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
   public class wwusuariosistema : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwusuariosistema( )
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

      public wwusuariosistema( IGxContext context )
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
         chkavAtt_usuariosistemaid_visible = new GXCheckbox();
         chkavAtt_usuariosistemaidentidad_visible = new GXCheckbox();
         chkavAtt_usuariosistemanombre_visible = new GXCheckbox();
         chkavAtt_usuariosistemagerencia_visible = new GXCheckbox();
         chkavAtt_usuariosistemadepartamento_visible = new GXCheckbox();
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
               AV23K2BToolsGenericSearchField = GetPar( "K2BToolsGenericSearchField");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV22ClassCollection);
               AV24OrderedBy = (short)(NumberUtil.Val( GetPar( "OrderedBy"), "."));
               AV8CurrentPage = (int)(NumberUtil.Val( GetPar( "CurrentPage"), "."));
               AV46Pgmname = GetPar( "Pgmname");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV10GridConfiguration);
               AV38UsuarioSistemaIdentidad_IsAuthorized = StringUtil.StrToBool( GetPar( "UsuarioSistemaIdentidad_IsAuthorized"));
               AV14Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaId_Visible"));
               AV37Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaIdentidad_Visible"));
               AV15Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaNombre_Visible"));
               AV39Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaGerencia_Visible"));
               AV40Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( GetPar( "Att_UsuarioSistemaDepartamento_Visible"));
               AV11FreezeColumnTitles = StringUtil.StrToBool( GetPar( "FreezeColumnTitles"));
               AV43Uri = GetPar( "Uri");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
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
            return "usuariosistema_Execute" ;
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
         PA502( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START502( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188203715", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwusuariosistema.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Uri, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vK2BTOOLSGENERICSEARCHFIELD", StringUtil.RTrim( AV23K2BToolsGenericSearchField));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_122", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_122), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDORDERS", AV25GridOrders);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDORDERS", AV25GridOrders);
         }
         GxWebStd.gx_hidden_field( context, "vUC_ORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27UC_OrderedBy), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION", AV22ClassCollection);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION", AV22ClassCollection);
         }
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CurrentPage), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24OrderedBy), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV10GridConfiguration);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED", AV38UsuarioSistemaIdentidad_IsAuthorized);
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGEVARIABLE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17RowsPerPageVariable), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vURI", AV43Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Uri, "")), context));
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
            WE502( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT502( ) ;
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
         return formatLink("wwusuariosistema.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWUsuarioSistema" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario sistemas" ;
      }

      protected void WB500( )
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
            GxWebStd.gx_label_ctrl( context, lblPgmdescriptortextblock_Internalname, "Usuario sistemas", "", "", lblPgmdescriptortextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavK2btoolsgenericsearchfield_Internalname, StringUtil.RTrim( AV23K2BToolsGenericSearchField), StringUtil.RTrim( context.localUtil.Format( AV23K2BToolsGenericSearchField, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavK2btoolsgenericsearchfield_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavK2btoolsgenericsearchfield_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWUsuarioSistema.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table1_24_502( true) ;
         }
         else
         {
            wb_table1_24_502( false) ;
         }
         return  ;
      }

      protected void wb_table1_24_502e( bool wbgen )
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaId_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Usuario Sistema:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaIdentidad_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Identidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaNombre_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaGerencia_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Gerencia") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtUsuarioSistemaDepartamento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Departamento") ;
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
               GridColumn.AddObjectProperty("Value", A99UsuarioSistemaId);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaId_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A101UsuarioSistemaIdentidad);
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtUsuarioSistemaIdentidad_Link));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A100UsuarioSistemaNombre);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A263UsuarioSistemaGerencia);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", A257UsuarioSistemaDepartamento);
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV31Update));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
               GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
               GridColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavUpdate_Tooltiptext));
               GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Visible), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", context.convertURL( AV32Delete));
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
            wb_table2_132_502( true) ;
         }
         else
         {
            wb_table2_132_502( false) ;
         }
         return  ;
      }

      protected void wb_table2_132_502e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblPreviouspagebuttontextblock_Internalname, "", "", "", lblPreviouspagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", lblPreviouspagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblFirstpagetextblock_Internalname, lblFirstpagetextblock_Caption, "", "", lblFirstpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOFIRST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblFirstpagetextblock_Visible, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacinglefttextblock_Internalname, "...", "", "", lblSpacinglefttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacinglefttextblock_Visible, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPreviouspagetextblock_Internalname, lblPreviouspagetextblock_Caption, "", "", lblPreviouspagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOPREVIOUS\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblPreviouspagetextblock_Visible, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCurrentpagetextblock_Internalname, lblCurrentpagetextblock_Caption, "", "", lblCurrentpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagetextblock_Internalname, lblNextpagetextblock_Caption, "", "", lblNextpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblNextpagetextblock_Visible, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSpacingrighttextblock_Internalname, "...", "", "", lblSpacingrighttextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblSpacingrighttextblock_Visible, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLastpagetextblock_Internalname, lblLastpagetextblock_Caption, "", "", lblLastpagetextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOLAST\\'."+"'", "", "K2BToolsTextBlock_PaginationNormal", 5, "", lblLastpagetextblock_Visible, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNextpagebuttontextblock_Internalname, "", "", "", lblNextpagebuttontextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DONEXT\\'."+"'", "", lblNextpagebuttontextblock_Class, 5, "", 1, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
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
            ucK2borderbyusercontrol.SetProperty("GridOrders", AV25GridOrders);
            ucK2borderbyusercontrol.SetProperty("SelectedOrderBy", AV27UC_OrderedBy);
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

      protected void START502( )
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
            Form.Meta.addItem("description", "Usuario sistemas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP500( ) ;
      }

      protected void WS502( )
      {
         START502( ) ;
         EVT502( ) ;
      }

      protected void EVT502( )
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
                              E11502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E12502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings' */
                              E13502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOFIRST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoFirst' */
                              E14502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOPREVIOUS'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoPrevious' */
                              E15502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DONEXT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoNext' */
                              E16502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOLAST'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoLast' */
                              E17502 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOEXPORT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoExport' */
                              E18502 ();
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
                              A99UsuarioSistemaId = cgiGet( edtUsuarioSistemaId_Internalname);
                              A101UsuarioSistemaIdentidad = cgiGet( edtUsuarioSistemaIdentidad_Internalname);
                              A100UsuarioSistemaNombre = cgiGet( edtUsuarioSistemaNombre_Internalname);
                              A263UsuarioSistemaGerencia = cgiGet( edtUsuarioSistemaGerencia_Internalname);
                              n263UsuarioSistemaGerencia = false;
                              A257UsuarioSistemaDepartamento = cgiGet( edtUsuarioSistemaDepartamento_Internalname);
                              n257UsuarioSistemaDepartamento = false;
                              AV31Update = cgiGet( edtavUpdate_Internalname);
                              AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV48Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_122_Refreshing);
                              AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
                              AV32Delete = cgiGet( edtavDelete_Internalname);
                              AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV49Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_122_Refreshing);
                              AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19502 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E20502 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E21502 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E22502 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If K2btoolsgenericsearchfield Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV23K2BToolsGenericSearchField) != 0 )
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

      protected void WE502( )
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

      protected void PA502( )
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
                                       string AV23K2BToolsGenericSearchField ,
                                       GxSimpleCollection<string> AV22ClassCollection ,
                                       short AV24OrderedBy ,
                                       int AV8CurrentPage ,
                                       string AV46Pgmname ,
                                       SdtK2BGridConfiguration AV10GridConfiguration ,
                                       bool AV38UsuarioSistemaIdentidad_IsAuthorized ,
                                       bool AV14Att_UsuarioSistemaId_Visible ,
                                       bool AV37Att_UsuarioSistemaIdentidad_Visible ,
                                       bool AV15Att_UsuarioSistemaNombre_Visible ,
                                       bool AV39Att_UsuarioSistemaGerencia_Visible ,
                                       bool AV40Att_UsuarioSistemaDepartamento_Visible ,
                                       bool AV11FreezeColumnTitles ,
                                       string AV43Uri )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E20502 ();
         GRID_nCurrentRecord = 0;
         RF502( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSISTEMAID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), context));
         GxWebStd.gx_hidden_field( context, "USUARIOSISTEMAID", A99UsuarioSistemaId);
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
         AV14Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_UsuarioSistemaId_Visible));
         AssignAttri("", false, "AV14Att_UsuarioSistemaId_Visible", AV14Att_UsuarioSistemaId_Visible);
         AV37Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV37Att_UsuarioSistemaIdentidad_Visible));
         AssignAttri("", false, "AV37Att_UsuarioSistemaIdentidad_Visible", AV37Att_UsuarioSistemaIdentidad_Visible);
         AV15Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_UsuarioSistemaNombre_Visible));
         AssignAttri("", false, "AV15Att_UsuarioSistemaNombre_Visible", AV15Att_UsuarioSistemaNombre_Visible);
         AV39Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV39Att_UsuarioSistemaGerencia_Visible));
         AssignAttri("", false, "AV39Att_UsuarioSistemaGerencia_Visible", AV39Att_UsuarioSistemaGerencia_Visible);
         AV40Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV40Att_UsuarioSistemaDepartamento_Visible));
         AssignAttri("", false, "AV40Att_UsuarioSistemaDepartamento_Visible", AV40Att_UsuarioSistemaDepartamento_Visible);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV16GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpagevariable_Internalname, "Values", cmbavGridsettingsrowsperpagevariable.ToJavascriptSource(), true);
         }
         AV11FreezeColumnTitles = StringUtil.StrToBool( StringUtil.BoolToStr( AV11FreezeColumnTitles));
         AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E20502 ();
         RF502( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV46Pgmname = "WWUsuarioSistema";
         context.Gx_err = 0;
      }

      protected void RF502( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 122;
         E21502 ();
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
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV23K2BToolsGenericSearchField ,
                                                 A99UsuarioSistemaId ,
                                                 A101UsuarioSistemaIdentidad ,
                                                 A100UsuarioSistemaNombre ,
                                                 A263UsuarioSistemaGerencia ,
                                                 A257UsuarioSistemaDepartamento ,
                                                 AV24OrderedBy } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
            /* Using cursor H00502 */
            pr_default.execute(0, new Object[] {lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_122_idx = 1;
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_1222( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A257UsuarioSistemaDepartamento = H00502_A257UsuarioSistemaDepartamento[0];
               n257UsuarioSistemaDepartamento = H00502_n257UsuarioSistemaDepartamento[0];
               A263UsuarioSistemaGerencia = H00502_A263UsuarioSistemaGerencia[0];
               n263UsuarioSistemaGerencia = H00502_n263UsuarioSistemaGerencia[0];
               A100UsuarioSistemaNombre = H00502_A100UsuarioSistemaNombre[0];
               A101UsuarioSistemaIdentidad = H00502_A101UsuarioSistemaIdentidad[0];
               A99UsuarioSistemaId = H00502_A99UsuarioSistemaId[0];
               E22502 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 122;
            WB500( ) ;
         }
         bGXsfl_122_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes502( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV46Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSISTEMAID"+"_"+sGXsfl_122_idx, GetSecureSignedToken( sGXsfl_122_idx, StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), context));
         GxWebStd.gx_hidden_field( context, "vURI", AV43Uri);
         GxWebStd.gx_hidden_field( context, "gxhash_vURI", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV43Uri, "")), context));
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
                                              AV23K2BToolsGenericSearchField ,
                                              A99UsuarioSistemaId ,
                                              A101UsuarioSistemaIdentidad ,
                                              A100UsuarioSistemaNombre ,
                                              A263UsuarioSistemaGerencia ,
                                              A257UsuarioSistemaDepartamento ,
                                              AV24OrderedBy } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         lV23K2BToolsGenericSearchField = StringUtil.PadR( StringUtil.RTrim( AV23K2BToolsGenericSearchField), 100, "%");
         /* Using cursor H00503 */
         pr_default.execute(1, new Object[] {lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField, lV23K2BToolsGenericSearchField});
         GRID_nRecordCount = H00503_AGRID_nRecordCount[0];
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
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
            gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV46Pgmname = "WWUsuarioSistema";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP500( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19502 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vGRIDORDERS"), AV25GridOrders);
            /* Read saved values. */
            nRC_GXsfl_122 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_122"), ".", ","));
            AV27UC_OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vUC_ORDEREDBY"), ".", ","));
            AV24OrderedBy = (short)(context.localUtil.CToN( cgiGet( "vORDEREDBY"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            K2borderbyusercontrol_Gridcontrolname = cgiGet( "K2BORDERBYUSERCONTROL_Gridcontrolname");
            bttReport_Visible = (int)(context.localUtil.CToN( cgiGet( "REPORT_Visible"), ".", ","));
            bttExport_Visible = (int)(context.localUtil.CToN( cgiGet( "EXPORT_Visible"), ".", ","));
            /* Read variables values. */
            AV23K2BToolsGenericSearchField = cgiGet( edtavK2btoolsgenericsearchfield_Internalname);
            AssignAttri("", false, "AV23K2BToolsGenericSearchField", AV23K2BToolsGenericSearchField);
            AV14Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemaid_visible_Internalname));
            AssignAttri("", false, "AV14Att_UsuarioSistemaId_Visible", AV14Att_UsuarioSistemaId_Visible);
            AV37Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemaidentidad_visible_Internalname));
            AssignAttri("", false, "AV37Att_UsuarioSistemaIdentidad_Visible", AV37Att_UsuarioSistemaIdentidad_Visible);
            AV15Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemanombre_visible_Internalname));
            AssignAttri("", false, "AV15Att_UsuarioSistemaNombre_Visible", AV15Att_UsuarioSistemaNombre_Visible);
            AV39Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemagerencia_visible_Internalname));
            AssignAttri("", false, "AV39Att_UsuarioSistemaGerencia_Visible", AV39Att_UsuarioSistemaGerencia_Visible);
            AV40Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( cgiGet( chkavAtt_usuariosistemadepartamento_visible_Internalname));
            AssignAttri("", false, "AV40Att_UsuarioSistemaDepartamento_Visible", AV40Att_UsuarioSistemaDepartamento_Visible);
            cmbavGridsettingsrowsperpagevariable.Name = cmbavGridsettingsrowsperpagevariable_Internalname;
            cmbavGridsettingsrowsperpagevariable.CurrentValue = cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname);
            AV16GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpagevariable_Internalname), "."));
            AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
            AV11FreezeColumnTitles = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_Internalname));
            AssignAttri("", false, "AV11FreezeColumnTitles", AV11FreezeColumnTitles);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vK2BTOOLSGENERICSEARCHFIELD"), AV23K2BToolsGenericSearchField) != 0 )
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
         E19502 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19502( )
      {
         /* Start Routine */
         returnInSub = false;
         divDownloadactionstable_Visible = 0;
         AssignProp("", false, divDownloadactionstable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divDownloadactionstable_Visible), 5, 0), true);
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         new k2bloadrowsperpage(context ).execute(  AV46Pgmname,  "Grid", out  AV17RowsPerPageVariable, out  AV18RowsPerPageLoaded) ;
         AssignAttri("", false, "AV17RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV17RowsPerPageVariable), 4, 0));
         if ( ! AV18RowsPerPageLoaded )
         {
            AV17RowsPerPageVariable = 20;
            AssignAttri("", false, "AV17RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV17RowsPerPageVariable), 4, 0));
         }
         AV16GridSettingsRowsPerPageVariable = AV17RowsPerPageVariable;
         AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
         subGrid_Rows = AV17RowsPerPageVariable;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Form.Caption = "Usuario sistemas";
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
         AV25GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
         AV26GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV26GridOrder.gxTpr_Ascendingorder = 0;
         AV26GridOrder.gxTpr_Descendingorder = 1;
         AV26GridOrder.gxTpr_Gridcolumnindex = 1;
         AV25GridOrders.Add(AV26GridOrder, 0);
         AV26GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV26GridOrder.gxTpr_Ascendingorder = 2;
         AV26GridOrder.gxTpr_Descendingorder = 3;
         AV26GridOrder.gxTpr_Gridcolumnindex = 2;
         AV25GridOrders.Add(AV26GridOrder, 0);
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
      }

      protected void E20502( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV28Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV28Messages = GXt_objcol_SdtMessages_Message1;
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV28Messages.Count )
         {
            AV29Message = ((GeneXus.Utils.SdtMessages_Message)AV28Messages.Item(AV47GXV1));
            GX_msglist.addItem(AV29Message.gxTpr_Description);
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = AV46Pgmname;
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Entityname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Transactionname)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Standardactivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Useractivitytype)),UrlEncode(StringUtil.RTrim(((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Activity.gxTpr_Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         AV31Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV48Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         AV48Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV48Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_122_Refreshing);
         AV32Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV49Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
         AV49Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV49Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
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
         new k2bscjoinstring(context ).execute(  AV22ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void S112( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         AV19GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV46Pgmname,  AV19GridStateKey, out  AV20GridState) ;
         AV24OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         AV27UC_OrderedBy = AV20GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV27UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV27UC_OrderedBy), 4, 0));
         AV50GXV2 = 1;
         while ( AV50GXV2 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV50GXV2));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Filtername, "K2BToolsGenericSearchField") == 0 )
            {
               AV23K2BToolsGenericSearchField = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV23K2BToolsGenericSearchField", AV23K2BToolsGenericSearchField);
            }
            AV50GXV2 = (int)(AV50GXV2+1);
         }
         AV9K2BMaxPages = subGrid_fnc_Pagecount( );
         if ( ( AV20GridState.gxTpr_Currentpage > 0 ) && ( AV20GridState.gxTpr_Currentpage <= AV9K2BMaxPages ) )
         {
            AV8CurrentPage = AV20GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_gotopage( AV8CurrentPage) ;
         }
      }

      protected void S122( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV19GridStateKey = "";
         new k2bloadgridstate(context ).execute(  AV46Pgmname,  AV19GridStateKey, out  AV20GridState) ;
         AV20GridState.gxTpr_Currentpage = (short)(AV8CurrentPage);
         AV20GridState.gxTpr_Orderedby = AV24OrderedBy;
         AV20GridState.gxTpr_Filtervalues.Clear();
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV21GridStateFilterValue.gxTpr_Filtername = "K2BToolsGenericSearchField";
         AV21GridStateFilterValue.gxTpr_Value = AV23K2BToolsGenericSearchField;
         AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV46Pgmname,  AV19GridStateKey,  AV20GridState) ;
      }

      protected void S182( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV33TrnContext = new SdtK2BTrnContext(context);
         AV33TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV33TrnContext.gxTpr_Returnmode = "Stack";
         AV33TrnContext.gxTpr_Afterinsert = new SdtK2BTrnNavigation(context);
         AV33TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn = 2;
         AV33TrnContext.gxTpr_Afterupdate = new SdtK2BTrnNavigation(context);
         AV33TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn = 1;
         AV33TrnContext.gxTpr_Afterdelete = new SdtK2BTrnNavigation(context);
         AV33TrnContext.gxTpr_Afterdelete.gxTpr_Aftertrn = 1;
         new k2bsettrncontextbyname(context ).execute(  "UsuarioSistema",  AV33TrnContext) ;
      }

      protected void E12502( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "UsuarioSistema",  "UsuarioSistema",  "Insert",  "",  "EntityManagerUsuarioSistema") )
         {
            CallWebObject(formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.RTrim("")),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S192( )
      {
         /* 'HIDESHOWCOLUMNS' Routine */
         returnInSub = false;
         edtUsuarioSistemaId_Visible = 1;
         AssignProp("", false, edtUsuarioSistemaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV14Att_UsuarioSistemaId_Visible = true;
         AssignAttri("", false, "AV14Att_UsuarioSistemaId_Visible", AV14Att_UsuarioSistemaId_Visible);
         edtUsuarioSistemaIdentidad_Visible = 1;
         AssignProp("", false, edtUsuarioSistemaIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV37Att_UsuarioSistemaIdentidad_Visible = true;
         AssignAttri("", false, "AV37Att_UsuarioSistemaIdentidad_Visible", AV37Att_UsuarioSistemaIdentidad_Visible);
         edtUsuarioSistemaNombre_Visible = 1;
         AssignProp("", false, edtUsuarioSistemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV15Att_UsuarioSistemaNombre_Visible = true;
         AssignAttri("", false, "AV15Att_UsuarioSistemaNombre_Visible", AV15Att_UsuarioSistemaNombre_Visible);
         edtUsuarioSistemaGerencia_Visible = 1;
         AssignProp("", false, edtUsuarioSistemaGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV39Att_UsuarioSistemaGerencia_Visible = true;
         AssignAttri("", false, "AV39Att_UsuarioSistemaGerencia_Visible", AV39Att_UsuarioSistemaGerencia_Visible);
         edtUsuarioSistemaDepartamento_Visible = 1;
         AssignProp("", false, edtUsuarioSistemaDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0), !bGXsfl_122_Refreshing);
         AV40Att_UsuarioSistemaDepartamento_Visible = true;
         AssignAttri("", false, "AV40Att_UsuarioSistemaDepartamento_Visible", AV40Att_UsuarioSistemaDepartamento_Visible);
         new k2bsavegridconfiguration(context ).execute(  AV46Pgmname,  "Grid",  AV10GridConfiguration,  false) ;
         AV51GXV3 = 1;
         while ( AV51GXV3 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV51GXV3));
            if ( ! AV13GridColumn.gxTpr_Showattribute )
            {
               if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
               {
                  edtUsuarioSistemaId_Visible = 0;
                  AssignProp("", false, edtUsuarioSistemaId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV14Att_UsuarioSistemaId_Visible = false;
                  AssignAttri("", false, "AV14Att_UsuarioSistemaId_Visible", AV14Att_UsuarioSistemaId_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
               {
                  edtUsuarioSistemaIdentidad_Visible = 0;
                  AssignProp("", false, edtUsuarioSistemaIdentidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV37Att_UsuarioSistemaIdentidad_Visible = false;
                  AssignAttri("", false, "AV37Att_UsuarioSistemaIdentidad_Visible", AV37Att_UsuarioSistemaIdentidad_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
               {
                  edtUsuarioSistemaNombre_Visible = 0;
                  AssignProp("", false, edtUsuarioSistemaNombre_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV15Att_UsuarioSistemaNombre_Visible = false;
                  AssignAttri("", false, "AV15Att_UsuarioSistemaNombre_Visible", AV15Att_UsuarioSistemaNombre_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
               {
                  edtUsuarioSistemaGerencia_Visible = 0;
                  AssignProp("", false, edtUsuarioSistemaGerencia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV39Att_UsuarioSistemaGerencia_Visible = false;
                  AssignAttri("", false, "AV39Att_UsuarioSistemaGerencia_Visible", AV39Att_UsuarioSistemaGerencia_Visible);
               }
               else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
               {
                  edtUsuarioSistemaDepartamento_Visible = 0;
                  AssignProp("", false, edtUsuarioSistemaDepartamento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Visible), 5, 0), !bGXsfl_122_Refreshing);
                  AV40Att_UsuarioSistemaDepartamento_Visible = false;
                  AssignAttri("", false, "AV40Att_UsuarioSistemaDepartamento_Visible", AV40Att_UsuarioSistemaDepartamento_Visible);
               }
            }
            AV51GXV3 = (int)(AV51GXV3+1);
         }
      }

      protected void S172( )
      {
         /* 'LOADAVAILABLECOLUMNS' Routine */
         returnInSub = false;
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioSistemaId";
         AV13GridColumn.gxTpr_Columntitle = "Usuario Sistema:";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioSistemaIdentidad";
         AV13GridColumn.gxTpr_Columntitle = "Identidad";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioSistemaNombre";
         AV13GridColumn.gxTpr_Columntitle = "Nombre";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioSistemaGerencia";
         AV13GridColumn.gxTpr_Columntitle = "Gerencia";
         AV13GridColumn.gxTpr_Showattribute = true;
         AV12GridColumns.Add(AV13GridColumn, 0);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV13GridColumn.gxTpr_Attributename = "UsuarioSistemaDepartamento";
         AV13GridColumn.gxTpr_Columntitle = "Departamento";
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
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ReportWWUsuarioSistema";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "List";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "ExportWWUsuarioSistema";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Insert";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttReport_Visible = 1;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         else
         {
            bttReport_Visible = 0;
            AssignProp("", false, bttReport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttReport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttExport_Visible = 1;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         else
         {
            bttExport_Visible = 0;
            AssignProp("", false, bttExport_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttExport_Visible), 5, 0), true);
         }
         if ( ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(3)).gxTpr_Isauthorized )
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
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Update";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Delete";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Transactionname = "UsuarioSistema";
         AV36ActivityListItem.gxTpr_Activity.gxTpr_Pgmname = "EntityManagerUsuarioSistema";
         AV35ActivityList.Add(AV36ActivityListItem, 0);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV35ActivityList) ;
         AV38UsuarioSistemaIdentidad_IsAuthorized = ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(1)).gxTpr_Isauthorized;
         AssignAttri("", false, "AV38UsuarioSistemaIdentidad_IsAuthorized", AV38UsuarioSistemaIdentidad_IsAuthorized);
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            edtavUpdate_Visible = 0;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_122_Refreshing);
         }
         else
         {
            edtavUpdate_Visible = 1;
            AssignProp("", false, edtavUpdate_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUpdate_Visible), 5, 0), !bGXsfl_122_Refreshing);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV35ActivityList.Item(3)).gxTpr_Isauthorized )
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

      protected void E21502( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV22ClassCollection) ;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         bttReport_Tooltiptext = "";
         AssignProp("", false, bttReport_Internalname, "Tooltiptext", bttReport_Tooltiptext, true);
         bttExport_Tooltiptext = "";
         AssignProp("", false, bttExport_Internalname, "Tooltiptext", bttExport_Tooltiptext, true);
         bttInsert_Tooltiptext = "Agregar";
         AssignProp("", false, bttInsert_Internalname, "Tooltiptext", bttInsert_Tooltiptext, true);
         AV31Update = context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( ));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV48Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         AV48Update_GXI = GXDbFile.PathToUrl( context.GetImagePath( "788f9b72-f982-49f9-99e4-c0374e31a85a", "", context.GetTheme( )));
         AssignProp("", false, edtavUpdate_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV48Update_GXI : context.convertURL( context.PathToRelativeUrl( AV31Update))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavUpdate_Internalname, "SrcSet", context.GetImageSrcSet( AV31Update), true);
         edtavUpdate_Tooltiptext = "Actualizar";
         AssignProp("", false, edtavUpdate_Internalname, "Tooltiptext", edtavUpdate_Tooltiptext, !bGXsfl_122_Refreshing);
         AV32Delete = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV49Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
         AV49Delete_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         AssignProp("", false, edtavDelete_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV49Delete_GXI : context.convertURL( context.PathToRelativeUrl( AV32Delete))), !bGXsfl_122_Refreshing);
         AssignProp("", false, edtavDelete_Internalname, "SrcSet", context.GetImageSrcSet( AV32Delete), true);
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
         AV27UC_OrderedBy = AV24OrderedBy;
         AssignAttri("", false, "AV27UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV27UC_OrderedBy), 4, 0));
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
         new k2bscjoinstring(context ).execute(  AV22ClassCollection,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_grid_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
      }

      private void E22502( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblNoresultsfoundtable_Visible = 0;
         AssignProp("", false, tblNoresultsfoundtable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblNoresultsfoundtable_Visible), 5, 0), true);
         if ( AV38UsuarioSistemaIdentidad_IsAuthorized )
         {
            edtUsuarioSistemaIdentidad_Link = formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) ;
         }
         else
         {
            edtUsuarioSistemaIdentidad_Link = "";
         }
         edtavUpdate_Enabled = 1;
         edtavUpdate_Link = formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) ;
         edtavUpdate_Tooltiptext = "Actualizar";
         edtavDelete_Enabled = 1;
         edtavDelete_Link = formatLink("entitymanagerusuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioSistemaId","TabCode"}) ;
         edtavDelete_Tooltiptext = "Eliminar";
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 122;
         }
         sendrow_1222( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_122_Refreshing )
         {
            context.DoAjaxLoad(122, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E11502( )
      {
         /* K2borderbyusercontrol_Orderbychanged Routine */
         returnInSub = false;
         AV24OrderedBy = AV27UC_OrderedBy;
         AssignAttri("", false, "AV24OrderedBy", StringUtil.LTrimStr( (decimal)(AV24OrderedBy), 4, 0));
         gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E13502( )
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
         new k2bloadgridconfiguration(context ).execute(  AV46Pgmname,  "Grid", ref  AV10GridConfiguration) ;
         AV52GXV4 = 1;
         while ( AV52GXV4 <= AV10GridConfiguration.gxTpr_Gridcolumns.Count )
         {
            AV13GridColumn = ((SdtK2BGridColumns_K2BGridColumnsItem)AV10GridConfiguration.gxTpr_Gridcolumns.Item(AV52GXV4));
            if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaId") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV14Att_UsuarioSistemaId_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaIdentidad") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV37Att_UsuarioSistemaIdentidad_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaNombre") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV15Att_UsuarioSistemaNombre_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaGerencia") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV39Att_UsuarioSistemaGerencia_Visible;
            }
            else if ( StringUtil.StrCmp(AV13GridColumn.gxTpr_Attributename, "UsuarioSistemaDepartamento") == 0 )
            {
               AV13GridColumn.gxTpr_Showattribute = AV40Att_UsuarioSistemaDepartamento_Visible;
            }
            AV52GXV4 = (int)(AV52GXV4+1);
         }
         AV10GridConfiguration.gxTpr_Freezecolumntitles = AV11FreezeColumnTitles;
         new k2bsavegridconfiguration(context ).execute(  AV46Pgmname,  "Grid",  AV10GridConfiguration,  true) ;
         AV27UC_OrderedBy = AV24OrderedBy;
         AssignAttri("", false, "AV27UC_OrderedBy", StringUtil.LTrimStr( (decimal)(AV27UC_OrderedBy), 4, 0));
         if ( AV17RowsPerPageVariable != AV16GridSettingsRowsPerPageVariable )
         {
            AV17RowsPerPageVariable = AV16GridSettingsRowsPerPageVariable;
            AssignAttri("", false, "AV17RowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV17RowsPerPageVariable), 4, 0));
            subGrid_Rows = AV17RowsPerPageVariable;
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            new k2bsaverowsperpage(context ).execute(  AV46Pgmname,  "Grid",  AV17RowsPerPageVariable) ;
            AV8CurrentPage = 1;
            AssignAttri("", false, "AV8CurrentPage", StringUtil.LTrimStr( (decimal)(AV8CurrentPage), 5, 0));
            subgrid_firstpage( ) ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV23K2BToolsGenericSearchField, AV22ClassCollection, AV24OrderedBy, AV8CurrentPage, AV46Pgmname, AV10GridConfiguration, AV38UsuarioSistemaIdentidad_IsAuthorized, AV14Att_UsuarioSistemaId_Visible, AV37Att_UsuarioSistemaIdentidad_Visible, AV15Att_UsuarioSistemaNombre_Visible, AV39Att_UsuarioSistemaGerencia_Visible, AV40Att_UsuarioSistemaDepartamento_Visible, AV11FreezeColumnTitles, AV43Uri) ;
         divK2bgridsettingscontentoutertable_Visible = 0;
         AssignProp("", false, divK2bgridsettingscontentoutertable_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2bgridsettingscontentoutertable_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10GridConfiguration", AV10GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
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

      protected void E14502( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E15502( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E16502( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
      }

      protected void E17502( )
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV22ClassCollection", AV22ClassCollection);
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
         new k2bloadgridconfiguration(context ).execute(  AV46Pgmname,  "Grid", ref  AV10GridConfiguration) ;
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
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV22ClassCollection) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV22ClassCollection) ;
         }
      }

      protected void E18502( )
      {
         /* 'DoExport' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "UsuarioSistema",  "UsuarioSistema",  "List",  "",  "ExportWWUsuarioSistema") )
         {
            new exportwwusuariosistema(context ).execute(  AV23K2BToolsGenericSearchField,  AV24OrderedBy, out  AV41OutFile) ;
            if ( new k2bt_isinexternalstorage(context).executeUdp(  AV41OutFile, out  AV43Uri) )
            {
               CallWebObject(formatLink(AV43Uri) );
               context.wjLocDisableFrm = 0;
            }
            else
            {
               AV42Guid = (Guid)(Guid.NewGuid( ));
               new k2bsessionset(context ).execute(  AV42Guid.ToString(),  AV41OutFile) ;
               CallWebObject(formatLink("k2bt_returnfileinhttpresponse.aspx", new object[] {UrlEncode(AV42Guid.ToString())}, new string[] {"Guid"}) );
               context.wjLocDisableFrm = 2;
            }
         }
      }

      protected void wb_table2_132_502( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblNoresultsfoundtextblock_Internalname, "No hay resultados", "", "", lblNoresultsfoundtextblock_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_132_502e( true) ;
         }
         else
         {
            wb_table2_132_502e( false) ;
         }
      }

      protected void wb_table1_24_502( bool wbgen )
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
            GxWebStd.gx_bitmap( context, imgK2bgridsettingslabel_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgK2bgridsettingslabel_Jsonclick, "'"+""+"'"+",false,"+"'"+"e23501_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWUsuarioSistema.htm");
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
            GxWebStd.gx_label_ctrl( context, lblRuntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblRuntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_WWUsuarioSistema.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosistemaid_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemaid_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemaid_visible_Internalname, "Usuario Sistema:", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemaid_visible_Internalname, StringUtil.BoolToStr( AV14Att_UsuarioSistemaId_Visible), "", "Usuario Sistema:", 1, chkavAtt_usuariosistemaid_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,53);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemaidentidad_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemaidentidad_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemaidentidad_visible_Internalname, "Identidad", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemaidentidad_visible_Internalname, StringUtil.BoolToStr( AV37Att_UsuarioSistemaIdentidad_Visible), "", "Identidad", 1, chkavAtt_usuariosistemaidentidad_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(59, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,59);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemanombre_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemanombre_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemanombre_visible_Internalname, "Nombre", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemanombre_visible_Internalname, StringUtil.BoolToStr( AV15Att_UsuarioSistemaNombre_Visible), "", "Nombre", 1, chkavAtt_usuariosistemanombre_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(65, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,65);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemagerencia_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemagerencia_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemagerencia_visible_Internalname, "Gerencia", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemagerencia_visible_Internalname, StringUtil.BoolToStr( AV39Att_UsuarioSistemaGerencia_Visible), "", "Gerencia", 1, chkavAtt_usuariosistemagerencia_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(71, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,71);\"");
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
            GxWebStd.gx_div_start( context, divUsuariosistemadepartamento_gridsettingscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavAtt_usuariosistemadepartamento_visible_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavAtt_usuariosistemadepartamento_visible_Internalname, "Departamento", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_122_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAtt_usuariosistemadepartamento_visible_Internalname, StringUtil.BoolToStr( AV40Att_UsuarioSistemaDepartamento_Visible), "", "Departamento", 1, chkavAtt_usuariosistemadepartamento_visible.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(77, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,77);\"");
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpagevariable, cmbavGridsettingsrowsperpagevariable_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0)), 1, cmbavGridsettingsrowsperpagevariable_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpagevariable.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 1, "HLP_WWUsuarioSistema.htm");
            cmbavGridsettingsrowsperpagevariable.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
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
            GxWebStd.gx_button_ctrl( context, bttK2bgridsettingssave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Aplicar", bttK2bgridsettingssave_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWUsuarioSistema.htm");
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
            GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"e24501_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_WWUsuarioSistema.htm");
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
            wb_table3_103_502( true) ;
         }
         else
         {
            wb_table3_103_502( false) ;
         }
         return  ;
      }

      protected void wb_table3_103_502e( bool wbgen )
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
            wb_table4_110_502( true) ;
         }
         else
         {
            wb_table4_110_502( false) ;
         }
         return  ;
      }

      protected void wb_table4_110_502e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_24_502e( true) ;
         }
         else
         {
            wb_table1_24_502e( false) ;
         }
      }

      protected void wb_table4_110_502( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttInsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Nuevo", bttInsert_Jsonclick, 5, bttInsert_Tooltiptext, "", StyleString, ClassString, bttInsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWUsuarioSistema.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_110_502e( true) ;
         }
         else
         {
            wb_table4_110_502e( false) ;
         }
      }

      protected void wb_table3_103_502( bool wbgen )
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
            GxWebStd.gx_button_ctrl( context, bttReport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Reporte", bttReport_Jsonclick, 7, bttReport_Tooltiptext, "", StyleString, ClassString, bttReport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"e25501_client"+"'", TempTags, "", 2, "HLP_WWUsuarioSistema.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            ClassString = "Button_Standard";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttExport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(122), 3, 0)+","+"null"+");", "Exportar", bttExport_Jsonclick, 5, bttExport_Tooltiptext, "", StyleString, ClassString, bttExport_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOEXPORT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWUsuarioSistema.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_103_502e( true) ;
         }
         else
         {
            wb_table3_103_502e( false) ;
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
         PA502( ) ;
         WS502( ) ;
         WE502( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188204069", true, true);
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
         context.AddJavascriptSource("wwusuariosistema.js", "?2024188204071", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BOrderBy/K2BOrderByRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1222( )
      {
         edtUsuarioSistemaId_Internalname = "USUARIOSISTEMAID_"+sGXsfl_122_idx;
         edtUsuarioSistemaIdentidad_Internalname = "USUARIOSISTEMAIDENTIDAD_"+sGXsfl_122_idx;
         edtUsuarioSistemaNombre_Internalname = "USUARIOSISTEMANOMBRE_"+sGXsfl_122_idx;
         edtUsuarioSistemaGerencia_Internalname = "USUARIOSISTEMAGERENCIA_"+sGXsfl_122_idx;
         edtUsuarioSistemaDepartamento_Internalname = "USUARIOSISTEMADEPARTAMENTO_"+sGXsfl_122_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_122_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_122_idx;
      }

      protected void SubsflControlProps_fel_1222( )
      {
         edtUsuarioSistemaId_Internalname = "USUARIOSISTEMAID_"+sGXsfl_122_fel_idx;
         edtUsuarioSistemaIdentidad_Internalname = "USUARIOSISTEMAIDENTIDAD_"+sGXsfl_122_fel_idx;
         edtUsuarioSistemaNombre_Internalname = "USUARIOSISTEMANOMBRE_"+sGXsfl_122_fel_idx;
         edtUsuarioSistemaGerencia_Internalname = "USUARIOSISTEMAGERENCIA_"+sGXsfl_122_fel_idx;
         edtUsuarioSistemaDepartamento_Internalname = "USUARIOSISTEMADEPARTAMENTO_"+sGXsfl_122_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_122_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_122_fel_idx;
      }

      protected void sendrow_1222( )
      {
         SubsflControlProps_1222( ) ;
         WB500( ) ;
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaId_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaId_Internalname,(string)A99UsuarioSistemaId,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaId_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)122,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaIdentidad_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaIdentidad_Internalname,(string)A101UsuarioSistemaIdentidad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioSistemaIdentidad_Link,(string)"",(string)"",(string)"",(string)edtUsuarioSistemaIdentidad_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(int)edtUsuarioSistemaIdentidad_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaNombre_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaNombre_Internalname,(string)A100UsuarioSistemaNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn K2BToolsSortableColumn",(string)"",(int)edtUsuarioSistemaNombre_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaGerencia_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaGerencia_Internalname,(string)A263UsuarioSistemaGerencia,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaGerencia_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaGerencia_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+((edtUsuarioSistemaDepartamento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute_Grid";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaDepartamento_Internalname,(string)A257UsuarioSistemaDepartamento,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaDepartamento_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtUsuarioSistemaDepartamento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)300,(short)0,(short)0,(short)122,(short)1,(short)-1,(short)-1,(bool)true,(string)"Texto",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavUpdate_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV31Update_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV31Update))&&String.IsNullOrEmpty(StringUtil.RTrim( AV48Update_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV31Update)) ? AV48Update_GXI : context.PathToRelativeUrl( AV31Update));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,(string)sImgUrl,(string)edtavUpdate_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavUpdate_Visible,(int)edtavUpdate_Enabled,(string)"",(string)edtavUpdate_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV31Update_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((edtavDelete_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "Image_Action";
            StyleString = "";
            AV32Delete_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete))&&String.IsNullOrEmpty(StringUtil.RTrim( AV49Delete_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV32Delete)) ? AV49Delete_GXI : context.PathToRelativeUrl( AV32Delete));
            GridRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,(string)sImgUrl,(string)edtavDelete_Link,(string)"",(string)"",context.GetTheme( ),(int)edtavDelete_Visible,(int)edtavDelete_Enabled,(string)"",(string)edtavDelete_Tooltiptext,(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV32Delete_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            send_integrity_lvl_hashes502( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_122_idx = ((subGrid_Islastpage==1)&&(nGXsfl_122_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_122_idx+1);
            sGXsfl_122_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_122_idx), 4, 0), 4, "0");
            SubsflControlProps_1222( ) ;
         }
         /* End function sendrow_1222 */
      }

      protected void init_web_controls( )
      {
         chkavAtt_usuariosistemaid_visible.Name = "vATT_USUARIOSISTEMAID_VISIBLE";
         chkavAtt_usuariosistemaid_visible.WebTags = "";
         chkavAtt_usuariosistemaid_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariosistemaid_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemaid_visible.Caption, true);
         chkavAtt_usuariosistemaid_visible.CheckedValue = "false";
         AV14Att_UsuarioSistemaId_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV14Att_UsuarioSistemaId_Visible));
         AssignAttri("", false, "AV14Att_UsuarioSistemaId_Visible", AV14Att_UsuarioSistemaId_Visible);
         chkavAtt_usuariosistemaidentidad_visible.Name = "vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE";
         chkavAtt_usuariosistemaidentidad_visible.WebTags = "";
         chkavAtt_usuariosistemaidentidad_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariosistemaidentidad_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemaidentidad_visible.Caption, true);
         chkavAtt_usuariosistemaidentidad_visible.CheckedValue = "false";
         AV37Att_UsuarioSistemaIdentidad_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV37Att_UsuarioSistemaIdentidad_Visible));
         AssignAttri("", false, "AV37Att_UsuarioSistemaIdentidad_Visible", AV37Att_UsuarioSistemaIdentidad_Visible);
         chkavAtt_usuariosistemanombre_visible.Name = "vATT_USUARIOSISTEMANOMBRE_VISIBLE";
         chkavAtt_usuariosistemanombre_visible.WebTags = "";
         chkavAtt_usuariosistemanombre_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariosistemanombre_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemanombre_visible.Caption, true);
         chkavAtt_usuariosistemanombre_visible.CheckedValue = "false";
         AV15Att_UsuarioSistemaNombre_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV15Att_UsuarioSistemaNombre_Visible));
         AssignAttri("", false, "AV15Att_UsuarioSistemaNombre_Visible", AV15Att_UsuarioSistemaNombre_Visible);
         chkavAtt_usuariosistemagerencia_visible.Name = "vATT_USUARIOSISTEMAGERENCIA_VISIBLE";
         chkavAtt_usuariosistemagerencia_visible.WebTags = "";
         chkavAtt_usuariosistemagerencia_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariosistemagerencia_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemagerencia_visible.Caption, true);
         chkavAtt_usuariosistemagerencia_visible.CheckedValue = "false";
         AV39Att_UsuarioSistemaGerencia_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV39Att_UsuarioSistemaGerencia_Visible));
         AssignAttri("", false, "AV39Att_UsuarioSistemaGerencia_Visible", AV39Att_UsuarioSistemaGerencia_Visible);
         chkavAtt_usuariosistemadepartamento_visible.Name = "vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE";
         chkavAtt_usuariosistemadepartamento_visible.WebTags = "";
         chkavAtt_usuariosistemadepartamento_visible.Caption = "";
         AssignProp("", false, chkavAtt_usuariosistemadepartamento_visible_Internalname, "TitleCaption", chkavAtt_usuariosistemadepartamento_visible.Caption, true);
         chkavAtt_usuariosistemadepartamento_visible.CheckedValue = "false";
         AV40Att_UsuarioSistemaDepartamento_Visible = StringUtil.StrToBool( StringUtil.BoolToStr( AV40Att_UsuarioSistemaDepartamento_Visible));
         AssignAttri("", false, "AV40Att_UsuarioSistemaDepartamento_Visible", AV40Att_UsuarioSistemaDepartamento_Visible);
         cmbavGridsettingsrowsperpagevariable.Name = "vGRIDSETTINGSROWSPERPAGEVARIABLE";
         cmbavGridsettingsrowsperpagevariable.WebTags = "";
         cmbavGridsettingsrowsperpagevariable.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpagevariable.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpagevariable.ItemCount > 0 )
         {
            AV16GridSettingsRowsPerPageVariable = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpagevariable.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0))), "."));
            AssignAttri("", false, "AV16GridSettingsRowsPerPageVariable", StringUtil.LTrimStr( (decimal)(AV16GridSettingsRowsPerPageVariable), 4, 0));
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
         chkavAtt_usuariosistemaid_visible_Internalname = "vATT_USUARIOSISTEMAID_VISIBLE";
         divUsuariosistemaid_gridsettingscontainer_Internalname = "USUARIOSISTEMAID_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemaidentidad_visible_Internalname = "vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE";
         divUsuariosistemaidentidad_gridsettingscontainer_Internalname = "USUARIOSISTEMAIDENTIDAD_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemanombre_visible_Internalname = "vATT_USUARIOSISTEMANOMBRE_VISIBLE";
         divUsuariosistemanombre_gridsettingscontainer_Internalname = "USUARIOSISTEMANOMBRE_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemagerencia_visible_Internalname = "vATT_USUARIOSISTEMAGERENCIA_VISIBLE";
         divUsuariosistemagerencia_gridsettingscontainer_Internalname = "USUARIOSISTEMAGERENCIA_GRIDSETTINGSCONTAINER";
         chkavAtt_usuariosistemadepartamento_visible_Internalname = "vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE";
         divUsuariosistemadepartamento_gridsettingscontainer_Internalname = "USUARIOSISTEMADEPARTAMENTO_GRIDSETTINGSCONTAINER";
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
         edtUsuarioSistemaId_Internalname = "USUARIOSISTEMAID";
         edtUsuarioSistemaIdentidad_Internalname = "USUARIOSISTEMAIDENTIDAD";
         edtUsuarioSistemaNombre_Internalname = "USUARIOSISTEMANOMBRE";
         edtUsuarioSistemaGerencia_Internalname = "USUARIOSISTEMAGERENCIA";
         edtUsuarioSistemaDepartamento_Internalname = "USUARIOSISTEMADEPARTAMENTO";
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
         chkavAtt_usuariosistemadepartamento_visible.Caption = "Departamento";
         chkavAtt_usuariosistemagerencia_visible.Caption = "Gerencia";
         chkavAtt_usuariosistemanombre_visible.Caption = "Nombre";
         chkavAtt_usuariosistemaidentidad_visible.Caption = "Identidad";
         chkavAtt_usuariosistemaid_visible.Caption = "Usuario Sistema:";
         edtUsuarioSistemaDepartamento_Jsonclick = "";
         edtUsuarioSistemaGerencia_Jsonclick = "";
         edtUsuarioSistemaNombre_Jsonclick = "";
         edtUsuarioSistemaIdentidad_Jsonclick = "";
         edtUsuarioSistemaId_Jsonclick = "";
         bttExport_Visible = 1;
         bttReport_Visible = 1;
         bttInsert_Visible = 1;
         divDownloadactionstable_Visible = 1;
         divDownloadsactionssectioncontainer_Visible = 1;
         chkavFreezecolumntitles.Enabled = 1;
         cmbavGridsettingsrowsperpagevariable_Jsonclick = "";
         cmbavGridsettingsrowsperpagevariable.Enabled = 1;
         chkavAtt_usuariosistemadepartamento_visible.Enabled = 1;
         chkavAtt_usuariosistemagerencia_visible.Enabled = 1;
         chkavAtt_usuariosistemanombre_visible.Enabled = 1;
         chkavAtt_usuariosistemaidentidad_visible.Enabled = 1;
         chkavAtt_usuariosistemaid_visible.Enabled = 1;
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
         edtUsuarioSistemaIdentidad_Link = "";
         subGrid_Sortable = 0;
         subGrid_Header = "";
         edtavDelete_Visible = -1;
         edtavUpdate_Visible = -1;
         edtUsuarioSistemaDepartamento_Visible = -1;
         edtUsuarioSistemaGerencia_Visible = -1;
         edtUsuarioSistemaNombre_Visible = -1;
         edtUsuarioSistemaIdentidad_Visible = -1;
         edtUsuarioSistemaId_Visible = -1;
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavK2btoolsgenericsearchfield_Jsonclick = "";
         edtavK2btoolsgenericsearchfield_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Usuario sistemas";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E12502',iparms:[{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOREPORT'","{handler:'E25501',iparms:[{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOREPORT'",",oparms:[{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E21502',iparms:[{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'AV27UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E22502',iparms:[{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblNoresultsfoundtable_Visible',ctrl:'NORESULTSFOUNDTABLE',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Link',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Link'},{av:'edtavUpdate_Enabled',ctrl:'vUPDATE',prop:'Enabled'},{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'edtavDelete_Enabled',ctrl:'vDELETE',prop:'Enabled'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED","{handler:'E11502',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV27UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("K2BORDERBYUSERCONTROL.ORDERBYCHANGED",",oparms:[{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'","{handler:'E23501',iparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGSTABLE'",",oparms:[{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS'","{handler:'E13502',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV17RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'cmbavGridsettingsrowsperpagevariable'},{av:'AV16GridSettingsRowsPerPageVariable',fld:'vGRIDSETTINGSROWSPERPAGEVARIABLE',pic:'ZZZ9'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS'",",oparms:[{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV27UC_OrderedBy',fld:'vUC_ORDEREDBY',pic:'ZZZ9'},{av:'AV17RowsPerPageVariable',fld:'vROWSPERPAGEVARIABLE',pic:'ZZZ9'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'divK2bgridsettingscontentoutertable_Visible',ctrl:'K2BGRIDSETTINGSCONTENTOUTERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOFIRST'","{handler:'E14502',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOFIRST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOPREVIOUS'","{handler:'E15502',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOPREVIOUS'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DONEXT'","{handler:'E16502',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DONEXT'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOLAST'","{handler:'E17502',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'AV46Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOLAST'",",oparms:[{av:'AV8CurrentPage',fld:'vCURRENTPAGE',pic:'ZZZZ9'},{av:'lblFirstpagetextblock_Caption',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagetextblock_Caption',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Caption'},{av:'lblCurrentpagetextblock_Caption',ctrl:'CURRENTPAGETEXTBLOCK',prop:'Caption'},{av:'lblNextpagetextblock_Caption',ctrl:'NEXTPAGETEXTBLOCK',prop:'Caption'},{av:'lblLastpagetextblock_Caption',ctrl:'LASTPAGETEXTBLOCK',prop:'Caption'},{av:'lblPreviouspagebuttontextblock_Class',ctrl:'PREVIOUSPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblNextpagebuttontextblock_Class',ctrl:'NEXTPAGEBUTTONTEXTBLOCK',prop:'Class'},{av:'lblFirstpagetextblock_Visible',ctrl:'FIRSTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacinglefttextblock_Visible',ctrl:'SPACINGLEFTTEXTBLOCK',prop:'Visible'},{av:'lblPreviouspagetextblock_Visible',ctrl:'PREVIOUSPAGETEXTBLOCK',prop:'Visible'},{av:'lblLastpagetextblock_Visible',ctrl:'LASTPAGETEXTBLOCK',prop:'Visible'},{av:'lblSpacingrighttextblock_Visible',ctrl:'SPACINGRIGHTTEXTBLOCK',prop:'Visible'},{av:'lblNextpagetextblock_Visible',ctrl:'NEXTPAGETEXTBLOCK',prop:'Visible'},{av:'divK2btoolspagingcontainertable_Visible',ctrl:'K2BTOOLSPAGINGCONTAINERTABLE',prop:'Visible'},{ctrl:'REPORT',prop:'Tooltiptext'},{ctrl:'EXPORT',prop:'Tooltiptext'},{ctrl:'INSERT',prop:'Tooltiptext'},{av:'AV31Update',fld:'vUPDATE',pic:''},{av:'edtavUpdate_Tooltiptext',ctrl:'vUPDATE',prop:'Tooltiptext'},{av:'AV32Delete',fld:'vDELETE',pic:''},{av:'edtavDelete_Tooltiptext',ctrl:'vDELETE',prop:'Tooltiptext'},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'divDownloadsactionssectioncontainer_Visible',ctrl:'DOWNLOADSACTIONSSECTIONCONTAINER',prop:'Visible'},{av:'AV10GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{ctrl:'REPORT',prop:'Visible'},{ctrl:'EXPORT',prop:'Visible'},{ctrl:'INSERT',prop:'Visible'},{av:'AV38UsuarioSistemaIdentidad_IsAuthorized',fld:'vUSUARIOSISTEMAIDENTIDAD_ISAUTHORIZED',pic:''},{av:'edtavUpdate_Visible',ctrl:'vUPDATE',prop:'Visible'},{av:'edtavDelete_Visible',ctrl:'vDELETE',prop:'Visible'},{av:'AV22ClassCollection',fld:'vCLASSCOLLECTION',pic:''},{av:'edtUsuarioSistemaId_Visible',ctrl:'USUARIOSISTEMAID',prop:'Visible'},{av:'edtUsuarioSistemaIdentidad_Visible',ctrl:'USUARIOSISTEMAIDENTIDAD',prop:'Visible'},{av:'edtUsuarioSistemaNombre_Visible',ctrl:'USUARIOSISTEMANOMBRE',prop:'Visible'},{av:'edtUsuarioSistemaGerencia_Visible',ctrl:'USUARIOSISTEMAGERENCIA',prop:'Visible'},{av:'edtUsuarioSistemaDepartamento_Visible',ctrl:'USUARIOSISTEMADEPARTAMENTO',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'DOEXPORT'","{handler:'E18502',iparms:[{av:'AV23K2BToolsGenericSearchField',fld:'vK2BTOOLSGENERICSEARCHFIELD',pic:''},{av:'AV24OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV43Uri',fld:'vURI',pic:'',hsh:true},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'DOEXPORT'",",oparms:[{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'","{handler:'E24501',iparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("'TOGGLEDOWNLOADACTIONS'",",oparms:[{av:'divDownloadactionstable_Visible',ctrl:'DOWNLOADACTIONSTABLE',prop:'Visible'},{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14Att_UsuarioSistemaId_Visible',fld:'vATT_USUARIOSISTEMAID_VISIBLE',pic:''},{av:'AV37Att_UsuarioSistemaIdentidad_Visible',fld:'vATT_USUARIOSISTEMAIDENTIDAD_VISIBLE',pic:''},{av:'AV15Att_UsuarioSistemaNombre_Visible',fld:'vATT_USUARIOSISTEMANOMBRE_VISIBLE',pic:''},{av:'AV39Att_UsuarioSistemaGerencia_Visible',fld:'vATT_USUARIOSISTEMAGERENCIA_VISIBLE',pic:''},{av:'AV40Att_UsuarioSistemaDepartamento_Visible',fld:'vATT_USUARIOSISTEMADEPARTAMENTO_VISIBLE',pic:''},{av:'AV11FreezeColumnTitles',fld:'vFREEZECOLUMNTITLES',pic:''}]}");
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
         AV23K2BToolsGenericSearchField = "";
         AV22ClassCollection = new GxSimpleCollection<string>();
         AV46Pgmname = "";
         AV10GridConfiguration = new SdtK2BGridConfiguration(context);
         AV43Uri = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV25GridOrders = new GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem>( context, "K2BGridOrdersItem", "kb_ticket");
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
         A99UsuarioSistemaId = "";
         A101UsuarioSistemaIdentidad = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         AV31Update = "";
         AV32Delete = "";
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
         AV48Update_GXI = "";
         AV49Delete_GXI = "";
         scmdbuf = "";
         lV23K2BToolsGenericSearchField = "";
         H00502_A257UsuarioSistemaDepartamento = new string[] {""} ;
         H00502_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         H00502_A263UsuarioSistemaGerencia = new string[] {""} ;
         H00502_n263UsuarioSistemaGerencia = new bool[] {false} ;
         H00502_A100UsuarioSistemaNombre = new string[] {""} ;
         H00502_A101UsuarioSistemaIdentidad = new string[] {""} ;
         H00502_A99UsuarioSistemaId = new string[] {""} ;
         H00503_AGRID_nRecordCount = new long[1] ;
         AV5Context = new SdtK2BContext(context);
         AV26GridOrder = new SdtK2BGridOrders_K2BGridOrdersItem(context);
         AV28Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV29Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV35ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV36ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV19GridStateKey = "";
         AV20GridState = new SdtK2BGridState(context);
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV33TrnContext = new SdtK2BTrnContext(context);
         AV13GridColumn = new SdtK2BGridColumns_K2BGridColumnsItem(context);
         AV12GridColumns = new GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem>( context, "K2BGridColumnsItem", "kb_ticket");
         GXt_char2 = "";
         GridRow = new GXWebRow();
         AV41OutFile = "";
         AV42Guid = (Guid)(Guid.Empty);
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwusuariosistema__default(),
            new Object[][] {
                new Object[] {
               H00502_A257UsuarioSistemaDepartamento, H00502_n257UsuarioSistemaDepartamento, H00502_A263UsuarioSistemaGerencia, H00502_n263UsuarioSistemaGerencia, H00502_A100UsuarioSistemaNombre, H00502_A101UsuarioSistemaIdentidad, H00502_A99UsuarioSistemaId
               }
               , new Object[] {
               H00503_AGRID_nRecordCount
               }
            }
         );
         AV46Pgmname = "WWUsuarioSistema";
         /* GeneXus formulas. */
         AV46Pgmname = "WWUsuarioSistema";
         context.Gx_err = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV24OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV27UC_OrderedBy ;
      private short AV17RowsPerPageVariable ;
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
      private short AV16GridSettingsRowsPerPageVariable ;
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
      private int edtUsuarioSistemaId_Visible ;
      private int edtUsuarioSistemaIdentidad_Visible ;
      private int edtUsuarioSistemaNombre_Visible ;
      private int edtUsuarioSistemaGerencia_Visible ;
      private int edtUsuarioSistemaDepartamento_Visible ;
      private int edtavUpdate_Visible ;
      private int edtavDelete_Visible ;
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
      private int AV47GXV1 ;
      private int AV50GXV2 ;
      private int AV9K2BMaxPages ;
      private int AV51GXV3 ;
      private int bttInsert_Visible ;
      private int divDownloadsactionssectioncontainer_Visible ;
      private int tblNoresultsfoundtable_Visible ;
      private int AV52GXV4 ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_122_idx="0001" ;
      private string AV23K2BToolsGenericSearchField ;
      private string AV46Pgmname ;
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
      private string edtUsuarioSistemaIdentidad_Link ;
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
      private string edtUsuarioSistemaId_Internalname ;
      private string edtUsuarioSistemaIdentidad_Internalname ;
      private string edtUsuarioSistemaNombre_Internalname ;
      private string edtUsuarioSistemaGerencia_Internalname ;
      private string edtUsuarioSistemaDepartamento_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string cmbavGridsettingsrowsperpagevariable_Internalname ;
      private string scmdbuf ;
      private string lV23K2BToolsGenericSearchField ;
      private string chkavAtt_usuariosistemaid_visible_Internalname ;
      private string chkavAtt_usuariosistemaidentidad_visible_Internalname ;
      private string chkavAtt_usuariosistemanombre_visible_Internalname ;
      private string chkavAtt_usuariosistemagerencia_visible_Internalname ;
      private string chkavAtt_usuariosistemadepartamento_visible_Internalname ;
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
      private string divUsuariosistemaid_gridsettingscontainer_Internalname ;
      private string divUsuariosistemaidentidad_gridsettingscontainer_Internalname ;
      private string divUsuariosistemanombre_gridsettingscontainer_Internalname ;
      private string divUsuariosistemagerencia_gridsettingscontainer_Internalname ;
      private string divUsuariosistemadepartamento_gridsettingscontainer_Internalname ;
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
      private string edtUsuarioSistemaId_Jsonclick ;
      private string edtUsuarioSistemaIdentidad_Jsonclick ;
      private string edtUsuarioSistemaNombre_Jsonclick ;
      private string edtUsuarioSistemaGerencia_Jsonclick ;
      private string edtUsuarioSistemaDepartamento_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV38UsuarioSistemaIdentidad_IsAuthorized ;
      private bool AV14Att_UsuarioSistemaId_Visible ;
      private bool AV37Att_UsuarioSistemaIdentidad_Visible ;
      private bool AV15Att_UsuarioSistemaNombre_Visible ;
      private bool AV39Att_UsuarioSistemaGerencia_Visible ;
      private bool AV40Att_UsuarioSistemaDepartamento_Visible ;
      private bool AV11FreezeColumnTitles ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n263UsuarioSistemaGerencia ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool bGXsfl_122_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV18RowsPerPageLoaded ;
      private bool gx_refresh_fired ;
      private bool AV31Update_IsBlob ;
      private bool AV32Delete_IsBlob ;
      private string AV43Uri ;
      private string A99UsuarioSistemaId ;
      private string A101UsuarioSistemaIdentidad ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string AV48Update_GXI ;
      private string AV49Delete_GXI ;
      private string AV19GridStateKey ;
      private string AV41OutFile ;
      private string AV31Update ;
      private string AV32Delete ;
      private Guid AV42Guid ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucK2borderbyusercontrol ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavAtt_usuariosistemaid_visible ;
      private GXCheckbox chkavAtt_usuariosistemaidentidad_visible ;
      private GXCheckbox chkavAtt_usuariosistemanombre_visible ;
      private GXCheckbox chkavAtt_usuariosistemagerencia_visible ;
      private GXCheckbox chkavAtt_usuariosistemadepartamento_visible ;
      private GXCombobox cmbavGridsettingsrowsperpagevariable ;
      private GXCheckbox chkavFreezecolumntitles ;
      private IDataStoreProvider pr_default ;
      private string[] H00502_A257UsuarioSistemaDepartamento ;
      private bool[] H00502_n257UsuarioSistemaDepartamento ;
      private string[] H00502_A263UsuarioSistemaGerencia ;
      private bool[] H00502_n263UsuarioSistemaGerencia ;
      private string[] H00502_A100UsuarioSistemaNombre ;
      private string[] H00502_A101UsuarioSistemaIdentidad ;
      private string[] H00502_A99UsuarioSistemaId ;
      private long[] H00503_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private GxSimpleCollection<string> AV22ClassCollection ;
      private GXBaseCollection<SdtK2BGridColumns_K2BGridColumnsItem> AV12GridColumns ;
      private GXBaseCollection<SdtK2BGridOrders_K2BGridOrdersItem> AV25GridOrders ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV28Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV35ActivityList ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BGridConfiguration AV10GridConfiguration ;
      private SdtK2BGridColumns_K2BGridColumnsItem AV13GridColumn ;
      private SdtK2BGridState AV20GridState ;
      private SdtK2BGridState_FilterValue AV21GridStateFilterValue ;
      private SdtK2BGridOrders_K2BGridOrdersItem AV26GridOrder ;
      private GeneXus.Utils.SdtMessages_Message AV29Message ;
      private SdtK2BTrnContext AV33TrnContext ;
      private SdtK2BActivityList_K2BActivityListItem AV36ActivityListItem ;
   }

   public class wwusuariosistema__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00502( IGxContext context ,
                                             string AV23K2BToolsGenericSearchField ,
                                             string A99UsuarioSistemaId ,
                                             string A101UsuarioSistemaIdentidad ,
                                             string A100UsuarioSistemaNombre ,
                                             string A263UsuarioSistemaGerencia ,
                                             string A257UsuarioSistemaDepartamento ,
                                             short AV24OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[8];
         Object[] GXv_Object4 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [UsuarioSistemaDepartamento], [UsuarioSistemaGerencia], [UsuarioSistemaNombre], [UsuarioSistemaIdentidad], [UsuarioSistemaId]";
         sFromString = " FROM [UsuarioSistema]";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaId] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaIdentidad] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaNombre] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaGerencia] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaDepartamento] like '%' + @lV23K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
            GXv_int3[3] = 1;
            GXv_int3[4] = 1;
         }
         if ( AV24OrderedBy == 0 )
         {
            sOrderString += " ORDER BY [UsuarioSistemaId]";
         }
         else if ( AV24OrderedBy == 1 )
         {
            sOrderString += " ORDER BY [UsuarioSistemaId] DESC";
         }
         else if ( AV24OrderedBy == 2 )
         {
            sOrderString += " ORDER BY [UsuarioSistemaNombre]";
         }
         else if ( AV24OrderedBy == 3 )
         {
            sOrderString += " ORDER BY [UsuarioSistemaNombre] DESC";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY [UsuarioSistemaId]";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_H00503( IGxContext context ,
                                             string AV23K2BToolsGenericSearchField ,
                                             string A99UsuarioSistemaId ,
                                             string A101UsuarioSistemaIdentidad ,
                                             string A100UsuarioSistemaNombre ,
                                             string A263UsuarioSistemaGerencia ,
                                             string A257UsuarioSistemaDepartamento ,
                                             short AV24OrderedBy )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[5];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [UsuarioSistema]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV23K2BToolsGenericSearchField)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaId] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaIdentidad] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaNombre] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaGerencia] like '%' + @lV23K2BToolsGenericSearchField + '%' or [UsuarioSistemaDepartamento] like '%' + @lV23K2BToolsGenericSearchField + '%')");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
            GXv_int5[3] = 1;
            GXv_int5[4] = 1;
         }
         scmdbuf += sWhereString;
         if ( AV24OrderedBy == 0 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 1 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 2 )
         {
            scmdbuf += "";
         }
         else if ( AV24OrderedBy == 3 )
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
                     return conditional_H00502(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] );
               case 1 :
                     return conditional_H00503(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] );
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
          Object[] prmH00502;
          prmH00502 = new Object[] {
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00503;
          prmH00503 = new Object[] {
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0) ,
          new ParDef("@lV23K2BToolsGenericSearchField",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00502", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00502,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00503", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00503,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
