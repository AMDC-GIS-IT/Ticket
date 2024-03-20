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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class gx00g0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00g0( )
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

      public gx00g0( IGxContext context )
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

      public void execute( out long aP0_pSoporteTecnicoId )
      {
         this.AV13pSoporteTecnicoId = 0 ;
         executePrivate();
         aP0_pSoporteTecnicoId=this.AV13pSoporteTecnicoId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCsoportetecnicoinstalacion = new GXCheckbox();
         chkavCsoportetecnicoconfiguracion = new GXCheckbox();
         chkavCsoportetecnicointernetrouter = new GXCheckbox();
         chkSoporteTecnicoInstalacion = new GXCheckbox();
         chkSoporteTecnicoConfiguracion = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pSoporteTecnicoId");
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
               gxfirstwebparm = GetFirstPar( "pSoporteTecnicoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pSoporteTecnicoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
               nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
               sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
               AV6cSoporteTecnicoId = (long)(NumberUtil.Val( GetPar( "cSoporteTecnicoId"), "."));
               AV7cSoporteTecnicoFecha = context.localUtil.ParseDateParm( GetPar( "cSoporteTecnicoFecha"));
               AV8cSoporteTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "cSoporteTecnicoHora")));
               AV9cTicketId = (long)(NumberUtil.Val( GetPar( "cTicketId"), "."));
               AV10cSoporteTecnicoInstalacion = StringUtil.StrToBool( GetPar( "cSoporteTecnicoInstalacion"));
               AV11cSoporteTecnicoConfiguracion = StringUtil.StrToBool( GetPar( "cSoporteTecnicoConfiguracion"));
               AV12cSoporteTecnicoInternetRouter = StringUtil.StrToBool( GetPar( "cSoporteTecnicoInternetRouter"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "SOPORTETECNICOIDFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicoidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "SOPORTETECNICOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicofechafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "SOPORTETECNICOHORAFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicohorafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "SOPORTETECNICOINSTALACIONFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicoinstalacionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "SOPORTETECNICOCONFIGURACIONFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicoconfiguracionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "SOPORTETECNICOINTERNETROUTERFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicointernetrouterfiltercontainer_Class));
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
               AV13pSoporteTecnicoId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pSoporteTecnicoId", StringUtil.LTrimStr( (decimal)(AV13pSoporteTecnicoId), 10, 0));
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
            return "gx00g0_Execute" ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdpromptmasterpage", "GeneXus.Programs.rwdpromptmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA5Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5Y2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249572541", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00g0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSoporteTecnicoId,10,0))}, new string[] {"pSoporteTecnicoId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCSOPORTETECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSoporteTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOPORTETECNICOFECHA", context.localUtil.Format(AV7cSoporteTecnicoFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOPORTETECNICOHORA", context.localUtil.TToC( AV8cSoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cTicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOPORTETECNICOINSTALACION", StringUtil.BoolToStr( AV10cSoporteTecnicoInstalacion));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOPORTETECNICOCONFIGURACION", StringUtil.BoolToStr( AV11cSoporteTecnicoConfiguracion));
         GxWebStd.gx_hidden_field( context, "GXH_vCSOPORTETECNICOINTERNETROUTER", StringUtil.BoolToStr( AV12cSoporteTecnicoInternetRouter));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPSOPORTETECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pSoporteTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOIDFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicofechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOHORAFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicohorafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOINSTALACIONFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicoinstalacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOCONFIGURACIONFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicoconfiguracionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOINTERNETROUTERFILTERCONTAINER_Class", StringUtil.RTrim( divSoportetecnicointernetrouterfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE5Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5Y2( ) ;
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
         return formatLink("gx00g0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pSoporteTecnicoId,10,0))}, new string[] {"pSoporteTecnicoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00G0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Soporte Tecnico" ;
      }

      protected void WB5Y0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divSoportetecnicoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSoportetecnicoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsoportetecnicoidfilter_Internalname, "Soporte Tecnico Id", "", "", lblLblsoportetecnicoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsoportetecnicoid_Internalname, "Soporte Tecnico Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCsoportetecnicoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cSoporteTecnicoId), 10, 0, ",", "")), ((edtavCsoportetecnicoid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cSoporteTecnicoId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cSoporteTecnicoId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsoportetecnicoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCsoportetecnicoid_Visible, edtavCsoportetecnicoid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divSoportetecnicofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divSoportetecnicofechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsoportetecnicofechafilter_Internalname, "Soporte Tecnico Fecha", "", "", lblLblsoportetecnicofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125y1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsoportetecnicofecha_Internalname, "Soporte Tecnico Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCsoportetecnicofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCsoportetecnicofecha_Internalname, context.localUtil.Format(AV7cSoporteTecnicoFecha, "99/99/9999"), context.localUtil.Format( AV7cSoporteTecnicoFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsoportetecnicofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCsoportetecnicofecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divSoportetecnicohorafiltercontainer_Internalname, 1, 0, "px", 0, "px", divSoportetecnicohorafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsoportetecnicohorafilter_Internalname, "Soporte Tecnico Hora", "", "", lblLblsoportetecnicohorafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135y1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCsoportetecnicohora_Internalname, "Soporte Tecnico Hora", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCsoportetecnicohora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCsoportetecnicohora_Internalname, context.localUtil.TToC( AV8cSoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV8cSoporteTecnicoHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCsoportetecnicohora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCsoportetecnicohora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTicketidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketidfilter_Internalname, "Id Ticket", "", "", lblLblticketidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCticketid_Internalname, "Id Ticket", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCticketid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cTicketId), 10, 0, ",", "")), ((edtavCticketid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9cTicketId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV9cTicketId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCticketid_Visible, edtavCticketid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00G0.htm");
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
            GxWebStd.gx_div_start( context, divSoportetecnicoinstalacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSoportetecnicoinstalacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsoportetecnicoinstalacionfilter_Internalname, "Soporte Tecnico Instalacion", "", "", lblLblsoportetecnicoinstalacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCsoportetecnicoinstalacion_Internalname, "Soporte Tecnico Instalacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCsoportetecnicoinstalacion_Internalname, StringUtil.BoolToStr( AV10cSoporteTecnicoInstalacion), "", "Soporte Tecnico Instalacion", chkavCsoportetecnicoinstalacion.Visible, chkavCsoportetecnicoinstalacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_div_start( context, divSoportetecnicoconfiguracionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSoportetecnicoconfiguracionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsoportetecnicoconfiguracionfilter_Internalname, "Soporte Tecnico Configuracion", "", "", lblLblsoportetecnicoconfiguracionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCsoportetecnicoconfiguracion_Internalname, "Soporte Tecnico Configuracion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCsoportetecnicoconfiguracion_Internalname, StringUtil.BoolToStr( AV11cSoporteTecnicoConfiguracion), "", "Soporte Tecnico Configuracion", chkavCsoportetecnicoconfiguracion.Visible, chkavCsoportetecnicoconfiguracion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_div_start( context, divSoportetecnicointernetrouterfiltercontainer_Internalname, 1, 0, "px", 0, "px", divSoportetecnicointernetrouterfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblsoportetecnicointernetrouterfilter_Internalname, "Soporte Tecnico Internet Router", "", "", lblLblsoportetecnicointernetrouterfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e175y1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCsoportetecnicointernetrouter_Internalname, "Soporte Tecnico Internet Router", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCsoportetecnicointernetrouter_Internalname, StringUtil.BoolToStr( AV12cSoporteTecnicoInternetRouter), "", "Soporte Tecnico Internet Router", chkavCsoportetecnicointernetrouter.Visible, chkavCsoportetecnicointernetrouter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e185y1_client"+"'", TempTags, "", 2, "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tecnico Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tecnico Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tecnico Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tecnico Instalacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tecnico Configuracion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "PromptGrid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202SoporteTecnicoId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtSoporteTecnicoFecha_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A204SoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A206SoporteTecnicoInstalacion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00G0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START5Y2( )
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
            Form.Meta.addItem("description", "Selection List Soporte Tecnico", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5Y0( ) ;
      }

      protected void WS5Y2( )
      {
         START5Y2( ) ;
         EVT5Y2( ) ;
      }

      protected void EVT5Y2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A202SoporteTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtSoporteTecnicoId_Internalname), ",", "."));
                              A203SoporteTecnicoFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtSoporteTecnicoFecha_Internalname), 0));
                              A204SoporteTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtSoporteTecnicoHora_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
                              A206SoporteTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoInstalacion_Internalname));
                              n206SoporteTecnicoInstalacion = false;
                              A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoConfiguracion_Internalname));
                              n207SoporteTecnicoConfiguracion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E205Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Csoportetecnicoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOPORTETECNICOID"), ",", ".") != Convert.ToDecimal( AV6cSoporteTecnicoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csoportetecnicofecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCSOPORTETECNICOFECHA"), 0) != AV7cSoporteTecnicoFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csoportetecnicohora Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCSOPORTETECNICOHORA"), 0) != AV8cSoporteTecnicoHora )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETID"), ",", ".") != Convert.ToDecimal( AV9cTicketId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csoportetecnicoinstalacion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCSOPORTETECNICOINSTALACION")) != AV10cSoporteTecnicoInstalacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csoportetecnicoconfiguracion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCSOPORTETECNICOCONFIGURACION")) != AV11cSoporteTecnicoConfiguracion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Csoportetecnicointernetrouter Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCSOPORTETECNICOINTERNETROUTER")) != AV12cSoporteTecnicoInternetRouter )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E215Y2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE5Y2( )
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

      protected void PA5Y2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cSoporteTecnicoId ,
                                        DateTime AV7cSoporteTecnicoFecha ,
                                        DateTime AV8cSoporteTecnicoHora ,
                                        long AV9cTicketId ,
                                        bool AV10cSoporteTecnicoInstalacion ,
                                        bool AV11cSoporteTecnicoConfiguracion ,
                                        bool AV12cSoporteTecnicoInternetRouter )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOPORTETECNICOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A202SoporteTecnicoId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "SOPORTETECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A202SoporteTecnicoId), 10, 0, ".", "")));
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
         AV10cSoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cSoporteTecnicoInstalacion));
         AssignAttri("", false, "AV10cSoporteTecnicoInstalacion", AV10cSoporteTecnicoInstalacion);
         AV11cSoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cSoporteTecnicoConfiguracion));
         AssignAttri("", false, "AV11cSoporteTecnicoConfiguracion", AV11cSoporteTecnicoConfiguracion);
         AV12cSoporteTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cSoporteTecnicoInternetRouter));
         AssignAttri("", false, "AV12cSoporteTecnicoInternetRouter", AV12cSoporteTecnicoInternetRouter);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5Y2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF5Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cSoporteTecnicoFecha ,
                                                 AV8cSoporteTecnicoHora ,
                                                 AV9cTicketId ,
                                                 AV10cSoporteTecnicoInstalacion ,
                                                 AV11cSoporteTecnicoConfiguracion ,
                                                 AV12cSoporteTecnicoInternetRouter ,
                                                 A203SoporteTecnicoFecha ,
                                                 A204SoporteTecnicoHora ,
                                                 A14TicketId ,
                                                 A206SoporteTecnicoInstalacion ,
                                                 A207SoporteTecnicoConfiguracion ,
                                                 A208SoporteTecnicoInternetRouter ,
                                                 AV6cSoporteTecnicoId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H005Y2 */
            pr_default.execute(0, new Object[] {AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A208SoporteTecnicoInternetRouter = H005Y2_A208SoporteTecnicoInternetRouter[0];
               n208SoporteTecnicoInternetRouter = H005Y2_n208SoporteTecnicoInternetRouter[0];
               A207SoporteTecnicoConfiguracion = H005Y2_A207SoporteTecnicoConfiguracion[0];
               n207SoporteTecnicoConfiguracion = H005Y2_n207SoporteTecnicoConfiguracion[0];
               A206SoporteTecnicoInstalacion = H005Y2_A206SoporteTecnicoInstalacion[0];
               n206SoporteTecnicoInstalacion = H005Y2_n206SoporteTecnicoInstalacion[0];
               A14TicketId = H005Y2_A14TicketId[0];
               A204SoporteTecnicoHora = H005Y2_A204SoporteTecnicoHora[0];
               A203SoporteTecnicoFecha = H005Y2_A203SoporteTecnicoFecha[0];
               A202SoporteTecnicoId = H005Y2_A202SoporteTecnicoId[0];
               /* Execute user event: Load */
               E205Y2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB5Y0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5Y2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_SOPORTETECNICOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A202SoporteTecnicoId), "ZZZZZZZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cSoporteTecnicoFecha ,
                                              AV8cSoporteTecnicoHora ,
                                              AV9cTicketId ,
                                              AV10cSoporteTecnicoInstalacion ,
                                              AV11cSoporteTecnicoConfiguracion ,
                                              AV12cSoporteTecnicoInternetRouter ,
                                              A203SoporteTecnicoFecha ,
                                              A204SoporteTecnicoHora ,
                                              A14TicketId ,
                                              A206SoporteTecnicoInstalacion ,
                                              A207SoporteTecnicoConfiguracion ,
                                              A208SoporteTecnicoInternetRouter ,
                                              AV6cSoporteTecnicoId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         /* Using cursor H005Y3 */
         pr_default.execute(1, new Object[] {AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter});
         GRID1_nRecordCount = H005Y3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cSoporteTecnicoId, AV7cSoporteTecnicoFecha, AV8cSoporteTecnicoHora, AV9cTicketId, AV10cSoporteTecnicoInstalacion, AV11cSoporteTecnicoConfiguracion, AV12cSoporteTecnicoInternetRouter) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195Y2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCsoportetecnicoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCsoportetecnicoid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCSOPORTETECNICOID");
               GX_FocusControl = edtavCsoportetecnicoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cSoporteTecnicoId = 0;
               AssignAttri("", false, "AV6cSoporteTecnicoId", StringUtil.LTrimStr( (decimal)(AV6cSoporteTecnicoId), 10, 0));
            }
            else
            {
               AV6cSoporteTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtavCsoportetecnicoid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cSoporteTecnicoId", StringUtil.LTrimStr( (decimal)(AV6cSoporteTecnicoId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCsoportetecnicofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Soporte Tecnico Fecha"}), 1, "vCSOPORTETECNICOFECHA");
               GX_FocusControl = edtavCsoportetecnicofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cSoporteTecnicoFecha = DateTime.MinValue;
               AssignAttri("", false, "AV7cSoporteTecnicoFecha", context.localUtil.Format(AV7cSoporteTecnicoFecha, "99/99/9999"));
            }
            else
            {
               AV7cSoporteTecnicoFecha = context.localUtil.CToD( cgiGet( edtavCsoportetecnicofecha_Internalname), 2);
               AssignAttri("", false, "AV7cSoporteTecnicoFecha", context.localUtil.Format(AV7cSoporteTecnicoFecha, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCsoportetecnicohora_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Soporte Tecnico Hora"}), 1, "vCSOPORTETECNICOHORA");
               GX_FocusControl = edtavCsoportetecnicohora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cSoporteTecnicoHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8cSoporteTecnicoHora", context.localUtil.TToC( AV8cSoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV8cSoporteTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavCsoportetecnicohora_Internalname)));
               AssignAttri("", false, "AV8cSoporteTecnicoHora", context.localUtil.TToC( AV8cSoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCticketid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCticketid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTICKETID");
               GX_FocusControl = edtavCticketid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTicketId = 0;
               AssignAttri("", false, "AV9cTicketId", StringUtil.LTrimStr( (decimal)(AV9cTicketId), 10, 0));
            }
            else
            {
               AV9cTicketId = (long)(context.localUtil.CToN( cgiGet( edtavCticketid_Internalname), ",", "."));
               AssignAttri("", false, "AV9cTicketId", StringUtil.LTrimStr( (decimal)(AV9cTicketId), 10, 0));
            }
            AV10cSoporteTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkavCsoportetecnicoinstalacion_Internalname));
            AssignAttri("", false, "AV10cSoporteTecnicoInstalacion", AV10cSoporteTecnicoInstalacion);
            AV11cSoporteTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkavCsoportetecnicoconfiguracion_Internalname));
            AssignAttri("", false, "AV11cSoporteTecnicoConfiguracion", AV11cSoporteTecnicoConfiguracion);
            AV12cSoporteTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( chkavCsoportetecnicointernetrouter_Internalname));
            AssignAttri("", false, "AV12cSoporteTecnicoInternetRouter", AV12cSoporteTecnicoInternetRouter);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCSOPORTETECNICOID"), ",", ".") != Convert.ToDecimal( AV6cSoporteTecnicoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCSOPORTETECNICOFECHA"), 2) != AV7cSoporteTecnicoFecha )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCSOPORTETECNICOHORA")) != AV8cSoporteTecnicoHora )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETID"), ",", ".") != Convert.ToDecimal( AV9cTicketId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCSOPORTETECNICOINSTALACION")) != AV10cSoporteTecnicoInstalacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCSOPORTETECNICOCONFIGURACION")) != AV11cSoporteTecnicoConfiguracion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCSOPORTETECNICOINTERNETROUTER")) != AV12cSoporteTecnicoInternetRouter )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E195Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195Y2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Soporte Tecnico", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E205Y2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            context.DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E215Y2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215Y2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pSoporteTecnicoId = A202SoporteTecnicoId;
         AssignAttri("", false, "AV13pSoporteTecnicoId", StringUtil.LTrimStr( (decimal)(AV13pSoporteTecnicoId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pSoporteTecnicoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pSoporteTecnicoId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV13pSoporteTecnicoId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pSoporteTecnicoId", StringUtil.LTrimStr( (decimal)(AV13pSoporteTecnicoId), 10, 0));
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
         PA5Y2( ) ;
         WS5Y2( ) ;
         WE5Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023124957260", true, true);
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
         context.AddJavascriptSource("gx00g0.js", "?2023124957261", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtSoporteTecnicoId_Internalname = "SOPORTETECNICOID_"+sGXsfl_84_idx;
         edtSoporteTecnicoFecha_Internalname = "SOPORTETECNICOFECHA_"+sGXsfl_84_idx;
         edtSoporteTecnicoHora_Internalname = "SOPORTETECNICOHORA_"+sGXsfl_84_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_idx;
         chkSoporteTecnicoInstalacion_Internalname = "SOPORTETECNICOINSTALACION_"+sGXsfl_84_idx;
         chkSoporteTecnicoConfiguracion_Internalname = "SOPORTETECNICOCONFIGURACION_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtSoporteTecnicoId_Internalname = "SOPORTETECNICOID_"+sGXsfl_84_fel_idx;
         edtSoporteTecnicoFecha_Internalname = "SOPORTETECNICOFECHA_"+sGXsfl_84_fel_idx;
         edtSoporteTecnicoHora_Internalname = "SOPORTETECNICOHORA_"+sGXsfl_84_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_fel_idx;
         chkSoporteTecnicoInstalacion_Internalname = "SOPORTETECNICOINSTALACION_"+sGXsfl_84_fel_idx;
         chkSoporteTecnicoConfiguracion_Internalname = "SOPORTETECNICOCONFIGURACION_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB5Y0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A202SoporteTecnicoId), 10, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSoporteTecnicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A202SoporteTecnicoId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A202SoporteTecnicoId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSoporteTecnicoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtSoporteTecnicoFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A202SoporteTecnicoId), 10, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtSoporteTecnicoFecha_Internalname, "Link", edtSoporteTecnicoFecha_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSoporteTecnicoFecha_Internalname,context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"),context.localUtil.Format( A203SoporteTecnicoFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtSoporteTecnicoFecha_Link,(string)"",(string)"",(string)"",(string)edtSoporteTecnicoFecha_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtSoporteTecnicoHora_Internalname,context.localUtil.TToC( A204SoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A204SoporteTecnicoHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtSoporteTecnicoHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SOPORTETECNICOINSTALACION_" + sGXsfl_84_idx;
            chkSoporteTecnicoInstalacion.Name = GXCCtl;
            chkSoporteTecnicoInstalacion.WebTags = "";
            chkSoporteTecnicoInstalacion.Caption = "";
            AssignProp("", false, chkSoporteTecnicoInstalacion_Internalname, "TitleCaption", chkSoporteTecnicoInstalacion.Caption, !bGXsfl_84_Refreshing);
            chkSoporteTecnicoInstalacion.CheckedValue = "false";
            A206SoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A206SoporteTecnicoInstalacion));
            n206SoporteTecnicoInstalacion = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSoporteTecnicoInstalacion_Internalname,StringUtil.BoolToStr( A206SoporteTecnicoInstalacion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "SOPORTETECNICOCONFIGURACION_" + sGXsfl_84_idx;
            chkSoporteTecnicoConfiguracion.Name = GXCCtl;
            chkSoporteTecnicoConfiguracion.WebTags = "";
            chkSoporteTecnicoConfiguracion.Caption = "";
            AssignProp("", false, chkSoporteTecnicoConfiguracion_Internalname, "TitleCaption", chkSoporteTecnicoConfiguracion.Caption, !bGXsfl_84_Refreshing);
            chkSoporteTecnicoConfiguracion.CheckedValue = "false";
            A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion));
            n207SoporteTecnicoConfiguracion = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkSoporteTecnicoConfiguracion_Internalname,StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            send_integrity_lvl_hashes5Y2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCsoportetecnicoinstalacion.Name = "vCSOPORTETECNICOINSTALACION";
         chkavCsoportetecnicoinstalacion.WebTags = "";
         chkavCsoportetecnicoinstalacion.Caption = "";
         AssignProp("", false, chkavCsoportetecnicoinstalacion_Internalname, "TitleCaption", chkavCsoportetecnicoinstalacion.Caption, true);
         chkavCsoportetecnicoinstalacion.CheckedValue = "false";
         AV10cSoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cSoporteTecnicoInstalacion));
         AssignAttri("", false, "AV10cSoporteTecnicoInstalacion", AV10cSoporteTecnicoInstalacion);
         chkavCsoportetecnicoconfiguracion.Name = "vCSOPORTETECNICOCONFIGURACION";
         chkavCsoportetecnicoconfiguracion.WebTags = "";
         chkavCsoportetecnicoconfiguracion.Caption = "";
         AssignProp("", false, chkavCsoportetecnicoconfiguracion_Internalname, "TitleCaption", chkavCsoportetecnicoconfiguracion.Caption, true);
         chkavCsoportetecnicoconfiguracion.CheckedValue = "false";
         AV11cSoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cSoporteTecnicoConfiguracion));
         AssignAttri("", false, "AV11cSoporteTecnicoConfiguracion", AV11cSoporteTecnicoConfiguracion);
         chkavCsoportetecnicointernetrouter.Name = "vCSOPORTETECNICOINTERNETROUTER";
         chkavCsoportetecnicointernetrouter.WebTags = "";
         chkavCsoportetecnicointernetrouter.Caption = "";
         AssignProp("", false, chkavCsoportetecnicointernetrouter_Internalname, "TitleCaption", chkavCsoportetecnicointernetrouter.Caption, true);
         chkavCsoportetecnicointernetrouter.CheckedValue = "false";
         AV12cSoporteTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cSoporteTecnicoInternetRouter));
         AssignAttri("", false, "AV12cSoporteTecnicoInternetRouter", AV12cSoporteTecnicoInternetRouter);
         GXCCtl = "SOPORTETECNICOINSTALACION_" + sGXsfl_84_idx;
         chkSoporteTecnicoInstalacion.Name = GXCCtl;
         chkSoporteTecnicoInstalacion.WebTags = "";
         chkSoporteTecnicoInstalacion.Caption = "";
         AssignProp("", false, chkSoporteTecnicoInstalacion_Internalname, "TitleCaption", chkSoporteTecnicoInstalacion.Caption, !bGXsfl_84_Refreshing);
         chkSoporteTecnicoInstalacion.CheckedValue = "false";
         A206SoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A206SoporteTecnicoInstalacion));
         n206SoporteTecnicoInstalacion = false;
         GXCCtl = "SOPORTETECNICOCONFIGURACION_" + sGXsfl_84_idx;
         chkSoporteTecnicoConfiguracion.Name = GXCCtl;
         chkSoporteTecnicoConfiguracion.WebTags = "";
         chkSoporteTecnicoConfiguracion.Caption = "";
         AssignProp("", false, chkSoporteTecnicoConfiguracion_Internalname, "TitleCaption", chkSoporteTecnicoConfiguracion.Caption, !bGXsfl_84_Refreshing);
         chkSoporteTecnicoConfiguracion.CheckedValue = "false";
         A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion));
         n207SoporteTecnicoConfiguracion = false;
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblsoportetecnicoidfilter_Internalname = "LBLSOPORTETECNICOIDFILTER";
         edtavCsoportetecnicoid_Internalname = "vCSOPORTETECNICOID";
         divSoportetecnicoidfiltercontainer_Internalname = "SOPORTETECNICOIDFILTERCONTAINER";
         lblLblsoportetecnicofechafilter_Internalname = "LBLSOPORTETECNICOFECHAFILTER";
         edtavCsoportetecnicofecha_Internalname = "vCSOPORTETECNICOFECHA";
         divSoportetecnicofechafiltercontainer_Internalname = "SOPORTETECNICOFECHAFILTERCONTAINER";
         lblLblsoportetecnicohorafilter_Internalname = "LBLSOPORTETECNICOHORAFILTER";
         edtavCsoportetecnicohora_Internalname = "vCSOPORTETECNICOHORA";
         divSoportetecnicohorafiltercontainer_Internalname = "SOPORTETECNICOHORAFILTERCONTAINER";
         lblLblticketidfilter_Internalname = "LBLTICKETIDFILTER";
         edtavCticketid_Internalname = "vCTICKETID";
         divTicketidfiltercontainer_Internalname = "TICKETIDFILTERCONTAINER";
         lblLblsoportetecnicoinstalacionfilter_Internalname = "LBLSOPORTETECNICOINSTALACIONFILTER";
         chkavCsoportetecnicoinstalacion_Internalname = "vCSOPORTETECNICOINSTALACION";
         divSoportetecnicoinstalacionfiltercontainer_Internalname = "SOPORTETECNICOINSTALACIONFILTERCONTAINER";
         lblLblsoportetecnicoconfiguracionfilter_Internalname = "LBLSOPORTETECNICOCONFIGURACIONFILTER";
         chkavCsoportetecnicoconfiguracion_Internalname = "vCSOPORTETECNICOCONFIGURACION";
         divSoportetecnicoconfiguracionfiltercontainer_Internalname = "SOPORTETECNICOCONFIGURACIONFILTERCONTAINER";
         lblLblsoportetecnicointernetrouterfilter_Internalname = "LBLSOPORTETECNICOINTERNETROUTERFILTER";
         chkavCsoportetecnicointernetrouter_Internalname = "vCSOPORTETECNICOINTERNETROUTER";
         divSoportetecnicointernetrouterfiltercontainer_Internalname = "SOPORTETECNICOINTERNETROUTERFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtSoporteTecnicoId_Internalname = "SOPORTETECNICOID";
         edtSoporteTecnicoFecha_Internalname = "SOPORTETECNICOFECHA";
         edtSoporteTecnicoHora_Internalname = "SOPORTETECNICOHORA";
         edtTicketId_Internalname = "TICKETID";
         chkSoporteTecnicoInstalacion_Internalname = "SOPORTETECNICOINSTALACION";
         chkSoporteTecnicoConfiguracion_Internalname = "SOPORTETECNICOCONFIGURACION";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavCsoportetecnicointernetrouter.Caption = "Soporte Tecnico Internet Router";
         chkavCsoportetecnicoconfiguracion.Caption = "Soporte Tecnico Configuracion";
         chkavCsoportetecnicoinstalacion.Caption = "Soporte Tecnico Instalacion";
         chkSoporteTecnicoConfiguracion.Caption = "";
         chkSoporteTecnicoInstalacion.Caption = "";
         edtTicketId_Jsonclick = "";
         edtSoporteTecnicoHora_Jsonclick = "";
         edtSoporteTecnicoFecha_Jsonclick = "";
         edtSoporteTecnicoId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtSoporteTecnicoFecha_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkavCsoportetecnicointernetrouter.Enabled = 1;
         chkavCsoportetecnicointernetrouter.Visible = 1;
         chkavCsoportetecnicoconfiguracion.Enabled = 1;
         chkavCsoportetecnicoconfiguracion.Visible = 1;
         chkavCsoportetecnicoinstalacion.Enabled = 1;
         chkavCsoportetecnicoinstalacion.Visible = 1;
         edtavCticketid_Jsonclick = "";
         edtavCticketid_Enabled = 1;
         edtavCticketid_Visible = 1;
         edtavCsoportetecnicohora_Jsonclick = "";
         edtavCsoportetecnicohora_Enabled = 1;
         edtavCsoportetecnicofecha_Jsonclick = "";
         edtavCsoportetecnicofecha_Enabled = 1;
         edtavCsoportetecnicoid_Jsonclick = "";
         edtavCsoportetecnicoid_Enabled = 1;
         edtavCsoportetecnicoid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Soporte Tecnico";
         divSoportetecnicointernetrouterfiltercontainer_Class = "AdvancedContainerItem";
         divSoportetecnicoconfiguracionfiltercontainer_Class = "AdvancedContainerItem";
         divSoportetecnicoinstalacionfiltercontainer_Class = "AdvancedContainerItem";
         divTicketidfiltercontainer_Class = "AdvancedContainerItem";
         divSoportetecnicohorafiltercontainer_Class = "AdvancedContainerItem";
         divSoportetecnicofechafiltercontainer_Class = "AdvancedContainerItem";
         divSoportetecnicoidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSoporteTecnicoId',fld:'vCSOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cSoporteTecnicoFecha',fld:'vCSOPORTETECNICOFECHA',pic:''},{av:'AV8cSoporteTecnicoHora',fld:'vCSOPORTETECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("'TOGGLE'","{handler:'E185Y1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLSOPORTETECNICOIDFILTER.CLICK","{handler:'E115Y1',iparms:[{av:'divSoportetecnicoidfiltercontainer_Class',ctrl:'SOPORTETECNICOIDFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLSOPORTETECNICOIDFILTER.CLICK",",oparms:[{av:'divSoportetecnicoidfiltercontainer_Class',ctrl:'SOPORTETECNICOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCsoportetecnicoid_Visible',ctrl:'vCSOPORTETECNICOID',prop:'Visible'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLSOPORTETECNICOFECHAFILTER.CLICK","{handler:'E125Y1',iparms:[{av:'divSoportetecnicofechafiltercontainer_Class',ctrl:'SOPORTETECNICOFECHAFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLSOPORTETECNICOFECHAFILTER.CLICK",",oparms:[{av:'divSoportetecnicofechafiltercontainer_Class',ctrl:'SOPORTETECNICOFECHAFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLSOPORTETECNICOHORAFILTER.CLICK","{handler:'E135Y1',iparms:[{av:'divSoportetecnicohorafiltercontainer_Class',ctrl:'SOPORTETECNICOHORAFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLSOPORTETECNICOHORAFILTER.CLICK",",oparms:[{av:'divSoportetecnicohorafiltercontainer_Class',ctrl:'SOPORTETECNICOHORAFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLTICKETIDFILTER.CLICK","{handler:'E145Y1',iparms:[{av:'divTicketidfiltercontainer_Class',ctrl:'TICKETIDFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLTICKETIDFILTER.CLICK",",oparms:[{av:'divTicketidfiltercontainer_Class',ctrl:'TICKETIDFILTERCONTAINER',prop:'Class'},{av:'edtavCticketid_Visible',ctrl:'vCTICKETID',prop:'Visible'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLSOPORTETECNICOINSTALACIONFILTER.CLICK","{handler:'E155Y1',iparms:[{av:'divSoportetecnicoinstalacionfiltercontainer_Class',ctrl:'SOPORTETECNICOINSTALACIONFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLSOPORTETECNICOINSTALACIONFILTER.CLICK",",oparms:[{av:'divSoportetecnicoinstalacionfiltercontainer_Class',ctrl:'SOPORTETECNICOINSTALACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCsoportetecnicoinstalacion.Visible',ctrl:'vCSOPORTETECNICOINSTALACION',prop:'Visible'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLSOPORTETECNICOCONFIGURACIONFILTER.CLICK","{handler:'E165Y1',iparms:[{av:'divSoportetecnicoconfiguracionfiltercontainer_Class',ctrl:'SOPORTETECNICOCONFIGURACIONFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLSOPORTETECNICOCONFIGURACIONFILTER.CLICK",",oparms:[{av:'divSoportetecnicoconfiguracionfiltercontainer_Class',ctrl:'SOPORTETECNICOCONFIGURACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCsoportetecnicoconfiguracion.Visible',ctrl:'vCSOPORTETECNICOCONFIGURACION',prop:'Visible'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("LBLSOPORTETECNICOINTERNETROUTERFILTER.CLICK","{handler:'E175Y1',iparms:[{av:'divSoportetecnicointernetrouterfiltercontainer_Class',ctrl:'SOPORTETECNICOINTERNETROUTERFILTERCONTAINER',prop:'Class'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("LBLSOPORTETECNICOINTERNETROUTERFILTER.CLICK",",oparms:[{av:'divSoportetecnicointernetrouterfiltercontainer_Class',ctrl:'SOPORTETECNICOINTERNETROUTERFILTERCONTAINER',prop:'Class'},{av:'chkavCsoportetecnicointernetrouter.Visible',ctrl:'vCSOPORTETECNICOINTERNETROUTER',prop:'Visible'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E215Y2',iparms:[{av:'A202SoporteTecnicoId',fld:'SOPORTETECNICOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pSoporteTecnicoId',fld:'vPSOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSoporteTecnicoId',fld:'vCSOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cSoporteTecnicoFecha',fld:'vCSOPORTETECNICOFECHA',pic:''},{av:'AV8cSoporteTecnicoHora',fld:'vCSOPORTETECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSoporteTecnicoId',fld:'vCSOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cSoporteTecnicoFecha',fld:'vCSOPORTETECNICOFECHA',pic:''},{av:'AV8cSoporteTecnicoHora',fld:'vCSOPORTETECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSoporteTecnicoId',fld:'vCSOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cSoporteTecnicoFecha',fld:'vCSOPORTETECNICOFECHA',pic:''},{av:'AV8cSoporteTecnicoHora',fld:'vCSOPORTETECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cSoporteTecnicoId',fld:'vCSOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cSoporteTecnicoFecha',fld:'vCSOPORTETECNICOFECHA',pic:''},{av:'AV8cSoporteTecnicoHora',fld:'vCSOPORTETECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("VALIDV_CSOPORTETECNICOFECHA","{handler:'Validv_Csoportetecnicofecha',iparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("VALIDV_CSOPORTETECNICOFECHA",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Soportetecnicoconfiguracion',iparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV10cSoporteTecnicoInstalacion',fld:'vCSOPORTETECNICOINSTALACION',pic:''},{av:'AV11cSoporteTecnicoConfiguracion',fld:'vCSOPORTETECNICOCONFIGURACION',pic:''},{av:'AV12cSoporteTecnicoInternetRouter',fld:'vCSOPORTETECNICOINTERNETROUTER',pic:''}]}");
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
         AV7cSoporteTecnicoFecha = DateTime.MinValue;
         AV8cSoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblsoportetecnicoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblsoportetecnicofechafilter_Jsonclick = "";
         lblLblsoportetecnicohorafilter_Jsonclick = "";
         lblLblticketidfilter_Jsonclick = "";
         lblLblsoportetecnicoinstalacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblsoportetecnicoconfiguracionfilter_Jsonclick = "";
         lblLblsoportetecnicointernetrouterfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A203SoporteTecnicoFecha = DateTime.MinValue;
         A204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         H005Y2_A208SoporteTecnicoInternetRouter = new bool[] {false} ;
         H005Y2_n208SoporteTecnicoInternetRouter = new bool[] {false} ;
         H005Y2_A207SoporteTecnicoConfiguracion = new bool[] {false} ;
         H005Y2_n207SoporteTecnicoConfiguracion = new bool[] {false} ;
         H005Y2_A206SoporteTecnicoInstalacion = new bool[] {false} ;
         H005Y2_n206SoporteTecnicoInstalacion = new bool[] {false} ;
         H005Y2_A14TicketId = new long[1] ;
         H005Y2_A204SoporteTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         H005Y2_A203SoporteTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         H005Y2_A202SoporteTecnicoId = new long[1] ;
         H005Y3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00g0__default(),
            new Object[][] {
                new Object[] {
               H005Y2_A208SoporteTecnicoInternetRouter, H005Y2_n208SoporteTecnicoInternetRouter, H005Y2_A207SoporteTecnicoConfiguracion, H005Y2_n207SoporteTecnicoConfiguracion, H005Y2_A206SoporteTecnicoInstalacion, H005Y2_n206SoporteTecnicoInstalacion, H005Y2_A14TicketId, H005Y2_A204SoporteTecnicoHora, H005Y2_A203SoporteTecnicoFecha, H005Y2_A202SoporteTecnicoId
               }
               , new Object[] {
               H005Y3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCsoportetecnicoid_Enabled ;
      private int edtavCsoportetecnicoid_Visible ;
      private int edtavCsoportetecnicofecha_Enabled ;
      private int edtavCsoportetecnicohora_Enabled ;
      private int edtavCticketid_Enabled ;
      private int edtavCticketid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long AV13pSoporteTecnicoId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cSoporteTecnicoId ;
      private long AV9cTicketId ;
      private long A202SoporteTecnicoId ;
      private long A14TicketId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divSoportetecnicoidfiltercontainer_Class ;
      private string divSoportetecnicofechafiltercontainer_Class ;
      private string divSoportetecnicohorafiltercontainer_Class ;
      private string divTicketidfiltercontainer_Class ;
      private string divSoportetecnicoinstalacionfiltercontainer_Class ;
      private string divSoportetecnicoconfiguracionfiltercontainer_Class ;
      private string divSoportetecnicointernetrouterfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divSoportetecnicoidfiltercontainer_Internalname ;
      private string lblLblsoportetecnicoidfilter_Internalname ;
      private string lblLblsoportetecnicoidfilter_Jsonclick ;
      private string edtavCsoportetecnicoid_Internalname ;
      private string TempTags ;
      private string edtavCsoportetecnicoid_Jsonclick ;
      private string divSoportetecnicofechafiltercontainer_Internalname ;
      private string lblLblsoportetecnicofechafilter_Internalname ;
      private string lblLblsoportetecnicofechafilter_Jsonclick ;
      private string edtavCsoportetecnicofecha_Internalname ;
      private string edtavCsoportetecnicofecha_Jsonclick ;
      private string divSoportetecnicohorafiltercontainer_Internalname ;
      private string lblLblsoportetecnicohorafilter_Internalname ;
      private string lblLblsoportetecnicohorafilter_Jsonclick ;
      private string edtavCsoportetecnicohora_Internalname ;
      private string edtavCsoportetecnicohora_Jsonclick ;
      private string divTicketidfiltercontainer_Internalname ;
      private string lblLblticketidfilter_Internalname ;
      private string lblLblticketidfilter_Jsonclick ;
      private string edtavCticketid_Internalname ;
      private string edtavCticketid_Jsonclick ;
      private string divSoportetecnicoinstalacionfiltercontainer_Internalname ;
      private string lblLblsoportetecnicoinstalacionfilter_Internalname ;
      private string lblLblsoportetecnicoinstalacionfilter_Jsonclick ;
      private string chkavCsoportetecnicoinstalacion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divSoportetecnicoconfiguracionfiltercontainer_Internalname ;
      private string lblLblsoportetecnicoconfiguracionfilter_Internalname ;
      private string lblLblsoportetecnicoconfiguracionfilter_Jsonclick ;
      private string chkavCsoportetecnicoconfiguracion_Internalname ;
      private string divSoportetecnicointernetrouterfiltercontainer_Internalname ;
      private string lblLblsoportetecnicointernetrouterfilter_Internalname ;
      private string lblLblsoportetecnicointernetrouterfilter_Jsonclick ;
      private string chkavCsoportetecnicointernetrouter_Internalname ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtSoporteTecnicoFecha_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtSoporteTecnicoId_Internalname ;
      private string edtSoporteTecnicoFecha_Internalname ;
      private string edtSoporteTecnicoHora_Internalname ;
      private string edtTicketId_Internalname ;
      private string chkSoporteTecnicoInstalacion_Internalname ;
      private string chkSoporteTecnicoConfiguracion_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtSoporteTecnicoId_Jsonclick ;
      private string edtSoporteTecnicoFecha_Jsonclick ;
      private string edtSoporteTecnicoHora_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string GXCCtl ;
      private DateTime AV8cSoporteTecnicoHora ;
      private DateTime A204SoporteTecnicoHora ;
      private DateTime AV7cSoporteTecnicoFecha ;
      private DateTime A203SoporteTecnicoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10cSoporteTecnicoInstalacion ;
      private bool AV11cSoporteTecnicoConfiguracion ;
      private bool AV12cSoporteTecnicoInternetRouter ;
      private bool wbLoad ;
      private bool A206SoporteTecnicoInstalacion ;
      private bool A207SoporteTecnicoConfiguracion ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n206SoporteTecnicoInstalacion ;
      private bool n207SoporteTecnicoConfiguracion ;
      private bool gxdyncontrolsrefreshing ;
      private bool A208SoporteTecnicoInternetRouter ;
      private bool n208SoporteTecnicoInternetRouter ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV17Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCsoportetecnicoinstalacion ;
      private GXCheckbox chkavCsoportetecnicoconfiguracion ;
      private GXCheckbox chkavCsoportetecnicointernetrouter ;
      private GXCheckbox chkSoporteTecnicoInstalacion ;
      private GXCheckbox chkSoporteTecnicoConfiguracion ;
      private IDataStoreProvider pr_default ;
      private bool[] H005Y2_A208SoporteTecnicoInternetRouter ;
      private bool[] H005Y2_n208SoporteTecnicoInternetRouter ;
      private bool[] H005Y2_A207SoporteTecnicoConfiguracion ;
      private bool[] H005Y2_n207SoporteTecnicoConfiguracion ;
      private bool[] H005Y2_A206SoporteTecnicoInstalacion ;
      private bool[] H005Y2_n206SoporteTecnicoInstalacion ;
      private long[] H005Y2_A14TicketId ;
      private DateTime[] H005Y2_A204SoporteTecnicoHora ;
      private DateTime[] H005Y2_A203SoporteTecnicoFecha ;
      private long[] H005Y2_A202SoporteTecnicoId ;
      private long[] H005Y3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pSoporteTecnicoId ;
      private GXWebForm Form ;
   }

   public class gx00g0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005Y2( IGxContext context ,
                                             DateTime AV7cSoporteTecnicoFecha ,
                                             DateTime AV8cSoporteTecnicoHora ,
                                             long AV9cTicketId ,
                                             bool AV10cSoporteTecnicoInstalacion ,
                                             bool AV11cSoporteTecnicoConfiguracion ,
                                             bool AV12cSoporteTecnicoInternetRouter ,
                                             DateTime A203SoporteTecnicoFecha ,
                                             DateTime A204SoporteTecnicoHora ,
                                             long A14TicketId ,
                                             bool A206SoporteTecnicoInstalacion ,
                                             bool A207SoporteTecnicoConfiguracion ,
                                             bool A208SoporteTecnicoInternetRouter ,
                                             long AV6cSoporteTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [SoporteTecnicoInternetRouter], [SoporteTecnicoConfiguracion], [SoporteTecnicoInstalacion], [TicketId], [SoporteTecnicoHora], [SoporteTecnicoFecha], [SoporteTecnicoId]";
         sFromString = " FROM [AtencionSoporteTecnico]";
         sOrderString = "";
         AddWhere(sWhereString, "([SoporteTecnicoId] >= @AV6cSoporteTecnicoId)");
         if ( ! (DateTime.MinValue==AV7cSoporteTecnicoFecha) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoFecha] >= @AV7cSoporteTecnicoFecha)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cSoporteTecnicoHora) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoHora] >= @AV8cSoporteTecnicoHora)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cTicketId) )
         {
            AddWhere(sWhereString, "([TicketId] >= @AV9cTicketId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (false==AV10cSoporteTecnicoInstalacion) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoInstalacion] >= @AV10cSoporteTecnicoInstalacion)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV11cSoporteTecnicoConfiguracion) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoConfiguracion] >= @AV11cSoporteTecnicoConfiguracion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV12cSoporteTecnicoInternetRouter) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoInternetRouter] >= @AV12cSoporteTecnicoInternetRouter)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [SoporteTecnicoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005Y3( IGxContext context ,
                                             DateTime AV7cSoporteTecnicoFecha ,
                                             DateTime AV8cSoporteTecnicoHora ,
                                             long AV9cTicketId ,
                                             bool AV10cSoporteTecnicoInstalacion ,
                                             bool AV11cSoporteTecnicoConfiguracion ,
                                             bool AV12cSoporteTecnicoInternetRouter ,
                                             DateTime A203SoporteTecnicoFecha ,
                                             DateTime A204SoporteTecnicoHora ,
                                             long A14TicketId ,
                                             bool A206SoporteTecnicoInstalacion ,
                                             bool A207SoporteTecnicoConfiguracion ,
                                             bool A208SoporteTecnicoInternetRouter ,
                                             long AV6cSoporteTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [AtencionSoporteTecnico]";
         AddWhere(sWhereString, "([SoporteTecnicoId] >= @AV6cSoporteTecnicoId)");
         if ( ! (DateTime.MinValue==AV7cSoporteTecnicoFecha) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoFecha] >= @AV7cSoporteTecnicoFecha)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cSoporteTecnicoHora) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoHora] >= @AV8cSoporteTecnicoHora)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cTicketId) )
         {
            AddWhere(sWhereString, "([TicketId] >= @AV9cTicketId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (false==AV10cSoporteTecnicoInstalacion) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoInstalacion] >= @AV10cSoporteTecnicoInstalacion)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV11cSoporteTecnicoConfiguracion) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoConfiguracion] >= @AV11cSoporteTecnicoConfiguracion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV12cSoporteTecnicoInternetRouter) )
         {
            AddWhere(sWhereString, "([SoporteTecnicoInternetRouter] >= @AV12cSoporteTecnicoInternetRouter)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H005Y2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (bool)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H005Y3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (bool)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH005Y2;
          prmH005Y2 = new Object[] {
          new ParDef("@AV6cSoporteTecnicoId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cSoporteTecnicoFecha",GXType.Date,8,0) ,
          new ParDef("@AV8cSoporteTecnicoHora",GXType.DateTime,0,5) ,
          new ParDef("@AV9cTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV10cSoporteTecnicoInstalacion",GXType.Boolean,4,0) ,
          new ParDef("@AV11cSoporteTecnicoConfiguracion",GXType.Boolean,4,0) ,
          new ParDef("@AV12cSoporteTecnicoInternetRouter",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005Y3;
          prmH005Y3 = new Object[] {
          new ParDef("@AV6cSoporteTecnicoId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cSoporteTecnicoFecha",GXType.Date,8,0) ,
          new ParDef("@AV8cSoporteTecnicoHora",GXType.DateTime,0,5) ,
          new ParDef("@AV9cTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV10cSoporteTecnicoInstalacion",GXType.Boolean,4,0) ,
          new ParDef("@AV11cSoporteTecnicoConfiguracion",GXType.Boolean,4,0) ,
          new ParDef("@AV12cSoporteTecnicoInternetRouter",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Y2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Y3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((bool[]) buf[2])[0] = rslt.getBool(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((bool[]) buf[4])[0] = rslt.getBool(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
