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
   public class soportetecnico : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A14TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
            AssignAttri("", false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A14TicketId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A15UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
            AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A15UsuarioId) ;
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
            }
            Form.Meta.addItem("description", "Soporte Tecnico", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSoporteTecnicoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public soportetecnico( )
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

      public soportetecnico( IGxContext context )
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
         chkSoporteTecnicoInstalacion = new GXCheckbox();
         chkSoporteTecnicoConfiguracion = new GXCheckbox();
         chkSoporteTecnicoInternetRouter = new GXCheckbox();
         chkSoporteTecnicoFormateo = new GXCheckbox();
         chkSoporteTecnicoReparacion = new GXCheckbox();
         chkSoporteTecnicoLimpieza = new GXCheckbox();
         chkSoporteTecnicoPuntoRed = new GXCheckbox();
         chkSoporteTecnicoCambiosHardware = new GXCheckbox();
         chkSoporteTecnicoCopiasRespaldo = new GXCheckbox();
         chkSoporteTecnicoCerrado = new GXCheckbox();
         chkSoporteTecnicoPendiente = new GXCheckbox();
         chkSoporteTecnicoPasaTaller = new GXCheckbox();
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
            return "soportetecnico_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
         A206SoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A206SoporteTecnicoInstalacion));
         n206SoporteTecnicoInstalacion = false;
         AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
         A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion));
         n207SoporteTecnicoConfiguracion = false;
         AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
         A208SoporteTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A208SoporteTecnicoInternetRouter));
         n208SoporteTecnicoInternetRouter = false;
         AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
         A209SoporteTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A209SoporteTecnicoFormateo));
         n209SoporteTecnicoFormateo = false;
         AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
         A210SoporteTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A210SoporteTecnicoReparacion));
         n210SoporteTecnicoReparacion = false;
         AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
         A213SoporteTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A213SoporteTecnicoLimpieza));
         n213SoporteTecnicoLimpieza = false;
         AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
         A214SoporteTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A214SoporteTecnicoPuntoRed));
         n214SoporteTecnicoPuntoRed = false;
         AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
         A215SoporteTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A215SoporteTecnicoCambiosHardware));
         n215SoporteTecnicoCambiosHardware = false;
         AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
         A216SoporteTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A216SoporteTecnicoCopiasRespaldo));
         n216SoporteTecnicoCopiasRespaldo = false;
         AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
         A235SoporteTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A235SoporteTecnicoCerrado));
         AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
         A236SoporteTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A236SoporteTecnicoPendiente));
         AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
         A237SoporteTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A237SoporteTecnicoPasaTaller));
         AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Soporte Tecnico", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00g0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"SOPORTETECNICOID"+"'), id:'"+"SOPORTETECNICOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoId_Internalname, "Tecnico Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A202SoporteTecnicoId), 10, 0, ",", "")), ((edtSoporteTecnicoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A202SoporteTecnicoId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A202SoporteTecnicoId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoFecha_Internalname, "Tecnico Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSoporteTecnicoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoFecha_Internalname, context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"), context.localUtil.Format( A203SoporteTecnicoFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_bitmap( context, edtSoporteTecnicoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSoporteTecnicoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SoporteTecnico.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoHora_Internalname, "Tecnico Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSoporteTecnicoHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoHora_Internalname, context.localUtil.TToC( A204SoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A204SoporteTecnicoHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoHora_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Hora", "right", false, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_bitmap( context, edtSoporteTecnicoHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSoporteTecnicoHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SoporteTecnico.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoFechaResuelve_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoFechaResuelve_Internalname, "Fecha Resuelve", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSoporteTecnicoFechaResuelve_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoFechaResuelve_Internalname, context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"), context.localUtil.Format( A211SoporteTecnicoFechaResuelve, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoFechaResuelve_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoFechaResuelve_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_bitmap( context, edtSoporteTecnicoFechaResuelve_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSoporteTecnicoFechaResuelve_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SoporteTecnico.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoHoraResuelve_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoHoraResuelve_Internalname, "Hora Resuelve", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSoporteTecnicoHoraResuelve_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoHoraResuelve_Internalname, context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A212SoporteTecnicoHoraResuelve, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoHoraResuelve_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoHoraResuelve_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Hora", "right", false, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_bitmap( context, edtSoporteTecnicoHoraResuelve_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSoporteTecnicoHoraResuelve_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SoporteTecnico.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTicketId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketId_Internalname, "Id Ticket", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")), ((edtTicketId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTicketId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_SoporteTecnico.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, "Id Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ",", "")), ((edtUsuarioId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")) : context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, A93UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioRequerimiento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioRequerimiento_Internalname, "Requerimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioRequerimiento_Internalname, A94UsuarioRequerimiento, "", "", 0, 1, edtUsuarioRequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioGerencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioGerencia_Internalname, "Gerencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioGerencia_Internalname, A91UsuarioGerencia, "", "", 0, 1, edtUsuarioGerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuarioDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioDepartamento_Internalname, "Departamento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioDepartamento_Internalname, A88UsuarioDepartamento, "", "", 0, 1, edtUsuarioDepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoInventarioSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoInventarioSerie_Internalname, "Inventario Serie", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSoporteTecnicoInventarioSerie_Internalname, A205SoporteTecnicoInventarioSerie, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", 0, 1, edtSoporteTecnicoInventarioSerie_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoInstalacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoInstalacion_Internalname, "Tecnico Instalacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoInstalacion_Internalname, StringUtil.BoolToStr( A206SoporteTecnicoInstalacion), "", "Tecnico Instalacion", 1, chkSoporteTecnicoInstalacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(88, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,88);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoConfiguracion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoConfiguracion_Internalname, "Tecnico Configuracion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoConfiguracion_Internalname, StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion), "", "Tecnico Configuracion", 1, chkSoporteTecnicoConfiguracion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(93, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,93);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoInternetRouter_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoInternetRouter_Internalname, "Internet Router", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoInternetRouter_Internalname, StringUtil.BoolToStr( A208SoporteTecnicoInternetRouter), "", "Internet Router", 1, chkSoporteTecnicoInternetRouter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(98, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,98);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoFormateo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoFormateo_Internalname, "Tecnico Formateo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoFormateo_Internalname, StringUtil.BoolToStr( A209SoporteTecnicoFormateo), "", "Tecnico Formateo", 1, chkSoporteTecnicoFormateo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,103);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoReparacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoReparacion_Internalname, "Tecnico Reparacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoReparacion_Internalname, StringUtil.BoolToStr( A210SoporteTecnicoReparacion), "", "Tecnico Reparacion", 1, chkSoporteTecnicoReparacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoLimpieza_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoLimpieza_Internalname, "Tecnico Limpieza", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoLimpieza_Internalname, StringUtil.BoolToStr( A213SoporteTecnicoLimpieza), "", "Tecnico Limpieza", 1, chkSoporteTecnicoLimpieza.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(113, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,113);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoPuntoRed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoPuntoRed_Internalname, "Punto Red", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoPuntoRed_Internalname, StringUtil.BoolToStr( A214SoporteTecnicoPuntoRed), "", "Punto Red", 1, chkSoporteTecnicoPuntoRed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(118, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,118);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoCambiosHardware_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoCambiosHardware_Internalname, "Cambios Hardware", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoCambiosHardware_Internalname, StringUtil.BoolToStr( A215SoporteTecnicoCambiosHardware), "", "Cambios Hardware", 1, chkSoporteTecnicoCambiosHardware.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(123, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,123);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoCopiasRespaldo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoCopiasRespaldo_Internalname, "Copias Respaldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoCopiasRespaldo_Internalname, StringUtil.BoolToStr( A216SoporteTecnicoCopiasRespaldo), "", "Copias Respaldo", 1, chkSoporteTecnicoCopiasRespaldo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(128, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,128);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoRam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoRam_Internalname, "Tecnico Ram", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoRam_Internalname, A217SoporteTecnicoRam, StringUtil.RTrim( context.localUtil.Format( A217SoporteTecnicoRam, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoRam_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoRam_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoDiscoDuro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoDiscoDuro_Internalname, "Disco Duro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoDiscoDuro_Internalname, A218SoporteTecnicoDiscoDuro, StringUtil.RTrim( context.localUtil.Format( A218SoporteTecnicoDiscoDuro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoDiscoDuro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoDiscoDuro_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoProcesador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoProcesador_Internalname, "Tecnico Procesador", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoProcesador_Internalname, A219SoporteTecnicoProcesador, StringUtil.RTrim( context.localUtil.Format( A219SoporteTecnicoProcesador, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoProcesador_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoProcesador_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoMaletin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoMaletin_Internalname, "Tecnico Maletin", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoMaletin_Internalname, A220SoporteTecnicoMaletin, StringUtil.RTrim( context.localUtil.Format( A220SoporteTecnicoMaletin, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoMaletin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoMaletin_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoTonerCinta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoTonerCinta_Internalname, "Toner Cinta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoTonerCinta_Internalname, A221SoporteTecnicoTonerCinta, StringUtil.RTrim( context.localUtil.Format( A221SoporteTecnicoTonerCinta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoTonerCinta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoTonerCinta_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoTarjetaVideoExtra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoTarjetaVideoExtra_Internalname, "Video Extra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoTarjetaVideoExtra_Internalname, A222SoporteTecnicoTarjetaVideoExtra, StringUtil.RTrim( context.localUtil.Format( A222SoporteTecnicoTarjetaVideoExtra, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,158);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoTarjetaVideoExtra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoTarjetaVideoExtra_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoCargadorLaptop_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoCargadorLaptop_Internalname, "Cargador Laptop", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoCargadorLaptop_Internalname, A223SoporteTecnicoCargadorLaptop, StringUtil.RTrim( context.localUtil.Format( A223SoporteTecnicoCargadorLaptop, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoCargadorLaptop_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoCargadorLaptop_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoCDsDVDs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoCDsDVDs_Internalname, "CDs DVDs", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoCDsDVDs_Internalname, A224SoporteTecnicoCDsDVDs, StringUtil.RTrim( context.localUtil.Format( A224SoporteTecnicoCDsDVDs, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,168);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoCDsDVDs_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoCDsDVDs_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoCableEspecial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoCableEspecial_Internalname, "Cable Especial", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoCableEspecial_Internalname, A225SoporteTecnicoCableEspecial, StringUtil.RTrim( context.localUtil.Format( A225SoporteTecnicoCableEspecial, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,173);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoCableEspecial_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoCableEspecial_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoOtrosTaller_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoOtrosTaller_Internalname, "Otros Taller", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 178,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSoporteTecnicoOtrosTaller_Internalname, A226SoporteTecnicoOtrosTaller, StringUtil.RTrim( context.localUtil.Format( A226SoporteTecnicoOtrosTaller, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,178);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSoporteTecnicoOtrosTaller_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSoporteTecnicoOtrosTaller_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoCerrado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoCerrado_Internalname, "Tecnico Cerrado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 183,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoCerrado_Internalname, StringUtil.BoolToStr( A235SoporteTecnicoCerrado), "", "Tecnico Cerrado", 1, chkSoporteTecnicoCerrado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(183, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,183);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoPendiente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoPendiente_Internalname, "Tecnico Pendiente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoPendiente_Internalname, StringUtil.BoolToStr( A236SoporteTecnicoPendiente), "", "Tecnico Pendiente", 1, chkSoporteTecnicoPendiente.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(188, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,188);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkSoporteTecnicoPasaTaller_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkSoporteTecnicoPasaTaller_Internalname, "Pasa Taller", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 193,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkSoporteTecnicoPasaTaller_Internalname, StringUtil.BoolToStr( A237SoporteTecnicoPasaTaller), "", "Pasa Taller", 1, chkSoporteTecnicoPasaTaller.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(193, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,193);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSoporteTecnicoObservacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSoporteTecnicoObservacion_Internalname, "Tecnico Observacion", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSoporteTecnicoObservacion_Internalname, A227SoporteTecnicoObservacion, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,198);\"", 0, 1, edtSoporteTecnicoObservacion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 205,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 207,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SoporteTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z202SoporteTecnicoId = (long)(context.localUtil.CToN( cgiGet( "Z202SoporteTecnicoId"), ",", "."));
            Z203SoporteTecnicoFecha = context.localUtil.CToD( cgiGet( "Z203SoporteTecnicoFecha"), 0);
            Z204SoporteTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z204SoporteTecnicoHora"), 0));
            Z211SoporteTecnicoFechaResuelve = context.localUtil.CToD( cgiGet( "Z211SoporteTecnicoFechaResuelve"), 0);
            n211SoporteTecnicoFechaResuelve = ((DateTime.MinValue==A211SoporteTecnicoFechaResuelve) ? true : false);
            Z212SoporteTecnicoHoraResuelve = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z212SoporteTecnicoHoraResuelve"), 0));
            n212SoporteTecnicoHoraResuelve = ((DateTime.MinValue==A212SoporteTecnicoHoraResuelve) ? true : false);
            Z205SoporteTecnicoInventarioSerie = cgiGet( "Z205SoporteTecnicoInventarioSerie");
            n205SoporteTecnicoInventarioSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A205SoporteTecnicoInventarioSerie)) ? true : false);
            Z206SoporteTecnicoInstalacion = StringUtil.StrToBool( cgiGet( "Z206SoporteTecnicoInstalacion"));
            n206SoporteTecnicoInstalacion = ((false==A206SoporteTecnicoInstalacion) ? true : false);
            Z207SoporteTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( "Z207SoporteTecnicoConfiguracion"));
            n207SoporteTecnicoConfiguracion = ((false==A207SoporteTecnicoConfiguracion) ? true : false);
            Z208SoporteTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( "Z208SoporteTecnicoInternetRouter"));
            n208SoporteTecnicoInternetRouter = ((false==A208SoporteTecnicoInternetRouter) ? true : false);
            Z209SoporteTecnicoFormateo = StringUtil.StrToBool( cgiGet( "Z209SoporteTecnicoFormateo"));
            n209SoporteTecnicoFormateo = ((false==A209SoporteTecnicoFormateo) ? true : false);
            Z210SoporteTecnicoReparacion = StringUtil.StrToBool( cgiGet( "Z210SoporteTecnicoReparacion"));
            n210SoporteTecnicoReparacion = ((false==A210SoporteTecnicoReparacion) ? true : false);
            Z213SoporteTecnicoLimpieza = StringUtil.StrToBool( cgiGet( "Z213SoporteTecnicoLimpieza"));
            n213SoporteTecnicoLimpieza = ((false==A213SoporteTecnicoLimpieza) ? true : false);
            Z214SoporteTecnicoPuntoRed = StringUtil.StrToBool( cgiGet( "Z214SoporteTecnicoPuntoRed"));
            n214SoporteTecnicoPuntoRed = ((false==A214SoporteTecnicoPuntoRed) ? true : false);
            Z215SoporteTecnicoCambiosHardware = StringUtil.StrToBool( cgiGet( "Z215SoporteTecnicoCambiosHardware"));
            n215SoporteTecnicoCambiosHardware = ((false==A215SoporteTecnicoCambiosHardware) ? true : false);
            Z216SoporteTecnicoCopiasRespaldo = StringUtil.StrToBool( cgiGet( "Z216SoporteTecnicoCopiasRespaldo"));
            n216SoporteTecnicoCopiasRespaldo = ((false==A216SoporteTecnicoCopiasRespaldo) ? true : false);
            Z217SoporteTecnicoRam = cgiGet( "Z217SoporteTecnicoRam");
            n217SoporteTecnicoRam = (String.IsNullOrEmpty(StringUtil.RTrim( A217SoporteTecnicoRam)) ? true : false);
            Z218SoporteTecnicoDiscoDuro = cgiGet( "Z218SoporteTecnicoDiscoDuro");
            n218SoporteTecnicoDiscoDuro = (String.IsNullOrEmpty(StringUtil.RTrim( A218SoporteTecnicoDiscoDuro)) ? true : false);
            Z219SoporteTecnicoProcesador = cgiGet( "Z219SoporteTecnicoProcesador");
            n219SoporteTecnicoProcesador = (String.IsNullOrEmpty(StringUtil.RTrim( A219SoporteTecnicoProcesador)) ? true : false);
            Z220SoporteTecnicoMaletin = cgiGet( "Z220SoporteTecnicoMaletin");
            n220SoporteTecnicoMaletin = (String.IsNullOrEmpty(StringUtil.RTrim( A220SoporteTecnicoMaletin)) ? true : false);
            Z221SoporteTecnicoTonerCinta = cgiGet( "Z221SoporteTecnicoTonerCinta");
            n221SoporteTecnicoTonerCinta = (String.IsNullOrEmpty(StringUtil.RTrim( A221SoporteTecnicoTonerCinta)) ? true : false);
            Z222SoporteTecnicoTarjetaVideoExtra = cgiGet( "Z222SoporteTecnicoTarjetaVideoExtra");
            n222SoporteTecnicoTarjetaVideoExtra = (String.IsNullOrEmpty(StringUtil.RTrim( A222SoporteTecnicoTarjetaVideoExtra)) ? true : false);
            Z223SoporteTecnicoCargadorLaptop = cgiGet( "Z223SoporteTecnicoCargadorLaptop");
            n223SoporteTecnicoCargadorLaptop = (String.IsNullOrEmpty(StringUtil.RTrim( A223SoporteTecnicoCargadorLaptop)) ? true : false);
            Z224SoporteTecnicoCDsDVDs = cgiGet( "Z224SoporteTecnicoCDsDVDs");
            n224SoporteTecnicoCDsDVDs = (String.IsNullOrEmpty(StringUtil.RTrim( A224SoporteTecnicoCDsDVDs)) ? true : false);
            Z225SoporteTecnicoCableEspecial = cgiGet( "Z225SoporteTecnicoCableEspecial");
            n225SoporteTecnicoCableEspecial = (String.IsNullOrEmpty(StringUtil.RTrim( A225SoporteTecnicoCableEspecial)) ? true : false);
            Z226SoporteTecnicoOtrosTaller = cgiGet( "Z226SoporteTecnicoOtrosTaller");
            n226SoporteTecnicoOtrosTaller = (String.IsNullOrEmpty(StringUtil.RTrim( A226SoporteTecnicoOtrosTaller)) ? true : false);
            Z235SoporteTecnicoCerrado = StringUtil.StrToBool( cgiGet( "Z235SoporteTecnicoCerrado"));
            Z236SoporteTecnicoPendiente = StringUtil.StrToBool( cgiGet( "Z236SoporteTecnicoPendiente"));
            Z237SoporteTecnicoPasaTaller = StringUtil.StrToBool( cgiGet( "Z237SoporteTecnicoPasaTaller"));
            Z227SoporteTecnicoObservacion = cgiGet( "Z227SoporteTecnicoObservacion");
            n227SoporteTecnicoObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A227SoporteTecnicoObservacion)) ? true : false);
            Z14TicketId = (long)(context.localUtil.CToN( cgiGet( "Z14TicketId"), ",", "."));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSoporteTecnicoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSoporteTecnicoId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SOPORTETECNICOID");
               AnyError = 1;
               GX_FocusControl = edtSoporteTecnicoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A202SoporteTecnicoId = 0;
               AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
            }
            else
            {
               A202SoporteTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtSoporteTecnicoId_Internalname), ",", "."));
               AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtSoporteTecnicoFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Soporte Tecnico Fecha"}), 1, "SOPORTETECNICOFECHA");
               AnyError = 1;
               GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A203SoporteTecnicoFecha = DateTime.MinValue;
               AssignAttri("", false, "A203SoporteTecnicoFecha", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
            }
            else
            {
               A203SoporteTecnicoFecha = context.localUtil.CToD( cgiGet( edtSoporteTecnicoFecha_Internalname), 2);
               AssignAttri("", false, "A203SoporteTecnicoFecha", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtSoporteTecnicoHora_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Soporte Tecnico Hora"}), 1, "SOPORTETECNICOHORA");
               AnyError = 1;
               GX_FocusControl = edtSoporteTecnicoHora_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A204SoporteTecnicoHora", context.localUtil.TToC( A204SoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A204SoporteTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtSoporteTecnicoHora_Internalname)));
               AssignAttri("", false, "A204SoporteTecnicoHora", context.localUtil.TToC( A204SoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDate( cgiGet( edtSoporteTecnicoFechaResuelve_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Soporte Tecnico Fecha Resuelve"}), 1, "SOPORTETECNICOFECHARESUELVE");
               AnyError = 1;
               GX_FocusControl = edtSoporteTecnicoFechaResuelve_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A211SoporteTecnicoFechaResuelve = DateTime.MinValue;
               n211SoporteTecnicoFechaResuelve = false;
               AssignAttri("", false, "A211SoporteTecnicoFechaResuelve", context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"));
            }
            else
            {
               A211SoporteTecnicoFechaResuelve = context.localUtil.CToD( cgiGet( edtSoporteTecnicoFechaResuelve_Internalname), 2);
               n211SoporteTecnicoFechaResuelve = false;
               AssignAttri("", false, "A211SoporteTecnicoFechaResuelve", context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"));
            }
            n211SoporteTecnicoFechaResuelve = ((DateTime.MinValue==A211SoporteTecnicoFechaResuelve) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtSoporteTecnicoHoraResuelve_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Soporte Tecnico Hora Resuelve"}), 1, "SOPORTETECNICOHORARESUELVE");
               AnyError = 1;
               GX_FocusControl = edtSoporteTecnicoHoraResuelve_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A212SoporteTecnicoHoraResuelve = (DateTime)(DateTime.MinValue);
               n212SoporteTecnicoHoraResuelve = false;
               AssignAttri("", false, "A212SoporteTecnicoHoraResuelve", context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 0, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A212SoporteTecnicoHoraResuelve = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtSoporteTecnicoHoraResuelve_Internalname)));
               n212SoporteTecnicoHoraResuelve = false;
               AssignAttri("", false, "A212SoporteTecnicoHoraResuelve", context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 0, 5, 0, 3, "/", ":", " "));
            }
            n212SoporteTecnicoHoraResuelve = ((DateTime.MinValue==A212SoporteTecnicoHoraResuelve) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TICKETID");
               AnyError = 1;
               GX_FocusControl = edtTicketId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A14TicketId = 0;
               AssignAttri("", false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            }
            else
            {
               A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
               AssignAttri("", false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            }
            A15UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", "."));
            AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
            AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
            AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A91UsuarioGerencia = cgiGet( edtUsuarioGerencia_Internalname);
            AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
            A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
            AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            A205SoporteTecnicoInventarioSerie = cgiGet( edtSoporteTecnicoInventarioSerie_Internalname);
            n205SoporteTecnicoInventarioSerie = false;
            AssignAttri("", false, "A205SoporteTecnicoInventarioSerie", A205SoporteTecnicoInventarioSerie);
            n205SoporteTecnicoInventarioSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A205SoporteTecnicoInventarioSerie)) ? true : false);
            A206SoporteTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoInstalacion_Internalname));
            n206SoporteTecnicoInstalacion = false;
            AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
            n206SoporteTecnicoInstalacion = ((false==A206SoporteTecnicoInstalacion) ? true : false);
            A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoConfiguracion_Internalname));
            n207SoporteTecnicoConfiguracion = false;
            AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
            n207SoporteTecnicoConfiguracion = ((false==A207SoporteTecnicoConfiguracion) ? true : false);
            A208SoporteTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoInternetRouter_Internalname));
            n208SoporteTecnicoInternetRouter = false;
            AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
            n208SoporteTecnicoInternetRouter = ((false==A208SoporteTecnicoInternetRouter) ? true : false);
            A209SoporteTecnicoFormateo = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoFormateo_Internalname));
            n209SoporteTecnicoFormateo = false;
            AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
            n209SoporteTecnicoFormateo = ((false==A209SoporteTecnicoFormateo) ? true : false);
            A210SoporteTecnicoReparacion = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoReparacion_Internalname));
            n210SoporteTecnicoReparacion = false;
            AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
            n210SoporteTecnicoReparacion = ((false==A210SoporteTecnicoReparacion) ? true : false);
            A213SoporteTecnicoLimpieza = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoLimpieza_Internalname));
            n213SoporteTecnicoLimpieza = false;
            AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
            n213SoporteTecnicoLimpieza = ((false==A213SoporteTecnicoLimpieza) ? true : false);
            A214SoporteTecnicoPuntoRed = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoPuntoRed_Internalname));
            n214SoporteTecnicoPuntoRed = false;
            AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
            n214SoporteTecnicoPuntoRed = ((false==A214SoporteTecnicoPuntoRed) ? true : false);
            A215SoporteTecnicoCambiosHardware = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoCambiosHardware_Internalname));
            n215SoporteTecnicoCambiosHardware = false;
            AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
            n215SoporteTecnicoCambiosHardware = ((false==A215SoporteTecnicoCambiosHardware) ? true : false);
            A216SoporteTecnicoCopiasRespaldo = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoCopiasRespaldo_Internalname));
            n216SoporteTecnicoCopiasRespaldo = false;
            AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
            n216SoporteTecnicoCopiasRespaldo = ((false==A216SoporteTecnicoCopiasRespaldo) ? true : false);
            A217SoporteTecnicoRam = cgiGet( edtSoporteTecnicoRam_Internalname);
            n217SoporteTecnicoRam = false;
            AssignAttri("", false, "A217SoporteTecnicoRam", A217SoporteTecnicoRam);
            n217SoporteTecnicoRam = (String.IsNullOrEmpty(StringUtil.RTrim( A217SoporteTecnicoRam)) ? true : false);
            A218SoporteTecnicoDiscoDuro = cgiGet( edtSoporteTecnicoDiscoDuro_Internalname);
            n218SoporteTecnicoDiscoDuro = false;
            AssignAttri("", false, "A218SoporteTecnicoDiscoDuro", A218SoporteTecnicoDiscoDuro);
            n218SoporteTecnicoDiscoDuro = (String.IsNullOrEmpty(StringUtil.RTrim( A218SoporteTecnicoDiscoDuro)) ? true : false);
            A219SoporteTecnicoProcesador = cgiGet( edtSoporteTecnicoProcesador_Internalname);
            n219SoporteTecnicoProcesador = false;
            AssignAttri("", false, "A219SoporteTecnicoProcesador", A219SoporteTecnicoProcesador);
            n219SoporteTecnicoProcesador = (String.IsNullOrEmpty(StringUtil.RTrim( A219SoporteTecnicoProcesador)) ? true : false);
            A220SoporteTecnicoMaletin = cgiGet( edtSoporteTecnicoMaletin_Internalname);
            n220SoporteTecnicoMaletin = false;
            AssignAttri("", false, "A220SoporteTecnicoMaletin", A220SoporteTecnicoMaletin);
            n220SoporteTecnicoMaletin = (String.IsNullOrEmpty(StringUtil.RTrim( A220SoporteTecnicoMaletin)) ? true : false);
            A221SoporteTecnicoTonerCinta = cgiGet( edtSoporteTecnicoTonerCinta_Internalname);
            n221SoporteTecnicoTonerCinta = false;
            AssignAttri("", false, "A221SoporteTecnicoTonerCinta", A221SoporteTecnicoTonerCinta);
            n221SoporteTecnicoTonerCinta = (String.IsNullOrEmpty(StringUtil.RTrim( A221SoporteTecnicoTonerCinta)) ? true : false);
            A222SoporteTecnicoTarjetaVideoExtra = cgiGet( edtSoporteTecnicoTarjetaVideoExtra_Internalname);
            n222SoporteTecnicoTarjetaVideoExtra = false;
            AssignAttri("", false, "A222SoporteTecnicoTarjetaVideoExtra", A222SoporteTecnicoTarjetaVideoExtra);
            n222SoporteTecnicoTarjetaVideoExtra = (String.IsNullOrEmpty(StringUtil.RTrim( A222SoporteTecnicoTarjetaVideoExtra)) ? true : false);
            A223SoporteTecnicoCargadorLaptop = cgiGet( edtSoporteTecnicoCargadorLaptop_Internalname);
            n223SoporteTecnicoCargadorLaptop = false;
            AssignAttri("", false, "A223SoporteTecnicoCargadorLaptop", A223SoporteTecnicoCargadorLaptop);
            n223SoporteTecnicoCargadorLaptop = (String.IsNullOrEmpty(StringUtil.RTrim( A223SoporteTecnicoCargadorLaptop)) ? true : false);
            A224SoporteTecnicoCDsDVDs = cgiGet( edtSoporteTecnicoCDsDVDs_Internalname);
            n224SoporteTecnicoCDsDVDs = false;
            AssignAttri("", false, "A224SoporteTecnicoCDsDVDs", A224SoporteTecnicoCDsDVDs);
            n224SoporteTecnicoCDsDVDs = (String.IsNullOrEmpty(StringUtil.RTrim( A224SoporteTecnicoCDsDVDs)) ? true : false);
            A225SoporteTecnicoCableEspecial = cgiGet( edtSoporteTecnicoCableEspecial_Internalname);
            n225SoporteTecnicoCableEspecial = false;
            AssignAttri("", false, "A225SoporteTecnicoCableEspecial", A225SoporteTecnicoCableEspecial);
            n225SoporteTecnicoCableEspecial = (String.IsNullOrEmpty(StringUtil.RTrim( A225SoporteTecnicoCableEspecial)) ? true : false);
            A226SoporteTecnicoOtrosTaller = cgiGet( edtSoporteTecnicoOtrosTaller_Internalname);
            n226SoporteTecnicoOtrosTaller = false;
            AssignAttri("", false, "A226SoporteTecnicoOtrosTaller", A226SoporteTecnicoOtrosTaller);
            n226SoporteTecnicoOtrosTaller = (String.IsNullOrEmpty(StringUtil.RTrim( A226SoporteTecnicoOtrosTaller)) ? true : false);
            A235SoporteTecnicoCerrado = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoCerrado_Internalname));
            AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
            A236SoporteTecnicoPendiente = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoPendiente_Internalname));
            AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
            A237SoporteTecnicoPasaTaller = StringUtil.StrToBool( cgiGet( chkSoporteTecnicoPasaTaller_Internalname));
            AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
            A227SoporteTecnicoObservacion = cgiGet( edtSoporteTecnicoObservacion_Internalname);
            n227SoporteTecnicoObservacion = false;
            AssignAttri("", false, "A227SoporteTecnicoObservacion", A227SoporteTecnicoObservacion);
            n227SoporteTecnicoObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A227SoporteTecnicoObservacion)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A202SoporteTecnicoId = (long)(NumberUtil.Val( GetPar( "SoporteTecnicoId"), "."));
               AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0F16( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0F16( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z203SoporteTecnicoFecha = T000F3_A203SoporteTecnicoFecha[0];
               Z204SoporteTecnicoHora = T000F3_A204SoporteTecnicoHora[0];
               Z211SoporteTecnicoFechaResuelve = T000F3_A211SoporteTecnicoFechaResuelve[0];
               Z212SoporteTecnicoHoraResuelve = T000F3_A212SoporteTecnicoHoraResuelve[0];
               Z205SoporteTecnicoInventarioSerie = T000F3_A205SoporteTecnicoInventarioSerie[0];
               Z206SoporteTecnicoInstalacion = T000F3_A206SoporteTecnicoInstalacion[0];
               Z207SoporteTecnicoConfiguracion = T000F3_A207SoporteTecnicoConfiguracion[0];
               Z208SoporteTecnicoInternetRouter = T000F3_A208SoporteTecnicoInternetRouter[0];
               Z209SoporteTecnicoFormateo = T000F3_A209SoporteTecnicoFormateo[0];
               Z210SoporteTecnicoReparacion = T000F3_A210SoporteTecnicoReparacion[0];
               Z213SoporteTecnicoLimpieza = T000F3_A213SoporteTecnicoLimpieza[0];
               Z214SoporteTecnicoPuntoRed = T000F3_A214SoporteTecnicoPuntoRed[0];
               Z215SoporteTecnicoCambiosHardware = T000F3_A215SoporteTecnicoCambiosHardware[0];
               Z216SoporteTecnicoCopiasRespaldo = T000F3_A216SoporteTecnicoCopiasRespaldo[0];
               Z217SoporteTecnicoRam = T000F3_A217SoporteTecnicoRam[0];
               Z218SoporteTecnicoDiscoDuro = T000F3_A218SoporteTecnicoDiscoDuro[0];
               Z219SoporteTecnicoProcesador = T000F3_A219SoporteTecnicoProcesador[0];
               Z220SoporteTecnicoMaletin = T000F3_A220SoporteTecnicoMaletin[0];
               Z221SoporteTecnicoTonerCinta = T000F3_A221SoporteTecnicoTonerCinta[0];
               Z222SoporteTecnicoTarjetaVideoExtra = T000F3_A222SoporteTecnicoTarjetaVideoExtra[0];
               Z223SoporteTecnicoCargadorLaptop = T000F3_A223SoporteTecnicoCargadorLaptop[0];
               Z224SoporteTecnicoCDsDVDs = T000F3_A224SoporteTecnicoCDsDVDs[0];
               Z225SoporteTecnicoCableEspecial = T000F3_A225SoporteTecnicoCableEspecial[0];
               Z226SoporteTecnicoOtrosTaller = T000F3_A226SoporteTecnicoOtrosTaller[0];
               Z235SoporteTecnicoCerrado = T000F3_A235SoporteTecnicoCerrado[0];
               Z236SoporteTecnicoPendiente = T000F3_A236SoporteTecnicoPendiente[0];
               Z237SoporteTecnicoPasaTaller = T000F3_A237SoporteTecnicoPasaTaller[0];
               Z227SoporteTecnicoObservacion = T000F3_A227SoporteTecnicoObservacion[0];
               Z14TicketId = T000F3_A14TicketId[0];
            }
            else
            {
               Z203SoporteTecnicoFecha = A203SoporteTecnicoFecha;
               Z204SoporteTecnicoHora = A204SoporteTecnicoHora;
               Z211SoporteTecnicoFechaResuelve = A211SoporteTecnicoFechaResuelve;
               Z212SoporteTecnicoHoraResuelve = A212SoporteTecnicoHoraResuelve;
               Z205SoporteTecnicoInventarioSerie = A205SoporteTecnicoInventarioSerie;
               Z206SoporteTecnicoInstalacion = A206SoporteTecnicoInstalacion;
               Z207SoporteTecnicoConfiguracion = A207SoporteTecnicoConfiguracion;
               Z208SoporteTecnicoInternetRouter = A208SoporteTecnicoInternetRouter;
               Z209SoporteTecnicoFormateo = A209SoporteTecnicoFormateo;
               Z210SoporteTecnicoReparacion = A210SoporteTecnicoReparacion;
               Z213SoporteTecnicoLimpieza = A213SoporteTecnicoLimpieza;
               Z214SoporteTecnicoPuntoRed = A214SoporteTecnicoPuntoRed;
               Z215SoporteTecnicoCambiosHardware = A215SoporteTecnicoCambiosHardware;
               Z216SoporteTecnicoCopiasRespaldo = A216SoporteTecnicoCopiasRespaldo;
               Z217SoporteTecnicoRam = A217SoporteTecnicoRam;
               Z218SoporteTecnicoDiscoDuro = A218SoporteTecnicoDiscoDuro;
               Z219SoporteTecnicoProcesador = A219SoporteTecnicoProcesador;
               Z220SoporteTecnicoMaletin = A220SoporteTecnicoMaletin;
               Z221SoporteTecnicoTonerCinta = A221SoporteTecnicoTonerCinta;
               Z222SoporteTecnicoTarjetaVideoExtra = A222SoporteTecnicoTarjetaVideoExtra;
               Z223SoporteTecnicoCargadorLaptop = A223SoporteTecnicoCargadorLaptop;
               Z224SoporteTecnicoCDsDVDs = A224SoporteTecnicoCDsDVDs;
               Z225SoporteTecnicoCableEspecial = A225SoporteTecnicoCableEspecial;
               Z226SoporteTecnicoOtrosTaller = A226SoporteTecnicoOtrosTaller;
               Z235SoporteTecnicoCerrado = A235SoporteTecnicoCerrado;
               Z236SoporteTecnicoPendiente = A236SoporteTecnicoPendiente;
               Z237SoporteTecnicoPasaTaller = A237SoporteTecnicoPasaTaller;
               Z227SoporteTecnicoObservacion = A227SoporteTecnicoObservacion;
               Z14TicketId = A14TicketId;
            }
         }
         if ( GX_JID == -3 )
         {
            Z202SoporteTecnicoId = A202SoporteTecnicoId;
            Z203SoporteTecnicoFecha = A203SoporteTecnicoFecha;
            Z204SoporteTecnicoHora = A204SoporteTecnicoHora;
            Z211SoporteTecnicoFechaResuelve = A211SoporteTecnicoFechaResuelve;
            Z212SoporteTecnicoHoraResuelve = A212SoporteTecnicoHoraResuelve;
            Z205SoporteTecnicoInventarioSerie = A205SoporteTecnicoInventarioSerie;
            Z206SoporteTecnicoInstalacion = A206SoporteTecnicoInstalacion;
            Z207SoporteTecnicoConfiguracion = A207SoporteTecnicoConfiguracion;
            Z208SoporteTecnicoInternetRouter = A208SoporteTecnicoInternetRouter;
            Z209SoporteTecnicoFormateo = A209SoporteTecnicoFormateo;
            Z210SoporteTecnicoReparacion = A210SoporteTecnicoReparacion;
            Z213SoporteTecnicoLimpieza = A213SoporteTecnicoLimpieza;
            Z214SoporteTecnicoPuntoRed = A214SoporteTecnicoPuntoRed;
            Z215SoporteTecnicoCambiosHardware = A215SoporteTecnicoCambiosHardware;
            Z216SoporteTecnicoCopiasRespaldo = A216SoporteTecnicoCopiasRespaldo;
            Z217SoporteTecnicoRam = A217SoporteTecnicoRam;
            Z218SoporteTecnicoDiscoDuro = A218SoporteTecnicoDiscoDuro;
            Z219SoporteTecnicoProcesador = A219SoporteTecnicoProcesador;
            Z220SoporteTecnicoMaletin = A220SoporteTecnicoMaletin;
            Z221SoporteTecnicoTonerCinta = A221SoporteTecnicoTonerCinta;
            Z222SoporteTecnicoTarjetaVideoExtra = A222SoporteTecnicoTarjetaVideoExtra;
            Z223SoporteTecnicoCargadorLaptop = A223SoporteTecnicoCargadorLaptop;
            Z224SoporteTecnicoCDsDVDs = A224SoporteTecnicoCDsDVDs;
            Z225SoporteTecnicoCableEspecial = A225SoporteTecnicoCableEspecial;
            Z226SoporteTecnicoOtrosTaller = A226SoporteTecnicoOtrosTaller;
            Z235SoporteTecnicoCerrado = A235SoporteTecnicoCerrado;
            Z236SoporteTecnicoPendiente = A236SoporteTecnicoPendiente;
            Z237SoporteTecnicoPasaTaller = A237SoporteTecnicoPasaTaller;
            Z227SoporteTecnicoObservacion = A227SoporteTecnicoObservacion;
            Z14TicketId = A14TicketId;
            Z15UsuarioId = A15UsuarioId;
            Z93UsuarioNombre = A93UsuarioNombre;
            Z94UsuarioRequerimiento = A94UsuarioRequerimiento;
            Z91UsuarioGerencia = A91UsuarioGerencia;
            Z88UsuarioDepartamento = A88UsuarioDepartamento;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TICKETID"+"'), id:'"+"TICKETID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor T000F6 */
         pr_default.execute(4, new Object[] {A202SoporteTecnicoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound16 = 1;
            A203SoporteTecnicoFecha = T000F6_A203SoporteTecnicoFecha[0];
            AssignAttri("", false, "A203SoporteTecnicoFecha", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
            A204SoporteTecnicoHora = T000F6_A204SoporteTecnicoHora[0];
            AssignAttri("", false, "A204SoporteTecnicoHora", context.localUtil.TToC( A204SoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            A211SoporteTecnicoFechaResuelve = T000F6_A211SoporteTecnicoFechaResuelve[0];
            n211SoporteTecnicoFechaResuelve = T000F6_n211SoporteTecnicoFechaResuelve[0];
            AssignAttri("", false, "A211SoporteTecnicoFechaResuelve", context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"));
            A212SoporteTecnicoHoraResuelve = T000F6_A212SoporteTecnicoHoraResuelve[0];
            n212SoporteTecnicoHoraResuelve = T000F6_n212SoporteTecnicoHoraResuelve[0];
            AssignAttri("", false, "A212SoporteTecnicoHoraResuelve", context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 0, 5, 0, 3, "/", ":", " "));
            A93UsuarioNombre = T000F6_A93UsuarioNombre[0];
            AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T000F6_A94UsuarioRequerimiento[0];
            AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A91UsuarioGerencia = T000F6_A91UsuarioGerencia[0];
            AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
            A88UsuarioDepartamento = T000F6_A88UsuarioDepartamento[0];
            AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            A205SoporteTecnicoInventarioSerie = T000F6_A205SoporteTecnicoInventarioSerie[0];
            n205SoporteTecnicoInventarioSerie = T000F6_n205SoporteTecnicoInventarioSerie[0];
            AssignAttri("", false, "A205SoporteTecnicoInventarioSerie", A205SoporteTecnicoInventarioSerie);
            A206SoporteTecnicoInstalacion = T000F6_A206SoporteTecnicoInstalacion[0];
            n206SoporteTecnicoInstalacion = T000F6_n206SoporteTecnicoInstalacion[0];
            AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
            A207SoporteTecnicoConfiguracion = T000F6_A207SoporteTecnicoConfiguracion[0];
            n207SoporteTecnicoConfiguracion = T000F6_n207SoporteTecnicoConfiguracion[0];
            AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
            A208SoporteTecnicoInternetRouter = T000F6_A208SoporteTecnicoInternetRouter[0];
            n208SoporteTecnicoInternetRouter = T000F6_n208SoporteTecnicoInternetRouter[0];
            AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
            A209SoporteTecnicoFormateo = T000F6_A209SoporteTecnicoFormateo[0];
            n209SoporteTecnicoFormateo = T000F6_n209SoporteTecnicoFormateo[0];
            AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
            A210SoporteTecnicoReparacion = T000F6_A210SoporteTecnicoReparacion[0];
            n210SoporteTecnicoReparacion = T000F6_n210SoporteTecnicoReparacion[0];
            AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
            A213SoporteTecnicoLimpieza = T000F6_A213SoporteTecnicoLimpieza[0];
            n213SoporteTecnicoLimpieza = T000F6_n213SoporteTecnicoLimpieza[0];
            AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
            A214SoporteTecnicoPuntoRed = T000F6_A214SoporteTecnicoPuntoRed[0];
            n214SoporteTecnicoPuntoRed = T000F6_n214SoporteTecnicoPuntoRed[0];
            AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
            A215SoporteTecnicoCambiosHardware = T000F6_A215SoporteTecnicoCambiosHardware[0];
            n215SoporteTecnicoCambiosHardware = T000F6_n215SoporteTecnicoCambiosHardware[0];
            AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
            A216SoporteTecnicoCopiasRespaldo = T000F6_A216SoporteTecnicoCopiasRespaldo[0];
            n216SoporteTecnicoCopiasRespaldo = T000F6_n216SoporteTecnicoCopiasRespaldo[0];
            AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
            A217SoporteTecnicoRam = T000F6_A217SoporteTecnicoRam[0];
            n217SoporteTecnicoRam = T000F6_n217SoporteTecnicoRam[0];
            AssignAttri("", false, "A217SoporteTecnicoRam", A217SoporteTecnicoRam);
            A218SoporteTecnicoDiscoDuro = T000F6_A218SoporteTecnicoDiscoDuro[0];
            n218SoporteTecnicoDiscoDuro = T000F6_n218SoporteTecnicoDiscoDuro[0];
            AssignAttri("", false, "A218SoporteTecnicoDiscoDuro", A218SoporteTecnicoDiscoDuro);
            A219SoporteTecnicoProcesador = T000F6_A219SoporteTecnicoProcesador[0];
            n219SoporteTecnicoProcesador = T000F6_n219SoporteTecnicoProcesador[0];
            AssignAttri("", false, "A219SoporteTecnicoProcesador", A219SoporteTecnicoProcesador);
            A220SoporteTecnicoMaletin = T000F6_A220SoporteTecnicoMaletin[0];
            n220SoporteTecnicoMaletin = T000F6_n220SoporteTecnicoMaletin[0];
            AssignAttri("", false, "A220SoporteTecnicoMaletin", A220SoporteTecnicoMaletin);
            A221SoporteTecnicoTonerCinta = T000F6_A221SoporteTecnicoTonerCinta[0];
            n221SoporteTecnicoTonerCinta = T000F6_n221SoporteTecnicoTonerCinta[0];
            AssignAttri("", false, "A221SoporteTecnicoTonerCinta", A221SoporteTecnicoTonerCinta);
            A222SoporteTecnicoTarjetaVideoExtra = T000F6_A222SoporteTecnicoTarjetaVideoExtra[0];
            n222SoporteTecnicoTarjetaVideoExtra = T000F6_n222SoporteTecnicoTarjetaVideoExtra[0];
            AssignAttri("", false, "A222SoporteTecnicoTarjetaVideoExtra", A222SoporteTecnicoTarjetaVideoExtra);
            A223SoporteTecnicoCargadorLaptop = T000F6_A223SoporteTecnicoCargadorLaptop[0];
            n223SoporteTecnicoCargadorLaptop = T000F6_n223SoporteTecnicoCargadorLaptop[0];
            AssignAttri("", false, "A223SoporteTecnicoCargadorLaptop", A223SoporteTecnicoCargadorLaptop);
            A224SoporteTecnicoCDsDVDs = T000F6_A224SoporteTecnicoCDsDVDs[0];
            n224SoporteTecnicoCDsDVDs = T000F6_n224SoporteTecnicoCDsDVDs[0];
            AssignAttri("", false, "A224SoporteTecnicoCDsDVDs", A224SoporteTecnicoCDsDVDs);
            A225SoporteTecnicoCableEspecial = T000F6_A225SoporteTecnicoCableEspecial[0];
            n225SoporteTecnicoCableEspecial = T000F6_n225SoporteTecnicoCableEspecial[0];
            AssignAttri("", false, "A225SoporteTecnicoCableEspecial", A225SoporteTecnicoCableEspecial);
            A226SoporteTecnicoOtrosTaller = T000F6_A226SoporteTecnicoOtrosTaller[0];
            n226SoporteTecnicoOtrosTaller = T000F6_n226SoporteTecnicoOtrosTaller[0];
            AssignAttri("", false, "A226SoporteTecnicoOtrosTaller", A226SoporteTecnicoOtrosTaller);
            A235SoporteTecnicoCerrado = T000F6_A235SoporteTecnicoCerrado[0];
            AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
            A236SoporteTecnicoPendiente = T000F6_A236SoporteTecnicoPendiente[0];
            AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
            A237SoporteTecnicoPasaTaller = T000F6_A237SoporteTecnicoPasaTaller[0];
            AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
            A227SoporteTecnicoObservacion = T000F6_A227SoporteTecnicoObservacion[0];
            n227SoporteTecnicoObservacion = T000F6_n227SoporteTecnicoObservacion[0];
            AssignAttri("", false, "A227SoporteTecnicoObservacion", A227SoporteTecnicoObservacion);
            A14TicketId = T000F6_A14TicketId[0];
            AssignAttri("", false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            A15UsuarioId = T000F6_A15UsuarioId[0];
            AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            ZM0F16( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A203SoporteTecnicoFecha) || ( A203SoporteTecnicoFecha >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Soporte Tecnico Fecha fuera de rango", "OutOfRange", 1, "SOPORTETECNICOFECHA");
            AnyError = 1;
            GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A211SoporteTecnicoFechaResuelve) || ( A211SoporteTecnicoFechaResuelve >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo Soporte Tecnico Fecha Resuelve fuera de rango", "OutOfRange", 1, "SOPORTETECNICOFECHARESUELVE");
            AnyError = 1;
            GX_FocusControl = edtSoporteTecnicoFechaResuelve_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000F4 */
         pr_default.execute(2, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A15UsuarioId = T000F4_A15UsuarioId[0];
         AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         pr_default.close(2);
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000F5_A93UsuarioNombre[0];
         AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = T000F5_A94UsuarioRequerimiento[0];
         AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A91UsuarioGerencia = T000F5_A91UsuarioGerencia[0];
         AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
         A88UsuarioDepartamento = T000F5_A88UsuarioDepartamento[0];
         AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0F16( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( long A14TicketId )
      {
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A15UsuarioId = T000F7_A15UsuarioId[0];
         AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( short A15UsuarioId )
      {
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000F8_A93UsuarioNombre[0];
         AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = T000F8_A94UsuarioRequerimiento[0];
         AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A91UsuarioGerencia = T000F8_A91UsuarioGerencia[0];
         AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
         A88UsuarioDepartamento = T000F8_A88UsuarioDepartamento[0];
         AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A93UsuarioNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A94UsuarioRequerimiento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A91UsuarioGerencia)+"\""+","+"\""+GXUtil.EncodeJSConstant( A88UsuarioDepartamento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0F16( )
      {
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A202SoporteTecnicoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A202SoporteTecnicoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F16( 3) ;
            RcdFound16 = 1;
            A202SoporteTecnicoId = T000F3_A202SoporteTecnicoId[0];
            AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
            A203SoporteTecnicoFecha = T000F3_A203SoporteTecnicoFecha[0];
            AssignAttri("", false, "A203SoporteTecnicoFecha", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
            A204SoporteTecnicoHora = T000F3_A204SoporteTecnicoHora[0];
            AssignAttri("", false, "A204SoporteTecnicoHora", context.localUtil.TToC( A204SoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            A211SoporteTecnicoFechaResuelve = T000F3_A211SoporteTecnicoFechaResuelve[0];
            n211SoporteTecnicoFechaResuelve = T000F3_n211SoporteTecnicoFechaResuelve[0];
            AssignAttri("", false, "A211SoporteTecnicoFechaResuelve", context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"));
            A212SoporteTecnicoHoraResuelve = T000F3_A212SoporteTecnicoHoraResuelve[0];
            n212SoporteTecnicoHoraResuelve = T000F3_n212SoporteTecnicoHoraResuelve[0];
            AssignAttri("", false, "A212SoporteTecnicoHoraResuelve", context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 0, 5, 0, 3, "/", ":", " "));
            A205SoporteTecnicoInventarioSerie = T000F3_A205SoporteTecnicoInventarioSerie[0];
            n205SoporteTecnicoInventarioSerie = T000F3_n205SoporteTecnicoInventarioSerie[0];
            AssignAttri("", false, "A205SoporteTecnicoInventarioSerie", A205SoporteTecnicoInventarioSerie);
            A206SoporteTecnicoInstalacion = T000F3_A206SoporteTecnicoInstalacion[0];
            n206SoporteTecnicoInstalacion = T000F3_n206SoporteTecnicoInstalacion[0];
            AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
            A207SoporteTecnicoConfiguracion = T000F3_A207SoporteTecnicoConfiguracion[0];
            n207SoporteTecnicoConfiguracion = T000F3_n207SoporteTecnicoConfiguracion[0];
            AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
            A208SoporteTecnicoInternetRouter = T000F3_A208SoporteTecnicoInternetRouter[0];
            n208SoporteTecnicoInternetRouter = T000F3_n208SoporteTecnicoInternetRouter[0];
            AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
            A209SoporteTecnicoFormateo = T000F3_A209SoporteTecnicoFormateo[0];
            n209SoporteTecnicoFormateo = T000F3_n209SoporteTecnicoFormateo[0];
            AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
            A210SoporteTecnicoReparacion = T000F3_A210SoporteTecnicoReparacion[0];
            n210SoporteTecnicoReparacion = T000F3_n210SoporteTecnicoReparacion[0];
            AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
            A213SoporteTecnicoLimpieza = T000F3_A213SoporteTecnicoLimpieza[0];
            n213SoporteTecnicoLimpieza = T000F3_n213SoporteTecnicoLimpieza[0];
            AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
            A214SoporteTecnicoPuntoRed = T000F3_A214SoporteTecnicoPuntoRed[0];
            n214SoporteTecnicoPuntoRed = T000F3_n214SoporteTecnicoPuntoRed[0];
            AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
            A215SoporteTecnicoCambiosHardware = T000F3_A215SoporteTecnicoCambiosHardware[0];
            n215SoporteTecnicoCambiosHardware = T000F3_n215SoporteTecnicoCambiosHardware[0];
            AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
            A216SoporteTecnicoCopiasRespaldo = T000F3_A216SoporteTecnicoCopiasRespaldo[0];
            n216SoporteTecnicoCopiasRespaldo = T000F3_n216SoporteTecnicoCopiasRespaldo[0];
            AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
            A217SoporteTecnicoRam = T000F3_A217SoporteTecnicoRam[0];
            n217SoporteTecnicoRam = T000F3_n217SoporteTecnicoRam[0];
            AssignAttri("", false, "A217SoporteTecnicoRam", A217SoporteTecnicoRam);
            A218SoporteTecnicoDiscoDuro = T000F3_A218SoporteTecnicoDiscoDuro[0];
            n218SoporteTecnicoDiscoDuro = T000F3_n218SoporteTecnicoDiscoDuro[0];
            AssignAttri("", false, "A218SoporteTecnicoDiscoDuro", A218SoporteTecnicoDiscoDuro);
            A219SoporteTecnicoProcesador = T000F3_A219SoporteTecnicoProcesador[0];
            n219SoporteTecnicoProcesador = T000F3_n219SoporteTecnicoProcesador[0];
            AssignAttri("", false, "A219SoporteTecnicoProcesador", A219SoporteTecnicoProcesador);
            A220SoporteTecnicoMaletin = T000F3_A220SoporteTecnicoMaletin[0];
            n220SoporteTecnicoMaletin = T000F3_n220SoporteTecnicoMaletin[0];
            AssignAttri("", false, "A220SoporteTecnicoMaletin", A220SoporteTecnicoMaletin);
            A221SoporteTecnicoTonerCinta = T000F3_A221SoporteTecnicoTonerCinta[0];
            n221SoporteTecnicoTonerCinta = T000F3_n221SoporteTecnicoTonerCinta[0];
            AssignAttri("", false, "A221SoporteTecnicoTonerCinta", A221SoporteTecnicoTonerCinta);
            A222SoporteTecnicoTarjetaVideoExtra = T000F3_A222SoporteTecnicoTarjetaVideoExtra[0];
            n222SoporteTecnicoTarjetaVideoExtra = T000F3_n222SoporteTecnicoTarjetaVideoExtra[0];
            AssignAttri("", false, "A222SoporteTecnicoTarjetaVideoExtra", A222SoporteTecnicoTarjetaVideoExtra);
            A223SoporteTecnicoCargadorLaptop = T000F3_A223SoporteTecnicoCargadorLaptop[0];
            n223SoporteTecnicoCargadorLaptop = T000F3_n223SoporteTecnicoCargadorLaptop[0];
            AssignAttri("", false, "A223SoporteTecnicoCargadorLaptop", A223SoporteTecnicoCargadorLaptop);
            A224SoporteTecnicoCDsDVDs = T000F3_A224SoporteTecnicoCDsDVDs[0];
            n224SoporteTecnicoCDsDVDs = T000F3_n224SoporteTecnicoCDsDVDs[0];
            AssignAttri("", false, "A224SoporteTecnicoCDsDVDs", A224SoporteTecnicoCDsDVDs);
            A225SoporteTecnicoCableEspecial = T000F3_A225SoporteTecnicoCableEspecial[0];
            n225SoporteTecnicoCableEspecial = T000F3_n225SoporteTecnicoCableEspecial[0];
            AssignAttri("", false, "A225SoporteTecnicoCableEspecial", A225SoporteTecnicoCableEspecial);
            A226SoporteTecnicoOtrosTaller = T000F3_A226SoporteTecnicoOtrosTaller[0];
            n226SoporteTecnicoOtrosTaller = T000F3_n226SoporteTecnicoOtrosTaller[0];
            AssignAttri("", false, "A226SoporteTecnicoOtrosTaller", A226SoporteTecnicoOtrosTaller);
            A235SoporteTecnicoCerrado = T000F3_A235SoporteTecnicoCerrado[0];
            AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
            A236SoporteTecnicoPendiente = T000F3_A236SoporteTecnicoPendiente[0];
            AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
            A237SoporteTecnicoPasaTaller = T000F3_A237SoporteTecnicoPasaTaller[0];
            AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
            A227SoporteTecnicoObservacion = T000F3_A227SoporteTecnicoObservacion[0];
            n227SoporteTecnicoObservacion = T000F3_n227SoporteTecnicoObservacion[0];
            AssignAttri("", false, "A227SoporteTecnicoObservacion", A227SoporteTecnicoObservacion);
            A14TicketId = T000F3_A14TicketId[0];
            AssignAttri("", false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            Z202SoporteTecnicoId = A202SoporteTecnicoId;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0F16( ) ;
            if ( AnyError == 1 )
            {
               RcdFound16 = 0;
               InitializeNonKey0F16( ) ;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F10 */
         pr_default.execute(8, new Object[] {A202SoporteTecnicoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000F10_A202SoporteTecnicoId[0] < A202SoporteTecnicoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000F10_A202SoporteTecnicoId[0] > A202SoporteTecnicoId ) ) )
            {
               A202SoporteTecnicoId = T000F10_A202SoporteTecnicoId[0];
               AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound16 = 0;
         /* Using cursor T000F11 */
         pr_default.execute(9, new Object[] {A202SoporteTecnicoId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000F11_A202SoporteTecnicoId[0] > A202SoporteTecnicoId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000F11_A202SoporteTecnicoId[0] < A202SoporteTecnicoId ) ) )
            {
               A202SoporteTecnicoId = T000F11_A202SoporteTecnicoId[0];
               AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
               RcdFound16 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F16( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSoporteTecnicoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F16( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound16 == 1 )
            {
               if ( A202SoporteTecnicoId != Z202SoporteTecnicoId )
               {
                  A202SoporteTecnicoId = Z202SoporteTecnicoId;
                  AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SOPORTETECNICOID");
                  AnyError = 1;
                  GX_FocusControl = edtSoporteTecnicoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSoporteTecnicoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0F16( ) ;
                  GX_FocusControl = edtSoporteTecnicoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A202SoporteTecnicoId != Z202SoporteTecnicoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSoporteTecnicoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F16( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SOPORTETECNICOID");
                     AnyError = 1;
                     GX_FocusControl = edtSoporteTecnicoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSoporteTecnicoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F16( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A202SoporteTecnicoId != Z202SoporteTecnicoId )
         {
            A202SoporteTecnicoId = Z202SoporteTecnicoId;
            AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SOPORTETECNICOID");
            AnyError = 1;
            GX_FocusControl = edtSoporteTecnicoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSoporteTecnicoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SOPORTETECNICOID");
            AnyError = 1;
            GX_FocusControl = edtSoporteTecnicoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F16( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0F16( ) ;
         if ( RcdFound16 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound16 != 0 )
            {
               ScanNext0F16( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F16( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A202SoporteTecnicoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AtencionSoporteTecnico"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z203SoporteTecnicoFecha != T000F2_A203SoporteTecnicoFecha[0] ) || ( Z204SoporteTecnicoHora != T000F2_A204SoporteTecnicoHora[0] ) || ( Z211SoporteTecnicoFechaResuelve != T000F2_A211SoporteTecnicoFechaResuelve[0] ) || ( Z212SoporteTecnicoHoraResuelve != T000F2_A212SoporteTecnicoHoraResuelve[0] ) || ( StringUtil.StrCmp(Z205SoporteTecnicoInventarioSerie, T000F2_A205SoporteTecnicoInventarioSerie[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z206SoporteTecnicoInstalacion != T000F2_A206SoporteTecnicoInstalacion[0] ) || ( Z207SoporteTecnicoConfiguracion != T000F2_A207SoporteTecnicoConfiguracion[0] ) || ( Z208SoporteTecnicoInternetRouter != T000F2_A208SoporteTecnicoInternetRouter[0] ) || ( Z209SoporteTecnicoFormateo != T000F2_A209SoporteTecnicoFormateo[0] ) || ( Z210SoporteTecnicoReparacion != T000F2_A210SoporteTecnicoReparacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z213SoporteTecnicoLimpieza != T000F2_A213SoporteTecnicoLimpieza[0] ) || ( Z214SoporteTecnicoPuntoRed != T000F2_A214SoporteTecnicoPuntoRed[0] ) || ( Z215SoporteTecnicoCambiosHardware != T000F2_A215SoporteTecnicoCambiosHardware[0] ) || ( Z216SoporteTecnicoCopiasRespaldo != T000F2_A216SoporteTecnicoCopiasRespaldo[0] ) || ( StringUtil.StrCmp(Z217SoporteTecnicoRam, T000F2_A217SoporteTecnicoRam[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z218SoporteTecnicoDiscoDuro, T000F2_A218SoporteTecnicoDiscoDuro[0]) != 0 ) || ( StringUtil.StrCmp(Z219SoporteTecnicoProcesador, T000F2_A219SoporteTecnicoProcesador[0]) != 0 ) || ( StringUtil.StrCmp(Z220SoporteTecnicoMaletin, T000F2_A220SoporteTecnicoMaletin[0]) != 0 ) || ( StringUtil.StrCmp(Z221SoporteTecnicoTonerCinta, T000F2_A221SoporteTecnicoTonerCinta[0]) != 0 ) || ( StringUtil.StrCmp(Z222SoporteTecnicoTarjetaVideoExtra, T000F2_A222SoporteTecnicoTarjetaVideoExtra[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z223SoporteTecnicoCargadorLaptop, T000F2_A223SoporteTecnicoCargadorLaptop[0]) != 0 ) || ( StringUtil.StrCmp(Z224SoporteTecnicoCDsDVDs, T000F2_A224SoporteTecnicoCDsDVDs[0]) != 0 ) || ( StringUtil.StrCmp(Z225SoporteTecnicoCableEspecial, T000F2_A225SoporteTecnicoCableEspecial[0]) != 0 ) || ( StringUtil.StrCmp(Z226SoporteTecnicoOtrosTaller, T000F2_A226SoporteTecnicoOtrosTaller[0]) != 0 ) || ( Z235SoporteTecnicoCerrado != T000F2_A235SoporteTecnicoCerrado[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z236SoporteTecnicoPendiente != T000F2_A236SoporteTecnicoPendiente[0] ) || ( Z237SoporteTecnicoPasaTaller != T000F2_A237SoporteTecnicoPasaTaller[0] ) || ( StringUtil.StrCmp(Z227SoporteTecnicoObservacion, T000F2_A227SoporteTecnicoObservacion[0]) != 0 ) || ( Z14TicketId != T000F2_A14TicketId[0] ) )
            {
               if ( Z203SoporteTecnicoFecha != T000F2_A203SoporteTecnicoFecha[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z203SoporteTecnicoFecha);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A203SoporteTecnicoFecha[0]);
               }
               if ( Z204SoporteTecnicoHora != T000F2_A204SoporteTecnicoHora[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoHora");
                  GXUtil.WriteLogRaw("Old: ",Z204SoporteTecnicoHora);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A204SoporteTecnicoHora[0]);
               }
               if ( Z211SoporteTecnicoFechaResuelve != T000F2_A211SoporteTecnicoFechaResuelve[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoFechaResuelve");
                  GXUtil.WriteLogRaw("Old: ",Z211SoporteTecnicoFechaResuelve);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A211SoporteTecnicoFechaResuelve[0]);
               }
               if ( Z212SoporteTecnicoHoraResuelve != T000F2_A212SoporteTecnicoHoraResuelve[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoHoraResuelve");
                  GXUtil.WriteLogRaw("Old: ",Z212SoporteTecnicoHoraResuelve);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A212SoporteTecnicoHoraResuelve[0]);
               }
               if ( StringUtil.StrCmp(Z205SoporteTecnicoInventarioSerie, T000F2_A205SoporteTecnicoInventarioSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoInventarioSerie");
                  GXUtil.WriteLogRaw("Old: ",Z205SoporteTecnicoInventarioSerie);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A205SoporteTecnicoInventarioSerie[0]);
               }
               if ( Z206SoporteTecnicoInstalacion != T000F2_A206SoporteTecnicoInstalacion[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoInstalacion");
                  GXUtil.WriteLogRaw("Old: ",Z206SoporteTecnicoInstalacion);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A206SoporteTecnicoInstalacion[0]);
               }
               if ( Z207SoporteTecnicoConfiguracion != T000F2_A207SoporteTecnicoConfiguracion[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoConfiguracion");
                  GXUtil.WriteLogRaw("Old: ",Z207SoporteTecnicoConfiguracion);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A207SoporteTecnicoConfiguracion[0]);
               }
               if ( Z208SoporteTecnicoInternetRouter != T000F2_A208SoporteTecnicoInternetRouter[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoInternetRouter");
                  GXUtil.WriteLogRaw("Old: ",Z208SoporteTecnicoInternetRouter);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A208SoporteTecnicoInternetRouter[0]);
               }
               if ( Z209SoporteTecnicoFormateo != T000F2_A209SoporteTecnicoFormateo[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoFormateo");
                  GXUtil.WriteLogRaw("Old: ",Z209SoporteTecnicoFormateo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A209SoporteTecnicoFormateo[0]);
               }
               if ( Z210SoporteTecnicoReparacion != T000F2_A210SoporteTecnicoReparacion[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoReparacion");
                  GXUtil.WriteLogRaw("Old: ",Z210SoporteTecnicoReparacion);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A210SoporteTecnicoReparacion[0]);
               }
               if ( Z213SoporteTecnicoLimpieza != T000F2_A213SoporteTecnicoLimpieza[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoLimpieza");
                  GXUtil.WriteLogRaw("Old: ",Z213SoporteTecnicoLimpieza);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A213SoporteTecnicoLimpieza[0]);
               }
               if ( Z214SoporteTecnicoPuntoRed != T000F2_A214SoporteTecnicoPuntoRed[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoPuntoRed");
                  GXUtil.WriteLogRaw("Old: ",Z214SoporteTecnicoPuntoRed);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A214SoporteTecnicoPuntoRed[0]);
               }
               if ( Z215SoporteTecnicoCambiosHardware != T000F2_A215SoporteTecnicoCambiosHardware[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoCambiosHardware");
                  GXUtil.WriteLogRaw("Old: ",Z215SoporteTecnicoCambiosHardware);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A215SoporteTecnicoCambiosHardware[0]);
               }
               if ( Z216SoporteTecnicoCopiasRespaldo != T000F2_A216SoporteTecnicoCopiasRespaldo[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoCopiasRespaldo");
                  GXUtil.WriteLogRaw("Old: ",Z216SoporteTecnicoCopiasRespaldo);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A216SoporteTecnicoCopiasRespaldo[0]);
               }
               if ( StringUtil.StrCmp(Z217SoporteTecnicoRam, T000F2_A217SoporteTecnicoRam[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoRam");
                  GXUtil.WriteLogRaw("Old: ",Z217SoporteTecnicoRam);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A217SoporteTecnicoRam[0]);
               }
               if ( StringUtil.StrCmp(Z218SoporteTecnicoDiscoDuro, T000F2_A218SoporteTecnicoDiscoDuro[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoDiscoDuro");
                  GXUtil.WriteLogRaw("Old: ",Z218SoporteTecnicoDiscoDuro);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A218SoporteTecnicoDiscoDuro[0]);
               }
               if ( StringUtil.StrCmp(Z219SoporteTecnicoProcesador, T000F2_A219SoporteTecnicoProcesador[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoProcesador");
                  GXUtil.WriteLogRaw("Old: ",Z219SoporteTecnicoProcesador);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A219SoporteTecnicoProcesador[0]);
               }
               if ( StringUtil.StrCmp(Z220SoporteTecnicoMaletin, T000F2_A220SoporteTecnicoMaletin[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoMaletin");
                  GXUtil.WriteLogRaw("Old: ",Z220SoporteTecnicoMaletin);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A220SoporteTecnicoMaletin[0]);
               }
               if ( StringUtil.StrCmp(Z221SoporteTecnicoTonerCinta, T000F2_A221SoporteTecnicoTonerCinta[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoTonerCinta");
                  GXUtil.WriteLogRaw("Old: ",Z221SoporteTecnicoTonerCinta);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A221SoporteTecnicoTonerCinta[0]);
               }
               if ( StringUtil.StrCmp(Z222SoporteTecnicoTarjetaVideoExtra, T000F2_A222SoporteTecnicoTarjetaVideoExtra[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoTarjetaVideoExtra");
                  GXUtil.WriteLogRaw("Old: ",Z222SoporteTecnicoTarjetaVideoExtra);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A222SoporteTecnicoTarjetaVideoExtra[0]);
               }
               if ( StringUtil.StrCmp(Z223SoporteTecnicoCargadorLaptop, T000F2_A223SoporteTecnicoCargadorLaptop[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoCargadorLaptop");
                  GXUtil.WriteLogRaw("Old: ",Z223SoporteTecnicoCargadorLaptop);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A223SoporteTecnicoCargadorLaptop[0]);
               }
               if ( StringUtil.StrCmp(Z224SoporteTecnicoCDsDVDs, T000F2_A224SoporteTecnicoCDsDVDs[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoCDsDVDs");
                  GXUtil.WriteLogRaw("Old: ",Z224SoporteTecnicoCDsDVDs);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A224SoporteTecnicoCDsDVDs[0]);
               }
               if ( StringUtil.StrCmp(Z225SoporteTecnicoCableEspecial, T000F2_A225SoporteTecnicoCableEspecial[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoCableEspecial");
                  GXUtil.WriteLogRaw("Old: ",Z225SoporteTecnicoCableEspecial);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A225SoporteTecnicoCableEspecial[0]);
               }
               if ( StringUtil.StrCmp(Z226SoporteTecnicoOtrosTaller, T000F2_A226SoporteTecnicoOtrosTaller[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoOtrosTaller");
                  GXUtil.WriteLogRaw("Old: ",Z226SoporteTecnicoOtrosTaller);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A226SoporteTecnicoOtrosTaller[0]);
               }
               if ( Z235SoporteTecnicoCerrado != T000F2_A235SoporteTecnicoCerrado[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoCerrado");
                  GXUtil.WriteLogRaw("Old: ",Z235SoporteTecnicoCerrado);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A235SoporteTecnicoCerrado[0]);
               }
               if ( Z236SoporteTecnicoPendiente != T000F2_A236SoporteTecnicoPendiente[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoPendiente");
                  GXUtil.WriteLogRaw("Old: ",Z236SoporteTecnicoPendiente);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A236SoporteTecnicoPendiente[0]);
               }
               if ( Z237SoporteTecnicoPasaTaller != T000F2_A237SoporteTecnicoPasaTaller[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoPasaTaller");
                  GXUtil.WriteLogRaw("Old: ",Z237SoporteTecnicoPasaTaller);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A237SoporteTecnicoPasaTaller[0]);
               }
               if ( StringUtil.StrCmp(Z227SoporteTecnicoObservacion, T000F2_A227SoporteTecnicoObservacion[0]) != 0 )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"SoporteTecnicoObservacion");
                  GXUtil.WriteLogRaw("Old: ",Z227SoporteTecnicoObservacion);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A227SoporteTecnicoObservacion[0]);
               }
               if ( Z14TicketId != T000F2_A14TicketId[0] )
               {
                  GXUtil.WriteLog("soportetecnico:[seudo value changed for attri]"+"TicketId");
                  GXUtil.WriteLogRaw("Old: ",Z14TicketId);
                  GXUtil.WriteLogRaw("Current: ",T000F2_A14TicketId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AtencionSoporteTecnico"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         if ( ! IsAuthorized("soportetecnico_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F12 */
                     pr_default.execute(10, new Object[] {A203SoporteTecnicoFecha, A204SoporteTecnicoHora, n211SoporteTecnicoFechaResuelve, A211SoporteTecnicoFechaResuelve, n212SoporteTecnicoHoraResuelve, A212SoporteTecnicoHoraResuelve, n205SoporteTecnicoInventarioSerie, A205SoporteTecnicoInventarioSerie, n206SoporteTecnicoInstalacion, A206SoporteTecnicoInstalacion, n207SoporteTecnicoConfiguracion, A207SoporteTecnicoConfiguracion, n208SoporteTecnicoInternetRouter, A208SoporteTecnicoInternetRouter, n209SoporteTecnicoFormateo, A209SoporteTecnicoFormateo, n210SoporteTecnicoReparacion, A210SoporteTecnicoReparacion, n213SoporteTecnicoLimpieza, A213SoporteTecnicoLimpieza, n214SoporteTecnicoPuntoRed, A214SoporteTecnicoPuntoRed, n215SoporteTecnicoCambiosHardware, A215SoporteTecnicoCambiosHardware, n216SoporteTecnicoCopiasRespaldo, A216SoporteTecnicoCopiasRespaldo, n217SoporteTecnicoRam, A217SoporteTecnicoRam, n218SoporteTecnicoDiscoDuro, A218SoporteTecnicoDiscoDuro, n219SoporteTecnicoProcesador, A219SoporteTecnicoProcesador, n220SoporteTecnicoMaletin, A220SoporteTecnicoMaletin, n221SoporteTecnicoTonerCinta, A221SoporteTecnicoTonerCinta, n222SoporteTecnicoTarjetaVideoExtra, A222SoporteTecnicoTarjetaVideoExtra, n223SoporteTecnicoCargadorLaptop, A223SoporteTecnicoCargadorLaptop, n224SoporteTecnicoCDsDVDs, A224SoporteTecnicoCDsDVDs, n225SoporteTecnicoCableEspecial, A225SoporteTecnicoCableEspecial, n226SoporteTecnicoOtrosTaller, A226SoporteTecnicoOtrosTaller, A235SoporteTecnicoCerrado, A236SoporteTecnicoPendiente, A237SoporteTecnicoPasaTaller, n227SoporteTecnicoObservacion, A227SoporteTecnicoObservacion, A14TicketId});
                     A202SoporteTecnicoId = T000F12_A202SoporteTecnicoId[0];
                     AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("AtencionSoporteTecnico");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0F0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         if ( ! IsAuthorized("soportetecnico_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F13 */
                     pr_default.execute(11, new Object[] {A203SoporteTecnicoFecha, A204SoporteTecnicoHora, n211SoporteTecnicoFechaResuelve, A211SoporteTecnicoFechaResuelve, n212SoporteTecnicoHoraResuelve, A212SoporteTecnicoHoraResuelve, n205SoporteTecnicoInventarioSerie, A205SoporteTecnicoInventarioSerie, n206SoporteTecnicoInstalacion, A206SoporteTecnicoInstalacion, n207SoporteTecnicoConfiguracion, A207SoporteTecnicoConfiguracion, n208SoporteTecnicoInternetRouter, A208SoporteTecnicoInternetRouter, n209SoporteTecnicoFormateo, A209SoporteTecnicoFormateo, n210SoporteTecnicoReparacion, A210SoporteTecnicoReparacion, n213SoporteTecnicoLimpieza, A213SoporteTecnicoLimpieza, n214SoporteTecnicoPuntoRed, A214SoporteTecnicoPuntoRed, n215SoporteTecnicoCambiosHardware, A215SoporteTecnicoCambiosHardware, n216SoporteTecnicoCopiasRespaldo, A216SoporteTecnicoCopiasRespaldo, n217SoporteTecnicoRam, A217SoporteTecnicoRam, n218SoporteTecnicoDiscoDuro, A218SoporteTecnicoDiscoDuro, n219SoporteTecnicoProcesador, A219SoporteTecnicoProcesador, n220SoporteTecnicoMaletin, A220SoporteTecnicoMaletin, n221SoporteTecnicoTonerCinta, A221SoporteTecnicoTonerCinta, n222SoporteTecnicoTarjetaVideoExtra, A222SoporteTecnicoTarjetaVideoExtra, n223SoporteTecnicoCargadorLaptop, A223SoporteTecnicoCargadorLaptop, n224SoporteTecnicoCDsDVDs, A224SoporteTecnicoCDsDVDs, n225SoporteTecnicoCableEspecial, A225SoporteTecnicoCableEspecial, n226SoporteTecnicoOtrosTaller, A226SoporteTecnicoOtrosTaller, A235SoporteTecnicoCerrado, A236SoporteTecnicoPendiente, A237SoporteTecnicoPasaTaller, n227SoporteTecnicoObservacion, A227SoporteTecnicoObservacion, A14TicketId, A202SoporteTecnicoId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("AtencionSoporteTecnico");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AtencionSoporteTecnico"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0F0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("soportetecnico_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F14 */
                  pr_default.execute(12, new Object[] {A202SoporteTecnicoId});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("AtencionSoporteTecnico");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound16 == 0 )
                        {
                           InitAll0F16( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0F0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F15 */
            pr_default.execute(13, new Object[] {A14TicketId});
            A15UsuarioId = T000F15_A15UsuarioId[0];
            AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            pr_default.close(13);
            /* Using cursor T000F16 */
            pr_default.execute(14, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T000F16_A93UsuarioNombre[0];
            AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T000F16_A94UsuarioRequerimiento[0];
            AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A91UsuarioGerencia = T000F16_A91UsuarioGerencia[0];
            AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
            A88UsuarioDepartamento = T000F16_A88UsuarioDepartamento[0];
            AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            pr_default.close(14);
         }
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("soportetecnico",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("soportetecnico",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F16( )
      {
         /* Using cursor T000F17 */
         pr_default.execute(15);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound16 = 1;
            A202SoporteTecnicoId = T000F17_A202SoporteTecnicoId[0];
            AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound16 = 1;
            A202SoporteTecnicoId = T000F17_A202SoporteTecnicoId[0];
            AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
         }
      }

      protected void ScanEnd0F16( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
         edtSoporteTecnicoId_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoId_Enabled), 5, 0), true);
         edtSoporteTecnicoFecha_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoFecha_Enabled), 5, 0), true);
         edtSoporteTecnicoHora_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoHora_Enabled), 5, 0), true);
         edtSoporteTecnicoFechaResuelve_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoFechaResuelve_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoFechaResuelve_Enabled), 5, 0), true);
         edtSoporteTecnicoHoraResuelve_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoHoraResuelve_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoHoraResuelve_Enabled), 5, 0), true);
         edtTicketId_Enabled = 0;
         AssignProp("", false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp("", false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp("", false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioRequerimiento_Enabled = 0;
         AssignProp("", false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         edtUsuarioGerencia_Enabled = 0;
         AssignProp("", false, edtUsuarioGerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioGerencia_Enabled), 5, 0), true);
         edtUsuarioDepartamento_Enabled = 0;
         AssignProp("", false, edtUsuarioDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Enabled), 5, 0), true);
         edtSoporteTecnicoInventarioSerie_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoInventarioSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoInventarioSerie_Enabled), 5, 0), true);
         chkSoporteTecnicoInstalacion.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoInstalacion.Enabled), 5, 0), true);
         chkSoporteTecnicoConfiguracion.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoConfiguracion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoConfiguracion.Enabled), 5, 0), true);
         chkSoporteTecnicoInternetRouter.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoInternetRouter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoInternetRouter.Enabled), 5, 0), true);
         chkSoporteTecnicoFormateo.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoFormateo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoFormateo.Enabled), 5, 0), true);
         chkSoporteTecnicoReparacion.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoReparacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoReparacion.Enabled), 5, 0), true);
         chkSoporteTecnicoLimpieza.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoLimpieza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoLimpieza.Enabled), 5, 0), true);
         chkSoporteTecnicoPuntoRed.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoPuntoRed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoPuntoRed.Enabled), 5, 0), true);
         chkSoporteTecnicoCambiosHardware.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoCambiosHardware_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoCambiosHardware.Enabled), 5, 0), true);
         chkSoporteTecnicoCopiasRespaldo.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoCopiasRespaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoCopiasRespaldo.Enabled), 5, 0), true);
         edtSoporteTecnicoRam_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoRam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoRam_Enabled), 5, 0), true);
         edtSoporteTecnicoDiscoDuro_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoDiscoDuro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoDiscoDuro_Enabled), 5, 0), true);
         edtSoporteTecnicoProcesador_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoProcesador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoProcesador_Enabled), 5, 0), true);
         edtSoporteTecnicoMaletin_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoMaletin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoMaletin_Enabled), 5, 0), true);
         edtSoporteTecnicoTonerCinta_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoTonerCinta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoTonerCinta_Enabled), 5, 0), true);
         edtSoporteTecnicoTarjetaVideoExtra_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoTarjetaVideoExtra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoTarjetaVideoExtra_Enabled), 5, 0), true);
         edtSoporteTecnicoCargadorLaptop_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoCargadorLaptop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoCargadorLaptop_Enabled), 5, 0), true);
         edtSoporteTecnicoCDsDVDs_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoCDsDVDs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoCDsDVDs_Enabled), 5, 0), true);
         edtSoporteTecnicoCableEspecial_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoCableEspecial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoCableEspecial_Enabled), 5, 0), true);
         edtSoporteTecnicoOtrosTaller_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoOtrosTaller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoOtrosTaller_Enabled), 5, 0), true);
         chkSoporteTecnicoCerrado.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoCerrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoCerrado.Enabled), 5, 0), true);
         chkSoporteTecnicoPendiente.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoPendiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoPendiente.Enabled), 5, 0), true);
         chkSoporteTecnicoPasaTaller.Enabled = 0;
         AssignProp("", false, chkSoporteTecnicoPasaTaller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkSoporteTecnicoPasaTaller.Enabled), 5, 0), true);
         edtSoporteTecnicoObservacion_Enabled = 0;
         AssignProp("", false, edtSoporteTecnicoObservacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSoporteTecnicoObservacion_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0F0( )
      {
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20231249524596", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("soportetecnico.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z202SoporteTecnicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202SoporteTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z203SoporteTecnicoFecha", context.localUtil.DToC( Z203SoporteTecnicoFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z204SoporteTecnicoHora", context.localUtil.TToC( Z204SoporteTecnicoHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z211SoporteTecnicoFechaResuelve", context.localUtil.DToC( Z211SoporteTecnicoFechaResuelve, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z212SoporteTecnicoHoraResuelve", context.localUtil.TToC( Z212SoporteTecnicoHoraResuelve, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z205SoporteTecnicoInventarioSerie", Z205SoporteTecnicoInventarioSerie);
         GxWebStd.gx_boolean_hidden_field( context, "Z206SoporteTecnicoInstalacion", Z206SoporteTecnicoInstalacion);
         GxWebStd.gx_boolean_hidden_field( context, "Z207SoporteTecnicoConfiguracion", Z207SoporteTecnicoConfiguracion);
         GxWebStd.gx_boolean_hidden_field( context, "Z208SoporteTecnicoInternetRouter", Z208SoporteTecnicoInternetRouter);
         GxWebStd.gx_boolean_hidden_field( context, "Z209SoporteTecnicoFormateo", Z209SoporteTecnicoFormateo);
         GxWebStd.gx_boolean_hidden_field( context, "Z210SoporteTecnicoReparacion", Z210SoporteTecnicoReparacion);
         GxWebStd.gx_boolean_hidden_field( context, "Z213SoporteTecnicoLimpieza", Z213SoporteTecnicoLimpieza);
         GxWebStd.gx_boolean_hidden_field( context, "Z214SoporteTecnicoPuntoRed", Z214SoporteTecnicoPuntoRed);
         GxWebStd.gx_boolean_hidden_field( context, "Z215SoporteTecnicoCambiosHardware", Z215SoporteTecnicoCambiosHardware);
         GxWebStd.gx_boolean_hidden_field( context, "Z216SoporteTecnicoCopiasRespaldo", Z216SoporteTecnicoCopiasRespaldo);
         GxWebStd.gx_hidden_field( context, "Z217SoporteTecnicoRam", Z217SoporteTecnicoRam);
         GxWebStd.gx_hidden_field( context, "Z218SoporteTecnicoDiscoDuro", Z218SoporteTecnicoDiscoDuro);
         GxWebStd.gx_hidden_field( context, "Z219SoporteTecnicoProcesador", Z219SoporteTecnicoProcesador);
         GxWebStd.gx_hidden_field( context, "Z220SoporteTecnicoMaletin", Z220SoporteTecnicoMaletin);
         GxWebStd.gx_hidden_field( context, "Z221SoporteTecnicoTonerCinta", Z221SoporteTecnicoTonerCinta);
         GxWebStd.gx_hidden_field( context, "Z222SoporteTecnicoTarjetaVideoExtra", Z222SoporteTecnicoTarjetaVideoExtra);
         GxWebStd.gx_hidden_field( context, "Z223SoporteTecnicoCargadorLaptop", Z223SoporteTecnicoCargadorLaptop);
         GxWebStd.gx_hidden_field( context, "Z224SoporteTecnicoCDsDVDs", Z224SoporteTecnicoCDsDVDs);
         GxWebStd.gx_hidden_field( context, "Z225SoporteTecnicoCableEspecial", Z225SoporteTecnicoCableEspecial);
         GxWebStd.gx_hidden_field( context, "Z226SoporteTecnicoOtrosTaller", Z226SoporteTecnicoOtrosTaller);
         GxWebStd.gx_boolean_hidden_field( context, "Z235SoporteTecnicoCerrado", Z235SoporteTecnicoCerrado);
         GxWebStd.gx_boolean_hidden_field( context, "Z236SoporteTecnicoPendiente", Z236SoporteTecnicoPendiente);
         GxWebStd.gx_boolean_hidden_field( context, "Z237SoporteTecnicoPasaTaller", Z237SoporteTecnicoPasaTaller);
         GxWebStd.gx_hidden_field( context, "Z227SoporteTecnicoObservacion", Z227SoporteTecnicoObservacion);
         GxWebStd.gx_hidden_field( context, "Z14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("soportetecnico.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SoporteTecnico" ;
      }

      public override string GetPgmdesc( )
      {
         return "Soporte Tecnico" ;
      }

      protected void InitializeNonKey0F16( )
      {
         A203SoporteTecnicoFecha = DateTime.MinValue;
         AssignAttri("", false, "A203SoporteTecnicoFecha", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
         A204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A204SoporteTecnicoHora", context.localUtil.TToC( A204SoporteTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
         A211SoporteTecnicoFechaResuelve = DateTime.MinValue;
         n211SoporteTecnicoFechaResuelve = false;
         AssignAttri("", false, "A211SoporteTecnicoFechaResuelve", context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"));
         n211SoporteTecnicoFechaResuelve = ((DateTime.MinValue==A211SoporteTecnicoFechaResuelve) ? true : false);
         A212SoporteTecnicoHoraResuelve = (DateTime)(DateTime.MinValue);
         n212SoporteTecnicoHoraResuelve = false;
         AssignAttri("", false, "A212SoporteTecnicoHoraResuelve", context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 0, 5, 0, 3, "/", ":", " "));
         n212SoporteTecnicoHoraResuelve = ((DateTime.MinValue==A212SoporteTecnicoHoraResuelve) ? true : false);
         A14TicketId = 0;
         AssignAttri("", false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         A15UsuarioId = 0;
         AssignAttri("", false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         A93UsuarioNombre = "";
         AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = "";
         AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A91UsuarioGerencia = "";
         AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
         A88UsuarioDepartamento = "";
         AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         A205SoporteTecnicoInventarioSerie = "";
         n205SoporteTecnicoInventarioSerie = false;
         AssignAttri("", false, "A205SoporteTecnicoInventarioSerie", A205SoporteTecnicoInventarioSerie);
         n205SoporteTecnicoInventarioSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A205SoporteTecnicoInventarioSerie)) ? true : false);
         A206SoporteTecnicoInstalacion = false;
         n206SoporteTecnicoInstalacion = false;
         AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
         n206SoporteTecnicoInstalacion = ((false==A206SoporteTecnicoInstalacion) ? true : false);
         A207SoporteTecnicoConfiguracion = false;
         n207SoporteTecnicoConfiguracion = false;
         AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
         n207SoporteTecnicoConfiguracion = ((false==A207SoporteTecnicoConfiguracion) ? true : false);
         A208SoporteTecnicoInternetRouter = false;
         n208SoporteTecnicoInternetRouter = false;
         AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
         n208SoporteTecnicoInternetRouter = ((false==A208SoporteTecnicoInternetRouter) ? true : false);
         A209SoporteTecnicoFormateo = false;
         n209SoporteTecnicoFormateo = false;
         AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
         n209SoporteTecnicoFormateo = ((false==A209SoporteTecnicoFormateo) ? true : false);
         A210SoporteTecnicoReparacion = false;
         n210SoporteTecnicoReparacion = false;
         AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
         n210SoporteTecnicoReparacion = ((false==A210SoporteTecnicoReparacion) ? true : false);
         A213SoporteTecnicoLimpieza = false;
         n213SoporteTecnicoLimpieza = false;
         AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
         n213SoporteTecnicoLimpieza = ((false==A213SoporteTecnicoLimpieza) ? true : false);
         A214SoporteTecnicoPuntoRed = false;
         n214SoporteTecnicoPuntoRed = false;
         AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
         n214SoporteTecnicoPuntoRed = ((false==A214SoporteTecnicoPuntoRed) ? true : false);
         A215SoporteTecnicoCambiosHardware = false;
         n215SoporteTecnicoCambiosHardware = false;
         AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
         n215SoporteTecnicoCambiosHardware = ((false==A215SoporteTecnicoCambiosHardware) ? true : false);
         A216SoporteTecnicoCopiasRespaldo = false;
         n216SoporteTecnicoCopiasRespaldo = false;
         AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
         n216SoporteTecnicoCopiasRespaldo = ((false==A216SoporteTecnicoCopiasRespaldo) ? true : false);
         A217SoporteTecnicoRam = "";
         n217SoporteTecnicoRam = false;
         AssignAttri("", false, "A217SoporteTecnicoRam", A217SoporteTecnicoRam);
         n217SoporteTecnicoRam = (String.IsNullOrEmpty(StringUtil.RTrim( A217SoporteTecnicoRam)) ? true : false);
         A218SoporteTecnicoDiscoDuro = "";
         n218SoporteTecnicoDiscoDuro = false;
         AssignAttri("", false, "A218SoporteTecnicoDiscoDuro", A218SoporteTecnicoDiscoDuro);
         n218SoporteTecnicoDiscoDuro = (String.IsNullOrEmpty(StringUtil.RTrim( A218SoporteTecnicoDiscoDuro)) ? true : false);
         A219SoporteTecnicoProcesador = "";
         n219SoporteTecnicoProcesador = false;
         AssignAttri("", false, "A219SoporteTecnicoProcesador", A219SoporteTecnicoProcesador);
         n219SoporteTecnicoProcesador = (String.IsNullOrEmpty(StringUtil.RTrim( A219SoporteTecnicoProcesador)) ? true : false);
         A220SoporteTecnicoMaletin = "";
         n220SoporteTecnicoMaletin = false;
         AssignAttri("", false, "A220SoporteTecnicoMaletin", A220SoporteTecnicoMaletin);
         n220SoporteTecnicoMaletin = (String.IsNullOrEmpty(StringUtil.RTrim( A220SoporteTecnicoMaletin)) ? true : false);
         A221SoporteTecnicoTonerCinta = "";
         n221SoporteTecnicoTonerCinta = false;
         AssignAttri("", false, "A221SoporteTecnicoTonerCinta", A221SoporteTecnicoTonerCinta);
         n221SoporteTecnicoTonerCinta = (String.IsNullOrEmpty(StringUtil.RTrim( A221SoporteTecnicoTonerCinta)) ? true : false);
         A222SoporteTecnicoTarjetaVideoExtra = "";
         n222SoporteTecnicoTarjetaVideoExtra = false;
         AssignAttri("", false, "A222SoporteTecnicoTarjetaVideoExtra", A222SoporteTecnicoTarjetaVideoExtra);
         n222SoporteTecnicoTarjetaVideoExtra = (String.IsNullOrEmpty(StringUtil.RTrim( A222SoporteTecnicoTarjetaVideoExtra)) ? true : false);
         A223SoporteTecnicoCargadorLaptop = "";
         n223SoporteTecnicoCargadorLaptop = false;
         AssignAttri("", false, "A223SoporteTecnicoCargadorLaptop", A223SoporteTecnicoCargadorLaptop);
         n223SoporteTecnicoCargadorLaptop = (String.IsNullOrEmpty(StringUtil.RTrim( A223SoporteTecnicoCargadorLaptop)) ? true : false);
         A224SoporteTecnicoCDsDVDs = "";
         n224SoporteTecnicoCDsDVDs = false;
         AssignAttri("", false, "A224SoporteTecnicoCDsDVDs", A224SoporteTecnicoCDsDVDs);
         n224SoporteTecnicoCDsDVDs = (String.IsNullOrEmpty(StringUtil.RTrim( A224SoporteTecnicoCDsDVDs)) ? true : false);
         A225SoporteTecnicoCableEspecial = "";
         n225SoporteTecnicoCableEspecial = false;
         AssignAttri("", false, "A225SoporteTecnicoCableEspecial", A225SoporteTecnicoCableEspecial);
         n225SoporteTecnicoCableEspecial = (String.IsNullOrEmpty(StringUtil.RTrim( A225SoporteTecnicoCableEspecial)) ? true : false);
         A226SoporteTecnicoOtrosTaller = "";
         n226SoporteTecnicoOtrosTaller = false;
         AssignAttri("", false, "A226SoporteTecnicoOtrosTaller", A226SoporteTecnicoOtrosTaller);
         n226SoporteTecnicoOtrosTaller = (String.IsNullOrEmpty(StringUtil.RTrim( A226SoporteTecnicoOtrosTaller)) ? true : false);
         A235SoporteTecnicoCerrado = false;
         AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
         A236SoporteTecnicoPendiente = false;
         AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
         A237SoporteTecnicoPasaTaller = false;
         AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
         A227SoporteTecnicoObservacion = "";
         n227SoporteTecnicoObservacion = false;
         AssignAttri("", false, "A227SoporteTecnicoObservacion", A227SoporteTecnicoObservacion);
         n227SoporteTecnicoObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A227SoporteTecnicoObservacion)) ? true : false);
         Z203SoporteTecnicoFecha = DateTime.MinValue;
         Z204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         Z211SoporteTecnicoFechaResuelve = DateTime.MinValue;
         Z212SoporteTecnicoHoraResuelve = (DateTime)(DateTime.MinValue);
         Z205SoporteTecnicoInventarioSerie = "";
         Z206SoporteTecnicoInstalacion = false;
         Z207SoporteTecnicoConfiguracion = false;
         Z208SoporteTecnicoInternetRouter = false;
         Z209SoporteTecnicoFormateo = false;
         Z210SoporteTecnicoReparacion = false;
         Z213SoporteTecnicoLimpieza = false;
         Z214SoporteTecnicoPuntoRed = false;
         Z215SoporteTecnicoCambiosHardware = false;
         Z216SoporteTecnicoCopiasRespaldo = false;
         Z217SoporteTecnicoRam = "";
         Z218SoporteTecnicoDiscoDuro = "";
         Z219SoporteTecnicoProcesador = "";
         Z220SoporteTecnicoMaletin = "";
         Z221SoporteTecnicoTonerCinta = "";
         Z222SoporteTecnicoTarjetaVideoExtra = "";
         Z223SoporteTecnicoCargadorLaptop = "";
         Z224SoporteTecnicoCDsDVDs = "";
         Z225SoporteTecnicoCableEspecial = "";
         Z226SoporteTecnicoOtrosTaller = "";
         Z235SoporteTecnicoCerrado = false;
         Z236SoporteTecnicoPendiente = false;
         Z237SoporteTecnicoPasaTaller = false;
         Z227SoporteTecnicoObservacion = "";
         Z14TicketId = 0;
      }

      protected void InitAll0F16( )
      {
         A202SoporteTecnicoId = 0;
         AssignAttri("", false, "A202SoporteTecnicoId", StringUtil.LTrimStr( (decimal)(A202SoporteTecnicoId), 10, 0));
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249524614", true, true);
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
         context.AddJavascriptSource("soportetecnico.js", "?20231249524614", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtSoporteTecnicoId_Internalname = "SOPORTETECNICOID";
         edtSoporteTecnicoFecha_Internalname = "SOPORTETECNICOFECHA";
         edtSoporteTecnicoHora_Internalname = "SOPORTETECNICOHORA";
         edtSoporteTecnicoFechaResuelve_Internalname = "SOPORTETECNICOFECHARESUELVE";
         edtSoporteTecnicoHoraResuelve_Internalname = "SOPORTETECNICOHORARESUELVE";
         edtTicketId_Internalname = "TICKETID";
         edtUsuarioId_Internalname = "USUARIOID";
         edtUsuarioNombre_Internalname = "USUARIONOMBRE";
         edtUsuarioRequerimiento_Internalname = "USUARIOREQUERIMIENTO";
         edtUsuarioGerencia_Internalname = "USUARIOGERENCIA";
         edtUsuarioDepartamento_Internalname = "USUARIODEPARTAMENTO";
         edtSoporteTecnicoInventarioSerie_Internalname = "SOPORTETECNICOINVENTARIOSERIE";
         chkSoporteTecnicoInstalacion_Internalname = "SOPORTETECNICOINSTALACION";
         chkSoporteTecnicoConfiguracion_Internalname = "SOPORTETECNICOCONFIGURACION";
         chkSoporteTecnicoInternetRouter_Internalname = "SOPORTETECNICOINTERNETROUTER";
         chkSoporteTecnicoFormateo_Internalname = "SOPORTETECNICOFORMATEO";
         chkSoporteTecnicoReparacion_Internalname = "SOPORTETECNICOREPARACION";
         chkSoporteTecnicoLimpieza_Internalname = "SOPORTETECNICOLIMPIEZA";
         chkSoporteTecnicoPuntoRed_Internalname = "SOPORTETECNICOPUNTORED";
         chkSoporteTecnicoCambiosHardware_Internalname = "SOPORTETECNICOCAMBIOSHARDWARE";
         chkSoporteTecnicoCopiasRespaldo_Internalname = "SOPORTETECNICOCOPIASRESPALDO";
         edtSoporteTecnicoRam_Internalname = "SOPORTETECNICORAM";
         edtSoporteTecnicoDiscoDuro_Internalname = "SOPORTETECNICODISCODURO";
         edtSoporteTecnicoProcesador_Internalname = "SOPORTETECNICOPROCESADOR";
         edtSoporteTecnicoMaletin_Internalname = "SOPORTETECNICOMALETIN";
         edtSoporteTecnicoTonerCinta_Internalname = "SOPORTETECNICOTONERCINTA";
         edtSoporteTecnicoTarjetaVideoExtra_Internalname = "SOPORTETECNICOTARJETAVIDEOEXTRA";
         edtSoporteTecnicoCargadorLaptop_Internalname = "SOPORTETECNICOCARGADORLAPTOP";
         edtSoporteTecnicoCDsDVDs_Internalname = "SOPORTETECNICOCDSDVDS";
         edtSoporteTecnicoCableEspecial_Internalname = "SOPORTETECNICOCABLEESPECIAL";
         edtSoporteTecnicoOtrosTaller_Internalname = "SOPORTETECNICOOTROSTALLER";
         chkSoporteTecnicoCerrado_Internalname = "SOPORTETECNICOCERRADO";
         chkSoporteTecnicoPendiente_Internalname = "SOPORTETECNICOPENDIENTE";
         chkSoporteTecnicoPasaTaller_Internalname = "SOPORTETECNICOPASATALLER";
         edtSoporteTecnicoObservacion_Internalname = "SOPORTETECNICOOBSERVACION";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_14_Internalname = "PROMPT_14";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Soporte Tecnico";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSoporteTecnicoObservacion_Enabled = 1;
         chkSoporteTecnicoPasaTaller.Enabled = 1;
         chkSoporteTecnicoPendiente.Enabled = 1;
         chkSoporteTecnicoCerrado.Enabled = 1;
         edtSoporteTecnicoOtrosTaller_Jsonclick = "";
         edtSoporteTecnicoOtrosTaller_Enabled = 1;
         edtSoporteTecnicoCableEspecial_Jsonclick = "";
         edtSoporteTecnicoCableEspecial_Enabled = 1;
         edtSoporteTecnicoCDsDVDs_Jsonclick = "";
         edtSoporteTecnicoCDsDVDs_Enabled = 1;
         edtSoporteTecnicoCargadorLaptop_Jsonclick = "";
         edtSoporteTecnicoCargadorLaptop_Enabled = 1;
         edtSoporteTecnicoTarjetaVideoExtra_Jsonclick = "";
         edtSoporteTecnicoTarjetaVideoExtra_Enabled = 1;
         edtSoporteTecnicoTonerCinta_Jsonclick = "";
         edtSoporteTecnicoTonerCinta_Enabled = 1;
         edtSoporteTecnicoMaletin_Jsonclick = "";
         edtSoporteTecnicoMaletin_Enabled = 1;
         edtSoporteTecnicoProcesador_Jsonclick = "";
         edtSoporteTecnicoProcesador_Enabled = 1;
         edtSoporteTecnicoDiscoDuro_Jsonclick = "";
         edtSoporteTecnicoDiscoDuro_Enabled = 1;
         edtSoporteTecnicoRam_Jsonclick = "";
         edtSoporteTecnicoRam_Enabled = 1;
         chkSoporteTecnicoCopiasRespaldo.Enabled = 1;
         chkSoporteTecnicoCambiosHardware.Enabled = 1;
         chkSoporteTecnicoPuntoRed.Enabled = 1;
         chkSoporteTecnicoLimpieza.Enabled = 1;
         chkSoporteTecnicoReparacion.Enabled = 1;
         chkSoporteTecnicoFormateo.Enabled = 1;
         chkSoporteTecnicoInternetRouter.Enabled = 1;
         chkSoporteTecnicoConfiguracion.Enabled = 1;
         chkSoporteTecnicoInstalacion.Enabled = 1;
         edtSoporteTecnicoInventarioSerie_Enabled = 1;
         edtUsuarioDepartamento_Enabled = 0;
         edtUsuarioGerencia_Enabled = 0;
         edtUsuarioRequerimiento_Enabled = 0;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Enabled = 0;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 0;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtTicketId_Jsonclick = "";
         edtTicketId_Enabled = 1;
         edtSoporteTecnicoHoraResuelve_Jsonclick = "";
         edtSoporteTecnicoHoraResuelve_Enabled = 1;
         edtSoporteTecnicoFechaResuelve_Jsonclick = "";
         edtSoporteTecnicoFechaResuelve_Enabled = 1;
         edtSoporteTecnicoHora_Jsonclick = "";
         edtSoporteTecnicoHora_Enabled = 1;
         edtSoporteTecnicoFecha_Jsonclick = "";
         edtSoporteTecnicoFecha_Enabled = 1;
         edtSoporteTecnicoId_Jsonclick = "";
         edtSoporteTecnicoId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         chkSoporteTecnicoInstalacion.Name = "SOPORTETECNICOINSTALACION";
         chkSoporteTecnicoInstalacion.WebTags = "";
         chkSoporteTecnicoInstalacion.Caption = "";
         AssignProp("", false, chkSoporteTecnicoInstalacion_Internalname, "TitleCaption", chkSoporteTecnicoInstalacion.Caption, true);
         chkSoporteTecnicoInstalacion.CheckedValue = "false";
         A206SoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A206SoporteTecnicoInstalacion));
         n206SoporteTecnicoInstalacion = false;
         AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
         chkSoporteTecnicoConfiguracion.Name = "SOPORTETECNICOCONFIGURACION";
         chkSoporteTecnicoConfiguracion.WebTags = "";
         chkSoporteTecnicoConfiguracion.Caption = "";
         AssignProp("", false, chkSoporteTecnicoConfiguracion_Internalname, "TitleCaption", chkSoporteTecnicoConfiguracion.Caption, true);
         chkSoporteTecnicoConfiguracion.CheckedValue = "false";
         A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion));
         n207SoporteTecnicoConfiguracion = false;
         AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
         chkSoporteTecnicoInternetRouter.Name = "SOPORTETECNICOINTERNETROUTER";
         chkSoporteTecnicoInternetRouter.WebTags = "";
         chkSoporteTecnicoInternetRouter.Caption = "";
         AssignProp("", false, chkSoporteTecnicoInternetRouter_Internalname, "TitleCaption", chkSoporteTecnicoInternetRouter.Caption, true);
         chkSoporteTecnicoInternetRouter.CheckedValue = "false";
         A208SoporteTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A208SoporteTecnicoInternetRouter));
         n208SoporteTecnicoInternetRouter = false;
         AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
         chkSoporteTecnicoFormateo.Name = "SOPORTETECNICOFORMATEO";
         chkSoporteTecnicoFormateo.WebTags = "";
         chkSoporteTecnicoFormateo.Caption = "";
         AssignProp("", false, chkSoporteTecnicoFormateo_Internalname, "TitleCaption", chkSoporteTecnicoFormateo.Caption, true);
         chkSoporteTecnicoFormateo.CheckedValue = "false";
         A209SoporteTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A209SoporteTecnicoFormateo));
         n209SoporteTecnicoFormateo = false;
         AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
         chkSoporteTecnicoReparacion.Name = "SOPORTETECNICOREPARACION";
         chkSoporteTecnicoReparacion.WebTags = "";
         chkSoporteTecnicoReparacion.Caption = "";
         AssignProp("", false, chkSoporteTecnicoReparacion_Internalname, "TitleCaption", chkSoporteTecnicoReparacion.Caption, true);
         chkSoporteTecnicoReparacion.CheckedValue = "false";
         A210SoporteTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A210SoporteTecnicoReparacion));
         n210SoporteTecnicoReparacion = false;
         AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
         chkSoporteTecnicoLimpieza.Name = "SOPORTETECNICOLIMPIEZA";
         chkSoporteTecnicoLimpieza.WebTags = "";
         chkSoporteTecnicoLimpieza.Caption = "";
         AssignProp("", false, chkSoporteTecnicoLimpieza_Internalname, "TitleCaption", chkSoporteTecnicoLimpieza.Caption, true);
         chkSoporteTecnicoLimpieza.CheckedValue = "false";
         A213SoporteTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A213SoporteTecnicoLimpieza));
         n213SoporteTecnicoLimpieza = false;
         AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
         chkSoporteTecnicoPuntoRed.Name = "SOPORTETECNICOPUNTORED";
         chkSoporteTecnicoPuntoRed.WebTags = "";
         chkSoporteTecnicoPuntoRed.Caption = "";
         AssignProp("", false, chkSoporteTecnicoPuntoRed_Internalname, "TitleCaption", chkSoporteTecnicoPuntoRed.Caption, true);
         chkSoporteTecnicoPuntoRed.CheckedValue = "false";
         A214SoporteTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A214SoporteTecnicoPuntoRed));
         n214SoporteTecnicoPuntoRed = false;
         AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
         chkSoporteTecnicoCambiosHardware.Name = "SOPORTETECNICOCAMBIOSHARDWARE";
         chkSoporteTecnicoCambiosHardware.WebTags = "";
         chkSoporteTecnicoCambiosHardware.Caption = "";
         AssignProp("", false, chkSoporteTecnicoCambiosHardware_Internalname, "TitleCaption", chkSoporteTecnicoCambiosHardware.Caption, true);
         chkSoporteTecnicoCambiosHardware.CheckedValue = "false";
         A215SoporteTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A215SoporteTecnicoCambiosHardware));
         n215SoporteTecnicoCambiosHardware = false;
         AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
         chkSoporteTecnicoCopiasRespaldo.Name = "SOPORTETECNICOCOPIASRESPALDO";
         chkSoporteTecnicoCopiasRespaldo.WebTags = "";
         chkSoporteTecnicoCopiasRespaldo.Caption = "";
         AssignProp("", false, chkSoporteTecnicoCopiasRespaldo_Internalname, "TitleCaption", chkSoporteTecnicoCopiasRespaldo.Caption, true);
         chkSoporteTecnicoCopiasRespaldo.CheckedValue = "false";
         A216SoporteTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A216SoporteTecnicoCopiasRespaldo));
         n216SoporteTecnicoCopiasRespaldo = false;
         AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
         chkSoporteTecnicoCerrado.Name = "SOPORTETECNICOCERRADO";
         chkSoporteTecnicoCerrado.WebTags = "";
         chkSoporteTecnicoCerrado.Caption = "";
         AssignProp("", false, chkSoporteTecnicoCerrado_Internalname, "TitleCaption", chkSoporteTecnicoCerrado.Caption, true);
         chkSoporteTecnicoCerrado.CheckedValue = "false";
         A235SoporteTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A235SoporteTecnicoCerrado));
         AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
         chkSoporteTecnicoPendiente.Name = "SOPORTETECNICOPENDIENTE";
         chkSoporteTecnicoPendiente.WebTags = "";
         chkSoporteTecnicoPendiente.Caption = "";
         AssignProp("", false, chkSoporteTecnicoPendiente_Internalname, "TitleCaption", chkSoporteTecnicoPendiente.Caption, true);
         chkSoporteTecnicoPendiente.CheckedValue = "false";
         A236SoporteTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A236SoporteTecnicoPendiente));
         AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
         chkSoporteTecnicoPasaTaller.Name = "SOPORTETECNICOPASATALLER";
         chkSoporteTecnicoPasaTaller.WebTags = "";
         chkSoporteTecnicoPasaTaller.Caption = "";
         AssignProp("", false, chkSoporteTecnicoPasaTaller_Internalname, "TitleCaption", chkSoporteTecnicoPasaTaller.Caption, true);
         chkSoporteTecnicoPasaTaller.CheckedValue = "false";
         A237SoporteTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A237SoporteTecnicoPasaTaller));
         AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtSoporteTecnicoFecha_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Soportetecnicoid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A206SoporteTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A206SoporteTecnicoInstalacion));
         n206SoporteTecnicoInstalacion = false;
         A207SoporteTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A207SoporteTecnicoConfiguracion));
         n207SoporteTecnicoConfiguracion = false;
         A208SoporteTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A208SoporteTecnicoInternetRouter));
         n208SoporteTecnicoInternetRouter = false;
         A209SoporteTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A209SoporteTecnicoFormateo));
         n209SoporteTecnicoFormateo = false;
         A210SoporteTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A210SoporteTecnicoReparacion));
         n210SoporteTecnicoReparacion = false;
         A213SoporteTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A213SoporteTecnicoLimpieza));
         n213SoporteTecnicoLimpieza = false;
         A214SoporteTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A214SoporteTecnicoPuntoRed));
         n214SoporteTecnicoPuntoRed = false;
         A215SoporteTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A215SoporteTecnicoCambiosHardware));
         n215SoporteTecnicoCambiosHardware = false;
         A216SoporteTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A216SoporteTecnicoCopiasRespaldo));
         n216SoporteTecnicoCopiasRespaldo = false;
         A235SoporteTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A235SoporteTecnicoCerrado));
         A236SoporteTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A236SoporteTecnicoPendiente));
         A237SoporteTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A237SoporteTecnicoPasaTaller));
         /*  Sending validation outputs */
         AssignAttri("", false, "A203SoporteTecnicoFecha", context.localUtil.Format(A203SoporteTecnicoFecha, "99/99/9999"));
         AssignAttri("", false, "A204SoporteTecnicoHora", context.localUtil.TToC( A204SoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A211SoporteTecnicoFechaResuelve", context.localUtil.Format(A211SoporteTecnicoFechaResuelve, "99/99/9999"));
         AssignAttri("", false, "A212SoporteTecnicoHoraResuelve", context.localUtil.TToC( A212SoporteTecnicoHoraResuelve, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
         AssignAttri("", false, "A205SoporteTecnicoInventarioSerie", A205SoporteTecnicoInventarioSerie);
         AssignAttri("", false, "A206SoporteTecnicoInstalacion", A206SoporteTecnicoInstalacion);
         AssignAttri("", false, "A207SoporteTecnicoConfiguracion", A207SoporteTecnicoConfiguracion);
         AssignAttri("", false, "A208SoporteTecnicoInternetRouter", A208SoporteTecnicoInternetRouter);
         AssignAttri("", false, "A209SoporteTecnicoFormateo", A209SoporteTecnicoFormateo);
         AssignAttri("", false, "A210SoporteTecnicoReparacion", A210SoporteTecnicoReparacion);
         AssignAttri("", false, "A213SoporteTecnicoLimpieza", A213SoporteTecnicoLimpieza);
         AssignAttri("", false, "A214SoporteTecnicoPuntoRed", A214SoporteTecnicoPuntoRed);
         AssignAttri("", false, "A215SoporteTecnicoCambiosHardware", A215SoporteTecnicoCambiosHardware);
         AssignAttri("", false, "A216SoporteTecnicoCopiasRespaldo", A216SoporteTecnicoCopiasRespaldo);
         AssignAttri("", false, "A217SoporteTecnicoRam", A217SoporteTecnicoRam);
         AssignAttri("", false, "A218SoporteTecnicoDiscoDuro", A218SoporteTecnicoDiscoDuro);
         AssignAttri("", false, "A219SoporteTecnicoProcesador", A219SoporteTecnicoProcesador);
         AssignAttri("", false, "A220SoporteTecnicoMaletin", A220SoporteTecnicoMaletin);
         AssignAttri("", false, "A221SoporteTecnicoTonerCinta", A221SoporteTecnicoTonerCinta);
         AssignAttri("", false, "A222SoporteTecnicoTarjetaVideoExtra", A222SoporteTecnicoTarjetaVideoExtra);
         AssignAttri("", false, "A223SoporteTecnicoCargadorLaptop", A223SoporteTecnicoCargadorLaptop);
         AssignAttri("", false, "A224SoporteTecnicoCDsDVDs", A224SoporteTecnicoCDsDVDs);
         AssignAttri("", false, "A225SoporteTecnicoCableEspecial", A225SoporteTecnicoCableEspecial);
         AssignAttri("", false, "A226SoporteTecnicoOtrosTaller", A226SoporteTecnicoOtrosTaller);
         AssignAttri("", false, "A235SoporteTecnicoCerrado", A235SoporteTecnicoCerrado);
         AssignAttri("", false, "A236SoporteTecnicoPendiente", A236SoporteTecnicoPendiente);
         AssignAttri("", false, "A237SoporteTecnicoPasaTaller", A237SoporteTecnicoPasaTaller);
         AssignAttri("", false, "A227SoporteTecnicoObservacion", A227SoporteTecnicoObservacion);
         AssignAttri("", false, "A15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ".", "")));
         AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
         AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
         AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z202SoporteTecnicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202SoporteTecnicoId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z203SoporteTecnicoFecha", context.localUtil.Format(Z203SoporteTecnicoFecha, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z204SoporteTecnicoHora", context.localUtil.TToC( Z204SoporteTecnicoHora, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z211SoporteTecnicoFechaResuelve", context.localUtil.Format(Z211SoporteTecnicoFechaResuelve, "99/99/9999"));
         GxWebStd.gx_hidden_field( context, "Z212SoporteTecnicoHoraResuelve", context.localUtil.TToC( Z212SoporteTecnicoHoraResuelve, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z205SoporteTecnicoInventarioSerie", Z205SoporteTecnicoInventarioSerie);
         GxWebStd.gx_hidden_field( context, "Z206SoporteTecnicoInstalacion", StringUtil.BoolToStr( Z206SoporteTecnicoInstalacion));
         GxWebStd.gx_hidden_field( context, "Z207SoporteTecnicoConfiguracion", StringUtil.BoolToStr( Z207SoporteTecnicoConfiguracion));
         GxWebStd.gx_hidden_field( context, "Z208SoporteTecnicoInternetRouter", StringUtil.BoolToStr( Z208SoporteTecnicoInternetRouter));
         GxWebStd.gx_hidden_field( context, "Z209SoporteTecnicoFormateo", StringUtil.BoolToStr( Z209SoporteTecnicoFormateo));
         GxWebStd.gx_hidden_field( context, "Z210SoporteTecnicoReparacion", StringUtil.BoolToStr( Z210SoporteTecnicoReparacion));
         GxWebStd.gx_hidden_field( context, "Z213SoporteTecnicoLimpieza", StringUtil.BoolToStr( Z213SoporteTecnicoLimpieza));
         GxWebStd.gx_hidden_field( context, "Z214SoporteTecnicoPuntoRed", StringUtil.BoolToStr( Z214SoporteTecnicoPuntoRed));
         GxWebStd.gx_hidden_field( context, "Z215SoporteTecnicoCambiosHardware", StringUtil.BoolToStr( Z215SoporteTecnicoCambiosHardware));
         GxWebStd.gx_hidden_field( context, "Z216SoporteTecnicoCopiasRespaldo", StringUtil.BoolToStr( Z216SoporteTecnicoCopiasRespaldo));
         GxWebStd.gx_hidden_field( context, "Z217SoporteTecnicoRam", Z217SoporteTecnicoRam);
         GxWebStd.gx_hidden_field( context, "Z218SoporteTecnicoDiscoDuro", Z218SoporteTecnicoDiscoDuro);
         GxWebStd.gx_hidden_field( context, "Z219SoporteTecnicoProcesador", Z219SoporteTecnicoProcesador);
         GxWebStd.gx_hidden_field( context, "Z220SoporteTecnicoMaletin", Z220SoporteTecnicoMaletin);
         GxWebStd.gx_hidden_field( context, "Z221SoporteTecnicoTonerCinta", Z221SoporteTecnicoTonerCinta);
         GxWebStd.gx_hidden_field( context, "Z222SoporteTecnicoTarjetaVideoExtra", Z222SoporteTecnicoTarjetaVideoExtra);
         GxWebStd.gx_hidden_field( context, "Z223SoporteTecnicoCargadorLaptop", Z223SoporteTecnicoCargadorLaptop);
         GxWebStd.gx_hidden_field( context, "Z224SoporteTecnicoCDsDVDs", Z224SoporteTecnicoCDsDVDs);
         GxWebStd.gx_hidden_field( context, "Z225SoporteTecnicoCableEspecial", Z225SoporteTecnicoCableEspecial);
         GxWebStd.gx_hidden_field( context, "Z226SoporteTecnicoOtrosTaller", Z226SoporteTecnicoOtrosTaller);
         GxWebStd.gx_hidden_field( context, "Z235SoporteTecnicoCerrado", StringUtil.BoolToStr( Z235SoporteTecnicoCerrado));
         GxWebStd.gx_hidden_field( context, "Z236SoporteTecnicoPendiente", StringUtil.BoolToStr( Z236SoporteTecnicoPendiente));
         GxWebStd.gx_hidden_field( context, "Z237SoporteTecnicoPasaTaller", StringUtil.BoolToStr( Z237SoporteTecnicoPasaTaller));
         GxWebStd.gx_hidden_field( context, "Z227SoporteTecnicoObservacion", Z227SoporteTecnicoObservacion);
         GxWebStd.gx_hidden_field( context, "Z15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15UsuarioId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z93UsuarioNombre", Z93UsuarioNombre);
         GxWebStd.gx_hidden_field( context, "Z94UsuarioRequerimiento", Z94UsuarioRequerimiento);
         GxWebStd.gx_hidden_field( context, "Z91UsuarioGerencia", Z91UsuarioGerencia);
         GxWebStd.gx_hidden_field( context, "Z88UsuarioDepartamento", Z88UsuarioDepartamento);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Ticketid( )
      {
         /* Using cursor T000F15 */
         pr_default.execute(13, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
         }
         A15UsuarioId = T000F15_A15UsuarioId[0];
         pr_default.close(13);
         /* Using cursor T000F16 */
         pr_default.execute(14, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000F16_A93UsuarioNombre[0];
         A94UsuarioRequerimiento = T000F16_A94UsuarioRequerimiento[0];
         A91UsuarioGerencia = T000F16_A91UsuarioGerencia[0];
         A88UsuarioDepartamento = T000F16_A88UsuarioDepartamento[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ".", "")));
         AssignAttri("", false, "A93UsuarioNombre", A93UsuarioNombre);
         AssignAttri("", false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         AssignAttri("", false, "A91UsuarioGerencia", A91UsuarioGerencia);
         AssignAttri("", false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
         setEventMetadata("VALID_SOPORTETECNICOID","{handler:'Valid_Soportetecnicoid',iparms:[{av:'A202SoporteTecnicoId',fld:'SOPORTETECNICOID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("VALID_SOPORTETECNICOID",",oparms:[{av:'A203SoporteTecnicoFecha',fld:'SOPORTETECNICOFECHA',pic:''},{av:'A204SoporteTecnicoHora',fld:'SOPORTETECNICOHORA',pic:'99:99'},{av:'A211SoporteTecnicoFechaResuelve',fld:'SOPORTETECNICOFECHARESUELVE',pic:''},{av:'A212SoporteTecnicoHoraResuelve',fld:'SOPORTETECNICOHORARESUELVE',pic:'99:99'},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9'},{av:'A205SoporteTecnicoInventarioSerie',fld:'SOPORTETECNICOINVENTARIOSERIE',pic:''},{av:'A217SoporteTecnicoRam',fld:'SOPORTETECNICORAM',pic:''},{av:'A218SoporteTecnicoDiscoDuro',fld:'SOPORTETECNICODISCODURO',pic:''},{av:'A219SoporteTecnicoProcesador',fld:'SOPORTETECNICOPROCESADOR',pic:''},{av:'A220SoporteTecnicoMaletin',fld:'SOPORTETECNICOMALETIN',pic:''},{av:'A221SoporteTecnicoTonerCinta',fld:'SOPORTETECNICOTONERCINTA',pic:''},{av:'A222SoporteTecnicoTarjetaVideoExtra',fld:'SOPORTETECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A223SoporteTecnicoCargadorLaptop',fld:'SOPORTETECNICOCARGADORLAPTOP',pic:''},{av:'A224SoporteTecnicoCDsDVDs',fld:'SOPORTETECNICOCDSDVDS',pic:''},{av:'A225SoporteTecnicoCableEspecial',fld:'SOPORTETECNICOCABLEESPECIAL',pic:''},{av:'A226SoporteTecnicoOtrosTaller',fld:'SOPORTETECNICOOTROSTALLER',pic:''},{av:'A227SoporteTecnicoObservacion',fld:'SOPORTETECNICOOBSERVACION',pic:''},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A91UsuarioGerencia',fld:'USUARIOGERENCIA',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z202SoporteTecnicoId'},{av:'Z203SoporteTecnicoFecha'},{av:'Z204SoporteTecnicoHora'},{av:'Z211SoporteTecnicoFechaResuelve'},{av:'Z212SoporteTecnicoHoraResuelve'},{av:'Z14TicketId'},{av:'Z205SoporteTecnicoInventarioSerie'},{av:'Z206SoporteTecnicoInstalacion'},{av:'Z207SoporteTecnicoConfiguracion'},{av:'Z208SoporteTecnicoInternetRouter'},{av:'Z209SoporteTecnicoFormateo'},{av:'Z210SoporteTecnicoReparacion'},{av:'Z213SoporteTecnicoLimpieza'},{av:'Z214SoporteTecnicoPuntoRed'},{av:'Z215SoporteTecnicoCambiosHardware'},{av:'Z216SoporteTecnicoCopiasRespaldo'},{av:'Z217SoporteTecnicoRam'},{av:'Z218SoporteTecnicoDiscoDuro'},{av:'Z219SoporteTecnicoProcesador'},{av:'Z220SoporteTecnicoMaletin'},{av:'Z221SoporteTecnicoTonerCinta'},{av:'Z222SoporteTecnicoTarjetaVideoExtra'},{av:'Z223SoporteTecnicoCargadorLaptop'},{av:'Z224SoporteTecnicoCDsDVDs'},{av:'Z225SoporteTecnicoCableEspecial'},{av:'Z226SoporteTecnicoOtrosTaller'},{av:'Z235SoporteTecnicoCerrado'},{av:'Z236SoporteTecnicoPendiente'},{av:'Z237SoporteTecnicoPasaTaller'},{av:'Z227SoporteTecnicoObservacion'},{av:'Z15UsuarioId'},{av:'Z93UsuarioNombre'},{av:'Z94UsuarioRequerimiento'},{av:'Z91UsuarioGerencia'},{av:'Z88UsuarioDepartamento'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
         setEventMetadata("VALID_SOPORTETECNICOFECHA","{handler:'Valid_Soportetecnicofecha',iparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("VALID_SOPORTETECNICOFECHA",",oparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
         setEventMetadata("VALID_SOPORTETECNICOFECHARESUELVE","{handler:'Valid_Soportetecnicofecharesuelve',iparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("VALID_SOPORTETECNICOFECHARESUELVE",",oparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9'},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A91UsuarioGerencia',fld:'USUARIOGERENCIA',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A91UsuarioGerencia',fld:'USUARIOGERENCIA',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'A206SoporteTecnicoInstalacion',fld:'SOPORTETECNICOINSTALACION',pic:''},{av:'A207SoporteTecnicoConfiguracion',fld:'SOPORTETECNICOCONFIGURACION',pic:''},{av:'A208SoporteTecnicoInternetRouter',fld:'SOPORTETECNICOINTERNETROUTER',pic:''},{av:'A209SoporteTecnicoFormateo',fld:'SOPORTETECNICOFORMATEO',pic:''},{av:'A210SoporteTecnicoReparacion',fld:'SOPORTETECNICOREPARACION',pic:''},{av:'A213SoporteTecnicoLimpieza',fld:'SOPORTETECNICOLIMPIEZA',pic:''},{av:'A214SoporteTecnicoPuntoRed',fld:'SOPORTETECNICOPUNTORED',pic:''},{av:'A215SoporteTecnicoCambiosHardware',fld:'SOPORTETECNICOCAMBIOSHARDWARE',pic:''},{av:'A216SoporteTecnicoCopiasRespaldo',fld:'SOPORTETECNICOCOPIASRESPALDO',pic:''},{av:'A235SoporteTecnicoCerrado',fld:'SOPORTETECNICOCERRADO',pic:''},{av:'A236SoporteTecnicoPendiente',fld:'SOPORTETECNICOPENDIENTE',pic:''},{av:'A237SoporteTecnicoPasaTaller',fld:'SOPORTETECNICOPASATALLER',pic:''}]}");
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
         pr_default.close(1);
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z203SoporteTecnicoFecha = DateTime.MinValue;
         Z204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         Z211SoporteTecnicoFechaResuelve = DateTime.MinValue;
         Z212SoporteTecnicoHoraResuelve = (DateTime)(DateTime.MinValue);
         Z205SoporteTecnicoInventarioSerie = "";
         Z217SoporteTecnicoRam = "";
         Z218SoporteTecnicoDiscoDuro = "";
         Z219SoporteTecnicoProcesador = "";
         Z220SoporteTecnicoMaletin = "";
         Z221SoporteTecnicoTonerCinta = "";
         Z222SoporteTecnicoTarjetaVideoExtra = "";
         Z223SoporteTecnicoCargadorLaptop = "";
         Z224SoporteTecnicoCDsDVDs = "";
         Z225SoporteTecnicoCableEspecial = "";
         Z226SoporteTecnicoOtrosTaller = "";
         Z227SoporteTecnicoObservacion = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A203SoporteTecnicoFecha = DateTime.MinValue;
         A204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         A211SoporteTecnicoFechaResuelve = DateTime.MinValue;
         A212SoporteTecnicoHoraResuelve = (DateTime)(DateTime.MinValue);
         sImgUrl = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A205SoporteTecnicoInventarioSerie = "";
         A217SoporteTecnicoRam = "";
         A218SoporteTecnicoDiscoDuro = "";
         A219SoporteTecnicoProcesador = "";
         A220SoporteTecnicoMaletin = "";
         A221SoporteTecnicoTonerCinta = "";
         A222SoporteTecnicoTarjetaVideoExtra = "";
         A223SoporteTecnicoCargadorLaptop = "";
         A224SoporteTecnicoCDsDVDs = "";
         A225SoporteTecnicoCableEspecial = "";
         A226SoporteTecnicoOtrosTaller = "";
         A227SoporteTecnicoObservacion = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z93UsuarioNombre = "";
         Z94UsuarioRequerimiento = "";
         Z91UsuarioGerencia = "";
         Z88UsuarioDepartamento = "";
         T000F6_A202SoporteTecnicoId = new long[1] ;
         T000F6_A203SoporteTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         T000F6_A204SoporteTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         T000F6_A211SoporteTecnicoFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         T000F6_n211SoporteTecnicoFechaResuelve = new bool[] {false} ;
         T000F6_A212SoporteTecnicoHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T000F6_n212SoporteTecnicoHoraResuelve = new bool[] {false} ;
         T000F6_A93UsuarioNombre = new string[] {""} ;
         T000F6_A94UsuarioRequerimiento = new string[] {""} ;
         T000F6_A91UsuarioGerencia = new string[] {""} ;
         T000F6_A88UsuarioDepartamento = new string[] {""} ;
         T000F6_A205SoporteTecnicoInventarioSerie = new string[] {""} ;
         T000F6_n205SoporteTecnicoInventarioSerie = new bool[] {false} ;
         T000F6_A206SoporteTecnicoInstalacion = new bool[] {false} ;
         T000F6_n206SoporteTecnicoInstalacion = new bool[] {false} ;
         T000F6_A207SoporteTecnicoConfiguracion = new bool[] {false} ;
         T000F6_n207SoporteTecnicoConfiguracion = new bool[] {false} ;
         T000F6_A208SoporteTecnicoInternetRouter = new bool[] {false} ;
         T000F6_n208SoporteTecnicoInternetRouter = new bool[] {false} ;
         T000F6_A209SoporteTecnicoFormateo = new bool[] {false} ;
         T000F6_n209SoporteTecnicoFormateo = new bool[] {false} ;
         T000F6_A210SoporteTecnicoReparacion = new bool[] {false} ;
         T000F6_n210SoporteTecnicoReparacion = new bool[] {false} ;
         T000F6_A213SoporteTecnicoLimpieza = new bool[] {false} ;
         T000F6_n213SoporteTecnicoLimpieza = new bool[] {false} ;
         T000F6_A214SoporteTecnicoPuntoRed = new bool[] {false} ;
         T000F6_n214SoporteTecnicoPuntoRed = new bool[] {false} ;
         T000F6_A215SoporteTecnicoCambiosHardware = new bool[] {false} ;
         T000F6_n215SoporteTecnicoCambiosHardware = new bool[] {false} ;
         T000F6_A216SoporteTecnicoCopiasRespaldo = new bool[] {false} ;
         T000F6_n216SoporteTecnicoCopiasRespaldo = new bool[] {false} ;
         T000F6_A217SoporteTecnicoRam = new string[] {""} ;
         T000F6_n217SoporteTecnicoRam = new bool[] {false} ;
         T000F6_A218SoporteTecnicoDiscoDuro = new string[] {""} ;
         T000F6_n218SoporteTecnicoDiscoDuro = new bool[] {false} ;
         T000F6_A219SoporteTecnicoProcesador = new string[] {""} ;
         T000F6_n219SoporteTecnicoProcesador = new bool[] {false} ;
         T000F6_A220SoporteTecnicoMaletin = new string[] {""} ;
         T000F6_n220SoporteTecnicoMaletin = new bool[] {false} ;
         T000F6_A221SoporteTecnicoTonerCinta = new string[] {""} ;
         T000F6_n221SoporteTecnicoTonerCinta = new bool[] {false} ;
         T000F6_A222SoporteTecnicoTarjetaVideoExtra = new string[] {""} ;
         T000F6_n222SoporteTecnicoTarjetaVideoExtra = new bool[] {false} ;
         T000F6_A223SoporteTecnicoCargadorLaptop = new string[] {""} ;
         T000F6_n223SoporteTecnicoCargadorLaptop = new bool[] {false} ;
         T000F6_A224SoporteTecnicoCDsDVDs = new string[] {""} ;
         T000F6_n224SoporteTecnicoCDsDVDs = new bool[] {false} ;
         T000F6_A225SoporteTecnicoCableEspecial = new string[] {""} ;
         T000F6_n225SoporteTecnicoCableEspecial = new bool[] {false} ;
         T000F6_A226SoporteTecnicoOtrosTaller = new string[] {""} ;
         T000F6_n226SoporteTecnicoOtrosTaller = new bool[] {false} ;
         T000F6_A235SoporteTecnicoCerrado = new bool[] {false} ;
         T000F6_A236SoporteTecnicoPendiente = new bool[] {false} ;
         T000F6_A237SoporteTecnicoPasaTaller = new bool[] {false} ;
         T000F6_A227SoporteTecnicoObservacion = new string[] {""} ;
         T000F6_n227SoporteTecnicoObservacion = new bool[] {false} ;
         T000F6_A14TicketId = new long[1] ;
         T000F6_A15UsuarioId = new short[1] ;
         T000F4_A15UsuarioId = new short[1] ;
         T000F5_A93UsuarioNombre = new string[] {""} ;
         T000F5_A94UsuarioRequerimiento = new string[] {""} ;
         T000F5_A91UsuarioGerencia = new string[] {""} ;
         T000F5_A88UsuarioDepartamento = new string[] {""} ;
         T000F7_A15UsuarioId = new short[1] ;
         T000F8_A93UsuarioNombre = new string[] {""} ;
         T000F8_A94UsuarioRequerimiento = new string[] {""} ;
         T000F8_A91UsuarioGerencia = new string[] {""} ;
         T000F8_A88UsuarioDepartamento = new string[] {""} ;
         T000F9_A202SoporteTecnicoId = new long[1] ;
         T000F3_A202SoporteTecnicoId = new long[1] ;
         T000F3_A203SoporteTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         T000F3_A204SoporteTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         T000F3_A211SoporteTecnicoFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         T000F3_n211SoporteTecnicoFechaResuelve = new bool[] {false} ;
         T000F3_A212SoporteTecnicoHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T000F3_n212SoporteTecnicoHoraResuelve = new bool[] {false} ;
         T000F3_A205SoporteTecnicoInventarioSerie = new string[] {""} ;
         T000F3_n205SoporteTecnicoInventarioSerie = new bool[] {false} ;
         T000F3_A206SoporteTecnicoInstalacion = new bool[] {false} ;
         T000F3_n206SoporteTecnicoInstalacion = new bool[] {false} ;
         T000F3_A207SoporteTecnicoConfiguracion = new bool[] {false} ;
         T000F3_n207SoporteTecnicoConfiguracion = new bool[] {false} ;
         T000F3_A208SoporteTecnicoInternetRouter = new bool[] {false} ;
         T000F3_n208SoporteTecnicoInternetRouter = new bool[] {false} ;
         T000F3_A209SoporteTecnicoFormateo = new bool[] {false} ;
         T000F3_n209SoporteTecnicoFormateo = new bool[] {false} ;
         T000F3_A210SoporteTecnicoReparacion = new bool[] {false} ;
         T000F3_n210SoporteTecnicoReparacion = new bool[] {false} ;
         T000F3_A213SoporteTecnicoLimpieza = new bool[] {false} ;
         T000F3_n213SoporteTecnicoLimpieza = new bool[] {false} ;
         T000F3_A214SoporteTecnicoPuntoRed = new bool[] {false} ;
         T000F3_n214SoporteTecnicoPuntoRed = new bool[] {false} ;
         T000F3_A215SoporteTecnicoCambiosHardware = new bool[] {false} ;
         T000F3_n215SoporteTecnicoCambiosHardware = new bool[] {false} ;
         T000F3_A216SoporteTecnicoCopiasRespaldo = new bool[] {false} ;
         T000F3_n216SoporteTecnicoCopiasRespaldo = new bool[] {false} ;
         T000F3_A217SoporteTecnicoRam = new string[] {""} ;
         T000F3_n217SoporteTecnicoRam = new bool[] {false} ;
         T000F3_A218SoporteTecnicoDiscoDuro = new string[] {""} ;
         T000F3_n218SoporteTecnicoDiscoDuro = new bool[] {false} ;
         T000F3_A219SoporteTecnicoProcesador = new string[] {""} ;
         T000F3_n219SoporteTecnicoProcesador = new bool[] {false} ;
         T000F3_A220SoporteTecnicoMaletin = new string[] {""} ;
         T000F3_n220SoporteTecnicoMaletin = new bool[] {false} ;
         T000F3_A221SoporteTecnicoTonerCinta = new string[] {""} ;
         T000F3_n221SoporteTecnicoTonerCinta = new bool[] {false} ;
         T000F3_A222SoporteTecnicoTarjetaVideoExtra = new string[] {""} ;
         T000F3_n222SoporteTecnicoTarjetaVideoExtra = new bool[] {false} ;
         T000F3_A223SoporteTecnicoCargadorLaptop = new string[] {""} ;
         T000F3_n223SoporteTecnicoCargadorLaptop = new bool[] {false} ;
         T000F3_A224SoporteTecnicoCDsDVDs = new string[] {""} ;
         T000F3_n224SoporteTecnicoCDsDVDs = new bool[] {false} ;
         T000F3_A225SoporteTecnicoCableEspecial = new string[] {""} ;
         T000F3_n225SoporteTecnicoCableEspecial = new bool[] {false} ;
         T000F3_A226SoporteTecnicoOtrosTaller = new string[] {""} ;
         T000F3_n226SoporteTecnicoOtrosTaller = new bool[] {false} ;
         T000F3_A235SoporteTecnicoCerrado = new bool[] {false} ;
         T000F3_A236SoporteTecnicoPendiente = new bool[] {false} ;
         T000F3_A237SoporteTecnicoPasaTaller = new bool[] {false} ;
         T000F3_A227SoporteTecnicoObservacion = new string[] {""} ;
         T000F3_n227SoporteTecnicoObservacion = new bool[] {false} ;
         T000F3_A14TicketId = new long[1] ;
         sMode16 = "";
         T000F10_A202SoporteTecnicoId = new long[1] ;
         T000F11_A202SoporteTecnicoId = new long[1] ;
         T000F2_A202SoporteTecnicoId = new long[1] ;
         T000F2_A203SoporteTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         T000F2_A204SoporteTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         T000F2_A211SoporteTecnicoFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         T000F2_n211SoporteTecnicoFechaResuelve = new bool[] {false} ;
         T000F2_A212SoporteTecnicoHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T000F2_n212SoporteTecnicoHoraResuelve = new bool[] {false} ;
         T000F2_A205SoporteTecnicoInventarioSerie = new string[] {""} ;
         T000F2_n205SoporteTecnicoInventarioSerie = new bool[] {false} ;
         T000F2_A206SoporteTecnicoInstalacion = new bool[] {false} ;
         T000F2_n206SoporteTecnicoInstalacion = new bool[] {false} ;
         T000F2_A207SoporteTecnicoConfiguracion = new bool[] {false} ;
         T000F2_n207SoporteTecnicoConfiguracion = new bool[] {false} ;
         T000F2_A208SoporteTecnicoInternetRouter = new bool[] {false} ;
         T000F2_n208SoporteTecnicoInternetRouter = new bool[] {false} ;
         T000F2_A209SoporteTecnicoFormateo = new bool[] {false} ;
         T000F2_n209SoporteTecnicoFormateo = new bool[] {false} ;
         T000F2_A210SoporteTecnicoReparacion = new bool[] {false} ;
         T000F2_n210SoporteTecnicoReparacion = new bool[] {false} ;
         T000F2_A213SoporteTecnicoLimpieza = new bool[] {false} ;
         T000F2_n213SoporteTecnicoLimpieza = new bool[] {false} ;
         T000F2_A214SoporteTecnicoPuntoRed = new bool[] {false} ;
         T000F2_n214SoporteTecnicoPuntoRed = new bool[] {false} ;
         T000F2_A215SoporteTecnicoCambiosHardware = new bool[] {false} ;
         T000F2_n215SoporteTecnicoCambiosHardware = new bool[] {false} ;
         T000F2_A216SoporteTecnicoCopiasRespaldo = new bool[] {false} ;
         T000F2_n216SoporteTecnicoCopiasRespaldo = new bool[] {false} ;
         T000F2_A217SoporteTecnicoRam = new string[] {""} ;
         T000F2_n217SoporteTecnicoRam = new bool[] {false} ;
         T000F2_A218SoporteTecnicoDiscoDuro = new string[] {""} ;
         T000F2_n218SoporteTecnicoDiscoDuro = new bool[] {false} ;
         T000F2_A219SoporteTecnicoProcesador = new string[] {""} ;
         T000F2_n219SoporteTecnicoProcesador = new bool[] {false} ;
         T000F2_A220SoporteTecnicoMaletin = new string[] {""} ;
         T000F2_n220SoporteTecnicoMaletin = new bool[] {false} ;
         T000F2_A221SoporteTecnicoTonerCinta = new string[] {""} ;
         T000F2_n221SoporteTecnicoTonerCinta = new bool[] {false} ;
         T000F2_A222SoporteTecnicoTarjetaVideoExtra = new string[] {""} ;
         T000F2_n222SoporteTecnicoTarjetaVideoExtra = new bool[] {false} ;
         T000F2_A223SoporteTecnicoCargadorLaptop = new string[] {""} ;
         T000F2_n223SoporteTecnicoCargadorLaptop = new bool[] {false} ;
         T000F2_A224SoporteTecnicoCDsDVDs = new string[] {""} ;
         T000F2_n224SoporteTecnicoCDsDVDs = new bool[] {false} ;
         T000F2_A225SoporteTecnicoCableEspecial = new string[] {""} ;
         T000F2_n225SoporteTecnicoCableEspecial = new bool[] {false} ;
         T000F2_A226SoporteTecnicoOtrosTaller = new string[] {""} ;
         T000F2_n226SoporteTecnicoOtrosTaller = new bool[] {false} ;
         T000F2_A235SoporteTecnicoCerrado = new bool[] {false} ;
         T000F2_A236SoporteTecnicoPendiente = new bool[] {false} ;
         T000F2_A237SoporteTecnicoPasaTaller = new bool[] {false} ;
         T000F2_A227SoporteTecnicoObservacion = new string[] {""} ;
         T000F2_n227SoporteTecnicoObservacion = new bool[] {false} ;
         T000F2_A14TicketId = new long[1] ;
         T000F12_A202SoporteTecnicoId = new long[1] ;
         T000F15_A15UsuarioId = new short[1] ;
         T000F16_A93UsuarioNombre = new string[] {""} ;
         T000F16_A94UsuarioRequerimiento = new string[] {""} ;
         T000F16_A91UsuarioGerencia = new string[] {""} ;
         T000F16_A88UsuarioDepartamento = new string[] {""} ;
         T000F17_A202SoporteTecnicoId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ203SoporteTecnicoFecha = DateTime.MinValue;
         ZZ204SoporteTecnicoHora = (DateTime)(DateTime.MinValue);
         ZZ211SoporteTecnicoFechaResuelve = DateTime.MinValue;
         ZZ212SoporteTecnicoHoraResuelve = (DateTime)(DateTime.MinValue);
         ZZ205SoporteTecnicoInventarioSerie = "";
         ZZ217SoporteTecnicoRam = "";
         ZZ218SoporteTecnicoDiscoDuro = "";
         ZZ219SoporteTecnicoProcesador = "";
         ZZ220SoporteTecnicoMaletin = "";
         ZZ221SoporteTecnicoTonerCinta = "";
         ZZ222SoporteTecnicoTarjetaVideoExtra = "";
         ZZ223SoporteTecnicoCargadorLaptop = "";
         ZZ224SoporteTecnicoCDsDVDs = "";
         ZZ225SoporteTecnicoCableEspecial = "";
         ZZ226SoporteTecnicoOtrosTaller = "";
         ZZ227SoporteTecnicoObservacion = "";
         ZZ93UsuarioNombre = "";
         ZZ94UsuarioRequerimiento = "";
         ZZ91UsuarioGerencia = "";
         ZZ88UsuarioDepartamento = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.soportetecnico__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.soportetecnico__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.soportetecnico__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.soportetecnico__default(),
            new Object[][] {
                new Object[] {
               T000F2_A202SoporteTecnicoId, T000F2_A203SoporteTecnicoFecha, T000F2_A204SoporteTecnicoHora, T000F2_A211SoporteTecnicoFechaResuelve, T000F2_n211SoporteTecnicoFechaResuelve, T000F2_A212SoporteTecnicoHoraResuelve, T000F2_n212SoporteTecnicoHoraResuelve, T000F2_A205SoporteTecnicoInventarioSerie, T000F2_n205SoporteTecnicoInventarioSerie, T000F2_A206SoporteTecnicoInstalacion,
               T000F2_n206SoporteTecnicoInstalacion, T000F2_A207SoporteTecnicoConfiguracion, T000F2_n207SoporteTecnicoConfiguracion, T000F2_A208SoporteTecnicoInternetRouter, T000F2_n208SoporteTecnicoInternetRouter, T000F2_A209SoporteTecnicoFormateo, T000F2_n209SoporteTecnicoFormateo, T000F2_A210SoporteTecnicoReparacion, T000F2_n210SoporteTecnicoReparacion, T000F2_A213SoporteTecnicoLimpieza,
               T000F2_n213SoporteTecnicoLimpieza, T000F2_A214SoporteTecnicoPuntoRed, T000F2_n214SoporteTecnicoPuntoRed, T000F2_A215SoporteTecnicoCambiosHardware, T000F2_n215SoporteTecnicoCambiosHardware, T000F2_A216SoporteTecnicoCopiasRespaldo, T000F2_n216SoporteTecnicoCopiasRespaldo, T000F2_A217SoporteTecnicoRam, T000F2_n217SoporteTecnicoRam, T000F2_A218SoporteTecnicoDiscoDuro,
               T000F2_n218SoporteTecnicoDiscoDuro, T000F2_A219SoporteTecnicoProcesador, T000F2_n219SoporteTecnicoProcesador, T000F2_A220SoporteTecnicoMaletin, T000F2_n220SoporteTecnicoMaletin, T000F2_A221SoporteTecnicoTonerCinta, T000F2_n221SoporteTecnicoTonerCinta, T000F2_A222SoporteTecnicoTarjetaVideoExtra, T000F2_n222SoporteTecnicoTarjetaVideoExtra, T000F2_A223SoporteTecnicoCargadorLaptop,
               T000F2_n223SoporteTecnicoCargadorLaptop, T000F2_A224SoporteTecnicoCDsDVDs, T000F2_n224SoporteTecnicoCDsDVDs, T000F2_A225SoporteTecnicoCableEspecial, T000F2_n225SoporteTecnicoCableEspecial, T000F2_A226SoporteTecnicoOtrosTaller, T000F2_n226SoporteTecnicoOtrosTaller, T000F2_A235SoporteTecnicoCerrado, T000F2_A236SoporteTecnicoPendiente, T000F2_A237SoporteTecnicoPasaTaller,
               T000F2_A227SoporteTecnicoObservacion, T000F2_n227SoporteTecnicoObservacion, T000F2_A14TicketId
               }
               , new Object[] {
               T000F3_A202SoporteTecnicoId, T000F3_A203SoporteTecnicoFecha, T000F3_A204SoporteTecnicoHora, T000F3_A211SoporteTecnicoFechaResuelve, T000F3_n211SoporteTecnicoFechaResuelve, T000F3_A212SoporteTecnicoHoraResuelve, T000F3_n212SoporteTecnicoHoraResuelve, T000F3_A205SoporteTecnicoInventarioSerie, T000F3_n205SoporteTecnicoInventarioSerie, T000F3_A206SoporteTecnicoInstalacion,
               T000F3_n206SoporteTecnicoInstalacion, T000F3_A207SoporteTecnicoConfiguracion, T000F3_n207SoporteTecnicoConfiguracion, T000F3_A208SoporteTecnicoInternetRouter, T000F3_n208SoporteTecnicoInternetRouter, T000F3_A209SoporteTecnicoFormateo, T000F3_n209SoporteTecnicoFormateo, T000F3_A210SoporteTecnicoReparacion, T000F3_n210SoporteTecnicoReparacion, T000F3_A213SoporteTecnicoLimpieza,
               T000F3_n213SoporteTecnicoLimpieza, T000F3_A214SoporteTecnicoPuntoRed, T000F3_n214SoporteTecnicoPuntoRed, T000F3_A215SoporteTecnicoCambiosHardware, T000F3_n215SoporteTecnicoCambiosHardware, T000F3_A216SoporteTecnicoCopiasRespaldo, T000F3_n216SoporteTecnicoCopiasRespaldo, T000F3_A217SoporteTecnicoRam, T000F3_n217SoporteTecnicoRam, T000F3_A218SoporteTecnicoDiscoDuro,
               T000F3_n218SoporteTecnicoDiscoDuro, T000F3_A219SoporteTecnicoProcesador, T000F3_n219SoporteTecnicoProcesador, T000F3_A220SoporteTecnicoMaletin, T000F3_n220SoporteTecnicoMaletin, T000F3_A221SoporteTecnicoTonerCinta, T000F3_n221SoporteTecnicoTonerCinta, T000F3_A222SoporteTecnicoTarjetaVideoExtra, T000F3_n222SoporteTecnicoTarjetaVideoExtra, T000F3_A223SoporteTecnicoCargadorLaptop,
               T000F3_n223SoporteTecnicoCargadorLaptop, T000F3_A224SoporteTecnicoCDsDVDs, T000F3_n224SoporteTecnicoCDsDVDs, T000F3_A225SoporteTecnicoCableEspecial, T000F3_n225SoporteTecnicoCableEspecial, T000F3_A226SoporteTecnicoOtrosTaller, T000F3_n226SoporteTecnicoOtrosTaller, T000F3_A235SoporteTecnicoCerrado, T000F3_A236SoporteTecnicoPendiente, T000F3_A237SoporteTecnicoPasaTaller,
               T000F3_A227SoporteTecnicoObservacion, T000F3_n227SoporteTecnicoObservacion, T000F3_A14TicketId
               }
               , new Object[] {
               T000F4_A15UsuarioId
               }
               , new Object[] {
               T000F5_A93UsuarioNombre, T000F5_A94UsuarioRequerimiento, T000F5_A91UsuarioGerencia, T000F5_A88UsuarioDepartamento
               }
               , new Object[] {
               T000F6_A202SoporteTecnicoId, T000F6_A203SoporteTecnicoFecha, T000F6_A204SoporteTecnicoHora, T000F6_A211SoporteTecnicoFechaResuelve, T000F6_n211SoporteTecnicoFechaResuelve, T000F6_A212SoporteTecnicoHoraResuelve, T000F6_n212SoporteTecnicoHoraResuelve, T000F6_A93UsuarioNombre, T000F6_A94UsuarioRequerimiento, T000F6_A91UsuarioGerencia,
               T000F6_A88UsuarioDepartamento, T000F6_A205SoporteTecnicoInventarioSerie, T000F6_n205SoporteTecnicoInventarioSerie, T000F6_A206SoporteTecnicoInstalacion, T000F6_n206SoporteTecnicoInstalacion, T000F6_A207SoporteTecnicoConfiguracion, T000F6_n207SoporteTecnicoConfiguracion, T000F6_A208SoporteTecnicoInternetRouter, T000F6_n208SoporteTecnicoInternetRouter, T000F6_A209SoporteTecnicoFormateo,
               T000F6_n209SoporteTecnicoFormateo, T000F6_A210SoporteTecnicoReparacion, T000F6_n210SoporteTecnicoReparacion, T000F6_A213SoporteTecnicoLimpieza, T000F6_n213SoporteTecnicoLimpieza, T000F6_A214SoporteTecnicoPuntoRed, T000F6_n214SoporteTecnicoPuntoRed, T000F6_A215SoporteTecnicoCambiosHardware, T000F6_n215SoporteTecnicoCambiosHardware, T000F6_A216SoporteTecnicoCopiasRespaldo,
               T000F6_n216SoporteTecnicoCopiasRespaldo, T000F6_A217SoporteTecnicoRam, T000F6_n217SoporteTecnicoRam, T000F6_A218SoporteTecnicoDiscoDuro, T000F6_n218SoporteTecnicoDiscoDuro, T000F6_A219SoporteTecnicoProcesador, T000F6_n219SoporteTecnicoProcesador, T000F6_A220SoporteTecnicoMaletin, T000F6_n220SoporteTecnicoMaletin, T000F6_A221SoporteTecnicoTonerCinta,
               T000F6_n221SoporteTecnicoTonerCinta, T000F6_A222SoporteTecnicoTarjetaVideoExtra, T000F6_n222SoporteTecnicoTarjetaVideoExtra, T000F6_A223SoporteTecnicoCargadorLaptop, T000F6_n223SoporteTecnicoCargadorLaptop, T000F6_A224SoporteTecnicoCDsDVDs, T000F6_n224SoporteTecnicoCDsDVDs, T000F6_A225SoporteTecnicoCableEspecial, T000F6_n225SoporteTecnicoCableEspecial, T000F6_A226SoporteTecnicoOtrosTaller,
               T000F6_n226SoporteTecnicoOtrosTaller, T000F6_A235SoporteTecnicoCerrado, T000F6_A236SoporteTecnicoPendiente, T000F6_A237SoporteTecnicoPasaTaller, T000F6_A227SoporteTecnicoObservacion, T000F6_n227SoporteTecnicoObservacion, T000F6_A14TicketId, T000F6_A15UsuarioId
               }
               , new Object[] {
               T000F7_A15UsuarioId
               }
               , new Object[] {
               T000F8_A93UsuarioNombre, T000F8_A94UsuarioRequerimiento, T000F8_A91UsuarioGerencia, T000F8_A88UsuarioDepartamento
               }
               , new Object[] {
               T000F9_A202SoporteTecnicoId
               }
               , new Object[] {
               T000F10_A202SoporteTecnicoId
               }
               , new Object[] {
               T000F11_A202SoporteTecnicoId
               }
               , new Object[] {
               T000F12_A202SoporteTecnicoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F15_A15UsuarioId
               }
               , new Object[] {
               T000F16_A93UsuarioNombre, T000F16_A94UsuarioRequerimiento, T000F16_A91UsuarioGerencia, T000F16_A88UsuarioDepartamento
               }
               , new Object[] {
               T000F17_A202SoporteTecnicoId
               }
            }
         );
      }

      private short GxWebError ;
      private short A15UsuarioId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short Z15UsuarioId ;
      private short RcdFound16 ;
      private short nIsDirty_16 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ15UsuarioId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSoporteTecnicoId_Enabled ;
      private int edtSoporteTecnicoFecha_Enabled ;
      private int edtSoporteTecnicoHora_Enabled ;
      private int edtSoporteTecnicoFechaResuelve_Enabled ;
      private int edtSoporteTecnicoHoraResuelve_Enabled ;
      private int edtTicketId_Enabled ;
      private int imgprompt_14_Visible ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioRequerimiento_Enabled ;
      private int edtUsuarioGerencia_Enabled ;
      private int edtUsuarioDepartamento_Enabled ;
      private int edtSoporteTecnicoInventarioSerie_Enabled ;
      private int edtSoporteTecnicoRam_Enabled ;
      private int edtSoporteTecnicoDiscoDuro_Enabled ;
      private int edtSoporteTecnicoProcesador_Enabled ;
      private int edtSoporteTecnicoMaletin_Enabled ;
      private int edtSoporteTecnicoTonerCinta_Enabled ;
      private int edtSoporteTecnicoTarjetaVideoExtra_Enabled ;
      private int edtSoporteTecnicoCargadorLaptop_Enabled ;
      private int edtSoporteTecnicoCDsDVDs_Enabled ;
      private int edtSoporteTecnicoCableEspecial_Enabled ;
      private int edtSoporteTecnicoOtrosTaller_Enabled ;
      private int edtSoporteTecnicoObservacion_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z202SoporteTecnicoId ;
      private long Z14TicketId ;
      private long A14TicketId ;
      private long A202SoporteTecnicoId ;
      private long ZZ202SoporteTecnicoId ;
      private long ZZ14TicketId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSoporteTecnicoId_Internalname ;
      private string divTablemain_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtSoporteTecnicoId_Jsonclick ;
      private string edtSoporteTecnicoFecha_Internalname ;
      private string edtSoporteTecnicoFecha_Jsonclick ;
      private string edtSoporteTecnicoHora_Internalname ;
      private string edtSoporteTecnicoHora_Jsonclick ;
      private string edtSoporteTecnicoFechaResuelve_Internalname ;
      private string edtSoporteTecnicoFechaResuelve_Jsonclick ;
      private string edtSoporteTecnicoHoraResuelve_Internalname ;
      private string edtSoporteTecnicoHoraResuelve_Jsonclick ;
      private string edtTicketId_Internalname ;
      private string edtTicketId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioId_Jsonclick ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string edtUsuarioGerencia_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string edtSoporteTecnicoInventarioSerie_Internalname ;
      private string chkSoporteTecnicoInstalacion_Internalname ;
      private string chkSoporteTecnicoConfiguracion_Internalname ;
      private string chkSoporteTecnicoInternetRouter_Internalname ;
      private string chkSoporteTecnicoFormateo_Internalname ;
      private string chkSoporteTecnicoReparacion_Internalname ;
      private string chkSoporteTecnicoLimpieza_Internalname ;
      private string chkSoporteTecnicoPuntoRed_Internalname ;
      private string chkSoporteTecnicoCambiosHardware_Internalname ;
      private string chkSoporteTecnicoCopiasRespaldo_Internalname ;
      private string edtSoporteTecnicoRam_Internalname ;
      private string edtSoporteTecnicoRam_Jsonclick ;
      private string edtSoporteTecnicoDiscoDuro_Internalname ;
      private string edtSoporteTecnicoDiscoDuro_Jsonclick ;
      private string edtSoporteTecnicoProcesador_Internalname ;
      private string edtSoporteTecnicoProcesador_Jsonclick ;
      private string edtSoporteTecnicoMaletin_Internalname ;
      private string edtSoporteTecnicoMaletin_Jsonclick ;
      private string edtSoporteTecnicoTonerCinta_Internalname ;
      private string edtSoporteTecnicoTonerCinta_Jsonclick ;
      private string edtSoporteTecnicoTarjetaVideoExtra_Internalname ;
      private string edtSoporteTecnicoTarjetaVideoExtra_Jsonclick ;
      private string edtSoporteTecnicoCargadorLaptop_Internalname ;
      private string edtSoporteTecnicoCargadorLaptop_Jsonclick ;
      private string edtSoporteTecnicoCDsDVDs_Internalname ;
      private string edtSoporteTecnicoCDsDVDs_Jsonclick ;
      private string edtSoporteTecnicoCableEspecial_Internalname ;
      private string edtSoporteTecnicoCableEspecial_Jsonclick ;
      private string edtSoporteTecnicoOtrosTaller_Internalname ;
      private string edtSoporteTecnicoOtrosTaller_Jsonclick ;
      private string chkSoporteTecnicoCerrado_Internalname ;
      private string chkSoporteTecnicoPendiente_Internalname ;
      private string chkSoporteTecnicoPasaTaller_Internalname ;
      private string edtSoporteTecnicoObservacion_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode16 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z204SoporteTecnicoHora ;
      private DateTime Z212SoporteTecnicoHoraResuelve ;
      private DateTime A204SoporteTecnicoHora ;
      private DateTime A212SoporteTecnicoHoraResuelve ;
      private DateTime ZZ204SoporteTecnicoHora ;
      private DateTime ZZ212SoporteTecnicoHoraResuelve ;
      private DateTime Z203SoporteTecnicoFecha ;
      private DateTime Z211SoporteTecnicoFechaResuelve ;
      private DateTime A203SoporteTecnicoFecha ;
      private DateTime A211SoporteTecnicoFechaResuelve ;
      private DateTime ZZ203SoporteTecnicoFecha ;
      private DateTime ZZ211SoporteTecnicoFechaResuelve ;
      private bool Z206SoporteTecnicoInstalacion ;
      private bool Z207SoporteTecnicoConfiguracion ;
      private bool Z208SoporteTecnicoInternetRouter ;
      private bool Z209SoporteTecnicoFormateo ;
      private bool Z210SoporteTecnicoReparacion ;
      private bool Z213SoporteTecnicoLimpieza ;
      private bool Z214SoporteTecnicoPuntoRed ;
      private bool Z215SoporteTecnicoCambiosHardware ;
      private bool Z216SoporteTecnicoCopiasRespaldo ;
      private bool Z235SoporteTecnicoCerrado ;
      private bool Z236SoporteTecnicoPendiente ;
      private bool Z237SoporteTecnicoPasaTaller ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A206SoporteTecnicoInstalacion ;
      private bool n206SoporteTecnicoInstalacion ;
      private bool A207SoporteTecnicoConfiguracion ;
      private bool n207SoporteTecnicoConfiguracion ;
      private bool A208SoporteTecnicoInternetRouter ;
      private bool n208SoporteTecnicoInternetRouter ;
      private bool A209SoporteTecnicoFormateo ;
      private bool n209SoporteTecnicoFormateo ;
      private bool A210SoporteTecnicoReparacion ;
      private bool n210SoporteTecnicoReparacion ;
      private bool A213SoporteTecnicoLimpieza ;
      private bool n213SoporteTecnicoLimpieza ;
      private bool A214SoporteTecnicoPuntoRed ;
      private bool n214SoporteTecnicoPuntoRed ;
      private bool A215SoporteTecnicoCambiosHardware ;
      private bool n215SoporteTecnicoCambiosHardware ;
      private bool A216SoporteTecnicoCopiasRespaldo ;
      private bool n216SoporteTecnicoCopiasRespaldo ;
      private bool A235SoporteTecnicoCerrado ;
      private bool A236SoporteTecnicoPendiente ;
      private bool A237SoporteTecnicoPasaTaller ;
      private bool n211SoporteTecnicoFechaResuelve ;
      private bool n212SoporteTecnicoHoraResuelve ;
      private bool n205SoporteTecnicoInventarioSerie ;
      private bool n217SoporteTecnicoRam ;
      private bool n218SoporteTecnicoDiscoDuro ;
      private bool n219SoporteTecnicoProcesador ;
      private bool n220SoporteTecnicoMaletin ;
      private bool n221SoporteTecnicoTonerCinta ;
      private bool n222SoporteTecnicoTarjetaVideoExtra ;
      private bool n223SoporteTecnicoCargadorLaptop ;
      private bool n224SoporteTecnicoCDsDVDs ;
      private bool n225SoporteTecnicoCableEspecial ;
      private bool n226SoporteTecnicoOtrosTaller ;
      private bool n227SoporteTecnicoObservacion ;
      private bool Gx_longc ;
      private bool ZZ206SoporteTecnicoInstalacion ;
      private bool ZZ207SoporteTecnicoConfiguracion ;
      private bool ZZ208SoporteTecnicoInternetRouter ;
      private bool ZZ209SoporteTecnicoFormateo ;
      private bool ZZ210SoporteTecnicoReparacion ;
      private bool ZZ213SoporteTecnicoLimpieza ;
      private bool ZZ214SoporteTecnicoPuntoRed ;
      private bool ZZ215SoporteTecnicoCambiosHardware ;
      private bool ZZ216SoporteTecnicoCopiasRespaldo ;
      private bool ZZ235SoporteTecnicoCerrado ;
      private bool ZZ236SoporteTecnicoPendiente ;
      private bool ZZ237SoporteTecnicoPasaTaller ;
      private string Z205SoporteTecnicoInventarioSerie ;
      private string Z217SoporteTecnicoRam ;
      private string Z218SoporteTecnicoDiscoDuro ;
      private string Z219SoporteTecnicoProcesador ;
      private string Z220SoporteTecnicoMaletin ;
      private string Z221SoporteTecnicoTonerCinta ;
      private string Z222SoporteTecnicoTarjetaVideoExtra ;
      private string Z223SoporteTecnicoCargadorLaptop ;
      private string Z224SoporteTecnicoCDsDVDs ;
      private string Z225SoporteTecnicoCableEspecial ;
      private string Z226SoporteTecnicoOtrosTaller ;
      private string Z227SoporteTecnicoObservacion ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A205SoporteTecnicoInventarioSerie ;
      private string A217SoporteTecnicoRam ;
      private string A218SoporteTecnicoDiscoDuro ;
      private string A219SoporteTecnicoProcesador ;
      private string A220SoporteTecnicoMaletin ;
      private string A221SoporteTecnicoTonerCinta ;
      private string A222SoporteTecnicoTarjetaVideoExtra ;
      private string A223SoporteTecnicoCargadorLaptop ;
      private string A224SoporteTecnicoCDsDVDs ;
      private string A225SoporteTecnicoCableEspecial ;
      private string A226SoporteTecnicoOtrosTaller ;
      private string A227SoporteTecnicoObservacion ;
      private string Z93UsuarioNombre ;
      private string Z94UsuarioRequerimiento ;
      private string Z91UsuarioGerencia ;
      private string Z88UsuarioDepartamento ;
      private string ZZ205SoporteTecnicoInventarioSerie ;
      private string ZZ217SoporteTecnicoRam ;
      private string ZZ218SoporteTecnicoDiscoDuro ;
      private string ZZ219SoporteTecnicoProcesador ;
      private string ZZ220SoporteTecnicoMaletin ;
      private string ZZ221SoporteTecnicoTonerCinta ;
      private string ZZ222SoporteTecnicoTarjetaVideoExtra ;
      private string ZZ223SoporteTecnicoCargadorLaptop ;
      private string ZZ224SoporteTecnicoCDsDVDs ;
      private string ZZ225SoporteTecnicoCableEspecial ;
      private string ZZ226SoporteTecnicoOtrosTaller ;
      private string ZZ227SoporteTecnicoObservacion ;
      private string ZZ93UsuarioNombre ;
      private string ZZ94UsuarioRequerimiento ;
      private string ZZ91UsuarioGerencia ;
      private string ZZ88UsuarioDepartamento ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkSoporteTecnicoInstalacion ;
      private GXCheckbox chkSoporteTecnicoConfiguracion ;
      private GXCheckbox chkSoporteTecnicoInternetRouter ;
      private GXCheckbox chkSoporteTecnicoFormateo ;
      private GXCheckbox chkSoporteTecnicoReparacion ;
      private GXCheckbox chkSoporteTecnicoLimpieza ;
      private GXCheckbox chkSoporteTecnicoPuntoRed ;
      private GXCheckbox chkSoporteTecnicoCambiosHardware ;
      private GXCheckbox chkSoporteTecnicoCopiasRespaldo ;
      private GXCheckbox chkSoporteTecnicoCerrado ;
      private GXCheckbox chkSoporteTecnicoPendiente ;
      private GXCheckbox chkSoporteTecnicoPasaTaller ;
      private IDataStoreProvider pr_default ;
      private long[] T000F6_A202SoporteTecnicoId ;
      private DateTime[] T000F6_A203SoporteTecnicoFecha ;
      private DateTime[] T000F6_A204SoporteTecnicoHora ;
      private DateTime[] T000F6_A211SoporteTecnicoFechaResuelve ;
      private bool[] T000F6_n211SoporteTecnicoFechaResuelve ;
      private DateTime[] T000F6_A212SoporteTecnicoHoraResuelve ;
      private bool[] T000F6_n212SoporteTecnicoHoraResuelve ;
      private string[] T000F6_A93UsuarioNombre ;
      private string[] T000F6_A94UsuarioRequerimiento ;
      private string[] T000F6_A91UsuarioGerencia ;
      private string[] T000F6_A88UsuarioDepartamento ;
      private string[] T000F6_A205SoporteTecnicoInventarioSerie ;
      private bool[] T000F6_n205SoporteTecnicoInventarioSerie ;
      private bool[] T000F6_A206SoporteTecnicoInstalacion ;
      private bool[] T000F6_n206SoporteTecnicoInstalacion ;
      private bool[] T000F6_A207SoporteTecnicoConfiguracion ;
      private bool[] T000F6_n207SoporteTecnicoConfiguracion ;
      private bool[] T000F6_A208SoporteTecnicoInternetRouter ;
      private bool[] T000F6_n208SoporteTecnicoInternetRouter ;
      private bool[] T000F6_A209SoporteTecnicoFormateo ;
      private bool[] T000F6_n209SoporteTecnicoFormateo ;
      private bool[] T000F6_A210SoporteTecnicoReparacion ;
      private bool[] T000F6_n210SoporteTecnicoReparacion ;
      private bool[] T000F6_A213SoporteTecnicoLimpieza ;
      private bool[] T000F6_n213SoporteTecnicoLimpieza ;
      private bool[] T000F6_A214SoporteTecnicoPuntoRed ;
      private bool[] T000F6_n214SoporteTecnicoPuntoRed ;
      private bool[] T000F6_A215SoporteTecnicoCambiosHardware ;
      private bool[] T000F6_n215SoporteTecnicoCambiosHardware ;
      private bool[] T000F6_A216SoporteTecnicoCopiasRespaldo ;
      private bool[] T000F6_n216SoporteTecnicoCopiasRespaldo ;
      private string[] T000F6_A217SoporteTecnicoRam ;
      private bool[] T000F6_n217SoporteTecnicoRam ;
      private string[] T000F6_A218SoporteTecnicoDiscoDuro ;
      private bool[] T000F6_n218SoporteTecnicoDiscoDuro ;
      private string[] T000F6_A219SoporteTecnicoProcesador ;
      private bool[] T000F6_n219SoporteTecnicoProcesador ;
      private string[] T000F6_A220SoporteTecnicoMaletin ;
      private bool[] T000F6_n220SoporteTecnicoMaletin ;
      private string[] T000F6_A221SoporteTecnicoTonerCinta ;
      private bool[] T000F6_n221SoporteTecnicoTonerCinta ;
      private string[] T000F6_A222SoporteTecnicoTarjetaVideoExtra ;
      private bool[] T000F6_n222SoporteTecnicoTarjetaVideoExtra ;
      private string[] T000F6_A223SoporteTecnicoCargadorLaptop ;
      private bool[] T000F6_n223SoporteTecnicoCargadorLaptop ;
      private string[] T000F6_A224SoporteTecnicoCDsDVDs ;
      private bool[] T000F6_n224SoporteTecnicoCDsDVDs ;
      private string[] T000F6_A225SoporteTecnicoCableEspecial ;
      private bool[] T000F6_n225SoporteTecnicoCableEspecial ;
      private string[] T000F6_A226SoporteTecnicoOtrosTaller ;
      private bool[] T000F6_n226SoporteTecnicoOtrosTaller ;
      private bool[] T000F6_A235SoporteTecnicoCerrado ;
      private bool[] T000F6_A236SoporteTecnicoPendiente ;
      private bool[] T000F6_A237SoporteTecnicoPasaTaller ;
      private string[] T000F6_A227SoporteTecnicoObservacion ;
      private bool[] T000F6_n227SoporteTecnicoObservacion ;
      private long[] T000F6_A14TicketId ;
      private short[] T000F6_A15UsuarioId ;
      private short[] T000F4_A15UsuarioId ;
      private string[] T000F5_A93UsuarioNombre ;
      private string[] T000F5_A94UsuarioRequerimiento ;
      private string[] T000F5_A91UsuarioGerencia ;
      private string[] T000F5_A88UsuarioDepartamento ;
      private short[] T000F7_A15UsuarioId ;
      private string[] T000F8_A93UsuarioNombre ;
      private string[] T000F8_A94UsuarioRequerimiento ;
      private string[] T000F8_A91UsuarioGerencia ;
      private string[] T000F8_A88UsuarioDepartamento ;
      private long[] T000F9_A202SoporteTecnicoId ;
      private long[] T000F3_A202SoporteTecnicoId ;
      private DateTime[] T000F3_A203SoporteTecnicoFecha ;
      private DateTime[] T000F3_A204SoporteTecnicoHora ;
      private DateTime[] T000F3_A211SoporteTecnicoFechaResuelve ;
      private bool[] T000F3_n211SoporteTecnicoFechaResuelve ;
      private DateTime[] T000F3_A212SoporteTecnicoHoraResuelve ;
      private bool[] T000F3_n212SoporteTecnicoHoraResuelve ;
      private string[] T000F3_A205SoporteTecnicoInventarioSerie ;
      private bool[] T000F3_n205SoporteTecnicoInventarioSerie ;
      private bool[] T000F3_A206SoporteTecnicoInstalacion ;
      private bool[] T000F3_n206SoporteTecnicoInstalacion ;
      private bool[] T000F3_A207SoporteTecnicoConfiguracion ;
      private bool[] T000F3_n207SoporteTecnicoConfiguracion ;
      private bool[] T000F3_A208SoporteTecnicoInternetRouter ;
      private bool[] T000F3_n208SoporteTecnicoInternetRouter ;
      private bool[] T000F3_A209SoporteTecnicoFormateo ;
      private bool[] T000F3_n209SoporteTecnicoFormateo ;
      private bool[] T000F3_A210SoporteTecnicoReparacion ;
      private bool[] T000F3_n210SoporteTecnicoReparacion ;
      private bool[] T000F3_A213SoporteTecnicoLimpieza ;
      private bool[] T000F3_n213SoporteTecnicoLimpieza ;
      private bool[] T000F3_A214SoporteTecnicoPuntoRed ;
      private bool[] T000F3_n214SoporteTecnicoPuntoRed ;
      private bool[] T000F3_A215SoporteTecnicoCambiosHardware ;
      private bool[] T000F3_n215SoporteTecnicoCambiosHardware ;
      private bool[] T000F3_A216SoporteTecnicoCopiasRespaldo ;
      private bool[] T000F3_n216SoporteTecnicoCopiasRespaldo ;
      private string[] T000F3_A217SoporteTecnicoRam ;
      private bool[] T000F3_n217SoporteTecnicoRam ;
      private string[] T000F3_A218SoporteTecnicoDiscoDuro ;
      private bool[] T000F3_n218SoporteTecnicoDiscoDuro ;
      private string[] T000F3_A219SoporteTecnicoProcesador ;
      private bool[] T000F3_n219SoporteTecnicoProcesador ;
      private string[] T000F3_A220SoporteTecnicoMaletin ;
      private bool[] T000F3_n220SoporteTecnicoMaletin ;
      private string[] T000F3_A221SoporteTecnicoTonerCinta ;
      private bool[] T000F3_n221SoporteTecnicoTonerCinta ;
      private string[] T000F3_A222SoporteTecnicoTarjetaVideoExtra ;
      private bool[] T000F3_n222SoporteTecnicoTarjetaVideoExtra ;
      private string[] T000F3_A223SoporteTecnicoCargadorLaptop ;
      private bool[] T000F3_n223SoporteTecnicoCargadorLaptop ;
      private string[] T000F3_A224SoporteTecnicoCDsDVDs ;
      private bool[] T000F3_n224SoporteTecnicoCDsDVDs ;
      private string[] T000F3_A225SoporteTecnicoCableEspecial ;
      private bool[] T000F3_n225SoporteTecnicoCableEspecial ;
      private string[] T000F3_A226SoporteTecnicoOtrosTaller ;
      private bool[] T000F3_n226SoporteTecnicoOtrosTaller ;
      private bool[] T000F3_A235SoporteTecnicoCerrado ;
      private bool[] T000F3_A236SoporteTecnicoPendiente ;
      private bool[] T000F3_A237SoporteTecnicoPasaTaller ;
      private string[] T000F3_A227SoporteTecnicoObservacion ;
      private bool[] T000F3_n227SoporteTecnicoObservacion ;
      private long[] T000F3_A14TicketId ;
      private long[] T000F10_A202SoporteTecnicoId ;
      private long[] T000F11_A202SoporteTecnicoId ;
      private long[] T000F2_A202SoporteTecnicoId ;
      private DateTime[] T000F2_A203SoporteTecnicoFecha ;
      private DateTime[] T000F2_A204SoporteTecnicoHora ;
      private DateTime[] T000F2_A211SoporteTecnicoFechaResuelve ;
      private bool[] T000F2_n211SoporteTecnicoFechaResuelve ;
      private DateTime[] T000F2_A212SoporteTecnicoHoraResuelve ;
      private bool[] T000F2_n212SoporteTecnicoHoraResuelve ;
      private string[] T000F2_A205SoporteTecnicoInventarioSerie ;
      private bool[] T000F2_n205SoporteTecnicoInventarioSerie ;
      private bool[] T000F2_A206SoporteTecnicoInstalacion ;
      private bool[] T000F2_n206SoporteTecnicoInstalacion ;
      private bool[] T000F2_A207SoporteTecnicoConfiguracion ;
      private bool[] T000F2_n207SoporteTecnicoConfiguracion ;
      private bool[] T000F2_A208SoporteTecnicoInternetRouter ;
      private bool[] T000F2_n208SoporteTecnicoInternetRouter ;
      private bool[] T000F2_A209SoporteTecnicoFormateo ;
      private bool[] T000F2_n209SoporteTecnicoFormateo ;
      private bool[] T000F2_A210SoporteTecnicoReparacion ;
      private bool[] T000F2_n210SoporteTecnicoReparacion ;
      private bool[] T000F2_A213SoporteTecnicoLimpieza ;
      private bool[] T000F2_n213SoporteTecnicoLimpieza ;
      private bool[] T000F2_A214SoporteTecnicoPuntoRed ;
      private bool[] T000F2_n214SoporteTecnicoPuntoRed ;
      private bool[] T000F2_A215SoporteTecnicoCambiosHardware ;
      private bool[] T000F2_n215SoporteTecnicoCambiosHardware ;
      private bool[] T000F2_A216SoporteTecnicoCopiasRespaldo ;
      private bool[] T000F2_n216SoporteTecnicoCopiasRespaldo ;
      private string[] T000F2_A217SoporteTecnicoRam ;
      private bool[] T000F2_n217SoporteTecnicoRam ;
      private string[] T000F2_A218SoporteTecnicoDiscoDuro ;
      private bool[] T000F2_n218SoporteTecnicoDiscoDuro ;
      private string[] T000F2_A219SoporteTecnicoProcesador ;
      private bool[] T000F2_n219SoporteTecnicoProcesador ;
      private string[] T000F2_A220SoporteTecnicoMaletin ;
      private bool[] T000F2_n220SoporteTecnicoMaletin ;
      private string[] T000F2_A221SoporteTecnicoTonerCinta ;
      private bool[] T000F2_n221SoporteTecnicoTonerCinta ;
      private string[] T000F2_A222SoporteTecnicoTarjetaVideoExtra ;
      private bool[] T000F2_n222SoporteTecnicoTarjetaVideoExtra ;
      private string[] T000F2_A223SoporteTecnicoCargadorLaptop ;
      private bool[] T000F2_n223SoporteTecnicoCargadorLaptop ;
      private string[] T000F2_A224SoporteTecnicoCDsDVDs ;
      private bool[] T000F2_n224SoporteTecnicoCDsDVDs ;
      private string[] T000F2_A225SoporteTecnicoCableEspecial ;
      private bool[] T000F2_n225SoporteTecnicoCableEspecial ;
      private string[] T000F2_A226SoporteTecnicoOtrosTaller ;
      private bool[] T000F2_n226SoporteTecnicoOtrosTaller ;
      private bool[] T000F2_A235SoporteTecnicoCerrado ;
      private bool[] T000F2_A236SoporteTecnicoPendiente ;
      private bool[] T000F2_A237SoporteTecnicoPasaTaller ;
      private string[] T000F2_A227SoporteTecnicoObservacion ;
      private bool[] T000F2_n227SoporteTecnicoObservacion ;
      private long[] T000F2_A14TicketId ;
      private long[] T000F12_A202SoporteTecnicoId ;
      private short[] T000F15_A15UsuarioId ;
      private string[] T000F16_A93UsuarioNombre ;
      private string[] T000F16_A94UsuarioRequerimiento ;
      private string[] T000F16_A91UsuarioGerencia ;
      private string[] T000F16_A88UsuarioDepartamento ;
      private long[] T000F17_A202SoporteTecnicoId ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class soportetecnico__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class soportetecnico__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class soportetecnico__gam : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       def= new CursorDef[] {
       };
    }
 }

 public void getResults( int cursor ,
                         IFieldGetter rslt ,
                         Object[] buf )
 {
 }

 public override string getDataStoreName( )
 {
    return "GAM";
 }

}

public class soportetecnico__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new UpdateCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000F6;
       prmT000F6 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F4;
       prmT000F4 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000F5;
       prmT000F5 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000F7;
       prmT000F7 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000F8;
       prmT000F8 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000F9;
       prmT000F9 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F3;
       prmT000F3 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F10;
       prmT000F10 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F11;
       prmT000F11 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F2;
       prmT000F2 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F12;
       prmT000F12 = new Object[] {
       new ParDef("@SoporteTecnicoFecha",GXType.Date,8,0) ,
       new ParDef("@SoporteTecnicoHora",GXType.DateTime,0,5) ,
       new ParDef("@SoporteTecnicoFechaResuelve",GXType.Date,8,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("@SoporteTecnicoInventarioSerie",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoInstalacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoConfiguracion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoInternetRouter",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoFormateo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoReparacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoLimpieza",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoPuntoRed",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCambiosHardware",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCopiasRespaldo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoRam",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoDiscoDuro",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoProcesador",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoMaletin",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoTonerCinta",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoTarjetaVideoExtra",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCargadorLaptop",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCDsDVDs",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCableEspecial",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoOtrosTaller",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCerrado",GXType.Boolean,4,0) ,
       new ParDef("@SoporteTecnicoPendiente",GXType.Boolean,4,0) ,
       new ParDef("@SoporteTecnicoPasaTaller",GXType.Boolean,4,0) ,
       new ParDef("@SoporteTecnicoObservacion",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000F13;
       prmT000F13 = new Object[] {
       new ParDef("@SoporteTecnicoFecha",GXType.Date,8,0) ,
       new ParDef("@SoporteTecnicoHora",GXType.DateTime,0,5) ,
       new ParDef("@SoporteTecnicoFechaResuelve",GXType.Date,8,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("@SoporteTecnicoInventarioSerie",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoInstalacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoConfiguracion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoInternetRouter",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoFormateo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoReparacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoLimpieza",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoPuntoRed",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCambiosHardware",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCopiasRespaldo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoRam",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoDiscoDuro",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoProcesador",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoMaletin",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoTonerCinta",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoTarjetaVideoExtra",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCargadorLaptop",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCDsDVDs",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCableEspecial",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoOtrosTaller",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@SoporteTecnicoCerrado",GXType.Boolean,4,0) ,
       new ParDef("@SoporteTecnicoPendiente",GXType.Boolean,4,0) ,
       new ParDef("@SoporteTecnicoPasaTaller",GXType.Boolean,4,0) ,
       new ParDef("@SoporteTecnicoObservacion",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F14;
       prmT000F14 = new Object[] {
       new ParDef("@SoporteTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000F17;
       prmT000F17 = new Object[] {
       };
       Object[] prmT000F15;
       prmT000F15 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000F16;
       prmT000F16 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000F2", "SELECT [SoporteTecnicoId], [SoporteTecnicoFecha], [SoporteTecnicoHora], [SoporteTecnicoFechaResuelve], [SoporteTecnicoHoraResuelve], [SoporteTecnicoInventarioSerie], [SoporteTecnicoInstalacion], [SoporteTecnicoConfiguracion], [SoporteTecnicoInternetRouter], [SoporteTecnicoFormateo], [SoporteTecnicoReparacion], [SoporteTecnicoLimpieza], [SoporteTecnicoPuntoRed], [SoporteTecnicoCambiosHardware], [SoporteTecnicoCopiasRespaldo], [SoporteTecnicoRam], [SoporteTecnicoDiscoDuro], [SoporteTecnicoProcesador], [SoporteTecnicoMaletin], [SoporteTecnicoTonerCinta], [SoporteTecnicoTarjetaVideoExtra], [SoporteTecnicoCargadorLaptop], [SoporteTecnicoCDsDVDs], [SoporteTecnicoCableEspecial], [SoporteTecnicoOtrosTaller], [SoporteTecnicoCerrado], [SoporteTecnicoPendiente], [SoporteTecnicoPasaTaller], [SoporteTecnicoObservacion], [TicketId] FROM [AtencionSoporteTecnico] WITH (UPDLOCK) WHERE [SoporteTecnicoId] = @SoporteTecnicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F3", "SELECT [SoporteTecnicoId], [SoporteTecnicoFecha], [SoporteTecnicoHora], [SoporteTecnicoFechaResuelve], [SoporteTecnicoHoraResuelve], [SoporteTecnicoInventarioSerie], [SoporteTecnicoInstalacion], [SoporteTecnicoConfiguracion], [SoporteTecnicoInternetRouter], [SoporteTecnicoFormateo], [SoporteTecnicoReparacion], [SoporteTecnicoLimpieza], [SoporteTecnicoPuntoRed], [SoporteTecnicoCambiosHardware], [SoporteTecnicoCopiasRespaldo], [SoporteTecnicoRam], [SoporteTecnicoDiscoDuro], [SoporteTecnicoProcesador], [SoporteTecnicoMaletin], [SoporteTecnicoTonerCinta], [SoporteTecnicoTarjetaVideoExtra], [SoporteTecnicoCargadorLaptop], [SoporteTecnicoCDsDVDs], [SoporteTecnicoCableEspecial], [SoporteTecnicoOtrosTaller], [SoporteTecnicoCerrado], [SoporteTecnicoPendiente], [SoporteTecnicoPasaTaller], [SoporteTecnicoObservacion], [TicketId] FROM [AtencionSoporteTecnico] WHERE [SoporteTecnicoId] = @SoporteTecnicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F4", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F5", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioGerencia], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F6", "SELECT TM1.[SoporteTecnicoId], TM1.[SoporteTecnicoFecha], TM1.[SoporteTecnicoHora], TM1.[SoporteTecnicoFechaResuelve], TM1.[SoporteTecnicoHoraResuelve], T3.[UsuarioNombre], T3.[UsuarioRequerimiento], T3.[UsuarioGerencia], T3.[UsuarioDepartamento], TM1.[SoporteTecnicoInventarioSerie], TM1.[SoporteTecnicoInstalacion], TM1.[SoporteTecnicoConfiguracion], TM1.[SoporteTecnicoInternetRouter], TM1.[SoporteTecnicoFormateo], TM1.[SoporteTecnicoReparacion], TM1.[SoporteTecnicoLimpieza], TM1.[SoporteTecnicoPuntoRed], TM1.[SoporteTecnicoCambiosHardware], TM1.[SoporteTecnicoCopiasRespaldo], TM1.[SoporteTecnicoRam], TM1.[SoporteTecnicoDiscoDuro], TM1.[SoporteTecnicoProcesador], TM1.[SoporteTecnicoMaletin], TM1.[SoporteTecnicoTonerCinta], TM1.[SoporteTecnicoTarjetaVideoExtra], TM1.[SoporteTecnicoCargadorLaptop], TM1.[SoporteTecnicoCDsDVDs], TM1.[SoporteTecnicoCableEspecial], TM1.[SoporteTecnicoOtrosTaller], TM1.[SoporteTecnicoCerrado], TM1.[SoporteTecnicoPendiente], TM1.[SoporteTecnicoPasaTaller], TM1.[SoporteTecnicoObservacion], TM1.[TicketId], T2.[UsuarioId] FROM (([AtencionSoporteTecnico] TM1 INNER JOIN [Ticket] T2 ON T2.[TicketId] = TM1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId]) WHERE TM1.[SoporteTecnicoId] = @SoporteTecnicoId ORDER BY TM1.[SoporteTecnicoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F7", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F8", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioGerencia], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F9", "SELECT [SoporteTecnicoId] FROM [AtencionSoporteTecnico] WHERE [SoporteTecnicoId] = @SoporteTecnicoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F10", "SELECT TOP 1 [SoporteTecnicoId] FROM [AtencionSoporteTecnico] WHERE ( [SoporteTecnicoId] > @SoporteTecnicoId) ORDER BY [SoporteTecnicoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000F11", "SELECT TOP 1 [SoporteTecnicoId] FROM [AtencionSoporteTecnico] WHERE ( [SoporteTecnicoId] < @SoporteTecnicoId) ORDER BY [SoporteTecnicoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000F12", "INSERT INTO [AtencionSoporteTecnico]([SoporteTecnicoFecha], [SoporteTecnicoHora], [SoporteTecnicoFechaResuelve], [SoporteTecnicoHoraResuelve], [SoporteTecnicoInventarioSerie], [SoporteTecnicoInstalacion], [SoporteTecnicoConfiguracion], [SoporteTecnicoInternetRouter], [SoporteTecnicoFormateo], [SoporteTecnicoReparacion], [SoporteTecnicoLimpieza], [SoporteTecnicoPuntoRed], [SoporteTecnicoCambiosHardware], [SoporteTecnicoCopiasRespaldo], [SoporteTecnicoRam], [SoporteTecnicoDiscoDuro], [SoporteTecnicoProcesador], [SoporteTecnicoMaletin], [SoporteTecnicoTonerCinta], [SoporteTecnicoTarjetaVideoExtra], [SoporteTecnicoCargadorLaptop], [SoporteTecnicoCDsDVDs], [SoporteTecnicoCableEspecial], [SoporteTecnicoOtrosTaller], [SoporteTecnicoCerrado], [SoporteTecnicoPendiente], [SoporteTecnicoPasaTaller], [SoporteTecnicoObservacion], [TicketId]) VALUES(@SoporteTecnicoFecha, @SoporteTecnicoHora, @SoporteTecnicoFechaResuelve, @SoporteTecnicoHoraResuelve, @SoporteTecnicoInventarioSerie, @SoporteTecnicoInstalacion, @SoporteTecnicoConfiguracion, @SoporteTecnicoInternetRouter, @SoporteTecnicoFormateo, @SoporteTecnicoReparacion, @SoporteTecnicoLimpieza, @SoporteTecnicoPuntoRed, @SoporteTecnicoCambiosHardware, @SoporteTecnicoCopiasRespaldo, @SoporteTecnicoRam, @SoporteTecnicoDiscoDuro, @SoporteTecnicoProcesador, @SoporteTecnicoMaletin, @SoporteTecnicoTonerCinta, @SoporteTecnicoTarjetaVideoExtra, @SoporteTecnicoCargadorLaptop, @SoporteTecnicoCDsDVDs, @SoporteTecnicoCableEspecial, @SoporteTecnicoOtrosTaller, @SoporteTecnicoCerrado, @SoporteTecnicoPendiente, @SoporteTecnicoPasaTaller, @SoporteTecnicoObservacion, @TicketId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000F12)
          ,new CursorDef("T000F13", "UPDATE [AtencionSoporteTecnico] SET [SoporteTecnicoFecha]=@SoporteTecnicoFecha, [SoporteTecnicoHora]=@SoporteTecnicoHora, [SoporteTecnicoFechaResuelve]=@SoporteTecnicoFechaResuelve, [SoporteTecnicoHoraResuelve]=@SoporteTecnicoHoraResuelve, [SoporteTecnicoInventarioSerie]=@SoporteTecnicoInventarioSerie, [SoporteTecnicoInstalacion]=@SoporteTecnicoInstalacion, [SoporteTecnicoConfiguracion]=@SoporteTecnicoConfiguracion, [SoporteTecnicoInternetRouter]=@SoporteTecnicoInternetRouter, [SoporteTecnicoFormateo]=@SoporteTecnicoFormateo, [SoporteTecnicoReparacion]=@SoporteTecnicoReparacion, [SoporteTecnicoLimpieza]=@SoporteTecnicoLimpieza, [SoporteTecnicoPuntoRed]=@SoporteTecnicoPuntoRed, [SoporteTecnicoCambiosHardware]=@SoporteTecnicoCambiosHardware, [SoporteTecnicoCopiasRespaldo]=@SoporteTecnicoCopiasRespaldo, [SoporteTecnicoRam]=@SoporteTecnicoRam, [SoporteTecnicoDiscoDuro]=@SoporteTecnicoDiscoDuro, [SoporteTecnicoProcesador]=@SoporteTecnicoProcesador, [SoporteTecnicoMaletin]=@SoporteTecnicoMaletin, [SoporteTecnicoTonerCinta]=@SoporteTecnicoTonerCinta, [SoporteTecnicoTarjetaVideoExtra]=@SoporteTecnicoTarjetaVideoExtra, [SoporteTecnicoCargadorLaptop]=@SoporteTecnicoCargadorLaptop, [SoporteTecnicoCDsDVDs]=@SoporteTecnicoCDsDVDs, [SoporteTecnicoCableEspecial]=@SoporteTecnicoCableEspecial, [SoporteTecnicoOtrosTaller]=@SoporteTecnicoOtrosTaller, [SoporteTecnicoCerrado]=@SoporteTecnicoCerrado, [SoporteTecnicoPendiente]=@SoporteTecnicoPendiente, [SoporteTecnicoPasaTaller]=@SoporteTecnicoPasaTaller, [SoporteTecnicoObservacion]=@SoporteTecnicoObservacion, [TicketId]=@TicketId  WHERE [SoporteTecnicoId] = @SoporteTecnicoId", GxErrorMask.GX_NOMASK,prmT000F13)
          ,new CursorDef("T000F14", "DELETE FROM [AtencionSoporteTecnico]  WHERE [SoporteTecnicoId] = @SoporteTecnicoId", GxErrorMask.GX_NOMASK,prmT000F14)
          ,new CursorDef("T000F15", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F15,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F16", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioGerencia], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F16,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000F17", "SELECT [SoporteTecnicoId] FROM [AtencionSoporteTecnico] ORDER BY [SoporteTecnicoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000F17,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getVarchar(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((bool[]) buf[9])[0] = rslt.getBool(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((bool[]) buf[11])[0] = rslt.getBool(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((bool[]) buf[13])[0] = rslt.getBool(9);
             ((bool[]) buf[14])[0] = rslt.wasNull(9);
             ((bool[]) buf[15])[0] = rslt.getBool(10);
             ((bool[]) buf[16])[0] = rslt.wasNull(10);
             ((bool[]) buf[17])[0] = rslt.getBool(11);
             ((bool[]) buf[18])[0] = rslt.wasNull(11);
             ((bool[]) buf[19])[0] = rslt.getBool(12);
             ((bool[]) buf[20])[0] = rslt.wasNull(12);
             ((bool[]) buf[21])[0] = rslt.getBool(13);
             ((bool[]) buf[22])[0] = rslt.wasNull(13);
             ((bool[]) buf[23])[0] = rslt.getBool(14);
             ((bool[]) buf[24])[0] = rslt.wasNull(14);
             ((bool[]) buf[25])[0] = rslt.getBool(15);
             ((bool[]) buf[26])[0] = rslt.wasNull(15);
             ((string[]) buf[27])[0] = rslt.getVarchar(16);
             ((bool[]) buf[28])[0] = rslt.wasNull(16);
             ((string[]) buf[29])[0] = rslt.getVarchar(17);
             ((bool[]) buf[30])[0] = rslt.wasNull(17);
             ((string[]) buf[31])[0] = rslt.getVarchar(18);
             ((bool[]) buf[32])[0] = rslt.wasNull(18);
             ((string[]) buf[33])[0] = rslt.getVarchar(19);
             ((bool[]) buf[34])[0] = rslt.wasNull(19);
             ((string[]) buf[35])[0] = rslt.getVarchar(20);
             ((bool[]) buf[36])[0] = rslt.wasNull(20);
             ((string[]) buf[37])[0] = rslt.getVarchar(21);
             ((bool[]) buf[38])[0] = rslt.wasNull(21);
             ((string[]) buf[39])[0] = rslt.getVarchar(22);
             ((bool[]) buf[40])[0] = rslt.wasNull(22);
             ((string[]) buf[41])[0] = rslt.getVarchar(23);
             ((bool[]) buf[42])[0] = rslt.wasNull(23);
             ((string[]) buf[43])[0] = rslt.getVarchar(24);
             ((bool[]) buf[44])[0] = rslt.wasNull(24);
             ((string[]) buf[45])[0] = rslt.getVarchar(25);
             ((bool[]) buf[46])[0] = rslt.wasNull(25);
             ((bool[]) buf[47])[0] = rslt.getBool(26);
             ((bool[]) buf[48])[0] = rslt.getBool(27);
             ((bool[]) buf[49])[0] = rslt.getBool(28);
             ((string[]) buf[50])[0] = rslt.getVarchar(29);
             ((bool[]) buf[51])[0] = rslt.wasNull(29);
             ((long[]) buf[52])[0] = rslt.getLong(30);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getVarchar(6);
             ((bool[]) buf[8])[0] = rslt.wasNull(6);
             ((bool[]) buf[9])[0] = rslt.getBool(7);
             ((bool[]) buf[10])[0] = rslt.wasNull(7);
             ((bool[]) buf[11])[0] = rslt.getBool(8);
             ((bool[]) buf[12])[0] = rslt.wasNull(8);
             ((bool[]) buf[13])[0] = rslt.getBool(9);
             ((bool[]) buf[14])[0] = rslt.wasNull(9);
             ((bool[]) buf[15])[0] = rslt.getBool(10);
             ((bool[]) buf[16])[0] = rslt.wasNull(10);
             ((bool[]) buf[17])[0] = rslt.getBool(11);
             ((bool[]) buf[18])[0] = rslt.wasNull(11);
             ((bool[]) buf[19])[0] = rslt.getBool(12);
             ((bool[]) buf[20])[0] = rslt.wasNull(12);
             ((bool[]) buf[21])[0] = rslt.getBool(13);
             ((bool[]) buf[22])[0] = rslt.wasNull(13);
             ((bool[]) buf[23])[0] = rslt.getBool(14);
             ((bool[]) buf[24])[0] = rslt.wasNull(14);
             ((bool[]) buf[25])[0] = rslt.getBool(15);
             ((bool[]) buf[26])[0] = rslt.wasNull(15);
             ((string[]) buf[27])[0] = rslt.getVarchar(16);
             ((bool[]) buf[28])[0] = rslt.wasNull(16);
             ((string[]) buf[29])[0] = rslt.getVarchar(17);
             ((bool[]) buf[30])[0] = rslt.wasNull(17);
             ((string[]) buf[31])[0] = rslt.getVarchar(18);
             ((bool[]) buf[32])[0] = rslt.wasNull(18);
             ((string[]) buf[33])[0] = rslt.getVarchar(19);
             ((bool[]) buf[34])[0] = rslt.wasNull(19);
             ((string[]) buf[35])[0] = rslt.getVarchar(20);
             ((bool[]) buf[36])[0] = rslt.wasNull(20);
             ((string[]) buf[37])[0] = rslt.getVarchar(21);
             ((bool[]) buf[38])[0] = rslt.wasNull(21);
             ((string[]) buf[39])[0] = rslt.getVarchar(22);
             ((bool[]) buf[40])[0] = rslt.wasNull(22);
             ((string[]) buf[41])[0] = rslt.getVarchar(23);
             ((bool[]) buf[42])[0] = rslt.wasNull(23);
             ((string[]) buf[43])[0] = rslt.getVarchar(24);
             ((bool[]) buf[44])[0] = rslt.wasNull(24);
             ((string[]) buf[45])[0] = rslt.getVarchar(25);
             ((bool[]) buf[46])[0] = rslt.wasNull(25);
             ((bool[]) buf[47])[0] = rslt.getBool(26);
             ((bool[]) buf[48])[0] = rslt.getBool(27);
             ((bool[]) buf[49])[0] = rslt.getBool(28);
             ((string[]) buf[50])[0] = rslt.getVarchar(29);
             ((bool[]) buf[51])[0] = rslt.wasNull(29);
             ((long[]) buf[52])[0] = rslt.getLong(30);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((string[]) buf[7])[0] = rslt.getVarchar(6);
             ((string[]) buf[8])[0] = rslt.getVarchar(7);
             ((string[]) buf[9])[0] = rslt.getVarchar(8);
             ((string[]) buf[10])[0] = rslt.getVarchar(9);
             ((string[]) buf[11])[0] = rslt.getVarchar(10);
             ((bool[]) buf[12])[0] = rslt.wasNull(10);
             ((bool[]) buf[13])[0] = rslt.getBool(11);
             ((bool[]) buf[14])[0] = rslt.wasNull(11);
             ((bool[]) buf[15])[0] = rslt.getBool(12);
             ((bool[]) buf[16])[0] = rslt.wasNull(12);
             ((bool[]) buf[17])[0] = rslt.getBool(13);
             ((bool[]) buf[18])[0] = rslt.wasNull(13);
             ((bool[]) buf[19])[0] = rslt.getBool(14);
             ((bool[]) buf[20])[0] = rslt.wasNull(14);
             ((bool[]) buf[21])[0] = rslt.getBool(15);
             ((bool[]) buf[22])[0] = rslt.wasNull(15);
             ((bool[]) buf[23])[0] = rslt.getBool(16);
             ((bool[]) buf[24])[0] = rslt.wasNull(16);
             ((bool[]) buf[25])[0] = rslt.getBool(17);
             ((bool[]) buf[26])[0] = rslt.wasNull(17);
             ((bool[]) buf[27])[0] = rslt.getBool(18);
             ((bool[]) buf[28])[0] = rslt.wasNull(18);
             ((bool[]) buf[29])[0] = rslt.getBool(19);
             ((bool[]) buf[30])[0] = rslt.wasNull(19);
             ((string[]) buf[31])[0] = rslt.getVarchar(20);
             ((bool[]) buf[32])[0] = rslt.wasNull(20);
             ((string[]) buf[33])[0] = rslt.getVarchar(21);
             ((bool[]) buf[34])[0] = rslt.wasNull(21);
             ((string[]) buf[35])[0] = rslt.getVarchar(22);
             ((bool[]) buf[36])[0] = rslt.wasNull(22);
             ((string[]) buf[37])[0] = rslt.getVarchar(23);
             ((bool[]) buf[38])[0] = rslt.wasNull(23);
             ((string[]) buf[39])[0] = rslt.getVarchar(24);
             ((bool[]) buf[40])[0] = rslt.wasNull(24);
             ((string[]) buf[41])[0] = rslt.getVarchar(25);
             ((bool[]) buf[42])[0] = rslt.wasNull(25);
             ((string[]) buf[43])[0] = rslt.getVarchar(26);
             ((bool[]) buf[44])[0] = rslt.wasNull(26);
             ((string[]) buf[45])[0] = rslt.getVarchar(27);
             ((bool[]) buf[46])[0] = rslt.wasNull(27);
             ((string[]) buf[47])[0] = rslt.getVarchar(28);
             ((bool[]) buf[48])[0] = rslt.wasNull(28);
             ((string[]) buf[49])[0] = rslt.getVarchar(29);
             ((bool[]) buf[50])[0] = rslt.wasNull(29);
             ((bool[]) buf[51])[0] = rslt.getBool(30);
             ((bool[]) buf[52])[0] = rslt.getBool(31);
             ((bool[]) buf[53])[0] = rslt.getBool(32);
             ((string[]) buf[54])[0] = rslt.getVarchar(33);
             ((bool[]) buf[55])[0] = rslt.wasNull(33);
             ((long[]) buf[56])[0] = rslt.getLong(34);
             ((short[]) buf[57])[0] = rslt.getShort(35);
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 7 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 8 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 13 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 15 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
