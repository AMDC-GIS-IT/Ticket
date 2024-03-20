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
   public class gx0070 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0070( )
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

      public gx0070( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pTicketId )
      {
         this.AV13pTicketId = 0 ;
         executePrivate();
         aP0_pTicketId=this.AV13pTicketId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCticketlaptop = new GXCheckbox();
         chkavCticketdesktop = new GXCheckbox();
         chkTicketLaptop = new GXCheckbox();
         chkTicketDesktop = new GXCheckbox();
         chkTicketMonitor = new GXCheckbox();
         chkTicketImpresora = new GXCheckbox();
         chkTicketEscaner = new GXCheckbox();
         chkTicketRouter = new GXCheckbox();
         chkTicketUps = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pTicketId");
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
               gxfirstwebparm = GetFirstPar( "pTicketId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pTicketId");
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
               AV6cTicketId = (long)(NumberUtil.Val( GetPar( "cTicketId"), "."));
               AV7cTicketFecha = context.localUtil.ParseDateParm( GetPar( "cTicketFecha"));
               AV8cTicketHora = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "cTicketHora")));
               AV9cUsuarioId = (long)(NumberUtil.Val( GetPar( "cUsuarioId"), "."));
               AV10cTicketLastId = (long)(NumberUtil.Val( GetPar( "cTicketLastId"), "."));
               AV11cTicketLaptop = StringUtil.StrToBool( GetPar( "cTicketLaptop"));
               AV12cTicketDesktop = StringUtil.StrToBool( GetPar( "cTicketDesktop"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop) ;
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
               AV13pTicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pTicketId", StringUtil.LTrimStr( (decimal)(AV13pTicketId), 10, 0));
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
            return "gx0070_Execute" ;
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
         PA0D2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0D2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188434177", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0070.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pTicketId,10,0))}, new string[] {"pTicketId"}) +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETFECHA", context.localUtil.Format(AV7cTicketFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETHORA", context.localUtil.TToC( AV8cTicketHora, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cUsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETLASTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTicketLastId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETLAPTOP", StringUtil.BoolToStr( AV11cTicketLaptop));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETDESKTOP", StringUtil.BoolToStr( AV12cTicketDesktop));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pTicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TICKETIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divTicketfechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETHORAFILTERCONTAINER_Class", StringUtil.RTrim( divTickethorafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarioidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETLASTIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketlastidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETLAPTOPFILTERCONTAINER_Class", StringUtil.RTrim( divTicketlaptopfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETDESKTOPFILTERCONTAINER_Class", StringUtil.RTrim( divTicketdesktopfiltercontainer_Class));
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
            WE0D2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0D2( ) ;
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
         return formatLink("gx0070.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pTicketId,10,0))}, new string[] {"pTicketId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0070" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Ticket" ;
      }

      protected void WB0D0( )
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
            GxWebStd.gx_div_start( context, divTicketidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketidfilter_Internalname, "Id Ticket", "", "", lblLblticketidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCticketid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTicketId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCticketid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cTicketId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cTicketId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCticketid_Visible, edtavCticketid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divTicketfechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketfechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketfechafilter_Internalname, "Ticket Fecha", "", "", lblLblticketfechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120d1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCticketfecha_Internalname, "Ticket Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCticketfecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCticketfecha_Internalname, context.localUtil.Format(AV7cTicketFecha, "99/99/9999"), context.localUtil.Format( AV7cTicketFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketfecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCticketfecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divTickethorafiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickethorafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickethorafilter_Internalname, "Ticket Hora", "", "", lblLbltickethorafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130d1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtickethora_Internalname, "Ticket Hora", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtickethora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtickethora_Internalname, context.localUtil.TToC( AV8cTicketHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV8cTicketHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtickethora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtickethora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divUsuarioidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarioidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarioidfilter_Internalname, "Id Usuario", "", "", lblLblusuarioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuarioid_Internalname, "Id Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cUsuarioId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCusuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV9cUsuarioId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV9cUsuarioId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarioid_Visible, edtavCusuarioid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divTicketlastidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketlastidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketlastidfilter_Internalname, "Ticket Last Id", "", "", lblLblticketlastidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCticketlastid_Internalname, "Ticket Last Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCticketlastid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cTicketLastId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCticketlastid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cTicketLastId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV10cTicketLastId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketlastid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCticketlastid_Visible, edtavCticketlastid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0070.htm");
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
            GxWebStd.gx_div_start( context, divTicketlaptopfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketlaptopfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketlaptopfilter_Internalname, "aptop", "", "", lblLblticketlaptopfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCticketlaptop_Internalname, "aptop", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCticketlaptop_Internalname, StringUtil.BoolToStr( AV11cTicketLaptop), "", "aptop", chkavCticketlaptop.Visible, chkavCticketlaptop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            GxWebStd.gx_div_start( context, divTicketdesktopfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketdesktopfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketdesktopfilter_Internalname, "Desktop", "", "", lblLblticketdesktopfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170d1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0070.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCticketdesktop_Internalname, "Desktop", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCticketdesktop_Internalname, StringUtil.BoolToStr( AV12cTicketDesktop), "", "Desktop", chkavCticketdesktop.Visible, chkavCticketdesktop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(76, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,76);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180d1_client"+"'", TempTags, "", 2, "HLP_Gx0070.htm");
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
               context.SendWebValue( "RST No.") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id Usuario") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Last Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "aptop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Desktop") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Monitor") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Impresora") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Escaner") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Internet/Router/Access Point") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "UPS") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtTicketFecha_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A53TicketLaptop));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A42TicketDesktop));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A55TicketMonitor));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A50TicketImpresora));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A45TicketEscaner));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A59TicketRouter));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A87TicketUps));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0070.htm");
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

      protected void START0D2( )
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
            Form.Meta.addItem("description", "Selection List Ticket", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0D0( ) ;
      }

      protected void WS0D2( )
      {
         START0D2( ) ;
         EVT0D2( ) ;
      }

      protected void EVT0D2( )
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
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                              A46TicketFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketFecha_Internalname), 0));
                              A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHora_Internalname), 0));
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A54TicketLastId = (long)(context.localUtil.CToN( cgiGet( edtTicketLastId_Internalname), ".", ","));
                              A53TicketLaptop = StringUtil.StrToBool( cgiGet( chkTicketLaptop_Internalname));
                              n53TicketLaptop = false;
                              A42TicketDesktop = StringUtil.StrToBool( cgiGet( chkTicketDesktop_Internalname));
                              n42TicketDesktop = false;
                              A55TicketMonitor = StringUtil.StrToBool( cgiGet( chkTicketMonitor_Internalname));
                              n55TicketMonitor = false;
                              A50TicketImpresora = StringUtil.StrToBool( cgiGet( chkTicketImpresora_Internalname));
                              n50TicketImpresora = false;
                              A45TicketEscaner = StringUtil.StrToBool( cgiGet( chkTicketEscaner_Internalname));
                              n45TicketEscaner = false;
                              A59TicketRouter = StringUtil.StrToBool( cgiGet( chkTicketRouter_Internalname));
                              n59TicketRouter = false;
                              A87TicketUps = StringUtil.StrToBool( cgiGet( chkTicketUps_Internalname));
                              n87TicketUps = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200D2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cticketid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETID"), ".", ",") != Convert.ToDecimal( AV6cTicketId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketfecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETFECHA"), 0) != AV7cTicketFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctickethora Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETHORA"), 0) != AV8cTicketHora )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuarioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOID"), ".", ",") != Convert.ToDecimal( AV9cUsuarioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketlastid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETLASTID"), ".", ",") != Convert.ToDecimal( AV10cTicketLastId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketlaptop Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETLAPTOP")) != AV11cTicketLaptop )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketdesktop Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETDESKTOP")) != AV12cTicketDesktop )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210D2 ();
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

      protected void WE0D2( )
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

      protected void PA0D2( )
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
                                        long AV6cTicketId ,
                                        DateTime AV7cTicketFecha ,
                                        DateTime AV8cTicketHora ,
                                        long AV9cUsuarioId ,
                                        long AV10cTicketLastId ,
                                        bool AV11cTicketLaptop ,
                                        bool AV12cTicketDesktop )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0D2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
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
         AV11cTicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cTicketLaptop));
         AssignAttri("", false, "AV11cTicketLaptop", AV11cTicketLaptop);
         AV12cTicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cTicketDesktop));
         AssignAttri("", false, "AV12cTicketDesktop", AV12cTicketDesktop);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0D2( ) ;
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

      protected void RF0D2( )
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
                                                 AV7cTicketFecha ,
                                                 AV8cTicketHora ,
                                                 AV9cUsuarioId ,
                                                 AV10cTicketLastId ,
                                                 AV11cTicketLaptop ,
                                                 AV12cTicketDesktop ,
                                                 A46TicketFecha ,
                                                 A48TicketHora ,
                                                 A15UsuarioId ,
                                                 A54TicketLastId ,
                                                 A53TicketLaptop ,
                                                 A42TicketDesktop ,
                                                 AV6cTicketId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H000D2 */
            pr_default.execute(0, new Object[] {AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A87TicketUps = H000D2_A87TicketUps[0];
               n87TicketUps = H000D2_n87TicketUps[0];
               A59TicketRouter = H000D2_A59TicketRouter[0];
               n59TicketRouter = H000D2_n59TicketRouter[0];
               A45TicketEscaner = H000D2_A45TicketEscaner[0];
               n45TicketEscaner = H000D2_n45TicketEscaner[0];
               A50TicketImpresora = H000D2_A50TicketImpresora[0];
               n50TicketImpresora = H000D2_n50TicketImpresora[0];
               A55TicketMonitor = H000D2_A55TicketMonitor[0];
               n55TicketMonitor = H000D2_n55TicketMonitor[0];
               A42TicketDesktop = H000D2_A42TicketDesktop[0];
               n42TicketDesktop = H000D2_n42TicketDesktop[0];
               A53TicketLaptop = H000D2_A53TicketLaptop[0];
               n53TicketLaptop = H000D2_n53TicketLaptop[0];
               A54TicketLastId = H000D2_A54TicketLastId[0];
               A15UsuarioId = H000D2_A15UsuarioId[0];
               A48TicketHora = H000D2_A48TicketHora[0];
               A46TicketFecha = H000D2_A46TicketFecha[0];
               A14TicketId = H000D2_A14TicketId[0];
               /* Execute user event: Load */
               E200D2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0D0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0D2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"), context));
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
                                              AV7cTicketFecha ,
                                              AV8cTicketHora ,
                                              AV9cUsuarioId ,
                                              AV10cTicketLastId ,
                                              AV11cTicketLaptop ,
                                              AV12cTicketDesktop ,
                                              A46TicketFecha ,
                                              A48TicketHora ,
                                              A15UsuarioId ,
                                              A54TicketLastId ,
                                              A53TicketLaptop ,
                                              A42TicketDesktop ,
                                              AV6cTicketId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         /* Using cursor H000D3 */
         pr_default.execute(1, new Object[] {AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop});
         GRID1_nRecordCount = H000D3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketId, AV7cTicketFecha, AV8cTicketHora, AV9cUsuarioId, AV10cTicketLastId, AV11cTicketLaptop, AV12cTicketDesktop) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0D0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190D2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCticketid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCticketid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTICKETID");
               GX_FocusControl = edtavCticketid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTicketId = 0;
               AssignAttri("", false, "AV6cTicketId", StringUtil.LTrimStr( (decimal)(AV6cTicketId), 10, 0));
            }
            else
            {
               AV6cTicketId = (long)(context.localUtil.CToN( cgiGet( edtavCticketid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cTicketId", StringUtil.LTrimStr( (decimal)(AV6cTicketId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCticketfecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ticket Fecha"}), 1, "vCTICKETFECHA");
               GX_FocusControl = edtavCticketfecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cTicketFecha = DateTime.MinValue;
               AssignAttri("", false, "AV7cTicketFecha", context.localUtil.Format(AV7cTicketFecha, "99/99/9999"));
            }
            else
            {
               AV7cTicketFecha = context.localUtil.CToD( cgiGet( edtavCticketfecha_Internalname), 2);
               AssignAttri("", false, "AV7cTicketFecha", context.localUtil.Format(AV7cTicketFecha, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtickethora_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Hora"}), 1, "vCTICKETHORA");
               GX_FocusControl = edtavCtickethora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cTicketHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV8cTicketHora", context.localUtil.TToC( AV8cTicketHora, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV8cTicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavCtickethora_Internalname)));
               AssignAttri("", false, "AV8cTicketHora", context.localUtil.TToC( AV8cTicketHora, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuarioid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuarioid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOID");
               GX_FocusControl = edtavCusuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cUsuarioId = 0;
               AssignAttri("", false, "AV9cUsuarioId", StringUtil.LTrimStr( (decimal)(AV9cUsuarioId), 10, 0));
            }
            else
            {
               AV9cUsuarioId = (long)(context.localUtil.CToN( cgiGet( edtavCusuarioid_Internalname), ".", ","));
               AssignAttri("", false, "AV9cUsuarioId", StringUtil.LTrimStr( (decimal)(AV9cUsuarioId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCticketlastid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCticketlastid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTICKETLASTID");
               GX_FocusControl = edtavCticketlastid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cTicketLastId = 0;
               AssignAttri("", false, "AV10cTicketLastId", StringUtil.LTrimStr( (decimal)(AV10cTicketLastId), 10, 0));
            }
            else
            {
               AV10cTicketLastId = (long)(context.localUtil.CToN( cgiGet( edtavCticketlastid_Internalname), ".", ","));
               AssignAttri("", false, "AV10cTicketLastId", StringUtil.LTrimStr( (decimal)(AV10cTicketLastId), 10, 0));
            }
            AV11cTicketLaptop = StringUtil.StrToBool( cgiGet( chkavCticketlaptop_Internalname));
            AssignAttri("", false, "AV11cTicketLaptop", AV11cTicketLaptop);
            AV12cTicketDesktop = StringUtil.StrToBool( cgiGet( chkavCticketdesktop_Internalname));
            AssignAttri("", false, "AV12cTicketDesktop", AV12cTicketDesktop);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETID"), ".", ",") != Convert.ToDecimal( AV6cTicketId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCTICKETFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV7cTicketFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETHORA")) != AV8cTicketHora )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOID"), ".", ",") != Convert.ToDecimal( AV9cUsuarioId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETLASTID"), ".", ",") != Convert.ToDecimal( AV10cTicketLastId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETLAPTOP")) != AV11cTicketLaptop )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETDESKTOP")) != AV12cTicketDesktop )
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
         E190D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190D2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Ticket", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200D2( )
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
         E210D2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210D2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pTicketId = A14TicketId;
         AssignAttri("", false, "AV13pTicketId", StringUtil.LTrimStr( (decimal)(AV13pTicketId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pTicketId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pTicketId"});
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
         AV13pTicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pTicketId", StringUtil.LTrimStr( (decimal)(AV13pTicketId), 10, 0));
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
         PA0D2( ) ;
         WS0D2( ) ;
         WE0D2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188434285", true, true);
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
         context.AddJavascriptSource("gx0070.js", "?2024188434285", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_84_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_84_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_84_idx;
         edtTicketLastId_Internalname = "TICKETLASTID_"+sGXsfl_84_idx;
         chkTicketLaptop_Internalname = "TICKETLAPTOP_"+sGXsfl_84_idx;
         chkTicketDesktop_Internalname = "TICKETDESKTOP_"+sGXsfl_84_idx;
         chkTicketMonitor_Internalname = "TICKETMONITOR_"+sGXsfl_84_idx;
         chkTicketImpresora_Internalname = "TICKETIMPRESORA_"+sGXsfl_84_idx;
         chkTicketEscaner_Internalname = "TICKETESCANER_"+sGXsfl_84_idx;
         chkTicketRouter_Internalname = "TICKETROUTER_"+sGXsfl_84_idx;
         chkTicketUps_Internalname = "TICKETUPS_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_84_fel_idx;
         edtTicketFecha_Internalname = "TICKETFECHA_"+sGXsfl_84_fel_idx;
         edtTicketHora_Internalname = "TICKETHORA_"+sGXsfl_84_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_84_fel_idx;
         edtTicketLastId_Internalname = "TICKETLASTID_"+sGXsfl_84_fel_idx;
         chkTicketLaptop_Internalname = "TICKETLAPTOP_"+sGXsfl_84_fel_idx;
         chkTicketDesktop_Internalname = "TICKETDESKTOP_"+sGXsfl_84_fel_idx;
         chkTicketMonitor_Internalname = "TICKETMONITOR_"+sGXsfl_84_fel_idx;
         chkTicketImpresora_Internalname = "TICKETIMPRESORA_"+sGXsfl_84_fel_idx;
         chkTicketEscaner_Internalname = "TICKETESCANER_"+sGXsfl_84_fel_idx;
         chkTicketRouter_Internalname = "TICKETROUTER_"+sGXsfl_84_fel_idx;
         chkTicketUps_Internalname = "TICKETUPS_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0D0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtTicketFecha_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtTicketFecha_Internalname, "Link", edtTicketFecha_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFecha_Internalname,context.localUtil.Format(A46TicketFecha, "99/99/9999"),context.localUtil.Format( A46TicketFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTicketFecha_Link,(string)"",(string)"",(string)"",(string)edtTicketFecha_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHora_Internalname,context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A48TicketHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketLastId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketLastId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETLAPTOP_" + sGXsfl_84_idx;
            chkTicketLaptop.Name = GXCCtl;
            chkTicketLaptop.WebTags = "";
            chkTicketLaptop.Caption = "";
            AssignProp("", false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_84_Refreshing);
            chkTicketLaptop.CheckedValue = "false";
            A53TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A53TicketLaptop));
            n53TicketLaptop = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketLaptop_Internalname,StringUtil.BoolToStr( A53TicketLaptop),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETDESKTOP_" + sGXsfl_84_idx;
            chkTicketDesktop.Name = GXCCtl;
            chkTicketDesktop.WebTags = "";
            chkTicketDesktop.Caption = "";
            AssignProp("", false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_84_Refreshing);
            chkTicketDesktop.CheckedValue = "false";
            A42TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( A42TicketDesktop));
            n42TicketDesktop = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketDesktop_Internalname,StringUtil.BoolToStr( A42TicketDesktop),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETMONITOR_" + sGXsfl_84_idx;
            chkTicketMonitor.Name = GXCCtl;
            chkTicketMonitor.WebTags = "";
            chkTicketMonitor.Caption = "";
            AssignProp("", false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_84_Refreshing);
            chkTicketMonitor.CheckedValue = "false";
            A55TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( A55TicketMonitor));
            n55TicketMonitor = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketMonitor_Internalname,StringUtil.BoolToStr( A55TicketMonitor),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETIMPRESORA_" + sGXsfl_84_idx;
            chkTicketImpresora.Name = GXCCtl;
            chkTicketImpresora.WebTags = "";
            chkTicketImpresora.Caption = "";
            AssignProp("", false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_84_Refreshing);
            chkTicketImpresora.CheckedValue = "false";
            A50TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( A50TicketImpresora));
            n50TicketImpresora = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketImpresora_Internalname,StringUtil.BoolToStr( A50TicketImpresora),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETESCANER_" + sGXsfl_84_idx;
            chkTicketEscaner.Name = GXCCtl;
            chkTicketEscaner.WebTags = "";
            chkTicketEscaner.Caption = "";
            AssignProp("", false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_84_Refreshing);
            chkTicketEscaner.CheckedValue = "false";
            A45TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( A45TicketEscaner));
            n45TicketEscaner = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketEscaner_Internalname,StringUtil.BoolToStr( A45TicketEscaner),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETROUTER_" + sGXsfl_84_idx;
            chkTicketRouter.Name = GXCCtl;
            chkTicketRouter.WebTags = "";
            chkTicketRouter.Caption = "";
            AssignProp("", false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_84_Refreshing);
            chkTicketRouter.CheckedValue = "false";
            A59TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A59TicketRouter));
            n59TicketRouter = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketRouter_Internalname,StringUtil.BoolToStr( A59TicketRouter),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETUPS_" + sGXsfl_84_idx;
            chkTicketUps.Name = GXCCtl;
            chkTicketUps.WebTags = "";
            chkTicketUps.Caption = "";
            AssignProp("", false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_84_Refreshing);
            chkTicketUps.CheckedValue = "false";
            A87TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( A87TicketUps));
            n87TicketUps = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketUps_Internalname,StringUtil.BoolToStr( A87TicketUps),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            send_integrity_lvl_hashes0D2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCticketlaptop.Name = "vCTICKETLAPTOP";
         chkavCticketlaptop.WebTags = "";
         chkavCticketlaptop.Caption = "";
         AssignProp("", false, chkavCticketlaptop_Internalname, "TitleCaption", chkavCticketlaptop.Caption, true);
         chkavCticketlaptop.CheckedValue = "false";
         AV11cTicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( AV11cTicketLaptop));
         AssignAttri("", false, "AV11cTicketLaptop", AV11cTicketLaptop);
         chkavCticketdesktop.Name = "vCTICKETDESKTOP";
         chkavCticketdesktop.WebTags = "";
         chkavCticketdesktop.Caption = "";
         AssignProp("", false, chkavCticketdesktop_Internalname, "TitleCaption", chkavCticketdesktop.Caption, true);
         chkavCticketdesktop.CheckedValue = "false";
         AV12cTicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( AV12cTicketDesktop));
         AssignAttri("", false, "AV12cTicketDesktop", AV12cTicketDesktop);
         GXCCtl = "TICKETLAPTOP_" + sGXsfl_84_idx;
         chkTicketLaptop.Name = GXCCtl;
         chkTicketLaptop.WebTags = "";
         chkTicketLaptop.Caption = "";
         AssignProp("", false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, !bGXsfl_84_Refreshing);
         chkTicketLaptop.CheckedValue = "false";
         A53TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A53TicketLaptop));
         n53TicketLaptop = false;
         GXCCtl = "TICKETDESKTOP_" + sGXsfl_84_idx;
         chkTicketDesktop.Name = GXCCtl;
         chkTicketDesktop.WebTags = "";
         chkTicketDesktop.Caption = "";
         AssignProp("", false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, !bGXsfl_84_Refreshing);
         chkTicketDesktop.CheckedValue = "false";
         A42TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( A42TicketDesktop));
         n42TicketDesktop = false;
         GXCCtl = "TICKETMONITOR_" + sGXsfl_84_idx;
         chkTicketMonitor.Name = GXCCtl;
         chkTicketMonitor.WebTags = "";
         chkTicketMonitor.Caption = "";
         AssignProp("", false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, !bGXsfl_84_Refreshing);
         chkTicketMonitor.CheckedValue = "false";
         A55TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( A55TicketMonitor));
         n55TicketMonitor = false;
         GXCCtl = "TICKETIMPRESORA_" + sGXsfl_84_idx;
         chkTicketImpresora.Name = GXCCtl;
         chkTicketImpresora.WebTags = "";
         chkTicketImpresora.Caption = "";
         AssignProp("", false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, !bGXsfl_84_Refreshing);
         chkTicketImpresora.CheckedValue = "false";
         A50TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( A50TicketImpresora));
         n50TicketImpresora = false;
         GXCCtl = "TICKETESCANER_" + sGXsfl_84_idx;
         chkTicketEscaner.Name = GXCCtl;
         chkTicketEscaner.WebTags = "";
         chkTicketEscaner.Caption = "";
         AssignProp("", false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, !bGXsfl_84_Refreshing);
         chkTicketEscaner.CheckedValue = "false";
         A45TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( A45TicketEscaner));
         n45TicketEscaner = false;
         GXCCtl = "TICKETROUTER_" + sGXsfl_84_idx;
         chkTicketRouter.Name = GXCCtl;
         chkTicketRouter.WebTags = "";
         chkTicketRouter.Caption = "";
         AssignProp("", false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, !bGXsfl_84_Refreshing);
         chkTicketRouter.CheckedValue = "false";
         A59TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A59TicketRouter));
         n59TicketRouter = false;
         GXCCtl = "TICKETUPS_" + sGXsfl_84_idx;
         chkTicketUps.Name = GXCCtl;
         chkTicketUps.WebTags = "";
         chkTicketUps.Caption = "";
         AssignProp("", false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, !bGXsfl_84_Refreshing);
         chkTicketUps.CheckedValue = "false";
         A87TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( A87TicketUps));
         n87TicketUps = false;
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblticketidfilter_Internalname = "LBLTICKETIDFILTER";
         edtavCticketid_Internalname = "vCTICKETID";
         divTicketidfiltercontainer_Internalname = "TICKETIDFILTERCONTAINER";
         lblLblticketfechafilter_Internalname = "LBLTICKETFECHAFILTER";
         edtavCticketfecha_Internalname = "vCTICKETFECHA";
         divTicketfechafiltercontainer_Internalname = "TICKETFECHAFILTERCONTAINER";
         lblLbltickethorafilter_Internalname = "LBLTICKETHORAFILTER";
         edtavCtickethora_Internalname = "vCTICKETHORA";
         divTickethorafiltercontainer_Internalname = "TICKETHORAFILTERCONTAINER";
         lblLblusuarioidfilter_Internalname = "LBLUSUARIOIDFILTER";
         edtavCusuarioid_Internalname = "vCUSUARIOID";
         divUsuarioidfiltercontainer_Internalname = "USUARIOIDFILTERCONTAINER";
         lblLblticketlastidfilter_Internalname = "LBLTICKETLASTIDFILTER";
         edtavCticketlastid_Internalname = "vCTICKETLASTID";
         divTicketlastidfiltercontainer_Internalname = "TICKETLASTIDFILTERCONTAINER";
         lblLblticketlaptopfilter_Internalname = "LBLTICKETLAPTOPFILTER";
         chkavCticketlaptop_Internalname = "vCTICKETLAPTOP";
         divTicketlaptopfiltercontainer_Internalname = "TICKETLAPTOPFILTERCONTAINER";
         lblLblticketdesktopfilter_Internalname = "LBLTICKETDESKTOPFILTER";
         chkavCticketdesktop_Internalname = "vCTICKETDESKTOP";
         divTicketdesktopfiltercontainer_Internalname = "TICKETDESKTOPFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTicketId_Internalname = "TICKETID";
         edtTicketFecha_Internalname = "TICKETFECHA";
         edtTicketHora_Internalname = "TICKETHORA";
         edtUsuarioId_Internalname = "USUARIOID";
         edtTicketLastId_Internalname = "TICKETLASTID";
         chkTicketLaptop_Internalname = "TICKETLAPTOP";
         chkTicketDesktop_Internalname = "TICKETDESKTOP";
         chkTicketMonitor_Internalname = "TICKETMONITOR";
         chkTicketImpresora_Internalname = "TICKETIMPRESORA";
         chkTicketEscaner_Internalname = "TICKETESCANER";
         chkTicketRouter_Internalname = "TICKETROUTER";
         chkTicketUps_Internalname = "TICKETUPS";
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
         chkavCticketdesktop.Caption = "Desktop";
         chkavCticketlaptop.Caption = "aptop";
         chkTicketUps.Caption = "";
         chkTicketRouter.Caption = "";
         chkTicketEscaner.Caption = "";
         chkTicketImpresora.Caption = "";
         chkTicketMonitor.Caption = "";
         chkTicketDesktop.Caption = "";
         chkTicketLaptop.Caption = "";
         edtTicketLastId_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         edtTicketHora_Jsonclick = "";
         edtTicketFecha_Jsonclick = "";
         edtTicketId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtTicketFecha_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkavCticketdesktop.Enabled = 1;
         chkavCticketdesktop.Visible = 1;
         chkavCticketlaptop.Enabled = 1;
         chkavCticketlaptop.Visible = 1;
         edtavCticketlastid_Jsonclick = "";
         edtavCticketlastid_Enabled = 1;
         edtavCticketlastid_Visible = 1;
         edtavCusuarioid_Jsonclick = "";
         edtavCusuarioid_Enabled = 1;
         edtavCusuarioid_Visible = 1;
         edtavCtickethora_Jsonclick = "";
         edtavCtickethora_Enabled = 1;
         edtavCticketfecha_Jsonclick = "";
         edtavCticketfecha_Enabled = 1;
         edtavCticketid_Jsonclick = "";
         edtavCticketid_Enabled = 1;
         edtavCticketid_Visible = 1;
         divTicketdesktopfiltercontainer_Class = "AdvancedContainerItem";
         divTicketlaptopfiltercontainer_Class = "AdvancedContainerItem";
         divTicketlastidfiltercontainer_Class = "AdvancedContainerItem";
         divUsuarioidfiltercontainer_Class = "AdvancedContainerItem";
         divTickethorafiltercontainer_Class = "AdvancedContainerItem";
         divTicketfechafiltercontainer_Class = "AdvancedContainerItem";
         divTicketidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Ticket";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketFecha',fld:'vCTICKETFECHA',pic:''},{av:'AV8cTicketHora',fld:'vCTICKETHORA',pic:'99:99'},{av:'AV9cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketLastId',fld:'vCTICKETLASTID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("'TOGGLE'","{handler:'E180D1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLTICKETIDFILTER.CLICK","{handler:'E110D1',iparms:[{av:'divTicketidfiltercontainer_Class',ctrl:'TICKETIDFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLTICKETIDFILTER.CLICK",",oparms:[{av:'divTicketidfiltercontainer_Class',ctrl:'TICKETIDFILTERCONTAINER',prop:'Class'},{av:'edtavCticketid_Visible',ctrl:'vCTICKETID',prop:'Visible'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLTICKETFECHAFILTER.CLICK","{handler:'E120D1',iparms:[{av:'divTicketfechafiltercontainer_Class',ctrl:'TICKETFECHAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLTICKETFECHAFILTER.CLICK",",oparms:[{av:'divTicketfechafiltercontainer_Class',ctrl:'TICKETFECHAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLTICKETHORAFILTER.CLICK","{handler:'E130D1',iparms:[{av:'divTickethorafiltercontainer_Class',ctrl:'TICKETHORAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLTICKETHORAFILTER.CLICK",",oparms:[{av:'divTickethorafiltercontainer_Class',ctrl:'TICKETHORAFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLUSUARIOIDFILTER.CLICK","{handler:'E140D1',iparms:[{av:'divUsuarioidfiltercontainer_Class',ctrl:'USUARIOIDFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLUSUARIOIDFILTER.CLICK",",oparms:[{av:'divUsuarioidfiltercontainer_Class',ctrl:'USUARIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarioid_Visible',ctrl:'vCUSUARIOID',prop:'Visible'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLTICKETLASTIDFILTER.CLICK","{handler:'E150D1',iparms:[{av:'divTicketlastidfiltercontainer_Class',ctrl:'TICKETLASTIDFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLTICKETLASTIDFILTER.CLICK",",oparms:[{av:'divTicketlastidfiltercontainer_Class',ctrl:'TICKETLASTIDFILTERCONTAINER',prop:'Class'},{av:'edtavCticketlastid_Visible',ctrl:'vCTICKETLASTID',prop:'Visible'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLTICKETLAPTOPFILTER.CLICK","{handler:'E160D1',iparms:[{av:'divTicketlaptopfiltercontainer_Class',ctrl:'TICKETLAPTOPFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLTICKETLAPTOPFILTER.CLICK",",oparms:[{av:'divTicketlaptopfiltercontainer_Class',ctrl:'TICKETLAPTOPFILTERCONTAINER',prop:'Class'},{av:'chkavCticketlaptop.Visible',ctrl:'vCTICKETLAPTOP',prop:'Visible'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("LBLTICKETDESKTOPFILTER.CLICK","{handler:'E170D1',iparms:[{av:'divTicketdesktopfiltercontainer_Class',ctrl:'TICKETDESKTOPFILTERCONTAINER',prop:'Class'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("LBLTICKETDESKTOPFILTER.CLICK",",oparms:[{av:'divTicketdesktopfiltercontainer_Class',ctrl:'TICKETDESKTOPFILTERCONTAINER',prop:'Class'},{av:'chkavCticketdesktop.Visible',ctrl:'vCTICKETDESKTOP',prop:'Visible'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E210D2',iparms:[{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pTicketId',fld:'vPTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketFecha',fld:'vCTICKETFECHA',pic:''},{av:'AV8cTicketHora',fld:'vCTICKETHORA',pic:'99:99'},{av:'AV9cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketLastId',fld:'vCTICKETLASTID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketFecha',fld:'vCTICKETFECHA',pic:''},{av:'AV8cTicketHora',fld:'vCTICKETHORA',pic:'99:99'},{av:'AV9cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketLastId',fld:'vCTICKETLASTID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketFecha',fld:'vCTICKETFECHA',pic:''},{av:'AV8cTicketHora',fld:'vCTICKETHORA',pic:'99:99'},{av:'AV9cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketLastId',fld:'vCTICKETLASTID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketId',fld:'vCTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV7cTicketFecha',fld:'vCTICKETFECHA',pic:''},{av:'AV8cTicketHora',fld:'vCTICKETHORA',pic:'99:99'},{av:'AV9cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV10cTicketLastId',fld:'vCTICKETLASTID',pic:'ZZZZZZZZZ9'},{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("VALIDV_CTICKETFECHA","{handler:'Validv_Cticketfecha',iparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("VALIDV_CTICKETFECHA",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Ticketups',iparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV11cTicketLaptop',fld:'vCTICKETLAPTOP',pic:''},{av:'AV12cTicketDesktop',fld:'vCTICKETDESKTOP',pic:''}]}");
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
         AV7cTicketFecha = DateTime.MinValue;
         AV8cTicketHora = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblticketidfilter_Jsonclick = "";
         TempTags = "";
         lblLblticketfechafilter_Jsonclick = "";
         lblLbltickethorafilter_Jsonclick = "";
         lblLblusuarioidfilter_Jsonclick = "";
         lblLblticketlastidfilter_Jsonclick = "";
         lblLblticketlaptopfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblticketdesktopfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         H000D2_A87TicketUps = new bool[] {false} ;
         H000D2_n87TicketUps = new bool[] {false} ;
         H000D2_A59TicketRouter = new bool[] {false} ;
         H000D2_n59TicketRouter = new bool[] {false} ;
         H000D2_A45TicketEscaner = new bool[] {false} ;
         H000D2_n45TicketEscaner = new bool[] {false} ;
         H000D2_A50TicketImpresora = new bool[] {false} ;
         H000D2_n50TicketImpresora = new bool[] {false} ;
         H000D2_A55TicketMonitor = new bool[] {false} ;
         H000D2_n55TicketMonitor = new bool[] {false} ;
         H000D2_A42TicketDesktop = new bool[] {false} ;
         H000D2_n42TicketDesktop = new bool[] {false} ;
         H000D2_A53TicketLaptop = new bool[] {false} ;
         H000D2_n53TicketLaptop = new bool[] {false} ;
         H000D2_A54TicketLastId = new long[1] ;
         H000D2_A15UsuarioId = new long[1] ;
         H000D2_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         H000D2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         H000D2_A14TicketId = new long[1] ;
         H000D3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0070__default(),
            new Object[][] {
                new Object[] {
               H000D2_A87TicketUps, H000D2_n87TicketUps, H000D2_A59TicketRouter, H000D2_n59TicketRouter, H000D2_A45TicketEscaner, H000D2_n45TicketEscaner, H000D2_A50TicketImpresora, H000D2_n50TicketImpresora, H000D2_A55TicketMonitor, H000D2_n55TicketMonitor,
               H000D2_A42TicketDesktop, H000D2_n42TicketDesktop, H000D2_A53TicketLaptop, H000D2_n53TicketLaptop, H000D2_A54TicketLastId, H000D2_A15UsuarioId, H000D2_A48TicketHora, H000D2_A46TicketFecha, H000D2_A14TicketId
               }
               , new Object[] {
               H000D3_AGRID1_nRecordCount
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
      private int edtavCticketid_Enabled ;
      private int edtavCticketid_Visible ;
      private int edtavCticketfecha_Enabled ;
      private int edtavCtickethora_Enabled ;
      private int edtavCusuarioid_Enabled ;
      private int edtavCusuarioid_Visible ;
      private int edtavCticketlastid_Enabled ;
      private int edtavCticketlastid_Visible ;
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
      private long AV13pTicketId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cTicketId ;
      private long AV9cUsuarioId ;
      private long AV10cTicketLastId ;
      private long A14TicketId ;
      private long A15UsuarioId ;
      private long A54TicketLastId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divTicketidfiltercontainer_Class ;
      private string divTicketfechafiltercontainer_Class ;
      private string divTickethorafiltercontainer_Class ;
      private string divUsuarioidfiltercontainer_Class ;
      private string divTicketlastidfiltercontainer_Class ;
      private string divTicketlaptopfiltercontainer_Class ;
      private string divTicketdesktopfiltercontainer_Class ;
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
      private string divTicketidfiltercontainer_Internalname ;
      private string lblLblticketidfilter_Internalname ;
      private string lblLblticketidfilter_Jsonclick ;
      private string edtavCticketid_Internalname ;
      private string TempTags ;
      private string edtavCticketid_Jsonclick ;
      private string divTicketfechafiltercontainer_Internalname ;
      private string lblLblticketfechafilter_Internalname ;
      private string lblLblticketfechafilter_Jsonclick ;
      private string edtavCticketfecha_Internalname ;
      private string edtavCticketfecha_Jsonclick ;
      private string divTickethorafiltercontainer_Internalname ;
      private string lblLbltickethorafilter_Internalname ;
      private string lblLbltickethorafilter_Jsonclick ;
      private string edtavCtickethora_Internalname ;
      private string edtavCtickethora_Jsonclick ;
      private string divUsuarioidfiltercontainer_Internalname ;
      private string lblLblusuarioidfilter_Internalname ;
      private string lblLblusuarioidfilter_Jsonclick ;
      private string edtavCusuarioid_Internalname ;
      private string edtavCusuarioid_Jsonclick ;
      private string divTicketlastidfiltercontainer_Internalname ;
      private string lblLblticketlastidfilter_Internalname ;
      private string lblLblticketlastidfilter_Jsonclick ;
      private string edtavCticketlastid_Internalname ;
      private string edtavCticketlastid_Jsonclick ;
      private string divTicketlaptopfiltercontainer_Internalname ;
      private string lblLblticketlaptopfilter_Internalname ;
      private string lblLblticketlaptopfilter_Jsonclick ;
      private string chkavCticketlaptop_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTicketdesktopfiltercontainer_Internalname ;
      private string lblLblticketdesktopfilter_Internalname ;
      private string lblLblticketdesktopfilter_Jsonclick ;
      private string chkavCticketdesktop_Internalname ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtTicketFecha_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketFecha_Internalname ;
      private string edtTicketHora_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtTicketLastId_Internalname ;
      private string chkTicketLaptop_Internalname ;
      private string chkTicketDesktop_Internalname ;
      private string chkTicketMonitor_Internalname ;
      private string chkTicketImpresora_Internalname ;
      private string chkTicketEscaner_Internalname ;
      private string chkTicketRouter_Internalname ;
      private string chkTicketUps_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtTicketId_Jsonclick ;
      private string edtTicketFecha_Jsonclick ;
      private string edtTicketHora_Jsonclick ;
      private string edtUsuarioId_Jsonclick ;
      private string edtTicketLastId_Jsonclick ;
      private string GXCCtl ;
      private DateTime AV8cTicketHora ;
      private DateTime A48TicketHora ;
      private DateTime AV7cTicketFecha ;
      private DateTime A46TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV11cTicketLaptop ;
      private bool AV12cTicketDesktop ;
      private bool wbLoad ;
      private bool A53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool A87TicketUps ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n53TicketLaptop ;
      private bool n42TicketDesktop ;
      private bool n55TicketMonitor ;
      private bool n50TicketImpresora ;
      private bool n45TicketEscaner ;
      private bool n59TicketRouter ;
      private bool n87TicketUps ;
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
      private GXCheckbox chkavCticketlaptop ;
      private GXCheckbox chkavCticketdesktop ;
      private GXCheckbox chkTicketLaptop ;
      private GXCheckbox chkTicketDesktop ;
      private GXCheckbox chkTicketMonitor ;
      private GXCheckbox chkTicketImpresora ;
      private GXCheckbox chkTicketEscaner ;
      private GXCheckbox chkTicketRouter ;
      private GXCheckbox chkTicketUps ;
      private IDataStoreProvider pr_default ;
      private bool[] H000D2_A87TicketUps ;
      private bool[] H000D2_n87TicketUps ;
      private bool[] H000D2_A59TicketRouter ;
      private bool[] H000D2_n59TicketRouter ;
      private bool[] H000D2_A45TicketEscaner ;
      private bool[] H000D2_n45TicketEscaner ;
      private bool[] H000D2_A50TicketImpresora ;
      private bool[] H000D2_n50TicketImpresora ;
      private bool[] H000D2_A55TicketMonitor ;
      private bool[] H000D2_n55TicketMonitor ;
      private bool[] H000D2_A42TicketDesktop ;
      private bool[] H000D2_n42TicketDesktop ;
      private bool[] H000D2_A53TicketLaptop ;
      private bool[] H000D2_n53TicketLaptop ;
      private long[] H000D2_A54TicketLastId ;
      private long[] H000D2_A15UsuarioId ;
      private DateTime[] H000D2_A48TicketHora ;
      private DateTime[] H000D2_A46TicketFecha ;
      private long[] H000D2_A14TicketId ;
      private long[] H000D3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pTicketId ;
      private GXWebForm Form ;
   }

   public class gx0070__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000D2( IGxContext context ,
                                             DateTime AV7cTicketFecha ,
                                             DateTime AV8cTicketHora ,
                                             long AV9cUsuarioId ,
                                             long AV10cTicketLastId ,
                                             bool AV11cTicketLaptop ,
                                             bool AV12cTicketDesktop ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             long A15UsuarioId ,
                                             long A54TicketLastId ,
                                             bool A53TicketLaptop ,
                                             bool A42TicketDesktop ,
                                             long AV6cTicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TicketUps], [TicketRouter], [TicketEscaner], [TicketImpresora], [TicketMonitor], [TicketDesktop], [TicketLaptop], [TicketLastId], [UsuarioId], [TicketHora], [TicketFecha], [TicketId]";
         sFromString = " FROM [Ticket]";
         sOrderString = "";
         AddWhere(sWhereString, "([TicketId] >= @AV6cTicketId)");
         if ( ! (DateTime.MinValue==AV7cTicketFecha) )
         {
            AddWhere(sWhereString, "([TicketFecha] >= @AV7cTicketFecha)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTicketHora) )
         {
            AddWhere(sWhereString, "([TicketHora] >= @AV8cTicketHora)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cUsuarioId) )
         {
            AddWhere(sWhereString, "([UsuarioId] >= @AV9cUsuarioId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cTicketLastId) )
         {
            AddWhere(sWhereString, "([TicketLastId] >= @AV10cTicketLastId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV11cTicketLaptop) )
         {
            AddWhere(sWhereString, "([TicketLaptop] >= @AV11cTicketLaptop)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV12cTicketDesktop) )
         {
            AddWhere(sWhereString, "([TicketDesktop] >= @AV12cTicketDesktop)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [TicketId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000D3( IGxContext context ,
                                             DateTime AV7cTicketFecha ,
                                             DateTime AV8cTicketHora ,
                                             long AV9cUsuarioId ,
                                             long AV10cTicketLastId ,
                                             bool AV11cTicketLaptop ,
                                             bool AV12cTicketDesktop ,
                                             DateTime A46TicketFecha ,
                                             DateTime A48TicketHora ,
                                             long A15UsuarioId ,
                                             long A54TicketLastId ,
                                             bool A53TicketLaptop ,
                                             bool A42TicketDesktop ,
                                             long AV6cTicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Ticket]";
         AddWhere(sWhereString, "([TicketId] >= @AV6cTicketId)");
         if ( ! (DateTime.MinValue==AV7cTicketFecha) )
         {
            AddWhere(sWhereString, "([TicketFecha] >= @AV7cTicketFecha)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cTicketHora) )
         {
            AddWhere(sWhereString, "([TicketHora] >= @AV8cTicketHora)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cUsuarioId) )
         {
            AddWhere(sWhereString, "([UsuarioId] >= @AV9cUsuarioId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cTicketLastId) )
         {
            AddWhere(sWhereString, "([TicketLastId] >= @AV10cTicketLastId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV11cTicketLaptop) )
         {
            AddWhere(sWhereString, "([TicketLaptop] >= @AV11cTicketLaptop)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV12cTicketDesktop) )
         {
            AddWhere(sWhereString, "([TicketDesktop] >= @AV12cTicketDesktop)");
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
                     return conditional_H000D2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H000D3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (long)dynConstraints[2] , (long)dynConstraints[3] , (bool)dynConstraints[4] , (bool)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (long)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (bool)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH000D2;
          prmH000D2 = new Object[] {
          new ParDef("@AV6cTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cTicketFecha",GXType.Date,8,0) ,
          new ParDef("@AV8cTicketHora",GXType.DateTime,0,5) ,
          new ParDef("@AV9cUsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@AV10cTicketLastId",GXType.Decimal,10,0) ,
          new ParDef("@AV11cTicketLaptop",GXType.Boolean,4,0) ,
          new ParDef("@AV12cTicketDesktop",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000D3;
          prmH000D3 = new Object[] {
          new ParDef("@AV6cTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV7cTicketFecha",GXType.Date,8,0) ,
          new ParDef("@AV8cTicketHora",GXType.DateTime,0,5) ,
          new ParDef("@AV9cUsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@AV10cTicketLastId",GXType.Decimal,10,0) ,
          new ParDef("@AV11cTicketLaptop",GXType.Boolean,4,0) ,
          new ParDef("@AV12cTicketDesktop",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000D2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000D3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000D3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[6])[0] = rslt.getBool(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((bool[]) buf[8])[0] = rslt.getBool(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((bool[]) buf[10])[0] = rslt.getBool(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((bool[]) buf[12])[0] = rslt.getBool(7);
                ((bool[]) buf[13])[0] = rslt.wasNull(7);
                ((long[]) buf[14])[0] = rslt.getLong(8);
                ((long[]) buf[15])[0] = rslt.getLong(9);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(10);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(11);
                ((long[]) buf[18])[0] = rslt.getLong(12);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
