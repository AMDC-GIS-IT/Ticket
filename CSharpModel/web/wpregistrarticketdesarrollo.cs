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
   public class wpregistrarticketdesarrollo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpregistrarticketdesarrollo( )
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

      public wpregistrarticketdesarrollo( IGxContext context )
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
         this.AV27UsuarioId = aP0_UsuarioId;
         this.AV28UsuarioNombre = aP1_UsuarioNombre;
         this.AV26UsuarioGerencia = aP2_UsuarioGerencia;
         this.AV25UsuarioDepartamento = aP3_UsuarioDepartamento;
         this.AV29UsuarioRequerimiento = aP4_UsuarioRequerimiento;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavTicketanalisisdeproceso = new GXCheckbox();
         chkavTicketdesarrollodesistema = new GXCheckbox();
         chkavTicketelaboraciondedocumentacion = new GXCheckbox();
         chkavTicketmantenimientosistema = new GXCheckbox();
         chkavTicketdisenioconceptual = new GXCheckbox();
         chkavTicketdesarrolloypruebasiniciales = new GXCheckbox();
         chkavTicketimplementacion = new GXCheckbox();
         chkavTicketadministradorbasedatos = new GXCheckbox();
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
               GXDLVvRESPONSABLEID7C2( ) ;
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
               AV27UsuarioId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV27UsuarioId", StringUtil.LTrimStr( (decimal)(AV27UsuarioId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV28UsuarioNombre = GetPar( "UsuarioNombre");
                  AssignAttri("", false, "AV28UsuarioNombre", AV28UsuarioNombre);
                  AV26UsuarioGerencia = GetPar( "UsuarioGerencia");
                  AssignAttri("", false, "AV26UsuarioGerencia", AV26UsuarioGerencia);
                  AV25UsuarioDepartamento = GetPar( "UsuarioDepartamento");
                  AssignAttri("", false, "AV25UsuarioDepartamento", AV25UsuarioDepartamento);
                  AV29UsuarioRequerimiento = GetPar( "UsuarioRequerimiento");
                  AssignAttri("", false, "AV29UsuarioRequerimiento", AV29UsuarioRequerimiento);
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
            return "wpregistrarticketdesarrollo_Execute" ;
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
         PA7C2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7C2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418821499", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal K2BForm\" data-gx-class=\"form-horizontal K2BForm\" novalidate action=\""+formatLink("wpregistrarticketdesarrollo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV27UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(AV28UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV26UsuarioGerencia)),UrlEncode(StringUtil.RTrim(AV25UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV29UsuarioRequerimiento))}, new string[] {"UsuarioId","UsuarioNombre","UsuarioGerencia","UsuarioDepartamento","UsuarioRequerimiento"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZZ9"), context));
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
            WE7C2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7C2( ) ;
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
         return formatLink("wpregistrarticketdesarrollo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV27UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(AV28UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV26UsuarioGerencia)),UrlEncode(StringUtil.RTrim(AV25UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV29UsuarioRequerimiento))}, new string[] {"UsuarioId","UsuarioNombre","UsuarioGerencia","UsuarioDepartamento","UsuarioRequerimiento"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegistrarTicketDesarrollo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Registrar Trabajo Departamento Desarrollo" ;
      }

      protected void WB7C0( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Usuario", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV28UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV28UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPRegistrarTicketDesarrollo.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Gerencia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavUsuariogerencia_Internalname, AV26UsuarioGerencia, "", "", 0, 1, edtavUsuariogerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Departamento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavUsuariodepartamento_Internalname, AV25UsuarioDepartamento, "", "", 0, 1, edtavUsuariodepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Requerimiento", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariorequerimiento_Internalname, "Requerimiento", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavUsuariorequerimiento_Internalname, AV29UsuarioRequerimiento, "", "", 0, 1, edtavUsuariorequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Análisis de Proceso", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketanalisisdeproceso_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketanalisisdeproceso_Internalname, StringUtil.BoolToStr( AV31TicketAnalisisDeProceso), "", "", 1, chkavTicketanalisisdeproceso.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(64, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,64);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Desarrollo de Sistema", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketdesarrollodesistema_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketdesarrollodesistema_Internalname, StringUtil.BoolToStr( AV33TicketDesarrolloDeSistema), "", "", 1, chkavTicketdesarrollodesistema.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,73);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Elaboración de Documentación", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketelaboraciondedocumentacion_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketelaboraciondedocumentacion_Internalname, StringUtil.BoolToStr( AV36TicketElaboraciondeDocumentacion), "", "", 1, chkavTicketelaboraciondedocumentacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Mantenimiento de Sistema", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketmantenimientosistema_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketmantenimientosistema_Internalname, StringUtil.BoolToStr( AV38TicketMantenimientoSistema), "", "", 1, chkavTicketmantenimientosistema.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable12_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Diseño Conceptual", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketdisenioconceptual_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketdisenioconceptual_Internalname, StringUtil.BoolToStr( AV32TicketDisenioConceptual), "", "", 1, chkavTicketdisenioconceptual.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Desarrollo y Pruebas Iniciales", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketdesarrolloypruebasiniciales_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketdesarrolloypruebasiniciales_Internalname, StringUtil.BoolToStr( AV34TicketDesarrolloyPruebasIniciales), "", "", 1, chkavTicketdesarrolloypruebasiniciales.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Implementación", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketimplementacion_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketimplementacion_Internalname, StringUtil.BoolToStr( AV37TicketImplementacion), "", "", 1, chkavTicketimplementacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Administrador de Base Datos", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketadministradorbasedatos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketadministradorbasedatos_Internalname, StringUtil.BoolToStr( AV39TicketAdministradorBaseDatos), "", "", 1, chkavTicketadministradorbasedatos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(127, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,127);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Técnico Asignado", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarTicketDesarrollo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavResponsableid, dynavResponsableid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5ResponsableId), 4, 0)), 1, dynavResponsableid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavResponsableid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "", true, 1, "HLP_WPRegistrarTicketDesarrollo.htm");
            dynavResponsableid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ResponsableId), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarTicketDesarrollo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarTicketDesarrollo.htm");
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

      protected void START7C2( )
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
            Form.Meta.addItem("description", "Registrar Trabajo Departamento Desarrollo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7C0( ) ;
      }

      protected void WS7C2( )
      {
         START7C2( ) ;
         EVT7C2( ) ;
      }

      protected void EVT7C2( )
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
                              E117C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E127C2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E137C2 ();
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

      protected void WE7C2( )
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

      protected void PA7C2( )
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
               GX_FocusControl = chkavTicketanalisisdeproceso_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvRESPONSABLEID7C2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvRESPONSABLEID_data7C2( ) ;
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

      protected void GXVvRESPONSABLEID_html7C2( )
      {
         short gxdynajaxvalue;
         GXDLVvRESPONSABLEID_data7C2( ) ;
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
            AV5ResponsableId = (short)(NumberUtil.Val( dynavResponsableid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5ResponsableId), 4, 0))), "."));
            AssignAttri("", false, "AV5ResponsableId", StringUtil.LTrimStr( (decimal)(AV5ResponsableId), 4, 0));
         }
      }

      protected void GXDLVvRESPONSABLEID_data7C2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H007C2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007C2_A6ResponsableId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007C2_A30ResponsableNombre[0]);
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
            GXVvRESPONSABLEID_html7C2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV31TicketAnalisisDeProceso = StringUtil.StrToBool( StringUtil.BoolToStr( AV31TicketAnalisisDeProceso));
         AssignAttri("", false, "AV31TicketAnalisisDeProceso", AV31TicketAnalisisDeProceso);
         AV33TicketDesarrolloDeSistema = StringUtil.StrToBool( StringUtil.BoolToStr( AV33TicketDesarrolloDeSistema));
         AssignAttri("", false, "AV33TicketDesarrolloDeSistema", AV33TicketDesarrolloDeSistema);
         AV36TicketElaboraciondeDocumentacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV36TicketElaboraciondeDocumentacion));
         AssignAttri("", false, "AV36TicketElaboraciondeDocumentacion", AV36TicketElaboraciondeDocumentacion);
         AV38TicketMantenimientoSistema = StringUtil.StrToBool( StringUtil.BoolToStr( AV38TicketMantenimientoSistema));
         AssignAttri("", false, "AV38TicketMantenimientoSistema", AV38TicketMantenimientoSistema);
         AV32TicketDisenioConceptual = StringUtil.StrToBool( StringUtil.BoolToStr( AV32TicketDisenioConceptual));
         AssignAttri("", false, "AV32TicketDisenioConceptual", AV32TicketDisenioConceptual);
         AV34TicketDesarrolloyPruebasIniciales = StringUtil.StrToBool( StringUtil.BoolToStr( AV34TicketDesarrolloyPruebasIniciales));
         AssignAttri("", false, "AV34TicketDesarrolloyPruebasIniciales", AV34TicketDesarrolloyPruebasIniciales);
         AV37TicketImplementacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV37TicketImplementacion));
         AssignAttri("", false, "AV37TicketImplementacion", AV37TicketImplementacion);
         AV39TicketAdministradorBaseDatos = StringUtil.StrToBool( StringUtil.BoolToStr( AV39TicketAdministradorBaseDatos));
         AssignAttri("", false, "AV39TicketAdministradorBaseDatos", AV39TicketAdministradorBaseDatos);
         if ( dynavResponsableid.ItemCount > 0 )
         {
            AV5ResponsableId = (short)(NumberUtil.Val( dynavResponsableid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5ResponsableId), 4, 0))), "."));
            AssignAttri("", false, "AV5ResponsableId", StringUtil.LTrimStr( (decimal)(AV5ResponsableId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavResponsableid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5ResponsableId), 4, 0));
            AssignProp("", false, dynavResponsableid_Internalname, "Values", dynavResponsableid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7C2( ) ;
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

      protected void RF7C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E137C2 ();
            WB7C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7C2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvRESPONSABLEID_html7C2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV31TicketAnalisisDeProceso = StringUtil.StrToBool( cgiGet( chkavTicketanalisisdeproceso_Internalname));
            AssignAttri("", false, "AV31TicketAnalisisDeProceso", AV31TicketAnalisisDeProceso);
            AV33TicketDesarrolloDeSistema = StringUtil.StrToBool( cgiGet( chkavTicketdesarrollodesistema_Internalname));
            AssignAttri("", false, "AV33TicketDesarrolloDeSistema", AV33TicketDesarrolloDeSistema);
            AV36TicketElaboraciondeDocumentacion = StringUtil.StrToBool( cgiGet( chkavTicketelaboraciondedocumentacion_Internalname));
            AssignAttri("", false, "AV36TicketElaboraciondeDocumentacion", AV36TicketElaboraciondeDocumentacion);
            AV38TicketMantenimientoSistema = StringUtil.StrToBool( cgiGet( chkavTicketmantenimientosistema_Internalname));
            AssignAttri("", false, "AV38TicketMantenimientoSistema", AV38TicketMantenimientoSistema);
            AV32TicketDisenioConceptual = StringUtil.StrToBool( cgiGet( chkavTicketdisenioconceptual_Internalname));
            AssignAttri("", false, "AV32TicketDisenioConceptual", AV32TicketDisenioConceptual);
            AV34TicketDesarrolloyPruebasIniciales = StringUtil.StrToBool( cgiGet( chkavTicketdesarrolloypruebasiniciales_Internalname));
            AssignAttri("", false, "AV34TicketDesarrolloyPruebasIniciales", AV34TicketDesarrolloyPruebasIniciales);
            AV37TicketImplementacion = StringUtil.StrToBool( cgiGet( chkavTicketimplementacion_Internalname));
            AssignAttri("", false, "AV37TicketImplementacion", AV37TicketImplementacion);
            AV39TicketAdministradorBaseDatos = StringUtil.StrToBool( cgiGet( chkavTicketadministradorbasedatos_Internalname));
            AssignAttri("", false, "AV39TicketAdministradorBaseDatos", AV39TicketAdministradorBaseDatos);
            dynavResponsableid.CurrentValue = cgiGet( dynavResponsableid_Internalname);
            AV5ResponsableId = (short)(NumberUtil.Val( cgiGet( dynavResponsableid_Internalname), "."));
            AssignAttri("", false, "AV5ResponsableId", StringUtil.LTrimStr( (decimal)(AV5ResponsableId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvRESPONSABLEID_html7C2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E117C2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         if ( ! AV31TicketAnalisisDeProceso && ! AV32TicketDisenioConceptual && ! AV33TicketDesarrolloDeSistema && ! AV34TicketDesarrolloyPruebasIniciales && ! AV36TicketElaboraciondeDocumentacion && ! AV37TicketImplementacion && ! AV38TicketMantenimientoSistema && ! AV39TicketAdministradorBaseDatos )
         {
            context.PopUp(formatLink("webpanelmsgticketdesarrollo.aspx") , new Object[] {});
         }
         else
         {
            new pcrregistrarticketdesarrollo(context ).execute(  AV27UsuarioId,  AV5ResponsableId,  AV31TicketAnalisisDeProceso,  AV32TicketDisenioConceptual,  AV33TicketDesarrolloDeSistema,  AV34TicketDesarrolloyPruebasIniciales,  AV36TicketElaboraciondeDocumentacion,  AV37TicketImplementacion,  AV38TicketMantenimientoSistema,  AV39TicketAdministradorBaseDatos) ;
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E127C2( )
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

      protected void nextLoad( )
      {
      }

      protected void E137C2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV27UsuarioId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV27UsuarioId", StringUtil.LTrimStr( (decimal)(AV27UsuarioId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV27UsuarioId), "ZZZZZZZZZ9"), context));
         AV28UsuarioNombre = (string)getParm(obj,1);
         AssignAttri("", false, "AV28UsuarioNombre", AV28UsuarioNombre);
         AV26UsuarioGerencia = (string)getParm(obj,2);
         AssignAttri("", false, "AV26UsuarioGerencia", AV26UsuarioGerencia);
         AV25UsuarioDepartamento = (string)getParm(obj,3);
         AssignAttri("", false, "AV25UsuarioDepartamento", AV25UsuarioDepartamento);
         AV29UsuarioRequerimiento = (string)getParm(obj,4);
         AssignAttri("", false, "AV29UsuarioRequerimiento", AV29UsuarioRequerimiento);
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
         PA7C2( ) ;
         WS7C2( ) ;
         WE7C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188215018", true, true);
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
         context.AddJavascriptSource("wpregistrarticketdesarrollo.js", "?2024188215018", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavTicketanalisisdeproceso.Name = "vTICKETANALISISDEPROCESO";
         chkavTicketanalisisdeproceso.WebTags = "";
         chkavTicketanalisisdeproceso.Caption = "";
         AssignProp("", false, chkavTicketanalisisdeproceso_Internalname, "TitleCaption", chkavTicketanalisisdeproceso.Caption, true);
         chkavTicketanalisisdeproceso.CheckedValue = "false";
         AV31TicketAnalisisDeProceso = StringUtil.StrToBool( StringUtil.BoolToStr( AV31TicketAnalisisDeProceso));
         AssignAttri("", false, "AV31TicketAnalisisDeProceso", AV31TicketAnalisisDeProceso);
         chkavTicketdesarrollodesistema.Name = "vTICKETDESARROLLODESISTEMA";
         chkavTicketdesarrollodesistema.WebTags = "";
         chkavTicketdesarrollodesistema.Caption = "";
         AssignProp("", false, chkavTicketdesarrollodesistema_Internalname, "TitleCaption", chkavTicketdesarrollodesistema.Caption, true);
         chkavTicketdesarrollodesistema.CheckedValue = "false";
         AV33TicketDesarrolloDeSistema = StringUtil.StrToBool( StringUtil.BoolToStr( AV33TicketDesarrolloDeSistema));
         AssignAttri("", false, "AV33TicketDesarrolloDeSistema", AV33TicketDesarrolloDeSistema);
         chkavTicketelaboraciondedocumentacion.Name = "vTICKETELABORACIONDEDOCUMENTACION";
         chkavTicketelaboraciondedocumentacion.WebTags = "";
         chkavTicketelaboraciondedocumentacion.Caption = "";
         AssignProp("", false, chkavTicketelaboraciondedocumentacion_Internalname, "TitleCaption", chkavTicketelaboraciondedocumentacion.Caption, true);
         chkavTicketelaboraciondedocumentacion.CheckedValue = "false";
         AV36TicketElaboraciondeDocumentacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV36TicketElaboraciondeDocumentacion));
         AssignAttri("", false, "AV36TicketElaboraciondeDocumentacion", AV36TicketElaboraciondeDocumentacion);
         chkavTicketmantenimientosistema.Name = "vTICKETMANTENIMIENTOSISTEMA";
         chkavTicketmantenimientosistema.WebTags = "";
         chkavTicketmantenimientosistema.Caption = "";
         AssignProp("", false, chkavTicketmantenimientosistema_Internalname, "TitleCaption", chkavTicketmantenimientosistema.Caption, true);
         chkavTicketmantenimientosistema.CheckedValue = "false";
         AV38TicketMantenimientoSistema = StringUtil.StrToBool( StringUtil.BoolToStr( AV38TicketMantenimientoSistema));
         AssignAttri("", false, "AV38TicketMantenimientoSistema", AV38TicketMantenimientoSistema);
         chkavTicketdisenioconceptual.Name = "vTICKETDISENIOCONCEPTUAL";
         chkavTicketdisenioconceptual.WebTags = "";
         chkavTicketdisenioconceptual.Caption = "";
         AssignProp("", false, chkavTicketdisenioconceptual_Internalname, "TitleCaption", chkavTicketdisenioconceptual.Caption, true);
         chkavTicketdisenioconceptual.CheckedValue = "false";
         AV32TicketDisenioConceptual = StringUtil.StrToBool( StringUtil.BoolToStr( AV32TicketDisenioConceptual));
         AssignAttri("", false, "AV32TicketDisenioConceptual", AV32TicketDisenioConceptual);
         chkavTicketdesarrolloypruebasiniciales.Name = "vTICKETDESARROLLOYPRUEBASINICIALES";
         chkavTicketdesarrolloypruebasiniciales.WebTags = "";
         chkavTicketdesarrolloypruebasiniciales.Caption = "";
         AssignProp("", false, chkavTicketdesarrolloypruebasiniciales_Internalname, "TitleCaption", chkavTicketdesarrolloypruebasiniciales.Caption, true);
         chkavTicketdesarrolloypruebasiniciales.CheckedValue = "false";
         AV34TicketDesarrolloyPruebasIniciales = StringUtil.StrToBool( StringUtil.BoolToStr( AV34TicketDesarrolloyPruebasIniciales));
         AssignAttri("", false, "AV34TicketDesarrolloyPruebasIniciales", AV34TicketDesarrolloyPruebasIniciales);
         chkavTicketimplementacion.Name = "vTICKETIMPLEMENTACION";
         chkavTicketimplementacion.WebTags = "";
         chkavTicketimplementacion.Caption = "";
         AssignProp("", false, chkavTicketimplementacion_Internalname, "TitleCaption", chkavTicketimplementacion.Caption, true);
         chkavTicketimplementacion.CheckedValue = "false";
         AV37TicketImplementacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV37TicketImplementacion));
         AssignAttri("", false, "AV37TicketImplementacion", AV37TicketImplementacion);
         chkavTicketadministradorbasedatos.Name = "vTICKETADMINISTRADORBASEDATOS";
         chkavTicketadministradorbasedatos.WebTags = "";
         chkavTicketadministradorbasedatos.Caption = "";
         AssignProp("", false, chkavTicketadministradorbasedatos_Internalname, "TitleCaption", chkavTicketadministradorbasedatos.Caption, true);
         chkavTicketadministradorbasedatos.CheckedValue = "false";
         AV39TicketAdministradorBaseDatos = StringUtil.StrToBool( StringUtil.BoolToStr( AV39TicketAdministradorBaseDatos));
         AssignAttri("", false, "AV39TicketAdministradorBaseDatos", AV39TicketAdministradorBaseDatos);
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
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtavUsuariorequerimiento_Internalname = "vUSUARIOREQUERIMIENTO";
         divTable11_Internalname = "TABLE11";
         divTable6_Internalname = "TABLE6";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         chkavTicketanalisisdeproceso_Internalname = "vTICKETANALISISDEPROCESO";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         chkavTicketdesarrollodesistema_Internalname = "vTICKETDESARROLLODESISTEMA";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         chkavTicketelaboraciondedocumentacion_Internalname = "vTICKETELABORACIONDEDOCUMENTACION";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         chkavTicketmantenimientosistema_Internalname = "vTICKETMANTENIMIENTOSISTEMA";
         divTable10_Internalname = "TABLE10";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         chkavTicketdisenioconceptual_Internalname = "vTICKETDISENIOCONCEPTUAL";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         chkavTicketdesarrolloypruebasiniciales_Internalname = "vTICKETDESARROLLOYPRUEBASINICIALES";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         chkavTicketimplementacion_Internalname = "vTICKETIMPLEMENTACION";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         chkavTicketadministradorbasedatos_Internalname = "vTICKETADMINISTRADORBASEDATOS";
         divTable12_Internalname = "TABLE12";
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
         chkavTicketadministradorbasedatos.Caption = "";
         chkavTicketimplementacion.Caption = "";
         chkavTicketdesarrolloypruebasiniciales.Caption = "";
         chkavTicketdisenioconceptual.Caption = "";
         chkavTicketmantenimientosistema.Caption = "";
         chkavTicketelaboraciondedocumentacion.Caption = "";
         chkavTicketdesarrollodesistema.Caption = "";
         chkavTicketanalisisdeproceso.Caption = "";
         dynavResponsableid_Jsonclick = "";
         dynavResponsableid.Enabled = 1;
         chkavTicketadministradorbasedatos.Enabled = 1;
         chkavTicketimplementacion.Enabled = 1;
         chkavTicketdesarrolloypruebasiniciales.Enabled = 1;
         chkavTicketdisenioconceptual.Enabled = 1;
         chkavTicketmantenimientosistema.Enabled = 1;
         chkavTicketelaboraciondedocumentacion.Enabled = 1;
         chkavTicketdesarrollodesistema.Enabled = 1;
         chkavTicketanalisisdeproceso.Enabled = 1;
         edtavUsuariorequerimiento_Enabled = 0;
         edtavUsuariodepartamento_Enabled = 0;
         edtavUsuariogerencia_Enabled = 0;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Enabled = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Registrar Trabajo Departamento Desarrollo";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV27UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavResponsableid'},{av:'AV5ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV31TicketAnalisisDeProceso',fld:'vTICKETANALISISDEPROCESO',pic:''},{av:'AV33TicketDesarrolloDeSistema',fld:'vTICKETDESARROLLODESISTEMA',pic:''},{av:'AV36TicketElaboraciondeDocumentacion',fld:'vTICKETELABORACIONDEDOCUMENTACION',pic:''},{av:'AV38TicketMantenimientoSistema',fld:'vTICKETMANTENIMIENTOSISTEMA',pic:''},{av:'AV32TicketDisenioConceptual',fld:'vTICKETDISENIOCONCEPTUAL',pic:''},{av:'AV34TicketDesarrolloyPruebasIniciales',fld:'vTICKETDESARROLLOYPRUEBASINICIALES',pic:''},{av:'AV37TicketImplementacion',fld:'vTICKETIMPLEMENTACION',pic:''},{av:'AV39TicketAdministradorBaseDatos',fld:'vTICKETADMINISTRADORBASEDATOS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavResponsableid'},{av:'AV5ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV31TicketAnalisisDeProceso',fld:'vTICKETANALISISDEPROCESO',pic:''},{av:'AV33TicketDesarrolloDeSistema',fld:'vTICKETDESARROLLODESISTEMA',pic:''},{av:'AV36TicketElaboraciondeDocumentacion',fld:'vTICKETELABORACIONDEDOCUMENTACION',pic:''},{av:'AV38TicketMantenimientoSistema',fld:'vTICKETMANTENIMIENTOSISTEMA',pic:''},{av:'AV32TicketDisenioConceptual',fld:'vTICKETDISENIOCONCEPTUAL',pic:''},{av:'AV34TicketDesarrolloyPruebasIniciales',fld:'vTICKETDESARROLLOYPRUEBASINICIALES',pic:''},{av:'AV37TicketImplementacion',fld:'vTICKETIMPLEMENTACION',pic:''},{av:'AV39TicketAdministradorBaseDatos',fld:'vTICKETADMINISTRADORBASEDATOS',pic:''}]}");
         setEventMetadata("'GUARDAR'","{handler:'E117C2',iparms:[{av:'AV27UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavResponsableid'},{av:'AV5ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV31TicketAnalisisDeProceso',fld:'vTICKETANALISISDEPROCESO',pic:''},{av:'AV33TicketDesarrolloDeSistema',fld:'vTICKETDESARROLLODESISTEMA',pic:''},{av:'AV36TicketElaboraciondeDocumentacion',fld:'vTICKETELABORACIONDEDOCUMENTACION',pic:''},{av:'AV38TicketMantenimientoSistema',fld:'vTICKETMANTENIMIENTOSISTEMA',pic:''},{av:'AV32TicketDisenioConceptual',fld:'vTICKETDISENIOCONCEPTUAL',pic:''},{av:'AV34TicketDesarrolloyPruebasIniciales',fld:'vTICKETDESARROLLOYPRUEBASINICIALES',pic:''},{av:'AV37TicketImplementacion',fld:'vTICKETIMPLEMENTACION',pic:''},{av:'AV39TicketAdministradorBaseDatos',fld:'vTICKETADMINISTRADORBASEDATOS',pic:''}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavResponsableid'},{av:'AV5ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV31TicketAnalisisDeProceso',fld:'vTICKETANALISISDEPROCESO',pic:''},{av:'AV33TicketDesarrolloDeSistema',fld:'vTICKETDESARROLLODESISTEMA',pic:''},{av:'AV36TicketElaboraciondeDocumentacion',fld:'vTICKETELABORACIONDEDOCUMENTACION',pic:''},{av:'AV38TicketMantenimientoSistema',fld:'vTICKETMANTENIMIENTOSISTEMA',pic:''},{av:'AV32TicketDisenioConceptual',fld:'vTICKETDISENIOCONCEPTUAL',pic:''},{av:'AV34TicketDesarrolloyPruebasIniciales',fld:'vTICKETDESARROLLOYPRUEBASINICIALES',pic:''},{av:'AV37TicketImplementacion',fld:'vTICKETIMPLEMENTACION',pic:''},{av:'AV39TicketAdministradorBaseDatos',fld:'vTICKETADMINISTRADORBASEDATOS',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E127C2',iparms:[{av:'dynavResponsableid'},{av:'AV5ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV31TicketAnalisisDeProceso',fld:'vTICKETANALISISDEPROCESO',pic:''},{av:'AV33TicketDesarrolloDeSistema',fld:'vTICKETDESARROLLODESISTEMA',pic:''},{av:'AV36TicketElaboraciondeDocumentacion',fld:'vTICKETELABORACIONDEDOCUMENTACION',pic:''},{av:'AV38TicketMantenimientoSistema',fld:'vTICKETMANTENIMIENTOSISTEMA',pic:''},{av:'AV32TicketDisenioConceptual',fld:'vTICKETDISENIOCONCEPTUAL',pic:''},{av:'AV34TicketDesarrolloyPruebasIniciales',fld:'vTICKETDESARROLLOYPRUEBASINICIALES',pic:''},{av:'AV37TicketImplementacion',fld:'vTICKETIMPLEMENTACION',pic:''},{av:'AV39TicketAdministradorBaseDatos',fld:'vTICKETADMINISTRADORBASEDATOS',pic:''}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavResponsableid'},{av:'AV5ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'AV31TicketAnalisisDeProceso',fld:'vTICKETANALISISDEPROCESO',pic:''},{av:'AV33TicketDesarrolloDeSistema',fld:'vTICKETDESARROLLODESISTEMA',pic:''},{av:'AV36TicketElaboraciondeDocumentacion',fld:'vTICKETELABORACIONDEDOCUMENTACION',pic:''},{av:'AV38TicketMantenimientoSistema',fld:'vTICKETMANTENIMIENTOSISTEMA',pic:''},{av:'AV32TicketDisenioConceptual',fld:'vTICKETDISENIOCONCEPTUAL',pic:''},{av:'AV34TicketDesarrolloyPruebasIniciales',fld:'vTICKETDESARROLLOYPRUEBASINICIALES',pic:''},{av:'AV37TicketImplementacion',fld:'vTICKETIMPLEMENTACION',pic:''},{av:'AV39TicketAdministradorBaseDatos',fld:'vTICKETADMINISTRADORBASEDATOS',pic:''}]}");
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
         wcpOAV28UsuarioNombre = "";
         wcpOAV26UsuarioGerencia = "";
         wcpOAV25UsuarioDepartamento = "";
         wcpOAV29UsuarioRequerimiento = "";
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
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         TempTags = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
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
         H007C2_A6ResponsableId = new short[1] ;
         H007C2_A30ResponsableNombre = new string[] {""} ;
         H007C2_A26ResponsableActivo = new bool[] {false} ;
         H007C2_A103id_unidad = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistrarticketdesarrollo__default(),
            new Object[][] {
                new Object[] {
               H007C2_A6ResponsableId, H007C2_A30ResponsableNombre, H007C2_A26ResponsableActivo, H007C2_A103id_unidad
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
      private short AV5ResponsableId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuariogerencia_Enabled ;
      private int edtavUsuariodepartamento_Enabled ;
      private int edtavUsuariorequerimiento_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV27UsuarioId ;
      private long wcpOAV27UsuarioId ;
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
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtavUsuariorequerimiento_Internalname ;
      private string divTable5_Internalname ;
      private string divTable10_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string chkavTicketanalisisdeproceso_Internalname ;
      private string TempTags ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string chkavTicketdesarrollodesistema_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string chkavTicketelaboraciondedocumentacion_Internalname ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string chkavTicketmantenimientosistema_Internalname ;
      private string divTable12_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string chkavTicketdisenioconceptual_Internalname ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string chkavTicketdesarrolloypruebasiniciales_Internalname ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string chkavTicketimplementacion_Internalname ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string chkavTicketadministradorbasedatos_Internalname ;
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
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool AV31TicketAnalisisDeProceso ;
      private bool AV33TicketDesarrolloDeSistema ;
      private bool AV36TicketElaboraciondeDocumentacion ;
      private bool AV38TicketMantenimientoSistema ;
      private bool AV32TicketDisenioConceptual ;
      private bool AV34TicketDesarrolloyPruebasIniciales ;
      private bool AV37TicketImplementacion ;
      private bool AV39TicketAdministradorBaseDatos ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV28UsuarioNombre ;
      private string AV26UsuarioGerencia ;
      private string AV25UsuarioDepartamento ;
      private string AV29UsuarioRequerimiento ;
      private string wcpOAV28UsuarioNombre ;
      private string wcpOAV26UsuarioGerencia ;
      private string wcpOAV25UsuarioDepartamento ;
      private string wcpOAV29UsuarioRequerimiento ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavTicketanalisisdeproceso ;
      private GXCheckbox chkavTicketdesarrollodesistema ;
      private GXCheckbox chkavTicketelaboraciondedocumentacion ;
      private GXCheckbox chkavTicketmantenimientosistema ;
      private GXCheckbox chkavTicketdisenioconceptual ;
      private GXCheckbox chkavTicketdesarrolloypruebasiniciales ;
      private GXCheckbox chkavTicketimplementacion ;
      private GXCheckbox chkavTicketadministradorbasedatos ;
      private GXCombobox dynavResponsableid ;
      private IDataStoreProvider pr_default ;
      private short[] H007C2_A6ResponsableId ;
      private string[] H007C2_A30ResponsableNombre ;
      private bool[] H007C2_A26ResponsableActivo ;
      private int[] H007C2_A103id_unidad ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wpregistrarticketdesarrollo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007C2;
          prmH007C2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007C2", "SELECT [ResponsableId], [ResponsableNombre], [ResponsableActivo], [id_unidad] FROM [Responsable] WHERE ([ResponsableActivo] = 1) AND ([id_unidad] = 2) ORDER BY [ResponsableNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007C2,0, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
