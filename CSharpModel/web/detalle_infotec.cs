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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class detalle_infotec : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               nDynComponent = 1;
               sCompPrefix = GetPar( "sCompPrefix");
               sSFPrefix = GetPar( "sSFPrefix");
               Gx_mode = GetPar( "Mode");
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               AV8correlativo = (int)(NumberUtil.Val( GetPar( "correlativo"), "."));
               AssignAttri(sPrefix, false, "AV8correlativo", StringUtil.LTrimStr( (decimal)(AV8correlativo), 9, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV8correlativo});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
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
               gxfirstwebparm = GetFirstPar( "Mode");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "Mode");
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
               Gx_mode = gxfirstwebparm;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV8correlativo = (int)(NumberUtil.Val( GetPar( "correlativo"), "."));
                  AssignAttri(sPrefix, false, "AV8correlativo", StringUtil.LTrimStr( (decimal)(AV8correlativo), 9, 0));
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_web_controls( ) ;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "detalle_infotec", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtnombre_emp_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
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

      public void execute( string aP0_Gx_mode ,
                           int aP1_correlativo )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8correlativo = aP1_correlativo;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
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
            RenderHtmlCloseForm0G17( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            RenderHtmlHeaders( ) ;
         }
         RenderHtmlOpenForm( ) ;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "detalle_infotec.aspx");
            context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besmaintable_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2beserrviewercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2besdataareacontainercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2babstracttabledataareacontainer_Internalname, 1, 0, "px", 0, "px", "Table_DataAreaContainer Table_TransactionDataAreaContainer K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btrnformmaintablecell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributesinformsection1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercorrelativo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcorrelativo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcorrelativo_Internalname, "correlativo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
         GxWebStd.gx_single_line_edit( context, edtcorrelativo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A238correlativo), 9, 0, ".", "")), StringUtil.LTrim( ((edtcorrelativo_Enabled!=0) ? context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A238correlativo), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcorrelativo_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcorrelativo_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_emp_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtnombre_emp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_emp_Internalname, "nombre_emp", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A239nombre_emp", A239nombre_emp);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         ClassString = edtnombre_emp_Class;
         StyleString = "";
         ClassString = edtnombre_emp_Class;
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_emp_Internalname, A239nombre_emp, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", 0, 1, edtnombre_emp_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercargo_emp_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcargo_emp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcargo_emp_Internalname, "cargo_emp", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A240cargo_emp", A240cargo_emp);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcargo_emp_Internalname, A240cargo_emp, StringUtil.RTrim( context.localUtil.Format( A240cargo_emp, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcargo_emp_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcargo_emp_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerfecha_registro_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtfecha_registro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtfecha_registro_Internalname, "fecha_registro", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtfecha_registro_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtfecha_registro_Internalname, context.localUtil.Format(A241fecha_registro, "99/99/99"), context.localUtil.Format( A241fecha_registro, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtfecha_registro_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtfecha_registro_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
         GxWebStd.gx_bitmap( context, edtfecha_registro_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtfecha_registro_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestatus_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtestatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtestatus_Internalname, "estatus", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A243estatus", A243estatus);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtestatus_Internalname, A243estatus, StringUtil.RTrim( context.localUtil.Format( A243estatus, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtestatus_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtestatus_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertrabajo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edttrabajo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edttrabajo_Internalname, "trabajo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A244trabajo", A244trabajo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edttrabajo_Internalname, A244trabajo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", 0, 1, edttrabajo_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_usuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtnombre_usuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_usuario_Internalname, "nombre_usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A245nombre_usuario", A245nombre_usuario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_usuario_Internalname, A245nombre_usuario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtnombre_usuario_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdepto_usuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtdepto_usuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdepto_usuario_Internalname, "depto_usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A246depto_usuario", A246depto_usuario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtdepto_usuario_Internalname, A246depto_usuario, StringUtil.RTrim( context.localUtil.Format( A246depto_usuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtdepto_usuario_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtdepto_usuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 150, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercorreo_usuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcorreo_usuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcorreo_usuario_Internalname, "correo_usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A247correo_usuario", A247correo_usuario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtcorreo_usuario_Internalname, A247correo_usuario, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", 0, 1, edtcorreo_usuario_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdetalle_infotecid_unidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtdetalle_infotecid_unidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdetalle_infotecid_unidad_Internalname, "id_unidad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtdetalle_infotecid_unidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A248detalle_infotecid_unidad), 9, 0, ".", "")), StringUtil.LTrim( ((edtdetalle_infotecid_unidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A248detalle_infotecid_unidad), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtdetalle_infotecid_unidad_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtdetalle_infotecid_unidad_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_categoria_Internalname, "id_categoria", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A249id_categoria), 9, 0, ".", "")), StringUtil.LTrim( ((edtid_categoria_Enabled!=0) ? context.localUtil.Format( (decimal)(A249id_categoria), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A249id_categoria), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_categoria_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtid_categoria_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_actividad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_actividad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_actividad_Internalname, "id_actividad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_actividad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A250id_actividad), 9, 0, ".", "")), StringUtil.LTrim( ((edtid_actividad_Enabled!=0) ? context.localUtil.Format( (decimal)(A250id_actividad), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A250id_actividad), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_actividad_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtid_actividad_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdetalle_tarea_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtdetalle_tarea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtdetalle_tarea_Internalname, "detalle_tarea", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A251detalle_tarea", A251detalle_tarea);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtdetalle_tarea_Internalname, A251detalle_tarea, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,90);\"", 0, 1, edtdetalle_tarea_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprioridad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprioridad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprioridad_Internalname, "prioridad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A252prioridad", A252prioridad);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprioridad_Internalname, A252prioridad, StringUtil.RTrim( context.localUtil.Format( A252prioridad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprioridad_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprioridad_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerobservaciones_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtobservaciones_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtobservaciones_Internalname, "observaciones", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A253observaciones", A253observaciones);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtobservaciones_Internalname, A253observaciones, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,102);\"", 0, 1, edtobservaciones_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_detalle_infotec.htm");
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
         GxWebStd.gx_div_start( context, divK2besactioncontainercell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblActionscontainerbuttons_Internalname, tblActionscontainerbuttons_Internalname, "", "Table_TrnActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_detalle_infotec.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2bescontrolbeaufitycell_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* User Defined Control */
         ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
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
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               standaloneStartupServer( ) ;
            }
         }
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         nDoneStart = 1;
         if ( AnyError == 0 )
         {
            sXEvt = cgiGet( "_EventName");
            if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z238correlativo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z238correlativo"), ".", ","));
               Z239nombre_emp = cgiGet( sPrefix+"Z239nombre_emp");
               n239nombre_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) ? true : false);
               Z240cargo_emp = cgiGet( sPrefix+"Z240cargo_emp");
               n240cargo_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A240cargo_emp)) ? true : false);
               Z241fecha_registro = context.localUtil.CToD( cgiGet( sPrefix+"Z241fecha_registro"), 0);
               n241fecha_registro = ((DateTime.MinValue==A241fecha_registro) ? true : false);
               Z242hora_registro = context.localUtil.CToT( cgiGet( sPrefix+"Z242hora_registro"), 0);
               n242hora_registro = ((DateTime.MinValue==A242hora_registro) ? true : false);
               Z243estatus = cgiGet( sPrefix+"Z243estatus");
               n243estatus = (String.IsNullOrEmpty(StringUtil.RTrim( A243estatus)) ? true : false);
               Z244trabajo = cgiGet( sPrefix+"Z244trabajo");
               n244trabajo = (String.IsNullOrEmpty(StringUtil.RTrim( A244trabajo)) ? true : false);
               Z245nombre_usuario = cgiGet( sPrefix+"Z245nombre_usuario");
               n245nombre_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A245nombre_usuario)) ? true : false);
               Z246depto_usuario = cgiGet( sPrefix+"Z246depto_usuario");
               n246depto_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A246depto_usuario)) ? true : false);
               Z247correo_usuario = cgiGet( sPrefix+"Z247correo_usuario");
               n247correo_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A247correo_usuario)) ? true : false);
               Z248detalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z248detalle_infotecid_unidad"), ".", ","));
               n248detalle_infotecid_unidad = ((0==A248detalle_infotecid_unidad) ? true : false);
               Z249id_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z249id_categoria"), ".", ","));
               n249id_categoria = ((0==A249id_categoria) ? true : false);
               Z250id_actividad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z250id_actividad"), ".", ","));
               n250id_actividad = ((0==A250id_actividad) ? true : false);
               Z251detalle_tarea = cgiGet( sPrefix+"Z251detalle_tarea");
               n251detalle_tarea = (String.IsNullOrEmpty(StringUtil.RTrim( A251detalle_tarea)) ? true : false);
               Z252prioridad = cgiGet( sPrefix+"Z252prioridad");
               n252prioridad = (String.IsNullOrEmpty(StringUtil.RTrim( A252prioridad)) ? true : false);
               Z253observaciones = cgiGet( sPrefix+"Z253observaciones");
               n253observaciones = (String.IsNullOrEmpty(StringUtil.RTrim( A253observaciones)) ? true : false);
               Z254fecha_solicitud = cgiGet( sPrefix+"Z254fecha_solicitud");
               n254fecha_solicitud = (String.IsNullOrEmpty(StringUtil.RTrim( A254fecha_solicitud)) ? true : false);
               Z255fecha_ciere = context.localUtil.CToD( cgiGet( sPrefix+"Z255fecha_ciere"), 0);
               n255fecha_ciere = ((DateTime.MinValue==A255fecha_ciere) ? true : false);
               Z256hora_cierra = context.localUtil.CToT( cgiGet( sPrefix+"Z256hora_cierra"), 0);
               n256hora_cierra = ((DateTime.MinValue==A256hora_cierra) ? true : false);
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8correlativo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8correlativo"), ".", ","));
               A242hora_registro = context.localUtil.CToT( cgiGet( sPrefix+"Z242hora_registro"), 0);
               n242hora_registro = false;
               n242hora_registro = ((DateTime.MinValue==A242hora_registro) ? true : false);
               A254fecha_solicitud = cgiGet( sPrefix+"Z254fecha_solicitud");
               n254fecha_solicitud = false;
               n254fecha_solicitud = (String.IsNullOrEmpty(StringUtil.RTrim( A254fecha_solicitud)) ? true : false);
               A255fecha_ciere = context.localUtil.CToD( cgiGet( sPrefix+"Z255fecha_ciere"), 0);
               n255fecha_ciere = false;
               n255fecha_ciere = ((DateTime.MinValue==A255fecha_ciere) ? true : false);
               A256hora_cierra = context.localUtil.CToT( cgiGet( sPrefix+"Z256hora_cierra"), 0);
               n256hora_cierra = false;
               n256hora_cierra = ((DateTime.MinValue==A256hora_cierra) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV8correlativo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vCORRELATIVO"), ".", ","));
               A242hora_registro = context.localUtil.CToT( cgiGet( sPrefix+"HORA_REGISTRO"), 0);
               n242hora_registro = ((DateTime.MinValue==A242hora_registro) ? true : false);
               A254fecha_solicitud = cgiGet( sPrefix+"FECHA_SOLICITUD");
               n254fecha_solicitud = (String.IsNullOrEmpty(StringUtil.RTrim( A254fecha_solicitud)) ? true : false);
               A255fecha_ciere = context.localUtil.CToD( cgiGet( sPrefix+"FECHA_CIERE"), 0);
               n255fecha_ciere = ((DateTime.MinValue==A255fecha_ciere) ? true : false);
               A256hora_cierra = context.localUtil.CToT( cgiGet( sPrefix+"HORA_CIERRA"), 0);
               n256hora_cierra = ((DateTime.MinValue==A256hora_cierra) ? true : false);
               AV25Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A238correlativo = (int)(context.localUtil.CToN( cgiGet( edtcorrelativo_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
               A239nombre_emp = cgiGet( edtnombre_emp_Internalname);
               n239nombre_emp = false;
               AssignAttri(sPrefix, false, "A239nombre_emp", A239nombre_emp);
               n239nombre_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) ? true : false);
               A240cargo_emp = cgiGet( edtcargo_emp_Internalname);
               n240cargo_emp = false;
               AssignAttri(sPrefix, false, "A240cargo_emp", A240cargo_emp);
               n240cargo_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A240cargo_emp)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtfecha_registro_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"fecha_registro"}), 1, "FECHA_REGISTRO");
                  AnyError = 1;
                  GX_FocusControl = edtfecha_registro_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A241fecha_registro = DateTime.MinValue;
                  n241fecha_registro = false;
                  AssignAttri(sPrefix, false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
               }
               else
               {
                  A241fecha_registro = context.localUtil.CToD( cgiGet( edtfecha_registro_Internalname), 2);
                  n241fecha_registro = false;
                  AssignAttri(sPrefix, false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
               }
               n241fecha_registro = ((DateTime.MinValue==A241fecha_registro) ? true : false);
               A243estatus = cgiGet( edtestatus_Internalname);
               n243estatus = false;
               AssignAttri(sPrefix, false, "A243estatus", A243estatus);
               n243estatus = (String.IsNullOrEmpty(StringUtil.RTrim( A243estatus)) ? true : false);
               A244trabajo = cgiGet( edttrabajo_Internalname);
               n244trabajo = false;
               AssignAttri(sPrefix, false, "A244trabajo", A244trabajo);
               n244trabajo = (String.IsNullOrEmpty(StringUtil.RTrim( A244trabajo)) ? true : false);
               A245nombre_usuario = cgiGet( edtnombre_usuario_Internalname);
               n245nombre_usuario = false;
               AssignAttri(sPrefix, false, "A245nombre_usuario", A245nombre_usuario);
               n245nombre_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A245nombre_usuario)) ? true : false);
               A246depto_usuario = cgiGet( edtdepto_usuario_Internalname);
               n246depto_usuario = false;
               AssignAttri(sPrefix, false, "A246depto_usuario", A246depto_usuario);
               n246depto_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A246depto_usuario)) ? true : false);
               A247correo_usuario = cgiGet( edtcorreo_usuario_Internalname);
               n247correo_usuario = false;
               AssignAttri(sPrefix, false, "A247correo_usuario", A247correo_usuario);
               n247correo_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A247correo_usuario)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DETALLE_INFOTECID_UNIDAD");
                  AnyError = 1;
                  GX_FocusControl = edtdetalle_infotecid_unidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A248detalle_infotecid_unidad = 0;
                  n248detalle_infotecid_unidad = false;
                  AssignAttri(sPrefix, false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
               }
               else
               {
                  A248detalle_infotecid_unidad = (int)(context.localUtil.CToN( cgiGet( edtdetalle_infotecid_unidad_Internalname), ".", ","));
                  n248detalle_infotecid_unidad = false;
                  AssignAttri(sPrefix, false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
               }
               n248detalle_infotecid_unidad = ((0==A248detalle_infotecid_unidad) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_CATEGORIA");
                  AnyError = 1;
                  GX_FocusControl = edtid_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A249id_categoria = 0;
                  n249id_categoria = false;
                  AssignAttri(sPrefix, false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
               }
               else
               {
                  A249id_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_categoria_Internalname), ".", ","));
                  n249id_categoria = false;
                  AssignAttri(sPrefix, false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
               }
               n249id_categoria = ((0==A249id_categoria) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_ACTIVIDAD");
                  AnyError = 1;
                  GX_FocusControl = edtid_actividad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A250id_actividad = 0;
                  n250id_actividad = false;
                  AssignAttri(sPrefix, false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
               }
               else
               {
                  A250id_actividad = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_Internalname), ".", ","));
                  n250id_actividad = false;
                  AssignAttri(sPrefix, false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
               }
               n250id_actividad = ((0==A250id_actividad) ? true : false);
               A251detalle_tarea = cgiGet( edtdetalle_tarea_Internalname);
               n251detalle_tarea = false;
               AssignAttri(sPrefix, false, "A251detalle_tarea", A251detalle_tarea);
               n251detalle_tarea = (String.IsNullOrEmpty(StringUtil.RTrim( A251detalle_tarea)) ? true : false);
               A252prioridad = cgiGet( edtprioridad_Internalname);
               n252prioridad = false;
               AssignAttri(sPrefix, false, "A252prioridad", A252prioridad);
               n252prioridad = (String.IsNullOrEmpty(StringUtil.RTrim( A252prioridad)) ? true : false);
               A253observaciones = cgiGet( edtobservaciones_Internalname);
               n253observaciones = false;
               AssignAttri(sPrefix, false, "A253observaciones", A253observaciones);
               n253observaciones = (String.IsNullOrEmpty(StringUtil.RTrim( A253observaciones)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"detalle_infotec");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("hora_registro", context.localUtil.Format( A242hora_registro, "99/99/99 99:99"));
               forbiddenHiddens.Add("fecha_solicitud", StringUtil.RTrim( context.localUtil.Format( A254fecha_solicitud, "")));
               forbiddenHiddens.Add("fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
               forbiddenHiddens.Add("hora_cierra", context.localUtil.Format( A256hora_cierra, "99/99/99 99:99"));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A238correlativo != Z238correlativo ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("detalle_infotec:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusDescription = 403.ToString();
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  A238correlativo = (int)(NumberUtil.Val( GetPar( "correlativo"), "."));
                  AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode17 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode17;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound17 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0G0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CORRELATIVO");
                        AnyError = 1;
                        GX_FocusControl = edtcorrelativo_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read Transaction buttons. */
            if ( context.wbHandled == 0 )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  sEvt = cgiGet( "_EventName");
                  EvtGridId = cgiGet( "_EventGridId");
                  EvtRowId = cgiGet( "_EventRowId");
               }
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: Start */
                                 E110G2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: After Trn */
                                 E120G2 ();
                              }
                           }
                        }
                        else if ( StringUtil.StrCmp(sEvt, "'DOCANCEL'") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 dynload_actions( ) ;
                                 /* Execute user event: 'DoCancel' */
                                 E130G2 ();
                              }
                           }
                           nKeyPressed = 3;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                           {
                              standaloneStartupServer( ) ;
                           }
                           if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 if ( ! IsDsp( ) )
                                 {
                                    btn_enter( ) ;
                                 }
                              }
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E120G2 ();
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
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttEnter_Visible = 0;
               AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
            }
            DisableAttributes0G17( ) ;
         }
         AssignProp(sPrefix, false, edtnombre_emp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_emp_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcargo_emp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcargo_emp_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtfecha_registro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfecha_registro_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtestatus_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edttrabajo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edttrabajo_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombre_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_usuario_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtdepto_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdepto_usuario_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcorreo_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorreo_usuario_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtdetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdetalle_infotecid_unidad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtid_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_categoria_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtid_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtdetalle_tarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdetalle_tarea_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprioridad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprioridad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtobservaciones_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtobservaciones_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G17( ) ;
            }
            else
            {
               CheckExtendedTable0G17( ) ;
               CloseExtendedTableCursors0G17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0G0( )
      {
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV17StandardActivityType = "Insert";
            AssignAttri(sPrefix, false, "AV17StandardActivityType", AV17StandardActivityType);
            AV18UserActivityType = "";
            AssignAttri(sPrefix, false, "AV18UserActivityType", AV18UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV17StandardActivityType = "Update";
            AssignAttri(sPrefix, false, "AV17StandardActivityType", AV17StandardActivityType);
            AV18UserActivityType = "";
            AssignAttri(sPrefix, false, "AV18UserActivityType", AV18UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV17StandardActivityType = "Delete";
            AssignAttri(sPrefix, false, "AV17StandardActivityType", AV17StandardActivityType);
            AV18UserActivityType = "";
            AssignAttri(sPrefix, false, "AV18UserActivityType", AV18UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV17StandardActivityType = "Display";
            AssignAttri(sPrefix, false, "AV17StandardActivityType", AV17StandardActivityType);
            AV18UserActivityType = "";
            AssignAttri(sPrefix, false, "AV18UserActivityType", AV18UserActivityType);
         }
         new k2bisauthorizedactivityname(context ).execute(  "detalle_infotec",  "detalle_infotec",  AV17StandardActivityType,  AV18UserActivityType,  AV25Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("detalle_infotec")),UrlEncode(StringUtil.RTrim("detalle_infotec")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV25Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
         new k2bgetcontext(context ).execute( out  AV13Context) ;
         AV14BtnCaption = "Confirmar";
         AssignAttri(sPrefix, false, "AV14BtnCaption", AV14BtnCaption);
         AV15BtnTooltip = "Confirmar";
         AssignAttri(sPrefix, false, "AV15BtnTooltip", AV15BtnTooltip);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV14BtnCaption = "Actualizar";
            AssignAttri(sPrefix, false, "AV14BtnCaption", AV14BtnCaption);
            AV15BtnTooltip = "Actualizar";
            AssignAttri(sPrefix, false, "AV15BtnTooltip", AV15BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV14BtnCaption = "Confirmar";
            AssignAttri(sPrefix, false, "AV14BtnCaption", AV14BtnCaption);
            AV15BtnTooltip = "Confirmar";
            AssignAttri(sPrefix, false, "AV15BtnTooltip", AV15BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14BtnCaption = "Eliminar";
            AssignAttri(sPrefix, false, "AV14BtnCaption", AV14BtnCaption);
            AV15BtnTooltip = "Eliminar";
            AssignAttri(sPrefix, false, "AV15BtnTooltip", AV15BtnTooltip);
         }
         bttEnter_Caption = AV14BtnCaption;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Caption", bttEnter_Caption, true);
         bttEnter_Tooltiptext = AV15BtnTooltip;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Tooltiptext", bttEnter_Tooltiptext, true);
         bttEnter_Visible = 0;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
         bttCancel_Visible = 0;
         AssignProp(sPrefix, false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "DSP") != 0 )
         {
            bttEnter_Visible = 1;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttEnter_Visible), 5, 0), true);
            bttCancel_Visible = 1;
            AssignProp(sPrefix, false, bttCancel_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttCancel_Visible), 5, 0), true);
         }
         new k2bgettrncontextbyname(context ).execute(  "detalle_infotec", out  AV9TrnContext) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "detalle_infotec", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "detalle_infotec", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "detalle_infotec", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtnombre_emp_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtnombre_emp_Internalname, "Class", edtnombre_emp_Class, true);
            }
            else
            {
               edtnombre_emp_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtnombre_emp_Internalname, "Class", edtnombre_emp_Class, true);
            }
         }
      }

      protected void E120G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV9TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "correlativo";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A238correlativo), 9, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "detalle_infotec",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La detalle_infotec %1 fue creada", A239nombre_emp, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La detalle_infotec %1 fue actualizada", A239nombre_emp, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La detalle_infotec %1 fue eliminada", A239nombre_emp, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"detalle_infotec",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV9TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV9TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "detalle_infotec") ;
            }
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV11Navigation = AV9TrnContext.gxTpr_Afterinsert;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               AV11Navigation = AV9TrnContext.gxTpr_Afterupdate;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV11Navigation = AV9TrnContext.gxTpr_Afterdelete;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AttributeValue", AV21AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11Navigation", AV11Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9TrnContext", AV9TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV20encrypt = AV9TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20encrypt)) )
         {
            GXt_char1 = AV20encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV20encrypt = GXt_char1;
         }
         if ( AV11Navigation.gxTpr_Aftertrn == 2 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem("K2BEntityServices: TransactionNavigation Invalid invocation method. Delete method cannot return using entity manager");
            }
            else
            {
               AV12DinamicObjToLink = StringUtil.Lower( AV9TrnContext.gxTpr_Entitymanagername);
               new k2bgetdynamicobjecttolink(context ).execute( ref  AV12DinamicObjToLink) ;
               if ( StringUtil.StrCmp(AV20encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A238correlativo,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A238correlativo = (int)(args[2]) ;
                        AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A238correlativo,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A238correlativo = (int)(args[2]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                        else
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A238correlativo,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A238correlativo = (int)(args[1]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
         }
         else
         {
            if ( AV11Navigation.gxTpr_Aftertrn == 3 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV11Navigation.gxTpr_Mode)) )
               {
                  AV11Navigation.gxTpr_Mode = Gx_mode;
               }
               AV12DinamicObjToLink = StringUtil.Lower( AV11Navigation.gxTpr_Objecttolink);
               new k2bgetdynamicobjecttolink(context ).execute( ref  AV12DinamicObjToLink) ;
               if ( StringUtil.StrCmp(AV20encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV11Navigation.gxTpr_Mode,(int)A238correlativo,AV11Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A238correlativo = (int)(args[2]) ;
                        AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV11Navigation.gxTpr_Mode,(int)A238correlativo,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A238correlativo = (int)(args[2]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                        else
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV11Navigation.gxTpr_Mode,(int)A238correlativo,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A238correlativo = (int)(args[1]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A238correlativo,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
            else
            {
               if ( AV11Navigation.gxTpr_Aftertrn != 5 )
               {
                  /* Execute user subroutine: 'K2BCLOSE' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
      }

      protected void E130G2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "detalle_infotec") ;
         /* Execute user subroutine: 'K2BCLOSE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S122( )
      {
         /* 'K2BCLOSE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"detalle_infotec"}, true);
         }
         else if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Stack") == 0 )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "CallerObject") == 0 )
         {
            AV16Url = AV9TrnContext.gxTpr_Callerurl;
            CallWebObject(formatLink(AV16Url) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
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
         edtcorrelativo_Enabled = 0;
         AssignProp(sPrefix, false, edtcorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorrelativo_Enabled), 5, 0), true);
         edtcorrelativo_Enabled = 0;
         AssignProp(sPrefix, false, edtcorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorrelativo_Enabled), 5, 0), true);
         if ( ! (0==AV8correlativo) )
         {
            A238correlativo = AV8correlativo;
            AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttEnter_Enabled = 0;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
         }
         else
         {
            bttEnter_Enabled = 1;
            AssignProp(sPrefix, false, bttEnter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttEnter_Enabled), 5, 0), true);
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
            AssignAttri(sPrefix, false, "A239nombre_emp", A239nombre_emp);
            A240cargo_emp = T000G4_A240cargo_emp[0];
            n240cargo_emp = T000G4_n240cargo_emp[0];
            AssignAttri(sPrefix, false, "A240cargo_emp", A240cargo_emp);
            A241fecha_registro = T000G4_A241fecha_registro[0];
            n241fecha_registro = T000G4_n241fecha_registro[0];
            AssignAttri(sPrefix, false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
            A242hora_registro = T000G4_A242hora_registro[0];
            n242hora_registro = T000G4_n242hora_registro[0];
            A243estatus = T000G4_A243estatus[0];
            n243estatus = T000G4_n243estatus[0];
            AssignAttri(sPrefix, false, "A243estatus", A243estatus);
            A244trabajo = T000G4_A244trabajo[0];
            n244trabajo = T000G4_n244trabajo[0];
            AssignAttri(sPrefix, false, "A244trabajo", A244trabajo);
            A245nombre_usuario = T000G4_A245nombre_usuario[0];
            n245nombre_usuario = T000G4_n245nombre_usuario[0];
            AssignAttri(sPrefix, false, "A245nombre_usuario", A245nombre_usuario);
            A246depto_usuario = T000G4_A246depto_usuario[0];
            n246depto_usuario = T000G4_n246depto_usuario[0];
            AssignAttri(sPrefix, false, "A246depto_usuario", A246depto_usuario);
            A247correo_usuario = T000G4_A247correo_usuario[0];
            n247correo_usuario = T000G4_n247correo_usuario[0];
            AssignAttri(sPrefix, false, "A247correo_usuario", A247correo_usuario);
            A248detalle_infotecid_unidad = T000G4_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = T000G4_n248detalle_infotecid_unidad[0];
            AssignAttri(sPrefix, false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
            A249id_categoria = T000G4_A249id_categoria[0];
            n249id_categoria = T000G4_n249id_categoria[0];
            AssignAttri(sPrefix, false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
            A250id_actividad = T000G4_A250id_actividad[0];
            n250id_actividad = T000G4_n250id_actividad[0];
            AssignAttri(sPrefix, false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
            A251detalle_tarea = T000G4_A251detalle_tarea[0];
            n251detalle_tarea = T000G4_n251detalle_tarea[0];
            AssignAttri(sPrefix, false, "A251detalle_tarea", A251detalle_tarea);
            A252prioridad = T000G4_A252prioridad[0];
            n252prioridad = T000G4_n252prioridad[0];
            AssignAttri(sPrefix, false, "A252prioridad", A252prioridad);
            A253observaciones = T000G4_A253observaciones[0];
            n253observaciones = T000G4_n253observaciones[0];
            AssignAttri(sPrefix, false, "A253observaciones", A253observaciones);
            A254fecha_solicitud = T000G4_A254fecha_solicitud[0];
            n254fecha_solicitud = T000G4_n254fecha_solicitud[0];
            A255fecha_ciere = T000G4_A255fecha_ciere[0];
            n255fecha_ciere = T000G4_n255fecha_ciere[0];
            A256hora_cierra = T000G4_A256hora_cierra[0];
            n256hora_cierra = T000G4_n256hora_cierra[0];
            ZM0G17( -5) ;
         }
         pr_datastore1.close(2);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
         AV25Pgmname = "detalle_infotec";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "detalle_infotec";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "nombre_emp", "", "", "", "", "", "", "", ""), 1, "NOMBRE_EMP");
            AnyError = 1;
            GX_FocusControl = edtnombre_emp_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A241fecha_registro) || ( DateTimeUtil.ResetTime ( A241fecha_registro ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo fecha_registro fuera de rango", "OutOfRange", 1, "FECHA_REGISTRO");
            AnyError = 1;
            GX_FocusControl = edtfecha_registro_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
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
            AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
            A239nombre_emp = T000G3_A239nombre_emp[0];
            n239nombre_emp = T000G3_n239nombre_emp[0];
            AssignAttri(sPrefix, false, "A239nombre_emp", A239nombre_emp);
            A240cargo_emp = T000G3_A240cargo_emp[0];
            n240cargo_emp = T000G3_n240cargo_emp[0];
            AssignAttri(sPrefix, false, "A240cargo_emp", A240cargo_emp);
            A241fecha_registro = T000G3_A241fecha_registro[0];
            n241fecha_registro = T000G3_n241fecha_registro[0];
            AssignAttri(sPrefix, false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
            A242hora_registro = T000G3_A242hora_registro[0];
            n242hora_registro = T000G3_n242hora_registro[0];
            A243estatus = T000G3_A243estatus[0];
            n243estatus = T000G3_n243estatus[0];
            AssignAttri(sPrefix, false, "A243estatus", A243estatus);
            A244trabajo = T000G3_A244trabajo[0];
            n244trabajo = T000G3_n244trabajo[0];
            AssignAttri(sPrefix, false, "A244trabajo", A244trabajo);
            A245nombre_usuario = T000G3_A245nombre_usuario[0];
            n245nombre_usuario = T000G3_n245nombre_usuario[0];
            AssignAttri(sPrefix, false, "A245nombre_usuario", A245nombre_usuario);
            A246depto_usuario = T000G3_A246depto_usuario[0];
            n246depto_usuario = T000G3_n246depto_usuario[0];
            AssignAttri(sPrefix, false, "A246depto_usuario", A246depto_usuario);
            A247correo_usuario = T000G3_A247correo_usuario[0];
            n247correo_usuario = T000G3_n247correo_usuario[0];
            AssignAttri(sPrefix, false, "A247correo_usuario", A247correo_usuario);
            A248detalle_infotecid_unidad = T000G3_A248detalle_infotecid_unidad[0];
            n248detalle_infotecid_unidad = T000G3_n248detalle_infotecid_unidad[0];
            AssignAttri(sPrefix, false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
            A249id_categoria = T000G3_A249id_categoria[0];
            n249id_categoria = T000G3_n249id_categoria[0];
            AssignAttri(sPrefix, false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
            A250id_actividad = T000G3_A250id_actividad[0];
            n250id_actividad = T000G3_n250id_actividad[0];
            AssignAttri(sPrefix, false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
            A251detalle_tarea = T000G3_A251detalle_tarea[0];
            n251detalle_tarea = T000G3_n251detalle_tarea[0];
            AssignAttri(sPrefix, false, "A251detalle_tarea", A251detalle_tarea);
            A252prioridad = T000G3_A252prioridad[0];
            n252prioridad = T000G3_n252prioridad[0];
            AssignAttri(sPrefix, false, "A252prioridad", A252prioridad);
            A253observaciones = T000G3_A253observaciones[0];
            n253observaciones = T000G3_n253observaciones[0];
            AssignAttri(sPrefix, false, "A253observaciones", A253observaciones);
            A254fecha_solicitud = T000G3_A254fecha_solicitud[0];
            n254fecha_solicitud = T000G3_n254fecha_solicitud[0];
            A255fecha_ciere = T000G3_A255fecha_ciere[0];
            n255fecha_ciere = T000G3_n255fecha_ciere[0];
            A256hora_cierra = T000G3_A256hora_cierra[0];
            n256hora_cierra = T000G3_n256hora_cierra[0];
            Z238correlativo = A238correlativo;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
         {
         }
         else
         {
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
               AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
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
               AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
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
            GX_FocusControl = edtnombre_emp_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0G17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A238correlativo != Z238correlativo )
               {
                  A238correlativo = Z238correlativo;
                  AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CORRELATIVO");
                  AnyError = 1;
                  GX_FocusControl = edtcorrelativo_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtnombre_emp_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0G17( ) ;
                  GX_FocusControl = edtnombre_emp_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A238correlativo != Z238correlativo )
               {
                  /* Insert record */
                  GX_FocusControl = edtnombre_emp_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0G17( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CORRELATIVO");
                     AnyError = 1;
                     GX_FocusControl = edtcorrelativo_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtnombre_emp_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0G17( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A238correlativo != Z238correlativo )
         {
            A238correlativo = Z238correlativo;
            AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CORRELATIVO");
            AnyError = 1;
            GX_FocusControl = edtcorrelativo_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtnombre_emp_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
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
            if ( (pr_datastore1.getStatus(0) == 101) || ( StringUtil.StrCmp(Z239nombre_emp, T000G2_A239nombre_emp[0]) != 0 ) || ( StringUtil.StrCmp(Z240cargo_emp, T000G2_A240cargo_emp[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z241fecha_registro ) != DateTimeUtil.ResetTime ( T000G2_A241fecha_registro[0] ) ) || ( Z242hora_registro != T000G2_A242hora_registro[0] ) || ( StringUtil.StrCmp(Z243estatus, T000G2_A243estatus[0]) != 0 ) )
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
            if ( Gx_longc || ( StringUtil.StrCmp(Z254fecha_solicitud, T000G2_A254fecha_solicitud[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z255fecha_ciere ) != DateTimeUtil.ResetTime ( T000G2_A255fecha_ciere[0] ) ) || ( Z256hora_cierra != T000G2_A256hora_cierra[0] ) )
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
               if ( DateTimeUtil.ResetTime ( Z241fecha_registro ) != DateTimeUtil.ResetTime ( T000G2_A241fecha_registro[0] ) )
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
               if ( DateTimeUtil.ResetTime ( Z255fecha_ciere ) != DateTimeUtil.ResetTime ( T000G2_A255fecha_ciere[0] ) )
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
                     AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
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
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                              {
                                 context.nUserReturn = 1;
                              }
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
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( ( AnyError == 0 ) && ( StringUtil.Len( sPrefix) == 0 ) )
                           {
                              context.nUserReturn = 1;
                           }
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
         }
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "detalle_infotec";
            AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         }
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
         /* Scan By routine */
         /* Using cursor T000G11 */
         pr_datastore1.execute(9);
         RcdFound17 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound17 = 1;
            A238correlativo = T000G11_A238correlativo[0];
            AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
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
            AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
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
         AssignProp(sPrefix, false, edtcorrelativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorrelativo_Enabled), 5, 0), true);
         edtnombre_emp_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_emp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_emp_Enabled), 5, 0), true);
         edtcargo_emp_Enabled = 0;
         AssignProp(sPrefix, false, edtcargo_emp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcargo_emp_Enabled), 5, 0), true);
         edtfecha_registro_Enabled = 0;
         AssignProp(sPrefix, false, edtfecha_registro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtfecha_registro_Enabled), 5, 0), true);
         edtestatus_Enabled = 0;
         AssignProp(sPrefix, false, edtestatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtestatus_Enabled), 5, 0), true);
         edttrabajo_Enabled = 0;
         AssignProp(sPrefix, false, edttrabajo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edttrabajo_Enabled), 5, 0), true);
         edtnombre_usuario_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_usuario_Enabled), 5, 0), true);
         edtdepto_usuario_Enabled = 0;
         AssignProp(sPrefix, false, edtdepto_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdepto_usuario_Enabled), 5, 0), true);
         edtcorreo_usuario_Enabled = 0;
         AssignProp(sPrefix, false, edtcorreo_usuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcorreo_usuario_Enabled), 5, 0), true);
         edtdetalle_infotecid_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtdetalle_infotecid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdetalle_infotecid_unidad_Enabled), 5, 0), true);
         edtid_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtid_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_categoria_Enabled), 5, 0), true);
         edtid_actividad_Enabled = 0;
         AssignProp(sPrefix, false, edtid_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_Enabled), 5, 0), true);
         edtdetalle_tarea_Enabled = 0;
         AssignProp(sPrefix, false, edtdetalle_tarea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtdetalle_tarea_Enabled), 5, 0), true);
         edtprioridad_Enabled = 0;
         AssignProp(sPrefix, false, edtprioridad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprioridad_Enabled), 5, 0), true);
         edtobservaciones_Enabled = 0;
         AssignProp(sPrefix, false, edtobservaciones_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtobservaciones_Enabled), 5, 0), true);
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
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
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 184460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2024188103997", false, true);
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            bodyStyle += "-moz-opacity:0;opacity:0;";
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("detalle_infotec.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8correlativo,9,0))}, new string[] {"Gx_mode","correlativo"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"detalle_infotec");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("hora_registro", context.localUtil.Format( A242hora_registro, "99/99/99 99:99"));
         forbiddenHiddens.Add("fecha_solicitud", StringUtil.RTrim( context.localUtil.Format( A254fecha_solicitud, "")));
         forbiddenHiddens.Add("fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
         forbiddenHiddens.Add("hora_cierra", context.localUtil.Format( A256hora_cierra, "99/99/99 99:99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("detalle_infotec:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z238correlativo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z238correlativo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z239nombre_emp", Z239nombre_emp);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z240cargo_emp", Z240cargo_emp);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z241fecha_registro", context.localUtil.DToC( Z241fecha_registro, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z242hora_registro", context.localUtil.TToC( Z242hora_registro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z243estatus", Z243estatus);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z244trabajo", Z244trabajo);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z245nombre_usuario", Z245nombre_usuario);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z246depto_usuario", Z246depto_usuario);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z247correo_usuario", Z247correo_usuario);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z248detalle_infotecid_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z248detalle_infotecid_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z249id_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z249id_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z250id_actividad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z250id_actividad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z251detalle_tarea", Z251detalle_tarea);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z252prioridad", Z252prioridad);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z253observaciones", Z253observaciones);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z254fecha_solicitud", Z254fecha_solicitud);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z255fecha_ciere", context.localUtil.DToC( Z255fecha_ciere, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z256hora_cierra", context.localUtil.TToC( Z256hora_cierra, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8correlativo", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8correlativo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV21AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV21AttributeValue);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vATTRIBUTEVALUE", GetSecureSignedToken( sPrefix, AV21AttributeValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV11Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV11Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV11Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCORRELATIVO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8correlativo), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"HORA_REGISTRO", context.localUtil.TToC( A242hora_registro, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"FECHA_SOLICITUD", A254fecha_solicitud);
         GxWebStd.gx_hidden_field( context, sPrefix+"FECHA_CIERE", context.localUtil.DToC( A255fecha_ciere, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"HORA_CIERRA", context.localUtil.TToC( A256hora_cierra, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0G17( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
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
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
         AssignAttri(sPrefix, false, "A239nombre_emp", A239nombre_emp);
         n239nombre_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A239nombre_emp)) ? true : false);
         A240cargo_emp = "";
         n240cargo_emp = false;
         AssignAttri(sPrefix, false, "A240cargo_emp", A240cargo_emp);
         n240cargo_emp = (String.IsNullOrEmpty(StringUtil.RTrim( A240cargo_emp)) ? true : false);
         A241fecha_registro = DateTime.MinValue;
         n241fecha_registro = false;
         AssignAttri(sPrefix, false, "A241fecha_registro", context.localUtil.Format(A241fecha_registro, "99/99/99"));
         n241fecha_registro = ((DateTime.MinValue==A241fecha_registro) ? true : false);
         A242hora_registro = (DateTime)(DateTime.MinValue);
         n242hora_registro = false;
         AssignAttri(sPrefix, false, "A242hora_registro", context.localUtil.TToC( A242hora_registro, 8, 5, 0, 3, "/", ":", " "));
         A243estatus = "";
         n243estatus = false;
         AssignAttri(sPrefix, false, "A243estatus", A243estatus);
         n243estatus = (String.IsNullOrEmpty(StringUtil.RTrim( A243estatus)) ? true : false);
         A244trabajo = "";
         n244trabajo = false;
         AssignAttri(sPrefix, false, "A244trabajo", A244trabajo);
         n244trabajo = (String.IsNullOrEmpty(StringUtil.RTrim( A244trabajo)) ? true : false);
         A245nombre_usuario = "";
         n245nombre_usuario = false;
         AssignAttri(sPrefix, false, "A245nombre_usuario", A245nombre_usuario);
         n245nombre_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A245nombre_usuario)) ? true : false);
         A246depto_usuario = "";
         n246depto_usuario = false;
         AssignAttri(sPrefix, false, "A246depto_usuario", A246depto_usuario);
         n246depto_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A246depto_usuario)) ? true : false);
         A247correo_usuario = "";
         n247correo_usuario = false;
         AssignAttri(sPrefix, false, "A247correo_usuario", A247correo_usuario);
         n247correo_usuario = (String.IsNullOrEmpty(StringUtil.RTrim( A247correo_usuario)) ? true : false);
         A248detalle_infotecid_unidad = 0;
         n248detalle_infotecid_unidad = false;
         AssignAttri(sPrefix, false, "A248detalle_infotecid_unidad", StringUtil.LTrimStr( (decimal)(A248detalle_infotecid_unidad), 9, 0));
         n248detalle_infotecid_unidad = ((0==A248detalle_infotecid_unidad) ? true : false);
         A249id_categoria = 0;
         n249id_categoria = false;
         AssignAttri(sPrefix, false, "A249id_categoria", StringUtil.LTrimStr( (decimal)(A249id_categoria), 9, 0));
         n249id_categoria = ((0==A249id_categoria) ? true : false);
         A250id_actividad = 0;
         n250id_actividad = false;
         AssignAttri(sPrefix, false, "A250id_actividad", StringUtil.LTrimStr( (decimal)(A250id_actividad), 9, 0));
         n250id_actividad = ((0==A250id_actividad) ? true : false);
         A251detalle_tarea = "";
         n251detalle_tarea = false;
         AssignAttri(sPrefix, false, "A251detalle_tarea", A251detalle_tarea);
         n251detalle_tarea = (String.IsNullOrEmpty(StringUtil.RTrim( A251detalle_tarea)) ? true : false);
         A252prioridad = "";
         n252prioridad = false;
         AssignAttri(sPrefix, false, "A252prioridad", A252prioridad);
         n252prioridad = (String.IsNullOrEmpty(StringUtil.RTrim( A252prioridad)) ? true : false);
         A253observaciones = "";
         n253observaciones = false;
         AssignAttri(sPrefix, false, "A253observaciones", A253observaciones);
         n253observaciones = (String.IsNullOrEmpty(StringUtil.RTrim( A253observaciones)) ? true : false);
         A254fecha_solicitud = "";
         n254fecha_solicitud = false;
         AssignAttri(sPrefix, false, "A254fecha_solicitud", A254fecha_solicitud);
         A255fecha_ciere = DateTime.MinValue;
         n255fecha_ciere = false;
         AssignAttri(sPrefix, false, "A255fecha_ciere", context.localUtil.Format(A255fecha_ciere, "99/99/99"));
         A256hora_cierra = (DateTime)(DateTime.MinValue);
         n256hora_cierra = false;
         AssignAttri(sPrefix, false, "A256hora_cierra", context.localUtil.TToC( A256hora_cierra, 8, 5, 0, 3, "/", ":", " "));
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
         AssignAttri(sPrefix, false, "A238correlativo", StringUtil.LTrimStr( (decimal)(A238correlativo), 9, 0));
         InitializeNonKey0G17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV8correlativo = (string)((string)getParm(obj,1));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            initialize_properties( ) ;
         }
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         if ( nDoneStart == 0 )
         {
            createObjects();
            initialize();
         }
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "detalle_infotec", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITENV( ) ;
            INITTRN( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            Gx_mode = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            AV8correlativo = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8correlativo", StringUtil.LTrimStr( (decimal)(AV8correlativo), 9, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8correlativo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8correlativo"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8correlativo != wcpOAV8correlativo ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8correlativo = AV8correlativo;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlGx_mode = cgiGet( sPrefix+"Gx_mode_CTRL");
         if ( StringUtil.Len( sCtrlGx_mode) > 0 )
         {
            Gx_mode = cgiGet( sCtrlGx_mode);
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = cgiGet( sPrefix+"Gx_mode_PARM");
         }
         sCtrlAV8correlativo = cgiGet( sPrefix+"AV8correlativo_CTRL");
         if ( StringUtil.Len( sCtrlAV8correlativo) > 0 )
         {
            AV8correlativo = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8correlativo), ".", ","));
            AssignAttri(sPrefix, false, "AV8correlativo", StringUtil.LTrimStr( (decimal)(AV8correlativo), 9, 0));
         }
         else
         {
            AV8correlativo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8correlativo_PARM"), ".", ","));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITENV( ) ;
         INITTRN( ) ;
         nDraw = 0;
         sEvt = sCompEvt;
         if ( isFullAjaxMode( ) )
         {
            UserMain( ) ;
         }
         else
         {
            WCParametersGet( ) ;
         }
         Process( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         UserMain( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_PARM", StringUtil.RTrim( Gx_mode));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlGx_mode)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"Gx_mode_CTRL", StringUtil.RTrim( sCtrlGx_mode));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8correlativo_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8correlativo), 9, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8correlativo)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8correlativo_CTRL", StringUtil.RTrim( sCtrlAV8correlativo));
         }
      }

      public override void componentdraw( )
      {
         if ( CheckCmpSecurityAccess() )
         {
            if ( nDoneStart == 0 )
            {
               WCStart( ) ;
            }
            BackMsgLst = context.GX_msglist;
            context.GX_msglist = LclMsgLst;
            WCParametersSet( ) ;
            Draw( ) ;
            SaveComponentMsgList(sPrefix);
            context.GX_msglist = BackMsgLst;
         }
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188104043", true, true);
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
         context.AddJavascriptSource("detalle_infotec.js", "?2024188104043", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtcorrelativo_Internalname = sPrefix+"CORRELATIVO";
         divK2btoolstable_attributecontainercorrelativo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCORRELATIVO";
         edtnombre_emp_Internalname = sPrefix+"NOMBRE_EMP";
         divK2btoolstable_attributecontainernombre_emp_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_EMP";
         edtcargo_emp_Internalname = sPrefix+"CARGO_EMP";
         divK2btoolstable_attributecontainercargo_emp_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCARGO_EMP";
         edtfecha_registro_Internalname = sPrefix+"FECHA_REGISTRO";
         divK2btoolstable_attributecontainerfecha_registro_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERFECHA_REGISTRO";
         edtestatus_Internalname = sPrefix+"ESTATUS";
         divK2btoolstable_attributecontainerestatus_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTATUS";
         edttrabajo_Internalname = sPrefix+"TRABAJO";
         divK2btoolstable_attributecontainertrabajo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTRABAJO";
         edtnombre_usuario_Internalname = sPrefix+"NOMBRE_USUARIO";
         divK2btoolstable_attributecontainernombre_usuario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_USUARIO";
         edtdepto_usuario_Internalname = sPrefix+"DEPTO_USUARIO";
         divK2btoolstable_attributecontainerdepto_usuario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDEPTO_USUARIO";
         edtcorreo_usuario_Internalname = sPrefix+"CORREO_USUARIO";
         divK2btoolstable_attributecontainercorreo_usuario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCORREO_USUARIO";
         edtdetalle_infotecid_unidad_Internalname = sPrefix+"DETALLE_INFOTECID_UNIDAD";
         divK2btoolstable_attributecontainerdetalle_infotecid_unidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDETALLE_INFOTECID_UNIDAD";
         edtid_categoria_Internalname = sPrefix+"ID_CATEGORIA";
         divK2btoolstable_attributecontainerid_categoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_CATEGORIA";
         edtid_actividad_Internalname = sPrefix+"ID_ACTIVIDAD";
         divK2btoolstable_attributecontainerid_actividad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_ACTIVIDAD";
         edtdetalle_tarea_Internalname = sPrefix+"DETALLE_TAREA";
         divK2btoolstable_attributecontainerdetalle_tarea_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDETALLE_TAREA";
         edtprioridad_Internalname = sPrefix+"PRIORIDAD";
         divK2btoolstable_attributecontainerprioridad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPRIORIDAD";
         edtobservaciones_Internalname = sPrefix+"OBSERVACIONES";
         divK2btoolstable_attributecontainerobservaciones_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINEROBSERVACIONES";
         divTableattributesinformsection1_Internalname = sPrefix+"TABLEATTRIBUTESINFORMSECTION1";
         divK2btrnformmaintablecell_Internalname = sPrefix+"K2BTRNFORMMAINTABLECELL";
         divK2babstracttabledataareacontainer_Internalname = sPrefix+"K2BABSTRACTTABLEDATAAREACONTAINER";
         divK2besdataareacontainercell_Internalname = sPrefix+"K2BESDATAAREACONTAINERCELL";
         bttEnter_Internalname = sPrefix+"ENTER";
         bttCancel_Internalname = sPrefix+"CANCEL";
         tblActionscontainerbuttons_Internalname = sPrefix+"ACTIONSCONTAINERBUTTONS";
         divK2besactioncontainercell_Internalname = sPrefix+"K2BESACTIONCONTAINERCELL";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divK2bescontrolbeaufitycell_Internalname = sPrefix+"K2BESCONTROLBEAUFITYCELL";
         divK2besmaintable_Internalname = sPrefix+"K2BESMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         Form.Caption = "detalle_infotec";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
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
         edtfecha_registro_Jsonclick = "";
         edtfecha_registro_Enabled = 1;
         edtcargo_emp_Jsonclick = "";
         edtcargo_emp_Enabled = 1;
         edtnombre_emp_Class = "Attribute_Trn Attribute_Required";
         edtnombre_emp_Enabled = 1;
         edtcorrelativo_Jsonclick = "";
         edtcorrelativo_Enabled = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8correlativo',fld:'vCORRELATIVO',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A242hora_registro',fld:'HORA_REGISTRO',pic:'99/99/99 99:99'},{av:'A254fecha_solicitud',fld:'FECHA_SOLICITUD',pic:''},{av:'A255fecha_ciere',fld:'FECHA_CIERE',pic:''},{av:'A256hora_cierra',fld:'HORA_CIERRA',pic:'99/99/99 99:99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120G2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A238correlativo',fld:'CORRELATIVO',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A239nombre_emp',fld:'NOMBRE_EMP',pic:''},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A238correlativo',fld:'CORRELATIVO',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130G2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_CORRELATIVO","{handler:'Valid_Correlativo',iparms:[]");
         setEventMetadata("VALID_CORRELATIVO",",oparms:[]}");
         setEventMetadata("VALID_NOMBRE_EMP","{handler:'Valid_Nombre_emp',iparms:[]");
         setEventMetadata("VALID_NOMBRE_EMP",",oparms:[]}");
         setEventMetadata("VALID_FECHA_REGISTRO","{handler:'Valid_Fecha_registro',iparms:[]");
         setEventMetadata("VALID_FECHA_REGISTRO",",oparms:[]}");
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
         wcpOGx_mode = "";
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
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         A239nombre_emp = "";
         TempTags = "";
         A240cargo_emp = "";
         A241fecha_registro = DateTime.MinValue;
         A243estatus = "";
         A244trabajo = "";
         A245nombre_usuario = "";
         A246depto_usuario = "";
         A247correo_usuario = "";
         A251detalle_tarea = "";
         A252prioridad = "";
         A253observaciones = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         A242hora_registro = (DateTime)(DateTime.MinValue);
         A254fecha_solicitud = "";
         A255fecha_ciere = DateTime.MinValue;
         A256hora_cierra = (DateTime)(DateTime.MinValue);
         AV25Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode17 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV17StandardActivityType = "";
         AV18UserActivityType = "";
         AV13Context = new SdtK2BContext(context);
         AV14BtnCaption = "";
         AV15BtnTooltip = "";
         AV9TrnContext = new SdtK2BTrnContext(context);
         AV7HttpRequest = new GxHttpRequest( context);
         AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV11Navigation = new SdtK2BTrnNavigation(context);
         AV20encrypt = "";
         GXt_char1 = "";
         AV12DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV16Url = "";
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
         sCtrlGx_mode = "";
         sCtrlAV8correlativo = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
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
         AV25Pgmname = "detalle_infotec";
      }

      private short GxWebError ;
      private short nDynComponent ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound17 ;
      private short GX_JID ;
      private short nIsDirty_17 ;
      private short Gx_BScreen ;
      private int wcpOAV8correlativo ;
      private int Z238correlativo ;
      private int Z248detalle_infotecid_unidad ;
      private int Z249id_categoria ;
      private int Z250id_actividad ;
      private int AV8correlativo ;
      private int trnEnded ;
      private int A238correlativo ;
      private int edtcorrelativo_Enabled ;
      private int edtnombre_emp_Enabled ;
      private int edtcargo_emp_Enabled ;
      private int edtfecha_registro_Enabled ;
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
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string sXEvt ;
      private string GX_FocusControl ;
      private string edtnombre_emp_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainercorrelativo_Internalname ;
      private string edtcorrelativo_Internalname ;
      private string edtcorrelativo_Jsonclick ;
      private string divK2btoolstable_attributecontainernombre_emp_Internalname ;
      private string TempTags ;
      private string edtnombre_emp_Class ;
      private string divK2btoolstable_attributecontainercargo_emp_Internalname ;
      private string edtcargo_emp_Internalname ;
      private string edtcargo_emp_Jsonclick ;
      private string divK2btoolstable_attributecontainerfecha_registro_Internalname ;
      private string edtfecha_registro_Internalname ;
      private string edtfecha_registro_Jsonclick ;
      private string divK2btoolstable_attributecontainerestatus_Internalname ;
      private string edtestatus_Internalname ;
      private string edtestatus_Jsonclick ;
      private string divK2btoolstable_attributecontainertrabajo_Internalname ;
      private string edttrabajo_Internalname ;
      private string divK2btoolstable_attributecontainernombre_usuario_Internalname ;
      private string edtnombre_usuario_Internalname ;
      private string divK2btoolstable_attributecontainerdepto_usuario_Internalname ;
      private string edtdepto_usuario_Internalname ;
      private string edtdepto_usuario_Jsonclick ;
      private string divK2btoolstable_attributecontainercorreo_usuario_Internalname ;
      private string edtcorreo_usuario_Internalname ;
      private string divK2btoolstable_attributecontainerdetalle_infotecid_unidad_Internalname ;
      private string edtdetalle_infotecid_unidad_Internalname ;
      private string edtdetalle_infotecid_unidad_Jsonclick ;
      private string divK2btoolstable_attributecontainerid_categoria_Internalname ;
      private string edtid_categoria_Internalname ;
      private string edtid_categoria_Jsonclick ;
      private string divK2btoolstable_attributecontainerid_actividad_Internalname ;
      private string edtid_actividad_Internalname ;
      private string edtid_actividad_Jsonclick ;
      private string divK2btoolstable_attributecontainerdetalle_tarea_Internalname ;
      private string edtdetalle_tarea_Internalname ;
      private string divK2btoolstable_attributecontainerprioridad_Internalname ;
      private string edtprioridad_Internalname ;
      private string edtprioridad_Jsonclick ;
      private string divK2btoolstable_attributecontainerobservaciones_Internalname ;
      private string edtobservaciones_Internalname ;
      private string divK2besactioncontainercell_Internalname ;
      private string sStyleString ;
      private string tblActionscontainerbuttons_Internalname ;
      private string bttEnter_Internalname ;
      private string bttEnter_Caption ;
      private string bttEnter_Jsonclick ;
      private string bttEnter_Tooltiptext ;
      private string bttCancel_Internalname ;
      private string bttCancel_Jsonclick ;
      private string divK2bescontrolbeaufitycell_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string AV25Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode17 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV17StandardActivityType ;
      private string AV14BtnCaption ;
      private string AV15BtnTooltip ;
      private string AV20encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV8correlativo ;
      private DateTime Z242hora_registro ;
      private DateTime Z256hora_cierra ;
      private DateTime A242hora_registro ;
      private DateTime A256hora_cierra ;
      private DateTime Z241fecha_registro ;
      private DateTime Z255fecha_ciere ;
      private DateTime A241fecha_registro ;
      private DateTime A255fecha_ciere ;
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
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
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
      private string AV18UserActivityType ;
      private string AV12DinamicObjToLink ;
      private string AV16Url ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
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
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV7HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV21AttributeValue ;
      private SdtK2BAttributeValue_Item AV22AttributeValueItem ;
      private SdtK2BContext AV13Context ;
      private GeneXus.Utils.SdtMessages_Message AV23Message ;
      private SdtK2BTrnNavigation AV11Navigation ;
      private SdtK2BTrnContext AV9TrnContext ;
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
