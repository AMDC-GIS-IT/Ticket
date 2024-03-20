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
   public class wpregistrarsatisfaccion : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wpregistrarsatisfaccion( )
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

      public wpregistrarsatisfaccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( long aP0_TicketId ,
                           long aP1_TicketResponsableId ,
                           short aP2_UsuarioId ,
                           string aP3_UsuarioNombre ,
                           short aP4_TicketTecnicoResponsableId ,
                           string aP5_TicketTecnicoResponsableNombre )
      {
         this.AV5TicketId = aP0_TicketId;
         this.AV17TicketResponsableId = aP1_TicketResponsableId;
         this.AV6UsuarioId = aP2_UsuarioId;
         this.AV7UsuarioNombre = aP3_UsuarioNombre;
         this.AV18TicketTecnicoResponsableId = aP4_TicketTecnicoResponsableId;
         this.AV19TicketTecnicoResponsableNombre = aP5_TicketTecnicoResponsableNombre;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         dynavSatisfaccionresueltoid = new GXCombobox();
         dynavSatisfacciontecnicoproblemaid = new GXCombobox();
         dynavSatisfacciontecnicocompetenteid = new GXCombobox();
         dynavSatisfacciontecnicoprofesionalismoid = new GXCombobox();
         dynavSatisfacciontiempoid = new GXCombobox();
         dynavSatisfaccionatencionid = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONRESUELTOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONRESUELTOID5V2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONTECNICOPROBLEMAID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONTECNICOPROBLEMAID5V2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONTECNICOCOMPETENTEID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONTECNICOCOMPETENTEID5V2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONTECNICOPROFESIONALISMOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONTECNICOPROFESIONALISMOID5V2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONTIEMPOID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONTIEMPOID5V2( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vSATISFACCIONATENCIONID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvSATISFACCIONATENCIONID5V2( ) ;
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
               AV5TicketId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV5TicketId", StringUtil.LTrimStr( (decimal)(AV5TicketId), 10, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5TicketId), "ZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV17TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
                  AssignAttri("", false, "AV17TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV17TicketResponsableId), 10, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
                  AV6UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AssignAttri("", false, "AV6UsuarioId", StringUtil.LTrimStr( (decimal)(AV6UsuarioId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6UsuarioId), "ZZZ9"), context));
                  AV7UsuarioNombre = GetPar( "UsuarioNombre");
                  AssignAttri("", false, "AV7UsuarioNombre", AV7UsuarioNombre);
                  AV18TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
                  AssignAttri("", false, "AV18TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV18TicketTecnicoResponsableId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
                  AV19TicketTecnicoResponsableNombre = GetPar( "TicketTecnicoResponsableNombre");
                  AssignAttri("", false, "AV19TicketTecnicoResponsableNombre", AV19TicketTecnicoResponsableNombre);
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
         PA5V2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5V2( ) ;
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20231249565571", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpregistrarsatisfaccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV17TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV6UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(AV7UsuarioNombre)),UrlEncode(StringUtil.LTrimStr(AV18TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV19TicketTecnicoResponsableNombre))}, new string[] {"TicketId","TicketResponsableId","UsuarioId","UsuarioNombre","TicketTecnicoResponsableId","TicketTecnicoResponsableNombre"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5TicketId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6UsuarioId), "ZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TicketTecnicoResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLENOMBRE", AV19TicketTecnicoResponsableNombre);
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONRESUELTOID_Text", StringUtil.RTrim( dynavSatisfaccionresueltoid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONTECNICOPROBLEMAID_Text", StringUtil.RTrim( dynavSatisfacciontecnicoproblemaid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONTECNICOCOMPETENTEID_Text", StringUtil.RTrim( dynavSatisfacciontecnicocompetenteid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONTECNICOPROFESIONALISMOID_Text", StringUtil.RTrim( dynavSatisfacciontecnicoprofesionalismoid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONTIEMPOID_Text", StringUtil.RTrim( dynavSatisfacciontiempoid.Description));
         GxWebStd.gx_hidden_field( context, "vSATISFACCIONATENCIONID_Text", StringUtil.RTrim( dynavSatisfaccionatencionid.Description));
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
            WE5V2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5V2( ) ;
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
         return formatLink("wpregistrarsatisfaccion.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV5TicketId,10,0)),UrlEncode(StringUtil.LTrimStr(AV17TicketResponsableId,10,0)),UrlEncode(StringUtil.LTrimStr(AV6UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(AV7UsuarioNombre)),UrlEncode(StringUtil.LTrimStr(AV18TicketTecnicoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV19TicketTecnicoResponsableNombre))}, new string[] {"TicketId","TicketResponsableId","UsuarioId","UsuarioNombre","TicketTecnicoResponsableId","TicketTecnicoResponsableNombre"})  ;
      }

      public override string GetPgmname( )
      {
         return "WPRegistrarSatisfaccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Llenar Encuesta Satisfacción" ;
      }

      protected void WB5V0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable6_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Ticket:", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTicketid_Internalname, "Ticket Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavTicketid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5TicketId), 10, 0, ",", "")), ((edtavTicketid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5TicketId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(AV5TicketId), "ZZZZZZZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTicketid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavTicketid_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable8_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Id Usuario:", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsuarioid_Internalname, "Usuario Id", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavUsuarioid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6UsuarioId), 4, 0, ",", "")), ((edtavUsuarioid_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(AV6UsuarioId), "ZZZ9")) : context.localUtil.Format( (decimal)(AV6UsuarioId), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarioid_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarioid_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable18_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Id Tecnico:", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTicketTecnicoResponsableId_Internalname, "Id Tecnico", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTicketTecnicoResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ",", "")), ((edtTicketTecnicoResponsableId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")) : context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoResponsableId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTicketTecnicoResponsableId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable19_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable7_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Usuario:", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavUsuarionombre_Internalname, AV7UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( AV7UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsuarionombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavUsuarionombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WPRegistrarSatisfaccion.htm");
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Técnico:", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtTicketTecnicoResponsableNombre_Internalname, "Técnico", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtTicketTecnicoResponsableNombre_Internalname, A199TicketTecnicoResponsableNombre, StringUtil.RTrim( context.localUtil.Format( A199TicketTecnicoResponsableNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoResponsableNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTicketTecnicoResponsableNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_WPRegistrarSatisfaccion.htm");
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
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "¿Considera resuelto el requerimiento?", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSatisfaccionresueltoid_Internalname, "Satisfaccion Resuelto Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfaccionresueltoid, dynavSatisfaccionresueltoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10SatisfaccionResueltoId), 4, 0)), 1, dynavSatisfaccionresueltoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfaccionresueltoid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 1, "HLP_WPRegistrarSatisfaccion.htm");
            dynavSatisfaccionresueltoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10SatisfaccionResueltoId), 4, 0));
            AssignProp("", false, dynavSatisfaccionresueltoid_Internalname, "Values", (string)(dynavSatisfaccionresueltoid.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "¿El técnico pudo identificar rápidamente el problema?", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSatisfacciontecnicoproblemaid_Internalname, "Satisfaccion Tecnico Problema Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfacciontecnicoproblemaid, dynavSatisfacciontecnicoproblemaid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV11SatisfaccionTecnicoProblemaId), 4, 0)), 1, dynavSatisfacciontecnicoproblemaid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfacciontecnicoproblemaid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", true, 1, "HLP_WPRegistrarSatisfaccion.htm");
            dynavSatisfacciontecnicoproblemaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11SatisfaccionTecnicoProblemaId), 4, 0));
            AssignProp("", false, dynavSatisfacciontecnicoproblemaid_Internalname, "Values", (string)(dynavSatisfacciontecnicoproblemaid.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "¿El técnico parece muy bien informado y competente?", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSatisfacciontecnicocompetenteid_Internalname, "Satisfaccion Tecnico Competente Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfacciontecnicocompetenteid, dynavSatisfacciontecnicocompetenteid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV12SatisfaccionTecnicoCompetenteId), 4, 0)), 1, dynavSatisfacciontecnicocompetenteid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfacciontecnicocompetenteid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 1, "HLP_WPRegistrarSatisfaccion.htm");
            dynavSatisfacciontecnicocompetenteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12SatisfaccionTecnicoCompetenteId), 4, 0));
            AssignProp("", false, dynavSatisfacciontecnicocompetenteid_Internalname, "Values", (string)(dynavSatisfacciontecnicocompetenteid.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "¿El técnico maneja los problemas con cortesía y profesionalismo?", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSatisfacciontecnicoprofesionalismoid_Internalname, "Satisfaccion Tecnico Profesionalismo Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfacciontecnicoprofesionalismoid, dynavSatisfacciontecnicoprofesionalismoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV13SatisfaccionTecnicoProfesionalismoId), 4, 0)), 1, dynavSatisfacciontecnicoprofesionalismoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfacciontecnicoprofesionalismoid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 1, "HLP_WPRegistrarSatisfaccion.htm");
            dynavSatisfacciontecnicoprofesionalismoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13SatisfaccionTecnicoProfesionalismoId), 4, 0));
            AssignProp("", false, dynavSatisfacciontecnicoprofesionalismoid_Internalname, "Values", (string)(dynavSatisfacciontecnicoprofesionalismoid.ToJavascriptSource()), true);
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
            GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Conforme con el tiempo resuelto su requerimiento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSatisfacciontiempoid_Internalname, "Satisfaccion Tiempo Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfacciontiempoid, dynavSatisfacciontiempoid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14SatisfaccionTiempoId), 4, 0)), 1, dynavSatisfacciontiempoid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfacciontiempoid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "", true, 1, "HLP_WPRegistrarSatisfaccion.htm");
            dynavSatisfacciontiempoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SatisfaccionTiempoId), 4, 0));
            AssignProp("", false, dynavSatisfacciontiempoid_Internalname, "Values", (string)(dynavSatisfacciontiempoid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "En general, ¿qué tan satisfecho está usted con la atención recibida?", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavSatisfaccionatencionid_Internalname, "Satisfaccion Atencion Id", "col-sm-3 AttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavSatisfaccionatencionid, dynavSatisfaccionatencionid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV15SatisfaccionAtencionId), 4, 0)), 1, dynavSatisfaccionatencionid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavSatisfaccionatencionid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "", true, 1, "HLP_WPRegistrarSatisfaccion.htm");
            dynavSatisfaccionatencionid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15SatisfaccionAtencionId), 4, 0));
            AssignProp("", false, dynavSatisfaccionatencionid_Internalname, "Values", (string)(dynavSatisfaccionatencionid.ToJavascriptSource()), true);
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
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "¿Tiene algún comentario o sugerencia adicional que hacernos sobre el soporte técnico recibido?", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_WPRegistrarSatisfaccion.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavSatisfaccionsugerencia_Internalname, "Satisfaccion Sugerencia", "col-sm-3 AttributeLabel", 0, true, "");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavSatisfaccionsugerencia_Internalname, AV16SatisfaccionSugerencia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", 0, 1, edtavSatisfaccionsugerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_WPRegistrarSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGuardar_Internalname, "", "Guardar", bttGuardar_Jsonclick, 5, "Guardar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'GUARDAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarSatisfaccion.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttCancelar_Internalname, "", "Cancelar", bttCancelar_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'CANCELAR\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WPRegistrarSatisfaccion.htm");
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

      protected void START5V2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
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
         STRUP5V0( ) ;
      }

      protected void WS5V2( )
      {
         START5V2( ) ;
         EVT5V2( ) ;
      }

      protected void EVT5V2( )
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
                              E115V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'GUARDAR'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'Guardar' */
                              E125V2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E135V2 ();
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

      protected void WE5V2( )
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

      protected void PA5V2( )
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
               GX_FocusControl = dynavSatisfaccionresueltoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvSATISFACCIONRESUELTOID5V2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONRESUELTOID_data5V2( ) ;
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

      protected void GXVvSATISFACCIONRESUELTOID_html5V2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONRESUELTOID_data5V2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfaccionresueltoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfaccionresueltoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONRESUELTOID_data5V2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005V2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005V2_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005V2_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void GXDLVvSATISFACCIONTECNICOPROBLEMAID5V2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONTECNICOPROBLEMAID_data5V2( ) ;
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

      protected void GXVvSATISFACCIONTECNICOPROBLEMAID_html5V2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONTECNICOPROBLEMAID_data5V2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfacciontecnicoproblemaid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfacciontecnicoproblemaid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONTECNICOPROBLEMAID_data5V2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005V3 */
         pr_default.execute(1);
         while ( (pr_default.getStatus(1) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005V3_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005V3_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(1);
         }
         pr_default.close(1);
      }

      protected void GXDLVvSATISFACCIONTECNICOCOMPETENTEID5V2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONTECNICOCOMPETENTEID_data5V2( ) ;
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

      protected void GXVvSATISFACCIONTECNICOCOMPETENTEID_html5V2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONTECNICOCOMPETENTEID_data5V2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfacciontecnicocompetenteid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfacciontecnicocompetenteid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONTECNICOCOMPETENTEID_data5V2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005V4 */
         pr_default.execute(2);
         while ( (pr_default.getStatus(2) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005V4_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005V4_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void GXDLVvSATISFACCIONTECNICOPROFESIONALISMOID5V2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONTECNICOPROFESIONALISMOID_data5V2( ) ;
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

      protected void GXVvSATISFACCIONTECNICOPROFESIONALISMOID_html5V2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONTECNICOPROFESIONALISMOID_data5V2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfacciontecnicoprofesionalismoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfacciontecnicoprofesionalismoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONTECNICOPROFESIONALISMOID_data5V2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005V5 */
         pr_default.execute(3);
         while ( (pr_default.getStatus(3) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005V5_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005V5_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void GXDLVvSATISFACCIONTIEMPOID5V2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONTIEMPOID_data5V2( ) ;
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

      protected void GXVvSATISFACCIONTIEMPOID_html5V2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONTIEMPOID_data5V2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfacciontiempoid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfacciontiempoid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONTIEMPOID_data5V2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005V6 */
         pr_default.execute(4);
         while ( (pr_default.getStatus(4) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005V6_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005V6_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(4);
         }
         pr_default.close(4);
      }

      protected void GXDLVvSATISFACCIONATENCIONID5V2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvSATISFACCIONATENCIONID_data5V2( ) ;
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

      protected void GXVvSATISFACCIONATENCIONID_html5V2( )
      {
         short gxdynajaxvalue;
         GXDLVvSATISFACCIONATENCIONID_data5V2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavSatisfaccionatencionid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavSatisfaccionatencionid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvSATISFACCIONATENCIONID_data5V2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("(Ninguno)");
         /* Using cursor H005V7 */
         pr_default.execute(5);
         while ( (pr_default.getStatus(5) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H005V7_A4EstadoSatisfaccionId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(H005V7_A22EstadoSatisfaccionNombre[0]);
            pr_default.readNext(5);
         }
         pr_default.close(5);
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvSATISFACCIONRESUELTOID_html5V2( ) ;
            GXVvSATISFACCIONTECNICOPROBLEMAID_html5V2( ) ;
            GXVvSATISFACCIONTECNICOCOMPETENTEID_html5V2( ) ;
            GXVvSATISFACCIONTECNICOPROFESIONALISMOID_html5V2( ) ;
            GXVvSATISFACCIONTIEMPOID_html5V2( ) ;
            GXVvSATISFACCIONATENCIONID_html5V2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavSatisfaccionresueltoid.ItemCount > 0 )
         {
            AV10SatisfaccionResueltoId = (short)(NumberUtil.Val( dynavSatisfaccionresueltoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10SatisfaccionResueltoId), 4, 0))), "."));
            AssignAttri("", false, "AV10SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(AV10SatisfaccionResueltoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfaccionresueltoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10SatisfaccionResueltoId), 4, 0));
            AssignProp("", false, dynavSatisfaccionresueltoid_Internalname, "Values", dynavSatisfaccionresueltoid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfacciontecnicoproblemaid.ItemCount > 0 )
         {
            AV11SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( dynavSatisfacciontecnicoproblemaid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV11SatisfaccionTecnicoProblemaId), 4, 0))), "."));
            AssignAttri("", false, "AV11SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV11SatisfaccionTecnicoProblemaId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfacciontecnicoproblemaid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV11SatisfaccionTecnicoProblemaId), 4, 0));
            AssignProp("", false, dynavSatisfacciontecnicoproblemaid_Internalname, "Values", dynavSatisfacciontecnicoproblemaid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfacciontecnicocompetenteid.ItemCount > 0 )
         {
            AV12SatisfaccionTecnicoCompetenteId = (short)(NumberUtil.Val( dynavSatisfacciontecnicocompetenteid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV12SatisfaccionTecnicoCompetenteId), 4, 0))), "."));
            AssignAttri("", false, "AV12SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(AV12SatisfaccionTecnicoCompetenteId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfacciontecnicocompetenteid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV12SatisfaccionTecnicoCompetenteId), 4, 0));
            AssignProp("", false, dynavSatisfacciontecnicocompetenteid_Internalname, "Values", dynavSatisfacciontecnicocompetenteid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfacciontecnicoprofesionalismoid.ItemCount > 0 )
         {
            AV13SatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( dynavSatisfacciontecnicoprofesionalismoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV13SatisfaccionTecnicoProfesionalismoId), 4, 0))), "."));
            AssignAttri("", false, "AV13SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(AV13SatisfaccionTecnicoProfesionalismoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfacciontecnicoprofesionalismoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV13SatisfaccionTecnicoProfesionalismoId), 4, 0));
            AssignProp("", false, dynavSatisfacciontecnicoprofesionalismoid_Internalname, "Values", dynavSatisfacciontecnicoprofesionalismoid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfacciontiempoid.ItemCount > 0 )
         {
            AV14SatisfaccionTiempoId = (short)(NumberUtil.Val( dynavSatisfacciontiempoid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14SatisfaccionTiempoId), 4, 0))), "."));
            AssignAttri("", false, "AV14SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(AV14SatisfaccionTiempoId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfacciontiempoid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14SatisfaccionTiempoId), 4, 0));
            AssignProp("", false, dynavSatisfacciontiempoid_Internalname, "Values", dynavSatisfacciontiempoid.ToJavascriptSource(), true);
         }
         if ( dynavSatisfaccionatencionid.ItemCount > 0 )
         {
            AV15SatisfaccionAtencionId = (short)(NumberUtil.Val( dynavSatisfaccionatencionid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV15SatisfaccionAtencionId), 4, 0))), "."));
            AssignAttri("", false, "AV15SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(AV15SatisfaccionAtencionId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavSatisfaccionatencionid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV15SatisfaccionAtencionId), 4, 0));
            AssignProp("", false, dynavSatisfaccionatencionid_Internalname, "Values", dynavSatisfaccionatencionid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5V2( ) ;
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

      protected void RF5V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H005V8 */
            pr_default.execute(6);
            while ( (pr_default.getStatus(6) != 101) )
            {
               A199TicketTecnicoResponsableNombre = H005V8_A199TicketTecnicoResponsableNombre[0];
               AssignAttri("", false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
               A198TicketTecnicoResponsableId = H005V8_A198TicketTecnicoResponsableId[0];
               AssignAttri("", false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
               A199TicketTecnicoResponsableNombre = H005V8_A199TicketTecnicoResponsableNombre[0];
               AssignAttri("", false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
               GXVvSATISFACCIONRESUELTOID_html5V2( ) ;
               GXVvSATISFACCIONTECNICOPROBLEMAID_html5V2( ) ;
               GXVvSATISFACCIONTECNICOCOMPETENTEID_html5V2( ) ;
               GXVvSATISFACCIONTECNICOPROFESIONALISMOID_html5V2( ) ;
               GXVvSATISFACCIONTIEMPOID_html5V2( ) ;
               GXVvSATISFACCIONATENCIONID_html5V2( ) ;
               /* Execute user event: Load */
               E135V2 ();
               pr_default.readNext(6);
            }
            pr_default.close(6);
            WB5V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5V2( )
      {
         GxWebStd.gx_hidden_field( context, "vTICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17TicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTICKETTECNICORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18TicketTecnicoResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvSATISFACCIONRESUELTOID_html5V2( ) ;
         GXVvSATISFACCIONTECNICOPROBLEMAID_html5V2( ) ;
         GXVvSATISFACCIONTECNICOCOMPETENTEID_html5V2( ) ;
         GXVvSATISFACCIONTECNICOPROFESIONALISMOID_html5V2( ) ;
         GXVvSATISFACCIONTIEMPOID_html5V2( ) ;
         GXVvSATISFACCIONATENCIONID_html5V2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5V0( )
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
            A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ",", "."));
            AssignAttri("", false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
            A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
            AssignAttri("", false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
            dynavSatisfaccionresueltoid.CurrentValue = cgiGet( dynavSatisfaccionresueltoid_Internalname);
            AV10SatisfaccionResueltoId = (short)(NumberUtil.Val( cgiGet( dynavSatisfaccionresueltoid_Internalname), "."));
            AssignAttri("", false, "AV10SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(AV10SatisfaccionResueltoId), 4, 0));
            dynavSatisfacciontecnicoproblemaid.CurrentValue = cgiGet( dynavSatisfacciontecnicoproblemaid_Internalname);
            AV11SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( cgiGet( dynavSatisfacciontecnicoproblemaid_Internalname), "."));
            AssignAttri("", false, "AV11SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV11SatisfaccionTecnicoProblemaId), 4, 0));
            dynavSatisfacciontecnicocompetenteid.CurrentValue = cgiGet( dynavSatisfacciontecnicocompetenteid_Internalname);
            AV12SatisfaccionTecnicoCompetenteId = (short)(NumberUtil.Val( cgiGet( dynavSatisfacciontecnicocompetenteid_Internalname), "."));
            AssignAttri("", false, "AV12SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(AV12SatisfaccionTecnicoCompetenteId), 4, 0));
            dynavSatisfacciontecnicoprofesionalismoid.CurrentValue = cgiGet( dynavSatisfacciontecnicoprofesionalismoid_Internalname);
            AV13SatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( cgiGet( dynavSatisfacciontecnicoprofesionalismoid_Internalname), "."));
            AssignAttri("", false, "AV13SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(AV13SatisfaccionTecnicoProfesionalismoId), 4, 0));
            dynavSatisfacciontiempoid.CurrentValue = cgiGet( dynavSatisfacciontiempoid_Internalname);
            AV14SatisfaccionTiempoId = (short)(NumberUtil.Val( cgiGet( dynavSatisfacciontiempoid_Internalname), "."));
            AssignAttri("", false, "AV14SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(AV14SatisfaccionTiempoId), 4, 0));
            dynavSatisfaccionatencionid.CurrentValue = cgiGet( dynavSatisfaccionatencionid_Internalname);
            AV15SatisfaccionAtencionId = (short)(NumberUtil.Val( cgiGet( dynavSatisfaccionatencionid_Internalname), "."));
            AssignAttri("", false, "AV15SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(AV15SatisfaccionAtencionId), 4, 0));
            AV16SatisfaccionSugerencia = cgiGet( edtavSatisfaccionsugerencia_Internalname);
            AssignAttri("", false, "AV16SatisfaccionSugerencia", AV16SatisfaccionSugerencia);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXVvSATISFACCIONRESUELTOID_html5V2( ) ;
            GXVvSATISFACCIONTECNICOPROBLEMAID_html5V2( ) ;
            GXVvSATISFACCIONTECNICOCOMPETENTEID_html5V2( ) ;
            GXVvSATISFACCIONTECNICOPROFESIONALISMOID_html5V2( ) ;
            GXVvSATISFACCIONTIEMPOID_html5V2( ) ;
            GXVvSATISFACCIONATENCIONID_html5V2( ) ;
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E115V2( )
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

      protected void E125V2( )
      {
         /* 'Guardar' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(dynavSatisfaccionresueltoid.Description, "(Ninguno)") == 0 )
         {
            context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
         }
         else
         {
            if ( StringUtil.StrCmp(dynavSatisfacciontecnicoproblemaid.Description, "(Ninguno)") == 0 )
            {
               context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
            }
            else
            {
               if ( StringUtil.StrCmp(dynavSatisfacciontecnicocompetenteid.Description, "(Ninguno)") == 0 )
               {
                  context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
               }
               else
               {
                  if ( StringUtil.StrCmp(dynavSatisfacciontecnicoprofesionalismoid.Description, "(Ninguno)") == 0 )
                  {
                     context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(dynavSatisfacciontiempoid.Description, "(Ninguno)") == 0 )
                     {
                        context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
                     }
                     else
                     {
                        if ( StringUtil.StrCmp(dynavSatisfaccionatencionid.Description, "(Ninguno)") == 0 )
                        {
                           context.PopUp(formatLink("webpanelmsgsatisfaccion.aspx") , new Object[] {});
                        }
                        else
                        {
                           new pcrinsertsatisfaccion(context ).execute(  AV5TicketId,  AV17TicketResponsableId,  AV6UsuarioId,  AV10SatisfaccionResueltoId,  AV11SatisfaccionTecnicoProblemaId,  AV12SatisfaccionTecnicoCompetenteId,  AV13SatisfaccionTecnicoProfesionalismoId,  AV14SatisfaccionTiempoId,  AV15SatisfaccionAtencionId,  AV16SatisfaccionSugerencia,  AV18TicketTecnicoResponsableId) ;
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

      protected void nextLoad( )
      {
      }

      protected void E135V2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5TicketId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV5TicketId", StringUtil.LTrimStr( (decimal)(AV5TicketId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV5TicketId), "ZZZZZZZZZ9"), context));
         AV17TicketResponsableId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV17TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV17TicketResponsableId), 10, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETRESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV17TicketResponsableId), "ZZZZZZZZZ9"), context));
         AV6UsuarioId = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV6UsuarioId", StringUtil.LTrimStr( (decimal)(AV6UsuarioId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSUARIOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV6UsuarioId), "ZZZ9"), context));
         AV7UsuarioNombre = (string)getParm(obj,3);
         AssignAttri("", false, "AV7UsuarioNombre", AV7UsuarioNombre);
         AV18TicketTecnicoResponsableId = Convert.ToInt16(getParm(obj,4));
         AssignAttri("", false, "AV18TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(AV18TicketTecnicoResponsableId), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vTICKETTECNICORESPONSABLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV18TicketTecnicoResponsableId), "ZZZ9"), context));
         AV19TicketTecnicoResponsableNombre = (string)getParm(obj,5);
         AssignAttri("", false, "AV19TicketTecnicoResponsableNombre", AV19TicketTecnicoResponsableNombre);
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
         PA5V2( ) ;
         WS5V2( ) ;
         WE5V2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249565662", true, true);
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
         context.AddJavascriptSource("wpregistrarsatisfaccion.js", "?20231249565662", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         dynavSatisfaccionresueltoid.Name = "vSATISFACCIONRESUELTOID";
         dynavSatisfaccionresueltoid.WebTags = "";
         dynavSatisfacciontecnicoproblemaid.Name = "vSATISFACCIONTECNICOPROBLEMAID";
         dynavSatisfacciontecnicoproblemaid.WebTags = "";
         dynavSatisfacciontecnicocompetenteid.Name = "vSATISFACCIONTECNICOCOMPETENTEID";
         dynavSatisfacciontecnicocompetenteid.WebTags = "";
         dynavSatisfacciontecnicoprofesionalismoid.Name = "vSATISFACCIONTECNICOPROFESIONALISMOID";
         dynavSatisfacciontecnicoprofesionalismoid.WebTags = "";
         dynavSatisfacciontiempoid.Name = "vSATISFACCIONTIEMPOID";
         dynavSatisfacciontiempoid.WebTags = "";
         dynavSatisfaccionatencionid.Name = "vSATISFACCIONATENCIONID";
         dynavSatisfaccionatencionid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtavTicketid_Internalname = "vTICKETID";
         divTable6_Internalname = "TABLE6";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtavUsuarioid_Internalname = "vUSUARIOID";
         divTable8_Internalname = "TABLE8";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtTicketTecnicoResponsableId_Internalname = "TICKETTECNICORESPONSABLEID";
         divTable18_Internalname = "TABLE18";
         divTable19_Internalname = "TABLE19";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtavUsuarionombre_Internalname = "vUSUARIONOMBRE";
         divTable7_Internalname = "TABLE7";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtTicketTecnicoResponsableNombre_Internalname = "TICKETTECNICORESPONSABLENOMBRE";
         divTable9_Internalname = "TABLE9";
         divTable2_Internalname = "TABLE2";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         dynavSatisfaccionresueltoid_Internalname = "vSATISFACCIONRESUELTOID";
         divTable11_Internalname = "TABLE11";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         dynavSatisfacciontecnicoproblemaid_Internalname = "vSATISFACCIONTECNICOPROBLEMAID";
         divTable12_Internalname = "TABLE12";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         dynavSatisfacciontecnicocompetenteid_Internalname = "vSATISFACCIONTECNICOCOMPETENTEID";
         divTable13_Internalname = "TABLE13";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         dynavSatisfacciontecnicoprofesionalismoid_Internalname = "vSATISFACCIONTECNICOPROFESIONALISMOID";
         divTable14_Internalname = "TABLE14";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         dynavSatisfacciontiempoid_Internalname = "vSATISFACCIONTIEMPOID";
         divTable15_Internalname = "TABLE15";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         dynavSatisfaccionatencionid_Internalname = "vSATISFACCIONATENCIONID";
         divTable16_Internalname = "TABLE16";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtavSatisfaccionsugerencia_Internalname = "vSATISFACCIONSUGERENCIA";
         divTable17_Internalname = "TABLE17";
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
         edtavSatisfaccionsugerencia_Enabled = 1;
         dynavSatisfaccionatencionid_Jsonclick = "";
         dynavSatisfaccionatencionid.Enabled = 1;
         dynavSatisfacciontiempoid_Jsonclick = "";
         dynavSatisfacciontiempoid.Enabled = 1;
         dynavSatisfacciontecnicoprofesionalismoid_Jsonclick = "";
         dynavSatisfacciontecnicoprofesionalismoid.Enabled = 1;
         dynavSatisfacciontecnicocompetenteid_Jsonclick = "";
         dynavSatisfacciontecnicocompetenteid.Enabled = 1;
         dynavSatisfacciontecnicoproblemaid_Jsonclick = "";
         dynavSatisfacciontecnicoproblemaid.Enabled = 1;
         dynavSatisfaccionresueltoid_Jsonclick = "";
         dynavSatisfaccionresueltoid.Enabled = 1;
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         edtTicketTecnicoResponsableNombre_Enabled = 0;
         edtavUsuarionombre_Jsonclick = "";
         edtavUsuarionombre_Enabled = 0;
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtTicketTecnicoResponsableId_Enabled = 0;
         edtavUsuarioid_Jsonclick = "";
         edtavUsuarioid_Enabled = 0;
         edtavTicketid_Jsonclick = "";
         edtavTicketid_Enabled = 0;
         dynavSatisfaccionatencionid.Description = "";
         dynavSatisfacciontiempoid.Description = "";
         dynavSatisfacciontecnicoprofesionalismoid.Description = "";
         dynavSatisfacciontecnicocompetenteid.Description = "";
         dynavSatisfacciontecnicoproblemaid.Description = "";
         dynavSatisfaccionresueltoid.Description = "";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV17TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV18TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'AV5TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV6UsuarioId',fld:'vUSUARIOID',pic:'ZZZ9',hsh:true},{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]}");
         setEventMetadata("'CANCELAR'","{handler:'E115V2',iparms:[{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]");
         setEventMetadata("'CANCELAR'",",oparms:[{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]}");
         setEventMetadata("'GUARDAR'","{handler:'E125V2',iparms:[{av:'AV5TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV17TicketResponsableId',fld:'vTICKETRESPONSABLEID',pic:'ZZZZZZZZZ9',hsh:true},{av:'AV6UsuarioId',fld:'vUSUARIOID',pic:'ZZZ9',hsh:true},{av:'AV16SatisfaccionSugerencia',fld:'vSATISFACCIONSUGERENCIA',pic:''},{av:'AV18TicketTecnicoResponsableId',fld:'vTICKETTECNICORESPONSABLEID',pic:'ZZZ9',hsh:true},{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]");
         setEventMetadata("'GUARDAR'",",oparms:[{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[{av:'dynavSatisfaccionresueltoid'},{av:'AV10SatisfaccionResueltoId',fld:'vSATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoproblemaid'},{av:'AV11SatisfaccionTecnicoProblemaId',fld:'vSATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicocompetenteid'},{av:'AV12SatisfaccionTecnicoCompetenteId',fld:'vSATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'dynavSatisfacciontecnicoprofesionalismoid'},{av:'AV13SatisfaccionTecnicoProfesionalismoId',fld:'vSATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'dynavSatisfacciontiempoid'},{av:'AV14SatisfaccionTiempoId',fld:'vSATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'dynavSatisfaccionatencionid'},{av:'AV15SatisfaccionAtencionId',fld:'vSATISFACCIONATENCIONID',pic:'ZZZ9'}]}");
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
         wcpOAV7UsuarioNombre = "";
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
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A199TicketTecnicoResponsableNombre = "";
         lblTextblock1_Jsonclick = "";
         TempTags = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         AV16SatisfaccionSugerencia = "";
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
         H005V2_A4EstadoSatisfaccionId = new short[1] ;
         H005V2_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H005V3_A4EstadoSatisfaccionId = new short[1] ;
         H005V3_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H005V4_A4EstadoSatisfaccionId = new short[1] ;
         H005V4_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H005V5_A4EstadoSatisfaccionId = new short[1] ;
         H005V5_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H005V6_A4EstadoSatisfaccionId = new short[1] ;
         H005V6_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H005V7_A4EstadoSatisfaccionId = new short[1] ;
         H005V7_A22EstadoSatisfaccionNombre = new string[] {""} ;
         H005V8_A14TicketId = new long[1] ;
         H005V8_A16TicketResponsableId = new long[1] ;
         H005V8_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         H005V8_A198TicketTecnicoResponsableId = new short[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpregistrarsatisfaccion__default(),
            new Object[][] {
                new Object[] {
               H005V2_A4EstadoSatisfaccionId, H005V2_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H005V3_A4EstadoSatisfaccionId, H005V3_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H005V4_A4EstadoSatisfaccionId, H005V4_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H005V5_A4EstadoSatisfaccionId, H005V5_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H005V6_A4EstadoSatisfaccionId, H005V6_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H005V7_A4EstadoSatisfaccionId, H005V7_A22EstadoSatisfaccionNombre
               }
               , new Object[] {
               H005V8_A14TicketId, H005V8_A16TicketResponsableId, H005V8_A199TicketTecnicoResponsableNombre, H005V8_A198TicketTecnicoResponsableId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV6UsuarioId ;
      private short AV18TicketTecnicoResponsableId ;
      private short wcpOAV6UsuarioId ;
      private short wcpOAV18TicketTecnicoResponsableId ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A198TicketTecnicoResponsableId ;
      private short AV10SatisfaccionResueltoId ;
      private short AV11SatisfaccionTecnicoProblemaId ;
      private short AV12SatisfaccionTecnicoCompetenteId ;
      private short AV13SatisfaccionTecnicoProfesionalismoId ;
      private short AV14SatisfaccionTiempoId ;
      private short AV15SatisfaccionAtencionId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavTicketid_Enabled ;
      private int edtavUsuarioid_Enabled ;
      private int edtTicketTecnicoResponsableId_Enabled ;
      private int edtavUsuarionombre_Enabled ;
      private int edtTicketTecnicoResponsableNombre_Enabled ;
      private int edtavSatisfaccionsugerencia_Enabled ;
      private int gxdynajaxindex ;
      private int idxLst ;
      private long AV5TicketId ;
      private long AV17TicketResponsableId ;
      private long wcpOAV5TicketId ;
      private long wcpOAV17TicketResponsableId ;
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
      private string divTable6_Internalname ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtavTicketid_Internalname ;
      private string edtavTicketid_Jsonclick ;
      private string divTable8_Internalname ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtavUsuarioid_Internalname ;
      private string edtavUsuarioid_Jsonclick ;
      private string divTable18_Internalname ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string divTable19_Internalname ;
      private string divTable7_Internalname ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtavUsuarionombre_Internalname ;
      private string edtavUsuarionombre_Jsonclick ;
      private string divTable9_Internalname ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private string divTable10_Internalname ;
      private string divTable11_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string dynavSatisfaccionresueltoid_Internalname ;
      private string TempTags ;
      private string dynavSatisfaccionresueltoid_Jsonclick ;
      private string divTable12_Internalname ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string dynavSatisfacciontecnicoproblemaid_Internalname ;
      private string dynavSatisfacciontecnicoproblemaid_Jsonclick ;
      private string divTable13_Internalname ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string dynavSatisfacciontecnicocompetenteid_Internalname ;
      private string dynavSatisfacciontecnicocompetenteid_Jsonclick ;
      private string divTable14_Internalname ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string dynavSatisfacciontecnicoprofesionalismoid_Internalname ;
      private string dynavSatisfacciontecnicoprofesionalismoid_Jsonclick ;
      private string divTable15_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string dynavSatisfacciontiempoid_Internalname ;
      private string dynavSatisfacciontiempoid_Jsonclick ;
      private string divTable16_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string dynavSatisfaccionatencionid_Internalname ;
      private string dynavSatisfaccionatencionid_Jsonclick ;
      private string divTable17_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtavSatisfaccionsugerencia_Internalname ;
      private string ClassString ;
      private string StyleString ;
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
      private string AV7UsuarioNombre ;
      private string AV19TicketTecnicoResponsableNombre ;
      private string wcpOAV7UsuarioNombre ;
      private string wcpOAV19TicketTecnicoResponsableNombre ;
      private string A199TicketTecnicoResponsableNombre ;
      private string AV16SatisfaccionSugerencia ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavSatisfaccionresueltoid ;
      private GXCombobox dynavSatisfacciontecnicoproblemaid ;
      private GXCombobox dynavSatisfacciontecnicocompetenteid ;
      private GXCombobox dynavSatisfacciontecnicoprofesionalismoid ;
      private GXCombobox dynavSatisfacciontiempoid ;
      private GXCombobox dynavSatisfaccionatencionid ;
      private IDataStoreProvider pr_default ;
      private short[] H005V2_A4EstadoSatisfaccionId ;
      private string[] H005V2_A22EstadoSatisfaccionNombre ;
      private short[] H005V3_A4EstadoSatisfaccionId ;
      private string[] H005V3_A22EstadoSatisfaccionNombre ;
      private short[] H005V4_A4EstadoSatisfaccionId ;
      private string[] H005V4_A22EstadoSatisfaccionNombre ;
      private short[] H005V5_A4EstadoSatisfaccionId ;
      private string[] H005V5_A22EstadoSatisfaccionNombre ;
      private short[] H005V6_A4EstadoSatisfaccionId ;
      private string[] H005V6_A22EstadoSatisfaccionNombre ;
      private short[] H005V7_A4EstadoSatisfaccionId ;
      private string[] H005V7_A22EstadoSatisfaccionNombre ;
      private long[] H005V8_A14TicketId ;
      private long[] H005V8_A16TicketResponsableId ;
      private string[] H005V8_A199TicketTecnicoResponsableNombre ;
      private short[] H005V8_A198TicketTecnicoResponsableId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wpregistrarsatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[6])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH005V2;
          prmH005V2 = new Object[] {
          };
          Object[] prmH005V3;
          prmH005V3 = new Object[] {
          };
          Object[] prmH005V4;
          prmH005V4 = new Object[] {
          };
          Object[] prmH005V5;
          prmH005V5 = new Object[] {
          };
          Object[] prmH005V6;
          prmH005V6 = new Object[] {
          };
          Object[] prmH005V7;
          prmH005V7 = new Object[] {
          };
          Object[] prmH005V8;
          prmH005V8 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("H005V2", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005V3", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V3,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005V4", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V4,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005V5", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V5,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005V6", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V6,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005V7", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre] FROM [EstadoSatisfaccion] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V7,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H005V8", "SELECT T1.[TicketId], T1.[TicketResponsableId], T2.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM ([TicketResponsable] T1 INNER JOIN [Responsable] T2 ON T2.[ResponsableId] = T1.[TicketTecnicoResponsableId]) ORDER BY T1.[TicketId], T1.[TicketResponsableId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005V8,100, GxCacheFrequency.OFF ,true,false )
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
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}
