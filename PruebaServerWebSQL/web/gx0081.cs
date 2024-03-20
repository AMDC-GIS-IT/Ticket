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
   public class gx0081 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0081( )
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

      public gx0081( IGxContext context )
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

      public void execute( long aP0_pTicketId ,
                           out long aP1_pTicketResponsableId )
      {
         this.AV11pTicketId = aP0_pTicketId;
         this.AV12pTicketResponsableId = 0 ;
         executePrivate();
         aP1_pTicketResponsableId=this.AV12pTicketResponsableId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCticketresponsableinstalacion = new GXCheckbox();
         chkavCticketresponsableconfiguracion = new GXCheckbox();
         chkTicketResponsableInstalacion = new GXCheckbox();
         chkTicketResponsableConfiguracion = new GXCheckbox();
         chkTicketResponsableFormateo = new GXCheckbox();
         chkTicketResponsableReparacion = new GXCheckbox();
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
               nRC_GXsfl_74 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."));
               nGXsfl_74_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."));
               sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
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
               AV6cTicketResponsableId = (long)(NumberUtil.Val( GetPar( "cTicketResponsableId"), "."));
               AV8cTicketFechaResponsable = context.localUtil.ParseDateParm( GetPar( "cTicketFechaResponsable"));
               AV9cTicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "cTicketHoraResponsable")));
               AV10cEstadoTicketTecnicoId = (short)(NumberUtil.Val( GetPar( "cEstadoTicketTecnicoId"), "."));
               AV14cTicketResponsableInstalacion = StringUtil.StrToBool( GetPar( "cTicketResponsableInstalacion"));
               AV15cTicketResponsableConfiguracion = StringUtil.StrToBool( GetPar( "cTicketResponsableConfiguracion"));
               AV11pTicketId = (long)(NumberUtil.Val( GetPar( "pTicketId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, AV11pTicketId) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETFECHARESPONSABLEFILTERCONTAINER_Class", StringUtil.RTrim( divTicketfecharesponsablefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETHORARESPONSABLEFILTERCONTAINER_Class", StringUtil.RTrim( divTickethoraresponsablefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "ESTADOTICKETTECNICOIDFILTERCONTAINER_Class", StringUtil.RTrim( divEstadotickettecnicoidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEINSTALACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableinstalacionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLECONFIGURACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableconfiguracionfiltercontainer_Class));
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
               AV11pTicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV11pTicketId", StringUtil.LTrimStr( (decimal)(AV11pTicketId), 10, 0));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV12pTicketResponsableId = (long)(NumberUtil.Val( GetPar( "pTicketResponsableId"), "."));
                  AssignAttri("", false, "AV12pTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV12pTicketResponsableId), 10, 0));
               }
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
            return "gx0081_Execute" ;
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
         PA0E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249571946", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0081.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pTicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV12pTicketResponsableId,10,0))}, new string[] {"pTicketId","pTicketResponsableId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETFECHARESPONSABLE", context.localUtil.Format(AV8cTicketFechaResponsable, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETHORARESPONSABLE", context.localUtil.TToC( AV9cTicketHoraResponsable, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cEstadoTicketTecnicoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETRESPONSABLEINSTALACION", StringUtil.BoolToStr( AV14cTicketResponsableInstalacion));
         GxWebStd.gx_hidden_field( context, "GXH_vCTICKETRESPONSABLECONFIGURACION", StringUtil.BoolToStr( AV15cTicketResponsableConfiguracion));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pTicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pTicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETFECHARESPONSABLEFILTERCONTAINER_Class", StringUtil.RTrim( divTicketfecharesponsablefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETHORARESPONSABLEFILTERCONTAINER_Class", StringUtil.RTrim( divTickethoraresponsablefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOTICKETTECNICOIDFILTERCONTAINER_Class", StringUtil.RTrim( divEstadotickettecnicoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEINSTALACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableinstalacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLECONFIGURACIONFILTERCONTAINER_Class", StringUtil.RTrim( divTicketresponsableconfiguracionfiltercontainer_Class));
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
            WE0E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0E2( ) ;
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
         return formatLink("gx0081.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pTicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV12pTicketResponsableId,10,0))}, new string[] {"pTicketId","pTicketResponsableId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0081" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Responsable" ;
      }

      protected void WB0E0( )
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
            GxWebStd.gx_div_start( context, divTicketresponsableidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketresponsableidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketresponsableidfilter_Internalname, "Ticket Responsable Id", "", "", lblLblticketresponsableidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0081.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCticketresponsableid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cTicketResponsableId), 10, 0, ",", "")), ((edtavCticketresponsableid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cTicketResponsableId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cTicketResponsableId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketresponsableid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCticketresponsableid_Visible, edtavCticketresponsableid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0081.htm");
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
            GxWebStd.gx_div_start( context, divTicketfecharesponsablefiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketfecharesponsablefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketfecharesponsablefilter_Internalname, "Ticket Fecha Responsable", "", "", lblLblticketfecharesponsablefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120e1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0081.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCticketfecharesponsable_Internalname, "Ticket Fecha Responsable", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCticketfecharesponsable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCticketfecharesponsable_Internalname, context.localUtil.Format(AV8cTicketFechaResponsable, "99/99/9999"), context.localUtil.Format( AV8cTicketFechaResponsable, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCticketfecharesponsable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCticketfecharesponsable_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0081.htm");
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
            GxWebStd.gx_div_start( context, divTickethoraresponsablefiltercontainer_Internalname, 1, 0, "px", 0, "px", divTickethoraresponsablefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbltickethoraresponsablefilter_Internalname, "Ticket Hora Responsable", "", "", lblLbltickethoraresponsablefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130e1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0081.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCtickethoraresponsable_Internalname, "Ticket Hora Responsable", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCtickethoraresponsable_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCtickethoraresponsable_Internalname, context.localUtil.TToC( AV9cTicketHoraResponsable, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV9cTicketHoraResponsable, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCtickethoraresponsable_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCtickethoraresponsable_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0081.htm");
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
            GxWebStd.gx_div_start( context, divEstadotickettecnicoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadotickettecnicoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadotickettecnicoidfilter_Internalname, "Estado Id", "", "", lblLblestadotickettecnicoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0081.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadotickettecnicoid_Internalname, "Estado Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadotickettecnicoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cEstadoTicketTecnicoId), 4, 0, ",", "")), ((edtavCestadotickettecnicoid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10cEstadoTicketTecnicoId), "ZZZ9")) : context.localUtil.Format( (decimal)(AV10cEstadoTicketTecnicoId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadotickettecnicoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadotickettecnicoid_Visible, edtavCestadotickettecnicoid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0081.htm");
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
            GxWebStd.gx_div_start( context, divTicketresponsableinstalacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketresponsableinstalacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketresponsableinstalacionfilter_Internalname, "Instalación", "", "", lblLblticketresponsableinstalacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0081.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCticketresponsableinstalacion_Internalname, "Instalación", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCticketresponsableinstalacion_Internalname, StringUtil.BoolToStr( AV14cTicketResponsableInstalacion), "", "Instalación", chkavCticketresponsableinstalacion.Visible, chkavCticketresponsableinstalacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_div_start( context, divTicketresponsableconfiguracionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divTicketresponsableconfiguracionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblticketresponsableconfiguracionfilter_Internalname, "Configuración", "", "", lblLblticketresponsableconfiguracionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160e1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0081.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCticketresponsableconfiguracion_Internalname, "Configuración", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCticketresponsableconfiguracion_Internalname, StringUtil.BoolToStr( AV15cTicketResponsableConfiguracion), "", "Configuración", chkavCticketresponsableconfiguracion.Visible, chkavCticketresponsableconfiguracion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(66, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,66);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170e1_client"+"'", TempTags, "", 2, "HLP_Gx0081.htm");
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
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
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
               context.SendWebValue( "Id TR:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Asignado:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora Asignado:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Instalación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Configuración") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Formateo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Reparación") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "RST No.") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A47TicketFechaResponsable, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A49TicketHoraResponsable, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A146TicketResponsableInstalacion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A147TicketResponsableConfiguracion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A149TicketResponsableFormateo));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A150TicketResponsableReparacion));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
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
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0081.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 74 )
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

      protected void START0E2( )
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
            Form.Meta.addItem("description", "Selection List Responsable", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0E0( ) ;
      }

      protected void WS0E2( )
      {
         START0E2( ) ;
         EVT0E2( ) ;
      }

      protected void EVT0E2( )
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
                              nGXsfl_74_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", "."));
                              A47TicketFechaResponsable = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTicketFechaResponsable_Internalname), 0));
                              A49TicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHoraResponsable_Internalname), 0));
                              A17EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketTecnicoId_Internalname), ",", "."));
                              A146TicketResponsableInstalacion = StringUtil.StrToBool( cgiGet( chkTicketResponsableInstalacion_Internalname));
                              n146TicketResponsableInstalacion = false;
                              A147TicketResponsableConfiguracion = StringUtil.StrToBool( cgiGet( chkTicketResponsableConfiguracion_Internalname));
                              n147TicketResponsableConfiguracion = false;
                              A149TicketResponsableFormateo = StringUtil.StrToBool( cgiGet( chkTicketResponsableFormateo_Internalname));
                              n149TicketResponsableFormateo = false;
                              A150TicketResponsableReparacion = StringUtil.StrToBool( cgiGet( chkTicketResponsableReparacion_Internalname));
                              n150TicketResponsableReparacion = false;
                              A290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( edtEtapaDesarrolloId_Internalname), ",", "."));
                              n290EtapaDesarrolloId = false;
                              A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cticketresponsableid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV6cTicketResponsableId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketfecharesponsable Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETFECHARESPONSABLE"), 0) != AV8cTicketFechaResponsable )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ctickethoraresponsable Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETHORARESPONSABLE"), 0) != AV9cTicketHoraResponsable )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadotickettecnicoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADOTICKETTECNICOID"), ",", ".") != Convert.ToDecimal( AV10cEstadoTicketTecnicoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketresponsableinstalacion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETRESPONSABLEINSTALACION")) != AV14cTicketResponsableInstalacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cticketresponsableconfiguracion Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETRESPONSABLECONFIGURACION")) != AV15cTicketResponsableConfiguracion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200E2 ();
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

      protected void WE0E2( )
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

      protected void PA0E2( )
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
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        long AV6cTicketResponsableId ,
                                        DateTime AV8cTicketFechaResponsable ,
                                        DateTime AV9cTicketHoraResponsable ,
                                        short AV10cEstadoTicketTecnicoId ,
                                        bool AV14cTicketResponsableInstalacion ,
                                        bool AV15cTicketResponsableConfiguracion ,
                                        long AV11pTicketId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "TICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
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
         AV14cTicketResponsableInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV14cTicketResponsableInstalacion));
         AssignAttri("", false, "AV14cTicketResponsableInstalacion", AV14cTicketResponsableInstalacion);
         AV15cTicketResponsableConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV15cTicketResponsableConfiguracion));
         AssignAttri("", false, "AV15cTicketResponsableConfiguracion", AV15cTicketResponsableConfiguracion);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0E2( ) ;
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

      protected void RF0E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
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
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8cTicketFechaResponsable ,
                                                 AV9cTicketHoraResponsable ,
                                                 AV10cEstadoTicketTecnicoId ,
                                                 AV14cTicketResponsableInstalacion ,
                                                 AV15cTicketResponsableConfiguracion ,
                                                 A47TicketFechaResponsable ,
                                                 A49TicketHoraResponsable ,
                                                 A17EstadoTicketTecnicoId ,
                                                 A146TicketResponsableInstalacion ,
                                                 A147TicketResponsableConfiguracion ,
                                                 AV11pTicketId ,
                                                 AV6cTicketResponsableId ,
                                                 A14TicketId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                                 }
            });
            /* Using cursor H000E2 */
            pr_default.execute(0, new Object[] {AV11pTicketId, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A14TicketId = H000E2_A14TicketId[0];
               A290EtapaDesarrolloId = H000E2_A290EtapaDesarrolloId[0];
               n290EtapaDesarrolloId = H000E2_n290EtapaDesarrolloId[0];
               A150TicketResponsableReparacion = H000E2_A150TicketResponsableReparacion[0];
               n150TicketResponsableReparacion = H000E2_n150TicketResponsableReparacion[0];
               A149TicketResponsableFormateo = H000E2_A149TicketResponsableFormateo[0];
               n149TicketResponsableFormateo = H000E2_n149TicketResponsableFormateo[0];
               A147TicketResponsableConfiguracion = H000E2_A147TicketResponsableConfiguracion[0];
               n147TicketResponsableConfiguracion = H000E2_n147TicketResponsableConfiguracion[0];
               A146TicketResponsableInstalacion = H000E2_A146TicketResponsableInstalacion[0];
               n146TicketResponsableInstalacion = H000E2_n146TicketResponsableInstalacion[0];
               A17EstadoTicketTecnicoId = H000E2_A17EstadoTicketTecnicoId[0];
               A49TicketHoraResponsable = H000E2_A49TicketHoraResponsable[0];
               A47TicketFechaResponsable = H000E2_A47TicketFechaResponsable[0];
               A16TicketResponsableId = H000E2_A16TicketResponsableId[0];
               /* Execute user event: Load */
               E190E2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0E0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0E2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TICKETRESPONSABLEID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"), context));
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
                                              AV8cTicketFechaResponsable ,
                                              AV9cTicketHoraResponsable ,
                                              AV10cEstadoTicketTecnicoId ,
                                              AV14cTicketResponsableInstalacion ,
                                              AV15cTicketResponsableConfiguracion ,
                                              A47TicketFechaResponsable ,
                                              A49TicketHoraResponsable ,
                                              A17EstadoTicketTecnicoId ,
                                              A146TicketResponsableInstalacion ,
                                              A147TicketResponsableConfiguracion ,
                                              AV11pTicketId ,
                                              AV6cTicketResponsableId ,
                                              A14TicketId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         /* Using cursor H000E3 */
         pr_default.execute(1, new Object[] {AV11pTicketId, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion});
         GRID1_nRecordCount = H000E3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, AV11pTicketId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, AV11pTicketId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, AV11pTicketId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, AV11pTicketId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cTicketResponsableId, AV8cTicketFechaResponsable, AV9cTicketHoraResponsable, AV10cEstadoTicketTecnicoId, AV14cTicketResponsableInstalacion, AV15cTicketResponsableConfiguracion, AV11pTicketId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ",", "."));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ",", "."));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ",", "."));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCticketresponsableid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCticketresponsableid_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCTICKETRESPONSABLEID");
               GX_FocusControl = edtavCticketresponsableid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cTicketResponsableId = 0;
               AssignAttri("", false, "AV6cTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV6cTicketResponsableId), 10, 0));
            }
            else
            {
               AV6cTicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtavCticketresponsableid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV6cTicketResponsableId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCticketfecharesponsable_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Ticket Fecha Responsable"}), 1, "vCTICKETFECHARESPONSABLE");
               GX_FocusControl = edtavCticketfecharesponsable_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cTicketFechaResponsable = DateTime.MinValue;
               AssignAttri("", false, "AV8cTicketFechaResponsable", context.localUtil.Format(AV8cTicketFechaResponsable, "99/99/9999"));
            }
            else
            {
               AV8cTicketFechaResponsable = context.localUtil.CToD( cgiGet( edtavCticketfecharesponsable_Internalname), 2);
               AssignAttri("", false, "AV8cTicketFechaResponsable", context.localUtil.Format(AV8cTicketFechaResponsable, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCtickethoraresponsable_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Ticket Hora Responsable"}), 1, "vCTICKETHORARESPONSABLE");
               GX_FocusControl = edtavCtickethoraresponsable_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cTicketHoraResponsable = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9cTicketHoraResponsable", context.localUtil.TToC( AV9cTicketHoraResponsable, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV9cTicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavCtickethoraresponsable_Internalname)));
               AssignAttri("", false, "AV9cTicketHoraResponsable", context.localUtil.TToC( AV9cTicketHoraResponsable, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCestadotickettecnicoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCestadotickettecnicoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESTADOTICKETTECNICOID");
               GX_FocusControl = edtavCestadotickettecnicoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cEstadoTicketTecnicoId = 0;
               AssignAttri("", false, "AV10cEstadoTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV10cEstadoTicketTecnicoId), 4, 0));
            }
            else
            {
               AV10cEstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( edtavCestadotickettecnicoid_Internalname), ",", "."));
               AssignAttri("", false, "AV10cEstadoTicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV10cEstadoTicketTecnicoId), 4, 0));
            }
            AV14cTicketResponsableInstalacion = StringUtil.StrToBool( cgiGet( chkavCticketresponsableinstalacion_Internalname));
            AssignAttri("", false, "AV14cTicketResponsableInstalacion", AV14cTicketResponsableInstalacion);
            AV15cTicketResponsableConfiguracion = StringUtil.StrToBool( cgiGet( chkavCticketresponsableconfiguracion_Internalname));
            AssignAttri("", false, "AV15cTicketResponsableConfiguracion", AV15cTicketResponsableConfiguracion);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCTICKETRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV6cTicketResponsableId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCTICKETFECHARESPONSABLE"), 2) != AV8cTicketFechaResponsable )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCTICKETHORARESPONSABLE")) != AV9cTicketHoraResponsable )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADOTICKETTECNICOID"), ",", ".") != Convert.ToDecimal( AV10cEstadoTicketTecnicoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETRESPONSABLEINSTALACION")) != AV14cTicketResponsableInstalacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCTICKETRESPONSABLECONFIGURACION")) != AV15cTicketResponsableConfiguracion )
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
         E180E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180E2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Responsable", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E190E2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            context.DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200E2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pTicketResponsableId = A16TicketResponsableId;
         AssignAttri("", false, "AV12pTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV12pTicketResponsableId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV12pTicketResponsableId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pTicketResponsableId"});
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
         AV11pTicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV11pTicketId", StringUtil.LTrimStr( (decimal)(AV11pTicketId), 10, 0));
         AV12pTicketResponsableId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV12pTicketResponsableId", StringUtil.LTrimStr( (decimal)(AV12pTicketResponsableId), 10, 0));
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
         PA0E2( ) ;
         WS0E2( ) ;
         WE0E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249572022", true, true);
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
         context.AddJavascriptSource("gx0081.js", "?20231249572022", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_74_idx;
         edtTicketFechaResponsable_Internalname = "TICKETFECHARESPONSABLE_"+sGXsfl_74_idx;
         edtTicketHoraResponsable_Internalname = "TICKETHORARESPONSABLE_"+sGXsfl_74_idx;
         edtEstadoTicketTecnicoId_Internalname = "ESTADOTICKETTECNICOID_"+sGXsfl_74_idx;
         chkTicketResponsableInstalacion_Internalname = "TICKETRESPONSABLEINSTALACION_"+sGXsfl_74_idx;
         chkTicketResponsableConfiguracion_Internalname = "TICKETRESPONSABLECONFIGURACION_"+sGXsfl_74_idx;
         chkTicketResponsableFormateo_Internalname = "TICKETRESPONSABLEFORMATEO_"+sGXsfl_74_idx;
         chkTicketResponsableReparacion_Internalname = "TICKETRESPONSABLEREPARACION_"+sGXsfl_74_idx;
         edtEtapaDesarrolloId_Internalname = "ETAPADESARROLLOID_"+sGXsfl_74_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID_"+sGXsfl_74_fel_idx;
         edtTicketFechaResponsable_Internalname = "TICKETFECHARESPONSABLE_"+sGXsfl_74_fel_idx;
         edtTicketHoraResponsable_Internalname = "TICKETHORARESPONSABLE_"+sGXsfl_74_fel_idx;
         edtEstadoTicketTecnicoId_Internalname = "ESTADOTICKETTECNICOID_"+sGXsfl_74_fel_idx;
         chkTicketResponsableInstalacion_Internalname = "TICKETRESPONSABLEINSTALACION_"+sGXsfl_74_fel_idx;
         chkTicketResponsableConfiguracion_Internalname = "TICKETRESPONSABLECONFIGURACION_"+sGXsfl_74_fel_idx;
         chkTicketResponsableFormateo_Internalname = "TICKETRESPONSABLEFORMATEO_"+sGXsfl_74_fel_idx;
         chkTicketResponsableReparacion_Internalname = "TICKETRESPONSABLEREPARACION_"+sGXsfl_74_fel_idx;
         edtEtapaDesarrolloId_Internalname = "ETAPADESARROLLOID_"+sGXsfl_74_fel_idx;
         edtTicketId_Internalname = "TICKETID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB0E0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV18Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFechaResponsable_Internalname,context.localUtil.Format(A47TicketFechaResponsable, "99/99/9999"),context.localUtil.Format( A47TicketFechaResponsable, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketFechaResponsable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHoraResponsable_Internalname,context.localUtil.TToC( A49TicketHoraResponsable, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A49TicketHoraResponsable, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHoraResponsable_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketTecnicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A17EstadoTicketTecnicoId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketTecnicoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETRESPONSABLEINSTALACION_" + sGXsfl_74_idx;
            chkTicketResponsableInstalacion.Name = GXCCtl;
            chkTicketResponsableInstalacion.WebTags = "";
            chkTicketResponsableInstalacion.Caption = "";
            AssignProp("", false, chkTicketResponsableInstalacion_Internalname, "TitleCaption", chkTicketResponsableInstalacion.Caption, !bGXsfl_74_Refreshing);
            chkTicketResponsableInstalacion.CheckedValue = "false";
            A146TicketResponsableInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A146TicketResponsableInstalacion));
            n146TicketResponsableInstalacion = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketResponsableInstalacion_Internalname,StringUtil.BoolToStr( A146TicketResponsableInstalacion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETRESPONSABLECONFIGURACION_" + sGXsfl_74_idx;
            chkTicketResponsableConfiguracion.Name = GXCCtl;
            chkTicketResponsableConfiguracion.WebTags = "";
            chkTicketResponsableConfiguracion.Caption = "";
            AssignProp("", false, chkTicketResponsableConfiguracion_Internalname, "TitleCaption", chkTicketResponsableConfiguracion.Caption, !bGXsfl_74_Refreshing);
            chkTicketResponsableConfiguracion.CheckedValue = "false";
            A147TicketResponsableConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A147TicketResponsableConfiguracion));
            n147TicketResponsableConfiguracion = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketResponsableConfiguracion_Internalname,StringUtil.BoolToStr( A147TicketResponsableConfiguracion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETRESPONSABLEFORMATEO_" + sGXsfl_74_idx;
            chkTicketResponsableFormateo.Name = GXCCtl;
            chkTicketResponsableFormateo.WebTags = "";
            chkTicketResponsableFormateo.Caption = "";
            AssignProp("", false, chkTicketResponsableFormateo_Internalname, "TitleCaption", chkTicketResponsableFormateo.Caption, !bGXsfl_74_Refreshing);
            chkTicketResponsableFormateo.CheckedValue = "false";
            A149TicketResponsableFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A149TicketResponsableFormateo));
            n149TicketResponsableFormateo = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketResponsableFormateo_Internalname,StringUtil.BoolToStr( A149TicketResponsableFormateo),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "TICKETRESPONSABLEREPARACION_" + sGXsfl_74_idx;
            chkTicketResponsableReparacion.Name = GXCCtl;
            chkTicketResponsableReparacion.WebTags = "";
            chkTicketResponsableReparacion.Caption = "";
            AssignProp("", false, chkTicketResponsableReparacion_Internalname, "TitleCaption", chkTicketResponsableReparacion.Caption, !bGXsfl_74_Refreshing);
            chkTicketResponsableReparacion.CheckedValue = "false";
            A150TicketResponsableReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A150TicketResponsableReparacion));
            n150TicketResponsableReparacion = false;
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkTicketResponsableReparacion_Internalname,StringUtil.BoolToStr( A150TicketResponsableReparacion),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEtapaDesarrolloId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A290EtapaDesarrolloId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEtapaDesarrolloId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")),context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0E2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         chkavCticketresponsableinstalacion.Name = "vCTICKETRESPONSABLEINSTALACION";
         chkavCticketresponsableinstalacion.WebTags = "";
         chkavCticketresponsableinstalacion.Caption = "";
         AssignProp("", false, chkavCticketresponsableinstalacion_Internalname, "TitleCaption", chkavCticketresponsableinstalacion.Caption, true);
         chkavCticketresponsableinstalacion.CheckedValue = "false";
         AV14cTicketResponsableInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV14cTicketResponsableInstalacion));
         AssignAttri("", false, "AV14cTicketResponsableInstalacion", AV14cTicketResponsableInstalacion);
         chkavCticketresponsableconfiguracion.Name = "vCTICKETRESPONSABLECONFIGURACION";
         chkavCticketresponsableconfiguracion.WebTags = "";
         chkavCticketresponsableconfiguracion.Caption = "";
         AssignProp("", false, chkavCticketresponsableconfiguracion_Internalname, "TitleCaption", chkavCticketresponsableconfiguracion.Caption, true);
         chkavCticketresponsableconfiguracion.CheckedValue = "false";
         AV15cTicketResponsableConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV15cTicketResponsableConfiguracion));
         AssignAttri("", false, "AV15cTicketResponsableConfiguracion", AV15cTicketResponsableConfiguracion);
         GXCCtl = "TICKETRESPONSABLEINSTALACION_" + sGXsfl_74_idx;
         chkTicketResponsableInstalacion.Name = GXCCtl;
         chkTicketResponsableInstalacion.WebTags = "";
         chkTicketResponsableInstalacion.Caption = "";
         AssignProp("", false, chkTicketResponsableInstalacion_Internalname, "TitleCaption", chkTicketResponsableInstalacion.Caption, !bGXsfl_74_Refreshing);
         chkTicketResponsableInstalacion.CheckedValue = "false";
         A146TicketResponsableInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A146TicketResponsableInstalacion));
         n146TicketResponsableInstalacion = false;
         GXCCtl = "TICKETRESPONSABLECONFIGURACION_" + sGXsfl_74_idx;
         chkTicketResponsableConfiguracion.Name = GXCCtl;
         chkTicketResponsableConfiguracion.WebTags = "";
         chkTicketResponsableConfiguracion.Caption = "";
         AssignProp("", false, chkTicketResponsableConfiguracion_Internalname, "TitleCaption", chkTicketResponsableConfiguracion.Caption, !bGXsfl_74_Refreshing);
         chkTicketResponsableConfiguracion.CheckedValue = "false";
         A147TicketResponsableConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A147TicketResponsableConfiguracion));
         n147TicketResponsableConfiguracion = false;
         GXCCtl = "TICKETRESPONSABLEFORMATEO_" + sGXsfl_74_idx;
         chkTicketResponsableFormateo.Name = GXCCtl;
         chkTicketResponsableFormateo.WebTags = "";
         chkTicketResponsableFormateo.Caption = "";
         AssignProp("", false, chkTicketResponsableFormateo_Internalname, "TitleCaption", chkTicketResponsableFormateo.Caption, !bGXsfl_74_Refreshing);
         chkTicketResponsableFormateo.CheckedValue = "false";
         A149TicketResponsableFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A149TicketResponsableFormateo));
         n149TicketResponsableFormateo = false;
         GXCCtl = "TICKETRESPONSABLEREPARACION_" + sGXsfl_74_idx;
         chkTicketResponsableReparacion.Name = GXCCtl;
         chkTicketResponsableReparacion.WebTags = "";
         chkTicketResponsableReparacion.Caption = "";
         AssignProp("", false, chkTicketResponsableReparacion_Internalname, "TitleCaption", chkTicketResponsableReparacion.Caption, !bGXsfl_74_Refreshing);
         chkTicketResponsableReparacion.CheckedValue = "false";
         A150TicketResponsableReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A150TicketResponsableReparacion));
         n150TicketResponsableReparacion = false;
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblticketresponsableidfilter_Internalname = "LBLTICKETRESPONSABLEIDFILTER";
         edtavCticketresponsableid_Internalname = "vCTICKETRESPONSABLEID";
         divTicketresponsableidfiltercontainer_Internalname = "TICKETRESPONSABLEIDFILTERCONTAINER";
         lblLblticketfecharesponsablefilter_Internalname = "LBLTICKETFECHARESPONSABLEFILTER";
         edtavCticketfecharesponsable_Internalname = "vCTICKETFECHARESPONSABLE";
         divTicketfecharesponsablefiltercontainer_Internalname = "TICKETFECHARESPONSABLEFILTERCONTAINER";
         lblLbltickethoraresponsablefilter_Internalname = "LBLTICKETHORARESPONSABLEFILTER";
         edtavCtickethoraresponsable_Internalname = "vCTICKETHORARESPONSABLE";
         divTickethoraresponsablefiltercontainer_Internalname = "TICKETHORARESPONSABLEFILTERCONTAINER";
         lblLblestadotickettecnicoidfilter_Internalname = "LBLESTADOTICKETTECNICOIDFILTER";
         edtavCestadotickettecnicoid_Internalname = "vCESTADOTICKETTECNICOID";
         divEstadotickettecnicoidfiltercontainer_Internalname = "ESTADOTICKETTECNICOIDFILTERCONTAINER";
         lblLblticketresponsableinstalacionfilter_Internalname = "LBLTICKETRESPONSABLEINSTALACIONFILTER";
         chkavCticketresponsableinstalacion_Internalname = "vCTICKETRESPONSABLEINSTALACION";
         divTicketresponsableinstalacionfiltercontainer_Internalname = "TICKETRESPONSABLEINSTALACIONFILTERCONTAINER";
         lblLblticketresponsableconfiguracionfilter_Internalname = "LBLTICKETRESPONSABLECONFIGURACIONFILTER";
         chkavCticketresponsableconfiguracion_Internalname = "vCTICKETRESPONSABLECONFIGURACION";
         divTicketresponsableconfiguracionfiltercontainer_Internalname = "TICKETRESPONSABLECONFIGURACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtTicketResponsableId_Internalname = "TICKETRESPONSABLEID";
         edtTicketFechaResponsable_Internalname = "TICKETFECHARESPONSABLE";
         edtTicketHoraResponsable_Internalname = "TICKETHORARESPONSABLE";
         edtEstadoTicketTecnicoId_Internalname = "ESTADOTICKETTECNICOID";
         chkTicketResponsableInstalacion_Internalname = "TICKETRESPONSABLEINSTALACION";
         chkTicketResponsableConfiguracion_Internalname = "TICKETRESPONSABLECONFIGURACION";
         chkTicketResponsableFormateo_Internalname = "TICKETRESPONSABLEFORMATEO";
         chkTicketResponsableReparacion_Internalname = "TICKETRESPONSABLEREPARACION";
         edtEtapaDesarrolloId_Internalname = "ETAPADESARROLLOID";
         edtTicketId_Internalname = "TICKETID";
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
         chkavCticketresponsableconfiguracion.Caption = "Configuración";
         chkavCticketresponsableinstalacion.Caption = "Instalación";
         edtTicketId_Jsonclick = "";
         edtEtapaDesarrolloId_Jsonclick = "";
         chkTicketResponsableReparacion.Caption = "";
         chkTicketResponsableFormateo.Caption = "";
         chkTicketResponsableConfiguracion.Caption = "";
         chkTicketResponsableInstalacion.Caption = "";
         edtEstadoTicketTecnicoId_Jsonclick = "";
         edtTicketHoraResponsable_Jsonclick = "";
         edtTicketFechaResponsable_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         chkavCticketresponsableconfiguracion.Enabled = 1;
         chkavCticketresponsableconfiguracion.Visible = 1;
         chkavCticketresponsableinstalacion.Enabled = 1;
         chkavCticketresponsableinstalacion.Visible = 1;
         edtavCestadotickettecnicoid_Jsonclick = "";
         edtavCestadotickettecnicoid_Enabled = 1;
         edtavCestadotickettecnicoid_Visible = 1;
         edtavCtickethoraresponsable_Jsonclick = "";
         edtavCtickethoraresponsable_Enabled = 1;
         edtavCticketfecharesponsable_Jsonclick = "";
         edtavCticketfecharesponsable_Enabled = 1;
         edtavCticketresponsableid_Jsonclick = "";
         edtavCticketresponsableid_Enabled = 1;
         edtavCticketresponsableid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Responsable";
         divTicketresponsableconfiguracionfiltercontainer_Class = "AdvancedContainerItem";
         divTicketresponsableinstalacionfiltercontainer_Class = "AdvancedContainerItem";
         divEstadotickettecnicoidfiltercontainer_Class = "AdvancedContainerItem";
         divTickethoraresponsablefiltercontainer_Class = "AdvancedContainerItem";
         divTicketfecharesponsablefiltercontainer_Class = "AdvancedContainerItem";
         divTicketresponsableidfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV8cTicketFechaResponsable',fld:'vCTICKETFECHARESPONSABLE',pic:''},{av:'AV9cTicketHoraResponsable',fld:'vCTICKETHORARESPONSABLE',pic:'99:99'},{av:'AV10cEstadoTicketTecnicoId',fld:'vCESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV11pTicketId',fld:'vPTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("'TOGGLE'","{handler:'E170E1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETRESPONSABLEIDFILTER.CLICK","{handler:'E110E1',iparms:[{av:'divTicketresponsableidfiltercontainer_Class',ctrl:'TICKETRESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETRESPONSABLEIDFILTER.CLICK",",oparms:[{av:'divTicketresponsableidfiltercontainer_Class',ctrl:'TICKETRESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCticketresponsableid_Visible',ctrl:'vCTICKETRESPONSABLEID',prop:'Visible'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETFECHARESPONSABLEFILTER.CLICK","{handler:'E120E1',iparms:[{av:'divTicketfecharesponsablefiltercontainer_Class',ctrl:'TICKETFECHARESPONSABLEFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETFECHARESPONSABLEFILTER.CLICK",",oparms:[{av:'divTicketfecharesponsablefiltercontainer_Class',ctrl:'TICKETFECHARESPONSABLEFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETHORARESPONSABLEFILTER.CLICK","{handler:'E130E1',iparms:[{av:'divTickethoraresponsablefiltercontainer_Class',ctrl:'TICKETHORARESPONSABLEFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETHORARESPONSABLEFILTER.CLICK",",oparms:[{av:'divTickethoraresponsablefiltercontainer_Class',ctrl:'TICKETHORARESPONSABLEFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("LBLESTADOTICKETTECNICOIDFILTER.CLICK","{handler:'E140E1',iparms:[{av:'divEstadotickettecnicoidfiltercontainer_Class',ctrl:'ESTADOTICKETTECNICOIDFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("LBLESTADOTICKETTECNICOIDFILTER.CLICK",",oparms:[{av:'divEstadotickettecnicoidfiltercontainer_Class',ctrl:'ESTADOTICKETTECNICOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCestadotickettecnicoid_Visible',ctrl:'vCESTADOTICKETTECNICOID',prop:'Visible'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETRESPONSABLEINSTALACIONFILTER.CLICK","{handler:'E150E1',iparms:[{av:'divTicketresponsableinstalacionfiltercontainer_Class',ctrl:'TICKETRESPONSABLEINSTALACIONFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETRESPONSABLEINSTALACIONFILTER.CLICK",",oparms:[{av:'divTicketresponsableinstalacionfiltercontainer_Class',ctrl:'TICKETRESPONSABLEINSTALACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCticketresponsableinstalacion.Visible',ctrl:'vCTICKETRESPONSABLEINSTALACION',prop:'Visible'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("LBLTICKETRESPONSABLECONFIGURACIONFILTER.CLICK","{handler:'E160E1',iparms:[{av:'divTicketresponsableconfiguracionfiltercontainer_Class',ctrl:'TICKETRESPONSABLECONFIGURACIONFILTERCONTAINER',prop:'Class'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("LBLTICKETRESPONSABLECONFIGURACIONFILTER.CLICK",",oparms:[{av:'divTicketresponsableconfiguracionfiltercontainer_Class',ctrl:'TICKETRESPONSABLECONFIGURACIONFILTERCONTAINER',prop:'Class'},{av:'chkavCticketresponsableconfiguracion.Visible',ctrl:'vCTICKETRESPONSABLECONFIGURACION',prop:'Visible'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E200E2',iparms:[{av:'A16TicketResponsableId',fld:'TICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pTicketResponsableId',fld:'vPTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV8cTicketFechaResponsable',fld:'vCTICKETFECHARESPONSABLE',pic:''},{av:'AV9cTicketHoraResponsable',fld:'vCTICKETHORARESPONSABLE',pic:'99:99'},{av:'AV10cEstadoTicketTecnicoId',fld:'vCESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV11pTicketId',fld:'vPTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV8cTicketFechaResponsable',fld:'vCTICKETFECHARESPONSABLE',pic:''},{av:'AV9cTicketHoraResponsable',fld:'vCTICKETHORARESPONSABLE',pic:'99:99'},{av:'AV10cEstadoTicketTecnicoId',fld:'vCESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV11pTicketId',fld:'vPTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV8cTicketFechaResponsable',fld:'vCTICKETFECHARESPONSABLE',pic:''},{av:'AV9cTicketHoraResponsable',fld:'vCTICKETHORARESPONSABLE',pic:'99:99'},{av:'AV10cEstadoTicketTecnicoId',fld:'vCESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV11pTicketId',fld:'vPTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cTicketResponsableId',fld:'vCTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'AV8cTicketFechaResponsable',fld:'vCTICKETFECHARESPONSABLE',pic:''},{av:'AV9cTicketHoraResponsable',fld:'vCTICKETHORARESPONSABLE',pic:'99:99'},{av:'AV10cEstadoTicketTecnicoId',fld:'vCESTADOTICKETTECNICOID',pic:'ZZZ9'},{av:'AV11pTicketId',fld:'vPTICKETID',pic:'ZZZZZZZZZ9'},{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("VALIDV_CTICKETFECHARESPONSABLE","{handler:'Validv_Cticketfecharesponsable',iparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("VALIDV_CTICKETFECHARESPONSABLE",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Ticketid',iparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV14cTicketResponsableInstalacion',fld:'vCTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV15cTicketResponsableConfiguracion',fld:'vCTICKETRESPONSABLECONFIGURACION',pic:''}]}");
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
         AV8cTicketFechaResponsable = DateTime.MinValue;
         AV9cTicketHoraResponsable = (DateTime)(DateTime.MinValue);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblticketresponsableidfilter_Jsonclick = "";
         TempTags = "";
         lblLblticketfecharesponsablefilter_Jsonclick = "";
         lblLbltickethoraresponsablefilter_Jsonclick = "";
         lblLblestadotickettecnicoidfilter_Jsonclick = "";
         lblLblticketresponsableinstalacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblticketresponsableconfiguracionfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A47TicketFechaResponsable = DateTime.MinValue;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Linkselection_GXI = "";
         scmdbuf = "";
         H000E2_A14TicketId = new long[1] ;
         H000E2_A290EtapaDesarrolloId = new short[1] ;
         H000E2_n290EtapaDesarrolloId = new bool[] {false} ;
         H000E2_A150TicketResponsableReparacion = new bool[] {false} ;
         H000E2_n150TicketResponsableReparacion = new bool[] {false} ;
         H000E2_A149TicketResponsableFormateo = new bool[] {false} ;
         H000E2_n149TicketResponsableFormateo = new bool[] {false} ;
         H000E2_A147TicketResponsableConfiguracion = new bool[] {false} ;
         H000E2_n147TicketResponsableConfiguracion = new bool[] {false} ;
         H000E2_A146TicketResponsableInstalacion = new bool[] {false} ;
         H000E2_n146TicketResponsableInstalacion = new bool[] {false} ;
         H000E2_A17EstadoTicketTecnicoId = new short[1] ;
         H000E2_A49TicketHoraResponsable = new DateTime[] {DateTime.MinValue} ;
         H000E2_A47TicketFechaResponsable = new DateTime[] {DateTime.MinValue} ;
         H000E2_A16TicketResponsableId = new long[1] ;
         H000E3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0081__default(),
            new Object[][] {
                new Object[] {
               H000E2_A14TicketId, H000E2_A290EtapaDesarrolloId, H000E2_n290EtapaDesarrolloId, H000E2_A150TicketResponsableReparacion, H000E2_n150TicketResponsableReparacion, H000E2_A149TicketResponsableFormateo, H000E2_n149TicketResponsableFormateo, H000E2_A147TicketResponsableConfiguracion, H000E2_n147TicketResponsableConfiguracion, H000E2_A146TicketResponsableInstalacion,
               H000E2_n146TicketResponsableInstalacion, H000E2_A17EstadoTicketTecnicoId, H000E2_A49TicketHoraResponsable, H000E2_A47TicketFechaResponsable, H000E2_A16TicketResponsableId
               }
               , new Object[] {
               H000E3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV10cEstadoTicketTecnicoId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A17EstadoTicketTecnicoId ;
      private short A290EtapaDesarrolloId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_74 ;
      private int nGXsfl_74_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCticketresponsableid_Enabled ;
      private int edtavCticketresponsableid_Visible ;
      private int edtavCticketfecharesponsable_Enabled ;
      private int edtavCtickethoraresponsable_Enabled ;
      private int edtavCestadotickettecnicoid_Enabled ;
      private int edtavCestadotickettecnicoid_Visible ;
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
      private long AV11pTicketId ;
      private long AV12pTicketResponsableId ;
      private long wcpOAV11pTicketId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cTicketResponsableId ;
      private long A16TicketResponsableId ;
      private long A14TicketId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divTicketresponsableidfiltercontainer_Class ;
      private string divTicketfecharesponsablefiltercontainer_Class ;
      private string divTickethoraresponsablefiltercontainer_Class ;
      private string divEstadotickettecnicoidfiltercontainer_Class ;
      private string divTicketresponsableinstalacionfiltercontainer_Class ;
      private string divTicketresponsableconfiguracionfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divTicketresponsableidfiltercontainer_Internalname ;
      private string lblLblticketresponsableidfilter_Internalname ;
      private string lblLblticketresponsableidfilter_Jsonclick ;
      private string edtavCticketresponsableid_Internalname ;
      private string TempTags ;
      private string edtavCticketresponsableid_Jsonclick ;
      private string divTicketfecharesponsablefiltercontainer_Internalname ;
      private string lblLblticketfecharesponsablefilter_Internalname ;
      private string lblLblticketfecharesponsablefilter_Jsonclick ;
      private string edtavCticketfecharesponsable_Internalname ;
      private string edtavCticketfecharesponsable_Jsonclick ;
      private string divTickethoraresponsablefiltercontainer_Internalname ;
      private string lblLbltickethoraresponsablefilter_Internalname ;
      private string lblLbltickethoraresponsablefilter_Jsonclick ;
      private string edtavCtickethoraresponsable_Internalname ;
      private string edtavCtickethoraresponsable_Jsonclick ;
      private string divEstadotickettecnicoidfiltercontainer_Internalname ;
      private string lblLblestadotickettecnicoidfilter_Internalname ;
      private string lblLblestadotickettecnicoidfilter_Jsonclick ;
      private string edtavCestadotickettecnicoid_Internalname ;
      private string edtavCestadotickettecnicoid_Jsonclick ;
      private string divTicketresponsableinstalacionfiltercontainer_Internalname ;
      private string lblLblticketresponsableinstalacionfilter_Internalname ;
      private string lblLblticketresponsableinstalacionfilter_Jsonclick ;
      private string chkavCticketresponsableinstalacion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTicketresponsableconfiguracionfiltercontainer_Internalname ;
      private string lblLblticketresponsableconfiguracionfilter_Internalname ;
      private string lblLblticketresponsableconfiguracionfilter_Jsonclick ;
      private string chkavCticketresponsableconfiguracion_Internalname ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketFechaResponsable_Internalname ;
      private string edtTicketHoraResponsable_Internalname ;
      private string edtEstadoTicketTecnicoId_Internalname ;
      private string chkTicketResponsableInstalacion_Internalname ;
      private string chkTicketResponsableConfiguracion_Internalname ;
      private string chkTicketResponsableFormateo_Internalname ;
      private string chkTicketResponsableReparacion_Internalname ;
      private string edtEtapaDesarrolloId_Internalname ;
      private string edtTicketId_Internalname ;
      private string scmdbuf ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtTicketFechaResponsable_Jsonclick ;
      private string edtTicketHoraResponsable_Jsonclick ;
      private string edtEstadoTicketTecnicoId_Jsonclick ;
      private string GXCCtl ;
      private string edtEtapaDesarrolloId_Jsonclick ;
      private string edtTicketId_Jsonclick ;
      private DateTime AV9cTicketHoraResponsable ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime AV8cTicketFechaResponsable ;
      private DateTime A47TicketFechaResponsable ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV14cTicketResponsableInstalacion ;
      private bool AV15cTicketResponsableConfiguracion ;
      private bool wbLoad ;
      private bool A146TicketResponsableInstalacion ;
      private bool A147TicketResponsableConfiguracion ;
      private bool A149TicketResponsableFormateo ;
      private bool A150TicketResponsableReparacion ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n146TicketResponsableInstalacion ;
      private bool n147TicketResponsableConfiguracion ;
      private bool n149TicketResponsableFormateo ;
      private bool n150TicketResponsableReparacion ;
      private bool n290EtapaDesarrolloId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV18Linkselection_GXI ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCticketresponsableinstalacion ;
      private GXCheckbox chkavCticketresponsableconfiguracion ;
      private GXCheckbox chkTicketResponsableInstalacion ;
      private GXCheckbox chkTicketResponsableConfiguracion ;
      private GXCheckbox chkTicketResponsableFormateo ;
      private GXCheckbox chkTicketResponsableReparacion ;
      private IDataStoreProvider pr_default ;
      private long[] H000E2_A14TicketId ;
      private short[] H000E2_A290EtapaDesarrolloId ;
      private bool[] H000E2_n290EtapaDesarrolloId ;
      private bool[] H000E2_A150TicketResponsableReparacion ;
      private bool[] H000E2_n150TicketResponsableReparacion ;
      private bool[] H000E2_A149TicketResponsableFormateo ;
      private bool[] H000E2_n149TicketResponsableFormateo ;
      private bool[] H000E2_A147TicketResponsableConfiguracion ;
      private bool[] H000E2_n147TicketResponsableConfiguracion ;
      private bool[] H000E2_A146TicketResponsableInstalacion ;
      private bool[] H000E2_n146TicketResponsableInstalacion ;
      private short[] H000E2_A17EstadoTicketTecnicoId ;
      private DateTime[] H000E2_A49TicketHoraResponsable ;
      private DateTime[] H000E2_A47TicketFechaResponsable ;
      private long[] H000E2_A16TicketResponsableId ;
      private long[] H000E3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP1_pTicketResponsableId ;
      private GXWebForm Form ;
   }

   public class gx0081__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000E2( IGxContext context ,
                                             DateTime AV8cTicketFechaResponsable ,
                                             DateTime AV9cTicketHoraResponsable ,
                                             short AV10cEstadoTicketTecnicoId ,
                                             bool AV14cTicketResponsableInstalacion ,
                                             bool AV15cTicketResponsableConfiguracion ,
                                             DateTime A47TicketFechaResponsable ,
                                             DateTime A49TicketHoraResponsable ,
                                             short A17EstadoTicketTecnicoId ,
                                             bool A146TicketResponsableInstalacion ,
                                             bool A147TicketResponsableConfiguracion ,
                                             long AV11pTicketId ,
                                             long AV6cTicketResponsableId ,
                                             long A14TicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [TicketId], [EtapaDesarrolloId], [TicketResponsableReparacion], [TicketResponsableFormateo], [TicketResponsableConfiguracion], [TicketResponsableInstalacion], [EstadoTicketTecnicoId], [TicketHoraResponsable], [TicketFechaResponsable], [TicketResponsableId]";
         sFromString = " FROM [TicketResponsable]";
         sOrderString = "";
         AddWhere(sWhereString, "([TicketId] = @AV11pTicketId and [TicketResponsableId] >= @AV6cTicketResponsableId)");
         if ( ! (DateTime.MinValue==AV8cTicketFechaResponsable) )
         {
            AddWhere(sWhereString, "([TicketFechaResponsable] >= @AV8cTicketFechaResponsable)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTicketHoraResponsable) )
         {
            AddWhere(sWhereString, "([TicketHoraResponsable] >= @AV9cTicketHoraResponsable)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cEstadoTicketTecnicoId) )
         {
            AddWhere(sWhereString, "([EstadoTicketTecnicoId] >= @AV10cEstadoTicketTecnicoId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (false==AV14cTicketResponsableInstalacion) )
         {
            AddWhere(sWhereString, "([TicketResponsableInstalacion] >= @AV14cTicketResponsableInstalacion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (false==AV15cTicketResponsableConfiguracion) )
         {
            AddWhere(sWhereString, "([TicketResponsableConfiguracion] >= @AV15cTicketResponsableConfiguracion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [TicketId], [TicketResponsableId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000E3( IGxContext context ,
                                             DateTime AV8cTicketFechaResponsable ,
                                             DateTime AV9cTicketHoraResponsable ,
                                             short AV10cEstadoTicketTecnicoId ,
                                             bool AV14cTicketResponsableInstalacion ,
                                             bool AV15cTicketResponsableConfiguracion ,
                                             DateTime A47TicketFechaResponsable ,
                                             DateTime A49TicketHoraResponsable ,
                                             short A17EstadoTicketTecnicoId ,
                                             bool A146TicketResponsableInstalacion ,
                                             bool A147TicketResponsableConfiguracion ,
                                             long AV11pTicketId ,
                                             long AV6cTicketResponsableId ,
                                             long A14TicketId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [TicketResponsable]";
         AddWhere(sWhereString, "([TicketId] = @AV11pTicketId and [TicketResponsableId] >= @AV6cTicketResponsableId)");
         if ( ! (DateTime.MinValue==AV8cTicketFechaResponsable) )
         {
            AddWhere(sWhereString, "([TicketFechaResponsable] >= @AV8cTicketFechaResponsable)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cTicketHoraResponsable) )
         {
            AddWhere(sWhereString, "([TicketHoraResponsable] >= @AV9cTicketHoraResponsable)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cEstadoTicketTecnicoId) )
         {
            AddWhere(sWhereString, "([EstadoTicketTecnicoId] >= @AV10cEstadoTicketTecnicoId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (false==AV14cTicketResponsableInstalacion) )
         {
            AddWhere(sWhereString, "([TicketResponsableInstalacion] >= @AV14cTicketResponsableInstalacion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (false==AV15cTicketResponsableConfiguracion) )
         {
            AddWhere(sWhereString, "([TicketResponsableConfiguracion] >= @AV15cTicketResponsableConfiguracion)");
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
                     return conditional_H000E2(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (bool)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H000E3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (bool)dynConstraints[3] , (bool)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (bool)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH000E2;
          prmH000E2 = new Object[] {
          new ParDef("@AV11pTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV6cTicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV8cTicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@AV9cTicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@AV10cEstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV14cTicketResponsableInstalacion",GXType.Boolean,4,0) ,
          new ParDef("@AV15cTicketResponsableConfiguracion",GXType.Boolean,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000E3;
          prmH000E3 = new Object[] {
          new ParDef("@AV11pTicketId",GXType.Decimal,10,0) ,
          new ParDef("@AV6cTicketResponsableId",GXType.Decimal,10,0) ,
          new ParDef("@AV8cTicketFechaResponsable",GXType.Date,8,0) ,
          new ParDef("@AV9cTicketHoraResponsable",GXType.DateTime,0,5) ,
          new ParDef("@AV10cEstadoTicketTecnicoId",GXType.Int16,4,0) ,
          new ParDef("@AV14cTicketResponsableInstalacion",GXType.Boolean,4,0) ,
          new ParDef("@AV15cTicketResponsableConfiguracion",GXType.Boolean,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000E3,1, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((bool[]) buf[7])[0] = rslt.getBool(5);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((bool[]) buf[9])[0] = rslt.getBool(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((short[]) buf[11])[0] = rslt.getShort(7);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
                ((long[]) buf[14])[0] = rslt.getLong(10);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
