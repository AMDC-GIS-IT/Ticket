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
   public class tickettecnico : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7TicketTecnicoId = (long)(NumberUtil.Val( GetPar( "TicketTecnicoId"), "."));
               AssignAttri(sPrefix, false, "AV7TicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV7TicketTecnicoId), 10, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(long)AV7TicketTecnicoId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel13"+"_"+"") == 0 )
            {
               A15UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA93089( A15UsuarioId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
            {
               A14TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
               AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_24( A14TicketId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_29") == 0 )
            {
               A15UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_29( A15UsuarioId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_26") == 0 )
            {
               A14TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
               AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               A16TicketResponsableId = (long)(NumberUtil.Val( GetPar( "TicketResponsableId"), "."));
               AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_26( A14TicketId, A16TicketResponsableId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
            {
               A6ResponsableId = (short)(NumberUtil.Val( GetPar( "ResponsableId"), "."));
               AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_25( A6ResponsableId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
            {
               A171SgActividadId = (int)(NumberUtil.Val( GetPar( "SgActividadId"), "."));
               AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_27( A171SgActividadId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_28") == 0 )
            {
               A173SgActividadIdCategoria = (int)(NumberUtil.Val( GetPar( "SgActividadIdCategoria"), "."));
               AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_28( A173SgActividadIdCategoria) ;
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
                  AV7TicketTecnicoId = (long)(NumberUtil.Val( GetPar( "TicketTecnicoId"), "."));
                  AssignAttri(sPrefix, false, "AV7TicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV7TicketTecnicoId), 10, 0));
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
               Form.Meta.addItem("description", "Ticket Tecnico", 0) ;
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
            GX_FocusControl = edtTicketResponsableId_Internalname;
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

      public tickettecnico( )
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

      public tickettecnico( IGxContext context )
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
                           long aP1_TicketTecnicoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TicketTecnicoId = aP1_TicketTecnicoId;
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
         chkTicketTecnicoInstalacion = new GXCheckbox();
         chkTicketTecnicoConfiguracion = new GXCheckbox();
         chkTicketTecnicoInternetRouter = new GXCheckbox();
         chkTicketTecnicoFormateo = new GXCheckbox();
         chkTicketTecnicoReparacion = new GXCheckbox();
         chkTicketTecnicoLimpieza = new GXCheckbox();
         chkTicketTecnicoPuntoRed = new GXCheckbox();
         chkTicketTecnicoCambiosHardware = new GXCheckbox();
         chkTicketTecnicoCopiasRespaldo = new GXCheckbox();
         chkTicketTecnicoCerrado = new GXCheckbox();
         chkTicketTecnicoPendiente = new GXCheckbox();
         chkTicketTecnicoPasaTaller = new GXCheckbox();
         chkTicketTecnicoObservacion = new GXCheckbox();
         chkTicketTecnicoRam = new GXCheckbox();
         chkTicketTecnicoDiscoDuro = new GXCheckbox();
         chkTicketTecnicoProcesador = new GXCheckbox();
         chkTicketTecnicoMaletin = new GXCheckbox();
         chkTicketTecnicoTonerCinta = new GXCheckbox();
         chkTicketTecnicoTarjetaVideoExtra = new GXCheckbox();
         chkTicketTecnicoCargadorLaptop = new GXCheckbox();
         chkTicketTecnicoCDsDVDs = new GXCheckbox();
         chkTicketTecnicoCableEspecial = new GXCheckbox();
         chkTicketTecnicoOtrosTaller = new GXCheckbox();
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
            return "tickettecnico_Execute" ;
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
         A72TicketTecnicoInstalacion = StringUtil.StrToBool( StringUtil.BoolToStr( A72TicketTecnicoInstalacion));
         AssignAttri(sPrefix, false, "A72TicketTecnicoInstalacion", A72TicketTecnicoInstalacion);
         A66TicketTecnicoConfiguracion = StringUtil.StrToBool( StringUtil.BoolToStr( A66TicketTecnicoConfiguracion));
         AssignAttri(sPrefix, false, "A66TicketTecnicoConfiguracion", A66TicketTecnicoConfiguracion);
         A73TicketTecnicoInternetRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A73TicketTecnicoInternetRouter));
         AssignAttri(sPrefix, false, "A73TicketTecnicoInternetRouter", A73TicketTecnicoInternetRouter);
         A70TicketTecnicoFormateo = StringUtil.StrToBool( StringUtil.BoolToStr( A70TicketTecnicoFormateo));
         AssignAttri(sPrefix, false, "A70TicketTecnicoFormateo", A70TicketTecnicoFormateo);
         A84TicketTecnicoReparacion = StringUtil.StrToBool( StringUtil.BoolToStr( A84TicketTecnicoReparacion));
         AssignAttri(sPrefix, false, "A84TicketTecnicoReparacion", A84TicketTecnicoReparacion);
         A75TicketTecnicoLimpieza = StringUtil.StrToBool( StringUtil.BoolToStr( A75TicketTecnicoLimpieza));
         AssignAttri(sPrefix, false, "A75TicketTecnicoLimpieza", A75TicketTecnicoLimpieza);
         A82TicketTecnicoPuntoRed = StringUtil.StrToBool( StringUtil.BoolToStr( A82TicketTecnicoPuntoRed));
         AssignAttri(sPrefix, false, "A82TicketTecnicoPuntoRed", A82TicketTecnicoPuntoRed);
         A62TicketTecnicoCambiosHardware = StringUtil.StrToBool( StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware));
         AssignAttri(sPrefix, false, "A62TicketTecnicoCambiosHardware", A62TicketTecnicoCambiosHardware);
         A67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo));
         AssignAttri(sPrefix, false, "A67TicketTecnicoCopiasRespaldo", A67TicketTecnicoCopiasRespaldo);
         A65TicketTecnicoCerrado = StringUtil.StrToBool( StringUtil.BoolToStr( A65TicketTecnicoCerrado));
         AssignAttri(sPrefix, false, "A65TicketTecnicoCerrado", A65TicketTecnicoCerrado);
         A80TicketTecnicoPendiente = StringUtil.StrToBool( StringUtil.BoolToStr( A80TicketTecnicoPendiente));
         AssignAttri(sPrefix, false, "A80TicketTecnicoPendiente", A80TicketTecnicoPendiente);
         A79TicketTecnicoPasaTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A79TicketTecnicoPasaTaller));
         AssignAttri(sPrefix, false, "A79TicketTecnicoPasaTaller", A79TicketTecnicoPasaTaller);
         A77TicketTecnicoObservacion = StringUtil.StrToBool( StringUtil.BoolToStr( A77TicketTecnicoObservacion));
         n77TicketTecnicoObservacion = false;
         AssignAttri(sPrefix, false, "A77TicketTecnicoObservacion", A77TicketTecnicoObservacion);
         A83TicketTecnicoRam = StringUtil.StrToBool( StringUtil.BoolToStr( A83TicketTecnicoRam));
         AssignAttri(sPrefix, false, "A83TicketTecnicoRam", A83TicketTecnicoRam);
         A68TicketTecnicoDiscoDuro = StringUtil.StrToBool( StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro));
         AssignAttri(sPrefix, false, "A68TicketTecnicoDiscoDuro", A68TicketTecnicoDiscoDuro);
         A81TicketTecnicoProcesador = StringUtil.StrToBool( StringUtil.BoolToStr( A81TicketTecnicoProcesador));
         AssignAttri(sPrefix, false, "A81TicketTecnicoProcesador", A81TicketTecnicoProcesador);
         A76TicketTecnicoMaletin = StringUtil.StrToBool( StringUtil.BoolToStr( A76TicketTecnicoMaletin));
         AssignAttri(sPrefix, false, "A76TicketTecnicoMaletin", A76TicketTecnicoMaletin);
         A86TicketTecnicoTonerCinta = StringUtil.StrToBool( StringUtil.BoolToStr( A86TicketTecnicoTonerCinta));
         AssignAttri(sPrefix, false, "A86TicketTecnicoTonerCinta", A86TicketTecnicoTonerCinta);
         A85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra));
         AssignAttri(sPrefix, false, "A85TicketTecnicoTarjetaVideoExtra", A85TicketTecnicoTarjetaVideoExtra);
         A63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop));
         AssignAttri(sPrefix, false, "A63TicketTecnicoCargadorLaptop", A63TicketTecnicoCargadorLaptop);
         A64TicketTecnicoCDsDVDs = StringUtil.StrToBool( StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs));
         AssignAttri(sPrefix, false, "A64TicketTecnicoCDsDVDs", A64TicketTecnicoCDsDVDs);
         A61TicketTecnicoCableEspecial = StringUtil.StrToBool( StringUtil.BoolToStr( A61TicketTecnicoCableEspecial));
         AssignAttri(sPrefix, false, "A61TicketTecnicoCableEspecial", A61TicketTecnicoCableEspecial);
         A78TicketTecnicoOtrosTaller = StringUtil.StrToBool( StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller));
         AssignAttri(sPrefix, false, "A78TicketTecnicoOtrosTaller", A78TicketTecnicoOtrosTaller);
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
            RenderHtmlCloseForm089( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "tickettecnico.aspx");
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
         GxWebStd.gx_div_start( context, divTabletextblocktxttrabajocontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxttrabajo_Internalname, "Trabajo Técnico Realizado", "", "", lblTxttrabajo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_TicketTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmid_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmid0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoId_Internalname, "Ticket Tecnico", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
         GxWebStd.gx_single_line_edit( context, edtTicketTecnicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A18TicketTecnicoId), 10, 0, ",", "")), ((edtTicketTecnicoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A18TicketTecnicoId), "ZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketTecnicoId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketresponsableid_Internalname, divK2btoolstable_attributecontainerticketresponsableid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketResponsableId_Internalname, "Ticket Responsable Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketResponsableId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketResponsableId_Enabled, 1, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TicketTecnico.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_16_Internalname, sImgUrl, imgprompt_16_Link, "", "", context.GetTheme( ), imgprompt_16_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divTableclmid1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketId_Internalname, "Id Ticket", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketId_Enabled, 1, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_TicketTecnico.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicofecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoFecha_Internalname, "Fecha", "gx-form-item Attribute_TrnDateLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
         context.WriteHtmlText( "<div id=\""+edtTicketTecnicoFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTicketTecnicoFecha_Internalname, context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"), context.localUtil.Format( A69TicketTecnicoFecha, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoFecha_Jsonclick, 0, edtTicketTecnicoFecha_Class, "", "", "", "", 1, edtTicketTecnicoFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_TicketTecnico.htm");
         GxWebStd.gx_bitmap( context, edtTicketTecnicoFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTicketTecnicoFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicohora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoHora_Internalname, "Hora", "gx-form-item Attribute_TrnDateTimeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
         context.WriteHtmlText( "<div id=\""+edtTicketTecnicoHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTicketTecnicoHora_Internalname, context.localUtil.TToC( A71TicketTecnicoHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A71TicketTecnicoHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoHora_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", 1, edtTicketTecnicoHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Hora", "right", false, "", "HLP_TicketTecnico.htm");
         GxWebStd.gx_bitmap( context, edtTicketTecnicoHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTicketTecnicoHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divClmtecnico_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmtecnico0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsablenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableNombre_Internalname, "Técnico", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
         GxWebStd.gx_single_line_edit( context, edtResponsableNombre_Internalname, A30ResponsableNombre, StringUtil.RTrim( context.localUtil.Format( A30ResponsableNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtResponsableNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, "Usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, A93UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtUsuarioNombre_Link, "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerresponsableid_Internalname, divK2btoolstable_attributecontainerresponsableid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtResponsableId_Internalname, "Técnico Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6ResponsableId), 4, 0, ",", "")), ((edtResponsableId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9")) : context.localUtil.Format( (decimal)(A6ResponsableId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,86);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtResponsableId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtResponsableId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_TicketTecnico.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_6_Internalname, sImgUrl, imgprompt_6_Link, "", "", context.GetTheme( ), imgprompt_6_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divTableclmtecnico1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuariodepartamento_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioDepartamento_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioDepartamento_Internalname, "Departamento", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioDepartamento_Internalname, A88UsuarioDepartamento, "", "", 0, 1, edtUsuarioDepartamento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarioid_Internalname, divK2btoolstable_attributecontainerusuarioid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, "Id Usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ",", "")), ((edtUsuarioId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")) : context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
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
         GxWebStd.gx_label_element( context, edtUsuarioRequerimiento_Internalname, "Requerimiento", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtUsuarioRequerimiento_Internalname, A94UsuarioRequerimiento, "", "", 0, 1, edtUsuarioRequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divTableclmreq1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoinventarioserie_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoInventarioSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoInventarioSerie_Internalname, "Serie", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A74TicketTecnicoInventarioSerie", A74TicketTecnicoInventarioSerie);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTicketTecnicoInventarioSerie_Internalname, A74TicketTecnicoInventarioSerie, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,120);\"", 0, 1, edtTicketTecnicoInventarioSerie_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divTabletextblocktxtaccionescontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtacciones_Internalname, "Acciones Realizadas", "", "", lblTxtacciones_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_TicketTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmacciones_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmacciones0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoinstalacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoInstalacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoInstalacion_Internalname, "Instalación", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A72TicketTecnicoInstalacion", A72TicketTecnicoInstalacion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoInstalacion_Internalname, StringUtil.BoolToStr( A72TicketTecnicoInstalacion), "", "Instalación", 1, chkTicketTecnicoInstalacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(136, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,136);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoconfiguracion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoConfiguracion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoConfiguracion_Internalname, "Configuración", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A66TicketTecnicoConfiguracion", A66TicketTecnicoConfiguracion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoConfiguracion_Internalname, StringUtil.BoolToStr( A66TicketTecnicoConfiguracion), "", "Configuración", 1, chkTicketTecnicoConfiguracion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(142, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,142);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicointernetrouter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoInternetRouter_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoInternetRouter_Internalname, "Internet/Router", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A73TicketTecnicoInternetRouter", A73TicketTecnicoInternetRouter);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoInternetRouter_Internalname, StringUtil.BoolToStr( A73TicketTecnicoInternetRouter), "", "Internet/Router", 1, chkTicketTecnicoInternetRouter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(148, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,148);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmacciones1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoformateo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoFormateo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoFormateo_Internalname, "Formateo", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A70TicketTecnicoFormateo", A70TicketTecnicoFormateo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoFormateo_Internalname, StringUtil.BoolToStr( A70TicketTecnicoFormateo), "", "Formateo", 1, chkTicketTecnicoFormateo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(156, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,156);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoreparacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoReparacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoReparacion_Internalname, "Reparación", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A84TicketTecnicoReparacion", A84TicketTecnicoReparacion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoReparacion_Internalname, StringUtil.BoolToStr( A84TicketTecnicoReparacion), "", "Reparación", 1, chkTicketTecnicoReparacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(162, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,162);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicolimpieza_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoLimpieza_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoLimpieza_Internalname, "Limpieza/Mantenimiento", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A75TicketTecnicoLimpieza", A75TicketTecnicoLimpieza);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoLimpieza_Internalname, StringUtil.BoolToStr( A75TicketTecnicoLimpieza), "", "Limpieza/Mantenimiento", 1, chkTicketTecnicoLimpieza.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(168, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,168);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmacciones2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicopuntored_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoPuntoRed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoPuntoRed_Internalname, "Nuevo Punto de Red", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A82TicketTecnicoPuntoRed", A82TicketTecnicoPuntoRed);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoPuntoRed_Internalname, StringUtil.BoolToStr( A82TicketTecnicoPuntoRed), "", "Nuevo Punto de Red", 1, chkTicketTecnicoPuntoRed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(176, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,176);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicocambioshardware_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoCambiosHardware_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoCambiosHardware_Internalname, "Cambios de Hardware", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A62TicketTecnicoCambiosHardware", A62TicketTecnicoCambiosHardware);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 182,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoCambiosHardware_Internalname, StringUtil.BoolToStr( A62TicketTecnicoCambiosHardware), "", "Cambios de Hardware", 1, chkTicketTecnicoCambiosHardware.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(182, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,182);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicocopiasrespaldo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoCopiasRespaldo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoCopiasRespaldo_Internalname, "Copias de Respaldo", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A67TicketTecnicoCopiasRespaldo", A67TicketTecnicoCopiasRespaldo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 188,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoCopiasRespaldo_Internalname, StringUtil.BoolToStr( A67TicketTecnicoCopiasRespaldo), "", "Copias de Respaldo", 1, chkTicketTecnicoCopiasRespaldo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(188, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,188);\"");
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
         GxWebStd.gx_div_start( context, divTabletextblocktxtestadocontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtestado_Internalname, "Estado de Atención del Requerimiento", "", "", lblTxtestado_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_TicketTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmestado_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmestado0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicocerrado_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoCerrado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoCerrado_Internalname, "Cerrado", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A65TicketTecnicoCerrado", A65TicketTecnicoCerrado);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoCerrado_Internalname, StringUtil.BoolToStr( A65TicketTecnicoCerrado), "", "Cerrado", 1, chkTicketTecnicoCerrado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(204, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,204);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicopendiente_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoPendiente_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoPendiente_Internalname, "Pendiente", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A80TicketTecnicoPendiente", A80TicketTecnicoPendiente);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoPendiente_Internalname, StringUtil.BoolToStr( A80TicketTecnicoPendiente), "", "Pendiente", 1, chkTicketTecnicoPendiente.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(210, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,210);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicopasataller_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoPasaTaller_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoPasaTaller_Internalname, "Pasa al Taller", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A79TicketTecnicoPasaTaller", A79TicketTecnicoPasaTaller);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoPasaTaller_Internalname, StringUtil.BoolToStr( A79TicketTecnicoPasaTaller), "", "Pasa al Taller", 1, chkTicketTecnicoPasaTaller.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(216, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,216);\"");
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
         GxWebStd.gx_div_start( context, divTableclmestado1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoobservacion_Internalname, divK2btoolstable_attributecontainertickettecnicoobservacion_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoObservacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoObservacion_Internalname, "Observación", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A77TicketTecnicoObservacion", A77TicketTecnicoObservacion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoObservacion_Internalname, StringUtil.BoolToStr( A77TicketTecnicoObservacion), "", "Observación", 1, chkTicketTecnicoObservacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(224, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,224);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicodetalle_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoDetalle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoDetalle_Internalname, "Observación", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A97TicketTecnicoDetalle", A97TicketTecnicoDetalle);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtTicketTecnicoDetalle_Internalname, A97TicketTecnicoDetalle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,230);\"", 0, 1, edtTicketTecnicoDetalle_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divTabletextblocktxttallercontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxttaller_Internalname, "En caso de llevar al Taller de Soporte Técnico, confirmar las especificaciones del equipo:", "", "", lblTxttaller_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_TicketTecnico.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divClmtaller_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmtaller0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoram_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoRam_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoRam_Internalname, "RAM", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A83TicketTecnicoRam", A83TicketTecnicoRam);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoRam_Internalname, StringUtil.BoolToStr( A83TicketTecnicoRam), "", "RAM", 1, chkTicketTecnicoRam.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(246, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,246);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicodiscoduro_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoDiscoDuro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoDiscoDuro_Internalname, "Disco Duro", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A68TicketTecnicoDiscoDuro", A68TicketTecnicoDiscoDuro);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 252,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoDiscoDuro_Internalname, StringUtil.BoolToStr( A68TicketTecnicoDiscoDuro), "", "Disco Duro", 1, chkTicketTecnicoDiscoDuro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(252, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,252);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoprocesador_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoProcesador_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoProcesador_Internalname, "Procesador", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A81TicketTecnicoProcesador", A81TicketTecnicoProcesador);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 258,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoProcesador_Internalname, StringUtil.BoolToStr( A81TicketTecnicoProcesador), "", "Procesador", 1, chkTicketTecnicoProcesador.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(258, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,258);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicomaletin_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoMaletin_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoMaletin_Internalname, "Maletin", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A76TicketTecnicoMaletin", A76TicketTecnicoMaletin);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 264,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoMaletin_Internalname, StringUtil.BoolToStr( A76TicketTecnicoMaletin), "", "Maletin", 1, chkTicketTecnicoMaletin.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(264, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,264);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicotonercinta_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoTonerCinta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoTonerCinta_Internalname, "Toner/Cinta", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A86TicketTecnicoTonerCinta", A86TicketTecnicoTonerCinta);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 270,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoTonerCinta_Internalname, StringUtil.BoolToStr( A86TicketTecnicoTonerCinta), "", "Toner/Cinta", 1, chkTicketTecnicoTonerCinta.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(270, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,270);\"");
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
         GxWebStd.gx_div_start( context, divTableclmtaller1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicotarjetavideoextra_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoTarjetaVideoExtra_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoTarjetaVideoExtra_Internalname, "Tarjeta de Video Extra", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A85TicketTecnicoTarjetaVideoExtra", A85TicketTecnicoTarjetaVideoExtra);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 278,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoTarjetaVideoExtra_Internalname, StringUtil.BoolToStr( A85TicketTecnicoTarjetaVideoExtra), "", "Tarjeta de Video Extra", 1, chkTicketTecnicoTarjetaVideoExtra.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(278, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,278);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicocargadorlaptop_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoCargadorLaptop_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoCargadorLaptop_Internalname, "Cargador para Laptop", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A63TicketTecnicoCargadorLaptop", A63TicketTecnicoCargadorLaptop);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 284,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoCargadorLaptop_Internalname, StringUtil.BoolToStr( A63TicketTecnicoCargadorLaptop), "", "Cargador para Laptop", 1, chkTicketTecnicoCargadorLaptop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(284, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,284);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicocdsdvds_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoCDsDVDs_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoCDsDVDs_Internalname, "CDs/DVDs", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A64TicketTecnicoCDsDVDs", A64TicketTecnicoCDsDVDs);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 290,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoCDsDVDs_Internalname, StringUtil.BoolToStr( A64TicketTecnicoCDsDVDs), "", "CDs/DVDs", 1, chkTicketTecnicoCDsDVDs.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(290, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,290);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicocableespecial_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoCableEspecial_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoCableEspecial_Internalname, "Cable Especial", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A61TicketTecnicoCableEspecial", A61TicketTecnicoCableEspecial);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 296,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoCableEspecial_Internalname, StringUtil.BoolToStr( A61TicketTecnicoCableEspecial), "", "Cable Especial", 1, chkTicketTecnicoCableEspecial.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(296, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,296);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicootrostaller_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketTecnicoOtrosTaller_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketTecnicoOtrosTaller_Internalname, "Otros", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A78TicketTecnicoOtrosTaller", A78TicketTecnicoOtrosTaller);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 302,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketTecnicoOtrosTaller_Internalname, StringUtil.BoolToStr( A78TicketTecnicoOtrosTaller), "", "Otros", 1, chkTicketTecnicoOtrosTaller.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(302, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,302);\"");
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
         GxWebStd.gx_div_start( context, divClcat_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclcat0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgactividadidcategoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgActividadIdCategoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgActividadIdCategoria_Internalname, "Sg Actividad Id Categoria", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 314,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSgActividadIdCategoria_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A173SgActividadIdCategoria), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A173SgActividadIdCategoria), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,314);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSgActividadIdCategoria_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSgActividadIdCategoria_Enabled, 1, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TicketTecnico.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_173_Internalname, sImgUrl, imgprompt_173_Link, "", "", context.GetTheme( ), imgprompt_173_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgactividadnombrecategoria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgActividadNombreCategoria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgActividadNombreCategoria_Internalname, "Sg Actividad Nombre Categoria", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSgActividadNombreCategoria_Internalname, A174SgActividadNombreCategoria, "", "", 0, 1, edtSgActividadNombreCategoria_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_div_start( context, divTableclcat1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersgactividadid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSgActividadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSgActividadId_Internalname, "Sg Actividad Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 328,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSgActividadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A171SgActividadId), 9, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A171SgActividadId), "ZZZZZZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,328);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSgActividadId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSgActividadId_Enabled, 1, "number", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TicketTecnico.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_171_Internalname, sImgUrl, imgprompt_171_Link, "", "", context.GetTheme( ), imgprompt_171_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_TicketTecnico.htm");
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
         GxWebStd.gx_label_element( context, edtSgActividadNombre_Internalname, "Sg Actividad Nombre", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSgActividadNombre_Internalname, A172SgActividadNombre, "", "", 0, 1, edtSgActividadNombre_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_TicketTecnico.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 340,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TicketTecnico.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 342,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_TicketTecnico.htm");
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
         E11082 ();
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
               Z18TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z18TicketTecnicoId"), ",", "."));
               Z69TicketTecnicoFecha = context.localUtil.CToD( cgiGet( sPrefix+"Z69TicketTecnicoFecha"), 0);
               Z71TicketTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+"Z71TicketTecnicoHora"), 0));
               Z74TicketTecnicoInventarioSerie = cgiGet( sPrefix+"Z74TicketTecnicoInventarioSerie");
               Z72TicketTecnicoInstalacion = StringUtil.StrToBool( cgiGet( sPrefix+"Z72TicketTecnicoInstalacion"));
               Z66TicketTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( sPrefix+"Z66TicketTecnicoConfiguracion"));
               Z73TicketTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( sPrefix+"Z73TicketTecnicoInternetRouter"));
               Z70TicketTecnicoFormateo = StringUtil.StrToBool( cgiGet( sPrefix+"Z70TicketTecnicoFormateo"));
               Z84TicketTecnicoReparacion = StringUtil.StrToBool( cgiGet( sPrefix+"Z84TicketTecnicoReparacion"));
               Z75TicketTecnicoLimpieza = StringUtil.StrToBool( cgiGet( sPrefix+"Z75TicketTecnicoLimpieza"));
               Z82TicketTecnicoPuntoRed = StringUtil.StrToBool( cgiGet( sPrefix+"Z82TicketTecnicoPuntoRed"));
               Z62TicketTecnicoCambiosHardware = StringUtil.StrToBool( cgiGet( sPrefix+"Z62TicketTecnicoCambiosHardware"));
               Z67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( cgiGet( sPrefix+"Z67TicketTecnicoCopiasRespaldo"));
               Z83TicketTecnicoRam = StringUtil.StrToBool( cgiGet( sPrefix+"Z83TicketTecnicoRam"));
               Z68TicketTecnicoDiscoDuro = StringUtil.StrToBool( cgiGet( sPrefix+"Z68TicketTecnicoDiscoDuro"));
               Z81TicketTecnicoProcesador = StringUtil.StrToBool( cgiGet( sPrefix+"Z81TicketTecnicoProcesador"));
               Z76TicketTecnicoMaletin = StringUtil.StrToBool( cgiGet( sPrefix+"Z76TicketTecnicoMaletin"));
               Z86TicketTecnicoTonerCinta = StringUtil.StrToBool( cgiGet( sPrefix+"Z86TicketTecnicoTonerCinta"));
               Z85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( cgiGet( sPrefix+"Z85TicketTecnicoTarjetaVideoExtra"));
               Z63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( cgiGet( sPrefix+"Z63TicketTecnicoCargadorLaptop"));
               Z64TicketTecnicoCDsDVDs = StringUtil.StrToBool( cgiGet( sPrefix+"Z64TicketTecnicoCDsDVDs"));
               Z61TicketTecnicoCableEspecial = StringUtil.StrToBool( cgiGet( sPrefix+"Z61TicketTecnicoCableEspecial"));
               Z78TicketTecnicoOtrosTaller = StringUtil.StrToBool( cgiGet( sPrefix+"Z78TicketTecnicoOtrosTaller"));
               Z65TicketTecnicoCerrado = StringUtil.StrToBool( cgiGet( sPrefix+"Z65TicketTecnicoCerrado"));
               Z80TicketTecnicoPendiente = StringUtil.StrToBool( cgiGet( sPrefix+"Z80TicketTecnicoPendiente"));
               Z79TicketTecnicoPasaTaller = StringUtil.StrToBool( cgiGet( sPrefix+"Z79TicketTecnicoPasaTaller"));
               Z77TicketTecnicoObservacion = StringUtil.StrToBool( cgiGet( sPrefix+"Z77TicketTecnicoObservacion"));
               n77TicketTecnicoObservacion = ((false==A77TicketTecnicoObservacion) ? true : false);
               Z97TicketTecnicoDetalle = cgiGet( sPrefix+"Z97TicketTecnicoDetalle");
               Z14TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z14TicketId"), ",", "."));
               Z6ResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z6ResponsableId"), ",", "."));
               Z16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z16TicketResponsableId"), ",", "."));
               Z171SgActividadId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z171SgActividadId"), ",", "."));
               Z173SgActividadIdCategoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"Z173SgActividadIdCategoria"), ",", "."));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7TicketTecnicoId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N14TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"N14TicketId"), ",", "."));
               N16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"N16TicketResponsableId"), ",", "."));
               N171SgActividadId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N171SgActividadId"), ",", "."));
               N173SgActividadIdCategoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"N173SgActividadIdCategoria"), ",", "."));
               AV7TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vTICKETTECNICOID"), ",", "."));
               AV12Insert_TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_TICKETID"), ",", "."));
               AV13Insert_TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_TICKETRESPONSABLEID"), ",", "."));
               AV31Insert_SgActividadId = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SGACTIVIDADID"), ",", "."));
               AV32Insert_SgActividadIdCategoria = (int)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SGACTIVIDADIDCATEGORIA"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."));
               AV34Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               A18TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( edtTicketTecnicoId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TICKETRESPONSABLEID");
                  AnyError = 1;
                  GX_FocusControl = edtTicketResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A16TicketResponsableId = 0;
                  AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
               }
               else
               {
                  A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TICKETID");
                  AnyError = 1;
                  GX_FocusControl = edtTicketId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A14TicketId = 0;
                  AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               }
               else
               {
                  A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               }
               A69TicketTecnicoFecha = context.localUtil.CToD( cgiGet( edtTicketTecnicoFecha_Internalname), 2);
               AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
               A71TicketTecnicoHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketTecnicoHora_Internalname)));
               AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
               A30ResponsableNombre = cgiGet( edtResponsableNombre_Internalname);
               AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
               A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
               AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "RESPONSABLEID");
                  AnyError = 1;
                  GX_FocusControl = edtResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6ResponsableId = 0;
                  AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
               }
               else
               {
                  A6ResponsableId = (short)(context.localUtil.CToN( cgiGet( edtResponsableId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
               }
               A88UsuarioDepartamento = cgiGet( edtUsuarioDepartamento_Internalname);
               AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
               A15UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
               AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
               A74TicketTecnicoInventarioSerie = cgiGet( edtTicketTecnicoInventarioSerie_Internalname);
               AssignAttri(sPrefix, false, "A74TicketTecnicoInventarioSerie", A74TicketTecnicoInventarioSerie);
               A72TicketTecnicoInstalacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoInstalacion_Internalname));
               AssignAttri(sPrefix, false, "A72TicketTecnicoInstalacion", A72TicketTecnicoInstalacion);
               A66TicketTecnicoConfiguracion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoConfiguracion_Internalname));
               AssignAttri(sPrefix, false, "A66TicketTecnicoConfiguracion", A66TicketTecnicoConfiguracion);
               A73TicketTecnicoInternetRouter = StringUtil.StrToBool( cgiGet( chkTicketTecnicoInternetRouter_Internalname));
               AssignAttri(sPrefix, false, "A73TicketTecnicoInternetRouter", A73TicketTecnicoInternetRouter);
               A70TicketTecnicoFormateo = StringUtil.StrToBool( cgiGet( chkTicketTecnicoFormateo_Internalname));
               AssignAttri(sPrefix, false, "A70TicketTecnicoFormateo", A70TicketTecnicoFormateo);
               A84TicketTecnicoReparacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoReparacion_Internalname));
               AssignAttri(sPrefix, false, "A84TicketTecnicoReparacion", A84TicketTecnicoReparacion);
               A75TicketTecnicoLimpieza = StringUtil.StrToBool( cgiGet( chkTicketTecnicoLimpieza_Internalname));
               AssignAttri(sPrefix, false, "A75TicketTecnicoLimpieza", A75TicketTecnicoLimpieza);
               A82TicketTecnicoPuntoRed = StringUtil.StrToBool( cgiGet( chkTicketTecnicoPuntoRed_Internalname));
               AssignAttri(sPrefix, false, "A82TicketTecnicoPuntoRed", A82TicketTecnicoPuntoRed);
               A62TicketTecnicoCambiosHardware = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCambiosHardware_Internalname));
               AssignAttri(sPrefix, false, "A62TicketTecnicoCambiosHardware", A62TicketTecnicoCambiosHardware);
               A67TicketTecnicoCopiasRespaldo = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCopiasRespaldo_Internalname));
               AssignAttri(sPrefix, false, "A67TicketTecnicoCopiasRespaldo", A67TicketTecnicoCopiasRespaldo);
               A65TicketTecnicoCerrado = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCerrado_Internalname));
               AssignAttri(sPrefix, false, "A65TicketTecnicoCerrado", A65TicketTecnicoCerrado);
               A80TicketTecnicoPendiente = StringUtil.StrToBool( cgiGet( chkTicketTecnicoPendiente_Internalname));
               AssignAttri(sPrefix, false, "A80TicketTecnicoPendiente", A80TicketTecnicoPendiente);
               A79TicketTecnicoPasaTaller = StringUtil.StrToBool( cgiGet( chkTicketTecnicoPasaTaller_Internalname));
               AssignAttri(sPrefix, false, "A79TicketTecnicoPasaTaller", A79TicketTecnicoPasaTaller);
               A77TicketTecnicoObservacion = StringUtil.StrToBool( cgiGet( chkTicketTecnicoObservacion_Internalname));
               n77TicketTecnicoObservacion = false;
               AssignAttri(sPrefix, false, "A77TicketTecnicoObservacion", A77TicketTecnicoObservacion);
               n77TicketTecnicoObservacion = ((false==A77TicketTecnicoObservacion) ? true : false);
               A97TicketTecnicoDetalle = cgiGet( edtTicketTecnicoDetalle_Internalname);
               AssignAttri(sPrefix, false, "A97TicketTecnicoDetalle", A97TicketTecnicoDetalle);
               A83TicketTecnicoRam = StringUtil.StrToBool( cgiGet( chkTicketTecnicoRam_Internalname));
               AssignAttri(sPrefix, false, "A83TicketTecnicoRam", A83TicketTecnicoRam);
               A68TicketTecnicoDiscoDuro = StringUtil.StrToBool( cgiGet( chkTicketTecnicoDiscoDuro_Internalname));
               AssignAttri(sPrefix, false, "A68TicketTecnicoDiscoDuro", A68TicketTecnicoDiscoDuro);
               A81TicketTecnicoProcesador = StringUtil.StrToBool( cgiGet( chkTicketTecnicoProcesador_Internalname));
               AssignAttri(sPrefix, false, "A81TicketTecnicoProcesador", A81TicketTecnicoProcesador);
               A76TicketTecnicoMaletin = StringUtil.StrToBool( cgiGet( chkTicketTecnicoMaletin_Internalname));
               AssignAttri(sPrefix, false, "A76TicketTecnicoMaletin", A76TicketTecnicoMaletin);
               A86TicketTecnicoTonerCinta = StringUtil.StrToBool( cgiGet( chkTicketTecnicoTonerCinta_Internalname));
               AssignAttri(sPrefix, false, "A86TicketTecnicoTonerCinta", A86TicketTecnicoTonerCinta);
               A85TicketTecnicoTarjetaVideoExtra = StringUtil.StrToBool( cgiGet( chkTicketTecnicoTarjetaVideoExtra_Internalname));
               AssignAttri(sPrefix, false, "A85TicketTecnicoTarjetaVideoExtra", A85TicketTecnicoTarjetaVideoExtra);
               A63TicketTecnicoCargadorLaptop = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCargadorLaptop_Internalname));
               AssignAttri(sPrefix, false, "A63TicketTecnicoCargadorLaptop", A63TicketTecnicoCargadorLaptop);
               A64TicketTecnicoCDsDVDs = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCDsDVDs_Internalname));
               AssignAttri(sPrefix, false, "A64TicketTecnicoCDsDVDs", A64TicketTecnicoCDsDVDs);
               A61TicketTecnicoCableEspecial = StringUtil.StrToBool( cgiGet( chkTicketTecnicoCableEspecial_Internalname));
               AssignAttri(sPrefix, false, "A61TicketTecnicoCableEspecial", A61TicketTecnicoCableEspecial);
               A78TicketTecnicoOtrosTaller = StringUtil.StrToBool( cgiGet( chkTicketTecnicoOtrosTaller_Internalname));
               AssignAttri(sPrefix, false, "A78TicketTecnicoOtrosTaller", A78TicketTecnicoOtrosTaller);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSgActividadIdCategoria_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSgActividadIdCategoria_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGACTIVIDADIDCATEGORIA");
                  AnyError = 1;
                  GX_FocusControl = edtSgActividadIdCategoria_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A173SgActividadIdCategoria = 0;
                  AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
               }
               else
               {
                  A173SgActividadIdCategoria = (int)(context.localUtil.CToN( cgiGet( edtSgActividadIdCategoria_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
               }
               A174SgActividadNombreCategoria = cgiGet( edtSgActividadNombreCategoria_Internalname);
               AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSgActividadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSgActividadId_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
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
                  A171SgActividadId = (int)(context.localUtil.CToN( cgiGet( edtSgActividadId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
               }
               A172SgActividadNombre = cgiGet( edtSgActividadNombre_Internalname);
               AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"TicketTecnico");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A18TicketTecnicoId != Z18TicketTecnicoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("tickettecnico:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A18TicketTecnicoId = (long)(NumberUtil.Val( GetPar( "TicketTecnicoId"), "."));
                  AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
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
                     sMode9 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode9;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound9 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_080( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TICKETTECNICOID");
                        AnyError = 1;
                        GX_FocusControl = edtTicketTecnicoId_Internalname;
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
                                 E11082 ();
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
                                 E12082 ();
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
                                 E13082 ();
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
            E12082 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll089( ) ;
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
            DisableAttributes089( ) ;
         }
         AssignProp(sPrefix, false, edtResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableId_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTicketTecnicoInventarioSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoInventarioSerie_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoInstalacion.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoConfiguracion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoConfiguracion.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoInternetRouter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoInternetRouter.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoFormateo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoFormateo.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoReparacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoReparacion.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoLimpieza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoLimpieza.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoPuntoRed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoPuntoRed.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoCambiosHardware_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCambiosHardware.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoCopiasRespaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCopiasRespaldo.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoCerrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCerrado.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoPendiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoPendiente.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoPasaTaller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoPasaTaller.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoObservacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoObservacion.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTicketTecnicoDetalle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoDetalle_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoRam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoRam.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoDiscoDuro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoDiscoDuro.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoProcesador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoProcesador.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoMaletin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoMaletin.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoTonerCinta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoTonerCinta.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoTarjetaVideoExtra.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoCargadorLaptop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCargadorLaptop.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoCDsDVDs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCDsDVDs.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoCableEspecial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCableEspecial.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketTecnicoOtrosTaller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoOtrosTaller.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSgActividadNombreCategoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadNombreCategoria_Enabled), 5, 0), true);
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

      protected void CONFIRM_080( )
      {
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls089( ) ;
            }
            else
            {
               CheckExtendedTable089( ) ;
               CloseExtendedTableCursors089( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption080( )
      {
      }

      protected void E11082( )
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
         new k2bisauthorizedactivityname(context ).execute(  "TicketTecnico",  "TicketTecnico",  AV18StandardActivityType,  AV19UserActivityType,  AV34Pgmname, out  AV20IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV20IsAuthorized", AV20IsAuthorized);
         if ( ! AV20IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("TicketTecnico")),UrlEncode(StringUtil.RTrim("TicketTecnico")),UrlEncode(StringUtil.RTrim(AV18StandardActivityType)),UrlEncode(StringUtil.RTrim(AV19UserActivityType)),UrlEncode(StringUtil.RTrim(AV34Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "TicketTecnico", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Ticket Tecnico", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Ticket Tecnico", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Ticket Tecnico", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV35GXV1 = 1;
            AssignAttri(sPrefix, false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            while ( AV35GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV35GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV12Insert_TicketId = (long)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV12Insert_TicketId", StringUtil.LTrimStr( (decimal)(AV12Insert_TicketId), 10, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "TicketResponsableId") == 0 )
               {
                  AV13Insert_TicketResponsableId = (long)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV13Insert_TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV13Insert_TicketResponsableId), 10, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SgActividadId") == 0 )
               {
                  AV31Insert_SgActividadId = (int)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV31Insert_SgActividadId", StringUtil.LTrimStr( (decimal)(AV31Insert_SgActividadId), 9, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SgActividadIdCategoria") == 0 )
               {
                  AV32Insert_SgActividadIdCategoria = (int)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV32Insert_SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(AV32Insert_SgActividadIdCategoria), 9, 0));
               }
               AV35GXV1 = (int)(AV35GXV1+1);
               AssignAttri(sPrefix, false, "AV35GXV1", StringUtil.LTrimStr( (decimal)(AV35GXV1), 8, 0));
            }
         }
         divK2btoolstable_attributecontainerticketresponsableid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainerticketresponsableid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainerticketresponsableid_Visible), 5, 0), true);
         divK2btoolstable_attributecontainerresponsableid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainerresponsableid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainerresponsableid_Visible), 5, 0), true);
         divK2btoolstable_attributecontainerusuarioid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainerusuarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainerusuarioid_Visible), 5, 0), true);
         divK2btoolstable_attributecontainertickettecnicoobservacion_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainertickettecnicoobservacion_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainertickettecnicoobservacion_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtTicketTecnicoFecha_Class = "Attribute_TrnDate"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtTicketTecnicoFecha_Internalname, "Class", edtTicketTecnicoFecha_Class, true);
            }
            else
            {
               edtTicketTecnicoFecha_Class = "Attribute_TrnDate"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtTicketTecnicoFecha_Internalname, "Class", edtTicketTecnicoFecha_Class, true);
            }
         }
      }

      protected void E12082( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV23AttributeValueItem.gxTpr_Attributename = "TicketTecnicoId";
            AV23AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A18TicketTecnicoId), 10, 0);
            AV22AttributeValue.Add(AV23AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "TicketTecnico",  AV22AttributeValue) ;
         }
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La ticket tecnico %1 fue creada", context.localUtil.DToC( A69TicketTecnicoFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La ticket tecnico %1 fue actualizada", context.localUtil.DToC( A69TicketTecnicoFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV24Message.gxTpr_Description = StringUtil.Format( "La ticket tecnico %1 fue eliminada", context.localUtil.DToC( A69TicketTecnicoFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV24Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"TicketTecnico",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV22AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "TicketTecnico") ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AttributeValue", AV22AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10Navigation", AV10Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", AV8TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV21encrypt = AV8TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21encrypt)) )
         {
            GXt_char1 = AV21encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV21encrypt = GXt_char1;
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
               if ( StringUtil.StrCmp(AV21encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A18TicketTecnicoId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A18TicketTecnicoId = (long)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV21encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A18TicketTecnicoId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A18TicketTecnicoId = (long)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A18TicketTecnicoId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A18TicketTecnicoId = (long)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
               if ( StringUtil.StrCmp(AV21encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(long)A18TicketTecnicoId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A18TicketTecnicoId = (long)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV21encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(long)A18TicketTecnicoId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A18TicketTecnicoId = (long)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(long)A18TicketTecnicoId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A18TicketTecnicoId = (long)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A18TicketTecnicoId,10,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E13082( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "TicketTecnico") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"TicketTecnico"}, true);
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
            AV17Url = AV8TrnContext.gxTpr_Callerurl;
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

      protected void ZM089( short GX_JID )
      {
         if ( ( GX_JID == 23 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z69TicketTecnicoFecha = T00083_A69TicketTecnicoFecha[0];
               Z71TicketTecnicoHora = T00083_A71TicketTecnicoHora[0];
               Z74TicketTecnicoInventarioSerie = T00083_A74TicketTecnicoInventarioSerie[0];
               Z72TicketTecnicoInstalacion = T00083_A72TicketTecnicoInstalacion[0];
               Z66TicketTecnicoConfiguracion = T00083_A66TicketTecnicoConfiguracion[0];
               Z73TicketTecnicoInternetRouter = T00083_A73TicketTecnicoInternetRouter[0];
               Z70TicketTecnicoFormateo = T00083_A70TicketTecnicoFormateo[0];
               Z84TicketTecnicoReparacion = T00083_A84TicketTecnicoReparacion[0];
               Z75TicketTecnicoLimpieza = T00083_A75TicketTecnicoLimpieza[0];
               Z82TicketTecnicoPuntoRed = T00083_A82TicketTecnicoPuntoRed[0];
               Z62TicketTecnicoCambiosHardware = T00083_A62TicketTecnicoCambiosHardware[0];
               Z67TicketTecnicoCopiasRespaldo = T00083_A67TicketTecnicoCopiasRespaldo[0];
               Z83TicketTecnicoRam = T00083_A83TicketTecnicoRam[0];
               Z68TicketTecnicoDiscoDuro = T00083_A68TicketTecnicoDiscoDuro[0];
               Z81TicketTecnicoProcesador = T00083_A81TicketTecnicoProcesador[0];
               Z76TicketTecnicoMaletin = T00083_A76TicketTecnicoMaletin[0];
               Z86TicketTecnicoTonerCinta = T00083_A86TicketTecnicoTonerCinta[0];
               Z85TicketTecnicoTarjetaVideoExtra = T00083_A85TicketTecnicoTarjetaVideoExtra[0];
               Z63TicketTecnicoCargadorLaptop = T00083_A63TicketTecnicoCargadorLaptop[0];
               Z64TicketTecnicoCDsDVDs = T00083_A64TicketTecnicoCDsDVDs[0];
               Z61TicketTecnicoCableEspecial = T00083_A61TicketTecnicoCableEspecial[0];
               Z78TicketTecnicoOtrosTaller = T00083_A78TicketTecnicoOtrosTaller[0];
               Z65TicketTecnicoCerrado = T00083_A65TicketTecnicoCerrado[0];
               Z80TicketTecnicoPendiente = T00083_A80TicketTecnicoPendiente[0];
               Z79TicketTecnicoPasaTaller = T00083_A79TicketTecnicoPasaTaller[0];
               Z77TicketTecnicoObservacion = T00083_A77TicketTecnicoObservacion[0];
               Z97TicketTecnicoDetalle = T00083_A97TicketTecnicoDetalle[0];
               Z14TicketId = T00083_A14TicketId[0];
               Z6ResponsableId = T00083_A6ResponsableId[0];
               Z16TicketResponsableId = T00083_A16TicketResponsableId[0];
               Z171SgActividadId = T00083_A171SgActividadId[0];
               Z173SgActividadIdCategoria = T00083_A173SgActividadIdCategoria[0];
            }
            else
            {
               Z69TicketTecnicoFecha = A69TicketTecnicoFecha;
               Z71TicketTecnicoHora = A71TicketTecnicoHora;
               Z74TicketTecnicoInventarioSerie = A74TicketTecnicoInventarioSerie;
               Z72TicketTecnicoInstalacion = A72TicketTecnicoInstalacion;
               Z66TicketTecnicoConfiguracion = A66TicketTecnicoConfiguracion;
               Z73TicketTecnicoInternetRouter = A73TicketTecnicoInternetRouter;
               Z70TicketTecnicoFormateo = A70TicketTecnicoFormateo;
               Z84TicketTecnicoReparacion = A84TicketTecnicoReparacion;
               Z75TicketTecnicoLimpieza = A75TicketTecnicoLimpieza;
               Z82TicketTecnicoPuntoRed = A82TicketTecnicoPuntoRed;
               Z62TicketTecnicoCambiosHardware = A62TicketTecnicoCambiosHardware;
               Z67TicketTecnicoCopiasRespaldo = A67TicketTecnicoCopiasRespaldo;
               Z83TicketTecnicoRam = A83TicketTecnicoRam;
               Z68TicketTecnicoDiscoDuro = A68TicketTecnicoDiscoDuro;
               Z81TicketTecnicoProcesador = A81TicketTecnicoProcesador;
               Z76TicketTecnicoMaletin = A76TicketTecnicoMaletin;
               Z86TicketTecnicoTonerCinta = A86TicketTecnicoTonerCinta;
               Z85TicketTecnicoTarjetaVideoExtra = A85TicketTecnicoTarjetaVideoExtra;
               Z63TicketTecnicoCargadorLaptop = A63TicketTecnicoCargadorLaptop;
               Z64TicketTecnicoCDsDVDs = A64TicketTecnicoCDsDVDs;
               Z61TicketTecnicoCableEspecial = A61TicketTecnicoCableEspecial;
               Z78TicketTecnicoOtrosTaller = A78TicketTecnicoOtrosTaller;
               Z65TicketTecnicoCerrado = A65TicketTecnicoCerrado;
               Z80TicketTecnicoPendiente = A80TicketTecnicoPendiente;
               Z79TicketTecnicoPasaTaller = A79TicketTecnicoPasaTaller;
               Z77TicketTecnicoObservacion = A77TicketTecnicoObservacion;
               Z97TicketTecnicoDetalle = A97TicketTecnicoDetalle;
               Z14TicketId = A14TicketId;
               Z6ResponsableId = A6ResponsableId;
               Z16TicketResponsableId = A16TicketResponsableId;
               Z171SgActividadId = A171SgActividadId;
               Z173SgActividadIdCategoria = A173SgActividadIdCategoria;
            }
         }
         if ( GX_JID == -23 )
         {
            Z18TicketTecnicoId = A18TicketTecnicoId;
            Z69TicketTecnicoFecha = A69TicketTecnicoFecha;
            Z71TicketTecnicoHora = A71TicketTecnicoHora;
            Z74TicketTecnicoInventarioSerie = A74TicketTecnicoInventarioSerie;
            Z72TicketTecnicoInstalacion = A72TicketTecnicoInstalacion;
            Z66TicketTecnicoConfiguracion = A66TicketTecnicoConfiguracion;
            Z73TicketTecnicoInternetRouter = A73TicketTecnicoInternetRouter;
            Z70TicketTecnicoFormateo = A70TicketTecnicoFormateo;
            Z84TicketTecnicoReparacion = A84TicketTecnicoReparacion;
            Z75TicketTecnicoLimpieza = A75TicketTecnicoLimpieza;
            Z82TicketTecnicoPuntoRed = A82TicketTecnicoPuntoRed;
            Z62TicketTecnicoCambiosHardware = A62TicketTecnicoCambiosHardware;
            Z67TicketTecnicoCopiasRespaldo = A67TicketTecnicoCopiasRespaldo;
            Z83TicketTecnicoRam = A83TicketTecnicoRam;
            Z68TicketTecnicoDiscoDuro = A68TicketTecnicoDiscoDuro;
            Z81TicketTecnicoProcesador = A81TicketTecnicoProcesador;
            Z76TicketTecnicoMaletin = A76TicketTecnicoMaletin;
            Z86TicketTecnicoTonerCinta = A86TicketTecnicoTonerCinta;
            Z85TicketTecnicoTarjetaVideoExtra = A85TicketTecnicoTarjetaVideoExtra;
            Z63TicketTecnicoCargadorLaptop = A63TicketTecnicoCargadorLaptop;
            Z64TicketTecnicoCDsDVDs = A64TicketTecnicoCDsDVDs;
            Z61TicketTecnicoCableEspecial = A61TicketTecnicoCableEspecial;
            Z78TicketTecnicoOtrosTaller = A78TicketTecnicoOtrosTaller;
            Z65TicketTecnicoCerrado = A65TicketTecnicoCerrado;
            Z80TicketTecnicoPendiente = A80TicketTecnicoPendiente;
            Z79TicketTecnicoPasaTaller = A79TicketTecnicoPasaTaller;
            Z77TicketTecnicoObservacion = A77TicketTecnicoObservacion;
            Z97TicketTecnicoDetalle = A97TicketTecnicoDetalle;
            Z14TicketId = A14TicketId;
            Z6ResponsableId = A6ResponsableId;
            Z16TicketResponsableId = A16TicketResponsableId;
            Z171SgActividadId = A171SgActividadId;
            Z173SgActividadIdCategoria = A173SgActividadIdCategoria;
            Z15UsuarioId = A15UsuarioId;
            Z93UsuarioNombre = A93UsuarioNombre;
            Z94UsuarioRequerimiento = A94UsuarioRequerimiento;
            Z88UsuarioDepartamento = A88UsuarioDepartamento;
            Z30ResponsableNombre = A30ResponsableNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTicketTecnicoId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoId_Enabled), 5, 0), true);
         edtTicketTecnicoFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoFecha_Enabled), 5, 0), true);
         edtTicketTecnicoHora_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoHora_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_16_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0081.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETID"+"'), id:'"+sPrefix+"TICKETID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETRESPONSABLEID"+"'), id:'"+sPrefix+"TICKETRESPONSABLEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETID"+"'), id:'"+sPrefix+"TICKETID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_6_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"RESPONSABLEID"+"'), id:'"+sPrefix+"RESPONSABLEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_173_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptcategoria_tarea.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SGACTIVIDADIDCATEGORIA"+"'), id:'"+sPrefix+"SGACTIVIDADIDCATEGORIA"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_171_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptactividades_categoria.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SGACTIVIDADID"+"'), id:'"+sPrefix+"SGACTIVIDADID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtTicketTecnicoId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoId_Enabled), 5, 0), true);
         edtTicketTecnicoFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoFecha_Enabled), 5, 0), true);
         edtTicketTecnicoHora_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoHora_Enabled), 5, 0), true);
         if ( ! (0==AV7TicketTecnicoId) )
         {
            A18TicketTecnicoId = AV7TicketTecnicoId;
            AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TicketId) )
         {
            edtTicketId_Enabled = 0;
            AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         }
         else
         {
            edtTicketId_Enabled = 1;
            AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TicketResponsableId) )
         {
            edtTicketResponsableId_Enabled = 0;
            AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), true);
         }
         else
         {
            edtTicketResponsableId_Enabled = 1;
            AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_SgActividadId) )
         {
            edtSgActividadId_Enabled = 0;
            AssignProp(sPrefix, false, edtSgActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadId_Enabled), 5, 0), true);
         }
         else
         {
            edtSgActividadId_Enabled = 1;
            AssignProp(sPrefix, false, edtSgActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_SgActividadIdCategoria) )
         {
            edtSgActividadIdCategoria_Enabled = 0;
            AssignProp(sPrefix, false, edtSgActividadIdCategoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadIdCategoria_Enabled), 5, 0), true);
         }
         else
         {
            edtSgActividadIdCategoria_Enabled = 1;
            AssignProp(sPrefix, false, edtSgActividadIdCategoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadIdCategoria_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_SgActividadIdCategoria) )
         {
            A173SgActividadIdCategoria = AV32Insert_SgActividadIdCategoria;
            AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV31Insert_SgActividadId) )
         {
            A171SgActividadId = AV31Insert_SgActividadId;
            AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_TicketResponsableId) )
         {
            A16TicketResponsableId = AV13Insert_TicketResponsableId;
            AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_TicketId) )
         {
            A14TicketId = AV12Insert_TicketId;
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A69TicketTecnicoFecha) && ( Gx_BScreen == 0 ) )
         {
            A69TicketTecnicoFecha = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A71TicketTecnicoHora) && ( Gx_BScreen == 0 ) )
         {
            A71TicketTecnicoHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV34Pgmname = "TicketTecnico";
            AssignAttri(sPrefix, false, "AV34Pgmname", AV34Pgmname);
            /* Using cursor T00088 */
            pr_datastore1.execute(1, new Object[] {A173SgActividadIdCategoria});
            A106nombre_categoria = T00088_A106nombre_categoria[0];
            n106nombre_categoria = T00088_n106nombre_categoria[0];
            A174SgActividadNombreCategoria = T00088_A106nombre_categoria[0];
            AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
            pr_datastore1.close(1);
            /* Using cursor T00087 */
            pr_datastore1.execute(0, new Object[] {A171SgActividadId});
            A123nombre_actividad = T00087_A123nombre_actividad[0];
            n123nombre_actividad = T00087_n123nombre_actividad[0];
            A172SgActividadNombre = T00087_A123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
            pr_datastore1.close(0);
            /* Using cursor T00084 */
            pr_default.execute(2, new Object[] {A14TicketId});
            A15UsuarioId = T00084_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            pr_default.close(2);
            /* Using cursor T00089 */
            pr_default.execute(5, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T00089_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T00089_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A88UsuarioDepartamento = T00089_A88UsuarioDepartamento[0];
            AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            pr_default.close(5);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
            }
         }
      }

      protected void Load089( )
      {
         /* Using cursor T000810 */
         pr_default.execute(6, new Object[] {A18TicketTecnicoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound9 = 1;
            A69TicketTecnicoFecha = T000810_A69TicketTecnicoFecha[0];
            AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
            A71TicketTecnicoHora = T000810_A71TicketTecnicoHora[0];
            AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            A30ResponsableNombre = T000810_A30ResponsableNombre[0];
            AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
            A93UsuarioNombre = T000810_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T000810_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A88UsuarioDepartamento = T000810_A88UsuarioDepartamento[0];
            AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            A74TicketTecnicoInventarioSerie = T000810_A74TicketTecnicoInventarioSerie[0];
            AssignAttri(sPrefix, false, "A74TicketTecnicoInventarioSerie", A74TicketTecnicoInventarioSerie);
            A72TicketTecnicoInstalacion = T000810_A72TicketTecnicoInstalacion[0];
            AssignAttri(sPrefix, false, "A72TicketTecnicoInstalacion", A72TicketTecnicoInstalacion);
            A66TicketTecnicoConfiguracion = T000810_A66TicketTecnicoConfiguracion[0];
            AssignAttri(sPrefix, false, "A66TicketTecnicoConfiguracion", A66TicketTecnicoConfiguracion);
            A73TicketTecnicoInternetRouter = T000810_A73TicketTecnicoInternetRouter[0];
            AssignAttri(sPrefix, false, "A73TicketTecnicoInternetRouter", A73TicketTecnicoInternetRouter);
            A70TicketTecnicoFormateo = T000810_A70TicketTecnicoFormateo[0];
            AssignAttri(sPrefix, false, "A70TicketTecnicoFormateo", A70TicketTecnicoFormateo);
            A84TicketTecnicoReparacion = T000810_A84TicketTecnicoReparacion[0];
            AssignAttri(sPrefix, false, "A84TicketTecnicoReparacion", A84TicketTecnicoReparacion);
            A75TicketTecnicoLimpieza = T000810_A75TicketTecnicoLimpieza[0];
            AssignAttri(sPrefix, false, "A75TicketTecnicoLimpieza", A75TicketTecnicoLimpieza);
            A82TicketTecnicoPuntoRed = T000810_A82TicketTecnicoPuntoRed[0];
            AssignAttri(sPrefix, false, "A82TicketTecnicoPuntoRed", A82TicketTecnicoPuntoRed);
            A62TicketTecnicoCambiosHardware = T000810_A62TicketTecnicoCambiosHardware[0];
            AssignAttri(sPrefix, false, "A62TicketTecnicoCambiosHardware", A62TicketTecnicoCambiosHardware);
            A67TicketTecnicoCopiasRespaldo = T000810_A67TicketTecnicoCopiasRespaldo[0];
            AssignAttri(sPrefix, false, "A67TicketTecnicoCopiasRespaldo", A67TicketTecnicoCopiasRespaldo);
            A83TicketTecnicoRam = T000810_A83TicketTecnicoRam[0];
            AssignAttri(sPrefix, false, "A83TicketTecnicoRam", A83TicketTecnicoRam);
            A68TicketTecnicoDiscoDuro = T000810_A68TicketTecnicoDiscoDuro[0];
            AssignAttri(sPrefix, false, "A68TicketTecnicoDiscoDuro", A68TicketTecnicoDiscoDuro);
            A81TicketTecnicoProcesador = T000810_A81TicketTecnicoProcesador[0];
            AssignAttri(sPrefix, false, "A81TicketTecnicoProcesador", A81TicketTecnicoProcesador);
            A76TicketTecnicoMaletin = T000810_A76TicketTecnicoMaletin[0];
            AssignAttri(sPrefix, false, "A76TicketTecnicoMaletin", A76TicketTecnicoMaletin);
            A86TicketTecnicoTonerCinta = T000810_A86TicketTecnicoTonerCinta[0];
            AssignAttri(sPrefix, false, "A86TicketTecnicoTonerCinta", A86TicketTecnicoTonerCinta);
            A85TicketTecnicoTarjetaVideoExtra = T000810_A85TicketTecnicoTarjetaVideoExtra[0];
            AssignAttri(sPrefix, false, "A85TicketTecnicoTarjetaVideoExtra", A85TicketTecnicoTarjetaVideoExtra);
            A63TicketTecnicoCargadorLaptop = T000810_A63TicketTecnicoCargadorLaptop[0];
            AssignAttri(sPrefix, false, "A63TicketTecnicoCargadorLaptop", A63TicketTecnicoCargadorLaptop);
            A64TicketTecnicoCDsDVDs = T000810_A64TicketTecnicoCDsDVDs[0];
            AssignAttri(sPrefix, false, "A64TicketTecnicoCDsDVDs", A64TicketTecnicoCDsDVDs);
            A61TicketTecnicoCableEspecial = T000810_A61TicketTecnicoCableEspecial[0];
            AssignAttri(sPrefix, false, "A61TicketTecnicoCableEspecial", A61TicketTecnicoCableEspecial);
            A78TicketTecnicoOtrosTaller = T000810_A78TicketTecnicoOtrosTaller[0];
            AssignAttri(sPrefix, false, "A78TicketTecnicoOtrosTaller", A78TicketTecnicoOtrosTaller);
            A65TicketTecnicoCerrado = T000810_A65TicketTecnicoCerrado[0];
            AssignAttri(sPrefix, false, "A65TicketTecnicoCerrado", A65TicketTecnicoCerrado);
            A80TicketTecnicoPendiente = T000810_A80TicketTecnicoPendiente[0];
            AssignAttri(sPrefix, false, "A80TicketTecnicoPendiente", A80TicketTecnicoPendiente);
            A79TicketTecnicoPasaTaller = T000810_A79TicketTecnicoPasaTaller[0];
            AssignAttri(sPrefix, false, "A79TicketTecnicoPasaTaller", A79TicketTecnicoPasaTaller);
            A77TicketTecnicoObservacion = T000810_A77TicketTecnicoObservacion[0];
            n77TicketTecnicoObservacion = T000810_n77TicketTecnicoObservacion[0];
            AssignAttri(sPrefix, false, "A77TicketTecnicoObservacion", A77TicketTecnicoObservacion);
            A97TicketTecnicoDetalle = T000810_A97TicketTecnicoDetalle[0];
            AssignAttri(sPrefix, false, "A97TicketTecnicoDetalle", A97TicketTecnicoDetalle);
            A14TicketId = T000810_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            A6ResponsableId = T000810_A6ResponsableId[0];
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
            A16TicketResponsableId = T000810_A16TicketResponsableId[0];
            AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
            A171SgActividadId = T000810_A171SgActividadId[0];
            AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
            A173SgActividadIdCategoria = T000810_A173SgActividadIdCategoria[0];
            AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
            A15UsuarioId = T000810_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            ZM089( -23) ;
         }
         pr_default.close(6);
         OnLoadActions089( ) ;
      }

      protected void OnLoadActions089( )
      {
         AV34Pgmname = "TicketTecnico";
         AssignAttri(sPrefix, false, "AV34Pgmname", AV34Pgmname);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode9, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         }
         /* Using cursor T00087 */
         pr_datastore1.execute(0, new Object[] {A171SgActividadId});
         A123nombre_actividad = T00087_A123nombre_actividad[0];
         n123nombre_actividad = T00087_n123nombre_actividad[0];
         A172SgActividadNombre = T00087_A123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         pr_datastore1.close(0);
         /* Using cursor T00088 */
         pr_datastore1.execute(1, new Object[] {A173SgActividadIdCategoria});
         A106nombre_categoria = T00088_A106nombre_categoria[0];
         n106nombre_categoria = T00088_n106nombre_categoria[0];
         A174SgActividadNombreCategoria = T00088_A106nombre_categoria[0];
         AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
         pr_datastore1.close(1);
      }

      protected void CheckExtendedTable089( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV34Pgmname = "TicketTecnico";
         AssignAttri(sPrefix, false, "AV34Pgmname", AV34Pgmname);
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A15UsuarioId = T00084_A15UsuarioId[0];
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         pr_default.close(2);
         /* Using cursor T00089 */
         pr_default.execute(5, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T00089_A93UsuarioNombre[0];
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = T00089_A94UsuarioRequerimiento[0];
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A88UsuarioDepartamento = T00089_A88UsuarioDepartamento[0];
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         pr_default.close(5);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         }
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "TICKETRESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A30ResponsableNombre = T00085_A30ResponsableNombre[0];
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
         pr_default.close(3);
         /* Using cursor T00087 */
         pr_datastore1.execute(0, new Object[] {A171SgActividadId});
         if ( (pr_datastore1.getStatus(0) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "SGACTIVIDADID");
            AnyError = 1;
            GX_FocusControl = edtSgActividadId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A123nombre_actividad = T00087_A123nombre_actividad[0];
         n123nombre_actividad = T00087_n123nombre_actividad[0];
         A172SgActividadNombre = T00087_A123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         pr_datastore1.close(0);
         /* Using cursor T00088 */
         pr_datastore1.execute(1, new Object[] {A173SgActividadIdCategoria});
         if ( (pr_datastore1.getStatus(1) == 101) )
         {
            GX_msglist.addItem("No existe 'categoria_tarea'.", "ForeignKeyNotFound", 1, "SGACTIVIDADIDCATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtSgActividadIdCategoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A106nombre_categoria = T00088_A106nombre_categoria[0];
         n106nombre_categoria = T00088_n106nombre_categoria[0];
         A174SgActividadNombreCategoria = T00088_A106nombre_categoria[0];
         AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
         pr_datastore1.close(1);
         if ( (DateTime.MinValue==A69TicketTecnicoFecha) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Fecha", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors089( )
      {
         pr_default.close(2);
         pr_default.close(5);
         pr_default.close(4);
         pr_default.close(3);
         pr_datastore1.close(0);
         pr_datastore1.close(1);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_24( long A14TicketId )
      {
         /* Using cursor T000811 */
         pr_default.execute(7, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A15UsuarioId = T000811_A15UsuarioId[0];
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_29( short A15UsuarioId )
      {
         /* Using cursor T000812 */
         pr_default.execute(8, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000812_A93UsuarioNombre[0];
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = T000812_A94UsuarioRequerimiento[0];
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A88UsuarioDepartamento = T000812_A88UsuarioDepartamento[0];
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A93UsuarioNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A94UsuarioRequerimiento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A88UsuarioDepartamento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_26( long A14TicketId ,
                                long A16TicketResponsableId )
      {
         /* Using cursor T000813 */
         pr_default.execute(9, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "TICKETRESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_25( short A6ResponsableId )
      {
         /* Using cursor T000814 */
         pr_default.execute(10, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A30ResponsableNombre = T000814_A30ResponsableNombre[0];
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A30ResponsableNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_27( int A171SgActividadId )
      {
         /* Using cursor T000815 */
         pr_datastore1.execute(2, new Object[] {A171SgActividadId});
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "SGACTIVIDADID");
            AnyError = 1;
            GX_FocusControl = edtSgActividadId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A123nombre_actividad = T000815_A123nombre_actividad[0];
         n123nombre_actividad = T000815_n123nombre_actividad[0];
         A172SgActividadNombre = T000815_A123nombre_actividad[0];
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A172SgActividadNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(2) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(2);
      }

      protected void gxLoad_28( int A173SgActividadIdCategoria )
      {
         /* Using cursor T000816 */
         pr_datastore1.execute(3, new Object[] {A173SgActividadIdCategoria});
         if ( (pr_datastore1.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'categoria_tarea'.", "ForeignKeyNotFound", 1, "SGACTIVIDADIDCATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtSgActividadIdCategoria_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A106nombre_categoria = T000816_A106nombre_categoria[0];
         n106nombre_categoria = T000816_n106nombre_categoria[0];
         A174SgActividadNombreCategoria = T000816_A106nombre_categoria[0];
         AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A174SgActividadNombreCategoria)+"\"") ;
         AddString( "]") ;
         if ( (pr_datastore1.getStatus(3) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_datastore1.close(3);
      }

      protected void GetKey089( )
      {
         /* Using cursor T000817 */
         pr_default.execute(11, new Object[] {A18TicketTecnicoId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A18TicketTecnicoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM089( 23) ;
            RcdFound9 = 1;
            A18TicketTecnicoId = T00083_A18TicketTecnicoId[0];
            AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
            A69TicketTecnicoFecha = T00083_A69TicketTecnicoFecha[0];
            AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
            A71TicketTecnicoHora = T00083_A71TicketTecnicoHora[0];
            AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
            A74TicketTecnicoInventarioSerie = T00083_A74TicketTecnicoInventarioSerie[0];
            AssignAttri(sPrefix, false, "A74TicketTecnicoInventarioSerie", A74TicketTecnicoInventarioSerie);
            A72TicketTecnicoInstalacion = T00083_A72TicketTecnicoInstalacion[0];
            AssignAttri(sPrefix, false, "A72TicketTecnicoInstalacion", A72TicketTecnicoInstalacion);
            A66TicketTecnicoConfiguracion = T00083_A66TicketTecnicoConfiguracion[0];
            AssignAttri(sPrefix, false, "A66TicketTecnicoConfiguracion", A66TicketTecnicoConfiguracion);
            A73TicketTecnicoInternetRouter = T00083_A73TicketTecnicoInternetRouter[0];
            AssignAttri(sPrefix, false, "A73TicketTecnicoInternetRouter", A73TicketTecnicoInternetRouter);
            A70TicketTecnicoFormateo = T00083_A70TicketTecnicoFormateo[0];
            AssignAttri(sPrefix, false, "A70TicketTecnicoFormateo", A70TicketTecnicoFormateo);
            A84TicketTecnicoReparacion = T00083_A84TicketTecnicoReparacion[0];
            AssignAttri(sPrefix, false, "A84TicketTecnicoReparacion", A84TicketTecnicoReparacion);
            A75TicketTecnicoLimpieza = T00083_A75TicketTecnicoLimpieza[0];
            AssignAttri(sPrefix, false, "A75TicketTecnicoLimpieza", A75TicketTecnicoLimpieza);
            A82TicketTecnicoPuntoRed = T00083_A82TicketTecnicoPuntoRed[0];
            AssignAttri(sPrefix, false, "A82TicketTecnicoPuntoRed", A82TicketTecnicoPuntoRed);
            A62TicketTecnicoCambiosHardware = T00083_A62TicketTecnicoCambiosHardware[0];
            AssignAttri(sPrefix, false, "A62TicketTecnicoCambiosHardware", A62TicketTecnicoCambiosHardware);
            A67TicketTecnicoCopiasRespaldo = T00083_A67TicketTecnicoCopiasRespaldo[0];
            AssignAttri(sPrefix, false, "A67TicketTecnicoCopiasRespaldo", A67TicketTecnicoCopiasRespaldo);
            A83TicketTecnicoRam = T00083_A83TicketTecnicoRam[0];
            AssignAttri(sPrefix, false, "A83TicketTecnicoRam", A83TicketTecnicoRam);
            A68TicketTecnicoDiscoDuro = T00083_A68TicketTecnicoDiscoDuro[0];
            AssignAttri(sPrefix, false, "A68TicketTecnicoDiscoDuro", A68TicketTecnicoDiscoDuro);
            A81TicketTecnicoProcesador = T00083_A81TicketTecnicoProcesador[0];
            AssignAttri(sPrefix, false, "A81TicketTecnicoProcesador", A81TicketTecnicoProcesador);
            A76TicketTecnicoMaletin = T00083_A76TicketTecnicoMaletin[0];
            AssignAttri(sPrefix, false, "A76TicketTecnicoMaletin", A76TicketTecnicoMaletin);
            A86TicketTecnicoTonerCinta = T00083_A86TicketTecnicoTonerCinta[0];
            AssignAttri(sPrefix, false, "A86TicketTecnicoTonerCinta", A86TicketTecnicoTonerCinta);
            A85TicketTecnicoTarjetaVideoExtra = T00083_A85TicketTecnicoTarjetaVideoExtra[0];
            AssignAttri(sPrefix, false, "A85TicketTecnicoTarjetaVideoExtra", A85TicketTecnicoTarjetaVideoExtra);
            A63TicketTecnicoCargadorLaptop = T00083_A63TicketTecnicoCargadorLaptop[0];
            AssignAttri(sPrefix, false, "A63TicketTecnicoCargadorLaptop", A63TicketTecnicoCargadorLaptop);
            A64TicketTecnicoCDsDVDs = T00083_A64TicketTecnicoCDsDVDs[0];
            AssignAttri(sPrefix, false, "A64TicketTecnicoCDsDVDs", A64TicketTecnicoCDsDVDs);
            A61TicketTecnicoCableEspecial = T00083_A61TicketTecnicoCableEspecial[0];
            AssignAttri(sPrefix, false, "A61TicketTecnicoCableEspecial", A61TicketTecnicoCableEspecial);
            A78TicketTecnicoOtrosTaller = T00083_A78TicketTecnicoOtrosTaller[0];
            AssignAttri(sPrefix, false, "A78TicketTecnicoOtrosTaller", A78TicketTecnicoOtrosTaller);
            A65TicketTecnicoCerrado = T00083_A65TicketTecnicoCerrado[0];
            AssignAttri(sPrefix, false, "A65TicketTecnicoCerrado", A65TicketTecnicoCerrado);
            A80TicketTecnicoPendiente = T00083_A80TicketTecnicoPendiente[0];
            AssignAttri(sPrefix, false, "A80TicketTecnicoPendiente", A80TicketTecnicoPendiente);
            A79TicketTecnicoPasaTaller = T00083_A79TicketTecnicoPasaTaller[0];
            AssignAttri(sPrefix, false, "A79TicketTecnicoPasaTaller", A79TicketTecnicoPasaTaller);
            A77TicketTecnicoObservacion = T00083_A77TicketTecnicoObservacion[0];
            n77TicketTecnicoObservacion = T00083_n77TicketTecnicoObservacion[0];
            AssignAttri(sPrefix, false, "A77TicketTecnicoObservacion", A77TicketTecnicoObservacion);
            A97TicketTecnicoDetalle = T00083_A97TicketTecnicoDetalle[0];
            AssignAttri(sPrefix, false, "A97TicketTecnicoDetalle", A97TicketTecnicoDetalle);
            A14TicketId = T00083_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            A6ResponsableId = T00083_A6ResponsableId[0];
            AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
            A16TicketResponsableId = T00083_A16TicketResponsableId[0];
            AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
            A171SgActividadId = T00083_A171SgActividadId[0];
            AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
            A173SgActividadIdCategoria = T00083_A173SgActividadIdCategoria[0];
            AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
            Z18TicketTecnicoId = A18TicketTecnicoId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load089( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey089( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey089( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey089( ) ;
         if ( RcdFound9 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound9 = 0;
         /* Using cursor T000818 */
         pr_default.execute(12, new Object[] {A18TicketTecnicoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T000818_A18TicketTecnicoId[0] < A18TicketTecnicoId ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T000818_A18TicketTecnicoId[0] > A18TicketTecnicoId ) ) )
            {
               A18TicketTecnicoId = T000818_A18TicketTecnicoId[0];
               AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T000819 */
         pr_default.execute(13, new Object[] {A18TicketTecnicoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000819_A18TicketTecnicoId[0] > A18TicketTecnicoId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000819_A18TicketTecnicoId[0] < A18TicketTecnicoId ) ) )
            {
               A18TicketTecnicoId = T000819_A18TicketTecnicoId[0];
               AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey089( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTicketResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert089( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A18TicketTecnicoId != Z18TicketTecnicoId )
               {
                  A18TicketTecnicoId = Z18TicketTecnicoId;
                  AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TICKETTECNICOID");
                  AnyError = 1;
                  GX_FocusControl = edtTicketTecnicoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTicketResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update089( ) ;
                  GX_FocusControl = edtTicketResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A18TicketTecnicoId != Z18TicketTecnicoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtTicketResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert089( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TICKETTECNICOID");
                     AnyError = 1;
                     GX_FocusControl = edtTicketTecnicoId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTicketResponsableId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert089( ) ;
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
         if ( A18TicketTecnicoId != Z18TicketTecnicoId )
         {
            A18TicketTecnicoId = Z18TicketTecnicoId;
            AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TICKETTECNICOID");
            AnyError = 1;
            GX_FocusControl = edtTicketTecnicoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTicketResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency089( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A18TicketTecnicoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TicketTecnico"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z69TicketTecnicoFecha != T00082_A69TicketTecnicoFecha[0] ) || ( Z71TicketTecnicoHora != T00082_A71TicketTecnicoHora[0] ) || ( StringUtil.StrCmp(Z74TicketTecnicoInventarioSerie, T00082_A74TicketTecnicoInventarioSerie[0]) != 0 ) || ( Z72TicketTecnicoInstalacion != T00082_A72TicketTecnicoInstalacion[0] ) || ( Z66TicketTecnicoConfiguracion != T00082_A66TicketTecnicoConfiguracion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z73TicketTecnicoInternetRouter != T00082_A73TicketTecnicoInternetRouter[0] ) || ( Z70TicketTecnicoFormateo != T00082_A70TicketTecnicoFormateo[0] ) || ( Z84TicketTecnicoReparacion != T00082_A84TicketTecnicoReparacion[0] ) || ( Z75TicketTecnicoLimpieza != T00082_A75TicketTecnicoLimpieza[0] ) || ( Z82TicketTecnicoPuntoRed != T00082_A82TicketTecnicoPuntoRed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z62TicketTecnicoCambiosHardware != T00082_A62TicketTecnicoCambiosHardware[0] ) || ( Z67TicketTecnicoCopiasRespaldo != T00082_A67TicketTecnicoCopiasRespaldo[0] ) || ( Z83TicketTecnicoRam != T00082_A83TicketTecnicoRam[0] ) || ( Z68TicketTecnicoDiscoDuro != T00082_A68TicketTecnicoDiscoDuro[0] ) || ( Z81TicketTecnicoProcesador != T00082_A81TicketTecnicoProcesador[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z76TicketTecnicoMaletin != T00082_A76TicketTecnicoMaletin[0] ) || ( Z86TicketTecnicoTonerCinta != T00082_A86TicketTecnicoTonerCinta[0] ) || ( Z85TicketTecnicoTarjetaVideoExtra != T00082_A85TicketTecnicoTarjetaVideoExtra[0] ) || ( Z63TicketTecnicoCargadorLaptop != T00082_A63TicketTecnicoCargadorLaptop[0] ) || ( Z64TicketTecnicoCDsDVDs != T00082_A64TicketTecnicoCDsDVDs[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z61TicketTecnicoCableEspecial != T00082_A61TicketTecnicoCableEspecial[0] ) || ( Z78TicketTecnicoOtrosTaller != T00082_A78TicketTecnicoOtrosTaller[0] ) || ( Z65TicketTecnicoCerrado != T00082_A65TicketTecnicoCerrado[0] ) || ( Z80TicketTecnicoPendiente != T00082_A80TicketTecnicoPendiente[0] ) || ( Z79TicketTecnicoPasaTaller != T00082_A79TicketTecnicoPasaTaller[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z77TicketTecnicoObservacion != T00082_A77TicketTecnicoObservacion[0] ) || ( StringUtil.StrCmp(Z97TicketTecnicoDetalle, T00082_A97TicketTecnicoDetalle[0]) != 0 ) || ( Z14TicketId != T00082_A14TicketId[0] ) || ( Z6ResponsableId != T00082_A6ResponsableId[0] ) || ( Z16TicketResponsableId != T00082_A16TicketResponsableId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z171SgActividadId != T00082_A171SgActividadId[0] ) || ( Z173SgActividadIdCategoria != T00082_A173SgActividadIdCategoria[0] ) )
            {
               if ( Z69TicketTecnicoFecha != T00082_A69TicketTecnicoFecha[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoFecha");
                  GXUtil.WriteLogRaw("Old: ",Z69TicketTecnicoFecha);
                  GXUtil.WriteLogRaw("Current: ",T00082_A69TicketTecnicoFecha[0]);
               }
               if ( Z71TicketTecnicoHora != T00082_A71TicketTecnicoHora[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoHora");
                  GXUtil.WriteLogRaw("Old: ",Z71TicketTecnicoHora);
                  GXUtil.WriteLogRaw("Current: ",T00082_A71TicketTecnicoHora[0]);
               }
               if ( StringUtil.StrCmp(Z74TicketTecnicoInventarioSerie, T00082_A74TicketTecnicoInventarioSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoInventarioSerie");
                  GXUtil.WriteLogRaw("Old: ",Z74TicketTecnicoInventarioSerie);
                  GXUtil.WriteLogRaw("Current: ",T00082_A74TicketTecnicoInventarioSerie[0]);
               }
               if ( Z72TicketTecnicoInstalacion != T00082_A72TicketTecnicoInstalacion[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoInstalacion");
                  GXUtil.WriteLogRaw("Old: ",Z72TicketTecnicoInstalacion);
                  GXUtil.WriteLogRaw("Current: ",T00082_A72TicketTecnicoInstalacion[0]);
               }
               if ( Z66TicketTecnicoConfiguracion != T00082_A66TicketTecnicoConfiguracion[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoConfiguracion");
                  GXUtil.WriteLogRaw("Old: ",Z66TicketTecnicoConfiguracion);
                  GXUtil.WriteLogRaw("Current: ",T00082_A66TicketTecnicoConfiguracion[0]);
               }
               if ( Z73TicketTecnicoInternetRouter != T00082_A73TicketTecnicoInternetRouter[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoInternetRouter");
                  GXUtil.WriteLogRaw("Old: ",Z73TicketTecnicoInternetRouter);
                  GXUtil.WriteLogRaw("Current: ",T00082_A73TicketTecnicoInternetRouter[0]);
               }
               if ( Z70TicketTecnicoFormateo != T00082_A70TicketTecnicoFormateo[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoFormateo");
                  GXUtil.WriteLogRaw("Old: ",Z70TicketTecnicoFormateo);
                  GXUtil.WriteLogRaw("Current: ",T00082_A70TicketTecnicoFormateo[0]);
               }
               if ( Z84TicketTecnicoReparacion != T00082_A84TicketTecnicoReparacion[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoReparacion");
                  GXUtil.WriteLogRaw("Old: ",Z84TicketTecnicoReparacion);
                  GXUtil.WriteLogRaw("Current: ",T00082_A84TicketTecnicoReparacion[0]);
               }
               if ( Z75TicketTecnicoLimpieza != T00082_A75TicketTecnicoLimpieza[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoLimpieza");
                  GXUtil.WriteLogRaw("Old: ",Z75TicketTecnicoLimpieza);
                  GXUtil.WriteLogRaw("Current: ",T00082_A75TicketTecnicoLimpieza[0]);
               }
               if ( Z82TicketTecnicoPuntoRed != T00082_A82TicketTecnicoPuntoRed[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoPuntoRed");
                  GXUtil.WriteLogRaw("Old: ",Z82TicketTecnicoPuntoRed);
                  GXUtil.WriteLogRaw("Current: ",T00082_A82TicketTecnicoPuntoRed[0]);
               }
               if ( Z62TicketTecnicoCambiosHardware != T00082_A62TicketTecnicoCambiosHardware[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoCambiosHardware");
                  GXUtil.WriteLogRaw("Old: ",Z62TicketTecnicoCambiosHardware);
                  GXUtil.WriteLogRaw("Current: ",T00082_A62TicketTecnicoCambiosHardware[0]);
               }
               if ( Z67TicketTecnicoCopiasRespaldo != T00082_A67TicketTecnicoCopiasRespaldo[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoCopiasRespaldo");
                  GXUtil.WriteLogRaw("Old: ",Z67TicketTecnicoCopiasRespaldo);
                  GXUtil.WriteLogRaw("Current: ",T00082_A67TicketTecnicoCopiasRespaldo[0]);
               }
               if ( Z83TicketTecnicoRam != T00082_A83TicketTecnicoRam[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoRam");
                  GXUtil.WriteLogRaw("Old: ",Z83TicketTecnicoRam);
                  GXUtil.WriteLogRaw("Current: ",T00082_A83TicketTecnicoRam[0]);
               }
               if ( Z68TicketTecnicoDiscoDuro != T00082_A68TicketTecnicoDiscoDuro[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoDiscoDuro");
                  GXUtil.WriteLogRaw("Old: ",Z68TicketTecnicoDiscoDuro);
                  GXUtil.WriteLogRaw("Current: ",T00082_A68TicketTecnicoDiscoDuro[0]);
               }
               if ( Z81TicketTecnicoProcesador != T00082_A81TicketTecnicoProcesador[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoProcesador");
                  GXUtil.WriteLogRaw("Old: ",Z81TicketTecnicoProcesador);
                  GXUtil.WriteLogRaw("Current: ",T00082_A81TicketTecnicoProcesador[0]);
               }
               if ( Z76TicketTecnicoMaletin != T00082_A76TicketTecnicoMaletin[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoMaletin");
                  GXUtil.WriteLogRaw("Old: ",Z76TicketTecnicoMaletin);
                  GXUtil.WriteLogRaw("Current: ",T00082_A76TicketTecnicoMaletin[0]);
               }
               if ( Z86TicketTecnicoTonerCinta != T00082_A86TicketTecnicoTonerCinta[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoTonerCinta");
                  GXUtil.WriteLogRaw("Old: ",Z86TicketTecnicoTonerCinta);
                  GXUtil.WriteLogRaw("Current: ",T00082_A86TicketTecnicoTonerCinta[0]);
               }
               if ( Z85TicketTecnicoTarjetaVideoExtra != T00082_A85TicketTecnicoTarjetaVideoExtra[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoTarjetaVideoExtra");
                  GXUtil.WriteLogRaw("Old: ",Z85TicketTecnicoTarjetaVideoExtra);
                  GXUtil.WriteLogRaw("Current: ",T00082_A85TicketTecnicoTarjetaVideoExtra[0]);
               }
               if ( Z63TicketTecnicoCargadorLaptop != T00082_A63TicketTecnicoCargadorLaptop[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoCargadorLaptop");
                  GXUtil.WriteLogRaw("Old: ",Z63TicketTecnicoCargadorLaptop);
                  GXUtil.WriteLogRaw("Current: ",T00082_A63TicketTecnicoCargadorLaptop[0]);
               }
               if ( Z64TicketTecnicoCDsDVDs != T00082_A64TicketTecnicoCDsDVDs[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoCDsDVDs");
                  GXUtil.WriteLogRaw("Old: ",Z64TicketTecnicoCDsDVDs);
                  GXUtil.WriteLogRaw("Current: ",T00082_A64TicketTecnicoCDsDVDs[0]);
               }
               if ( Z61TicketTecnicoCableEspecial != T00082_A61TicketTecnicoCableEspecial[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoCableEspecial");
                  GXUtil.WriteLogRaw("Old: ",Z61TicketTecnicoCableEspecial);
                  GXUtil.WriteLogRaw("Current: ",T00082_A61TicketTecnicoCableEspecial[0]);
               }
               if ( Z78TicketTecnicoOtrosTaller != T00082_A78TicketTecnicoOtrosTaller[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoOtrosTaller");
                  GXUtil.WriteLogRaw("Old: ",Z78TicketTecnicoOtrosTaller);
                  GXUtil.WriteLogRaw("Current: ",T00082_A78TicketTecnicoOtrosTaller[0]);
               }
               if ( Z65TicketTecnicoCerrado != T00082_A65TicketTecnicoCerrado[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoCerrado");
                  GXUtil.WriteLogRaw("Old: ",Z65TicketTecnicoCerrado);
                  GXUtil.WriteLogRaw("Current: ",T00082_A65TicketTecnicoCerrado[0]);
               }
               if ( Z80TicketTecnicoPendiente != T00082_A80TicketTecnicoPendiente[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoPendiente");
                  GXUtil.WriteLogRaw("Old: ",Z80TicketTecnicoPendiente);
                  GXUtil.WriteLogRaw("Current: ",T00082_A80TicketTecnicoPendiente[0]);
               }
               if ( Z79TicketTecnicoPasaTaller != T00082_A79TicketTecnicoPasaTaller[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoPasaTaller");
                  GXUtil.WriteLogRaw("Old: ",Z79TicketTecnicoPasaTaller);
                  GXUtil.WriteLogRaw("Current: ",T00082_A79TicketTecnicoPasaTaller[0]);
               }
               if ( Z77TicketTecnicoObservacion != T00082_A77TicketTecnicoObservacion[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoObservacion");
                  GXUtil.WriteLogRaw("Old: ",Z77TicketTecnicoObservacion);
                  GXUtil.WriteLogRaw("Current: ",T00082_A77TicketTecnicoObservacion[0]);
               }
               if ( StringUtil.StrCmp(Z97TicketTecnicoDetalle, T00082_A97TicketTecnicoDetalle[0]) != 0 )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketTecnicoDetalle");
                  GXUtil.WriteLogRaw("Old: ",Z97TicketTecnicoDetalle);
                  GXUtil.WriteLogRaw("Current: ",T00082_A97TicketTecnicoDetalle[0]);
               }
               if ( Z14TicketId != T00082_A14TicketId[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketId");
                  GXUtil.WriteLogRaw("Old: ",Z14TicketId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A14TicketId[0]);
               }
               if ( Z6ResponsableId != T00082_A6ResponsableId[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"ResponsableId");
                  GXUtil.WriteLogRaw("Old: ",Z6ResponsableId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A6ResponsableId[0]);
               }
               if ( Z16TicketResponsableId != T00082_A16TicketResponsableId[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"TicketResponsableId");
                  GXUtil.WriteLogRaw("Old: ",Z16TicketResponsableId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A16TicketResponsableId[0]);
               }
               if ( Z171SgActividadId != T00082_A171SgActividadId[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"SgActividadId");
                  GXUtil.WriteLogRaw("Old: ",Z171SgActividadId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A171SgActividadId[0]);
               }
               if ( Z173SgActividadIdCategoria != T00082_A173SgActividadIdCategoria[0] )
               {
                  GXUtil.WriteLog("tickettecnico:[seudo value changed for attri]"+"SgActividadIdCategoria");
                  GXUtil.WriteLogRaw("Old: ",Z173SgActividadIdCategoria);
                  GXUtil.WriteLogRaw("Current: ",T00082_A173SgActividadIdCategoria[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TicketTecnico"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert089( )
      {
         if ( ! IsAuthorized("tickettecnico_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM089( 0) ;
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000820 */
                     pr_default.execute(14, new Object[] {A69TicketTecnicoFecha, A71TicketTecnicoHora, A74TicketTecnicoInventarioSerie, A72TicketTecnicoInstalacion, A66TicketTecnicoConfiguracion, A73TicketTecnicoInternetRouter, A70TicketTecnicoFormateo, A84TicketTecnicoReparacion, A75TicketTecnicoLimpieza, A82TicketTecnicoPuntoRed, A62TicketTecnicoCambiosHardware, A67TicketTecnicoCopiasRespaldo, A83TicketTecnicoRam, A68TicketTecnicoDiscoDuro, A81TicketTecnicoProcesador, A76TicketTecnicoMaletin, A86TicketTecnicoTonerCinta, A85TicketTecnicoTarjetaVideoExtra, A63TicketTecnicoCargadorLaptop, A64TicketTecnicoCDsDVDs, A61TicketTecnicoCableEspecial, A78TicketTecnicoOtrosTaller, A65TicketTecnicoCerrado, A80TicketTecnicoPendiente, A79TicketTecnicoPasaTaller, n77TicketTecnicoObservacion, A77TicketTecnicoObservacion, A97TicketTecnicoDetalle, A14TicketId, A6ResponsableId, A16TicketResponsableId, A171SgActividadId, A173SgActividadIdCategoria});
                     A18TicketTecnicoId = T000820_A18TicketTecnicoId[0];
                     AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("TicketTecnico");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
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
               Load089( ) ;
            }
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void Update089( )
      {
         if ( ! IsAuthorized("tickettecnico_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable089( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm089( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate089( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000821 */
                     pr_default.execute(15, new Object[] {A69TicketTecnicoFecha, A71TicketTecnicoHora, A74TicketTecnicoInventarioSerie, A72TicketTecnicoInstalacion, A66TicketTecnicoConfiguracion, A73TicketTecnicoInternetRouter, A70TicketTecnicoFormateo, A84TicketTecnicoReparacion, A75TicketTecnicoLimpieza, A82TicketTecnicoPuntoRed, A62TicketTecnicoCambiosHardware, A67TicketTecnicoCopiasRespaldo, A83TicketTecnicoRam, A68TicketTecnicoDiscoDuro, A81TicketTecnicoProcesador, A76TicketTecnicoMaletin, A86TicketTecnicoTonerCinta, A85TicketTecnicoTarjetaVideoExtra, A63TicketTecnicoCargadorLaptop, A64TicketTecnicoCDsDVDs, A61TicketTecnicoCableEspecial, A78TicketTecnicoOtrosTaller, A65TicketTecnicoCerrado, A80TicketTecnicoPendiente, A79TicketTecnicoPasaTaller, n77TicketTecnicoObservacion, A77TicketTecnicoObservacion, A97TicketTecnicoDetalle, A14TicketId, A6ResponsableId, A16TicketResponsableId, A171SgActividadId, A173SgActividadIdCategoria, A18TicketTecnicoId});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("TicketTecnico");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TicketTecnico"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate089( ) ;
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
            EndLevel089( ) ;
         }
         CloseExtendedTableCursors089( ) ;
      }

      protected void DeferredUpdate089( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tickettecnico_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate089( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency089( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls089( ) ;
            AfterConfirm089( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete089( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000822 */
                  pr_default.execute(16, new Object[] {A18TicketTecnicoId});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("TicketTecnico");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel089( ) ;
         Gx_mode = sMode9;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls089( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV34Pgmname = "TicketTecnico";
            AssignAttri(sPrefix, false, "AV34Pgmname", AV34Pgmname);
            /* Using cursor T000823 */
            pr_default.execute(17, new Object[] {A14TicketId});
            A15UsuarioId = T000823_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            pr_default.close(17);
            /* Using cursor T000824 */
            pr_default.execute(18, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T000824_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T000824_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A88UsuarioDepartamento = T000824_A88UsuarioDepartamento[0];
            AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
            pr_default.close(18);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
            }
            /* Using cursor T000825 */
            pr_default.execute(19, new Object[] {A6ResponsableId});
            A30ResponsableNombre = T000825_A30ResponsableNombre[0];
            AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
            pr_default.close(19);
            /* Using cursor T000826 */
            pr_datastore1.execute(4, new Object[] {A171SgActividadId});
            A123nombre_actividad = T000826_A123nombre_actividad[0];
            n123nombre_actividad = T000826_n123nombre_actividad[0];
            A172SgActividadNombre = T000826_A123nombre_actividad[0];
            AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
            pr_datastore1.close(4);
            /* Using cursor T000827 */
            pr_datastore1.execute(5, new Object[] {A173SgActividadIdCategoria});
            A106nombre_categoria = T000827_A106nombre_categoria[0];
            n106nombre_categoria = T000827_n106nombre_categoria[0];
            A174SgActividadNombreCategoria = T000827_A106nombre_categoria[0];
            AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
            pr_datastore1.close(5);
         }
      }

      protected void EndLevel089( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete089( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(19);
            pr_datastore1.close(4);
            pr_datastore1.close(5);
            pr_default.close(18);
            context.CommitDataStores("tickettecnico",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(19);
            pr_datastore1.close(4);
            pr_datastore1.close(5);
            pr_default.close(18);
            context.RollbackDataStores("tickettecnico",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart089( )
      {
         /* Scan By routine */
         /* Using cursor T000828 */
         pr_default.execute(20);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound9 = 1;
            A18TicketTecnicoId = T000828_A18TicketTecnicoId[0];
            AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext089( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound9 = 1;
            A18TicketTecnicoId = T000828_A18TicketTecnicoId[0];
            AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
         }
      }

      protected void ScanEnd089( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm089( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert089( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate089( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete089( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete089( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate089( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes089( )
      {
         edtTicketTecnicoId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoId_Enabled), 5, 0), true);
         edtTicketResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), true);
         edtTicketId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         edtTicketTecnicoFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoFecha_Enabled), 5, 0), true);
         edtTicketTecnicoHora_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoHora_Enabled), 5, 0), true);
         edtResponsableNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableNombre_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtResponsableId_Enabled), 5, 0), true);
         edtUsuarioDepartamento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioDepartamento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioDepartamento_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioRequerimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         edtTicketTecnicoInventarioSerie_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoInventarioSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoInventarioSerie_Enabled), 5, 0), true);
         chkTicketTecnicoInstalacion.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoInstalacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoInstalacion.Enabled), 5, 0), true);
         chkTicketTecnicoConfiguracion.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoConfiguracion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoConfiguracion.Enabled), 5, 0), true);
         chkTicketTecnicoInternetRouter.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoInternetRouter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoInternetRouter.Enabled), 5, 0), true);
         chkTicketTecnicoFormateo.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoFormateo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoFormateo.Enabled), 5, 0), true);
         chkTicketTecnicoReparacion.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoReparacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoReparacion.Enabled), 5, 0), true);
         chkTicketTecnicoLimpieza.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoLimpieza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoLimpieza.Enabled), 5, 0), true);
         chkTicketTecnicoPuntoRed.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoPuntoRed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoPuntoRed.Enabled), 5, 0), true);
         chkTicketTecnicoCambiosHardware.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoCambiosHardware_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCambiosHardware.Enabled), 5, 0), true);
         chkTicketTecnicoCopiasRespaldo.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoCopiasRespaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCopiasRespaldo.Enabled), 5, 0), true);
         chkTicketTecnicoCerrado.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoCerrado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCerrado.Enabled), 5, 0), true);
         chkTicketTecnicoPendiente.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoPendiente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoPendiente.Enabled), 5, 0), true);
         chkTicketTecnicoPasaTaller.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoPasaTaller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoPasaTaller.Enabled), 5, 0), true);
         chkTicketTecnicoObservacion.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoObservacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoObservacion.Enabled), 5, 0), true);
         edtTicketTecnicoDetalle_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoDetalle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoDetalle_Enabled), 5, 0), true);
         chkTicketTecnicoRam.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoRam_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoRam.Enabled), 5, 0), true);
         chkTicketTecnicoDiscoDuro.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoDiscoDuro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoDiscoDuro.Enabled), 5, 0), true);
         chkTicketTecnicoProcesador.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoProcesador_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoProcesador.Enabled), 5, 0), true);
         chkTicketTecnicoMaletin.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoMaletin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoMaletin.Enabled), 5, 0), true);
         chkTicketTecnicoTonerCinta.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoTonerCinta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoTonerCinta.Enabled), 5, 0), true);
         chkTicketTecnicoTarjetaVideoExtra.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoTarjetaVideoExtra.Enabled), 5, 0), true);
         chkTicketTecnicoCargadorLaptop.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoCargadorLaptop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCargadorLaptop.Enabled), 5, 0), true);
         chkTicketTecnicoCDsDVDs.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoCDsDVDs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCDsDVDs.Enabled), 5, 0), true);
         chkTicketTecnicoCableEspecial.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoCableEspecial_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoCableEspecial.Enabled), 5, 0), true);
         chkTicketTecnicoOtrosTaller.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketTecnicoOtrosTaller_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketTecnicoOtrosTaller.Enabled), 5, 0), true);
         edtSgActividadIdCategoria_Enabled = 0;
         AssignProp(sPrefix, false, edtSgActividadIdCategoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadIdCategoria_Enabled), 5, 0), true);
         edtSgActividadNombreCategoria_Enabled = 0;
         AssignProp(sPrefix, false, edtSgActividadNombreCategoria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadNombreCategoria_Enabled), 5, 0), true);
         edtSgActividadId_Enabled = 0;
         AssignProp(sPrefix, false, edtSgActividadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadId_Enabled), 5, 0), true);
         edtSgActividadNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSgActividadNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSgActividadNombre_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes089( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.AddJavascriptSource("gxcfg.js", "?20231249502222", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tickettecnico.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TicketTecnicoId,10,0))}, new string[] {"Gx_mode","TicketTecnicoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"TicketTecnico");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tickettecnico:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z18TicketTecnicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z18TicketTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z69TicketTecnicoFecha", context.localUtil.DToC( Z69TicketTecnicoFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z71TicketTecnicoHora", context.localUtil.TToC( Z71TicketTecnicoHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z74TicketTecnicoInventarioSerie", Z74TicketTecnicoInventarioSerie);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z72TicketTecnicoInstalacion", Z72TicketTecnicoInstalacion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z66TicketTecnicoConfiguracion", Z66TicketTecnicoConfiguracion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z73TicketTecnicoInternetRouter", Z73TicketTecnicoInternetRouter);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z70TicketTecnicoFormateo", Z70TicketTecnicoFormateo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z84TicketTecnicoReparacion", Z84TicketTecnicoReparacion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z75TicketTecnicoLimpieza", Z75TicketTecnicoLimpieza);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z82TicketTecnicoPuntoRed", Z82TicketTecnicoPuntoRed);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z62TicketTecnicoCambiosHardware", Z62TicketTecnicoCambiosHardware);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z67TicketTecnicoCopiasRespaldo", Z67TicketTecnicoCopiasRespaldo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z83TicketTecnicoRam", Z83TicketTecnicoRam);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z68TicketTecnicoDiscoDuro", Z68TicketTecnicoDiscoDuro);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z81TicketTecnicoProcesador", Z81TicketTecnicoProcesador);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z76TicketTecnicoMaletin", Z76TicketTecnicoMaletin);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z86TicketTecnicoTonerCinta", Z86TicketTecnicoTonerCinta);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z85TicketTecnicoTarjetaVideoExtra", Z85TicketTecnicoTarjetaVideoExtra);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z63TicketTecnicoCargadorLaptop", Z63TicketTecnicoCargadorLaptop);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z64TicketTecnicoCDsDVDs", Z64TicketTecnicoCDsDVDs);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z61TicketTecnicoCableEspecial", Z61TicketTecnicoCableEspecial);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z78TicketTecnicoOtrosTaller", Z78TicketTecnicoOtrosTaller);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z65TicketTecnicoCerrado", Z65TicketTecnicoCerrado);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z80TicketTecnicoPendiente", Z80TicketTecnicoPendiente);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z79TicketTecnicoPasaTaller", Z79TicketTecnicoPasaTaller);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z77TicketTecnicoObservacion", Z77TicketTecnicoObservacion);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z97TicketTecnicoDetalle", Z97TicketTecnicoDetalle);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z6ResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6ResponsableId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z16TicketResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16TicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z171SgActividadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z171SgActividadId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z173SgActividadIdCategoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z173SgActividadIdCategoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7TicketTecnicoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7TicketTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N16TicketResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N171SgActividadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A171SgActividadId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N173SgActividadIdCategoria", StringUtil.LTrim( StringUtil.NToC( (decimal)(A173SgActividadIdCategoria), 9, 0, ",", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV22AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV22AttributeValue);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vATTRIBUTEVALUE", GetSecureSignedToken( sPrefix, AV22AttributeValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV10Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV10Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV10Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vTICKETTECNICOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TicketTecnicoId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_TICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_TICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_TicketResponsableId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SGACTIVIDADID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV31Insert_SgActividadId), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SGACTIVIDADIDCATEGORIA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32Insert_SgActividadIdCategoria), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV34Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm089( )
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
         return "TicketTecnico" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ticket Tecnico" ;
      }

      protected void InitializeNonKey089( )
      {
         A104categoria_tareaid_tipo_categoria = 0;
         AssignAttri(sPrefix, false, "A104categoria_tareaid_tipo_categoria", StringUtil.LTrimStr( (decimal)(A104categoria_tareaid_tipo_categoria), 9, 0));
         A102id_actividad_categoria = 0;
         AssignAttri(sPrefix, false, "A102id_actividad_categoria", StringUtil.LTrimStr( (decimal)(A102id_actividad_categoria), 9, 0));
         A14TicketId = 0;
         AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         A16TicketResponsableId = 0;
         AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
         A171SgActividadId = 0;
         AssignAttri(sPrefix, false, "A171SgActividadId", StringUtil.LTrimStr( (decimal)(A171SgActividadId), 9, 0));
         A173SgActividadIdCategoria = 0;
         AssignAttri(sPrefix, false, "A173SgActividadIdCategoria", StringUtil.LTrimStr( (decimal)(A173SgActividadIdCategoria), 9, 0));
         A6ResponsableId = 0;
         AssignAttri(sPrefix, false, "A6ResponsableId", StringUtil.LTrimStr( (decimal)(A6ResponsableId), 4, 0));
         A30ResponsableNombre = "";
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
         A15UsuarioId = 0;
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         A93UsuarioNombre = "";
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = "";
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A88UsuarioDepartamento = "";
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         A74TicketTecnicoInventarioSerie = "";
         AssignAttri(sPrefix, false, "A74TicketTecnicoInventarioSerie", A74TicketTecnicoInventarioSerie);
         A72TicketTecnicoInstalacion = false;
         AssignAttri(sPrefix, false, "A72TicketTecnicoInstalacion", A72TicketTecnicoInstalacion);
         A66TicketTecnicoConfiguracion = false;
         AssignAttri(sPrefix, false, "A66TicketTecnicoConfiguracion", A66TicketTecnicoConfiguracion);
         A73TicketTecnicoInternetRouter = false;
         AssignAttri(sPrefix, false, "A73TicketTecnicoInternetRouter", A73TicketTecnicoInternetRouter);
         A70TicketTecnicoFormateo = false;
         AssignAttri(sPrefix, false, "A70TicketTecnicoFormateo", A70TicketTecnicoFormateo);
         A84TicketTecnicoReparacion = false;
         AssignAttri(sPrefix, false, "A84TicketTecnicoReparacion", A84TicketTecnicoReparacion);
         A75TicketTecnicoLimpieza = false;
         AssignAttri(sPrefix, false, "A75TicketTecnicoLimpieza", A75TicketTecnicoLimpieza);
         A82TicketTecnicoPuntoRed = false;
         AssignAttri(sPrefix, false, "A82TicketTecnicoPuntoRed", A82TicketTecnicoPuntoRed);
         A62TicketTecnicoCambiosHardware = false;
         AssignAttri(sPrefix, false, "A62TicketTecnicoCambiosHardware", A62TicketTecnicoCambiosHardware);
         A67TicketTecnicoCopiasRespaldo = false;
         AssignAttri(sPrefix, false, "A67TicketTecnicoCopiasRespaldo", A67TicketTecnicoCopiasRespaldo);
         A83TicketTecnicoRam = false;
         AssignAttri(sPrefix, false, "A83TicketTecnicoRam", A83TicketTecnicoRam);
         A68TicketTecnicoDiscoDuro = false;
         AssignAttri(sPrefix, false, "A68TicketTecnicoDiscoDuro", A68TicketTecnicoDiscoDuro);
         A81TicketTecnicoProcesador = false;
         AssignAttri(sPrefix, false, "A81TicketTecnicoProcesador", A81TicketTecnicoProcesador);
         A76TicketTecnicoMaletin = false;
         AssignAttri(sPrefix, false, "A76TicketTecnicoMaletin", A76TicketTecnicoMaletin);
         A86TicketTecnicoTonerCinta = false;
         AssignAttri(sPrefix, false, "A86TicketTecnicoTonerCinta", A86TicketTecnicoTonerCinta);
         A85TicketTecnicoTarjetaVideoExtra = false;
         AssignAttri(sPrefix, false, "A85TicketTecnicoTarjetaVideoExtra", A85TicketTecnicoTarjetaVideoExtra);
         A63TicketTecnicoCargadorLaptop = false;
         AssignAttri(sPrefix, false, "A63TicketTecnicoCargadorLaptop", A63TicketTecnicoCargadorLaptop);
         A64TicketTecnicoCDsDVDs = false;
         AssignAttri(sPrefix, false, "A64TicketTecnicoCDsDVDs", A64TicketTecnicoCDsDVDs);
         A61TicketTecnicoCableEspecial = false;
         AssignAttri(sPrefix, false, "A61TicketTecnicoCableEspecial", A61TicketTecnicoCableEspecial);
         A78TicketTecnicoOtrosTaller = false;
         AssignAttri(sPrefix, false, "A78TicketTecnicoOtrosTaller", A78TicketTecnicoOtrosTaller);
         A65TicketTecnicoCerrado = false;
         AssignAttri(sPrefix, false, "A65TicketTecnicoCerrado", A65TicketTecnicoCerrado);
         A80TicketTecnicoPendiente = false;
         AssignAttri(sPrefix, false, "A80TicketTecnicoPendiente", A80TicketTecnicoPendiente);
         A79TicketTecnicoPasaTaller = false;
         AssignAttri(sPrefix, false, "A79TicketTecnicoPasaTaller", A79TicketTecnicoPasaTaller);
         A77TicketTecnicoObservacion = false;
         n77TicketTecnicoObservacion = false;
         AssignAttri(sPrefix, false, "A77TicketTecnicoObservacion", A77TicketTecnicoObservacion);
         n77TicketTecnicoObservacion = ((false==A77TicketTecnicoObservacion) ? true : false);
         A97TicketTecnicoDetalle = "";
         AssignAttri(sPrefix, false, "A97TicketTecnicoDetalle", A97TicketTecnicoDetalle);
         A172SgActividadNombre = "";
         AssignAttri(sPrefix, false, "A172SgActividadNombre", A172SgActividadNombre);
         A174SgActividadNombreCategoria = "";
         AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
         A69TicketTecnicoFecha = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
         A71TicketTecnicoHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
         Z69TicketTecnicoFecha = DateTime.MinValue;
         Z71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         Z74TicketTecnicoInventarioSerie = "";
         Z72TicketTecnicoInstalacion = false;
         Z66TicketTecnicoConfiguracion = false;
         Z73TicketTecnicoInternetRouter = false;
         Z70TicketTecnicoFormateo = false;
         Z84TicketTecnicoReparacion = false;
         Z75TicketTecnicoLimpieza = false;
         Z82TicketTecnicoPuntoRed = false;
         Z62TicketTecnicoCambiosHardware = false;
         Z67TicketTecnicoCopiasRespaldo = false;
         Z83TicketTecnicoRam = false;
         Z68TicketTecnicoDiscoDuro = false;
         Z81TicketTecnicoProcesador = false;
         Z76TicketTecnicoMaletin = false;
         Z86TicketTecnicoTonerCinta = false;
         Z85TicketTecnicoTarjetaVideoExtra = false;
         Z63TicketTecnicoCargadorLaptop = false;
         Z64TicketTecnicoCDsDVDs = false;
         Z61TicketTecnicoCableEspecial = false;
         Z78TicketTecnicoOtrosTaller = false;
         Z65TicketTecnicoCerrado = false;
         Z80TicketTecnicoPendiente = false;
         Z79TicketTecnicoPasaTaller = false;
         Z77TicketTecnicoObservacion = false;
         Z97TicketTecnicoDetalle = "";
         Z14TicketId = 0;
         Z6ResponsableId = 0;
         Z16TicketResponsableId = 0;
         Z171SgActividadId = 0;
         Z173SgActividadIdCategoria = 0;
      }

      protected void InitAll089( )
      {
         A18TicketTecnicoId = 0;
         AssignAttri(sPrefix, false, "A18TicketTecnicoId", StringUtil.LTrimStr( (decimal)(A18TicketTecnicoId), 10, 0));
         InitializeNonKey089( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A69TicketTecnicoFecha = i69TicketTecnicoFecha;
         AssignAttri(sPrefix, false, "A69TicketTecnicoFecha", context.localUtil.Format(A69TicketTecnicoFecha, "99/99/9999"));
         A71TicketTecnicoHora = i71TicketTecnicoHora;
         AssignAttri(sPrefix, false, "A71TicketTecnicoHora", context.localUtil.TToC( A71TicketTecnicoHora, 0, 5, 0, 3, "/", ":", " "));
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7TicketTecnicoId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "tickettecnico", GetJustCreated( ));
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
            AV7TicketTecnicoId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7TicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV7TicketTecnicoId), 10, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7TicketTecnicoId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7TicketTecnicoId != wcpOAV7TicketTecnicoId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7TicketTecnicoId = AV7TicketTecnicoId;
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
         sCtrlAV7TicketTecnicoId = cgiGet( sPrefix+"AV7TicketTecnicoId_CTRL");
         if ( StringUtil.Len( sCtrlAV7TicketTecnicoId) > 0 )
         {
            AV7TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV7TicketTecnicoId), ",", "."));
            AssignAttri(sPrefix, false, "AV7TicketTecnicoId", StringUtil.LTrimStr( (decimal)(AV7TicketTecnicoId), 10, 0));
         }
         else
         {
            AV7TicketTecnicoId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV7TicketTecnicoId_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7TicketTecnicoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TicketTecnicoId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7TicketTecnicoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7TicketTecnicoId_CTRL", StringUtil.RTrim( sCtrlAV7TicketTecnicoId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249502271", true, true);
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
         context.AddJavascriptSource("tickettecnico.js", "?20231249502273", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         lblTxttrabajo_Internalname = sPrefix+"TXTTRABAJO";
         divTabletextblocktxttrabajocontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTTRABAJOCONTAINER";
         edtTicketTecnicoId_Internalname = sPrefix+"TICKETTECNICOID";
         divK2btoolstable_attributecontainertickettecnicoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOID";
         edtTicketResponsableId_Internalname = sPrefix+"TICKETRESPONSABLEID";
         divK2btoolstable_attributecontainerticketresponsableid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETRESPONSABLEID";
         divTableclmid0_Internalname = sPrefix+"TABLECLMID0";
         edtTicketId_Internalname = sPrefix+"TICKETID";
         divK2btoolstable_attributecontainerticketid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETID";
         divTableclmid1_Internalname = sPrefix+"TABLECLMID1";
         divClmid_Internalname = sPrefix+"CLMID";
         edtTicketTecnicoFecha_Internalname = sPrefix+"TICKETTECNICOFECHA";
         divK2btoolstable_attributecontainertickettecnicofecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOFECHA";
         divTableclmfecha0_Internalname = sPrefix+"TABLECLMFECHA0";
         edtTicketTecnicoHora_Internalname = sPrefix+"TICKETTECNICOHORA";
         divK2btoolstable_attributecontainertickettecnicohora_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOHORA";
         divTableclmfecha1_Internalname = sPrefix+"TABLECLMFECHA1";
         divClmfecha_Internalname = sPrefix+"CLMFECHA";
         edtResponsableNombre_Internalname = sPrefix+"RESPONSABLENOMBRE";
         divK2btoolstable_attributecontainerresponsablenombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLENOMBRE";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         edtResponsableId_Internalname = sPrefix+"RESPONSABLEID";
         divK2btoolstable_attributecontainerresponsableid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERRESPONSABLEID";
         divTableclmtecnico0_Internalname = sPrefix+"TABLECLMTECNICO0";
         edtUsuarioDepartamento_Internalname = sPrefix+"USUARIODEPARTAMENTO";
         divK2btoolstable_attributecontainerusuariodepartamento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIODEPARTAMENTO";
         edtUsuarioId_Internalname = sPrefix+"USUARIOID";
         divK2btoolstable_attributecontainerusuarioid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOID";
         divTableclmtecnico1_Internalname = sPrefix+"TABLECLMTECNICO1";
         divClmtecnico_Internalname = sPrefix+"CLMTECNICO";
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO";
         divK2btoolstable_attributecontainerusuariorequerimiento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOREQUERIMIENTO";
         divTableclmreq0_Internalname = sPrefix+"TABLECLMREQ0";
         edtTicketTecnicoInventarioSerie_Internalname = sPrefix+"TICKETTECNICOINVENTARIOSERIE";
         divK2btoolstable_attributecontainertickettecnicoinventarioserie_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOINVENTARIOSERIE";
         divTableclmreq1_Internalname = sPrefix+"TABLECLMREQ1";
         divClmreq_Internalname = sPrefix+"CLMREQ";
         lblTxtacciones_Internalname = sPrefix+"TXTACCIONES";
         divTabletextblocktxtaccionescontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTACCIONESCONTAINER";
         chkTicketTecnicoInstalacion_Internalname = sPrefix+"TICKETTECNICOINSTALACION";
         divK2btoolstable_attributecontainertickettecnicoinstalacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOINSTALACION";
         chkTicketTecnicoConfiguracion_Internalname = sPrefix+"TICKETTECNICOCONFIGURACION";
         divK2btoolstable_attributecontainertickettecnicoconfiguracion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCONFIGURACION";
         chkTicketTecnicoInternetRouter_Internalname = sPrefix+"TICKETTECNICOINTERNETROUTER";
         divK2btoolstable_attributecontainertickettecnicointernetrouter_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOINTERNETROUTER";
         divTableclmacciones0_Internalname = sPrefix+"TABLECLMACCIONES0";
         chkTicketTecnicoFormateo_Internalname = sPrefix+"TICKETTECNICOFORMATEO";
         divK2btoolstable_attributecontainertickettecnicoformateo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOFORMATEO";
         chkTicketTecnicoReparacion_Internalname = sPrefix+"TICKETTECNICOREPARACION";
         divK2btoolstable_attributecontainertickettecnicoreparacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOREPARACION";
         chkTicketTecnicoLimpieza_Internalname = sPrefix+"TICKETTECNICOLIMPIEZA";
         divK2btoolstable_attributecontainertickettecnicolimpieza_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOLIMPIEZA";
         divTableclmacciones1_Internalname = sPrefix+"TABLECLMACCIONES1";
         chkTicketTecnicoPuntoRed_Internalname = sPrefix+"TICKETTECNICOPUNTORED";
         divK2btoolstable_attributecontainertickettecnicopuntored_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOPUNTORED";
         chkTicketTecnicoCambiosHardware_Internalname = sPrefix+"TICKETTECNICOCAMBIOSHARDWARE";
         divK2btoolstable_attributecontainertickettecnicocambioshardware_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCAMBIOSHARDWARE";
         chkTicketTecnicoCopiasRespaldo_Internalname = sPrefix+"TICKETTECNICOCOPIASRESPALDO";
         divK2btoolstable_attributecontainertickettecnicocopiasrespaldo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCOPIASRESPALDO";
         divTableclmacciones2_Internalname = sPrefix+"TABLECLMACCIONES2";
         divClmacciones_Internalname = sPrefix+"CLMACCIONES";
         lblTxtestado_Internalname = sPrefix+"TXTESTADO";
         divTabletextblocktxtestadocontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTESTADOCONTAINER";
         chkTicketTecnicoCerrado_Internalname = sPrefix+"TICKETTECNICOCERRADO";
         divK2btoolstable_attributecontainertickettecnicocerrado_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCERRADO";
         chkTicketTecnicoPendiente_Internalname = sPrefix+"TICKETTECNICOPENDIENTE";
         divK2btoolstable_attributecontainertickettecnicopendiente_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOPENDIENTE";
         chkTicketTecnicoPasaTaller_Internalname = sPrefix+"TICKETTECNICOPASATALLER";
         divK2btoolstable_attributecontainertickettecnicopasataller_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOPASATALLER";
         divTableclmestado0_Internalname = sPrefix+"TABLECLMESTADO0";
         chkTicketTecnicoObservacion_Internalname = sPrefix+"TICKETTECNICOOBSERVACION";
         divK2btoolstable_attributecontainertickettecnicoobservacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOOBSERVACION";
         edtTicketTecnicoDetalle_Internalname = sPrefix+"TICKETTECNICODETALLE";
         divK2btoolstable_attributecontainertickettecnicodetalle_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICODETALLE";
         divTableclmestado1_Internalname = sPrefix+"TABLECLMESTADO1";
         divClmestado_Internalname = sPrefix+"CLMESTADO";
         lblTxttaller_Internalname = sPrefix+"TXTTALLER";
         divTabletextblocktxttallercontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTTALLERCONTAINER";
         chkTicketTecnicoRam_Internalname = sPrefix+"TICKETTECNICORAM";
         divK2btoolstable_attributecontainertickettecnicoram_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICORAM";
         chkTicketTecnicoDiscoDuro_Internalname = sPrefix+"TICKETTECNICODISCODURO";
         divK2btoolstable_attributecontainertickettecnicodiscoduro_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICODISCODURO";
         chkTicketTecnicoProcesador_Internalname = sPrefix+"TICKETTECNICOPROCESADOR";
         divK2btoolstable_attributecontainertickettecnicoprocesador_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOPROCESADOR";
         chkTicketTecnicoMaletin_Internalname = sPrefix+"TICKETTECNICOMALETIN";
         divK2btoolstable_attributecontainertickettecnicomaletin_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOMALETIN";
         chkTicketTecnicoTonerCinta_Internalname = sPrefix+"TICKETTECNICOTONERCINTA";
         divK2btoolstable_attributecontainertickettecnicotonercinta_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOTONERCINTA";
         divTableclmtaller0_Internalname = sPrefix+"TABLECLMTALLER0";
         chkTicketTecnicoTarjetaVideoExtra_Internalname = sPrefix+"TICKETTECNICOTARJETAVIDEOEXTRA";
         divK2btoolstable_attributecontainertickettecnicotarjetavideoextra_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOTARJETAVIDEOEXTRA";
         chkTicketTecnicoCargadorLaptop_Internalname = sPrefix+"TICKETTECNICOCARGADORLAPTOP";
         divK2btoolstable_attributecontainertickettecnicocargadorlaptop_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCARGADORLAPTOP";
         chkTicketTecnicoCDsDVDs_Internalname = sPrefix+"TICKETTECNICOCDSDVDS";
         divK2btoolstable_attributecontainertickettecnicocdsdvds_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCDSDVDS";
         chkTicketTecnicoCableEspecial_Internalname = sPrefix+"TICKETTECNICOCABLEESPECIAL";
         divK2btoolstable_attributecontainertickettecnicocableespecial_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOCABLEESPECIAL";
         chkTicketTecnicoOtrosTaller_Internalname = sPrefix+"TICKETTECNICOOTROSTALLER";
         divK2btoolstable_attributecontainertickettecnicootrostaller_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICOOTROSTALLER";
         divTableclmtaller1_Internalname = sPrefix+"TABLECLMTALLER1";
         divClmtaller_Internalname = sPrefix+"CLMTALLER";
         edtSgActividadIdCategoria_Internalname = sPrefix+"SGACTIVIDADIDCATEGORIA";
         divK2btoolstable_attributecontainersgactividadidcategoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGACTIVIDADIDCATEGORIA";
         edtSgActividadNombreCategoria_Internalname = sPrefix+"SGACTIVIDADNOMBRECATEGORIA";
         divK2btoolstable_attributecontainersgactividadnombrecategoria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGACTIVIDADNOMBRECATEGORIA";
         divTableclcat0_Internalname = sPrefix+"TABLECLCAT0";
         edtSgActividadId_Internalname = sPrefix+"SGACTIVIDADID";
         divK2btoolstable_attributecontainersgactividadid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGACTIVIDADID";
         edtSgActividadNombre_Internalname = sPrefix+"SGACTIVIDADNOMBRE";
         divK2btoolstable_attributecontainersgactividadnombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSGACTIVIDADNOMBRE";
         divTableclcat1_Internalname = sPrefix+"TABLECLCAT1";
         divClcat_Internalname = sPrefix+"CLCAT";
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
         imgprompt_16_Internalname = sPrefix+"PROMPT_16";
         imgprompt_14_Internalname = sPrefix+"PROMPT_14";
         imgprompt_6_Internalname = sPrefix+"PROMPT_6";
         imgprompt_173_Internalname = sPrefix+"PROMPT_173";
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
         Form.Caption = "Ticket Tecnico";
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
         edtSgActividadNombreCategoria_Enabled = 0;
         imgprompt_173_Visible = 1;
         imgprompt_173_Link = "";
         edtSgActividadIdCategoria_Jsonclick = "";
         edtSgActividadIdCategoria_Enabled = 1;
         chkTicketTecnicoOtrosTaller.Enabled = 1;
         chkTicketTecnicoCableEspecial.Enabled = 1;
         chkTicketTecnicoCDsDVDs.Enabled = 1;
         chkTicketTecnicoCargadorLaptop.Enabled = 1;
         chkTicketTecnicoTarjetaVideoExtra.Enabled = 1;
         chkTicketTecnicoTonerCinta.Enabled = 1;
         chkTicketTecnicoMaletin.Enabled = 1;
         chkTicketTecnicoProcesador.Enabled = 1;
         chkTicketTecnicoDiscoDuro.Enabled = 1;
         chkTicketTecnicoRam.Enabled = 1;
         edtTicketTecnicoDetalle_Enabled = 1;
         chkTicketTecnicoObservacion.Enabled = 1;
         divK2btoolstable_attributecontainertickettecnicoobservacion_Visible = 1;
         chkTicketTecnicoPasaTaller.Enabled = 1;
         chkTicketTecnicoPendiente.Enabled = 1;
         chkTicketTecnicoCerrado.Enabled = 1;
         chkTicketTecnicoCopiasRespaldo.Enabled = 1;
         chkTicketTecnicoCambiosHardware.Enabled = 1;
         chkTicketTecnicoPuntoRed.Enabled = 1;
         chkTicketTecnicoLimpieza.Enabled = 1;
         chkTicketTecnicoReparacion.Enabled = 1;
         chkTicketTecnicoFormateo.Enabled = 1;
         chkTicketTecnicoInternetRouter.Enabled = 1;
         chkTicketTecnicoConfiguracion.Enabled = 1;
         chkTicketTecnicoInstalacion.Enabled = 1;
         edtTicketTecnicoInventarioSerie_Enabled = 1;
         edtUsuarioRequerimiento_Enabled = 0;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 0;
         divK2btoolstable_attributecontainerusuarioid_Visible = 1;
         edtUsuarioDepartamento_Enabled = 0;
         imgprompt_6_Visible = 1;
         imgprompt_6_Link = "";
         edtResponsableId_Jsonclick = "";
         edtResponsableId_Enabled = 1;
         divK2btoolstable_attributecontainerresponsableid_Visible = 1;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Link = "";
         edtUsuarioNombre_Enabled = 0;
         edtResponsableNombre_Jsonclick = "";
         edtResponsableNombre_Enabled = 0;
         edtTicketTecnicoHora_Jsonclick = "";
         edtTicketTecnicoHora_Enabled = 0;
         edtTicketTecnicoFecha_Jsonclick = "";
         edtTicketTecnicoFecha_Class = "Attribute_TrnDate Attribute_Required";
         edtTicketTecnicoFecha_Enabled = 0;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtTicketId_Jsonclick = "";
         edtTicketId_Enabled = 1;
         imgprompt_16_Visible = 1;
         imgprompt_16_Link = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketResponsableId_Enabled = 1;
         divK2btoolstable_attributecontainerticketresponsableid_Visible = 1;
         edtTicketTecnicoId_Jsonclick = "";
         edtTicketTecnicoId_Enabled = 0;
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

      protected void GXASA93089( short A15UsuarioId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
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
         chkTicketTecnicoInstalacion.Name = "TICKETTECNICOINSTALACION";
         chkTicketTecnicoInstalacion.WebTags = "";
         chkTicketTecnicoInstalacion.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoInstalacion_Internalname, "TitleCaption", chkTicketTecnicoInstalacion.Caption, true);
         chkTicketTecnicoInstalacion.CheckedValue = "false";
         chkTicketTecnicoConfiguracion.Name = "TICKETTECNICOCONFIGURACION";
         chkTicketTecnicoConfiguracion.WebTags = "";
         chkTicketTecnicoConfiguracion.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoConfiguracion_Internalname, "TitleCaption", chkTicketTecnicoConfiguracion.Caption, true);
         chkTicketTecnicoConfiguracion.CheckedValue = "false";
         chkTicketTecnicoInternetRouter.Name = "TICKETTECNICOINTERNETROUTER";
         chkTicketTecnicoInternetRouter.WebTags = "";
         chkTicketTecnicoInternetRouter.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoInternetRouter_Internalname, "TitleCaption", chkTicketTecnicoInternetRouter.Caption, true);
         chkTicketTecnicoInternetRouter.CheckedValue = "false";
         chkTicketTecnicoFormateo.Name = "TICKETTECNICOFORMATEO";
         chkTicketTecnicoFormateo.WebTags = "";
         chkTicketTecnicoFormateo.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoFormateo_Internalname, "TitleCaption", chkTicketTecnicoFormateo.Caption, true);
         chkTicketTecnicoFormateo.CheckedValue = "false";
         chkTicketTecnicoReparacion.Name = "TICKETTECNICOREPARACION";
         chkTicketTecnicoReparacion.WebTags = "";
         chkTicketTecnicoReparacion.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoReparacion_Internalname, "TitleCaption", chkTicketTecnicoReparacion.Caption, true);
         chkTicketTecnicoReparacion.CheckedValue = "false";
         chkTicketTecnicoLimpieza.Name = "TICKETTECNICOLIMPIEZA";
         chkTicketTecnicoLimpieza.WebTags = "";
         chkTicketTecnicoLimpieza.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoLimpieza_Internalname, "TitleCaption", chkTicketTecnicoLimpieza.Caption, true);
         chkTicketTecnicoLimpieza.CheckedValue = "false";
         chkTicketTecnicoPuntoRed.Name = "TICKETTECNICOPUNTORED";
         chkTicketTecnicoPuntoRed.WebTags = "";
         chkTicketTecnicoPuntoRed.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoPuntoRed_Internalname, "TitleCaption", chkTicketTecnicoPuntoRed.Caption, true);
         chkTicketTecnicoPuntoRed.CheckedValue = "false";
         chkTicketTecnicoCambiosHardware.Name = "TICKETTECNICOCAMBIOSHARDWARE";
         chkTicketTecnicoCambiosHardware.WebTags = "";
         chkTicketTecnicoCambiosHardware.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoCambiosHardware_Internalname, "TitleCaption", chkTicketTecnicoCambiosHardware.Caption, true);
         chkTicketTecnicoCambiosHardware.CheckedValue = "false";
         chkTicketTecnicoCopiasRespaldo.Name = "TICKETTECNICOCOPIASRESPALDO";
         chkTicketTecnicoCopiasRespaldo.WebTags = "";
         chkTicketTecnicoCopiasRespaldo.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoCopiasRespaldo_Internalname, "TitleCaption", chkTicketTecnicoCopiasRespaldo.Caption, true);
         chkTicketTecnicoCopiasRespaldo.CheckedValue = "false";
         chkTicketTecnicoCerrado.Name = "TICKETTECNICOCERRADO";
         chkTicketTecnicoCerrado.WebTags = "";
         chkTicketTecnicoCerrado.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoCerrado_Internalname, "TitleCaption", chkTicketTecnicoCerrado.Caption, true);
         chkTicketTecnicoCerrado.CheckedValue = "false";
         chkTicketTecnicoPendiente.Name = "TICKETTECNICOPENDIENTE";
         chkTicketTecnicoPendiente.WebTags = "";
         chkTicketTecnicoPendiente.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoPendiente_Internalname, "TitleCaption", chkTicketTecnicoPendiente.Caption, true);
         chkTicketTecnicoPendiente.CheckedValue = "false";
         chkTicketTecnicoPasaTaller.Name = "TICKETTECNICOPASATALLER";
         chkTicketTecnicoPasaTaller.WebTags = "";
         chkTicketTecnicoPasaTaller.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoPasaTaller_Internalname, "TitleCaption", chkTicketTecnicoPasaTaller.Caption, true);
         chkTicketTecnicoPasaTaller.CheckedValue = "false";
         chkTicketTecnicoObservacion.Name = "TICKETTECNICOOBSERVACION";
         chkTicketTecnicoObservacion.WebTags = "";
         chkTicketTecnicoObservacion.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoObservacion_Internalname, "TitleCaption", chkTicketTecnicoObservacion.Caption, true);
         chkTicketTecnicoObservacion.CheckedValue = "false";
         chkTicketTecnicoRam.Name = "TICKETTECNICORAM";
         chkTicketTecnicoRam.WebTags = "";
         chkTicketTecnicoRam.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoRam_Internalname, "TitleCaption", chkTicketTecnicoRam.Caption, true);
         chkTicketTecnicoRam.CheckedValue = "false";
         chkTicketTecnicoDiscoDuro.Name = "TICKETTECNICODISCODURO";
         chkTicketTecnicoDiscoDuro.WebTags = "";
         chkTicketTecnicoDiscoDuro.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoDiscoDuro_Internalname, "TitleCaption", chkTicketTecnicoDiscoDuro.Caption, true);
         chkTicketTecnicoDiscoDuro.CheckedValue = "false";
         chkTicketTecnicoProcesador.Name = "TICKETTECNICOPROCESADOR";
         chkTicketTecnicoProcesador.WebTags = "";
         chkTicketTecnicoProcesador.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoProcesador_Internalname, "TitleCaption", chkTicketTecnicoProcesador.Caption, true);
         chkTicketTecnicoProcesador.CheckedValue = "false";
         chkTicketTecnicoMaletin.Name = "TICKETTECNICOMALETIN";
         chkTicketTecnicoMaletin.WebTags = "";
         chkTicketTecnicoMaletin.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoMaletin_Internalname, "TitleCaption", chkTicketTecnicoMaletin.Caption, true);
         chkTicketTecnicoMaletin.CheckedValue = "false";
         chkTicketTecnicoTonerCinta.Name = "TICKETTECNICOTONERCINTA";
         chkTicketTecnicoTonerCinta.WebTags = "";
         chkTicketTecnicoTonerCinta.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoTonerCinta_Internalname, "TitleCaption", chkTicketTecnicoTonerCinta.Caption, true);
         chkTicketTecnicoTonerCinta.CheckedValue = "false";
         chkTicketTecnicoTarjetaVideoExtra.Name = "TICKETTECNICOTARJETAVIDEOEXTRA";
         chkTicketTecnicoTarjetaVideoExtra.WebTags = "";
         chkTicketTecnicoTarjetaVideoExtra.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoTarjetaVideoExtra_Internalname, "TitleCaption", chkTicketTecnicoTarjetaVideoExtra.Caption, true);
         chkTicketTecnicoTarjetaVideoExtra.CheckedValue = "false";
         chkTicketTecnicoCargadorLaptop.Name = "TICKETTECNICOCARGADORLAPTOP";
         chkTicketTecnicoCargadorLaptop.WebTags = "";
         chkTicketTecnicoCargadorLaptop.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoCargadorLaptop_Internalname, "TitleCaption", chkTicketTecnicoCargadorLaptop.Caption, true);
         chkTicketTecnicoCargadorLaptop.CheckedValue = "false";
         chkTicketTecnicoCDsDVDs.Name = "TICKETTECNICOCDSDVDS";
         chkTicketTecnicoCDsDVDs.WebTags = "";
         chkTicketTecnicoCDsDVDs.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoCDsDVDs_Internalname, "TitleCaption", chkTicketTecnicoCDsDVDs.Caption, true);
         chkTicketTecnicoCDsDVDs.CheckedValue = "false";
         chkTicketTecnicoCableEspecial.Name = "TICKETTECNICOCABLEESPECIAL";
         chkTicketTecnicoCableEspecial.WebTags = "";
         chkTicketTecnicoCableEspecial.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoCableEspecial_Internalname, "TitleCaption", chkTicketTecnicoCableEspecial.Caption, true);
         chkTicketTecnicoCableEspecial.CheckedValue = "false";
         chkTicketTecnicoOtrosTaller.Name = "TICKETTECNICOOTROSTALLER";
         chkTicketTecnicoOtrosTaller.WebTags = "";
         chkTicketTecnicoOtrosTaller.Caption = "";
         AssignProp(sPrefix, false, chkTicketTecnicoOtrosTaller_Internalname, "TitleCaption", chkTicketTecnicoOtrosTaller.Caption, true);
         chkTicketTecnicoOtrosTaller.CheckedValue = "false";
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

      public void Valid_Ticketid( )
      {
         /* Using cursor T000823 */
         pr_default.execute(17, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
         }
         A15UsuarioId = T000823_A15UsuarioId[0];
         pr_default.close(17);
         /* Using cursor T000824 */
         pr_default.execute(18, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000824_A93UsuarioNombre[0];
         A94UsuarioRequerimiento = T000824_A94UsuarioRequerimiento[0];
         A88UsuarioDepartamento = T000824_A88UsuarioDepartamento[0];
         pr_default.close(18);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         /* Using cursor T000829 */
         pr_default.execute(21, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "TICKETRESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ".", "")));
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
      }

      public void Valid_Responsableid( )
      {
         /* Using cursor T000825 */
         pr_default.execute(19, new Object[] {A6ResponsableId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "RESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtResponsableId_Internalname;
         }
         A30ResponsableNombre = T000825_A30ResponsableNombre[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A30ResponsableNombre", A30ResponsableNombre);
      }

      public void Valid_Sgactividadidcategoria( )
      {
         /* Using cursor T000827 */
         pr_datastore1.execute(5, new Object[] {A173SgActividadIdCategoria});
         if ( (pr_datastore1.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'categoria_tarea'.", "ForeignKeyNotFound", 1, "SGACTIVIDADIDCATEGORIA");
            AnyError = 1;
            GX_FocusControl = edtSgActividadIdCategoria_Internalname;
         }
         A106nombre_categoria = T000827_A106nombre_categoria[0];
         n106nombre_categoria = T000827_n106nombre_categoria[0];
         A174SgActividadNombreCategoria = T000827_A106nombre_categoria[0];
         pr_datastore1.close(5);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A174SgActividadNombreCategoria", A174SgActividadNombreCategoria);
      }

      public void Valid_Sgactividadid( )
      {
         /* Using cursor T000826 */
         pr_datastore1.execute(4, new Object[] {A171SgActividadId});
         if ( (pr_datastore1.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'actividades_categoria'.", "ForeignKeyNotFound", 1, "SGACTIVIDADID");
            AnyError = 1;
            GX_FocusControl = edtSgActividadId_Internalname;
         }
         A123nombre_actividad = T000826_A123nombre_actividad[0];
         n123nombre_actividad = T000826_n123nombre_actividad[0];
         A172SgActividadNombre = T000826_A123nombre_actividad[0];
         pr_datastore1.close(4);
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
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7TicketTecnicoId',fld:'vTICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12082',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A18TicketTecnicoId',fld:'TICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A69TicketTecnicoFecha',fld:'TICKETTECNICOFECHA',pic:''},{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV22AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A18TicketTecnicoId',fld:'TICKETTECNICOID',pic:'ZZZZZZZZZ9'},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13082',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("'DOCANCEL'",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICOID","{handler:'Valid_Tickettecnicoid',iparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICOID",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_TICKETRESPONSABLEID","{handler:'Valid_Ticketresponsableid',iparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_TICKETRESPONSABLEID",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9'},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'A16TicketResponsableId',fld:'TICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICOFECHA","{handler:'Valid_Tickettecnicofecha',iparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICOFECHA",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_RESPONSABLEID","{handler:'Valid_Responsableid',iparms:[{av:'A6ResponsableId',fld:'RESPONSABLEID',pic:'ZZZ9'},{av:'A30ResponsableNombre',fld:'RESPONSABLENOMBRE',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_RESPONSABLEID",",oparms:[{av:'A30ResponsableNombre',fld:'RESPONSABLENOMBRE',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_SGACTIVIDADIDCATEGORIA","{handler:'Valid_Sgactividadidcategoria',iparms:[{av:'A173SgActividadIdCategoria',fld:'SGACTIVIDADIDCATEGORIA',pic:'ZZZZZZZZ9'},{av:'A174SgActividadNombreCategoria',fld:'SGACTIVIDADNOMBRECATEGORIA',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_SGACTIVIDADIDCATEGORIA",",oparms:[{av:'A174SgActividadNombreCategoria',fld:'SGACTIVIDADNOMBRECATEGORIA',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
         setEventMetadata("VALID_SGACTIVIDADID","{handler:'Valid_Sgactividadid',iparms:[{av:'A171SgActividadId',fld:'SGACTIVIDADID',pic:'ZZZZZZZZ9'},{av:'A172SgActividadNombre',fld:'SGACTIVIDADNOMBRE',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]");
         setEventMetadata("VALID_SGACTIVIDADID",",oparms:[{av:'A172SgActividadNombre',fld:'SGACTIVIDADNOMBRE',pic:''},{av:'A72TicketTecnicoInstalacion',fld:'TICKETTECNICOINSTALACION',pic:''},{av:'A66TicketTecnicoConfiguracion',fld:'TICKETTECNICOCONFIGURACION',pic:''},{av:'A73TicketTecnicoInternetRouter',fld:'TICKETTECNICOINTERNETROUTER',pic:''},{av:'A70TicketTecnicoFormateo',fld:'TICKETTECNICOFORMATEO',pic:''},{av:'A84TicketTecnicoReparacion',fld:'TICKETTECNICOREPARACION',pic:''},{av:'A75TicketTecnicoLimpieza',fld:'TICKETTECNICOLIMPIEZA',pic:''},{av:'A82TicketTecnicoPuntoRed',fld:'TICKETTECNICOPUNTORED',pic:''},{av:'A62TicketTecnicoCambiosHardware',fld:'TICKETTECNICOCAMBIOSHARDWARE',pic:''},{av:'A67TicketTecnicoCopiasRespaldo',fld:'TICKETTECNICOCOPIASRESPALDO',pic:''},{av:'A65TicketTecnicoCerrado',fld:'TICKETTECNICOCERRADO',pic:''},{av:'A80TicketTecnicoPendiente',fld:'TICKETTECNICOPENDIENTE',pic:''},{av:'A79TicketTecnicoPasaTaller',fld:'TICKETTECNICOPASATALLER',pic:''},{av:'A77TicketTecnicoObservacion',fld:'TICKETTECNICOOBSERVACION',pic:''},{av:'A83TicketTecnicoRam',fld:'TICKETTECNICORAM',pic:''},{av:'A68TicketTecnicoDiscoDuro',fld:'TICKETTECNICODISCODURO',pic:''},{av:'A81TicketTecnicoProcesador',fld:'TICKETTECNICOPROCESADOR',pic:''},{av:'A76TicketTecnicoMaletin',fld:'TICKETTECNICOMALETIN',pic:''},{av:'A86TicketTecnicoTonerCinta',fld:'TICKETTECNICOTONERCINTA',pic:''},{av:'A85TicketTecnicoTarjetaVideoExtra',fld:'TICKETTECNICOTARJETAVIDEOEXTRA',pic:''},{av:'A63TicketTecnicoCargadorLaptop',fld:'TICKETTECNICOCARGADORLAPTOP',pic:''},{av:'A64TicketTecnicoCDsDVDs',fld:'TICKETTECNICOCDSDVDS',pic:''},{av:'A61TicketTecnicoCableEspecial',fld:'TICKETTECNICOCABLEESPECIAL',pic:''},{av:'A78TicketTecnicoOtrosTaller',fld:'TICKETTECNICOOTROSTALLER',pic:''}]}");
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
         pr_default.close(17);
         pr_default.close(19);
         pr_default.close(21);
         pr_datastore1.close(4);
         pr_datastore1.close(5);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z69TicketTecnicoFecha = DateTime.MinValue;
         Z71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         Z74TicketTecnicoInventarioSerie = "";
         Z97TicketTecnicoDetalle = "";
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
         lblTxttrabajo_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         A69TicketTecnicoFecha = DateTime.MinValue;
         A71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         A30ResponsableNombre = "";
         A93UsuarioNombre = "";
         A88UsuarioDepartamento = "";
         A94UsuarioRequerimiento = "";
         A74TicketTecnicoInventarioSerie = "";
         lblTxtacciones_Jsonclick = "";
         lblTxtestado_Jsonclick = "";
         A97TicketTecnicoDetalle = "";
         lblTxttaller_Jsonclick = "";
         A174SgActividadNombreCategoria = "";
         A172SgActividadNombre = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AV34Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode9 = "";
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
         AV8TrnContext = new SdtK2BTrnContext(context);
         AV9TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV26HttpRequest = new GxHttpRequest( context);
         AV22AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV23AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV24Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV21encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV17Url = "";
         Z93UsuarioNombre = "";
         Z94UsuarioRequerimiento = "";
         Z88UsuarioDepartamento = "";
         Z30ResponsableNombre = "";
         T00088_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T00088_A106nombre_categoria = new string[] {""} ;
         T00088_n106nombre_categoria = new bool[] {false} ;
         A106nombre_categoria = "";
         T00087_A102id_actividad_categoria = new int[1] ;
         T00087_A123nombre_actividad = new string[] {""} ;
         T00087_n123nombre_actividad = new bool[] {false} ;
         A123nombre_actividad = "";
         T00084_A15UsuarioId = new short[1] ;
         T00089_A93UsuarioNombre = new string[] {""} ;
         T00089_A94UsuarioRequerimiento = new string[] {""} ;
         T00089_A88UsuarioDepartamento = new string[] {""} ;
         T000810_A18TicketTecnicoId = new long[1] ;
         T000810_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         T000810_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         T000810_A30ResponsableNombre = new string[] {""} ;
         T000810_A93UsuarioNombre = new string[] {""} ;
         T000810_A94UsuarioRequerimiento = new string[] {""} ;
         T000810_A88UsuarioDepartamento = new string[] {""} ;
         T000810_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         T000810_A72TicketTecnicoInstalacion = new bool[] {false} ;
         T000810_A66TicketTecnicoConfiguracion = new bool[] {false} ;
         T000810_A73TicketTecnicoInternetRouter = new bool[] {false} ;
         T000810_A70TicketTecnicoFormateo = new bool[] {false} ;
         T000810_A84TicketTecnicoReparacion = new bool[] {false} ;
         T000810_A75TicketTecnicoLimpieza = new bool[] {false} ;
         T000810_A82TicketTecnicoPuntoRed = new bool[] {false} ;
         T000810_A62TicketTecnicoCambiosHardware = new bool[] {false} ;
         T000810_A67TicketTecnicoCopiasRespaldo = new bool[] {false} ;
         T000810_A83TicketTecnicoRam = new bool[] {false} ;
         T000810_A68TicketTecnicoDiscoDuro = new bool[] {false} ;
         T000810_A81TicketTecnicoProcesador = new bool[] {false} ;
         T000810_A76TicketTecnicoMaletin = new bool[] {false} ;
         T000810_A86TicketTecnicoTonerCinta = new bool[] {false} ;
         T000810_A85TicketTecnicoTarjetaVideoExtra = new bool[] {false} ;
         T000810_A63TicketTecnicoCargadorLaptop = new bool[] {false} ;
         T000810_A64TicketTecnicoCDsDVDs = new bool[] {false} ;
         T000810_A61TicketTecnicoCableEspecial = new bool[] {false} ;
         T000810_A78TicketTecnicoOtrosTaller = new bool[] {false} ;
         T000810_A65TicketTecnicoCerrado = new bool[] {false} ;
         T000810_A80TicketTecnicoPendiente = new bool[] {false} ;
         T000810_A79TicketTecnicoPasaTaller = new bool[] {false} ;
         T000810_A77TicketTecnicoObservacion = new bool[] {false} ;
         T000810_n77TicketTecnicoObservacion = new bool[] {false} ;
         T000810_A97TicketTecnicoDetalle = new string[] {""} ;
         T000810_A14TicketId = new long[1] ;
         T000810_A6ResponsableId = new short[1] ;
         T000810_A16TicketResponsableId = new long[1] ;
         T000810_A171SgActividadId = new int[1] ;
         T000810_A173SgActividadIdCategoria = new int[1] ;
         T000810_A15UsuarioId = new short[1] ;
         T00086_A14TicketId = new long[1] ;
         T00085_A30ResponsableNombre = new string[] {""} ;
         T000811_A15UsuarioId = new short[1] ;
         T000812_A93UsuarioNombre = new string[] {""} ;
         T000812_A94UsuarioRequerimiento = new string[] {""} ;
         T000812_A88UsuarioDepartamento = new string[] {""} ;
         T000813_A14TicketId = new long[1] ;
         T000814_A30ResponsableNombre = new string[] {""} ;
         T000815_A102id_actividad_categoria = new int[1] ;
         T000815_A123nombre_actividad = new string[] {""} ;
         T000815_n123nombre_actividad = new bool[] {false} ;
         T000816_A104categoria_tareaid_tipo_categoria = new int[1] ;
         T000816_A106nombre_categoria = new string[] {""} ;
         T000816_n106nombre_categoria = new bool[] {false} ;
         T000817_A18TicketTecnicoId = new long[1] ;
         T00083_A18TicketTecnicoId = new long[1] ;
         T00083_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         T00083_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         T00083_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         T00083_A72TicketTecnicoInstalacion = new bool[] {false} ;
         T00083_A66TicketTecnicoConfiguracion = new bool[] {false} ;
         T00083_A73TicketTecnicoInternetRouter = new bool[] {false} ;
         T00083_A70TicketTecnicoFormateo = new bool[] {false} ;
         T00083_A84TicketTecnicoReparacion = new bool[] {false} ;
         T00083_A75TicketTecnicoLimpieza = new bool[] {false} ;
         T00083_A82TicketTecnicoPuntoRed = new bool[] {false} ;
         T00083_A62TicketTecnicoCambiosHardware = new bool[] {false} ;
         T00083_A67TicketTecnicoCopiasRespaldo = new bool[] {false} ;
         T00083_A83TicketTecnicoRam = new bool[] {false} ;
         T00083_A68TicketTecnicoDiscoDuro = new bool[] {false} ;
         T00083_A81TicketTecnicoProcesador = new bool[] {false} ;
         T00083_A76TicketTecnicoMaletin = new bool[] {false} ;
         T00083_A86TicketTecnicoTonerCinta = new bool[] {false} ;
         T00083_A85TicketTecnicoTarjetaVideoExtra = new bool[] {false} ;
         T00083_A63TicketTecnicoCargadorLaptop = new bool[] {false} ;
         T00083_A64TicketTecnicoCDsDVDs = new bool[] {false} ;
         T00083_A61TicketTecnicoCableEspecial = new bool[] {false} ;
         T00083_A78TicketTecnicoOtrosTaller = new bool[] {false} ;
         T00083_A65TicketTecnicoCerrado = new bool[] {false} ;
         T00083_A80TicketTecnicoPendiente = new bool[] {false} ;
         T00083_A79TicketTecnicoPasaTaller = new bool[] {false} ;
         T00083_A77TicketTecnicoObservacion = new bool[] {false} ;
         T00083_n77TicketTecnicoObservacion = new bool[] {false} ;
         T00083_A97TicketTecnicoDetalle = new string[] {""} ;
         T00083_A14TicketId = new long[1] ;
         T00083_A6ResponsableId = new short[1] ;
         T00083_A16TicketResponsableId = new long[1] ;
         T00083_A171SgActividadId = new int[1] ;
         T00083_A173SgActividadIdCategoria = new int[1] ;
         T000818_A18TicketTecnicoId = new long[1] ;
         T000819_A18TicketTecnicoId = new long[1] ;
         T00082_A18TicketTecnicoId = new long[1] ;
         T00082_A69TicketTecnicoFecha = new DateTime[] {DateTime.MinValue} ;
         T00082_A71TicketTecnicoHora = new DateTime[] {DateTime.MinValue} ;
         T00082_A74TicketTecnicoInventarioSerie = new string[] {""} ;
         T00082_A72TicketTecnicoInstalacion = new bool[] {false} ;
         T00082_A66TicketTecnicoConfiguracion = new bool[] {false} ;
         T00082_A73TicketTecnicoInternetRouter = new bool[] {false} ;
         T00082_A70TicketTecnicoFormateo = new bool[] {false} ;
         T00082_A84TicketTecnicoReparacion = new bool[] {false} ;
         T00082_A75TicketTecnicoLimpieza = new bool[] {false} ;
         T00082_A82TicketTecnicoPuntoRed = new bool[] {false} ;
         T00082_A62TicketTecnicoCambiosHardware = new bool[] {false} ;
         T00082_A67TicketTecnicoCopiasRespaldo = new bool[] {false} ;
         T00082_A83TicketTecnicoRam = new bool[] {false} ;
         T00082_A68TicketTecnicoDiscoDuro = new bool[] {false} ;
         T00082_A81TicketTecnicoProcesador = new bool[] {false} ;
         T00082_A76TicketTecnicoMaletin = new bool[] {false} ;
         T00082_A86TicketTecnicoTonerCinta = new bool[] {false} ;
         T00082_A85TicketTecnicoTarjetaVideoExtra = new bool[] {false} ;
         T00082_A63TicketTecnicoCargadorLaptop = new bool[] {false} ;
         T00082_A64TicketTecnicoCDsDVDs = new bool[] {false} ;
         T00082_A61TicketTecnicoCableEspecial = new bool[] {false} ;
         T00082_A78TicketTecnicoOtrosTaller = new bool[] {false} ;
         T00082_A65TicketTecnicoCerrado = new bool[] {false} ;
         T00082_A80TicketTecnicoPendiente = new bool[] {false} ;
         T00082_A79TicketTecnicoPasaTaller = new bool[] {false} ;
         T00082_A77TicketTecnicoObservacion = new bool[] {false} ;
         T00082_n77TicketTecnicoObservacion = new bool[] {false} ;
         T00082_A97TicketTecnicoDetalle = new string[] {""} ;
         T00082_A14TicketId = new long[1] ;
         T00082_A6ResponsableId = new short[1] ;
         T00082_A16TicketResponsableId = new long[1] ;
         T00082_A171SgActividadId = new int[1] ;
         T00082_A173SgActividadIdCategoria = new int[1] ;
         T000820_A18TicketTecnicoId = new long[1] ;
         T000823_A15UsuarioId = new short[1] ;
         T000824_A93UsuarioNombre = new string[] {""} ;
         T000824_A94UsuarioRequerimiento = new string[] {""} ;
         T000824_A88UsuarioDepartamento = new string[] {""} ;
         T000825_A30ResponsableNombre = new string[] {""} ;
         T000826_A123nombre_actividad = new string[] {""} ;
         T000826_n123nombre_actividad = new bool[] {false} ;
         T000827_A106nombre_categoria = new string[] {""} ;
         T000827_n106nombre_categoria = new bool[] {false} ;
         T000828_A18TicketTecnicoId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i69TicketTecnicoFecha = DateTime.MinValue;
         i71TicketTecnicoHora = (DateTime)(DateTime.MinValue);
         sCtrlGx_mode = "";
         sCtrlAV7TicketTecnicoId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         T000829_A14TicketId = new long[1] ;
         Z174SgActividadNombreCategoria = "";
         Z172SgActividadNombre = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tickettecnico__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.tickettecnico__datastore1(),
            new Object[][] {
                new Object[] {
               T00087_A102id_actividad_categoria, T00087_A123nombre_actividad, T00087_n123nombre_actividad
               }
               , new Object[] {
               T00088_A104categoria_tareaid_tipo_categoria, T00088_A106nombre_categoria, T00088_n106nombre_categoria
               }
               , new Object[] {
               T000815_A102id_actividad_categoria, T000815_A123nombre_actividad, T000815_n123nombre_actividad
               }
               , new Object[] {
               T000816_A104categoria_tareaid_tipo_categoria, T000816_A106nombre_categoria, T000816_n106nombre_categoria
               }
               , new Object[] {
               T000826_A123nombre_actividad, T000826_n123nombre_actividad
               }
               , new Object[] {
               T000827_A106nombre_categoria, T000827_n106nombre_categoria
               }
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.tickettecnico__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tickettecnico__default(),
            new Object[][] {
                new Object[] {
               T00082_A18TicketTecnicoId, T00082_A69TicketTecnicoFecha, T00082_A71TicketTecnicoHora, T00082_A74TicketTecnicoInventarioSerie, T00082_A72TicketTecnicoInstalacion, T00082_A66TicketTecnicoConfiguracion, T00082_A73TicketTecnicoInternetRouter, T00082_A70TicketTecnicoFormateo, T00082_A84TicketTecnicoReparacion, T00082_A75TicketTecnicoLimpieza,
               T00082_A82TicketTecnicoPuntoRed, T00082_A62TicketTecnicoCambiosHardware, T00082_A67TicketTecnicoCopiasRespaldo, T00082_A83TicketTecnicoRam, T00082_A68TicketTecnicoDiscoDuro, T00082_A81TicketTecnicoProcesador, T00082_A76TicketTecnicoMaletin, T00082_A86TicketTecnicoTonerCinta, T00082_A85TicketTecnicoTarjetaVideoExtra, T00082_A63TicketTecnicoCargadorLaptop,
               T00082_A64TicketTecnicoCDsDVDs, T00082_A61TicketTecnicoCableEspecial, T00082_A78TicketTecnicoOtrosTaller, T00082_A65TicketTecnicoCerrado, T00082_A80TicketTecnicoPendiente, T00082_A79TicketTecnicoPasaTaller, T00082_A77TicketTecnicoObservacion, T00082_n77TicketTecnicoObservacion, T00082_A97TicketTecnicoDetalle, T00082_A14TicketId,
               T00082_A6ResponsableId, T00082_A16TicketResponsableId, T00082_A171SgActividadId, T00082_A173SgActividadIdCategoria
               }
               , new Object[] {
               T00083_A18TicketTecnicoId, T00083_A69TicketTecnicoFecha, T00083_A71TicketTecnicoHora, T00083_A74TicketTecnicoInventarioSerie, T00083_A72TicketTecnicoInstalacion, T00083_A66TicketTecnicoConfiguracion, T00083_A73TicketTecnicoInternetRouter, T00083_A70TicketTecnicoFormateo, T00083_A84TicketTecnicoReparacion, T00083_A75TicketTecnicoLimpieza,
               T00083_A82TicketTecnicoPuntoRed, T00083_A62TicketTecnicoCambiosHardware, T00083_A67TicketTecnicoCopiasRespaldo, T00083_A83TicketTecnicoRam, T00083_A68TicketTecnicoDiscoDuro, T00083_A81TicketTecnicoProcesador, T00083_A76TicketTecnicoMaletin, T00083_A86TicketTecnicoTonerCinta, T00083_A85TicketTecnicoTarjetaVideoExtra, T00083_A63TicketTecnicoCargadorLaptop,
               T00083_A64TicketTecnicoCDsDVDs, T00083_A61TicketTecnicoCableEspecial, T00083_A78TicketTecnicoOtrosTaller, T00083_A65TicketTecnicoCerrado, T00083_A80TicketTecnicoPendiente, T00083_A79TicketTecnicoPasaTaller, T00083_A77TicketTecnicoObservacion, T00083_n77TicketTecnicoObservacion, T00083_A97TicketTecnicoDetalle, T00083_A14TicketId,
               T00083_A6ResponsableId, T00083_A16TicketResponsableId, T00083_A171SgActividadId, T00083_A173SgActividadIdCategoria
               }
               , new Object[] {
               T00084_A15UsuarioId
               }
               , new Object[] {
               T00085_A30ResponsableNombre
               }
               , new Object[] {
               T00086_A14TicketId
               }
               , new Object[] {
               T00089_A93UsuarioNombre, T00089_A94UsuarioRequerimiento, T00089_A88UsuarioDepartamento
               }
               , new Object[] {
               T000810_A18TicketTecnicoId, T000810_A69TicketTecnicoFecha, T000810_A71TicketTecnicoHora, T000810_A30ResponsableNombre, T000810_A93UsuarioNombre, T000810_A94UsuarioRequerimiento, T000810_A88UsuarioDepartamento, T000810_A74TicketTecnicoInventarioSerie, T000810_A72TicketTecnicoInstalacion, T000810_A66TicketTecnicoConfiguracion,
               T000810_A73TicketTecnicoInternetRouter, T000810_A70TicketTecnicoFormateo, T000810_A84TicketTecnicoReparacion, T000810_A75TicketTecnicoLimpieza, T000810_A82TicketTecnicoPuntoRed, T000810_A62TicketTecnicoCambiosHardware, T000810_A67TicketTecnicoCopiasRespaldo, T000810_A83TicketTecnicoRam, T000810_A68TicketTecnicoDiscoDuro, T000810_A81TicketTecnicoProcesador,
               T000810_A76TicketTecnicoMaletin, T000810_A86TicketTecnicoTonerCinta, T000810_A85TicketTecnicoTarjetaVideoExtra, T000810_A63TicketTecnicoCargadorLaptop, T000810_A64TicketTecnicoCDsDVDs, T000810_A61TicketTecnicoCableEspecial, T000810_A78TicketTecnicoOtrosTaller, T000810_A65TicketTecnicoCerrado, T000810_A80TicketTecnicoPendiente, T000810_A79TicketTecnicoPasaTaller,
               T000810_A77TicketTecnicoObservacion, T000810_n77TicketTecnicoObservacion, T000810_A97TicketTecnicoDetalle, T000810_A14TicketId, T000810_A6ResponsableId, T000810_A16TicketResponsableId, T000810_A171SgActividadId, T000810_A173SgActividadIdCategoria, T000810_A15UsuarioId
               }
               , new Object[] {
               T000811_A15UsuarioId
               }
               , new Object[] {
               T000812_A93UsuarioNombre, T000812_A94UsuarioRequerimiento, T000812_A88UsuarioDepartamento
               }
               , new Object[] {
               T000813_A14TicketId
               }
               , new Object[] {
               T000814_A30ResponsableNombre
               }
               , new Object[] {
               T000817_A18TicketTecnicoId
               }
               , new Object[] {
               T000818_A18TicketTecnicoId
               }
               , new Object[] {
               T000819_A18TicketTecnicoId
               }
               , new Object[] {
               T000820_A18TicketTecnicoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000823_A15UsuarioId
               }
               , new Object[] {
               T000824_A93UsuarioNombre, T000824_A94UsuarioRequerimiento, T000824_A88UsuarioDepartamento
               }
               , new Object[] {
               T000825_A30ResponsableNombre
               }
               , new Object[] {
               T000828_A18TicketTecnicoId
               }
               , new Object[] {
               T000829_A14TicketId
               }
            }
         );
         AV34Pgmname = "TicketTecnico";
         Z71TicketTecnicoHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A71TicketTecnicoHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         i71TicketTecnicoHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         Z69TicketTecnicoFecha = DateTimeUtil.Today( context);
         A69TicketTecnicoFecha = DateTimeUtil.Today( context);
         i69TicketTecnicoFecha = DateTimeUtil.Today( context);
      }

      private short Z6ResponsableId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A15UsuarioId ;
      private short A6ResponsableId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z15UsuarioId ;
      private short nIsDirty_9 ;
      private int Z171SgActividadId ;
      private int Z173SgActividadIdCategoria ;
      private int N171SgActividadId ;
      private int N173SgActividadIdCategoria ;
      private int A171SgActividadId ;
      private int A173SgActividadIdCategoria ;
      private int trnEnded ;
      private int edtTicketTecnicoId_Enabled ;
      private int divK2btoolstable_attributecontainerticketresponsableid_Visible ;
      private int edtTicketResponsableId_Enabled ;
      private int imgprompt_16_Visible ;
      private int edtTicketId_Enabled ;
      private int imgprompt_14_Visible ;
      private int edtTicketTecnicoFecha_Enabled ;
      private int edtTicketTecnicoHora_Enabled ;
      private int edtResponsableNombre_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int divK2btoolstable_attributecontainerresponsableid_Visible ;
      private int edtResponsableId_Enabled ;
      private int imgprompt_6_Visible ;
      private int edtUsuarioDepartamento_Enabled ;
      private int divK2btoolstable_attributecontainerusuarioid_Visible ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioRequerimiento_Enabled ;
      private int edtTicketTecnicoInventarioSerie_Enabled ;
      private int divK2btoolstable_attributecontainertickettecnicoobservacion_Visible ;
      private int edtTicketTecnicoDetalle_Enabled ;
      private int edtSgActividadIdCategoria_Enabled ;
      private int imgprompt_173_Visible ;
      private int edtSgActividadNombreCategoria_Enabled ;
      private int edtSgActividadId_Enabled ;
      private int imgprompt_171_Visible ;
      private int edtSgActividadNombre_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int AV31Insert_SgActividadId ;
      private int AV32Insert_SgActividadIdCategoria ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV35GXV1 ;
      private int A104categoria_tareaid_tipo_categoria ;
      private int A102id_actividad_categoria ;
      private int idxLst ;
      private long wcpOAV7TicketTecnicoId ;
      private long Z18TicketTecnicoId ;
      private long Z14TicketId ;
      private long Z16TicketResponsableId ;
      private long N14TicketId ;
      private long N16TicketResponsableId ;
      private long AV7TicketTecnicoId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A18TicketTecnicoId ;
      private long AV12Insert_TicketId ;
      private long AV13Insert_TicketResponsableId ;
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
      private string edtTicketResponsableId_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divTabletextblocktxttrabajocontainer_Internalname ;
      private string lblTxttrabajo_Internalname ;
      private string lblTxttrabajo_Jsonclick ;
      private string divClmid_Internalname ;
      private string divTableclmid0_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoid_Internalname ;
      private string edtTicketTecnicoId_Internalname ;
      private string edtTicketTecnicoId_Jsonclick ;
      private string divK2btoolstable_attributecontainerticketresponsableid_Internalname ;
      private string TempTags ;
      private string edtTicketResponsableId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_16_Internalname ;
      private string imgprompt_16_Link ;
      private string divTableclmid1_Internalname ;
      private string divK2btoolstable_attributecontainerticketid_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketId_Jsonclick ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string divClmfecha_Internalname ;
      private string divTableclmfecha0_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicofecha_Internalname ;
      private string edtTicketTecnicoFecha_Internalname ;
      private string edtTicketTecnicoFecha_Jsonclick ;
      private string edtTicketTecnicoFecha_Class ;
      private string divTableclmfecha1_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicohora_Internalname ;
      private string edtTicketTecnicoHora_Internalname ;
      private string edtTicketTecnicoHora_Jsonclick ;
      private string divClmtecnico_Internalname ;
      private string divTableclmtecnico0_Internalname ;
      private string divK2btoolstable_attributecontainerresponsablenombre_Internalname ;
      private string edtResponsableNombre_Internalname ;
      private string edtResponsableNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuarionombre_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioNombre_Link ;
      private string edtUsuarioNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerresponsableid_Internalname ;
      private string edtResponsableId_Internalname ;
      private string edtResponsableId_Jsonclick ;
      private string imgprompt_6_Internalname ;
      private string imgprompt_6_Link ;
      private string divTableclmtecnico1_Internalname ;
      private string divK2btoolstable_attributecontainerusuariodepartamento_Internalname ;
      private string edtUsuarioDepartamento_Internalname ;
      private string divK2btoolstable_attributecontainerusuarioid_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioId_Jsonclick ;
      private string divClmreq_Internalname ;
      private string divTableclmreq0_Internalname ;
      private string divK2btoolstable_attributecontainerusuariorequerimiento_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string divTableclmreq1_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoinventarioserie_Internalname ;
      private string edtTicketTecnicoInventarioSerie_Internalname ;
      private string divTabletextblocktxtaccionescontainer_Internalname ;
      private string lblTxtacciones_Internalname ;
      private string lblTxtacciones_Jsonclick ;
      private string divClmacciones_Internalname ;
      private string divTableclmacciones0_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoinstalacion_Internalname ;
      private string chkTicketTecnicoInstalacion_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoconfiguracion_Internalname ;
      private string chkTicketTecnicoConfiguracion_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicointernetrouter_Internalname ;
      private string chkTicketTecnicoInternetRouter_Internalname ;
      private string divTableclmacciones1_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoformateo_Internalname ;
      private string chkTicketTecnicoFormateo_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoreparacion_Internalname ;
      private string chkTicketTecnicoReparacion_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicolimpieza_Internalname ;
      private string chkTicketTecnicoLimpieza_Internalname ;
      private string divTableclmacciones2_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicopuntored_Internalname ;
      private string chkTicketTecnicoPuntoRed_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicocambioshardware_Internalname ;
      private string chkTicketTecnicoCambiosHardware_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicocopiasrespaldo_Internalname ;
      private string chkTicketTecnicoCopiasRespaldo_Internalname ;
      private string divTabletextblocktxtestadocontainer_Internalname ;
      private string lblTxtestado_Internalname ;
      private string lblTxtestado_Jsonclick ;
      private string divClmestado_Internalname ;
      private string divTableclmestado0_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicocerrado_Internalname ;
      private string chkTicketTecnicoCerrado_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicopendiente_Internalname ;
      private string chkTicketTecnicoPendiente_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicopasataller_Internalname ;
      private string chkTicketTecnicoPasaTaller_Internalname ;
      private string divTableclmestado1_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoobservacion_Internalname ;
      private string chkTicketTecnicoObservacion_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicodetalle_Internalname ;
      private string edtTicketTecnicoDetalle_Internalname ;
      private string divTabletextblocktxttallercontainer_Internalname ;
      private string lblTxttaller_Internalname ;
      private string lblTxttaller_Jsonclick ;
      private string divClmtaller_Internalname ;
      private string divTableclmtaller0_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoram_Internalname ;
      private string chkTicketTecnicoRam_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicodiscoduro_Internalname ;
      private string chkTicketTecnicoDiscoDuro_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicoprocesador_Internalname ;
      private string chkTicketTecnicoProcesador_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicomaletin_Internalname ;
      private string chkTicketTecnicoMaletin_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicotonercinta_Internalname ;
      private string chkTicketTecnicoTonerCinta_Internalname ;
      private string divTableclmtaller1_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicotarjetavideoextra_Internalname ;
      private string chkTicketTecnicoTarjetaVideoExtra_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicocargadorlaptop_Internalname ;
      private string chkTicketTecnicoCargadorLaptop_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicocdsdvds_Internalname ;
      private string chkTicketTecnicoCDsDVDs_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicocableespecial_Internalname ;
      private string chkTicketTecnicoCableEspecial_Internalname ;
      private string divK2btoolstable_attributecontainertickettecnicootrostaller_Internalname ;
      private string chkTicketTecnicoOtrosTaller_Internalname ;
      private string divClcat_Internalname ;
      private string divTableclcat0_Internalname ;
      private string divK2btoolstable_attributecontainersgactividadidcategoria_Internalname ;
      private string edtSgActividadIdCategoria_Internalname ;
      private string edtSgActividadIdCategoria_Jsonclick ;
      private string imgprompt_173_Internalname ;
      private string imgprompt_173_Link ;
      private string divK2btoolstable_attributecontainersgactividadnombrecategoria_Internalname ;
      private string edtSgActividadNombreCategoria_Internalname ;
      private string divTableclcat1_Internalname ;
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
      private string AV34Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode9 ;
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
      private string sCtrlAV7TicketTecnicoId ;
      private DateTime Z71TicketTecnicoHora ;
      private DateTime A71TicketTecnicoHora ;
      private DateTime i71TicketTecnicoHora ;
      private DateTime Z69TicketTecnicoFecha ;
      private DateTime A69TicketTecnicoFecha ;
      private DateTime i69TicketTecnicoFecha ;
      private bool Z72TicketTecnicoInstalacion ;
      private bool Z66TicketTecnicoConfiguracion ;
      private bool Z73TicketTecnicoInternetRouter ;
      private bool Z70TicketTecnicoFormateo ;
      private bool Z84TicketTecnicoReparacion ;
      private bool Z75TicketTecnicoLimpieza ;
      private bool Z82TicketTecnicoPuntoRed ;
      private bool Z62TicketTecnicoCambiosHardware ;
      private bool Z67TicketTecnicoCopiasRespaldo ;
      private bool Z83TicketTecnicoRam ;
      private bool Z68TicketTecnicoDiscoDuro ;
      private bool Z81TicketTecnicoProcesador ;
      private bool Z76TicketTecnicoMaletin ;
      private bool Z86TicketTecnicoTonerCinta ;
      private bool Z85TicketTecnicoTarjetaVideoExtra ;
      private bool Z63TicketTecnicoCargadorLaptop ;
      private bool Z64TicketTecnicoCDsDVDs ;
      private bool Z61TicketTecnicoCableEspecial ;
      private bool Z78TicketTecnicoOtrosTaller ;
      private bool Z65TicketTecnicoCerrado ;
      private bool Z80TicketTecnicoPendiente ;
      private bool Z79TicketTecnicoPasaTaller ;
      private bool Z77TicketTecnicoObservacion ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A72TicketTecnicoInstalacion ;
      private bool A66TicketTecnicoConfiguracion ;
      private bool A73TicketTecnicoInternetRouter ;
      private bool A70TicketTecnicoFormateo ;
      private bool A84TicketTecnicoReparacion ;
      private bool A75TicketTecnicoLimpieza ;
      private bool A82TicketTecnicoPuntoRed ;
      private bool A62TicketTecnicoCambiosHardware ;
      private bool A67TicketTecnicoCopiasRespaldo ;
      private bool A65TicketTecnicoCerrado ;
      private bool A80TicketTecnicoPendiente ;
      private bool A79TicketTecnicoPasaTaller ;
      private bool A77TicketTecnicoObservacion ;
      private bool n77TicketTecnicoObservacion ;
      private bool A83TicketTecnicoRam ;
      private bool A68TicketTecnicoDiscoDuro ;
      private bool A81TicketTecnicoProcesador ;
      private bool A76TicketTecnicoMaletin ;
      private bool A86TicketTecnicoTonerCinta ;
      private bool A85TicketTecnicoTarjetaVideoExtra ;
      private bool A63TicketTecnicoCargadorLaptop ;
      private bool A64TicketTecnicoCDsDVDs ;
      private bool A61TicketTecnicoCableEspecial ;
      private bool A78TicketTecnicoOtrosTaller ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV20IsAuthorized ;
      private bool n106nombre_categoria ;
      private bool n123nombre_actividad ;
      private bool Gx_longc ;
      private bool GXt_boolean2 ;
      private string Z74TicketTecnicoInventarioSerie ;
      private string Z97TicketTecnicoDetalle ;
      private string A30ResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A88UsuarioDepartamento ;
      private string A94UsuarioRequerimiento ;
      private string A74TicketTecnicoInventarioSerie ;
      private string A97TicketTecnicoDetalle ;
      private string A174SgActividadNombreCategoria ;
      private string A172SgActividadNombre ;
      private string AV19UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV17Url ;
      private string Z93UsuarioNombre ;
      private string Z94UsuarioRequerimiento ;
      private string Z88UsuarioDepartamento ;
      private string Z30ResponsableNombre ;
      private string A106nombre_categoria ;
      private string A123nombre_actividad ;
      private string Z174SgActividadNombreCategoria ;
      private string Z172SgActividadNombre ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTicketTecnicoInstalacion ;
      private GXCheckbox chkTicketTecnicoConfiguracion ;
      private GXCheckbox chkTicketTecnicoInternetRouter ;
      private GXCheckbox chkTicketTecnicoFormateo ;
      private GXCheckbox chkTicketTecnicoReparacion ;
      private GXCheckbox chkTicketTecnicoLimpieza ;
      private GXCheckbox chkTicketTecnicoPuntoRed ;
      private GXCheckbox chkTicketTecnicoCambiosHardware ;
      private GXCheckbox chkTicketTecnicoCopiasRespaldo ;
      private GXCheckbox chkTicketTecnicoCerrado ;
      private GXCheckbox chkTicketTecnicoPendiente ;
      private GXCheckbox chkTicketTecnicoPasaTaller ;
      private GXCheckbox chkTicketTecnicoObservacion ;
      private GXCheckbox chkTicketTecnicoRam ;
      private GXCheckbox chkTicketTecnicoDiscoDuro ;
      private GXCheckbox chkTicketTecnicoProcesador ;
      private GXCheckbox chkTicketTecnicoMaletin ;
      private GXCheckbox chkTicketTecnicoTonerCinta ;
      private GXCheckbox chkTicketTecnicoTarjetaVideoExtra ;
      private GXCheckbox chkTicketTecnicoCargadorLaptop ;
      private GXCheckbox chkTicketTecnicoCDsDVDs ;
      private GXCheckbox chkTicketTecnicoCableEspecial ;
      private GXCheckbox chkTicketTecnicoOtrosTaller ;
      private Object[] args ;
      private IDataStoreProvider pr_datastore1 ;
      private int[] T00088_A104categoria_tareaid_tipo_categoria ;
      private string[] T00088_A106nombre_categoria ;
      private bool[] T00088_n106nombre_categoria ;
      private int[] T00087_A102id_actividad_categoria ;
      private string[] T00087_A123nombre_actividad ;
      private bool[] T00087_n123nombre_actividad ;
      private IDataStoreProvider pr_default ;
      private short[] T00084_A15UsuarioId ;
      private string[] T00089_A93UsuarioNombre ;
      private string[] T00089_A94UsuarioRequerimiento ;
      private string[] T00089_A88UsuarioDepartamento ;
      private long[] T000810_A18TicketTecnicoId ;
      private DateTime[] T000810_A69TicketTecnicoFecha ;
      private DateTime[] T000810_A71TicketTecnicoHora ;
      private string[] T000810_A30ResponsableNombre ;
      private string[] T000810_A93UsuarioNombre ;
      private string[] T000810_A94UsuarioRequerimiento ;
      private string[] T000810_A88UsuarioDepartamento ;
      private string[] T000810_A74TicketTecnicoInventarioSerie ;
      private bool[] T000810_A72TicketTecnicoInstalacion ;
      private bool[] T000810_A66TicketTecnicoConfiguracion ;
      private bool[] T000810_A73TicketTecnicoInternetRouter ;
      private bool[] T000810_A70TicketTecnicoFormateo ;
      private bool[] T000810_A84TicketTecnicoReparacion ;
      private bool[] T000810_A75TicketTecnicoLimpieza ;
      private bool[] T000810_A82TicketTecnicoPuntoRed ;
      private bool[] T000810_A62TicketTecnicoCambiosHardware ;
      private bool[] T000810_A67TicketTecnicoCopiasRespaldo ;
      private bool[] T000810_A83TicketTecnicoRam ;
      private bool[] T000810_A68TicketTecnicoDiscoDuro ;
      private bool[] T000810_A81TicketTecnicoProcesador ;
      private bool[] T000810_A76TicketTecnicoMaletin ;
      private bool[] T000810_A86TicketTecnicoTonerCinta ;
      private bool[] T000810_A85TicketTecnicoTarjetaVideoExtra ;
      private bool[] T000810_A63TicketTecnicoCargadorLaptop ;
      private bool[] T000810_A64TicketTecnicoCDsDVDs ;
      private bool[] T000810_A61TicketTecnicoCableEspecial ;
      private bool[] T000810_A78TicketTecnicoOtrosTaller ;
      private bool[] T000810_A65TicketTecnicoCerrado ;
      private bool[] T000810_A80TicketTecnicoPendiente ;
      private bool[] T000810_A79TicketTecnicoPasaTaller ;
      private bool[] T000810_A77TicketTecnicoObservacion ;
      private bool[] T000810_n77TicketTecnicoObservacion ;
      private string[] T000810_A97TicketTecnicoDetalle ;
      private long[] T000810_A14TicketId ;
      private short[] T000810_A6ResponsableId ;
      private long[] T000810_A16TicketResponsableId ;
      private int[] T000810_A171SgActividadId ;
      private int[] T000810_A173SgActividadIdCategoria ;
      private short[] T000810_A15UsuarioId ;
      private long[] T00086_A14TicketId ;
      private string[] T00085_A30ResponsableNombre ;
      private short[] T000811_A15UsuarioId ;
      private string[] T000812_A93UsuarioNombre ;
      private string[] T000812_A94UsuarioRequerimiento ;
      private string[] T000812_A88UsuarioDepartamento ;
      private long[] T000813_A14TicketId ;
      private string[] T000814_A30ResponsableNombre ;
      private int[] T000815_A102id_actividad_categoria ;
      private string[] T000815_A123nombre_actividad ;
      private bool[] T000815_n123nombre_actividad ;
      private int[] T000816_A104categoria_tareaid_tipo_categoria ;
      private string[] T000816_A106nombre_categoria ;
      private bool[] T000816_n106nombre_categoria ;
      private long[] T000817_A18TicketTecnicoId ;
      private long[] T00083_A18TicketTecnicoId ;
      private DateTime[] T00083_A69TicketTecnicoFecha ;
      private DateTime[] T00083_A71TicketTecnicoHora ;
      private string[] T00083_A74TicketTecnicoInventarioSerie ;
      private bool[] T00083_A72TicketTecnicoInstalacion ;
      private bool[] T00083_A66TicketTecnicoConfiguracion ;
      private bool[] T00083_A73TicketTecnicoInternetRouter ;
      private bool[] T00083_A70TicketTecnicoFormateo ;
      private bool[] T00083_A84TicketTecnicoReparacion ;
      private bool[] T00083_A75TicketTecnicoLimpieza ;
      private bool[] T00083_A82TicketTecnicoPuntoRed ;
      private bool[] T00083_A62TicketTecnicoCambiosHardware ;
      private bool[] T00083_A67TicketTecnicoCopiasRespaldo ;
      private bool[] T00083_A83TicketTecnicoRam ;
      private bool[] T00083_A68TicketTecnicoDiscoDuro ;
      private bool[] T00083_A81TicketTecnicoProcesador ;
      private bool[] T00083_A76TicketTecnicoMaletin ;
      private bool[] T00083_A86TicketTecnicoTonerCinta ;
      private bool[] T00083_A85TicketTecnicoTarjetaVideoExtra ;
      private bool[] T00083_A63TicketTecnicoCargadorLaptop ;
      private bool[] T00083_A64TicketTecnicoCDsDVDs ;
      private bool[] T00083_A61TicketTecnicoCableEspecial ;
      private bool[] T00083_A78TicketTecnicoOtrosTaller ;
      private bool[] T00083_A65TicketTecnicoCerrado ;
      private bool[] T00083_A80TicketTecnicoPendiente ;
      private bool[] T00083_A79TicketTecnicoPasaTaller ;
      private bool[] T00083_A77TicketTecnicoObservacion ;
      private bool[] T00083_n77TicketTecnicoObservacion ;
      private string[] T00083_A97TicketTecnicoDetalle ;
      private long[] T00083_A14TicketId ;
      private short[] T00083_A6ResponsableId ;
      private long[] T00083_A16TicketResponsableId ;
      private int[] T00083_A171SgActividadId ;
      private int[] T00083_A173SgActividadIdCategoria ;
      private long[] T000818_A18TicketTecnicoId ;
      private long[] T000819_A18TicketTecnicoId ;
      private long[] T00082_A18TicketTecnicoId ;
      private DateTime[] T00082_A69TicketTecnicoFecha ;
      private DateTime[] T00082_A71TicketTecnicoHora ;
      private string[] T00082_A74TicketTecnicoInventarioSerie ;
      private bool[] T00082_A72TicketTecnicoInstalacion ;
      private bool[] T00082_A66TicketTecnicoConfiguracion ;
      private bool[] T00082_A73TicketTecnicoInternetRouter ;
      private bool[] T00082_A70TicketTecnicoFormateo ;
      private bool[] T00082_A84TicketTecnicoReparacion ;
      private bool[] T00082_A75TicketTecnicoLimpieza ;
      private bool[] T00082_A82TicketTecnicoPuntoRed ;
      private bool[] T00082_A62TicketTecnicoCambiosHardware ;
      private bool[] T00082_A67TicketTecnicoCopiasRespaldo ;
      private bool[] T00082_A83TicketTecnicoRam ;
      private bool[] T00082_A68TicketTecnicoDiscoDuro ;
      private bool[] T00082_A81TicketTecnicoProcesador ;
      private bool[] T00082_A76TicketTecnicoMaletin ;
      private bool[] T00082_A86TicketTecnicoTonerCinta ;
      private bool[] T00082_A85TicketTecnicoTarjetaVideoExtra ;
      private bool[] T00082_A63TicketTecnicoCargadorLaptop ;
      private bool[] T00082_A64TicketTecnicoCDsDVDs ;
      private bool[] T00082_A61TicketTecnicoCableEspecial ;
      private bool[] T00082_A78TicketTecnicoOtrosTaller ;
      private bool[] T00082_A65TicketTecnicoCerrado ;
      private bool[] T00082_A80TicketTecnicoPendiente ;
      private bool[] T00082_A79TicketTecnicoPasaTaller ;
      private bool[] T00082_A77TicketTecnicoObservacion ;
      private bool[] T00082_n77TicketTecnicoObservacion ;
      private string[] T00082_A97TicketTecnicoDetalle ;
      private long[] T00082_A14TicketId ;
      private short[] T00082_A6ResponsableId ;
      private long[] T00082_A16TicketResponsableId ;
      private int[] T00082_A171SgActividadId ;
      private int[] T00082_A173SgActividadIdCategoria ;
      private long[] T000820_A18TicketTecnicoId ;
      private short[] T000823_A15UsuarioId ;
      private string[] T000824_A93UsuarioNombre ;
      private string[] T000824_A94UsuarioRequerimiento ;
      private string[] T000824_A88UsuarioDepartamento ;
      private string[] T000825_A30ResponsableNombre ;
      private string[] T000826_A123nombre_actividad ;
      private bool[] T000826_n123nombre_actividad ;
      private string[] T000827_A106nombre_categoria ;
      private bool[] T000827_n106nombre_categoria ;
      private long[] T000828_A18TicketTecnicoId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private long[] T000829_A14TicketId ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV26HttpRequest ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV22AttributeValue ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BContext AV14Context ;
      private SdtK2BAttributeValue_Item AV23AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV24Message ;
   }

   public class tickettecnico__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tickettecnico__datastore1 : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00087;
        prmT00087 = new Object[] {
        new ParDef("@SgActividadId",GXType.Int32,9,0)
        };
        Object[] prmT00088;
        prmT00088 = new Object[] {
        new ParDef("@SgActividadIdCategoria",GXType.Int32,9,0)
        };
        Object[] prmT000815;
        prmT000815 = new Object[] {
        new ParDef("@SgActividadId",GXType.Int32,9,0)
        };
        Object[] prmT000816;
        prmT000816 = new Object[] {
        new ParDef("@SgActividadIdCategoria",GXType.Int32,9,0)
        };
        Object[] prmT000827;
        prmT000827 = new Object[] {
        new ParDef("@SgActividadIdCategoria",GXType.Int32,9,0)
        };
        Object[] prmT000826;
        prmT000826 = new Object[] {
        new ParDef("@SgActividadId",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00087", "SELECT [id_actividad_categoria], [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @SgActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00088", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @SgActividadIdCategoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000815", "SELECT [id_actividad_categoria], [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @SgActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000816", "SELECT [id_tipo_categoria] AS categoria_tareaid_tipo_categoria, [nombre_categoria] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @SgActividadIdCategoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000826", "SELECT [nombre_actividad] FROM dbo.[actividades_categoria] WHERE [id_actividad_categoria] = @SgActividadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000826,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000827", "SELECT [nombre_categoria] FROM dbo.[categoria_tarea] WHERE [id_tipo_categoria] = @SgActividadIdCategoria ",true, GxErrorMask.GX_NOMASK, false, this,prmT000827,1, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
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

public class tickettecnico__gam : DataStoreHelperBase, IDataStoreHelper
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

public class tickettecnico__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[9])
      ,new ForEachCursor(def[10])
      ,new ForEachCursor(def[11])
      ,new ForEachCursor(def[12])
      ,new ForEachCursor(def[13])
      ,new ForEachCursor(def[14])
      ,new UpdateCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000810;
       prmT000810 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT00084;
       prmT00084 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT00089;
       prmT00089 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT00086;
       prmT00086 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT00085;
       prmT00085 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000811;
       prmT000811 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000812;
       prmT000812 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000813;
       prmT000813 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000814;
       prmT000814 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000817;
       prmT000817 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT00083;
       prmT00083 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000818;
       prmT000818 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000819;
       prmT000819 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT00082;
       prmT00082 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000820;
       prmT000820 = new Object[] {
       new ParDef("@TicketTecnicoFecha",GXType.Date,8,0) ,
       new ParDef("@TicketTecnicoHora",GXType.DateTime,0,5) ,
       new ParDef("@TicketTecnicoInventarioSerie",GXType.NVarChar,300,0) ,
       new ParDef("@TicketTecnicoInstalacion",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoConfiguracion",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoInternetRouter",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoFormateo",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoReparacion",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoLimpieza",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoPuntoRed",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCambiosHardware",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCopiasRespaldo",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoRam",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoDiscoDuro",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoProcesador",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoMaletin",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoTonerCinta",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoTarjetaVideoExtra",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCargadorLaptop",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCDsDVDs",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCableEspecial",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoOtrosTaller",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCerrado",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoPendiente",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoPasaTaller",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoObservacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketTecnicoDetalle",GXType.NVarChar,300,0) ,
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@ResponsableId",GXType.Int16,4,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
       new ParDef("@SgActividadId",GXType.Int32,9,0) ,
       new ParDef("@SgActividadIdCategoria",GXType.Int32,9,0)
       };
       Object[] prmT000821;
       prmT000821 = new Object[] {
       new ParDef("@TicketTecnicoFecha",GXType.Date,8,0) ,
       new ParDef("@TicketTecnicoHora",GXType.DateTime,0,5) ,
       new ParDef("@TicketTecnicoInventarioSerie",GXType.NVarChar,300,0) ,
       new ParDef("@TicketTecnicoInstalacion",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoConfiguracion",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoInternetRouter",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoFormateo",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoReparacion",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoLimpieza",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoPuntoRed",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCambiosHardware",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCopiasRespaldo",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoRam",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoDiscoDuro",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoProcesador",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoMaletin",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoTonerCinta",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoTarjetaVideoExtra",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCargadorLaptop",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCDsDVDs",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCableEspecial",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoOtrosTaller",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoCerrado",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoPendiente",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoPasaTaller",GXType.Boolean,4,0) ,
       new ParDef("@TicketTecnicoObservacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketTecnicoDetalle",GXType.NVarChar,300,0) ,
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@ResponsableId",GXType.Int16,4,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
       new ParDef("@SgActividadId",GXType.Int32,9,0) ,
       new ParDef("@SgActividadIdCategoria",GXType.Int32,9,0) ,
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000822;
       prmT000822 = new Object[] {
       new ParDef("@TicketTecnicoId",GXType.Decimal,10,0)
       };
       Object[] prmT000828;
       prmT000828 = new Object[] {
       };
       Object[] prmT000823;
       prmT000823 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000824;
       prmT000824 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000829;
       prmT000829 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000825;
       prmT000825 = new Object[] {
       new ParDef("@ResponsableId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00082", "SELECT [TicketTecnicoId], [TicketTecnicoFecha], [TicketTecnicoHora], [TicketTecnicoInventarioSerie], [TicketTecnicoInstalacion], [TicketTecnicoConfiguracion], [TicketTecnicoInternetRouter], [TicketTecnicoFormateo], [TicketTecnicoReparacion], [TicketTecnicoLimpieza], [TicketTecnicoPuntoRed], [TicketTecnicoCambiosHardware], [TicketTecnicoCopiasRespaldo], [TicketTecnicoRam], [TicketTecnicoDiscoDuro], [TicketTecnicoProcesador], [TicketTecnicoMaletin], [TicketTecnicoTonerCinta], [TicketTecnicoTarjetaVideoExtra], [TicketTecnicoCargadorLaptop], [TicketTecnicoCDsDVDs], [TicketTecnicoCableEspecial], [TicketTecnicoOtrosTaller], [TicketTecnicoCerrado], [TicketTecnicoPendiente], [TicketTecnicoPasaTaller], [TicketTecnicoObservacion], [TicketTecnicoDetalle], [TicketId], [ResponsableId], [TicketResponsableId], [SgActividadId], [SgActividadIdCategoria] FROM [TicketTecnico] WITH (UPDLOCK) WHERE [TicketTecnicoId] = @TicketTecnicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00083", "SELECT [TicketTecnicoId], [TicketTecnicoFecha], [TicketTecnicoHora], [TicketTecnicoInventarioSerie], [TicketTecnicoInstalacion], [TicketTecnicoConfiguracion], [TicketTecnicoInternetRouter], [TicketTecnicoFormateo], [TicketTecnicoReparacion], [TicketTecnicoLimpieza], [TicketTecnicoPuntoRed], [TicketTecnicoCambiosHardware], [TicketTecnicoCopiasRespaldo], [TicketTecnicoRam], [TicketTecnicoDiscoDuro], [TicketTecnicoProcesador], [TicketTecnicoMaletin], [TicketTecnicoTonerCinta], [TicketTecnicoTarjetaVideoExtra], [TicketTecnicoCargadorLaptop], [TicketTecnicoCDsDVDs], [TicketTecnicoCableEspecial], [TicketTecnicoOtrosTaller], [TicketTecnicoCerrado], [TicketTecnicoPendiente], [TicketTecnicoPasaTaller], [TicketTecnicoObservacion], [TicketTecnicoDetalle], [TicketId], [ResponsableId], [TicketResponsableId], [SgActividadId], [SgActividadIdCategoria] FROM [TicketTecnico] WHERE [TicketTecnicoId] = @TicketTecnicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00084", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00085", "SELECT [ResponsableNombre] FROM [Responsable] WHERE [ResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00086", "SELECT [TicketId] FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00089", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000810", "SELECT TM1.[TicketTecnicoId], TM1.[TicketTecnicoFecha], TM1.[TicketTecnicoHora], T4.[ResponsableNombre], T3.[UsuarioNombre], T3.[UsuarioRequerimiento], T3.[UsuarioDepartamento], TM1.[TicketTecnicoInventarioSerie], TM1.[TicketTecnicoInstalacion], TM1.[TicketTecnicoConfiguracion], TM1.[TicketTecnicoInternetRouter], TM1.[TicketTecnicoFormateo], TM1.[TicketTecnicoReparacion], TM1.[TicketTecnicoLimpieza], TM1.[TicketTecnicoPuntoRed], TM1.[TicketTecnicoCambiosHardware], TM1.[TicketTecnicoCopiasRespaldo], TM1.[TicketTecnicoRam], TM1.[TicketTecnicoDiscoDuro], TM1.[TicketTecnicoProcesador], TM1.[TicketTecnicoMaletin], TM1.[TicketTecnicoTonerCinta], TM1.[TicketTecnicoTarjetaVideoExtra], TM1.[TicketTecnicoCargadorLaptop], TM1.[TicketTecnicoCDsDVDs], TM1.[TicketTecnicoCableEspecial], TM1.[TicketTecnicoOtrosTaller], TM1.[TicketTecnicoCerrado], TM1.[TicketTecnicoPendiente], TM1.[TicketTecnicoPasaTaller], TM1.[TicketTecnicoObservacion], TM1.[TicketTecnicoDetalle], TM1.[TicketId], TM1.[ResponsableId], TM1.[TicketResponsableId], TM1.[SgActividadId], TM1.[SgActividadIdCategoria], T2.[UsuarioId] FROM ((([TicketTecnico] TM1 INNER JOIN [Ticket] T2 ON T2.[TicketId] = TM1.[TicketId]) INNER JOIN [Usuario] T3 ON T3.[UsuarioId] = T2.[UsuarioId]) INNER JOIN [Responsable] T4 ON T4.[ResponsableId] = TM1.[ResponsableId]) WHERE TM1.[TicketTecnicoId] = @TicketTecnicoId ORDER BY TM1.[TicketTecnicoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000811", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000812", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000813", "SELECT [TicketId] FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000814", "SELECT [ResponsableNombre] FROM [Responsable] WHERE [ResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000814,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000817", "SELECT [TicketTecnicoId] FROM [TicketTecnico] WHERE [TicketTecnicoId] = @TicketTecnicoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000818", "SELECT TOP 1 [TicketTecnicoId] FROM [TicketTecnico] WHERE ( [TicketTecnicoId] > @TicketTecnicoId) ORDER BY [TicketTecnicoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000819", "SELECT TOP 1 [TicketTecnicoId] FROM [TicketTecnico] WHERE ( [TicketTecnicoId] < @TicketTecnicoId) ORDER BY [TicketTecnicoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000820", "INSERT INTO [TicketTecnico]([TicketTecnicoFecha], [TicketTecnicoHora], [TicketTecnicoInventarioSerie], [TicketTecnicoInstalacion], [TicketTecnicoConfiguracion], [TicketTecnicoInternetRouter], [TicketTecnicoFormateo], [TicketTecnicoReparacion], [TicketTecnicoLimpieza], [TicketTecnicoPuntoRed], [TicketTecnicoCambiosHardware], [TicketTecnicoCopiasRespaldo], [TicketTecnicoRam], [TicketTecnicoDiscoDuro], [TicketTecnicoProcesador], [TicketTecnicoMaletin], [TicketTecnicoTonerCinta], [TicketTecnicoTarjetaVideoExtra], [TicketTecnicoCargadorLaptop], [TicketTecnicoCDsDVDs], [TicketTecnicoCableEspecial], [TicketTecnicoOtrosTaller], [TicketTecnicoCerrado], [TicketTecnicoPendiente], [TicketTecnicoPasaTaller], [TicketTecnicoObservacion], [TicketTecnicoDetalle], [TicketId], [ResponsableId], [TicketResponsableId], [SgActividadId], [SgActividadIdCategoria]) VALUES(@TicketTecnicoFecha, @TicketTecnicoHora, @TicketTecnicoInventarioSerie, @TicketTecnicoInstalacion, @TicketTecnicoConfiguracion, @TicketTecnicoInternetRouter, @TicketTecnicoFormateo, @TicketTecnicoReparacion, @TicketTecnicoLimpieza, @TicketTecnicoPuntoRed, @TicketTecnicoCambiosHardware, @TicketTecnicoCopiasRespaldo, @TicketTecnicoRam, @TicketTecnicoDiscoDuro, @TicketTecnicoProcesador, @TicketTecnicoMaletin, @TicketTecnicoTonerCinta, @TicketTecnicoTarjetaVideoExtra, @TicketTecnicoCargadorLaptop, @TicketTecnicoCDsDVDs, @TicketTecnicoCableEspecial, @TicketTecnicoOtrosTaller, @TicketTecnicoCerrado, @TicketTecnicoPendiente, @TicketTecnicoPasaTaller, @TicketTecnicoObservacion, @TicketTecnicoDetalle, @TicketId, @ResponsableId, @TicketResponsableId, @SgActividadId, @SgActividadIdCategoria); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000820)
          ,new CursorDef("T000821", "UPDATE [TicketTecnico] SET [TicketTecnicoFecha]=@TicketTecnicoFecha, [TicketTecnicoHora]=@TicketTecnicoHora, [TicketTecnicoInventarioSerie]=@TicketTecnicoInventarioSerie, [TicketTecnicoInstalacion]=@TicketTecnicoInstalacion, [TicketTecnicoConfiguracion]=@TicketTecnicoConfiguracion, [TicketTecnicoInternetRouter]=@TicketTecnicoInternetRouter, [TicketTecnicoFormateo]=@TicketTecnicoFormateo, [TicketTecnicoReparacion]=@TicketTecnicoReparacion, [TicketTecnicoLimpieza]=@TicketTecnicoLimpieza, [TicketTecnicoPuntoRed]=@TicketTecnicoPuntoRed, [TicketTecnicoCambiosHardware]=@TicketTecnicoCambiosHardware, [TicketTecnicoCopiasRespaldo]=@TicketTecnicoCopiasRespaldo, [TicketTecnicoRam]=@TicketTecnicoRam, [TicketTecnicoDiscoDuro]=@TicketTecnicoDiscoDuro, [TicketTecnicoProcesador]=@TicketTecnicoProcesador, [TicketTecnicoMaletin]=@TicketTecnicoMaletin, [TicketTecnicoTonerCinta]=@TicketTecnicoTonerCinta, [TicketTecnicoTarjetaVideoExtra]=@TicketTecnicoTarjetaVideoExtra, [TicketTecnicoCargadorLaptop]=@TicketTecnicoCargadorLaptop, [TicketTecnicoCDsDVDs]=@TicketTecnicoCDsDVDs, [TicketTecnicoCableEspecial]=@TicketTecnicoCableEspecial, [TicketTecnicoOtrosTaller]=@TicketTecnicoOtrosTaller, [TicketTecnicoCerrado]=@TicketTecnicoCerrado, [TicketTecnicoPendiente]=@TicketTecnicoPendiente, [TicketTecnicoPasaTaller]=@TicketTecnicoPasaTaller, [TicketTecnicoObservacion]=@TicketTecnicoObservacion, [TicketTecnicoDetalle]=@TicketTecnicoDetalle, [TicketId]=@TicketId, [ResponsableId]=@ResponsableId, [TicketResponsableId]=@TicketResponsableId, [SgActividadId]=@SgActividadId, [SgActividadIdCategoria]=@SgActividadIdCategoria  WHERE [TicketTecnicoId] = @TicketTecnicoId", GxErrorMask.GX_NOMASK,prmT000821)
          ,new CursorDef("T000822", "DELETE FROM [TicketTecnico]  WHERE [TicketTecnicoId] = @TicketTecnicoId", GxErrorMask.GX_NOMASK,prmT000822)
          ,new CursorDef("T000823", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000823,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000824", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000824,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000825", "SELECT [ResponsableNombre] FROM [Responsable] WHERE [ResponsableId] = @ResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000825,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000828", "SELECT [TicketTecnicoId] FROM [TicketTecnico] ORDER BY [TicketTecnicoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000828,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000829", "SELECT [TicketId] FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000829,1, GxCacheFrequency.OFF ,true,false )
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
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             ((bool[]) buf[14])[0] = rslt.getBool(15);
             ((bool[]) buf[15])[0] = rslt.getBool(16);
             ((bool[]) buf[16])[0] = rslt.getBool(17);
             ((bool[]) buf[17])[0] = rslt.getBool(18);
             ((bool[]) buf[18])[0] = rslt.getBool(19);
             ((bool[]) buf[19])[0] = rslt.getBool(20);
             ((bool[]) buf[20])[0] = rslt.getBool(21);
             ((bool[]) buf[21])[0] = rslt.getBool(22);
             ((bool[]) buf[22])[0] = rslt.getBool(23);
             ((bool[]) buf[23])[0] = rslt.getBool(24);
             ((bool[]) buf[24])[0] = rslt.getBool(25);
             ((bool[]) buf[25])[0] = rslt.getBool(26);
             ((bool[]) buf[26])[0] = rslt.getBool(27);
             ((bool[]) buf[27])[0] = rslt.wasNull(27);
             ((string[]) buf[28])[0] = rslt.getVarchar(28);
             ((long[]) buf[29])[0] = rslt.getLong(29);
             ((short[]) buf[30])[0] = rslt.getShort(30);
             ((long[]) buf[31])[0] = rslt.getLong(31);
             ((int[]) buf[32])[0] = rslt.getInt(32);
             ((int[]) buf[33])[0] = rslt.getInt(33);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.getBool(5);
             ((bool[]) buf[5])[0] = rslt.getBool(6);
             ((bool[]) buf[6])[0] = rslt.getBool(7);
             ((bool[]) buf[7])[0] = rslt.getBool(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             ((bool[]) buf[14])[0] = rslt.getBool(15);
             ((bool[]) buf[15])[0] = rslt.getBool(16);
             ((bool[]) buf[16])[0] = rslt.getBool(17);
             ((bool[]) buf[17])[0] = rslt.getBool(18);
             ((bool[]) buf[18])[0] = rslt.getBool(19);
             ((bool[]) buf[19])[0] = rslt.getBool(20);
             ((bool[]) buf[20])[0] = rslt.getBool(21);
             ((bool[]) buf[21])[0] = rslt.getBool(22);
             ((bool[]) buf[22])[0] = rslt.getBool(23);
             ((bool[]) buf[23])[0] = rslt.getBool(24);
             ((bool[]) buf[24])[0] = rslt.getBool(25);
             ((bool[]) buf[25])[0] = rslt.getBool(26);
             ((bool[]) buf[26])[0] = rslt.getBool(27);
             ((bool[]) buf[27])[0] = rslt.wasNull(27);
             ((string[]) buf[28])[0] = rslt.getVarchar(28);
             ((long[]) buf[29])[0] = rslt.getLong(29);
             ((short[]) buf[30])[0] = rslt.getShort(30);
             ((long[]) buf[31])[0] = rslt.getLong(31);
             ((int[]) buf[32])[0] = rslt.getInt(32);
             ((int[]) buf[33])[0] = rslt.getInt(33);
             return;
          case 2 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 3 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 4 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((bool[]) buf[8])[0] = rslt.getBool(9);
             ((bool[]) buf[9])[0] = rslt.getBool(10);
             ((bool[]) buf[10])[0] = rslt.getBool(11);
             ((bool[]) buf[11])[0] = rslt.getBool(12);
             ((bool[]) buf[12])[0] = rslt.getBool(13);
             ((bool[]) buf[13])[0] = rslt.getBool(14);
             ((bool[]) buf[14])[0] = rslt.getBool(15);
             ((bool[]) buf[15])[0] = rslt.getBool(16);
             ((bool[]) buf[16])[0] = rslt.getBool(17);
             ((bool[]) buf[17])[0] = rslt.getBool(18);
             ((bool[]) buf[18])[0] = rslt.getBool(19);
             ((bool[]) buf[19])[0] = rslt.getBool(20);
             ((bool[]) buf[20])[0] = rslt.getBool(21);
             ((bool[]) buf[21])[0] = rslt.getBool(22);
             ((bool[]) buf[22])[0] = rslt.getBool(23);
             ((bool[]) buf[23])[0] = rslt.getBool(24);
             ((bool[]) buf[24])[0] = rslt.getBool(25);
             ((bool[]) buf[25])[0] = rslt.getBool(26);
             ((bool[]) buf[26])[0] = rslt.getBool(27);
             ((bool[]) buf[27])[0] = rslt.getBool(28);
             ((bool[]) buf[28])[0] = rslt.getBool(29);
             ((bool[]) buf[29])[0] = rslt.getBool(30);
             ((bool[]) buf[30])[0] = rslt.getBool(31);
             ((bool[]) buf[31])[0] = rslt.wasNull(31);
             ((string[]) buf[32])[0] = rslt.getVarchar(32);
             ((long[]) buf[33])[0] = rslt.getLong(33);
             ((short[]) buf[34])[0] = rslt.getShort(34);
             ((long[]) buf[35])[0] = rslt.getLong(35);
             ((int[]) buf[36])[0] = rslt.getInt(36);
             ((int[]) buf[37])[0] = rslt.getInt(37);
             ((short[]) buf[38])[0] = rslt.getShort(38);
             return;
          case 7 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
          case 17 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 18 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 19 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 20 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 21 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
