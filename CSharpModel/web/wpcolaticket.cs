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
   public class wpcolaticket : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpcolaticket( )
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

      public wpcolaticket( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_UsuarioId ,
                           string aP1_UsuarioNombre ,
                           string aP2_UsuarioGerencia ,
                           string aP3_UsuarioDepartamento ,
                           string aP4_UsuarioRequerimiento )
      {
         this.AV5UsuarioId = aP0_UsuarioId;
         this.AV25UsuarioNombre = aP1_UsuarioNombre;
         this.AV28UsuarioGerencia = aP2_UsuarioGerencia;
         this.AV29UsuarioDepartamento = aP3_UsuarioDepartamento;
         this.AV30UsuarioRequerimiento = aP4_UsuarioRequerimiento;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavTicketlaptop = new GXCheckbox();
         chkavTicketdesktop = new GXCheckbox();
         chkavTicketmonitor = new GXCheckbox();
         chkavTicketimpresora = new GXCheckbox();
         chkavTicketescaner = new GXCheckbox();
         chkavTicketrouter = new GXCheckbox();
         chkavTicketsistemaoperativo = new GXCheckbox();
         chkavTicketoffice = new GXCheckbox();
         chkavTicketantivirus = new GXCheckbox();
         chkavTicketaplicacion = new GXCheckbox();
         chkavTicketdisenio = new GXCheckbox();
         chkavTicketingenieria = new GXCheckbox();
         chkavTicketdiscoduroexterno = new GXCheckbox();
         chkavTicketperifericos = new GXCheckbox();
         chkavTicketups = new GXCheckbox();
         chkavTicketapoyousuario = new GXCheckbox();
         chkavTicketinstalardatashow = new GXCheckbox();
         chkavTicketotros = new GXCheckbox();
         dynavResponsableid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "UsuarioId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vRESPONSABLEID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvRESPONSABLEID5L2( ) ;
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
               gxfirstwebparm = GetFirstPar( "UsuarioId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "UsuarioId");
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
               AV5UsuarioId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV5UsuarioId", StringUtil.LTrimStr( (decimal)(AV5UsuarioId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuarioId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV25UsuarioNombre = GetPar( "UsuarioNombre");
                  AssignAttri("", false, "AV25UsuarioNombre", AV25UsuarioNombre);
                  AV28UsuarioGerencia = GetPar( "UsuarioGerencia");
                  AssignAttri("", false, "AV28UsuarioGerencia", AV28UsuarioGerencia);
                  AV29UsuarioDepartamento = GetPar( "UsuarioDepartamento");
                  AssignAttri("", false, "AV29UsuarioDepartamento", AV29UsuarioDepartamento);
                  AV30UsuarioRequerimiento = GetPar( "UsuarioRequerimiento");
                  AssignAttri("", false, "AV30UsuarioRequerimiento", AV30UsuarioRequerimiento);
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
            return "wpcolaticket_Execute" ;
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
         PA5L2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5L2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418821760", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal K2BForm\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BForm\" data-gx-class=\"form-horizontal K2BForm\" novalidate action=\""+formatLink("wpcolaticket.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(AV25UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV28UsuarioGerencia)),UrlEncode(StringUtil.RTrim(AV29UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV30UsuarioRequerimiento))}, new string[] {"UsuarioId","UsuarioNombre","UsuarioGerencia","UsuarioDepartamento","UsuarioRequerimiento"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal K2BForm", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuarioId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuarioId), "ZZZZZZZZZ9"), context));
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
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal K2BForm" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE5L2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5L2( ) ;
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
         return formatLink("wpcolaticket.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(AV25UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV28UsuarioGerencia)),UrlEncode(StringUtil.RTrim(AV29UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV30UsuarioRequerimiento))}, new string[] {"UsuarioId","UsuarioNombre","UsuarioGerencia","UsuarioDepartamento","UsuarioRequerimiento"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPColaTicket" ;
      }

      public override string GetPgmdesc( )
      {
         return "Requerimiento de Soporte Técnico" ;
      }

      protected void WB5L0( )
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Usuario", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarionombre_Internalname, "Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV25UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV25UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavUsuarionombre_Forecolor)+";", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable8_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Gerencia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariogerencia_Internalname, "Usuario Gerencia", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariogerencia_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariogerencia_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavUsuariogerencia_Internalname, AV28UsuarioGerencia, "", "", 0, 1, edtavUsuariogerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable9_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Departamento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariodepartamento_Internalname, "Departamento", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariodepartamento_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariodepartamento_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavUsuariodepartamento_Internalname, AV29UsuarioDepartamento, "", "", 0, 1, edtavUsuariodepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPColaTicket.htm");
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
            GxWebStd.gx_div_start( context, divTable11_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuariorequerimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariorequerimiento_Internalname, "Requerimiento:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariorequerimiento_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariorequerimiento_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavUsuariorequerimiento_Internalname, AV30UsuarioRequerimiento, "", "", 0, 1, edtavUsuariorequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPColaTicket.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable16_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable17_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTicketmemorando_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketmemorando_Internalname, "Memorando:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketmemorando_Internalname, AV32TicketMemorando, StringUtil.RTrim( context.localUtil.Format( AV32TicketMemorando, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketmemorando_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTicketmemorando_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable18_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTicketfechahora_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketfechahora_Internalname, "Fecha / Hora:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTicketfechahora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTicketfechahora_Internalname, context.localUtil.TToC( AV34TicketFechaHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV34TicketFechaHora, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketfechahora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTicketfechahora_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPColaTicket.htm");
            GxWebStd.gx_bitmap( context, edtavTicketfechahora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTicketfechahora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPColaTicket.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Laptop", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock5_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketlaptop_Internalname, "Laptop", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketlaptop_Internalname, StringUtil.BoolToStr( AV7TicketLaptop), "", "Laptop", 1, chkavTicketlaptop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Desktop", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock8_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketdesktop_Internalname, "Desktop", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketdesktop_Internalname, StringUtil.BoolToStr( AV8TicketDesktop), "", "Desktop", 1, chkavTicketdesktop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(87, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,87);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Monitor", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock11_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketmonitor_Internalname, "Monitor", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketmonitor_Internalname, StringUtil.BoolToStr( AV9TicketMonitor), "", "Monitor", 1, chkavTicketmonitor.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(95, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,95);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Impresora", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock14_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketimpresora_Internalname, "Impresora", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketimpresora_Internalname, StringUtil.BoolToStr( AV10TicketImpresora), "", "Impresora", 1, chkavTicketimpresora.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,103);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Escaner", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock17_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketescaner_Internalname, "Escaner", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketescaner_Internalname, StringUtil.BoolToStr( AV11TicketEscaner), "", "Escaner", 1, chkavTicketescaner.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(111, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,111);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Internet/Router/Access Point", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock20_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketrouter_Internalname, "Router", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketrouter_Internalname, StringUtil.BoolToStr( AV12TicketRouter), "", "Router", 1, chkavTicketrouter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(119, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,119);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable12_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Sistema Operativo", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock6_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketsistemaoperativo_Internalname, "Sistema Operativo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketsistemaoperativo_Internalname, StringUtil.BoolToStr( AV13TicketSistemaOperativo), "", "Sistema Operativo", 1, chkavTicketsistemaoperativo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(127, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,127);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Office", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock9_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketoffice_Internalname, "Office", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 135,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketoffice_Internalname, StringUtil.BoolToStr( AV14TicketOffice), "", "Office", 1, chkavTicketoffice.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(135, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,135);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Antivirus", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock12_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketantivirus_Internalname, "Antivirus", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketantivirus_Internalname, StringUtil.BoolToStr( AV15TicketAntivirus), "", "Antivirus", 1, chkavTicketantivirus.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(143, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,143);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Aplicación", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock15_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketaplicacion_Internalname, "Aplicación", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketaplicacion_Internalname, StringUtil.BoolToStr( AV16TicketAplicacion), "", "Aplicación", 1, chkavTicketaplicacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(151, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,151);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Diseño", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock18_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketdisenio_Internalname, "Diseño", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 159,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketdisenio_Internalname, StringUtil.BoolToStr( AV17TicketDisenio), "", "Diseño", 1, chkavTicketdisenio.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(159, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,159);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Ingeniería", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock21_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketingenieria_Internalname, "Ingeniería", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 167,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketingenieria_Internalname, StringUtil.BoolToStr( AV18TicketIngenieria), "", "Ingeniería", 1, chkavTicketingenieria.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(167, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,167);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable13_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Disco Duro ", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock7_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketdiscoduroexterno_Internalname, "Disco Duro Externo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketdiscoduroexterno_Internalname, StringUtil.BoolToStr( AV19TicketDiscoDuroExterno), "", "Disco Duro Externo", 1, chkavTicketdiscoduroexterno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(175, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,175);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Periféricos", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock10_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketperifericos_Internalname, "Periféricos", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketperifericos_Internalname, StringUtil.BoolToStr( AV20TicketPerifericos), "", "Periféricos", 1, chkavTicketperifericos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(183, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,183);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "UPS", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock13_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketups_Internalname, "UPS", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketups_Internalname, StringUtil.BoolToStr( AV21TicketUps), "", "UPS", 1, chkavTicketups.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(191, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,191);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Apoyo a Usuario", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock16_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketapoyousuario_Internalname, "Apoyo a Usuario", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketapoyousuario_Internalname, StringUtil.BoolToStr( AV22TicketApoyoUsuario), "", "Apoyo a Usuario", 1, chkavTicketapoyousuario.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(199, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,199);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Instalación DataShow", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock19_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketinstalardatashow_Internalname, "Instalación DataShow", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketinstalardatashow_Internalname, StringUtil.BoolToStr( AV23TicketInstalarDataShow), "", "Instalación DataShow", 1, chkavTicketinstalardatashow.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(207, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,207);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Otros", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock22_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketotros_Internalname, "Otros", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 215,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketotros_Internalname, StringUtil.BoolToStr( AV24TicketOtros), "", "Otros", 1, chkavTicketotros.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(215, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,215);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable14_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable15_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Técnico Asignado", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavResponsableid_Internalname, "Responsable Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavResponsableid, dynavResponsableid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6ResponsableId), 4, 0)), 1, dynavResponsableid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavResponsableid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavResponsableid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,230);\"", "", true, 1, "HLP_WPColaTicket.htm");
            dynavResponsableid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6ResponsableId), 4, 0));
            AssignProp("", false, dynavResponsableid_Internalname, "Values", (string)(dynavResponsableid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            context.WriteHtmlText( "<hr/>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPColaTicket.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPColaTicket.htm");
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
         }
         wbLoad = true;
      }

      protected void START5L2( )
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
            Form.Meta.addItem("description", "Requerimiento de Soporte Técnico", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5L0( ) ;
      }

      protected void WS5L2( )
      {
         START5L2( ) ;
         EVT5L2( ) ;
      }

      protected void EVT5L2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E115L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E125L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E135L2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E145L2 ();
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

      protected void WE5L2( )
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

      protected void PA5L2( )
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
               GX_FocusControl = edtavTicketmemorando_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvRESPONSABLEID5L2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvRESPONSABLEID_data5L2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvRESPONSABLEID_html5L2( )
      {
         short gxdynajaxvalue;
         GXDLVvRESPONSABLEID_data5L2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavResponsableid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavResponsableid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavResponsableid.ItemCount > 0 )
         {
            AV6ResponsableId = (short)(NumberUtil.Val( dynavResponsableid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6ResponsableId), 4, 0))), "."));
            AssignAttri("", false, "AV6ResponsableId", StringUtil.LTrimStr( (decimal)(AV6ResponsableId), 4, 0));
         }
      }

      protected void GXDLVvRESPONSABLEID_data5L2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005L2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005L2_A6ResponsableId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005L2_A30ResponsableNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvRESPONSABLEID_html5L2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV7TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( AV7TicketLaptop));
         AssignAttri("", false, "AV7TicketLaptop", AV7TicketLaptop);
         AV8TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( AV8TicketDesktop));
         AssignAttri("", false, "AV8TicketDesktop", AV8TicketDesktop);
         AV9TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( AV9TicketMonitor));
         AssignAttri("", false, "AV9TicketMonitor", AV9TicketMonitor);
         AV10TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( AV10TicketImpresora));
         AssignAttri("", false, "AV10TicketImpresora", AV10TicketImpresora);
         AV11TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( AV11TicketEscaner));
         AssignAttri("", false, "AV11TicketEscaner", AV11TicketEscaner);
         AV12TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( AV12TicketRouter));
         AssignAttri("", false, "AV12TicketRouter", AV12TicketRouter);
         AV13TicketSistemaOperativo = StringUtil.StrToBool( StringUtil.BoolToStr( AV13TicketSistemaOperativo));
         AssignAttri("", false, "AV13TicketSistemaOperativo", AV13TicketSistemaOperativo);
         AV14TicketOffice = StringUtil.StrToBool( StringUtil.BoolToStr( AV14TicketOffice));
         AssignAttri("", false, "AV14TicketOffice", AV14TicketOffice);
         AV15TicketAntivirus = StringUtil.StrToBool( StringUtil.BoolToStr( AV15TicketAntivirus));
         AssignAttri("", false, "AV15TicketAntivirus", AV15TicketAntivirus);
         AV16TicketAplicacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV16TicketAplicacion));
         AssignAttri("", false, "AV16TicketAplicacion", AV16TicketAplicacion);
         AV17TicketDisenio = StringUtil.StrToBool( StringUtil.BoolToStr( AV17TicketDisenio));
         AssignAttri("", false, "AV17TicketDisenio", AV17TicketDisenio);
         AV18TicketIngenieria = StringUtil.StrToBool( StringUtil.BoolToStr( AV18TicketIngenieria));
         AssignAttri("", false, "AV18TicketIngenieria", AV18TicketIngenieria);
         AV19TicketDiscoDuroExterno = StringUtil.StrToBool( StringUtil.BoolToStr( AV19TicketDiscoDuroExterno));
         AssignAttri("", false, "AV19TicketDiscoDuroExterno", AV19TicketDiscoDuroExterno);
         AV20TicketPerifericos = StringUtil.StrToBool( StringUtil.BoolToStr( AV20TicketPerifericos));
         AssignAttri("", false, "AV20TicketPerifericos", AV20TicketPerifericos);
         AV21TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( AV21TicketUps));
         AssignAttri("", false, "AV21TicketUps", AV21TicketUps);
         AV22TicketApoyoUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( AV22TicketApoyoUsuario));
         AssignAttri("", false, "AV22TicketApoyoUsuario", AV22TicketApoyoUsuario);
         AV23TicketInstalarDataShow = StringUtil.StrToBool( StringUtil.BoolToStr( AV23TicketInstalarDataShow));
         AssignAttri("", false, "AV23TicketInstalarDataShow", AV23TicketInstalarDataShow);
         AV24TicketOtros = StringUtil.StrToBool( StringUtil.BoolToStr( AV24TicketOtros));
         AssignAttri("", false, "AV24TicketOtros", AV24TicketOtros);
         if ( dynavResponsableid.ItemCount > 0 )
         {
            AV6ResponsableId = (short)(NumberUtil.Val( dynavResponsableid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6ResponsableId), 4, 0))), "."));
            AssignAttri("", false, "AV6ResponsableId", StringUtil.LTrimStr( (decimal)(AV6ResponsableId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavResponsableid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6ResponsableId), 4, 0));
            AssignProp("", false, dynavResponsableid_Internalname, "Values", dynavResponsableid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5L2( ) ;
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

      protected void RF5L2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E145L2 ();
            WB5L0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5L2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuarioId), "ZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvRESPONSABLEID_html5L2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5L0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E135L2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV32TicketMemorando = cgiGet( edtavTicketmemorando_Internalname);
            AssignAttri("", false, "AV32TicketMemorando", AV32TicketMemorando);
            if ( context.localUtil.VCDateTime( cgiGet( edtavTicketfechahora_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Ticket Fecha Hora"}), 1, "vTICKETFECHAHORA");
               GX_FocusControl = edtavTicketfechahora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV34TicketFechaHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV34TicketFechaHora", context.localUtil.TToC( AV34TicketFechaHora, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               AV34TicketFechaHora = context.localUtil.CToT( cgiGet( edtavTicketfechahora_Internalname));
               AssignAttri("", false, "AV34TicketFechaHora", context.localUtil.TToC( AV34TicketFechaHora, 10, 8, 0, 3, "/", ":", " "));
            }
            AV7TicketLaptop = StringUtil.StrToBool( cgiGet( chkavTicketlaptop_Internalname));
            AssignAttri("", false, "AV7TicketLaptop", AV7TicketLaptop);
            AV8TicketDesktop = StringUtil.StrToBool( cgiGet( chkavTicketdesktop_Internalname));
            AssignAttri("", false, "AV8TicketDesktop", AV8TicketDesktop);
            AV9TicketMonitor = StringUtil.StrToBool( cgiGet( chkavTicketmonitor_Internalname));
            AssignAttri("", false, "AV9TicketMonitor", AV9TicketMonitor);
            AV10TicketImpresora = StringUtil.StrToBool( cgiGet( chkavTicketimpresora_Internalname));
            AssignAttri("", false, "AV10TicketImpresora", AV10TicketImpresora);
            AV11TicketEscaner = StringUtil.StrToBool( cgiGet( chkavTicketescaner_Internalname));
            AssignAttri("", false, "AV11TicketEscaner", AV11TicketEscaner);
            AV12TicketRouter = StringUtil.StrToBool( cgiGet( chkavTicketrouter_Internalname));
            AssignAttri("", false, "AV12TicketRouter", AV12TicketRouter);
            AV13TicketSistemaOperativo = StringUtil.StrToBool( cgiGet( chkavTicketsistemaoperativo_Internalname));
            AssignAttri("", false, "AV13TicketSistemaOperativo", AV13TicketSistemaOperativo);
            AV14TicketOffice = StringUtil.StrToBool( cgiGet( chkavTicketoffice_Internalname));
            AssignAttri("", false, "AV14TicketOffice", AV14TicketOffice);
            AV15TicketAntivirus = StringUtil.StrToBool( cgiGet( chkavTicketantivirus_Internalname));
            AssignAttri("", false, "AV15TicketAntivirus", AV15TicketAntivirus);
            AV16TicketAplicacion = StringUtil.StrToBool( cgiGet( chkavTicketaplicacion_Internalname));
            AssignAttri("", false, "AV16TicketAplicacion", AV16TicketAplicacion);
            AV17TicketDisenio = StringUtil.StrToBool( cgiGet( chkavTicketdisenio_Internalname));
            AssignAttri("", false, "AV17TicketDisenio", AV17TicketDisenio);
            AV18TicketIngenieria = StringUtil.StrToBool( cgiGet( chkavTicketingenieria_Internalname));
            AssignAttri("", false, "AV18TicketIngenieria", AV18TicketIngenieria);
            AV19TicketDiscoDuroExterno = StringUtil.StrToBool( cgiGet( chkavTicketdiscoduroexterno_Internalname));
            AssignAttri("", false, "AV19TicketDiscoDuroExterno", AV19TicketDiscoDuroExterno);
            AV20TicketPerifericos = StringUtil.StrToBool( cgiGet( chkavTicketperifericos_Internalname));
            AssignAttri("", false, "AV20TicketPerifericos", AV20TicketPerifericos);
            AV21TicketUps = StringUtil.StrToBool( cgiGet( chkavTicketups_Internalname));
            AssignAttri("", false, "AV21TicketUps", AV21TicketUps);
            AV22TicketApoyoUsuario = StringUtil.StrToBool( cgiGet( chkavTicketapoyousuario_Internalname));
            AssignAttri("", false, "AV22TicketApoyoUsuario", AV22TicketApoyoUsuario);
            AV23TicketInstalarDataShow = StringUtil.StrToBool( cgiGet( chkavTicketinstalardatashow_Internalname));
            AssignAttri("", false, "AV23TicketInstalarDataShow", AV23TicketInstalarDataShow);
            AV24TicketOtros = StringUtil.StrToBool( cgiGet( chkavTicketotros_Internalname));
            AssignAttri("", false, "AV24TicketOtros", AV24TicketOtros);
            dynavResponsableid.CurrentValue = cgiGet( dynavResponsableid_Internalname);
            AV6ResponsableId = (short)(NumberUtil.Val( cgiGet( dynavResponsableid_Internalname), "."));
            AssignAttri("", false, "AV6ResponsableId", StringUtil.LTrimStr( (decimal)(AV6ResponsableId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvRESPONSABLEID_html5L2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E115L2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         new pcrregistrarticket(context ).execute(  AV5UsuarioId,  AV6ResponsableId,  AV7TicketLaptop,  AV8TicketDesktop,  AV9TicketMonitor,  AV10TicketImpresora,  AV11TicketEscaner,  AV12TicketRouter,  AV13TicketSistemaOperativo,  AV14TicketOffice,  AV15TicketAntivirus,  AV16TicketAplicacion,  AV17TicketDisenio,  AV18TicketIngenieria,  AV19TicketDiscoDuroExterno,  AV20TicketPerifericos,  AV21TicketUps,  AV22TicketApoyoUsuario,  AV23TicketInstalarDataShow,  AV24TicketOtros,  AV32TicketMemorando,  AV34TicketFechaHora) ;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E125L2( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E135L2 ();
         if (returnInSub) return;
      }

      protected void E135L2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavUsuarionombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuarionombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuarionombre_Forecolor), 9, 0), true);
         edtavUsuariogerencia_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariogerencia_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariogerencia_Forecolor), 9, 0), true);
         edtavUsuariodepartamento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariodepartamento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariodepartamento_Forecolor), 9, 0), true);
         edtavUsuariorequerimiento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariorequerimiento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariorequerimiento_Forecolor), 9, 0), true);
         dynavResponsableid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavResponsableid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavResponsableid.ForeColor), 9, 0), true);
         lblTextblock5_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock5_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock5_Forecolor), 9, 0), true);
         lblTextblock6_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock6_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock6_Forecolor), 9, 0), true);
         lblTextblock7_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock7_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock7_Forecolor), 9, 0), true);
         lblTextblock8_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock8_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock8_Forecolor), 9, 0), true);
         lblTextblock9_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock9_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock9_Forecolor), 9, 0), true);
         lblTextblock10_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock10_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock10_Forecolor), 9, 0), true);
         lblTextblock11_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock11_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock11_Forecolor), 9, 0), true);
         lblTextblock12_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock12_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock12_Forecolor), 9, 0), true);
         lblTextblock13_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock13_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock13_Forecolor), 9, 0), true);
         lblTextblock14_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock14_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock14_Forecolor), 9, 0), true);
         lblTextblock15_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock15_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock15_Forecolor), 9, 0), true);
         lblTextblock16_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock16_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock16_Forecolor), 9, 0), true);
         lblTextblock17_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock17_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock17_Forecolor), 9, 0), true);
         lblTextblock18_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock18_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock18_Forecolor), 9, 0), true);
         lblTextblock19_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock19_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock19_Forecolor), 9, 0), true);
         lblTextblock20_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock20_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock20_Forecolor), 9, 0), true);
         lblTextblock21_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock21_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock21_Forecolor), 9, 0), true);
         lblTextblock22_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock22_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock22_Forecolor), 9, 0), true);
         AV34TicketFechaHora = DateTimeUtil.Now( context);
         AssignAttri("", false, "AV34TicketFechaHora", context.localUtil.TToC( AV34TicketFechaHora, 10, 8, 0, 3, "/", ":", " "));
      }

      protected void nextLoad( )
      {
      }

      protected void E145L2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5UsuarioId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV5UsuarioId", StringUtil.LTrimStr( (decimal)(AV5UsuarioId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5UsuarioId), "ZZZZZZZZZ9"), context));
         AV25UsuarioNombre = (string)getParm(obj,1);
         AssignAttri("", false, "AV25UsuarioNombre", AV25UsuarioNombre);
         AV28UsuarioGerencia = (string)getParm(obj,2);
         AssignAttri("", false, "AV28UsuarioGerencia", AV28UsuarioGerencia);
         AV29UsuarioDepartamento = (string)getParm(obj,3);
         AssignAttri("", false, "AV29UsuarioDepartamento", AV29UsuarioDepartamento);
         AV30UsuarioRequerimiento = (string)getParm(obj,4);
         AssignAttri("", false, "AV30UsuarioRequerimiento", AV30UsuarioRequerimiento);
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
         PA5L2( ) ;
         WS5L2( ) ;
         WE5L2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188211036", true, true);
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
         context.AddJavascriptSource("wpcolaticket.js", "?2024188211036", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavTicketlaptop.Name = "vTICKETLAPTOP";
         chkavTicketlaptop.WebTags = "";
         chkavTicketlaptop.Caption = "";
         AssignProp("", false, chkavTicketlaptop_Internalname, "TitleCaption", chkavTicketlaptop.Caption, true);
         chkavTicketlaptop.CheckedValue = "false";
         AV7TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( AV7TicketLaptop));
         AssignAttri("", false, "AV7TicketLaptop", AV7TicketLaptop);
         chkavTicketdesktop.Name = "vTICKETDESKTOP";
         chkavTicketdesktop.WebTags = "";
         chkavTicketdesktop.Caption = "";
         AssignProp("", false, chkavTicketdesktop_Internalname, "TitleCaption", chkavTicketdesktop.Caption, true);
         chkavTicketdesktop.CheckedValue = "false";
         AV8TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( AV8TicketDesktop));
         AssignAttri("", false, "AV8TicketDesktop", AV8TicketDesktop);
         chkavTicketmonitor.Name = "vTICKETMONITOR";
         chkavTicketmonitor.WebTags = "";
         chkavTicketmonitor.Caption = "";
         AssignProp("", false, chkavTicketmonitor_Internalname, "TitleCaption", chkavTicketmonitor.Caption, true);
         chkavTicketmonitor.CheckedValue = "false";
         AV9TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( AV9TicketMonitor));
         AssignAttri("", false, "AV9TicketMonitor", AV9TicketMonitor);
         chkavTicketimpresora.Name = "vTICKETIMPRESORA";
         chkavTicketimpresora.WebTags = "";
         chkavTicketimpresora.Caption = "";
         AssignProp("", false, chkavTicketimpresora_Internalname, "TitleCaption", chkavTicketimpresora.Caption, true);
         chkavTicketimpresora.CheckedValue = "false";
         AV10TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( AV10TicketImpresora));
         AssignAttri("", false, "AV10TicketImpresora", AV10TicketImpresora);
         chkavTicketescaner.Name = "vTICKETESCANER";
         chkavTicketescaner.WebTags = "";
         chkavTicketescaner.Caption = "";
         AssignProp("", false, chkavTicketescaner_Internalname, "TitleCaption", chkavTicketescaner.Caption, true);
         chkavTicketescaner.CheckedValue = "false";
         AV11TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( AV11TicketEscaner));
         AssignAttri("", false, "AV11TicketEscaner", AV11TicketEscaner);
         chkavTicketrouter.Name = "vTICKETROUTER";
         chkavTicketrouter.WebTags = "";
         chkavTicketrouter.Caption = "";
         AssignProp("", false, chkavTicketrouter_Internalname, "TitleCaption", chkavTicketrouter.Caption, true);
         chkavTicketrouter.CheckedValue = "false";
         AV12TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( AV12TicketRouter));
         AssignAttri("", false, "AV12TicketRouter", AV12TicketRouter);
         chkavTicketsistemaoperativo.Name = "vTICKETSISTEMAOPERATIVO";
         chkavTicketsistemaoperativo.WebTags = "";
         chkavTicketsistemaoperativo.Caption = "";
         AssignProp("", false, chkavTicketsistemaoperativo_Internalname, "TitleCaption", chkavTicketsistemaoperativo.Caption, true);
         chkavTicketsistemaoperativo.CheckedValue = "false";
         AV13TicketSistemaOperativo = StringUtil.StrToBool( StringUtil.BoolToStr( AV13TicketSistemaOperativo));
         AssignAttri("", false, "AV13TicketSistemaOperativo", AV13TicketSistemaOperativo);
         chkavTicketoffice.Name = "vTICKETOFFICE";
         chkavTicketoffice.WebTags = "";
         chkavTicketoffice.Caption = "";
         AssignProp("", false, chkavTicketoffice_Internalname, "TitleCaption", chkavTicketoffice.Caption, true);
         chkavTicketoffice.CheckedValue = "false";
         AV14TicketOffice = StringUtil.StrToBool( StringUtil.BoolToStr( AV14TicketOffice));
         AssignAttri("", false, "AV14TicketOffice", AV14TicketOffice);
         chkavTicketantivirus.Name = "vTICKETANTIVIRUS";
         chkavTicketantivirus.WebTags = "";
         chkavTicketantivirus.Caption = "";
         AssignProp("", false, chkavTicketantivirus_Internalname, "TitleCaption", chkavTicketantivirus.Caption, true);
         chkavTicketantivirus.CheckedValue = "false";
         AV15TicketAntivirus = StringUtil.StrToBool( StringUtil.BoolToStr( AV15TicketAntivirus));
         AssignAttri("", false, "AV15TicketAntivirus", AV15TicketAntivirus);
         chkavTicketaplicacion.Name = "vTICKETAPLICACION";
         chkavTicketaplicacion.WebTags = "";
         chkavTicketaplicacion.Caption = "";
         AssignProp("", false, chkavTicketaplicacion_Internalname, "TitleCaption", chkavTicketaplicacion.Caption, true);
         chkavTicketaplicacion.CheckedValue = "false";
         AV16TicketAplicacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV16TicketAplicacion));
         AssignAttri("", false, "AV16TicketAplicacion", AV16TicketAplicacion);
         chkavTicketdisenio.Name = "vTICKETDISENIO";
         chkavTicketdisenio.WebTags = "";
         chkavTicketdisenio.Caption = "";
         AssignProp("", false, chkavTicketdisenio_Internalname, "TitleCaption", chkavTicketdisenio.Caption, true);
         chkavTicketdisenio.CheckedValue = "false";
         AV17TicketDisenio = StringUtil.StrToBool( StringUtil.BoolToStr( AV17TicketDisenio));
         AssignAttri("", false, "AV17TicketDisenio", AV17TicketDisenio);
         chkavTicketingenieria.Name = "vTICKETINGENIERIA";
         chkavTicketingenieria.WebTags = "";
         chkavTicketingenieria.Caption = "";
         AssignProp("", false, chkavTicketingenieria_Internalname, "TitleCaption", chkavTicketingenieria.Caption, true);
         chkavTicketingenieria.CheckedValue = "false";
         AV18TicketIngenieria = StringUtil.StrToBool( StringUtil.BoolToStr( AV18TicketIngenieria));
         AssignAttri("", false, "AV18TicketIngenieria", AV18TicketIngenieria);
         chkavTicketdiscoduroexterno.Name = "vTICKETDISCODUROEXTERNO";
         chkavTicketdiscoduroexterno.WebTags = "";
         chkavTicketdiscoduroexterno.Caption = "";
         AssignProp("", false, chkavTicketdiscoduroexterno_Internalname, "TitleCaption", chkavTicketdiscoduroexterno.Caption, true);
         chkavTicketdiscoduroexterno.CheckedValue = "false";
         AV19TicketDiscoDuroExterno = StringUtil.StrToBool( StringUtil.BoolToStr( AV19TicketDiscoDuroExterno));
         AssignAttri("", false, "AV19TicketDiscoDuroExterno", AV19TicketDiscoDuroExterno);
         chkavTicketperifericos.Name = "vTICKETPERIFERICOS";
         chkavTicketperifericos.WebTags = "";
         chkavTicketperifericos.Caption = "";
         AssignProp("", false, chkavTicketperifericos_Internalname, "TitleCaption", chkavTicketperifericos.Caption, true);
         chkavTicketperifericos.CheckedValue = "false";
         AV20TicketPerifericos = StringUtil.StrToBool( StringUtil.BoolToStr( AV20TicketPerifericos));
         AssignAttri("", false, "AV20TicketPerifericos", AV20TicketPerifericos);
         chkavTicketups.Name = "vTICKETUPS";
         chkavTicketups.WebTags = "";
         chkavTicketups.Caption = "";
         AssignProp("", false, chkavTicketups_Internalname, "TitleCaption", chkavTicketups.Caption, true);
         chkavTicketups.CheckedValue = "false";
         AV21TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( AV21TicketUps));
         AssignAttri("", false, "AV21TicketUps", AV21TicketUps);
         chkavTicketapoyousuario.Name = "vTICKETAPOYOUSUARIO";
         chkavTicketapoyousuario.WebTags = "";
         chkavTicketapoyousuario.Caption = "";
         AssignProp("", false, chkavTicketapoyousuario_Internalname, "TitleCaption", chkavTicketapoyousuario.Caption, true);
         chkavTicketapoyousuario.CheckedValue = "false";
         AV22TicketApoyoUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( AV22TicketApoyoUsuario));
         AssignAttri("", false, "AV22TicketApoyoUsuario", AV22TicketApoyoUsuario);
         chkavTicketinstalardatashow.Name = "vTICKETINSTALARDATASHOW";
         chkavTicketinstalardatashow.WebTags = "";
         chkavTicketinstalardatashow.Caption = "";
         AssignProp("", false, chkavTicketinstalardatashow_Internalname, "TitleCaption", chkavTicketinstalardatashow.Caption, true);
         chkavTicketinstalardatashow.CheckedValue = "false";
         AV23TicketInstalarDataShow = StringUtil.StrToBool( StringUtil.BoolToStr( AV23TicketInstalarDataShow));
         AssignAttri("", false, "AV23TicketInstalarDataShow", AV23TicketInstalarDataShow);
         chkavTicketotros.Name = "vTICKETOTROS";
         chkavTicketotros.WebTags = "";
         chkavTicketotros.Caption = "";
         AssignProp("", false, chkavTicketotros_Internalname, "TitleCaption", chkavTicketotros.Caption, true);
         chkavTicketotros.CheckedValue = "false";
         AV24TicketOtros = StringUtil.StrToBool( StringUtil.BoolToStr( AV24TicketOtros));
         AssignAttri("", false, "AV24TicketOtros", AV24TicketOtros);
         dynavResponsableid.Name = "vRESPONSABLEID";
         dynavResponsableid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divTable7_Internalname = "TABLE7";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtavUsuariogerencia_Internalname = "vUSUARIOGERENCIA";
         divTable8_Internalname = "TABLE8";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtavUsuariodepartamento_Internalname = "vUSUARIODEPARTAMENTO";
         divTable9_Internalname = "TABLE9";
         edtavUsuariorequerimiento_Internalname = "vUSUARIOREQUERIMIENTO";
         divTable11_Internalname = "TABLE11";
         edtavTicketmemorando_Internalname = "vTICKETMEMORANDO";
         divTable17_Internalname = "TABLE17";
         edtavTicketfechahora_Internalname = "vTICKETFECHAHORA";
         divTable18_Internalname = "TABLE18";
         divTable16_Internalname = "TABLE16";
         divTable6_Internalname = "TABLE6";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         chkavTicketlaptop_Internalname = "vTICKETLAPTOP";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         chkavTicketdesktop_Internalname = "vTICKETDESKTOP";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         chkavTicketmonitor_Internalname = "vTICKETMONITOR";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         chkavTicketimpresora_Internalname = "vTICKETIMPRESORA";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         chkavTicketescaner_Internalname = "vTICKETESCANER";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         chkavTicketrouter_Internalname = "vTICKETROUTER";
         divTable10_Internalname = "TABLE10";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         chkavTicketsistemaoperativo_Internalname = "vTICKETSISTEMAOPERATIVO";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         chkavTicketoffice_Internalname = "vTICKETOFFICE";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         chkavTicketantivirus_Internalname = "vTICKETANTIVIRUS";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         chkavTicketaplicacion_Internalname = "vTICKETAPLICACION";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         chkavTicketdisenio_Internalname = "vTICKETDISENIO";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         chkavTicketingenieria_Internalname = "vTICKETINGENIERIA";
         divTable12_Internalname = "TABLE12";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         chkavTicketdiscoduroexterno_Internalname = "vTICKETDISCODUROEXTERNO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         chkavTicketperifericos_Internalname = "vTICKETPERIFERICOS";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         chkavTicketups_Internalname = "vTICKETUPS";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         chkavTicketapoyousuario_Internalname = "vTICKETAPOYOUSUARIO";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         chkavTicketinstalardatashow_Internalname = "vTICKETINSTALARDATASHOW";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         chkavTicketotros_Internalname = "vTICKETOTROS";
         divTable13_Internalname = "TABLE13";
         divTable5_Internalname = "TABLE5";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         dynavResponsableid_Internalname = "vRESPONSABLEID";
         divTable15_Internalname = "TABLE15";
         divTable14_Internalname = "TABLE14";
         bttGuardar_Internalname = "GUARDAR";
         divTable3_Internalname = "TABLE3";
         bttCancelar_Internalname = "CANCELAR";
         divTable4_Internalname = "TABLE4";
         divTable2_Internalname = "TABLE2";
         divTable1_Internalname = "TABLE1";
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
         chkavTicketotros.Caption = "Otros";
         chkavTicketinstalardatashow.Caption = "Instalación DataShow";
         chkavTicketapoyousuario.Caption = "Apoyo a Usuario";
         chkavTicketups.Caption = "UPS";
         chkavTicketperifericos.Caption = "Periféricos";
         chkavTicketdiscoduroexterno.Caption = "Disco Duro Externo";
         chkavTicketingenieria.Caption = "Ingeniería";
         chkavTicketdisenio.Caption = "Diseño";
         chkavTicketaplicacion.Caption = "Aplicación";
         chkavTicketantivirus.Caption = "Antivirus";
         chkavTicketoffice.Caption = "Office";
         chkavTicketsistemaoperativo.Caption = "Sistema Operativo";
         chkavTicketrouter.Caption = "Router";
         chkavTicketescaner.Caption = "Escaner";
         chkavTicketimpresora.Caption = "Impresora";
         chkavTicketmonitor.Caption = "Monitor";
         chkavTicketdesktop.Caption = "Desktop";
         chkavTicketlaptop.Caption = "Laptop";
         dynavResponsableid_Jsonclick = "";
         dynavResponsableid.Enabled = 1;
         dynavResponsableid.ForeColor = (int)(0x000000);
         chkavTicketotros.Enabled = 1;
         lblTextblock22_Forecolor = (int)(0x000000);
         chkavTicketinstalardatashow.Enabled = 1;
         lblTextblock19_Forecolor = (int)(0x000000);
         chkavTicketapoyousuario.Enabled = 1;
         lblTextblock16_Forecolor = (int)(0x000000);
         chkavTicketups.Enabled = 1;
         lblTextblock13_Forecolor = (int)(0x000000);
         chkavTicketperifericos.Enabled = 1;
         lblTextblock10_Forecolor = (int)(0x000000);
         chkavTicketdiscoduroexterno.Enabled = 1;
         lblTextblock7_Forecolor = (int)(0x000000);
         chkavTicketingenieria.Enabled = 1;
         lblTextblock21_Forecolor = (int)(0x000000);
         chkavTicketdisenio.Enabled = 1;
         lblTextblock18_Forecolor = (int)(0x000000);
         chkavTicketaplicacion.Enabled = 1;
         lblTextblock15_Forecolor = (int)(0x000000);
         chkavTicketantivirus.Enabled = 1;
         lblTextblock12_Forecolor = (int)(0x000000);
         chkavTicketoffice.Enabled = 1;
         lblTextblock9_Forecolor = (int)(0x000000);
         chkavTicketsistemaoperativo.Enabled = 1;
         lblTextblock6_Forecolor = (int)(0x000000);
         chkavTicketrouter.Enabled = 1;
         lblTextblock20_Forecolor = (int)(0x000000);
         chkavTicketescaner.Enabled = 1;
         lblTextblock17_Forecolor = (int)(0x000000);
         chkavTicketimpresora.Enabled = 1;
         lblTextblock14_Forecolor = (int)(0x000000);
         chkavTicketmonitor.Enabled = 1;
         lblTextblock11_Forecolor = (int)(0x000000);
         chkavTicketdesktop.Enabled = 1;
         lblTextblock8_Forecolor = (int)(0x000000);
         chkavTicketlaptop.Enabled = 1;
         lblTextblock5_Forecolor = (int)(0x000000);
         edtavTicketfechahora_Jsonclick = "";
         edtavTicketfechahora_Enabled = 1;
         edtavTicketmemorando_Jsonclick = "";
         edtavTicketmemorando_Enabled = 1;
         edtavUsuariorequerimiento_Forecolor = (int)(0x000000);
         edtavUsuariorequerimiento_Enabled = 0;
         edtavUsuariodepartamento_Forecolor = (int)(0x000000);
         edtavUsuariodepartamento_Enabled = 0;
         edtavUsuariogerencia_Forecolor = (int)(0x000000);
         edtavUsuariogerencia_Enabled = 0;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Forecolor = (int)(0x000000);
         edtavUsuarionombre_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Requerimiento de Soporte Técnico";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV5UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]}");
         setEventMetadata("'GUARDAR'","{handler:'E115L2',iparms:[{av:'AV5UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV32TicketMemorando',fld:'vTICKETMEMORANDO',pic:''},{av:'AV34TicketFechaHora',fld:'vTICKETFECHAHORA',pic:'99/99/9999 99:99:99'},{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E125L2',iparms:[{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]}");
         setEventMetadata("VALIDV_TICKETFECHAHORA","{handler:'Validv_Ticketfechahora',iparms:[{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]");
         setEventMetadata("VALIDV_TICKETFECHAHORA",",oparms:[{av:'dynavResponsableid'},{av:'AV6ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV7TicketLaptop',fld:'vTICKETLAPTOP',pic:''},{av:'AV8TicketDesktop',fld:'vTICKETDESKTOP',pic:''},{av:'AV9TicketMonitor',fld:'vTICKETMONITOR',pic:''},{av:'AV10TicketImpresora',fld:'vTICKETIMPRESORA',pic:''},{av:'AV11TicketEscaner',fld:'vTICKETESCANER',pic:''},{av:'AV12TicketRouter',fld:'vTICKETROUTER',pic:''},{av:'AV13TicketSistemaOperativo',fld:'vTICKETSISTEMAOPERATIVO',pic:''},{av:'AV14TicketOffice',fld:'vTICKETOFFICE',pic:''},{av:'AV15TicketAntivirus',fld:'vTICKETANTIVIRUS',pic:''},{av:'AV16TicketAplicacion',fld:'vTICKETAPLICACION',pic:''},{av:'AV17TicketDisenio',fld:'vTICKETDISENIO',pic:''},{av:'AV18TicketIngenieria',fld:'vTICKETINGENIERIA',pic:''},{av:'AV19TicketDiscoDuroExterno',fld:'vTICKETDISCODUROEXTERNO',pic:''},{av:'AV20TicketPerifericos',fld:'vTICKETPERIFERICOS',pic:''},{av:'AV21TicketUps',fld:'vTICKETUPS',pic:''},{av:'AV22TicketApoyoUsuario',fld:'vTICKETAPOYOUSUARIO',pic:''},{av:'AV23TicketInstalarDataShow',fld:'vTICKETINSTALARDATASHOW',pic:''},{av:'AV24TicketOtros',fld:'vTICKETOTROS',pic:''}]}");
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
         wcpOAV25UsuarioNombre = "";
         wcpOAV28UsuarioGerencia = "";
         wcpOAV29UsuarioDepartamento = "";
         wcpOAV30UsuarioRequerimiento = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock3_Jsonclick = "";
         TempTags = "";
         AV32TicketMemorando = "";
         AV34TicketFechaHora = (DateTime)(DateTime.MinValue);
         lblTextblock5_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         bttGuardar_Jsonclick = "";
         bttCancelar_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H005L2_A6ResponsableId = new short[1] ;
         H005L2_A30ResponsableNombre = new string[] {""} ;
         H005L2_A26ResponsableActivo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpcolaticket__default(),
            new Object[][] {
                new Object[] {
               H005L2_A6ResponsableId, H005L2_A30ResponsableNombre, H005L2_A26ResponsableActivo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV6ResponsableId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavUsuarionombre_Forecolor ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuariogerencia_Forecolor ;
      private int edtavUsuariogerencia_Enabled ;
      private int edtavUsuariodepartamento_Forecolor ;
      private int edtavUsuariodepartamento_Enabled ;
      private int edtavUsuariorequerimiento_Forecolor ;
      private int edtavUsuariorequerimiento_Enabled ;
      private int edtavTicketmemorando_Enabled ;
      private int edtavTicketfechahora_Enabled ;
      private int lblTextblock5_Forecolor ;
      private int lblTextblock8_Forecolor ;
      private int lblTextblock11_Forecolor ;
      private int lblTextblock14_Forecolor ;
      private int lblTextblock17_Forecolor ;
      private int lblTextblock20_Forecolor ;
      private int lblTextblock6_Forecolor ;
      private int lblTextblock9_Forecolor ;
      private int lblTextblock12_Forecolor ;
      private int lblTextblock15_Forecolor ;
      private int lblTextblock18_Forecolor ;
      private int lblTextblock21_Forecolor ;
      private int lblTextblock7_Forecolor ;
      private int lblTextblock10_Forecolor ;
      private int lblTextblock13_Forecolor ;
      private int lblTextblock16_Forecolor ;
      private int lblTextblock19_Forecolor ;
      private int lblTextblock22_Forecolor ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV5UsuarioId ;
      private long wcpOAV5UsuarioId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable1_Internalname ;
      private string divTable6_Internalname ;
      private string divTable7_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divTable8_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtavUsuariogerencia_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable9_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtavUsuariodepartamento_Internalname ;
      private string divTable11_Internalname ;
      private string edtavUsuariorequerimiento_Internalname ;
      private string divTable16_Internalname ;
      private string divTable17_Internalname ;
      private string edtavTicketmemorando_Internalname ;
      private string TempTags ;
      private string edtavTicketmemorando_Jsonclick ;
      private string divTable18_Internalname ;
      private string edtavTicketfechahora_Internalname ;
      private string edtavTicketfechahora_Jsonclick ;
      private string divTable5_Internalname ;
      private string divTable10_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string chkavTicketlaptop_Internalname ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string chkavTicketdesktop_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string chkavTicketmonitor_Internalname ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string chkavTicketimpresora_Internalname ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string chkavTicketescaner_Internalname ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string chkavTicketrouter_Internalname ;
      private string divTable12_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string chkavTicketsistemaoperativo_Internalname ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string chkavTicketoffice_Internalname ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string chkavTicketantivirus_Internalname ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string chkavTicketaplicacion_Internalname ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string chkavTicketdisenio_Internalname ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string chkavTicketingenieria_Internalname ;
      private string divTable13_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string chkavTicketdiscoduroexterno_Internalname ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string chkavTicketperifericos_Internalname ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string chkavTicketups_Internalname ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string chkavTicketapoyousuario_Internalname ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string chkavTicketinstalardatashow_Internalname ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string chkavTicketotros_Internalname ;
      private string divTable14_Internalname ;
      private string divTable15_Internalname ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string dynavResponsableid_Internalname ;
      private string dynavResponsableid_Jsonclick ;
      private string divTable2_Internalname ;
      private string divTable3_Internalname ;
      private string bttGuardar_Internalname ;
      private string bttGuardar_Jsonclick ;
      private string divTable4_Internalname ;
      private string bttCancelar_Internalname ;
      private string bttCancelar_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private DateTime AV34TicketFechaHora ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV7TicketLaptop ;
      private bool AV8TicketDesktop ;
      private bool AV9TicketMonitor ;
      private bool AV10TicketImpresora ;
      private bool AV11TicketEscaner ;
      private bool AV12TicketRouter ;
      private bool AV13TicketSistemaOperativo ;
      private bool AV14TicketOffice ;
      private bool AV15TicketAntivirus ;
      private bool AV16TicketAplicacion ;
      private bool AV17TicketDisenio ;
      private bool AV18TicketIngenieria ;
      private bool AV19TicketDiscoDuroExterno ;
      private bool AV20TicketPerifericos ;
      private bool AV21TicketUps ;
      private bool AV22TicketApoyoUsuario ;
      private bool AV23TicketInstalarDataShow ;
      private bool AV24TicketOtros ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV25UsuarioNombre ;
      private string AV28UsuarioGerencia ;
      private string AV29UsuarioDepartamento ;
      private string AV30UsuarioRequerimiento ;
      private string wcpOAV25UsuarioNombre ;
      private string wcpOAV28UsuarioGerencia ;
      private string wcpOAV29UsuarioDepartamento ;
      private string wcpOAV30UsuarioRequerimiento ;
      private string AV32TicketMemorando ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavTicketlaptop ;
      private GXCheckbox chkavTicketdesktop ;
      private GXCheckbox chkavTicketmonitor ;
      private GXCheckbox chkavTicketimpresora ;
      private GXCheckbox chkavTicketescaner ;
      private GXCheckbox chkavTicketrouter ;
      private GXCheckbox chkavTicketsistemaoperativo ;
      private GXCheckbox chkavTicketoffice ;
      private GXCheckbox chkavTicketantivirus ;
      private GXCheckbox chkavTicketaplicacion ;
      private GXCheckbox chkavTicketdisenio ;
      private GXCheckbox chkavTicketingenieria ;
      private GXCheckbox chkavTicketdiscoduroexterno ;
      private GXCheckbox chkavTicketperifericos ;
      private GXCheckbox chkavTicketups ;
      private GXCheckbox chkavTicketapoyousuario ;
      private GXCheckbox chkavTicketinstalardatashow ;
      private GXCheckbox chkavTicketotros ;
      private GXCombobox dynavResponsableid ;
      private IDataStoreProvider pr_default ;
      private short[] H005L2_A6ResponsableId ;
      private string[] H005L2_A30ResponsableNombre ;
      private bool[] H005L2_A26ResponsableActivo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wpcolaticket__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005L2;
          prmH005L2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005L2", "SELECT [ResponsableId], [ResponsableNombre], [ResponsableActivo] FROM [Responsable] WHERE [ResponsableActivo] = 1 ORDER BY [ResponsableNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005L2,0, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

}
