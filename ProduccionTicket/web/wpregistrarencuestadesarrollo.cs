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
   public class wpregistrarencuestadesarrollo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpregistrarencuestadesarrollo( )
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

      public wpregistrarencuestadesarrollo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_TicketId ,
                           long aP1_TicketResponsableId ,
                           long aP2_UsuarioId ,
                           string aP3_UsuarioNombre ,
                           short aP4_TicketTecnicoResponsableId ,
                           string aP5_TicketTecnicoResponsableNombre ,
                           short aP6_EtapaDesarrolloId )
      {
         this.AV14TicketId = aP0_TicketId;
         this.AV17TicketResponsableId = aP1_TicketResponsableId;
         this.AV15UsuarioId = aP2_UsuarioId;
         this.AV16UsuarioNombre = aP3_UsuarioNombre;
         this.AV18TicketTecnicoResponsableId = aP4_TicketTecnicoResponsableId;
         this.AV19TicketTecnicoResponsableNombre = aP5_TicketTecnicoResponsableNombre;
         this.AV29EtapaDesarrolloId = aP6_EtapaDesarrolloId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavSatisfaccioncatalogaid = new GXCombobox();
         dynavSatisfaccionrendimientoid = new GXCombobox();
         dynavSatisfaccionprogramadorid = new GXCombobox();
         dynavSatisfaccioncapacitacionid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONCATALOGAID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONCATALOGAID7M2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONRENDIMIENTOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONRENDIMIENTOID7M2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONPROGRAMADORID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONPROGRAMADORID7M2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONCAPACITACIONID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONCAPACITACIONID7M2( ) ;
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
               AV14TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV14TicketId", StringUtil.LTrimStr( (decimal)(AV14TicketId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14TicketId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
                  AssignAttri("", false, "AV17TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV17TicketResponsableId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
                  AV15UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AssignAttri("", false, "AV15UsuarioId", StringUtil.LTrimStr( (decimal)(AV15UsuarioId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioId), "ZZZZZZZZZ9"), context));
                  AV16UsuarioNombre = GetPar( "UsuarioNombre");
                  AssignAttri("", false, "AV16UsuarioNombre", AV16UsuarioNombre);
                  AV18TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
                  AssignAttri("", false, "AV18TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV18TicketTecnicoResponsableId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
                  AV19TicketTecnicoResponsableNombre = GetPar( "TicketTecnicoResponsableNombre");
                  AssignAttri("", false, "AV19TicketTecnicoResponsableNombre", AV19TicketTecnicoResponsableNombre);
                  AV29EtapaDesarrolloId = (short)(NumberUtil.Val( GetPar( "EtapaDesarrolloId"), "."));
                  AssignAttri("", false, "AV29EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV29EtapaDesarrolloId), 4, 0));
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
            return "wpregistrarsatisfaccion_Execute" ;
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
         PA7M2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START7M2( ) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202418843060", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregistrarencuestadesarrollo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV14TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV17TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(AV16UsuarioNombre)),UrlEncode(StringUtil.LTrimStr(AV18TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV19TicketTecnicoResponsableNombre)),UrlEncode(StringUtil.LTrimStr(AV29EtapaDesarrolloId,4,0))}, new string[] {"TicketId","TicketResponsableId","UsuarioId","UsuarioNombre","TicketTecnicoResponsableId","TicketTecnicoResponsableNombre","EtapaDesarrolloId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14TicketId), "ZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TicketTecnicoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV29EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONCATALOGAID_Text", StringUtil.RTrim( dynavSatisfaccioncatalogaid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONRENDIMIENTOID_Text", StringUtil.RTrim( dynavSatisfaccionrendimientoid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONPROGRAMADORID_Text", StringUtil.RTrim( dynavSatisfaccionprogramadorid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONCAPACITACIONID_Text", StringUtil.RTrim( dynavSatisfaccioncapacitacionid.Description));
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
            WE7M2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT7M2( ) ;
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
         return formatLink("wpregistrarencuestadesarrollo.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV14TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV17TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(AV16UsuarioNombre)),UrlEncode(StringUtil.LTrimStr(AV18TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV19TicketTecnicoResponsableNombre)),UrlEncode(StringUtil.LTrimStr(AV29EtapaDesarrolloId,4,0))}, new string[] {"TicketId","TicketResponsableId","UsuarioId","UsuarioNombre","TicketTecnicoResponsableId","TicketTecnicoResponsableNombre","EtapaDesarrolloId"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegistrarEncuestaDesarrollo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Llenar Encuesta Satisfacción" ;
      }

      protected void WB7M0( )
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "No. Ticket:", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTicketid_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTicketid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14TicketId), 10, 0, ".", "")), StringUtil.LTrim( ((edtavTicketid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV14TicketId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV14TicketId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketid_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTicketid_Forecolor)+";", "", "", "", 1, edtavTicketid_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Usuario:", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV16UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV16UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavUsuarionombre_Forecolor)+";", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPRegistrarEncuestaDesarrollo.htm");
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
            GxWebStd.gx_div_start( context, divTable9_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Técnico:", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtavTickettecnicoresponsablenombre_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTickettecnicoresponsablenombre_Internalname, AV19TicketTecnicoResponsableNombre, StringUtil.RTrim( context.localUtil.Format( AV19TicketTecnicoResponsableNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTickettecnicoresponsablenombre_Jsonclick, 0, "Attribute", "color:"+context.BuildHTMLColor( edtavTickettecnicoresponsablenombre_Forecolor)+";", "", "", "", 1, edtavTickettecnicoresponsablenombre_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPRegistrarEncuestaDesarrollo.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable11_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "1. ¿Cómo cataloga la atención brindada?", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock1_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock1_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfaccioncatalogaid, dynavSatisfaccioncatalogaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24SatisfaccionCatalogaId), 4, 0)), 1, dynavSatisfaccioncatalogaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfaccioncatalogaid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavSatisfaccioncatalogaid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 1, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            dynavSatisfaccioncatalogaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24SatisfaccionCatalogaId), 4, 0));
            AssignProp("", false, dynavSatisfaccioncatalogaid_Internalname, "Values", (string)(dynavSatisfaccioncatalogaid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable12_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "2. ¿El rendimiento del software está acorde a lo que usted espera?", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock2_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock2_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfaccionrendimientoid, dynavSatisfaccionrendimientoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV21SatisfaccionRendimientoId), 4, 0)), 1, dynavSatisfaccionrendimientoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfaccionrendimientoid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavSatisfaccionrendimientoid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "", true, 1, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            dynavSatisfaccionrendimientoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21SatisfaccionRendimientoId), 4, 0));
            AssignProp("", false, dynavSatisfaccionrendimientoid_Internalname, "Values", (string)(dynavSatisfaccionrendimientoid.ToJavascriptSource()), true);
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "3. ¿cómo evaluaría el grado de conocimiento y experiencia de nuestro técnico en desarrollo de software?", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock3_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock3_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfaccionprogramadorid, dynavSatisfaccionprogramadorid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV22SatisfaccionProgramadorId), 4, 0)), 1, dynavSatisfaccionprogramadorid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfaccionprogramadorid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavSatisfaccionprogramadorid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 1, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            dynavSatisfaccionprogramadorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22SatisfaccionProgramadorId), 4, 0));
            AssignProp("", false, dynavSatisfaccionprogramadorid_Internalname, "Values", (string)(dynavSatisfaccionprogramadorid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable14_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "4. ¿Cómo evaluaría el apoyo, la capacitación que ha recibido y/o la iniciativa del técnico para ayudarlo en el buen uso del software?", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock4_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock4_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfaccioncapacitacionid, dynavSatisfaccioncapacitacionid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23SatisfaccionCapacitacionId), 4, 0)), 1, dynavSatisfaccioncapacitacionid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfaccioncapacitacionid.Enabled, 0, 0, 0, "em", 0, "", "color:"+context.BuildHTMLColor( dynavSatisfaccioncapacitacionid.ForeColor)+";", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "", true, 1, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            dynavSatisfaccioncapacitacionid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23SatisfaccionCapacitacionId), 4, 0));
            AssignProp("", false, dynavSatisfaccioncapacitacionid_Internalname, "Values", (string)(dynavSatisfaccioncapacitacionid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable15_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "5. ¿Cómo podemos mejorar el software? (Si fuera necesario)", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", ((lblTextblock5_Fontbold==1) ? "font-weight:bold;" : "font-weight:normal;")+"color:"+context.BuildHTMLColor( lblTextblock5_Forecolor)+";", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavSatisfaccionmejorasoftware_Forecolor) + ";";
            ClassString = "Attribute";
            StyleString = "color:" + context.BuildHTMLColor( edtavSatisfaccionmejorasoftware_Forecolor) + ";";
            GxWebStd.gx_html_textarea( context, edtavSatisfaccionmejorasoftware_Internalname, AV20SatisfaccionMejoraSoftware, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", 0, 1, edtavSatisfaccionmejorasoftware_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegistrarEncuestaDesarrollo.htm");
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
            GxWebStd.gx_div_start( context, divTable3_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable4_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarEncuestaDesarrollo.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable5_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarEncuestaDesarrollo.htm");
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

      protected void START7M2( )
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
            Form.Meta.addItem("description", "Llenar Encuesta Satisfacción", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP7M0( ) ;
      }

      protected void WS7M2( )
      {
         START7M2( ) ;
         EVT7M2( ) ;
      }

      protected void EVT7M2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "'CANCELAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Cancelar' */
                              E117M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E127M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E137M2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E147M2 ();
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

      protected void WE7M2( )
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

      protected void PA7M2( )
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
               GX_FocusControl = dynavSatisfaccioncatalogaid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSATISFACCIONCATALOGAID7M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONCATALOGAID_data7M2( ) ;
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

      protected void GXVvSATISFACCIONCATALOGAID_html7M2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONCATALOGAID_data7M2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfaccioncatalogaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfaccioncatalogaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONCATALOGAID_data7M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007M2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007M2_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007M2_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSATISFACCIONRENDIMIENTOID7M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONRENDIMIENTOID_data7M2( ) ;
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

      protected void GXVvSATISFACCIONRENDIMIENTOID_html7M2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONRENDIMIENTOID_data7M2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfaccionrendimientoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfaccionrendimientoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONRENDIMIENTOID_data7M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007M3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007M3_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007M3_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSATISFACCIONPROGRAMADORID7M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONPROGRAMADORID_data7M2( ) ;
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

      protected void GXVvSATISFACCIONPROGRAMADORID_html7M2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONPROGRAMADORID_data7M2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfaccionprogramadorid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfaccionprogramadorid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONPROGRAMADORID_data7M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007M4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007M4_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007M4_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLVvSATISFACCIONCAPACITACIONID7M2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONCAPACITACIONID_data7M2( ) ;
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

      protected void GXVvSATISFACCIONCAPACITACIONID_html7M2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONCAPACITACIONID_data7M2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfaccioncapacitacionid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfaccioncapacitacionid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONCAPACITACIONID_data7M2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H007M5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H007M5_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H007M5_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSATISFACCIONCATALOGAID_html7M2( ) ;
            GXVvSATISFACCIONRENDIMIENTOID_html7M2( ) ;
            GXVvSATISFACCIONPROGRAMADORID_html7M2( ) ;
            GXVvSATISFACCIONCAPACITACIONID_html7M2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSatisfaccioncatalogaid.ItemCount > 0 )
         {
            AV24SatisfaccionCatalogaId = (short)(NumberUtil.Val( dynavSatisfaccioncatalogaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24SatisfaccionCatalogaId), 4, 0))), "."));
            AssignAttri("", false, "AV24SatisfaccionCatalogaId", StringUtil.LTrimStr( (decimal)(AV24SatisfaccionCatalogaId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfaccioncatalogaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24SatisfaccionCatalogaId), 4, 0));
            AssignProp("", false, dynavSatisfaccioncatalogaid_Internalname, "Values", dynavSatisfaccioncatalogaid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfaccionrendimientoid.ItemCount > 0 )
         {
            AV21SatisfaccionRendimientoId = (short)(NumberUtil.Val( dynavSatisfaccionrendimientoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV21SatisfaccionRendimientoId), 4, 0))), "."));
            AssignAttri("", false, "AV21SatisfaccionRendimientoId", StringUtil.LTrimStr( (decimal)(AV21SatisfaccionRendimientoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfaccionrendimientoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV21SatisfaccionRendimientoId), 4, 0));
            AssignProp("", false, dynavSatisfaccionrendimientoid_Internalname, "Values", dynavSatisfaccionrendimientoid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfaccionprogramadorid.ItemCount > 0 )
         {
            AV22SatisfaccionProgramadorId = (short)(NumberUtil.Val( dynavSatisfaccionprogramadorid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV22SatisfaccionProgramadorId), 4, 0))), "."));
            AssignAttri("", false, "AV22SatisfaccionProgramadorId", StringUtil.LTrimStr( (decimal)(AV22SatisfaccionProgramadorId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfaccionprogramadorid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV22SatisfaccionProgramadorId), 4, 0));
            AssignProp("", false, dynavSatisfaccionprogramadorid_Internalname, "Values", dynavSatisfaccionprogramadorid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfaccioncapacitacionid.ItemCount > 0 )
         {
            AV23SatisfaccionCapacitacionId = (short)(NumberUtil.Val( dynavSatisfaccioncapacitacionid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23SatisfaccionCapacitacionId), 4, 0))), "."));
            AssignAttri("", false, "AV23SatisfaccionCapacitacionId", StringUtil.LTrimStr( (decimal)(AV23SatisfaccionCapacitacionId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfaccioncapacitacionid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23SatisfaccionCapacitacionId), 4, 0));
            AssignProp("", false, dynavSatisfaccioncapacitacionid_Internalname, "Values", dynavSatisfaccioncapacitacionid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF7M2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTicketid_Enabled = 0;
         AssignProp("", false, edtavTicketid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTicketid_Enabled), 5, 0), true);
         edtavUsuarionombre_Enabled = 0;
         AssignProp("", false, edtavUsuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarionombre_Enabled), 5, 0), true);
         edtavTickettecnicoresponsablenombre_Enabled = 0;
         AssignProp("", false, edtavTickettecnicoresponsablenombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTickettecnicoresponsablenombre_Enabled), 5, 0), true);
      }

      protected void RF7M2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E147M2 ();
            WB7M0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes7M2( )
      {
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15UsuarioId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TicketTecnicoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         edtavTicketid_Enabled = 0;
         AssignProp("", false, edtavTicketid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTicketid_Enabled), 5, 0), true);
         edtavUsuarionombre_Enabled = 0;
         AssignProp("", false, edtavUsuarionombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsuarionombre_Enabled), 5, 0), true);
         edtavTickettecnicoresponsablenombre_Enabled = 0;
         AssignProp("", false, edtavTickettecnicoresponsablenombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTickettecnicoresponsablenombre_Enabled), 5, 0), true);
         GXVvSATISFACCIONCATALOGAID_html7M2( ) ;
         GXVvSATISFACCIONRENDIMIENTOID_html7M2( ) ;
         GXVvSATISFACCIONPROGRAMADORID_html7M2( ) ;
         GXVvSATISFACCIONCAPACITACIONID_html7M2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP7M0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E137M2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            dynavSatisfaccioncatalogaid.CurrentValue = cgiGet( dynavSatisfaccioncatalogaid_Internalname);
            AV24SatisfaccionCatalogaId = (short)(NumberUtil.Val( cgiGet( dynavSatisfaccioncatalogaid_Internalname), "."));
            AssignAttri("", false, "AV24SatisfaccionCatalogaId", StringUtil.LTrimStr( (decimal)(AV24SatisfaccionCatalogaId), 4, 0));
            dynavSatisfaccionrendimientoid.CurrentValue = cgiGet( dynavSatisfaccionrendimientoid_Internalname);
            AV21SatisfaccionRendimientoId = (short)(NumberUtil.Val( cgiGet( dynavSatisfaccionrendimientoid_Internalname), "."));
            AssignAttri("", false, "AV21SatisfaccionRendimientoId", StringUtil.LTrimStr( (decimal)(AV21SatisfaccionRendimientoId), 4, 0));
            dynavSatisfaccionprogramadorid.CurrentValue = cgiGet( dynavSatisfaccionprogramadorid_Internalname);
            AV22SatisfaccionProgramadorId = (short)(NumberUtil.Val( cgiGet( dynavSatisfaccionprogramadorid_Internalname), "."));
            AssignAttri("", false, "AV22SatisfaccionProgramadorId", StringUtil.LTrimStr( (decimal)(AV22SatisfaccionProgramadorId), 4, 0));
            dynavSatisfaccioncapacitacionid.CurrentValue = cgiGet( dynavSatisfaccioncapacitacionid_Internalname);
            AV23SatisfaccionCapacitacionId = (short)(NumberUtil.Val( cgiGet( dynavSatisfaccioncapacitacionid_Internalname), "."));
            AssignAttri("", false, "AV23SatisfaccionCapacitacionId", StringUtil.LTrimStr( (decimal)(AV23SatisfaccionCapacitacionId), 4, 0));
            AV20SatisfaccionMejoraSoftware = cgiGet( edtavSatisfaccionmejorasoftware_Internalname);
            AssignAttri("", false, "AV20SatisfaccionMejoraSoftware", AV20SatisfaccionMejoraSoftware);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvSATISFACCIONCATALOGAID_html7M2( ) ;
            GXVvSATISFACCIONRENDIMIENTOID_html7M2( ) ;
            GXVvSATISFACCIONPROGRAMADORID_html7M2( ) ;
            GXVvSATISFACCIONCAPACITACIONID_html7M2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E117M2( )
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

      protected void E127M2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(dynavSatisfaccioncatalogaid.Description, "(Ninguno)") == 0 )
         {
            context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
         }
         else
         {
            if ( StringUtil.StrCmp(dynavSatisfaccionrendimientoid.Description, "(Ninguno)") == 0 )
            {
               context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
            }
            else
            {
               if ( StringUtil.StrCmp(dynavSatisfaccionprogramadorid.Description, "(Ninguno)") == 0 )
               {
                  context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
               }
               else
               {
                  if ( StringUtil.StrCmp(dynavSatisfaccioncapacitacionid.Description, "(Ninguno)") == 0 )
                  {
                     context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
                  }
                  else
                  {
                     new pcrinsertencuestadesarrollo(context ).execute(  AV14TicketId,  AV17TicketResponsableId,  AV15UsuarioId,  AV24SatisfaccionCatalogaId,  AV21SatisfaccionRendimientoId,  AV22SatisfaccionProgramadorId,  AV23SatisfaccionCapacitacionId,  AV20SatisfaccionMejoraSoftware,  AV18TicketTecnicoResponsableId) ;
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

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E137M2 ();
         if (returnInSub) return;
      }

      protected void E137M2( )
      {
         /* Start Routine */
         returnInSub = false;
         edtavTickettecnicoresponsablenombre_Enabled = 0;
         AssignProp("", false, edtavTickettecnicoresponsablenombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavTickettecnicoresponsablenombre_Enabled), 5, 0), true);
         lblTextblock1_Fontbold = 1;
         AssignProp("", false, lblTextblock1_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock1_Fontbold), 1, 0), true);
         lblTextblock2_Fontbold = 1;
         AssignProp("", false, lblTextblock2_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock2_Fontbold), 1, 0), true);
         lblTextblock3_Fontbold = 1;
         AssignProp("", false, lblTextblock3_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock3_Fontbold), 1, 0), true);
         lblTextblock4_Fontbold = 1;
         AssignProp("", false, lblTextblock4_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock4_Fontbold), 1, 0), true);
         lblTextblock5_Fontbold = 1;
         AssignProp("", false, lblTextblock5_Internalname, "Fontbold", StringUtil.Str( (decimal)(lblTextblock5_Fontbold), 1, 0), true);
         lblTextblock1_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock1_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock1_Forecolor), 9, 0), true);
         lblTextblock2_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock2_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock2_Forecolor), 9, 0), true);
         lblTextblock3_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock3_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock3_Forecolor), 9, 0), true);
         lblTextblock4_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock4_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock4_Forecolor), 9, 0), true);
         lblTextblock5_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, lblTextblock5_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(lblTextblock5_Forecolor), 9, 0), true);
         edtavTicketid_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTicketid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTicketid_Forecolor), 9, 0), true);
         edtavUsuarionombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavUsuarionombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavUsuarionombre_Forecolor), 9, 0), true);
         edtavTickettecnicoresponsablenombre_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavTickettecnicoresponsablenombre_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavTickettecnicoresponsablenombre_Forecolor), 9, 0), true);
         dynavSatisfaccioncatalogaid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavSatisfaccioncatalogaid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavSatisfaccioncatalogaid.ForeColor), 9, 0), true);
         dynavSatisfaccionrendimientoid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavSatisfaccionrendimientoid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavSatisfaccionrendimientoid.ForeColor), 9, 0), true);
         dynavSatisfaccionprogramadorid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavSatisfaccionprogramadorid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavSatisfaccionprogramadorid.ForeColor), 9, 0), true);
         dynavSatisfaccioncapacitacionid.ForeColor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, dynavSatisfaccioncapacitacionid_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(dynavSatisfaccioncapacitacionid.ForeColor), 9, 0), true);
         edtavSatisfaccionmejorasoftware_Forecolor = GXUtil.RGB( 0, 0, 0);
         AssignProp("", false, edtavSatisfaccionmejorasoftware_Internalname, "Forecolor", StringUtil.LTrimStr( (decimal)(edtavSatisfaccionmejorasoftware_Forecolor), 9, 0), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E147M2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14TicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV14TicketId", StringUtil.LTrimStr( (decimal)(AV14TicketId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV14TicketId), "ZZZZZZZZZ9"), context));
         AV17TicketResponsableId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV17TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV17TicketResponsableId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         AV15UsuarioId = Convert.ToInt64(getParm(obj,2));
         AssignAttri("", false, "AV15UsuarioId", StringUtil.LTrimStr( (decimal)(AV15UsuarioId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV15UsuarioId), "ZZZZZZZZZ9"), context));
         AV16UsuarioNombre = (string)getParm(obj,3);
         AssignAttri("", false, "AV16UsuarioNombre", AV16UsuarioNombre);
         AV18TicketTecnicoResponsableId = Convert.ToInt16(getParm(obj,4));
         AssignAttri("", false, "AV18TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV18TicketTecnicoResponsableId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
         AV19TicketTecnicoResponsableNombre = (string)getParm(obj,5);
         AssignAttri("", false, "AV19TicketTecnicoResponsableNombre", AV19TicketTecnicoResponsableNombre);
         AV29EtapaDesarrolloId = Convert.ToInt16(getParm(obj,6));
         AssignAttri("", false, "AV29EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV29EtapaDesarrolloId), 4, 0));
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
         PA7M2( ) ;
         WS7M2( ) ;
         WE7M2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418843161", true, true);
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
         context.AddJavascriptSource("wpregistrarencuestadesarrollo.js", "?202418843162", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavSatisfaccioncatalogaid.Name = "vSATISFACCIONCATALOGAID";
         dynavSatisfaccioncatalogaid.WebTags = "";
         dynavSatisfaccionrendimientoid.Name = "vSATISFACCIONRENDIMIENTOID";
         dynavSatisfaccionrendimientoid.WebTags = "";
         dynavSatisfaccionprogramadorid.Name = "vSATISFACCIONPROGRAMADORID";
         dynavSatisfaccionprogramadorid.WebTags = "";
         dynavSatisfaccioncapacitacionid.Name = "vSATISFACCIONCAPACITACIONID";
         dynavSatisfaccioncapacitacionid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtavTicketid_Internalname = "vTICKETID";
         divTable8_Internalname = "TABLE8";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divTable7_Internalname = "TABLE7";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtavTickettecnicoresponsablenombre_Internalname = "vTICKETTECNICORESPONSABLENOMBRE";
         divTable9_Internalname = "TABLE9";
         divTable2_Internalname = "TABLE2";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         dynavSatisfaccioncatalogaid_Internalname = "vSATISFACCIONCATALOGAID";
         divTable11_Internalname = "TABLE11";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         dynavSatisfaccionrendimientoid_Internalname = "vSATISFACCIONRENDIMIENTOID";
         divTable12_Internalname = "TABLE12";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         dynavSatisfaccionprogramadorid_Internalname = "vSATISFACCIONPROGRAMADORID";
         divTable13_Internalname = "TABLE13";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         dynavSatisfaccioncapacitacionid_Internalname = "vSATISFACCIONCAPACITACIONID";
         divTable14_Internalname = "TABLE14";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtavSatisfaccionmejorasoftware_Internalname = "vSATISFACCIONMEJORASOFTWARE";
         divTable15_Internalname = "TABLE15";
         divTable10_Internalname = "TABLE10";
         bttGuardar_Internalname = "GUARDAR";
         divTable4_Internalname = "TABLE4";
         bttCancelar_Internalname = "CANCELAR";
         divTable5_Internalname = "TABLE5";
         divTable3_Internalname = "TABLE3";
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
         edtavSatisfaccionmejorasoftware_Forecolor = (int)(0x000000);
         edtavSatisfaccionmejorasoftware_Enabled = 1;
         lblTextblock5_Forecolor = (int)(0x000000);
         lblTextblock5_Fontbold = 0;
         dynavSatisfaccioncapacitacionid_Jsonclick = "";
         dynavSatisfaccioncapacitacionid.Enabled = 1;
         dynavSatisfaccioncapacitacionid.ForeColor = (int)(0x000000);
         lblTextblock4_Forecolor = (int)(0x000000);
         lblTextblock4_Fontbold = 0;
         dynavSatisfaccionprogramadorid_Jsonclick = "";
         dynavSatisfaccionprogramadorid.Enabled = 1;
         dynavSatisfaccionprogramadorid.ForeColor = (int)(0x000000);
         lblTextblock3_Forecolor = (int)(0x000000);
         lblTextblock3_Fontbold = 0;
         dynavSatisfaccionrendimientoid_Jsonclick = "";
         dynavSatisfaccionrendimientoid.Enabled = 1;
         dynavSatisfaccionrendimientoid.ForeColor = (int)(0x000000);
         lblTextblock2_Forecolor = (int)(0x000000);
         lblTextblock2_Fontbold = 0;
         dynavSatisfaccioncatalogaid_Jsonclick = "";
         dynavSatisfaccioncatalogaid.Enabled = 1;
         dynavSatisfaccioncatalogaid.ForeColor = (int)(0x000000);
         lblTextblock1_Forecolor = (int)(0x000000);
         lblTextblock1_Fontbold = 0;
         edtavTickettecnicoresponsablenombre_Jsonclick = "";
         edtavTickettecnicoresponsablenombre_Forecolor = (int)(0x000000);
         edtavTickettecnicoresponsablenombre_Enabled = 0;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Forecolor = (int)(0x000000);
         edtavUsuarionombre_Enabled = 0;
         edtavTicketid_Jsonclick = "";
         edtavTicketid_Forecolor = (int)(0x000000);
         edtavTicketid_Enabled = 0;
         dynavSatisfaccioncapacitacionid.Description = "";
         dynavSatisfaccionprogramadorid.Description = "";
         dynavSatisfaccionrendimientoid.Description = "";
         dynavSatisfaccioncatalogaid.Description = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Llenar Encuesta Satisfacción";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV17TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV18TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV14TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'dynavSatisfaccioncatalogaid'},{av:'AV24SatisfaccionCatalogaId',fld:'vSATISFACCIONCATALOGAID',pic:'ZZZ9'},{av:'dynavSatisfaccionrendimientoid'},{av:'AV21SatisfaccionRendimientoId',fld:'vSATISFACCIONRENDIMIENTOID',pic:'ZZZ9'},{av:'dynavSatisfaccionprogramadorid'},{av:'AV22SatisfaccionProgramadorId',fld:'vSATISFACCIONPROGRAMADORID',pic:'ZZZ9'},{av:'dynavSatisfaccioncapacitacionid'},{av:'AV23SatisfaccionCapacitacionId',fld:'vSATISFACCIONCAPACITACIONID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavSatisfaccioncatalogaid'},{av:'AV24SatisfaccionCatalogaId',fld:'vSATISFACCIONCATALOGAID',pic:'ZZZ9'},{av:'dynavSatisfaccionrendimientoid'},{av:'AV21SatisfaccionRendimientoId',fld:'vSATISFACCIONRENDIMIENTOID',pic:'ZZZ9'},{av:'dynavSatisfaccionprogramadorid'},{av:'AV22SatisfaccionProgramadorId',fld:'vSATISFACCIONPROGRAMADORID',pic:'ZZZ9'},{av:'dynavSatisfaccioncapacitacionid'},{av:'AV23SatisfaccionCapacitacionId',fld:'vSATISFACCIONCAPACITACIONID',pic:'ZZZ9'}]}");
         setEventMetadata("'CANCELAR'","{handler:'E117M2',iparms:[{av:'dynavSatisfaccioncatalogaid'},{av:'AV24SatisfaccionCatalogaId',fld:'vSATISFACCIONCATALOGAID',pic:'ZZZ9'},{av:'dynavSatisfaccionrendimientoid'},{av:'AV21SatisfaccionRendimientoId',fld:'vSATISFACCIONRENDIMIENTOID',pic:'ZZZ9'},{av:'dynavSatisfaccionprogramadorid'},{av:'AV22SatisfaccionProgramadorId',fld:'vSATISFACCIONPROGRAMADORID',pic:'ZZZ9'},{av:'dynavSatisfaccioncapacitacionid'},{av:'AV23SatisfaccionCapacitacionId',fld:'vSATISFACCIONCAPACITACIONID',pic:'ZZZ9'}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavSatisfaccioncatalogaid'},{av:'AV24SatisfaccionCatalogaId',fld:'vSATISFACCIONCATALOGAID',pic:'ZZZ9'},{av:'dynavSatisfaccionrendimientoid'},{av:'AV21SatisfaccionRendimientoId',fld:'vSATISFACCIONRENDIMIENTOID',pic:'ZZZ9'},{av:'dynavSatisfaccionprogramadorid'},{av:'AV22SatisfaccionProgramadorId',fld:'vSATISFACCIONPROGRAMADORID',pic:'ZZZ9'},{av:'dynavSatisfaccioncapacitacionid'},{av:'AV23SatisfaccionCapacitacionId',fld:'vSATISFACCIONCAPACITACIONID',pic:'ZZZ9'}]}");
         setEventMetadata("'GUARDAR'","{handler:'E127M2',iparms:[{av:'AV14TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV17TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV15UsuarioId',fld:'vUSUARIOID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV20SatisfaccionMejoraSoftware',fld:'vSATISFACCIONMEJORASOFTWARE',pic:''},{av:'AV18TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'dynavSatisfaccioncatalogaid'},{av:'AV24SatisfaccionCatalogaId',fld:'vSATISFACCIONCATALOGAID',pic:'ZZZ9'},{av:'dynavSatisfaccionrendimientoid'},{av:'AV21SatisfaccionRendimientoId',fld:'vSATISFACCIONRENDIMIENTOID',pic:'ZZZ9'},{av:'dynavSatisfaccionprogramadorid'},{av:'AV22SatisfaccionProgramadorId',fld:'vSATISFACCIONPROGRAMADORID',pic:'ZZZ9'},{av:'dynavSatisfaccioncapacitacionid'},{av:'AV23SatisfaccionCapacitacionId',fld:'vSATISFACCIONCAPACITACIONID',pic:'ZZZ9'}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavSatisfaccioncatalogaid'},{av:'AV24SatisfaccionCatalogaId',fld:'vSATISFACCIONCATALOGAID',pic:'ZZZ9'},{av:'dynavSatisfaccionrendimientoid'},{av:'AV21SatisfaccionRendimientoId',fld:'vSATISFACCIONRENDIMIENTOID',pic:'ZZZ9'},{av:'dynavSatisfaccionprogramadorid'},{av:'AV22SatisfaccionProgramadorId',fld:'vSATISFACCIONPROGRAMADORID',pic:'ZZZ9'},{av:'dynavSatisfaccioncapacitacionid'},{av:'AV23SatisfaccionCapacitacionId',fld:'vSATISFACCIONCAPACITACIONID',pic:'ZZZ9'}]}");
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
         wcpOAV16UsuarioNombre = "";
         wcpOAV19TicketTecnicoResponsableNombre = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         TempTags = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         AV20SatisfaccionMejoraSoftware = "";
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
         H007M2_A4EstadoSatisfaccionId = new short[1] ;
         H007M2_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H007M3_A4EstadoSatisfaccionId = new short[1] ;
         H007M3_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H007M4_A4EstadoSatisfaccionId = new short[1] ;
         H007M4_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H007M5_A4EstadoSatisfaccionId = new short[1] ;
         H007M5_A22EstadoSatisfaccionNombre = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistrarencuestadesarrollo__default(),
            new Object[][] {
                new Object[] {
               H007M2_A4EstadoSatisfaccionId, H007M2_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H007M3_A4EstadoSatisfaccionId, H007M3_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H007M4_A4EstadoSatisfaccionId, H007M4_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H007M5_A4EstadoSatisfaccionId, H007M5_A22EstadoSatisfaccionNombre
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
         edtavTicketid_Enabled = 0;
         edtavUsuarionombre_Enabled = 0;
         edtavTickettecnicoresponsablenombre_Enabled = 0;
      }

      private short AV18TicketTecnicoResponsableId ;
      private short AV29EtapaDesarrolloId ;
      private short wcpOAV18TicketTecnicoResponsableId ;
      private short wcpOAV29EtapaDesarrolloId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short lblTextblock1_Fontbold ;
      private short AV24SatisfaccionCatalogaId ;
      private short lblTextblock2_Fontbold ;
      private short AV21SatisfaccionRendimientoId ;
      private short lblTextblock3_Fontbold ;
      private short AV22SatisfaccionProgramadorId ;
      private short lblTextblock4_Fontbold ;
      private short AV23SatisfaccionCapacitacionId ;
      private short lblTextblock5_Fontbold ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTicketid_Enabled ;
      private int edtavTicketid_Forecolor ;
      private int edtavUsuarionombre_Forecolor ;
      private int edtavUsuarionombre_Enabled ;
      private int edtavTickettecnicoresponsablenombre_Forecolor ;
      private int edtavTickettecnicoresponsablenombre_Enabled ;
      private int lblTextblock1_Forecolor ;
      private int lblTextblock2_Forecolor ;
      private int lblTextblock3_Forecolor ;
      private int lblTextblock4_Forecolor ;
      private int lblTextblock5_Forecolor ;
      private int edtavSatisfaccionmejorasoftware_Forecolor ;
      private int edtavSatisfaccionmejorasoftware_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV14TicketId ;
      private long AV17TicketResponsableId ;
      private long AV15UsuarioId ;
      private long wcpOAV14TicketId ;
      private long wcpOAV17TicketResponsableId ;
      private long wcpOAV15UsuarioId ;
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
      private string divTable2_Internalname ;
      private string divTable8_Internalname ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtavTicketid_Internalname ;
      private string edtavTicketid_Jsonclick ;
      private string divTable7_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divTable9_Internalname ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtavTickettecnicoresponsablenombre_Internalname ;
      private string TempTags ;
      private string edtavTickettecnicoresponsablenombre_Jsonclick ;
      private string divTable10_Internalname ;
      private string divTable11_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string dynavSatisfaccioncatalogaid_Internalname ;
      private string dynavSatisfaccioncatalogaid_Jsonclick ;
      private string divTable12_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string dynavSatisfaccionrendimientoid_Internalname ;
      private string dynavSatisfaccionrendimientoid_Jsonclick ;
      private string divTable13_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string dynavSatisfaccionprogramadorid_Internalname ;
      private string dynavSatisfaccionprogramadorid_Jsonclick ;
      private string divTable14_Internalname ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string dynavSatisfaccioncapacitacionid_Internalname ;
      private string dynavSatisfaccioncapacitacionid_Jsonclick ;
      private string divTable15_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string edtavSatisfaccionmejorasoftware_Internalname ;
      private string divTable3_Internalname ;
      private string divTable4_Internalname ;
      private string bttGuardar_Internalname ;
      private string bttGuardar_Jsonclick ;
      private string divTable5_Internalname ;
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
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV16UsuarioNombre ;
      private string AV19TicketTecnicoResponsableNombre ;
      private string wcpOAV16UsuarioNombre ;
      private string wcpOAV19TicketTecnicoResponsableNombre ;
      private string AV20SatisfaccionMejoraSoftware ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSatisfaccioncatalogaid ;
      private GXCombobox dynavSatisfaccionrendimientoid ;
      private GXCombobox dynavSatisfaccionprogramadorid ;
      private GXCombobox dynavSatisfaccioncapacitacionid ;
      private IDataStoreProvider pr_default ;
      private short[] H007M2_A4EstadoSatisfaccionId ;
      private string[] H007M2_A22EstadoSatisfaccionNombre ;
      private short[] H007M3_A4EstadoSatisfaccionId ;
      private string[] H007M3_A22EstadoSatisfaccionNombre ;
      private short[] H007M4_A4EstadoSatisfaccionId ;
      private string[] H007M4_A22EstadoSatisfaccionNombre ;
      private short[] H007M5_A4EstadoSatisfaccionId ;
      private string[] H007M5_A22EstadoSatisfaccionNombre ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wpregistrarencuestadesarrollo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH007M2;
          prmH007M2 = new Object[] {
          };
          Object[] prmH007M3;
          prmH007M3 = new Object[] {
          };
          Object[] prmH007M4;
          prmH007M4 = new Object[] {
          };
          Object[] prmH007M5;
          prmH007M5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H007M2", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = 6 or [EstadoSatisfaccionId] = 7 or [EstadoSatisfaccionId] = 8 or [EstadoSatisfaccionId] = 9 or [EstadoSatisfaccionId] = 10 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007M3", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = 6 or [EstadoSatisfaccionId] = 7 or [EstadoSatisfaccionId] = 8 or [EstadoSatisfaccionId] = 9 or [EstadoSatisfaccionId] = 10 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007M4", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = 6 or [EstadoSatisfaccionId] = 7 or [EstadoSatisfaccionId] = 8 or [EstadoSatisfaccionId] = 9 or [EstadoSatisfaccionId] = 10 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H007M5", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = 6 or [EstadoSatisfaccionId] = 7 or [EstadoSatisfaccionId] = 8 or [EstadoSatisfaccionId] = 9 or [EstadoSatisfaccionId] = 10 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH007M5,0, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
