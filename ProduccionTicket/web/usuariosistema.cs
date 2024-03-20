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
   public class usuariosistema : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV30UsuarioSistemaId = GetPar( "UsuarioSistemaId");
               AssignAttri(sPrefix, false, "AV30UsuarioSistemaId", AV30UsuarioSistemaId);
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV30UsuarioSistemaId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel12"+"_"+"") == 0 )
            {
               A258DireccionId = (short)(NumberUtil.Val( GetPar( "DireccionId"), "."));
               AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA2620A11( A258DireccionId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"") == 0 )
            {
               A259CentrodecostoId = GetPar( "CentrodecostoId");
               AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
               A260DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
               AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA2610A11( A259CentrodecostoId, A260DepartamentoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_21") == 0 )
            {
               A258DireccionId = (short)(NumberUtil.Val( GetPar( "DireccionId"), "."));
               AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_21( A258DireccionId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
            {
               A259CentrodecostoId = GetPar( "CentrodecostoId");
               AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
               A260DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
               AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_22( A259CentrodecostoId, A260DepartamentoId) ;
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
                  AV30UsuarioSistemaId = GetPar( "UsuarioSistemaId");
                  AssignAttri(sPrefix, false, "AV30UsuarioSistemaId", AV30UsuarioSistemaId);
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
               Form.Meta.addItem("description", "Usuario Sistema", 0) ;
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
            GX_FocusControl = edtUsuarioSistemaId_Internalname;
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

      public usuariosistema( )
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

      public usuariosistema( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_UsuarioSistemaId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV30UsuarioSistemaId = aP1_UsuarioSistemaId;
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
            return "usuariosistema_Execute" ;
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
            RenderHtmlCloseForm0A11( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usuariosistema.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemaid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaId_Internalname, "Usuario Sistema:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSistemaId_Internalname, A99UsuarioSistemaId, StringUtil.RTrim( context.localUtil.Format( A99UsuarioSistemaId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSistemaId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioSistemaId_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemaidentidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaIdentidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaIdentidad_Internalname, "Identidad", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A101UsuarioSistemaIdentidad", A101UsuarioSistemaIdentidad);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSistemaIdentidad_Internalname, A101UsuarioSistemaIdentidad, StringUtil.RTrim( context.localUtil.Format( A101UsuarioSistemaIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSistemaIdentidad_Jsonclick, 0, edtUsuarioSistemaIdentidad_Class, "", "", "", "", 1, edtUsuarioSistemaIdentidad_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemanombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaNombre_Internalname, "Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A100UsuarioSistemaNombre", A100UsuarioSistemaNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSistemaNombre_Internalname, A100UsuarioSistemaNombre, StringUtil.RTrim( context.localUtil.Format( A100UsuarioSistemaNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSistemaNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioSistemaNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemagerencia_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaGerencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaGerencia_Internalname, "Gerencia", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A263UsuarioSistemaGerencia", A263UsuarioSistemaGerencia);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioSistemaGerencia_Internalname, A263UsuarioSistemaGerencia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", 0, 1, edtUsuarioSistemaGerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemadepartamento_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaDepartamento_Internalname, "Departamento", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A257UsuarioSistemaDepartamento", A257UsuarioSistemaDepartamento);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioSistemaDepartamento_Internalname, A257UsuarioSistemaDepartamento, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtUsuarioSistemaDepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistematelefono_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaTelefono_Internalname, "Teléfono", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A264UsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(A264UsuarioSistemaTelefono), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSistemaTelefono_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A264UsuarioSistemaTelefono), 9, 0, ".", "")), StringUtil.LTrim( ((edtUsuarioSistemaTelefono_Enabled!=0) ? context.localUtil.Format( (decimal)(A264UsuarioSistemaTelefono), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A264UsuarioSistemaTelefono), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioSistemaTelefono_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioSistemaTelefono_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Telefono", "right", false, "", "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariosistemaemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioSistemaEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioSistemaEmail_Internalname, "Email", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A265UsuarioSistemaEmail", A265UsuarioSistemaEmail);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioSistemaEmail_Internalname, A265UsuarioSistemaEmail, StringUtil.RTrim( context.localUtil.Format( A265UsuarioSistemaEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A265UsuarioSistemaEmail, "", "", "", edtUsuarioSistemaEmail_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioSistemaEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdireccionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtDireccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDireccionId_Internalname, "Direccion Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDireccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A258DireccionId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A258DireccionId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDireccionId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtDireccionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UsuarioSistema.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_258_Internalname, sImgUrl, imgprompt_258_Link, "", "", context.GetTheme( ), imgprompt_258_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdirecciondescripcion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtDireccionDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDireccionDescripcion_Internalname, "Direccion Descripcion", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDireccionDescripcion_Internalname, A262DireccionDescripcion, edtDireccionDescripcion_Link, "", 0, 1, edtDireccionDescripcion_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercentrodecostoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtCentrodecostoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentrodecostoId_Internalname, "Centrodecosto Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentrodecostoId_Internalname, A259CentrodecostoId, StringUtil.RTrim( context.localUtil.Format( A259CentrodecostoId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentrodecostoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtCentrodecostoId_Enabled, 1, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdepartamentoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtDepartamentoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoId_Internalname, "Departamento Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A260DepartamentoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A260DepartamentoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtDepartamentoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_UsuarioSistema.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_259_260_Internalname, sImgUrl, imgprompt_259_260_Link, "", "", context.GetTheme( ), imgprompt_259_260_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_UsuarioSistema.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerdepartamentonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtDepartamentoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDepartamentoNombre_Internalname, "Departamento Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDepartamentoNombre_Internalname, A261DepartamentoNombre, edtDepartamentoNombre_Link, "", 0, 1, edtDepartamentoNombre_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_UsuarioSistema.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_UsuarioSistema.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_UsuarioSistema.htm");
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
         E110A2 ();
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
               Z99UsuarioSistemaId = cgiGet( sPrefix+"Z99UsuarioSistemaId");
               Z101UsuarioSistemaIdentidad = cgiGet( sPrefix+"Z101UsuarioSistemaIdentidad");
               Z100UsuarioSistemaNombre = cgiGet( sPrefix+"Z100UsuarioSistemaNombre");
               Z263UsuarioSistemaGerencia = cgiGet( sPrefix+"Z263UsuarioSistemaGerencia");
               n263UsuarioSistemaGerencia = (String.IsNullOrEmpty(StringUtil.RTrim( A263UsuarioSistemaGerencia)) ? true : false);
               Z257UsuarioSistemaDepartamento = cgiGet( sPrefix+"Z257UsuarioSistemaDepartamento");
               n257UsuarioSistemaDepartamento = (String.IsNullOrEmpty(StringUtil.RTrim( A257UsuarioSistemaDepartamento)) ? true : false);
               Z264UsuarioSistemaTelefono = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z264UsuarioSistemaTelefono"), ".", ","));
               Z265UsuarioSistemaEmail = cgiGet( sPrefix+"Z265UsuarioSistemaEmail");
               Z266UsuarioSistemaFecha = context.localUtil.CToT( cgiGet( sPrefix+"Z266UsuarioSistemaFecha"), 0);
               Z258DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z258DireccionId"), ".", ","));
               Z259CentrodecostoId = cgiGet( sPrefix+"Z259CentrodecostoId");
               Z260DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z260DepartamentoId"), ".", ","));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV30UsuarioSistemaId = cgiGet( sPrefix+"wcpOAV30UsuarioSistemaId");
               A266UsuarioSistemaFecha = context.localUtil.CToT( cgiGet( sPrefix+"Z266UsuarioSistemaFecha"), 0);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N258DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N258DireccionId"), ".", ","));
               N259CentrodecostoId = cgiGet( sPrefix+"N259CentrodecostoId");
               N260DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N260DepartamentoId"), ".", ","));
               AV30UsuarioSistemaId = cgiGet( sPrefix+"vUSUARIOSISTEMAID");
               AV31Insert_DireccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_DIRECCIONID"), ".", ","));
               AV32Insert_CentrodecostoId = cgiGet( sPrefix+"vINSERT_CENTRODECOSTOID");
               AV33Insert_DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_DEPARTAMENTOID"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ".", ","));
               A266UsuarioSistemaFecha = context.localUtil.CToT( cgiGet( sPrefix+"USUARIOSISTEMAFECHA"), 0);
               AV35Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A99UsuarioSistemaId = cgiGet( edtUsuarioSistemaId_Internalname);
               AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
               A101UsuarioSistemaIdentidad = cgiGet( edtUsuarioSistemaIdentidad_Internalname);
               AssignAttri(sPrefix, false, "A101UsuarioSistemaIdentidad", A101UsuarioSistemaIdentidad);
               A100UsuarioSistemaNombre = cgiGet( edtUsuarioSistemaNombre_Internalname);
               AssignAttri(sPrefix, false, "A100UsuarioSistemaNombre", A100UsuarioSistemaNombre);
               A263UsuarioSistemaGerencia = cgiGet( edtUsuarioSistemaGerencia_Internalname);
               n263UsuarioSistemaGerencia = false;
               AssignAttri(sPrefix, false, "A263UsuarioSistemaGerencia", A263UsuarioSistemaGerencia);
               n263UsuarioSistemaGerencia = (String.IsNullOrEmpty(StringUtil.RTrim( A263UsuarioSistemaGerencia)) ? true : false);
               A257UsuarioSistemaDepartamento = cgiGet( edtUsuarioSistemaDepartamento_Internalname);
               n257UsuarioSistemaDepartamento = false;
               AssignAttri(sPrefix, false, "A257UsuarioSistemaDepartamento", A257UsuarioSistemaDepartamento);
               n257UsuarioSistemaDepartamento = (String.IsNullOrEmpty(StringUtil.RTrim( A257UsuarioSistemaDepartamento)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioSistemaTelefono_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioSistemaTelefono_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOSISTEMATELEFONO");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioSistemaTelefono_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A264UsuarioSistemaTelefono = 0;
                  AssignAttri(sPrefix, false, "A264UsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(A264UsuarioSistemaTelefono), 9, 0));
               }
               else
               {
                  A264UsuarioSistemaTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioSistemaTelefono_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A264UsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(A264UsuarioSistemaTelefono), 9, 0));
               }
               A265UsuarioSistemaEmail = cgiGet( edtUsuarioSistemaEmail_Internalname);
               AssignAttri(sPrefix, false, "A265UsuarioSistemaEmail", A265UsuarioSistemaEmail);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDireccionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDireccionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DIRECCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtDireccionId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A258DireccionId = 0;
                  AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
               }
               else
               {
                  A258DireccionId = (short)(context.localUtil.CToN( cgiGet( edtDireccionId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
               }
               A262DireccionDescripcion = cgiGet( edtDireccionDescripcion_Internalname);
               AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
               A259CentrodecostoId = cgiGet( edtCentrodecostoId_Internalname);
               AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DEPARTAMENTOID");
                  AnyError = 1;
                  GX_FocusControl = edtDepartamentoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A260DepartamentoId = 0;
                  AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               }
               else
               {
                  A260DepartamentoId = (short)(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               }
               A261DepartamentoNombre = cgiGet( edtDepartamentoNombre_Internalname);
               AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuarioSistema");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A99UsuarioSistemaId, Z99UsuarioSistemaId) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("usuariosistema:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A99UsuarioSistemaId = GetPar( "UsuarioSistemaId");
                  AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
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
                     sMode11 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode11;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound11 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USUARIOSISTEMAID");
                        AnyError = 1;
                        GX_FocusControl = edtUsuarioSistemaId_Internalname;
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
                                 E110A2 ();
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
                                 E120A2 ();
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
                                 E130A2 ();
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
            E120A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A11( ) ;
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
            DisableAttributes0A11( ) ;
         }
         AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioSistemaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioSistemaGerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioSistemaDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioSistemaTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaTelefono_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioSistemaEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaEmail_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDireccionDescripcion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoNombre_Enabled), 5, 0), true);
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A11( ) ;
            }
            else
            {
               CheckExtendedTable0A11( ) ;
               CloseExtendedTableCursors0A11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV16StandardActivityType = "Insert";
            AssignAttri(sPrefix, false, "AV16StandardActivityType", AV16StandardActivityType);
            AV17UserActivityType = "";
            AssignAttri(sPrefix, false, "AV17UserActivityType", AV17UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV16StandardActivityType = "Update";
            AssignAttri(sPrefix, false, "AV16StandardActivityType", AV16StandardActivityType);
            AV17UserActivityType = "";
            AssignAttri(sPrefix, false, "AV17UserActivityType", AV17UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV16StandardActivityType = "Delete";
            AssignAttri(sPrefix, false, "AV16StandardActivityType", AV16StandardActivityType);
            AV17UserActivityType = "";
            AssignAttri(sPrefix, false, "AV17UserActivityType", AV17UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV16StandardActivityType = "Display";
            AssignAttri(sPrefix, false, "AV16StandardActivityType", AV16StandardActivityType);
            AV17UserActivityType = "";
            AssignAttri(sPrefix, false, "AV17UserActivityType", AV17UserActivityType);
         }
         new k2bisauthorizedactivityname(context ).execute(  "UsuarioSistema",  "UsuarioSistema",  AV16StandardActivityType,  AV17UserActivityType,  AV35Pgmname, out  AV18IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV18IsAuthorized", AV18IsAuthorized);
         if ( ! AV18IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("UsuarioSistema")),UrlEncode(StringUtil.RTrim("UsuarioSistema")),UrlEncode(StringUtil.RTrim(AV16StandardActivityType)),UrlEncode(StringUtil.RTrim(AV17UserActivityType)),UrlEncode(StringUtil.RTrim(AV35Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
         new k2bgetcontext(context ).execute( out  AV12Context) ;
         AV13BtnCaption = "Confirmar";
         AssignAttri(sPrefix, false, "AV13BtnCaption", AV13BtnCaption);
         AV14BtnTooltip = "Confirmar";
         AssignAttri(sPrefix, false, "AV14BtnTooltip", AV14BtnTooltip);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV13BtnCaption = "Actualizar";
            AssignAttri(sPrefix, false, "AV13BtnCaption", AV13BtnCaption);
            AV14BtnTooltip = "Actualizar";
            AssignAttri(sPrefix, false, "AV14BtnTooltip", AV14BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV13BtnCaption = "Confirmar";
            AssignAttri(sPrefix, false, "AV13BtnCaption", AV13BtnCaption);
            AV14BtnTooltip = "Confirmar";
            AssignAttri(sPrefix, false, "AV14BtnTooltip", AV14BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13BtnCaption = "Eliminar";
            AssignAttri(sPrefix, false, "AV13BtnCaption", AV13BtnCaption);
            AV14BtnTooltip = "Eliminar";
            AssignAttri(sPrefix, false, "AV14BtnTooltip", AV14BtnTooltip);
         }
         bttEnter_Caption = AV13BtnCaption;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Caption", bttEnter_Caption, true);
         bttEnter_Tooltiptext = AV14BtnTooltip;
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
         new k2bgettrncontextbyname(context ).execute(  "UsuarioSistema", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Usuario Sistema", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Usuario Sistema", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Usuario Sistema", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV36GXV1 = 1;
            AssignAttri(sPrefix, false, "AV36GXV1", StringUtil.LTrimStr( (decimal)(AV36GXV1), 8, 0));
            while ( AV36GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV36GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "DireccionId") == 0 )
               {
                  AV31Insert_DireccionId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV31Insert_DireccionId", StringUtil.LTrimStr( (decimal)(AV31Insert_DireccionId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "CentrodecostoId") == 0 )
               {
                  AV32Insert_CentrodecostoId = AV9TrnContextAtt.gxTpr_Attributevalue;
                  AssignAttri(sPrefix, false, "AV32Insert_CentrodecostoId", AV32Insert_CentrodecostoId);
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "DepartamentoId") == 0 )
               {
                  AV33Insert_DepartamentoId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV33Insert_DepartamentoId", StringUtil.LTrimStr( (decimal)(AV33Insert_DepartamentoId), 4, 0));
               }
               AV36GXV1 = (int)(AV36GXV1+1);
               AssignAttri(sPrefix, false, "AV36GXV1", StringUtil.LTrimStr( (decimal)(AV36GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtUsuarioSistemaIdentidad_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Class", edtUsuarioSistemaIdentidad_Class, true);
            }
            else
            {
               edtUsuarioSistemaIdentidad_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Class", edtUsuarioSistemaIdentidad_Class, true);
            }
         }
      }

      protected void E120A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV21AttributeValueItem.gxTpr_Attributename = "UsuarioSistemaId";
            AV21AttributeValueItem.gxTpr_Attributevalue = A99UsuarioSistemaId;
            AV20AttributeValue.Add(AV21AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "UsuarioSistema",  AV20AttributeValue) ;
         }
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La usuario sistema %1 fue creada", A101UsuarioSistemaIdentidad, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La usuario sistema %1 fue actualizada", A101UsuarioSistemaIdentidad, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La usuario sistema %1 fue eliminada", A101UsuarioSistemaIdentidad, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV22Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"UsuarioSistema",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV20AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "UsuarioSistema") ;
            }
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV10Navigation = AV8TrnContext.gxTpr_Afterinsert;
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
               AV10Navigation = AV8TrnContext.gxTpr_Afterupdate;
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
               AV10Navigation = AV8TrnContext.gxTpr_Afterdelete;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AttributeValue", AV20AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10Navigation", AV10Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", AV8TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV19encrypt = AV8TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV19encrypt)) )
         {
            GXt_char1 = AV19encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV19encrypt = GXt_char1;
         }
         if ( AV10Navigation.gxTpr_Aftertrn == 2 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem("K2BEntityServices: TransactionNavigation Invalid invocation method. Delete method cannot return using entity manager");
            }
            else
            {
               AV11DinamicObjToLink = StringUtil.Lower( AV8TrnContext.gxTpr_Entitymanagername);
               new k2bgetdynamicobjecttolink(context ).execute( ref  AV11DinamicObjToLink) ;
               if ( StringUtil.StrCmp(AV19encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(string)A99UsuarioSistemaId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A99UsuarioSistemaId = (string)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(string)A99UsuarioSistemaId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A99UsuarioSistemaId = (string)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(string)A99UsuarioSistemaId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A99UsuarioSistemaId = (string)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
         }
         else
         {
            if ( AV10Navigation.gxTpr_Aftertrn == 3 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV10Navigation.gxTpr_Mode)) )
               {
                  AV10Navigation.gxTpr_Mode = Gx_mode;
               }
               AV11DinamicObjToLink = StringUtil.Lower( AV10Navigation.gxTpr_Objecttolink);
               new k2bgetdynamicobjecttolink(context ).execute( ref  AV11DinamicObjToLink) ;
               if ( StringUtil.StrCmp(AV19encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(string)A99UsuarioSistemaId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A99UsuarioSistemaId = (string)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(string)A99UsuarioSistemaId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A99UsuarioSistemaId = (string)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(string)A99UsuarioSistemaId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A99UsuarioSistemaId = (string)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.RTrim(A99UsuarioSistemaId)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
            else
            {
               if ( AV10Navigation.gxTpr_Aftertrn != 5 )
               {
                  /* Execute user subroutine: 'K2BCLOSE' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
      }

      protected void E130A2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "UsuarioSistema") ;
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
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"UsuarioSistema"}, true);
         }
         else if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Stack") == 0 )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "CallerObject") == 0 )
         {
            AV15Url = AV8TrnContext.gxTpr_Callerurl;
            CallWebObject(formatLink(AV15Url) );
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

      protected void ZM0A11( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z101UsuarioSistemaIdentidad = T000A3_A101UsuarioSistemaIdentidad[0];
               Z100UsuarioSistemaNombre = T000A3_A100UsuarioSistemaNombre[0];
               Z263UsuarioSistemaGerencia = T000A3_A263UsuarioSistemaGerencia[0];
               Z257UsuarioSistemaDepartamento = T000A3_A257UsuarioSistemaDepartamento[0];
               Z264UsuarioSistemaTelefono = T000A3_A264UsuarioSistemaTelefono[0];
               Z265UsuarioSistemaEmail = T000A3_A265UsuarioSistemaEmail[0];
               Z266UsuarioSistemaFecha = T000A3_A266UsuarioSistemaFecha[0];
               Z258DireccionId = T000A3_A258DireccionId[0];
               Z259CentrodecostoId = T000A3_A259CentrodecostoId[0];
               Z260DepartamentoId = T000A3_A260DepartamentoId[0];
            }
            else
            {
               Z101UsuarioSistemaIdentidad = A101UsuarioSistemaIdentidad;
               Z100UsuarioSistemaNombre = A100UsuarioSistemaNombre;
               Z263UsuarioSistemaGerencia = A263UsuarioSistemaGerencia;
               Z257UsuarioSistemaDepartamento = A257UsuarioSistemaDepartamento;
               Z264UsuarioSistemaTelefono = A264UsuarioSistemaTelefono;
               Z265UsuarioSistemaEmail = A265UsuarioSistemaEmail;
               Z266UsuarioSistemaFecha = A266UsuarioSistemaFecha;
               Z258DireccionId = A258DireccionId;
               Z259CentrodecostoId = A259CentrodecostoId;
               Z260DepartamentoId = A260DepartamentoId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z99UsuarioSistemaId = A99UsuarioSistemaId;
            Z101UsuarioSistemaIdentidad = A101UsuarioSistemaIdentidad;
            Z100UsuarioSistemaNombre = A100UsuarioSistemaNombre;
            Z263UsuarioSistemaGerencia = A263UsuarioSistemaGerencia;
            Z257UsuarioSistemaDepartamento = A257UsuarioSistemaDepartamento;
            Z264UsuarioSistemaTelefono = A264UsuarioSistemaTelefono;
            Z265UsuarioSistemaEmail = A265UsuarioSistemaEmail;
            Z266UsuarioSistemaFecha = A266UsuarioSistemaFecha;
            Z258DireccionId = A258DireccionId;
            Z259CentrodecostoId = A259CentrodecostoId;
            Z260DepartamentoId = A260DepartamentoId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_258_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptdirecciones.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"DIRECCIONID"+"'), id:'"+sPrefix+"DIRECCIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_259_260_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptdepto.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"CENTRODECOSTOID"+"'), id:'"+sPrefix+"CENTRODECOSTOID"+"'"+",IOType:'out'}"+","+"{Ctrl:gx.dom.el('"+sPrefix+"DEPARTAMENTOID"+"'), id:'"+sPrefix+"DEPARTAMENTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30UsuarioSistemaId)) )
         {
            A99UsuarioSistemaId = AV30UsuarioSistemaId;
            AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30UsuarioSistemaId)) )
         {
            edtUsuarioSistemaId_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuarioSistemaId_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30UsuarioSistemaId)) )
         {
            edtUsuarioSistemaId_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_DireccionId) )
         {
            edtDireccionId_Enabled = 0;
            AssignProp(sPrefix, false, edtDireccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDireccionId_Enabled), 5, 0), true);
         }
         else
         {
            edtDireccionId_Enabled = 1;
            AssignProp(sPrefix, false, edtDireccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDireccionId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Insert_CentrodecostoId)) )
         {
            edtCentrodecostoId_Enabled = 0;
            AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         }
         else
         {
            edtCentrodecostoId_Enabled = 1;
            AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV33Insert_DepartamentoId) )
         {
            edtDepartamentoId_Enabled = 0;
            AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDepartamentoId_Enabled = 1;
            AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV33Insert_DepartamentoId) )
         {
            A260DepartamentoId = AV33Insert_DepartamentoId;
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32Insert_CentrodecostoId)) )
         {
            A259CentrodecostoId = AV32Insert_CentrodecostoId;
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_DireccionId) )
         {
            A258DireccionId = AV31Insert_DireccionId;
            AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A266UsuarioSistemaFecha) && ( Gx_BScreen == 0 ) )
         {
            A266UsuarioSistemaFecha = DateTimeUtil.Now( context);
            AssignAttri(sPrefix, false, "A266UsuarioSistemaFecha", context.localUtil.TToC( A266UsuarioSistemaFecha, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV35Pgmname = "UsuarioSistema";
            AssignAttri(sPrefix, false, "AV35Pgmname", AV35Pgmname);
            /* Using cursor T000A5 */
            pr_datastore2.execute(1, new Object[] {A259CentrodecostoId, A260DepartamentoId});
            A261DepartamentoNombre = T000A5_A261DepartamentoNombre[0];
            AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
            pr_datastore2.close(1);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  "Display",  "",  "EntityManagerDepto", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
               AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Link", edtDepartamentoNombre_Link, true);
            }
            /* Using cursor T000A4 */
            pr_datastore2.execute(0, new Object[] {A258DireccionId});
            A262DireccionDescripcion = T000A4_A262DireccionDescripcion[0];
            AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
            pr_datastore2.close(0);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Direcciones",  "Direcciones",  "Display",  "",  "EntityManagerDirecciones", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Link", edtDireccionDescripcion_Link, true);
            }
         }
      }

      protected void Load0A11( )
      {
         /* Using cursor T000A6 */
         pr_default.execute(2, new Object[] {A99UsuarioSistemaId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound11 = 1;
            A101UsuarioSistemaIdentidad = T000A6_A101UsuarioSistemaIdentidad[0];
            AssignAttri(sPrefix, false, "A101UsuarioSistemaIdentidad", A101UsuarioSistemaIdentidad);
            A100UsuarioSistemaNombre = T000A6_A100UsuarioSistemaNombre[0];
            AssignAttri(sPrefix, false, "A100UsuarioSistemaNombre", A100UsuarioSistemaNombre);
            A263UsuarioSistemaGerencia = T000A6_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = T000A6_n263UsuarioSistemaGerencia[0];
            AssignAttri(sPrefix, false, "A263UsuarioSistemaGerencia", A263UsuarioSistemaGerencia);
            A257UsuarioSistemaDepartamento = T000A6_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = T000A6_n257UsuarioSistemaDepartamento[0];
            AssignAttri(sPrefix, false, "A257UsuarioSistemaDepartamento", A257UsuarioSistemaDepartamento);
            A264UsuarioSistemaTelefono = T000A6_A264UsuarioSistemaTelefono[0];
            AssignAttri(sPrefix, false, "A264UsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(A264UsuarioSistemaTelefono), 9, 0));
            A265UsuarioSistemaEmail = T000A6_A265UsuarioSistemaEmail[0];
            AssignAttri(sPrefix, false, "A265UsuarioSistemaEmail", A265UsuarioSistemaEmail);
            A266UsuarioSistemaFecha = T000A6_A266UsuarioSistemaFecha[0];
            A258DireccionId = T000A6_A258DireccionId[0];
            AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
            A259CentrodecostoId = T000A6_A259CentrodecostoId[0];
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
            A260DepartamentoId = T000A6_A260DepartamentoId[0];
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
            ZM0A11( -20) ;
         }
         pr_default.close(2);
         OnLoadActions0A11( ) ;
      }

      protected void OnLoadActions0A11( )
      {
         AV35Pgmname = "UsuarioSistema";
         AssignAttri(sPrefix, false, "AV35Pgmname", AV35Pgmname);
         /* Using cursor T000A4 */
         pr_datastore2.execute(0, new Object[] {A258DireccionId});
         A262DireccionDescripcion = T000A4_A262DireccionDescripcion[0];
         AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
         pr_datastore2.close(0);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Direcciones",  "Direcciones",  "Display",  "",  "EntityManagerDirecciones", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode11, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Link", edtDireccionDescripcion_Link, true);
         }
         /* Using cursor T000A5 */
         pr_datastore2.execute(1, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         A261DepartamentoNombre = T000A5_A261DepartamentoNombre[0];
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         pr_datastore2.close(1);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  "Display",  "",  "EntityManagerDepto", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode11, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
            AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Link", edtDepartamentoNombre_Link, true);
         }
      }

      protected void CheckExtendedTable0A11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV35Pgmname = "UsuarioSistema";
         AssignAttri(sPrefix, false, "AV35Pgmname", AV35Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A101UsuarioSistemaIdentidad)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Identidad", "", "", "", "", "", "", "", ""), 1, "USUARIOSISTEMAIDENTIDAD");
            AnyError = 1;
            GX_FocusControl = edtUsuarioSistemaIdentidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A265UsuarioSistemaEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Email no coincide con el patrón especificado", "OutOfRange", 1, "USUARIOSISTEMAEMAIL");
            AnyError = 1;
            GX_FocusControl = edtUsuarioSistemaEmail_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000A4 */
         pr_datastore2.execute(0, new Object[] {A258DireccionId});
         if ( (pr_datastore2.getStatus(0) == 101) )
         {
            GX_msglist.addItem("No existe 'Direcciones'.", "ForeignKeyNotFound", 1, "DIRECCIONID");
            AnyError = 1;
            GX_FocusControl = edtDireccionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A262DireccionDescripcion = T000A4_A262DireccionDescripcion[0];
         AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
         pr_datastore2.close(0);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Direcciones",  "Direcciones",  "Display",  "",  "EntityManagerDirecciones", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Link", edtDireccionDescripcion_Link, true);
         }
         /* Using cursor T000A5 */
         pr_datastore2.execute(1, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(1) == 101) )
         {
            GX_msglist.addItem("No existe 'Depto'.", "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtCentrodecostoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A261DepartamentoNombre = T000A5_A261DepartamentoNombre[0];
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         pr_datastore2.close(1);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  "Display",  "",  "EntityManagerDepto", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
            AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Link", edtDepartamentoNombre_Link, true);
         }
      }

      protected void CloseExtendedTableCursors0A11( )
      {
         pr_datastore2.close(0);
         pr_datastore2.close(1);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_21( short A258DireccionId )
      {
         /* Using cursor T000A7 */
         pr_datastore2.execute(2, new Object[] {A258DireccionId});
         if ( (pr_datastore2.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Direcciones'.", "ForeignKeyNotFound", 1, "DIRECCIONID");
            AnyError = 1;
            GX_FocusControl = edtDireccionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A262DireccionDescripcion = T000A7_A262DireccionDescripcion[0];
         AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A262DireccionDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore2.getStatus(2) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore2.close(2);
      }

      protected void gxLoad_22( string A259CentrodecostoId ,
                                short A260DepartamentoId )
      {
         /* Using cursor T000A8 */
         pr_datastore2.execute(3, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Depto'.", "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtCentrodecostoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A261DepartamentoNombre = T000A8_A261DepartamentoNombre[0];
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A261DepartamentoNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore2.getStatus(3) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore2.close(3);
      }

      protected void GetKey0A11( )
      {
         /* Using cursor T000A9 */
         pr_default.execute(3, new Object[] {A99UsuarioSistemaId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A99UsuarioSistemaId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A11( 20) ;
            RcdFound11 = 1;
            A99UsuarioSistemaId = T000A3_A99UsuarioSistemaId[0];
            AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
            A101UsuarioSistemaIdentidad = T000A3_A101UsuarioSistemaIdentidad[0];
            AssignAttri(sPrefix, false, "A101UsuarioSistemaIdentidad", A101UsuarioSistemaIdentidad);
            A100UsuarioSistemaNombre = T000A3_A100UsuarioSistemaNombre[0];
            AssignAttri(sPrefix, false, "A100UsuarioSistemaNombre", A100UsuarioSistemaNombre);
            A263UsuarioSistemaGerencia = T000A3_A263UsuarioSistemaGerencia[0];
            n263UsuarioSistemaGerencia = T000A3_n263UsuarioSistemaGerencia[0];
            AssignAttri(sPrefix, false, "A263UsuarioSistemaGerencia", A263UsuarioSistemaGerencia);
            A257UsuarioSistemaDepartamento = T000A3_A257UsuarioSistemaDepartamento[0];
            n257UsuarioSistemaDepartamento = T000A3_n257UsuarioSistemaDepartamento[0];
            AssignAttri(sPrefix, false, "A257UsuarioSistemaDepartamento", A257UsuarioSistemaDepartamento);
            A264UsuarioSistemaTelefono = T000A3_A264UsuarioSistemaTelefono[0];
            AssignAttri(sPrefix, false, "A264UsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(A264UsuarioSistemaTelefono), 9, 0));
            A265UsuarioSistemaEmail = T000A3_A265UsuarioSistemaEmail[0];
            AssignAttri(sPrefix, false, "A265UsuarioSistemaEmail", A265UsuarioSistemaEmail);
            A266UsuarioSistemaFecha = T000A3_A266UsuarioSistemaFecha[0];
            A258DireccionId = T000A3_A258DireccionId[0];
            AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
            A259CentrodecostoId = T000A3_A259CentrodecostoId[0];
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
            A260DepartamentoId = T000A3_A260DepartamentoId[0];
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
            Z99UsuarioSistemaId = A99UsuarioSistemaId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0A11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0A11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0A11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A11( ) ;
         if ( RcdFound11 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T000A10 */
         pr_default.execute(4, new Object[] {A99UsuarioSistemaId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000A10_A99UsuarioSistemaId[0], A99UsuarioSistemaId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000A10_A99UsuarioSistemaId[0], A99UsuarioSistemaId) > 0 ) ) )
            {
               A99UsuarioSistemaId = T000A10_A99UsuarioSistemaId[0];
               AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
               RcdFound11 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000A11 */
         pr_default.execute(5, new Object[] {A99UsuarioSistemaId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000A11_A99UsuarioSistemaId[0], A99UsuarioSistemaId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000A11_A99UsuarioSistemaId[0], A99UsuarioSistemaId) < 0 ) ) )
            {
               A99UsuarioSistemaId = T000A11_A99UsuarioSistemaId[0];
               AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
               RcdFound11 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuarioSistemaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0A11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( StringUtil.StrCmp(A99UsuarioSistemaId, Z99UsuarioSistemaId) != 0 )
               {
                  A99UsuarioSistemaId = Z99UsuarioSistemaId;
                  AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOSISTEMAID");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioSistemaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuarioSistemaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0A11( ) ;
                  GX_FocusControl = edtUsuarioSistemaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A99UsuarioSistemaId, Z99UsuarioSistemaId) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtUsuarioSistemaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0A11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOSISTEMAID");
                     AnyError = 1;
                     GX_FocusControl = edtUsuarioSistemaId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUsuarioSistemaId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0A11( ) ;
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
         if ( StringUtil.StrCmp(A99UsuarioSistemaId, Z99UsuarioSistemaId) != 0 )
         {
            A99UsuarioSistemaId = Z99UsuarioSistemaId;
            AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOSISTEMAID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioSistemaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuarioSistemaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0A11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A99UsuarioSistemaId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UsuarioSistema"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z101UsuarioSistemaIdentidad, T000A2_A101UsuarioSistemaIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z100UsuarioSistemaNombre, T000A2_A100UsuarioSistemaNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z263UsuarioSistemaGerencia, T000A2_A263UsuarioSistemaGerencia[0]) != 0 ) || ( StringUtil.StrCmp(Z257UsuarioSistemaDepartamento, T000A2_A257UsuarioSistemaDepartamento[0]) != 0 ) || ( Z264UsuarioSistemaTelefono != T000A2_A264UsuarioSistemaTelefono[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z265UsuarioSistemaEmail, T000A2_A265UsuarioSistemaEmail[0]) != 0 ) || ( Z266UsuarioSistemaFecha != T000A2_A266UsuarioSistemaFecha[0] ) || ( Z258DireccionId != T000A2_A258DireccionId[0] ) || ( StringUtil.StrCmp(Z259CentrodecostoId, T000A2_A259CentrodecostoId[0]) != 0 ) || ( Z260DepartamentoId != T000A2_A260DepartamentoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z101UsuarioSistemaIdentidad, T000A2_A101UsuarioSistemaIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z101UsuarioSistemaIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A101UsuarioSistemaIdentidad[0]);
               }
               if ( StringUtil.StrCmp(Z100UsuarioSistemaNombre, T000A2_A100UsuarioSistemaNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaNombre");
                  GXUtil.WriteLogRaw("Old: ",Z100UsuarioSistemaNombre);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A100UsuarioSistemaNombre[0]);
               }
               if ( StringUtil.StrCmp(Z263UsuarioSistemaGerencia, T000A2_A263UsuarioSistemaGerencia[0]) != 0 )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaGerencia");
                  GXUtil.WriteLogRaw("Old: ",Z263UsuarioSistemaGerencia);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A263UsuarioSistemaGerencia[0]);
               }
               if ( StringUtil.StrCmp(Z257UsuarioSistemaDepartamento, T000A2_A257UsuarioSistemaDepartamento[0]) != 0 )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaDepartamento");
                  GXUtil.WriteLogRaw("Old: ",Z257UsuarioSistemaDepartamento);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A257UsuarioSistemaDepartamento[0]);
               }
               if ( Z264UsuarioSistemaTelefono != T000A2_A264UsuarioSistemaTelefono[0] )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z264UsuarioSistemaTelefono);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A264UsuarioSistemaTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z265UsuarioSistemaEmail, T000A2_A265UsuarioSistemaEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaEmail");
                  GXUtil.WriteLogRaw("Old: ",Z265UsuarioSistemaEmail);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A265UsuarioSistemaEmail[0]);
               }
               if ( Z266UsuarioSistemaFecha != T000A2_A266UsuarioSistemaFecha[0] )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"UsuarioSistemaFecha");
                  GXUtil.WriteLogRaw("Old: ",Z266UsuarioSistemaFecha);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A266UsuarioSistemaFecha[0]);
               }
               if ( Z258DireccionId != T000A2_A258DireccionId[0] )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"DireccionId");
                  GXUtil.WriteLogRaw("Old: ",Z258DireccionId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A258DireccionId[0]);
               }
               if ( StringUtil.StrCmp(Z259CentrodecostoId, T000A2_A259CentrodecostoId[0]) != 0 )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"CentrodecostoId");
                  GXUtil.WriteLogRaw("Old: ",Z259CentrodecostoId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A259CentrodecostoId[0]);
               }
               if ( Z260DepartamentoId != T000A2_A260DepartamentoId[0] )
               {
                  GXUtil.WriteLog("usuariosistema:[seudo value changed for attri]"+"DepartamentoId");
                  GXUtil.WriteLogRaw("Old: ",Z260DepartamentoId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A260DepartamentoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UsuarioSistema"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A11( )
      {
         if ( ! IsAuthorized("usuariosistema_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A11( 0) ;
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A12 */
                     pr_default.execute(6, new Object[] {A99UsuarioSistemaId, A101UsuarioSistemaIdentidad, A100UsuarioSistemaNombre, n263UsuarioSistemaGerencia, A263UsuarioSistemaGerencia, n257UsuarioSistemaDepartamento, A257UsuarioSistemaDepartamento, A264UsuarioSistemaTelefono, A265UsuarioSistemaEmail, A266UsuarioSistemaFecha, A258DireccionId, A259CentrodecostoId, A260DepartamentoId});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("UsuarioSistema");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption0A0( ) ;
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
               Load0A11( ) ;
            }
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void Update0A11( )
      {
         if ( ! IsAuthorized("usuariosistema_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A13 */
                     pr_default.execute(7, new Object[] {A101UsuarioSistemaIdentidad, A100UsuarioSistemaNombre, n263UsuarioSistemaGerencia, A263UsuarioSistemaGerencia, n257UsuarioSistemaDepartamento, A257UsuarioSistemaDepartamento, A264UsuarioSistemaTelefono, A265UsuarioSistemaEmail, A266UsuarioSistemaFecha, A258DireccionId, A259CentrodecostoId, A260DepartamentoId, A99UsuarioSistemaId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("UsuarioSistema");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UsuarioSistema"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A11( ) ;
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
            EndLevel0A11( ) ;
         }
         CloseExtendedTableCursors0A11( ) ;
      }

      protected void DeferredUpdate0A11( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("usuariosistema_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A11( ) ;
            AfterConfirm0A11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A14 */
                  pr_default.execute(8, new Object[] {A99UsuarioSistemaId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("UsuarioSistema");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0A11( ) ;
         Gx_mode = sMode11;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV35Pgmname = "UsuarioSistema";
            AssignAttri(sPrefix, false, "AV35Pgmname", AV35Pgmname);
            /* Using cursor T000A15 */
            pr_datastore2.execute(4, new Object[] {A258DireccionId});
            A262DireccionDescripcion = T000A15_A262DireccionDescripcion[0];
            AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
            pr_datastore2.close(4);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Direcciones",  "Direcciones",  "Display",  "",  "EntityManagerDirecciones", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Link", edtDireccionDescripcion_Link, true);
            }
            /* Using cursor T000A16 */
            pr_datastore2.execute(5, new Object[] {A259CentrodecostoId, A260DepartamentoId});
            A261DepartamentoNombre = T000A16_A261DepartamentoNombre[0];
            AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
            pr_datastore2.close(5);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  "Display",  "",  "EntityManagerDepto", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
               AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Link", edtDepartamentoNombre_Link, true);
            }
         }
      }

      protected void EndLevel0A11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_datastore2.close(4);
            pr_datastore2.close(5);
            context.CommitDataStores("usuariosistema",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_datastore2.close(4);
            pr_datastore2.close(5);
            context.RollbackDataStores("usuariosistema",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A11( )
      {
         /* Scan By routine */
         /* Using cursor T000A17 */
         pr_default.execute(9);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound11 = 1;
            A99UsuarioSistemaId = T000A17_A99UsuarioSistemaId[0];
            AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A11( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound11 = 1;
            A99UsuarioSistemaId = T000A17_A99UsuarioSistemaId[0];
            AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
         }
      }

      protected void ScanEnd0A11( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0A11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A11( )
      {
         edtUsuarioSistemaId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaId_Enabled), 5, 0), true);
         edtUsuarioSistemaIdentidad_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaIdentidad_Enabled), 5, 0), true);
         edtUsuarioSistemaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaNombre_Enabled), 5, 0), true);
         edtUsuarioSistemaGerencia_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaGerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaGerencia_Enabled), 5, 0), true);
         edtUsuarioSistemaDepartamento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaDepartamento_Enabled), 5, 0), true);
         edtUsuarioSistemaTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaTelefono_Enabled), 5, 0), true);
         edtUsuarioSistemaEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioSistemaEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioSistemaEmail_Enabled), 5, 0), true);
         edtDireccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtDireccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDireccionId_Enabled), 5, 0), true);
         edtDireccionDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDireccionDescripcion_Enabled), 5, 0), true);
         edtCentrodecostoId_Enabled = 0;
         AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         edtDepartamentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A11( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188321377", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuariosistema.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV30UsuarioSistemaId))}, new string[] {"Gx_mode","UsuarioSistemaId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"UsuarioSistema");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("usuariosistema:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z99UsuarioSistemaId", Z99UsuarioSistemaId);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z101UsuarioSistemaIdentidad", Z101UsuarioSistemaIdentidad);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z100UsuarioSistemaNombre", Z100UsuarioSistemaNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z263UsuarioSistemaGerencia", Z263UsuarioSistemaGerencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z257UsuarioSistemaDepartamento", Z257UsuarioSistemaDepartamento);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z264UsuarioSistemaTelefono", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z264UsuarioSistemaTelefono), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z265UsuarioSistemaEmail", Z265UsuarioSistemaEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z266UsuarioSistemaFecha", context.localUtil.TToC( Z266UsuarioSistemaFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z258DireccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z258DireccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z259CentrodecostoId", Z259CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z260DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z260DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV30UsuarioSistemaId", wcpOAV30UsuarioSistemaId);
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N258DireccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A258DireccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N259CentrodecostoId", A259CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"N260DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A260DepartamentoId), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMODE", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV20AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV20AttributeValue);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vATTRIBUTEVALUE", GetSecureSignedToken( sPrefix, AV20AttributeValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV10Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV10Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV10Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOSISTEMAID", AV30UsuarioSistemaId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_DIRECCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31Insert_DireccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_CENTRODECOSTOID", AV32Insert_CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_DEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33Insert_DepartamentoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSISTEMAFECHA", context.localUtil.TToC( A266UsuarioSistemaFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV35Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0A11( )
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
         return "UsuarioSistema" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario Sistema" ;
      }

      protected void InitializeNonKey0A11( )
      {
         A258DireccionId = 0;
         AssignAttri(sPrefix, false, "A258DireccionId", StringUtil.LTrimStr( (decimal)(A258DireccionId), 4, 0));
         A259CentrodecostoId = "";
         AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
         A260DepartamentoId = 0;
         AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         A101UsuarioSistemaIdentidad = "";
         AssignAttri(sPrefix, false, "A101UsuarioSistemaIdentidad", A101UsuarioSistemaIdentidad);
         A100UsuarioSistemaNombre = "";
         AssignAttri(sPrefix, false, "A100UsuarioSistemaNombre", A100UsuarioSistemaNombre);
         A263UsuarioSistemaGerencia = "";
         n263UsuarioSistemaGerencia = false;
         AssignAttri(sPrefix, false, "A263UsuarioSistemaGerencia", A263UsuarioSistemaGerencia);
         n263UsuarioSistemaGerencia = (String.IsNullOrEmpty(StringUtil.RTrim( A263UsuarioSistemaGerencia)) ? true : false);
         A257UsuarioSistemaDepartamento = "";
         n257UsuarioSistemaDepartamento = false;
         AssignAttri(sPrefix, false, "A257UsuarioSistemaDepartamento", A257UsuarioSistemaDepartamento);
         n257UsuarioSistemaDepartamento = (String.IsNullOrEmpty(StringUtil.RTrim( A257UsuarioSistemaDepartamento)) ? true : false);
         A264UsuarioSistemaTelefono = 0;
         AssignAttri(sPrefix, false, "A264UsuarioSistemaTelefono", StringUtil.LTrimStr( (decimal)(A264UsuarioSistemaTelefono), 9, 0));
         A265UsuarioSistemaEmail = "";
         AssignAttri(sPrefix, false, "A265UsuarioSistemaEmail", A265UsuarioSistemaEmail);
         A262DireccionDescripcion = "";
         AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
         A261DepartamentoNombre = "";
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         A266UsuarioSistemaFecha = DateTimeUtil.Now( context);
         AssignAttri(sPrefix, false, "A266UsuarioSistemaFecha", context.localUtil.TToC( A266UsuarioSistemaFecha, 10, 5, 0, 3, "/", ":", " "));
         Z101UsuarioSistemaIdentidad = "";
         Z100UsuarioSistemaNombre = "";
         Z263UsuarioSistemaGerencia = "";
         Z257UsuarioSistemaDepartamento = "";
         Z264UsuarioSistemaTelefono = 0;
         Z265UsuarioSistemaEmail = "";
         Z266UsuarioSistemaFecha = (DateTime)(DateTime.MinValue);
         Z258DireccionId = 0;
         Z259CentrodecostoId = "";
         Z260DepartamentoId = 0;
      }

      protected void InitAll0A11( )
      {
         A99UsuarioSistemaId = "";
         AssignAttri(sPrefix, false, "A99UsuarioSistemaId", A99UsuarioSistemaId);
         InitializeNonKey0A11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A266UsuarioSistemaFecha = i266UsuarioSistemaFecha;
         AssignAttri(sPrefix, false, "A266UsuarioSistemaFecha", context.localUtil.TToC( A266UsuarioSistemaFecha, 10, 5, 0, 3, "/", ":", " "));
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV30UsuarioSistemaId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "usuariosistema", GetJustCreated( ));
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
            AV30UsuarioSistemaId = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV30UsuarioSistemaId", AV30UsuarioSistemaId);
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV30UsuarioSistemaId = cgiGet( sPrefix+"wcpOAV30UsuarioSistemaId");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV30UsuarioSistemaId, wcpOAV30UsuarioSistemaId) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV30UsuarioSistemaId = AV30UsuarioSistemaId;
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
         sCtrlAV30UsuarioSistemaId = cgiGet( sPrefix+"AV30UsuarioSistemaId_CTRL");
         if ( StringUtil.Len( sCtrlAV30UsuarioSistemaId) > 0 )
         {
            AV30UsuarioSistemaId = cgiGet( sCtrlAV30UsuarioSistemaId);
            AssignAttri(sPrefix, false, "AV30UsuarioSistemaId", AV30UsuarioSistemaId);
         }
         else
         {
            AV30UsuarioSistemaId = cgiGet( sPrefix+"AV30UsuarioSistemaId_PARM");
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV30UsuarioSistemaId_PARM", AV30UsuarioSistemaId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV30UsuarioSistemaId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV30UsuarioSistemaId_CTRL", StringUtil.RTrim( sCtrlAV30UsuarioSistemaId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418832141", true, true);
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
         context.AddJavascriptSource("usuariosistema.js", "?202418832141", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtUsuarioSistemaId_Internalname = sPrefix+"USUARIOSISTEMAID";
         divK2btoolstable_attributecontainerusuariosistemaid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMAID";
         edtUsuarioSistemaIdentidad_Internalname = sPrefix+"USUARIOSISTEMAIDENTIDAD";
         divK2btoolstable_attributecontainerusuariosistemaidentidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMAIDENTIDAD";
         edtUsuarioSistemaNombre_Internalname = sPrefix+"USUARIOSISTEMANOMBRE";
         divK2btoolstable_attributecontainerusuariosistemanombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMANOMBRE";
         edtUsuarioSistemaGerencia_Internalname = sPrefix+"USUARIOSISTEMAGERENCIA";
         divK2btoolstable_attributecontainerusuariosistemagerencia_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMAGERENCIA";
         edtUsuarioSistemaDepartamento_Internalname = sPrefix+"USUARIOSISTEMADEPARTAMENTO";
         divK2btoolstable_attributecontainerusuariosistemadepartamento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMADEPARTAMENTO";
         edtUsuarioSistemaTelefono_Internalname = sPrefix+"USUARIOSISTEMATELEFONO";
         divK2btoolstable_attributecontainerusuariosistematelefono_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMATELEFONO";
         edtUsuarioSistemaEmail_Internalname = sPrefix+"USUARIOSISTEMAEMAIL";
         divK2btoolstable_attributecontainerusuariosistemaemail_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOSISTEMAEMAIL";
         edtDireccionId_Internalname = sPrefix+"DIRECCIONID";
         divK2btoolstable_attributecontainerdireccionid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDIRECCIONID";
         edtDireccionDescripcion_Internalname = sPrefix+"DIRECCIONDESCRIPCION";
         divK2btoolstable_attributecontainerdirecciondescripcion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDIRECCIONDESCRIPCION";
         edtCentrodecostoId_Internalname = sPrefix+"CENTRODECOSTOID";
         divK2btoolstable_attributecontainercentrodecostoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERCENTRODECOSTOID";
         edtDepartamentoId_Internalname = sPrefix+"DEPARTAMENTOID";
         divK2btoolstable_attributecontainerdepartamentoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDEPARTAMENTOID";
         edtDepartamentoNombre_Internalname = sPrefix+"DEPARTAMENTONOMBRE";
         divK2btoolstable_attributecontainerdepartamentonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERDEPARTAMENTONOMBRE";
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
         imgprompt_258_Internalname = sPrefix+"PROMPT_258";
         imgprompt_259_260_Internalname = sPrefix+"PROMPT_259_260";
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
         Form.Caption = "Usuario Sistema";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtDepartamentoNombre_Link = "";
         edtDepartamentoNombre_Enabled = 0;
         imgprompt_259_260_Visible = 1;
         imgprompt_259_260_Link = "";
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 1;
         edtCentrodecostoId_Jsonclick = "";
         edtCentrodecostoId_Enabled = 1;
         edtDireccionDescripcion_Link = "";
         edtDireccionDescripcion_Enabled = 0;
         imgprompt_258_Visible = 1;
         imgprompt_258_Link = "";
         edtDireccionId_Jsonclick = "";
         edtDireccionId_Enabled = 1;
         edtUsuarioSistemaEmail_Jsonclick = "";
         edtUsuarioSistemaEmail_Enabled = 1;
         edtUsuarioSistemaTelefono_Jsonclick = "";
         edtUsuarioSistemaTelefono_Enabled = 1;
         edtUsuarioSistemaDepartamento_Enabled = 1;
         edtUsuarioSistemaGerencia_Enabled = 1;
         edtUsuarioSistemaNombre_Jsonclick = "";
         edtUsuarioSistemaNombre_Enabled = 1;
         edtUsuarioSistemaIdentidad_Jsonclick = "";
         edtUsuarioSistemaIdentidad_Class = "Attribute_Trn Attribute_Required";
         edtUsuarioSistemaIdentidad_Enabled = 1;
         edtUsuarioSistemaId_Jsonclick = "";
         edtUsuarioSistemaId_Enabled = 1;
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

      protected void GXASA2620A11( short A258DireccionId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Direcciones",  "Direcciones",  "Display",  "",  "EntityManagerDirecciones", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Link", edtDireccionDescripcion_Link, true);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GXASA2610A11( string A259CentrodecostoId ,
                                   short A260DepartamentoId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  "Display",  "",  "EntityManagerDepto", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
            AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Link", edtDepartamentoNombre_Link, true);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
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

      public void Valid_Direccionid( )
      {
         /* Using cursor T000A15 */
         pr_datastore2.execute(4, new Object[] {A258DireccionId});
         if ( (pr_datastore2.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Direcciones'.", "ForeignKeyNotFound", 1, "DIRECCIONID");
            AnyError = 1;
            GX_FocusControl = edtDireccionId_Internalname;
         }
         A262DireccionDescripcion = T000A15_A262DireccionDescripcion[0];
         pr_datastore2.close(4);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Direcciones",  "Direcciones",  "Display",  "",  "EntityManagerDirecciones", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDireccionDescripcion_Link = formatLink("entitymanagerdirecciones.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A258DireccionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","DireccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A262DireccionDescripcion", A262DireccionDescripcion);
         AssignProp(sPrefix, false, edtDireccionDescripcion_Internalname, "Link", edtDireccionDescripcion_Link, true);
      }

      public void Valid_Departamentoid( )
      {
         /* Using cursor T000A16 */
         pr_datastore2.execute(5, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Depto'.", "ForeignKeyNotFound", 1, "DEPARTAMENTOID");
            AnyError = 1;
            GX_FocusControl = edtCentrodecostoId_Internalname;
         }
         A261DepartamentoNombre = T000A16_A261DepartamentoNombre[0];
         pr_datastore2.close(5);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  "Display",  "",  "EntityManagerDepto", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtDepartamentoNombre_Link = formatLink("entitymanagerdepto.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","CentrodecostoId","DepartamentoId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Link", edtDepartamentoNombre_Link, true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV30UsuarioSistemaId',fld:'vUSUARIOSISTEMAID',pic:''}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120A2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A101UsuarioSistemaIdentidad',fld:'USUARIOSISTEMAIDENTIDAD',pic:''},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A99UsuarioSistemaId',fld:'USUARIOSISTEMAID',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130A2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSISTEMAID","{handler:'Valid_Usuariosistemaid',iparms:[]");
         setEventMetadata("VALID_USUARIOSISTEMAID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSISTEMAIDENTIDAD","{handler:'Valid_Usuariosistemaidentidad',iparms:[]");
         setEventMetadata("VALID_USUARIOSISTEMAIDENTIDAD",",oparms:[]}");
         setEventMetadata("VALID_USUARIOSISTEMAEMAIL","{handler:'Valid_Usuariosistemaemail',iparms:[]");
         setEventMetadata("VALID_USUARIOSISTEMAEMAIL",",oparms:[]}");
         setEventMetadata("VALID_DIRECCIONID","{handler:'Valid_Direccionid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A258DireccionId',fld:'DIRECCIONID',pic:'ZZZ9'},{av:'A262DireccionDescripcion',fld:'DIRECCIONDESCRIPCION',pic:''}]");
         setEventMetadata("VALID_DIRECCIONID",",oparms:[{av:'A262DireccionDescripcion',fld:'DIRECCIONDESCRIPCION',pic:''},{av:'edtDireccionDescripcion_Link',ctrl:'DIRECCIONDESCRIPCION',prop:'Link'}]}");
         setEventMetadata("VALID_CENTRODECOSTOID","{handler:'Valid_Centrodecostoid',iparms:[]");
         setEventMetadata("VALID_CENTRODECOSTOID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A259CentrodecostoId',fld:'CENTRODECOSTOID',pic:''},{av:'A260DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZ9'},{av:'A261DepartamentoNombre',fld:'DEPARTAMENTONOMBRE',pic:''}]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[{av:'A261DepartamentoNombre',fld:'DEPARTAMENTONOMBRE',pic:''},{av:'edtDepartamentoNombre_Link',ctrl:'DEPARTAMENTONOMBRE',prop:'Link'}]}");
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
         pr_datastore2.close(4);
         pr_datastore2.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV30UsuarioSistemaId = "";
         Z99UsuarioSistemaId = "";
         Z101UsuarioSistemaIdentidad = "";
         Z100UsuarioSistemaNombre = "";
         Z263UsuarioSistemaGerencia = "";
         Z257UsuarioSistemaDepartamento = "";
         Z265UsuarioSistemaEmail = "";
         Z266UsuarioSistemaFecha = (DateTime)(DateTime.MinValue);
         Z259CentrodecostoId = "";
         N259CentrodecostoId = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A259CentrodecostoId = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         sXEvt = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         A99UsuarioSistemaId = "";
         TempTags = "";
         A101UsuarioSistemaIdentidad = "";
         A100UsuarioSistemaNombre = "";
         A263UsuarioSistemaGerencia = "";
         A257UsuarioSistemaDepartamento = "";
         A265UsuarioSistemaEmail = "";
         sImgUrl = "";
         A262DireccionDescripcion = "";
         A261DepartamentoNombre = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         A266UsuarioSistemaFecha = (DateTime)(DateTime.MinValue);
         AV32Insert_CentrodecostoId = "";
         AV35Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode11 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV16StandardActivityType = "";
         AV17UserActivityType = "";
         AV12Context = new SdtK2BContext(context);
         AV13BtnCaption = "";
         AV14BtnTooltip = "";
         AV8TrnContext = new SdtK2BTrnContext(context);
         AV9TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV24HttpRequest = new GxHttpRequest( context);
         AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV19encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV15Url = "";
         T000A5_A261DepartamentoNombre = new string[] {""} ;
         T000A4_A262DireccionDescripcion = new string[] {""} ;
         T000A6_A99UsuarioSistemaId = new string[] {""} ;
         T000A6_A101UsuarioSistemaIdentidad = new string[] {""} ;
         T000A6_A100UsuarioSistemaNombre = new string[] {""} ;
         T000A6_A263UsuarioSistemaGerencia = new string[] {""} ;
         T000A6_n263UsuarioSistemaGerencia = new bool[] {false} ;
         T000A6_A257UsuarioSistemaDepartamento = new string[] {""} ;
         T000A6_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         T000A6_A264UsuarioSistemaTelefono = new int[1] ;
         T000A6_A265UsuarioSistemaEmail = new string[] {""} ;
         T000A6_A266UsuarioSistemaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A6_A258DireccionId = new short[1] ;
         T000A6_A259CentrodecostoId = new string[] {""} ;
         T000A6_A260DepartamentoId = new short[1] ;
         T000A7_A262DireccionDescripcion = new string[] {""} ;
         T000A8_A261DepartamentoNombre = new string[] {""} ;
         T000A9_A99UsuarioSistemaId = new string[] {""} ;
         T000A3_A99UsuarioSistemaId = new string[] {""} ;
         T000A3_A101UsuarioSistemaIdentidad = new string[] {""} ;
         T000A3_A100UsuarioSistemaNombre = new string[] {""} ;
         T000A3_A263UsuarioSistemaGerencia = new string[] {""} ;
         T000A3_n263UsuarioSistemaGerencia = new bool[] {false} ;
         T000A3_A257UsuarioSistemaDepartamento = new string[] {""} ;
         T000A3_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         T000A3_A264UsuarioSistemaTelefono = new int[1] ;
         T000A3_A265UsuarioSistemaEmail = new string[] {""} ;
         T000A3_A266UsuarioSistemaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A3_A258DireccionId = new short[1] ;
         T000A3_A259CentrodecostoId = new string[] {""} ;
         T000A3_A260DepartamentoId = new short[1] ;
         T000A10_A99UsuarioSistemaId = new string[] {""} ;
         T000A11_A99UsuarioSistemaId = new string[] {""} ;
         T000A2_A99UsuarioSistemaId = new string[] {""} ;
         T000A2_A101UsuarioSistemaIdentidad = new string[] {""} ;
         T000A2_A100UsuarioSistemaNombre = new string[] {""} ;
         T000A2_A263UsuarioSistemaGerencia = new string[] {""} ;
         T000A2_n263UsuarioSistemaGerencia = new bool[] {false} ;
         T000A2_A257UsuarioSistemaDepartamento = new string[] {""} ;
         T000A2_n257UsuarioSistemaDepartamento = new bool[] {false} ;
         T000A2_A264UsuarioSistemaTelefono = new int[1] ;
         T000A2_A265UsuarioSistemaEmail = new string[] {""} ;
         T000A2_A266UsuarioSistemaFecha = new DateTime[] {DateTime.MinValue} ;
         T000A2_A258DireccionId = new short[1] ;
         T000A2_A259CentrodecostoId = new string[] {""} ;
         T000A2_A260DepartamentoId = new short[1] ;
         T000A15_A262DireccionDescripcion = new string[] {""} ;
         T000A16_A261DepartamentoNombre = new string[] {""} ;
         T000A17_A99UsuarioSistemaId = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i266UsuarioSistemaFecha = (DateTime)(DateTime.MinValue);
         sCtrlGx_mode = "";
         sCtrlAV30UsuarioSistemaId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Z262DireccionDescripcion = "";
         Z261DepartamentoNombre = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.usuariosistema__datastore2(),
            new Object[][] {
                new Object[] {
               T000A4_A262DireccionDescripcion
               }
               , new Object[] {
               T000A5_A261DepartamentoNombre
               }
               , new Object[] {
               T000A7_A262DireccionDescripcion
               }
               , new Object[] {
               T000A8_A261DepartamentoNombre
               }
               , new Object[] {
               T000A15_A262DireccionDescripcion
               }
               , new Object[] {
               T000A16_A261DepartamentoNombre
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.usuariosistema__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.usuariosistema__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuariosistema__default(),
            new Object[][] {
                new Object[] {
               T000A2_A99UsuarioSistemaId, T000A2_A101UsuarioSistemaIdentidad, T000A2_A100UsuarioSistemaNombre, T000A2_A263UsuarioSistemaGerencia, T000A2_n263UsuarioSistemaGerencia, T000A2_A257UsuarioSistemaDepartamento, T000A2_n257UsuarioSistemaDepartamento, T000A2_A264UsuarioSistemaTelefono, T000A2_A265UsuarioSistemaEmail, T000A2_A266UsuarioSistemaFecha,
               T000A2_A258DireccionId, T000A2_A259CentrodecostoId, T000A2_A260DepartamentoId
               }
               , new Object[] {
               T000A3_A99UsuarioSistemaId, T000A3_A101UsuarioSistemaIdentidad, T000A3_A100UsuarioSistemaNombre, T000A3_A263UsuarioSistemaGerencia, T000A3_n263UsuarioSistemaGerencia, T000A3_A257UsuarioSistemaDepartamento, T000A3_n257UsuarioSistemaDepartamento, T000A3_A264UsuarioSistemaTelefono, T000A3_A265UsuarioSistemaEmail, T000A3_A266UsuarioSistemaFecha,
               T000A3_A258DireccionId, T000A3_A259CentrodecostoId, T000A3_A260DepartamentoId
               }
               , new Object[] {
               T000A6_A99UsuarioSistemaId, T000A6_A101UsuarioSistemaIdentidad, T000A6_A100UsuarioSistemaNombre, T000A6_A263UsuarioSistemaGerencia, T000A6_n263UsuarioSistemaGerencia, T000A6_A257UsuarioSistemaDepartamento, T000A6_n257UsuarioSistemaDepartamento, T000A6_A264UsuarioSistemaTelefono, T000A6_A265UsuarioSistemaEmail, T000A6_A266UsuarioSistemaFecha,
               T000A6_A258DireccionId, T000A6_A259CentrodecostoId, T000A6_A260DepartamentoId
               }
               , new Object[] {
               T000A9_A99UsuarioSistemaId
               }
               , new Object[] {
               T000A10_A99UsuarioSistemaId
               }
               , new Object[] {
               T000A11_A99UsuarioSistemaId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A17_A99UsuarioSistemaId
               }
            }
         );
         AV35Pgmname = "UsuarioSistema";
         Z266UsuarioSistemaFecha = DateTimeUtil.Now( context);
         A266UsuarioSistemaFecha = DateTimeUtil.Now( context);
         i266UsuarioSistemaFecha = DateTimeUtil.Now( context);
      }

      private short Z258DireccionId ;
      private short Z260DepartamentoId ;
      private short N258DireccionId ;
      private short N260DepartamentoId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A258DireccionId ;
      private short A260DepartamentoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV31Insert_DireccionId ;
      private short AV33Insert_DepartamentoId ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short GX_JID ;
      private short nIsDirty_11 ;
      private int Z264UsuarioSistemaTelefono ;
      private int trnEnded ;
      private int edtUsuarioSistemaId_Enabled ;
      private int edtUsuarioSistemaIdentidad_Enabled ;
      private int edtUsuarioSistemaNombre_Enabled ;
      private int edtUsuarioSistemaGerencia_Enabled ;
      private int edtUsuarioSistemaDepartamento_Enabled ;
      private int A264UsuarioSistemaTelefono ;
      private int edtUsuarioSistemaTelefono_Enabled ;
      private int edtUsuarioSistemaEmail_Enabled ;
      private int edtDireccionId_Enabled ;
      private int imgprompt_258_Visible ;
      private int edtDireccionDescripcion_Enabled ;
      private int edtCentrodecostoId_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int imgprompt_259_260_Visible ;
      private int edtDepartamentoNombre_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV36GXV1 ;
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
      private string edtUsuarioSistemaId_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerusuariosistemaid_Internalname ;
      private string TempTags ;
      private string edtUsuarioSistemaId_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuariosistemaidentidad_Internalname ;
      private string edtUsuarioSistemaIdentidad_Internalname ;
      private string edtUsuarioSistemaIdentidad_Jsonclick ;
      private string edtUsuarioSistemaIdentidad_Class ;
      private string divK2btoolstable_attributecontainerusuariosistemanombre_Internalname ;
      private string edtUsuarioSistemaNombre_Internalname ;
      private string edtUsuarioSistemaNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuariosistemagerencia_Internalname ;
      private string edtUsuarioSistemaGerencia_Internalname ;
      private string divK2btoolstable_attributecontainerusuariosistemadepartamento_Internalname ;
      private string edtUsuarioSistemaDepartamento_Internalname ;
      private string divK2btoolstable_attributecontainerusuariosistematelefono_Internalname ;
      private string edtUsuarioSistemaTelefono_Internalname ;
      private string edtUsuarioSistemaTelefono_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuariosistemaemail_Internalname ;
      private string edtUsuarioSistemaEmail_Internalname ;
      private string edtUsuarioSistemaEmail_Jsonclick ;
      private string divK2btoolstable_attributecontainerdireccionid_Internalname ;
      private string edtDireccionId_Internalname ;
      private string edtDireccionId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_258_Internalname ;
      private string imgprompt_258_Link ;
      private string divK2btoolstable_attributecontainerdirecciondescripcion_Internalname ;
      private string edtDireccionDescripcion_Internalname ;
      private string edtDireccionDescripcion_Link ;
      private string divK2btoolstable_attributecontainercentrodecostoid_Internalname ;
      private string edtCentrodecostoId_Internalname ;
      private string edtCentrodecostoId_Jsonclick ;
      private string divK2btoolstable_attributecontainerdepartamentoid_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoId_Jsonclick ;
      private string imgprompt_259_260_Internalname ;
      private string imgprompt_259_260_Link ;
      private string divK2btoolstable_attributecontainerdepartamentonombre_Internalname ;
      private string edtDepartamentoNombre_Internalname ;
      private string edtDepartamentoNombre_Link ;
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
      private string AV35Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode11 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV16StandardActivityType ;
      private string AV13BtnCaption ;
      private string AV14BtnTooltip ;
      private string AV19encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV30UsuarioSistemaId ;
      private DateTime Z266UsuarioSistemaFecha ;
      private DateTime A266UsuarioSistemaFecha ;
      private DateTime i266UsuarioSistemaFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n263UsuarioSistemaGerencia ;
      private bool n257UsuarioSistemaDepartamento ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV18IsAuthorized ;
      private bool Gx_longc ;
      private bool GXt_boolean2 ;
      private string wcpOAV30UsuarioSistemaId ;
      private string Z99UsuarioSistemaId ;
      private string Z101UsuarioSistemaIdentidad ;
      private string Z100UsuarioSistemaNombre ;
      private string Z263UsuarioSistemaGerencia ;
      private string Z257UsuarioSistemaDepartamento ;
      private string Z265UsuarioSistemaEmail ;
      private string Z259CentrodecostoId ;
      private string N259CentrodecostoId ;
      private string AV30UsuarioSistemaId ;
      private string A259CentrodecostoId ;
      private string A99UsuarioSistemaId ;
      private string A101UsuarioSistemaIdentidad ;
      private string A100UsuarioSistemaNombre ;
      private string A263UsuarioSistemaGerencia ;
      private string A257UsuarioSistemaDepartamento ;
      private string A265UsuarioSistemaEmail ;
      private string A262DireccionDescripcion ;
      private string A261DepartamentoNombre ;
      private string AV32Insert_CentrodecostoId ;
      private string AV17UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV15Url ;
      private string Z262DireccionDescripcion ;
      private string Z261DepartamentoNombre ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] T000A5_A261DepartamentoNombre ;
      private string[] T000A4_A262DireccionDescripcion ;
      private IDataStoreProvider pr_default ;
      private string[] T000A6_A99UsuarioSistemaId ;
      private string[] T000A6_A101UsuarioSistemaIdentidad ;
      private string[] T000A6_A100UsuarioSistemaNombre ;
      private string[] T000A6_A263UsuarioSistemaGerencia ;
      private bool[] T000A6_n263UsuarioSistemaGerencia ;
      private string[] T000A6_A257UsuarioSistemaDepartamento ;
      private bool[] T000A6_n257UsuarioSistemaDepartamento ;
      private int[] T000A6_A264UsuarioSistemaTelefono ;
      private string[] T000A6_A265UsuarioSistemaEmail ;
      private DateTime[] T000A6_A266UsuarioSistemaFecha ;
      private short[] T000A6_A258DireccionId ;
      private string[] T000A6_A259CentrodecostoId ;
      private short[] T000A6_A260DepartamentoId ;
      private string[] T000A7_A262DireccionDescripcion ;
      private string[] T000A8_A261DepartamentoNombre ;
      private string[] T000A9_A99UsuarioSistemaId ;
      private string[] T000A3_A99UsuarioSistemaId ;
      private string[] T000A3_A101UsuarioSistemaIdentidad ;
      private string[] T000A3_A100UsuarioSistemaNombre ;
      private string[] T000A3_A263UsuarioSistemaGerencia ;
      private bool[] T000A3_n263UsuarioSistemaGerencia ;
      private string[] T000A3_A257UsuarioSistemaDepartamento ;
      private bool[] T000A3_n257UsuarioSistemaDepartamento ;
      private int[] T000A3_A264UsuarioSistemaTelefono ;
      private string[] T000A3_A265UsuarioSistemaEmail ;
      private DateTime[] T000A3_A266UsuarioSistemaFecha ;
      private short[] T000A3_A258DireccionId ;
      private string[] T000A3_A259CentrodecostoId ;
      private short[] T000A3_A260DepartamentoId ;
      private string[] T000A10_A99UsuarioSistemaId ;
      private string[] T000A11_A99UsuarioSistemaId ;
      private string[] T000A2_A99UsuarioSistemaId ;
      private string[] T000A2_A101UsuarioSistemaIdentidad ;
      private string[] T000A2_A100UsuarioSistemaNombre ;
      private string[] T000A2_A263UsuarioSistemaGerencia ;
      private bool[] T000A2_n263UsuarioSistemaGerencia ;
      private string[] T000A2_A257UsuarioSistemaDepartamento ;
      private bool[] T000A2_n257UsuarioSistemaDepartamento ;
      private int[] T000A2_A264UsuarioSistemaTelefono ;
      private string[] T000A2_A265UsuarioSistemaEmail ;
      private DateTime[] T000A2_A266UsuarioSistemaFecha ;
      private short[] T000A2_A258DireccionId ;
      private string[] T000A2_A259CentrodecostoId ;
      private short[] T000A2_A260DepartamentoId ;
      private string[] T000A15_A262DireccionDescripcion ;
      private string[] T000A16_A261DepartamentoNombre ;
      private string[] T000A17_A99UsuarioSistemaId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV24HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV20AttributeValue ;
      private SdtK2BAttributeValue_Item AV21AttributeValueItem ;
      private SdtK2BContext AV12Context ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
   }

   public class usuariosistema__datastore2 : DataStoreHelperBase, IDataStoreHelper
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@DireccionId",GXType.Int16,4,0)
          };
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@DireccionId",GXType.Int16,4,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          new ParDef("@DireccionId",GXType.Int16,4,0)
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A4", "SELECT [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @DireccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @DireccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A15", "SELECT [DireccionDescripcion] FROM dbo.[Direcciones] WHERE [DireccionId] = @DireccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A16", "SELECT [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class usuariosistema__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class usuariosistema__gam : DataStoreHelperBase, IDataStoreHelper
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

public class usuariosistema__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new UpdateCursor(def[6])
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
       Object[] prmT000A6;
       prmT000A6 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A9;
       prmT000A9 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A3;
       prmT000A3 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A10;
       prmT000A10 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A11;
       prmT000A11 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A2;
       prmT000A2 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A12;
       prmT000A12 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60) ,
       new ParDef("@UsuarioSistemaIdentidad",GXType.NVarChar,30,0) ,
       new ParDef("@UsuarioSistemaNombre",GXType.NVarChar,60,0) ,
       new ParDef("@UsuarioSistemaGerencia",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@UsuarioSistemaDepartamento",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@UsuarioSistemaTelefono",GXType.Int32,9,0) ,
       new ParDef("@UsuarioSistemaEmail",GXType.NVarChar,100,0) ,
       new ParDef("@UsuarioSistemaFecha",GXType.DateTime,10,5) ,
       new ParDef("@DireccionId",GXType.Int16,4,0) ,
       new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
       new ParDef("@DepartamentoId",GXType.Int16,4,0)
       };
       Object[] prmT000A13;
       prmT000A13 = new Object[] {
       new ParDef("@UsuarioSistemaIdentidad",GXType.NVarChar,30,0) ,
       new ParDef("@UsuarioSistemaNombre",GXType.NVarChar,60,0) ,
       new ParDef("@UsuarioSistemaGerencia",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@UsuarioSistemaDepartamento",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@UsuarioSistemaTelefono",GXType.Int32,9,0) ,
       new ParDef("@UsuarioSistemaEmail",GXType.NVarChar,100,0) ,
       new ParDef("@UsuarioSistemaFecha",GXType.DateTime,10,5) ,
       new ParDef("@DireccionId",GXType.Int16,4,0) ,
       new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
       new ParDef("@DepartamentoId",GXType.Int16,4,0) ,
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A14;
       prmT000A14 = new Object[] {
       new ParDef("@UsuarioSistemaId",GXType.NVarChar,100,60)
       };
       Object[] prmT000A17;
       prmT000A17 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000A2", "SELECT [UsuarioSistemaId], [UsuarioSistemaIdentidad], [UsuarioSistemaNombre], [UsuarioSistemaGerencia], [UsuarioSistemaDepartamento], [UsuarioSistemaTelefono], [UsuarioSistemaEmail], [UsuarioSistemaFecha], [DireccionId], [CentrodecostoId], [DepartamentoId] FROM [UsuarioSistema] WITH (UPDLOCK) WHERE [UsuarioSistemaId] = @UsuarioSistemaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A3", "SELECT [UsuarioSistemaId], [UsuarioSistemaIdentidad], [UsuarioSistemaNombre], [UsuarioSistemaGerencia], [UsuarioSistemaDepartamento], [UsuarioSistemaTelefono], [UsuarioSistemaEmail], [UsuarioSistemaFecha], [DireccionId], [CentrodecostoId], [DepartamentoId] FROM [UsuarioSistema] WHERE [UsuarioSistemaId] = @UsuarioSistemaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A6", "SELECT TM1.[UsuarioSistemaId], TM1.[UsuarioSistemaIdentidad], TM1.[UsuarioSistemaNombre], TM1.[UsuarioSistemaGerencia], TM1.[UsuarioSistemaDepartamento], TM1.[UsuarioSistemaTelefono], TM1.[UsuarioSistemaEmail], TM1.[UsuarioSistemaFecha], TM1.[DireccionId], TM1.[CentrodecostoId], TM1.[DepartamentoId] FROM [UsuarioSistema] TM1 WHERE TM1.[UsuarioSistemaId] = @UsuarioSistemaId ORDER BY TM1.[UsuarioSistemaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A9", "SELECT [UsuarioSistemaId] FROM [UsuarioSistema] WHERE [UsuarioSistemaId] = @UsuarioSistemaId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000A10", "SELECT TOP 1 [UsuarioSistemaId] FROM [UsuarioSistema] WHERE ( [UsuarioSistemaId] > @UsuarioSistemaId) ORDER BY [UsuarioSistemaId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000A11", "SELECT TOP 1 [UsuarioSistemaId] FROM [UsuarioSistema] WHERE ( [UsuarioSistemaId] < @UsuarioSistemaId) ORDER BY [UsuarioSistemaId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000A12", "INSERT INTO [UsuarioSistema]([UsuarioSistemaId], [UsuarioSistemaIdentidad], [UsuarioSistemaNombre], [UsuarioSistemaGerencia], [UsuarioSistemaDepartamento], [UsuarioSistemaTelefono], [UsuarioSistemaEmail], [UsuarioSistemaFecha], [DireccionId], [CentrodecostoId], [DepartamentoId]) VALUES(@UsuarioSistemaId, @UsuarioSistemaIdentidad, @UsuarioSistemaNombre, @UsuarioSistemaGerencia, @UsuarioSistemaDepartamento, @UsuarioSistemaTelefono, @UsuarioSistemaEmail, @UsuarioSistemaFecha, @DireccionId, @CentrodecostoId, @DepartamentoId)", GxErrorMask.GX_NOMASK,prmT000A12)
          ,new CursorDef("T000A13", "UPDATE [UsuarioSistema] SET [UsuarioSistemaIdentidad]=@UsuarioSistemaIdentidad, [UsuarioSistemaNombre]=@UsuarioSistemaNombre, [UsuarioSistemaGerencia]=@UsuarioSistemaGerencia, [UsuarioSistemaDepartamento]=@UsuarioSistemaDepartamento, [UsuarioSistemaTelefono]=@UsuarioSistemaTelefono, [UsuarioSistemaEmail]=@UsuarioSistemaEmail, [UsuarioSistemaFecha]=@UsuarioSistemaFecha, [DireccionId]=@DireccionId, [CentrodecostoId]=@CentrodecostoId, [DepartamentoId]=@DepartamentoId  WHERE [UsuarioSistemaId] = @UsuarioSistemaId", GxErrorMask.GX_NOMASK,prmT000A13)
          ,new CursorDef("T000A14", "DELETE FROM [UsuarioSistema]  WHERE [UsuarioSistemaId] = @UsuarioSistemaId", GxErrorMask.GX_NOMASK,prmT000A14)
          ,new CursorDef("T000A17", "SELECT [UsuarioSistemaId] FROM [UsuarioSistema] ORDER BY [UsuarioSistemaId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getVarchar(7);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((short[]) buf[10])[0] = rslt.getShort(9);
             ((string[]) buf[11])[0] = rslt.getVarchar(10);
             ((short[]) buf[12])[0] = rslt.getShort(11);
             return;
          case 1 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getVarchar(7);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((short[]) buf[10])[0] = rslt.getShort(9);
             ((string[]) buf[11])[0] = rslt.getVarchar(10);
             ((short[]) buf[12])[0] = rslt.getShort(11);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((int[]) buf[7])[0] = rslt.getInt(6);
             ((string[]) buf[8])[0] = rslt.getVarchar(7);
             ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
             ((short[]) buf[10])[0] = rslt.getShort(9);
             ((string[]) buf[11])[0] = rslt.getVarchar(10);
             ((short[]) buf[12])[0] = rslt.getShort(11);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
    }
 }

}

}
