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
namespace GeneXus.Programs.k2bfsg {
   public class secbackendhome : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public secbackendhome( )
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

      public secbackendhome( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
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
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
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
            return "k2bsecurity_Execute" ;
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bt_masterpage", "GeneXus.Programs.k2bt_masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
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
         PA3E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188161796", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.secbackendhome.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIVITYLIST", GetSecureSignedToken( "", AV5ActivityList, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vACTIVITYLIST", AV5ActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vACTIVITYLIST", AV5ActivityList);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIVITYLIST", GetSecureSignedToken( "", AV5ActivityList, context));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
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
            WE3E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("k2bfsg.secbackendhome.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.SecBackendHome" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio configuración de seguridad" ;
      }

      protected void WB3E0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_MainContentTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Security Configuration", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table1_12_3E2( true) ;
         }
         else
         {
            wb_table1_12_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_12_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table2_26_3E2( true) ;
         }
         else
         {
            wb_table2_26_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_26_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table3_40_3E2( true) ;
         }
         else
         {
            wb_table3_40_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_40_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table4_55_3E2( true) ;
         }
         else
         {
            wb_table4_55_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table4_55_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table5_69_3E2( true) ;
         }
         else
         {
            wb_table5_69_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table5_69_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            wb_table6_83_3E2( true) ;
         }
         else
         {
            wb_table6_83_3E2( false) ;
         }
         return  ;
      }

      protected void wb_table6_83_3E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START3E2( )
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
            Form.Meta.addItem("description", "Inicio configuración de seguridad", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3E0( ) ;
      }

      protected void WS3E2( )
      {
         START3E2( ) ;
         EVT3E2( ) ;
      }

      protected void EVT3E2( )
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
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E113E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E123E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                 }
                                 dynload_actions( ) ;
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE3E2( )
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

      protected void PA3E2( )
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
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
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
         RF3E2( ) ;
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

      protected void RF3E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E123E2 ();
            WB3E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes3E2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vACTIVITYLIST", AV5ActivityList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vACTIVITYLIST", AV5ActivityList);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vACTIVITYLIST", GetSecureSignedToken( "", AV5ActivityList, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E113E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vACTIVITYLIST"), AV5ActivityList);
            /* Read saved values. */
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E113E2 ();
         if (returnInSub) return;
      }

      protected void E113E2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         AV5ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         AV6ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "K2BSecurity";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV5ActivityList.Add(AV6ActivityListItem, 0);
         AV6ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "K2BSecurity";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV5ActivityList.Add(AV6ActivityListItem, 0);
         AV6ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "K2BSecurity";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV5ActivityList.Add(AV6ActivityListItem, 0);
         AV6ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Entityname = "K2BSecurity";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Standardactivitytype = "Display";
         AV6ActivityListItem.gxTpr_Activity.gxTpr_Useractivitytype = "";
         AV5ActivityList.Add(AV6ActivityListItem, 0);
         imgImageusers_Link = formatLink("k2bfsg.wwuser.aspx") ;
         AssignProp("", false, imgImageusers_Internalname, "Link", imgImageusers_Link, true);
         imgImageroles_Link = formatLink("k2bfsg.wwrole.aspx") ;
         AssignProp("", false, imgImageroles_Internalname, "Link", imgImageroles_Link, true);
         imgImageapplications_Link = formatLink("k2bfsg.wwapplication.aspx") ;
         AssignProp("", false, imgImageapplications_Internalname, "Link", imgImageapplications_Link, true);
         imgImageauthtype_Link = formatLink("k2bfsg.wwauthtype.aspx") ;
         AssignProp("", false, imgImageauthtype_Internalname, "Link", imgImageauthtype_Link, true);
         imgMenuimage_Link = formatLink("k2bfsg.wwmenu.aspx") ;
         AssignProp("", false, imgMenuimage_Internalname, "Link", imgMenuimage_Link, true);
         new k2bisauthorizedactivitylist(context ).execute( ref  AV5ActivityList) ;
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV5ActivityList.Item(1)).gxTpr_Isauthorized )
         {
            bttButtonusers_Enabled = 0;
            AssignProp("", false, bttButtonusers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttButtonusers_Enabled), 5, 0), true);
            bttButtonusers_Caption = "No autorizado";
            AssignProp("", false, bttButtonusers_Internalname, "Caption", bttButtonusers_Caption, true);
            bttButtonusers_Class = "Button_DashBoardDisabled";
            AssignProp("", false, bttButtonusers_Internalname, "Class", bttButtonusers_Class, true);
            imgImageusers_Link = "";
            AssignProp("", false, imgImageusers_Internalname, "Link", imgImageusers_Link, true);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV5ActivityList.Item(2)).gxTpr_Isauthorized )
         {
            bttButtonroles_Enabled = 0;
            AssignProp("", false, bttButtonroles_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttButtonroles_Enabled), 5, 0), true);
            bttButtonroles_Class = "Button_DashBoardDisabled";
            AssignProp("", false, bttButtonroles_Internalname, "Class", bttButtonroles_Class, true);
            bttButtonroles_Caption = "No autorizado";
            AssignProp("", false, bttButtonroles_Internalname, "Caption", bttButtonroles_Caption, true);
            imgImageroles_Link = "";
            AssignProp("", false, imgImageroles_Internalname, "Link", imgImageroles_Link, true);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV5ActivityList.Item(3)).gxTpr_Isauthorized )
         {
            bttButtonapplications_Enabled = 0;
            AssignProp("", false, bttButtonapplications_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttButtonapplications_Enabled), 5, 0), true);
            bttButtonapplications_Caption = "No autorizado";
            AssignProp("", false, bttButtonapplications_Internalname, "Caption", bttButtonapplications_Caption, true);
            bttButtonapplications_Class = "Button_DashBoardDisabled";
            AssignProp("", false, bttButtonapplications_Internalname, "Class", bttButtonapplications_Class, true);
            imgImageapplications_Link = "";
            AssignProp("", false, imgImageapplications_Internalname, "Link", imgImageapplications_Link, true);
         }
         if ( ! ((SdtK2BActivityList_K2BActivityListItem)AV5ActivityList.Item(4)).gxTpr_Isauthorized )
         {
            bttButtonauthtypes_Caption = "No autorizado";
            AssignProp("", false, bttButtonauthtypes_Internalname, "Caption", bttButtonauthtypes_Caption, true);
            bttButtonauthtypes_Enabled = 0;
            AssignProp("", false, bttButtonauthtypes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttButtonauthtypes_Enabled), 5, 0), true);
            bttButtonauthtypes_Class = "Button_DashBoardDisabled";
            AssignProp("", false, bttButtonauthtypes_Internalname, "Class", bttButtonauthtypes_Class, true);
            imgImageauthtype_Link = "";
            AssignProp("", false, imgImageauthtype_Internalname, "Link", imgImageauthtype_Link, true);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E123E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table6_83_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable6_Internalname, tblTable6_Internalname, "", "K2BFSGTable_DashBoardItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "87341f57-926c-4296-b80f-3b8d4d28fcd6", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageadvanced_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockadvanced_Internalname, "Avanzado", "", "", lblTextblockadvanced_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardTitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblocksecuritypolicies_Internalname, "Políticas de seguridad", "", "", lblTextblocksecuritypolicies_Jsonclick, "'"+""+"'"+",false,"+"'"+"e133e1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockrepositoryconfigurations_Internalname, "Configuraciones de repositorio", "", "", lblTextblockrepositoryconfigurations_Jsonclick, "'"+""+"'"+",false,"+"'"+"e143e1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockconnections_Internalname, "Conexiones del repositorio", "", "", lblTextblockconnections_Jsonclick, "'"+""+"'"+",false,"+"'"+"e153e1_client"+"'", "", "TextBlock", 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_83_3E2e( true) ;
         }
         else
         {
            wb_table6_83_3E2e( false) ;
         }
      }

      protected void wb_table5_69_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable5_Internalname, tblTable5_Internalname, "", "K2BFSGTable_DashBoardItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "87341f57-926c-4296-b80f-3b8d4d28fcd6", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageauthtype_Internalname, sImgUrl, imgImageauthtype_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockauthenticationtypes_Internalname, "Tipos de autenticación", "", "", lblTextblockauthenticationtypes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardTitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Administrar tipos de autenticación. Agregar nuevas formas que usuarios pueden usar para ingresar.", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardDescription", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttButtonauthtypes_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButtonauthtypes_Internalname, "", bttButtonauthtypes_Caption, bttButtonauthtypes_Jsonclick, 7, "Tipos de autenticación", "", StyleString, ClassString, 1, bttButtonauthtypes_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e163e1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_69_3E2e( true) ;
         }
         else
         {
            wb_table5_69_3E2e( false) ;
         }
      }

      protected void wb_table4_55_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable7_Internalname, tblTable7_Internalname, "", "K2BFSGTable_DashBoardItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e4338482-dcd0-4a97-994b-02de70e7af7b", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMenuimage_Internalname, sImgUrl, imgMenuimage_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMenus1_Internalname, "Menús", "", "", lblMenus1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardTitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMenudescription_Internalname, "Administrar menus. Agregar o actualizar opciones del menú.", "", "", lblMenudescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttMenus_Internalname, "", "Menús", bttMenus_Jsonclick, 7, "Menús", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e173e1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_55_3E2e( true) ;
         }
         else
         {
            wb_table4_55_3E2e( false) ;
         }
      }

      protected void wb_table3_40_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable4_Internalname, tblTable4_Internalname, "", "K2BFSGTable_DashBoardItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "aecc1b9f-fc25-43ff-812a-ebd2a3855425", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageapplications_Internalname, sImgUrl, imgImageapplications_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockapplications_Internalname, "Aplicaciones", "", "", lblTextblockapplications_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardTitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Administrar aplicaciones. Agregar permisos a aplicaciones.", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardDescription", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = bttButtonapplications_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButtonapplications_Internalname, "", bttButtonapplications_Caption, bttButtonapplications_Jsonclick, 7, "Aplicaciones", "", StyleString, ClassString, 1, bttButtonapplications_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e183e1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_40_3E2e( true) ;
         }
         else
         {
            wb_table3_40_3E2e( false) ;
         }
      }

      protected void wb_table2_26_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable3_Internalname, tblTable3_Internalname, "", "K2BFSGTable_DashBoardItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "8aadadc7-1113-4f45-84ab-4b6f760dbecf", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageroles_Internalname, sImgUrl, imgImageroles_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockroles_Internalname, "Roles", "", "", lblTextblockroles_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardTitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Administrar roles. Crear roles. Asignar actividades a un rol.", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardDescription", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            ClassString = bttButtonroles_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButtonroles_Internalname, "", bttButtonroles_Caption, bttButtonroles_Jsonclick, 7, "Roles", "", StyleString, ClassString, 1, bttButtonroles_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e193e1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_26_3E2e( true) ;
         }
         else
         {
            wb_table2_26_3E2e( false) ;
         }
      }

      protected void wb_table1_12_3E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "K2BFSGTable_DashBoardItem", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Static images/pictures */
            ClassString = "Image";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c0707835-6985-42c0-bf24-54b2679c24dd", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageusers_Internalname, sImgUrl, imgImageusers_Link, "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblockusers_Internalname, "Usuarios", "", "", lblTextblockusers_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardTitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Administrar usuarios. Asignar roles a un usuario. Actualizar información de usuario.", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BFSGTextBlock_DashboardDescription", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'',false,'',0)\"";
            ClassString = bttButtonusers_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttButtonusers_Internalname, "", bttButtonusers_Caption, bttButtonusers_Jsonclick, 7, "Usuarios", "", StyleString, ClassString, 1, bttButtonusers_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"e203e1_client"+"'", TempTags, "", 2, "HLP_K2BFSG\\SecBackendHome.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_12_3E2e( true) ;
         }
         else
         {
            wb_table1_12_3E2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
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
         PA3E2( ) ;
         WS3E2( ) ;
         WE3E2( ) ;
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
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188161841", true, true);
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
         context.AddJavascriptSource("k2bfsg/secbackendhome.js", "?2024188161842", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         imgImageusers_Internalname = "IMAGEUSERS";
         lblTextblockusers_Internalname = "TEXTBLOCKUSERS";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         bttButtonusers_Internalname = "BUTTONUSERS";
         tblTable2_Internalname = "TABLE2";
         imgImageroles_Internalname = "IMAGEROLES";
         lblTextblockroles_Internalname = "TEXTBLOCKROLES";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         bttButtonroles_Internalname = "BUTTONROLES";
         tblTable3_Internalname = "TABLE3";
         imgImageapplications_Internalname = "IMAGEAPPLICATIONS";
         lblTextblockapplications_Internalname = "TEXTBLOCKAPPLICATIONS";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         bttButtonapplications_Internalname = "BUTTONAPPLICATIONS";
         tblTable4_Internalname = "TABLE4";
         imgMenuimage_Internalname = "MENUIMAGE";
         lblMenus1_Internalname = "MENUS1";
         lblMenudescription_Internalname = "MENUDESCRIPTION";
         bttMenus_Internalname = "MENUS";
         tblTable7_Internalname = "TABLE7";
         imgImageauthtype_Internalname = "IMAGEAUTHTYPE";
         lblTextblockauthenticationtypes_Internalname = "TEXTBLOCKAUTHENTICATIONTYPES";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         bttButtonauthtypes_Internalname = "BUTTONAUTHTYPES";
         tblTable5_Internalname = "TABLE5";
         imgImageadvanced_Internalname = "IMAGEADVANCED";
         lblTextblockadvanced_Internalname = "TEXTBLOCKADVANCED";
         lblTextblocksecuritypolicies_Internalname = "TEXTBLOCKSECURITYPOLICIES";
         lblTextblockrepositoryconfigurations_Internalname = "TEXTBLOCKREPOSITORYCONFIGURATIONS";
         lblTextblockconnections_Internalname = "TEXTBLOCKCONNECTIONS";
         tblTable6_Internalname = "TABLE6";
         divTable1_Internalname = "TABLE1";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         bttButtonusers_Enabled = 1;
         imgImageusers_Link = "";
         bttButtonroles_Enabled = 1;
         imgImageroles_Link = "";
         bttButtonapplications_Enabled = 1;
         imgImageapplications_Link = "";
         imgMenuimage_Link = "";
         bttButtonauthtypes_Enabled = 1;
         imgImageauthtype_Link = "";
         bttButtonauthtypes_Class = "K2BToolsButton_MainAction";
         bttButtonauthtypes_Caption = "Tipos de autenticación";
         bttButtonapplications_Class = "K2BToolsButton_MainAction";
         bttButtonapplications_Caption = "Aplicaciones";
         bttButtonroles_Caption = "Roles";
         bttButtonroles_Class = "K2BToolsButton_MainAction";
         bttButtonusers_Class = "K2BToolsButton_MainAction";
         bttButtonusers_Caption = "Usuarios";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio configuración de seguridad";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV5ActivityList',fld:'vACTIVITYLIST',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'USERS'","{handler:'E203E1',iparms:[{av:'AV5ActivityList',fld:'vACTIVITYLIST',pic:'',hsh:true}]");
         setEventMetadata("'USERS'",",oparms:[]}");
         setEventMetadata("'ROLES'","{handler:'E193E1',iparms:[{av:'AV5ActivityList',fld:'vACTIVITYLIST',pic:'',hsh:true}]");
         setEventMetadata("'ROLES'",",oparms:[]}");
         setEventMetadata("'APPLICATIONS'","{handler:'E183E1',iparms:[{av:'AV5ActivityList',fld:'vACTIVITYLIST',pic:'',hsh:true}]");
         setEventMetadata("'APPLICATIONS'",",oparms:[]}");
         setEventMetadata("'AUTHTYPES'","{handler:'E163E1',iparms:[{av:'AV5ActivityList',fld:'vACTIVITYLIST',pic:'',hsh:true}]");
         setEventMetadata("'AUTHTYPES'",",oparms:[]}");
         setEventMetadata("'SECURITYPOLICIES'","{handler:'E133E1',iparms:[]");
         setEventMetadata("'SECURITYPOLICIES'",",oparms:[]}");
         setEventMetadata("'REPOSITORYCONFIGURATIONS'","{handler:'E143E1',iparms:[]");
         setEventMetadata("'REPOSITORYCONFIGURATIONS'",",oparms:[]}");
         setEventMetadata("'CONNECTIONS'","{handler:'E153E1',iparms:[]");
         setEventMetadata("'CONNECTIONS'",",oparms:[]}");
         setEventMetadata("'MENUS'","{handler:'E173E1',iparms:[{av:'AV5ActivityList',fld:'vACTIVITYLIST',pic:'',hsh:true}]");
         setEventMetadata("'MENUS'",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV5ActivityList = new GXBaseCollection<SdtK2BActivityList_K2BActivityListItem>( context, "K2BActivityListItem", "kb_ticket");
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitle_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6ActivityListItem = new SdtK2BActivityList_K2BActivityListItem(context);
         sStyleString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         lblTextblockadvanced_Jsonclick = "";
         lblTextblocksecuritypolicies_Jsonclick = "";
         lblTextblockrepositoryconfigurations_Jsonclick = "";
         lblTextblockconnections_Jsonclick = "";
         lblTextblockauthenticationtypes_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         TempTags = "";
         bttButtonauthtypes_Jsonclick = "";
         lblMenus1_Jsonclick = "";
         lblMenudescription_Jsonclick = "";
         bttMenus_Jsonclick = "";
         lblTextblockapplications_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         bttButtonapplications_Jsonclick = "";
         lblTextblockroles_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         bttButtonroles_Jsonclick = "";
         lblTextblockusers_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         bttButtonusers_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int bttButtonusers_Enabled ;
      private int bttButtonroles_Enabled ;
      private int bttButtonapplications_Enabled ;
      private int bttButtonauthtypes_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string divTable1_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string imgImageusers_Link ;
      private string imgImageusers_Internalname ;
      private string imgImageroles_Link ;
      private string imgImageroles_Internalname ;
      private string imgImageapplications_Link ;
      private string imgImageapplications_Internalname ;
      private string imgImageauthtype_Link ;
      private string imgImageauthtype_Internalname ;
      private string imgMenuimage_Link ;
      private string imgMenuimage_Internalname ;
      private string bttButtonusers_Internalname ;
      private string bttButtonusers_Caption ;
      private string bttButtonusers_Class ;
      private string bttButtonroles_Internalname ;
      private string bttButtonroles_Class ;
      private string bttButtonroles_Caption ;
      private string bttButtonapplications_Internalname ;
      private string bttButtonapplications_Caption ;
      private string bttButtonapplications_Class ;
      private string bttButtonauthtypes_Caption ;
      private string bttButtonauthtypes_Internalname ;
      private string bttButtonauthtypes_Class ;
      private string sStyleString ;
      private string tblTable6_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImageadvanced_Internalname ;
      private string lblTextblockadvanced_Internalname ;
      private string lblTextblockadvanced_Jsonclick ;
      private string lblTextblocksecuritypolicies_Internalname ;
      private string lblTextblocksecuritypolicies_Jsonclick ;
      private string lblTextblockrepositoryconfigurations_Internalname ;
      private string lblTextblockrepositoryconfigurations_Jsonclick ;
      private string lblTextblockconnections_Internalname ;
      private string lblTextblockconnections_Jsonclick ;
      private string tblTable5_Internalname ;
      private string lblTextblockauthenticationtypes_Internalname ;
      private string lblTextblockauthenticationtypes_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string TempTags ;
      private string bttButtonauthtypes_Jsonclick ;
      private string tblTable7_Internalname ;
      private string lblMenus1_Internalname ;
      private string lblMenus1_Jsonclick ;
      private string lblMenudescription_Internalname ;
      private string lblMenudescription_Jsonclick ;
      private string bttMenus_Internalname ;
      private string bttMenus_Jsonclick ;
      private string tblTable4_Internalname ;
      private string lblTextblockapplications_Internalname ;
      private string lblTextblockapplications_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string bttButtonapplications_Jsonclick ;
      private string tblTable3_Internalname ;
      private string lblTextblockroles_Internalname ;
      private string lblTextblockroles_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string bttButtonroles_Jsonclick ;
      private string tblTable2_Internalname ;
      private string lblTextblockusers_Internalname ;
      private string lblTextblockusers_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string bttButtonusers_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<SdtK2BActivityList_K2BActivityListItem> AV5ActivityList ;
      private GXWebForm Form ;
      private SdtK2BActivityList_K2BActivityListItem AV6ActivityListItem ;
   }

}
