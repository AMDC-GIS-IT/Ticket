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
   public class actividades_categoria : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV8id_actividad_categoria = (int)(NumberUtil.Val( GetPar( "id_actividad_categoria"), "."));
               AssignAttri(sPrefix, false, "AV8id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV8id_actividad_categoria), 9, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV8id_actividad_categoria});
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
                  AV8id_actividad_categoria = (int)(NumberUtil.Val( GetPar( "id_actividad_categoria"), "."));
                  AssignAttri(sPrefix, false, "AV8id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV8id_actividad_categoria), 9, 0));
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
               Form.Meta.addItem("description", "actividades_categoria", 0) ;
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
            GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
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

      public actividades_categoria( )
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

      public actividades_categoria( IGxContext context )
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
                           int aP1_id_actividad_categoria )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8id_actividad_categoria = aP1_id_actividad_categoria;
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
            return "actividades_categoria_Execute" ;
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
            RenderHtmlCloseForm0C13( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "actividades_categoria.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_actividad_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_actividad_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_actividad_categoria_Internalname, "id_actividad_categoria", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         GxWebStd.gx_single_line_edit( context, edtid_actividad_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ",", "")), ((edtid_actividad_categoria_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_actividad_categoria_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtid_actividad_categoria_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriaid_tipo_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriaid_tipo_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriaid_tipo_categoria_Internalname, "id_tipo_categoria", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A122actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriaid_tipo_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0, ",", "")), ((edtactividades_categoriaid_tipo_categoria_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A122actividades_categoriaid_tipo_categoria), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A122actividades_categoriaid_tipo_categoria), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriaid_tipo_categoria_Jsonclick, 0, edtactividades_categoriaid_tipo_categoria_Class, "", "", "", "", 1, edtactividades_categoriaid_tipo_categoria_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_actividad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtnombre_actividad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_actividad_Internalname, "nombre_actividad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_actividad_Internalname, A123nombre_actividad, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", 0, 1, edtnombre_actividad_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidad_medida_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidad_medida_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidad_medida_Internalname, "unidad_medida", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A124unidad_medida", A124unidad_medida);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtunidad_medida_Internalname, A124unidad_medida, StringUtil.RTrim( context.localUtil.Format( A124unidad_medida, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidad_medida_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtunidad_medida_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriaestado_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriaestado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriaestado_Internalname, "estado", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A125actividades_categoriaestado", StringUtil.LTrimStr( (decimal)(A125actividades_categoriaestado), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriaestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A125actividades_categoriaestado), 9, 0, ",", "")), ((edtactividades_categoriaestado_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A125actividades_categoriaestado), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A125actividades_categoriaestado), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriaestado_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtactividades_categoriaestado_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_enero_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_enero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_enero_Internalname, "programa_enero", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A126programa_enero", StringUtil.LTrimStr( (decimal)(A126programa_enero), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_enero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A126programa_enero), 9, 0, ",", "")), ((edtprograma_enero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A126programa_enero), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A126programa_enero), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_enero_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_enero_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_febrero_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_febrero_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_febrero_Internalname, "programa_febrero", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A127programa_febrero", StringUtil.LTrimStr( (decimal)(A127programa_febrero), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_febrero_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A127programa_febrero), 9, 0, ",", "")), ((edtprograma_febrero_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A127programa_febrero), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A127programa_febrero), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_febrero_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_febrero_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_marzo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_marzo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_marzo_Internalname, "programa_marzo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A128programa_marzo", StringUtil.LTrimStr( (decimal)(A128programa_marzo), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_marzo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A128programa_marzo), 9, 0, ",", "")), ((edtprograma_marzo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A128programa_marzo), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A128programa_marzo), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_marzo_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_marzo_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_abril_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_abril_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_abril_Internalname, "programa_abril", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A129programa_abril", StringUtil.LTrimStr( (decimal)(A129programa_abril), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_abril_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A129programa_abril), 9, 0, ",", "")), ((edtprograma_abril_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A129programa_abril), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A129programa_abril), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_abril_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_abril_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_mayo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_mayo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_mayo_Internalname, "programa_mayo", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A130programa_mayo", StringUtil.LTrimStr( (decimal)(A130programa_mayo), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_mayo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A130programa_mayo), 9, 0, ",", "")), ((edtprograma_mayo_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A130programa_mayo), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A130programa_mayo), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_mayo_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_mayo_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_junio_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_junio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_junio_Internalname, "programa_junio", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A131programa_junio", StringUtil.LTrimStr( (decimal)(A131programa_junio), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_junio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A131programa_junio), 9, 0, ",", "")), ((edtprograma_junio_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A131programa_junio), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A131programa_junio), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_junio_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_junio_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_julio_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_julio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_julio_Internalname, "programa_julio", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A132programa_julio", StringUtil.LTrimStr( (decimal)(A132programa_julio), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_julio_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A132programa_julio), 9, 0, ",", "")), ((edtprograma_julio_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A132programa_julio), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A132programa_julio), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,84);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_julio_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_julio_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_agosto_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_agosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_agosto_Internalname, "programa_agosto", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A133programa_agosto", StringUtil.LTrimStr( (decimal)(A133programa_agosto), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_agosto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A133programa_agosto), 9, 0, ",", "")), ((edtprograma_agosto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A133programa_agosto), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A133programa_agosto), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,90);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_agosto_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_agosto_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_sept_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_sept_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_sept_Internalname, "programa_sept", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A134programa_sept", StringUtil.LTrimStr( (decimal)(A134programa_sept), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_sept_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A134programa_sept), 9, 0, ",", "")), ((edtprograma_sept_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A134programa_sept), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A134programa_sept), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_sept_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_sept_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_oct_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_oct_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_oct_Internalname, "programa_oct", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A135programa_oct", StringUtil.LTrimStr( (decimal)(A135programa_oct), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_oct_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A135programa_oct), 9, 0, ",", "")), ((edtprograma_oct_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A135programa_oct), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A135programa_oct), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_oct_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_oct_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_nov_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_nov_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_nov_Internalname, "programa_nov", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A136programa_nov", StringUtil.LTrimStr( (decimal)(A136programa_nov), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_nov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A136programa_nov), 9, 0, ",", "")), ((edtprograma_nov_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A136programa_nov), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A136programa_nov), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,108);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_nov_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_nov_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerprograma_dic_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtprograma_dic_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtprograma_dic_Internalname, "programa_dic", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A137programa_dic", StringUtil.LTrimStr( (decimal)(A137programa_dic), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtprograma_dic_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137programa_dic), 9, 0, ",", "")), ((edtprograma_dic_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A137programa_dic), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A137programa_dic), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,114);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtprograma_dic_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtprograma_dic_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriafecha_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriafecha_creacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriafecha_creacion_Internalname, "fecha_creacion", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A138actividades_categoriafecha_creacion", context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtactividades_categoriafecha_creacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriafecha_creacion_Internalname, context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"), context.localUtil.Format( A138actividades_categoriafecha_creacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,120);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriafecha_creacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtactividades_categoriafecha_creacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
         GxWebStd.gx_bitmap( context, edtactividades_categoriafecha_creacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtactividades_categoriafecha_creacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriahora_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriahora_creacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriahora_creacion_Internalname, "hora_creacion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A139actividades_categoriahora_creacion", StringUtil.LTrimStr( (decimal)(A139actividades_categoriahora_creacion), 5, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriahora_creacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A139actividades_categoriahora_creacion), 5, 0, ",", "")), ((edtactividades_categoriahora_creacion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A139actividades_categoriahora_creacion), "ZZZZ9")) : context.localUtil.Format( (decimal)(A139actividades_categoriahora_creacion), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,126);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriahora_creacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtactividades_categoriahora_creacion_Enabled, 0, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriacreado_por_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriacreado_por_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriacreado_por_Internalname, "creado_por", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A140actividades_categoriacreado_por", A140actividades_categoriacreado_por);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriacreado_por_Internalname, A140actividades_categoriacreado_por, StringUtil.RTrim( context.localUtil.Format( A140actividades_categoriacreado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,132);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriacreado_por_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtactividades_categoriacreado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriafecha_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriafecha_modificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriafecha_modificacion_Internalname, "fecha_modificacion", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A141actividades_categoriafecha_modificacion", context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtactividades_categoriafecha_modificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriafecha_modificacion_Internalname, context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"), context.localUtil.Format( A141actividades_categoriafecha_modificacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,138);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriafecha_modificacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtactividades_categoriafecha_modificacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
         GxWebStd.gx_bitmap( context, edtactividades_categoriafecha_modificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtactividades_categoriafecha_modificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriahora_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriahora_modificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriahora_modificacion_Internalname, "hora_modificacion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A142actividades_categoriahora_modificacion", StringUtil.LTrimStr( (decimal)(A142actividades_categoriahora_modificacion), 5, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriahora_modificacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A142actividades_categoriahora_modificacion), 5, 0, ",", "")), ((edtactividades_categoriahora_modificacion_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A142actividades_categoriahora_modificacion), "ZZZZ9")) : context.localUtil.Format( (decimal)(A142actividades_categoriahora_modificacion), "ZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,144);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriahora_modificacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtactividades_categoriahora_modificacion_Enabled, 0, "number", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_actividades_categoria.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineractividades_categoriamodificado_por_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtactividades_categoriamodificado_por_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtactividades_categoriamodificado_por_Internalname, "modificado_por", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A143actividades_categoriamodificado_por", A143actividades_categoriamodificado_por);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtactividades_categoriamodificado_por_Internalname, A143actividades_categoriamodificado_por, StringUtil.RTrim( context.localUtil.Format( A143actividades_categoriamodificado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,150);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtactividades_categoriamodificado_por_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtactividades_categoriamodificado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_actividades_categoria.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_actividades_categoria.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_actividades_categoria.htm");
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
         E110C2 ();
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
               Z102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z102id_actividad_categoria"), ",", "."));
               Z122actividades_categoriaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z122actividades_categoriaid_tipo_categoria"), ",", "."));
               n122actividades_categoriaid_tipo_categoria = ((0==A122actividades_categoriaid_tipo_categoria) ? true : false);
               Z123nombre_actividad = cgiGet( sPrefix+"Z123nombre_actividad");
               n123nombre_actividad = (String.IsNullOrEmpty(StringUtil.RTrim( A123nombre_actividad)) ? true : false);
               Z124unidad_medida = cgiGet( sPrefix+"Z124unidad_medida");
               n124unidad_medida = (String.IsNullOrEmpty(StringUtil.RTrim( A124unidad_medida)) ? true : false);
               Z125actividades_categoriaestado = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z125actividades_categoriaestado"), ",", "."));
               n125actividades_categoriaestado = ((0==A125actividades_categoriaestado) ? true : false);
               Z126programa_enero = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z126programa_enero"), ",", "."));
               n126programa_enero = ((0==A126programa_enero) ? true : false);
               Z127programa_febrero = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z127programa_febrero"), ",", "."));
               n127programa_febrero = ((0==A127programa_febrero) ? true : false);
               Z128programa_marzo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z128programa_marzo"), ",", "."));
               n128programa_marzo = ((0==A128programa_marzo) ? true : false);
               Z129programa_abril = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z129programa_abril"), ",", "."));
               n129programa_abril = ((0==A129programa_abril) ? true : false);
               Z130programa_mayo = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z130programa_mayo"), ",", "."));
               n130programa_mayo = ((0==A130programa_mayo) ? true : false);
               Z131programa_junio = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z131programa_junio"), ",", "."));
               n131programa_junio = ((0==A131programa_junio) ? true : false);
               Z132programa_julio = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z132programa_julio"), ",", "."));
               n132programa_julio = ((0==A132programa_julio) ? true : false);
               Z133programa_agosto = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z133programa_agosto"), ",", "."));
               n133programa_agosto = ((0==A133programa_agosto) ? true : false);
               Z134programa_sept = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z134programa_sept"), ",", "."));
               n134programa_sept = ((0==A134programa_sept) ? true : false);
               Z135programa_oct = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z135programa_oct"), ",", "."));
               n135programa_oct = ((0==A135programa_oct) ? true : false);
               Z136programa_nov = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z136programa_nov"), ",", "."));
               n136programa_nov = ((0==A136programa_nov) ? true : false);
               Z137programa_dic = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z137programa_dic"), ",", "."));
               n137programa_dic = ((0==A137programa_dic) ? true : false);
               Z138actividades_categoriafecha_creacion = context.localUtil.CToD( cgiGet( sPrefix+"Z138actividades_categoriafecha_creacion"), 0);
               n138actividades_categoriafecha_creacion = ((DateTime.MinValue==A138actividades_categoriafecha_creacion) ? true : false);
               Z139actividades_categoriahora_creacion = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z139actividades_categoriahora_creacion"), ",", "."));
               n139actividades_categoriahora_creacion = ((0==A139actividades_categoriahora_creacion) ? true : false);
               Z140actividades_categoriacreado_por = cgiGet( sPrefix+"Z140actividades_categoriacreado_por");
               n140actividades_categoriacreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A140actividades_categoriacreado_por)) ? true : false);
               Z141actividades_categoriafecha_modificacion = context.localUtil.CToD( cgiGet( sPrefix+"Z141actividades_categoriafecha_modificacion"), 0);
               n141actividades_categoriafecha_modificacion = ((DateTime.MinValue==A141actividades_categoriafecha_modificacion) ? true : false);
               Z142actividades_categoriahora_modificacion = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z142actividades_categoriahora_modificacion"), ",", "."));
               n142actividades_categoriahora_modificacion = ((0==A142actividades_categoriahora_modificacion) ? true : false);
               Z143actividades_categoriamodificado_por = cgiGet( sPrefix+"Z143actividades_categoriamodificado_por");
               n143actividades_categoriamodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A143actividades_categoriamodificado_por)) ? true : false);
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8id_actividad_categoria"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV8id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vID_ACTIVIDAD_CATEGORIA"), ",", "."));
               AV25Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriaid_tipo_categoria_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriaid_tipo_categoria_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA");
                  AnyError = 1;
                  GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A122actividades_categoriaid_tipo_categoria = 0;
                  n122actividades_categoriaid_tipo_categoria = false;
                  AssignAttri(sPrefix, false, "A122actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0));
               }
               else
               {
                  A122actividades_categoriaid_tipo_categoria = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriaid_tipo_categoria_Internalname), ",", "."));
                  n122actividades_categoriaid_tipo_categoria = false;
                  AssignAttri(sPrefix, false, "A122actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0));
               }
               n122actividades_categoriaid_tipo_categoria = ((0==A122actividades_categoriaid_tipo_categoria) ? true : false);
               A123nombre_actividad = cgiGet( edtnombre_actividad_Internalname);
               n123nombre_actividad = false;
               AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
               n123nombre_actividad = (String.IsNullOrEmpty(StringUtil.RTrim( A123nombre_actividad)) ? true : false);
               A124unidad_medida = cgiGet( edtunidad_medida_Internalname);
               n124unidad_medida = false;
               AssignAttri(sPrefix, false, "A124unidad_medida", A124unidad_medida);
               n124unidad_medida = (String.IsNullOrEmpty(StringUtil.RTrim( A124unidad_medida)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriaestado_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriaestado_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADES_CATEGORIAESTADO");
                  AnyError = 1;
                  GX_FocusControl = edtactividades_categoriaestado_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A125actividades_categoriaestado = 0;
                  n125actividades_categoriaestado = false;
                  AssignAttri(sPrefix, false, "A125actividades_categoriaestado", StringUtil.LTrimStr( (decimal)(A125actividades_categoriaestado), 9, 0));
               }
               else
               {
                  A125actividades_categoriaestado = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriaestado_Internalname), ",", "."));
                  n125actividades_categoriaestado = false;
                  AssignAttri(sPrefix, false, "A125actividades_categoriaestado", StringUtil.LTrimStr( (decimal)(A125actividades_categoriaestado), 9, 0));
               }
               n125actividades_categoriaestado = ((0==A125actividades_categoriaestado) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_enero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_enero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_ENERO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_enero_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A126programa_enero = 0;
                  n126programa_enero = false;
                  AssignAttri(sPrefix, false, "A126programa_enero", StringUtil.LTrimStr( (decimal)(A126programa_enero), 9, 0));
               }
               else
               {
                  A126programa_enero = (int)(context.localUtil.CToN( cgiGet( edtprograma_enero_Internalname), ",", "."));
                  n126programa_enero = false;
                  AssignAttri(sPrefix, false, "A126programa_enero", StringUtil.LTrimStr( (decimal)(A126programa_enero), 9, 0));
               }
               n126programa_enero = ((0==A126programa_enero) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_febrero_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_febrero_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_FEBRERO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_febrero_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A127programa_febrero = 0;
                  n127programa_febrero = false;
                  AssignAttri(sPrefix, false, "A127programa_febrero", StringUtil.LTrimStr( (decimal)(A127programa_febrero), 9, 0));
               }
               else
               {
                  A127programa_febrero = (int)(context.localUtil.CToN( cgiGet( edtprograma_febrero_Internalname), ",", "."));
                  n127programa_febrero = false;
                  AssignAttri(sPrefix, false, "A127programa_febrero", StringUtil.LTrimStr( (decimal)(A127programa_febrero), 9, 0));
               }
               n127programa_febrero = ((0==A127programa_febrero) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_marzo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_marzo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_MARZO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_marzo_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A128programa_marzo = 0;
                  n128programa_marzo = false;
                  AssignAttri(sPrefix, false, "A128programa_marzo", StringUtil.LTrimStr( (decimal)(A128programa_marzo), 9, 0));
               }
               else
               {
                  A128programa_marzo = (int)(context.localUtil.CToN( cgiGet( edtprograma_marzo_Internalname), ",", "."));
                  n128programa_marzo = false;
                  AssignAttri(sPrefix, false, "A128programa_marzo", StringUtil.LTrimStr( (decimal)(A128programa_marzo), 9, 0));
               }
               n128programa_marzo = ((0==A128programa_marzo) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_abril_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_abril_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_ABRIL");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_abril_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A129programa_abril = 0;
                  n129programa_abril = false;
                  AssignAttri(sPrefix, false, "A129programa_abril", StringUtil.LTrimStr( (decimal)(A129programa_abril), 9, 0));
               }
               else
               {
                  A129programa_abril = (int)(context.localUtil.CToN( cgiGet( edtprograma_abril_Internalname), ",", "."));
                  n129programa_abril = false;
                  AssignAttri(sPrefix, false, "A129programa_abril", StringUtil.LTrimStr( (decimal)(A129programa_abril), 9, 0));
               }
               n129programa_abril = ((0==A129programa_abril) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_mayo_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_mayo_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_MAYO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_mayo_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A130programa_mayo = 0;
                  n130programa_mayo = false;
                  AssignAttri(sPrefix, false, "A130programa_mayo", StringUtil.LTrimStr( (decimal)(A130programa_mayo), 9, 0));
               }
               else
               {
                  A130programa_mayo = (int)(context.localUtil.CToN( cgiGet( edtprograma_mayo_Internalname), ",", "."));
                  n130programa_mayo = false;
                  AssignAttri(sPrefix, false, "A130programa_mayo", StringUtil.LTrimStr( (decimal)(A130programa_mayo), 9, 0));
               }
               n130programa_mayo = ((0==A130programa_mayo) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_junio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_junio_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_JUNIO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_junio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A131programa_junio = 0;
                  n131programa_junio = false;
                  AssignAttri(sPrefix, false, "A131programa_junio", StringUtil.LTrimStr( (decimal)(A131programa_junio), 9, 0));
               }
               else
               {
                  A131programa_junio = (int)(context.localUtil.CToN( cgiGet( edtprograma_junio_Internalname), ",", "."));
                  n131programa_junio = false;
                  AssignAttri(sPrefix, false, "A131programa_junio", StringUtil.LTrimStr( (decimal)(A131programa_junio), 9, 0));
               }
               n131programa_junio = ((0==A131programa_junio) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_julio_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_julio_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_JULIO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_julio_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A132programa_julio = 0;
                  n132programa_julio = false;
                  AssignAttri(sPrefix, false, "A132programa_julio", StringUtil.LTrimStr( (decimal)(A132programa_julio), 9, 0));
               }
               else
               {
                  A132programa_julio = (int)(context.localUtil.CToN( cgiGet( edtprograma_julio_Internalname), ",", "."));
                  n132programa_julio = false;
                  AssignAttri(sPrefix, false, "A132programa_julio", StringUtil.LTrimStr( (decimal)(A132programa_julio), 9, 0));
               }
               n132programa_julio = ((0==A132programa_julio) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_agosto_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_agosto_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_AGOSTO");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_agosto_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A133programa_agosto = 0;
                  n133programa_agosto = false;
                  AssignAttri(sPrefix, false, "A133programa_agosto", StringUtil.LTrimStr( (decimal)(A133programa_agosto), 9, 0));
               }
               else
               {
                  A133programa_agosto = (int)(context.localUtil.CToN( cgiGet( edtprograma_agosto_Internalname), ",", "."));
                  n133programa_agosto = false;
                  AssignAttri(sPrefix, false, "A133programa_agosto", StringUtil.LTrimStr( (decimal)(A133programa_agosto), 9, 0));
               }
               n133programa_agosto = ((0==A133programa_agosto) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_sept_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_sept_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_SEPT");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_sept_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A134programa_sept = 0;
                  n134programa_sept = false;
                  AssignAttri(sPrefix, false, "A134programa_sept", StringUtil.LTrimStr( (decimal)(A134programa_sept), 9, 0));
               }
               else
               {
                  A134programa_sept = (int)(context.localUtil.CToN( cgiGet( edtprograma_sept_Internalname), ",", "."));
                  n134programa_sept = false;
                  AssignAttri(sPrefix, false, "A134programa_sept", StringUtil.LTrimStr( (decimal)(A134programa_sept), 9, 0));
               }
               n134programa_sept = ((0==A134programa_sept) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_oct_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_oct_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_OCT");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_oct_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A135programa_oct = 0;
                  n135programa_oct = false;
                  AssignAttri(sPrefix, false, "A135programa_oct", StringUtil.LTrimStr( (decimal)(A135programa_oct), 9, 0));
               }
               else
               {
                  A135programa_oct = (int)(context.localUtil.CToN( cgiGet( edtprograma_oct_Internalname), ",", "."));
                  n135programa_oct = false;
                  AssignAttri(sPrefix, false, "A135programa_oct", StringUtil.LTrimStr( (decimal)(A135programa_oct), 9, 0));
               }
               n135programa_oct = ((0==A135programa_oct) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_nov_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_nov_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_NOV");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_nov_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A136programa_nov = 0;
                  n136programa_nov = false;
                  AssignAttri(sPrefix, false, "A136programa_nov", StringUtil.LTrimStr( (decimal)(A136programa_nov), 9, 0));
               }
               else
               {
                  A136programa_nov = (int)(context.localUtil.CToN( cgiGet( edtprograma_nov_Internalname), ",", "."));
                  n136programa_nov = false;
                  AssignAttri(sPrefix, false, "A136programa_nov", StringUtil.LTrimStr( (decimal)(A136programa_nov), 9, 0));
               }
               n136programa_nov = ((0==A136programa_nov) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtprograma_dic_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtprograma_dic_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGRAMA_DIC");
                  AnyError = 1;
                  GX_FocusControl = edtprograma_dic_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A137programa_dic = 0;
                  n137programa_dic = false;
                  AssignAttri(sPrefix, false, "A137programa_dic", StringUtil.LTrimStr( (decimal)(A137programa_dic), 9, 0));
               }
               else
               {
                  A137programa_dic = (int)(context.localUtil.CToN( cgiGet( edtprograma_dic_Internalname), ",", "."));
                  n137programa_dic = false;
                  AssignAttri(sPrefix, false, "A137programa_dic", StringUtil.LTrimStr( (decimal)(A137programa_dic), 9, 0));
               }
               n137programa_dic = ((0==A137programa_dic) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtactividades_categoriafecha_creacion_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"actividades_categoriafecha_creacion"}), 1, "ACTIVIDADES_CATEGORIAFECHA_CREACION");
                  AnyError = 1;
                  GX_FocusControl = edtactividades_categoriafecha_creacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A138actividades_categoriafecha_creacion = DateTime.MinValue;
                  n138actividades_categoriafecha_creacion = false;
                  AssignAttri(sPrefix, false, "A138actividades_categoriafecha_creacion", context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"));
               }
               else
               {
                  A138actividades_categoriafecha_creacion = context.localUtil.CToD( cgiGet( edtactividades_categoriafecha_creacion_Internalname), 2);
                  n138actividades_categoriafecha_creacion = false;
                  AssignAttri(sPrefix, false, "A138actividades_categoriafecha_creacion", context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"));
               }
               n138actividades_categoriafecha_creacion = ((DateTime.MinValue==A138actividades_categoriafecha_creacion) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriahora_creacion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriahora_creacion_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADES_CATEGORIAHORA_CREACION");
                  AnyError = 1;
                  GX_FocusControl = edtactividades_categoriahora_creacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A139actividades_categoriahora_creacion = 0;
                  n139actividades_categoriahora_creacion = false;
                  AssignAttri(sPrefix, false, "A139actividades_categoriahora_creacion", StringUtil.LTrimStr( (decimal)(A139actividades_categoriahora_creacion), 5, 0));
               }
               else
               {
                  A139actividades_categoriahora_creacion = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriahora_creacion_Internalname), ",", "."));
                  n139actividades_categoriahora_creacion = false;
                  AssignAttri(sPrefix, false, "A139actividades_categoriahora_creacion", StringUtil.LTrimStr( (decimal)(A139actividades_categoriahora_creacion), 5, 0));
               }
               n139actividades_categoriahora_creacion = ((0==A139actividades_categoriahora_creacion) ? true : false);
               A140actividades_categoriacreado_por = cgiGet( edtactividades_categoriacreado_por_Internalname);
               n140actividades_categoriacreado_por = false;
               AssignAttri(sPrefix, false, "A140actividades_categoriacreado_por", A140actividades_categoriacreado_por);
               n140actividades_categoriacreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A140actividades_categoriacreado_por)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtactividades_categoriafecha_modificacion_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"actividades_categoriafecha_modificacion"}), 1, "ACTIVIDADES_CATEGORIAFECHA_MODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtactividades_categoriafecha_modificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A141actividades_categoriafecha_modificacion = DateTime.MinValue;
                  n141actividades_categoriafecha_modificacion = false;
                  AssignAttri(sPrefix, false, "A141actividades_categoriafecha_modificacion", context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"));
               }
               else
               {
                  A141actividades_categoriafecha_modificacion = context.localUtil.CToD( cgiGet( edtactividades_categoriafecha_modificacion_Internalname), 2);
                  n141actividades_categoriafecha_modificacion = false;
                  AssignAttri(sPrefix, false, "A141actividades_categoriafecha_modificacion", context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"));
               }
               n141actividades_categoriafecha_modificacion = ((DateTime.MinValue==A141actividades_categoriafecha_modificacion) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriahora_modificacion_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtactividades_categoriahora_modificacion_Internalname), ",", ".") > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTIVIDADES_CATEGORIAHORA_MODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtactividades_categoriahora_modificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A142actividades_categoriahora_modificacion = 0;
                  n142actividades_categoriahora_modificacion = false;
                  AssignAttri(sPrefix, false, "A142actividades_categoriahora_modificacion", StringUtil.LTrimStr( (decimal)(A142actividades_categoriahora_modificacion), 5, 0));
               }
               else
               {
                  A142actividades_categoriahora_modificacion = (int)(context.localUtil.CToN( cgiGet( edtactividades_categoriahora_modificacion_Internalname), ",", "."));
                  n142actividades_categoriahora_modificacion = false;
                  AssignAttri(sPrefix, false, "A142actividades_categoriahora_modificacion", StringUtil.LTrimStr( (decimal)(A142actividades_categoriahora_modificacion), 5, 0));
               }
               n142actividades_categoriahora_modificacion = ((0==A142actividades_categoriahora_modificacion) ? true : false);
               A143actividades_categoriamodificado_por = cgiGet( edtactividades_categoriamodificado_por_Internalname);
               n143actividades_categoriamodificado_por = false;
               AssignAttri(sPrefix, false, "A143actividades_categoriamodificado_por", A143actividades_categoriamodificado_por);
               n143actividades_categoriamodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A143actividades_categoriamodificado_por)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"actividades_categoria");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A102id_actividad_categoria != Z102id_actividad_categoria ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("actividades_categoria:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A102id_actividad_categoria = (int)(NumberUtil.Val( GetPar( "id_actividad_categoria"), "."));
                  AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
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
                     sMode13 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode13;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound13 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ID_ACTIVIDAD_CATEGORIA");
                        AnyError = 1;
                        GX_FocusControl = edtid_actividad_categoria_Internalname;
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
                                 E110C2 ();
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
                                 E120C2 ();
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
                                 E130C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C13( ) ;
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
            DisableAttributes0C13( ) ;
         }
         AssignProp(sPrefix, false, edtactividades_categoriaid_tipo_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaid_tipo_categoria_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombre_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidad_medida_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidad_medida_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriaestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaestado_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_enero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_enero_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_febrero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_febrero_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_marzo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_marzo_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_abril_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_abril_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_mayo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_mayo_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_junio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_junio_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_julio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_julio_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_agosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_agosto_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_sept_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_sept_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_oct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_oct_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_nov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_nov_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtprograma_dic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_dic_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriafecha_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriafecha_creacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriahora_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriahora_creacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriacreado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriacreado_por_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriafecha_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriafecha_modificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriahora_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriahora_modificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtactividades_categoriamodificado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriamodificado_por_Enabled), 5, 0), true);
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C13( ) ;
            }
            else
            {
               CheckExtendedTable0C13( ) ;
               CloseExtendedTableCursors0C13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "actividades_categoria",  "actividades_categoria",  AV17StandardActivityType,  AV18UserActivityType,  AV25Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("actividades_categoria")),UrlEncode(StringUtil.RTrim("actividades_categoria")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV25Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "actividades_categoria", out  AV9TrnContext) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "actividades_categoria", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "actividades_categoria", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "actividades_categoria", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtactividades_categoriaid_tipo_categoria_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtactividades_categoriaid_tipo_categoria_Internalname, "Class", edtactividades_categoriaid_tipo_categoria_Class, true);
            }
            else
            {
               edtactividades_categoriaid_tipo_categoria_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtactividades_categoriaid_tipo_categoria_Internalname, "Class", edtactividades_categoriaid_tipo_categoria_Class, true);
            }
         }
      }

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV9TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "id_actividad_categoria";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A102id_actividad_categoria), 9, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "actividades_categoria",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La actividades_categoria %1 fue creada", StringUtil.Str( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La actividades_categoria %1 fue actualizada", StringUtil.Str( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La actividades_categoria %1 fue eliminada", StringUtil.Str( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0), "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"actividades_categoria",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV9TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV9TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "actividades_categoria") ;
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
                     args = new Object[] {(string)"_site_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A102id_actividad_categoria,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A102id_actividad_categoria = (int)(args[2]) ;
                        AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A102id_actividad_categoria,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A102id_actividad_categoria = (int)(args[2]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A102id_actividad_categoria,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A102id_actividad_categoria = (int)(args[1]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV11Navigation.gxTpr_Mode,(int)A102id_actividad_categoria,AV11Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A102id_actividad_categoria = (int)(args[2]) ;
                        AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV11Navigation.gxTpr_Mode,(int)A102id_actividad_categoria,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A102id_actividad_categoria = (int)(args[2]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV11Navigation.gxTpr_Mode,(int)A102id_actividad_categoria,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A102id_actividad_categoria = (int)(args[1]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A102id_actividad_categoria,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130C2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "actividades_categoria") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"actividades_categoria"}, true);
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

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z122actividades_categoriaid_tipo_categoria = T000C3_A122actividades_categoriaid_tipo_categoria[0];
               Z123nombre_actividad = T000C3_A123nombre_actividad[0];
               Z124unidad_medida = T000C3_A124unidad_medida[0];
               Z125actividades_categoriaestado = T000C3_A125actividades_categoriaestado[0];
               Z126programa_enero = T000C3_A126programa_enero[0];
               Z127programa_febrero = T000C3_A127programa_febrero[0];
               Z128programa_marzo = T000C3_A128programa_marzo[0];
               Z129programa_abril = T000C3_A129programa_abril[0];
               Z130programa_mayo = T000C3_A130programa_mayo[0];
               Z131programa_junio = T000C3_A131programa_junio[0];
               Z132programa_julio = T000C3_A132programa_julio[0];
               Z133programa_agosto = T000C3_A133programa_agosto[0];
               Z134programa_sept = T000C3_A134programa_sept[0];
               Z135programa_oct = T000C3_A135programa_oct[0];
               Z136programa_nov = T000C3_A136programa_nov[0];
               Z137programa_dic = T000C3_A137programa_dic[0];
               Z138actividades_categoriafecha_creacion = T000C3_A138actividades_categoriafecha_creacion[0];
               Z139actividades_categoriahora_creacion = T000C3_A139actividades_categoriahora_creacion[0];
               Z140actividades_categoriacreado_por = T000C3_A140actividades_categoriacreado_por[0];
               Z141actividades_categoriafecha_modificacion = T000C3_A141actividades_categoriafecha_modificacion[0];
               Z142actividades_categoriahora_modificacion = T000C3_A142actividades_categoriahora_modificacion[0];
               Z143actividades_categoriamodificado_por = T000C3_A143actividades_categoriamodificado_por[0];
            }
            else
            {
               Z122actividades_categoriaid_tipo_categoria = A122actividades_categoriaid_tipo_categoria;
               Z123nombre_actividad = A123nombre_actividad;
               Z124unidad_medida = A124unidad_medida;
               Z125actividades_categoriaestado = A125actividades_categoriaestado;
               Z126programa_enero = A126programa_enero;
               Z127programa_febrero = A127programa_febrero;
               Z128programa_marzo = A128programa_marzo;
               Z129programa_abril = A129programa_abril;
               Z130programa_mayo = A130programa_mayo;
               Z131programa_junio = A131programa_junio;
               Z132programa_julio = A132programa_julio;
               Z133programa_agosto = A133programa_agosto;
               Z134programa_sept = A134programa_sept;
               Z135programa_oct = A135programa_oct;
               Z136programa_nov = A136programa_nov;
               Z137programa_dic = A137programa_dic;
               Z138actividades_categoriafecha_creacion = A138actividades_categoriafecha_creacion;
               Z139actividades_categoriahora_creacion = A139actividades_categoriahora_creacion;
               Z140actividades_categoriacreado_por = A140actividades_categoriacreado_por;
               Z141actividades_categoriafecha_modificacion = A141actividades_categoriafecha_modificacion;
               Z142actividades_categoriahora_modificacion = A142actividades_categoriahora_modificacion;
               Z143actividades_categoriamodificado_por = A143actividades_categoriamodificado_por;
            }
         }
         if ( GX_JID == -6 )
         {
            Z102id_actividad_categoria = A102id_actividad_categoria;
            Z122actividades_categoriaid_tipo_categoria = A122actividades_categoriaid_tipo_categoria;
            Z123nombre_actividad = A123nombre_actividad;
            Z124unidad_medida = A124unidad_medida;
            Z125actividades_categoriaestado = A125actividades_categoriaestado;
            Z126programa_enero = A126programa_enero;
            Z127programa_febrero = A127programa_febrero;
            Z128programa_marzo = A128programa_marzo;
            Z129programa_abril = A129programa_abril;
            Z130programa_mayo = A130programa_mayo;
            Z131programa_junio = A131programa_junio;
            Z132programa_julio = A132programa_julio;
            Z133programa_agosto = A133programa_agosto;
            Z134programa_sept = A134programa_sept;
            Z135programa_oct = A135programa_oct;
            Z136programa_nov = A136programa_nov;
            Z137programa_dic = A137programa_dic;
            Z138actividades_categoriafecha_creacion = A138actividades_categoriafecha_creacion;
            Z139actividades_categoriahora_creacion = A139actividades_categoriahora_creacion;
            Z140actividades_categoriacreado_por = A140actividades_categoriacreado_por;
            Z141actividades_categoriafecha_modificacion = A141actividades_categoriafecha_modificacion;
            Z142actividades_categoriahora_modificacion = A142actividades_categoriahora_modificacion;
            Z143actividades_categoriamodificado_por = A143actividades_categoriamodificado_por;
         }
      }

      protected void standaloneNotModal( )
      {
         edtid_actividad_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtid_actividad_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Enabled), 5, 0), true);
         edtid_actividad_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtid_actividad_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Enabled), 5, 0), true);
         if ( ! (0==AV8id_actividad_categoria) )
         {
            A102id_actividad_categoria = AV8id_actividad_categoria;
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
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

      protected void Load0C13( )
      {
         /* Using cursor T000C4 */
         pr_datastore1.execute(2, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound13 = 1;
            A122actividades_categoriaid_tipo_categoria = T000C4_A122actividades_categoriaid_tipo_categoria[0];
            n122actividades_categoriaid_tipo_categoria = T000C4_n122actividades_categoriaid_tipo_categoria[0];
            AssignAttri(sPrefix, false, "A122actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0));
            A123nombre_actividad = T000C4_A123nombre_actividad[0];
            n123nombre_actividad = T000C4_n123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
            A124unidad_medida = T000C4_A124unidad_medida[0];
            n124unidad_medida = T000C4_n124unidad_medida[0];
            AssignAttri(sPrefix, false, "A124unidad_medida", A124unidad_medida);
            A125actividades_categoriaestado = T000C4_A125actividades_categoriaestado[0];
            n125actividades_categoriaestado = T000C4_n125actividades_categoriaestado[0];
            AssignAttri(sPrefix, false, "A125actividades_categoriaestado", StringUtil.LTrimStr( (decimal)(A125actividades_categoriaestado), 9, 0));
            A126programa_enero = T000C4_A126programa_enero[0];
            n126programa_enero = T000C4_n126programa_enero[0];
            AssignAttri(sPrefix, false, "A126programa_enero", StringUtil.LTrimStr( (decimal)(A126programa_enero), 9, 0));
            A127programa_febrero = T000C4_A127programa_febrero[0];
            n127programa_febrero = T000C4_n127programa_febrero[0];
            AssignAttri(sPrefix, false, "A127programa_febrero", StringUtil.LTrimStr( (decimal)(A127programa_febrero), 9, 0));
            A128programa_marzo = T000C4_A128programa_marzo[0];
            n128programa_marzo = T000C4_n128programa_marzo[0];
            AssignAttri(sPrefix, false, "A128programa_marzo", StringUtil.LTrimStr( (decimal)(A128programa_marzo), 9, 0));
            A129programa_abril = T000C4_A129programa_abril[0];
            n129programa_abril = T000C4_n129programa_abril[0];
            AssignAttri(sPrefix, false, "A129programa_abril", StringUtil.LTrimStr( (decimal)(A129programa_abril), 9, 0));
            A130programa_mayo = T000C4_A130programa_mayo[0];
            n130programa_mayo = T000C4_n130programa_mayo[0];
            AssignAttri(sPrefix, false, "A130programa_mayo", StringUtil.LTrimStr( (decimal)(A130programa_mayo), 9, 0));
            A131programa_junio = T000C4_A131programa_junio[0];
            n131programa_junio = T000C4_n131programa_junio[0];
            AssignAttri(sPrefix, false, "A131programa_junio", StringUtil.LTrimStr( (decimal)(A131programa_junio), 9, 0));
            A132programa_julio = T000C4_A132programa_julio[0];
            n132programa_julio = T000C4_n132programa_julio[0];
            AssignAttri(sPrefix, false, "A132programa_julio", StringUtil.LTrimStr( (decimal)(A132programa_julio), 9, 0));
            A133programa_agosto = T000C4_A133programa_agosto[0];
            n133programa_agosto = T000C4_n133programa_agosto[0];
            AssignAttri(sPrefix, false, "A133programa_agosto", StringUtil.LTrimStr( (decimal)(A133programa_agosto), 9, 0));
            A134programa_sept = T000C4_A134programa_sept[0];
            n134programa_sept = T000C4_n134programa_sept[0];
            AssignAttri(sPrefix, false, "A134programa_sept", StringUtil.LTrimStr( (decimal)(A134programa_sept), 9, 0));
            A135programa_oct = T000C4_A135programa_oct[0];
            n135programa_oct = T000C4_n135programa_oct[0];
            AssignAttri(sPrefix, false, "A135programa_oct", StringUtil.LTrimStr( (decimal)(A135programa_oct), 9, 0));
            A136programa_nov = T000C4_A136programa_nov[0];
            n136programa_nov = T000C4_n136programa_nov[0];
            AssignAttri(sPrefix, false, "A136programa_nov", StringUtil.LTrimStr( (decimal)(A136programa_nov), 9, 0));
            A137programa_dic = T000C4_A137programa_dic[0];
            n137programa_dic = T000C4_n137programa_dic[0];
            AssignAttri(sPrefix, false, "A137programa_dic", StringUtil.LTrimStr( (decimal)(A137programa_dic), 9, 0));
            A138actividades_categoriafecha_creacion = T000C4_A138actividades_categoriafecha_creacion[0];
            n138actividades_categoriafecha_creacion = T000C4_n138actividades_categoriafecha_creacion[0];
            AssignAttri(sPrefix, false, "A138actividades_categoriafecha_creacion", context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"));
            A139actividades_categoriahora_creacion = T000C4_A139actividades_categoriahora_creacion[0];
            n139actividades_categoriahora_creacion = T000C4_n139actividades_categoriahora_creacion[0];
            AssignAttri(sPrefix, false, "A139actividades_categoriahora_creacion", StringUtil.LTrimStr( (decimal)(A139actividades_categoriahora_creacion), 5, 0));
            A140actividades_categoriacreado_por = T000C4_A140actividades_categoriacreado_por[0];
            n140actividades_categoriacreado_por = T000C4_n140actividades_categoriacreado_por[0];
            AssignAttri(sPrefix, false, "A140actividades_categoriacreado_por", A140actividades_categoriacreado_por);
            A141actividades_categoriafecha_modificacion = T000C4_A141actividades_categoriafecha_modificacion[0];
            n141actividades_categoriafecha_modificacion = T000C4_n141actividades_categoriafecha_modificacion[0];
            AssignAttri(sPrefix, false, "A141actividades_categoriafecha_modificacion", context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"));
            A142actividades_categoriahora_modificacion = T000C4_A142actividades_categoriahora_modificacion[0];
            n142actividades_categoriahora_modificacion = T000C4_n142actividades_categoriahora_modificacion[0];
            AssignAttri(sPrefix, false, "A142actividades_categoriahora_modificacion", StringUtil.LTrimStr( (decimal)(A142actividades_categoriahora_modificacion), 5, 0));
            A143actividades_categoriamodificado_por = T000C4_A143actividades_categoriamodificado_por[0];
            n143actividades_categoriamodificado_por = T000C4_n143actividades_categoriamodificado_por[0];
            AssignAttri(sPrefix, false, "A143actividades_categoriamodificado_por", A143actividades_categoriamodificado_por);
            ZM0C13( -6) ;
         }
         pr_datastore1.close(2);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
         AV25Pgmname = "actividades_categoria";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "actividades_categoria";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         if ( (0==A122actividades_categoriaid_tipo_categoria) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "id_tipo_categoria", "", "", "", "", "", "", "", ""), 1, "ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A138actividades_categoriafecha_creacion) || ( A138actividades_categoriafecha_creacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo actividades_categoriafecha_creacion fuera de rango", "OutOfRange", 1, "ACTIVIDADES_CATEGORIAFECHA_CREACION");
            AnyError = 1;
            GX_FocusControl = edtactividades_categoriafecha_creacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A141actividades_categoriafecha_modificacion) || ( A141actividades_categoriafecha_modificacion >= context.localUtil.YMDToD( 1753, 1, 1) ) ) )
         {
            GX_msglist.addItem("Campo actividades_categoriafecha_modificacion fuera de rango", "OutOfRange", 1, "ACTIVIDADES_CATEGORIAFECHA_MODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtactividades_categoriafecha_modificacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0C13( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C13( )
      {
         /* Using cursor T000C5 */
         pr_datastore1.execute(3, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_datastore1.execute(1, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM0C13( 6) ;
            RcdFound13 = 1;
            A102id_actividad_categoria = T000C3_A102id_actividad_categoria[0];
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
            A122actividades_categoriaid_tipo_categoria = T000C3_A122actividades_categoriaid_tipo_categoria[0];
            n122actividades_categoriaid_tipo_categoria = T000C3_n122actividades_categoriaid_tipo_categoria[0];
            AssignAttri(sPrefix, false, "A122actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0));
            A123nombre_actividad = T000C3_A123nombre_actividad[0];
            n123nombre_actividad = T000C3_n123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
            A124unidad_medida = T000C3_A124unidad_medida[0];
            n124unidad_medida = T000C3_n124unidad_medida[0];
            AssignAttri(sPrefix, false, "A124unidad_medida", A124unidad_medida);
            A125actividades_categoriaestado = T000C3_A125actividades_categoriaestado[0];
            n125actividades_categoriaestado = T000C3_n125actividades_categoriaestado[0];
            AssignAttri(sPrefix, false, "A125actividades_categoriaestado", StringUtil.LTrimStr( (decimal)(A125actividades_categoriaestado), 9, 0));
            A126programa_enero = T000C3_A126programa_enero[0];
            n126programa_enero = T000C3_n126programa_enero[0];
            AssignAttri(sPrefix, false, "A126programa_enero", StringUtil.LTrimStr( (decimal)(A126programa_enero), 9, 0));
            A127programa_febrero = T000C3_A127programa_febrero[0];
            n127programa_febrero = T000C3_n127programa_febrero[0];
            AssignAttri(sPrefix, false, "A127programa_febrero", StringUtil.LTrimStr( (decimal)(A127programa_febrero), 9, 0));
            A128programa_marzo = T000C3_A128programa_marzo[0];
            n128programa_marzo = T000C3_n128programa_marzo[0];
            AssignAttri(sPrefix, false, "A128programa_marzo", StringUtil.LTrimStr( (decimal)(A128programa_marzo), 9, 0));
            A129programa_abril = T000C3_A129programa_abril[0];
            n129programa_abril = T000C3_n129programa_abril[0];
            AssignAttri(sPrefix, false, "A129programa_abril", StringUtil.LTrimStr( (decimal)(A129programa_abril), 9, 0));
            A130programa_mayo = T000C3_A130programa_mayo[0];
            n130programa_mayo = T000C3_n130programa_mayo[0];
            AssignAttri(sPrefix, false, "A130programa_mayo", StringUtil.LTrimStr( (decimal)(A130programa_mayo), 9, 0));
            A131programa_junio = T000C3_A131programa_junio[0];
            n131programa_junio = T000C3_n131programa_junio[0];
            AssignAttri(sPrefix, false, "A131programa_junio", StringUtil.LTrimStr( (decimal)(A131programa_junio), 9, 0));
            A132programa_julio = T000C3_A132programa_julio[0];
            n132programa_julio = T000C3_n132programa_julio[0];
            AssignAttri(sPrefix, false, "A132programa_julio", StringUtil.LTrimStr( (decimal)(A132programa_julio), 9, 0));
            A133programa_agosto = T000C3_A133programa_agosto[0];
            n133programa_agosto = T000C3_n133programa_agosto[0];
            AssignAttri(sPrefix, false, "A133programa_agosto", StringUtil.LTrimStr( (decimal)(A133programa_agosto), 9, 0));
            A134programa_sept = T000C3_A134programa_sept[0];
            n134programa_sept = T000C3_n134programa_sept[0];
            AssignAttri(sPrefix, false, "A134programa_sept", StringUtil.LTrimStr( (decimal)(A134programa_sept), 9, 0));
            A135programa_oct = T000C3_A135programa_oct[0];
            n135programa_oct = T000C3_n135programa_oct[0];
            AssignAttri(sPrefix, false, "A135programa_oct", StringUtil.LTrimStr( (decimal)(A135programa_oct), 9, 0));
            A136programa_nov = T000C3_A136programa_nov[0];
            n136programa_nov = T000C3_n136programa_nov[0];
            AssignAttri(sPrefix, false, "A136programa_nov", StringUtil.LTrimStr( (decimal)(A136programa_nov), 9, 0));
            A137programa_dic = T000C3_A137programa_dic[0];
            n137programa_dic = T000C3_n137programa_dic[0];
            AssignAttri(sPrefix, false, "A137programa_dic", StringUtil.LTrimStr( (decimal)(A137programa_dic), 9, 0));
            A138actividades_categoriafecha_creacion = T000C3_A138actividades_categoriafecha_creacion[0];
            n138actividades_categoriafecha_creacion = T000C3_n138actividades_categoriafecha_creacion[0];
            AssignAttri(sPrefix, false, "A138actividades_categoriafecha_creacion", context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"));
            A139actividades_categoriahora_creacion = T000C3_A139actividades_categoriahora_creacion[0];
            n139actividades_categoriahora_creacion = T000C3_n139actividades_categoriahora_creacion[0];
            AssignAttri(sPrefix, false, "A139actividades_categoriahora_creacion", StringUtil.LTrimStr( (decimal)(A139actividades_categoriahora_creacion), 5, 0));
            A140actividades_categoriacreado_por = T000C3_A140actividades_categoriacreado_por[0];
            n140actividades_categoriacreado_por = T000C3_n140actividades_categoriacreado_por[0];
            AssignAttri(sPrefix, false, "A140actividades_categoriacreado_por", A140actividades_categoriacreado_por);
            A141actividades_categoriafecha_modificacion = T000C3_A141actividades_categoriafecha_modificacion[0];
            n141actividades_categoriafecha_modificacion = T000C3_n141actividades_categoriafecha_modificacion[0];
            AssignAttri(sPrefix, false, "A141actividades_categoriafecha_modificacion", context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"));
            A142actividades_categoriahora_modificacion = T000C3_A142actividades_categoriahora_modificacion[0];
            n142actividades_categoriahora_modificacion = T000C3_n142actividades_categoriahora_modificacion[0];
            AssignAttri(sPrefix, false, "A142actividades_categoriahora_modificacion", StringUtil.LTrimStr( (decimal)(A142actividades_categoriahora_modificacion), 5, 0));
            A143actividades_categoriamodificado_por = T000C3_A143actividades_categoriamodificado_por[0];
            n143actividades_categoriamodificado_por = T000C3_n143actividades_categoriamodificado_por[0];
            AssignAttri(sPrefix, false, "A143actividades_categoriamodificado_por", A143actividades_categoriamodificado_por);
            Z102id_actividad_categoria = A102id_actividad_categoria;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C6 */
         pr_datastore1.execute(4, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T000C6_A102id_actividad_categoria[0] < A102id_actividad_categoria ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T000C6_A102id_actividad_categoria[0] > A102id_actividad_categoria ) ) )
            {
               A102id_actividad_categoria = T000C6_A102id_actividad_categoria[0];
               AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
               RcdFound13 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C7 */
         pr_datastore1.execute(5, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T000C7_A102id_actividad_categoria[0] > A102id_actividad_categoria ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T000C7_A102id_actividad_categoria[0] < A102id_actividad_categoria ) ) )
            {
               A102id_actividad_categoria = T000C7_A102id_actividad_categoria[0];
               AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
               RcdFound13 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0C13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A102id_actividad_categoria != Z102id_actividad_categoria )
               {
                  A102id_actividad_categoria = Z102id_actividad_categoria;
                  AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ID_ACTIVIDAD_CATEGORIA");
                  AnyError = 1;
                  GX_FocusControl = edtid_actividad_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C13( ) ;
                  GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A102id_actividad_categoria != Z102id_actividad_categoria )
               {
                  /* Insert record */
                  GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0C13( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ID_ACTIVIDAD_CATEGORIA");
                     AnyError = 1;
                     GX_FocusControl = edtid_actividad_categoria_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0C13( ) ;
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
         if ( A102id_actividad_categoria != Z102id_actividad_categoria )
         {
            A102id_actividad_categoria = Z102id_actividad_categoria;
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ID_ACTIVIDAD_CATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtid_actividad_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtactividades_categoriaid_tipo_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_datastore1.execute(0, new Object[] {A102id_actividad_categoria});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTIVIDADES_CATEGORIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( Z122actividades_categoriaid_tipo_categoria != T000C2_A122actividades_categoriaid_tipo_categoria[0] ) || ( StringUtil.StrCmp(Z123nombre_actividad, T000C2_A123nombre_actividad[0]) != 0 ) || ( StringUtil.StrCmp(Z124unidad_medida, T000C2_A124unidad_medida[0]) != 0 ) || ( Z125actividades_categoriaestado != T000C2_A125actividades_categoriaestado[0] ) || ( Z126programa_enero != T000C2_A126programa_enero[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z127programa_febrero != T000C2_A127programa_febrero[0] ) || ( Z128programa_marzo != T000C2_A128programa_marzo[0] ) || ( Z129programa_abril != T000C2_A129programa_abril[0] ) || ( Z130programa_mayo != T000C2_A130programa_mayo[0] ) || ( Z131programa_junio != T000C2_A131programa_junio[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z132programa_julio != T000C2_A132programa_julio[0] ) || ( Z133programa_agosto != T000C2_A133programa_agosto[0] ) || ( Z134programa_sept != T000C2_A134programa_sept[0] ) || ( Z135programa_oct != T000C2_A135programa_oct[0] ) || ( Z136programa_nov != T000C2_A136programa_nov[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z137programa_dic != T000C2_A137programa_dic[0] ) || ( Z138actividades_categoriafecha_creacion != T000C2_A138actividades_categoriafecha_creacion[0] ) || ( Z139actividades_categoriahora_creacion != T000C2_A139actividades_categoriahora_creacion[0] ) || ( StringUtil.StrCmp(Z140actividades_categoriacreado_por, T000C2_A140actividades_categoriacreado_por[0]) != 0 ) || ( Z141actividades_categoriafecha_modificacion != T000C2_A141actividades_categoriafecha_modificacion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z142actividades_categoriahora_modificacion != T000C2_A142actividades_categoriahora_modificacion[0] ) || ( StringUtil.StrCmp(Z143actividades_categoriamodificado_por, T000C2_A143actividades_categoriamodificado_por[0]) != 0 ) )
            {
               if ( Z122actividades_categoriaid_tipo_categoria != T000C2_A122actividades_categoriaid_tipo_categoria[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriaid_tipo_categoria");
                  GXUtil.WriteLogRaw("Old: ",Z122actividades_categoriaid_tipo_categoria);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A122actividades_categoriaid_tipo_categoria[0]);
               }
               if ( StringUtil.StrCmp(Z123nombre_actividad, T000C2_A123nombre_actividad[0]) != 0 )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"nombre_actividad");
                  GXUtil.WriteLogRaw("Old: ",Z123nombre_actividad);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A123nombre_actividad[0]);
               }
               if ( StringUtil.StrCmp(Z124unidad_medida, T000C2_A124unidad_medida[0]) != 0 )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"unidad_medida");
                  GXUtil.WriteLogRaw("Old: ",Z124unidad_medida);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A124unidad_medida[0]);
               }
               if ( Z125actividades_categoriaestado != T000C2_A125actividades_categoriaestado[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriaestado");
                  GXUtil.WriteLogRaw("Old: ",Z125actividades_categoriaestado);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A125actividades_categoriaestado[0]);
               }
               if ( Z126programa_enero != T000C2_A126programa_enero[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_enero");
                  GXUtil.WriteLogRaw("Old: ",Z126programa_enero);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A126programa_enero[0]);
               }
               if ( Z127programa_febrero != T000C2_A127programa_febrero[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_febrero");
                  GXUtil.WriteLogRaw("Old: ",Z127programa_febrero);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A127programa_febrero[0]);
               }
               if ( Z128programa_marzo != T000C2_A128programa_marzo[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_marzo");
                  GXUtil.WriteLogRaw("Old: ",Z128programa_marzo);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A128programa_marzo[0]);
               }
               if ( Z129programa_abril != T000C2_A129programa_abril[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_abril");
                  GXUtil.WriteLogRaw("Old: ",Z129programa_abril);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A129programa_abril[0]);
               }
               if ( Z130programa_mayo != T000C2_A130programa_mayo[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_mayo");
                  GXUtil.WriteLogRaw("Old: ",Z130programa_mayo);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A130programa_mayo[0]);
               }
               if ( Z131programa_junio != T000C2_A131programa_junio[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_junio");
                  GXUtil.WriteLogRaw("Old: ",Z131programa_junio);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A131programa_junio[0]);
               }
               if ( Z132programa_julio != T000C2_A132programa_julio[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_julio");
                  GXUtil.WriteLogRaw("Old: ",Z132programa_julio);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A132programa_julio[0]);
               }
               if ( Z133programa_agosto != T000C2_A133programa_agosto[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_agosto");
                  GXUtil.WriteLogRaw("Old: ",Z133programa_agosto);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A133programa_agosto[0]);
               }
               if ( Z134programa_sept != T000C2_A134programa_sept[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_sept");
                  GXUtil.WriteLogRaw("Old: ",Z134programa_sept);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A134programa_sept[0]);
               }
               if ( Z135programa_oct != T000C2_A135programa_oct[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_oct");
                  GXUtil.WriteLogRaw("Old: ",Z135programa_oct);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A135programa_oct[0]);
               }
               if ( Z136programa_nov != T000C2_A136programa_nov[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_nov");
                  GXUtil.WriteLogRaw("Old: ",Z136programa_nov);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A136programa_nov[0]);
               }
               if ( Z137programa_dic != T000C2_A137programa_dic[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"programa_dic");
                  GXUtil.WriteLogRaw("Old: ",Z137programa_dic);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A137programa_dic[0]);
               }
               if ( Z138actividades_categoriafecha_creacion != T000C2_A138actividades_categoriafecha_creacion[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriafecha_creacion");
                  GXUtil.WriteLogRaw("Old: ",Z138actividades_categoriafecha_creacion);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A138actividades_categoriafecha_creacion[0]);
               }
               if ( Z139actividades_categoriahora_creacion != T000C2_A139actividades_categoriahora_creacion[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriahora_creacion");
                  GXUtil.WriteLogRaw("Old: ",Z139actividades_categoriahora_creacion);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A139actividades_categoriahora_creacion[0]);
               }
               if ( StringUtil.StrCmp(Z140actividades_categoriacreado_por, T000C2_A140actividades_categoriacreado_por[0]) != 0 )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriacreado_por");
                  GXUtil.WriteLogRaw("Old: ",Z140actividades_categoriacreado_por);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A140actividades_categoriacreado_por[0]);
               }
               if ( Z141actividades_categoriafecha_modificacion != T000C2_A141actividades_categoriafecha_modificacion[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriafecha_modificacion");
                  GXUtil.WriteLogRaw("Old: ",Z141actividades_categoriafecha_modificacion);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A141actividades_categoriafecha_modificacion[0]);
               }
               if ( Z142actividades_categoriahora_modificacion != T000C2_A142actividades_categoriahora_modificacion[0] )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriahora_modificacion");
                  GXUtil.WriteLogRaw("Old: ",Z142actividades_categoriahora_modificacion);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A142actividades_categoriahora_modificacion[0]);
               }
               if ( StringUtil.StrCmp(Z143actividades_categoriamodificado_por, T000C2_A143actividades_categoriamodificado_por[0]) != 0 )
               {
                  GXUtil.WriteLog("actividades_categoria:[seudo value changed for attri]"+"actividades_categoriamodificado_por");
                  GXUtil.WriteLogRaw("Old: ",Z143actividades_categoriamodificado_por);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A143actividades_categoriamodificado_por[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTIVIDADES_CATEGORIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         if ( ! IsAuthorized("actividades_categoria_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C8 */
                     pr_datastore1.execute(6, new Object[] {n122actividades_categoriaid_tipo_categoria, A122actividades_categoriaid_tipo_categoria, n123nombre_actividad, A123nombre_actividad, n124unidad_medida, A124unidad_medida, n125actividades_categoriaestado, A125actividades_categoriaestado, n126programa_enero, A126programa_enero, n127programa_febrero, A127programa_febrero, n128programa_marzo, A128programa_marzo, n129programa_abril, A129programa_abril, n130programa_mayo, A130programa_mayo, n131programa_junio, A131programa_junio, n132programa_julio, A132programa_julio, n133programa_agosto, A133programa_agosto, n134programa_sept, A134programa_sept, n135programa_oct, A135programa_oct, n136programa_nov, A136programa_nov, n137programa_dic, A137programa_dic, n138actividades_categoriafecha_creacion, A138actividades_categoriafecha_creacion, n139actividades_categoriahora_creacion, A139actividades_categoriahora_creacion, n140actividades_categoriacreado_por, A140actividades_categoriacreado_por, n141actividades_categoriafecha_modificacion, A141actividades_categoriafecha_modificacion, n142actividades_categoriahora_modificacion, A142actividades_categoriahora_modificacion, n143actividades_categoriamodificado_por, A143actividades_categoriamodificado_por});
                     A102id_actividad_categoria = T000C8_A102id_actividad_categoria[0];
                     AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
                     pr_datastore1.close(6);
                     dsDataStore1.SmartCacheProvider.SetUpdated("ACTIVIDADES_CATEGORIA");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0C0( ) ;
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         if ( ! IsAuthorized("actividades_categoria_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C9 */
                     pr_datastore1.execute(7, new Object[] {n122actividades_categoriaid_tipo_categoria, A122actividades_categoriaid_tipo_categoria, n123nombre_actividad, A123nombre_actividad, n124unidad_medida, A124unidad_medida, n125actividades_categoriaestado, A125actividades_categoriaestado, n126programa_enero, A126programa_enero, n127programa_febrero, A127programa_febrero, n128programa_marzo, A128programa_marzo, n129programa_abril, A129programa_abril, n130programa_mayo, A130programa_mayo, n131programa_junio, A131programa_junio, n132programa_julio, A132programa_julio, n133programa_agosto, A133programa_agosto, n134programa_sept, A134programa_sept, n135programa_oct, A135programa_oct, n136programa_nov, A136programa_nov, n137programa_dic, A137programa_dic, n138actividades_categoriafecha_creacion, A138actividades_categoriafecha_creacion, n139actividades_categoriahora_creacion, A139actividades_categoriahora_creacion, n140actividades_categoriacreado_por, A140actividades_categoriacreado_por, n141actividades_categoriafecha_modificacion, A141actividades_categoriafecha_modificacion, n142actividades_categoriahora_modificacion, A142actividades_categoriahora_modificacion, n143actividades_categoriamodificado_por, A143actividades_categoriamodificado_por, A102id_actividad_categoria});
                     pr_datastore1.close(7);
                     dsDataStore1.SmartCacheProvider.SetUpdated("ACTIVIDADES_CATEGORIA");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTIVIDADES_CATEGORIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
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
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("actividades_categoria_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C10 */
                  pr_datastore1.execute(8, new Object[] {A102id_actividad_categoria});
                  pr_datastore1.close(8);
                  dsDataStore1.SmartCacheProvider.SetUpdated("ACTIVIDADES_CATEGORIA");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "actividades_categoria";
            AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C11 */
            pr_default.execute(0, new Object[] {A102id_actividad_categoria});
            if ( (pr_default.getStatus(0) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ticket Tecnico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(0);
            /* Using cursor T000C12 */
            pr_default.execute(1, new Object[] {A102id_actividad_categoria});
            if ( (pr_default.getStatus(1) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Estado"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(1);
         }
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore1.close(1);
            context.CommitDataStores("actividades_categoria",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore1.close(1);
            context.RollbackDataStores("actividades_categoria",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C13( )
      {
         /* Scan By routine */
         /* Using cursor T000C13 */
         pr_datastore1.execute(9);
         RcdFound13 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A102id_actividad_categoria = T000C13_A102id_actividad_categoria[0];
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C13( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound13 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound13 = 1;
            A102id_actividad_categoria = T000C13_A102id_actividad_categoria[0];
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         }
      }

      protected void ScanEnd0C13( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
         edtid_actividad_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtid_actividad_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Enabled), 5, 0), true);
         edtactividades_categoriaid_tipo_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriaid_tipo_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaid_tipo_categoria_Enabled), 5, 0), true);
         edtnombre_actividad_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Enabled), 5, 0), true);
         edtunidad_medida_Enabled = 0;
         AssignProp(sPrefix, false, edtunidad_medida_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidad_medida_Enabled), 5, 0), true);
         edtactividades_categoriaestado_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriaestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriaestado_Enabled), 5, 0), true);
         edtprograma_enero_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_enero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_enero_Enabled), 5, 0), true);
         edtprograma_febrero_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_febrero_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_febrero_Enabled), 5, 0), true);
         edtprograma_marzo_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_marzo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_marzo_Enabled), 5, 0), true);
         edtprograma_abril_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_abril_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_abril_Enabled), 5, 0), true);
         edtprograma_mayo_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_mayo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_mayo_Enabled), 5, 0), true);
         edtprograma_junio_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_junio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_junio_Enabled), 5, 0), true);
         edtprograma_julio_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_julio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_julio_Enabled), 5, 0), true);
         edtprograma_agosto_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_agosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_agosto_Enabled), 5, 0), true);
         edtprograma_sept_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_sept_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_sept_Enabled), 5, 0), true);
         edtprograma_oct_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_oct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_oct_Enabled), 5, 0), true);
         edtprograma_nov_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_nov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_nov_Enabled), 5, 0), true);
         edtprograma_dic_Enabled = 0;
         AssignProp(sPrefix, false, edtprograma_dic_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtprograma_dic_Enabled), 5, 0), true);
         edtactividades_categoriafecha_creacion_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriafecha_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriafecha_creacion_Enabled), 5, 0), true);
         edtactividades_categoriahora_creacion_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriahora_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriahora_creacion_Enabled), 5, 0), true);
         edtactividades_categoriacreado_por_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriacreado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriacreado_por_Enabled), 5, 0), true);
         edtactividades_categoriafecha_modificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriafecha_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriafecha_modificacion_Enabled), 5, 0), true);
         edtactividades_categoriahora_modificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriahora_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriahora_modificacion_Enabled), 5, 0), true);
         edtactividades_categoriamodificado_por_Enabled = 0;
         AssignProp(sPrefix, false, edtactividades_categoriamodificado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtactividades_categoriamodificado_por_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2023124949287", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actividades_categoria.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8id_actividad_categoria,9,0))}, new string[] {"Gx_mode","id_actividad_categoria"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"actividades_categoria");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("actividades_categoria:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z102id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102id_actividad_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z122actividades_categoriaid_tipo_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122actividades_categoriaid_tipo_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z123nombre_actividad", Z123nombre_actividad);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z124unidad_medida", Z124unidad_medida);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z125actividades_categoriaestado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z125actividades_categoriaestado), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z126programa_enero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z126programa_enero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z127programa_febrero", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z127programa_febrero), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z128programa_marzo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z128programa_marzo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z129programa_abril", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z129programa_abril), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z130programa_mayo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z130programa_mayo), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z131programa_junio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z131programa_junio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z132programa_julio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z132programa_julio), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z133programa_agosto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z133programa_agosto), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z134programa_sept", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z134programa_sept), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z135programa_oct", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z135programa_oct), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z136programa_nov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z136programa_nov), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z137programa_dic", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137programa_dic), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z138actividades_categoriafecha_creacion", context.localUtil.DToC( Z138actividades_categoriafecha_creacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z139actividades_categoriahora_creacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z139actividades_categoriahora_creacion), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z140actividades_categoriacreado_por", Z140actividades_categoriacreado_por);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z141actividades_categoriafecha_modificacion", context.localUtil.DToC( Z141actividades_categoriafecha_modificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z142actividades_categoriahora_modificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z142actividades_categoriahora_modificacion), 5, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z143actividades_categoriamodificado_por", Z143actividades_categoriamodificado_por);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8id_actividad_categoria), 9, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vID_ACTIVIDAD_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8id_actividad_categoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0C13( )
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
         return "actividades_categoria" ;
      }

      public override string GetPgmdesc( )
      {
         return "actividades_categoria" ;
      }

      protected void InitializeNonKey0C13( )
      {
         A122actividades_categoriaid_tipo_categoria = 0;
         n122actividades_categoriaid_tipo_categoria = false;
         AssignAttri(sPrefix, false, "A122actividades_categoriaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A122actividades_categoriaid_tipo_categoria), 9, 0));
         n122actividades_categoriaid_tipo_categoria = ((0==A122actividades_categoriaid_tipo_categoria) ? true : false);
         A123nombre_actividad = "";
         n123nombre_actividad = false;
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         n123nombre_actividad = (String.IsNullOrEmpty(StringUtil.RTrim( A123nombre_actividad)) ? true : false);
         A124unidad_medida = "";
         n124unidad_medida = false;
         AssignAttri(sPrefix, false, "A124unidad_medida", A124unidad_medida);
         n124unidad_medida = (String.IsNullOrEmpty(StringUtil.RTrim( A124unidad_medida)) ? true : false);
         A125actividades_categoriaestado = 0;
         n125actividades_categoriaestado = false;
         AssignAttri(sPrefix, false, "A125actividades_categoriaestado", StringUtil.LTrimStr( (decimal)(A125actividades_categoriaestado), 9, 0));
         n125actividades_categoriaestado = ((0==A125actividades_categoriaestado) ? true : false);
         A126programa_enero = 0;
         n126programa_enero = false;
         AssignAttri(sPrefix, false, "A126programa_enero", StringUtil.LTrimStr( (decimal)(A126programa_enero), 9, 0));
         n126programa_enero = ((0==A126programa_enero) ? true : false);
         A127programa_febrero = 0;
         n127programa_febrero = false;
         AssignAttri(sPrefix, false, "A127programa_febrero", StringUtil.LTrimStr( (decimal)(A127programa_febrero), 9, 0));
         n127programa_febrero = ((0==A127programa_febrero) ? true : false);
         A128programa_marzo = 0;
         n128programa_marzo = false;
         AssignAttri(sPrefix, false, "A128programa_marzo", StringUtil.LTrimStr( (decimal)(A128programa_marzo), 9, 0));
         n128programa_marzo = ((0==A128programa_marzo) ? true : false);
         A129programa_abril = 0;
         n129programa_abril = false;
         AssignAttri(sPrefix, false, "A129programa_abril", StringUtil.LTrimStr( (decimal)(A129programa_abril), 9, 0));
         n129programa_abril = ((0==A129programa_abril) ? true : false);
         A130programa_mayo = 0;
         n130programa_mayo = false;
         AssignAttri(sPrefix, false, "A130programa_mayo", StringUtil.LTrimStr( (decimal)(A130programa_mayo), 9, 0));
         n130programa_mayo = ((0==A130programa_mayo) ? true : false);
         A131programa_junio = 0;
         n131programa_junio = false;
         AssignAttri(sPrefix, false, "A131programa_junio", StringUtil.LTrimStr( (decimal)(A131programa_junio), 9, 0));
         n131programa_junio = ((0==A131programa_junio) ? true : false);
         A132programa_julio = 0;
         n132programa_julio = false;
         AssignAttri(sPrefix, false, "A132programa_julio", StringUtil.LTrimStr( (decimal)(A132programa_julio), 9, 0));
         n132programa_julio = ((0==A132programa_julio) ? true : false);
         A133programa_agosto = 0;
         n133programa_agosto = false;
         AssignAttri(sPrefix, false, "A133programa_agosto", StringUtil.LTrimStr( (decimal)(A133programa_agosto), 9, 0));
         n133programa_agosto = ((0==A133programa_agosto) ? true : false);
         A134programa_sept = 0;
         n134programa_sept = false;
         AssignAttri(sPrefix, false, "A134programa_sept", StringUtil.LTrimStr( (decimal)(A134programa_sept), 9, 0));
         n134programa_sept = ((0==A134programa_sept) ? true : false);
         A135programa_oct = 0;
         n135programa_oct = false;
         AssignAttri(sPrefix, false, "A135programa_oct", StringUtil.LTrimStr( (decimal)(A135programa_oct), 9, 0));
         n135programa_oct = ((0==A135programa_oct) ? true : false);
         A136programa_nov = 0;
         n136programa_nov = false;
         AssignAttri(sPrefix, false, "A136programa_nov", StringUtil.LTrimStr( (decimal)(A136programa_nov), 9, 0));
         n136programa_nov = ((0==A136programa_nov) ? true : false);
         A137programa_dic = 0;
         n137programa_dic = false;
         AssignAttri(sPrefix, false, "A137programa_dic", StringUtil.LTrimStr( (decimal)(A137programa_dic), 9, 0));
         n137programa_dic = ((0==A137programa_dic) ? true : false);
         A138actividades_categoriafecha_creacion = DateTime.MinValue;
         n138actividades_categoriafecha_creacion = false;
         AssignAttri(sPrefix, false, "A138actividades_categoriafecha_creacion", context.localUtil.Format(A138actividades_categoriafecha_creacion, "99/99/99"));
         n138actividades_categoriafecha_creacion = ((DateTime.MinValue==A138actividades_categoriafecha_creacion) ? true : false);
         A139actividades_categoriahora_creacion = 0;
         n139actividades_categoriahora_creacion = false;
         AssignAttri(sPrefix, false, "A139actividades_categoriahora_creacion", StringUtil.LTrimStr( (decimal)(A139actividades_categoriahora_creacion), 5, 0));
         n139actividades_categoriahora_creacion = ((0==A139actividades_categoriahora_creacion) ? true : false);
         A140actividades_categoriacreado_por = "";
         n140actividades_categoriacreado_por = false;
         AssignAttri(sPrefix, false, "A140actividades_categoriacreado_por", A140actividades_categoriacreado_por);
         n140actividades_categoriacreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A140actividades_categoriacreado_por)) ? true : false);
         A141actividades_categoriafecha_modificacion = DateTime.MinValue;
         n141actividades_categoriafecha_modificacion = false;
         AssignAttri(sPrefix, false, "A141actividades_categoriafecha_modificacion", context.localUtil.Format(A141actividades_categoriafecha_modificacion, "99/99/99"));
         n141actividades_categoriafecha_modificacion = ((DateTime.MinValue==A141actividades_categoriafecha_modificacion) ? true : false);
         A142actividades_categoriahora_modificacion = 0;
         n142actividades_categoriahora_modificacion = false;
         AssignAttri(sPrefix, false, "A142actividades_categoriahora_modificacion", StringUtil.LTrimStr( (decimal)(A142actividades_categoriahora_modificacion), 5, 0));
         n142actividades_categoriahora_modificacion = ((0==A142actividades_categoriahora_modificacion) ? true : false);
         A143actividades_categoriamodificado_por = "";
         n143actividades_categoriamodificado_por = false;
         AssignAttri(sPrefix, false, "A143actividades_categoriamodificado_por", A143actividades_categoriamodificado_por);
         n143actividades_categoriamodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A143actividades_categoriamodificado_por)) ? true : false);
         Z122actividades_categoriaid_tipo_categoria = 0;
         Z123nombre_actividad = "";
         Z124unidad_medida = "";
         Z125actividades_categoriaestado = 0;
         Z126programa_enero = 0;
         Z127programa_febrero = 0;
         Z128programa_marzo = 0;
         Z129programa_abril = 0;
         Z130programa_mayo = 0;
         Z131programa_junio = 0;
         Z132programa_julio = 0;
         Z133programa_agosto = 0;
         Z134programa_sept = 0;
         Z135programa_oct = 0;
         Z136programa_nov = 0;
         Z137programa_dic = 0;
         Z138actividades_categoriafecha_creacion = DateTime.MinValue;
         Z139actividades_categoriahora_creacion = 0;
         Z140actividades_categoriacreado_por = "";
         Z141actividades_categoriafecha_modificacion = DateTime.MinValue;
         Z142actividades_categoriahora_modificacion = 0;
         Z143actividades_categoriamodificado_por = "";
      }

      protected void InitAll0C13( )
      {
         A102id_actividad_categoria = 0;
         AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         InitializeNonKey0C13( ) ;
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
         sCtrlAV8id_actividad_categoria = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "actividades_categoria", GetJustCreated( ));
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
            AV8id_actividad_categoria = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV8id_actividad_categoria), 9, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8id_actividad_categoria"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8id_actividad_categoria != wcpOAV8id_actividad_categoria ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8id_actividad_categoria = AV8id_actividad_categoria;
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
         sCtrlAV8id_actividad_categoria = cgiGet( sPrefix+"AV8id_actividad_categoria_CTRL");
         if ( StringUtil.Len( sCtrlAV8id_actividad_categoria) > 0 )
         {
            AV8id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8id_actividad_categoria), ",", "."));
            AssignAttri(sPrefix, false, "AV8id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV8id_actividad_categoria), 9, 0));
         }
         else
         {
            AV8id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8id_actividad_categoria_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8id_actividad_categoria_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8id_actividad_categoria), 9, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8id_actividad_categoria)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8id_actividad_categoria_CTRL", StringUtil.RTrim( sCtrlAV8id_actividad_categoria));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249492840", true, true);
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
         context.AddJavascriptSource("actividades_categoria.js", "?20231249492840", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtid_actividad_categoria_Internalname = sPrefix+"ID_ACTIVIDAD_CATEGORIA";
         divK2btoolstable_attributecontainerid_actividad_categoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_ACTIVIDAD_CATEGORIA";
         edtactividades_categoriaid_tipo_categoria_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         divK2btoolstable_attributecontaineractividades_categoriaid_tipo_categoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA";
         edtnombre_actividad_Internalname = sPrefix+"NOMBRE_ACTIVIDAD";
         divK2btoolstable_attributecontainernombre_actividad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_ACTIVIDAD";
         edtunidad_medida_Internalname = sPrefix+"UNIDAD_MEDIDA";
         divK2btoolstable_attributecontainerunidad_medida_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDAD_MEDIDA";
         edtactividades_categoriaestado_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAESTADO";
         divK2btoolstable_attributecontaineractividades_categoriaestado_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAESTADO";
         edtprograma_enero_Internalname = sPrefix+"PROGRAMA_ENERO";
         divK2btoolstable_attributecontainerprograma_enero_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_ENERO";
         edtprograma_febrero_Internalname = sPrefix+"PROGRAMA_FEBRERO";
         divK2btoolstable_attributecontainerprograma_febrero_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_FEBRERO";
         edtprograma_marzo_Internalname = sPrefix+"PROGRAMA_MARZO";
         divK2btoolstable_attributecontainerprograma_marzo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_MARZO";
         edtprograma_abril_Internalname = sPrefix+"PROGRAMA_ABRIL";
         divK2btoolstable_attributecontainerprograma_abril_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_ABRIL";
         edtprograma_mayo_Internalname = sPrefix+"PROGRAMA_MAYO";
         divK2btoolstable_attributecontainerprograma_mayo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_MAYO";
         edtprograma_junio_Internalname = sPrefix+"PROGRAMA_JUNIO";
         divK2btoolstable_attributecontainerprograma_junio_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_JUNIO";
         edtprograma_julio_Internalname = sPrefix+"PROGRAMA_JULIO";
         divK2btoolstable_attributecontainerprograma_julio_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_JULIO";
         edtprograma_agosto_Internalname = sPrefix+"PROGRAMA_AGOSTO";
         divK2btoolstable_attributecontainerprograma_agosto_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_AGOSTO";
         edtprograma_sept_Internalname = sPrefix+"PROGRAMA_SEPT";
         divK2btoolstable_attributecontainerprograma_sept_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_SEPT";
         edtprograma_oct_Internalname = sPrefix+"PROGRAMA_OCT";
         divK2btoolstable_attributecontainerprograma_oct_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_OCT";
         edtprograma_nov_Internalname = sPrefix+"PROGRAMA_NOV";
         divK2btoolstable_attributecontainerprograma_nov_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_NOV";
         edtprograma_dic_Internalname = sPrefix+"PROGRAMA_DIC";
         divK2btoolstable_attributecontainerprograma_dic_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERPROGRAMA_DIC";
         edtactividades_categoriafecha_creacion_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAFECHA_CREACION";
         divK2btoolstable_attributecontaineractividades_categoriafecha_creacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAFECHA_CREACION";
         edtactividades_categoriahora_creacion_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAHORA_CREACION";
         divK2btoolstable_attributecontaineractividades_categoriahora_creacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAHORA_CREACION";
         edtactividades_categoriacreado_por_Internalname = sPrefix+"ACTIVIDADES_CATEGORIACREADO_POR";
         divK2btoolstable_attributecontaineractividades_categoriacreado_por_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIACREADO_POR";
         edtactividades_categoriafecha_modificacion_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAFECHA_MODIFICACION";
         divK2btoolstable_attributecontaineractividades_categoriafecha_modificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAFECHA_MODIFICACION";
         edtactividades_categoriahora_modificacion_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAHORA_MODIFICACION";
         divK2btoolstable_attributecontaineractividades_categoriahora_modificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAHORA_MODIFICACION";
         edtactividades_categoriamodificado_por_Internalname = sPrefix+"ACTIVIDADES_CATEGORIAMODIFICADO_POR";
         divK2btoolstable_attributecontaineractividades_categoriamodificado_por_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERACTIVIDADES_CATEGORIAMODIFICADO_POR";
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
         Form.Caption = "actividades_categoria";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtactividades_categoriamodificado_por_Jsonclick = "";
         edtactividades_categoriamodificado_por_Enabled = 1;
         edtactividades_categoriahora_modificacion_Jsonclick = "";
         edtactividades_categoriahora_modificacion_Enabled = 1;
         edtactividades_categoriafecha_modificacion_Jsonclick = "";
         edtactividades_categoriafecha_modificacion_Enabled = 1;
         edtactividades_categoriacreado_por_Jsonclick = "";
         edtactividades_categoriacreado_por_Enabled = 1;
         edtactividades_categoriahora_creacion_Jsonclick = "";
         edtactividades_categoriahora_creacion_Enabled = 1;
         edtactividades_categoriafecha_creacion_Jsonclick = "";
         edtactividades_categoriafecha_creacion_Enabled = 1;
         edtprograma_dic_Jsonclick = "";
         edtprograma_dic_Enabled = 1;
         edtprograma_nov_Jsonclick = "";
         edtprograma_nov_Enabled = 1;
         edtprograma_oct_Jsonclick = "";
         edtprograma_oct_Enabled = 1;
         edtprograma_sept_Jsonclick = "";
         edtprograma_sept_Enabled = 1;
         edtprograma_agosto_Jsonclick = "";
         edtprograma_agosto_Enabled = 1;
         edtprograma_julio_Jsonclick = "";
         edtprograma_julio_Enabled = 1;
         edtprograma_junio_Jsonclick = "";
         edtprograma_junio_Enabled = 1;
         edtprograma_mayo_Jsonclick = "";
         edtprograma_mayo_Enabled = 1;
         edtprograma_abril_Jsonclick = "";
         edtprograma_abril_Enabled = 1;
         edtprograma_marzo_Jsonclick = "";
         edtprograma_marzo_Enabled = 1;
         edtprograma_febrero_Jsonclick = "";
         edtprograma_febrero_Enabled = 1;
         edtprograma_enero_Jsonclick = "";
         edtprograma_enero_Enabled = 1;
         edtactividades_categoriaestado_Jsonclick = "";
         edtactividades_categoriaestado_Enabled = 1;
         edtunidad_medida_Jsonclick = "";
         edtunidad_medida_Enabled = 1;
         edtnombre_actividad_Enabled = 1;
         edtactividades_categoriaid_tipo_categoria_Jsonclick = "";
         edtactividades_categoriaid_tipo_categoria_Class = "Attribute_Trn Attribute_Required";
         edtactividades_categoriaid_tipo_categoria_Enabled = 1;
         edtid_actividad_categoria_Jsonclick = "";
         edtid_actividad_categoria_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8id_actividad_categoria',fld:'vID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120C2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A102id_actividad_categoria',fld:'ID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A122actividades_categoriaid_tipo_categoria',fld:'ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A102id_actividad_categoria',fld:'ID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130C2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_ID_ACTIVIDAD_CATEGORIA","{handler:'Valid_Id_actividad_categoria',iparms:[]");
         setEventMetadata("VALID_ID_ACTIVIDAD_CATEGORIA",",oparms:[]}");
         setEventMetadata("VALID_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA","{handler:'Valid_Actividades_categoriaid_tipo_categoria',iparms:[]");
         setEventMetadata("VALID_ACTIVIDADES_CATEGORIAID_TIPO_CATEGORIA",",oparms:[]}");
         setEventMetadata("VALID_ACTIVIDADES_CATEGORIAFECHA_CREACION","{handler:'Valid_Actividades_categoriafecha_creacion',iparms:[]");
         setEventMetadata("VALID_ACTIVIDADES_CATEGORIAFECHA_CREACION",",oparms:[]}");
         setEventMetadata("VALID_ACTIVIDADES_CATEGORIAFECHA_MODIFICACION","{handler:'Valid_Actividades_categoriafecha_modificacion',iparms:[]");
         setEventMetadata("VALID_ACTIVIDADES_CATEGORIAFECHA_MODIFICACION",",oparms:[]}");
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
         Z123nombre_actividad = "";
         Z124unidad_medida = "";
         Z138actividades_categoriafecha_creacion = DateTime.MinValue;
         Z140actividades_categoriacreado_por = "";
         Z141actividades_categoriafecha_modificacion = DateTime.MinValue;
         Z143actividades_categoriamodificado_por = "";
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
         A123nombre_actividad = "";
         A124unidad_medida = "";
         A138actividades_categoriafecha_creacion = DateTime.MinValue;
         A140actividades_categoriacreado_por = "";
         A141actividades_categoriafecha_modificacion = DateTime.MinValue;
         A143actividades_categoriamodificado_por = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV25Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode13 = "";
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
         T000C4_A102id_actividad_categoria = new int[1] ;
         T000C4_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         T000C4_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         T000C4_A123nombre_actividad = new string[] {""} ;
         T000C4_n123nombre_actividad = new bool[] {false} ;
         T000C4_A124unidad_medida = new string[] {""} ;
         T000C4_n124unidad_medida = new bool[] {false} ;
         T000C4_A125actividades_categoriaestado = new int[1] ;
         T000C4_n125actividades_categoriaestado = new bool[] {false} ;
         T000C4_A126programa_enero = new int[1] ;
         T000C4_n126programa_enero = new bool[] {false} ;
         T000C4_A127programa_febrero = new int[1] ;
         T000C4_n127programa_febrero = new bool[] {false} ;
         T000C4_A128programa_marzo = new int[1] ;
         T000C4_n128programa_marzo = new bool[] {false} ;
         T000C4_A129programa_abril = new int[1] ;
         T000C4_n129programa_abril = new bool[] {false} ;
         T000C4_A130programa_mayo = new int[1] ;
         T000C4_n130programa_mayo = new bool[] {false} ;
         T000C4_A131programa_junio = new int[1] ;
         T000C4_n131programa_junio = new bool[] {false} ;
         T000C4_A132programa_julio = new int[1] ;
         T000C4_n132programa_julio = new bool[] {false} ;
         T000C4_A133programa_agosto = new int[1] ;
         T000C4_n133programa_agosto = new bool[] {false} ;
         T000C4_A134programa_sept = new int[1] ;
         T000C4_n134programa_sept = new bool[] {false} ;
         T000C4_A135programa_oct = new int[1] ;
         T000C4_n135programa_oct = new bool[] {false} ;
         T000C4_A136programa_nov = new int[1] ;
         T000C4_n136programa_nov = new bool[] {false} ;
         T000C4_A137programa_dic = new int[1] ;
         T000C4_n137programa_dic = new bool[] {false} ;
         T000C4_A138actividades_categoriafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000C4_n138actividades_categoriafecha_creacion = new bool[] {false} ;
         T000C4_A139actividades_categoriahora_creacion = new int[1] ;
         T000C4_n139actividades_categoriahora_creacion = new bool[] {false} ;
         T000C4_A140actividades_categoriacreado_por = new string[] {""} ;
         T000C4_n140actividades_categoriacreado_por = new bool[] {false} ;
         T000C4_A141actividades_categoriafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000C4_n141actividades_categoriafecha_modificacion = new bool[] {false} ;
         T000C4_A142actividades_categoriahora_modificacion = new int[1] ;
         T000C4_n142actividades_categoriahora_modificacion = new bool[] {false} ;
         T000C4_A143actividades_categoriamodificado_por = new string[] {""} ;
         T000C4_n143actividades_categoriamodificado_por = new bool[] {false} ;
         T000C5_A102id_actividad_categoria = new int[1] ;
         T000C3_A102id_actividad_categoria = new int[1] ;
         T000C3_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         T000C3_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         T000C3_A123nombre_actividad = new string[] {""} ;
         T000C3_n123nombre_actividad = new bool[] {false} ;
         T000C3_A124unidad_medida = new string[] {""} ;
         T000C3_n124unidad_medida = new bool[] {false} ;
         T000C3_A125actividades_categoriaestado = new int[1] ;
         T000C3_n125actividades_categoriaestado = new bool[] {false} ;
         T000C3_A126programa_enero = new int[1] ;
         T000C3_n126programa_enero = new bool[] {false} ;
         T000C3_A127programa_febrero = new int[1] ;
         T000C3_n127programa_febrero = new bool[] {false} ;
         T000C3_A128programa_marzo = new int[1] ;
         T000C3_n128programa_marzo = new bool[] {false} ;
         T000C3_A129programa_abril = new int[1] ;
         T000C3_n129programa_abril = new bool[] {false} ;
         T000C3_A130programa_mayo = new int[1] ;
         T000C3_n130programa_mayo = new bool[] {false} ;
         T000C3_A131programa_junio = new int[1] ;
         T000C3_n131programa_junio = new bool[] {false} ;
         T000C3_A132programa_julio = new int[1] ;
         T000C3_n132programa_julio = new bool[] {false} ;
         T000C3_A133programa_agosto = new int[1] ;
         T000C3_n133programa_agosto = new bool[] {false} ;
         T000C3_A134programa_sept = new int[1] ;
         T000C3_n134programa_sept = new bool[] {false} ;
         T000C3_A135programa_oct = new int[1] ;
         T000C3_n135programa_oct = new bool[] {false} ;
         T000C3_A136programa_nov = new int[1] ;
         T000C3_n136programa_nov = new bool[] {false} ;
         T000C3_A137programa_dic = new int[1] ;
         T000C3_n137programa_dic = new bool[] {false} ;
         T000C3_A138actividades_categoriafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000C3_n138actividades_categoriafecha_creacion = new bool[] {false} ;
         T000C3_A139actividades_categoriahora_creacion = new int[1] ;
         T000C3_n139actividades_categoriahora_creacion = new bool[] {false} ;
         T000C3_A140actividades_categoriacreado_por = new string[] {""} ;
         T000C3_n140actividades_categoriacreado_por = new bool[] {false} ;
         T000C3_A141actividades_categoriafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000C3_n141actividades_categoriafecha_modificacion = new bool[] {false} ;
         T000C3_A142actividades_categoriahora_modificacion = new int[1] ;
         T000C3_n142actividades_categoriahora_modificacion = new bool[] {false} ;
         T000C3_A143actividades_categoriamodificado_por = new string[] {""} ;
         T000C3_n143actividades_categoriamodificado_por = new bool[] {false} ;
         T000C6_A102id_actividad_categoria = new int[1] ;
         T000C7_A102id_actividad_categoria = new int[1] ;
         T000C2_A102id_actividad_categoria = new int[1] ;
         T000C2_A122actividades_categoriaid_tipo_categoria = new int[1] ;
         T000C2_n122actividades_categoriaid_tipo_categoria = new bool[] {false} ;
         T000C2_A123nombre_actividad = new string[] {""} ;
         T000C2_n123nombre_actividad = new bool[] {false} ;
         T000C2_A124unidad_medida = new string[] {""} ;
         T000C2_n124unidad_medida = new bool[] {false} ;
         T000C2_A125actividades_categoriaestado = new int[1] ;
         T000C2_n125actividades_categoriaestado = new bool[] {false} ;
         T000C2_A126programa_enero = new int[1] ;
         T000C2_n126programa_enero = new bool[] {false} ;
         T000C2_A127programa_febrero = new int[1] ;
         T000C2_n127programa_febrero = new bool[] {false} ;
         T000C2_A128programa_marzo = new int[1] ;
         T000C2_n128programa_marzo = new bool[] {false} ;
         T000C2_A129programa_abril = new int[1] ;
         T000C2_n129programa_abril = new bool[] {false} ;
         T000C2_A130programa_mayo = new int[1] ;
         T000C2_n130programa_mayo = new bool[] {false} ;
         T000C2_A131programa_junio = new int[1] ;
         T000C2_n131programa_junio = new bool[] {false} ;
         T000C2_A132programa_julio = new int[1] ;
         T000C2_n132programa_julio = new bool[] {false} ;
         T000C2_A133programa_agosto = new int[1] ;
         T000C2_n133programa_agosto = new bool[] {false} ;
         T000C2_A134programa_sept = new int[1] ;
         T000C2_n134programa_sept = new bool[] {false} ;
         T000C2_A135programa_oct = new int[1] ;
         T000C2_n135programa_oct = new bool[] {false} ;
         T000C2_A136programa_nov = new int[1] ;
         T000C2_n136programa_nov = new bool[] {false} ;
         T000C2_A137programa_dic = new int[1] ;
         T000C2_n137programa_dic = new bool[] {false} ;
         T000C2_A138actividades_categoriafecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000C2_n138actividades_categoriafecha_creacion = new bool[] {false} ;
         T000C2_A139actividades_categoriahora_creacion = new int[1] ;
         T000C2_n139actividades_categoriahora_creacion = new bool[] {false} ;
         T000C2_A140actividades_categoriacreado_por = new string[] {""} ;
         T000C2_n140actividades_categoriacreado_por = new bool[] {false} ;
         T000C2_A141actividades_categoriafecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000C2_n141actividades_categoriafecha_modificacion = new bool[] {false} ;
         T000C2_A142actividades_categoriahora_modificacion = new int[1] ;
         T000C2_n142actividades_categoriahora_modificacion = new bool[] {false} ;
         T000C2_A143actividades_categoriamodificado_por = new string[] {""} ;
         T000C2_n143actividades_categoriamodificado_por = new bool[] {false} ;
         T000C8_A102id_actividad_categoria = new int[1] ;
         T000C11_A18TicketTecnicoId = new long[1] ;
         T000C12_A3EstadoId = new short[1] ;
         T000C13_A102id_actividad_categoria = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV8id_actividad_categoria = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actividades_categoria__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.actividades_categoria__datastore1(),
            new Object[][] {
                new Object[] {
               T000C2_A102id_actividad_categoria, T000C2_A122actividades_categoriaid_tipo_categoria, T000C2_n122actividades_categoriaid_tipo_categoria, T000C2_A123nombre_actividad, T000C2_n123nombre_actividad, T000C2_A124unidad_medida, T000C2_n124unidad_medida, T000C2_A125actividades_categoriaestado, T000C2_n125actividades_categoriaestado, T000C2_A126programa_enero,
               T000C2_n126programa_enero, T000C2_A127programa_febrero, T000C2_n127programa_febrero, T000C2_A128programa_marzo, T000C2_n128programa_marzo, T000C2_A129programa_abril, T000C2_n129programa_abril, T000C2_A130programa_mayo, T000C2_n130programa_mayo, T000C2_A131programa_junio,
               T000C2_n131programa_junio, T000C2_A132programa_julio, T000C2_n132programa_julio, T000C2_A133programa_agosto, T000C2_n133programa_agosto, T000C2_A134programa_sept, T000C2_n134programa_sept, T000C2_A135programa_oct, T000C2_n135programa_oct, T000C2_A136programa_nov,
               T000C2_n136programa_nov, T000C2_A137programa_dic, T000C2_n137programa_dic, T000C2_A138actividades_categoriafecha_creacion, T000C2_n138actividades_categoriafecha_creacion, T000C2_A139actividades_categoriahora_creacion, T000C2_n139actividades_categoriahora_creacion, T000C2_A140actividades_categoriacreado_por, T000C2_n140actividades_categoriacreado_por, T000C2_A141actividades_categoriafecha_modificacion,
               T000C2_n141actividades_categoriafecha_modificacion, T000C2_A142actividades_categoriahora_modificacion, T000C2_n142actividades_categoriahora_modificacion, T000C2_A143actividades_categoriamodificado_por, T000C2_n143actividades_categoriamodificado_por
               }
               , new Object[] {
               T000C3_A102id_actividad_categoria, T000C3_A122actividades_categoriaid_tipo_categoria, T000C3_n122actividades_categoriaid_tipo_categoria, T000C3_A123nombre_actividad, T000C3_n123nombre_actividad, T000C3_A124unidad_medida, T000C3_n124unidad_medida, T000C3_A125actividades_categoriaestado, T000C3_n125actividades_categoriaestado, T000C3_A126programa_enero,
               T000C3_n126programa_enero, T000C3_A127programa_febrero, T000C3_n127programa_febrero, T000C3_A128programa_marzo, T000C3_n128programa_marzo, T000C3_A129programa_abril, T000C3_n129programa_abril, T000C3_A130programa_mayo, T000C3_n130programa_mayo, T000C3_A131programa_junio,
               T000C3_n131programa_junio, T000C3_A132programa_julio, T000C3_n132programa_julio, T000C3_A133programa_agosto, T000C3_n133programa_agosto, T000C3_A134programa_sept, T000C3_n134programa_sept, T000C3_A135programa_oct, T000C3_n135programa_oct, T000C3_A136programa_nov,
               T000C3_n136programa_nov, T000C3_A137programa_dic, T000C3_n137programa_dic, T000C3_A138actividades_categoriafecha_creacion, T000C3_n138actividades_categoriafecha_creacion, T000C3_A139actividades_categoriahora_creacion, T000C3_n139actividades_categoriahora_creacion, T000C3_A140actividades_categoriacreado_por, T000C3_n140actividades_categoriacreado_por, T000C3_A141actividades_categoriafecha_modificacion,
               T000C3_n141actividades_categoriafecha_modificacion, T000C3_A142actividades_categoriahora_modificacion, T000C3_n142actividades_categoriahora_modificacion, T000C3_A143actividades_categoriamodificado_por, T000C3_n143actividades_categoriamodificado_por
               }
               , new Object[] {
               T000C4_A102id_actividad_categoria, T000C4_A122actividades_categoriaid_tipo_categoria, T000C4_n122actividades_categoriaid_tipo_categoria, T000C4_A123nombre_actividad, T000C4_n123nombre_actividad, T000C4_A124unidad_medida, T000C4_n124unidad_medida, T000C4_A125actividades_categoriaestado, T000C4_n125actividades_categoriaestado, T000C4_A126programa_enero,
               T000C4_n126programa_enero, T000C4_A127programa_febrero, T000C4_n127programa_febrero, T000C4_A128programa_marzo, T000C4_n128programa_marzo, T000C4_A129programa_abril, T000C4_n129programa_abril, T000C4_A130programa_mayo, T000C4_n130programa_mayo, T000C4_A131programa_junio,
               T000C4_n131programa_junio, T000C4_A132programa_julio, T000C4_n132programa_julio, T000C4_A133programa_agosto, T000C4_n133programa_agosto, T000C4_A134programa_sept, T000C4_n134programa_sept, T000C4_A135programa_oct, T000C4_n135programa_oct, T000C4_A136programa_nov,
               T000C4_n136programa_nov, T000C4_A137programa_dic, T000C4_n137programa_dic, T000C4_A138actividades_categoriafecha_creacion, T000C4_n138actividades_categoriafecha_creacion, T000C4_A139actividades_categoriahora_creacion, T000C4_n139actividades_categoriahora_creacion, T000C4_A140actividades_categoriacreado_por, T000C4_n140actividades_categoriacreado_por, T000C4_A141actividades_categoriafecha_modificacion,
               T000C4_n141actividades_categoriafecha_modificacion, T000C4_A142actividades_categoriahora_modificacion, T000C4_n142actividades_categoriahora_modificacion, T000C4_A143actividades_categoriamodificado_por, T000C4_n143actividades_categoriamodificado_por
               }
               , new Object[] {
               T000C5_A102id_actividad_categoria
               }
               , new Object[] {
               T000C6_A102id_actividad_categoria
               }
               , new Object[] {
               T000C7_A102id_actividad_categoria
               }
               , new Object[] {
               T000C8_A102id_actividad_categoria
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C13_A102id_actividad_categoria
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.actividades_categoria__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actividades_categoria__default(),
            new Object[][] {
                new Object[] {
               T000C11_A18TicketTecnicoId
               }
               , new Object[] {
               T000C12_A3EstadoId
               }
            }
         );
         AV25Pgmname = "actividades_categoria";
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
      private short RcdFound13 ;
      private short GX_JID ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private int wcpOAV8id_actividad_categoria ;
      private int Z102id_actividad_categoria ;
      private int Z122actividades_categoriaid_tipo_categoria ;
      private int Z125actividades_categoriaestado ;
      private int Z126programa_enero ;
      private int Z127programa_febrero ;
      private int Z128programa_marzo ;
      private int Z129programa_abril ;
      private int Z130programa_mayo ;
      private int Z131programa_junio ;
      private int Z132programa_julio ;
      private int Z133programa_agosto ;
      private int Z134programa_sept ;
      private int Z135programa_oct ;
      private int Z136programa_nov ;
      private int Z137programa_dic ;
      private int Z139actividades_categoriahora_creacion ;
      private int Z142actividades_categoriahora_modificacion ;
      private int AV8id_actividad_categoria ;
      private int trnEnded ;
      private int A102id_actividad_categoria ;
      private int edtid_actividad_categoria_Enabled ;
      private int A122actividades_categoriaid_tipo_categoria ;
      private int edtactividades_categoriaid_tipo_categoria_Enabled ;
      private int edtnombre_actividad_Enabled ;
      private int edtunidad_medida_Enabled ;
      private int A125actividades_categoriaestado ;
      private int edtactividades_categoriaestado_Enabled ;
      private int A126programa_enero ;
      private int edtprograma_enero_Enabled ;
      private int A127programa_febrero ;
      private int edtprograma_febrero_Enabled ;
      private int A128programa_marzo ;
      private int edtprograma_marzo_Enabled ;
      private int A129programa_abril ;
      private int edtprograma_abril_Enabled ;
      private int A130programa_mayo ;
      private int edtprograma_mayo_Enabled ;
      private int A131programa_junio ;
      private int edtprograma_junio_Enabled ;
      private int A132programa_julio ;
      private int edtprograma_julio_Enabled ;
      private int A133programa_agosto ;
      private int edtprograma_agosto_Enabled ;
      private int A134programa_sept ;
      private int edtprograma_sept_Enabled ;
      private int A135programa_oct ;
      private int edtprograma_oct_Enabled ;
      private int A136programa_nov ;
      private int edtprograma_nov_Enabled ;
      private int A137programa_dic ;
      private int edtprograma_dic_Enabled ;
      private int edtactividades_categoriafecha_creacion_Enabled ;
      private int A139actividades_categoriahora_creacion ;
      private int edtactividades_categoriahora_creacion_Enabled ;
      private int edtactividades_categoriacreado_por_Enabled ;
      private int edtactividades_categoriafecha_modificacion_Enabled ;
      private int A142actividades_categoriahora_modificacion ;
      private int edtactividades_categoriahora_modificacion_Enabled ;
      private int edtactividades_categoriamodificado_por_Enabled ;
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
      private string edtactividades_categoriaid_tipo_categoria_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerid_actividad_categoria_Internalname ;
      private string edtid_actividad_categoria_Internalname ;
      private string edtid_actividad_categoria_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriaid_tipo_categoria_Internalname ;
      private string TempTags ;
      private string edtactividades_categoriaid_tipo_categoria_Jsonclick ;
      private string edtactividades_categoriaid_tipo_categoria_Class ;
      private string divK2btoolstable_attributecontainernombre_actividad_Internalname ;
      private string edtnombre_actividad_Internalname ;
      private string divK2btoolstable_attributecontainerunidad_medida_Internalname ;
      private string edtunidad_medida_Internalname ;
      private string edtunidad_medida_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriaestado_Internalname ;
      private string edtactividades_categoriaestado_Internalname ;
      private string edtactividades_categoriaestado_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_enero_Internalname ;
      private string edtprograma_enero_Internalname ;
      private string edtprograma_enero_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_febrero_Internalname ;
      private string edtprograma_febrero_Internalname ;
      private string edtprograma_febrero_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_marzo_Internalname ;
      private string edtprograma_marzo_Internalname ;
      private string edtprograma_marzo_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_abril_Internalname ;
      private string edtprograma_abril_Internalname ;
      private string edtprograma_abril_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_mayo_Internalname ;
      private string edtprograma_mayo_Internalname ;
      private string edtprograma_mayo_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_junio_Internalname ;
      private string edtprograma_junio_Internalname ;
      private string edtprograma_junio_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_julio_Internalname ;
      private string edtprograma_julio_Internalname ;
      private string edtprograma_julio_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_agosto_Internalname ;
      private string edtprograma_agosto_Internalname ;
      private string edtprograma_agosto_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_sept_Internalname ;
      private string edtprograma_sept_Internalname ;
      private string edtprograma_sept_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_oct_Internalname ;
      private string edtprograma_oct_Internalname ;
      private string edtprograma_oct_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_nov_Internalname ;
      private string edtprograma_nov_Internalname ;
      private string edtprograma_nov_Jsonclick ;
      private string divK2btoolstable_attributecontainerprograma_dic_Internalname ;
      private string edtprograma_dic_Internalname ;
      private string edtprograma_dic_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriafecha_creacion_Internalname ;
      private string edtactividades_categoriafecha_creacion_Internalname ;
      private string edtactividades_categoriafecha_creacion_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriahora_creacion_Internalname ;
      private string edtactividades_categoriahora_creacion_Internalname ;
      private string edtactividades_categoriahora_creacion_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriacreado_por_Internalname ;
      private string edtactividades_categoriacreado_por_Internalname ;
      private string edtactividades_categoriacreado_por_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriafecha_modificacion_Internalname ;
      private string edtactividades_categoriafecha_modificacion_Internalname ;
      private string edtactividades_categoriafecha_modificacion_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriahora_modificacion_Internalname ;
      private string edtactividades_categoriahora_modificacion_Internalname ;
      private string edtactividades_categoriahora_modificacion_Jsonclick ;
      private string divK2btoolstable_attributecontaineractividades_categoriamodificado_por_Internalname ;
      private string edtactividades_categoriamodificado_por_Internalname ;
      private string edtactividades_categoriamodificado_por_Jsonclick ;
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
      private string sMode13 ;
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
      private string sCtrlAV8id_actividad_categoria ;
      private DateTime Z138actividades_categoriafecha_creacion ;
      private DateTime Z141actividades_categoriafecha_modificacion ;
      private DateTime A138actividades_categoriafecha_creacion ;
      private DateTime A141actividades_categoriafecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n122actividades_categoriaid_tipo_categoria ;
      private bool n123nombre_actividad ;
      private bool n124unidad_medida ;
      private bool n125actividades_categoriaestado ;
      private bool n126programa_enero ;
      private bool n127programa_febrero ;
      private bool n128programa_marzo ;
      private bool n129programa_abril ;
      private bool n130programa_mayo ;
      private bool n131programa_junio ;
      private bool n132programa_julio ;
      private bool n133programa_agosto ;
      private bool n134programa_sept ;
      private bool n135programa_oct ;
      private bool n136programa_nov ;
      private bool n137programa_dic ;
      private bool n138actividades_categoriafecha_creacion ;
      private bool n139actividades_categoriahora_creacion ;
      private bool n140actividades_categoriacreado_por ;
      private bool n141actividades_categoriafecha_modificacion ;
      private bool n142actividades_categoriahora_modificacion ;
      private bool n143actividades_categoriamodificado_por ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
      private bool Gx_longc ;
      private string Z123nombre_actividad ;
      private string Z124unidad_medida ;
      private string Z140actividades_categoriacreado_por ;
      private string Z143actividades_categoriamodificado_por ;
      private string A123nombre_actividad ;
      private string A124unidad_medida ;
      private string A140actividades_categoriacreado_por ;
      private string A143actividades_categoriamodificado_por ;
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
      private int[] T000C4_A102id_actividad_categoria ;
      private int[] T000C4_A122actividades_categoriaid_tipo_categoria ;
      private bool[] T000C4_n122actividades_categoriaid_tipo_categoria ;
      private string[] T000C4_A123nombre_actividad ;
      private bool[] T000C4_n123nombre_actividad ;
      private string[] T000C4_A124unidad_medida ;
      private bool[] T000C4_n124unidad_medida ;
      private int[] T000C4_A125actividades_categoriaestado ;
      private bool[] T000C4_n125actividades_categoriaestado ;
      private int[] T000C4_A126programa_enero ;
      private bool[] T000C4_n126programa_enero ;
      private int[] T000C4_A127programa_febrero ;
      private bool[] T000C4_n127programa_febrero ;
      private int[] T000C4_A128programa_marzo ;
      private bool[] T000C4_n128programa_marzo ;
      private int[] T000C4_A129programa_abril ;
      private bool[] T000C4_n129programa_abril ;
      private int[] T000C4_A130programa_mayo ;
      private bool[] T000C4_n130programa_mayo ;
      private int[] T000C4_A131programa_junio ;
      private bool[] T000C4_n131programa_junio ;
      private int[] T000C4_A132programa_julio ;
      private bool[] T000C4_n132programa_julio ;
      private int[] T000C4_A133programa_agosto ;
      private bool[] T000C4_n133programa_agosto ;
      private int[] T000C4_A134programa_sept ;
      private bool[] T000C4_n134programa_sept ;
      private int[] T000C4_A135programa_oct ;
      private bool[] T000C4_n135programa_oct ;
      private int[] T000C4_A136programa_nov ;
      private bool[] T000C4_n136programa_nov ;
      private int[] T000C4_A137programa_dic ;
      private bool[] T000C4_n137programa_dic ;
      private DateTime[] T000C4_A138actividades_categoriafecha_creacion ;
      private bool[] T000C4_n138actividades_categoriafecha_creacion ;
      private int[] T000C4_A139actividades_categoriahora_creacion ;
      private bool[] T000C4_n139actividades_categoriahora_creacion ;
      private string[] T000C4_A140actividades_categoriacreado_por ;
      private bool[] T000C4_n140actividades_categoriacreado_por ;
      private DateTime[] T000C4_A141actividades_categoriafecha_modificacion ;
      private bool[] T000C4_n141actividades_categoriafecha_modificacion ;
      private int[] T000C4_A142actividades_categoriahora_modificacion ;
      private bool[] T000C4_n142actividades_categoriahora_modificacion ;
      private string[] T000C4_A143actividades_categoriamodificado_por ;
      private bool[] T000C4_n143actividades_categoriamodificado_por ;
      private int[] T000C5_A102id_actividad_categoria ;
      private int[] T000C3_A102id_actividad_categoria ;
      private int[] T000C3_A122actividades_categoriaid_tipo_categoria ;
      private bool[] T000C3_n122actividades_categoriaid_tipo_categoria ;
      private string[] T000C3_A123nombre_actividad ;
      private bool[] T000C3_n123nombre_actividad ;
      private string[] T000C3_A124unidad_medida ;
      private bool[] T000C3_n124unidad_medida ;
      private int[] T000C3_A125actividades_categoriaestado ;
      private bool[] T000C3_n125actividades_categoriaestado ;
      private int[] T000C3_A126programa_enero ;
      private bool[] T000C3_n126programa_enero ;
      private int[] T000C3_A127programa_febrero ;
      private bool[] T000C3_n127programa_febrero ;
      private int[] T000C3_A128programa_marzo ;
      private bool[] T000C3_n128programa_marzo ;
      private int[] T000C3_A129programa_abril ;
      private bool[] T000C3_n129programa_abril ;
      private int[] T000C3_A130programa_mayo ;
      private bool[] T000C3_n130programa_mayo ;
      private int[] T000C3_A131programa_junio ;
      private bool[] T000C3_n131programa_junio ;
      private int[] T000C3_A132programa_julio ;
      private bool[] T000C3_n132programa_julio ;
      private int[] T000C3_A133programa_agosto ;
      private bool[] T000C3_n133programa_agosto ;
      private int[] T000C3_A134programa_sept ;
      private bool[] T000C3_n134programa_sept ;
      private int[] T000C3_A135programa_oct ;
      private bool[] T000C3_n135programa_oct ;
      private int[] T000C3_A136programa_nov ;
      private bool[] T000C3_n136programa_nov ;
      private int[] T000C3_A137programa_dic ;
      private bool[] T000C3_n137programa_dic ;
      private DateTime[] T000C3_A138actividades_categoriafecha_creacion ;
      private bool[] T000C3_n138actividades_categoriafecha_creacion ;
      private int[] T000C3_A139actividades_categoriahora_creacion ;
      private bool[] T000C3_n139actividades_categoriahora_creacion ;
      private string[] T000C3_A140actividades_categoriacreado_por ;
      private bool[] T000C3_n140actividades_categoriacreado_por ;
      private DateTime[] T000C3_A141actividades_categoriafecha_modificacion ;
      private bool[] T000C3_n141actividades_categoriafecha_modificacion ;
      private int[] T000C3_A142actividades_categoriahora_modificacion ;
      private bool[] T000C3_n142actividades_categoriahora_modificacion ;
      private string[] T000C3_A143actividades_categoriamodificado_por ;
      private bool[] T000C3_n143actividades_categoriamodificado_por ;
      private int[] T000C6_A102id_actividad_categoria ;
      private int[] T000C7_A102id_actividad_categoria ;
      private int[] T000C2_A102id_actividad_categoria ;
      private int[] T000C2_A122actividades_categoriaid_tipo_categoria ;
      private bool[] T000C2_n122actividades_categoriaid_tipo_categoria ;
      private string[] T000C2_A123nombre_actividad ;
      private bool[] T000C2_n123nombre_actividad ;
      private string[] T000C2_A124unidad_medida ;
      private bool[] T000C2_n124unidad_medida ;
      private int[] T000C2_A125actividades_categoriaestado ;
      private bool[] T000C2_n125actividades_categoriaestado ;
      private int[] T000C2_A126programa_enero ;
      private bool[] T000C2_n126programa_enero ;
      private int[] T000C2_A127programa_febrero ;
      private bool[] T000C2_n127programa_febrero ;
      private int[] T000C2_A128programa_marzo ;
      private bool[] T000C2_n128programa_marzo ;
      private int[] T000C2_A129programa_abril ;
      private bool[] T000C2_n129programa_abril ;
      private int[] T000C2_A130programa_mayo ;
      private bool[] T000C2_n130programa_mayo ;
      private int[] T000C2_A131programa_junio ;
      private bool[] T000C2_n131programa_junio ;
      private int[] T000C2_A132programa_julio ;
      private bool[] T000C2_n132programa_julio ;
      private int[] T000C2_A133programa_agosto ;
      private bool[] T000C2_n133programa_agosto ;
      private int[] T000C2_A134programa_sept ;
      private bool[] T000C2_n134programa_sept ;
      private int[] T000C2_A135programa_oct ;
      private bool[] T000C2_n135programa_oct ;
      private int[] T000C2_A136programa_nov ;
      private bool[] T000C2_n136programa_nov ;
      private int[] T000C2_A137programa_dic ;
      private bool[] T000C2_n137programa_dic ;
      private DateTime[] T000C2_A138actividades_categoriafecha_creacion ;
      private bool[] T000C2_n138actividades_categoriafecha_creacion ;
      private int[] T000C2_A139actividades_categoriahora_creacion ;
      private bool[] T000C2_n139actividades_categoriahora_creacion ;
      private string[] T000C2_A140actividades_categoriacreado_por ;
      private bool[] T000C2_n140actividades_categoriacreado_por ;
      private DateTime[] T000C2_A141actividades_categoriafecha_modificacion ;
      private bool[] T000C2_n141actividades_categoriafecha_modificacion ;
      private int[] T000C2_A142actividades_categoriahora_modificacion ;
      private bool[] T000C2_n142actividades_categoriahora_modificacion ;
      private string[] T000C2_A143actividades_categoriamodificado_por ;
      private bool[] T000C2_n143actividades_categoriamodificado_por ;
      private int[] T000C8_A102id_actividad_categoria ;
      private IDataStoreProvider pr_default ;
      private long[] T000C11_A18TicketTecnicoId ;
      private short[] T000C12_A3EstadoId ;
      private int[] T000C13_A102id_actividad_categoria ;
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

   public class actividades_categoria__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actividades_categoria__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000C4;
        prmT000C4 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C5;
        prmT000C5 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C3;
        prmT000C3 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C6;
        prmT000C6 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C7;
        prmT000C7 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C2;
        prmT000C2 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C8;
        prmT000C8 = new Object[] {
        new ParDef("@actividades_categoriaid_tipo_categoria",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@nombre_actividad",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@unidad_medida",GXType.NVarChar,80,0){Nullable=true} ,
        new ParDef("@actividades_categoriaestado",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_enero",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_febrero",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_marzo",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_abril",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_mayo",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_junio",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_julio",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_agosto",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_sept",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_oct",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_nov",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_dic",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@actividades_categoriafecha_creacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@actividades_categoriahora_creacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@actividades_categoriacreado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@actividades_categoriafecha_modificacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@actividades_categoriahora_modificacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@actividades_categoriamodificado_por",GXType.NVarChar,30,0){Nullable=true}
        };
        Object[] prmT000C9;
        prmT000C9 = new Object[] {
        new ParDef("@actividades_categoriaid_tipo_categoria",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@nombre_actividad",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@unidad_medida",GXType.NVarChar,80,0){Nullable=true} ,
        new ParDef("@actividades_categoriaestado",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_enero",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_febrero",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_marzo",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_abril",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_mayo",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_junio",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_julio",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_agosto",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_sept",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_oct",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_nov",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@programa_dic",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@actividades_categoriafecha_creacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@actividades_categoriahora_creacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@actividades_categoriacreado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@actividades_categoriafecha_modificacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@actividades_categoriahora_modificacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@actividades_categoriamodificado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C10;
        prmT000C10 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000C13;
        prmT000C13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000C2", "SELECT [id_actividad_categoria], [id_tipo_categoria], [nombre_actividad], [unidad_medida], [estado], [programa_enero], [programa_febrero], [programa_marzo], [programa_abril], [programa_mayo], [programa_junio], [programa_julio], [programa_agosto], [programa_sept], [programa_oct], [programa_nov], [programa_dic], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por] FROM dbo.[actividades_categoria] WITH (UPDLOCK) WHERE [id_actividad_categoria] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C3", "SELECT [id_actividad_categoria], [id_tipo_categoria], [nombre_actividad], [unidad_medida], [estado], [programa_enero], [programa_febrero], [programa_marzo], [programa_abril], [programa_mayo], [programa_junio], [programa_julio], [programa_agosto], [programa_sept], [programa_oct], [programa_nov], [programa_dic], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C4", "SELECT TM1.[id_actividad_categoria], TM1.[id_tipo_categoria], TM1.[nombre_actividad], TM1.[unidad_medida], TM1.[estado], TM1.[programa_enero], TM1.[programa_febrero], TM1.[programa_marzo], TM1.[programa_abril], TM1.[programa_mayo], TM1.[programa_junio], TM1.[programa_julio], TM1.[programa_agosto], TM1.[programa_sept], TM1.[programa_oct], TM1.[programa_nov], TM1.[programa_dic], TM1.[fecha_creacion], TM1.[hora_creacion], TM1.[creado_por], TM1.[fecha_modificacion], TM1.[hora_modificacion], TM1.[modificado_por] FROM dbo.[actividades_categoria] TM1 WHERE TM1.[id_actividad_categoria] = @id_actividad_categoria ORDER BY TM1.[id_actividad_categoria]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C5", "SELECT [id_actividad_categoria] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C6", "SELECT TOP 1 [id_actividad_categoria] FROM dbo.[actividades_categoria] WHERE ( [id_actividad_categoria] > @id_actividad_categoria) ORDER BY [id_actividad_categoria]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C7", "SELECT TOP 1 [id_actividad_categoria] FROM dbo.[actividades_categoria] WHERE ( [id_actividad_categoria] < @id_actividad_categoria) ORDER BY [id_actividad_categoria] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C8", "INSERT INTO dbo.[actividades_categoria]([id_tipo_categoria], [nombre_actividad], [unidad_medida], [estado], [programa_enero], [programa_febrero], [programa_marzo], [programa_abril], [programa_mayo], [programa_junio], [programa_julio], [programa_agosto], [programa_sept], [programa_oct], [programa_nov], [programa_dic], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por]) VALUES(@actividades_categoriaid_tipo_categoria, @nombre_actividad, @unidad_medida, @actividades_categoriaestado, @programa_enero, @programa_febrero, @programa_marzo, @programa_abril, @programa_mayo, @programa_junio, @programa_julio, @programa_agosto, @programa_sept, @programa_oct, @programa_nov, @programa_dic, @actividades_categoriafecha_creacion, @actividades_categoriahora_creacion, @actividades_categoriacreado_por, @actividades_categoriafecha_modificacion, @actividades_categoriahora_modificacion, @actividades_categoriamodificado_por); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000C8)
           ,new CursorDef("T000C9", "UPDATE dbo.[actividades_categoria] SET [id_tipo_categoria]=@actividades_categoriaid_tipo_categoria, [nombre_actividad]=@nombre_actividad, [unidad_medida]=@unidad_medida, [estado]=@actividades_categoriaestado, [programa_enero]=@programa_enero, [programa_febrero]=@programa_febrero, [programa_marzo]=@programa_marzo, [programa_abril]=@programa_abril, [programa_mayo]=@programa_mayo, [programa_junio]=@programa_junio, [programa_julio]=@programa_julio, [programa_agosto]=@programa_agosto, [programa_sept]=@programa_sept, [programa_oct]=@programa_oct, [programa_nov]=@programa_nov, [programa_dic]=@programa_dic, [fecha_creacion]=@actividades_categoriafecha_creacion, [hora_creacion]=@actividades_categoriahora_creacion, [creado_por]=@actividades_categoriacreado_por, [fecha_modificacion]=@actividades_categoriafecha_modificacion, [hora_modificacion]=@actividades_categoriahora_modificacion, [modificado_por]=@actividades_categoriamodificado_por  WHERE [id_actividad_categoria] = @id_actividad_categoria", GxErrorMask.GX_NOMASK,prmT000C9)
           ,new CursorDef("T000C10", "DELETE FROM dbo.[actividades_categoria]  WHERE [id_actividad_categoria] = @id_actividad_categoria", GxErrorMask.GX_NOMASK,prmT000C10)
           ,new CursorDef("T000C13", "SELECT [id_actividad_categoria] FROM dbo.[actividades_categoria] ORDER BY [id_actividad_categoria]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((int[]) buf[15])[0] = rslt.getInt(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((int[]) buf[17])[0] = rslt.getInt(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((int[]) buf[25])[0] = rslt.getInt(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((int[]) buf[27])[0] = rslt.getInt(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((int[]) buf[29])[0] = rslt.getInt(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((int[]) buf[31])[0] = rslt.getInt(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((int[]) buf[35])[0] = rslt.getInt(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((string[]) buf[37])[0] = rslt.getVarchar(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[39])[0] = rslt.getGXDate(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((int[]) buf[41])[0] = rslt.getInt(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((string[]) buf[43])[0] = rslt.getVarchar(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((int[]) buf[15])[0] = rslt.getInt(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((int[]) buf[17])[0] = rslt.getInt(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((int[]) buf[25])[0] = rslt.getInt(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((int[]) buf[27])[0] = rslt.getInt(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((int[]) buf[29])[0] = rslt.getInt(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((int[]) buf[31])[0] = rslt.getInt(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((int[]) buf[35])[0] = rslt.getInt(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((string[]) buf[37])[0] = rslt.getVarchar(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[39])[0] = rslt.getGXDate(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((int[]) buf[41])[0] = rslt.getInt(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((string[]) buf[43])[0] = rslt.getVarchar(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getVarchar(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((int[]) buf[9])[0] = rslt.getInt(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((int[]) buf[15])[0] = rslt.getInt(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              ((int[]) buf[17])[0] = rslt.getInt(10);
              ((bool[]) buf[18])[0] = rslt.wasNull(10);
              ((int[]) buf[19])[0] = rslt.getInt(11);
              ((bool[]) buf[20])[0] = rslt.wasNull(11);
              ((int[]) buf[21])[0] = rslt.getInt(12);
              ((bool[]) buf[22])[0] = rslt.wasNull(12);
              ((int[]) buf[23])[0] = rslt.getInt(13);
              ((bool[]) buf[24])[0] = rslt.wasNull(13);
              ((int[]) buf[25])[0] = rslt.getInt(14);
              ((bool[]) buf[26])[0] = rslt.wasNull(14);
              ((int[]) buf[27])[0] = rslt.getInt(15);
              ((bool[]) buf[28])[0] = rslt.wasNull(15);
              ((int[]) buf[29])[0] = rslt.getInt(16);
              ((bool[]) buf[30])[0] = rslt.wasNull(16);
              ((int[]) buf[31])[0] = rslt.getInt(17);
              ((bool[]) buf[32])[0] = rslt.wasNull(17);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(18);
              ((bool[]) buf[34])[0] = rslt.wasNull(18);
              ((int[]) buf[35])[0] = rslt.getInt(19);
              ((bool[]) buf[36])[0] = rslt.wasNull(19);
              ((string[]) buf[37])[0] = rslt.getVarchar(20);
              ((bool[]) buf[38])[0] = rslt.wasNull(20);
              ((DateTime[]) buf[39])[0] = rslt.getGXDate(21);
              ((bool[]) buf[40])[0] = rslt.wasNull(21);
              ((int[]) buf[41])[0] = rslt.getInt(22);
              ((bool[]) buf[42])[0] = rslt.wasNull(22);
              ((string[]) buf[43])[0] = rslt.getVarchar(23);
              ((bool[]) buf[44])[0] = rslt.wasNull(23);
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

public class actividades_categoria__gam : DataStoreHelperBase, IDataStoreHelper
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

public class actividades_categoria__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000C11;
       prmT000C11 = new Object[] {
       new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
       };
       Object[] prmT000C12;
       prmT000C12 = new Object[] {
       new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000C11", "SELECT TOP 1 [TicketTecnicoId] FROM [TicketTecnico] WHERE [SgActividadId] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000C12", "SELECT TOP 1 [EstadoId] FROM [Estado] WHERE [SgActividadId] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C12,1, GxCacheFrequency.OFF ,true,true )
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
