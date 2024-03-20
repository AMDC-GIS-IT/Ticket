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
   public class listarequerimientos : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7ListaRequerimientosId = (short)(NumberUtil.Val( GetPar( "ListaRequerimientosId"), "."));
               AssignAttri(sPrefix, false, "AV7ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(AV7ListaRequerimientosId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7ListaRequerimientosId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"") == 0 )
            {
               A366AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
               AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA3670P26( A366AreasAtencionId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
            {
               A366AreasAtencionId = (short)(NumberUtil.Val( GetPar( "AreasAtencionId"), "."));
               AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_11( A366AreasAtencionId) ;
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
                  AV7ListaRequerimientosId = (short)(NumberUtil.Val( GetPar( "ListaRequerimientosId"), "."));
                  AssignAttri(sPrefix, false, "AV7ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(AV7ListaRequerimientosId), 4, 0));
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
               Form.Meta.addItem("description", "Lista requerimientos", 0) ;
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
            GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
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

      public listarequerimientos( )
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

      public listarequerimientos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ListaRequerimientosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ListaRequerimientosId = aP1_ListaRequerimientosId;
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
            return "listarequerimientos_Execute" ;
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
            RenderHtmlCloseForm0P26( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "listarequerimientos.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerlistarequerimientosid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtListaRequerimientosId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtListaRequerimientosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A369ListaRequerimientosId), 4, 0, ".", "")), StringUtil.LTrim( ((edtListaRequerimientosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9") : context.localUtil.Format( (decimal)(A369ListaRequerimientosId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaRequerimientosId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtListaRequerimientosId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_ListaRequerimientos.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerlistarequerimientosdescripcion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtListaRequerimientosDescripcion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaRequerimientosDescripcion_Internalname, "Descripción:", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 24,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaRequerimientosDescripcion_Internalname, A370ListaRequerimientosDescripcion, StringUtil.RTrim( context.localUtil.Format( A370ListaRequerimientosDescripcion, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,24);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaRequerimientosDescripcion_Jsonclick, 0, edtListaRequerimientosDescripcion_Class, "", "", "", "", 1, edtListaRequerimientosDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "TextoCorto", "left", true, "", "HLP_ListaRequerimientos.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerareasatencionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtAreasAtencionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreasAtencionId_Internalname, "Id: ", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreasAtencionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A366AreasAtencionId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A366AreasAtencionId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreasAtencionId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtAreasAtencionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_ListaRequerimientos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_366_Internalname, sImgUrl, imgprompt_366_Link, "", "", context.GetTheme( ), imgprompt_366_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ListaRequerimientos.htm");
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
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtAreasAtencionDescripcion_Internalname, "Descripción: ", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         GxWebStd.gx_single_line_edit( context, edtAreasAtencionDescripcion_Internalname, A367AreasAtencionDescripcion, StringUtil.RTrim( context.localUtil.Format( A367AreasAtencionDescripcion, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtAreasAtencionDescripcion_Link, "", "", "", edtAreasAtencionDescripcion_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtAreasAtencionDescripcion_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_ListaRequerimientos.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerlistarequerimientosusuariosistema_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtListaRequerimientosUsuarioSistema_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtListaRequerimientosUsuarioSistema_Internalname, "Registro:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A371ListaRequerimientosUsuarioSistema", A371ListaRequerimientosUsuarioSistema);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtListaRequerimientosUsuarioSistema_Internalname, A371ListaRequerimientosUsuarioSistema, StringUtil.RTrim( context.localUtil.Format( A371ListaRequerimientosUsuarioSistema, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtListaRequerimientosUsuarioSistema_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtListaRequerimientosUsuarioSistema_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "left", true, "", "HLP_ListaRequerimientos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaRequerimientos.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ListaRequerimientos.htm");
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
         E110P2 ();
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
               Z369ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z369ListaRequerimientosId"), ".", ","));
               Z370ListaRequerimientosDescripcion = cgiGet( sPrefix+"Z370ListaRequerimientosDescripcion");
               Z371ListaRequerimientosUsuarioSistema = cgiGet( sPrefix+"Z371ListaRequerimientosUsuarioSistema");
               Z366AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z366AreasAtencionId"), ".", ","));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7ListaRequerimientosId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N366AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N366AreasAtencionId"), ".", ","));
               AV7ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vLISTAREQUERIMIENTOSID"), ".", ","));
               AV12Insert_AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_AREASATENCIONID"), ".", ","));
               AV26Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A369ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( edtListaRequerimientosId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
               A370ListaRequerimientosDescripcion = cgiGet( edtListaRequerimientosDescripcion_Internalname);
               AssignAttri(sPrefix, false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
               if ( ( ( context.localUtil.CToN( cgiGet( edtAreasAtencionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAreasAtencionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AREASATENCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtAreasAtencionId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A366AreasAtencionId = 0;
                  AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               }
               else
               {
                  A366AreasAtencionId = (short)(context.localUtil.CToN( cgiGet( edtAreasAtencionId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
               }
               A367AreasAtencionDescripcion = cgiGet( edtAreasAtencionDescripcion_Internalname);
               AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
               A371ListaRequerimientosUsuarioSistema = cgiGet( edtListaRequerimientosUsuarioSistema_Internalname);
               AssignAttri(sPrefix, false, "A371ListaRequerimientosUsuarioSistema", A371ListaRequerimientosUsuarioSistema);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ListaRequerimientos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A369ListaRequerimientosId != Z369ListaRequerimientosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("listarequerimientos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A369ListaRequerimientosId = (short)(NumberUtil.Val( GetPar( "ListaRequerimientosId"), "."));
                  AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
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
                     sMode26 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode26;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound26 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0P0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LISTAREQUERIMIENTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtListaRequerimientosId_Internalname;
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
                                 E110P2 ();
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
                                 E120P2 ();
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
                                 E130P2 ();
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
            E120P2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0P26( ) ;
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
            DisableAttributes0P26( ) ;
         }
         AssignProp(sPrefix, false, edtListaRequerimientosDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionDescripcion_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtListaRequerimientosUsuarioSistema_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosUsuarioSistema_Enabled), 5, 0), true);
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

      protected void CONFIRM_0P0( )
      {
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0P26( ) ;
            }
            else
            {
               CheckExtendedTable0P26( ) ;
               CloseExtendedTableCursors0P26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0P0( )
      {
      }

      protected void E110P2( )
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
         new k2bisauthorizedactivityname(context ).execute(  "ListaRequerimientos",  "ListaRequerimientos",  AV18StandardActivityType,  AV19UserActivityType,  AV26Pgmname, out  AV20IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV20IsAuthorized", AV20IsAuthorized);
         if ( ! AV20IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("ListaRequerimientos")),UrlEncode(StringUtil.RTrim("ListaRequerimientos")),UrlEncode(StringUtil.RTrim(AV18StandardActivityType)),UrlEncode(StringUtil.RTrim(AV19UserActivityType)),UrlEncode(StringUtil.RTrim(AV26Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "ListaRequerimientos", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Lista requerimientos", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Lista requerimientos", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Lista requerimientos", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV27GXV1 = 1;
            AssignAttri(sPrefix, false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            while ( AV27GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "AreasAtencionId") == 0 )
               {
                  AV12Insert_AreasAtencionId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV12Insert_AreasAtencionId", StringUtil.LTrimStr( (decimal)(AV12Insert_AreasAtencionId), 4, 0));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
               AssignAttri(sPrefix, false, "AV27GXV1", StringUtil.LTrimStr( (decimal)(AV27GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(AV25HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtListaRequerimientosDescripcion_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtListaRequerimientosDescripcion_Internalname, "Class", edtListaRequerimientosDescripcion_Class, true);
            }
            else
            {
               edtListaRequerimientosDescripcion_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtListaRequerimientosDescripcion_Internalname, "Class", edtListaRequerimientosDescripcion_Class, true);
            }
         }
      }

      protected void E120P2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "ListaRequerimientosId";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A369ListaRequerimientosId), 4, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "ListaRequerimientos",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La lista requerimientos %1 fue creada", A370ListaRequerimientosDescripcion, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La lista requerimientos %1 fue actualizada", A370ListaRequerimientosDescripcion, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La lista requerimientos %1 fue eliminada", A370ListaRequerimientosDescripcion, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"ListaRequerimientos",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "ListaRequerimientos") ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21AttributeValue", AV21AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10Navigation", AV10Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", AV8TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV17encrypt = AV8TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17encrypt)) )
         {
            GXt_char1 = AV17encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV17encrypt = GXt_char1;
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
               if ( StringUtil.StrCmp(AV17encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A369ListaRequerimientosId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A369ListaRequerimientosId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV17encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A369ListaRequerimientosId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A369ListaRequerimientosId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A369ListaRequerimientosId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A369ListaRequerimientosId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
               if ( StringUtil.StrCmp(AV17encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A369ListaRequerimientosId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A369ListaRequerimientosId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV17encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A369ListaRequerimientosId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A369ListaRequerimientosId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A369ListaRequerimientosId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A369ListaRequerimientosId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A369ListaRequerimientosId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E130P2( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "ListaRequerimientos") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"ListaRequerimientos"}, true);
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
            AV16Url = AV8TrnContext.gxTpr_Callerurl;
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

      protected void ZM0P26( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z370ListaRequerimientosDescripcion = T000P3_A370ListaRequerimientosDescripcion[0];
               Z371ListaRequerimientosUsuarioSistema = T000P3_A371ListaRequerimientosUsuarioSistema[0];
               Z366AreasAtencionId = T000P3_A366AreasAtencionId[0];
            }
            else
            {
               Z370ListaRequerimientosDescripcion = A370ListaRequerimientosDescripcion;
               Z371ListaRequerimientosUsuarioSistema = A371ListaRequerimientosUsuarioSistema;
               Z366AreasAtencionId = A366AreasAtencionId;
            }
         }
         if ( GX_JID == -10 )
         {
            Z369ListaRequerimientosId = A369ListaRequerimientosId;
            Z370ListaRequerimientosDescripcion = A370ListaRequerimientosDescripcion;
            Z371ListaRequerimientosUsuarioSistema = A371ListaRequerimientosUsuarioSistema;
            Z366AreasAtencionId = A366AreasAtencionId;
            Z367AreasAtencionDescripcion = A367AreasAtencionDescripcion;
         }
      }

      protected void standaloneNotModal( )
      {
         edtListaRequerimientosId_Enabled = 0;
         AssignProp(sPrefix, false, edtListaRequerimientosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Enabled), 5, 0), true);
         imgprompt_366_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptareasatencion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"AREASATENCIONID"+"'), id:'"+sPrefix+"AREASATENCIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtListaRequerimientosId_Enabled = 0;
         AssignProp(sPrefix, false, edtListaRequerimientosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Enabled), 5, 0), true);
         if ( ! (0==AV7ListaRequerimientosId) )
         {
            A369ListaRequerimientosId = AV7ListaRequerimientosId;
            AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_AreasAtencionId) )
         {
            edtAreasAtencionId_Enabled = 0;
            AssignProp(sPrefix, false, edtAreasAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionId_Enabled), 5, 0), true);
         }
         else
         {
            edtAreasAtencionId_Enabled = 1;
            AssignProp(sPrefix, false, edtAreasAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_AreasAtencionId) )
         {
            A366AreasAtencionId = AV12Insert_AreasAtencionId;
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
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
            AV26Pgmname = "ListaRequerimientos";
            AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
            /* Using cursor T000P4 */
            pr_default.execute(2, new Object[] {A366AreasAtencionId});
            A367AreasAtencionDescripcion = T000P4_A367AreasAtencionDescripcion[0];
            AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
            pr_default.close(2);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  "Display",  "",  "EntityManagerAreasAtencion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Link", edtAreasAtencionDescripcion_Link, true);
            }
         }
      }

      protected void Load0P26( )
      {
         /* Using cursor T000P5 */
         pr_default.execute(3, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
            A370ListaRequerimientosDescripcion = T000P5_A370ListaRequerimientosDescripcion[0];
            AssignAttri(sPrefix, false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
            A367AreasAtencionDescripcion = T000P5_A367AreasAtencionDescripcion[0];
            AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
            A371ListaRequerimientosUsuarioSistema = T000P5_A371ListaRequerimientosUsuarioSistema[0];
            AssignAttri(sPrefix, false, "A371ListaRequerimientosUsuarioSistema", A371ListaRequerimientosUsuarioSistema);
            A366AreasAtencionId = T000P5_A366AreasAtencionId[0];
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
            ZM0P26( -10) ;
         }
         pr_default.close(3);
         OnLoadActions0P26( ) ;
      }

      protected void OnLoadActions0P26( )
      {
         AV26Pgmname = "ListaRequerimientos";
         AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  "Display",  "",  "EntityManagerAreasAtencion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode26, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Link", edtAreasAtencionDescripcion_Link, true);
         }
      }

      protected void CheckExtendedTable0P26( )
      {
         nIsDirty_26 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV26Pgmname = "ListaRequerimientos";
         AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A370ListaRequerimientosDescripcion)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Descripción:", "", "", "", "", "", "", "", ""), 1, "LISTAREQUERIMIENTOSDESCRIPCION");
            AnyError = 1;
            GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000P4 */
         pr_default.execute(2, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Áreas de atención'.", "ForeignKeyNotFound", 1, "AREASATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtAreasAtencionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A367AreasAtencionDescripcion = T000P4_A367AreasAtencionDescripcion[0];
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         pr_default.close(2);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  "Display",  "",  "EntityManagerAreasAtencion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Link", edtAreasAtencionDescripcion_Link, true);
         }
      }

      protected void CloseExtendedTableCursors0P26( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( short A366AreasAtencionId )
      {
         /* Using cursor T000P6 */
         pr_default.execute(4, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Áreas de atención'.", "ForeignKeyNotFound", 1, "AREASATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtAreasAtencionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A367AreasAtencionDescripcion = T000P6_A367AreasAtencionDescripcion[0];
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A367AreasAtencionDescripcion)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0P26( )
      {
         /* Using cursor T000P7 */
         pr_default.execute(5, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000P3 */
         pr_default.execute(1, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0P26( 10) ;
            RcdFound26 = 1;
            A369ListaRequerimientosId = T000P3_A369ListaRequerimientosId[0];
            AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            A370ListaRequerimientosDescripcion = T000P3_A370ListaRequerimientosDescripcion[0];
            AssignAttri(sPrefix, false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
            A371ListaRequerimientosUsuarioSistema = T000P3_A371ListaRequerimientosUsuarioSistema[0];
            AssignAttri(sPrefix, false, "A371ListaRequerimientosUsuarioSistema", A371ListaRequerimientosUsuarioSistema);
            A366AreasAtencionId = T000P3_A366AreasAtencionId[0];
            AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
            Z369ListaRequerimientosId = A369ListaRequerimientosId;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0P26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0P26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0P26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0P26( ) ;
         if ( RcdFound26 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound26 = 0;
         /* Using cursor T000P8 */
         pr_default.execute(6, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000P8_A369ListaRequerimientosId[0] < A369ListaRequerimientosId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000P8_A369ListaRequerimientosId[0] > A369ListaRequerimientosId ) ) )
            {
               A369ListaRequerimientosId = T000P8_A369ListaRequerimientosId[0];
               AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000P9 */
         pr_default.execute(7, new Object[] {A369ListaRequerimientosId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000P9_A369ListaRequerimientosId[0] > A369ListaRequerimientosId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000P9_A369ListaRequerimientosId[0] < A369ListaRequerimientosId ) ) )
            {
               A369ListaRequerimientosId = T000P9_A369ListaRequerimientosId[0];
               AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0P26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0P26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A369ListaRequerimientosId != Z369ListaRequerimientosId )
               {
                  A369ListaRequerimientosId = Z369ListaRequerimientosId;
                  AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LISTAREQUERIMIENTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtListaRequerimientosId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0P26( ) ;
                  GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A369ListaRequerimientosId != Z369ListaRequerimientosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0P26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LISTAREQUERIMIENTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtListaRequerimientosId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0P26( ) ;
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
         if ( A369ListaRequerimientosId != Z369ListaRequerimientosId )
         {
            A369ListaRequerimientosId = Z369ListaRequerimientosId;
            AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LISTAREQUERIMIENTOSID");
            AnyError = 1;
            GX_FocusControl = edtListaRequerimientosId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtListaRequerimientosDescripcion_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0P26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000P2 */
            pr_default.execute(0, new Object[] {A369ListaRequerimientosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaRequerimientos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z370ListaRequerimientosDescripcion, T000P2_A370ListaRequerimientosDescripcion[0]) != 0 ) || ( StringUtil.StrCmp(Z371ListaRequerimientosUsuarioSistema, T000P2_A371ListaRequerimientosUsuarioSistema[0]) != 0 ) || ( Z366AreasAtencionId != T000P2_A366AreasAtencionId[0] ) )
            {
               if ( StringUtil.StrCmp(Z370ListaRequerimientosDescripcion, T000P2_A370ListaRequerimientosDescripcion[0]) != 0 )
               {
                  GXUtil.WriteLog("listarequerimientos:[seudo value changed for attri]"+"ListaRequerimientosDescripcion");
                  GXUtil.WriteLogRaw("Old: ",Z370ListaRequerimientosDescripcion);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A370ListaRequerimientosDescripcion[0]);
               }
               if ( StringUtil.StrCmp(Z371ListaRequerimientosUsuarioSistema, T000P2_A371ListaRequerimientosUsuarioSistema[0]) != 0 )
               {
                  GXUtil.WriteLog("listarequerimientos:[seudo value changed for attri]"+"ListaRequerimientosUsuarioSistema");
                  GXUtil.WriteLogRaw("Old: ",Z371ListaRequerimientosUsuarioSistema);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A371ListaRequerimientosUsuarioSistema[0]);
               }
               if ( Z366AreasAtencionId != T000P2_A366AreasAtencionId[0] )
               {
                  GXUtil.WriteLog("listarequerimientos:[seudo value changed for attri]"+"AreasAtencionId");
                  GXUtil.WriteLogRaw("Old: ",Z366AreasAtencionId);
                  GXUtil.WriteLogRaw("Current: ",T000P2_A366AreasAtencionId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ListaRequerimientos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0P26( )
      {
         if ( ! IsAuthorized("listarequerimientos_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0P26( 0) ;
            CheckOptimisticConcurrency0P26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0P26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P10 */
                     pr_default.execute(8, new Object[] {A370ListaRequerimientosDescripcion, A371ListaRequerimientosUsuarioSistema, A366AreasAtencionId});
                     A369ListaRequerimientosId = T000P10_A369ListaRequerimientosId[0];
                     AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ListaRequerimientos");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0P0( ) ;
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
               Load0P26( ) ;
            }
            EndLevel0P26( ) ;
         }
         CloseExtendedTableCursors0P26( ) ;
      }

      protected void Update0P26( )
      {
         if ( ! IsAuthorized("listarequerimientos_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0P26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0P26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000P11 */
                     pr_default.execute(9, new Object[] {A370ListaRequerimientosDescripcion, A371ListaRequerimientosUsuarioSistema, A366AreasAtencionId, A369ListaRequerimientosId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ListaRequerimientos");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ListaRequerimientos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0P26( ) ;
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
            EndLevel0P26( ) ;
         }
         CloseExtendedTableCursors0P26( ) ;
      }

      protected void DeferredUpdate0P26( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("listarequerimientos_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0P26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0P26( ) ;
            AfterConfirm0P26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0P26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000P12 */
                  pr_default.execute(10, new Object[] {A369ListaRequerimientosId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ListaRequerimientos");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0P26( ) ;
         Gx_mode = sMode26;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0P26( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV26Pgmname = "ListaRequerimientos";
            AssignAttri(sPrefix, false, "AV26Pgmname", AV26Pgmname);
            /* Using cursor T000P13 */
            pr_default.execute(11, new Object[] {A366AreasAtencionId});
            A367AreasAtencionDescripcion = T000P13_A367AreasAtencionDescripcion[0];
            AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
            pr_default.close(11);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  "Display",  "",  "EntityManagerAreasAtencion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Link", edtAreasAtencionDescripcion_Link, true);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000P14 */
            pr_default.execute(12, new Object[] {A369ListaRequerimientosId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Error Requerimiento"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0P26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0P26( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("listarequerimientos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("listarequerimientos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0P26( )
      {
         /* Scan By routine */
         /* Using cursor T000P15 */
         pr_default.execute(13);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound26 = 1;
            A369ListaRequerimientosId = T000P15_A369ListaRequerimientosId[0];
            AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0P26( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound26 = 1;
            A369ListaRequerimientosId = T000P15_A369ListaRequerimientosId[0];
            AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
         }
      }

      protected void ScanEnd0P26( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0P26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0P26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0P26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0P26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0P26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0P26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0P26( )
      {
         edtListaRequerimientosId_Enabled = 0;
         AssignProp(sPrefix, false, edtListaRequerimientosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosId_Enabled), 5, 0), true);
         edtListaRequerimientosDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtListaRequerimientosDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosDescripcion_Enabled), 5, 0), true);
         edtAreasAtencionId_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionId_Enabled), 5, 0), true);
         edtAreasAtencionDescripcion_Enabled = 0;
         AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreasAtencionDescripcion_Enabled), 5, 0), true);
         edtListaRequerimientosUsuarioSistema_Enabled = 0;
         AssignProp(sPrefix, false, edtListaRequerimientosUsuarioSistema_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtListaRequerimientosUsuarioSistema_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0P26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0P0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202418831336", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("listarequerimientos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ListaRequerimientosId,4,0))}, new string[] {"Gx_mode","ListaRequerimientosId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"ListaRequerimientos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("listarequerimientos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z369ListaRequerimientosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z369ListaRequerimientosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z370ListaRequerimientosDescripcion", Z370ListaRequerimientosDescripcion);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z371ListaRequerimientosUsuarioSistema", Z371ListaRequerimientosUsuarioSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z366AreasAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z366AreasAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7ListaRequerimientosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7ListaRequerimientosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N366AreasAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A366AreasAtencionId), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV21AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV21AttributeValue);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vATTRIBUTEVALUE", GetSecureSignedToken( sPrefix, AV21AttributeValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV10Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV10Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV10Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vLISTAREQUERIMIENTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ListaRequerimientosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_AREASATENCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_AreasAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV26Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0P26( )
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
         return "ListaRequerimientos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lista requerimientos" ;
      }

      protected void InitializeNonKey0P26( )
      {
         A366AreasAtencionId = 0;
         AssignAttri(sPrefix, false, "A366AreasAtencionId", StringUtil.LTrimStr( (decimal)(A366AreasAtencionId), 4, 0));
         A370ListaRequerimientosDescripcion = "";
         AssignAttri(sPrefix, false, "A370ListaRequerimientosDescripcion", A370ListaRequerimientosDescripcion);
         A367AreasAtencionDescripcion = "";
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         A371ListaRequerimientosUsuarioSistema = "";
         AssignAttri(sPrefix, false, "A371ListaRequerimientosUsuarioSistema", A371ListaRequerimientosUsuarioSistema);
         Z370ListaRequerimientosDescripcion = "";
         Z371ListaRequerimientosUsuarioSistema = "";
         Z366AreasAtencionId = 0;
      }

      protected void InitAll0P26( )
      {
         A369ListaRequerimientosId = 0;
         AssignAttri(sPrefix, false, "A369ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(A369ListaRequerimientosId), 4, 0));
         InitializeNonKey0P26( ) ;
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
         sCtrlAV7ListaRequerimientosId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "listarequerimientos", GetJustCreated( ));
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
            AV7ListaRequerimientosId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(AV7ListaRequerimientosId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7ListaRequerimientosId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7ListaRequerimientosId != wcpOAV7ListaRequerimientosId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7ListaRequerimientosId = AV7ListaRequerimientosId;
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
         sCtrlAV7ListaRequerimientosId = cgiGet( sPrefix+"AV7ListaRequerimientosId_CTRL");
         if ( StringUtil.Len( sCtrlAV7ListaRequerimientosId) > 0 )
         {
            AV7ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7ListaRequerimientosId), ".", ","));
            AssignAttri(sPrefix, false, "AV7ListaRequerimientosId", StringUtil.LTrimStr( (decimal)(AV7ListaRequerimientosId), 4, 0));
         }
         else
         {
            AV7ListaRequerimientosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7ListaRequerimientosId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7ListaRequerimientosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ListaRequerimientosId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7ListaRequerimientosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7ListaRequerimientosId_CTRL", StringUtil.RTrim( sCtrlAV7ListaRequerimientosId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188313325", true, true);
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
         context.AddJavascriptSource("listarequerimientos.js", "?2024188313326", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtListaRequerimientosId_Internalname = sPrefix+"LISTAREQUERIMIENTOSID";
         divK2btoolstable_attributecontainerlistarequerimientosid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERLISTAREQUERIMIENTOSID";
         edtListaRequerimientosDescripcion_Internalname = sPrefix+"LISTAREQUERIMIENTOSDESCRIPCION";
         divK2btoolstable_attributecontainerlistarequerimientosdescripcion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERLISTAREQUERIMIENTOSDESCRIPCION";
         edtAreasAtencionId_Internalname = sPrefix+"AREASATENCIONID";
         divK2btoolstable_attributecontainerareasatencionid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERAREASATENCIONID";
         edtAreasAtencionDescripcion_Internalname = sPrefix+"AREASATENCIONDESCRIPCION";
         divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERAREASATENCIONDESCRIPCION";
         edtListaRequerimientosUsuarioSistema_Internalname = sPrefix+"LISTAREQUERIMIENTOSUSUARIOSISTEMA";
         divK2btoolstable_attributecontainerlistarequerimientosusuariosistema_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERLISTAREQUERIMIENTOSUSUARIOSISTEMA";
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
         imgprompt_366_Internalname = sPrefix+"PROMPT_366";
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
         Form.Caption = "Lista requerimientos";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtListaRequerimientosUsuarioSistema_Jsonclick = "";
         edtListaRequerimientosUsuarioSistema_Enabled = 1;
         edtAreasAtencionDescripcion_Jsonclick = "";
         edtAreasAtencionDescripcion_Link = "";
         edtAreasAtencionDescripcion_Enabled = 0;
         imgprompt_366_Visible = 1;
         imgprompt_366_Link = "";
         edtAreasAtencionId_Jsonclick = "";
         edtAreasAtencionId_Enabled = 1;
         edtListaRequerimientosDescripcion_Jsonclick = "";
         edtListaRequerimientosDescripcion_Class = "Attribute_Trn Attribute_Required";
         edtListaRequerimientosDescripcion_Enabled = 1;
         edtListaRequerimientosId_Jsonclick = "";
         edtListaRequerimientosId_Enabled = 0;
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

      protected void GXASA3670P26( short A366AreasAtencionId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  "Display",  "",  "EntityManagerAreasAtencion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Link", edtAreasAtencionDescripcion_Link, true);
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

      public void Valid_Areasatencionid( )
      {
         /* Using cursor T000P13 */
         pr_default.execute(11, new Object[] {A366AreasAtencionId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Áreas de atención'.", "ForeignKeyNotFound", 1, "AREASATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtAreasAtencionId_Internalname;
         }
         A367AreasAtencionDescripcion = T000P13_A367AreasAtencionDescripcion[0];
         pr_default.close(11);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "AreasAtencion",  "AreasAtencion",  "Display",  "",  "EntityManagerAreasAtencion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtAreasAtencionDescripcion_Link = formatLink("entitymanagerareasatencion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A366AreasAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","AreasAtencionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A367AreasAtencionDescripcion", A367AreasAtencionDescripcion);
         AssignProp(sPrefix, false, edtAreasAtencionDescripcion_Internalname, "Link", edtAreasAtencionDescripcion_Link, true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7ListaRequerimientosId',fld:'vLISTAREQUERIMIENTOSID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120P2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A370ListaRequerimientosDescripcion',fld:'LISTAREQUERIMIENTOSDESCRIPCION',pic:''},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A369ListaRequerimientosId',fld:'LISTAREQUERIMIENTOSID',pic:'ZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E130P2',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_LISTAREQUERIMIENTOSID","{handler:'Valid_Listarequerimientosid',iparms:[]");
         setEventMetadata("VALID_LISTAREQUERIMIENTOSID",",oparms:[]}");
         setEventMetadata("VALID_LISTAREQUERIMIENTOSDESCRIPCION","{handler:'Valid_Listarequerimientosdescripcion',iparms:[]");
         setEventMetadata("VALID_LISTAREQUERIMIENTOSDESCRIPCION",",oparms:[]}");
         setEventMetadata("VALID_AREASATENCIONID","{handler:'Valid_Areasatencionid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A366AreasAtencionId',fld:'AREASATENCIONID',pic:'ZZZ9'},{av:'A367AreasAtencionDescripcion',fld:'AREASATENCIONDESCRIPCION',pic:''}]");
         setEventMetadata("VALID_AREASATENCIONID",",oparms:[{av:'A367AreasAtencionDescripcion',fld:'AREASATENCIONDESCRIPCION',pic:''},{av:'edtAreasAtencionDescripcion_Link',ctrl:'AREASATENCIONDESCRIPCION',prop:'Link'}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z370ListaRequerimientosDescripcion = "";
         Z371ListaRequerimientosUsuarioSistema = "";
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
         A370ListaRequerimientosDescripcion = "";
         TempTags = "";
         sImgUrl = "";
         A367AreasAtencionDescripcion = "";
         A371ListaRequerimientosUsuarioSistema = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV26Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode26 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV18StandardActivityType = "";
         AV19UserActivityType = "";
         AV13Context = new SdtK2BContext(context);
         AV14BtnCaption = "";
         AV15BtnTooltip = "";
         AV8TrnContext = new SdtK2BTrnContext(context);
         AV9TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV25HttpRequest = new GxHttpRequest( context);
         AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV17encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV16Url = "";
         Z367AreasAtencionDescripcion = "";
         T000P4_A367AreasAtencionDescripcion = new string[] {""} ;
         T000P5_A369ListaRequerimientosId = new short[1] ;
         T000P5_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000P5_A367AreasAtencionDescripcion = new string[] {""} ;
         T000P5_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         T000P5_A366AreasAtencionId = new short[1] ;
         T000P6_A367AreasAtencionDescripcion = new string[] {""} ;
         T000P7_A369ListaRequerimientosId = new short[1] ;
         T000P3_A369ListaRequerimientosId = new short[1] ;
         T000P3_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000P3_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         T000P3_A366AreasAtencionId = new short[1] ;
         T000P8_A369ListaRequerimientosId = new short[1] ;
         T000P9_A369ListaRequerimientosId = new short[1] ;
         T000P2_A369ListaRequerimientosId = new short[1] ;
         T000P2_A370ListaRequerimientosDescripcion = new string[] {""} ;
         T000P2_A371ListaRequerimientosUsuarioSistema = new string[] {""} ;
         T000P2_A366AreasAtencionId = new short[1] ;
         T000P10_A369ListaRequerimientosId = new short[1] ;
         T000P13_A367AreasAtencionDescripcion = new string[] {""} ;
         T000P14_A372ErrorRequerimientoId = new short[1] ;
         T000P15_A369ListaRequerimientosId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         sCtrlGx_mode = "";
         sCtrlAV7ListaRequerimientosId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.listarequerimientos__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.listarequerimientos__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.listarequerimientos__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listarequerimientos__default(),
            new Object[][] {
                new Object[] {
               T000P2_A369ListaRequerimientosId, T000P2_A370ListaRequerimientosDescripcion, T000P2_A371ListaRequerimientosUsuarioSistema, T000P2_A366AreasAtencionId
               }
               , new Object[] {
               T000P3_A369ListaRequerimientosId, T000P3_A370ListaRequerimientosDescripcion, T000P3_A371ListaRequerimientosUsuarioSistema, T000P3_A366AreasAtencionId
               }
               , new Object[] {
               T000P4_A367AreasAtencionDescripcion
               }
               , new Object[] {
               T000P5_A369ListaRequerimientosId, T000P5_A370ListaRequerimientosDescripcion, T000P5_A367AreasAtencionDescripcion, T000P5_A371ListaRequerimientosUsuarioSistema, T000P5_A366AreasAtencionId
               }
               , new Object[] {
               T000P6_A367AreasAtencionDescripcion
               }
               , new Object[] {
               T000P7_A369ListaRequerimientosId
               }
               , new Object[] {
               T000P8_A369ListaRequerimientosId
               }
               , new Object[] {
               T000P9_A369ListaRequerimientosId
               }
               , new Object[] {
               T000P10_A369ListaRequerimientosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000P13_A367AreasAtencionDescripcion
               }
               , new Object[] {
               T000P14_A372ErrorRequerimientoId
               }
               , new Object[] {
               T000P15_A369ListaRequerimientosId
               }
            }
         );
         AV26Pgmname = "ListaRequerimientos";
      }

      private short wcpOAV7ListaRequerimientosId ;
      private short Z369ListaRequerimientosId ;
      private short Z366AreasAtencionId ;
      private short N366AreasAtencionId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7ListaRequerimientosId ;
      private short A366AreasAtencionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A369ListaRequerimientosId ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV12Insert_AreasAtencionId ;
      private short RcdFound26 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_26 ;
      private int trnEnded ;
      private int edtListaRequerimientosId_Enabled ;
      private int edtListaRequerimientosDescripcion_Enabled ;
      private int edtAreasAtencionId_Enabled ;
      private int imgprompt_366_Visible ;
      private int edtAreasAtencionDescripcion_Enabled ;
      private int edtListaRequerimientosUsuarioSistema_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV27GXV1 ;
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
      private string edtListaRequerimientosDescripcion_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divK2btoolstable_attributecontainerlistarequerimientosid_Internalname ;
      private string edtListaRequerimientosId_Internalname ;
      private string edtListaRequerimientosId_Jsonclick ;
      private string divK2btoolstable_attributecontainerlistarequerimientosdescripcion_Internalname ;
      private string TempTags ;
      private string edtListaRequerimientosDescripcion_Jsonclick ;
      private string edtListaRequerimientosDescripcion_Class ;
      private string divK2btoolstable_attributecontainerareasatencionid_Internalname ;
      private string edtAreasAtencionId_Internalname ;
      private string edtAreasAtencionId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_366_Internalname ;
      private string imgprompt_366_Link ;
      private string divK2btoolstable_attributecontainerareasatenciondescripcion_Internalname ;
      private string edtAreasAtencionDescripcion_Internalname ;
      private string edtAreasAtencionDescripcion_Link ;
      private string edtAreasAtencionDescripcion_Jsonclick ;
      private string divK2btoolstable_attributecontainerlistarequerimientosusuariosistema_Internalname ;
      private string edtListaRequerimientosUsuarioSistema_Internalname ;
      private string edtListaRequerimientosUsuarioSistema_Jsonclick ;
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
      private string sMode26 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV18StandardActivityType ;
      private string AV14BtnCaption ;
      private string AV15BtnTooltip ;
      private string AV17encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7ListaRequerimientosId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV20IsAuthorized ;
      private bool GXt_boolean2 ;
      private string Z370ListaRequerimientosDescripcion ;
      private string Z371ListaRequerimientosUsuarioSistema ;
      private string A370ListaRequerimientosDescripcion ;
      private string A367AreasAtencionDescripcion ;
      private string A371ListaRequerimientosUsuarioSistema ;
      private string AV19UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV16Url ;
      private string Z367AreasAtencionDescripcion ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private string[] T000P4_A367AreasAtencionDescripcion ;
      private short[] T000P5_A369ListaRequerimientosId ;
      private string[] T000P5_A370ListaRequerimientosDescripcion ;
      private string[] T000P5_A367AreasAtencionDescripcion ;
      private string[] T000P5_A371ListaRequerimientosUsuarioSistema ;
      private short[] T000P5_A366AreasAtencionId ;
      private string[] T000P6_A367AreasAtencionDescripcion ;
      private short[] T000P7_A369ListaRequerimientosId ;
      private short[] T000P3_A369ListaRequerimientosId ;
      private string[] T000P3_A370ListaRequerimientosDescripcion ;
      private string[] T000P3_A371ListaRequerimientosUsuarioSistema ;
      private short[] T000P3_A366AreasAtencionId ;
      private short[] T000P8_A369ListaRequerimientosId ;
      private short[] T000P9_A369ListaRequerimientosId ;
      private short[] T000P2_A369ListaRequerimientosId ;
      private string[] T000P2_A370ListaRequerimientosDescripcion ;
      private string[] T000P2_A371ListaRequerimientosUsuarioSistema ;
      private short[] T000P2_A366AreasAtencionId ;
      private short[] T000P10_A369ListaRequerimientosId ;
      private string[] T000P13_A367AreasAtencionDescripcion ;
      private short[] T000P14_A372ErrorRequerimientoId ;
      private short[] T000P15_A369ListaRequerimientosId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV25HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV21AttributeValue ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BContext AV13Context ;
      private SdtK2BAttributeValue_Item AV22AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV23Message ;
   }

   public class listarequerimientos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class listarequerimientos__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class listarequerimientos__gam : DataStoreHelperBase, IDataStoreHelper
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

public class listarequerimientos__default : DataStoreHelperBase, IDataStoreHelper
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
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000P5;
       prmT000P5 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P4;
       prmT000P4 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000P6;
       prmT000P6 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000P7;
       prmT000P7 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P3;
       prmT000P3 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P8;
       prmT000P8 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P9;
       prmT000P9 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P2;
       prmT000P2 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P10;
       prmT000P10 = new Object[] {
       new ParDef("@ListaRequerimientosDescripcion",GXType.NVarChar,100,0) ,
       new ParDef("@ListaRequerimientosUsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000P11;
       prmT000P11 = new Object[] {
       new ParDef("@ListaRequerimientosDescripcion",GXType.NVarChar,100,0) ,
       new ParDef("@ListaRequerimientosUsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@AreasAtencionId",GXType.Int16,4,0) ,
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P12;
       prmT000P12 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P14;
       prmT000P14 = new Object[] {
       new ParDef("@ListaRequerimientosId",GXType.Int16,4,0)
       };
       Object[] prmT000P15;
       prmT000P15 = new Object[] {
       };
       Object[] prmT000P13;
       prmT000P13 = new Object[] {
       new ParDef("@AreasAtencionId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T000P2", "SELECT [ListaRequerimientosId], [ListaRequerimientosDescripcion], [ListaRequerimientosUsuarioSistema], [AreasAtencionId] FROM [ListaRequerimientos] WITH (UPDLOCK) WHERE [ListaRequerimientosId] = @ListaRequerimientosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P2,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P3", "SELECT [ListaRequerimientosId], [ListaRequerimientosDescripcion], [ListaRequerimientosUsuarioSistema], [AreasAtencionId] FROM [ListaRequerimientos] WHERE [ListaRequerimientosId] = @ListaRequerimientosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P3,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P4", "SELECT [AreasAtencionDescripcion] FROM [AreasAtencion] WHERE [AreasAtencionId] = @AreasAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P4,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P5", "SELECT TM1.[ListaRequerimientosId], TM1.[ListaRequerimientosDescripcion], T2.[AreasAtencionDescripcion], TM1.[ListaRequerimientosUsuarioSistema], TM1.[AreasAtencionId] FROM ([ListaRequerimientos] TM1 INNER JOIN [AreasAtencion] T2 ON T2.[AreasAtencionId] = TM1.[AreasAtencionId]) WHERE TM1.[ListaRequerimientosId] = @ListaRequerimientosId ORDER BY TM1.[ListaRequerimientosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P5,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P6", "SELECT [AreasAtencionDescripcion] FROM [AreasAtencion] WHERE [AreasAtencionId] = @AreasAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P6,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P7", "SELECT [ListaRequerimientosId] FROM [ListaRequerimientos] WHERE [ListaRequerimientosId] = @ListaRequerimientosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P7,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P8", "SELECT TOP 1 [ListaRequerimientosId] FROM [ListaRequerimientos] WHERE ( [ListaRequerimientosId] > @ListaRequerimientosId) ORDER BY [ListaRequerimientosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P8,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000P9", "SELECT TOP 1 [ListaRequerimientosId] FROM [ListaRequerimientos] WHERE ( [ListaRequerimientosId] < @ListaRequerimientosId) ORDER BY [ListaRequerimientosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P9,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000P10", "INSERT INTO [ListaRequerimientos]([ListaRequerimientosDescripcion], [ListaRequerimientosUsuarioSistema], [AreasAtencionId]) VALUES(@ListaRequerimientosDescripcion, @ListaRequerimientosUsuarioSistema, @AreasAtencionId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000P10)
          ,new CursorDef("T000P11", "UPDATE [ListaRequerimientos] SET [ListaRequerimientosDescripcion]=@ListaRequerimientosDescripcion, [ListaRequerimientosUsuarioSistema]=@ListaRequerimientosUsuarioSistema, [AreasAtencionId]=@AreasAtencionId  WHERE [ListaRequerimientosId] = @ListaRequerimientosId", GxErrorMask.GX_NOMASK,prmT000P11)
          ,new CursorDef("T000P12", "DELETE FROM [ListaRequerimientos]  WHERE [ListaRequerimientosId] = @ListaRequerimientosId", GxErrorMask.GX_NOMASK,prmT000P12)
          ,new CursorDef("T000P13", "SELECT [AreasAtencionDescripcion] FROM [AreasAtencion] WHERE [AreasAtencionId] = @AreasAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P13,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000P14", "SELECT TOP 1 [ErrorRequerimientoId] FROM [ErrorRequerimiento] WHERE [ListaRequerimientosId] = @ListaRequerimientosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000P14,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000P15", "SELECT [ListaRequerimientosId] FROM [ListaRequerimientos] ORDER BY [ListaRequerimientosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000P15,100, GxCacheFrequency.OFF ,true,false )
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
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((short[]) buf[3])[0] = rslt.getShort(4);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((short[]) buf[4])[0] = rslt.getShort(5);
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
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 13 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
