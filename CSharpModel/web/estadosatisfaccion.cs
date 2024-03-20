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
   public class estadosatisfaccion : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7EstadoSatisfaccionId = (short)(NumberUtil.Val( GetPar( "EstadoSatisfaccionId"), "."));
               AssignAttri(sPrefix, false, "AV7EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7EstadoSatisfaccionId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7EstadoSatisfaccionId});
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
                  AV7EstadoSatisfaccionId = (short)(NumberUtil.Val( GetPar( "EstadoSatisfaccionId"), "."));
                  AssignAttri(sPrefix, false, "AV7EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7EstadoSatisfaccionId), 4, 0));
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
               Form.Meta.addItem("description", "Estado Satisfaccion", 0) ;
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
            GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
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

      public estadosatisfaccion( )
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

      public estadosatisfaccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EstadoSatisfaccionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EstadoSatisfaccionId = aP1_EstadoSatisfaccionId;
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
         chkEstadoSatisfaccionEstado = new GXCheckbox();
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
            return "estadosatisfaccion_Execute" ;
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
         A21EstadoSatisfaccionEstado = StringUtil.StrToBool( StringUtil.BoolToStr( A21EstadoSatisfaccionEstado));
         AssignAttri(sPrefix, false, "A21EstadoSatisfaccionEstado", A21EstadoSatisfaccionEstado);
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
            RenderHtmlCloseForm033( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "estadosatisfaccion.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadosatisfaccionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoSatisfaccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoSatisfaccionId_Internalname, "Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtEstadoSatisfaccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A4EstadoSatisfaccionId), 4, 0, ".", "")), StringUtil.LTrim( ((edtEstadoSatisfaccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A4EstadoSatisfaccionId), "ZZZ9") : context.localUtil.Format( (decimal)(A4EstadoSatisfaccionId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoSatisfaccionId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoSatisfaccionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_EstadoSatisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadosatisfaccionnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoSatisfaccionNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoSatisfaccionNombre_Internalname, "Satisfacción", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A22EstadoSatisfaccionNombre", A22EstadoSatisfaccionNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoSatisfaccionNombre_Internalname, A22EstadoSatisfaccionNombre, StringUtil.RTrim( context.localUtil.Format( A22EstadoSatisfaccionNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoSatisfaccionNombre_Jsonclick, 0, edtEstadoSatisfaccionNombre_Class, "", "", "", "", 1, edtEstadoSatisfaccionNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_EstadoSatisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadosatisfaccioncalificacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoSatisfaccionCalificacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoSatisfaccionCalificacion_Internalname, "Calificación", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A98EstadoSatisfaccionCalificacion", StringUtil.LTrimStr( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoSatisfaccionCalificacion_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0, ".", "")), StringUtil.LTrim( ((edtEstadoSatisfaccionCalificacion_Enabled!=0) ? context.localUtil.Format( (decimal)(A98EstadoSatisfaccionCalificacion), "ZZZ9") : context.localUtil.Format( (decimal)(A98EstadoSatisfaccionCalificacion), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoSatisfaccionCalificacion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoSatisfaccionCalificacion_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_EstadoSatisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadosatisfaccionestado_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkEstadoSatisfaccionEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkEstadoSatisfaccionEstado_Internalname, "Estado", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A21EstadoSatisfaccionEstado", A21EstadoSatisfaccionEstado);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkEstadoSatisfaccionEstado_Internalname, StringUtil.BoolToStr( A21EstadoSatisfaccionEstado), "", "Estado", 1, chkEstadoSatisfaccionEstado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,36);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoSatisfaccion.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EstadoSatisfaccion.htm");
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
         E11032 ();
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
               Z4EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z4EstadoSatisfaccionId"), ".", ","));
               Z22EstadoSatisfaccionNombre = cgiGet( sPrefix+"Z22EstadoSatisfaccionNombre");
               Z98EstadoSatisfaccionCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z98EstadoSatisfaccionCalificacion"), ".", ","));
               Z21EstadoSatisfaccionEstado = StringUtil.StrToBool( cgiGet( sPrefix+"Z21EstadoSatisfaccionEstado"));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EstadoSatisfaccionId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV7EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vESTADOSATISFACCIONID"), ".", ","));
               AV25Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A4EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( edtEstadoSatisfaccionId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
               A22EstadoSatisfaccionNombre = cgiGet( edtEstadoSatisfaccionNombre_Internalname);
               AssignAttri(sPrefix, false, "A22EstadoSatisfaccionNombre", A22EstadoSatisfaccionNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadoSatisfaccionCalificacion_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadoSatisfaccionCalificacion_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADOSATISFACCIONCALIFICACION");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoSatisfaccionCalificacion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A98EstadoSatisfaccionCalificacion = 0;
                  AssignAttri(sPrefix, false, "A98EstadoSatisfaccionCalificacion", StringUtil.LTrimStr( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0));
               }
               else
               {
                  A98EstadoSatisfaccionCalificacion = (short)(context.localUtil.CToN( cgiGet( edtEstadoSatisfaccionCalificacion_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A98EstadoSatisfaccionCalificacion", StringUtil.LTrimStr( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0));
               }
               A21EstadoSatisfaccionEstado = StringUtil.StrToBool( cgiGet( chkEstadoSatisfaccionEstado_Internalname));
               AssignAttri(sPrefix, false, "A21EstadoSatisfaccionEstado", A21EstadoSatisfaccionEstado);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EstadoSatisfaccion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A4EstadoSatisfaccionId != Z4EstadoSatisfaccionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("estadosatisfaccion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A4EstadoSatisfaccionId = (short)(NumberUtil.Val( GetPar( "EstadoSatisfaccionId"), "."));
                  AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
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
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ESTADOSATISFACCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtEstadoSatisfaccionId_Internalname;
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
                                 E11032 ();
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
                                 E12032 ();
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
                                 E13032 ();
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
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
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
            DisableAttributes033( ) ;
         }
         AssignProp(sPrefix, false, edtEstadoSatisfaccionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtEstadoSatisfaccionCalificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionCalificacion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkEstadoSatisfaccionEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadoSatisfaccionEstado.Enabled), 5, 0), true);
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
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
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  AV16StandardActivityType,  AV17UserActivityType,  AV25Pgmname, out  AV18IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV18IsAuthorized", AV18IsAuthorized);
         if ( ! AV18IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("EstadoSatisfaccion")),UrlEncode(StringUtil.RTrim("EstadoSatisfaccion")),UrlEncode(StringUtil.RTrim(AV16StandardActivityType)),UrlEncode(StringUtil.RTrim(AV17UserActivityType)),UrlEncode(StringUtil.RTrim(AV25Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "EstadoSatisfaccion", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Estado Satisfaccion", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Estado Satisfaccion", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Estado Satisfaccion", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtEstadoSatisfaccionNombre_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtEstadoSatisfaccionNombre_Internalname, "Class", edtEstadoSatisfaccionNombre_Class, true);
            }
            else
            {
               edtEstadoSatisfaccionNombre_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtEstadoSatisfaccionNombre_Internalname, "Class", edtEstadoSatisfaccionNombre_Class, true);
            }
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV21AttributeValueItem.gxTpr_Attributename = "EstadoSatisfaccionId";
            AV21AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A4EstadoSatisfaccionId), 4, 0);
            AV20AttributeValue.Add(AV21AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "EstadoSatisfaccion",  AV20AttributeValue) ;
         }
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La estado satisfaccion %1 fue creada", A22EstadoSatisfaccionNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La estado satisfaccion %1 fue actualizada", A22EstadoSatisfaccionNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La estado satisfaccion %1 fue eliminada", A22EstadoSatisfaccionNombre, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV22Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"EstadoSatisfaccion",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV20AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "EstadoSatisfaccion") ;
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
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A4EstadoSatisfaccionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A4EstadoSatisfaccionId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A4EstadoSatisfaccionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A4EstadoSatisfaccionId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A4EstadoSatisfaccionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A4EstadoSatisfaccionId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A4EstadoSatisfaccionId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A4EstadoSatisfaccionId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A4EstadoSatisfaccionId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A4EstadoSatisfaccionId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A4EstadoSatisfaccionId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A4EstadoSatisfaccionId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A4EstadoSatisfaccionId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E13032( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "EstadoSatisfaccion") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"EstadoSatisfaccion"}, true);
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

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z22EstadoSatisfaccionNombre = T00033_A22EstadoSatisfaccionNombre[0];
               Z98EstadoSatisfaccionCalificacion = T00033_A98EstadoSatisfaccionCalificacion[0];
               Z21EstadoSatisfaccionEstado = T00033_A21EstadoSatisfaccionEstado[0];
            }
            else
            {
               Z22EstadoSatisfaccionNombre = A22EstadoSatisfaccionNombre;
               Z98EstadoSatisfaccionCalificacion = A98EstadoSatisfaccionCalificacion;
               Z21EstadoSatisfaccionEstado = A21EstadoSatisfaccionEstado;
            }
         }
         if ( GX_JID == -4 )
         {
            Z4EstadoSatisfaccionId = A4EstadoSatisfaccionId;
            Z22EstadoSatisfaccionNombre = A22EstadoSatisfaccionNombre;
            Z98EstadoSatisfaccionCalificacion = A98EstadoSatisfaccionCalificacion;
            Z21EstadoSatisfaccionEstado = A21EstadoSatisfaccionEstado;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEstadoSatisfaccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoSatisfaccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionId_Enabled), 5, 0), true);
         edtEstadoSatisfaccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoSatisfaccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionId_Enabled), 5, 0), true);
         if ( ! (0==AV7EstadoSatisfaccionId) )
         {
            A4EstadoSatisfaccionId = AV7EstadoSatisfaccionId;
            AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
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

      protected void Load033( )
      {
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A4EstadoSatisfaccionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A22EstadoSatisfaccionNombre = T00034_A22EstadoSatisfaccionNombre[0];
            AssignAttri(sPrefix, false, "A22EstadoSatisfaccionNombre", A22EstadoSatisfaccionNombre);
            A98EstadoSatisfaccionCalificacion = T00034_A98EstadoSatisfaccionCalificacion[0];
            AssignAttri(sPrefix, false, "A98EstadoSatisfaccionCalificacion", StringUtil.LTrimStr( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0));
            A21EstadoSatisfaccionEstado = T00034_A21EstadoSatisfaccionEstado[0];
            AssignAttri(sPrefix, false, "A21EstadoSatisfaccionEstado", A21EstadoSatisfaccionEstado);
            ZM033( -4) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV25Pgmname = "EstadoSatisfaccion";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "EstadoSatisfaccion";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A22EstadoSatisfaccionNombre)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Satisfacción", "", "", "", "", "", "", "", ""), 1, "ESTADOSATISFACCIONNOMBRE");
            AnyError = 1;
            GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A4EstadoSatisfaccionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A4EstadoSatisfaccionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 4) ;
            RcdFound3 = 1;
            A4EstadoSatisfaccionId = T00033_A4EstadoSatisfaccionId[0];
            AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
            A22EstadoSatisfaccionNombre = T00033_A22EstadoSatisfaccionNombre[0];
            AssignAttri(sPrefix, false, "A22EstadoSatisfaccionNombre", A22EstadoSatisfaccionNombre);
            A98EstadoSatisfaccionCalificacion = T00033_A98EstadoSatisfaccionCalificacion[0];
            AssignAttri(sPrefix, false, "A98EstadoSatisfaccionCalificacion", StringUtil.LTrimStr( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0));
            A21EstadoSatisfaccionEstado = T00033_A21EstadoSatisfaccionEstado[0];
            AssignAttri(sPrefix, false, "A21EstadoSatisfaccionEstado", A21EstadoSatisfaccionEstado);
            Z4EstadoSatisfaccionId = A4EstadoSatisfaccionId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A4EstadoSatisfaccionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00036_A4EstadoSatisfaccionId[0] < A4EstadoSatisfaccionId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00036_A4EstadoSatisfaccionId[0] > A4EstadoSatisfaccionId ) ) )
            {
               A4EstadoSatisfaccionId = T00036_A4EstadoSatisfaccionId[0];
               AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A4EstadoSatisfaccionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00037_A4EstadoSatisfaccionId[0] > A4EstadoSatisfaccionId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00037_A4EstadoSatisfaccionId[0] < A4EstadoSatisfaccionId ) ) )
            {
               A4EstadoSatisfaccionId = T00037_A4EstadoSatisfaccionId[0];
               AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A4EstadoSatisfaccionId != Z4EstadoSatisfaccionId )
               {
                  A4EstadoSatisfaccionId = Z4EstadoSatisfaccionId;
                  AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ESTADOSATISFACCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoSatisfaccionId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A4EstadoSatisfaccionId != Z4EstadoSatisfaccionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ESTADOSATISFACCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtEstadoSatisfaccionId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( A4EstadoSatisfaccionId != Z4EstadoSatisfaccionId )
         {
            A4EstadoSatisfaccionId = Z4EstadoSatisfaccionId;
            AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ESTADOSATISFACCIONID");
            AnyError = 1;
            GX_FocusControl = edtEstadoSatisfaccionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEstadoSatisfaccionNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadoSatisfaccion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z22EstadoSatisfaccionNombre, T00032_A22EstadoSatisfaccionNombre[0]) != 0 ) || ( Z98EstadoSatisfaccionCalificacion != T00032_A98EstadoSatisfaccionCalificacion[0] ) || ( Z21EstadoSatisfaccionEstado != T00032_A21EstadoSatisfaccionEstado[0] ) )
            {
               if ( StringUtil.StrCmp(Z22EstadoSatisfaccionNombre, T00032_A22EstadoSatisfaccionNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("estadosatisfaccion:[seudo value changed for attri]"+"EstadoSatisfaccionNombre");
                  GXUtil.WriteLogRaw("Old: ",Z22EstadoSatisfaccionNombre);
                  GXUtil.WriteLogRaw("Current: ",T00032_A22EstadoSatisfaccionNombre[0]);
               }
               if ( Z98EstadoSatisfaccionCalificacion != T00032_A98EstadoSatisfaccionCalificacion[0] )
               {
                  GXUtil.WriteLog("estadosatisfaccion:[seudo value changed for attri]"+"EstadoSatisfaccionCalificacion");
                  GXUtil.WriteLogRaw("Old: ",Z98EstadoSatisfaccionCalificacion);
                  GXUtil.WriteLogRaw("Current: ",T00032_A98EstadoSatisfaccionCalificacion[0]);
               }
               if ( Z21EstadoSatisfaccionEstado != T00032_A21EstadoSatisfaccionEstado[0] )
               {
                  GXUtil.WriteLog("estadosatisfaccion:[seudo value changed for attri]"+"EstadoSatisfaccionEstado");
                  GXUtil.WriteLogRaw("Old: ",Z21EstadoSatisfaccionEstado);
                  GXUtil.WriteLogRaw("Current: ",T00032_A21EstadoSatisfaccionEstado[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EstadoSatisfaccion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         if ( ! IsAuthorized("estadosatisfaccion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00038 */
                     pr_default.execute(6, new Object[] {A22EstadoSatisfaccionNombre, A98EstadoSatisfaccionCalificacion, A21EstadoSatisfaccionEstado});
                     A4EstadoSatisfaccionId = T00038_A4EstadoSatisfaccionId[0];
                     AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("EstadoSatisfaccion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         if ( ! IsAuthorized("estadosatisfaccion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00039 */
                     pr_default.execute(7, new Object[] {A22EstadoSatisfaccionNombre, A98EstadoSatisfaccionCalificacion, A21EstadoSatisfaccionEstado, A4EstadoSatisfaccionId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("EstadoSatisfaccion");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EstadoSatisfaccion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("estadosatisfaccion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000310 */
                  pr_default.execute(8, new Object[] {A4EstadoSatisfaccionId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("EstadoSatisfaccion");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "EstadoSatisfaccion";
            AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000311 */
            pr_default.execute(9, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Capacitacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000312 */
            pr_default.execute(10, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Programador"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000313 */
            pr_default.execute(11, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Rendimiento"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Cataloga"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000315 */
            pr_default.execute(13, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Atencion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000316 */
            pr_default.execute(14, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Tiempo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000317 */
            pr_default.execute(15, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Tecnico Profesionalismo"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000318 */
            pr_default.execute(16, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Tecnico Competente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000319 */
            pr_default.execute(17, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Tecnico Problema"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000320 */
            pr_default.execute(18, new Object[] {A4EstadoSatisfaccionId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"+" ("+"Satisfaccion Resuelto"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("estadosatisfaccion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("estadosatisfaccion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000321 */
         pr_default.execute(19);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound3 = 1;
            A4EstadoSatisfaccionId = T000321_A4EstadoSatisfaccionId[0];
            AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound3 = 1;
            A4EstadoSatisfaccionId = T000321_A4EstadoSatisfaccionId[0];
            AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtEstadoSatisfaccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoSatisfaccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionId_Enabled), 5, 0), true);
         edtEstadoSatisfaccionNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoSatisfaccionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionNombre_Enabled), 5, 0), true);
         edtEstadoSatisfaccionCalificacion_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoSatisfaccionCalificacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoSatisfaccionCalificacion_Enabled), 5, 0), true);
         chkEstadoSatisfaccionEstado.Enabled = 0;
         AssignProp(sPrefix, false, chkEstadoSatisfaccionEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkEstadoSatisfaccionEstado.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.AddJavascriptSource("gxcfg.js", "?202418814116", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("estadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EstadoSatisfaccionId,4,0))}, new string[] {"Gx_mode","EstadoSatisfaccionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EstadoSatisfaccion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("estadosatisfaccion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z4EstadoSatisfaccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z4EstadoSatisfaccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z22EstadoSatisfaccionNombre", Z22EstadoSatisfaccionNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z98EstadoSatisfaccionCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z98EstadoSatisfaccionCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z21EstadoSatisfaccionEstado", Z21EstadoSatisfaccionEstado);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7EstadoSatisfaccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7EstadoSatisfaccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vESTADOSATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EstadoSatisfaccionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm033( )
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
         return "EstadoSatisfaccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Estado Satisfaccion" ;
      }

      protected void InitializeNonKey033( )
      {
         A22EstadoSatisfaccionNombre = "";
         AssignAttri(sPrefix, false, "A22EstadoSatisfaccionNombre", A22EstadoSatisfaccionNombre);
         A98EstadoSatisfaccionCalificacion = 0;
         AssignAttri(sPrefix, false, "A98EstadoSatisfaccionCalificacion", StringUtil.LTrimStr( (decimal)(A98EstadoSatisfaccionCalificacion), 4, 0));
         A21EstadoSatisfaccionEstado = false;
         AssignAttri(sPrefix, false, "A21EstadoSatisfaccionEstado", A21EstadoSatisfaccionEstado);
         Z22EstadoSatisfaccionNombre = "";
         Z98EstadoSatisfaccionCalificacion = 0;
         Z21EstadoSatisfaccionEstado = false;
      }

      protected void InitAll033( )
      {
         A4EstadoSatisfaccionId = 0;
         AssignAttri(sPrefix, false, "A4EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(A4EstadoSatisfaccionId), 4, 0));
         InitializeNonKey033( ) ;
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
         sCtrlAV7EstadoSatisfaccionId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "estadosatisfaccion", GetJustCreated( ));
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
            AV7EstadoSatisfaccionId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7EstadoSatisfaccionId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EstadoSatisfaccionId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7EstadoSatisfaccionId != wcpOAV7EstadoSatisfaccionId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7EstadoSatisfaccionId = AV7EstadoSatisfaccionId;
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
         sCtrlAV7EstadoSatisfaccionId = cgiGet( sPrefix+"AV7EstadoSatisfaccionId_CTRL");
         if ( StringUtil.Len( sCtrlAV7EstadoSatisfaccionId) > 0 )
         {
            AV7EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7EstadoSatisfaccionId), ".", ","));
            AssignAttri(sPrefix, false, "AV7EstadoSatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7EstadoSatisfaccionId), 4, 0));
         }
         else
         {
            AV7EstadoSatisfaccionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7EstadoSatisfaccionId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7EstadoSatisfaccionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EstadoSatisfaccionId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7EstadoSatisfaccionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7EstadoSatisfaccionId_CTRL", StringUtil.RTrim( sCtrlAV7EstadoSatisfaccionId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188141121", true, true);
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
         context.AddJavascriptSource("estadosatisfaccion.js", "?2024188141121", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtEstadoSatisfaccionId_Internalname = sPrefix+"ESTADOSATISFACCIONID";
         divK2btoolstable_attributecontainerestadosatisfaccionid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOSATISFACCIONID";
         edtEstadoSatisfaccionNombre_Internalname = sPrefix+"ESTADOSATISFACCIONNOMBRE";
         divK2btoolstable_attributecontainerestadosatisfaccionnombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOSATISFACCIONNOMBRE";
         edtEstadoSatisfaccionCalificacion_Internalname = sPrefix+"ESTADOSATISFACCIONCALIFICACION";
         divK2btoolstable_attributecontainerestadosatisfaccioncalificacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOSATISFACCIONCALIFICACION";
         chkEstadoSatisfaccionEstado_Internalname = sPrefix+"ESTADOSATISFACCIONESTADO";
         divK2btoolstable_attributecontainerestadosatisfaccionestado_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOSATISFACCIONESTADO";
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
         Form.Caption = "Estado Satisfaccion";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         chkEstadoSatisfaccionEstado.Enabled = 1;
         edtEstadoSatisfaccionCalificacion_Jsonclick = "";
         edtEstadoSatisfaccionCalificacion_Enabled = 1;
         edtEstadoSatisfaccionNombre_Jsonclick = "";
         edtEstadoSatisfaccionNombre_Class = "Attribute_Trn Attribute_Required";
         edtEstadoSatisfaccionNombre_Enabled = 1;
         edtEstadoSatisfaccionId_Jsonclick = "";
         edtEstadoSatisfaccionId_Enabled = 0;
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
         chkEstadoSatisfaccionEstado.Name = "ESTADOSATISFACCIONESTADO";
         chkEstadoSatisfaccionEstado.WebTags = "";
         chkEstadoSatisfaccionEstado.Caption = "";
         AssignProp(sPrefix, false, chkEstadoSatisfaccionEstado_Internalname, "TitleCaption", chkEstadoSatisfaccionEstado.Caption, true);
         chkEstadoSatisfaccionEstado.CheckedValue = "false";
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7EstadoSatisfaccionId',fld:'vESTADOSATISFACCIONID',pic:'ZZZ9'},{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A4EstadoSatisfaccionId',fld:'ESTADOSATISFACCIONID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A22EstadoSatisfaccionNombre',fld:'ESTADOSATISFACCIONNOMBRE',pic:''},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A4EstadoSatisfaccionId',fld:'ESTADOSATISFACCIONID',pic:'ZZZ9'},{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13032',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]");
         setEventMetadata("'DOCANCEL'",",oparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]}");
         setEventMetadata("VALID_ESTADOSATISFACCIONID","{handler:'Valid_Estadosatisfaccionid',iparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]");
         setEventMetadata("VALID_ESTADOSATISFACCIONID",",oparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]}");
         setEventMetadata("VALID_ESTADOSATISFACCIONNOMBRE","{handler:'Valid_Estadosatisfaccionnombre',iparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]");
         setEventMetadata("VALID_ESTADOSATISFACCIONNOMBRE",",oparms:[{av:'A21EstadoSatisfaccionEstado',fld:'ESTADOSATISFACCIONESTADO',pic:''}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z22EstadoSatisfaccionNombre = "";
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
         A22EstadoSatisfaccionNombre = "";
         TempTags = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV25Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
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
         T00034_A4EstadoSatisfaccionId = new short[1] ;
         T00034_A22EstadoSatisfaccionNombre = new string[] {""} ;
         T00034_A98EstadoSatisfaccionCalificacion = new short[1] ;
         T00034_A21EstadoSatisfaccionEstado = new bool[] {false} ;
         T00035_A4EstadoSatisfaccionId = new short[1] ;
         T00033_A4EstadoSatisfaccionId = new short[1] ;
         T00033_A22EstadoSatisfaccionNombre = new string[] {""} ;
         T00033_A98EstadoSatisfaccionCalificacion = new short[1] ;
         T00033_A21EstadoSatisfaccionEstado = new bool[] {false} ;
         T00036_A4EstadoSatisfaccionId = new short[1] ;
         T00037_A4EstadoSatisfaccionId = new short[1] ;
         T00032_A4EstadoSatisfaccionId = new short[1] ;
         T00032_A22EstadoSatisfaccionNombre = new string[] {""} ;
         T00032_A98EstadoSatisfaccionCalificacion = new short[1] ;
         T00032_A21EstadoSatisfaccionEstado = new bool[] {false} ;
         T00038_A4EstadoSatisfaccionId = new short[1] ;
         T000311_A7SatisfaccionId = new long[1] ;
         T000312_A7SatisfaccionId = new long[1] ;
         T000313_A7SatisfaccionId = new long[1] ;
         T000314_A7SatisfaccionId = new long[1] ;
         T000315_A7SatisfaccionId = new long[1] ;
         T000316_A7SatisfaccionId = new long[1] ;
         T000317_A7SatisfaccionId = new long[1] ;
         T000318_A7SatisfaccionId = new long[1] ;
         T000319_A7SatisfaccionId = new long[1] ;
         T000320_A7SatisfaccionId = new long[1] ;
         T000321_A4EstadoSatisfaccionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV7EstadoSatisfaccionId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.estadosatisfaccion__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.estadosatisfaccion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.estadosatisfaccion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.estadosatisfaccion__default(),
            new Object[][] {
                new Object[] {
               T00032_A4EstadoSatisfaccionId, T00032_A22EstadoSatisfaccionNombre, T00032_A98EstadoSatisfaccionCalificacion, T00032_A21EstadoSatisfaccionEstado
               }
               , new Object[] {
               T00033_A4EstadoSatisfaccionId, T00033_A22EstadoSatisfaccionNombre, T00033_A98EstadoSatisfaccionCalificacion, T00033_A21EstadoSatisfaccionEstado
               }
               , new Object[] {
               T00034_A4EstadoSatisfaccionId, T00034_A22EstadoSatisfaccionNombre, T00034_A98EstadoSatisfaccionCalificacion, T00034_A21EstadoSatisfaccionEstado
               }
               , new Object[] {
               T00035_A4EstadoSatisfaccionId
               }
               , new Object[] {
               T00036_A4EstadoSatisfaccionId
               }
               , new Object[] {
               T00037_A4EstadoSatisfaccionId
               }
               , new Object[] {
               T00038_A4EstadoSatisfaccionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000311_A7SatisfaccionId
               }
               , new Object[] {
               T000312_A7SatisfaccionId
               }
               , new Object[] {
               T000313_A7SatisfaccionId
               }
               , new Object[] {
               T000314_A7SatisfaccionId
               }
               , new Object[] {
               T000315_A7SatisfaccionId
               }
               , new Object[] {
               T000316_A7SatisfaccionId
               }
               , new Object[] {
               T000317_A7SatisfaccionId
               }
               , new Object[] {
               T000318_A7SatisfaccionId
               }
               , new Object[] {
               T000319_A7SatisfaccionId
               }
               , new Object[] {
               T000320_A7SatisfaccionId
               }
               , new Object[] {
               T000321_A4EstadoSatisfaccionId
               }
            }
         );
         AV25Pgmname = "EstadoSatisfaccion";
      }

      private short wcpOAV7EstadoSatisfaccionId ;
      private short Z4EstadoSatisfaccionId ;
      private short Z98EstadoSatisfaccionCalificacion ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7EstadoSatisfaccionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A4EstadoSatisfaccionId ;
      private short A98EstadoSatisfaccionCalificacion ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int edtEstadoSatisfaccionId_Enabled ;
      private int edtEstadoSatisfaccionNombre_Enabled ;
      private int edtEstadoSatisfaccionCalificacion_Enabled ;
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
      private string edtEstadoSatisfaccionNombre_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerestadosatisfaccionid_Internalname ;
      private string edtEstadoSatisfaccionId_Internalname ;
      private string edtEstadoSatisfaccionId_Jsonclick ;
      private string divK2btoolstable_attributecontainerestadosatisfaccionnombre_Internalname ;
      private string TempTags ;
      private string edtEstadoSatisfaccionNombre_Jsonclick ;
      private string edtEstadoSatisfaccionNombre_Class ;
      private string divK2btoolstable_attributecontainerestadosatisfaccioncalificacion_Internalname ;
      private string edtEstadoSatisfaccionCalificacion_Internalname ;
      private string edtEstadoSatisfaccionCalificacion_Jsonclick ;
      private string divK2btoolstable_attributecontainerestadosatisfaccionestado_Internalname ;
      private string chkEstadoSatisfaccionEstado_Internalname ;
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
      private string sMode3 ;
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
      private string sCtrlAV7EstadoSatisfaccionId ;
      private bool Z21EstadoSatisfaccionEstado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A21EstadoSatisfaccionEstado ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV18IsAuthorized ;
      private string Z22EstadoSatisfaccionNombre ;
      private string A22EstadoSatisfaccionNombre ;
      private string AV17UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV15Url ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkEstadoSatisfaccionEstado ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private short[] T00034_A4EstadoSatisfaccionId ;
      private string[] T00034_A22EstadoSatisfaccionNombre ;
      private short[] T00034_A98EstadoSatisfaccionCalificacion ;
      private bool[] T00034_A21EstadoSatisfaccionEstado ;
      private short[] T00035_A4EstadoSatisfaccionId ;
      private short[] T00033_A4EstadoSatisfaccionId ;
      private string[] T00033_A22EstadoSatisfaccionNombre ;
      private short[] T00033_A98EstadoSatisfaccionCalificacion ;
      private bool[] T00033_A21EstadoSatisfaccionEstado ;
      private short[] T00036_A4EstadoSatisfaccionId ;
      private short[] T00037_A4EstadoSatisfaccionId ;
      private short[] T00032_A4EstadoSatisfaccionId ;
      private string[] T00032_A22EstadoSatisfaccionNombre ;
      private short[] T00032_A98EstadoSatisfaccionCalificacion ;
      private bool[] T00032_A21EstadoSatisfaccionEstado ;
      private short[] T00038_A4EstadoSatisfaccionId ;
      private long[] T000311_A7SatisfaccionId ;
      private long[] T000312_A7SatisfaccionId ;
      private long[] T000313_A7SatisfaccionId ;
      private long[] T000314_A7SatisfaccionId ;
      private long[] T000315_A7SatisfaccionId ;
      private long[] T000316_A7SatisfaccionId ;
      private long[] T000317_A7SatisfaccionId ;
      private long[] T000318_A7SatisfaccionId ;
      private long[] T000319_A7SatisfaccionId ;
      private long[] T000320_A7SatisfaccionId ;
      private short[] T000321_A4EstadoSatisfaccionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV24HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV20AttributeValue ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BContext AV12Context ;
      private SdtK2BAttributeValue_Item AV21AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
   }

   public class estadosatisfaccion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class estadosatisfaccion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class estadosatisfaccion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class estadosatisfaccion__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new ForEachCursor(def[15])
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00034;
       prmT00034 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT00035;
       prmT00035 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT00033;
       prmT00033 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT00036;
       prmT00036 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT00037;
       prmT00037 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT00032;
       prmT00032 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT00038;
       prmT00038 = new Object[] {
       new ParDef("@EstadoSatisfaccionNombre",GXType.NVarChar,30,0) ,
       new ParDef("@EstadoSatisfaccionCalificacion",GXType.Int16,4,0) ,
       new ParDef("@EstadoSatisfaccionEstado",GXType.Boolean,4,0)
       };
       Object[] prmT00039;
       prmT00039 = new Object[] {
       new ParDef("@EstadoSatisfaccionNombre",GXType.NVarChar,30,0) ,
       new ParDef("@EstadoSatisfaccionCalificacion",GXType.Int16,4,0) ,
       new ParDef("@EstadoSatisfaccionEstado",GXType.Boolean,4,0) ,
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000310;
       prmT000310 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000311;
       prmT000311 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000312;
       prmT000312 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000313;
       prmT000313 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000314;
       prmT000314 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000315;
       prmT000315 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000316;
       prmT000316 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000317;
       prmT000317 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000318;
       prmT000318 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000319;
       prmT000319 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000320;
       prmT000320 = new Object[] {
       new ParDef("@EstadoSatisfaccionId",GXType.Int16,4,0)
       };
       Object[] prmT000321;
       prmT000321 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T00032", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre], [EstadoSatisfaccionCalificacion], [EstadoSatisfaccionEstado] FROM [EstadoSatisfaccion] WITH (UPDLOCK) WHERE [EstadoSatisfaccionId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00033", "SELECT [EstadoSatisfaccionId], [EstadoSatisfaccionNombre], [EstadoSatisfaccionCalificacion], [EstadoSatisfaccionEstado] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00034", "SELECT TM1.[EstadoSatisfaccionId], TM1.[EstadoSatisfaccionNombre], TM1.[EstadoSatisfaccionCalificacion], TM1.[EstadoSatisfaccionEstado] FROM [EstadoSatisfaccion] TM1 WHERE TM1.[EstadoSatisfaccionId] = @EstadoSatisfaccionId ORDER BY TM1.[EstadoSatisfaccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00035", "SELECT [EstadoSatisfaccionId] FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @EstadoSatisfaccionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00036", "SELECT TOP 1 [EstadoSatisfaccionId] FROM [EstadoSatisfaccion] WHERE ( [EstadoSatisfaccionId] > @EstadoSatisfaccionId) ORDER BY [EstadoSatisfaccionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00037", "SELECT TOP 1 [EstadoSatisfaccionId] FROM [EstadoSatisfaccion] WHERE ( [EstadoSatisfaccionId] < @EstadoSatisfaccionId) ORDER BY [EstadoSatisfaccionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00038", "INSERT INTO [EstadoSatisfaccion]([EstadoSatisfaccionNombre], [EstadoSatisfaccionCalificacion], [EstadoSatisfaccionEstado]) VALUES(@EstadoSatisfaccionNombre, @EstadoSatisfaccionCalificacion, @EstadoSatisfaccionEstado); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT00038)
          ,new CursorDef("T00039", "UPDATE [EstadoSatisfaccion] SET [EstadoSatisfaccionNombre]=@EstadoSatisfaccionNombre, [EstadoSatisfaccionCalificacion]=@EstadoSatisfaccionCalificacion, [EstadoSatisfaccionEstado]=@EstadoSatisfaccionEstado  WHERE [EstadoSatisfaccionId] = @EstadoSatisfaccionId", GxErrorMask.GX_NOMASK,prmT00039)
          ,new CursorDef("T000310", "DELETE FROM [EstadoSatisfaccion]  WHERE [EstadoSatisfaccionId] = @EstadoSatisfaccionId", GxErrorMask.GX_NOMASK,prmT000310)
          ,new CursorDef("T000311", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionCapacitacionId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000312", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionProgramadorId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000312,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000313", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionRendimientoId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000313,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000314", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionCatalogaId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000315", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionAtencionId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000316", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionTiempoId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000317", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionTecnicoProfesionalismoId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000317,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000318", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionTecnicoCompetenteId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000318,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000319", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionTecnicoProblemaId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000319,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000320", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionResueltoId] = @EstadoSatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000320,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000321", "SELECT [EstadoSatisfaccionId] FROM [EstadoSatisfaccion] ORDER BY [EstadoSatisfaccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000321,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((short[]) buf[2])[0] = rslt.getShort(3);
             ((bool[]) buf[3])[0] = rslt.getBool(4);
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
             return;
          case 10 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 11 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 15 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 16 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 17 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 18 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 19 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
