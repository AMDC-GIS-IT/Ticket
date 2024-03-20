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
   public class gx00d0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00d0( )
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

      public gx00d0( IGxContext context )
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

      public void execute( out int aP0_pid_actividad_categoria )
      {
         this.AV13pid_actividad_categoria = 0 ;
         executePrivate();
         aP0_pid_actividad_categoria=this.AV13pid_actividad_categoria;
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
            gxfirstwebparm = GetFirstPar( "pid_actividad_categoria");
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
               gxfirstwebparm = GetFirstPar( "pid_actividad_categoria");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pid_actividad_categoria");
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
               AV6cid_actividad_categoria = (int)(NumberUtil.Val( GetPar( "cid_actividad_categoria"), "."));
               AV7cactividades_categoriaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "cactividades_categoriaid_tipo_categoria"), "."));
               AV8cunidad_medida = GetPar( "cunidad_medida");
               AV9cactividades_categoriaestado = (int)(NumberUtil.Val( GetPar( "cactividades_categoriaestado"), "."));
               AV10cprograma_enero = (int)(NumberUtil.Val( GetPar( "cprograma_enero"), "."));
               AV11cprograma_febrero = (int)(NumberUtil.Val( GetPar( "cprograma_febrero"), "."));
               AV12cprograma_marzo = (int)(NumberUtil.Val( GetPar( "cprograma_marzo"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, AV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "ID_ACTIVIDAD_CATEGORIAFILTERCONTAINER_Class", StringUtil.RTrim( divId_actividad_categoriafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTERCONTAINER_Class", StringUtil.RTrim( divActividades_categoriaid_tipo_categoriafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "UNIDAD_MEDIDAFILTERCONTAINER_Class", StringUtil.RTrim( divUnidad_medidafiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "ACTIVIDADES_CATEGORIAESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divActividades_categoriaestadofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "PROGRAMA_ENEROFILTERCONTAINER_Class", StringUtil.RTrim( divPrograma_enerofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "PROGRAMA_FEBREROFILTERCONTAINER_Class", StringUtil.RTrim( divPrograma_febrerofiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "PROGRAMA_MARZOFILTERCONTAINER_Class", StringUtil.RTrim( divPrograma_marzofiltercontainer_Class));
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
               AV13pid_actividad_categoria = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pid_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV13pid_actividad_categoria), 9, 0));
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
            return "gx00d0_Execute" ;
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
         PA5I2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5I2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249572298", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00d0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pid_actividad_categoria,9,0))}, new string[] {"pid_actividad_categoria"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCID_ACTIVIDAD_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cid_actividad_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cactividades_categoriaid_tipo_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUNIDAD_MEDIDA", AV8cunidad_medida);
         GxWebStd.gx_hidden_field( context, "GXH_vCACTIVIDADES_CATEGORIAESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cactividades_categoriaestado), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROGRAMA_ENERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cprograma_enero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROGRAMA_FEBRERO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cprograma_febrero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPROGRAMA_MARZO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cprograma_marzo), 9, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPID_ACTIVIDAD_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pid_actividad_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "ID_ACTIVIDAD_CATEGORIAFILTERCONTAINER_Class", StringUtil.RTrim( divId_actividad_categoriafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTERCONTAINER_Class", StringUtil.RTrim( divActividades_categoriaid_tipo_categoriafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "UNIDAD_MEDIDAFILTERCONTAINER_Class", StringUtil.RTrim( divUnidad_medidafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ACTIVIDADES_CATEGORIAESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divActividades_categoriaestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROGRAMA_ENEROFILTERCONTAINER_Class", StringUtil.RTrim( divPrograma_enerofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROGRAMA_FEBREROFILTERCONTAINER_Class", StringUtil.RTrim( divPrograma_febrerofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PROGRAMA_MARZOFILTERCONTAINER_Class", StringUtil.RTrim( divPrograma_marzofiltercontainer_Class));
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
            WE5I2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5I2( ) ;
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
         return formatLink("gx00d0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pid_actividad_categoria,9,0))}, new string[] {"pid_actividad_categoria"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00D0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List actividades_categoria" ;
      }

      protected void WB5I0( )
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
            GxWebStd.gx_div_start( context, divId_actividad_categoriafiltercontainer_Internalname, 1, 0, "px", 0, "px", divId_actividad_categoriafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblid_actividad_categoriafilter_Internalname, "id_actividad_categoria", "", "", lblLblid_actividad_categoriafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCid_actividad_categoria_Internalname, "id_actividad_categoria", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCid_actividad_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cid_actividad_categoria), 9, 0, ",", "")), ((edtavCid_actividad_categoria_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6cid_actividad_categoria), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV6cid_actividad_categoria), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCid_actividad_categoria_Jsonclick, 0, "Attribute", "", "", "", "", edtavCid_actividad_categoria_Visible, edtavCid_actividad_categoria_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divActividades_categoriaid_tipo_categoriafiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividades_categoriaid_tipo_categoriafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividades_categoriaid_tipo_categoriafilter_Internalname, "actividades_categoriaid_tipo_categoria", "", "", lblLblactividades_categoriaid_tipo_categoriafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCactividades_categoriaid_tipo_categoria_Internalname, "id_tipo_categoria", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCactividades_categoriaid_tipo_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cactividades_categoriaid_tipo_categoria), 9, 0, ",", "")), ((edtavCactividades_categoriaid_tipo_categoria_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV7cactividades_categoriaid_tipo_categoria), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV7cactividades_categoriaid_tipo_categoria), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCactividades_categoriaid_tipo_categoria_Jsonclick, 0, "Attribute", "", "", "", "", edtavCactividades_categoriaid_tipo_categoria_Visible, edtavCactividades_categoriaid_tipo_categoria_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divUnidad_medidafiltercontainer_Internalname, 1, 0, "px", 0, "px", divUnidad_medidafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblunidad_medidafilter_Internalname, "unidad_medida", "", "", lblLblunidad_medidafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCunidad_medida_Internalname, "unidad_medida", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCunidad_medida_Internalname, AV8cunidad_medida, StringUtil.RTrim( context.localUtil.Format( AV8cunidad_medida, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCunidad_medida_Jsonclick, 0, "Attribute", "", "", "", "", edtavCunidad_medida_Visible, edtavCunidad_medida_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divActividades_categoriaestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divActividades_categoriaestadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblactividades_categoriaestadofilter_Internalname, "actividades_categoriaestado", "", "", lblLblactividades_categoriaestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCactividades_categoriaestado_Internalname, "estado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCactividades_categoriaestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9cactividades_categoriaestado), 9, 0, ",", "")), ((edtavCactividades_categoriaestado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV9cactividades_categoriaestado), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV9cactividades_categoriaestado), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCactividades_categoriaestado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCactividades_categoriaestado_Visible, edtavCactividades_categoriaestado_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divPrograma_enerofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPrograma_enerofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprograma_enerofilter_Internalname, "programa_enero", "", "", lblLblprograma_enerofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprograma_enero_Internalname, "programa_enero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprograma_enero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cprograma_enero), 9, 0, ",", "")), ((edtavCprograma_enero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV10cprograma_enero), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV10cprograma_enero), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprograma_enero_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprograma_enero_Visible, edtavCprograma_enero_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divPrograma_febrerofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPrograma_febrerofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprograma_febrerofilter_Internalname, "programa_febrero", "", "", lblLblprograma_febrerofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprograma_febrero_Internalname, "programa_febrero", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprograma_febrero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cprograma_febrero), 9, 0, ",", "")), ((edtavCprograma_febrero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11cprograma_febrero), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV11cprograma_febrero), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprograma_febrero_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprograma_febrero_Visible, edtavCprograma_febrero_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_div_start( context, divPrograma_marzofiltercontainer_Internalname, 1, 0, "px", 0, "px", divPrograma_marzofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprograma_marzofilter_Internalname, "programa_marzo", "", "", lblLblprograma_marzofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e175i1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00D0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprograma_marzo_Internalname, "programa_marzo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprograma_marzo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cprograma_marzo), 9, 0, ",", "")), ((edtavCprograma_marzo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV12cprograma_marzo), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV12cprograma_marzo), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprograma_marzo_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprograma_marzo_Visible, edtavCprograma_marzo_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00D0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e185i1_client"+"'", TempTags, "", 2, "HLP_Gx00D0.htm");
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
               context.SendWebValue( "id_actividad_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "id_tipo_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "estado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "programa_enero") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "programa_febrero") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtactividades_categoriaid_tipo_categoria_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A125actividades_categoriaestado), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A126programa_enero), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A127programa_febrero), 9, 0, ".", "")));
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00D0.htm");
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

      protected void START5I2( )
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
            Form.Meta.addItem("description", "Selection List actividades_categoria", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5I0( ) ;
      }

      protected void WS5I2( )
      {
         START5I2( ) ;
         EVT5I2( ) ;
      }

      protected void EVT5I2( )
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
                              A102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ",", "."));
                              A122actividades_categoriaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriaid_tipo_categoria_Internalname), ",", "."));
                              n122actividades_categoriaid_tipo_categoria = false;
                              A125actividades_categoriaestado = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriaestado_Internalname), ",", "."));
                              n125actividades_categoriaestado = false;
                              A126programa_enero = (int)(context.localUtil.CToN( cgiGet( edtprograma_enero_Internalname), ",", "."));
                              n126programa_enero = false;
                              A127programa_febrero = (int)(context.localUtil.CToN( cgiGet( edtprograma_febrero_Internalname), ",", "."));
                              n127programa_febrero = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E205I2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cid_actividad_categoria Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_ACTIVIDAD_CATEGORIA"), ",", ".") != Convert.ToDecimal( AV6cid_actividad_categoria )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cactividades_categoriaid_tipo_categoria Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA"), ",", ".") != Convert.ToDecimal( AV7cactividades_categoriaid_tipo_categoria )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cunidad_medida Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUNIDAD_MEDIDA"), AV8cunidad_medida) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cactividades_categoriaestado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADES_CATEGORIAESTADO"), ",", ".") != Convert.ToDecimal( AV9cactividades_categoriaestado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprograma_enero Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROGRAMA_ENERO"), ",", ".") != Convert.ToDecimal( AV10cprograma_enero )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprograma_febrero Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROGRAMA_FEBRERO"), ",", ".") != Convert.ToDecimal( AV11cprograma_febrero )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprograma_marzo Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROGRAMA_MARZO"), ",", ".") != Convert.ToDecimal( AV12cprograma_marzo )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E215I2 ();
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

      protected void WE5I2( )
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

      protected void PA5I2( )
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
                                        int AV6cid_actividad_categoria ,
                                        int AV7cactividades_categoriaid_tipo_categoria ,
                                        string AV8cunidad_medida ,
                                        int AV9cactividades_categoriaestado ,
                                        int AV10cprograma_enero ,
                                        int AV11cprograma_febrero ,
                                        int AV12cprograma_marzo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5I2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ID_ACTIVIDAD_CATEGORIA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "ID_ACTIVIDAD_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")));
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
         RF5I2( ) ;
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

      protected void RF5I2( )
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
                                                 AV7cactividades_categoriaid_tipo_categoria ,
                                                 AV8cunidad_medida ,
                                                 AV9cactividades_categoriaestado ,
                                                 AV10cprograma_enero ,
                                                 AV11cprograma_febrero ,
                                                 AV12cprograma_marzo ,
                                                 A122actividades_categoriaid_tipo_categoria ,
                                                 A124unidad_medida ,
                                                 A125actividades_categoriaestado ,
                                                 A126programa_enero ,
                                                 A127programa_febrero ,
                                                 A128programa_marzo ,
                                                 AV6cid_actividad_categoria } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV8cunidad_medida = StringUtil.Concat( StringUtil.RTrim( AV8cunidad_medida), "%", "");
            /* Using cursor H005I2 */
            pr_datastore1.execute(0, new Object[] {AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, lV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A128programa_marzo = H005I2_A128programa_marzo[0];
               n128programa_marzo = H005I2_n128programa_marzo[0];
               A124unidad_medida = H005I2_A124unidad_medida[0];
               n124unidad_medida = H005I2_n124unidad_medida[0];
               A127programa_febrero = H005I2_A127programa_febrero[0];
               n127programa_febrero = H005I2_n127programa_febrero[0];
               A126programa_enero = H005I2_A126programa_enero[0];
               n126programa_enero = H005I2_n126programa_enero[0];
               A125actividades_categoriaestado = H005I2_A125actividades_categoriaestado[0];
               n125actividades_categoriaestado = H005I2_n125actividades_categoriaestado[0];
               A122actividades_categoriaid_tipo_categoria = H005I2_A122actividades_categoriaid_tipo_categoria[0];
               n122actividades_categoriaid_tipo_categoria = H005I2_n122actividades_categoriaid_tipo_categoria[0];
               A102id_actividad_categoria = H005I2_A102id_actividad_categoria[0];
               /* Execute user event: Load */
               E205I2 ();
               pr_datastore1.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 84;
            WB5I0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5I2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_ID_ACTIVIDAD_CATEGORIA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9"), context));
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
                                              AV7cactividades_categoriaid_tipo_categoria ,
                                              AV8cunidad_medida ,
                                              AV9cactividades_categoriaestado ,
                                              AV10cprograma_enero ,
                                              AV11cprograma_febrero ,
                                              AV12cprograma_marzo ,
                                              A122actividades_categoriaid_tipo_categoria ,
                                              A124unidad_medida ,
                                              A125actividades_categoriaestado ,
                                              A126programa_enero ,
                                              A127programa_febrero ,
                                              A128programa_marzo ,
                                              AV6cid_actividad_categoria } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV8cunidad_medida = StringUtil.Concat( StringUtil.RTrim( AV8cunidad_medida), "%", "");
         /* Using cursor H005I3 */
         pr_datastore1.execute(1, new Object[] {AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, lV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo});
         GRID1_nRecordCount = H005I3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, AV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, AV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, AV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, AV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cid_actividad_categoria, AV7cactividades_categoriaid_tipo_categoria, AV8cunidad_medida, AV9cactividades_categoriaestado, AV10cprograma_enero, AV11cprograma_febrero, AV12cprograma_marzo) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5I0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195I2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCid_actividad_categoria_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCid_actividad_categoria_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCID_ACTIVIDAD_CATEGORIA");
               GX_FocusControl = edtavCid_actividad_categoria_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cid_actividad_categoria = 0;
               AssignAttri("", false, "AV6cid_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV6cid_actividad_categoria), 9, 0));
            }
            else
            {
               AV6cid_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( edtavCid_actividad_categoria_Internalname), ",", "."));
               AssignAttri("", false, "AV6cid_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV6cid_actividad_categoria), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCactividades_categoriaid_tipo_categoria_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCactividades_categoriaid_tipo_categoria_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA");
               GX_FocusControl = edtavCactividades_categoriaid_tipo_categoria_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cactividades_categoriaid_tipo_categoria = 0;
               AssignAttri("", false, "AV7cactividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7cactividades_categoriaid_tipo_categoria), 9, 0));
            }
            else
            {
               AV7cactividades_categoriaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtavCactividades_categoriaid_tipo_categoria_Internalname), ",", "."));
               AssignAttri("", false, "AV7cactividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7cactividades_categoriaid_tipo_categoria), 9, 0));
            }
            AV8cunidad_medida = cgiGet( edtavCunidad_medida_Internalname);
            AssignAttri("", false, "AV8cunidad_medida", AV8cunidad_medida);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCactividades_categoriaestado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCactividades_categoriaestado_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCACTIVIDADES_CATEGORIAESTADO");
               GX_FocusControl = edtavCactividades_categoriaestado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cactividades_categoriaestado = 0;
               AssignAttri("", false, "AV9cactividades_categoriaestado", StringUtil.LTrimStr( (decimal)(AV9cactividades_categoriaestado), 9, 0));
            }
            else
            {
               AV9cactividades_categoriaestado = (int)(context.localUtil.CToN( cgiGet( edtavCactividades_categoriaestado_Internalname), ",", "."));
               AssignAttri("", false, "AV9cactividades_categoriaestado", StringUtil.LTrimStr( (decimal)(AV9cactividades_categoriaestado), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprograma_enero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprograma_enero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROGRAMA_ENERO");
               GX_FocusControl = edtavCprograma_enero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cprograma_enero = 0;
               AssignAttri("", false, "AV10cprograma_enero", StringUtil.LTrimStr( (decimal)(AV10cprograma_enero), 9, 0));
            }
            else
            {
               AV10cprograma_enero = (int)(context.localUtil.CToN( cgiGet( edtavCprograma_enero_Internalname), ",", "."));
               AssignAttri("", false, "AV10cprograma_enero", StringUtil.LTrimStr( (decimal)(AV10cprograma_enero), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprograma_febrero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprograma_febrero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROGRAMA_FEBRERO");
               GX_FocusControl = edtavCprograma_febrero_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cprograma_febrero = 0;
               AssignAttri("", false, "AV11cprograma_febrero", StringUtil.LTrimStr( (decimal)(AV11cprograma_febrero), 9, 0));
            }
            else
            {
               AV11cprograma_febrero = (int)(context.localUtil.CToN( cgiGet( edtavCprograma_febrero_Internalname), ",", "."));
               AssignAttri("", false, "AV11cprograma_febrero", StringUtil.LTrimStr( (decimal)(AV11cprograma_febrero), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprograma_marzo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprograma_marzo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPROGRAMA_MARZO");
               GX_FocusControl = edtavCprograma_marzo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cprograma_marzo = 0;
               AssignAttri("", false, "AV12cprograma_marzo", StringUtil.LTrimStr( (decimal)(AV12cprograma_marzo), 9, 0));
            }
            else
            {
               AV12cprograma_marzo = (int)(context.localUtil.CToN( cgiGet( edtavCprograma_marzo_Internalname), ",", "."));
               AssignAttri("", false, "AV12cprograma_marzo", StringUtil.LTrimStr( (decimal)(AV12cprograma_marzo), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_ACTIVIDAD_CATEGORIA"), ",", ".") != Convert.ToDecimal( AV6cid_actividad_categoria )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA"), ",", ".") != Convert.ToDecimal( AV7cactividades_categoriaid_tipo_categoria )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUNIDAD_MEDIDA"), AV8cunidad_medida) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCACTIVIDADES_CATEGORIAESTADO"), ",", ".") != Convert.ToDecimal( AV9cactividades_categoriaestado )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROGRAMA_ENERO"), ",", ".") != Convert.ToDecimal( AV10cprograma_enero )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROGRAMA_FEBRERO"), ",", ".") != Convert.ToDecimal( AV11cprograma_febrero )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPROGRAMA_MARZO"), ",", ".") != Convert.ToDecimal( AV12cprograma_marzo )) )
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
         E195I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195I2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "actividades_categoria", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E205I2( )
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
         E215I2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215I2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pid_actividad_categoria = A102id_actividad_categoria;
         AssignAttri("", false, "AV13pid_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV13pid_actividad_categoria), 9, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pid_actividad_categoria});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pid_actividad_categoria"});
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
         AV13pid_actividad_categoria = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pid_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV13pid_actividad_categoria), 9, 0));
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
         PA5I2( ) ;
         WS5I2( ) ;
         WE5I2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249572363", true, true);
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
         context.AddJavascriptSource("gx00d0.js", "?20231249572363", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA_"+sGXsfl_84_idx;
         edtactividades_categoriaid_tipo_categoria_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_"+sGXsfl_84_idx;
         edtactividades_categoriaestado_Internalname = "ACTIVIDADES_CATEGORIAESTADO_"+sGXsfl_84_idx;
         edtprograma_enero_Internalname = "PROGRAMA_ENERO_"+sGXsfl_84_idx;
         edtprograma_febrero_Internalname = "PROGRAMA_FEBRERO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA_"+sGXsfl_84_fel_idx;
         edtactividades_categoriaid_tipo_categoria_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA_"+sGXsfl_84_fel_idx;
         edtactividades_categoriaestado_Internalname = "ACTIVIDADES_CATEGORIAESTADO_"+sGXsfl_84_fel_idx;
         edtprograma_enero_Internalname = "PROGRAMA_ENERO_"+sGXsfl_84_fel_idx;
         edtprograma_febrero_Internalname = "PROGRAMA_FEBRERO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB5I0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ",", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_actividad_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtid_actividad_categoria_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtactividades_categoriaid_tipo_categoria_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ",", "")))+"'"+"]);";
            AssignProp("", false, edtactividades_categoriaid_tipo_categoria_Internalname, "Link", edtactividades_categoriaid_tipo_categoria_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtactividades_categoriaid_tipo_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A122actividades_categoriaid_tipo_categoria), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtactividades_categoriaid_tipo_categoria_Link,(string)"",(string)"",(string)"",(string)edtactividades_categoriaid_tipo_categoria_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtactividades_categoriaestado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A125actividades_categoriaestado), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A125actividades_categoriaestado), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtactividades_categoriaestado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtprograma_enero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A126programa_enero), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A126programa_enero), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtprograma_enero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtprograma_febrero_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A127programa_febrero), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A127programa_febrero), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtprograma_febrero_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes5I2( ) ;
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
         lblLblid_actividad_categoriafilter_Internalname = "LBLID_ACTIVIDAD_CATEGORIAFILTER";
         edtavCid_actividad_categoria_Internalname = "vCID_ACTIVIDAD_CATEGORIA";
         divId_actividad_categoriafiltercontainer_Internalname = "ID_ACTIVIDAD_CATEGORIAFILTERCONTAINER";
         lblLblactividades_categoriaid_tipo_categoriafilter_Internalname = "LBLACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTER";
         edtavCactividades_categoriaid_tipo_categoria_Internalname = "vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         divActividades_categoriaid_tipo_categoriafiltercontainer_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTERCONTAINER";
         lblLblunidad_medidafilter_Internalname = "LBLUNIDAD_MEDIDAFILTER";
         edtavCunidad_medida_Internalname = "vCUNIDAD_MEDIDA";
         divUnidad_medidafiltercontainer_Internalname = "UNIDAD_MEDIDAFILTERCONTAINER";
         lblLblactividades_categoriaestadofilter_Internalname = "LBLACTIVIDADES_CATEGORIAESTADOFILTER";
         edtavCactividades_categoriaestado_Internalname = "vCACTIVIDADES_CATEGORIAESTADO";
         divActividades_categoriaestadofiltercontainer_Internalname = "ACTIVIDADES_CATEGORIAESTADOFILTERCONTAINER";
         lblLblprograma_enerofilter_Internalname = "LBLPROGRAMA_ENEROFILTER";
         edtavCprograma_enero_Internalname = "vCPROGRAMA_ENERO";
         divPrograma_enerofiltercontainer_Internalname = "PROGRAMA_ENEROFILTERCONTAINER";
         lblLblprograma_febrerofilter_Internalname = "LBLPROGRAMA_FEBREROFILTER";
         edtavCprograma_febrero_Internalname = "vCPROGRAMA_FEBRERO";
         divPrograma_febrerofiltercontainer_Internalname = "PROGRAMA_FEBREROFILTERCONTAINER";
         lblLblprograma_marzofilter_Internalname = "LBLPROGRAMA_MARZOFILTER";
         edtavCprograma_marzo_Internalname = "vCPROGRAMA_MARZO";
         divPrograma_marzofiltercontainer_Internalname = "PROGRAMA_MARZOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtid_actividad_categoria_Internalname = "ID_ACTIVIDAD_CATEGORIA";
         edtactividades_categoriaid_tipo_categoria_Internalname = "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         edtactividades_categoriaestado_Internalname = "ACTIVIDADES_CATEGORIAESTADO";
         edtprograma_enero_Internalname = "PROGRAMA_ENERO";
         edtprograma_febrero_Internalname = "PROGRAMA_FEBRERO";
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
         edtprograma_febrero_Jsonclick = "";
         edtprograma_enero_Jsonclick = "";
         edtactividades_categoriaestado_Jsonclick = "";
         edtactividades_categoriaid_tipo_categoria_Jsonclick = "";
         edtid_actividad_categoria_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtactividades_categoriaid_tipo_categoria_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCprograma_marzo_Jsonclick = "";
         edtavCprograma_marzo_Enabled = 1;
         edtavCprograma_marzo_Visible = 1;
         edtavCprograma_febrero_Jsonclick = "";
         edtavCprograma_febrero_Enabled = 1;
         edtavCprograma_febrero_Visible = 1;
         edtavCprograma_enero_Jsonclick = "";
         edtavCprograma_enero_Enabled = 1;
         edtavCprograma_enero_Visible = 1;
         edtavCactividades_categoriaestado_Jsonclick = "";
         edtavCactividades_categoriaestado_Enabled = 1;
         edtavCactividades_categoriaestado_Visible = 1;
         edtavCunidad_medida_Jsonclick = "";
         edtavCunidad_medida_Enabled = 1;
         edtavCunidad_medida_Visible = 1;
         edtavCactividades_categoriaid_tipo_categoria_Jsonclick = "";
         edtavCactividades_categoriaid_tipo_categoria_Enabled = 1;
         edtavCactividades_categoriaid_tipo_categoria_Visible = 1;
         edtavCid_actividad_categoria_Jsonclick = "";
         edtavCid_actividad_categoria_Enabled = 1;
         edtavCid_actividad_categoria_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List actividades_categoria";
         divPrograma_marzofiltercontainer_Class = "AdvancedContainerItem";
         divPrograma_febrerofiltercontainer_Class = "AdvancedContainerItem";
         divPrograma_enerofiltercontainer_Class = "AdvancedContainerItem";
         divActividades_categoriaestadofiltercontainer_Class = "AdvancedContainerItem";
         divUnidad_medidafiltercontainer_Class = "AdvancedContainerItem";
         divActividades_categoriaid_tipo_categoriafiltercontainer_Class = "AdvancedContainerItem";
         divId_actividad_categoriafiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_actividad_categoria',fld:'vCID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cactividades_categoriaid_tipo_categoria',fld:'vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV8cunidad_medida',fld:'vCUNIDAD_MEDIDA',pic:''},{av:'AV9cactividades_categoriaestado',fld:'vCACTIVIDADES_CATEGORIAESTADO',pic:'ZZZZZZZZ9'},{av:'AV10cprograma_enero',fld:'vCPROGRAMA_ENERO',pic:'ZZZZZZZZ9'},{av:'AV11cprograma_febrero',fld:'vCPROGRAMA_FEBRERO',pic:'ZZZZZZZZ9'},{av:'AV12cprograma_marzo',fld:'vCPROGRAMA_MARZO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E185I1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLID_ACTIVIDAD_CATEGORIAFILTER.CLICK","{handler:'E115I1',iparms:[{av:'divId_actividad_categoriafiltercontainer_Class',ctrl:'ID_ACTIVIDAD_CATEGORIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLID_ACTIVIDAD_CATEGORIAFILTER.CLICK",",oparms:[{av:'divId_actividad_categoriafiltercontainer_Class',ctrl:'ID_ACTIVIDAD_CATEGORIAFILTERCONTAINER',prop:'Class'},{av:'edtavCid_actividad_categoria_Visible',ctrl:'vCID_ACTIVIDAD_CATEGORIA',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTER.CLICK","{handler:'E125I1',iparms:[{av:'divActividades_categoriaid_tipo_categoriafiltercontainer_Class',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTER.CLICK",",oparms:[{av:'divActividades_categoriaid_tipo_categoriafiltercontainer_Class',ctrl:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIAFILTERCONTAINER',prop:'Class'},{av:'edtavCactividades_categoriaid_tipo_categoria_Visible',ctrl:'vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',prop:'Visible'}]}");
         setEventMetadata("LBLUNIDAD_MEDIDAFILTER.CLICK","{handler:'E135I1',iparms:[{av:'divUnidad_medidafiltercontainer_Class',ctrl:'UNIDAD_MEDIDAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUNIDAD_MEDIDAFILTER.CLICK",",oparms:[{av:'divUnidad_medidafiltercontainer_Class',ctrl:'UNIDAD_MEDIDAFILTERCONTAINER',prop:'Class'},{av:'edtavCunidad_medida_Visible',ctrl:'vCUNIDAD_MEDIDA',prop:'Visible'}]}");
         setEventMetadata("LBLACTIVIDADES_CATEGORIAESTADOFILTER.CLICK","{handler:'E145I1',iparms:[{av:'divActividades_categoriaestadofiltercontainer_Class',ctrl:'ACTIVIDADES_CATEGORIAESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLACTIVIDADES_CATEGORIAESTADOFILTER.CLICK",",oparms:[{av:'divActividades_categoriaestadofiltercontainer_Class',ctrl:'ACTIVIDADES_CATEGORIAESTADOFILTERCONTAINER',prop:'Class'},{av:'edtavCactividades_categoriaestado_Visible',ctrl:'vCACTIVIDADES_CATEGORIAESTADO',prop:'Visible'}]}");
         setEventMetadata("LBLPROGRAMA_ENEROFILTER.CLICK","{handler:'E155I1',iparms:[{av:'divPrograma_enerofiltercontainer_Class',ctrl:'PROGRAMA_ENEROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROGRAMA_ENEROFILTER.CLICK",",oparms:[{av:'divPrograma_enerofiltercontainer_Class',ctrl:'PROGRAMA_ENEROFILTERCONTAINER',prop:'Class'},{av:'edtavCprograma_enero_Visible',ctrl:'vCPROGRAMA_ENERO',prop:'Visible'}]}");
         setEventMetadata("LBLPROGRAMA_FEBREROFILTER.CLICK","{handler:'E165I1',iparms:[{av:'divPrograma_febrerofiltercontainer_Class',ctrl:'PROGRAMA_FEBREROFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROGRAMA_FEBREROFILTER.CLICK",",oparms:[{av:'divPrograma_febrerofiltercontainer_Class',ctrl:'PROGRAMA_FEBREROFILTERCONTAINER',prop:'Class'},{av:'edtavCprograma_febrero_Visible',ctrl:'vCPROGRAMA_FEBRERO',prop:'Visible'}]}");
         setEventMetadata("LBLPROGRAMA_MARZOFILTER.CLICK","{handler:'E175I1',iparms:[{av:'divPrograma_marzofiltercontainer_Class',ctrl:'PROGRAMA_MARZOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPROGRAMA_MARZOFILTER.CLICK",",oparms:[{av:'divPrograma_marzofiltercontainer_Class',ctrl:'PROGRAMA_MARZOFILTERCONTAINER',prop:'Class'},{av:'edtavCprograma_marzo_Visible',ctrl:'vCPROGRAMA_MARZO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E215I2',iparms:[{av:'A102id_actividad_categoria',fld:'ID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pid_actividad_categoria',fld:'vPID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_actividad_categoria',fld:'vCID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cactividades_categoriaid_tipo_categoria',fld:'vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV8cunidad_medida',fld:'vCUNIDAD_MEDIDA',pic:''},{av:'AV9cactividades_categoriaestado',fld:'vCACTIVIDADES_CATEGORIAESTADO',pic:'ZZZZZZZZ9'},{av:'AV10cprograma_enero',fld:'vCPROGRAMA_ENERO',pic:'ZZZZZZZZ9'},{av:'AV11cprograma_febrero',fld:'vCPROGRAMA_FEBRERO',pic:'ZZZZZZZZ9'},{av:'AV12cprograma_marzo',fld:'vCPROGRAMA_MARZO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_actividad_categoria',fld:'vCID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cactividades_categoriaid_tipo_categoria',fld:'vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV8cunidad_medida',fld:'vCUNIDAD_MEDIDA',pic:''},{av:'AV9cactividades_categoriaestado',fld:'vCACTIVIDADES_CATEGORIAESTADO',pic:'ZZZZZZZZ9'},{av:'AV10cprograma_enero',fld:'vCPROGRAMA_ENERO',pic:'ZZZZZZZZ9'},{av:'AV11cprograma_febrero',fld:'vCPROGRAMA_FEBRERO',pic:'ZZZZZZZZ9'},{av:'AV12cprograma_marzo',fld:'vCPROGRAMA_MARZO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_actividad_categoria',fld:'vCID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cactividades_categoriaid_tipo_categoria',fld:'vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV8cunidad_medida',fld:'vCUNIDAD_MEDIDA',pic:''},{av:'AV9cactividades_categoriaestado',fld:'vCACTIVIDADES_CATEGORIAESTADO',pic:'ZZZZZZZZ9'},{av:'AV10cprograma_enero',fld:'vCPROGRAMA_ENERO',pic:'ZZZZZZZZ9'},{av:'AV11cprograma_febrero',fld:'vCPROGRAMA_FEBRERO',pic:'ZZZZZZZZ9'},{av:'AV12cprograma_marzo',fld:'vCPROGRAMA_MARZO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cid_actividad_categoria',fld:'vCID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cactividades_categoriaid_tipo_categoria',fld:'vCACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV8cunidad_medida',fld:'vCUNIDAD_MEDIDA',pic:''},{av:'AV9cactividades_categoriaestado',fld:'vCACTIVIDADES_CATEGORIAESTADO',pic:'ZZZZZZZZ9'},{av:'AV10cprograma_enero',fld:'vCPROGRAMA_ENERO',pic:'ZZZZZZZZ9'},{av:'AV11cprograma_febrero',fld:'vCPROGRAMA_FEBRERO',pic:'ZZZZZZZZ9'},{av:'AV12cprograma_marzo',fld:'vCPROGRAMA_MARZO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Programa_febrero',iparms:[]");
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
         AV8cunidad_medida = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblid_actividad_categoriafilter_Jsonclick = "";
         TempTags = "";
         lblLblactividades_categoriaid_tipo_categoriafilter_Jsonclick = "";
         lblLblunidad_medidafilter_Jsonclick = "";
         lblLblactividades_categoriaestadofilter_Jsonclick = "";
         lblLblprograma_enerofilter_Jsonclick = "";
         lblLblprograma_febrerofilter_Jsonclick = "";
         lblLblprograma_marzofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV8cunidad_medida = "";
         A124unidad_medida = "";
         H005I2_A128programa_marzo = new int[1] ;
         H005I2_n128programa_marzo = new bool[] {false} ;
         H005I2_A124unidad_medida = new string[] {""} ;
         H005I2_n124unidad_medida = new bool[] {false} ;
         H005I2_A127programa_febrero = new int[1] ;
         H005I2_n127programa_febrero = new bool[] {false} ;
         H005I2_A126programa_enero = new int[1] ;
         H005I2_n126programa_enero = new bool[] {false} ;
         H005I2_A125actividades_categoriaestado = new int[1] ;
         H005I2_n125actividades_categoriaestado = new bool[] {false} ;
         H005I2_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         H005I2_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         H005I2_A102id_actividad_categoria = new int[1] ;
         H005I3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.gx00d0__datastore1(),
            new Object[][] {
                new Object[] {
               H005I2_A128programa_marzo, H005I2_n128programa_marzo, H005I2_A124unidad_medida, H005I2_n124unidad_medida, H005I2_A127programa_febrero, H005I2_n127programa_febrero, H005I2_A126programa_enero, H005I2_n126programa_enero, H005I2_A125actividades_categoriaestado, H005I2_n125actividades_categoriaestado,
               H005I2_A122actividades_categoriaid_tipo_categoria, H005I2_n122actividades_categoriaid_tipo_categoria, H005I2_A102id_actividad_categoria
               }
               , new Object[] {
               H005I3_AGRID1_nRecordCount
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
      private int AV13pid_actividad_categoria ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV6cid_actividad_categoria ;
      private int AV7cactividades_categoriaid_tipo_categoria ;
      private int AV9cactividades_categoriaestado ;
      private int AV10cprograma_enero ;
      private int AV11cprograma_febrero ;
      private int AV12cprograma_marzo ;
      private int edtavCid_actividad_categoria_Enabled ;
      private int edtavCid_actividad_categoria_Visible ;
      private int edtavCactividades_categoriaid_tipo_categoria_Enabled ;
      private int edtavCactividades_categoriaid_tipo_categoria_Visible ;
      private int edtavCunidad_medida_Visible ;
      private int edtavCunidad_medida_Enabled ;
      private int edtavCactividades_categoriaestado_Enabled ;
      private int edtavCactividades_categoriaestado_Visible ;
      private int edtavCprograma_enero_Enabled ;
      private int edtavCprograma_enero_Visible ;
      private int edtavCprograma_febrero_Enabled ;
      private int edtavCprograma_febrero_Visible ;
      private int edtavCprograma_marzo_Enabled ;
      private int edtavCprograma_marzo_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A102id_actividad_categoria ;
      private int A122actividades_categoriaid_tipo_categoria ;
      private int A125actividades_categoriaestado ;
      private int A126programa_enero ;
      private int A127programa_febrero ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A128programa_marzo ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divId_actividad_categoriafiltercontainer_Class ;
      private string divActividades_categoriaid_tipo_categoriafiltercontainer_Class ;
      private string divUnidad_medidafiltercontainer_Class ;
      private string divActividades_categoriaestadofiltercontainer_Class ;
      private string divPrograma_enerofiltercontainer_Class ;
      private string divPrograma_febrerofiltercontainer_Class ;
      private string divPrograma_marzofiltercontainer_Class ;
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
      private string divId_actividad_categoriafiltercontainer_Internalname ;
      private string lblLblid_actividad_categoriafilter_Internalname ;
      private string lblLblid_actividad_categoriafilter_Jsonclick ;
      private string edtavCid_actividad_categoria_Internalname ;
      private string TempTags ;
      private string edtavCid_actividad_categoria_Jsonclick ;
      private string divActividades_categoriaid_tipo_categoriafiltercontainer_Internalname ;
      private string lblLblactividades_categoriaid_tipo_categoriafilter_Internalname ;
      private string lblLblactividades_categoriaid_tipo_categoriafilter_Jsonclick ;
      private string edtavCactividades_categoriaid_tipo_categoria_Internalname ;
      private string edtavCactividades_categoriaid_tipo_categoria_Jsonclick ;
      private string divUnidad_medidafiltercontainer_Internalname ;
      private string lblLblunidad_medidafilter_Internalname ;
      private string lblLblunidad_medidafilter_Jsonclick ;
      private string edtavCunidad_medida_Internalname ;
      private string edtavCunidad_medida_Jsonclick ;
      private string divActividades_categoriaestadofiltercontainer_Internalname ;
      private string lblLblactividades_categoriaestadofilter_Internalname ;
      private string lblLblactividades_categoriaestadofilter_Jsonclick ;
      private string edtavCactividades_categoriaestado_Internalname ;
      private string edtavCactividades_categoriaestado_Jsonclick ;
      private string divPrograma_enerofiltercontainer_Internalname ;
      private string lblLblprograma_enerofilter_Internalname ;
      private string lblLblprograma_enerofilter_Jsonclick ;
      private string edtavCprograma_enero_Internalname ;
      private string edtavCprograma_enero_Jsonclick ;
      private string divPrograma_febrerofiltercontainer_Internalname ;
      private string lblLblprograma_febrerofilter_Internalname ;
      private string lblLblprograma_febrerofilter_Jsonclick ;
      private string edtavCprograma_febrero_Internalname ;
      private string edtavCprograma_febrero_Jsonclick ;
      private string divPrograma_marzofiltercontainer_Internalname ;
      private string lblLblprograma_marzofilter_Internalname ;
      private string lblLblprograma_marzofilter_Jsonclick ;
      private string edtavCprograma_marzo_Internalname ;
      private string edtavCprograma_marzo_Jsonclick ;
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
      private string edtactividades_categoriaid_tipo_categoria_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtid_actividad_categoria_Internalname ;
      private string edtactividades_categoriaid_tipo_categoria_Internalname ;
      private string edtactividades_categoriaestado_Internalname ;
      private string edtprograma_enero_Internalname ;
      private string edtprograma_febrero_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtid_actividad_categoria_Jsonclick ;
      private string edtactividades_categoriaid_tipo_categoria_Jsonclick ;
      private string edtactividades_categoriaestado_Jsonclick ;
      private string edtprograma_enero_Jsonclick ;
      private string edtprograma_febrero_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n122actividades_categoriaid_tipo_categoria ;
      private bool n125actividades_categoriaestado ;
      private bool n126programa_enero ;
      private bool n127programa_febrero ;
      private bool gxdyncontrolsrefreshing ;
      private bool n128programa_marzo ;
      private bool n124unidad_medida ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV8cunidad_medida ;
      private string AV17Linkselection_GXI ;
      private string lV8cunidad_medida ;
      private string A124unidad_medida ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H005I2_A128programa_marzo ;
      private bool[] H005I2_n128programa_marzo ;
      private string[] H005I2_A124unidad_medida ;
      private bool[] H005I2_n124unidad_medida ;
      private int[] H005I2_A127programa_febrero ;
      private bool[] H005I2_n127programa_febrero ;
      private int[] H005I2_A126programa_enero ;
      private bool[] H005I2_n126programa_enero ;
      private int[] H005I2_A125actividades_categoriaestado ;
      private bool[] H005I2_n125actividades_categoriaestado ;
      private int[] H005I2_A122actividades_categoriaid_tipo_categoria ;
      private bool[] H005I2_n122actividades_categoriaid_tipo_categoria ;
      private int[] H005I2_A102id_actividad_categoria ;
      private long[] H005I3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pid_actividad_categoria ;
      private GXWebForm Form ;
   }

   public class gx00d0__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005I2( IGxContext context ,
                                             int AV7cactividades_categoriaid_tipo_categoria ,
                                             string AV8cunidad_medida ,
                                             int AV9cactividades_categoriaestado ,
                                             int AV10cprograma_enero ,
                                             int AV11cprograma_febrero ,
                                             int AV12cprograma_marzo ,
                                             int A122actividades_categoriaid_tipo_categoria ,
                                             string A124unidad_medida ,
                                             int A125actividades_categoriaestado ,
                                             int A126programa_enero ,
                                             int A127programa_febrero ,
                                             int A128programa_marzo ,
                                             int AV6cid_actividad_categoria )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [programa_marzo], [unidad_medida], [programa_febrero], [programa_enero], [estado], [id_tipo_categoria], [id_actividad_categoria]";
         sFromString = " FROM dbo.[actividades_categoria]";
         sOrderString = "";
         AddWhere(sWhereString, "([id_actividad_categoria] >= @AV6cid_actividad_categoria)");
         if ( ! (0==AV7cactividades_categoriaid_tipo_categoria) )
         {
            AddWhere(sWhereString, "([id_tipo_categoria] >= @AV7cactividades_categoriaid_tipo_categoria)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cunidad_medida)) )
         {
            AddWhere(sWhereString, "([unidad_medida] like @lV8cunidad_medida)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV9cactividades_categoriaestado) )
         {
            AddWhere(sWhereString, "([estado] >= @AV9cactividades_categoriaestado)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cprograma_enero) )
         {
            AddWhere(sWhereString, "([programa_enero] >= @AV10cprograma_enero)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cprograma_febrero) )
         {
            AddWhere(sWhereString, "([programa_febrero] >= @AV11cprograma_febrero)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cprograma_marzo) )
         {
            AddWhere(sWhereString, "([programa_marzo] >= @AV12cprograma_marzo)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [id_actividad_categoria]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005I3( IGxContext context ,
                                             int AV7cactividades_categoriaid_tipo_categoria ,
                                             string AV8cunidad_medida ,
                                             int AV9cactividades_categoriaestado ,
                                             int AV10cprograma_enero ,
                                             int AV11cprograma_febrero ,
                                             int AV12cprograma_marzo ,
                                             int A122actividades_categoriaid_tipo_categoria ,
                                             string A124unidad_medida ,
                                             int A125actividades_categoriaestado ,
                                             int A126programa_enero ,
                                             int A127programa_febrero ,
                                             int A128programa_marzo ,
                                             int AV6cid_actividad_categoria )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[actividades_categoria]";
         AddWhere(sWhereString, "([id_actividad_categoria] >= @AV6cid_actividad_categoria)");
         if ( ! (0==AV7cactividades_categoriaid_tipo_categoria) )
         {
            AddWhere(sWhereString, "([id_tipo_categoria] >= @AV7cactividades_categoriaid_tipo_categoria)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cunidad_medida)) )
         {
            AddWhere(sWhereString, "([unidad_medida] like @lV8cunidad_medida)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV9cactividades_categoriaestado) )
         {
            AddWhere(sWhereString, "([estado] >= @AV9cactividades_categoriaestado)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cprograma_enero) )
         {
            AddWhere(sWhereString, "([programa_enero] >= @AV10cprograma_enero)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cprograma_febrero) )
         {
            AddWhere(sWhereString, "([programa_febrero] >= @AV11cprograma_febrero)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cprograma_marzo) )
         {
            AddWhere(sWhereString, "([programa_marzo] >= @AV12cprograma_marzo)");
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
                     return conditional_H005I2(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H005I3(context, (int)dynConstraints[0] , (string)dynConstraints[1] , (int)dynConstraints[2] , (int)dynConstraints[3] , (int)dynConstraints[4] , (int)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH005I2;
          prmH005I2 = new Object[] {
          new ParDef("@AV6cid_actividad_categoria",GXType.Int32,9,0) ,
          new ParDef("@AV7cactividades_categoriaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@lV8cunidad_medida",GXType.NVarChar,80,0) ,
          new ParDef("@AV9cactividades_categoriaestado",GXType.Int32,9,0) ,
          new ParDef("@AV10cprograma_enero",GXType.Int32,9,0) ,
          new ParDef("@AV11cprograma_febrero",GXType.Int32,9,0) ,
          new ParDef("@AV12cprograma_marzo",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005I3;
          prmH005I3 = new Object[] {
          new ParDef("@AV6cid_actividad_categoria",GXType.Int32,9,0) ,
          new ParDef("@AV7cactividades_categoriaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@lV8cunidad_medida",GXType.NVarChar,80,0) ,
          new ParDef("@AV9cactividades_categoriaestado",GXType.Int32,9,0) ,
          new ParDef("@AV10cprograma_enero",GXType.Int32,9,0) ,
          new ParDef("@AV11cprograma_febrero",GXType.Int32,9,0) ,
          new ParDef("@AV12cprograma_marzo",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005I2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005I3,1, GxCacheFrequency.OFF ,false,false )
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
                ((int[]) buf[6])[0] = rslt.getInt(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
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
