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
   public class gx00c0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00c0( )
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

      public gx00c0( IGxContext context )
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

      public void execute( out int aP0_pid_unidad )
      {
         this.AV13pid_unidad = 0 ;
         executePrivate();
         aP0_pid_unidad=this.AV13pid_unidad;
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
            gxfirstwebparm = GetFirstPar( "pid_unidad");
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
               gxfirstwebparm = GetFirstPar( "pid_unidad");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pid_unidad");
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
               AV6cid_unidad = (int)(NumberUtil.Val( GetPar( "cid_unidad"), "."));
               AV7cunidades_gisestado = (int)(NumberUtil.Val( GetPar( "cunidades_gisestado"), "."));
               AV8cunidades_gisfecha_creacion = context.localUtil.ParseDateParm( GetPar( "cunidades_gisfecha_creacion"));
               AV9cunidades_gishora_creacion = (int)(NumberUtil.Val( GetPar( "cunidades_gishora_creacion"), "."));
               AV10cunidades_giscreado_por = GetPar( "cunidades_giscreado_por");
               AV11cunidades_gisfecha_modificacion = context.localUtil.ParseDateParm( GetPar( "cunidades_gisfecha_modificacion"));
               AV12cunidades_gishora_modificacion = (int)(NumberUtil.Val( GetPar( "cunidades_gishora_modificacion"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, AV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "ID_UNIDADFILTERCONTAINER_Class", StringUtil.RTrim( divId_unidadfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDADES_GISESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gisestadofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDADES_GISFECHA_CREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gisfecha_creacionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDADES_GISHORA_CREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gishora_creacionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDADES_GISCREADO_PORFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_giscreado_porfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDADES_GISFECHA_MODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gisfecha_modificacionfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDADES_GISHORA_MODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gishora_modificacionfiltercontainer_Class));
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
               AV13pid_unidad = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pid_unidad", StringUtil.LTrimStr( (decimal)(AV13pid_unidad), 9, 0));
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
            return "gx00c0_Execute" ;
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
         PA5H2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5H2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2023124957223", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00c0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pid_unidad,9,0))}, new string[] {"pid_unidad"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCID_UNIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cid_unidad), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDADES_GISESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cunidades_gisestado), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDADES_GISFECHA_CREACION", context.localUtil.Format(AV8cunidades_gisfecha_creacion, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDADES_GISHORA_CREACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cunidades_gishora_creacion), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDADES_GISCREADO_POR", AV10cunidades_giscreado_por);
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDADES_GISFECHA_MODIFICACION", context.localUtil.Format(AV11cunidades_gisfecha_modificacion, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDADES_GISHORA_MODIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cunidades_gishora_modificacion), 5, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPID_UNIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pid_unidad), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ID_UNIDADFILTERCONTAINER_Class", StringUtil.RTrim( divId_unidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDADES_GISESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gisestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDADES_GISFECHA_CREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gisfecha_creacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDADES_GISHORA_CREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gishora_creacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDADES_GISCREADO_PORFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_giscreado_porfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDADES_GISFECHA_MODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gisfecha_modificacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDADES_GISHORA_MODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divUnidades_gishora_modificacionfiltercontainer_Class));
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
            WE5H2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5H2( ) ;
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
         return formatLink("gx00c0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pid_unidad,9,0))}, new string[] {"pid_unidad"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00C0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List unidades_gis" ;
      }

      protected void WB5H0( )
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
            GxWebStd.gx_div_start( context, divId_unidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divId_unidadfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblid_unidadfilter_Internalname, "id_unidad", "", "", lblLblid_unidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCid_unidad_Internalname, "id_unidad", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCid_unidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cid_unidad), 9, 0, ",", "")), ((edtavCid_unidad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cid_unidad), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cid_unidad), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCid_unidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCid_unidad_Visible, edtavCid_unidad_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divUnidades_gisestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidades_gisestadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidades_gisestadofilter_Internalname, "unidades_gisestado", "", "", lblLblunidades_gisestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidades_gisestado_Internalname, "estado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCunidades_gisestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cunidades_gisestado), 9, 0, ",", "")), ((edtavCunidades_gisestado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7cunidades_gisestado), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV7cunidades_gisestado), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidades_gisestado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCunidades_gisestado_Visible, edtavCunidades_gisestado_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divUnidades_gisfecha_creacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidades_gisfecha_creacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidades_gisfecha_creacionfilter_Internalname, "unidades_gisfecha_creacion", "", "", lblLblunidades_gisfecha_creacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135h1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidades_gisfecha_creacion_Internalname, "fecha_creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCunidades_gisfecha_creacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCunidades_gisfecha_creacion_Internalname, context.localUtil.Format(AV8cunidades_gisfecha_creacion, "99/99/99"), context.localUtil.Format( AV8cunidades_gisfecha_creacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidades_gisfecha_creacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCunidades_gisfecha_creacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divUnidades_gishora_creacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidades_gishora_creacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidades_gishora_creacionfilter_Internalname, "unidades_gishora_creacion", "", "", lblLblunidades_gishora_creacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidades_gishora_creacion_Internalname, "hora_creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCunidades_gishora_creacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cunidades_gishora_creacion), 5, 0, ",", "")), ((edtavCunidades_gishora_creacion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9cunidades_gishora_creacion), "ZZZZ9")) : context.localUtil.Format( (decimal)(AV9cunidades_gishora_creacion), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidades_gishora_creacion_Jsonclick, 0, "Attribute", "", "", "", "", edtavCunidades_gishora_creacion_Visible, edtavCunidades_gishora_creacion_Enabled, 0, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divUnidades_giscreado_porfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidades_giscreado_porfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidades_giscreado_porfilter_Internalname, "unidades_giscreado_por", "", "", lblLblunidades_giscreado_porfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidades_giscreado_por_Internalname, "creado_por", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCunidades_giscreado_por_Internalname, AV10cunidades_giscreado_por, StringUtil.RTrim( context.localUtil.Format( AV10cunidades_giscreado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidades_giscreado_por_Jsonclick, 0, "Attribute", "", "", "", "", edtavCunidades_giscreado_por_Visible, edtavCunidades_giscreado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divUnidades_gisfecha_modificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidades_gisfecha_modificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidades_gisfecha_modificacionfilter_Internalname, "unidades_gisfecha_modificacion", "", "", lblLblunidades_gisfecha_modificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165h1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidades_gisfecha_modificacion_Internalname, "fecha_modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCunidades_gisfecha_modificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCunidades_gisfecha_modificacion_Internalname, context.localUtil.Format(AV11cunidades_gisfecha_modificacion, "99/99/99"), context.localUtil.Format( AV11cunidades_gisfecha_modificacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidades_gisfecha_modificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCunidades_gisfecha_modificacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_div_start( context, divUnidades_gishora_modificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidades_gishora_modificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidades_gishora_modificacionfilter_Internalname, "unidades_gishora_modificacion", "", "", lblLblunidades_gishora_modificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e175h1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00C0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidades_gishora_modificacion_Internalname, "hora_modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCunidades_gishora_modificacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cunidades_gishora_modificacion), 5, 0, ",", "")), ((edtavCunidades_gishora_modificacion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12cunidades_gishora_modificacion), "ZZZZ9")) : context.localUtil.Format( (decimal)(AV12cunidades_gishora_modificacion), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidades_gishora_modificacion_Jsonclick, 0, "Attribute", "", "", "", "", edtavCunidades_gishora_modificacion_Visible, edtavCunidades_gishora_modificacion_Enabled, 0, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00C0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e185h1_client"+"'", TempTags, "", 2, "HLP_Gx00C0.htm");
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
               context.SendWebValue( "id_unidad") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "fecha_creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "hora_creacion") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "creado_por") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A115unidades_gisestado), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A117unidades_gishora_creacion), 5, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A118unidades_giscreado_por);
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00C0.htm");
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

      protected void START5H2( )
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
            Form.Meta.addItem("description", "Selection List unidades_gis", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5H0( ) ;
      }

      protected void WS5H2( )
      {
         START5H2( ) ;
         EVT5H2( ) ;
      }

      protected void EVT5H2( )
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
                              A103id_unidad = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ",", "."));
                              A115unidades_gisestado = (int)(context.localUtil.CToN( cgiGet( edtunidades_gisestado_Internalname), ",", "."));
                              n115unidades_gisestado = false;
                              A116unidades_gisfecha_creacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtunidades_gisfecha_creacion_Internalname), 0));
                              n116unidades_gisfecha_creacion = false;
                              A117unidades_gishora_creacion = (int)(context.localUtil.CToN( cgiGet( edtunidades_gishora_creacion_Internalname), ",", "."));
                              n117unidades_gishora_creacion = false;
                              A118unidades_giscreado_por = cgiGet( edtunidades_giscreado_por_Internalname);
                              n118unidades_giscreado_por = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E205H2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cid_unidad Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_UNIDAD"), ",", ".") != Convert.ToDecimal( AV6cid_unidad )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidades_gisestado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUNIDADES_GISESTADO"), ",", ".") != Convert.ToDecimal( AV7cunidades_gisestado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidades_gisfecha_creacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUNIDADES_GISFECHA_CREACION"), 0) != AV8cunidades_gisfecha_creacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidades_gishora_creacion Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUNIDADES_GISHORA_CREACION"), ",", ".") != Convert.ToDecimal( AV9cunidades_gishora_creacion )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidades_giscreado_por Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUNIDADES_GISCREADO_POR"), AV10cunidades_giscreado_por) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidades_gisfecha_modificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUNIDADES_GISFECHA_MODIFICACION"), 0) != AV11cunidades_gisfecha_modificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidades_gishora_modificacion Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUNIDADES_GISHORA_MODIFICACION"), ",", ".") != Convert.ToDecimal( AV12cunidades_gishora_modificacion )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E215H2 ();
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

      protected void WE5H2( )
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

      protected void PA5H2( )
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
                                        int AV6cid_unidad ,
                                        int AV7cunidades_gisestado ,
                                        DateTime AV8cunidades_gisfecha_creacion ,
                                        int AV9cunidades_gishora_creacion ,
                                        string AV10cunidades_giscreado_por ,
                                        DateTime AV11cunidades_gisfecha_modificacion ,
                                        int AV12cunidades_gishora_modificacion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5H2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ID_UNIDAD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ID_UNIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")));
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
         RF5H2( ) ;
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

      protected void RF5H2( )
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
            pr_datastore1.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cunidades_gisestado ,
                                                 AV8cunidades_gisfecha_creacion ,
                                                 AV9cunidades_gishora_creacion ,
                                                 AV10cunidades_giscreado_por ,
                                                 AV11cunidades_gisfecha_modificacion ,
                                                 AV12cunidades_gishora_modificacion ,
                                                 A115unidades_gisestado ,
                                                 A116unidades_gisfecha_creacion ,
                                                 A117unidades_gishora_creacion ,
                                                 A118unidades_giscreado_por ,
                                                 A119unidades_gisfecha_modificacion ,
                                                 A120unidades_gishora_modificacion ,
                                                 AV6cid_unidad } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV10cunidades_giscreado_por = StringUtil.Concat( StringUtil.RTrim( AV10cunidades_giscreado_por), "%", "");
            /* Using cursor H005H2 */
            pr_datastore1.execute(0, new Object[] {AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, lV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A120unidades_gishora_modificacion = H005H2_A120unidades_gishora_modificacion[0];
               n120unidades_gishora_modificacion = H005H2_n120unidades_gishora_modificacion[0];
               A119unidades_gisfecha_modificacion = H005H2_A119unidades_gisfecha_modificacion[0];
               n119unidades_gisfecha_modificacion = H005H2_n119unidades_gisfecha_modificacion[0];
               A118unidades_giscreado_por = H005H2_A118unidades_giscreado_por[0];
               n118unidades_giscreado_por = H005H2_n118unidades_giscreado_por[0];
               A117unidades_gishora_creacion = H005H2_A117unidades_gishora_creacion[0];
               n117unidades_gishora_creacion = H005H2_n117unidades_gishora_creacion[0];
               A116unidades_gisfecha_creacion = H005H2_A116unidades_gisfecha_creacion[0];
               n116unidades_gisfecha_creacion = H005H2_n116unidades_gisfecha_creacion[0];
               A115unidades_gisestado = H005H2_A115unidades_gisestado[0];
               n115unidades_gisestado = H005H2_n115unidades_gisestado[0];
               A103id_unidad = H005H2_A103id_unidad[0];
               /* Execute user event: Load */
               E205H2 ();
               pr_datastore1.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 84;
            WB5H0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5H2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ID_UNIDAD"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9"), context));
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
                                              AV7cunidades_gisestado ,
                                              AV8cunidades_gisfecha_creacion ,
                                              AV9cunidades_gishora_creacion ,
                                              AV10cunidades_giscreado_por ,
                                              AV11cunidades_gisfecha_modificacion ,
                                              AV12cunidades_gishora_modificacion ,
                                              A115unidades_gisestado ,
                                              A116unidades_gisfecha_creacion ,
                                              A117unidades_gishora_creacion ,
                                              A118unidades_giscreado_por ,
                                              A119unidades_gisfecha_modificacion ,
                                              A120unidades_gishora_modificacion ,
                                              AV6cid_unidad } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV10cunidades_giscreado_por = StringUtil.Concat( StringUtil.RTrim( AV10cunidades_giscreado_por), "%", "");
         /* Using cursor H005H3 */
         pr_datastore1.execute(1, new Object[] {AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, lV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion});
         GRID1_nRecordCount = H005H3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, AV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, AV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, AV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, AV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_unidad, AV7cunidades_gisestado, AV8cunidades_gisfecha_creacion, AV9cunidades_gishora_creacion, AV10cunidades_giscreado_por, AV11cunidades_gisfecha_modificacion, AV12cunidades_gishora_modificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195H2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCid_unidad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCid_unidad_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCID_UNIDAD");
               GX_FocusControl = edtavCid_unidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cid_unidad = 0;
               AssignAttri("", false, "AV6cid_unidad", StringUtil.LTrimStr( (decimal)(AV6cid_unidad), 9, 0));
            }
            else
            {
               AV6cid_unidad = (int)(context.localUtil.CToN( cgiGet( edtavCid_unidad_Internalname), ",", "."));
               AssignAttri("", false, "AV6cid_unidad", StringUtil.LTrimStr( (decimal)(AV6cid_unidad), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCunidades_gisestado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCunidades_gisestado_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUNIDADES_GISESTADO");
               GX_FocusControl = edtavCunidades_gisestado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cunidades_gisestado = 0;
               AssignAttri("", false, "AV7cunidades_gisestado", StringUtil.LTrimStr( (decimal)(AV7cunidades_gisestado), 9, 0));
            }
            else
            {
               AV7cunidades_gisestado = (int)(context.localUtil.CToN( cgiGet( edtavCunidades_gisestado_Internalname), ",", "."));
               AssignAttri("", false, "AV7cunidades_gisestado", StringUtil.LTrimStr( (decimal)(AV7cunidades_gisestado), 9, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCunidades_gisfecha_creacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_creacion"}), 1, "vCUNIDADES_GISFECHA_CREACION");
               GX_FocusControl = edtavCunidades_gisfecha_creacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cunidades_gisfecha_creacion = DateTime.MinValue;
               AssignAttri("", false, "AV8cunidades_gisfecha_creacion", context.localUtil.Format(AV8cunidades_gisfecha_creacion, "99/99/99"));
            }
            else
            {
               AV8cunidades_gisfecha_creacion = context.localUtil.CToD( cgiGet( edtavCunidades_gisfecha_creacion_Internalname), 2);
               AssignAttri("", false, "AV8cunidades_gisfecha_creacion", context.localUtil.Format(AV8cunidades_gisfecha_creacion, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCunidades_gishora_creacion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCunidades_gishora_creacion_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUNIDADES_GISHORA_CREACION");
               GX_FocusControl = edtavCunidades_gishora_creacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cunidades_gishora_creacion = 0;
               AssignAttri("", false, "AV9cunidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(AV9cunidades_gishora_creacion), 5, 0));
            }
            else
            {
               AV9cunidades_gishora_creacion = (int)(context.localUtil.CToN( cgiGet( edtavCunidades_gishora_creacion_Internalname), ",", "."));
               AssignAttri("", false, "AV9cunidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(AV9cunidades_gishora_creacion), 5, 0));
            }
            AV10cunidades_giscreado_por = cgiGet( edtavCunidades_giscreado_por_Internalname);
            AssignAttri("", false, "AV10cunidades_giscreado_por", AV10cunidades_giscreado_por);
            if ( context.localUtil.VCDate( cgiGet( edtavCunidades_gisfecha_modificacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_modificacion"}), 1, "vCUNIDADES_GISFECHA_MODIFICACION");
               GX_FocusControl = edtavCunidades_gisfecha_modificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cunidades_gisfecha_modificacion = DateTime.MinValue;
               AssignAttri("", false, "AV11cunidades_gisfecha_modificacion", context.localUtil.Format(AV11cunidades_gisfecha_modificacion, "99/99/99"));
            }
            else
            {
               AV11cunidades_gisfecha_modificacion = context.localUtil.CToD( cgiGet( edtavCunidades_gisfecha_modificacion_Internalname), 2);
               AssignAttri("", false, "AV11cunidades_gisfecha_modificacion", context.localUtil.Format(AV11cunidades_gisfecha_modificacion, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCunidades_gishora_modificacion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCunidades_gishora_modificacion_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUNIDADES_GISHORA_MODIFICACION");
               GX_FocusControl = edtavCunidades_gishora_modificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cunidades_gishora_modificacion = 0;
               AssignAttri("", false, "AV12cunidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(AV12cunidades_gishora_modificacion), 5, 0));
            }
            else
            {
               AV12cunidades_gishora_modificacion = (int)(context.localUtil.CToN( cgiGet( edtavCunidades_gishora_modificacion_Internalname), ",", "."));
               AssignAttri("", false, "AV12cunidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(AV12cunidades_gishora_modificacion), 5, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_UNIDAD"), ",", ".") != Convert.ToDecimal( AV6cid_unidad )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUNIDADES_GISESTADO"), ",", ".") != Convert.ToDecimal( AV7cunidades_gisestado )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCUNIDADES_GISFECHA_CREACION"), 2) != AV8cunidades_gisfecha_creacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUNIDADES_GISHORA_CREACION"), ",", ".") != Convert.ToDecimal( AV9cunidades_gishora_creacion )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUNIDADES_GISCREADO_POR"), AV10cunidades_giscreado_por) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToD( cgiGet( "GXH_vCUNIDADES_GISFECHA_MODIFICACION"), 2) != AV11cunidades_gisfecha_modificacion )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUNIDADES_GISHORA_MODIFICACION"), ",", ".") != Convert.ToDecimal( AV12cunidades_gishora_modificacion )) )
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
         E195H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195H2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "unidades_gis", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E205H2( )
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
         E215H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215H2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pid_unidad = A103id_unidad;
         AssignAttri("", false, "AV13pid_unidad", StringUtil.LTrimStr( (decimal)(AV13pid_unidad), 9, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pid_unidad});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pid_unidad"});
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
         AV13pid_unidad = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pid_unidad", StringUtil.LTrimStr( (decimal)(AV13pid_unidad), 9, 0));
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
         PA5H2( ) ;
         WS5H2( ) ;
         WE5H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249572273", true, true);
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
         context.AddJavascriptSource("gx00c0.js", "?20231249572274", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_84_idx;
         edtunidades_gisestado_Internalname = "UNIDADES_GISESTADO_"+sGXsfl_84_idx;
         edtunidades_gisfecha_creacion_Internalname = "UNIDADES_GISFECHA_CREACION_"+sGXsfl_84_idx;
         edtunidades_gishora_creacion_Internalname = "UNIDADES_GISHORA_CREACION_"+sGXsfl_84_idx;
         edtunidades_giscreado_por_Internalname = "UNIDADES_GISCREADO_POR_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtid_unidad_Internalname = "ID_UNIDAD_"+sGXsfl_84_fel_idx;
         edtunidades_gisestado_Internalname = "UNIDADES_GISESTADO_"+sGXsfl_84_fel_idx;
         edtunidades_gisfecha_creacion_Internalname = "UNIDADES_GISFECHA_CREACION_"+sGXsfl_84_fel_idx;
         edtunidades_gishora_creacion_Internalname = "UNIDADES_GISHORA_CREACION_"+sGXsfl_84_fel_idx;
         edtunidades_giscreado_por_Internalname = "UNIDADES_GISCREADO_POR_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB5H0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ",", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_unidad_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_unidad_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gisestado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A115unidades_gisestado), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A115unidades_gisestado), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gisestado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gisfecha_creacion_Internalname,context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"),context.localUtil.Format( A116unidades_gisfecha_creacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gisfecha_creacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_gishora_creacion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A117unidades_gishora_creacion), 5, 0, ",", "")),context.localUtil.Format( (decimal)(A117unidades_gishora_creacion), "ZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_gishora_creacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtunidades_giscreado_por_Internalname,(string)A118unidades_giscreado_por,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtunidades_giscreado_por_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes5H2( ) ;
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
         lblLblid_unidadfilter_Internalname = "LBLID_UNIDADFILTER";
         edtavCid_unidad_Internalname = "vCID_UNIDAD";
         divId_unidadfiltercontainer_Internalname = "ID_UNIDADFILTERCONTAINER";
         lblLblunidades_gisestadofilter_Internalname = "LBLUNIDADES_GISESTADOFILTER";
         edtavCunidades_gisestado_Internalname = "vCUNIDADES_GISESTADO";
         divUnidades_gisestadofiltercontainer_Internalname = "UNIDADES_GISESTADOFILTERCONTAINER";
         lblLblunidades_gisfecha_creacionfilter_Internalname = "LBLUNIDADES_GISFECHA_CREACIONFILTER";
         edtavCunidades_gisfecha_creacion_Internalname = "vCUNIDADES_GISFECHA_CREACION";
         divUnidades_gisfecha_creacionfiltercontainer_Internalname = "UNIDADES_GISFECHA_CREACIONFILTERCONTAINER";
         lblLblunidades_gishora_creacionfilter_Internalname = "LBLUNIDADES_GISHORA_CREACIONFILTER";
         edtavCunidades_gishora_creacion_Internalname = "vCUNIDADES_GISHORA_CREACION";
         divUnidades_gishora_creacionfiltercontainer_Internalname = "UNIDADES_GISHORA_CREACIONFILTERCONTAINER";
         lblLblunidades_giscreado_porfilter_Internalname = "LBLUNIDADES_GISCREADO_PORFILTER";
         edtavCunidades_giscreado_por_Internalname = "vCUNIDADES_GISCREADO_POR";
         divUnidades_giscreado_porfiltercontainer_Internalname = "UNIDADES_GISCREADO_PORFILTERCONTAINER";
         lblLblunidades_gisfecha_modificacionfilter_Internalname = "LBLUNIDADES_GISFECHA_MODIFICACIONFILTER";
         edtavCunidades_gisfecha_modificacion_Internalname = "vCUNIDADES_GISFECHA_MODIFICACION";
         divUnidades_gisfecha_modificacionfiltercontainer_Internalname = "UNIDADES_GISFECHA_MODIFICACIONFILTERCONTAINER";
         lblLblunidades_gishora_modificacionfilter_Internalname = "LBLUNIDADES_GISHORA_MODIFICACIONFILTER";
         edtavCunidades_gishora_modificacion_Internalname = "vCUNIDADES_GISHORA_MODIFICACION";
         divUnidades_gishora_modificacionfiltercontainer_Internalname = "UNIDADES_GISHORA_MODIFICACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtid_unidad_Internalname = "ID_UNIDAD";
         edtunidades_gisestado_Internalname = "UNIDADES_GISESTADO";
         edtunidades_gisfecha_creacion_Internalname = "UNIDADES_GISFECHA_CREACION";
         edtunidades_gishora_creacion_Internalname = "UNIDADES_GISHORA_CREACION";
         edtunidades_giscreado_por_Internalname = "UNIDADES_GISCREADO_POR";
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
         edtunidades_giscreado_por_Jsonclick = "";
         edtunidades_gishora_creacion_Jsonclick = "";
         edtunidades_gisfecha_creacion_Jsonclick = "";
         edtunidades_gisestado_Jsonclick = "";
         edtid_unidad_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCunidades_gishora_modificacion_Jsonclick = "";
         edtavCunidades_gishora_modificacion_Enabled = 1;
         edtavCunidades_gishora_modificacion_Visible = 1;
         edtavCunidades_gisfecha_modificacion_Jsonclick = "";
         edtavCunidades_gisfecha_modificacion_Enabled = 1;
         edtavCunidades_giscreado_por_Jsonclick = "";
         edtavCunidades_giscreado_por_Enabled = 1;
         edtavCunidades_giscreado_por_Visible = 1;
         edtavCunidades_gishora_creacion_Jsonclick = "";
         edtavCunidades_gishora_creacion_Enabled = 1;
         edtavCunidades_gishora_creacion_Visible = 1;
         edtavCunidades_gisfecha_creacion_Jsonclick = "";
         edtavCunidades_gisfecha_creacion_Enabled = 1;
         edtavCunidades_gisestado_Jsonclick = "";
         edtavCunidades_gisestado_Enabled = 1;
         edtavCunidades_gisestado_Visible = 1;
         edtavCid_unidad_Jsonclick = "";
         edtavCid_unidad_Enabled = 1;
         edtavCid_unidad_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List unidades_gis";
         divUnidades_gishora_modificacionfiltercontainer_Class = "AdvancedContainerItem";
         divUnidades_gisfecha_modificacionfiltercontainer_Class = "AdvancedContainerItem";
         divUnidades_giscreado_porfiltercontainer_Class = "AdvancedContainerItem";
         divUnidades_gishora_creacionfiltercontainer_Class = "AdvancedContainerItem";
         divUnidades_gisfecha_creacionfiltercontainer_Class = "AdvancedContainerItem";
         divUnidades_gisestadofiltercontainer_Class = "AdvancedContainerItem";
         divId_unidadfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_unidad',fld:'vCID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV7cunidades_gisestado',fld:'vCUNIDADES_GISESTADO',pic:'ZZZZZZZZ9'},{av:'AV8cunidades_gisfecha_creacion',fld:'vCUNIDADES_GISFECHA_CREACION',pic:''},{av:'AV9cunidades_gishora_creacion',fld:'vCUNIDADES_GISHORA_CREACION',pic:'ZZZZ9'},{av:'AV10cunidades_giscreado_por',fld:'vCUNIDADES_GISCREADO_POR',pic:''},{av:'AV11cunidades_gisfecha_modificacion',fld:'vCUNIDADES_GISFECHA_MODIFICACION',pic:''},{av:'AV12cunidades_gishora_modificacion',fld:'vCUNIDADES_GISHORA_MODIFICACION',pic:'ZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E185H1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLID_UNIDADFILTER.CLICK","{handler:'E115H1',iparms:[{av:'divId_unidadfiltercontainer_Class',ctrl:'ID_UNIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLID_UNIDADFILTER.CLICK",",oparms:[{av:'divId_unidadfiltercontainer_Class',ctrl:'ID_UNIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCid_unidad_Visible',ctrl:'vCID_UNIDAD',prop:'Visible'}]}");
         setEventMetadata("LBLUNIDADES_GISESTADOFILTER.CLICK","{handler:'E125H1',iparms:[{av:'divUnidades_gisestadofiltercontainer_Class',ctrl:'UNIDADES_GISESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDADES_GISESTADOFILTER.CLICK",",oparms:[{av:'divUnidades_gisestadofiltercontainer_Class',ctrl:'UNIDADES_GISESTADOFILTERCONTAINER',prop:'Class'},{av:'edtavCunidades_gisestado_Visible',ctrl:'vCUNIDADES_GISESTADO',prop:'Visible'}]}");
         setEventMetadata("LBLUNIDADES_GISFECHA_CREACIONFILTER.CLICK","{handler:'E135H1',iparms:[{av:'divUnidades_gisfecha_creacionfiltercontainer_Class',ctrl:'UNIDADES_GISFECHA_CREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDADES_GISFECHA_CREACIONFILTER.CLICK",",oparms:[{av:'divUnidades_gisfecha_creacionfiltercontainer_Class',ctrl:'UNIDADES_GISFECHA_CREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLUNIDADES_GISHORA_CREACIONFILTER.CLICK","{handler:'E145H1',iparms:[{av:'divUnidades_gishora_creacionfiltercontainer_Class',ctrl:'UNIDADES_GISHORA_CREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDADES_GISHORA_CREACIONFILTER.CLICK",",oparms:[{av:'divUnidades_gishora_creacionfiltercontainer_Class',ctrl:'UNIDADES_GISHORA_CREACIONFILTERCONTAINER',prop:'Class'},{av:'edtavCunidades_gishora_creacion_Visible',ctrl:'vCUNIDADES_GISHORA_CREACION',prop:'Visible'}]}");
         setEventMetadata("LBLUNIDADES_GISCREADO_PORFILTER.CLICK","{handler:'E155H1',iparms:[{av:'divUnidades_giscreado_porfiltercontainer_Class',ctrl:'UNIDADES_GISCREADO_PORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDADES_GISCREADO_PORFILTER.CLICK",",oparms:[{av:'divUnidades_giscreado_porfiltercontainer_Class',ctrl:'UNIDADES_GISCREADO_PORFILTERCONTAINER',prop:'Class'},{av:'edtavCunidades_giscreado_por_Visible',ctrl:'vCUNIDADES_GISCREADO_POR',prop:'Visible'}]}");
         setEventMetadata("LBLUNIDADES_GISFECHA_MODIFICACIONFILTER.CLICK","{handler:'E165H1',iparms:[{av:'divUnidades_gisfecha_modificacionfiltercontainer_Class',ctrl:'UNIDADES_GISFECHA_MODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDADES_GISFECHA_MODIFICACIONFILTER.CLICK",",oparms:[{av:'divUnidades_gisfecha_modificacionfiltercontainer_Class',ctrl:'UNIDADES_GISFECHA_MODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLUNIDADES_GISHORA_MODIFICACIONFILTER.CLICK","{handler:'E175H1',iparms:[{av:'divUnidades_gishora_modificacionfiltercontainer_Class',ctrl:'UNIDADES_GISHORA_MODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDADES_GISHORA_MODIFICACIONFILTER.CLICK",",oparms:[{av:'divUnidades_gishora_modificacionfiltercontainer_Class',ctrl:'UNIDADES_GISHORA_MODIFICACIONFILTERCONTAINER',prop:'Class'},{av:'edtavCunidades_gishora_modificacion_Visible',ctrl:'vCUNIDADES_GISHORA_MODIFICACION',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E215H2',iparms:[{av:'A103id_unidad',fld:'ID_UNIDAD',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pid_unidad',fld:'vPID_UNIDAD',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_unidad',fld:'vCID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV7cunidades_gisestado',fld:'vCUNIDADES_GISESTADO',pic:'ZZZZZZZZ9'},{av:'AV8cunidades_gisfecha_creacion',fld:'vCUNIDADES_GISFECHA_CREACION',pic:''},{av:'AV9cunidades_gishora_creacion',fld:'vCUNIDADES_GISHORA_CREACION',pic:'ZZZZ9'},{av:'AV10cunidades_giscreado_por',fld:'vCUNIDADES_GISCREADO_POR',pic:''},{av:'AV11cunidades_gisfecha_modificacion',fld:'vCUNIDADES_GISFECHA_MODIFICACION',pic:''},{av:'AV12cunidades_gishora_modificacion',fld:'vCUNIDADES_GISHORA_MODIFICACION',pic:'ZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_unidad',fld:'vCID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV7cunidades_gisestado',fld:'vCUNIDADES_GISESTADO',pic:'ZZZZZZZZ9'},{av:'AV8cunidades_gisfecha_creacion',fld:'vCUNIDADES_GISFECHA_CREACION',pic:''},{av:'AV9cunidades_gishora_creacion',fld:'vCUNIDADES_GISHORA_CREACION',pic:'ZZZZ9'},{av:'AV10cunidades_giscreado_por',fld:'vCUNIDADES_GISCREADO_POR',pic:''},{av:'AV11cunidades_gisfecha_modificacion',fld:'vCUNIDADES_GISFECHA_MODIFICACION',pic:''},{av:'AV12cunidades_gishora_modificacion',fld:'vCUNIDADES_GISHORA_MODIFICACION',pic:'ZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_unidad',fld:'vCID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV7cunidades_gisestado',fld:'vCUNIDADES_GISESTADO',pic:'ZZZZZZZZ9'},{av:'AV8cunidades_gisfecha_creacion',fld:'vCUNIDADES_GISFECHA_CREACION',pic:''},{av:'AV9cunidades_gishora_creacion',fld:'vCUNIDADES_GISHORA_CREACION',pic:'ZZZZ9'},{av:'AV10cunidades_giscreado_por',fld:'vCUNIDADES_GISCREADO_POR',pic:''},{av:'AV11cunidades_gisfecha_modificacion',fld:'vCUNIDADES_GISFECHA_MODIFICACION',pic:''},{av:'AV12cunidades_gishora_modificacion',fld:'vCUNIDADES_GISHORA_MODIFICACION',pic:'ZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_unidad',fld:'vCID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV7cunidades_gisestado',fld:'vCUNIDADES_GISESTADO',pic:'ZZZZZZZZ9'},{av:'AV8cunidades_gisfecha_creacion',fld:'vCUNIDADES_GISFECHA_CREACION',pic:''},{av:'AV9cunidades_gishora_creacion',fld:'vCUNIDADES_GISHORA_CREACION',pic:'ZZZZ9'},{av:'AV10cunidades_giscreado_por',fld:'vCUNIDADES_GISCREADO_POR',pic:''},{av:'AV11cunidades_gisfecha_modificacion',fld:'vCUNIDADES_GISFECHA_MODIFICACION',pic:''},{av:'AV12cunidades_gishora_modificacion',fld:'vCUNIDADES_GISHORA_MODIFICACION',pic:'ZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CUNIDADES_GISFECHA_CREACION","{handler:'Validv_Cunidades_gisfecha_creacion',iparms:[]");
         setEventMetadata("VALIDV_CUNIDADES_GISFECHA_CREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CUNIDADES_GISFECHA_MODIFICACION","{handler:'Validv_Cunidades_gisfecha_modificacion',iparms:[]");
         setEventMetadata("VALIDV_CUNIDADES_GISFECHA_MODIFICACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Unidades_giscreado_por',iparms:[]");
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
         AV8cunidades_gisfecha_creacion = DateTime.MinValue;
         AV10cunidades_giscreado_por = "";
         AV11cunidades_gisfecha_modificacion = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblid_unidadfilter_Jsonclick = "";
         TempTags = "";
         lblLblunidades_gisestadofilter_Jsonclick = "";
         lblLblunidades_gisfecha_creacionfilter_Jsonclick = "";
         lblLblunidades_gishora_creacionfilter_Jsonclick = "";
         lblLblunidades_giscreado_porfilter_Jsonclick = "";
         lblLblunidades_gisfecha_modificacionfilter_Jsonclick = "";
         lblLblunidades_gishora_modificacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A116unidades_gisfecha_creacion = DateTime.MinValue;
         A118unidades_giscreado_por = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV10cunidades_giscreado_por = "";
         A119unidades_gisfecha_modificacion = DateTime.MinValue;
         H005H2_A120unidades_gishora_modificacion = new int[1] ;
         H005H2_n120unidades_gishora_modificacion = new bool[] {false} ;
         H005H2_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         H005H2_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         H005H2_A118unidades_giscreado_por = new string[] {""} ;
         H005H2_n118unidades_giscreado_por = new bool[] {false} ;
         H005H2_A117unidades_gishora_creacion = new int[1] ;
         H005H2_n117unidades_gishora_creacion = new bool[] {false} ;
         H005H2_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         H005H2_n116unidades_gisfecha_creacion = new bool[] {false} ;
         H005H2_A115unidades_gisestado = new int[1] ;
         H005H2_n115unidades_gisestado = new bool[] {false} ;
         H005H2_A103id_unidad = new int[1] ;
         H005H3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.gx00c0__datastore1(),
            new Object[][] {
                new Object[] {
               H005H2_A120unidades_gishora_modificacion, H005H2_n120unidades_gishora_modificacion, H005H2_A119unidades_gisfecha_modificacion, H005H2_n119unidades_gisfecha_modificacion, H005H2_A118unidades_giscreado_por, H005H2_n118unidades_giscreado_por, H005H2_A117unidades_gishora_creacion, H005H2_n117unidades_gishora_creacion, H005H2_A116unidades_gisfecha_creacion, H005H2_n116unidades_gisfecha_creacion,
               H005H2_A115unidades_gisestado, H005H2_n115unidades_gisestado, H005H2_A103id_unidad
               }
               , new Object[] {
               H005H3_AGRID1_nRecordCount
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
      private int AV13pid_unidad ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV6cid_unidad ;
      private int AV7cunidades_gisestado ;
      private int AV9cunidades_gishora_creacion ;
      private int AV12cunidades_gishora_modificacion ;
      private int edtavCid_unidad_Enabled ;
      private int edtavCid_unidad_Visible ;
      private int edtavCunidades_gisestado_Enabled ;
      private int edtavCunidades_gisestado_Visible ;
      private int edtavCunidades_gisfecha_creacion_Enabled ;
      private int edtavCunidades_gishora_creacion_Enabled ;
      private int edtavCunidades_gishora_creacion_Visible ;
      private int edtavCunidades_giscreado_por_Visible ;
      private int edtavCunidades_giscreado_por_Enabled ;
      private int edtavCunidades_gisfecha_modificacion_Enabled ;
      private int edtavCunidades_gishora_modificacion_Enabled ;
      private int edtavCunidades_gishora_modificacion_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A103id_unidad ;
      private int A115unidades_gisestado ;
      private int A117unidades_gishora_creacion ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A120unidades_gishora_modificacion ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divId_unidadfiltercontainer_Class ;
      private string divUnidades_gisestadofiltercontainer_Class ;
      private string divUnidades_gisfecha_creacionfiltercontainer_Class ;
      private string divUnidades_gishora_creacionfiltercontainer_Class ;
      private string divUnidades_giscreado_porfiltercontainer_Class ;
      private string divUnidades_gisfecha_modificacionfiltercontainer_Class ;
      private string divUnidades_gishora_modificacionfiltercontainer_Class ;
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
      private string divId_unidadfiltercontainer_Internalname ;
      private string lblLblid_unidadfilter_Internalname ;
      private string lblLblid_unidadfilter_Jsonclick ;
      private string edtavCid_unidad_Internalname ;
      private string TempTags ;
      private string edtavCid_unidad_Jsonclick ;
      private string divUnidades_gisestadofiltercontainer_Internalname ;
      private string lblLblunidades_gisestadofilter_Internalname ;
      private string lblLblunidades_gisestadofilter_Jsonclick ;
      private string edtavCunidades_gisestado_Internalname ;
      private string edtavCunidades_gisestado_Jsonclick ;
      private string divUnidades_gisfecha_creacionfiltercontainer_Internalname ;
      private string lblLblunidades_gisfecha_creacionfilter_Internalname ;
      private string lblLblunidades_gisfecha_creacionfilter_Jsonclick ;
      private string edtavCunidades_gisfecha_creacion_Internalname ;
      private string edtavCunidades_gisfecha_creacion_Jsonclick ;
      private string divUnidades_gishora_creacionfiltercontainer_Internalname ;
      private string lblLblunidades_gishora_creacionfilter_Internalname ;
      private string lblLblunidades_gishora_creacionfilter_Jsonclick ;
      private string edtavCunidades_gishora_creacion_Internalname ;
      private string edtavCunidades_gishora_creacion_Jsonclick ;
      private string divUnidades_giscreado_porfiltercontainer_Internalname ;
      private string lblLblunidades_giscreado_porfilter_Internalname ;
      private string lblLblunidades_giscreado_porfilter_Jsonclick ;
      private string edtavCunidades_giscreado_por_Internalname ;
      private string edtavCunidades_giscreado_por_Jsonclick ;
      private string divUnidades_gisfecha_modificacionfiltercontainer_Internalname ;
      private string lblLblunidades_gisfecha_modificacionfilter_Internalname ;
      private string lblLblunidades_gisfecha_modificacionfilter_Jsonclick ;
      private string edtavCunidades_gisfecha_modificacion_Internalname ;
      private string edtavCunidades_gisfecha_modificacion_Jsonclick ;
      private string divUnidades_gishora_modificacionfiltercontainer_Internalname ;
      private string lblLblunidades_gishora_modificacionfilter_Internalname ;
      private string lblLblunidades_gishora_modificacionfilter_Jsonclick ;
      private string edtavCunidades_gishora_modificacion_Internalname ;
      private string edtavCunidades_gishora_modificacion_Jsonclick ;
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
      private string edtid_unidad_Internalname ;
      private string edtunidades_gisestado_Internalname ;
      private string edtunidades_gisfecha_creacion_Internalname ;
      private string edtunidades_gishora_creacion_Internalname ;
      private string edtunidades_giscreado_por_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtid_unidad_Jsonclick ;
      private string edtunidades_gisestado_Jsonclick ;
      private string edtunidades_gisfecha_creacion_Jsonclick ;
      private string edtunidades_gishora_creacion_Jsonclick ;
      private string edtunidades_giscreado_por_Jsonclick ;
      private DateTime AV8cunidades_gisfecha_creacion ;
      private DateTime AV11cunidades_gisfecha_modificacion ;
      private DateTime A116unidades_gisfecha_creacion ;
      private DateTime A119unidades_gisfecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n115unidades_gisestado ;
      private bool n116unidades_gisfecha_creacion ;
      private bool n117unidades_gishora_creacion ;
      private bool n118unidades_giscreado_por ;
      private bool gxdyncontrolsrefreshing ;
      private bool n120unidades_gishora_modificacion ;
      private bool n119unidades_gisfecha_modificacion ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV10cunidades_giscreado_por ;
      private string A118unidades_giscreado_por ;
      private string AV17Linkselection_GXI ;
      private string lV10cunidades_giscreado_por ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H005H2_A120unidades_gishora_modificacion ;
      private bool[] H005H2_n120unidades_gishora_modificacion ;
      private DateTime[] H005H2_A119unidades_gisfecha_modificacion ;
      private bool[] H005H2_n119unidades_gisfecha_modificacion ;
      private string[] H005H2_A118unidades_giscreado_por ;
      private bool[] H005H2_n118unidades_giscreado_por ;
      private int[] H005H2_A117unidades_gishora_creacion ;
      private bool[] H005H2_n117unidades_gishora_creacion ;
      private DateTime[] H005H2_A116unidades_gisfecha_creacion ;
      private bool[] H005H2_n116unidades_gisfecha_creacion ;
      private int[] H005H2_A115unidades_gisestado ;
      private bool[] H005H2_n115unidades_gisestado ;
      private int[] H005H2_A103id_unidad ;
      private long[] H005H3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pid_unidad ;
      private GXWebForm Form ;
   }

   public class gx00c0__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005H2( IGxContext context ,
                                             int AV7cunidades_gisestado ,
                                             DateTime AV8cunidades_gisfecha_creacion ,
                                             int AV9cunidades_gishora_creacion ,
                                             string AV10cunidades_giscreado_por ,
                                             DateTime AV11cunidades_gisfecha_modificacion ,
                                             int AV12cunidades_gishora_modificacion ,
                                             int A115unidades_gisestado ,
                                             DateTime A116unidades_gisfecha_creacion ,
                                             int A117unidades_gishora_creacion ,
                                             string A118unidades_giscreado_por ,
                                             DateTime A119unidades_gisfecha_modificacion ,
                                             int A120unidades_gishora_modificacion ,
                                             int AV6cid_unidad )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [hora_modificacion], [fecha_modificacion], [creado_por], [hora_creacion], [fecha_creacion], [estado], [id_unidad]";
         sFromString = " FROM dbo.[unidades_gis]";
         sOrderString = "";
         AddWhere(sWhereString, "([id_unidad] >= @AV6cid_unidad)");
         if ( ! (0==AV7cunidades_gisestado) )
         {
            AddWhere(sWhereString, "([estado] >= @AV7cunidades_gisestado)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cunidades_gisfecha_creacion) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV8cunidades_gisfecha_creacion)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cunidades_gishora_creacion) )
         {
            AddWhere(sWhereString, "([hora_creacion] >= @AV9cunidades_gishora_creacion)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cunidades_giscreado_por)) )
         {
            AddWhere(sWhereString, "([creado_por] like @lV10cunidades_giscreado_por)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cunidades_gisfecha_modificacion) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV11cunidades_gisfecha_modificacion)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cunidades_gishora_modificacion) )
         {
            AddWhere(sWhereString, "([hora_modificacion] >= @AV12cunidades_gishora_modificacion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [id_unidad]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005H3( IGxContext context ,
                                             int AV7cunidades_gisestado ,
                                             DateTime AV8cunidades_gisfecha_creacion ,
                                             int AV9cunidades_gishora_creacion ,
                                             string AV10cunidades_giscreado_por ,
                                             DateTime AV11cunidades_gisfecha_modificacion ,
                                             int AV12cunidades_gishora_modificacion ,
                                             int A115unidades_gisestado ,
                                             DateTime A116unidades_gisfecha_creacion ,
                                             int A117unidades_gishora_creacion ,
                                             string A118unidades_giscreado_por ,
                                             DateTime A119unidades_gisfecha_modificacion ,
                                             int A120unidades_gishora_modificacion ,
                                             int AV6cid_unidad )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[unidades_gis]";
         AddWhere(sWhereString, "([id_unidad] >= @AV6cid_unidad)");
         if ( ! (0==AV7cunidades_gisestado) )
         {
            AddWhere(sWhereString, "([estado] >= @AV7cunidades_gisestado)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cunidades_gisfecha_creacion) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV8cunidades_gisfecha_creacion)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cunidades_gishora_creacion) )
         {
            AddWhere(sWhereString, "([hora_creacion] >= @AV9cunidades_gishora_creacion)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cunidades_giscreado_por)) )
         {
            AddWhere(sWhereString, "([creado_por] like @lV10cunidades_giscreado_por)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV11cunidades_gisfecha_modificacion) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV11cunidades_gisfecha_modificacion)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cunidades_gishora_modificacion) )
         {
            AddWhere(sWhereString, "([hora_modificacion] >= @AV12cunidades_gishora_modificacion)");
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
                     return conditional_H005H2(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H005H3(context, (int)dynConstraints[0] , (DateTime)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (DateTime)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH005H2;
          prmH005H2 = new Object[] {
          new ParDef("@AV6cid_unidad",GXType.Int32,9,0) ,
          new ParDef("@AV7cunidades_gisestado",GXType.Int32,9,0) ,
          new ParDef("@AV8cunidades_gisfecha_creacion",GXType.Date,8,0) ,
          new ParDef("@AV9cunidades_gishora_creacion",GXType.Int32,5,0) ,
          new ParDef("@lV10cunidades_giscreado_por",GXType.NVarChar,30,0) ,
          new ParDef("@AV11cunidades_gisfecha_modificacion",GXType.Date,8,0) ,
          new ParDef("@AV12cunidades_gishora_modificacion",GXType.Int32,5,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005H3;
          prmH005H3 = new Object[] {
          new ParDef("@AV6cid_unidad",GXType.Int32,9,0) ,
          new ParDef("@AV7cunidades_gisestado",GXType.Int32,9,0) ,
          new ParDef("@AV8cunidades_gisfecha_creacion",GXType.Date,8,0) ,
          new ParDef("@AV9cunidades_gishora_creacion",GXType.Int32,5,0) ,
          new ParDef("@lV10cunidades_giscreado_por",GXType.NVarChar,30,0) ,
          new ParDef("@AV11cunidades_gisfecha_modificacion",GXType.Date,8,0) ,
          new ParDef("@AV12cunidades_gishora_modificacion",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005H2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005H3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getVarchar(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
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
