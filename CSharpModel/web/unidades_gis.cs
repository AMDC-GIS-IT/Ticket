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
   public class unidades_gis : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV8id_unidad = (int)(NumberUtil.Val( GetPar( "id_unidad"), "."));
               AssignAttri(sPrefix, false, "AV8id_unidad", StringUtil.LTrimStr( (decimal)(AV8id_unidad), 9, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(int)AV8id_unidad});
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
                  AV8id_unidad = (int)(NumberUtil.Val( GetPar( "id_unidad"), "."));
                  AssignAttri(sPrefix, false, "AV8id_unidad", StringUtil.LTrimStr( (decimal)(AV8id_unidad), 9, 0));
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
               Form.Meta.addItem("description", "unidades_gis", 0) ;
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
            GX_FocusControl = edtnombre_unidad_Internalname;
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

      public unidades_gis( )
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

      public unidades_gis( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_id_unidad )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8id_unidad = aP1_id_unidad;
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
            return "unidades_gis_Execute" ;
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
            RenderHtmlCloseForm0B12( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "unidades_gis.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_unidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_unidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_unidad_Internalname, "id_unidad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         GxWebStd.gx_single_line_edit( context, edtid_unidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")), StringUtil.LTrim( ((edtid_unidad_Enabled!=0) ? context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_unidad_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtid_unidad_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainernombre_unidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtnombre_unidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtnombre_unidad_Internalname, "nombre_unidad", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         ClassString = edtnombre_unidad_Class;
         StyleString = "";
         ClassString = edtnombre_unidad_Class;
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_unidad_Internalname, A114nombre_unidad, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", 0, 1, edtnombre_unidad_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gisestado_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_gisestado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_gisestado_Internalname, "estado", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A115unidades_gisestado", StringUtil.LTrimStr( (decimal)(A115unidades_gisestado), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtunidades_gisestado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A115unidades_gisestado), 9, 0, ".", "")), StringUtil.LTrim( ((edtunidades_gisestado_Enabled!=0) ? context.localUtil.Format( (decimal)(A115unidades_gisestado), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A115unidades_gisestado), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_gisestado_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtunidades_gisestado_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gisfecha_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_gisfecha_creacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_gisfecha_creacion_Internalname, "fecha_creacion", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A116unidades_gisfecha_creacion", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtunidades_gisfecha_creacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtunidades_gisfecha_creacion_Internalname, context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"), context.localUtil.Format( A116unidades_gisfecha_creacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_gisfecha_creacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtunidades_gisfecha_creacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_unidades_gis.htm");
         GxWebStd.gx_bitmap( context, edtunidades_gisfecha_creacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtunidades_gisfecha_creacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gishora_creacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_gishora_creacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_gishora_creacion_Internalname, "hora_creacion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A117unidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(A117unidades_gishora_creacion), 5, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtunidades_gishora_creacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A117unidades_gishora_creacion), 5, 0, ".", "")), StringUtil.LTrim( ((edtunidades_gishora_creacion_Enabled!=0) ? context.localUtil.Format( (decimal)(A117unidades_gishora_creacion), "ZZZZ9") : context.localUtil.Format( (decimal)(A117unidades_gishora_creacion), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_gishora_creacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtunidades_gishora_creacion_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_giscreado_por_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_giscreado_por_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_giscreado_por_Internalname, "creado_por", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A118unidades_giscreado_por", A118unidades_giscreado_por);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtunidades_giscreado_por_Internalname, A118unidades_giscreado_por, StringUtil.RTrim( context.localUtil.Format( A118unidades_giscreado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_giscreado_por_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtunidades_giscreado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gisfecha_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_gisfecha_modificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_gisfecha_modificacion_Internalname, "fecha_modificacion", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A119unidades_gisfecha_modificacion", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtunidades_gisfecha_modificacion_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtunidades_gisfecha_modificacion_Internalname, context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"), context.localUtil.Format( A119unidades_gisfecha_modificacion, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_gisfecha_modificacion_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtunidades_gisfecha_modificacion_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_unidades_gis.htm");
         GxWebStd.gx_bitmap( context, edtunidades_gisfecha_modificacion_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtunidades_gisfecha_modificacion_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gishora_modificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_gishora_modificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_gishora_modificacion_Internalname, "hora_modificacion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A120unidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(A120unidades_gishora_modificacion), 5, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtunidades_gishora_modificacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A120unidades_gishora_modificacion), 5, 0, ".", "")), StringUtil.LTrim( ((edtunidades_gishora_modificacion_Enabled!=0) ? context.localUtil.Format( (decimal)(A120unidades_gishora_modificacion), "ZZZZ9") : context.localUtil.Format( (decimal)(A120unidades_gishora_modificacion), "ZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_gishora_modificacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtunidades_gishora_modificacion_Enabled, 0, "text", "1", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_unidades_gis.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerunidades_gismodificado_por_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtunidades_gismodificado_por_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtunidades_gismodificado_por_Internalname, "modificado_por", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A121unidades_gismodificado_por", A121unidades_gismodificado_por);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtunidades_gismodificado_por_Internalname, A121unidades_gismodificado_por, StringUtil.RTrim( context.localUtil.Format( A121unidades_gismodificado_por, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtunidades_gismodificado_por_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtunidades_gismodificado_por_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_unidades_gis.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_unidades_gis.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_unidades_gis.htm");
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
         E110B2 ();
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
               Z103id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z103id_unidad"), ".", ","));
               Z114nombre_unidad = cgiGet( sPrefix+"Z114nombre_unidad");
               n114nombre_unidad = (String.IsNullOrEmpty(StringUtil.RTrim( A114nombre_unidad)) ? true : false);
               Z115unidades_gisestado = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z115unidades_gisestado"), ".", ","));
               n115unidades_gisestado = ((0==A115unidades_gisestado) ? true : false);
               Z116unidades_gisfecha_creacion = context.localUtil.CToD( cgiGet( sPrefix+"Z116unidades_gisfecha_creacion"), 0);
               n116unidades_gisfecha_creacion = ((DateTime.MinValue==A116unidades_gisfecha_creacion) ? true : false);
               Z117unidades_gishora_creacion = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z117unidades_gishora_creacion"), ".", ","));
               n117unidades_gishora_creacion = ((0==A117unidades_gishora_creacion) ? true : false);
               Z118unidades_giscreado_por = cgiGet( sPrefix+"Z118unidades_giscreado_por");
               n118unidades_giscreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A118unidades_giscreado_por)) ? true : false);
               Z119unidades_gisfecha_modificacion = context.localUtil.CToD( cgiGet( sPrefix+"Z119unidades_gisfecha_modificacion"), 0);
               n119unidades_gisfecha_modificacion = ((DateTime.MinValue==A119unidades_gisfecha_modificacion) ? true : false);
               Z120unidades_gishora_modificacion = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z120unidades_gishora_modificacion"), ".", ","));
               n120unidades_gishora_modificacion = ((0==A120unidades_gishora_modificacion) ? true : false);
               Z121unidades_gismodificado_por = cgiGet( sPrefix+"Z121unidades_gismodificado_por");
               n121unidades_gismodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A121unidades_gismodificado_por)) ? true : false);
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8id_unidad"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV8id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vID_UNIDAD"), ".", ","));
               AV25Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A103id_unidad = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               A114nombre_unidad = cgiGet( edtnombre_unidad_Internalname);
               n114nombre_unidad = false;
               AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
               n114nombre_unidad = (String.IsNullOrEmpty(StringUtil.RTrim( A114nombre_unidad)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtunidades_gisestado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtunidades_gisestado_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNIDADES_GISESTADO");
                  AnyError = 1;
                  GX_FocusControl = edtunidades_gisestado_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A115unidades_gisestado = 0;
                  n115unidades_gisestado = false;
                  AssignAttri(sPrefix, false, "A115unidades_gisestado", StringUtil.LTrimStr( (decimal)(A115unidades_gisestado), 9, 0));
               }
               else
               {
                  A115unidades_gisestado = (int)(context.localUtil.CToN( cgiGet( edtunidades_gisestado_Internalname), ".", ","));
                  n115unidades_gisestado = false;
                  AssignAttri(sPrefix, false, "A115unidades_gisestado", StringUtil.LTrimStr( (decimal)(A115unidades_gisestado), 9, 0));
               }
               n115unidades_gisestado = ((0==A115unidades_gisestado) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtunidades_gisfecha_creacion_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"unidades_gisfecha_creacion"}), 1, "UNIDADES_GISFECHA_CREACION");
                  AnyError = 1;
                  GX_FocusControl = edtunidades_gisfecha_creacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A116unidades_gisfecha_creacion = DateTime.MinValue;
                  n116unidades_gisfecha_creacion = false;
                  AssignAttri(sPrefix, false, "A116unidades_gisfecha_creacion", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
               }
               else
               {
                  A116unidades_gisfecha_creacion = context.localUtil.CToD( cgiGet( edtunidades_gisfecha_creacion_Internalname), 2);
                  n116unidades_gisfecha_creacion = false;
                  AssignAttri(sPrefix, false, "A116unidades_gisfecha_creacion", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
               }
               n116unidades_gisfecha_creacion = ((DateTime.MinValue==A116unidades_gisfecha_creacion) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtunidades_gishora_creacion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtunidades_gishora_creacion_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNIDADES_GISHORA_CREACION");
                  AnyError = 1;
                  GX_FocusControl = edtunidades_gishora_creacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A117unidades_gishora_creacion = 0;
                  n117unidades_gishora_creacion = false;
                  AssignAttri(sPrefix, false, "A117unidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(A117unidades_gishora_creacion), 5, 0));
               }
               else
               {
                  A117unidades_gishora_creacion = (int)(context.localUtil.CToN( cgiGet( edtunidades_gishora_creacion_Internalname), ".", ","));
                  n117unidades_gishora_creacion = false;
                  AssignAttri(sPrefix, false, "A117unidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(A117unidades_gishora_creacion), 5, 0));
               }
               n117unidades_gishora_creacion = ((0==A117unidades_gishora_creacion) ? true : false);
               A118unidades_giscreado_por = cgiGet( edtunidades_giscreado_por_Internalname);
               n118unidades_giscreado_por = false;
               AssignAttri(sPrefix, false, "A118unidades_giscreado_por", A118unidades_giscreado_por);
               n118unidades_giscreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A118unidades_giscreado_por)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtunidades_gisfecha_modificacion_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"unidades_gisfecha_modificacion"}), 1, "UNIDADES_GISFECHA_MODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtunidades_gisfecha_modificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A119unidades_gisfecha_modificacion = DateTime.MinValue;
                  n119unidades_gisfecha_modificacion = false;
                  AssignAttri(sPrefix, false, "A119unidades_gisfecha_modificacion", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
               }
               else
               {
                  A119unidades_gisfecha_modificacion = context.localUtil.CToD( cgiGet( edtunidades_gisfecha_modificacion_Internalname), 2);
                  n119unidades_gisfecha_modificacion = false;
                  AssignAttri(sPrefix, false, "A119unidades_gisfecha_modificacion", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
               }
               n119unidades_gisfecha_modificacion = ((DateTime.MinValue==A119unidades_gisfecha_modificacion) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtunidades_gishora_modificacion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtunidades_gishora_modificacion_Internalname), ".", ",") > Convert.ToDecimal( 99999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNIDADES_GISHORA_MODIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtunidades_gishora_modificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A120unidades_gishora_modificacion = 0;
                  n120unidades_gishora_modificacion = false;
                  AssignAttri(sPrefix, false, "A120unidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(A120unidades_gishora_modificacion), 5, 0));
               }
               else
               {
                  A120unidades_gishora_modificacion = (int)(context.localUtil.CToN( cgiGet( edtunidades_gishora_modificacion_Internalname), ".", ","));
                  n120unidades_gishora_modificacion = false;
                  AssignAttri(sPrefix, false, "A120unidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(A120unidades_gishora_modificacion), 5, 0));
               }
               n120unidades_gishora_modificacion = ((0==A120unidades_gishora_modificacion) ? true : false);
               A121unidades_gismodificado_por = cgiGet( edtunidades_gismodificado_por_Internalname);
               n121unidades_gismodificado_por = false;
               AssignAttri(sPrefix, false, "A121unidades_gismodificado_por", A121unidades_gismodificado_por);
               n121unidades_gismodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A121unidades_gismodificado_por)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"unidades_gis");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A103id_unidad != Z103id_unidad ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("unidades_gis:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A103id_unidad = (int)(NumberUtil.Val( GetPar( "id_unidad"), "."));
                  AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
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
                     sMode12 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode12;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound12 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0B0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ID_UNIDAD");
                        AnyError = 1;
                        GX_FocusControl = edtid_unidad_Internalname;
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
                                 E110B2 ();
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
                                 E120B2 ();
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
                                 E130B2 ();
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
            E120B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0B12( ) ;
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
            DisableAttributes0B12( ) ;
         }
         AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_gisestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gisestado_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_gisfecha_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_creacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_gishora_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_creacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_giscreado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_giscreado_por_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_gisfecha_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_modificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_gishora_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_modificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtunidades_gismodificado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gismodificado_por_Enabled), 5, 0), true);
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B12( ) ;
            }
            else
            {
               CheckExtendedTable0B12( ) ;
               CloseExtendedTableCursors0B12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void E110B2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  AV17StandardActivityType,  AV18UserActivityType,  AV25Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("unidades_gis")),UrlEncode(StringUtil.RTrim("unidades_gis")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV25Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "unidades_gis", out  AV9TrnContext) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "unidades_gis", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "unidades_gis", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "unidades_gis", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtnombre_unidad_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Class", edtnombre_unidad_Class, true);
            }
            else
            {
               edtnombre_unidad_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Class", edtnombre_unidad_Class, true);
            }
         }
      }

      protected void E120B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV9TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "id_unidad";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A103id_unidad), 9, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "unidades_gis",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La unidades_gis %1 fue creada", A114nombre_unidad, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La unidades_gis %1 fue actualizada", A114nombre_unidad, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La unidades_gis %1 fue eliminada", A114nombre_unidad, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"unidades_gis",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV9TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV9TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "unidades_gis") ;
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
                     args = new Object[] {(string)"_site_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A103id_unidad,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A103id_unidad = (int)(args[2]) ;
                        AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A103id_unidad,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A103id_unidad = (int)(args[2]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV9TrnContext.gxTpr_Entitymanagernexttaskmode,(int)A103id_unidad,AV9TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV9TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A103id_unidad = (int)(args[1]) ;
                           AV9TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(AV9TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV11Navigation.gxTpr_Mode,(int)A103id_unidad,AV11Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A103id_unidad = (int)(args[2]) ;
                        AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV11Navigation.gxTpr_Mode,(int)A103id_unidad,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A103id_unidad = (int)(args[2]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)) + "," + UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV12DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV11Navigation.gxTpr_Mode,(int)A103id_unidad,AV11Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV12DinamicObjToLink,"GeneXus.Programs",AV12DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV11Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A103id_unidad = (int)(args[1]) ;
                           AV11Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV12DinamicObjToLink .Trim().Length < 6 || AV12DinamicObjToLink .Substring( AV12DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV12DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(AV11Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130B2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "unidades_gis") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"unidades_gis"}, true);
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

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z114nombre_unidad = T000B3_A114nombre_unidad[0];
               Z115unidades_gisestado = T000B3_A115unidades_gisestado[0];
               Z116unidades_gisfecha_creacion = T000B3_A116unidades_gisfecha_creacion[0];
               Z117unidades_gishora_creacion = T000B3_A117unidades_gishora_creacion[0];
               Z118unidades_giscreado_por = T000B3_A118unidades_giscreado_por[0];
               Z119unidades_gisfecha_modificacion = T000B3_A119unidades_gisfecha_modificacion[0];
               Z120unidades_gishora_modificacion = T000B3_A120unidades_gishora_modificacion[0];
               Z121unidades_gismodificado_por = T000B3_A121unidades_gismodificado_por[0];
            }
            else
            {
               Z114nombre_unidad = A114nombre_unidad;
               Z115unidades_gisestado = A115unidades_gisestado;
               Z116unidades_gisfecha_creacion = A116unidades_gisfecha_creacion;
               Z117unidades_gishora_creacion = A117unidades_gishora_creacion;
               Z118unidades_giscreado_por = A118unidades_giscreado_por;
               Z119unidades_gisfecha_modificacion = A119unidades_gisfecha_modificacion;
               Z120unidades_gishora_modificacion = A120unidades_gishora_modificacion;
               Z121unidades_gismodificado_por = A121unidades_gismodificado_por;
            }
         }
         if ( GX_JID == -6 )
         {
            Z103id_unidad = A103id_unidad;
            Z114nombre_unidad = A114nombre_unidad;
            Z115unidades_gisestado = A115unidades_gisestado;
            Z116unidades_gisfecha_creacion = A116unidades_gisfecha_creacion;
            Z117unidades_gishora_creacion = A117unidades_gishora_creacion;
            Z118unidades_giscreado_por = A118unidades_giscreado_por;
            Z119unidades_gisfecha_modificacion = A119unidades_gisfecha_modificacion;
            Z120unidades_gishora_modificacion = A120unidades_gishora_modificacion;
            Z121unidades_gismodificado_por = A121unidades_gismodificado_por;
         }
      }

      protected void standaloneNotModal( )
      {
         edtid_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_Enabled), 5, 0), true);
         edtid_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_Enabled), 5, 0), true);
         if ( ! (0==AV8id_unidad) )
         {
            A103id_unidad = AV8id_unidad;
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
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

      protected void Load0B12( )
      {
         /* Using cursor T000B4 */
         pr_datastore1.execute(2, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(2) != 101) )
         {
            RcdFound12 = 1;
            A114nombre_unidad = T000B4_A114nombre_unidad[0];
            n114nombre_unidad = T000B4_n114nombre_unidad[0];
            AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
            A115unidades_gisestado = T000B4_A115unidades_gisestado[0];
            n115unidades_gisestado = T000B4_n115unidades_gisestado[0];
            AssignAttri(sPrefix, false, "A115unidades_gisestado", StringUtil.LTrimStr( (decimal)(A115unidades_gisestado), 9, 0));
            A116unidades_gisfecha_creacion = T000B4_A116unidades_gisfecha_creacion[0];
            n116unidades_gisfecha_creacion = T000B4_n116unidades_gisfecha_creacion[0];
            AssignAttri(sPrefix, false, "A116unidades_gisfecha_creacion", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
            A117unidades_gishora_creacion = T000B4_A117unidades_gishora_creacion[0];
            n117unidades_gishora_creacion = T000B4_n117unidades_gishora_creacion[0];
            AssignAttri(sPrefix, false, "A117unidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(A117unidades_gishora_creacion), 5, 0));
            A118unidades_giscreado_por = T000B4_A118unidades_giscreado_por[0];
            n118unidades_giscreado_por = T000B4_n118unidades_giscreado_por[0];
            AssignAttri(sPrefix, false, "A118unidades_giscreado_por", A118unidades_giscreado_por);
            A119unidades_gisfecha_modificacion = T000B4_A119unidades_gisfecha_modificacion[0];
            n119unidades_gisfecha_modificacion = T000B4_n119unidades_gisfecha_modificacion[0];
            AssignAttri(sPrefix, false, "A119unidades_gisfecha_modificacion", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
            A120unidades_gishora_modificacion = T000B4_A120unidades_gishora_modificacion[0];
            n120unidades_gishora_modificacion = T000B4_n120unidades_gishora_modificacion[0];
            AssignAttri(sPrefix, false, "A120unidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(A120unidades_gishora_modificacion), 5, 0));
            A121unidades_gismodificado_por = T000B4_A121unidades_gismodificado_por[0];
            n121unidades_gismodificado_por = T000B4_n121unidades_gismodificado_por[0];
            AssignAttri(sPrefix, false, "A121unidades_gismodificado_por", A121unidades_gismodificado_por);
            ZM0B12( -6) ;
         }
         pr_datastore1.close(2);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
         AV25Pgmname = "unidades_gis";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "unidades_gis";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A114nombre_unidad)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "nombre_unidad", "", "", "", "", "", "", "", ""), 1, "NOMBRE_UNIDAD");
            AnyError = 1;
            GX_FocusControl = edtnombre_unidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A116unidades_gisfecha_creacion) || ( DateTimeUtil.ResetTime ( A116unidades_gisfecha_creacion ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo unidades_gisfecha_creacion fuera de rango", "OutOfRange", 1, "UNIDADES_GISFECHA_CREACION");
            AnyError = 1;
            GX_FocusControl = edtunidades_gisfecha_creacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A119unidades_gisfecha_modificacion) || ( DateTimeUtil.ResetTime ( A119unidades_gisfecha_modificacion ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo unidades_gisfecha_modificacion fuera de rango", "OutOfRange", 1, "UNIDADES_GISFECHA_MODIFICACION");
            AnyError = 1;
            GX_FocusControl = edtunidades_gisfecha_modificacion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0B12( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor T000B5 */
         pr_datastore1.execute(3, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_datastore1.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B3 */
         pr_datastore1.execute(1, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(1) != 101) )
         {
            ZM0B12( 6) ;
            RcdFound12 = 1;
            A103id_unidad = T000B3_A103id_unidad[0];
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
            A114nombre_unidad = T000B3_A114nombre_unidad[0];
            n114nombre_unidad = T000B3_n114nombre_unidad[0];
            AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
            A115unidades_gisestado = T000B3_A115unidades_gisestado[0];
            n115unidades_gisestado = T000B3_n115unidades_gisestado[0];
            AssignAttri(sPrefix, false, "A115unidades_gisestado", StringUtil.LTrimStr( (decimal)(A115unidades_gisestado), 9, 0));
            A116unidades_gisfecha_creacion = T000B3_A116unidades_gisfecha_creacion[0];
            n116unidades_gisfecha_creacion = T000B3_n116unidades_gisfecha_creacion[0];
            AssignAttri(sPrefix, false, "A116unidades_gisfecha_creacion", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
            A117unidades_gishora_creacion = T000B3_A117unidades_gishora_creacion[0];
            n117unidades_gishora_creacion = T000B3_n117unidades_gishora_creacion[0];
            AssignAttri(sPrefix, false, "A117unidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(A117unidades_gishora_creacion), 5, 0));
            A118unidades_giscreado_por = T000B3_A118unidades_giscreado_por[0];
            n118unidades_giscreado_por = T000B3_n118unidades_giscreado_por[0];
            AssignAttri(sPrefix, false, "A118unidades_giscreado_por", A118unidades_giscreado_por);
            A119unidades_gisfecha_modificacion = T000B3_A119unidades_gisfecha_modificacion[0];
            n119unidades_gisfecha_modificacion = T000B3_n119unidades_gisfecha_modificacion[0];
            AssignAttri(sPrefix, false, "A119unidades_gisfecha_modificacion", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
            A120unidades_gishora_modificacion = T000B3_A120unidades_gishora_modificacion[0];
            n120unidades_gishora_modificacion = T000B3_n120unidades_gishora_modificacion[0];
            AssignAttri(sPrefix, false, "A120unidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(A120unidades_gishora_modificacion), 5, 0));
            A121unidades_gismodificado_por = T000B3_A121unidades_gismodificado_por[0];
            n121unidades_gismodificado_por = T000B3_n121unidades_gismodificado_por[0];
            AssignAttri(sPrefix, false, "A121unidades_gismodificado_por", A121unidades_gismodificado_por);
            Z103id_unidad = A103id_unidad;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0B12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0B12( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_datastore1.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B12( ) ;
         if ( RcdFound12 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound12 = 0;
         /* Using cursor T000B6 */
         pr_datastore1.execute(4, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(4) != 101) )
         {
            while ( (pr_datastore1.getStatus(4) != 101) && ( ( T000B6_A103id_unidad[0] < A103id_unidad ) ) )
            {
               pr_datastore1.readNext(4);
            }
            if ( (pr_datastore1.getStatus(4) != 101) && ( ( T000B6_A103id_unidad[0] > A103id_unidad ) ) )
            {
               A103id_unidad = T000B6_A103id_unidad[0];
               AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               RcdFound12 = 1;
            }
         }
         pr_datastore1.close(4);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T000B7 */
         pr_datastore1.execute(5, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(5) != 101) )
         {
            while ( (pr_datastore1.getStatus(5) != 101) && ( ( T000B7_A103id_unidad[0] > A103id_unidad ) ) )
            {
               pr_datastore1.readNext(5);
            }
            if ( (pr_datastore1.getStatus(5) != 101) && ( ( T000B7_A103id_unidad[0] < A103id_unidad ) ) )
            {
               A103id_unidad = T000B7_A103id_unidad[0];
               AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               RcdFound12 = 1;
            }
         }
         pr_datastore1.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtnombre_unidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0B12( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A103id_unidad != Z103id_unidad )
               {
                  A103id_unidad = Z103id_unidad;
                  AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ID_UNIDAD");
                  AnyError = 1;
                  GX_FocusControl = edtid_unidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtnombre_unidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0B12( ) ;
                  GX_FocusControl = edtnombre_unidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A103id_unidad != Z103id_unidad )
               {
                  /* Insert record */
                  GX_FocusControl = edtnombre_unidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0B12( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ID_UNIDAD");
                     AnyError = 1;
                     GX_FocusControl = edtid_unidad_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtnombre_unidad_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0B12( ) ;
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
         if ( A103id_unidad != Z103id_unidad )
         {
            A103id_unidad = Z103id_unidad;
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ID_UNIDAD");
            AnyError = 1;
            GX_FocusControl = edtid_unidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtnombre_unidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_datastore1.execute(0, new Object[] {A103id_unidad});
            if ( (pr_datastore1.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UNIDADES_GIS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_datastore1.getStatus(0) == 101) || ( StringUtil.StrCmp(Z114nombre_unidad, T000B2_A114nombre_unidad[0]) != 0 ) || ( Z115unidades_gisestado != T000B2_A115unidades_gisestado[0] ) || ( DateTimeUtil.ResetTime ( Z116unidades_gisfecha_creacion ) != DateTimeUtil.ResetTime ( T000B2_A116unidades_gisfecha_creacion[0] ) ) || ( Z117unidades_gishora_creacion != T000B2_A117unidades_gishora_creacion[0] ) || ( StringUtil.StrCmp(Z118unidades_giscreado_por, T000B2_A118unidades_giscreado_por[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z119unidades_gisfecha_modificacion ) != DateTimeUtil.ResetTime ( T000B2_A119unidades_gisfecha_modificacion[0] ) ) || ( Z120unidades_gishora_modificacion != T000B2_A120unidades_gishora_modificacion[0] ) || ( StringUtil.StrCmp(Z121unidades_gismodificado_por, T000B2_A121unidades_gismodificado_por[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z114nombre_unidad, T000B2_A114nombre_unidad[0]) != 0 )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"nombre_unidad");
                  GXUtil.WriteLogRaw("Old: ",Z114nombre_unidad);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A114nombre_unidad[0]);
               }
               if ( Z115unidades_gisestado != T000B2_A115unidades_gisestado[0] )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_gisestado");
                  GXUtil.WriteLogRaw("Old: ",Z115unidades_gisestado);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A115unidades_gisestado[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z116unidades_gisfecha_creacion ) != DateTimeUtil.ResetTime ( T000B2_A116unidades_gisfecha_creacion[0] ) )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_gisfecha_creacion");
                  GXUtil.WriteLogRaw("Old: ",Z116unidades_gisfecha_creacion);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A116unidades_gisfecha_creacion[0]);
               }
               if ( Z117unidades_gishora_creacion != T000B2_A117unidades_gishora_creacion[0] )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_gishora_creacion");
                  GXUtil.WriteLogRaw("Old: ",Z117unidades_gishora_creacion);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A117unidades_gishora_creacion[0]);
               }
               if ( StringUtil.StrCmp(Z118unidades_giscreado_por, T000B2_A118unidades_giscreado_por[0]) != 0 )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_giscreado_por");
                  GXUtil.WriteLogRaw("Old: ",Z118unidades_giscreado_por);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A118unidades_giscreado_por[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z119unidades_gisfecha_modificacion ) != DateTimeUtil.ResetTime ( T000B2_A119unidades_gisfecha_modificacion[0] ) )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_gisfecha_modificacion");
                  GXUtil.WriteLogRaw("Old: ",Z119unidades_gisfecha_modificacion);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A119unidades_gisfecha_modificacion[0]);
               }
               if ( Z120unidades_gishora_modificacion != T000B2_A120unidades_gishora_modificacion[0] )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_gishora_modificacion");
                  GXUtil.WriteLogRaw("Old: ",Z120unidades_gishora_modificacion);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A120unidades_gishora_modificacion[0]);
               }
               if ( StringUtil.StrCmp(Z121unidades_gismodificado_por, T000B2_A121unidades_gismodificado_por[0]) != 0 )
               {
                  GXUtil.WriteLog("unidades_gis:[seudo value changed for attri]"+"unidades_gismodificado_por");
                  GXUtil.WriteLogRaw("Old: ",Z121unidades_gismodificado_por);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A121unidades_gismodificado_por[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UNIDADES_GIS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         if ( ! IsAuthorized("unidades_gis_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B8 */
                     pr_datastore1.execute(6, new Object[] {n114nombre_unidad, A114nombre_unidad, n115unidades_gisestado, A115unidades_gisestado, n116unidades_gisfecha_creacion, A116unidades_gisfecha_creacion, n117unidades_gishora_creacion, A117unidades_gishora_creacion, n118unidades_giscreado_por, A118unidades_giscreado_por, n119unidades_gisfecha_modificacion, A119unidades_gisfecha_modificacion, n120unidades_gishora_modificacion, A120unidades_gishora_modificacion, n121unidades_gismodificado_por, A121unidades_gismodificado_por});
                     A103id_unidad = T000B8_A103id_unidad[0];
                     AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
                     pr_datastore1.close(6);
                     dsDataStore1.SmartCacheProvider.SetUpdated("UNIDADES_GIS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0B0( ) ;
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         if ( ! IsAuthorized("unidades_gis_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B9 */
                     pr_datastore1.execute(7, new Object[] {n114nombre_unidad, A114nombre_unidad, n115unidades_gisestado, A115unidades_gisestado, n116unidades_gisfecha_creacion, A116unidades_gisfecha_creacion, n117unidades_gishora_creacion, A117unidades_gishora_creacion, n118unidades_giscreado_por, A118unidades_giscreado_por, n119unidades_gisfecha_modificacion, A119unidades_gisfecha_modificacion, n120unidades_gishora_modificacion, A120unidades_gishora_modificacion, n121unidades_gismodificado_por, A121unidades_gismodificado_por, A103id_unidad});
                     pr_datastore1.close(7);
                     dsDataStore1.SmartCacheProvider.SetUpdated("UNIDADES_GIS");
                     if ( (pr_datastore1.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UNIDADES_GIS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B12( ) ;
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
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("unidades_gis_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B10 */
                  pr_datastore1.execute(8, new Object[] {A103id_unidad});
                  pr_datastore1.close(8);
                  dsDataStore1.SmartCacheProvider.SetUpdated("UNIDADES_GIS");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "unidades_gis";
            AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000B11 */
            pr_default.execute(0, new Object[] {A103id_unidad});
            if ( (pr_default.getStatus(0) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Responsable"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(0);
         }
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore1.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore1.close(1);
            context.CommitDataStores("unidades_gis",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore1.close(1);
            context.RollbackDataStores("unidades_gis",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B12( )
      {
         /* Scan By routine */
         /* Using cursor T000B12 */
         pr_datastore1.execute(9);
         RcdFound12 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
            A103id_unidad = T000B12_A103id_unidad[0];
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B12( )
      {
         /* Scan next routine */
         pr_datastore1.readNext(9);
         RcdFound12 = 0;
         if ( (pr_datastore1.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
            A103id_unidad = T000B12_A103id_unidad[0];
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         }
      }

      protected void ScanEnd0B12( )
      {
         pr_datastore1.close(9);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
         edtid_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_Enabled), 5, 0), true);
         edtnombre_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Enabled), 5, 0), true);
         edtunidades_gisestado_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_gisestado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gisestado_Enabled), 5, 0), true);
         edtunidades_gisfecha_creacion_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_gisfecha_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_creacion_Enabled), 5, 0), true);
         edtunidades_gishora_creacion_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_gishora_creacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_creacion_Enabled), 5, 0), true);
         edtunidades_giscreado_por_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_giscreado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_giscreado_por_Enabled), 5, 0), true);
         edtunidades_gisfecha_modificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_gisfecha_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gisfecha_modificacion_Enabled), 5, 0), true);
         edtunidades_gishora_modificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_gishora_modificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gishora_modificacion_Enabled), 5, 0), true);
         edtunidades_gismodificado_por_Enabled = 0;
         AssignProp(sPrefix, false, edtunidades_gismodificado_por_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtunidades_gismodificado_por_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188105696", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("unidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV8id_unidad,9,0))}, new string[] {"Gx_mode","id_unidad"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"unidades_gis");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("unidades_gis:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z103id_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z103id_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z114nombre_unidad", Z114nombre_unidad);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z115unidades_gisestado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z115unidades_gisestado), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z116unidades_gisfecha_creacion", context.localUtil.DToC( Z116unidades_gisfecha_creacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z117unidades_gishora_creacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z117unidades_gishora_creacion), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z118unidades_giscreado_por", Z118unidades_giscreado_por);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z119unidades_gisfecha_modificacion", context.localUtil.DToC( Z119unidades_gisfecha_modificacion, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z120unidades_gishora_modificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z120unidades_gishora_modificacion), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z121unidades_gismodificado_por", Z121unidades_gismodificado_por);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8id_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV8id_unidad), 9, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vID_UNIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8id_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0B12( )
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
         return "unidades_gis" ;
      }

      public override string GetPgmdesc( )
      {
         return "unidades_gis" ;
      }

      protected void InitializeNonKey0B12( )
      {
         A114nombre_unidad = "";
         n114nombre_unidad = false;
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         n114nombre_unidad = (String.IsNullOrEmpty(StringUtil.RTrim( A114nombre_unidad)) ? true : false);
         A115unidades_gisestado = 0;
         n115unidades_gisestado = false;
         AssignAttri(sPrefix, false, "A115unidades_gisestado", StringUtil.LTrimStr( (decimal)(A115unidades_gisestado), 9, 0));
         n115unidades_gisestado = ((0==A115unidades_gisestado) ? true : false);
         A116unidades_gisfecha_creacion = DateTime.MinValue;
         n116unidades_gisfecha_creacion = false;
         AssignAttri(sPrefix, false, "A116unidades_gisfecha_creacion", context.localUtil.Format(A116unidades_gisfecha_creacion, "99/99/99"));
         n116unidades_gisfecha_creacion = ((DateTime.MinValue==A116unidades_gisfecha_creacion) ? true : false);
         A117unidades_gishora_creacion = 0;
         n117unidades_gishora_creacion = false;
         AssignAttri(sPrefix, false, "A117unidades_gishora_creacion", StringUtil.LTrimStr( (decimal)(A117unidades_gishora_creacion), 5, 0));
         n117unidades_gishora_creacion = ((0==A117unidades_gishora_creacion) ? true : false);
         A118unidades_giscreado_por = "";
         n118unidades_giscreado_por = false;
         AssignAttri(sPrefix, false, "A118unidades_giscreado_por", A118unidades_giscreado_por);
         n118unidades_giscreado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A118unidades_giscreado_por)) ? true : false);
         A119unidades_gisfecha_modificacion = DateTime.MinValue;
         n119unidades_gisfecha_modificacion = false;
         AssignAttri(sPrefix, false, "A119unidades_gisfecha_modificacion", context.localUtil.Format(A119unidades_gisfecha_modificacion, "99/99/99"));
         n119unidades_gisfecha_modificacion = ((DateTime.MinValue==A119unidades_gisfecha_modificacion) ? true : false);
         A120unidades_gishora_modificacion = 0;
         n120unidades_gishora_modificacion = false;
         AssignAttri(sPrefix, false, "A120unidades_gishora_modificacion", StringUtil.LTrimStr( (decimal)(A120unidades_gishora_modificacion), 5, 0));
         n120unidades_gishora_modificacion = ((0==A120unidades_gishora_modificacion) ? true : false);
         A121unidades_gismodificado_por = "";
         n121unidades_gismodificado_por = false;
         AssignAttri(sPrefix, false, "A121unidades_gismodificado_por", A121unidades_gismodificado_por);
         n121unidades_gismodificado_por = (String.IsNullOrEmpty(StringUtil.RTrim( A121unidades_gismodificado_por)) ? true : false);
         Z114nombre_unidad = "";
         Z115unidades_gisestado = 0;
         Z116unidades_gisfecha_creacion = DateTime.MinValue;
         Z117unidades_gishora_creacion = 0;
         Z118unidades_giscreado_por = "";
         Z119unidades_gisfecha_modificacion = DateTime.MinValue;
         Z120unidades_gishora_modificacion = 0;
         Z121unidades_gismodificado_por = "";
      }

      protected void InitAll0B12( )
      {
         A103id_unidad = 0;
         AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         InitializeNonKey0B12( ) ;
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
         sCtrlAV8id_unidad = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "unidades_gis", GetJustCreated( ));
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
            AV8id_unidad = Convert.ToInt32(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV8id_unidad", StringUtil.LTrimStr( (decimal)(AV8id_unidad), 9, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV8id_unidad"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV8id_unidad != wcpOAV8id_unidad ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8id_unidad = AV8id_unidad;
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
         sCtrlAV8id_unidad = cgiGet( sPrefix+"AV8id_unidad_CTRL");
         if ( StringUtil.Len( sCtrlAV8id_unidad) > 0 )
         {
            AV8id_unidad = (int)(context.localUtil.CToN( cgiGet( sCtrlAV8id_unidad), ".", ","));
            AssignAttri(sPrefix, false, "AV8id_unidad", StringUtil.LTrimStr( (decimal)(AV8id_unidad), 9, 0));
         }
         else
         {
            AV8id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"AV8id_unidad_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8id_unidad_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8id_unidad), 9, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8id_unidad)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8id_unidad_CTRL", StringUtil.RTrim( sCtrlAV8id_unidad));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188105718", true, true);
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
         context.AddJavascriptSource("unidades_gis.js", "?2024188105719", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtid_unidad_Internalname = sPrefix+"ID_UNIDAD";
         divK2btoolstable_attributecontainerid_unidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_UNIDAD";
         edtnombre_unidad_Internalname = sPrefix+"NOMBRE_UNIDAD";
         divK2btoolstable_attributecontainernombre_unidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_UNIDAD";
         edtunidades_gisestado_Internalname = sPrefix+"UNIDADES_GISESTADO";
         divK2btoolstable_attributecontainerunidades_gisestado_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISESTADO";
         edtunidades_gisfecha_creacion_Internalname = sPrefix+"UNIDADES_GISFECHA_CREACION";
         divK2btoolstable_attributecontainerunidades_gisfecha_creacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISFECHA_CREACION";
         edtunidades_gishora_creacion_Internalname = sPrefix+"UNIDADES_GISHORA_CREACION";
         divK2btoolstable_attributecontainerunidades_gishora_creacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISHORA_CREACION";
         edtunidades_giscreado_por_Internalname = sPrefix+"UNIDADES_GISCREADO_POR";
         divK2btoolstable_attributecontainerunidades_giscreado_por_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISCREADO_POR";
         edtunidades_gisfecha_modificacion_Internalname = sPrefix+"UNIDADES_GISFECHA_MODIFICACION";
         divK2btoolstable_attributecontainerunidades_gisfecha_modificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISFECHA_MODIFICACION";
         edtunidades_gishora_modificacion_Internalname = sPrefix+"UNIDADES_GISHORA_MODIFICACION";
         divK2btoolstable_attributecontainerunidades_gishora_modificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISHORA_MODIFICACION";
         edtunidades_gismodificado_por_Internalname = sPrefix+"UNIDADES_GISMODIFICADO_POR";
         divK2btoolstable_attributecontainerunidades_gismodificado_por_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUNIDADES_GISMODIFICADO_POR";
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
         Form.Caption = "unidades_gis";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtunidades_gismodificado_por_Jsonclick = "";
         edtunidades_gismodificado_por_Enabled = 1;
         edtunidades_gishora_modificacion_Jsonclick = "";
         edtunidades_gishora_modificacion_Enabled = 1;
         edtunidades_gisfecha_modificacion_Jsonclick = "";
         edtunidades_gisfecha_modificacion_Enabled = 1;
         edtunidades_giscreado_por_Jsonclick = "";
         edtunidades_giscreado_por_Enabled = 1;
         edtunidades_gishora_creacion_Jsonclick = "";
         edtunidades_gishora_creacion_Enabled = 1;
         edtunidades_gisfecha_creacion_Jsonclick = "";
         edtunidades_gisfecha_creacion_Enabled = 1;
         edtunidades_gisestado_Jsonclick = "";
         edtunidades_gisestado_Enabled = 1;
         edtnombre_unidad_Class = "Attribute_Trn Attribute_Required";
         edtnombre_unidad_Enabled = 1;
         edtid_unidad_Jsonclick = "";
         edtid_unidad_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8id_unidad',fld:'vID_UNIDAD',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120B2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A103id_unidad',fld:'ID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A114nombre_unidad',fld:'NOMBRE_UNIDAD',pic:''},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV11Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A103id_unidad',fld:'ID_UNIDAD',pic:'ZZZZZZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130B2',iparms:[{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_ID_UNIDAD","{handler:'Valid_Id_unidad',iparms:[]");
         setEventMetadata("VALID_ID_UNIDAD",",oparms:[]}");
         setEventMetadata("VALID_NOMBRE_UNIDAD","{handler:'Valid_Nombre_unidad',iparms:[]");
         setEventMetadata("VALID_NOMBRE_UNIDAD",",oparms:[]}");
         setEventMetadata("VALID_UNIDADES_GISFECHA_CREACION","{handler:'Valid_Unidades_gisfecha_creacion',iparms:[]");
         setEventMetadata("VALID_UNIDADES_GISFECHA_CREACION",",oparms:[]}");
         setEventMetadata("VALID_UNIDADES_GISFECHA_MODIFICACION","{handler:'Valid_Unidades_gisfecha_modificacion',iparms:[]");
         setEventMetadata("VALID_UNIDADES_GISFECHA_MODIFICACION",",oparms:[]}");
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
         Z114nombre_unidad = "";
         Z116unidades_gisfecha_creacion = DateTime.MinValue;
         Z118unidades_giscreado_por = "";
         Z119unidades_gisfecha_modificacion = DateTime.MinValue;
         Z121unidades_gismodificado_por = "";
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
         A114nombre_unidad = "";
         TempTags = "";
         A116unidades_gisfecha_creacion = DateTime.MinValue;
         A118unidades_giscreado_por = "";
         A119unidades_gisfecha_modificacion = DateTime.MinValue;
         A121unidades_gismodificado_por = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV25Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode12 = "";
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
         T000B4_A103id_unidad = new int[1] ;
         T000B4_A114nombre_unidad = new string[] {""} ;
         T000B4_n114nombre_unidad = new bool[] {false} ;
         T000B4_A115unidades_gisestado = new int[1] ;
         T000B4_n115unidades_gisestado = new bool[] {false} ;
         T000B4_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000B4_n116unidades_gisfecha_creacion = new bool[] {false} ;
         T000B4_A117unidades_gishora_creacion = new int[1] ;
         T000B4_n117unidades_gishora_creacion = new bool[] {false} ;
         T000B4_A118unidades_giscreado_por = new string[] {""} ;
         T000B4_n118unidades_giscreado_por = new bool[] {false} ;
         T000B4_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000B4_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         T000B4_A120unidades_gishora_modificacion = new int[1] ;
         T000B4_n120unidades_gishora_modificacion = new bool[] {false} ;
         T000B4_A121unidades_gismodificado_por = new string[] {""} ;
         T000B4_n121unidades_gismodificado_por = new bool[] {false} ;
         T000B5_A103id_unidad = new int[1] ;
         T000B3_A103id_unidad = new int[1] ;
         T000B3_A114nombre_unidad = new string[] {""} ;
         T000B3_n114nombre_unidad = new bool[] {false} ;
         T000B3_A115unidades_gisestado = new int[1] ;
         T000B3_n115unidades_gisestado = new bool[] {false} ;
         T000B3_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000B3_n116unidades_gisfecha_creacion = new bool[] {false} ;
         T000B3_A117unidades_gishora_creacion = new int[1] ;
         T000B3_n117unidades_gishora_creacion = new bool[] {false} ;
         T000B3_A118unidades_giscreado_por = new string[] {""} ;
         T000B3_n118unidades_giscreado_por = new bool[] {false} ;
         T000B3_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000B3_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         T000B3_A120unidades_gishora_modificacion = new int[1] ;
         T000B3_n120unidades_gishora_modificacion = new bool[] {false} ;
         T000B3_A121unidades_gismodificado_por = new string[] {""} ;
         T000B3_n121unidades_gismodificado_por = new bool[] {false} ;
         T000B6_A103id_unidad = new int[1] ;
         T000B7_A103id_unidad = new int[1] ;
         T000B2_A103id_unidad = new int[1] ;
         T000B2_A114nombre_unidad = new string[] {""} ;
         T000B2_n114nombre_unidad = new bool[] {false} ;
         T000B2_A115unidades_gisestado = new int[1] ;
         T000B2_n115unidades_gisestado = new bool[] {false} ;
         T000B2_A116unidades_gisfecha_creacion = new DateTime[] {DateTime.MinValue} ;
         T000B2_n116unidades_gisfecha_creacion = new bool[] {false} ;
         T000B2_A117unidades_gishora_creacion = new int[1] ;
         T000B2_n117unidades_gishora_creacion = new bool[] {false} ;
         T000B2_A118unidades_giscreado_por = new string[] {""} ;
         T000B2_n118unidades_giscreado_por = new bool[] {false} ;
         T000B2_A119unidades_gisfecha_modificacion = new DateTime[] {DateTime.MinValue} ;
         T000B2_n119unidades_gisfecha_modificacion = new bool[] {false} ;
         T000B2_A120unidades_gishora_modificacion = new int[1] ;
         T000B2_n120unidades_gishora_modificacion = new bool[] {false} ;
         T000B2_A121unidades_gismodificado_por = new string[] {""} ;
         T000B2_n121unidades_gismodificado_por = new bool[] {false} ;
         T000B8_A103id_unidad = new int[1] ;
         T000B11_A6ResponsableId = new short[1] ;
         T000B12_A103id_unidad = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV8id_unidad = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.unidades_gis__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.unidades_gis__datastore1(),
            new Object[][] {
                new Object[] {
               T000B2_A103id_unidad, T000B2_A114nombre_unidad, T000B2_n114nombre_unidad, T000B2_A115unidades_gisestado, T000B2_n115unidades_gisestado, T000B2_A116unidades_gisfecha_creacion, T000B2_n116unidades_gisfecha_creacion, T000B2_A117unidades_gishora_creacion, T000B2_n117unidades_gishora_creacion, T000B2_A118unidades_giscreado_por,
               T000B2_n118unidades_giscreado_por, T000B2_A119unidades_gisfecha_modificacion, T000B2_n119unidades_gisfecha_modificacion, T000B2_A120unidades_gishora_modificacion, T000B2_n120unidades_gishora_modificacion, T000B2_A121unidades_gismodificado_por, T000B2_n121unidades_gismodificado_por
               }
               , new Object[] {
               T000B3_A103id_unidad, T000B3_A114nombre_unidad, T000B3_n114nombre_unidad, T000B3_A115unidades_gisestado, T000B3_n115unidades_gisestado, T000B3_A116unidades_gisfecha_creacion, T000B3_n116unidades_gisfecha_creacion, T000B3_A117unidades_gishora_creacion, T000B3_n117unidades_gishora_creacion, T000B3_A118unidades_giscreado_por,
               T000B3_n118unidades_giscreado_por, T000B3_A119unidades_gisfecha_modificacion, T000B3_n119unidades_gisfecha_modificacion, T000B3_A120unidades_gishora_modificacion, T000B3_n120unidades_gishora_modificacion, T000B3_A121unidades_gismodificado_por, T000B3_n121unidades_gismodificado_por
               }
               , new Object[] {
               T000B4_A103id_unidad, T000B4_A114nombre_unidad, T000B4_n114nombre_unidad, T000B4_A115unidades_gisestado, T000B4_n115unidades_gisestado, T000B4_A116unidades_gisfecha_creacion, T000B4_n116unidades_gisfecha_creacion, T000B4_A117unidades_gishora_creacion, T000B4_n117unidades_gishora_creacion, T000B4_A118unidades_giscreado_por,
               T000B4_n118unidades_giscreado_por, T000B4_A119unidades_gisfecha_modificacion, T000B4_n119unidades_gisfecha_modificacion, T000B4_A120unidades_gishora_modificacion, T000B4_n120unidades_gishora_modificacion, T000B4_A121unidades_gismodificado_por, T000B4_n121unidades_gismodificado_por
               }
               , new Object[] {
               T000B5_A103id_unidad
               }
               , new Object[] {
               T000B6_A103id_unidad
               }
               , new Object[] {
               T000B7_A103id_unidad
               }
               , new Object[] {
               T000B8_A103id_unidad
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B12_A103id_unidad
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.unidades_gis__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.unidades_gis__default(),
            new Object[][] {
                new Object[] {
               T000B11_A6ResponsableId
               }
            }
         );
         AV25Pgmname = "unidades_gis";
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
      private short RcdFound12 ;
      private short GX_JID ;
      private short nIsDirty_12 ;
      private short Gx_BScreen ;
      private int wcpOAV8id_unidad ;
      private int Z103id_unidad ;
      private int Z115unidades_gisestado ;
      private int Z117unidades_gishora_creacion ;
      private int Z120unidades_gishora_modificacion ;
      private int AV8id_unidad ;
      private int trnEnded ;
      private int A103id_unidad ;
      private int edtid_unidad_Enabled ;
      private int edtnombre_unidad_Enabled ;
      private int A115unidades_gisestado ;
      private int edtunidades_gisestado_Enabled ;
      private int edtunidades_gisfecha_creacion_Enabled ;
      private int A117unidades_gishora_creacion ;
      private int edtunidades_gishora_creacion_Enabled ;
      private int edtunidades_giscreado_por_Enabled ;
      private int edtunidades_gisfecha_modificacion_Enabled ;
      private int A120unidades_gishora_modificacion ;
      private int edtunidades_gishora_modificacion_Enabled ;
      private int edtunidades_gismodificado_por_Enabled ;
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
      private string edtnombre_unidad_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerid_unidad_Internalname ;
      private string edtid_unidad_Internalname ;
      private string edtid_unidad_Jsonclick ;
      private string divK2btoolstable_attributecontainernombre_unidad_Internalname ;
      private string TempTags ;
      private string edtnombre_unidad_Class ;
      private string divK2btoolstable_attributecontainerunidades_gisestado_Internalname ;
      private string edtunidades_gisestado_Internalname ;
      private string edtunidades_gisestado_Jsonclick ;
      private string divK2btoolstable_attributecontainerunidades_gisfecha_creacion_Internalname ;
      private string edtunidades_gisfecha_creacion_Internalname ;
      private string edtunidades_gisfecha_creacion_Jsonclick ;
      private string divK2btoolstable_attributecontainerunidades_gishora_creacion_Internalname ;
      private string edtunidades_gishora_creacion_Internalname ;
      private string edtunidades_gishora_creacion_Jsonclick ;
      private string divK2btoolstable_attributecontainerunidades_giscreado_por_Internalname ;
      private string edtunidades_giscreado_por_Internalname ;
      private string edtunidades_giscreado_por_Jsonclick ;
      private string divK2btoolstable_attributecontainerunidades_gisfecha_modificacion_Internalname ;
      private string edtunidades_gisfecha_modificacion_Internalname ;
      private string edtunidades_gisfecha_modificacion_Jsonclick ;
      private string divK2btoolstable_attributecontainerunidades_gishora_modificacion_Internalname ;
      private string edtunidades_gishora_modificacion_Internalname ;
      private string edtunidades_gishora_modificacion_Jsonclick ;
      private string divK2btoolstable_attributecontainerunidades_gismodificado_por_Internalname ;
      private string edtunidades_gismodificado_por_Internalname ;
      private string edtunidades_gismodificado_por_Jsonclick ;
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
      private string sMode12 ;
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
      private string sCtrlAV8id_unidad ;
      private DateTime Z116unidades_gisfecha_creacion ;
      private DateTime Z119unidades_gisfecha_modificacion ;
      private DateTime A116unidades_gisfecha_creacion ;
      private DateTime A119unidades_gisfecha_modificacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n114nombre_unidad ;
      private bool n115unidades_gisestado ;
      private bool n116unidades_gisfecha_creacion ;
      private bool n117unidades_gishora_creacion ;
      private bool n118unidades_giscreado_por ;
      private bool n119unidades_gisfecha_modificacion ;
      private bool n120unidades_gishora_modificacion ;
      private bool n121unidades_gismodificado_por ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
      private bool Gx_longc ;
      private string Z114nombre_unidad ;
      private string Z118unidades_giscreado_por ;
      private string Z121unidades_gismodificado_por ;
      private string A114nombre_unidad ;
      private string A118unidades_giscreado_por ;
      private string A121unidades_gismodificado_por ;
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
      private int[] T000B4_A103id_unidad ;
      private string[] T000B4_A114nombre_unidad ;
      private bool[] T000B4_n114nombre_unidad ;
      private int[] T000B4_A115unidades_gisestado ;
      private bool[] T000B4_n115unidades_gisestado ;
      private DateTime[] T000B4_A116unidades_gisfecha_creacion ;
      private bool[] T000B4_n116unidades_gisfecha_creacion ;
      private int[] T000B4_A117unidades_gishora_creacion ;
      private bool[] T000B4_n117unidades_gishora_creacion ;
      private string[] T000B4_A118unidades_giscreado_por ;
      private bool[] T000B4_n118unidades_giscreado_por ;
      private DateTime[] T000B4_A119unidades_gisfecha_modificacion ;
      private bool[] T000B4_n119unidades_gisfecha_modificacion ;
      private int[] T000B4_A120unidades_gishora_modificacion ;
      private bool[] T000B4_n120unidades_gishora_modificacion ;
      private string[] T000B4_A121unidades_gismodificado_por ;
      private bool[] T000B4_n121unidades_gismodificado_por ;
      private int[] T000B5_A103id_unidad ;
      private int[] T000B3_A103id_unidad ;
      private string[] T000B3_A114nombre_unidad ;
      private bool[] T000B3_n114nombre_unidad ;
      private int[] T000B3_A115unidades_gisestado ;
      private bool[] T000B3_n115unidades_gisestado ;
      private DateTime[] T000B3_A116unidades_gisfecha_creacion ;
      private bool[] T000B3_n116unidades_gisfecha_creacion ;
      private int[] T000B3_A117unidades_gishora_creacion ;
      private bool[] T000B3_n117unidades_gishora_creacion ;
      private string[] T000B3_A118unidades_giscreado_por ;
      private bool[] T000B3_n118unidades_giscreado_por ;
      private DateTime[] T000B3_A119unidades_gisfecha_modificacion ;
      private bool[] T000B3_n119unidades_gisfecha_modificacion ;
      private int[] T000B3_A120unidades_gishora_modificacion ;
      private bool[] T000B3_n120unidades_gishora_modificacion ;
      private string[] T000B3_A121unidades_gismodificado_por ;
      private bool[] T000B3_n121unidades_gismodificado_por ;
      private int[] T000B6_A103id_unidad ;
      private int[] T000B7_A103id_unidad ;
      private int[] T000B2_A103id_unidad ;
      private string[] T000B2_A114nombre_unidad ;
      private bool[] T000B2_n114nombre_unidad ;
      private int[] T000B2_A115unidades_gisestado ;
      private bool[] T000B2_n115unidades_gisestado ;
      private DateTime[] T000B2_A116unidades_gisfecha_creacion ;
      private bool[] T000B2_n116unidades_gisfecha_creacion ;
      private int[] T000B2_A117unidades_gishora_creacion ;
      private bool[] T000B2_n117unidades_gishora_creacion ;
      private string[] T000B2_A118unidades_giscreado_por ;
      private bool[] T000B2_n118unidades_giscreado_por ;
      private DateTime[] T000B2_A119unidades_gisfecha_modificacion ;
      private bool[] T000B2_n119unidades_gisfecha_modificacion ;
      private int[] T000B2_A120unidades_gishora_modificacion ;
      private bool[] T000B2_n120unidades_gishora_modificacion ;
      private string[] T000B2_A121unidades_gismodificado_por ;
      private bool[] T000B2_n121unidades_gismodificado_por ;
      private int[] T000B8_A103id_unidad ;
      private IDataStoreProvider pr_default ;
      private short[] T000B11_A6ResponsableId ;
      private int[] T000B12_A103id_unidad ;
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

   public class unidades_gis__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class unidades_gis__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000B4;
        prmT000B4 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B5;
        prmT000B5 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B3;
        prmT000B3 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B6;
        prmT000B6 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B7;
        prmT000B7 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B2;
        prmT000B2 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B8;
        prmT000B8 = new Object[] {
        new ParDef("@nombre_unidad",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@unidades_gisestado",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@unidades_gisfecha_creacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@unidades_gishora_creacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@unidades_giscreado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@unidades_gisfecha_modificacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@unidades_gishora_modificacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@unidades_gismodificado_por",GXType.NVarChar,30,0){Nullable=true}
        };
        Object[] prmT000B9;
        prmT000B9 = new Object[] {
        new ParDef("@nombre_unidad",GXType.NVarChar,200,0){Nullable=true} ,
        new ParDef("@unidades_gisestado",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("@unidades_gisfecha_creacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@unidades_gishora_creacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@unidades_giscreado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@unidades_gisfecha_modificacion",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@unidades_gishora_modificacion",GXType.Int32,5,0){Nullable=true} ,
        new ParDef("@unidades_gismodificado_por",GXType.NVarChar,30,0){Nullable=true} ,
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B10;
        prmT000B10 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000B12;
        prmT000B12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000B2", "SELECT [id_unidad], [nombre_unidad], [estado], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por] FROM dbo.[unidades_gis] WITH (UPDLOCK) WHERE [id_unidad] = @id_unidad ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B3", "SELECT [id_unidad], [nombre_unidad], [estado], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B4", "SELECT TM1.[id_unidad], TM1.[nombre_unidad], TM1.[estado], TM1.[fecha_creacion], TM1.[hora_creacion], TM1.[creado_por], TM1.[fecha_modificacion], TM1.[hora_modificacion], TM1.[modificado_por] FROM dbo.[unidades_gis] TM1 WHERE TM1.[id_unidad] = @id_unidad ORDER BY TM1.[id_unidad]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B5", "SELECT [id_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B6", "SELECT TOP 1 [id_unidad] FROM dbo.[unidades_gis] WHERE ( [id_unidad] > @id_unidad) ORDER BY [id_unidad]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B7", "SELECT TOP 1 [id_unidad] FROM dbo.[unidades_gis] WHERE ( [id_unidad] < @id_unidad) ORDER BY [id_unidad] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B8", "INSERT INTO dbo.[unidades_gis]([nombre_unidad], [estado], [fecha_creacion], [hora_creacion], [creado_por], [fecha_modificacion], [hora_modificacion], [modificado_por]) VALUES(@nombre_unidad, @unidades_gisestado, @unidades_gisfecha_creacion, @unidades_gishora_creacion, @unidades_giscreado_por, @unidades_gisfecha_modificacion, @unidades_gishora_modificacion, @unidades_gismodificado_por); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000B8)
           ,new CursorDef("T000B9", "UPDATE dbo.[unidades_gis] SET [nombre_unidad]=@nombre_unidad, [estado]=@unidades_gisestado, [fecha_creacion]=@unidades_gisfecha_creacion, [hora_creacion]=@unidades_gishora_creacion, [creado_por]=@unidades_giscreado_por, [fecha_modificacion]=@unidades_gisfecha_modificacion, [hora_modificacion]=@unidades_gishora_modificacion, [modificado_por]=@unidades_gismodificado_por  WHERE [id_unidad] = @id_unidad", GxErrorMask.GX_NOMASK,prmT000B9)
           ,new CursorDef("T000B10", "DELETE FROM dbo.[unidades_gis]  WHERE [id_unidad] = @id_unidad", GxErrorMask.GX_NOMASK,prmT000B10)
           ,new CursorDef("T000B12", "SELECT [id_unidad] FROM dbo.[unidades_gis] ORDER BY [id_unidad]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B12,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getVarchar(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getVarchar(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((int[]) buf[7])[0] = rslt.getInt(5);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((int[]) buf[13])[0] = rslt.getInt(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((string[]) buf[15])[0] = rslt.getVarchar(9);
              ((bool[]) buf[16])[0] = rslt.wasNull(9);
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

public class unidades_gis__gam : DataStoreHelperBase, IDataStoreHelper
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

public class unidades_gis__default : DataStoreHelperBase, IDataStoreHelper
{
   public ICursor[] getCursors( )
   {
      cursorDefinitions();
      return new Cursor[] {
       new ForEachCursor(def[0])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000B11;
       prmT000B11 = new Object[] {
       new ParDef("@id_unidad",GXType.Int32,9,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000B11", "SELECT TOP 1 [ResponsableId] FROM [Responsable] WHERE [id_unidad] = @id_unidad ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B11,1, GxCacheFrequency.OFF ,true,true )
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
             return;
    }
 }

}

}
