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
   public class estado : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7EstadoId = (short)(NumberUtil.Val( GetPar( "EstadoId"), "."));
               AssignAttri(sPrefix, false, "AV7EstadoId", StringUtil.LTrimStr( (decimal)(AV7EstadoId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7EstadoId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
            {
               A169SgCategoriaId = (int)(NumberUtil.Val( GetPar( "SgCategoriaId"), "."));
               AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_13( A169SgCategoriaId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
            {
               A171SgActividadId = (int)(NumberUtil.Val( GetPar( "SgActividadId"), "."));
               AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_14( A171SgActividadId) ;
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
                  AV7EstadoId = (short)(NumberUtil.Val( GetPar( "EstadoId"), "."));
                  AssignAttri(sPrefix, false, "AV7EstadoId", StringUtil.LTrimStr( (decimal)(AV7EstadoId), 4, 0));
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
               Form.Meta.addItem("description", "Estado", 0) ;
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
            GX_FocusControl = edtEstadoNombre_Internalname;
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

      public estado( )
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

      public estado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EstadoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EstadoId = aP1_EstadoId;
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
         chkEstadoActivo = new GXCheckbox();
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
            return "estado_Execute" ;
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
         A19EstadoActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A19EstadoActivo));
         AssignAttri(sPrefix, false, "A19EstadoActivo", A19EstadoActivo);
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
            RenderHtmlCloseForm022( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "estado.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoId_Internalname, "Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtEstadoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A3EstadoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtEstadoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A3EstadoId), "ZZZ9") : context.localUtil.Format( (decimal)(A3EstadoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Estado.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoNombre_Internalname, "Estado", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A20EstadoNombre", A20EstadoNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoNombre_Internalname, A20EstadoNombre, StringUtil.RTrim( context.localUtil.Format( A20EstadoNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoNombre_Jsonclick, 0, edtEstadoNombre_Class, "", "", "", "", 1, edtEstadoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Estado.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoactivo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkEstadoActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEstadoActivo_Internalname, "Status", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A19EstadoActivo", A19EstadoActivo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEstadoActivo_Internalname, StringUtil.BoolToStr( A19EstadoActivo), "", "Status", 1, chkEstadoActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(30, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,30);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgcategoriaid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgCategoriaId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgCategoriaId_Internalname, "Categoria Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSgCategoriaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A169SgCategoriaId), 9, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A169SgCategoriaId), "ZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSgCategoriaId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSgCategoriaId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Estado.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_169_Internalname, sImgUrl, imgprompt_169_Link, "", "", context.GetTheme( ), imgprompt_169_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Estado.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgcategorianombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgCategoriaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgCategoriaNombre_Internalname, "Categoria Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSgCategoriaNombre_Internalname, A170SgCategoriaNombre, "", "", 0, 1, edtSgCategoriaNombre_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Estado.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgactividadid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgActividadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgActividadId_Internalname, "Actividad Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSgActividadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A171SgActividadId), 9, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A171SgActividadId), "ZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSgActividadId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSgActividadId_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Estado.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_171_Internalname, sImgUrl, imgprompt_171_Link, "", "", context.GetTheme( ), imgprompt_171_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Estado.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgactividadnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgActividadNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgActividadNombre_Internalname, "Actividad Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSgActividadNombre_Internalname, A172SgActividadNombre, "", "", 0, 1, edtSgActividadNombre_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Estado.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estado.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Estado.htm");
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
         E11022 ();
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
               Z3EstadoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z3EstadoId"), ".", ","));
               Z20EstadoNombre = cgiGet( sPrefix+"Z20EstadoNombre");
               Z19EstadoActivo = StringUtil.StrToBool( cgiGet( sPrefix+"Z19EstadoActivo"));
               Z169SgCategoriaId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z169SgCategoriaId"), ".", ","));
               Z171SgActividadId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z171SgActividadId"), ".", ","));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7EstadoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EstadoId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N169SgCategoriaId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N169SgCategoriaId"), ".", ","));
               N171SgActividadId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N171SgActividadId"), ".", ","));
               AV7EstadoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vESTADOID"), ".", ","));
               AV24Insert_SgCategoriaId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SGCATEGORIAID"), ".", ","));
               AV25Insert_SgActividadId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SGACTIVIDADID"), ".", ","));
               AV27Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A3EstadoId = (short)(context.localUtil.CToN( cgiGet( edtEstadoId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
               A20EstadoNombre = cgiGet( edtEstadoNombre_Internalname);
               AssignAttri(sPrefix, false, "A20EstadoNombre", A20EstadoNombre);
               A19EstadoActivo = StringUtil.StrToBool( cgiGet( chkEstadoActivo_Internalname));
               AssignAttri(sPrefix, false, "A19EstadoActivo", A19EstadoActivo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSgCategoriaId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSgCategoriaId_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGCATEGORIAID");
                  AnyError = 1;
                  GX_FocusControl = edtSgCategoriaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A169SgCategoriaId = 0;
                  AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
               }
               else
               {
                  A169SgCategoriaId = (int)(context.localUtil.CToN( cgiGet( edtSgCategoriaId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
               }
               A170SgCategoriaNombre = cgiGet( edtSgCategoriaNombre_Internalname);
               n170SgCategoriaNombre = false;
               AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSgActividadId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSgActividadId_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGACTIVIDADID");
                  AnyError = 1;
                  GX_FocusControl = edtSgActividadId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A171SgActividadId = 0;
                  AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
               }
               else
               {
                  A171SgActividadId = (int)(context.localUtil.CToN( cgiGet( edtSgActividadId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
               }
               A172SgActividadNombre = cgiGet( edtSgActividadNombre_Internalname);
               AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Estado");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A3EstadoId != Z3EstadoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("estado:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A3EstadoId = (short)(NumberUtil.Val( GetPar( "EstadoId"), "."));
                  AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
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
                     sMode2 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode2;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound2 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_020( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESTADOID");
                        AnyError = 1;
                        GX_FocusControl = edtEstadoId_Internalname;
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
                                 E11022 ();
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
                                 E12022 ();
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
                                 E13022 ();
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
            E12022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll022( ) ;
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
            DisableAttributes022( ) ;
         }
         AssignProp(sPrefix, false, edtEstadoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkEstadoActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadoActivo.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSgCategoriaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgCategoriaNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSgActividadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadNombre_Enabled), 5, 0), true);
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption020( )
      {
      }

      protected void E11022( )
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
         new k2bisauthorizedactivityname(context ).execute(  "Estado",  "Estado",  AV16StandardActivityType,  AV17UserActivityType,  AV27Pgmname, out  AV18IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV18IsAuthorized", AV18IsAuthorized);
         if ( ! AV18IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("Estado")),UrlEncode(StringUtil.RTrim("Estado")),UrlEncode(StringUtil.RTrim(AV16StandardActivityType)),UrlEncode(StringUtil.RTrim(AV17UserActivityType)),UrlEncode(StringUtil.RTrim(AV27Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "Estado", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Estado", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Estado", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Estado", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV28GXV1 = 1;
            AssignAttri(sPrefix, false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            while ( AV28GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV28GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SgCategoriaId") == 0 )
               {
                  AV24Insert_SgCategoriaId = (int)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV24Insert_SgCategoriaId", StringUtil.LTrimStr( (decimal)(AV24Insert_SgCategoriaId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SgActividadId") == 0 )
               {
                  AV25Insert_SgActividadId = (int)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV25Insert_SgActividadId", StringUtil.LTrimStr( (decimal)(AV25Insert_SgActividadId), 9, 0));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri(sPrefix, false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(AV26HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtEstadoNombre_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtEstadoNombre_Internalname, "Class", edtEstadoNombre_Class, true);
            }
            else
            {
               edtEstadoNombre_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtEstadoNombre_Internalname, "Class", edtEstadoNombre_Class, true);
            }
         }
      }

      protected void E12022( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV21AttributeValueItem.gxTpr_Attributename = "EstadoId";
            AV21AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A3EstadoId), 4, 0);
            AV20AttributeValue.Add(AV21AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "Estado",  AV20AttributeValue) ;
         }
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La estado %1 fue creada", A20EstadoNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La estado %1 fue actualizada", A20EstadoNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La estado %1 fue eliminada", A20EstadoNombre, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV22Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"Estado",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV20AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "Estado") ;
            }
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV10Navigation = AV8TrnContext.gxTpr_Afterinsert;
               /* Execute user subroutine: 'DOAFTERTRNACTION' */
               S112 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  pr_datastore1.close(0);
                  pr_datastore1.close(1);
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
                  pr_default.close(1);
                  pr_datastore1.close(0);
                  pr_datastore1.close(1);
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
                  pr_default.close(1);
                  pr_datastore1.close(0);
                  pr_datastore1.close(1);
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
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A3EstadoId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A3EstadoId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A3EstadoId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A3EstadoId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A3EstadoId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A3EstadoId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A3EstadoId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A3EstadoId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A3EstadoId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A3EstadoId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A3EstadoId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A3EstadoId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A3EstadoId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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
                  if ( returnInSub )
                  {
                     pr_default.close(1);
                     pr_datastore1.close(0);
                     pr_datastore1.close(1);
                     returnInSub = true;
                     if (true) return;
                  }
               }
            }
         }
      }

      protected void E13022( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "Estado") ;
         /* Execute user subroutine: 'K2BCLOSE' */
         S122 ();
         if ( returnInSub )
         {
            pr_default.close(1);
            pr_datastore1.close(0);
            pr_datastore1.close(1);
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"Estado"}, true);
         }
         else if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Stack") == 0 )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            pr_default.close(1);
            pr_datastore1.close(0);
            pr_datastore1.close(1);
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
            pr_default.close(1);
            pr_datastore1.close(0);
            pr_datastore1.close(1);
            returnInSub = true;
            if (true) return;
         }
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z20EstadoNombre = T00023_A20EstadoNombre[0];
               Z19EstadoActivo = T00023_A19EstadoActivo[0];
               Z169SgCategoriaId = T00023_A169SgCategoriaId[0];
               Z171SgActividadId = T00023_A171SgActividadId[0];
            }
            else
            {
               Z20EstadoNombre = A20EstadoNombre;
               Z19EstadoActivo = A19EstadoActivo;
               Z169SgCategoriaId = A169SgCategoriaId;
               Z171SgActividadId = A171SgActividadId;
            }
         }
         if ( GX_JID == -12 )
         {
            Z3EstadoId = A3EstadoId;
            Z20EstadoNombre = A20EstadoNombre;
            Z19EstadoActivo = A19EstadoActivo;
            Z169SgCategoriaId = A169SgCategoriaId;
            Z171SgActividadId = A171SgActividadId;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEstadoId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoId_Enabled), 5, 0), true);
         imgprompt_169_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptcategoria_tarea.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SGCATEGORIAID"+"'), id:'"+sPrefix+"SGCATEGORIAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_171_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptactividades_categoria.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SGACTIVIDADID"+"'), id:'"+sPrefix+"SGACTIVIDADID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtEstadoId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoId_Enabled), 5, 0), true);
         if ( ! (0==AV7EstadoId) )
         {
            A3EstadoId = AV7EstadoId;
            AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_SgCategoriaId) )
         {
            edtSgCategoriaId_Enabled = 0;
            AssignProp(sPrefix, false, edtSgCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgCategoriaId_Enabled), 5, 0), true);
         }
         else
         {
            edtSgCategoriaId_Enabled = 1;
            AssignProp(sPrefix, false, edtSgCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgCategoriaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_SgActividadId) )
         {
            edtSgActividadId_Enabled = 0;
            AssignProp(sPrefix, false, edtSgActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadId_Enabled), 5, 0), true);
         }
         else
         {
            edtSgActividadId_Enabled = 1;
            AssignProp(sPrefix, false, edtSgActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_SgActividadId) )
         {
            A171SgActividadId = AV25Insert_SgActividadId;
            AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV24Insert_SgCategoriaId) )
         {
            A169SgCategoriaId = AV24Insert_SgCategoriaId;
            AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV27Pgmname = "Estado";
            AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
            /* Using cursor T00025 */
            pr_datastore1.execute(1, new Object[] {A171SgActividadId});
            A123nombre_actividad = T00025_A123nombre_actividad[0];
            n123nombre_actividad = T00025_n123nombre_actividad[0];
            A172SgActividadNombre = T00025_A123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
            pr_datastore1.close(1);
            /* Using cursor T00024 */
            pr_datastore1.execute(0, new Object[] {A169SgCategoriaId});
            A170SgCategoriaNombre = T00024_A170SgCategoriaNombre[0];
            n170SgCategoriaNombre = T00024_n170SgCategoriaNombre[0];
            AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
            pr_datastore1.close(0);
         }
      }

      protected void Load022( )
      {
         /* Using cursor T00026 */
         pr_default.execute(2, new Object[] {A3EstadoId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A20EstadoNombre = T00026_A20EstadoNombre[0];
            AssignAttri(sPrefix, false, "A20EstadoNombre", A20EstadoNombre);
            A19EstadoActivo = T00026_A19EstadoActivo[0];
            AssignAttri(sPrefix, false, "A19EstadoActivo", A19EstadoActivo);
            A169SgCategoriaId = T00026_A169SgCategoriaId[0];
            AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
            A171SgActividadId = T00026_A171SgActividadId[0];
            AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
            ZM022( -12) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         AV27Pgmname = "Estado";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         /* Using cursor T00024 */
         pr_datastore1.execute(0, new Object[] {A169SgCategoriaId});
         A170SgCategoriaNombre = T00024_A170SgCategoriaNombre[0];
         n170SgCategoriaNombre = T00024_n170SgCategoriaNombre[0];
         AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
         pr_datastore1.close(0);
         /* Using cursor T00025 */
         pr_datastore1.execute(1, new Object[] {A171SgActividadId});
         A123nombre_actividad = T00025_A123nombre_actividad[0];
         n123nombre_actividad = T00025_n123nombre_actividad[0];
         A172SgActividadNombre = T00025_A123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         pr_datastore1.close(1);
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV27Pgmname = "Estado";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A20EstadoNombre)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Estado", "", "", "", "", "", "", "", ""), 1, "ESTADONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtEstadoNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00024 */
         pr_datastore1.execute(0, new Object[] {A169SgCategoriaId});
         if ( (pr_datastore1.getStatus(0) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Categoria'.", "ForeignKeyNotFound", 1, "SGCATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtSgCategoriaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A170SgCategoriaNombre = T00024_A170SgCategoriaNombre[0];
         n170SgCategoriaNombre = T00024_n170SgCategoriaNombre[0];
         AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
         pr_datastore1.close(0);
         /* Using cursor T00025 */
         pr_datastore1.execute(1, new Object[] {A171SgActividadId});
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "SGACTIVIDADID");
            AnyError = 1;
            GX_FocusControl = edtSgActividadId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A123nombre_actividad = T00025_A123nombre_actividad[0];
         n123nombre_actividad = T00025_n123nombre_actividad[0];
         A172SgActividadNombre = T00025_A123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         pr_datastore1.close(1);
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_datastore1.close(0);
         pr_datastore1.close(1);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_13( int A169SgCategoriaId )
      {
         /* Using cursor T00027 */
         pr_datastore1.execute(2, new Object[] {A169SgCategoriaId});
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Categoria'.", "ForeignKeyNotFound", 1, "SGCATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtSgCategoriaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A170SgCategoriaNombre = T00027_A170SgCategoriaNombre[0];
         n170SgCategoriaNombre = T00027_n170SgCategoriaNombre[0];
         AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A170SgCategoriaNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(2);
      }

      protected void gxLoad_14( int A171SgActividadId )
      {
         /* Using cursor T00028 */
         pr_datastore1.execute(3, new Object[] {A171SgActividadId});
         if ( (pr_datastore1.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "SGACTIVIDADID");
            AnyError = 1;
            GX_FocusControl = edtSgActividadId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A123nombre_actividad = T00028_A123nombre_actividad[0];
         n123nombre_actividad = T00028_n123nombre_actividad[0];
         A172SgActividadNombre = T00028_A123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A172SgActividadNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(3) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(3);
      }

      protected void GetKey022( )
      {
         /* Using cursor T00029 */
         pr_default.execute(3, new Object[] {A3EstadoId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A3EstadoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 12) ;
            RcdFound2 = 1;
            A3EstadoId = T00023_A3EstadoId[0];
            AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
            A20EstadoNombre = T00023_A20EstadoNombre[0];
            AssignAttri(sPrefix, false, "A20EstadoNombre", A20EstadoNombre);
            A19EstadoActivo = T00023_A19EstadoActivo[0];
            AssignAttri(sPrefix, false, "A19EstadoActivo", A19EstadoActivo);
            A169SgCategoriaId = T00023_A169SgCategoriaId[0];
            AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
            A171SgActividadId = T00023_A171SgActividadId[0];
            AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
            Z3EstadoId = A3EstadoId;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound2 = 0;
         /* Using cursor T000210 */
         pr_default.execute(4, new Object[] {A3EstadoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000210_A3EstadoId[0] < A3EstadoId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000210_A3EstadoId[0] > A3EstadoId ) ) )
            {
               A3EstadoId = T000210_A3EstadoId[0];
               AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T000211 */
         pr_default.execute(5, new Object[] {A3EstadoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000211_A3EstadoId[0] > A3EstadoId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000211_A3EstadoId[0] < A3EstadoId ) ) )
            {
               A3EstadoId = T000211_A3EstadoId[0];
               AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
               RcdFound2 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEstadoNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A3EstadoId != Z3EstadoId )
               {
                  A3EstadoId = Z3EstadoId;
                  AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESTADOID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEstadoNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtEstadoNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A3EstadoId != Z3EstadoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEstadoNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOID");
                     AnyError = 1;
                     GX_FocusControl = edtEstadoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEstadoNombre_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( A3EstadoId != Z3EstadoId )
         {
            A3EstadoId = Z3EstadoId;
            AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESTADOID");
            AnyError = 1;
            GX_FocusControl = edtEstadoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEstadoNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A3EstadoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estado"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20EstadoNombre, T00022_A20EstadoNombre[0]) != 0 ) || ( Z19EstadoActivo != T00022_A19EstadoActivo[0] ) || ( Z169SgCategoriaId != T00022_A169SgCategoriaId[0] ) || ( Z171SgActividadId != T00022_A171SgActividadId[0] ) )
            {
               if ( StringUtil.StrCmp(Z20EstadoNombre, T00022_A20EstadoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"EstadoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z20EstadoNombre);
                  GXUtil.WriteLogRaw("Current: ",T00022_A20EstadoNombre[0]);
               }
               if ( Z19EstadoActivo != T00022_A19EstadoActivo[0] )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"EstadoActivo");
                  GXUtil.WriteLogRaw("Old: ",Z19EstadoActivo);
                  GXUtil.WriteLogRaw("Current: ",T00022_A19EstadoActivo[0]);
               }
               if ( Z169SgCategoriaId != T00022_A169SgCategoriaId[0] )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"SgCategoriaId");
                  GXUtil.WriteLogRaw("Old: ",Z169SgCategoriaId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A169SgCategoriaId[0]);
               }
               if ( Z171SgActividadId != T00022_A171SgActividadId[0] )
               {
                  GXUtil.WriteLog("estado:[seudo value changed for attri]"+"SgActividadId");
                  GXUtil.WriteLogRaw("Old: ",Z171SgActividadId);
                  GXUtil.WriteLogRaw("Current: ",T00022_A171SgActividadId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Estado"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         if ( ! IsAuthorized("estado_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000212 */
                     pr_default.execute(6, new Object[] {A20EstadoNombre, A19EstadoActivo, A169SgCategoriaId, A171SgActividadId});
                     A3EstadoId = T000212_A3EstadoId[0];
                     AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Estado");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         if ( ! IsAuthorized("estado_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000213 */
                     pr_default.execute(7, new Object[] {A20EstadoNombre, A19EstadoActivo, A169SgCategoriaId, A171SgActividadId, A3EstadoId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Estado");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Estado"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("estado_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000214 */
                  pr_default.execute(8, new Object[] {A3EstadoId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Estado");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV27Pgmname = "Estado";
            AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
            /* Using cursor T000215 */
            pr_datastore1.execute(4, new Object[] {A169SgCategoriaId});
            A170SgCategoriaNombre = T000215_A170SgCategoriaNombre[0];
            n170SgCategoriaNombre = T000215_n170SgCategoriaNombre[0];
            AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
            pr_datastore1.close(4);
            /* Using cursor T000216 */
            pr_datastore1.execute(5, new Object[] {A171SgActividadId});
            A123nombre_actividad = T000216_A123nombre_actividad[0];
            n123nombre_actividad = T000216_n123nombre_actividad[0];
            A172SgActividadNombre = T000216_A123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
            pr_datastore1.close(5);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_datastore1.close(4);
            pr_datastore1.close(5);
            context.CommitDataStores("estado",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_datastore1.close(4);
            pr_datastore1.close(5);
            context.RollbackDataStores("estado",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Scan By routine */
         /* Using cursor T000217 */
         pr_default.execute(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A3EstadoId = T000217_A3EstadoId[0];
            AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A3EstadoId = T000217_A3EstadoId[0];
            AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtEstadoId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoId_Enabled), 5, 0), true);
         edtEstadoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoNombre_Enabled), 5, 0), true);
         chkEstadoActivo.Enabled = 0;
         AssignProp(sPrefix, false, chkEstadoActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadoActivo.Enabled), 5, 0), true);
         edtSgCategoriaId_Enabled = 0;
         AssignProp(sPrefix, false, edtSgCategoriaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgCategoriaId_Enabled), 5, 0), true);
         edtSgCategoriaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSgCategoriaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgCategoriaNombre_Enabled), 5, 0), true);
         edtSgActividadId_Enabled = 0;
         AssignProp(sPrefix, false, edtSgActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadId_Enabled), 5, 0), true);
         edtSgActividadNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSgActividadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188141460", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estado.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EstadoId,4,0))}, new string[] {"Gx_mode","EstadoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Estado");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("estado:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z3EstadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z3EstadoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z20EstadoNombre", Z20EstadoNombre);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z19EstadoActivo", Z19EstadoActivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z169SgCategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z169SgCategoriaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z171SgActividadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z171SgActividadId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7EstadoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7EstadoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N169SgCategoriaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A169SgCategoriaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N171SgActividadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A171SgActividadId), 9, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTADOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EstadoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SGCATEGORIAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24Insert_SgCategoriaId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SGACTIVIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Insert_SgActividadId), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm022( )
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
         return "Estado" ;
      }

      public override string GetPgmdesc( )
      {
         return "Estado" ;
      }

      protected void InitializeNonKey022( )
      {
         A102id_actividad_categoria = 0;
         AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         A169SgCategoriaId = 0;
         AssignAttri(sPrefix, false, "A169SgCategoriaId", StringUtil.LTrimStr( (decimal)(A169SgCategoriaId), 9, 0));
         A171SgActividadId = 0;
         AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
         A20EstadoNombre = "";
         AssignAttri(sPrefix, false, "A20EstadoNombre", A20EstadoNombre);
         A19EstadoActivo = false;
         AssignAttri(sPrefix, false, "A19EstadoActivo", A19EstadoActivo);
         A170SgCategoriaNombre = "";
         n170SgCategoriaNombre = false;
         AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
         A172SgActividadNombre = "";
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         Z20EstadoNombre = "";
         Z19EstadoActivo = false;
         Z169SgCategoriaId = 0;
         Z171SgActividadId = 0;
      }

      protected void InitAll022( )
      {
         A3EstadoId = 0;
         AssignAttri(sPrefix, false, "A3EstadoId", StringUtil.LTrimStr( (decimal)(A3EstadoId), 4, 0));
         InitializeNonKey022( ) ;
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
         sCtrlAV7EstadoId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "estado", GetJustCreated( ));
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
            AV7EstadoId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7EstadoId", StringUtil.LTrimStr( (decimal)(AV7EstadoId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7EstadoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EstadoId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7EstadoId != wcpOAV7EstadoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7EstadoId = AV7EstadoId;
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
         sCtrlAV7EstadoId = cgiGet( sPrefix+"AV7EstadoId_CTRL");
         if ( StringUtil.Len( sCtrlAV7EstadoId) > 0 )
         {
            AV7EstadoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7EstadoId), ".", ","));
            AssignAttri(sPrefix, false, "AV7EstadoId", StringUtil.LTrimStr( (decimal)(AV7EstadoId), 4, 0));
         }
         else
         {
            AV7EstadoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7EstadoId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7EstadoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EstadoId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7EstadoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7EstadoId_CTRL", StringUtil.RTrim( sCtrlAV7EstadoId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188141482", true, true);
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
         context.AddJavascriptSource("estado.js", "?2024188141482", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtEstadoId_Internalname = sPrefix+"ESTADOID";
         divK2btoolstable_attributecontainerestadoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOID";
         edtEstadoNombre_Internalname = sPrefix+"ESTADONOMBRE";
         divK2btoolstable_attributecontainerestadonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADONOMBRE";
         chkEstadoActivo_Internalname = sPrefix+"ESTADOACTIVO";
         divK2btoolstable_attributecontainerestadoactivo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOACTIVO";
         edtSgCategoriaId_Internalname = sPrefix+"SGCATEGORIAID";
         divK2btoolstable_attributecontainersgcategoriaid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGCATEGORIAID";
         edtSgCategoriaNombre_Internalname = sPrefix+"SGCATEGORIANOMBRE";
         divK2btoolstable_attributecontainersgcategorianombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGCATEGORIANOMBRE";
         edtSgActividadId_Internalname = sPrefix+"SGACTIVIDADID";
         divK2btoolstable_attributecontainersgactividadid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGACTIVIDADID";
         edtSgActividadNombre_Internalname = sPrefix+"SGACTIVIDADNOMBRE";
         divK2btoolstable_attributecontainersgactividadnombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGACTIVIDADNOMBRE";
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
         imgprompt_169_Internalname = sPrefix+"PROMPT_169";
         imgprompt_171_Internalname = sPrefix+"PROMPT_171";
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
         Form.Caption = "Estado";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtSgActividadNombre_Enabled = 0;
         imgprompt_171_Visible = 1;
         imgprompt_171_Link = "";
         edtSgActividadId_Jsonclick = "";
         edtSgActividadId_Enabled = 1;
         edtSgCategoriaNombre_Enabled = 0;
         imgprompt_169_Visible = 1;
         imgprompt_169_Link = "";
         edtSgCategoriaId_Jsonclick = "";
         edtSgCategoriaId_Enabled = 1;
         chkEstadoActivo.Enabled = 1;
         edtEstadoNombre_Jsonclick = "";
         edtEstadoNombre_Class = "Attribute_Trn Attribute_Required";
         edtEstadoNombre_Enabled = 1;
         edtEstadoId_Jsonclick = "";
         edtEstadoId_Enabled = 0;
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
         chkEstadoActivo.Name = "ESTADOACTIVO";
         chkEstadoActivo.WebTags = "";
         chkEstadoActivo.Caption = "";
         AssignProp(sPrefix, false, chkEstadoActivo_Internalname, "TitleCaption", chkEstadoActivo.Caption, true);
         chkEstadoActivo.CheckedValue = "false";
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

      public void Valid_Sgcategoriaid( )
      {
         n170SgCategoriaNombre = false;
         /* Using cursor T000215 */
         pr_datastore1.execute(4, new Object[] {A169SgCategoriaId});
         if ( (pr_datastore1.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Categoria'.", "ForeignKeyNotFound", 1, "SGCATEGORIAID");
            AnyError = 1;
            GX_FocusControl = edtSgCategoriaId_Internalname;
         }
         A170SgCategoriaNombre = T000215_A170SgCategoriaNombre[0];
         n170SgCategoriaNombre = T000215_n170SgCategoriaNombre[0];
         pr_datastore1.close(4);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A170SgCategoriaNombre", A170SgCategoriaNombre);
      }

      public void Valid_Sgactividadid( )
      {
         /* Using cursor T000216 */
         pr_datastore1.execute(5, new Object[] {A171SgActividadId});
         if ( (pr_datastore1.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "SGACTIVIDADID");
            AnyError = 1;
            GX_FocusControl = edtSgActividadId_Internalname;
         }
         A123nombre_actividad = T000216_A123nombre_actividad[0];
         n123nombre_actividad = T000216_n123nombre_actividad[0];
         A172SgActividadNombre = T000216_A123nombre_actividad[0];
         pr_datastore1.close(5);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7EstadoId',fld:'vESTADOID',pic:'ZZZ9'},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12022',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A3EstadoId',fld:'ESTADOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A20EstadoNombre',fld:'ESTADONOMBRE',pic:''},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A3EstadoId',fld:'ESTADOID',pic:'ZZZ9'},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13022',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("'DOCANCEL'",",oparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("VALID_ESTADOID","{handler:'Valid_Estadoid',iparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("VALID_ESTADOID",",oparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("VALID_ESTADONOMBRE","{handler:'Valid_Estadonombre',iparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("VALID_ESTADONOMBRE",",oparms:[{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("VALID_SGCATEGORIAID","{handler:'Valid_Sgcategoriaid',iparms:[{av:'A169SgCategoriaId',fld:'SGCATEGORIAID',pic:'ZZZZZZZZ9'},{av:'A170SgCategoriaNombre',fld:'SGCATEGORIANOMBRE',pic:''},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("VALID_SGCATEGORIAID",",oparms:[{av:'A170SgCategoriaNombre',fld:'SGCATEGORIANOMBRE',pic:''},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
         setEventMetadata("VALID_SGACTIVIDADID","{handler:'Valid_Sgactividadid',iparms:[{av:'A171SgActividadId',fld:'SGACTIVIDADID',pic:'ZZZZZZZZ9'},{av:'A172SgActividadNombre',fld:'SGACTIVIDADNOMBRE',pic:''},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]");
         setEventMetadata("VALID_SGACTIVIDADID",",oparms:[{av:'A172SgActividadNombre',fld:'SGACTIVIDADNOMBRE',pic:''},{av:'A19EstadoActivo',fld:'ESTADOACTIVO',pic:''}]}");
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
         pr_datastore1.close(4);
         pr_datastore1.close(5);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z20EstadoNombre = "";
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
         A20EstadoNombre = "";
         TempTags = "";
         sImgUrl = "";
         A170SgCategoriaNombre = "";
         A172SgActividadNombre = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV27Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode2 = "";
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
         AV26HttpRequest = new GxHttpRequest( context);
         AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV19encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV15Url = "";
         T00025_A102id_actividad_categoria = new int[1] ;
         T00025_A123nombre_actividad = new string[] {""} ;
         T00025_n123nombre_actividad = new bool[] {false} ;
         A123nombre_actividad = "";
         T00024_A170SgCategoriaNombre = new string[] {""} ;
         T00024_n170SgCategoriaNombre = new bool[] {false} ;
         T00026_A3EstadoId = new short[1] ;
         T00026_A20EstadoNombre = new string[] {""} ;
         T00026_A19EstadoActivo = new bool[] {false} ;
         T00026_A169SgCategoriaId = new int[1] ;
         T00026_A171SgActividadId = new int[1] ;
         T00027_A170SgCategoriaNombre = new string[] {""} ;
         T00027_n170SgCategoriaNombre = new bool[] {false} ;
         T00028_A102id_actividad_categoria = new int[1] ;
         T00028_A123nombre_actividad = new string[] {""} ;
         T00028_n123nombre_actividad = new bool[] {false} ;
         T00029_A3EstadoId = new short[1] ;
         T00023_A3EstadoId = new short[1] ;
         T00023_A20EstadoNombre = new string[] {""} ;
         T00023_A19EstadoActivo = new bool[] {false} ;
         T00023_A169SgCategoriaId = new int[1] ;
         T00023_A171SgActividadId = new int[1] ;
         T000210_A3EstadoId = new short[1] ;
         T000211_A3EstadoId = new short[1] ;
         T00022_A3EstadoId = new short[1] ;
         T00022_A20EstadoNombre = new string[] {""} ;
         T00022_A19EstadoActivo = new bool[] {false} ;
         T00022_A169SgCategoriaId = new int[1] ;
         T00022_A171SgActividadId = new int[1] ;
         T000212_A3EstadoId = new short[1] ;
         T000215_A170SgCategoriaNombre = new string[] {""} ;
         T000215_n170SgCategoriaNombre = new bool[] {false} ;
         T000216_A123nombre_actividad = new string[] {""} ;
         T000216_n123nombre_actividad = new bool[] {false} ;
         T000217_A3EstadoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV7EstadoId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Z170SgCategoriaNombre = "";
         Z172SgActividadNombre = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.estado__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.estado__datastore1(),
            new Object[][] {
                new Object[] {
               T00024_A170SgCategoriaNombre, T00024_n170SgCategoriaNombre
               }
               , new Object[] {
               T00025_A102id_actividad_categoria, T00025_A123nombre_actividad, T00025_n123nombre_actividad
               }
               , new Object[] {
               T00027_A170SgCategoriaNombre, T00027_n170SgCategoriaNombre
               }
               , new Object[] {
               T00028_A102id_actividad_categoria, T00028_A123nombre_actividad, T00028_n123nombre_actividad
               }
               , new Object[] {
               T000215_A170SgCategoriaNombre, T000215_n170SgCategoriaNombre
               }
               , new Object[] {
               T000216_A123nombre_actividad, T000216_n123nombre_actividad
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.estado__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estado__default(),
            new Object[][] {
                new Object[] {
               T00022_A3EstadoId, T00022_A20EstadoNombre, T00022_A19EstadoActivo, T00022_A169SgCategoriaId, T00022_A171SgActividadId
               }
               , new Object[] {
               T00023_A3EstadoId, T00023_A20EstadoNombre, T00023_A19EstadoActivo, T00023_A169SgCategoriaId, T00023_A171SgActividadId
               }
               , new Object[] {
               T00026_A3EstadoId, T00026_A20EstadoNombre, T00026_A19EstadoActivo, T00026_A169SgCategoriaId, T00026_A171SgActividadId
               }
               , new Object[] {
               T00029_A3EstadoId
               }
               , new Object[] {
               T000210_A3EstadoId
               }
               , new Object[] {
               T000211_A3EstadoId
               }
               , new Object[] {
               T000212_A3EstadoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000217_A3EstadoId
               }
            }
         );
         AV27Pgmname = "Estado";
      }

      private short wcpOAV7EstadoId ;
      private short Z3EstadoId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7EstadoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A3EstadoId ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound2 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_2 ;
      private int Z169SgCategoriaId ;
      private int Z171SgActividadId ;
      private int N169SgCategoriaId ;
      private int N171SgActividadId ;
      private int A169SgCategoriaId ;
      private int A171SgActividadId ;
      private int trnEnded ;
      private int edtEstadoId_Enabled ;
      private int edtEstadoNombre_Enabled ;
      private int edtSgCategoriaId_Enabled ;
      private int imgprompt_169_Visible ;
      private int edtSgCategoriaNombre_Enabled ;
      private int edtSgActividadId_Enabled ;
      private int imgprompt_171_Visible ;
      private int edtSgActividadNombre_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int AV24Insert_SgCategoriaId ;
      private int AV25Insert_SgActividadId ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV28GXV1 ;
      private int A102id_actividad_categoria ;
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
      private string edtEstadoNombre_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerestadoid_Internalname ;
      private string edtEstadoId_Internalname ;
      private string edtEstadoId_Jsonclick ;
      private string divK2btoolstable_attributecontainerestadonombre_Internalname ;
      private string TempTags ;
      private string edtEstadoNombre_Jsonclick ;
      private string edtEstadoNombre_Class ;
      private string divK2btoolstable_attributecontainerestadoactivo_Internalname ;
      private string chkEstadoActivo_Internalname ;
      private string divK2btoolstable_attributecontainersgcategoriaid_Internalname ;
      private string edtSgCategoriaId_Internalname ;
      private string edtSgCategoriaId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_169_Internalname ;
      private string imgprompt_169_Link ;
      private string divK2btoolstable_attributecontainersgcategorianombre_Internalname ;
      private string edtSgCategoriaNombre_Internalname ;
      private string divK2btoolstable_attributecontainersgactividadid_Internalname ;
      private string edtSgActividadId_Internalname ;
      private string edtSgActividadId_Jsonclick ;
      private string imgprompt_171_Internalname ;
      private string imgprompt_171_Link ;
      private string divK2btoolstable_attributecontainersgactividadnombre_Internalname ;
      private string edtSgActividadNombre_Internalname ;
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
      private string AV27Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode2 ;
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
      private string sCtrlAV7EstadoId ;
      private bool Z19EstadoActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A19EstadoActivo ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool n170SgCategoriaNombre ;
      private bool returnInSub ;
      private bool AV18IsAuthorized ;
      private bool n123nombre_actividad ;
      private string Z20EstadoNombre ;
      private string A20EstadoNombre ;
      private string A170SgCategoriaNombre ;
      private string A172SgActividadNombre ;
      private string AV17UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV15Url ;
      private string A123nombre_actividad ;
      private string Z170SgCategoriaNombre ;
      private string Z172SgActividadNombre ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkEstadoActivo ;
      private Object[] args ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] T00025_A102id_actividad_categoria ;
      private string[] T00025_A123nombre_actividad ;
      private bool[] T00025_n123nombre_actividad ;
      private string[] T00024_A170SgCategoriaNombre ;
      private bool[] T00024_n170SgCategoriaNombre ;
      private IDataStoreProvider pr_default ;
      private short[] T00026_A3EstadoId ;
      private string[] T00026_A20EstadoNombre ;
      private bool[] T00026_A19EstadoActivo ;
      private int[] T00026_A169SgCategoriaId ;
      private int[] T00026_A171SgActividadId ;
      private string[] T00027_A170SgCategoriaNombre ;
      private bool[] T00027_n170SgCategoriaNombre ;
      private int[] T00028_A102id_actividad_categoria ;
      private string[] T00028_A123nombre_actividad ;
      private bool[] T00028_n123nombre_actividad ;
      private short[] T00029_A3EstadoId ;
      private short[] T00023_A3EstadoId ;
      private string[] T00023_A20EstadoNombre ;
      private bool[] T00023_A19EstadoActivo ;
      private int[] T00023_A169SgCategoriaId ;
      private int[] T00023_A171SgActividadId ;
      private short[] T000210_A3EstadoId ;
      private short[] T000211_A3EstadoId ;
      private short[] T00022_A3EstadoId ;
      private string[] T00022_A20EstadoNombre ;
      private bool[] T00022_A19EstadoActivo ;
      private int[] T00022_A169SgCategoriaId ;
      private int[] T00022_A171SgActividadId ;
      private short[] T000212_A3EstadoId ;
      private string[] T000215_A170SgCategoriaNombre ;
      private bool[] T000215_n170SgCategoriaNombre ;
      private string[] T000216_A123nombre_actividad ;
      private bool[] T000216_n123nombre_actividad ;
      private short[] T000217_A3EstadoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV26HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV20AttributeValue ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BContext AV12Context ;
      private SdtK2BAttributeValue_Item AV21AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
   }

   public class estado__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class estado__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("@SgCategoriaId",GXType.Int32,9,0)
        };
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("@SgActividadId",GXType.Int32,9,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("@SgCategoriaId",GXType.Int32,9,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("@SgActividadId",GXType.Int32,9,0)
        };
        Object[] prmT000215;
        prmT000215 = new Object[] {
        new ParDef("@SgCategoriaId",GXType.Int32,9,0)
        };
        Object[] prmT000216;
        prmT000216 = new Object[] {
        new ParDef("@SgActividadId",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00024", "SELECT [nombre_categoria] AS SgCategoriaNombre FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @SgCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT [id_actividad_categoria], [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @SgActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00027", "SELECT [nombre_categoria] AS SgCategoriaNombre FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @SgCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00028", "SELECT [id_actividad_categoria], [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @SgActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00028,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000215", "SELECT [nombre_categoria] AS SgCategoriaNombre FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @SgCategoriaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000215,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000216", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @SgActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000216,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 5 :
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

public class estado__gam : DataStoreHelperBase, IDataStoreHelper
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

public class estado__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT00026;
       prmT00026 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT00029;
       prmT00029 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT00023;
       prmT00023 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT000210;
       prmT000210 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT000211;
       prmT000211 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT00022;
       prmT00022 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT000212;
       prmT000212 = new Object[] {
       new ParDef("@EstadoNombre",GXType.NVarChar,30,0) ,
       new ParDef("@EstadoActivo",GXType.Boolean,4,0) ,
       new ParDef("@SgCategoriaId",GXType.Int32,9,0) ,
       new ParDef("@SgActividadId",GXType.Int32,9,0)
       };
       Object[] prmT000213;
       prmT000213 = new Object[] {
       new ParDef("@EstadoNombre",GXType.NVarChar,30,0) ,
       new ParDef("@EstadoActivo",GXType.Boolean,4,0) ,
       new ParDef("@SgCategoriaId",GXType.Int32,9,0) ,
       new ParDef("@SgActividadId",GXType.Int32,9,0) ,
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT000214;
       prmT000214 = new Object[] {
       new ParDef("@EstadoId",GXType.Int16,4,0)
       };
       Object[] prmT000217;
       prmT000217 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00022", "SELECT [EstadoId], [EstadoNombre], [EstadoActivo], [SgCategoriaId] AS SgCategoriaId, [SgActividadId] FROM [Estado] WITH (UPDLOCK) WHERE [EstadoId] = @EstadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00023", "SELECT [EstadoId], [EstadoNombre], [EstadoActivo], [SgCategoriaId] AS SgCategoriaId, [SgActividadId] FROM [Estado] WHERE [EstadoId] = @EstadoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00026", "SELECT TM1.[EstadoId], TM1.[EstadoNombre], TM1.[EstadoActivo], TM1.[SgCategoriaId] AS SgCategoriaId, TM1.[SgActividadId] FROM [Estado] TM1 WHERE TM1.[EstadoId] = @EstadoId ORDER BY TM1.[EstadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00029", "SELECT [EstadoId] FROM [Estado] WHERE [EstadoId] = @EstadoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00029,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000210", "SELECT TOP 1 [EstadoId] FROM [Estado] WHERE ( [EstadoId] > @EstadoId) ORDER BY [EstadoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000210,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000211", "SELECT TOP 1 [EstadoId] FROM [Estado] WHERE ( [EstadoId] < @EstadoId) ORDER BY [EstadoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000212", "INSERT INTO [Estado]([EstadoNombre], [EstadoActivo], [SgCategoriaId], [SgActividadId]) VALUES(@EstadoNombre, @EstadoActivo, @SgCategoriaId, @SgActividadId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000212)
          ,new CursorDef("T000213", "UPDATE [Estado] SET [EstadoNombre]=@EstadoNombre, [EstadoActivo]=@EstadoActivo, [SgCategoriaId]=@SgCategoriaId, [SgActividadId]=@SgActividadId  WHERE [EstadoId] = @EstadoId", GxErrorMask.GX_NOMASK,prmT000213)
          ,new CursorDef("T000214", "DELETE FROM [Estado]  WHERE [EstadoId] = @EstadoId", GxErrorMask.GX_NOMASK,prmT000214)
          ,new CursorDef("T000217", "SELECT [EstadoId] FROM [Estado] ORDER BY [EstadoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000217,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((int[]) buf[3])[0] = rslt.getInt(4);
             ((int[]) buf[4])[0] = rslt.getInt(5);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((int[]) buf[3])[0] = rslt.getInt(4);
             ((int[]) buf[4])[0] = rslt.getInt(5);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((bool[]) buf[2])[0] = rslt.getBool(3);
             ((int[]) buf[3])[0] = rslt.getInt(4);
             ((int[]) buf[4])[0] = rslt.getInt(5);
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
