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
   public class entitymanagerticket : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public entitymanagerticket( )
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

      public entitymanagerticket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_TicketId ,
                           string aP2_TabCode )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV6TicketId = aP1_TicketId;
         this.AV8TabCode = aP2_TabCode;
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
            gxfirstwebparm = GetFirstPar( "Mode");
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV6TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
                  AssignAttri("", false, "AV6TicketId", StringUtil.LTrimStr( (decimal)(AV6TicketId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6TicketId), "ZZZZZZZZZ9"), context));
                  AV8TabCode = GetPar( "TabCode");
                  AssignAttri("", false, "AV8TabCode", AV8TabCode);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
            return "ticket_Execute" ;
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
         PA2Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2Q2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20241883666", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ModalWindowRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV8TabCode))}, new string[] {"Gx_mode","TicketId","TabCode"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV18AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV18AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV20RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGE_COMPONENTNAME", AV22GE_ComponentName);
         GxWebStd.gx_hidden_field( context, "vGE_ENTITYMANAGERNAME", AV21GE_EntityManagerName);
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Title", StringUtil.RTrim( Componentscontainer_components_Title));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Collapsible", StringUtil.BoolToStr( Componentscontainer_components_Collapsible));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Open", StringUtil.BoolToStr( Componentscontainer_components_Open));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Showborders", StringUtil.BoolToStr( Componentscontainer_components_Showborders));
         GxWebStd.gx_hidden_field( context, "COMPONENTSCONTAINER_COMPONENTS_Visible", StringUtil.BoolToStr( Componentscontainer_components_Visible));
         GxWebStd.gx_hidden_field( context, "TABLEMODAL_Modaltitle", StringUtil.RTrim( Tablemodal_Modaltitle));
         GxWebStd.gx_hidden_field( context, "TABLEMODAL_Visible", StringUtil.BoolToStr( Tablemodal_Visible));
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
         if ( ! ( WebComp_Tabstrip == null ) )
         {
            WebComp_Tabstrip.componentjscripts();
         }
         if ( ! ( WebComp_Componentwc_general == null ) )
         {
            WebComp_Componentwc_general.componentjscripts();
         }
         if ( ! ( WebComp_Componentwc_satisfaccion == null ) )
         {
            WebComp_Componentwc_satisfaccion.componentjscripts();
         }
         if ( ! ( WebComp_Popupcomponent == null ) )
         {
            WebComp_Popupcomponent.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE2Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2Q2( ) ;
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
         return formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV8TabCode))}, new string[] {"Gx_mode","TicketId","TabCode"})  ;
      }

      public override string GetPgmname( )
      {
         return "EntityManagerTicket" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ticket" ;
      }

      protected void WB2Q0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecontainersection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_TitleContainer", "left", "top", "", "", "h1");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblK2bpgmdesc_Internalname, lblK2bpgmdesc_Caption, "", "", lblK2bpgmdesc_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Title", 0, "", 1, 1, 0, 0, "HLP_EntityManagerTicket.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitleright_Internalname, 1, 0, "px", 0, "px", "K2BT_TitleRight", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "h1");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcontainer_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcontainertable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_BackToWorkWithContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divBacktoworkwithcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBacktoworkwith_Internalname, lblBacktoworkwith_Caption, lblBacktoworkwith_Link, "", lblBacktoworkwith_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_BackToWorkWith", 0, "", 1, 1, 0, 0, "HLP_EntityManagerTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_EntityManagerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucComponentscontainer_components.SetProperty("Title", Componentscontainer_components_Title);
            ucComponentscontainer_components.SetProperty("Collapsible", Componentscontainer_components_Collapsible);
            ucComponentscontainer_components.SetProperty("Open", Componentscontainer_components_Open);
            ucComponentscontainer_components.SetProperty("ShowBorders", Componentscontainer_components_Showborders);
            ucComponentscontainer_components.Render(context, "k2bt_component", Componentscontainer_components_Internalname, "COMPONENTSCONTAINER_COMPONENTSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"COMPONENTSCONTAINER_COMPONENTSContainer"+"Componentscontainer_components_Content"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentscontainer_components_content_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContainercollapsiblesection_components_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponents_components_tabssection_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0033"+"", StringUtil.RTrim( WebComp_Tabstrip_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0033"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabstrip), StringUtil.Lower( WebComp_Tabstrip_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
                  }
                  WebComp_Tabstrip.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldTabstrip), StringUtil.Lower( WebComp_Tabstrip_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, divSection2_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablayouts_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentstabcontainer_components_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divComponentcontainer_general_Internalname, divComponentcontainer_general_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0043"+"", StringUtil.RTrim( WebComp_Componentwc_general_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0043"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_general), StringUtil.Lower( WebComp_Componentwc_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
                  }
                  WebComp_Componentwc_general.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_general), StringUtil.Lower( WebComp_Componentwc_general_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
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
            GxWebStd.gx_div_start( context, divComponentcontainer_satisfaccion_Internalname, divComponentcontainer_satisfaccion_Visible, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0049"+"", StringUtil.RTrim( WebComp_Componentwc_satisfaccion_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0049"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Componentwc_satisfaccion_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_satisfaccion), StringUtil.Lower( WebComp_Componentwc_satisfaccion_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
                  }
                  WebComp_Componentwc_satisfaccion.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldComponentwc_satisfaccion), StringUtil.Lower( WebComp_Componentwc_satisfaccion_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucTablemodal.Render(context, "k2bt_modalwindow", Tablemodal_Internalname, "TABLEMODALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABLEMODALContainer"+"Tablemodal_ModalContent"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemodal_modalcontent_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0060"+"", StringUtil.RTrim( WebComp_Popupcomponent_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0060"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPopupcomponent), StringUtil.Lower( WebComp_Popupcomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                  }
                  WebComp_Popupcomponent.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldPopupcomponent), StringUtil.Lower( WebComp_Popupcomponent_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2Q2( )
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
            Form.Meta.addItem("description", "Ticket", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2Q0( ) ;
      }

      protected void WS2Q2( )
      {
         START2Q2( ) ;
         EVT2Q2( ) ;
      }

      protected void EVT2Q2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "TABLEMODAL.ONCLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E112Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E122Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E132Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GLOBALEVENTS.K2BT_REFRESHENTITYMANAGER") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E142Q2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E152Q2 ();
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
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(NumberUtil.Val( sEvtType, "."));
                        if ( nCmpId == 33 )
                        {
                           OldTabstrip = cgiGet( "W0033");
                           if ( ( StringUtil.Len( OldTabstrip) == 0 ) || ( StringUtil.StrCmp(OldTabstrip, WebComp_Tabstrip_Component) != 0 ) )
                           {
                              WebComp_Tabstrip = getWebComponent(GetType(), "GeneXus.Programs", OldTabstrip, new Object[] {context} );
                              WebComp_Tabstrip.ComponentInit();
                              WebComp_Tabstrip.Name = "OldTabstrip";
                              WebComp_Tabstrip_Component = OldTabstrip;
                           }
                           if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
                           {
                              WebComp_Tabstrip.componentprocess("W0033", "", sEvt);
                           }
                           WebComp_Tabstrip_Component = OldTabstrip;
                        }
                        else if ( nCmpId == 43 )
                        {
                           OldComponentwc_general = cgiGet( "W0043");
                           if ( ( StringUtil.Len( OldComponentwc_general) == 0 ) || ( StringUtil.StrCmp(OldComponentwc_general, WebComp_Componentwc_general_Component) != 0 ) )
                           {
                              WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", OldComponentwc_general, new Object[] {context} );
                              WebComp_Componentwc_general.ComponentInit();
                              WebComp_Componentwc_general.Name = "OldComponentwc_general";
                              WebComp_Componentwc_general_Component = OldComponentwc_general;
                           }
                           if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
                           {
                              WebComp_Componentwc_general.componentprocess("W0043", "", sEvt);
                           }
                           WebComp_Componentwc_general_Component = OldComponentwc_general;
                        }
                        else if ( nCmpId == 49 )
                        {
                           OldComponentwc_satisfaccion = cgiGet( "W0049");
                           if ( ( StringUtil.Len( OldComponentwc_satisfaccion) == 0 ) || ( StringUtil.StrCmp(OldComponentwc_satisfaccion, WebComp_Componentwc_satisfaccion_Component) != 0 ) )
                           {
                              WebComp_Componentwc_satisfaccion = getWebComponent(GetType(), "GeneXus.Programs", OldComponentwc_satisfaccion, new Object[] {context} );
                              WebComp_Componentwc_satisfaccion.ComponentInit();
                              WebComp_Componentwc_satisfaccion.Name = "OldComponentwc_satisfaccion";
                              WebComp_Componentwc_satisfaccion_Component = OldComponentwc_satisfaccion;
                           }
                           if ( StringUtil.Len( WebComp_Componentwc_satisfaccion_Component) != 0 )
                           {
                              WebComp_Componentwc_satisfaccion.componentprocess("W0049", "", sEvt);
                           }
                           WebComp_Componentwc_satisfaccion_Component = OldComponentwc_satisfaccion;
                        }
                        else if ( nCmpId == 60 )
                        {
                           OldPopupcomponent = cgiGet( "W0060");
                           if ( ( StringUtil.Len( OldPopupcomponent) == 0 ) || ( StringUtil.StrCmp(OldPopupcomponent, WebComp_Popupcomponent_Component) != 0 ) )
                           {
                              WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", OldPopupcomponent, new Object[] {context} );
                              WebComp_Popupcomponent.ComponentInit();
                              WebComp_Popupcomponent.Name = "OldPopupcomponent";
                              WebComp_Popupcomponent_Component = OldPopupcomponent;
                           }
                           if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
                           {
                              WebComp_Popupcomponent.componentprocess("W0060", "", sEvt);
                           }
                           WebComp_Popupcomponent_Component = OldPopupcomponent;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2Q2( )
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

      protected void PA2Q2( )
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
         RF2Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV27Pgmname = "EntityManagerTicket";
         context.Gx_err = 0;
      }

      protected void RF2Q2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E132Q2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
               {
                  WebComp_Tabstrip.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
               {
                  WebComp_Componentwc_general.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Componentwc_satisfaccion_Component) != 0 )
               {
                  WebComp_Componentwc_satisfaccion.componentstart();
               }
            }
         }
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E152Q2 ();
            WB2Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2Q2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAVAILABLECOMPONENTS", AV18AvailableComponents);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vAVAILABLECOMPONENTS", GetSecureSignedToken( "", AV18AvailableComponents, context));
         GxWebStd.gx_hidden_field( context, "vRELATEDTRANSACTIONNAME", StringUtil.RTrim( AV20RelatedTransactionName));
         GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")), context));
      }

      protected void before_start_formulas( )
      {
         AV27Pgmname = "EntityManagerTicket";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E122Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Componentscontainer_components_Title = cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Title");
            Componentscontainer_components_Collapsible = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Collapsible"));
            Componentscontainer_components_Open = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Open"));
            Componentscontainer_components_Showborders = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Showborders"));
            Componentscontainer_components_Visible = StringUtil.StrToBool( cgiGet( "COMPONENTSCONTAINER_COMPONENTS_Visible"));
            Tablemodal_Modaltitle = cgiGet( "TABLEMODAL_Modaltitle");
            Tablemodal_Visible = StringUtil.StrToBool( cgiGet( "TABLEMODAL_Visible"));
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
         E122Q2 ();
         if (returnInSub) return;
      }

      protected void E122Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblBacktoworkwith_Caption = StringUtil.Format( "%1", "Ticketes", "", "", "", "", "", "", "", "");
         AssignProp("", false, lblBacktoworkwith_Internalname, "Caption", lblBacktoworkwith_Caption, true);
         lblBacktoworkwith_Link = formatLink("wwticket.aspx") ;
         AssignProp("", false, lblBacktoworkwith_Internalname, "Link", lblBacktoworkwith_Link, true);
         AV26GXLvl7 = 0;
         /* Using cursor H002Q2 */
         pr_default.execute(0, new Object[] {AV6TicketId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14TicketId = H002Q2_A14TicketId[0];
            A46TicketFecha = H002Q2_A46TicketFecha[0];
            AV26GXLvl7 = 1;
            Form.Caption = context.localUtil.DToC( A46TicketFecha, 2, "/");
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            lblK2bpgmdesc_Caption = StringUtil.Format( "%1 - %2", "Ticket", context.localUtil.Format( A46TicketFecha, "99/99/9999"), "", "", "", "", "", "", "");
            AssignProp("", false, lblK2bpgmdesc_Internalname, "Caption", lblK2bpgmdesc_Caption, true);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV26GXLvl7 == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               context.setWebReturnParms(new Object[] {});
               context.setWebReturnParmsMetadata(new Object[] {});
               context.wjLocDisableFrm = 1;
               context.nUserReturn = 1;
               returnInSub = true;
               if (true) return;
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            lblK2bpgmdesc_Caption = "Ticket";
            AssignProp("", false, lblK2bpgmdesc_Internalname, "Caption", lblK2bpgmdesc_Caption, true);
         }
         new k2bsetobjectcontainername(context ).execute(  AV27Pgmname) ;
         GXt_objcol_SdtMessages_Message1 = AV16Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV16Messages = GXt_objcol_SdtMessages_Message1;
         AV28GXV1 = 1;
         while ( AV28GXV1 <= AV16Messages.Count )
         {
            AV17Message = ((GeneXus.Utils.SdtMessages_Message)AV16Messages.Item(AV28GXV1));
            GX_msglist.addItem(AV17Message.gxTpr_Description);
            AV28GXV1 = (int)(AV28GXV1+1);
         }
      }

      protected void E132Q2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         new k2bgetcontext(context ).execute( out  AV5Context) ;
         /* Execute user subroutine: 'LOADCOMPONENTGROUP_COMPONENTS' */
         S112 ();
         if (returnInSub) return;
         GXt_char2 = AV19NextComponentCode;
         new k2bgetnextcomponentcode(context ).execute(  AV18AvailableComponents,  AV8TabCode, out  GXt_char2) ;
         AV19NextComponentCode = GXt_char2;
         if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || ( StringUtil.StrCmp(AV8TabCode, "") == 0 ) )
         {
            AV20RelatedTransactionName = "Ticket";
            AssignAttri("", false, "AV20RelatedTransactionName", AV20RelatedTransactionName);
            GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         }
         else if ( StringUtil.StrCmp(AV8TabCode, "Satisfaccion") == 0 )
         {
            AV20RelatedTransactionName = "Satisfaccion";
            AssignAttri("", false, "AV20RelatedTransactionName", AV20RelatedTransactionName);
            GxWebStd.gx_hidden_field( context, "gxhash_vRELATEDTRANSACTIONNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV20RelatedTransactionName, "")), context));
         }
         new k2bgettrncontextbyname(context ).execute(  AV20RelatedTransactionName, out  AV9TrnContext) ;
         AV14CurrentUrl = AV9TrnContext.gxTpr_Callerurl;
         AV9TrnContext.gxTpr_Entitymanagername = AV27Pgmname;
         AV9TrnContext.gxTpr_Entitymanagerencrypturlparameters = "";
         AV9TrnContext.gxTpr_Entitymanagernexttaskcode = AV19NextComponentCode;
         AV9TrnContext.gxTpr_Entitymanagernexttaskmode = "DSP";
         new k2bsettrncontextbyname(context ).execute(  AV20RelatedTransactionName,  AV9TrnContext) ;
         Tablemodal_Visible = false;
         ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "Visible", StringUtil.BoolToStr( Tablemodal_Visible));
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
            {
               Tablemodal_Modaltitle = StringUtil.Format( "Actualizar %1", "Ticket", "", "", "", "", "", "", "", "");
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "ModalTitle", Tablemodal_Modaltitle);
               Tablemodal_Visible = true;
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "Visible", StringUtil.BoolToStr( Tablemodal_Visible));
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Popupcomponent = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Popupcomponent_Component), StringUtil.Lower( "Ticket")) != 0 )
               {
                  WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", "ticket", new Object[] {context} );
                  WebComp_Popupcomponent.ComponentInit();
                  WebComp_Popupcomponent.Name = "Ticket";
                  WebComp_Popupcomponent_Component = "Ticket";
               }
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.setjustcreated();
                  WebComp_Popupcomponent.componentprepare(new Object[] {(string)"W0060",(string)"",(string)"UPD",(long)AV6TicketId});
                  WebComp_Popupcomponent.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Popupcomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                  WebComp_Popupcomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) )
            {
               Tablemodal_Modaltitle = StringUtil.Format( "Eliminar %1", "Ticket", "", "", "", "", "", "", "", "");
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "ModalTitle", Tablemodal_Modaltitle);
               Tablemodal_Visible = true;
               ucTablemodal.SendProperty(context, "", false, Tablemodal_Internalname, "Visible", StringUtil.BoolToStr( Tablemodal_Visible));
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Popupcomponent = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Popupcomponent_Component), StringUtil.Lower( "Ticket")) != 0 )
               {
                  WebComp_Popupcomponent = getWebComponent(GetType(), "GeneXus.Programs", "ticket", new Object[] {context} );
                  WebComp_Popupcomponent.ComponentInit();
                  WebComp_Popupcomponent.Name = "Ticket";
                  WebComp_Popupcomponent_Component = "Ticket";
               }
               if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
               {
                  WebComp_Popupcomponent.setjustcreated();
                  WebComp_Popupcomponent.componentprepare(new Object[] {(string)"W0060",(string)"",(string)"DLT",(long)AV6TicketId});
                  WebComp_Popupcomponent.componentbind(new Object[] {(string)"",(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Popupcomponent )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0060"+"");
                  WebComp_Popupcomponent.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV18AvailableComponents", AV18AvailableComponents);
      }

      protected void S112( )
      {
         /* 'LOADCOMPONENTGROUP_COMPONENTS' Routine */
         returnInSub = false;
         AV10Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "kb_ticket");
         AV18AvailableComponents.Add("General", 0);
         AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         AV11Tab.gxTpr_Code = "General";
         AV11Tab.gxTpr_Description = "General";
         AV11Tab.gxTpr_Link = formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV11Tab.gxTpr_Code))}, new string[] {"Mode","TicketId","TabCode"}) ;
         AV11Tab.gxTpr_Componenttype = 3;
         AV11Tab.gxTpr_Relatedtransaction = "Ticket";
         AV10Tabs.Add(AV11Tab, 0);
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  "TicketSatisfaccionWC") )
         {
            AV18AvailableComponents.Add("Satisfaccion", 0);
            AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
            AV11Tab.gxTpr_Code = "Satisfaccion";
            AV11Tab.gxTpr_Description = "Satisfacciones";
            AV11Tab.gxTpr_Link = formatLink("entitymanagerticket.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV6TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV11Tab.gxTpr_Code))}, new string[] {"Mode","TicketId","TabCode"}) ;
            AV11Tab.gxTpr_Componenttype = 1;
            AV11Tab.gxTpr_Relatedtransaction = "Satisfaccion";
            AV10Tabs.Add(AV11Tab, 0);
         }
         if ( AV10Tabs.Count > 0 )
         {
            Componentscontainer_components_Visible = true;
            ucComponentscontainer_components.SendProperty(context, "", false, Componentscontainer_components_Internalname, "Visible", StringUtil.BoolToStr( Componentscontainer_components_Visible));
            /* Object Property */
            if ( true )
            {
               bDynCreated_Tabstrip = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Tabstrip_Component), StringUtil.Lower( "K2BToolsTabsTitleComponent")) != 0 )
            {
               WebComp_Tabstrip = getWebComponent(GetType(), "GeneXus.Programs", "k2btoolstabstitlecomponent", new Object[] {context} );
               WebComp_Tabstrip.ComponentInit();
               WebComp_Tabstrip.Name = "K2BToolsTabsTitleComponent";
               WebComp_Tabstrip_Component = "K2BToolsTabsTitleComponent";
            }
            if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
            {
               WebComp_Tabstrip.setjustcreated();
               WebComp_Tabstrip.componentprepare(new Object[] {(string)"W0033",(string)"",(string)Gx_mode,(GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>)AV10Tabs,(string)AV8TabCode});
               WebComp_Tabstrip.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Tabstrip )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0033"+"");
               WebComp_Tabstrip.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
            divComponentcontainer_general_Visible = 0;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            divComponentcontainer_satisfaccion_Visible = 0;
            AssignProp("", false, divComponentcontainer_satisfaccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_satisfaccion_Visible), 5, 0), true);
            if ( ( StringUtil.StrCmp(AV8TabCode, "General") == 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) && ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV10Tabs.Item(1)).gxTpr_Code, "General") == 0 ) ) )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
            else if ( ( StringUtil.StrCmp(AV8TabCode, "Satisfaccion") == 0 ) || ( String.IsNullOrEmpty(StringUtil.RTrim( AV8TabCode)) && ( StringUtil.StrCmp(((SdtK2BTabOptions_K2BTabOptionsItem)AV10Tabs.Item(1)).gxTpr_Code, "Satisfaccion") == 0 ) ) )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_SATISFACCION' */
               S132 ();
               if (returnInSub) return;
            }
            else
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
         }
         else
         {
            Componentscontainer_components_Visible = false;
            ucComponentscontainer_components.SendProperty(context, "", false, Componentscontainer_components_Internalname, "Visible", StringUtil.BoolToStr( Componentscontainer_components_Visible));
         }
      }

      protected void S122( )
      {
         /* 'LOADCOMPONENT_GENERAL' Routine */
         returnInSub = false;
         divComponentcontainer_general_Visible = 0;
         AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TicketGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "ticketgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TicketGeneral";
               WebComp_Componentwc_general_Component = "TicketGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0043",(string)"",(string)Gx_mode,(long)AV6TicketId,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TicketGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "ticketgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TicketGeneral";
               WebComp_Componentwc_general_Component = "TicketGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0043",(string)"",(string)"DSP",(long)AV6TicketId,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TicketGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "ticketgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TicketGeneral";
               WebComp_Componentwc_general_Component = "TicketGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0043",(string)"",(string)"DSP",(long)AV6TicketId,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            divComponentcontainer_general_Visible = 1;
            AssignProp("", false, divComponentcontainer_general_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_general_Visible), 5, 0), true);
            /* Object Property */
            if ( true )
            {
               bDynCreated_Componentwc_general = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_general_Component), StringUtil.Lower( "TicketGeneral")) != 0 )
            {
               WebComp_Componentwc_general = getWebComponent(GetType(), "GeneXus.Programs", "ticketgeneral", new Object[] {context} );
               WebComp_Componentwc_general.ComponentInit();
               WebComp_Componentwc_general.Name = "TicketGeneral";
               WebComp_Componentwc_general_Component = "TicketGeneral";
            }
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.setjustcreated();
               WebComp_Componentwc_general.componentprepare(new Object[] {(string)"W0043",(string)"",(string)"DSP",(long)AV6TicketId,(string)AV8TabCode});
               WebComp_Componentwc_general.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_general )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0043"+"");
               WebComp_Componentwc_general.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      protected void S132( )
      {
         /* 'LOADCOMPONENT_SATISFACCION' Routine */
         returnInSub = false;
         if ( new k2bisauthorizedactivityname(context).executeUdp(  "Satisfaccion",  "Satisfaccion",  "List",  "",  "TicketSatisfaccionWC") )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               divComponentcontainer_satisfaccion_Visible = 1;
               AssignProp("", false, divComponentcontainer_satisfaccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_satisfaccion_Visible), 5, 0), true);
               /* Object Property */
               if ( true )
               {
                  bDynCreated_Componentwc_satisfaccion = true;
               }
               if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Componentwc_satisfaccion_Component), StringUtil.Lower( "TicketSatisfaccionWC")) != 0 )
               {
                  WebComp_Componentwc_satisfaccion = getWebComponent(GetType(), "GeneXus.Programs", "ticketsatisfaccionwc", new Object[] {context} );
                  WebComp_Componentwc_satisfaccion.ComponentInit();
                  WebComp_Componentwc_satisfaccion.Name = "TicketSatisfaccionWC";
                  WebComp_Componentwc_satisfaccion_Component = "TicketSatisfaccionWC";
               }
               if ( StringUtil.Len( WebComp_Componentwc_satisfaccion_Component) != 0 )
               {
                  WebComp_Componentwc_satisfaccion.setjustcreated();
                  WebComp_Componentwc_satisfaccion.componentprepare(new Object[] {(string)"W0049",(string)"",(long)AV6TicketId});
                  WebComp_Componentwc_satisfaccion.componentbind(new Object[] {(string)""});
               }
               if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Componentwc_satisfaccion )
               {
                  context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0049"+"");
                  WebComp_Componentwc_satisfaccion.componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
               }
            }
            else
            {
               divComponentcontainer_satisfaccion_Visible = 0;
               AssignProp("", false, divComponentcontainer_satisfaccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_satisfaccion_Visible), 5, 0), true);
            }
         }
         else
         {
            divComponentcontainer_satisfaccion_Visible = 0;
            AssignProp("", false, divComponentcontainer_satisfaccion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divComponentcontainer_satisfaccion_Visible), 5, 0), true);
         }
      }

      protected void E142Q2( )
      {
         /* GlobalEvents_K2bt_refreshentitymanager Routine */
         returnInSub = false;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21GE_EntityManagerName)) || ( StringUtil.StrCmp(StringUtil.Lower( StringUtil.Trim( AV21GE_EntityManagerName)), StringUtil.Lower( StringUtil.Trim( AV27Pgmname))) == 0 ) )
         {
            if ( StringUtil.StrCmp(AV22GE_ComponentName, "General") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_GENERAL' */
               S122 ();
               if (returnInSub) return;
            }
            else if ( StringUtil.StrCmp(AV22GE_ComponentName, "Satisfaccion") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMPONENT_SATISFACCION' */
               S132 ();
               if (returnInSub) return;
            }
            else if ( String.IsNullOrEmpty(StringUtil.RTrim( AV22GE_ComponentName)) )
            {
               context.DoAjaxRefresh();
            }
         }
         /*  Sending Event outputs  */
      }

      protected void E112Q2( )
      {
         /* Tablemodal_Onclose Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E152Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV6TicketId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV6TicketId", StringUtil.LTrimStr( (decimal)(AV6TicketId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6TicketId), "ZZZZZZZZZ9"), context));
         AV8TabCode = (string)getParm(obj,2);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA2Q2( ) ;
         WS2Q2( ) ;
         WE2Q2( ) ;
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
         if ( ! ( WebComp_Tabstrip == null ) )
         {
            if ( StringUtil.Len( WebComp_Tabstrip_Component) != 0 )
            {
               WebComp_Tabstrip.componentthemes();
            }
         }
         if ( ! ( WebComp_Componentwc_general == null ) )
         {
            if ( StringUtil.Len( WebComp_Componentwc_general_Component) != 0 )
            {
               WebComp_Componentwc_general.componentthemes();
            }
         }
         if ( ! ( WebComp_Componentwc_satisfaccion == null ) )
         {
            if ( StringUtil.Len( WebComp_Componentwc_satisfaccion_Component) != 0 )
            {
               WebComp_Componentwc_satisfaccion.componentthemes();
            }
         }
         if ( ! ( WebComp_Popupcomponent == null ) )
         {
            if ( StringUtil.Len( WebComp_Popupcomponent_Component) != 0 )
            {
               WebComp_Popupcomponent.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418836752", true, true);
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
         context.AddJavascriptSource("entitymanagerticket.js", "?202418836754", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ComponentRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.AddJavascriptSource("UserControls/K2BT_ModalWindowRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblK2bpgmdesc_Internalname = "K2BPGMDESC";
         divTitleright_Internalname = "TITLERIGHT";
         divTitlecontainersection_Internalname = "TITLECONTAINERSECTION";
         lblBacktoworkwith_Internalname = "BACKTOWORKWITH";
         divBacktoworkwithcell_Internalname = "BACKTOWORKWITHCELL";
         divBacktoworkwithcontainertable_Internalname = "BACKTOWORKWITHCONTAINERTABLE";
         divBacktoworkwithcontainer_Internalname = "BACKTOWORKWITHCONTAINER";
         divComponentcontainer_general_Internalname = "COMPONENTCONTAINER_GENERAL";
         divComponentcontainer_satisfaccion_Internalname = "COMPONENTCONTAINER_SATISFACCION";
         divComponentstabcontainer_components_Internalname = "COMPONENTSTABCONTAINER_COMPONENTS";
         divTablayouts_Internalname = "TABLAYOUTS";
         divSection2_Internalname = "SECTION2";
         divComponents_components_tabssection_Internalname = "COMPONENTS_COMPONENTS_TABSSECTION";
         divContainercollapsiblesection_components_Internalname = "CONTAINERCOLLAPSIBLESECTION_COMPONENTS";
         divComponentscontainer_components_content_Internalname = "COMPONENTSCONTAINER_COMPONENTS_CONTENT";
         Componentscontainer_components_Internalname = "COMPONENTSCONTAINER_COMPONENTS";
         divTable3_Internalname = "TABLE3";
         divTable2_Internalname = "TABLE2";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divTablemodal_modalcontent_Internalname = "TABLEMODAL_MODALCONTENT";
         Tablemodal_Internalname = "TABLEMODAL";
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
         divComponentcontainer_satisfaccion_Visible = 1;
         divComponentcontainer_general_Visible = 1;
         lblBacktoworkwith_Link = "";
         lblBacktoworkwith_Caption = "";
         lblK2bpgmdesc_Caption = "Ticket";
         Tablemodal_Visible = Convert.ToBoolean( -1);
         Tablemodal_Modaltitle = "";
         Componentscontainer_components_Visible = Convert.ToBoolean( -1);
         Componentscontainer_components_Showborders = Convert.ToBoolean( 0);
         Componentscontainer_components_Open = Convert.ToBoolean( -1);
         Componentscontainer_components_Collapsible = Convert.ToBoolean( 0);
         Componentscontainer_components_Title = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Ticket";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV18AvailableComponents',fld:'vAVAILABLECOMPONENTS',pic:'',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true},{av:'AV20RelatedTransactionName',fld:'vRELATEDTRANSACTIONNAME',pic:'',hsh:true},{av:'AV27Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV20RelatedTransactionName',fld:'vRELATEDTRANSACTIONNAME',pic:'',hsh:true},{av:'Tablemodal_Visible',ctrl:'TABLEMODAL',prop:'Visible'},{av:'Tablemodal_Modaltitle',ctrl:'TABLEMODAL',prop:'ModalTitle'},{ctrl:'POPUPCOMPONENT'},{av:'AV18AvailableComponents',fld:'vAVAILABLECOMPONENTS',pic:'',hsh:true},{ctrl:'TABSTRIP'},{av:'divComponentcontainer_general_Visible',ctrl:'COMPONENTCONTAINER_GENERAL',prop:'Visible'},{av:'divComponentcontainer_satisfaccion_Visible',ctrl:'COMPONENTCONTAINER_SATISFACCION',prop:'Visible'},{av:'Componentscontainer_components_Visible',ctrl:'COMPONENTSCONTAINER_COMPONENTS',prop:'Visible'},{ctrl:'COMPONENTWC_GENERAL'},{ctrl:'COMPONENTWC_SATISFACCION'}]}");
         setEventMetadata("GLOBALEVENTS.K2BT_REFRESHENTITYMANAGER","{handler:'E142Q2',iparms:[{av:'AV22GE_ComponentName',fld:'vGE_COMPONENTNAME',pic:''},{av:'AV21GE_EntityManagerName',fld:'vGE_ENTITYMANAGERNAME',pic:''},{av:'AV27Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV6TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true}]");
         setEventMetadata("GLOBALEVENTS.K2BT_REFRESHENTITYMANAGER",",oparms:[{av:'divComponentcontainer_general_Visible',ctrl:'COMPONENTCONTAINER_GENERAL',prop:'Visible'},{ctrl:'COMPONENTWC_GENERAL'},{ctrl:'COMPONENTWC_SATISFACCION'},{av:'divComponentcontainer_satisfaccion_Visible',ctrl:'COMPONENTCONTAINER_SATISFACCION',prop:'Visible'}]}");
         setEventMetadata("TABLEMODAL.ONCLOSE","{handler:'E112Q2',iparms:[]");
         setEventMetadata("TABLEMODAL.ONCLOSE",",oparms:[]}");
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
         wcpOGx_mode = "";
         wcpOAV8TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV18AvailableComponents = new GxSimpleCollection<string>();
         AV20RelatedTransactionName = "";
         AV27Pgmname = "";
         GXKey = "";
         AV22GE_ComponentName = "";
         AV21GE_EntityManagerName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblK2bpgmdesc_Jsonclick = "";
         lblBacktoworkwith_Jsonclick = "";
         ucComponentscontainer_components = new GXUserControl();
         WebComp_Tabstrip_Component = "";
         OldTabstrip = "";
         WebComp_Componentwc_general_Component = "";
         OldComponentwc_general = "";
         WebComp_Componentwc_satisfaccion_Component = "";
         OldComponentwc_satisfaccion = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         ucTablemodal = new GXUserControl();
         WebComp_Popupcomponent_Component = "";
         OldPopupcomponent = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H002Q2_A14TicketId = new long[1] ;
         H002Q2_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         A46TicketFecha = DateTime.MinValue;
         AV16Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV17Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV5Context = new SdtK2BContext(context);
         AV19NextComponentCode = "";
         GXt_char2 = "";
         AV9TrnContext = new SdtK2BTrnContext(context);
         AV14CurrentUrl = "";
         AV10Tabs = new GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem>( context, "K2BTabOptionsItem", "kb_ticket");
         AV11Tab = new SdtK2BTabOptions_K2BTabOptionsItem(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.entitymanagerticket__default(),
            new Object[][] {
                new Object[] {
               H002Q2_A14TicketId, H002Q2_A46TicketFecha
               }
            }
         );
         WebComp_Tabstrip = new GeneXus.Http.GXNullWebComponent();
         WebComp_Componentwc_general = new GeneXus.Http.GXNullWebComponent();
         WebComp_Componentwc_satisfaccion = new GeneXus.Http.GXNullWebComponent();
         WebComp_Popupcomponent = new GeneXus.Http.GXNullWebComponent();
         AV27Pgmname = "EntityManagerTicket";
         /* GeneXus formulas. */
         AV27Pgmname = "EntityManagerTicket";
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV26GXLvl7 ;
      private short nGXWrapped ;
      private int divComponentcontainer_general_Visible ;
      private int divComponentcontainer_satisfaccion_Visible ;
      private int AV28GXV1 ;
      private int idxLst ;
      private long AV6TicketId ;
      private long wcpOAV6TicketId ;
      private long A14TicketId ;
      private string Gx_mode ;
      private string AV8TabCode ;
      private string wcpOGx_mode ;
      private string wcpOAV8TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV20RelatedTransactionName ;
      private string AV27Pgmname ;
      private string GXKey ;
      private string Componentscontainer_components_Title ;
      private string Tablemodal_Modaltitle ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTitlecontainersection_Internalname ;
      private string lblK2bpgmdesc_Internalname ;
      private string lblK2bpgmdesc_Caption ;
      private string lblK2bpgmdesc_Jsonclick ;
      private string divTitleright_Internalname ;
      private string divBacktoworkwithcontainer_Internalname ;
      private string divBacktoworkwithcontainertable_Internalname ;
      private string divBacktoworkwithcell_Internalname ;
      private string lblBacktoworkwith_Internalname ;
      private string lblBacktoworkwith_Caption ;
      private string lblBacktoworkwith_Link ;
      private string lblBacktoworkwith_Jsonclick ;
      private string divTable2_Internalname ;
      private string divTable3_Internalname ;
      private string Componentscontainer_components_Internalname ;
      private string divComponentscontainer_components_content_Internalname ;
      private string divContainercollapsiblesection_components_Internalname ;
      private string divComponents_components_tabssection_Internalname ;
      private string WebComp_Tabstrip_Component ;
      private string OldTabstrip ;
      private string divSection2_Internalname ;
      private string divTablayouts_Internalname ;
      private string divComponentstabcontainer_components_Internalname ;
      private string divComponentcontainer_general_Internalname ;
      private string WebComp_Componentwc_general_Component ;
      private string OldComponentwc_general ;
      private string divComponentcontainer_satisfaccion_Internalname ;
      private string WebComp_Componentwc_satisfaccion_Component ;
      private string OldComponentwc_satisfaccion ;
      private string K2bcontrolbeautify1_Internalname ;
      private string Tablemodal_Internalname ;
      private string divTablemodal_modalcontent_Internalname ;
      private string WebComp_Popupcomponent_Component ;
      private string OldPopupcomponent ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string AV19NextComponentCode ;
      private string GXt_char2 ;
      private DateTime A46TicketFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Componentscontainer_components_Collapsible ;
      private bool Componentscontainer_components_Open ;
      private bool Componentscontainer_components_Showborders ;
      private bool Componentscontainer_components_Visible ;
      private bool Tablemodal_Visible ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Popupcomponent ;
      private bool bDynCreated_Tabstrip ;
      private bool bDynCreated_Componentwc_general ;
      private bool bDynCreated_Componentwc_satisfaccion ;
      private string AV22GE_ComponentName ;
      private string AV21GE_EntityManagerName ;
      private string AV14CurrentUrl ;
      private GXWebComponent WebComp_Tabstrip ;
      private GXWebComponent WebComp_Componentwc_general ;
      private GXWebComponent WebComp_Componentwc_satisfaccion ;
      private GXWebComponent WebComp_Popupcomponent ;
      private GXUserControl ucComponentscontainer_components ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXUserControl ucTablemodal ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] H002Q2_A14TicketId ;
      private DateTime[] H002Q2_A46TicketFecha ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxSimpleCollection<string> AV18AvailableComponents ;
      private GXBaseCollection<SdtK2BTabOptions_K2BTabOptionsItem> AV10Tabs ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV16Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXWebForm Form ;
      private SdtK2BContext AV5Context ;
      private SdtK2BTrnContext AV9TrnContext ;
      private SdtK2BTabOptions_K2BTabOptionsItem AV11Tab ;
      private GeneXus.Utils.SdtMessages_Message AV17Message ;
   }

   public class entitymanagerticket__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH002Q2;
          prmH002Q2 = new Object[] {
          new ParDef("@AV6TicketId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002Q2", "SELECT TOP 1 [TicketId], [TicketFecha] FROM [Ticket] WHERE [TicketId] = @AV6TicketId ORDER BY [TicketId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002Q2,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                return;
       }
    }

 }

}
