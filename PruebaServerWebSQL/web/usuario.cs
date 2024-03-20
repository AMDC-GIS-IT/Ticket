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
   public class usuario : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "AV7UsuarioId", StringUtil.LTrimStr( (decimal)(AV7UsuarioId), 4, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(short)AV7UsuarioId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
            {
               A189EstadoTicketUsuarioId = (short)(NumberUtil.Val( GetPar( "EstadoTicketUsuarioId"), "."));
               AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_16( A189EstadoTicketUsuarioId) ;
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
                  AV7UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AssignAttri(sPrefix, false, "AV7UsuarioId", StringUtil.LTrimStr( (decimal)(AV7UsuarioId), 4, 0));
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
               Form.Meta.addItem("description", "Usuario", 0) ;
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
            GX_FocusControl = edtUsuarioNombre_Internalname;
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

      public usuario( )
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

      public usuario( IGxContext context )
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
                           short aP1_UsuarioId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7UsuarioId = aP1_UsuarioId;
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
            return "usuario_Execute" ;
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
            RenderHtmlCloseForm0910( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "usuario.aspx");
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
         GxWebStd.gx_div_start( context, divClmfecha_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmfecha0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariofecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioFecha_Internalname, "Fecha Inicio:", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         context.WriteHtmlText( "<div id=\""+edtUsuarioFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioFecha_Internalname, context.localUtil.Format(A90UsuarioFecha, "99/99/9999"), context.localUtil.Format( A90UsuarioFecha, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFecha_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtUsuarioFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuario.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmfecha1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariohora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioHora_Internalname, "Hora Inicio:", "gx-form-item Attribute_TrnDateTimeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
         context.WriteHtmlText( "<div id=\""+edtUsuarioHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioHora_Internalname, context.localUtil.TToC( A92UsuarioHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A92UsuarioHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioHora_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", 1, edtUsuarioHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Hora", "right", false, "", "HLP_Usuario.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Usuario.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmusuario_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmusuario0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarioid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, "Id Usuario:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ",", "")), ((edtUsuarioId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")) : context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Usuario.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarionombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, "Usuario:", "gx-form-item Attribute_TrnLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, A93UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioNombre_Jsonclick, 0, edtUsuarioNombre_Class, "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmusuario1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarioemail_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioEmail_Internalname, "Email:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A89UsuarioEmail", A89UsuarioEmail);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioEmail_Internalname, A89UsuarioEmail, StringUtil.RTrim( context.localUtil.Format( A89UsuarioEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A89UsuarioEmail, "", "", "", edtUsuarioEmail_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Usuario.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariotelefono_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioTelefono_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioTelefono_Internalname, "Teléfono:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A95UsuarioTelefono", StringUtil.LTrimStr( (decimal)(A95UsuarioTelefono), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioTelefono_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A95UsuarioTelefono), 9, 0, ",", "")), ((edtUsuarioTelefono_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A95UsuarioTelefono), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioTelefono_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioTelefono_Enabled, 0, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "Telefono", "right", false, "", "HLP_Usuario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmgerencia_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmgerencia0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariogerencia_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioGerencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioGerencia_Internalname, "Gerencia:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioGerencia_Internalname, A91UsuarioGerencia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", 0, 1, edtUsuarioGerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Usuario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmgerencia1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariodepartamento_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioDepartamento_Internalname, "Departamento:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioDepartamento_Internalname, A88UsuarioDepartamento, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", 0, 1, edtUsuarioDepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Usuario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmreq_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmreq0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariorequerimiento_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioRequerimiento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioRequerimiento_Internalname, "Descripción del Requerimiento:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioRequerimiento_Internalname, A94UsuarioRequerimiento, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", 0, 1, edtUsuarioRequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Usuario.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoticketusuarioid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoTicketUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoTicketUsuarioId_Internalname, "Estado Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoTicketUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A189EstadoTicketUsuarioId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,102);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoTicketUsuarioId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoTicketUsuarioId_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Usuario.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_189_Internalname, sImgUrl, imgprompt_189_Link, "", "", context.GetTheme( ), imgprompt_189_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Usuario.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 110,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Usuario.htm");
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
         E11092 ();
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
               Z15UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z15UsuarioId"), ",", "."));
               Z93UsuarioNombre = cgiGet( sPrefix+"Z93UsuarioNombre");
               Z90UsuarioFecha = context.localUtil.CToD( cgiGet( sPrefix+"Z90UsuarioFecha"), 0);
               Z92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+"Z92UsuarioHora"), 0));
               Z91UsuarioGerencia = cgiGet( sPrefix+"Z91UsuarioGerencia");
               Z88UsuarioDepartamento = cgiGet( sPrefix+"Z88UsuarioDepartamento");
               Z94UsuarioRequerimiento = cgiGet( sPrefix+"Z94UsuarioRequerimiento");
               Z89UsuarioEmail = cgiGet( sPrefix+"Z89UsuarioEmail");
               Z95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z95UsuarioTelefono"), ",", "."));
               Z191UsuarioSistema = cgiGet( sPrefix+"Z191UsuarioSistema");
               Z286UsuarioFechaHora = context.localUtil.CToT( cgiGet( sPrefix+"Z286UsuarioFechaHora"), 0);
               n286UsuarioFechaHora = ((DateTime.MinValue==A286UsuarioFechaHora) ? true : false);
               Z189EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z189EstadoTicketUsuarioId"), ",", "."));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7UsuarioId"), ",", "."));
               A191UsuarioSistema = cgiGet( sPrefix+"Z191UsuarioSistema");
               A286UsuarioFechaHora = context.localUtil.CToT( cgiGet( sPrefix+"Z286UsuarioFechaHora"), 0);
               n286UsuarioFechaHora = false;
               n286UsuarioFechaHora = ((DateTime.MinValue==A286UsuarioFechaHora) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N189EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N189EstadoTicketUsuarioId"), ",", "."));
               AV7UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vUSUARIOID"), ",", "."));
               AV26Insert_EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_ESTADOTICKETUSUARIOID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."));
               A191UsuarioSistema = cgiGet( sPrefix+"USUARIOSISTEMA");
               A286UsuarioFechaHora = context.localUtil.CToT( cgiGet( sPrefix+"USUARIOFECHAHORA"), 0);
               n286UsuarioFechaHora = ((DateTime.MinValue==A286UsuarioFechaHora) ? true : false);
               A190EstadoTicketUsuarioNombre = cgiGet( sPrefix+"ESTADOTICKETUSUARIONOMBRE");
               AV29Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A90UsuarioFecha = context.localUtil.CToD( cgiGet( edtUsuarioFecha_Internalname), 2);
               AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               A92UsuarioHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtUsuarioHora_Internalname)));
               AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
               A15UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
               AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
               A89UsuarioEmail = cgiGet( edtUsuarioEmail_Internalname);
               AssignAttri(sPrefix, false, "A89UsuarioEmail", A89UsuarioEmail);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOTELEFONO");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioTelefono_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A95UsuarioTelefono = 0;
                  AssignAttri(sPrefix, false, "A95UsuarioTelefono", StringUtil.LTrimStr( (decimal)(A95UsuarioTelefono), 9, 0));
               }
               else
               {
                  A95UsuarioTelefono = (int)(context.localUtil.CToN( cgiGet( edtUsuarioTelefono_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A95UsuarioTelefono", StringUtil.LTrimStr( (decimal)(A95UsuarioTelefono), 9, 0));
               }
               A91UsuarioGerencia = cgiGet( edtUsuarioGerencia_Internalname);
               AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
               A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
               AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
               A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
               AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadoTicketUsuarioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadoTicketUsuarioId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADOTICKETUSUARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoTicketUsuarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A189EstadoTicketUsuarioId = 0;
                  AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
               }
               else
               {
                  A189EstadoTicketUsuarioId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketUsuarioId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Usuario");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("UsuarioFechaHora", context.localUtil.Format( A286UsuarioFechaHora, "99/99/9999 99:99:99"));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A15UsuarioId != Z15UsuarioId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("usuario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A15UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
                  AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
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
                     sMode10 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode10;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound10 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_090( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "USUARIOID");
                        AnyError = 1;
                        GX_FocusControl = edtUsuarioId_Internalname;
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
                                 E11092 ();
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
                                 E12092 ();
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
                                 E13092 ();
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
            E12092 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0910( ) ;
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
            DisableAttributes0910( ) ;
         }
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefono_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioGerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioGerencia_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
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

      protected void CONFIRM_090( )
      {
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0910( ) ;
            }
            else
            {
               CheckExtendedTable0910( ) ;
               CloseExtendedTableCursors0910( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption090( )
      {
      }

      protected void E11092( )
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
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  AV17StandardActivityType,  AV18UserActivityType,  AV29Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("Usuario")),UrlEncode(StringUtil.RTrim("Usuario")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV29Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "Usuario", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Usuario", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Usuario", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Usuario", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV30GXV1 = 1;
            AssignAttri(sPrefix, false, "AV30GXV1", StringUtil.LTrimStr( (decimal)(AV30GXV1), 8, 0));
            while ( AV30GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV30GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "EstadoTicketUsuarioId") == 0 )
               {
                  AV26Insert_EstadoTicketUsuarioId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV26Insert_EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(AV26Insert_EstadoTicketUsuarioId), 4, 0));
               }
               AV30GXV1 = (int)(AV30GXV1+1);
               AssignAttri(sPrefix, false, "AV30GXV1", StringUtil.LTrimStr( (decimal)(AV30GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(AV25HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtUsuarioNombre_Class = "Attribute_Trn"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Class", edtUsuarioNombre_Class, true);
            }
            else
            {
               edtUsuarioNombre_Class = "Attribute_Trn"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Class", edtUsuarioNombre_Class, true);
            }
         }
      }

      protected void E12092( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "UsuarioId";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A15UsuarioId), 4, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "Usuario",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La usuario %1 fue creada", A93UsuarioNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La usuario %1 fue actualizada", A93UsuarioNombre, "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La usuario %1 fue eliminada", A93UsuarioNombre, "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"Usuario",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "Usuario") ;
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
         AV20encrypt = AV8TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20encrypt)) )
         {
            GXt_char1 = AV20encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV20encrypt = GXt_char1;
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
               if ( StringUtil.StrCmp(AV20encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A15UsuarioId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A15UsuarioId = (short)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A15UsuarioId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A15UsuarioId = (short)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(short)A15UsuarioId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A15UsuarioId = (short)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
               if ( StringUtil.StrCmp(AV20encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(short)A15UsuarioId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A15UsuarioId = (short)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(short)A15UsuarioId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A15UsuarioId = (short)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(short)A15UsuarioId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A15UsuarioId = (short)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E13092( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "Usuario") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"Usuario"}, true);
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

      protected void ZM0910( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z93UsuarioNombre = T00093_A93UsuarioNombre[0];
               Z90UsuarioFecha = T00093_A90UsuarioFecha[0];
               Z92UsuarioHora = T00093_A92UsuarioHora[0];
               Z91UsuarioGerencia = T00093_A91UsuarioGerencia[0];
               Z88UsuarioDepartamento = T00093_A88UsuarioDepartamento[0];
               Z94UsuarioRequerimiento = T00093_A94UsuarioRequerimiento[0];
               Z89UsuarioEmail = T00093_A89UsuarioEmail[0];
               Z95UsuarioTelefono = T00093_A95UsuarioTelefono[0];
               Z191UsuarioSistema = T00093_A191UsuarioSistema[0];
               Z286UsuarioFechaHora = T00093_A286UsuarioFechaHora[0];
               Z189EstadoTicketUsuarioId = T00093_A189EstadoTicketUsuarioId[0];
            }
            else
            {
               Z93UsuarioNombre = A93UsuarioNombre;
               Z90UsuarioFecha = A90UsuarioFecha;
               Z92UsuarioHora = A92UsuarioHora;
               Z91UsuarioGerencia = A91UsuarioGerencia;
               Z88UsuarioDepartamento = A88UsuarioDepartamento;
               Z94UsuarioRequerimiento = A94UsuarioRequerimiento;
               Z89UsuarioEmail = A89UsuarioEmail;
               Z95UsuarioTelefono = A95UsuarioTelefono;
               Z191UsuarioSistema = A191UsuarioSistema;
               Z286UsuarioFechaHora = A286UsuarioFechaHora;
               Z189EstadoTicketUsuarioId = A189EstadoTicketUsuarioId;
            }
         }
         if ( GX_JID == -15 )
         {
            Z15UsuarioId = A15UsuarioId;
            Z93UsuarioNombre = A93UsuarioNombre;
            Z90UsuarioFecha = A90UsuarioFecha;
            Z92UsuarioHora = A92UsuarioHora;
            Z91UsuarioGerencia = A91UsuarioGerencia;
            Z88UsuarioDepartamento = A88UsuarioDepartamento;
            Z94UsuarioRequerimiento = A94UsuarioRequerimiento;
            Z89UsuarioEmail = A89UsuarioEmail;
            Z95UsuarioTelefono = A95UsuarioTelefono;
            Z191UsuarioSistema = A191UsuarioSistema;
            Z286UsuarioFechaHora = A286UsuarioFechaHora;
            Z189EstadoTicketUsuarioId = A189EstadoTicketUsuarioId;
            Z190EstadoTicketUsuarioNombre = A190EstadoTicketUsuarioNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Enabled), 5, 0), true);
         edtUsuarioHora_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioHora_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_189_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadoticket.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"ESTADOTICKETUSUARIOID"+"'), id:'"+sPrefix+"ESTADOTICKETUSUARIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Enabled), 5, 0), true);
         edtUsuarioHora_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioHora_Enabled), 5, 0), true);
         if ( ! (0==AV7UsuarioId) )
         {
            A15UsuarioId = AV7UsuarioId;
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_EstadoTicketUsuarioId) )
         {
            edtEstadoTicketUsuarioId_Enabled = 0;
            AssignProp(sPrefix, false, edtEstadoTicketUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketUsuarioId_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadoTicketUsuarioId_Enabled = 1;
            AssignProp(sPrefix, false, edtEstadoTicketUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketUsuarioId_Enabled), 5, 0), true);
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_EstadoTicketUsuarioId) )
         {
            A189EstadoTicketUsuarioId = AV26Insert_EstadoTicketUsuarioId;
            AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A189EstadoTicketUsuarioId) && ( Gx_BScreen == 0 ) )
            {
               A189EstadoTicketUsuarioId = 1;
               AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A90UsuarioFecha) && ( Gx_BScreen == 0 ) )
         {
            A90UsuarioFecha = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A92UsuarioHora) && ( Gx_BScreen == 0 ) )
         {
            A92UsuarioHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A191UsuarioSistema)) && ( Gx_BScreen == 0 ) )
         {
            A191UsuarioSistema = AV27WebSession.Get("UsuarioConectado");
            AssignAttri(sPrefix, false, "A191UsuarioSistema", A191UsuarioSistema);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV29Pgmname = "Usuario";
            AssignAttri(sPrefix, false, "AV29Pgmname", AV29Pgmname);
            /* Using cursor T00094 */
            pr_default.execute(2, new Object[] {A189EstadoTicketUsuarioId});
            A190EstadoTicketUsuarioNombre = T00094_A190EstadoTicketUsuarioNombre[0];
            pr_default.close(2);
         }
      }

      protected void Load0910( )
      {
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound10 = 1;
            A93UsuarioNombre = T00095_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A90UsuarioFecha = T00095_A90UsuarioFecha[0];
            AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
            A92UsuarioHora = T00095_A92UsuarioHora[0];
            AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
            A91UsuarioGerencia = T00095_A91UsuarioGerencia[0];
            AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
            A88UsuarioDepartamento = T00095_A88UsuarioDepartamento[0];
            AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            A94UsuarioRequerimiento = T00095_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A89UsuarioEmail = T00095_A89UsuarioEmail[0];
            AssignAttri(sPrefix, false, "A89UsuarioEmail", A89UsuarioEmail);
            A95UsuarioTelefono = T00095_A95UsuarioTelefono[0];
            AssignAttri(sPrefix, false, "A95UsuarioTelefono", StringUtil.LTrimStr( (decimal)(A95UsuarioTelefono), 9, 0));
            A190EstadoTicketUsuarioNombre = T00095_A190EstadoTicketUsuarioNombre[0];
            A191UsuarioSistema = T00095_A191UsuarioSistema[0];
            A286UsuarioFechaHora = T00095_A286UsuarioFechaHora[0];
            n286UsuarioFechaHora = T00095_n286UsuarioFechaHora[0];
            A189EstadoTicketUsuarioId = T00095_A189EstadoTicketUsuarioId[0];
            AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
            ZM0910( -15) ;
         }
         pr_default.close(3);
         OnLoadActions0910( ) ;
      }

      protected void OnLoadActions0910( )
      {
         AV29Pgmname = "Usuario";
         AssignAttri(sPrefix, false, "AV29Pgmname", AV29Pgmname);
      }

      protected void CheckExtendedTable0910( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV29Pgmname = "Usuario";
         AssignAttri(sPrefix, false, "AV29Pgmname", AV29Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A93UsuarioNombre)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Usuario:", "", "", "", "", "", "", "", ""), 1, "USUARIONOMBRE");
            AnyError = 1;
            GX_FocusControl = edtUsuarioNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( GxRegex.IsMatch(A89UsuarioEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("El valor de Email no coincide con el patrón especificado", "OutOfRange", 1, "USUARIOEMAIL");
            AnyError = 1;
            GX_FocusControl = edtUsuarioEmail_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00094 */
         pr_default.execute(2, new Object[] {A189EstadoTicketUsuarioId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Ticket Usuario'.", "ForeignKeyNotFound", 1, "ESTADOTICKETUSUARIOID");
            AnyError = 1;
            GX_FocusControl = edtEstadoTicketUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A190EstadoTicketUsuarioNombre = T00094_A190EstadoTicketUsuarioNombre[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0910( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_16( short A189EstadoTicketUsuarioId )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {A189EstadoTicketUsuarioId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Ticket Usuario'.", "ForeignKeyNotFound", 1, "ESTADOTICKETUSUARIOID");
            AnyError = 1;
            GX_FocusControl = edtEstadoTicketUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A190EstadoTicketUsuarioNombre = T00096_A190EstadoTicketUsuarioNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A190EstadoTicketUsuarioNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0910( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0910( 15) ;
            RcdFound10 = 1;
            A15UsuarioId = T00093_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            A93UsuarioNombre = T00093_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A90UsuarioFecha = T00093_A90UsuarioFecha[0];
            AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
            A92UsuarioHora = T00093_A92UsuarioHora[0];
            AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
            A91UsuarioGerencia = T00093_A91UsuarioGerencia[0];
            AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
            A88UsuarioDepartamento = T00093_A88UsuarioDepartamento[0];
            AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            A94UsuarioRequerimiento = T00093_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A89UsuarioEmail = T00093_A89UsuarioEmail[0];
            AssignAttri(sPrefix, false, "A89UsuarioEmail", A89UsuarioEmail);
            A95UsuarioTelefono = T00093_A95UsuarioTelefono[0];
            AssignAttri(sPrefix, false, "A95UsuarioTelefono", StringUtil.LTrimStr( (decimal)(A95UsuarioTelefono), 9, 0));
            A191UsuarioSistema = T00093_A191UsuarioSistema[0];
            A286UsuarioFechaHora = T00093_A286UsuarioFechaHora[0];
            n286UsuarioFechaHora = T00093_n286UsuarioFechaHora[0];
            A189EstadoTicketUsuarioId = T00093_A189EstadoTicketUsuarioId[0];
            AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
            Z15UsuarioId = A15UsuarioId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load0910( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0910( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0910( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0910( ) ;
         if ( RcdFound10 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound10 = 0;
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00098_A15UsuarioId[0] < A15UsuarioId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00098_A15UsuarioId[0] > A15UsuarioId ) ) )
            {
               A15UsuarioId = T00098_A15UsuarioId[0];
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00099_A15UsuarioId[0] > A15UsuarioId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00099_A15UsuarioId[0] < A15UsuarioId ) ) )
            {
               A15UsuarioId = T00099_A15UsuarioId[0];
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0910( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuarioNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert0910( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A15UsuarioId != Z15UsuarioId )
               {
                  A15UsuarioId = Z15UsuarioId;
                  AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuarioNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0910( ) ;
                  GX_FocusControl = edtUsuarioNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A15UsuarioId != Z15UsuarioId )
               {
                  /* Insert record */
                  GX_FocusControl = edtUsuarioNombre_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert0910( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUARIOID");
                     AnyError = 1;
                     GX_FocusControl = edtUsuarioId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtUsuarioNombre_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert0910( ) ;
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
         if ( A15UsuarioId != Z15UsuarioId )
         {
            A15UsuarioId = Z15UsuarioId;
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuarioNombre_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0910( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A15UsuarioId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z93UsuarioNombre, T00092_A93UsuarioNombre[0]) != 0 ) || ( Z90UsuarioFecha != T00092_A90UsuarioFecha[0] ) || ( Z92UsuarioHora != T00092_A92UsuarioHora[0] ) || ( StringUtil.StrCmp(Z91UsuarioGerencia, T00092_A91UsuarioGerencia[0]) != 0 ) || ( StringUtil.StrCmp(Z88UsuarioDepartamento, T00092_A88UsuarioDepartamento[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z94UsuarioRequerimiento, T00092_A94UsuarioRequerimiento[0]) != 0 ) || ( StringUtil.StrCmp(Z89UsuarioEmail, T00092_A89UsuarioEmail[0]) != 0 ) || ( Z95UsuarioTelefono != T00092_A95UsuarioTelefono[0] ) || ( StringUtil.StrCmp(Z191UsuarioSistema, T00092_A191UsuarioSistema[0]) != 0 ) || ( Z286UsuarioFechaHora != T00092_A286UsuarioFechaHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z189EstadoTicketUsuarioId != T00092_A189EstadoTicketUsuarioId[0] ) )
            {
               if ( StringUtil.StrCmp(Z93UsuarioNombre, T00092_A93UsuarioNombre[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioNombre");
                  GXUtil.WriteLogRaw("Old: ",Z93UsuarioNombre);
                  GXUtil.WriteLogRaw("Current: ",T00092_A93UsuarioNombre[0]);
               }
               if ( Z90UsuarioFecha != T00092_A90UsuarioFecha[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioFecha");
                  GXUtil.WriteLogRaw("Old: ",Z90UsuarioFecha);
                  GXUtil.WriteLogRaw("Current: ",T00092_A90UsuarioFecha[0]);
               }
               if ( Z92UsuarioHora != T00092_A92UsuarioHora[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioHora");
                  GXUtil.WriteLogRaw("Old: ",Z92UsuarioHora);
                  GXUtil.WriteLogRaw("Current: ",T00092_A92UsuarioHora[0]);
               }
               if ( StringUtil.StrCmp(Z91UsuarioGerencia, T00092_A91UsuarioGerencia[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioGerencia");
                  GXUtil.WriteLogRaw("Old: ",Z91UsuarioGerencia);
                  GXUtil.WriteLogRaw("Current: ",T00092_A91UsuarioGerencia[0]);
               }
               if ( StringUtil.StrCmp(Z88UsuarioDepartamento, T00092_A88UsuarioDepartamento[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioDepartamento");
                  GXUtil.WriteLogRaw("Old: ",Z88UsuarioDepartamento);
                  GXUtil.WriteLogRaw("Current: ",T00092_A88UsuarioDepartamento[0]);
               }
               if ( StringUtil.StrCmp(Z94UsuarioRequerimiento, T00092_A94UsuarioRequerimiento[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioRequerimiento");
                  GXUtil.WriteLogRaw("Old: ",Z94UsuarioRequerimiento);
                  GXUtil.WriteLogRaw("Current: ",T00092_A94UsuarioRequerimiento[0]);
               }
               if ( StringUtil.StrCmp(Z89UsuarioEmail, T00092_A89UsuarioEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioEmail");
                  GXUtil.WriteLogRaw("Old: ",Z89UsuarioEmail);
                  GXUtil.WriteLogRaw("Current: ",T00092_A89UsuarioEmail[0]);
               }
               if ( Z95UsuarioTelefono != T00092_A95UsuarioTelefono[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioTelefono");
                  GXUtil.WriteLogRaw("Old: ",Z95UsuarioTelefono);
                  GXUtil.WriteLogRaw("Current: ",T00092_A95UsuarioTelefono[0]);
               }
               if ( StringUtil.StrCmp(Z191UsuarioSistema, T00092_A191UsuarioSistema[0]) != 0 )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioSistema");
                  GXUtil.WriteLogRaw("Old: ",Z191UsuarioSistema);
                  GXUtil.WriteLogRaw("Current: ",T00092_A191UsuarioSistema[0]);
               }
               if ( Z286UsuarioFechaHora != T00092_A286UsuarioFechaHora[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"UsuarioFechaHora");
                  GXUtil.WriteLogRaw("Old: ",Z286UsuarioFechaHora);
                  GXUtil.WriteLogRaw("Current: ",T00092_A286UsuarioFechaHora[0]);
               }
               if ( Z189EstadoTicketUsuarioId != T00092_A189EstadoTicketUsuarioId[0] )
               {
                  GXUtil.WriteLog("usuario:[seudo value changed for attri]"+"EstadoTicketUsuarioId");
                  GXUtil.WriteLogRaw("Old: ",Z189EstadoTicketUsuarioId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A189EstadoTicketUsuarioId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Usuario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0910( )
      {
         if ( ! IsAuthorized("usuario_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0910( 0) ;
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000910 */
                     pr_default.execute(8, new Object[] {A93UsuarioNombre, A90UsuarioFecha, A92UsuarioHora, A91UsuarioGerencia, A88UsuarioDepartamento, A94UsuarioRequerimiento, A89UsuarioEmail, A95UsuarioTelefono, A191UsuarioSistema, n286UsuarioFechaHora, A286UsuarioFechaHora, A189EstadoTicketUsuarioId});
                     A15UsuarioId = T000910_A15UsuarioId[0];
                     AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuario");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
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
               Load0910( ) ;
            }
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void Update0910( )
      {
         if ( ! IsAuthorized("usuario_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0910( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0910( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0910( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000911 */
                     pr_default.execute(9, new Object[] {A93UsuarioNombre, A90UsuarioFecha, A92UsuarioHora, A91UsuarioGerencia, A88UsuarioDepartamento, A94UsuarioRequerimiento, A89UsuarioEmail, A95UsuarioTelefono, A191UsuarioSistema, n286UsuarioFechaHora, A286UsuarioFechaHora, A189EstadoTicketUsuarioId, A15UsuarioId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("Usuario");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Usuario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0910( ) ;
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
            EndLevel0910( ) ;
         }
         CloseExtendedTableCursors0910( ) ;
      }

      protected void DeferredUpdate0910( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("usuario_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0910( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0910( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0910( ) ;
            AfterConfirm0910( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0910( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000912 */
                  pr_default.execute(10, new Object[] {A15UsuarioId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("Usuario");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel0910( ) ;
         Gx_mode = sMode10;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0910( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV29Pgmname = "Usuario";
            AssignAttri(sPrefix, false, "AV29Pgmname", AV29Pgmname);
            /* Using cursor T000913 */
            pr_default.execute(11, new Object[] {A189EstadoTicketUsuarioId});
            A190EstadoTicketUsuarioNombre = T000913_A190EstadoTicketUsuarioNombre[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000914 */
            pr_default.execute(12, new Object[] {A15UsuarioId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ticket"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0910( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0910( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("usuario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("usuario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0910( )
      {
         /* Scan By routine */
         /* Using cursor T000915 */
         pr_default.execute(13);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A15UsuarioId = T000915_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0910( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A15UsuarioId = T000915_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         }
      }

      protected void ScanEnd0910( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0910( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0910( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0910( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0910( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0910( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0910( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0910( )
      {
         edtUsuarioFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Enabled), 5, 0), true);
         edtUsuarioHora_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioHora_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioEmail_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioEmail_Enabled), 5, 0), true);
         edtUsuarioTelefono_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioTelefono_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioTelefono_Enabled), 5, 0), true);
         edtUsuarioGerencia_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioGerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioGerencia_Enabled), 5, 0), true);
         edtUsuarioDepartamento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Enabled), 5, 0), true);
         edtUsuarioRequerimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         edtEstadoTicketUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketUsuarioId_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0910( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.AddJavascriptSource("gxcfg.js", "?2023124949577", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 1810380), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 1810380), false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("usuario.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7UsuarioId,4,0))}, new string[] {"Gx_mode","UsuarioId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Usuario");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("UsuarioFechaHora", context.localUtil.Format( A286UsuarioFechaHora, "99/99/9999 99:99:99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("usuario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z93UsuarioNombre", Z93UsuarioNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z90UsuarioFecha", context.localUtil.DToC( Z90UsuarioFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z92UsuarioHora", context.localUtil.TToC( Z92UsuarioHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z91UsuarioGerencia", Z91UsuarioGerencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z88UsuarioDepartamento", Z88UsuarioDepartamento);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z94UsuarioRequerimiento", Z94UsuarioRequerimiento);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z89UsuarioEmail", Z89UsuarioEmail);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z95UsuarioTelefono", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z95UsuarioTelefono), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z191UsuarioSistema", Z191UsuarioSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z286UsuarioFechaHora", context.localUtil.TToC( Z286UsuarioFechaHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z189EstadoTicketUsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z189EstadoTicketUsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N189EstadoTicketUsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A189EstadoTicketUsuarioId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_ESTADOTICKETUSUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Insert_EstadoTicketUsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOSISTEMA", A191UsuarioSistema);
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOFECHAHORA", context.localUtil.TToC( A286UsuarioFechaHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"ESTADOTICKETUSUARIONOMBRE", A190EstadoTicketUsuarioNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV29Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm0910( )
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
         return "Usuario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuario" ;
      }

      protected void InitializeNonKey0910( )
      {
         A93UsuarioNombre = "";
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A91UsuarioGerencia = "";
         AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
         A88UsuarioDepartamento = "";
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         A94UsuarioRequerimiento = "";
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A89UsuarioEmail = "";
         AssignAttri(sPrefix, false, "A89UsuarioEmail", A89UsuarioEmail);
         A95UsuarioTelefono = 0;
         AssignAttri(sPrefix, false, "A95UsuarioTelefono", StringUtil.LTrimStr( (decimal)(A95UsuarioTelefono), 9, 0));
         A190EstadoTicketUsuarioNombre = "";
         AssignAttri(sPrefix, false, "A190EstadoTicketUsuarioNombre", A190EstadoTicketUsuarioNombre);
         A286UsuarioFechaHora = (DateTime)(DateTime.MinValue);
         n286UsuarioFechaHora = false;
         AssignAttri(sPrefix, false, "A286UsuarioFechaHora", context.localUtil.TToC( A286UsuarioFechaHora, 10, 8, 0, 3, "/", ":", " "));
         A189EstadoTicketUsuarioId = 1;
         AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
         A90UsuarioFecha = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         A92UsuarioHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
         A191UsuarioSistema = AV27WebSession.Get("UsuarioConectado");
         AssignAttri(sPrefix, false, "A191UsuarioSistema", A191UsuarioSistema);
         Z93UsuarioNombre = "";
         Z90UsuarioFecha = DateTime.MinValue;
         Z92UsuarioHora = (DateTime)(DateTime.MinValue);
         Z91UsuarioGerencia = "";
         Z88UsuarioDepartamento = "";
         Z94UsuarioRequerimiento = "";
         Z89UsuarioEmail = "";
         Z95UsuarioTelefono = 0;
         Z191UsuarioSistema = "";
         Z286UsuarioFechaHora = (DateTime)(DateTime.MinValue);
         Z189EstadoTicketUsuarioId = 0;
      }

      protected void InitAll0910( )
      {
         A15UsuarioId = 0;
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         InitializeNonKey0910( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A189EstadoTicketUsuarioId = i189EstadoTicketUsuarioId;
         AssignAttri(sPrefix, false, "A189EstadoTicketUsuarioId", StringUtil.LTrimStr( (decimal)(A189EstadoTicketUsuarioId), 4, 0));
         A90UsuarioFecha = i90UsuarioFecha;
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         A92UsuarioHora = i92UsuarioHora;
         AssignAttri(sPrefix, false, "A92UsuarioHora", context.localUtil.TToC( A92UsuarioHora, 0, 5, 0, 3, "/", ":", " "));
         A191UsuarioSistema = i191UsuarioSistema;
         AssignAttri(sPrefix, false, "A191UsuarioSistema", A191UsuarioSistema);
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7UsuarioId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "usuario", GetJustCreated( ));
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
            AV7UsuarioId = Convert.ToInt16(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7UsuarioId", StringUtil.LTrimStr( (decimal)(AV7UsuarioId), 4, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7UsuarioId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7UsuarioId != wcpOAV7UsuarioId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7UsuarioId = AV7UsuarioId;
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
         sCtrlAV7UsuarioId = cgiGet( sPrefix+"AV7UsuarioId_CTRL");
         if ( StringUtil.Len( sCtrlAV7UsuarioId) > 0 )
         {
            AV7UsuarioId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV7UsuarioId), ",", "."));
            AssignAttri(sPrefix, false, "AV7UsuarioId", StringUtil.LTrimStr( (decimal)(AV7UsuarioId), 4, 0));
         }
         else
         {
            AV7UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV7UsuarioId_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuarioId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7UsuarioId), 4, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7UsuarioId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuarioId_CTRL", StringUtil.RTrim( sCtrlAV7UsuarioId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249495732", true, true);
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
         context.AddJavascriptSource("usuario.js", "?20231249495732", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA";
         divK2btoolstable_attributecontainerusuariofecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOFECHA";
         divTableclmfecha0_Internalname = sPrefix+"TABLECLMFECHA0";
         edtUsuarioHora_Internalname = sPrefix+"USUARIOHORA";
         divK2btoolstable_attributecontainerusuariohora_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOHORA";
         divTableclmfecha1_Internalname = sPrefix+"TABLECLMFECHA1";
         divClmfecha_Internalname = sPrefix+"CLMFECHA";
         edtUsuarioId_Internalname = sPrefix+"USUARIOID";
         divK2btoolstable_attributecontainerusuarioid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOID";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         divTableclmusuario0_Internalname = sPrefix+"TABLECLMUSUARIO0";
         edtUsuarioEmail_Internalname = sPrefix+"USUARIOEMAIL";
         divK2btoolstable_attributecontainerusuarioemail_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOEMAIL";
         edtUsuarioTelefono_Internalname = sPrefix+"USUARIOTELEFONO";
         divK2btoolstable_attributecontainerusuariotelefono_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOTELEFONO";
         divTableclmusuario1_Internalname = sPrefix+"TABLECLMUSUARIO1";
         divClmusuario_Internalname = sPrefix+"CLMUSUARIO";
         edtUsuarioGerencia_Internalname = sPrefix+"USUARIOGERENCIA";
         divK2btoolstable_attributecontainerusuariogerencia_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOGERENCIA";
         divTableclmgerencia0_Internalname = sPrefix+"TABLECLMGERENCIA0";
         edtUsuarioDepartamento_Internalname = sPrefix+"USUARIODEPARTAMENTO";
         divK2btoolstable_attributecontainerusuariodepartamento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIODEPARTAMENTO";
         divTableclmgerencia1_Internalname = sPrefix+"TABLECLMGERENCIA1";
         divClmgerencia_Internalname = sPrefix+"CLMGERENCIA";
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO";
         divK2btoolstable_attributecontainerusuariorequerimiento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOREQUERIMIENTO";
         divTableclmreq0_Internalname = sPrefix+"TABLECLMREQ0";
         divClmreq_Internalname = sPrefix+"CLMREQ";
         edtEstadoTicketUsuarioId_Internalname = sPrefix+"ESTADOTICKETUSUARIOID";
         divK2btoolstable_attributecontainerestadoticketusuarioid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOTICKETUSUARIOID";
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
         imgprompt_189_Internalname = sPrefix+"PROMPT_189";
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
         Form.Caption = "Usuario";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         imgprompt_189_Visible = 1;
         imgprompt_189_Link = "";
         edtEstadoTicketUsuarioId_Jsonclick = "";
         edtEstadoTicketUsuarioId_Enabled = 1;
         edtUsuarioRequerimiento_Enabled = 1;
         edtUsuarioDepartamento_Enabled = 1;
         edtUsuarioGerencia_Enabled = 1;
         edtUsuarioTelefono_Jsonclick = "";
         edtUsuarioTelefono_Enabled = 1;
         edtUsuarioEmail_Jsonclick = "";
         edtUsuarioEmail_Enabled = 1;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Class = "Attribute_Trn Attribute_Required";
         edtUsuarioNombre_Enabled = 1;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 0;
         edtUsuarioHora_Jsonclick = "";
         edtUsuarioHora_Enabled = 0;
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioFecha_Enabled = 0;
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

      public void Valid_Estadoticketusuarioid( )
      {
         /* Using cursor T000913 */
         pr_default.execute(11, new Object[] {A189EstadoTicketUsuarioId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Ticket Usuario'.", "ForeignKeyNotFound", 1, "ESTADOTICKETUSUARIOID");
            AnyError = 1;
            GX_FocusControl = edtEstadoTicketUsuarioId_Internalname;
         }
         A190EstadoTicketUsuarioNombre = T000913_A190EstadoTicketUsuarioNombre[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A190EstadoTicketUsuarioNombre", A190EstadoTicketUsuarioNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7UsuarioId',fld:'vUSUARIOID',pic:'ZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A286UsuarioFechaHora',fld:'USUARIOFECHAHORA',pic:'99/99/9999 99:99:99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12092',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13092',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[]");
         setEventMetadata("VALID_USUARIOID",",oparms:[]}");
         setEventMetadata("VALID_USUARIONOMBRE","{handler:'Valid_Usuarionombre',iparms:[]");
         setEventMetadata("VALID_USUARIONOMBRE",",oparms:[]}");
         setEventMetadata("VALID_USUARIOEMAIL","{handler:'Valid_Usuarioemail',iparms:[]");
         setEventMetadata("VALID_USUARIOEMAIL",",oparms:[]}");
         setEventMetadata("VALID_ESTADOTICKETUSUARIOID","{handler:'Valid_Estadoticketusuarioid',iparms:[{av:'A189EstadoTicketUsuarioId',fld:'ESTADOTICKETUSUARIOID',pic:'ZZZ9'},{av:'A190EstadoTicketUsuarioNombre',fld:'ESTADOTICKETUSUARIONOMBRE',pic:''}]");
         setEventMetadata("VALID_ESTADOTICKETUSUARIOID",",oparms:[{av:'A190EstadoTicketUsuarioNombre',fld:'ESTADOTICKETUSUARIONOMBRE',pic:''}]}");
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
         Z93UsuarioNombre = "";
         Z90UsuarioFecha = DateTime.MinValue;
         Z92UsuarioHora = (DateTime)(DateTime.MinValue);
         Z91UsuarioGerencia = "";
         Z88UsuarioDepartamento = "";
         Z94UsuarioRequerimiento = "";
         Z89UsuarioEmail = "";
         Z191UsuarioSistema = "";
         Z286UsuarioFechaHora = (DateTime)(DateTime.MinValue);
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
         A90UsuarioFecha = DateTime.MinValue;
         A92UsuarioHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         TempTags = "";
         A89UsuarioEmail = "";
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         sImgUrl = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         A286UsuarioFechaHora = (DateTime)(DateTime.MinValue);
         A191UsuarioSistema = "";
         A190EstadoTicketUsuarioNombre = "";
         AV29Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode10 = "";
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
         AV8TrnContext = new SdtK2BTrnContext(context);
         AV9TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV25HttpRequest = new GxHttpRequest( context);
         AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV20encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV16Url = "";
         Z190EstadoTicketUsuarioNombre = "";
         AV27WebSession = context.GetSession();
         T00094_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         T00095_A15UsuarioId = new short[1] ;
         T00095_A93UsuarioNombre = new string[] {""} ;
         T00095_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T00095_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         T00095_A91UsuarioGerencia = new string[] {""} ;
         T00095_A88UsuarioDepartamento = new string[] {""} ;
         T00095_A94UsuarioRequerimiento = new string[] {""} ;
         T00095_A89UsuarioEmail = new string[] {""} ;
         T00095_A95UsuarioTelefono = new int[1] ;
         T00095_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         T00095_A191UsuarioSistema = new string[] {""} ;
         T00095_A286UsuarioFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00095_n286UsuarioFechaHora = new bool[] {false} ;
         T00095_A189EstadoTicketUsuarioId = new short[1] ;
         T00096_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         T00097_A15UsuarioId = new short[1] ;
         T00093_A15UsuarioId = new short[1] ;
         T00093_A93UsuarioNombre = new string[] {""} ;
         T00093_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T00093_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         T00093_A91UsuarioGerencia = new string[] {""} ;
         T00093_A88UsuarioDepartamento = new string[] {""} ;
         T00093_A94UsuarioRequerimiento = new string[] {""} ;
         T00093_A89UsuarioEmail = new string[] {""} ;
         T00093_A95UsuarioTelefono = new int[1] ;
         T00093_A191UsuarioSistema = new string[] {""} ;
         T00093_A286UsuarioFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00093_n286UsuarioFechaHora = new bool[] {false} ;
         T00093_A189EstadoTicketUsuarioId = new short[1] ;
         T00098_A15UsuarioId = new short[1] ;
         T00099_A15UsuarioId = new short[1] ;
         T00092_A15UsuarioId = new short[1] ;
         T00092_A93UsuarioNombre = new string[] {""} ;
         T00092_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T00092_A92UsuarioHora = new DateTime[] {DateTime.MinValue} ;
         T00092_A91UsuarioGerencia = new string[] {""} ;
         T00092_A88UsuarioDepartamento = new string[] {""} ;
         T00092_A94UsuarioRequerimiento = new string[] {""} ;
         T00092_A89UsuarioEmail = new string[] {""} ;
         T00092_A95UsuarioTelefono = new int[1] ;
         T00092_A191UsuarioSistema = new string[] {""} ;
         T00092_A286UsuarioFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00092_n286UsuarioFechaHora = new bool[] {false} ;
         T00092_A189EstadoTicketUsuarioId = new short[1] ;
         T000910_A15UsuarioId = new short[1] ;
         T000913_A190EstadoTicketUsuarioNombre = new string[] {""} ;
         T000914_A14TicketId = new long[1] ;
         T000915_A15UsuarioId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i90UsuarioFecha = DateTime.MinValue;
         i92UsuarioHora = (DateTime)(DateTime.MinValue);
         i191UsuarioSistema = "";
         sCtrlGx_mode = "";
         sCtrlAV7UsuarioId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.usuario__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.usuario__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.usuario__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuario__default(),
            new Object[][] {
                new Object[] {
               T00092_A15UsuarioId, T00092_A93UsuarioNombre, T00092_A90UsuarioFecha, T00092_A92UsuarioHora, T00092_A91UsuarioGerencia, T00092_A88UsuarioDepartamento, T00092_A94UsuarioRequerimiento, T00092_A89UsuarioEmail, T00092_A95UsuarioTelefono, T00092_A191UsuarioSistema,
               T00092_A286UsuarioFechaHora, T00092_n286UsuarioFechaHora, T00092_A189EstadoTicketUsuarioId
               }
               , new Object[] {
               T00093_A15UsuarioId, T00093_A93UsuarioNombre, T00093_A90UsuarioFecha, T00093_A92UsuarioHora, T00093_A91UsuarioGerencia, T00093_A88UsuarioDepartamento, T00093_A94UsuarioRequerimiento, T00093_A89UsuarioEmail, T00093_A95UsuarioTelefono, T00093_A191UsuarioSistema,
               T00093_A286UsuarioFechaHora, T00093_n286UsuarioFechaHora, T00093_A189EstadoTicketUsuarioId
               }
               , new Object[] {
               T00094_A190EstadoTicketUsuarioNombre
               }
               , new Object[] {
               T00095_A15UsuarioId, T00095_A93UsuarioNombre, T00095_A90UsuarioFecha, T00095_A92UsuarioHora, T00095_A91UsuarioGerencia, T00095_A88UsuarioDepartamento, T00095_A94UsuarioRequerimiento, T00095_A89UsuarioEmail, T00095_A95UsuarioTelefono, T00095_A190EstadoTicketUsuarioNombre,
               T00095_A191UsuarioSistema, T00095_A286UsuarioFechaHora, T00095_n286UsuarioFechaHora, T00095_A189EstadoTicketUsuarioId
               }
               , new Object[] {
               T00096_A190EstadoTicketUsuarioNombre
               }
               , new Object[] {
               T00097_A15UsuarioId
               }
               , new Object[] {
               T00098_A15UsuarioId
               }
               , new Object[] {
               T00099_A15UsuarioId
               }
               , new Object[] {
               T000910_A15UsuarioId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000913_A190EstadoTicketUsuarioNombre
               }
               , new Object[] {
               T000914_A14TicketId
               }
               , new Object[] {
               T000915_A15UsuarioId
               }
            }
         );
         AV29Pgmname = "Usuario";
         Z191UsuarioSistema = AV27WebSession.Get("UsuarioConectado");
         A191UsuarioSistema = AV27WebSession.Get("UsuarioConectado");
         i191UsuarioSistema = AV27WebSession.Get("UsuarioConectado");
         Z189EstadoTicketUsuarioId = 1;
         N189EstadoTicketUsuarioId = 1;
         i189EstadoTicketUsuarioId = 1;
         A189EstadoTicketUsuarioId = 1;
         Z92UsuarioHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A92UsuarioHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         i92UsuarioHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         Z90UsuarioFecha = DateTimeUtil.Today( context);
         A90UsuarioFecha = DateTimeUtil.Today( context);
         i90UsuarioFecha = DateTimeUtil.Today( context);
      }

      private short wcpOAV7UsuarioId ;
      private short Z15UsuarioId ;
      private short Z189EstadoTicketUsuarioId ;
      private short N189EstadoTicketUsuarioId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV7UsuarioId ;
      private short A189EstadoTicketUsuarioId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A15UsuarioId ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV26Insert_EstadoTicketUsuarioId ;
      private short Gx_BScreen ;
      private short RcdFound10 ;
      private short GX_JID ;
      private short nIsDirty_10 ;
      private short i189EstadoTicketUsuarioId ;
      private int Z95UsuarioTelefono ;
      private int trnEnded ;
      private int edtUsuarioFecha_Enabled ;
      private int edtUsuarioHora_Enabled ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioEmail_Enabled ;
      private int A95UsuarioTelefono ;
      private int edtUsuarioTelefono_Enabled ;
      private int edtUsuarioGerencia_Enabled ;
      private int edtUsuarioDepartamento_Enabled ;
      private int edtUsuarioRequerimiento_Enabled ;
      private int edtEstadoTicketUsuarioId_Enabled ;
      private int imgprompt_189_Visible ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV30GXV1 ;
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
      private string edtUsuarioNombre_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divClmfecha_Internalname ;
      private string divTableclmfecha0_Internalname ;
      private string divK2btoolstable_attributecontainerusuariofecha_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioFecha_Jsonclick ;
      private string divTableclmfecha1_Internalname ;
      private string divK2btoolstable_attributecontainerusuariohora_Internalname ;
      private string edtUsuarioHora_Internalname ;
      private string edtUsuarioHora_Jsonclick ;
      private string divClmusuario_Internalname ;
      private string divTableclmusuario0_Internalname ;
      private string divK2btoolstable_attributecontainerusuarioid_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioId_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuarionombre_Internalname ;
      private string TempTags ;
      private string edtUsuarioNombre_Jsonclick ;
      private string edtUsuarioNombre_Class ;
      private string divTableclmusuario1_Internalname ;
      private string divK2btoolstable_attributecontainerusuarioemail_Internalname ;
      private string edtUsuarioEmail_Internalname ;
      private string edtUsuarioEmail_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuariotelefono_Internalname ;
      private string edtUsuarioTelefono_Internalname ;
      private string edtUsuarioTelefono_Jsonclick ;
      private string divClmgerencia_Internalname ;
      private string divTableclmgerencia0_Internalname ;
      private string divK2btoolstable_attributecontainerusuariogerencia_Internalname ;
      private string edtUsuarioGerencia_Internalname ;
      private string divTableclmgerencia1_Internalname ;
      private string divK2btoolstable_attributecontainerusuariodepartamento_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string divClmreq_Internalname ;
      private string divTableclmreq0_Internalname ;
      private string divK2btoolstable_attributecontainerusuariorequerimiento_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string divK2btoolstable_attributecontainerestadoticketusuarioid_Internalname ;
      private string edtEstadoTicketUsuarioId_Internalname ;
      private string edtEstadoTicketUsuarioId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_189_Internalname ;
      private string imgprompt_189_Link ;
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
      private string AV29Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode10 ;
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
      private string sCtrlAV7UsuarioId ;
      private DateTime Z92UsuarioHora ;
      private DateTime Z286UsuarioFechaHora ;
      private DateTime A92UsuarioHora ;
      private DateTime A286UsuarioFechaHora ;
      private DateTime i92UsuarioHora ;
      private DateTime Z90UsuarioFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime i90UsuarioFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n286UsuarioFechaHora ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
      private bool Gx_longc ;
      private string Z93UsuarioNombre ;
      private string Z91UsuarioGerencia ;
      private string Z88UsuarioDepartamento ;
      private string Z94UsuarioRequerimiento ;
      private string Z89UsuarioEmail ;
      private string Z191UsuarioSistema ;
      private string A93UsuarioNombre ;
      private string A89UsuarioEmail ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A191UsuarioSistema ;
      private string A190EstadoTicketUsuarioNombre ;
      private string AV18UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV16Url ;
      private string Z190EstadoTicketUsuarioNombre ;
      private string i191UsuarioSistema ;
      private IGxSession AV27WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private string[] T00094_A190EstadoTicketUsuarioNombre ;
      private short[] T00095_A15UsuarioId ;
      private string[] T00095_A93UsuarioNombre ;
      private DateTime[] T00095_A90UsuarioFecha ;
      private DateTime[] T00095_A92UsuarioHora ;
      private string[] T00095_A91UsuarioGerencia ;
      private string[] T00095_A88UsuarioDepartamento ;
      private string[] T00095_A94UsuarioRequerimiento ;
      private string[] T00095_A89UsuarioEmail ;
      private int[] T00095_A95UsuarioTelefono ;
      private string[] T00095_A190EstadoTicketUsuarioNombre ;
      private string[] T00095_A191UsuarioSistema ;
      private DateTime[] T00095_A286UsuarioFechaHora ;
      private bool[] T00095_n286UsuarioFechaHora ;
      private short[] T00095_A189EstadoTicketUsuarioId ;
      private string[] T00096_A190EstadoTicketUsuarioNombre ;
      private short[] T00097_A15UsuarioId ;
      private short[] T00093_A15UsuarioId ;
      private string[] T00093_A93UsuarioNombre ;
      private DateTime[] T00093_A90UsuarioFecha ;
      private DateTime[] T00093_A92UsuarioHora ;
      private string[] T00093_A91UsuarioGerencia ;
      private string[] T00093_A88UsuarioDepartamento ;
      private string[] T00093_A94UsuarioRequerimiento ;
      private string[] T00093_A89UsuarioEmail ;
      private int[] T00093_A95UsuarioTelefono ;
      private string[] T00093_A191UsuarioSistema ;
      private DateTime[] T00093_A286UsuarioFechaHora ;
      private bool[] T00093_n286UsuarioFechaHora ;
      private short[] T00093_A189EstadoTicketUsuarioId ;
      private short[] T00098_A15UsuarioId ;
      private short[] T00099_A15UsuarioId ;
      private short[] T00092_A15UsuarioId ;
      private string[] T00092_A93UsuarioNombre ;
      private DateTime[] T00092_A90UsuarioFecha ;
      private DateTime[] T00092_A92UsuarioHora ;
      private string[] T00092_A91UsuarioGerencia ;
      private string[] T00092_A88UsuarioDepartamento ;
      private string[] T00092_A94UsuarioRequerimiento ;
      private string[] T00092_A89UsuarioEmail ;
      private int[] T00092_A95UsuarioTelefono ;
      private string[] T00092_A191UsuarioSistema ;
      private DateTime[] T00092_A286UsuarioFechaHora ;
      private bool[] T00092_n286UsuarioFechaHora ;
      private short[] T00092_A189EstadoTicketUsuarioId ;
      private short[] T000910_A15UsuarioId ;
      private string[] T000913_A190EstadoTicketUsuarioNombre ;
      private long[] T000914_A14TicketId ;
      private short[] T000915_A15UsuarioId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV25HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV21AttributeValue ;
      private SdtK2BAttributeValue_Item AV22AttributeValueItem ;
      private SdtK2BContext AV13Context ;
      private GeneXus.Utils.SdtMessages_Message AV23Message ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
   }

   public class usuario__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class usuario__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class usuario__gam : DataStoreHelperBase, IDataStoreHelper
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

public class usuario__default : DataStoreHelperBase, IDataStoreHelper
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
       Object[] prmT00095;
       prmT00095 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00094;
       prmT00094 = new Object[] {
       new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00096;
       prmT00096 = new Object[] {
       new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00097;
       prmT00097 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00093;
       prmT00093 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00098;
       prmT00098 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00099;
       prmT00099 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00092;
       prmT00092 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000910;
       prmT000910 = new Object[] {
       new ParDef("@UsuarioNombre",GXType.NVarChar,60,0) ,
       new ParDef("@UsuarioFecha",GXType.Date,8,0) ,
       new ParDef("@UsuarioHora",GXType.DateTime,0,5) ,
       new ParDef("@UsuarioGerencia",GXType.NVarChar,300,0) ,
       new ParDef("@UsuarioDepartamento",GXType.NVarChar,300,0) ,
       new ParDef("@UsuarioRequerimiento",GXType.NVarChar,300,0) ,
       new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
       new ParDef("@UsuarioTelefono",GXType.Int32,9,0) ,
       new ParDef("@UsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@UsuarioFechaHora",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000911;
       prmT000911 = new Object[] {
       new ParDef("@UsuarioNombre",GXType.NVarChar,60,0) ,
       new ParDef("@UsuarioFecha",GXType.Date,8,0) ,
       new ParDef("@UsuarioHora",GXType.DateTime,0,5) ,
       new ParDef("@UsuarioGerencia",GXType.NVarChar,300,0) ,
       new ParDef("@UsuarioDepartamento",GXType.NVarChar,300,0) ,
       new ParDef("@UsuarioRequerimiento",GXType.NVarChar,300,0) ,
       new ParDef("@UsuarioEmail",GXType.NVarChar,100,0) ,
       new ParDef("@UsuarioTelefono",GXType.Int32,9,0) ,
       new ParDef("@UsuarioSistema",GXType.NVarChar,100,60) ,
       new ParDef("@UsuarioFechaHora",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0) ,
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000912;
       prmT000912 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000914;
       prmT000914 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000915;
       prmT000915 = new Object[] {
       };
       Object[] prmT000913;
       prmT000913 = new Object[] {
       new ParDef("@EstadoTicketUsuarioId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00092", "SELECT [UsuarioId], [UsuarioNombre], [UsuarioFecha], [UsuarioHora], [UsuarioGerencia], [UsuarioDepartamento], [UsuarioRequerimiento], [UsuarioEmail], [UsuarioTelefono], [UsuarioSistema], [UsuarioFechaHora], [EstadoTicketUsuarioId] AS EstadoTicketUsuarioId FROM [Usuario] WITH (UPDLOCK) WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00093", "SELECT [UsuarioId], [UsuarioNombre], [UsuarioFecha], [UsuarioHora], [UsuarioGerencia], [UsuarioDepartamento], [UsuarioRequerimiento], [UsuarioEmail], [UsuarioTelefono], [UsuarioSistema], [UsuarioFechaHora], [EstadoTicketUsuarioId] AS EstadoTicketUsuarioId FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00094", "SELECT [EstadoTicketNombre] AS EstadoTicketUsuarioNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00095", "SELECT TM1.[UsuarioId], TM1.[UsuarioNombre], TM1.[UsuarioFecha], TM1.[UsuarioHora], TM1.[UsuarioGerencia], TM1.[UsuarioDepartamento], TM1.[UsuarioRequerimiento], TM1.[UsuarioEmail], TM1.[UsuarioTelefono], T2.[EstadoTicketNombre] AS EstadoTicketUsuarioNombre, TM1.[UsuarioSistema], TM1.[UsuarioFechaHora], TM1.[EstadoTicketUsuarioId] AS EstadoTicketUsuarioId FROM ([Usuario] TM1 INNER JOIN [EstadoTicket] T2 ON T2.[EstadoTicketId] = TM1.[EstadoTicketUsuarioId]) WHERE TM1.[UsuarioId] = @UsuarioId ORDER BY TM1.[UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00096", "SELECT [EstadoTicketNombre] AS EstadoTicketUsuarioNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00097", "SELECT [UsuarioId] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00098", "SELECT TOP 1 [UsuarioId] FROM [Usuario] WHERE ( [UsuarioId] > @UsuarioId) ORDER BY [UsuarioId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T00099", "SELECT TOP 1 [UsuarioId] FROM [Usuario] WHERE ( [UsuarioId] < @UsuarioId) ORDER BY [UsuarioId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000910", "INSERT INTO [Usuario]([UsuarioNombre], [UsuarioFecha], [UsuarioHora], [UsuarioGerencia], [UsuarioDepartamento], [UsuarioRequerimiento], [UsuarioEmail], [UsuarioTelefono], [UsuarioSistema], [UsuarioFechaHora], [EstadoTicketUsuarioId]) VALUES(@UsuarioNombre, @UsuarioFecha, @UsuarioHora, @UsuarioGerencia, @UsuarioDepartamento, @UsuarioRequerimiento, @UsuarioEmail, @UsuarioTelefono, @UsuarioSistema, @UsuarioFechaHora, @EstadoTicketUsuarioId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000910)
          ,new CursorDef("T000911", "UPDATE [Usuario] SET [UsuarioNombre]=@UsuarioNombre, [UsuarioFecha]=@UsuarioFecha, [UsuarioHora]=@UsuarioHora, [UsuarioGerencia]=@UsuarioGerencia, [UsuarioDepartamento]=@UsuarioDepartamento, [UsuarioRequerimiento]=@UsuarioRequerimiento, [UsuarioEmail]=@UsuarioEmail, [UsuarioTelefono]=@UsuarioTelefono, [UsuarioSistema]=@UsuarioSistema, [UsuarioFechaHora]=@UsuarioFechaHora, [EstadoTicketUsuarioId]=@EstadoTicketUsuarioId  WHERE [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmT000911)
          ,new CursorDef("T000912", "DELETE FROM [Usuario]  WHERE [UsuarioId] = @UsuarioId", GxErrorMask.GX_NOMASK,prmT000912)
          ,new CursorDef("T000913", "SELECT [EstadoTicketNombre] AS EstadoTicketUsuarioNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketUsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000913,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000914", "SELECT TOP 1 [TicketId] FROM [Ticket] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000915", "SELECT [UsuarioId] FROM [Usuario] ORDER BY [UsuarioId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,100, GxCacheFrequency.OFF ,true,false )
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
             ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((int[]) buf[8])[0] = rslt.getInt(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
             ((bool[]) buf[11])[0] = rslt.wasNull(11);
             ((short[]) buf[12])[0] = rslt.getShort(12);
             return;
          case 1 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((int[]) buf[8])[0] = rslt.getInt(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
             ((bool[]) buf[11])[0] = rslt.wasNull(11);
             ((short[]) buf[12])[0] = rslt.getShort(12);
             return;
          case 2 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((int[]) buf[8])[0] = rslt.getInt(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((string[]) buf[10])[0] = rslt.getVarchar(11);
             ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
             ((bool[]) buf[12])[0] = rslt.wasNull(12);
             ((short[]) buf[13])[0] = rslt.getShort(13);
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
             return;
          case 13 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
    }
 }

}

}
