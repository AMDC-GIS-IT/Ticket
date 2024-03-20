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
   public class gx00e0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00e0( )
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

      public gx00e0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out int aP0_pcategoria_tareaid_tipo_categoria )
      {
         this.AV13pcategoria_tareaid_tipo_categoria = 0 ;
         executePrivate();
         aP0_pcategoria_tareaid_tipo_categoria=this.AV13pcategoria_tareaid_tipo_categoria;
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
            gxfirstwebparm = GetFirstPar( "pcategoria_tareaid_tipo_categoria");
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
               gxfirstwebparm = GetFirstPar( "pcategoria_tareaid_tipo_categoria");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pcategoria_tareaid_tipo_categoria");
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
               AV6ccategoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "ccategoria_tareaid_tipo_categoria"), "."));
               AV7cid_unidad_gis = (int)(NumberUtil.Val( GetPar( "cid_unidad_gis"), "."));
               AV8ccategoria_tareaestado = (int)(NumberUtil.Val( GetPar( "ccategoria_tareaestado"), "."));
               AV9ccategoria_tareafecha_creacion = context.localUtil.ParseDateParm( GetPar( "ccategoria_tareafecha_creacion"));
               AV10ccategoria_tareahora_creacion = (int)(NumberUtil.Val( GetPar( "ccategoria_tareahora_creacion"), "."));
               AV11ccategoria_tareacreado_por = GetPar( "ccategoria_tareacreado_por");
               AV12ccategoria_tareafecha_modificacion = context.localUtil.ParseDateParm( GetPar( "ccategoria_tareafecha_modificacion"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, AV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion) ;
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
               AV13pcategoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pcategoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV13pcategoria_tareaid_tipo_categoria), 9, 0));
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
            return "gx00e0_Execute" ;
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
         PA5G2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5G2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188434754", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00e0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pcategoria_tareaid_tipo_categoria,9,0))}, new string[] {"pcategoria_tareaid_tipo_categoria"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIA_TAREAID_TIPO_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ccategoria_tareaid_tipo_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCID_UNIDAD_GIS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cid_unidad_gis), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIA_TAREAESTADO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ccategoria_tareaestado), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIA_TAREAFECHA_CREACION", context.localUtil.Format(AV9ccategoria_tareafecha_creacion, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIA_TAREAHORA_CREACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ccategoria_tareahora_creacion), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIA_TAREACREADO_POR", AV11ccategoria_tareacreado_por);
         GxWebStd.gx_hidden_field( context, "GXH_vCCATEGORIA_TAREAFECHA_MODIFICACION", context.localUtil.Format(AV12ccategoria_tareafecha_modificacion, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCATEGORIA_TAREAID_TIPO_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pcategoria_tareaid_tipo_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREAID_TIPO_CATEGORIAFILTERCONTAINER_Class", StringUtil.RTrim( divCategoria_tareaid_tipo_categoriafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ID_UNIDAD_GISFILTERCONTAINER_Class", StringUtil.RTrim( divId_unidad_gisfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREAESTADOFILTERCONTAINER_Class", StringUtil.RTrim( divCategoria_tareaestadofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREAFECHA_CREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divCategoria_tareafecha_creacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREAHORA_CREACIONFILTERCONTAINER_Class", StringUtil.RTrim( divCategoria_tareahora_creacionfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREACREADO_PORFILTERCONTAINER_Class", StringUtil.RTrim( divCategoria_tareacreado_porfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREAFECHA_MODIFICACIONFILTERCONTAINER_Class", StringUtil.RTrim( divCategoria_tareafecha_modificacionfiltercontainer_Class));
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
            WE5G2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5G2( ) ;
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
         return formatLink("gx00e0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pcategoria_tareaid_tipo_categoria,9,0))}, new string[] {"pcategoria_tareaid_tipo_categoria"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00E0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List categoria_tarea" ;
      }

      protected void WB5G0( )
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
            GxWebStd.gx_div_start( context, divCategoria_tareaid_tipo_categoriafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoria_tareaid_tipo_categoriafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoria_tareaid_tipo_categoriafilter_Internalname, "categoria_tareaid_tipo_categoria", "", "", lblLblcategoria_tareaid_tipo_categoriafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e115g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoria_tareaid_tipo_categoria_Internalname, "id_tipo_categoria", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcategoria_tareaid_tipo_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ccategoria_tareaid_tipo_categoria), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCcategoria_tareaid_tipo_categoria_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6ccategoria_tareaid_tipo_categoria), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6ccategoria_tareaid_tipo_categoria), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoria_tareaid_tipo_categoria_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcategoria_tareaid_tipo_categoria_Visible, edtavCcategoria_tareaid_tipo_categoria_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00E0.htm");
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
            GxWebStd.gx_div_start( context, divId_unidad_gisfiltercontainer_Internalname, 1, 0, "px", 0, "px", divId_unidad_gisfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblid_unidad_gisfilter_Internalname, "id_unidad_gis", "", "", lblLblid_unidad_gisfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e125g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCid_unidad_gis_Internalname, "id_unidad_gis", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCid_unidad_gis_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7cid_unidad_gis), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCid_unidad_gis_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7cid_unidad_gis), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7cid_unidad_gis), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCid_unidad_gis_Jsonclick, 0, "Attribute", "", "", "", "", edtavCid_unidad_gis_Visible, edtavCid_unidad_gis_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00E0.htm");
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
            GxWebStd.gx_div_start( context, divCategoria_tareaestadofiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoria_tareaestadofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoria_tareaestadofilter_Internalname, "categoria_tareaestado", "", "", lblLblcategoria_tareaestadofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e135g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoria_tareaestado_Internalname, "estado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcategoria_tareaestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8ccategoria_tareaestado), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCcategoria_tareaestado_Enabled!=0) ? context.localUtil.Format( (decimal)(AV8ccategoria_tareaestado), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV8ccategoria_tareaestado), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoria_tareaestado_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcategoria_tareaestado_Visible, edtavCcategoria_tareaestado_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00E0.htm");
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
            GxWebStd.gx_div_start( context, divCategoria_tareafecha_creacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoria_tareafecha_creacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoria_tareafecha_creacionfilter_Internalname, "categoria_tareafecha_creacion", "", "", lblLblcategoria_tareafecha_creacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e145g1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoria_tareafecha_creacion_Internalname, "fecha_creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcategoria_tareafecha_creacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcategoria_tareafecha_creacion_Internalname, context.localUtil.Format(AV9ccategoria_tareafecha_creacion, "99/99/99"), context.localUtil.Format( AV9ccategoria_tareafecha_creacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoria_tareafecha_creacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcategoria_tareafecha_creacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00E0.htm");
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
            GxWebStd.gx_div_start( context, divCategoria_tareahora_creacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoria_tareahora_creacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoria_tareahora_creacionfilter_Internalname, "categoria_tareahora_creacion", "", "", lblLblcategoria_tareahora_creacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e155g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoria_tareahora_creacion_Internalname, "hora_creacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcategoria_tareahora_creacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ccategoria_tareahora_creacion), 5, 0, ".", "")), StringUtil.LTrim( ((edtavCcategoria_tareahora_creacion_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10ccategoria_tareahora_creacion), "ZZZZ9") : context.localUtil.Format( (decimal)(AV10ccategoria_tareahora_creacion), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoria_tareahora_creacion_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcategoria_tareahora_creacion_Visible, edtavCcategoria_tareahora_creacion_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00E0.htm");
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
            GxWebStd.gx_div_start( context, divCategoria_tareacreado_porfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoria_tareacreado_porfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoria_tareacreado_porfilter_Internalname, "categoria_tareacreado_por", "", "", lblLblcategoria_tareacreado_porfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e165g1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoria_tareacreado_por_Internalname, "creado_por", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcategoria_tareacreado_por_Internalname, AV11ccategoria_tareacreado_por, StringUtil.RTrim( context.localUtil.Format( AV11ccategoria_tareacreado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoria_tareacreado_por_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcategoria_tareacreado_por_Visible, edtavCcategoria_tareacreado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00E0.htm");
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
            GxWebStd.gx_div_start( context, divCategoria_tareafecha_modificacionfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCategoria_tareafecha_modificacionfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcategoria_tareafecha_modificacionfilter_Internalname, "categoria_tareafecha_modificacion", "", "", lblLblcategoria_tareafecha_modificacionfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e175g1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00E0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcategoria_tareafecha_modificacion_Internalname, "fecha_modificacion", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCcategoria_tareafecha_modificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCcategoria_tareafecha_modificacion_Internalname, context.localUtil.Format(AV12ccategoria_tareafecha_modificacion, "99/99/99"), context.localUtil.Format( AV12ccategoria_tareafecha_modificacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcategoria_tareafecha_modificacion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCcategoria_tareafecha_modificacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00E0.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e185g1_client"+"'", TempTags, "", 2, "HLP_Gx00E0.htm");
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
               context.SendWebValue( "id_tipo_categoria") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "id_unidad_gis") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A105id_unidad_gis), 9, 0, ".", "")));
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtid_unidad_gis_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107categoria_tareaestado), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A109categoria_tareahora_creacion), 5, 0, ".", "")));
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
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00E0.htm");
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

      protected void START5G2( )
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
            Form.Meta.addItem("description", "Selection List categoria_tarea", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5G0( ) ;
      }

      protected void WS5G2( )
      {
         START5G2( ) ;
         EVT5G2( ) ;
      }

      protected void EVT5G2( )
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
                              A104categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareaid_tipo_categoria_Internalname), ".", ","));
                              A105id_unidad_gis = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_gis_Internalname), ".", ","));
                              A107categoria_tareaestado = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareaestado_Internalname), ".", ","));
                              n107categoria_tareaestado = false;
                              A108categoria_tareafecha_creacion = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtcategoria_tareafecha_creacion_Internalname), 0));
                              n108categoria_tareafecha_creacion = false;
                              A109categoria_tareahora_creacion = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareahora_creacion_Internalname), ".", ","));
                              n109categoria_tareahora_creacion = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E195G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E205G2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Ccategoria_tareaid_tipo_categoria Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIA_TAREAID_TIPO_CATEGORIA"), ".", ",") != Convert.ToDecimal( AV6ccategoria_tareaid_tipo_categoria )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cid_unidad_gis Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_UNIDAD_GIS"), ".", ",") != Convert.ToDecimal( AV7cid_unidad_gis )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoria_tareaestado Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIA_TAREAESTADO"), ".", ",") != Convert.ToDecimal( AV8ccategoria_tareaestado )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoria_tareafecha_creacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCATEGORIA_TAREAFECHA_CREACION"), 0) != AV9ccategoria_tareafecha_creacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoria_tareahora_creacion Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIA_TAREAHORA_CREACION"), ".", ",") != Convert.ToDecimal( AV10ccategoria_tareahora_creacion )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoria_tareacreado_por Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCATEGORIA_TAREACREADO_POR"), AV11ccategoria_tareacreado_por) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccategoria_tareafecha_modificacion Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCCATEGORIA_TAREAFECHA_MODIFICACION"), 0) != AV12ccategoria_tareafecha_modificacion )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E215G2 ();
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

      protected void WE5G2( )
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

      protected void PA5G2( )
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
                                        int AV6ccategoria_tareaid_tipo_categoria ,
                                        int AV7cid_unidad_gis ,
                                        int AV8ccategoria_tareaestado ,
                                        DateTime AV9ccategoria_tareafecha_creacion ,
                                        int AV10ccategoria_tareahora_creacion ,
                                        string AV11ccategoria_tareacreado_por ,
                                        DateTime AV12ccategoria_tareafecha_modificacion )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF5G2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIA_TAREAID_TIPO_CATEGORIA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A104categoria_tareaid_tipo_categoria), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CATEGORIA_TAREAID_TIPO_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ".", "")));
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
         RF5G2( ) ;
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

      protected void RF5G2( )
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
                                                 AV7cid_unidad_gis ,
                                                 AV8ccategoria_tareaestado ,
                                                 AV9ccategoria_tareafecha_creacion ,
                                                 AV10ccategoria_tareahora_creacion ,
                                                 AV11ccategoria_tareacreado_por ,
                                                 AV12ccategoria_tareafecha_modificacion ,
                                                 A105id_unidad_gis ,
                                                 A107categoria_tareaestado ,
                                                 A108categoria_tareafecha_creacion ,
                                                 A109categoria_tareahora_creacion ,
                                                 A110categoria_tareacreado_por ,
                                                 A111categoria_tareafecha_modificacion ,
                                                 AV6ccategoria_tareaid_tipo_categoria } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                                 TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT
                                                 }
            });
            lV11ccategoria_tareacreado_por = StringUtil.Concat( StringUtil.RTrim( AV11ccategoria_tareacreado_por), "%", "");
            /* Using cursor H005G2 */
            pr_datastore1.execute(0, new Object[] {AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, lV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion, GXPagingFrom2, GXPagingTo2, GXPagingFrom2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_datastore1.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A111categoria_tareafecha_modificacion = H005G2_A111categoria_tareafecha_modificacion[0];
               n111categoria_tareafecha_modificacion = H005G2_n111categoria_tareafecha_modificacion[0];
               A110categoria_tareacreado_por = H005G2_A110categoria_tareacreado_por[0];
               n110categoria_tareacreado_por = H005G2_n110categoria_tareacreado_por[0];
               A109categoria_tareahora_creacion = H005G2_A109categoria_tareahora_creacion[0];
               n109categoria_tareahora_creacion = H005G2_n109categoria_tareahora_creacion[0];
               A108categoria_tareafecha_creacion = H005G2_A108categoria_tareafecha_creacion[0];
               n108categoria_tareafecha_creacion = H005G2_n108categoria_tareafecha_creacion[0];
               A107categoria_tareaestado = H005G2_A107categoria_tareaestado[0];
               n107categoria_tareaestado = H005G2_n107categoria_tareaestado[0];
               A105id_unidad_gis = H005G2_A105id_unidad_gis[0];
               A104categoria_tareaid_tipo_categoria = H005G2_A104categoria_tareaid_tipo_categoria[0];
               /* Execute user event: Load */
               E205G2 ();
               pr_datastore1.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_datastore1.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_datastore1.close(0);
            wbEnd = 84;
            WB5G0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes5G2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CATEGORIA_TAREAID_TIPO_CATEGORIA"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A104categoria_tareaid_tipo_categoria), "ZZZZZZZZ9"), context));
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
                                              AV7cid_unidad_gis ,
                                              AV8ccategoria_tareaestado ,
                                              AV9ccategoria_tareafecha_creacion ,
                                              AV10ccategoria_tareahora_creacion ,
                                              AV11ccategoria_tareacreado_por ,
                                              AV12ccategoria_tareafecha_modificacion ,
                                              A105id_unidad_gis ,
                                              A107categoria_tareaestado ,
                                              A108categoria_tareafecha_creacion ,
                                              A109categoria_tareahora_creacion ,
                                              A110categoria_tareacreado_por ,
                                              A111categoria_tareafecha_modificacion ,
                                              AV6ccategoria_tareaid_tipo_categoria } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.INT
                                              }
         });
         lV11ccategoria_tareacreado_por = StringUtil.Concat( StringUtil.RTrim( AV11ccategoria_tareacreado_por), "%", "");
         /* Using cursor H005G3 */
         pr_datastore1.execute(1, new Object[] {AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, lV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion});
         GRID1_nRecordCount = H005G3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, AV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, AV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, AV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, AV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6ccategoria_tareaid_tipo_categoria, AV7cid_unidad_gis, AV8ccategoria_tareaestado, AV9ccategoria_tareafecha_creacion, AV10ccategoria_tareahora_creacion, AV11ccategoria_tareacreado_por, AV12ccategoria_tareafecha_modificacion) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E195G2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcategoria_tareaid_tipo_categoria_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcategoria_tareaid_tipo_categoria_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCATEGORIA_TAREAID_TIPO_CATEGORIA");
               GX_FocusControl = edtavCcategoria_tareaid_tipo_categoria_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6ccategoria_tareaid_tipo_categoria = 0;
               AssignAttri("", false, "AV6ccategoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV6ccategoria_tareaid_tipo_categoria), 9, 0));
            }
            else
            {
               AV6ccategoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtavCcategoria_tareaid_tipo_categoria_Internalname), ".", ","));
               AssignAttri("", false, "AV6ccategoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV6ccategoria_tareaid_tipo_categoria), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCid_unidad_gis_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCid_unidad_gis_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCID_UNIDAD_GIS");
               GX_FocusControl = edtavCid_unidad_gis_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV7cid_unidad_gis = 0;
               AssignAttri("", false, "AV7cid_unidad_gis", StringUtil.LTrimStr( (decimal)(AV7cid_unidad_gis), 9, 0));
            }
            else
            {
               AV7cid_unidad_gis = (int)(context.localUtil.CToN( cgiGet( edtavCid_unidad_gis_Internalname), ".", ","));
               AssignAttri("", false, "AV7cid_unidad_gis", StringUtil.LTrimStr( (decimal)(AV7cid_unidad_gis), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcategoria_tareaestado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcategoria_tareaestado_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCATEGORIA_TAREAESTADO");
               GX_FocusControl = edtavCcategoria_tareaestado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8ccategoria_tareaestado = 0;
               AssignAttri("", false, "AV8ccategoria_tareaestado", StringUtil.LTrimStr( (decimal)(AV8ccategoria_tareaestado), 9, 0));
            }
            else
            {
               AV8ccategoria_tareaestado = (int)(context.localUtil.CToN( cgiGet( edtavCcategoria_tareaestado_Internalname), ".", ","));
               AssignAttri("", false, "AV8ccategoria_tareaestado", StringUtil.LTrimStr( (decimal)(AV8ccategoria_tareaestado), 9, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCcategoria_tareafecha_creacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_creacion"}), 1, "vCCATEGORIA_TAREAFECHA_CREACION");
               GX_FocusControl = edtavCcategoria_tareafecha_creacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9ccategoria_tareafecha_creacion = DateTime.MinValue;
               AssignAttri("", false, "AV9ccategoria_tareafecha_creacion", context.localUtil.Format(AV9ccategoria_tareafecha_creacion, "99/99/99"));
            }
            else
            {
               AV9ccategoria_tareafecha_creacion = context.localUtil.CToD( cgiGet( edtavCcategoria_tareafecha_creacion_Internalname), 2);
               AssignAttri("", false, "AV9ccategoria_tareafecha_creacion", context.localUtil.Format(AV9ccategoria_tareafecha_creacion, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcategoria_tareahora_creacion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcategoria_tareahora_creacion_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCATEGORIA_TAREAHORA_CREACION");
               GX_FocusControl = edtavCcategoria_tareahora_creacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10ccategoria_tareahora_creacion = 0;
               AssignAttri("", false, "AV10ccategoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(AV10ccategoria_tareahora_creacion), 5, 0));
            }
            else
            {
               AV10ccategoria_tareahora_creacion = (int)(context.localUtil.CToN( cgiGet( edtavCcategoria_tareahora_creacion_Internalname), ".", ","));
               AssignAttri("", false, "AV10ccategoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(AV10ccategoria_tareahora_creacion), 5, 0));
            }
            AV11ccategoria_tareacreado_por = cgiGet( edtavCcategoria_tareacreado_por_Internalname);
            AssignAttri("", false, "AV11ccategoria_tareacreado_por", AV11ccategoria_tareacreado_por);
            if ( context.localUtil.VCDate( cgiGet( edtavCcategoria_tareafecha_modificacion_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_modificacion"}), 1, "vCCATEGORIA_TAREAFECHA_MODIFICACION");
               GX_FocusControl = edtavCcategoria_tareafecha_modificacion_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12ccategoria_tareafecha_modificacion = DateTime.MinValue;
               AssignAttri("", false, "AV12ccategoria_tareafecha_modificacion", context.localUtil.Format(AV12ccategoria_tareafecha_modificacion, "99/99/99"));
            }
            else
            {
               AV12ccategoria_tareafecha_modificacion = context.localUtil.CToD( cgiGet( edtavCcategoria_tareafecha_modificacion_Internalname), 2);
               AssignAttri("", false, "AV12ccategoria_tareafecha_modificacion", context.localUtil.Format(AV12ccategoria_tareafecha_modificacion, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIA_TAREAID_TIPO_CATEGORIA"), ".", ",") != Convert.ToDecimal( AV6ccategoria_tareaid_tipo_categoria )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCID_UNIDAD_GIS"), ".", ",") != Convert.ToDecimal( AV7cid_unidad_gis )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIA_TAREAESTADO"), ".", ",") != Convert.ToDecimal( AV8ccategoria_tareaestado )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCATEGORIA_TAREAFECHA_CREACION"), 2) ) != DateTimeUtil.ResetTime ( AV9ccategoria_tareafecha_creacion ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCATEGORIA_TAREAHORA_CREACION"), ".", ",") != Convert.ToDecimal( AV10ccategoria_tareahora_creacion )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCATEGORIA_TAREACREADO_POR"), AV11ccategoria_tareacreado_por) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCCATEGORIA_TAREAFECHA_MODIFICACION"), 2) ) != DateTimeUtil.ResetTime ( AV12ccategoria_tareafecha_modificacion ) )
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
         E195G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E195G2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "categoria_tarea", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E205G2( )
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
         E215G2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E215G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pcategoria_tareaid_tipo_categoria = A104categoria_tareaid_tipo_categoria;
         AssignAttri("", false, "AV13pcategoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV13pcategoria_tareaid_tipo_categoria), 9, 0));
         context.setWebReturnParms(new Object[] {(int)AV13pcategoria_tareaid_tipo_categoria});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pcategoria_tareaid_tipo_categoria"});
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
         AV13pcategoria_tareaid_tipo_categoria = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV13pcategoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV13pcategoria_tareaid_tipo_categoria), 9, 0));
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
         PA5G2( ) ;
         WS5G2( ) ;
         WE5G2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188434854", true, true);
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
         context.AddJavascriptSource("gx00e0.js", "?2024188434855", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtcategoria_tareaid_tipo_categoria_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA_"+sGXsfl_84_idx;
         edtid_unidad_gis_Internalname = "ID_UNIDAD_GIS_"+sGXsfl_84_idx;
         edtcategoria_tareaestado_Internalname = "CATEGORIA_TAREAESTADO_"+sGXsfl_84_idx;
         edtcategoria_tareafecha_creacion_Internalname = "CATEGORIA_TAREAFECHA_CREACION_"+sGXsfl_84_idx;
         edtcategoria_tareahora_creacion_Internalname = "CATEGORIA_TAREAHORA_CREACION_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtcategoria_tareaid_tipo_categoria_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA_"+sGXsfl_84_fel_idx;
         edtid_unidad_gis_Internalname = "ID_UNIDAD_GIS_"+sGXsfl_84_fel_idx;
         edtcategoria_tareaestado_Internalname = "CATEGORIA_TAREAESTADO_"+sGXsfl_84_fel_idx;
         edtcategoria_tareafecha_creacion_Internalname = "CATEGORIA_TAREAFECHA_CREACION_"+sGXsfl_84_fel_idx;
         edtcategoria_tareahora_creacion_Internalname = "CATEGORIA_TAREAHORA_CREACION_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB5G0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ".", "")))+"'"+"]);";
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcategoria_tareaid_tipo_categoria_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A104categoria_tareaid_tipo_categoria), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcategoria_tareaid_tipo_categoria_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtid_unidad_gis_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtid_unidad_gis_Internalname, "Link", edtid_unidad_gis_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtid_unidad_gis_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A105id_unidad_gis), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A105id_unidad_gis), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtid_unidad_gis_Link,(string)"",(string)"",(string)"",(string)edtid_unidad_gis_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcategoria_tareaestado_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A107categoria_tareaestado), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A107categoria_tareaestado), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcategoria_tareaestado_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcategoria_tareafecha_creacion_Internalname,context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"),context.localUtil.Format( A108categoria_tareafecha_creacion, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcategoria_tareafecha_creacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtcategoria_tareahora_creacion_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A109categoria_tareahora_creacion), 5, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A109categoria_tareahora_creacion), "ZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtcategoria_tareahora_creacion_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes5G2( ) ;
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
         lblLblcategoria_tareaid_tipo_categoriafilter_Internalname = "LBLCATEGORIA_TAREAID_TIPO_CATEGORIAFILTER";
         edtavCcategoria_tareaid_tipo_categoria_Internalname = "vCCATEGORIA_TAREAID_TIPO_CATEGORIA";
         divCategoria_tareaid_tipo_categoriafiltercontainer_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIAFILTERCONTAINER";
         lblLblid_unidad_gisfilter_Internalname = "LBLID_UNIDAD_GISFILTER";
         edtavCid_unidad_gis_Internalname = "vCID_UNIDAD_GIS";
         divId_unidad_gisfiltercontainer_Internalname = "ID_UNIDAD_GISFILTERCONTAINER";
         lblLblcategoria_tareaestadofilter_Internalname = "LBLCATEGORIA_TAREAESTADOFILTER";
         edtavCcategoria_tareaestado_Internalname = "vCCATEGORIA_TAREAESTADO";
         divCategoria_tareaestadofiltercontainer_Internalname = "CATEGORIA_TAREAESTADOFILTERCONTAINER";
         lblLblcategoria_tareafecha_creacionfilter_Internalname = "LBLCATEGORIA_TAREAFECHA_CREACIONFILTER";
         edtavCcategoria_tareafecha_creacion_Internalname = "vCCATEGORIA_TAREAFECHA_CREACION";
         divCategoria_tareafecha_creacionfiltercontainer_Internalname = "CATEGORIA_TAREAFECHA_CREACIONFILTERCONTAINER";
         lblLblcategoria_tareahora_creacionfilter_Internalname = "LBLCATEGORIA_TAREAHORA_CREACIONFILTER";
         edtavCcategoria_tareahora_creacion_Internalname = "vCCATEGORIA_TAREAHORA_CREACION";
         divCategoria_tareahora_creacionfiltercontainer_Internalname = "CATEGORIA_TAREAHORA_CREACIONFILTERCONTAINER";
         lblLblcategoria_tareacreado_porfilter_Internalname = "LBLCATEGORIA_TAREACREADO_PORFILTER";
         edtavCcategoria_tareacreado_por_Internalname = "vCCATEGORIA_TAREACREADO_POR";
         divCategoria_tareacreado_porfiltercontainer_Internalname = "CATEGORIA_TAREACREADO_PORFILTERCONTAINER";
         lblLblcategoria_tareafecha_modificacionfilter_Internalname = "LBLCATEGORIA_TAREAFECHA_MODIFICACIONFILTER";
         edtavCcategoria_tareafecha_modificacion_Internalname = "vCCATEGORIA_TAREAFECHA_MODIFICACION";
         divCategoria_tareafecha_modificacionfiltercontainer_Internalname = "CATEGORIA_TAREAFECHA_MODIFICACIONFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtcategoria_tareaid_tipo_categoria_Internalname = "CATEGORIA_TAREAID_TIPO_CATEGORIA";
         edtid_unidad_gis_Internalname = "ID_UNIDAD_GIS";
         edtcategoria_tareaestado_Internalname = "CATEGORIA_TAREAESTADO";
         edtcategoria_tareafecha_creacion_Internalname = "CATEGORIA_TAREAFECHA_CREACION";
         edtcategoria_tareahora_creacion_Internalname = "CATEGORIA_TAREAHORA_CREACION";
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
         edtcategoria_tareahora_creacion_Jsonclick = "";
         edtcategoria_tareafecha_creacion_Jsonclick = "";
         edtcategoria_tareaestado_Jsonclick = "";
         edtid_unidad_gis_Jsonclick = "";
         edtcategoria_tareaid_tipo_categoria_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtid_unidad_gis_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcategoria_tareafecha_modificacion_Jsonclick = "";
         edtavCcategoria_tareafecha_modificacion_Enabled = 1;
         edtavCcategoria_tareacreado_por_Jsonclick = "";
         edtavCcategoria_tareacreado_por_Enabled = 1;
         edtavCcategoria_tareacreado_por_Visible = 1;
         edtavCcategoria_tareahora_creacion_Jsonclick = "";
         edtavCcategoria_tareahora_creacion_Enabled = 1;
         edtavCcategoria_tareahora_creacion_Visible = 1;
         edtavCcategoria_tareafecha_creacion_Jsonclick = "";
         edtavCcategoria_tareafecha_creacion_Enabled = 1;
         edtavCcategoria_tareaestado_Jsonclick = "";
         edtavCcategoria_tareaestado_Enabled = 1;
         edtavCcategoria_tareaestado_Visible = 1;
         edtavCid_unidad_gis_Jsonclick = "";
         edtavCid_unidad_gis_Enabled = 1;
         edtavCid_unidad_gis_Visible = 1;
         edtavCcategoria_tareaid_tipo_categoria_Jsonclick = "";
         edtavCcategoria_tareaid_tipo_categoria_Enabled = 1;
         edtavCcategoria_tareaid_tipo_categoria_Visible = 1;
         divCategoria_tareafecha_modificacionfiltercontainer_Class = "AdvancedContainerItem";
         divCategoria_tareacreado_porfiltercontainer_Class = "AdvancedContainerItem";
         divCategoria_tareahora_creacionfiltercontainer_Class = "AdvancedContainerItem";
         divCategoria_tareafecha_creacionfiltercontainer_Class = "AdvancedContainerItem";
         divCategoria_tareaestadofiltercontainer_Class = "AdvancedContainerItem";
         divId_unidad_gisfiltercontainer_Class = "AdvancedContainerItem";
         divCategoria_tareaid_tipo_categoriafiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List categoria_tarea";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccategoria_tareaid_tipo_categoria',fld:'vCCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cid_unidad_gis',fld:'vCID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV8ccategoria_tareaestado',fld:'vCCATEGORIA_TAREAESTADO',pic:'ZZZZZZZZ9'},{av:'AV9ccategoria_tareafecha_creacion',fld:'vCCATEGORIA_TAREAFECHA_CREACION',pic:''},{av:'AV10ccategoria_tareahora_creacion',fld:'vCCATEGORIA_TAREAHORA_CREACION',pic:'ZZZZ9'},{av:'AV11ccategoria_tareacreado_por',fld:'vCCATEGORIA_TAREACREADO_POR',pic:''},{av:'AV12ccategoria_tareafecha_modificacion',fld:'vCCATEGORIA_TAREAFECHA_MODIFICACION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E185G1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCATEGORIA_TAREAID_TIPO_CATEGORIAFILTER.CLICK","{handler:'E115G1',iparms:[{av:'divCategoria_tareaid_tipo_categoriafiltercontainer_Class',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORIA_TAREAID_TIPO_CATEGORIAFILTER.CLICK",",oparms:[{av:'divCategoria_tareaid_tipo_categoriafiltercontainer_Class',ctrl:'CATEGORIA_TAREAID_TIPO_CATEGORIAFILTERCONTAINER',prop:'Class'},{av:'edtavCcategoria_tareaid_tipo_categoria_Visible',ctrl:'vCCATEGORIA_TAREAID_TIPO_CATEGORIA',prop:'Visible'}]}");
         setEventMetadata("LBLID_UNIDAD_GISFILTER.CLICK","{handler:'E125G1',iparms:[{av:'divId_unidad_gisfiltercontainer_Class',ctrl:'ID_UNIDAD_GISFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLID_UNIDAD_GISFILTER.CLICK",",oparms:[{av:'divId_unidad_gisfiltercontainer_Class',ctrl:'ID_UNIDAD_GISFILTERCONTAINER',prop:'Class'},{av:'edtavCid_unidad_gis_Visible',ctrl:'vCID_UNIDAD_GIS',prop:'Visible'}]}");
         setEventMetadata("LBLCATEGORIA_TAREAESTADOFILTER.CLICK","{handler:'E135G1',iparms:[{av:'divCategoria_tareaestadofiltercontainer_Class',ctrl:'CATEGORIA_TAREAESTADOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORIA_TAREAESTADOFILTER.CLICK",",oparms:[{av:'divCategoria_tareaestadofiltercontainer_Class',ctrl:'CATEGORIA_TAREAESTADOFILTERCONTAINER',prop:'Class'},{av:'edtavCcategoria_tareaestado_Visible',ctrl:'vCCATEGORIA_TAREAESTADO',prop:'Visible'}]}");
         setEventMetadata("LBLCATEGORIA_TAREAFECHA_CREACIONFILTER.CLICK","{handler:'E145G1',iparms:[{av:'divCategoria_tareafecha_creacionfiltercontainer_Class',ctrl:'CATEGORIA_TAREAFECHA_CREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORIA_TAREAFECHA_CREACIONFILTER.CLICK",",oparms:[{av:'divCategoria_tareafecha_creacionfiltercontainer_Class',ctrl:'CATEGORIA_TAREAFECHA_CREACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLCATEGORIA_TAREAHORA_CREACIONFILTER.CLICK","{handler:'E155G1',iparms:[{av:'divCategoria_tareahora_creacionfiltercontainer_Class',ctrl:'CATEGORIA_TAREAHORA_CREACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORIA_TAREAHORA_CREACIONFILTER.CLICK",",oparms:[{av:'divCategoria_tareahora_creacionfiltercontainer_Class',ctrl:'CATEGORIA_TAREAHORA_CREACIONFILTERCONTAINER',prop:'Class'},{av:'edtavCcategoria_tareahora_creacion_Visible',ctrl:'vCCATEGORIA_TAREAHORA_CREACION',prop:'Visible'}]}");
         setEventMetadata("LBLCATEGORIA_TAREACREADO_PORFILTER.CLICK","{handler:'E165G1',iparms:[{av:'divCategoria_tareacreado_porfiltercontainer_Class',ctrl:'CATEGORIA_TAREACREADO_PORFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORIA_TAREACREADO_PORFILTER.CLICK",",oparms:[{av:'divCategoria_tareacreado_porfiltercontainer_Class',ctrl:'CATEGORIA_TAREACREADO_PORFILTERCONTAINER',prop:'Class'},{av:'edtavCcategoria_tareacreado_por_Visible',ctrl:'vCCATEGORIA_TAREACREADO_POR',prop:'Visible'}]}");
         setEventMetadata("LBLCATEGORIA_TAREAFECHA_MODIFICACIONFILTER.CLICK","{handler:'E175G1',iparms:[{av:'divCategoria_tareafecha_modificacionfiltercontainer_Class',ctrl:'CATEGORIA_TAREAFECHA_MODIFICACIONFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCATEGORIA_TAREAFECHA_MODIFICACIONFILTER.CLICK",",oparms:[{av:'divCategoria_tareafecha_modificacionfiltercontainer_Class',ctrl:'CATEGORIA_TAREAFECHA_MODIFICACIONFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("ENTER","{handler:'E215G2',iparms:[{av:'A104categoria_tareaid_tipo_categoria',fld:'CATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pcategoria_tareaid_tipo_categoria',fld:'vPCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccategoria_tareaid_tipo_categoria',fld:'vCCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cid_unidad_gis',fld:'vCID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV8ccategoria_tareaestado',fld:'vCCATEGORIA_TAREAESTADO',pic:'ZZZZZZZZ9'},{av:'AV9ccategoria_tareafecha_creacion',fld:'vCCATEGORIA_TAREAFECHA_CREACION',pic:''},{av:'AV10ccategoria_tareahora_creacion',fld:'vCCATEGORIA_TAREAHORA_CREACION',pic:'ZZZZ9'},{av:'AV11ccategoria_tareacreado_por',fld:'vCCATEGORIA_TAREACREADO_POR',pic:''},{av:'AV12ccategoria_tareafecha_modificacion',fld:'vCCATEGORIA_TAREAFECHA_MODIFICACION',pic:''}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccategoria_tareaid_tipo_categoria',fld:'vCCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cid_unidad_gis',fld:'vCID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV8ccategoria_tareaestado',fld:'vCCATEGORIA_TAREAESTADO',pic:'ZZZZZZZZ9'},{av:'AV9ccategoria_tareafecha_creacion',fld:'vCCATEGORIA_TAREAFECHA_CREACION',pic:''},{av:'AV10ccategoria_tareahora_creacion',fld:'vCCATEGORIA_TAREAHORA_CREACION',pic:'ZZZZ9'},{av:'AV11ccategoria_tareacreado_por',fld:'vCCATEGORIA_TAREACREADO_POR',pic:''},{av:'AV12ccategoria_tareafecha_modificacion',fld:'vCCATEGORIA_TAREAFECHA_MODIFICACION',pic:''}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccategoria_tareaid_tipo_categoria',fld:'vCCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cid_unidad_gis',fld:'vCID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV8ccategoria_tareaestado',fld:'vCCATEGORIA_TAREAESTADO',pic:'ZZZZZZZZ9'},{av:'AV9ccategoria_tareafecha_creacion',fld:'vCCATEGORIA_TAREAFECHA_CREACION',pic:''},{av:'AV10ccategoria_tareahora_creacion',fld:'vCCATEGORIA_TAREAHORA_CREACION',pic:'ZZZZ9'},{av:'AV11ccategoria_tareacreado_por',fld:'vCCATEGORIA_TAREACREADO_POR',pic:''},{av:'AV12ccategoria_tareafecha_modificacion',fld:'vCCATEGORIA_TAREAFECHA_MODIFICACION',pic:''}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6ccategoria_tareaid_tipo_categoria',fld:'vCCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV7cid_unidad_gis',fld:'vCID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV8ccategoria_tareaestado',fld:'vCCATEGORIA_TAREAESTADO',pic:'ZZZZZZZZ9'},{av:'AV9ccategoria_tareafecha_creacion',fld:'vCCATEGORIA_TAREAFECHA_CREACION',pic:''},{av:'AV10ccategoria_tareahora_creacion',fld:'vCCATEGORIA_TAREAHORA_CREACION',pic:'ZZZZ9'},{av:'AV11ccategoria_tareacreado_por',fld:'vCCATEGORIA_TAREACREADO_POR',pic:''},{av:'AV12ccategoria_tareafecha_modificacion',fld:'vCCATEGORIA_TAREAFECHA_MODIFICACION',pic:''}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCATEGORIA_TAREAFECHA_CREACION","{handler:'Validv_Ccategoria_tareafecha_creacion',iparms:[]");
         setEventMetadata("VALIDV_CCATEGORIA_TAREAFECHA_CREACION",",oparms:[]}");
         setEventMetadata("VALIDV_CCATEGORIA_TAREAFECHA_MODIFICACION","{handler:'Validv_Ccategoria_tareafecha_modificacion',iparms:[]");
         setEventMetadata("VALIDV_CCATEGORIA_TAREAFECHA_MODIFICACION",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Categoria_tareahora_creacion',iparms:[]");
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
         AV9ccategoria_tareafecha_creacion = DateTime.MinValue;
         AV11ccategoria_tareacreado_por = "";
         AV12ccategoria_tareafecha_modificacion = DateTime.MinValue;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblcategoria_tareaid_tipo_categoriafilter_Jsonclick = "";
         TempTags = "";
         lblLblid_unidad_gisfilter_Jsonclick = "";
         lblLblcategoria_tareaestadofilter_Jsonclick = "";
         lblLblcategoria_tareafecha_creacionfilter_Jsonclick = "";
         lblLblcategoria_tareahora_creacionfilter_Jsonclick = "";
         lblLblcategoria_tareacreado_porfilter_Jsonclick = "";
         lblLblcategoria_tareafecha_modificacionfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A108categoria_tareafecha_creacion = DateTime.MinValue;
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV11ccategoria_tareacreado_por = "";
         A110categoria_tareacreado_por = "";
         A111categoria_tareafecha_modificacion = DateTime.MinValue;
         H005G2_A111categoria_tareafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         H005G2_n111categoria_tareafecha_modificacion = new bool[] {false} ;
         H005G2_A110categoria_tareacreado_por = new string[] {""} ;
         H005G2_n110categoria_tareacreado_por = new bool[] {false} ;
         H005G2_A109categoria_tareahora_creacion = new int[1] ;
         H005G2_n109categoria_tareahora_creacion = new bool[] {false} ;
         H005G2_A108categoria_tareafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         H005G2_n108categoria_tareafecha_creacion = new bool[] {false} ;
         H005G2_A107categoria_tareaestado = new int[1] ;
         H005G2_n107categoria_tareaestado = new bool[] {false} ;
         H005G2_A105id_unidad_gis = new int[1] ;
         H005G2_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H005G3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.gx00e0__datastore1(),
            new Object[][] {
                new Object[] {
               H005G2_A111categoria_tareafecha_modificacion, H005G2_n111categoria_tareafecha_modificacion, H005G2_A110categoria_tareacreado_por, H005G2_n110categoria_tareacreado_por, H005G2_A109categoria_tareahora_creacion, H005G2_n109categoria_tareahora_creacion, H005G2_A108categoria_tareafecha_creacion, H005G2_n108categoria_tareafecha_creacion, H005G2_A107categoria_tareaestado, H005G2_n107categoria_tareaestado,
               H005G2_A105id_unidad_gis, H005G2_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               H005G3_AGRID1_nRecordCount
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
      private int AV13pcategoria_tareaid_tipo_categoria ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV6ccategoria_tareaid_tipo_categoria ;
      private int AV7cid_unidad_gis ;
      private int AV8ccategoria_tareaestado ;
      private int AV10ccategoria_tareahora_creacion ;
      private int edtavCcategoria_tareaid_tipo_categoria_Enabled ;
      private int edtavCcategoria_tareaid_tipo_categoria_Visible ;
      private int edtavCid_unidad_gis_Enabled ;
      private int edtavCid_unidad_gis_Visible ;
      private int edtavCcategoria_tareaestado_Enabled ;
      private int edtavCcategoria_tareaestado_Visible ;
      private int edtavCcategoria_tareafecha_creacion_Enabled ;
      private int edtavCcategoria_tareahora_creacion_Enabled ;
      private int edtavCcategoria_tareahora_creacion_Visible ;
      private int edtavCcategoria_tareacreado_por_Visible ;
      private int edtavCcategoria_tareacreado_por_Enabled ;
      private int edtavCcategoria_tareafecha_modificacion_Enabled ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A104categoria_tareaid_tipo_categoria ;
      private int A105id_unidad_gis ;
      private int A107categoria_tareaestado ;
      private int A109categoria_tareahora_creacion ;
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
      private string divCategoria_tareaid_tipo_categoriafiltercontainer_Class ;
      private string divId_unidad_gisfiltercontainer_Class ;
      private string divCategoria_tareaestadofiltercontainer_Class ;
      private string divCategoria_tareafecha_creacionfiltercontainer_Class ;
      private string divCategoria_tareahora_creacionfiltercontainer_Class ;
      private string divCategoria_tareacreado_porfiltercontainer_Class ;
      private string divCategoria_tareafecha_modificacionfiltercontainer_Class ;
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
      private string divCategoria_tareaid_tipo_categoriafiltercontainer_Internalname ;
      private string lblLblcategoria_tareaid_tipo_categoriafilter_Internalname ;
      private string lblLblcategoria_tareaid_tipo_categoriafilter_Jsonclick ;
      private string edtavCcategoria_tareaid_tipo_categoria_Internalname ;
      private string TempTags ;
      private string edtavCcategoria_tareaid_tipo_categoria_Jsonclick ;
      private string divId_unidad_gisfiltercontainer_Internalname ;
      private string lblLblid_unidad_gisfilter_Internalname ;
      private string lblLblid_unidad_gisfilter_Jsonclick ;
      private string edtavCid_unidad_gis_Internalname ;
      private string edtavCid_unidad_gis_Jsonclick ;
      private string divCategoria_tareaestadofiltercontainer_Internalname ;
      private string lblLblcategoria_tareaestadofilter_Internalname ;
      private string lblLblcategoria_tareaestadofilter_Jsonclick ;
      private string edtavCcategoria_tareaestado_Internalname ;
      private string edtavCcategoria_tareaestado_Jsonclick ;
      private string divCategoria_tareafecha_creacionfiltercontainer_Internalname ;
      private string lblLblcategoria_tareafecha_creacionfilter_Internalname ;
      private string lblLblcategoria_tareafecha_creacionfilter_Jsonclick ;
      private string edtavCcategoria_tareafecha_creacion_Internalname ;
      private string edtavCcategoria_tareafecha_creacion_Jsonclick ;
      private string divCategoria_tareahora_creacionfiltercontainer_Internalname ;
      private string lblLblcategoria_tareahora_creacionfilter_Internalname ;
      private string lblLblcategoria_tareahora_creacionfilter_Jsonclick ;
      private string edtavCcategoria_tareahora_creacion_Internalname ;
      private string edtavCcategoria_tareahora_creacion_Jsonclick ;
      private string divCategoria_tareacreado_porfiltercontainer_Internalname ;
      private string lblLblcategoria_tareacreado_porfilter_Internalname ;
      private string lblLblcategoria_tareacreado_porfilter_Jsonclick ;
      private string edtavCcategoria_tareacreado_por_Internalname ;
      private string edtavCcategoria_tareacreado_por_Jsonclick ;
      private string divCategoria_tareafecha_modificacionfiltercontainer_Internalname ;
      private string lblLblcategoria_tareafecha_modificacionfilter_Internalname ;
      private string lblLblcategoria_tareafecha_modificacionfilter_Jsonclick ;
      private string edtavCcategoria_tareafecha_modificacion_Internalname ;
      private string edtavCcategoria_tareafecha_modificacion_Jsonclick ;
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
      private string edtid_unidad_gis_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtcategoria_tareaid_tipo_categoria_Internalname ;
      private string edtid_unidad_gis_Internalname ;
      private string edtcategoria_tareaestado_Internalname ;
      private string edtcategoria_tareafecha_creacion_Internalname ;
      private string edtcategoria_tareahora_creacion_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtcategoria_tareaid_tipo_categoria_Jsonclick ;
      private string edtid_unidad_gis_Jsonclick ;
      private string edtcategoria_tareaestado_Jsonclick ;
      private string edtcategoria_tareafecha_creacion_Jsonclick ;
      private string edtcategoria_tareahora_creacion_Jsonclick ;
      private DateTime AV9ccategoria_tareafecha_creacion ;
      private DateTime AV12ccategoria_tareafecha_modificacion ;
      private DateTime A108categoria_tareafecha_creacion ;
      private DateTime A111categoria_tareafecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n107categoria_tareaestado ;
      private bool n108categoria_tareafecha_creacion ;
      private bool n109categoria_tareahora_creacion ;
      private bool gxdyncontrolsrefreshing ;
      private bool n111categoria_tareafecha_modificacion ;
      private bool n110categoria_tareacreado_por ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV11ccategoria_tareacreado_por ;
      private string AV17Linkselection_GXI ;
      private string lV11ccategoria_tareacreado_por ;
      private string A110categoria_tareacreado_por ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private DateTime[] H005G2_A111categoria_tareafecha_modificacion ;
      private bool[] H005G2_n111categoria_tareafecha_modificacion ;
      private string[] H005G2_A110categoria_tareacreado_por ;
      private bool[] H005G2_n110categoria_tareacreado_por ;
      private int[] H005G2_A109categoria_tareahora_creacion ;
      private bool[] H005G2_n109categoria_tareahora_creacion ;
      private DateTime[] H005G2_A108categoria_tareafecha_creacion ;
      private bool[] H005G2_n108categoria_tareafecha_creacion ;
      private int[] H005G2_A107categoria_tareaestado ;
      private bool[] H005G2_n107categoria_tareaestado ;
      private int[] H005G2_A105id_unidad_gis ;
      private int[] H005G2_A104categoria_tareaid_tipo_categoria ;
      private long[] H005G3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int aP0_pcategoria_tareaid_tipo_categoria ;
      private GXWebForm Form ;
   }

   public class gx00e0__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H005G2( IGxContext context ,
                                             int AV7cid_unidad_gis ,
                                             int AV8ccategoria_tareaestado ,
                                             DateTime AV9ccategoria_tareafecha_creacion ,
                                             int AV10ccategoria_tareahora_creacion ,
                                             string AV11ccategoria_tareacreado_por ,
                                             DateTime AV12ccategoria_tareafecha_modificacion ,
                                             int A105id_unidad_gis ,
                                             int A107categoria_tareaestado ,
                                             DateTime A108categoria_tareafecha_creacion ,
                                             int A109categoria_tareahora_creacion ,
                                             string A110categoria_tareacreado_por ,
                                             DateTime A111categoria_tareafecha_modificacion ,
                                             int AV6ccategoria_tareaid_tipo_categoria )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [fecha_modificacion], [creado_por], [hora_creacion], [fecha_creacion], [estado], [id_unidad_gis], [id_tipo_categoria]";
         sFromString = " FROM dbo.[categoria_tarea]";
         sOrderString = "";
         AddWhere(sWhereString, "([id_tipo_categoria] >= @AV6ccategoria_tareaid_tipo_categoria)");
         if ( ! (0==AV7cid_unidad_gis) )
         {
            AddWhere(sWhereString, "([id_unidad_gis] >= @AV7cid_unidad_gis)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV8ccategoria_tareaestado) )
         {
            AddWhere(sWhereString, "([estado] >= @AV8ccategoria_tareaestado)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9ccategoria_tareafecha_creacion) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV9ccategoria_tareafecha_creacion)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10ccategoria_tareahora_creacion) )
         {
            AddWhere(sWhereString, "([hora_creacion] >= @AV10ccategoria_tareahora_creacion)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ccategoria_tareacreado_por)) )
         {
            AddWhere(sWhereString, "([creado_por] like @lV11ccategoria_tareacreado_por)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12ccategoria_tareafecha_modificacion) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV12ccategoria_tareafecha_modificacion)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [id_tipo_categoria]";
         scmdbuf = "SELECT * FROM (SELECT " + sSelectString + ", ROW_NUMBER() OVER (" + sOrderString + " ) AS GX_ROW_NUMBER" + sFromString + sWhereString + "" + ") AS GX_CTE WHERE GX_ROW_NUMBER" + " >= " + "@GXPagingFrom2" + " AND GX_ROW_NUMBER <= (CASE WHEN (" + "@GXPagingTo2" + " < " + "@GXPagingFrom2" + ") THEN CAST(0x7FFFFFFFFFFFFFFF AS bigint) ELSE " + "@GXPagingTo2" + " END)";
         scmdbuf += " OPTION (FAST 11)";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H005G3( IGxContext context ,
                                             int AV7cid_unidad_gis ,
                                             int AV8ccategoria_tareaestado ,
                                             DateTime AV9ccategoria_tareafecha_creacion ,
                                             int AV10ccategoria_tareahora_creacion ,
                                             string AV11ccategoria_tareacreado_por ,
                                             DateTime AV12ccategoria_tareafecha_modificacion ,
                                             int A105id_unidad_gis ,
                                             int A107categoria_tareaestado ,
                                             DateTime A108categoria_tareafecha_creacion ,
                                             int A109categoria_tareahora_creacion ,
                                             string A110categoria_tareacreado_por ,
                                             DateTime A111categoria_tareafecha_modificacion ,
                                             int AV6ccategoria_tareaid_tipo_categoria )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM dbo.[categoria_tarea]";
         AddWhere(sWhereString, "([id_tipo_categoria] >= @AV6ccategoria_tareaid_tipo_categoria)");
         if ( ! (0==AV7cid_unidad_gis) )
         {
            AddWhere(sWhereString, "([id_unidad_gis] >= @AV7cid_unidad_gis)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV8ccategoria_tareaestado) )
         {
            AddWhere(sWhereString, "([estado] >= @AV8ccategoria_tareaestado)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9ccategoria_tareafecha_creacion) )
         {
            AddWhere(sWhereString, "([fecha_creacion] >= @AV9ccategoria_tareafecha_creacion)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10ccategoria_tareahora_creacion) )
         {
            AddWhere(sWhereString, "([hora_creacion] >= @AV10ccategoria_tareahora_creacion)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11ccategoria_tareacreado_por)) )
         {
            AddWhere(sWhereString, "([creado_por] like @lV11ccategoria_tareacreado_por)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV12ccategoria_tareafecha_modificacion) )
         {
            AddWhere(sWhereString, "([fecha_modificacion] >= @AV12ccategoria_tareafecha_modificacion)");
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
                     return conditional_H005G2(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] );
               case 1 :
                     return conditional_H005G3(context, (int)dynConstraints[0] , (int)dynConstraints[1] , (DateTime)dynConstraints[2] , (int)dynConstraints[3] , (string)dynConstraints[4] , (DateTime)dynConstraints[5] , (int)dynConstraints[6] , (int)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (DateTime)dynConstraints[11] , (int)dynConstraints[12] );
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
          Object[] prmH005G2;
          prmH005G2 = new Object[] {
          new ParDef("@AV6ccategoria_tareaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@AV7cid_unidad_gis",GXType.Int32,9,0) ,
          new ParDef("@AV8ccategoria_tareaestado",GXType.Int32,9,0) ,
          new ParDef("@AV9ccategoria_tareafecha_creacion",GXType.Date,8,0) ,
          new ParDef("@AV10ccategoria_tareahora_creacion",GXType.Int32,5,0) ,
          new ParDef("@lV11ccategoria_tareacreado_por",GXType.NVarChar,30,0) ,
          new ParDef("@AV12ccategoria_tareafecha_modificacion",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH005G3;
          prmH005G3 = new Object[] {
          new ParDef("@AV6ccategoria_tareaid_tipo_categoria",GXType.Int32,9,0) ,
          new ParDef("@AV7cid_unidad_gis",GXType.Int32,9,0) ,
          new ParDef("@AV8ccategoria_tareaestado",GXType.Int32,9,0) ,
          new ParDef("@AV9ccategoria_tareafecha_creacion",GXType.Date,8,0) ,
          new ParDef("@AV10ccategoria_tareahora_creacion",GXType.Int32,5,0) ,
          new ParDef("@lV11ccategoria_tareacreado_por",GXType.NVarChar,30,0) ,
          new ParDef("@AV12ccategoria_tareafecha_modificacion",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H005G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005G3,1, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((int[]) buf[11])[0] = rslt.getInt(7);
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
