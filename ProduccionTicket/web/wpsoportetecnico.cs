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
   public class wpsoportetecnico : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpsoportetecnico( )
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

      public wpsoportetecnico( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_TicketId ,
                           long aP1_UsuarioId ,
                           long aP2_TicketResponsableId ,
                           short aP3_TicketTecnicoResponsableId ,
                           string aP4_UsuarioEmail ,
                           DateTime aP5_UsuarioFecha ,
                           string aP6_UsuarioNombre ,
                           string aP7_UsuarioDepartamento ,
                           string aP8_UsuarioRequerimiento ,
                           ref bool aP9_TicketResponsablePasaTaller2 )
      {
         this.AV30TicketId = aP0_TicketId;
         this.AV31UsuarioId = aP1_UsuarioId;
         this.AV10TicketResponsableId = aP2_TicketResponsableId;
         this.AV52TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV47UsuarioEmail = aP4_UsuarioEmail;
         this.AV51UsuarioFecha = aP5_UsuarioFecha;
         this.AV45UsuarioNombre = aP6_UsuarioNombre;
         this.AV46UsuarioDepartamento = aP7_UsuarioDepartamento;
         this.AV58UsuarioRequerimiento = aP8_UsuarioRequerimiento;
         this.AV59TicketResponsablePasaTaller2 = aP9_TicketResponsablePasaTaller2;
         executePrivate();
         aP9_TicketResponsablePasaTaller2=this.AV59TicketResponsablePasaTaller2;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavEstadoticketticketid = new GXCombobox();
         chkavTicketresponsableinstalacion = new GXCheckbox();
         chkavTicketresponsableconfiguracion = new GXCheckbox();
         chkavTicketresponsableinternetrouter = new GXCheckbox();
         chkavTicketresponsableformateo = new GXCheckbox();
         chkavTicketresponsablereparacion = new GXCheckbox();
         chkavTicketresponsablelimpieza = new GXCheckbox();
         chkavTicketresponsablepuntored = new GXCheckbox();
         chkavTicketresponsablecambioshardware = new GXCheckbox();
         chkavTicketresponsablecopiasrespaldo = new GXCheckbox();
         chkavTicketresponsablecerrado = new GXCheckbox();
         chkavTicketresponsablependiente = new GXCheckbox();
         chkavTicketresponsablepasataller = new GXCheckbox();
         dynavDetalle_infotecid_unidad = new GXCombobox();
         chkavTicketresponsablepasataller2 = new GXCheckbox();
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
            gxfirstwebparm = GetFirstPar( "TicketId");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vESTADOTICKETTICKETID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvESTADOTICKETTICKETID5J2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vDETALLE_INFOTECID_UNIDAD") == 0 )
            {
               AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvDETALLE_INFOTECID_UNIDAD5J2( AV43categoria_tareaid_tipo_categoria) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vID_ACTIVIDAD_CATEGORIA") == 0 )
            {
               AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvID_ACTIVIDAD_CATEGORIA5J2( AV43categoria_tareaid_tipo_categoria) ;
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
               gxfirstwebparm = GetFirstPar( "TicketId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "TicketId");
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
               AV30TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV30TicketId", StringUtil.LTrimStr( (decimal)(AV30TicketId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV31UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AssignAttri("", false, "AV31UsuarioId", StringUtil.LTrimStr( (decimal)(AV31UsuarioId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31UsuarioId), "ZZZZZZZZZ9"), context));
                  AV10TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
                  AssignAttri("", false, "AV10TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV10TicketResponsableId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TicketResponsableId), "ZZZZZZZZZ9"), context));
                  AV52TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
                  AssignAttri("", false, "AV52TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV52TicketTecnicoResponsableId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
                  AV47UsuarioEmail = GetPar( "UsuarioEmail");
                  AssignAttri("", false, "AV47UsuarioEmail", AV47UsuarioEmail);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47UsuarioEmail, "")), context));
                  AV51UsuarioFecha = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha"));
                  AssignAttri("", false, "AV51UsuarioFecha", context.localUtil.Format(AV51UsuarioFecha, "99/99/9999"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV51UsuarioFecha, context));
                  AV45UsuarioNombre = GetPar( "UsuarioNombre");
                  AssignAttri("", false, "AV45UsuarioNombre", AV45UsuarioNombre);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UsuarioNombre, "")), context));
                  AV46UsuarioDepartamento = GetPar( "UsuarioDepartamento");
                  AssignAttri("", false, "AV46UsuarioDepartamento", AV46UsuarioDepartamento);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIODEPARTAMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46UsuarioDepartamento, "")), context));
                  AV58UsuarioRequerimiento = GetPar( "UsuarioRequerimiento");
                  AssignAttri("", false, "AV58UsuarioRequerimiento", AV58UsuarioRequerimiento);
                  AV59TicketResponsablePasaTaller2 = StringUtil.StrToBool( GetPar( "TicketResponsablePasaTaller2"));
                  AssignAttri("", false, "AV59TicketResponsablePasaTaller2", AV59TicketResponsablePasaTaller2);
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
            return "wpsoportetecnico_Execute" ;
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
         PA5J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5J2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?20241884298", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpsoportetecnico.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV30TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV31UsuarioId,10,0)),UrlEncode(StringUtil.LTrimStr(AV10TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV52TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV47UsuarioEmail)),UrlEncode(DateTimeUtil.FormatDateParm(AV51UsuarioFecha)),UrlEncode(StringUtil.RTrim(AV45UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV46UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV58UsuarioRequerimiento)),UrlEncode(StringUtil.BoolToStr(AV59TicketResponsablePasaTaller2))}, new string[] {"TicketId","UsuarioId","TicketResponsableId","TicketTecnicoResponsableId","UsuarioEmail","UsuarioFecha","UsuarioNombre","UsuarioDepartamento","UsuarioRequerimiento","TicketResponsablePasaTaller2"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAANTIGUA", GetSecureSignedToken( "", context.localUtil.Format( AV65fechaAntigua, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAACTUAL", GetSecureSignedToken( "", context.localUtil.Format( AV66fechaActual, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47UsuarioEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV51UsuarioFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UsuarioNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIODEPARTAMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46UsuarioDepartamento, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vFECHAANTIGUA", context.localUtil.TToC( AV65fechaAntigua, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAANTIGUA", GetSecureSignedToken( "", context.localUtil.Format( AV65fechaAntigua, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "vFECHAACTUAL", context.localUtil.TToC( AV66fechaActual, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAACTUAL", GetSecureSignedToken( "", context.localUtil.Format( AV66fechaActual, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TicketTecnicoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOEMAIL", AV47UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47UsuarioEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA", context.localUtil.DToC( AV51UsuarioFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV51UsuarioFecha, context));
         GxWebStd.gx_hidden_field( context, "TAB1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tab1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TAB1_Class", StringUtil.RTrim( Tab1_Class));
         GxWebStd.gx_hidden_field( context, "TAB1_Historymanagement", StringUtil.BoolToStr( Tab1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "vESTADOTICKETTICKETID_Text", StringUtil.RTrim( dynavEstadoticketticketid.Description));
         GxWebStd.gx_hidden_field( context, "vCATEGORIA_TAREAID_TIPO_CATEGORIA_Text", StringUtil.RTrim( dynavCategoria_tareaid_tipo_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vID_ACTIVIDAD_CATEGORIA_Text", StringUtil.RTrim( dynavId_actividad_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vPRIORIDAD_Text", StringUtil.RTrim( cmbavPrioridad.Description));
         GxWebStd.gx_hidden_field( context, "vDETALLE_INFOTECID_UNIDAD_Text", StringUtil.RTrim( dynavDetalle_infotecid_unidad.Description));
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
            WE5J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5J2( ) ;
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
         return formatLink("wpsoportetecnico.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV30TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV31UsuarioId,10,0)),UrlEncode(StringUtil.LTrimStr(AV10TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV52TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV47UsuarioEmail)),UrlEncode(DateTimeUtil.FormatDateParm(AV51UsuarioFecha)),UrlEncode(StringUtil.RTrim(AV45UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV46UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV58UsuarioRequerimiento)),UrlEncode(StringUtil.BoolToStr(AV59TicketResponsablePasaTaller2))}, new string[] {"TicketId","UsuarioId","TicketResponsableId","TicketTecnicoResponsableId","UsuarioEmail","UsuarioFecha","UsuarioNombre","UsuarioDepartamento","UsuarioRequerimiento","TicketResponsablePasaTaller2"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPSoporteTecnico" ;
      }

      public override string GetPgmdesc( )
      {
         return "Trabajo Técnico Realizado" ;
      }

      protected void WB5J0( )
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
            /* User Defined Control */
            ucTab1.SetProperty("PageCount", Tab1_Pagecount);
            ucTab1.SetProperty("Class", Tab1_Class);
            ucTab1.SetProperty("HistoryManagement", Tab1_Historymanagement);
            ucTab1.Render(context, "tab", Tab1_Internalname, "TAB1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage1_title_Internalname, "Trabajo Realizado", "", "", lblTabpage1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage1") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage1table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable25_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable26_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Usuario:", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock32_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV45UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV45UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavUsuarionombre_Forecolor)+";", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable27_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Departamento:", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock33_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_html_textarea( context, edtavUsuariodepartamento_Internalname, AV46UsuarioDepartamento, "", "", 0, 1, edtavUsuariodepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable28_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Requerimiento:", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock34_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
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
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariorequerimiento_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavUsuariorequerimiento_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavUsuariorequerimiento_Internalname, AV58UsuarioRequerimiento, "", "", 0, 1, edtavUsuariorequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable17_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Inventario/Serie:", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock4_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsableinventarioserie_Internalname, "Inventario/Serie", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableinventarioserie_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableinventarioserie_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavTicketresponsableinventarioserie_Internalname, AV12TicketResponsableInventarioSerie, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", 0, 1, edtavTicketresponsableinventarioserie_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable19_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Estado Ticket:", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock31_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEstadoticketticketid_Internalname, "Estado Ticket Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEstadoticketticketid, dynavEstadoticketticketid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV53EstadoTicketTicketId), 4, 0)), 1, dynavEstadoticketticketid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEstadoticketticketid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavEstadoticketticketid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "", true, 1, "HLP_WPSoporteTecnico.htm");
            dynavEstadoticketticketid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV53EstadoTicketTicketId), 4, 0));
            AssignProp("", false, dynavEstadoticketticketid_Internalname, "Values", (string)(dynavEstadoticketticketid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable30_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTicketresponsablefechahoraatiende_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablefechahoraatiende_Internalname, "Inicio:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTicketresponsablefechahoraatiende_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablefechahoraatiende_Internalname, context.localUtil.TToC( AV60TicketResponsableFechaHoraAtiende, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV60TicketResponsableFechaHoraAtiende, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablefechahoraatiende_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTicketresponsablefechahoraatiende_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_bitmap( context, edtavTicketresponsablefechahoraatiende_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTicketresponsablefechahoraatiende_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPSoporteTecnico.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable31_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTicketresponsablefechahoraresuelve_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablefechahoraresuelve_Internalname, "Cierre:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavTicketresponsablefechahoraresuelve_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablefechahoraresuelve_Internalname, context.localUtil.TToC( AV62TicketResponsableFechaHoraResuelve, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( AV62TicketResponsableFechaHoraResuelve, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablefechahoraresuelve_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTicketresponsablefechahoraresuelve_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_bitmap( context, edtavTicketresponsablefechahoraresuelve_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavTicketresponsablefechahoraresuelve_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WPSoporteTecnico.htm");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "ACCIONES REALIZADAS", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock2_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock2_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable22_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Instalación", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock5_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsableinstalacion_Internalname, "Instalación", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableinstalacion_Internalname, StringUtil.BoolToStr( AV13TicketResponsableInstalacion), "", "Instalación", 1, chkavTicketresponsableinstalacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(96, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,96);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Configuración", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock6_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsableconfiguracion_Internalname, "Configuración", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableconfiguracion_Internalname, StringUtil.BoolToStr( AV14TicketResponsableConfiguracion), "", "Configuración", 1, chkavTicketresponsableconfiguracion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(104, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Internet/Router/Access Point", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock7_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsableinternetrouter_Internalname, "Internet/Router", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableinternetrouter_Internalname, StringUtil.BoolToStr( AV15TicketResponsableInternetRouter), "", "Internet/Router", 1, chkavTicketresponsableinternetrouter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(112, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,112);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable23_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Formateo", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock8_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsableformateo_Internalname, "Formateo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableformateo_Internalname, StringUtil.BoolToStr( AV16TicketResponsableFormateo), "", "Formateo", 1, chkavTicketresponsableformateo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Reparación", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock9_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablereparacion_Internalname, "Reparación", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablereparacion_Internalname, StringUtil.BoolToStr( AV29TicketResponsableReparacion), "", "Reparación", 1, chkavTicketresponsablereparacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(128, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,128);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Limpieza", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock10_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablelimpieza_Internalname, "Limpieza", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablelimpieza_Internalname, StringUtil.BoolToStr( AV28TicketResponsableLimpieza), "", "Limpieza", 1, chkavTicketresponsablelimpieza.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(136, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,136);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable24_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Punto Red", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock11_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablepuntored_Internalname, "Punto Red", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepuntored_Internalname, StringUtil.BoolToStr( AV27TicketResponsablePuntoRed), "", "Punto Red", 1, chkavTicketresponsablepuntored.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(144, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,144);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Cambios Hardware", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock12_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablecambioshardware_Internalname, "Cambios Hardware", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablecambioshardware_Internalname, StringUtil.BoolToStr( AV26TicketResponsableCambiosHardware), "", "Cambios Hardware", 1, chkavTicketresponsablecambioshardware.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(152, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,152);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Copias Respaldo", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock13_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablecopiasrespaldo_Internalname, "Copias Respaldo", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablecopiasrespaldo_Internalname, StringUtil.BoolToStr( AV25TicketResponsableCopiasRespaldo), "", "Copias Respaldo", 1, chkavTicketresponsablecopiasrespaldo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(160, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "ESTADO DE ATENCIÓN DEL REQUERIMIENTO", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock1_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock1_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Cerrado", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock14_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablecerrado_Internalname, "Cerrado", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablecerrado_Internalname, StringUtil.BoolToStr( AV8TicketResponsableCerrado), "", "Cerrado", 1, chkavTicketresponsablecerrado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(177, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,177);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Pendiente", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock15_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablependiente_Internalname, "Pendiente", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablependiente_Internalname, StringUtil.BoolToStr( AV7TicketResponsablePendiente), "", "Pendiente", 1, chkavTicketresponsablependiente.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(183, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,183);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Pasa Taller", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock16_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavTicketresponsablepasataller_Internalname, "Pasa Taller", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 189,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepasataller_Internalname, StringUtil.BoolToStr( AV6TicketResponsablePasaTaller), "", "Pasa Taller", 1, chkavTicketresponsablepasataller.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(189, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,189);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Observación", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock17_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsableobservacion_Internalname, "Observación", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavTicketresponsableobservacion_Internalname, AV5TicketResponsableObservacion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,198);\"", 0, 1, edtavTicketresponsableobservacion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPSoporteTecnico.htm");
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
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage2_title_Internalname, "Taller Soporte Técnico", "", "", lblTabpage2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage2") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage2table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "EN CASO DE LLEVAR AL TALLER DE SOPORTE TÉCNICO, CONFIRMAR LAS ESPECIFICACIONES DEL EQUIPO", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock3_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock3_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable8_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "RAM", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock18_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsableramtxt_Internalname, "RAM", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 218,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsableramtxt_Internalname, AV33TicketResponsableRamTxt, StringUtil.RTrim( context.localUtil.Format( AV33TicketResponsableRamTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,218);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsableramtxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsableramtxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsableramtxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Disco Duro", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock19_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablediscodurotxt_Internalname, "Disco Duro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablediscodurotxt_Internalname, AV34TicketResponsableDiscoDuroTxt, StringUtil.RTrim( context.localUtil.Format( AV34TicketResponsableDiscoDuroTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,226);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablediscodurotxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsablediscodurotxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsablediscodurotxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Procesador", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock20_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsableprocesadortxt_Internalname, "Procesador", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 234,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsableprocesadortxt_Internalname, AV35TicketResponsableProcesadorTxt, StringUtil.RTrim( context.localUtil.Format( AV35TicketResponsableProcesadorTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,234);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsableprocesadortxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsableprocesadortxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsableprocesadortxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Maletin", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock21_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablemaletintxt_Internalname, "Maletin", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 242,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablemaletintxt_Internalname, AV36TicketResponsableMaletinTxt, StringUtil.RTrim( context.localUtil.Format( AV36TicketResponsableMaletinTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,242);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablemaletintxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsablemaletintxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsablemaletintxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Toner Cinta", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock22_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsabletonercintatxt_Internalname, "Toner Cinta", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 250,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsabletonercintatxt_Internalname, AV37TicketResponsableTonerCintaTxt, StringUtil.RTrim( context.localUtil.Format( AV37TicketResponsableTonerCintaTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,250);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsabletonercintatxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsabletonercintatxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsabletonercintatxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Tarjeta de Video Extra", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock23_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsabletarjetavideoextratxt_Internalname, "Tarjeta de Video Extra", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsabletarjetavideoextratxt_Internalname, AV38TicketResponsableTarjetaVideoExtraTxt, StringUtil.RTrim( context.localUtil.Format( AV38TicketResponsableTarjetaVideoExtraTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,258);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsabletarjetavideoextratxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsabletarjetavideoextratxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsabletarjetavideoextratxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Cargador Laptop", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock24_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablecargadorlaptoptxt_Internalname, "Cargador Laptop", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablecargadorlaptoptxt_Internalname, AV39TicketResponsableCargadorLaptopTxt, StringUtil.RTrim( context.localUtil.Format( AV39TicketResponsableCargadorLaptopTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablecargadorlaptoptxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsablecargadorlaptoptxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsablecargadorlaptoptxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "CDs/DVDs", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock25_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablecdsdvdstxt_Internalname, "CDs/DVDs", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 274,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablecdsdvdstxt_Internalname, AV40TicketResponsableCDsDVDsTxt, StringUtil.RTrim( context.localUtil.Format( AV40TicketResponsableCDsDVDsTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,274);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablecdsdvdstxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsablecdsdvdstxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsablecdsdvdstxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Cable Especial", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock26_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsablecableespecialtxt_Internalname, "Cable Especial", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 282,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsablecableespecialtxt_Internalname, AV41TicketResponsableCableEspecialTxt, StringUtil.RTrim( context.localUtil.Format( AV41TicketResponsableCableEspecialTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,282);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsablecableespecialtxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsablecableespecialtxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsablecableespecialtxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Otros", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock27_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPSoporteTecnico.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketresponsableotrostallertxt_Internalname, "Otros", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 290,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTicketresponsableotrostallertxt_Internalname, AV42TicketResponsableOtrosTallerTxt, StringUtil.RTrim( context.localUtil.Format( AV42TicketResponsableOtrosTallerTxt, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,290);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketresponsableotrostallertxt_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketresponsableotrostallertxt_Forecolor)+";", "", "", "", 1, edtavTicketresponsableotrostallertxt_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPSoporteTecnico.htm");
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
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavDetalle_infotecid_unidad_Internalname, "id_unidad", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 297,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavDetalle_infotecid_unidad, dynavDetalle_infotecid_unidad_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0)), 1, dynavDetalle_infotecid_unidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavDetalle_infotecid_unidad.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,297);\"", "", true, 1, "HLP_WPSoporteTecnico.htm");
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", (string)(dynavDetalle_infotecid_unidad.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_element( context, chkavTicketresponsablepasataller2_Internalname, "Ticket Responsable Pasa Taller2", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepasataller2_Internalname, StringUtil.BoolToStr( AV59TicketResponsablePasaTaller2), "", "Ticket Responsable Pasa Taller2", 1, chkavTicketresponsablepasataller2.Enabled, "true", "", StyleString, ClassString, "", "", "");
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
            GxWebStd.gx_label_element( context, dynavCategoria_tareaid_tipo_categoria_Internalname, "Categoría de Tarea:", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 320,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoria_tareaid_tipo_categoria, dynavCategoria_tareaid_tipo_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0)), 1, dynavCategoria_tareaid_tipo_categoria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCategoria_tareaid_tipo_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCategoria_tareaid_tipo_categoria.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,320);\"", "", true, 1, "HLP_WPSoporteTecnico.htm");
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 328,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavId_actividad_categoria, dynavId_actividad_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0)), 1, dynavId_actividad_categoria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavId_actividad_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavId_actividad_categoria.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,328);\"", "", true, 1, "HLP_WPSoporteTecnico.htm");
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0));
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
            GxWebStd.gx_div_start( context, divTable20_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 339,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPrioridad, cmbavPrioridad_Internalname, StringUtil.RTrim( AV50prioridad), 1, cmbavPrioridad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavPrioridad.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( cmbavPrioridad.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,339);\"", "", true, 1, "HLP_WPSoporteTecnico.htm");
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV50prioridad);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 348,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPSoporteTecnico.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 353,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPSoporteTecnico.htm");
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

      protected void START5J2( )
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
            Form.Meta.addItem("description", "Trabajo Técnico Realizado", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5J0( ) ;
      }

      protected void WS5J2( )
      {
         START5J2( ) ;
         EVT5J2( ) ;
      }

      protected void EVT5J2( )
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
                              E115J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E125J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VESTADOTICKETTICKETID.ISVALID") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E135J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E145J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E155J2 ();
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

      protected void WE5J2( )
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

      protected void PA5J2( )
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
               GX_FocusControl = edtavTicketresponsableinventarioserie_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvDETALLE_INFOTECID_UNIDAD_html5J2( AV43categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html5J2( AV43categoria_tareaid_tipo_categoria) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA5J1( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data5J1( ) ;
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

      protected void GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html5J1( )
      {
         int gxdynajaxvalue;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data5J1( ) ;
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
         if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
         {
            AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
         }
      }

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data5J1( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005J2 */
         pr_datastore1.execute(0);
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005J2_A104categoria_tareaid_tipo_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005J2_A106nombre_categoria[0]);
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
      }

      protected void GXDLVvESTADOTICKETTICKETID5J2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvESTADOTICKETTICKETID_data5J2( ) ;
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

      protected void GXVvESTADOTICKETTICKETID_html5J2( )
      {
         short gxdynajaxvalue;
         GXDLVvESTADOTICKETTICKETID_data5J2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavEstadoticketticketid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavEstadoticketticketid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvESTADOTICKETTICKETID_data5J2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005J3 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005J3_A5EstadoTicketId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005J3_A24EstadoTicketNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD5J2( int AV43categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data5J2( AV43categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvDETALLE_INFOTECID_UNIDAD_html5J2( int AV43categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data5J2( AV43categoria_tareaid_tipo_categoria) ;
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

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD_data5J2( int AV43categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005J4 */
         pr_datastore1.execute(1, new Object[] {AV43categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005J4_A105id_unidad_gis[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005J4_A105id_unidad_gis[0]), 9, 0, ".", "")));
            pr_datastore1.readNext(1);
         }
         pr_datastore1.close(1);
      }

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA5J2( int AV43categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data5J2( AV43categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvID_ACTIVIDAD_CATEGORIA_html5J2( int AV43categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data5J2( AV43categoria_tareaid_tipo_categoria) ;
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
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV44id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV44id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV44id_actividad_categoria), 9, 0));
         }
      }

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA_data5J2( int AV43categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H005J5 */
         pr_datastore1.execute(2, new Object[] {AV43categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005J5_A102id_actividad_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005J5_A123nombre_actividad[0]);
            pr_datastore1.readNext(2);
         }
         pr_datastore1.close(2);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvESTADOTICKETTICKETID_html5J2( ) ;
            dynavCategoria_tareaid_tipo_categoria.Name = "vCATEGORIA_TAREAID_TIPO_CATEGORIA";
            dynavCategoria_tareaid_tipo_categoria.WebTags = "";
            dynavCategoria_tareaid_tipo_categoria.removeAllItems();
            /* Using cursor H005J6 */
            pr_datastore1.execute(3);
            while ( (pr_datastore1.getStatus(3) != 101) )
            {
               dynavCategoria_tareaid_tipo_categoria.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005J6_A104categoria_tareaid_tipo_categoria[0]), 9, 0)), H005J6_A106nombre_categoria[0], 0);
               pr_datastore1.readNext(3);
            }
            pr_datastore1.close(3);
            if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
            {
               AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0))), "."));
               AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
            }
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEstadoticketticketid.ItemCount > 0 )
         {
            AV53EstadoTicketTicketId = (short)(NumberUtil.Val( dynavEstadoticketticketid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV53EstadoTicketTicketId), 4, 0))), "."));
            AssignAttri("", false, "AV53EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(AV53EstadoTicketTicketId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEstadoticketticketid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV53EstadoTicketTicketId), 4, 0));
            AssignProp("", false, dynavEstadoticketticketid_Internalname, "Values", dynavEstadoticketticketid.ToJavascriptSource(), true);
         }
         AV13TicketResponsableInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV13TicketResponsableInstalacion));
         AssignAttri("", false, "AV13TicketResponsableInstalacion", AV13TicketResponsableInstalacion);
         AV14TicketResponsableConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV14TicketResponsableConfiguracion));
         AssignAttri("", false, "AV14TicketResponsableConfiguracion", AV14TicketResponsableConfiguracion);
         AV15TicketResponsableInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( AV15TicketResponsableInternetRouter));
         AssignAttri("", false, "AV15TicketResponsableInternetRouter", AV15TicketResponsableInternetRouter);
         AV16TicketResponsableFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( AV16TicketResponsableFormateo));
         AssignAttri("", false, "AV16TicketResponsableFormateo", AV16TicketResponsableFormateo);
         AV29TicketResponsableReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV29TicketResponsableReparacion));
         AssignAttri("", false, "AV29TicketResponsableReparacion", AV29TicketResponsableReparacion);
         AV28TicketResponsableLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( AV28TicketResponsableLimpieza));
         AssignAttri("", false, "AV28TicketResponsableLimpieza", AV28TicketResponsableLimpieza);
         AV27TicketResponsablePuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( AV27TicketResponsablePuntoRed));
         AssignAttri("", false, "AV27TicketResponsablePuntoRed", AV27TicketResponsablePuntoRed);
         AV26TicketResponsableCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( AV26TicketResponsableCambiosHardware));
         AssignAttri("", false, "AV26TicketResponsableCambiosHardware", AV26TicketResponsableCambiosHardware);
         AV25TicketResponsableCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( AV25TicketResponsableCopiasRespaldo));
         AssignAttri("", false, "AV25TicketResponsableCopiasRespaldo", AV25TicketResponsableCopiasRespaldo);
         AV8TicketResponsableCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( AV8TicketResponsableCerrado));
         AssignAttri("", false, "AV8TicketResponsableCerrado", AV8TicketResponsableCerrado);
         AV7TicketResponsablePendiente = StringUtil.StrToBool( StringUtil.BoolToStr( AV7TicketResponsablePendiente));
         AssignAttri("", false, "AV7TicketResponsablePendiente", AV7TicketResponsablePendiente);
         AV6TicketResponsablePasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( AV6TicketResponsablePasaTaller));
         AssignAttri("", false, "AV6TicketResponsablePasaTaller", AV6TicketResponsablePasaTaller);
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV48detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0))), "."));
            AssignAttri("", false, "AV48detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV48detalle_infotecid_unidad), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         }
         AV59TicketResponsablePasaTaller2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV59TicketResponsablePasaTaller2));
         AssignAttri("", false, "AV59TicketResponsablePasaTaller2", AV59TicketResponsablePasaTaller2);
         if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
         {
            AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
            AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Values", dynavCategoria_tareaid_tipo_categoria.ToJavascriptSource(), true);
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV44id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV44id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV44id_actividad_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0));
            AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
         }
         if ( cmbavPrioridad.ItemCount > 0 )
         {
            AV50prioridad = cmbavPrioridad.getValidValue(AV50prioridad);
            AssignAttri("", false, "AV50prioridad", AV50prioridad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV50prioridad);
            AssignProp("", false, cmbavPrioridad_Internalname, "Values", cmbavPrioridad.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
         chkavTicketresponsablepasataller2.Enabled = 0;
         AssignProp("", false, chkavTicketresponsablepasataller2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablepasataller2.Enabled), 5, 0), true);
      }

      protected void RF5J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E155J2 ();
            WB5J0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5J2( )
      {
         GxWebStd.gx_hidden_field( context, "vFECHAANTIGUA", context.localUtil.TToC( AV65fechaAntigua, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAANTIGUA", GetSecureSignedToken( "", context.localUtil.Format( AV65fechaAntigua, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "vFECHAACTUAL", context.localUtil.TToC( AV66fechaActual, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAACTUAL", GetSecureSignedToken( "", context.localUtil.Format( AV66fechaActual, "99/99/99 99:99"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TicketTecnicoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOEMAIL", AV47UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47UsuarioEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA", context.localUtil.DToC( AV51UsuarioFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV51UsuarioFecha, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
         chkavTicketresponsablepasataller2.Enabled = 0;
         AssignProp("", false, chkavTicketresponsablepasataller2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablepasataller2.Enabled), 5, 0), true);
         GXVvESTADOTICKETTICKETID_html5J2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E145J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Tab1_Pagecount = (int)(context.localUtil.CToN( cgiGet( "TAB1_Pagecount"), ".", ","));
            Tab1_Class = cgiGet( "TAB1_Class");
            Tab1_Historymanagement = StringUtil.StrToBool( cgiGet( "TAB1_Historymanagement"));
            /* Read variables values. */
            AV12TicketResponsableInventarioSerie = cgiGet( edtavTicketresponsableinventarioserie_Internalname);
            AssignAttri("", false, "AV12TicketResponsableInventarioSerie", AV12TicketResponsableInventarioSerie);
            dynavEstadoticketticketid.CurrentValue = cgiGet( dynavEstadoticketticketid_Internalname);
            AV53EstadoTicketTicketId = (short)(NumberUtil.Val( cgiGet( dynavEstadoticketticketid_Internalname), "."));
            AssignAttri("", false, "AV53EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(AV53EstadoTicketTicketId), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtavTicketresponsablefechahoraatiende_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Ticket Responsable Fecha Hora Atiende"}), 1, "vTICKETRESPONSABLEFECHAHORAATIENDE");
               GX_FocusControl = edtavTicketresponsablefechahoraatiende_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV60TicketResponsableFechaHoraAtiende = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV60TicketResponsableFechaHoraAtiende", context.localUtil.TToC( AV60TicketResponsableFechaHoraAtiende, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               AV60TicketResponsableFechaHoraAtiende = context.localUtil.CToT( cgiGet( edtavTicketresponsablefechahoraatiende_Internalname));
               AssignAttri("", false, "AV60TicketResponsableFechaHoraAtiende", context.localUtil.TToC( AV60TicketResponsableFechaHoraAtiende, 10, 8, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtavTicketresponsablefechahoraresuelve_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Ticket Responsable Fecha Hora Resuelve"}), 1, "vTICKETRESPONSABLEFECHAHORARESUELVE");
               GX_FocusControl = edtavTicketresponsablefechahoraresuelve_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV62TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "AV62TicketResponsableFechaHoraResuelve", context.localUtil.TToC( AV62TicketResponsableFechaHoraResuelve, 10, 8, 0, 3, "/", ":", " "));
            }
            else
            {
               AV62TicketResponsableFechaHoraResuelve = context.localUtil.CToT( cgiGet( edtavTicketresponsablefechahoraresuelve_Internalname));
               AssignAttri("", false, "AV62TicketResponsableFechaHoraResuelve", context.localUtil.TToC( AV62TicketResponsableFechaHoraResuelve, 10, 8, 0, 3, "/", ":", " "));
            }
            AV13TicketResponsableInstalacion = StringUtil.StrToBool( cgiGet( chkavTicketresponsableinstalacion_Internalname));
            AssignAttri("", false, "AV13TicketResponsableInstalacion", AV13TicketResponsableInstalacion);
            AV14TicketResponsableConfiguracion = StringUtil.StrToBool( cgiGet( chkavTicketresponsableconfiguracion_Internalname));
            AssignAttri("", false, "AV14TicketResponsableConfiguracion", AV14TicketResponsableConfiguracion);
            AV15TicketResponsableInternetRouter = StringUtil.StrToBool( cgiGet( chkavTicketresponsableinternetrouter_Internalname));
            AssignAttri("", false, "AV15TicketResponsableInternetRouter", AV15TicketResponsableInternetRouter);
            AV16TicketResponsableFormateo = StringUtil.StrToBool( cgiGet( chkavTicketresponsableformateo_Internalname));
            AssignAttri("", false, "AV16TicketResponsableFormateo", AV16TicketResponsableFormateo);
            AV29TicketResponsableReparacion = StringUtil.StrToBool( cgiGet( chkavTicketresponsablereparacion_Internalname));
            AssignAttri("", false, "AV29TicketResponsableReparacion", AV29TicketResponsableReparacion);
            AV28TicketResponsableLimpieza = StringUtil.StrToBool( cgiGet( chkavTicketresponsablelimpieza_Internalname));
            AssignAttri("", false, "AV28TicketResponsableLimpieza", AV28TicketResponsableLimpieza);
            AV27TicketResponsablePuntoRed = StringUtil.StrToBool( cgiGet( chkavTicketresponsablepuntored_Internalname));
            AssignAttri("", false, "AV27TicketResponsablePuntoRed", AV27TicketResponsablePuntoRed);
            AV26TicketResponsableCambiosHardware = StringUtil.StrToBool( cgiGet( chkavTicketresponsablecambioshardware_Internalname));
            AssignAttri("", false, "AV26TicketResponsableCambiosHardware", AV26TicketResponsableCambiosHardware);
            AV25TicketResponsableCopiasRespaldo = StringUtil.StrToBool( cgiGet( chkavTicketresponsablecopiasrespaldo_Internalname));
            AssignAttri("", false, "AV25TicketResponsableCopiasRespaldo", AV25TicketResponsableCopiasRespaldo);
            AV8TicketResponsableCerrado = StringUtil.StrToBool( cgiGet( chkavTicketresponsablecerrado_Internalname));
            AssignAttri("", false, "AV8TicketResponsableCerrado", AV8TicketResponsableCerrado);
            AV7TicketResponsablePendiente = StringUtil.StrToBool( cgiGet( chkavTicketresponsablependiente_Internalname));
            AssignAttri("", false, "AV7TicketResponsablePendiente", AV7TicketResponsablePendiente);
            AV6TicketResponsablePasaTaller = StringUtil.StrToBool( cgiGet( chkavTicketresponsablepasataller_Internalname));
            AssignAttri("", false, "AV6TicketResponsablePasaTaller", AV6TicketResponsablePasaTaller);
            AV5TicketResponsableObservacion = cgiGet( edtavTicketresponsableobservacion_Internalname);
            AssignAttri("", false, "AV5TicketResponsableObservacion", AV5TicketResponsableObservacion);
            AV33TicketResponsableRamTxt = cgiGet( edtavTicketresponsableramtxt_Internalname);
            AssignAttri("", false, "AV33TicketResponsableRamTxt", AV33TicketResponsableRamTxt);
            AV34TicketResponsableDiscoDuroTxt = cgiGet( edtavTicketresponsablediscodurotxt_Internalname);
            AssignAttri("", false, "AV34TicketResponsableDiscoDuroTxt", AV34TicketResponsableDiscoDuroTxt);
            AV35TicketResponsableProcesadorTxt = cgiGet( edtavTicketresponsableprocesadortxt_Internalname);
            AssignAttri("", false, "AV35TicketResponsableProcesadorTxt", AV35TicketResponsableProcesadorTxt);
            AV36TicketResponsableMaletinTxt = cgiGet( edtavTicketresponsablemaletintxt_Internalname);
            AssignAttri("", false, "AV36TicketResponsableMaletinTxt", AV36TicketResponsableMaletinTxt);
            AV37TicketResponsableTonerCintaTxt = cgiGet( edtavTicketresponsabletonercintatxt_Internalname);
            AssignAttri("", false, "AV37TicketResponsableTonerCintaTxt", AV37TicketResponsableTonerCintaTxt);
            AV38TicketResponsableTarjetaVideoExtraTxt = cgiGet( edtavTicketresponsabletarjetavideoextratxt_Internalname);
            AssignAttri("", false, "AV38TicketResponsableTarjetaVideoExtraTxt", AV38TicketResponsableTarjetaVideoExtraTxt);
            AV39TicketResponsableCargadorLaptopTxt = cgiGet( edtavTicketresponsablecargadorlaptoptxt_Internalname);
            AssignAttri("", false, "AV39TicketResponsableCargadorLaptopTxt", AV39TicketResponsableCargadorLaptopTxt);
            AV40TicketResponsableCDsDVDsTxt = cgiGet( edtavTicketresponsablecdsdvdstxt_Internalname);
            AssignAttri("", false, "AV40TicketResponsableCDsDVDsTxt", AV40TicketResponsableCDsDVDsTxt);
            AV41TicketResponsableCableEspecialTxt = cgiGet( edtavTicketresponsablecableespecialtxt_Internalname);
            AssignAttri("", false, "AV41TicketResponsableCableEspecialTxt", AV41TicketResponsableCableEspecialTxt);
            AV42TicketResponsableOtrosTallerTxt = cgiGet( edtavTicketresponsableotrostallertxt_Internalname);
            AssignAttri("", false, "AV42TicketResponsableOtrosTallerTxt", AV42TicketResponsableOtrosTallerTxt);
            dynavDetalle_infotecid_unidad.CurrentValue = cgiGet( dynavDetalle_infotecid_unidad_Internalname);
            AV48detalle_infotecid_unidad = (int)(NumberUtil.Val( cgiGet( dynavDetalle_infotecid_unidad_Internalname), "."));
            AssignAttri("", false, "AV48detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV48detalle_infotecid_unidad), 9, 0));
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname);
            AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname), "."));
            AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
            dynavId_actividad_categoria.CurrentValue = cgiGet( dynavId_actividad_categoria_Internalname);
            AV44id_actividad_categoria = (int)(NumberUtil.Val( cgiGet( dynavId_actividad_categoria_Internalname), "."));
            AssignAttri("", false, "AV44id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV44id_actividad_categoria), 9, 0));
            cmbavPrioridad.CurrentValue = cgiGet( cmbavPrioridad_Internalname);
            AV50prioridad = cgiGet( cmbavPrioridad_Internalname);
            AssignAttri("", false, "AV50prioridad", AV50prioridad);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvESTADOTICKETTICKETID_html5J2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E115J2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         if ( ! AV59TicketResponsablePasaTaller2 )
         {
            if ( StringUtil.StrCmp(dynavEstadoticketticketid.Description, "(Ninguno)") == 0 )
            {
               context.PopUp(formatLink("webpanelmsg.aspx") , new Object[] {});
            }
            else
            {
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
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV5TicketResponsableObservacion)) )
                        {
                           context.PopUp(formatLink("webpanelmsgobservacion.aspx") , new Object[] {});
                        }
                        else
                        {
                           if ( AV60TicketResponsableFechaHoraAtiende < AV65fechaAntigua )
                           {
                              context.PopUp(formatLink("webpanelmsgfechaerronea.aspx") , new Object[] {});
                           }
                           else
                           {
                              if ( AV62TicketResponsableFechaHoraResuelve < AV65fechaAntigua )
                              {
                                 context.PopUp(formatLink("webpanelmsgfechaerronea.aspx") , new Object[] {});
                              }
                              else
                              {
                                 if ( AV60TicketResponsableFechaHoraAtiende > AV66fechaActual )
                                 {
                                    context.PopUp(formatLink("webpanelmsgfechamayoractual.aspx") , new Object[] {});
                                 }
                                 else
                                 {
                                    if ( AV62TicketResponsableFechaHoraResuelve > AV66fechaActual )
                                    {
                                       context.PopUp(formatLink("webpanelmsgfechamayoractual.aspx") , new Object[] {});
                                    }
                                    else
                                    {
                                       if ( AV60TicketResponsableFechaHoraAtiende > AV62TicketResponsableFechaHoraResuelve )
                                       {
                                          context.PopUp(formatLink("webpanelmsgfechaatencion.aspx") , new Object[] {});
                                       }
                                       else
                                       {
                                          AV49detalle_tarea = dynavCategoria_tareaid_tipo_categoria.Description + "/-" + dynavId_actividad_categoria.Description;
                                          new pcrregistrartecnico(context ).execute(  AV30TicketId,  AV31UsuarioId,  AV10TicketResponsableId,  AV52TicketTecnicoResponsableId,  AV12TicketResponsableInventarioSerie,  AV13TicketResponsableInstalacion,  AV14TicketResponsableConfiguracion,  AV15TicketResponsableInternetRouter,  AV16TicketResponsableFormateo,  AV29TicketResponsableReparacion,  AV28TicketResponsableLimpieza,  AV27TicketResponsablePuntoRed,  AV26TicketResponsableCambiosHardware,  AV25TicketResponsableCopiasRespaldo,  AV33TicketResponsableRamTxt,  AV34TicketResponsableDiscoDuroTxt,  AV35TicketResponsableProcesadorTxt,  AV36TicketResponsableMaletinTxt,  AV37TicketResponsableTonerCintaTxt,  AV38TicketResponsableTarjetaVideoExtraTxt,  AV39TicketResponsableCargadorLaptopTxt,  AV40TicketResponsableCDsDVDsTxt,  AV41TicketResponsableCableEspecialTxt,  AV42TicketResponsableOtrosTallerTxt,  AV8TicketResponsableCerrado,  AV7TicketResponsablePendiente,  AV6TicketResponsablePasaTaller,  AV5TicketResponsableObservacion,  AV43categoria_tareaid_tipo_categoria,  AV44id_actividad_categoria,  AV45UsuarioNombre,  AV46UsuarioDepartamento,  AV47UsuarioEmail,  (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.Description, ".")),  AV49detalle_tarea,  cmbavPrioridad.Description,  AV51UsuarioFecha,  AV53EstadoTicketTicketId,  AV60TicketResponsableFechaHoraAtiende,  AV62TicketResponsableFechaHoraResuelve) ;
                                          context.setWebReturnParms(new Object[] {(bool)AV59TicketResponsablePasaTaller2});
                                          context.setWebReturnParmsMetadata(new Object[] {"AV59TicketResponsablePasaTaller2"});
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
                     }
                  }
               }
            }
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV33TicketResponsableRamTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV34TicketResponsableDiscoDuroTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV35TicketResponsableProcesadorTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV36TicketResponsableMaletinTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV37TicketResponsableTonerCintaTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV38TicketResponsableTarjetaVideoExtraTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV39TicketResponsableCargadorLaptopTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV40TicketResponsableCDsDVDsTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV41TicketResponsableCableEspecialTxt)) && String.IsNullOrEmpty(StringUtil.RTrim( AV42TicketResponsableOtrosTallerTxt)) )
            {
               context.PopUp(formatLink("webpanelmsgtaller.aspx") , new Object[] {});
            }
            else
            {
               if ( StringUtil.StrCmp(dynavEstadoticketticketid.Description, "(Ninguno)") == 0 )
               {
                  context.PopUp(formatLink("webpanelmsg.aspx") , new Object[] {});
               }
               else
               {
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
                           if ( AV60TicketResponsableFechaHoraAtiende < AV65fechaAntigua )
                           {
                              context.PopUp(formatLink("webpanelmsgfechaerronea.aspx") , new Object[] {});
                           }
                           else
                           {
                              if ( AV62TicketResponsableFechaHoraResuelve < AV65fechaAntigua )
                              {
                                 context.PopUp(formatLink("webpanelmsgfechaerronea.aspx") , new Object[] {});
                              }
                              else
                              {
                                 if ( AV60TicketResponsableFechaHoraAtiende > AV66fechaActual )
                                 {
                                    context.PopUp(formatLink("webpanelmsgfechamayoractual.aspx") , new Object[] {});
                                 }
                                 else
                                 {
                                    if ( AV62TicketResponsableFechaHoraResuelve > AV66fechaActual )
                                    {
                                       context.PopUp(formatLink("webpanelmsgfechamayoractual.aspx") , new Object[] {});
                                    }
                                    else
                                    {
                                       if ( AV60TicketResponsableFechaHoraAtiende > AV62TicketResponsableFechaHoraResuelve )
                                       {
                                          context.PopUp(formatLink("webpanelmsgfechaatencion.aspx") , new Object[] {});
                                       }
                                       else
                                       {
                                          AV49detalle_tarea = dynavCategoria_tareaid_tipo_categoria.Description + "/-" + dynavId_actividad_categoria.Description;
                                          new pcrregistrartecnico(context ).execute(  AV30TicketId,  AV31UsuarioId,  AV10TicketResponsableId,  AV52TicketTecnicoResponsableId,  AV12TicketResponsableInventarioSerie,  AV13TicketResponsableInstalacion,  AV14TicketResponsableConfiguracion,  AV15TicketResponsableInternetRouter,  AV16TicketResponsableFormateo,  AV29TicketResponsableReparacion,  AV28TicketResponsableLimpieza,  AV27TicketResponsablePuntoRed,  AV26TicketResponsableCambiosHardware,  AV25TicketResponsableCopiasRespaldo,  AV33TicketResponsableRamTxt,  AV34TicketResponsableDiscoDuroTxt,  AV35TicketResponsableProcesadorTxt,  AV36TicketResponsableMaletinTxt,  AV37TicketResponsableTonerCintaTxt,  AV38TicketResponsableTarjetaVideoExtraTxt,  AV39TicketResponsableCargadorLaptopTxt,  AV40TicketResponsableCDsDVDsTxt,  AV41TicketResponsableCableEspecialTxt,  AV42TicketResponsableOtrosTallerTxt,  AV8TicketResponsableCerrado,  AV7TicketResponsablePendiente,  AV6TicketResponsablePasaTaller,  AV5TicketResponsableObservacion,  AV43categoria_tareaid_tipo_categoria,  AV44id_actividad_categoria,  AV45UsuarioNombre,  AV46UsuarioDepartamento,  AV47UsuarioEmail,  (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.Description, ".")),  AV49detalle_tarea,  cmbavPrioridad.Description,  AV51UsuarioFecha,  AV53EstadoTicketTicketId,  AV60TicketResponsableFechaHoraAtiende,  AV62TicketResponsableFechaHoraResuelve) ;
                                          context.setWebReturnParms(new Object[] {(bool)AV59TicketResponsablePasaTaller2});
                                          context.setWebReturnParmsMetadata(new Object[] {"AV59TicketResponsablePasaTaller2"});
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
                     }
                  }
               }
            }
         }
      }

      protected void E125J2( )
      {
         /* 'Cancelar' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(bool)AV59TicketResponsablePasaTaller2});
         context.setWebReturnParmsMetadata(new Object[] {"AV59TicketResponsablePasaTaller2"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E135J2( )
      {
         /* Estadoticketticketid_Isvalid Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(dynavEstadoticketticketid.Description, "Pendiente") == 0 )
         {
            chkavTicketresponsablecerrado.Enabled = 0;
            AssignProp("", false, chkavTicketresponsablecerrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablecerrado.Enabled), 5, 0), true);
            AV8TicketResponsableCerrado = false;
            AssignAttri("", false, "AV8TicketResponsableCerrado", AV8TicketResponsableCerrado);
            chkavTicketresponsablepasataller.Enabled = 1;
            AssignProp("", false, chkavTicketresponsablepasataller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablepasataller.Enabled), 5, 0), true);
            chkavTicketresponsablependiente.Enabled = 1;
            AssignProp("", false, chkavTicketresponsablependiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablependiente.Enabled), 5, 0), true);
         }
         else
         {
            chkavTicketresponsablecerrado.Enabled = 1;
            AssignProp("", false, chkavTicketresponsablecerrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablecerrado.Enabled), 5, 0), true);
            chkavTicketresponsablepasataller.Enabled = 0;
            AssignProp("", false, chkavTicketresponsablepasataller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablepasataller.Enabled), 5, 0), true);
            AV6TicketResponsablePasaTaller = false;
            AssignAttri("", false, "AV6TicketResponsablePasaTaller", AV6TicketResponsablePasaTaller);
            chkavTicketresponsablependiente.Enabled = 0;
            AssignProp("", false, chkavTicketresponsablependiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavTicketresponsablependiente.Enabled), 5, 0), true);
            AV7TicketResponsablePendiente = false;
            AssignAttri("", false, "AV7TicketResponsablePendiente", AV7TicketResponsablePendiente);
         }
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E145J2 ();
         if (returnInSub) return;
      }

      protected void E145J2( )
      {
         /* Start Routine */
         returnInSub = false;
         lblTextblock3_Fontbold = 1;
         AssignProp("", false, lblTextblock3_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock3_Fontbold), 1, 0), true);
         lblTextblock3_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock3_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock3_Forecolor), 9, 0), true);
         lblTextblock2_Fontbold = 1;
         AssignProp("", false, lblTextblock2_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock2_Fontbold), 1, 0), true);
         lblTextblock2_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock2_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock2_Forecolor), 9, 0), true);
         lblTextblock1_Fontbold = 1;
         AssignProp("", false, lblTextblock1_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock1_Fontbold), 1, 0), true);
         lblTextblock1_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock1_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock1_Forecolor), 9, 0), true);
         lblTextblock32_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock32_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock32_Forecolor), 9, 0), true);
         lblTextblock33_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock33_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock33_Forecolor), 9, 0), true);
         lblTextblock34_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock34_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock34_Forecolor), 9, 0), true);
         lblTextblock4_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock4_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock4_Forecolor), 9, 0), true);
         lblTextblock31_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock31_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock31_Forecolor), 9, 0), true);
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
         lblTextblock23_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock23_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock23_Forecolor), 9, 0), true);
         lblTextblock24_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock24_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock24_Forecolor), 9, 0), true);
         lblTextblock25_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock25_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock25_Forecolor), 9, 0), true);
         lblTextblock26_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock26_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock26_Forecolor), 9, 0), true);
         lblTextblock27_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock27_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock27_Forecolor), 9, 0), true);
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
         dynavCategoria_tareaid_tipo_categoria.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavCategoria_tareaid_tipo_categoria.ForeColor), 9, 0), true);
         dynavId_actividad_categoria.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavId_actividad_categoria.ForeColor), 9, 0), true);
         cmbavPrioridad.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, cmbavPrioridad_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(cmbavPrioridad.ForeColor), 9, 0), true);
         edtavUsuarionombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuarionombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuarionombre_Forecolor), 9, 0), true);
         edtavUsuariodepartamento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariodepartamento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariodepartamento_Forecolor), 9, 0), true);
         edtavUsuariorequerimiento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariorequerimiento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariorequerimiento_Forecolor), 9, 0), true);
         edtavTicketresponsableinventarioserie_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsableinventarioserie_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsableinventarioserie_Forecolor), 9, 0), true);
         dynavEstadoticketticketid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavEstadoticketticketid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavEstadoticketticketid.ForeColor), 9, 0), true);
         edtavTicketresponsableramtxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsableramtxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsableramtxt_Forecolor), 9, 0), true);
         edtavTicketresponsabletarjetavideoextratxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsabletarjetavideoextratxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsabletarjetavideoextratxt_Forecolor), 9, 0), true);
         edtavTicketresponsablediscodurotxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsablediscodurotxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsablediscodurotxt_Forecolor), 9, 0), true);
         edtavTicketresponsablecargadorlaptoptxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsablecargadorlaptoptxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsablecargadorlaptoptxt_Forecolor), 9, 0), true);
         edtavTicketresponsableprocesadortxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsableprocesadortxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsableprocesadortxt_Forecolor), 9, 0), true);
         edtavTicketresponsablecdsdvdstxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsablecdsdvdstxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsablecdsdvdstxt_Forecolor), 9, 0), true);
         edtavTicketresponsablemaletintxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsablemaletintxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsablemaletintxt_Forecolor), 9, 0), true);
         edtavTicketresponsablecableespecialtxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsablecableespecialtxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsablecableespecialtxt_Forecolor), 9, 0), true);
         edtavTicketresponsabletonercintatxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsabletonercintatxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsabletonercintatxt_Forecolor), 9, 0), true);
         edtavTicketresponsableotrostallertxt_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsableotrostallertxt_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsableotrostallertxt_Forecolor), 9, 0), true);
         edtavTicketresponsableobservacion_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketresponsableobservacion_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketresponsableobservacion_Forecolor), 9, 0), true);
         AV60TicketResponsableFechaHoraAtiende = DateTimeUtil.Now( context);
         AssignAttri("", false, "AV60TicketResponsableFechaHoraAtiende", context.localUtil.TToC( AV60TicketResponsableFechaHoraAtiende, 10, 8, 0, 3, "/", ":", " "));
         AV62TicketResponsableFechaHoraResuelve = DateTimeUtil.Now( context);
         AssignAttri("", false, "AV62TicketResponsableFechaHoraResuelve", context.localUtil.TToC( AV62TicketResponsableFechaHoraResuelve, 10, 8, 0, 3, "/", ":", " "));
         AV65fechaAntigua = context.localUtil.YMDHMSMToT( 2022, 11, 8, 0, 1, 58, 0);
         AssignAttri("", false, "AV65fechaAntigua", context.localUtil.TToC( AV65fechaAntigua, 8, 5, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAANTIGUA", GetSecureSignedToken( "", context.localUtil.Format( AV65fechaAntigua, "99/99/99 99:99"), context));
         AV66fechaActual = DateTimeUtil.Now( context);
         AssignAttri("", false, "AV66fechaActual", context.localUtil.TToC( AV66fechaActual, 8, 5, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "gxhash_vFECHAACTUAL", GetSecureSignedToken( "", context.localUtil.Format( AV66fechaActual, "99/99/99 99:99"), context));
      }

      protected void nextLoad( )
      {
      }

      protected void E155J2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV30TicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV30TicketId", StringUtil.LTrimStr( (decimal)(AV30TicketId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketId), "ZZZZZZZZZ9"), context));
         AV31UsuarioId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV31UsuarioId", StringUtil.LTrimStr( (decimal)(AV31UsuarioId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV31UsuarioId), "ZZZZZZZZZ9"), context));
         AV10TicketResponsableId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV10TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV10TicketResponsableId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10TicketResponsableId), "ZZZZZZZZZ9"), context));
         AV52TicketTecnicoResponsableId = Convert.ToInt16(getParm(obj,3));
         AssignAttri("", false, "AV52TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV52TicketTecnicoResponsableId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         AV47UsuarioEmail = (string)getParm(obj,4);
         AssignAttri("", false, "AV47UsuarioEmail", AV47UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV47UsuarioEmail, "")), context));
         AV51UsuarioFecha = (DateTime)getParm(obj,5);
         AssignAttri("", false, "AV51UsuarioFecha", context.localUtil.Format(AV51UsuarioFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV51UsuarioFecha, context));
         AV45UsuarioNombre = (string)getParm(obj,6);
         AssignAttri("", false, "AV45UsuarioNombre", AV45UsuarioNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UsuarioNombre, "")), context));
         AV46UsuarioDepartamento = (string)getParm(obj,7);
         AssignAttri("", false, "AV46UsuarioDepartamento", AV46UsuarioDepartamento);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIODEPARTAMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV46UsuarioDepartamento, "")), context));
         AV58UsuarioRequerimiento = (string)getParm(obj,8);
         AssignAttri("", false, "AV58UsuarioRequerimiento", AV58UsuarioRequerimiento);
         AV59TicketResponsablePasaTaller2 = (bool)getParm(obj,9);
         AssignAttri("", false, "AV59TicketResponsablePasaTaller2", AV59TicketResponsablePasaTaller2);
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
         PA5J2( ) ;
         WS5J2( ) ;
         WE5J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188421732", true, true);
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
         context.AddJavascriptSource("wpsoportetecnico.js", "?2024188421732", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("Shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavEstadoticketticketid.Name = "vESTADOTICKETTICKETID";
         dynavEstadoticketticketid.WebTags = "";
         chkavTicketresponsableinstalacion.Name = "vTICKETRESPONSABLEINSTALACION";
         chkavTicketresponsableinstalacion.WebTags = "";
         chkavTicketresponsableinstalacion.Caption = "";
         AssignProp("", false, chkavTicketresponsableinstalacion_Internalname, "TitleCaption", chkavTicketresponsableinstalacion.Caption, true);
         chkavTicketresponsableinstalacion.CheckedValue = "false";
         AV13TicketResponsableInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV13TicketResponsableInstalacion));
         AssignAttri("", false, "AV13TicketResponsableInstalacion", AV13TicketResponsableInstalacion);
         chkavTicketresponsableconfiguracion.Name = "vTICKETRESPONSABLECONFIGURACION";
         chkavTicketresponsableconfiguracion.WebTags = "";
         chkavTicketresponsableconfiguracion.Caption = "";
         AssignProp("", false, chkavTicketresponsableconfiguracion_Internalname, "TitleCaption", chkavTicketresponsableconfiguracion.Caption, true);
         chkavTicketresponsableconfiguracion.CheckedValue = "false";
         AV14TicketResponsableConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( AV14TicketResponsableConfiguracion));
         AssignAttri("", false, "AV14TicketResponsableConfiguracion", AV14TicketResponsableConfiguracion);
         chkavTicketresponsableinternetrouter.Name = "vTICKETRESPONSABLEINTERNETROUTER";
         chkavTicketresponsableinternetrouter.WebTags = "";
         chkavTicketresponsableinternetrouter.Caption = "";
         AssignProp("", false, chkavTicketresponsableinternetrouter_Internalname, "TitleCaption", chkavTicketresponsableinternetrouter.Caption, true);
         chkavTicketresponsableinternetrouter.CheckedValue = "false";
         AV15TicketResponsableInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( AV15TicketResponsableInternetRouter));
         AssignAttri("", false, "AV15TicketResponsableInternetRouter", AV15TicketResponsableInternetRouter);
         chkavTicketresponsableformateo.Name = "vTICKETRESPONSABLEFORMATEO";
         chkavTicketresponsableformateo.WebTags = "";
         chkavTicketresponsableformateo.Caption = "";
         AssignProp("", false, chkavTicketresponsableformateo_Internalname, "TitleCaption", chkavTicketresponsableformateo.Caption, true);
         chkavTicketresponsableformateo.CheckedValue = "false";
         AV16TicketResponsableFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( AV16TicketResponsableFormateo));
         AssignAttri("", false, "AV16TicketResponsableFormateo", AV16TicketResponsableFormateo);
         chkavTicketresponsablereparacion.Name = "vTICKETRESPONSABLEREPARACION";
         chkavTicketresponsablereparacion.WebTags = "";
         chkavTicketresponsablereparacion.Caption = "";
         AssignProp("", false, chkavTicketresponsablereparacion_Internalname, "TitleCaption", chkavTicketresponsablereparacion.Caption, true);
         chkavTicketresponsablereparacion.CheckedValue = "false";
         AV29TicketResponsableReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( AV29TicketResponsableReparacion));
         AssignAttri("", false, "AV29TicketResponsableReparacion", AV29TicketResponsableReparacion);
         chkavTicketresponsablelimpieza.Name = "vTICKETRESPONSABLELIMPIEZA";
         chkavTicketresponsablelimpieza.WebTags = "";
         chkavTicketresponsablelimpieza.Caption = "";
         AssignProp("", false, chkavTicketresponsablelimpieza_Internalname, "TitleCaption", chkavTicketresponsablelimpieza.Caption, true);
         chkavTicketresponsablelimpieza.CheckedValue = "false";
         AV28TicketResponsableLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( AV28TicketResponsableLimpieza));
         AssignAttri("", false, "AV28TicketResponsableLimpieza", AV28TicketResponsableLimpieza);
         chkavTicketresponsablepuntored.Name = "vTICKETRESPONSABLEPUNTORED";
         chkavTicketresponsablepuntored.WebTags = "";
         chkavTicketresponsablepuntored.Caption = "";
         AssignProp("", false, chkavTicketresponsablepuntored_Internalname, "TitleCaption", chkavTicketresponsablepuntored.Caption, true);
         chkavTicketresponsablepuntored.CheckedValue = "false";
         AV27TicketResponsablePuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( AV27TicketResponsablePuntoRed));
         AssignAttri("", false, "AV27TicketResponsablePuntoRed", AV27TicketResponsablePuntoRed);
         chkavTicketresponsablecambioshardware.Name = "vTICKETRESPONSABLECAMBIOSHARDWARE";
         chkavTicketresponsablecambioshardware.WebTags = "";
         chkavTicketresponsablecambioshardware.Caption = "";
         AssignProp("", false, chkavTicketresponsablecambioshardware_Internalname, "TitleCaption", chkavTicketresponsablecambioshardware.Caption, true);
         chkavTicketresponsablecambioshardware.CheckedValue = "false";
         AV26TicketResponsableCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( AV26TicketResponsableCambiosHardware));
         AssignAttri("", false, "AV26TicketResponsableCambiosHardware", AV26TicketResponsableCambiosHardware);
         chkavTicketresponsablecopiasrespaldo.Name = "vTICKETRESPONSABLECOPIASRESPALDO";
         chkavTicketresponsablecopiasrespaldo.WebTags = "";
         chkavTicketresponsablecopiasrespaldo.Caption = "";
         AssignProp("", false, chkavTicketresponsablecopiasrespaldo_Internalname, "TitleCaption", chkavTicketresponsablecopiasrespaldo.Caption, true);
         chkavTicketresponsablecopiasrespaldo.CheckedValue = "false";
         AV25TicketResponsableCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( AV25TicketResponsableCopiasRespaldo));
         AssignAttri("", false, "AV25TicketResponsableCopiasRespaldo", AV25TicketResponsableCopiasRespaldo);
         chkavTicketresponsablecerrado.Name = "vTICKETRESPONSABLECERRADO";
         chkavTicketresponsablecerrado.WebTags = "";
         chkavTicketresponsablecerrado.Caption = "";
         AssignProp("", false, chkavTicketresponsablecerrado_Internalname, "TitleCaption", chkavTicketresponsablecerrado.Caption, true);
         chkavTicketresponsablecerrado.CheckedValue = "false";
         AV8TicketResponsableCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( AV8TicketResponsableCerrado));
         AssignAttri("", false, "AV8TicketResponsableCerrado", AV8TicketResponsableCerrado);
         chkavTicketresponsablependiente.Name = "vTICKETRESPONSABLEPENDIENTE";
         chkavTicketresponsablependiente.WebTags = "";
         chkavTicketresponsablependiente.Caption = "";
         AssignProp("", false, chkavTicketresponsablependiente_Internalname, "TitleCaption", chkavTicketresponsablependiente.Caption, true);
         chkavTicketresponsablependiente.CheckedValue = "false";
         AV7TicketResponsablePendiente = StringUtil.StrToBool( StringUtil.BoolToStr( AV7TicketResponsablePendiente));
         AssignAttri("", false, "AV7TicketResponsablePendiente", AV7TicketResponsablePendiente);
         chkavTicketresponsablepasataller.Name = "vTICKETRESPONSABLEPASATALLER";
         chkavTicketresponsablepasataller.WebTags = "";
         chkavTicketresponsablepasataller.Caption = "";
         AssignProp("", false, chkavTicketresponsablepasataller_Internalname, "TitleCaption", chkavTicketresponsablepasataller.Caption, true);
         chkavTicketresponsablepasataller.CheckedValue = "false";
         AV6TicketResponsablePasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( AV6TicketResponsablePasaTaller));
         AssignAttri("", false, "AV6TicketResponsablePasaTaller", AV6TicketResponsablePasaTaller);
         dynavDetalle_infotecid_unidad.Name = "vDETALLE_INFOTECID_UNIDAD";
         dynavDetalle_infotecid_unidad.WebTags = "";
         chkavTicketresponsablepasataller2.Name = "vTICKETRESPONSABLEPASATALLER2";
         chkavTicketresponsablepasataller2.WebTags = "";
         chkavTicketresponsablepasataller2.Caption = "";
         AssignProp("", false, chkavTicketresponsablepasataller2_Internalname, "TitleCaption", chkavTicketresponsablepasataller2.Caption, true);
         chkavTicketresponsablepasataller2.CheckedValue = "false";
         AV59TicketResponsablePasaTaller2 = StringUtil.StrToBool( StringUtil.BoolToStr( AV59TicketResponsablePasaTaller2));
         AssignAttri("", false, "AV59TicketResponsablePasaTaller2", AV59TicketResponsablePasaTaller2);
         dynavCategoria_tareaid_tipo_categoria.Name = "vCATEGORIA_TAREAID_TIPO_CATEGORIA";
         dynavCategoria_tareaid_tipo_categoria.WebTags = "";
         dynavCategoria_tareaid_tipo_categoria.removeAllItems();
         /* Using cursor H005J7 */
         pr_datastore1.execute(4);
         while ( (pr_datastore1.getStatus(4) != 101) )
         {
            dynavCategoria_tareaid_tipo_categoria.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(H005J7_A104categoria_tareaid_tipo_categoria[0]), 9, 0)), H005J7_A106nombre_categoria[0], 0);
            pr_datastore1.readNext(4);
         }
         pr_datastore1.close(4);
         if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
         {
            AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV43categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV43categoria_tareaid_tipo_categoria), 9, 0));
         }
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
            AV50prioridad = cmbavPrioridad.getValidValue(AV50prioridad);
            AssignAttri("", false, "AV50prioridad", AV50prioridad);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTabpage1_title_Internalname = "TABPAGE1_TITLE";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divTable26_Internalname = "TABLE26";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtavUsuariodepartamento_Internalname = "vUSUARIODEPARTAMENTO";
         divTable27_Internalname = "TABLE27";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtavUsuariorequerimiento_Internalname = "vUSUARIOREQUERIMIENTO";
         divTable28_Internalname = "TABLE28";
         divTable25_Internalname = "TABLE25";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtavTicketresponsableinventarioserie_Internalname = "vTICKETRESPONSABLEINVENTARIOSERIE";
         divTable17_Internalname = "TABLE17";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         dynavEstadoticketticketid_Internalname = "vESTADOTICKETTICKETID";
         divTable19_Internalname = "TABLE19";
         edtavTicketresponsablefechahoraatiende_Internalname = "vTICKETRESPONSABLEFECHAHORAATIENDE";
         divTable30_Internalname = "TABLE30";
         edtavTicketresponsablefechahoraresuelve_Internalname = "vTICKETRESPONSABLEFECHAHORARESUELVE";
         divTable31_Internalname = "TABLE31";
         divTable5_Internalname = "TABLE5";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         chkavTicketresponsableinstalacion_Internalname = "vTICKETRESPONSABLEINSTALACION";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         chkavTicketresponsableconfiguracion_Internalname = "vTICKETRESPONSABLECONFIGURACION";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         chkavTicketresponsableinternetrouter_Internalname = "vTICKETRESPONSABLEINTERNETROUTER";
         divTable22_Internalname = "TABLE22";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         chkavTicketresponsableformateo_Internalname = "vTICKETRESPONSABLEFORMATEO";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         chkavTicketresponsablereparacion_Internalname = "vTICKETRESPONSABLEREPARACION";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         chkavTicketresponsablelimpieza_Internalname = "vTICKETRESPONSABLELIMPIEZA";
         divTable23_Internalname = "TABLE23";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         chkavTicketresponsablepuntored_Internalname = "vTICKETRESPONSABLEPUNTORED";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         chkavTicketresponsablecambioshardware_Internalname = "vTICKETRESPONSABLECAMBIOSHARDWARE";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         chkavTicketresponsablecopiasrespaldo_Internalname = "vTICKETRESPONSABLECOPIASRESPALDO";
         divTable24_Internalname = "TABLE24";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         chkavTicketresponsablecerrado_Internalname = "vTICKETRESPONSABLECERRADO";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         chkavTicketresponsablependiente_Internalname = "vTICKETRESPONSABLEPENDIENTE";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         chkavTicketresponsablepasataller_Internalname = "vTICKETRESPONSABLEPASATALLER";
         divTable6_Internalname = "TABLE6";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtavTicketresponsableobservacion_Internalname = "vTICKETRESPONSABLEOBSERVACION";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
         divTable21_Internalname = "TABLE21";
         divTabpage1table_Internalname = "TABPAGE1TABLE";
         lblTabpage2_title_Internalname = "TABPAGE2_TITLE";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtavTicketresponsableramtxt_Internalname = "vTICKETRESPONSABLERAMTXT";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtavTicketresponsablediscodurotxt_Internalname = "vTICKETRESPONSABLEDISCODUROTXT";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtavTicketresponsableprocesadortxt_Internalname = "vTICKETRESPONSABLEPROCESADORTXT";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtavTicketresponsablemaletintxt_Internalname = "vTICKETRESPONSABLEMALETINTXT";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtavTicketresponsabletonercintatxt_Internalname = "vTICKETRESPONSABLETONERCINTATXT";
         divTable8_Internalname = "TABLE8";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtavTicketresponsabletarjetavideoextratxt_Internalname = "vTICKETRESPONSABLETARJETAVIDEOEXTRATXT";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtavTicketresponsablecargadorlaptoptxt_Internalname = "vTICKETRESPONSABLECARGADORLAPTOPTXT";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtavTicketresponsablecdsdvdstxt_Internalname = "vTICKETRESPONSABLECDSDVDSTXT";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtavTicketresponsablecableespecialtxt_Internalname = "vTICKETRESPONSABLECABLEESPECIALTXT";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtavTicketresponsableotrostallertxt_Internalname = "vTICKETRESPONSABLEOTROSTALLERTXT";
         divTable9_Internalname = "TABLE9";
         divTable4_Internalname = "TABLE4";
         dynavDetalle_infotecid_unidad_Internalname = "vDETALLE_INFOTECID_UNIDAD";
         chkavTicketresponsablepasataller2_Internalname = "vTICKETRESPONSABLEPASATALLER2";
         divTable1_Internalname = "TABLE1";
         divTabpage2table_Internalname = "TABPAGE2TABLE";
         Tab1_Internalname = "TAB1";
         dynavCategoria_tareaid_tipo_categoria_Internalname = "vCATEGORIA_TAREAID_TIPO_CATEGORIA";
         divTable16_Internalname = "TABLE16";
         dynavId_actividad_categoria_Internalname = "vID_ACTIVIDAD_CATEGORIA";
         divTable18_Internalname = "TABLE18";
         cmbavPrioridad_Internalname = "vPRIORIDAD";
         divTable29_Internalname = "TABLE29";
         divTable20_Internalname = "TABLE20";
         divTable15_Internalname = "TABLE15";
         divTable14_Internalname = "TABLE14";
         divTable13_Internalname = "TABLE13";
         bttGuardar_Internalname = "GUARDAR";
         divTable11_Internalname = "TABLE11";
         bttCancelar_Internalname = "CANCELAR";
         divTable12_Internalname = "TABLE12";
         divTable10_Internalname = "TABLE10";
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
         chkavTicketresponsablepasataller2.Caption = "Ticket Responsable Pasa Taller2";
         chkavTicketresponsablepasataller.Caption = "Pasa Taller";
         chkavTicketresponsablependiente.Caption = "Pendiente";
         chkavTicketresponsablecerrado.Caption = "Cerrado";
         chkavTicketresponsablecopiasrespaldo.Caption = "Copias Respaldo";
         chkavTicketresponsablecambioshardware.Caption = "Cambios Hardware";
         chkavTicketresponsablepuntored.Caption = "Punto Red";
         chkavTicketresponsablelimpieza.Caption = "Limpieza";
         chkavTicketresponsablereparacion.Caption = "Reparación";
         chkavTicketresponsableformateo.Caption = "Formateo";
         chkavTicketresponsableinternetrouter.Caption = "Internet/Router";
         chkavTicketresponsableconfiguracion.Caption = "Configuración";
         chkavTicketresponsableinstalacion.Caption = "Instalación";
         cmbavPrioridad_Jsonclick = "";
         cmbavPrioridad.Enabled = 1;
         cmbavPrioridad.ForeColor = (int)(0x000000);
         dynavId_actividad_categoria_Jsonclick = "";
         dynavId_actividad_categoria.Enabled = 1;
         dynavId_actividad_categoria.ForeColor = (int)(0x000000);
         dynavCategoria_tareaid_tipo_categoria_Jsonclick = "";
         dynavCategoria_tareaid_tipo_categoria.Enabled = 1;
         dynavCategoria_tareaid_tipo_categoria.ForeColor = (int)(0x000000);
         chkavTicketresponsablepasataller2.Enabled = 0;
         dynavDetalle_infotecid_unidad_Jsonclick = "";
         dynavDetalle_infotecid_unidad.Enabled = 1;
         edtavTicketresponsableotrostallertxt_Jsonclick = "";
         edtavTicketresponsableotrostallertxt_Forecolor = (int)(0x000000);
         edtavTicketresponsableotrostallertxt_Enabled = 1;
         lblTextblock27_Forecolor = (int)(0x000000);
         edtavTicketresponsablecableespecialtxt_Jsonclick = "";
         edtavTicketresponsablecableespecialtxt_Forecolor = (int)(0x000000);
         edtavTicketresponsablecableespecialtxt_Enabled = 1;
         lblTextblock26_Forecolor = (int)(0x000000);
         edtavTicketresponsablecdsdvdstxt_Jsonclick = "";
         edtavTicketresponsablecdsdvdstxt_Forecolor = (int)(0x000000);
         edtavTicketresponsablecdsdvdstxt_Enabled = 1;
         lblTextblock25_Forecolor = (int)(0x000000);
         edtavTicketresponsablecargadorlaptoptxt_Jsonclick = "";
         edtavTicketresponsablecargadorlaptoptxt_Forecolor = (int)(0x000000);
         edtavTicketresponsablecargadorlaptoptxt_Enabled = 1;
         lblTextblock24_Forecolor = (int)(0x000000);
         edtavTicketresponsabletarjetavideoextratxt_Jsonclick = "";
         edtavTicketresponsabletarjetavideoextratxt_Forecolor = (int)(0x000000);
         edtavTicketresponsabletarjetavideoextratxt_Enabled = 1;
         lblTextblock23_Forecolor = (int)(0x000000);
         edtavTicketresponsabletonercintatxt_Jsonclick = "";
         edtavTicketresponsabletonercintatxt_Forecolor = (int)(0x000000);
         edtavTicketresponsabletonercintatxt_Enabled = 1;
         lblTextblock22_Forecolor = (int)(0x000000);
         edtavTicketresponsablemaletintxt_Jsonclick = "";
         edtavTicketresponsablemaletintxt_Forecolor = (int)(0x000000);
         edtavTicketresponsablemaletintxt_Enabled = 1;
         lblTextblock21_Forecolor = (int)(0x000000);
         edtavTicketresponsableprocesadortxt_Jsonclick = "";
         edtavTicketresponsableprocesadortxt_Forecolor = (int)(0x000000);
         edtavTicketresponsableprocesadortxt_Enabled = 1;
         lblTextblock20_Forecolor = (int)(0x000000);
         edtavTicketresponsablediscodurotxt_Jsonclick = "";
         edtavTicketresponsablediscodurotxt_Forecolor = (int)(0x000000);
         edtavTicketresponsablediscodurotxt_Enabled = 1;
         lblTextblock19_Forecolor = (int)(0x000000);
         edtavTicketresponsableramtxt_Jsonclick = "";
         edtavTicketresponsableramtxt_Forecolor = (int)(0x000000);
         edtavTicketresponsableramtxt_Enabled = 1;
         lblTextblock18_Forecolor = (int)(0x000000);
         lblTextblock3_Forecolor = (int)(0x000000);
         lblTextblock3_Fontbold = 0;
         edtavTicketresponsableobservacion_Forecolor = (int)(0x000000);
         edtavTicketresponsableobservacion_Enabled = 1;
         lblTextblock17_Forecolor = (int)(0x000000);
         chkavTicketresponsablepasataller.Enabled = 1;
         lblTextblock16_Forecolor = (int)(0x000000);
         chkavTicketresponsablependiente.Enabled = 1;
         lblTextblock15_Forecolor = (int)(0x000000);
         chkavTicketresponsablecerrado.Enabled = 1;
         lblTextblock14_Forecolor = (int)(0x000000);
         lblTextblock1_Forecolor = (int)(0x000000);
         lblTextblock1_Fontbold = 0;
         chkavTicketresponsablecopiasrespaldo.Enabled = 1;
         lblTextblock13_Forecolor = (int)(0x000000);
         chkavTicketresponsablecambioshardware.Enabled = 1;
         lblTextblock12_Forecolor = (int)(0x000000);
         chkavTicketresponsablepuntored.Enabled = 1;
         lblTextblock11_Forecolor = (int)(0x000000);
         chkavTicketresponsablelimpieza.Enabled = 1;
         lblTextblock10_Forecolor = (int)(0x000000);
         chkavTicketresponsablereparacion.Enabled = 1;
         lblTextblock9_Forecolor = (int)(0x000000);
         chkavTicketresponsableformateo.Enabled = 1;
         lblTextblock8_Forecolor = (int)(0x000000);
         chkavTicketresponsableinternetrouter.Enabled = 1;
         lblTextblock7_Forecolor = (int)(0x000000);
         chkavTicketresponsableconfiguracion.Enabled = 1;
         lblTextblock6_Forecolor = (int)(0x000000);
         chkavTicketresponsableinstalacion.Enabled = 1;
         lblTextblock5_Forecolor = (int)(0x000000);
         lblTextblock2_Forecolor = (int)(0x000000);
         lblTextblock2_Fontbold = 0;
         edtavTicketresponsablefechahoraresuelve_Jsonclick = "";
         edtavTicketresponsablefechahoraresuelve_Enabled = 1;
         edtavTicketresponsablefechahoraatiende_Jsonclick = "";
         edtavTicketresponsablefechahoraatiende_Enabled = 1;
         dynavEstadoticketticketid_Jsonclick = "";
         dynavEstadoticketticketid.Enabled = 1;
         dynavEstadoticketticketid.ForeColor = (int)(0x000000);
         lblTextblock31_Forecolor = (int)(0x000000);
         edtavTicketresponsableinventarioserie_Forecolor = (int)(0x000000);
         edtavTicketresponsableinventarioserie_Enabled = 1;
         lblTextblock4_Forecolor = (int)(0x000000);
         edtavUsuariorequerimiento_Forecolor = (int)(0x000000);
         edtavUsuariorequerimiento_Enabled = 0;
         lblTextblock34_Forecolor = (int)(0x000000);
         edtavUsuariodepartamento_Forecolor = (int)(0x000000);
         edtavUsuariodepartamento_Enabled = 0;
         lblTextblock33_Forecolor = (int)(0x000000);
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Forecolor = (int)(0x000000);
         edtavUsuarionombre_Enabled = 0;
         lblTextblock32_Forecolor = (int)(0x000000);
         dynavDetalle_infotecid_unidad.Description = "";
         cmbavPrioridad.Description = "";
         dynavId_actividad_categoria.Description = "";
         dynavCategoria_tareaid_tipo_categoria.Description = "";
         dynavEstadoticketticketid.Description = "";
         Tab1_Historymanagement = Convert.ToBoolean( 0);
         Tab1_Class = "Tab";
         Tab1_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Trabajo Técnico Realizado";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Categoria_tareaid_tipo_categoria( )
      {
         AV53EstadoTicketTicketId = (short)(NumberUtil.Val( dynavEstadoticketticketid.CurrentValue, "."));
         AV43categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.CurrentValue, "."));
         AV48detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.CurrentValue, "."));
         AV44id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.CurrentValue, "."));
         GXVvDETALLE_INFOTECID_UNIDAD_html5J2( AV43categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html5J2( AV43categoria_tareaid_tipo_categoria) ;
         dynload_actions( ) ;
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV48detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0));
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV44id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV48detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48detalle_infotecid_unidad), 9, 0, ".", "")));
         dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV48detalle_infotecid_unidad), 9, 0));
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         AssignAttri("", false, "AV44id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV44id_actividad_categoria), 9, 0, ".", "")));
         dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV44id_actividad_categoria), 9, 0));
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV65fechaAntigua',fld:'vFECHAANTIGUA',pic:'99/99/99 99:99',hsh:true},{av:'AV66fechaActual',fld:'vFECHAACTUAL',pic:'99/99/99 99:99',hsh:true},{av:'AV30TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV31UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV10TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV52TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV47UsuarioEmail',fld:'vUSUARIOEMAIL',pic:'',hsh:true},{av:'AV51UsuarioFecha',fld:'vUSUARIOFECHA',pic:'',hsh:true},{av:'AV45UsuarioNombre',fld:'vUSUARIONOMBRE',pic:'',hsh:true},{av:'AV46UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:'',hsh:true},{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
         setEventMetadata("'GUARDAR'","{handler:'E115J2',iparms:[{av:'dynavId_actividad_categoria'},{av:'cmbavPrioridad'},{av:'AV5TicketResponsableObservacion',fld:'vTICKETRESPONSABLEOBSERVACION',pic:''},{av:'AV60TicketResponsableFechaHoraAtiende',fld:'vTICKETRESPONSABLEFECHAHORAATIENDE',pic:'99/99/9999 99:99:99'},{av:'AV65fechaAntigua',fld:'vFECHAANTIGUA',pic:'99/99/99 99:99',hsh:true},{av:'AV62TicketResponsableFechaHoraResuelve',fld:'vTICKETRESPONSABLEFECHAHORARESUELVE',pic:'99/99/9999 99:99:99'},{av:'AV66fechaActual',fld:'vFECHAACTUAL',pic:'99/99/99 99:99',hsh:true},{av:'AV30TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV31UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV10TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV52TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV12TicketResponsableInventarioSerie',fld:'vTICKETRESPONSABLEINVENTARIOSERIE',pic:''},{av:'AV33TicketResponsableRamTxt',fld:'vTICKETRESPONSABLERAMTXT',pic:''},{av:'AV34TicketResponsableDiscoDuroTxt',fld:'vTICKETRESPONSABLEDISCODUROTXT',pic:''},{av:'AV35TicketResponsableProcesadorTxt',fld:'vTICKETRESPONSABLEPROCESADORTXT',pic:''},{av:'AV36TicketResponsableMaletinTxt',fld:'vTICKETRESPONSABLEMALETINTXT',pic:''},{av:'AV37TicketResponsableTonerCintaTxt',fld:'vTICKETRESPONSABLETONERCINTATXT',pic:''},{av:'AV38TicketResponsableTarjetaVideoExtraTxt',fld:'vTICKETRESPONSABLETARJETAVIDEOEXTRATXT',pic:''},{av:'AV39TicketResponsableCargadorLaptopTxt',fld:'vTICKETRESPONSABLECARGADORLAPTOPTXT',pic:''},{av:'AV40TicketResponsableCDsDVDsTxt',fld:'vTICKETRESPONSABLECDSDVDSTXT',pic:''},{av:'AV41TicketResponsableCableEspecialTxt',fld:'vTICKETRESPONSABLECABLEESPECIALTXT',pic:''},{av:'AV42TicketResponsableOtrosTallerTxt',fld:'vTICKETRESPONSABLEOTROSTALLERTXT',pic:''},{av:'AV44id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV45UsuarioNombre',fld:'vUSUARIONOMBRE',pic:'',hsh:true},{av:'AV46UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:'',hsh:true},{av:'AV47UsuarioEmail',fld:'vUSUARIOEMAIL',pic:'',hsh:true},{av:'dynavDetalle_infotecid_unidad'},{av:'AV51UsuarioFecha',fld:'vUSUARIOFECHA',pic:'',hsh:true},{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E125J2',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
         setEventMetadata("VESTADOTICKETTICKETID.ISVALID","{handler:'E135J2',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("VESTADOTICKETTICKETID.ISVALID",",oparms:[{av:'chkavTicketresponsablecerrado.Enabled',ctrl:'vTICKETRESPONSABLECERRADO',prop:'Enabled'},{av:'chkavTicketresponsablepasataller.Enabled',ctrl:'vTICKETRESPONSABLEPASATALLER',prop:'Enabled'},{av:'chkavTicketresponsablependiente.Enabled',ctrl:'vTICKETRESPONSABLEPENDIENTE',prop:'Enabled'},{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
         setEventMetadata("VALIDV_TICKETRESPONSABLEFECHAHORAATIENDE","{handler:'Validv_Ticketresponsablefechahoraatiende',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("VALIDV_TICKETRESPONSABLEFECHAHORAATIENDE",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
         setEventMetadata("VALIDV_TICKETRESPONSABLEFECHAHORARESUELVE","{handler:'Validv_Ticketresponsablefechahoraresuelve',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("VALIDV_TICKETRESPONSABLEFECHAHORARESUELVE",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA","{handler:'Validv_Categoria_tareaid_tipo_categoria',iparms:[{av:'dynavDetalle_infotecid_unidad'},{av:'AV48detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV44id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA",",oparms:[{av:'dynavDetalle_infotecid_unidad'},{av:'AV48detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV44id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavEstadoticketticketid'},{av:'AV53EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV43categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV13TicketResponsableInstalacion',fld:'vTICKETRESPONSABLEINSTALACION',pic:''},{av:'AV14TicketResponsableConfiguracion',fld:'vTICKETRESPONSABLECONFIGURACION',pic:''},{av:'AV15TicketResponsableInternetRouter',fld:'vTICKETRESPONSABLEINTERNETROUTER',pic:''},{av:'AV16TicketResponsableFormateo',fld:'vTICKETRESPONSABLEFORMATEO',pic:''},{av:'AV29TicketResponsableReparacion',fld:'vTICKETRESPONSABLEREPARACION',pic:''},{av:'AV28TicketResponsableLimpieza',fld:'vTICKETRESPONSABLELIMPIEZA',pic:''},{av:'AV27TicketResponsablePuntoRed',fld:'vTICKETRESPONSABLEPUNTORED',pic:''},{av:'AV26TicketResponsableCambiosHardware',fld:'vTICKETRESPONSABLECAMBIOSHARDWARE',pic:''},{av:'AV25TicketResponsableCopiasRespaldo',fld:'vTICKETRESPONSABLECOPIASRESPALDO',pic:''},{av:'AV8TicketResponsableCerrado',fld:'vTICKETRESPONSABLECERRADO',pic:''},{av:'AV7TicketResponsablePendiente',fld:'vTICKETRESPONSABLEPENDIENTE',pic:''},{av:'AV6TicketResponsablePasaTaller',fld:'vTICKETRESPONSABLEPASATALLER',pic:''},{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:''}]}");
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
         wcpOAV47UsuarioEmail = "";
         wcpOAV51UsuarioFecha = DateTime.MinValue;
         wcpOAV45UsuarioNombre = "";
         wcpOAV46UsuarioDepartamento = "";
         wcpOAV58UsuarioRequerimiento = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV65fechaAntigua = (DateTime)(DateTime.MinValue);
         AV66fechaActual = (DateTime)(DateTime.MinValue);
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucTab1 = new GXUserControl();
         lblTabpage1_title_Jsonclick = "";
         lblTextblock32_Jsonclick = "";
         lblTextblock33_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         TempTags = "";
         AV12TicketResponsableInventarioSerie = "";
         lblTextblock31_Jsonclick = "";
         AV60TicketResponsableFechaHoraAtiende = (DateTime)(DateTime.MinValue);
         AV62TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
         lblTextblock2_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         AV5TicketResponsableObservacion = "";
         lblTabpage2_title_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         AV33TicketResponsableRamTxt = "";
         lblTextblock19_Jsonclick = "";
         AV34TicketResponsableDiscoDuroTxt = "";
         lblTextblock20_Jsonclick = "";
         AV35TicketResponsableProcesadorTxt = "";
         lblTextblock21_Jsonclick = "";
         AV36TicketResponsableMaletinTxt = "";
         lblTextblock22_Jsonclick = "";
         AV37TicketResponsableTonerCintaTxt = "";
         lblTextblock23_Jsonclick = "";
         AV38TicketResponsableTarjetaVideoExtraTxt = "";
         lblTextblock24_Jsonclick = "";
         AV39TicketResponsableCargadorLaptopTxt = "";
         lblTextblock25_Jsonclick = "";
         AV40TicketResponsableCDsDVDsTxt = "";
         lblTextblock26_Jsonclick = "";
         AV41TicketResponsableCableEspecialTxt = "";
         lblTextblock27_Jsonclick = "";
         AV42TicketResponsableOtrosTallerTxt = "";
         AV50prioridad = "";
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
         H005J2_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H005J2_A106nombre_categoria = new string[] {""} ;
         H005J2_n106nombre_categoria = new bool[] {false} ;
         H005J3_A5EstadoTicketId = new short[1] ;
         H005J3_A24EstadoTicketNombre = new string[] {""} ;
         H005J4_A105id_unidad_gis = new int[1] ;
         H005J4_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H005J5_A102id_actividad_categoria = new int[1] ;
         H005J5_A123nombre_actividad = new string[] {""} ;
         H005J5_n123nombre_actividad = new bool[] {false} ;
         H005J5_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         H005J5_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         H005J5_A125actividades_categoriaestado = new int[1] ;
         H005J5_n125actividades_categoriaestado = new bool[] {false} ;
         H005J6_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H005J6_A106nombre_categoria = new string[] {""} ;
         H005J6_n106nombre_categoria = new bool[] {false} ;
         AV49detalle_tarea = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         H005J7_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H005J7_A106nombre_categoria = new string[] {""} ;
         H005J7_n106nombre_categoria = new bool[] {false} ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wpsoportetecnico__datastore1(),
            new Object[][] {
                new Object[] {
               H005J2_A104categoria_tareaid_tipo_categoria, H005J2_A106nombre_categoria, H005J2_n106nombre_categoria
               }
               , new Object[] {
               H005J4_A105id_unidad_gis, H005J4_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               H005J5_A102id_actividad_categoria, H005J5_A123nombre_actividad, H005J5_n123nombre_actividad, H005J5_A122actividades_categoriaid_tipo_categoria, H005J5_n122actividades_categoriaid_tipo_categoria, H005J5_A125actividades_categoriaestado, H005J5_n125actividades_categoriaestado
               }
               , new Object[] {
               H005J6_A104categoria_tareaid_tipo_categoria, H005J6_A106nombre_categoria, H005J6_n106nombre_categoria
               }
               , new Object[] {
               H005J7_A104categoria_tareaid_tipo_categoria, H005J7_A106nombre_categoria, H005J7_n106nombre_categoria
               }
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpsoportetecnico__default(),
            new Object[][] {
                new Object[] {
               H005J3_A5EstadoTicketId, H005J3_A24EstadoTicketNombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
         chkavTicketresponsablepasataller2.Enabled = 0;
      }

      private short AV52TicketTecnicoResponsableId ;
      private short wcpOAV52TicketTecnicoResponsableId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV53EstadoTicketTicketId ;
      private short lblTextblock2_Fontbold ;
      private short lblTextblock1_Fontbold ;
      private short lblTextblock3_Fontbold ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int AV43categoria_tareaid_tipo_categoria ;
      private int Tab1_Pagecount ;
      private int lblTextblock32_Forecolor ;
      private int edtavUsuarionombre_Forecolor ;
      private int edtavUsuarionombre_Enabled ;
      private int lblTextblock33_Forecolor ;
      private int edtavUsuariodepartamento_Forecolor ;
      private int edtavUsuariodepartamento_Enabled ;
      private int lblTextblock34_Forecolor ;
      private int edtavUsuariorequerimiento_Forecolor ;
      private int edtavUsuariorequerimiento_Enabled ;
      private int lblTextblock4_Forecolor ;
      private int edtavTicketresponsableinventarioserie_Forecolor ;
      private int edtavTicketresponsableinventarioserie_Enabled ;
      private int lblTextblock31_Forecolor ;
      private int edtavTicketresponsablefechahoraatiende_Enabled ;
      private int edtavTicketresponsablefechahoraresuelve_Enabled ;
      private int lblTextblock2_Forecolor ;
      private int lblTextblock5_Forecolor ;
      private int lblTextblock6_Forecolor ;
      private int lblTextblock7_Forecolor ;
      private int lblTextblock8_Forecolor ;
      private int lblTextblock9_Forecolor ;
      private int lblTextblock10_Forecolor ;
      private int lblTextblock11_Forecolor ;
      private int lblTextblock12_Forecolor ;
      private int lblTextblock13_Forecolor ;
      private int lblTextblock1_Forecolor ;
      private int lblTextblock14_Forecolor ;
      private int lblTextblock15_Forecolor ;
      private int lblTextblock16_Forecolor ;
      private int lblTextblock17_Forecolor ;
      private int edtavTicketresponsableobservacion_Forecolor ;
      private int edtavTicketresponsableobservacion_Enabled ;
      private int lblTextblock3_Forecolor ;
      private int lblTextblock18_Forecolor ;
      private int edtavTicketresponsableramtxt_Forecolor ;
      private int edtavTicketresponsableramtxt_Enabled ;
      private int lblTextblock19_Forecolor ;
      private int edtavTicketresponsablediscodurotxt_Forecolor ;
      private int edtavTicketresponsablediscodurotxt_Enabled ;
      private int lblTextblock20_Forecolor ;
      private int edtavTicketresponsableprocesadortxt_Forecolor ;
      private int edtavTicketresponsableprocesadortxt_Enabled ;
      private int lblTextblock21_Forecolor ;
      private int edtavTicketresponsablemaletintxt_Forecolor ;
      private int edtavTicketresponsablemaletintxt_Enabled ;
      private int lblTextblock22_Forecolor ;
      private int edtavTicketresponsabletonercintatxt_Forecolor ;
      private int edtavTicketresponsabletonercintatxt_Enabled ;
      private int lblTextblock23_Forecolor ;
      private int edtavTicketresponsabletarjetavideoextratxt_Forecolor ;
      private int edtavTicketresponsabletarjetavideoextratxt_Enabled ;
      private int lblTextblock24_Forecolor ;
      private int edtavTicketresponsablecargadorlaptoptxt_Forecolor ;
      private int edtavTicketresponsablecargadorlaptoptxt_Enabled ;
      private int lblTextblock25_Forecolor ;
      private int edtavTicketresponsablecdsdvdstxt_Forecolor ;
      private int edtavTicketresponsablecdsdvdstxt_Enabled ;
      private int lblTextblock26_Forecolor ;
      private int edtavTicketresponsablecableespecialtxt_Forecolor ;
      private int edtavTicketresponsablecableespecialtxt_Enabled ;
      private int lblTextblock27_Forecolor ;
      private int edtavTicketresponsableotrostallertxt_Forecolor ;
      private int edtavTicketresponsableotrostallertxt_Enabled ;
      private int AV48detalle_infotecid_unidad ;
      private int AV44id_actividad_categoria ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private int ZV48detalle_infotecid_unidad ;
      private int ZV44id_actividad_categoria ;
      private long AV30TicketId ;
      private long AV31UsuarioId ;
      private long AV10TicketResponsableId ;
      private long wcpOAV30TicketId ;
      private long wcpOAV31UsuarioId ;
      private long wcpOAV10TicketResponsableId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Tab1_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divTable3_Internalname ;
      private string Tab1_Internalname ;
      private string lblTabpage1_title_Internalname ;
      private string lblTabpage1_title_Jsonclick ;
      private string divTabpage1table_Internalname ;
      private string divTable5_Internalname ;
      private string divTable25_Internalname ;
      private string divTable26_Internalname ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divTable27_Internalname ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtavUsuariodepartamento_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTable28_Internalname ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtavUsuariorequerimiento_Internalname ;
      private string divTable17_Internalname ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtavTicketresponsableinventarioserie_Internalname ;
      private string TempTags ;
      private string divTable19_Internalname ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string dynavEstadoticketticketid_Internalname ;
      private string dynavEstadoticketticketid_Jsonclick ;
      private string divTable30_Internalname ;
      private string edtavTicketresponsablefechahoraatiende_Internalname ;
      private string edtavTicketresponsablefechahoraatiende_Jsonclick ;
      private string divTable31_Internalname ;
      private string edtavTicketresponsablefechahoraresuelve_Internalname ;
      private string edtavTicketresponsablefechahoraresuelve_Jsonclick ;
      private string divTable21_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string divTable22_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string chkavTicketresponsableinstalacion_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string chkavTicketresponsableconfiguracion_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string chkavTicketresponsableinternetrouter_Internalname ;
      private string divTable23_Internalname ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string chkavTicketresponsableformateo_Internalname ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string chkavTicketresponsablereparacion_Internalname ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string chkavTicketresponsablelimpieza_Internalname ;
      private string divTable24_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string chkavTicketresponsablepuntored_Internalname ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string chkavTicketresponsablecambioshardware_Internalname ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string chkavTicketresponsablecopiasrespaldo_Internalname ;
      private string divTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable6_Internalname ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string chkavTicketresponsablecerrado_Internalname ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string chkavTicketresponsablependiente_Internalname ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string chkavTicketresponsablepasataller_Internalname ;
      private string divTable7_Internalname ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtavTicketresponsableobservacion_Internalname ;
      private string lblTabpage2_title_Internalname ;
      private string lblTabpage2_title_Jsonclick ;
      private string divTabpage2table_Internalname ;
      private string divTable4_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string divTable8_Internalname ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtavTicketresponsableramtxt_Internalname ;
      private string edtavTicketresponsableramtxt_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtavTicketresponsablediscodurotxt_Internalname ;
      private string edtavTicketresponsablediscodurotxt_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtavTicketresponsableprocesadortxt_Internalname ;
      private string edtavTicketresponsableprocesadortxt_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtavTicketresponsablemaletintxt_Internalname ;
      private string edtavTicketresponsablemaletintxt_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtavTicketresponsabletonercintatxt_Internalname ;
      private string edtavTicketresponsabletonercintatxt_Jsonclick ;
      private string divTable9_Internalname ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtavTicketresponsabletarjetavideoextratxt_Internalname ;
      private string edtavTicketresponsabletarjetavideoextratxt_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtavTicketresponsablecargadorlaptoptxt_Internalname ;
      private string edtavTicketresponsablecargadorlaptoptxt_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtavTicketresponsablecdsdvdstxt_Internalname ;
      private string edtavTicketresponsablecdsdvdstxt_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtavTicketresponsablecableespecialtxt_Internalname ;
      private string edtavTicketresponsablecableespecialtxt_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtavTicketresponsableotrostallertxt_Internalname ;
      private string edtavTicketresponsableotrostallertxt_Jsonclick ;
      private string divTable1_Internalname ;
      private string dynavDetalle_infotecid_unidad_Internalname ;
      private string dynavDetalle_infotecid_unidad_Jsonclick ;
      private string chkavTicketresponsablepasataller2_Internalname ;
      private string divTable13_Internalname ;
      private string divTable14_Internalname ;
      private string divTable15_Internalname ;
      private string divTable16_Internalname ;
      private string dynavCategoria_tareaid_tipo_categoria_Internalname ;
      private string dynavCategoria_tareaid_tipo_categoria_Jsonclick ;
      private string divTable18_Internalname ;
      private string dynavId_actividad_categoria_Internalname ;
      private string dynavId_actividad_categoria_Jsonclick ;
      private string divTable20_Internalname ;
      private string divTable29_Internalname ;
      private string cmbavPrioridad_Internalname ;
      private string cmbavPrioridad_Jsonclick ;
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
      private DateTime AV65fechaAntigua ;
      private DateTime AV66fechaActual ;
      private DateTime AV60TicketResponsableFechaHoraAtiende ;
      private DateTime AV62TicketResponsableFechaHoraResuelve ;
      private DateTime AV51UsuarioFecha ;
      private DateTime wcpOAV51UsuarioFecha ;
      private bool AV59TicketResponsablePasaTaller2 ;
      private bool wcpOAV59TicketResponsablePasaTaller2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Tab1_Historymanagement ;
      private bool wbLoad ;
      private bool AV13TicketResponsableInstalacion ;
      private bool AV14TicketResponsableConfiguracion ;
      private bool AV15TicketResponsableInternetRouter ;
      private bool AV16TicketResponsableFormateo ;
      private bool AV29TicketResponsableReparacion ;
      private bool AV28TicketResponsableLimpieza ;
      private bool AV27TicketResponsablePuntoRed ;
      private bool AV26TicketResponsableCambiosHardware ;
      private bool AV25TicketResponsableCopiasRespaldo ;
      private bool AV8TicketResponsableCerrado ;
      private bool AV7TicketResponsablePendiente ;
      private bool AV6TicketResponsablePasaTaller ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV47UsuarioEmail ;
      private string AV45UsuarioNombre ;
      private string AV46UsuarioDepartamento ;
      private string AV58UsuarioRequerimiento ;
      private string wcpOAV47UsuarioEmail ;
      private string wcpOAV45UsuarioNombre ;
      private string wcpOAV46UsuarioDepartamento ;
      private string wcpOAV58UsuarioRequerimiento ;
      private string AV12TicketResponsableInventarioSerie ;
      private string AV5TicketResponsableObservacion ;
      private string AV33TicketResponsableRamTxt ;
      private string AV34TicketResponsableDiscoDuroTxt ;
      private string AV35TicketResponsableProcesadorTxt ;
      private string AV36TicketResponsableMaletinTxt ;
      private string AV37TicketResponsableTonerCintaTxt ;
      private string AV38TicketResponsableTarjetaVideoExtraTxt ;
      private string AV39TicketResponsableCargadorLaptopTxt ;
      private string AV40TicketResponsableCDsDVDsTxt ;
      private string AV41TicketResponsableCableEspecialTxt ;
      private string AV42TicketResponsableOtrosTallerTxt ;
      private string AV50prioridad ;
      private string AV49detalle_tarea ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucTab1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private bool aP9_TicketResponsablePasaTaller2 ;
      private GXCombobox dynavEstadoticketticketid ;
      private GXCheckbox chkavTicketresponsableinstalacion ;
      private GXCheckbox chkavTicketresponsableconfiguracion ;
      private GXCheckbox chkavTicketresponsableinternetrouter ;
      private GXCheckbox chkavTicketresponsableformateo ;
      private GXCheckbox chkavTicketresponsablereparacion ;
      private GXCheckbox chkavTicketresponsablelimpieza ;
      private GXCheckbox chkavTicketresponsablepuntored ;
      private GXCheckbox chkavTicketresponsablecambioshardware ;
      private GXCheckbox chkavTicketresponsablecopiasrespaldo ;
      private GXCheckbox chkavTicketresponsablecerrado ;
      private GXCheckbox chkavTicketresponsablependiente ;
      private GXCheckbox chkavTicketresponsablepasataller ;
      private GXCombobox dynavDetalle_infotecid_unidad ;
      private GXCheckbox chkavTicketresponsablepasataller2 ;
      private GXCombobox dynavCategoria_tareaid_tipo_categoria ;
      private GXCombobox dynavId_actividad_categoria ;
      private GXCombobox cmbavPrioridad ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H005J2_A104categoria_tareaid_tipo_categoria ;
      private string[] H005J2_A106nombre_categoria ;
      private bool[] H005J2_n106nombre_categoria ;
      private IDataStoreProvider pr_default ;
      private short[] H005J3_A5EstadoTicketId ;
      private string[] H005J3_A24EstadoTicketNombre ;
      private int[] H005J4_A105id_unidad_gis ;
      private int[] H005J4_A104categoria_tareaid_tipo_categoria ;
      private int[] H005J5_A102id_actividad_categoria ;
      private string[] H005J5_A123nombre_actividad ;
      private bool[] H005J5_n123nombre_actividad ;
      private int[] H005J5_A122actividades_categoriaid_tipo_categoria ;
      private bool[] H005J5_n122actividades_categoriaid_tipo_categoria ;
      private int[] H005J5_A125actividades_categoriaestado ;
      private bool[] H005J5_n125actividades_categoriaestado ;
      private int[] H005J6_A104categoria_tareaid_tipo_categoria ;
      private string[] H005J6_A106nombre_categoria ;
      private bool[] H005J6_n106nombre_categoria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private int[] H005J7_A104categoria_tareaid_tipo_categoria ;
      private string[] H005J7_A106nombre_categoria ;
      private bool[] H005J7_n106nombre_categoria ;
      private GXWebForm Form ;
   }

   public class wpsoportetecnico__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005J2;
          prmH005J2 = new Object[] {
          };
          Object[] prmH005J4;
          prmH005J4 = new Object[] {
          new ParDef("@AV43categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
          };
          Object[] prmH005J5;
          prmH005J5 = new Object[] {
          new ParDef("@AV43categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
          };
          Object[] prmH005J6;
          prmH005J6 = new Object[] {
          };
          Object[] prmH005J7;
          prmH005J7 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005J2", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] ORDER BY [nombre_categoria] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005J4", "SELECT [id_unidad_gis], [id_tipo_categoria] AS categoria_tareaid_tipo_categoria FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @AV43categoria_tareaid_tipo_categoria ORDER BY [id_unidad_gis] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005J5", "SELECT [id_actividad_categoria], [nombre_actividad], [id_tipo_categoria] AS actividades_categoriaid_tipo_categoria, [estado] AS actividades_categoriaestado FROM dbo.[actividades_categoria] WHERE ([id_tipo_categoria] = @AV43categoria_tareaid_tipo_categoria) AND ([estado] = 1) ORDER BY [nombre_actividad] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005J6", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] ORDER BY [nombre_categoria] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005J7", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] ORDER BY [nombre_categoria] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J7,0, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 4 :
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

 public class wpsoportetecnico__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH005J3;
        prmH005J3 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("H005J3", "SELECT [EstadoTicketId], [EstadoTicketNombre] FROM [EstadoTicket] WHERE [EstadoTicketId] = 4 or [EstadoTicketId] = 5 ORDER BY [EstadoTicketNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005J3,0, GxCacheFrequency.OFF ,true,false )
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
              return;
     }
  }

}

}
