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
   public class gx00a0 : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public gx00a0( )
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

      public gx00a0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_pUsuarioId )
      {
         this.AV13pUsuarioId = 0 ;
         executePrivate();
         aP0_pUsuarioId=this.AV13pUsuarioId;
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
            gxfirstwebparm = GetFirstPar( "pUsuarioId");
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
               gxfirstwebparm = GetFirstPar( "pUsuarioId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pUsuarioId");
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
               AV6cUsuarioId = (long)(NumberUtil.Val( GetPar( "cUsuarioId"), "."));
               AV7cUsuarioNombre = GetPar( "cUsuarioNombre");
               AV8cUsuarioFecha = context.localUtil.ParseDateParm( GetPar( "cUsuarioFecha"));
               AV9cUsuarioHora = DateTimeUtil.ResetDate(context.localUtil.ParseDTimeParm( GetPar( "cUsuarioHora")));
               AV10cUsuarioEmail = GetPar( "cUsuarioEmail");
               AV11cUsuarioTelefono = (int)(NumberUtil.Val( GetPar( "cUsuarioTelefono"), "."));
               AV15cEstadoTicketUsuarioId = (short)(NumberUtil.Val( GetPar( "cEstadoTicketUsuarioId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioId, AV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, AV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId) ;
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
               AV13pUsuarioId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pUsuarioId", StringUtil.LTrimStr( (decimal)(AV13pUsuarioId), 10, 0));
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
            return "gx00a0_Execute" ;
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
         PA0F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0F2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188224536", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pUsuarioId,10,0))}, new string[] {"pUsuarioId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIONOMBRE", AV7cUsuarioNombre);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOFECHA", context.localUtil.Format(AV8cUsuarioFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOHORA", context.localUtil.TToC( AV9cUsuarioHora, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOEMAIL", AV10cUsuarioEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCUSUARIOTELEFONO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cUsuarioTelefono), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCESTADOTICKETUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cEstadoTicketUsuarioId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pUsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarioidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIONOMBREFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarionombrefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOFECHAFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariofechafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOHORAFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariohorafiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divUsuarioemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "USUARIOTELEFONOFILTERCONTAINER_Class", StringUtil.RTrim( divUsuariotelefonofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "ESTADOTICKETUSUARIOIDFILTERCONTAINER_Class", StringUtil.RTrim( divEstadoticketusuarioidfiltercontainer_Class));
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
            WE0F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0F2( ) ;
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
         return formatLink("gx00a0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pUsuarioId,10,0))}, new string[] {"pUsuarioId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00A0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Usuario" ;
      }

      protected void WB0F0( )
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
            GxWebStd.gx_div_start( context, divUsuarioidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarioidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarioidfilter_Internalname, "Id Usuario", "", "", lblLblusuarioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cUsuarioId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavCusuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cUsuarioId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV6cUsuarioId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarioid_Visible, edtavCusuarioid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divUsuarionombrefiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarionombrefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarionombrefilter_Internalname, "Usuario", "", "", lblLblusuarionombrefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuarionombre_Internalname, "Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarionombre_Internalname, AV7cUsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV7cUsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarionombre_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarionombre_Visible, edtavCusuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divUsuariofechafiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariofechafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariofechafilter_Internalname, "Fecha", "", "", lblLblusuariofechafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130f1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariofecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCusuariofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCusuariofecha_Internalname, context.localUtil.Format(AV8cUsuarioFecha, "99/99/9999"), context.localUtil.Format( AV8cUsuarioFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusuariofecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divUsuariohorafiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariohorafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariohorafilter_Internalname, "Hora", "", "", lblLblusuariohorafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140f1_client"+"'", "", "WWAdvancedLabel WWDateFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariohora_Internalname, "Hora", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCusuariohora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCusuariohora_Internalname, context.localUtil.TToC( AV9cUsuarioHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV9cUsuarioHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariohora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCusuariohora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divUsuarioemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuarioemailfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuarioemailfilter_Internalname, "Email", "", "", lblLblusuarioemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuarioemail_Internalname, "Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuarioemail_Internalname, AV10cUsuarioEmail, StringUtil.RTrim( context.localUtil.Format( AV10cUsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuarioemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuarioemail_Visible, edtavCusuarioemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divUsuariotelefonofiltercontainer_Internalname, 1, 0, "px", 0, "px", divUsuariotelefonofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblusuariotelefonofilter_Internalname, "Teléfono", "", "", lblLblusuariotelefonofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCusuariotelefono_Internalname, "Teléfono", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCusuariotelefono_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cUsuarioTelefono), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCusuariotelefono_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cUsuarioTelefono), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV11cUsuarioTelefono), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCusuariotelefono_Jsonclick, 0, "Attribute", "", "", "", "", edtavCusuariotelefono_Visible, edtavCusuariotelefono_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_div_start( context, divEstadoticketusuarioidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divEstadoticketusuarioidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblestadoticketusuarioidfilter_Internalname, "Estado Id", "", "", lblLblestadoticketusuarioidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e170f1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00A0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCestadoticketusuarioid_Internalname, "Estado Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCestadoticketusuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cEstadoTicketUsuarioId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCestadoticketusuarioid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV15cEstadoTicketUsuarioId), "ZZZ9") : context.localUtil.Format( (decimal)(AV15cEstadoTicketUsuarioId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCestadoticketusuarioid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCestadoticketusuarioid_Visible, edtavCestadoticketusuarioid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Gx00A0.htm");
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
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e180f1_client"+"'", TempTags, "", 2, "HLP_Gx00A0.htm");
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
               context.SendWebValue( "Id Usuario:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Usuario:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Fecha Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora Inicio:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Teléfono:") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Hora Usuario") ;
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
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A93UsuarioNombre);
               Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtUsuarioNombre_Link));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.localUtil.TToC( A286UsuarioFechaHora, 10, 8, 0, 3, "/", ":", " "));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00A0.htm");
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

      protected void START0F2( )
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
            Form.Meta.addItem("description", "Selection List Usuario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
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
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV18Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
                              A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
                              A90UsuarioFecha = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtUsuarioFecha_Internalname), 0));
                              A92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtUsuarioHora_Internalname), 0));
                              A95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ".", ","));
                              A189EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketUsuarioId_Internalname), ".", ","));
                              A286UsuarioFechaHora = context.localUtil.CToT( cgiGet( edtUsuarioFechaHora_Internalname), 0);
                              n286UsuarioFechaHora = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E190F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cusuarioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOID"), ".", ",") != Convert.ToDecimal( AV6cUsuarioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuarionombre Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIONOMBRE"), AV7cUsuarioNombre) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariofecha Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUSUARIOFECHA"), 0) != AV8cUsuarioFecha )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariohora Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCUSUARIOHORA"), 0) != AV9cUsuarioHora )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuarioemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOEMAIL"), AV10cUsuarioEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cusuariotelefono Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOTELEFONO"), ".", ",") != Convert.ToDecimal( AV11cUsuarioTelefono )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cestadoticketusuarioid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADOTICKETUSUARIOID"), ".", ",") != Convert.ToDecimal( AV15cEstadoTicketUsuarioId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E210F2 ();
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

      protected void WE0F2( )
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

      protected void PA0F2( )
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
                                        long AV6cUsuarioId ,
                                        string AV7cUsuarioNombre ,
                                        DateTime AV8cUsuarioFecha ,
                                        DateTime AV9cUsuarioHora ,
                                        string AV10cUsuarioEmail ,
                                        int AV11cUsuarioTelefono ,
                                        short AV15cEstadoTicketUsuarioId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
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
         RF0F2( ) ;
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

      protected void RF0F2( )
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
                                                 AV7cUsuarioNombre ,
                                                 AV8cUsuarioFecha ,
                                                 AV9cUsuarioHora ,
                                                 AV10cUsuarioEmail ,
                                                 AV11cUsuarioTelefono ,
                                                 AV15cEstadoTicketUsuarioId ,
                                                 A93UsuarioNombre ,
                                                 A90UsuarioFecha ,
                                                 A92UsuarioHora ,
                                                 A89UsuarioEmail ,
                                                 A95UsuarioTelefono ,
                                                 A189EstadoTicketUsuarioId ,
                                                 AV6cUsuarioId } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG
                                                 }
            });
            lV7cUsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV7cUsuarioNombre), "%", "");
            lV10cUsuarioEmail = StringUtil.Concat( StringUtil.RTrim( AV10cUsuarioEmail), "%", "");
            /* Using cursor H000F2 */
            pr_default.execute(0, new Object[] {AV6cUsuarioId, lV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, lV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A89UsuarioEmail = H000F2_A89UsuarioEmail[0];
               A286UsuarioFechaHora = H000F2_A286UsuarioFechaHora[0];
               n286UsuarioFechaHora = H000F2_n286UsuarioFechaHora[0];
               A189EstadoTicketUsuarioId = H000F2_A189EstadoTicketUsuarioId[0];
               A95UsuarioTelefono = H000F2_A95UsuarioTelefono[0];
               A92UsuarioHora = H000F2_A92UsuarioHora[0];
               A90UsuarioFecha = H000F2_A90UsuarioFecha[0];
               A93UsuarioNombre = H000F2_A93UsuarioNombre[0];
               A15UsuarioId = H000F2_A15UsuarioId[0];
               /* Execute user event: Load */
               E200F2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB0F0( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_USUARIOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9"), context));
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
                                              AV7cUsuarioNombre ,
                                              AV8cUsuarioFecha ,
                                              AV9cUsuarioHora ,
                                              AV10cUsuarioEmail ,
                                              AV11cUsuarioTelefono ,
                                              AV15cEstadoTicketUsuarioId ,
                                              A93UsuarioNombre ,
                                              A90UsuarioFecha ,
                                              A92UsuarioHora ,
                                              A89UsuarioEmail ,
                                              A95UsuarioTelefono ,
                                              A189EstadoTicketUsuarioId ,
                                              AV6cUsuarioId } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG
                                              }
         });
         lV7cUsuarioNombre = StringUtil.Concat( StringUtil.RTrim( AV7cUsuarioNombre), "%", "");
         lV10cUsuarioEmail = StringUtil.Concat( StringUtil.RTrim( AV10cUsuarioEmail), "%", "");
         /* Using cursor H000F3 */
         pr_default.execute(1, new Object[] {AV6cUsuarioId, lV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, lV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId});
         GRID1_nRecordCount = H000F3_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioId, AV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, AV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioId, AV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, AV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioId, AV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, AV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioId, AV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, AV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cUsuarioId, AV7cUsuarioNombre, AV8cUsuarioFecha, AV9cUsuarioHora, AV10cUsuarioEmail, AV11cUsuarioTelefono, AV15cEstadoTicketUsuarioId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E190F2 ();
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuarioid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuarioid_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOID");
               GX_FocusControl = edtavCusuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cUsuarioId = 0;
               AssignAttri("", false, "AV6cUsuarioId", StringUtil.LTrimStr( (decimal)(AV6cUsuarioId), 10, 0));
            }
            else
            {
               AV6cUsuarioId = (long)(context.localUtil.CToN( cgiGet( edtavCusuarioid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cUsuarioId", StringUtil.LTrimStr( (decimal)(AV6cUsuarioId), 10, 0));
            }
            AV7cUsuarioNombre = cgiGet( edtavCusuarionombre_Internalname);
            AssignAttri("", false, "AV7cUsuarioNombre", AV7cUsuarioNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavCusuariofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "vCUSUARIOFECHA");
               GX_FocusControl = edtavCusuariofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV8cUsuarioFecha = DateTime.MinValue;
               AssignAttri("", false, "AV8cUsuarioFecha", context.localUtil.Format(AV8cUsuarioFecha, "99/99/9999"));
            }
            else
            {
               AV8cUsuarioFecha = context.localUtil.CToD( cgiGet( edtavCusuariofecha_Internalname), 2);
               AssignAttri("", false, "AV8cUsuarioFecha", context.localUtil.Format(AV8cUsuarioFecha, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCusuariohora_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "vCUSUARIOHORA");
               GX_FocusControl = edtavCusuariohora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cUsuarioHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV9cUsuarioHora", context.localUtil.TToC( AV9cUsuarioHora, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               AV9cUsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtavCusuariohora_Internalname)));
               AssignAttri("", false, "AV9cUsuarioHora", context.localUtil.TToC( AV9cUsuarioHora, 0, 5, 0, 3, "/", ":", " "));
            }
            AV10cUsuarioEmail = cgiGet( edtavCusuarioemail_Internalname);
            AssignAttri("", false, "AV10cUsuarioEmail", AV10cUsuarioEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCusuariotelefono_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCusuariotelefono_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCUSUARIOTELEFONO");
               GX_FocusControl = edtavCusuariotelefono_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cUsuarioTelefono = 0;
               AssignAttri("", false, "AV11cUsuarioTelefono", StringUtil.LTrimStr( (decimal)(AV11cUsuarioTelefono), 9, 0));
            }
            else
            {
               AV11cUsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtavCusuariotelefono_Internalname), ".", ","));
               AssignAttri("", false, "AV11cUsuarioTelefono", StringUtil.LTrimStr( (decimal)(AV11cUsuarioTelefono), 9, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCestadoticketusuarioid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCestadoticketusuarioid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCESTADOTICKETUSUARIOID");
               GX_FocusControl = edtavCestadoticketusuarioid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV15cEstadoTicketUsuarioId = 0;
               AssignAttri("", false, "AV15cEstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(AV15cEstadoTicketUsuarioId), 4, 0));
            }
            else
            {
               AV15cEstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( edtavCestadoticketusuarioid_Internalname), ".", ","));
               AssignAttri("", false, "AV15cEstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(AV15cEstadoTicketUsuarioId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOID"), ".", ",") != Convert.ToDecimal( AV6cUsuarioId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIONOMBRE"), AV7cUsuarioNombre) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCUSUARIOFECHA"), 2) ) != DateTimeUtil.ResetTime ( AV8cUsuarioFecha ) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToT( cgiGet( "GXH_vCUSUARIOHORA")) != AV9cUsuarioHora )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCUSUARIOEMAIL"), AV10cUsuarioEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCUSUARIOTELEFONO"), ".", ",") != Convert.ToDecimal( AV11cUsuarioTelefono )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCESTADOTICKETUSUARIOID"), ".", ",") != Convert.ToDecimal( AV15cEstadoTicketUsuarioId )) )
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
         E190F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E190F2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Lista de Selección %1", "Usuario", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E200F2( )
      {
         /* Load Routine */
         returnInSub = false;
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV18Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
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
         E210F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E210F2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pUsuarioId = A15UsuarioId;
         AssignAttri("", false, "AV13pUsuarioId", StringUtil.LTrimStr( (decimal)(AV13pUsuarioId), 10, 0));
         context.setWebReturnParms(new Object[] {(long)AV13pUsuarioId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pUsuarioId"});
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
         AV13pUsuarioId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV13pUsuarioId", StringUtil.LTrimStr( (decimal)(AV13pUsuarioId), 10, 0));
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
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188224632", true, true);
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
         context.AddJavascriptSource("gx00a0.js", "?2024188224632", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_84_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_84_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_84_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_84_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_84_idx;
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID_"+sGXsfl_84_idx;
         edtUsuarioFechaHora_Internalname = "USUARIOFECHAHORA_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtUsuarioId_Internalname = "USUARIOID_"+sGXsfl_84_fel_idx;
         edtUsuarioNombre_Internalname = "USUARIONOMBRE_"+sGXsfl_84_fel_idx;
         edtUsuarioFecha_Internalname = "USUARIOFECHA_"+sGXsfl_84_fel_idx;
         edtUsuarioHora_Internalname = "USUARIOHORA_"+sGXsfl_84_fel_idx;
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO_"+sGXsfl_84_fel_idx;
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID_"+sGXsfl_84_fel_idx;
         edtUsuarioFechaHora_Internalname = "USUARIOFECHAHORA_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB0F0( ) ;
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
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
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
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMax",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtUsuarioNombre_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioNombre_Internalname,(string)A93UsuarioNombre,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtUsuarioNombre_Link,(string)"",(string)"",(string)"",(string)edtUsuarioNombre_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFecha_Internalname,context.localUtil.Format(A90UsuarioFecha, "99/99/9999"),context.localUtil.Format( A90UsuarioFecha, "99/99/9999"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFecha_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioHora_Internalname,context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A92UsuarioHora, "99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioTelefono_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioTelefono_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)9,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"Telefono",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketUsuarioId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A189EstadoTicketUsuarioId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketUsuarioId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuarioFechaHora_Internalname,context.localUtil.TToC( A286UsuarioFechaHora, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A286UsuarioFechaHora, "99/99/9999 99:99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuarioFechaHora_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)19,(short)0,(short)0,(short)84,(short)1,(short)-1,(short)0,(bool)true,(string)"FechaHora",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0F2( ) ;
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
         lblLblusuarioidfilter_Internalname = "LBLUSUARIOIDFILTER";
         edtavCusuarioid_Internalname = "vCUSUARIOID";
         divUsuarioidfiltercontainer_Internalname = "USUARIOIDFILTERCONTAINER";
         lblLblusuarionombrefilter_Internalname = "LBLUSUARIONOMBREFILTER";
         edtavCusuarionombre_Internalname = "vCUSUARIONOMBRE";
         divUsuarionombrefiltercontainer_Internalname = "USUARIONOMBREFILTERCONTAINER";
         lblLblusuariofechafilter_Internalname = "LBLUSUARIOFECHAFILTER";
         edtavCusuariofecha_Internalname = "vCUSUARIOFECHA";
         divUsuariofechafiltercontainer_Internalname = "USUARIOFECHAFILTERCONTAINER";
         lblLblusuariohorafilter_Internalname = "LBLUSUARIOHORAFILTER";
         edtavCusuariohora_Internalname = "vCUSUARIOHORA";
         divUsuariohorafiltercontainer_Internalname = "USUARIOHORAFILTERCONTAINER";
         lblLblusuarioemailfilter_Internalname = "LBLUSUARIOEMAILFILTER";
         edtavCusuarioemail_Internalname = "vCUSUARIOEMAIL";
         divUsuarioemailfiltercontainer_Internalname = "USUARIOEMAILFILTERCONTAINER";
         lblLblusuariotelefonofilter_Internalname = "LBLUSUARIOTELEFONOFILTER";
         edtavCusuariotelefono_Internalname = "vCUSUARIOTELEFONO";
         divUsuariotelefonofiltercontainer_Internalname = "USUARIOTELEFONOFILTERCONTAINER";
         lblLblestadoticketusuarioidfilter_Internalname = "LBLESTADOTICKETUSUARIOIDFILTER";
         edtavCestadoticketusuarioid_Internalname = "vCESTADOTICKETUSUARIOID";
         divEstadoticketusuarioidfiltercontainer_Internalname = "ESTADOTICKETUSUARIOIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioFecha_Internalname = "USUARIOFECHA";
         edtUsuarioHora_Internalname = "USUARIOHORA";
         edtUsuarioTelefono_Internalname = "USUARIOTELEFONO";
         edtEstadoTicketUsuarioId_Internalname = "ESTADOTICKETUSUARIOID";
         edtUsuarioFechaHora_Internalname = "USUARIOFECHAHORA";
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
         edtUsuarioFechaHora_Jsonclick = "";
         edtEstadoTicketUsuarioId_Jsonclick = "";
         edtUsuarioTelefono_Jsonclick = "";
         edtUsuarioHora_Jsonclick = "";
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioId_Jsonclick = "";
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtUsuarioNombre_Link = "";
         edtavLinkselection_Link = "";
         subGrid1_Header = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCestadoticketusuarioid_Jsonclick = "";
         edtavCestadoticketusuarioid_Enabled = 1;
         edtavCestadoticketusuarioid_Visible = 1;
         edtavCusuariotelefono_Jsonclick = "";
         edtavCusuariotelefono_Enabled = 1;
         edtavCusuariotelefono_Visible = 1;
         edtavCusuarioemail_Jsonclick = "";
         edtavCusuarioemail_Enabled = 1;
         edtavCusuarioemail_Visible = 1;
         edtavCusuariohora_Jsonclick = "";
         edtavCusuariohora_Enabled = 1;
         edtavCusuariofecha_Jsonclick = "";
         edtavCusuariofecha_Enabled = 1;
         edtavCusuarionombre_Jsonclick = "";
         edtavCusuarionombre_Enabled = 1;
         edtavCusuarionombre_Visible = 1;
         edtavCusuarioid_Jsonclick = "";
         edtavCusuarioid_Enabled = 1;
         edtavCusuarioid_Visible = 1;
         divEstadoticketusuarioidfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariotelefonofiltercontainer_Class = "AdvancedContainerItem";
         divUsuarioemailfiltercontainer_Class = "AdvancedContainerItem";
         divUsuariohorafiltercontainer_Class = "AdvancedContainerItem";
         divUsuariofechafiltercontainer_Class = "AdvancedContainerItem";
         divUsuarionombrefiltercontainer_Class = "AdvancedContainerItem";
         divUsuarioidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Usuario";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV7cUsuarioNombre',fld:'vCUSUARIONOMBRE',pic:''},{av:'AV8cUsuarioFecha',fld:'vCUSUARIOFECHA',pic:''},{av:'AV9cUsuarioHora',fld:'vCUSUARIOHORA',pic:'99:99'},{av:'AV10cUsuarioEmail',fld:'vCUSUARIOEMAIL',pic:''},{av:'AV11cUsuarioTelefono',fld:'vCUSUARIOTELEFONO',pic:'ZZZZZZZZ9'},{av:'AV15cEstadoTicketUsuarioId',fld:'vCESTADOTICKETUSUARIOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E180F1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOIDFILTER.CLICK","{handler:'E110F1',iparms:[{av:'divUsuarioidfiltercontainer_Class',ctrl:'USUARIOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOIDFILTER.CLICK",",oparms:[{av:'divUsuarioidfiltercontainer_Class',ctrl:'USUARIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarioid_Visible',ctrl:'vCUSUARIOID',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIONOMBREFILTER.CLICK","{handler:'E120F1',iparms:[{av:'divUsuarionombrefiltercontainer_Class',ctrl:'USUARIONOMBREFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIONOMBREFILTER.CLICK",",oparms:[{av:'divUsuarionombrefiltercontainer_Class',ctrl:'USUARIONOMBREFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarionombre_Visible',ctrl:'vCUSUARIONOMBRE',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOFECHAFILTER.CLICK","{handler:'E130F1',iparms:[{av:'divUsuariofechafiltercontainer_Class',ctrl:'USUARIOFECHAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOFECHAFILTER.CLICK",",oparms:[{av:'divUsuariofechafiltercontainer_Class',ctrl:'USUARIOFECHAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOHORAFILTER.CLICK","{handler:'E140F1',iparms:[{av:'divUsuariohorafiltercontainer_Class',ctrl:'USUARIOHORAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOHORAFILTER.CLICK",",oparms:[{av:'divUsuariohorafiltercontainer_Class',ctrl:'USUARIOHORAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("LBLUSUARIOEMAILFILTER.CLICK","{handler:'E150F1',iparms:[{av:'divUsuarioemailfiltercontainer_Class',ctrl:'USUARIOEMAILFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOEMAILFILTER.CLICK",",oparms:[{av:'divUsuarioemailfiltercontainer_Class',ctrl:'USUARIOEMAILFILTERCONTAINER',prop:'Class'},{av:'edtavCusuarioemail_Visible',ctrl:'vCUSUARIOEMAIL',prop:'Visible'}]}");
         setEventMetadata("LBLUSUARIOTELEFONOFILTER.CLICK","{handler:'E160F1',iparms:[{av:'divUsuariotelefonofiltercontainer_Class',ctrl:'USUARIOTELEFONOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLUSUARIOTELEFONOFILTER.CLICK",",oparms:[{av:'divUsuariotelefonofiltercontainer_Class',ctrl:'USUARIOTELEFONOFILTERCONTAINER',prop:'Class'},{av:'edtavCusuariotelefono_Visible',ctrl:'vCUSUARIOTELEFONO',prop:'Visible'}]}");
         setEventMetadata("LBLESTADOTICKETUSUARIOIDFILTER.CLICK","{handler:'E170F1',iparms:[{av:'divEstadoticketusuarioidfiltercontainer_Class',ctrl:'ESTADOTICKETUSUARIOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLESTADOTICKETUSUARIOIDFILTER.CLICK",",oparms:[{av:'divEstadoticketusuarioidfiltercontainer_Class',ctrl:'ESTADOTICKETUSUARIOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCestadoticketusuarioid_Visible',ctrl:'vCESTADOTICKETUSUARIOID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E210F2',iparms:[{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pUsuarioId',fld:'vPUSUARIOID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV7cUsuarioNombre',fld:'vCUSUARIONOMBRE',pic:''},{av:'AV8cUsuarioFecha',fld:'vCUSUARIOFECHA',pic:''},{av:'AV9cUsuarioHora',fld:'vCUSUARIOHORA',pic:'99:99'},{av:'AV10cUsuarioEmail',fld:'vCUSUARIOEMAIL',pic:''},{av:'AV11cUsuarioTelefono',fld:'vCUSUARIOTELEFONO',pic:'ZZZZZZZZ9'},{av:'AV15cEstadoTicketUsuarioId',fld:'vCESTADOTICKETUSUARIOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV7cUsuarioNombre',fld:'vCUSUARIONOMBRE',pic:''},{av:'AV8cUsuarioFecha',fld:'vCUSUARIOFECHA',pic:''},{av:'AV9cUsuarioHora',fld:'vCUSUARIOHORA',pic:'99:99'},{av:'AV10cUsuarioEmail',fld:'vCUSUARIOEMAIL',pic:''},{av:'AV11cUsuarioTelefono',fld:'vCUSUARIOTELEFONO',pic:'ZZZZZZZZ9'},{av:'AV15cEstadoTicketUsuarioId',fld:'vCESTADOTICKETUSUARIOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV7cUsuarioNombre',fld:'vCUSUARIONOMBRE',pic:''},{av:'AV8cUsuarioFecha',fld:'vCUSUARIOFECHA',pic:''},{av:'AV9cUsuarioHora',fld:'vCUSUARIOHORA',pic:'99:99'},{av:'AV10cUsuarioEmail',fld:'vCUSUARIOEMAIL',pic:''},{av:'AV11cUsuarioTelefono',fld:'vCUSUARIOTELEFONO',pic:'ZZZZZZZZ9'},{av:'AV15cEstadoTicketUsuarioId',fld:'vCESTADOTICKETUSUARIOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cUsuarioId',fld:'vCUSUARIOID',pic:'ZZZZZZZZZ9'},{av:'AV7cUsuarioNombre',fld:'vCUSUARIONOMBRE',pic:''},{av:'AV8cUsuarioFecha',fld:'vCUSUARIOFECHA',pic:''},{av:'AV9cUsuarioHora',fld:'vCUSUARIOHORA',pic:'99:99'},{av:'AV10cUsuarioEmail',fld:'vCUSUARIOEMAIL',pic:''},{av:'AV11cUsuarioTelefono',fld:'vCUSUARIOTELEFONO',pic:'ZZZZZZZZ9'},{av:'AV15cEstadoTicketUsuarioId',fld:'vCESTADOTICKETUSUARIOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CUSUARIOFECHA","{handler:'Validv_Cusuariofecha',iparms:[]");
         setEventMetadata("VALIDV_CUSUARIOFECHA",",oparms:[]}");
         setEventMetadata("VALIDV_CUSUARIOEMAIL","{handler:'Validv_Cusuarioemail',iparms:[]");
         setEventMetadata("VALIDV_CUSUARIOEMAIL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Usuariofechahora',iparms:[]");
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
         AV7cUsuarioNombre = "";
         AV8cUsuarioFecha = DateTime.MinValue;
         AV9cUsuarioHora = (DateTime)(DateTime.MinValue);
         AV10cUsuarioEmail = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblusuarioidfilter_Jsonclick = "";
         TempTags = "";
         lblLblusuarionombrefilter_Jsonclick = "";
         lblLblusuariofechafilter_Jsonclick = "";
         lblLblusuariohorafilter_Jsonclick = "";
         lblLblusuarioemailfilter_Jsonclick = "";
         lblLblusuariotelefonofilter_Jsonclick = "";
         lblLblestadoticketusuarioidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         AV5LinkSelection = "";
         A93UsuarioNombre = "";
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A286UsuarioFechaHora = (DateTime)(DateTime.MinValue);
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV18Linkselection_GXI = "";
         scmdbuf = "";
         lV7cUsuarioNombre = "";
         lV10cUsuarioEmail = "";
         A89UsuarioEmail = "";
         H000F2_A89UsuarioEmail = new string[] {""} ;
         H000F2_A286UsuarioFechaHora = new DateTime[] {DateTime.MinValue} ;
         H000F2_n286UsuarioFechaHora = new bool[] {false} ;
         H000F2_A189EstadoTicketUsuarioId = new short[1] ;
         H000F2_A95UsuarioTelefono = new int[1] ;
         H000F2_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         H000F2_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         H000F2_A93UsuarioNombre = new string[] {""} ;
         H000F2_A15UsuarioId = new long[1] ;
         H000F3_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sImgUrl = "";
         ROClassString = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00a0__default(),
            new Object[][] {
                new Object[] {
               H000F2_A89UsuarioEmail, H000F2_A286UsuarioFechaHora, H000F2_n286UsuarioFechaHora, H000F2_A189EstadoTicketUsuarioId, H000F2_A95UsuarioTelefono, H000F2_A92UsuarioHora, H000F2_A90UsuarioFecha, H000F2_A93UsuarioNombre, H000F2_A15UsuarioId
               }
               , new Object[] {
               H000F3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15cEstadoTicketUsuarioId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A189EstadoTicketUsuarioId ;
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
      private int AV11cUsuarioTelefono ;
      private int edtavCusuarioid_Enabled ;
      private int edtavCusuarioid_Visible ;
      private int edtavCusuarionombre_Visible ;
      private int edtavCusuarionombre_Enabled ;
      private int edtavCusuariofecha_Enabled ;
      private int edtavCusuariohora_Enabled ;
      private int edtavCusuarioemail_Visible ;
      private int edtavCusuarioemail_Enabled ;
      private int edtavCusuariotelefono_Enabled ;
      private int edtavCusuariotelefono_Visible ;
      private int edtavCestadoticketusuarioid_Enabled ;
      private int edtavCestadoticketusuarioid_Visible ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int A95UsuarioTelefono ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long AV13pUsuarioId ;
      private long GRID1_nFirstRecordOnPage ;
      private long AV6cUsuarioId ;
      private long A15UsuarioId ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divUsuarioidfiltercontainer_Class ;
      private string divUsuarionombrefiltercontainer_Class ;
      private string divUsuariofechafiltercontainer_Class ;
      private string divUsuariohorafiltercontainer_Class ;
      private string divUsuarioemailfiltercontainer_Class ;
      private string divUsuariotelefonofiltercontainer_Class ;
      private string divEstadoticketusuarioidfiltercontainer_Class ;
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
      private string divUsuarioidfiltercontainer_Internalname ;
      private string lblLblusuarioidfilter_Internalname ;
      private string lblLblusuarioidfilter_Jsonclick ;
      private string edtavCusuarioid_Internalname ;
      private string TempTags ;
      private string edtavCusuarioid_Jsonclick ;
      private string divUsuarionombrefiltercontainer_Internalname ;
      private string lblLblusuarionombrefilter_Internalname ;
      private string lblLblusuarionombrefilter_Jsonclick ;
      private string edtavCusuarionombre_Internalname ;
      private string edtavCusuarionombre_Jsonclick ;
      private string divUsuariofechafiltercontainer_Internalname ;
      private string lblLblusuariofechafilter_Internalname ;
      private string lblLblusuariofechafilter_Jsonclick ;
      private string edtavCusuariofecha_Internalname ;
      private string edtavCusuariofecha_Jsonclick ;
      private string divUsuariohorafiltercontainer_Internalname ;
      private string lblLblusuariohorafilter_Internalname ;
      private string lblLblusuariohorafilter_Jsonclick ;
      private string edtavCusuariohora_Internalname ;
      private string edtavCusuariohora_Jsonclick ;
      private string divUsuarioemailfiltercontainer_Internalname ;
      private string lblLblusuarioemailfilter_Internalname ;
      private string lblLblusuarioemailfilter_Jsonclick ;
      private string edtavCusuarioemail_Internalname ;
      private string edtavCusuarioemail_Jsonclick ;
      private string divUsuariotelefonofiltercontainer_Internalname ;
      private string lblLblusuariotelefonofilter_Internalname ;
      private string lblLblusuariotelefonofilter_Jsonclick ;
      private string edtavCusuariotelefono_Internalname ;
      private string edtavCusuariotelefono_Jsonclick ;
      private string divEstadoticketusuarioidfiltercontainer_Internalname ;
      private string lblLblestadoticketusuarioidfilter_Internalname ;
      private string lblLblestadoticketusuarioidfilter_Jsonclick ;
      private string edtavCestadoticketusuarioid_Internalname ;
      private string edtavCestadoticketusuarioid_Jsonclick ;
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
      private string edtUsuarioNombre_Link ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioHora_Internalname ;
      private string edtUsuarioTelefono_Internalname ;
      private string edtEstadoTicketUsuarioId_Internalname ;
      private string edtUsuarioFechaHora_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioFecha_Jsonclick ;
      private string edtUsuarioHora_Jsonclick ;
      private string edtUsuarioTelefono_Jsonclick ;
      private string edtEstadoTicketUsuarioId_Jsonclick ;
      private string edtUsuarioFechaHora_Jsonclick ;
      private DateTime AV9cUsuarioHora ;
      private DateTime A92UsuarioHora ;
      private DateTime A286UsuarioFechaHora ;
      private DateTime AV8cUsuarioFecha ;
      private DateTime A90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool n286UsuarioFechaHora ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cUsuarioNombre ;
      private string AV10cUsuarioEmail ;
      private string A93UsuarioNombre ;
      private string AV18Linkselection_GXI ;
      private string lV7cUsuarioNombre ;
      private string lV10cUsuarioEmail ;
      private string A89UsuarioEmail ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000F2_A89UsuarioEmail ;
      private DateTime[] H000F2_A286UsuarioFechaHora ;
      private bool[] H000F2_n286UsuarioFechaHora ;
      private short[] H000F2_A189EstadoTicketUsuarioId ;
      private int[] H000F2_A95UsuarioTelefono ;
      private DateTime[] H000F2_A92UsuarioHora ;
      private DateTime[] H000F2_A90UsuarioFecha ;
      private string[] H000F2_A93UsuarioNombre ;
      private long[] H000F2_A15UsuarioId ;
      private long[] H000F3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long aP0_pUsuarioId ;
      private GXWebForm Form ;
   }

   public class gx00a0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000F2( IGxContext context ,
                                             string AV7cUsuarioNombre ,
                                             DateTime AV8cUsuarioFecha ,
                                             DateTime AV9cUsuarioHora ,
                                             string AV10cUsuarioEmail ,
                                             int AV11cUsuarioTelefono ,
                                             short AV15cEstadoTicketUsuarioId ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             DateTime A92UsuarioHora ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short A189EstadoTicketUsuarioId ,
                                             long AV6cUsuarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [UsuarioEmail], [UsuarioFechaHora], [EstadoTicketUsuarioId], [UsuarioTelefono], [UsuarioHora], [UsuarioFecha], [UsuarioNombre], [UsuarioId]";
         sFromString = " FROM [Usuario]";
         sOrderString = "";
         AddWhere(sWhereString, "([UsuarioId] >= @AV6cUsuarioId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV7cUsuarioNombre)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cUsuarioFecha) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV8cUsuarioFecha)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cUsuarioHora) )
         {
            AddWhere(sWhereString, "([UsuarioHora] >= @AV9cUsuarioHora)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cUsuarioEmail)) )
         {
            AddWhere(sWhereString, "([UsuarioEmail] like @lV10cUsuarioEmail)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cUsuarioTelefono) )
         {
            AddWhere(sWhereString, "([UsuarioTelefono] >= @AV11cUsuarioTelefono)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV15cEstadoTicketUsuarioId) )
         {
            AddWhere(sWhereString, "([EstadoTicketUsuarioId] >= @AV15cEstadoTicketUsuarioId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [UsuarioId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000F3( IGxContext context ,
                                             string AV7cUsuarioNombre ,
                                             DateTime AV8cUsuarioFecha ,
                                             DateTime AV9cUsuarioHora ,
                                             string AV10cUsuarioEmail ,
                                             int AV11cUsuarioTelefono ,
                                             short AV15cEstadoTicketUsuarioId ,
                                             string A93UsuarioNombre ,
                                             DateTime A90UsuarioFecha ,
                                             DateTime A92UsuarioHora ,
                                             string A89UsuarioEmail ,
                                             int A95UsuarioTelefono ,
                                             short A189EstadoTicketUsuarioId ,
                                             long AV6cUsuarioId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Usuario]";
         AddWhere(sWhereString, "([UsuarioId] >= @AV6cUsuarioId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cUsuarioNombre)) )
         {
            AddWhere(sWhereString, "([UsuarioNombre] like @lV7cUsuarioNombre)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8cUsuarioFecha) )
         {
            AddWhere(sWhereString, "([UsuarioFecha] >= @AV8cUsuarioFecha)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV9cUsuarioHora) )
         {
            AddWhere(sWhereString, "([UsuarioHora] >= @AV9cUsuarioHora)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV10cUsuarioEmail)) )
         {
            AddWhere(sWhereString, "([UsuarioEmail] like @lV10cUsuarioEmail)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cUsuarioTelefono) )
         {
            AddWhere(sWhereString, "([UsuarioTelefono] >= @AV11cUsuarioTelefono)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV15cEstadoTicketUsuarioId) )
         {
            AddWhere(sWhereString, "([EstadoTicketUsuarioId] >= @AV15cEstadoTicketUsuarioId)");
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
                     return conditional_H000F2(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
               case 1 :
                     return conditional_H000F3(context, (string)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] , (string)dynConstraints[3] , (int)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (int)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] );
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
          Object[] prmH000F2;
          prmH000F2 = new Object[] {
          new ParDef("@AV6cUsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@lV7cUsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV8cUsuarioFecha",GXType.Date,8,0) ,
          new ParDef("@AV9cUsuarioHora",GXType.DateTime,0,5) ,
          new ParDef("@lV10cUsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV11cUsuarioTelefono",GXType.Int32,9,0) ,
          new ParDef("@AV15cEstadoTicketUsuarioId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000F3;
          prmH000F3 = new Object[] {
          new ParDef("@AV6cUsuarioId",GXType.Decimal,10,0) ,
          new ParDef("@lV7cUsuarioNombre",GXType.NVarChar,60,0) ,
          new ParDef("@AV8cUsuarioFecha",GXType.Date,8,0) ,
          new ParDef("@AV9cUsuarioHora",GXType.DateTime,0,5) ,
          new ParDef("@lV10cUsuarioEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV11cUsuarioTelefono",GXType.Int32,9,0) ,
          new ParDef("@AV15cEstadoTicketUsuarioId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F3,1, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
