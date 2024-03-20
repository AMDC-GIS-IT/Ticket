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
   public class wpdesarrollosoftware : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpdesarrollosoftware( )
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

      public wpdesarrollosoftware( IGxContext context )
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
                           bool aP9_TicketResponsablePasaTaller2 ,
                           short aP10_EtapaDesarrolloId )
      {
         this.AV16TicketId = aP0_TicketId;
         this.AV56UsuarioId = aP1_UsuarioId;
         this.AV30TicketResponsableId = aP2_TicketResponsableId;
         this.AV52TicketTecnicoResponsableId = aP3_TicketTecnicoResponsableId;
         this.AV54UsuarioEmail = aP4_UsuarioEmail;
         this.AV55UsuarioFecha = aP5_UsuarioFecha;
         this.AV57UsuarioNombre = aP6_UsuarioNombre;
         this.AV53UsuarioDepartamento = aP7_UsuarioDepartamento;
         this.AV58UsuarioRequerimiento = aP8_UsuarioRequerimiento;
         this.AV59TicketResponsablePasaTaller2 = aP9_TicketResponsablePasaTaller2;
         this.AV60EtapaDesarrolloId = aP10_EtapaDesarrolloId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavEstadoticketticketid = new GXCombobox();
         chkavTicketresponsableanalasisuno = new GXCheckbox();
         chkavTicketresponsableanalasisdos = new GXCheckbox();
         chkavTicketresponsableanalasistres = new GXCheckbox();
         chkavTicketresponsableanalasiscuatro = new GXCheckbox();
         chkavTicketresponsablediseniouno = new GXCheckbox();
         chkavTicketresponsabledesarrollouno = new GXCheckbox();
         chkavTicketresponsabledesarrollodos = new GXCheckbox();
         chkavTicketresponsabledesarrollotres = new GXCheckbox();
         chkavTicketresponsabledesarrollocuatro = new GXCheckbox();
         chkavTicketresponsabledesarrollocinco = new GXCheckbox();
         chkavTicketresponsablepruebasuno = new GXCheckbox();
         chkavTicketresponsablepruebasdos = new GXCheckbox();
         chkavTicketresponsablepruebastres = new GXCheckbox();
         chkavTicketresponsablepruebascuatro = new GXCheckbox();
         chkavTicketresponsabledocumentacionuno = new GXCheckbox();
         chkavTicketresponsabledocumentaciondos = new GXCheckbox();
         chkavTicketresponsabledocumentaciontres = new GXCheckbox();
         chkavTicketresponsabledocumentacioncuatro = new GXCheckbox();
         chkavTicketresponsableimplementacionuno = new GXCheckbox();
         chkavTicketresponsableimplementaciondos = new GXCheckbox();
         chkavTicketresponsableimplementaciontres = new GXCheckbox();
         chkavTicketresponsableimplementacioncuatro = new GXCheckbox();
         chkavTicketresponsableimplementacioncinco = new GXCheckbox();
         chkavTicketresponsableimplementacionseis = new GXCheckbox();
         chkavTicketresponsablemantenimientouno = new GXCheckbox();
         chkavTicketresponsablemantenimientodos = new GXCheckbox();
         chkavTicketresponsablemantenimientotres = new GXCheckbox();
         chkavTicketresponsablemantenimientocuatro = new GXCheckbox();
         chkavTicketresponsablemantenimientocinco = new GXCheckbox();
         chkavTicketresponsablemantenimientoseis = new GXCheckbox();
         chkavTicketresponsablemantenimientosiete = new GXCheckbox();
         chkavTicketresponsablegestionbduno = new GXCheckbox();
         chkavTicketresponsablegestionbddos = new GXCheckbox();
         chkavTicketresponsablegestionbdtres = new GXCheckbox();
         chkavTicketresponsablegestionbdcuatro = new GXCheckbox();
         chkavTicketresponsablemantenimientobduno = new GXCheckbox();
         chkavTicketresponsablemantenimientobddos = new GXCheckbox();
         chkavTicketresponsablemantenimientobdtres = new GXCheckbox();
         chkavTicketresponsablemantenimientobdcuatro = new GXCheckbox();
         chkavTicketresponsablemantenimientobdcinco = new GXCheckbox();
         chkavTicketresponsablemantenimientobdseis = new GXCheckbox();
         chkavTicketresponsablemantenimientobdsiete = new GXCheckbox();
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
               GXDLVvESTADOTICKETTICKETID7E2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vDETALLE_INFOTECID_UNIDAD") == 0 )
            {
               AV5categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV5categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvDETALLE_INFOTECID_UNIDAD7E2( AV5categoria_tareaid_tipo_categoria) ;
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
               GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA7E2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vID_ACTIVIDAD_CATEGORIA") == 0 )
            {
               AV5categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri("", false, "AV5categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvID_ACTIVIDAD_CATEGORIA7E2( AV5categoria_tareaid_tipo_categoria) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCATEGORIADETALLETAREAID") == 0 )
            {
               AV12id_actividad_categoria = (int)(NumberUtil.Val( GetPar( "id_actividad_categoria"), "."));
               AssignAttri("", false, "AV12id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV12id_actividad_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCATEGORIADETALLETAREAID7E2( AV12id_actividad_categoria) ;
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
               AV16TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV16TicketId", StringUtil.LTrimStr( (decimal)(AV16TicketId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16TicketId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV56UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AssignAttri("", false, "AV56UsuarioId", StringUtil.LTrimStr( (decimal)(AV56UsuarioId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV56UsuarioId), "ZZZZZZZZZ9"), context));
                  AV30TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
                  AssignAttri("", false, "AV30TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV30TicketResponsableId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketResponsableId), "ZZZZZZZZZ9"), context));
                  AV52TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
                  AssignAttri("", false, "AV52TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV52TicketTecnicoResponsableId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
                  AV54UsuarioEmail = GetPar( "UsuarioEmail");
                  AssignAttri("", false, "AV54UsuarioEmail", AV54UsuarioEmail);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54UsuarioEmail, "")), context));
                  AV55UsuarioFecha = context.localUtil.ParseDateParm( GetPar( "UsuarioFecha"));
                  AssignAttri("", false, "AV55UsuarioFecha", context.localUtil.Format(AV55UsuarioFecha, "99/99/9999"));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV55UsuarioFecha, context));
                  AV57UsuarioNombre = GetPar( "UsuarioNombre");
                  AssignAttri("", false, "AV57UsuarioNombre", AV57UsuarioNombre);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57UsuarioNombre, "")), context));
                  AV53UsuarioDepartamento = GetPar( "UsuarioDepartamento");
                  AssignAttri("", false, "AV53UsuarioDepartamento", AV53UsuarioDepartamento);
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIODEPARTAMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53UsuarioDepartamento, "")), context));
                  AV58UsuarioRequerimiento = GetPar( "UsuarioRequerimiento");
                  AssignAttri("", false, "AV58UsuarioRequerimiento", AV58UsuarioRequerimiento);
                  AV59TicketResponsablePasaTaller2 = StringUtil.StrToBool( GetPar( "TicketResponsablePasaTaller2"));
                  AssignAttri("", false, "AV59TicketResponsablePasaTaller2", AV59TicketResponsablePasaTaller2);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEPASATALLER2", GetSecureSignedToken( "", AV59TicketResponsablePasaTaller2, context));
                  AV60EtapaDesarrolloId = (short)(NumberUtil.Val( GetPar( "EtapaDesarrolloId"), "."));
                  AssignAttri("", false, "AV60EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV60EtapaDesarrolloId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV60EtapaDesarrolloId), "ZZZ9"), context));
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
            return "wpdesarrollosoftware_Execute" ;
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
         PA7E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7E2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418822337", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpdesarrollosoftware.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV16TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV56UsuarioId,10,0)),UrlEncode(StringUtil.LTrimStr(AV30TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV52TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV54UsuarioEmail)),UrlEncode(DateTimeUtil.FormatDateParm(AV55UsuarioFecha)),UrlEncode(StringUtil.RTrim(AV57UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV53UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV58UsuarioRequerimiento)),UrlEncode(StringUtil.BoolToStr(AV59TicketResponsablePasaTaller2)),UrlEncode(StringUtil.LTrimStr(AV60EtapaDesarrolloId,4,0))}, new string[] {"TicketId","UsuarioId","TicketResponsableId","TicketTecnicoResponsableId","UsuarioEmail","UsuarioFecha","UsuarioNombre","UsuarioDepartamento","UsuarioRequerimiento","TicketResponsablePasaTaller2","EtapaDesarrolloId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEPASATALLER2", GetSecureSignedToken( "", AV59TicketResponsablePasaTaller2, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV56UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54UsuarioEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV55UsuarioFecha, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57UsuarioNombre, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIODEPARTAMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53UsuarioDepartamento, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV60EtapaDesarrolloId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vTICKETRESPONSABLEPASATALLER2", AV59TicketResponsablePasaTaller2);
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEPASATALLER2", GetSecureSignedToken( "", AV59TicketResponsablePasaTaller2, context));
         GxWebStd.gx_hidden_field( context, "vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV56UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TicketTecnicoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOEMAIL", AV54UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54UsuarioEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA", context.localUtil.DToC( AV55UsuarioFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV55UsuarioFecha, context));
         GxWebStd.gx_hidden_field( context, "TAB1_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tab1_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TAB1_Class", StringUtil.RTrim( Tab1_Class));
         GxWebStd.gx_hidden_field( context, "TAB1_Historymanagement", StringUtil.BoolToStr( Tab1_Historymanagement));
         GxWebStd.gx_hidden_field( context, "vESTADOTICKETTICKETID_Text", StringUtil.RTrim( dynavEstadoticketticketid.Description));
         GxWebStd.gx_hidden_field( context, "vCATEGORIA_TAREAID_TIPO_CATEGORIA_Text", StringUtil.RTrim( dynavCategoria_tareaid_tipo_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vID_ACTIVIDAD_CATEGORIA_Text", StringUtil.RTrim( dynavId_actividad_categoria.Description));
         GxWebStd.gx_hidden_field( context, "vPRIORIDAD_Text", StringUtil.RTrim( cmbavPrioridad.Description));
         GxWebStd.gx_hidden_field( context, "vCATEGORIADETALLETAREAID_Text", StringUtil.RTrim( dynavCategoriadetalletareaid.Description));
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
            WE7E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7E2( ) ;
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
         return formatLink("wpdesarrollosoftware.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV16TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV56UsuarioId,10,0)),UrlEncode(StringUtil.LTrimStr(AV30TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV52TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV54UsuarioEmail)),UrlEncode(DateTimeUtil.FormatDateParm(AV55UsuarioFecha)),UrlEncode(StringUtil.RTrim(AV57UsuarioNombre)),UrlEncode(StringUtil.RTrim(AV53UsuarioDepartamento)),UrlEncode(StringUtil.RTrim(AV58UsuarioRequerimiento)),UrlEncode(StringUtil.BoolToStr(AV59TicketResponsablePasaTaller2)),UrlEncode(StringUtil.LTrimStr(AV60EtapaDesarrolloId,4,0))}, new string[] {"TicketId","UsuarioId","TicketResponsableId","TicketTecnicoResponsableId","UsuarioEmail","UsuarioFecha","UsuarioNombre","UsuarioDepartamento","UsuarioRequerimiento","TicketResponsablePasaTaller2","EtapaDesarrolloId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPDesarrolloSoftware" ;
      }

      public override string GetPgmdesc( )
      {
         return "Trabajo Departamento de Desarrollo" ;
      }

      protected void WB7E0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable26_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Usuario:", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV57UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV57UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavUsuarionombre_Forecolor)+";", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable27_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Departamento:", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_html_textarea( context, edtavUsuariodepartamento_Internalname, AV53UsuarioDepartamento, "", "", 0, 1, edtavUsuariodepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_div_start( context, divTable28_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Requerimiento:", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_html_textarea( context, edtavUsuariorequerimiento_Internalname, AV58UsuarioRequerimiento, "", "", 0, 1, edtavUsuariorequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Estado Ticket:", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavEstadoticketticketid_Internalname, "Estado Ticket Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavEstadoticketticketid, dynavEstadoticketticketid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11EstadoTicketTicketId), 4, 0)), 1, dynavEstadoticketticketid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavEstadoticketticketid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavEstadoticketticketid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "", true, 1, "HLP_WPDesarrolloSoftware.htm");
            dynavEstadoticketticketid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11EstadoTicketTicketId), 4, 0));
            AssignProp("", false, dynavEstadoticketticketid_Internalname, "Values", (string)(dynavEstadoticketticketid.ToJavascriptSource()), true);
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
            /* User Defined Control */
            ucTab1.SetProperty("PageCount", Tab1_Pagecount);
            ucTab1.SetProperty("Class", Tab1_Class);
            ucTab1.SetProperty("HistoryManagement", Tab1_Historymanagement);
            ucTab1.Render(context, "tab", Tab1_Internalname, "TAB1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage1_title_Internalname, "Etapa 1 y 2 ", "", "", lblTabpage1_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_div_start( context, divTable21_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable22_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "ANÁLISIS DE PROCESO", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock5_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock5_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Recepción de documentación de solicitud de sistema", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock6_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableanalasisuno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableanalasisuno_Internalname, StringUtil.BoolToStr( AV62TicketResponsableAnalasisUno), "", "", 1, chkavTicketresponsableanalasisuno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,73);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Análisis de la información recibida", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock7_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableanalasisdos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableanalasisdos_Internalname, StringUtil.BoolToStr( AV64TicketResponsableAnalasisDos), "", "", 1, chkavTicketresponsableanalasisdos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(82, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,82);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Reunión con dependencia y exposición de lo solicitado", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock16_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableanalasistres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableanalasistres_Internalname, StringUtil.BoolToStr( AV65TicketResponsableAnalasisTres), "", "", 1, chkavTicketresponsableanalasistres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(91, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,91);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Elaboración de diagrama de flujo preliminar", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock35_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableanalasiscuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableanalasiscuatro_Internalname, StringUtil.BoolToStr( AV66TicketResponsableAnalasisCuatro), "", "", 1, chkavTicketresponsableanalasiscuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(100, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,100);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable23_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "DISEÑO CONCEPTUAL", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock8_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock8_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cualquier actividad orientada a la pre-programación del sistema", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock9_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablediseniouno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablediseniouno_Internalname, StringUtil.BoolToStr( AV67TicketResponsableDisenioUno), "", "", 1, chkavTicketresponsablediseniouno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(116, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,116);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage2_title_Internalname, "Etapa 3 y 4 ", "", "", lblTabpage2_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable24_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "DESARROLLO DE SISTEMA", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock11_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock11_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Inicio de Programación de sistema en lenguaje escogido", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock12_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledesarrollouno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledesarrollouno_Internalname, StringUtil.BoolToStr( AV68TicketResponsableDesarrolloUno), "", "", 1, chkavTicketresponsabledesarrollouno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(142, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Cualquier actividad que involucre programación ", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock13_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledesarrollodos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledesarrollodos_Internalname, StringUtil.BoolToStr( AV70TicketResponsableDesarrolloDos), "", "", 1, chkavTicketresponsabledesarrollodos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(151, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,151);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Creación de nuevos módulos o agregar mas funcionalidades", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock10_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledesarrollotres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledesarrollotres_Internalname, StringUtil.BoolToStr( AV71TicketResponsableDesarrolloTres), "", "", 1, chkavTicketresponsabledesarrollotres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(160, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,160);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Reuniones orientadas con el cliente interno, revisión de sistema", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock36_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledesarrollocuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledesarrollocuatro_Internalname, StringUtil.BoolToStr( AV72TicketResponsableDesarrolloCuatro), "", "", 1, chkavTicketresponsabledesarrollocuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(169, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,169);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Creación de tablas de base de datos, programación, etc.", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock37_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledesarrollocinco_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledesarrollocinco_Internalname, StringUtil.BoolToStr( AV73TicketResponsableDesarrolloCinco), "", "", 1, chkavTicketresponsabledesarrollocinco.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(178, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,178);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable38_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "DESARROLLO Y PRUEBAS INICIALES", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock38_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock38_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Inicio de Pruebas al interno, funcionabilidad, recursos", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock39_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablepruebasuno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepruebasuno_Internalname, StringUtil.BoolToStr( AV74TicketResponsablePruebasUno), "", "", 1, chkavTicketresponsablepruebasuno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(194, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,194);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Revisión junto al cliente del avance del  desarrollo ", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock40_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablepruebasdos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepruebasdos_Internalname, StringUtil.BoolToStr( AV76TicketResponsablePruebasDos), "", "", 1, chkavTicketresponsablepruebasdos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(203, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,203);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Carga de Información a servidor correspondiente", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock41_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablepruebastres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepruebastres_Internalname, StringUtil.BoolToStr( AV77TicketResponsablePruebasTres), "", "", 1, chkavTicketresponsablepruebastres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(212, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,212);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "Ultimas modificaciones, re-programación, incrementos de capacidad", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock42_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablepruebascuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablepruebascuatro_Internalname, StringUtil.BoolToStr( AV78TicketResponsablePruebasCuatro), "", "", 1, chkavTicketresponsablepruebascuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(221, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,221);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title3"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage3_title_Internalname, "Etapa 5 y 6 ", "", "", lblTabpage3_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage3") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel3"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage3table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable8_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "ELABORACION DE DOCUMENTACION", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock43_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock43_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "Creación de manuales de usuario", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock44_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledocumentacionuno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledocumentacionuno_Internalname, StringUtil.BoolToStr( AV80TicketResponsableDocumentacionUno), "", "", 1, chkavTicketresponsabledocumentacionuno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(246, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,246);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "Creación de ruta de la información, servidores, url, etc.", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock45_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledocumentaciondos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 255,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledocumentaciondos_Internalname, StringUtil.BoolToStr( AV81TicketResponsableDocumentacionDos), "", "", 1, chkavTicketresponsabledocumentaciondos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(255, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,255);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "Elaboración de diagramas de flujo operativos y funcionales", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock46_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledocumentaciontres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 264,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledocumentaciontres_Internalname, StringUtil.BoolToStr( AV82TicketResponsableDocumentacionTres), "", "", 1, chkavTicketresponsabledocumentaciontres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(264, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,264);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock47_Internalname, "Resumen general de proyecto, funcionamiento, requisitos, requerimientos de sistema, alcances, etc.", "", "", lblTextblock47_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock47_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsabledocumentacioncuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 273,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsabledocumentacioncuatro_Internalname, StringUtil.BoolToStr( AV83TicketResponsableDocumentacionCuatro), "", "", 1, chkavTicketresponsabledocumentacioncuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(273, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,273);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable39_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock48_Internalname, "IMPLEMENTACION", "", "", lblTextblock48_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock48_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock48_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock49_Internalname, "Elaboración de niveles de usuarios", "", "", lblTextblock49_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock49_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableimplementacionuno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 289,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableimplementacionuno_Internalname, StringUtil.BoolToStr( AV84TicketResponsableImplementacionUno), "", "", 1, chkavTicketresponsableimplementacionuno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(289, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,289);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock50_Internalname, "Creación de usuarios por dependencia", "", "", lblTextblock50_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock50_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableimplementaciondos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 298,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableimplementaciondos_Internalname, StringUtil.BoolToStr( AV87TicketResponsableImplementacionDos), "", "", 1, chkavTicketresponsableimplementaciondos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(298, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,298);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock51_Internalname, "Pruebas de conectividad en sitios a instalar el sistema", "", "", lblTextblock51_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock51_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableimplementaciontres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 307,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableimplementaciontres_Internalname, StringUtil.BoolToStr( AV88TicketResponsableImplementacionTres), "", "", 1, chkavTicketresponsableimplementaciontres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(307, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,307);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock52_Internalname, "Instalación de accesos en computadoras de usuarios", "", "", lblTextblock52_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock52_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableimplementacioncuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 316,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableimplementacioncuatro_Internalname, StringUtil.BoolToStr( AV89TicketResponsableImplementacionCuatro), "", "", 1, chkavTicketresponsableimplementacioncuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(316, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,316);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock53_Internalname, "Inicio de pruebas de reportería y estadísticas", "", "", lblTextblock53_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock53_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableimplementacioncinco_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 325,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableimplementacioncinco_Internalname, StringUtil.BoolToStr( AV90TicketResponsableImplementacionCinco), "", "", 1, chkavTicketresponsableimplementacioncinco.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(325, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,325);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock54_Internalname, "Carga de datos iniciales a base de datos", "", "", lblTextblock54_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock54_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsableimplementacionseis_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 334,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsableimplementacionseis_Internalname, StringUtil.BoolToStr( AV91TicketResponsableImplementacionSeis), "", "", 1, chkavTicketresponsableimplementacionseis.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(334, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,334);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title4"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage4_title_Internalname, "Etapa 7", "", "", lblTabpage4_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage4") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage4table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable9_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable31_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock55_Internalname, "MANTENIMIENTO DE SISTEMA", "", "", lblTextblock55_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock55_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock55_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock56_Internalname, "Atención de fallas del sistema", "", "", lblTextblock56_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock56_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientouno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 359,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientouno_Internalname, StringUtil.BoolToStr( AV93TicketResponsableMantenimientoUno), "", "", 1, chkavTicketresponsablemantenimientouno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(359, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,359);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock57_Internalname, "Atención a fallas en los servidores y sistemas conexos", "", "", lblTextblock57_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock57_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientodos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 368,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientodos_Internalname, StringUtil.BoolToStr( AV94TicketResponsableMantenimientoDos), "", "", 1, chkavTicketresponsablemantenimientodos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(368, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,368);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock58_Internalname, "Revisión rutinaria del sistema, documentar", "", "", lblTextblock58_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock58_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientotres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 377,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientotres_Internalname, StringUtil.BoolToStr( AV95TicketResponsableMantenimientoTres), "", "", 1, chkavTicketresponsablemantenimientotres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(377, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,377);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock62_Internalname, "Hacer mejoras al sistema que no incurran en ampliación del mismo", "", "", lblTextblock62_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock62_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientocuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 386,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientocuatro_Internalname, StringUtil.BoolToStr( AV96TicketResponsableMantenimientoCuatro), "", "", 1, chkavTicketresponsablemantenimientocuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(386, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,386);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable34_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock61_Internalname, "Ampliación de módulos, limites, etc. de la app", "", "", lblTextblock61_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock61_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientocinco_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 397,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientocinco_Internalname, StringUtil.BoolToStr( AV98TicketResponsableMantenimientoCinco), "", "", 1, chkavTicketresponsablemantenimientocinco.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(397, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,397);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock60_Internalname, "Administrar accesos al sistema, niveles y funcionabilidades", "", "", lblTextblock60_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock60_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientoseis_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 406,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientoseis_Internalname, StringUtil.BoolToStr( AV99TicketResponsableMantenimientoSeis), "", "", 1, chkavTicketresponsablemantenimientoseis.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(406, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,406);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock59_Internalname, "Elaboración de las copias de seguridad de sistema", "", "", lblTextblock59_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock59_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientosiete_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 415,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientosiete_Internalname, StringUtil.BoolToStr( AV101TicketResponsableMantenimientoSiete), "", "", 1, chkavTicketresponsablemantenimientosiete.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(415, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,415);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title5"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage5_title_Internalname, "Base de Datos", "", "", lblTabpage5_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage5") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel5"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage5table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable32_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock63_Internalname, "ACTIVIDADES DEL ADMINISTRADOR DE BASE DE DATOS", "", "", lblTextblock63_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock63_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock63_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable33_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock65_Internalname, "GESTION DE BASE DE DATOS", "", "", lblTextblock65_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock65_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock65_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock67_Internalname, "Definir y permitir la distribución de datos al usuario adecuado", "", "", lblTextblock67_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock67_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablegestionbduno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 443,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablegestionbduno_Internalname, StringUtil.BoolToStr( AV102TicketResponsableGestionbdUno), "", "", 1, chkavTicketresponsablegestionbduno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(443, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,443);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock68_Internalname, "Gestionar todos los componentes e instancias de las distintas bases de datos ", "", "", lblTextblock68_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock68_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablegestionbddos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 452,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablegestionbddos_Internalname, StringUtil.BoolToStr( AV103TicketResponsableGestionbdDos), "", "", 1, chkavTicketresponsablegestionbddos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(452, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,452);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock66_Internalname, "Colaboración con desarrollo para implementar una base de datos para un sistema determinado", "", "", lblTextblock66_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock66_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablegestionbdtres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 461,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablegestionbdtres_Internalname, StringUtil.BoolToStr( AV104TicketResponsableGestionbdTres), "", "", 1, chkavTicketresponsablegestionbdtres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(461, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,461);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock64_Internalname, "Modificación de búsquedas acorde a optimizar los sistemas involucrados", "", "", lblTextblock64_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock64_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablegestionbdcuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 470,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablegestionbdcuatro_Internalname, StringUtil.BoolToStr( AV105TicketResponsableGestionbdCuatro), "", "", 1, chkavTicketresponsablegestionbdcuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(470, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,470);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable40_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock69_Internalname, "MANTENIMIENTO DE BASE DE DATOS", "", "", lblTextblock69_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock69_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock69_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock72_Internalname, "Elaborar programas automáticos de respaldo de bases de datos", "", "", lblTextblock72_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock72_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobduno_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 486,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobduno_Internalname, StringUtil.BoolToStr( AV106TicketResponsableMantenimientobdUno), "", "", 1, chkavTicketresponsablemantenimientobduno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(486, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,486);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock76_Internalname, "Elaborar rutinas que garanticen la confiabilidad de la información almacenada", "", "", lblTextblock76_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock76_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobddos_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 495,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobddos_Internalname, StringUtil.BoolToStr( AV107TicketResponsableMantenimientobdDos), "", "", 1, chkavTicketresponsablemantenimientobddos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(495, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,495);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock77_Internalname, "Revisión física de los servidores de base de datos", "", "", lblTextblock77_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock77_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobdtres_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 504,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobdtres_Internalname, StringUtil.BoolToStr( AV108TicketResponsableMantenimientobdTres), "", "", 1, chkavTicketresponsablemantenimientobdtres.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(504, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,504);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock74_Internalname, "Mantener los programas de gestión de base de datos actualizados a la ultima versión", "", "", lblTextblock74_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock74_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobdcuatro_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 513,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobdcuatro_Internalname, StringUtil.BoolToStr( AV109TicketResponsableMantenimientobdCuatro), "", "", 1, chkavTicketresponsablemantenimientobdcuatro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(513, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,513);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock75_Internalname, "Atención de fallas en búsqueda de información de parte del usuario", "", "", lblTextblock75_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock75_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobdcinco_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 522,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobdcinco_Internalname, StringUtil.BoolToStr( AV111TicketResponsableMantenimientobdCinco), "", "", 1, chkavTicketresponsablemantenimientobdcinco.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(522, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,522);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock73_Internalname, "Restauración de Base de Datos", "", "", lblTextblock73_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock73_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobdseis_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 531,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobdseis_Internalname, StringUtil.BoolToStr( AV112TicketResponsableMantenimientobdSeis), "", "", 1, chkavTicketresponsablemantenimientobdseis.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(531, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,531);\"");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock71_Internalname, "Liberar espacio de servidor o equipo de almacenamiento", "", "", lblTextblock71_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "color:"+context.BuildHTMLColor( lblTextblock71_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkavTicketresponsablemantenimientobdsiete_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 540,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTicketresponsablemantenimientobdsiete_Internalname, StringUtil.BoolToStr( AV113TicketResponsableMantenimientobdSiete), "", "", 1, chkavTicketresponsablemantenimientobdsiete.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(540, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,540);\"");
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"title6"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTabpage6_title_Internalname, "", "", "", lblTabpage6_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", "", "display:none;", "div");
            context.WriteHtmlText( "TabPage6") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TAB1Container"+"panel6"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabpage6table_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable1_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavDetalle_infotecid_unidad_Internalname, "id_unidad", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 554,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavDetalle_infotecid_unidad, dynavDetalle_infotecid_unidad_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0)), 1, dynavDetalle_infotecid_unidad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavDetalle_infotecid_unidad.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,554);\"", "", true, 1, "HLP_WPDesarrolloSoftware.htm");
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", (string)(dynavDetalle_infotecid_unidad.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavEtapadesarrolloid_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavEtapadesarrolloid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60EtapaDesarrolloId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavEtapadesarrolloid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV60EtapaDesarrolloId), "ZZZ9") : context.localUtil.Format( (decimal)(AV60EtapaDesarrolloId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavEtapadesarrolloid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavEtapadesarrolloid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPDesarrolloSoftware.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Observación", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPDesarrolloSoftware.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 572,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavTicketresponsableobservacion_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavTicketresponsableobservacion_Internalname, AV37TicketResponsableObservacion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,572);\"", 0, 1, edtavTicketresponsableobservacion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPDesarrolloSoftware.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 589,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoria_tareaid_tipo_categoria, dynavCategoria_tareaid_tipo_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0)), 1, dynavCategoria_tareaid_tipo_categoria_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK."+"'", "int", "", 1, dynavCategoria_tareaid_tipo_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCategoria_tareaid_tipo_categoria.ForeColor)+";", "Attribute_Color", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,589);\"", "", true, 1, "HLP_WPDesarrolloSoftware.htm");
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 597,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavId_actividad_categoria, dynavId_actividad_categoria_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0)), 1, dynavId_actividad_categoria_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavId_actividad_categoria.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavId_actividad_categoria.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,597);\"", "", true, 1, "HLP_WPDesarrolloSoftware.htm");
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 605,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCategoriadetalletareaid, dynavCategoriadetalletareaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0)), 1, dynavCategoriadetalletareaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCategoriadetalletareaid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavCategoriadetalletareaid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,605);\"", "", true, 1, "HLP_WPDesarrolloSoftware.htm");
            dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 613,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPrioridad, cmbavPrioridad_Internalname, StringUtil.RTrim( AV14prioridad), 1, cmbavPrioridad_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbavPrioridad.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( cmbavPrioridad.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,613);\"", "", true, 1, "HLP_WPDesarrolloSoftware.htm");
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV14prioridad);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 622,'',false,'',0)\"";
            ClassString = "Button_Confirm";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDesarrolloSoftware.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 627,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPDesarrolloSoftware.htm");
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

      protected void START7E2( )
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
            Form.Meta.addItem("description", "Trabajo Departamento de Desarrollo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7E0( ) ;
      }

      protected void WS7E2( )
      {
         START7E2( ) ;
         EVT7E2( ) ;
      }

      protected void EVT7E2( )
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
                              E117E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E127E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'PRUEBA'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Prueba' */
                              E137E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E147E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E157E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E167E2 ();
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

      protected void WE7E2( )
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

      protected void PA7E2( )
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
               GX_FocusControl = dynavEstadoticketticketid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         GXVvDETALLE_INFOTECID_UNIDAD_html7E2( AV5categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html7E2( AV5categoria_tareaid_tipo_categoria) ;
         GXVvCATEGORIADETALLETAREAID_html7E2( AV12id_actividad_categoria) ;
         /* End function dynload_actions */
      }

      protected void GXDLVvESTADOTICKETTICKETID7E2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvESTADOTICKETTICKETID_data7E2( ) ;
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

      protected void GXVvESTADOTICKETTICKETID_html7E2( )
      {
         short gxdynajaxvalue;
         GXDLVvESTADOTICKETTICKETID_data7E2( ) ;
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
         if ( dynavEstadoticketticketid.ItemCount > 0 )
         {
            AV11EstadoTicketTicketId = (short)(NumberUtil.Val( dynavEstadoticketticketid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11EstadoTicketTicketId), 4, 0))), "."));
            AssignAttri("", false, "AV11EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(AV11EstadoTicketTicketId), 4, 0));
         }
      }

      protected void GXDLVvESTADOTICKETTICKETID_data7E2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         /* Using cursor H007E2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007E2_A5EstadoTicketId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007E2_A24EstadoTicketNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD7E2( int AV5categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data7E2( AV5categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvDETALLE_INFOTECID_UNIDAD_html7E2( int AV5categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvDETALLE_INFOTECID_UNIDAD_data7E2( AV5categoria_tareaid_tipo_categoria) ;
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

      protected void GXDLVvDETALLE_INFOTECID_UNIDAD_data7E2( int AV5categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007E3 */
         pr_datastore1.execute(0, new Object[] {AV5categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007E3_A105id_unidad_gis[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007E3_A105id_unidad_gis[0]), 9, 0, ".", "")));
            pr_datastore1.readNext(0);
         }
         pr_datastore1.close(0);
      }

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA7E2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data7E2( ) ;
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

      protected void GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7E2( )
      {
         int gxdynajaxvalue;
         GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data7E2( ) ;
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

      protected void GXDLVvCATEGORIA_TAREAID_TIPO_CATEGORIA_data7E2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007E4 */
         pr_datastore1.execute(1);
         while ( (pr_datastore1.getStatus(1) != 101) )
         {
            if ( (Convert.ToDecimal( H007E4_A105id_unidad_gis[0] ) == NumberUtil.Val( AV115WebSession.Get("id_unidad_tecnico"), ".") ) )
            {
               gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007E4_A104categoria_tareaid_tipo_categoria[0]), 9, 0, ".", "")));
               gxdynajaxctrldescr.Add(H007E4_A106nombre_categoria[0]);
            }
            pr_datastore1.readNext(1);
         }
         pr_datastore1.close(1);
      }

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA7E2( int AV5categoria_tareaid_tipo_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data7E2( AV5categoria_tareaid_tipo_categoria) ;
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

      protected void GXVvID_ACTIVIDAD_CATEGORIA_html7E2( int AV5categoria_tareaid_tipo_categoria )
      {
         int gxdynajaxvalue;
         GXDLVvID_ACTIVIDAD_CATEGORIA_data7E2( AV5categoria_tareaid_tipo_categoria) ;
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

      protected void GXDLVvID_ACTIVIDAD_CATEGORIA_data7E2( int AV5categoria_tareaid_tipo_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007E5 */
         pr_datastore1.execute(2, new Object[] {AV5categoria_tareaid_tipo_categoria});
         while ( (pr_datastore1.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007E5_A102id_actividad_categoria[0]), 9, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007E5_A123nombre_actividad[0]);
            pr_datastore1.readNext(2);
         }
         pr_datastore1.close(2);
      }

      protected void GXDLVvCATEGORIADETALLETAREAID7E2( int AV12id_actividad_categoria )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCATEGORIADETALLETAREAID_data7E2( AV12id_actividad_categoria) ;
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

      protected void GXVvCATEGORIADETALLETAREAID_html7E2( int AV12id_actividad_categoria )
      {
         short gxdynajaxvalue;
         GXDLVvCATEGORIADETALLETAREAID_data7E2( AV12id_actividad_categoria) ;
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

      protected void GXDLVvCATEGORIADETALLETAREAID_data7E2( int AV12id_actividad_categoria )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007E6 */
         pr_default.execute(1, new Object[] {AV12id_actividad_categoria});
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007E6_A294CategoriaDetalleTareaId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007E6_A295CategoriaDetalleTareaNombre[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvESTADOTICKETTICKETID_html7E2( ) ;
            GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7E2( ) ;
            GXVvDETALLE_INFOTECID_UNIDAD_html7E2( AV5categoria_tareaid_tipo_categoria) ;
            GXVvID_ACTIVIDAD_CATEGORIA_html7E2( AV5categoria_tareaid_tipo_categoria) ;
            GXVvCATEGORIADETALLETAREAID_html7E2( AV12id_actividad_categoria) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavEstadoticketticketid.ItemCount > 0 )
         {
            AV11EstadoTicketTicketId = (short)(NumberUtil.Val( dynavEstadoticketticketid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11EstadoTicketTicketId), 4, 0))), "."));
            AssignAttri("", false, "AV11EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(AV11EstadoTicketTicketId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavEstadoticketticketid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11EstadoTicketTicketId), 4, 0));
            AssignProp("", false, dynavEstadoticketticketid_Internalname, "Values", dynavEstadoticketticketid.ToJavascriptSource(), true);
         }
         AV62TicketResponsableAnalasisUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV62TicketResponsableAnalasisUno));
         AssignAttri("", false, "AV62TicketResponsableAnalasisUno", AV62TicketResponsableAnalasisUno);
         AV64TicketResponsableAnalasisDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV64TicketResponsableAnalasisDos));
         AssignAttri("", false, "AV64TicketResponsableAnalasisDos", AV64TicketResponsableAnalasisDos);
         AV65TicketResponsableAnalasisTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV65TicketResponsableAnalasisTres));
         AssignAttri("", false, "AV65TicketResponsableAnalasisTres", AV65TicketResponsableAnalasisTres);
         AV66TicketResponsableAnalasisCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV66TicketResponsableAnalasisCuatro));
         AssignAttri("", false, "AV66TicketResponsableAnalasisCuatro", AV66TicketResponsableAnalasisCuatro);
         AV67TicketResponsableDisenioUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV67TicketResponsableDisenioUno));
         AssignAttri("", false, "AV67TicketResponsableDisenioUno", AV67TicketResponsableDisenioUno);
         AV68TicketResponsableDesarrolloUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV68TicketResponsableDesarrolloUno));
         AssignAttri("", false, "AV68TicketResponsableDesarrolloUno", AV68TicketResponsableDesarrolloUno);
         AV70TicketResponsableDesarrolloDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV70TicketResponsableDesarrolloDos));
         AssignAttri("", false, "AV70TicketResponsableDesarrolloDos", AV70TicketResponsableDesarrolloDos);
         AV71TicketResponsableDesarrolloTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV71TicketResponsableDesarrolloTres));
         AssignAttri("", false, "AV71TicketResponsableDesarrolloTres", AV71TicketResponsableDesarrolloTres);
         AV72TicketResponsableDesarrolloCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV72TicketResponsableDesarrolloCuatro));
         AssignAttri("", false, "AV72TicketResponsableDesarrolloCuatro", AV72TicketResponsableDesarrolloCuatro);
         AV73TicketResponsableDesarrolloCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV73TicketResponsableDesarrolloCinco));
         AssignAttri("", false, "AV73TicketResponsableDesarrolloCinco", AV73TicketResponsableDesarrolloCinco);
         AV74TicketResponsablePruebasUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV74TicketResponsablePruebasUno));
         AssignAttri("", false, "AV74TicketResponsablePruebasUno", AV74TicketResponsablePruebasUno);
         AV76TicketResponsablePruebasDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV76TicketResponsablePruebasDos));
         AssignAttri("", false, "AV76TicketResponsablePruebasDos", AV76TicketResponsablePruebasDos);
         AV77TicketResponsablePruebasTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV77TicketResponsablePruebasTres));
         AssignAttri("", false, "AV77TicketResponsablePruebasTres", AV77TicketResponsablePruebasTres);
         AV78TicketResponsablePruebasCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV78TicketResponsablePruebasCuatro));
         AssignAttri("", false, "AV78TicketResponsablePruebasCuatro", AV78TicketResponsablePruebasCuatro);
         AV80TicketResponsableDocumentacionUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV80TicketResponsableDocumentacionUno));
         AssignAttri("", false, "AV80TicketResponsableDocumentacionUno", AV80TicketResponsableDocumentacionUno);
         AV81TicketResponsableDocumentacionDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV81TicketResponsableDocumentacionDos));
         AssignAttri("", false, "AV81TicketResponsableDocumentacionDos", AV81TicketResponsableDocumentacionDos);
         AV82TicketResponsableDocumentacionTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV82TicketResponsableDocumentacionTres));
         AssignAttri("", false, "AV82TicketResponsableDocumentacionTres", AV82TicketResponsableDocumentacionTres);
         AV83TicketResponsableDocumentacionCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV83TicketResponsableDocumentacionCuatro));
         AssignAttri("", false, "AV83TicketResponsableDocumentacionCuatro", AV83TicketResponsableDocumentacionCuatro);
         AV84TicketResponsableImplementacionUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV84TicketResponsableImplementacionUno));
         AssignAttri("", false, "AV84TicketResponsableImplementacionUno", AV84TicketResponsableImplementacionUno);
         AV87TicketResponsableImplementacionDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV87TicketResponsableImplementacionDos));
         AssignAttri("", false, "AV87TicketResponsableImplementacionDos", AV87TicketResponsableImplementacionDos);
         AV88TicketResponsableImplementacionTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV88TicketResponsableImplementacionTres));
         AssignAttri("", false, "AV88TicketResponsableImplementacionTres", AV88TicketResponsableImplementacionTres);
         AV89TicketResponsableImplementacionCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV89TicketResponsableImplementacionCuatro));
         AssignAttri("", false, "AV89TicketResponsableImplementacionCuatro", AV89TicketResponsableImplementacionCuatro);
         AV90TicketResponsableImplementacionCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV90TicketResponsableImplementacionCinco));
         AssignAttri("", false, "AV90TicketResponsableImplementacionCinco", AV90TicketResponsableImplementacionCinco);
         AV91TicketResponsableImplementacionSeis = StringUtil.StrToBool( StringUtil.BoolToStr( AV91TicketResponsableImplementacionSeis));
         AssignAttri("", false, "AV91TicketResponsableImplementacionSeis", AV91TicketResponsableImplementacionSeis);
         AV93TicketResponsableMantenimientoUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV93TicketResponsableMantenimientoUno));
         AssignAttri("", false, "AV93TicketResponsableMantenimientoUno", AV93TicketResponsableMantenimientoUno);
         AV94TicketResponsableMantenimientoDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV94TicketResponsableMantenimientoDos));
         AssignAttri("", false, "AV94TicketResponsableMantenimientoDos", AV94TicketResponsableMantenimientoDos);
         AV95TicketResponsableMantenimientoTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV95TicketResponsableMantenimientoTres));
         AssignAttri("", false, "AV95TicketResponsableMantenimientoTres", AV95TicketResponsableMantenimientoTres);
         AV96TicketResponsableMantenimientoCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV96TicketResponsableMantenimientoCuatro));
         AssignAttri("", false, "AV96TicketResponsableMantenimientoCuatro", AV96TicketResponsableMantenimientoCuatro);
         AV98TicketResponsableMantenimientoCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV98TicketResponsableMantenimientoCinco));
         AssignAttri("", false, "AV98TicketResponsableMantenimientoCinco", AV98TicketResponsableMantenimientoCinco);
         AV99TicketResponsableMantenimientoSeis = StringUtil.StrToBool( StringUtil.BoolToStr( AV99TicketResponsableMantenimientoSeis));
         AssignAttri("", false, "AV99TicketResponsableMantenimientoSeis", AV99TicketResponsableMantenimientoSeis);
         AV101TicketResponsableMantenimientoSiete = StringUtil.StrToBool( StringUtil.BoolToStr( AV101TicketResponsableMantenimientoSiete));
         AssignAttri("", false, "AV101TicketResponsableMantenimientoSiete", AV101TicketResponsableMantenimientoSiete);
         AV102TicketResponsableGestionbdUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV102TicketResponsableGestionbdUno));
         AssignAttri("", false, "AV102TicketResponsableGestionbdUno", AV102TicketResponsableGestionbdUno);
         AV103TicketResponsableGestionbdDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV103TicketResponsableGestionbdDos));
         AssignAttri("", false, "AV103TicketResponsableGestionbdDos", AV103TicketResponsableGestionbdDos);
         AV104TicketResponsableGestionbdTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV104TicketResponsableGestionbdTres));
         AssignAttri("", false, "AV104TicketResponsableGestionbdTres", AV104TicketResponsableGestionbdTres);
         AV105TicketResponsableGestionbdCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV105TicketResponsableGestionbdCuatro));
         AssignAttri("", false, "AV105TicketResponsableGestionbdCuatro", AV105TicketResponsableGestionbdCuatro);
         AV106TicketResponsableMantenimientobdUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV106TicketResponsableMantenimientobdUno));
         AssignAttri("", false, "AV106TicketResponsableMantenimientobdUno", AV106TicketResponsableMantenimientobdUno);
         AV107TicketResponsableMantenimientobdDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV107TicketResponsableMantenimientobdDos));
         AssignAttri("", false, "AV107TicketResponsableMantenimientobdDos", AV107TicketResponsableMantenimientobdDos);
         AV108TicketResponsableMantenimientobdTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV108TicketResponsableMantenimientobdTres));
         AssignAttri("", false, "AV108TicketResponsableMantenimientobdTres", AV108TicketResponsableMantenimientobdTres);
         AV109TicketResponsableMantenimientobdCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV109TicketResponsableMantenimientobdCuatro));
         AssignAttri("", false, "AV109TicketResponsableMantenimientobdCuatro", AV109TicketResponsableMantenimientobdCuatro);
         AV111TicketResponsableMantenimientobdCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV111TicketResponsableMantenimientobdCinco));
         AssignAttri("", false, "AV111TicketResponsableMantenimientobdCinco", AV111TicketResponsableMantenimientobdCinco);
         AV112TicketResponsableMantenimientobdSeis = StringUtil.StrToBool( StringUtil.BoolToStr( AV112TicketResponsableMantenimientobdSeis));
         AssignAttri("", false, "AV112TicketResponsableMantenimientobdSeis", AV112TicketResponsableMantenimientobdSeis);
         AV113TicketResponsableMantenimientobdSiete = StringUtil.StrToBool( StringUtil.BoolToStr( AV113TicketResponsableMantenimientobdSiete));
         AssignAttri("", false, "AV113TicketResponsableMantenimientobdSiete", AV113TicketResponsableMantenimientobdSiete);
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV6detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0))), "."));
            AssignAttri("", false, "AV6detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV6detalle_infotecid_unidad), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0));
            AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         }
         if ( dynavCategoria_tareaid_tipo_categoria.ItemCount > 0 )
         {
            AV5categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV5categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0));
            AssignProp("", false, dynavCategoria_tareaid_tipo_categoria_Internalname, "Values", dynavCategoria_tareaid_tipo_categoria.ToJavascriptSource(), true);
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV12id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0))), "."));
            AssignAttri("", false, "AV12id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV12id_actividad_categoria), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0));
            AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
         }
         if ( dynavCategoriadetalletareaid.ItemCount > 0 )
         {
            AV114CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0))), "."));
            AssignAttri("", false, "AV114CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
            AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", dynavCategoriadetalletareaid.ToJavascriptSource(), true);
         }
         if ( cmbavPrioridad.ItemCount > 0 )
         {
            AV14prioridad = cmbavPrioridad.getValidValue(AV14prioridad);
            AssignAttri("", false, "AV14prioridad", AV14prioridad);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPrioridad.CurrentValue = StringUtil.RTrim( AV14prioridad);
            AssignProp("", false, cmbavPrioridad_Internalname, "Values", cmbavPrioridad.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7E2( ) ;
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
         edtavEtapadesarrolloid_Enabled = 0;
         AssignProp("", false, edtavEtapadesarrolloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEtapadesarrolloid_Enabled), 5, 0), true);
      }

      protected void RF7E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E167E2 ();
            WB7E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7E2( )
      {
         GxWebStd.gx_boolean_hidden_field( context, "vTICKETRESPONSABLEPASATALLER2", AV59TicketResponsablePasaTaller2);
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEPASATALLER2", GetSecureSignedToken( "", AV59TicketResponsablePasaTaller2, context));
         GxWebStd.gx_hidden_field( context, "vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV56UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52TicketTecnicoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOEMAIL", AV54UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54UsuarioEmail, "")), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOFECHA", context.localUtil.DToC( AV55UsuarioFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV55UsuarioFecha, context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(dynavDetalle_infotecid_unidad.Enabled), 5, 0), true);
         edtavEtapadesarrolloid_Enabled = 0;
         AssignProp("", false, edtavEtapadesarrolloid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavEtapadesarrolloid_Enabled), 5, 0), true);
         GXVvESTADOTICKETTICKETID_html7E2( ) ;
         GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7E2( ) ;
         GXVvDETALLE_INFOTECID_UNIDAD_html7E2( AV5categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html7E2( AV5categoria_tareaid_tipo_categoria) ;
         GXVvCATEGORIADETALLETAREAID_html7E2( AV12id_actividad_categoria) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E157E2 ();
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
            dynavEstadoticketticketid.CurrentValue = cgiGet( dynavEstadoticketticketid_Internalname);
            AV11EstadoTicketTicketId = (short)(NumberUtil.Val( cgiGet( dynavEstadoticketticketid_Internalname), "."));
            AssignAttri("", false, "AV11EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(AV11EstadoTicketTicketId), 4, 0));
            AV62TicketResponsableAnalasisUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsableanalasisuno_Internalname));
            AssignAttri("", false, "AV62TicketResponsableAnalasisUno", AV62TicketResponsableAnalasisUno);
            AV64TicketResponsableAnalasisDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsableanalasisdos_Internalname));
            AssignAttri("", false, "AV64TicketResponsableAnalasisDos", AV64TicketResponsableAnalasisDos);
            AV65TicketResponsableAnalasisTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsableanalasistres_Internalname));
            AssignAttri("", false, "AV65TicketResponsableAnalasisTres", AV65TicketResponsableAnalasisTres);
            AV66TicketResponsableAnalasisCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsableanalasiscuatro_Internalname));
            AssignAttri("", false, "AV66TicketResponsableAnalasisCuatro", AV66TicketResponsableAnalasisCuatro);
            AV67TicketResponsableDisenioUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsablediseniouno_Internalname));
            AssignAttri("", false, "AV67TicketResponsableDisenioUno", AV67TicketResponsableDisenioUno);
            AV68TicketResponsableDesarrolloUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledesarrollouno_Internalname));
            AssignAttri("", false, "AV68TicketResponsableDesarrolloUno", AV68TicketResponsableDesarrolloUno);
            AV70TicketResponsableDesarrolloDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledesarrollodos_Internalname));
            AssignAttri("", false, "AV70TicketResponsableDesarrolloDos", AV70TicketResponsableDesarrolloDos);
            AV71TicketResponsableDesarrolloTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledesarrollotres_Internalname));
            AssignAttri("", false, "AV71TicketResponsableDesarrolloTres", AV71TicketResponsableDesarrolloTres);
            AV72TicketResponsableDesarrolloCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledesarrollocuatro_Internalname));
            AssignAttri("", false, "AV72TicketResponsableDesarrolloCuatro", AV72TicketResponsableDesarrolloCuatro);
            AV73TicketResponsableDesarrolloCinco = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledesarrollocinco_Internalname));
            AssignAttri("", false, "AV73TicketResponsableDesarrolloCinco", AV73TicketResponsableDesarrolloCinco);
            AV74TicketResponsablePruebasUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsablepruebasuno_Internalname));
            AssignAttri("", false, "AV74TicketResponsablePruebasUno", AV74TicketResponsablePruebasUno);
            AV76TicketResponsablePruebasDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsablepruebasdos_Internalname));
            AssignAttri("", false, "AV76TicketResponsablePruebasDos", AV76TicketResponsablePruebasDos);
            AV77TicketResponsablePruebasTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsablepruebastres_Internalname));
            AssignAttri("", false, "AV77TicketResponsablePruebasTres", AV77TicketResponsablePruebasTres);
            AV78TicketResponsablePruebasCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsablepruebascuatro_Internalname));
            AssignAttri("", false, "AV78TicketResponsablePruebasCuatro", AV78TicketResponsablePruebasCuatro);
            AV80TicketResponsableDocumentacionUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledocumentacionuno_Internalname));
            AssignAttri("", false, "AV80TicketResponsableDocumentacionUno", AV80TicketResponsableDocumentacionUno);
            AV81TicketResponsableDocumentacionDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledocumentaciondos_Internalname));
            AssignAttri("", false, "AV81TicketResponsableDocumentacionDos", AV81TicketResponsableDocumentacionDos);
            AV82TicketResponsableDocumentacionTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledocumentaciontres_Internalname));
            AssignAttri("", false, "AV82TicketResponsableDocumentacionTres", AV82TicketResponsableDocumentacionTres);
            AV83TicketResponsableDocumentacionCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsabledocumentacioncuatro_Internalname));
            AssignAttri("", false, "AV83TicketResponsableDocumentacionCuatro", AV83TicketResponsableDocumentacionCuatro);
            AV84TicketResponsableImplementacionUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsableimplementacionuno_Internalname));
            AssignAttri("", false, "AV84TicketResponsableImplementacionUno", AV84TicketResponsableImplementacionUno);
            AV87TicketResponsableImplementacionDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsableimplementaciondos_Internalname));
            AssignAttri("", false, "AV87TicketResponsableImplementacionDos", AV87TicketResponsableImplementacionDos);
            AV88TicketResponsableImplementacionTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsableimplementaciontres_Internalname));
            AssignAttri("", false, "AV88TicketResponsableImplementacionTres", AV88TicketResponsableImplementacionTres);
            AV89TicketResponsableImplementacionCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsableimplementacioncuatro_Internalname));
            AssignAttri("", false, "AV89TicketResponsableImplementacionCuatro", AV89TicketResponsableImplementacionCuatro);
            AV90TicketResponsableImplementacionCinco = StringUtil.StrToBool( cgiGet( chkavTicketresponsableimplementacioncinco_Internalname));
            AssignAttri("", false, "AV90TicketResponsableImplementacionCinco", AV90TicketResponsableImplementacionCinco);
            AV91TicketResponsableImplementacionSeis = StringUtil.StrToBool( cgiGet( chkavTicketresponsableimplementacionseis_Internalname));
            AssignAttri("", false, "AV91TicketResponsableImplementacionSeis", AV91TicketResponsableImplementacionSeis);
            AV93TicketResponsableMantenimientoUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientouno_Internalname));
            AssignAttri("", false, "AV93TicketResponsableMantenimientoUno", AV93TicketResponsableMantenimientoUno);
            AV94TicketResponsableMantenimientoDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientodos_Internalname));
            AssignAttri("", false, "AV94TicketResponsableMantenimientoDos", AV94TicketResponsableMantenimientoDos);
            AV95TicketResponsableMantenimientoTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientotres_Internalname));
            AssignAttri("", false, "AV95TicketResponsableMantenimientoTres", AV95TicketResponsableMantenimientoTres);
            AV96TicketResponsableMantenimientoCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientocuatro_Internalname));
            AssignAttri("", false, "AV96TicketResponsableMantenimientoCuatro", AV96TicketResponsableMantenimientoCuatro);
            AV98TicketResponsableMantenimientoCinco = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientocinco_Internalname));
            AssignAttri("", false, "AV98TicketResponsableMantenimientoCinco", AV98TicketResponsableMantenimientoCinco);
            AV99TicketResponsableMantenimientoSeis = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientoseis_Internalname));
            AssignAttri("", false, "AV99TicketResponsableMantenimientoSeis", AV99TicketResponsableMantenimientoSeis);
            AV101TicketResponsableMantenimientoSiete = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientosiete_Internalname));
            AssignAttri("", false, "AV101TicketResponsableMantenimientoSiete", AV101TicketResponsableMantenimientoSiete);
            AV102TicketResponsableGestionbdUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsablegestionbduno_Internalname));
            AssignAttri("", false, "AV102TicketResponsableGestionbdUno", AV102TicketResponsableGestionbdUno);
            AV103TicketResponsableGestionbdDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsablegestionbddos_Internalname));
            AssignAttri("", false, "AV103TicketResponsableGestionbdDos", AV103TicketResponsableGestionbdDos);
            AV104TicketResponsableGestionbdTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsablegestionbdtres_Internalname));
            AssignAttri("", false, "AV104TicketResponsableGestionbdTres", AV104TicketResponsableGestionbdTres);
            AV105TicketResponsableGestionbdCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsablegestionbdcuatro_Internalname));
            AssignAttri("", false, "AV105TicketResponsableGestionbdCuatro", AV105TicketResponsableGestionbdCuatro);
            AV106TicketResponsableMantenimientobdUno = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobduno_Internalname));
            AssignAttri("", false, "AV106TicketResponsableMantenimientobdUno", AV106TicketResponsableMantenimientobdUno);
            AV107TicketResponsableMantenimientobdDos = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobddos_Internalname));
            AssignAttri("", false, "AV107TicketResponsableMantenimientobdDos", AV107TicketResponsableMantenimientobdDos);
            AV108TicketResponsableMantenimientobdTres = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobdtres_Internalname));
            AssignAttri("", false, "AV108TicketResponsableMantenimientobdTres", AV108TicketResponsableMantenimientobdTres);
            AV109TicketResponsableMantenimientobdCuatro = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobdcuatro_Internalname));
            AssignAttri("", false, "AV109TicketResponsableMantenimientobdCuatro", AV109TicketResponsableMantenimientobdCuatro);
            AV111TicketResponsableMantenimientobdCinco = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobdcinco_Internalname));
            AssignAttri("", false, "AV111TicketResponsableMantenimientobdCinco", AV111TicketResponsableMantenimientobdCinco);
            AV112TicketResponsableMantenimientobdSeis = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobdseis_Internalname));
            AssignAttri("", false, "AV112TicketResponsableMantenimientobdSeis", AV112TicketResponsableMantenimientobdSeis);
            AV113TicketResponsableMantenimientobdSiete = StringUtil.StrToBool( cgiGet( chkavTicketresponsablemantenimientobdsiete_Internalname));
            AssignAttri("", false, "AV113TicketResponsableMantenimientobdSiete", AV113TicketResponsableMantenimientobdSiete);
            dynavDetalle_infotecid_unidad.CurrentValue = cgiGet( dynavDetalle_infotecid_unidad_Internalname);
            AV6detalle_infotecid_unidad = (int)(NumberUtil.Val( cgiGet( dynavDetalle_infotecid_unidad_Internalname), "."));
            AssignAttri("", false, "AV6detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(AV6detalle_infotecid_unidad), 9, 0));
            AV37TicketResponsableObservacion = cgiGet( edtavTicketresponsableobservacion_Internalname);
            AssignAttri("", false, "AV37TicketResponsableObservacion", AV37TicketResponsableObservacion);
            dynavCategoria_tareaid_tipo_categoria.CurrentValue = cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname);
            AV5categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( cgiGet( dynavCategoria_tareaid_tipo_categoria_Internalname), "."));
            AssignAttri("", false, "AV5categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV5categoria_tareaid_tipo_categoria), 9, 0));
            dynavId_actividad_categoria.CurrentValue = cgiGet( dynavId_actividad_categoria_Internalname);
            AV12id_actividad_categoria = (int)(NumberUtil.Val( cgiGet( dynavId_actividad_categoria_Internalname), "."));
            AssignAttri("", false, "AV12id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV12id_actividad_categoria), 9, 0));
            dynavCategoriadetalletareaid.CurrentValue = cgiGet( dynavCategoriadetalletareaid_Internalname);
            AV114CategoriaDetalleTareaId = (short)(NumberUtil.Val( cgiGet( dynavCategoriadetalletareaid_Internalname), "."));
            AssignAttri("", false, "AV114CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
            cmbavPrioridad.CurrentValue = cgiGet( cmbavPrioridad_Internalname);
            AV14prioridad = cgiGet( cmbavPrioridad_Internalname);
            AssignAttri("", false, "AV14prioridad", AV14prioridad);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvESTADOTICKETTICKETID_html7E2( ) ;
            GXVvCATEGORIA_TAREAID_TIPO_CATEGORIA_html7E2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E117E2( )
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
                        if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37TicketResponsableObservacion)) )
                        {
                           context.PopUp(formatLink("webpanelmsgobservacion.aspx") , new Object[] {});
                        }
                        else
                        {
                           if ( ! AV62TicketResponsableAnalasisUno && ! AV64TicketResponsableAnalasisDos && ! AV65TicketResponsableAnalasisTres && ! AV66TicketResponsableAnalasisCuatro && ! AV67TicketResponsableDisenioUno && ! AV68TicketResponsableDesarrolloUno && ! AV70TicketResponsableDesarrolloDos && ! AV71TicketResponsableDesarrolloTres && ! AV72TicketResponsableDesarrolloCuatro && ! AV73TicketResponsableDesarrolloCinco && ! AV74TicketResponsablePruebasUno && ! AV76TicketResponsablePruebasDos && ! AV77TicketResponsablePruebasTres && ! AV78TicketResponsablePruebasCuatro && ! AV80TicketResponsableDocumentacionUno && ! AV81TicketResponsableDocumentacionDos && ! AV82TicketResponsableDocumentacionTres && ! AV83TicketResponsableDocumentacionCuatro && ! AV84TicketResponsableImplementacionUno && ! AV87TicketResponsableImplementacionDos && ! AV88TicketResponsableImplementacionTres && ! AV89TicketResponsableImplementacionCuatro && ! AV90TicketResponsableImplementacionCinco && ! AV91TicketResponsableImplementacionSeis && ! AV93TicketResponsableMantenimientoUno && ! AV94TicketResponsableMantenimientoDos && ! AV95TicketResponsableMantenimientoTres && ! AV96TicketResponsableMantenimientoCuatro && ! AV98TicketResponsableMantenimientoCinco && ! AV99TicketResponsableMantenimientoSeis && ! AV101TicketResponsableMantenimientoSiete && ! AV102TicketResponsableGestionbdUno && ! AV103TicketResponsableGestionbdDos && ! AV104TicketResponsableGestionbdTres && ! AV105TicketResponsableGestionbdCuatro && ! AV106TicketResponsableMantenimientobdUno && ! AV107TicketResponsableMantenimientobdDos && ! AV108TicketResponsableMantenimientobdTres && ! AV109TicketResponsableMantenimientobdCuatro && ! AV111TicketResponsableMantenimientobdCinco && ! AV112TicketResponsableMantenimientobdSeis && ! AV113TicketResponsableMantenimientobdSiete )
                           {
                              context.PopUp(formatLink("webpanelmsgdesarrollo.aspx") , new Object[] {});
                           }
                           else
                           {
                              AV7detalle_tarea = dynavCategoria_tareaid_tipo_categoria.Description + "/-" + dynavId_actividad_categoria.Description + "/-" + dynavCategoriadetalletareaid.Description;
                              new pcrregistrardesarrollo(context ).execute(  AV16TicketId,  AV56UsuarioId,  AV30TicketResponsableId,  AV52TicketTecnicoResponsableId,  AV62TicketResponsableAnalasisUno,  AV64TicketResponsableAnalasisDos,  AV65TicketResponsableAnalasisTres,  AV66TicketResponsableAnalasisCuatro,  AV67TicketResponsableDisenioUno,  AV68TicketResponsableDesarrolloUno,  AV70TicketResponsableDesarrolloDos,  AV71TicketResponsableDesarrolloTres,  AV72TicketResponsableDesarrolloCuatro,  AV73TicketResponsableDesarrolloCinco,  AV74TicketResponsablePruebasUno,  AV76TicketResponsablePruebasDos,  AV77TicketResponsablePruebasTres,  AV78TicketResponsablePruebasCuatro,  AV80TicketResponsableDocumentacionUno,  AV81TicketResponsableDocumentacionDos,  AV82TicketResponsableDocumentacionTres,  AV83TicketResponsableDocumentacionCuatro,  AV84TicketResponsableImplementacionUno,  AV87TicketResponsableImplementacionDos,  AV88TicketResponsableImplementacionTres,  AV89TicketResponsableImplementacionCuatro,  AV90TicketResponsableImplementacionCinco,  AV91TicketResponsableImplementacionSeis,  AV93TicketResponsableMantenimientoUno,  AV94TicketResponsableMantenimientoDos,  AV95TicketResponsableMantenimientoTres,  AV96TicketResponsableMantenimientoCuatro,  AV98TicketResponsableMantenimientoCinco,  AV99TicketResponsableMantenimientoSeis,  AV101TicketResponsableMantenimientoSiete,  AV102TicketResponsableGestionbdUno,  AV103TicketResponsableGestionbdDos,  AV104TicketResponsableGestionbdTres,  AV105TicketResponsableGestionbdCuatro,  AV106TicketResponsableMantenimientobdUno,  AV107TicketResponsableMantenimientobdDos,  AV108TicketResponsableMantenimientobdTres,  AV109TicketResponsableMantenimientobdCuatro,  AV111TicketResponsableMantenimientobdCinco,  AV112TicketResponsableMantenimientobdSeis,  AV113TicketResponsableMantenimientobdSiete,  AV37TicketResponsableObservacion,  AV5categoria_tareaid_tipo_categoria,  AV12id_actividad_categoria,  AV57UsuarioNombre,  AV53UsuarioDepartamento,  AV54UsuarioEmail,  (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.Description, ".")),  AV7detalle_tarea,  cmbavPrioridad.Description,  AV55UsuarioFecha,  AV11EstadoTicketTicketId,  AV60EtapaDesarrolloId) ;
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
         }
      }

      protected void E127E2( )
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

      protected void E137E2( )
      {
         /* 'Prueba' Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         AV61window.Url = "http://localhost/kb_ticket.NetEnvironment/wpdesarrollosoftware.aspx";
         context.NewWindow(AV61window);
         /*  Sending Event outputs  */
      }

      protected void E147E2( )
      {
         /* Categoria_tareaid_tipo_categoria_Click Routine */
         returnInSub = false;
         dynavCategoriadetalletareaid.removeAllItems();
         dynavCategoriadetalletareaid.Description = "(Ninguno)";
         /*  Sending Event outputs  */
         dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
         AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", dynavCategoriadetalletareaid.ToJavascriptSource(), true);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E157E2 ();
         if (returnInSub) return;
      }

      protected void E157E2( )
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
         edtavUsuariodepartamento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariodepartamento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariodepartamento_Forecolor), 9, 0), true);
         edtavUsuariorequerimiento_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuariorequerimiento_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuariorequerimiento_Forecolor), 9, 0), true);
         dynavEstadoticketticketid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavEstadoticketticketid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavEstadoticketticketid.ForeColor), 9, 0), true);
         lblTextblock5_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock5_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock5_Forecolor), 9, 0), true);
         lblTextblock8_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock8_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock8_Forecolor), 9, 0), true);
         lblTextblock6_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock6_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock6_Forecolor), 9, 0), true);
         lblTextblock7_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock7_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock7_Forecolor), 9, 0), true);
         lblTextblock16_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock16_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock16_Forecolor), 9, 0), true);
         lblTextblock35_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock35_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock35_Forecolor), 9, 0), true);
         lblTextblock9_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock9_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock9_Forecolor), 9, 0), true);
         lblTextblock11_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock11_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock11_Forecolor), 9, 0), true);
         lblTextblock38_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock38_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock38_Forecolor), 9, 0), true);
         lblTextblock12_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock12_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock12_Forecolor), 9, 0), true);
         lblTextblock13_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock13_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock13_Forecolor), 9, 0), true);
         lblTextblock10_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock10_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock10_Forecolor), 9, 0), true);
         lblTextblock36_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock36_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock36_Forecolor), 9, 0), true);
         lblTextblock37_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock37_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock37_Forecolor), 9, 0), true);
         lblTextblock39_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock39_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock39_Forecolor), 9, 0), true);
         lblTextblock40_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock40_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock40_Forecolor), 9, 0), true);
         lblTextblock41_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock41_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock41_Forecolor), 9, 0), true);
         lblTextblock42_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock42_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock42_Forecolor), 9, 0), true);
         lblTextblock43_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock43_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock43_Forecolor), 9, 0), true);
         lblTextblock44_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock44_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock44_Forecolor), 9, 0), true);
         lblTextblock45_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock45_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock45_Forecolor), 9, 0), true);
         lblTextblock46_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock46_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock46_Forecolor), 9, 0), true);
         lblTextblock47_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock47_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock47_Forecolor), 9, 0), true);
         lblTextblock48_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock48_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock48_Forecolor), 9, 0), true);
         lblTextblock49_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock49_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock49_Forecolor), 9, 0), true);
         lblTextblock50_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock50_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock50_Forecolor), 9, 0), true);
         lblTextblock51_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock51_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock51_Forecolor), 9, 0), true);
         lblTextblock52_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock52_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock52_Forecolor), 9, 0), true);
         lblTextblock53_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock53_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock53_Forecolor), 9, 0), true);
         lblTextblock50_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock50_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock50_Forecolor), 9, 0), true);
         lblTextblock51_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock51_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock51_Forecolor), 9, 0), true);
         lblTextblock52_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock52_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock52_Forecolor), 9, 0), true);
         lblTextblock53_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock53_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock53_Forecolor), 9, 0), true);
         lblTextblock54_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock54_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock54_Forecolor), 9, 0), true);
         lblTextblock55_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock55_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock55_Forecolor), 9, 0), true);
         lblTextblock56_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock56_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock56_Forecolor), 9, 0), true);
         lblTextblock57_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock57_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock57_Forecolor), 9, 0), true);
         lblTextblock58_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock58_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock58_Forecolor), 9, 0), true);
         lblTextblock59_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock59_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock59_Forecolor), 9, 0), true);
         lblTextblock60_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock60_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock60_Forecolor), 9, 0), true);
         lblTextblock61_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock61_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock61_Forecolor), 9, 0), true);
         lblTextblock62_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock62_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock62_Forecolor), 9, 0), true);
         lblTextblock63_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock63_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock63_Forecolor), 9, 0), true);
         lblTextblock64_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock64_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock64_Forecolor), 9, 0), true);
         lblTextblock65_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock65_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock65_Forecolor), 9, 0), true);
         lblTextblock66_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock66_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock66_Forecolor), 9, 0), true);
         lblTextblock67_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock67_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock67_Forecolor), 9, 0), true);
         lblTextblock68_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock68_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock68_Forecolor), 9, 0), true);
         lblTextblock69_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock69_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock69_Forecolor), 9, 0), true);
         lblTextblock71_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock71_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock71_Forecolor), 9, 0), true);
         lblTextblock72_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock72_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock72_Forecolor), 9, 0), true);
         lblTextblock73_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock73_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock73_Forecolor), 9, 0), true);
         lblTextblock74_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock74_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock74_Forecolor), 9, 0), true);
         lblTextblock75_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock75_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock75_Forecolor), 9, 0), true);
         lblTextblock76_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock76_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock76_Forecolor), 9, 0), true);
         lblTextblock77_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock77_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock77_Forecolor), 9, 0), true);
         lblTextblock63_Fontbold = 1;
         AssignProp("", false, lblTextblock63_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock63_Fontbold), 1, 0), true);
         lblTextblock65_Fontbold = 1;
         AssignProp("", false, lblTextblock65_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock65_Fontbold), 1, 0), true);
         lblTextblock69_Fontbold = 1;
         AssignProp("", false, lblTextblock69_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock69_Fontbold), 1, 0), true);
         lblTextblock55_Fontbold = 1;
         AssignProp("", false, lblTextblock55_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock55_Fontbold), 1, 0), true);
         lblTextblock43_Fontbold = 1;
         AssignProp("", false, lblTextblock43_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock43_Fontbold), 1, 0), true);
         lblTextblock48_Fontbold = 1;
         AssignProp("", false, lblTextblock48_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock48_Fontbold), 1, 0), true);
         lblTextblock11_Fontbold = 1;
         AssignProp("", false, lblTextblock11_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock11_Fontbold), 1, 0), true);
         lblTextblock38_Fontbold = 1;
         AssignProp("", false, lblTextblock38_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock38_Fontbold), 1, 0), true);
         lblTextblock5_Fontbold = 1;
         AssignProp("", false, lblTextblock5_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock5_Fontbold), 1, 0), true);
         lblTextblock8_Fontbold = 1;
         AssignProp("", false, lblTextblock8_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock8_Fontbold), 1, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E167E2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV16TicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV16TicketId", StringUtil.LTrimStr( (decimal)(AV16TicketId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV16TicketId), "ZZZZZZZZZ9"), context));
         AV56UsuarioId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV56UsuarioId", StringUtil.LTrimStr( (decimal)(AV56UsuarioId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV56UsuarioId), "ZZZZZZZZZ9"), context));
         AV30TicketResponsableId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV30TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV30TicketResponsableId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30TicketResponsableId), "ZZZZZZZZZ9"), context));
         AV52TicketTecnicoResponsableId = Convert.ToInt16(getParm(obj,3));
         AssignAttri("", false, "AV52TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV52TicketTecnicoResponsableId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV52TicketTecnicoResponsableId), "ZZZ9"), context));
         AV54UsuarioEmail = (string)getParm(obj,4);
         AssignAttri("", false, "AV54UsuarioEmail", AV54UsuarioEmail);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOEMAIL", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV54UsuarioEmail, "")), context));
         AV55UsuarioFecha = (DateTime)getParm(obj,5);
         AssignAttri("", false, "AV55UsuarioFecha", context.localUtil.Format(AV55UsuarioFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOFECHA", GetSecureSignedToken( "", AV55UsuarioFecha, context));
         AV57UsuarioNombre = (string)getParm(obj,6);
         AssignAttri("", false, "AV57UsuarioNombre", AV57UsuarioNombre);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIONOMBRE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV57UsuarioNombre, "")), context));
         AV53UsuarioDepartamento = (string)getParm(obj,7);
         AssignAttri("", false, "AV53UsuarioDepartamento", AV53UsuarioDepartamento);
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIODEPARTAMENTO", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV53UsuarioDepartamento, "")), context));
         AV58UsuarioRequerimiento = (string)getParm(obj,8);
         AssignAttri("", false, "AV58UsuarioRequerimiento", AV58UsuarioRequerimiento);
         AV59TicketResponsablePasaTaller2 = (bool)getParm(obj,9);
         AssignAttri("", false, "AV59TicketResponsablePasaTaller2", AV59TicketResponsablePasaTaller2);
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEPASATALLER2", GetSecureSignedToken( "", AV59TicketResponsablePasaTaller2, context));
         AV60EtapaDesarrolloId = Convert.ToInt16(getParm(obj,10));
         AssignAttri("", false, "AV60EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV60EtapaDesarrolloId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vETAPADESARROLLOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV60EtapaDesarrolloId), "ZZZ9"), context));
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
         PA7E2( ) ;
         WS7E2( ) ;
         WE7E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188222167", true, true);
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
         context.AddJavascriptSource("wpdesarrollosoftware.js", "?2024188222167", false, true);
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
         chkavTicketresponsableanalasisuno.Name = "vTICKETRESPONSABLEANALASISUNO";
         chkavTicketresponsableanalasisuno.WebTags = "";
         chkavTicketresponsableanalasisuno.Caption = "";
         AssignProp("", false, chkavTicketresponsableanalasisuno_Internalname, "TitleCaption", chkavTicketresponsableanalasisuno.Caption, true);
         chkavTicketresponsableanalasisuno.CheckedValue = "false";
         AV62TicketResponsableAnalasisUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV62TicketResponsableAnalasisUno));
         AssignAttri("", false, "AV62TicketResponsableAnalasisUno", AV62TicketResponsableAnalasisUno);
         chkavTicketresponsableanalasisdos.Name = "vTICKETRESPONSABLEANALASISDOS";
         chkavTicketresponsableanalasisdos.WebTags = "";
         chkavTicketresponsableanalasisdos.Caption = "";
         AssignProp("", false, chkavTicketresponsableanalasisdos_Internalname, "TitleCaption", chkavTicketresponsableanalasisdos.Caption, true);
         chkavTicketresponsableanalasisdos.CheckedValue = "false";
         AV64TicketResponsableAnalasisDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV64TicketResponsableAnalasisDos));
         AssignAttri("", false, "AV64TicketResponsableAnalasisDos", AV64TicketResponsableAnalasisDos);
         chkavTicketresponsableanalasistres.Name = "vTICKETRESPONSABLEANALASISTRES";
         chkavTicketresponsableanalasistres.WebTags = "";
         chkavTicketresponsableanalasistres.Caption = "";
         AssignProp("", false, chkavTicketresponsableanalasistres_Internalname, "TitleCaption", chkavTicketresponsableanalasistres.Caption, true);
         chkavTicketresponsableanalasistres.CheckedValue = "false";
         AV65TicketResponsableAnalasisTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV65TicketResponsableAnalasisTres));
         AssignAttri("", false, "AV65TicketResponsableAnalasisTres", AV65TicketResponsableAnalasisTres);
         chkavTicketresponsableanalasiscuatro.Name = "vTICKETRESPONSABLEANALASISCUATRO";
         chkavTicketresponsableanalasiscuatro.WebTags = "";
         chkavTicketresponsableanalasiscuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsableanalasiscuatro_Internalname, "TitleCaption", chkavTicketresponsableanalasiscuatro.Caption, true);
         chkavTicketresponsableanalasiscuatro.CheckedValue = "false";
         AV66TicketResponsableAnalasisCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV66TicketResponsableAnalasisCuatro));
         AssignAttri("", false, "AV66TicketResponsableAnalasisCuatro", AV66TicketResponsableAnalasisCuatro);
         chkavTicketresponsablediseniouno.Name = "vTICKETRESPONSABLEDISENIOUNO";
         chkavTicketresponsablediseniouno.WebTags = "";
         chkavTicketresponsablediseniouno.Caption = "";
         AssignProp("", false, chkavTicketresponsablediseniouno_Internalname, "TitleCaption", chkavTicketresponsablediseniouno.Caption, true);
         chkavTicketresponsablediseniouno.CheckedValue = "false";
         AV67TicketResponsableDisenioUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV67TicketResponsableDisenioUno));
         AssignAttri("", false, "AV67TicketResponsableDisenioUno", AV67TicketResponsableDisenioUno);
         chkavTicketresponsabledesarrollouno.Name = "vTICKETRESPONSABLEDESARROLLOUNO";
         chkavTicketresponsabledesarrollouno.WebTags = "";
         chkavTicketresponsabledesarrollouno.Caption = "";
         AssignProp("", false, chkavTicketresponsabledesarrollouno_Internalname, "TitleCaption", chkavTicketresponsabledesarrollouno.Caption, true);
         chkavTicketresponsabledesarrollouno.CheckedValue = "false";
         AV68TicketResponsableDesarrolloUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV68TicketResponsableDesarrolloUno));
         AssignAttri("", false, "AV68TicketResponsableDesarrolloUno", AV68TicketResponsableDesarrolloUno);
         chkavTicketresponsabledesarrollodos.Name = "vTICKETRESPONSABLEDESARROLLODOS";
         chkavTicketresponsabledesarrollodos.WebTags = "";
         chkavTicketresponsabledesarrollodos.Caption = "";
         AssignProp("", false, chkavTicketresponsabledesarrollodos_Internalname, "TitleCaption", chkavTicketresponsabledesarrollodos.Caption, true);
         chkavTicketresponsabledesarrollodos.CheckedValue = "false";
         AV70TicketResponsableDesarrolloDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV70TicketResponsableDesarrolloDos));
         AssignAttri("", false, "AV70TicketResponsableDesarrolloDos", AV70TicketResponsableDesarrolloDos);
         chkavTicketresponsabledesarrollotres.Name = "vTICKETRESPONSABLEDESARROLLOTRES";
         chkavTicketresponsabledesarrollotres.WebTags = "";
         chkavTicketresponsabledesarrollotres.Caption = "";
         AssignProp("", false, chkavTicketresponsabledesarrollotres_Internalname, "TitleCaption", chkavTicketresponsabledesarrollotres.Caption, true);
         chkavTicketresponsabledesarrollotres.CheckedValue = "false";
         AV71TicketResponsableDesarrolloTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV71TicketResponsableDesarrolloTres));
         AssignAttri("", false, "AV71TicketResponsableDesarrolloTres", AV71TicketResponsableDesarrolloTres);
         chkavTicketresponsabledesarrollocuatro.Name = "vTICKETRESPONSABLEDESARROLLOCUATRO";
         chkavTicketresponsabledesarrollocuatro.WebTags = "";
         chkavTicketresponsabledesarrollocuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsabledesarrollocuatro_Internalname, "TitleCaption", chkavTicketresponsabledesarrollocuatro.Caption, true);
         chkavTicketresponsabledesarrollocuatro.CheckedValue = "false";
         AV72TicketResponsableDesarrolloCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV72TicketResponsableDesarrolloCuatro));
         AssignAttri("", false, "AV72TicketResponsableDesarrolloCuatro", AV72TicketResponsableDesarrolloCuatro);
         chkavTicketresponsabledesarrollocinco.Name = "vTICKETRESPONSABLEDESARROLLOCINCO";
         chkavTicketresponsabledesarrollocinco.WebTags = "";
         chkavTicketresponsabledesarrollocinco.Caption = "";
         AssignProp("", false, chkavTicketresponsabledesarrollocinco_Internalname, "TitleCaption", chkavTicketresponsabledesarrollocinco.Caption, true);
         chkavTicketresponsabledesarrollocinco.CheckedValue = "false";
         AV73TicketResponsableDesarrolloCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV73TicketResponsableDesarrolloCinco));
         AssignAttri("", false, "AV73TicketResponsableDesarrolloCinco", AV73TicketResponsableDesarrolloCinco);
         chkavTicketresponsablepruebasuno.Name = "vTICKETRESPONSABLEPRUEBASUNO";
         chkavTicketresponsablepruebasuno.WebTags = "";
         chkavTicketresponsablepruebasuno.Caption = "";
         AssignProp("", false, chkavTicketresponsablepruebasuno_Internalname, "TitleCaption", chkavTicketresponsablepruebasuno.Caption, true);
         chkavTicketresponsablepruebasuno.CheckedValue = "false";
         AV74TicketResponsablePruebasUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV74TicketResponsablePruebasUno));
         AssignAttri("", false, "AV74TicketResponsablePruebasUno", AV74TicketResponsablePruebasUno);
         chkavTicketresponsablepruebasdos.Name = "vTICKETRESPONSABLEPRUEBASDOS";
         chkavTicketresponsablepruebasdos.WebTags = "";
         chkavTicketresponsablepruebasdos.Caption = "";
         AssignProp("", false, chkavTicketresponsablepruebasdos_Internalname, "TitleCaption", chkavTicketresponsablepruebasdos.Caption, true);
         chkavTicketresponsablepruebasdos.CheckedValue = "false";
         AV76TicketResponsablePruebasDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV76TicketResponsablePruebasDos));
         AssignAttri("", false, "AV76TicketResponsablePruebasDos", AV76TicketResponsablePruebasDos);
         chkavTicketresponsablepruebastres.Name = "vTICKETRESPONSABLEPRUEBASTRES";
         chkavTicketresponsablepruebastres.WebTags = "";
         chkavTicketresponsablepruebastres.Caption = "";
         AssignProp("", false, chkavTicketresponsablepruebastres_Internalname, "TitleCaption", chkavTicketresponsablepruebastres.Caption, true);
         chkavTicketresponsablepruebastres.CheckedValue = "false";
         AV77TicketResponsablePruebasTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV77TicketResponsablePruebasTres));
         AssignAttri("", false, "AV77TicketResponsablePruebasTres", AV77TicketResponsablePruebasTres);
         chkavTicketresponsablepruebascuatro.Name = "vTICKETRESPONSABLEPRUEBASCUATRO";
         chkavTicketresponsablepruebascuatro.WebTags = "";
         chkavTicketresponsablepruebascuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsablepruebascuatro_Internalname, "TitleCaption", chkavTicketresponsablepruebascuatro.Caption, true);
         chkavTicketresponsablepruebascuatro.CheckedValue = "false";
         AV78TicketResponsablePruebasCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV78TicketResponsablePruebasCuatro));
         AssignAttri("", false, "AV78TicketResponsablePruebasCuatro", AV78TicketResponsablePruebasCuatro);
         chkavTicketresponsabledocumentacionuno.Name = "vTICKETRESPONSABLEDOCUMENTACIONUNO";
         chkavTicketresponsabledocumentacionuno.WebTags = "";
         chkavTicketresponsabledocumentacionuno.Caption = "";
         AssignProp("", false, chkavTicketresponsabledocumentacionuno_Internalname, "TitleCaption", chkavTicketresponsabledocumentacionuno.Caption, true);
         chkavTicketresponsabledocumentacionuno.CheckedValue = "false";
         AV80TicketResponsableDocumentacionUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV80TicketResponsableDocumentacionUno));
         AssignAttri("", false, "AV80TicketResponsableDocumentacionUno", AV80TicketResponsableDocumentacionUno);
         chkavTicketresponsabledocumentaciondos.Name = "vTICKETRESPONSABLEDOCUMENTACIONDOS";
         chkavTicketresponsabledocumentaciondos.WebTags = "";
         chkavTicketresponsabledocumentaciondos.Caption = "";
         AssignProp("", false, chkavTicketresponsabledocumentaciondos_Internalname, "TitleCaption", chkavTicketresponsabledocumentaciondos.Caption, true);
         chkavTicketresponsabledocumentaciondos.CheckedValue = "false";
         AV81TicketResponsableDocumentacionDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV81TicketResponsableDocumentacionDos));
         AssignAttri("", false, "AV81TicketResponsableDocumentacionDos", AV81TicketResponsableDocumentacionDos);
         chkavTicketresponsabledocumentaciontres.Name = "vTICKETRESPONSABLEDOCUMENTACIONTRES";
         chkavTicketresponsabledocumentaciontres.WebTags = "";
         chkavTicketresponsabledocumentaciontres.Caption = "";
         AssignProp("", false, chkavTicketresponsabledocumentaciontres_Internalname, "TitleCaption", chkavTicketresponsabledocumentaciontres.Caption, true);
         chkavTicketresponsabledocumentaciontres.CheckedValue = "false";
         AV82TicketResponsableDocumentacionTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV82TicketResponsableDocumentacionTres));
         AssignAttri("", false, "AV82TicketResponsableDocumentacionTres", AV82TicketResponsableDocumentacionTres);
         chkavTicketresponsabledocumentacioncuatro.Name = "vTICKETRESPONSABLEDOCUMENTACIONCUATRO";
         chkavTicketresponsabledocumentacioncuatro.WebTags = "";
         chkavTicketresponsabledocumentacioncuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsabledocumentacioncuatro_Internalname, "TitleCaption", chkavTicketresponsabledocumentacioncuatro.Caption, true);
         chkavTicketresponsabledocumentacioncuatro.CheckedValue = "false";
         AV83TicketResponsableDocumentacionCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV83TicketResponsableDocumentacionCuatro));
         AssignAttri("", false, "AV83TicketResponsableDocumentacionCuatro", AV83TicketResponsableDocumentacionCuatro);
         chkavTicketresponsableimplementacionuno.Name = "vTICKETRESPONSABLEIMPLEMENTACIONUNO";
         chkavTicketresponsableimplementacionuno.WebTags = "";
         chkavTicketresponsableimplementacionuno.Caption = "";
         AssignProp("", false, chkavTicketresponsableimplementacionuno_Internalname, "TitleCaption", chkavTicketresponsableimplementacionuno.Caption, true);
         chkavTicketresponsableimplementacionuno.CheckedValue = "false";
         AV84TicketResponsableImplementacionUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV84TicketResponsableImplementacionUno));
         AssignAttri("", false, "AV84TicketResponsableImplementacionUno", AV84TicketResponsableImplementacionUno);
         chkavTicketresponsableimplementaciondos.Name = "vTICKETRESPONSABLEIMPLEMENTACIONDOS";
         chkavTicketresponsableimplementaciondos.WebTags = "";
         chkavTicketresponsableimplementaciondos.Caption = "";
         AssignProp("", false, chkavTicketresponsableimplementaciondos_Internalname, "TitleCaption", chkavTicketresponsableimplementaciondos.Caption, true);
         chkavTicketresponsableimplementaciondos.CheckedValue = "false";
         AV87TicketResponsableImplementacionDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV87TicketResponsableImplementacionDos));
         AssignAttri("", false, "AV87TicketResponsableImplementacionDos", AV87TicketResponsableImplementacionDos);
         chkavTicketresponsableimplementaciontres.Name = "vTICKETRESPONSABLEIMPLEMENTACIONTRES";
         chkavTicketresponsableimplementaciontres.WebTags = "";
         chkavTicketresponsableimplementaciontres.Caption = "";
         AssignProp("", false, chkavTicketresponsableimplementaciontres_Internalname, "TitleCaption", chkavTicketresponsableimplementaciontres.Caption, true);
         chkavTicketresponsableimplementaciontres.CheckedValue = "false";
         AV88TicketResponsableImplementacionTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV88TicketResponsableImplementacionTres));
         AssignAttri("", false, "AV88TicketResponsableImplementacionTres", AV88TicketResponsableImplementacionTres);
         chkavTicketresponsableimplementacioncuatro.Name = "vTICKETRESPONSABLEIMPLEMENTACIONCUATRO";
         chkavTicketresponsableimplementacioncuatro.WebTags = "";
         chkavTicketresponsableimplementacioncuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsableimplementacioncuatro_Internalname, "TitleCaption", chkavTicketresponsableimplementacioncuatro.Caption, true);
         chkavTicketresponsableimplementacioncuatro.CheckedValue = "false";
         AV89TicketResponsableImplementacionCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV89TicketResponsableImplementacionCuatro));
         AssignAttri("", false, "AV89TicketResponsableImplementacionCuatro", AV89TicketResponsableImplementacionCuatro);
         chkavTicketresponsableimplementacioncinco.Name = "vTICKETRESPONSABLEIMPLEMENTACIONCINCO";
         chkavTicketresponsableimplementacioncinco.WebTags = "";
         chkavTicketresponsableimplementacioncinco.Caption = "";
         AssignProp("", false, chkavTicketresponsableimplementacioncinco_Internalname, "TitleCaption", chkavTicketresponsableimplementacioncinco.Caption, true);
         chkavTicketresponsableimplementacioncinco.CheckedValue = "false";
         AV90TicketResponsableImplementacionCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV90TicketResponsableImplementacionCinco));
         AssignAttri("", false, "AV90TicketResponsableImplementacionCinco", AV90TicketResponsableImplementacionCinco);
         chkavTicketresponsableimplementacionseis.Name = "vTICKETRESPONSABLEIMPLEMENTACIONSEIS";
         chkavTicketresponsableimplementacionseis.WebTags = "";
         chkavTicketresponsableimplementacionseis.Caption = "";
         AssignProp("", false, chkavTicketresponsableimplementacionseis_Internalname, "TitleCaption", chkavTicketresponsableimplementacionseis.Caption, true);
         chkavTicketresponsableimplementacionseis.CheckedValue = "false";
         AV91TicketResponsableImplementacionSeis = StringUtil.StrToBool( StringUtil.BoolToStr( AV91TicketResponsableImplementacionSeis));
         AssignAttri("", false, "AV91TicketResponsableImplementacionSeis", AV91TicketResponsableImplementacionSeis);
         chkavTicketresponsablemantenimientouno.Name = "vTICKETRESPONSABLEMANTENIMIENTOUNO";
         chkavTicketresponsablemantenimientouno.WebTags = "";
         chkavTicketresponsablemantenimientouno.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientouno_Internalname, "TitleCaption", chkavTicketresponsablemantenimientouno.Caption, true);
         chkavTicketresponsablemantenimientouno.CheckedValue = "false";
         AV93TicketResponsableMantenimientoUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV93TicketResponsableMantenimientoUno));
         AssignAttri("", false, "AV93TicketResponsableMantenimientoUno", AV93TicketResponsableMantenimientoUno);
         chkavTicketresponsablemantenimientodos.Name = "vTICKETRESPONSABLEMANTENIMIENTODOS";
         chkavTicketresponsablemantenimientodos.WebTags = "";
         chkavTicketresponsablemantenimientodos.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientodos_Internalname, "TitleCaption", chkavTicketresponsablemantenimientodos.Caption, true);
         chkavTicketresponsablemantenimientodos.CheckedValue = "false";
         AV94TicketResponsableMantenimientoDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV94TicketResponsableMantenimientoDos));
         AssignAttri("", false, "AV94TicketResponsableMantenimientoDos", AV94TicketResponsableMantenimientoDos);
         chkavTicketresponsablemantenimientotres.Name = "vTICKETRESPONSABLEMANTENIMIENTOTRES";
         chkavTicketresponsablemantenimientotres.WebTags = "";
         chkavTicketresponsablemantenimientotres.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientotres_Internalname, "TitleCaption", chkavTicketresponsablemantenimientotres.Caption, true);
         chkavTicketresponsablemantenimientotres.CheckedValue = "false";
         AV95TicketResponsableMantenimientoTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV95TicketResponsableMantenimientoTres));
         AssignAttri("", false, "AV95TicketResponsableMantenimientoTres", AV95TicketResponsableMantenimientoTres);
         chkavTicketresponsablemantenimientocuatro.Name = "vTICKETRESPONSABLEMANTENIMIENTOCUATRO";
         chkavTicketresponsablemantenimientocuatro.WebTags = "";
         chkavTicketresponsablemantenimientocuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientocuatro_Internalname, "TitleCaption", chkavTicketresponsablemantenimientocuatro.Caption, true);
         chkavTicketresponsablemantenimientocuatro.CheckedValue = "false";
         AV96TicketResponsableMantenimientoCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV96TicketResponsableMantenimientoCuatro));
         AssignAttri("", false, "AV96TicketResponsableMantenimientoCuatro", AV96TicketResponsableMantenimientoCuatro);
         chkavTicketresponsablemantenimientocinco.Name = "vTICKETRESPONSABLEMANTENIMIENTOCINCO";
         chkavTicketresponsablemantenimientocinco.WebTags = "";
         chkavTicketresponsablemantenimientocinco.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientocinco_Internalname, "TitleCaption", chkavTicketresponsablemantenimientocinco.Caption, true);
         chkavTicketresponsablemantenimientocinco.CheckedValue = "false";
         AV98TicketResponsableMantenimientoCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV98TicketResponsableMantenimientoCinco));
         AssignAttri("", false, "AV98TicketResponsableMantenimientoCinco", AV98TicketResponsableMantenimientoCinco);
         chkavTicketresponsablemantenimientoseis.Name = "vTICKETRESPONSABLEMANTENIMIENTOSEIS";
         chkavTicketresponsablemantenimientoseis.WebTags = "";
         chkavTicketresponsablemantenimientoseis.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientoseis_Internalname, "TitleCaption", chkavTicketresponsablemantenimientoseis.Caption, true);
         chkavTicketresponsablemantenimientoseis.CheckedValue = "false";
         AV99TicketResponsableMantenimientoSeis = StringUtil.StrToBool( StringUtil.BoolToStr( AV99TicketResponsableMantenimientoSeis));
         AssignAttri("", false, "AV99TicketResponsableMantenimientoSeis", AV99TicketResponsableMantenimientoSeis);
         chkavTicketresponsablemantenimientosiete.Name = "vTICKETRESPONSABLEMANTENIMIENTOSIETE";
         chkavTicketresponsablemantenimientosiete.WebTags = "";
         chkavTicketresponsablemantenimientosiete.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientosiete_Internalname, "TitleCaption", chkavTicketresponsablemantenimientosiete.Caption, true);
         chkavTicketresponsablemantenimientosiete.CheckedValue = "false";
         AV101TicketResponsableMantenimientoSiete = StringUtil.StrToBool( StringUtil.BoolToStr( AV101TicketResponsableMantenimientoSiete));
         AssignAttri("", false, "AV101TicketResponsableMantenimientoSiete", AV101TicketResponsableMantenimientoSiete);
         chkavTicketresponsablegestionbduno.Name = "vTICKETRESPONSABLEGESTIONBDUNO";
         chkavTicketresponsablegestionbduno.WebTags = "";
         chkavTicketresponsablegestionbduno.Caption = "";
         AssignProp("", false, chkavTicketresponsablegestionbduno_Internalname, "TitleCaption", chkavTicketresponsablegestionbduno.Caption, true);
         chkavTicketresponsablegestionbduno.CheckedValue = "false";
         AV102TicketResponsableGestionbdUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV102TicketResponsableGestionbdUno));
         AssignAttri("", false, "AV102TicketResponsableGestionbdUno", AV102TicketResponsableGestionbdUno);
         chkavTicketresponsablegestionbddos.Name = "vTICKETRESPONSABLEGESTIONBDDOS";
         chkavTicketresponsablegestionbddos.WebTags = "";
         chkavTicketresponsablegestionbddos.Caption = "";
         AssignProp("", false, chkavTicketresponsablegestionbddos_Internalname, "TitleCaption", chkavTicketresponsablegestionbddos.Caption, true);
         chkavTicketresponsablegestionbddos.CheckedValue = "false";
         AV103TicketResponsableGestionbdDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV103TicketResponsableGestionbdDos));
         AssignAttri("", false, "AV103TicketResponsableGestionbdDos", AV103TicketResponsableGestionbdDos);
         chkavTicketresponsablegestionbdtres.Name = "vTICKETRESPONSABLEGESTIONBDTRES";
         chkavTicketresponsablegestionbdtres.WebTags = "";
         chkavTicketresponsablegestionbdtres.Caption = "";
         AssignProp("", false, chkavTicketresponsablegestionbdtres_Internalname, "TitleCaption", chkavTicketresponsablegestionbdtres.Caption, true);
         chkavTicketresponsablegestionbdtres.CheckedValue = "false";
         AV104TicketResponsableGestionbdTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV104TicketResponsableGestionbdTres));
         AssignAttri("", false, "AV104TicketResponsableGestionbdTres", AV104TicketResponsableGestionbdTres);
         chkavTicketresponsablegestionbdcuatro.Name = "vTICKETRESPONSABLEGESTIONBDCUATRO";
         chkavTicketresponsablegestionbdcuatro.WebTags = "";
         chkavTicketresponsablegestionbdcuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsablegestionbdcuatro_Internalname, "TitleCaption", chkavTicketresponsablegestionbdcuatro.Caption, true);
         chkavTicketresponsablegestionbdcuatro.CheckedValue = "false";
         AV105TicketResponsableGestionbdCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV105TicketResponsableGestionbdCuatro));
         AssignAttri("", false, "AV105TicketResponsableGestionbdCuatro", AV105TicketResponsableGestionbdCuatro);
         chkavTicketresponsablemantenimientobduno.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDUNO";
         chkavTicketresponsablemantenimientobduno.WebTags = "";
         chkavTicketresponsablemantenimientobduno.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobduno_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobduno.Caption, true);
         chkavTicketresponsablemantenimientobduno.CheckedValue = "false";
         AV106TicketResponsableMantenimientobdUno = StringUtil.StrToBool( StringUtil.BoolToStr( AV106TicketResponsableMantenimientobdUno));
         AssignAttri("", false, "AV106TicketResponsableMantenimientobdUno", AV106TicketResponsableMantenimientobdUno);
         chkavTicketresponsablemantenimientobddos.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDDOS";
         chkavTicketresponsablemantenimientobddos.WebTags = "";
         chkavTicketresponsablemantenimientobddos.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobddos_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobddos.Caption, true);
         chkavTicketresponsablemantenimientobddos.CheckedValue = "false";
         AV107TicketResponsableMantenimientobdDos = StringUtil.StrToBool( StringUtil.BoolToStr( AV107TicketResponsableMantenimientobdDos));
         AssignAttri("", false, "AV107TicketResponsableMantenimientobdDos", AV107TicketResponsableMantenimientobdDos);
         chkavTicketresponsablemantenimientobdtres.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDTRES";
         chkavTicketresponsablemantenimientobdtres.WebTags = "";
         chkavTicketresponsablemantenimientobdtres.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobdtres_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobdtres.Caption, true);
         chkavTicketresponsablemantenimientobdtres.CheckedValue = "false";
         AV108TicketResponsableMantenimientobdTres = StringUtil.StrToBool( StringUtil.BoolToStr( AV108TicketResponsableMantenimientobdTres));
         AssignAttri("", false, "AV108TicketResponsableMantenimientobdTres", AV108TicketResponsableMantenimientobdTres);
         chkavTicketresponsablemantenimientobdcuatro.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO";
         chkavTicketresponsablemantenimientobdcuatro.WebTags = "";
         chkavTicketresponsablemantenimientobdcuatro.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobdcuatro_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobdcuatro.Caption, true);
         chkavTicketresponsablemantenimientobdcuatro.CheckedValue = "false";
         AV109TicketResponsableMantenimientobdCuatro = StringUtil.StrToBool( StringUtil.BoolToStr( AV109TicketResponsableMantenimientobdCuatro));
         AssignAttri("", false, "AV109TicketResponsableMantenimientobdCuatro", AV109TicketResponsableMantenimientobdCuatro);
         chkavTicketresponsablemantenimientobdcinco.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDCINCO";
         chkavTicketresponsablemantenimientobdcinco.WebTags = "";
         chkavTicketresponsablemantenimientobdcinco.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobdcinco_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobdcinco.Caption, true);
         chkavTicketresponsablemantenimientobdcinco.CheckedValue = "false";
         AV111TicketResponsableMantenimientobdCinco = StringUtil.StrToBool( StringUtil.BoolToStr( AV111TicketResponsableMantenimientobdCinco));
         AssignAttri("", false, "AV111TicketResponsableMantenimientobdCinco", AV111TicketResponsableMantenimientobdCinco);
         chkavTicketresponsablemantenimientobdseis.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDSEIS";
         chkavTicketresponsablemantenimientobdseis.WebTags = "";
         chkavTicketresponsablemantenimientobdseis.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobdseis_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobdseis.Caption, true);
         chkavTicketresponsablemantenimientobdseis.CheckedValue = "false";
         AV112TicketResponsableMantenimientobdSeis = StringUtil.StrToBool( StringUtil.BoolToStr( AV112TicketResponsableMantenimientobdSeis));
         AssignAttri("", false, "AV112TicketResponsableMantenimientobdSeis", AV112TicketResponsableMantenimientobdSeis);
         chkavTicketresponsablemantenimientobdsiete.Name = "vTICKETRESPONSABLEMANTENIMIENTOBDSIETE";
         chkavTicketresponsablemantenimientobdsiete.WebTags = "";
         chkavTicketresponsablemantenimientobdsiete.Caption = "";
         AssignProp("", false, chkavTicketresponsablemantenimientobdsiete_Internalname, "TitleCaption", chkavTicketresponsablemantenimientobdsiete.Caption, true);
         chkavTicketresponsablemantenimientobdsiete.CheckedValue = "false";
         AV113TicketResponsableMantenimientobdSiete = StringUtil.StrToBool( StringUtil.BoolToStr( AV113TicketResponsableMantenimientobdSiete));
         AssignAttri("", false, "AV113TicketResponsableMantenimientobdSiete", AV113TicketResponsableMantenimientobdSiete);
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
            AV14prioridad = cmbavPrioridad.getValidValue(AV14prioridad);
            AssignAttri("", false, "AV14prioridad", AV14prioridad);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divTable26_Internalname = "TABLE26";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtavUsuariodepartamento_Internalname = "vUSUARIODEPARTAMENTO";
         divTable27_Internalname = "TABLE27";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtavUsuariorequerimiento_Internalname = "vUSUARIOREQUERIMIENTO";
         divTable28_Internalname = "TABLE28";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         dynavEstadoticketticketid_Internalname = "vESTADOTICKETTICKETID";
         divTable19_Internalname = "TABLE19";
         divTable25_Internalname = "TABLE25";
         lblTabpage1_title_Internalname = "TABPAGE1_TITLE";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         chkavTicketresponsableanalasisuno_Internalname = "vTICKETRESPONSABLEANALASISUNO";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         chkavTicketresponsableanalasisdos_Internalname = "vTICKETRESPONSABLEANALASISDOS";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         chkavTicketresponsableanalasistres_Internalname = "vTICKETRESPONSABLEANALASISTRES";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         chkavTicketresponsableanalasiscuatro_Internalname = "vTICKETRESPONSABLEANALASISCUATRO";
         divTable22_Internalname = "TABLE22";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         chkavTicketresponsablediseniouno_Internalname = "vTICKETRESPONSABLEDISENIOUNO";
         divTable23_Internalname = "TABLE23";
         divTable21_Internalname = "TABLE21";
         divTabpage1table_Internalname = "TABPAGE1TABLE";
         lblTabpage2_title_Internalname = "TABPAGE2_TITLE";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         chkavTicketresponsabledesarrollouno_Internalname = "vTICKETRESPONSABLEDESARROLLOUNO";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         chkavTicketresponsabledesarrollodos_Internalname = "vTICKETRESPONSABLEDESARROLLODOS";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         chkavTicketresponsabledesarrollotres_Internalname = "vTICKETRESPONSABLEDESARROLLOTRES";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         chkavTicketresponsabledesarrollocuatro_Internalname = "vTICKETRESPONSABLEDESARROLLOCUATRO";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         chkavTicketresponsabledesarrollocinco_Internalname = "vTICKETRESPONSABLEDESARROLLOCINCO";
         divTable24_Internalname = "TABLE24";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         chkavTicketresponsablepruebasuno_Internalname = "vTICKETRESPONSABLEPRUEBASUNO";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         chkavTicketresponsablepruebasdos_Internalname = "vTICKETRESPONSABLEPRUEBASDOS";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         chkavTicketresponsablepruebastres_Internalname = "vTICKETRESPONSABLEPRUEBASTRES";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         chkavTicketresponsablepruebascuatro_Internalname = "vTICKETRESPONSABLEPRUEBASCUATRO";
         divTable38_Internalname = "TABLE38";
         divTable4_Internalname = "TABLE4";
         divTabpage2table_Internalname = "TABPAGE2TABLE";
         lblTabpage3_title_Internalname = "TABPAGE3_TITLE";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         chkavTicketresponsabledocumentacionuno_Internalname = "vTICKETRESPONSABLEDOCUMENTACIONUNO";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         chkavTicketresponsabledocumentaciondos_Internalname = "vTICKETRESPONSABLEDOCUMENTACIONDOS";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         chkavTicketresponsabledocumentaciontres_Internalname = "vTICKETRESPONSABLEDOCUMENTACIONTRES";
         lblTextblock47_Internalname = "TEXTBLOCK47";
         chkavTicketresponsabledocumentacioncuatro_Internalname = "vTICKETRESPONSABLEDOCUMENTACIONCUATRO";
         divTable30_Internalname = "TABLE30";
         lblTextblock48_Internalname = "TEXTBLOCK48";
         lblTextblock49_Internalname = "TEXTBLOCK49";
         chkavTicketresponsableimplementacionuno_Internalname = "vTICKETRESPONSABLEIMPLEMENTACIONUNO";
         lblTextblock50_Internalname = "TEXTBLOCK50";
         chkavTicketresponsableimplementaciondos_Internalname = "vTICKETRESPONSABLEIMPLEMENTACIONDOS";
         lblTextblock51_Internalname = "TEXTBLOCK51";
         chkavTicketresponsableimplementaciontres_Internalname = "vTICKETRESPONSABLEIMPLEMENTACIONTRES";
         lblTextblock52_Internalname = "TEXTBLOCK52";
         chkavTicketresponsableimplementacioncuatro_Internalname = "vTICKETRESPONSABLEIMPLEMENTACIONCUATRO";
         lblTextblock53_Internalname = "TEXTBLOCK53";
         chkavTicketresponsableimplementacioncinco_Internalname = "vTICKETRESPONSABLEIMPLEMENTACIONCINCO";
         lblTextblock54_Internalname = "TEXTBLOCK54";
         chkavTicketresponsableimplementacionseis_Internalname = "vTICKETRESPONSABLEIMPLEMENTACIONSEIS";
         divTable39_Internalname = "TABLE39";
         divTable8_Internalname = "TABLE8";
         divTabpage3table_Internalname = "TABPAGE3TABLE";
         lblTabpage4_title_Internalname = "TABPAGE4_TITLE";
         lblTextblock55_Internalname = "TEXTBLOCK55";
         lblTextblock56_Internalname = "TEXTBLOCK56";
         chkavTicketresponsablemantenimientouno_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOUNO";
         lblTextblock57_Internalname = "TEXTBLOCK57";
         chkavTicketresponsablemantenimientodos_Internalname = "vTICKETRESPONSABLEMANTENIMIENTODOS";
         lblTextblock58_Internalname = "TEXTBLOCK58";
         chkavTicketresponsablemantenimientotres_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOTRES";
         lblTextblock62_Internalname = "TEXTBLOCK62";
         chkavTicketresponsablemantenimientocuatro_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOCUATRO";
         divTable31_Internalname = "TABLE31";
         lblTextblock61_Internalname = "TEXTBLOCK61";
         chkavTicketresponsablemantenimientocinco_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOCINCO";
         lblTextblock60_Internalname = "TEXTBLOCK60";
         chkavTicketresponsablemantenimientoseis_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOSEIS";
         lblTextblock59_Internalname = "TEXTBLOCK59";
         chkavTicketresponsablemantenimientosiete_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOSIETE";
         divTable34_Internalname = "TABLE34";
         divTable9_Internalname = "TABLE9";
         divTabpage4table_Internalname = "TABPAGE4TABLE";
         lblTabpage5_title_Internalname = "TABPAGE5_TITLE";
         lblTextblock63_Internalname = "TEXTBLOCK63";
         lblTextblock65_Internalname = "TEXTBLOCK65";
         lblTextblock67_Internalname = "TEXTBLOCK67";
         chkavTicketresponsablegestionbduno_Internalname = "vTICKETRESPONSABLEGESTIONBDUNO";
         lblTextblock68_Internalname = "TEXTBLOCK68";
         chkavTicketresponsablegestionbddos_Internalname = "vTICKETRESPONSABLEGESTIONBDDOS";
         lblTextblock66_Internalname = "TEXTBLOCK66";
         chkavTicketresponsablegestionbdtres_Internalname = "vTICKETRESPONSABLEGESTIONBDTRES";
         lblTextblock64_Internalname = "TEXTBLOCK64";
         chkavTicketresponsablegestionbdcuatro_Internalname = "vTICKETRESPONSABLEGESTIONBDCUATRO";
         divTable33_Internalname = "TABLE33";
         lblTextblock69_Internalname = "TEXTBLOCK69";
         lblTextblock72_Internalname = "TEXTBLOCK72";
         chkavTicketresponsablemantenimientobduno_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDUNO";
         lblTextblock76_Internalname = "TEXTBLOCK76";
         chkavTicketresponsablemantenimientobddos_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDDOS";
         lblTextblock77_Internalname = "TEXTBLOCK77";
         chkavTicketresponsablemantenimientobdtres_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDTRES";
         lblTextblock74_Internalname = "TEXTBLOCK74";
         chkavTicketresponsablemantenimientobdcuatro_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO";
         lblTextblock75_Internalname = "TEXTBLOCK75";
         chkavTicketresponsablemantenimientobdcinco_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDCINCO";
         lblTextblock73_Internalname = "TEXTBLOCK73";
         chkavTicketresponsablemantenimientobdseis_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDSEIS";
         lblTextblock71_Internalname = "TEXTBLOCK71";
         chkavTicketresponsablemantenimientobdsiete_Internalname = "vTICKETRESPONSABLEMANTENIMIENTOBDSIETE";
         divTable40_Internalname = "TABLE40";
         divTable32_Internalname = "TABLE32";
         divTabpage5table_Internalname = "TABPAGE5TABLE";
         lblTabpage6_title_Internalname = "TABPAGE6_TITLE";
         dynavDetalle_infotecid_unidad_Internalname = "vDETALLE_INFOTECID_UNIDAD";
         edtavEtapadesarrolloid_Internalname = "vETAPADESARROLLOID";
         divTable1_Internalname = "TABLE1";
         divTabpage6table_Internalname = "TABPAGE6TABLE";
         Tab1_Internalname = "TAB1";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtavTicketresponsableobservacion_Internalname = "vTICKETRESPONSABLEOBSERVACION";
         divTable7_Internalname = "TABLE7";
         divTable2_Internalname = "TABLE2";
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
         chkavTicketresponsablemantenimientobdsiete.Caption = "";
         chkavTicketresponsablemantenimientobdseis.Caption = "";
         chkavTicketresponsablemantenimientobdcinco.Caption = "";
         chkavTicketresponsablemantenimientobdcuatro.Caption = "";
         chkavTicketresponsablemantenimientobdtres.Caption = "";
         chkavTicketresponsablemantenimientobddos.Caption = "";
         chkavTicketresponsablemantenimientobduno.Caption = "";
         chkavTicketresponsablegestionbdcuatro.Caption = "";
         chkavTicketresponsablegestionbdtres.Caption = "";
         chkavTicketresponsablegestionbddos.Caption = "";
         chkavTicketresponsablegestionbduno.Caption = "";
         chkavTicketresponsablemantenimientosiete.Caption = "";
         chkavTicketresponsablemantenimientoseis.Caption = "";
         chkavTicketresponsablemantenimientocinco.Caption = "";
         chkavTicketresponsablemantenimientocuatro.Caption = "";
         chkavTicketresponsablemantenimientotres.Caption = "";
         chkavTicketresponsablemantenimientodos.Caption = "";
         chkavTicketresponsablemantenimientouno.Caption = "";
         chkavTicketresponsableimplementacionseis.Caption = "";
         chkavTicketresponsableimplementacioncinco.Caption = "";
         chkavTicketresponsableimplementacioncuatro.Caption = "";
         chkavTicketresponsableimplementaciontres.Caption = "";
         chkavTicketresponsableimplementaciondos.Caption = "";
         chkavTicketresponsableimplementacionuno.Caption = "";
         chkavTicketresponsabledocumentacioncuatro.Caption = "";
         chkavTicketresponsabledocumentaciontres.Caption = "";
         chkavTicketresponsabledocumentaciondos.Caption = "";
         chkavTicketresponsabledocumentacionuno.Caption = "";
         chkavTicketresponsablepruebascuatro.Caption = "";
         chkavTicketresponsablepruebastres.Caption = "";
         chkavTicketresponsablepruebasdos.Caption = "";
         chkavTicketresponsablepruebasuno.Caption = "";
         chkavTicketresponsabledesarrollocinco.Caption = "";
         chkavTicketresponsabledesarrollocuatro.Caption = "";
         chkavTicketresponsabledesarrollotres.Caption = "";
         chkavTicketresponsabledesarrollodos.Caption = "";
         chkavTicketresponsabledesarrollouno.Caption = "";
         chkavTicketresponsablediseniouno.Caption = "";
         chkavTicketresponsableanalasiscuatro.Caption = "";
         chkavTicketresponsableanalasistres.Caption = "";
         chkavTicketresponsableanalasisdos.Caption = "";
         chkavTicketresponsableanalasisuno.Caption = "";
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
         edtavEtapadesarrolloid_Jsonclick = "";
         edtavEtapadesarrolloid_Enabled = 0;
         dynavDetalle_infotecid_unidad_Jsonclick = "";
         dynavDetalle_infotecid_unidad.Enabled = 1;
         chkavTicketresponsablemantenimientobdsiete.Enabled = 1;
         lblTextblock71_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientobdseis.Enabled = 1;
         lblTextblock73_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientobdcinco.Enabled = 1;
         lblTextblock75_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientobdcuatro.Enabled = 1;
         lblTextblock74_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientobdtres.Enabled = 1;
         lblTextblock77_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientobddos.Enabled = 1;
         lblTextblock76_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientobduno.Enabled = 1;
         lblTextblock72_Forecolor = (int)(0x000000);
         lblTextblock69_Forecolor = (int)(0x000000);
         lblTextblock69_Fontbold = 0;
         chkavTicketresponsablegestionbdcuatro.Enabled = 1;
         lblTextblock64_Forecolor = (int)(0x000000);
         chkavTicketresponsablegestionbdtres.Enabled = 1;
         lblTextblock66_Forecolor = (int)(0x000000);
         chkavTicketresponsablegestionbddos.Enabled = 1;
         lblTextblock68_Forecolor = (int)(0x000000);
         chkavTicketresponsablegestionbduno.Enabled = 1;
         lblTextblock67_Forecolor = (int)(0x000000);
         lblTextblock65_Forecolor = (int)(0x000000);
         lblTextblock65_Fontbold = 0;
         lblTextblock63_Forecolor = (int)(0x000000);
         lblTextblock63_Fontbold = 0;
         chkavTicketresponsablemantenimientosiete.Enabled = 1;
         lblTextblock59_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientoseis.Enabled = 1;
         lblTextblock60_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientocinco.Enabled = 1;
         lblTextblock61_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientocuatro.Enabled = 1;
         lblTextblock62_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientotres.Enabled = 1;
         lblTextblock58_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientodos.Enabled = 1;
         lblTextblock57_Forecolor = (int)(0x000000);
         chkavTicketresponsablemantenimientouno.Enabled = 1;
         lblTextblock56_Forecolor = (int)(0x000000);
         lblTextblock55_Forecolor = (int)(0x000000);
         lblTextblock55_Fontbold = 0;
         chkavTicketresponsableimplementacionseis.Enabled = 1;
         lblTextblock54_Forecolor = (int)(0x000000);
         chkavTicketresponsableimplementacioncinco.Enabled = 1;
         lblTextblock53_Forecolor = (int)(0x000000);
         chkavTicketresponsableimplementacioncuatro.Enabled = 1;
         lblTextblock52_Forecolor = (int)(0x000000);
         chkavTicketresponsableimplementaciontres.Enabled = 1;
         lblTextblock51_Forecolor = (int)(0x000000);
         chkavTicketresponsableimplementaciondos.Enabled = 1;
         lblTextblock50_Forecolor = (int)(0x000000);
         chkavTicketresponsableimplementacionuno.Enabled = 1;
         lblTextblock49_Forecolor = (int)(0x000000);
         lblTextblock48_Forecolor = (int)(0x000000);
         lblTextblock48_Fontbold = 0;
         chkavTicketresponsabledocumentacioncuatro.Enabled = 1;
         lblTextblock47_Forecolor = (int)(0x000000);
         chkavTicketresponsabledocumentaciontres.Enabled = 1;
         lblTextblock46_Forecolor = (int)(0x000000);
         chkavTicketresponsabledocumentaciondos.Enabled = 1;
         lblTextblock45_Forecolor = (int)(0x000000);
         chkavTicketresponsabledocumentacionuno.Enabled = 1;
         lblTextblock44_Forecolor = (int)(0x000000);
         lblTextblock43_Forecolor = (int)(0x000000);
         lblTextblock43_Fontbold = 0;
         chkavTicketresponsablepruebascuatro.Enabled = 1;
         lblTextblock42_Forecolor = (int)(0x000000);
         chkavTicketresponsablepruebastres.Enabled = 1;
         lblTextblock41_Forecolor = (int)(0x000000);
         chkavTicketresponsablepruebasdos.Enabled = 1;
         lblTextblock40_Forecolor = (int)(0x000000);
         chkavTicketresponsablepruebasuno.Enabled = 1;
         lblTextblock39_Forecolor = (int)(0x000000);
         lblTextblock38_Forecolor = (int)(0x000000);
         lblTextblock38_Fontbold = 0;
         chkavTicketresponsabledesarrollocinco.Enabled = 1;
         lblTextblock37_Forecolor = (int)(0x000000);
         chkavTicketresponsabledesarrollocuatro.Enabled = 1;
         lblTextblock36_Forecolor = (int)(0x000000);
         chkavTicketresponsabledesarrollotres.Enabled = 1;
         lblTextblock10_Forecolor = (int)(0x000000);
         chkavTicketresponsabledesarrollodos.Enabled = 1;
         lblTextblock13_Forecolor = (int)(0x000000);
         chkavTicketresponsabledesarrollouno.Enabled = 1;
         lblTextblock12_Forecolor = (int)(0x000000);
         lblTextblock11_Forecolor = (int)(0x000000);
         lblTextblock11_Fontbold = 0;
         chkavTicketresponsablediseniouno.Enabled = 1;
         lblTextblock9_Forecolor = (int)(0x000000);
         lblTextblock8_Forecolor = (int)(0x000000);
         lblTextblock8_Fontbold = 0;
         chkavTicketresponsableanalasiscuatro.Enabled = 1;
         lblTextblock35_Forecolor = (int)(0x000000);
         chkavTicketresponsableanalasistres.Enabled = 1;
         lblTextblock16_Forecolor = (int)(0x000000);
         chkavTicketresponsableanalasisdos.Enabled = 1;
         lblTextblock7_Forecolor = (int)(0x000000);
         chkavTicketresponsableanalasisuno.Enabled = 1;
         lblTextblock6_Forecolor = (int)(0x000000);
         lblTextblock5_Forecolor = (int)(0x000000);
         lblTextblock5_Fontbold = 0;
         dynavEstadoticketticketid_Jsonclick = "";
         dynavEstadoticketticketid.Enabled = 1;
         dynavEstadoticketticketid.ForeColor = (int)(0x000000);
         edtavUsuariorequerimiento_Forecolor = (int)(0x000000);
         edtavUsuariorequerimiento_Enabled = 0;
         edtavUsuariodepartamento_Forecolor = (int)(0x000000);
         edtavUsuariodepartamento_Enabled = 0;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Forecolor = (int)(0x000000);
         edtavUsuarionombre_Enabled = 0;
         dynavDetalle_infotecid_unidad.Description = "";
         dynavCategoriadetalletareaid.Description = "";
         cmbavPrioridad.Description = "";
         dynavId_actividad_categoria.Description = "";
         dynavCategoria_tareaid_tipo_categoria.Description = "";
         dynavEstadoticketticketid.Description = "";
         Tab1_Historymanagement = Convert.ToBoolean( 0);
         Tab1_Class = "Tab";
         Tab1_Pagecount = 6;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Trabajo Departamento de Desarrollo";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public void Validv_Categoria_tareaid_tipo_categoria( )
      {
         AV11EstadoTicketTicketId = (short)(NumberUtil.Val( dynavEstadoticketticketid.CurrentValue, "."));
         AV5categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.CurrentValue, "."));
         AV6detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.CurrentValue, "."));
         AV12id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.CurrentValue, "."));
         AV114CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.CurrentValue, "."));
         GXVvDETALLE_INFOTECID_UNIDAD_html7E2( AV5categoria_tareaid_tipo_categoria) ;
         GXVvID_ACTIVIDAD_CATEGORIA_html7E2( AV5categoria_tareaid_tipo_categoria) ;
         dynload_actions( ) ;
         if ( dynavDetalle_infotecid_unidad.ItemCount > 0 )
         {
            AV6detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0));
         }
         if ( dynavId_actividad_categoria.ItemCount > 0 )
         {
            AV12id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV6detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6detalle_infotecid_unidad), 9, 0, ".", "")));
         dynavDetalle_infotecid_unidad.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV6detalle_infotecid_unidad), 9, 0));
         AssignProp("", false, dynavDetalle_infotecid_unidad_Internalname, "Values", dynavDetalle_infotecid_unidad.ToJavascriptSource(), true);
         AssignAttri("", false, "AV12id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12id_actividad_categoria), 9, 0, ".", "")));
         dynavId_actividad_categoria.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12id_actividad_categoria), 9, 0));
         AssignProp("", false, dynavId_actividad_categoria_Internalname, "Values", dynavId_actividad_categoria.ToJavascriptSource(), true);
      }

      public void Validv_Id_actividad_categoria( )
      {
         AV11EstadoTicketTicketId = (short)(NumberUtil.Val( dynavEstadoticketticketid.CurrentValue, "."));
         AV5categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( dynavCategoria_tareaid_tipo_categoria.CurrentValue, "."));
         AV6detalle_infotecid_unidad = (int)(NumberUtil.Val( dynavDetalle_infotecid_unidad.CurrentValue, "."));
         AV12id_actividad_categoria = (int)(NumberUtil.Val( dynavId_actividad_categoria.CurrentValue, "."));
         AV114CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.CurrentValue, "."));
         GXVvCATEGORIADETALLETAREAID_html7E2( AV12id_actividad_categoria) ;
         dynload_actions( ) ;
         if ( dynavCategoriadetalletareaid.ItemCount > 0 )
         {
            AV114CategoriaDetalleTareaId = (short)(NumberUtil.Val( dynavCategoriadetalletareaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0))), "."));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "AV114CategoriaDetalleTareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV114CategoriaDetalleTareaId), 4, 0, ".", "")));
         dynavCategoriadetalletareaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV114CategoriaDetalleTareaId), 4, 0));
         AssignProp("", false, dynavCategoriadetalletareaid_Internalname, "Values", dynavCategoriadetalletareaid.ToJavascriptSource(), true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:'',hsh:true},{av:'AV16TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV56UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV30TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV52TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV54UsuarioEmail',fld:'vUSUARIOEMAIL',pic:'',hsh:true},{av:'AV55UsuarioFecha',fld:'vUSUARIOFECHA',pic:'',hsh:true},{av:'AV57UsuarioNombre',fld:'vUSUARIONOMBRE',pic:'',hsh:true},{av:'AV53UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:'',hsh:true},{av:'AV60EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
         setEventMetadata("'GUARDAR'","{handler:'E117E2',iparms:[{av:'AV59TicketResponsablePasaTaller2',fld:'vTICKETRESPONSABLEPASATALLER2',pic:'',hsh:true},{av:'cmbavPrioridad'},{av:'AV37TicketResponsableObservacion',fld:'vTICKETRESPONSABLEOBSERVACION',pic:''},{av:'AV16TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV56UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV30TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV52TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV57UsuarioNombre',fld:'vUSUARIONOMBRE',pic:'',hsh:true},{av:'AV53UsuarioDepartamento',fld:'vUSUARIODEPARTAMENTO',pic:'',hsh:true},{av:'AV54UsuarioEmail',fld:'vUSUARIOEMAIL',pic:'',hsh:true},{av:'AV55UsuarioFecha',fld:'vUSUARIOFECHA',pic:'',hsh:true},{av:'AV60EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9',hsh:true},{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
         setEventMetadata("'CANCELAR'","{handler:'E127E2',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
         setEventMetadata("'PRUEBA'","{handler:'E137E2',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("'PRUEBA'",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
         setEventMetadata("VCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK","{handler:'E147E2',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("VCATEGORIA_TAREAID_TIPO_CATEGORIA.CLICK",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA","{handler:'Validv_Categoria_tareaid_tipo_categoria',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("VALIDV_CATEGORIA_TAREAID_TIPO_CATEGORIA",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
         setEventMetadata("VALIDV_ID_ACTIVIDAD_CATEGORIA","{handler:'Validv_Id_actividad_categoria',iparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]");
         setEventMetadata("VALIDV_ID_ACTIVIDAD_CATEGORIA",",oparms:[{av:'dynavEstadoticketticketid'},{av:'AV11EstadoTicketTicketId',fld:'vESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'dynavCategoria_tareaid_tipo_categoria'},{av:'AV5categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavDetalle_infotecid_unidad'},{av:'AV6detalle_infotecid_unidad',fld:'vDETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'dynavId_actividad_categoria'},{av:'AV12id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'dynavCategoriadetalletareaid'},{av:'AV114CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'AV62TicketResponsableAnalasisUno',fld:'vTICKETRESPONSABLEANALASISUNO',pic:''},{av:'AV64TicketResponsableAnalasisDos',fld:'vTICKETRESPONSABLEANALASISDOS',pic:''},{av:'AV65TicketResponsableAnalasisTres',fld:'vTICKETRESPONSABLEANALASISTRES',pic:''},{av:'AV66TicketResponsableAnalasisCuatro',fld:'vTICKETRESPONSABLEANALASISCUATRO',pic:''},{av:'AV67TicketResponsableDisenioUno',fld:'vTICKETRESPONSABLEDISENIOUNO',pic:''},{av:'AV68TicketResponsableDesarrolloUno',fld:'vTICKETRESPONSABLEDESARROLLOUNO',pic:''},{av:'AV70TicketResponsableDesarrolloDos',fld:'vTICKETRESPONSABLEDESARROLLODOS',pic:''},{av:'AV71TicketResponsableDesarrolloTres',fld:'vTICKETRESPONSABLEDESARROLLOTRES',pic:''},{av:'AV72TicketResponsableDesarrolloCuatro',fld:'vTICKETRESPONSABLEDESARROLLOCUATRO',pic:''},{av:'AV73TicketResponsableDesarrolloCinco',fld:'vTICKETRESPONSABLEDESARROLLOCINCO',pic:''},{av:'AV74TicketResponsablePruebasUno',fld:'vTICKETRESPONSABLEPRUEBASUNO',pic:''},{av:'AV76TicketResponsablePruebasDos',fld:'vTICKETRESPONSABLEPRUEBASDOS',pic:''},{av:'AV77TicketResponsablePruebasTres',fld:'vTICKETRESPONSABLEPRUEBASTRES',pic:''},{av:'AV78TicketResponsablePruebasCuatro',fld:'vTICKETRESPONSABLEPRUEBASCUATRO',pic:''},{av:'AV80TicketResponsableDocumentacionUno',fld:'vTICKETRESPONSABLEDOCUMENTACIONUNO',pic:''},{av:'AV81TicketResponsableDocumentacionDos',fld:'vTICKETRESPONSABLEDOCUMENTACIONDOS',pic:''},{av:'AV82TicketResponsableDocumentacionTres',fld:'vTICKETRESPONSABLEDOCUMENTACIONTRES',pic:''},{av:'AV83TicketResponsableDocumentacionCuatro',fld:'vTICKETRESPONSABLEDOCUMENTACIONCUATRO',pic:''},{av:'AV84TicketResponsableImplementacionUno',fld:'vTICKETRESPONSABLEIMPLEMENTACIONUNO',pic:''},{av:'AV87TicketResponsableImplementacionDos',fld:'vTICKETRESPONSABLEIMPLEMENTACIONDOS',pic:''},{av:'AV88TicketResponsableImplementacionTres',fld:'vTICKETRESPONSABLEIMPLEMENTACIONTRES',pic:''},{av:'AV89TicketResponsableImplementacionCuatro',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCUATRO',pic:''},{av:'AV90TicketResponsableImplementacionCinco',fld:'vTICKETRESPONSABLEIMPLEMENTACIONCINCO',pic:''},{av:'AV91TicketResponsableImplementacionSeis',fld:'vTICKETRESPONSABLEIMPLEMENTACIONSEIS',pic:''},{av:'AV93TicketResponsableMantenimientoUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOUNO',pic:''},{av:'AV94TicketResponsableMantenimientoDos',fld:'vTICKETRESPONSABLEMANTENIMIENTODOS',pic:''},{av:'AV95TicketResponsableMantenimientoTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOTRES',pic:''},{av:'AV96TicketResponsableMantenimientoCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOCUATRO',pic:''},{av:'AV98TicketResponsableMantenimientoCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOCINCO',pic:''},{av:'AV99TicketResponsableMantenimientoSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOSEIS',pic:''},{av:'AV101TicketResponsableMantenimientoSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOSIETE',pic:''},{av:'AV102TicketResponsableGestionbdUno',fld:'vTICKETRESPONSABLEGESTIONBDUNO',pic:''},{av:'AV103TicketResponsableGestionbdDos',fld:'vTICKETRESPONSABLEGESTIONBDDOS',pic:''},{av:'AV104TicketResponsableGestionbdTres',fld:'vTICKETRESPONSABLEGESTIONBDTRES',pic:''},{av:'AV105TicketResponsableGestionbdCuatro',fld:'vTICKETRESPONSABLEGESTIONBDCUATRO',pic:''},{av:'AV106TicketResponsableMantenimientobdUno',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDUNO',pic:''},{av:'AV107TicketResponsableMantenimientobdDos',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDDOS',pic:''},{av:'AV108TicketResponsableMantenimientobdTres',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDTRES',pic:''},{av:'AV109TicketResponsableMantenimientobdCuatro',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCUATRO',pic:''},{av:'AV111TicketResponsableMantenimientobdCinco',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDCINCO',pic:''},{av:'AV112TicketResponsableMantenimientobdSeis',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSEIS',pic:''},{av:'AV113TicketResponsableMantenimientobdSiete',fld:'vTICKETRESPONSABLEMANTENIMIENTOBDSIETE',pic:''}]}");
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
         wcpOAV54UsuarioEmail = "";
         wcpOAV55UsuarioFecha = DateTime.MinValue;
         wcpOAV57UsuarioNombre = "";
         wcpOAV53UsuarioDepartamento = "";
         wcpOAV58UsuarioRequerimiento = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock32_Jsonclick = "";
         lblTextblock33_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         TempTags = "";
         ucTab1 = new GXUserControl();
         lblTabpage1_title_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTabpage2_title_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
         lblTextblock37_Jsonclick = "";
         lblTextblock38_Jsonclick = "";
         lblTextblock39_Jsonclick = "";
         lblTextblock40_Jsonclick = "";
         lblTextblock41_Jsonclick = "";
         lblTextblock42_Jsonclick = "";
         lblTabpage3_title_Jsonclick = "";
         lblTextblock43_Jsonclick = "";
         lblTextblock44_Jsonclick = "";
         lblTextblock45_Jsonclick = "";
         lblTextblock46_Jsonclick = "";
         lblTextblock47_Jsonclick = "";
         lblTextblock48_Jsonclick = "";
         lblTextblock49_Jsonclick = "";
         lblTextblock50_Jsonclick = "";
         lblTextblock51_Jsonclick = "";
         lblTextblock52_Jsonclick = "";
         lblTextblock53_Jsonclick = "";
         lblTextblock54_Jsonclick = "";
         lblTabpage4_title_Jsonclick = "";
         lblTextblock55_Jsonclick = "";
         lblTextblock56_Jsonclick = "";
         lblTextblock57_Jsonclick = "";
         lblTextblock58_Jsonclick = "";
         lblTextblock62_Jsonclick = "";
         lblTextblock61_Jsonclick = "";
         lblTextblock60_Jsonclick = "";
         lblTextblock59_Jsonclick = "";
         lblTabpage5_title_Jsonclick = "";
         lblTextblock63_Jsonclick = "";
         lblTextblock65_Jsonclick = "";
         lblTextblock67_Jsonclick = "";
         lblTextblock68_Jsonclick = "";
         lblTextblock66_Jsonclick = "";
         lblTextblock64_Jsonclick = "";
         lblTextblock69_Jsonclick = "";
         lblTextblock72_Jsonclick = "";
         lblTextblock76_Jsonclick = "";
         lblTextblock77_Jsonclick = "";
         lblTextblock74_Jsonclick = "";
         lblTextblock75_Jsonclick = "";
         lblTextblock73_Jsonclick = "";
         lblTextblock71_Jsonclick = "";
         lblTabpage6_title_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         AV37TicketResponsableObservacion = "";
         AV14prioridad = "";
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
         H007E2_A5EstadoTicketId = new short[1] ;
         H007E2_A24EstadoTicketNombre = new string[] {""} ;
         H007E3_A105id_unidad_gis = new int[1] ;
         H007E3_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H007E4_A104categoria_tareaid_tipo_categoria = new int[1] ;
         H007E4_A106nombre_categoria = new string[] {""} ;
         H007E4_n106nombre_categoria = new bool[] {false} ;
         H007E4_A105id_unidad_gis = new int[1] ;
         AV115WebSession = context.GetSession();
         H007E5_A102id_actividad_categoria = new int[1] ;
         H007E5_A123nombre_actividad = new string[] {""} ;
         H007E5_n123nombre_actividad = new bool[] {false} ;
         H007E5_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         H007E5_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         H007E5_A125actividades_categoriaestado = new int[1] ;
         H007E5_n125actividades_categoriaestado = new bool[] {false} ;
         H007E6_A294CategoriaDetalleTareaId = new short[1] ;
         H007E6_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         H007E6_A102id_actividad_categoria = new int[1] ;
         AV7detalle_tarea = "";
         AV61window = new GXWindow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpdesarrollosoftware__default(),
            new Object[][] {
                new Object[] {
               H007E2_A5EstadoTicketId, H007E2_A24EstadoTicketNombre
               }
               , new Object[] {
               H007E6_A294CategoriaDetalleTareaId, H007E6_A295CategoriaDetalleTareaNombre, H007E6_A102id_actividad_categoria
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.wpdesarrollosoftware__datastore1(),
            new Object[][] {
                new Object[] {
               H007E3_A105id_unidad_gis, H007E3_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               H007E4_A104categoria_tareaid_tipo_categoria, H007E4_A106nombre_categoria, H007E4_n106nombre_categoria, H007E4_A105id_unidad_gis
               }
               , new Object[] {
               H007E5_A102id_actividad_categoria, H007E5_A123nombre_actividad, H007E5_n123nombre_actividad, H007E5_A122actividades_categoriaid_tipo_categoria, H007E5_n122actividades_categoriaid_tipo_categoria, H007E5_A125actividades_categoriaestado, H007E5_n125actividades_categoriaestado
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         dynavDetalle_infotecid_unidad.Enabled = 0;
         edtavEtapadesarrolloid_Enabled = 0;
      }

      private short AV52TicketTecnicoResponsableId ;
      private short AV60EtapaDesarrolloId ;
      private short wcpOAV52TicketTecnicoResponsableId ;
      private short wcpOAV60EtapaDesarrolloId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV11EstadoTicketTicketId ;
      private short lblTextblock5_Fontbold ;
      private short lblTextblock8_Fontbold ;
      private short lblTextblock11_Fontbold ;
      private short lblTextblock38_Fontbold ;
      private short lblTextblock43_Fontbold ;
      private short lblTextblock48_Fontbold ;
      private short lblTextblock55_Fontbold ;
      private short lblTextblock63_Fontbold ;
      private short lblTextblock65_Fontbold ;
      private short lblTextblock69_Fontbold ;
      private short AV114CategoriaDetalleTareaId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short ZV114CategoriaDetalleTareaId ;
      private int AV5categoria_tareaid_tipo_categoria ;
      private int AV12id_actividad_categoria ;
      private int Tab1_Pagecount ;
      private int edtavUsuarionombre_Forecolor ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavUsuariodepartamento_Forecolor ;
      private int edtavUsuariodepartamento_Enabled ;
      private int edtavUsuariorequerimiento_Forecolor ;
      private int edtavUsuariorequerimiento_Enabled ;
      private int lblTextblock5_Forecolor ;
      private int lblTextblock6_Forecolor ;
      private int lblTextblock7_Forecolor ;
      private int lblTextblock16_Forecolor ;
      private int lblTextblock35_Forecolor ;
      private int lblTextblock8_Forecolor ;
      private int lblTextblock9_Forecolor ;
      private int lblTextblock11_Forecolor ;
      private int lblTextblock12_Forecolor ;
      private int lblTextblock13_Forecolor ;
      private int lblTextblock10_Forecolor ;
      private int lblTextblock36_Forecolor ;
      private int lblTextblock37_Forecolor ;
      private int lblTextblock38_Forecolor ;
      private int lblTextblock39_Forecolor ;
      private int lblTextblock40_Forecolor ;
      private int lblTextblock41_Forecolor ;
      private int lblTextblock42_Forecolor ;
      private int lblTextblock43_Forecolor ;
      private int lblTextblock44_Forecolor ;
      private int lblTextblock45_Forecolor ;
      private int lblTextblock46_Forecolor ;
      private int lblTextblock47_Forecolor ;
      private int lblTextblock48_Forecolor ;
      private int lblTextblock49_Forecolor ;
      private int lblTextblock50_Forecolor ;
      private int lblTextblock51_Forecolor ;
      private int lblTextblock52_Forecolor ;
      private int lblTextblock53_Forecolor ;
      private int lblTextblock54_Forecolor ;
      private int lblTextblock55_Forecolor ;
      private int lblTextblock56_Forecolor ;
      private int lblTextblock57_Forecolor ;
      private int lblTextblock58_Forecolor ;
      private int lblTextblock62_Forecolor ;
      private int lblTextblock61_Forecolor ;
      private int lblTextblock60_Forecolor ;
      private int lblTextblock59_Forecolor ;
      private int lblTextblock63_Forecolor ;
      private int lblTextblock65_Forecolor ;
      private int lblTextblock67_Forecolor ;
      private int lblTextblock68_Forecolor ;
      private int lblTextblock66_Forecolor ;
      private int lblTextblock64_Forecolor ;
      private int lblTextblock69_Forecolor ;
      private int lblTextblock72_Forecolor ;
      private int lblTextblock76_Forecolor ;
      private int lblTextblock77_Forecolor ;
      private int lblTextblock74_Forecolor ;
      private int lblTextblock75_Forecolor ;
      private int lblTextblock73_Forecolor ;
      private int lblTextblock71_Forecolor ;
      private int AV6detalle_infotecid_unidad ;
      private int edtavEtapadesarrolloid_Enabled ;
      private int edtavTicketresponsableobservacion_Forecolor ;
      private int edtavTicketresponsableobservacion_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private int ZV6detalle_infotecid_unidad ;
      private int ZV12id_actividad_categoria ;
      private long AV16TicketId ;
      private long AV56UsuarioId ;
      private long AV30TicketResponsableId ;
      private long wcpOAV16TicketId ;
      private long wcpOAV56UsuarioId ;
      private long wcpOAV30TicketResponsableId ;
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
      private string divTable19_Internalname ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string dynavEstadoticketticketid_Internalname ;
      private string TempTags ;
      private string dynavEstadoticketticketid_Jsonclick ;
      private string Tab1_Internalname ;
      private string lblTabpage1_title_Internalname ;
      private string lblTabpage1_title_Jsonclick ;
      private string divTabpage1table_Internalname ;
      private string divTable21_Internalname ;
      private string divTable22_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string chkavTicketresponsableanalasisuno_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string chkavTicketresponsableanalasisdos_Internalname ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string chkavTicketresponsableanalasistres_Internalname ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string chkavTicketresponsableanalasiscuatro_Internalname ;
      private string divTable23_Internalname ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string chkavTicketresponsablediseniouno_Internalname ;
      private string lblTabpage2_title_Internalname ;
      private string lblTabpage2_title_Jsonclick ;
      private string divTabpage2table_Internalname ;
      private string divTable4_Internalname ;
      private string divTable24_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string chkavTicketresponsabledesarrollouno_Internalname ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string chkavTicketresponsabledesarrollodos_Internalname ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string chkavTicketresponsabledesarrollotres_Internalname ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string chkavTicketresponsabledesarrollocuatro_Internalname ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string chkavTicketresponsabledesarrollocinco_Internalname ;
      private string divTable38_Internalname ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string chkavTicketresponsablepruebasuno_Internalname ;
      private string lblTextblock40_Internalname ;
      private string lblTextblock40_Jsonclick ;
      private string chkavTicketresponsablepruebasdos_Internalname ;
      private string lblTextblock41_Internalname ;
      private string lblTextblock41_Jsonclick ;
      private string chkavTicketresponsablepruebastres_Internalname ;
      private string lblTextblock42_Internalname ;
      private string lblTextblock42_Jsonclick ;
      private string chkavTicketresponsablepruebascuatro_Internalname ;
      private string lblTabpage3_title_Internalname ;
      private string lblTabpage3_title_Jsonclick ;
      private string divTabpage3table_Internalname ;
      private string divTable8_Internalname ;
      private string divTable30_Internalname ;
      private string lblTextblock43_Internalname ;
      private string lblTextblock43_Jsonclick ;
      private string lblTextblock44_Internalname ;
      private string lblTextblock44_Jsonclick ;
      private string chkavTicketresponsabledocumentacionuno_Internalname ;
      private string lblTextblock45_Internalname ;
      private string lblTextblock45_Jsonclick ;
      private string chkavTicketresponsabledocumentaciondos_Internalname ;
      private string lblTextblock46_Internalname ;
      private string lblTextblock46_Jsonclick ;
      private string chkavTicketresponsabledocumentaciontres_Internalname ;
      private string lblTextblock47_Internalname ;
      private string lblTextblock47_Jsonclick ;
      private string chkavTicketresponsabledocumentacioncuatro_Internalname ;
      private string divTable39_Internalname ;
      private string lblTextblock48_Internalname ;
      private string lblTextblock48_Jsonclick ;
      private string lblTextblock49_Internalname ;
      private string lblTextblock49_Jsonclick ;
      private string chkavTicketresponsableimplementacionuno_Internalname ;
      private string lblTextblock50_Internalname ;
      private string lblTextblock50_Jsonclick ;
      private string chkavTicketresponsableimplementaciondos_Internalname ;
      private string lblTextblock51_Internalname ;
      private string lblTextblock51_Jsonclick ;
      private string chkavTicketresponsableimplementaciontres_Internalname ;
      private string lblTextblock52_Internalname ;
      private string lblTextblock52_Jsonclick ;
      private string chkavTicketresponsableimplementacioncuatro_Internalname ;
      private string lblTextblock53_Internalname ;
      private string lblTextblock53_Jsonclick ;
      private string chkavTicketresponsableimplementacioncinco_Internalname ;
      private string lblTextblock54_Internalname ;
      private string lblTextblock54_Jsonclick ;
      private string chkavTicketresponsableimplementacionseis_Internalname ;
      private string lblTabpage4_title_Internalname ;
      private string lblTabpage4_title_Jsonclick ;
      private string divTabpage4table_Internalname ;
      private string divTable9_Internalname ;
      private string divTable31_Internalname ;
      private string lblTextblock55_Internalname ;
      private string lblTextblock55_Jsonclick ;
      private string lblTextblock56_Internalname ;
      private string lblTextblock56_Jsonclick ;
      private string chkavTicketresponsablemantenimientouno_Internalname ;
      private string lblTextblock57_Internalname ;
      private string lblTextblock57_Jsonclick ;
      private string chkavTicketresponsablemantenimientodos_Internalname ;
      private string lblTextblock58_Internalname ;
      private string lblTextblock58_Jsonclick ;
      private string chkavTicketresponsablemantenimientotres_Internalname ;
      private string lblTextblock62_Internalname ;
      private string lblTextblock62_Jsonclick ;
      private string chkavTicketresponsablemantenimientocuatro_Internalname ;
      private string divTable34_Internalname ;
      private string lblTextblock61_Internalname ;
      private string lblTextblock61_Jsonclick ;
      private string chkavTicketresponsablemantenimientocinco_Internalname ;
      private string lblTextblock60_Internalname ;
      private string lblTextblock60_Jsonclick ;
      private string chkavTicketresponsablemantenimientoseis_Internalname ;
      private string lblTextblock59_Internalname ;
      private string lblTextblock59_Jsonclick ;
      private string chkavTicketresponsablemantenimientosiete_Internalname ;
      private string lblTabpage5_title_Internalname ;
      private string lblTabpage5_title_Jsonclick ;
      private string divTabpage5table_Internalname ;
      private string divTable32_Internalname ;
      private string lblTextblock63_Internalname ;
      private string lblTextblock63_Jsonclick ;
      private string divTable33_Internalname ;
      private string lblTextblock65_Internalname ;
      private string lblTextblock65_Jsonclick ;
      private string lblTextblock67_Internalname ;
      private string lblTextblock67_Jsonclick ;
      private string chkavTicketresponsablegestionbduno_Internalname ;
      private string lblTextblock68_Internalname ;
      private string lblTextblock68_Jsonclick ;
      private string chkavTicketresponsablegestionbddos_Internalname ;
      private string lblTextblock66_Internalname ;
      private string lblTextblock66_Jsonclick ;
      private string chkavTicketresponsablegestionbdtres_Internalname ;
      private string lblTextblock64_Internalname ;
      private string lblTextblock64_Jsonclick ;
      private string chkavTicketresponsablegestionbdcuatro_Internalname ;
      private string divTable40_Internalname ;
      private string lblTextblock69_Internalname ;
      private string lblTextblock69_Jsonclick ;
      private string lblTextblock72_Internalname ;
      private string lblTextblock72_Jsonclick ;
      private string chkavTicketresponsablemantenimientobduno_Internalname ;
      private string lblTextblock76_Internalname ;
      private string lblTextblock76_Jsonclick ;
      private string chkavTicketresponsablemantenimientobddos_Internalname ;
      private string lblTextblock77_Internalname ;
      private string lblTextblock77_Jsonclick ;
      private string chkavTicketresponsablemantenimientobdtres_Internalname ;
      private string lblTextblock74_Internalname ;
      private string lblTextblock74_Jsonclick ;
      private string chkavTicketresponsablemantenimientobdcuatro_Internalname ;
      private string lblTextblock75_Internalname ;
      private string lblTextblock75_Jsonclick ;
      private string chkavTicketresponsablemantenimientobdcinco_Internalname ;
      private string lblTextblock73_Internalname ;
      private string lblTextblock73_Jsonclick ;
      private string chkavTicketresponsablemantenimientobdseis_Internalname ;
      private string lblTextblock71_Internalname ;
      private string lblTextblock71_Jsonclick ;
      private string chkavTicketresponsablemantenimientobdsiete_Internalname ;
      private string lblTabpage6_title_Internalname ;
      private string lblTabpage6_title_Jsonclick ;
      private string divTabpage6table_Internalname ;
      private string divTable1_Internalname ;
      private string dynavDetalle_infotecid_unidad_Internalname ;
      private string dynavDetalle_infotecid_unidad_Jsonclick ;
      private string edtavEtapadesarrolloid_Internalname ;
      private string edtavEtapadesarrolloid_Jsonclick ;
      private string divTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string divTable7_Internalname ;
      private string edtavTicketresponsableobservacion_Internalname ;
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
      private DateTime AV55UsuarioFecha ;
      private DateTime wcpOAV55UsuarioFecha ;
      private bool AV59TicketResponsablePasaTaller2 ;
      private bool wcpOAV59TicketResponsablePasaTaller2 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Tab1_Historymanagement ;
      private bool wbLoad ;
      private bool AV62TicketResponsableAnalasisUno ;
      private bool AV64TicketResponsableAnalasisDos ;
      private bool AV65TicketResponsableAnalasisTres ;
      private bool AV66TicketResponsableAnalasisCuatro ;
      private bool AV67TicketResponsableDisenioUno ;
      private bool AV68TicketResponsableDesarrolloUno ;
      private bool AV70TicketResponsableDesarrolloDos ;
      private bool AV71TicketResponsableDesarrolloTres ;
      private bool AV72TicketResponsableDesarrolloCuatro ;
      private bool AV73TicketResponsableDesarrolloCinco ;
      private bool AV74TicketResponsablePruebasUno ;
      private bool AV76TicketResponsablePruebasDos ;
      private bool AV77TicketResponsablePruebasTres ;
      private bool AV78TicketResponsablePruebasCuatro ;
      private bool AV80TicketResponsableDocumentacionUno ;
      private bool AV81TicketResponsableDocumentacionDos ;
      private bool AV82TicketResponsableDocumentacionTres ;
      private bool AV83TicketResponsableDocumentacionCuatro ;
      private bool AV84TicketResponsableImplementacionUno ;
      private bool AV87TicketResponsableImplementacionDos ;
      private bool AV88TicketResponsableImplementacionTres ;
      private bool AV89TicketResponsableImplementacionCuatro ;
      private bool AV90TicketResponsableImplementacionCinco ;
      private bool AV91TicketResponsableImplementacionSeis ;
      private bool AV93TicketResponsableMantenimientoUno ;
      private bool AV94TicketResponsableMantenimientoDos ;
      private bool AV95TicketResponsableMantenimientoTres ;
      private bool AV96TicketResponsableMantenimientoCuatro ;
      private bool AV98TicketResponsableMantenimientoCinco ;
      private bool AV99TicketResponsableMantenimientoSeis ;
      private bool AV101TicketResponsableMantenimientoSiete ;
      private bool AV102TicketResponsableGestionbdUno ;
      private bool AV103TicketResponsableGestionbdDos ;
      private bool AV104TicketResponsableGestionbdTres ;
      private bool AV105TicketResponsableGestionbdCuatro ;
      private bool AV106TicketResponsableMantenimientobdUno ;
      private bool AV107TicketResponsableMantenimientobdDos ;
      private bool AV108TicketResponsableMantenimientobdTres ;
      private bool AV109TicketResponsableMantenimientobdCuatro ;
      private bool AV111TicketResponsableMantenimientobdCinco ;
      private bool AV112TicketResponsableMantenimientobdSeis ;
      private bool AV113TicketResponsableMantenimientobdSiete ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV54UsuarioEmail ;
      private string AV57UsuarioNombre ;
      private string AV53UsuarioDepartamento ;
      private string AV58UsuarioRequerimiento ;
      private string wcpOAV54UsuarioEmail ;
      private string wcpOAV57UsuarioNombre ;
      private string wcpOAV53UsuarioDepartamento ;
      private string wcpOAV58UsuarioRequerimiento ;
      private string AV37TicketResponsableObservacion ;
      private string AV14prioridad ;
      private string AV7detalle_tarea ;
      private IGxSession AV115WebSession ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXUserControl ucTab1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavEstadoticketticketid ;
      private GXCheckbox chkavTicketresponsableanalasisuno ;
      private GXCheckbox chkavTicketresponsableanalasisdos ;
      private GXCheckbox chkavTicketresponsableanalasistres ;
      private GXCheckbox chkavTicketresponsableanalasiscuatro ;
      private GXCheckbox chkavTicketresponsablediseniouno ;
      private GXCheckbox chkavTicketresponsabledesarrollouno ;
      private GXCheckbox chkavTicketresponsabledesarrollodos ;
      private GXCheckbox chkavTicketresponsabledesarrollotres ;
      private GXCheckbox chkavTicketresponsabledesarrollocuatro ;
      private GXCheckbox chkavTicketresponsabledesarrollocinco ;
      private GXCheckbox chkavTicketresponsablepruebasuno ;
      private GXCheckbox chkavTicketresponsablepruebasdos ;
      private GXCheckbox chkavTicketresponsablepruebastres ;
      private GXCheckbox chkavTicketresponsablepruebascuatro ;
      private GXCheckbox chkavTicketresponsabledocumentacionuno ;
      private GXCheckbox chkavTicketresponsabledocumentaciondos ;
      private GXCheckbox chkavTicketresponsabledocumentaciontres ;
      private GXCheckbox chkavTicketresponsabledocumentacioncuatro ;
      private GXCheckbox chkavTicketresponsableimplementacionuno ;
      private GXCheckbox chkavTicketresponsableimplementaciondos ;
      private GXCheckbox chkavTicketresponsableimplementaciontres ;
      private GXCheckbox chkavTicketresponsableimplementacioncuatro ;
      private GXCheckbox chkavTicketresponsableimplementacioncinco ;
      private GXCheckbox chkavTicketresponsableimplementacionseis ;
      private GXCheckbox chkavTicketresponsablemantenimientouno ;
      private GXCheckbox chkavTicketresponsablemantenimientodos ;
      private GXCheckbox chkavTicketresponsablemantenimientotres ;
      private GXCheckbox chkavTicketresponsablemantenimientocuatro ;
      private GXCheckbox chkavTicketresponsablemantenimientocinco ;
      private GXCheckbox chkavTicketresponsablemantenimientoseis ;
      private GXCheckbox chkavTicketresponsablemantenimientosiete ;
      private GXCheckbox chkavTicketresponsablegestionbduno ;
      private GXCheckbox chkavTicketresponsablegestionbddos ;
      private GXCheckbox chkavTicketresponsablegestionbdtres ;
      private GXCheckbox chkavTicketresponsablegestionbdcuatro ;
      private GXCheckbox chkavTicketresponsablemantenimientobduno ;
      private GXCheckbox chkavTicketresponsablemantenimientobddos ;
      private GXCheckbox chkavTicketresponsablemantenimientobdtres ;
      private GXCheckbox chkavTicketresponsablemantenimientobdcuatro ;
      private GXCheckbox chkavTicketresponsablemantenimientobdcinco ;
      private GXCheckbox chkavTicketresponsablemantenimientobdseis ;
      private GXCheckbox chkavTicketresponsablemantenimientobdsiete ;
      private GXCombobox dynavDetalle_infotecid_unidad ;
      private GXCombobox dynavCategoria_tareaid_tipo_categoria ;
      private GXCombobox dynavId_actividad_categoria ;
      private GXCombobox dynavCategoriadetalletareaid ;
      private GXCombobox cmbavPrioridad ;
      private IDataStoreProvider pr_default ;
      private short[] H007E2_A5EstadoTicketId ;
      private string[] H007E2_A24EstadoTicketNombre ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] H007E3_A105id_unidad_gis ;
      private int[] H007E3_A104categoria_tareaid_tipo_categoria ;
      private int[] H007E4_A104categoria_tareaid_tipo_categoria ;
      private string[] H007E4_A106nombre_categoria ;
      private bool[] H007E4_n106nombre_categoria ;
      private int[] H007E4_A105id_unidad_gis ;
      private int[] H007E5_A102id_actividad_categoria ;
      private string[] H007E5_A123nombre_actividad ;
      private bool[] H007E5_n123nombre_actividad ;
      private int[] H007E5_A122actividades_categoriaid_tipo_categoria ;
      private bool[] H007E5_n122actividades_categoriaid_tipo_categoria ;
      private int[] H007E5_A125actividades_categoriaestado ;
      private bool[] H007E5_n125actividades_categoriaestado ;
      private short[] H007E6_A294CategoriaDetalleTareaId ;
      private string[] H007E6_A295CategoriaDetalleTareaNombre ;
      private int[] H007E6_A102id_actividad_categoria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GXWindow AV61window ;
   }

   public class wpdesarrollosoftware__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007E2;
          prmH007E2 = new Object[] {
          };
          Object[] prmH007E6;
          prmH007E6 = new Object[] {
          new ParDef("@AV12id_actividad_categoria",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("H007E2", "SELECT [EstadoTicketId], [EstadoTicketNombre] FROM [EstadoTicket] WHERE [EstadoTicketId] = 5 ORDER BY [EstadoTicketNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007E6", "SELECT [CategoriaDetalleTareaId], [CategoriaDetalleTareaNombre], [id_actividad_categoria] FROM [CategoriaDetalleTarea] WHERE [id_actividad_categoria] = @AV12id_actividad_categoria ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E6,0, GxCacheFrequency.OFF ,true,false )
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
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

 public class wpdesarrollosoftware__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmH007E3;
        prmH007E3 = new Object[] {
        new ParDef("@AV5categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmH007E4;
        prmH007E4 = new Object[] {
        };
        Object[] prmH007E5;
        prmH007E5 = new Object[] {
        new ParDef("@AV5categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("H007E3", "SELECT [id_unidad_gis], [id_tipo_categoria] AS categoria_tareaid_tipo_categoria FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @AV5categoria_tareaid_tipo_categoria ORDER BY [id_unidad_gis] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E3,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007E4", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria], [id_unidad_gis] FROM dbo.[categoria_tarea] ORDER BY [nombre_categoria] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E4,0, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H007E5", "SELECT [id_actividad_categoria], [nombre_actividad], [id_tipo_categoria] AS actividades_categoriaid_tipo_categoria, [estado] AS actividades_categoriaestado FROM dbo.[actividades_categoria] WHERE ([id_tipo_categoria] = @AV5categoria_tareaid_tipo_categoria) AND ([estado] = 1) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007E5,0, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
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
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

}
