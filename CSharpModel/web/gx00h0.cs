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
   public class gx00h0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00h0( )
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

      public gx00h0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pcorrelativo )
      {
         this.AV13pcorrelativo = 0 ;
         executePrivate();
         aP0_pcorrelativo=this.AV13pcorrelativo;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "pcorrelativo");
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
               gxfirstwebparm = GetFirstPar( "pcorrelativo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pcorrelativo");
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
               AV6ccorrelativo = (int)(NumberUtil.Val( GetPar( "ccorrelativo"), "."));
               AV7ccargo_emp = GetPar( "ccargo_emp");
               AV8cfecha_registro = context.localUtil.ParseDateParm( GetPar( "cfecha_registro"));
               AV9chora_registro = context.localUtil.ParseDTimeParm( GetPar( "chora_registro"));
               AV10cestatus = GetPar( "cestatus");
               AV16cdetalle_infotecid_unidad = (int)(NumberUtil.Val( GetPar( "cdetalle_infotecid_unidad"), "."));
               AV12cid_categoria = (int)(NumberUtil.Val( GetPar( "cid_categoria"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6ccorrelativo, AV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, AV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria) ;
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
               AV13pcorrelativo = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pcorrelativo", StringUtil.LTrimStr( (decimal)(AV13pcorrelativo), 9, 0));
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
            return "gx00h0_Execute" ;
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
         PA5X2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5X2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188224874", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pcorrelativo,9,0))}, new string[] {"pcorrelativo"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCORRELATIVO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ccorrelativo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCARGO_EMP", AV7ccargo_emp);
         GxWebStd.gx_hidden_field( context, "GXH_vCFECHA_REGISTRO", context.localUtil.Format(AV8cfecha_registro, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCHORA_REGISTRO", context.localUtil.TToC( AV9chora_registro, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTATUS", AV10cestatus);
         GxWebStd.gx_hidden_field( context, "GXH_vCDETALLE_INFOTECID_UNIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cdetalle_infotecid_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCID_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cid_categoria), 9, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCORRELATIVO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pcorrelativo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CORRELATIVOFILTERCONTAINER_Class", StringUtil.RTrim( divCorrelativofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CARGO_EMPFILTERCONTAINER_Class", StringUtil.RTrim( divCargo_empfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FECHA_REGISTROFILTERCONTAINER_Class", StringUtil.RTrim( divFecha_registrofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "HORA_REGISTROFILTERCONTAINER_Class", StringUtil.RTrim( divHora_registrofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTATUSFILTERCONTAINER_Class", StringUtil.RTrim( divEstatusfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DETALLE_INFOTECID_UNIDADFILTERCONTAINER_Class", StringUtil.RTrim( divDetalle_infotecid_unidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ID_CATEGORIAFILTERCONTAINER_Class", StringUtil.RTrim( divId_categoriafiltercontainer_Class));
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
            WE5X2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5X2( ) ;
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
         return formatLink("gx00h0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pcorrelativo,9,0))}, new string[] {"pcorrelativo"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00H0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List detalle_infotec" ;
      }

      protected void WB5X0( )
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
            GxWebStd.gx_div_start( context, divCorrelativofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCorrelativofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcorrelativofilter_Internalname, "correlativo", "", "", lblLblcorrelativofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcorrelativo_Internalname, "correlativo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ccorrelativo), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCcorrelativo_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6ccorrelativo), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6ccorrelativo), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcorrelativo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcorrelativo_Visible, edtavCcorrelativo_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divCargo_empfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCargo_empfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcargo_empfilter_Internalname, "cargo_emp", "", "", lblLblcargo_empfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcargo_emp_Internalname, "cargo_emp", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcargo_emp_Internalname, AV7ccargo_emp, StringUtil.RTrim( context.localUtil.Format( AV7ccargo_emp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcargo_emp_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcargo_emp_Visible, edtavCcargo_emp_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divFecha_registrofiltercontainer_Internalname, 1, 0, "px", 0, "px", divFecha_registrofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfecha_registrofilter_Internalname, "fecha_registro", "", "", lblLblfecha_registrofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135x1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfecha_registro_Internalname, "fecha_registro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCfecha_registro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCfecha_registro_Internalname, context.localUtil.Format(AV8cfecha_registro, "99/99/99"), context.localUtil.Format( AV8cfecha_registro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfecha_registro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCfecha_registro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divHora_registrofiltercontainer_Internalname, 1, 0, "px", 0, "px", divHora_registrofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblhora_registrofilter_Internalname, "hora_registro", "", "", lblLblhora_registrofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145x1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavChora_registro_Internalname, "hora_registro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavChora_registro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavChora_registro_Internalname, context.localUtil.TToC( AV9chora_registro, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV9chora_registro, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavChora_registro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavChora_registro_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divEstatusfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstatusfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestatusfilter_Internalname, "estatus", "", "", lblLblestatusfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestatus_Internalname, "estatus", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestatus_Internalname, AV10cestatus, StringUtil.RTrim( context.localUtil.Format( AV10cestatus, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestatus_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestatus_Visible, edtavCestatus_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divDetalle_infotecid_unidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDetalle_infotecid_unidadfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldetalle_infotecid_unidadfilter_Internalname, "detalle_infotecid_unidad", "", "", lblLbldetalle_infotecid_unidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdetalle_infotecid_unidad_Internalname, "id_unidad", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdetalle_infotecid_unidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16cdetalle_infotecid_unidad), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCdetalle_infotecid_unidad_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16cdetalle_infotecid_unidad), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV16cdetalle_infotecid_unidad), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdetalle_infotecid_unidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdetalle_infotecid_unidad_Visible, edtavCdetalle_infotecid_unidad_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_div_start( context, divId_categoriafiltercontainer_Internalname, 1, 0, "px", 0, "px", divId_categoriafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblid_categoriafilter_Internalname, "id_categoria", "", "", lblLblid_categoriafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e175x1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00H0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCid_categoria_Internalname, "id_categoria", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCid_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cid_categoria), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCid_categoria_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cid_categoria), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV12cid_categoria), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCid_categoria_Jsonclick, 0, "Attribute", "", "", "", "", edtavCid_categoria_Visible, edtavCid_categoria_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00H0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e185x1_client"+"'", TempTags, "", 2, "HLP_Gx00H0.htm");
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
               context.SendWebValue( "correlativo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "cargo_emp") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "fecha_registro") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "hora_registro") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A240cargo_emp);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A241fecha_registro, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A242hora_registro, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ".", "")));
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00H0.htm");
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

      protected void START5X2( )
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
            Form.Meta.addItem("description", "Selection List detalle_infotec", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5X0( ) ;
      }

      protected void WS5X2( )
      {
         START5X2( ) ;
         EVT5X2( ) ;
      }

      protected void EVT5X2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A238correlativo = (int)(context.localUtil.CToN( cgiGet( edtcorrelativo_Internalname), ".", ","));
                              A240cargo_emp = cgiGet( edtcargo_emp_Internalname);
                              n240cargo_emp = false;
                              A241fecha_registro = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtfecha_registro_Internalname), 0));
                              n241fecha_registro = false;
                              A242hora_registro = context.localUtil.CToT( cgiGet( edthora_registro_Internalname), 0);
                              n242hora_registro = false;
                              A248detalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ".", ","));
                              n248detalle_infotecid_unidad = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E205X2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccorrelativo Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORRELATIVO"), ".", ",") != Convert.ToDecimal( AV6ccorrelativo )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccargo_emp Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCARGO_EMP"), AV7ccargo_emp) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfecha_registro Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCFECHA_REGISTRO"), 0) != AV8cfecha_registro )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Chora_registro Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCHORA_REGISTRO"), 0) != AV9chora_registro )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestatus Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTATUS"), AV10cestatus) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdetalle_infotecid_unidad Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDETALLE_INFOTECID_UNIDAD"), ".", ",") != Convert.ToDecimal( AV16cdetalle_infotecid_unidad )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cid_categoria Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_CATEGORIA"), ".", ",") != Convert.ToDecimal( AV12cid_categoria )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E215X2 ();
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

      protected void WE5X2( )
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

      protected void PA5X2( )
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
                                        int AV6ccorrelativo ,
                                        string AV7ccargo_emp ,
                                        DateTime AV8cfecha_registro ,
                                        DateTime AV9chora_registro ,
                                        string AV10cestatus ,
                                        int AV16cdetalle_infotecid_unidad ,
                                        int AV12cid_categoria )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CORRELATIVO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CORRELATIVO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")));
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5X2( ) ;
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

      protected void RF5X2( )
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
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage+1);
            GXPagingTo2 = (int)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( )+1);
            pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                 AV7ccargo_emp ,
                                                 AV8cfecha_registro ,
                                                 AV9chora_registro ,
                                                 AV10cestatus ,
                                                 AV16cdetalle_infotecid_unidad ,
                                                 AV12cid_categoria ,
                                                 A240cargo_emp ,
                                                 A241fecha_registro ,
                                                 A242hora_registro ,
                                                 A243estatus ,
                                                 A248detalle_infotecid_unidad ,
                                                 A249id_categoria ,
                                                 AV6ccorrelativo } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV7ccargo_emp = StringUtil.Concat( StringUtil.RTrim( AV7ccargo_emp), "%", "");
            lV10cestatus = StringUtil.Concat( StringUtil.RTrim( AV10cestatus), "%", "");
            /* Using cursor H005X2 */
            pr_datastore1.execute(0, new Object[] {AV6ccorrelativo, lV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, lV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria, GXPagingFrom2, GXPagingTo2, GXPagingFrom2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A249id_categoria = H005X2_A249id_categoria[0];
               n249id_categoria = H005X2_n249id_categoria[0];
               A243estatus = H005X2_A243estatus[0];
               n243estatus = H005X2_n243estatus[0];
               A248detalle_infotecid_unidad = H005X2_A248detalle_infotecid_unidad[0];
               n248detalle_infotecid_unidad = H005X2_n248detalle_infotecid_unidad[0];
               A242hora_registro = H005X2_A242hora_registro[0];
               n242hora_registro = H005X2_n242hora_registro[0];
               A241fecha_registro = H005X2_A241fecha_registro[0];
               n241fecha_registro = H005X2_n241fecha_registro[0];
               A240cargo_emp = H005X2_A240cargo_emp[0];
               n240cargo_emp = H005X2_n240cargo_emp[0];
               A238correlativo = H005X2_A238correlativo[0];
               /* Execute user event: Load */
               E205X2 ();
               pr_datastore1.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 84;
            WB5X0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5X2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CORRELATIVO"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9"), context));
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
         pr_datastore1.dynParam(1, new Object[]{ new Object[]{
                                              AV7ccargo_emp ,
                                              AV8cfecha_registro ,
                                              AV9chora_registro ,
                                              AV10cestatus ,
                                              AV16cdetalle_infotecid_unidad ,
                                              AV12cid_categoria ,
                                              A240cargo_emp ,
                                              A241fecha_registro ,
                                              A242hora_registro ,
                                              A243estatus ,
                                              A248detalle_infotecid_unidad ,
                                              A249id_categoria ,
                                              AV6ccorrelativo } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV7ccargo_emp = StringUtil.Concat( StringUtil.RTrim( AV7ccargo_emp), "%", "");
         lV10cestatus = StringUtil.Concat( StringUtil.RTrim( AV10cestatus), "%", "");
         /* Using cursor H005X3 */
         pr_datastore1.execute(1, new Object[] {AV6ccorrelativo, lV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, lV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria});
         GRID1_nRecordCount = H005X3_AGRID1_nRecordCount[0];
         pr_datastore1.close(1);
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccorrelativo, AV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, AV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccorrelativo, AV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, AV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccorrelativo, AV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, AV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccorrelativo, AV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, AV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccorrelativo, AV7ccargo_emp, AV8cfecha_registro, AV9chora_registro, AV10cestatus, AV16cdetalle_infotecid_unidad, AV12cid_categoria) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195X2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcorrelativo_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcorrelativo_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCORRELATIVO");
               GX_FocusControl = edtavCcorrelativo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ccorrelativo = 0;
               AssignAttri("", false, "AV6ccorrelativo", StringUtil.LTrimStr( (decimal)(AV6ccorrelativo), 9, 0));
            }
            else
            {
               AV6ccorrelativo = (int)(context.localUtil.CToN( cgiGet( edtavCcorrelativo_Internalname), ".", ","));
               AssignAttri("", false, "AV6ccorrelativo", StringUtil.LTrimStr( (decimal)(AV6ccorrelativo), 9, 0));
            }
            AV7ccargo_emp = cgiGet( edtavCcargo_emp_Internalname);
            AssignAttri("", false, "AV7ccargo_emp", AV7ccargo_emp);
            if ( context.localUtil.VCDate( cgiGet( edtavCfecha_registro_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_registro"}), 1, "vCFECHA_REGISTRO");
               GX_FocusControl = edtavCfecha_registro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cfecha_registro = DateTime.MinValue;
               AssignAttri("", false, "AV8cfecha_registro", context.localUtil.Format(AV8cfecha_registro, "99/99/99"));
            }
            else
            {
               AV8cfecha_registro = context.localUtil.CToD( cgiGet( edtavCfecha_registro_Internalname), 2);
               AssignAttri("", false, "AV8cfecha_registro", context.localUtil.Format(AV8cfecha_registro, "99/99/99"));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavChora_registro_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"hora_registro"}), 1, "vCHORA_REGISTRO");
               GX_FocusControl = edtavChora_registro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9chora_registro = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9chora_registro", context.localUtil.TToC( AV9chora_registro, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV9chora_registro = context.localUtil.CToT( cgiGet( edtavChora_registro_Internalname));
               AssignAttri("", false, "AV9chora_registro", context.localUtil.TToC( AV9chora_registro, 8, 5, 0, 3, "/", ":", " "));
            }
            AV10cestatus = cgiGet( edtavCestatus_Internalname);
            AssignAttri("", false, "AV10cestatus", AV10cestatus);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdetalle_infotecid_unidad_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdetalle_infotecid_unidad_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDETALLE_INFOTECID_UNIDAD");
               GX_FocusControl = edtavCdetalle_infotecid_unidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16cdetalle_infotecid_unidad = 0;
               AssignAttri("", false, "AV16cdetalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV16cdetalle_infotecid_unidad), 9, 0));
            }
            else
            {
               AV16cdetalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( edtavCdetalle_infotecid_unidad_Internalname), ".", ","));
               AssignAttri("", false, "AV16cdetalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV16cdetalle_infotecid_unidad), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCid_categoria_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCid_categoria_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCID_CATEGORIA");
               GX_FocusControl = edtavCid_categoria_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cid_categoria = 0;
               AssignAttri("", false, "AV12cid_categoria", StringUtil.LTrimStr( (decimal)(AV12cid_categoria), 9, 0));
            }
            else
            {
               AV12cid_categoria = (int)(context.localUtil.CToN( cgiGet( edtavCid_categoria_Internalname), ".", ","));
               AssignAttri("", false, "AV12cid_categoria", StringUtil.LTrimStr( (decimal)(AV12cid_categoria), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCORRELATIVO"), ".", ",") != Convert.ToDecimal( AV6ccorrelativo )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCARGO_EMP"), AV7ccargo_emp) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCFECHA_REGISTRO"), 2) ) != DateTimeUtil.ResetTime ( AV8cfecha_registro ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCHORA_REGISTRO")) != AV9chora_registro )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCESTATUS"), AV10cestatus) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDETALLE_INFOTECID_UNIDAD"), ".", ",") != Convert.ToDecimal( AV16cdetalle_infotecid_unidad )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_CATEGORIA"), ".", ",") != Convert.ToDecimal( AV12cid_categoria )) )
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
         E195X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195X2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "detalle_infotec", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E205X2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV19Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E215X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215X2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pcorrelativo = A238correlativo;
         AssignAttri("", false, "AV13pcorrelativo", StringUtil.LTrimStr( (decimal)(AV13pcorrelativo), 9, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pcorrelativo});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pcorrelativo"});
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
         AV13pcorrelativo = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pcorrelativo", StringUtil.LTrimStr( (decimal)(AV13pcorrelativo), 9, 0));
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
         PA5X2( ) ;
         WS5X2( ) ;
         WE5X2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188224958", true, true);
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
         context.AddJavascriptSource("gx00h0.js", "?2024188224958", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtcorrelativo_Internalname = "CORRELATIVO_"+sGXsfl_84_idx;
         edtcargo_emp_Internalname = "CARGO_EMP_"+sGXsfl_84_idx;
         edtfecha_registro_Internalname = "FECHA_REGISTRO_"+sGXsfl_84_idx;
         edthora_registro_Internalname = "HORA_REGISTRO_"+sGXsfl_84_idx;
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtcorrelativo_Internalname = "CORRELATIVO_"+sGXsfl_84_fel_idx;
         edtcargo_emp_Internalname = "CARGO_EMP_"+sGXsfl_84_fel_idx;
         edtfecha_registro_Internalname = "FECHA_REGISTRO_"+sGXsfl_84_fel_idx;
         edthora_registro_Internalname = "HORA_REGISTRO_"+sGXsfl_84_fel_idx;
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB5X0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV19Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV19Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcorrelativo_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcorrelativo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcargo_emp_Internalname,(string)A240cargo_emp,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcargo_emp_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtfecha_registro_Internalname,context.localUtil.Format(A241fecha_registro, "99/99/99"),context.localUtil.Format( A241fecha_registro, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtfecha_registro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edthora_registro_Internalname,context.localUtil.TToC( A242hora_registro, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A242hora_registro, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edthora_registro_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtdetalle_infotecid_unidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtdetalle_infotecid_unidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes5X2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblLblcorrelativofilter_Internalname = "LBLCORRELATIVOFILTER";
         edtavCcorrelativo_Internalname = "vCCORRELATIVO";
         divCorrelativofiltercontainer_Internalname = "CORRELATIVOFILTERCONTAINER";
         lblLblcargo_empfilter_Internalname = "LBLCARGO_EMPFILTER";
         edtavCcargo_emp_Internalname = "vCCARGO_EMP";
         divCargo_empfiltercontainer_Internalname = "CARGO_EMPFILTERCONTAINER";
         lblLblfecha_registrofilter_Internalname = "LBLFECHA_REGISTROFILTER";
         edtavCfecha_registro_Internalname = "vCFECHA_REGISTRO";
         divFecha_registrofiltercontainer_Internalname = "FECHA_REGISTROFILTERCONTAINER";
         lblLblhora_registrofilter_Internalname = "LBLHORA_REGISTROFILTER";
         edtavChora_registro_Internalname = "vCHORA_REGISTRO";
         divHora_registrofiltercontainer_Internalname = "HORA_REGISTROFILTERCONTAINER";
         lblLblestatusfilter_Internalname = "LBLESTATUSFILTER";
         edtavCestatus_Internalname = "vCESTATUS";
         divEstatusfiltercontainer_Internalname = "ESTATUSFILTERCONTAINER";
         lblLbldetalle_infotecid_unidadfilter_Internalname = "LBLDETALLE_INFOTECID_UNIDADFILTER";
         edtavCdetalle_infotecid_unidad_Internalname = "vCDETALLE_INFOTECID_UNIDAD";
         divDetalle_infotecid_unidadfiltercontainer_Internalname = "DETALLE_INFOTECID_UNIDADFILTERCONTAINER";
         lblLblid_categoriafilter_Internalname = "LBLID_CATEGORIAFILTER";
         edtavCid_categoria_Internalname = "vCID_CATEGORIA";
         divId_categoriafiltercontainer_Internalname = "ID_CATEGORIAFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtcorrelativo_Internalname = "CORRELATIVO";
         edtcargo_emp_Internalname = "CARGO_EMP";
         edtfecha_registro_Internalname = "FECHA_REGISTRO";
         edthora_registro_Internalname = "HORA_REGISTRO";
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD";
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
         edtdetalle_infotecid_unidad_Jsonclick = "";
         edthora_registro_Jsonclick = "";
         edtfecha_registro_Jsonclick = "";
         edtcargo_emp_Jsonclick = "";
         edtcorrelativo_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCid_categoria_Jsonclick = "";
         edtavCid_categoria_Enabled = 1;
         edtavCid_categoria_Visible = 1;
         edtavCdetalle_infotecid_unidad_Jsonclick = "";
         edtavCdetalle_infotecid_unidad_Enabled = 1;
         edtavCdetalle_infotecid_unidad_Visible = 1;
         edtavCestatus_Jsonclick = "";
         edtavCestatus_Enabled = 1;
         edtavCestatus_Visible = 1;
         edtavChora_registro_Jsonclick = "";
         edtavChora_registro_Enabled = 1;
         edtavCfecha_registro_Jsonclick = "";
         edtavCfecha_registro_Enabled = 1;
         edtavCcargo_emp_Jsonclick = "";
         edtavCcargo_emp_Enabled = 1;
         edtavCcargo_emp_Visible = 1;
         edtavCcorrelativo_Jsonclick = "";
         edtavCcorrelativo_Enabled = 1;
         edtavCcorrelativo_Visible = 1;
         divId_categoriafiltercontainer_Class = "AdvancedContainerItem";
         divDetalle_infotecid_unidadfiltercontainer_Class = "AdvancedContainerItem";
         divEstatusfiltercontainer_Class = "AdvancedContainerItem";
         divHora_registrofiltercontainer_Class = "AdvancedContainerItem";
         divFecha_registrofiltercontainer_Class = "AdvancedContainerItem";
         divCargo_empfiltercontainer_Class = "AdvancedContainerItem";
         divCorrelativofiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List detalle_infotec";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccorrelativo',fld:'vCCORRELATIVO',pic:'ZZZZZZZZ9'},{av:'AV7ccargo_emp',fld:'vCCARGO_EMP',pic:''},{av:'AV8cfecha_registro',fld:'vCFECHA_REGISTRO',pic:''},{av:'AV9chora_registro',fld:'vCHORA_REGISTRO',pic:'99/99/99 99:99'},{av:'AV10cestatus',fld:'vCESTATUS',pic:''},{av:'AV16cdetalle_infotecid_unidad',fld:'vCDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV12cid_categoria',fld:'vCID_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E185X1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCORRELATIVOFILTER.CLICK","{handler:'E115X1',iparms:[{av:'divCorrelativofiltercontainer_Class',ctrl:'CORRELATIVOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCORRELATIVOFILTER.CLICK",",oparms:[{av:'divCorrelativofiltercontainer_Class',ctrl:'CORRELATIVOFILTERCONTAINER',prop:'Class'},{av:'edtavCcorrelativo_Visible',ctrl:'vCCORRELATIVO',prop:'Visible'}]}");
         setEventMetadata("LBLCARGO_EMPFILTER.CLICK","{handler:'E125X1',iparms:[{av:'divCargo_empfiltercontainer_Class',ctrl:'CARGO_EMPFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCARGO_EMPFILTER.CLICK",",oparms:[{av:'divCargo_empfiltercontainer_Class',ctrl:'CARGO_EMPFILTERCONTAINER',prop:'Class'},{av:'edtavCcargo_emp_Visible',ctrl:'vCCARGO_EMP',prop:'Visible'}]}");
         setEventMetadata("LBLFECHA_REGISTROFILTER.CLICK","{handler:'E135X1',iparms:[{av:'divFecha_registrofiltercontainer_Class',ctrl:'FECHA_REGISTROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFECHA_REGISTROFILTER.CLICK",",oparms:[{av:'divFecha_registrofiltercontainer_Class',ctrl:'FECHA_REGISTROFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLHORA_REGISTROFILTER.CLICK","{handler:'E145X1',iparms:[{av:'divHora_registrofiltercontainer_Class',ctrl:'HORA_REGISTROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLHORA_REGISTROFILTER.CLICK",",oparms:[{av:'divHora_registrofiltercontainer_Class',ctrl:'HORA_REGISTROFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLESTATUSFILTER.CLICK","{handler:'E155X1',iparms:[{av:'divEstatusfiltercontainer_Class',ctrl:'ESTATUSFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTATUSFILTER.CLICK",",oparms:[{av:'divEstatusfiltercontainer_Class',ctrl:'ESTATUSFILTERCONTAINER',prop:'Class'},{av:'edtavCestatus_Visible',ctrl:'vCESTATUS',prop:'Visible'}]}");
         setEventMetadata("LBLDETALLE_INFOTECID_UNIDADFILTER.CLICK","{handler:'E165X1',iparms:[{av:'divDetalle_infotecid_unidadfiltercontainer_Class',ctrl:'DETALLE_INFOTECID_UNIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDETALLE_INFOTECID_UNIDADFILTER.CLICK",",oparms:[{av:'divDetalle_infotecid_unidadfiltercontainer_Class',ctrl:'DETALLE_INFOTECID_UNIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCdetalle_infotecid_unidad_Visible',ctrl:'vCDETALLE_INFOTECID_UNIDAD',prop:'Visible'}]}");
         setEventMetadata("LBLID_CATEGORIAFILTER.CLICK","{handler:'E175X1',iparms:[{av:'divId_categoriafiltercontainer_Class',ctrl:'ID_CATEGORIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLID_CATEGORIAFILTER.CLICK",",oparms:[{av:'divId_categoriafiltercontainer_Class',ctrl:'ID_CATEGORIAFILTERCONTAINER',prop:'Class'},{av:'edtavCid_categoria_Visible',ctrl:'vCID_CATEGORIA',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E215X2',iparms:[{av:'A238correlativo',fld:'CORRELATIVO',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pcorrelativo',fld:'vPCORRELATIVO',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccorrelativo',fld:'vCCORRELATIVO',pic:'ZZZZZZZZ9'},{av:'AV7ccargo_emp',fld:'vCCARGO_EMP',pic:''},{av:'AV8cfecha_registro',fld:'vCFECHA_REGISTRO',pic:''},{av:'AV9chora_registro',fld:'vCHORA_REGISTRO',pic:'99/99/99 99:99'},{av:'AV10cestatus',fld:'vCESTATUS',pic:''},{av:'AV16cdetalle_infotecid_unidad',fld:'vCDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV12cid_categoria',fld:'vCID_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccorrelativo',fld:'vCCORRELATIVO',pic:'ZZZZZZZZ9'},{av:'AV7ccargo_emp',fld:'vCCARGO_EMP',pic:''},{av:'AV8cfecha_registro',fld:'vCFECHA_REGISTRO',pic:''},{av:'AV9chora_registro',fld:'vCHORA_REGISTRO',pic:'99/99/99 99:99'},{av:'AV10cestatus',fld:'vCESTATUS',pic:''},{av:'AV16cdetalle_infotecid_unidad',fld:'vCDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV12cid_categoria',fld:'vCID_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccorrelativo',fld:'vCCORRELATIVO',pic:'ZZZZZZZZ9'},{av:'AV7ccargo_emp',fld:'vCCARGO_EMP',pic:''},{av:'AV8cfecha_registro',fld:'vCFECHA_REGISTRO',pic:''},{av:'AV9chora_registro',fld:'vCHORA_REGISTRO',pic:'99/99/99 99:99'},{av:'AV10cestatus',fld:'vCESTATUS',pic:''},{av:'AV16cdetalle_infotecid_unidad',fld:'vCDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV12cid_categoria',fld:'vCID_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccorrelativo',fld:'vCCORRELATIVO',pic:'ZZZZZZZZ9'},{av:'AV7ccargo_emp',fld:'vCCARGO_EMP',pic:''},{av:'AV8cfecha_registro',fld:'vCFECHA_REGISTRO',pic:''},{av:'AV9chora_registro',fld:'vCHORA_REGISTRO',pic:'99/99/99 99:99'},{av:'AV10cestatus',fld:'vCESTATUS',pic:''},{av:'AV16cdetalle_infotecid_unidad',fld:'vCDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV12cid_categoria',fld:'vCID_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CFECHA_REGISTRO","{handler:'Validv_Cfecha_registro',iparms:[]");
         setEventMetadata("VALIDV_CFECHA_REGISTRO",",oparms:[]}");
         setEventMetadata("VALIDV_CHORA_REGISTRO","{handler:'Validv_Chora_registro',iparms:[]");
         setEventMetadata("VALIDV_CHORA_REGISTRO",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Detalle_infotecid_unidad',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         AV7ccargo_emp = "";
         AV8cfecha_registro = DateTime.MinValue;
         AV9chora_registro = (DateTime)(DateTime.MinValue);
         AV10cestatus = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcorrelativofilter_Jsonclick = "";
         TempTags = "";
         lblLblcargo_empfilter_Jsonclick = "";
         lblLblfecha_registrofilter_Jsonclick = "";
         lblLblhora_registrofilter_Jsonclick = "";
         lblLblestatusfilter_Jsonclick = "";
         lblLbldetalle_infotecid_unidadfilter_Jsonclick = "";
         lblLblid_categoriafilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A240cargo_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A242hora_registro = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV19Linkselection_GXI = "";
         scmdbuf = "";
         lV7ccargo_emp = "";
         lV10cestatus = "";
         A243estatus = "";
         H005X2_A249id_categoria = new int[1] ;
         H005X2_n249id_categoria = new bool[] {false} ;
         H005X2_A243estatus = new string[] {""} ;
         H005X2_n243estatus = new bool[] {false} ;
         H005X2_A248detalle_infotecid_unidad = new int[1] ;
         H005X2_n248detalle_infotecid_unidad = new bool[] {false} ;
         H005X2_A242hora_registro = new DateTime[] {DateTime.MinValue} ;
         H005X2_n242hora_registro = new bool[] {false} ;
         H005X2_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         H005X2_n241fecha_registro = new bool[] {false} ;
         H005X2_A240cargo_emp = new string[] {""} ;
         H005X2_n240cargo_emp = new bool[] {false} ;
         H005X2_A238correlativo = new int[1] ;
         H005X3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.gx00h0__datastore1(),
            new Object[][] {
                new Object[] {
               H005X2_A249id_categoria, H005X2_n249id_categoria, H005X2_A243estatus, H005X2_n243estatus, H005X2_A248detalle_infotecid_unidad, H005X2_n248detalle_infotecid_unidad, H005X2_A242hora_registro, H005X2_n242hora_registro, H005X2_A241fecha_registro, H005X2_n241fecha_registro,
               H005X2_A240cargo_emp, H005X2_n240cargo_emp, H005X2_A238correlativo
               }
               , new Object[] {
               H005X3_AGRID1_nRecordCount
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
      private int AV13pcorrelativo ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV6ccorrelativo ;
      private int AV16cdetalle_infotecid_unidad ;
      private int AV12cid_categoria ;
      private int edtavCcorrelativo_Enabled ;
      private int edtavCcorrelativo_Visible ;
      private int edtavCcargo_emp_Visible ;
      private int edtavCcargo_emp_Enabled ;
      private int edtavCfecha_registro_Enabled ;
      private int edtavChora_registro_Enabled ;
      private int edtavCestatus_Visible ;
      private int edtavCestatus_Enabled ;
      private int edtavCdetalle_infotecid_unidad_Enabled ;
      private int edtavCdetalle_infotecid_unidad_Visible ;
      private int edtavCid_categoria_Enabled ;
      private int edtavCid_categoria_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A238correlativo ;
      private int A248detalle_infotecid_unidad ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A249id_categoria ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divCorrelativofiltercontainer_Class ;
      private string divCargo_empfiltercontainer_Class ;
      private string divFecha_registrofiltercontainer_Class ;
      private string divHora_registrofiltercontainer_Class ;
      private string divEstatusfiltercontainer_Class ;
      private string divDetalle_infotecid_unidadfiltercontainer_Class ;
      private string divId_categoriafiltercontainer_Class ;
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
      private string divCorrelativofiltercontainer_Internalname ;
      private string lblLblcorrelativofilter_Internalname ;
      private string lblLblcorrelativofilter_Jsonclick ;
      private string edtavCcorrelativo_Internalname ;
      private string TempTags ;
      private string edtavCcorrelativo_Jsonclick ;
      private string divCargo_empfiltercontainer_Internalname ;
      private string lblLblcargo_empfilter_Internalname ;
      private string lblLblcargo_empfilter_Jsonclick ;
      private string edtavCcargo_emp_Internalname ;
      private string edtavCcargo_emp_Jsonclick ;
      private string divFecha_registrofiltercontainer_Internalname ;
      private string lblLblfecha_registrofilter_Internalname ;
      private string lblLblfecha_registrofilter_Jsonclick ;
      private string edtavCfecha_registro_Internalname ;
      private string edtavCfecha_registro_Jsonclick ;
      private string divHora_registrofiltercontainer_Internalname ;
      private string lblLblhora_registrofilter_Internalname ;
      private string lblLblhora_registrofilter_Jsonclick ;
      private string edtavChora_registro_Internalname ;
      private string edtavChora_registro_Jsonclick ;
      private string divEstatusfiltercontainer_Internalname ;
      private string lblLblestatusfilter_Internalname ;
      private string lblLblestatusfilter_Jsonclick ;
      private string edtavCestatus_Internalname ;
      private string edtavCestatus_Jsonclick ;
      private string divDetalle_infotecid_unidadfiltercontainer_Internalname ;
      private string lblLbldetalle_infotecid_unidadfilter_Internalname ;
      private string lblLbldetalle_infotecid_unidadfilter_Jsonclick ;
      private string edtavCdetalle_infotecid_unidad_Internalname ;
      private string edtavCdetalle_infotecid_unidad_Jsonclick ;
      private string divId_categoriafiltercontainer_Internalname ;
      private string lblLblid_categoriafilter_Internalname ;
      private string lblLblid_categoriafilter_Jsonclick ;
      private string edtavCid_categoria_Internalname ;
      private string edtavCid_categoria_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
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
      private string edtcorrelativo_Internalname ;
      private string edtcargo_emp_Internalname ;
      private string edtfecha_registro_Internalname ;
      private string edthora_registro_Internalname ;
      private string edtdetalle_infotecid_unidad_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtcorrelativo_Jsonclick ;
      private string edtcargo_emp_Jsonclick ;
      private string edtfecha_registro_Jsonclick ;
      private string edthora_registro_Jsonclick ;
      private string edtdetalle_infotecid_unidad_Jsonclick ;
      private DateTime AV9chora_registro ;
      private DateTime A242hora_registro ;
      private DateTime AV8cfecha_registro ;
      private DateTime A241fecha_registro ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n242hora_registro ;
      private bool n248detalle_infotecid_unidad ;
      private bool gxdyncontrolsrefreshing ;
      private bool n249id_categoria ;
      private bool n243estatus ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7ccargo_emp ;
      private string AV10cestatus ;
      private string A240cargo_emp ;
      private string AV19Linkselection_GXI ;
      private string lV7ccargo_emp ;
      private string lV10cestatus ;
      private string A243estatus ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H005X2_A249id_categoria ;
      private bool[] H005X2_n249id_categoria ;
      private string[] H005X2_A243estatus ;
      private bool[] H005X2_n243estatus ;
      private int[] H005X2_A248detalle_infotecid_unidad ;
      private bool[] H005X2_n248detalle_infotecid_unidad ;
      private DateTime[] H005X2_A242hora_registro ;
      private bool[] H005X2_n242hora_registro ;
      private DateTime[] H005X2_A241fecha_registro ;
      private bool[] H005X2_n241fecha_registro ;
      private string[] H005X2_A240cargo_emp ;
      private bool[] H005X2_n240cargo_emp ;
      private int[] H005X2_A238correlativo ;
      private long[] H005X3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pcorrelativo ;
      private GXWebForm Form ;
   }

   public class gx00h0__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005X2( IGxContext context ,
                                             string AV7ccargo_emp ,
                                             DateTime AV8cfecha_registro ,
                                             DateTime AV9chora_registro ,
                                             string AV10cestatus ,
                                             int AV16cdetalle_infotecid_unidad ,
                                             int AV12cid_categoria ,
                                             string A240cargo_emp ,
                                             DateTime A241fecha_registro ,
                                             DateTime A242hora_registro ,
                                             string A243estatus ,
                                             int A248detalle_infotecid_unidad ,
                                             int A249id_categoria ,
                                             int AV6ccorrelativo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [id_categoria], [estatus], [id_unidad], [hora_registro], [fecha_registro], [cargo_emp], [correlativo]";
         sFromString = " FROM dbo.[detalle_infotec]";
         sOrderString = "";
         AddWhere(sWhereString, "([correlativo] >= @AV6ccorrelativo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ccargo_emp)) )
         {
            AddWhere(sWhereString, "([cargo_emp] like @lV7ccargo_emp)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cfecha_registro) )
         {
            AddWhere(sWhereString, "([fecha_registro] >= @AV8cfecha_registro)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9chora_registro) )
         {
            AddWhere(sWhereString, "([hora_registro] >= @AV9chora_registro)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cestatus)) )
         {
            AddWhere(sWhereString, "([estatus] like @lV10cestatus)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV16cdetalle_infotecid_unidad) )
         {
            AddWhere(sWhereString, "([id_unidad] >= @AV16cdetalle_infotecid_unidad)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cid_categoria) )
         {
            AddWhere(sWhereString, "([id_categoria] >= @AV12cid_categoria)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [correlativo]";
         scmdbuf = "SELECT * FROM (SELECT " + sSelectString + ", ROW_NUMBER() OVER (" + sOrderString + " ) AS GX_ROW_NUMBER" + sFromString + sWhereString + "" + ") AS GX_CTE WHERE GX_ROW_NUMBER" + " >= " + "@GXPagingFrom2" + " AND GX_ROW_NUMBER <= (CASE WHEN (" + "@GXPagingTo2" + " < " + "@GXPagingFrom2" + ") THEN CAST(0x7FFFFFFFFFFFFFFF AS bigint) ELSE " + "@GXPagingTo2" + " END)";
         scmdbuf += " OPTION (FAST 11)";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005X3( IGxContext context ,
                                             string AV7ccargo_emp ,
                                             DateTime AV8cfecha_registro ,
                                             DateTime AV9chora_registro ,
                                             string AV10cestatus ,
                                             int AV16cdetalle_infotecid_unidad ,
                                             int AV12cid_categoria ,
                                             string A240cargo_emp ,
                                             DateTime A241fecha_registro ,
                                             DateTime A242hora_registro ,
                                             string A243estatus ,
                                             int A248detalle_infotecid_unidad ,
                                             int A249id_categoria ,
                                             int AV6ccorrelativo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[detalle_infotec]";
         AddWhere(sWhereString, "([correlativo] >= @AV6ccorrelativo)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ccargo_emp)) )
         {
            AddWhere(sWhereString, "([cargo_emp] like @lV7ccargo_emp)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cfecha_registro) )
         {
            AddWhere(sWhereString, "([fecha_registro] >= @AV8cfecha_registro)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9chora_registro) )
         {
            AddWhere(sWhereString, "([hora_registro] >= @AV9chora_registro)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cestatus)) )
         {
            AddWhere(sWhereString, "([estatus] like @lV10cestatus)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV16cdetalle_infotecid_unidad) )
         {
            AddWhere(sWhereString, "([id_unidad] >= @AV16cdetalle_infotecid_unidad)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cid_categoria) )
         {
            AddWhere(sWhereString, "([id_categoria] >= @AV12cid_categoria)");
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
                     return conditional_H005X2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H005X3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH005X2;
          prmH005X2 = new Object[] {
          new ParDef("@AV6ccorrelativo",GXType.Int32,9,0) ,
          new ParDef("@lV7ccargo_emp",GXType.NVarChar,60,0) ,
          new ParDef("@AV8cfecha_registro",GXType.Date,8,0) ,
          new ParDef("@AV9chora_registro",GXType.DateTime,8,5) ,
          new ParDef("@lV10cestatus",GXType.NVarChar,30,0) ,
          new ParDef("@AV16cdetalle_infotecid_unidad",GXType.Int32,9,0) ,
          new ParDef("@AV12cid_categoria",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005X3;
          prmH005X3 = new Object[] {
          new ParDef("@AV6ccorrelativo",GXType.Int32,9,0) ,
          new ParDef("@lV7ccargo_emp",GXType.NVarChar,60,0) ,
          new ParDef("@AV8cfecha_registro",GXType.Date,8,0) ,
          new ParDef("@AV9chora_registro",GXType.DateTime,8,5) ,
          new ParDef("@lV10cestatus",GXType.NVarChar,30,0) ,
          new ParDef("@AV16cdetalle_infotecid_unidad",GXType.Int32,9,0) ,
          new ParDef("@AV12cid_categoria",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005X2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005X3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getVarchar(6);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((int[]) buf[12])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

}
