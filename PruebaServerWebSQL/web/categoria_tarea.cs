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
   public class categoria_tarea : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV8categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
               AssignAttri(sPrefix, false, "AV8categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV8categoria_tareaid_tipo_categoria), 9, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV8categoria_tareaid_tipo_categoria});
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
                  AV8categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
                  AssignAttri(sPrefix, false, "AV8categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV8categoria_tareaid_tipo_categoria), 9, 0));
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
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
               }
               Form.Meta.addItem("description", "categoria_tarea", 0) ;
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
            GX_FocusControl = edtid_unidad_gis_Internalname;
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

      public categoria_tarea( )
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

      public categoria_tarea( IGxContext context )
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

      public void execute( string aP0_Gx_mode ,
                           int aP1_categoria_tareaid_tipo_categoria )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8categoria_tareaid_tipo_categoria = aP1_categoria_tareaid_tipo_categoria;
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
            return "categoria_tarea_Execute" ;
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
            RenderHtmlCloseForm0D14( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "categoria_tarea.aspx");
            context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareaid_tipo_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareaid_tipo_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareaid_tipo_categoria_Internalname, "id_tipo_categoria", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareaid_tipo_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0, ",", "")), ((edtcategoria_tareaid_tipo_categoria_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A104categoria_tareaid_tipo_categoria), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A104categoria_tareaid_tipo_categoria), "ZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareaid_tipo_categoria_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcategoria_tareaid_tipo_categoria_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_unidad_gis_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_unidad_gis_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_unidad_gis_Internalname, "id_unidad_gis", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A105id_unidad_gis", StringUtil.LTrimStr( (decimal)(A105id_unidad_gis), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_unidad_gis_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A105id_unidad_gis), 9, 0, ",", "")), ((edtid_unidad_gis_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A105id_unidad_gis), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A105id_unidad_gis), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_unidad_gis_Jsonclick, 0, edtid_unidad_gis_Class, "", "", "", "", 1, edtid_unidad_gis_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtnombre_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_categoria_Internalname, "nombre_categoria", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A106nombre_categoria", A106nombre_categoria);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_categoria_Internalname, A106nombre_categoria, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", 0, 1, edtnombre_categoria_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareaestado_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareaestado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareaestado_Internalname, "estado", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A107categoria_tareaestado", StringUtil.LTrimStr( (decimal)(A107categoria_tareaestado), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareaestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A107categoria_tareaestado), 9, 0, ",", "")), ((edtcategoria_tareaestado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A107categoria_tareaestado), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A107categoria_tareaestado), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareaestado_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcategoria_tareaestado_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareafecha_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareafecha_creacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareafecha_creacion_Internalname, "fecha_creacion", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A108categoria_tareafecha_creacion", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtcategoria_tareafecha_creacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareafecha_creacion_Internalname, context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"), context.localUtil.Format( A108categoria_tareafecha_creacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareafecha_creacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtcategoria_tareafecha_creacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
         GxWebStd.gx_bitmap( context, edtcategoria_tareafecha_creacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtcategoria_tareafecha_creacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareahora_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareahora_creacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareahora_creacion_Internalname, "hora_creacion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A109categoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(A109categoria_tareahora_creacion), 5, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareahora_creacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A109categoria_tareahora_creacion), 5, 0, ",", "")), ((edtcategoria_tareahora_creacion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A109categoria_tareahora_creacion), "ZZZZ9")) : context.localUtil.Format( (decimal)(A109categoria_tareahora_creacion), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareahora_creacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcategoria_tareahora_creacion_Enabled, 0, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareacreado_por_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareacreado_por_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareacreado_por_Internalname, "creado_por", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A110categoria_tareacreado_por", A110categoria_tareacreado_por);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareacreado_por_Internalname, A110categoria_tareacreado_por, StringUtil.RTrim( context.localUtil.Format( A110categoria_tareacreado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareacreado_por_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcategoria_tareacreado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareafecha_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareafecha_modificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareafecha_modificacion_Internalname, "fecha_modificacion", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A111categoria_tareafecha_modificacion", context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtcategoria_tareafecha_modificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareafecha_modificacion_Internalname, context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"), context.localUtil.Format( A111categoria_tareafecha_modificacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareafecha_modificacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtcategoria_tareafecha_modificacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
         GxWebStd.gx_bitmap( context, edtcategoria_tareafecha_modificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtcategoria_tareafecha_modificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareahora_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareahora_modificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareahora_modificacion_Internalname, "hora_modificacion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A112categoria_tareahora_modificacion", StringUtil.LTrimStr( (decimal)(A112categoria_tareahora_modificacion), 5, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareahora_modificacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A112categoria_tareahora_modificacion), 5, 0, ",", "")), ((edtcategoria_tareahora_modificacion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A112categoria_tareahora_modificacion), "ZZZZ9")) : context.localUtil.Format( (decimal)(A112categoria_tareahora_modificacion), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareahora_modificacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcategoria_tareahora_modificacion_Enabled, 0, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_categoria_tarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoria_tareamodificado_por_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtcategoria_tareamodificado_por_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtcategoria_tareamodificado_por_Internalname, "modificado_por", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A113categoria_tareamodificado_por", A113categoria_tareamodificado_por);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtcategoria_tareamodificado_por_Internalname, A113categoria_tareamodificado_por, StringUtil.RTrim( context.localUtil.Format( A113categoria_tareamodificado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtcategoria_tareamodificado_por_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtcategoria_tareamodificado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_categoria_tarea.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_categoria_tarea.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_categoria_tarea.htm");
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
         E110D2 ();
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
               Z104categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z104categoria_tareaid_tipo_categoria"), ",", "."));
               Z105id_unidad_gis = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z105id_unidad_gis"), ",", "."));
               Z106nombre_categoria = cgiGet( sPrefix+"Z106nombre_categoria");
               n106nombre_categoria = (String.IsNullOrEmpty(StringUtil.RTrim( A106nombre_categoria)) ? true : false);
               Z107categoria_tareaestado = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z107categoria_tareaestado"), ",", "."));
               n107categoria_tareaestado = ((0==A107categoria_tareaestado) ? true : false);
               Z108categoria_tareafecha_creacion = context.localUtil.CToD( cgiGet( sPrefix+"Z108categoria_tareafecha_creacion"), 0);
               n108categoria_tareafecha_creacion = ((DateTime.MinValue==A108categoria_tareafecha_creacion) ? true : false);
               Z109categoria_tareahora_creacion = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z109categoria_tareahora_creacion"), ",", "."));
               n109categoria_tareahora_creacion = ((0==A109categoria_tareahora_creacion) ? true : false);
               Z110categoria_tareacreado_por = cgiGet( sPrefix+"Z110categoria_tareacreado_por");
               n110categoria_tareacreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A110categoria_tareacreado_por)) ? true : false);
               Z111categoria_tareafecha_modificacion = context.localUtil.CToD( cgiGet( sPrefix+"Z111categoria_tareafecha_modificacion"), 0);
               n111categoria_tareafecha_modificacion = ((DateTime.MinValue==A111categoria_tareafecha_modificacion) ? true : false);
               Z112categoria_tareahora_modificacion = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z112categoria_tareahora_modificacion"), ",", "."));
               n112categoria_tareahora_modificacion = ((0==A112categoria_tareahora_modificacion) ? true : false);
               Z113categoria_tareamodificado_por = cgiGet( sPrefix+"Z113categoria_tareamodificado_por");
               n113categoria_tareamodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A113categoria_tareamodificado_por)) ? true : false);
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8categoria_tareaid_tipo_categoria"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV8categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vCATEGORIA_TAREAID_TIPO_CATEGORIA"), ",", "."));
               AV25Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A104categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareaid_tipo_categoria_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtid_unidad_gis_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_unidad_gis_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_UNIDAD_GIS");
                  AnyError = 1;
                  GX_FocusControl = edtid_unidad_gis_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A105id_unidad_gis = 0;
                  AssignAttri(sPrefix, false, "A105id_unidad_gis", StringUtil.LTrimStr( (decimal)(A105id_unidad_gis), 9, 0));
               }
               else
               {
                  A105id_unidad_gis = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_gis_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A105id_unidad_gis", StringUtil.LTrimStr( (decimal)(A105id_unidad_gis), 9, 0));
               }
               A106nombre_categoria = cgiGet( edtnombre_categoria_Internalname);
               n106nombre_categoria = false;
               AssignAttri(sPrefix, false, "A106nombre_categoria", A106nombre_categoria);
               n106nombre_categoria = (String.IsNullOrEmpty(StringUtil.RTrim( A106nombre_categoria)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtcategoria_tareaestado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtcategoria_tareaestado_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIA_TAREAESTADO");
                  AnyError = 1;
                  GX_FocusControl = edtcategoria_tareaestado_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A107categoria_tareaestado = 0;
                  n107categoria_tareaestado = false;
                  AssignAttri(sPrefix, false, "A107categoria_tareaestado", StringUtil.LTrimStr( (decimal)(A107categoria_tareaestado), 9, 0));
               }
               else
               {
                  A107categoria_tareaestado = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareaestado_Internalname), ",", "."));
                  n107categoria_tareaestado = false;
                  AssignAttri(sPrefix, false, "A107categoria_tareaestado", StringUtil.LTrimStr( (decimal)(A107categoria_tareaestado), 9, 0));
               }
               n107categoria_tareaestado = ((0==A107categoria_tareaestado) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtcategoria_tareafecha_creacion_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"categoria_tareafecha_creacion"}), 1, "CATEGORIA_TAREAFECHA_CREACION");
                  AnyError = 1;
                  GX_FocusControl = edtcategoria_tareafecha_creacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A108categoria_tareafecha_creacion = DateTime.MinValue;
                  n108categoria_tareafecha_creacion = false;
                  AssignAttri(sPrefix, false, "A108categoria_tareafecha_creacion", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
               }
               else
               {
                  A108categoria_tareafecha_creacion = context.localUtil.CToD( cgiGet( edtcategoria_tareafecha_creacion_Internalname), 2);
                  n108categoria_tareafecha_creacion = false;
                  AssignAttri(sPrefix, false, "A108categoria_tareafecha_creacion", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
               }
               n108categoria_tareafecha_creacion = ((DateTime.MinValue==A108categoria_tareafecha_creacion) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtcategoria_tareahora_creacion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtcategoria_tareahora_creacion_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIA_TAREAHORA_CREACION");
                  AnyError = 1;
                  GX_FocusControl = edtcategoria_tareahora_creacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A109categoria_tareahora_creacion = 0;
                  n109categoria_tareahora_creacion = false;
                  AssignAttri(sPrefix, false, "A109categoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(A109categoria_tareahora_creacion), 5, 0));
               }
               else
               {
                  A109categoria_tareahora_creacion = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareahora_creacion_Internalname), ",", "."));
                  n109categoria_tareahora_creacion = false;
                  AssignAttri(sPrefix, false, "A109categoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(A109categoria_tareahora_creacion), 5, 0));
               }
               n109categoria_tareahora_creacion = ((0==A109categoria_tareahora_creacion) ? true : false);
               A110categoria_tareacreado_por = cgiGet( edtcategoria_tareacreado_por_Internalname);
               n110categoria_tareacreado_por = false;
               AssignAttri(sPrefix, false, "A110categoria_tareacreado_por", A110categoria_tareacreado_por);
               n110categoria_tareacreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A110categoria_tareacreado_por)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtcategoria_tareafecha_modificacion_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"categoria_tareafecha_modificacion"}), 1, "CATEGORIA_TAREAFECHA_MODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtcategoria_tareafecha_modificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A111categoria_tareafecha_modificacion = DateTime.MinValue;
                  n111categoria_tareafecha_modificacion = false;
                  AssignAttri(sPrefix, false, "A111categoria_tareafecha_modificacion", context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"));
               }
               else
               {
                  A111categoria_tareafecha_modificacion = context.localUtil.CToD( cgiGet( edtcategoria_tareafecha_modificacion_Internalname), 2);
                  n111categoria_tareafecha_modificacion = false;
                  AssignAttri(sPrefix, false, "A111categoria_tareafecha_modificacion", context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"));
               }
               n111categoria_tareafecha_modificacion = ((DateTime.MinValue==A111categoria_tareafecha_modificacion) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtcategoria_tareahora_modificacion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtcategoria_tareahora_modificacion_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIA_TAREAHORA_MODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtcategoria_tareahora_modificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A112categoria_tareahora_modificacion = 0;
                  n112categoria_tareahora_modificacion = false;
                  AssignAttri(sPrefix, false, "A112categoria_tareahora_modificacion", StringUtil.LTrimStr( (decimal)(A112categoria_tareahora_modificacion), 5, 0));
               }
               else
               {
                  A112categoria_tareahora_modificacion = (int)(context.localUtil.CToN( cgiGet( edtcategoria_tareahora_modificacion_Internalname), ",", "."));
                  n112categoria_tareahora_modificacion = false;
                  AssignAttri(sPrefix, false, "A112categoria_tareahora_modificacion", StringUtil.LTrimStr( (decimal)(A112categoria_tareahora_modificacion), 5, 0));
               }
               n112categoria_tareahora_modificacion = ((0==A112categoria_tareahora_modificacion) ? true : false);
               A113categoria_tareamodificado_por = cgiGet( edtcategoria_tareamodificado_por_Internalname);
               n113categoria_tareamodificado_por = false;
               AssignAttri(sPrefix, false, "A113categoria_tareamodificado_por", A113categoria_tareamodificado_por);
               n113categoria_tareamodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A113categoria_tareamodificado_por)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"categoria_tarea");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A104categoria_tareaid_tipo_categoria != Z104categoria_tareaid_tipo_categoria ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("categoria_tarea:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A104categoria_tareaid_tipo_categoria = (int)(NumberUtil.Val( GetPar( "categoria_tareaid_tipo_categoria"), "."));
                  AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
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
                     sMode14 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode14;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound14 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CATEGORIA_TAREAID_TIPO_CATEGORIA");
                        AnyError = 1;
                        GX_FocusControl = edtcategoria_tareaid_tipo_categoria_Internalname;
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
                                 E110D2 ();
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
                                 E120D2 ();
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
                                 E130D2 ();
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
            E120D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0D14( ) ;
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
            DisableAttributes0D14( ) ;
         }
         AssignProp(sPrefix, false, edtid_unidad_gis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_gis_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombre_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_categoria_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareaestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaestado_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareafecha_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareafecha_creacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareahora_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareahora_creacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareacreado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareacreado_por_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareafecha_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareafecha_modificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareahora_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareahora_modificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtcategoria_tareamodificado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareamodificado_por_Enabled), 5, 0), true);
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D14( ) ;
            }
            else
            {
               CheckExtendedTable0D14( ) ;
               CloseExtendedTableCursors0D14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0D0( )
      {
      }

      protected void E110D2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "categoria_tarea",  "categoria_tarea",  AV17StandardActivityType,  AV18UserActivityType,  AV25Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("categoria_tarea")),UrlEncode(StringUtil.RTrim("categoria_tarea")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV25Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "categoria_tarea", out  AV9TrnContext) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "categoria_tarea", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "categoria_tarea", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "categoria_tarea", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtid_unidad_gis_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtid_unidad_gis_Internalname, "Class", edtid_unidad_gis_Class, true);
            }
            else
            {
               edtid_unidad_gis_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtid_unidad_gis_Internalname, "Class", edtid_unidad_gis_Class, true);
            }
         }
      }

      protected void E120D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV9TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "categoria_tareaid_tipo_categoria";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "categoria_tarea",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La categoria_tarea %1 fue creada", StringUtil.Str( (decimal)(A105id_unidad_gis), 9, 0), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La categoria_tarea %1 fue actualizada", StringUtil.Str( (decimal)(A105id_unidad_gis), 9, 0), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La categoria_tarea %1 fue eliminada", StringUtil.Str( (decimal)(A105id_unidad_gis), 9, 0), "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"categoria_tarea",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV9TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV9TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "categoria_tarea") ;
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
                     args = new Object[] {(string)"_site_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A104categoria_tareaid_tipo_categoria,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A104categoria_tareaid_tipo_categoria = (int)(args[2]) ;
                        AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A104categoria_tareaid_tipo_categoria,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A104categoria_tareaid_tipo_categoria = (int)(args[2]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A104categoria_tareaid_tipo_categoria,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A104categoria_tareaid_tipo_categoria = (int)(args[1]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV11Navigation.gxTpr_Mode,(int)A104categoria_tareaid_tipo_categoria,AV11Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A104categoria_tareaid_tipo_categoria = (int)(args[2]) ;
                        AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV11Navigation.gxTpr_Mode,(int)A104categoria_tareaid_tipo_categoria,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A104categoria_tareaid_tipo_categoria = (int)(args[2]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV11Navigation.gxTpr_Mode,(int)A104categoria_tareaid_tipo_categoria,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A104categoria_tareaid_tipo_categoria = (int)(args[1]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A104categoria_tareaid_tipo_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130D2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "categoria_tarea") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"categoria_tarea"}, true);
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

      protected void ZM0D14( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z105id_unidad_gis = T000D3_A105id_unidad_gis[0];
               Z106nombre_categoria = T000D3_A106nombre_categoria[0];
               Z107categoria_tareaestado = T000D3_A107categoria_tareaestado[0];
               Z108categoria_tareafecha_creacion = T000D3_A108categoria_tareafecha_creacion[0];
               Z109categoria_tareahora_creacion = T000D3_A109categoria_tareahora_creacion[0];
               Z110categoria_tareacreado_por = T000D3_A110categoria_tareacreado_por[0];
               Z111categoria_tareafecha_modificacion = T000D3_A111categoria_tareafecha_modificacion[0];
               Z112categoria_tareahora_modificacion = T000D3_A112categoria_tareahora_modificacion[0];
               Z113categoria_tareamodificado_por = T000D3_A113categoria_tareamodificado_por[0];
            }
            else
            {
               Z105id_unidad_gis = A105id_unidad_gis;
               Z106nombre_categoria = A106nombre_categoria;
               Z107categoria_tareaestado = A107categoria_tareaestado;
               Z108categoria_tareafecha_creacion = A108categoria_tareafecha_creacion;
               Z109categoria_tareahora_creacion = A109categoria_tareahora_creacion;
               Z110categoria_tareacreado_por = A110categoria_tareacreado_por;
               Z111categoria_tareafecha_modificacion = A111categoria_tareafecha_modificacion;
               Z112categoria_tareahora_modificacion = A112categoria_tareahora_modificacion;
               Z113categoria_tareamodificado_por = A113categoria_tareamodificado_por;
            }
         }
         if ( GX_JID == -6 )
         {
            Z104categoria_tareaid_tipo_categoria = A104categoria_tareaid_tipo_categoria;
            Z105id_unidad_gis = A105id_unidad_gis;
            Z106nombre_categoria = A106nombre_categoria;
            Z107categoria_tareaestado = A107categoria_tareaestado;
            Z108categoria_tareafecha_creacion = A108categoria_tareafecha_creacion;
            Z109categoria_tareahora_creacion = A109categoria_tareahora_creacion;
            Z110categoria_tareacreado_por = A110categoria_tareacreado_por;
            Z111categoria_tareafecha_modificacion = A111categoria_tareafecha_modificacion;
            Z112categoria_tareahora_modificacion = A112categoria_tareahora_modificacion;
            Z113categoria_tareamodificado_por = A113categoria_tareamodificado_por;
         }
      }

      protected void standaloneNotModal( )
      {
         edtcategoria_tareaid_tipo_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareaid_tipo_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaid_tipo_categoria_Enabled), 5, 0), true);
         edtcategoria_tareaid_tipo_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareaid_tipo_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaid_tipo_categoria_Enabled), 5, 0), true);
         if ( ! (0==AV8categoria_tareaid_tipo_categoria) )
         {
            A104categoria_tareaid_tipo_categoria = AV8categoria_tareaid_tipo_categoria;
            AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
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

      protected void Load0D14( )
      {
         /* Using cursor T000D4 */
         pr_datastore1.execute(2, new Object[] {A104categoria_tareaid_tipo_categoria});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound14 = 1;
            A105id_unidad_gis = T000D4_A105id_unidad_gis[0];
            AssignAttri(sPrefix, false, "A105id_unidad_gis", StringUtil.LTrimStr( (decimal)(A105id_unidad_gis), 9, 0));
            A106nombre_categoria = T000D4_A106nombre_categoria[0];
            n106nombre_categoria = T000D4_n106nombre_categoria[0];
            AssignAttri(sPrefix, false, "A106nombre_categoria", A106nombre_categoria);
            A107categoria_tareaestado = T000D4_A107categoria_tareaestado[0];
            n107categoria_tareaestado = T000D4_n107categoria_tareaestado[0];
            AssignAttri(sPrefix, false, "A107categoria_tareaestado", StringUtil.LTrimStr( (decimal)(A107categoria_tareaestado), 9, 0));
            A108categoria_tareafecha_creacion = T000D4_A108categoria_tareafecha_creacion[0];
            n108categoria_tareafecha_creacion = T000D4_n108categoria_tareafecha_creacion[0];
            AssignAttri(sPrefix, false, "A108categoria_tareafecha_creacion", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
            A109categoria_tareahora_creacion = T000D4_A109categoria_tareahora_creacion[0];
            n109categoria_tareahora_creacion = T000D4_n109categoria_tareahora_creacion[0];
            AssignAttri(sPrefix, false, "A109categoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(A109categoria_tareahora_creacion), 5, 0));
            A110categoria_tareacreado_por = T000D4_A110categoria_tareacreado_por[0];
            n110categoria_tareacreado_por = T000D4_n110categoria_tareacreado_por[0];
            AssignAttri(sPrefix, false, "A110categoria_tareacreado_por", A110categoria_tareacreado_por);
            A111categoria_tareafecha_modificacion = T000D4_A111categoria_tareafecha_modificacion[0];
            n111categoria_tareafecha_modificacion = T000D4_n111categoria_tareafecha_modificacion[0];
            AssignAttri(sPrefix, false, "A111categoria_tareafecha_modificacion", context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"));
            A112categoria_tareahora_modificacion = T000D4_A112categoria_tareahora_modificacion[0];
            n112categoria_tareahora_modificacion = T000D4_n112categoria_tareahora_modificacion[0];
            AssignAttri(sPrefix, false, "A112categoria_tareahora_modificacion", StringUtil.LTrimStr( (decimal)(A112categoria_tareahora_modificacion), 5, 0));
            A113categoria_tareamodificado_por = T000D4_A113categoria_tareamodificado_por[0];
            n113categoria_tareamodificado_por = T000D4_n113categoria_tareamodificado_por[0];
            AssignAttri(sPrefix, false, "A113categoria_tareamodificado_por", A113categoria_tareamodificado_por);
            ZM0D14( -6) ;
         }
         pr_datastore1.close(2);
         OnLoadActions0D14( ) ;
      }

      protected void OnLoadActions0D14( )
      {
         AV25Pgmname = "categoria_tarea";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable0D14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "categoria_tarea";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         if ( (0==A105id_unidad_gis) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "id_unidad_gis", "", "", "", "", "", "", "", ""), 1, "ID_UNIDAD_GIS");
            AnyError = 1;
            GX_FocusControl = edtid_unidad_gis_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A108categoria_tareafecha_creacion) || ( A108categoria_tareafecha_creacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo categoria_tareafecha_creacion fuera de rango", "OutOfRange", 1, "CATEGORIA_TAREAFECHA_CREACION");
            AnyError = 1;
            GX_FocusControl = edtcategoria_tareafecha_creacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A111categoria_tareafecha_modificacion) || ( A111categoria_tareafecha_modificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo categoria_tareafecha_modificacion fuera de rango", "OutOfRange", 1, "CATEGORIA_TAREAFECHA_MODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtcategoria_tareafecha_modificacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0D14( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D14( )
      {
         /* Using cursor T000D5 */
         pr_datastore1.execute(3, new Object[] {A104categoria_tareaid_tipo_categoria});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_datastore1.execute(1, new Object[] {A104categoria_tareaid_tipo_categoria});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM0D14( 6) ;
            RcdFound14 = 1;
            A104categoria_tareaid_tipo_categoria = T000D3_A104categoria_tareaid_tipo_categoria[0];
            AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
            A105id_unidad_gis = T000D3_A105id_unidad_gis[0];
            AssignAttri(sPrefix, false, "A105id_unidad_gis", StringUtil.LTrimStr( (decimal)(A105id_unidad_gis), 9, 0));
            A106nombre_categoria = T000D3_A106nombre_categoria[0];
            n106nombre_categoria = T000D3_n106nombre_categoria[0];
            AssignAttri(sPrefix, false, "A106nombre_categoria", A106nombre_categoria);
            A107categoria_tareaestado = T000D3_A107categoria_tareaestado[0];
            n107categoria_tareaestado = T000D3_n107categoria_tareaestado[0];
            AssignAttri(sPrefix, false, "A107categoria_tareaestado", StringUtil.LTrimStr( (decimal)(A107categoria_tareaestado), 9, 0));
            A108categoria_tareafecha_creacion = T000D3_A108categoria_tareafecha_creacion[0];
            n108categoria_tareafecha_creacion = T000D3_n108categoria_tareafecha_creacion[0];
            AssignAttri(sPrefix, false, "A108categoria_tareafecha_creacion", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
            A109categoria_tareahora_creacion = T000D3_A109categoria_tareahora_creacion[0];
            n109categoria_tareahora_creacion = T000D3_n109categoria_tareahora_creacion[0];
            AssignAttri(sPrefix, false, "A109categoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(A109categoria_tareahora_creacion), 5, 0));
            A110categoria_tareacreado_por = T000D3_A110categoria_tareacreado_por[0];
            n110categoria_tareacreado_por = T000D3_n110categoria_tareacreado_por[0];
            AssignAttri(sPrefix, false, "A110categoria_tareacreado_por", A110categoria_tareacreado_por);
            A111categoria_tareafecha_modificacion = T000D3_A111categoria_tareafecha_modificacion[0];
            n111categoria_tareafecha_modificacion = T000D3_n111categoria_tareafecha_modificacion[0];
            AssignAttri(sPrefix, false, "A111categoria_tareafecha_modificacion", context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"));
            A112categoria_tareahora_modificacion = T000D3_A112categoria_tareahora_modificacion[0];
            n112categoria_tareahora_modificacion = T000D3_n112categoria_tareahora_modificacion[0];
            AssignAttri(sPrefix, false, "A112categoria_tareahora_modificacion", StringUtil.LTrimStr( (decimal)(A112categoria_tareahora_modificacion), 5, 0));
            A113categoria_tareamodificado_por = T000D3_A113categoria_tareamodificado_por[0];
            n113categoria_tareamodificado_por = T000D3_n113categoria_tareamodificado_por[0];
            AssignAttri(sPrefix, false, "A113categoria_tareamodificado_por", A113categoria_tareamodificado_por);
            Z104categoria_tareaid_tipo_categoria = A104categoria_tareaid_tipo_categoria;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0D14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0D14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0D14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D14( ) ;
         if ( RcdFound14 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D6 */
         pr_datastore1.execute(4, new Object[] {A104categoria_tareaid_tipo_categoria});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T000D6_A104categoria_tareaid_tipo_categoria[0] < A104categoria_tareaid_tipo_categoria ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T000D6_A104categoria_tareaid_tipo_categoria[0] > A104categoria_tareaid_tipo_categoria ) ) )
            {
               A104categoria_tareaid_tipo_categoria = T000D6_A104categoria_tareaid_tipo_categoria[0];
               AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
               RcdFound14 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000D7 */
         pr_datastore1.execute(5, new Object[] {A104categoria_tareaid_tipo_categoria});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T000D7_A104categoria_tareaid_tipo_categoria[0] > A104categoria_tareaid_tipo_categoria ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T000D7_A104categoria_tareaid_tipo_categoria[0] < A104categoria_tareaid_tipo_categoria ) ) )
            {
               A104categoria_tareaid_tipo_categoria = T000D7_A104categoria_tareaid_tipo_categoria[0];
               AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
               RcdFound14 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtid_unidad_gis_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0D14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( A104categoria_tareaid_tipo_categoria != Z104categoria_tareaid_tipo_categoria )
               {
                  A104categoria_tareaid_tipo_categoria = Z104categoria_tareaid_tipo_categoria;
                  AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CATEGORIA_TAREAID_TIPO_CATEGORIA");
                  AnyError = 1;
                  GX_FocusControl = edtcategoria_tareaid_tipo_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtid_unidad_gis_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0D14( ) ;
                  GX_FocusControl = edtid_unidad_gis_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A104categoria_tareaid_tipo_categoria != Z104categoria_tareaid_tipo_categoria )
               {
                  /* Insert record */
                  GX_FocusControl = edtid_unidad_gis_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0D14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CATEGORIA_TAREAID_TIPO_CATEGORIA");
                     AnyError = 1;
                     GX_FocusControl = edtcategoria_tareaid_tipo_categoria_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtid_unidad_gis_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0D14( ) ;
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
         if ( A104categoria_tareaid_tipo_categoria != Z104categoria_tareaid_tipo_categoria )
         {
            A104categoria_tareaid_tipo_categoria = Z104categoria_tareaid_tipo_categoria;
            AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CATEGORIA_TAREAID_TIPO_CATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtcategoria_tareaid_tipo_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtid_unidad_gis_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0D14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_datastore1.execute(0, new Object[] {A104categoria_tareaid_tipo_categoria});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CATEGORIA_TAREA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( Z105id_unidad_gis != T000D2_A105id_unidad_gis[0] ) || ( StringUtil.StrCmp(Z106nombre_categoria, T000D2_A106nombre_categoria[0]) != 0 ) || ( Z107categoria_tareaestado != T000D2_A107categoria_tareaestado[0] ) || ( Z108categoria_tareafecha_creacion != T000D2_A108categoria_tareafecha_creacion[0] ) || ( Z109categoria_tareahora_creacion != T000D2_A109categoria_tareahora_creacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z110categoria_tareacreado_por, T000D2_A110categoria_tareacreado_por[0]) != 0 ) || ( Z111categoria_tareafecha_modificacion != T000D2_A111categoria_tareafecha_modificacion[0] ) || ( Z112categoria_tareahora_modificacion != T000D2_A112categoria_tareahora_modificacion[0] ) || ( StringUtil.StrCmp(Z113categoria_tareamodificado_por, T000D2_A113categoria_tareamodificado_por[0]) != 0 ) )
            {
               if ( Z105id_unidad_gis != T000D2_A105id_unidad_gis[0] )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"id_unidad_gis");
                  GXUtil.WriteLogRaw("Old: ",Z105id_unidad_gis);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A105id_unidad_gis[0]);
               }
               if ( StringUtil.StrCmp(Z106nombre_categoria, T000D2_A106nombre_categoria[0]) != 0 )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"nombre_categoria");
                  GXUtil.WriteLogRaw("Old: ",Z106nombre_categoria);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A106nombre_categoria[0]);
               }
               if ( Z107categoria_tareaestado != T000D2_A107categoria_tareaestado[0] )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareaestado");
                  GXUtil.WriteLogRaw("Old: ",Z107categoria_tareaestado);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A107categoria_tareaestado[0]);
               }
               if ( Z108categoria_tareafecha_creacion != T000D2_A108categoria_tareafecha_creacion[0] )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareafecha_creacion");
                  GXUtil.WriteLogRaw("Old: ",Z108categoria_tareafecha_creacion);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A108categoria_tareafecha_creacion[0]);
               }
               if ( Z109categoria_tareahora_creacion != T000D2_A109categoria_tareahora_creacion[0] )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareahora_creacion");
                  GXUtil.WriteLogRaw("Old: ",Z109categoria_tareahora_creacion);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A109categoria_tareahora_creacion[0]);
               }
               if ( StringUtil.StrCmp(Z110categoria_tareacreado_por, T000D2_A110categoria_tareacreado_por[0]) != 0 )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareacreado_por");
                  GXUtil.WriteLogRaw("Old: ",Z110categoria_tareacreado_por);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A110categoria_tareacreado_por[0]);
               }
               if ( Z111categoria_tareafecha_modificacion != T000D2_A111categoria_tareafecha_modificacion[0] )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareafecha_modificacion");
                  GXUtil.WriteLogRaw("Old: ",Z111categoria_tareafecha_modificacion);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A111categoria_tareafecha_modificacion[0]);
               }
               if ( Z112categoria_tareahora_modificacion != T000D2_A112categoria_tareahora_modificacion[0] )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareahora_modificacion");
                  GXUtil.WriteLogRaw("Old: ",Z112categoria_tareahora_modificacion);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A112categoria_tareahora_modificacion[0]);
               }
               if ( StringUtil.StrCmp(Z113categoria_tareamodificado_por, T000D2_A113categoria_tareamodificado_por[0]) != 0 )
               {
                  GXUtil.WriteLog("categoria_tarea:[seudo value changed for attri]"+"categoria_tareamodificado_por");
                  GXUtil.WriteLogRaw("Old: ",Z113categoria_tareamodificado_por);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A113categoria_tareamodificado_por[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CATEGORIA_TAREA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D14( )
      {
         if ( ! IsAuthorized("categoria_tarea_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D14( 0) ;
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D8 */
                     pr_datastore1.execute(6, new Object[] {A105id_unidad_gis, n106nombre_categoria, A106nombre_categoria, n107categoria_tareaestado, A107categoria_tareaestado, n108categoria_tareafecha_creacion, A108categoria_tareafecha_creacion, n109categoria_tareahora_creacion, A109categoria_tareahora_creacion, n110categoria_tareacreado_por, A110categoria_tareacreado_por, n111categoria_tareafecha_modificacion, A111categoria_tareafecha_modificacion, n112categoria_tareahora_modificacion, A112categoria_tareahora_modificacion, n113categoria_tareamodificado_por, A113categoria_tareamodificado_por});
                     A104categoria_tareaid_tipo_categoria = T000D8_A104categoria_tareaid_tipo_categoria[0];
                     AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
                     pr_datastore1.close(6);
                     dsDataStore1.SmartCacheProvider.SetUpdated("CATEGORIA_TAREA");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D14( ) ;
            }
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void Update0D14( )
      {
         if ( ! IsAuthorized("categoria_tarea_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D9 */
                     pr_datastore1.execute(7, new Object[] {A105id_unidad_gis, n106nombre_categoria, A106nombre_categoria, n107categoria_tareaestado, A107categoria_tareaestado, n108categoria_tareafecha_creacion, A108categoria_tareafecha_creacion, n109categoria_tareahora_creacion, A109categoria_tareahora_creacion, n110categoria_tareacreado_por, A110categoria_tareacreado_por, n111categoria_tareafecha_modificacion, A111categoria_tareafecha_modificacion, n112categoria_tareahora_modificacion, A112categoria_tareahora_modificacion, n113categoria_tareamodificado_por, A113categoria_tareamodificado_por, A104categoria_tareaid_tipo_categoria});
                     pr_datastore1.close(7);
                     dsDataStore1.SmartCacheProvider.SetUpdated("CATEGORIA_TAREA");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CATEGORIA_TAREA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D14( ) ;
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
            EndLevel0D14( ) ;
         }
         CloseExtendedTableCursors0D14( ) ;
      }

      protected void DeferredUpdate0D14( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("categoria_tarea_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D14( ) ;
            AfterConfirm0D14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D10 */
                  pr_datastore1.execute(8, new Object[] {A104categoria_tareaid_tipo_categoria});
                  pr_datastore1.close(8);
                  dsDataStore1.SmartCacheProvider.SetUpdated("CATEGORIA_TAREA");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0D14( ) ;
         Gx_mode = sMode14;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D14( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "categoria_tarea";
            AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000D11 */
            pr_default.execute(0, new Object[] {A104categoria_tareaid_tipo_categoria});
            if ( (pr_default.getStatus(0) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ticket Tecnico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(0);
            /* Using cursor T000D12 */
            pr_default.execute(1, new Object[] {A104categoria_tareaid_tipo_categoria});
            if ( (pr_default.getStatus(1) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Estado"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(1);
         }
      }

      protected void EndLevel0D14( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D14( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore1.close(1);
            context.CommitDataStores("categoria_tarea",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore1.close(1);
            context.RollbackDataStores("categoria_tarea",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D14( )
      {
         /* Scan By routine */
         /* Using cursor T000D13 */
         pr_datastore1.execute(9);
         RcdFound14 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound14 = 1;
            A104categoria_tareaid_tipo_categoria = T000D13_A104categoria_tareaid_tipo_categoria[0];
            AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D14( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound14 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound14 = 1;
            A104categoria_tareaid_tipo_categoria = T000D13_A104categoria_tareaid_tipo_categoria[0];
            AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
         }
      }

      protected void ScanEnd0D14( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm0D14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D14( )
      {
         edtcategoria_tareaid_tipo_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareaid_tipo_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaid_tipo_categoria_Enabled), 5, 0), true);
         edtid_unidad_gis_Enabled = 0;
         AssignProp(sPrefix, false, edtid_unidad_gis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_gis_Enabled), 5, 0), true);
         edtnombre_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_categoria_Enabled), 5, 0), true);
         edtcategoria_tareaestado_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareaestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareaestado_Enabled), 5, 0), true);
         edtcategoria_tareafecha_creacion_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareafecha_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareafecha_creacion_Enabled), 5, 0), true);
         edtcategoria_tareahora_creacion_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareahora_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareahora_creacion_Enabled), 5, 0), true);
         edtcategoria_tareacreado_por_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareacreado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareacreado_por_Enabled), 5, 0), true);
         edtcategoria_tareafecha_modificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareafecha_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareafecha_modificacion_Enabled), 5, 0), true);
         edtcategoria_tareahora_modificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareahora_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareahora_modificacion_Enabled), 5, 0), true);
         edtcategoria_tareamodificado_por_Enabled = 0;
         AssignProp(sPrefix, false, edtcategoria_tareamodificado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtcategoria_tareamodificado_por_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 1810380), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20231249492660", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("categoria_tarea.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8categoria_tareaid_tipo_categoria,9,0))}, new string[] {"Gx_mode","categoria_tareaid_tipo_categoria"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"categoria_tarea");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("categoria_tarea:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z104categoria_tareaid_tipo_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z104categoria_tareaid_tipo_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z105id_unidad_gis", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z105id_unidad_gis), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z106nombre_categoria", Z106nombre_categoria);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z107categoria_tareaestado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z107categoria_tareaestado), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z108categoria_tareafecha_creacion", context.localUtil.DToC( Z108categoria_tareafecha_creacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z109categoria_tareahora_creacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z109categoria_tareahora_creacion), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z110categoria_tareacreado_por", Z110categoria_tareacreado_por);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z111categoria_tareafecha_modificacion", context.localUtil.DToC( Z111categoria_tareafecha_modificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z112categoria_tareahora_modificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z112categoria_tareahora_modificacion), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z113categoria_tareamodificado_por", Z113categoria_tareamodificado_por);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8categoria_tareaid_tipo_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8categoria_tareaid_tipo_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vCATEGORIA_TAREAID_TIPO_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8categoria_tareaid_tipo_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0D14( )
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
         return "categoria_tarea" ;
      }

      public override string GetPgmdesc( )
      {
         return "categoria_tarea" ;
      }

      protected void InitializeNonKey0D14( )
      {
         A105id_unidad_gis = 0;
         AssignAttri(sPrefix, false, "A105id_unidad_gis", StringUtil.LTrimStr( (decimal)(A105id_unidad_gis), 9, 0));
         A106nombre_categoria = "";
         n106nombre_categoria = false;
         AssignAttri(sPrefix, false, "A106nombre_categoria", A106nombre_categoria);
         n106nombre_categoria = (String.IsNullOrEmpty(StringUtil.RTrim( A106nombre_categoria)) ? true : false);
         A107categoria_tareaestado = 0;
         n107categoria_tareaestado = false;
         AssignAttri(sPrefix, false, "A107categoria_tareaestado", StringUtil.LTrimStr( (decimal)(A107categoria_tareaestado), 9, 0));
         n107categoria_tareaestado = ((0==A107categoria_tareaestado) ? true : false);
         A108categoria_tareafecha_creacion = DateTime.MinValue;
         n108categoria_tareafecha_creacion = false;
         AssignAttri(sPrefix, false, "A108categoria_tareafecha_creacion", context.localUtil.Format(A108categoria_tareafecha_creacion, "99/99/99"));
         n108categoria_tareafecha_creacion = ((DateTime.MinValue==A108categoria_tareafecha_creacion) ? true : false);
         A109categoria_tareahora_creacion = 0;
         n109categoria_tareahora_creacion = false;
         AssignAttri(sPrefix, false, "A109categoria_tareahora_creacion", StringUtil.LTrimStr( (decimal)(A109categoria_tareahora_creacion), 5, 0));
         n109categoria_tareahora_creacion = ((0==A109categoria_tareahora_creacion) ? true : false);
         A110categoria_tareacreado_por = "";
         n110categoria_tareacreado_por = false;
         AssignAttri(sPrefix, false, "A110categoria_tareacreado_por", A110categoria_tareacreado_por);
         n110categoria_tareacreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A110categoria_tareacreado_por)) ? true : false);
         A111categoria_tareafecha_modificacion = DateTime.MinValue;
         n111categoria_tareafecha_modificacion = false;
         AssignAttri(sPrefix, false, "A111categoria_tareafecha_modificacion", context.localUtil.Format(A111categoria_tareafecha_modificacion, "99/99/99"));
         n111categoria_tareafecha_modificacion = ((DateTime.MinValue==A111categoria_tareafecha_modificacion) ? true : false);
         A112categoria_tareahora_modificacion = 0;
         n112categoria_tareahora_modificacion = false;
         AssignAttri(sPrefix, false, "A112categoria_tareahora_modificacion", StringUtil.LTrimStr( (decimal)(A112categoria_tareahora_modificacion), 5, 0));
         n112categoria_tareahora_modificacion = ((0==A112categoria_tareahora_modificacion) ? true : false);
         A113categoria_tareamodificado_por = "";
         n113categoria_tareamodificado_por = false;
         AssignAttri(sPrefix, false, "A113categoria_tareamodificado_por", A113categoria_tareamodificado_por);
         n113categoria_tareamodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A113categoria_tareamodificado_por)) ? true : false);
         Z105id_unidad_gis = 0;
         Z106nombre_categoria = "";
         Z107categoria_tareaestado = 0;
         Z108categoria_tareafecha_creacion = DateTime.MinValue;
         Z109categoria_tareahora_creacion = 0;
         Z110categoria_tareacreado_por = "";
         Z111categoria_tareafecha_modificacion = DateTime.MinValue;
         Z112categoria_tareahora_modificacion = 0;
         Z113categoria_tareamodificado_por = "";
      }

      protected void InitAll0D14( )
      {
         A104categoria_tareaid_tipo_categoria = 0;
         AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
         InitializeNonKey0D14( ) ;
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
         sCtrlAV8categoria_tareaid_tipo_categoria = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "categoria_tarea", GetJustCreated( ));
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
            AV8categoria_tareaid_tipo_categoria = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV8categoria_tareaid_tipo_categoria), 9, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8categoria_tareaid_tipo_categoria"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8categoria_tareaid_tipo_categoria != wcpOAV8categoria_tareaid_tipo_categoria ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8categoria_tareaid_tipo_categoria = AV8categoria_tareaid_tipo_categoria;
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
         sCtrlAV8categoria_tareaid_tipo_categoria = cgiGet( sPrefix+"AV8categoria_tareaid_tipo_categoria_CTRL");
         if ( StringUtil.Len( sCtrlAV8categoria_tareaid_tipo_categoria) > 0 )
         {
            AV8categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8categoria_tareaid_tipo_categoria), ",", "."));
            AssignAttri(sPrefix, false, "AV8categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(AV8categoria_tareaid_tipo_categoria), 9, 0));
         }
         else
         {
            AV8categoria_tareaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8categoria_tareaid_tipo_categoria_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8categoria_tareaid_tipo_categoria_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8categoria_tareaid_tipo_categoria), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8categoria_tareaid_tipo_categoria)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8categoria_tareaid_tipo_categoria_CTRL", StringUtil.RTrim( sCtrlAV8categoria_tareaid_tipo_categoria));
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
         AddStyleSheetFile("K2BControlBeautify/silviomoreto-bootstrap-select/dist/css/bootstrap-select.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249492683", true, true);
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
         context.AddJavascriptSource("categoria_tarea.js", "?20231249492684", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtcategoria_tareaid_tipo_categoria_Internalname = sPrefix+"CATEGORIA_TAREAID_TIPO_CATEGORIA";
         divK2btoolstable_attributecontainercategoria_tareaid_tipo_categoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAID_TIPO_CATEGORIA";
         edtid_unidad_gis_Internalname = sPrefix+"ID_UNIDAD_GIS";
         divK2btoolstable_attributecontainerid_unidad_gis_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_UNIDAD_GIS";
         edtnombre_categoria_Internalname = sPrefix+"NOMBRE_CATEGORIA";
         divK2btoolstable_attributecontainernombre_categoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_CATEGORIA";
         edtcategoria_tareaestado_Internalname = sPrefix+"CATEGORIA_TAREAESTADO";
         divK2btoolstable_attributecontainercategoria_tareaestado_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAESTADO";
         edtcategoria_tareafecha_creacion_Internalname = sPrefix+"CATEGORIA_TAREAFECHA_CREACION";
         divK2btoolstable_attributecontainercategoria_tareafecha_creacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAFECHA_CREACION";
         edtcategoria_tareahora_creacion_Internalname = sPrefix+"CATEGORIA_TAREAHORA_CREACION";
         divK2btoolstable_attributecontainercategoria_tareahora_creacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAHORA_CREACION";
         edtcategoria_tareacreado_por_Internalname = sPrefix+"CATEGORIA_TAREACREADO_POR";
         divK2btoolstable_attributecontainercategoria_tareacreado_por_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREACREADO_POR";
         edtcategoria_tareafecha_modificacion_Internalname = sPrefix+"CATEGORIA_TAREAFECHA_MODIFICACION";
         divK2btoolstable_attributecontainercategoria_tareafecha_modificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAFECHA_MODIFICACION";
         edtcategoria_tareahora_modificacion_Internalname = sPrefix+"CATEGORIA_TAREAHORA_MODIFICACION";
         divK2btoolstable_attributecontainercategoria_tareahora_modificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAHORA_MODIFICACION";
         edtcategoria_tareamodificado_por_Internalname = sPrefix+"CATEGORIA_TAREAMODIFICADO_POR";
         divK2btoolstable_attributecontainercategoria_tareamodificado_por_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIA_TAREAMODIFICADO_POR";
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
         Form.Caption = "categoria_tarea";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtcategoria_tareamodificado_por_Jsonclick = "";
         edtcategoria_tareamodificado_por_Enabled = 1;
         edtcategoria_tareahora_modificacion_Jsonclick = "";
         edtcategoria_tareahora_modificacion_Enabled = 1;
         edtcategoria_tareafecha_modificacion_Jsonclick = "";
         edtcategoria_tareafecha_modificacion_Enabled = 1;
         edtcategoria_tareacreado_por_Jsonclick = "";
         edtcategoria_tareacreado_por_Enabled = 1;
         edtcategoria_tareahora_creacion_Jsonclick = "";
         edtcategoria_tareahora_creacion_Enabled = 1;
         edtcategoria_tareafecha_creacion_Jsonclick = "";
         edtcategoria_tareafecha_creacion_Enabled = 1;
         edtcategoria_tareaestado_Jsonclick = "";
         edtcategoria_tareaestado_Enabled = 1;
         edtnombre_categoria_Enabled = 1;
         edtid_unidad_gis_Jsonclick = "";
         edtid_unidad_gis_Class = "Attribute_Trn Attribute_Required";
         edtid_unidad_gis_Enabled = 1;
         edtcategoria_tareaid_tipo_categoria_Jsonclick = "";
         edtcategoria_tareaid_tipo_categoria_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8categoria_tareaid_tipo_categoria',fld:'vCATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120D2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A104categoria_tareaid_tipo_categoria',fld:'CATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A105id_unidad_gis',fld:'ID_UNIDAD_GIS',pic:'ZZZZZZZZ9'},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A104categoria_tareaid_tipo_categoria',fld:'CATEGORIA_TAREAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130D2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIA_TAREAID_TIPO_CATEGORIA","{handler:'Valid_Categoria_tareaid_tipo_categoria',iparms:[]");
         setEventMetadata("VALID_CATEGORIA_TAREAID_TIPO_CATEGORIA",",oparms:[]}");
         setEventMetadata("VALID_ID_UNIDAD_GIS","{handler:'Valid_Id_unidad_gis',iparms:[]");
         setEventMetadata("VALID_ID_UNIDAD_GIS",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIA_TAREAFECHA_CREACION","{handler:'Valid_Categoria_tareafecha_creacion',iparms:[]");
         setEventMetadata("VALID_CATEGORIA_TAREAFECHA_CREACION",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIA_TAREAFECHA_MODIFICACION","{handler:'Valid_Categoria_tareafecha_modificacion',iparms:[]");
         setEventMetadata("VALID_CATEGORIA_TAREAFECHA_MODIFICACION",",oparms:[]}");
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
         Z106nombre_categoria = "";
         Z108categoria_tareafecha_creacion = DateTime.MinValue;
         Z110categoria_tareacreado_por = "";
         Z111categoria_tareafecha_modificacion = DateTime.MinValue;
         Z113categoria_tareamodificado_por = "";
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
         TempTags = "";
         A106nombre_categoria = "";
         A108categoria_tareafecha_creacion = DateTime.MinValue;
         A110categoria_tareacreado_por = "";
         A111categoria_tareafecha_modificacion = DateTime.MinValue;
         A113categoria_tareamodificado_por = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV25Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode14 = "";
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
         T000D4_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D4_A105id_unidad_gis = new int[1] ;
         T000D4_A106nombre_categoria = new string[] {""} ;
         T000D4_n106nombre_categoria = new bool[] {false} ;
         T000D4_A107categoria_tareaestado = new int[1] ;
         T000D4_n107categoria_tareaestado = new bool[] {false} ;
         T000D4_A108categoria_tareafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000D4_n108categoria_tareafecha_creacion = new bool[] {false} ;
         T000D4_A109categoria_tareahora_creacion = new int[1] ;
         T000D4_n109categoria_tareahora_creacion = new bool[] {false} ;
         T000D4_A110categoria_tareacreado_por = new string[] {""} ;
         T000D4_n110categoria_tareacreado_por = new bool[] {false} ;
         T000D4_A111categoria_tareafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000D4_n111categoria_tareafecha_modificacion = new bool[] {false} ;
         T000D4_A112categoria_tareahora_modificacion = new int[1] ;
         T000D4_n112categoria_tareahora_modificacion = new bool[] {false} ;
         T000D4_A113categoria_tareamodificado_por = new string[] {""} ;
         T000D4_n113categoria_tareamodificado_por = new bool[] {false} ;
         T000D5_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D3_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D3_A105id_unidad_gis = new int[1] ;
         T000D3_A106nombre_categoria = new string[] {""} ;
         T000D3_n106nombre_categoria = new bool[] {false} ;
         T000D3_A107categoria_tareaestado = new int[1] ;
         T000D3_n107categoria_tareaestado = new bool[] {false} ;
         T000D3_A108categoria_tareafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000D3_n108categoria_tareafecha_creacion = new bool[] {false} ;
         T000D3_A109categoria_tareahora_creacion = new int[1] ;
         T000D3_n109categoria_tareahora_creacion = new bool[] {false} ;
         T000D3_A110categoria_tareacreado_por = new string[] {""} ;
         T000D3_n110categoria_tareacreado_por = new bool[] {false} ;
         T000D3_A111categoria_tareafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000D3_n111categoria_tareafecha_modificacion = new bool[] {false} ;
         T000D3_A112categoria_tareahora_modificacion = new int[1] ;
         T000D3_n112categoria_tareahora_modificacion = new bool[] {false} ;
         T000D3_A113categoria_tareamodificado_por = new string[] {""} ;
         T000D3_n113categoria_tareamodificado_por = new bool[] {false} ;
         T000D6_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D7_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D2_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D2_A105id_unidad_gis = new int[1] ;
         T000D2_A106nombre_categoria = new string[] {""} ;
         T000D2_n106nombre_categoria = new bool[] {false} ;
         T000D2_A107categoria_tareaestado = new int[1] ;
         T000D2_n107categoria_tareaestado = new bool[] {false} ;
         T000D2_A108categoria_tareafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000D2_n108categoria_tareafecha_creacion = new bool[] {false} ;
         T000D2_A109categoria_tareahora_creacion = new int[1] ;
         T000D2_n109categoria_tareahora_creacion = new bool[] {false} ;
         T000D2_A110categoria_tareacreado_por = new string[] {""} ;
         T000D2_n110categoria_tareacreado_por = new bool[] {false} ;
         T000D2_A111categoria_tareafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000D2_n111categoria_tareafecha_modificacion = new bool[] {false} ;
         T000D2_A112categoria_tareahora_modificacion = new int[1] ;
         T000D2_n112categoria_tareahora_modificacion = new bool[] {false} ;
         T000D2_A113categoria_tareamodificado_por = new string[] {""} ;
         T000D2_n113categoria_tareamodificado_por = new bool[] {false} ;
         T000D8_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000D11_A18TicketTecnicoId = new long[1] ;
         T000D12_A3EstadoId = new short[1] ;
         T000D13_A104categoria_tareaid_tipo_categoria = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV8categoria_tareaid_tipo_categoria = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.categoria_tarea__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.categoria_tarea__datastore1(),
            new Object[][] {
                new Object[] {
               T000D2_A104categoria_tareaid_tipo_categoria, T000D2_A105id_unidad_gis, T000D2_A106nombre_categoria, T000D2_n106nombre_categoria, T000D2_A107categoria_tareaestado, T000D2_n107categoria_tareaestado, T000D2_A108categoria_tareafecha_creacion, T000D2_n108categoria_tareafecha_creacion, T000D2_A109categoria_tareahora_creacion, T000D2_n109categoria_tareahora_creacion,
               T000D2_A110categoria_tareacreado_por, T000D2_n110categoria_tareacreado_por, T000D2_A111categoria_tareafecha_modificacion, T000D2_n111categoria_tareafecha_modificacion, T000D2_A112categoria_tareahora_modificacion, T000D2_n112categoria_tareahora_modificacion, T000D2_A113categoria_tareamodificado_por, T000D2_n113categoria_tareamodificado_por
               }
               , new Object[] {
               T000D3_A104categoria_tareaid_tipo_categoria, T000D3_A105id_unidad_gis, T000D3_A106nombre_categoria, T000D3_n106nombre_categoria, T000D3_A107categoria_tareaestado, T000D3_n107categoria_tareaestado, T000D3_A108categoria_tareafecha_creacion, T000D3_n108categoria_tareafecha_creacion, T000D3_A109categoria_tareahora_creacion, T000D3_n109categoria_tareahora_creacion,
               T000D3_A110categoria_tareacreado_por, T000D3_n110categoria_tareacreado_por, T000D3_A111categoria_tareafecha_modificacion, T000D3_n111categoria_tareafecha_modificacion, T000D3_A112categoria_tareahora_modificacion, T000D3_n112categoria_tareahora_modificacion, T000D3_A113categoria_tareamodificado_por, T000D3_n113categoria_tareamodificado_por
               }
               , new Object[] {
               T000D4_A104categoria_tareaid_tipo_categoria, T000D4_A105id_unidad_gis, T000D4_A106nombre_categoria, T000D4_n106nombre_categoria, T000D4_A107categoria_tareaestado, T000D4_n107categoria_tareaestado, T000D4_A108categoria_tareafecha_creacion, T000D4_n108categoria_tareafecha_creacion, T000D4_A109categoria_tareahora_creacion, T000D4_n109categoria_tareahora_creacion,
               T000D4_A110categoria_tareacreado_por, T000D4_n110categoria_tareacreado_por, T000D4_A111categoria_tareafecha_modificacion, T000D4_n111categoria_tareafecha_modificacion, T000D4_A112categoria_tareahora_modificacion, T000D4_n112categoria_tareahora_modificacion, T000D4_A113categoria_tareamodificado_por, T000D4_n113categoria_tareamodificado_por
               }
               , new Object[] {
               T000D5_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               T000D6_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               T000D7_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               T000D8_A104categoria_tareaid_tipo_categoria
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D13_A104categoria_tareaid_tipo_categoria
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.categoria_tarea__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoria_tarea__default(),
            new Object[][] {
                new Object[] {
               T000D11_A18TicketTecnicoId
               }
               , new Object[] {
               T000D12_A3EstadoId
               }
            }
         );
         AV25Pgmname = "categoria_tarea";
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
      private short RcdFound14 ;
      private short GX_JID ;
      private short nIsDirty_14 ;
      private short Gx_BScreen ;
      private int wcpOAV8categoria_tareaid_tipo_categoria ;
      private int Z104categoria_tareaid_tipo_categoria ;
      private int Z105id_unidad_gis ;
      private int Z107categoria_tareaestado ;
      private int Z109categoria_tareahora_creacion ;
      private int Z112categoria_tareahora_modificacion ;
      private int AV8categoria_tareaid_tipo_categoria ;
      private int trnEnded ;
      private int A104categoria_tareaid_tipo_categoria ;
      private int edtcategoria_tareaid_tipo_categoria_Enabled ;
      private int A105id_unidad_gis ;
      private int edtid_unidad_gis_Enabled ;
      private int edtnombre_categoria_Enabled ;
      private int A107categoria_tareaestado ;
      private int edtcategoria_tareaestado_Enabled ;
      private int edtcategoria_tareafecha_creacion_Enabled ;
      private int A109categoria_tareahora_creacion ;
      private int edtcategoria_tareahora_creacion_Enabled ;
      private int edtcategoria_tareacreado_por_Enabled ;
      private int edtcategoria_tareafecha_modificacion_Enabled ;
      private int A112categoria_tareahora_modificacion ;
      private int edtcategoria_tareahora_modificacion_Enabled ;
      private int edtcategoria_tareamodificado_por_Enabled ;
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
      private string edtid_unidad_gis_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainercategoria_tareaid_tipo_categoria_Internalname ;
      private string edtcategoria_tareaid_tipo_categoria_Internalname ;
      private string edtcategoria_tareaid_tipo_categoria_Jsonclick ;
      private string divK2btoolstable_attributecontainerid_unidad_gis_Internalname ;
      private string TempTags ;
      private string edtid_unidad_gis_Jsonclick ;
      private string edtid_unidad_gis_Class ;
      private string divK2btoolstable_attributecontainernombre_categoria_Internalname ;
      private string edtnombre_categoria_Internalname ;
      private string divK2btoolstable_attributecontainercategoria_tareaestado_Internalname ;
      private string edtcategoria_tareaestado_Internalname ;
      private string edtcategoria_tareaestado_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoria_tareafecha_creacion_Internalname ;
      private string edtcategoria_tareafecha_creacion_Internalname ;
      private string edtcategoria_tareafecha_creacion_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoria_tareahora_creacion_Internalname ;
      private string edtcategoria_tareahora_creacion_Internalname ;
      private string edtcategoria_tareahora_creacion_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoria_tareacreado_por_Internalname ;
      private string edtcategoria_tareacreado_por_Internalname ;
      private string edtcategoria_tareacreado_por_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoria_tareafecha_modificacion_Internalname ;
      private string edtcategoria_tareafecha_modificacion_Internalname ;
      private string edtcategoria_tareafecha_modificacion_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoria_tareahora_modificacion_Internalname ;
      private string edtcategoria_tareahora_modificacion_Internalname ;
      private string edtcategoria_tareahora_modificacion_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoria_tareamodificado_por_Internalname ;
      private string edtcategoria_tareamodificado_por_Internalname ;
      private string edtcategoria_tareamodificado_por_Jsonclick ;
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
      private string sMode14 ;
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
      private string sCtrlAV8categoria_tareaid_tipo_categoria ;
      private DateTime Z108categoria_tareafecha_creacion ;
      private DateTime Z111categoria_tareafecha_modificacion ;
      private DateTime A108categoria_tareafecha_creacion ;
      private DateTime A111categoria_tareafecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n106nombre_categoria ;
      private bool n107categoria_tareaestado ;
      private bool n108categoria_tareafecha_creacion ;
      private bool n109categoria_tareahora_creacion ;
      private bool n110categoria_tareacreado_por ;
      private bool n111categoria_tareafecha_modificacion ;
      private bool n112categoria_tareahora_modificacion ;
      private bool n113categoria_tareamodificado_por ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
      private bool Gx_longc ;
      private string Z106nombre_categoria ;
      private string Z110categoria_tareacreado_por ;
      private string Z113categoria_tareamodificado_por ;
      private string A106nombre_categoria ;
      private string A110categoria_tareacreado_por ;
      private string A113categoria_tareamodificado_por ;
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
      private int[] T000D4_A104categoria_tareaid_tipo_categoria ;
      private int[] T000D4_A105id_unidad_gis ;
      private string[] T000D4_A106nombre_categoria ;
      private bool[] T000D4_n106nombre_categoria ;
      private int[] T000D4_A107categoria_tareaestado ;
      private bool[] T000D4_n107categoria_tareaestado ;
      private DateTime[] T000D4_A108categoria_tareafecha_creacion ;
      private bool[] T000D4_n108categoria_tareafecha_creacion ;
      private int[] T000D4_A109categoria_tareahora_creacion ;
      private bool[] T000D4_n109categoria_tareahora_creacion ;
      private string[] T000D4_A110categoria_tareacreado_por ;
      private bool[] T000D4_n110categoria_tareacreado_por ;
      private DateTime[] T000D4_A111categoria_tareafecha_modificacion ;
      private bool[] T000D4_n111categoria_tareafecha_modificacion ;
      private int[] T000D4_A112categoria_tareahora_modificacion ;
      private bool[] T000D4_n112categoria_tareahora_modificacion ;
      private string[] T000D4_A113categoria_tareamodificado_por ;
      private bool[] T000D4_n113categoria_tareamodificado_por ;
      private int[] T000D5_A104categoria_tareaid_tipo_categoria ;
      private int[] T000D3_A104categoria_tareaid_tipo_categoria ;
      private int[] T000D3_A105id_unidad_gis ;
      private string[] T000D3_A106nombre_categoria ;
      private bool[] T000D3_n106nombre_categoria ;
      private int[] T000D3_A107categoria_tareaestado ;
      private bool[] T000D3_n107categoria_tareaestado ;
      private DateTime[] T000D3_A108categoria_tareafecha_creacion ;
      private bool[] T000D3_n108categoria_tareafecha_creacion ;
      private int[] T000D3_A109categoria_tareahora_creacion ;
      private bool[] T000D3_n109categoria_tareahora_creacion ;
      private string[] T000D3_A110categoria_tareacreado_por ;
      private bool[] T000D3_n110categoria_tareacreado_por ;
      private DateTime[] T000D3_A111categoria_tareafecha_modificacion ;
      private bool[] T000D3_n111categoria_tareafecha_modificacion ;
      private int[] T000D3_A112categoria_tareahora_modificacion ;
      private bool[] T000D3_n112categoria_tareahora_modificacion ;
      private string[] T000D3_A113categoria_tareamodificado_por ;
      private bool[] T000D3_n113categoria_tareamodificado_por ;
      private int[] T000D6_A104categoria_tareaid_tipo_categoria ;
      private int[] T000D7_A104categoria_tareaid_tipo_categoria ;
      private int[] T000D2_A104categoria_tareaid_tipo_categoria ;
      private int[] T000D2_A105id_unidad_gis ;
      private string[] T000D2_A106nombre_categoria ;
      private bool[] T000D2_n106nombre_categoria ;
      private int[] T000D2_A107categoria_tareaestado ;
      private bool[] T000D2_n107categoria_tareaestado ;
      private DateTime[] T000D2_A108categoria_tareafecha_creacion ;
      private bool[] T000D2_n108categoria_tareafecha_creacion ;
      private int[] T000D2_A109categoria_tareahora_creacion ;
      private bool[] T000D2_n109categoria_tareahora_creacion ;
      private string[] T000D2_A110categoria_tareacreado_por ;
      private bool[] T000D2_n110categoria_tareacreado_por ;
      private DateTime[] T000D2_A111categoria_tareafecha_modificacion ;
      private bool[] T000D2_n111categoria_tareafecha_modificacion ;
      private int[] T000D2_A112categoria_tareahora_modificacion ;
      private bool[] T000D2_n112categoria_tareahora_modificacion ;
      private string[] T000D2_A113categoria_tareamodificado_por ;
      private bool[] T000D2_n113categoria_tareamodificado_por ;
      private int[] T000D8_A104categoria_tareaid_tipo_categoria ;
      private IDataStoreProvider pr_default ;
      private long[] T000D11_A18TicketTecnicoId ;
      private short[] T000D12_A3EstadoId ;
      private int[] T000D13_A104categoria_tareaid_tipo_categoria ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV7HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV21AttributeValue ;
      private SdtK2BTrnContext AV9TrnContext ;
      private SdtK2BTrnNavigation AV11Navigation ;
      private SdtK2BContext AV13Context ;
      private SdtK2BAttributeValue_Item AV22AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV23Message ;
   }

   public class categoria_tarea__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class categoria_tarea__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new ParDef("@id_unidad_gis",GXType.Int32,9,0) ,
        new ParDef("@nombre_categoria",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@categoria_tareaestado",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@categoria_tareafecha_creacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@categoria_tareahora_creacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@categoria_tareacreado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@categoria_tareafecha_modificacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@categoria_tareahora_modificacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@categoria_tareamodificado_por",GXType.NVarChar,30,0){Nullable=true}
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new ParDef("@id_unidad_gis",GXType.Int32,9,0) ,
        new ParDef("@nombre_categoria",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@categoria_tareaestado",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@categoria_tareafecha_creacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@categoria_tareahora_creacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@categoria_tareacreado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@categoria_tareafecha_modificacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@categoria_tareahora_modificacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@categoria_tareamodificado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000D13;
        prmT000D13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT [id_tipo_categoria], [id_unidad_gis], [nombre_categoria], [estado], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por] FROM dbo.[categoria_tarea] WITH (UPDLOCK) WHERE [id_tipo_categoria] = @categoria_tareaid_tipo_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT [id_tipo_categoria], [id_unidad_gis], [nombre_categoria], [estado], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @categoria_tareaid_tipo_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT TM1.[id_tipo_categoria], TM1.[id_unidad_gis], TM1.[nombre_categoria], TM1.[estado], TM1.[fecha_creacion], TM1.[hora_creacion], TM1.[creado_por], TM1.[fecha_modificacion], TM1.[hora_modificacion], TM1.[modificado_por] FROM dbo.[categoria_tarea] TM1 WHERE TM1.[id_tipo_categoria] = @categoria_tareaid_tipo_categoria ORDER BY TM1.[id_tipo_categoria]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT [id_tipo_categoria] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @categoria_tareaid_tipo_categoria  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT TOP 1 [id_tipo_categoria] FROM dbo.[categoria_tarea] WHERE ( [id_tipo_categoria] > @categoria_tareaid_tipo_categoria) ORDER BY [id_tipo_categoria]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D7", "SELECT TOP 1 [id_tipo_categoria] FROM dbo.[categoria_tarea] WHERE ( [id_tipo_categoria] < @categoria_tareaid_tipo_categoria) ORDER BY [id_tipo_categoria] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D8", "INSERT INTO dbo.[categoria_tarea]([id_unidad_gis], [nombre_categoria], [estado], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por]) VALUES(@id_unidad_gis, @nombre_categoria, @categoria_tareaestado, @categoria_tareafecha_creacion, @categoria_tareahora_creacion, @categoria_tareacreado_por, @categoria_tareafecha_modificacion, @categoria_tareahora_modificacion, @categoria_tareamodificado_por); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000D8)
           ,new CursorDef("T000D9", "UPDATE dbo.[categoria_tarea] SET [id_unidad_gis]=@id_unidad_gis, [nombre_categoria]=@nombre_categoria, [estado]=@categoria_tareaestado, [fecha_creacion]=@categoria_tareafecha_creacion, [hora_creacion]=@categoria_tareahora_creacion, [creado_por]=@categoria_tareacreado_por, [fecha_modificacion]=@categoria_tareafecha_modificacion, [hora_modificacion]=@categoria_tareahora_modificacion, [modificado_por]=@categoria_tareamodificado_por  WHERE [id_tipo_categoria] = @categoria_tareaid_tipo_categoria", GxErrorMask.GX_NOMASK,prmT000D9)
           ,new CursorDef("T000D10", "DELETE FROM dbo.[categoria_tarea]  WHERE [id_tipo_categoria] = @categoria_tareaid_tipo_categoria", GxErrorMask.GX_NOMASK,prmT000D10)
           ,new CursorDef("T000D13", "SELECT [id_tipo_categoria] FROM dbo.[categoria_tarea] ORDER BY [id_tipo_categoria]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((int[]) buf[8])[0] = rslt.getInt(6);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              ((string[]) buf[10])[0] = rslt.getVarchar(7);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(8);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((int[]) buf[14])[0] = rslt.getInt(9);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getVarchar(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((int[]) buf[8])[0] = rslt.getInt(6);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              ((string[]) buf[10])[0] = rslt.getVarchar(7);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(8);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((int[]) buf[14])[0] = rslt.getInt(9);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getVarchar(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((bool[]) buf[5])[0] = rslt.wasNull(4);
              ((DateTime[]) buf[6])[0] = rslt.getGXDate(5);
              ((bool[]) buf[7])[0] = rslt.wasNull(5);
              ((int[]) buf[8])[0] = rslt.getInt(6);
              ((bool[]) buf[9])[0] = rslt.wasNull(6);
              ((string[]) buf[10])[0] = rslt.getVarchar(7);
              ((bool[]) buf[11])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[12])[0] = rslt.getGXDate(8);
              ((bool[]) buf[13])[0] = rslt.wasNull(8);
              ((int[]) buf[14])[0] = rslt.getInt(9);
              ((bool[]) buf[15])[0] = rslt.wasNull(9);
              ((string[]) buf[16])[0] = rslt.getVarchar(10);
              ((bool[]) buf[17])[0] = rslt.wasNull(10);
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

public class categoria_tarea__gam : DataStoreHelperBase, IDataStoreHelper
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

public class categoria_tarea__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000D11;
       prmT000D11 = new Object[] {
       new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
       };
       Object[] prmT000D12;
       prmT000D12 = new Object[] {
       new ParDef("@categoria_tareaid_tipo_categoria",GXType.Int32,9,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000D11", "SELECT TOP 1 [TicketTecnicoId] FROM [TicketTecnico] WHERE [SgActividadIdCategoria] = @categoria_tareaid_tipo_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000D12", "SELECT TOP 1 [EstadoId] FROM [Estado] WHERE [SgCategoriaId] = @categoria_tareaid_tipo_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D12,1, GxCacheFrequency.OFF ,true,true )
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
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
