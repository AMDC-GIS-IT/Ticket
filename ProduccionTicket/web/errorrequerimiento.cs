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
   public class errorrequerimiento : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A369ListaRequerimientosId = (short)(NumberUtil.Val( GetPar( "ListaRequerimientosId"), "."));
            AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A369ListaRequerimientosId) ;
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
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Error Requerimiento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtErrorRequerimientoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public errorrequerimiento( )
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

      public errorrequerimiento( IGxContext context )
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
            return "errorrequerimiento_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Error Requerimiento", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ErrorRequerimiento.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00r0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ERRORREQUERIMIENTOID"+"'), id:'"+"ERRORREQUERIMIENTOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_ErrorRequerimiento.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtErrorRequerimientoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtErrorRequerimientoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A372ErrorRequerimientoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtErrorRequerimientoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A372ErrorRequerimientoId), "ZZZ9") : context.localUtil.Format( (decimal)(A372ErrorRequerimientoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtErrorRequerimientoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtErrorRequerimientoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtErrorRequerimientoDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtErrorRequerimientoDescripcion_Internalname, "Descripción:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtErrorRequerimientoDescripcion_Internalname, A373ErrorRequerimientoDescripcion, StringUtil.RTrim( context.localUtil.Format( A373ErrorRequerimientoDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtErrorRequerimientoDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtErrorRequerimientoDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "TextoCorto", "left", true, "", "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtListaRequerimientosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaRequerimientosId_Internalname, "Id: ", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaRequerimientosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")), StringUtil.LTrim( ((edtListaRequerimientosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9") : context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaRequerimientosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListaRequerimientosId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_ErrorRequerimiento.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_369_Internalname, sImgUrl, imgprompt_369_Link, "", "", context.GetTheme( ), imgprompt_369_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtListaRequerimientosDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaRequerimientosDescripcion_Internalname, "Descripción:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtListaRequerimientosDescripcion_Internalname, A370ListaRequerimientosDescripcion, StringUtil.RTrim( context.localUtil.Format( A370ListaRequerimientosDescripcion, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaRequerimientosDescripcion_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtListaRequerimientosDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "TextoCorto", "left", true, "", "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtErrorRequerimientoUsuarioSistema_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtErrorRequerimientoUsuarioSistema_Internalname, "Registro:", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtErrorRequerimientoUsuarioSistema_Internalname, A374ErrorRequerimientoUsuarioSistema, StringUtil.RTrim( context.localUtil.Format( A374ErrorRequerimientoUsuarioSistema, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtErrorRequerimientoUsuarioSistema_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtErrorRequerimientoUsuarioSistema_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_ErrorRequerimiento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ErrorRequerimiento.htm");
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
            Z372ErrorRequerimientoId = (short)(context.localUtil.CToN( cgiGet( "Z372ErrorRequerimientoId"), ".", ","));
            Z373ErrorRequerimientoDescripcion = cgiGet( "Z373ErrorRequerimientoDescripcion");
            Z374ErrorRequerimientoUsuarioSistema = cgiGet( "Z374ErrorRequerimientoUsuarioSistema");
            Z369ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( "Z369ListaRequerimientosId"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtErrorRequerimientoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtErrorRequerimientoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ERRORREQUERIMIENTOID");
               AnyError = 1;
               GX_FocusControl = edtErrorRequerimientoId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A372ErrorRequerimientoId = 0;
               AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
            }
            else
            {
               A372ErrorRequerimientoId = (short)(context.localUtil.CToN( cgiGet( edtErrorRequerimientoId_Internalname), ".", ","));
               AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
            }
            A373ErrorRequerimientoDescripcion = cgiGet( edtErrorRequerimientoDescripcion_Internalname);
            AssignAttri("", false, "A373ErrorRequerimientoDescripcion", A373ErrorRequerimientoDescripcion);
            if ( ( ( context.localUtil.CToN( cgiGet( edtListaRequerimientosId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtListaRequerimientosId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LISTAREQUERIMIENTOSID");
               AnyError = 1;
               GX_FocusControl = edtListaRequerimientosId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A369ListaRequerimientosId = 0;
               AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            }
            else
            {
               A369ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( edtListaRequerimientosId_Internalname), ".", ","));
               AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            }
            A370ListaRequerimientosDescripcion = cgiGet( edtListaRequerimientosDescripcion_Internalname);
            AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
            A374ErrorRequerimientoUsuarioSistema = cgiGet( edtErrorRequerimientoUsuarioSistema_Internalname);
            AssignAttri("", false, "A374ErrorRequerimientoUsuarioSistema", A374ErrorRequerimientoUsuarioSistema);
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
               A372ErrorRequerimientoId = (short)(NumberUtil.Val( GetPar( "ErrorRequerimientoId"), "."));
               AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
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
               InitAll0Q27( ) ;
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
         DisableAttributes0Q27( ) ;
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

      protected void ResetCaption0Q0( )
      {
      }

      protected void ZM0Q27( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z373ErrorRequerimientoDescripcion = T000Q3_A373ErrorRequerimientoDescripcion[0];
               Z374ErrorRequerimientoUsuarioSistema = T000Q3_A374ErrorRequerimientoUsuarioSistema[0];
               Z369ListaRequerimientosId = T000Q3_A369ListaRequerimientosId[0];
            }
            else
            {
               Z373ErrorRequerimientoDescripcion = A373ErrorRequerimientoDescripcion;
               Z374ErrorRequerimientoUsuarioSistema = A374ErrorRequerimientoUsuarioSistema;
               Z369ListaRequerimientosId = A369ListaRequerimientosId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z372ErrorRequerimientoId = A372ErrorRequerimientoId;
            Z373ErrorRequerimientoDescripcion = A373ErrorRequerimientoDescripcion;
            Z374ErrorRequerimientoUsuarioSistema = A374ErrorRequerimientoUsuarioSistema;
            Z369ListaRequerimientosId = A369ListaRequerimientosId;
            Z370ListaRequerimientosDescripcion = A370ListaRequerimientosDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_369_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00q0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"LISTAREQUERIMIENTOSID"+"'), id:'"+"LISTAREQUERIMIENTOSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
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

      protected void Load0Q27( )
      {
         /* Using cursor T000Q5 */
         pr_default.execute(3, new Object[] {A372ErrorRequerimientoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
            A373ErrorRequerimientoDescripcion = T000Q5_A373ErrorRequerimientoDescripcion[0];
            AssignAttri("", false, "A373ErrorRequerimientoDescripcion", A373ErrorRequerimientoDescripcion);
            A370ListaRequerimientosDescripcion = T000Q5_A370ListaRequerimientosDescripcion[0];
            AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
            A374ErrorRequerimientoUsuarioSistema = T000Q5_A374ErrorRequerimientoUsuarioSistema[0];
            AssignAttri("", false, "A374ErrorRequerimientoUsuarioSistema", A374ErrorRequerimientoUsuarioSistema);
            A369ListaRequerimientosId = T000Q5_A369ListaRequerimientosId[0];
            AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            ZM0Q27( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0Q27( ) ;
      }

      protected void OnLoadActions0Q27( )
      {
      }

      protected void CheckExtendedTable0Q27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000Q4 */
         pr_default.execute(2, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista requerimientos'.", "ForeignKeyNotFound", 1, "LISTAREQUERIMIENTOSID");
            AnyError = 1;
            GX_FocusControl = edtListaRequerimientosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A370ListaRequerimientosDescripcion = T000Q4_A370ListaRequerimientosDescripcion[0];
         AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0Q27( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A369ListaRequerimientosId )
      {
         /* Using cursor T000Q6 */
         pr_default.execute(4, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista requerimientos'.", "ForeignKeyNotFound", 1, "LISTAREQUERIMIENTOSID");
            AnyError = 1;
            GX_FocusControl = edtListaRequerimientosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A370ListaRequerimientosDescripcion = T000Q6_A370ListaRequerimientosDescripcion[0];
         AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A370ListaRequerimientosDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0Q27( )
      {
         /* Using cursor T000Q7 */
         pr_default.execute(5, new Object[] {A372ErrorRequerimientoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Q3 */
         pr_default.execute(1, new Object[] {A372ErrorRequerimientoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q27( 1) ;
            RcdFound27 = 1;
            A372ErrorRequerimientoId = T000Q3_A372ErrorRequerimientoId[0];
            AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
            A373ErrorRequerimientoDescripcion = T000Q3_A373ErrorRequerimientoDescripcion[0];
            AssignAttri("", false, "A373ErrorRequerimientoDescripcion", A373ErrorRequerimientoDescripcion);
            A374ErrorRequerimientoUsuarioSistema = T000Q3_A374ErrorRequerimientoUsuarioSistema[0];
            AssignAttri("", false, "A374ErrorRequerimientoUsuarioSistema", A374ErrorRequerimientoUsuarioSistema);
            A369ListaRequerimientosId = T000Q3_A369ListaRequerimientosId[0];
            AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            Z372ErrorRequerimientoId = A372ErrorRequerimientoId;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Q27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0Q27( ) ;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0Q27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q27( ) ;
         if ( RcdFound27 == 0 )
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
         RcdFound27 = 0;
         /* Using cursor T000Q8 */
         pr_default.execute(6, new Object[] {A372ErrorRequerimientoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000Q8_A372ErrorRequerimientoId[0] < A372ErrorRequerimientoId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000Q8_A372ErrorRequerimientoId[0] > A372ErrorRequerimientoId ) ) )
            {
               A372ErrorRequerimientoId = T000Q8_A372ErrorRequerimientoId[0];
               AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound27 = 0;
         /* Using cursor T000Q9 */
         pr_default.execute(7, new Object[] {A372ErrorRequerimientoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000Q9_A372ErrorRequerimientoId[0] > A372ErrorRequerimientoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000Q9_A372ErrorRequerimientoId[0] < A372ErrorRequerimientoId ) ) )
            {
               A372ErrorRequerimientoId = T000Q9_A372ErrorRequerimientoId[0];
               AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Q27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtErrorRequerimientoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Q27( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A372ErrorRequerimientoId != Z372ErrorRequerimientoId )
               {
                  A372ErrorRequerimientoId = Z372ErrorRequerimientoId;
                  AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ERRORREQUERIMIENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtErrorRequerimientoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtErrorRequerimientoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0Q27( ) ;
                  GX_FocusControl = edtErrorRequerimientoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A372ErrorRequerimientoId != Z372ErrorRequerimientoId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtErrorRequerimientoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Q27( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ERRORREQUERIMIENTOID");
                     AnyError = 1;
                     GX_FocusControl = edtErrorRequerimientoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtErrorRequerimientoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Q27( ) ;
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
         if ( A372ErrorRequerimientoId != Z372ErrorRequerimientoId )
         {
            A372ErrorRequerimientoId = Z372ErrorRequerimientoId;
            AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ERRORREQUERIMIENTOID");
            AnyError = 1;
            GX_FocusControl = edtErrorRequerimientoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtErrorRequerimientoId_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ERRORREQUERIMIENTOID");
            AnyError = 1;
            GX_FocusControl = edtErrorRequerimientoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtErrorRequerimientoDescripcion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Q27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtErrorRequerimientoDescripcion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Q27( ) ;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtErrorRequerimientoDescripcion_Internalname;
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
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtErrorRequerimientoDescripcion_Internalname;
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
         ScanStart0Q27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound27 != 0 )
            {
               ScanNext0Q27( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtErrorRequerimientoDescripcion_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Q27( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Q27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Q2 */
            pr_default.execute(0, new Object[] {A372ErrorRequerimientoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ErrorRequerimiento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z373ErrorRequerimientoDescripcion, T000Q2_A373ErrorRequerimientoDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z374ErrorRequerimientoUsuarioSistema, T000Q2_A374ErrorRequerimientoUsuarioSistema[0]) != 0 ) || ( Z369ListaRequerimientosId != T000Q2_A369ListaRequerimientosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z373ErrorRequerimientoDescripcion, T000Q2_A373ErrorRequerimientoDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("errorrequerimiento:[seudo value changed for attri]"+"ErrorRequerimientoDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z373ErrorRequerimientoDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A373ErrorRequerimientoDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z374ErrorRequerimientoUsuarioSistema, T000Q2_A374ErrorRequerimientoUsuarioSistema[0]) != 0 )
               {
                  GXUtil.WriteLog("errorrequerimiento:[seudo value changed for attri]"+"ErrorRequerimientoUsuarioSistema");
                  GXUtil.WriteLogRaw("Old: ",Z374ErrorRequerimientoUsuarioSistema);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A374ErrorRequerimientoUsuarioSistema[0]);
               }
               if ( Z369ListaRequerimientosId != T000Q2_A369ListaRequerimientosId[0] )
               {
                  GXUtil.WriteLog("errorrequerimiento:[seudo value changed for attri]"+"ListaRequerimientosId");
                  GXUtil.WriteLogRaw("Old: ",Z369ListaRequerimientosId);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A369ListaRequerimientosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ErrorRequerimiento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q27( )
      {
         if ( ! IsAuthorized("errorrequerimiento_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Q27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q27( 0) ;
            CheckOptimisticConcurrency0Q27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q10 */
                     pr_default.execute(8, new Object[] {A373ErrorRequerimientoDescripcion, A374ErrorRequerimientoUsuarioSistema, A369ListaRequerimientosId});
                     A372ErrorRequerimientoId = T000Q10_A372ErrorRequerimientoId[0];
                     AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ErrorRequerimiento");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0Q0( ) ;
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
               Load0Q27( ) ;
            }
            EndLevel0Q27( ) ;
         }
         CloseExtendedTableCursors0Q27( ) ;
      }

      protected void Update0Q27( )
      {
         if ( ! IsAuthorized("errorrequerimiento_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Q27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q11 */
                     pr_default.execute(9, new Object[] {A373ErrorRequerimientoDescripcion, A374ErrorRequerimientoUsuarioSistema, A369ListaRequerimientosId, A372ErrorRequerimientoId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ErrorRequerimiento");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ErrorRequerimiento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q27( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Q0( ) ;
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
            EndLevel0Q27( ) ;
         }
         CloseExtendedTableCursors0Q27( ) ;
      }

      protected void DeferredUpdate0Q27( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("errorrequerimiento_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Q27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q27( ) ;
            AfterConfirm0Q27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Q12 */
                  pr_default.execute(10, new Object[] {A372ErrorRequerimientoId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ErrorRequerimiento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound27 == 0 )
                        {
                           InitAll0Q27( ) ;
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
                        ResetCaption0Q0( ) ;
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Q27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Q27( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000Q13 */
            pr_default.execute(11, new Object[] {A369ListaRequerimientosId});
            A370ListaRequerimientosDescripcion = T000Q13_A370ListaRequerimientosDescripcion[0];
            AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
            pr_default.close(11);
         }
      }

      protected void EndLevel0Q27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q27( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("errorrequerimiento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("errorrequerimiento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Q27( )
      {
         /* Using cursor T000Q14 */
         pr_default.execute(12);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound27 = 1;
            A372ErrorRequerimientoId = T000Q14_A372ErrorRequerimientoId[0];
            AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Q27( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound27 = 1;
            A372ErrorRequerimientoId = T000Q14_A372ErrorRequerimientoId[0];
            AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
         }
      }

      protected void ScanEnd0Q27( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0Q27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q27( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q27( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q27( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q27( )
      {
         edtErrorRequerimientoId_Enabled = 0;
         AssignProp("", false, edtErrorRequerimientoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtErrorRequerimientoId_Enabled), 5, 0), true);
         edtErrorRequerimientoDescripcion_Enabled = 0;
         AssignProp("", false, edtErrorRequerimientoDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtErrorRequerimientoDescripcion_Enabled), 5, 0), true);
         edtListaRequerimientosId_Enabled = 0;
         AssignProp("", false, edtListaRequerimientosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Enabled), 5, 0), true);
         edtListaRequerimientosDescripcion_Enabled = 0;
         AssignProp("", false, edtListaRequerimientosDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Enabled), 5, 0), true);
         edtErrorRequerimientoUsuarioSistema_Enabled = 0;
         AssignProp("", false, edtErrorRequerimientoUsuarioSistema_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtErrorRequerimientoUsuarioSistema_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Q27( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Q0( )
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 184460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2024188355786", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("errorrequerimiento.aspx") +"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z372ErrorRequerimientoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372ErrorRequerimientoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z373ErrorRequerimientoDescripcion", Z373ErrorRequerimientoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z374ErrorRequerimientoUsuarioSistema", Z374ErrorRequerimientoUsuarioSistema);
         GxWebStd.gx_hidden_field( context, "Z369ListaRequerimientosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z369ListaRequerimientosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
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
         return formatLink("errorrequerimiento.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ErrorRequerimiento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Error Requerimiento" ;
      }

      protected void InitializeNonKey0Q27( )
      {
         A373ErrorRequerimientoDescripcion = "";
         AssignAttri("", false, "A373ErrorRequerimientoDescripcion", A373ErrorRequerimientoDescripcion);
         A369ListaRequerimientosId = 0;
         AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
         A370ListaRequerimientosDescripcion = "";
         AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
         A374ErrorRequerimientoUsuarioSistema = "";
         AssignAttri("", false, "A374ErrorRequerimientoUsuarioSistema", A374ErrorRequerimientoUsuarioSistema);
         Z373ErrorRequerimientoDescripcion = "";
         Z374ErrorRequerimientoUsuarioSistema = "";
         Z369ListaRequerimientosId = 0;
      }

      protected void InitAll0Q27( )
      {
         A372ErrorRequerimientoId = 0;
         AssignAttri("", false, "A372ErrorRequerimientoId", StringUtil.LTrimStr( (decimal)(A372ErrorRequerimientoId), 4, 0));
         InitializeNonKey0Q27( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188355790", true, true);
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
         context.AddJavascriptSource("errorrequerimiento.js", "?2024188355790", false, true);
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
         edtErrorRequerimientoId_Internalname = "ERRORREQUERIMIENTOID";
         edtErrorRequerimientoDescripcion_Internalname = "ERRORREQUERIMIENTODESCRIPCION";
         edtListaRequerimientosId_Internalname = "LISTAREQUERIMIENTOSID";
         edtListaRequerimientosDescripcion_Internalname = "LISTAREQUERIMIENTOSDESCRIPCION";
         edtErrorRequerimientoUsuarioSistema_Internalname = "ERRORREQUERIMIENTOUSUARIOSISTEMA";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_369_Internalname = "PROMPT_369";
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
         Form.Caption = "Error Requerimiento";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtErrorRequerimientoUsuarioSistema_Jsonclick = "";
         edtErrorRequerimientoUsuarioSistema_Enabled = 1;
         edtListaRequerimientosDescripcion_Jsonclick = "";
         edtListaRequerimientosDescripcion_Enabled = 0;
         imgprompt_369_Visible = 1;
         imgprompt_369_Link = "";
         edtListaRequerimientosId_Jsonclick = "";
         edtListaRequerimientosId_Enabled = 1;
         edtErrorRequerimientoDescripcion_Jsonclick = "";
         edtErrorRequerimientoDescripcion_Enabled = 1;
         edtErrorRequerimientoId_Jsonclick = "";
         edtErrorRequerimientoId_Enabled = 1;
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
         GX_FocusControl = edtErrorRequerimientoDescripcion_Internalname;
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

      public void Valid_Errorrequerimientoid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A373ErrorRequerimientoDescripcion", A373ErrorRequerimientoDescripcion);
         AssignAttri("", false, "A369ListaRequerimientosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")));
         AssignAttri("", false, "A374ErrorRequerimientoUsuarioSistema", A374ErrorRequerimientoUsuarioSistema);
         AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z372ErrorRequerimientoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372ErrorRequerimientoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z373ErrorRequerimientoDescripcion", Z373ErrorRequerimientoDescripcion);
         GxWebStd.gx_hidden_field( context, "Z369ListaRequerimientosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z369ListaRequerimientosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z374ErrorRequerimientoUsuarioSistema", Z374ErrorRequerimientoUsuarioSistema);
         GxWebStd.gx_hidden_field( context, "Z370ListaRequerimientosDescripcion", Z370ListaRequerimientosDescripcion);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Listarequerimientosid( )
      {
         /* Using cursor T000Q13 */
         pr_default.execute(11, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista requerimientos'.", "ForeignKeyNotFound", 1, "LISTAREQUERIMIENTOSID");
            AnyError = 1;
            GX_FocusControl = edtListaRequerimientosId_Internalname;
         }
         A370ListaRequerimientosDescripcion = T000Q13_A370ListaRequerimientosDescripcion[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
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
         setEventMetadata("VALID_ERRORREQUERIMIENTOID","{handler:'Valid_Errorrequerimientoid',iparms:[{av:'A372ErrorRequerimientoId',fld:'ERRORREQUERIMIENTOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ERRORREQUERIMIENTOID",",oparms:[{av:'A373ErrorRequerimientoDescripcion',fld:'ERRORREQUERIMIENTODESCRIPCION',pic:''},{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9'},{av:'A374ErrorRequerimientoUsuarioSistema',fld:'ERRORREQUERIMIENTOUSUARIOSISTEMA',pic:''},{av:'A370ListaRequerimientosDescripcion',fld:'LISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z372ErrorRequerimientoId'},{av:'Z373ErrorRequerimientoDescripcion'},{av:'Z369ListaRequerimientosId'},{av:'Z374ErrorRequerimientoUsuarioSistema'},{av:'Z370ListaRequerimientosDescripcion'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_LISTAREQUERIMIENTOSID","{handler:'Valid_Listarequerimientosid',iparms:[{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9'},{av:'A370ListaRequerimientosDescripcion',fld:'LISTAREQUERIMIENTOSDESCRIPCION',pic:''}]");
         setEventMetadata("VALID_LISTAREQUERIMIENTOSID",",oparms:[{av:'A370ListaRequerimientosDescripcion',fld:'LISTAREQUERIMIENTOSDESCRIPCION',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z373ErrorRequerimientoDescripcion = "";
         Z374ErrorRequerimientoUsuarioSistema = "";
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
         A373ErrorRequerimientoDescripcion = "";
         sImgUrl = "";
         A370ListaRequerimientosDescripcion = "";
         A374ErrorRequerimientoUsuarioSistema = "";
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
         Z370ListaRequerimientosDescripcion = "";
         T000Q5_A372ErrorRequerimientoId = new short[1] ;
         T000Q5_A373ErrorRequerimientoDescripcion = new string[] {""} ;
         T000Q5_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000Q5_A374ErrorRequerimientoUsuarioSistema = new string[] {""} ;
         T000Q5_A369ListaRequerimientosId = new short[1] ;
         T000Q4_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000Q6_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000Q7_A372ErrorRequerimientoId = new short[1] ;
         T000Q3_A372ErrorRequerimientoId = new short[1] ;
         T000Q3_A373ErrorRequerimientoDescripcion = new string[] {""} ;
         T000Q3_A374ErrorRequerimientoUsuarioSistema = new string[] {""} ;
         T000Q3_A369ListaRequerimientosId = new short[1] ;
         sMode27 = "";
         T000Q8_A372ErrorRequerimientoId = new short[1] ;
         T000Q9_A372ErrorRequerimientoId = new short[1] ;
         T000Q2_A372ErrorRequerimientoId = new short[1] ;
         T000Q2_A373ErrorRequerimientoDescripcion = new string[] {""} ;
         T000Q2_A374ErrorRequerimientoUsuarioSistema = new string[] {""} ;
         T000Q2_A369ListaRequerimientosId = new short[1] ;
         T000Q10_A372ErrorRequerimientoId = new short[1] ;
         T000Q13_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000Q14_A372ErrorRequerimientoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ373ErrorRequerimientoDescripcion = "";
         ZZ374ErrorRequerimientoUsuarioSistema = "";
         ZZ370ListaRequerimientosDescripcion = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.errorrequerimiento__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.errorrequerimiento__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.errorrequerimiento__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.errorrequerimiento__default(),
            new Object[][] {
                new Object[] {
               T000Q2_A372ErrorRequerimientoId, T000Q2_A373ErrorRequerimientoDescripcion, T000Q2_A374ErrorRequerimientoUsuarioSistema, T000Q2_A369ListaRequerimientosId
               }
               , new Object[] {
               T000Q3_A372ErrorRequerimientoId, T000Q3_A373ErrorRequerimientoDescripcion, T000Q3_A374ErrorRequerimientoUsuarioSistema, T000Q3_A369ListaRequerimientosId
               }
               , new Object[] {
               T000Q4_A370ListaRequerimientosDescripcion
               }
               , new Object[] {
               T000Q5_A372ErrorRequerimientoId, T000Q5_A373ErrorRequerimientoDescripcion, T000Q5_A370ListaRequerimientosDescripcion, T000Q5_A374ErrorRequerimientoUsuarioSistema, T000Q5_A369ListaRequerimientosId
               }
               , new Object[] {
               T000Q6_A370ListaRequerimientosDescripcion
               }
               , new Object[] {
               T000Q7_A372ErrorRequerimientoId
               }
               , new Object[] {
               T000Q8_A372ErrorRequerimientoId
               }
               , new Object[] {
               T000Q9_A372ErrorRequerimientoId
               }
               , new Object[] {
               T000Q10_A372ErrorRequerimientoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q13_A370ListaRequerimientosDescripcion
               }
               , new Object[] {
               T000Q14_A372ErrorRequerimientoId
               }
            }
         );
      }

      private short Z372ErrorRequerimientoId ;
      private short Z369ListaRequerimientosId ;
      private short GxWebError ;
      private short A369ListaRequerimientosId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A372ErrorRequerimientoId ;
      private short GX_JID ;
      private short RcdFound27 ;
      private short nIsDirty_27 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ372ErrorRequerimientoId ;
      private short ZZ369ListaRequerimientosId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtErrorRequerimientoId_Enabled ;
      private int edtErrorRequerimientoDescripcion_Enabled ;
      private int edtListaRequerimientosId_Enabled ;
      private int imgprompt_369_Visible ;
      private int edtListaRequerimientosDescripcion_Enabled ;
      private int edtErrorRequerimientoUsuarioSistema_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtErrorRequerimientoId_Internalname ;
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
      private string edtErrorRequerimientoId_Jsonclick ;
      private string edtErrorRequerimientoDescripcion_Internalname ;
      private string edtErrorRequerimientoDescripcion_Jsonclick ;
      private string edtListaRequerimientosId_Internalname ;
      private string edtListaRequerimientosId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_369_Internalname ;
      private string imgprompt_369_Link ;
      private string edtListaRequerimientosDescripcion_Internalname ;
      private string edtListaRequerimientosDescripcion_Jsonclick ;
      private string edtErrorRequerimientoUsuarioSistema_Internalname ;
      private string edtErrorRequerimientoUsuarioSistema_Jsonclick ;
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
      private string sMode27 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z373ErrorRequerimientoDescripcion ;
      private string Z374ErrorRequerimientoUsuarioSistema ;
      private string A373ErrorRequerimientoDescripcion ;
      private string A370ListaRequerimientosDescripcion ;
      private string A374ErrorRequerimientoUsuarioSistema ;
      private string Z370ListaRequerimientosDescripcion ;
      private string ZZ373ErrorRequerimientoDescripcion ;
      private string ZZ374ErrorRequerimientoUsuarioSistema ;
      private string ZZ370ListaRequerimientosDescripcion ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000Q5_A372ErrorRequerimientoId ;
      private string[] T000Q5_A373ErrorRequerimientoDescripcion ;
      private string[] T000Q5_A370ListaRequerimientosDescripcion ;
      private string[] T000Q5_A374ErrorRequerimientoUsuarioSistema ;
      private short[] T000Q5_A369ListaRequerimientosId ;
      private string[] T000Q4_A370ListaRequerimientosDescripcion ;
      private string[] T000Q6_A370ListaRequerimientosDescripcion ;
      private short[] T000Q7_A372ErrorRequerimientoId ;
      private short[] T000Q3_A372ErrorRequerimientoId ;
      private string[] T000Q3_A373ErrorRequerimientoDescripcion ;
      private string[] T000Q3_A374ErrorRequerimientoUsuarioSistema ;
      private short[] T000Q3_A369ListaRequerimientosId ;
      private short[] T000Q8_A372ErrorRequerimientoId ;
      private short[] T000Q9_A372ErrorRequerimientoId ;
      private short[] T000Q2_A372ErrorRequerimientoId ;
      private string[] T000Q2_A373ErrorRequerimientoDescripcion ;
      private string[] T000Q2_A374ErrorRequerimientoUsuarioSistema ;
      private short[] T000Q2_A369ListaRequerimientosId ;
      private short[] T000Q10_A372ErrorRequerimientoId ;
      private string[] T000Q13_A370ListaRequerimientosDescripcion ;
      private short[] T000Q14_A372ErrorRequerimientoId ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class errorrequerimiento__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class errorrequerimiento__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class errorrequerimiento__gam : DataStoreHelperBase, IDataStoreHelper
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

public class errorrequerimiento__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000Q5;
       prmT000Q5 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q4;
       prmT000Q4 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000Q6;
       prmT000Q6 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000Q7;
       prmT000Q7 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q3;
       prmT000Q3 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q8;
       prmT000Q8 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q9;
       prmT000Q9 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q2;
       prmT000Q2 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q10;
       prmT000Q10 = new Object[] {
       new ParDef("@ErrorRequerimientoDescripcion",GXType.NVarChar,100,0) ,
       new ParDef("@ErrorRequerimientoUsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000Q11;
       prmT000Q11 = new Object[] {
       new ParDef("@ErrorRequerimientoDescripcion",GXType.NVarChar,100,0) ,
       new ParDef("@ErrorRequerimientoUsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0) ,
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q12;
       prmT000Q12 = new Object[] {
       new ParDef("@ErrorRequerimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000Q14;
       prmT000Q14 = new Object[] {
       };
       Object[] prmT000Q13;
       prmT000Q13 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000Q2", "SELECT [ErrorRequerimientoId], [ErrorRequerimientoDescripcion], [ErrorRequerimientoUsuarioSistema], [ListaRequerimientosId] FROM [ErrorRequerimiento] WITH (UPDLOCK) WHERE [ErrorRequerimientoId] = @ErrorRequerimientoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q3", "SELECT [ErrorRequerimientoId], [ErrorRequerimientoDescripcion], [ErrorRequerimientoUsuarioSistema], [ListaRequerimientosId] FROM [ErrorRequerimiento] WHERE [ErrorRequerimientoId] = @ErrorRequerimientoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q4", "SELECT [ListaRequerimientosDescripcion] FROM [ListaRequerimientos] WHERE [ListaRequerimientosId] = @ListaRequerimientosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q5", "SELECT TM1.[ErrorRequerimientoId], TM1.[ErrorRequerimientoDescripcion], T2.[ListaRequerimientosDescripcion], TM1.[ErrorRequerimientoUsuarioSistema], TM1.[ListaRequerimientosId] FROM ([ErrorRequerimiento] TM1 INNER JOIN [ListaRequerimientos] T2 ON T2.[ListaRequerimientosId] = TM1.[ListaRequerimientosId]) WHERE TM1.[ErrorRequerimientoId] = @ErrorRequerimientoId ORDER BY TM1.[ErrorRequerimientoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q6", "SELECT [ListaRequerimientosDescripcion] FROM [ListaRequerimientos] WHERE [ListaRequerimientosId] = @ListaRequerimientosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q7", "SELECT [ErrorRequerimientoId] FROM [ErrorRequerimiento] WHERE [ErrorRequerimientoId] = @ErrorRequerimientoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q8", "SELECT TOP 1 [ErrorRequerimientoId] FROM [ErrorRequerimiento] WHERE ( [ErrorRequerimientoId] > @ErrorRequerimientoId) ORDER BY [ErrorRequerimientoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Q9", "SELECT TOP 1 [ErrorRequerimientoId] FROM [ErrorRequerimiento] WHERE ( [ErrorRequerimientoId] < @ErrorRequerimientoId) ORDER BY [ErrorRequerimientoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000Q10", "INSERT INTO [ErrorRequerimiento]([ErrorRequerimientoDescripcion], [ErrorRequerimientoUsuarioSistema], [ListaRequerimientosId]) VALUES(@ErrorRequerimientoDescripcion, @ErrorRequerimientoUsuarioSistema, @ListaRequerimientosId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000Q10)
          ,new CursorDef("T000Q11", "UPDATE [ErrorRequerimiento] SET [ErrorRequerimientoDescripcion]=@ErrorRequerimientoDescripcion, [ErrorRequerimientoUsuarioSistema]=@ErrorRequerimientoUsuarioSistema, [ListaRequerimientosId]=@ListaRequerimientosId  WHERE [ErrorRequerimientoId] = @ErrorRequerimientoId", GxErrorMask.GX_NOMASK,prmT000Q11)
          ,new CursorDef("T000Q12", "DELETE FROM [ErrorRequerimiento]  WHERE [ErrorRequerimientoId] = @ErrorRequerimientoId", GxErrorMask.GX_NOMASK,prmT000Q12)
          ,new CursorDef("T000Q13", "SELECT [ListaRequerimientosDescripcion] FROM [ListaRequerimientos] WHERE [ListaRequerimientosId] = @ListaRequerimientosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000Q14", "SELECT [ErrorRequerimientoId] FROM [ErrorRequerimiento] ORDER BY [ErrorRequerimientoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q14,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 6 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 8 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 12 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
