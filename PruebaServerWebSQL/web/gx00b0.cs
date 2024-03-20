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
   public class gx00b0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00b0( )
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

      public gx00b0( IGxContext context )
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

      public void execute( out string aP0_pUsuarioSistemaId )
      {
         this.AV9pUsuarioSistemaId = "" ;
         executePrivate();
         aP0_pUsuarioSistemaId=this.AV9pUsuarioSistemaId;
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
            gxfirstwebparm = GetFirstPar( "pUsuarioSistemaId");
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
               gxfirstwebparm = GetFirstPar( "pUsuarioSistemaId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pUsuarioSistemaId");
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
               AV6cUsuarioSistemaId = GetPar( "cUsuarioSistemaId");
               AV7cUsuarioSistemaNombre = GetPar( "cUsuarioSistemaNombre");
               AV8cUsuarioSistemaIdentidad = GetPar( "cUsuarioSistemaIdentidad");
               AV11cDireccionId = (short)(NumberUtil.Val( GetPar( "cDireccionId"), "."));
               AV12cCentrodecostoId = GetPar( "cCentrodecostoId");
               AV13cDepartamentoId = (short)(NumberUtil.Val( GetPar( "cDepartamentoId"), "."));
               AV14cUsuarioSistemaTelefono = (int)(NumberUtil.Val( GetPar( "cUsuarioSistemaTelefono"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioSistemaId, AV7cUsuarioSistemaNombre, AV8cUsuarioSistemaIdentidad, AV11cDireccionId, AV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono) ;
               GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
               GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
               GxWebStd.gx_hidden_field( context, "USUARIOSISTEMAIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistemaidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "USUARIOSISTEMANOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistemanombrefiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "USUARIOSISTEMAIDENTIDADFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistemaidentidadfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "DIRECCIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divDireccionidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "CENTRODECOSTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divCentrodecostoidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
               GxWebStd.gx_hidden_field( context, "USUARIOSISTEMATELEFONOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistematelefonofiltercontainer_Class));
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
               AV9pUsuarioSistemaId = gxfirstwebparm;
               AssignAttri("", false, "AV9pUsuarioSistemaId", AV9pUsuarioSistemaId);
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
            return "gx00b0_Execute" ;
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
         PA532( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START532( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20231249572289", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00b0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9pUsuarioSistemaId))}, new string[] {"pUsuarioSistemaId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSISTEMAID", AV6cUsuarioSistemaId);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSISTEMANOMBRE", AV7cUsuarioSistemaNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSISTEMAIDENTIDAD", AV8cUsuarioSistemaIdentidad);
         GxWebStd.gx_hidden_field( context, "GXH_vCDIRECCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cDireccionId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCENTRODECOSTOID", AV12cCentrodecostoId);
         GxWebStd.gx_hidden_field( context, "GXH_vCDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cDepartamentoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOSISTEMATELEFONO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cUsuarioSistemaTelefono), 9, 0, ",", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOSISTEMAID", AV9pUsuarioSistemaId);
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSISTEMAIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistemaidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSISTEMANOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistemanombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSISTEMAIDENTIDADFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistemaidentidadfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DIRECCIONIDFILTERCONTAINER_Class", StringUtil.RTrim( divDireccionidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CENTRODECOSTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divCentrodecostoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "DEPARTAMENTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divDepartamentoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOSISTEMATELEFONOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariosistematelefonofiltercontainer_Class));
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
            WE532( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT532( ) ;
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
         return formatLink("gx00b0.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9pUsuarioSistemaId))}, new string[] {"pUsuarioSistemaId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00B0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Usuario Sistema" ;
      }

      protected void WB530( )
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
            GxWebStd.gx_div_start( context, divUsuariosistemaidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosistemaidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosistemaidfilter_Internalname, "Usuario Sistema", "", "", lblLblusuariosistemaidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosistemaid_Internalname, "Usuario Sistema", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosistemaid_Internalname, AV6cUsuarioSistemaId, StringUtil.RTrim( context.localUtil.Format( AV6cUsuarioSistemaId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosistemaid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosistemaid_Visible, edtavCusuariosistemaid_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosistemanombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosistemanombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosistemanombrefilter_Internalname, "Nombre", "", "", lblLblusuariosistemanombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosistemanombre_Internalname, "Nombre", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosistemanombre_Internalname, AV7cUsuarioSistemaNombre, StringUtil.RTrim( context.localUtil.Format( AV7cUsuarioSistemaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosistemanombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosistemanombre_Visible, edtavCusuariosistemanombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosistemaidentidadfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosistemaidentidadfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosistemaidentidadfilter_Internalname, "Identidad", "", "", lblLblusuariosistemaidentidadfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosistemaidentidad_Internalname, "Identidad", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosistemaidentidad_Internalname, AV8cUsuarioSistemaIdentidad, StringUtil.RTrim( context.localUtil.Format( AV8cUsuarioSistemaIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosistemaidentidad_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosistemaidentidad_Visible, edtavCusuariosistemaidentidad_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divDireccionidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDireccionidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldireccionidfilter_Internalname, "Direccion Id", "", "", lblLbldireccionidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdireccionid_Internalname, "Direccion Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdireccionid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cDireccionId), 4, 0, ",", "")), ((edtavCdireccionid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV11cDireccionId), "ZZZ9")) : context.localUtil.Format( (decimal)(AV11cDireccionId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdireccionid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdireccionid_Visible, edtavCdireccionid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divCentrodecostoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCentrodecostoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcentrodecostoidfilter_Internalname, "Centrodecosto Id", "", "", lblLblcentrodecostoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcentrodecostoid_Internalname, "Centrodecosto Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcentrodecostoid_Internalname, AV12cCentrodecostoId, StringUtil.RTrim( context.localUtil.Format( AV12cCentrodecostoId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcentrodecostoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcentrodecostoid_Visible, edtavCcentrodecostoid_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divDepartamentoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divDepartamentoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLbldepartamentoidfilter_Internalname, "Departamento Id", "", "", lblLbldepartamentoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCdepartamentoid_Internalname, "Departamento Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCdepartamentoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cDepartamentoId), 4, 0, ",", "")), ((edtavCdepartamentoid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV13cDepartamentoId), "ZZZ9")) : context.localUtil.Format( (decimal)(AV13cDepartamentoId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCdepartamentoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCdepartamentoid_Visible, edtavCdepartamentoid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divUsuariosistematelefonofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariosistematelefonofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariosistematelefonofilter_Internalname, "Teléfono", "", "", lblLblusuariosistematelefonofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17531_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariosistematelefono_Internalname, "Teléfono", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariosistematelefono_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cUsuarioSistemaTelefono), 9, 0, ",", "")), ((edtavCusuariosistematelefono_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV14cUsuarioSistemaTelefono), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV14cUsuarioSistemaTelefono), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariosistematelefono_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariosistematelefono_Visible, edtavCusuariosistematelefono_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18531_client"+"'", TempTags, "", 2, "HLP_Gx00B0.htm");
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
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario Sistema:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Direccion Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Teléfono") ;
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
               Grid1Column.AddObjectProperty("Value", A99UsuarioSistemaId);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A258DireccionId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A264UsuarioSistemaTelefono), 9, 0, ".", "")));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00B0.htm");
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

      protected void START532( )
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
            Form.Meta.addItem("description", "Selection List Usuario Sistema", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP530( ) ;
      }

      protected void WS532( )
      {
         START532( ) ;
         EVT532( ) ;
      }

      protected void EVT532( )
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
                              A99UsuarioSistemaId = cgiGet( edtUsuarioSistemaId_Internalname);
                              A258DireccionId = (short)(context.localUtil.CToN( cgiGet( edtDireccionId_Internalname), ",", "."));
                              A264UsuarioSistemaTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioSistemaTelefono_Internalname), ",", "."));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19532 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20532 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cusuariosistemaid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSISTEMAID"), AV6cUsuarioSistemaId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosistemanombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSISTEMANOMBRE"), AV7cUsuarioSistemaNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosistemaidentidad Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSISTEMAIDENTIDAD"), AV8cUsuarioSistemaIdentidad) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdireccionid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDIRECCIONID"), ",", ".") != Convert.ToDecimal( AV11cDireccionId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccentrodecostoid Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTRODECOSTOID"), AV12cCentrodecostoId) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cdepartamentoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), ",", ".") != Convert.ToDecimal( AV13cDepartamentoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariosistematelefono Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSISTEMATELEFONO"), ",", ".") != Convert.ToDecimal( AV14cUsuarioSistemaTelefono )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21532 ();
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

      protected void WE532( )
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

      protected void PA532( )
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
                                        string AV6cUsuarioSistemaId ,
                                        string AV7cUsuarioSistemaNombre ,
                                        string AV8cUsuarioSistemaIdentidad ,
                                        short AV11cDireccionId ,
                                        string AV12cCentrodecostoId ,
                                        short AV13cDepartamentoId ,
                                        int AV14cUsuarioSistemaTelefono )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF532( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF532( ) ;
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

      protected void RF532( )
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
                                                 AV7cUsuarioSistemaNombre ,
                                                 AV8cUsuarioSistemaIdentidad ,
                                                 AV11cDireccionId ,
                                                 AV12cCentrodecostoId ,
                                                 AV13cDepartamentoId ,
                                                 AV14cUsuarioSistemaTelefono ,
                                                 A100UsuarioSistemaNombre ,
                                                 A101UsuarioSistemaIdentidad ,
                                                 A258DireccionId ,
                                                 A259CentrodecostoId ,
                                                 A260DepartamentoId ,
                                                 A264UsuarioSistemaTelefono ,
                                                 A99UsuarioSistemaId ,
                                                 AV6cUsuarioSistemaId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT
                                                 }
            });
            lV6cUsuarioSistemaId = StringUtil.Concat( StringUtil.RTrim( AV6cUsuarioSistemaId), "%", "");
            lV7cUsuarioSistemaNombre = StringUtil.Concat( StringUtil.RTrim( AV7cUsuarioSistemaNombre), "%", "");
            lV8cUsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV8cUsuarioSistemaIdentidad), "%", "");
            lV12cCentrodecostoId = StringUtil.Concat( StringUtil.RTrim( AV12cCentrodecostoId), "%", "");
            /* Using cursor H00532 */
            pr_default.execute(0, new Object[] {lV6cUsuarioSistemaId, lV7cUsuarioSistemaNombre, lV8cUsuarioSistemaIdentidad, AV11cDireccionId, lV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A260DepartamentoId = H00532_A260DepartamentoId[0];
               A259CentrodecostoId = H00532_A259CentrodecostoId[0];
               A101UsuarioSistemaIdentidad = H00532_A101UsuarioSistemaIdentidad[0];
               A100UsuarioSistemaNombre = H00532_A100UsuarioSistemaNombre[0];
               A264UsuarioSistemaTelefono = H00532_A264UsuarioSistemaTelefono[0];
               A258DireccionId = H00532_A258DireccionId[0];
               A99UsuarioSistemaId = H00532_A99UsuarioSistemaId[0];
               /* Execute user event: Load */
               E20532 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB530( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes532( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOSISTEMAID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), context));
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
                                              AV7cUsuarioSistemaNombre ,
                                              AV8cUsuarioSistemaIdentidad ,
                                              AV11cDireccionId ,
                                              AV12cCentrodecostoId ,
                                              AV13cDepartamentoId ,
                                              AV14cUsuarioSistemaTelefono ,
                                              A100UsuarioSistemaNombre ,
                                              A101UsuarioSistemaIdentidad ,
                                              A258DireccionId ,
                                              A259CentrodecostoId ,
                                              A260DepartamentoId ,
                                              A264UsuarioSistemaTelefono ,
                                              A99UsuarioSistemaId ,
                                              AV6cUsuarioSistemaId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV6cUsuarioSistemaId = StringUtil.Concat( StringUtil.RTrim( AV6cUsuarioSistemaId), "%", "");
         lV7cUsuarioSistemaNombre = StringUtil.Concat( StringUtil.RTrim( AV7cUsuarioSistemaNombre), "%", "");
         lV8cUsuarioSistemaIdentidad = StringUtil.Concat( StringUtil.RTrim( AV8cUsuarioSistemaIdentidad), "%", "");
         lV12cCentrodecostoId = StringUtil.Concat( StringUtil.RTrim( AV12cCentrodecostoId), "%", "");
         /* Using cursor H00533 */
         pr_default.execute(1, new Object[] {lV6cUsuarioSistemaId, lV7cUsuarioSistemaNombre, lV8cUsuarioSistemaIdentidad, AV11cDireccionId, lV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono});
         GRID1_nRecordCount = H00533_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioSistemaId, AV7cUsuarioSistemaNombre, AV8cUsuarioSistemaIdentidad, AV11cDireccionId, AV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioSistemaId, AV7cUsuarioSistemaNombre, AV8cUsuarioSistemaIdentidad, AV11cDireccionId, AV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioSistemaId, AV7cUsuarioSistemaNombre, AV8cUsuarioSistemaIdentidad, AV11cDireccionId, AV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioSistemaId, AV7cUsuarioSistemaNombre, AV8cUsuarioSistemaIdentidad, AV11cDireccionId, AV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioSistemaId, AV7cUsuarioSistemaNombre, AV8cUsuarioSistemaIdentidad, AV11cDireccionId, AV12cCentrodecostoId, AV13cDepartamentoId, AV14cUsuarioSistemaTelefono) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP530( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19532 ();
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
            AV6cUsuarioSistemaId = cgiGet( edtavCusuariosistemaid_Internalname);
            AssignAttri("", false, "AV6cUsuarioSistemaId", AV6cUsuarioSistemaId);
            AV7cUsuarioSistemaNombre = cgiGet( edtavCusuariosistemanombre_Internalname);
            AssignAttri("", false, "AV7cUsuarioSistemaNombre", AV7cUsuarioSistemaNombre);
            AV8cUsuarioSistemaIdentidad = cgiGet( edtavCusuariosistemaidentidad_Internalname);
            AssignAttri("", false, "AV8cUsuarioSistemaIdentidad", AV8cUsuarioSistemaIdentidad);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdireccionid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdireccionid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDIRECCIONID");
               GX_FocusControl = edtavCdireccionid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cDireccionId = 0;
               AssignAttri("", false, "AV11cDireccionId", StringUtil.LTrimStr( (decimal)(AV11cDireccionId), 4, 0));
            }
            else
            {
               AV11cDireccionId = (short)(context.localUtil.CToN( cgiGet( edtavCdireccionid_Internalname), ",", "."));
               AssignAttri("", false, "AV11cDireccionId", StringUtil.LTrimStr( (decimal)(AV11cDireccionId), 4, 0));
            }
            AV12cCentrodecostoId = cgiGet( edtavCcentrodecostoid_Internalname);
            AssignAttri("", false, "AV12cCentrodecostoId", AV12cCentrodecostoId);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCDEPARTAMENTOID");
               GX_FocusControl = edtavCdepartamentoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV13cDepartamentoId = 0;
               AssignAttri("", false, "AV13cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV13cDepartamentoId), 4, 0));
            }
            else
            {
               AV13cDepartamentoId = (short)(context.localUtil.CToN( cgiGet( edtavCdepartamentoid_Internalname), ",", "."));
               AssignAttri("", false, "AV13cDepartamentoId", StringUtil.LTrimStr( (decimal)(AV13cDepartamentoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuariosistematelefono_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuariosistematelefono_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOSISTEMATELEFONO");
               GX_FocusControl = edtavCusuariosistematelefono_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV14cUsuarioSistemaTelefono = 0;
               AssignAttri("", false, "AV14cUsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(AV14cUsuarioSistemaTelefono), 9, 0));
            }
            else
            {
               AV14cUsuarioSistemaTelefono = (int)(context.localUtil.CToN( cgiGet( edtavCusuariosistematelefono_Internalname), ",", "."));
               AssignAttri("", false, "AV14cUsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(AV14cUsuarioSistemaTelefono), 9, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSISTEMAID"), AV6cUsuarioSistemaId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSISTEMANOMBRE"), AV7cUsuarioSistemaNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOSISTEMAIDENTIDAD"), AV8cUsuarioSistemaIdentidad) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDIRECCIONID"), ",", ".") != Convert.ToDecimal( AV11cDireccionId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCENTRODECOSTOID"), AV12cCentrodecostoId) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCDEPARTAMENTOID"), ",", ".") != Convert.ToDecimal( AV13cDepartamentoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOSISTEMATELEFONO"), ",", ".") != Convert.ToDecimal( AV14cUsuarioSistemaTelefono )) )
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
         E19532 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19532( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Usuario Sistema", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV10ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20532( )
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
         E21532 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21532( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9pUsuarioSistemaId = A99UsuarioSistemaId;
         AssignAttri("", false, "AV9pUsuarioSistemaId", AV9pUsuarioSistemaId);
         context.setWebReturnParms(new Object[] {(string)AV9pUsuarioSistemaId});
         context.setWebReturnParmsMetadata(new Object[] {"AV9pUsuarioSistemaId"});
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
         AV9pUsuarioSistemaId = (string)getParm(obj,0);
         AssignAttri("", false, "AV9pUsuarioSistemaId", AV9pUsuarioSistemaId);
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
         PA532( ) ;
         WS532( ) ;
         WE532( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249572350", true, true);
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
         context.AddJavascriptSource("gx00b0.js", "?20231249572350", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtUsuarioSistemaId_Internalname = "USUARIOSISTEMAID_"+sGXsfl_84_idx;
         edtDireccionId_Internalname = "DIRECCIONID_"+sGXsfl_84_idx;
         edtUsuarioSistemaTelefono_Internalname = "USUARIOSISTEMATELEFONO_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtUsuarioSistemaId_Internalname = "USUARIOSISTEMAID_"+sGXsfl_84_fel_idx;
         edtDireccionId_Internalname = "DIRECCIONID_"+sGXsfl_84_fel_idx;
         edtUsuarioSistemaTelefono_Internalname = "USUARIOSISTEMATELEFONO_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB530( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( A99UsuarioSistemaId)+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute";
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaId_Internalname,(string)A99UsuarioSistemaId,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)84,(short)1,(short)0,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMUserIdentification",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDireccionId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A258DireccionId), 4, 0, ",", "")),context.localUtil.Format( (decimal)(A258DireccionId), "ZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDireccionId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioSistemaTelefono_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A264UsuarioSistemaTelefono), 9, 0, ",", "")),context.localUtil.Format( (decimal)(A264UsuarioSistemaTelefono), "ZZZZZZZZ9"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioSistemaTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Telefono",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes532( ) ;
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
         lblLblusuariosistemaidfilter_Internalname = "LBLUSUARIOSISTEMAIDFILTER";
         edtavCusuariosistemaid_Internalname = "vCUSUARIOSISTEMAID";
         divUsuariosistemaidfiltercontainer_Internalname = "USUARIOSISTEMAIDFILTERCONTAINER";
         lblLblusuariosistemanombrefilter_Internalname = "LBLUSUARIOSISTEMANOMBREFILTER";
         edtavCusuariosistemanombre_Internalname = "vCUSUARIOSISTEMANOMBRE";
         divUsuariosistemanombrefiltercontainer_Internalname = "USUARIOSISTEMANOMBREFILTERCONTAINER";
         lblLblusuariosistemaidentidadfilter_Internalname = "LBLUSUARIOSISTEMAIDENTIDADFILTER";
         edtavCusuariosistemaidentidad_Internalname = "vCUSUARIOSISTEMAIDENTIDAD";
         divUsuariosistemaidentidadfiltercontainer_Internalname = "USUARIOSISTEMAIDENTIDADFILTERCONTAINER";
         lblLbldireccionidfilter_Internalname = "LBLDIRECCIONIDFILTER";
         edtavCdireccionid_Internalname = "vCDIRECCIONID";
         divDireccionidfiltercontainer_Internalname = "DIRECCIONIDFILTERCONTAINER";
         lblLblcentrodecostoidfilter_Internalname = "LBLCENTRODECOSTOIDFILTER";
         edtavCcentrodecostoid_Internalname = "vCCENTRODECOSTOID";
         divCentrodecostoidfiltercontainer_Internalname = "CENTRODECOSTOIDFILTERCONTAINER";
         lblLbldepartamentoidfilter_Internalname = "LBLDEPARTAMENTOIDFILTER";
         edtavCdepartamentoid_Internalname = "vCDEPARTAMENTOID";
         divDepartamentoidfiltercontainer_Internalname = "DEPARTAMENTOIDFILTERCONTAINER";
         lblLblusuariosistematelefonofilter_Internalname = "LBLUSUARIOSISTEMATELEFONOFILTER";
         edtavCusuariosistematelefono_Internalname = "vCUSUARIOSISTEMATELEFONO";
         divUsuariosistematelefonofiltercontainer_Internalname = "USUARIOSISTEMATELEFONOFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtUsuarioSistemaId_Internalname = "USUARIOSISTEMAID";
         edtDireccionId_Internalname = "DIRECCIONID";
         edtUsuarioSistemaTelefono_Internalname = "USUARIOSISTEMATELEFONO";
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
         edtUsuarioSistemaTelefono_Jsonclick = "";
         edtDireccionId_Jsonclick = "";
         edtUsuarioSistemaId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCusuariosistematelefono_Jsonclick = "";
         edtavCusuariosistematelefono_Enabled = 1;
         edtavCusuariosistematelefono_Visible = 1;
         edtavCdepartamentoid_Jsonclick = "";
         edtavCdepartamentoid_Enabled = 1;
         edtavCdepartamentoid_Visible = 1;
         edtavCcentrodecostoid_Jsonclick = "";
         edtavCcentrodecostoid_Enabled = 1;
         edtavCcentrodecostoid_Visible = 1;
         edtavCdireccionid_Jsonclick = "";
         edtavCdireccionid_Enabled = 1;
         edtavCdireccionid_Visible = 1;
         edtavCusuariosistemaidentidad_Jsonclick = "";
         edtavCusuariosistemaidentidad_Enabled = 1;
         edtavCusuariosistemaidentidad_Visible = 1;
         edtavCusuariosistemanombre_Jsonclick = "";
         edtavCusuariosistemanombre_Enabled = 1;
         edtavCusuariosistemanombre_Visible = 1;
         edtavCusuariosistemaid_Jsonclick = "";
         edtavCusuariosistemaid_Enabled = 1;
         edtavCusuariosistemaid_Visible = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Usuario Sistema";
         divUsuariosistematelefonofiltercontainer_Class = "AdvancedContainerItem";
         divDepartamentoidfiltercontainer_Class = "AdvancedContainerItem";
         divCentrodecostoidfiltercontainer_Class = "AdvancedContainerItem";
         divDireccionidfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosistemaidentidadfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosistemanombrefiltercontainer_Class = "AdvancedContainerItem";
         divUsuariosistemaidfiltercontainer_Class = "AdvancedContainerItem";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioSistemaId',fld:'vCUSUARIOSISTEMAID',pic:''},{av:'AV7cUsuarioSistemaNombre',fld:'vCUSUARIOSISTEMANOMBRE',pic:''},{av:'AV8cUsuarioSistemaIdentidad',fld:'vCUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV11cDireccionId',fld:'vCDIRECCIONID',pic:'ZZZ9'},{av:'AV12cCentrodecostoId',fld:'vCCENTRODECOSTOID',pic:''},{av:'AV13cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV14cUsuarioSistemaTelefono',fld:'vCUSUARIOSISTEMATELEFONO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18531',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOSISTEMAIDFILTER.CLICK","{handler:'E11531',iparms:[{av:'divUsuariosistemaidfiltercontainer_Class',ctrl:'USUARIOSISTEMAIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSISTEMAIDFILTER.CLICK",",oparms:[{av:'divUsuariosistemaidfiltercontainer_Class',ctrl:'USUARIOSISTEMAIDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosistemaid_Visible',ctrl:'vCUSUARIOSISTEMAID',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSISTEMANOMBREFILTER.CLICK","{handler:'E12531',iparms:[{av:'divUsuariosistemanombrefiltercontainer_Class',ctrl:'USUARIOSISTEMANOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSISTEMANOMBREFILTER.CLICK",",oparms:[{av:'divUsuariosistemanombrefiltercontainer_Class',ctrl:'USUARIOSISTEMANOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosistemanombre_Visible',ctrl:'vCUSUARIOSISTEMANOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSISTEMAIDENTIDADFILTER.CLICK","{handler:'E13531',iparms:[{av:'divUsuariosistemaidentidadfiltercontainer_Class',ctrl:'USUARIOSISTEMAIDENTIDADFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSISTEMAIDENTIDADFILTER.CLICK",",oparms:[{av:'divUsuariosistemaidentidadfiltercontainer_Class',ctrl:'USUARIOSISTEMAIDENTIDADFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosistemaidentidad_Visible',ctrl:'vCUSUARIOSISTEMAIDENTIDAD',prop:'Visible'}]}");
         setEventMetadata("LBLDIRECCIONIDFILTER.CLICK","{handler:'E14531',iparms:[{av:'divDireccionidfiltercontainer_Class',ctrl:'DIRECCIONIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDIRECCIONIDFILTER.CLICK",",oparms:[{av:'divDireccionidfiltercontainer_Class',ctrl:'DIRECCIONIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdireccionid_Visible',ctrl:'vCDIRECCIONID',prop:'Visible'}]}");
         setEventMetadata("LBLCENTRODECOSTOIDFILTER.CLICK","{handler:'E15531',iparms:[{av:'divCentrodecostoidfiltercontainer_Class',ctrl:'CENTRODECOSTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCENTRODECOSTOIDFILTER.CLICK",",oparms:[{av:'divCentrodecostoidfiltercontainer_Class',ctrl:'CENTRODECOSTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcentrodecostoid_Visible',ctrl:'vCCENTRODECOSTOID',prop:'Visible'}]}");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK","{handler:'E16531',iparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLDEPARTAMENTOIDFILTER.CLICK",",oparms:[{av:'divDepartamentoidfiltercontainer_Class',ctrl:'DEPARTAMENTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCdepartamentoid_Visible',ctrl:'vCDEPARTAMENTOID',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOSISTEMATELEFONOFILTER.CLICK","{handler:'E17531',iparms:[{av:'divUsuariosistematelefonofiltercontainer_Class',ctrl:'USUARIOSISTEMATELEFONOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOSISTEMATELEFONOFILTER.CLICK",",oparms:[{av:'divUsuariosistematelefonofiltercontainer_Class',ctrl:'USUARIOSISTEMATELEFONOFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariosistematelefono_Visible',ctrl:'vCUSUARIOSISTEMATELEFONO',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21532',iparms:[{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV9pUsuarioSistemaId',fld:'vPUSUARIOSISTEMAID',pic:''}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioSistemaId',fld:'vCUSUARIOSISTEMAID',pic:''},{av:'AV7cUsuarioSistemaNombre',fld:'vCUSUARIOSISTEMANOMBRE',pic:''},{av:'AV8cUsuarioSistemaIdentidad',fld:'vCUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV11cDireccionId',fld:'vCDIRECCIONID',pic:'ZZZ9'},{av:'AV12cCentrodecostoId',fld:'vCCENTRODECOSTOID',pic:''},{av:'AV13cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV14cUsuarioSistemaTelefono',fld:'vCUSUARIOSISTEMATELEFONO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioSistemaId',fld:'vCUSUARIOSISTEMAID',pic:''},{av:'AV7cUsuarioSistemaNombre',fld:'vCUSUARIOSISTEMANOMBRE',pic:''},{av:'AV8cUsuarioSistemaIdentidad',fld:'vCUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV11cDireccionId',fld:'vCDIRECCIONID',pic:'ZZZ9'},{av:'AV12cCentrodecostoId',fld:'vCCENTRODECOSTOID',pic:''},{av:'AV13cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV14cUsuarioSistemaTelefono',fld:'vCUSUARIOSISTEMATELEFONO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioSistemaId',fld:'vCUSUARIOSISTEMAID',pic:''},{av:'AV7cUsuarioSistemaNombre',fld:'vCUSUARIOSISTEMANOMBRE',pic:''},{av:'AV8cUsuarioSistemaIdentidad',fld:'vCUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV11cDireccionId',fld:'vCDIRECCIONID',pic:'ZZZ9'},{av:'AV12cCentrodecostoId',fld:'vCCENTRODECOSTOID',pic:''},{av:'AV13cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV14cUsuarioSistemaTelefono',fld:'vCUSUARIOSISTEMATELEFONO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioSistemaId',fld:'vCUSUARIOSISTEMAID',pic:''},{av:'AV7cUsuarioSistemaNombre',fld:'vCUSUARIOSISTEMANOMBRE',pic:''},{av:'AV8cUsuarioSistemaIdentidad',fld:'vCUSUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV11cDireccionId',fld:'vCDIRECCIONID',pic:'ZZZ9'},{av:'AV12cCentrodecostoId',fld:'vCCENTRODECOSTOID',pic:''},{av:'AV13cDepartamentoId',fld:'vCDEPARTAMENTOID',pic:'ZZZ9'},{av:'AV14cUsuarioSistemaTelefono',fld:'vCUSUARIOSISTEMATELEFONO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariosistematelefono',iparms:[]");
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
         AV9pUsuarioSistemaId = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV6cUsuarioSistemaId = "";
         AV7cUsuarioSistemaNombre = "";
         AV8cUsuarioSistemaIdentidad = "";
         AV12cCentrodecostoId = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblusuariosistemaidfilter_Jsonclick = "";
         TempTags = "";
         lblLblusuariosistemanombrefilter_Jsonclick = "";
         lblLblusuariosistemaidentidadfilter_Jsonclick = "";
         lblLbldireccionidfilter_Jsonclick = "";
         lblLblcentrodecostoidfilter_Jsonclick = "";
         lblLbldepartamentoidfilter_Jsonclick = "";
         lblLblusuariosistematelefonofilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A99UsuarioSistemaId = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV17Linkselection_GXI = "";
         scmdbuf = "";
         lV6cUsuarioSistemaId = "";
         lV7cUsuarioSistemaNombre = "";
         lV8cUsuarioSistemaIdentidad = "";
         lV12cCentrodecostoId = "";
         A100UsuarioSistemaNombre = "";
         A101UsuarioSistemaIdentidad = "";
         A259CentrodecostoId = "";
         H00532_A260DepartamentoId = new short[1] ;
         H00532_A259CentrodecostoId = new string[] {""} ;
         H00532_A101UsuarioSistemaIdentidad = new string[] {""} ;
         H00532_A100UsuarioSistemaNombre = new string[] {""} ;
         H00532_A264UsuarioSistemaTelefono = new int[1] ;
         H00532_A258DireccionId = new short[1] ;
         H00532_A99UsuarioSistemaId = new string[] {""} ;
         H00533_AGRID1_nRecordCount = new long[1] ;
         AV10ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00b0__default(),
            new Object[][] {
                new Object[] {
               H00532_A260DepartamentoId, H00532_A259CentrodecostoId, H00532_A101UsuarioSistemaIdentidad, H00532_A100UsuarioSistemaNombre, H00532_A264UsuarioSistemaTelefono, H00532_A258DireccionId, H00532_A99UsuarioSistemaId
               }
               , new Object[] {
               H00533_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV11cDireccionId ;
      private short AV13cDepartamentoId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A258DireccionId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A260DepartamentoId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private int nRC_GXsfl_84 ;
      private int nGXsfl_84_idx=1 ;
      private int subGrid1_Rows ;
      private int AV14cUsuarioSistemaTelefono ;
      private int edtavCusuariosistemaid_Visible ;
      private int edtavCusuariosistemaid_Enabled ;
      private int edtavCusuariosistemanombre_Visible ;
      private int edtavCusuariosistemanombre_Enabled ;
      private int edtavCusuariosistemaidentidad_Visible ;
      private int edtavCusuariosistemaidentidad_Enabled ;
      private int edtavCdireccionid_Enabled ;
      private int edtavCdireccionid_Visible ;
      private int edtavCcentrodecostoid_Visible ;
      private int edtavCcentrodecostoid_Enabled ;
      private int edtavCdepartamentoid_Enabled ;
      private int edtavCdepartamentoid_Visible ;
      private int edtavCusuariosistematelefono_Enabled ;
      private int edtavCusuariosistematelefono_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A264UsuarioSistemaTelefono ;
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
      private string divUsuariosistemaidfiltercontainer_Class ;
      private string divUsuariosistemanombrefiltercontainer_Class ;
      private string divUsuariosistemaidentidadfiltercontainer_Class ;
      private string divDireccionidfiltercontainer_Class ;
      private string divCentrodecostoidfiltercontainer_Class ;
      private string divDepartamentoidfiltercontainer_Class ;
      private string divUsuariosistematelefonofiltercontainer_Class ;
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
      private string divUsuariosistemaidfiltercontainer_Internalname ;
      private string lblLblusuariosistemaidfilter_Internalname ;
      private string lblLblusuariosistemaidfilter_Jsonclick ;
      private string edtavCusuariosistemaid_Internalname ;
      private string TempTags ;
      private string edtavCusuariosistemaid_Jsonclick ;
      private string divUsuariosistemanombrefiltercontainer_Internalname ;
      private string lblLblusuariosistemanombrefilter_Internalname ;
      private string lblLblusuariosistemanombrefilter_Jsonclick ;
      private string edtavCusuariosistemanombre_Internalname ;
      private string edtavCusuariosistemanombre_Jsonclick ;
      private string divUsuariosistemaidentidadfiltercontainer_Internalname ;
      private string lblLblusuariosistemaidentidadfilter_Internalname ;
      private string lblLblusuariosistemaidentidadfilter_Jsonclick ;
      private string edtavCusuariosistemaidentidad_Internalname ;
      private string edtavCusuariosistemaidentidad_Jsonclick ;
      private string divDireccionidfiltercontainer_Internalname ;
      private string lblLbldireccionidfilter_Internalname ;
      private string lblLbldireccionidfilter_Jsonclick ;
      private string edtavCdireccionid_Internalname ;
      private string edtavCdireccionid_Jsonclick ;
      private string divCentrodecostoidfiltercontainer_Internalname ;
      private string lblLblcentrodecostoidfilter_Internalname ;
      private string lblLblcentrodecostoidfilter_Jsonclick ;
      private string edtavCcentrodecostoid_Internalname ;
      private string edtavCcentrodecostoid_Jsonclick ;
      private string divDepartamentoidfiltercontainer_Internalname ;
      private string lblLbldepartamentoidfilter_Internalname ;
      private string lblLbldepartamentoidfilter_Jsonclick ;
      private string edtavCdepartamentoid_Internalname ;
      private string edtavCdepartamentoid_Jsonclick ;
      private string divUsuariosistematelefonofiltercontainer_Internalname ;
      private string lblLblusuariosistematelefonofilter_Internalname ;
      private string lblLblusuariosistematelefonofilter_Jsonclick ;
      private string edtavCusuariosistematelefono_Internalname ;
      private string edtavCusuariosistematelefono_Jsonclick ;
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
      private string edtUsuarioSistemaId_Internalname ;
      private string edtDireccionId_Internalname ;
      private string edtUsuarioSistemaTelefono_Internalname ;
      private string scmdbuf ;
      private string AV10ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtUsuarioSistemaId_Jsonclick ;
      private string edtDireccionId_Jsonclick ;
      private string edtUsuarioSistemaTelefono_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV9pUsuarioSistemaId ;
      private string AV6cUsuarioSistemaId ;
      private string AV7cUsuarioSistemaNombre ;
      private string AV8cUsuarioSistemaIdentidad ;
      private string AV12cCentrodecostoId ;
      private string A99UsuarioSistemaId ;
      private string AV17Linkselection_GXI ;
      private string lV6cUsuarioSistemaId ;
      private string lV7cUsuarioSistemaNombre ;
      private string lV8cUsuarioSistemaIdentidad ;
      private string lV12cCentrodecostoId ;
      private string A100UsuarioSistemaNombre ;
      private string A101UsuarioSistemaIdentidad ;
      private string A259CentrodecostoId ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00532_A260DepartamentoId ;
      private string[] H00532_A259CentrodecostoId ;
      private string[] H00532_A101UsuarioSistemaIdentidad ;
      private string[] H00532_A100UsuarioSistemaNombre ;
      private int[] H00532_A264UsuarioSistemaTelefono ;
      private short[] H00532_A258DireccionId ;
      private string[] H00532_A99UsuarioSistemaId ;
      private long[] H00533_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private string aP0_pUsuarioSistemaId ;
      private GXWebForm Form ;
   }

   public class gx00b0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00532( IGxContext context ,
                                             string AV7cUsuarioSistemaNombre ,
                                             string AV8cUsuarioSistemaIdentidad ,
                                             short AV11cDireccionId ,
                                             string AV12cCentrodecostoId ,
                                             short AV13cDepartamentoId ,
                                             int AV14cUsuarioSistemaTelefono ,
                                             string A100UsuarioSistemaNombre ,
                                             string A101UsuarioSistemaIdentidad ,
                                             short A258DireccionId ,
                                             string A259CentrodecostoId ,
                                             short A260DepartamentoId ,
                                             int A264UsuarioSistemaTelefono ,
                                             string A99UsuarioSistemaId ,
                                             string AV6cUsuarioSistemaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [DepartamentoId], [CentrodecostoId], [UsuarioSistemaIdentidad], [UsuarioSistemaNombre], [UsuarioSistemaTelefono], [DireccionId], [UsuarioSistemaId]";
         sFromString = " FROM [UsuarioSistema]";
         sOrderString = "";
         AddWhere(sWhereString, "([UsuarioSistemaId] like @lV6cUsuarioSistemaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUsuarioSistemaNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaNombre] like @lV7cUsuarioSistemaNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cUsuarioSistemaIdentidad)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV8cUsuarioSistemaIdentidad)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV11cDireccionId) )
         {
            AddWhere(sWhereString, "([DireccionId] >= @AV11cDireccionId)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cCentrodecostoId)) )
         {
            AddWhere(sWhereString, "([CentrodecostoId] like @lV12cCentrodecostoId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV13cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV13cDepartamentoId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV14cUsuarioSistemaTelefono) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaTelefono] >= @AV14cUsuarioSistemaTelefono)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [UsuarioSistemaId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00533( IGxContext context ,
                                             string AV7cUsuarioSistemaNombre ,
                                             string AV8cUsuarioSistemaIdentidad ,
                                             short AV11cDireccionId ,
                                             string AV12cCentrodecostoId ,
                                             short AV13cDepartamentoId ,
                                             int AV14cUsuarioSistemaTelefono ,
                                             string A100UsuarioSistemaNombre ,
                                             string A101UsuarioSistemaIdentidad ,
                                             short A258DireccionId ,
                                             string A259CentrodecostoId ,
                                             short A260DepartamentoId ,
                                             int A264UsuarioSistemaTelefono ,
                                             string A99UsuarioSistemaId ,
                                             string AV6cUsuarioSistemaId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [UsuarioSistema]";
         AddWhere(sWhereString, "([UsuarioSistemaId] like @lV6cUsuarioSistemaId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUsuarioSistemaNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaNombre] like @lV7cUsuarioSistemaNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cUsuarioSistemaIdentidad)) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaIdentidad] like @lV8cUsuarioSistemaIdentidad)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV11cDireccionId) )
         {
            AddWhere(sWhereString, "([DireccionId] >= @AV11cDireccionId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12cCentrodecostoId)) )
         {
            AddWhere(sWhereString, "([CentrodecostoId] like @lV12cCentrodecostoId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV13cDepartamentoId) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV13cDepartamentoId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV14cUsuarioSistemaTelefono) )
         {
            AddWhere(sWhereString, "([UsuarioSistemaTelefono] >= @AV14cUsuarioSistemaTelefono)");
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
                     return conditional_H00532(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_H00533(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (int)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmH00532;
          prmH00532 = new Object[] {
          new ParDef("@lV6cUsuarioSistemaId",GXType.NVarChar,100,60) ,
          new ParDef("@lV7cUsuarioSistemaNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV8cUsuarioSistemaIdentidad",GXType.NVarChar,30,0) ,
          new ParDef("@AV11cDireccionId",GXType.Int16,4,0) ,
          new ParDef("@lV12cCentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@AV13cDepartamentoId",GXType.Int16,4,0) ,
          new ParDef("@AV14cUsuarioSistemaTelefono",GXType.Int32,9,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00533;
          prmH00533 = new Object[] {
          new ParDef("@lV6cUsuarioSistemaId",GXType.NVarChar,100,60) ,
          new ParDef("@lV7cUsuarioSistemaNombre",GXType.NVarChar,60,0) ,
          new ParDef("@lV8cUsuarioSistemaIdentidad",GXType.NVarChar,30,0) ,
          new ParDef("@AV11cDireccionId",GXType.Int16,4,0) ,
          new ParDef("@lV12cCentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@AV13cDepartamentoId",GXType.Int16,4,0) ,
          new ParDef("@AV14cUsuarioSistemaTelefono",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00532", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00532,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00533", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00533,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
