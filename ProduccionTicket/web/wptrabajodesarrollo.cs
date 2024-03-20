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
using GeneXus.Mail;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wptrabajodesarrollo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wptrabajodesarrollo( )
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

      public wptrabajodesarrollo( IGxContext context )
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
         dynavEmpleado = new GXCombobox();
         dynavCargo = new GXCombobox();
         dynavUsuariodepartamento = new GXCombobox();
         dynavDetalle_infotecid_unidad = new GXCombobox();
         dynavCategoria_tareaid_tipo_categoria = new GXCombobox();
         dynavId_actividad_categoria = new GXCombobox();
         dynavCategoriadetalletareaid = new GXCombobox();
         cmbavPrioridad = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vEMPLEADO") == 0 )
            {
               AV111UsuarioConectado = GetPar( "UsuarioConectado");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvEMPLEADO7O2( AV111UsuarioConectado) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCARGO") == 0 )
            {
               AV111UsuarioConectado = GetPar( "UsuarioConectado");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCARGO7O2( AV111UsuarioConectado) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vUSUARIODEPARTAMENTO") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvUSUARIODEPARTAMENTO7O2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vDETALLE_INFOTECID_UNIDAD") == 0 )
            {
               AV6categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV6categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvDETALLE_INFOTECID_UNIDAD7O2( AV6categoria_tareaid_tipo_categoria) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCATEGORIA_TAREAID_TIPO_CATEGORIA") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA7O2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vID_ACTIVIDAD_CATEGORIA") == 0 )
            {
               AV6categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV6categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvID_ACTIVIDAD_CATEGORIA7O2( AV6categoria_tareaid_tipo_categoria) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCATEGORIADETALLETAREAID") == 0 )
            {
               AV15id_actividad_categoria = (int)(NumberUtil.Val( GetPar( "id_actividad_categoria"), "."));
               AssignAttri("", false, "AV15id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV15id_actividad_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCATEGORIADETALLETAREAID7O2( AV15id_actividad_categoria) ;
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
            return "wptrabajodesarrollo_Execute" ;
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
         PA7O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7O2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418843090", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wptrabajodesarrollo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOTICKETTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13EstadoTicketTicketId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14EtapaDesarrolloId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WPTrabajoDesarrollo");
         forbiddenHiddens.Add("detalle_infotecid_unidad", context.localUtil.Format( (decimal)(AV8detalle_infotecid_unidad), "ZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wptrabajodesarrollo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13EstadoTicketTicketId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOTICKETTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13EstadoTicketTicketId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14EtapaDesarrolloId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOCONECTADO", AV111UsuarioConectado);
         GxWebStd.gx_hidden_field( context, "vCATEGORIA_TAREAID_TIPO_CATEGORIA_Text", StringUtil.RTrim( dynavCategoria_tareaid_tipo_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vID_ACTIVIDAD_CATEGORIA_Text", StringUtil.RTrim( dynavId_actividad_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vPRIORIDAD_Text", StringUtil.RTrim( cmbavPrioridad.Description));
         GxWebStd.gx_hidden_field( context, "vUSUARIODEPARTAMENTO_Text", StringUtil.RTrim( dynavUsuariodepartamento.Description));
         GxWebStd.gx_hidden_field( context, "vCATEGORIADETALLETAREAID_Text", StringUtil.RTrim( dynavCategoriadetalletareaid.Description));
         GxWebStd.gx_hidden_field( context, "vEMPLEADO_Text", StringUtil.RTrim( dynavEmpleado.Description));
         GxWebStd.gx_hidden_field( context, "vCARGO_Text", StringUtil.RTrim( dynavCargo.Description));
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
            WE7O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7O2( ) ;
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
         return formatLink("wptrabajodesarrollo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WPTrabajoDesarrollo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Registro de Trabajo Diario" ;
      }

      protected void WB7O0( )
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable25_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Gerencia de Información y Sistemas", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle1", 0, "", 1, 1, 0, 0, "HLP_WPTrabajoDesarrollo.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "<<Registro de Trabajo Diario>>", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPTrabajoDesarrollo.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
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
            GxWebStd.gx_div_start( context, divTable8_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavEmpleado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEmpleado_Internalname, "Empleado: ", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEmpleado, dynavEmpleado_Internalname, StringUtil.RTrim( AV109Empleado), 1, dynavEmpleado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavEmpleado.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavEmpleado.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavEmpleado.CurrentValue = StringUtil.RTrim( AV109Empleado);
            AssignProp("", false, dynavEmpleado_Internalname, "Values", (string)(dynavEmpleado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable9_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavCargo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCargo_Internalname, "Cargo: ", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCargo, dynavCargo_Internalname, StringUtil.RTrim( AV110Cargo), 1, dynavCargo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavCargo.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCargo.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavCargo.CurrentValue = StringUtil.RTrim( AV110Cargo);
            AssignProp("", false, dynavCargo_Internalname, "Values", (string)(dynavCargo.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable26_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarionombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarionombre_Internalname, "Usuario Atendido:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV105UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV105UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavUsuarionombre_Forecolor)+";", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPTrabajoDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuariofecha_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuariofecha_Internalname, "Fecha Solicitud:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuariofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuariofecha_Internalname, context.localUtil.Format(AV103UsuarioFecha, "99/99/9999"), context.localUtil.Format( AV103UsuarioFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuariofecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPTrabajoDesarrollo.htm");
            GxWebStd.gx_bitmap( context, edtavUsuariofecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuariofecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPTrabajoDesarrollo.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable27_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavUsuariodepartamento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavUsuariodepartamento_Internalname, "Departamento:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavUsuariodepartamento, dynavUsuariodepartamento_Internalname, StringUtil.RTrim( AV101UsuarioDepartamento), 1, dynavUsuariodepartamento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavUsuariodepartamento.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavUsuariodepartamento.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavUsuariodepartamento.CurrentValue = StringUtil.RTrim( AV101UsuarioDepartamento);
            AssignProp("", false, dynavUsuariodepartamento_Internalname, "Values", (string)(dynavUsuariodepartamento.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable28_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavUsuarioemail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioemail_Internalname, "Email:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioemail_Internalname, AV102UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( AV102UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_WPTrabajoDesarrollo.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavDetalle_infotecid_unidad_Internalname, "id_unidad", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavDetalle_infotecid_unidad, dynavDetalle_infotecid_unidad_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0)), 1, dynavDetalle_infotecid_unidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavDetalle_infotecid_unidad.Visible, dynavDetalle_infotecid_unidad.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", (string)(dynavDetalle_infotecid_unidad.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable20_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable21_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Observaciones: ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock1_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPTrabajoDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTicketresponsableobservacion_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavTicketresponsableobservacion_Internalname, AV79TicketResponsableObservacion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", 0, 1, edtavTicketresponsableobservacion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPTrabajoDesarrollo.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable13_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable16_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavCategoria_tareaid_tipo_categoria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCategoria_tareaid_tipo_categoria_Internalname, "Categoría de Tarea:", "col-sm-3 Attribute_ColorLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoria_tareaid_tipo_categoria, dynavCategoria_tareaid_tipo_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0)), 1, dynavCategoria_tareaid_tipo_categoria_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK."+"'", "int", "", 1, dynavCategoria_tareaid_tipo_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCategoria_tareaid_tipo_categoria.ForeColor)+";", "Attribute_Color", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0));
            AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Values", (string)(dynavCategoria_tareaid_tipo_categoria.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable18_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavId_actividad_categoria_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavId_actividad_categoria_Internalname, "Detalle Tarea:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavId_actividad_categoria, dynavId_actividad_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0)), 1, dynavId_actividad_categoria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavId_actividad_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavId_actividad_categoria.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0));
            AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", (string)(dynavId_actividad_categoria.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable35_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavCategoriadetalletareaid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCategoriadetalletareaid_Internalname, "Actividad Tarea:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoriadetalletareaid, dynavCategoriadetalletareaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0)), 1, dynavCategoriadetalletareaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCategoriadetalletareaid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCategoriadetalletareaid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
            AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", (string)(dynavCategoriadetalletareaid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable29_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbavPrioridad_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPrioridad_Internalname, "Prioridad:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPrioridad, cmbavPrioridad_Internalname, StringUtil.RTrim( AV17prioridad), 1, cmbavPrioridad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavPrioridad.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( cmbavPrioridad.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "", true, 1, "HLP_WPTrabajoDesarrollo.htm");
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV17prioridad);
            AssignProp("", false, cmbavPrioridad_Internalname, "Values", (string)(cmbavPrioridad.ToJavascriptSource()), true);
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable17_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable19_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable10_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable11_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 157,'',false,'',0)\"";
            ClassString = "Button_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPTrabajoDesarrollo.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPTrabajoDesarrollo.htm");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START7O2( )
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
            Form.Meta.addItem("description", "Registro de Trabajo Diario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7O0( ) ;
      }

      protected void WS7O2( )
      {
         START7O2( ) ;
         EVT7O2( ) ;
      }

      protected void EVT7O2( )
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
                              E117O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E127O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba' */
                              E137O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E147O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E157O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E167O2 ();
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

      protected void WE7O2( )
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

      protected void PA7O2( )
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
               GX_FocusControl = dynavEmpleado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvDETALLE_INFOTECID_UNIDAD_html7O2( AV6categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html7O2( AV6categoria_tareaid_tipo_categoria) ;
         GXVvCATEGORIADETALLETAREAID_html7O2( AV15id_actividad_categoria) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvEMPLEADO7O2( string AV111UsuarioConectado )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvEMPLEADO_data7O2( AV111UsuarioConectado) ;
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

      protected void GXVvEMPLEADO_html7O2( string AV111UsuarioConectado )
      {
         string gxdynajaxvalue;
         GXDLVvEMPLEADO_data7O2( AV111UsuarioConectado) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEmpleado.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavEmpleado.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavEmpleado.ItemCount > 0 )
         {
            AV109Empleado = dynavEmpleado.getValidValue(AV109Empleado);
            AssignAttri("", false, "AV109Empleado", AV109Empleado);
         }
      }

      protected void GXDLVvEMPLEADO_data7O2( string AV111UsuarioConectado )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H007O2 */
         pr_default.execute(0, new Object[] {AV111UsuarioConectado});
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H007O2_A30ResponsableNombre[0]);
            gxdynajaxctrldescr.Add(H007O2_A30ResponsableNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvCARGO7O2( string AV111UsuarioConectado )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCARGO_data7O2( AV111UsuarioConectado) ;
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

      protected void GXVvCARGO_html7O2( string AV111UsuarioConectado )
      {
         string gxdynajaxvalue;
         GXDLVvCARGO_data7O2( AV111UsuarioConectado) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCargo.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavCargo.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
         if ( dynavCargo.ItemCount > 0 )
         {
            AV110Cargo = dynavCargo.getValidValue(AV110Cargo);
            AssignAttri("", false, "AV110Cargo", AV110Cargo);
         }
      }

      protected void GXDLVvCARGO_data7O2( string AV111UsuarioConectado )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H007O3 */
         pr_default.execute(1, new Object[] {AV111UsuarioConectado});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(H007O3_A27ResponsableCargo[0]);
            gxdynajaxctrldescr.Add(H007O3_A27ResponsableCargo[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvUSUARIODEPARTAMENTO7O2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvUSUARIODEPARTAMENTO_data7O2( ) ;
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

      protected void GXVvUSUARIODEPARTAMENTO_html7O2( )
      {
         string gxdynajaxvalue;
         GXDLVvUSUARIODEPARTAMENTO_data7O2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavUsuariodepartamento.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex));
            dynavUsuariodepartamento.addItem(gxdynajaxvalue, ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvUSUARIODEPARTAMENTO_data7O2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add("");
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007O4 */
         pr_datastore1.execute(0);
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H007O4_A361nombre_depto[0]);
            gxdynajaxctrldescr.Add(H007O4_A361nombre_depto[0]);
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
      }

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD7O2( int AV6categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data7O2( AV6categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvDETALLE_INFOTECID_UNIDAD_html7O2( int AV6categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data7O2( AV6categoria_tareaid_tipo_categoria) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavDetalle_infotecid_unidad.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavDetalle_infotecid_unidad.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 9, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD_data7O2( int AV6categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007O5 */
         pr_datastore1.execute(1, new Object[] {AV6categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007O5_A105id_unidad_gis[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007O5_A105id_unidad_gis[0]), 9, 0, ".", "")));
            pr_datastore1.readNext(1);
         }
         pr_datastore1.close(1);
      }

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA7O2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data7O2( ) ;
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

      protected void GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7O2( )
      {
         int gxdynajaxvalue;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data7O2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCategoria_tareaid_tipo_categoria.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavCategoria_tareaid_tipo_categoria.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 9, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data7O2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007O6 */
         pr_datastore1.execute(2);
         while ( (pr_datastore1.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007O6_A104categoria_tareaid_tipo_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007O6_A106nombre_categoria[0]);
            pr_datastore1.readNext(2);
         }
         pr_datastore1.close(2);
      }

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA7O2( int AV6categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data7O2( AV6categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvID_ACTIVIDAD_CATEGORIA_html7O2( int AV6categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data7O2( AV6categoria_tareaid_tipo_categoria) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavId_actividad_categoria.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (int)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavId_actividad_categoria.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 9, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA_data7O2( int AV6categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007O7 */
         pr_datastore1.execute(3, new Object[] {AV6categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007O7_A102id_actividad_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007O7_A123nombre_actividad[0]);
            pr_datastore1.readNext(3);
         }
         pr_datastore1.close(3);
      }

      protected void GXDLVvCATEGORIADETALLETAREAID7O2( int AV15id_actividad_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIADETALLETAREAID_data7O2( AV15id_actividad_categoria) ;
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

      protected void GXVvCATEGORIADETALLETAREAID_html7O2( int AV15id_actividad_categoria )
      {
         short gxdynajaxvalue;
         GXDLVvCATEGORIADETALLETAREAID_data7O2( AV15id_actividad_categoria) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCategoriadetalletareaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavCategoriadetalletareaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCATEGORIADETALLETAREAID_data7O2( int AV15id_actividad_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007O8 */
         pr_default.execute(2, new Object[] {AV15id_actividad_categoria});
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007O8_A294CategoriaDetalleTareaId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007O8_A295CategoriaDetalleTareaNombre[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvUSUARIODEPARTAMENTO_html7O2( ) ;
            GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7O2( ) ;
            GXVvDETALLE_INFOTECID_UNIDAD_html7O2( AV6categoria_tareaid_tipo_categoria) ;
            GXVvID_ACTIVIDAD_CATEGORIA_html7O2( AV6categoria_tareaid_tipo_categoria) ;
            GXVvCATEGORIADETALLETAREAID_html7O2( AV15id_actividad_categoria) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEmpleado.ItemCount > 0 )
         {
            AV109Empleado = dynavEmpleado.getValidValue(AV109Empleado);
            AssignAttri("", false, "AV109Empleado", AV109Empleado);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEmpleado.CurrentValue = StringUtil.RTrim( AV109Empleado);
            AssignProp("", false, dynavEmpleado_Internalname, "Values", dynavEmpleado.ToJavascriptSource(), true);
         }
         if ( dynavCargo.ItemCount > 0 )
         {
            AV110Cargo = dynavCargo.getValidValue(AV110Cargo);
            AssignAttri("", false, "AV110Cargo", AV110Cargo);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCargo.CurrentValue = StringUtil.RTrim( AV110Cargo);
            AssignProp("", false, dynavCargo_Internalname, "Values", dynavCargo.ToJavascriptSource(), true);
         }
         if ( dynavUsuariodepartamento.ItemCount > 0 )
         {
            AV101UsuarioDepartamento = dynavUsuariodepartamento.getValidValue(AV101UsuarioDepartamento);
            AssignAttri("", false, "AV101UsuarioDepartamento", AV101UsuarioDepartamento);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavUsuariodepartamento.CurrentValue = StringUtil.RTrim( AV101UsuarioDepartamento);
            AssignProp("", false, dynavUsuariodepartamento_Internalname, "Values", dynavUsuariodepartamento.ToJavascriptSource(), true);
         }
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV8detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0))), "."));
            AssignAttri("", false, "AV8detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         }
         if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
         {
            AV6categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV6categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0));
            AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Values", dynavCategoria_tareaid_tipo_categoria.ToJavascriptSource(), true);
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV15id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV15id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV15id_actividad_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0));
            AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
         }
         if ( dynavCategoriadetalletareaid.ItemCount > 0 )
         {
            AV7CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0))), "."));
            AssignAttri("", false, "AV7CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
            AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", dynavCategoriadetalletareaid.ToJavascriptSource(), true);
         }
         if ( cmbavPrioridad.ItemCount > 0 )
         {
            AV17prioridad = cmbavPrioridad.getValidValue(AV17prioridad);
            AssignAttri("", false, "AV17prioridad", AV17prioridad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV17prioridad);
            AssignProp("", false, cmbavPrioridad_Internalname, "Values", cmbavPrioridad.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavEmpleado.Enabled = 0;
         AssignProp("", false, dynavEmpleado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmpleado.Enabled), 5, 0), true);
         dynavCargo.Enabled = 0;
         AssignProp("", false, dynavCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCargo.Enabled), 5, 0), true);
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
      }

      protected void RF7O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E167O2 ();
            WB7O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7O2( )
      {
         GxWebStd.gx_hidden_field( context, "vESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13EstadoTicketTicketId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOTICKETTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13EstadoTicketTicketId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14EtapaDesarrolloId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         dynavEmpleado.Enabled = 0;
         AssignProp("", false, dynavEmpleado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmpleado.Enabled), 5, 0), true);
         dynavCargo.Enabled = 0;
         AssignProp("", false, dynavCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCargo.Enabled), 5, 0), true);
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
         GXVvUSUARIODEPARTAMENTO_html7O2( ) ;
         GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7O2( ) ;
         GXVvDETALLE_INFOTECID_UNIDAD_html7O2( AV6categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html7O2( AV6categoria_tareaid_tipo_categoria) ;
         GXVvCATEGORIADETALLETAREAID_html7O2( AV15id_actividad_categoria) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E157O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         GXVvEMPLEADO_html7O2( AV111UsuarioConectado) ;
         GXVvCARGO_html7O2( AV111UsuarioConectado) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavEmpleado.CurrentValue = cgiGet( dynavEmpleado_Internalname);
            AV109Empleado = cgiGet( dynavEmpleado_Internalname);
            AssignAttri("", false, "AV109Empleado", AV109Empleado);
            dynavCargo.CurrentValue = cgiGet( dynavCargo_Internalname);
            AV110Cargo = cgiGet( dynavCargo_Internalname);
            AssignAttri("", false, "AV110Cargo", AV110Cargo);
            AV105UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV105UsuarioNombre", AV105UsuarioNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuariofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Usuario Fecha"}), 1, "vUSUARIOFECHA");
               GX_FocusControl = edtavUsuariofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV103UsuarioFecha = DateTime.MinValue;
               AssignAttri("", false, "AV103UsuarioFecha", context.localUtil.Format(AV103UsuarioFecha, "99/99/9999"));
            }
            else
            {
               AV103UsuarioFecha = context.localUtil.CToD( cgiGet( edtavUsuariofecha_Internalname), 2);
               AssignAttri("", false, "AV103UsuarioFecha", context.localUtil.Format(AV103UsuarioFecha, "99/99/9999"));
            }
            dynavUsuariodepartamento.CurrentValue = cgiGet( dynavUsuariodepartamento_Internalname);
            AV101UsuarioDepartamento = cgiGet( dynavUsuariodepartamento_Internalname);
            AssignAttri("", false, "AV101UsuarioDepartamento", AV101UsuarioDepartamento);
            AV102UsuarioEmail = cgiGet( edtavUsuarioemail_Internalname);
            AssignAttri("", false, "AV102UsuarioEmail", AV102UsuarioEmail);
            dynavDetalle_infotecid_unidad.CurrentValue = cgiGet( dynavDetalle_infotecid_unidad_Internalname);
            AV8detalle_infotecid_unidad = (int)(NumberUtil.Val( cgiGet( dynavDetalle_infotecid_unidad_Internalname), "."));
            AssignAttri("", false, "AV8detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
            AV79TicketResponsableObservacion = cgiGet( edtavTicketresponsableobservacion_Internalname);
            AssignAttri("", false, "AV79TicketResponsableObservacion", AV79TicketResponsableObservacion);
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname);
            AV6categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname), "."));
            AssignAttri("", false, "AV6categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV6categoria_tareaid_tipo_categoria), 9, 0));
            dynavId_actividad_categoria.CurrentValue = cgiGet( dynavId_actividad_categoria_Internalname);
            AV15id_actividad_categoria = (int)(NumberUtil.Val( cgiGet( dynavId_actividad_categoria_Internalname), "."));
            AssignAttri("", false, "AV15id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV15id_actividad_categoria), 9, 0));
            dynavCategoriadetalletareaid.CurrentValue = cgiGet( dynavCategoriadetalletareaid_Internalname);
            AV7CategoriaDetalleTareaId = (short)(NumberUtil.Val( cgiGet( dynavCategoriadetalletareaid_Internalname), "."));
            AssignAttri("", false, "AV7CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
            cmbavPrioridad.CurrentValue = cgiGet( cmbavPrioridad_Internalname);
            AV17prioridad = cgiGet( cmbavPrioridad_Internalname);
            AssignAttri("", false, "AV17prioridad", AV17prioridad);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WPTrabajoDesarrollo");
            AV8detalle_infotecid_unidad = (int)(NumberUtil.Val( cgiGet( dynavDetalle_infotecid_unidad_Internalname), "."));
            AssignAttri("", false, "AV8detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
            forbiddenHiddens.Add("detalle_infotecid_unidad", context.localUtil.Format( (decimal)(AV8detalle_infotecid_unidad), "ZZZZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wptrabajodesarrollo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            GXVvUSUARIODEPARTAMENTO_html7O2( ) ;
            GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7O2( ) ;
            GXVvEMPLEADO_html7O2( AV111UsuarioConectado) ;
            GXVvCARGO_html7O2( AV111UsuarioConectado) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E117O2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(dynavCategoria_tareaid_tipo_categoria.Description, "(Ninguno)") == 0 )
         {
            context.PopUp(formatLink("webpanelmsgcategoria.aspx") , new Object[] {});
         }
         else
         {
            if ( StringUtil.StrCmp(dynavId_actividad_categoria.Description, "(Ninguno)") == 0 )
            {
               context.PopUp(formatLink("webpanelmsgcategoria.aspx") , new Object[] {});
            }
            else
            {
               if ( StringUtil.StrCmp(cmbavPrioridad.Description, "(Ninguno)") == 0 )
               {
                  context.PopUp(formatLink("webpanelmsgcategoria.aspx") , new Object[] {});
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79TicketResponsableObservacion)) )
                  {
                     context.PopUp(formatLink("webpanelmsgobservacion.aspx") , new Object[] {});
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(dynavUsuariodepartamento.Description, "(Ninguno)") == 0 )
                     {
                        context.PopUp(formatLink("webpanelmsgdeptousuario.aspx") , new Object[] {});
                     }
                     else
                     {
                        AV9detalle_tarea = dynavCategoria_tareaid_tipo_categoria.Description + "/-" + dynavId_actividad_categoria.Description + "/-" + dynavCategoriadetalletareaid.Description;
                        new pcrregistrarinfotec(context ).execute(  AV6categoria_tareaid_tipo_categoria,  AV15id_actividad_categoria,  AV105UsuarioNombre,  AV101UsuarioDepartamento,  AV102UsuarioEmail,  AV8detalle_infotecid_unidad,  AV9detalle_tarea,  cmbavPrioridad.Description,  AV103UsuarioFecha,  AV13EstadoTicketTicketId,  AV14EtapaDesarrolloId,  AV79TicketResponsableObservacion,  dynavEmpleado.Description,  dynavCargo.Description) ;
                        context.setWebReturnParms(new Object[] {});
                        context.setWebReturnParmsMetadata(new Object[] {});
                        context.wjLocDisableFrm = 1;
                        context.nUserReturn = 1;
                        returnInSub = true;
                        if (true) return;
                     }
                  }
               }
            }
         }
      }

      protected void E127O2( )
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

      protected void E137O2( )
      {
         /* 'Prueba' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         AV5window.Url = "http://localhost/kb_ticket.NetEnvironment/wpdesarrollosoftware.aspx";
         context.NewWindow(AV5window);
         /*  Sending Event outputs  */
      }

      protected void E147O2( )
      {
         /* Categoria_tareaid_tipo_categoria_Click Routine */
         returnInSub = false;
         dynavCategoriadetalletareaid.removeAllItems();
         dynavCategoriadetalletareaid.Description = "(Ninguno)";
         /*  Sending Event outputs  */
         dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
         AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", dynavCategoriadetalletareaid.ToJavascriptSource(), true);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E157O2 ();
         if (returnInSub) return;
      }

      protected void E157O2( )
      {
         /* Start Routine */
         returnInSub = false;
         dynavCategoria_tareaid_tipo_categoria.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavCategoria_tareaid_tipo_categoria.ForeColor), 9, 0), true);
         dynavId_actividad_categoria.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavId_actividad_categoria.ForeColor), 9, 0), true);
         dynavCategoriadetalletareaid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavCategoriadetalletareaid.ForeColor), 9, 0), true);
         cmbavPrioridad.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, cmbavPrioridad_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(cmbavPrioridad.ForeColor), 9, 0), true);
         edtavTicketresponsableobservacion_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsableobservacion_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsableobservacion_Forecolor), 9, 0), true);
         edtavUsuarionombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuarionombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuarionombre_Forecolor), 9, 0), true);
         dynavUsuariodepartamento.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavUsuariodepartamento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavUsuariodepartamento.ForeColor), 9, 0), true);
         dynavDetalle_infotecid_unidad.Visible = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Visible), 5, 0), true);
         lblTextblock1_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock1_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock1_Forecolor), 9, 0), true);
         AV111UsuarioConectado = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         dynavEmpleado.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavEmpleado_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavEmpleado.ForeColor), 9, 0), true);
         dynavCargo.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavCargo_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavCargo.ForeColor), 9, 0), true);
         AV103UsuarioFecha = DateTimeUtil.ResetTime(DateTimeUtil.Now( context));
         AssignAttri("", false, "AV103UsuarioFecha", context.localUtil.Format(AV103UsuarioFecha, "99/99/9999"));
      }

      protected void nextLoad( )
      {
      }

      protected void E167O2( )
      {
         /* Load Routine */
         returnInSub = false;
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
         PA7O2( ) ;
         WS7O2( ) ;
         WE7O2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418843384", true, true);
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
         context.AddJavascriptSource("wptrabajodesarrollo.js", "?202418843384", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavEmpleado.Name = "vEMPLEADO";
         dynavEmpleado.WebTags = "";
         dynavCargo.Name = "vCARGO";
         dynavCargo.WebTags = "";
         dynavUsuariodepartamento.Name = "vUSUARIODEPARTAMENTO";
         dynavUsuariodepartamento.WebTags = "";
         dynavDetalle_infotecid_unidad.Name = "vDETALLE_INFOTECID_UNIDAD";
         dynavDetalle_infotecid_unidad.WebTags = "";
         dynavCategoria_tareaid_tipo_categoria.Name = "vCATEGORIA_TAREAID_TIPO_CATEGORIA";
         dynavCategoria_tareaid_tipo_categoria.WebTags = "";
         dynavId_actividad_categoria.Name = "vID_ACTIVIDAD_CATEGORIA";
         dynavId_actividad_categoria.WebTags = "";
         dynavCategoriadetalletareaid.Name = "vCATEGORIADETALLETAREAID";
         dynavCategoriadetalletareaid.WebTags = "";
         cmbavPrioridad.Name = "vPRIORIDAD";
         cmbavPrioridad.WebTags = "";
         cmbavPrioridad.addItem("", "(Ninguno)", 0);
         cmbavPrioridad.addItem("1", "BAJA", 0);
         cmbavPrioridad.addItem("2", "MEDIA", 0);
         cmbavPrioridad.addItem("3", "ALTA", 0);
         if ( cmbavPrioridad.ItemCount > 0 )
         {
            AV17prioridad = cmbavPrioridad.getValidValue(AV17prioridad);
            AssignAttri("", false, "AV17prioridad", AV17prioridad);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         divTable1_Internalname = "TABLE1";
         dynavEmpleado_Internalname = "vEMPLEADO";
         divTable8_Internalname = "TABLE8";
         dynavCargo_Internalname = "vCARGO";
         divTable9_Internalname = "TABLE9";
         divTable5_Internalname = "TABLE5";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divTable26_Internalname = "TABLE26";
         edtavUsuariofecha_Internalname = "vUSUARIOFECHA";
         divTable6_Internalname = "TABLE6";
         dynavUsuariodepartamento_Internalname = "vUSUARIODEPARTAMENTO";
         divTable27_Internalname = "TABLE27";
         edtavUsuarioemail_Internalname = "vUSUARIOEMAIL";
         divTable28_Internalname = "TABLE28";
         divTable4_Internalname = "TABLE4";
         divTable25_Internalname = "TABLE25";
         dynavDetalle_infotecid_unidad_Internalname = "vDETALLE_INFOTECID_UNIDAD";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTicketresponsableobservacion_Internalname = "vTICKETRESPONSABLEOBSERVACION";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         divTable21_Internalname = "TABLE21";
         divTable20_Internalname = "TABLE20";
         dynavCategoria_tareaid_tipo_categoria_Internalname = "vCATEGORIA_TAREAID_TIPO_CATEGORIA";
         divTable16_Internalname = "TABLE16";
         dynavId_actividad_categoria_Internalname = "vID_ACTIVIDAD_CATEGORIA";
         divTable18_Internalname = "TABLE18";
         dynavCategoriadetalletareaid_Internalname = "vCATEGORIADETALLETAREAID";
         divTable35_Internalname = "TABLE35";
         cmbavPrioridad_Internalname = "vPRIORIDAD";
         divTable29_Internalname = "TABLE29";
         divTable15_Internalname = "TABLE15";
         divTable14_Internalname = "TABLE14";
         divTable13_Internalname = "TABLE13";
         bttGuardar_Internalname = "GUARDAR";
         divTable11_Internalname = "TABLE11";
         bttCancelar_Internalname = "CANCELAR";
         divTable12_Internalname = "TABLE12";
         divTable10_Internalname = "TABLE10";
         divTable19_Internalname = "TABLE19";
         divTable17_Internalname = "TABLE17";
         divTable3_Internalname = "TABLE3";
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
         cmbavPrioridad_Jsonclick = "";
         cmbavPrioridad.Enabled = 1;
         cmbavPrioridad.ForeColor = (int)(0x000000);
         dynavCategoriadetalletareaid_Jsonclick = "";
         dynavCategoriadetalletareaid.Enabled = 1;
         dynavCategoriadetalletareaid.ForeColor = (int)(0x000000);
         dynavId_actividad_categoria_Jsonclick = "";
         dynavId_actividad_categoria.Enabled = 1;
         dynavId_actividad_categoria.ForeColor = (int)(0x000000);
         dynavCategoria_tareaid_tipo_categoria_Jsonclick = "";
         dynavCategoria_tareaid_tipo_categoria.Enabled = 1;
         dynavCategoria_tareaid_tipo_categoria.ForeColor = (int)(0x000000);
         edtavTicketresponsableobservacion_Forecolor = (int)(0x000000);
         edtavTicketresponsableobservacion_Enabled = 1;
         lblTextblock1_Forecolor = (int)(0x000000);
         dynavDetalle_infotecid_unidad_Jsonclick = "";
         dynavDetalle_infotecid_unidad.Visible = 1;
         dynavDetalle_infotecid_unidad.Enabled = 1;
         edtavUsuarioemail_Jsonclick = "";
         edtavUsuarioemail_Enabled = 1;
         dynavUsuariodepartamento_Jsonclick = "";
         dynavUsuariodepartamento.Enabled = 1;
         dynavUsuariodepartamento.ForeColor = (int)(0x000000);
         edtavUsuariofecha_Jsonclick = "";
         edtavUsuariofecha_Enabled = 1;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Forecolor = (int)(0x000000);
         edtavUsuarionombre_Enabled = 1;
         dynavCargo_Jsonclick = "";
         dynavCargo.Enabled = 1;
         dynavCargo.ForeColor = (int)(0x000000);
         dynavEmpleado_Jsonclick = "";
         dynavEmpleado.Enabled = 1;
         dynavEmpleado.ForeColor = (int)(0x000000);
         dynavCargo.Description = "";
         dynavEmpleado.Description = "";
         dynavCategoriadetalletareaid.Description = "";
         dynavUsuariodepartamento.Description = "";
         cmbavPrioridad.Description = "";
         dynavId_actividad_categoria.Description = "";
         dynavCategoria_tareaid_tipo_categoria.Description = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Registro de Trabajo Diario";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Categoria_tareaid_tipo_categoria( )
      {
         AV109Empleado = dynavEmpleado.CurrentValue;
         AV110Cargo = dynavCargo.CurrentValue;
         AV101UsuarioDepartamento = dynavUsuariodepartamento.CurrentValue;
         AV6categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.CurrentValue, "."));
         AV8detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.CurrentValue, "."));
         AV15id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.CurrentValue, "."));
         AV7CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.CurrentValue, "."));
         GXVvDETALLE_INFOTECID_UNIDAD_html7O2( AV6categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html7O2( AV6categoria_tareaid_tipo_categoria) ;
         dynload_actions( ) ;
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV8detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV15id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV8detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8detalle_infotecid_unidad), 9, 0, ".", "")));
         dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV8detalle_infotecid_unidad), 9, 0));
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         AssignAttri("", false, "AV15id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15id_actividad_categoria), 9, 0, ".", "")));
         dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15id_actividad_categoria), 9, 0));
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
      }

      public void Validv_Id_actividad_categoria( )
      {
         AV109Empleado = dynavEmpleado.CurrentValue;
         AV110Cargo = dynavCargo.CurrentValue;
         AV101UsuarioDepartamento = dynavUsuariodepartamento.CurrentValue;
         AV6categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.CurrentValue, "."));
         AV8detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.CurrentValue, "."));
         AV15id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.CurrentValue, "."));
         AV7CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.CurrentValue, "."));
         GXVvCATEGORIADETALLETAREAID_html7O2( AV15id_actividad_categoria) ;
         dynload_actions( ) ;
         if ( dynavCategoriadetalletareaid.ItemCount > 0 )
         {
            AV7CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV7CategoriaDetalleTareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CategoriaDetalleTareaId), 4, 0, ".", "")));
         dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CategoriaDetalleTareaId), 4, 0));
         AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", dynavCategoriadetalletareaid.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV13EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9',hsh:true},{av:'AV14EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("'GUARDAR'","{handler:'E117O2',iparms:[{av:'cmbavPrioridad'},{av:'AV79TicketResponsableObservacion',fld:'vTICKETRESPONSABLEOBSERVACION',pic:''},{av:'AV105UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV102UsuarioEmail',fld:'vUSUARIOEMAIL',pic:''},{av:'AV103UsuarioFecha',fld:'vUSUARIOFECHA',pic:''},{av:'AV13EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9',hsh:true},{av:'AV14EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'dynavEmpleado'},{av:'dynavCargo'},{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("'CANCELAR'","{handler:'E127O2',iparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("'PRUEBA'","{handler:'E137O2',iparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("'PRUEBA'",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("VCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK","{handler:'E147O2',iparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("VCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_USUARIOFECHA","{handler:'Validv_Usuariofecha',iparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_USUARIOFECHA",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_USUARIOEMAIL","{handler:'Validv_Usuarioemail',iparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_USUARIOEMAIL",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA","{handler:'Validv_Categoria_tareaid_tipo_categoria',iparms:[{av:'AV111UsuarioConectado',fld:'vUSUARIOCONECTADO',pic:''},{av:'dynavEmpleado'},{av:'AV109Empleado',fld:'vEMPLEADO',pic:''},{av:'dynavCargo'},{av:'AV110Cargo',fld:'vCARGO',pic:''},{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("VALIDV_ID_ACTIVIDAD_CATEGORIA","{handler:'Validv_Id_actividad_categoria',iparms:[{av:'AV111UsuarioConectado',fld:'vUSUARIOCONECTADO',pic:''},{av:'dynavEmpleado'},{av:'AV109Empleado',fld:'vEMPLEADO',pic:''},{av:'dynavCargo'},{av:'AV110Cargo',fld:'vCARGO',pic:''},{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("VALIDV_ID_ACTIVIDAD_CATEGORIA",",oparms:[{av:'dynavUsuariodepartamento'},{av:'AV101UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV6categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV8detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV15id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV7CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
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
         AV111UsuarioConectado = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         forbiddenHiddens = new GXProperties();
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         TempTags = "";
         AV109Empleado = "";
         AV110Cargo = "";
         AV105UsuarioNombre = "";
         AV103UsuarioFecha = DateTime.MinValue;
         AV101UsuarioDepartamento = "";
         AV102UsuarioEmail = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         AV79TicketResponsableObservacion = "";
         AV17prioridad = "";
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
         H007O2_A6ResponsableId = new short[1] ;
         H007O2_A30ResponsableNombre = new string[] {""} ;
         H007O2_A96ResponsableUsuario = new string[] {""} ;
         H007O3_A6ResponsableId = new short[1] ;
         H007O3_A27ResponsableCargo = new string[] {""} ;
         H007O3_A96ResponsableUsuario = new string[] {""} ;
         H007O4_A360codigo_depto = new int[1] ;
         H007O4_A361nombre_depto = new string[] {""} ;
         H007O4_n361nombre_depto = new bool[] {false} ;
         H007O5_A105id_unidad_gis = new int[1] ;
         H007O5_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H007O6_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H007O6_A106nombre_categoria = new string[] {""} ;
         H007O6_n106nombre_categoria = new bool[] {false} ;
         H007O7_A102id_actividad_categoria = new int[1] ;
         H007O7_A123nombre_actividad = new string[] {""} ;
         H007O7_n123nombre_actividad = new bool[] {false} ;
         H007O7_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         H007O7_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         H007O7_A125actividades_categoriaestado = new int[1] ;
         H007O7_n125actividades_categoriaestado = new bool[] {false} ;
         H007O8_A294CategoriaDetalleTareaId = new short[1] ;
         H007O8_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         H007O8_A102id_actividad_categoria = new int[1] ;
         hsh = "";
         AV9detalle_tarea = "";
         AV5window = new GXWindow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptrabajodesarrollo__default(),
            new Object[][] {
                new Object[] {
               H007O2_A6ResponsableId, H007O2_A30ResponsableNombre, H007O2_A96ResponsableUsuario
               }
               , new Object[] {
               H007O3_A6ResponsableId, H007O3_A27ResponsableCargo, H007O3_A96ResponsableUsuario
               }
               , new Object[] {
               H007O8_A294CategoriaDetalleTareaId, H007O8_A295CategoriaDetalleTareaNombre, H007O8_A102id_actividad_categoria
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wptrabajodesarrollo__datastore1(),
            new Object[][] {
                new Object[] {
               H007O4_A360codigo_depto, H007O4_A361nombre_depto, H007O4_n361nombre_depto
               }
               , new Object[] {
               H007O5_A105id_unidad_gis, H007O5_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               H007O6_A104categoria_tareaid_tipo_categoria, H007O6_A106nombre_categoria, H007O6_n106nombre_categoria
               }
               , new Object[] {
               H007O7_A102id_actividad_categoria, H007O7_A123nombre_actividad, H007O7_n123nombre_actividad, H007O7_A122actividades_categoriaid_tipo_categoria, H007O7_n122actividades_categoriaid_tipo_categoria, H007O7_A125actividades_categoriaestado, H007O7_n125actividades_categoriaestado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavEmpleado.Enabled = 0;
         dynavCargo.Enabled = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV13EstadoTicketTicketId ;
      private short AV14EtapaDesarrolloId ;
      private short wbEnd ;
      private short wbStart ;
      private short AV7CategoriaDetalleTareaId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short ZV7CategoriaDetalleTareaId ;
      private int AV6categoria_tareaid_tipo_categoria ;
      private int AV15id_actividad_categoria ;
      private int AV8detalle_infotecid_unidad ;
      private int edtavUsuarionombre_Forecolor ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuariofecha_Enabled ;
      private int edtavUsuarioemail_Enabled ;
      private int lblTextblock1_Forecolor ;
      private int edtavTicketresponsableobservacion_Forecolor ;
      private int edtavTicketresponsableobservacion_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private int ZV8detalle_infotecid_unidad ;
      private int ZV15id_actividad_categoria ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable3_Internalname ;
      private string divTable25_Internalname ;
      private string divTable1_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string divTable5_Internalname ;
      private string divTable8_Internalname ;
      private string dynavEmpleado_Internalname ;
      private string TempTags ;
      private string dynavEmpleado_Jsonclick ;
      private string divTable9_Internalname ;
      private string dynavCargo_Internalname ;
      private string dynavCargo_Jsonclick ;
      private string divTable4_Internalname ;
      private string divTable26_Internalname ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divTable6_Internalname ;
      private string edtavUsuariofecha_Internalname ;
      private string edtavUsuariofecha_Jsonclick ;
      private string divTable27_Internalname ;
      private string dynavUsuariodepartamento_Internalname ;
      private string dynavUsuariodepartamento_Jsonclick ;
      private string divTable28_Internalname ;
      private string edtavUsuarioemail_Internalname ;
      private string edtavUsuarioemail_Jsonclick ;
      private string dynavDetalle_infotecid_unidad_Internalname ;
      private string dynavDetalle_infotecid_unidad_Jsonclick ;
      private string divTable20_Internalname ;
      private string divTable21_Internalname ;
      private string divTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable7_Internalname ;
      private string edtavTicketresponsableobservacion_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable13_Internalname ;
      private string divTable14_Internalname ;
      private string divTable15_Internalname ;
      private string divTable16_Internalname ;
      private string dynavCategoria_tareaid_tipo_categoria_Internalname ;
      private string dynavCategoria_tareaid_tipo_categoria_Jsonclick ;
      private string divTable18_Internalname ;
      private string dynavId_actividad_categoria_Internalname ;
      private string dynavId_actividad_categoria_Jsonclick ;
      private string divTable35_Internalname ;
      private string dynavCategoriadetalletareaid_Internalname ;
      private string dynavCategoriadetalletareaid_Jsonclick ;
      private string divTable29_Internalname ;
      private string cmbavPrioridad_Internalname ;
      private string cmbavPrioridad_Jsonclick ;
      private string divTable17_Internalname ;
      private string divTable19_Internalname ;
      private string divTable10_Internalname ;
      private string divTable11_Internalname ;
      private string bttGuardar_Internalname ;
      private string bttGuardar_Jsonclick ;
      private string divTable12_Internalname ;
      private string bttCancelar_Internalname ;
      private string bttCancelar_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string hsh ;
      private DateTime AV103UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV111UsuarioConectado ;
      private string AV109Empleado ;
      private string AV110Cargo ;
      private string AV105UsuarioNombre ;
      private string AV101UsuarioDepartamento ;
      private string AV102UsuarioEmail ;
      private string AV79TicketResponsableObservacion ;
      private string AV17prioridad ;
      private string AV9detalle_tarea ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEmpleado ;
      private GXCombobox dynavCargo ;
      private GXCombobox dynavUsuariodepartamento ;
      private GXCombobox dynavDetalle_infotecid_unidad ;
      private GXCombobox dynavCategoria_tareaid_tipo_categoria ;
      private GXCombobox dynavId_actividad_categoria ;
      private GXCombobox dynavCategoriadetalletareaid ;
      private GXCombobox cmbavPrioridad ;
      private IDataStoreProvider pr_default ;
      private short[] H007O2_A6ResponsableId ;
      private string[] H007O2_A30ResponsableNombre ;
      private string[] H007O2_A96ResponsableUsuario ;
      private short[] H007O3_A6ResponsableId ;
      private string[] H007O3_A27ResponsableCargo ;
      private string[] H007O3_A96ResponsableUsuario ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H007O4_A360codigo_depto ;
      private string[] H007O4_A361nombre_depto ;
      private bool[] H007O4_n361nombre_depto ;
      private int[] H007O5_A105id_unidad_gis ;
      private int[] H007O5_A104categoria_tareaid_tipo_categoria ;
      private int[] H007O6_A104categoria_tareaid_tipo_categoria ;
      private string[] H007O6_A106nombre_categoria ;
      private bool[] H007O6_n106nombre_categoria ;
      private int[] H007O7_A102id_actividad_categoria ;
      private string[] H007O7_A123nombre_actividad ;
      private bool[] H007O7_n123nombre_actividad ;
      private int[] H007O7_A122actividades_categoriaid_tipo_categoria ;
      private bool[] H007O7_n122actividades_categoriaid_tipo_categoria ;
      private int[] H007O7_A125actividades_categoriaestado ;
      private bool[] H007O7_n125actividades_categoriaestado ;
      private short[] H007O8_A294CategoriaDetalleTareaId ;
      private string[] H007O8_A295CategoriaDetalleTareaNombre ;
      private int[] H007O8_A102id_actividad_categoria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GXWindow AV5window ;
   }

   public class wptrabajodesarrollo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH007O2;
          prmH007O2 = new Object[] {
          new ParDef("@AV111UsuarioConectado",GXType.NVarChar,100,60)
          };
          Object[] prmH007O3;
          prmH007O3 = new Object[] {
          new ParDef("@AV111UsuarioConectado",GXType.NVarChar,100,60)
          };
          Object[] prmH007O8;
          prmH007O8 = new Object[] {
          new ParDef("@AV15id_actividad_categoria",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007O2", "SELECT [ResponsableId], [ResponsableNombre], [ResponsableUsuario] FROM [Responsable] WHERE [ResponsableUsuario] = @AV111UsuarioConectado ORDER BY [ResponsableNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007O3", "SELECT [ResponsableId], [ResponsableCargo], [ResponsableUsuario] FROM [Responsable] WHERE [ResponsableUsuario] = @AV111UsuarioConectado ORDER BY [ResponsableCargo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007O8", "SELECT [CategoriaDetalleTareaId], [CategoriaDetalleTareaNombre], [id_actividad_categoria] FROM [CategoriaDetalleTarea] WHERE [id_actividad_categoria] = @AV15id_actividad_categoria ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O8,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

 public class wptrabajodesarrollo__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH007O4;
        prmH007O4 = new Object[] {
        };
        Object[] prmH007O5;
        prmH007O5 = new Object[] {
        new ParDef("@AV6categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmH007O6;
        prmH007O6 = new Object[] {
        };
        Object[] prmH007O7;
        prmH007O7 = new Object[] {
        new ParDef("@AV6categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("H007O4", "SELECT [codigo_depto], [nombre_depto] FROM dbo.[deptos] ORDER BY [nombre_depto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O4,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007O5", "SELECT [id_unidad_gis], [id_tipo_categoria] AS categoria_tareaid_tipo_categoria FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @AV6categoria_tareaid_tipo_categoria ORDER BY [id_unidad_gis] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O5,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007O6", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = 14 or [id_tipo_categoria] = 15 ORDER BY [nombre_categoria] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O6,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007O7", "SELECT [id_actividad_categoria], [nombre_actividad], [id_tipo_categoria] AS actividades_categoriaid_tipo_categoria, [estado] AS actividades_categoriaestado FROM dbo.[actividades_categoria] WHERE ([id_tipo_categoria] = @AV6categoria_tareaid_tipo_categoria) AND ([estado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007O7,0, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((int[]) buf[5])[0] = rslt.getInt(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

}
