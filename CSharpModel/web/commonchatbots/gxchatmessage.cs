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
namespace GeneXus.Programs.commonchatbots {
   public class gxchatmessage : GXDataArea, System.Web.SessionState.IRequiresSessionState
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A268GXChatUserId = (Guid)(StringUtil.StrToGuid( GetPar( "GXChatUserId")));
            AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
            A269GXChatUserDevice = GetPar( "GXChatUserDevice");
            AssignAttri("", false, "A269GXChatUserDevice", A269GXChatUserDevice);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A268GXChatUserId, A269GXChatUserDevice) ;
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
            Form.Meta.addItem("description", "GXChat Message", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtGXChatMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("K2BOrion");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public gxchatmessage( )
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

      public gxchatmessage( IGxContext context )
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
            return "gxchatmessage_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "GXChat Message", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CommonChatbots\\GXChatMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 4, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"commonchatbots.gx00k0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"GXCHATMESSAGEID"+"'), id:'"+"GXCHATMESSAGEID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_CommonChatbots\\GXChatMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageId_Internalname, "Message Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGXChatMessageId_Internalname, A267GXChatMessageId.ToString(), A267GXChatMessageId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGXChatMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGXChatMessageId_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatUserId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatUserId_Internalname, "GXChat User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGXChatUserId_Internalname, A268GXChatUserId.ToString(), A268GXChatUserId.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGXChatUserId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGXChatUserId_Enabled, 0, "text", "", 256, "chr", 1, "row", 36, 0, 0, 0, 1, 0, 0, true, "", "", false, "", "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageMessage_Internalname, "Message Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGXChatMessageMessage_Internalname, A272GXChatMessageMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", 0, 1, edtGXChatMessageMessage_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageType_Internalname, "Message Type", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGXChatMessageType_Internalname, StringUtil.RTrim( A271GXChatMessageType), StringUtil.RTrim( context.localUtil.Format( A271GXChatMessageType, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGXChatMessageType_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGXChatMessageType_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgGXChatMessageImage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Message Image", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A274GXChatMessageImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000GXChatMessageImage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.PathToRelativeUrl( A274GXChatMessageImage));
         GxWebStd.gx_bitmap( context, imgGXChatMessageImage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgGXChatMessageImage_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", "", "", 0, A274GXChatMessageImage_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CommonChatbots\\GXChatMessage.htm");
         AssignProp("", false, imgGXChatMessageImage_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.PathToRelativeUrl( A274GXChatMessageImage)), true);
         AssignProp("", false, imgGXChatMessageImage_Internalname, "IsBlob", StringUtil.BoolToStr( A274GXChatMessageImage_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageDate_Internalname, "Message Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtGXChatMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtGXChatMessageDate_Internalname, context.localUtil.TToC( A270GXChatMessageDate, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A270GXChatMessageDate, "99/99/99 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',12,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',12,24,'spa',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGXChatMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGXChatMessageDate_Enabled, 0, "text", "", 21, "chr", 1, "row", 21, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_bitmap( context, edtGXChatMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtGXChatMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CommonChatbots\\GXChatMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageMeta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageMeta_Internalname, "Message Meta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGXChatMessageMeta_Internalname, A276GXChatMessageMeta, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", 0, 1, edtGXChatMessageMeta_Enabled, 0, 80, "chr", 10, "row", StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatUserDevice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatUserDevice_Internalname, "GXChat User Device", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGXChatUserDevice_Internalname, A269GXChatUserDevice, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", 0, 1, edtGXChatUserDevice_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CommonChatbots\\GXChatMessage.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_268_269_Internalname, sImgUrl, imgprompt_268_269_Link, "", "", context.GetTheme( ), imgprompt_268_269_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageRepeat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageRepeat_Internalname, "Message Repeat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGXChatMessageRepeat_Internalname, A275GXChatMessageRepeat, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", 0, 1, edtGXChatMessageRepeat_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGXChatMessageInstance_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGXChatMessageInstance_Internalname, "Message Instance", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtGXChatMessageInstance_Internalname, A273GXChatMessageInstance, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", 0, 1, edtGXChatMessageInstance_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "256", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CommonChatbots\\GXChatMessage.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CommonChatbots\\GXChatMessage.htm");
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
            Z267GXChatMessageId = (Guid)(StringUtil.StrToGuid( cgiGet( "Z267GXChatMessageId")));
            Z271GXChatMessageType = cgiGet( "Z271GXChatMessageType");
            Z270GXChatMessageDate = context.localUtil.CToT( cgiGet( "Z270GXChatMessageDate"), 0);
            Z275GXChatMessageRepeat = cgiGet( "Z275GXChatMessageRepeat");
            Z273GXChatMessageInstance = cgiGet( "Z273GXChatMessageInstance");
            Z268GXChatUserId = (Guid)(StringUtil.StrToGuid( cgiGet( "Z268GXChatUserId")));
            Z269GXChatUserDevice = cgiGet( "Z269GXChatUserDevice");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
            A40000GXChatMessageImage_GXI = cgiGet( "GXCHATMESSAGEIMAGE_GXI");
            n40000GXChatMessageImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000GXChatMessageImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? true : false);
            /* Read variables values. */
            if ( StringUtil.StrCmp(cgiGet( edtGXChatMessageId_Internalname), "") == 0 )
            {
               A267GXChatMessageId = (Guid)(Guid.Empty);
               AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
            }
            else
            {
               try
               {
                  A267GXChatMessageId = (Guid)(StringUtil.StrToGuid( cgiGet( edtGXChatMessageId_Internalname)));
                  AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "GXCHATMESSAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtGXChatMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            if ( StringUtil.StrCmp(cgiGet( edtGXChatUserId_Internalname), "") == 0 )
            {
               A268GXChatUserId = (Guid)(Guid.Empty);
               AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
            }
            else
            {
               try
               {
                  A268GXChatUserId = (Guid)(StringUtil.StrToGuid( cgiGet( edtGXChatUserId_Internalname)));
                  AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
               }
               catch ( Exception  )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "GXCHATUSERID");
                  AnyError = 1;
                  GX_FocusControl = edtGXChatUserId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
               }
            }
            A272GXChatMessageMessage = cgiGet( edtGXChatMessageMessage_Internalname);
            AssignAttri("", false, "A272GXChatMessageMessage", A272GXChatMessageMessage);
            A271GXChatMessageType = cgiGet( edtGXChatMessageType_Internalname);
            AssignAttri("", false, "A271GXChatMessageType", A271GXChatMessageType);
            A274GXChatMessageImage = cgiGet( imgGXChatMessageImage_Internalname);
            n274GXChatMessageImage = false;
            AssignAttri("", false, "A274GXChatMessageImage", A274GXChatMessageImage);
            n274GXChatMessageImage = (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? true : false);
            if ( context.localUtil.VCDateTime( cgiGet( edtGXChatMessageDate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"GXChat Message Date"}), 1, "GXCHATMESSAGEDATE");
               AnyError = 1;
               GX_FocusControl = edtGXChatMessageDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A270GXChatMessageDate", context.localUtil.TToC( A270GXChatMessageDate, 8, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A270GXChatMessageDate = context.localUtil.CToT( cgiGet( edtGXChatMessageDate_Internalname));
               AssignAttri("", false, "A270GXChatMessageDate", context.localUtil.TToC( A270GXChatMessageDate, 8, 12, 0, 3, "/", ":", " "));
            }
            A276GXChatMessageMeta = cgiGet( edtGXChatMessageMeta_Internalname);
            AssignAttri("", false, "A276GXChatMessageMeta", A276GXChatMessageMeta);
            A269GXChatUserDevice = cgiGet( edtGXChatUserDevice_Internalname);
            AssignAttri("", false, "A269GXChatUserDevice", A269GXChatUserDevice);
            A275GXChatMessageRepeat = cgiGet( edtGXChatMessageRepeat_Internalname);
            AssignAttri("", false, "A275GXChatMessageRepeat", A275GXChatMessageRepeat);
            A273GXChatMessageInstance = cgiGet( edtGXChatMessageInstance_Internalname);
            AssignAttri("", false, "A273GXChatMessageInstance", A273GXChatMessageInstance);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgGXChatMessageImage_Internalname, ref  A274GXChatMessageImage, ref  A40000GXChatMessageImage_GXI);
            n40000GXChatMessageImage_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000GXChatMessageImage_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? true : false);
            n274GXChatMessageImage = (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? true : false);
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
               A267GXChatMessageId = (Guid)(StringUtil.StrToGuid( GetPar( "GXChatMessageId")));
               AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
               getEqualNoModal( ) ;
               if ( IsIns( )  && (Guid.Empty==A267GXChatMessageId) && ( Gx_BScreen == 0 ) )
               {
                  A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
                  AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
               }
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               getEqualNoModal( ) ;
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
               InitAll0J20( ) ;
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
         DisableAttributes0J20( ) ;
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

      protected void ResetCaption0J0( )
      {
      }

      protected void ZM0J20( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z271GXChatMessageType = T000J3_A271GXChatMessageType[0];
               Z270GXChatMessageDate = T000J3_A270GXChatMessageDate[0];
               Z275GXChatMessageRepeat = T000J3_A275GXChatMessageRepeat[0];
               Z273GXChatMessageInstance = T000J3_A273GXChatMessageInstance[0];
               Z268GXChatUserId = (Guid)(T000J3_A268GXChatUserId[0]);
               Z269GXChatUserDevice = T000J3_A269GXChatUserDevice[0];
            }
            else
            {
               Z271GXChatMessageType = A271GXChatMessageType;
               Z270GXChatMessageDate = A270GXChatMessageDate;
               Z275GXChatMessageRepeat = A275GXChatMessageRepeat;
               Z273GXChatMessageInstance = A273GXChatMessageInstance;
               Z268GXChatUserId = (Guid)(A268GXChatUserId);
               Z269GXChatUserDevice = A269GXChatUserDevice;
            }
         }
         if ( GX_JID == -5 )
         {
            Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
            Z272GXChatMessageMessage = A272GXChatMessageMessage;
            Z271GXChatMessageType = A271GXChatMessageType;
            Z274GXChatMessageImage = A274GXChatMessageImage;
            Z40000GXChatMessageImage_GXI = A40000GXChatMessageImage_GXI;
            Z270GXChatMessageDate = A270GXChatMessageDate;
            Z276GXChatMessageMeta = A276GXChatMessageMeta;
            Z275GXChatMessageRepeat = A275GXChatMessageRepeat;
            Z273GXChatMessageInstance = A273GXChatMessageInstance;
            Z268GXChatUserId = (Guid)(A268GXChatUserId);
            Z269GXChatUserDevice = A269GXChatUserDevice;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_268_269_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"commonchatbots.gx00l0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"GXCHATUSERID"+"'), id:'"+"GXCHATUSERID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+"GXCHATUSERDEVICE"+"'), id:'"+"GXCHATUSERDEVICE"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A267GXChatMessageId) && ( Gx_BScreen == 0 ) )
         {
            A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
            AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
         }
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0J20( )
      {
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
            A272GXChatMessageMessage = T000J5_A272GXChatMessageMessage[0];
            AssignAttri("", false, "A272GXChatMessageMessage", A272GXChatMessageMessage);
            A271GXChatMessageType = T000J5_A271GXChatMessageType[0];
            AssignAttri("", false, "A271GXChatMessageType", A271GXChatMessageType);
            A40000GXChatMessageImage_GXI = T000J5_A40000GXChatMessageImage_GXI[0];
            n40000GXChatMessageImage_GXI = T000J5_n40000GXChatMessageImage_GXI[0];
            AssignProp("", false, imgGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), true);
            AssignProp("", false, imgGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
            A270GXChatMessageDate = T000J5_A270GXChatMessageDate[0];
            AssignAttri("", false, "A270GXChatMessageDate", context.localUtil.TToC( A270GXChatMessageDate, 8, 12, 0, 3, "/", ":", " "));
            A276GXChatMessageMeta = T000J5_A276GXChatMessageMeta[0];
            AssignAttri("", false, "A276GXChatMessageMeta", A276GXChatMessageMeta);
            A275GXChatMessageRepeat = T000J5_A275GXChatMessageRepeat[0];
            AssignAttri("", false, "A275GXChatMessageRepeat", A275GXChatMessageRepeat);
            A273GXChatMessageInstance = T000J5_A273GXChatMessageInstance[0];
            AssignAttri("", false, "A273GXChatMessageInstance", A273GXChatMessageInstance);
            A268GXChatUserId = (Guid)((Guid)(T000J5_A268GXChatUserId[0]));
            AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
            A269GXChatUserDevice = T000J5_A269GXChatUserDevice[0];
            AssignAttri("", false, "A269GXChatUserDevice", A269GXChatUserDevice);
            A274GXChatMessageImage = T000J5_A274GXChatMessageImage[0];
            n274GXChatMessageImage = T000J5_n274GXChatMessageImage[0];
            AssignAttri("", false, "A274GXChatMessageImage", A274GXChatMessageImage);
            AssignProp("", false, imgGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), true);
            AssignProp("", false, imgGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
            ZM0J20( -5) ;
         }
         pr_default.close(3);
         OnLoadActions0J20( ) ;
      }

      protected void OnLoadActions0J20( )
      {
      }

      protected void CheckExtendedTable0J20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'GX Chat User'.", "ForeignKeyNotFound", 1, "GXCHATUSERDEVICE");
            AnyError = 1;
            GX_FocusControl = edtGXChatUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A270GXChatMessageDate) || ( A270GXChatMessageDate >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo GXChat Message Date fuera de rango", "OutOfRange", 1, "GXCHATMESSAGEDATE");
            AnyError = 1;
            GX_FocusControl = edtGXChatMessageDate_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0J20( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( Guid A268GXChatUserId ,
                               string A269GXChatUserDevice )
      {
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'GX Chat User'.", "ForeignKeyNotFound", 1, "GXCHATUSERDEVICE");
            AnyError = 1;
            GX_FocusControl = edtGXChatUserId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0J20( )
      {
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J20( 5) ;
            RcdFound20 = 1;
            A267GXChatMessageId = (Guid)((Guid)(T000J3_A267GXChatMessageId[0]));
            AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
            A272GXChatMessageMessage = T000J3_A272GXChatMessageMessage[0];
            AssignAttri("", false, "A272GXChatMessageMessage", A272GXChatMessageMessage);
            A271GXChatMessageType = T000J3_A271GXChatMessageType[0];
            AssignAttri("", false, "A271GXChatMessageType", A271GXChatMessageType);
            A40000GXChatMessageImage_GXI = T000J3_A40000GXChatMessageImage_GXI[0];
            n40000GXChatMessageImage_GXI = T000J3_n40000GXChatMessageImage_GXI[0];
            AssignProp("", false, imgGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), true);
            AssignProp("", false, imgGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
            A270GXChatMessageDate = T000J3_A270GXChatMessageDate[0];
            AssignAttri("", false, "A270GXChatMessageDate", context.localUtil.TToC( A270GXChatMessageDate, 8, 12, 0, 3, "/", ":", " "));
            A276GXChatMessageMeta = T000J3_A276GXChatMessageMeta[0];
            AssignAttri("", false, "A276GXChatMessageMeta", A276GXChatMessageMeta);
            A275GXChatMessageRepeat = T000J3_A275GXChatMessageRepeat[0];
            AssignAttri("", false, "A275GXChatMessageRepeat", A275GXChatMessageRepeat);
            A273GXChatMessageInstance = T000J3_A273GXChatMessageInstance[0];
            AssignAttri("", false, "A273GXChatMessageInstance", A273GXChatMessageInstance);
            A268GXChatUserId = (Guid)((Guid)(T000J3_A268GXChatUserId[0]));
            AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
            A269GXChatUserDevice = T000J3_A269GXChatUserDevice[0];
            AssignAttri("", false, "A269GXChatUserDevice", A269GXChatUserDevice);
            A274GXChatMessageImage = T000J3_A274GXChatMessageImage[0];
            n274GXChatMessageImage = T000J3_n274GXChatMessageImage[0];
            AssignAttri("", false, "A274GXChatMessageImage", A274GXChatMessageImage);
            AssignProp("", false, imgGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), true);
            AssignProp("", false, imgGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
            Z267GXChatMessageId = (Guid)(A267GXChatMessageId);
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0J20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0J20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0J20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J20( ) ;
         if ( RcdFound20 == 0 )
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
         RcdFound20 = 0;
         /* Using cursor T000J8 */
         pr_default.execute(6, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000J8_A267GXChatMessageId[0], A267GXChatMessageId, 1) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000J8_A267GXChatMessageId[0], A267GXChatMessageId, 1) > 0 ) ) )
            {
               A267GXChatMessageId = (Guid)((Guid)(T000J8_A267GXChatMessageId[0]));
               AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
               RcdFound20 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000J9 */
         pr_default.execute(7, new Object[] {A267GXChatMessageId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000J9_A267GXChatMessageId[0], A267GXChatMessageId, 1) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000J9_A267GXChatMessageId[0], A267GXChatMessageId, 1) < 0 ) ) )
            {
               A267GXChatMessageId = (Guid)((Guid)(T000J9_A267GXChatMessageId[0]));
               AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
               RcdFound20 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtGXChatMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A267GXChatMessageId != Z267GXChatMessageId )
               {
                  A267GXChatMessageId = (Guid)(Z267GXChatMessageId);
                  AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "GXCHATMESSAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtGXChatMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtGXChatMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0J20( ) ;
                  GX_FocusControl = edtGXChatMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A267GXChatMessageId != Z267GXChatMessageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtGXChatMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "GXCHATMESSAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtGXChatMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtGXChatMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J20( ) ;
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
         if ( A267GXChatMessageId != Z267GXChatMessageId )
         {
            A267GXChatMessageId = (Guid)(Z267GXChatMessageId);
            AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "GXCHATMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtGXChatMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtGXChatMessageId_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "GXCHATMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtGXChatMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtGXChatUserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGXChatUserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J20( ) ;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGXChatUserId_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGXChatUserId_Internalname;
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
         ScanStart0J20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound20 != 0 )
            {
               ScanNext0J20( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtGXChatUserId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0J20( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0J20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A267GXChatMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GXChatMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z271GXChatMessageType, T000J2_A271GXChatMessageType[0]) != 0 ) || ( Z270GXChatMessageDate != T000J2_A270GXChatMessageDate[0] ) || ( StringUtil.StrCmp(Z275GXChatMessageRepeat, T000J2_A275GXChatMessageRepeat[0]) != 0 ) || ( StringUtil.StrCmp(Z273GXChatMessageInstance, T000J2_A273GXChatMessageInstance[0]) != 0 ) || ( Z268GXChatUserId != T000J2_A268GXChatUserId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z269GXChatUserDevice, T000J2_A269GXChatUserDevice[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z271GXChatMessageType, T000J2_A271GXChatMessageType[0]) != 0 )
               {
                  GXUtil.WriteLog("commonchatbots.gxchatmessage:[seudo value changed for attri]"+"GXChatMessageType");
                  GXUtil.WriteLogRaw("Old: ",Z271GXChatMessageType);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A271GXChatMessageType[0]);
               }
               if ( Z270GXChatMessageDate != T000J2_A270GXChatMessageDate[0] )
               {
                  GXUtil.WriteLog("commonchatbots.gxchatmessage:[seudo value changed for attri]"+"GXChatMessageDate");
                  GXUtil.WriteLogRaw("Old: ",Z270GXChatMessageDate);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A270GXChatMessageDate[0]);
               }
               if ( StringUtil.StrCmp(Z275GXChatMessageRepeat, T000J2_A275GXChatMessageRepeat[0]) != 0 )
               {
                  GXUtil.WriteLog("commonchatbots.gxchatmessage:[seudo value changed for attri]"+"GXChatMessageRepeat");
                  GXUtil.WriteLogRaw("Old: ",Z275GXChatMessageRepeat);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A275GXChatMessageRepeat[0]);
               }
               if ( StringUtil.StrCmp(Z273GXChatMessageInstance, T000J2_A273GXChatMessageInstance[0]) != 0 )
               {
                  GXUtil.WriteLog("commonchatbots.gxchatmessage:[seudo value changed for attri]"+"GXChatMessageInstance");
                  GXUtil.WriteLogRaw("Old: ",Z273GXChatMessageInstance);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A273GXChatMessageInstance[0]);
               }
               if ( Z268GXChatUserId != T000J2_A268GXChatUserId[0] )
               {
                  GXUtil.WriteLog("commonchatbots.gxchatmessage:[seudo value changed for attri]"+"GXChatUserId");
                  GXUtil.WriteLogRaw("Old: ",Z268GXChatUserId);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A268GXChatUserId[0]);
               }
               if ( StringUtil.StrCmp(Z269GXChatUserDevice, T000J2_A269GXChatUserDevice[0]) != 0 )
               {
                  GXUtil.WriteLog("commonchatbots.gxchatmessage:[seudo value changed for attri]"+"GXChatUserDevice");
                  GXUtil.WriteLogRaw("Old: ",Z269GXChatUserDevice);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A269GXChatUserDevice[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"GXChatMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J20( )
      {
         if ( ! IsAuthorized("gxchatmessage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J20( 0) ;
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J10 */
                     pr_default.execute(8, new Object[] {A272GXChatMessageMessage, A271GXChatMessageType, n274GXChatMessageImage, A274GXChatMessageImage, n40000GXChatMessageImage_GXI, A40000GXChatMessageImage_GXI, A270GXChatMessageDate, A276GXChatMessageMeta, A275GXChatMessageRepeat, A273GXChatMessageInstance, A268GXChatUserId, A269GXChatUserDevice, A267GXChatMessageId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0J0( ) ;
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
               Load0J20( ) ;
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void Update0J20( )
      {
         if ( ! IsAuthorized("gxchatmessage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J11 */
                     pr_default.execute(9, new Object[] {A272GXChatMessageMessage, A271GXChatMessageType, A270GXChatMessageDate, A276GXChatMessageMeta, A275GXChatMessageRepeat, A273GXChatMessageInstance, A268GXChatUserId, A269GXChatUserDevice, A267GXChatMessageId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"GXChatMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0J0( ) ;
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
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void DeferredUpdate0J20( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000J12 */
            pr_default.execute(10, new Object[] {n274GXChatMessageImage, A274GXChatMessageImage, n40000GXChatMessageImage_GXI, A40000GXChatMessageImage_GXI, A267GXChatMessageId});
            pr_default.close(10);
            dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("gxchatmessage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J20( ) ;
            AfterConfirm0J20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J13 */
                  pr_default.execute(11, new Object[] {A267GXChatMessageId});
                  pr_default.close(11);
                  dsDefault.SmartCacheProvider.SetUpdated("GXChatMessage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound20 == 0 )
                        {
                           InitAll0J20( ) ;
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
                        ResetCaption0J0( ) ;
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0J20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("commonchatbots.gxchatmessage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("commonchatbots.gxchatmessage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J20( )
      {
         /* Using cursor T000J14 */
         pr_default.execute(12);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound20 = 1;
            A267GXChatMessageId = (Guid)((Guid)(T000J14_A267GXChatMessageId[0]));
            AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J20( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound20 = 1;
            A267GXChatMessageId = (Guid)((Guid)(T000J14_A267GXChatMessageId[0]));
            AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
         }
      }

      protected void ScanEnd0J20( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0J20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J20( )
      {
         edtGXChatMessageId_Enabled = 0;
         AssignProp("", false, edtGXChatMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageId_Enabled), 5, 0), true);
         edtGXChatUserId_Enabled = 0;
         AssignProp("", false, edtGXChatUserId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatUserId_Enabled), 5, 0), true);
         edtGXChatMessageMessage_Enabled = 0;
         AssignProp("", false, edtGXChatMessageMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageMessage_Enabled), 5, 0), true);
         edtGXChatMessageType_Enabled = 0;
         AssignProp("", false, edtGXChatMessageType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageType_Enabled), 5, 0), true);
         imgGXChatMessageImage_Enabled = 0;
         AssignProp("", false, imgGXChatMessageImage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgGXChatMessageImage_Enabled), 5, 0), true);
         edtGXChatMessageDate_Enabled = 0;
         AssignProp("", false, edtGXChatMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageDate_Enabled), 5, 0), true);
         edtGXChatMessageMeta_Enabled = 0;
         AssignProp("", false, edtGXChatMessageMeta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageMeta_Enabled), 5, 0), true);
         edtGXChatUserDevice_Enabled = 0;
         AssignProp("", false, edtGXChatUserDevice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatUserDevice_Enabled), 5, 0), true);
         edtGXChatMessageRepeat_Enabled = 0;
         AssignProp("", false, edtGXChatMessageRepeat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageRepeat_Enabled), 5, 0), true);
         edtGXChatMessageInstance_Enabled = 0;
         AssignProp("", false, edtGXChatMessageInstance_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGXChatMessageInstance_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202418815843", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("commonchatbots.gxchatmessage.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z267GXChatMessageId", Z267GXChatMessageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z271GXChatMessageType", StringUtil.RTrim( Z271GXChatMessageType));
         GxWebStd.gx_hidden_field( context, "Z270GXChatMessageDate", context.localUtil.TToC( Z270GXChatMessageDate, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z275GXChatMessageRepeat", Z275GXChatMessageRepeat);
         GxWebStd.gx_hidden_field( context, "Z273GXChatMessageInstance", Z273GXChatMessageInstance);
         GxWebStd.gx_hidden_field( context, "Z268GXChatUserId", Z268GXChatUserId.ToString());
         GxWebStd.gx_hidden_field( context, "Z269GXChatUserDevice", Z269GXChatUserDevice);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXCHATMESSAGEIMAGE_GXI", A40000GXChatMessageImage_GXI);
         GXCCtlgxBlob = "GXCHATMESSAGEIMAGE" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A274GXChatMessageImage);
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
         return formatLink("commonchatbots.gxchatmessage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CommonChatbots.GXChatMessage" ;
      }

      public override string GetPgmdesc( )
      {
         return "GXChat Message" ;
      }

      protected void InitializeNonKey0J20( )
      {
         A268GXChatUserId = (Guid)(Guid.Empty);
         AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
         A272GXChatMessageMessage = "";
         AssignAttri("", false, "A272GXChatMessageMessage", A272GXChatMessageMessage);
         A271GXChatMessageType = "";
         AssignAttri("", false, "A271GXChatMessageType", A271GXChatMessageType);
         A274GXChatMessageImage = "";
         n274GXChatMessageImage = false;
         AssignAttri("", false, "A274GXChatMessageImage", A274GXChatMessageImage);
         AssignProp("", false, imgGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), true);
         AssignProp("", false, imgGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
         n274GXChatMessageImage = (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? true : false);
         A40000GXChatMessageImage_GXI = "";
         n40000GXChatMessageImage_GXI = false;
         AssignProp("", false, imgGXChatMessageImage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A274GXChatMessageImage)) ? A40000GXChatMessageImage_GXI : context.convertURL( context.PathToRelativeUrl( A274GXChatMessageImage))), true);
         AssignProp("", false, imgGXChatMessageImage_Internalname, "SrcSet", context.GetImageSrcSet( A274GXChatMessageImage), true);
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A270GXChatMessageDate", context.localUtil.TToC( A270GXChatMessageDate, 8, 12, 0, 3, "/", ":", " "));
         A276GXChatMessageMeta = "";
         AssignAttri("", false, "A276GXChatMessageMeta", A276GXChatMessageMeta);
         A269GXChatUserDevice = "";
         AssignAttri("", false, "A269GXChatUserDevice", A269GXChatUserDevice);
         A275GXChatMessageRepeat = "";
         AssignAttri("", false, "A275GXChatMessageRepeat", A275GXChatMessageRepeat);
         A273GXChatMessageInstance = "";
         AssignAttri("", false, "A273GXChatMessageInstance", A273GXChatMessageInstance);
         Z271GXChatMessageType = "";
         Z270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         Z275GXChatMessageRepeat = "";
         Z273GXChatMessageInstance = "";
         Z268GXChatUserId = (Guid)(Guid.Empty);
         Z269GXChatUserDevice = "";
      }

      protected void InitAll0J20( )
      {
         A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
         AssignAttri("", false, "A267GXChatMessageId", A267GXChatMessageId.ToString());
         InitializeNonKey0J20( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418815854", true, true);
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
         context.AddJavascriptSource("commonchatbots/gxchatmessage.js", "?202418815854", false, true);
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
         edtGXChatMessageId_Internalname = "GXCHATMESSAGEID";
         edtGXChatUserId_Internalname = "GXCHATUSERID";
         edtGXChatMessageMessage_Internalname = "GXCHATMESSAGEMESSAGE";
         edtGXChatMessageType_Internalname = "GXCHATMESSAGETYPE";
         imgGXChatMessageImage_Internalname = "GXCHATMESSAGEIMAGE";
         edtGXChatMessageDate_Internalname = "GXCHATMESSAGEDATE";
         edtGXChatMessageMeta_Internalname = "GXCHATMESSAGEMETA";
         edtGXChatUserDevice_Internalname = "GXCHATUSERDEVICE";
         edtGXChatMessageRepeat_Internalname = "GXCHATMESSAGEREPEAT";
         edtGXChatMessageInstance_Internalname = "GXCHATMESSAGEINSTANCE";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         imgprompt_268_269_Internalname = "PROMPT_268_269";
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
         Form.Caption = "GXChat Message";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtGXChatMessageInstance_Enabled = 1;
         edtGXChatMessageRepeat_Enabled = 1;
         imgprompt_268_269_Visible = 1;
         imgprompt_268_269_Link = "";
         edtGXChatUserDevice_Enabled = 1;
         edtGXChatMessageMeta_Enabled = 1;
         edtGXChatMessageDate_Jsonclick = "";
         edtGXChatMessageDate_Enabled = 1;
         imgGXChatMessageImage_Enabled = 1;
         edtGXChatMessageType_Jsonclick = "";
         edtGXChatMessageType_Enabled = 1;
         edtGXChatMessageMessage_Enabled = 1;
         edtGXChatUserId_Jsonclick = "";
         edtGXChatUserId_Enabled = 1;
         edtGXChatMessageId_Jsonclick = "";
         edtGXChatMessageId_Enabled = 1;
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
         GX_FocusControl = edtGXChatUserId_Internalname;
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

      public void Valid_Gxchatmessageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A268GXChatUserId", A268GXChatUserId.ToString());
         AssignAttri("", false, "A272GXChatMessageMessage", A272GXChatMessageMessage);
         AssignAttri("", false, "A271GXChatMessageType", StringUtil.RTrim( A271GXChatMessageType));
         AssignAttri("", false, "A274GXChatMessageImage", context.PathToRelativeUrl( A274GXChatMessageImage));
         GXCCtlgxBlob = "GXCHATMESSAGEIMAGE" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A274GXChatMessageImage));
         AssignAttri("", false, "A40000GXChatMessageImage_GXI", A40000GXChatMessageImage_GXI);
         AssignAttri("", false, "A270GXChatMessageDate", context.localUtil.TToC( A270GXChatMessageDate, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A276GXChatMessageMeta", A276GXChatMessageMeta);
         AssignAttri("", false, "A269GXChatUserDevice", A269GXChatUserDevice);
         AssignAttri("", false, "A275GXChatMessageRepeat", A275GXChatMessageRepeat);
         AssignAttri("", false, "A273GXChatMessageInstance", A273GXChatMessageInstance);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z267GXChatMessageId", Z267GXChatMessageId.ToString());
         GxWebStd.gx_hidden_field( context, "Z268GXChatUserId", Z268GXChatUserId.ToString());
         GxWebStd.gx_hidden_field( context, "Z272GXChatMessageMessage", Z272GXChatMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z271GXChatMessageType", StringUtil.RTrim( Z271GXChatMessageType));
         GxWebStd.gx_hidden_field( context, "Z274GXChatMessageImage", context.PathToRelativeUrl( Z274GXChatMessageImage));
         GxWebStd.gx_hidden_field( context, "Z40000GXChatMessageImage_GXI", Z40000GXChatMessageImage_GXI);
         GxWebStd.gx_hidden_field( context, "Z270GXChatMessageDate", context.localUtil.TToC( Z270GXChatMessageDate, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z276GXChatMessageMeta", Z276GXChatMessageMeta);
         GxWebStd.gx_hidden_field( context, "Z269GXChatUserDevice", Z269GXChatUserDevice);
         GxWebStd.gx_hidden_field( context, "Z275GXChatMessageRepeat", Z275GXChatMessageRepeat);
         GxWebStd.gx_hidden_field( context, "Z273GXChatMessageInstance", Z273GXChatMessageInstance);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Gxchatuserdevice( )
      {
         /* Using cursor T000J15 */
         pr_default.execute(13, new Object[] {A268GXChatUserId, A269GXChatUserDevice});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'GX Chat User'.", "ForeignKeyNotFound", 1, "GXCHATUSERDEVICE");
            AnyError = 1;
            GX_FocusControl = edtGXChatUserId_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_GXCHATMESSAGEID","{handler:'Valid_Gxchatmessageid',iparms:[{av:'A267GXChatMessageId',fld:'GXCHATMESSAGEID',pic:''},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_GXCHATMESSAGEID",",oparms:[{av:'A268GXChatUserId',fld:'GXCHATUSERID',pic:''},{av:'A272GXChatMessageMessage',fld:'GXCHATMESSAGEMESSAGE',pic:''},{av:'A271GXChatMessageType',fld:'GXCHATMESSAGETYPE',pic:''},{av:'A274GXChatMessageImage',fld:'GXCHATMESSAGEIMAGE',pic:''},{av:'A40000GXChatMessageImage_GXI',fld:'GXCHATMESSAGEIMAGE_GXI',pic:''},{av:'A270GXChatMessageDate',fld:'GXCHATMESSAGEDATE',pic:'99/99/99 99:99:99.999'},{av:'A276GXChatMessageMeta',fld:'GXCHATMESSAGEMETA',pic:''},{av:'A269GXChatUserDevice',fld:'GXCHATUSERDEVICE',pic:''},{av:'A275GXChatMessageRepeat',fld:'GXCHATMESSAGEREPEAT',pic:''},{av:'A273GXChatMessageInstance',fld:'GXCHATMESSAGEINSTANCE',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z267GXChatMessageId'},{av:'Z268GXChatUserId'},{av:'Z272GXChatMessageMessage'},{av:'Z271GXChatMessageType'},{av:'Z274GXChatMessageImage'},{av:'Z40000GXChatMessageImage_GXI'},{av:'Z270GXChatMessageDate'},{av:'Z276GXChatMessageMeta'},{av:'Z269GXChatUserDevice'},{av:'Z275GXChatMessageRepeat'},{av:'Z273GXChatMessageInstance'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_GXCHATUSERID","{handler:'Valid_Gxchatuserid',iparms:[]");
         setEventMetadata("VALID_GXCHATUSERID",",oparms:[]}");
         setEventMetadata("VALID_GXCHATMESSAGEDATE","{handler:'Valid_Gxchatmessagedate',iparms:[]");
         setEventMetadata("VALID_GXCHATMESSAGEDATE",",oparms:[]}");
         setEventMetadata("VALID_GXCHATUSERDEVICE","{handler:'Valid_Gxchatuserdevice',iparms:[{av:'A268GXChatUserId',fld:'GXCHATUSERID',pic:''},{av:'A269GXChatUserDevice',fld:'GXCHATUSERDEVICE',pic:''}]");
         setEventMetadata("VALID_GXCHATUSERDEVICE",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z267GXChatMessageId = (Guid)(Guid.Empty);
         Z271GXChatMessageType = "";
         Z270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         Z275GXChatMessageRepeat = "";
         Z273GXChatMessageInstance = "";
         Z268GXChatUserId = (Guid)(Guid.Empty);
         Z269GXChatUserDevice = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A268GXChatUserId = (Guid)(Guid.Empty);
         A269GXChatUserDevice = "";
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
         A267GXChatMessageId = (Guid)(Guid.Empty);
         A272GXChatMessageMessage = "";
         A271GXChatMessageType = "";
         A274GXChatMessageImage = "";
         A40000GXChatMessageImage_GXI = "";
         sImgUrl = "";
         A270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         A276GXChatMessageMeta = "";
         A275GXChatMessageRepeat = "";
         A273GXChatMessageInstance = "";
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
         Z272GXChatMessageMessage = "";
         Z274GXChatMessageImage = "";
         Z40000GXChatMessageImage_GXI = "";
         Z276GXChatMessageMeta = "";
         T000J5_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         T000J5_A272GXChatMessageMessage = new string[] {""} ;
         T000J5_A271GXChatMessageType = new string[] {""} ;
         T000J5_A40000GXChatMessageImage_GXI = new string[] {""} ;
         T000J5_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         T000J5_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000J5_A276GXChatMessageMeta = new string[] {""} ;
         T000J5_A275GXChatMessageRepeat = new string[] {""} ;
         T000J5_A273GXChatMessageInstance = new string[] {""} ;
         T000J5_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         T000J5_A269GXChatUserDevice = new string[] {""} ;
         T000J5_A274GXChatMessageImage = new string[] {""} ;
         T000J5_n274GXChatMessageImage = new bool[] {false} ;
         T000J4_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         T000J6_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         T000J7_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         T000J3_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         T000J3_A272GXChatMessageMessage = new string[] {""} ;
         T000J3_A271GXChatMessageType = new string[] {""} ;
         T000J3_A40000GXChatMessageImage_GXI = new string[] {""} ;
         T000J3_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         T000J3_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000J3_A276GXChatMessageMeta = new string[] {""} ;
         T000J3_A275GXChatMessageRepeat = new string[] {""} ;
         T000J3_A273GXChatMessageInstance = new string[] {""} ;
         T000J3_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         T000J3_A269GXChatUserDevice = new string[] {""} ;
         T000J3_A274GXChatMessageImage = new string[] {""} ;
         T000J3_n274GXChatMessageImage = new bool[] {false} ;
         sMode20 = "";
         T000J8_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         T000J9_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         T000J2_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         T000J2_A272GXChatMessageMessage = new string[] {""} ;
         T000J2_A271GXChatMessageType = new string[] {""} ;
         T000J2_A40000GXChatMessageImage_GXI = new string[] {""} ;
         T000J2_n40000GXChatMessageImage_GXI = new bool[] {false} ;
         T000J2_A270GXChatMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000J2_A276GXChatMessageMeta = new string[] {""} ;
         T000J2_A275GXChatMessageRepeat = new string[] {""} ;
         T000J2_A273GXChatMessageInstance = new string[] {""} ;
         T000J2_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         T000J2_A269GXChatUserDevice = new string[] {""} ;
         T000J2_A274GXChatMessageImage = new string[] {""} ;
         T000J2_n274GXChatMessageImage = new bool[] {false} ;
         T000J14_A267GXChatMessageId = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ267GXChatMessageId = (Guid)(Guid.Empty);
         ZZ268GXChatUserId = (Guid)(Guid.Empty);
         ZZ272GXChatMessageMessage = "";
         ZZ271GXChatMessageType = "";
         ZZ274GXChatMessageImage = "";
         ZZ40000GXChatMessageImage_GXI = "";
         ZZ270GXChatMessageDate = (DateTime)(DateTime.MinValue);
         ZZ276GXChatMessageMeta = "";
         ZZ269GXChatUserDevice = "";
         ZZ275GXChatMessageRepeat = "";
         ZZ273GXChatMessageInstance = "";
         T000J15_A268GXChatUserId = new Guid[] {Guid.Empty} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.commonchatbots.gxchatmessage__default(),
            new Object[][] {
                new Object[] {
               T000J2_A267GXChatMessageId, T000J2_A272GXChatMessageMessage, T000J2_A271GXChatMessageType, T000J2_A40000GXChatMessageImage_GXI, T000J2_n40000GXChatMessageImage_GXI, T000J2_A270GXChatMessageDate, T000J2_A276GXChatMessageMeta, T000J2_A275GXChatMessageRepeat, T000J2_A273GXChatMessageInstance, T000J2_A268GXChatUserId,
               T000J2_A269GXChatUserDevice, T000J2_A274GXChatMessageImage, T000J2_n274GXChatMessageImage
               }
               , new Object[] {
               T000J3_A267GXChatMessageId, T000J3_A272GXChatMessageMessage, T000J3_A271GXChatMessageType, T000J3_A40000GXChatMessageImage_GXI, T000J3_n40000GXChatMessageImage_GXI, T000J3_A270GXChatMessageDate, T000J3_A276GXChatMessageMeta, T000J3_A275GXChatMessageRepeat, T000J3_A273GXChatMessageInstance, T000J3_A268GXChatUserId,
               T000J3_A269GXChatUserDevice, T000J3_A274GXChatMessageImage, T000J3_n274GXChatMessageImage
               }
               , new Object[] {
               T000J4_A268GXChatUserId
               }
               , new Object[] {
               T000J5_A267GXChatMessageId, T000J5_A272GXChatMessageMessage, T000J5_A271GXChatMessageType, T000J5_A40000GXChatMessageImage_GXI, T000J5_n40000GXChatMessageImage_GXI, T000J5_A270GXChatMessageDate, T000J5_A276GXChatMessageMeta, T000J5_A275GXChatMessageRepeat, T000J5_A273GXChatMessageInstance, T000J5_A268GXChatUserId,
               T000J5_A269GXChatUserDevice, T000J5_A274GXChatMessageImage, T000J5_n274GXChatMessageImage
               }
               , new Object[] {
               T000J6_A268GXChatUserId
               }
               , new Object[] {
               T000J7_A267GXChatMessageId
               }
               , new Object[] {
               T000J8_A267GXChatMessageId
               }
               , new Object[] {
               T000J9_A267GXChatMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J14_A267GXChatMessageId
               }
               , new Object[] {
               T000J15_A268GXChatUserId
               }
            }
         );
         Z267GXChatMessageId = (Guid)(Guid.NewGuid( ));
         A267GXChatMessageId = (Guid)(Guid.NewGuid( ));
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtGXChatMessageId_Enabled ;
      private int edtGXChatUserId_Enabled ;
      private int edtGXChatMessageMessage_Enabled ;
      private int edtGXChatMessageType_Enabled ;
      private int imgGXChatMessageImage_Enabled ;
      private int edtGXChatMessageDate_Enabled ;
      private int edtGXChatMessageMeta_Enabled ;
      private int edtGXChatUserDevice_Enabled ;
      private int imgprompt_268_269_Visible ;
      private int edtGXChatMessageRepeat_Enabled ;
      private int edtGXChatMessageInstance_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z271GXChatMessageType ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtGXChatMessageId_Internalname ;
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
      private string edtGXChatMessageId_Jsonclick ;
      private string edtGXChatUserId_Internalname ;
      private string edtGXChatUserId_Jsonclick ;
      private string edtGXChatMessageMessage_Internalname ;
      private string edtGXChatMessageType_Internalname ;
      private string A271GXChatMessageType ;
      private string edtGXChatMessageType_Jsonclick ;
      private string imgGXChatMessageImage_Internalname ;
      private string sImgUrl ;
      private string edtGXChatMessageDate_Internalname ;
      private string edtGXChatMessageDate_Jsonclick ;
      private string edtGXChatMessageMeta_Internalname ;
      private string edtGXChatUserDevice_Internalname ;
      private string imgprompt_268_269_Internalname ;
      private string imgprompt_268_269_Link ;
      private string edtGXChatMessageRepeat_Internalname ;
      private string edtGXChatMessageInstance_Internalname ;
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
      private string sMode20 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ271GXChatMessageType ;
      private DateTime Z270GXChatMessageDate ;
      private DateTime A270GXChatMessageDate ;
      private DateTime ZZ270GXChatMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A274GXChatMessageImage_IsBlob ;
      private bool n40000GXChatMessageImage_GXI ;
      private bool n274GXChatMessageImage ;
      private bool Gx_longc ;
      private string A272GXChatMessageMessage ;
      private string A276GXChatMessageMeta ;
      private string Z272GXChatMessageMessage ;
      private string Z276GXChatMessageMeta ;
      private string ZZ272GXChatMessageMessage ;
      private string ZZ276GXChatMessageMeta ;
      private string Z275GXChatMessageRepeat ;
      private string Z273GXChatMessageInstance ;
      private string Z269GXChatUserDevice ;
      private string A269GXChatUserDevice ;
      private string A40000GXChatMessageImage_GXI ;
      private string A275GXChatMessageRepeat ;
      private string A273GXChatMessageInstance ;
      private string Z40000GXChatMessageImage_GXI ;
      private string ZZ40000GXChatMessageImage_GXI ;
      private string ZZ269GXChatUserDevice ;
      private string ZZ275GXChatMessageRepeat ;
      private string ZZ273GXChatMessageInstance ;
      private string A274GXChatMessageImage ;
      private string Z274GXChatMessageImage ;
      private string ZZ274GXChatMessageImage ;
      private Guid Z267GXChatMessageId ;
      private Guid Z268GXChatUserId ;
      private Guid A268GXChatUserId ;
      private Guid A267GXChatMessageId ;
      private Guid ZZ267GXChatMessageId ;
      private Guid ZZ268GXChatUserId ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000J5_A267GXChatMessageId ;
      private string[] T000J5_A272GXChatMessageMessage ;
      private string[] T000J5_A271GXChatMessageType ;
      private string[] T000J5_A40000GXChatMessageImage_GXI ;
      private bool[] T000J5_n40000GXChatMessageImage_GXI ;
      private DateTime[] T000J5_A270GXChatMessageDate ;
      private string[] T000J5_A276GXChatMessageMeta ;
      private string[] T000J5_A275GXChatMessageRepeat ;
      private string[] T000J5_A273GXChatMessageInstance ;
      private Guid[] T000J5_A268GXChatUserId ;
      private string[] T000J5_A269GXChatUserDevice ;
      private string[] T000J5_A274GXChatMessageImage ;
      private bool[] T000J5_n274GXChatMessageImage ;
      private Guid[] T000J4_A268GXChatUserId ;
      private Guid[] T000J6_A268GXChatUserId ;
      private Guid[] T000J7_A267GXChatMessageId ;
      private Guid[] T000J3_A267GXChatMessageId ;
      private string[] T000J3_A272GXChatMessageMessage ;
      private string[] T000J3_A271GXChatMessageType ;
      private string[] T000J3_A40000GXChatMessageImage_GXI ;
      private bool[] T000J3_n40000GXChatMessageImage_GXI ;
      private DateTime[] T000J3_A270GXChatMessageDate ;
      private string[] T000J3_A276GXChatMessageMeta ;
      private string[] T000J3_A275GXChatMessageRepeat ;
      private string[] T000J3_A273GXChatMessageInstance ;
      private Guid[] T000J3_A268GXChatUserId ;
      private string[] T000J3_A269GXChatUserDevice ;
      private string[] T000J3_A274GXChatMessageImage ;
      private bool[] T000J3_n274GXChatMessageImage ;
      private Guid[] T000J8_A267GXChatMessageId ;
      private Guid[] T000J9_A267GXChatMessageId ;
      private Guid[] T000J2_A267GXChatMessageId ;
      private string[] T000J2_A272GXChatMessageMessage ;
      private string[] T000J2_A271GXChatMessageType ;
      private string[] T000J2_A40000GXChatMessageImage_GXI ;
      private bool[] T000J2_n40000GXChatMessageImage_GXI ;
      private DateTime[] T000J2_A270GXChatMessageDate ;
      private string[] T000J2_A276GXChatMessageMeta ;
      private string[] T000J2_A275GXChatMessageRepeat ;
      private string[] T000J2_A273GXChatMessageInstance ;
      private Guid[] T000J2_A268GXChatUserId ;
      private string[] T000J2_A269GXChatUserDevice ;
      private string[] T000J2_A274GXChatMessageImage ;
      private bool[] T000J2_n274GXChatMessageImage ;
      private Guid[] T000J14_A267GXChatMessageId ;
      private Guid[] T000J15_A268GXChatUserId ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class gxchatmessage__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class gxchatmessage__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class gxchatmessage__gam : DataStoreHelperBase, IDataStoreHelper
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

public class gxchatmessage__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new UpdateCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000J5;
       prmT000J5 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J4;
       prmT000J4 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmT000J6;
       prmT000J6 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       Object[] prmT000J7;
       prmT000J7 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J3;
       prmT000J3 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J8;
       prmT000J8 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J9;
       prmT000J9 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J2;
       prmT000J2 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J10;
       prmT000J10 = new Object[] {
       new ParDef("@GXChatMessageMessage",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageType",GXType.NChar,2,0) ,
       new ParDef("@GXChatMessageImage",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
       new ParDef("@GXChatMessageImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=2, Tbl="GXChatMessage", Fld="GXChatMessageImage"} ,
       new ParDef("@GXChatMessageDate",GXType.DateTime2,8,12) ,
       new ParDef("@GXChatMessageMeta",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageRepeat",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageInstance",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J11;
       prmT000J11 = new Object[] {
       new ParDef("@GXChatMessageMessage",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageType",GXType.NChar,2,0) ,
       new ParDef("@GXChatMessageDate",GXType.DateTime2,8,12) ,
       new ParDef("@GXChatMessageMeta",GXType.NVarChar,2097152,0) ,
       new ParDef("@GXChatMessageRepeat",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageInstance",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0) ,
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J12;
       prmT000J12 = new Object[] {
       new ParDef("@GXChatMessageImage",GXType.Blob,1024,0){Nullable=true,InDB=false} ,
       new ParDef("@GXChatMessageImage_GXI",GXType.VarChar,2048,0){Nullable=true,AddAtt=true, ImgIdx=0, Tbl="GXChatMessage", Fld="GXChatMessageImage"} ,
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J13;
       prmT000J13 = new Object[] {
       new ParDef("@GXChatMessageId",GXType.UniqueIdentifier,12,0)
       };
       Object[] prmT000J14;
       prmT000J14 = new Object[] {
       };
       Object[] prmT000J15;
       prmT000J15 = new Object[] {
       new ParDef("@GXChatUserId",GXType.UniqueIdentifier,256,0) ,
       new ParDef("@GXChatUserDevice",GXType.NVarChar,256,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000J2", "SELECT [GXChatMessageId], [GXChatMessageMessage], [GXChatMessageType], [GXChatMessageImage_GXI], [GXChatMessageDate], [GXChatMessageMeta], [GXChatMessageRepeat], [GXChatMessageInstance], [GXChatUserId], [GXChatUserDevice], [GXChatMessageImage] FROM [GXChatMessage] WITH (UPDLOCK) WHERE [GXChatMessageId] = @GXChatMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J3", "SELECT [GXChatMessageId], [GXChatMessageMessage], [GXChatMessageType], [GXChatMessageImage_GXI], [GXChatMessageDate], [GXChatMessageMeta], [GXChatMessageRepeat], [GXChatMessageInstance], [GXChatUserId], [GXChatUserDevice], [GXChatMessageImage] FROM [GXChatMessage] WHERE [GXChatMessageId] = @GXChatMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J4", "SELECT [GXChatUserId] FROM [GXChatUser] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J5", "SELECT TM1.[GXChatMessageId], TM1.[GXChatMessageMessage], TM1.[GXChatMessageType], TM1.[GXChatMessageImage_GXI], TM1.[GXChatMessageDate], TM1.[GXChatMessageMeta], TM1.[GXChatMessageRepeat], TM1.[GXChatMessageInstance], TM1.[GXChatUserId], TM1.[GXChatUserDevice], TM1.[GXChatMessageImage] FROM [GXChatMessage] TM1 WHERE TM1.[GXChatMessageId] = @GXChatMessageId ORDER BY TM1.[GXChatMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J6", "SELECT [GXChatUserId] FROM [GXChatUser] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J7", "SELECT [GXChatMessageId] FROM [GXChatMessage] WHERE [GXChatMessageId] = @GXChatMessageId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J8", "SELECT TOP 1 [GXChatMessageId] FROM [GXChatMessage] WHERE ( [GXChatMessageId] > @GXChatMessageId) ORDER BY [GXChatMessageId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000J9", "SELECT TOP 1 [GXChatMessageId] FROM [GXChatMessage] WHERE ( [GXChatMessageId] < @GXChatMessageId) ORDER BY [GXChatMessageId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000J10", "INSERT INTO [GXChatMessage]([GXChatMessageMessage], [GXChatMessageType], [GXChatMessageImage], [GXChatMessageImage_GXI], [GXChatMessageDate], [GXChatMessageMeta], [GXChatMessageRepeat], [GXChatMessageInstance], [GXChatUserId], [GXChatUserDevice], [GXChatMessageId]) VALUES(@GXChatMessageMessage, @GXChatMessageType, @GXChatMessageImage, @GXChatMessageImage_GXI, @GXChatMessageDate, @GXChatMessageMeta, @GXChatMessageRepeat, @GXChatMessageInstance, @GXChatUserId, @GXChatUserDevice, @GXChatMessageId)", GxErrorMask.GX_NOMASK,prmT000J10)
          ,new CursorDef("T000J11", "UPDATE [GXChatMessage] SET [GXChatMessageMessage]=@GXChatMessageMessage, [GXChatMessageType]=@GXChatMessageType, [GXChatMessageDate]=@GXChatMessageDate, [GXChatMessageMeta]=@GXChatMessageMeta, [GXChatMessageRepeat]=@GXChatMessageRepeat, [GXChatMessageInstance]=@GXChatMessageInstance, [GXChatUserId]=@GXChatUserId, [GXChatUserDevice]=@GXChatUserDevice  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK,prmT000J11)
          ,new CursorDef("T000J12", "UPDATE [GXChatMessage] SET [GXChatMessageImage]=@GXChatMessageImage, [GXChatMessageImage_GXI]=@GXChatMessageImage_GXI  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK,prmT000J12)
          ,new CursorDef("T000J13", "DELETE FROM [GXChatMessage]  WHERE [GXChatMessageId] = @GXChatMessageId", GxErrorMask.GX_NOMASK,prmT000J13)
          ,new CursorDef("T000J14", "SELECT [GXChatMessageId] FROM [GXChatMessage] ORDER BY [GXChatMessageId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J14,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000J15", "SELECT [GXChatUserId] FROM [GXChatUser] WHERE [GXChatUserId] = @GXChatUserId AND [GXChatUserDevice] = @GXChatUserDevice ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J15,1, GxCacheFrequency.OFF ,true,false )
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
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 1 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 2 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 3 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
             ((string[]) buf[2])[0] = rslt.getString(3, 2);
             ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
             ((string[]) buf[6])[0] = rslt.getLongVarchar(6);
             ((string[]) buf[7])[0] = rslt.getVarchar(7);
             ((string[]) buf[8])[0] = rslt.getVarchar(8);
             ((Guid[]) buf[9])[0] = rslt.getGuid(9);
             ((string[]) buf[10])[0] = rslt.getVarchar(10);
             ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
             ((bool[]) buf[12])[0] = rslt.wasNull(11);
             return;
          case 4 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 5 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 6 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 7 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 12 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
          case 13 :
             ((Guid[]) buf[0])[0] = rslt.getGuid(1);
             return;
    }
 }

}

}
