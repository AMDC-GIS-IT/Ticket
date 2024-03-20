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
   public class wptrabajosoportemodificar : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wptrabajosoportemodificar( )
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

      public wptrabajosoportemodificar( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( int aP0_correlativo ,
                           string aP1_nombre_emp1 ,
                           string aP2_cargo_emp1 ,
                           string aP3_nombre_usuario1 ,
                           DateTime aP4_fecha_registro1 ,
                           string aP5_depto_usuario1 ,
                           string aP6_correo_usuario1 ,
                           string aP7_observaciones1 ,
                           int aP8_detalle_infotecid_unidad1 ,
                           int aP9_id_categoria1 ,
                           int aP10_id_actividad1 ,
                           string aP11_prioridad1 ,
                           string aP12_fecha_solicitud )
      {
         this.AV34correlativo = aP0_correlativo;
         this.AV36nombre_emp1 = aP1_nombre_emp1;
         this.AV37cargo_emp1 = aP2_cargo_emp1;
         this.AV38nombre_usuario1 = aP3_nombre_usuario1;
         this.AV39fecha_registro1 = aP4_fecha_registro1;
         this.AV40depto_usuario1 = aP5_depto_usuario1;
         this.AV41correo_usuario1 = aP6_correo_usuario1;
         this.AV42observaciones1 = aP7_observaciones1;
         this.AV43detalle_infotecid_unidad1 = aP8_detalle_infotecid_unidad1;
         this.AV44id_categoria1 = aP9_id_categoria1;
         this.AV45id_actividad1 = aP10_id_actividad1;
         this.AV46prioridad1 = aP11_prioridad1;
         this.AV35fecha_solicitud = aP12_fecha_solicitud;
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
         cmbavPrioridad = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "correlativo");
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
               AV33UsuarioConectado = GetPar( "UsuarioConectado");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvEMPLEADO812( AV33UsuarioConectado) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCARGO") == 0 )
            {
               AV33UsuarioConectado = GetPar( "UsuarioConectado");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCARGO812( AV33UsuarioConectado) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vDETALLE_INFOTECID_UNIDAD") == 0 )
            {
               AV7categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV7categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvDETALLE_INFOTECID_UNIDAD812( AV7categoria_tareaid_tipo_categoria) ;
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
               GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA812( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vID_ACTIVIDAD_CATEGORIA") == 0 )
            {
               AV7categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV7categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvID_ACTIVIDAD_CATEGORIA812( AV7categoria_tareaid_tipo_categoria) ;
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
               gxfirstwebparm = GetFirstPar( "correlativo");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "correlativo");
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
               AV34correlativo = (int)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV34correlativo", StringUtil.LTrimStr( (decimal)(AV34correlativo), 9, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCORRELATIVO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34correlativo), "ZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV36nombre_emp1 = GetPar( "nombre_emp1");
                  AssignAttri("", false, "AV36nombre_emp1", AV36nombre_emp1);
                  AV37cargo_emp1 = GetPar( "cargo_emp1");
                  AssignAttri("", false, "AV37cargo_emp1", AV37cargo_emp1);
                  AV38nombre_usuario1 = GetPar( "nombre_usuario1");
                  AssignAttri("", false, "AV38nombre_usuario1", AV38nombre_usuario1);
                  GxWebStd.gx_hidden_field( context, "gxhash_vNOMBRE_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38nombre_usuario1, "")), context));
                  AV39fecha_registro1 = context.localUtil.ParseDateParm( GetPar( "fecha_registro1"));
                  AssignAttri("", false, "AV39fecha_registro1", context.localUtil.Format(AV39fecha_registro1, "99/99/99"));
                  AV40depto_usuario1 = GetPar( "depto_usuario1");
                  AssignAttri("", false, "AV40depto_usuario1", AV40depto_usuario1);
                  GxWebStd.gx_hidden_field( context, "gxhash_vDEPTO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40depto_usuario1, "")), context));
                  AV41correo_usuario1 = GetPar( "correo_usuario1");
                  AssignAttri("", false, "AV41correo_usuario1", AV41correo_usuario1);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCORREO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41correo_usuario1, "")), context));
                  AV42observaciones1 = GetPar( "observaciones1");
                  AssignAttri("", false, "AV42observaciones1", AV42observaciones1);
                  GxWebStd.gx_hidden_field( context, "gxhash_vOBSERVACIONES1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42observaciones1, "")), context));
                  AV43detalle_infotecid_unidad1 = (int)(NumberUtil.Val( GetPar( "detalle_infotecid_unidad1"), "."));
                  AssignAttri("", false, "AV43detalle_infotecid_unidad1", StringUtil.LTrimStr( (decimal)(AV43detalle_infotecid_unidad1), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDETALLE_INFOTECID_UNIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43detalle_infotecid_unidad1), "ZZZZZZZZ9"), context));
                  AV44id_categoria1 = (int)(NumberUtil.Val( GetPar( "id_categoria1"), "."));
                  AssignAttri("", false, "AV44id_categoria1", StringUtil.LTrimStr( (decimal)(AV44id_categoria1), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vID_CATEGORIA1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44id_categoria1), "ZZZZZZZZ9"), context));
                  AV45id_actividad1 = (int)(NumberUtil.Val( GetPar( "id_actividad1"), "."));
                  AssignAttri("", false, "AV45id_actividad1", StringUtil.LTrimStr( (decimal)(AV45id_actividad1), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vID_ACTIVIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV45id_actividad1), "ZZZZZZZZ9"), context));
                  AV46prioridad1 = GetPar( "prioridad1");
                  AssignAttri("", false, "AV46prioridad1", AV46prioridad1);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPRIORIDAD1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46prioridad1, "")), context));
                  AV35fecha_solicitud = GetPar( "fecha_solicitud");
                  AssignAttri("", false, "AV35fecha_solicitud", AV35fecha_solicitud);
                  GxWebStd.gx_hidden_field( context, "gxhash_vFECHA_SOLICITUD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35fecha_solicitud, "")), context));
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
            return "wptrabajosoportemodificar_Execute" ;
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
         PA812( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START812( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188221246", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wptrabajosoportemodificar.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV34correlativo,9,0)),UrlEncode(StringUtil.RTrim(AV36nombre_emp1)),UrlEncode(StringUtil.RTrim(AV37cargo_emp1)),UrlEncode(StringUtil.RTrim(AV38nombre_usuario1)),UrlEncode(DateTimeUtil.FormatDateParm(AV39fecha_registro1)),UrlEncode(StringUtil.RTrim(AV40depto_usuario1)),UrlEncode(StringUtil.RTrim(AV41correo_usuario1)),UrlEncode(StringUtil.RTrim(AV42observaciones1)),UrlEncode(StringUtil.LTrimStr(AV43detalle_infotecid_unidad1,9,0)),UrlEncode(StringUtil.LTrimStr(AV44id_categoria1,9,0)),UrlEncode(StringUtil.LTrimStr(AV45id_actividad1,9,0)),UrlEncode(StringUtil.RTrim(AV46prioridad1)),UrlEncode(StringUtil.RTrim(AV35fecha_solicitud))}, new string[] {"correlativo","nombre_emp1","cargo_emp1","nombre_usuario1","fecha_registro1","depto_usuario1","correo_usuario1","observaciones1","detalle_infotecid_unidad1","id_categoria1","id_actividad1","prioridad1","fecha_solicitud"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOTICKETTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EstadoTicketTicketId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16EtapaDesarrolloId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCORRELATIVO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34correlativo), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMBRE_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38nombre_usuario1, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDEPTO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40depto_usuario1, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vCORREO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41correo_usuario1, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOBSERVACIONES1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42observaciones1, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDETALLE_INFOTECID_UNIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43detalle_infotecid_unidad1), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID_CATEGORIA1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44id_categoria1), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID_ACTIVIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV45id_actividad1), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRIORIDAD1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46prioridad1, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHA_SOLICITUD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35fecha_solicitud, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"WPTrabajoSoporteModificar");
         forbiddenHiddens.Add("detalle_infotecid_unidad", context.localUtil.Format( (decimal)(AV9detalle_infotecid_unidad), "ZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wptrabajosoportemodificar:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EstadoTicketTicketId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOTICKETTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EstadoTicketTicketId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16EtapaDesarrolloId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vNOMBRE_EMP1", AV36nombre_emp1);
         GxWebStd.gx_hidden_field( context, "vCARGO_EMP1", AV37cargo_emp1);
         GxWebStd.gx_hidden_field( context, "vNOMBRE_USUARIO1", AV38nombre_usuario1);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMBRE_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38nombre_usuario1, "")), context));
         GxWebStd.gx_hidden_field( context, "vFECHA_REGISTRO1", context.localUtil.DToC( AV39fecha_registro1, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDEPTO_USUARIO1", AV40depto_usuario1);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEPTO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40depto_usuario1, "")), context));
         GxWebStd.gx_hidden_field( context, "vCORREO_USUARIO1", AV41correo_usuario1);
         GxWebStd.gx_hidden_field( context, "gxhash_vCORREO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41correo_usuario1, "")), context));
         GxWebStd.gx_hidden_field( context, "vOBSERVACIONES1", AV42observaciones1);
         GxWebStd.gx_hidden_field( context, "gxhash_vOBSERVACIONES1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42observaciones1, "")), context));
         GxWebStd.gx_hidden_field( context, "vDETALLE_INFOTECID_UNIDAD1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43detalle_infotecid_unidad1), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDETALLE_INFOTECID_UNIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43detalle_infotecid_unidad1), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vID_CATEGORIA1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44id_categoria1), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID_CATEGORIA1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44id_categoria1), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vID_ACTIVIDAD1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV45id_actividad1), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID_ACTIVIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV45id_actividad1), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPRIORIDAD1", AV46prioridad1);
         GxWebStd.gx_hidden_field( context, "gxhash_vPRIORIDAD1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46prioridad1, "")), context));
         GxWebStd.gx_hidden_field( context, "vFECHA_SOLICITUD", AV35fecha_solicitud);
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHA_SOLICITUD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35fecha_solicitud, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOCONECTADO", AV33UsuarioConectado);
         GxWebStd.gx_hidden_field( context, "vCATEGORIA_TAREAID_TIPO_CATEGORIA_Text", StringUtil.RTrim( dynavCategoria_tareaid_tipo_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vID_ACTIVIDAD_CATEGORIA_Text", StringUtil.RTrim( dynavId_actividad_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vPRIORIDAD_Text", StringUtil.RTrim( cmbavPrioridad.Description));
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
            WE812( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT812( ) ;
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
         return formatLink("wptrabajosoportemodificar.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV34correlativo,9,0)),UrlEncode(StringUtil.RTrim(AV36nombre_emp1)),UrlEncode(StringUtil.RTrim(AV37cargo_emp1)),UrlEncode(StringUtil.RTrim(AV38nombre_usuario1)),UrlEncode(DateTimeUtil.FormatDateParm(AV39fecha_registro1)),UrlEncode(StringUtil.RTrim(AV40depto_usuario1)),UrlEncode(StringUtil.RTrim(AV41correo_usuario1)),UrlEncode(StringUtil.RTrim(AV42observaciones1)),UrlEncode(StringUtil.LTrimStr(AV43detalle_infotecid_unidad1,9,0)),UrlEncode(StringUtil.LTrimStr(AV44id_categoria1,9,0)),UrlEncode(StringUtil.LTrimStr(AV45id_actividad1,9,0)),UrlEncode(StringUtil.RTrim(AV46prioridad1)),UrlEncode(StringUtil.RTrim(AV35fecha_solicitud))}, new string[] {"correlativo","nombre_emp1","cargo_emp1","nombre_usuario1","fecha_registro1","depto_usuario1","correo_usuario1","observaciones1","detalle_infotecid_unidad1","id_categoria1","id_actividad1","prioridad1","fecha_solicitud"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPTrabajoSoporteModificar" ;
      }

      public override string GetPgmdesc( )
      {
         return "WPTrabajo Soporte Modificar" ;
      }

      protected void WB810( )
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Gerencia de Información y Sistemas", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle1", 0, "", 1, 1, 0, 0, "HLP_WPTrabajoSoporteModificar.htm");
            GxWebStd.gx_div_end( context, "Center", "Middle", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "Middle", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "<<Modificar de Trabajo Diario>>", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPTrabajoSoporteModificar.htm");
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
            GxWebStd.gx_div_start( context, divTable22_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavCorrelativo_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCorrelativo_Internalname, "No. Trabajo:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavCorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV34correlativo), 9, 0, ".", "")), StringUtil.LTrim( ((edtavCorrelativo_Enabled!=0) ? context.localUtil.Format( (decimal)(AV34correlativo), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV34correlativo), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCorrelativo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavCorrelativo_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPTrabajoSoporteModificar.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEmpleado, dynavEmpleado_Internalname, StringUtil.RTrim( AV13Empleado), 1, dynavEmpleado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavEmpleado.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavEmpleado.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            dynavEmpleado.CurrentValue = StringUtil.RTrim( AV13Empleado);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCargo, dynavCargo_Internalname, StringUtil.RTrim( AV6Cargo), 1, dynavCargo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavCargo.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCargo.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            dynavCargo.CurrentValue = StringUtil.RTrim( AV6Cargo);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV30UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV30UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavUsuarionombre_Forecolor)+";", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPTrabajoSoporteModificar.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUsuariofecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUsuariofecha_Internalname, context.localUtil.Format(AV28UsuarioFecha, "99/99/9999"), context.localUtil.Format( AV28UsuarioFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuariofecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuariofecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPTrabajoSoporteModificar.htm");
            GxWebStd.gx_bitmap( context, edtavUsuariofecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavUsuariofecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPTrabajoSoporteModificar.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavUsuariodepartamento, dynavUsuariodepartamento_Internalname, StringUtil.RTrim( AV26UsuarioDepartamento), 1, dynavUsuariodepartamento_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, dynavUsuariodepartamento.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavUsuariodepartamento.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            dynavUsuariodepartamento.CurrentValue = StringUtil.RTrim( AV26UsuarioDepartamento);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsuarioemail_Internalname, AV27UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( AV27UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioemail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "", "left", true, "", "HLP_WPTrabajoSoporteModificar.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavDetalle_infotecid_unidad, dynavDetalle_infotecid_unidad_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0)), 1, dynavDetalle_infotecid_unidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", dynavDetalle_infotecid_unidad.Visible, dynavDetalle_infotecid_unidad.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Observaciones: ", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock1_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPTrabajoSoporteModificar.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavTicketresponsableobservacion_Internalname, AV24TicketResponsableObservacion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,109);\"", 0, 1, edtavTicketresponsableobservacion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPTrabajoSoporteModificar.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoria_tareaid_tipo_categoria, dynavCategoria_tareaid_tipo_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0)), 1, dynavCategoria_tareaid_tipo_categoria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCategoria_tareaid_tipo_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCategoria_tareaid_tipo_categoria.ForeColor)+";", "Attribute_Color", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 134,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavId_actividad_categoria, dynavId_actividad_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0)), 1, dynavId_actividad_categoria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavId_actividad_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavId_actividad_categoria.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,134);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0));
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
            GxWebStd.gx_combobox_ctrl1( context, cmbavPrioridad, cmbavPrioridad_Internalname, StringUtil.RTrim( AV19prioridad), 1, cmbavPrioridad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavPrioridad.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( cmbavPrioridad.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "", true, 1, "HLP_WPTrabajoSoporteModificar.htm");
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV19prioridad);
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
            GxWebStd.gx_div_start( context, divTable19_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPTrabajoSoporteModificar.htm");
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
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPTrabajoSoporteModificar.htm");
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

      protected void START812( )
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
            Form.Meta.addItem("description", "WPTrabajo Soporte Modificar", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP810( ) ;
      }

      protected void WS812( )
      {
         START812( ) ;
         EVT812( ) ;
      }

      protected void EVT812( )
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
                              E11812 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E12812 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba' */
                              E13812 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E14812 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E15812 ();
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

      protected void WE812( )
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

      protected void PA812( )
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
         /* End function dynload_actions */
      }

      protected void GXDLVvUSUARIODEPARTAMENTO811( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvUSUARIODEPARTAMENTO_data811( ) ;
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

      protected void GXVvUSUARIODEPARTAMENTO_html811( )
      {
         string gxdynajaxvalue;
         GXDLVvUSUARIODEPARTAMENTO_data811( ) ;
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
         if ( dynavUsuariodepartamento.ItemCount > 0 )
         {
            AV26UsuarioDepartamento = dynavUsuariodepartamento.getValidValue(AV26UsuarioDepartamento);
            AssignAttri("", false, "AV26UsuarioDepartamento", AV26UsuarioDepartamento);
         }
      }

      protected void GXDLVvUSUARIODEPARTAMENTO_data811( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00812 */
         pr_datastore1.execute(0);
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H00812_A361nombre_depto[0]);
            gxdynajaxctrldescr.Add(H00812_A361nombre_depto[0]);
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
      }

      protected void GXDLVvEMPLEADO812( string AV33UsuarioConectado )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvEMPLEADO_data812( AV33UsuarioConectado) ;
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

      protected void GXVvEMPLEADO_html812( string AV33UsuarioConectado )
      {
         string gxdynajaxvalue;
         GXDLVvEMPLEADO_data812( AV33UsuarioConectado) ;
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
            AV13Empleado = dynavEmpleado.getValidValue(AV13Empleado);
            AssignAttri("", false, "AV13Empleado", AV13Empleado);
         }
      }

      protected void GXDLVvEMPLEADO_data812( string AV33UsuarioConectado )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00813 */
         pr_default.execute(0, new Object[] {AV33UsuarioConectado});
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(H00813_A30ResponsableNombre[0]);
            gxdynajaxctrldescr.Add(H00813_A30ResponsableNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvCARGO812( string AV33UsuarioConectado )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCARGO_data812( AV33UsuarioConectado) ;
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

      protected void GXVvCARGO_html812( string AV33UsuarioConectado )
      {
         string gxdynajaxvalue;
         GXDLVvCARGO_data812( AV33UsuarioConectado) ;
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
            AV6Cargo = dynavCargo.getValidValue(AV6Cargo);
            AssignAttri("", false, "AV6Cargo", AV6Cargo);
         }
      }

      protected void GXDLVvCARGO_data812( string AV33UsuarioConectado )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H00814 */
         pr_default.execute(1, new Object[] {AV33UsuarioConectado});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(H00814_A27ResponsableCargo[0]);
            gxdynajaxctrldescr.Add(H00814_A27ResponsableCargo[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD812( int AV7categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data812( AV7categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvDETALLE_INFOTECID_UNIDAD_html812( int AV7categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data812( AV7categoria_tareaid_tipo_categoria) ;
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

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD_data812( int AV7categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H00815 */
         pr_datastore1.execute(1, new Object[] {AV7categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00815_A105id_unidad_gis[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00815_A105id_unidad_gis[0]), 9, 0, ".", "")));
            pr_datastore1.readNext(1);
         }
         pr_datastore1.close(1);
      }

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA812( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data812( ) ;
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

      protected void GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html812( )
      {
         int gxdynajaxvalue;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data812( ) ;
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

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data812( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H00816 */
         pr_datastore1.execute(2);
         while ( (pr_datastore1.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00816_A104categoria_tareaid_tipo_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00816_A106nombre_categoria[0]);
            pr_datastore1.readNext(2);
         }
         pr_datastore1.close(2);
      }

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA812( int AV7categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data812( AV7categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvID_ACTIVIDAD_CATEGORIA_html812( int AV7categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data812( AV7categoria_tareaid_tipo_categoria) ;
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

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA_data812( int AV7categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H00817 */
         pr_datastore1.execute(3, new Object[] {AV7categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H00817_A102id_actividad_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H00817_A123nombre_actividad[0]);
            pr_datastore1.readNext(3);
         }
         pr_datastore1.close(3);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html812( ) ;
            dynavUsuariodepartamento.Name = "vUSUARIODEPARTAMENTO";
            dynavUsuariodepartamento.WebTags = "";
            dynavUsuariodepartamento.removeAllItems();
            /* Using cursor H00818 */
            pr_datastore1.execute(4);
            while ( (pr_datastore1.getStatus(4) != 101) )
            {
               dynavUsuariodepartamento.addItem(H00818_A361nombre_depto[0], H00818_A361nombre_depto[0], 0);
               pr_datastore1.readNext(4);
            }
            pr_datastore1.close(4);
            if ( dynavUsuariodepartamento.ItemCount > 0 )
            {
               AV26UsuarioDepartamento = dynavUsuariodepartamento.getValidValue(AV26UsuarioDepartamento);
               AssignAttri("", false, "AV26UsuarioDepartamento", AV26UsuarioDepartamento);
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEmpleado.ItemCount > 0 )
         {
            AV13Empleado = dynavEmpleado.getValidValue(AV13Empleado);
            AssignAttri("", false, "AV13Empleado", AV13Empleado);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEmpleado.CurrentValue = StringUtil.RTrim( AV13Empleado);
            AssignProp("", false, dynavEmpleado_Internalname, "Values", dynavEmpleado.ToJavascriptSource(), true);
         }
         if ( dynavCargo.ItemCount > 0 )
         {
            AV6Cargo = dynavCargo.getValidValue(AV6Cargo);
            AssignAttri("", false, "AV6Cargo", AV6Cargo);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCargo.CurrentValue = StringUtil.RTrim( AV6Cargo);
            AssignProp("", false, dynavCargo_Internalname, "Values", dynavCargo.ToJavascriptSource(), true);
         }
         if ( dynavUsuariodepartamento.ItemCount > 0 )
         {
            AV26UsuarioDepartamento = dynavUsuariodepartamento.getValidValue(AV26UsuarioDepartamento);
            AssignAttri("", false, "AV26UsuarioDepartamento", AV26UsuarioDepartamento);
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavUsuariodepartamento.CurrentValue = StringUtil.RTrim( AV26UsuarioDepartamento);
            AssignProp("", false, dynavUsuariodepartamento_Internalname, "Values", dynavUsuariodepartamento.ToJavascriptSource(), true);
         }
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV9detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0))), "."));
            AssignAttri("", false, "AV9detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         }
         if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
         {
            AV7categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV7categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
            AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Values", dynavCategoria_tareaid_tipo_categoria.ToJavascriptSource(), true);
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV17id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV17id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV17id_actividad_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0));
            AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
         }
         if ( cmbavPrioridad.ItemCount > 0 )
         {
            AV19prioridad = cmbavPrioridad.getValidValue(AV19prioridad);
            AssignAttri("", false, "AV19prioridad", AV19prioridad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV19prioridad);
            AssignProp("", false, cmbavPrioridad_Internalname, "Values", cmbavPrioridad.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF812( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCorrelativo_Enabled = 0;
         AssignProp("", false, edtavCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCorrelativo_Enabled), 5, 0), true);
         dynavEmpleado.Enabled = 0;
         AssignProp("", false, dynavEmpleado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmpleado.Enabled), 5, 0), true);
         dynavCargo.Enabled = 0;
         AssignProp("", false, dynavCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCargo.Enabled), 5, 0), true);
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
      }

      protected void RF812( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E15812 ();
            WB810( ) ;
         }
      }

      protected void send_integrity_lvl_hashes812( )
      {
         GxWebStd.gx_hidden_field( context, "vESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15EstadoTicketTicketId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vESTADOTICKETTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15EstadoTicketTicketId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16EtapaDesarrolloId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavCorrelativo_Enabled = 0;
         AssignProp("", false, edtavCorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCorrelativo_Enabled), 5, 0), true);
         dynavEmpleado.Enabled = 0;
         AssignProp("", false, dynavEmpleado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavEmpleado.Enabled), 5, 0), true);
         dynavCargo.Enabled = 0;
         AssignProp("", false, dynavCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavCargo.Enabled), 5, 0), true);
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
         GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html812( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP810( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E14812 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         GXVvEMPLEADO_html812( AV33UsuarioConectado) ;
         GXVvCARGO_html812( AV33UsuarioConectado) ;
         GXVvDETALLE_INFOTECID_UNIDAD_html812( AV7categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html812( AV7categoria_tareaid_tipo_categoria) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavEmpleado.CurrentValue = cgiGet( dynavEmpleado_Internalname);
            AV13Empleado = cgiGet( dynavEmpleado_Internalname);
            AssignAttri("", false, "AV13Empleado", AV13Empleado);
            dynavCargo.CurrentValue = cgiGet( dynavCargo_Internalname);
            AV6Cargo = cgiGet( dynavCargo_Internalname);
            AssignAttri("", false, "AV6Cargo", AV6Cargo);
            AV30UsuarioNombre = cgiGet( edtavUsuarionombre_Internalname);
            AssignAttri("", false, "AV30UsuarioNombre", AV30UsuarioNombre);
            if ( context.localUtil.VCDate( cgiGet( edtavUsuariofecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Usuario Fecha"}), 1, "vUSUARIOFECHA");
               GX_FocusControl = edtavUsuariofecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV28UsuarioFecha = DateTime.MinValue;
               AssignAttri("", false, "AV28UsuarioFecha", context.localUtil.Format(AV28UsuarioFecha, "99/99/9999"));
            }
            else
            {
               AV28UsuarioFecha = context.localUtil.CToD( cgiGet( edtavUsuariofecha_Internalname), 2);
               AssignAttri("", false, "AV28UsuarioFecha", context.localUtil.Format(AV28UsuarioFecha, "99/99/9999"));
            }
            dynavUsuariodepartamento.CurrentValue = cgiGet( dynavUsuariodepartamento_Internalname);
            AV26UsuarioDepartamento = cgiGet( dynavUsuariodepartamento_Internalname);
            AssignAttri("", false, "AV26UsuarioDepartamento", AV26UsuarioDepartamento);
            AV27UsuarioEmail = cgiGet( edtavUsuarioemail_Internalname);
            AssignAttri("", false, "AV27UsuarioEmail", AV27UsuarioEmail);
            dynavDetalle_infotecid_unidad.CurrentValue = cgiGet( dynavDetalle_infotecid_unidad_Internalname);
            AV9detalle_infotecid_unidad = (int)(NumberUtil.Val( cgiGet( dynavDetalle_infotecid_unidad_Internalname), "."));
            AssignAttri("", false, "AV9detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
            AV24TicketResponsableObservacion = cgiGet( edtavTicketresponsableobservacion_Internalname);
            AssignAttri("", false, "AV24TicketResponsableObservacion", AV24TicketResponsableObservacion);
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname);
            AV7categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname), "."));
            AssignAttri("", false, "AV7categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
            dynavId_actividad_categoria.CurrentValue = cgiGet( dynavId_actividad_categoria_Internalname);
            AV17id_actividad_categoria = (int)(NumberUtil.Val( cgiGet( dynavId_actividad_categoria_Internalname), "."));
            AssignAttri("", false, "AV17id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV17id_actividad_categoria), 9, 0));
            cmbavPrioridad.CurrentValue = cgiGet( cmbavPrioridad_Internalname);
            AV19prioridad = cgiGet( cmbavPrioridad_Internalname);
            AssignAttri("", false, "AV19prioridad", AV19prioridad);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"WPTrabajoSoporteModificar");
            AV9detalle_infotecid_unidad = (int)(NumberUtil.Val( cgiGet( dynavDetalle_infotecid_unidad_Internalname), "."));
            AssignAttri("", false, "AV9detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
            forbiddenHiddens.Add("detalle_infotecid_unidad", context.localUtil.Format( (decimal)(AV9detalle_infotecid_unidad), "ZZZZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("wptrabajosoportemodificar:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusDescription = 403.ToString();
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               return  ;
            }
            GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html812( ) ;
            GXVvEMPLEADO_html812( AV33UsuarioConectado) ;
            GXVvCARGO_html812( AV33UsuarioConectado) ;
            GXVvDETALLE_INFOTECID_UNIDAD_html812( AV7categoria_tareaid_tipo_categoria) ;
            GXVvID_ACTIVIDAD_CATEGORIA_html812( AV7categoria_tareaid_tipo_categoria) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E11812( )
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
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV24TicketResponsableObservacion)) )
                  {
                     context.PopUp(formatLink("webpanelmsgobservacion.aspx") , new Object[] {});
                  }
                  else
                  {
                     AV10detalle_tarea = dynavCategoria_tareaid_tipo_categoria.Description + "/-" + dynavId_actividad_categoria.Description;
                     new pcrmodificarinfotec(context ).execute(  AV7categoria_tareaid_tipo_categoria,  AV17id_actividad_categoria,  AV30UsuarioNombre,  AV26UsuarioDepartamento,  AV27UsuarioEmail,  AV9detalle_infotecid_unidad,  AV10detalle_tarea,  cmbavPrioridad.Description,  AV28UsuarioFecha,  AV15EstadoTicketTicketId,  AV16EtapaDesarrolloId,  AV24TicketResponsableObservacion,  dynavEmpleado.Description,  dynavCargo.Description,  AV34correlativo) ;
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

      protected void E12812( )
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

      protected void E13812( )
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

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E14812 ();
         if (returnInSub) return;
      }

      protected void E14812( )
      {
         /* Start Routine */
         returnInSub = false;
         dynavCategoria_tareaid_tipo_categoria.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavCategoria_tareaid_tipo_categoria.ForeColor), 9, 0), true);
         dynavId_actividad_categoria.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavId_actividad_categoria.ForeColor), 9, 0), true);
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
         AV33UsuarioConectado = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         dynavEmpleado.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavEmpleado_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavEmpleado.ForeColor), 9, 0), true);
         dynavCargo.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavCargo_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavCargo.ForeColor), 9, 0), true);
         AV30UsuarioNombre = AV38nombre_usuario1;
         AssignAttri("", false, "AV30UsuarioNombre", AV30UsuarioNombre);
         AV28UsuarioFecha = context.localUtil.CToD( AV35fecha_solicitud, 2);
         AssignAttri("", false, "AV28UsuarioFecha", context.localUtil.Format(AV28UsuarioFecha, "99/99/9999"));
         AV26UsuarioDepartamento = AV40depto_usuario1;
         AssignAttri("", false, "AV26UsuarioDepartamento", AV26UsuarioDepartamento);
         AV27UsuarioEmail = AV41correo_usuario1;
         AssignAttri("", false, "AV27UsuarioEmail", AV27UsuarioEmail);
         AV9detalle_infotecid_unidad = AV43detalle_infotecid_unidad1;
         AssignAttri("", false, "AV9detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
         AV24TicketResponsableObservacion = AV42observaciones1;
         AssignAttri("", false, "AV24TicketResponsableObservacion", AV24TicketResponsableObservacion);
         AV7categoria_tareaid_tipo_categoria = AV44id_categoria1;
         AssignAttri("", false, "AV7categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV7categoria_tareaid_tipo_categoria), 9, 0));
         AV17id_actividad_categoria = AV45id_actividad1;
         AssignAttri("", false, "AV17id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV17id_actividad_categoria), 9, 0));
         AV19prioridad = AV46prioridad1;
         AssignAttri("", false, "AV19prioridad", AV19prioridad);
      }

      protected void nextLoad( )
      {
      }

      protected void E15812( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV34correlativo = Convert.ToInt32(getParm(obj,0));
         AssignAttri("", false, "AV34correlativo", StringUtil.LTrimStr( (decimal)(AV34correlativo), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCORRELATIVO", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV34correlativo), "ZZZZZZZZ9"), context));
         AV36nombre_emp1 = (string)getParm(obj,1);
         AssignAttri("", false, "AV36nombre_emp1", AV36nombre_emp1);
         AV37cargo_emp1 = (string)getParm(obj,2);
         AssignAttri("", false, "AV37cargo_emp1", AV37cargo_emp1);
         AV38nombre_usuario1 = (string)getParm(obj,3);
         AssignAttri("", false, "AV38nombre_usuario1", AV38nombre_usuario1);
         GxWebStd.gx_hidden_field( context, "gxhash_vNOMBRE_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV38nombre_usuario1, "")), context));
         AV39fecha_registro1 = (DateTime)getParm(obj,4);
         AssignAttri("", false, "AV39fecha_registro1", context.localUtil.Format(AV39fecha_registro1, "99/99/99"));
         AV40depto_usuario1 = (string)getParm(obj,5);
         AssignAttri("", false, "AV40depto_usuario1", AV40depto_usuario1);
         GxWebStd.gx_hidden_field( context, "gxhash_vDEPTO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV40depto_usuario1, "")), context));
         AV41correo_usuario1 = (string)getParm(obj,6);
         AssignAttri("", false, "AV41correo_usuario1", AV41correo_usuario1);
         GxWebStd.gx_hidden_field( context, "gxhash_vCORREO_USUARIO1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV41correo_usuario1, "")), context));
         AV42observaciones1 = (string)getParm(obj,7);
         AssignAttri("", false, "AV42observaciones1", AV42observaciones1);
         GxWebStd.gx_hidden_field( context, "gxhash_vOBSERVACIONES1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV42observaciones1, "")), context));
         AV43detalle_infotecid_unidad1 = Convert.ToInt32(getParm(obj,8));
         AssignAttri("", false, "AV43detalle_infotecid_unidad1", StringUtil.LTrimStr( (decimal)(AV43detalle_infotecid_unidad1), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vDETALLE_INFOTECID_UNIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV43detalle_infotecid_unidad1), "ZZZZZZZZ9"), context));
         AV44id_categoria1 = Convert.ToInt32(getParm(obj,9));
         AssignAttri("", false, "AV44id_categoria1", StringUtil.LTrimStr( (decimal)(AV44id_categoria1), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID_CATEGORIA1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV44id_categoria1), "ZZZZZZZZ9"), context));
         AV45id_actividad1 = Convert.ToInt32(getParm(obj,10));
         AssignAttri("", false, "AV45id_actividad1", StringUtil.LTrimStr( (decimal)(AV45id_actividad1), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID_ACTIVIDAD1", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV45id_actividad1), "ZZZZZZZZ9"), context));
         AV46prioridad1 = (string)getParm(obj,11);
         AssignAttri("", false, "AV46prioridad1", AV46prioridad1);
         GxWebStd.gx_hidden_field( context, "gxhash_vPRIORIDAD1", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46prioridad1, "")), context));
         AV35fecha_solicitud = (string)getParm(obj,12);
         AssignAttri("", false, "AV35fecha_solicitud", AV35fecha_solicitud);
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHA_SOLICITUD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV35fecha_solicitud, "")), context));
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
         PA812( ) ;
         WS812( ) ;
         WE812( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188221552", true, true);
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
         context.AddJavascriptSource("wptrabajosoportemodificar.js", "?2024188221553", false, true);
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
         dynavUsuariodepartamento.removeAllItems();
         /* Using cursor H00819 */
         pr_datastore1.execute(5);
         while ( (pr_datastore1.getStatus(5) != 101) )
         {
            dynavUsuariodepartamento.addItem(H00819_A361nombre_depto[0], H00819_A361nombre_depto[0], 0);
            pr_datastore1.readNext(5);
         }
         pr_datastore1.close(5);
         if ( dynavUsuariodepartamento.ItemCount > 0 )
         {
            AV26UsuarioDepartamento = dynavUsuariodepartamento.getValidValue(AV26UsuarioDepartamento);
            AssignAttri("", false, "AV26UsuarioDepartamento", AV26UsuarioDepartamento);
         }
         dynavDetalle_infotecid_unidad.Name = "vDETALLE_INFOTECID_UNIDAD";
         dynavDetalle_infotecid_unidad.WebTags = "";
         dynavCategoria_tareaid_tipo_categoria.Name = "vCATEGORIA_TAREAID_TIPO_CATEGORIA";
         dynavCategoria_tareaid_tipo_categoria.WebTags = "";
         dynavId_actividad_categoria.Name = "vID_ACTIVIDAD_CATEGORIA";
         dynavId_actividad_categoria.WebTags = "";
         cmbavPrioridad.Name = "vPRIORIDAD";
         cmbavPrioridad.WebTags = "";
         cmbavPrioridad.addItem("", "(Ninguno)", 0);
         cmbavPrioridad.addItem("1", "BAJA", 0);
         cmbavPrioridad.addItem("2", "MEDIA", 0);
         cmbavPrioridad.addItem("3", "ALTA", 0);
         if ( cmbavPrioridad.ItemCount > 0 )
         {
            AV19prioridad = cmbavPrioridad.getValidValue(AV19prioridad);
            AssignAttri("", false, "AV19prioridad", AV19prioridad);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         divTable1_Internalname = "TABLE1";
         edtavCorrelativo_Internalname = "vCORRELATIVO";
         divTable22_Internalname = "TABLE22";
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
         divTable17_Internalname = "TABLE17";
         divTable19_Internalname = "TABLE19";
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
         edtavCorrelativo_Jsonclick = "";
         edtavCorrelativo_Enabled = 0;
         dynavCargo.Description = "";
         dynavEmpleado.Description = "";
         cmbavPrioridad.Description = "";
         dynavId_actividad_categoria.Description = "";
         dynavCategoria_tareaid_tipo_categoria.Description = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WPTrabajo Soporte Modificar";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Categoria_tareaid_tipo_categoria( )
      {
         AV13Empleado = dynavEmpleado.CurrentValue;
         AV6Cargo = dynavCargo.CurrentValue;
         AV7categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.CurrentValue, "."));
         AV9detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.CurrentValue, "."));
         AV17id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.CurrentValue, "."));
         AV26UsuarioDepartamento = dynavUsuariodepartamento.CurrentValue;
         GXVvDETALLE_INFOTECID_UNIDAD_html812( AV7categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html812( AV7categoria_tareaid_tipo_categoria) ;
         dynload_actions( ) ;
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV9detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV17id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV9detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9detalle_infotecid_unidad), 9, 0, ".", "")));
         dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV9detalle_infotecid_unidad), 9, 0));
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         AssignAttri("", false, "AV17id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17id_actividad_categoria), 9, 0, ".", "")));
         dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17id_actividad_categoria), 9, 0));
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV15EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9',hsh:true},{av:'AV16EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'AV38nombre_usuario1',fld:'vNOMBRE_USUARIO1',pic:'',hsh:true},{av:'AV40depto_usuario1',fld:'vDEPTO_USUARIO1',pic:'',hsh:true},{av:'AV41correo_usuario1',fld:'vCORREO_USUARIO1',pic:'',hsh:true},{av:'AV42observaciones1',fld:'vOBSERVACIONES1',pic:'',hsh:true},{av:'AV43detalle_infotecid_unidad1',fld:'vDETALLE_INFOTECID_UNIDAD1',pic:'ZZZZZZZZ9',hsh:true},{av:'AV44id_categoria1',fld:'vID_CATEGORIA1',pic:'ZZZZZZZZ9',hsh:true},{av:'AV45id_actividad1',fld:'vID_ACTIVIDAD1',pic:'ZZZZZZZZ9',hsh:true},{av:'AV46prioridad1',fld:'vPRIORIDAD1',pic:'',hsh:true},{av:'AV35fecha_solicitud',fld:'vFECHA_SOLICITUD',pic:'',hsh:true},{av:'AV34correlativo',fld:'vCORRELATIVO',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavDetalle_infotecid_unidad'},{av:'AV9detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
         setEventMetadata("'GUARDAR'","{handler:'E11812',iparms:[{av:'dynavId_actividad_categoria'},{av:'cmbavPrioridad'},{av:'AV24TicketResponsableObservacion',fld:'vTICKETRESPONSABLEOBSERVACION',pic:''},{av:'AV17id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV30UsuarioNombre',fld:'vUSUARIONOMBRE',pic:''},{av:'AV27UsuarioEmail',fld:'vUSUARIOEMAIL',pic:''},{av:'dynavDetalle_infotecid_unidad'},{av:'AV9detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'AV28UsuarioFecha',fld:'vUSUARIOFECHA',pic:''},{av:'AV15EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9',hsh:true},{av:'AV16EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'dynavEmpleado'},{av:'dynavCargo'},{av:'AV34correlativo',fld:'vCORRELATIVO',pic:'ZZZZZZZZ9',hsh:true},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E12812',iparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
         setEventMetadata("'PRUEBA'","{handler:'E13812',iparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("'PRUEBA'",",oparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
         setEventMetadata("VALIDV_USUARIOFECHA","{handler:'Validv_Usuariofecha',iparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("VALIDV_USUARIOFECHA",",oparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
         setEventMetadata("VALIDV_USUARIOEMAIL","{handler:'Validv_Usuarioemail',iparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("VALIDV_USUARIOEMAIL",",oparms:[{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA","{handler:'Validv_Categoria_tareaid_tipo_categoria',iparms:[{av:'AV33UsuarioConectado',fld:'vUSUARIOCONECTADO',pic:''},{av:'dynavEmpleado'},{av:'AV13Empleado',fld:'vEMPLEADO',pic:''},{av:'dynavCargo'},{av:'AV6Cargo',fld:'vCARGO',pic:''},{av:'dynavDetalle_infotecid_unidad'},{av:'AV9detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV17id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA",",oparms:[{av:'dynavDetalle_infotecid_unidad'},{av:'AV9detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV17id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV7categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavUsuariodepartamento'},{av:'AV26UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:''}]}");
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
         wcpOAV36nombre_emp1 = "";
         wcpOAV37cargo_emp1 = "";
         wcpOAV38nombre_usuario1 = "";
         wcpOAV39fecha_registro1 = DateTime.MinValue;
         wcpOAV40depto_usuario1 = "";
         wcpOAV41correo_usuario1 = "";
         wcpOAV42observaciones1 = "";
         wcpOAV46prioridad1 = "";
         wcpOAV35fecha_solicitud = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV33UsuarioConectado = "";
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
         AV13Empleado = "";
         AV6Cargo = "";
         AV30UsuarioNombre = "";
         AV28UsuarioFecha = DateTime.MinValue;
         AV26UsuarioDepartamento = "";
         AV27UsuarioEmail = "";
         lblTextblock1_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         AV24TicketResponsableObservacion = "";
         AV19prioridad = "";
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
         H00812_A360codigo_depto = new int[1] ;
         H00812_A361nombre_depto = new string[] {""} ;
         H00812_n361nombre_depto = new bool[] {false} ;
         H00813_A6ResponsableId = new short[1] ;
         H00813_A30ResponsableNombre = new string[] {""} ;
         H00813_A96ResponsableUsuario = new string[] {""} ;
         H00814_A6ResponsableId = new short[1] ;
         H00814_A27ResponsableCargo = new string[] {""} ;
         H00814_A96ResponsableUsuario = new string[] {""} ;
         H00815_A105id_unidad_gis = new int[1] ;
         H00815_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H00816_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H00816_A106nombre_categoria = new string[] {""} ;
         H00816_n106nombre_categoria = new bool[] {false} ;
         H00817_A102id_actividad_categoria = new int[1] ;
         H00817_A123nombre_actividad = new string[] {""} ;
         H00817_n123nombre_actividad = new bool[] {false} ;
         H00817_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         H00817_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         H00817_A125actividades_categoriaestado = new int[1] ;
         H00817_n125actividades_categoriaestado = new bool[] {false} ;
         H00818_A360codigo_depto = new int[1] ;
         H00818_A361nombre_depto = new string[] {""} ;
         H00818_n361nombre_depto = new bool[] {false} ;
         hsh = "";
         AV10detalle_tarea = "";
         AV5window = new GXWindow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H00819_A360codigo_depto = new int[1] ;
         H00819_A361nombre_depto = new string[] {""} ;
         H00819_n361nombre_depto = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wptrabajosoportemodificar__datastore1(),
            new Object[][] {
                new Object[] {
               H00812_A360codigo_depto, H00812_A361nombre_depto, H00812_n361nombre_depto
               }
               , new Object[] {
               H00815_A105id_unidad_gis, H00815_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               H00816_A104categoria_tareaid_tipo_categoria, H00816_A106nombre_categoria, H00816_n106nombre_categoria
               }
               , new Object[] {
               H00817_A102id_actividad_categoria, H00817_A123nombre_actividad, H00817_n123nombre_actividad, H00817_A122actividades_categoriaid_tipo_categoria, H00817_n122actividades_categoriaid_tipo_categoria, H00817_A125actividades_categoriaestado, H00817_n125actividades_categoriaestado
               }
               , new Object[] {
               H00818_A360codigo_depto, H00818_A361nombre_depto, H00818_n361nombre_depto
               }
               , new Object[] {
               H00819_A360codigo_depto, H00819_A361nombre_depto, H00819_n361nombre_depto
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wptrabajosoportemodificar__default(),
            new Object[][] {
                new Object[] {
               H00813_A6ResponsableId, H00813_A30ResponsableNombre, H00813_A96ResponsableUsuario
               }
               , new Object[] {
               H00814_A6ResponsableId, H00814_A27ResponsableCargo, H00814_A96ResponsableUsuario
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavCorrelativo_Enabled = 0;
         dynavEmpleado.Enabled = 0;
         dynavCargo.Enabled = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short AV15EstadoTicketTicketId ;
      private short AV16EtapaDesarrolloId ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV34correlativo ;
      private int AV43detalle_infotecid_unidad1 ;
      private int AV44id_categoria1 ;
      private int AV45id_actividad1 ;
      private int wcpOAV34correlativo ;
      private int wcpOAV43detalle_infotecid_unidad1 ;
      private int wcpOAV44id_categoria1 ;
      private int wcpOAV45id_actividad1 ;
      private int AV7categoria_tareaid_tipo_categoria ;
      private int AV9detalle_infotecid_unidad ;
      private int edtavCorrelativo_Enabled ;
      private int edtavUsuarionombre_Forecolor ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuariofecha_Enabled ;
      private int edtavUsuarioemail_Enabled ;
      private int lblTextblock1_Forecolor ;
      private int edtavTicketresponsableobservacion_Forecolor ;
      private int edtavTicketresponsableobservacion_Enabled ;
      private int AV17id_actividad_categoria ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private int ZV9detalle_infotecid_unidad ;
      private int ZV17id_actividad_categoria ;
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
      private string divTable22_Internalname ;
      private string edtavCorrelativo_Internalname ;
      private string edtavCorrelativo_Jsonclick ;
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
      private string divTable29_Internalname ;
      private string cmbavPrioridad_Internalname ;
      private string cmbavPrioridad_Jsonclick ;
      private string divTable19_Internalname ;
      private string divTable17_Internalname ;
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
      private DateTime AV39fecha_registro1 ;
      private DateTime wcpOAV39fecha_registro1 ;
      private DateTime AV28UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV36nombre_emp1 ;
      private string AV37cargo_emp1 ;
      private string AV38nombre_usuario1 ;
      private string AV40depto_usuario1 ;
      private string AV41correo_usuario1 ;
      private string AV42observaciones1 ;
      private string AV46prioridad1 ;
      private string AV35fecha_solicitud ;
      private string wcpOAV36nombre_emp1 ;
      private string wcpOAV37cargo_emp1 ;
      private string wcpOAV38nombre_usuario1 ;
      private string wcpOAV40depto_usuario1 ;
      private string wcpOAV41correo_usuario1 ;
      private string wcpOAV42observaciones1 ;
      private string wcpOAV46prioridad1 ;
      private string wcpOAV35fecha_solicitud ;
      private string AV33UsuarioConectado ;
      private string AV13Empleado ;
      private string AV6Cargo ;
      private string AV30UsuarioNombre ;
      private string AV26UsuarioDepartamento ;
      private string AV27UsuarioEmail ;
      private string AV24TicketResponsableObservacion ;
      private string AV19prioridad ;
      private string AV10detalle_tarea ;
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
      private GXCombobox cmbavPrioridad ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H00812_A360codigo_depto ;
      private string[] H00812_A361nombre_depto ;
      private bool[] H00812_n361nombre_depto ;
      private IDataStoreProvider pr_default ;
      private short[] H00813_A6ResponsableId ;
      private string[] H00813_A30ResponsableNombre ;
      private string[] H00813_A96ResponsableUsuario ;
      private short[] H00814_A6ResponsableId ;
      private string[] H00814_A27ResponsableCargo ;
      private string[] H00814_A96ResponsableUsuario ;
      private int[] H00815_A105id_unidad_gis ;
      private int[] H00815_A104categoria_tareaid_tipo_categoria ;
      private int[] H00816_A104categoria_tareaid_tipo_categoria ;
      private string[] H00816_A106nombre_categoria ;
      private bool[] H00816_n106nombre_categoria ;
      private int[] H00817_A102id_actividad_categoria ;
      private string[] H00817_A123nombre_actividad ;
      private bool[] H00817_n123nombre_actividad ;
      private int[] H00817_A122actividades_categoriaid_tipo_categoria ;
      private bool[] H00817_n122actividades_categoriaid_tipo_categoria ;
      private int[] H00817_A125actividades_categoriaestado ;
      private bool[] H00817_n125actividades_categoriaestado ;
      private int[] H00818_A360codigo_depto ;
      private string[] H00818_A361nombre_depto ;
      private bool[] H00818_n361nombre_depto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H00819_A360codigo_depto ;
      private string[] H00819_A361nombre_depto ;
      private bool[] H00819_n361nombre_depto ;
      private GXWebForm Form ;
      private GXWindow AV5window ;
   }

   public class wptrabajosoportemodificar__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00812;
          prmH00812 = new Object[] {
          };
          Object[] prmH00815;
          prmH00815 = new Object[] {
          new ParDef("@AV7categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
          };
          Object[] prmH00816;
          prmH00816 = new Object[] {
          };
          Object[] prmH00817;
          prmH00817 = new Object[] {
          new ParDef("@AV7categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
          };
          Object[] prmH00818;
          prmH00818 = new Object[] {
          };
          Object[] prmH00819;
          prmH00819 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H00812", "SELECT [codigo_depto], [nombre_depto] FROM dbo.[deptos] ORDER BY [nombre_depto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00812,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00815", "SELECT [id_unidad_gis], [id_tipo_categoria] AS categoria_tareaid_tipo_categoria FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @AV7categoria_tareaid_tipo_categoria ORDER BY [id_unidad_gis] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00815,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00816", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] <> 2 or [id_tipo_categoria] <> 11 or [id_tipo_categoria] <> 14 or [id_tipo_categoria] <> 15 ORDER BY [nombre_categoria] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00816,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00817", "SELECT [id_actividad_categoria], [nombre_actividad], [id_tipo_categoria] AS actividades_categoriaid_tipo_categoria, [estado] AS actividades_categoriaestado FROM dbo.[actividades_categoria] WHERE ([id_tipo_categoria] = @AV7categoria_tareaid_tipo_categoria) AND ([estado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00817,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00818", "SELECT [codigo_depto], [nombre_depto] FROM dbo.[deptos] ORDER BY [nombre_depto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00818,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H00819", "SELECT [codigo_depto], [nombre_depto] FROM dbo.[deptos] ORDER BY [nombre_depto] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00819,0, GxCacheFrequency.OFF ,true,false )
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
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 5 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class wptrabajosoportemodificar__default : DataStoreHelperBase, IDataStoreHelper
 {
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
        Object[] prmH00813;
        prmH00813 = new Object[] {
        new ParDef("@AV33UsuarioConectado",GXType.NVarChar,100,60)
        };
        Object[] prmH00814;
        prmH00814 = new Object[] {
        new ParDef("@AV33UsuarioConectado",GXType.NVarChar,100,60)
        };
        def= new CursorDef[] {
            new CursorDef("H00813", "SELECT [ResponsableId], [ResponsableNombre], [ResponsableUsuario] FROM [Responsable] WHERE [ResponsableUsuario] = @AV33UsuarioConectado ORDER BY [ResponsableNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00813,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H00814", "SELECT [ResponsableId], [ResponsableCargo], [ResponsableUsuario] FROM [Responsable] WHERE [ResponsableUsuario] = @AV33UsuarioConectado ORDER BY [ResponsableCargo] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00814,0, GxCacheFrequency.OFF ,true,false )
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
     }
  }

}

}
