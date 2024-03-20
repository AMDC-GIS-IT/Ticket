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
   public class gx0090 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0090( )
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

      public gx0090( IGxContext context )
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

      public void execute( out long aP0_pTicketTecnicoId )
      {
         this.AV13pTicketTecnicoId = 0 ;
         executePrivate();
         aP0_pTicketTecnicoId=this.AV13pTicketTecnicoId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCtickettecnicoinstalacion = new GXCheckbox();
         chkavCtickettecnicoconfiguracion = new GXCheckbox();
         chkTicketTecnicoInstalacion = new GXCheckbox();
         chkTicketTecnicoConfiguracion = new GXCheckbox();
         chkTicketTecnicoInternetRouter = new GXCheckbox();
         chkTicketTecnicoFormateo = new GXCheckbox();
         chkTicketTecnicoReparacion = new GXCheckbox();
         chkTicketTecnicoRam = new GXCheckbox();
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
               AV6cTicketTecnicoId = (long)(NumberUtil.Val( GetPar( "cTicketTecnicoId"), "."));
               AV7cTicketTecnicoFecha = context.localUtil.ParseDateParm( GetPar( "cTicketTecnicoFecha"));
               AV8cTicketTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "cTicketTecnicoHora")));
               AV9cTicketId = (long)(NumberUtil.Val( GetPar( "cTicketId"), "."));
               AV10cTicketResponsableId = (long)(NumberUtil.Val( GetPar( "cTicketResponsableId"), "."));
               AV11cTicketTecnicoInstalacion = StringUtil.StrToBool( GetPar( "cTicketTecnicoInstalacion"));
               AV12cTicketTecnicoConfiguracion = StringUtil.StrToBool( GetPar( "cTicketTecnicoConfiguracion"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "TICKETTECNICOIDFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicoidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETTECNICOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicofechafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETTECNICOHORAFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicohorafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETTECNICOINSTALACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicoinstalacionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETTECNICOCONFIGURACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicoconfiguracionfiltercontainer_Class));
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
               AV13pTicketTecnicoId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV13pTicketTecnicoId), 10, 0));
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
            return "gx0090_Execute" ;
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
         PA0G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0G2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249572113", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pTicketTecnicoId,10,0))}, new string[] {"pTicketTecnicoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTicketTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETTECNICOFECHA", context.localUtil.Format(AV7cTicketTecnicoFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETTECNICOHORA", context.localUtil.TToC( AV8cTicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cTicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETTECNICOINSTALACION", StringUtil.BoolToStr( AV11cTicketTecnicoInstalacion));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETTECNICOCONFIGURACION", StringUtil.BoolToStr( AV12cTicketTecnicoConfiguracion));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pTicketTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICOIDFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicofechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICOHORAFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicohorafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICOINSTALACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicoinstalacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETTECNICOCONFIGURACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTickettecnicoconfiguracionfiltercontainer_Class));
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
            WE0G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0G2( ) ;
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
         return formatLink("gx0090.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pTicketTecnicoId,10,0))}, new string[] {"pTicketTecnicoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0090" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Ticket Tecnico" ;
      }

      protected void WB0G0( )
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
            GxWebStd.gx_div_start( context, divTickettecnicoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickettecnicoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickettecnicoidfilter_Internalname, "Id Ticket Tecnico", "", "", lblLbltickettecnicoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtickettecnicoid_Internalname, "Id Ticket Tecnico", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCtickettecnicoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTicketTecnicoId), 10, 0, ",", "")), ((edtavCtickettecnicoid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cTicketTecnicoId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cTicketTecnicoId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtickettecnicoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCtickettecnicoid_Visible, edtavCtickettecnicoid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divTickettecnicofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickettecnicofechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickettecnicofechafilter_Internalname, "Fecha", "", "", lblLbltickettecnicofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120g1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtickettecnicofecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtickettecnicofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtickettecnicofecha_Internalname, context.localUtil.Format(AV7cTicketTecnicoFecha, "99/99/9999"), context.localUtil.Format( AV7cTicketTecnicoFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtickettecnicofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtickettecnicofecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divTickettecnicohorafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickettecnicohorafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickettecnicohorafilter_Internalname, "Hora", "", "", lblLbltickettecnicohorafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130g1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtickettecnicohora_Internalname, "Hora", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtickettecnicohora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtickettecnicohora_Internalname, context.localUtil.TToC( AV8cTicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV8cTicketTecnicoHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtickettecnicohora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtickettecnicohora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_label_ctrl( context, lblLblticketidfilter_Internalname, "Id Ticket", "", "", lblLblticketidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavCticketid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cTicketId), 10, 0, ",", "")), ((edtavCticketid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9cTicketId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV9cTicketId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCticketid_Visible, edtavCticketid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divTicketresponsableidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketresponsableidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketresponsableidfilter_Internalname, "Ticket Responsable Id", "", "", lblLblticketresponsableidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCticketresponsableid_Internalname, "Ticket Responsable Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCticketresponsableid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTicketResponsableId), 10, 0, ",", "")), ((edtavCticketresponsableid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10cTicketResponsableId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV10cTicketResponsableId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketresponsableid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCticketresponsableid_Visible, edtavCticketresponsableid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0090.htm");
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
            GxWebStd.gx_div_start( context, divTickettecnicoinstalacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickettecnicoinstalacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickettecnicoinstalacionfilter_Internalname, "Instalación", "", "", lblLbltickettecnicoinstalacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCtickettecnicoinstalacion_Internalname, "Instalación", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCtickettecnicoinstalacion_Internalname, StringUtil.BoolToStr( AV11cTicketTecnicoInstalacion), "", "Instalación", chkavCtickettecnicoinstalacion.Visible, chkavCtickettecnicoinstalacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_div_start( context, divTickettecnicoconfiguracionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickettecnicoconfiguracionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickettecnicoconfiguracionfilter_Internalname, "Configuración", "", "", lblLbltickettecnicoconfiguracionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0090.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCtickettecnicoconfiguracion_Internalname, "Configuración", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCtickettecnicoconfiguracion_Internalname, StringUtil.BoolToStr( AV12cTicketTecnicoConfiguracion), "", "Configuración", chkavCtickettecnicoconfiguracion.Visible, chkavCtickettecnicoconfiguracion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180g1_client"+"'", TempTags, "", 2, "HLP_Gx0090.htm");
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
               context.SendWebValue( "Ticket Tecnico") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Instalación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Configuración") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Internet/Router") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Formateo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Reparación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "RAM") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtTicketTecnicoFecha_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A70TicketTecnicoFormateo));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A84TicketTecnicoReparacion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A83TicketTecnicoRam));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0090.htm");
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

      protected void START0G2( )
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
            Form.Meta.addItem("description", "Selection List Ticket Tecnico", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0G0( ) ;
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
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
                              A18TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtTicketTecnicoId_Internalname), ",", "."));
                              A69TicketTecnicoFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketTecnicoFecha_Internalname), 0));
                              A71TicketTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketTecnicoHora_Internalname), 0));
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", "."));
                              A72TicketTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoInstalacion_Internalname));
                              A66TicketTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoConfiguracion_Internalname));
                              A73TicketTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( chkTicketTecnicoInternetRouter_Internalname));
                              A70TicketTecnicoFormateo = StringUtil.StrToBool( cgiGet( chkTicketTecnicoFormateo_Internalname));
                              A84TicketTecnicoReparacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoReparacion_Internalname));
                              A83TicketTecnicoRam = StringUtil.StrToBool( cgiGet( chkTicketTecnicoRam_Internalname));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ctickettecnicoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETTECNICOID"), ",", ".") != Convert.ToDecimal( AV6cTicketTecnicoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctickettecnicofecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETTECNICOFECHA"), 0) != AV7cTicketTecnicoFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctickettecnicohora Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETTECNICOHORA"), 0) != AV8cTicketTecnicoHora )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETID"), ",", ".") != Convert.ToDecimal( AV9cTicketId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketresponsableid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV10cTicketResponsableId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctickettecnicoinstalacion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETTECNICOINSTALACION")) != AV11cTicketTecnicoInstalacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctickettecnicoconfiguracion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETTECNICOCONFIGURACION")) != AV12cTicketTecnicoConfiguracion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210G2 ();
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

      protected void WE0G2( )
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

      protected void PA0G2( )
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
                                        long AV6cTicketTecnicoId ,
                                        DateTime AV7cTicketTecnicoFecha ,
                                        DateTime AV8cTicketTecnicoHora ,
                                        long AV9cTicketId ,
                                        long AV10cTicketResponsableId ,
                                        bool AV11cTicketTecnicoInstalacion ,
                                        bool AV12cTicketTecnicoConfiguracion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
         AV11cTicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cTicketTecnicoInstalacion));
         AssignAttri("", false, "AV11cTicketTecnicoInstalacion", AV11cTicketTecnicoInstalacion);
         AV12cTicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cTicketTecnicoConfiguracion));
         AssignAttri("", false, "AV12cTicketTecnicoConfiguracion", AV12cTicketTecnicoConfiguracion);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
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

      protected void RF0G2( )
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
                                                 AV7cTicketTecnicoFecha ,
                                                 AV8cTicketTecnicoHora ,
                                                 AV9cTicketId ,
                                                 AV10cTicketResponsableId ,
                                                 AV11cTicketTecnicoInstalacion ,
                                                 AV12cTicketTecnicoConfiguracion ,
                                                 A69TicketTecnicoFecha ,
                                                 A71TicketTecnicoHora ,
                                                 A14TicketId ,
                                                 A16TicketResponsableId ,
                                                 A72TicketTecnicoInstalacion ,
                                                 A66TicketTecnicoConfiguracion ,
                                                 AV6cTicketTecnicoId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H000G2 */
            pr_default.execute(0, new Object[] {AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A83TicketTecnicoRam = H000G2_A83TicketTecnicoRam[0];
               A84TicketTecnicoReparacion = H000G2_A84TicketTecnicoReparacion[0];
               A70TicketTecnicoFormateo = H000G2_A70TicketTecnicoFormateo[0];
               A73TicketTecnicoInternetRouter = H000G2_A73TicketTecnicoInternetRouter[0];
               A66TicketTecnicoConfiguracion = H000G2_A66TicketTecnicoConfiguracion[0];
               A72TicketTecnicoInstalacion = H000G2_A72TicketTecnicoInstalacion[0];
               A16TicketResponsableId = H000G2_A16TicketResponsableId[0];
               A14TicketId = H000G2_A14TicketId[0];
               A71TicketTecnicoHora = H000G2_A71TicketTecnicoHora[0];
               A69TicketTecnicoFecha = H000G2_A69TicketTecnicoFecha[0];
               A18TicketTecnicoId = H000G2_A18TicketTecnicoId[0];
               /* Execute user event: Load */
               E200G2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0G0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETTECNICOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9"), context));
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
                                              AV7cTicketTecnicoFecha ,
                                              AV8cTicketTecnicoHora ,
                                              AV9cTicketId ,
                                              AV10cTicketResponsableId ,
                                              AV11cTicketTecnicoInstalacion ,
                                              AV12cTicketTecnicoConfiguracion ,
                                              A69TicketTecnicoFecha ,
                                              A71TicketTecnicoHora ,
                                              A14TicketId ,
                                              A16TicketResponsableId ,
                                              A72TicketTecnicoInstalacion ,
                                              A66TicketTecnicoConfiguracion ,
                                              AV6cTicketTecnicoId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         /* Using cursor H000G3 */
         pr_default.execute(1, new Object[] {AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion});
         GRID1_nRecordCount = H000G3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketTecnicoId, AV7cTicketTecnicoFecha, AV8cTicketTecnicoHora, AV9cTicketId, AV10cTicketResponsableId, AV11cTicketTecnicoInstalacion, AV12cTicketTecnicoConfiguracion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190G2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCtickettecnicoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCtickettecnicoid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTICKETTECNICOID");
               GX_FocusControl = edtavCtickettecnicoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTicketTecnicoId = 0;
               AssignAttri("", false, "AV6cTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV6cTicketTecnicoId), 10, 0));
            }
            else
            {
               AV6cTicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtavCtickettecnicoid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV6cTicketTecnicoId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtickettecnicofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "vCTICKETTECNICOFECHA");
               GX_FocusControl = edtavCtickettecnicofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTicketTecnicoFecha = DateTime.MinValue;
               AssignAttri("", false, "AV7cTicketTecnicoFecha", context.localUtil.Format(AV7cTicketTecnicoFecha, "99/99/9999"));
            }
            else
            {
               AV7cTicketTecnicoFecha = context.localUtil.CToD( cgiGet( edtavCtickettecnicofecha_Internalname), 2);
               AssignAttri("", false, "AV7cTicketTecnicoFecha", context.localUtil.Format(AV7cTicketTecnicoFecha, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtickettecnicohora_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "vCTICKETTECNICOHORA");
               GX_FocusControl = edtavCtickettecnicohora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cTicketTecnicoHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8cTicketTecnicoHora", context.localUtil.TToC( AV8cTicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV8cTicketTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavCtickettecnicohora_Internalname)));
               AssignAttri("", false, "AV8cTicketTecnicoHora", context.localUtil.TToC( AV8cTicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCticketresponsableid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCticketresponsableid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTICKETRESPONSABLEID");
               GX_FocusControl = edtavCticketresponsableid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTicketResponsableId = 0;
               AssignAttri("", false, "AV10cTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV10cTicketResponsableId), 10, 0));
            }
            else
            {
               AV10cTicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtavCticketresponsableid_Internalname), ",", "."));
               AssignAttri("", false, "AV10cTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV10cTicketResponsableId), 10, 0));
            }
            AV11cTicketTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkavCtickettecnicoinstalacion_Internalname));
            AssignAttri("", false, "AV11cTicketTecnicoInstalacion", AV11cTicketTecnicoInstalacion);
            AV12cTicketTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkavCtickettecnicoconfiguracion_Internalname));
            AssignAttri("", false, "AV12cTicketTecnicoConfiguracion", AV12cTicketTecnicoConfiguracion);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETTECNICOID"), ",", ".") != Convert.ToDecimal( AV6cTicketTecnicoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTICKETTECNICOFECHA"), 2) != AV7cTicketTecnicoFecha )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETTECNICOHORA")) != AV8cTicketTecnicoHora )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETID"), ",", ".") != Convert.ToDecimal( AV9cTicketId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV10cTicketResponsableId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETTECNICOINSTALACION")) != AV11cTicketTecnicoInstalacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETTECNICOCONFIGURACION")) != AV12cTicketTecnicoConfiguracion )
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
         E190G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190G2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Ticket Tecnico", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200G2( )
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
         E210G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pTicketTecnicoId = A18TicketTecnicoId;
         AssignAttri("", false, "AV13pTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV13pTicketTecnicoId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pTicketTecnicoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pTicketTecnicoId"});
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
         AV13pTicketTecnicoId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV13pTicketTecnicoId), 10, 0));
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
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023124957221", true, true);
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
         context.AddJavascriptSource("gx0090.js", "?2023124957221", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID_"+sGXsfl_84_idx;
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA_"+sGXsfl_84_idx;
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA_"+sGXsfl_84_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_84_idx;
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION_"+sGXsfl_84_idx;
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION_"+sGXsfl_84_idx;
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER_"+sGXsfl_84_idx;
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO_"+sGXsfl_84_idx;
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION_"+sGXsfl_84_idx;
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID_"+sGXsfl_84_fel_idx;
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA_"+sGXsfl_84_fel_idx;
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA_"+sGXsfl_84_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_84_fel_idx;
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION_"+sGXsfl_84_fel_idx;
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION_"+sGXsfl_84_fel_idx;
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER_"+sGXsfl_84_fel_idx;
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO_"+sGXsfl_84_fel_idx;
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION_"+sGXsfl_84_fel_idx;
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0G0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ",", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtTicketTecnicoFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtTicketTecnicoFecha_Internalname, "Link", edtTicketTecnicoFecha_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoFecha_Internalname,context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"),context.localUtil.Format( A69TicketTecnicoFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTicketTecnicoFecha_Link,(string)"",(string)"",(string)"",(string)edtTicketTecnicoFecha_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoHora_Internalname,context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A71TicketTecnicoHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
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
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETTECNICOINSTALACION_" + sGXsfl_84_idx;
            chkTicketTecnicoInstalacion.Name = GXCCtl;
            chkTicketTecnicoInstalacion.WebTags = "";
            chkTicketTecnicoInstalacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, !bGXsfl_84_Refreshing);
            chkTicketTecnicoInstalacion.CheckedValue = "false";
            A72TicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoInstalacion_Internalname,StringUtil.BoolToStr( A72TicketTecnicoInstalacion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETTECNICOCONFIGURACION_" + sGXsfl_84_idx;
            chkTicketTecnicoConfiguracion.Name = GXCCtl;
            chkTicketTecnicoConfiguracion.WebTags = "";
            chkTicketTecnicoConfiguracion.Caption = "";
            AssignProp("", false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, !bGXsfl_84_Refreshing);
            chkTicketTecnicoConfiguracion.CheckedValue = "false";
            A66TicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoConfiguracion_Internalname,StringUtil.BoolToStr( A66TicketTecnicoConfiguracion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETTECNICOINTERNETROUTER_" + sGXsfl_84_idx;
            chkTicketTecnicoInternetRouter.Name = GXCCtl;
            chkTicketTecnicoInternetRouter.WebTags = "";
            chkTicketTecnicoInternetRouter.Caption = "";
            AssignProp("", false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, !bGXsfl_84_Refreshing);
            chkTicketTecnicoInternetRouter.CheckedValue = "false";
            A73TicketTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoInternetRouter_Internalname,StringUtil.BoolToStr( A73TicketTecnicoInternetRouter),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETTECNICOFORMATEO_" + sGXsfl_84_idx;
            chkTicketTecnicoFormateo.Name = GXCCtl;
            chkTicketTecnicoFormateo.WebTags = "";
            chkTicketTecnicoFormateo.Caption = "";
            AssignProp("", false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, !bGXsfl_84_Refreshing);
            chkTicketTecnicoFormateo.CheckedValue = "false";
            A70TicketTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A70TicketTecnicoFormateo));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoFormateo_Internalname,StringUtil.BoolToStr( A70TicketTecnicoFormateo),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETTECNICOREPARACION_" + sGXsfl_84_idx;
            chkTicketTecnicoReparacion.Name = GXCCtl;
            chkTicketTecnicoReparacion.WebTags = "";
            chkTicketTecnicoReparacion.Caption = "";
            AssignProp("", false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, !bGXsfl_84_Refreshing);
            chkTicketTecnicoReparacion.CheckedValue = "false";
            A84TicketTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A84TicketTecnicoReparacion));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoReparacion_Internalname,StringUtil.BoolToStr( A84TicketTecnicoReparacion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETTECNICORAM_" + sGXsfl_84_idx;
            chkTicketTecnicoRam.Name = GXCCtl;
            chkTicketTecnicoRam.WebTags = "";
            chkTicketTecnicoRam.Caption = "";
            AssignProp("", false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, !bGXsfl_84_Refreshing);
            chkTicketTecnicoRam.CheckedValue = "false";
            A83TicketTecnicoRam = StringUtil.StrToBool( StringUtil.BoolToStr( A83TicketTecnicoRam));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketTecnicoRam_Internalname,StringUtil.BoolToStr( A83TicketTecnicoRam),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            send_integrity_lvl_hashes0G2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCtickettecnicoinstalacion.Name = "vCTICKETTECNICOINSTALACION";
         chkavCtickettecnicoinstalacion.WebTags = "";
         chkavCtickettecnicoinstalacion.Caption = "";
         AssignProp("", false, chkavCtickettecnicoinstalacion_Internalname, "TitleCaption", chkavCtickettecnicoinstalacion.Caption, true);
         chkavCtickettecnicoinstalacion.CheckedValue = "false";
         AV11cTicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cTicketTecnicoInstalacion));
         AssignAttri("", false, "AV11cTicketTecnicoInstalacion", AV11cTicketTecnicoInstalacion);
         chkavCtickettecnicoconfiguracion.Name = "vCTICKETTECNICOCONFIGURACION";
         chkavCtickettecnicoconfiguracion.WebTags = "";
         chkavCtickettecnicoconfiguracion.Caption = "";
         AssignProp("", false, chkavCtickettecnicoconfiguracion_Internalname, "TitleCaption", chkavCtickettecnicoconfiguracion.Caption, true);
         chkavCtickettecnicoconfiguracion.CheckedValue = "false";
         AV12cTicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cTicketTecnicoConfiguracion));
         AssignAttri("", false, "AV12cTicketTecnicoConfiguracion", AV12cTicketTecnicoConfiguracion);
         GXCCtl = "TICKETTECNICOINSTALACION_" + sGXsfl_84_idx;
         chkTicketTecnicoInstalacion.Name = GXCCtl;
         chkTicketTecnicoInstalacion.WebTags = "";
         chkTicketTecnicoInstalacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, !bGXsfl_84_Refreshing);
         chkTicketTecnicoInstalacion.CheckedValue = "false";
         A72TicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
         GXCCtl = "TICKETTECNICOCONFIGURACION_" + sGXsfl_84_idx;
         chkTicketTecnicoConfiguracion.Name = GXCCtl;
         chkTicketTecnicoConfiguracion.WebTags = "";
         chkTicketTecnicoConfiguracion.Caption = "";
         AssignProp("", false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, !bGXsfl_84_Refreshing);
         chkTicketTecnicoConfiguracion.CheckedValue = "false";
         A66TicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
         GXCCtl = "TICKETTECNICOINTERNETROUTER_" + sGXsfl_84_idx;
         chkTicketTecnicoInternetRouter.Name = GXCCtl;
         chkTicketTecnicoInternetRouter.WebTags = "";
         chkTicketTecnicoInternetRouter.Caption = "";
         AssignProp("", false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, !bGXsfl_84_Refreshing);
         chkTicketTecnicoInternetRouter.CheckedValue = "false";
         A73TicketTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
         GXCCtl = "TICKETTECNICOFORMATEO_" + sGXsfl_84_idx;
         chkTicketTecnicoFormateo.Name = GXCCtl;
         chkTicketTecnicoFormateo.WebTags = "";
         chkTicketTecnicoFormateo.Caption = "";
         AssignProp("", false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, !bGXsfl_84_Refreshing);
         chkTicketTecnicoFormateo.CheckedValue = "false";
         A70TicketTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A70TicketTecnicoFormateo));
         GXCCtl = "TICKETTECNICOREPARACION_" + sGXsfl_84_idx;
         chkTicketTecnicoReparacion.Name = GXCCtl;
         chkTicketTecnicoReparacion.WebTags = "";
         chkTicketTecnicoReparacion.Caption = "";
         AssignProp("", false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, !bGXsfl_84_Refreshing);
         chkTicketTecnicoReparacion.CheckedValue = "false";
         A84TicketTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A84TicketTecnicoReparacion));
         GXCCtl = "TICKETTECNICORAM_" + sGXsfl_84_idx;
         chkTicketTecnicoRam.Name = GXCCtl;
         chkTicketTecnicoRam.WebTags = "";
         chkTicketTecnicoRam.Caption = "";
         AssignProp("", false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, !bGXsfl_84_Refreshing);
         chkTicketTecnicoRam.CheckedValue = "false";
         A83TicketTecnicoRam = StringUtil.StrToBool( StringUtil.BoolToStr( A83TicketTecnicoRam));
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLbltickettecnicoidfilter_Internalname = "LBLTICKETTECNICOIDFILTER";
         edtavCtickettecnicoid_Internalname = "vCTICKETTECNICOID";
         divTickettecnicoidfiltercontainer_Internalname = "TICKETTECNICOIDFILTERCONTAINER";
         lblLbltickettecnicofechafilter_Internalname = "LBLTICKETTECNICOFECHAFILTER";
         edtavCtickettecnicofecha_Internalname = "vCTICKETTECNICOFECHA";
         divTickettecnicofechafiltercontainer_Internalname = "TICKETTECNICOFECHAFILTERCONTAINER";
         lblLbltickettecnicohorafilter_Internalname = "LBLTICKETTECNICOHORAFILTER";
         edtavCtickettecnicohora_Internalname = "vCTICKETTECNICOHORA";
         divTickettecnicohorafiltercontainer_Internalname = "TICKETTECNICOHORAFILTERCONTAINER";
         lblLblticketidfilter_Internalname = "LBLTICKETIDFILTER";
         edtavCticketid_Internalname = "vCTICKETID";
         divTicketidfiltercontainer_Internalname = "TICKETIDFILTERCONTAINER";
         lblLblticketresponsableidfilter_Internalname = "LBLTICKETRESPONSABLEIDFILTER";
         edtavCticketresponsableid_Internalname = "vCTICKETRESPONSABLEID";
         divTicketresponsableidfiltercontainer_Internalname = "TICKETRESPONSABLEIDFILTERCONTAINER";
         lblLbltickettecnicoinstalacionfilter_Internalname = "LBLTICKETTECNICOINSTALACIONFILTER";
         chkavCtickettecnicoinstalacion_Internalname = "vCTICKETTECNICOINSTALACION";
         divTickettecnicoinstalacionfiltercontainer_Internalname = "TICKETTECNICOINSTALACIONFILTERCONTAINER";
         lblLbltickettecnicoconfiguracionfilter_Internalname = "LBLTICKETTECNICOCONFIGURACIONFILTER";
         chkavCtickettecnicoconfiguracion_Internalname = "vCTICKETTECNICOCONFIGURACION";
         divTickettecnicoconfiguracionfiltercontainer_Internalname = "TICKETTECNICOCONFIGURACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTicketTecnicoId_Internalname = "TICKETTECNICOID";
         edtTicketTecnicoFecha_Internalname = "TICKETTECNICOFECHA";
         edtTicketTecnicoHora_Internalname = "TICKETTECNICOHORA";
         edtTicketId_Internalname = "TICKETID";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         chkTicketTecnicoInstalacion_Internalname = "TICKETTECNICOINSTALACION";
         chkTicketTecnicoConfiguracion_Internalname = "TICKETTECNICOCONFIGURACION";
         chkTicketTecnicoInternetRouter_Internalname = "TICKETTECNICOINTERNETROUTER";
         chkTicketTecnicoFormateo_Internalname = "TICKETTECNICOFORMATEO";
         chkTicketTecnicoReparacion_Internalname = "TICKETTECNICOREPARACION";
         chkTicketTecnicoRam_Internalname = "TICKETTECNICORAM";
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
         chkavCtickettecnicoconfiguracion.Caption = "Configuración";
         chkavCtickettecnicoinstalacion.Caption = "Instalación";
         chkTicketTecnicoRam.Caption = "";
         chkTicketTecnicoReparacion.Caption = "";
         chkTicketTecnicoFormateo.Caption = "";
         chkTicketTecnicoInternetRouter.Caption = "";
         chkTicketTecnicoConfiguracion.Caption = "";
         chkTicketTecnicoInstalacion.Caption = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         edtTicketTecnicoHora_Jsonclick = "";
         edtTicketTecnicoFecha_Jsonclick = "";
         edtTicketTecnicoId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtTicketTecnicoFecha_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkavCtickettecnicoconfiguracion.Enabled = 1;
         chkavCtickettecnicoconfiguracion.Visible = 1;
         chkavCtickettecnicoinstalacion.Enabled = 1;
         chkavCtickettecnicoinstalacion.Visible = 1;
         edtavCticketresponsableid_Jsonclick = "";
         edtavCticketresponsableid_Enabled = 1;
         edtavCticketresponsableid_Visible = 1;
         edtavCticketid_Jsonclick = "";
         edtavCticketid_Enabled = 1;
         edtavCticketid_Visible = 1;
         edtavCtickettecnicohora_Jsonclick = "";
         edtavCtickettecnicohora_Enabled = 1;
         edtavCtickettecnicofecha_Jsonclick = "";
         edtavCtickettecnicofecha_Enabled = 1;
         edtavCtickettecnicoid_Jsonclick = "";
         edtavCtickettecnicoid_Enabled = 1;
         edtavCtickettecnicoid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Ticket Tecnico";
         divTickettecnicoconfiguracionfiltercontainer_Class = "AdvancedContainerItem";
         divTickettecnicoinstalacionfiltercontainer_Class = "AdvancedContainerItem";
         divTicketresponsableidfiltercontainer_Class = "AdvancedContainerItem";
         divTicketidfiltercontainer_Class = "AdvancedContainerItem";
         divTickettecnicohorafiltercontainer_Class = "AdvancedContainerItem";
         divTickettecnicofechafiltercontainer_Class = "AdvancedContainerItem";
         divTickettecnicoidfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketTecnicoId',fld:'vCTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketTecnicoFecha',fld:'vCTICKETTECNICOFECHA',pic:''},{av:'AV8cTicketTecnicoHora',fld:'vCTICKETTECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("'TOGGLE'","{handler:'E180G1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETTECNICOIDFILTER.CLICK","{handler:'E110G1',iparms:[{av:'divTickettecnicoidfiltercontainer_Class',ctrl:'TICKETTECNICOIDFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETTECNICOIDFILTER.CLICK",",oparms:[{av:'divTickettecnicoidfiltercontainer_Class',ctrl:'TICKETTECNICOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCtickettecnicoid_Visible',ctrl:'vCTICKETTECNICOID',prop:'Visible'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETTECNICOFECHAFILTER.CLICK","{handler:'E120G1',iparms:[{av:'divTickettecnicofechafiltercontainer_Class',ctrl:'TICKETTECNICOFECHAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETTECNICOFECHAFILTER.CLICK",",oparms:[{av:'divTickettecnicofechafiltercontainer_Class',ctrl:'TICKETTECNICOFECHAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETTECNICOHORAFILTER.CLICK","{handler:'E130G1',iparms:[{av:'divTickettecnicohorafiltercontainer_Class',ctrl:'TICKETTECNICOHORAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETTECNICOHORAFILTER.CLICK",",oparms:[{av:'divTickettecnicohorafiltercontainer_Class',ctrl:'TICKETTECNICOHORAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETIDFILTER.CLICK","{handler:'E140G1',iparms:[{av:'divTicketidfiltercontainer_Class',ctrl:'TICKETIDFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETIDFILTER.CLICK",",oparms:[{av:'divTicketidfiltercontainer_Class',ctrl:'TICKETIDFILTERCONTAINER',prop:'Class'},{av:'edtavCticketid_Visible',ctrl:'vCTICKETID',prop:'Visible'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETRESPONSABLEIDFILTER.CLICK","{handler:'E150G1',iparms:[{av:'divTicketresponsableidfiltercontainer_Class',ctrl:'TICKETRESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETRESPONSABLEIDFILTER.CLICK",",oparms:[{av:'divTicketresponsableidfiltercontainer_Class',ctrl:'TICKETRESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCticketresponsableid_Visible',ctrl:'vCTICKETRESPONSABLEID',prop:'Visible'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETTECNICOINSTALACIONFILTER.CLICK","{handler:'E160G1',iparms:[{av:'divTickettecnicoinstalacionfiltercontainer_Class',ctrl:'TICKETTECNICOINSTALACIONFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETTECNICOINSTALACIONFILTER.CLICK",",oparms:[{av:'divTickettecnicoinstalacionfiltercontainer_Class',ctrl:'TICKETTECNICOINSTALACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCtickettecnicoinstalacion.Visible',ctrl:'vCTICKETTECNICOINSTALACION',prop:'Visible'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETTECNICOCONFIGURACIONFILTER.CLICK","{handler:'E170G1',iparms:[{av:'divTickettecnicoconfiguracionfiltercontainer_Class',ctrl:'TICKETTECNICOCONFIGURACIONFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETTECNICOCONFIGURACIONFILTER.CLICK",",oparms:[{av:'divTickettecnicoconfiguracionfiltercontainer_Class',ctrl:'TICKETTECNICOCONFIGURACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCtickettecnicoconfiguracion.Visible',ctrl:'vCTICKETTECNICOCONFIGURACION',prop:'Visible'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E210G2',iparms:[{av:'A18TicketTecnicoId',fld:'TICKETTECNICOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pTicketTecnicoId',fld:'vPTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketTecnicoId',fld:'vCTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketTecnicoFecha',fld:'vCTICKETTECNICOFECHA',pic:''},{av:'AV8cTicketTecnicoHora',fld:'vCTICKETTECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketTecnicoId',fld:'vCTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketTecnicoFecha',fld:'vCTICKETTECNICOFECHA',pic:''},{av:'AV8cTicketTecnicoHora',fld:'vCTICKETTECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketTecnicoId',fld:'vCTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketTecnicoFecha',fld:'vCTICKETTECNICOFECHA',pic:''},{av:'AV8cTicketTecnicoHora',fld:'vCTICKETTECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketTecnicoId',fld:'vCTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketTecnicoFecha',fld:'vCTICKETTECNICOFECHA',pic:''},{av:'AV8cTicketTecnicoHora',fld:'vCTICKETTECNICOHORA',pic:'99:99'},{av:'AV9cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("VALIDV_CTICKETTECNICOFECHA","{handler:'Validv_Ctickettecnicofecha',iparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("VALIDV_CTICKETTECNICOFECHA",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Tickettecnicoram',iparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV11cTicketTecnicoInstalacion',fld:'vCTICKETTECNICOINSTALACION',pic:''},{av:'AV12cTicketTecnicoConfiguracion',fld:'vCTICKETTECNICOCONFIGURACION',pic:''}]}");
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
         AV7cTicketTecnicoFecha = DateTime.MinValue;
         AV8cTicketTecnicoHora = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLbltickettecnicoidfilter_Jsonclick = "";
         TempTags = "";
         lblLbltickettecnicofechafilter_Jsonclick = "";
         lblLbltickettecnicohorafilter_Jsonclick = "";
         lblLblticketidfilter_Jsonclick = "";
         lblLblticketresponsableidfilter_Jsonclick = "";
         lblLbltickettecnicoinstalacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLbltickettecnicoconfiguracionfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A69TicketTecnicoFecha = DateTime.MinValue;
         A71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         H000G2_A83TicketTecnicoRam = new bool[] {false} ;
         H000G2_A84TicketTecnicoReparacion = new bool[] {false} ;
         H000G2_A70TicketTecnicoFormateo = new bool[] {false} ;
         H000G2_A73TicketTecnicoInternetRouter = new bool[] {false} ;
         H000G2_A66TicketTecnicoConfiguracion = new bool[] {false} ;
         H000G2_A72TicketTecnicoInstalacion = new bool[] {false} ;
         H000G2_A16TicketResponsableId = new long[1] ;
         H000G2_A14TicketId = new long[1] ;
         H000G2_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         H000G2_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         H000G2_A18TicketTecnicoId = new long[1] ;
         H000G3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0090__default(),
            new Object[][] {
                new Object[] {
               H000G2_A83TicketTecnicoRam, H000G2_A84TicketTecnicoReparacion, H000G2_A70TicketTecnicoFormateo, H000G2_A73TicketTecnicoInternetRouter, H000G2_A66TicketTecnicoConfiguracion, H000G2_A72TicketTecnicoInstalacion, H000G2_A16TicketResponsableId, H000G2_A14TicketId, H000G2_A71TicketTecnicoHora, H000G2_A69TicketTecnicoFecha,
               H000G2_A18TicketTecnicoId
               }
               , new Object[] {
               H000G3_AGRID1_nRecordCount
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
      private int edtavCtickettecnicoid_Enabled ;
      private int edtavCtickettecnicoid_Visible ;
      private int edtavCtickettecnicofecha_Enabled ;
      private int edtavCtickettecnicohora_Enabled ;
      private int edtavCticketid_Enabled ;
      private int edtavCticketid_Visible ;
      private int edtavCticketresponsableid_Enabled ;
      private int edtavCticketresponsableid_Visible ;
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
      private long AV13pTicketTecnicoId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cTicketTecnicoId ;
      private long AV9cTicketId ;
      private long AV10cTicketResponsableId ;
      private long A18TicketTecnicoId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divTickettecnicoidfiltercontainer_Class ;
      private string divTickettecnicofechafiltercontainer_Class ;
      private string divTickettecnicohorafiltercontainer_Class ;
      private string divTicketidfiltercontainer_Class ;
      private string divTicketresponsableidfiltercontainer_Class ;
      private string divTickettecnicoinstalacionfiltercontainer_Class ;
      private string divTickettecnicoconfiguracionfiltercontainer_Class ;
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
      private string divTickettecnicoidfiltercontainer_Internalname ;
      private string lblLbltickettecnicoidfilter_Internalname ;
      private string lblLbltickettecnicoidfilter_Jsonclick ;
      private string edtavCtickettecnicoid_Internalname ;
      private string TempTags ;
      private string edtavCtickettecnicoid_Jsonclick ;
      private string divTickettecnicofechafiltercontainer_Internalname ;
      private string lblLbltickettecnicofechafilter_Internalname ;
      private string lblLbltickettecnicofechafilter_Jsonclick ;
      private string edtavCtickettecnicofecha_Internalname ;
      private string edtavCtickettecnicofecha_Jsonclick ;
      private string divTickettecnicohorafiltercontainer_Internalname ;
      private string lblLbltickettecnicohorafilter_Internalname ;
      private string lblLbltickettecnicohorafilter_Jsonclick ;
      private string edtavCtickettecnicohora_Internalname ;
      private string edtavCtickettecnicohora_Jsonclick ;
      private string divTicketidfiltercontainer_Internalname ;
      private string lblLblticketidfilter_Internalname ;
      private string lblLblticketidfilter_Jsonclick ;
      private string edtavCticketid_Internalname ;
      private string edtavCticketid_Jsonclick ;
      private string divTicketresponsableidfiltercontainer_Internalname ;
      private string lblLblticketresponsableidfilter_Internalname ;
      private string lblLblticketresponsableidfilter_Jsonclick ;
      private string edtavCticketresponsableid_Internalname ;
      private string edtavCticketresponsableid_Jsonclick ;
      private string divTickettecnicoinstalacionfiltercontainer_Internalname ;
      private string lblLbltickettecnicoinstalacionfilter_Internalname ;
      private string lblLbltickettecnicoinstalacionfilter_Jsonclick ;
      private string chkavCtickettecnicoinstalacion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTickettecnicoconfiguracionfiltercontainer_Internalname ;
      private string lblLbltickettecnicoconfiguracionfilter_Internalname ;
      private string lblLbltickettecnicoconfiguracionfilter_Jsonclick ;
      private string chkavCtickettecnicoconfiguracion_Internalname ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtTicketTecnicoFecha_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtTicketTecnicoId_Internalname ;
      private string edtTicketTecnicoFecha_Internalname ;
      private string edtTicketTecnicoHora_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string chkTicketTecnicoInstalacion_Internalname ;
      private string chkTicketTecnicoConfiguracion_Internalname ;
      private string chkTicketTecnicoInternetRouter_Internalname ;
      private string chkTicketTecnicoFormateo_Internalname ;
      private string chkTicketTecnicoReparacion_Internalname ;
      private string chkTicketTecnicoRam_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtTicketTecnicoId_Jsonclick ;
      private string edtTicketTecnicoFecha_Jsonclick ;
      private string edtTicketTecnicoHora_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketResponsableId_Jsonclick ;
      private string GXCCtl ;
      private DateTime AV8cTicketTecnicoHora ;
      private DateTime A71TicketTecnicoHora ;
      private DateTime AV7cTicketTecnicoFecha ;
      private DateTime A69TicketTecnicoFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11cTicketTecnicoInstalacion ;
      private bool AV12cTicketTecnicoConfiguracion ;
      private bool wbLoad ;
      private bool A72TicketTecnicoInstalacion ;
      private bool A66TicketTecnicoConfiguracion ;
      private bool A73TicketTecnicoInternetRouter ;
      private bool A70TicketTecnicoFormateo ;
      private bool A84TicketTecnicoReparacion ;
      private bool A83TicketTecnicoRam ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
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
      private GXCheckbox chkavCtickettecnicoinstalacion ;
      private GXCheckbox chkavCtickettecnicoconfiguracion ;
      private GXCheckbox chkTicketTecnicoInstalacion ;
      private GXCheckbox chkTicketTecnicoConfiguracion ;
      private GXCheckbox chkTicketTecnicoInternetRouter ;
      private GXCheckbox chkTicketTecnicoFormateo ;
      private GXCheckbox chkTicketTecnicoReparacion ;
      private GXCheckbox chkTicketTecnicoRam ;
      private IDataStoreProvider pr_default ;
      private bool[] H000G2_A83TicketTecnicoRam ;
      private bool[] H000G2_A84TicketTecnicoReparacion ;
      private bool[] H000G2_A70TicketTecnicoFormateo ;
      private bool[] H000G2_A73TicketTecnicoInternetRouter ;
      private bool[] H000G2_A66TicketTecnicoConfiguracion ;
      private bool[] H000G2_A72TicketTecnicoInstalacion ;
      private long[] H000G2_A16TicketResponsableId ;
      private long[] H000G2_A14TicketId ;
      private DateTime[] H000G2_A71TicketTecnicoHora ;
      private DateTime[] H000G2_A69TicketTecnicoFecha ;
      private long[] H000G2_A18TicketTecnicoId ;
      private long[] H000G3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTicketTecnicoId ;
      private GXWebForm Form ;
   }

   public class gx0090__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000G2( IGxContext context ,
                                             DateTime AV7cTicketTecnicoFecha ,
                                             DateTime AV8cTicketTecnicoHora ,
                                             long AV9cTicketId ,
                                             long AV10cTicketResponsableId ,
                                             bool AV11cTicketTecnicoInstalacion ,
                                             bool AV12cTicketTecnicoConfiguracion ,
                                             DateTime A69TicketTecnicoFecha ,
                                             DateTime A71TicketTecnicoHora ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             bool A72TicketTecnicoInstalacion ,
                                             bool A66TicketTecnicoConfiguracion ,
                                             long AV6cTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TicketTecnicoRam], [TicketTecnicoReparacion], [TicketTecnicoFormateo], [TicketTecnicoInternetRouter], [TicketTecnicoConfiguracion], [TicketTecnicoInstalacion], [TicketResponsableId], [TicketId], [TicketTecnicoHora], [TicketTecnicoFecha], [TicketTecnicoId]";
         sFromString = " FROM [TicketTecnico]";
         sOrderString = "";
         AddWhere(sWhereString, "([TicketTecnicoId] >= @AV6cTicketTecnicoId)");
         if ( ! (DateTime.MinValue==AV7cTicketTecnicoFecha) )
         {
            AddWhere(sWhereString, "([TicketTecnicoFecha] >= @AV7cTicketTecnicoFecha)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTicketTecnicoHora) )
         {
            AddWhere(sWhereString, "([TicketTecnicoHora] >= @AV8cTicketTecnicoHora)");
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
         if ( ! (0==AV10cTicketResponsableId) )
         {
            AddWhere(sWhereString, "([TicketResponsableId] >= @AV10cTicketResponsableId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV11cTicketTecnicoInstalacion) )
         {
            AddWhere(sWhereString, "([TicketTecnicoInstalacion] >= @AV11cTicketTecnicoInstalacion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV12cTicketTecnicoConfiguracion) )
         {
            AddWhere(sWhereString, "([TicketTecnicoConfiguracion] >= @AV12cTicketTecnicoConfiguracion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [TicketTecnicoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000G3( IGxContext context ,
                                             DateTime AV7cTicketTecnicoFecha ,
                                             DateTime AV8cTicketTecnicoHora ,
                                             long AV9cTicketId ,
                                             long AV10cTicketResponsableId ,
                                             bool AV11cTicketTecnicoInstalacion ,
                                             bool AV12cTicketTecnicoConfiguracion ,
                                             DateTime A69TicketTecnicoFecha ,
                                             DateTime A71TicketTecnicoHora ,
                                             long A14TicketId ,
                                             long A16TicketResponsableId ,
                                             bool A72TicketTecnicoInstalacion ,
                                             bool A66TicketTecnicoConfiguracion ,
                                             long AV6cTicketTecnicoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [TicketTecnico]";
         AddWhere(sWhereString, "([TicketTecnicoId] >= @AV6cTicketTecnicoId)");
         if ( ! (DateTime.MinValue==AV7cTicketTecnicoFecha) )
         {
            AddWhere(sWhereString, "([TicketTecnicoFecha] >= @AV7cTicketTecnicoFecha)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTicketTecnicoHora) )
         {
            AddWhere(sWhereString, "([TicketTecnicoHora] >= @AV8cTicketTecnicoHora)");
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
         if ( ! (0==AV10cTicketResponsableId) )
         {
            AddWhere(sWhereString, "([TicketResponsableId] >= @AV10cTicketResponsableId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV11cTicketTecnicoInstalacion) )
         {
            AddWhere(sWhereString, "([TicketTecnicoInstalacion] >= @AV11cTicketTecnicoInstalacion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV12cTicketTecnicoConfiguracion) )
         {
            AddWhere(sWhereString, "([TicketTecnicoConfiguracion] >= @AV12cTicketTecnicoConfiguracion)");
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
                     return conditional_H000G2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H000G3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH000G2;
          prmH000G2 = new Object[] {
          new ParDef("@AV6cTicketTecnicoId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cTicketTecnicoFecha",GXType.Date,8,0) ,
          new ParDef("@AV8cTicketTecnicoHora",GXType.DateTime,0,5) ,
          new ParDef("@AV9cTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV10cTicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV11cTicketTecnicoInstalacion",GXType.Boolean,4,0) ,
          new ParDef("@AV12cTicketTecnicoConfiguracion",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000G3;
          prmH000G3 = new Object[] {
          new ParDef("@AV6cTicketTecnicoId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cTicketTecnicoFecha",GXType.Date,8,0) ,
          new ParDef("@AV8cTicketTecnicoHora",GXType.DateTime,0,5) ,
          new ParDef("@AV9cTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV10cTicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV11cTicketTecnicoInstalacion",GXType.Boolean,4,0) ,
          new ParDef("@AV12cTicketTecnicoConfiguracion",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
