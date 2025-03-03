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
   public class areasatencion : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
               AssignAttri(sPrefix, false, "AV7AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV7AreasAtencionId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7AreasAtencionId});
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
                  AV7AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
                  AssignAttri(sPrefix, false, "AV7AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV7AreasAtencionId), 4, 0));
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
               Form.Meta.addItem("description", "�reas de atenci�n", 0) ;
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
            GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
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

      public areasatencion( )
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

      public areasatencion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_AreasAtencionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7AreasAtencionId = aP1_AreasAtencionId;
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
            return "areasatencion_Execute" ;
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
            RenderHtmlCloseForm0O25( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "areasatencion.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerareasatencionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtAreasAtencionId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtAreasAtencionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A366AreasAtencionId), 4, 0, ".", "")), StringUtil.LTrim( ((edtAreasAtencionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A366AreasAtencionId), "ZZZ9") : context.localUtil.Format( (decimal)(A366AreasAtencionId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreasAtencionId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtAreasAtencionId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_AreasAtencion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtAreasAtencionDescripcion_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreasAtencionDescripcion_Internalname, A367AreasAtencionDescripcion, StringUtil.RTrim( context.localUtil.Format( A367AreasAtencionDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreasAtencionDescripcion_Jsonclick, 0, edtAreasAtencionDescripcion_Class, "", "", "", "", 1, edtAreasAtencionDescripcion_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_AreasAtencion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerareasatencionusuariosistema_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtAreasAtencionUsuarioSistema_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreasAtencionUsuarioSistema_Internalname, "Registro: ", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A368AreasAtencionUsuarioSistema", A368AreasAtencionUsuarioSistema);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreasAtencionUsuarioSistema_Internalname, A368AreasAtencionUsuarioSistema, StringUtil.RTrim( context.localUtil.Format( A368AreasAtencionUsuarioSistema, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreasAtencionUsuarioSistema_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtAreasAtencionUsuarioSistema_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_AreasAtencion.htm");
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
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreasAtencion.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_AreasAtencion.htm");
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
         E110O2 ();
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
               Z366AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z366AreasAtencionId"), ".", ","));
               Z367AreasAtencionDescripcion = cgiGet( sPrefix+"Z367AreasAtencionDescripcion");
               Z368AreasAtencionUsuarioSistema = cgiGet( sPrefix+"Z368AreasAtencionUsuarioSistema");
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7AreasAtencionId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV7AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vAREASATENCIONID"), ".", ","));
               AV25Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A366AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( edtAreasAtencionId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               A367AreasAtencionDescripcion = cgiGet( edtAreasAtencionDescripcion_Internalname);
               AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
               A368AreasAtencionUsuarioSistema = cgiGet( edtAreasAtencionUsuarioSistema_Internalname);
               AssignAttri(sPrefix, false, "A368AreasAtencionUsuarioSistema", A368AreasAtencionUsuarioSistema);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"AreasAtencion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A366AreasAtencionId != Z366AreasAtencionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("areasatencion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A366AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
                  AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
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
                     sMode25 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode25;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound25 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "AREASATENCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtAreasAtencionId_Internalname;
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
                                 E110O2 ();
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
                                 E120O2 ();
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
                                 E130O2 ();
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
            E120O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0O25( ) ;
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
            DisableAttributes0O25( ) ;
         }
         AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionDescripcion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtAreasAtencionUsuarioSistema_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionUsuarioSistema_Enabled), 5, 0), true);
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O25( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O25( ) ;
            }
            else
            {
               CheckExtendedTable0O25( ) ;
               CloseExtendedTableCursors0O25( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0O0( )
      {
      }

      protected void E110O2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  AV17StandardActivityType,  AV18UserActivityType,  AV25Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("AreasAtencion")),UrlEncode(StringUtil.RTrim("AreasAtencion")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV25Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "AreasAtencion", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "�reas de atenci�n", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "�reas de atenci�n", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "�reas de atenci�n", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtAreasAtencionDescripcion_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Class", edtAreasAtencionDescripcion_Class, true);
            }
            else
            {
               edtAreasAtencionDescripcion_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Class", edtAreasAtencionDescripcion_Class, true);
            }
         }
      }

      protected void E120O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV21AttributeValueItem.gxTpr_Attributename = "AreasAtencionId";
            AV21AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A366AreasAtencionId), 4, 0);
            AV20AttributeValue.Add(AV21AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "AreasAtencion",  AV20AttributeValue) ;
         }
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La �reas de atenci�n %1 fue creada", A367AreasAtencionDescripcion, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La �reas de atenci�n %1 fue actualizada", A367AreasAtencionDescripcion, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La �reas de atenci�n %1 fue eliminada", A367AreasAtencionDescripcion, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV22Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"AreasAtencion",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV20AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "AreasAtencion") ;
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
         AV16encrypt = AV8TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16encrypt)) )
         {
            GXt_char1 = AV16encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV16encrypt = GXt_char1;
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
               if ( StringUtil.StrCmp(AV16encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A366AreasAtencionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A366AreasAtencionId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV16encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A366AreasAtencionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A366AreasAtencionId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A366AreasAtencionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A366AreasAtencionId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
               if ( StringUtil.StrCmp(AV16encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A366AreasAtencionId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A366AreasAtencionId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV16encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A366AreasAtencionId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A366AreasAtencionId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A366AreasAtencionId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A366AreasAtencionId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130O2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "AreasAtencion") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"AreasAtencion"}, true);
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

      protected void ZM0O25( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z367AreasAtencionDescripcion = T000O3_A367AreasAtencionDescripcion[0];
               Z368AreasAtencionUsuarioSistema = T000O3_A368AreasAtencionUsuarioSistema[0];
            }
            else
            {
               Z367AreasAtencionDescripcion = A367AreasAtencionDescripcion;
               Z368AreasAtencionUsuarioSistema = A368AreasAtencionUsuarioSistema;
            }
         }
         if ( GX_JID == -4 )
         {
            Z366AreasAtencionId = A366AreasAtencionId;
            Z367AreasAtencionDescripcion = A367AreasAtencionDescripcion;
            Z368AreasAtencionUsuarioSistema = A368AreasAtencionUsuarioSistema;
         }
      }

      protected void standaloneNotModal( )
      {
         edtAreasAtencionId_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionId_Enabled), 5, 0), true);
         edtAreasAtencionId_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionId_Enabled), 5, 0), true);
         if ( ! (0==AV7AreasAtencionId) )
         {
            A366AreasAtencionId = AV7AreasAtencionId;
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
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

      protected void Load0O25( )
      {
         /* Using cursor T000O4 */
         pr_default.execute(2, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound25 = 1;
            A367AreasAtencionDescripcion = T000O4_A367AreasAtencionDescripcion[0];
            AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
            A368AreasAtencionUsuarioSistema = T000O4_A368AreasAtencionUsuarioSistema[0];
            AssignAttri(sPrefix, false, "A368AreasAtencionUsuarioSistema", A368AreasAtencionUsuarioSistema);
            ZM0O25( -4) ;
         }
         pr_default.close(2);
         OnLoadActions0O25( ) ;
      }

      protected void OnLoadActions0O25( )
      {
         AV25Pgmname = "AreasAtencion";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
      }

      protected void CheckExtendedTable0O25( )
      {
         nIsDirty_25 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV25Pgmname = "AreasAtencion";
         AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A367AreasAtencionDescripcion)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "", "", "", "", "", "", "", "", ""), 1, "AREASATENCIONDESCRIPCION");
            AnyError = 1;
            GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0O25( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0O25( )
      {
         /* Using cursor T000O5 */
         pr_default.execute(3, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound25 = 1;
         }
         else
         {
            RcdFound25 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000O3 */
         pr_default.execute(1, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O25( 4) ;
            RcdFound25 = 1;
            A366AreasAtencionId = T000O3_A366AreasAtencionId[0];
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
            A367AreasAtencionDescripcion = T000O3_A367AreasAtencionDescripcion[0];
            AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
            A368AreasAtencionUsuarioSistema = T000O3_A368AreasAtencionUsuarioSistema[0];
            AssignAttri(sPrefix, false, "A368AreasAtencionUsuarioSistema", A368AreasAtencionUsuarioSistema);
            Z366AreasAtencionId = A366AreasAtencionId;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0O25( ) ;
            if ( AnyError == 1 )
            {
               RcdFound25 = 0;
               InitializeNonKey0O25( ) ;
            }
            Gx_mode = sMode25;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound25 = 0;
            InitializeNonKey0O25( ) ;
            sMode25 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode25;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O25( ) ;
         if ( RcdFound25 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound25 = 0;
         /* Using cursor T000O6 */
         pr_default.execute(4, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000O6_A366AreasAtencionId[0] < A366AreasAtencionId ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000O6_A366AreasAtencionId[0] > A366AreasAtencionId ) ) )
            {
               A366AreasAtencionId = T000O6_A366AreasAtencionId[0];
               AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound25 = 0;
         /* Using cursor T000O7 */
         pr_default.execute(5, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000O7_A366AreasAtencionId[0] > A366AreasAtencionId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000O7_A366AreasAtencionId[0] < A366AreasAtencionId ) ) )
            {
               A366AreasAtencionId = T000O7_A366AreasAtencionId[0];
               AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               RcdFound25 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0O25( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0O25( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound25 == 1 )
            {
               if ( A366AreasAtencionId != Z366AreasAtencionId )
               {
                  A366AreasAtencionId = Z366AreasAtencionId;
                  AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AREASATENCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAreasAtencionId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0O25( ) ;
                  GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A366AreasAtencionId != Z366AreasAtencionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0O25( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AREASATENCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtAreasAtencionId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0O25( ) ;
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
         if ( A366AreasAtencionId != Z366AreasAtencionId )
         {
            A366AreasAtencionId = Z366AreasAtencionId;
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AREASATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtAreasAtencionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAreasAtencionDescripcion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0O25( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000O2 */
            pr_default.execute(0, new Object[] {A366AreasAtencionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreasAtencion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z367AreasAtencionDescripcion, T000O2_A367AreasAtencionDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z368AreasAtencionUsuarioSistema, T000O2_A368AreasAtencionUsuarioSistema[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z367AreasAtencionDescripcion, T000O2_A367AreasAtencionDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("areasatencion:[seudo value changed for attri]"+"AreasAtencionDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z367AreasAtencionDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A367AreasAtencionDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z368AreasAtencionUsuarioSistema, T000O2_A368AreasAtencionUsuarioSistema[0]) != 0 )
               {
                  GXUtil.WriteLog("areasatencion:[seudo value changed for attri]"+"AreasAtencionUsuarioSistema");
                  GXUtil.WriteLogRaw("Old: ",Z368AreasAtencionUsuarioSistema);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A368AreasAtencionUsuarioSistema[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AreasAtencion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O25( )
      {
         if ( ! IsAuthorized("areasatencion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O25( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O25( 0) ;
            CheckOptimisticConcurrency0O25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O8 */
                     pr_default.execute(6, new Object[] {A367AreasAtencionDescripcion, A368AreasAtencionUsuarioSistema});
                     A366AreasAtencionId = T000O8_A366AreasAtencionId[0];
                     AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("AreasAtencion");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0O0( ) ;
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
               Load0O25( ) ;
            }
            EndLevel0O25( ) ;
         }
         CloseExtendedTableCursors0O25( ) ;
      }

      protected void Update0O25( )
      {
         if ( ! IsAuthorized("areasatencion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O25( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O25( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O25( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O25( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O25( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O9 */
                     pr_default.execute(7, new Object[] {A367AreasAtencionDescripcion, A368AreasAtencionUsuarioSistema, A366AreasAtencionId});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("AreasAtencion");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AreasAtencion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O25( ) ;
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
            EndLevel0O25( ) ;
         }
         CloseExtendedTableCursors0O25( ) ;
      }

      protected void DeferredUpdate0O25( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("areasatencion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O25( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O25( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O25( ) ;
            AfterConfirm0O25( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O25( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000O10 */
                  pr_default.execute(8, new Object[] {A366AreasAtencionId});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("AreasAtencion");
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
         sMode25 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0O25( ) ;
         Gx_mode = sMode25;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0O25( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV25Pgmname = "AreasAtencion";
            AssignAttri(sPrefix, false, "AV25Pgmname", AV25Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000O11 */
            pr_default.execute(9, new Object[] {A366AreasAtencionId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista requerimientos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0O25( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O25( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("areasatencion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("areasatencion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0O25( )
      {
         /* Scan By routine */
         /* Using cursor T000O12 */
         pr_default.execute(10);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound25 = 1;
            A366AreasAtencionId = T000O12_A366AreasAtencionId[0];
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0O25( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound25 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound25 = 1;
            A366AreasAtencionId = T000O12_A366AreasAtencionId[0];
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
         }
      }

      protected void ScanEnd0O25( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0O25( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0O25( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0O25( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0O25( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0O25( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0O25( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O25( )
      {
         edtAreasAtencionId_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionId_Enabled), 5, 0), true);
         edtAreasAtencionDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionDescripcion_Enabled), 5, 0), true);
         edtAreasAtencionUsuarioSistema_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionUsuarioSistema_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionUsuarioSistema_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0O25( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0O0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188102492", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("areasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7AreasAtencionId,4,0))}, new string[] {"Gx_mode","AreasAtencionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"AreasAtencion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("areasatencion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z366AreasAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z366AreasAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z367AreasAtencionDescripcion", Z367AreasAtencionDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z368AreasAtencionUsuarioSistema", Z368AreasAtencionUsuarioSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7AreasAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7AreasAtencionId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vAREASATENCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AreasAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0O25( )
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
         return "AreasAtencion" ;
      }

      public override string GetPgmdesc( )
      {
         return "�reas de atenci�n" ;
      }

      protected void InitializeNonKey0O25( )
      {
         A367AreasAtencionDescripcion = "";
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         A368AreasAtencionUsuarioSistema = "";
         AssignAttri(sPrefix, false, "A368AreasAtencionUsuarioSistema", A368AreasAtencionUsuarioSistema);
         Z367AreasAtencionDescripcion = "";
         Z368AreasAtencionUsuarioSistema = "";
      }

      protected void InitAll0O25( )
      {
         A366AreasAtencionId = 0;
         AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
         InitializeNonKey0O25( ) ;
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
         sCtrlAV7AreasAtencionId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "areasatencion", GetJustCreated( ));
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
            AV7AreasAtencionId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV7AreasAtencionId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7AreasAtencionId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7AreasAtencionId != wcpOAV7AreasAtencionId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7AreasAtencionId = AV7AreasAtencionId;
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
         sCtrlAV7AreasAtencionId = cgiGet( sPrefix+"AV7AreasAtencionId_CTRL");
         if ( StringUtil.Len( sCtrlAV7AreasAtencionId) > 0 )
         {
            AV7AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7AreasAtencionId), ".", ","));
            AssignAttri(sPrefix, false, "AV7AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV7AreasAtencionId), 4, 0));
         }
         else
         {
            AV7AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7AreasAtencionId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7AreasAtencionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AreasAtencionId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7AreasAtencionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7AreasAtencionId_CTRL", StringUtil.RTrim( sCtrlAV7AreasAtencionId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202418810257", true, true);
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
         context.AddJavascriptSource("areasatencion.js", "?202418810258", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtAreasAtencionId_Internalname = sPrefix+"AREASATENCIONID";
         divK2btoolstable_attributecontainerareasatencionid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERAREASATENCIONID";
         edtAreasAtencionDescripcion_Internalname = sPrefix+"AREASATENCIONDESCRIPCION";
         divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERAREASATENCIONDESCRIPCION";
         edtAreasAtencionUsuarioSistema_Internalname = sPrefix+"AREASATENCIONUSUARIOSISTEMA";
         divK2btoolstable_attributecontainerareasatencionusuariosistema_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERAREASATENCIONUSUARIOSISTEMA";
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
         Form.Caption = "�reas de atenci�n";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtAreasAtencionUsuarioSistema_Jsonclick = "";
         edtAreasAtencionUsuarioSistema_Enabled = 1;
         edtAreasAtencionDescripcion_Jsonclick = "";
         edtAreasAtencionDescripcion_Class = "Attribute_Trn Attribute_Required";
         edtAreasAtencionDescripcion_Enabled = 1;
         edtAreasAtencionId_Jsonclick = "";
         edtAreasAtencionId_Enabled = 0;
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7AreasAtencionId',fld:'vAREASATENCIONID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120O2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A366AreasAtencionId',fld:'AREASATENCIONID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A367AreasAtencionDescripcion',fld:'AREASATENCIONDESCRIPCION',pic:''},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A366AreasAtencionId',fld:'AREASATENCIONID',pic:'ZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130O2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_AREASATENCIONID","{handler:'Valid_Areasatencionid',iparms:[]");
         setEventMetadata("VALID_AREASATENCIONID",",oparms:[]}");
         setEventMetadata("VALID_AREASATENCIONDESCRIPCION","{handler:'Valid_Areasatenciondescripcion',iparms:[]");
         setEventMetadata("VALID_AREASATENCIONDESCRIPCION",",oparms:[]}");
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
         Z367AreasAtencionDescripcion = "";
         Z368AreasAtencionUsuarioSistema = "";
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
         A367AreasAtencionDescripcion = "";
         TempTags = "";
         A368AreasAtencionUsuarioSistema = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV25Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode25 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV17StandardActivityType = "";
         AV18UserActivityType = "";
         AV12Context = new SdtK2BContext(context);
         AV13BtnCaption = "";
         AV14BtnTooltip = "";
         AV8TrnContext = new SdtK2BTrnContext(context);
         AV24HttpRequest = new GxHttpRequest( context);
         AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV16encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV15Url = "";
         T000O4_A366AreasAtencionId = new short[1] ;
         T000O4_A367AreasAtencionDescripcion = new string[] {""} ;
         T000O4_A368AreasAtencionUsuarioSistema = new string[] {""} ;
         T000O5_A366AreasAtencionId = new short[1] ;
         T000O3_A366AreasAtencionId = new short[1] ;
         T000O3_A367AreasAtencionDescripcion = new string[] {""} ;
         T000O3_A368AreasAtencionUsuarioSistema = new string[] {""} ;
         T000O6_A366AreasAtencionId = new short[1] ;
         T000O7_A366AreasAtencionId = new short[1] ;
         T000O2_A366AreasAtencionId = new short[1] ;
         T000O2_A367AreasAtencionDescripcion = new string[] {""} ;
         T000O2_A368AreasAtencionUsuarioSistema = new string[] {""} ;
         T000O8_A366AreasAtencionId = new short[1] ;
         T000O11_A369ListaRequerimientosId = new short[1] ;
         T000O12_A366AreasAtencionId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV7AreasAtencionId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.areasatencion__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.areasatencion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.areasatencion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.areasatencion__default(),
            new Object[][] {
                new Object[] {
               T000O2_A366AreasAtencionId, T000O2_A367AreasAtencionDescripcion, T000O2_A368AreasAtencionUsuarioSistema
               }
               , new Object[] {
               T000O3_A366AreasAtencionId, T000O3_A367AreasAtencionDescripcion, T000O3_A368AreasAtencionUsuarioSistema
               }
               , new Object[] {
               T000O4_A366AreasAtencionId, T000O4_A367AreasAtencionDescripcion, T000O4_A368AreasAtencionUsuarioSistema
               }
               , new Object[] {
               T000O5_A366AreasAtencionId
               }
               , new Object[] {
               T000O6_A366AreasAtencionId
               }
               , new Object[] {
               T000O7_A366AreasAtencionId
               }
               , new Object[] {
               T000O8_A366AreasAtencionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000O11_A369ListaRequerimientosId
               }
               , new Object[] {
               T000O12_A366AreasAtencionId
               }
            }
         );
         AV25Pgmname = "AreasAtencion";
      }

      private short wcpOAV7AreasAtencionId ;
      private short Z366AreasAtencionId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7AreasAtencionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A366AreasAtencionId ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound25 ;
      private short GX_JID ;
      private short nIsDirty_25 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int edtAreasAtencionId_Enabled ;
      private int edtAreasAtencionDescripcion_Enabled ;
      private int edtAreasAtencionUsuarioSistema_Enabled ;
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
      private string edtAreasAtencionDescripcion_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerareasatencionid_Internalname ;
      private string edtAreasAtencionId_Internalname ;
      private string edtAreasAtencionId_Jsonclick ;
      private string divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname ;
      private string TempTags ;
      private string edtAreasAtencionDescripcion_Jsonclick ;
      private string edtAreasAtencionDescripcion_Class ;
      private string divK2btoolstable_attributecontainerareasatencionusuariosistema_Internalname ;
      private string edtAreasAtencionUsuarioSistema_Internalname ;
      private string edtAreasAtencionUsuarioSistema_Jsonclick ;
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
      private string sMode25 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV17StandardActivityType ;
      private string AV13BtnCaption ;
      private string AV14BtnTooltip ;
      private string AV16encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7AreasAtencionId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
      private string Z367AreasAtencionDescripcion ;
      private string Z368AreasAtencionUsuarioSistema ;
      private string A367AreasAtencionDescripcion ;
      private string A368AreasAtencionUsuarioSistema ;
      private string AV18UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV15Url ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private short[] T000O4_A366AreasAtencionId ;
      private string[] T000O4_A367AreasAtencionDescripcion ;
      private string[] T000O4_A368AreasAtencionUsuarioSistema ;
      private short[] T000O5_A366AreasAtencionId ;
      private short[] T000O3_A366AreasAtencionId ;
      private string[] T000O3_A367AreasAtencionDescripcion ;
      private string[] T000O3_A368AreasAtencionUsuarioSistema ;
      private short[] T000O6_A366AreasAtencionId ;
      private short[] T000O7_A366AreasAtencionId ;
      private short[] T000O2_A366AreasAtencionId ;
      private string[] T000O2_A367AreasAtencionDescripcion ;
      private string[] T000O2_A368AreasAtencionUsuarioSistema ;
      private short[] T000O8_A366AreasAtencionId ;
      private short[] T000O11_A369ListaRequerimientosId ;
      private short[] T000O12_A366AreasAtencionId ;
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

   public class areasatencion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class areasatencion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class areasatencion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class areasatencion__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000O4;
       prmT000O4 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O5;
       prmT000O5 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O3;
       prmT000O3 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O6;
       prmT000O6 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O7;
       prmT000O7 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O2;
       prmT000O2 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O8;
       prmT000O8 = new Object[] {
       new ParDef("@AreasAtencionDescripcion",GXType.NVarChar,30,0) ,
       new ParDef("@AreasAtencionUsuarioSistema",GXType.NVarChar,100,60)
       };
       Object[] prmT000O9;
       prmT000O9 = new Object[] {
       new ParDef("@AreasAtencionDescripcion",GXType.NVarChar,30,0) ,
       new ParDef("@AreasAtencionUsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O10;
       prmT000O10 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O11;
       prmT000O11 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000O12;
       prmT000O12 = new Object[] {
       };
       def= new CursorDef[] {
           new CursorDef("T000O2", "SELECT [AreasAtencionId], [AreasAtencionDescripcion], [AreasAtencionUsuarioSistema] FROM [AreasAtencion] WITH (UPDLOCK) WHERE [AreasAtencionId] = @AreasAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O3", "SELECT [AreasAtencionId], [AreasAtencionDescripcion], [AreasAtencionUsuarioSistema] FROM [AreasAtencion] WHERE [AreasAtencionId] = @AreasAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O4", "SELECT TM1.[AreasAtencionId], TM1.[AreasAtencionDescripcion], TM1.[AreasAtencionUsuarioSistema] FROM [AreasAtencion] TM1 WHERE TM1.[AreasAtencionId] = @AreasAtencionId ORDER BY TM1.[AreasAtencionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000O4,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O5", "SELECT [AreasAtencionId] FROM [AreasAtencion] WHERE [AreasAtencionId] = @AreasAtencionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000O5,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000O6", "SELECT TOP 1 [AreasAtencionId] FROM [AreasAtencion] WHERE ( [AreasAtencionId] > @AreasAtencionId) ORDER BY [AreasAtencionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000O6,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O7", "SELECT TOP 1 [AreasAtencionId] FROM [AreasAtencion] WHERE ( [AreasAtencionId] < @AreasAtencionId) ORDER BY [AreasAtencionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000O7,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O8", "INSERT INTO [AreasAtencion]([AreasAtencionDescripcion], [AreasAtencionUsuarioSistema]) VALUES(@AreasAtencionDescripcion, @AreasAtencionUsuarioSistema); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000O8)
          ,new CursorDef("T000O9", "UPDATE [AreasAtencion] SET [AreasAtencionDescripcion]=@AreasAtencionDescripcion, [AreasAtencionUsuarioSistema]=@AreasAtencionUsuarioSistema  WHERE [AreasAtencionId] = @AreasAtencionId", GxErrorMask.GX_NOMASK,prmT000O9)
          ,new CursorDef("T000O10", "DELETE FROM [AreasAtencion]  WHERE [AreasAtencionId] = @AreasAtencionId", GxErrorMask.GX_NOMASK,prmT000O10)
          ,new CursorDef("T000O11", "SELECT TOP 1 [ListaRequerimientosId] FROM [ListaRequerimientos] WHERE [AreasAtencionId] = @AreasAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O11,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000O12", "SELECT [AreasAtencionId] FROM [AreasAtencion] ORDER BY [AreasAtencionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000O12,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 10 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
