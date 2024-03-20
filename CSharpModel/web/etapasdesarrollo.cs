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
   public class etapasdesarrollo : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7EtapaDesarrolloId = (short)(NumberUtil.Val( GetPar( "EtapaDesarrolloId"), "."));
               AssignAttri(sPrefix, false, "AV7EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV7EtapaDesarrolloId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7EtapaDesarrolloId});
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
                  AV7EtapaDesarrolloId = (short)(NumberUtil.Val( GetPar( "EtapaDesarrolloId"), "."));
                  AssignAttri(sPrefix, false, "AV7EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV7EtapaDesarrolloId), 4, 0));
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
               Form.Meta.addItem("description", "Etapas Desarrollo", 0) ;
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
            GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
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

      public etapasdesarrollo( )
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

      public etapasdesarrollo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_EtapaDesarrolloId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7EtapaDesarrolloId = aP1_EtapaDesarrolloId;
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
            return "etapasdesarrollo_Execute" ;
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
            RenderHtmlCloseForm0L22( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "etapasdesarrollo.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineretapadesarrolloid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEtapaDesarrolloId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEtapaDesarrolloId_Internalname, "Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtEtapaDesarrolloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ".", "")), StringUtil.LTrim( ((edtEtapaDesarrolloId_Enabled!=0) ? context.localUtil.Format( (decimal)(A290EtapaDesarrolloId), "ZZZ9") : context.localUtil.Format( (decimal)(A290EtapaDesarrolloId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEtapaDesarrolloId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEtapaDesarrolloId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_EtapasDesarrollo.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineretapadesarrollonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEtapaDesarrolloNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEtapaDesarrolloNombre_Internalname, "Desarrollo Nombre", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A291EtapaDesarrolloNombre", A291EtapaDesarrolloNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEtapaDesarrolloNombre_Internalname, A291EtapaDesarrolloNombre, StringUtil.RTrim( context.localUtil.Format( A291EtapaDesarrolloNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEtapaDesarrolloNombre_Jsonclick, 0, edtEtapaDesarrolloNombre_Class, "", "", "", "", 1, edtEtapaDesarrolloNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_EtapasDesarrollo.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontaineretapadesarrollousuarioregistro_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEtapaDesarrolloUsuarioRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEtapaDesarrolloUsuarioRegistro_Internalname, "Usuario Registro", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
         GxWebStd.gx_single_line_edit( context, edtEtapaDesarrolloUsuarioRegistro_Internalname, A292EtapaDesarrolloUsuarioRegistro, StringUtil.RTrim( context.localUtil.Format( A292EtapaDesarrolloUsuarioRegistro, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEtapaDesarrolloUsuarioRegistro_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEtapaDesarrolloUsuarioRegistro_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_EtapasDesarrollo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_EtapasDesarrollo.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_EtapasDesarrollo.htm");
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
         E110L2 ();
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
               Z290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z290EtapaDesarrolloId"), ".", ","));
               Z291EtapaDesarrolloNombre = cgiGet( sPrefix+"Z291EtapaDesarrolloNombre");
               Z292EtapaDesarrolloUsuarioRegistro = cgiGet( sPrefix+"Z292EtapaDesarrolloUsuarioRegistro");
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EtapaDesarrolloId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV7EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vETAPADESARROLLOID"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ".", ","));
               AV27Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( edtEtapaDesarrolloId_Internalname), ".", ","));
               n290EtapaDesarrolloId = false;
               AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
               A291EtapaDesarrolloNombre = cgiGet( edtEtapaDesarrolloNombre_Internalname);
               AssignAttri(sPrefix, false, "A291EtapaDesarrolloNombre", A291EtapaDesarrolloNombre);
               A292EtapaDesarrolloUsuarioRegistro = cgiGet( edtEtapaDesarrolloUsuarioRegistro_Internalname);
               AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EtapasDesarrollo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A290EtapaDesarrolloId != Z290EtapaDesarrolloId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("etapasdesarrollo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A290EtapaDesarrolloId = (short)(NumberUtil.Val( GetPar( "EtapaDesarrolloId"), "."));
                  n290EtapaDesarrolloId = false;
                  AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
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
                     sMode22 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode22;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound22 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ETAPADESARROLLOID");
                        AnyError = 1;
                        GX_FocusControl = edtEtapaDesarrolloId_Internalname;
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
                                 E110L2 ();
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
                                 E120L2 ();
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
                                 E130L2 ();
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
            E120L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0L22( ) ;
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
            DisableAttributes0L22( ) ;
         }
         AssignProp(sPrefix, false, edtEtapaDesarrolloNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloNombre_Enabled), 5, 0), true);
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L22( ) ;
            }
            else
            {
               CheckExtendedTable0L22( ) ;
               CloseExtendedTableCursors0L22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0L0( )
      {
      }

      protected void E110L2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "EtapasDesarrollo",  "EtapasDesarrollo",  AV16StandardActivityType,  AV17UserActivityType,  AV27Pgmname, out  AV18IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV18IsAuthorized", AV18IsAuthorized);
         if ( ! AV18IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("EtapasDesarrollo")),UrlEncode(StringUtil.RTrim("EtapasDesarrollo")),UrlEncode(StringUtil.RTrim(AV16StandardActivityType)),UrlEncode(StringUtil.RTrim(AV17UserActivityType)),UrlEncode(StringUtil.RTrim(AV27Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "EtapasDesarrollo", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Etapas Desarrollo", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Etapas Desarrollo", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Etapas Desarrollo", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtEtapaDesarrolloNombre_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtEtapaDesarrolloNombre_Internalname, "Class", edtEtapaDesarrolloNombre_Class, true);
            }
            else
            {
               edtEtapaDesarrolloNombre_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtEtapaDesarrolloNombre_Internalname, "Class", edtEtapaDesarrolloNombre_Class, true);
            }
         }
      }

      protected void E120L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV21AttributeValueItem.gxTpr_Attributename = "EtapaDesarrolloId";
            AV21AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A290EtapaDesarrolloId), 4, 0);
            AV20AttributeValue.Add(AV21AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "EtapasDesarrollo",  AV20AttributeValue) ;
         }
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La etapas desarrollo %1 fue creada", A291EtapaDesarrolloNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La etapas desarrollo %1 fue actualizada", A291EtapaDesarrolloNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La etapas desarrollo %1 fue eliminada", A291EtapaDesarrolloNombre, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV22Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"EtapasDesarrollo",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV20AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "EtapasDesarrollo") ;
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
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A290EtapaDesarrolloId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A290EtapaDesarrolloId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A290EtapaDesarrolloId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A290EtapaDesarrolloId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A290EtapaDesarrolloId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A290EtapaDesarrolloId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A290EtapaDesarrolloId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A290EtapaDesarrolloId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A290EtapaDesarrolloId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A290EtapaDesarrolloId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A290EtapaDesarrolloId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A290EtapaDesarrolloId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A290EtapaDesarrolloId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130L2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "EtapasDesarrollo") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"EtapasDesarrollo"}, true);
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

      protected void ZM0L22( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z291EtapaDesarrolloNombre = T000L3_A291EtapaDesarrolloNombre[0];
               Z292EtapaDesarrolloUsuarioRegistro = T000L3_A292EtapaDesarrolloUsuarioRegistro[0];
            }
            else
            {
               Z291EtapaDesarrolloNombre = A291EtapaDesarrolloNombre;
               Z292EtapaDesarrolloUsuarioRegistro = A292EtapaDesarrolloUsuarioRegistro;
            }
         }
         if ( GX_JID == -6 )
         {
            Z290EtapaDesarrolloId = A290EtapaDesarrolloId;
            Z291EtapaDesarrolloNombre = A291EtapaDesarrolloNombre;
            Z292EtapaDesarrolloUsuarioRegistro = A292EtapaDesarrolloUsuarioRegistro;
         }
      }

      protected void standaloneNotModal( )
      {
         edtEtapaDesarrolloId_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloId_Enabled), 5, 0), true);
         edtEtapaDesarrolloUsuarioRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloUsuarioRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloUsuarioRegistro_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtEtapaDesarrolloId_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloId_Enabled), 5, 0), true);
         edtEtapaDesarrolloUsuarioRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloUsuarioRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloUsuarioRegistro_Enabled), 5, 0), true);
         if ( ! (0==AV7EtapaDesarrolloId) )
         {
            A290EtapaDesarrolloId = AV7EtapaDesarrolloId;
            n290EtapaDesarrolloId = false;
            AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A292EtapaDesarrolloUsuarioRegistro)) && ( Gx_BScreen == 0 ) )
         {
            A292EtapaDesarrolloUsuarioRegistro = AV25WebSession.Get("UsuarioConectado");
            AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
         }
      }

      protected void Load0L22( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A291EtapaDesarrolloNombre = T000L4_A291EtapaDesarrolloNombre[0];
            AssignAttri(sPrefix, false, "A291EtapaDesarrolloNombre", A291EtapaDesarrolloNombre);
            A292EtapaDesarrolloUsuarioRegistro = T000L4_A292EtapaDesarrolloUsuarioRegistro[0];
            AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
            ZM0L22( -6) ;
         }
         pr_default.close(2);
         OnLoadActions0L22( ) ;
      }

      protected void OnLoadActions0L22( )
      {
         AV27Pgmname = "EtapasDesarrollo";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
      }

      protected void CheckExtendedTable0L22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV27Pgmname = "EtapasDesarrollo";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A291EtapaDesarrolloNombre)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Desarrollo Nombre", "", "", "", "", "", "", "", ""), 1, "ETAPADESARROLLONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L22( )
      {
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L22( 6) ;
            RcdFound22 = 1;
            A290EtapaDesarrolloId = T000L3_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = T000L3_n290EtapaDesarrolloId[0];
            AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
            A291EtapaDesarrolloNombre = T000L3_A291EtapaDesarrolloNombre[0];
            AssignAttri(sPrefix, false, "A291EtapaDesarrolloNombre", A291EtapaDesarrolloNombre);
            A292EtapaDesarrolloUsuarioRegistro = T000L3_A292EtapaDesarrolloUsuarioRegistro[0];
            AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
            Z290EtapaDesarrolloId = A290EtapaDesarrolloId;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0L22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0L22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0L22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L22( ) ;
         if ( RcdFound22 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound22 = 0;
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A290EtapaDesarrolloId[0] < A290EtapaDesarrolloId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000L6_A290EtapaDesarrolloId[0] > A290EtapaDesarrolloId ) ) )
            {
               A290EtapaDesarrolloId = T000L6_A290EtapaDesarrolloId[0];
               n290EtapaDesarrolloId = T000L6_n290EtapaDesarrolloId[0];
               AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A290EtapaDesarrolloId[0] > A290EtapaDesarrolloId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A290EtapaDesarrolloId[0] < A290EtapaDesarrolloId ) ) )
            {
               A290EtapaDesarrolloId = T000L7_A290EtapaDesarrolloId[0];
               n290EtapaDesarrolloId = T000L7_n290EtapaDesarrolloId[0];
               AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0L22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A290EtapaDesarrolloId != Z290EtapaDesarrolloId )
               {
                  A290EtapaDesarrolloId = Z290EtapaDesarrolloId;
                  n290EtapaDesarrolloId = false;
                  AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ETAPADESARROLLOID");
                  AnyError = 1;
                  GX_FocusControl = edtEtapaDesarrolloId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0L22( ) ;
                  GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A290EtapaDesarrolloId != Z290EtapaDesarrolloId )
               {
                  /* Insert record */
                  GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0L22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ETAPADESARROLLOID");
                     AnyError = 1;
                     GX_FocusControl = edtEtapaDesarrolloId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0L22( ) ;
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
         if ( A290EtapaDesarrolloId != Z290EtapaDesarrolloId )
         {
            A290EtapaDesarrolloId = Z290EtapaDesarrolloId;
            n290EtapaDesarrolloId = false;
            AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ETAPADESARROLLOID");
            AnyError = 1;
            GX_FocusControl = edtEtapaDesarrolloId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEtapaDesarrolloNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0L22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EtapasDesarrollo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z291EtapaDesarrolloNombre, T000L2_A291EtapaDesarrolloNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z292EtapaDesarrolloUsuarioRegistro, T000L2_A292EtapaDesarrolloUsuarioRegistro[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z291EtapaDesarrolloNombre, T000L2_A291EtapaDesarrolloNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("etapasdesarrollo:[seudo value changed for attri]"+"EtapaDesarrolloNombre");
                  GXUtil.WriteLogRaw("Old: ",Z291EtapaDesarrolloNombre);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A291EtapaDesarrolloNombre[0]);
               }
               if ( StringUtil.StrCmp(Z292EtapaDesarrolloUsuarioRegistro, T000L2_A292EtapaDesarrolloUsuarioRegistro[0]) != 0 )
               {
                  GXUtil.WriteLog("etapasdesarrollo:[seudo value changed for attri]"+"EtapaDesarrolloUsuarioRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z292EtapaDesarrolloUsuarioRegistro);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A292EtapaDesarrolloUsuarioRegistro[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"EtapasDesarrollo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L22( )
      {
         if ( ! IsAuthorized("etapasdesarrollo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L22( 0) ;
            CheckOptimisticConcurrency0L22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L8 */
                     pr_default.execute(6, new Object[] {A291EtapaDesarrolloNombre, A292EtapaDesarrolloUsuarioRegistro});
                     A290EtapaDesarrolloId = T000L8_A290EtapaDesarrolloId[0];
                     n290EtapaDesarrolloId = T000L8_n290EtapaDesarrolloId[0];
                     AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("EtapasDesarrollo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L22( ) ;
            }
            EndLevel0L22( ) ;
         }
         CloseExtendedTableCursors0L22( ) ;
      }

      protected void Update0L22( )
      {
         if ( ! IsAuthorized("etapasdesarrollo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L9 */
                     pr_default.execute(7, new Object[] {A291EtapaDesarrolloNombre, A292EtapaDesarrolloUsuarioRegistro, n290EtapaDesarrolloId, A290EtapaDesarrolloId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("EtapasDesarrollo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"EtapasDesarrollo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L22( ) ;
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
            EndLevel0L22( ) ;
         }
         CloseExtendedTableCursors0L22( ) ;
      }

      protected void DeferredUpdate0L22( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("etapasdesarrollo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L22( ) ;
            AfterConfirm0L22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L10 */
                  pr_default.execute(8, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("EtapasDesarrollo");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0L22( ) ;
         Gx_mode = sMode22;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L22( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV27Pgmname = "EtapasDesarrollo";
            AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000L11 */
            pr_default.execute(9, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Responsable"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0L22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L22( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("etapasdesarrollo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("etapasdesarrollo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L22( )
      {
         /* Scan By routine */
         /* Using cursor T000L12 */
         pr_default.execute(10);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound22 = 1;
            A290EtapaDesarrolloId = T000L12_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = T000L12_n290EtapaDesarrolloId[0];
            AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L22( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound22 = 1;
            A290EtapaDesarrolloId = T000L12_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = T000L12_n290EtapaDesarrolloId[0];
            AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
         }
      }

      protected void ScanEnd0L22( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0L22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L22( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L22( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L22( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L22( )
      {
         edtEtapaDesarrolloId_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloId_Enabled), 5, 0), true);
         edtEtapaDesarrolloNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloNombre_Enabled), 5, 0), true);
         edtEtapaDesarrolloUsuarioRegistro_Enabled = 0;
         AssignProp(sPrefix, false, edtEtapaDesarrolloUsuarioRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEtapaDesarrolloUsuarioRegistro_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188103163", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("etapasdesarrollo.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7EtapaDesarrolloId,4,0))}, new string[] {"Gx_mode","EtapaDesarrolloId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"EtapasDesarrollo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("etapasdesarrollo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z290EtapaDesarrolloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z291EtapaDesarrolloNombre", Z291EtapaDesarrolloNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z292EtapaDesarrolloUsuarioRegistro", Z292EtapaDesarrolloUsuarioRegistro);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7EtapaDesarrolloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7EtapaDesarrolloId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EtapaDesarrolloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0L22( )
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
         return "EtapasDesarrollo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Etapas Desarrollo" ;
      }

      protected void InitializeNonKey0L22( )
      {
         A291EtapaDesarrolloNombre = "";
         AssignAttri(sPrefix, false, "A291EtapaDesarrolloNombre", A291EtapaDesarrolloNombre);
         A292EtapaDesarrolloUsuarioRegistro = AV25WebSession.Get("UsuarioConectado");
         AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
         Z291EtapaDesarrolloNombre = "";
         Z292EtapaDesarrolloUsuarioRegistro = "";
      }

      protected void InitAll0L22( )
      {
         A290EtapaDesarrolloId = 0;
         n290EtapaDesarrolloId = false;
         AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
         InitializeNonKey0L22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A292EtapaDesarrolloUsuarioRegistro = i292EtapaDesarrolloUsuarioRegistro;
         AssignAttri(sPrefix, false, "A292EtapaDesarrolloUsuarioRegistro", A292EtapaDesarrolloUsuarioRegistro);
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7EtapaDesarrolloId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "etapasdesarrollo", GetJustCreated( ));
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
            AV7EtapaDesarrolloId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV7EtapaDesarrolloId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7EtapaDesarrolloId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7EtapaDesarrolloId != wcpOAV7EtapaDesarrolloId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7EtapaDesarrolloId = AV7EtapaDesarrolloId;
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
         sCtrlAV7EtapaDesarrolloId = cgiGet( sPrefix+"AV7EtapaDesarrolloId_CTRL");
         if ( StringUtil.Len( sCtrlAV7EtapaDesarrolloId) > 0 )
         {
            AV7EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7EtapaDesarrolloId), ".", ","));
            AssignAttri(sPrefix, false, "AV7EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(AV7EtapaDesarrolloId), 4, 0));
         }
         else
         {
            AV7EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7EtapaDesarrolloId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7EtapaDesarrolloId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7EtapaDesarrolloId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7EtapaDesarrolloId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7EtapaDesarrolloId_CTRL", StringUtil.RTrim( sCtrlAV7EtapaDesarrolloId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188103181", true, true);
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
         context.AddJavascriptSource("etapasdesarrollo.js", "?2024188103181", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtEtapaDesarrolloId_Internalname = sPrefix+"ETAPADESARROLLOID";
         divK2btoolstable_attributecontaineretapadesarrolloid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERETAPADESARROLLOID";
         edtEtapaDesarrolloNombre_Internalname = sPrefix+"ETAPADESARROLLONOMBRE";
         divK2btoolstable_attributecontaineretapadesarrollonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERETAPADESARROLLONOMBRE";
         edtEtapaDesarrolloUsuarioRegistro_Internalname = sPrefix+"ETAPADESARROLLOUSUARIOREGISTRO";
         divK2btoolstable_attributecontaineretapadesarrollousuarioregistro_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERETAPADESARROLLOUSUARIOREGISTRO";
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
         Form.Caption = "Etapas Desarrollo";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtEtapaDesarrolloUsuarioRegistro_Jsonclick = "";
         edtEtapaDesarrolloUsuarioRegistro_Enabled = 0;
         edtEtapaDesarrolloNombre_Jsonclick = "";
         edtEtapaDesarrolloNombre_Class = "Attribute_Trn Attribute_Required";
         edtEtapaDesarrolloNombre_Enabled = 1;
         edtEtapaDesarrolloId_Jsonclick = "";
         edtEtapaDesarrolloId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7EtapaDesarrolloId',fld:'vETAPADESARROLLOID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120L2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A290EtapaDesarrolloId',fld:'ETAPADESARROLLOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A291EtapaDesarrolloNombre',fld:'ETAPADESARROLLONOMBRE',pic:''},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A290EtapaDesarrolloId',fld:'ETAPADESARROLLOID',pic:'ZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130L2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_ETAPADESARROLLOID","{handler:'Valid_Etapadesarrolloid',iparms:[]");
         setEventMetadata("VALID_ETAPADESARROLLOID",",oparms:[]}");
         setEventMetadata("VALID_ETAPADESARROLLONOMBRE","{handler:'Valid_Etapadesarrollonombre',iparms:[]");
         setEventMetadata("VALID_ETAPADESARROLLONOMBRE",",oparms:[]}");
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
         Z291EtapaDesarrolloNombre = "";
         Z292EtapaDesarrolloUsuarioRegistro = "";
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
         A291EtapaDesarrolloNombre = "";
         TempTags = "";
         A292EtapaDesarrolloUsuarioRegistro = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV27Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode22 = "";
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
         AV25WebSession = context.GetSession();
         T000L4_A290EtapaDesarrolloId = new short[1] ;
         T000L4_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L4_A291EtapaDesarrolloNombre = new string[] {""} ;
         T000L4_A292EtapaDesarrolloUsuarioRegistro = new string[] {""} ;
         T000L5_A290EtapaDesarrolloId = new short[1] ;
         T000L5_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L3_A290EtapaDesarrolloId = new short[1] ;
         T000L3_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L3_A291EtapaDesarrolloNombre = new string[] {""} ;
         T000L3_A292EtapaDesarrolloUsuarioRegistro = new string[] {""} ;
         T000L6_A290EtapaDesarrolloId = new short[1] ;
         T000L6_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L7_A290EtapaDesarrolloId = new short[1] ;
         T000L7_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L2_A290EtapaDesarrolloId = new short[1] ;
         T000L2_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L2_A291EtapaDesarrolloNombre = new string[] {""} ;
         T000L2_A292EtapaDesarrolloUsuarioRegistro = new string[] {""} ;
         T000L8_A290EtapaDesarrolloId = new short[1] ;
         T000L8_n290EtapaDesarrolloId = new bool[] {false} ;
         T000L11_A14TicketId = new long[1] ;
         T000L11_A16TicketResponsableId = new long[1] ;
         T000L12_A290EtapaDesarrolloId = new short[1] ;
         T000L12_n290EtapaDesarrolloId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i292EtapaDesarrolloUsuarioRegistro = "";
         sCtrlGx_mode = "";
         sCtrlAV7EtapaDesarrolloId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.etapasdesarrollo__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.etapasdesarrollo__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.etapasdesarrollo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.etapasdesarrollo__default(),
            new Object[][] {
                new Object[] {
               T000L2_A290EtapaDesarrolloId, T000L2_A291EtapaDesarrolloNombre, T000L2_A292EtapaDesarrolloUsuarioRegistro
               }
               , new Object[] {
               T000L3_A290EtapaDesarrolloId, T000L3_A291EtapaDesarrolloNombre, T000L3_A292EtapaDesarrolloUsuarioRegistro
               }
               , new Object[] {
               T000L4_A290EtapaDesarrolloId, T000L4_A291EtapaDesarrolloNombre, T000L4_A292EtapaDesarrolloUsuarioRegistro
               }
               , new Object[] {
               T000L5_A290EtapaDesarrolloId
               }
               , new Object[] {
               T000L6_A290EtapaDesarrolloId
               }
               , new Object[] {
               T000L7_A290EtapaDesarrolloId
               }
               , new Object[] {
               T000L8_A290EtapaDesarrolloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L11_A14TicketId, T000L11_A16TicketResponsableId
               }
               , new Object[] {
               T000L12_A290EtapaDesarrolloId
               }
            }
         );
         AV27Pgmname = "EtapasDesarrollo";
         Z292EtapaDesarrolloUsuarioRegistro = AV25WebSession.Get("UsuarioConectado");
         A292EtapaDesarrolloUsuarioRegistro = AV25WebSession.Get("UsuarioConectado");
         i292EtapaDesarrolloUsuarioRegistro = AV25WebSession.Get("UsuarioConectado");
      }

      private short wcpOAV7EtapaDesarrolloId ;
      private short Z290EtapaDesarrolloId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7EtapaDesarrolloId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A290EtapaDesarrolloId ;
      private short nDraw ;
      private short nDoneStart ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short GX_JID ;
      private short nIsDirty_22 ;
      private int trnEnded ;
      private int edtEtapaDesarrolloId_Enabled ;
      private int edtEtapaDesarrolloNombre_Enabled ;
      private int edtEtapaDesarrolloUsuarioRegistro_Enabled ;
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
      private string edtEtapaDesarrolloNombre_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontaineretapadesarrolloid_Internalname ;
      private string edtEtapaDesarrolloId_Internalname ;
      private string edtEtapaDesarrolloId_Jsonclick ;
      private string divK2btoolstable_attributecontaineretapadesarrollonombre_Internalname ;
      private string TempTags ;
      private string edtEtapaDesarrolloNombre_Jsonclick ;
      private string edtEtapaDesarrolloNombre_Class ;
      private string divK2btoolstable_attributecontaineretapadesarrollousuarioregistro_Internalname ;
      private string edtEtapaDesarrolloUsuarioRegistro_Internalname ;
      private string edtEtapaDesarrolloUsuarioRegistro_Jsonclick ;
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
      private string sMode22 ;
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
      private string sCtrlAV7EtapaDesarrolloId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool n290EtapaDesarrolloId ;
      private bool returnInSub ;
      private bool AV18IsAuthorized ;
      private string Z291EtapaDesarrolloNombre ;
      private string Z292EtapaDesarrolloUsuarioRegistro ;
      private string A291EtapaDesarrolloNombre ;
      private string A292EtapaDesarrolloUsuarioRegistro ;
      private string AV17UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV15Url ;
      private string i292EtapaDesarrolloUsuarioRegistro ;
      private IGxSession AV25WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private short[] T000L4_A290EtapaDesarrolloId ;
      private bool[] T000L4_n290EtapaDesarrolloId ;
      private string[] T000L4_A291EtapaDesarrolloNombre ;
      private string[] T000L4_A292EtapaDesarrolloUsuarioRegistro ;
      private short[] T000L5_A290EtapaDesarrolloId ;
      private bool[] T000L5_n290EtapaDesarrolloId ;
      private short[] T000L3_A290EtapaDesarrolloId ;
      private bool[] T000L3_n290EtapaDesarrolloId ;
      private string[] T000L3_A291EtapaDesarrolloNombre ;
      private string[] T000L3_A292EtapaDesarrolloUsuarioRegistro ;
      private short[] T000L6_A290EtapaDesarrolloId ;
      private bool[] T000L6_n290EtapaDesarrolloId ;
      private short[] T000L7_A290EtapaDesarrolloId ;
      private bool[] T000L7_n290EtapaDesarrolloId ;
      private short[] T000L2_A290EtapaDesarrolloId ;
      private bool[] T000L2_n290EtapaDesarrolloId ;
      private string[] T000L2_A291EtapaDesarrolloNombre ;
      private string[] T000L2_A292EtapaDesarrolloUsuarioRegistro ;
      private short[] T000L8_A290EtapaDesarrolloId ;
      private bool[] T000L8_n290EtapaDesarrolloId ;
      private long[] T000L11_A14TicketId ;
      private long[] T000L11_A16TicketResponsableId ;
      private short[] T000L12_A290EtapaDesarrolloId ;
      private bool[] T000L12_n290EtapaDesarrolloId ;
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

   public class etapasdesarrollo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class etapasdesarrollo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class etapasdesarrollo__gam : DataStoreHelperBase, IDataStoreHelper
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

public class etapasdesarrollo__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000L4;
       prmT000L4 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L5;
       prmT000L5 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L3;
       prmT000L3 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L6;
       prmT000L6 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L7;
       prmT000L7 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L2;
       prmT000L2 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L8;
       prmT000L8 = new Object[] {
       new ParDef("@EtapaDesarrolloNombre",GXType.NVarChar,30,0) ,
       new ParDef("@EtapaDesarrolloUsuarioRegistro",GXType.NVarChar,100,60)
       };
       Object[] prmT000L9;
       prmT000L9 = new Object[] {
       new ParDef("@EtapaDesarrolloNombre",GXType.NVarChar,30,0) ,
       new ParDef("@EtapaDesarrolloUsuarioRegistro",GXType.NVarChar,100,60) ,
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L10;
       prmT000L10 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L11;
       prmT000L11 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT000L12;
       prmT000L12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000L2", "SELECT [EtapaDesarrolloId], [EtapaDesarrolloNombre], [EtapaDesarrolloUsuarioRegistro] FROM [EtapasDesarrollo] WITH (UPDLOCK) WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L3", "SELECT [EtapaDesarrolloId], [EtapaDesarrolloNombre], [EtapaDesarrolloUsuarioRegistro] FROM [EtapasDesarrollo] WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L4", "SELECT TM1.[EtapaDesarrolloId], TM1.[EtapaDesarrolloNombre], TM1.[EtapaDesarrolloUsuarioRegistro] FROM [EtapasDesarrollo] TM1 WHERE TM1.[EtapaDesarrolloId] = @EtapaDesarrolloId ORDER BY TM1.[EtapaDesarrolloId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L5", "SELECT [EtapaDesarrolloId] FROM [EtapasDesarrollo] WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000L6", "SELECT TOP 1 [EtapaDesarrolloId] FROM [EtapasDesarrollo] WHERE ( [EtapaDesarrolloId] > @EtapaDesarrolloId) ORDER BY [EtapaDesarrolloId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000L7", "SELECT TOP 1 [EtapaDesarrolloId] FROM [EtapasDesarrollo] WHERE ( [EtapaDesarrolloId] < @EtapaDesarrolloId) ORDER BY [EtapaDesarrolloId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000L8", "INSERT INTO [EtapasDesarrollo]([EtapaDesarrolloNombre], [EtapaDesarrolloUsuarioRegistro]) VALUES(@EtapaDesarrolloNombre, @EtapaDesarrolloUsuarioRegistro); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000L8)
          ,new CursorDef("T000L9", "UPDATE [EtapasDesarrollo] SET [EtapaDesarrolloNombre]=@EtapaDesarrolloNombre, [EtapaDesarrolloUsuarioRegistro]=@EtapaDesarrolloUsuarioRegistro  WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId", GxErrorMask.GX_NOMASK,prmT000L9)
          ,new CursorDef("T000L10", "DELETE FROM [EtapasDesarrollo]  WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId", GxErrorMask.GX_NOMASK,prmT000L10)
          ,new CursorDef("T000L11", "SELECT TOP 1 [TicketId], [TicketResponsableId] FROM [TicketResponsable] WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000L12", "SELECT [EtapaDesarrolloId] FROM [EtapasDesarrollo] ORDER BY [EtapaDesarrolloId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L12,100, GxCacheFrequency.OFF ,true,false )
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
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
