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
   public class responsable : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
               AssignAttri(sPrefix, false, "AV7ResponsableId", StringUtil.LTrimStr( (decimal)(AV7ResponsableId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7ResponsableId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"") == 0 )
            {
               A194EstadoResponsableId = (short)(NumberUtil.Val( GetPar( "EstadoResponsableId"), "."));
               AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA195055( A194EstadoResponsableId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"") == 0 )
            {
               A103id_unidad = (int)(NumberUtil.Val( GetPar( "id_unidad"), "."));
               AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA114055( A103id_unidad) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
            {
               A194EstadoResponsableId = (short)(NumberUtil.Val( GetPar( "EstadoResponsableId"), "."));
               AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_17( A194EstadoResponsableId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
            {
               A103id_unidad = (int)(NumberUtil.Val( GetPar( "id_unidad"), "."));
               AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_16( A103id_unidad) ;
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
                  AV7ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
                  AssignAttri(sPrefix, false, "AV7ResponsableId", StringUtil.LTrimStr( (decimal)(AV7ResponsableId), 4, 0));
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
               Form.Meta.addItem("description", "Responsable", 0) ;
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
            GX_FocusControl = edtResponsableIdentidad_Internalname;
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

      public responsable( )
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

      public responsable( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ResponsableId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ResponsableId = aP1_ResponsableId;
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
         chkResponsableActivo = new GXCheckbox();
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
            return "responsable_Execute" ;
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
         A26ResponsableActivo = StringUtil.StrToBool( StringUtil.BoolToStr( A26ResponsableActivo));
         AssignAttri(sPrefix, false, "A26ResponsableActivo", A26ResponsableActivo);
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
            RenderHtmlCloseForm055( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "responsable.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsableid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableId_Internalname, "Id Técnico:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ".", "")), StringUtil.LTrim( ((edtResponsableId_Enabled!=0) ? context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9") : context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtResponsableId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsableidentidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableIdentidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableIdentidad_Internalname, "Identidad Técnico:", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A29ResponsableIdentidad", A29ResponsableIdentidad);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResponsableIdentidad_Internalname, A29ResponsableIdentidad, StringUtil.RTrim( context.localUtil.Format( A29ResponsableIdentidad, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableIdentidad_Jsonclick, 0, edtResponsableIdentidad_Class, "", "", "", "", 1, edtResponsableIdentidad_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsablenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableNombre_Internalname, "Técnico:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResponsableNombre_Internalname, A30ResponsableNombre, StringUtil.RTrim( context.localUtil.Format( A30ResponsableNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtResponsableNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsableusuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableUsuario_Internalname, "Usuario Sistema", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A96ResponsableUsuario", A96ResponsableUsuario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResponsableUsuario_Internalname, A96ResponsableUsuario, StringUtil.RTrim( context.localUtil.Format( A96ResponsableUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableUsuario_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtResponsableUsuario_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsablecargo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableCargo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableCargo_Internalname, "Cargo:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A27ResponsableCargo", A27ResponsableCargo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtResponsableCargo_Internalname, A27ResponsableCargo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", 0, 1, edtResponsableCargo_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsableemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableEmail_Internalname, "Email:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A28ResponsableEmail", A28ResponsableEmail);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResponsableEmail_Internalname, A28ResponsableEmail, StringUtil.RTrim( context.localUtil.Format( A28ResponsableEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A28ResponsableEmail, "", "", "", edtResponsableEmail_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtResponsableEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsableactivo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkResponsableActivo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkResponsableActivo_Internalname, "Estado:", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A26ResponsableActivo", A26ResponsableActivo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkResponsableActivo_Internalname, StringUtil.BoolToStr( A26ResponsableActivo), "", "Estado:", 1, chkResponsableActivo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(54, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,54);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoresponsableid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoResponsableId_Internalname, "Responsable Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A194EstadoResponsableId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A194EstadoResponsableId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,60);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoResponsableId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoResponsableId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Responsable.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_194_Internalname, sImgUrl, imgprompt_194_Link, "", "", context.GetTheme( ), imgprompt_194_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoresponsablenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoResponsableNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoResponsableNombre_Internalname, "Responsable Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
         GxWebStd.gx_single_line_edit( context, edtEstadoResponsableNombre_Internalname, A195EstadoResponsableNombre, StringUtil.RTrim( context.localUtil.Format( A195EstadoResponsableNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEstadoResponsableNombre_Link, "", "", "", edtEstadoResponsableNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoResponsableNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Responsable.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerid_unidad_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtid_unidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtid_unidad_Internalname, "id_unidad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtid_unidad_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A103id_unidad), "ZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,72);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtid_unidad_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtid_unidad_Enabled, 1, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Responsable.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_103_Internalname, sImgUrl, imgprompt_103_Link, "", "", context.GetTheme( ), imgprompt_103_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Responsable.htm");
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
         GxWebStd.gx_label_element( context, edtnombre_unidad_Internalname, "nombre_unidad", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtnombre_unidad_Internalname, A114nombre_unidad, edtnombre_unidad_Link, "", 0, 1, edtnombre_unidad_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Responsable.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Responsable.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Responsable.htm");
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
         E11052 ();
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
               Z6ResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z6ResponsableId"), ".", ","));
               Z29ResponsableIdentidad = cgiGet( sPrefix+"Z29ResponsableIdentidad");
               Z30ResponsableNombre = cgiGet( sPrefix+"Z30ResponsableNombre");
               Z96ResponsableUsuario = cgiGet( sPrefix+"Z96ResponsableUsuario");
               Z27ResponsableCargo = cgiGet( sPrefix+"Z27ResponsableCargo");
               Z28ResponsableEmail = cgiGet( sPrefix+"Z28ResponsableEmail");
               Z26ResponsableActivo = StringUtil.StrToBool( cgiGet( sPrefix+"Z26ResponsableActivo"));
               Z103id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z103id_unidad"), ".", ","));
               Z194EstadoResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z194EstadoResponsableId"), ".", ","));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7ResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7ResponsableId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N194EstadoResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N194EstadoResponsableId"), ".", ","));
               N103id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N103id_unidad"), ".", ","));
               AV7ResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vRESPONSABLEID"), ".", ","));
               AV25Insert_EstadoResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_ESTADORESPONSABLEID"), ".", ","));
               AV26Insert_id_unidad = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_ID_UNIDAD"), ".", ","));
               AV27Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A6ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
               A29ResponsableIdentidad = cgiGet( edtResponsableIdentidad_Internalname);
               AssignAttri(sPrefix, false, "A29ResponsableIdentidad", A29ResponsableIdentidad);
               A30ResponsableNombre = cgiGet( edtResponsableNombre_Internalname);
               AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
               A96ResponsableUsuario = cgiGet( edtResponsableUsuario_Internalname);
               AssignAttri(sPrefix, false, "A96ResponsableUsuario", A96ResponsableUsuario);
               A27ResponsableCargo = cgiGet( edtResponsableCargo_Internalname);
               AssignAttri(sPrefix, false, "A27ResponsableCargo", A27ResponsableCargo);
               A28ResponsableEmail = cgiGet( edtResponsableEmail_Internalname);
               AssignAttri(sPrefix, false, "A28ResponsableEmail", A28ResponsableEmail);
               A26ResponsableActivo = StringUtil.StrToBool( cgiGet( chkResponsableActivo_Internalname));
               AssignAttri(sPrefix, false, "A26ResponsableActivo", A26ResponsableActivo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadoResponsableId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadoResponsableId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADORESPONSABLEID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A194EstadoResponsableId = 0;
                  AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
               }
               else
               {
                  A194EstadoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtEstadoResponsableId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
               }
               A195EstadoResponsableNombre = cgiGet( edtEstadoResponsableNombre_Internalname);
               AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ID_UNIDAD");
                  AnyError = 1;
                  GX_FocusControl = edtid_unidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A103id_unidad = 0;
                  AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               }
               else
               {
                  A103id_unidad = (int)(context.localUtil.CToN( cgiGet( edtid_unidad_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
               }
               A114nombre_unidad = cgiGet( edtnombre_unidad_Internalname);
               n114nombre_unidad = false;
               AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Responsable");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A6ResponsableId != Z6ResponsableId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("responsable:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A6ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
                  AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "RESPONSABLEID");
                        AnyError = 1;
                        GX_FocusControl = edtResponsableId_Internalname;
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
                                 E11052 ();
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
                                 E12052 ();
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
                                 E13052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
            DisableAttributes055( ) ;
         }
         AssignProp(sPrefix, false, edtResponsableIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableIdentidad_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResponsableUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableUsuario_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResponsableCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableCargo_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResponsableEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableEmail_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkResponsableActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkResponsableActivo.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoResponsableNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Enabled), 5, 0), true);
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
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
         new k2bisauthorizedactivityname(context ).execute(  "Responsable",  "Responsable",  AV16StandardActivityType,  AV17UserActivityType,  AV27Pgmname, out  AV18IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV18IsAuthorized", AV18IsAuthorized);
         if ( ! AV18IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("Responsable")),UrlEncode(StringUtil.RTrim("Responsable")),UrlEncode(StringUtil.RTrim(AV16StandardActivityType)),UrlEncode(StringUtil.RTrim(AV17UserActivityType)),UrlEncode(StringUtil.RTrim(AV27Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "Responsable", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Responsable", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Responsable", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Responsable", "", "", "", "", "", "", "", "");
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
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "EstadoResponsableId") == 0 )
               {
                  AV25Insert_EstadoResponsableId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV25Insert_EstadoResponsableId", StringUtil.LTrimStr( (decimal)(AV25Insert_EstadoResponsableId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "id_unidad") == 0 )
               {
                  AV26Insert_id_unidad = (int)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV26Insert_id_unidad", StringUtil.LTrimStr( (decimal)(AV26Insert_id_unidad), 9, 0));
               }
               AV28GXV1 = (int)(AV28GXV1+1);
               AssignAttri(sPrefix, false, "AV28GXV1", StringUtil.LTrimStr( (decimal)(AV28GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtResponsableIdentidad_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtResponsableIdentidad_Internalname, "Class", edtResponsableIdentidad_Class, true);
            }
            else
            {
               edtResponsableIdentidad_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtResponsableIdentidad_Internalname, "Class", edtResponsableIdentidad_Class, true);
            }
         }
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV20AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV21AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV21AttributeValueItem.gxTpr_Attributename = "ResponsableId";
            AV21AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A6ResponsableId), 4, 0);
            AV20AttributeValue.Add(AV21AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "Responsable",  AV20AttributeValue) ;
         }
         AV22Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La responsable %1 fue creada", A29ResponsableIdentidad, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La responsable %1 fue actualizada", A29ResponsableIdentidad, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV22Message.gxTpr_Description = StringUtil.Format( "La responsable %1 fue eliminada", A29ResponsableIdentidad, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV22Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"Responsable",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV20AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "Responsable") ;
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
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A6ResponsableId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A6ResponsableId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A6ResponsableId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A6ResponsableId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A6ResponsableId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A6ResponsableId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A6ResponsableId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A6ResponsableId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV19encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A6ResponsableId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A6ResponsableId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A6ResponsableId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A6ResponsableId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A6ResponsableId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E13052( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "Responsable") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"Responsable"}, true);
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

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z29ResponsableIdentidad = T00053_A29ResponsableIdentidad[0];
               Z30ResponsableNombre = T00053_A30ResponsableNombre[0];
               Z96ResponsableUsuario = T00053_A96ResponsableUsuario[0];
               Z27ResponsableCargo = T00053_A27ResponsableCargo[0];
               Z28ResponsableEmail = T00053_A28ResponsableEmail[0];
               Z26ResponsableActivo = T00053_A26ResponsableActivo[0];
               Z103id_unidad = T00053_A103id_unidad[0];
               Z194EstadoResponsableId = T00053_A194EstadoResponsableId[0];
            }
            else
            {
               Z29ResponsableIdentidad = A29ResponsableIdentidad;
               Z30ResponsableNombre = A30ResponsableNombre;
               Z96ResponsableUsuario = A96ResponsableUsuario;
               Z27ResponsableCargo = A27ResponsableCargo;
               Z28ResponsableEmail = A28ResponsableEmail;
               Z26ResponsableActivo = A26ResponsableActivo;
               Z103id_unidad = A103id_unidad;
               Z194EstadoResponsableId = A194EstadoResponsableId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z6ResponsableId = A6ResponsableId;
            Z29ResponsableIdentidad = A29ResponsableIdentidad;
            Z30ResponsableNombre = A30ResponsableNombre;
            Z96ResponsableUsuario = A96ResponsableUsuario;
            Z27ResponsableCargo = A27ResponsableCargo;
            Z28ResponsableEmail = A28ResponsableEmail;
            Z26ResponsableActivo = A26ResponsableActivo;
            Z103id_unidad = A103id_unidad;
            Z194EstadoResponsableId = A194EstadoResponsableId;
            Z195EstadoResponsableNombre = A195EstadoResponsableNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableId_Enabled), 5, 0), true);
         imgprompt_194_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadotecnicos.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"ESTADORESPONSABLEID"+"'), id:'"+sPrefix+"ESTADORESPONSABLEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_103_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptunidades_gis.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"ID_UNIDAD"+"'), id:'"+sPrefix+"ID_UNIDAD"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableId_Enabled), 5, 0), true);
         if ( ! (0==AV7ResponsableId) )
         {
            A6ResponsableId = AV7ResponsableId;
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_EstadoResponsableId) )
         {
            edtEstadoResponsableId_Enabled = 0;
            AssignProp(sPrefix, false, edtEstadoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoResponsableId_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadoResponsableId_Enabled = 1;
            AssignProp(sPrefix, false, edtEstadoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoResponsableId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_id_unidad) )
         {
            edtid_unidad_Enabled = 0;
            AssignProp(sPrefix, false, edtid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_Enabled), 5, 0), true);
         }
         else
         {
            edtid_unidad_Enabled = 1;
            AssignProp(sPrefix, false, edtid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_id_unidad) )
         {
            A103id_unidad = AV26Insert_id_unidad;
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV25Insert_EstadoResponsableId) )
         {
            A194EstadoResponsableId = AV25Insert_EstadoResponsableId;
            AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
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
            AV27Pgmname = "Responsable";
            AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
            /* Using cursor T00054 */
            pr_datastore1.execute(0, new Object[] {A103id_unidad});
            A114nombre_unidad = T00054_A114nombre_unidad[0];
            n114nombre_unidad = T00054_n114nombre_unidad[0];
            AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
            pr_datastore1.close(0);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  "Display",  "",  "EntityManagerunidades_gis", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
               AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Link", edtnombre_unidad_Link, true);
            }
            /* Using cursor T00055 */
            pr_default.execute(2, new Object[] {A194EstadoResponsableId});
            A195EstadoResponsableNombre = T00055_A195EstadoResponsableNombre[0];
            AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
            pr_default.close(2);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoTecnicos",  "EstadoTecnicos",  "Display",  "",  "EntityManagerEstadoTecnicos", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtEstadoResponsableNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A194EstadoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
               AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Link", edtEstadoResponsableNombre_Link, true);
            }
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00056 */
         pr_default.execute(3, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound5 = 1;
            A29ResponsableIdentidad = T00056_A29ResponsableIdentidad[0];
            AssignAttri(sPrefix, false, "A29ResponsableIdentidad", A29ResponsableIdentidad);
            A30ResponsableNombre = T00056_A30ResponsableNombre[0];
            AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
            A96ResponsableUsuario = T00056_A96ResponsableUsuario[0];
            AssignAttri(sPrefix, false, "A96ResponsableUsuario", A96ResponsableUsuario);
            A27ResponsableCargo = T00056_A27ResponsableCargo[0];
            AssignAttri(sPrefix, false, "A27ResponsableCargo", A27ResponsableCargo);
            A28ResponsableEmail = T00056_A28ResponsableEmail[0];
            AssignAttri(sPrefix, false, "A28ResponsableEmail", A28ResponsableEmail);
            A26ResponsableActivo = T00056_A26ResponsableActivo[0];
            AssignAttri(sPrefix, false, "A26ResponsableActivo", A26ResponsableActivo);
            A195EstadoResponsableNombre = T00056_A195EstadoResponsableNombre[0];
            AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
            A103id_unidad = T00056_A103id_unidad[0];
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
            A194EstadoResponsableId = T00056_A194EstadoResponsableId[0];
            AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
            ZM055( -15) ;
         }
         pr_default.close(3);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV27Pgmname = "Responsable";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTecnicos",  "EstadoTecnicos",  "Display",  "",  "EntityManagerEstadoTecnicos", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode5, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoResponsableNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A194EstadoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
            AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Link", edtEstadoResponsableNombre_Link, true);
         }
         /* Using cursor T00054 */
         pr_datastore1.execute(0, new Object[] {A103id_unidad});
         A114nombre_unidad = T00054_A114nombre_unidad[0];
         n114nombre_unidad = T00054_n114nombre_unidad[0];
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         pr_datastore1.close(0);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  "Display",  "",  "EntityManagerunidades_gis", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode5, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
            AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Link", edtnombre_unidad_Link, true);
         }
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV27Pgmname = "Responsable";
         AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A29ResponsableIdentidad)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Identidad Técnico:", "", "", "", "", "", "", "", ""), 1, "RESPONSABLEIDENTIDAD");
            AnyError = 1;
            GX_FocusControl = edtResponsableIdentidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A28ResponsableEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Email no coincide con el patrón especificado", "OutOfRange", 1, "RESPONSABLEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtResponsableEmail_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00055 */
         pr_default.execute(2, new Object[] {A194EstadoResponsableId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Responsable'.", "ForeignKeyNotFound", 1, "ESTADORESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtEstadoResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A195EstadoResponsableNombre = T00055_A195EstadoResponsableNombre[0];
         AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
         pr_default.close(2);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTecnicos",  "EstadoTecnicos",  "Display",  "",  "EntityManagerEstadoTecnicos", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoResponsableNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A194EstadoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
            AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Link", edtEstadoResponsableNombre_Link, true);
         }
         /* Using cursor T00054 */
         pr_datastore1.execute(0, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(0) == 101) )
         {
            GX_msglist.addItem("No existe 'unidades_gis'.", "ForeignKeyNotFound", 1, "ID_UNIDAD");
            AnyError = 1;
            GX_FocusControl = edtid_unidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A114nombre_unidad = T00054_A114nombre_unidad[0];
         n114nombre_unidad = T00054_n114nombre_unidad[0];
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         pr_datastore1.close(0);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  "Display",  "",  "EntityManagerunidades_gis", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
            AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Link", edtnombre_unidad_Link, true);
         }
      }

      protected void CloseExtendedTableCursors055( )
      {
         pr_default.close(2);
         pr_datastore1.close(0);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_17( short A194EstadoResponsableId )
      {
         /* Using cursor T00057 */
         pr_default.execute(4, new Object[] {A194EstadoResponsableId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Responsable'.", "ForeignKeyNotFound", 1, "ESTADORESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtEstadoResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A195EstadoResponsableNombre = T00057_A195EstadoResponsableNombre[0];
         AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A195EstadoResponsableNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void gxLoad_16( int A103id_unidad )
      {
         /* Using cursor T00058 */
         pr_datastore1.execute(1, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            GX_msglist.addItem("No existe 'unidades_gis'.", "ForeignKeyNotFound", 1, "ID_UNIDAD");
            AnyError = 1;
            GX_FocusControl = edtid_unidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A114nombre_unidad = T00058_A114nombre_unidad[0];
         n114nombre_unidad = T00058_n114nombre_unidad[0];
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A114nombre_unidad)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(1);
      }

      protected void GetKey055( )
      {
         /* Using cursor T00059 */
         pr_default.execute(5, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 15) ;
            RcdFound5 = 1;
            A6ResponsableId = T00053_A6ResponsableId[0];
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
            A29ResponsableIdentidad = T00053_A29ResponsableIdentidad[0];
            AssignAttri(sPrefix, false, "A29ResponsableIdentidad", A29ResponsableIdentidad);
            A30ResponsableNombre = T00053_A30ResponsableNombre[0];
            AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
            A96ResponsableUsuario = T00053_A96ResponsableUsuario[0];
            AssignAttri(sPrefix, false, "A96ResponsableUsuario", A96ResponsableUsuario);
            A27ResponsableCargo = T00053_A27ResponsableCargo[0];
            AssignAttri(sPrefix, false, "A27ResponsableCargo", A27ResponsableCargo);
            A28ResponsableEmail = T00053_A28ResponsableEmail[0];
            AssignAttri(sPrefix, false, "A28ResponsableEmail", A28ResponsableEmail);
            A26ResponsableActivo = T00053_A26ResponsableActivo[0];
            AssignAttri(sPrefix, false, "A26ResponsableActivo", A26ResponsableActivo);
            A103id_unidad = T00053_A103id_unidad[0];
            AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
            A194EstadoResponsableId = T00053_A194EstadoResponsableId[0];
            AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
            Z6ResponsableId = A6ResponsableId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T000510 */
         pr_default.execute(6, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000510_A6ResponsableId[0] < A6ResponsableId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000510_A6ResponsableId[0] > A6ResponsableId ) ) )
            {
               A6ResponsableId = T000510_A6ResponsableId[0];
               AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T000511 */
         pr_default.execute(7, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000511_A6ResponsableId[0] > A6ResponsableId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000511_A6ResponsableId[0] < A6ResponsableId ) ) )
            {
               A6ResponsableId = T000511_A6ResponsableId[0];
               AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtResponsableIdentidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A6ResponsableId != Z6ResponsableId )
               {
                  A6ResponsableId = Z6ResponsableId;
                  AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "RESPONSABLEID");
                  AnyError = 1;
                  GX_FocusControl = edtResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtResponsableIdentidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtResponsableIdentidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A6ResponsableId != Z6ResponsableId )
               {
                  /* Insert record */
                  GX_FocusControl = edtResponsableIdentidad_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "RESPONSABLEID");
                     AnyError = 1;
                     GX_FocusControl = edtResponsableId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtResponsableIdentidad_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A6ResponsableId != Z6ResponsableId )
         {
            A6ResponsableId = Z6ResponsableId;
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "RESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtResponsableIdentidad_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A6ResponsableId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Responsable"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z29ResponsableIdentidad, T00052_A29ResponsableIdentidad[0]) != 0 ) || ( StringUtil.StrCmp(Z30ResponsableNombre, T00052_A30ResponsableNombre[0]) != 0 ) || ( StringUtil.StrCmp(Z96ResponsableUsuario, T00052_A96ResponsableUsuario[0]) != 0 ) || ( StringUtil.StrCmp(Z27ResponsableCargo, T00052_A27ResponsableCargo[0]) != 0 ) || ( StringUtil.StrCmp(Z28ResponsableEmail, T00052_A28ResponsableEmail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z26ResponsableActivo != T00052_A26ResponsableActivo[0] ) || ( Z103id_unidad != T00052_A103id_unidad[0] ) || ( Z194EstadoResponsableId != T00052_A194EstadoResponsableId[0] ) )
            {
               if ( StringUtil.StrCmp(Z29ResponsableIdentidad, T00052_A29ResponsableIdentidad[0]) != 0 )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"ResponsableIdentidad");
                  GXUtil.WriteLogRaw("Old: ",Z29ResponsableIdentidad);
                  GXUtil.WriteLogRaw("Current: ",T00052_A29ResponsableIdentidad[0]);
               }
               if ( StringUtil.StrCmp(Z30ResponsableNombre, T00052_A30ResponsableNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"ResponsableNombre");
                  GXUtil.WriteLogRaw("Old: ",Z30ResponsableNombre);
                  GXUtil.WriteLogRaw("Current: ",T00052_A30ResponsableNombre[0]);
               }
               if ( StringUtil.StrCmp(Z96ResponsableUsuario, T00052_A96ResponsableUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"ResponsableUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z96ResponsableUsuario);
                  GXUtil.WriteLogRaw("Current: ",T00052_A96ResponsableUsuario[0]);
               }
               if ( StringUtil.StrCmp(Z27ResponsableCargo, T00052_A27ResponsableCargo[0]) != 0 )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"ResponsableCargo");
                  GXUtil.WriteLogRaw("Old: ",Z27ResponsableCargo);
                  GXUtil.WriteLogRaw("Current: ",T00052_A27ResponsableCargo[0]);
               }
               if ( StringUtil.StrCmp(Z28ResponsableEmail, T00052_A28ResponsableEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"ResponsableEmail");
                  GXUtil.WriteLogRaw("Old: ",Z28ResponsableEmail);
                  GXUtil.WriteLogRaw("Current: ",T00052_A28ResponsableEmail[0]);
               }
               if ( Z26ResponsableActivo != T00052_A26ResponsableActivo[0] )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"ResponsableActivo");
                  GXUtil.WriteLogRaw("Old: ",Z26ResponsableActivo);
                  GXUtil.WriteLogRaw("Current: ",T00052_A26ResponsableActivo[0]);
               }
               if ( Z103id_unidad != T00052_A103id_unidad[0] )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"id_unidad");
                  GXUtil.WriteLogRaw("Old: ",Z103id_unidad);
                  GXUtil.WriteLogRaw("Current: ",T00052_A103id_unidad[0]);
               }
               if ( Z194EstadoResponsableId != T00052_A194EstadoResponsableId[0] )
               {
                  GXUtil.WriteLog("responsable:[seudo value changed for attri]"+"EstadoResponsableId");
                  GXUtil.WriteLogRaw("Old: ",Z194EstadoResponsableId);
                  GXUtil.WriteLogRaw("Current: ",T00052_A194EstadoResponsableId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Responsable"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         if ( ! IsAuthorized("responsable_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000512 */
                     pr_default.execute(8, new Object[] {A29ResponsableIdentidad, A30ResponsableNombre, A96ResponsableUsuario, A27ResponsableCargo, A28ResponsableEmail, A26ResponsableActivo, A103id_unidad, A194EstadoResponsableId});
                     A6ResponsableId = T000512_A6ResponsableId[0];
                     AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Responsable");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         if ( ! IsAuthorized("responsable_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000513 */
                     pr_default.execute(9, new Object[] {A29ResponsableIdentidad, A30ResponsableNombre, A96ResponsableUsuario, A27ResponsableCargo, A28ResponsableEmail, A26ResponsableActivo, A103id_unidad, A194EstadoResponsableId, A6ResponsableId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Responsable");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Responsable"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("responsable_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000514 */
                  pr_default.execute(10, new Object[] {A6ResponsableId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Responsable");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV27Pgmname = "Responsable";
            AssignAttri(sPrefix, false, "AV27Pgmname", AV27Pgmname);
            /* Using cursor T000515 */
            pr_default.execute(11, new Object[] {A194EstadoResponsableId});
            A195EstadoResponsableNombre = T000515_A195EstadoResponsableNombre[0];
            AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
            pr_default.close(11);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoTecnicos",  "EstadoTecnicos",  "Display",  "",  "EntityManagerEstadoTecnicos", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtEstadoResponsableNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A194EstadoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
               AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Link", edtEstadoResponsableNombre_Link, true);
            }
            /* Using cursor T000516 */
            pr_datastore1.execute(2, new Object[] {A103id_unidad});
            A114nombre_unidad = T000516_A114nombre_unidad[0];
            n114nombre_unidad = T000516_n114nombre_unidad[0];
            AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
            pr_datastore1.close(2);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  "Display",  "",  "EntityManagerunidades_gis", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
               AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Link", edtnombre_unidad_Link, true);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000517 */
            pr_default.execute(12, new Object[] {A6ResponsableId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Responsable"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000518 */
            pr_default.execute(13, new Object[] {A6ResponsableId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ticket Tecnico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_datastore1.close(2);
            pr_default.close(11);
            context.CommitDataStores("responsable",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_datastore1.close(2);
            pr_default.close(11);
            context.RollbackDataStores("responsable",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000519 */
         pr_default.execute(14);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound5 = 1;
            A6ResponsableId = T000519_A6ResponsableId[0];
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound5 = 1;
            A6ResponsableId = T000519_A6ResponsableId[0];
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableId_Enabled), 5, 0), true);
         edtResponsableIdentidad_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableIdentidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableIdentidad_Enabled), 5, 0), true);
         edtResponsableNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Enabled), 5, 0), true);
         edtResponsableUsuario_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableUsuario_Enabled), 5, 0), true);
         edtResponsableCargo_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableCargo_Enabled), 5, 0), true);
         edtResponsableEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableEmail_Enabled), 5, 0), true);
         chkResponsableActivo.Enabled = 0;
         AssignProp(sPrefix, false, chkResponsableActivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkResponsableActivo.Enabled), 5, 0), true);
         edtEstadoResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoResponsableId_Enabled), 5, 0), true);
         edtEstadoResponsableNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoResponsableNombre_Enabled), 5, 0), true);
         edtid_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtid_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtid_unidad_Enabled), 5, 0), true);
         edtnombre_unidad_Enabled = 0;
         AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtnombre_unidad_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188343712", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("responsable.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ResponsableId,4,0))}, new string[] {"Gx_mode","ResponsableId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Responsable");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("responsable:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z6ResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6ResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z29ResponsableIdentidad", Z29ResponsableIdentidad);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z30ResponsableNombre", Z30ResponsableNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z96ResponsableUsuario", Z96ResponsableUsuario);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z27ResponsableCargo", Z27ResponsableCargo);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z28ResponsableEmail", Z28ResponsableEmail);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z26ResponsableActivo", Z26ResponsableActivo);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z103id_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z103id_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z194EstadoResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z194EstadoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7ResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7ResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N194EstadoResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A194EstadoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N103id_unidad", StringUtil.LTrim( StringUtil.NToC( (decimal)(A103id_unidad), 9, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_ESTADORESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25Insert_EstadoResponsableId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_ID_UNIDAD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Insert_id_unidad), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV27Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm055( )
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
         return "Responsable" ;
      }

      public override string GetPgmdesc( )
      {
         return "Responsable" ;
      }

      protected void InitializeNonKey055( )
      {
         A194EstadoResponsableId = 0;
         AssignAttri(sPrefix, false, "A194EstadoResponsableId", StringUtil.LTrimStr( (decimal)(A194EstadoResponsableId), 4, 0));
         A103id_unidad = 0;
         AssignAttri(sPrefix, false, "A103id_unidad", StringUtil.LTrimStr( (decimal)(A103id_unidad), 9, 0));
         A29ResponsableIdentidad = "";
         AssignAttri(sPrefix, false, "A29ResponsableIdentidad", A29ResponsableIdentidad);
         A30ResponsableNombre = "";
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
         A96ResponsableUsuario = "";
         AssignAttri(sPrefix, false, "A96ResponsableUsuario", A96ResponsableUsuario);
         A27ResponsableCargo = "";
         AssignAttri(sPrefix, false, "A27ResponsableCargo", A27ResponsableCargo);
         A28ResponsableEmail = "";
         AssignAttri(sPrefix, false, "A28ResponsableEmail", A28ResponsableEmail);
         A26ResponsableActivo = false;
         AssignAttri(sPrefix, false, "A26ResponsableActivo", A26ResponsableActivo);
         A195EstadoResponsableNombre = "";
         AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
         A114nombre_unidad = "";
         n114nombre_unidad = false;
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         Z29ResponsableIdentidad = "";
         Z30ResponsableNombre = "";
         Z96ResponsableUsuario = "";
         Z27ResponsableCargo = "";
         Z28ResponsableEmail = "";
         Z26ResponsableActivo = false;
         Z103id_unidad = 0;
         Z194EstadoResponsableId = 0;
      }

      protected void InitAll055( )
      {
         A6ResponsableId = 0;
         AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         InitializeNonKey055( ) ;
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
         sCtrlAV7ResponsableId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "responsable", GetJustCreated( ));
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
            AV7ResponsableId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7ResponsableId", StringUtil.LTrimStr( (decimal)(AV7ResponsableId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7ResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7ResponsableId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7ResponsableId != wcpOAV7ResponsableId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7ResponsableId = AV7ResponsableId;
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
         sCtrlAV7ResponsableId = cgiGet( sPrefix+"AV7ResponsableId_CTRL");
         if ( StringUtil.Len( sCtrlAV7ResponsableId) > 0 )
         {
            AV7ResponsableId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7ResponsableId), ".", ","));
            AssignAttri(sPrefix, false, "AV7ResponsableId", StringUtil.LTrimStr( (decimal)(AV7ResponsableId), 4, 0));
         }
         else
         {
            AV7ResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7ResponsableId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7ResponsableId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ResponsableId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7ResponsableId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7ResponsableId_CTRL", StringUtil.RTrim( sCtrlAV7ResponsableId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188343737", true, true);
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
         context.AddJavascriptSource("responsable.js", "?2024188343738", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtResponsableId_Internalname = sPrefix+"RESPONSABLEID";
         divK2btoolstable_attributecontainerresponsableid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLEID";
         edtResponsableIdentidad_Internalname = sPrefix+"RESPONSABLEIDENTIDAD";
         divK2btoolstable_attributecontainerresponsableidentidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLEIDENTIDAD";
         edtResponsableNombre_Internalname = sPrefix+"RESPONSABLENOMBRE";
         divK2btoolstable_attributecontainerresponsablenombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLENOMBRE";
         edtResponsableUsuario_Internalname = sPrefix+"RESPONSABLEUSUARIO";
         divK2btoolstable_attributecontainerresponsableusuario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLEUSUARIO";
         edtResponsableCargo_Internalname = sPrefix+"RESPONSABLECARGO";
         divK2btoolstable_attributecontainerresponsablecargo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLECARGO";
         edtResponsableEmail_Internalname = sPrefix+"RESPONSABLEEMAIL";
         divK2btoolstable_attributecontainerresponsableemail_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLEEMAIL";
         chkResponsableActivo_Internalname = sPrefix+"RESPONSABLEACTIVO";
         divK2btoolstable_attributecontainerresponsableactivo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLEACTIVO";
         edtEstadoResponsableId_Internalname = sPrefix+"ESTADORESPONSABLEID";
         divK2btoolstable_attributecontainerestadoresponsableid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADORESPONSABLEID";
         edtEstadoResponsableNombre_Internalname = sPrefix+"ESTADORESPONSABLENOMBRE";
         divK2btoolstable_attributecontainerestadoresponsablenombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADORESPONSABLENOMBRE";
         edtid_unidad_Internalname = sPrefix+"ID_UNIDAD";
         divK2btoolstable_attributecontainerid_unidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERID_UNIDAD";
         edtnombre_unidad_Internalname = sPrefix+"NOMBRE_UNIDAD";
         divK2btoolstable_attributecontainernombre_unidad_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERNOMBRE_UNIDAD";
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
         imgprompt_194_Internalname = sPrefix+"PROMPT_194";
         imgprompt_103_Internalname = sPrefix+"PROMPT_103";
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
         Form.Caption = "Responsable";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtnombre_unidad_Link = "";
         edtnombre_unidad_Enabled = 0;
         imgprompt_103_Visible = 1;
         imgprompt_103_Link = "";
         edtid_unidad_Jsonclick = "";
         edtid_unidad_Enabled = 1;
         edtEstadoResponsableNombre_Jsonclick = "";
         edtEstadoResponsableNombre_Link = "";
         edtEstadoResponsableNombre_Enabled = 0;
         imgprompt_194_Visible = 1;
         imgprompt_194_Link = "";
         edtEstadoResponsableId_Jsonclick = "";
         edtEstadoResponsableId_Enabled = 1;
         chkResponsableActivo.Enabled = 1;
         edtResponsableEmail_Jsonclick = "";
         edtResponsableEmail_Enabled = 1;
         edtResponsableCargo_Enabled = 1;
         edtResponsableUsuario_Jsonclick = "";
         edtResponsableUsuario_Enabled = 1;
         edtResponsableNombre_Jsonclick = "";
         edtResponsableNombre_Enabled = 1;
         edtResponsableIdentidad_Jsonclick = "";
         edtResponsableIdentidad_Class = "Attribute_Trn Attribute_Required";
         edtResponsableIdentidad_Enabled = 1;
         edtResponsableId_Jsonclick = "";
         edtResponsableId_Enabled = 0;
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

      protected void GXASA195055( short A194EstadoResponsableId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTecnicos",  "EstadoTecnicos",  "Display",  "",  "EntityManagerEstadoTecnicos", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoResponsableNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A194EstadoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
            AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Link", edtEstadoResponsableNombre_Link, true);
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

      protected void GXASA114055( int A103id_unidad )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  "Display",  "",  "EntityManagerunidades_gis", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
            AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Link", edtnombre_unidad_Link, true);
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
         chkResponsableActivo.Name = "RESPONSABLEACTIVO";
         chkResponsableActivo.WebTags = "";
         chkResponsableActivo.Caption = "";
         AssignProp(sPrefix, false, chkResponsableActivo_Internalname, "TitleCaption", chkResponsableActivo.Caption, true);
         chkResponsableActivo.CheckedValue = "false";
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

      public void Valid_Estadoresponsableid( )
      {
         /* Using cursor T000515 */
         pr_default.execute(11, new Object[] {A194EstadoResponsableId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Responsable'.", "ForeignKeyNotFound", 1, "ESTADORESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtEstadoResponsableId_Internalname;
         }
         A195EstadoResponsableNombre = T000515_A195EstadoResponsableNombre[0];
         pr_default.close(11);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTecnicos",  "EstadoTecnicos",  "Display",  "",  "EntityManagerEstadoTecnicos", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoResponsableNombre_Link = formatLink("entitymanagerestadotecnicos.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A194EstadoResponsableId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTecnicosId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A195EstadoResponsableNombre", A195EstadoResponsableNombre);
         AssignProp(sPrefix, false, edtEstadoResponsableNombre_Internalname, "Link", edtEstadoResponsableNombre_Link, true);
      }

      public void Valid_Id_unidad( )
      {
         n114nombre_unidad = false;
         /* Using cursor T000516 */
         pr_datastore1.execute(2, new Object[] {A103id_unidad});
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'unidades_gis'.", "ForeignKeyNotFound", 1, "ID_UNIDAD");
            AnyError = 1;
            GX_FocusControl = edtid_unidad_Internalname;
         }
         A114nombre_unidad = T000516_A114nombre_unidad[0];
         n114nombre_unidad = T000516_n114nombre_unidad[0];
         pr_datastore1.close(2);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "unidades_gis",  "unidades_gis",  "Display",  "",  "EntityManagerunidades_gis", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtnombre_unidad_Link = formatLink("entitymanagerunidades_gis.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A103id_unidad,9,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","id_unidad","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A114nombre_unidad", A114nombre_unidad);
         AssignProp(sPrefix, false, edtnombre_unidad_Internalname, "Link", edtnombre_unidad_Link, true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7ResponsableId',fld:'vRESPONSABLEID',pic:'ZZZ9'},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A6ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A29ResponsableIdentidad',fld:'RESPONSABLEIDENTIDAD',pic:''},{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV20AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A6ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13052',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("'DOCANCEL'",",oparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEID","{handler:'Valid_Responsableid',iparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEID",",oparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEIDENTIDAD","{handler:'Valid_Responsableidentidad',iparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEIDENTIDAD",",oparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEEMAIL","{handler:'Valid_Responsableemail',iparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEEMAIL",",oparms:[{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("VALID_ESTADORESPONSABLEID","{handler:'Valid_Estadoresponsableid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A194EstadoResponsableId',fld:'ESTADORESPONSABLEID',pic:'ZZZ9'},{av:'A195EstadoResponsableNombre',fld:'ESTADORESPONSABLENOMBRE',pic:''},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("VALID_ESTADORESPONSABLEID",",oparms:[{av:'A195EstadoResponsableNombre',fld:'ESTADORESPONSABLENOMBRE',pic:''},{av:'edtEstadoResponsableNombre_Link',ctrl:'ESTADORESPONSABLENOMBRE',prop:'Link'},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
         setEventMetadata("VALID_ID_UNIDAD","{handler:'Valid_Id_unidad',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A103id_unidad',fld:'ID_UNIDAD',pic:'ZZZZZZZZ9'},{av:'A114nombre_unidad',fld:'NOMBRE_UNIDAD',pic:''},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]");
         setEventMetadata("VALID_ID_UNIDAD",",oparms:[{av:'A114nombre_unidad',fld:'NOMBRE_UNIDAD',pic:''},{av:'edtnombre_unidad_Link',ctrl:'NOMBRE_UNIDAD',prop:'Link'},{av:'A26ResponsableActivo',fld:'RESPONSABLEACTIVO',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z29ResponsableIdentidad = "";
         Z30ResponsableNombre = "";
         Z96ResponsableUsuario = "";
         Z27ResponsableCargo = "";
         Z28ResponsableEmail = "";
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
         A29ResponsableIdentidad = "";
         TempTags = "";
         A30ResponsableNombre = "";
         A96ResponsableUsuario = "";
         A27ResponsableCargo = "";
         A28ResponsableEmail = "";
         sImgUrl = "";
         A195EstadoResponsableNombre = "";
         A114nombre_unidad = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV27Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
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
         Z195EstadoResponsableNombre = "";
         T00054_A114nombre_unidad = new string[] {""} ;
         T00054_n114nombre_unidad = new bool[] {false} ;
         T00055_A195EstadoResponsableNombre = new string[] {""} ;
         T00056_A6ResponsableId = new short[1] ;
         T00056_A29ResponsableIdentidad = new string[] {""} ;
         T00056_A30ResponsableNombre = new string[] {""} ;
         T00056_A96ResponsableUsuario = new string[] {""} ;
         T00056_A27ResponsableCargo = new string[] {""} ;
         T00056_A28ResponsableEmail = new string[] {""} ;
         T00056_A26ResponsableActivo = new bool[] {false} ;
         T00056_A195EstadoResponsableNombre = new string[] {""} ;
         T00056_A103id_unidad = new int[1] ;
         T00056_A194EstadoResponsableId = new short[1] ;
         T00057_A195EstadoResponsableNombre = new string[] {""} ;
         T00058_A114nombre_unidad = new string[] {""} ;
         T00058_n114nombre_unidad = new bool[] {false} ;
         T00059_A6ResponsableId = new short[1] ;
         T00053_A6ResponsableId = new short[1] ;
         T00053_A29ResponsableIdentidad = new string[] {""} ;
         T00053_A30ResponsableNombre = new string[] {""} ;
         T00053_A96ResponsableUsuario = new string[] {""} ;
         T00053_A27ResponsableCargo = new string[] {""} ;
         T00053_A28ResponsableEmail = new string[] {""} ;
         T00053_A26ResponsableActivo = new bool[] {false} ;
         T00053_A103id_unidad = new int[1] ;
         T00053_A194EstadoResponsableId = new short[1] ;
         T000510_A6ResponsableId = new short[1] ;
         T000511_A6ResponsableId = new short[1] ;
         T00052_A6ResponsableId = new short[1] ;
         T00052_A29ResponsableIdentidad = new string[] {""} ;
         T00052_A30ResponsableNombre = new string[] {""} ;
         T00052_A96ResponsableUsuario = new string[] {""} ;
         T00052_A27ResponsableCargo = new string[] {""} ;
         T00052_A28ResponsableEmail = new string[] {""} ;
         T00052_A26ResponsableActivo = new bool[] {false} ;
         T00052_A103id_unidad = new int[1] ;
         T00052_A194EstadoResponsableId = new short[1] ;
         T000512_A6ResponsableId = new short[1] ;
         T000515_A195EstadoResponsableNombre = new string[] {""} ;
         T000516_A114nombre_unidad = new string[] {""} ;
         T000516_n114nombre_unidad = new bool[] {false} ;
         T000517_A14TicketId = new long[1] ;
         T000517_A16TicketResponsableId = new long[1] ;
         T000518_A18TicketTecnicoId = new long[1] ;
         T000519_A6ResponsableId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV7ResponsableId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         Z114nombre_unidad = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.responsable__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.responsable__datastore1(),
            new Object[][] {
                new Object[] {
               T00054_A114nombre_unidad, T00054_n114nombre_unidad
               }
               , new Object[] {
               T00058_A114nombre_unidad, T00058_n114nombre_unidad
               }
               , new Object[] {
               T000516_A114nombre_unidad, T000516_n114nombre_unidad
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.responsable__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.responsable__default(),
            new Object[][] {
                new Object[] {
               T00052_A6ResponsableId, T00052_A29ResponsableIdentidad, T00052_A30ResponsableNombre, T00052_A96ResponsableUsuario, T00052_A27ResponsableCargo, T00052_A28ResponsableEmail, T00052_A26ResponsableActivo, T00052_A103id_unidad, T00052_A194EstadoResponsableId
               }
               , new Object[] {
               T00053_A6ResponsableId, T00053_A29ResponsableIdentidad, T00053_A30ResponsableNombre, T00053_A96ResponsableUsuario, T00053_A27ResponsableCargo, T00053_A28ResponsableEmail, T00053_A26ResponsableActivo, T00053_A103id_unidad, T00053_A194EstadoResponsableId
               }
               , new Object[] {
               T00055_A195EstadoResponsableNombre
               }
               , new Object[] {
               T00056_A6ResponsableId, T00056_A29ResponsableIdentidad, T00056_A30ResponsableNombre, T00056_A96ResponsableUsuario, T00056_A27ResponsableCargo, T00056_A28ResponsableEmail, T00056_A26ResponsableActivo, T00056_A195EstadoResponsableNombre, T00056_A103id_unidad, T00056_A194EstadoResponsableId
               }
               , new Object[] {
               T00057_A195EstadoResponsableNombre
               }
               , new Object[] {
               T00059_A6ResponsableId
               }
               , new Object[] {
               T000510_A6ResponsableId
               }
               , new Object[] {
               T000511_A6ResponsableId
               }
               , new Object[] {
               T000512_A6ResponsableId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000515_A195EstadoResponsableNombre
               }
               , new Object[] {
               T000517_A14TicketId, T000517_A16TicketResponsableId
               }
               , new Object[] {
               T000518_A18TicketTecnicoId
               }
               , new Object[] {
               T000519_A6ResponsableId
               }
            }
         );
         AV27Pgmname = "Responsable";
      }

      private short wcpOAV7ResponsableId ;
      private short Z6ResponsableId ;
      private short Z194EstadoResponsableId ;
      private short N194EstadoResponsableId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7ResponsableId ;
      private short A194EstadoResponsableId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A6ResponsableId ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV25Insert_EstadoResponsableId ;
      private short RcdFound5 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_5 ;
      private int Z103id_unidad ;
      private int N103id_unidad ;
      private int A103id_unidad ;
      private int trnEnded ;
      private int edtResponsableId_Enabled ;
      private int edtResponsableIdentidad_Enabled ;
      private int edtResponsableNombre_Enabled ;
      private int edtResponsableUsuario_Enabled ;
      private int edtResponsableCargo_Enabled ;
      private int edtResponsableEmail_Enabled ;
      private int edtEstadoResponsableId_Enabled ;
      private int imgprompt_194_Visible ;
      private int edtEstadoResponsableNombre_Enabled ;
      private int edtid_unidad_Enabled ;
      private int imgprompt_103_Visible ;
      private int edtnombre_unidad_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int AV26Insert_id_unidad ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV28GXV1 ;
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
      private string edtResponsableIdentidad_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerresponsableid_Internalname ;
      private string edtResponsableId_Internalname ;
      private string edtResponsableId_Jsonclick ;
      private string divK2btoolstable_attributecontainerresponsableidentidad_Internalname ;
      private string TempTags ;
      private string edtResponsableIdentidad_Jsonclick ;
      private string edtResponsableIdentidad_Class ;
      private string divK2btoolstable_attributecontainerresponsablenombre_Internalname ;
      private string edtResponsableNombre_Internalname ;
      private string edtResponsableNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerresponsableusuario_Internalname ;
      private string edtResponsableUsuario_Internalname ;
      private string edtResponsableUsuario_Jsonclick ;
      private string divK2btoolstable_attributecontainerresponsablecargo_Internalname ;
      private string edtResponsableCargo_Internalname ;
      private string divK2btoolstable_attributecontainerresponsableemail_Internalname ;
      private string edtResponsableEmail_Internalname ;
      private string edtResponsableEmail_Jsonclick ;
      private string divK2btoolstable_attributecontainerresponsableactivo_Internalname ;
      private string chkResponsableActivo_Internalname ;
      private string divK2btoolstable_attributecontainerestadoresponsableid_Internalname ;
      private string edtEstadoResponsableId_Internalname ;
      private string edtEstadoResponsableId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_194_Internalname ;
      private string imgprompt_194_Link ;
      private string divK2btoolstable_attributecontainerestadoresponsablenombre_Internalname ;
      private string edtEstadoResponsableNombre_Internalname ;
      private string edtEstadoResponsableNombre_Link ;
      private string edtEstadoResponsableNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerid_unidad_Internalname ;
      private string edtid_unidad_Internalname ;
      private string edtid_unidad_Jsonclick ;
      private string imgprompt_103_Internalname ;
      private string imgprompt_103_Link ;
      private string divK2btoolstable_attributecontainernombre_unidad_Internalname ;
      private string edtnombre_unidad_Internalname ;
      private string edtnombre_unidad_Link ;
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
      private string sMode5 ;
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
      private string sCtrlAV7ResponsableId ;
      private bool Z26ResponsableActivo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A26ResponsableActivo ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool n114nombre_unidad ;
      private bool returnInSub ;
      private bool AV18IsAuthorized ;
      private bool Gx_longc ;
      private bool GXt_boolean2 ;
      private string Z29ResponsableIdentidad ;
      private string Z30ResponsableNombre ;
      private string Z96ResponsableUsuario ;
      private string Z27ResponsableCargo ;
      private string Z28ResponsableEmail ;
      private string A29ResponsableIdentidad ;
      private string A30ResponsableNombre ;
      private string A96ResponsableUsuario ;
      private string A27ResponsableCargo ;
      private string A28ResponsableEmail ;
      private string A195EstadoResponsableNombre ;
      private string A114nombre_unidad ;
      private string AV17UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV15Url ;
      private string Z195EstadoResponsableNombre ;
      private string Z114nombre_unidad ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkResponsableActivo ;
      private Object[] args ;
      private IDataStoreProvider pr_datastore1 ;
      private string[] T00054_A114nombre_unidad ;
      private bool[] T00054_n114nombre_unidad ;
      private IDataStoreProvider pr_default ;
      private string[] T00055_A195EstadoResponsableNombre ;
      private short[] T00056_A6ResponsableId ;
      private string[] T00056_A29ResponsableIdentidad ;
      private string[] T00056_A30ResponsableNombre ;
      private string[] T00056_A96ResponsableUsuario ;
      private string[] T00056_A27ResponsableCargo ;
      private string[] T00056_A28ResponsableEmail ;
      private bool[] T00056_A26ResponsableActivo ;
      private string[] T00056_A195EstadoResponsableNombre ;
      private int[] T00056_A103id_unidad ;
      private short[] T00056_A194EstadoResponsableId ;
      private string[] T00057_A195EstadoResponsableNombre ;
      private string[] T00058_A114nombre_unidad ;
      private bool[] T00058_n114nombre_unidad ;
      private short[] T00059_A6ResponsableId ;
      private short[] T00053_A6ResponsableId ;
      private string[] T00053_A29ResponsableIdentidad ;
      private string[] T00053_A30ResponsableNombre ;
      private string[] T00053_A96ResponsableUsuario ;
      private string[] T00053_A27ResponsableCargo ;
      private string[] T00053_A28ResponsableEmail ;
      private bool[] T00053_A26ResponsableActivo ;
      private int[] T00053_A103id_unidad ;
      private short[] T00053_A194EstadoResponsableId ;
      private short[] T000510_A6ResponsableId ;
      private short[] T000511_A6ResponsableId ;
      private short[] T00052_A6ResponsableId ;
      private string[] T00052_A29ResponsableIdentidad ;
      private string[] T00052_A30ResponsableNombre ;
      private string[] T00052_A96ResponsableUsuario ;
      private string[] T00052_A27ResponsableCargo ;
      private string[] T00052_A28ResponsableEmail ;
      private bool[] T00052_A26ResponsableActivo ;
      private int[] T00052_A103id_unidad ;
      private short[] T00052_A194EstadoResponsableId ;
      private short[] T000512_A6ResponsableId ;
      private string[] T000515_A195EstadoResponsableNombre ;
      private string[] T000516_A114nombre_unidad ;
      private bool[] T000516_n114nombre_unidad ;
      private long[] T000517_A14TicketId ;
      private long[] T000517_A16TicketResponsableId ;
      private long[] T000518_A18TicketTecnicoId ;
      private short[] T000519_A6ResponsableId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV24HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV20AttributeValue ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BContext AV12Context ;
      private SdtK2BAttributeValue_Item AV21AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV22Message ;
   }

   public class responsable__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class responsable__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00054;
        prmT00054 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT00058;
        prmT00058 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        Object[] prmT000516;
        prmT000516 = new Object[] {
        new ParDef("@id_unidad",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00054", "SELECT [nombre_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00058", "SELECT [nombre_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000516", "SELECT [nombre_unidad] FROM dbo.[unidades_gis] WHERE [id_unidad] = @id_unidad ",true, GxErrorMask.GX_NOMASK, false, this,prmT000516,1, GxCacheFrequency.OFF ,true,false )
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

public class responsable__gam : DataStoreHelperBase, IDataStoreHelper
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

public class responsable__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[7])
      ,new ForEachCursor(def[8])
      ,new UpdateCursor(def[9])
      ,new UpdateCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT00056;
       prmT00056 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT00055;
       prmT00055 = new Object[] {
       new ParDef("@EstadoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT00057;
       prmT00057 = new Object[] {
       new ParDef("@EstadoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT00059;
       prmT00059 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT00053;
       prmT00053 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000510;
       prmT000510 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000511;
       prmT000511 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT00052;
       prmT00052 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000512;
       prmT000512 = new Object[] {
       new ParDef("@ResponsableIdentidad",GXType.NVarChar,30,0) ,
       new ParDef("@ResponsableNombre",GXType.NVarChar,60,0) ,
       new ParDef("@ResponsableUsuario",GXType.NVarChar,100,60) ,
       new ParDef("@ResponsableCargo",GXType.NVarChar,300,0) ,
       new ParDef("@ResponsableEmail",GXType.NVarChar,100,0) ,
       new ParDef("@ResponsableActivo",GXType.Boolean,4,0) ,
       new ParDef("@id_unidad",GXType.Int32,9,0) ,
       new ParDef("@EstadoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000513;
       prmT000513 = new Object[] {
       new ParDef("@ResponsableIdentidad",GXType.NVarChar,30,0) ,
       new ParDef("@ResponsableNombre",GXType.NVarChar,60,0) ,
       new ParDef("@ResponsableUsuario",GXType.NVarChar,100,60) ,
       new ParDef("@ResponsableCargo",GXType.NVarChar,300,0) ,
       new ParDef("@ResponsableEmail",GXType.NVarChar,100,0) ,
       new ParDef("@ResponsableActivo",GXType.Boolean,4,0) ,
       new ParDef("@id_unidad",GXType.Int32,9,0) ,
       new ParDef("@EstadoResponsableId",GXType.Int16,4,0) ,
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000514;
       prmT000514 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000517;
       prmT000517 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000518;
       prmT000518 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000519;
       prmT000519 = new Object[] {
       };
       Object[] prmT000515;
       prmT000515 = new Object[] {
       new ParDef("@EstadoResponsableId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00052", "SELECT [ResponsableId], [ResponsableIdentidad], [ResponsableNombre], [ResponsableUsuario], [ResponsableCargo], [ResponsableEmail], [ResponsableActivo], [id_unidad], [EstadoResponsableId] AS EstadoResponsableId FROM [Responsable] WITH (UPDLOCK) WHERE [ResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00053", "SELECT [ResponsableId], [ResponsableIdentidad], [ResponsableNombre], [ResponsableUsuario], [ResponsableCargo], [ResponsableEmail], [ResponsableActivo], [id_unidad], [EstadoResponsableId] AS EstadoResponsableId FROM [Responsable] WHERE [ResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00055", "SELECT [EstadoTecnicosNombre] AS EstadoResponsableNombre FROM [EstadoTecnicos] WHERE [EstadoTecnicosId] = @EstadoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00056", "SELECT TM1.[ResponsableId], TM1.[ResponsableIdentidad], TM1.[ResponsableNombre], TM1.[ResponsableUsuario], TM1.[ResponsableCargo], TM1.[ResponsableEmail], TM1.[ResponsableActivo], T2.[EstadoTecnicosNombre] AS EstadoResponsableNombre, TM1.[id_unidad], TM1.[EstadoResponsableId] AS EstadoResponsableId FROM ([Responsable] TM1 INNER JOIN [EstadoTecnicos] T2 ON T2.[EstadoTecnicosId] = TM1.[EstadoResponsableId]) WHERE TM1.[ResponsableId] = @ResponsableId ORDER BY TM1.[ResponsableId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00057", "SELECT [EstadoTecnicosNombre] AS EstadoResponsableNombre FROM [EstadoTecnicos] WHERE [EstadoTecnicosId] = @EstadoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00059", "SELECT [ResponsableId] FROM [Responsable] WHERE [ResponsableId] = @ResponsableId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00059,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000510", "SELECT TOP 1 [ResponsableId] FROM [Responsable] WHERE ( [ResponsableId] > @ResponsableId) ORDER BY [ResponsableId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000510,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000511", "SELECT TOP 1 [ResponsableId] FROM [Responsable] WHERE ( [ResponsableId] < @ResponsableId) ORDER BY [ResponsableId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000511,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000512", "INSERT INTO [Responsable]([ResponsableIdentidad], [ResponsableNombre], [ResponsableUsuario], [ResponsableCargo], [ResponsableEmail], [ResponsableActivo], [id_unidad], [EstadoResponsableId]) VALUES(@ResponsableIdentidad, @ResponsableNombre, @ResponsableUsuario, @ResponsableCargo, @ResponsableEmail, @ResponsableActivo, @id_unidad, @EstadoResponsableId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000512)
          ,new CursorDef("T000513", "UPDATE [Responsable] SET [ResponsableIdentidad]=@ResponsableIdentidad, [ResponsableNombre]=@ResponsableNombre, [ResponsableUsuario]=@ResponsableUsuario, [ResponsableCargo]=@ResponsableCargo, [ResponsableEmail]=@ResponsableEmail, [ResponsableActivo]=@ResponsableActivo, [id_unidad]=@id_unidad, [EstadoResponsableId]=@EstadoResponsableId  WHERE [ResponsableId] = @ResponsableId", GxErrorMask.GX_NOMASK,prmT000513)
          ,new CursorDef("T000514", "DELETE FROM [Responsable]  WHERE [ResponsableId] = @ResponsableId", GxErrorMask.GX_NOMASK,prmT000514)
          ,new CursorDef("T000515", "SELECT [EstadoTecnicosNombre] AS EstadoResponsableNombre FROM [EstadoTecnicos] WHERE [EstadoTecnicosId] = @EstadoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000515,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000517", "SELECT TOP 1 [TicketId], [TicketResponsableId] FROM [TicketResponsable] WHERE [TicketTecnicoResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000517,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000518", "SELECT TOP 1 [TicketTecnicoId] FROM [TicketTecnico] WHERE [ResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000518,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000519", "SELECT [ResponsableId] FROM [Responsable] ORDER BY [ResponsableId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000519,100, GxCacheFrequency.OFF ,true,false )
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
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((int[]) buf[7])[0] = rslt.getInt(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((int[]) buf[7])[0] = rslt.getInt(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((int[]) buf[8])[0] = rslt.getInt(9);
             ((short[]) buf[9])[0] = rslt.getShort(10);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 5 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 6 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 8 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 12 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             return;
          case 13 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 14 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
