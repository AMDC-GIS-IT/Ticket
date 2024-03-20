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
   public class gx0050 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx0050( )
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

      public gx0050( IGxContext context )
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

      public void execute( out short aP0_pResponsableId )
      {
         this.AV11pResponsableId = 0 ;
         executePrivate();
         aP0_pResponsableId=this.AV11pResponsableId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavCresponsableactivo = new GXCheckbox();
         chkResponsableActivo = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pResponsableId");
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
               gxfirstwebparm = GetFirstPar( "pResponsableId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pResponsableId");
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
               AV6cResponsableId = (short)(NumberUtil.Val( GetPar( "cResponsableId"), "."));
               AV7cResponsableIdentidad = GetPar( "cResponsableIdentidad");
               AV8cResponsableNombre = GetPar( "cResponsableNombre");
               AV9cResponsableEmail = GetPar( "cResponsableEmail");
               AV10cResponsableActivo = StringUtil.StrToBool( GetPar( "cResponsableActivo"));
               AV13cResponsableUsuario = GetPar( "cResponsableUsuario");
               AV14cEstadoResponsableId = (short)(NumberUtil.Val( GetPar( "cEstadoResponsableId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cResponsableId, AV7cResponsableIdentidad, AV8cResponsableNombre, AV9cResponsableEmail, AV10cResponsableActivo, AV13cResponsableUsuario, AV14cEstadoResponsableId) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "RESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "RESPONSABLEIDENTIDADFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableidentidadfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "RESPONSABLENOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divResponsablenombrefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "RESPONSABLEEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableemailfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "RESPONSABLEACTIVOFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableactivofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "RESPONSABLEUSUARIOFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableusuariofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "ESTADORESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divEstadoresponsableidfiltercontainer_Class));
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
               AV11pResponsableId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV11pResponsableId", StringUtil.LTrimStr( (decimal)(AV11pResponsableId), 4, 0));
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
            return "gx0050_Execute" ;
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
         PA082( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START082( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249571739", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0050.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pResponsableId,4,0))}, new string[] {"pResponsableId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLEIDENTIDAD", AV7cResponsableIdentidad);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLENOMBRE", AV8cResponsableNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLEEMAIL", AV9cResponsableEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLEACTIVO", StringUtil.BoolToStr( AV10cResponsableActivo));
         GxWebStd.gx_hidden_field( context, "GXH_vCRESPONSABLEUSUARIO", AV13cResponsableUsuario);
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cEstadoResponsableId), 4, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11pResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEIDENTIDADFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableidentidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLENOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divResponsablenombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEACTIVOFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableactivofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "RESPONSABLEUSUARIOFILTERCONTAINER_Class", StringUtil.RTrim( divResponsableusuariofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADORESPONSABLEIDFILTERCONTAINER_Class", StringUtil.RTrim( divEstadoresponsableidfiltercontainer_Class));
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
            WE082( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT082( ) ;
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
         return formatLink("gx0050.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV11pResponsableId,4,0))}, new string[] {"pResponsableId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0050" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Responsable" ;
      }

      protected void WB080( )
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
            GxWebStd.gx_div_start( context, divResponsableidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsableidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsableidfilter_Internalname, "Técnico Id", "", "", lblLblresponsableidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresponsableid_Internalname, "Técnico Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresponsableid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cResponsableId), 4, 0, ",", "")), ((edtavCresponsableid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cResponsableId), "ZZZ9")) : context.localUtil.Format( (decimal)(AV6cResponsableId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresponsableid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresponsableid_Visible, edtavCresponsableid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divResponsableidentidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsableidentidadfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsableidentidadfilter_Internalname, "Identidad", "", "", lblLblresponsableidentidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresponsableidentidad_Internalname, "Identidad", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresponsableidentidad_Internalname, AV7cResponsableIdentidad, StringUtil.RTrim( context.localUtil.Format( AV7cResponsableIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresponsableidentidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresponsableidentidad_Visible, edtavCresponsableidentidad_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divResponsablenombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsablenombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsablenombrefilter_Internalname, "Técnico", "", "", lblLblresponsablenombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresponsablenombre_Internalname, "Técnico", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresponsablenombre_Internalname, AV8cResponsableNombre, StringUtil.RTrim( context.localUtil.Format( AV8cResponsableNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresponsablenombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresponsablenombre_Visible, edtavCresponsablenombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divResponsableemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsableemailfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsableemailfilter_Internalname, "Email", "", "", lblLblresponsableemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresponsableemail_Internalname, "Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresponsableemail_Internalname, AV9cResponsableEmail, StringUtil.RTrim( context.localUtil.Format( AV9cResponsableEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresponsableemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresponsableemail_Visible, edtavCresponsableemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divResponsableactivofiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsableactivofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsableactivofilter_Internalname, "Estado", "", "", lblLblresponsableactivofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCresponsableactivo_Internalname, "Estado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCresponsableactivo_Internalname, StringUtil.BoolToStr( AV10cResponsableActivo), "", "Estado", chkavCresponsableactivo.Visible, chkavCresponsableactivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,56);\"");
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
            GxWebStd.gx_div_start( context, divResponsableusuariofiltercontainer_Internalname, 1, 0, "px", 0, "px", divResponsableusuariofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblresponsableusuariofilter_Internalname, "Usuario Sistema", "", "", lblLblresponsableusuariofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCresponsableusuario_Internalname, "Usuario Sistema", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCresponsableusuario_Internalname, AV13cResponsableUsuario, StringUtil.RTrim( context.localUtil.Format( AV13cResponsableUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCresponsableusuario_Jsonclick, 0, "Attribute", "", "", "", "", edtavCresponsableusuario_Visible, edtavCresponsableusuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "", "left", true, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_div_start( context, divEstadoresponsableidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadoresponsableidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadoresponsableidfilter_Internalname, "Estado Responsable Id", "", "", lblLblestadoresponsableidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17081_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0050.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadoresponsableid_Internalname, "Estado Responsable Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadoresponsableid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cEstadoResponsableId), 4, 0, ",", "")), ((edtavCestadoresponsableid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14cEstadoResponsableId), "ZZZ9")) : context.localUtil.Format( (decimal)(AV14cEstadoResponsableId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadoresponsableid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadoresponsableid_Visible, edtavCestadoresponsableid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx0050.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18081_client"+"'", TempTags, "", 2, "HLP_Gx0050.htm");
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
               context.SendWebValue( "Id Técnico:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Identidad Técnico:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Técnico:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Estado:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "id_unidad") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A29ResponsableIdentidad);
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtResponsableIdentidad_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A30ResponsableNombre);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.BoolToStr( A26ResponsableActivo));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0050.htm");
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

      protected void START082( )
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
         STRUP080( ) ;
      }

      protected void WS082( )
      {
         START082( ) ;
         EVT082( ) ;
      }

      protected void EVT082( )
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
                              A6ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", "."));
                              A29ResponsableIdentidad = cgiGet( edtResponsableIdentidad_Internalname);
                              A30ResponsableNombre = cgiGet( edtResponsableNombre_Internalname);
                              A26ResponsableActivo = StringUtil.StrToBool( cgiGet( chkResponsableActivo_Internalname));
                              A103id_unidad = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20082 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cresponsableid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV6cResponsableId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresponsableidentidad Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLEIDENTIDAD"), AV7cResponsableIdentidad) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresponsablenombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLENOMBRE"), AV8cResponsableNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresponsableemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLEEMAIL"), AV9cResponsableEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresponsableactivo Changed */
                                       if ( StringUtil.StrToBool( cgiGet( "GXH_vCRESPONSABLEACTIVO")) != AV10cResponsableActivo )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cresponsableusuario Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLEUSUARIO"), AV13cResponsableUsuario) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadoresponsableid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADORESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV14cEstadoResponsableId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21082 ();
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

      protected void WE082( )
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

      protected void PA082( )
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
                                        short AV6cResponsableId ,
                                        string AV7cResponsableIdentidad ,
                                        string AV8cResponsableNombre ,
                                        string AV9cResponsableEmail ,
                                        bool AV10cResponsableActivo ,
                                        string AV13cResponsableUsuario ,
                                        short AV14cEstadoResponsableId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF082( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
         AV10cResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cResponsableActivo));
         AssignAttri("", false, "AV10cResponsableActivo", AV10cResponsableActivo);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF082( ) ;
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

      protected void RF082( )
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
                                                 AV7cResponsableIdentidad ,
                                                 AV8cResponsableNombre ,
                                                 AV9cResponsableEmail ,
                                                 AV10cResponsableActivo ,
                                                 AV13cResponsableUsuario ,
                                                 AV14cEstadoResponsableId ,
                                                 A29ResponsableIdentidad ,
                                                 A30ResponsableNombre ,
                                                 A28ResponsableEmail ,
                                                 A26ResponsableActivo ,
                                                 A96ResponsableUsuario ,
                                                 A194EstadoResponsableId ,
                                                 AV6cResponsableId } ,
                                                 new int[]{
                                                 TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cResponsableIdentidad = StringUtil.Concat( StringUtil.RTrim( AV7cResponsableIdentidad), "%", "");
            lV8cResponsableNombre = StringUtil.Concat( StringUtil.RTrim( AV8cResponsableNombre), "%", "");
            lV9cResponsableEmail = StringUtil.Concat( StringUtil.RTrim( AV9cResponsableEmail), "%", "");
            lV13cResponsableUsuario = StringUtil.Concat( StringUtil.RTrim( AV13cResponsableUsuario), "%", "");
            /* Using cursor H00082 */
            pr_default.execute(0, new Object[] {AV6cResponsableId, lV7cResponsableIdentidad, lV8cResponsableNombre, lV9cResponsableEmail, AV10cResponsableActivo, lV13cResponsableUsuario, AV14cEstadoResponsableId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A194EstadoResponsableId = H00082_A194EstadoResponsableId[0];
               A96ResponsableUsuario = H00082_A96ResponsableUsuario[0];
               A28ResponsableEmail = H00082_A28ResponsableEmail[0];
               A103id_unidad = H00082_A103id_unidad[0];
               A26ResponsableActivo = H00082_A26ResponsableActivo[0];
               A30ResponsableNombre = H00082_A30ResponsableNombre[0];
               A29ResponsableIdentidad = H00082_A29ResponsableIdentidad[0];
               A6ResponsableId = H00082_A6ResponsableId[0];
               /* Execute user event: Load */
               E20082 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB080( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes082( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_RESPONSABLEID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9"), context));
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
                                              AV7cResponsableIdentidad ,
                                              AV8cResponsableNombre ,
                                              AV9cResponsableEmail ,
                                              AV10cResponsableActivo ,
                                              AV13cResponsableUsuario ,
                                              AV14cEstadoResponsableId ,
                                              A29ResponsableIdentidad ,
                                              A30ResponsableNombre ,
                                              A28ResponsableEmail ,
                                              A26ResponsableActivo ,
                                              A96ResponsableUsuario ,
                                              A194EstadoResponsableId ,
                                              AV6cResponsableId } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cResponsableIdentidad = StringUtil.Concat( StringUtil.RTrim( AV7cResponsableIdentidad), "%", "");
         lV8cResponsableNombre = StringUtil.Concat( StringUtil.RTrim( AV8cResponsableNombre), "%", "");
         lV9cResponsableEmail = StringUtil.Concat( StringUtil.RTrim( AV9cResponsableEmail), "%", "");
         lV13cResponsableUsuario = StringUtil.Concat( StringUtil.RTrim( AV13cResponsableUsuario), "%", "");
         /* Using cursor H00083 */
         pr_default.execute(1, new Object[] {AV6cResponsableId, lV7cResponsableIdentidad, lV8cResponsableNombre, lV9cResponsableEmail, AV10cResponsableActivo, lV13cResponsableUsuario, AV14cEstadoResponsableId});
         GRID1_nRecordCount = H00083_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResponsableId, AV7cResponsableIdentidad, AV8cResponsableNombre, AV9cResponsableEmail, AV10cResponsableActivo, AV13cResponsableUsuario, AV14cEstadoResponsableId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResponsableId, AV7cResponsableIdentidad, AV8cResponsableNombre, AV9cResponsableEmail, AV10cResponsableActivo, AV13cResponsableUsuario, AV14cEstadoResponsableId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResponsableId, AV7cResponsableIdentidad, AV8cResponsableNombre, AV9cResponsableEmail, AV10cResponsableActivo, AV13cResponsableUsuario, AV14cEstadoResponsableId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResponsableId, AV7cResponsableIdentidad, AV8cResponsableNombre, AV9cResponsableEmail, AV10cResponsableActivo, AV13cResponsableUsuario, AV14cEstadoResponsableId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cResponsableId, AV7cResponsableIdentidad, AV8cResponsableNombre, AV9cResponsableEmail, AV10cResponsableActivo, AV13cResponsableUsuario, AV14cEstadoResponsableId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP080( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19082 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCresponsableid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCresponsableid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCRESPONSABLEID");
               GX_FocusControl = edtavCresponsableid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cResponsableId = 0;
               AssignAttri("", false, "AV6cResponsableId", StringUtil.LTrimStr( (decimal)(AV6cResponsableId), 4, 0));
            }
            else
            {
               AV6cResponsableId = (short)(context.localUtil.CToN( cgiGet( edtavCresponsableid_Internalname), ",", "."));
               AssignAttri("", false, "AV6cResponsableId", StringUtil.LTrimStr( (decimal)(AV6cResponsableId), 4, 0));
            }
            AV7cResponsableIdentidad = cgiGet( edtavCresponsableidentidad_Internalname);
            AssignAttri("", false, "AV7cResponsableIdentidad", AV7cResponsableIdentidad);
            AV8cResponsableNombre = cgiGet( edtavCresponsablenombre_Internalname);
            AssignAttri("", false, "AV8cResponsableNombre", AV8cResponsableNombre);
            AV9cResponsableEmail = cgiGet( edtavCresponsableemail_Internalname);
            AssignAttri("", false, "AV9cResponsableEmail", AV9cResponsableEmail);
            AV10cResponsableActivo = StringUtil.StrToBool( cgiGet( chkavCresponsableactivo_Internalname));
            AssignAttri("", false, "AV10cResponsableActivo", AV10cResponsableActivo);
            AV13cResponsableUsuario = cgiGet( edtavCresponsableusuario_Internalname);
            AssignAttri("", false, "AV13cResponsableUsuario", AV13cResponsableUsuario);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCestadoresponsableid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCestadoresponsableid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESTADORESPONSABLEID");
               GX_FocusControl = edtavCestadoresponsableid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14cEstadoResponsableId = 0;
               AssignAttri("", false, "AV14cEstadoResponsableId", StringUtil.LTrimStr( (decimal)(AV14cEstadoResponsableId), 4, 0));
            }
            else
            {
               AV14cEstadoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtavCestadoresponsableid_Internalname), ",", "."));
               AssignAttri("", false, "AV14cEstadoResponsableId", StringUtil.LTrimStr( (decimal)(AV14cEstadoResponsableId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCRESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV6cResponsableId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLEIDENTIDAD"), AV7cResponsableIdentidad) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLENOMBRE"), AV8cResponsableNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLEEMAIL"), AV9cResponsableEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrToBool( cgiGet( "GXH_vCRESPONSABLEACTIVO")) != AV10cResponsableActivo )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCRESPONSABLEUSUARIO"), AV13cResponsableUsuario) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADORESPONSABLEID"), ",", ".") != Convert.ToDecimal( AV14cEstadoResponsableId )) )
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
         E19082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19082( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Responsable", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV12ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20082( )
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
         E21082 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21082( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV11pResponsableId = A6ResponsableId;
         AssignAttri("", false, "AV11pResponsableId", StringUtil.LTrimStr( (decimal)(AV11pResponsableId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV11pResponsableId});
         context.setWebReturnParmsMetadata(new Object[] {"AV11pResponsableId"});
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
         AV11pResponsableId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV11pResponsableId", StringUtil.LTrimStr( (decimal)(AV11pResponsableId), 4, 0));
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
         PA082( ) ;
         WS082( ) ;
         WE082( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249571810", true, true);
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
         context.AddJavascriptSource("gx0050.js", "?20231249571811", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_84_idx;
         edtResponsableIdentidad_Internalname = "RESPONSABLEIDENTIDAD_"+sGXsfl_84_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_84_idx;
         chkResponsableActivo_Internalname = "RESPONSABLEACTIVO_"+sGXsfl_84_idx;
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtResponsableId_Internalname = "RESPONSABLEID_"+sGXsfl_84_fel_idx;
         edtResponsableIdentidad_Internalname = "RESPONSABLEIDENTIDAD_"+sGXsfl_84_fel_idx;
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE_"+sGXsfl_84_fel_idx;
         chkResponsableActivo_Internalname = "RESPONSABLEACTIVO_"+sGXsfl_84_fel_idx;
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB080( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ",", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtResponsableIdentidad_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtResponsableIdentidad_Internalname, "Link", edtResponsableIdentidad_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableIdentidad_Internalname,(string)A29ResponsableIdentidad,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtResponsableIdentidad_Link,(string)"",(string)"",(string)"",(string)edtResponsableIdentidad_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtResponsableNombre_Internalname,(string)A30ResponsableNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtResponsableNombre_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "RESPONSABLEACTIVO_" + sGXsfl_84_idx;
            chkResponsableActivo.Name = GXCCtl;
            chkResponsableActivo.WebTags = "";
            chkResponsableActivo.Caption = "";
            AssignProp("", false, chkResponsableActivo_Internalname, "TitleCaption", chkResponsableActivo.Caption, !bGXsfl_84_Refreshing);
            chkResponsableActivo.CheckedValue = "false";
            A26ResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A26ResponsableActivo));
            Grid1Row.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkResponsableActivo_Internalname,StringUtil.BoolToStr( A26ResponsableActivo),(string)"",(string)"",(short)-1,(short)0,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_unidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_unidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes082( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         chkavCresponsableactivo.Name = "vCRESPONSABLEACTIVO";
         chkavCresponsableactivo.WebTags = "";
         chkavCresponsableactivo.Caption = "";
         AssignProp("", false, chkavCresponsableactivo_Internalname, "TitleCaption", chkavCresponsableactivo.Caption, true);
         chkavCresponsableactivo.CheckedValue = "false";
         AV10cResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( AV10cResponsableActivo));
         AssignAttri("", false, "AV10cResponsableActivo", AV10cResponsableActivo);
         GXCCtl = "RESPONSABLEACTIVO_" + sGXsfl_84_idx;
         chkResponsableActivo.Name = GXCCtl;
         chkResponsableActivo.WebTags = "";
         chkResponsableActivo.Caption = "";
         AssignProp("", false, chkResponsableActivo_Internalname, "TitleCaption", chkResponsableActivo.Caption, !bGXsfl_84_Refreshing);
         chkResponsableActivo.CheckedValue = "false";
         A26ResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A26ResponsableActivo));
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblresponsableidfilter_Internalname = "LBLRESPONSABLEIDFILTER";
         edtavCresponsableid_Internalname = "vCRESPONSABLEID";
         divResponsableidfiltercontainer_Internalname = "RESPONSABLEIDFILTERCONTAINER";
         lblLblresponsableidentidadfilter_Internalname = "LBLRESPONSABLEIDENTIDADFILTER";
         edtavCresponsableidentidad_Internalname = "vCRESPONSABLEIDENTIDAD";
         divResponsableidentidadfiltercontainer_Internalname = "RESPONSABLEIDENTIDADFILTERCONTAINER";
         lblLblresponsablenombrefilter_Internalname = "LBLRESPONSABLENOMBREFILTER";
         edtavCresponsablenombre_Internalname = "vCRESPONSABLENOMBRE";
         divResponsablenombrefiltercontainer_Internalname = "RESPONSABLENOMBREFILTERCONTAINER";
         lblLblresponsableemailfilter_Internalname = "LBLRESPONSABLEEMAILFILTER";
         edtavCresponsableemail_Internalname = "vCRESPONSABLEEMAIL";
         divResponsableemailfiltercontainer_Internalname = "RESPONSABLEEMAILFILTERCONTAINER";
         lblLblresponsableactivofilter_Internalname = "LBLRESPONSABLEACTIVOFILTER";
         chkavCresponsableactivo_Internalname = "vCRESPONSABLEACTIVO";
         divResponsableactivofiltercontainer_Internalname = "RESPONSABLEACTIVOFILTERCONTAINER";
         lblLblresponsableusuariofilter_Internalname = "LBLRESPONSABLEUSUARIOFILTER";
         edtavCresponsableusuario_Internalname = "vCRESPONSABLEUSUARIO";
         divResponsableusuariofiltercontainer_Internalname = "RESPONSABLEUSUARIOFILTERCONTAINER";
         lblLblestadoresponsableidfilter_Internalname = "LBLESTADORESPONSABLEIDFILTER";
         edtavCestadoresponsableid_Internalname = "vCESTADORESPONSABLEID";
         divEstadoresponsableidfiltercontainer_Internalname = "ESTADORESPONSABLEIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtResponsableId_Internalname = "RESPONSABLEID";
         edtResponsableIdentidad_Internalname = "RESPONSABLEIDENTIDAD";
         edtResponsableNombre_Internalname = "RESPONSABLENOMBRE";
         chkResponsableActivo_Internalname = "RESPONSABLEACTIVO";
         edtid_unidad_Internalname = "ID_UNIDAD";
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
         chkavCresponsableactivo.Caption = "Estado";
         edtid_unidad_Jsonclick = "";
         chkResponsableActivo.Caption = "";
         edtResponsableNombre_Jsonclick = "";
         edtResponsableIdentidad_Jsonclick = "";
         edtResponsableId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtResponsableIdentidad_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCestadoresponsableid_Jsonclick = "";
         edtavCestadoresponsableid_Enabled = 1;
         edtavCestadoresponsableid_Visible = 1;
         edtavCresponsableusuario_Jsonclick = "";
         edtavCresponsableusuario_Enabled = 1;
         edtavCresponsableusuario_Visible = 1;
         chkavCresponsableactivo.Enabled = 1;
         chkavCresponsableactivo.Visible = 1;
         edtavCresponsableemail_Jsonclick = "";
         edtavCresponsableemail_Enabled = 1;
         edtavCresponsableemail_Visible = 1;
         edtavCresponsablenombre_Jsonclick = "";
         edtavCresponsablenombre_Enabled = 1;
         edtavCresponsablenombre_Visible = 1;
         edtavCresponsableidentidad_Jsonclick = "";
         edtavCresponsableidentidad_Enabled = 1;
         edtavCresponsableidentidad_Visible = 1;
         edtavCresponsableid_Jsonclick = "";
         edtavCresponsableid_Enabled = 1;
         edtavCresponsableid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Responsable";
         divEstadoresponsableidfiltercontainer_Class = "AdvancedContainerItem";
         divResponsableusuariofiltercontainer_Class = "AdvancedContainerItem";
         divResponsableactivofiltercontainer_Class = "AdvancedContainerItem";
         divResponsableemailfiltercontainer_Class = "AdvancedContainerItem";
         divResponsablenombrefiltercontainer_Class = "AdvancedContainerItem";
         divResponsableidentidadfiltercontainer_Class = "AdvancedContainerItem";
         divResponsableidfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV7cResponsableIdentidad',fld:'vCRESPONSABLEIDENTIDAD',pic:''},{av:'AV8cResponsableNombre',fld:'vCRESPONSABLENOMBRE',pic:''},{av:'AV9cResponsableEmail',fld:'vCRESPONSABLEEMAIL',pic:''},{av:'AV13cResponsableUsuario',fld:'vCRESPONSABLEUSUARIO',pic:''},{av:'AV14cEstadoResponsableId',fld:'vCESTADORESPONSABLEID',pic:'ZZZ9'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("'TOGGLE'","{handler:'E18081',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLRESPONSABLEIDFILTER.CLICK","{handler:'E11081',iparms:[{av:'divResponsableidfiltercontainer_Class',ctrl:'RESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLRESPONSABLEIDFILTER.CLICK",",oparms:[{av:'divResponsableidfiltercontainer_Class',ctrl:'RESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCresponsableid_Visible',ctrl:'vCRESPONSABLEID',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLRESPONSABLEIDENTIDADFILTER.CLICK","{handler:'E12081',iparms:[{av:'divResponsableidentidadfiltercontainer_Class',ctrl:'RESPONSABLEIDENTIDADFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLRESPONSABLEIDENTIDADFILTER.CLICK",",oparms:[{av:'divResponsableidentidadfiltercontainer_Class',ctrl:'RESPONSABLEIDENTIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCresponsableidentidad_Visible',ctrl:'vCRESPONSABLEIDENTIDAD',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLRESPONSABLENOMBREFILTER.CLICK","{handler:'E13081',iparms:[{av:'divResponsablenombrefiltercontainer_Class',ctrl:'RESPONSABLENOMBREFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLRESPONSABLENOMBREFILTER.CLICK",",oparms:[{av:'divResponsablenombrefiltercontainer_Class',ctrl:'RESPONSABLENOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCresponsablenombre_Visible',ctrl:'vCRESPONSABLENOMBRE',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLRESPONSABLEEMAILFILTER.CLICK","{handler:'E14081',iparms:[{av:'divResponsableemailfiltercontainer_Class',ctrl:'RESPONSABLEEMAILFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLRESPONSABLEEMAILFILTER.CLICK",",oparms:[{av:'divResponsableemailfiltercontainer_Class',ctrl:'RESPONSABLEEMAILFILTERCONTAINER',prop:'Class'},{av:'edtavCresponsableemail_Visible',ctrl:'vCRESPONSABLEEMAIL',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLRESPONSABLEACTIVOFILTER.CLICK","{handler:'E15081',iparms:[{av:'divResponsableactivofiltercontainer_Class',ctrl:'RESPONSABLEACTIVOFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLRESPONSABLEACTIVOFILTER.CLICK",",oparms:[{av:'divResponsableactivofiltercontainer_Class',ctrl:'RESPONSABLEACTIVOFILTERCONTAINER',prop:'Class'},{av:'chkavCresponsableactivo.Visible',ctrl:'vCRESPONSABLEACTIVO',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLRESPONSABLEUSUARIOFILTER.CLICK","{handler:'E16081',iparms:[{av:'divResponsableusuariofiltercontainer_Class',ctrl:'RESPONSABLEUSUARIOFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLRESPONSABLEUSUARIOFILTER.CLICK",",oparms:[{av:'divResponsableusuariofiltercontainer_Class',ctrl:'RESPONSABLEUSUARIOFILTERCONTAINER',prop:'Class'},{av:'edtavCresponsableusuario_Visible',ctrl:'vCRESPONSABLEUSUARIO',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("LBLESTADORESPONSABLEIDFILTER.CLICK","{handler:'E17081',iparms:[{av:'divEstadoresponsableidfiltercontainer_Class',ctrl:'ESTADORESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("LBLESTADORESPONSABLEIDFILTER.CLICK",",oparms:[{av:'divEstadoresponsableidfiltercontainer_Class',ctrl:'ESTADORESPONSABLEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCestadoresponsableid_Visible',ctrl:'vCESTADORESPONSABLEID',prop:'Visible'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E21082',iparms:[{av:'A6ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV11pResponsableId',fld:'vPRESPONSABLEID',pic:'ZZZ9'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV7cResponsableIdentidad',fld:'vCRESPONSABLEIDENTIDAD',pic:''},{av:'AV8cResponsableNombre',fld:'vCRESPONSABLENOMBRE',pic:''},{av:'AV9cResponsableEmail',fld:'vCRESPONSABLEEMAIL',pic:''},{av:'AV13cResponsableUsuario',fld:'vCRESPONSABLEUSUARIO',pic:''},{av:'AV14cEstadoResponsableId',fld:'vCESTADORESPONSABLEID',pic:'ZZZ9'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV7cResponsableIdentidad',fld:'vCRESPONSABLEIDENTIDAD',pic:''},{av:'AV8cResponsableNombre',fld:'vCRESPONSABLENOMBRE',pic:''},{av:'AV9cResponsableEmail',fld:'vCRESPONSABLEEMAIL',pic:''},{av:'AV13cResponsableUsuario',fld:'vCRESPONSABLEUSUARIO',pic:''},{av:'AV14cEstadoResponsableId',fld:'vCESTADORESPONSABLEID',pic:'ZZZ9'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV7cResponsableIdentidad',fld:'vCRESPONSABLEIDENTIDAD',pic:''},{av:'AV8cResponsableNombre',fld:'vCRESPONSABLENOMBRE',pic:''},{av:'AV9cResponsableEmail',fld:'vCRESPONSABLEEMAIL',pic:''},{av:'AV13cResponsableUsuario',fld:'vCRESPONSABLEUSUARIO',pic:''},{av:'AV14cEstadoResponsableId',fld:'vCESTADORESPONSABLEID',pic:'ZZZ9'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cResponsableId',fld:'vCRESPONSABLEID',pic:'ZZZ9'},{av:'AV7cResponsableIdentidad',fld:'vCRESPONSABLEIDENTIDAD',pic:''},{av:'AV8cResponsableNombre',fld:'vCRESPONSABLENOMBRE',pic:''},{av:'AV9cResponsableEmail',fld:'vCRESPONSABLEEMAIL',pic:''},{av:'AV13cResponsableUsuario',fld:'vCRESPONSABLEUSUARIO',pic:''},{av:'AV14cEstadoResponsableId',fld:'vCESTADORESPONSABLEID',pic:'ZZZ9'},{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("VALIDV_CRESPONSABLEEMAIL","{handler:'Validv_Cresponsableemail',iparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("VALIDV_CRESPONSABLEEMAIL",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Id_unidad',iparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV10cResponsableActivo',fld:'vCRESPONSABLEACTIVO',pic:''}]}");
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
         AV7cResponsableIdentidad = "";
         AV8cResponsableNombre = "";
         AV9cResponsableEmail = "";
         AV13cResponsableUsuario = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblresponsableidfilter_Jsonclick = "";
         TempTags = "";
         lblLblresponsableidentidadfilter_Jsonclick = "";
         lblLblresponsablenombrefilter_Jsonclick = "";
         lblLblresponsableemailfilter_Jsonclick = "";
         lblLblresponsableactivofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblLblresponsableusuariofilter_Jsonclick = "";
         lblLblestadoresponsableidfilter_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A29ResponsableIdentidad = "";
         A30ResponsableNombre = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV7cResponsableIdentidad = "";
         lV8cResponsableNombre = "";
         lV9cResponsableEmail = "";
         lV13cResponsableUsuario = "";
         A28ResponsableEmail = "";
         A96ResponsableUsuario = "";
         H00082_A194EstadoResponsableId = new short[1] ;
         H00082_A96ResponsableUsuario = new string[] {""} ;
         H00082_A28ResponsableEmail = new string[] {""} ;
         H00082_A103id_unidad = new int[1] ;
         H00082_A26ResponsableActivo = new bool[] {false} ;
         H00082_A30ResponsableNombre = new string[] {""} ;
         H00082_A29ResponsableIdentidad = new string[] {""} ;
         H00082_A6ResponsableId = new short[1] ;
         H00083_AGRID1_nRecordCount = new long[1] ;
         AV12ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         GXCCtl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0050__default(),
            new Object[][] {
                new Object[] {
               H00082_A194EstadoResponsableId, H00082_A96ResponsableUsuario, H00082_A28ResponsableEmail, H00082_A103id_unidad, H00082_A26ResponsableActivo, H00082_A30ResponsableNombre, H00082_A29ResponsableIdentidad, H00082_A6ResponsableId
               }
               , new Object[] {
               H00083_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV11pResponsableId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cResponsableId ;
      private short AV14cEstadoResponsableId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A6ResponsableId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A194EstadoResponsableId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int edtavCresponsableid_Enabled ;
      private int edtavCresponsableid_Visible ;
      private int edtavCresponsableidentidad_Visible ;
      private int edtavCresponsableidentidad_Enabled ;
      private int edtavCresponsablenombre_Visible ;
      private int edtavCresponsablenombre_Enabled ;
      private int edtavCresponsableemail_Visible ;
      private int edtavCresponsableemail_Enabled ;
      private int edtavCresponsableusuario_Visible ;
      private int edtavCresponsableusuario_Enabled ;
      private int edtavCestadoresponsableid_Enabled ;
      private int edtavCestadoresponsableid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A103id_unidad ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divResponsableidfiltercontainer_Class ;
      private string divResponsableidentidadfiltercontainer_Class ;
      private string divResponsablenombrefiltercontainer_Class ;
      private string divResponsableemailfiltercontainer_Class ;
      private string divResponsableactivofiltercontainer_Class ;
      private string divResponsableusuariofiltercontainer_Class ;
      private string divEstadoresponsableidfiltercontainer_Class ;
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
      private string divResponsableidfiltercontainer_Internalname ;
      private string lblLblresponsableidfilter_Internalname ;
      private string lblLblresponsableidfilter_Jsonclick ;
      private string edtavCresponsableid_Internalname ;
      private string TempTags ;
      private string edtavCresponsableid_Jsonclick ;
      private string divResponsableidentidadfiltercontainer_Internalname ;
      private string lblLblresponsableidentidadfilter_Internalname ;
      private string lblLblresponsableidentidadfilter_Jsonclick ;
      private string edtavCresponsableidentidad_Internalname ;
      private string edtavCresponsableidentidad_Jsonclick ;
      private string divResponsablenombrefiltercontainer_Internalname ;
      private string lblLblresponsablenombrefilter_Internalname ;
      private string lblLblresponsablenombrefilter_Jsonclick ;
      private string edtavCresponsablenombre_Internalname ;
      private string edtavCresponsablenombre_Jsonclick ;
      private string divResponsableemailfiltercontainer_Internalname ;
      private string lblLblresponsableemailfilter_Internalname ;
      private string lblLblresponsableemailfilter_Jsonclick ;
      private string edtavCresponsableemail_Internalname ;
      private string edtavCresponsableemail_Jsonclick ;
      private string divResponsableactivofiltercontainer_Internalname ;
      private string lblLblresponsableactivofilter_Internalname ;
      private string lblLblresponsableactivofilter_Jsonclick ;
      private string chkavCresponsableactivo_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divResponsableusuariofiltercontainer_Internalname ;
      private string lblLblresponsableusuariofilter_Internalname ;
      private string lblLblresponsableusuariofilter_Jsonclick ;
      private string edtavCresponsableusuario_Internalname ;
      private string edtavCresponsableusuario_Jsonclick ;
      private string divEstadoresponsableidfiltercontainer_Internalname ;
      private string lblLblestadoresponsableidfilter_Internalname ;
      private string lblLblestadoresponsableidfilter_Jsonclick ;
      private string edtavCestadoresponsableid_Internalname ;
      private string edtavCestadoresponsableid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string edtavLinkselection_Link ;
      private string edtResponsableIdentidad_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtResponsableId_Internalname ;
      private string edtResponsableIdentidad_Internalname ;
      private string edtResponsableNombre_Internalname ;
      private string chkResponsableActivo_Internalname ;
      private string edtid_unidad_Internalname ;
      private string scmdbuf ;
      private string AV12ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtResponsableId_Jsonclick ;
      private string edtResponsableIdentidad_Jsonclick ;
      private string edtResponsableNombre_Jsonclick ;
      private string GXCCtl ;
      private string edtid_unidad_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV10cResponsableActivo ;
      private bool wbLoad ;
      private bool A26ResponsableActivo ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cResponsableIdentidad ;
      private string AV8cResponsableNombre ;
      private string AV9cResponsableEmail ;
      private string AV13cResponsableUsuario ;
      private string A29ResponsableIdentidad ;
      private string A30ResponsableNombre ;
      private string AV17Linkselection_GXI ;
      private string lV7cResponsableIdentidad ;
      private string lV8cResponsableNombre ;
      private string lV9cResponsableEmail ;
      private string lV13cResponsableUsuario ;
      private string A28ResponsableEmail ;
      private string A96ResponsableUsuario ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavCresponsableactivo ;
      private GXCheckbox chkResponsableActivo ;
      private IDataStoreProvider pr_default ;
      private short[] H00082_A194EstadoResponsableId ;
      private string[] H00082_A96ResponsableUsuario ;
      private string[] H00082_A28ResponsableEmail ;
      private int[] H00082_A103id_unidad ;
      private bool[] H00082_A26ResponsableActivo ;
      private string[] H00082_A30ResponsableNombre ;
      private string[] H00082_A29ResponsableIdentidad ;
      private short[] H00082_A6ResponsableId ;
      private long[] H00083_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pResponsableId ;
      private GXWebForm Form ;
   }

   public class gx0050__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00082( IGxContext context ,
                                             string AV7cResponsableIdentidad ,
                                             string AV8cResponsableNombre ,
                                             string AV9cResponsableEmail ,
                                             bool AV10cResponsableActivo ,
                                             string AV13cResponsableUsuario ,
                                             short AV14cEstadoResponsableId ,
                                             string A29ResponsableIdentidad ,
                                             string A30ResponsableNombre ,
                                             string A28ResponsableEmail ,
                                             bool A26ResponsableActivo ,
                                             string A96ResponsableUsuario ,
                                             short A194EstadoResponsableId ,
                                             short AV6cResponsableId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [EstadoResponsableId], [ResponsableUsuario], [ResponsableEmail], [id_unidad], [ResponsableActivo], [ResponsableNombre], [ResponsableIdentidad], [ResponsableId]";
         sFromString = " FROM [Responsable]";
         sOrderString = "";
         AddWhere(sWhereString, "([ResponsableId] >= @AV6cResponsableId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cResponsableIdentidad)) )
         {
            AddWhere(sWhereString, "([ResponsableIdentidad] like @lV7cResponsableIdentidad)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cResponsableNombre)) )
         {
            AddWhere(sWhereString, "([ResponsableNombre] like @lV8cResponsableNombre)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResponsableEmail)) )
         {
            AddWhere(sWhereString, "([ResponsableEmail] like @lV9cResponsableEmail)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (false==AV10cResponsableActivo) )
         {
            AddWhere(sWhereString, "([ResponsableActivo] >= @AV10cResponsableActivo)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cResponsableUsuario)) )
         {
            AddWhere(sWhereString, "([ResponsableUsuario] like @lV13cResponsableUsuario)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV14cEstadoResponsableId) )
         {
            AddWhere(sWhereString, "([EstadoResponsableId] >= @AV14cEstadoResponsableId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ResponsableId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00083( IGxContext context ,
                                             string AV7cResponsableIdentidad ,
                                             string AV8cResponsableNombre ,
                                             string AV9cResponsableEmail ,
                                             bool AV10cResponsableActivo ,
                                             string AV13cResponsableUsuario ,
                                             short AV14cEstadoResponsableId ,
                                             string A29ResponsableIdentidad ,
                                             string A30ResponsableNombre ,
                                             string A28ResponsableEmail ,
                                             bool A26ResponsableActivo ,
                                             string A96ResponsableUsuario ,
                                             short A194EstadoResponsableId ,
                                             short AV6cResponsableId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Responsable]";
         AddWhere(sWhereString, "([ResponsableId] >= @AV6cResponsableId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cResponsableIdentidad)) )
         {
            AddWhere(sWhereString, "([ResponsableIdentidad] like @lV7cResponsableIdentidad)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cResponsableNombre)) )
         {
            AddWhere(sWhereString, "([ResponsableNombre] like @lV8cResponsableNombre)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cResponsableEmail)) )
         {
            AddWhere(sWhereString, "([ResponsableEmail] like @lV9cResponsableEmail)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (false==AV10cResponsableActivo) )
         {
            AddWhere(sWhereString, "([ResponsableActivo] >= @AV10cResponsableActivo)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13cResponsableUsuario)) )
         {
            AddWhere(sWhereString, "([ResponsableUsuario] like @lV13cResponsableUsuario)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV14cEstadoResponsableId) )
         {
            AddWhere(sWhereString, "([EstadoResponsableId] >= @AV14cEstadoResponsableId)");
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
                     return conditional_H00082(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00083(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH00082;
          prmH00082 = new Object[] {
          new ParDef("@AV6cResponsableId",GXType.Int16,4,0) ,
          new ParDef("@lV7cResponsableIdentidad",GXType.NVarChar,30,0) ,
          new ParDef("@lV8cResponsableNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV9cResponsableEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV10cResponsableActivo",GXType.Boolean,4,0) ,
          new ParDef("@lV13cResponsableUsuario",GXType.NVarChar,100,60) ,
          new ParDef("@AV14cEstadoResponsableId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00083;
          prmH00083 = new Object[] {
          new ParDef("@AV6cResponsableId",GXType.Int16,4,0) ,
          new ParDef("@lV7cResponsableIdentidad",GXType.NVarChar,30,0) ,
          new ParDef("@lV8cResponsableNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV9cResponsableEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV10cResponsableActivo",GXType.Boolean,4,0) ,
          new ParDef("@lV13cResponsableUsuario",GXType.NVarChar,100,60) ,
          new ParDef("@AV14cEstadoResponsableId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00082", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00082,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00083", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00083,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
