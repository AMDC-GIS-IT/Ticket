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
   public class categoriadetalletarea : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV8CategoriaDetalleTareaId = (short)(NumberUtil.Val( GetPar( "CategoriaDetalleTareaId"), "."));
               AssignAttri(sPrefix, false, "AV8CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaDetalleTareaId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV8CategoriaDetalleTareaId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
            {
               A102id_actividad_categoria = (int)(NumberUtil.Val( GetPar( "id_actividad_categoria"), "."));
               AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_12( A102id_actividad_categoria) ;
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
                  AV8CategoriaDetalleTareaId = (short)(NumberUtil.Val( GetPar( "CategoriaDetalleTareaId"), "."));
                  AssignAttri(sPrefix, false, "AV8CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaDetalleTareaId), 4, 0));
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
               Form.Meta.addItem("description", "Categoria Detalle Tarea", 0) ;
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
            GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
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

      public categoriadetalletarea( )
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

      public categoriadetalletarea( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CategoriaDetalleTareaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8CategoriaDetalleTareaId = aP1_CategoriaDetalleTareaId;
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
            return "categoriadetalletarea_Execute" ;
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
            RenderHtmlCloseForm0M23( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "categoriadetalletarea.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoriadetalletareaid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtCategoriaDetalleTareaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaDetalleTareaId_Internalname, "Id.", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtCategoriaDetalleTareaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A294CategoriaDetalleTareaId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCategoriaDetalleTareaId_Enabled!=0) ? context.localUtil.Format( (decimal)(A294CategoriaDetalleTareaId), "ZZZ9") : context.localUtil.Format( (decimal)(A294CategoriaDetalleTareaId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaDetalleTareaId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtCategoriaDetalleTareaId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_CategoriaDetalleTarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoriadetalletareanombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtCategoriaDetalleTareaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaDetalleTareaNombre_Internalname, "Tarea", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A295CategoriaDetalleTareaNombre", A295CategoriaDetalleTareaNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         ClassString = edtCategoriaDetalleTareaNombre_Class;
         StyleString = "";
         ClassString = edtCategoriaDetalleTareaNombre_Class;
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtCategoriaDetalleTareaNombre_Internalname, A295CategoriaDetalleTareaNombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", 0, 1, edtCategoriaDetalleTareaNombre_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_CategoriaDetalleTarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_actividad_categoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_actividad_categoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_actividad_categoria_Internalname, "Id. ", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_actividad_categoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A102id_actividad_categoria), "ZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_actividad_categoria_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtid_actividad_categoria_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CategoriaDetalleTarea.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_102_Internalname, sImgUrl, imgprompt_102_Link, "", "", context.GetTheme( ), imgprompt_102_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CategoriaDetalleTarea.htm");
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
         GxWebStd.gx_label_element( context, edtnombre_actividad_Internalname, "Actividad Categoría", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_actividad_Internalname, A123nombre_actividad, "", "", 0, 1, edtnombre_actividad_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_CategoriaDetalleTarea.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercategoriadetalleusuarioregistro_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtCategoriaDetalleUsuarioRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCategoriaDetalleUsuarioRegistro_Internalname, "Usuario Registro", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
         GxWebStd.gx_single_line_edit( context, edtCategoriaDetalleUsuarioRegistro_Internalname, A296CategoriaDetalleUsuarioRegistro, StringUtil.RTrim( context.localUtil.Format( A296CategoriaDetalleUsuarioRegistro, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaDetalleUsuarioRegistro_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtCategoriaDetalleUsuarioRegistro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_CategoriaDetalleTarea.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriaDetalleTarea.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_CategoriaDetalleTarea.htm");
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
         E110M2 ();
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
               Z294CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z294CategoriaDetalleTareaId"), ".", ","));
               Z295CategoriaDetalleTareaNombre = cgiGet( sPrefix+"Z295CategoriaDetalleTareaNombre");
               Z296CategoriaDetalleUsuarioRegistro = cgiGet( sPrefix+"Z296CategoriaDetalleUsuarioRegistro");
               Z102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z102id_actividad_categoria"), ".", ","));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8CategoriaDetalleTareaId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N102id_actividad_categoria"), ".", ","));
               AV8CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vCATEGORIADETALLETAREAID"), ".", ","));
               AV13Insert_id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_ID_ACTIVIDAD_CATEGORIA"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ".", ","));
               AV28Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A294CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( edtCategoriaDetalleTareaId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
               A295CategoriaDetalleTareaNombre = cgiGet( edtCategoriaDetalleTareaNombre_Internalname);
               AssignAttri(sPrefix, false, "A295CategoriaDetalleTareaNombre", A295CategoriaDetalleTareaNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_ACTIVIDAD_CATEGORIA");
                  AnyError = 1;
                  GX_FocusControl = edtid_actividad_categoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A102id_actividad_categoria = 0;
                  AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
               }
               else
               {
                  A102id_actividad_categoria = (int)(context.localUtil.CToN( cgiGet( edtid_actividad_categoria_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
               }
               A123nombre_actividad = cgiGet( edtnombre_actividad_Internalname);
               n123nombre_actividad = false;
               AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
               A296CategoriaDetalleUsuarioRegistro = cgiGet( edtCategoriaDetalleUsuarioRegistro_Internalname);
               AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"CategoriaDetalleTarea");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A294CategoriaDetalleTareaId != Z294CategoriaDetalleTareaId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("categoriadetalletarea:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A294CategoriaDetalleTareaId = (short)(NumberUtil.Val( GetPar( "CategoriaDetalleTareaId"), "."));
                  AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
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
                     sMode23 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode23;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound23 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CATEGORIADETALLETAREAID");
                        AnyError = 1;
                        GX_FocusControl = edtCategoriaDetalleTareaId_Internalname;
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
                                 E110M2 ();
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
                                 E120M2 ();
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
                                 E130M2 ();
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
            E120M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0M23( ) ;
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
            DisableAttributes0M23( ) ;
         }
         AssignProp(sPrefix, false, edtCategoriaDetalleTareaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombre_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Enabled), 5, 0), true);
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M23( ) ;
            }
            else
            {
               CheckExtendedTable0M23( ) ;
               CloseExtendedTableCursors0M23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0M0( )
      {
      }

      protected void E110M2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV18StandardActivityType = "Insert";
            AssignAttri(sPrefix, false, "AV18StandardActivityType", AV18StandardActivityType);
            AV19UserActivityType = "";
            AssignAttri(sPrefix, false, "AV19UserActivityType", AV19UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV18StandardActivityType = "Update";
            AssignAttri(sPrefix, false, "AV18StandardActivityType", AV18StandardActivityType);
            AV19UserActivityType = "";
            AssignAttri(sPrefix, false, "AV19UserActivityType", AV19UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV18StandardActivityType = "Delete";
            AssignAttri(sPrefix, false, "AV18StandardActivityType", AV18StandardActivityType);
            AV19UserActivityType = "";
            AssignAttri(sPrefix, false, "AV19UserActivityType", AV19UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV18StandardActivityType = "Display";
            AssignAttri(sPrefix, false, "AV18StandardActivityType", AV18StandardActivityType);
            AV19UserActivityType = "";
            AssignAttri(sPrefix, false, "AV19UserActivityType", AV19UserActivityType);
         }
         new k2bisauthorizedactivityname(context ).execute(  "CategoriaDetalleTarea",  "CategoriaDetalleTarea",  AV18StandardActivityType,  AV19UserActivityType,  AV28Pgmname, out  AV20IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV20IsAuthorized", AV20IsAuthorized);
         if ( ! AV20IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("CategoriaDetalleTarea")),UrlEncode(StringUtil.RTrim("CategoriaDetalleTarea")),UrlEncode(StringUtil.RTrim(AV18StandardActivityType)),UrlEncode(StringUtil.RTrim(AV19UserActivityType)),UrlEncode(StringUtil.RTrim(AV28Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
         new k2bgetcontext(context ).execute( out  AV14Context) ;
         AV15BtnCaption = "Confirmar";
         AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
         AV16BtnTooltip = "Confirmar";
         AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV15BtnCaption = "Actualizar";
            AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
            AV16BtnTooltip = "Actualizar";
            AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV15BtnCaption = "Confirmar";
            AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
            AV16BtnTooltip = "Confirmar";
            AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV15BtnCaption = "Eliminar";
            AssignAttri(sPrefix, false, "AV15BtnCaption", AV15BtnCaption);
            AV16BtnTooltip = "Eliminar";
            AssignAttri(sPrefix, false, "AV16BtnTooltip", AV16BtnTooltip);
         }
         bttEnter_Caption = AV15BtnCaption;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Caption", bttEnter_Caption, true);
         bttEnter_Tooltiptext = AV16BtnTooltip;
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
         new k2bgettrncontextbyname(context ).execute(  "CategoriaDetalleTarea", out  AV9TrnContext) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Categoria Detalle Tarea", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Categoria Detalle Tarea", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Categoria Detalle Tarea", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV29GXV1 = 1;
            AssignAttri(sPrefix, false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            while ( AV29GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV10TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV29GXV1));
               if ( StringUtil.StrCmp(AV10TrnContextAtt.gxTpr_Attributename, "id_actividad_categoria") == 0 )
               {
                  AV13Insert_id_actividad_categoria = (int)(NumberUtil.Val( AV10TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV13Insert_id_actividad_categoria", StringUtil.LTrimStr( (decimal)(AV13Insert_id_actividad_categoria), 9, 0));
               }
               AV29GXV1 = (int)(AV29GXV1+1);
               AssignAttri(sPrefix, false, "AV29GXV1", StringUtil.LTrimStr( (decimal)(AV29GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(AV26HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtCategoriaDetalleTareaNombre_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtCategoriaDetalleTareaNombre_Internalname, "Class", edtCategoriaDetalleTareaNombre_Class, true);
            }
            else
            {
               edtCategoriaDetalleTareaNombre_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtCategoriaDetalleTareaNombre_Internalname, "Class", edtCategoriaDetalleTareaNombre_Class, true);
            }
         }
      }

      protected void E120M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV9TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV23AttributeValueItem.gxTpr_Attributename = "CategoriaDetalleTareaId";
            AV23AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A294CategoriaDetalleTareaId), 4, 0);
            AV22AttributeValue.Add(AV23AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "CategoriaDetalleTarea",  AV22AttributeValue) ;
         }
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La categoria detalle tarea %1 fue creada", A295CategoriaDetalleTareaNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La categoria detalle tarea %1 fue actualizada", A295CategoriaDetalleTareaNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La categoria detalle tarea %1 fue eliminada", A295CategoriaDetalleTareaNombre, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV24Message) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"CategoriaDetalleTarea",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV22AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV9TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV9TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "CategoriaDetalleTarea") ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AttributeValue", AV22AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11Navigation", AV11Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9TrnContext", AV9TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV21encrypt = AV9TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21encrypt)) )
         {
            GXt_char1 = AV21encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV21encrypt = GXt_char1;
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
               if ( StringUtil.StrCmp(AV21encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A294CategoriaDetalleTareaId,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A294CategoriaDetalleTareaId = (short)(args[2]) ;
                        AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV21encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A294CategoriaDetalleTareaId,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A294CategoriaDetalleTareaId = (short)(args[2]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A294CategoriaDetalleTareaId,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A294CategoriaDetalleTareaId = (short)(args[1]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
               if ( StringUtil.StrCmp(AV21encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV11Navigation.gxTpr_Mode,(short)A294CategoriaDetalleTareaId,AV11Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A294CategoriaDetalleTareaId = (short)(args[2]) ;
                        AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV21encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV11Navigation.gxTpr_Mode,(short)A294CategoriaDetalleTareaId,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A294CategoriaDetalleTareaId = (short)(args[2]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV11Navigation.gxTpr_Mode,(short)A294CategoriaDetalleTareaId,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A294CategoriaDetalleTareaId = (short)(args[1]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A294CategoriaDetalleTareaId,4,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130M2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "CategoriaDetalleTarea") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"CategoriaDetalleTarea"}, true);
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
            AV17Url = AV9TrnContext.gxTpr_Callerurl;
            CallWebObject(formatLink(AV17Url) );
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

      protected void ZM0M23( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z295CategoriaDetalleTareaNombre = T000M3_A295CategoriaDetalleTareaNombre[0];
               Z296CategoriaDetalleUsuarioRegistro = T000M3_A296CategoriaDetalleUsuarioRegistro[0];
               Z102id_actividad_categoria = T000M3_A102id_actividad_categoria[0];
            }
            else
            {
               Z295CategoriaDetalleTareaNombre = A295CategoriaDetalleTareaNombre;
               Z296CategoriaDetalleUsuarioRegistro = A296CategoriaDetalleUsuarioRegistro;
               Z102id_actividad_categoria = A102id_actividad_categoria;
            }
         }
         if ( GX_JID == -11 )
         {
            Z294CategoriaDetalleTareaId = A294CategoriaDetalleTareaId;
            Z295CategoriaDetalleTareaNombre = A295CategoriaDetalleTareaNombre;
            Z296CategoriaDetalleUsuarioRegistro = A296CategoriaDetalleUsuarioRegistro;
            Z102id_actividad_categoria = A102id_actividad_categoria;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCategoriaDetalleTareaId_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleTareaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaId_Enabled), 5, 0), true);
         edtCategoriaDetalleUsuarioRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleUsuarioRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleUsuarioRegistro_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_102_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptactividades_categoria.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"ID_ACTIVIDAD_CATEGORIA"+"'), id:'"+sPrefix+"ID_ACTIVIDAD_CATEGORIA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtCategoriaDetalleTareaId_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleTareaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaId_Enabled), 5, 0), true);
         edtCategoriaDetalleUsuarioRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleUsuarioRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleUsuarioRegistro_Enabled), 5, 0), true);
         if ( ! (0==AV8CategoriaDetalleTareaId) )
         {
            A294CategoriaDetalleTareaId = AV8CategoriaDetalleTareaId;
            AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_id_actividad_categoria) )
         {
            edtid_actividad_categoria_Enabled = 0;
            AssignProp(sPrefix, false, edtid_actividad_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Enabled), 5, 0), true);
         }
         else
         {
            edtid_actividad_categoria_Enabled = 1;
            AssignProp(sPrefix, false, edtid_actividad_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_id_actividad_categoria) )
         {
            A102id_actividad_categoria = AV13Insert_id_actividad_categoria;
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         }
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A296CategoriaDetalleUsuarioRegistro)) && ( Gx_BScreen == 0 ) )
         {
            A296CategoriaDetalleUsuarioRegistro = AV7WebSession.Get("UsuarioConectado");
            AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV28Pgmname = "CategoriaDetalleTarea";
            AssignAttri(sPrefix, false, "AV28Pgmname", AV28Pgmname);
            /* Using cursor T000M4 */
            pr_datastore1.execute(0, new Object[] {A102id_actividad_categoria});
            A123nombre_actividad = T000M4_A123nombre_actividad[0];
            n123nombre_actividad = T000M4_n123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
            pr_datastore1.close(0);
         }
      }

      protected void Load0M23( )
      {
         /* Using cursor T000M5 */
         pr_default.execute(2, new Object[] {A294CategoriaDetalleTareaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A295CategoriaDetalleTareaNombre = T000M5_A295CategoriaDetalleTareaNombre[0];
            AssignAttri(sPrefix, false, "A295CategoriaDetalleTareaNombre", A295CategoriaDetalleTareaNombre);
            A296CategoriaDetalleUsuarioRegistro = T000M5_A296CategoriaDetalleUsuarioRegistro[0];
            AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
            A102id_actividad_categoria = T000M5_A102id_actividad_categoria[0];
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
            ZM0M23( -11) ;
         }
         pr_default.close(2);
         OnLoadActions0M23( ) ;
      }

      protected void OnLoadActions0M23( )
      {
         AV28Pgmname = "CategoriaDetalleTarea";
         AssignAttri(sPrefix, false, "AV28Pgmname", AV28Pgmname);
         /* Using cursor T000M4 */
         pr_datastore1.execute(0, new Object[] {A102id_actividad_categoria});
         A123nombre_actividad = T000M4_A123nombre_actividad[0];
         n123nombre_actividad = T000M4_n123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         pr_datastore1.close(0);
      }

      protected void CheckExtendedTable0M23( )
      {
         nIsDirty_23 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV28Pgmname = "CategoriaDetalleTarea";
         AssignAttri(sPrefix, false, "AV28Pgmname", AV28Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A295CategoriaDetalleTareaNombre)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Tarea", "", "", "", "", "", "", "", ""), 1, "CATEGORIADETALLETAREANOMBRE");
            AnyError = 1;
            GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000M4 */
         pr_datastore1.execute(0, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(0) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "ID_ACTIVIDAD_CATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtid_actividad_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A123nombre_actividad = T000M4_A123nombre_actividad[0];
         n123nombre_actividad = T000M4_n123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         pr_datastore1.close(0);
      }

      protected void CloseExtendedTableCursors0M23( )
      {
         pr_datastore1.close(0);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( int A102id_actividad_categoria )
      {
         /* Using cursor T000M6 */
         pr_datastore1.execute(1, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "ID_ACTIVIDAD_CATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtid_actividad_categoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A123nombre_actividad = T000M6_A123nombre_actividad[0];
         n123nombre_actividad = T000M6_n123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A123nombre_actividad)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(1);
      }

      protected void GetKey0M23( )
      {
         /* Using cursor T000M7 */
         pr_default.execute(3, new Object[] {A294CategoriaDetalleTareaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A294CategoriaDetalleTareaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M23( 11) ;
            RcdFound23 = 1;
            A294CategoriaDetalleTareaId = T000M3_A294CategoriaDetalleTareaId[0];
            AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
            A295CategoriaDetalleTareaNombre = T000M3_A295CategoriaDetalleTareaNombre[0];
            AssignAttri(sPrefix, false, "A295CategoriaDetalleTareaNombre", A295CategoriaDetalleTareaNombre);
            A296CategoriaDetalleUsuarioRegistro = T000M3_A296CategoriaDetalleUsuarioRegistro[0];
            AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
            A102id_actividad_categoria = T000M3_A102id_actividad_categoria[0];
            AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
            Z294CategoriaDetalleTareaId = A294CategoriaDetalleTareaId;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0M23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0M23( ) ;
            }
            Gx_mode = sMode23;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0M23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode23;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M23( ) ;
         if ( RcdFound23 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound23 = 0;
         /* Using cursor T000M8 */
         pr_default.execute(4, new Object[] {A294CategoriaDetalleTareaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000M8_A294CategoriaDetalleTareaId[0] < A294CategoriaDetalleTareaId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000M8_A294CategoriaDetalleTareaId[0] > A294CategoriaDetalleTareaId ) ) )
            {
               A294CategoriaDetalleTareaId = T000M8_A294CategoriaDetalleTareaId[0];
               AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound23 = 0;
         /* Using cursor T000M9 */
         pr_default.execute(5, new Object[] {A294CategoriaDetalleTareaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000M9_A294CategoriaDetalleTareaId[0] > A294CategoriaDetalleTareaId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000M9_A294CategoriaDetalleTareaId[0] < A294CategoriaDetalleTareaId ) ) )
            {
               A294CategoriaDetalleTareaId = T000M9_A294CategoriaDetalleTareaId[0];
               AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0M23( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( A294CategoriaDetalleTareaId != Z294CategoriaDetalleTareaId )
               {
                  A294CategoriaDetalleTareaId = Z294CategoriaDetalleTareaId;
                  AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CATEGORIADETALLETAREAID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoriaDetalleTareaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0M23( ) ;
                  GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A294CategoriaDetalleTareaId != Z294CategoriaDetalleTareaId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0M23( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CATEGORIADETALLETAREAID");
                     AnyError = 1;
                     GX_FocusControl = edtCategoriaDetalleTareaId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0M23( ) ;
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
         if ( A294CategoriaDetalleTareaId != Z294CategoriaDetalleTareaId )
         {
            A294CategoriaDetalleTareaId = Z294CategoriaDetalleTareaId;
            AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CATEGORIADETALLETAREAID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaDetalleTareaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCategoriaDetalleTareaNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0M23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A294CategoriaDetalleTareaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CategoriaDetalleTarea"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z295CategoriaDetalleTareaNombre, T000M2_A295CategoriaDetalleTareaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z296CategoriaDetalleUsuarioRegistro, T000M2_A296CategoriaDetalleUsuarioRegistro[0]) != 0 ) || ( Z102id_actividad_categoria != T000M2_A102id_actividad_categoria[0] ) )
            {
               if ( StringUtil.StrCmp(Z295CategoriaDetalleTareaNombre, T000M2_A295CategoriaDetalleTareaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("categoriadetalletarea:[seudo value changed for attri]"+"CategoriaDetalleTareaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z295CategoriaDetalleTareaNombre);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A295CategoriaDetalleTareaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z296CategoriaDetalleUsuarioRegistro, T000M2_A296CategoriaDetalleUsuarioRegistro[0]) != 0 )
               {
                  GXUtil.WriteLog("categoriadetalletarea:[seudo value changed for attri]"+"CategoriaDetalleUsuarioRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z296CategoriaDetalleUsuarioRegistro);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A296CategoriaDetalleUsuarioRegistro[0]);
               }
               if ( Z102id_actividad_categoria != T000M2_A102id_actividad_categoria[0] )
               {
                  GXUtil.WriteLog("categoriadetalletarea:[seudo value changed for attri]"+"id_actividad_categoria");
                  GXUtil.WriteLogRaw("Old: ",Z102id_actividad_categoria);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A102id_actividad_categoria[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CategoriaDetalleTarea"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M23( )
      {
         if ( ! IsAuthorized("categoriadetalletarea_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M23( 0) ;
            CheckOptimisticConcurrency0M23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M10 */
                     pr_default.execute(6, new Object[] {A295CategoriaDetalleTareaNombre, A296CategoriaDetalleUsuarioRegistro, A102id_actividad_categoria});
                     A294CategoriaDetalleTareaId = T000M10_A294CategoriaDetalleTareaId[0];
                     AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CategoriaDetalleTarea");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0M0( ) ;
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
               Load0M23( ) ;
            }
            EndLevel0M23( ) ;
         }
         CloseExtendedTableCursors0M23( ) ;
      }

      protected void Update0M23( )
      {
         if ( ! IsAuthorized("categoriadetalletarea_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M11 */
                     pr_default.execute(7, new Object[] {A295CategoriaDetalleTareaNombre, A296CategoriaDetalleUsuarioRegistro, A102id_actividad_categoria, A294CategoriaDetalleTareaId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CategoriaDetalleTarea");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CategoriaDetalleTarea"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M23( ) ;
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
            EndLevel0M23( ) ;
         }
         CloseExtendedTableCursors0M23( ) ;
      }

      protected void DeferredUpdate0M23( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("categoriadetalletarea_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M23( ) ;
            AfterConfirm0M23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M12 */
                  pr_default.execute(8, new Object[] {A294CategoriaDetalleTareaId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CategoriaDetalleTarea");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0M23( ) ;
         Gx_mode = sMode23;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M23( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV28Pgmname = "CategoriaDetalleTarea";
            AssignAttri(sPrefix, false, "AV28Pgmname", AV28Pgmname);
            /* Using cursor T000M13 */
            pr_datastore1.execute(2, new Object[] {A102id_actividad_categoria});
            A123nombre_actividad = T000M13_A123nombre_actividad[0];
            n123nombre_actividad = T000M13_n123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
            pr_datastore1.close(2);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000M14 */
            pr_default.execute(9, new Object[] {A294CategoriaDetalleTareaId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Responsable"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0M23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M23( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_datastore1.close(2);
            context.CommitDataStores("categoriadetalletarea",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_datastore1.close(2);
            context.RollbackDataStores("categoriadetalletarea",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M23( )
      {
         /* Scan By routine */
         /* Using cursor T000M15 */
         pr_default.execute(10);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound23 = 1;
            A294CategoriaDetalleTareaId = T000M15_A294CategoriaDetalleTareaId[0];
            AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M23( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound23 = 1;
            A294CategoriaDetalleTareaId = T000M15_A294CategoriaDetalleTareaId[0];
            AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
         }
      }

      protected void ScanEnd0M23( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0M23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M23( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0M23( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0M23( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0M23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M23( )
      {
         edtCategoriaDetalleTareaId_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleTareaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaId_Enabled), 5, 0), true);
         edtCategoriaDetalleTareaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleTareaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleTareaNombre_Enabled), 5, 0), true);
         edtid_actividad_categoria_Enabled = 0;
         AssignProp(sPrefix, false, edtid_actividad_categoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_actividad_categoria_Enabled), 5, 0), true);
         edtnombre_actividad_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_actividad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_actividad_Enabled), 5, 0), true);
         edtCategoriaDetalleUsuarioRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtCategoriaDetalleUsuarioRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaDetalleUsuarioRegistro_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0M23( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0M0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188314454", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("categoriadetalletarea.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8CategoriaDetalleTareaId,4,0))}, new string[] {"Gx_mode","CategoriaDetalleTareaId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"CategoriaDetalleTarea");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("categoriadetalletarea:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z294CategoriaDetalleTareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z294CategoriaDetalleTareaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z295CategoriaDetalleTareaNombre", Z295CategoriaDetalleTareaNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z296CategoriaDetalleUsuarioRegistro", Z296CategoriaDetalleUsuarioRegistro);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z102id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z102id_actividad_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8CategoriaDetalleTareaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8CategoriaDetalleTareaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N102id_actividad_categoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(A102id_actividad_categoria), 9, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV22AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV22AttributeValue);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vATTRIBUTEVALUE", GetSecureSignedToken( sPrefix, AV22AttributeValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV11Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV11Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV11Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCATEGORIADETALLETAREAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CategoriaDetalleTareaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_ID_ACTIVIDAD_CATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_id_actividad_categoria), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV28Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0M23( )
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
         return "CategoriaDetalleTarea" ;
      }

      public override string GetPgmdesc( )
      {
         return "Categoria Detalle Tarea" ;
      }

      protected void InitializeNonKey0M23( )
      {
         A102id_actividad_categoria = 0;
         AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         A295CategoriaDetalleTareaNombre = "";
         AssignAttri(sPrefix, false, "A295CategoriaDetalleTareaNombre", A295CategoriaDetalleTareaNombre);
         A123nombre_actividad = "";
         n123nombre_actividad = false;
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
         A296CategoriaDetalleUsuarioRegistro = AV7WebSession.Get("UsuarioConectado");
         AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
         Z295CategoriaDetalleTareaNombre = "";
         Z296CategoriaDetalleUsuarioRegistro = "";
         Z102id_actividad_categoria = 0;
      }

      protected void InitAll0M23( )
      {
         A294CategoriaDetalleTareaId = 0;
         AssignAttri(sPrefix, false, "A294CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(A294CategoriaDetalleTareaId), 4, 0));
         InitializeNonKey0M23( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A296CategoriaDetalleUsuarioRegistro = i296CategoriaDetalleUsuarioRegistro;
         AssignAttri(sPrefix, false, "A296CategoriaDetalleUsuarioRegistro", A296CategoriaDetalleUsuarioRegistro);
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV8CategoriaDetalleTareaId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "categoriadetalletarea", GetJustCreated( ));
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
            AV8CategoriaDetalleTareaId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaDetalleTareaId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8CategoriaDetalleTareaId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8CategoriaDetalleTareaId != wcpOAV8CategoriaDetalleTareaId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8CategoriaDetalleTareaId = AV8CategoriaDetalleTareaId;
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
         sCtrlAV8CategoriaDetalleTareaId = cgiGet( sPrefix+"AV8CategoriaDetalleTareaId_CTRL");
         if ( StringUtil.Len( sCtrlAV8CategoriaDetalleTareaId) > 0 )
         {
            AV8CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV8CategoriaDetalleTareaId), ".", ","));
            AssignAttri(sPrefix, false, "AV8CategoriaDetalleTareaId", StringUtil.LTrimStr( (decimal)(AV8CategoriaDetalleTareaId), 4, 0));
         }
         else
         {
            AV8CategoriaDetalleTareaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV8CategoriaDetalleTareaId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8CategoriaDetalleTareaId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8CategoriaDetalleTareaId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8CategoriaDetalleTareaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8CategoriaDetalleTareaId_CTRL", StringUtil.RTrim( sCtrlAV8CategoriaDetalleTareaId));
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188314473", true, true);
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
         context.AddJavascriptSource("categoriadetalletarea.js", "?2024188314473", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtCategoriaDetalleTareaId_Internalname = sPrefix+"CATEGORIADETALLETAREAID";
         divK2btoolstable_attributecontainercategoriadetalletareaid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIADETALLETAREAID";
         edtCategoriaDetalleTareaNombre_Internalname = sPrefix+"CATEGORIADETALLETAREANOMBRE";
         divK2btoolstable_attributecontainercategoriadetalletareanombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIADETALLETAREANOMBRE";
         edtid_actividad_categoria_Internalname = sPrefix+"ID_ACTIVIDAD_CATEGORIA";
         divK2btoolstable_attributecontainerid_actividad_categoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_ACTIVIDAD_CATEGORIA";
         edtnombre_actividad_Internalname = sPrefix+"NOMBRE_ACTIVIDAD";
         divK2btoolstable_attributecontainernombre_actividad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_ACTIVIDAD";
         edtCategoriaDetalleUsuarioRegistro_Internalname = sPrefix+"CATEGORIADETALLEUSUARIOREGISTRO";
         divK2btoolstable_attributecontainercategoriadetalleusuarioregistro_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCATEGORIADETALLEUSUARIOREGISTRO";
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
         imgprompt_102_Internalname = sPrefix+"PROMPT_102";
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
         Form.Caption = "Categoria Detalle Tarea";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtCategoriaDetalleUsuarioRegistro_Jsonclick = "";
         edtCategoriaDetalleUsuarioRegistro_Enabled = 0;
         edtnombre_actividad_Enabled = 0;
         imgprompt_102_Visible = 1;
         imgprompt_102_Link = "";
         edtid_actividad_categoria_Jsonclick = "";
         edtid_actividad_categoria_Enabled = 1;
         edtCategoriaDetalleTareaNombre_Class = "Attribute_Trn Attribute_Required";
         edtCategoriaDetalleTareaNombre_Enabled = 1;
         edtCategoriaDetalleTareaId_Jsonclick = "";
         edtCategoriaDetalleTareaId_Enabled = 0;
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

      public void Valid_Id_actividad_categoria( )
      {
         n123nombre_actividad = false;
         /* Using cursor T000M13 */
         pr_datastore1.execute(2, new Object[] {A102id_actividad_categoria});
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "ID_ACTIVIDAD_CATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtid_actividad_categoria_Internalname;
         }
         A123nombre_actividad = T000M13_A123nombre_actividad[0];
         n123nombre_actividad = T000M13_n123nombre_actividad[0];
         pr_datastore1.close(2);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A123nombre_actividad", A123nombre_actividad);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8CategoriaDetalleTareaId',fld:'vCATEGORIADETALLETAREAID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120M2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A294CategoriaDetalleTareaId',fld:'CATEGORIADETALLETAREAID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A295CategoriaDetalleTareaNombre',fld:'CATEGORIADETALLETAREANOMBRE',pic:''},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A294CategoriaDetalleTareaId',fld:'CATEGORIADETALLETAREAID',pic:'ZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130M2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIADETALLETAREAID","{handler:'Valid_Categoriadetalletareaid',iparms:[]");
         setEventMetadata("VALID_CATEGORIADETALLETAREAID",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIADETALLETAREANOMBRE","{handler:'Valid_Categoriadetalletareanombre',iparms:[]");
         setEventMetadata("VALID_CATEGORIADETALLETAREANOMBRE",",oparms:[]}");
         setEventMetadata("VALID_ID_ACTIVIDAD_CATEGORIA","{handler:'Valid_Id_actividad_categoria',iparms:[{av:'A102id_actividad_categoria',fld:'ID_ACTIVIDAD_CATEGORIA',pic:'ZZZZZZZZ9'},{av:'A123nombre_actividad',fld:'NOMBRE_ACTIVIDAD',pic:''}]");
         setEventMetadata("VALID_ID_ACTIVIDAD_CATEGORIA",",oparms:[{av:'A123nombre_actividad',fld:'NOMBRE_ACTIVIDAD',pic:''}]}");
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
         pr_datastore1.close(2);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z295CategoriaDetalleTareaNombre = "";
         Z296CategoriaDetalleUsuarioRegistro = "";
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
         A295CategoriaDetalleTareaNombre = "";
         TempTags = "";
         sImgUrl = "";
         A123nombre_actividad = "";
         A296CategoriaDetalleUsuarioRegistro = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV28Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode23 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV18StandardActivityType = "";
         AV19UserActivityType = "";
         AV14Context = new SdtK2BContext(context);
         AV15BtnCaption = "";
         AV16BtnTooltip = "";
         AV9TrnContext = new SdtK2BTrnContext(context);
         AV10TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV26HttpRequest = new GxHttpRequest( context);
         AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV11Navigation = new SdtK2BTrnNavigation(context);
         AV21encrypt = "";
         GXt_char1 = "";
         AV12DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV17Url = "";
         AV7WebSession = context.GetSession();
         T000M4_A123nombre_actividad = new string[] {""} ;
         T000M4_n123nombre_actividad = new bool[] {false} ;
         T000M5_A294CategoriaDetalleTareaId = new short[1] ;
         T000M5_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         T000M5_A296CategoriaDetalleUsuarioRegistro = new string[] {""} ;
         T000M5_A102id_actividad_categoria = new int[1] ;
         T000M6_A123nombre_actividad = new string[] {""} ;
         T000M6_n123nombre_actividad = new bool[] {false} ;
         T000M7_A294CategoriaDetalleTareaId = new short[1] ;
         T000M3_A294CategoriaDetalleTareaId = new short[1] ;
         T000M3_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         T000M3_A296CategoriaDetalleUsuarioRegistro = new string[] {""} ;
         T000M3_A102id_actividad_categoria = new int[1] ;
         T000M8_A294CategoriaDetalleTareaId = new short[1] ;
         T000M9_A294CategoriaDetalleTareaId = new short[1] ;
         T000M2_A294CategoriaDetalleTareaId = new short[1] ;
         T000M2_A295CategoriaDetalleTareaNombre = new string[] {""} ;
         T000M2_A296CategoriaDetalleUsuarioRegistro = new string[] {""} ;
         T000M2_A102id_actividad_categoria = new int[1] ;
         T000M10_A294CategoriaDetalleTareaId = new short[1] ;
         T000M13_A123nombre_actividad = new string[] {""} ;
         T000M13_n123nombre_actividad = new bool[] {false} ;
         T000M14_A14TicketId = new long[1] ;
         T000M14_A16TicketResponsableId = new long[1] ;
         T000M15_A294CategoriaDetalleTareaId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i296CategoriaDetalleUsuarioRegistro = "";
         sCtrlGx_mode = "";
         sCtrlAV8CategoriaDetalleTareaId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Z123nombre_actividad = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.categoriadetalletarea__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.categoriadetalletarea__datastore1(),
            new Object[][] {
                new Object[] {
               T000M4_A123nombre_actividad, T000M4_n123nombre_actividad
               }
               , new Object[] {
               T000M6_A123nombre_actividad, T000M6_n123nombre_actividad
               }
               , new Object[] {
               T000M13_A123nombre_actividad, T000M13_n123nombre_actividad
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.categoriadetalletarea__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.categoriadetalletarea__default(),
            new Object[][] {
                new Object[] {
               T000M2_A294CategoriaDetalleTareaId, T000M2_A295CategoriaDetalleTareaNombre, T000M2_A296CategoriaDetalleUsuarioRegistro, T000M2_A102id_actividad_categoria
               }
               , new Object[] {
               T000M3_A294CategoriaDetalleTareaId, T000M3_A295CategoriaDetalleTareaNombre, T000M3_A296CategoriaDetalleUsuarioRegistro, T000M3_A102id_actividad_categoria
               }
               , new Object[] {
               T000M5_A294CategoriaDetalleTareaId, T000M5_A295CategoriaDetalleTareaNombre, T000M5_A296CategoriaDetalleUsuarioRegistro, T000M5_A102id_actividad_categoria
               }
               , new Object[] {
               T000M7_A294CategoriaDetalleTareaId
               }
               , new Object[] {
               T000M8_A294CategoriaDetalleTareaId
               }
               , new Object[] {
               T000M9_A294CategoriaDetalleTareaId
               }
               , new Object[] {
               T000M10_A294CategoriaDetalleTareaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M14_A14TicketId, T000M14_A16TicketResponsableId
               }
               , new Object[] {
               T000M15_A294CategoriaDetalleTareaId
               }
            }
         );
         AV28Pgmname = "CategoriaDetalleTarea";
         Z296CategoriaDetalleUsuarioRegistro = AV7WebSession.Get("UsuarioConectado");
         A296CategoriaDetalleUsuarioRegistro = AV7WebSession.Get("UsuarioConectado");
         i296CategoriaDetalleUsuarioRegistro = AV7WebSession.Get("UsuarioConectado");
      }

      private short wcpOAV8CategoriaDetalleTareaId ;
      private short Z294CategoriaDetalleTareaId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV8CategoriaDetalleTareaId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A294CategoriaDetalleTareaId ;
      private short nDraw ;
      private short nDoneStart ;
      private short Gx_BScreen ;
      private short RcdFound23 ;
      private short GX_JID ;
      private short nIsDirty_23 ;
      private int Z102id_actividad_categoria ;
      private int N102id_actividad_categoria ;
      private int A102id_actividad_categoria ;
      private int trnEnded ;
      private int edtCategoriaDetalleTareaId_Enabled ;
      private int edtCategoriaDetalleTareaNombre_Enabled ;
      private int edtid_actividad_categoria_Enabled ;
      private int imgprompt_102_Visible ;
      private int edtnombre_actividad_Enabled ;
      private int edtCategoriaDetalleUsuarioRegistro_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int AV13Insert_id_actividad_categoria ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV29GXV1 ;
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
      private string edtCategoriaDetalleTareaNombre_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainercategoriadetalletareaid_Internalname ;
      private string edtCategoriaDetalleTareaId_Internalname ;
      private string edtCategoriaDetalleTareaId_Jsonclick ;
      private string divK2btoolstable_attributecontainercategoriadetalletareanombre_Internalname ;
      private string TempTags ;
      private string edtCategoriaDetalleTareaNombre_Class ;
      private string divK2btoolstable_attributecontainerid_actividad_categoria_Internalname ;
      private string edtid_actividad_categoria_Internalname ;
      private string edtid_actividad_categoria_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_102_Internalname ;
      private string imgprompt_102_Link ;
      private string divK2btoolstable_attributecontainernombre_actividad_Internalname ;
      private string edtnombre_actividad_Internalname ;
      private string divK2btoolstable_attributecontainercategoriadetalleusuarioregistro_Internalname ;
      private string edtCategoriaDetalleUsuarioRegistro_Internalname ;
      private string edtCategoriaDetalleUsuarioRegistro_Jsonclick ;
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
      private string AV28Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode23 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV18StandardActivityType ;
      private string AV15BtnCaption ;
      private string AV16BtnTooltip ;
      private string AV21encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV8CategoriaDetalleTareaId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool n123nombre_actividad ;
      private bool returnInSub ;
      private bool AV20IsAuthorized ;
      private string Z295CategoriaDetalleTareaNombre ;
      private string Z296CategoriaDetalleUsuarioRegistro ;
      private string A295CategoriaDetalleTareaNombre ;
      private string A123nombre_actividad ;
      private string A296CategoriaDetalleUsuarioRegistro ;
      private string AV19UserActivityType ;
      private string AV12DinamicObjToLink ;
      private string AV17Url ;
      private string i296CategoriaDetalleUsuarioRegistro ;
      private string Z123nombre_actividad ;
      private IGxSession AV7WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] T000M4_A123nombre_actividad ;
      private bool[] T000M4_n123nombre_actividad ;
      private IDataStoreProvider pr_default ;
      private short[] T000M5_A294CategoriaDetalleTareaId ;
      private string[] T000M5_A295CategoriaDetalleTareaNombre ;
      private string[] T000M5_A296CategoriaDetalleUsuarioRegistro ;
      private int[] T000M5_A102id_actividad_categoria ;
      private string[] T000M6_A123nombre_actividad ;
      private bool[] T000M6_n123nombre_actividad ;
      private short[] T000M7_A294CategoriaDetalleTareaId ;
      private short[] T000M3_A294CategoriaDetalleTareaId ;
      private string[] T000M3_A295CategoriaDetalleTareaNombre ;
      private string[] T000M3_A296CategoriaDetalleUsuarioRegistro ;
      private int[] T000M3_A102id_actividad_categoria ;
      private short[] T000M8_A294CategoriaDetalleTareaId ;
      private short[] T000M9_A294CategoriaDetalleTareaId ;
      private short[] T000M2_A294CategoriaDetalleTareaId ;
      private string[] T000M2_A295CategoriaDetalleTareaNombre ;
      private string[] T000M2_A296CategoriaDetalleUsuarioRegistro ;
      private int[] T000M2_A102id_actividad_categoria ;
      private short[] T000M10_A294CategoriaDetalleTareaId ;
      private string[] T000M13_A123nombre_actividad ;
      private bool[] T000M13_n123nombre_actividad ;
      private long[] T000M14_A14TicketId ;
      private long[] T000M14_A16TicketResponsableId ;
      private short[] T000M15_A294CategoriaDetalleTareaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV26HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV22AttributeValue ;
      private SdtK2BTrnContext AV9TrnContext ;
      private SdtK2BTrnContext_Attribute AV10TrnContextAtt ;
      private SdtK2BTrnNavigation AV11Navigation ;
      private SdtK2BContext AV14Context ;
      private SdtK2BAttributeValue_Item AV23AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV24Message ;
   }

   public class categoriadetalletarea__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class categoriadetalletarea__datastore1 : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000M4;
        prmT000M4 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000M6;
        prmT000M6 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        Object[] prmT000M13;
        prmT000M13 = new Object[] {
        new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000M4", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M6", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M13", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @id_actividad_categoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M13,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
     }
  }

  public override string getDataStoreName( )
  {
     return "DATASTORE1";
  }

}

public class categoriadetalletarea__gam : DataStoreHelperBase, IDataStoreHelper
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

public class categoriadetalletarea__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[10])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000M5;
       prmT000M5 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M7;
       prmT000M7 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M3;
       prmT000M3 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M8;
       prmT000M8 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M9;
       prmT000M9 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M2;
       prmT000M2 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M10;
       prmT000M10 = new Object[] {
       new ParDef("@CategoriaDetalleTareaNombre",GXType.NVarChar,300,0) ,
       new ParDef("@CategoriaDetalleUsuarioRegistro",GXType.NVarChar,100,60) ,
       new ParDef("@id_actividad_categoria",GXType.Int32,9,0)
       };
       Object[] prmT000M11;
       prmT000M11 = new Object[] {
       new ParDef("@CategoriaDetalleTareaNombre",GXType.NVarChar,300,0) ,
       new ParDef("@CategoriaDetalleUsuarioRegistro",GXType.NVarChar,100,60) ,
       new ParDef("@id_actividad_categoria",GXType.Int32,9,0) ,
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M12;
       prmT000M12 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M14;
       prmT000M14 = new Object[] {
       new ParDef("@CategoriaDetalleTareaId",GXType.Int16,4,0)
       };
       Object[] prmT000M15;
       prmT000M15 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000M2", "SELECT [CategoriaDetalleTareaId], [CategoriaDetalleTareaNombre], [CategoriaDetalleUsuarioRegistro], [id_actividad_categoria] FROM [CategoriaDetalleTarea] WITH (UPDLOCK) WHERE [CategoriaDetalleTareaId] = @CategoriaDetalleTareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000M3", "SELECT [CategoriaDetalleTareaId], [CategoriaDetalleTareaNombre], [CategoriaDetalleUsuarioRegistro], [id_actividad_categoria] FROM [CategoriaDetalleTarea] WHERE [CategoriaDetalleTareaId] = @CategoriaDetalleTareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000M5", "SELECT TM1.[CategoriaDetalleTareaId], TM1.[CategoriaDetalleTareaNombre], TM1.[CategoriaDetalleUsuarioRegistro], TM1.[id_actividad_categoria] FROM [CategoriaDetalleTarea] TM1 WHERE TM1.[CategoriaDetalleTareaId] = @CategoriaDetalleTareaId ORDER BY TM1.[CategoriaDetalleTareaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000M7", "SELECT [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea] WHERE [CategoriaDetalleTareaId] = @CategoriaDetalleTareaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000M8", "SELECT TOP 1 [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea] WHERE ( [CategoriaDetalleTareaId] > @CategoriaDetalleTareaId) ORDER BY [CategoriaDetalleTareaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000M9", "SELECT TOP 1 [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea] WHERE ( [CategoriaDetalleTareaId] < @CategoriaDetalleTareaId) ORDER BY [CategoriaDetalleTareaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000M10", "INSERT INTO [CategoriaDetalleTarea]([CategoriaDetalleTareaNombre], [CategoriaDetalleUsuarioRegistro], [id_actividad_categoria]) VALUES(@CategoriaDetalleTareaNombre, @CategoriaDetalleUsuarioRegistro, @id_actividad_categoria); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000M10)
          ,new CursorDef("T000M11", "UPDATE [CategoriaDetalleTarea] SET [CategoriaDetalleTareaNombre]=@CategoriaDetalleTareaNombre, [CategoriaDetalleUsuarioRegistro]=@CategoriaDetalleUsuarioRegistro, [id_actividad_categoria]=@id_actividad_categoria  WHERE [CategoriaDetalleTareaId] = @CategoriaDetalleTareaId", GxErrorMask.GX_NOMASK,prmT000M11)
          ,new CursorDef("T000M12", "DELETE FROM [CategoriaDetalleTarea]  WHERE [CategoriaDetalleTareaId] = @CategoriaDetalleTareaId", GxErrorMask.GX_NOMASK,prmT000M12)
          ,new CursorDef("T000M14", "SELECT TOP 1 [TicketId], [TicketResponsableId] FROM [TicketResponsable] WHERE [CategoriaDetalleTareaId] = @CategoriaDetalleTareaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000M15", "SELECT [CategoriaDetalleTareaId] FROM [CategoriaDetalleTarea] ORDER BY [CategoriaDetalleTareaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000M15,100, GxCacheFrequency.OFF ,true,false )
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
             ((int[]) buf[3])[0] = rslt.getInt(4);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((int[]) buf[3])[0] = rslt.getInt(4);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((int[]) buf[3])[0] = rslt.getInt(4);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 4 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 6 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             return;
          case 10 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
