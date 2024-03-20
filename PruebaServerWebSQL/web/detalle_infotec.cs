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
   public class detalle_infotec : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
            Form.Meta.addItem("description", "detalle_infotec", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtcorrelativo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public detalle_infotec( )
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

      public detalle_infotec( IGxContext context )
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
            return "detalle_infotec_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "detalle_infotec", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00h0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CORRELATIVO"+"'), id:'"+"CORRELATIVO"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtcorrelativo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcorrelativo_Internalname, "correlativo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ",", "")), ((edtcorrelativo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcorrelativo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtcorrelativo_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtnombre_emp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_emp_Internalname, "nombre_emp", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_emp_Internalname, A239nombre_emp, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", 0, 1, edtnombre_emp_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtcargo_emp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcargo_emp_Internalname, "cargo_emp", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcargo_emp_Internalname, A240cargo_emp, StringUtil.RTrim( context.localUtil.Format( A240cargo_emp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcargo_emp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtcargo_emp_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtfecha_registro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfecha_registro_Internalname, "fecha_registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtfecha_registro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtfecha_registro_Internalname, context.localUtil.Format(A241fecha_registro, "99/99/99"), context.localUtil.Format( A241fecha_registro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtfecha_registro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtfecha_registro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_bitmap( context, edtfecha_registro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtfecha_registro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edthora_registro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edthora_registro_Internalname, "hora_registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edthora_registro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edthora_registro_Internalname, context.localUtil.TToC( A242hora_registro, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A242hora_registro, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edthora_registro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edthora_registro_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_bitmap( context, edthora_registro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edthora_registro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtestatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtestatus_Internalname, "estatus", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtestatus_Internalname, A243estatus, StringUtil.RTrim( context.localUtil.Format( A243estatus, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtestatus_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtestatus_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edttrabajo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edttrabajo_Internalname, "trabajo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edttrabajo_Internalname, A244trabajo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edttrabajo_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtnombre_usuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_usuario_Internalname, "nombre_usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_usuario_Internalname, A245nombre_usuario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtnombre_usuario_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtdepto_usuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdepto_usuario_Internalname, "depto_usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtdepto_usuario_Internalname, A246depto_usuario, StringUtil.RTrim( context.localUtil.Format( A246depto_usuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtdepto_usuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtdepto_usuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtcorreo_usuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcorreo_usuario_Internalname, "correo_usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtcorreo_usuario_Internalname, A247correo_usuario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", 0, 1, edtcorreo_usuario_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtdetalle_infotecid_unidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdetalle_infotecid_unidad_Internalname, "id_unidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtdetalle_infotecid_unidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ",", "")), ((edtdetalle_infotecid_unidad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtdetalle_infotecid_unidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtdetalle_infotecid_unidad_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtid_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_categoria_Internalname, "id_categoria", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A249id_categoria), 9, 0, ",", "")), ((edtid_categoria_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A249id_categoria), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A249id_categoria), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_categoria_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtid_categoria_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtid_actividad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_actividad_Internalname, "id_actividad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_actividad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A250id_actividad), 9, 0, ",", "")), ((edtid_actividad_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A250id_actividad), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A250id_actividad), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_actividad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtid_actividad_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtdetalle_tarea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdetalle_tarea_Internalname, "detalle_tarea", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtdetalle_tarea_Internalname, A251detalle_tarea, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", 0, 1, edtdetalle_tarea_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtprioridad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprioridad_Internalname, "prioridad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprioridad_Internalname, A252prioridad, StringUtil.RTrim( context.localUtil.Format( A252prioridad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprioridad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtprioridad_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtobservaciones_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtobservaciones_Internalname, "observaciones", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtobservaciones_Internalname, A253observaciones, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", 0, 1, edtobservaciones_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtfecha_solicitud_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfecha_solicitud_Internalname, "fecha_solicitud", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtfecha_solicitud_Internalname, A254fecha_solicitud, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,108);\"", 0, 1, edtfecha_solicitud_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtfecha_ciere_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfecha_ciere_Internalname, "fecha_ciere", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtfecha_ciere_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtfecha_ciere_Internalname, context.localUtil.Format(A255fecha_ciere, "99/99/99"), context.localUtil.Format( A255fecha_ciere, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtfecha_ciere_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtfecha_ciere_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_bitmap( context, edtfecha_ciere_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtfecha_ciere_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edthora_cierra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edthora_cierra_Internalname, "hora_cierra", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edthora_cierra_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edthora_cierra_Internalname, context.localUtil.TToC( A256hora_cierra, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A256hora_cierra, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edthora_cierra_Jsonclick, 0, "Attribute", "", "", "", "", 1, edthora_cierra_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_bitmap( context, edthora_cierra_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edthora_cierra_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_detalle_infotec.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
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
            Z238correlativo = (int)(context.localUtil.CToN( cgiGet( "Z238correlativo"), ",", "."));
            Z239nombre_emp = cgiGet( "Z239nombre_emp");
            n239nombre_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) ? true : false);
            Z240cargo_emp = cgiGet( "Z240cargo_emp");
            n240cargo_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A240cargo_emp)) ? true : false);
            Z241fecha_registro = context.localUtil.CToD( cgiGet( "Z241fecha_registro"), 0);
            n241fecha_registro = ((DateTime.MinValue==A241fecha_registro) ? true : false);
            Z242hora_registro = context.localUtil.CToT( cgiGet( "Z242hora_registro"), 0);
            n242hora_registro = ((DateTime.MinValue==A242hora_registro) ? true : false);
            Z243estatus = cgiGet( "Z243estatus");
            n243estatus = (String.IsNullOrEmpty(StringUtil.RTrim( A243estatus)) ? true : false);
            Z244trabajo = cgiGet( "Z244trabajo");
            n244trabajo = (String.IsNullOrEmpty(StringUtil.RTrim( A244trabajo)) ? true : false);
            Z245nombre_usuario = cgiGet( "Z245nombre_usuario");
            n245nombre_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A245nombre_usuario)) ? true : false);
            Z246depto_usuario = cgiGet( "Z246depto_usuario");
            n246depto_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A246depto_usuario)) ? true : false);
            Z247correo_usuario = cgiGet( "Z247correo_usuario");
            n247correo_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A247correo_usuario)) ? true : false);
            Z248detalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( "Z248detalle_infotecid_unidad"), ",", "."));
            n248detalle_infotecid_unidad = ((0==A248detalle_infotecid_unidad) ? true : false);
            Z249id_categoria = (int)(context.localUtil.CToN( cgiGet( "Z249id_categoria"), ",", "."));
            n249id_categoria = ((0==A249id_categoria) ? true : false);
            Z250id_actividad = (int)(context.localUtil.CToN( cgiGet( "Z250id_actividad"), ",", "."));
            n250id_actividad = ((0==A250id_actividad) ? true : false);
            Z251detalle_tarea = cgiGet( "Z251detalle_tarea");
            n251detalle_tarea = (String.IsNullOrEmpty(StringUtil.RTrim( A251detalle_tarea)) ? true : false);
            Z252prioridad = cgiGet( "Z252prioridad");
            n252prioridad = (String.IsNullOrEmpty(StringUtil.RTrim( A252prioridad)) ? true : false);
            Z253observaciones = cgiGet( "Z253observaciones");
            n253observaciones = (String.IsNullOrEmpty(StringUtil.RTrim( A253observaciones)) ? true : false);
            Z254fecha_solicitud = cgiGet( "Z254fecha_solicitud");
            n254fecha_solicitud = (String.IsNullOrEmpty(StringUtil.RTrim( A254fecha_solicitud)) ? true : false);
            Z255fecha_ciere = context.localUtil.CToD( cgiGet( "Z255fecha_ciere"), 0);
            n255fecha_ciere = ((DateTime.MinValue==A255fecha_ciere) ? true : false);
            Z256hora_cierra = context.localUtil.CToT( cgiGet( "Z256hora_cierra"), 0);
            n256hora_cierra = ((DateTime.MinValue==A256hora_cierra) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtcorrelativo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtcorrelativo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORRELATIVO");
               AnyError = 1;
               GX_FocusControl = edtcorrelativo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A238correlativo = 0;
               AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
            }
            else
            {
               A238correlativo = (int)(context.localUtil.CToN( cgiGet( edtcorrelativo_Internalname), ",", "."));
               AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
            }
            A239nombre_emp = cgiGet( edtnombre_emp_Internalname);
            n239nombre_emp = false;
            AssignAttri("", false, "A239nombre_emp", A239nombre_emp);
            n239nombre_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) ? true : false);
            A240cargo_emp = cgiGet( edtcargo_emp_Internalname);
            n240cargo_emp = false;
            AssignAttri("", false, "A240cargo_emp", A240cargo_emp);
            n240cargo_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A240cargo_emp)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtfecha_registro_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_registro"}), 1, "FECHA_REGISTRO");
               AnyError = 1;
               GX_FocusControl = edtfecha_registro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A241fecha_registro = DateTime.MinValue;
               n241fecha_registro = false;
               AssignAttri("", false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
            }
            else
            {
               A241fecha_registro = context.localUtil.CToD( cgiGet( edtfecha_registro_Internalname), 2);
               n241fecha_registro = false;
               AssignAttri("", false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
            }
            n241fecha_registro = ((DateTime.MinValue==A241fecha_registro) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edthora_registro_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"hora_registro"}), 1, "HORA_REGISTRO");
               AnyError = 1;
               GX_FocusControl = edthora_registro_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A242hora_registro = (DateTime)(DateTime.MinValue);
               n242hora_registro = false;
               AssignAttri("", false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A242hora_registro = context.localUtil.CToT( cgiGet( edthora_registro_Internalname));
               n242hora_registro = false;
               AssignAttri("", false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 8, 5, 0, 3, "/", ":", " "));
            }
            n242hora_registro = ((DateTime.MinValue==A242hora_registro) ? true : false);
            A243estatus = cgiGet( edtestatus_Internalname);
            n243estatus = false;
            AssignAttri("", false, "A243estatus", A243estatus);
            n243estatus = (String.IsNullOrEmpty(StringUtil.RTrim( A243estatus)) ? true : false);
            A244trabajo = cgiGet( edttrabajo_Internalname);
            n244trabajo = false;
            AssignAttri("", false, "A244trabajo", A244trabajo);
            n244trabajo = (String.IsNullOrEmpty(StringUtil.RTrim( A244trabajo)) ? true : false);
            A245nombre_usuario = cgiGet( edtnombre_usuario_Internalname);
            n245nombre_usuario = false;
            AssignAttri("", false, "A245nombre_usuario", A245nombre_usuario);
            n245nombre_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A245nombre_usuario)) ? true : false);
            A246depto_usuario = cgiGet( edtdepto_usuario_Internalname);
            n246depto_usuario = false;
            AssignAttri("", false, "A246depto_usuario", A246depto_usuario);
            n246depto_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A246depto_usuario)) ? true : false);
            A247correo_usuario = cgiGet( edtcorreo_usuario_Internalname);
            n247correo_usuario = false;
            AssignAttri("", false, "A247correo_usuario", A247correo_usuario);
            n247correo_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A247correo_usuario)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DETALLE_INFOTECID_UNIDAD");
               AnyError = 1;
               GX_FocusControl = edtdetalle_infotecid_unidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A248detalle_infotecid_unidad = 0;
               n248detalle_infotecid_unidad = false;
               AssignAttri("", false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
            }
            else
            {
               A248detalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ",", "."));
               n248detalle_infotecid_unidad = false;
               AssignAttri("", false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
            }
            n248detalle_infotecid_unidad = ((0==A248detalle_infotecid_unidad) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_CATEGORIA");
               AnyError = 1;
               GX_FocusControl = edtid_categoria_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A249id_categoria = 0;
               n249id_categoria = false;
               AssignAttri("", false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
            }
            else
            {
               A249id_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ",", "."));
               n249id_categoria = false;
               AssignAttri("", false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
            }
            n249id_categoria = ((0==A249id_categoria) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_ACTIVIDAD");
               AnyError = 1;
               GX_FocusControl = edtid_actividad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A250id_actividad = 0;
               n250id_actividad = false;
               AssignAttri("", false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
            }
            else
            {
               A250id_actividad = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ",", "."));
               n250id_actividad = false;
               AssignAttri("", false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
            }
            n250id_actividad = ((0==A250id_actividad) ? true : false);
            A251detalle_tarea = cgiGet( edtdetalle_tarea_Internalname);
            n251detalle_tarea = false;
            AssignAttri("", false, "A251detalle_tarea", A251detalle_tarea);
            n251detalle_tarea = (String.IsNullOrEmpty(StringUtil.RTrim( A251detalle_tarea)) ? true : false);
            A252prioridad = cgiGet( edtprioridad_Internalname);
            n252prioridad = false;
            AssignAttri("", false, "A252prioridad", A252prioridad);
            n252prioridad = (String.IsNullOrEmpty(StringUtil.RTrim( A252prioridad)) ? true : false);
            A253observaciones = cgiGet( edtobservaciones_Internalname);
            n253observaciones = false;
            AssignAttri("", false, "A253observaciones", A253observaciones);
            n253observaciones = (String.IsNullOrEmpty(StringUtil.RTrim( A253observaciones)) ? true : false);
            A254fecha_solicitud = cgiGet( edtfecha_solicitud_Internalname);
            n254fecha_solicitud = false;
            AssignAttri("", false, "A254fecha_solicitud", A254fecha_solicitud);
            n254fecha_solicitud = (String.IsNullOrEmpty(StringUtil.RTrim( A254fecha_solicitud)) ? true : false);
            if ( context.localUtil.VCDate( cgiGet( edtfecha_ciere_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_ciere"}), 1, "FECHA_CIERE");
               AnyError = 1;
               GX_FocusControl = edtfecha_ciere_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A255fecha_ciere = DateTime.MinValue;
               n255fecha_ciere = false;
               AssignAttri("", false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
            }
            else
            {
               A255fecha_ciere = context.localUtil.CToD( cgiGet( edtfecha_ciere_Internalname), 2);
               n255fecha_ciere = false;
               AssignAttri("", false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
            }
            n255fecha_ciere = ((DateTime.MinValue==A255fecha_ciere) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edthora_cierra_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"hora_cierra"}), 1, "HORA_CIERRA");
               AnyError = 1;
               GX_FocusControl = edthora_cierra_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A256hora_cierra = (DateTime)(DateTime.MinValue);
               n256hora_cierra = false;
               AssignAttri("", false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A256hora_cierra = context.localUtil.CToT( cgiGet( edthora_cierra_Internalname));
               n256hora_cierra = false;
               AssignAttri("", false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 8, 5, 0, 3, "/", ":", " "));
            }
            n256hora_cierra = ((DateTime.MinValue==A256hora_cierra) ? true : false);
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
               A238correlativo = (int)(NumberUtil.Val( GetPar( "correlativo"), "."));
               AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
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
               InitAll0G17( ) ;
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
         DisableAttributes0G17( ) ;
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

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z239nombre_emp = T000G3_A239nombre_emp[0];
               Z240cargo_emp = T000G3_A240cargo_emp[0];
               Z241fecha_registro = T000G3_A241fecha_registro[0];
               Z242hora_registro = T000G3_A242hora_registro[0];
               Z243estatus = T000G3_A243estatus[0];
               Z244trabajo = T000G3_A244trabajo[0];
               Z245nombre_usuario = T000G3_A245nombre_usuario[0];
               Z246depto_usuario = T000G3_A246depto_usuario[0];
               Z247correo_usuario = T000G3_A247correo_usuario[0];
               Z248detalle_infotecid_unidad = T000G3_A248detalle_infotecid_unidad[0];
               Z249id_categoria = T000G3_A249id_categoria[0];
               Z250id_actividad = T000G3_A250id_actividad[0];
               Z251detalle_tarea = T000G3_A251detalle_tarea[0];
               Z252prioridad = T000G3_A252prioridad[0];
               Z253observaciones = T000G3_A253observaciones[0];
               Z254fecha_solicitud = T000G3_A254fecha_solicitud[0];
               Z255fecha_ciere = T000G3_A255fecha_ciere[0];
               Z256hora_cierra = T000G3_A256hora_cierra[0];
            }
            else
            {
               Z239nombre_emp = A239nombre_emp;
               Z240cargo_emp = A240cargo_emp;
               Z241fecha_registro = A241fecha_registro;
               Z242hora_registro = A242hora_registro;
               Z243estatus = A243estatus;
               Z244trabajo = A244trabajo;
               Z245nombre_usuario = A245nombre_usuario;
               Z246depto_usuario = A246depto_usuario;
               Z247correo_usuario = A247correo_usuario;
               Z248detalle_infotecid_unidad = A248detalle_infotecid_unidad;
               Z249id_categoria = A249id_categoria;
               Z250id_actividad = A250id_actividad;
               Z251detalle_tarea = A251detalle_tarea;
               Z252prioridad = A252prioridad;
               Z253observaciones = A253observaciones;
               Z254fecha_solicitud = A254fecha_solicitud;
               Z255fecha_ciere = A255fecha_ciere;
               Z256hora_cierra = A256hora_cierra;
            }
         }
         if ( GX_JID == -5 )
         {
            Z238correlativo = A238correlativo;
            Z239nombre_emp = A239nombre_emp;
            Z240cargo_emp = A240cargo_emp;
            Z241fecha_registro = A241fecha_registro;
            Z242hora_registro = A242hora_registro;
            Z243estatus = A243estatus;
            Z244trabajo = A244trabajo;
            Z245nombre_usuario = A245nombre_usuario;
            Z246depto_usuario = A246depto_usuario;
            Z247correo_usuario = A247correo_usuario;
            Z248detalle_infotecid_unidad = A248detalle_infotecid_unidad;
            Z249id_categoria = A249id_categoria;
            Z250id_actividad = A250id_actividad;
            Z251detalle_tarea = A251detalle_tarea;
            Z252prioridad = A252prioridad;
            Z253observaciones = A253observaciones;
            Z254fecha_solicitud = A254fecha_solicitud;
            Z255fecha_ciere = A255fecha_ciere;
            Z256hora_cierra = A256hora_cierra;
         }
      }

      protected void standaloneNotModal( )
      {
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

      protected void Load0G17( )
      {
         /* Using cursor T000G4 */
         pr_datastore1.execute(2, new Object[] {A238correlativo});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A239nombre_emp = T000G4_A239nombre_emp[0];
            n239nombre_emp = T000G4_n239nombre_emp[0];
            AssignAttri("", false, "A239nombre_emp", A239nombre_emp);
            A240cargo_emp = T000G4_A240cargo_emp[0];
            n240cargo_emp = T000G4_n240cargo_emp[0];
            AssignAttri("", false, "A240cargo_emp", A240cargo_emp);
            A241fecha_registro = T000G4_A241fecha_registro[0];
            n241fecha_registro = T000G4_n241fecha_registro[0];
            AssignAttri("", false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
            A242hora_registro = T000G4_A242hora_registro[0];
            n242hora_registro = T000G4_n242hora_registro[0];
            AssignAttri("", false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 8, 5, 0, 3, "/", ":", " "));
            A243estatus = T000G4_A243estatus[0];
            n243estatus = T000G4_n243estatus[0];
            AssignAttri("", false, "A243estatus", A243estatus);
            A244trabajo = T000G4_A244trabajo[0];
            n244trabajo = T000G4_n244trabajo[0];
            AssignAttri("", false, "A244trabajo", A244trabajo);
            A245nombre_usuario = T000G4_A245nombre_usuario[0];
            n245nombre_usuario = T000G4_n245nombre_usuario[0];
            AssignAttri("", false, "A245nombre_usuario", A245nombre_usuario);
            A246depto_usuario = T000G4_A246depto_usuario[0];
            n246depto_usuario = T000G4_n246depto_usuario[0];
            AssignAttri("", false, "A246depto_usuario", A246depto_usuario);
            A247correo_usuario = T000G4_A247correo_usuario[0];
            n247correo_usuario = T000G4_n247correo_usuario[0];
            AssignAttri("", false, "A247correo_usuario", A247correo_usuario);
            A248detalle_infotecid_unidad = T000G4_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = T000G4_n248detalle_infotecid_unidad[0];
            AssignAttri("", false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
            A249id_categoria = T000G4_A249id_categoria[0];
            n249id_categoria = T000G4_n249id_categoria[0];
            AssignAttri("", false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
            A250id_actividad = T000G4_A250id_actividad[0];
            n250id_actividad = T000G4_n250id_actividad[0];
            AssignAttri("", false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
            A251detalle_tarea = T000G4_A251detalle_tarea[0];
            n251detalle_tarea = T000G4_n251detalle_tarea[0];
            AssignAttri("", false, "A251detalle_tarea", A251detalle_tarea);
            A252prioridad = T000G4_A252prioridad[0];
            n252prioridad = T000G4_n252prioridad[0];
            AssignAttri("", false, "A252prioridad", A252prioridad);
            A253observaciones = T000G4_A253observaciones[0];
            n253observaciones = T000G4_n253observaciones[0];
            AssignAttri("", false, "A253observaciones", A253observaciones);
            A254fecha_solicitud = T000G4_A254fecha_solicitud[0];
            n254fecha_solicitud = T000G4_n254fecha_solicitud[0];
            AssignAttri("", false, "A254fecha_solicitud", A254fecha_solicitud);
            A255fecha_ciere = T000G4_A255fecha_ciere[0];
            n255fecha_ciere = T000G4_n255fecha_ciere[0];
            AssignAttri("", false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
            A256hora_cierra = T000G4_A256hora_cierra[0];
            n256hora_cierra = T000G4_n256hora_cierra[0];
            AssignAttri("", false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 8, 5, 0, 3, "/", ":", " "));
            ZM0G17( -5) ;
         }
         pr_datastore1.close(2);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A241fecha_registro) || ( A241fecha_registro >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo fecha_registro fuera de rango", "OutOfRange", 1, "FECHA_REGISTRO");
            AnyError = 1;
            GX_FocusControl = edtfecha_registro_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A242hora_registro) || ( A242hora_registro >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo hora_registro fuera de rango", "OutOfRange", 1, "HORA_REGISTRO");
            AnyError = 1;
            GX_FocusControl = edthora_registro_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A255fecha_ciere) || ( A255fecha_ciere >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo fecha_ciere fuera de rango", "OutOfRange", 1, "FECHA_CIERE");
            AnyError = 1;
            GX_FocusControl = edtfecha_ciere_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A256hora_cierra) || ( A256hora_cierra >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo hora_cierra fuera de rango", "OutOfRange", 1, "HORA_CIERRA");
            AnyError = 1;
            GX_FocusControl = edthora_cierra_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0G17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G17( )
      {
         /* Using cursor T000G5 */
         pr_datastore1.execute(3, new Object[] {A238correlativo});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_datastore1.execute(1, new Object[] {A238correlativo});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM0G17( 5) ;
            RcdFound17 = 1;
            A238correlativo = T000G3_A238correlativo[0];
            AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
            A239nombre_emp = T000G3_A239nombre_emp[0];
            n239nombre_emp = T000G3_n239nombre_emp[0];
            AssignAttri("", false, "A239nombre_emp", A239nombre_emp);
            A240cargo_emp = T000G3_A240cargo_emp[0];
            n240cargo_emp = T000G3_n240cargo_emp[0];
            AssignAttri("", false, "A240cargo_emp", A240cargo_emp);
            A241fecha_registro = T000G3_A241fecha_registro[0];
            n241fecha_registro = T000G3_n241fecha_registro[0];
            AssignAttri("", false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
            A242hora_registro = T000G3_A242hora_registro[0];
            n242hora_registro = T000G3_n242hora_registro[0];
            AssignAttri("", false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 8, 5, 0, 3, "/", ":", " "));
            A243estatus = T000G3_A243estatus[0];
            n243estatus = T000G3_n243estatus[0];
            AssignAttri("", false, "A243estatus", A243estatus);
            A244trabajo = T000G3_A244trabajo[0];
            n244trabajo = T000G3_n244trabajo[0];
            AssignAttri("", false, "A244trabajo", A244trabajo);
            A245nombre_usuario = T000G3_A245nombre_usuario[0];
            n245nombre_usuario = T000G3_n245nombre_usuario[0];
            AssignAttri("", false, "A245nombre_usuario", A245nombre_usuario);
            A246depto_usuario = T000G3_A246depto_usuario[0];
            n246depto_usuario = T000G3_n246depto_usuario[0];
            AssignAttri("", false, "A246depto_usuario", A246depto_usuario);
            A247correo_usuario = T000G3_A247correo_usuario[0];
            n247correo_usuario = T000G3_n247correo_usuario[0];
            AssignAttri("", false, "A247correo_usuario", A247correo_usuario);
            A248detalle_infotecid_unidad = T000G3_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = T000G3_n248detalle_infotecid_unidad[0];
            AssignAttri("", false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
            A249id_categoria = T000G3_A249id_categoria[0];
            n249id_categoria = T000G3_n249id_categoria[0];
            AssignAttri("", false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
            A250id_actividad = T000G3_A250id_actividad[0];
            n250id_actividad = T000G3_n250id_actividad[0];
            AssignAttri("", false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
            A251detalle_tarea = T000G3_A251detalle_tarea[0];
            n251detalle_tarea = T000G3_n251detalle_tarea[0];
            AssignAttri("", false, "A251detalle_tarea", A251detalle_tarea);
            A252prioridad = T000G3_A252prioridad[0];
            n252prioridad = T000G3_n252prioridad[0];
            AssignAttri("", false, "A252prioridad", A252prioridad);
            A253observaciones = T000G3_A253observaciones[0];
            n253observaciones = T000G3_n253observaciones[0];
            AssignAttri("", false, "A253observaciones", A253observaciones);
            A254fecha_solicitud = T000G3_A254fecha_solicitud[0];
            n254fecha_solicitud = T000G3_n254fecha_solicitud[0];
            AssignAttri("", false, "A254fecha_solicitud", A254fecha_solicitud);
            A255fecha_ciere = T000G3_A255fecha_ciere[0];
            n255fecha_ciere = T000G3_n255fecha_ciere[0];
            AssignAttri("", false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
            A256hora_cierra = T000G3_A256hora_cierra[0];
            n256hora_cierra = T000G3_n256hora_cierra[0];
            AssignAttri("", false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 8, 5, 0, 3, "/", ":", " "));
            Z238correlativo = A238correlativo;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RcdFound17 = 0;
         /* Using cursor T000G6 */
         pr_datastore1.execute(4, new Object[] {A238correlativo});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T000G6_A238correlativo[0] < A238correlativo ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T000G6_A238correlativo[0] > A238correlativo ) ) )
            {
               A238correlativo = T000G6_A238correlativo[0];
               AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
               RcdFound17 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000G7 */
         pr_datastore1.execute(5, new Object[] {A238correlativo});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T000G7_A238correlativo[0] > A238correlativo ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T000G7_A238correlativo[0] < A238correlativo ) ) )
            {
               A238correlativo = T000G7_A238correlativo[0];
               AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
               RcdFound17 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtcorrelativo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A238correlativo != Z238correlativo )
               {
                  A238correlativo = Z238correlativo;
                  AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CORRELATIVO");
                  AnyError = 1;
                  GX_FocusControl = edtcorrelativo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtcorrelativo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G17( ) ;
                  GX_FocusControl = edtcorrelativo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A238correlativo != Z238correlativo )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtcorrelativo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CORRELATIVO");
                     AnyError = 1;
                     GX_FocusControl = edtcorrelativo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtcorrelativo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G17( ) ;
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
         if ( A238correlativo != Z238correlativo )
         {
            A238correlativo = Z238correlativo;
            AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CORRELATIVO");
            AnyError = 1;
            GX_FocusControl = edtcorrelativo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtcorrelativo_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CORRELATIVO");
            AnyError = 1;
            GX_FocusControl = edtcorrelativo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtnombre_emp_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtnombre_emp_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtnombre_emp_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtnombre_emp_Internalname;
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
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound17 != 0 )
            {
               ScanNext0G17( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtnombre_emp_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_datastore1.execute(0, new Object[] {A238correlativo});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DETALLE_INFOTEC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( StringUtil.StrCmp(Z239nombre_emp, T000G2_A239nombre_emp[0]) != 0 ) || ( StringUtil.StrCmp(Z240cargo_emp, T000G2_A240cargo_emp[0]) != 0 ) || ( Z241fecha_registro != T000G2_A241fecha_registro[0] ) || ( Z242hora_registro != T000G2_A242hora_registro[0] ) || ( StringUtil.StrCmp(Z243estatus, T000G2_A243estatus[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z244trabajo, T000G2_A244trabajo[0]) != 0 ) || ( StringUtil.StrCmp(Z245nombre_usuario, T000G2_A245nombre_usuario[0]) != 0 ) || ( StringUtil.StrCmp(Z246depto_usuario, T000G2_A246depto_usuario[0]) != 0 ) || ( StringUtil.StrCmp(Z247correo_usuario, T000G2_A247correo_usuario[0]) != 0 ) || ( Z248detalle_infotecid_unidad != T000G2_A248detalle_infotecid_unidad[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z249id_categoria != T000G2_A249id_categoria[0] ) || ( Z250id_actividad != T000G2_A250id_actividad[0] ) || ( StringUtil.StrCmp(Z251detalle_tarea, T000G2_A251detalle_tarea[0]) != 0 ) || ( StringUtil.StrCmp(Z252prioridad, T000G2_A252prioridad[0]) != 0 ) || ( StringUtil.StrCmp(Z253observaciones, T000G2_A253observaciones[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z254fecha_solicitud, T000G2_A254fecha_solicitud[0]) != 0 ) || ( Z255fecha_ciere != T000G2_A255fecha_ciere[0] ) || ( Z256hora_cierra != T000G2_A256hora_cierra[0] ) )
            {
               if ( StringUtil.StrCmp(Z239nombre_emp, T000G2_A239nombre_emp[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"nombre_emp");
                  GXUtil.WriteLogRaw("Old: ",Z239nombre_emp);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A239nombre_emp[0]);
               }
               if ( StringUtil.StrCmp(Z240cargo_emp, T000G2_A240cargo_emp[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"cargo_emp");
                  GXUtil.WriteLogRaw("Old: ",Z240cargo_emp);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A240cargo_emp[0]);
               }
               if ( Z241fecha_registro != T000G2_A241fecha_registro[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"fecha_registro");
                  GXUtil.WriteLogRaw("Old: ",Z241fecha_registro);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A241fecha_registro[0]);
               }
               if ( Z242hora_registro != T000G2_A242hora_registro[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"hora_registro");
                  GXUtil.WriteLogRaw("Old: ",Z242hora_registro);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A242hora_registro[0]);
               }
               if ( StringUtil.StrCmp(Z243estatus, T000G2_A243estatus[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"estatus");
                  GXUtil.WriteLogRaw("Old: ",Z243estatus);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A243estatus[0]);
               }
               if ( StringUtil.StrCmp(Z244trabajo, T000G2_A244trabajo[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"trabajo");
                  GXUtil.WriteLogRaw("Old: ",Z244trabajo);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A244trabajo[0]);
               }
               if ( StringUtil.StrCmp(Z245nombre_usuario, T000G2_A245nombre_usuario[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"nombre_usuario");
                  GXUtil.WriteLogRaw("Old: ",Z245nombre_usuario);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A245nombre_usuario[0]);
               }
               if ( StringUtil.StrCmp(Z246depto_usuario, T000G2_A246depto_usuario[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"depto_usuario");
                  GXUtil.WriteLogRaw("Old: ",Z246depto_usuario);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A246depto_usuario[0]);
               }
               if ( StringUtil.StrCmp(Z247correo_usuario, T000G2_A247correo_usuario[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"correo_usuario");
                  GXUtil.WriteLogRaw("Old: ",Z247correo_usuario);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A247correo_usuario[0]);
               }
               if ( Z248detalle_infotecid_unidad != T000G2_A248detalle_infotecid_unidad[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"detalle_infotecid_unidad");
                  GXUtil.WriteLogRaw("Old: ",Z248detalle_infotecid_unidad);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A248detalle_infotecid_unidad[0]);
               }
               if ( Z249id_categoria != T000G2_A249id_categoria[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"id_categoria");
                  GXUtil.WriteLogRaw("Old: ",Z249id_categoria);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A249id_categoria[0]);
               }
               if ( Z250id_actividad != T000G2_A250id_actividad[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"id_actividad");
                  GXUtil.WriteLogRaw("Old: ",Z250id_actividad);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A250id_actividad[0]);
               }
               if ( StringUtil.StrCmp(Z251detalle_tarea, T000G2_A251detalle_tarea[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"detalle_tarea");
                  GXUtil.WriteLogRaw("Old: ",Z251detalle_tarea);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A251detalle_tarea[0]);
               }
               if ( StringUtil.StrCmp(Z252prioridad, T000G2_A252prioridad[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"prioridad");
                  GXUtil.WriteLogRaw("Old: ",Z252prioridad);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A252prioridad[0]);
               }
               if ( StringUtil.StrCmp(Z253observaciones, T000G2_A253observaciones[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"observaciones");
                  GXUtil.WriteLogRaw("Old: ",Z253observaciones);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A253observaciones[0]);
               }
               if ( StringUtil.StrCmp(Z254fecha_solicitud, T000G2_A254fecha_solicitud[0]) != 0 )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"fecha_solicitud");
                  GXUtil.WriteLogRaw("Old: ",Z254fecha_solicitud);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A254fecha_solicitud[0]);
               }
               if ( Z255fecha_ciere != T000G2_A255fecha_ciere[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"fecha_ciere");
                  GXUtil.WriteLogRaw("Old: ",Z255fecha_ciere);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A255fecha_ciere[0]);
               }
               if ( Z256hora_cierra != T000G2_A256hora_cierra[0] )
               {
                  GXUtil.WriteLog("detalle_infotec:[seudo value changed for attri]"+"hora_cierra");
                  GXUtil.WriteLogRaw("Old: ",Z256hora_cierra);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A256hora_cierra[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DETALLE_INFOTEC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         if ( ! IsAuthorized("detalle_infotec_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G8 */
                     pr_datastore1.execute(6, new Object[] {n239nombre_emp, A239nombre_emp, n240cargo_emp, A240cargo_emp, n241fecha_registro, A241fecha_registro, n242hora_registro, A242hora_registro, n243estatus, A243estatus, n244trabajo, A244trabajo, n245nombre_usuario, A245nombre_usuario, n246depto_usuario, A246depto_usuario, n247correo_usuario, A247correo_usuario, n248detalle_infotecid_unidad, A248detalle_infotecid_unidad, n249id_categoria, A249id_categoria, n250id_actividad, A250id_actividad, n251detalle_tarea, A251detalle_tarea, n252prioridad, A252prioridad, n253observaciones, A253observaciones, n254fecha_solicitud, A254fecha_solicitud, n255fecha_ciere, A255fecha_ciere, n256hora_cierra, A256hora_cierra});
                     A238correlativo = T000G8_A238correlativo[0];
                     AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                     pr_datastore1.close(6);
                     dsDataStore1.SmartCacheProvider.SetUpdated("DETALLE_INFOTEC");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0G0( ) ;
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         if ( ! IsAuthorized("detalle_infotec_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G9 */
                     pr_datastore1.execute(7, new Object[] {n239nombre_emp, A239nombre_emp, n240cargo_emp, A240cargo_emp, n241fecha_registro, A241fecha_registro, n242hora_registro, A242hora_registro, n243estatus, A243estatus, n244trabajo, A244trabajo, n245nombre_usuario, A245nombre_usuario, n246depto_usuario, A246depto_usuario, n247correo_usuario, A247correo_usuario, n248detalle_infotecid_unidad, A248detalle_infotecid_unidad, n249id_categoria, A249id_categoria, n250id_actividad, A250id_actividad, n251detalle_tarea, A251detalle_tarea, n252prioridad, A252prioridad, n253observaciones, A253observaciones, n254fecha_solicitud, A254fecha_solicitud, n255fecha_ciere, A255fecha_ciere, n256hora_cierra, A256hora_cierra, A238correlativo});
                     pr_datastore1.close(7);
                     dsDataStore1.SmartCacheProvider.SetUpdated("DETALLE_INFOTEC");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DETALLE_INFOTEC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
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
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("detalle_infotec_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G10 */
                  pr_datastore1.execute(8, new Object[] {A238correlativo});
                  pr_datastore1.close(8);
                  dsDataStore1.SmartCacheProvider.SetUpdated("DETALLE_INFOTEC");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound17 == 0 )
                        {
                           InitAll0G17( ) ;
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
                        ResetCaption0G0( ) ;
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore1.close(1);
            context.CommitDataStores("detalle_infotec",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore1.close(1);
            context.RollbackDataStores("detalle_infotec",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G17( )
      {
         /* Using cursor T000G11 */
         pr_datastore1.execute(9);
         RcdFound17 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound17 = 1;
            A238correlativo = T000G11_A238correlativo[0];
            AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G17( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound17 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound17 = 1;
            A238correlativo = T000G11_A238correlativo[0];
            AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
         }
      }

      protected void ScanEnd0G17( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
         edtcorrelativo_Enabled = 0;
         AssignProp("", false, edtcorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorrelativo_Enabled), 5, 0), true);
         edtnombre_emp_Enabled = 0;
         AssignProp("", false, edtnombre_emp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_emp_Enabled), 5, 0), true);
         edtcargo_emp_Enabled = 0;
         AssignProp("", false, edtcargo_emp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcargo_emp_Enabled), 5, 0), true);
         edtfecha_registro_Enabled = 0;
         AssignProp("", false, edtfecha_registro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfecha_registro_Enabled), 5, 0), true);
         edthora_registro_Enabled = 0;
         AssignProp("", false, edthora_registro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edthora_registro_Enabled), 5, 0), true);
         edtestatus_Enabled = 0;
         AssignProp("", false, edtestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtestatus_Enabled), 5, 0), true);
         edttrabajo_Enabled = 0;
         AssignProp("", false, edttrabajo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edttrabajo_Enabled), 5, 0), true);
         edtnombre_usuario_Enabled = 0;
         AssignProp("", false, edtnombre_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_usuario_Enabled), 5, 0), true);
         edtdepto_usuario_Enabled = 0;
         AssignProp("", false, edtdepto_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdepto_usuario_Enabled), 5, 0), true);
         edtcorreo_usuario_Enabled = 0;
         AssignProp("", false, edtcorreo_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorreo_usuario_Enabled), 5, 0), true);
         edtdetalle_infotecid_unidad_Enabled = 0;
         AssignProp("", false, edtdetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdetalle_infotecid_unidad_Enabled), 5, 0), true);
         edtid_categoria_Enabled = 0;
         AssignProp("", false, edtid_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_categoria_Enabled), 5, 0), true);
         edtid_actividad_Enabled = 0;
         AssignProp("", false, edtid_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_Enabled), 5, 0), true);
         edtdetalle_tarea_Enabled = 0;
         AssignProp("", false, edtdetalle_tarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdetalle_tarea_Enabled), 5, 0), true);
         edtprioridad_Enabled = 0;
         AssignProp("", false, edtprioridad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprioridad_Enabled), 5, 0), true);
         edtobservaciones_Enabled = 0;
         AssignProp("", false, edtobservaciones_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtobservaciones_Enabled), 5, 0), true);
         edtfecha_solicitud_Enabled = 0;
         AssignProp("", false, edtfecha_solicitud_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfecha_solicitud_Enabled), 5, 0), true);
         edtfecha_ciere_Enabled = 0;
         AssignProp("", false, edtfecha_ciere_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfecha_ciere_Enabled), 5, 0), true);
         edthora_cierra_Enabled = 0;
         AssignProp("", false, edthora_cierra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edthora_cierra_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20231249524461", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("detalle_infotec.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z238correlativo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z238correlativo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z239nombre_emp", Z239nombre_emp);
         GxWebStd.gx_hidden_field( context, "Z240cargo_emp", Z240cargo_emp);
         GxWebStd.gx_hidden_field( context, "Z241fecha_registro", context.localUtil.DToC( Z241fecha_registro, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z242hora_registro", context.localUtil.TToC( Z242hora_registro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z243estatus", Z243estatus);
         GxWebStd.gx_hidden_field( context, "Z244trabajo", Z244trabajo);
         GxWebStd.gx_hidden_field( context, "Z245nombre_usuario", Z245nombre_usuario);
         GxWebStd.gx_hidden_field( context, "Z246depto_usuario", Z246depto_usuario);
         GxWebStd.gx_hidden_field( context, "Z247correo_usuario", Z247correo_usuario);
         GxWebStd.gx_hidden_field( context, "Z248detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z248detalle_infotecid_unidad), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z249id_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z249id_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z250id_actividad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z250id_actividad), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z251detalle_tarea", Z251detalle_tarea);
         GxWebStd.gx_hidden_field( context, "Z252prioridad", Z252prioridad);
         GxWebStd.gx_hidden_field( context, "Z253observaciones", Z253observaciones);
         GxWebStd.gx_hidden_field( context, "Z254fecha_solicitud", Z254fecha_solicitud);
         GxWebStd.gx_hidden_field( context, "Z255fecha_ciere", context.localUtil.DToC( Z255fecha_ciere, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z256hora_cierra", context.localUtil.TToC( Z256hora_cierra, 10, 8, 0, 0, "/", ":", " "));
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
         return formatLink("detalle_infotec.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "detalle_infotec" ;
      }

      public override string GetPgmdesc( )
      {
         return "detalle_infotec" ;
      }

      protected void InitializeNonKey0G17( )
      {
         A239nombre_emp = "";
         n239nombre_emp = false;
         AssignAttri("", false, "A239nombre_emp", A239nombre_emp);
         n239nombre_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) ? true : false);
         A240cargo_emp = "";
         n240cargo_emp = false;
         AssignAttri("", false, "A240cargo_emp", A240cargo_emp);
         n240cargo_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A240cargo_emp)) ? true : false);
         A241fecha_registro = DateTime.MinValue;
         n241fecha_registro = false;
         AssignAttri("", false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
         n241fecha_registro = ((DateTime.MinValue==A241fecha_registro) ? true : false);
         A242hora_registro = (DateTime)(DateTime.MinValue);
         n242hora_registro = false;
         AssignAttri("", false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 8, 5, 0, 3, "/", ":", " "));
         n242hora_registro = ((DateTime.MinValue==A242hora_registro) ? true : false);
         A243estatus = "";
         n243estatus = false;
         AssignAttri("", false, "A243estatus", A243estatus);
         n243estatus = (String.IsNullOrEmpty(StringUtil.RTrim( A243estatus)) ? true : false);
         A244trabajo = "";
         n244trabajo = false;
         AssignAttri("", false, "A244trabajo", A244trabajo);
         n244trabajo = (String.IsNullOrEmpty(StringUtil.RTrim( A244trabajo)) ? true : false);
         A245nombre_usuario = "";
         n245nombre_usuario = false;
         AssignAttri("", false, "A245nombre_usuario", A245nombre_usuario);
         n245nombre_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A245nombre_usuario)) ? true : false);
         A246depto_usuario = "";
         n246depto_usuario = false;
         AssignAttri("", false, "A246depto_usuario", A246depto_usuario);
         n246depto_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A246depto_usuario)) ? true : false);
         A247correo_usuario = "";
         n247correo_usuario = false;
         AssignAttri("", false, "A247correo_usuario", A247correo_usuario);
         n247correo_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A247correo_usuario)) ? true : false);
         A248detalle_infotecid_unidad = 0;
         n248detalle_infotecid_unidad = false;
         AssignAttri("", false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
         n248detalle_infotecid_unidad = ((0==A248detalle_infotecid_unidad) ? true : false);
         A249id_categoria = 0;
         n249id_categoria = false;
         AssignAttri("", false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
         n249id_categoria = ((0==A249id_categoria) ? true : false);
         A250id_actividad = 0;
         n250id_actividad = false;
         AssignAttri("", false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
         n250id_actividad = ((0==A250id_actividad) ? true : false);
         A251detalle_tarea = "";
         n251detalle_tarea = false;
         AssignAttri("", false, "A251detalle_tarea", A251detalle_tarea);
         n251detalle_tarea = (String.IsNullOrEmpty(StringUtil.RTrim( A251detalle_tarea)) ? true : false);
         A252prioridad = "";
         n252prioridad = false;
         AssignAttri("", false, "A252prioridad", A252prioridad);
         n252prioridad = (String.IsNullOrEmpty(StringUtil.RTrim( A252prioridad)) ? true : false);
         A253observaciones = "";
         n253observaciones = false;
         AssignAttri("", false, "A253observaciones", A253observaciones);
         n253observaciones = (String.IsNullOrEmpty(StringUtil.RTrim( A253observaciones)) ? true : false);
         A254fecha_solicitud = "";
         n254fecha_solicitud = false;
         AssignAttri("", false, "A254fecha_solicitud", A254fecha_solicitud);
         n254fecha_solicitud = (String.IsNullOrEmpty(StringUtil.RTrim( A254fecha_solicitud)) ? true : false);
         A255fecha_ciere = DateTime.MinValue;
         n255fecha_ciere = false;
         AssignAttri("", false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
         n255fecha_ciere = ((DateTime.MinValue==A255fecha_ciere) ? true : false);
         A256hora_cierra = (DateTime)(DateTime.MinValue);
         n256hora_cierra = false;
         AssignAttri("", false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 8, 5, 0, 3, "/", ":", " "));
         n256hora_cierra = ((DateTime.MinValue==A256hora_cierra) ? true : false);
         Z239nombre_emp = "";
         Z240cargo_emp = "";
         Z241fecha_registro = DateTime.MinValue;
         Z242hora_registro = (DateTime)(DateTime.MinValue);
         Z243estatus = "";
         Z244trabajo = "";
         Z245nombre_usuario = "";
         Z246depto_usuario = "";
         Z247correo_usuario = "";
         Z248detalle_infotecid_unidad = 0;
         Z249id_categoria = 0;
         Z250id_actividad = 0;
         Z251detalle_tarea = "";
         Z252prioridad = "";
         Z253observaciones = "";
         Z254fecha_solicitud = "";
         Z255fecha_ciere = DateTime.MinValue;
         Z256hora_cierra = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll0G17( )
      {
         A238correlativo = 0;
         AssignAttri("", false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
         InitializeNonKey0G17( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249524474", true, true);
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
         context.AddJavascriptSource("detalle_infotec.js", "?20231249524474", false, true);
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
         edtcorrelativo_Internalname = "CORRELATIVO";
         edtnombre_emp_Internalname = "NOMBRE_EMP";
         edtcargo_emp_Internalname = "CARGO_EMP";
         edtfecha_registro_Internalname = "FECHA_REGISTRO";
         edthora_registro_Internalname = "HORA_REGISTRO";
         edtestatus_Internalname = "ESTATUS";
         edttrabajo_Internalname = "TRABAJO";
         edtnombre_usuario_Internalname = "NOMBRE_USUARIO";
         edtdepto_usuario_Internalname = "DEPTO_USUARIO";
         edtcorreo_usuario_Internalname = "CORREO_USUARIO";
         edtdetalle_infotecid_unidad_Internalname = "DETALLE_INFOTECID_UNIDAD";
         edtid_categoria_Internalname = "ID_CATEGORIA";
         edtid_actividad_Internalname = "ID_ACTIVIDAD";
         edtdetalle_tarea_Internalname = "DETALLE_TAREA";
         edtprioridad_Internalname = "PRIORIDAD";
         edtobservaciones_Internalname = "OBSERVACIONES";
         edtfecha_solicitud_Internalname = "FECHA_SOLICITUD";
         edtfecha_ciere_Internalname = "FECHA_CIERE";
         edthora_cierra_Internalname = "HORA_CIERRA";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "detalle_infotec";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edthora_cierra_Jsonclick = "";
         edthora_cierra_Enabled = 1;
         edtfecha_ciere_Jsonclick = "";
         edtfecha_ciere_Enabled = 1;
         edtfecha_solicitud_Enabled = 1;
         edtobservaciones_Enabled = 1;
         edtprioridad_Jsonclick = "";
         edtprioridad_Enabled = 1;
         edtdetalle_tarea_Enabled = 1;
         edtid_actividad_Jsonclick = "";
         edtid_actividad_Enabled = 1;
         edtid_categoria_Jsonclick = "";
         edtid_categoria_Enabled = 1;
         edtdetalle_infotecid_unidad_Jsonclick = "";
         edtdetalle_infotecid_unidad_Enabled = 1;
         edtcorreo_usuario_Enabled = 1;
         edtdepto_usuario_Jsonclick = "";
         edtdepto_usuario_Enabled = 1;
         edtnombre_usuario_Enabled = 1;
         edttrabajo_Enabled = 1;
         edtestatus_Jsonclick = "";
         edtestatus_Enabled = 1;
         edthora_registro_Jsonclick = "";
         edthora_registro_Enabled = 1;
         edtfecha_registro_Jsonclick = "";
         edtfecha_registro_Enabled = 1;
         edtcargo_emp_Jsonclick = "";
         edtcargo_emp_Enabled = 1;
         edtnombre_emp_Enabled = 1;
         edtcorrelativo_Jsonclick = "";
         edtcorrelativo_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtnombre_emp_Internalname;
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

      public void Valid_Correlativo( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A239nombre_emp", A239nombre_emp);
         AssignAttri("", false, "A240cargo_emp", A240cargo_emp);
         AssignAttri("", false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
         AssignAttri("", false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A243estatus", A243estatus);
         AssignAttri("", false, "A244trabajo", A244trabajo);
         AssignAttri("", false, "A245nombre_usuario", A245nombre_usuario);
         AssignAttri("", false, "A246depto_usuario", A246depto_usuario);
         AssignAttri("", false, "A247correo_usuario", A247correo_usuario);
         AssignAttri("", false, "A248detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ".", "")));
         AssignAttri("", false, "A249id_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(A249id_categoria), 9, 0, ".", "")));
         AssignAttri("", false, "A250id_actividad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A250id_actividad), 9, 0, ".", "")));
         AssignAttri("", false, "A251detalle_tarea", A251detalle_tarea);
         AssignAttri("", false, "A252prioridad", A252prioridad);
         AssignAttri("", false, "A253observaciones", A253observaciones);
         AssignAttri("", false, "A254fecha_solicitud", A254fecha_solicitud);
         AssignAttri("", false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
         AssignAttri("", false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z238correlativo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z238correlativo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z239nombre_emp", Z239nombre_emp);
         GxWebStd.gx_hidden_field( context, "Z240cargo_emp", Z240cargo_emp);
         GxWebStd.gx_hidden_field( context, "Z241fecha_registro", context.localUtil.Format(Z241fecha_registro, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z242hora_registro", context.localUtil.TToC( Z242hora_registro, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z243estatus", Z243estatus);
         GxWebStd.gx_hidden_field( context, "Z244trabajo", Z244trabajo);
         GxWebStd.gx_hidden_field( context, "Z245nombre_usuario", Z245nombre_usuario);
         GxWebStd.gx_hidden_field( context, "Z246depto_usuario", Z246depto_usuario);
         GxWebStd.gx_hidden_field( context, "Z247correo_usuario", Z247correo_usuario);
         GxWebStd.gx_hidden_field( context, "Z248detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z248detalle_infotecid_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z249id_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z249id_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z250id_actividad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z250id_actividad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z251detalle_tarea", Z251detalle_tarea);
         GxWebStd.gx_hidden_field( context, "Z252prioridad", Z252prioridad);
         GxWebStd.gx_hidden_field( context, "Z253observaciones", Z253observaciones);
         GxWebStd.gx_hidden_field( context, "Z254fecha_solicitud", Z254fecha_solicitud);
         GxWebStd.gx_hidden_field( context, "Z255fecha_ciere", context.localUtil.Format(Z255fecha_ciere, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z256hora_cierra", context.localUtil.TToC( Z256hora_cierra, 10, 8, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_CORRELATIVO","{handler:'Valid_Correlativo',iparms:[{av:'A238correlativo',fld:'CORRELATIVO',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CORRELATIVO",",oparms:[{av:'A239nombre_emp',fld:'NOMBRE_EMP',pic:''},{av:'A240cargo_emp',fld:'CARGO_EMP',pic:''},{av:'A241fecha_registro',fld:'FECHA_REGISTRO',pic:''},{av:'A242hora_registro',fld:'HORA_REGISTRO',pic:'99/99/99 99:99'},{av:'A243estatus',fld:'ESTATUS',pic:''},{av:'A244trabajo',fld:'TRABAJO',pic:''},{av:'A245nombre_usuario',fld:'NOMBRE_USUARIO',pic:''},{av:'A246depto_usuario',fld:'DEPTO_USUARIO',pic:''},{av:'A247correo_usuario',fld:'CORREO_USUARIO',pic:''},{av:'A248detalle_infotecid_unidad',fld:'DETALLE_INFOTECID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'A249id_categoria',fld:'ID_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'A250id_actividad',fld:'ID_ACTIVIDAD',pic:'ZZZZZZZZ9'},{av:'A251detalle_tarea',fld:'DETALLE_TAREA',pic:''},{av:'A252prioridad',fld:'PRIORIDAD',pic:''},{av:'A253observaciones',fld:'OBSERVACIONES',pic:''},{av:'A254fecha_solicitud',fld:'FECHA_SOLICITUD',pic:''},{av:'A255fecha_ciere',fld:'FECHA_CIERE',pic:''},{av:'A256hora_cierra',fld:'HORA_CIERRA',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z238correlativo'},{av:'Z239nombre_emp'},{av:'Z240cargo_emp'},{av:'Z241fecha_registro'},{av:'Z242hora_registro'},{av:'Z243estatus'},{av:'Z244trabajo'},{av:'Z245nombre_usuario'},{av:'Z246depto_usuario'},{av:'Z247correo_usuario'},{av:'Z248detalle_infotecid_unidad'},{av:'Z249id_categoria'},{av:'Z250id_actividad'},{av:'Z251detalle_tarea'},{av:'Z252prioridad'},{av:'Z253observaciones'},{av:'Z254fecha_solicitud'},{av:'Z255fecha_ciere'},{av:'Z256hora_cierra'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_FECHA_REGISTRO","{handler:'Valid_Fecha_registro',iparms:[]");
         setEventMetadata("VALID_FECHA_REGISTRO",",oparms:[]}");
         setEventMetadata("VALID_HORA_REGISTRO","{handler:'Valid_Hora_registro',iparms:[]");
         setEventMetadata("VALID_HORA_REGISTRO",",oparms:[]}");
         setEventMetadata("VALID_FECHA_CIERE","{handler:'Valid_Fecha_ciere',iparms:[]");
         setEventMetadata("VALID_FECHA_CIERE",",oparms:[]}");
         setEventMetadata("VALID_HORA_CIERRA","{handler:'Valid_Hora_cierra',iparms:[]");
         setEventMetadata("VALID_HORA_CIERRA",",oparms:[]}");
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
         pr_datastore1.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z239nombre_emp = "";
         Z240cargo_emp = "";
         Z241fecha_registro = DateTime.MinValue;
         Z242hora_registro = (DateTime)(DateTime.MinValue);
         Z243estatus = "";
         Z244trabajo = "";
         Z245nombre_usuario = "";
         Z246depto_usuario = "";
         Z247correo_usuario = "";
         Z251detalle_tarea = "";
         Z252prioridad = "";
         Z253observaciones = "";
         Z254fecha_solicitud = "";
         Z255fecha_ciere = DateTime.MinValue;
         Z256hora_cierra = (DateTime)(DateTime.MinValue);
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
         A239nombre_emp = "";
         A240cargo_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A242hora_registro = (DateTime)(DateTime.MinValue);
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         A254fecha_solicitud = "";
         A255fecha_ciere = DateTime.MinValue;
         A256hora_cierra = (DateTime)(DateTime.MinValue);
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
         T000G4_A238correlativo = new int[1] ;
         T000G4_A239nombre_emp = new string[] {""} ;
         T000G4_n239nombre_emp = new bool[] {false} ;
         T000G4_A240cargo_emp = new string[] {""} ;
         T000G4_n240cargo_emp = new bool[] {false} ;
         T000G4_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         T000G4_n241fecha_registro = new bool[] {false} ;
         T000G4_A242hora_registro = new DateTime[] {DateTime.MinValue} ;
         T000G4_n242hora_registro = new bool[] {false} ;
         T000G4_A243estatus = new string[] {""} ;
         T000G4_n243estatus = new bool[] {false} ;
         T000G4_A244trabajo = new string[] {""} ;
         T000G4_n244trabajo = new bool[] {false} ;
         T000G4_A245nombre_usuario = new string[] {""} ;
         T000G4_n245nombre_usuario = new bool[] {false} ;
         T000G4_A246depto_usuario = new string[] {""} ;
         T000G4_n246depto_usuario = new bool[] {false} ;
         T000G4_A247correo_usuario = new string[] {""} ;
         T000G4_n247correo_usuario = new bool[] {false} ;
         T000G4_A248detalle_infotecid_unidad = new int[1] ;
         T000G4_n248detalle_infotecid_unidad = new bool[] {false} ;
         T000G4_A249id_categoria = new int[1] ;
         T000G4_n249id_categoria = new bool[] {false} ;
         T000G4_A250id_actividad = new int[1] ;
         T000G4_n250id_actividad = new bool[] {false} ;
         T000G4_A251detalle_tarea = new string[] {""} ;
         T000G4_n251detalle_tarea = new bool[] {false} ;
         T000G4_A252prioridad = new string[] {""} ;
         T000G4_n252prioridad = new bool[] {false} ;
         T000G4_A253observaciones = new string[] {""} ;
         T000G4_n253observaciones = new bool[] {false} ;
         T000G4_A254fecha_solicitud = new string[] {""} ;
         T000G4_n254fecha_solicitud = new bool[] {false} ;
         T000G4_A255fecha_ciere = new DateTime[] {DateTime.MinValue} ;
         T000G4_n255fecha_ciere = new bool[] {false} ;
         T000G4_A256hora_cierra = new DateTime[] {DateTime.MinValue} ;
         T000G4_n256hora_cierra = new bool[] {false} ;
         T000G5_A238correlativo = new int[1] ;
         T000G3_A238correlativo = new int[1] ;
         T000G3_A239nombre_emp = new string[] {""} ;
         T000G3_n239nombre_emp = new bool[] {false} ;
         T000G3_A240cargo_emp = new string[] {""} ;
         T000G3_n240cargo_emp = new bool[] {false} ;
         T000G3_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         T000G3_n241fecha_registro = new bool[] {false} ;
         T000G3_A242hora_registro = new DateTime[] {DateTime.MinValue} ;
         T000G3_n242hora_registro = new bool[] {false} ;
         T000G3_A243estatus = new string[] {""} ;
         T000G3_n243estatus = new bool[] {false} ;
         T000G3_A244trabajo = new string[] {""} ;
         T000G3_n244trabajo = new bool[] {false} ;
         T000G3_A245nombre_usuario = new string[] {""} ;
         T000G3_n245nombre_usuario = new bool[] {false} ;
         T000G3_A246depto_usuario = new string[] {""} ;
         T000G3_n246depto_usuario = new bool[] {false} ;
         T000G3_A247correo_usuario = new string[] {""} ;
         T000G3_n247correo_usuario = new bool[] {false} ;
         T000G3_A248detalle_infotecid_unidad = new int[1] ;
         T000G3_n248detalle_infotecid_unidad = new bool[] {false} ;
         T000G3_A249id_categoria = new int[1] ;
         T000G3_n249id_categoria = new bool[] {false} ;
         T000G3_A250id_actividad = new int[1] ;
         T000G3_n250id_actividad = new bool[] {false} ;
         T000G3_A251detalle_tarea = new string[] {""} ;
         T000G3_n251detalle_tarea = new bool[] {false} ;
         T000G3_A252prioridad = new string[] {""} ;
         T000G3_n252prioridad = new bool[] {false} ;
         T000G3_A253observaciones = new string[] {""} ;
         T000G3_n253observaciones = new bool[] {false} ;
         T000G3_A254fecha_solicitud = new string[] {""} ;
         T000G3_n254fecha_solicitud = new bool[] {false} ;
         T000G3_A255fecha_ciere = new DateTime[] {DateTime.MinValue} ;
         T000G3_n255fecha_ciere = new bool[] {false} ;
         T000G3_A256hora_cierra = new DateTime[] {DateTime.MinValue} ;
         T000G3_n256hora_cierra = new bool[] {false} ;
         sMode17 = "";
         T000G6_A238correlativo = new int[1] ;
         T000G7_A238correlativo = new int[1] ;
         T000G2_A238correlativo = new int[1] ;
         T000G2_A239nombre_emp = new string[] {""} ;
         T000G2_n239nombre_emp = new bool[] {false} ;
         T000G2_A240cargo_emp = new string[] {""} ;
         T000G2_n240cargo_emp = new bool[] {false} ;
         T000G2_A241fecha_registro = new DateTime[] {DateTime.MinValue} ;
         T000G2_n241fecha_registro = new bool[] {false} ;
         T000G2_A242hora_registro = new DateTime[] {DateTime.MinValue} ;
         T000G2_n242hora_registro = new bool[] {false} ;
         T000G2_A243estatus = new string[] {""} ;
         T000G2_n243estatus = new bool[] {false} ;
         T000G2_A244trabajo = new string[] {""} ;
         T000G2_n244trabajo = new bool[] {false} ;
         T000G2_A245nombre_usuario = new string[] {""} ;
         T000G2_n245nombre_usuario = new bool[] {false} ;
         T000G2_A246depto_usuario = new string[] {""} ;
         T000G2_n246depto_usuario = new bool[] {false} ;
         T000G2_A247correo_usuario = new string[] {""} ;
         T000G2_n247correo_usuario = new bool[] {false} ;
         T000G2_A248detalle_infotecid_unidad = new int[1] ;
         T000G2_n248detalle_infotecid_unidad = new bool[] {false} ;
         T000G2_A249id_categoria = new int[1] ;
         T000G2_n249id_categoria = new bool[] {false} ;
         T000G2_A250id_actividad = new int[1] ;
         T000G2_n250id_actividad = new bool[] {false} ;
         T000G2_A251detalle_tarea = new string[] {""} ;
         T000G2_n251detalle_tarea = new bool[] {false} ;
         T000G2_A252prioridad = new string[] {""} ;
         T000G2_n252prioridad = new bool[] {false} ;
         T000G2_A253observaciones = new string[] {""} ;
         T000G2_n253observaciones = new bool[] {false} ;
         T000G2_A254fecha_solicitud = new string[] {""} ;
         T000G2_n254fecha_solicitud = new bool[] {false} ;
         T000G2_A255fecha_ciere = new DateTime[] {DateTime.MinValue} ;
         T000G2_n255fecha_ciere = new bool[] {false} ;
         T000G2_A256hora_cierra = new DateTime[] {DateTime.MinValue} ;
         T000G2_n256hora_cierra = new bool[] {false} ;
         T000G8_A238correlativo = new int[1] ;
         T000G11_A238correlativo = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ239nombre_emp = "";
         ZZ240cargo_emp = "";
         ZZ241fecha_registro = DateTime.MinValue;
         ZZ242hora_registro = (DateTime)(DateTime.MinValue);
         ZZ243estatus = "";
         ZZ244trabajo = "";
         ZZ245nombre_usuario = "";
         ZZ246depto_usuario = "";
         ZZ247correo_usuario = "";
         ZZ251detalle_tarea = "";
         ZZ252prioridad = "";
         ZZ253observaciones = "";
         ZZ254fecha_solicitud = "";
         ZZ255fecha_ciere = DateTime.MinValue;
         ZZ256hora_cierra = (DateTime)(DateTime.MinValue);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.detalle_infotec__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.detalle_infotec__datastore1(),
            new Object[][] {
                new Object[] {
               T000G2_A238correlativo, T000G2_A239nombre_emp, T000G2_n239nombre_emp, T000G2_A240cargo_emp, T000G2_n240cargo_emp, T000G2_A241fecha_registro, T000G2_n241fecha_registro, T000G2_A242hora_registro, T000G2_n242hora_registro, T000G2_A243estatus,
               T000G2_n243estatus, T000G2_A244trabajo, T000G2_n244trabajo, T000G2_A245nombre_usuario, T000G2_n245nombre_usuario, T000G2_A246depto_usuario, T000G2_n246depto_usuario, T000G2_A247correo_usuario, T000G2_n247correo_usuario, T000G2_A248detalle_infotecid_unidad,
               T000G2_n248detalle_infotecid_unidad, T000G2_A249id_categoria, T000G2_n249id_categoria, T000G2_A250id_actividad, T000G2_n250id_actividad, T000G2_A251detalle_tarea, T000G2_n251detalle_tarea, T000G2_A252prioridad, T000G2_n252prioridad, T000G2_A253observaciones,
               T000G2_n253observaciones, T000G2_A254fecha_solicitud, T000G2_n254fecha_solicitud, T000G2_A255fecha_ciere, T000G2_n255fecha_ciere, T000G2_A256hora_cierra, T000G2_n256hora_cierra
               }
               , new Object[] {
               T000G3_A238correlativo, T000G3_A239nombre_emp, T000G3_n239nombre_emp, T000G3_A240cargo_emp, T000G3_n240cargo_emp, T000G3_A241fecha_registro, T000G3_n241fecha_registro, T000G3_A242hora_registro, T000G3_n242hora_registro, T000G3_A243estatus,
               T000G3_n243estatus, T000G3_A244trabajo, T000G3_n244trabajo, T000G3_A245nombre_usuario, T000G3_n245nombre_usuario, T000G3_A246depto_usuario, T000G3_n246depto_usuario, T000G3_A247correo_usuario, T000G3_n247correo_usuario, T000G3_A248detalle_infotecid_unidad,
               T000G3_n248detalle_infotecid_unidad, T000G3_A249id_categoria, T000G3_n249id_categoria, T000G3_A250id_actividad, T000G3_n250id_actividad, T000G3_A251detalle_tarea, T000G3_n251detalle_tarea, T000G3_A252prioridad, T000G3_n252prioridad, T000G3_A253observaciones,
               T000G3_n253observaciones, T000G3_A254fecha_solicitud, T000G3_n254fecha_solicitud, T000G3_A255fecha_ciere, T000G3_n255fecha_ciere, T000G3_A256hora_cierra, T000G3_n256hora_cierra
               }
               , new Object[] {
               T000G4_A238correlativo, T000G4_A239nombre_emp, T000G4_n239nombre_emp, T000G4_A240cargo_emp, T000G4_n240cargo_emp, T000G4_A241fecha_registro, T000G4_n241fecha_registro, T000G4_A242hora_registro, T000G4_n242hora_registro, T000G4_A243estatus,
               T000G4_n243estatus, T000G4_A244trabajo, T000G4_n244trabajo, T000G4_A245nombre_usuario, T000G4_n245nombre_usuario, T000G4_A246depto_usuario, T000G4_n246depto_usuario, T000G4_A247correo_usuario, T000G4_n247correo_usuario, T000G4_A248detalle_infotecid_unidad,
               T000G4_n248detalle_infotecid_unidad, T000G4_A249id_categoria, T000G4_n249id_categoria, T000G4_A250id_actividad, T000G4_n250id_actividad, T000G4_A251detalle_tarea, T000G4_n251detalle_tarea, T000G4_A252prioridad, T000G4_n252prioridad, T000G4_A253observaciones,
               T000G4_n253observaciones, T000G4_A254fecha_solicitud, T000G4_n254fecha_solicitud, T000G4_A255fecha_ciere, T000G4_n255fecha_ciere, T000G4_A256hora_cierra, T000G4_n256hora_cierra
               }
               , new Object[] {
               T000G5_A238correlativo
               }
               , new Object[] {
               T000G6_A238correlativo
               }
               , new Object[] {
               T000G7_A238correlativo
               }
               , new Object[] {
               T000G8_A238correlativo
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G11_A238correlativo
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.detalle_infotec__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.detalle_infotec__default(),
            new Object[][] {
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z238correlativo ;
      private int Z248detalle_infotecid_unidad ;
      private int Z249id_categoria ;
      private int Z250id_actividad ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A238correlativo ;
      private int edtcorrelativo_Enabled ;
      private int edtnombre_emp_Enabled ;
      private int edtcargo_emp_Enabled ;
      private int edtfecha_registro_Enabled ;
      private int edthora_registro_Enabled ;
      private int edtestatus_Enabled ;
      private int edttrabajo_Enabled ;
      private int edtnombre_usuario_Enabled ;
      private int edtdepto_usuario_Enabled ;
      private int edtcorreo_usuario_Enabled ;
      private int A248detalle_infotecid_unidad ;
      private int edtdetalle_infotecid_unidad_Enabled ;
      private int A249id_categoria ;
      private int edtid_categoria_Enabled ;
      private int A250id_actividad ;
      private int edtid_actividad_Enabled ;
      private int edtdetalle_tarea_Enabled ;
      private int edtprioridad_Enabled ;
      private int edtobservaciones_Enabled ;
      private int edtfecha_solicitud_Enabled ;
      private int edtfecha_ciere_Enabled ;
      private int edthora_cierra_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ238correlativo ;
      private int ZZ248detalle_infotecid_unidad ;
      private int ZZ249id_categoria ;
      private int ZZ250id_actividad ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtcorrelativo_Internalname ;
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
      private string edtcorrelativo_Jsonclick ;
      private string edtnombre_emp_Internalname ;
      private string edtcargo_emp_Internalname ;
      private string edtcargo_emp_Jsonclick ;
      private string edtfecha_registro_Internalname ;
      private string edtfecha_registro_Jsonclick ;
      private string edthora_registro_Internalname ;
      private string edthora_registro_Jsonclick ;
      private string edtestatus_Internalname ;
      private string edtestatus_Jsonclick ;
      private string edttrabajo_Internalname ;
      private string edtnombre_usuario_Internalname ;
      private string edtdepto_usuario_Internalname ;
      private string edtdepto_usuario_Jsonclick ;
      private string edtcorreo_usuario_Internalname ;
      private string edtdetalle_infotecid_unidad_Internalname ;
      private string edtdetalle_infotecid_unidad_Jsonclick ;
      private string edtid_categoria_Internalname ;
      private string edtid_categoria_Jsonclick ;
      private string edtid_actividad_Internalname ;
      private string edtid_actividad_Jsonclick ;
      private string edtdetalle_tarea_Internalname ;
      private string edtprioridad_Internalname ;
      private string edtprioridad_Jsonclick ;
      private string edtobservaciones_Internalname ;
      private string edtfecha_solicitud_Internalname ;
      private string edtfecha_ciere_Internalname ;
      private string edtfecha_ciere_Jsonclick ;
      private string edthora_cierra_Internalname ;
      private string edthora_cierra_Jsonclick ;
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
      private string sMode17 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z242hora_registro ;
      private DateTime Z256hora_cierra ;
      private DateTime A242hora_registro ;
      private DateTime A256hora_cierra ;
      private DateTime ZZ242hora_registro ;
      private DateTime ZZ256hora_cierra ;
      private DateTime Z241fecha_registro ;
      private DateTime Z255fecha_ciere ;
      private DateTime A241fecha_registro ;
      private DateTime A255fecha_ciere ;
      private DateTime ZZ241fecha_registro ;
      private DateTime ZZ255fecha_ciere ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n239nombre_emp ;
      private bool n240cargo_emp ;
      private bool n241fecha_registro ;
      private bool n242hora_registro ;
      private bool n243estatus ;
      private bool n244trabajo ;
      private bool n245nombre_usuario ;
      private bool n246depto_usuario ;
      private bool n247correo_usuario ;
      private bool n248detalle_infotecid_unidad ;
      private bool n249id_categoria ;
      private bool n250id_actividad ;
      private bool n251detalle_tarea ;
      private bool n252prioridad ;
      private bool n253observaciones ;
      private bool n254fecha_solicitud ;
      private bool n255fecha_ciere ;
      private bool n256hora_cierra ;
      private bool Gx_longc ;
      private string Z239nombre_emp ;
      private string Z240cargo_emp ;
      private string Z243estatus ;
      private string Z244trabajo ;
      private string Z245nombre_usuario ;
      private string Z246depto_usuario ;
      private string Z247correo_usuario ;
      private string Z251detalle_tarea ;
      private string Z252prioridad ;
      private string Z253observaciones ;
      private string Z254fecha_solicitud ;
      private string A239nombre_emp ;
      private string A240cargo_emp ;
      private string A243estatus ;
      private string A244trabajo ;
      private string A245nombre_usuario ;
      private string A246depto_usuario ;
      private string A247correo_usuario ;
      private string A251detalle_tarea ;
      private string A252prioridad ;
      private string A253observaciones ;
      private string A254fecha_solicitud ;
      private string ZZ239nombre_emp ;
      private string ZZ240cargo_emp ;
      private string ZZ243estatus ;
      private string ZZ244trabajo ;
      private string ZZ245nombre_usuario ;
      private string ZZ246depto_usuario ;
      private string ZZ247correo_usuario ;
      private string ZZ251detalle_tarea ;
      private string ZZ252prioridad ;
      private string ZZ253observaciones ;
      private string ZZ254fecha_solicitud ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] T000G4_A238correlativo ;
      private string[] T000G4_A239nombre_emp ;
      private bool[] T000G4_n239nombre_emp ;
      private string[] T000G4_A240cargo_emp ;
      private bool[] T000G4_n240cargo_emp ;
      private DateTime[] T000G4_A241fecha_registro ;
      private bool[] T000G4_n241fecha_registro ;
      private DateTime[] T000G4_A242hora_registro ;
      private bool[] T000G4_n242hora_registro ;
      private string[] T000G4_A243estatus ;
      private bool[] T000G4_n243estatus ;
      private string[] T000G4_A244trabajo ;
      private bool[] T000G4_n244trabajo ;
      private string[] T000G4_A245nombre_usuario ;
      private bool[] T000G4_n245nombre_usuario ;
      private string[] T000G4_A246depto_usuario ;
      private bool[] T000G4_n246depto_usuario ;
      private string[] T000G4_A247correo_usuario ;
      private bool[] T000G4_n247correo_usuario ;
      private int[] T000G4_A248detalle_infotecid_unidad ;
      private bool[] T000G4_n248detalle_infotecid_unidad ;
      private int[] T000G4_A249id_categoria ;
      private bool[] T000G4_n249id_categoria ;
      private int[] T000G4_A250id_actividad ;
      private bool[] T000G4_n250id_actividad ;
      private string[] T000G4_A251detalle_tarea ;
      private bool[] T000G4_n251detalle_tarea ;
      private string[] T000G4_A252prioridad ;
      private bool[] T000G4_n252prioridad ;
      private string[] T000G4_A253observaciones ;
      private bool[] T000G4_n253observaciones ;
      private string[] T000G4_A254fecha_solicitud ;
      private bool[] T000G4_n254fecha_solicitud ;
      private DateTime[] T000G4_A255fecha_ciere ;
      private bool[] T000G4_n255fecha_ciere ;
      private DateTime[] T000G4_A256hora_cierra ;
      private bool[] T000G4_n256hora_cierra ;
      private int[] T000G5_A238correlativo ;
      private int[] T000G3_A238correlativo ;
      private string[] T000G3_A239nombre_emp ;
      private bool[] T000G3_n239nombre_emp ;
      private string[] T000G3_A240cargo_emp ;
      private bool[] T000G3_n240cargo_emp ;
      private DateTime[] T000G3_A241fecha_registro ;
      private bool[] T000G3_n241fecha_registro ;
      private DateTime[] T000G3_A242hora_registro ;
      private bool[] T000G3_n242hora_registro ;
      private string[] T000G3_A243estatus ;
      private bool[] T000G3_n243estatus ;
      private string[] T000G3_A244trabajo ;
      private bool[] T000G3_n244trabajo ;
      private string[] T000G3_A245nombre_usuario ;
      private bool[] T000G3_n245nombre_usuario ;
      private string[] T000G3_A246depto_usuario ;
      private bool[] T000G3_n246depto_usuario ;
      private string[] T000G3_A247correo_usuario ;
      private bool[] T000G3_n247correo_usuario ;
      private int[] T000G3_A248detalle_infotecid_unidad ;
      private bool[] T000G3_n248detalle_infotecid_unidad ;
      private int[] T000G3_A249id_categoria ;
      private bool[] T000G3_n249id_categoria ;
      private int[] T000G3_A250id_actividad ;
      private bool[] T000G3_n250id_actividad ;
      private string[] T000G3_A251detalle_tarea ;
      private bool[] T000G3_n251detalle_tarea ;
      private string[] T000G3_A252prioridad ;
      private bool[] T000G3_n252prioridad ;
      private string[] T000G3_A253observaciones ;
      private bool[] T000G3_n253observaciones ;
      private string[] T000G3_A254fecha_solicitud ;
      private bool[] T000G3_n254fecha_solicitud ;
      private DateTime[] T000G3_A255fecha_ciere ;
      private bool[] T000G3_n255fecha_ciere ;
      private DateTime[] T000G3_A256hora_cierra ;
      private bool[] T000G3_n256hora_cierra ;
      private int[] T000G6_A238correlativo ;
      private int[] T000G7_A238correlativo ;
      private int[] T000G2_A238correlativo ;
      private string[] T000G2_A239nombre_emp ;
      private bool[] T000G2_n239nombre_emp ;
      private string[] T000G2_A240cargo_emp ;
      private bool[] T000G2_n240cargo_emp ;
      private DateTime[] T000G2_A241fecha_registro ;
      private bool[] T000G2_n241fecha_registro ;
      private DateTime[] T000G2_A242hora_registro ;
      private bool[] T000G2_n242hora_registro ;
      private string[] T000G2_A243estatus ;
      private bool[] T000G2_n243estatus ;
      private string[] T000G2_A244trabajo ;
      private bool[] T000G2_n244trabajo ;
      private string[] T000G2_A245nombre_usuario ;
      private bool[] T000G2_n245nombre_usuario ;
      private string[] T000G2_A246depto_usuario ;
      private bool[] T000G2_n246depto_usuario ;
      private string[] T000G2_A247correo_usuario ;
      private bool[] T000G2_n247correo_usuario ;
      private int[] T000G2_A248detalle_infotecid_unidad ;
      private bool[] T000G2_n248detalle_infotecid_unidad ;
      private int[] T000G2_A249id_categoria ;
      private bool[] T000G2_n249id_categoria ;
      private int[] T000G2_A250id_actividad ;
      private bool[] T000G2_n250id_actividad ;
      private string[] T000G2_A251detalle_tarea ;
      private bool[] T000G2_n251detalle_tarea ;
      private string[] T000G2_A252prioridad ;
      private bool[] T000G2_n252prioridad ;
      private string[] T000G2_A253observaciones ;
      private bool[] T000G2_n253observaciones ;
      private string[] T000G2_A254fecha_solicitud ;
      private bool[] T000G2_n254fecha_solicitud ;
      private DateTime[] T000G2_A255fecha_ciere ;
      private bool[] T000G2_n255fecha_ciere ;
      private DateTime[] T000G2_A256hora_cierra ;
      private bool[] T000G2_n256hora_cierra ;
      private int[] T000G8_A238correlativo ;
      private IDataStoreProvider pr_default ;
      private int[] T000G11_A238correlativo ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class detalle_infotec__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class detalle_infotec__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000G4;
        prmT000G4 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G5;
        prmT000G5 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G3;
        prmT000G3 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G6;
        prmT000G6 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G7;
        prmT000G7 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G2;
        prmT000G2 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G8;
        prmT000G8 = new Object[] {
        new ParDef("@nombre_emp",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@cargo_emp",GXType.NVarChar,60,0){Nullable=true} ,
        new ParDef("@fecha_registro",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@hora_registro",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@estatus",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@trabajo",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@nombre_usuario",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@depto_usuario",GXType.NVarChar,150,0){Nullable=true} ,
        new ParDef("@correo_usuario",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@detalle_infotecid_unidad",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@id_categoria",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@id_actividad",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@detalle_tarea",GXType.NVarChar,250,0){Nullable=true} ,
        new ParDef("@prioridad",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@observaciones",GXType.NVarChar,500,0){Nullable=true} ,
        new ParDef("@fecha_solicitud",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@fecha_ciere",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@hora_cierra",GXType.DateTime,8,5){Nullable=true}
        };
        Object[] prmT000G9;
        prmT000G9 = new Object[] {
        new ParDef("@nombre_emp",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@cargo_emp",GXType.NVarChar,60,0){Nullable=true} ,
        new ParDef("@fecha_registro",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@hora_registro",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@estatus",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@trabajo",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@nombre_usuario",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@depto_usuario",GXType.NVarChar,150,0){Nullable=true} ,
        new ParDef("@correo_usuario",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@detalle_infotecid_unidad",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@id_categoria",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@id_actividad",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@detalle_tarea",GXType.NVarChar,250,0){Nullable=true} ,
        new ParDef("@prioridad",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@observaciones",GXType.NVarChar,500,0){Nullable=true} ,
        new ParDef("@fecha_solicitud",GXType.NVarChar,300,0){Nullable=true} ,
        new ParDef("@fecha_ciere",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@hora_cierra",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G10;
        prmT000G10 = new Object[] {
        new ParDef("@correlativo",GXType.Int32,9,0)
        };
        Object[] prmT000G11;
        prmT000G11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000G2", "SELECT [correlativo], [nombre_emp], [cargo_emp], [fecha_registro], [hora_registro], [estatus], [trabajo], [nombre_usuario], [depto_usuario], [correo_usuario], [id_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud], [fecha_ciere], [hora_cierra] FROM dbo.[detalle_infotec] WITH (UPDLOCK) WHERE [correlativo] = @correlativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G3", "SELECT [correlativo], [nombre_emp], [cargo_emp], [fecha_registro], [hora_registro], [estatus], [trabajo], [nombre_usuario], [depto_usuario], [correo_usuario], [id_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud], [fecha_ciere], [hora_cierra] FROM dbo.[detalle_infotec] WHERE [correlativo] = @correlativo ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G4", "SELECT TM1.[correlativo], TM1.[nombre_emp], TM1.[cargo_emp], TM1.[fecha_registro], TM1.[hora_registro], TM1.[estatus], TM1.[trabajo], TM1.[nombre_usuario], TM1.[depto_usuario], TM1.[correo_usuario], TM1.[id_unidad], TM1.[id_categoria], TM1.[id_actividad], TM1.[detalle_tarea], TM1.[prioridad], TM1.[observaciones], TM1.[fecha_solicitud], TM1.[fecha_ciere], TM1.[hora_cierra] FROM dbo.[detalle_infotec] TM1 WHERE TM1.[correlativo] = @correlativo ORDER BY TM1.[correlativo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G5", "SELECT [correlativo] FROM dbo.[detalle_infotec] WHERE [correlativo] = @correlativo  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G6", "SELECT TOP 1 [correlativo] FROM dbo.[detalle_infotec] WHERE ( [correlativo] > @correlativo) ORDER BY [correlativo]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G7", "SELECT TOP 1 [correlativo] FROM dbo.[detalle_infotec] WHERE ( [correlativo] < @correlativo) ORDER BY [correlativo] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G8", "INSERT INTO dbo.[detalle_infotec]([nombre_emp], [cargo_emp], [fecha_registro], [hora_registro], [estatus], [trabajo], [nombre_usuario], [depto_usuario], [correo_usuario], [id_unidad], [id_categoria], [id_actividad], [detalle_tarea], [prioridad], [observaciones], [fecha_solicitud], [fecha_ciere], [hora_cierra]) VALUES(@nombre_emp, @cargo_emp, @fecha_registro, @hora_registro, @estatus, @trabajo, @nombre_usuario, @depto_usuario, @correo_usuario, @detalle_infotecid_unidad, @id_categoria, @id_actividad, @detalle_tarea, @prioridad, @observaciones, @fecha_solicitud, @fecha_ciere, @hora_cierra); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000G8)
           ,new CursorDef("T000G9", "UPDATE dbo.[detalle_infotec] SET [nombre_emp]=@nombre_emp, [cargo_emp]=@cargo_emp, [fecha_registro]=@fecha_registro, [hora_registro]=@hora_registro, [estatus]=@estatus, [trabajo]=@trabajo, [nombre_usuario]=@nombre_usuario, [depto_usuario]=@depto_usuario, [correo_usuario]=@correo_usuario, [id_unidad]=@detalle_infotecid_unidad, [id_categoria]=@id_categoria, [id_actividad]=@id_actividad, [detalle_tarea]=@detalle_tarea, [prioridad]=@prioridad, [observaciones]=@observaciones, [fecha_solicitud]=@fecha_solicitud, [fecha_ciere]=@fecha_ciere, [hora_cierra]=@hora_cierra  WHERE [correlativo] = @correlativo", GxErrorMask.GX_NOMASK,prmT000G9)
           ,new CursorDef("T000G10", "DELETE FROM dbo.[detalle_infotec]  WHERE [correlativo] = @correlativo", GxErrorMask.GX_NOMASK,prmT000G10)
           ,new CursorDef("T000G11", "SELECT [correlativo] FROM dbo.[detalle_infotec] ORDER BY [correlativo]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getVarchar(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getVarchar(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((string[]) buf[25])[0] = rslt.getVarchar(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((string[]) buf[31])[0] = rslt.getVarchar(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getVarchar(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getVarchar(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((string[]) buf[25])[0] = rslt.getVarchar(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((string[]) buf[31])[0] = rslt.getVarchar(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getVarchar(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((string[]) buf[17])[0] = rslt.getVarchar(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((string[]) buf[25])[0] = rslt.getVarchar(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((string[]) buf[27])[0] = rslt.getVarchar(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((string[]) buf[29])[0] = rslt.getVarchar(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((string[]) buf[31])[0] = rslt.getVarchar(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class detalle_infotec__gam : DataStoreHelperBase, IDataStoreHelper
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

public class detalle_infotec__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
