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
   public class depto : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV8CentrodecostoId = GetPar( "CentrodecostoId");
               AssignAttri(sPrefix, false, "AV8CentrodecostoId", AV8CentrodecostoId);
               AV9DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
               AssignAttri(sPrefix, false, "AV9DepartamentoId", StringUtil.LTrimStr( (decimal)(AV9DepartamentoId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(string)AV8CentrodecostoId,(short)AV9DepartamentoId});
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
                  AV8CentrodecostoId = GetPar( "CentrodecostoId");
                  AssignAttri(sPrefix, false, "AV8CentrodecostoId", AV8CentrodecostoId);
                  AV9DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
                  AssignAttri(sPrefix, false, "AV9DepartamentoId", StringUtil.LTrimStr( (decimal)(AV9DepartamentoId), 4, 0));
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
               Form.Meta.addItem("description", "Depto", 0) ;
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
            GX_FocusControl = edtCentrodecostoId_Internalname;
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

      public depto( )
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

      public depto( IGxContext context )
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
                           string aP1_CentrodecostoId ,
                           short aP2_DepartamentoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV8CentrodecostoId = aP1_CentrodecostoId;
         this.AV9DepartamentoId = aP2_DepartamentoId;
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
            return "depto_Execute" ;
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
            RenderHtmlCloseForm0I19( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "depto.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainercentrodecostoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtCentrodecostoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCentrodecostoId_Internalname, "Centrodecosto Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCentrodecostoId_Internalname, A259CentrodecostoId, StringUtil.RTrim( context.localUtil.Format( A259CentrodecostoId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,18);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCentrodecostoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtCentrodecostoId_Enabled, 1, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Depto.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDepartamentoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A260DepartamentoId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A260DepartamentoId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDepartamentoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtDepartamentoId_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Depto.htm");
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
         GxWebStd.gx_label_element( context, edtDepartamentoNombre_Internalname, "Departamento Nombre", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         ClassString = edtDepartamentoNombre_Class;
         StyleString = "";
         ClassString = edtDepartamentoNombre_Class;
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDepartamentoNombre_Internalname, A261DepartamentoNombre, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", 0, 1, edtDepartamentoNombre_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Depto.htm");
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
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Depto.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Depto.htm");
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
         E110I2 ();
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
               Z259CentrodecostoId = cgiGet( sPrefix+"Z259CentrodecostoId");
               Z260DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z260DepartamentoId"), ",", "."));
               Z261DepartamentoNombre = cgiGet( sPrefix+"Z261DepartamentoNombre");
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV8CentrodecostoId = cgiGet( sPrefix+"wcpOAV8CentrodecostoId");
               wcpOAV9DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9DepartamentoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               AV8CentrodecostoId = cgiGet( sPrefix+"vCENTRODECOSTOID");
               AV9DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vDEPARTAMENTOID"), ",", "."));
               AV26Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A259CentrodecostoId = cgiGet( edtCentrodecostoId_Internalname);
               AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
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
                  A260DepartamentoId = (short)(context.localUtil.CToN( cgiGet( edtDepartamentoId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               }
               A261DepartamentoNombre = cgiGet( edtDepartamentoNombre_Internalname);
               AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Depto");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A259CentrodecostoId, Z259CentrodecostoId) != 0 ) || ( A260DepartamentoId != Z260DepartamentoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("depto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A259CentrodecostoId = GetPar( "CentrodecostoId");
                  AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                  A260DepartamentoId = (short)(NumberUtil.Val( GetPar( "DepartamentoId"), "."));
                  AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
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
                     sMode19 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode19;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound19 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CENTRODECOSTOID");
                        AnyError = 1;
                        GX_FocusControl = edtCentrodecostoId_Internalname;
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
                                 E110I2 ();
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
                                 E120I2 ();
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
                                 E130I2 ();
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
            E120I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I19( ) ;
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
            DisableAttributes0I19( ) ;
         }
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I19( ) ;
            }
            else
            {
               CheckExtendedTable0I19( ) ;
               CloseExtendedTableCursors0I19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0I0( )
      {
      }

      protected void E110I2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "Depto",  "Depto",  AV18StandardActivityType,  AV19UserActivityType,  AV26Pgmname, out  AV20IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV20IsAuthorized", AV20IsAuthorized);
         if ( ! AV20IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("Depto")),UrlEncode(StringUtil.RTrim("Depto")),UrlEncode(StringUtil.RTrim(AV18StandardActivityType)),UrlEncode(StringUtil.RTrim(AV19UserActivityType)),UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "Depto", out  AV10TrnContext) ;
         if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Depto", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Depto", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Depto", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(AV7HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtDepartamentoNombre_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Class", edtDepartamentoNombre_Class, true);
            }
            else
            {
               edtDepartamentoNombre_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Class", edtDepartamentoNombre_Class, true);
            }
         }
      }

      protected void E120I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV10TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV23AttributeValueItem.gxTpr_Attributename = "CentrodecostoId";
            AV23AttributeValueItem.gxTpr_Attributevalue = A259CentrodecostoId;
            AV22AttributeValue.Add(AV23AttributeValueItem, 0);
            AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV23AttributeValueItem.gxTpr_Attributename = "DepartamentoId";
            AV23AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A260DepartamentoId), 4, 0);
            AV22AttributeValue.Add(AV23AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "Depto",  AV22AttributeValue) ;
         }
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La depto %1 fue creada", A261DepartamentoNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La depto %1 fue actualizada", A261DepartamentoNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La depto %1 fue eliminada", A261DepartamentoNombre, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV24Message) ;
         if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"Depto",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV22AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV10TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV10TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "Depto") ;
            }
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV12Navigation = AV10TrnContext.gxTpr_Afterinsert;
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
               AV12Navigation = AV10TrnContext.gxTpr_Afterupdate;
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
               AV12Navigation = AV10TrnContext.gxTpr_Afterdelete;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV12Navigation", AV12Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10TrnContext", AV10TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV21encrypt = AV10TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21encrypt)) )
         {
            GXt_char1 = AV21encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV21encrypt = GXt_char1;
         }
         if ( AV12Navigation.gxTpr_Aftertrn == 2 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               GX_msglist.addItem("K2BEntityServices: TransactionNavigation Invalid invocation method. Delete method cannot return using entity manager");
            }
            else
            {
               AV13DinamicObjToLink = StringUtil.Lower( AV10TrnContext.gxTpr_Entitymanagername);
               new k2bgetdynamicobjecttolink(context ).execute( ref  AV13DinamicObjToLink) ;
               if ( StringUtil.StrCmp(AV21encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10TrnContext.gxTpr_Entitymanagernexttaskmode,(string)A259CentrodecostoId,(short)A260DepartamentoId,AV10TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 5 ) )
                     {
                        AV10TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A259CentrodecostoId = (string)(args[2]) ;
                        A260DepartamentoId = (short)(args[3]) ;
                        AV10TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[4]) ;
                     }
                     AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                     AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV21encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10TrnContext.gxTpr_Entitymanagernexttaskmode,(string)A259CentrodecostoId,(short)A260DepartamentoId,AV10TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 5 ) )
                        {
                           AV10TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A259CentrodecostoId = (string)(args[2]) ;
                           A260DepartamentoId = (short)(args[3]) ;
                           AV10TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[4]) ;
                        }
                        AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                        AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10TrnContext.gxTpr_Entitymanagernexttaskmode,(string)A259CentrodecostoId,(short)A260DepartamentoId,AV10TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A259CentrodecostoId = (string)(args[1]) ;
                           A260DepartamentoId = (short)(args[2]) ;
                           AV10TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                        AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(AV10TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
         }
         else
         {
            if ( AV12Navigation.gxTpr_Aftertrn == 3 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV12Navigation.gxTpr_Mode)) )
               {
                  AV12Navigation.gxTpr_Mode = Gx_mode;
               }
               AV13DinamicObjToLink = StringUtil.Lower( AV12Navigation.gxTpr_Objecttolink);
               new k2bgetdynamicobjecttolink(context ).execute( ref  AV13DinamicObjToLink) ;
               if ( StringUtil.StrCmp(AV21encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV12Navigation.gxTpr_Mode,(string)A259CentrodecostoId,(short)A260DepartamentoId,AV12Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 5 ) )
                     {
                        AV12Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A259CentrodecostoId = (string)(args[2]) ;
                        A260DepartamentoId = (short)(args[3]) ;
                        AV12Navigation.gxTpr_Extraparameter = (string)(args[4]) ;
                     }
                     AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                     AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV21encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV12Navigation.gxTpr_Mode,(string)A259CentrodecostoId,(short)A260DepartamentoId,AV12Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 5 ) )
                        {
                           AV12Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A259CentrodecostoId = (string)(args[2]) ;
                           A260DepartamentoId = (short)(args[3]) ;
                           AV12Navigation.gxTpr_Extraparameter = (string)(args[4]) ;
                        }
                        AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                        AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           if ( StringUtil.Len( sPrefix) == 0 )
                           {
                              if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
                              {
                                 gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
                              }
                           }
                           GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.RTrim(A259CentrodecostoId)) + "," + UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV13DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV12Navigation.gxTpr_Mode,(string)A259CentrodecostoId,(short)A260DepartamentoId,AV12Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV13DinamicObjToLink,"GeneXus.Programs",AV13DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV12Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A259CentrodecostoId = (string)(args[1]) ;
                           A260DepartamentoId = (short)(args[2]) ;
                           AV12Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                        AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV13DinamicObjToLink .Trim().Length < 6 || AV13DinamicObjToLink .Substring( AV13DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV13DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Mode)),UrlEncode(StringUtil.RTrim(A259CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(A260DepartamentoId,4,0)),UrlEncode(StringUtil.RTrim(AV12Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                     }
                  }
               }
            }
            else
            {
               if ( AV12Navigation.gxTpr_Aftertrn != 5 )
               {
                  /* Execute user subroutine: 'K2BCLOSE' */
                  S122 ();
                  if (returnInSub) return;
               }
            }
         }
      }

      protected void E130I2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "Depto") ;
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
         if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"Depto"}, true);
         }
         else if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "Stack") == 0 )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else if ( StringUtil.StrCmp(AV10TrnContext.gxTpr_Returnmode, "CallerObject") == 0 )
         {
            AV17Url = AV10TrnContext.gxTpr_Callerurl;
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

      protected void ZM0I19( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z261DepartamentoNombre = T000I3_A261DepartamentoNombre[0];
            }
            else
            {
               Z261DepartamentoNombre = A261DepartamentoNombre;
            }
         }
         if ( GX_JID == -8 )
         {
            Z259CentrodecostoId = A259CentrodecostoId;
            Z260DepartamentoId = A260DepartamentoId;
            Z261DepartamentoNombre = A261DepartamentoNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CentrodecostoId)) )
         {
            A259CentrodecostoId = AV8CentrodecostoId;
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CentrodecostoId)) )
         {
            edtCentrodecostoId_Enabled = 0;
            AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         }
         else
         {
            edtCentrodecostoId_Enabled = 1;
            AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CentrodecostoId)) )
         {
            edtCentrodecostoId_Enabled = 0;
            AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV9DepartamentoId) )
         {
            A260DepartamentoId = AV9DepartamentoId;
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         }
         if ( ! (0==AV9DepartamentoId) )
         {
            edtDepartamentoId_Enabled = 0;
            AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         }
         else
         {
            edtDepartamentoId_Enabled = 1;
            AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV9DepartamentoId) )
         {
            edtDepartamentoId_Enabled = 0;
            AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV26Pgmname = "Depto";
            AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
         }
      }

      protected void Load0I19( )
      {
         /* Using cursor T000I4 */
         pr_datastore2.execute(2, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A261DepartamentoNombre = T000I4_A261DepartamentoNombre[0];
            AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
            ZM0I19( -8) ;
         }
         pr_datastore2.close(2);
         OnLoadActions0I19( ) ;
      }

      protected void OnLoadActions0I19( )
      {
         AV26Pgmname = "Depto";
         AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
      }

      protected void CheckExtendedTable0I19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV26Pgmname = "Depto";
         AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A261DepartamentoNombre)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Departamento Nombre", "", "", "", "", "", "", "", ""), 1, "DEPARTAMENTONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtDepartamentoNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0I19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I19( )
      {
         /* Using cursor T000I5 */
         pr_datastore2.execute(3, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_datastore2.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_datastore2.execute(1, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(1) != 101) )
         {
            ZM0I19( 8) ;
            RcdFound19 = 1;
            A259CentrodecostoId = T000I3_A259CentrodecostoId[0];
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
            A260DepartamentoId = T000I3_A260DepartamentoId[0];
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
            A261DepartamentoNombre = T000I3_A261DepartamentoNombre[0];
            AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
            Z259CentrodecostoId = A259CentrodecostoId;
            Z260DepartamentoId = A260DepartamentoId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0I19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0I19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0I19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_datastore2.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I19( ) ;
         if ( RcdFound19 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I6 */
         pr_datastore2.execute(4, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(4) != 101) )
         {
            while ( (pr_datastore2.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000I6_A259CentrodecostoId[0], A259CentrodecostoId) < 0 ) || ( StringUtil.StrCmp(T000I6_A259CentrodecostoId[0], A259CentrodecostoId) == 0 ) && ( T000I6_A260DepartamentoId[0] < A260DepartamentoId ) ) )
            {
               pr_datastore2.readNext(4);
            }
            if ( (pr_datastore2.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000I6_A259CentrodecostoId[0], A259CentrodecostoId) > 0 ) || ( StringUtil.StrCmp(T000I6_A259CentrodecostoId[0], A259CentrodecostoId) == 0 ) && ( T000I6_A260DepartamentoId[0] > A260DepartamentoId ) ) )
            {
               A259CentrodecostoId = T000I6_A259CentrodecostoId[0];
               AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
               A260DepartamentoId = T000I6_A260DepartamentoId[0];
               AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               RcdFound19 = 1;
            }
         }
         pr_datastore2.close(4);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I7 */
         pr_datastore2.execute(5, new Object[] {A259CentrodecostoId, A260DepartamentoId});
         if ( (pr_datastore2.getStatus(5) != 101) )
         {
            while ( (pr_datastore2.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000I7_A259CentrodecostoId[0], A259CentrodecostoId) > 0 ) || ( StringUtil.StrCmp(T000I7_A259CentrodecostoId[0], A259CentrodecostoId) == 0 ) && ( T000I7_A260DepartamentoId[0] > A260DepartamentoId ) ) )
            {
               pr_datastore2.readNext(5);
            }
            if ( (pr_datastore2.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000I7_A259CentrodecostoId[0], A259CentrodecostoId) < 0 ) || ( StringUtil.StrCmp(T000I7_A259CentrodecostoId[0], A259CentrodecostoId) == 0 ) && ( T000I7_A260DepartamentoId[0] < A260DepartamentoId ) ) )
            {
               A259CentrodecostoId = T000I7_A259CentrodecostoId[0];
               AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
               A260DepartamentoId = T000I7_A260DepartamentoId[0];
               AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
               RcdFound19 = 1;
            }
         }
         pr_datastore2.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCentrodecostoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0I19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( ( StringUtil.StrCmp(A259CentrodecostoId, Z259CentrodecostoId) != 0 ) || ( A260DepartamentoId != Z260DepartamentoId ) )
               {
                  A259CentrodecostoId = Z259CentrodecostoId;
                  AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
                  A260DepartamentoId = Z260DepartamentoId;
                  AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CENTRODECOSTOID");
                  AnyError = 1;
                  GX_FocusControl = edtCentrodecostoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCentrodecostoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0I19( ) ;
                  GX_FocusControl = edtCentrodecostoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A259CentrodecostoId, Z259CentrodecostoId) != 0 ) || ( A260DepartamentoId != Z260DepartamentoId ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtCentrodecostoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0I19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CENTRODECOSTOID");
                     AnyError = 1;
                     GX_FocusControl = edtCentrodecostoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCentrodecostoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0I19( ) ;
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
         if ( ( StringUtil.StrCmp(A259CentrodecostoId, Z259CentrodecostoId) != 0 ) || ( A260DepartamentoId != Z260DepartamentoId ) )
         {
            A259CentrodecostoId = Z259CentrodecostoId;
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
            A260DepartamentoId = Z260DepartamentoId;
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CENTRODECOSTOID");
            AnyError = 1;
            GX_FocusControl = edtCentrodecostoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCentrodecostoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0I19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_datastore2.execute(0, new Object[] {A259CentrodecostoId, A260DepartamentoId});
            if ( (pr_datastore2.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DEPTO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_datastore2.getStatus(0) == 101) || ( StringUtil.StrCmp(Z261DepartamentoNombre, T000I2_A261DepartamentoNombre[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z261DepartamentoNombre, T000I2_A261DepartamentoNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("depto:[seudo value changed for attri]"+"DepartamentoNombre");
                  GXUtil.WriteLogRaw("Old: ",Z261DepartamentoNombre);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A261DepartamentoNombre[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DEPTO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I19( )
      {
         if ( ! IsAuthorized("depto_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I19( 0) ;
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I8 */
                     pr_datastore2.execute(6, new Object[] {A259CentrodecostoId, A260DepartamentoId, A261DepartamentoNombre});
                     pr_datastore2.close(6);
                     dsDataStore2.SmartCacheProvider.SetUpdated("DEPTO");
                     if ( (pr_datastore2.getStatus(6) == 1) )
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
                           ResetCaption0I0( ) ;
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
               Load0I19( ) ;
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void Update0I19( )
      {
         if ( ! IsAuthorized("depto_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I9 */
                     pr_datastore2.execute(7, new Object[] {A261DepartamentoNombre, A259CentrodecostoId, A260DepartamentoId});
                     pr_datastore2.close(7);
                     dsDataStore2.SmartCacheProvider.SetUpdated("DEPTO");
                     if ( (pr_datastore2.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DEPTO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I19( ) ;
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
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void DeferredUpdate0I19( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("depto_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I19( ) ;
            AfterConfirm0I19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I10 */
                  pr_datastore2.execute(8, new Object[] {A259CentrodecostoId, A260DepartamentoId});
                  pr_datastore2.close(8);
                  dsDataStore2.SmartCacheProvider.SetUpdated("DEPTO");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0I19( ) ;
         Gx_mode = sMode19;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV26Pgmname = "Depto";
            AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000I11 */
            pr_default.execute(0, new Object[] {A259CentrodecostoId, A260DepartamentoId});
            if ( (pr_default.getStatus(0) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuario Sistema"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(0);
         }
      }

      protected void EndLevel0I19( )
      {
         if ( ! IsIns( ) )
         {
            pr_datastore2.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_datastore2.close(1);
            context.CommitDataStores("depto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_datastore2.close(1);
            context.RollbackDataStores("depto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I19( )
      {
         /* Scan By routine */
         /* Using cursor T000I12 */
         pr_datastore2.execute(9);
         RcdFound19 = 0;
         if ( (pr_datastore2.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A259CentrodecostoId = T000I12_A259CentrodecostoId[0];
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
            A260DepartamentoId = T000I12_A260DepartamentoId[0];
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I19( )
      {
         /* Scan next routine */
         pr_datastore2.readNext(9);
         RcdFound19 = 0;
         if ( (pr_datastore2.getStatus(9) != 101) )
         {
            RcdFound19 = 1;
            A259CentrodecostoId = T000I12_A259CentrodecostoId[0];
            AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
            A260DepartamentoId = T000I12_A260DepartamentoId[0];
            AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         }
      }

      protected void ScanEnd0I19( )
      {
         pr_datastore2.close(9);
      }

      protected void AfterConfirm0I19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I19( )
      {
         edtCentrodecostoId_Enabled = 0;
         AssignProp(sPrefix, false, edtCentrodecostoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCentrodecostoId_Enabled), 5, 0), true);
         edtDepartamentoId_Enabled = 0;
         AssignProp(sPrefix, false, edtDepartamentoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoId_Enabled), 5, 0), true);
         edtDepartamentoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtDepartamentoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDepartamentoNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20231249492357", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("depto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.RTrim(AV8CentrodecostoId)),UrlEncode(StringUtil.LTrimStr(AV9DepartamentoId,4,0))}, new string[] {"Gx_mode","CentrodecostoId","DepartamentoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Depto");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("depto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z259CentrodecostoId", Z259CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z260DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z260DepartamentoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z261DepartamentoNombre", Z261DepartamentoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV8CentrodecostoId", wcpOAV8CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV9DepartamentoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV9DepartamentoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vTRNCONTEXT", GetSecureSignedToken( sPrefix, AV10TrnContext, context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV12Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV12Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV12Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCENTRODECOSTOID", AV8CentrodecostoId);
         GxWebStd.gx_hidden_field( context, sPrefix+"vDEPARTAMENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9DepartamentoId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0I19( )
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
         return "Depto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Depto" ;
      }

      protected void InitializeNonKey0I19( )
      {
         A261DepartamentoNombre = "";
         AssignAttri(sPrefix, false, "A261DepartamentoNombre", A261DepartamentoNombre);
         Z261DepartamentoNombre = "";
      }

      protected void InitAll0I19( )
      {
         A259CentrodecostoId = "";
         AssignAttri(sPrefix, false, "A259CentrodecostoId", A259CentrodecostoId);
         A260DepartamentoId = 0;
         AssignAttri(sPrefix, false, "A260DepartamentoId", StringUtil.LTrimStr( (decimal)(A260DepartamentoId), 4, 0));
         InitializeNonKey0I19( ) ;
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
         sCtrlAV8CentrodecostoId = (string)((string)getParm(obj,1));
         sCtrlAV9DepartamentoId = (string)((string)getParm(obj,2));
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
         AddComponentObject(sPrefix, "depto", GetJustCreated( ));
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
            AV8CentrodecostoId = (string)getParm(obj,3);
            AssignAttri(sPrefix, false, "AV8CentrodecostoId", AV8CentrodecostoId);
            AV9DepartamentoId = Convert.ToInt16(getParm(obj,4));
            AssignAttri(sPrefix, false, "AV9DepartamentoId", StringUtil.LTrimStr( (decimal)(AV9DepartamentoId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV8CentrodecostoId = cgiGet( sPrefix+"wcpOAV8CentrodecostoId");
         wcpOAV9DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV9DepartamentoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( StringUtil.StrCmp(AV8CentrodecostoId, wcpOAV8CentrodecostoId) != 0 ) || ( AV9DepartamentoId != wcpOAV9DepartamentoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV8CentrodecostoId = AV8CentrodecostoId;
         wcpOAV9DepartamentoId = AV9DepartamentoId;
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
         sCtrlAV8CentrodecostoId = cgiGet( sPrefix+"AV8CentrodecostoId_CTRL");
         if ( StringUtil.Len( sCtrlAV8CentrodecostoId) > 0 )
         {
            AV8CentrodecostoId = cgiGet( sCtrlAV8CentrodecostoId);
            AssignAttri(sPrefix, false, "AV8CentrodecostoId", AV8CentrodecostoId);
         }
         else
         {
            AV8CentrodecostoId = cgiGet( sPrefix+"AV8CentrodecostoId_PARM");
         }
         sCtrlAV9DepartamentoId = cgiGet( sPrefix+"AV9DepartamentoId_CTRL");
         if ( StringUtil.Len( sCtrlAV9DepartamentoId) > 0 )
         {
            AV9DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV9DepartamentoId), ",", "."));
            AssignAttri(sPrefix, false, "AV9DepartamentoId", StringUtil.LTrimStr( (decimal)(AV9DepartamentoId), 4, 0));
         }
         else
         {
            AV9DepartamentoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV9DepartamentoId_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV8CentrodecostoId_PARM", AV8CentrodecostoId);
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV8CentrodecostoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV8CentrodecostoId_CTRL", StringUtil.RTrim( sCtrlAV8CentrodecostoId));
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"AV9DepartamentoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9DepartamentoId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV9DepartamentoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV9DepartamentoId_CTRL", StringUtil.RTrim( sCtrlAV9DepartamentoId));
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249492373", true, true);
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
         context.AddJavascriptSource("depto.js", "?20231249492373", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
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
         Form.Caption = "Depto";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtDepartamentoNombre_Class = "Attribute_Trn Attribute_Required";
         edtDepartamentoNombre_Enabled = 1;
         edtDepartamentoId_Jsonclick = "";
         edtDepartamentoId_Enabled = 1;
         edtCentrodecostoId_Jsonclick = "";
         edtCentrodecostoId_Enabled = 1;
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV8CentrodecostoId',fld:'vCENTRODECOSTOID',pic:''},{av:'AV9DepartamentoId',fld:'vDEPARTAMENTOID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV12Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120I2',iparms:[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A259CentrodecostoId',fld:'CENTRODECOSTOID',pic:''},{av:'A260DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A261DepartamentoNombre',fld:'DEPARTAMENTONOMBRE',pic:''},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV12Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV12Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A260DepartamentoId',fld:'DEPARTAMENTOID',pic:'ZZZ9'},{av:'A259CentrodecostoId',fld:'CENTRODECOSTOID',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130I2',iparms:[{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_CENTRODECOSTOID","{handler:'Valid_Centrodecostoid',iparms:[]");
         setEventMetadata("VALID_CENTRODECOSTOID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTOID","{handler:'Valid_Departamentoid',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTOID",",oparms:[]}");
         setEventMetadata("VALID_DEPARTAMENTONOMBRE","{handler:'Valid_Departamentonombre',iparms:[]");
         setEventMetadata("VALID_DEPARTAMENTONOMBRE",",oparms:[]}");
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
         pr_datastore2.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV8CentrodecostoId = "";
         Z259CentrodecostoId = "";
         Z261DepartamentoNombre = "";
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
         A259CentrodecostoId = "";
         TempTags = "";
         A261DepartamentoNombre = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV26Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode19 = "";
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
         AV10TrnContext = new SdtK2BTrnContext(context);
         AV7HttpRequest = new GxHttpRequest( context);
         AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12Navigation = new SdtK2BTrnNavigation(context);
         AV21encrypt = "";
         GXt_char1 = "";
         AV13DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV17Url = "";
         T000I4_A259CentrodecostoId = new string[] {""} ;
         T000I4_A260DepartamentoId = new short[1] ;
         T000I4_A261DepartamentoNombre = new string[] {""} ;
         T000I5_A259CentrodecostoId = new string[] {""} ;
         T000I5_A260DepartamentoId = new short[1] ;
         T000I3_A259CentrodecostoId = new string[] {""} ;
         T000I3_A260DepartamentoId = new short[1] ;
         T000I3_A261DepartamentoNombre = new string[] {""} ;
         T000I6_A259CentrodecostoId = new string[] {""} ;
         T000I6_A260DepartamentoId = new short[1] ;
         T000I7_A259CentrodecostoId = new string[] {""} ;
         T000I7_A260DepartamentoId = new short[1] ;
         T000I2_A259CentrodecostoId = new string[] {""} ;
         T000I2_A260DepartamentoId = new short[1] ;
         T000I2_A261DepartamentoNombre = new string[] {""} ;
         T000I11_A99UsuarioSistemaId = new string[] {""} ;
         T000I12_A259CentrodecostoId = new string[] {""} ;
         T000I12_A260DepartamentoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV8CentrodecostoId = "";
         sCtrlAV9DepartamentoId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.depto__datastore2(),
            new Object[][] {
                new Object[] {
               T000I2_A259CentrodecostoId, T000I2_A260DepartamentoId, T000I2_A261DepartamentoNombre
               }
               , new Object[] {
               T000I3_A259CentrodecostoId, T000I3_A260DepartamentoId, T000I3_A261DepartamentoNombre
               }
               , new Object[] {
               T000I4_A259CentrodecostoId, T000I4_A260DepartamentoId, T000I4_A261DepartamentoNombre
               }
               , new Object[] {
               T000I5_A259CentrodecostoId, T000I5_A260DepartamentoId
               }
               , new Object[] {
               T000I6_A259CentrodecostoId, T000I6_A260DepartamentoId
               }
               , new Object[] {
               T000I7_A259CentrodecostoId, T000I7_A260DepartamentoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I12_A259CentrodecostoId, T000I12_A260DepartamentoId
               }
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.depto__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.depto__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.depto__default(),
            new Object[][] {
                new Object[] {
               T000I11_A99UsuarioSistemaId
               }
            }
         );
         AV26Pgmname = "Depto";
      }

      private short wcpOAV9DepartamentoId ;
      private short Z260DepartamentoId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV9DepartamentoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A260DepartamentoId ;
      private short nDraw ;
      private short nDoneStart ;
      private short RcdFound19 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_19 ;
      private int trnEnded ;
      private int edtCentrodecostoId_Enabled ;
      private int edtDepartamentoId_Enabled ;
      private int edtDepartamentoNombre_Enabled ;
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
      private string edtCentrodecostoId_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainercentrodecostoid_Internalname ;
      private string TempTags ;
      private string edtCentrodecostoId_Jsonclick ;
      private string divK2btoolstable_attributecontainerdepartamentoid_Internalname ;
      private string edtDepartamentoId_Internalname ;
      private string edtDepartamentoId_Jsonclick ;
      private string divK2btoolstable_attributecontainerdepartamentonombre_Internalname ;
      private string edtDepartamentoNombre_Internalname ;
      private string edtDepartamentoNombre_Class ;
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
      private string AV26Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode19 ;
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
      private string sCtrlAV8CentrodecostoId ;
      private string sCtrlAV9DepartamentoId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV20IsAuthorized ;
      private string wcpOAV8CentrodecostoId ;
      private string Z259CentrodecostoId ;
      private string Z261DepartamentoNombre ;
      private string AV8CentrodecostoId ;
      private string A259CentrodecostoId ;
      private string A261DepartamentoNombre ;
      private string AV19UserActivityType ;
      private string AV13DinamicObjToLink ;
      private string AV17Url ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_datastore2 ;
      private string[] T000I4_A259CentrodecostoId ;
      private short[] T000I4_A260DepartamentoId ;
      private string[] T000I4_A261DepartamentoNombre ;
      private string[] T000I5_A259CentrodecostoId ;
      private short[] T000I5_A260DepartamentoId ;
      private string[] T000I3_A259CentrodecostoId ;
      private short[] T000I3_A260DepartamentoId ;
      private string[] T000I3_A261DepartamentoNombre ;
      private string[] T000I6_A259CentrodecostoId ;
      private short[] T000I6_A260DepartamentoId ;
      private string[] T000I7_A259CentrodecostoId ;
      private short[] T000I7_A260DepartamentoId ;
      private string[] T000I2_A259CentrodecostoId ;
      private short[] T000I2_A260DepartamentoId ;
      private string[] T000I2_A261DepartamentoNombre ;
      private IDataStoreProvider pr_default ;
      private string[] T000I11_A99UsuarioSistemaId ;
      private string[] T000I12_A259CentrodecostoId ;
      private short[] T000I12_A260DepartamentoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV7HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV22AttributeValue ;
      private SdtK2BTrnContext AV10TrnContext ;
      private SdtK2BTrnNavigation AV12Navigation ;
      private SdtK2BContext AV14Context ;
      private SdtK2BAttributeValue_Item AV23AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV24Message ;
   }

   public class depto__datastore2 : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmT000I4;
          prmT000I4 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I5;
          prmT000I5 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I3;
          prmT000I3 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I6;
          prmT000I6 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I7;
          prmT000I7 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I2;
          prmT000I2 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I8;
          prmT000I8 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0) ,
          new ParDef("@DepartamentoNombre",GXType.NVarChar,300,0)
          };
          Object[] prmT000I9;
          prmT000I9 = new Object[] {
          new ParDef("@DepartamentoNombre",GXType.NVarChar,300,0) ,
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I10;
          prmT000I10 = new Object[] {
          new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
          new ParDef("@DepartamentoId",GXType.Int16,4,0)
          };
          Object[] prmT000I12;
          prmT000I12 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("T000I2", "SELECT [CentrodecostoId], [DepartamentoId], [DepartamentoNombre] FROM dbo.[Depto] WITH (UPDLOCK) WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I3", "SELECT [CentrodecostoId], [DepartamentoId], [DepartamentoNombre] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I4", "SELECT TM1.[CentrodecostoId], TM1.[DepartamentoId], TM1.[DepartamentoNombre] FROM dbo.[Depto] TM1 WHERE TM1.[CentrodecostoId] = @CentrodecostoId and TM1.[DepartamentoId] = @DepartamentoId ORDER BY TM1.[CentrodecostoId], TM1.[DepartamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I5", "SELECT [CentrodecostoId], [DepartamentoId] FROM dbo.[Depto] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000I6", "SELECT TOP 1 [CentrodecostoId], [DepartamentoId] FROM dbo.[Depto] WHERE ( [CentrodecostoId] > @CentrodecostoId or [CentrodecostoId] = @CentrodecostoId and [DepartamentoId] > @DepartamentoId) ORDER BY [CentrodecostoId], [DepartamentoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I7", "SELECT TOP 1 [CentrodecostoId], [DepartamentoId] FROM dbo.[Depto] WHERE ( [CentrodecostoId] < @CentrodecostoId or [CentrodecostoId] = @CentrodecostoId and [DepartamentoId] < @DepartamentoId) ORDER BY [CentrodecostoId] DESC, [DepartamentoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000I8", "INSERT INTO dbo.[Depto]([CentrodecostoId], [DepartamentoId], [DepartamentoNombre]) VALUES(@CentrodecostoId, @DepartamentoId, @DepartamentoNombre)", GxErrorMask.GX_NOMASK,prmT000I8)
             ,new CursorDef("T000I9", "UPDATE dbo.[Depto] SET [DepartamentoNombre]=@DepartamentoNombre  WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId", GxErrorMask.GX_NOMASK,prmT000I9)
             ,new CursorDef("T000I10", "DELETE FROM dbo.[Depto]  WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId", GxErrorMask.GX_NOMASK,prmT000I10)
             ,new CursorDef("T000I12", "SELECT [CentrodecostoId], [DepartamentoId] FROM dbo.[Depto] ORDER BY [CentrodecostoId], [DepartamentoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I12,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class depto__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class depto__gam : DataStoreHelperBase, IDataStoreHelper
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

public class depto__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT000I11;
       prmT000I11 = new Object[] {
       new ParDef("@CentrodecostoId",GXType.NVarChar,5,0) ,
       new ParDef("@DepartamentoId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000I11", "SELECT TOP 1 [UsuarioSistemaId] FROM [UsuarioSistema] WHERE [CentrodecostoId] = @CentrodecostoId AND [DepartamentoId] = @DepartamentoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I11,1, GxCacheFrequency.OFF ,true,true )
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
    }
 }

}

}
