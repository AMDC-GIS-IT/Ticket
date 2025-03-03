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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.k2bfsg {
   public class recoverpasswordstep1 : GXHttpHandler, System.Web.SessionState.IRequiresSessionState
   {
      public recoverpasswordstep1( )
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

      public recoverpasswordstep1( IGxContext context )
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
            ValidateSpaRequest();
            PA4G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS4G2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  WE4G2( ) ;
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Recover Password Step 1") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 184460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2024188403240", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.recoverpasswordstep1.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UserAuthTypeName, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_boolean_hidden_field( context, "vCAPTCHAISCORRECT", AV9CaptchaIsCorrect);
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV45UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vLASTEMAILSENT", context.localUtil.TToC( AV22LastEmailSent, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "vSHOWDETAILEDMESSAGES", AV35ShowDetailedMessages);
         GxWebStd.gx_hidden_field( context, "vERRORMESSAGE", StringUtil.RTrim( AV15ErrorMessage));
         GxWebStd.gx_hidden_field( context, "vUSER_Email", AV44User.gxTpr_Email);
      }

      protected void RenderHtmlCloseForm4G2( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RecoverPasswordStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Recover Password Step 1" ;
      }

      protected void WB4G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            RenderHtmlHeaders( ) ;
            RenderHtmlOpenForm( ) ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTitlecell_attributes_attributes_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_4G2( true) ;
         }
         else
         {
            wb_table1_15_4G2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_4G2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumns_maincolumnstable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumncontainertable_column_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_username_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "Nombre de usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, StringUtil.RTrim( AV57UserName), StringUtil.RTrim( context.localUtil.Format( AV57UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavUsername_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_useremail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUseremail_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUseremail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUseremail_Internalname, "Correo electrónico", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUseremail_Internalname, AV58UserEmail, StringUtil.RTrim( context.localUtil.Format( AV58UserEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUseremail_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUseremail_Visible, edtavUseremail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMEMail", "left", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_userbirthday_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserbirthday_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUserbirthday_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserbirthday_Internalname, "Fecha de nacimiento", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavUserbirthday_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavUserbirthday_Internalname, context.localUtil.Format(AV59UserBirthDay, "99/99/9999"), context.localUtil.Format( AV59UserBirthDay, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserbirthday_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", edtavUserbirthday_Visible, edtavUserbirthday_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "GeneXusSecurityCommon\\GAMDate", "right", false, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_bitmap( context, edtavUserbirthday_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtavUserbirthday_Visible==0)||(edtavUserbirthday_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            context.WriteHtmlTextNl( "</div>") ;
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
            GxWebStd.gx_div_start( context, divTable_container_userfirstname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavUserfirstname_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavUserfirstname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUserfirstname_Internalname, "Apellido", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUserfirstname_Internalname, StringUtil.RTrim( AV60UserFirstName), StringUtil.RTrim( context.localUtil.Format( AV60UserFirstName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUserfirstname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavUserfirstname_Visible, edtavUserfirstname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divColumncontainertable_column1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCaptchadescription_Internalname, "Please insert the text below", "", "", lblCaptchadescription_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "SideLabel", 0, "", lblCaptchadescription_Visible, 1, 0, 0, "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_captchaimage_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Static Bitmap Variable */
            ClassString = "Attribute_Trn";
            StyleString = "";
            AV61CaptchaImage_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV61CaptchaImage))&&String.IsNullOrEmpty(StringUtil.RTrim( AV66Captchaimage_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV61CaptchaImage)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV61CaptchaImage)) ? AV66Captchaimage_GXI : context.PathToRelativeUrl( AV61CaptchaImage));
            GxWebStd.gx_bitmap( context, imgavCaptchaimage_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgavCaptchaimage_Visible, 0, "", "", 0, 1, 180, "px", 75, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, AV61CaptchaImage_IsBlob, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_captchatext_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCaptchatext_Internalname, StringUtil.RTrim( AV62CaptchaText), StringUtil.RTrim( context.localUtil.Format( AV62CaptchaText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCaptchatext_Jsonclick, 0, "Attribute_Trn", "", "", "", "", edtavCaptchatext_Visible, edtavCaptchatext_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "K2BDescription", "left", true, "", "HLP_K2BFSG\\RecoverPasswordStep1.htm");
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_72_4G2( true) ;
         }
         else
         {
            wb_table2_72_4G2( false) ;
         }
         return  ;
      }

      protected void wb_table2_72_4G2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START4G2( )
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
            Form.Meta.addItem("description", "Recover Password Step 1", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4G0( ) ;
      }

      protected void WS4G2( )
      {
         START4G2( ) ;
         EVT4G2( ) ;
      }

      protected void EVT4G2( )
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
                        else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Refresh */
                           E114G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E124G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! wbErr )
                           {
                              Rfr0gs = false;
                              if ( ! Rfr0gs )
                              {
                                 /* Execute user event: Enter */
                                 E134G2 ();
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Load */
                           E144G2 ();
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

      protected void WE4G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm4G2( ) ;
            }
         }
      }

      protected void PA4G2( )
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
               GX_FocusControl = edtavUsername_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4G2( ) ;
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

      protected void RF4G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E114G2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E144G2 ();
            WB4G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4G2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV45UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV45UserAuthTypeName, "")), context));
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E124G2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            AV57UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV57UserName", AV57UserName);
            AV58UserEmail = cgiGet( edtavUseremail_Internalname);
            AssignAttri("", false, "AV58UserEmail", AV58UserEmail);
            if ( context.localUtil.VCDate( cgiGet( edtavUserbirthday_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"User Birth Day"}), 1, "vUSERBIRTHDAY");
               GX_FocusControl = edtavUserbirthday_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV59UserBirthDay = DateTime.MinValue;
               AssignAttri("", false, "AV59UserBirthDay", context.localUtil.Format(AV59UserBirthDay, "99/99/9999"));
            }
            else
            {
               AV59UserBirthDay = context.localUtil.CToD( cgiGet( edtavUserbirthday_Internalname), 2);
               AssignAttri("", false, "AV59UserBirthDay", context.localUtil.Format(AV59UserBirthDay, "99/99/9999"));
            }
            AV60UserFirstName = cgiGet( edtavUserfirstname_Internalname);
            AssignAttri("", false, "AV60UserFirstName", AV60UserFirstName);
            AV61CaptchaImage = cgiGet( imgavCaptchaimage_Internalname);
            AV62CaptchaText = cgiGet( edtavCaptchatext_Internalname);
            AssignAttri("", false, "AV62CaptchaText", AV62CaptchaText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S132( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
         AV6AmountOfCharacters = 5;
         AssignAttri("", false, "AV6AmountOfCharacters", StringUtil.LTrimStr( (decimal)(AV6AmountOfCharacters), 4, 0));
         /* Execute user subroutine: 'SHOWCAPTCHAIFNEEDED' */
         S152 ();
         if (returnInSub) return;
      }

      protected void S112( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void E114G2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E124G2 ();
         if (returnInSub) return;
      }

      protected void E124G2( )
      {
         /* Start Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_OPENPAGE' */
         S132 ();
         if (returnInSub) return;
      }

      protected void S122( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadrecoverpasswordrequirementsparameters(context ).execute( out  AV27RequireEmail, out  AV28RequireFirstName, out  AV26RequireBirthday) ;
         edtavUserbirthday_Visible = 1;
         AssignProp("", false, edtavUserbirthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserbirthday_Visible), 5, 0), true);
         edtavUseremail_Visible = 1;
         AssignProp("", false, edtavUseremail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseremail_Visible), 5, 0), true);
         edtavUserfirstname_Visible = 1;
         AssignProp("", false, edtavUserfirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserfirstname_Visible), 5, 0), true);
         if ( ! AV26RequireBirthday )
         {
            edtavUserbirthday_Visible = 0;
            AssignProp("", false, edtavUserbirthday_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserbirthday_Visible), 5, 0), true);
         }
         if ( ! AV27RequireEmail )
         {
            edtavUseremail_Visible = 0;
            AssignProp("", false, edtavUseremail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUseremail_Visible), 5, 0), true);
         }
         if ( ! AV28RequireFirstName )
         {
            edtavUserfirstname_Visible = 0;
            AssignProp("", false, edtavUserfirstname_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavUserfirstname_Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ADDARTIFICIALDELAY' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'EVALUATECAPTCHACORRECTNESS' */
         S172 ();
         if (returnInSub) return;
         if ( AV9CaptchaIsCorrect )
         {
            new GeneXus.Programs.k2bfsg.loadrecoverpasswordrequirementsparameters(context ).execute( out  AV27RequireEmail, out  AV28RequireFirstName, out  AV26RequireBirthday) ;
            AV15ErrorMessage = "";
            AssignAttri("", false, "AV15ErrorMessage", AV15ErrorMessage);
            AV44User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV45UserAuthTypeName, AV57UserName, out  AV16Errors);
            if ( AV16Errors.Count == 0 )
            {
               AV17ExecuteAction = true;
               if ( AV26RequireBirthday && ( DateTimeUtil.ResetTime ( AV59UserBirthDay ) != DateTimeUtil.ResetTime ( AV44User.gxTpr_Birthday ) ) )
               {
                  AV17ExecuteAction = false;
               }
               if ( AV27RequireEmail && ( StringUtil.StrCmp(AV58UserEmail, AV44User.gxTpr_Email) != 0 ) )
               {
                  AV17ExecuteAction = false;
               }
               if ( AV28RequireFirstName && ( StringUtil.StrCmp(AV60UserFirstName, AV44User.gxTpr_Firstname) != 0 ) )
               {
                  AV17ExecuteAction = false;
               }
               if ( AV17ExecuteAction )
               {
                  /* Execute user subroutine: 'EXECUTEACTIONTORECOVER' */
                  S182 ();
                  if (returnInSub) return;
               }
               else
               {
                  AV15ErrorMessage = "El candidato falló las pruebas de identidad";
                  AssignAttri("", false, "AV15ErrorMessage", AV15ErrorMessage);
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S192 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S192 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S192 ();
            if (returnInSub) return;
         }
      }

      protected void S182( )
      {
         /* 'EXECUTEACTIONTORECOVER' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadrecoverpasswordemailparameters(context ).execute( out  AV31SendPasswordEmail, out  AV24MailSubject, out  AV5MailMessage, out  AV42SMTPServerName, out  AV43SMTPUserName, out  AV38SMTPPassword, out  AV39SMTPPort, out  AV37SMTPAuthentication, out  AV41SMTPSenderName, out  AV40SMTPSenderAddress, out  AV25MinMinutesBetweenEmails, out  AV33ServerHost, out  AV34ServerPort, out  AV32ServerBaseURL) ;
         AV21KeyToChangePassword = AV44User.recoverpasswordbykey(out  AV16Errors);
         if ( AV16Errors.Count == 0 )
         {
            if ( AV31SendPasswordEmail )
            {
               /* Execute user subroutine: 'GETLASTEMAILSENTTIME' */
               S202 ();
               if (returnInSub) return;
               if ( (DateTime.MinValue==AV22LastEmailSent) || ( DateTimeUtil.TAdd( AV22LastEmailSent, 60*(AV25MinMinutesBetweenEmails)) <= DateTimeUtil.ServerNow( context, pr_default) ) )
               {
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33ServerHost)) && ! (0==AV34ServerPort) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32ServerBaseURL)) )
                  {
                     AV8CallbackLink = StringUtil.Format( "http://%1:%2%3%4", AV33ServerHost, StringUtil.LTrimStr( (decimal)(AV34ServerPort), 5, 0), AV32ServerBaseURL, formatLink("k2bfsg.recoverpasswordstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21KeyToChangePassword))}, new string[] {"KeyToChangePassword"}) , "", "", "", "", "");
                     AV47UserFirstNameSafe = GxRegex.Replace(AV44User.gxTpr_Firstname,"<script[^>]*>.*</script>","");
                     AV47UserFirstNameSafe = GxRegex.Replace(AV47UserFirstNameSafe,"<[^>]*>","");
                     AV49UserLastNameSafe = GxRegex.Replace(AV44User.gxTpr_Lastname,"<script[^>]*>.*</script>","");
                     AV49UserLastNameSafe = GxRegex.Replace(AV49UserLastNameSafe,"<[^>]*>","");
                     AV12DirTo.Address = AV44User.gxTpr_Email;
                     AV12DirTo.Name = StringUtil.Format( "%1 %2", AV47UserFirstNameSafe, AV49UserLastNameSafe, "", "", "", "", "", "", "");
                     AV23Mail.To.Add(AV12DirTo);
                     AV23Mail.Subject = StringUtil.Trim( AV24MailSubject);
                     AV46ReplacedMailMessage = StringUtil.Format( AV5MailMessage, AV8CallbackLink, AV47UserFirstNameSafe, AV49UserLastNameSafe, "", "", "", "", "", "");
                     AV23Mail.HTMLText = AV46ReplacedMailMessage;
                     AV36SMTP.Host = StringUtil.Trim( AV42SMTPServerName);
                     AV36SMTP.Port = AV39SMTPPort;
                     AV36SMTP.Secure = 0;
                     AV36SMTP.Authentication = AV37SMTPAuthentication;
                     AV36SMTP.UserName = StringUtil.Trim( AV43SMTPUserName);
                     AV36SMTP.Password = StringUtil.Trim( AV38SMTPPassword);
                     AV36SMTP.Sender.Name = AV41SMTPSenderName;
                     AV36SMTP.Sender.Address = AV40SMTPSenderAddress;
                     AV20isOK = AV36SMTP.Login();
                     if ( AV36SMTP.ErrCode == 0 )
                     {
                        AV36SMTP.Send(AV23Mail);
                        if ( AV36SMTP.ErrCode != 0 )
                        {
                           AV15ErrorMessage = StringUtil.Format( "Fallo al enviar correo electrónico: %1 (%2)", AV36SMTP.ErrDescription, StringUtil.LTrimStr( (decimal)(AV36SMTP.ErrCode), 4, 0), "", "", "", "", "", "", "");
                           AssignAttri("", false, "AV15ErrorMessage", AV15ErrorMessage);
                           /* Execute user subroutine: 'DISPLAYMESSAGES' */
                           S192 ();
                           if (returnInSub) return;
                        }
                        else
                        {
                           /* Execute user subroutine: 'SETLASTEMAILSENTTIMETONOW' */
                           S212 ();
                           if (returnInSub) return;
                           /* Execute user subroutine: 'DISPLAYMESSAGES' */
                           S192 ();
                           if (returnInSub) return;
                        }
                        AV36SMTP.Logout();
                     }
                     else
                     {
                        /* Execute user subroutine: 'DISPLAYMESSAGES' */
                        S192 ();
                        if (returnInSub) return;
                     }
                  }
                  else
                  {
                     AV15ErrorMessage = "Configuración de link inválido para correo electrónico";
                     AssignAttri("", false, "AV15ErrorMessage", AV15ErrorMessage);
                     /* Execute user subroutine: 'DISPLAYMESSAGES' */
                     S192 ();
                     if (returnInSub) return;
                  }
               }
               else
               {
                  /* Execute user subroutine: 'DISPLAYMESSAGES' */
                  S192 ();
                  if (returnInSub) return;
               }
            }
            else
            {
               CallWebObject(formatLink("k2bfsg.recoverpasswordstep2.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV21KeyToChangePassword))}, new string[] {"KeyToChangePassword"}) );
               context.wjLocDisableFrm = 1;
            }
            context.CommitDataStores("k2bfsg.recoverpasswordstep1",pr_default);
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S192 ();
            if (returnInSub) return;
         }
      }

      protected void S162( )
      {
         /* 'ADDARTIFICIALDELAY' Routine */
         returnInSub = false;
         AV30seconds = (short)(NumberUtil.Random( )*3);
         AV29result = GXUtil.Sleep( AV30seconds);
      }

      protected void S202( )
      {
         /* 'GETLASTEMAILSENTTIME' Routine */
         returnInSub = false;
         AV18GAMUserAttribute = AV44User.getattribute("LastPasswordRecoveryEmailDate", out  AV16Errors);
         if ( AV16Errors.Count == 0 )
         {
            AV22LastEmailSent = context.localUtil.CToT( AV18GAMUserAttribute.gxTpr_Value, 2);
            AssignAttri("", false, "AV22LastEmailSent", context.localUtil.TToC( AV22LastEmailSent, 8, 5, 0, 3, "/", ":", " "));
         }
         else
         {
            AV22LastEmailSent = (DateTime)(DateTime.MinValue);
            AssignAttri("", false, "AV22LastEmailSent", context.localUtil.TToC( AV22LastEmailSent, 8, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void S212( )
      {
         /* 'SETLASTEMAILSENTTIMETONOW' Routine */
         returnInSub = false;
         AV18GAMUserAttribute = AV44User.getattribute("LastPasswordRecoveryEmailDate", out  AV16Errors);
         if ( AV16Errors.Count == 0 )
         {
            AV22LastEmailSent = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "AV22LastEmailSent", context.localUtil.TToC( AV22LastEmailSent, 8, 5, 0, 3, "/", ":", " "));
            AV18GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV22LastEmailSent, 8, 5, 0, 3, "/", ":", " ");
            AV44User.setattribute( AV18GAMUserAttribute, out  AV16Errors);
         }
         else
         {
            AV18GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
            AV18GAMUserAttribute.gxTpr_Id = "LastPasswordRecoveryEmailDate";
            AV22LastEmailSent = DateTimeUtil.ServerNow( context, pr_default);
            AssignAttri("", false, "AV22LastEmailSent", context.localUtil.TToC( AV22LastEmailSent, 8, 5, 0, 3, "/", ":", " "));
            AV18GAMUserAttribute.gxTpr_Value = context.localUtil.TToC( AV22LastEmailSent, 8, 5, 0, 3, "/", ":", " ");
            AV18GAMUserAttribute.gxTpr_Ismultivalue = false;
            AV44User.setattribute( AV18GAMUserAttribute, out  AV16Errors);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E134G2 ();
         if (returnInSub) return;
      }

      protected void E134G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S142 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44User", AV44User);
      }

      protected void S192( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         new GeneXus.Programs.k2bfsg.loadmessageparameters(context ).execute( ref  AV35ShowDetailedMessages) ;
         AssignAttri("", false, "AV35ShowDetailedMessages", AV35ShowDetailedMessages);
         if ( AV35ShowDetailedMessages )
         {
            GX_msglist.addItem("Un correo electrónico ha sido enviado a su casilla");
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ErrorMessage)) )
            {
               GX_msglist.addItem(AV15ErrorMessage);
            }
            AV65GXV1 = 1;
            while ( AV65GXV1 <= AV16Errors.Count )
            {
               AV14Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16Errors.Item(AV65GXV1));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV14Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV14Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV65GXV1 = (int)(AV65GXV1+1);
            }
         }
         else
         {
            CallWebObject(formatLink("k2bfsg.emailsent.aspx") );
            context.wjLocDisableFrm = 1;
         }
      }

      protected void S172( )
      {
         /* 'EVALUATECAPTCHACORRECTNESS' Routine */
         returnInSub = false;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV11CaptchaRequiredText) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11CaptchaRequiredText)) )
         {
            AV9CaptchaIsCorrect = false;
            AssignAttri("", false, "AV9CaptchaIsCorrect", AV9CaptchaIsCorrect);
         }
         else
         {
            if ( StringUtil.StrCmp(AV11CaptchaRequiredText, AV62CaptchaText) == 0 )
            {
               AV9CaptchaIsCorrect = true;
               AssignAttri("", false, "AV9CaptchaIsCorrect", AV9CaptchaIsCorrect);
            }
            else
            {
               AV9CaptchaIsCorrect = false;
               AssignAttri("", false, "AV9CaptchaIsCorrect", AV9CaptchaIsCorrect);
            }
         }
      }

      protected void S222( )
      {
         /* 'CREATENEWCAPTCHA' Routine */
         returnInSub = false;
         new k2bsessionset(context ).execute(  "SessionCaptchaIteSessionCaptchaItem",  AV10CaptchaProvider.generatestringtoken(AV6AmountOfCharacters)) ;
      }

      protected void S152( )
      {
         /* 'SHOWCAPTCHAIFNEEDED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'CREATENEWCAPTCHA' */
         S222 ();
         if (returnInSub) return;
         new k2bsessionget(context ).execute(  "SessionCaptchaIteSessionCaptchaItem", out  AV11CaptchaRequiredText) ;
         lblCaptchadescription_Visible = 1;
         AssignProp("", false, lblCaptchadescription_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblCaptchadescription_Visible), 5, 0), true);
         imgavCaptchaimage_Visible = 1;
         AssignProp("", false, imgavCaptchaimage_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgavCaptchaimage_Visible), 5, 0), true);
         edtavCaptchatext_Visible = 1;
         AssignProp("", false, edtavCaptchatext_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCaptchatext_Visible), 5, 0), true);
         AV7Base64String = AV10CaptchaProvider.generateimage(180, 75, AV11CaptchaRequiredText);
         AV62CaptchaText = "";
         AssignAttri("", false, "AV62CaptchaText", AV62CaptchaText);
         AV61CaptchaImage = "data:image/jpeg;charset=utf-8;base64," + AV7Base64String;
         AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61CaptchaImage)) ? AV66Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV61CaptchaImage))), true);
         AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV61CaptchaImage), true);
         AV66Captchaimage_GXI = GXDbFile.PathToUrl( "data:image/jpeg;charset=utf-8;base64,"+AV7Base64String);
         AssignProp("", false, imgavCaptchaimage_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV61CaptchaImage)) ? AV66Captchaimage_GXI : context.convertURL( context.PathToRelativeUrl( AV61CaptchaImage))), true);
         AssignProp("", false, imgavCaptchaimage_Internalname, "SrcSet", context.GetImageSrcSet( AV61CaptchaImage), true);
      }

      protected void nextLoad( )
      {
      }

      protected void E144G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table2_72_4G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "", "Confirmar", bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_72_4G2e( true) ;
         }
         else
         {
            wb_table2_72_4G2e( false) ;
         }
      }

      protected void wb_table1_15_4G2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTitlecontainertable_attributes_Internalname, tblTitlecontainertable_attributes_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock_attributes_attributes_Internalname, "Recover Password", "", "", lblTextblock_attributes_attributes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock_Subtitle", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RecoverPasswordStep1.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_4G2e( true) ;
         }
         else
         {
            wb_table1_15_4G2e( false) ;
         }
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
         PA4G2( ) ;
         WS4G2( ) ;
         WE4G2( ) ;
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
         AddStyleSheetFile("K2BControlBeautify/toastr-master/toastr.min.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188404740", true, true);
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
         context.AddJavascriptSource("k2bfsg/recoverpasswordstep1.js", "?2024188404745", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTextblock_attributes_attributes_Internalname = "TEXTBLOCK_ATTRIBUTES_ATTRIBUTES";
         tblTitlecontainertable_attributes_Internalname = "TITLECONTAINERTABLE_ATTRIBUTES";
         divTitlecell_attributes_attributes_Internalname = "TITLECELL_ATTRIBUTES_ATTRIBUTES";
         edtavUsername_Internalname = "vUSERNAME";
         divTable_container_username_Internalname = "TABLE_CONTAINER_USERNAME";
         edtavUseremail_Internalname = "vUSEREMAIL";
         divTable_container_useremail_Internalname = "TABLE_CONTAINER_USEREMAIL";
         edtavUserbirthday_Internalname = "vUSERBIRTHDAY";
         divTable_container_userbirthday_Internalname = "TABLE_CONTAINER_USERBIRTHDAY";
         edtavUserfirstname_Internalname = "vUSERFIRSTNAME";
         divTable_container_userfirstname_Internalname = "TABLE_CONTAINER_USERFIRSTNAME";
         divColumncontainertable_column_Internalname = "COLUMNCONTAINERTABLE_COLUMN";
         lblCaptchadescription_Internalname = "CAPTCHADESCRIPTION";
         imgavCaptchaimage_Internalname = "vCAPTCHAIMAGE";
         divTable_container_captchaimage_Internalname = "TABLE_CONTAINER_CAPTCHAIMAGE";
         edtavCaptchatext_Internalname = "vCAPTCHATEXT";
         divTable_container_captchatext_Internalname = "TABLE_CONTAINER_CAPTCHATEXT";
         divColumncontainertable_column1_Internalname = "COLUMNCONTAINERTABLE_COLUMN1";
         divColumns_maincolumnstable_Internalname = "COLUMNS_MAINCOLUMNSTABLE";
         bttConfirm_Internalname = "CONFIRM";
         tblActionscontainertableleft_actions_Internalname = "ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = "RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
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
         edtavCaptchatext_Jsonclick = "";
         edtavCaptchatext_Enabled = 1;
         edtavCaptchatext_Visible = 1;
         imgavCaptchaimage_Visible = 1;
         lblCaptchadescription_Visible = 1;
         edtavUserfirstname_Jsonclick = "";
         edtavUserfirstname_Enabled = 1;
         edtavUserfirstname_Visible = 1;
         edtavUserbirthday_Jsonclick = "";
         edtavUserbirthday_Enabled = 1;
         edtavUserbirthday_Visible = 1;
         edtavUseremail_Jsonclick = "";
         edtavUseremail_Enabled = 1;
         edtavUseremail_Visible = 1;
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         context.GX_msglist.DisplayMode = 1;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV45UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'edtavUserbirthday_Visible',ctrl:'vUSERBIRTHDAY',prop:'Visible'},{av:'edtavUseremail_Visible',ctrl:'vUSEREMAIL',prop:'Visible'},{av:'edtavUserfirstname_Visible',ctrl:'vUSERFIRSTNAME',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E134G2',iparms:[{av:'AV9CaptchaIsCorrect',fld:'vCAPTCHAISCORRECT',pic:''},{av:'AV45UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true},{av:'AV57UserName',fld:'vUSERNAME',pic:''},{av:'AV59UserBirthDay',fld:'vUSERBIRTHDAY',pic:''},{av:'AV58UserEmail',fld:'vUSEREMAIL',pic:''},{av:'AV60UserFirstName',fld:'vUSERFIRSTNAME',pic:''},{av:'AV62CaptchaText',fld:'vCAPTCHATEXT',pic:''},{av:'AV22LastEmailSent',fld:'vLASTEMAILSENT',pic:'99/99/99 99:99'},{av:'AV44User.gxTpr_Email',ctrl:'vUSER',prop:'Email'},{av:'AV35ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:''},{av:'AV15ErrorMessage',fld:'vERRORMESSAGE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV15ErrorMessage',fld:'vERRORMESSAGE',pic:''},{av:'AV9CaptchaIsCorrect',fld:'vCAPTCHAISCORRECT',pic:''},{av:'AV35ShowDetailedMessages',fld:'vSHOWDETAILEDMESSAGES',pic:''},{av:'AV22LastEmailSent',fld:'vLASTEMAILSENT',pic:'99/99/99 99:99'}]}");
         setEventMetadata("VALIDV_USERBIRTHDAY","{handler:'Validv_Userbirthday',iparms:[]");
         setEventMetadata("VALIDV_USERBIRTHDAY",",oparms:[]}");
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
         AV44User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         AV45UserAuthTypeName = "";
         GXKey = "";
         AV22LastEmailSent = (DateTime)(DateTime.MinValue);
         AV15ErrorMessage = "";
         GX_FocusControl = "";
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV57UserName = "";
         AV58UserEmail = "";
         AV59UserBirthDay = DateTime.MinValue;
         AV60UserFirstName = "";
         lblCaptchadescription_Jsonclick = "";
         AV61CaptchaImage = "";
         AV66Captchaimage_GXI = "";
         sImgUrl = "";
         AV62CaptchaText = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         Form = new GXWebForm();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV16Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV24MailSubject = "";
         AV5MailMessage = "";
         AV42SMTPServerName = "";
         AV43SMTPUserName = "";
         AV38SMTPPassword = "";
         AV41SMTPSenderName = "";
         AV40SMTPSenderAddress = "";
         AV33ServerHost = "";
         AV32ServerBaseURL = "";
         AV21KeyToChangePassword = "";
         AV8CallbackLink = "";
         AV47UserFirstNameSafe = "";
         AV49UserLastNameSafe = "";
         AV12DirTo = new GeneXus.Mail.GXMailRecipient();
         AV23Mail = new GeneXus.Mail.GXMailMessage();
         AV46ReplacedMailMessage = "";
         AV36SMTP = new GeneXus.Mail.GXSMTPSession(context.GetPhysicalPath());
         AV18GAMUserAttribute = new GeneXus.Programs.genexussecurity.SdtGAMUserAttribute(context);
         AV14Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV11CaptchaRequiredText = "";
         AV10CaptchaProvider = new SdtK2BToolsCaptchaProvider(context);
         AV7Base64String = "";
         sStyleString = "";
         bttConfirm_Jsonclick = "";
         lblTextblock_attributes_attributes_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.recoverpasswordstep1__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.recoverpasswordstep1__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.recoverpasswordstep1__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.recoverpasswordstep1__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6AmountOfCharacters ;
      private short AV39SMTPPort ;
      private short AV37SMTPAuthentication ;
      private short AV25MinMinutesBetweenEmails ;
      private short AV20isOK ;
      private short AV30seconds ;
      private short AV29result ;
      private short nGXWrapped ;
      private int edtavUsername_Enabled ;
      private int edtavUseremail_Visible ;
      private int edtavUseremail_Enabled ;
      private int edtavUserbirthday_Visible ;
      private int edtavUserbirthday_Enabled ;
      private int edtavUserfirstname_Visible ;
      private int edtavUserfirstname_Enabled ;
      private int lblCaptchadescription_Visible ;
      private int imgavCaptchaimage_Visible ;
      private int edtavCaptchatext_Visible ;
      private int edtavCaptchatext_Enabled ;
      private int AV34ServerPort ;
      private int AV65GXV1 ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string AV45UserAuthTypeName ;
      private string GXKey ;
      private string AV15ErrorMessage ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divResponsivetable_mainattributes_attributes_Internalname ;
      private string divTitlecell_attributes_attributes_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divColumns_maincolumnstable_Internalname ;
      private string divColumncontainertable_column_Internalname ;
      private string divTable_container_username_Internalname ;
      private string edtavUsername_Internalname ;
      private string TempTags ;
      private string AV57UserName ;
      private string edtavUsername_Jsonclick ;
      private string divTable_container_useremail_Internalname ;
      private string edtavUseremail_Internalname ;
      private string edtavUseremail_Jsonclick ;
      private string divTable_container_userbirthday_Internalname ;
      private string edtavUserbirthday_Internalname ;
      private string edtavUserbirthday_Jsonclick ;
      private string divTable_container_userfirstname_Internalname ;
      private string edtavUserfirstname_Internalname ;
      private string AV60UserFirstName ;
      private string edtavUserfirstname_Jsonclick ;
      private string divColumncontainertable_column1_Internalname ;
      private string lblCaptchadescription_Internalname ;
      private string lblCaptchadescription_Jsonclick ;
      private string divTable_container_captchaimage_Internalname ;
      private string sImgUrl ;
      private string imgavCaptchaimage_Internalname ;
      private string divTable_container_captchatext_Internalname ;
      private string edtavCaptchatext_Internalname ;
      private string AV62CaptchaText ;
      private string edtavCaptchatext_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string AV24MailSubject ;
      private string AV5MailMessage ;
      private string AV42SMTPServerName ;
      private string AV43SMTPUserName ;
      private string AV38SMTPPassword ;
      private string AV41SMTPSenderName ;
      private string AV40SMTPSenderAddress ;
      private string AV33ServerHost ;
      private string AV21KeyToChangePassword ;
      private string AV8CallbackLink ;
      private string AV47UserFirstNameSafe ;
      private string AV49UserLastNameSafe ;
      private string AV46ReplacedMailMessage ;
      private string AV11CaptchaRequiredText ;
      private string AV7Base64String ;
      private string sStyleString ;
      private string tblActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string tblTitlecontainertable_attributes_Internalname ;
      private string lblTextblock_attributes_attributes_Internalname ;
      private string lblTextblock_attributes_attributes_Jsonclick ;
      private DateTime AV22LastEmailSent ;
      private DateTime AV59UserBirthDay ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV9CaptchaIsCorrect ;
      private bool AV35ShowDetailedMessages ;
      private bool wbLoad ;
      private bool AV61CaptchaImage_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV27RequireEmail ;
      private bool AV28RequireFirstName ;
      private bool AV26RequireBirthday ;
      private bool AV17ExecuteAction ;
      private bool AV31SendPasswordEmail ;
      private string AV58UserEmail ;
      private string AV66Captchaimage_GXI ;
      private string AV32ServerBaseURL ;
      private string AV61CaptchaImage ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private SdtK2BToolsCaptchaProvider AV10CaptchaProvider ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Mail.GXMailMessage AV23Mail ;
      private GeneXus.Mail.GXMailRecipient AV12DirTo ;
      private GeneXus.Mail.GXSMTPSession AV36SMTP ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16Errors ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV14Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUserAttribute AV18GAMUserAttribute ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV44User ;
   }

   public class recoverpasswordstep1__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class recoverpasswordstep1__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class recoverpasswordstep1__gam : DataStoreHelperBase, IDataStoreHelper
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

public class recoverpasswordstep1__default : DataStoreHelperBase, IDataStoreHelper
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
