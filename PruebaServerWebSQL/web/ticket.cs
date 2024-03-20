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
   public class ticket : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
               AssignAttri(sPrefix, false, "AV7TicketId", StringUtil.LTrimStr( (decimal)(AV7TicketId), 10, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(long)AV7TicketId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel10"+"_"+"") == 0 )
            {
               A15UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA93077( A15UsuarioId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel11"+"_"+"") == 0 )
            {
               A187EstadoTicketTicketId = (short)(NumberUtil.Val( GetPar( "EstadoTicketTicketId"), "."));
               AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA188077( A187EstadoTicketTicketId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_32") == 0 )
            {
               A15UsuarioId = (short)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_32( A15UsuarioId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_33") == 0 )
            {
               A187EstadoTicketTicketId = (short)(NumberUtil.Val( GetPar( "EstadoTicketTicketId"), "."));
               AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_33( A187EstadoTicketTicketId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
            {
               A198TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_37( A198TicketTecnicoResponsableId) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridresponsable") == 0 )
            {
               nRC_GXsfl_242 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_242"), "."));
               nGXsfl_242_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_242_idx"), "."));
               sGXsfl_242_idx = GetPar( "sGXsfl_242_idx");
               sPrefix = GetPar( "sPrefix");
               A54TicketLastId = (long)(NumberUtil.Val( GetPar( "TicketLastId"), "."));
               Gx_BScreen = (short)(NumberUtil.Val( GetPar( "Gx_BScreen"), "."));
               Gx_mode = GetPar( "Mode");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGridresponsable_newrow( ) ;
               return  ;
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
                  AV7TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
                  AssignAttri(sPrefix, false, "AV7TicketId", StringUtil.LTrimStr( (decimal)(AV7TicketId), 10, 0));
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
               Form.Meta.addItem("description", "Ticket", 0) ;
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
            GX_FocusControl = edtUsuarioId_Internalname;
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

      public ticket( )
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

      public ticket( IGxContext context )
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
                           long aP1_TicketId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TicketId = aP1_TicketId;
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
         chkTicketLaptop = new GXCheckbox();
         chkTicketDesktop = new GXCheckbox();
         chkTicketMonitor = new GXCheckbox();
         chkTicketImpresora = new GXCheckbox();
         chkTicketEscaner = new GXCheckbox();
         chkTicketRouter = new GXCheckbox();
         chkTicketSistemaOperativo = new GXCheckbox();
         chkTicketOffice = new GXCheckbox();
         chkTicketAntivirus = new GXCheckbox();
         chkTicketAplicacion = new GXCheckbox();
         chkTicketDisenio = new GXCheckbox();
         chkTicketIngenieria = new GXCheckbox();
         chkTicketDiscoDuroExterno = new GXCheckbox();
         chkTicketPerifericos = new GXCheckbox();
         chkTicketUps = new GXCheckbox();
         chkTicketApoyoUsuario = new GXCheckbox();
         chkTicketInstalarDataShow = new GXCheckbox();
         chkTicketOtros = new GXCheckbox();
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
            return "ticket_Execute" ;
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
         A53TicketLaptop = StringUtil.StrToBool( StringUtil.BoolToStr( A53TicketLaptop));
         AssignAttri(sPrefix, false, "A53TicketLaptop", A53TicketLaptop);
         A42TicketDesktop = StringUtil.StrToBool( StringUtil.BoolToStr( A42TicketDesktop));
         AssignAttri(sPrefix, false, "A42TicketDesktop", A42TicketDesktop);
         A55TicketMonitor = StringUtil.StrToBool( StringUtil.BoolToStr( A55TicketMonitor));
         AssignAttri(sPrefix, false, "A55TicketMonitor", A55TicketMonitor);
         A50TicketImpresora = StringUtil.StrToBool( StringUtil.BoolToStr( A50TicketImpresora));
         AssignAttri(sPrefix, false, "A50TicketImpresora", A50TicketImpresora);
         A45TicketEscaner = StringUtil.StrToBool( StringUtil.BoolToStr( A45TicketEscaner));
         AssignAttri(sPrefix, false, "A45TicketEscaner", A45TicketEscaner);
         A59TicketRouter = StringUtil.StrToBool( StringUtil.BoolToStr( A59TicketRouter));
         AssignAttri(sPrefix, false, "A59TicketRouter", A59TicketRouter);
         A60TicketSistemaOperativo = StringUtil.StrToBool( StringUtil.BoolToStr( A60TicketSistemaOperativo));
         AssignAttri(sPrefix, false, "A60TicketSistemaOperativo", A60TicketSistemaOperativo);
         A56TicketOffice = StringUtil.StrToBool( StringUtil.BoolToStr( A56TicketOffice));
         AssignAttri(sPrefix, false, "A56TicketOffice", A56TicketOffice);
         A39TicketAntivirus = StringUtil.StrToBool( StringUtil.BoolToStr( A39TicketAntivirus));
         AssignAttri(sPrefix, false, "A39TicketAntivirus", A39TicketAntivirus);
         A40TicketAplicacion = StringUtil.StrToBool( StringUtil.BoolToStr( A40TicketAplicacion));
         AssignAttri(sPrefix, false, "A40TicketAplicacion", A40TicketAplicacion);
         A44TicketDisenio = StringUtil.StrToBool( StringUtil.BoolToStr( A44TicketDisenio));
         AssignAttri(sPrefix, false, "A44TicketDisenio", A44TicketDisenio);
         A51TicketIngenieria = StringUtil.StrToBool( StringUtil.BoolToStr( A51TicketIngenieria));
         AssignAttri(sPrefix, false, "A51TicketIngenieria", A51TicketIngenieria);
         A43TicketDiscoDuroExterno = StringUtil.StrToBool( StringUtil.BoolToStr( A43TicketDiscoDuroExterno));
         AssignAttri(sPrefix, false, "A43TicketDiscoDuroExterno", A43TicketDiscoDuroExterno);
         A58TicketPerifericos = StringUtil.StrToBool( StringUtil.BoolToStr( A58TicketPerifericos));
         AssignAttri(sPrefix, false, "A58TicketPerifericos", A58TicketPerifericos);
         A87TicketUps = StringUtil.StrToBool( StringUtil.BoolToStr( A87TicketUps));
         AssignAttri(sPrefix, false, "A87TicketUps", A87TicketUps);
         A41TicketApoyoUsuario = StringUtil.StrToBool( StringUtil.BoolToStr( A41TicketApoyoUsuario));
         AssignAttri(sPrefix, false, "A41TicketApoyoUsuario", A41TicketApoyoUsuario);
         A52TicketInstalarDataShow = StringUtil.StrToBool( StringUtil.BoolToStr( A52TicketInstalarDataShow));
         AssignAttri(sPrefix, false, "A52TicketInstalarDataShow", A52TicketInstalarDataShow);
         A57TicketOtros = StringUtil.StrToBool( StringUtil.BoolToStr( A57TicketOtros));
         AssignAttri(sPrefix, false, "A57TicketOtros", A57TicketOtros);
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
            RenderHtmlCloseForm077( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "ticket.aspx");
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
         GxWebStd.gx_div_start( context, divTabletextblocklnreqsopteccontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLnreqsoptec_Internalname, "REQUERIMIENTO DE SOPORTE TÉCNICO", "", "", lblLnreqsoptec_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarioid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioId_Internalname, "Id Usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,28);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioId_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Ticket.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_15_Internalname, sImgUrl, imgprompt_15_Link, "", "", context.GetTheme( ), imgprompt_15_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ticket.htm");
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
         GxWebStd.gx_label_element( context, edtTicketId_Internalname, "RST No.", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         GxWebStd.gx_single_line_edit( context, edtTicketId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ",", "")), ((edtTicketId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketfecha_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketFecha_Internalname, "Fecha:", "gx-form-item Attribute_TrnDateLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
         context.WriteHtmlText( "<div id=\""+edtTicketFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTicketFecha_Internalname, context.localUtil.Format(A46TicketFecha, "99/99/9999"), context.localUtil.Format( A46TicketFecha, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketFecha_Jsonclick, 0, edtTicketFecha_Class, "", "", "", "", 1, edtTicketFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_Ticket.htm");
         GxWebStd.gx_bitmap( context, edtTicketFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTicketFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickethora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketHora_Internalname, "Hora:", "gx-form-item Attribute_TrnDateTimeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
         context.WriteHtmlText( "<div id=\""+edtTicketHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTicketHora_Internalname, context.localUtil.TToC( A48TicketHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A48TicketHora, "99:99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketHora_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", 1, edtTicketHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Hora", "right", false, "", "HLP_Ticket.htm");
         GxWebStd.gx_bitmap( context, edtTicketHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTicketHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerusuarionombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtUsuarioNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuarioNombre_Internalname, "Usuario", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, A93UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtUsuarioNombre_Link, "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_Ticket.htm");
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
         GxWebStd.gx_html_textarea( context, edtUsuarioRequerimiento_Internalname, A94UsuarioRequerimiento, "", "", 0, 1, edtUsuarioRequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divClmestado_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmestado0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoticketticketnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoTicketTicketNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoTicketTicketNombre_Internalname, "Estado Ticket", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
         GxWebStd.gx_single_line_edit( context, edtEstadoTicketTicketNombre_Internalname, A188EstadoTicketTicketNombre, StringUtil.RTrim( context.localUtil.Format( A188EstadoTicketTicketNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtEstadoTicketTicketNombre_Link, "", "", "", edtEstadoTicketTicketNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoTicketTicketNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divTableclmestado1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerestadoticketticketid_Internalname, divK2btoolstable_attributecontainerestadoticketticketid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtEstadoTicketTicketId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtEstadoTicketTicketId_Internalname, "Estado Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEstadoTicketTicketId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A187EstadoTicketTicketId), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A187EstadoTicketTicketId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,96);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEstadoTicketTicketId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtEstadoTicketTicketId_Enabled, 1, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Ticket.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_187_Internalname, sImgUrl, imgprompt_187_Link, "", "", context.GetTheme( ), imgprompt_187_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divTableclmestado2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketlastid_Internalname, divK2btoolstable_attributecontainerticketlastid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketLastId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketLastId_Internalname, "Last Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         GxWebStd.gx_single_line_edit( context, edtTicketLastId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A54TicketLastId), 10, 0, ",", "")), ((edtTicketLastId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")) : context.localUtil.Format( (decimal)(A54TicketLastId), "ZZZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketLastId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketLastId_Enabled, 0, "number", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Ticket.htm");
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
         GxWebStd.gx_div_start( context, divClmcat_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableclmcat0_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabletextblocktxthardwarecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxthardware_Internalname, "Hardware:", "", "", lblTxthardware_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketlaptop_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketLaptop_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketLaptop_Internalname, "aptop", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A53TicketLaptop", A53TicketLaptop);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketLaptop_Internalname, StringUtil.BoolToStr( A53TicketLaptop), "", "aptop", 1, chkTicketLaptop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(120, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,120);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketdesktop_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketDesktop_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketDesktop_Internalname, "Desktop", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A42TicketDesktop", A42TicketDesktop);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketDesktop_Internalname, StringUtil.BoolToStr( A42TicketDesktop), "", "Desktop", 1, chkTicketDesktop.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(126, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,126);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketmonitor_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketMonitor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketMonitor_Internalname, "Monitor", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A55TicketMonitor", A55TicketMonitor);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketMonitor_Internalname, StringUtil.BoolToStr( A55TicketMonitor), "", "Monitor", 1, chkTicketMonitor.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(132, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,132);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketimpresora_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketImpresora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketImpresora_Internalname, "Impresora", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A50TicketImpresora", A50TicketImpresora);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketImpresora_Internalname, StringUtil.BoolToStr( A50TicketImpresora), "", "Impresora", 1, chkTicketImpresora.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(138, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,138);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketescaner_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketEscaner_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketEscaner_Internalname, "Escaner", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A45TicketEscaner", A45TicketEscaner);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 144,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketEscaner_Internalname, StringUtil.BoolToStr( A45TicketEscaner), "", "Escaner", 1, chkTicketEscaner.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(144, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,144);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketrouter_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketRouter_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketRouter_Internalname, "Internet/Router/Access Point", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A59TicketRouter", A59TicketRouter);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketRouter_Internalname, StringUtil.BoolToStr( A59TicketRouter), "", "Internet/Router/Access Point", 1, chkTicketRouter.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(150, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,150);\"");
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
         GxWebStd.gx_div_start( context, divTableclmcat1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabletextblocktxtsoftwarecontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtsoftware_Internalname, "Software:", "", "", lblTxtsoftware_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketsistemaoperativo_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketSistemaOperativo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketSistemaOperativo_Internalname, "Operativo", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A60TicketSistemaOperativo", A60TicketSistemaOperativo);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 162,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketSistemaOperativo_Internalname, StringUtil.BoolToStr( A60TicketSistemaOperativo), "", "Operativo", 1, chkTicketSistemaOperativo.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(162, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,162);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketoffice_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketOffice_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketOffice_Internalname, "Office", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A56TicketOffice", A56TicketOffice);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 168,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketOffice_Internalname, StringUtil.BoolToStr( A56TicketOffice), "", "Office", 1, chkTicketOffice.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(168, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,168);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketantivirus_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketAntivirus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketAntivirus_Internalname, "Antivirus", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A39TicketAntivirus", A39TicketAntivirus);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 174,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketAntivirus_Internalname, StringUtil.BoolToStr( A39TicketAntivirus), "", "Antivirus", 1, chkTicketAntivirus.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(174, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,174);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketaplicacion_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketAplicacion_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketAplicacion_Internalname, "Aplicación", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A40TicketAplicacion", A40TicketAplicacion);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 180,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketAplicacion_Internalname, StringUtil.BoolToStr( A40TicketAplicacion), "", "Aplicación", 1, chkTicketAplicacion.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(180, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,180);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketdisenio_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketDisenio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketDisenio_Internalname, "Diseño", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A44TicketDisenio", A44TicketDisenio);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketDisenio_Internalname, StringUtil.BoolToStr( A44TicketDisenio), "", "Diseño", 1, chkTicketDisenio.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(186, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,186);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketingenieria_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketIngenieria_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketIngenieria_Internalname, "Ingeniería", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A51TicketIngenieria", A51TicketIngenieria);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 192,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketIngenieria_Internalname, StringUtil.BoolToStr( A51TicketIngenieria), "", "Ingeniería", 1, chkTicketIngenieria.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(192, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,192);\"");
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
         GxWebStd.gx_div_start( context, divTableclmcat2_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTabletextblocktxtotroscontainer_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTxtotros_Internalname, "Otros:", "", "", lblTxtotros_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", 0, "", 1, 1, 0, 0, "HLP_Ticket.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketdiscoduroexterno_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketDiscoDuroExterno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketDiscoDuroExterno_Internalname, "Duro ", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A43TicketDiscoDuroExterno", A43TicketDiscoDuroExterno);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 204,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketDiscoDuroExterno_Internalname, StringUtil.BoolToStr( A43TicketDiscoDuroExterno), "", "Duro ", 1, chkTicketDiscoDuroExterno.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(204, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,204);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketperifericos_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketPerifericos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketPerifericos_Internalname, "Periféricos", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A58TicketPerifericos", A58TicketPerifericos);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketPerifericos_Internalname, StringUtil.BoolToStr( A58TicketPerifericos), "", "Periféricos", 1, chkTicketPerifericos.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(210, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,210);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketups_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketUps_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketUps_Internalname, "UPS", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A87TicketUps", A87TicketUps);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketUps_Internalname, StringUtil.BoolToStr( A87TicketUps), "", "UPS", 1, chkTicketUps.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(216, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,216);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketapoyousuario_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketApoyoUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketApoyoUsuario_Internalname, "Usuario", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A41TicketApoyoUsuario", A41TicketApoyoUsuario);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketApoyoUsuario_Internalname, StringUtil.BoolToStr( A41TicketApoyoUsuario), "", "Usuario", 1, chkTicketApoyoUsuario.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(222, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,222);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketinstalardatashow_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketInstalarDataShow_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketInstalarDataShow_Internalname, "Data Show", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A52TicketInstalarDataShow", A52TicketInstalarDataShow);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 228,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketInstalarDataShow_Internalname, StringUtil.BoolToStr( A52TicketInstalarDataShow), "", "Data Show", 1, chkTicketInstalarDataShow.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(228, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,228);\"");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketotros_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+chkTicketOtros_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTicketOtros_Internalname, "Otros", "gx-form-item CheckBoxAttributeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         AssignAttri(sPrefix, false, "A57TicketOtros", A57TicketOtros);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 234,'" + sPrefix + "',false,'',0)\"";
         ClassString = "CheckBoxAttribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTicketOtros_Internalname, StringUtil.BoolToStr( A57TicketOtros), "", "Otros", 1, chkTicketOtros.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(234, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,234);\"");
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
         GxWebStd.gx_div_start( context, divK2btrnformmaintablecell2_Internalname, 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divDiv_level_container_responsable_Internalname, 1, 0, "px", 0, "px", "Section_TrnFreeStyleContainer", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock_header_responsable_Internalname, "Responsable", "", "", lblTextblock_header_responsable_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "TextBlock_LevelHeaderTitle", 0, "", 1, 1, 0, 0, "HLP_Ticket.htm");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaingrid_responsivetable_gridresponsable_Internalname, 1, 0, "px", 0, "px", "Section_Grid", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridresponsable( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 255,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 257,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Ticket.htm");
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

      protected void gxdraw_Gridresponsable( )
      {
         /*  Grid Control  */
         GridresponsableContainer.AddObjectProperty("GridName", "Gridresponsable");
         GridresponsableContainer.AddObjectProperty("Header", subGridresponsable_Header);
         GridresponsableContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridresponsableContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Backcolorstyle), 1, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Sortable), 1, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("CmpContext", sPrefix);
         GridresponsableContainer.AddObjectProperty("InMasterPage", "false");
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketResponsableId_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", A199TicketTecnicoResponsableNombre);
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", context.localUtil.Format(A47TicketFechaResponsable, "99/99/9999"));
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", context.localUtil.TToC( A49TicketHoraResponsable, 10, 8, 0, 3, "/", ":", " "));
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ".", "")));
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         GridresponsableColumn.AddObjectProperty("Value", A25EstadoTicketTecnicoNombre);
         GridresponsableColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0, ".", "")));
         GridresponsableContainer.AddColumnProperties(GridresponsableColumn);
         GridresponsableContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Selectedindex), 4, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Allowselection), 1, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Selectioncolor), 9, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Allowhovering), 1, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Hoveringcolor), 9, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Allowcollapsing), 1, 0, ".", "")));
         GridresponsableContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridresponsable_Collapsed), 1, 0, ".", "")));
         nGXsfl_242_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount8 = (short)(subGridresponsable_Rows);
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_8 = 1;
               ScanStart078( ) ;
               while ( RcdFound8 != 0 )
               {
                  init_level_properties8( ) ;
                  getByPrimaryKey078( ) ;
                  AddRow078( ) ;
                  ScanNext078( ) ;
               }
               ScanEnd078( ) ;
               nBlankRcdCount8 = (short)(subGridresponsable_Rows);
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B54TicketLastId = A54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            standaloneNotModal078( ) ;
            standaloneModal078( ) ;
            sMode8 = Gx_mode;
            while ( nGXsfl_242_idx < nRC_GXsfl_242 )
            {
               bGXsfl_242_Refreshing = true;
               ReadRow078( ) ;
               edtTicketResponsableId_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               edtTicketTecnicoResponsableId_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtTicketTecnicoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               edtTicketTecnicoResponsableNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtTicketTecnicoResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               edtTicketFechaResponsable_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtTicketFechaResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               edtTicketHoraResponsable_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtTicketHoraResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               edtEstadoTicketTecnicoId_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtEstadoTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               edtEstadoTicketTecnicoNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
               AssignProp(sPrefix, false, edtEstadoTicketTecnicoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0), !bGXsfl_242_Refreshing);
               imgprompt_15_Link = cgiGet( sPrefix+"PROMPT_198_"+sGXsfl_242_idx+"Link");
               if ( ( nRcdExists_8 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  standaloneModal078( ) ;
               }
               SendRow078( ) ;
               bGXsfl_242_Refreshing = false;
            }
            Gx_mode = sMode8;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            A54TicketLastId = B54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount8 = (short)(subGridresponsable_Rows);
            nRcdExists_8 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart078( ) ;
               while ( RcdFound8 != 0 )
               {
                  sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_2428( ) ;
                  init_level_properties8( ) ;
                  standaloneNotModal078( ) ;
                  getByPrimaryKey078( ) ;
                  standaloneModal078( ) ;
                  AddRow078( ) ;
                  ScanNext078( ) ;
               }
               ScanEnd078( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode8 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx+1), 4, 0), 4, "0");
            SubsflControlProps_2428( ) ;
            InitAll078( ) ;
            init_level_properties8( ) ;
            B54TicketLastId = A54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            nRcdExists_8 = 0;
            nIsMod_8 = 0;
            nRcdDeleted_8 = 0;
            nBlankRcdCount8 = (short)(nBlankRcdUsr8+nBlankRcdCount8);
            fRowAdded = 0;
            while ( nBlankRcdCount8 > 0 )
            {
               standaloneNotModal078( ) ;
               standaloneModal078( ) ;
               AddRow078( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtTicketResponsableId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount8 = (short)(nBlankRcdCount8-1);
            }
            Gx_mode = sMode8;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            A54TicketLastId = B54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+sPrefix+"GridresponsableContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Gridresponsable", GridresponsableContainer);
         if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"GridresponsableContainerData", GridresponsableContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"GridresponsableContainerData"+"V", GridresponsableContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridresponsableContainerData"+"V"+"\" value='"+GridresponsableContainer.GridValuesHidden()+"'/>") ;
         }
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
         E11072 ();
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
               Z14TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z14TicketId"), ",", "."));
               Z46TicketFecha = context.localUtil.CToD( cgiGet( sPrefix+"Z46TicketFecha"), 0);
               Z48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+"Z48TicketHora"), 0));
               Z54TicketLastId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z54TicketLastId"), ",", "."));
               Z285TicketHoraCaracter = cgiGet( sPrefix+"Z285TicketHoraCaracter");
               Z53TicketLaptop = StringUtil.StrToBool( cgiGet( sPrefix+"Z53TicketLaptop"));
               Z42TicketDesktop = StringUtil.StrToBool( cgiGet( sPrefix+"Z42TicketDesktop"));
               Z55TicketMonitor = StringUtil.StrToBool( cgiGet( sPrefix+"Z55TicketMonitor"));
               Z50TicketImpresora = StringUtil.StrToBool( cgiGet( sPrefix+"Z50TicketImpresora"));
               Z45TicketEscaner = StringUtil.StrToBool( cgiGet( sPrefix+"Z45TicketEscaner"));
               Z59TicketRouter = StringUtil.StrToBool( cgiGet( sPrefix+"Z59TicketRouter"));
               Z60TicketSistemaOperativo = StringUtil.StrToBool( cgiGet( sPrefix+"Z60TicketSistemaOperativo"));
               Z56TicketOffice = StringUtil.StrToBool( cgiGet( sPrefix+"Z56TicketOffice"));
               Z39TicketAntivirus = StringUtil.StrToBool( cgiGet( sPrefix+"Z39TicketAntivirus"));
               Z40TicketAplicacion = StringUtil.StrToBool( cgiGet( sPrefix+"Z40TicketAplicacion"));
               Z44TicketDisenio = StringUtil.StrToBool( cgiGet( sPrefix+"Z44TicketDisenio"));
               Z51TicketIngenieria = StringUtil.StrToBool( cgiGet( sPrefix+"Z51TicketIngenieria"));
               Z43TicketDiscoDuroExterno = StringUtil.StrToBool( cgiGet( sPrefix+"Z43TicketDiscoDuroExterno"));
               Z58TicketPerifericos = StringUtil.StrToBool( cgiGet( sPrefix+"Z58TicketPerifericos"));
               Z87TicketUps = StringUtil.StrToBool( cgiGet( sPrefix+"Z87TicketUps"));
               Z41TicketApoyoUsuario = StringUtil.StrToBool( cgiGet( sPrefix+"Z41TicketApoyoUsuario"));
               Z52TicketInstalarDataShow = StringUtil.StrToBool( cgiGet( sPrefix+"Z52TicketInstalarDataShow"));
               Z57TicketOtros = StringUtil.StrToBool( cgiGet( sPrefix+"Z57TicketOtros"));
               Z278TicketUsuarioAsigno = cgiGet( sPrefix+"Z278TicketUsuarioAsigno");
               Z289TicketFechaHora = context.localUtil.CToT( cgiGet( sPrefix+"Z289TicketFechaHora"), 0);
               n289TicketFechaHora = ((DateTime.MinValue==A289TicketFechaHora) ? true : false);
               Z15UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z15UsuarioId"), ",", "."));
               Z187EstadoTicketTicketId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z187EstadoTicketTicketId"), ",", "."));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7TicketId"), ",", "."));
               A285TicketHoraCaracter = cgiGet( sPrefix+"Z285TicketHoraCaracter");
               A278TicketUsuarioAsigno = cgiGet( sPrefix+"Z278TicketUsuarioAsigno");
               A289TicketFechaHora = context.localUtil.CToT( cgiGet( sPrefix+"Z289TicketFechaHora"), 0);
               n289TicketFechaHora = false;
               n289TicketFechaHora = ((DateTime.MinValue==A289TicketFechaHora) ? true : false);
               O54TicketLastId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"O54TicketLastId"), ",", "."));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ",", "."));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ",", "."));
               Gx_mode = cgiGet( sPrefix+"Mode");
               nRC_GXsfl_242 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_242"), ",", "."));
               N15UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N15UsuarioId"), ",", "."));
               N187EstadoTicketTicketId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N187EstadoTicketTicketId"), ",", "."));
               AV7TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vTICKETID"), ",", "."));
               AV12Insert_UsuarioId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_USUARIOID"), ",", "."));
               AV26Insert_EstadoTicketTicketId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_ESTADOTICKETTICKETID"), ",", "."));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ",", "."));
               A278TicketUsuarioAsigno = cgiGet( sPrefix+"TICKETUSUARIOASIGNO");
               A285TicketHoraCaracter = cgiGet( sPrefix+"TICKETHORACARACTER");
               A289TicketFechaHora = context.localUtil.CToT( cgiGet( sPrefix+"TICKETFECHAHORA"), 0);
               n289TicketFechaHora = ((DateTime.MinValue==A289TicketFechaHora) ? true : false);
               A91UsuarioGerencia = cgiGet( sPrefix+"USUARIOGERENCIA");
               A88UsuarioDepartamento = cgiGet( sPrefix+"USUARIODEPARTAMENTO");
               AV30Pgmname = cgiGet( sPrefix+"vPGMNAME");
               A145TicketResponsableInventarioSerie = cgiGet( sPrefix+"TICKETRESPONSABLEINVENTARIOSERIE");
               n145TicketResponsableInventarioSerie = false;
               n145TicketResponsableInventarioSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A145TicketResponsableInventarioSerie)) ? true : false);
               A146TicketResponsableInstalacion = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEINSTALACION"));
               n146TicketResponsableInstalacion = false;
               n146TicketResponsableInstalacion = ((false==A146TicketResponsableInstalacion) ? true : false);
               A147TicketResponsableConfiguracion = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLECONFIGURACION"));
               n147TicketResponsableConfiguracion = false;
               n147TicketResponsableConfiguracion = ((false==A147TicketResponsableConfiguracion) ? true : false);
               A148TicketResponsableInternetRouter = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEINTERNETROUTER"));
               n148TicketResponsableInternetRouter = false;
               n148TicketResponsableInternetRouter = ((false==A148TicketResponsableInternetRouter) ? true : false);
               A149TicketResponsableFormateo = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEFORMATEO"));
               n149TicketResponsableFormateo = false;
               n149TicketResponsableFormateo = ((false==A149TicketResponsableFormateo) ? true : false);
               A150TicketResponsableReparacion = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEREPARACION"));
               n150TicketResponsableReparacion = false;
               n150TicketResponsableReparacion = ((false==A150TicketResponsableReparacion) ? true : false);
               A151TicketResponsableLimpieza = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLELIMPIEZA"));
               n151TicketResponsableLimpieza = false;
               n151TicketResponsableLimpieza = ((false==A151TicketResponsableLimpieza) ? true : false);
               A152TicketResponsablePuntoRed = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEPUNTORED"));
               n152TicketResponsablePuntoRed = false;
               n152TicketResponsablePuntoRed = ((false==A152TicketResponsablePuntoRed) ? true : false);
               A153TicketResponsableCambiosHardware = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLECAMBIOSHARDWARE"));
               n153TicketResponsableCambiosHardware = false;
               n153TicketResponsableCambiosHardware = ((false==A153TicketResponsableCambiosHardware) ? true : false);
               A154TicketResponsableCopiasRespaldo = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLECOPIASRESPALDO"));
               n154TicketResponsableCopiasRespaldo = false;
               n154TicketResponsableCopiasRespaldo = ((false==A154TicketResponsableCopiasRespaldo) ? true : false);
               A165TicketResponsableCerrado = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLECERRADO"));
               n165TicketResponsableCerrado = false;
               n165TicketResponsableCerrado = ((false==A165TicketResponsableCerrado) ? true : false);
               A166TicketResponsablePendiente = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEPENDIENTE"));
               n166TicketResponsablePendiente = false;
               n166TicketResponsablePendiente = ((false==A166TicketResponsablePendiente) ? true : false);
               A167TicketResponsablePasaTaller = StringUtil.StrToBool( cgiGet( sPrefix+"TICKETRESPONSABLEPASATALLER"));
               n167TicketResponsablePasaTaller = false;
               n167TicketResponsablePasaTaller = ((false==A167TicketResponsablePasaTaller) ? true : false);
               A168TicketResponsableObservacion = cgiGet( sPrefix+"TICKETRESPONSABLEOBSERVACION");
               n168TicketResponsableObservacion = false;
               n168TicketResponsableObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A168TicketResponsableObservacion)) ? true : false);
               A175TicketResponsableFechaResuelve = context.localUtil.CToD( cgiGet( sPrefix+"TICKETRESPONSABLEFECHARESUELVE"), 0);
               n175TicketResponsableFechaResuelve = false;
               n175TicketResponsableFechaResuelve = ((DateTime.MinValue==A175TicketResponsableFechaResuelve) ? true : false);
               A176TicketResponsableHoraResuelve = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+"TICKETRESPONSABLEHORARESUELVE"), 0));
               n176TicketResponsableHoraResuelve = false;
               n176TicketResponsableHoraResuelve = ((DateTime.MinValue==A176TicketResponsableHoraResuelve) ? true : false);
               A177TicketResponsableRamTxt = cgiGet( sPrefix+"TICKETRESPONSABLERAMTXT");
               n177TicketResponsableRamTxt = false;
               n177TicketResponsableRamTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A177TicketResponsableRamTxt)) ? true : false);
               A178TicketResponsableDiscoDuroTxt = cgiGet( sPrefix+"TICKETRESPONSABLEDISCODUROTXT");
               n178TicketResponsableDiscoDuroTxt = false;
               n178TicketResponsableDiscoDuroTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A178TicketResponsableDiscoDuroTxt)) ? true : false);
               A179TicketResponsableProcesadorTxt = cgiGet( sPrefix+"TICKETRESPONSABLEPROCESADORTXT");
               n179TicketResponsableProcesadorTxt = false;
               n179TicketResponsableProcesadorTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A179TicketResponsableProcesadorTxt)) ? true : false);
               A180TicketResponsableMaletinTxt = cgiGet( sPrefix+"TICKETRESPONSABLEMALETINTXT");
               n180TicketResponsableMaletinTxt = false;
               n180TicketResponsableMaletinTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A180TicketResponsableMaletinTxt)) ? true : false);
               A181TicketResponsableTonerCintaTxt = cgiGet( sPrefix+"TICKETRESPONSABLETONERCINTATXT");
               n181TicketResponsableTonerCintaTxt = false;
               n181TicketResponsableTonerCintaTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A181TicketResponsableTonerCintaTxt)) ? true : false);
               A182TicketResponsableTarjetaVideoExtraTxt = cgiGet( sPrefix+"TICKETRESPONSABLETARJETAVIDEOEXTRATXT");
               n182TicketResponsableTarjetaVideoExtraTxt = false;
               n182TicketResponsableTarjetaVideoExtraTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A182TicketResponsableTarjetaVideoExtraTxt)) ? true : false);
               A183TicketResponsableCargadorLaptopTxt = cgiGet( sPrefix+"TICKETRESPONSABLECARGADORLAPTOPTXT");
               n183TicketResponsableCargadorLaptopTxt = false;
               n183TicketResponsableCargadorLaptopTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A183TicketResponsableCargadorLaptopTxt)) ? true : false);
               A184TicketResponsableCDsDVDsTxt = cgiGet( sPrefix+"TICKETRESPONSABLECDSDVDSTXT");
               n184TicketResponsableCDsDVDsTxt = false;
               n184TicketResponsableCDsDVDsTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A184TicketResponsableCDsDVDsTxt)) ? true : false);
               A185TicketResponsableCableEspecialTxt = cgiGet( sPrefix+"TICKETRESPONSABLECABLEESPECIALTXT");
               n185TicketResponsableCableEspecialTxt = false;
               n185TicketResponsableCableEspecialTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A185TicketResponsableCableEspecialTxt)) ? true : false);
               A186TicketResponsableOtrosTallerTxt = cgiGet( sPrefix+"TICKETRESPONSABLEOTROSTALLERTXT");
               n186TicketResponsableOtrosTallerTxt = false;
               n186TicketResponsableOtrosTallerTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A186TicketResponsableOtrosTallerTxt)) ? true : false);
               A287TicketResponsableFechaHoraAsigna = context.localUtil.CToT( cgiGet( sPrefix+"TICKETRESPONSABLEFECHAHORAASIGNA"), 0);
               n287TicketResponsableFechaHoraAsigna = false;
               n287TicketResponsableFechaHoraAsigna = ((DateTime.MinValue==A287TicketResponsableFechaHoraAsigna) ? true : false);
               A288TicketResponsableFechaHoraResuelve = context.localUtil.CToT( cgiGet( sPrefix+"TICKETRESPONSABLEFECHAHORARESUELVE"), 0);
               n288TicketResponsableFechaHoraResuelve = false;
               n288TicketResponsableFechaHoraResuelve = ((DateTime.MinValue==A288TicketResponsableFechaHoraResuelve) ? true : false);
               A290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"ETAPADESARROLLOID"), ",", "."));
               n290EtapaDesarrolloId = false;
               n290EtapaDesarrolloId = ((0==A290EtapaDesarrolloId) ? true : false);
               A291EtapaDesarrolloNombre = cgiGet( sPrefix+"ETAPADESARROLLONOMBRE");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Updateselects = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updateselects"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ",", "."));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUARIOID");
                  AnyError = 1;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A15UsuarioId = 0;
                  AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               }
               else
               {
                  A15UsuarioId = (short)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
               }
               A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               A46TicketFecha = context.localUtil.CToD( cgiGet( edtTicketFecha_Internalname), 2);
               AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
               A48TicketHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHora_Internalname)));
               AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
               A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
               AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
               A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
               AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
               A188EstadoTicketTicketNombre = cgiGet( edtEstadoTicketTicketNombre_Internalname);
               AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtEstadoTicketTicketId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEstadoTicketTicketId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ESTADOTICKETTICKETID");
                  AnyError = 1;
                  GX_FocusControl = edtEstadoTicketTicketId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A187EstadoTicketTicketId = 0;
                  AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
               }
               else
               {
                  A187EstadoTicketTicketId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketTicketId_Internalname), ",", "."));
                  AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
               }
               A54TicketLastId = (long)(context.localUtil.CToN( cgiGet( edtTicketLastId_Internalname), ",", "."));
               AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
               A53TicketLaptop = StringUtil.StrToBool( cgiGet( chkTicketLaptop_Internalname));
               AssignAttri(sPrefix, false, "A53TicketLaptop", A53TicketLaptop);
               A42TicketDesktop = StringUtil.StrToBool( cgiGet( chkTicketDesktop_Internalname));
               AssignAttri(sPrefix, false, "A42TicketDesktop", A42TicketDesktop);
               A55TicketMonitor = StringUtil.StrToBool( cgiGet( chkTicketMonitor_Internalname));
               AssignAttri(sPrefix, false, "A55TicketMonitor", A55TicketMonitor);
               A50TicketImpresora = StringUtil.StrToBool( cgiGet( chkTicketImpresora_Internalname));
               AssignAttri(sPrefix, false, "A50TicketImpresora", A50TicketImpresora);
               A45TicketEscaner = StringUtil.StrToBool( cgiGet( chkTicketEscaner_Internalname));
               AssignAttri(sPrefix, false, "A45TicketEscaner", A45TicketEscaner);
               A59TicketRouter = StringUtil.StrToBool( cgiGet( chkTicketRouter_Internalname));
               AssignAttri(sPrefix, false, "A59TicketRouter", A59TicketRouter);
               A60TicketSistemaOperativo = StringUtil.StrToBool( cgiGet( chkTicketSistemaOperativo_Internalname));
               AssignAttri(sPrefix, false, "A60TicketSistemaOperativo", A60TicketSistemaOperativo);
               A56TicketOffice = StringUtil.StrToBool( cgiGet( chkTicketOffice_Internalname));
               AssignAttri(sPrefix, false, "A56TicketOffice", A56TicketOffice);
               A39TicketAntivirus = StringUtil.StrToBool( cgiGet( chkTicketAntivirus_Internalname));
               AssignAttri(sPrefix, false, "A39TicketAntivirus", A39TicketAntivirus);
               A40TicketAplicacion = StringUtil.StrToBool( cgiGet( chkTicketAplicacion_Internalname));
               AssignAttri(sPrefix, false, "A40TicketAplicacion", A40TicketAplicacion);
               A44TicketDisenio = StringUtil.StrToBool( cgiGet( chkTicketDisenio_Internalname));
               AssignAttri(sPrefix, false, "A44TicketDisenio", A44TicketDisenio);
               A51TicketIngenieria = StringUtil.StrToBool( cgiGet( chkTicketIngenieria_Internalname));
               AssignAttri(sPrefix, false, "A51TicketIngenieria", A51TicketIngenieria);
               A43TicketDiscoDuroExterno = StringUtil.StrToBool( cgiGet( chkTicketDiscoDuroExterno_Internalname));
               AssignAttri(sPrefix, false, "A43TicketDiscoDuroExterno", A43TicketDiscoDuroExterno);
               A58TicketPerifericos = StringUtil.StrToBool( cgiGet( chkTicketPerifericos_Internalname));
               AssignAttri(sPrefix, false, "A58TicketPerifericos", A58TicketPerifericos);
               A87TicketUps = StringUtil.StrToBool( cgiGet( chkTicketUps_Internalname));
               AssignAttri(sPrefix, false, "A87TicketUps", A87TicketUps);
               A41TicketApoyoUsuario = StringUtil.StrToBool( cgiGet( chkTicketApoyoUsuario_Internalname));
               AssignAttri(sPrefix, false, "A41TicketApoyoUsuario", A41TicketApoyoUsuario);
               A52TicketInstalarDataShow = StringUtil.StrToBool( cgiGet( chkTicketInstalarDataShow_Internalname));
               AssignAttri(sPrefix, false, "A52TicketInstalarDataShow", A52TicketInstalarDataShow);
               A57TicketOtros = StringUtil.StrToBool( cgiGet( chkTicketOtros_Internalname));
               AssignAttri(sPrefix, false, "A57TicketOtros", A57TicketOtros);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Ticket");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("TicketHoraCaracter", StringUtil.RTrim( context.localUtil.Format( A285TicketHoraCaracter, "")));
               forbiddenHiddens.Add("TicketFechaHora", context.localUtil.Format( A289TicketFechaHora, "99/99/9999 99:99:99"));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A14TicketId != Z14TicketId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("ticket:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A14TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
                  AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TICKETID");
                        AnyError = 1;
                        GX_FocusControl = edtTicketId_Internalname;
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
                                 E11072 ();
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
                                 E12072 ();
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
                                 E13072 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
            DisableAttributes077( ) ;
         }
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketLaptop.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketDesktop.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketMonitor.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketImpresora.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketEscaner.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketRouter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketRouter.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketSistemaOperativo.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketOffice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketOffice.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketAntivirus.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketAplicacion.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketDisenio.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketIngenieria.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketDiscoDuroExterno.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketPerifericos.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketUps_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketUps.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketApoyoUsuario.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketInstalarDataShow.Enabled), 5, 0), true);
         AssignProp(sPrefix, false, chkTicketOtros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketOtros.Enabled), 5, 0), true);
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode7 = Gx_mode;
            CONFIRM_078( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode7;
               AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode7;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_078( )
      {
         s54TicketLastId = O54TicketLastId;
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         nGXsfl_242_idx = 0;
         while ( nGXsfl_242_idx < nRC_GXsfl_242 )
         {
            ReadRow078( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               GetKey078( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  if ( RcdFound8 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     BeforeValidate078( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable078( ) ;
                        CloseExtendedTableCursors078( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O54TicketLastId = A54TicketLastId;
                        AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "TICKETRESPONSABLEID_" + sGXsfl_242_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtTicketResponsableId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( nRcdDeleted_8 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        getByPrimaryKey078( ) ;
                        Load078( ) ;
                        BeforeValidate078( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls078( ) ;
                           O54TicketLastId = A54TicketLastId;
                           AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           BeforeValidate078( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable078( ) ;
                              CloseExtendedTableCursors078( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O54TicketLastId = A54TicketLastId;
                              AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "TICKETRESPONSABLEID_" + sGXsfl_242_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTicketResponsableId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( sPrefix+edtTicketResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtTicketTecnicoResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtTicketTecnicoResponsableNombre_Internalname, A199TicketTecnicoResponsableNombre) ;
            ChangePostValue( sPrefix+edtTicketFechaResponsable_Internalname, context.localUtil.Format(A47TicketFechaResponsable, "99/99/9999")) ;
            ChangePostValue( sPrefix+edtTicketHoraResponsable_Internalname, context.localUtil.TToC( A49TicketHoraResponsable, 10, 8, 0, 3, "/", ":", " ")) ;
            ChangePostValue( sPrefix+edtEstadoTicketTecnicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtEstadoTicketTecnicoNombre_Internalname, A25EstadoTicketTecnicoNombre) ;
            ChangePostValue( sPrefix+"ZT_"+"Z16TicketResponsableId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16TicketResponsableId), 10, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z49TicketHoraResponsable_"+sGXsfl_242_idx, context.localUtil.TToC( Z49TicketHoraResponsable, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z47TicketFechaResponsable_"+sGXsfl_242_idx, context.localUtil.DToC( Z47TicketFechaResponsable, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z145TicketResponsableInventarioSerie_"+sGXsfl_242_idx, Z145TicketResponsableInventarioSerie) ;
            ChangePostValue( sPrefix+"ZT_"+"Z146TicketResponsableInstalacion_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z146TicketResponsableInstalacion)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z147TicketResponsableConfiguracion_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z147TicketResponsableConfiguracion)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z148TicketResponsableInternetRouter_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z148TicketResponsableInternetRouter)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z149TicketResponsableFormateo_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z149TicketResponsableFormateo)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z150TicketResponsableReparacion_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z150TicketResponsableReparacion)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z151TicketResponsableLimpieza_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z151TicketResponsableLimpieza)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z152TicketResponsablePuntoRed_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z152TicketResponsablePuntoRed)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z153TicketResponsableCambiosHardware_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z153TicketResponsableCambiosHardware)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z154TicketResponsableCopiasRespaldo_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z154TicketResponsableCopiasRespaldo)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z165TicketResponsableCerrado_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z165TicketResponsableCerrado)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z166TicketResponsablePendiente_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z166TicketResponsablePendiente)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z167TicketResponsablePasaTaller_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z167TicketResponsablePasaTaller)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z168TicketResponsableObservacion_"+sGXsfl_242_idx, Z168TicketResponsableObservacion) ;
            ChangePostValue( sPrefix+"ZT_"+"Z175TicketResponsableFechaResuelve_"+sGXsfl_242_idx, context.localUtil.DToC( Z175TicketResponsableFechaResuelve, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z176TicketResponsableHoraResuelve_"+sGXsfl_242_idx, context.localUtil.TToC( Z176TicketResponsableHoraResuelve, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z177TicketResponsableRamTxt_"+sGXsfl_242_idx, Z177TicketResponsableRamTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z178TicketResponsableDiscoDuroTxt_"+sGXsfl_242_idx, Z178TicketResponsableDiscoDuroTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z179TicketResponsableProcesadorTxt_"+sGXsfl_242_idx, Z179TicketResponsableProcesadorTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z180TicketResponsableMaletinTxt_"+sGXsfl_242_idx, Z180TicketResponsableMaletinTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z181TicketResponsableTonerCintaTxt_"+sGXsfl_242_idx, Z181TicketResponsableTonerCintaTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z182TicketResponsableTarjetaVideoExtraTxt_"+sGXsfl_242_idx, Z182TicketResponsableTarjetaVideoExtraTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z183TicketResponsableCargadorLaptopTxt_"+sGXsfl_242_idx, Z183TicketResponsableCargadorLaptopTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z184TicketResponsableCDsDVDsTxt_"+sGXsfl_242_idx, Z184TicketResponsableCDsDVDsTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z185TicketResponsableCableEspecialTxt_"+sGXsfl_242_idx, Z185TicketResponsableCableEspecialTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z186TicketResponsableOtrosTallerTxt_"+sGXsfl_242_idx, Z186TicketResponsableOtrosTallerTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z287TicketResponsableFechaHoraAsigna_"+sGXsfl_242_idx, context.localUtil.TToC( Z287TicketResponsableFechaHoraAsigna, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z288TicketResponsableFechaHoraResuelve_"+sGXsfl_242_idx, context.localUtil.TToC( Z288TicketResponsableFechaHoraResuelve, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z290EtapaDesarrolloId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290EtapaDesarrolloId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z17EstadoTicketTecnicoId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EstadoTicketTecnicoId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z198TicketTecnicoResponsableId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z198TicketTecnicoResponsableId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdDeleted_8_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_8_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_8_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ",", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketResponsableId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O54TicketLastId = s54TicketLastId;
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
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
         new k2bisauthorizedactivityname(context ).execute(  "Ticket",  "Ticket",  AV17StandardActivityType,  AV18UserActivityType,  AV30Pgmname, out  AV19IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV19IsAuthorized", AV19IsAuthorized);
         if ( ! AV19IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("Ticket")),UrlEncode(StringUtil.RTrim("Ticket")),UrlEncode(StringUtil.RTrim(AV17StandardActivityType)),UrlEncode(StringUtil.RTrim(AV18UserActivityType)),UrlEncode(StringUtil.RTrim(AV30Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
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
         new k2bgettrncontextbyname(context ).execute(  "Ticket", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Ticket", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Ticket", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Ticket", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV31GXV1 = 1;
            AssignAttri(sPrefix, false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            while ( AV31GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV31GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "UsuarioId") == 0 )
               {
                  AV12Insert_UsuarioId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV12Insert_UsuarioId", StringUtil.LTrimStr( (decimal)(AV12Insert_UsuarioId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "EstadoTicketTicketId") == 0 )
               {
                  AV26Insert_EstadoTicketTicketId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV26Insert_EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(AV26Insert_EstadoTicketTicketId), 4, 0));
               }
               AV31GXV1 = (int)(AV31GXV1+1);
               AssignAttri(sPrefix, false, "AV31GXV1", StringUtil.LTrimStr( (decimal)(AV31GXV1), 8, 0));
            }
         }
         divK2btoolstable_attributecontainerestadoticketticketid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainerestadoticketticketid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainerestadoticketticketid_Visible), 5, 0), true);
         divK2btoolstable_attributecontainerticketlastid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainerticketlastid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainerticketlastid_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25HttpRequest.Method, "GET") == 0 )
         {
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               edtTicketFecha_Class = "Attribute_TrnDate"+" "+"Attribute_RequiredReadOnly";
               AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Class", edtTicketFecha_Class, true);
            }
            else
            {
               edtTicketFecha_Class = "Attribute_TrnDate"+" "+"Attribute_Required";
               AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Class", edtTicketFecha_Class, true);
            }
         }
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV21AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV22AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV22AttributeValueItem.gxTpr_Attributename = "TicketId";
            AV22AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A14TicketId), 10, 0);
            AV21AttributeValue.Add(AV22AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "Ticket",  AV21AttributeValue) ;
         }
         AV23Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La ticket %1 fue creada", context.localUtil.DToC( A46TicketFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La ticket %1 fue actualizada", context.localUtil.DToC( A46TicketFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23Message.gxTpr_Description = StringUtil.Format( "La ticket %1 fue eliminada", context.localUtil.DToC( A46TicketFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV23Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"Ticket",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV21AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "Ticket") ;
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
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A14TicketId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A14TicketId = (long)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A14TicketId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A14TicketId = (long)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A14TicketId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A14TicketId = (long)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(long)A14TicketId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A14TicketId = (long)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV20encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(long)A14TicketId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A14TicketId = (long)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(long)A14TicketId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A14TicketId = (long)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A14TicketId,10,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E13072( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "Ticket") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"Ticket"}, true);
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

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z46TicketFecha = T00078_A46TicketFecha[0];
               Z48TicketHora = T00078_A48TicketHora[0];
               Z54TicketLastId = T00078_A54TicketLastId[0];
               Z285TicketHoraCaracter = T00078_A285TicketHoraCaracter[0];
               Z53TicketLaptop = T00078_A53TicketLaptop[0];
               Z42TicketDesktop = T00078_A42TicketDesktop[0];
               Z55TicketMonitor = T00078_A55TicketMonitor[0];
               Z50TicketImpresora = T00078_A50TicketImpresora[0];
               Z45TicketEscaner = T00078_A45TicketEscaner[0];
               Z59TicketRouter = T00078_A59TicketRouter[0];
               Z60TicketSistemaOperativo = T00078_A60TicketSistemaOperativo[0];
               Z56TicketOffice = T00078_A56TicketOffice[0];
               Z39TicketAntivirus = T00078_A39TicketAntivirus[0];
               Z40TicketAplicacion = T00078_A40TicketAplicacion[0];
               Z44TicketDisenio = T00078_A44TicketDisenio[0];
               Z51TicketIngenieria = T00078_A51TicketIngenieria[0];
               Z43TicketDiscoDuroExterno = T00078_A43TicketDiscoDuroExterno[0];
               Z58TicketPerifericos = T00078_A58TicketPerifericos[0];
               Z87TicketUps = T00078_A87TicketUps[0];
               Z41TicketApoyoUsuario = T00078_A41TicketApoyoUsuario[0];
               Z52TicketInstalarDataShow = T00078_A52TicketInstalarDataShow[0];
               Z57TicketOtros = T00078_A57TicketOtros[0];
               Z278TicketUsuarioAsigno = T00078_A278TicketUsuarioAsigno[0];
               Z289TicketFechaHora = T00078_A289TicketFechaHora[0];
               Z15UsuarioId = T00078_A15UsuarioId[0];
               Z187EstadoTicketTicketId = T00078_A187EstadoTicketTicketId[0];
            }
            else
            {
               Z46TicketFecha = A46TicketFecha;
               Z48TicketHora = A48TicketHora;
               Z54TicketLastId = A54TicketLastId;
               Z285TicketHoraCaracter = A285TicketHoraCaracter;
               Z53TicketLaptop = A53TicketLaptop;
               Z42TicketDesktop = A42TicketDesktop;
               Z55TicketMonitor = A55TicketMonitor;
               Z50TicketImpresora = A50TicketImpresora;
               Z45TicketEscaner = A45TicketEscaner;
               Z59TicketRouter = A59TicketRouter;
               Z60TicketSistemaOperativo = A60TicketSistemaOperativo;
               Z56TicketOffice = A56TicketOffice;
               Z39TicketAntivirus = A39TicketAntivirus;
               Z40TicketAplicacion = A40TicketAplicacion;
               Z44TicketDisenio = A44TicketDisenio;
               Z51TicketIngenieria = A51TicketIngenieria;
               Z43TicketDiscoDuroExterno = A43TicketDiscoDuroExterno;
               Z58TicketPerifericos = A58TicketPerifericos;
               Z87TicketUps = A87TicketUps;
               Z41TicketApoyoUsuario = A41TicketApoyoUsuario;
               Z52TicketInstalarDataShow = A52TicketInstalarDataShow;
               Z57TicketOtros = A57TicketOtros;
               Z278TicketUsuarioAsigno = A278TicketUsuarioAsigno;
               Z289TicketFechaHora = A289TicketFechaHora;
               Z15UsuarioId = A15UsuarioId;
               Z187EstadoTicketTicketId = A187EstadoTicketTicketId;
            }
         }
         if ( GX_JID == -31 )
         {
            Z14TicketId = A14TicketId;
            Z46TicketFecha = A46TicketFecha;
            Z48TicketHora = A48TicketHora;
            Z54TicketLastId = A54TicketLastId;
            Z285TicketHoraCaracter = A285TicketHoraCaracter;
            Z53TicketLaptop = A53TicketLaptop;
            Z42TicketDesktop = A42TicketDesktop;
            Z55TicketMonitor = A55TicketMonitor;
            Z50TicketImpresora = A50TicketImpresora;
            Z45TicketEscaner = A45TicketEscaner;
            Z59TicketRouter = A59TicketRouter;
            Z60TicketSistemaOperativo = A60TicketSistemaOperativo;
            Z56TicketOffice = A56TicketOffice;
            Z39TicketAntivirus = A39TicketAntivirus;
            Z40TicketAplicacion = A40TicketAplicacion;
            Z44TicketDisenio = A44TicketDisenio;
            Z51TicketIngenieria = A51TicketIngenieria;
            Z43TicketDiscoDuroExterno = A43TicketDiscoDuroExterno;
            Z58TicketPerifericos = A58TicketPerifericos;
            Z87TicketUps = A87TicketUps;
            Z41TicketApoyoUsuario = A41TicketApoyoUsuario;
            Z52TicketInstalarDataShow = A52TicketInstalarDataShow;
            Z57TicketOtros = A57TicketOtros;
            Z278TicketUsuarioAsigno = A278TicketUsuarioAsigno;
            Z289TicketFechaHora = A289TicketFechaHora;
            Z15UsuarioId = A15UsuarioId;
            Z187EstadoTicketTicketId = A187EstadoTicketTicketId;
            Z93UsuarioNombre = A93UsuarioNombre;
            Z94UsuarioRequerimiento = A94UsuarioRequerimiento;
            Z91UsuarioGerencia = A91UsuarioGerencia;
            Z88UsuarioDepartamento = A88UsuarioDepartamento;
            Z188EstadoTicketTicketNombre = A188EstadoTicketTicketNombre;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTicketId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            subGridresponsable_Rows = 1;
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
            {
               subGridresponsable_Rows = 0;
            }
         }
         edtTicketLastId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Enabled), 5, 0), true);
         edtTicketFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Enabled), 5, 0), true);
         edtTicketHora_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHora_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_15_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptusuario.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"USUARIOID"+"'), id:'"+sPrefix+"USUARIOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_187_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadoticket.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"ESTADOTICKETTICKETID"+"'), id:'"+sPrefix+"ESTADOTICKETTICKETID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtTicketId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         edtTicketLastId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Enabled), 5, 0), true);
         edtTicketFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Enabled), 5, 0), true);
         edtTicketHora_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHora_Enabled), 5, 0), true);
         if ( ! (0==AV7TicketId) )
         {
            A14TicketId = AV7TicketId;
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_UsuarioId) )
         {
            edtUsuarioId_Enabled = 0;
            AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         }
         else
         {
            edtUsuarioId_Enabled = 1;
            AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_EstadoTicketTicketId) )
         {
            edtEstadoTicketTicketId_Enabled = 0;
            AssignProp(sPrefix, false, edtEstadoTicketTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketId_Enabled), 5, 0), true);
         }
         else
         {
            edtEstadoTicketTicketId_Enabled = 1;
            AssignProp(sPrefix, false, edtEstadoTicketTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_UsuarioId) )
         {
            A15UsuarioId = AV12Insert_UsuarioId;
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV26Insert_EstadoTicketTicketId) )
         {
            A187EstadoTicketTicketId = AV26Insert_EstadoTicketTicketId;
            AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
         }
         else
         {
            if ( IsIns( )  && (0==A187EstadoTicketTicketId) && ( Gx_BScreen == 0 ) )
            {
               A187EstadoTicketTicketId = 3;
               AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
            }
         }
         if ( IsIns( )  && (DateTime.MinValue==A46TicketFecha) && ( Gx_BScreen == 0 ) )
         {
            A46TicketFecha = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A48TicketHora) && ( Gx_BScreen == 0 ) )
         {
            A48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A278TicketUsuarioAsigno)) && ( Gx_BScreen == 0 ) )
         {
            A278TicketUsuarioAsigno = AV28WebSession.Get("UsuarioConectado");
            AssignAttri(sPrefix, false, "A278TicketUsuarioAsigno", A278TicketUsuarioAsigno);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV30Pgmname = "Ticket";
            AssignAttri(sPrefix, false, "AV30Pgmname", AV30Pgmname);
            /* Using cursor T00079 */
            pr_default.execute(7, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T00079_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T00079_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A91UsuarioGerencia = T00079_A91UsuarioGerencia[0];
            A88UsuarioDepartamento = T00079_A88UsuarioDepartamento[0];
            pr_default.close(7);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
            }
            /* Using cursor T000710 */
            pr_default.execute(8, new Object[] {A187EstadoTicketTicketId});
            A188EstadoTicketTicketNombre = T000710_A188EstadoTicketTicketNombre[0];
            AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
            pr_default.close(8);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoTicket",  "EstadoTicket",  "Display",  "",  "EntityManagerEstadoTicket", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
               AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Link", edtEstadoTicketTicketNombre_Link, true);
            }
         }
      }

      protected void Load077( )
      {
         /* Using cursor T000711 */
         pr_default.execute(9, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
            A46TicketFecha = T000711_A46TicketFecha[0];
            AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
            A48TicketHora = T000711_A48TicketHora[0];
            AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
            A93UsuarioNombre = T000711_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T000711_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A91UsuarioGerencia = T000711_A91UsuarioGerencia[0];
            A88UsuarioDepartamento = T000711_A88UsuarioDepartamento[0];
            A188EstadoTicketTicketNombre = T000711_A188EstadoTicketTicketNombre[0];
            AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
            A54TicketLastId = T000711_A54TicketLastId[0];
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            A285TicketHoraCaracter = T000711_A285TicketHoraCaracter[0];
            A53TicketLaptop = T000711_A53TicketLaptop[0];
            AssignAttri(sPrefix, false, "A53TicketLaptop", A53TicketLaptop);
            A42TicketDesktop = T000711_A42TicketDesktop[0];
            AssignAttri(sPrefix, false, "A42TicketDesktop", A42TicketDesktop);
            A55TicketMonitor = T000711_A55TicketMonitor[0];
            AssignAttri(sPrefix, false, "A55TicketMonitor", A55TicketMonitor);
            A50TicketImpresora = T000711_A50TicketImpresora[0];
            AssignAttri(sPrefix, false, "A50TicketImpresora", A50TicketImpresora);
            A45TicketEscaner = T000711_A45TicketEscaner[0];
            AssignAttri(sPrefix, false, "A45TicketEscaner", A45TicketEscaner);
            A59TicketRouter = T000711_A59TicketRouter[0];
            AssignAttri(sPrefix, false, "A59TicketRouter", A59TicketRouter);
            A60TicketSistemaOperativo = T000711_A60TicketSistemaOperativo[0];
            AssignAttri(sPrefix, false, "A60TicketSistemaOperativo", A60TicketSistemaOperativo);
            A56TicketOffice = T000711_A56TicketOffice[0];
            AssignAttri(sPrefix, false, "A56TicketOffice", A56TicketOffice);
            A39TicketAntivirus = T000711_A39TicketAntivirus[0];
            AssignAttri(sPrefix, false, "A39TicketAntivirus", A39TicketAntivirus);
            A40TicketAplicacion = T000711_A40TicketAplicacion[0];
            AssignAttri(sPrefix, false, "A40TicketAplicacion", A40TicketAplicacion);
            A44TicketDisenio = T000711_A44TicketDisenio[0];
            AssignAttri(sPrefix, false, "A44TicketDisenio", A44TicketDisenio);
            A51TicketIngenieria = T000711_A51TicketIngenieria[0];
            AssignAttri(sPrefix, false, "A51TicketIngenieria", A51TicketIngenieria);
            A43TicketDiscoDuroExterno = T000711_A43TicketDiscoDuroExterno[0];
            AssignAttri(sPrefix, false, "A43TicketDiscoDuroExterno", A43TicketDiscoDuroExterno);
            A58TicketPerifericos = T000711_A58TicketPerifericos[0];
            AssignAttri(sPrefix, false, "A58TicketPerifericos", A58TicketPerifericos);
            A87TicketUps = T000711_A87TicketUps[0];
            AssignAttri(sPrefix, false, "A87TicketUps", A87TicketUps);
            A41TicketApoyoUsuario = T000711_A41TicketApoyoUsuario[0];
            AssignAttri(sPrefix, false, "A41TicketApoyoUsuario", A41TicketApoyoUsuario);
            A52TicketInstalarDataShow = T000711_A52TicketInstalarDataShow[0];
            AssignAttri(sPrefix, false, "A52TicketInstalarDataShow", A52TicketInstalarDataShow);
            A57TicketOtros = T000711_A57TicketOtros[0];
            AssignAttri(sPrefix, false, "A57TicketOtros", A57TicketOtros);
            A278TicketUsuarioAsigno = T000711_A278TicketUsuarioAsigno[0];
            A289TicketFechaHora = T000711_A289TicketFechaHora[0];
            n289TicketFechaHora = T000711_n289TicketFechaHora[0];
            A15UsuarioId = T000711_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            A187EstadoTicketTicketId = T000711_A187EstadoTicketTicketId[0];
            AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
            ZM077( -31) ;
         }
         pr_default.close(9);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
         AV30Pgmname = "Ticket";
         AssignAttri(sPrefix, false, "AV30Pgmname", AV30Pgmname);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode7, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTicket",  "EstadoTicket",  "Display",  "",  "EntityManagerEstadoTicket", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode7, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
            AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Link", edtEstadoTicketTicketNombre_Link, true);
         }
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV30Pgmname = "Ticket";
         AssignAttri(sPrefix, false, "AV30Pgmname", AV30Pgmname);
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A93UsuarioNombre = T00079_A93UsuarioNombre[0];
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = T00079_A94UsuarioRequerimiento[0];
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A91UsuarioGerencia = T00079_A91UsuarioGerencia[0];
         A88UsuarioDepartamento = T00079_A88UsuarioDepartamento[0];
         pr_default.close(7);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         }
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A187EstadoTicketTicketId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Ticket Ticket'.", "ForeignKeyNotFound", 1, "ESTADOTICKETTICKETID");
            AnyError = 1;
            GX_FocusControl = edtEstadoTicketTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A188EstadoTicketTicketNombre = T000710_A188EstadoTicketTicketNombre[0];
         AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
         pr_default.close(8);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTicket",  "EstadoTicket",  "Display",  "",  "EntityManagerEstadoTicket", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
            AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Link", edtEstadoTicketTicketNombre_Link, true);
         }
         if ( (DateTime.MinValue==A46TicketFecha) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es obligatorio", "Fecha:", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors077( )
      {
         pr_default.close(7);
         pr_default.close(8);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_32( short A15UsuarioId )
      {
         /* Using cursor T000712 */
         pr_default.execute(10, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A93UsuarioNombre = T000712_A93UsuarioNombre[0];
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = T000712_A94UsuarioRequerimiento[0];
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A91UsuarioGerencia = T000712_A91UsuarioGerencia[0];
         A88UsuarioDepartamento = T000712_A88UsuarioDepartamento[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A93UsuarioNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A94UsuarioRequerimiento)+"\""+","+"\""+GXUtil.EncodeJSConstant( A91UsuarioGerencia)+"\""+","+"\""+GXUtil.EncodeJSConstant( A88UsuarioDepartamento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_33( short A187EstadoTicketTicketId )
      {
         /* Using cursor T000713 */
         pr_default.execute(11, new Object[] {A187EstadoTicketTicketId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Ticket Ticket'.", "ForeignKeyNotFound", 1, "ESTADOTICKETTICKETID");
            AnyError = 1;
            GX_FocusControl = edtEstadoTicketTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A188EstadoTicketTicketNombre = T000713_A188EstadoTicketTicketNombre[0];
         AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A188EstadoTicketTicketNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey077( )
      {
         /* Using cursor T000714 */
         pr_default.execute(12, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            ZM077( 31) ;
            RcdFound7 = 1;
            A14TicketId = T00078_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            A46TicketFecha = T00078_A46TicketFecha[0];
            AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
            A48TicketHora = T00078_A48TicketHora[0];
            AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
            A54TicketLastId = T00078_A54TicketLastId[0];
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            A285TicketHoraCaracter = T00078_A285TicketHoraCaracter[0];
            A53TicketLaptop = T00078_A53TicketLaptop[0];
            AssignAttri(sPrefix, false, "A53TicketLaptop", A53TicketLaptop);
            A42TicketDesktop = T00078_A42TicketDesktop[0];
            AssignAttri(sPrefix, false, "A42TicketDesktop", A42TicketDesktop);
            A55TicketMonitor = T00078_A55TicketMonitor[0];
            AssignAttri(sPrefix, false, "A55TicketMonitor", A55TicketMonitor);
            A50TicketImpresora = T00078_A50TicketImpresora[0];
            AssignAttri(sPrefix, false, "A50TicketImpresora", A50TicketImpresora);
            A45TicketEscaner = T00078_A45TicketEscaner[0];
            AssignAttri(sPrefix, false, "A45TicketEscaner", A45TicketEscaner);
            A59TicketRouter = T00078_A59TicketRouter[0];
            AssignAttri(sPrefix, false, "A59TicketRouter", A59TicketRouter);
            A60TicketSistemaOperativo = T00078_A60TicketSistemaOperativo[0];
            AssignAttri(sPrefix, false, "A60TicketSistemaOperativo", A60TicketSistemaOperativo);
            A56TicketOffice = T00078_A56TicketOffice[0];
            AssignAttri(sPrefix, false, "A56TicketOffice", A56TicketOffice);
            A39TicketAntivirus = T00078_A39TicketAntivirus[0];
            AssignAttri(sPrefix, false, "A39TicketAntivirus", A39TicketAntivirus);
            A40TicketAplicacion = T00078_A40TicketAplicacion[0];
            AssignAttri(sPrefix, false, "A40TicketAplicacion", A40TicketAplicacion);
            A44TicketDisenio = T00078_A44TicketDisenio[0];
            AssignAttri(sPrefix, false, "A44TicketDisenio", A44TicketDisenio);
            A51TicketIngenieria = T00078_A51TicketIngenieria[0];
            AssignAttri(sPrefix, false, "A51TicketIngenieria", A51TicketIngenieria);
            A43TicketDiscoDuroExterno = T00078_A43TicketDiscoDuroExterno[0];
            AssignAttri(sPrefix, false, "A43TicketDiscoDuroExterno", A43TicketDiscoDuroExterno);
            A58TicketPerifericos = T00078_A58TicketPerifericos[0];
            AssignAttri(sPrefix, false, "A58TicketPerifericos", A58TicketPerifericos);
            A87TicketUps = T00078_A87TicketUps[0];
            AssignAttri(sPrefix, false, "A87TicketUps", A87TicketUps);
            A41TicketApoyoUsuario = T00078_A41TicketApoyoUsuario[0];
            AssignAttri(sPrefix, false, "A41TicketApoyoUsuario", A41TicketApoyoUsuario);
            A52TicketInstalarDataShow = T00078_A52TicketInstalarDataShow[0];
            AssignAttri(sPrefix, false, "A52TicketInstalarDataShow", A52TicketInstalarDataShow);
            A57TicketOtros = T00078_A57TicketOtros[0];
            AssignAttri(sPrefix, false, "A57TicketOtros", A57TicketOtros);
            A278TicketUsuarioAsigno = T00078_A278TicketUsuarioAsigno[0];
            A289TicketFechaHora = T00078_A289TicketFechaHora[0];
            n289TicketFechaHora = T00078_n289TicketFechaHora[0];
            A15UsuarioId = T00078_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
            A187EstadoTicketTicketId = T00078_A187EstadoTicketTicketId[0];
            AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
            O54TicketLastId = A54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            Z14TicketId = A14TicketId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(6);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T000715 */
         pr_default.execute(13, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000715_A14TicketId[0] < A14TicketId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000715_A14TicketId[0] > A14TicketId ) ) )
            {
               A14TicketId = T000715_A14TicketId[0];
               AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000716 */
         pr_default.execute(14, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000716_A14TicketId[0] > A14TicketId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000716_A14TicketId[0] < A14TicketId ) ) )
            {
               A14TicketId = T000716_A14TicketId[0];
               AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A54TicketLastId = O54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A14TicketId != Z14TicketId )
               {
                  A14TicketId = Z14TicketId;
                  AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TICKETID");
                  AnyError = 1;
                  GX_FocusControl = edtTicketId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A54TicketLastId = O54TicketLastId;
                  AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A54TicketLastId = O54TicketLastId;
                  AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                  Update077( ) ;
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A14TicketId != Z14TicketId )
               {
                  /* Insert record */
                  A54TicketLastId = O54TicketLastId;
                  AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                  GX_FocusControl = edtUsuarioId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TICKETID");
                     AnyError = 1;
                     GX_FocusControl = edtTicketId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A54TicketLastId = O54TicketLastId;
                     AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                     GX_FocusControl = edtUsuarioId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( A14TicketId != Z14TicketId )
         {
            A14TicketId = Z14TicketId;
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A54TicketLastId = O54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuarioId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00077 */
            pr_default.execute(5, new Object[] {A14TicketId});
            if ( (pr_default.getStatus(5) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ticket"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(5) == 101) || ( Z46TicketFecha != T00077_A46TicketFecha[0] ) || ( Z48TicketHora != T00077_A48TicketHora[0] ) || ( Z54TicketLastId != T00077_A54TicketLastId[0] ) || ( StringUtil.StrCmp(Z285TicketHoraCaracter, T00077_A285TicketHoraCaracter[0]) != 0 ) || ( Z53TicketLaptop != T00077_A53TicketLaptop[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z42TicketDesktop != T00077_A42TicketDesktop[0] ) || ( Z55TicketMonitor != T00077_A55TicketMonitor[0] ) || ( Z50TicketImpresora != T00077_A50TicketImpresora[0] ) || ( Z45TicketEscaner != T00077_A45TicketEscaner[0] ) || ( Z59TicketRouter != T00077_A59TicketRouter[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z60TicketSistemaOperativo != T00077_A60TicketSistemaOperativo[0] ) || ( Z56TicketOffice != T00077_A56TicketOffice[0] ) || ( Z39TicketAntivirus != T00077_A39TicketAntivirus[0] ) || ( Z40TicketAplicacion != T00077_A40TicketAplicacion[0] ) || ( Z44TicketDisenio != T00077_A44TicketDisenio[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z51TicketIngenieria != T00077_A51TicketIngenieria[0] ) || ( Z43TicketDiscoDuroExterno != T00077_A43TicketDiscoDuroExterno[0] ) || ( Z58TicketPerifericos != T00077_A58TicketPerifericos[0] ) || ( Z87TicketUps != T00077_A87TicketUps[0] ) || ( Z41TicketApoyoUsuario != T00077_A41TicketApoyoUsuario[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z52TicketInstalarDataShow != T00077_A52TicketInstalarDataShow[0] ) || ( Z57TicketOtros != T00077_A57TicketOtros[0] ) || ( StringUtil.StrCmp(Z278TicketUsuarioAsigno, T00077_A278TicketUsuarioAsigno[0]) != 0 ) || ( Z289TicketFechaHora != T00077_A289TicketFechaHora[0] ) || ( Z15UsuarioId != T00077_A15UsuarioId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z187EstadoTicketTicketId != T00077_A187EstadoTicketTicketId[0] ) )
            {
               if ( Z46TicketFecha != T00077_A46TicketFecha[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketFecha");
                  GXUtil.WriteLogRaw("Old: ",Z46TicketFecha);
                  GXUtil.WriteLogRaw("Current: ",T00077_A46TicketFecha[0]);
               }
               if ( Z48TicketHora != T00077_A48TicketHora[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketHora");
                  GXUtil.WriteLogRaw("Old: ",Z48TicketHora);
                  GXUtil.WriteLogRaw("Current: ",T00077_A48TicketHora[0]);
               }
               if ( Z54TicketLastId != T00077_A54TicketLastId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketLastId");
                  GXUtil.WriteLogRaw("Old: ",Z54TicketLastId);
                  GXUtil.WriteLogRaw("Current: ",T00077_A54TicketLastId[0]);
               }
               if ( StringUtil.StrCmp(Z285TicketHoraCaracter, T00077_A285TicketHoraCaracter[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketHoraCaracter");
                  GXUtil.WriteLogRaw("Old: ",Z285TicketHoraCaracter);
                  GXUtil.WriteLogRaw("Current: ",T00077_A285TicketHoraCaracter[0]);
               }
               if ( Z53TicketLaptop != T00077_A53TicketLaptop[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketLaptop");
                  GXUtil.WriteLogRaw("Old: ",Z53TicketLaptop);
                  GXUtil.WriteLogRaw("Current: ",T00077_A53TicketLaptop[0]);
               }
               if ( Z42TicketDesktop != T00077_A42TicketDesktop[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketDesktop");
                  GXUtil.WriteLogRaw("Old: ",Z42TicketDesktop);
                  GXUtil.WriteLogRaw("Current: ",T00077_A42TicketDesktop[0]);
               }
               if ( Z55TicketMonitor != T00077_A55TicketMonitor[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketMonitor");
                  GXUtil.WriteLogRaw("Old: ",Z55TicketMonitor);
                  GXUtil.WriteLogRaw("Current: ",T00077_A55TicketMonitor[0]);
               }
               if ( Z50TicketImpresora != T00077_A50TicketImpresora[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketImpresora");
                  GXUtil.WriteLogRaw("Old: ",Z50TicketImpresora);
                  GXUtil.WriteLogRaw("Current: ",T00077_A50TicketImpresora[0]);
               }
               if ( Z45TicketEscaner != T00077_A45TicketEscaner[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketEscaner");
                  GXUtil.WriteLogRaw("Old: ",Z45TicketEscaner);
                  GXUtil.WriteLogRaw("Current: ",T00077_A45TicketEscaner[0]);
               }
               if ( Z59TicketRouter != T00077_A59TicketRouter[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketRouter");
                  GXUtil.WriteLogRaw("Old: ",Z59TicketRouter);
                  GXUtil.WriteLogRaw("Current: ",T00077_A59TicketRouter[0]);
               }
               if ( Z60TicketSistemaOperativo != T00077_A60TicketSistemaOperativo[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketSistemaOperativo");
                  GXUtil.WriteLogRaw("Old: ",Z60TicketSistemaOperativo);
                  GXUtil.WriteLogRaw("Current: ",T00077_A60TicketSistemaOperativo[0]);
               }
               if ( Z56TicketOffice != T00077_A56TicketOffice[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketOffice");
                  GXUtil.WriteLogRaw("Old: ",Z56TicketOffice);
                  GXUtil.WriteLogRaw("Current: ",T00077_A56TicketOffice[0]);
               }
               if ( Z39TicketAntivirus != T00077_A39TicketAntivirus[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketAntivirus");
                  GXUtil.WriteLogRaw("Old: ",Z39TicketAntivirus);
                  GXUtil.WriteLogRaw("Current: ",T00077_A39TicketAntivirus[0]);
               }
               if ( Z40TicketAplicacion != T00077_A40TicketAplicacion[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketAplicacion");
                  GXUtil.WriteLogRaw("Old: ",Z40TicketAplicacion);
                  GXUtil.WriteLogRaw("Current: ",T00077_A40TicketAplicacion[0]);
               }
               if ( Z44TicketDisenio != T00077_A44TicketDisenio[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketDisenio");
                  GXUtil.WriteLogRaw("Old: ",Z44TicketDisenio);
                  GXUtil.WriteLogRaw("Current: ",T00077_A44TicketDisenio[0]);
               }
               if ( Z51TicketIngenieria != T00077_A51TicketIngenieria[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketIngenieria");
                  GXUtil.WriteLogRaw("Old: ",Z51TicketIngenieria);
                  GXUtil.WriteLogRaw("Current: ",T00077_A51TicketIngenieria[0]);
               }
               if ( Z43TicketDiscoDuroExterno != T00077_A43TicketDiscoDuroExterno[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketDiscoDuroExterno");
                  GXUtil.WriteLogRaw("Old: ",Z43TicketDiscoDuroExterno);
                  GXUtil.WriteLogRaw("Current: ",T00077_A43TicketDiscoDuroExterno[0]);
               }
               if ( Z58TicketPerifericos != T00077_A58TicketPerifericos[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketPerifericos");
                  GXUtil.WriteLogRaw("Old: ",Z58TicketPerifericos);
                  GXUtil.WriteLogRaw("Current: ",T00077_A58TicketPerifericos[0]);
               }
               if ( Z87TicketUps != T00077_A87TicketUps[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketUps");
                  GXUtil.WriteLogRaw("Old: ",Z87TicketUps);
                  GXUtil.WriteLogRaw("Current: ",T00077_A87TicketUps[0]);
               }
               if ( Z41TicketApoyoUsuario != T00077_A41TicketApoyoUsuario[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketApoyoUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z41TicketApoyoUsuario);
                  GXUtil.WriteLogRaw("Current: ",T00077_A41TicketApoyoUsuario[0]);
               }
               if ( Z52TicketInstalarDataShow != T00077_A52TicketInstalarDataShow[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketInstalarDataShow");
                  GXUtil.WriteLogRaw("Old: ",Z52TicketInstalarDataShow);
                  GXUtil.WriteLogRaw("Current: ",T00077_A52TicketInstalarDataShow[0]);
               }
               if ( Z57TicketOtros != T00077_A57TicketOtros[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketOtros");
                  GXUtil.WriteLogRaw("Old: ",Z57TicketOtros);
                  GXUtil.WriteLogRaw("Current: ",T00077_A57TicketOtros[0]);
               }
               if ( StringUtil.StrCmp(Z278TicketUsuarioAsigno, T00077_A278TicketUsuarioAsigno[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketUsuarioAsigno");
                  GXUtil.WriteLogRaw("Old: ",Z278TicketUsuarioAsigno);
                  GXUtil.WriteLogRaw("Current: ",T00077_A278TicketUsuarioAsigno[0]);
               }
               if ( Z289TicketFechaHora != T00077_A289TicketFechaHora[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketFechaHora");
                  GXUtil.WriteLogRaw("Old: ",Z289TicketFechaHora);
                  GXUtil.WriteLogRaw("Current: ",T00077_A289TicketFechaHora[0]);
               }
               if ( Z15UsuarioId != T00077_A15UsuarioId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"UsuarioId");
                  GXUtil.WriteLogRaw("Old: ",Z15UsuarioId);
                  GXUtil.WriteLogRaw("Current: ",T00077_A15UsuarioId[0]);
               }
               if ( Z187EstadoTicketTicketId != T00077_A187EstadoTicketTicketId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"EstadoTicketTicketId");
                  GXUtil.WriteLogRaw("Old: ",Z187EstadoTicketTicketId);
                  GXUtil.WriteLogRaw("Current: ",T00077_A187EstadoTicketTicketId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Ticket"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         if ( ! IsAuthorized("ticket_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000717 */
                     pr_default.execute(15, new Object[] {A46TicketFecha, A48TicketHora, A54TicketLastId, A285TicketHoraCaracter, A53TicketLaptop, A42TicketDesktop, A55TicketMonitor, A50TicketImpresora, A45TicketEscaner, A59TicketRouter, A60TicketSistemaOperativo, A56TicketOffice, A39TicketAntivirus, A40TicketAplicacion, A44TicketDisenio, A51TicketIngenieria, A43TicketDiscoDuroExterno, A58TicketPerifericos, A87TicketUps, A41TicketApoyoUsuario, A52TicketInstalarDataShow, A57TicketOtros, A278TicketUsuarioAsigno, n289TicketFechaHora, A289TicketFechaHora, A15UsuarioId, A187EstadoTicketTicketId});
                     A14TicketId = T000717_A14TicketId[0];
                     AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("Ticket");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel077( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption070( ) ;
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
            else
            {
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         if ( ! IsAuthorized("ticket_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000718 */
                     pr_default.execute(16, new Object[] {A46TicketFecha, A48TicketHora, A54TicketLastId, A285TicketHoraCaracter, A53TicketLaptop, A42TicketDesktop, A55TicketMonitor, A50TicketImpresora, A45TicketEscaner, A59TicketRouter, A60TicketSistemaOperativo, A56TicketOffice, A39TicketAntivirus, A40TicketAplicacion, A44TicketDisenio, A51TicketIngenieria, A43TicketDiscoDuroExterno, A58TicketPerifericos, A87TicketUps, A41TicketApoyoUsuario, A52TicketInstalarDataShow, A57TicketOtros, A278TicketUsuarioAsigno, n289TicketFechaHora, A289TicketFechaHora, A15UsuarioId, A187EstadoTicketTicketId, A14TicketId});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("Ticket");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Ticket"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel077( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("ticket_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  A54TicketLastId = O54TicketLastId;
                  AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                  ScanStart078( ) ;
                  while ( RcdFound8 != 0 )
                  {
                     getByPrimaryKey078( ) ;
                     Delete078( ) ;
                     ScanNext078( ) ;
                     O54TicketLastId = A54TicketLastId;
                     AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
                  }
                  ScanEnd078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000719 */
                     pr_default.execute(17, new Object[] {A14TicketId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Ticket");
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
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV30Pgmname = "Ticket";
            AssignAttri(sPrefix, false, "AV30Pgmname", AV30Pgmname);
            /* Using cursor T000720 */
            pr_default.execute(18, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T000720_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A94UsuarioRequerimiento = T000720_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A91UsuarioGerencia = T000720_A91UsuarioGerencia[0];
            A88UsuarioDepartamento = T000720_A88UsuarioDepartamento[0];
            pr_default.close(18);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
            }
            /* Using cursor T000721 */
            pr_default.execute(19, new Object[] {A187EstadoTicketTicketId});
            A188EstadoTicketTicketNombre = T000721_A188EstadoTicketTicketNombre[0];
            AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
            pr_default.close(19);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoTicket",  "EstadoTicket",  "Display",  "",  "EntityManagerEstadoTicket", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
               AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Link", edtEstadoTicketTicketNombre_Link, true);
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000722 */
            pr_default.execute(20, new Object[] {A14TicketId});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Soporte Tecnico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000723 */
            pr_default.execute(21, new Object[] {A14TicketId});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void ProcessNestedLevel078( )
      {
         s54TicketLastId = O54TicketLastId;
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         nGXsfl_242_idx = 0;
         while ( nGXsfl_242_idx < nRC_GXsfl_242 )
         {
            ReadRow078( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               standaloneNotModal078( ) ;
               GetKey078( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  Insert078( ) ;
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( ( nRcdDeleted_8 != 0 ) && ( nRcdExists_8 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                        Delete078( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                           Update078( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "TICKETRESPONSABLEID_" + sGXsfl_242_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTicketResponsableId_Internalname;
                        AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O54TicketLastId = A54TicketLastId;
               AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
            }
            ChangePostValue( sPrefix+edtTicketResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtTicketTecnicoResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtTicketTecnicoResponsableNombre_Internalname, A199TicketTecnicoResponsableNombre) ;
            ChangePostValue( sPrefix+edtTicketFechaResponsable_Internalname, context.localUtil.Format(A47TicketFechaResponsable, "99/99/9999")) ;
            ChangePostValue( sPrefix+edtTicketHoraResponsable_Internalname, context.localUtil.TToC( A49TicketHoraResponsable, 10, 8, 0, 3, "/", ":", " ")) ;
            ChangePostValue( sPrefix+edtEstadoTicketTecnicoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+edtEstadoTicketTecnicoNombre_Internalname, A25EstadoTicketTecnicoNombre) ;
            ChangePostValue( sPrefix+"ZT_"+"Z16TicketResponsableId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16TicketResponsableId), 10, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z49TicketHoraResponsable_"+sGXsfl_242_idx, context.localUtil.TToC( Z49TicketHoraResponsable, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z47TicketFechaResponsable_"+sGXsfl_242_idx, context.localUtil.DToC( Z47TicketFechaResponsable, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z145TicketResponsableInventarioSerie_"+sGXsfl_242_idx, Z145TicketResponsableInventarioSerie) ;
            ChangePostValue( sPrefix+"ZT_"+"Z146TicketResponsableInstalacion_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z146TicketResponsableInstalacion)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z147TicketResponsableConfiguracion_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z147TicketResponsableConfiguracion)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z148TicketResponsableInternetRouter_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z148TicketResponsableInternetRouter)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z149TicketResponsableFormateo_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z149TicketResponsableFormateo)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z150TicketResponsableReparacion_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z150TicketResponsableReparacion)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z151TicketResponsableLimpieza_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z151TicketResponsableLimpieza)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z152TicketResponsablePuntoRed_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z152TicketResponsablePuntoRed)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z153TicketResponsableCambiosHardware_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z153TicketResponsableCambiosHardware)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z154TicketResponsableCopiasRespaldo_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z154TicketResponsableCopiasRespaldo)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z165TicketResponsableCerrado_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z165TicketResponsableCerrado)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z166TicketResponsablePendiente_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z166TicketResponsablePendiente)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z167TicketResponsablePasaTaller_"+sGXsfl_242_idx, StringUtil.BoolToStr( Z167TicketResponsablePasaTaller)) ;
            ChangePostValue( sPrefix+"ZT_"+"Z168TicketResponsableObservacion_"+sGXsfl_242_idx, Z168TicketResponsableObservacion) ;
            ChangePostValue( sPrefix+"ZT_"+"Z175TicketResponsableFechaResuelve_"+sGXsfl_242_idx, context.localUtil.DToC( Z175TicketResponsableFechaResuelve, 0, "/")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z176TicketResponsableHoraResuelve_"+sGXsfl_242_idx, context.localUtil.TToC( Z176TicketResponsableHoraResuelve, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z177TicketResponsableRamTxt_"+sGXsfl_242_idx, Z177TicketResponsableRamTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z178TicketResponsableDiscoDuroTxt_"+sGXsfl_242_idx, Z178TicketResponsableDiscoDuroTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z179TicketResponsableProcesadorTxt_"+sGXsfl_242_idx, Z179TicketResponsableProcesadorTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z180TicketResponsableMaletinTxt_"+sGXsfl_242_idx, Z180TicketResponsableMaletinTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z181TicketResponsableTonerCintaTxt_"+sGXsfl_242_idx, Z181TicketResponsableTonerCintaTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z182TicketResponsableTarjetaVideoExtraTxt_"+sGXsfl_242_idx, Z182TicketResponsableTarjetaVideoExtraTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z183TicketResponsableCargadorLaptopTxt_"+sGXsfl_242_idx, Z183TicketResponsableCargadorLaptopTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z184TicketResponsableCDsDVDsTxt_"+sGXsfl_242_idx, Z184TicketResponsableCDsDVDsTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z185TicketResponsableCableEspecialTxt_"+sGXsfl_242_idx, Z185TicketResponsableCableEspecialTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z186TicketResponsableOtrosTallerTxt_"+sGXsfl_242_idx, Z186TicketResponsableOtrosTallerTxt) ;
            ChangePostValue( sPrefix+"ZT_"+"Z287TicketResponsableFechaHoraAsigna_"+sGXsfl_242_idx, context.localUtil.TToC( Z287TicketResponsableFechaHoraAsigna, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z288TicketResponsableFechaHoraResuelve_"+sGXsfl_242_idx, context.localUtil.TToC( Z288TicketResponsableFechaHoraResuelve, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( sPrefix+"ZT_"+"Z290EtapaDesarrolloId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290EtapaDesarrolloId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z17EstadoTicketTecnicoId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EstadoTicketTecnicoId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"ZT_"+"Z198TicketTecnicoResponsableId_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z198TicketTecnicoResponsableId), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdDeleted_8_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nRcdExists_8_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ",", ""))) ;
            ChangePostValue( sPrefix+"nIsMod_8_"+sGXsfl_242_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ",", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketResponsableId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll078( ) ;
         if ( AnyError != 0 )
         {
            O54TicketLastId = s54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         }
         nRcdExists_8 = 0;
         nIsMod_8 = 0;
         nRcdDeleted_8 = 0;
      }

      protected void ProcessLevel077( )
      {
         /* Save parent mode. */
         sMode7 = Gx_mode;
         ProcessNestedLevel078( ) ;
         if ( AnyError != 0 )
         {
            O54TicketLastId = s54TicketLastId;
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode7;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
         /* Using cursor T000724 */
         pr_default.execute(22, new Object[] {A54TicketLastId, A14TicketId});
         pr_default.close(22);
         dsDefault.SmartCacheProvider.SetUpdated("Ticket");
      }

      protected void EndLevel077( )
      {
         pr_default.close(5);
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(18);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.CommitDataStores("ticket",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(6);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(18);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            pr_default.close(4);
            context.RollbackDataStores("ticket",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000725 */
         pr_default.execute(23);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound7 = 1;
            A14TicketId = T000725_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound7 = 1;
            A14TicketId = T000725_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtTicketId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         edtTicketFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFecha_Enabled), 5, 0), true);
         edtTicketHora_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHora_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioRequerimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         edtEstadoTicketTicketNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketNombre_Enabled), 5, 0), true);
         edtEstadoTicketTicketId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTicketId_Enabled), 5, 0), true);
         edtTicketLastId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Enabled), 5, 0), true);
         chkTicketLaptop.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketLaptop.Enabled), 5, 0), true);
         chkTicketDesktop.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketDesktop.Enabled), 5, 0), true);
         chkTicketMonitor.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketMonitor.Enabled), 5, 0), true);
         chkTicketImpresora.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketImpresora.Enabled), 5, 0), true);
         chkTicketEscaner.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketEscaner.Enabled), 5, 0), true);
         chkTicketRouter.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketRouter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketRouter.Enabled), 5, 0), true);
         chkTicketSistemaOperativo.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketSistemaOperativo.Enabled), 5, 0), true);
         chkTicketOffice.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketOffice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketOffice.Enabled), 5, 0), true);
         chkTicketAntivirus.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketAntivirus.Enabled), 5, 0), true);
         chkTicketAplicacion.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketAplicacion.Enabled), 5, 0), true);
         chkTicketDisenio.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketDisenio.Enabled), 5, 0), true);
         chkTicketIngenieria.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketIngenieria.Enabled), 5, 0), true);
         chkTicketDiscoDuroExterno.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketDiscoDuroExterno.Enabled), 5, 0), true);
         chkTicketPerifericos.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketPerifericos.Enabled), 5, 0), true);
         chkTicketUps.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketUps_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketUps.Enabled), 5, 0), true);
         chkTicketApoyoUsuario.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketApoyoUsuario.Enabled), 5, 0), true);
         chkTicketInstalarDataShow.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketInstalarDataShow.Enabled), 5, 0), true);
         chkTicketOtros.Enabled = 0;
         AssignProp(sPrefix, false, chkTicketOtros_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTicketOtros.Enabled), 5, 0), true);
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z49TicketHoraResponsable = T00073_A49TicketHoraResponsable[0];
               Z47TicketFechaResponsable = T00073_A47TicketFechaResponsable[0];
               Z145TicketResponsableInventarioSerie = T00073_A145TicketResponsableInventarioSerie[0];
               Z146TicketResponsableInstalacion = T00073_A146TicketResponsableInstalacion[0];
               Z147TicketResponsableConfiguracion = T00073_A147TicketResponsableConfiguracion[0];
               Z148TicketResponsableInternetRouter = T00073_A148TicketResponsableInternetRouter[0];
               Z149TicketResponsableFormateo = T00073_A149TicketResponsableFormateo[0];
               Z150TicketResponsableReparacion = T00073_A150TicketResponsableReparacion[0];
               Z151TicketResponsableLimpieza = T00073_A151TicketResponsableLimpieza[0];
               Z152TicketResponsablePuntoRed = T00073_A152TicketResponsablePuntoRed[0];
               Z153TicketResponsableCambiosHardware = T00073_A153TicketResponsableCambiosHardware[0];
               Z154TicketResponsableCopiasRespaldo = T00073_A154TicketResponsableCopiasRespaldo[0];
               Z165TicketResponsableCerrado = T00073_A165TicketResponsableCerrado[0];
               Z166TicketResponsablePendiente = T00073_A166TicketResponsablePendiente[0];
               Z167TicketResponsablePasaTaller = T00073_A167TicketResponsablePasaTaller[0];
               Z168TicketResponsableObservacion = T00073_A168TicketResponsableObservacion[0];
               Z175TicketResponsableFechaResuelve = T00073_A175TicketResponsableFechaResuelve[0];
               Z176TicketResponsableHoraResuelve = T00073_A176TicketResponsableHoraResuelve[0];
               Z177TicketResponsableRamTxt = T00073_A177TicketResponsableRamTxt[0];
               Z178TicketResponsableDiscoDuroTxt = T00073_A178TicketResponsableDiscoDuroTxt[0];
               Z179TicketResponsableProcesadorTxt = T00073_A179TicketResponsableProcesadorTxt[0];
               Z180TicketResponsableMaletinTxt = T00073_A180TicketResponsableMaletinTxt[0];
               Z181TicketResponsableTonerCintaTxt = T00073_A181TicketResponsableTonerCintaTxt[0];
               Z182TicketResponsableTarjetaVideoExtraTxt = T00073_A182TicketResponsableTarjetaVideoExtraTxt[0];
               Z183TicketResponsableCargadorLaptopTxt = T00073_A183TicketResponsableCargadorLaptopTxt[0];
               Z184TicketResponsableCDsDVDsTxt = T00073_A184TicketResponsableCDsDVDsTxt[0];
               Z185TicketResponsableCableEspecialTxt = T00073_A185TicketResponsableCableEspecialTxt[0];
               Z186TicketResponsableOtrosTallerTxt = T00073_A186TicketResponsableOtrosTallerTxt[0];
               Z287TicketResponsableFechaHoraAsigna = T00073_A287TicketResponsableFechaHoraAsigna[0];
               Z288TicketResponsableFechaHoraResuelve = T00073_A288TicketResponsableFechaHoraResuelve[0];
               Z290EtapaDesarrolloId = T00073_A290EtapaDesarrolloId[0];
               Z17EstadoTicketTecnicoId = T00073_A17EstadoTicketTecnicoId[0];
               Z198TicketTecnicoResponsableId = T00073_A198TicketTecnicoResponsableId[0];
            }
            else
            {
               Z49TicketHoraResponsable = A49TicketHoraResponsable;
               Z47TicketFechaResponsable = A47TicketFechaResponsable;
               Z145TicketResponsableInventarioSerie = A145TicketResponsableInventarioSerie;
               Z146TicketResponsableInstalacion = A146TicketResponsableInstalacion;
               Z147TicketResponsableConfiguracion = A147TicketResponsableConfiguracion;
               Z148TicketResponsableInternetRouter = A148TicketResponsableInternetRouter;
               Z149TicketResponsableFormateo = A149TicketResponsableFormateo;
               Z150TicketResponsableReparacion = A150TicketResponsableReparacion;
               Z151TicketResponsableLimpieza = A151TicketResponsableLimpieza;
               Z152TicketResponsablePuntoRed = A152TicketResponsablePuntoRed;
               Z153TicketResponsableCambiosHardware = A153TicketResponsableCambiosHardware;
               Z154TicketResponsableCopiasRespaldo = A154TicketResponsableCopiasRespaldo;
               Z165TicketResponsableCerrado = A165TicketResponsableCerrado;
               Z166TicketResponsablePendiente = A166TicketResponsablePendiente;
               Z167TicketResponsablePasaTaller = A167TicketResponsablePasaTaller;
               Z168TicketResponsableObservacion = A168TicketResponsableObservacion;
               Z175TicketResponsableFechaResuelve = A175TicketResponsableFechaResuelve;
               Z176TicketResponsableHoraResuelve = A176TicketResponsableHoraResuelve;
               Z177TicketResponsableRamTxt = A177TicketResponsableRamTxt;
               Z178TicketResponsableDiscoDuroTxt = A178TicketResponsableDiscoDuroTxt;
               Z179TicketResponsableProcesadorTxt = A179TicketResponsableProcesadorTxt;
               Z180TicketResponsableMaletinTxt = A180TicketResponsableMaletinTxt;
               Z181TicketResponsableTonerCintaTxt = A181TicketResponsableTonerCintaTxt;
               Z182TicketResponsableTarjetaVideoExtraTxt = A182TicketResponsableTarjetaVideoExtraTxt;
               Z183TicketResponsableCargadorLaptopTxt = A183TicketResponsableCargadorLaptopTxt;
               Z184TicketResponsableCDsDVDsTxt = A184TicketResponsableCDsDVDsTxt;
               Z185TicketResponsableCableEspecialTxt = A185TicketResponsableCableEspecialTxt;
               Z186TicketResponsableOtrosTallerTxt = A186TicketResponsableOtrosTallerTxt;
               Z287TicketResponsableFechaHoraAsigna = A287TicketResponsableFechaHoraAsigna;
               Z288TicketResponsableFechaHoraResuelve = A288TicketResponsableFechaHoraResuelve;
               Z290EtapaDesarrolloId = A290EtapaDesarrolloId;
               Z17EstadoTicketTecnicoId = A17EstadoTicketTecnicoId;
               Z198TicketTecnicoResponsableId = A198TicketTecnicoResponsableId;
            }
         }
         if ( GX_JID == -34 )
         {
            Z14TicketId = A14TicketId;
            Z16TicketResponsableId = A16TicketResponsableId;
            Z49TicketHoraResponsable = A49TicketHoraResponsable;
            Z47TicketFechaResponsable = A47TicketFechaResponsable;
            Z145TicketResponsableInventarioSerie = A145TicketResponsableInventarioSerie;
            Z146TicketResponsableInstalacion = A146TicketResponsableInstalacion;
            Z147TicketResponsableConfiguracion = A147TicketResponsableConfiguracion;
            Z148TicketResponsableInternetRouter = A148TicketResponsableInternetRouter;
            Z149TicketResponsableFormateo = A149TicketResponsableFormateo;
            Z150TicketResponsableReparacion = A150TicketResponsableReparacion;
            Z151TicketResponsableLimpieza = A151TicketResponsableLimpieza;
            Z152TicketResponsablePuntoRed = A152TicketResponsablePuntoRed;
            Z153TicketResponsableCambiosHardware = A153TicketResponsableCambiosHardware;
            Z154TicketResponsableCopiasRespaldo = A154TicketResponsableCopiasRespaldo;
            Z165TicketResponsableCerrado = A165TicketResponsableCerrado;
            Z166TicketResponsablePendiente = A166TicketResponsablePendiente;
            Z167TicketResponsablePasaTaller = A167TicketResponsablePasaTaller;
            Z168TicketResponsableObservacion = A168TicketResponsableObservacion;
            Z175TicketResponsableFechaResuelve = A175TicketResponsableFechaResuelve;
            Z176TicketResponsableHoraResuelve = A176TicketResponsableHoraResuelve;
            Z177TicketResponsableRamTxt = A177TicketResponsableRamTxt;
            Z178TicketResponsableDiscoDuroTxt = A178TicketResponsableDiscoDuroTxt;
            Z179TicketResponsableProcesadorTxt = A179TicketResponsableProcesadorTxt;
            Z180TicketResponsableMaletinTxt = A180TicketResponsableMaletinTxt;
            Z181TicketResponsableTonerCintaTxt = A181TicketResponsableTonerCintaTxt;
            Z182TicketResponsableTarjetaVideoExtraTxt = A182TicketResponsableTarjetaVideoExtraTxt;
            Z183TicketResponsableCargadorLaptopTxt = A183TicketResponsableCargadorLaptopTxt;
            Z184TicketResponsableCDsDVDsTxt = A184TicketResponsableCDsDVDsTxt;
            Z185TicketResponsableCableEspecialTxt = A185TicketResponsableCableEspecialTxt;
            Z186TicketResponsableOtrosTallerTxt = A186TicketResponsableOtrosTallerTxt;
            Z287TicketResponsableFechaHoraAsigna = A287TicketResponsableFechaHoraAsigna;
            Z288TicketResponsableFechaHoraResuelve = A288TicketResponsableFechaHoraResuelve;
            Z290EtapaDesarrolloId = A290EtapaDesarrolloId;
            Z17EstadoTicketTecnicoId = A17EstadoTicketTecnicoId;
            Z198TicketTecnicoResponsableId = A198TicketTecnicoResponsableId;
            Z291EtapaDesarrolloNombre = A291EtapaDesarrolloNombre;
            Z25EstadoTicketTecnicoNombre = A25EstadoTicketTecnicoNombre;
            Z199TicketTecnicoResponsableNombre = A199TicketTecnicoResponsableNombre;
         }
      }

      protected void standaloneNotModal078( )
      {
         edtTicketFechaResponsable_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketFechaResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketHoraResponsable_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketHoraResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtEstadoTicketTecnicoId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtEstadoTicketTecnicoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketTecnicoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketLastId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Enabled), 5, 0), true);
         edtTicketLastId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketLastId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketLastId_Enabled), 5, 0), true);
      }

      protected void standaloneModal078( )
      {
         if ( IsIns( )  )
         {
            A54TicketLastId = (long)(O54TicketLastId+1);
            AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         }
         if ( IsIns( )  && ( Gx_BScreen == 1 ) )
         {
            A16TicketResponsableId = A54TicketLastId;
         }
         if ( IsIns( )  && (DateTime.MinValue==A49TicketHoraResponsable) && ( Gx_BScreen == 0 ) )
         {
            A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         }
         if ( IsIns( )  && (DateTime.MinValue==A47TicketFechaResponsable) && ( Gx_BScreen == 0 ) )
         {
            A47TicketFechaResponsable = DateTimeUtil.Today( context);
         }
         if ( IsIns( )  && (0==A17EstadoTicketTecnicoId) && ( Gx_BScreen == 0 ) )
         {
            A17EstadoTicketTecnicoId = 3;
         }
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {n290EtapaDesarrolloId, A290EtapaDesarrolloId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A290EtapaDesarrolloId) ) )
            {
               GX_msglist.addItem("No existe 'Etapas Desarrollo'.", "ForeignKeyNotFound", 1, "ETAPADESARROLLOID");
               AnyError = 1;
            }
         }
         A291EtapaDesarrolloNombre = T00074_A291EtapaDesarrolloNombre[0];
         pr_default.close(2);
         /* Using cursor T00075 */
         pr_default.execute(3, new Object[] {A17EstadoTicketTecnicoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GXCCtl = "ESTADOTICKETTECNICOID_" + sGXsfl_242_idx;
            GX_msglist.addItem("No existe 'Estado Ticket Tecnico'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
         }
         A25EstadoTicketTecnicoNombre = T00075_A25EstadoTicketTecnicoNombre[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtTicketResponsableId_Enabled = 0;
            AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         }
         else
         {
            edtTicketResponsableId_Enabled = 1;
            AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         }
      }

      protected void Load078( )
      {
         /* Using cursor T000726 */
         pr_default.execute(24, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound8 = 1;
            A49TicketHoraResponsable = T000726_A49TicketHoraResponsable[0];
            A47TicketFechaResponsable = T000726_A47TicketFechaResponsable[0];
            A199TicketTecnicoResponsableNombre = T000726_A199TicketTecnicoResponsableNombre[0];
            A25EstadoTicketTecnicoNombre = T000726_A25EstadoTicketTecnicoNombre[0];
            A145TicketResponsableInventarioSerie = T000726_A145TicketResponsableInventarioSerie[0];
            n145TicketResponsableInventarioSerie = T000726_n145TicketResponsableInventarioSerie[0];
            A146TicketResponsableInstalacion = T000726_A146TicketResponsableInstalacion[0];
            n146TicketResponsableInstalacion = T000726_n146TicketResponsableInstalacion[0];
            A147TicketResponsableConfiguracion = T000726_A147TicketResponsableConfiguracion[0];
            n147TicketResponsableConfiguracion = T000726_n147TicketResponsableConfiguracion[0];
            A148TicketResponsableInternetRouter = T000726_A148TicketResponsableInternetRouter[0];
            n148TicketResponsableInternetRouter = T000726_n148TicketResponsableInternetRouter[0];
            A149TicketResponsableFormateo = T000726_A149TicketResponsableFormateo[0];
            n149TicketResponsableFormateo = T000726_n149TicketResponsableFormateo[0];
            A150TicketResponsableReparacion = T000726_A150TicketResponsableReparacion[0];
            n150TicketResponsableReparacion = T000726_n150TicketResponsableReparacion[0];
            A151TicketResponsableLimpieza = T000726_A151TicketResponsableLimpieza[0];
            n151TicketResponsableLimpieza = T000726_n151TicketResponsableLimpieza[0];
            A152TicketResponsablePuntoRed = T000726_A152TicketResponsablePuntoRed[0];
            n152TicketResponsablePuntoRed = T000726_n152TicketResponsablePuntoRed[0];
            A153TicketResponsableCambiosHardware = T000726_A153TicketResponsableCambiosHardware[0];
            n153TicketResponsableCambiosHardware = T000726_n153TicketResponsableCambiosHardware[0];
            A154TicketResponsableCopiasRespaldo = T000726_A154TicketResponsableCopiasRespaldo[0];
            n154TicketResponsableCopiasRespaldo = T000726_n154TicketResponsableCopiasRespaldo[0];
            A165TicketResponsableCerrado = T000726_A165TicketResponsableCerrado[0];
            n165TicketResponsableCerrado = T000726_n165TicketResponsableCerrado[0];
            A166TicketResponsablePendiente = T000726_A166TicketResponsablePendiente[0];
            n166TicketResponsablePendiente = T000726_n166TicketResponsablePendiente[0];
            A167TicketResponsablePasaTaller = T000726_A167TicketResponsablePasaTaller[0];
            n167TicketResponsablePasaTaller = T000726_n167TicketResponsablePasaTaller[0];
            A168TicketResponsableObservacion = T000726_A168TicketResponsableObservacion[0];
            n168TicketResponsableObservacion = T000726_n168TicketResponsableObservacion[0];
            A175TicketResponsableFechaResuelve = T000726_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = T000726_n175TicketResponsableFechaResuelve[0];
            A176TicketResponsableHoraResuelve = T000726_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = T000726_n176TicketResponsableHoraResuelve[0];
            A177TicketResponsableRamTxt = T000726_A177TicketResponsableRamTxt[0];
            n177TicketResponsableRamTxt = T000726_n177TicketResponsableRamTxt[0];
            A178TicketResponsableDiscoDuroTxt = T000726_A178TicketResponsableDiscoDuroTxt[0];
            n178TicketResponsableDiscoDuroTxt = T000726_n178TicketResponsableDiscoDuroTxt[0];
            A179TicketResponsableProcesadorTxt = T000726_A179TicketResponsableProcesadorTxt[0];
            n179TicketResponsableProcesadorTxt = T000726_n179TicketResponsableProcesadorTxt[0];
            A180TicketResponsableMaletinTxt = T000726_A180TicketResponsableMaletinTxt[0];
            n180TicketResponsableMaletinTxt = T000726_n180TicketResponsableMaletinTxt[0];
            A181TicketResponsableTonerCintaTxt = T000726_A181TicketResponsableTonerCintaTxt[0];
            n181TicketResponsableTonerCintaTxt = T000726_n181TicketResponsableTonerCintaTxt[0];
            A182TicketResponsableTarjetaVideoExtraTxt = T000726_A182TicketResponsableTarjetaVideoExtraTxt[0];
            n182TicketResponsableTarjetaVideoExtraTxt = T000726_n182TicketResponsableTarjetaVideoExtraTxt[0];
            A183TicketResponsableCargadorLaptopTxt = T000726_A183TicketResponsableCargadorLaptopTxt[0];
            n183TicketResponsableCargadorLaptopTxt = T000726_n183TicketResponsableCargadorLaptopTxt[0];
            A184TicketResponsableCDsDVDsTxt = T000726_A184TicketResponsableCDsDVDsTxt[0];
            n184TicketResponsableCDsDVDsTxt = T000726_n184TicketResponsableCDsDVDsTxt[0];
            A185TicketResponsableCableEspecialTxt = T000726_A185TicketResponsableCableEspecialTxt[0];
            n185TicketResponsableCableEspecialTxt = T000726_n185TicketResponsableCableEspecialTxt[0];
            A186TicketResponsableOtrosTallerTxt = T000726_A186TicketResponsableOtrosTallerTxt[0];
            n186TicketResponsableOtrosTallerTxt = T000726_n186TicketResponsableOtrosTallerTxt[0];
            A287TicketResponsableFechaHoraAsigna = T000726_A287TicketResponsableFechaHoraAsigna[0];
            n287TicketResponsableFechaHoraAsigna = T000726_n287TicketResponsableFechaHoraAsigna[0];
            A288TicketResponsableFechaHoraResuelve = T000726_A288TicketResponsableFechaHoraResuelve[0];
            n288TicketResponsableFechaHoraResuelve = T000726_n288TicketResponsableFechaHoraResuelve[0];
            A291EtapaDesarrolloNombre = T000726_A291EtapaDesarrolloNombre[0];
            A290EtapaDesarrolloId = T000726_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = T000726_n290EtapaDesarrolloId[0];
            A17EstadoTicketTecnicoId = T000726_A17EstadoTicketTecnicoId[0];
            A198TicketTecnicoResponsableId = T000726_A198TicketTecnicoResponsableId[0];
            ZM078( -34) ;
         }
         pr_default.close(24);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal078( ) ;
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A198TicketTecnicoResponsableId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GXCCtl = "TICKETTECNICORESPONSABLEID_" + sGXsfl_242_idx;
            GX_msglist.addItem("No existe 'Sg Ticket Tecnico Responsable'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTicketTecnicoResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A199TicketTecnicoResponsableNombre = T00076_A199TicketTecnicoResponsableNombre[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors078( )
      {
         pr_default.close(4);
      }

      protected void enableDisable078( )
      {
      }

      protected void gxLoad_37( short A198TicketTecnicoResponsableId )
      {
         /* Using cursor T000727 */
         pr_default.execute(25, new Object[] {A198TicketTecnicoResponsableId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GXCCtl = "TICKETTECNICORESPONSABLEID_" + sGXsfl_242_idx;
            GX_msglist.addItem("No existe 'Sg Ticket Tecnico Responsable'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTicketTecnicoResponsableId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A199TicketTecnicoResponsableNombre = T000727_A199TicketTecnicoResponsableNombre[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A199TicketTecnicoResponsableNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey078( )
      {
         /* Using cursor T000728 */
         pr_default.execute(26, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey078( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 34) ;
            RcdFound8 = 1;
            InitializeNonKey078( ) ;
            A16TicketResponsableId = T00073_A16TicketResponsableId[0];
            A49TicketHoraResponsable = T00073_A49TicketHoraResponsable[0];
            A47TicketFechaResponsable = T00073_A47TicketFechaResponsable[0];
            A145TicketResponsableInventarioSerie = T00073_A145TicketResponsableInventarioSerie[0];
            n145TicketResponsableInventarioSerie = T00073_n145TicketResponsableInventarioSerie[0];
            A146TicketResponsableInstalacion = T00073_A146TicketResponsableInstalacion[0];
            n146TicketResponsableInstalacion = T00073_n146TicketResponsableInstalacion[0];
            A147TicketResponsableConfiguracion = T00073_A147TicketResponsableConfiguracion[0];
            n147TicketResponsableConfiguracion = T00073_n147TicketResponsableConfiguracion[0];
            A148TicketResponsableInternetRouter = T00073_A148TicketResponsableInternetRouter[0];
            n148TicketResponsableInternetRouter = T00073_n148TicketResponsableInternetRouter[0];
            A149TicketResponsableFormateo = T00073_A149TicketResponsableFormateo[0];
            n149TicketResponsableFormateo = T00073_n149TicketResponsableFormateo[0];
            A150TicketResponsableReparacion = T00073_A150TicketResponsableReparacion[0];
            n150TicketResponsableReparacion = T00073_n150TicketResponsableReparacion[0];
            A151TicketResponsableLimpieza = T00073_A151TicketResponsableLimpieza[0];
            n151TicketResponsableLimpieza = T00073_n151TicketResponsableLimpieza[0];
            A152TicketResponsablePuntoRed = T00073_A152TicketResponsablePuntoRed[0];
            n152TicketResponsablePuntoRed = T00073_n152TicketResponsablePuntoRed[0];
            A153TicketResponsableCambiosHardware = T00073_A153TicketResponsableCambiosHardware[0];
            n153TicketResponsableCambiosHardware = T00073_n153TicketResponsableCambiosHardware[0];
            A154TicketResponsableCopiasRespaldo = T00073_A154TicketResponsableCopiasRespaldo[0];
            n154TicketResponsableCopiasRespaldo = T00073_n154TicketResponsableCopiasRespaldo[0];
            A165TicketResponsableCerrado = T00073_A165TicketResponsableCerrado[0];
            n165TicketResponsableCerrado = T00073_n165TicketResponsableCerrado[0];
            A166TicketResponsablePendiente = T00073_A166TicketResponsablePendiente[0];
            n166TicketResponsablePendiente = T00073_n166TicketResponsablePendiente[0];
            A167TicketResponsablePasaTaller = T00073_A167TicketResponsablePasaTaller[0];
            n167TicketResponsablePasaTaller = T00073_n167TicketResponsablePasaTaller[0];
            A168TicketResponsableObservacion = T00073_A168TicketResponsableObservacion[0];
            n168TicketResponsableObservacion = T00073_n168TicketResponsableObservacion[0];
            A175TicketResponsableFechaResuelve = T00073_A175TicketResponsableFechaResuelve[0];
            n175TicketResponsableFechaResuelve = T00073_n175TicketResponsableFechaResuelve[0];
            A176TicketResponsableHoraResuelve = T00073_A176TicketResponsableHoraResuelve[0];
            n176TicketResponsableHoraResuelve = T00073_n176TicketResponsableHoraResuelve[0];
            A177TicketResponsableRamTxt = T00073_A177TicketResponsableRamTxt[0];
            n177TicketResponsableRamTxt = T00073_n177TicketResponsableRamTxt[0];
            A178TicketResponsableDiscoDuroTxt = T00073_A178TicketResponsableDiscoDuroTxt[0];
            n178TicketResponsableDiscoDuroTxt = T00073_n178TicketResponsableDiscoDuroTxt[0];
            A179TicketResponsableProcesadorTxt = T00073_A179TicketResponsableProcesadorTxt[0];
            n179TicketResponsableProcesadorTxt = T00073_n179TicketResponsableProcesadorTxt[0];
            A180TicketResponsableMaletinTxt = T00073_A180TicketResponsableMaletinTxt[0];
            n180TicketResponsableMaletinTxt = T00073_n180TicketResponsableMaletinTxt[0];
            A181TicketResponsableTonerCintaTxt = T00073_A181TicketResponsableTonerCintaTxt[0];
            n181TicketResponsableTonerCintaTxt = T00073_n181TicketResponsableTonerCintaTxt[0];
            A182TicketResponsableTarjetaVideoExtraTxt = T00073_A182TicketResponsableTarjetaVideoExtraTxt[0];
            n182TicketResponsableTarjetaVideoExtraTxt = T00073_n182TicketResponsableTarjetaVideoExtraTxt[0];
            A183TicketResponsableCargadorLaptopTxt = T00073_A183TicketResponsableCargadorLaptopTxt[0];
            n183TicketResponsableCargadorLaptopTxt = T00073_n183TicketResponsableCargadorLaptopTxt[0];
            A184TicketResponsableCDsDVDsTxt = T00073_A184TicketResponsableCDsDVDsTxt[0];
            n184TicketResponsableCDsDVDsTxt = T00073_n184TicketResponsableCDsDVDsTxt[0];
            A185TicketResponsableCableEspecialTxt = T00073_A185TicketResponsableCableEspecialTxt[0];
            n185TicketResponsableCableEspecialTxt = T00073_n185TicketResponsableCableEspecialTxt[0];
            A186TicketResponsableOtrosTallerTxt = T00073_A186TicketResponsableOtrosTallerTxt[0];
            n186TicketResponsableOtrosTallerTxt = T00073_n186TicketResponsableOtrosTallerTxt[0];
            A287TicketResponsableFechaHoraAsigna = T00073_A287TicketResponsableFechaHoraAsigna[0];
            n287TicketResponsableFechaHoraAsigna = T00073_n287TicketResponsableFechaHoraAsigna[0];
            A288TicketResponsableFechaHoraResuelve = T00073_A288TicketResponsableFechaHoraResuelve[0];
            n288TicketResponsableFechaHoraResuelve = T00073_n288TicketResponsableFechaHoraResuelve[0];
            A290EtapaDesarrolloId = T00073_A290EtapaDesarrolloId[0];
            n290EtapaDesarrolloId = T00073_n290EtapaDesarrolloId[0];
            A17EstadoTicketTecnicoId = T00073_A17EstadoTicketTecnicoId[0];
            A198TicketTecnicoResponsableId = T00073_A198TicketTecnicoResponsableId[0];
            Z14TicketId = A14TicketId;
            Z16TicketResponsableId = A16TicketResponsableId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load078( ) ;
            Gx_mode = sMode8;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal078( ) ;
            Gx_mode = sMode8;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes078( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A14TicketId, A16TicketResponsableId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TicketResponsable"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z49TicketHoraResponsable != T00072_A49TicketHoraResponsable[0] ) || ( Z47TicketFechaResponsable != T00072_A47TicketFechaResponsable[0] ) || ( StringUtil.StrCmp(Z145TicketResponsableInventarioSerie, T00072_A145TicketResponsableInventarioSerie[0]) != 0 ) || ( Z146TicketResponsableInstalacion != T00072_A146TicketResponsableInstalacion[0] ) || ( Z147TicketResponsableConfiguracion != T00072_A147TicketResponsableConfiguracion[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z148TicketResponsableInternetRouter != T00072_A148TicketResponsableInternetRouter[0] ) || ( Z149TicketResponsableFormateo != T00072_A149TicketResponsableFormateo[0] ) || ( Z150TicketResponsableReparacion != T00072_A150TicketResponsableReparacion[0] ) || ( Z151TicketResponsableLimpieza != T00072_A151TicketResponsableLimpieza[0] ) || ( Z152TicketResponsablePuntoRed != T00072_A152TicketResponsablePuntoRed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z153TicketResponsableCambiosHardware != T00072_A153TicketResponsableCambiosHardware[0] ) || ( Z154TicketResponsableCopiasRespaldo != T00072_A154TicketResponsableCopiasRespaldo[0] ) || ( Z165TicketResponsableCerrado != T00072_A165TicketResponsableCerrado[0] ) || ( Z166TicketResponsablePendiente != T00072_A166TicketResponsablePendiente[0] ) || ( Z167TicketResponsablePasaTaller != T00072_A167TicketResponsablePasaTaller[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z168TicketResponsableObservacion, T00072_A168TicketResponsableObservacion[0]) != 0 ) || ( Z175TicketResponsableFechaResuelve != T00072_A175TicketResponsableFechaResuelve[0] ) || ( Z176TicketResponsableHoraResuelve != T00072_A176TicketResponsableHoraResuelve[0] ) || ( StringUtil.StrCmp(Z177TicketResponsableRamTxt, T00072_A177TicketResponsableRamTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z178TicketResponsableDiscoDuroTxt, T00072_A178TicketResponsableDiscoDuroTxt[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z179TicketResponsableProcesadorTxt, T00072_A179TicketResponsableProcesadorTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z180TicketResponsableMaletinTxt, T00072_A180TicketResponsableMaletinTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z181TicketResponsableTonerCintaTxt, T00072_A181TicketResponsableTonerCintaTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z182TicketResponsableTarjetaVideoExtraTxt, T00072_A182TicketResponsableTarjetaVideoExtraTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z183TicketResponsableCargadorLaptopTxt, T00072_A183TicketResponsableCargadorLaptopTxt[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z184TicketResponsableCDsDVDsTxt, T00072_A184TicketResponsableCDsDVDsTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z185TicketResponsableCableEspecialTxt, T00072_A185TicketResponsableCableEspecialTxt[0]) != 0 ) || ( StringUtil.StrCmp(Z186TicketResponsableOtrosTallerTxt, T00072_A186TicketResponsableOtrosTallerTxt[0]) != 0 ) || ( Z287TicketResponsableFechaHoraAsigna != T00072_A287TicketResponsableFechaHoraAsigna[0] ) || ( Z288TicketResponsableFechaHoraResuelve != T00072_A288TicketResponsableFechaHoraResuelve[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z290EtapaDesarrolloId != T00072_A290EtapaDesarrolloId[0] ) || ( Z17EstadoTicketTecnicoId != T00072_A17EstadoTicketTecnicoId[0] ) || ( Z198TicketTecnicoResponsableId != T00072_A198TicketTecnicoResponsableId[0] ) )
            {
               if ( Z49TicketHoraResponsable != T00072_A49TicketHoraResponsable[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketHoraResponsable");
                  GXUtil.WriteLogRaw("Old: ",Z49TicketHoraResponsable);
                  GXUtil.WriteLogRaw("Current: ",T00072_A49TicketHoraResponsable[0]);
               }
               if ( Z47TicketFechaResponsable != T00072_A47TicketFechaResponsable[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketFechaResponsable");
                  GXUtil.WriteLogRaw("Old: ",Z47TicketFechaResponsable);
                  GXUtil.WriteLogRaw("Current: ",T00072_A47TicketFechaResponsable[0]);
               }
               if ( StringUtil.StrCmp(Z145TicketResponsableInventarioSerie, T00072_A145TicketResponsableInventarioSerie[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableInventarioSerie");
                  GXUtil.WriteLogRaw("Old: ",Z145TicketResponsableInventarioSerie);
                  GXUtil.WriteLogRaw("Current: ",T00072_A145TicketResponsableInventarioSerie[0]);
               }
               if ( Z146TicketResponsableInstalacion != T00072_A146TicketResponsableInstalacion[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableInstalacion");
                  GXUtil.WriteLogRaw("Old: ",Z146TicketResponsableInstalacion);
                  GXUtil.WriteLogRaw("Current: ",T00072_A146TicketResponsableInstalacion[0]);
               }
               if ( Z147TicketResponsableConfiguracion != T00072_A147TicketResponsableConfiguracion[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableConfiguracion");
                  GXUtil.WriteLogRaw("Old: ",Z147TicketResponsableConfiguracion);
                  GXUtil.WriteLogRaw("Current: ",T00072_A147TicketResponsableConfiguracion[0]);
               }
               if ( Z148TicketResponsableInternetRouter != T00072_A148TicketResponsableInternetRouter[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableInternetRouter");
                  GXUtil.WriteLogRaw("Old: ",Z148TicketResponsableInternetRouter);
                  GXUtil.WriteLogRaw("Current: ",T00072_A148TicketResponsableInternetRouter[0]);
               }
               if ( Z149TicketResponsableFormateo != T00072_A149TicketResponsableFormateo[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableFormateo");
                  GXUtil.WriteLogRaw("Old: ",Z149TicketResponsableFormateo);
                  GXUtil.WriteLogRaw("Current: ",T00072_A149TicketResponsableFormateo[0]);
               }
               if ( Z150TicketResponsableReparacion != T00072_A150TicketResponsableReparacion[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableReparacion");
                  GXUtil.WriteLogRaw("Old: ",Z150TicketResponsableReparacion);
                  GXUtil.WriteLogRaw("Current: ",T00072_A150TicketResponsableReparacion[0]);
               }
               if ( Z151TicketResponsableLimpieza != T00072_A151TicketResponsableLimpieza[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableLimpieza");
                  GXUtil.WriteLogRaw("Old: ",Z151TicketResponsableLimpieza);
                  GXUtil.WriteLogRaw("Current: ",T00072_A151TicketResponsableLimpieza[0]);
               }
               if ( Z152TicketResponsablePuntoRed != T00072_A152TicketResponsablePuntoRed[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsablePuntoRed");
                  GXUtil.WriteLogRaw("Old: ",Z152TicketResponsablePuntoRed);
                  GXUtil.WriteLogRaw("Current: ",T00072_A152TicketResponsablePuntoRed[0]);
               }
               if ( Z153TicketResponsableCambiosHardware != T00072_A153TicketResponsableCambiosHardware[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableCambiosHardware");
                  GXUtil.WriteLogRaw("Old: ",Z153TicketResponsableCambiosHardware);
                  GXUtil.WriteLogRaw("Current: ",T00072_A153TicketResponsableCambiosHardware[0]);
               }
               if ( Z154TicketResponsableCopiasRespaldo != T00072_A154TicketResponsableCopiasRespaldo[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableCopiasRespaldo");
                  GXUtil.WriteLogRaw("Old: ",Z154TicketResponsableCopiasRespaldo);
                  GXUtil.WriteLogRaw("Current: ",T00072_A154TicketResponsableCopiasRespaldo[0]);
               }
               if ( Z165TicketResponsableCerrado != T00072_A165TicketResponsableCerrado[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableCerrado");
                  GXUtil.WriteLogRaw("Old: ",Z165TicketResponsableCerrado);
                  GXUtil.WriteLogRaw("Current: ",T00072_A165TicketResponsableCerrado[0]);
               }
               if ( Z166TicketResponsablePendiente != T00072_A166TicketResponsablePendiente[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsablePendiente");
                  GXUtil.WriteLogRaw("Old: ",Z166TicketResponsablePendiente);
                  GXUtil.WriteLogRaw("Current: ",T00072_A166TicketResponsablePendiente[0]);
               }
               if ( Z167TicketResponsablePasaTaller != T00072_A167TicketResponsablePasaTaller[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsablePasaTaller");
                  GXUtil.WriteLogRaw("Old: ",Z167TicketResponsablePasaTaller);
                  GXUtil.WriteLogRaw("Current: ",T00072_A167TicketResponsablePasaTaller[0]);
               }
               if ( StringUtil.StrCmp(Z168TicketResponsableObservacion, T00072_A168TicketResponsableObservacion[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableObservacion");
                  GXUtil.WriteLogRaw("Old: ",Z168TicketResponsableObservacion);
                  GXUtil.WriteLogRaw("Current: ",T00072_A168TicketResponsableObservacion[0]);
               }
               if ( Z175TicketResponsableFechaResuelve != T00072_A175TicketResponsableFechaResuelve[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableFechaResuelve");
                  GXUtil.WriteLogRaw("Old: ",Z175TicketResponsableFechaResuelve);
                  GXUtil.WriteLogRaw("Current: ",T00072_A175TicketResponsableFechaResuelve[0]);
               }
               if ( Z176TicketResponsableHoraResuelve != T00072_A176TicketResponsableHoraResuelve[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableHoraResuelve");
                  GXUtil.WriteLogRaw("Old: ",Z176TicketResponsableHoraResuelve);
                  GXUtil.WriteLogRaw("Current: ",T00072_A176TicketResponsableHoraResuelve[0]);
               }
               if ( StringUtil.StrCmp(Z177TicketResponsableRamTxt, T00072_A177TicketResponsableRamTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableRamTxt");
                  GXUtil.WriteLogRaw("Old: ",Z177TicketResponsableRamTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A177TicketResponsableRamTxt[0]);
               }
               if ( StringUtil.StrCmp(Z178TicketResponsableDiscoDuroTxt, T00072_A178TicketResponsableDiscoDuroTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableDiscoDuroTxt");
                  GXUtil.WriteLogRaw("Old: ",Z178TicketResponsableDiscoDuroTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A178TicketResponsableDiscoDuroTxt[0]);
               }
               if ( StringUtil.StrCmp(Z179TicketResponsableProcesadorTxt, T00072_A179TicketResponsableProcesadorTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableProcesadorTxt");
                  GXUtil.WriteLogRaw("Old: ",Z179TicketResponsableProcesadorTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A179TicketResponsableProcesadorTxt[0]);
               }
               if ( StringUtil.StrCmp(Z180TicketResponsableMaletinTxt, T00072_A180TicketResponsableMaletinTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableMaletinTxt");
                  GXUtil.WriteLogRaw("Old: ",Z180TicketResponsableMaletinTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A180TicketResponsableMaletinTxt[0]);
               }
               if ( StringUtil.StrCmp(Z181TicketResponsableTonerCintaTxt, T00072_A181TicketResponsableTonerCintaTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableTonerCintaTxt");
                  GXUtil.WriteLogRaw("Old: ",Z181TicketResponsableTonerCintaTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A181TicketResponsableTonerCintaTxt[0]);
               }
               if ( StringUtil.StrCmp(Z182TicketResponsableTarjetaVideoExtraTxt, T00072_A182TicketResponsableTarjetaVideoExtraTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableTarjetaVideoExtraTxt");
                  GXUtil.WriteLogRaw("Old: ",Z182TicketResponsableTarjetaVideoExtraTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A182TicketResponsableTarjetaVideoExtraTxt[0]);
               }
               if ( StringUtil.StrCmp(Z183TicketResponsableCargadorLaptopTxt, T00072_A183TicketResponsableCargadorLaptopTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableCargadorLaptopTxt");
                  GXUtil.WriteLogRaw("Old: ",Z183TicketResponsableCargadorLaptopTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A183TicketResponsableCargadorLaptopTxt[0]);
               }
               if ( StringUtil.StrCmp(Z184TicketResponsableCDsDVDsTxt, T00072_A184TicketResponsableCDsDVDsTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableCDsDVDsTxt");
                  GXUtil.WriteLogRaw("Old: ",Z184TicketResponsableCDsDVDsTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A184TicketResponsableCDsDVDsTxt[0]);
               }
               if ( StringUtil.StrCmp(Z185TicketResponsableCableEspecialTxt, T00072_A185TicketResponsableCableEspecialTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableCableEspecialTxt");
                  GXUtil.WriteLogRaw("Old: ",Z185TicketResponsableCableEspecialTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A185TicketResponsableCableEspecialTxt[0]);
               }
               if ( StringUtil.StrCmp(Z186TicketResponsableOtrosTallerTxt, T00072_A186TicketResponsableOtrosTallerTxt[0]) != 0 )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableOtrosTallerTxt");
                  GXUtil.WriteLogRaw("Old: ",Z186TicketResponsableOtrosTallerTxt);
                  GXUtil.WriteLogRaw("Current: ",T00072_A186TicketResponsableOtrosTallerTxt[0]);
               }
               if ( Z287TicketResponsableFechaHoraAsigna != T00072_A287TicketResponsableFechaHoraAsigna[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableFechaHoraAsigna");
                  GXUtil.WriteLogRaw("Old: ",Z287TicketResponsableFechaHoraAsigna);
                  GXUtil.WriteLogRaw("Current: ",T00072_A287TicketResponsableFechaHoraAsigna[0]);
               }
               if ( Z288TicketResponsableFechaHoraResuelve != T00072_A288TicketResponsableFechaHoraResuelve[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketResponsableFechaHoraResuelve");
                  GXUtil.WriteLogRaw("Old: ",Z288TicketResponsableFechaHoraResuelve);
                  GXUtil.WriteLogRaw("Current: ",T00072_A288TicketResponsableFechaHoraResuelve[0]);
               }
               if ( Z290EtapaDesarrolloId != T00072_A290EtapaDesarrolloId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"EtapaDesarrolloId");
                  GXUtil.WriteLogRaw("Old: ",Z290EtapaDesarrolloId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A290EtapaDesarrolloId[0]);
               }
               if ( Z17EstadoTicketTecnicoId != T00072_A17EstadoTicketTecnicoId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"EstadoTicketTecnicoId");
                  GXUtil.WriteLogRaw("Old: ",Z17EstadoTicketTecnicoId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A17EstadoTicketTecnicoId[0]);
               }
               if ( Z198TicketTecnicoResponsableId != T00072_A198TicketTecnicoResponsableId[0] )
               {
                  GXUtil.WriteLog("ticket:[seudo value changed for attri]"+"TicketTecnicoResponsableId");
                  GXUtil.WriteLogRaw("Old: ",Z198TicketTecnicoResponsableId);
                  GXUtil.WriteLogRaw("Current: ",T00072_A198TicketTecnicoResponsableId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TicketResponsable"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         if ( ! IsAuthorized("ticket_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000729 */
                     pr_default.execute(27, new Object[] {A14TicketId, A16TicketResponsableId, A49TicketHoraResponsable, A47TicketFechaResponsable, n145TicketResponsableInventarioSerie, A145TicketResponsableInventarioSerie, n146TicketResponsableInstalacion, A146TicketResponsableInstalacion, n147TicketResponsableConfiguracion, A147TicketResponsableConfiguracion, n148TicketResponsableInternetRouter, A148TicketResponsableInternetRouter, n149TicketResponsableFormateo, A149TicketResponsableFormateo, n150TicketResponsableReparacion, A150TicketResponsableReparacion, n151TicketResponsableLimpieza, A151TicketResponsableLimpieza, n152TicketResponsablePuntoRed, A152TicketResponsablePuntoRed, n153TicketResponsableCambiosHardware, A153TicketResponsableCambiosHardware, n154TicketResponsableCopiasRespaldo, A154TicketResponsableCopiasRespaldo, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, n168TicketResponsableObservacion, A168TicketResponsableObservacion, n175TicketResponsableFechaResuelve, A175TicketResponsableFechaResuelve, n176TicketResponsableHoraResuelve, A176TicketResponsableHoraResuelve, n177TicketResponsableRamTxt, A177TicketResponsableRamTxt, n178TicketResponsableDiscoDuroTxt, A178TicketResponsableDiscoDuroTxt, n179TicketResponsableProcesadorTxt, A179TicketResponsableProcesadorTxt, n180TicketResponsableMaletinTxt, A180TicketResponsableMaletinTxt, n181TicketResponsableTonerCintaTxt, A181TicketResponsableTonerCintaTxt, n182TicketResponsableTarjetaVideoExtraTxt, A182TicketResponsableTarjetaVideoExtraTxt, n183TicketResponsableCargadorLaptopTxt, A183TicketResponsableCargadorLaptopTxt, n184TicketResponsableCDsDVDsTxt, A184TicketResponsableCDsDVDsTxt, n185TicketResponsableCableEspecialTxt, A185TicketResponsableCableEspecialTxt, n186TicketResponsableOtrosTallerTxt, A186TicketResponsableOtrosTallerTxt, n287TicketResponsableFechaHoraAsigna, A287TicketResponsableFechaHoraAsigna, n288TicketResponsableFechaHoraResuelve, A288TicketResponsableFechaHoraResuelve, n290EtapaDesarrolloId, A290EtapaDesarrolloId, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId});
                     pr_default.close(27);
                     dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         if ( ! IsAuthorized("ticket_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( ( nIsMod_8 != 0 ) || ( nIsDirty_8 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency078( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm078( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate078( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000730 */
                        pr_default.execute(28, new Object[] {A49TicketHoraResponsable, A47TicketFechaResponsable, n145TicketResponsableInventarioSerie, A145TicketResponsableInventarioSerie, n146TicketResponsableInstalacion, A146TicketResponsableInstalacion, n147TicketResponsableConfiguracion, A147TicketResponsableConfiguracion, n148TicketResponsableInternetRouter, A148TicketResponsableInternetRouter, n149TicketResponsableFormateo, A149TicketResponsableFormateo, n150TicketResponsableReparacion, A150TicketResponsableReparacion, n151TicketResponsableLimpieza, A151TicketResponsableLimpieza, n152TicketResponsablePuntoRed, A152TicketResponsablePuntoRed, n153TicketResponsableCambiosHardware, A153TicketResponsableCambiosHardware, n154TicketResponsableCopiasRespaldo, A154TicketResponsableCopiasRespaldo, n165TicketResponsableCerrado, A165TicketResponsableCerrado, n166TicketResponsablePendiente, A166TicketResponsablePendiente, n167TicketResponsablePasaTaller, A167TicketResponsablePasaTaller, n168TicketResponsableObservacion, A168TicketResponsableObservacion, n175TicketResponsableFechaResuelve, A175TicketResponsableFechaResuelve, n176TicketResponsableHoraResuelve, A176TicketResponsableHoraResuelve, n177TicketResponsableRamTxt, A177TicketResponsableRamTxt, n178TicketResponsableDiscoDuroTxt, A178TicketResponsableDiscoDuroTxt, n179TicketResponsableProcesadorTxt, A179TicketResponsableProcesadorTxt, n180TicketResponsableMaletinTxt, A180TicketResponsableMaletinTxt, n181TicketResponsableTonerCintaTxt, A181TicketResponsableTonerCintaTxt, n182TicketResponsableTarjetaVideoExtraTxt, A182TicketResponsableTarjetaVideoExtraTxt, n183TicketResponsableCargadorLaptopTxt, A183TicketResponsableCargadorLaptopTxt, n184TicketResponsableCDsDVDsTxt, A184TicketResponsableCDsDVDsTxt, n185TicketResponsableCableEspecialTxt, A185TicketResponsableCableEspecialTxt, n186TicketResponsableOtrosTallerTxt, A186TicketResponsableOtrosTallerTxt, n287TicketResponsableFechaHoraAsigna, A287TicketResponsableFechaHoraAsigna, n288TicketResponsableFechaHoraResuelve, A288TicketResponsableFechaHoraResuelve, n290EtapaDesarrolloId, A290EtapaDesarrolloId, A17EstadoTicketTecnicoId, A198TicketTecnicoResponsableId, A14TicketId, A16TicketResponsableId});
                        pr_default.close(28);
                        dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
                        if ( (pr_default.getStatus(28) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TicketResponsable"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate078( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey078( ) ;
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
               EndLevel078( ) ;
            }
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void Delete078( )
      {
         if ( ! IsAuthorized("ticket_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000731 */
                  pr_default.execute(29, new Object[] {A14TicketId, A16TicketResponsableId});
                  pr_default.close(29);
                  dsDefault.SmartCacheProvider.SetUpdated("TicketResponsable");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel078( ) ;
         Gx_mode = sMode8;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal078( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000732 */
            pr_default.execute(30, new Object[] {A198TicketTecnicoResponsableId});
            A199TicketTecnicoResponsableNombre = T000732_A199TicketTecnicoResponsableNombre[0];
            pr_default.close(30);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000733 */
            pr_default.execute(31, new Object[] {A14TicketId, A16TicketResponsableId});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ticket Tecnico"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T000734 */
            pr_default.execute(32, new Object[] {A14TicketId, A16TicketResponsableId});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Satisfaccion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
         }
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart078( )
      {
         /* Scan By routine */
         /* Using cursor T000735 */
         pr_default.execute(33, new Object[] {A14TicketId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound8 = 1;
            A16TicketResponsableId = T000735_A16TicketResponsableId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(33);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(33) != 101) )
         {
            RcdFound8 = 1;
            A16TicketResponsableId = T000735_A16TicketResponsableId[0];
         }
      }

      protected void ScanEnd078( )
      {
         pr_default.close(33);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
         edtTicketResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketTecnicoResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketTecnicoResponsableNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketFechaResponsable_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketFechaResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketHoraResponsable_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketHoraResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtEstadoTicketTecnicoId_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtEstadoTicketTecnicoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtEstadoTicketTecnicoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0), !bGXsfl_242_Refreshing);
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void SubsflControlProps_2428( )
      {
         edtTicketResponsableId_Internalname = sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_idx;
         edtTicketTecnicoResponsableId_Internalname = sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx;
         imgprompt_198_Internalname = sPrefix+"PROMPT_198_"+sGXsfl_242_idx;
         edtTicketTecnicoResponsableNombre_Internalname = sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_idx;
         edtTicketFechaResponsable_Internalname = sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_idx;
         edtTicketHoraResponsable_Internalname = sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_idx;
         edtEstadoTicketTecnicoId_Internalname = sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_idx;
         edtEstadoTicketTecnicoNombre_Internalname = sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_idx;
      }

      protected void SubsflControlProps_fel_2428( )
      {
         edtTicketResponsableId_Internalname = sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_fel_idx;
         edtTicketTecnicoResponsableId_Internalname = sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_fel_idx;
         imgprompt_198_Internalname = sPrefix+"PROMPT_198_"+sGXsfl_242_fel_idx;
         edtTicketTecnicoResponsableNombre_Internalname = sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_fel_idx;
         edtTicketFechaResponsable_Internalname = sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_fel_idx;
         edtTicketHoraResponsable_Internalname = sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_fel_idx;
         edtEstadoTicketTecnicoId_Internalname = sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_fel_idx;
         edtEstadoTicketTecnicoNombre_Internalname = sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_fel_idx;
      }

      protected void AddRow078( )
      {
         nGXsfl_242_idx = (int)(nGXsfl_242_idx+1);
         sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx), 4, 0), 4, "0");
         SubsflControlProps_2428( ) ;
         SendRow078( ) ;
      }

      protected void SendRow078( )
      {
         GridresponsableRow = GXWebRow.GetNew(context);
         if ( subGridresponsable_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridresponsable_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridresponsable_Class, "") != 0 )
            {
               subGridresponsable_Linesclass = subGridresponsable_Class+"Odd";
            }
         }
         else if ( subGridresponsable_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridresponsable_Backstyle = 0;
            subGridresponsable_Backcolor = subGridresponsable_Allbackcolor;
            if ( StringUtil.StrCmp(subGridresponsable_Class, "") != 0 )
            {
               subGridresponsable_Linesclass = subGridresponsable_Class+"Uniform";
            }
         }
         else if ( subGridresponsable_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridresponsable_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridresponsable_Class, "") != 0 )
            {
               subGridresponsable_Linesclass = subGridresponsable_Class+"Odd";
            }
            subGridresponsable_Backcolor = (int)(0x0);
         }
         else if ( subGridresponsable_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridresponsable_Backstyle = 1;
            if ( ((int)((nGXsfl_242_idx) % (2))) == 0 )
            {
               subGridresponsable_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridresponsable_Class, "") != 0 )
               {
                  subGridresponsable_Linesclass = subGridresponsable_Class+"Even";
               }
            }
            else
            {
               subGridresponsable_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridresponsable_Class, "") != 0 )
               {
                  subGridresponsable_Linesclass = subGridresponsable_Class+"Odd";
               }
            }
         }
         imgprompt_198_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptresponsable.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"'), id:'"+sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+sPrefix+"nIsMod_8_"+sGXsfl_242_idx+","+"'"+sPrefix+"', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_242_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 243,'" + sPrefix + "',false,'" + sGXsfl_242_idx + "',242)\"";
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,243);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtTicketResponsableId_Enabled,(short)1,(string)"number",(string)"1",(short)80,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_242_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 244,'" + sPrefix + "',false,'" + sGXsfl_242_idx + "',242)\"";
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ",", "")),((edtTicketTecnicoResponsableId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")) : context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9")),TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,244);\"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtTicketTecnicoResponsableId_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GridresponsableRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_198_Internalname,(string)sImgUrl,(string)imgprompt_198_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_198_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketTecnicoResponsableNombre_Internalname,(string)A199TicketTecnicoResponsableNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketTecnicoResponsableNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtTicketTecnicoResponsableNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)-1,(bool)true,(string)"Nombres",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketFechaResponsable_Internalname,context.localUtil.Format(A47TicketFechaResponsable, "99/99/9999"),context.localUtil.Format( A47TicketFechaResponsable, "99/99/9999"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketFechaResponsable_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtTicketFechaResponsable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)0,(bool)true,(string)"Fecha",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTicketHoraResponsable_Internalname,context.localUtil.TToC( A49TicketHoraResponsable, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( A49TicketHoraResponsable, "99:99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTicketHoraResponsable_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtTicketHoraResponsable_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)5,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)0,(bool)true,(string)"Hora",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketTecnicoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EstadoTicketTecnicoId), 4, 0, ",", "")),((edtEstadoTicketTecnicoId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A17EstadoTicketTecnicoId), "ZZZ9")) : context.localUtil.Format( (decimal)(A17EstadoTicketTecnicoId), "ZZZ9")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketTecnicoId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtEstadoTicketTecnicoId_Enabled,(short)0,(string)"number",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)0,(bool)true,(string)"NumMin",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute_Grid";
         GridresponsableRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtEstadoTicketTecnicoNombre_Internalname,(string)A25EstadoTicketTecnicoNombre,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtEstadoTicketTecnicoNombre_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)0,(int)edtEstadoTicketTecnicoNombre_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)242,(short)1,(short)-1,(short)-1,(bool)true,(string)"Descripcion",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(GridresponsableRow);
         send_integrity_lvl_hashes078( ) ;
         GXCCtl = "Z16TicketResponsableId_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16TicketResponsableId), 10, 0, ",", "")));
         GXCCtl = "Z49TicketHoraResponsable_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.TToC( Z49TicketHoraResponsable, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z47TicketFechaResponsable_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.DToC( Z47TicketFechaResponsable, 0, "/"));
         GXCCtl = "Z145TicketResponsableInventarioSerie_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z145TicketResponsableInventarioSerie);
         GXCCtl = "Z146TicketResponsableInstalacion_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z146TicketResponsableInstalacion);
         GXCCtl = "Z147TicketResponsableConfiguracion_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z147TicketResponsableConfiguracion);
         GXCCtl = "Z148TicketResponsableInternetRouter_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z148TicketResponsableInternetRouter);
         GXCCtl = "Z149TicketResponsableFormateo_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z149TicketResponsableFormateo);
         GXCCtl = "Z150TicketResponsableReparacion_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z150TicketResponsableReparacion);
         GXCCtl = "Z151TicketResponsableLimpieza_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z151TicketResponsableLimpieza);
         GXCCtl = "Z152TicketResponsablePuntoRed_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z152TicketResponsablePuntoRed);
         GXCCtl = "Z153TicketResponsableCambiosHardware_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z153TicketResponsableCambiosHardware);
         GXCCtl = "Z154TicketResponsableCopiasRespaldo_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z154TicketResponsableCopiasRespaldo);
         GXCCtl = "Z165TicketResponsableCerrado_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z165TicketResponsableCerrado);
         GXCCtl = "Z166TicketResponsablePendiente_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z166TicketResponsablePendiente);
         GXCCtl = "Z167TicketResponsablePasaTaller_" + sGXsfl_242_idx;
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+GXCCtl, Z167TicketResponsablePasaTaller);
         GXCCtl = "Z168TicketResponsableObservacion_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z168TicketResponsableObservacion);
         GXCCtl = "Z175TicketResponsableFechaResuelve_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.DToC( Z175TicketResponsableFechaResuelve, 0, "/"));
         GXCCtl = "Z176TicketResponsableHoraResuelve_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.TToC( Z176TicketResponsableHoraResuelve, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z177TicketResponsableRamTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z177TicketResponsableRamTxt);
         GXCCtl = "Z178TicketResponsableDiscoDuroTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z178TicketResponsableDiscoDuroTxt);
         GXCCtl = "Z179TicketResponsableProcesadorTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z179TicketResponsableProcesadorTxt);
         GXCCtl = "Z180TicketResponsableMaletinTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z180TicketResponsableMaletinTxt);
         GXCCtl = "Z181TicketResponsableTonerCintaTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z181TicketResponsableTonerCintaTxt);
         GXCCtl = "Z182TicketResponsableTarjetaVideoExtraTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z182TicketResponsableTarjetaVideoExtraTxt);
         GXCCtl = "Z183TicketResponsableCargadorLaptopTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z183TicketResponsableCargadorLaptopTxt);
         GXCCtl = "Z184TicketResponsableCDsDVDsTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z184TicketResponsableCDsDVDsTxt);
         GXCCtl = "Z185TicketResponsableCableEspecialTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z185TicketResponsableCableEspecialTxt);
         GXCCtl = "Z186TicketResponsableOtrosTallerTxt_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, Z186TicketResponsableOtrosTallerTxt);
         GXCCtl = "Z287TicketResponsableFechaHoraAsigna_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.TToC( Z287TicketResponsableFechaHoraAsigna, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z288TicketResponsableFechaHoraResuelve_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, context.localUtil.TToC( Z288TicketResponsableFechaHoraResuelve, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z290EtapaDesarrolloId_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z290EtapaDesarrolloId), 4, 0, ",", "")));
         GXCCtl = "Z17EstadoTicketTecnicoId_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EstadoTicketTecnicoId), 4, 0, ",", "")));
         GXCCtl = "Z198TicketTecnicoResponsableId_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z198TicketTecnicoResponsableId), 4, 0, ",", "")));
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_8_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ",", "")));
         GXCCtl = "nIsMod_8_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ",", "")));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_242_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+GXCCtl, AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+GXCCtl, AV8TrnContext);
         }
         GXCCtl = "vMODE_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vATTRIBUTEVALUE_" + sGXsfl_242_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+GXCCtl, AV21AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+GXCCtl, AV21AttributeValue);
         }
         GXCCtl = "vNAVIGATION_" + sGXsfl_242_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+GXCCtl, AV10Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+GXCCtl, AV10Navigation);
         }
         GXCCtl = "vTICKETID_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TicketId), 10, 0, ",", "")));
         GXCCtl = "ETAPADESARROLLONOMBRE_" + sGXsfl_242_idx;
         GxWebStd.gx_hidden_field( context, sPrefix+GXCCtl, A291EtapaDesarrolloNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketResponsableId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"PROMPT_198_"+sGXsfl_242_idx+"Link", StringUtil.RTrim( imgprompt_198_Link));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         GridresponsableContainer.AddRow(GridresponsableRow);
      }

      protected void ReadRow078( )
      {
         nGXsfl_242_idx = (int)(nGXsfl_242_idx+1);
         sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx), 4, 0), 4, "0");
         SubsflControlProps_2428( ) ;
         edtTicketResponsableId_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETRESPONSABLEID_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         edtTicketTecnicoResponsableId_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETTECNICORESPONSABLEID_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         edtTicketTecnicoResponsableNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETTECNICORESPONSABLENOMBRE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         edtTicketFechaResponsable_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETFECHARESPONSABLE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         edtTicketHoraResponsable_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"TICKETHORARESPONSABLE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         edtEstadoTicketTecnicoId_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"ESTADOTICKETTECNICOID_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         edtEstadoTicketTecnicoNombre_Enabled = (int)(context.localUtil.CToN( cgiGet( sPrefix+"ESTADOTICKETTECNICONOMBRE_"+sGXsfl_242_idx+"Enabled"), ",", "."));
         imgprompt_15_Link = cgiGet( sPrefix+"PROMPT_198_"+sGXsfl_242_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
         {
            GXCCtl = "TICKETRESPONSABLEID_" + sGXsfl_242_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTicketResponsableId_Internalname;
            wbErr = true;
            A16TicketResponsableId = 0;
         }
         else
         {
            A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ",", "."));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "TICKETTECNICORESPONSABLEID_" + sGXsfl_242_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTicketTecnicoResponsableId_Internalname;
            wbErr = true;
            A198TicketTecnicoResponsableId = 0;
         }
         else
         {
            A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ",", "."));
         }
         A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
         A47TicketFechaResponsable = context.localUtil.CToD( cgiGet( edtTicketFechaResponsable_Internalname), 2);
         A49TicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTicketHoraResponsable_Internalname)));
         A17EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( edtEstadoTicketTecnicoId_Internalname), ",", "."));
         A25EstadoTicketTecnicoNombre = cgiGet( edtEstadoTicketTecnicoNombre_Internalname);
         GXCCtl = "Z16TicketResponsableId_" + sGXsfl_242_idx;
         Z16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         GXCCtl = "Z49TicketHoraResponsable_" + sGXsfl_242_idx;
         Z49TicketHoraResponsable = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0));
         GXCCtl = "Z47TicketFechaResponsable_" + sGXsfl_242_idx;
         Z47TicketFechaResponsable = context.localUtil.CToD( cgiGet( sPrefix+GXCCtl), 0);
         GXCCtl = "Z145TicketResponsableInventarioSerie_" + sGXsfl_242_idx;
         Z145TicketResponsableInventarioSerie = cgiGet( sPrefix+GXCCtl);
         n145TicketResponsableInventarioSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A145TicketResponsableInventarioSerie)) ? true : false);
         GXCCtl = "Z146TicketResponsableInstalacion_" + sGXsfl_242_idx;
         Z146TicketResponsableInstalacion = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n146TicketResponsableInstalacion = ((false==A146TicketResponsableInstalacion) ? true : false);
         GXCCtl = "Z147TicketResponsableConfiguracion_" + sGXsfl_242_idx;
         Z147TicketResponsableConfiguracion = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n147TicketResponsableConfiguracion = ((false==A147TicketResponsableConfiguracion) ? true : false);
         GXCCtl = "Z148TicketResponsableInternetRouter_" + sGXsfl_242_idx;
         Z148TicketResponsableInternetRouter = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n148TicketResponsableInternetRouter = ((false==A148TicketResponsableInternetRouter) ? true : false);
         GXCCtl = "Z149TicketResponsableFormateo_" + sGXsfl_242_idx;
         Z149TicketResponsableFormateo = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n149TicketResponsableFormateo = ((false==A149TicketResponsableFormateo) ? true : false);
         GXCCtl = "Z150TicketResponsableReparacion_" + sGXsfl_242_idx;
         Z150TicketResponsableReparacion = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n150TicketResponsableReparacion = ((false==A150TicketResponsableReparacion) ? true : false);
         GXCCtl = "Z151TicketResponsableLimpieza_" + sGXsfl_242_idx;
         Z151TicketResponsableLimpieza = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n151TicketResponsableLimpieza = ((false==A151TicketResponsableLimpieza) ? true : false);
         GXCCtl = "Z152TicketResponsablePuntoRed_" + sGXsfl_242_idx;
         Z152TicketResponsablePuntoRed = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n152TicketResponsablePuntoRed = ((false==A152TicketResponsablePuntoRed) ? true : false);
         GXCCtl = "Z153TicketResponsableCambiosHardware_" + sGXsfl_242_idx;
         Z153TicketResponsableCambiosHardware = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n153TicketResponsableCambiosHardware = ((false==A153TicketResponsableCambiosHardware) ? true : false);
         GXCCtl = "Z154TicketResponsableCopiasRespaldo_" + sGXsfl_242_idx;
         Z154TicketResponsableCopiasRespaldo = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n154TicketResponsableCopiasRespaldo = ((false==A154TicketResponsableCopiasRespaldo) ? true : false);
         GXCCtl = "Z165TicketResponsableCerrado_" + sGXsfl_242_idx;
         Z165TicketResponsableCerrado = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n165TicketResponsableCerrado = ((false==A165TicketResponsableCerrado) ? true : false);
         GXCCtl = "Z166TicketResponsablePendiente_" + sGXsfl_242_idx;
         Z166TicketResponsablePendiente = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n166TicketResponsablePendiente = ((false==A166TicketResponsablePendiente) ? true : false);
         GXCCtl = "Z167TicketResponsablePasaTaller_" + sGXsfl_242_idx;
         Z167TicketResponsablePasaTaller = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n167TicketResponsablePasaTaller = ((false==A167TicketResponsablePasaTaller) ? true : false);
         GXCCtl = "Z168TicketResponsableObservacion_" + sGXsfl_242_idx;
         Z168TicketResponsableObservacion = cgiGet( sPrefix+GXCCtl);
         n168TicketResponsableObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A168TicketResponsableObservacion)) ? true : false);
         GXCCtl = "Z175TicketResponsableFechaResuelve_" + sGXsfl_242_idx;
         Z175TicketResponsableFechaResuelve = context.localUtil.CToD( cgiGet( sPrefix+GXCCtl), 0);
         n175TicketResponsableFechaResuelve = ((DateTime.MinValue==A175TicketResponsableFechaResuelve) ? true : false);
         GXCCtl = "Z176TicketResponsableHoraResuelve_" + sGXsfl_242_idx;
         Z176TicketResponsableHoraResuelve = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0));
         n176TicketResponsableHoraResuelve = ((DateTime.MinValue==A176TicketResponsableHoraResuelve) ? true : false);
         GXCCtl = "Z177TicketResponsableRamTxt_" + sGXsfl_242_idx;
         Z177TicketResponsableRamTxt = cgiGet( sPrefix+GXCCtl);
         n177TicketResponsableRamTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A177TicketResponsableRamTxt)) ? true : false);
         GXCCtl = "Z178TicketResponsableDiscoDuroTxt_" + sGXsfl_242_idx;
         Z178TicketResponsableDiscoDuroTxt = cgiGet( sPrefix+GXCCtl);
         n178TicketResponsableDiscoDuroTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A178TicketResponsableDiscoDuroTxt)) ? true : false);
         GXCCtl = "Z179TicketResponsableProcesadorTxt_" + sGXsfl_242_idx;
         Z179TicketResponsableProcesadorTxt = cgiGet( sPrefix+GXCCtl);
         n179TicketResponsableProcesadorTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A179TicketResponsableProcesadorTxt)) ? true : false);
         GXCCtl = "Z180TicketResponsableMaletinTxt_" + sGXsfl_242_idx;
         Z180TicketResponsableMaletinTxt = cgiGet( sPrefix+GXCCtl);
         n180TicketResponsableMaletinTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A180TicketResponsableMaletinTxt)) ? true : false);
         GXCCtl = "Z181TicketResponsableTonerCintaTxt_" + sGXsfl_242_idx;
         Z181TicketResponsableTonerCintaTxt = cgiGet( sPrefix+GXCCtl);
         n181TicketResponsableTonerCintaTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A181TicketResponsableTonerCintaTxt)) ? true : false);
         GXCCtl = "Z182TicketResponsableTarjetaVideoExtraTxt_" + sGXsfl_242_idx;
         Z182TicketResponsableTarjetaVideoExtraTxt = cgiGet( sPrefix+GXCCtl);
         n182TicketResponsableTarjetaVideoExtraTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A182TicketResponsableTarjetaVideoExtraTxt)) ? true : false);
         GXCCtl = "Z183TicketResponsableCargadorLaptopTxt_" + sGXsfl_242_idx;
         Z183TicketResponsableCargadorLaptopTxt = cgiGet( sPrefix+GXCCtl);
         n183TicketResponsableCargadorLaptopTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A183TicketResponsableCargadorLaptopTxt)) ? true : false);
         GXCCtl = "Z184TicketResponsableCDsDVDsTxt_" + sGXsfl_242_idx;
         Z184TicketResponsableCDsDVDsTxt = cgiGet( sPrefix+GXCCtl);
         n184TicketResponsableCDsDVDsTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A184TicketResponsableCDsDVDsTxt)) ? true : false);
         GXCCtl = "Z185TicketResponsableCableEspecialTxt_" + sGXsfl_242_idx;
         Z185TicketResponsableCableEspecialTxt = cgiGet( sPrefix+GXCCtl);
         n185TicketResponsableCableEspecialTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A185TicketResponsableCableEspecialTxt)) ? true : false);
         GXCCtl = "Z186TicketResponsableOtrosTallerTxt_" + sGXsfl_242_idx;
         Z186TicketResponsableOtrosTallerTxt = cgiGet( sPrefix+GXCCtl);
         n186TicketResponsableOtrosTallerTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A186TicketResponsableOtrosTallerTxt)) ? true : false);
         GXCCtl = "Z287TicketResponsableFechaHoraAsigna_" + sGXsfl_242_idx;
         Z287TicketResponsableFechaHoraAsigna = context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0);
         n287TicketResponsableFechaHoraAsigna = ((DateTime.MinValue==A287TicketResponsableFechaHoraAsigna) ? true : false);
         GXCCtl = "Z288TicketResponsableFechaHoraResuelve_" + sGXsfl_242_idx;
         Z288TicketResponsableFechaHoraResuelve = context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0);
         n288TicketResponsableFechaHoraResuelve = ((DateTime.MinValue==A288TicketResponsableFechaHoraResuelve) ? true : false);
         GXCCtl = "Z290EtapaDesarrolloId_" + sGXsfl_242_idx;
         Z290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         n290EtapaDesarrolloId = ((0==A290EtapaDesarrolloId) ? true : false);
         GXCCtl = "Z17EstadoTicketTecnicoId_" + sGXsfl_242_idx;
         Z17EstadoTicketTecnicoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         GXCCtl = "Z198TicketTecnicoResponsableId_" + sGXsfl_242_idx;
         Z198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         GXCCtl = "Z145TicketResponsableInventarioSerie_" + sGXsfl_242_idx;
         A145TicketResponsableInventarioSerie = cgiGet( sPrefix+GXCCtl);
         n145TicketResponsableInventarioSerie = false;
         n145TicketResponsableInventarioSerie = (String.IsNullOrEmpty(StringUtil.RTrim( A145TicketResponsableInventarioSerie)) ? true : false);
         GXCCtl = "Z146TicketResponsableInstalacion_" + sGXsfl_242_idx;
         A146TicketResponsableInstalacion = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n146TicketResponsableInstalacion = false;
         n146TicketResponsableInstalacion = ((false==A146TicketResponsableInstalacion) ? true : false);
         GXCCtl = "Z147TicketResponsableConfiguracion_" + sGXsfl_242_idx;
         A147TicketResponsableConfiguracion = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n147TicketResponsableConfiguracion = false;
         n147TicketResponsableConfiguracion = ((false==A147TicketResponsableConfiguracion) ? true : false);
         GXCCtl = "Z148TicketResponsableInternetRouter_" + sGXsfl_242_idx;
         A148TicketResponsableInternetRouter = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n148TicketResponsableInternetRouter = false;
         n148TicketResponsableInternetRouter = ((false==A148TicketResponsableInternetRouter) ? true : false);
         GXCCtl = "Z149TicketResponsableFormateo_" + sGXsfl_242_idx;
         A149TicketResponsableFormateo = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n149TicketResponsableFormateo = false;
         n149TicketResponsableFormateo = ((false==A149TicketResponsableFormateo) ? true : false);
         GXCCtl = "Z150TicketResponsableReparacion_" + sGXsfl_242_idx;
         A150TicketResponsableReparacion = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n150TicketResponsableReparacion = false;
         n150TicketResponsableReparacion = ((false==A150TicketResponsableReparacion) ? true : false);
         GXCCtl = "Z151TicketResponsableLimpieza_" + sGXsfl_242_idx;
         A151TicketResponsableLimpieza = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n151TicketResponsableLimpieza = false;
         n151TicketResponsableLimpieza = ((false==A151TicketResponsableLimpieza) ? true : false);
         GXCCtl = "Z152TicketResponsablePuntoRed_" + sGXsfl_242_idx;
         A152TicketResponsablePuntoRed = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n152TicketResponsablePuntoRed = false;
         n152TicketResponsablePuntoRed = ((false==A152TicketResponsablePuntoRed) ? true : false);
         GXCCtl = "Z153TicketResponsableCambiosHardware_" + sGXsfl_242_idx;
         A153TicketResponsableCambiosHardware = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n153TicketResponsableCambiosHardware = false;
         n153TicketResponsableCambiosHardware = ((false==A153TicketResponsableCambiosHardware) ? true : false);
         GXCCtl = "Z154TicketResponsableCopiasRespaldo_" + sGXsfl_242_idx;
         A154TicketResponsableCopiasRespaldo = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n154TicketResponsableCopiasRespaldo = false;
         n154TicketResponsableCopiasRespaldo = ((false==A154TicketResponsableCopiasRespaldo) ? true : false);
         GXCCtl = "Z165TicketResponsableCerrado_" + sGXsfl_242_idx;
         A165TicketResponsableCerrado = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n165TicketResponsableCerrado = false;
         n165TicketResponsableCerrado = ((false==A165TicketResponsableCerrado) ? true : false);
         GXCCtl = "Z166TicketResponsablePendiente_" + sGXsfl_242_idx;
         A166TicketResponsablePendiente = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n166TicketResponsablePendiente = false;
         n166TicketResponsablePendiente = ((false==A166TicketResponsablePendiente) ? true : false);
         GXCCtl = "Z167TicketResponsablePasaTaller_" + sGXsfl_242_idx;
         A167TicketResponsablePasaTaller = StringUtil.StrToBool( cgiGet( sPrefix+GXCCtl));
         n167TicketResponsablePasaTaller = false;
         n167TicketResponsablePasaTaller = ((false==A167TicketResponsablePasaTaller) ? true : false);
         GXCCtl = "Z168TicketResponsableObservacion_" + sGXsfl_242_idx;
         A168TicketResponsableObservacion = cgiGet( sPrefix+GXCCtl);
         n168TicketResponsableObservacion = false;
         n168TicketResponsableObservacion = (String.IsNullOrEmpty(StringUtil.RTrim( A168TicketResponsableObservacion)) ? true : false);
         GXCCtl = "Z175TicketResponsableFechaResuelve_" + sGXsfl_242_idx;
         A175TicketResponsableFechaResuelve = context.localUtil.CToD( cgiGet( sPrefix+GXCCtl), 0);
         n175TicketResponsableFechaResuelve = false;
         n175TicketResponsableFechaResuelve = ((DateTime.MinValue==A175TicketResponsableFechaResuelve) ? true : false);
         GXCCtl = "Z176TicketResponsableHoraResuelve_" + sGXsfl_242_idx;
         A176TicketResponsableHoraResuelve = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0));
         n176TicketResponsableHoraResuelve = false;
         n176TicketResponsableHoraResuelve = ((DateTime.MinValue==A176TicketResponsableHoraResuelve) ? true : false);
         GXCCtl = "Z177TicketResponsableRamTxt_" + sGXsfl_242_idx;
         A177TicketResponsableRamTxt = cgiGet( sPrefix+GXCCtl);
         n177TicketResponsableRamTxt = false;
         n177TicketResponsableRamTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A177TicketResponsableRamTxt)) ? true : false);
         GXCCtl = "Z178TicketResponsableDiscoDuroTxt_" + sGXsfl_242_idx;
         A178TicketResponsableDiscoDuroTxt = cgiGet( sPrefix+GXCCtl);
         n178TicketResponsableDiscoDuroTxt = false;
         n178TicketResponsableDiscoDuroTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A178TicketResponsableDiscoDuroTxt)) ? true : false);
         GXCCtl = "Z179TicketResponsableProcesadorTxt_" + sGXsfl_242_idx;
         A179TicketResponsableProcesadorTxt = cgiGet( sPrefix+GXCCtl);
         n179TicketResponsableProcesadorTxt = false;
         n179TicketResponsableProcesadorTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A179TicketResponsableProcesadorTxt)) ? true : false);
         GXCCtl = "Z180TicketResponsableMaletinTxt_" + sGXsfl_242_idx;
         A180TicketResponsableMaletinTxt = cgiGet( sPrefix+GXCCtl);
         n180TicketResponsableMaletinTxt = false;
         n180TicketResponsableMaletinTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A180TicketResponsableMaletinTxt)) ? true : false);
         GXCCtl = "Z181TicketResponsableTonerCintaTxt_" + sGXsfl_242_idx;
         A181TicketResponsableTonerCintaTxt = cgiGet( sPrefix+GXCCtl);
         n181TicketResponsableTonerCintaTxt = false;
         n181TicketResponsableTonerCintaTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A181TicketResponsableTonerCintaTxt)) ? true : false);
         GXCCtl = "Z182TicketResponsableTarjetaVideoExtraTxt_" + sGXsfl_242_idx;
         A182TicketResponsableTarjetaVideoExtraTxt = cgiGet( sPrefix+GXCCtl);
         n182TicketResponsableTarjetaVideoExtraTxt = false;
         n182TicketResponsableTarjetaVideoExtraTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A182TicketResponsableTarjetaVideoExtraTxt)) ? true : false);
         GXCCtl = "Z183TicketResponsableCargadorLaptopTxt_" + sGXsfl_242_idx;
         A183TicketResponsableCargadorLaptopTxt = cgiGet( sPrefix+GXCCtl);
         n183TicketResponsableCargadorLaptopTxt = false;
         n183TicketResponsableCargadorLaptopTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A183TicketResponsableCargadorLaptopTxt)) ? true : false);
         GXCCtl = "Z184TicketResponsableCDsDVDsTxt_" + sGXsfl_242_idx;
         A184TicketResponsableCDsDVDsTxt = cgiGet( sPrefix+GXCCtl);
         n184TicketResponsableCDsDVDsTxt = false;
         n184TicketResponsableCDsDVDsTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A184TicketResponsableCDsDVDsTxt)) ? true : false);
         GXCCtl = "Z185TicketResponsableCableEspecialTxt_" + sGXsfl_242_idx;
         A185TicketResponsableCableEspecialTxt = cgiGet( sPrefix+GXCCtl);
         n185TicketResponsableCableEspecialTxt = false;
         n185TicketResponsableCableEspecialTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A185TicketResponsableCableEspecialTxt)) ? true : false);
         GXCCtl = "Z186TicketResponsableOtrosTallerTxt_" + sGXsfl_242_idx;
         A186TicketResponsableOtrosTallerTxt = cgiGet( sPrefix+GXCCtl);
         n186TicketResponsableOtrosTallerTxt = false;
         n186TicketResponsableOtrosTallerTxt = (String.IsNullOrEmpty(StringUtil.RTrim( A186TicketResponsableOtrosTallerTxt)) ? true : false);
         GXCCtl = "Z287TicketResponsableFechaHoraAsigna_" + sGXsfl_242_idx;
         A287TicketResponsableFechaHoraAsigna = context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0);
         n287TicketResponsableFechaHoraAsigna = false;
         n287TicketResponsableFechaHoraAsigna = ((DateTime.MinValue==A287TicketResponsableFechaHoraAsigna) ? true : false);
         GXCCtl = "Z288TicketResponsableFechaHoraResuelve_" + sGXsfl_242_idx;
         A288TicketResponsableFechaHoraResuelve = context.localUtil.CToT( cgiGet( sPrefix+GXCCtl), 0);
         n288TicketResponsableFechaHoraResuelve = false;
         n288TicketResponsableFechaHoraResuelve = ((DateTime.MinValue==A288TicketResponsableFechaHoraResuelve) ? true : false);
         GXCCtl = "Z290EtapaDesarrolloId_" + sGXsfl_242_idx;
         A290EtapaDesarrolloId = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         n290EtapaDesarrolloId = false;
         n290EtapaDesarrolloId = ((0==A290EtapaDesarrolloId) ? true : false);
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_242_idx;
         nRcdDeleted_8 = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         GXCCtl = "nRcdExists_8_" + sGXsfl_242_idx;
         nRcdExists_8 = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         GXCCtl = "nIsMod_8_" + sGXsfl_242_idx;
         nIsMod_8 = (short)(context.localUtil.CToN( cgiGet( sPrefix+GXCCtl), ",", "."));
         GXCCtl = "ETAPADESARROLLONOMBRE_" + sGXsfl_242_idx;
         A291EtapaDesarrolloNombre = cgiGet( sPrefix+GXCCtl);
      }

      protected void assign_properties_default( )
      {
         defedtEstadoTicketTecnicoNombre_Enabled = edtEstadoTicketTecnicoNombre_Enabled;
         defedtEstadoTicketTecnicoId_Enabled = edtEstadoTicketTecnicoId_Enabled;
         defedtTicketHoraResponsable_Enabled = edtTicketHoraResponsable_Enabled;
         defedtTicketFechaResponsable_Enabled = edtTicketFechaResponsable_Enabled;
         defedtTicketResponsableId_Enabled = edtTicketResponsableId_Enabled;
      }

      protected void ConfirmValues070( )
      {
         nGXsfl_242_idx = 0;
         sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx), 4, 0), 4, "0");
         SubsflControlProps_2428( ) ;
         while ( nGXsfl_242_idx < nRC_GXsfl_242 )
         {
            nGXsfl_242_idx = (int)(nGXsfl_242_idx+1);
            sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx), 4, 0), 4, "0");
            SubsflControlProps_2428( ) ;
            ChangePostValue( sPrefix+"Z16TicketResponsableId_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z16TicketResponsableId_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z16TicketResponsableId_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z49TicketHoraResponsable_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z49TicketHoraResponsable_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z49TicketHoraResponsable_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z47TicketFechaResponsable_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z47TicketFechaResponsable_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z47TicketFechaResponsable_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z145TicketResponsableInventarioSerie_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z145TicketResponsableInventarioSerie_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z145TicketResponsableInventarioSerie_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z146TicketResponsableInstalacion_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z146TicketResponsableInstalacion_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z146TicketResponsableInstalacion_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z147TicketResponsableConfiguracion_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z147TicketResponsableConfiguracion_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z147TicketResponsableConfiguracion_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z148TicketResponsableInternetRouter_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z148TicketResponsableInternetRouter_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z148TicketResponsableInternetRouter_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z149TicketResponsableFormateo_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z149TicketResponsableFormateo_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z149TicketResponsableFormateo_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z150TicketResponsableReparacion_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z150TicketResponsableReparacion_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z150TicketResponsableReparacion_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z151TicketResponsableLimpieza_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z151TicketResponsableLimpieza_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z151TicketResponsableLimpieza_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z152TicketResponsablePuntoRed_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z152TicketResponsablePuntoRed_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z152TicketResponsablePuntoRed_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z153TicketResponsableCambiosHardware_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z153TicketResponsableCambiosHardware_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z153TicketResponsableCambiosHardware_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z154TicketResponsableCopiasRespaldo_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z154TicketResponsableCopiasRespaldo_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z154TicketResponsableCopiasRespaldo_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z165TicketResponsableCerrado_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z165TicketResponsableCerrado_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z165TicketResponsableCerrado_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z166TicketResponsablePendiente_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z166TicketResponsablePendiente_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z166TicketResponsablePendiente_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z167TicketResponsablePasaTaller_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z167TicketResponsablePasaTaller_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z167TicketResponsablePasaTaller_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z168TicketResponsableObservacion_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z168TicketResponsableObservacion_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z168TicketResponsableObservacion_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z175TicketResponsableFechaResuelve_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z175TicketResponsableFechaResuelve_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z175TicketResponsableFechaResuelve_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z176TicketResponsableHoraResuelve_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z176TicketResponsableHoraResuelve_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z176TicketResponsableHoraResuelve_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z177TicketResponsableRamTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z177TicketResponsableRamTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z177TicketResponsableRamTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z178TicketResponsableDiscoDuroTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z178TicketResponsableDiscoDuroTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z178TicketResponsableDiscoDuroTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z179TicketResponsableProcesadorTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z179TicketResponsableProcesadorTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z179TicketResponsableProcesadorTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z180TicketResponsableMaletinTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z180TicketResponsableMaletinTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z180TicketResponsableMaletinTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z181TicketResponsableTonerCintaTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z181TicketResponsableTonerCintaTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z181TicketResponsableTonerCintaTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z182TicketResponsableTarjetaVideoExtraTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z182TicketResponsableTarjetaVideoExtraTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z182TicketResponsableTarjetaVideoExtraTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z183TicketResponsableCargadorLaptopTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z183TicketResponsableCargadorLaptopTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z183TicketResponsableCargadorLaptopTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z184TicketResponsableCDsDVDsTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z184TicketResponsableCDsDVDsTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z184TicketResponsableCDsDVDsTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z185TicketResponsableCableEspecialTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z185TicketResponsableCableEspecialTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z185TicketResponsableCableEspecialTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z186TicketResponsableOtrosTallerTxt_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z186TicketResponsableOtrosTallerTxt_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z186TicketResponsableOtrosTallerTxt_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z287TicketResponsableFechaHoraAsigna_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z287TicketResponsableFechaHoraAsigna_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z287TicketResponsableFechaHoraAsigna_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z288TicketResponsableFechaHoraResuelve_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z288TicketResponsableFechaHoraResuelve_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z288TicketResponsableFechaHoraResuelve_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z290EtapaDesarrolloId_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z290EtapaDesarrolloId_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z290EtapaDesarrolloId_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z17EstadoTicketTecnicoId_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z17EstadoTicketTecnicoId_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z17EstadoTicketTecnicoId_"+sGXsfl_242_idx) ;
            ChangePostValue( sPrefix+"Z198TicketTecnicoResponsableId_"+sGXsfl_242_idx, cgiGet( sPrefix+"ZT_"+"Z198TicketTecnicoResponsableId_"+sGXsfl_242_idx)) ;
            DeletePostValue( sPrefix+"ZT_"+"Z198TicketTecnicoResponsableId_"+sGXsfl_242_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?20231249503339", false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("ticket.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7TicketId,10,0))}, new string[] {"Gx_mode","TicketId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Ticket");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("TicketHoraCaracter", StringUtil.RTrim( context.localUtil.Format( A285TicketHoraCaracter, "")));
         forbiddenHiddens.Add("TicketFechaHora", context.localUtil.Format( A289TicketFechaHora, "99/99/9999 99:99:99"));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("ticket:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z46TicketFecha", context.localUtil.DToC( Z46TicketFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z48TicketHora", context.localUtil.TToC( Z48TicketHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z54TicketLastId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54TicketLastId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z285TicketHoraCaracter", StringUtil.RTrim( Z285TicketHoraCaracter));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z53TicketLaptop", Z53TicketLaptop);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z42TicketDesktop", Z42TicketDesktop);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z55TicketMonitor", Z55TicketMonitor);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z50TicketImpresora", Z50TicketImpresora);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z45TicketEscaner", Z45TicketEscaner);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z59TicketRouter", Z59TicketRouter);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z60TicketSistemaOperativo", Z60TicketSistemaOperativo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z56TicketOffice", Z56TicketOffice);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z39TicketAntivirus", Z39TicketAntivirus);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z40TicketAplicacion", Z40TicketAplicacion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z44TicketDisenio", Z44TicketDisenio);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z51TicketIngenieria", Z51TicketIngenieria);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z43TicketDiscoDuroExterno", Z43TicketDiscoDuroExterno);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z58TicketPerifericos", Z58TicketPerifericos);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z87TicketUps", Z87TicketUps);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z41TicketApoyoUsuario", Z41TicketApoyoUsuario);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z52TicketInstalarDataShow", Z52TicketInstalarDataShow);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"Z57TicketOtros", Z57TicketOtros);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z278TicketUsuarioAsigno", Z278TicketUsuarioAsigno);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z289TicketFechaHora", context.localUtil.TToC( Z289TicketFechaHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z15UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z187EstadoTicketTicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z187EstadoTicketTicketId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"O54TicketLastId", StringUtil.LTrim( StringUtil.NToC( (decimal)(O54TicketLastId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_242", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_242_idx), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N187EstadoTicketTicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A187EstadoTicketTicketId), 4, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"vTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TicketId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_USUARIOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_UsuarioId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_ESTADOTICKETTICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26Insert_EstadoTicketTicketId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETUSUARIOASIGNO", A278TicketUsuarioAsigno);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETHORACARACTER", StringUtil.RTrim( A285TicketHoraCaracter));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETFECHAHORA", context.localUtil.TToC( A289TicketFechaHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIOGERENCIA", A91UsuarioGerencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"USUARIODEPARTAMENTO", A88UsuarioDepartamento);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV30Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEINVENTARIOSERIE", A145TicketResponsableInventarioSerie);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEINSTALACION", A146TicketResponsableInstalacion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLECONFIGURACION", A147TicketResponsableConfiguracion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEINTERNETROUTER", A148TicketResponsableInternetRouter);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEFORMATEO", A149TicketResponsableFormateo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEREPARACION", A150TicketResponsableReparacion);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLELIMPIEZA", A151TicketResponsableLimpieza);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEPUNTORED", A152TicketResponsablePuntoRed);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLECAMBIOSHARDWARE", A153TicketResponsableCambiosHardware);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLECOPIASRESPALDO", A154TicketResponsableCopiasRespaldo);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLECERRADO", A165TicketResponsableCerrado);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEPENDIENTE", A166TicketResponsablePendiente);
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"TICKETRESPONSABLEPASATALLER", A167TicketResponsablePasaTaller);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEOBSERVACION", A168TicketResponsableObservacion);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEFECHARESUELVE", context.localUtil.DToC( A175TicketResponsableFechaResuelve, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEHORARESUELVE", context.localUtil.TToC( A176TicketResponsableHoraResuelve, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLERAMTXT", A177TicketResponsableRamTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEDISCODUROTXT", A178TicketResponsableDiscoDuroTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEPROCESADORTXT", A179TicketResponsableProcesadorTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEMALETINTXT", A180TicketResponsableMaletinTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLETONERCINTATXT", A181TicketResponsableTonerCintaTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLETARJETAVIDEOEXTRATXT", A182TicketResponsableTarjetaVideoExtraTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLECARGADORLAPTOPTXT", A183TicketResponsableCargadorLaptopTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLECDSDVDSTXT", A184TicketResponsableCDsDVDsTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLECABLEESPECIALTXT", A185TicketResponsableCableEspecialTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEOTROSTALLERTXT", A186TicketResponsableOtrosTallerTxt);
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEFECHAHORAASIGNA", context.localUtil.TToC( A287TicketResponsableFechaHoraAsigna, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"TICKETRESPONSABLEFECHAHORARESUELVE", context.localUtil.TToC( A288TicketResponsableFechaHoraResuelve, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"ETAPADESARROLLOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A290EtapaDesarrolloId), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"ETAPADESARROLLONOMBRE", A291EtapaDesarrolloNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm077( )
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
         return "Ticket" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ticket" ;
      }

      protected void InitializeNonKey077( )
      {
         A15UsuarioId = 0;
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 4, 0));
         A93UsuarioNombre = "";
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A94UsuarioRequerimiento = "";
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A91UsuarioGerencia = "";
         AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
         A88UsuarioDepartamento = "";
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         A188EstadoTicketTicketNombre = "";
         AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
         A54TicketLastId = 0;
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         A285TicketHoraCaracter = "";
         AssignAttri(sPrefix, false, "A285TicketHoraCaracter", A285TicketHoraCaracter);
         A53TicketLaptop = false;
         AssignAttri(sPrefix, false, "A53TicketLaptop", A53TicketLaptop);
         A42TicketDesktop = false;
         AssignAttri(sPrefix, false, "A42TicketDesktop", A42TicketDesktop);
         A55TicketMonitor = false;
         AssignAttri(sPrefix, false, "A55TicketMonitor", A55TicketMonitor);
         A50TicketImpresora = false;
         AssignAttri(sPrefix, false, "A50TicketImpresora", A50TicketImpresora);
         A45TicketEscaner = false;
         AssignAttri(sPrefix, false, "A45TicketEscaner", A45TicketEscaner);
         A59TicketRouter = false;
         AssignAttri(sPrefix, false, "A59TicketRouter", A59TicketRouter);
         A60TicketSistemaOperativo = false;
         AssignAttri(sPrefix, false, "A60TicketSistemaOperativo", A60TicketSistemaOperativo);
         A56TicketOffice = false;
         AssignAttri(sPrefix, false, "A56TicketOffice", A56TicketOffice);
         A39TicketAntivirus = false;
         AssignAttri(sPrefix, false, "A39TicketAntivirus", A39TicketAntivirus);
         A40TicketAplicacion = false;
         AssignAttri(sPrefix, false, "A40TicketAplicacion", A40TicketAplicacion);
         A44TicketDisenio = false;
         AssignAttri(sPrefix, false, "A44TicketDisenio", A44TicketDisenio);
         A51TicketIngenieria = false;
         AssignAttri(sPrefix, false, "A51TicketIngenieria", A51TicketIngenieria);
         A43TicketDiscoDuroExterno = false;
         AssignAttri(sPrefix, false, "A43TicketDiscoDuroExterno", A43TicketDiscoDuroExterno);
         A58TicketPerifericos = false;
         AssignAttri(sPrefix, false, "A58TicketPerifericos", A58TicketPerifericos);
         A87TicketUps = false;
         AssignAttri(sPrefix, false, "A87TicketUps", A87TicketUps);
         A41TicketApoyoUsuario = false;
         AssignAttri(sPrefix, false, "A41TicketApoyoUsuario", A41TicketApoyoUsuario);
         A52TicketInstalarDataShow = false;
         AssignAttri(sPrefix, false, "A52TicketInstalarDataShow", A52TicketInstalarDataShow);
         A57TicketOtros = false;
         AssignAttri(sPrefix, false, "A57TicketOtros", A57TicketOtros);
         A289TicketFechaHora = (DateTime)(DateTime.MinValue);
         n289TicketFechaHora = false;
         AssignAttri(sPrefix, false, "A289TicketFechaHora", context.localUtil.TToC( A289TicketFechaHora, 10, 8, 0, 3, "/", ":", " "));
         A187EstadoTicketTicketId = 3;
         AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
         A46TicketFecha = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
         A48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
         A278TicketUsuarioAsigno = AV28WebSession.Get("UsuarioConectado");
         AssignAttri(sPrefix, false, "A278TicketUsuarioAsigno", A278TicketUsuarioAsigno);
         O54TicketLastId = A54TicketLastId;
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         Z46TicketFecha = DateTime.MinValue;
         Z48TicketHora = (DateTime)(DateTime.MinValue);
         Z54TicketLastId = 0;
         Z285TicketHoraCaracter = "";
         Z53TicketLaptop = false;
         Z42TicketDesktop = false;
         Z55TicketMonitor = false;
         Z50TicketImpresora = false;
         Z45TicketEscaner = false;
         Z59TicketRouter = false;
         Z60TicketSistemaOperativo = false;
         Z56TicketOffice = false;
         Z39TicketAntivirus = false;
         Z40TicketAplicacion = false;
         Z44TicketDisenio = false;
         Z51TicketIngenieria = false;
         Z43TicketDiscoDuroExterno = false;
         Z58TicketPerifericos = false;
         Z87TicketUps = false;
         Z41TicketApoyoUsuario = false;
         Z52TicketInstalarDataShow = false;
         Z57TicketOtros = false;
         Z278TicketUsuarioAsigno = "";
         Z289TicketFechaHora = (DateTime)(DateTime.MinValue);
         Z15UsuarioId = 0;
         Z187EstadoTicketTicketId = 0;
      }

      protected void InitAll077( )
      {
         A14TicketId = 0;
         AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A187EstadoTicketTicketId = i187EstadoTicketTicketId;
         AssignAttri(sPrefix, false, "A187EstadoTicketTicketId", StringUtil.LTrimStr( (decimal)(A187EstadoTicketTicketId), 4, 0));
         A46TicketFecha = i46TicketFecha;
         AssignAttri(sPrefix, false, "A46TicketFecha", context.localUtil.Format(A46TicketFecha, "99/99/9999"));
         A48TicketHora = i48TicketHora;
         AssignAttri(sPrefix, false, "A48TicketHora", context.localUtil.TToC( A48TicketHora, 0, 5, 0, 3, "/", ":", " "));
         A278TicketUsuarioAsigno = i278TicketUsuarioAsigno;
         AssignAttri(sPrefix, false, "A278TicketUsuarioAsigno", A278TicketUsuarioAsigno);
      }

      protected void InitializeNonKey078( )
      {
         A198TicketTecnicoResponsableId = 0;
         A199TicketTecnicoResponsableNombre = "";
         A25EstadoTicketTecnicoNombre = "";
         A145TicketResponsableInventarioSerie = "";
         n145TicketResponsableInventarioSerie = false;
         AssignAttri(sPrefix, false, "A145TicketResponsableInventarioSerie", A145TicketResponsableInventarioSerie);
         A146TicketResponsableInstalacion = false;
         n146TicketResponsableInstalacion = false;
         AssignAttri(sPrefix, false, "A146TicketResponsableInstalacion", A146TicketResponsableInstalacion);
         A147TicketResponsableConfiguracion = false;
         n147TicketResponsableConfiguracion = false;
         AssignAttri(sPrefix, false, "A147TicketResponsableConfiguracion", A147TicketResponsableConfiguracion);
         A148TicketResponsableInternetRouter = false;
         n148TicketResponsableInternetRouter = false;
         AssignAttri(sPrefix, false, "A148TicketResponsableInternetRouter", A148TicketResponsableInternetRouter);
         A149TicketResponsableFormateo = false;
         n149TicketResponsableFormateo = false;
         AssignAttri(sPrefix, false, "A149TicketResponsableFormateo", A149TicketResponsableFormateo);
         A150TicketResponsableReparacion = false;
         n150TicketResponsableReparacion = false;
         AssignAttri(sPrefix, false, "A150TicketResponsableReparacion", A150TicketResponsableReparacion);
         A151TicketResponsableLimpieza = false;
         n151TicketResponsableLimpieza = false;
         AssignAttri(sPrefix, false, "A151TicketResponsableLimpieza", A151TicketResponsableLimpieza);
         A152TicketResponsablePuntoRed = false;
         n152TicketResponsablePuntoRed = false;
         AssignAttri(sPrefix, false, "A152TicketResponsablePuntoRed", A152TicketResponsablePuntoRed);
         A153TicketResponsableCambiosHardware = false;
         n153TicketResponsableCambiosHardware = false;
         AssignAttri(sPrefix, false, "A153TicketResponsableCambiosHardware", A153TicketResponsableCambiosHardware);
         A154TicketResponsableCopiasRespaldo = false;
         n154TicketResponsableCopiasRespaldo = false;
         AssignAttri(sPrefix, false, "A154TicketResponsableCopiasRespaldo", A154TicketResponsableCopiasRespaldo);
         A165TicketResponsableCerrado = false;
         n165TicketResponsableCerrado = false;
         AssignAttri(sPrefix, false, "A165TicketResponsableCerrado", A165TicketResponsableCerrado);
         A166TicketResponsablePendiente = false;
         n166TicketResponsablePendiente = false;
         AssignAttri(sPrefix, false, "A166TicketResponsablePendiente", A166TicketResponsablePendiente);
         A167TicketResponsablePasaTaller = false;
         n167TicketResponsablePasaTaller = false;
         AssignAttri(sPrefix, false, "A167TicketResponsablePasaTaller", A167TicketResponsablePasaTaller);
         A168TicketResponsableObservacion = "";
         n168TicketResponsableObservacion = false;
         AssignAttri(sPrefix, false, "A168TicketResponsableObservacion", A168TicketResponsableObservacion);
         A175TicketResponsableFechaResuelve = DateTime.MinValue;
         n175TicketResponsableFechaResuelve = false;
         AssignAttri(sPrefix, false, "A175TicketResponsableFechaResuelve", context.localUtil.Format(A175TicketResponsableFechaResuelve, "99/99/9999"));
         A176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         n176TicketResponsableHoraResuelve = false;
         AssignAttri(sPrefix, false, "A176TicketResponsableHoraResuelve", context.localUtil.TToC( A176TicketResponsableHoraResuelve, 0, 5, 0, 3, "/", ":", " "));
         A177TicketResponsableRamTxt = "";
         n177TicketResponsableRamTxt = false;
         AssignAttri(sPrefix, false, "A177TicketResponsableRamTxt", A177TicketResponsableRamTxt);
         A178TicketResponsableDiscoDuroTxt = "";
         n178TicketResponsableDiscoDuroTxt = false;
         AssignAttri(sPrefix, false, "A178TicketResponsableDiscoDuroTxt", A178TicketResponsableDiscoDuroTxt);
         A179TicketResponsableProcesadorTxt = "";
         n179TicketResponsableProcesadorTxt = false;
         AssignAttri(sPrefix, false, "A179TicketResponsableProcesadorTxt", A179TicketResponsableProcesadorTxt);
         A180TicketResponsableMaletinTxt = "";
         n180TicketResponsableMaletinTxt = false;
         AssignAttri(sPrefix, false, "A180TicketResponsableMaletinTxt", A180TicketResponsableMaletinTxt);
         A181TicketResponsableTonerCintaTxt = "";
         n181TicketResponsableTonerCintaTxt = false;
         AssignAttri(sPrefix, false, "A181TicketResponsableTonerCintaTxt", A181TicketResponsableTonerCintaTxt);
         A182TicketResponsableTarjetaVideoExtraTxt = "";
         n182TicketResponsableTarjetaVideoExtraTxt = false;
         AssignAttri(sPrefix, false, "A182TicketResponsableTarjetaVideoExtraTxt", A182TicketResponsableTarjetaVideoExtraTxt);
         A183TicketResponsableCargadorLaptopTxt = "";
         n183TicketResponsableCargadorLaptopTxt = false;
         AssignAttri(sPrefix, false, "A183TicketResponsableCargadorLaptopTxt", A183TicketResponsableCargadorLaptopTxt);
         A184TicketResponsableCDsDVDsTxt = "";
         n184TicketResponsableCDsDVDsTxt = false;
         AssignAttri(sPrefix, false, "A184TicketResponsableCDsDVDsTxt", A184TicketResponsableCDsDVDsTxt);
         A185TicketResponsableCableEspecialTxt = "";
         n185TicketResponsableCableEspecialTxt = false;
         AssignAttri(sPrefix, false, "A185TicketResponsableCableEspecialTxt", A185TicketResponsableCableEspecialTxt);
         A186TicketResponsableOtrosTallerTxt = "";
         n186TicketResponsableOtrosTallerTxt = false;
         AssignAttri(sPrefix, false, "A186TicketResponsableOtrosTallerTxt", A186TicketResponsableOtrosTallerTxt);
         A287TicketResponsableFechaHoraAsigna = (DateTime)(DateTime.MinValue);
         n287TicketResponsableFechaHoraAsigna = false;
         AssignAttri(sPrefix, false, "A287TicketResponsableFechaHoraAsigna", context.localUtil.TToC( A287TicketResponsableFechaHoraAsigna, 10, 8, 0, 3, "/", ":", " "));
         A288TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
         n288TicketResponsableFechaHoraResuelve = false;
         AssignAttri(sPrefix, false, "A288TicketResponsableFechaHoraResuelve", context.localUtil.TToC( A288TicketResponsableFechaHoraResuelve, 10, 8, 0, 3, "/", ":", " "));
         A290EtapaDesarrolloId = 0;
         n290EtapaDesarrolloId = false;
         AssignAttri(sPrefix, false, "A290EtapaDesarrolloId", StringUtil.LTrimStr( (decimal)(A290EtapaDesarrolloId), 4, 0));
         A291EtapaDesarrolloNombre = "";
         AssignAttri(sPrefix, false, "A291EtapaDesarrolloNombre", A291EtapaDesarrolloNombre);
         A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A47TicketFechaResponsable = DateTimeUtil.Today( context);
         A17EstadoTicketTecnicoId = 3;
         Z49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         Z47TicketFechaResponsable = DateTime.MinValue;
         Z145TicketResponsableInventarioSerie = "";
         Z146TicketResponsableInstalacion = false;
         Z147TicketResponsableConfiguracion = false;
         Z148TicketResponsableInternetRouter = false;
         Z149TicketResponsableFormateo = false;
         Z150TicketResponsableReparacion = false;
         Z151TicketResponsableLimpieza = false;
         Z152TicketResponsablePuntoRed = false;
         Z153TicketResponsableCambiosHardware = false;
         Z154TicketResponsableCopiasRespaldo = false;
         Z165TicketResponsableCerrado = false;
         Z166TicketResponsablePendiente = false;
         Z167TicketResponsablePasaTaller = false;
         Z168TicketResponsableObservacion = "";
         Z175TicketResponsableFechaResuelve = DateTime.MinValue;
         Z176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         Z177TicketResponsableRamTxt = "";
         Z178TicketResponsableDiscoDuroTxt = "";
         Z179TicketResponsableProcesadorTxt = "";
         Z180TicketResponsableMaletinTxt = "";
         Z181TicketResponsableTonerCintaTxt = "";
         Z182TicketResponsableTarjetaVideoExtraTxt = "";
         Z183TicketResponsableCargadorLaptopTxt = "";
         Z184TicketResponsableCDsDVDsTxt = "";
         Z185TicketResponsableCableEspecialTxt = "";
         Z186TicketResponsableOtrosTallerTxt = "";
         Z287TicketResponsableFechaHoraAsigna = (DateTime)(DateTime.MinValue);
         Z288TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
         Z290EtapaDesarrolloId = 0;
         Z17EstadoTicketTecnicoId = 0;
         Z198TicketTecnicoResponsableId = 0;
      }

      protected void InitAll078( )
      {
         A16TicketResponsableId = 0;
         InitializeNonKey078( ) ;
      }

      protected void StandaloneModalInsert078( )
      {
         A54TicketLastId = i54TicketLastId;
         AssignAttri(sPrefix, false, "A54TicketLastId", StringUtil.LTrimStr( (decimal)(A54TicketLastId), 10, 0));
         A49TicketHoraResponsable = i49TicketHoraResponsable;
         A47TicketFechaResponsable = i47TicketFechaResponsable;
         A17EstadoTicketTecnicoId = i17EstadoTicketTecnicoId;
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7TicketId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "ticket", GetJustCreated( ));
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
            AV7TicketId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7TicketId", StringUtil.LTrimStr( (decimal)(AV7TicketId), 10, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7TicketId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7TicketId != wcpOAV7TicketId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7TicketId = AV7TicketId;
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
         sCtrlAV7TicketId = cgiGet( sPrefix+"AV7TicketId_CTRL");
         if ( StringUtil.Len( sCtrlAV7TicketId) > 0 )
         {
            AV7TicketId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV7TicketId), ",", "."));
            AssignAttri(sPrefix, false, "AV7TicketId", StringUtil.LTrimStr( (decimal)(AV7TicketId), 10, 0));
         }
         else
         {
            AV7TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV7TicketId_PARM"), ",", "."));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7TicketId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TicketId), 10, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7TicketId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7TicketId_CTRL", StringUtil.RTrim( sCtrlAV7TicketId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023124950349", true, true);
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
         context.AddJavascriptSource("ticket.js", "?2023124950349", false, true);
         context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties8( )
      {
         edtEstadoTicketTecnicoNombre_Enabled = defedtEstadoTicketTecnicoNombre_Enabled;
         AssignProp(sPrefix, false, edtEstadoTicketTecnicoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoNombre_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtEstadoTicketTecnicoId_Enabled = defedtEstadoTicketTecnicoId_Enabled;
         AssignProp(sPrefix, false, edtEstadoTicketTecnicoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEstadoTicketTecnicoId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketHoraResponsable_Enabled = defedtTicketHoraResponsable_Enabled;
         AssignProp(sPrefix, false, edtTicketHoraResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketHoraResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketFechaResponsable_Enabled = defedtTicketFechaResponsable_Enabled;
         AssignProp(sPrefix, false, edtTicketFechaResponsable_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketFechaResponsable_Enabled), 5, 0), !bGXsfl_242_Refreshing);
         edtTicketResponsableId_Enabled = defedtTicketResponsableId_Enabled;
         AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), !bGXsfl_242_Refreshing);
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         lblLnreqsoptec_Internalname = sPrefix+"LNREQSOPTEC";
         divTabletextblocklnreqsopteccontainer_Internalname = sPrefix+"TABLETEXTBLOCKLNREQSOPTECCONTAINER";
         edtUsuarioId_Internalname = sPrefix+"USUARIOID";
         divK2btoolstable_attributecontainerusuarioid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOID";
         divTableclmid0_Internalname = sPrefix+"TABLECLMID0";
         edtTicketId_Internalname = sPrefix+"TICKETID";
         divK2btoolstable_attributecontainerticketid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETID";
         divTableclmid1_Internalname = sPrefix+"TABLECLMID1";
         divClmid_Internalname = sPrefix+"CLMID";
         edtTicketFecha_Internalname = sPrefix+"TICKETFECHA";
         divK2btoolstable_attributecontainerticketfecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETFECHA";
         divTableclmfecha0_Internalname = sPrefix+"TABLECLMFECHA0";
         edtTicketHora_Internalname = sPrefix+"TICKETHORA";
         divK2btoolstable_attributecontainertickethora_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETHORA";
         divTableclmfecha1_Internalname = sPrefix+"TABLECLMFECHA1";
         divClmfecha_Internalname = sPrefix+"CLMFECHA";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         divTableclmusuario0_Internalname = sPrefix+"TABLECLMUSUARIO0";
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO";
         divK2btoolstable_attributecontainerusuariorequerimiento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOREQUERIMIENTO";
         divTableclmusuario1_Internalname = sPrefix+"TABLECLMUSUARIO1";
         divClmusuario_Internalname = sPrefix+"CLMUSUARIO";
         edtEstadoTicketTicketNombre_Internalname = sPrefix+"ESTADOTICKETTICKETNOMBRE";
         divK2btoolstable_attributecontainerestadoticketticketnombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOTICKETTICKETNOMBRE";
         divTableclmestado0_Internalname = sPrefix+"TABLECLMESTADO0";
         edtEstadoTicketTicketId_Internalname = sPrefix+"ESTADOTICKETTICKETID";
         divK2btoolstable_attributecontainerestadoticketticketid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERESTADOTICKETTICKETID";
         divTableclmestado1_Internalname = sPrefix+"TABLECLMESTADO1";
         edtTicketLastId_Internalname = sPrefix+"TICKETLASTID";
         divK2btoolstable_attributecontainerticketlastid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETLASTID";
         divTableclmestado2_Internalname = sPrefix+"TABLECLMESTADO2";
         divClmestado_Internalname = sPrefix+"CLMESTADO";
         lblTxthardware_Internalname = sPrefix+"TXTHARDWARE";
         divTabletextblocktxthardwarecontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTHARDWARECONTAINER";
         chkTicketLaptop_Internalname = sPrefix+"TICKETLAPTOP";
         divK2btoolstable_attributecontainerticketlaptop_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETLAPTOP";
         chkTicketDesktop_Internalname = sPrefix+"TICKETDESKTOP";
         divK2btoolstable_attributecontainerticketdesktop_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETDESKTOP";
         chkTicketMonitor_Internalname = sPrefix+"TICKETMONITOR";
         divK2btoolstable_attributecontainerticketmonitor_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETMONITOR";
         chkTicketImpresora_Internalname = sPrefix+"TICKETIMPRESORA";
         divK2btoolstable_attributecontainerticketimpresora_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETIMPRESORA";
         chkTicketEscaner_Internalname = sPrefix+"TICKETESCANER";
         divK2btoolstable_attributecontainerticketescaner_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETESCANER";
         chkTicketRouter_Internalname = sPrefix+"TICKETROUTER";
         divK2btoolstable_attributecontainerticketrouter_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETROUTER";
         divTableclmcat0_Internalname = sPrefix+"TABLECLMCAT0";
         lblTxtsoftware_Internalname = sPrefix+"TXTSOFTWARE";
         divTabletextblocktxtsoftwarecontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTSOFTWARECONTAINER";
         chkTicketSistemaOperativo_Internalname = sPrefix+"TICKETSISTEMAOPERATIVO";
         divK2btoolstable_attributecontainerticketsistemaoperativo_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETSISTEMAOPERATIVO";
         chkTicketOffice_Internalname = sPrefix+"TICKETOFFICE";
         divK2btoolstable_attributecontainerticketoffice_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETOFFICE";
         chkTicketAntivirus_Internalname = sPrefix+"TICKETANTIVIRUS";
         divK2btoolstable_attributecontainerticketantivirus_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETANTIVIRUS";
         chkTicketAplicacion_Internalname = sPrefix+"TICKETAPLICACION";
         divK2btoolstable_attributecontainerticketaplicacion_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETAPLICACION";
         chkTicketDisenio_Internalname = sPrefix+"TICKETDISENIO";
         divK2btoolstable_attributecontainerticketdisenio_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETDISENIO";
         chkTicketIngenieria_Internalname = sPrefix+"TICKETINGENIERIA";
         divK2btoolstable_attributecontainerticketingenieria_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETINGENIERIA";
         divTableclmcat1_Internalname = sPrefix+"TABLECLMCAT1";
         lblTxtotros_Internalname = sPrefix+"TXTOTROS";
         divTabletextblocktxtotroscontainer_Internalname = sPrefix+"TABLETEXTBLOCKTXTOTROSCONTAINER";
         chkTicketDiscoDuroExterno_Internalname = sPrefix+"TICKETDISCODUROEXTERNO";
         divK2btoolstable_attributecontainerticketdiscoduroexterno_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETDISCODUROEXTERNO";
         chkTicketPerifericos_Internalname = sPrefix+"TICKETPERIFERICOS";
         divK2btoolstable_attributecontainerticketperifericos_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETPERIFERICOS";
         chkTicketUps_Internalname = sPrefix+"TICKETUPS";
         divK2btoolstable_attributecontainerticketups_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETUPS";
         chkTicketApoyoUsuario_Internalname = sPrefix+"TICKETAPOYOUSUARIO";
         divK2btoolstable_attributecontainerticketapoyousuario_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETAPOYOUSUARIO";
         chkTicketInstalarDataShow_Internalname = sPrefix+"TICKETINSTALARDATASHOW";
         divK2btoolstable_attributecontainerticketinstalardatashow_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETINSTALARDATASHOW";
         chkTicketOtros_Internalname = sPrefix+"TICKETOTROS";
         divK2btoolstable_attributecontainerticketotros_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETOTROS";
         divTableclmcat2_Internalname = sPrefix+"TABLECLMCAT2";
         divClmcat_Internalname = sPrefix+"CLMCAT";
         divTableattributesinformsection1_Internalname = sPrefix+"TABLEATTRIBUTESINFORMSECTION1";
         divK2btrnformmaintablecell_Internalname = sPrefix+"K2BTRNFORMMAINTABLECELL";
         lblTextblock_header_responsable_Internalname = sPrefix+"TEXTBLOCK_HEADER_RESPONSABLE";
         edtTicketResponsableId_Internalname = sPrefix+"TICKETRESPONSABLEID";
         edtTicketTecnicoResponsableId_Internalname = sPrefix+"TICKETTECNICORESPONSABLEID";
         edtTicketTecnicoResponsableNombre_Internalname = sPrefix+"TICKETTECNICORESPONSABLENOMBRE";
         edtTicketFechaResponsable_Internalname = sPrefix+"TICKETFECHARESPONSABLE";
         edtTicketHoraResponsable_Internalname = sPrefix+"TICKETHORARESPONSABLE";
         edtEstadoTicketTecnicoId_Internalname = sPrefix+"ESTADOTICKETTECNICOID";
         edtEstadoTicketTecnicoNombre_Internalname = sPrefix+"ESTADOTICKETTECNICONOMBRE";
         divMaingrid_responsivetable_gridresponsable_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRIDRESPONSABLE";
         divDiv_level_container_responsable_Internalname = sPrefix+"DIV_LEVEL_CONTAINER_RESPONSABLE";
         divK2btrnformmaintablecell2_Internalname = sPrefix+"K2BTRNFORMMAINTABLECELL2";
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
         imgprompt_15_Internalname = sPrefix+"PROMPT_15";
         imgprompt_187_Internalname = sPrefix+"PROMPT_187";
         imgprompt_198_Internalname = sPrefix+"PROMPT_198";
         subGridresponsable_Internalname = sPrefix+"GRIDRESPONSABLE";
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
         Form.Caption = "Ticket";
         edtEstadoTicketTecnicoNombre_Jsonclick = "";
         edtEstadoTicketTecnicoId_Jsonclick = "";
         edtTicketHoraResponsable_Jsonclick = "";
         edtTicketFechaResponsable_Jsonclick = "";
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         imgprompt_198_Visible = 1;
         imgprompt_198_Link = "";
         imgprompt_15_Visible = 1;
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtTicketResponsableId_Jsonclick = "";
         subGridresponsable_Class = "K2BT_SG Grid_WorkWith";
         subGridresponsable_Backcolorstyle = 0;
         subGridresponsable_Rows = 5;
         subGridresponsable_Allowcollapsing = 0;
         subGridresponsable_Allowselection = 0;
         edtEstadoTicketTecnicoNombre_Enabled = 0;
         edtEstadoTicketTecnicoId_Enabled = 0;
         edtTicketHoraResponsable_Enabled = 0;
         edtTicketFechaResponsable_Enabled = 0;
         edtTicketTecnicoResponsableNombre_Enabled = 0;
         edtTicketTecnicoResponsableId_Enabled = 1;
         edtTicketResponsableId_Enabled = 1;
         subGridresponsable_Sortable = 0;
         subGridresponsable_Header = "";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         chkTicketOtros.Enabled = 1;
         chkTicketInstalarDataShow.Enabled = 1;
         chkTicketApoyoUsuario.Enabled = 1;
         chkTicketUps.Enabled = 1;
         chkTicketPerifericos.Enabled = 1;
         chkTicketDiscoDuroExterno.Enabled = 1;
         chkTicketIngenieria.Enabled = 1;
         chkTicketDisenio.Enabled = 1;
         chkTicketAplicacion.Enabled = 1;
         chkTicketAntivirus.Enabled = 1;
         chkTicketOffice.Enabled = 1;
         chkTicketSistemaOperativo.Enabled = 1;
         chkTicketRouter.Enabled = 1;
         chkTicketEscaner.Enabled = 1;
         chkTicketImpresora.Enabled = 1;
         chkTicketMonitor.Enabled = 1;
         chkTicketDesktop.Enabled = 1;
         chkTicketLaptop.Enabled = 1;
         edtTicketLastId_Jsonclick = "";
         edtTicketLastId_Enabled = 0;
         divK2btoolstable_attributecontainerticketlastid_Visible = 1;
         imgprompt_187_Visible = 1;
         imgprompt_187_Link = "";
         edtEstadoTicketTicketId_Jsonclick = "";
         edtEstadoTicketTicketId_Enabled = 1;
         divK2btoolstable_attributecontainerestadoticketticketid_Visible = 1;
         edtEstadoTicketTicketNombre_Jsonclick = "";
         edtEstadoTicketTicketNombre_Link = "";
         edtEstadoTicketTicketNombre_Enabled = 0;
         edtUsuarioRequerimiento_Enabled = 0;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Link = "";
         edtUsuarioNombre_Enabled = 0;
         edtTicketHora_Jsonclick = "";
         edtTicketHora_Enabled = 0;
         edtTicketFecha_Jsonclick = "";
         edtTicketFecha_Class = "Attribute_TrnDate Attribute_Required";
         edtTicketFecha_Enabled = 0;
         edtTicketId_Jsonclick = "";
         edtTicketId_Enabled = 0;
         imgprompt_15_Visible = 1;
         imgprompt_15_Link = "";
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 1;
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

      protected void GXASA93077( short A15UsuarioId )
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

      protected void GXASA188077( short A187EstadoTicketTicketId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTicket",  "EstadoTicket",  "Display",  "",  "EntityManagerEstadoTicket", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
            AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Link", edtEstadoTicketTicketNombre_Link, true);
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

      protected void gxnrGridresponsable_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         SubsflControlProps_2428( ) ;
         while ( nGXsfl_242_idx <= nRC_GXsfl_242 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal078( ) ;
            standaloneModal078( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow078( ) ;
            nGXsfl_242_idx = (int)(nGXsfl_242_idx+1);
            sGXsfl_242_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_242_idx), 4, 0), 4, "0");
            SubsflControlProps_2428( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridresponsableContainer)) ;
         /* End function gxnrGridresponsable_newrow */
      }

      protected void init_web_controls( )
      {
         chkTicketLaptop.Name = "TICKETLAPTOP";
         chkTicketLaptop.WebTags = "";
         chkTicketLaptop.Caption = "";
         AssignProp(sPrefix, false, chkTicketLaptop_Internalname, "TitleCaption", chkTicketLaptop.Caption, true);
         chkTicketLaptop.CheckedValue = "false";
         chkTicketDesktop.Name = "TICKETDESKTOP";
         chkTicketDesktop.WebTags = "";
         chkTicketDesktop.Caption = "";
         AssignProp(sPrefix, false, chkTicketDesktop_Internalname, "TitleCaption", chkTicketDesktop.Caption, true);
         chkTicketDesktop.CheckedValue = "false";
         chkTicketMonitor.Name = "TICKETMONITOR";
         chkTicketMonitor.WebTags = "";
         chkTicketMonitor.Caption = "";
         AssignProp(sPrefix, false, chkTicketMonitor_Internalname, "TitleCaption", chkTicketMonitor.Caption, true);
         chkTicketMonitor.CheckedValue = "false";
         chkTicketImpresora.Name = "TICKETIMPRESORA";
         chkTicketImpresora.WebTags = "";
         chkTicketImpresora.Caption = "";
         AssignProp(sPrefix, false, chkTicketImpresora_Internalname, "TitleCaption", chkTicketImpresora.Caption, true);
         chkTicketImpresora.CheckedValue = "false";
         chkTicketEscaner.Name = "TICKETESCANER";
         chkTicketEscaner.WebTags = "";
         chkTicketEscaner.Caption = "";
         AssignProp(sPrefix, false, chkTicketEscaner_Internalname, "TitleCaption", chkTicketEscaner.Caption, true);
         chkTicketEscaner.CheckedValue = "false";
         chkTicketRouter.Name = "TICKETROUTER";
         chkTicketRouter.WebTags = "";
         chkTicketRouter.Caption = "";
         AssignProp(sPrefix, false, chkTicketRouter_Internalname, "TitleCaption", chkTicketRouter.Caption, true);
         chkTicketRouter.CheckedValue = "false";
         chkTicketSistemaOperativo.Name = "TICKETSISTEMAOPERATIVO";
         chkTicketSistemaOperativo.WebTags = "";
         chkTicketSistemaOperativo.Caption = "";
         AssignProp(sPrefix, false, chkTicketSistemaOperativo_Internalname, "TitleCaption", chkTicketSistemaOperativo.Caption, true);
         chkTicketSistemaOperativo.CheckedValue = "false";
         chkTicketOffice.Name = "TICKETOFFICE";
         chkTicketOffice.WebTags = "";
         chkTicketOffice.Caption = "";
         AssignProp(sPrefix, false, chkTicketOffice_Internalname, "TitleCaption", chkTicketOffice.Caption, true);
         chkTicketOffice.CheckedValue = "false";
         chkTicketAntivirus.Name = "TICKETANTIVIRUS";
         chkTicketAntivirus.WebTags = "";
         chkTicketAntivirus.Caption = "";
         AssignProp(sPrefix, false, chkTicketAntivirus_Internalname, "TitleCaption", chkTicketAntivirus.Caption, true);
         chkTicketAntivirus.CheckedValue = "false";
         chkTicketAplicacion.Name = "TICKETAPLICACION";
         chkTicketAplicacion.WebTags = "";
         chkTicketAplicacion.Caption = "";
         AssignProp(sPrefix, false, chkTicketAplicacion_Internalname, "TitleCaption", chkTicketAplicacion.Caption, true);
         chkTicketAplicacion.CheckedValue = "false";
         chkTicketDisenio.Name = "TICKETDISENIO";
         chkTicketDisenio.WebTags = "";
         chkTicketDisenio.Caption = "";
         AssignProp(sPrefix, false, chkTicketDisenio_Internalname, "TitleCaption", chkTicketDisenio.Caption, true);
         chkTicketDisenio.CheckedValue = "false";
         chkTicketIngenieria.Name = "TICKETINGENIERIA";
         chkTicketIngenieria.WebTags = "";
         chkTicketIngenieria.Caption = "";
         AssignProp(sPrefix, false, chkTicketIngenieria_Internalname, "TitleCaption", chkTicketIngenieria.Caption, true);
         chkTicketIngenieria.CheckedValue = "false";
         chkTicketDiscoDuroExterno.Name = "TICKETDISCODUROEXTERNO";
         chkTicketDiscoDuroExterno.WebTags = "";
         chkTicketDiscoDuroExterno.Caption = "";
         AssignProp(sPrefix, false, chkTicketDiscoDuroExterno_Internalname, "TitleCaption", chkTicketDiscoDuroExterno.Caption, true);
         chkTicketDiscoDuroExterno.CheckedValue = "false";
         chkTicketPerifericos.Name = "TICKETPERIFERICOS";
         chkTicketPerifericos.WebTags = "";
         chkTicketPerifericos.Caption = "";
         AssignProp(sPrefix, false, chkTicketPerifericos_Internalname, "TitleCaption", chkTicketPerifericos.Caption, true);
         chkTicketPerifericos.CheckedValue = "false";
         chkTicketUps.Name = "TICKETUPS";
         chkTicketUps.WebTags = "";
         chkTicketUps.Caption = "";
         AssignProp(sPrefix, false, chkTicketUps_Internalname, "TitleCaption", chkTicketUps.Caption, true);
         chkTicketUps.CheckedValue = "false";
         chkTicketApoyoUsuario.Name = "TICKETAPOYOUSUARIO";
         chkTicketApoyoUsuario.WebTags = "";
         chkTicketApoyoUsuario.Caption = "";
         AssignProp(sPrefix, false, chkTicketApoyoUsuario_Internalname, "TitleCaption", chkTicketApoyoUsuario.Caption, true);
         chkTicketApoyoUsuario.CheckedValue = "false";
         chkTicketInstalarDataShow.Name = "TICKETINSTALARDATASHOW";
         chkTicketInstalarDataShow.WebTags = "";
         chkTicketInstalarDataShow.Caption = "";
         AssignProp(sPrefix, false, chkTicketInstalarDataShow_Internalname, "TitleCaption", chkTicketInstalarDataShow.Caption, true);
         chkTicketInstalarDataShow.CheckedValue = "false";
         chkTicketOtros.Name = "TICKETOTROS";
         chkTicketOtros.WebTags = "";
         chkTicketOtros.Caption = "";
         AssignProp(sPrefix, false, chkTicketOtros_Internalname, "TitleCaption", chkTicketOtros.Caption, true);
         chkTicketOtros.CheckedValue = "false";
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

      public void Valid_Usuarioid( )
      {
         /* Using cursor T000720 */
         pr_default.execute(18, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
            GX_FocusControl = edtUsuarioId_Internalname;
         }
         A93UsuarioNombre = T000720_A93UsuarioNombre[0];
         A94UsuarioRequerimiento = T000720_A94UsuarioRequerimiento[0];
         A91UsuarioGerencia = T000720_A91UsuarioGerencia[0];
         A88UsuarioDepartamento = T000720_A88UsuarioDepartamento[0];
         pr_default.close(18);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         AssignAttri(sPrefix, false, "A91UsuarioGerencia", A91UsuarioGerencia);
         AssignAttri(sPrefix, false, "A88UsuarioDepartamento", A88UsuarioDepartamento);
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
      }

      public void Valid_Estadoticketticketid( )
      {
         /* Using cursor T000721 */
         pr_default.execute(19, new Object[] {A187EstadoTicketTicketId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Estado Ticket Ticket'.", "ForeignKeyNotFound", 1, "ESTADOTICKETTICKETID");
            AnyError = 1;
            GX_FocusControl = edtEstadoTicketTicketId_Internalname;
         }
         A188EstadoTicketTicketNombre = T000721_A188EstadoTicketTicketNombre[0];
         pr_default.close(19);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoTicket",  "EstadoTicket",  "Display",  "",  "EntityManagerEstadoTicket", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtEstadoTicketTicketNombre_Link = formatLink("entitymanagerestadoticket.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A187EstadoTicketTicketId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoTicketId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A188EstadoTicketTicketNombre", A188EstadoTicketTicketNombre);
         AssignProp(sPrefix, false, edtEstadoTicketTicketNombre_Internalname, "Link", edtEstadoTicketTicketNombre_Link, true);
      }

      public void Valid_Tickettecnicoresponsableid( )
      {
         /* Using cursor T000732 */
         pr_default.execute(30, new Object[] {A198TicketTecnicoResponsableId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Ticket Tecnico Responsable'.", "ForeignKeyNotFound", 1, "TICKETTECNICORESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketTecnicoResponsableId_Internalname;
         }
         A199TicketTecnicoResponsableNombre = T000732_A199TicketTecnicoResponsableNombre[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7TicketId',fld:'vTICKETID',pic:'ZZZZZZZZZ9'},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A285TicketHoraCaracter',fld:'TICKETHORACARACTER',pic:''},{av:'A289TicketFechaHora',fld:'TICKETFECHAHORA',pic:'99/99/9999 99:99:99'},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A46TicketFecha',fld:'TICKETFECHA',pic:''},{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV21AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9'},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E13072',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("'DOCANCEL'",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A91UsuarioGerencia',fld:'USUARIOGERENCIA',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_USUARIOID",",oparms:[{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A91UsuarioGerencia',fld:'USUARIOGERENCIA',pic:''},{av:'A88UsuarioDepartamento',fld:'USUARIODEPARTAMENTO',pic:''},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_TICKETFECHA","{handler:'Valid_Ticketfecha',iparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_TICKETFECHA",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_ESTADOTICKETTICKETID","{handler:'Valid_Estadoticketticketid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A187EstadoTicketTicketId',fld:'ESTADOTICKETTICKETID',pic:'ZZZ9'},{av:'A188EstadoTicketTicketNombre',fld:'ESTADOTICKETTICKETNOMBRE',pic:''},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_ESTADOTICKETTICKETID",",oparms:[{av:'A188EstadoTicketTicketNombre',fld:'ESTADOTICKETTICKETNOMBRE',pic:''},{av:'edtEstadoTicketTicketNombre_Link',ctrl:'ESTADOTICKETTICKETNOMBRE',prop:'Link'},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_TICKETLASTID","{handler:'Valid_Ticketlastid',iparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_TICKETLASTID",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_TICKETRESPONSABLEID","{handler:'Valid_Ticketresponsableid',iparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_TICKETRESPONSABLEID",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[{av:'A198TicketTecnicoResponsableId',fld:'TICKETTECNICORESPONSABLEID',pic:'ZZZ9'},{av:'A199TicketTecnicoResponsableNombre',fld:'TICKETTECNICORESPONSABLENOMBRE',pic:''},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[{av:'A199TicketTecnicoResponsableNombre',fld:'TICKETTECNICORESPONSABLENOMBRE',pic:''},{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("VALID_ESTADOTICKETTECNICOID","{handler:'Valid_Estadotickettecnicoid',iparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("VALID_ESTADOTICKETTECNICOID",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Estadotickettecniconombre',iparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'A53TicketLaptop',fld:'TICKETLAPTOP',pic:''},{av:'A42TicketDesktop',fld:'TICKETDESKTOP',pic:''},{av:'A55TicketMonitor',fld:'TICKETMONITOR',pic:''},{av:'A50TicketImpresora',fld:'TICKETIMPRESORA',pic:''},{av:'A45TicketEscaner',fld:'TICKETESCANER',pic:''},{av:'A59TicketRouter',fld:'TICKETROUTER',pic:''},{av:'A60TicketSistemaOperativo',fld:'TICKETSISTEMAOPERATIVO',pic:''},{av:'A56TicketOffice',fld:'TICKETOFFICE',pic:''},{av:'A39TicketAntivirus',fld:'TICKETANTIVIRUS',pic:''},{av:'A40TicketAplicacion',fld:'TICKETAPLICACION',pic:''},{av:'A44TicketDisenio',fld:'TICKETDISENIO',pic:''},{av:'A51TicketIngenieria',fld:'TICKETINGENIERIA',pic:''},{av:'A43TicketDiscoDuroExterno',fld:'TICKETDISCODUROEXTERNO',pic:''},{av:'A58TicketPerifericos',fld:'TICKETPERIFERICOS',pic:''},{av:'A87TicketUps',fld:'TICKETUPS',pic:''},{av:'A41TicketApoyoUsuario',fld:'TICKETAPOYOUSUARIO',pic:''},{av:'A52TicketInstalarDataShow',fld:'TICKETINSTALARDATASHOW',pic:''},{av:'A57TicketOtros',fld:'TICKETOTROS',pic:''}]}");
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
         pr_default.close(30);
         pr_default.close(6);
         pr_default.close(18);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z46TicketFecha = DateTime.MinValue;
         Z48TicketHora = (DateTime)(DateTime.MinValue);
         Z285TicketHoraCaracter = "";
         Z278TicketUsuarioAsigno = "";
         Z289TicketFechaHora = (DateTime)(DateTime.MinValue);
         Z49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         Z47TicketFechaResponsable = DateTime.MinValue;
         Z145TicketResponsableInventarioSerie = "";
         Z168TicketResponsableObservacion = "";
         Z175TicketResponsableFechaResuelve = DateTime.MinValue;
         Z176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         Z177TicketResponsableRamTxt = "";
         Z178TicketResponsableDiscoDuroTxt = "";
         Z179TicketResponsableProcesadorTxt = "";
         Z180TicketResponsableMaletinTxt = "";
         Z181TicketResponsableTonerCintaTxt = "";
         Z182TicketResponsableTarjetaVideoExtraTxt = "";
         Z183TicketResponsableCargadorLaptopTxt = "";
         Z184TicketResponsableCDsDVDsTxt = "";
         Z185TicketResponsableCableEspecialTxt = "";
         Z186TicketResponsableOtrosTallerTxt = "";
         Z287TicketResponsableFechaHoraAsigna = (DateTime)(DateTime.MinValue);
         Z288TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
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
         lblLnreqsoptec_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         A46TicketFecha = DateTime.MinValue;
         A48TicketHora = (DateTime)(DateTime.MinValue);
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         A188EstadoTicketTicketNombre = "";
         lblTxthardware_Jsonclick = "";
         lblTxtsoftware_Jsonclick = "";
         lblTxtotros_Jsonclick = "";
         lblTextblock_header_responsable_Jsonclick = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         GridresponsableContainer = new GXWebGrid( context);
         GridresponsableColumn = new GXWebColumn();
         A199TicketTecnicoResponsableNombre = "";
         A47TicketFechaResponsable = DateTime.MinValue;
         A49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         A25EstadoTicketTecnicoNombre = "";
         sMode8 = "";
         A289TicketFechaHora = (DateTime)(DateTime.MinValue);
         A285TicketHoraCaracter = "";
         A278TicketUsuarioAsigno = "";
         A91UsuarioGerencia = "";
         A88UsuarioDepartamento = "";
         AV30Pgmname = "";
         A145TicketResponsableInventarioSerie = "";
         A168TicketResponsableObservacion = "";
         A175TicketResponsableFechaResuelve = DateTime.MinValue;
         A176TicketResponsableHoraResuelve = (DateTime)(DateTime.MinValue);
         A177TicketResponsableRamTxt = "";
         A178TicketResponsableDiscoDuroTxt = "";
         A179TicketResponsableProcesadorTxt = "";
         A180TicketResponsableMaletinTxt = "";
         A181TicketResponsableTonerCintaTxt = "";
         A182TicketResponsableTarjetaVideoExtraTxt = "";
         A183TicketResponsableCargadorLaptopTxt = "";
         A184TicketResponsableCDsDVDsTxt = "";
         A185TicketResponsableCableEspecialTxt = "";
         A186TicketResponsableOtrosTallerTxt = "";
         A287TicketResponsableFechaHoraAsigna = (DateTime)(DateTime.MinValue);
         A288TicketResponsableFechaHoraResuelve = (DateTime)(DateTime.MinValue);
         A291EtapaDesarrolloNombre = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
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
         Z93UsuarioNombre = "";
         Z94UsuarioRequerimiento = "";
         Z91UsuarioGerencia = "";
         Z88UsuarioDepartamento = "";
         Z188EstadoTicketTicketNombre = "";
         AV28WebSession = context.GetSession();
         T00079_A93UsuarioNombre = new string[] {""} ;
         T00079_A94UsuarioRequerimiento = new string[] {""} ;
         T00079_A91UsuarioGerencia = new string[] {""} ;
         T00079_A88UsuarioDepartamento = new string[] {""} ;
         T000710_A188EstadoTicketTicketNombre = new string[] {""} ;
         T000711_A14TicketId = new long[1] ;
         T000711_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         T000711_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         T000711_A93UsuarioNombre = new string[] {""} ;
         T000711_A94UsuarioRequerimiento = new string[] {""} ;
         T000711_A91UsuarioGerencia = new string[] {""} ;
         T000711_A88UsuarioDepartamento = new string[] {""} ;
         T000711_A188EstadoTicketTicketNombre = new string[] {""} ;
         T000711_A54TicketLastId = new long[1] ;
         T000711_A285TicketHoraCaracter = new string[] {""} ;
         T000711_A53TicketLaptop = new bool[] {false} ;
         T000711_A42TicketDesktop = new bool[] {false} ;
         T000711_A55TicketMonitor = new bool[] {false} ;
         T000711_A50TicketImpresora = new bool[] {false} ;
         T000711_A45TicketEscaner = new bool[] {false} ;
         T000711_A59TicketRouter = new bool[] {false} ;
         T000711_A60TicketSistemaOperativo = new bool[] {false} ;
         T000711_A56TicketOffice = new bool[] {false} ;
         T000711_A39TicketAntivirus = new bool[] {false} ;
         T000711_A40TicketAplicacion = new bool[] {false} ;
         T000711_A44TicketDisenio = new bool[] {false} ;
         T000711_A51TicketIngenieria = new bool[] {false} ;
         T000711_A43TicketDiscoDuroExterno = new bool[] {false} ;
         T000711_A58TicketPerifericos = new bool[] {false} ;
         T000711_A87TicketUps = new bool[] {false} ;
         T000711_A41TicketApoyoUsuario = new bool[] {false} ;
         T000711_A52TicketInstalarDataShow = new bool[] {false} ;
         T000711_A57TicketOtros = new bool[] {false} ;
         T000711_A278TicketUsuarioAsigno = new string[] {""} ;
         T000711_A289TicketFechaHora = new DateTime[] {DateTime.MinValue} ;
         T000711_n289TicketFechaHora = new bool[] {false} ;
         T000711_A15UsuarioId = new short[1] ;
         T000711_A187EstadoTicketTicketId = new short[1] ;
         T000712_A93UsuarioNombre = new string[] {""} ;
         T000712_A94UsuarioRequerimiento = new string[] {""} ;
         T000712_A91UsuarioGerencia = new string[] {""} ;
         T000712_A88UsuarioDepartamento = new string[] {""} ;
         T000713_A188EstadoTicketTicketNombre = new string[] {""} ;
         T000714_A14TicketId = new long[1] ;
         T00078_A14TicketId = new long[1] ;
         T00078_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         T00078_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         T00078_A54TicketLastId = new long[1] ;
         T00078_A285TicketHoraCaracter = new string[] {""} ;
         T00078_A53TicketLaptop = new bool[] {false} ;
         T00078_A42TicketDesktop = new bool[] {false} ;
         T00078_A55TicketMonitor = new bool[] {false} ;
         T00078_A50TicketImpresora = new bool[] {false} ;
         T00078_A45TicketEscaner = new bool[] {false} ;
         T00078_A59TicketRouter = new bool[] {false} ;
         T00078_A60TicketSistemaOperativo = new bool[] {false} ;
         T00078_A56TicketOffice = new bool[] {false} ;
         T00078_A39TicketAntivirus = new bool[] {false} ;
         T00078_A40TicketAplicacion = new bool[] {false} ;
         T00078_A44TicketDisenio = new bool[] {false} ;
         T00078_A51TicketIngenieria = new bool[] {false} ;
         T00078_A43TicketDiscoDuroExterno = new bool[] {false} ;
         T00078_A58TicketPerifericos = new bool[] {false} ;
         T00078_A87TicketUps = new bool[] {false} ;
         T00078_A41TicketApoyoUsuario = new bool[] {false} ;
         T00078_A52TicketInstalarDataShow = new bool[] {false} ;
         T00078_A57TicketOtros = new bool[] {false} ;
         T00078_A278TicketUsuarioAsigno = new string[] {""} ;
         T00078_A289TicketFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00078_n289TicketFechaHora = new bool[] {false} ;
         T00078_A15UsuarioId = new short[1] ;
         T00078_A187EstadoTicketTicketId = new short[1] ;
         T000715_A14TicketId = new long[1] ;
         T000716_A14TicketId = new long[1] ;
         T00077_A14TicketId = new long[1] ;
         T00077_A46TicketFecha = new DateTime[] {DateTime.MinValue} ;
         T00077_A48TicketHora = new DateTime[] {DateTime.MinValue} ;
         T00077_A54TicketLastId = new long[1] ;
         T00077_A285TicketHoraCaracter = new string[] {""} ;
         T00077_A53TicketLaptop = new bool[] {false} ;
         T00077_A42TicketDesktop = new bool[] {false} ;
         T00077_A55TicketMonitor = new bool[] {false} ;
         T00077_A50TicketImpresora = new bool[] {false} ;
         T00077_A45TicketEscaner = new bool[] {false} ;
         T00077_A59TicketRouter = new bool[] {false} ;
         T00077_A60TicketSistemaOperativo = new bool[] {false} ;
         T00077_A56TicketOffice = new bool[] {false} ;
         T00077_A39TicketAntivirus = new bool[] {false} ;
         T00077_A40TicketAplicacion = new bool[] {false} ;
         T00077_A44TicketDisenio = new bool[] {false} ;
         T00077_A51TicketIngenieria = new bool[] {false} ;
         T00077_A43TicketDiscoDuroExterno = new bool[] {false} ;
         T00077_A58TicketPerifericos = new bool[] {false} ;
         T00077_A87TicketUps = new bool[] {false} ;
         T00077_A41TicketApoyoUsuario = new bool[] {false} ;
         T00077_A52TicketInstalarDataShow = new bool[] {false} ;
         T00077_A57TicketOtros = new bool[] {false} ;
         T00077_A278TicketUsuarioAsigno = new string[] {""} ;
         T00077_A289TicketFechaHora = new DateTime[] {DateTime.MinValue} ;
         T00077_n289TicketFechaHora = new bool[] {false} ;
         T00077_A15UsuarioId = new short[1] ;
         T00077_A187EstadoTicketTicketId = new short[1] ;
         T000717_A14TicketId = new long[1] ;
         T000720_A93UsuarioNombre = new string[] {""} ;
         T000720_A94UsuarioRequerimiento = new string[] {""} ;
         T000720_A91UsuarioGerencia = new string[] {""} ;
         T000720_A88UsuarioDepartamento = new string[] {""} ;
         T000721_A188EstadoTicketTicketNombre = new string[] {""} ;
         T000722_A202SoporteTecnicoId = new long[1] ;
         T000723_A7SatisfaccionId = new long[1] ;
         T000725_A14TicketId = new long[1] ;
         Z291EtapaDesarrolloNombre = "";
         Z25EstadoTicketTecnicoNombre = "";
         Z199TicketTecnicoResponsableNombre = "";
         T00074_A291EtapaDesarrolloNombre = new string[] {""} ;
         T00075_A25EstadoTicketTecnicoNombre = new string[] {""} ;
         T000726_A14TicketId = new long[1] ;
         T000726_A16TicketResponsableId = new long[1] ;
         T000726_A49TicketHoraResponsable = new DateTime[] {DateTime.MinValue} ;
         T000726_A47TicketFechaResponsable = new DateTime[] {DateTime.MinValue} ;
         T000726_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000726_A25EstadoTicketTecnicoNombre = new string[] {""} ;
         T000726_A145TicketResponsableInventarioSerie = new string[] {""} ;
         T000726_n145TicketResponsableInventarioSerie = new bool[] {false} ;
         T000726_A146TicketResponsableInstalacion = new bool[] {false} ;
         T000726_n146TicketResponsableInstalacion = new bool[] {false} ;
         T000726_A147TicketResponsableConfiguracion = new bool[] {false} ;
         T000726_n147TicketResponsableConfiguracion = new bool[] {false} ;
         T000726_A148TicketResponsableInternetRouter = new bool[] {false} ;
         T000726_n148TicketResponsableInternetRouter = new bool[] {false} ;
         T000726_A149TicketResponsableFormateo = new bool[] {false} ;
         T000726_n149TicketResponsableFormateo = new bool[] {false} ;
         T000726_A150TicketResponsableReparacion = new bool[] {false} ;
         T000726_n150TicketResponsableReparacion = new bool[] {false} ;
         T000726_A151TicketResponsableLimpieza = new bool[] {false} ;
         T000726_n151TicketResponsableLimpieza = new bool[] {false} ;
         T000726_A152TicketResponsablePuntoRed = new bool[] {false} ;
         T000726_n152TicketResponsablePuntoRed = new bool[] {false} ;
         T000726_A153TicketResponsableCambiosHardware = new bool[] {false} ;
         T000726_n153TicketResponsableCambiosHardware = new bool[] {false} ;
         T000726_A154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         T000726_n154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         T000726_A165TicketResponsableCerrado = new bool[] {false} ;
         T000726_n165TicketResponsableCerrado = new bool[] {false} ;
         T000726_A166TicketResponsablePendiente = new bool[] {false} ;
         T000726_n166TicketResponsablePendiente = new bool[] {false} ;
         T000726_A167TicketResponsablePasaTaller = new bool[] {false} ;
         T000726_n167TicketResponsablePasaTaller = new bool[] {false} ;
         T000726_A168TicketResponsableObservacion = new string[] {""} ;
         T000726_n168TicketResponsableObservacion = new bool[] {false} ;
         T000726_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         T000726_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         T000726_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T000726_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         T000726_A177TicketResponsableRamTxt = new string[] {""} ;
         T000726_n177TicketResponsableRamTxt = new bool[] {false} ;
         T000726_A178TicketResponsableDiscoDuroTxt = new string[] {""} ;
         T000726_n178TicketResponsableDiscoDuroTxt = new bool[] {false} ;
         T000726_A179TicketResponsableProcesadorTxt = new string[] {""} ;
         T000726_n179TicketResponsableProcesadorTxt = new bool[] {false} ;
         T000726_A180TicketResponsableMaletinTxt = new string[] {""} ;
         T000726_n180TicketResponsableMaletinTxt = new bool[] {false} ;
         T000726_A181TicketResponsableTonerCintaTxt = new string[] {""} ;
         T000726_n181TicketResponsableTonerCintaTxt = new bool[] {false} ;
         T000726_A182TicketResponsableTarjetaVideoExtraTxt = new string[] {""} ;
         T000726_n182TicketResponsableTarjetaVideoExtraTxt = new bool[] {false} ;
         T000726_A183TicketResponsableCargadorLaptopTxt = new string[] {""} ;
         T000726_n183TicketResponsableCargadorLaptopTxt = new bool[] {false} ;
         T000726_A184TicketResponsableCDsDVDsTxt = new string[] {""} ;
         T000726_n184TicketResponsableCDsDVDsTxt = new bool[] {false} ;
         T000726_A185TicketResponsableCableEspecialTxt = new string[] {""} ;
         T000726_n185TicketResponsableCableEspecialTxt = new bool[] {false} ;
         T000726_A186TicketResponsableOtrosTallerTxt = new string[] {""} ;
         T000726_n186TicketResponsableOtrosTallerTxt = new bool[] {false} ;
         T000726_A287TicketResponsableFechaHoraAsigna = new DateTime[] {DateTime.MinValue} ;
         T000726_n287TicketResponsableFechaHoraAsigna = new bool[] {false} ;
         T000726_A288TicketResponsableFechaHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T000726_n288TicketResponsableFechaHoraResuelve = new bool[] {false} ;
         T000726_A291EtapaDesarrolloNombre = new string[] {""} ;
         T000726_A290EtapaDesarrolloId = new short[1] ;
         T000726_n290EtapaDesarrolloId = new bool[] {false} ;
         T000726_A17EstadoTicketTecnicoId = new short[1] ;
         T000726_A198TicketTecnicoResponsableId = new short[1] ;
         T00076_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000727_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000728_A14TicketId = new long[1] ;
         T000728_A16TicketResponsableId = new long[1] ;
         T00073_A14TicketId = new long[1] ;
         T00073_A16TicketResponsableId = new long[1] ;
         T00073_A49TicketHoraResponsable = new DateTime[] {DateTime.MinValue} ;
         T00073_A47TicketFechaResponsable = new DateTime[] {DateTime.MinValue} ;
         T00073_A145TicketResponsableInventarioSerie = new string[] {""} ;
         T00073_n145TicketResponsableInventarioSerie = new bool[] {false} ;
         T00073_A146TicketResponsableInstalacion = new bool[] {false} ;
         T00073_n146TicketResponsableInstalacion = new bool[] {false} ;
         T00073_A147TicketResponsableConfiguracion = new bool[] {false} ;
         T00073_n147TicketResponsableConfiguracion = new bool[] {false} ;
         T00073_A148TicketResponsableInternetRouter = new bool[] {false} ;
         T00073_n148TicketResponsableInternetRouter = new bool[] {false} ;
         T00073_A149TicketResponsableFormateo = new bool[] {false} ;
         T00073_n149TicketResponsableFormateo = new bool[] {false} ;
         T00073_A150TicketResponsableReparacion = new bool[] {false} ;
         T00073_n150TicketResponsableReparacion = new bool[] {false} ;
         T00073_A151TicketResponsableLimpieza = new bool[] {false} ;
         T00073_n151TicketResponsableLimpieza = new bool[] {false} ;
         T00073_A152TicketResponsablePuntoRed = new bool[] {false} ;
         T00073_n152TicketResponsablePuntoRed = new bool[] {false} ;
         T00073_A153TicketResponsableCambiosHardware = new bool[] {false} ;
         T00073_n153TicketResponsableCambiosHardware = new bool[] {false} ;
         T00073_A154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         T00073_n154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         T00073_A165TicketResponsableCerrado = new bool[] {false} ;
         T00073_n165TicketResponsableCerrado = new bool[] {false} ;
         T00073_A166TicketResponsablePendiente = new bool[] {false} ;
         T00073_n166TicketResponsablePendiente = new bool[] {false} ;
         T00073_A167TicketResponsablePasaTaller = new bool[] {false} ;
         T00073_n167TicketResponsablePasaTaller = new bool[] {false} ;
         T00073_A168TicketResponsableObservacion = new string[] {""} ;
         T00073_n168TicketResponsableObservacion = new bool[] {false} ;
         T00073_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         T00073_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         T00073_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T00073_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         T00073_A177TicketResponsableRamTxt = new string[] {""} ;
         T00073_n177TicketResponsableRamTxt = new bool[] {false} ;
         T00073_A178TicketResponsableDiscoDuroTxt = new string[] {""} ;
         T00073_n178TicketResponsableDiscoDuroTxt = new bool[] {false} ;
         T00073_A179TicketResponsableProcesadorTxt = new string[] {""} ;
         T00073_n179TicketResponsableProcesadorTxt = new bool[] {false} ;
         T00073_A180TicketResponsableMaletinTxt = new string[] {""} ;
         T00073_n180TicketResponsableMaletinTxt = new bool[] {false} ;
         T00073_A181TicketResponsableTonerCintaTxt = new string[] {""} ;
         T00073_n181TicketResponsableTonerCintaTxt = new bool[] {false} ;
         T00073_A182TicketResponsableTarjetaVideoExtraTxt = new string[] {""} ;
         T00073_n182TicketResponsableTarjetaVideoExtraTxt = new bool[] {false} ;
         T00073_A183TicketResponsableCargadorLaptopTxt = new string[] {""} ;
         T00073_n183TicketResponsableCargadorLaptopTxt = new bool[] {false} ;
         T00073_A184TicketResponsableCDsDVDsTxt = new string[] {""} ;
         T00073_n184TicketResponsableCDsDVDsTxt = new bool[] {false} ;
         T00073_A185TicketResponsableCableEspecialTxt = new string[] {""} ;
         T00073_n185TicketResponsableCableEspecialTxt = new bool[] {false} ;
         T00073_A186TicketResponsableOtrosTallerTxt = new string[] {""} ;
         T00073_n186TicketResponsableOtrosTallerTxt = new bool[] {false} ;
         T00073_A287TicketResponsableFechaHoraAsigna = new DateTime[] {DateTime.MinValue} ;
         T00073_n287TicketResponsableFechaHoraAsigna = new bool[] {false} ;
         T00073_A288TicketResponsableFechaHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T00073_n288TicketResponsableFechaHoraResuelve = new bool[] {false} ;
         T00073_A290EtapaDesarrolloId = new short[1] ;
         T00073_n290EtapaDesarrolloId = new bool[] {false} ;
         T00073_A17EstadoTicketTecnicoId = new short[1] ;
         T00073_A198TicketTecnicoResponsableId = new short[1] ;
         T00072_A14TicketId = new long[1] ;
         T00072_A16TicketResponsableId = new long[1] ;
         T00072_A49TicketHoraResponsable = new DateTime[] {DateTime.MinValue} ;
         T00072_A47TicketFechaResponsable = new DateTime[] {DateTime.MinValue} ;
         T00072_A145TicketResponsableInventarioSerie = new string[] {""} ;
         T00072_n145TicketResponsableInventarioSerie = new bool[] {false} ;
         T00072_A146TicketResponsableInstalacion = new bool[] {false} ;
         T00072_n146TicketResponsableInstalacion = new bool[] {false} ;
         T00072_A147TicketResponsableConfiguracion = new bool[] {false} ;
         T00072_n147TicketResponsableConfiguracion = new bool[] {false} ;
         T00072_A148TicketResponsableInternetRouter = new bool[] {false} ;
         T00072_n148TicketResponsableInternetRouter = new bool[] {false} ;
         T00072_A149TicketResponsableFormateo = new bool[] {false} ;
         T00072_n149TicketResponsableFormateo = new bool[] {false} ;
         T00072_A150TicketResponsableReparacion = new bool[] {false} ;
         T00072_n150TicketResponsableReparacion = new bool[] {false} ;
         T00072_A151TicketResponsableLimpieza = new bool[] {false} ;
         T00072_n151TicketResponsableLimpieza = new bool[] {false} ;
         T00072_A152TicketResponsablePuntoRed = new bool[] {false} ;
         T00072_n152TicketResponsablePuntoRed = new bool[] {false} ;
         T00072_A153TicketResponsableCambiosHardware = new bool[] {false} ;
         T00072_n153TicketResponsableCambiosHardware = new bool[] {false} ;
         T00072_A154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         T00072_n154TicketResponsableCopiasRespaldo = new bool[] {false} ;
         T00072_A165TicketResponsableCerrado = new bool[] {false} ;
         T00072_n165TicketResponsableCerrado = new bool[] {false} ;
         T00072_A166TicketResponsablePendiente = new bool[] {false} ;
         T00072_n166TicketResponsablePendiente = new bool[] {false} ;
         T00072_A167TicketResponsablePasaTaller = new bool[] {false} ;
         T00072_n167TicketResponsablePasaTaller = new bool[] {false} ;
         T00072_A168TicketResponsableObservacion = new string[] {""} ;
         T00072_n168TicketResponsableObservacion = new bool[] {false} ;
         T00072_A175TicketResponsableFechaResuelve = new DateTime[] {DateTime.MinValue} ;
         T00072_n175TicketResponsableFechaResuelve = new bool[] {false} ;
         T00072_A176TicketResponsableHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T00072_n176TicketResponsableHoraResuelve = new bool[] {false} ;
         T00072_A177TicketResponsableRamTxt = new string[] {""} ;
         T00072_n177TicketResponsableRamTxt = new bool[] {false} ;
         T00072_A178TicketResponsableDiscoDuroTxt = new string[] {""} ;
         T00072_n178TicketResponsableDiscoDuroTxt = new bool[] {false} ;
         T00072_A179TicketResponsableProcesadorTxt = new string[] {""} ;
         T00072_n179TicketResponsableProcesadorTxt = new bool[] {false} ;
         T00072_A180TicketResponsableMaletinTxt = new string[] {""} ;
         T00072_n180TicketResponsableMaletinTxt = new bool[] {false} ;
         T00072_A181TicketResponsableTonerCintaTxt = new string[] {""} ;
         T00072_n181TicketResponsableTonerCintaTxt = new bool[] {false} ;
         T00072_A182TicketResponsableTarjetaVideoExtraTxt = new string[] {""} ;
         T00072_n182TicketResponsableTarjetaVideoExtraTxt = new bool[] {false} ;
         T00072_A183TicketResponsableCargadorLaptopTxt = new string[] {""} ;
         T00072_n183TicketResponsableCargadorLaptopTxt = new bool[] {false} ;
         T00072_A184TicketResponsableCDsDVDsTxt = new string[] {""} ;
         T00072_n184TicketResponsableCDsDVDsTxt = new bool[] {false} ;
         T00072_A185TicketResponsableCableEspecialTxt = new string[] {""} ;
         T00072_n185TicketResponsableCableEspecialTxt = new bool[] {false} ;
         T00072_A186TicketResponsableOtrosTallerTxt = new string[] {""} ;
         T00072_n186TicketResponsableOtrosTallerTxt = new bool[] {false} ;
         T00072_A287TicketResponsableFechaHoraAsigna = new DateTime[] {DateTime.MinValue} ;
         T00072_n287TicketResponsableFechaHoraAsigna = new bool[] {false} ;
         T00072_A288TicketResponsableFechaHoraResuelve = new DateTime[] {DateTime.MinValue} ;
         T00072_n288TicketResponsableFechaHoraResuelve = new bool[] {false} ;
         T00072_A290EtapaDesarrolloId = new short[1] ;
         T00072_n290EtapaDesarrolloId = new bool[] {false} ;
         T00072_A17EstadoTicketTecnicoId = new short[1] ;
         T00072_A198TicketTecnicoResponsableId = new short[1] ;
         T000732_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000733_A18TicketTecnicoId = new long[1] ;
         T000734_A7SatisfaccionId = new long[1] ;
         T000735_A14TicketId = new long[1] ;
         T000735_A16TicketResponsableId = new long[1] ;
         GridresponsableRow = new GXWebRow();
         subGridresponsable_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i46TicketFecha = DateTime.MinValue;
         i48TicketHora = (DateTime)(DateTime.MinValue);
         i278TicketUsuarioAsigno = "";
         i49TicketHoraResponsable = (DateTime)(DateTime.MinValue);
         i47TicketFechaResponsable = DateTime.MinValue;
         sCtrlGx_mode = "";
         sCtrlAV7TicketId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ticket__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.ticket__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.ticket__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ticket__default(),
            new Object[][] {
                new Object[] {
               T00072_A14TicketId, T00072_A16TicketResponsableId, T00072_A49TicketHoraResponsable, T00072_A47TicketFechaResponsable, T00072_A145TicketResponsableInventarioSerie, T00072_n145TicketResponsableInventarioSerie, T00072_A146TicketResponsableInstalacion, T00072_n146TicketResponsableInstalacion, T00072_A147TicketResponsableConfiguracion, T00072_n147TicketResponsableConfiguracion,
               T00072_A148TicketResponsableInternetRouter, T00072_n148TicketResponsableInternetRouter, T00072_A149TicketResponsableFormateo, T00072_n149TicketResponsableFormateo, T00072_A150TicketResponsableReparacion, T00072_n150TicketResponsableReparacion, T00072_A151TicketResponsableLimpieza, T00072_n151TicketResponsableLimpieza, T00072_A152TicketResponsablePuntoRed, T00072_n152TicketResponsablePuntoRed,
               T00072_A153TicketResponsableCambiosHardware, T00072_n153TicketResponsableCambiosHardware, T00072_A154TicketResponsableCopiasRespaldo, T00072_n154TicketResponsableCopiasRespaldo, T00072_A165TicketResponsableCerrado, T00072_n165TicketResponsableCerrado, T00072_A166TicketResponsablePendiente, T00072_n166TicketResponsablePendiente, T00072_A167TicketResponsablePasaTaller, T00072_n167TicketResponsablePasaTaller,
               T00072_A168TicketResponsableObservacion, T00072_n168TicketResponsableObservacion, T00072_A175TicketResponsableFechaResuelve, T00072_n175TicketResponsableFechaResuelve, T00072_A176TicketResponsableHoraResuelve, T00072_n176TicketResponsableHoraResuelve, T00072_A177TicketResponsableRamTxt, T00072_n177TicketResponsableRamTxt, T00072_A178TicketResponsableDiscoDuroTxt, T00072_n178TicketResponsableDiscoDuroTxt,
               T00072_A179TicketResponsableProcesadorTxt, T00072_n179TicketResponsableProcesadorTxt, T00072_A180TicketResponsableMaletinTxt, T00072_n180TicketResponsableMaletinTxt, T00072_A181TicketResponsableTonerCintaTxt, T00072_n181TicketResponsableTonerCintaTxt, T00072_A182TicketResponsableTarjetaVideoExtraTxt, T00072_n182TicketResponsableTarjetaVideoExtraTxt, T00072_A183TicketResponsableCargadorLaptopTxt, T00072_n183TicketResponsableCargadorLaptopTxt,
               T00072_A184TicketResponsableCDsDVDsTxt, T00072_n184TicketResponsableCDsDVDsTxt, T00072_A185TicketResponsableCableEspecialTxt, T00072_n185TicketResponsableCableEspecialTxt, T00072_A186TicketResponsableOtrosTallerTxt, T00072_n186TicketResponsableOtrosTallerTxt, T00072_A287TicketResponsableFechaHoraAsigna, T00072_n287TicketResponsableFechaHoraAsigna, T00072_A288TicketResponsableFechaHoraResuelve, T00072_n288TicketResponsableFechaHoraResuelve,
               T00072_A290EtapaDesarrolloId, T00072_n290EtapaDesarrolloId, T00072_A17EstadoTicketTecnicoId, T00072_A198TicketTecnicoResponsableId
               }
               , new Object[] {
               T00073_A14TicketId, T00073_A16TicketResponsableId, T00073_A49TicketHoraResponsable, T00073_A47TicketFechaResponsable, T00073_A145TicketResponsableInventarioSerie, T00073_n145TicketResponsableInventarioSerie, T00073_A146TicketResponsableInstalacion, T00073_n146TicketResponsableInstalacion, T00073_A147TicketResponsableConfiguracion, T00073_n147TicketResponsableConfiguracion,
               T00073_A148TicketResponsableInternetRouter, T00073_n148TicketResponsableInternetRouter, T00073_A149TicketResponsableFormateo, T00073_n149TicketResponsableFormateo, T00073_A150TicketResponsableReparacion, T00073_n150TicketResponsableReparacion, T00073_A151TicketResponsableLimpieza, T00073_n151TicketResponsableLimpieza, T00073_A152TicketResponsablePuntoRed, T00073_n152TicketResponsablePuntoRed,
               T00073_A153TicketResponsableCambiosHardware, T00073_n153TicketResponsableCambiosHardware, T00073_A154TicketResponsableCopiasRespaldo, T00073_n154TicketResponsableCopiasRespaldo, T00073_A165TicketResponsableCerrado, T00073_n165TicketResponsableCerrado, T00073_A166TicketResponsablePendiente, T00073_n166TicketResponsablePendiente, T00073_A167TicketResponsablePasaTaller, T00073_n167TicketResponsablePasaTaller,
               T00073_A168TicketResponsableObservacion, T00073_n168TicketResponsableObservacion, T00073_A175TicketResponsableFechaResuelve, T00073_n175TicketResponsableFechaResuelve, T00073_A176TicketResponsableHoraResuelve, T00073_n176TicketResponsableHoraResuelve, T00073_A177TicketResponsableRamTxt, T00073_n177TicketResponsableRamTxt, T00073_A178TicketResponsableDiscoDuroTxt, T00073_n178TicketResponsableDiscoDuroTxt,
               T00073_A179TicketResponsableProcesadorTxt, T00073_n179TicketResponsableProcesadorTxt, T00073_A180TicketResponsableMaletinTxt, T00073_n180TicketResponsableMaletinTxt, T00073_A181TicketResponsableTonerCintaTxt, T00073_n181TicketResponsableTonerCintaTxt, T00073_A182TicketResponsableTarjetaVideoExtraTxt, T00073_n182TicketResponsableTarjetaVideoExtraTxt, T00073_A183TicketResponsableCargadorLaptopTxt, T00073_n183TicketResponsableCargadorLaptopTxt,
               T00073_A184TicketResponsableCDsDVDsTxt, T00073_n184TicketResponsableCDsDVDsTxt, T00073_A185TicketResponsableCableEspecialTxt, T00073_n185TicketResponsableCableEspecialTxt, T00073_A186TicketResponsableOtrosTallerTxt, T00073_n186TicketResponsableOtrosTallerTxt, T00073_A287TicketResponsableFechaHoraAsigna, T00073_n287TicketResponsableFechaHoraAsigna, T00073_A288TicketResponsableFechaHoraResuelve, T00073_n288TicketResponsableFechaHoraResuelve,
               T00073_A290EtapaDesarrolloId, T00073_n290EtapaDesarrolloId, T00073_A17EstadoTicketTecnicoId, T00073_A198TicketTecnicoResponsableId
               }
               , new Object[] {
               T00074_A291EtapaDesarrolloNombre
               }
               , new Object[] {
               T00075_A25EstadoTicketTecnicoNombre
               }
               , new Object[] {
               T00076_A199TicketTecnicoResponsableNombre
               }
               , new Object[] {
               T00077_A14TicketId, T00077_A46TicketFecha, T00077_A48TicketHora, T00077_A54TicketLastId, T00077_A285TicketHoraCaracter, T00077_A53TicketLaptop, T00077_A42TicketDesktop, T00077_A55TicketMonitor, T00077_A50TicketImpresora, T00077_A45TicketEscaner,
               T00077_A59TicketRouter, T00077_A60TicketSistemaOperativo, T00077_A56TicketOffice, T00077_A39TicketAntivirus, T00077_A40TicketAplicacion, T00077_A44TicketDisenio, T00077_A51TicketIngenieria, T00077_A43TicketDiscoDuroExterno, T00077_A58TicketPerifericos, T00077_A87TicketUps,
               T00077_A41TicketApoyoUsuario, T00077_A52TicketInstalarDataShow, T00077_A57TicketOtros, T00077_A278TicketUsuarioAsigno, T00077_A289TicketFechaHora, T00077_n289TicketFechaHora, T00077_A15UsuarioId, T00077_A187EstadoTicketTicketId
               }
               , new Object[] {
               T00078_A14TicketId, T00078_A46TicketFecha, T00078_A48TicketHora, T00078_A54TicketLastId, T00078_A285TicketHoraCaracter, T00078_A53TicketLaptop, T00078_A42TicketDesktop, T00078_A55TicketMonitor, T00078_A50TicketImpresora, T00078_A45TicketEscaner,
               T00078_A59TicketRouter, T00078_A60TicketSistemaOperativo, T00078_A56TicketOffice, T00078_A39TicketAntivirus, T00078_A40TicketAplicacion, T00078_A44TicketDisenio, T00078_A51TicketIngenieria, T00078_A43TicketDiscoDuroExterno, T00078_A58TicketPerifericos, T00078_A87TicketUps,
               T00078_A41TicketApoyoUsuario, T00078_A52TicketInstalarDataShow, T00078_A57TicketOtros, T00078_A278TicketUsuarioAsigno, T00078_A289TicketFechaHora, T00078_n289TicketFechaHora, T00078_A15UsuarioId, T00078_A187EstadoTicketTicketId
               }
               , new Object[] {
               T00079_A93UsuarioNombre, T00079_A94UsuarioRequerimiento, T00079_A91UsuarioGerencia, T00079_A88UsuarioDepartamento
               }
               , new Object[] {
               T000710_A188EstadoTicketTicketNombre
               }
               , new Object[] {
               T000711_A14TicketId, T000711_A46TicketFecha, T000711_A48TicketHora, T000711_A93UsuarioNombre, T000711_A94UsuarioRequerimiento, T000711_A91UsuarioGerencia, T000711_A88UsuarioDepartamento, T000711_A188EstadoTicketTicketNombre, T000711_A54TicketLastId, T000711_A285TicketHoraCaracter,
               T000711_A53TicketLaptop, T000711_A42TicketDesktop, T000711_A55TicketMonitor, T000711_A50TicketImpresora, T000711_A45TicketEscaner, T000711_A59TicketRouter, T000711_A60TicketSistemaOperativo, T000711_A56TicketOffice, T000711_A39TicketAntivirus, T000711_A40TicketAplicacion,
               T000711_A44TicketDisenio, T000711_A51TicketIngenieria, T000711_A43TicketDiscoDuroExterno, T000711_A58TicketPerifericos, T000711_A87TicketUps, T000711_A41TicketApoyoUsuario, T000711_A52TicketInstalarDataShow, T000711_A57TicketOtros, T000711_A278TicketUsuarioAsigno, T000711_A289TicketFechaHora,
               T000711_n289TicketFechaHora, T000711_A15UsuarioId, T000711_A187EstadoTicketTicketId
               }
               , new Object[] {
               T000712_A93UsuarioNombre, T000712_A94UsuarioRequerimiento, T000712_A91UsuarioGerencia, T000712_A88UsuarioDepartamento
               }
               , new Object[] {
               T000713_A188EstadoTicketTicketNombre
               }
               , new Object[] {
               T000714_A14TicketId
               }
               , new Object[] {
               T000715_A14TicketId
               }
               , new Object[] {
               T000716_A14TicketId
               }
               , new Object[] {
               T000717_A14TicketId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000720_A93UsuarioNombre, T000720_A94UsuarioRequerimiento, T000720_A91UsuarioGerencia, T000720_A88UsuarioDepartamento
               }
               , new Object[] {
               T000721_A188EstadoTicketTicketNombre
               }
               , new Object[] {
               T000722_A202SoporteTecnicoId
               }
               , new Object[] {
               T000723_A7SatisfaccionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000725_A14TicketId
               }
               , new Object[] {
               T000726_A14TicketId, T000726_A16TicketResponsableId, T000726_A49TicketHoraResponsable, T000726_A47TicketFechaResponsable, T000726_A199TicketTecnicoResponsableNombre, T000726_A25EstadoTicketTecnicoNombre, T000726_A145TicketResponsableInventarioSerie, T000726_n145TicketResponsableInventarioSerie, T000726_A146TicketResponsableInstalacion, T000726_n146TicketResponsableInstalacion,
               T000726_A147TicketResponsableConfiguracion, T000726_n147TicketResponsableConfiguracion, T000726_A148TicketResponsableInternetRouter, T000726_n148TicketResponsableInternetRouter, T000726_A149TicketResponsableFormateo, T000726_n149TicketResponsableFormateo, T000726_A150TicketResponsableReparacion, T000726_n150TicketResponsableReparacion, T000726_A151TicketResponsableLimpieza, T000726_n151TicketResponsableLimpieza,
               T000726_A152TicketResponsablePuntoRed, T000726_n152TicketResponsablePuntoRed, T000726_A153TicketResponsableCambiosHardware, T000726_n153TicketResponsableCambiosHardware, T000726_A154TicketResponsableCopiasRespaldo, T000726_n154TicketResponsableCopiasRespaldo, T000726_A165TicketResponsableCerrado, T000726_n165TicketResponsableCerrado, T000726_A166TicketResponsablePendiente, T000726_n166TicketResponsablePendiente,
               T000726_A167TicketResponsablePasaTaller, T000726_n167TicketResponsablePasaTaller, T000726_A168TicketResponsableObservacion, T000726_n168TicketResponsableObservacion, T000726_A175TicketResponsableFechaResuelve, T000726_n175TicketResponsableFechaResuelve, T000726_A176TicketResponsableHoraResuelve, T000726_n176TicketResponsableHoraResuelve, T000726_A177TicketResponsableRamTxt, T000726_n177TicketResponsableRamTxt,
               T000726_A178TicketResponsableDiscoDuroTxt, T000726_n178TicketResponsableDiscoDuroTxt, T000726_A179TicketResponsableProcesadorTxt, T000726_n179TicketResponsableProcesadorTxt, T000726_A180TicketResponsableMaletinTxt, T000726_n180TicketResponsableMaletinTxt, T000726_A181TicketResponsableTonerCintaTxt, T000726_n181TicketResponsableTonerCintaTxt, T000726_A182TicketResponsableTarjetaVideoExtraTxt, T000726_n182TicketResponsableTarjetaVideoExtraTxt,
               T000726_A183TicketResponsableCargadorLaptopTxt, T000726_n183TicketResponsableCargadorLaptopTxt, T000726_A184TicketResponsableCDsDVDsTxt, T000726_n184TicketResponsableCDsDVDsTxt, T000726_A185TicketResponsableCableEspecialTxt, T000726_n185TicketResponsableCableEspecialTxt, T000726_A186TicketResponsableOtrosTallerTxt, T000726_n186TicketResponsableOtrosTallerTxt, T000726_A287TicketResponsableFechaHoraAsigna, T000726_n287TicketResponsableFechaHoraAsigna,
               T000726_A288TicketResponsableFechaHoraResuelve, T000726_n288TicketResponsableFechaHoraResuelve, T000726_A291EtapaDesarrolloNombre, T000726_A290EtapaDesarrolloId, T000726_n290EtapaDesarrolloId, T000726_A17EstadoTicketTecnicoId, T000726_A198TicketTecnicoResponsableId
               }
               , new Object[] {
               T000727_A199TicketTecnicoResponsableNombre
               }
               , new Object[] {
               T000728_A14TicketId, T000728_A16TicketResponsableId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000732_A199TicketTecnicoResponsableNombre
               }
               , new Object[] {
               T000733_A18TicketTecnicoId
               }
               , new Object[] {
               T000734_A7SatisfaccionId
               }
               , new Object[] {
               T000735_A14TicketId, T000735_A16TicketResponsableId
               }
            }
         );
         AV30Pgmname = "Ticket";
         Z278TicketUsuarioAsigno = AV28WebSession.Get("UsuarioConectado");
         A278TicketUsuarioAsigno = AV28WebSession.Get("UsuarioConectado");
         i278TicketUsuarioAsigno = AV28WebSession.Get("UsuarioConectado");
         Z17EstadoTicketTecnicoId = 3;
         A17EstadoTicketTecnicoId = 3;
         i17EstadoTicketTecnicoId = 3;
         Z187EstadoTicketTicketId = 3;
         N187EstadoTicketTicketId = 3;
         i187EstadoTicketTicketId = 3;
         A187EstadoTicketTicketId = 3;
         Z47TicketFechaResponsable = DateTimeUtil.Today( context);
         A47TicketFechaResponsable = DateTimeUtil.Today( context);
         i47TicketFechaResponsable = DateTimeUtil.Today( context);
         Z48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         i48TicketHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         Z49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         i49TicketHoraResponsable = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         Z46TicketFecha = DateTimeUtil.Today( context);
         A46TicketFecha = DateTimeUtil.Today( context);
         i46TicketFecha = DateTimeUtil.Today( context);
      }

      private short nIsMod_8 ;
      private short Z15UsuarioId ;
      private short Z187EstadoTicketTicketId ;
      private short N15UsuarioId ;
      private short N187EstadoTicketTicketId ;
      private short Z290EtapaDesarrolloId ;
      private short Z17EstadoTicketTecnicoId ;
      private short Z198TicketTecnicoResponsableId ;
      private short nRcdDeleted_8 ;
      private short nRcdExists_8 ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A15UsuarioId ;
      private short A187EstadoTicketTicketId ;
      private short A198TicketTecnicoResponsableId ;
      private short Gx_BScreen ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridresponsable_Backcolorstyle ;
      private short subGridresponsable_Sortable ;
      private short A17EstadoTicketTecnicoId ;
      private short subGridresponsable_Allowselection ;
      private short subGridresponsable_Allowhovering ;
      private short subGridresponsable_Allowcollapsing ;
      private short subGridresponsable_Collapsed ;
      private short nBlankRcdCount8 ;
      private short RcdFound8 ;
      private short nBlankRcdUsr8 ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV12Insert_UsuarioId ;
      private short AV26Insert_EstadoTicketTicketId ;
      private short A290EtapaDesarrolloId ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short nIsDirty_7 ;
      private short nIsDirty_8 ;
      private short subGridresponsable_Backstyle ;
      private short i187EstadoTicketTicketId ;
      private short i17EstadoTicketTecnicoId ;
      private int nRC_GXsfl_242 ;
      private int nGXsfl_242_idx=1 ;
      private int trnEnded ;
      private int edtUsuarioId_Enabled ;
      private int imgprompt_15_Visible ;
      private int edtTicketId_Enabled ;
      private int edtTicketFecha_Enabled ;
      private int edtTicketHora_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioRequerimiento_Enabled ;
      private int edtEstadoTicketTicketNombre_Enabled ;
      private int divK2btoolstable_attributecontainerestadoticketticketid_Visible ;
      private int edtEstadoTicketTicketId_Enabled ;
      private int imgprompt_187_Visible ;
      private int divK2btoolstable_attributecontainerticketlastid_Visible ;
      private int edtTicketLastId_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int edtTicketResponsableId_Enabled ;
      private int edtTicketTecnicoResponsableId_Enabled ;
      private int edtTicketTecnicoResponsableNombre_Enabled ;
      private int edtTicketFechaResponsable_Enabled ;
      private int edtTicketHoraResponsable_Enabled ;
      private int edtEstadoTicketTecnicoId_Enabled ;
      private int edtEstadoTicketTecnicoNombre_Enabled ;
      private int subGridresponsable_Selectedindex ;
      private int subGridresponsable_Selectioncolor ;
      private int subGridresponsable_Hoveringcolor ;
      private int subGridresponsable_Rows ;
      private int fRowAdded ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV31GXV1 ;
      private int subGridresponsable_Backcolor ;
      private int subGridresponsable_Allbackcolor ;
      private int imgprompt_198_Visible ;
      private int defedtEstadoTicketTecnicoNombre_Enabled ;
      private int defedtEstadoTicketTecnicoId_Enabled ;
      private int defedtTicketHoraResponsable_Enabled ;
      private int defedtTicketFechaResponsable_Enabled ;
      private int defedtTicketResponsableId_Enabled ;
      private int idxLst ;
      private long wcpOAV7TicketId ;
      private long Z14TicketId ;
      private long Z54TicketLastId ;
      private long O54TicketLastId ;
      private long Z16TicketResponsableId ;
      private long AV7TicketId ;
      private long A54TicketLastId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long B54TicketLastId ;
      private long s54TicketLastId ;
      private long i54TicketLastId ;
      private string sPrefix ;
      private string sGXsfl_242_idx="0001" ;
      private string wcpOGx_mode ;
      private string Z285TicketHoraCaracter ;
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
      private string edtUsuarioId_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divTabletextblocklnreqsopteccontainer_Internalname ;
      private string lblLnreqsoptec_Internalname ;
      private string lblLnreqsoptec_Jsonclick ;
      private string divClmid_Internalname ;
      private string divTableclmid0_Internalname ;
      private string divK2btoolstable_attributecontainerusuarioid_Internalname ;
      private string TempTags ;
      private string edtUsuarioId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_15_Internalname ;
      private string imgprompt_15_Link ;
      private string divTableclmid1_Internalname ;
      private string divK2btoolstable_attributecontainerticketid_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketId_Jsonclick ;
      private string divClmfecha_Internalname ;
      private string divTableclmfecha0_Internalname ;
      private string divK2btoolstable_attributecontainerticketfecha_Internalname ;
      private string edtTicketFecha_Internalname ;
      private string edtTicketFecha_Jsonclick ;
      private string edtTicketFecha_Class ;
      private string divTableclmfecha1_Internalname ;
      private string divK2btoolstable_attributecontainertickethora_Internalname ;
      private string edtTicketHora_Internalname ;
      private string edtTicketHora_Jsonclick ;
      private string divClmusuario_Internalname ;
      private string divTableclmusuario0_Internalname ;
      private string divK2btoolstable_attributecontainerusuarionombre_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioNombre_Link ;
      private string edtUsuarioNombre_Jsonclick ;
      private string divTableclmusuario1_Internalname ;
      private string divK2btoolstable_attributecontainerusuariorequerimiento_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string divClmestado_Internalname ;
      private string divTableclmestado0_Internalname ;
      private string divK2btoolstable_attributecontainerestadoticketticketnombre_Internalname ;
      private string edtEstadoTicketTicketNombre_Internalname ;
      private string edtEstadoTicketTicketNombre_Link ;
      private string edtEstadoTicketTicketNombre_Jsonclick ;
      private string divTableclmestado1_Internalname ;
      private string divK2btoolstable_attributecontainerestadoticketticketid_Internalname ;
      private string edtEstadoTicketTicketId_Internalname ;
      private string edtEstadoTicketTicketId_Jsonclick ;
      private string imgprompt_187_Internalname ;
      private string imgprompt_187_Link ;
      private string divTableclmestado2_Internalname ;
      private string divK2btoolstable_attributecontainerticketlastid_Internalname ;
      private string edtTicketLastId_Internalname ;
      private string edtTicketLastId_Jsonclick ;
      private string divClmcat_Internalname ;
      private string divTableclmcat0_Internalname ;
      private string divTabletextblocktxthardwarecontainer_Internalname ;
      private string lblTxthardware_Internalname ;
      private string lblTxthardware_Jsonclick ;
      private string divK2btoolstable_attributecontainerticketlaptop_Internalname ;
      private string chkTicketLaptop_Internalname ;
      private string divK2btoolstable_attributecontainerticketdesktop_Internalname ;
      private string chkTicketDesktop_Internalname ;
      private string divK2btoolstable_attributecontainerticketmonitor_Internalname ;
      private string chkTicketMonitor_Internalname ;
      private string divK2btoolstable_attributecontainerticketimpresora_Internalname ;
      private string chkTicketImpresora_Internalname ;
      private string divK2btoolstable_attributecontainerticketescaner_Internalname ;
      private string chkTicketEscaner_Internalname ;
      private string divK2btoolstable_attributecontainerticketrouter_Internalname ;
      private string chkTicketRouter_Internalname ;
      private string divTableclmcat1_Internalname ;
      private string divTabletextblocktxtsoftwarecontainer_Internalname ;
      private string lblTxtsoftware_Internalname ;
      private string lblTxtsoftware_Jsonclick ;
      private string divK2btoolstable_attributecontainerticketsistemaoperativo_Internalname ;
      private string chkTicketSistemaOperativo_Internalname ;
      private string divK2btoolstable_attributecontainerticketoffice_Internalname ;
      private string chkTicketOffice_Internalname ;
      private string divK2btoolstable_attributecontainerticketantivirus_Internalname ;
      private string chkTicketAntivirus_Internalname ;
      private string divK2btoolstable_attributecontainerticketaplicacion_Internalname ;
      private string chkTicketAplicacion_Internalname ;
      private string divK2btoolstable_attributecontainerticketdisenio_Internalname ;
      private string chkTicketDisenio_Internalname ;
      private string divK2btoolstable_attributecontainerticketingenieria_Internalname ;
      private string chkTicketIngenieria_Internalname ;
      private string divTableclmcat2_Internalname ;
      private string divTabletextblocktxtotroscontainer_Internalname ;
      private string lblTxtotros_Internalname ;
      private string lblTxtotros_Jsonclick ;
      private string divK2btoolstable_attributecontainerticketdiscoduroexterno_Internalname ;
      private string chkTicketDiscoDuroExterno_Internalname ;
      private string divK2btoolstable_attributecontainerticketperifericos_Internalname ;
      private string chkTicketPerifericos_Internalname ;
      private string divK2btoolstable_attributecontainerticketups_Internalname ;
      private string chkTicketUps_Internalname ;
      private string divK2btoolstable_attributecontainerticketapoyousuario_Internalname ;
      private string chkTicketApoyoUsuario_Internalname ;
      private string divK2btoolstable_attributecontainerticketinstalardatashow_Internalname ;
      private string chkTicketInstalarDataShow_Internalname ;
      private string divK2btoolstable_attributecontainerticketotros_Internalname ;
      private string chkTicketOtros_Internalname ;
      private string divK2btrnformmaintablecell2_Internalname ;
      private string divDiv_level_container_responsable_Internalname ;
      private string lblTextblock_header_responsable_Internalname ;
      private string lblTextblock_header_responsable_Jsonclick ;
      private string divMaingrid_responsivetable_gridresponsable_Internalname ;
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
      private string subGridresponsable_Header ;
      private string sMode8 ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string edtTicketFechaResponsable_Internalname ;
      private string edtTicketHoraResponsable_Internalname ;
      private string edtEstadoTicketTecnicoId_Internalname ;
      private string edtEstadoTicketTecnicoNombre_Internalname ;
      private string A285TicketHoraCaracter ;
      private string AV30Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string AV17StandardActivityType ;
      private string AV14BtnCaption ;
      private string AV15BtnTooltip ;
      private string AV20encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string imgprompt_198_Internalname ;
      private string sGXsfl_242_fel_idx="0001" ;
      private string subGridresponsable_Class ;
      private string subGridresponsable_Linesclass ;
      private string imgprompt_198_Link ;
      private string ROClassString ;
      private string edtTicketResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private string edtTicketFechaResponsable_Jsonclick ;
      private string edtTicketHoraResponsable_Jsonclick ;
      private string edtEstadoTicketTecnicoId_Jsonclick ;
      private string edtEstadoTicketTecnicoNombre_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7TicketId ;
      private string subGridresponsable_Internalname ;
      private DateTime Z48TicketHora ;
      private DateTime Z289TicketFechaHora ;
      private DateTime Z49TicketHoraResponsable ;
      private DateTime Z176TicketResponsableHoraResuelve ;
      private DateTime Z287TicketResponsableFechaHoraAsigna ;
      private DateTime Z288TicketResponsableFechaHoraResuelve ;
      private DateTime A48TicketHora ;
      private DateTime A49TicketHoraResponsable ;
      private DateTime A289TicketFechaHora ;
      private DateTime A176TicketResponsableHoraResuelve ;
      private DateTime A287TicketResponsableFechaHoraAsigna ;
      private DateTime A288TicketResponsableFechaHoraResuelve ;
      private DateTime i48TicketHora ;
      private DateTime i49TicketHoraResponsable ;
      private DateTime Z46TicketFecha ;
      private DateTime Z47TicketFechaResponsable ;
      private DateTime Z175TicketResponsableFechaResuelve ;
      private DateTime A46TicketFecha ;
      private DateTime A47TicketFechaResponsable ;
      private DateTime A175TicketResponsableFechaResuelve ;
      private DateTime i46TicketFecha ;
      private DateTime i47TicketFechaResponsable ;
      private bool Z53TicketLaptop ;
      private bool Z42TicketDesktop ;
      private bool Z55TicketMonitor ;
      private bool Z50TicketImpresora ;
      private bool Z45TicketEscaner ;
      private bool Z59TicketRouter ;
      private bool Z60TicketSistemaOperativo ;
      private bool Z56TicketOffice ;
      private bool Z39TicketAntivirus ;
      private bool Z40TicketAplicacion ;
      private bool Z44TicketDisenio ;
      private bool Z51TicketIngenieria ;
      private bool Z43TicketDiscoDuroExterno ;
      private bool Z58TicketPerifericos ;
      private bool Z87TicketUps ;
      private bool Z41TicketApoyoUsuario ;
      private bool Z52TicketInstalarDataShow ;
      private bool Z57TicketOtros ;
      private bool Z146TicketResponsableInstalacion ;
      private bool Z147TicketResponsableConfiguracion ;
      private bool Z148TicketResponsableInternetRouter ;
      private bool Z149TicketResponsableFormateo ;
      private bool Z150TicketResponsableReparacion ;
      private bool Z151TicketResponsableLimpieza ;
      private bool Z152TicketResponsablePuntoRed ;
      private bool Z153TicketResponsableCambiosHardware ;
      private bool Z154TicketResponsableCopiasRespaldo ;
      private bool Z165TicketResponsableCerrado ;
      private bool Z166TicketResponsablePendiente ;
      private bool Z167TicketResponsablePasaTaller ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A53TicketLaptop ;
      private bool A42TicketDesktop ;
      private bool A55TicketMonitor ;
      private bool A50TicketImpresora ;
      private bool A45TicketEscaner ;
      private bool A59TicketRouter ;
      private bool A60TicketSistemaOperativo ;
      private bool A56TicketOffice ;
      private bool A39TicketAntivirus ;
      private bool A40TicketAplicacion ;
      private bool A44TicketDisenio ;
      private bool A51TicketIngenieria ;
      private bool A43TicketDiscoDuroExterno ;
      private bool A58TicketPerifericos ;
      private bool A87TicketUps ;
      private bool A41TicketApoyoUsuario ;
      private bool A52TicketInstalarDataShow ;
      private bool A57TicketOtros ;
      private bool bGXsfl_242_Refreshing=false ;
      private bool n289TicketFechaHora ;
      private bool n145TicketResponsableInventarioSerie ;
      private bool A146TicketResponsableInstalacion ;
      private bool n146TicketResponsableInstalacion ;
      private bool A147TicketResponsableConfiguracion ;
      private bool n147TicketResponsableConfiguracion ;
      private bool A148TicketResponsableInternetRouter ;
      private bool n148TicketResponsableInternetRouter ;
      private bool A149TicketResponsableFormateo ;
      private bool n149TicketResponsableFormateo ;
      private bool A150TicketResponsableReparacion ;
      private bool n150TicketResponsableReparacion ;
      private bool A151TicketResponsableLimpieza ;
      private bool n151TicketResponsableLimpieza ;
      private bool A152TicketResponsablePuntoRed ;
      private bool n152TicketResponsablePuntoRed ;
      private bool A153TicketResponsableCambiosHardware ;
      private bool n153TicketResponsableCambiosHardware ;
      private bool A154TicketResponsableCopiasRespaldo ;
      private bool n154TicketResponsableCopiasRespaldo ;
      private bool A165TicketResponsableCerrado ;
      private bool n165TicketResponsableCerrado ;
      private bool A166TicketResponsablePendiente ;
      private bool n166TicketResponsablePendiente ;
      private bool A167TicketResponsablePasaTaller ;
      private bool n167TicketResponsablePasaTaller ;
      private bool n168TicketResponsableObservacion ;
      private bool n175TicketResponsableFechaResuelve ;
      private bool n176TicketResponsableHoraResuelve ;
      private bool n177TicketResponsableRamTxt ;
      private bool n178TicketResponsableDiscoDuroTxt ;
      private bool n179TicketResponsableProcesadorTxt ;
      private bool n180TicketResponsableMaletinTxt ;
      private bool n181TicketResponsableTonerCintaTxt ;
      private bool n182TicketResponsableTarjetaVideoExtraTxt ;
      private bool n183TicketResponsableCargadorLaptopTxt ;
      private bool n184TicketResponsableCDsDVDsTxt ;
      private bool n185TicketResponsableCableEspecialTxt ;
      private bool n186TicketResponsableOtrosTallerTxt ;
      private bool n287TicketResponsableFechaHoraAsigna ;
      private bool n288TicketResponsableFechaHoraResuelve ;
      private bool n290EtapaDesarrolloId ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Updateselects ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV19IsAuthorized ;
      private bool Gx_longc ;
      private bool GXt_boolean2 ;
      private string Z278TicketUsuarioAsigno ;
      private string Z145TicketResponsableInventarioSerie ;
      private string Z168TicketResponsableObservacion ;
      private string Z177TicketResponsableRamTxt ;
      private string Z178TicketResponsableDiscoDuroTxt ;
      private string Z179TicketResponsableProcesadorTxt ;
      private string Z180TicketResponsableMaletinTxt ;
      private string Z181TicketResponsableTonerCintaTxt ;
      private string Z182TicketResponsableTarjetaVideoExtraTxt ;
      private string Z183TicketResponsableCargadorLaptopTxt ;
      private string Z184TicketResponsableCDsDVDsTxt ;
      private string Z185TicketResponsableCableEspecialTxt ;
      private string Z186TicketResponsableOtrosTallerTxt ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A188EstadoTicketTicketNombre ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A25EstadoTicketTecnicoNombre ;
      private string A278TicketUsuarioAsigno ;
      private string A91UsuarioGerencia ;
      private string A88UsuarioDepartamento ;
      private string A145TicketResponsableInventarioSerie ;
      private string A168TicketResponsableObservacion ;
      private string A177TicketResponsableRamTxt ;
      private string A178TicketResponsableDiscoDuroTxt ;
      private string A179TicketResponsableProcesadorTxt ;
      private string A180TicketResponsableMaletinTxt ;
      private string A181TicketResponsableTonerCintaTxt ;
      private string A182TicketResponsableTarjetaVideoExtraTxt ;
      private string A183TicketResponsableCargadorLaptopTxt ;
      private string A184TicketResponsableCDsDVDsTxt ;
      private string A185TicketResponsableCableEspecialTxt ;
      private string A186TicketResponsableOtrosTallerTxt ;
      private string A291EtapaDesarrolloNombre ;
      private string AV18UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV16Url ;
      private string Z93UsuarioNombre ;
      private string Z94UsuarioRequerimiento ;
      private string Z91UsuarioGerencia ;
      private string Z88UsuarioDepartamento ;
      private string Z188EstadoTicketTicketNombre ;
      private string Z291EtapaDesarrolloNombre ;
      private string Z25EstadoTicketTecnicoNombre ;
      private string Z199TicketTecnicoResponsableNombre ;
      private string i278TicketUsuarioAsigno ;
      private IGxSession AV28WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid GridresponsableContainer ;
      private GXWebRow GridresponsableRow ;
      private GXWebColumn GridresponsableColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTicketLaptop ;
      private GXCheckbox chkTicketDesktop ;
      private GXCheckbox chkTicketMonitor ;
      private GXCheckbox chkTicketImpresora ;
      private GXCheckbox chkTicketEscaner ;
      private GXCheckbox chkTicketRouter ;
      private GXCheckbox chkTicketSistemaOperativo ;
      private GXCheckbox chkTicketOffice ;
      private GXCheckbox chkTicketAntivirus ;
      private GXCheckbox chkTicketAplicacion ;
      private GXCheckbox chkTicketDisenio ;
      private GXCheckbox chkTicketIngenieria ;
      private GXCheckbox chkTicketDiscoDuroExterno ;
      private GXCheckbox chkTicketPerifericos ;
      private GXCheckbox chkTicketUps ;
      private GXCheckbox chkTicketApoyoUsuario ;
      private GXCheckbox chkTicketInstalarDataShow ;
      private GXCheckbox chkTicketOtros ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private string[] T00079_A93UsuarioNombre ;
      private string[] T00079_A94UsuarioRequerimiento ;
      private string[] T00079_A91UsuarioGerencia ;
      private string[] T00079_A88UsuarioDepartamento ;
      private string[] T000710_A188EstadoTicketTicketNombre ;
      private long[] T000711_A14TicketId ;
      private DateTime[] T000711_A46TicketFecha ;
      private DateTime[] T000711_A48TicketHora ;
      private string[] T000711_A93UsuarioNombre ;
      private string[] T000711_A94UsuarioRequerimiento ;
      private string[] T000711_A91UsuarioGerencia ;
      private string[] T000711_A88UsuarioDepartamento ;
      private string[] T000711_A188EstadoTicketTicketNombre ;
      private long[] T000711_A54TicketLastId ;
      private string[] T000711_A285TicketHoraCaracter ;
      private bool[] T000711_A53TicketLaptop ;
      private bool[] T000711_A42TicketDesktop ;
      private bool[] T000711_A55TicketMonitor ;
      private bool[] T000711_A50TicketImpresora ;
      private bool[] T000711_A45TicketEscaner ;
      private bool[] T000711_A59TicketRouter ;
      private bool[] T000711_A60TicketSistemaOperativo ;
      private bool[] T000711_A56TicketOffice ;
      private bool[] T000711_A39TicketAntivirus ;
      private bool[] T000711_A40TicketAplicacion ;
      private bool[] T000711_A44TicketDisenio ;
      private bool[] T000711_A51TicketIngenieria ;
      private bool[] T000711_A43TicketDiscoDuroExterno ;
      private bool[] T000711_A58TicketPerifericos ;
      private bool[] T000711_A87TicketUps ;
      private bool[] T000711_A41TicketApoyoUsuario ;
      private bool[] T000711_A52TicketInstalarDataShow ;
      private bool[] T000711_A57TicketOtros ;
      private string[] T000711_A278TicketUsuarioAsigno ;
      private DateTime[] T000711_A289TicketFechaHora ;
      private bool[] T000711_n289TicketFechaHora ;
      private short[] T000711_A15UsuarioId ;
      private short[] T000711_A187EstadoTicketTicketId ;
      private string[] T000712_A93UsuarioNombre ;
      private string[] T000712_A94UsuarioRequerimiento ;
      private string[] T000712_A91UsuarioGerencia ;
      private string[] T000712_A88UsuarioDepartamento ;
      private string[] T000713_A188EstadoTicketTicketNombre ;
      private long[] T000714_A14TicketId ;
      private long[] T00078_A14TicketId ;
      private DateTime[] T00078_A46TicketFecha ;
      private DateTime[] T00078_A48TicketHora ;
      private long[] T00078_A54TicketLastId ;
      private string[] T00078_A285TicketHoraCaracter ;
      private bool[] T00078_A53TicketLaptop ;
      private bool[] T00078_A42TicketDesktop ;
      private bool[] T00078_A55TicketMonitor ;
      private bool[] T00078_A50TicketImpresora ;
      private bool[] T00078_A45TicketEscaner ;
      private bool[] T00078_A59TicketRouter ;
      private bool[] T00078_A60TicketSistemaOperativo ;
      private bool[] T00078_A56TicketOffice ;
      private bool[] T00078_A39TicketAntivirus ;
      private bool[] T00078_A40TicketAplicacion ;
      private bool[] T00078_A44TicketDisenio ;
      private bool[] T00078_A51TicketIngenieria ;
      private bool[] T00078_A43TicketDiscoDuroExterno ;
      private bool[] T00078_A58TicketPerifericos ;
      private bool[] T00078_A87TicketUps ;
      private bool[] T00078_A41TicketApoyoUsuario ;
      private bool[] T00078_A52TicketInstalarDataShow ;
      private bool[] T00078_A57TicketOtros ;
      private string[] T00078_A278TicketUsuarioAsigno ;
      private DateTime[] T00078_A289TicketFechaHora ;
      private bool[] T00078_n289TicketFechaHora ;
      private short[] T00078_A15UsuarioId ;
      private short[] T00078_A187EstadoTicketTicketId ;
      private long[] T000715_A14TicketId ;
      private long[] T000716_A14TicketId ;
      private long[] T00077_A14TicketId ;
      private DateTime[] T00077_A46TicketFecha ;
      private DateTime[] T00077_A48TicketHora ;
      private long[] T00077_A54TicketLastId ;
      private string[] T00077_A285TicketHoraCaracter ;
      private bool[] T00077_A53TicketLaptop ;
      private bool[] T00077_A42TicketDesktop ;
      private bool[] T00077_A55TicketMonitor ;
      private bool[] T00077_A50TicketImpresora ;
      private bool[] T00077_A45TicketEscaner ;
      private bool[] T00077_A59TicketRouter ;
      private bool[] T00077_A60TicketSistemaOperativo ;
      private bool[] T00077_A56TicketOffice ;
      private bool[] T00077_A39TicketAntivirus ;
      private bool[] T00077_A40TicketAplicacion ;
      private bool[] T00077_A44TicketDisenio ;
      private bool[] T00077_A51TicketIngenieria ;
      private bool[] T00077_A43TicketDiscoDuroExterno ;
      private bool[] T00077_A58TicketPerifericos ;
      private bool[] T00077_A87TicketUps ;
      private bool[] T00077_A41TicketApoyoUsuario ;
      private bool[] T00077_A52TicketInstalarDataShow ;
      private bool[] T00077_A57TicketOtros ;
      private string[] T00077_A278TicketUsuarioAsigno ;
      private DateTime[] T00077_A289TicketFechaHora ;
      private bool[] T00077_n289TicketFechaHora ;
      private short[] T00077_A15UsuarioId ;
      private short[] T00077_A187EstadoTicketTicketId ;
      private long[] T000717_A14TicketId ;
      private string[] T000720_A93UsuarioNombre ;
      private string[] T000720_A94UsuarioRequerimiento ;
      private string[] T000720_A91UsuarioGerencia ;
      private string[] T000720_A88UsuarioDepartamento ;
      private string[] T000721_A188EstadoTicketTicketNombre ;
      private long[] T000722_A202SoporteTecnicoId ;
      private long[] T000723_A7SatisfaccionId ;
      private long[] T000725_A14TicketId ;
      private string[] T00074_A291EtapaDesarrolloNombre ;
      private string[] T00075_A25EstadoTicketTecnicoNombre ;
      private long[] T000726_A14TicketId ;
      private long[] T000726_A16TicketResponsableId ;
      private DateTime[] T000726_A49TicketHoraResponsable ;
      private DateTime[] T000726_A47TicketFechaResponsable ;
      private string[] T000726_A199TicketTecnicoResponsableNombre ;
      private string[] T000726_A25EstadoTicketTecnicoNombre ;
      private string[] T000726_A145TicketResponsableInventarioSerie ;
      private bool[] T000726_n145TicketResponsableInventarioSerie ;
      private bool[] T000726_A146TicketResponsableInstalacion ;
      private bool[] T000726_n146TicketResponsableInstalacion ;
      private bool[] T000726_A147TicketResponsableConfiguracion ;
      private bool[] T000726_n147TicketResponsableConfiguracion ;
      private bool[] T000726_A148TicketResponsableInternetRouter ;
      private bool[] T000726_n148TicketResponsableInternetRouter ;
      private bool[] T000726_A149TicketResponsableFormateo ;
      private bool[] T000726_n149TicketResponsableFormateo ;
      private bool[] T000726_A150TicketResponsableReparacion ;
      private bool[] T000726_n150TicketResponsableReparacion ;
      private bool[] T000726_A151TicketResponsableLimpieza ;
      private bool[] T000726_n151TicketResponsableLimpieza ;
      private bool[] T000726_A152TicketResponsablePuntoRed ;
      private bool[] T000726_n152TicketResponsablePuntoRed ;
      private bool[] T000726_A153TicketResponsableCambiosHardware ;
      private bool[] T000726_n153TicketResponsableCambiosHardware ;
      private bool[] T000726_A154TicketResponsableCopiasRespaldo ;
      private bool[] T000726_n154TicketResponsableCopiasRespaldo ;
      private bool[] T000726_A165TicketResponsableCerrado ;
      private bool[] T000726_n165TicketResponsableCerrado ;
      private bool[] T000726_A166TicketResponsablePendiente ;
      private bool[] T000726_n166TicketResponsablePendiente ;
      private bool[] T000726_A167TicketResponsablePasaTaller ;
      private bool[] T000726_n167TicketResponsablePasaTaller ;
      private string[] T000726_A168TicketResponsableObservacion ;
      private bool[] T000726_n168TicketResponsableObservacion ;
      private DateTime[] T000726_A175TicketResponsableFechaResuelve ;
      private bool[] T000726_n175TicketResponsableFechaResuelve ;
      private DateTime[] T000726_A176TicketResponsableHoraResuelve ;
      private bool[] T000726_n176TicketResponsableHoraResuelve ;
      private string[] T000726_A177TicketResponsableRamTxt ;
      private bool[] T000726_n177TicketResponsableRamTxt ;
      private string[] T000726_A178TicketResponsableDiscoDuroTxt ;
      private bool[] T000726_n178TicketResponsableDiscoDuroTxt ;
      private string[] T000726_A179TicketResponsableProcesadorTxt ;
      private bool[] T000726_n179TicketResponsableProcesadorTxt ;
      private string[] T000726_A180TicketResponsableMaletinTxt ;
      private bool[] T000726_n180TicketResponsableMaletinTxt ;
      private string[] T000726_A181TicketResponsableTonerCintaTxt ;
      private bool[] T000726_n181TicketResponsableTonerCintaTxt ;
      private string[] T000726_A182TicketResponsableTarjetaVideoExtraTxt ;
      private bool[] T000726_n182TicketResponsableTarjetaVideoExtraTxt ;
      private string[] T000726_A183TicketResponsableCargadorLaptopTxt ;
      private bool[] T000726_n183TicketResponsableCargadorLaptopTxt ;
      private string[] T000726_A184TicketResponsableCDsDVDsTxt ;
      private bool[] T000726_n184TicketResponsableCDsDVDsTxt ;
      private string[] T000726_A185TicketResponsableCableEspecialTxt ;
      private bool[] T000726_n185TicketResponsableCableEspecialTxt ;
      private string[] T000726_A186TicketResponsableOtrosTallerTxt ;
      private bool[] T000726_n186TicketResponsableOtrosTallerTxt ;
      private DateTime[] T000726_A287TicketResponsableFechaHoraAsigna ;
      private bool[] T000726_n287TicketResponsableFechaHoraAsigna ;
      private DateTime[] T000726_A288TicketResponsableFechaHoraResuelve ;
      private bool[] T000726_n288TicketResponsableFechaHoraResuelve ;
      private string[] T000726_A291EtapaDesarrolloNombre ;
      private short[] T000726_A290EtapaDesarrolloId ;
      private bool[] T000726_n290EtapaDesarrolloId ;
      private short[] T000726_A17EstadoTicketTecnicoId ;
      private short[] T000726_A198TicketTecnicoResponsableId ;
      private string[] T00076_A199TicketTecnicoResponsableNombre ;
      private string[] T000727_A199TicketTecnicoResponsableNombre ;
      private long[] T000728_A14TicketId ;
      private long[] T000728_A16TicketResponsableId ;
      private long[] T00073_A14TicketId ;
      private long[] T00073_A16TicketResponsableId ;
      private DateTime[] T00073_A49TicketHoraResponsable ;
      private DateTime[] T00073_A47TicketFechaResponsable ;
      private string[] T00073_A145TicketResponsableInventarioSerie ;
      private bool[] T00073_n145TicketResponsableInventarioSerie ;
      private bool[] T00073_A146TicketResponsableInstalacion ;
      private bool[] T00073_n146TicketResponsableInstalacion ;
      private bool[] T00073_A147TicketResponsableConfiguracion ;
      private bool[] T00073_n147TicketResponsableConfiguracion ;
      private bool[] T00073_A148TicketResponsableInternetRouter ;
      private bool[] T00073_n148TicketResponsableInternetRouter ;
      private bool[] T00073_A149TicketResponsableFormateo ;
      private bool[] T00073_n149TicketResponsableFormateo ;
      private bool[] T00073_A150TicketResponsableReparacion ;
      private bool[] T00073_n150TicketResponsableReparacion ;
      private bool[] T00073_A151TicketResponsableLimpieza ;
      private bool[] T00073_n151TicketResponsableLimpieza ;
      private bool[] T00073_A152TicketResponsablePuntoRed ;
      private bool[] T00073_n152TicketResponsablePuntoRed ;
      private bool[] T00073_A153TicketResponsableCambiosHardware ;
      private bool[] T00073_n153TicketResponsableCambiosHardware ;
      private bool[] T00073_A154TicketResponsableCopiasRespaldo ;
      private bool[] T00073_n154TicketResponsableCopiasRespaldo ;
      private bool[] T00073_A165TicketResponsableCerrado ;
      private bool[] T00073_n165TicketResponsableCerrado ;
      private bool[] T00073_A166TicketResponsablePendiente ;
      private bool[] T00073_n166TicketResponsablePendiente ;
      private bool[] T00073_A167TicketResponsablePasaTaller ;
      private bool[] T00073_n167TicketResponsablePasaTaller ;
      private string[] T00073_A168TicketResponsableObservacion ;
      private bool[] T00073_n168TicketResponsableObservacion ;
      private DateTime[] T00073_A175TicketResponsableFechaResuelve ;
      private bool[] T00073_n175TicketResponsableFechaResuelve ;
      private DateTime[] T00073_A176TicketResponsableHoraResuelve ;
      private bool[] T00073_n176TicketResponsableHoraResuelve ;
      private string[] T00073_A177TicketResponsableRamTxt ;
      private bool[] T00073_n177TicketResponsableRamTxt ;
      private string[] T00073_A178TicketResponsableDiscoDuroTxt ;
      private bool[] T00073_n178TicketResponsableDiscoDuroTxt ;
      private string[] T00073_A179TicketResponsableProcesadorTxt ;
      private bool[] T00073_n179TicketResponsableProcesadorTxt ;
      private string[] T00073_A180TicketResponsableMaletinTxt ;
      private bool[] T00073_n180TicketResponsableMaletinTxt ;
      private string[] T00073_A181TicketResponsableTonerCintaTxt ;
      private bool[] T00073_n181TicketResponsableTonerCintaTxt ;
      private string[] T00073_A182TicketResponsableTarjetaVideoExtraTxt ;
      private bool[] T00073_n182TicketResponsableTarjetaVideoExtraTxt ;
      private string[] T00073_A183TicketResponsableCargadorLaptopTxt ;
      private bool[] T00073_n183TicketResponsableCargadorLaptopTxt ;
      private string[] T00073_A184TicketResponsableCDsDVDsTxt ;
      private bool[] T00073_n184TicketResponsableCDsDVDsTxt ;
      private string[] T00073_A185TicketResponsableCableEspecialTxt ;
      private bool[] T00073_n185TicketResponsableCableEspecialTxt ;
      private string[] T00073_A186TicketResponsableOtrosTallerTxt ;
      private bool[] T00073_n186TicketResponsableOtrosTallerTxt ;
      private DateTime[] T00073_A287TicketResponsableFechaHoraAsigna ;
      private bool[] T00073_n287TicketResponsableFechaHoraAsigna ;
      private DateTime[] T00073_A288TicketResponsableFechaHoraResuelve ;
      private bool[] T00073_n288TicketResponsableFechaHoraResuelve ;
      private short[] T00073_A290EtapaDesarrolloId ;
      private bool[] T00073_n290EtapaDesarrolloId ;
      private short[] T00073_A17EstadoTicketTecnicoId ;
      private short[] T00073_A198TicketTecnicoResponsableId ;
      private long[] T00072_A14TicketId ;
      private long[] T00072_A16TicketResponsableId ;
      private DateTime[] T00072_A49TicketHoraResponsable ;
      private DateTime[] T00072_A47TicketFechaResponsable ;
      private string[] T00072_A145TicketResponsableInventarioSerie ;
      private bool[] T00072_n145TicketResponsableInventarioSerie ;
      private bool[] T00072_A146TicketResponsableInstalacion ;
      private bool[] T00072_n146TicketResponsableInstalacion ;
      private bool[] T00072_A147TicketResponsableConfiguracion ;
      private bool[] T00072_n147TicketResponsableConfiguracion ;
      private bool[] T00072_A148TicketResponsableInternetRouter ;
      private bool[] T00072_n148TicketResponsableInternetRouter ;
      private bool[] T00072_A149TicketResponsableFormateo ;
      private bool[] T00072_n149TicketResponsableFormateo ;
      private bool[] T00072_A150TicketResponsableReparacion ;
      private bool[] T00072_n150TicketResponsableReparacion ;
      private bool[] T00072_A151TicketResponsableLimpieza ;
      private bool[] T00072_n151TicketResponsableLimpieza ;
      private bool[] T00072_A152TicketResponsablePuntoRed ;
      private bool[] T00072_n152TicketResponsablePuntoRed ;
      private bool[] T00072_A153TicketResponsableCambiosHardware ;
      private bool[] T00072_n153TicketResponsableCambiosHardware ;
      private bool[] T00072_A154TicketResponsableCopiasRespaldo ;
      private bool[] T00072_n154TicketResponsableCopiasRespaldo ;
      private bool[] T00072_A165TicketResponsableCerrado ;
      private bool[] T00072_n165TicketResponsableCerrado ;
      private bool[] T00072_A166TicketResponsablePendiente ;
      private bool[] T00072_n166TicketResponsablePendiente ;
      private bool[] T00072_A167TicketResponsablePasaTaller ;
      private bool[] T00072_n167TicketResponsablePasaTaller ;
      private string[] T00072_A168TicketResponsableObservacion ;
      private bool[] T00072_n168TicketResponsableObservacion ;
      private DateTime[] T00072_A175TicketResponsableFechaResuelve ;
      private bool[] T00072_n175TicketResponsableFechaResuelve ;
      private DateTime[] T00072_A176TicketResponsableHoraResuelve ;
      private bool[] T00072_n176TicketResponsableHoraResuelve ;
      private string[] T00072_A177TicketResponsableRamTxt ;
      private bool[] T00072_n177TicketResponsableRamTxt ;
      private string[] T00072_A178TicketResponsableDiscoDuroTxt ;
      private bool[] T00072_n178TicketResponsableDiscoDuroTxt ;
      private string[] T00072_A179TicketResponsableProcesadorTxt ;
      private bool[] T00072_n179TicketResponsableProcesadorTxt ;
      private string[] T00072_A180TicketResponsableMaletinTxt ;
      private bool[] T00072_n180TicketResponsableMaletinTxt ;
      private string[] T00072_A181TicketResponsableTonerCintaTxt ;
      private bool[] T00072_n181TicketResponsableTonerCintaTxt ;
      private string[] T00072_A182TicketResponsableTarjetaVideoExtraTxt ;
      private bool[] T00072_n182TicketResponsableTarjetaVideoExtraTxt ;
      private string[] T00072_A183TicketResponsableCargadorLaptopTxt ;
      private bool[] T00072_n183TicketResponsableCargadorLaptopTxt ;
      private string[] T00072_A184TicketResponsableCDsDVDsTxt ;
      private bool[] T00072_n184TicketResponsableCDsDVDsTxt ;
      private string[] T00072_A185TicketResponsableCableEspecialTxt ;
      private bool[] T00072_n185TicketResponsableCableEspecialTxt ;
      private string[] T00072_A186TicketResponsableOtrosTallerTxt ;
      private bool[] T00072_n186TicketResponsableOtrosTallerTxt ;
      private DateTime[] T00072_A287TicketResponsableFechaHoraAsigna ;
      private bool[] T00072_n287TicketResponsableFechaHoraAsigna ;
      private DateTime[] T00072_A288TicketResponsableFechaHoraResuelve ;
      private bool[] T00072_n288TicketResponsableFechaHoraResuelve ;
      private short[] T00072_A290EtapaDesarrolloId ;
      private bool[] T00072_n290EtapaDesarrolloId ;
      private short[] T00072_A17EstadoTicketTecnicoId ;
      private short[] T00072_A198TicketTecnicoResponsableId ;
      private string[] T000732_A199TicketTecnicoResponsableNombre ;
      private long[] T000733_A18TicketTecnicoId ;
      private long[] T000734_A7SatisfaccionId ;
      private long[] T000735_A14TicketId ;
      private long[] T000735_A16TicketResponsableId ;
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

   public class ticket__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ticket__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class ticket__gam : DataStoreHelperBase, IDataStoreHelper
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

public class ticket__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[15])
      ,new UpdateCursor(def[16])
      ,new UpdateCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new UpdateCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new UpdateCursor(def[27])
      ,new UpdateCursor(def[28])
      ,new UpdateCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000711;
       prmT000711 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT00079;
       prmT00079 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000710;
       prmT000710 = new Object[] {
       new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0)
       };
       Object[] prmT000712;
       prmT000712 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000713;
       prmT000713 = new Object[] {
       new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0)
       };
       Object[] prmT000714;
       prmT000714 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT00078;
       prmT00078 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000715;
       prmT000715 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000716;
       prmT000716 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT00077;
       prmT00077 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000717;
       prmT000717 = new Object[] {
       new ParDef("@TicketFecha",GXType.Date,8,0) ,
       new ParDef("@TicketHora",GXType.DateTime,0,5) ,
       new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
       new ParDef("@TicketHoraCaracter",GXType.NChar,8,0) ,
       new ParDef("@TicketLaptop",GXType.Boolean,4,0) ,
       new ParDef("@TicketDesktop",GXType.Boolean,4,0) ,
       new ParDef("@TicketMonitor",GXType.Boolean,4,0) ,
       new ParDef("@TicketImpresora",GXType.Boolean,4,0) ,
       new ParDef("@TicketEscaner",GXType.Boolean,4,0) ,
       new ParDef("@TicketRouter",GXType.Boolean,4,0) ,
       new ParDef("@TicketSistemaOperativo",GXType.Boolean,4,0) ,
       new ParDef("@TicketOffice",GXType.Boolean,4,0) ,
       new ParDef("@TicketAntivirus",GXType.Boolean,4,0) ,
       new ParDef("@TicketAplicacion",GXType.Boolean,4,0) ,
       new ParDef("@TicketDisenio",GXType.Boolean,4,0) ,
       new ParDef("@TicketIngenieria",GXType.Boolean,4,0) ,
       new ParDef("@TicketDiscoDuroExterno",GXType.Boolean,4,0) ,
       new ParDef("@TicketPerifericos",GXType.Boolean,4,0) ,
       new ParDef("@TicketUps",GXType.Boolean,4,0) ,
       new ParDef("@TicketApoyoUsuario",GXType.Boolean,4,0) ,
       new ParDef("@TicketInstalarDataShow",GXType.Boolean,4,0) ,
       new ParDef("@TicketOtros",GXType.Boolean,4,0) ,
       new ParDef("@TicketUsuarioAsigno",GXType.NVarChar,100,60) ,
       new ParDef("@TicketFechaHora",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@UsuarioId",GXType.Int16,4,0) ,
       new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0)
       };
       Object[] prmT000718;
       prmT000718 = new Object[] {
       new ParDef("@TicketFecha",GXType.Date,8,0) ,
       new ParDef("@TicketHora",GXType.DateTime,0,5) ,
       new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
       new ParDef("@TicketHoraCaracter",GXType.NChar,8,0) ,
       new ParDef("@TicketLaptop",GXType.Boolean,4,0) ,
       new ParDef("@TicketDesktop",GXType.Boolean,4,0) ,
       new ParDef("@TicketMonitor",GXType.Boolean,4,0) ,
       new ParDef("@TicketImpresora",GXType.Boolean,4,0) ,
       new ParDef("@TicketEscaner",GXType.Boolean,4,0) ,
       new ParDef("@TicketRouter",GXType.Boolean,4,0) ,
       new ParDef("@TicketSistemaOperativo",GXType.Boolean,4,0) ,
       new ParDef("@TicketOffice",GXType.Boolean,4,0) ,
       new ParDef("@TicketAntivirus",GXType.Boolean,4,0) ,
       new ParDef("@TicketAplicacion",GXType.Boolean,4,0) ,
       new ParDef("@TicketDisenio",GXType.Boolean,4,0) ,
       new ParDef("@TicketIngenieria",GXType.Boolean,4,0) ,
       new ParDef("@TicketDiscoDuroExterno",GXType.Boolean,4,0) ,
       new ParDef("@TicketPerifericos",GXType.Boolean,4,0) ,
       new ParDef("@TicketUps",GXType.Boolean,4,0) ,
       new ParDef("@TicketApoyoUsuario",GXType.Boolean,4,0) ,
       new ParDef("@TicketInstalarDataShow",GXType.Boolean,4,0) ,
       new ParDef("@TicketOtros",GXType.Boolean,4,0) ,
       new ParDef("@TicketUsuarioAsigno",GXType.NVarChar,100,60) ,
       new ParDef("@TicketFechaHora",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@UsuarioId",GXType.Int16,4,0) ,
       new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0) ,
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000719;
       prmT000719 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000722;
       prmT000722 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000723;
       prmT000723 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000724;
       prmT000724 = new Object[] {
       new ParDef("@TicketLastId",GXType.Decimal,10,0) ,
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000725;
       prmT000725 = new Object[] {
       };
       Object[] prmT00074;
       prmT00074 = new Object[] {
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true}
       };
       Object[] prmT00075;
       prmT00075 = new Object[] {
       new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0)
       };
       Object[] prmT000726;
       prmT000726 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       string cmdBufferT000726;
       cmdBufferT000726=" SELECT T1.[TicketId], T1.[TicketResponsableId], T1.[TicketHoraResponsable], T1.[TicketFechaResponsable], T4.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T3.[EstadoTicketNombre] AS EstadoTicketTecnicoNombre, T1.[TicketResponsableInventarioSerie], T1.[TicketResponsableInstalacion], T1.[TicketResponsableConfiguracion], T1.[TicketResponsableInternetRouter], T1.[TicketResponsableFormateo], T1.[TicketResponsableReparacion], T1.[TicketResponsableLimpieza], T1.[TicketResponsablePuntoRed], T1.[TicketResponsableCambiosHardware], T1.[TicketResponsableCopiasRespaldo], T1.[TicketResponsableCerrado], T1.[TicketResponsablePendiente], T1.[TicketResponsablePasaTaller], T1.[TicketResponsableObservacion], T1.[TicketResponsableFechaResuelve], T1.[TicketResponsableHoraResuelve], T1.[TicketResponsableRamTxt], T1.[TicketResponsableDiscoDuroTxt], T1.[TicketResponsableProcesadorTxt], T1.[TicketResponsableMaletinTxt], T1.[TicketResponsableTonerCintaTxt], T1.[TicketResponsableTarjetaVideoExtraTxt], T1.[TicketResponsableCargadorLaptopTxt], T1.[TicketResponsableCDsDVDsTxt], T1.[TicketResponsableCableEspecialTxt], T1.[TicketResponsableOtrosTallerTxt], T1.[TicketResponsableFechaHoraAsigna], T1.[TicketResponsableFechaHoraResuelve], T2.[EtapaDesarrolloNombre], T1.[EtapaDesarrolloId], T1.[EstadoTicketTecnicoId] AS EstadoTicketTecnicoId, T1.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM ((([TicketResponsable] T1 LEFT JOIN [EtapasDesarrollo] T2 ON T2.[EtapaDesarrolloId] = T1.[EtapaDesarrolloId]) INNER JOIN [EstadoTicket] T3 ON T3.[EstadoTicketId] = T1.[EstadoTicketTecnicoId]) INNER JOIN [Responsable] T4 ON T4.[ResponsableId] = T1.[TicketTecnicoResponsableId]) WHERE T1.[TicketId] = @TicketId and T1.[TicketResponsableId] = @TicketResponsableId ORDER BY T1.[TicketId], T1.[TicketResponsableId] "
       + "" ;
       Object[] prmT00076;
       prmT00076 = new Object[] {
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000727;
       prmT000727 = new Object[] {
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000728;
       prmT000728 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT00073;
       prmT00073 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT00072;
       prmT00072 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000729;
       prmT000729 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
       new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
       new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
       new ParDef("@TicketResponsableInventarioSerie",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketResponsableInstalacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableConfiguracion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableInternetRouter",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableFormateo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableReparacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableLimpieza",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsablePuntoRed",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableCambiosHardware",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableCopiasRespaldo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableCerrado",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsablePendiente",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsablePasaTaller",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableObservacion",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketResponsableFechaResuelve",GXType.Date,8,0){Nullable=true} ,
       new ParDef("@TicketResponsableHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("@TicketResponsableRamTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableDiscoDuroTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableProcesadorTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableMaletinTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableTonerCintaTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableTarjetaVideoExtraTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableCargadorLaptopTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableCDsDVDsTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableCableEspecialTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableOtrosTallerTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableFechaHoraAsigna",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@TicketResponsableFechaHoraResuelve",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       string cmdBufferT000729;
       cmdBufferT000729=" INSERT INTO [TicketResponsable]([TicketId], [TicketResponsableId], [TicketHoraResponsable], [TicketFechaResponsable], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [EtapaDesarrolloId], [EstadoTicketTecnicoId], [TicketTecnicoResponsableId]) VALUES(@TicketId, @TicketResponsableId, @TicketHoraResponsable, @TicketFechaResponsable, @TicketResponsableInventarioSerie, @TicketResponsableInstalacion, @TicketResponsableConfiguracion, @TicketResponsableInternetRouter, @TicketResponsableFormateo, @TicketResponsableReparacion, @TicketResponsableLimpieza, @TicketResponsablePuntoRed, @TicketResponsableCambiosHardware, @TicketResponsableCopiasRespaldo, @TicketResponsableCerrado, @TicketResponsablePendiente, @TicketResponsablePasaTaller, @TicketResponsableObservacion, @TicketResponsableFechaResuelve, @TicketResponsableHoraResuelve, @TicketResponsableRamTxt, @TicketResponsableDiscoDuroTxt, @TicketResponsableProcesadorTxt, "
       + " @TicketResponsableMaletinTxt, @TicketResponsableTonerCintaTxt, @TicketResponsableTarjetaVideoExtraTxt, @TicketResponsableCargadorLaptopTxt, @TicketResponsableCDsDVDsTxt, @TicketResponsableCableEspecialTxt, @TicketResponsableOtrosTallerTxt, @TicketResponsableFechaHoraAsigna, @TicketResponsableFechaHoraResuelve, @EtapaDesarrolloId, @EstadoTicketTecnicoId, @TicketTecnicoResponsableId)" ;
       Object[] prmT000730;
       prmT000730 = new Object[] {
       new ParDef("@TicketHoraResponsable",GXType.DateTime,0,5) ,
       new ParDef("@TicketFechaResponsable",GXType.Date,8,0) ,
       new ParDef("@TicketResponsableInventarioSerie",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketResponsableInstalacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableConfiguracion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableInternetRouter",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableFormateo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableReparacion",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableLimpieza",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsablePuntoRed",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableCambiosHardware",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableCopiasRespaldo",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableCerrado",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsablePendiente",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsablePasaTaller",GXType.Boolean,4,0){Nullable=true} ,
       new ParDef("@TicketResponsableObservacion",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketResponsableFechaResuelve",GXType.Date,8,0){Nullable=true} ,
       new ParDef("@TicketResponsableHoraResuelve",GXType.DateTime,0,5){Nullable=true} ,
       new ParDef("@TicketResponsableRamTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableDiscoDuroTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableProcesadorTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableMaletinTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableTonerCintaTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableTarjetaVideoExtraTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableCargadorLaptopTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableCDsDVDsTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableCableEspecialTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableOtrosTallerTxt",GXType.NVarChar,60,0){Nullable=true} ,
       new ParDef("@TicketResponsableFechaHoraAsigna",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@TicketResponsableFechaHoraResuelve",GXType.DateTime,10,8){Nullable=true} ,
       new ParDef("@EtapaDesarrolloId",GXType.Int16,4,0){Nullable=true} ,
       new ParDef("@EstadoTicketTecnicoId",GXType.Int16,4,0) ,
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0) ,
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       string cmdBufferT000730;
       cmdBufferT000730=" UPDATE [TicketResponsable] SET [TicketHoraResponsable]=@TicketHoraResponsable, [TicketFechaResponsable]=@TicketFechaResponsable, [TicketResponsableInventarioSerie]=@TicketResponsableInventarioSerie, [TicketResponsableInstalacion]=@TicketResponsableInstalacion, [TicketResponsableConfiguracion]=@TicketResponsableConfiguracion, [TicketResponsableInternetRouter]=@TicketResponsableInternetRouter, [TicketResponsableFormateo]=@TicketResponsableFormateo, [TicketResponsableReparacion]=@TicketResponsableReparacion, [TicketResponsableLimpieza]=@TicketResponsableLimpieza, [TicketResponsablePuntoRed]=@TicketResponsablePuntoRed, [TicketResponsableCambiosHardware]=@TicketResponsableCambiosHardware, [TicketResponsableCopiasRespaldo]=@TicketResponsableCopiasRespaldo, [TicketResponsableCerrado]=@TicketResponsableCerrado, [TicketResponsablePendiente]=@TicketResponsablePendiente, [TicketResponsablePasaTaller]=@TicketResponsablePasaTaller, [TicketResponsableObservacion]=@TicketResponsableObservacion, [TicketResponsableFechaResuelve]=@TicketResponsableFechaResuelve, [TicketResponsableHoraResuelve]=@TicketResponsableHoraResuelve, [TicketResponsableRamTxt]=@TicketResponsableRamTxt, [TicketResponsableDiscoDuroTxt]=@TicketResponsableDiscoDuroTxt, [TicketResponsableProcesadorTxt]=@TicketResponsableProcesadorTxt, [TicketResponsableMaletinTxt]=@TicketResponsableMaletinTxt, [TicketResponsableTonerCintaTxt]=@TicketResponsableTonerCintaTxt, [TicketResponsableTarjetaVideoExtraTxt]=@TicketResponsableTarjetaVideoExtraTxt, [TicketResponsableCargadorLaptopTxt]=@TicketResponsableCargadorLaptopTxt, [TicketResponsableCDsDVDsTxt]=@TicketResponsableCDsDVDsTxt, [TicketResponsableCableEspecialTxt]=@TicketResponsableCableEspecialTxt, [TicketResponsableOtrosTallerTxt]=@TicketResponsableOtrosTallerTxt, [TicketResponsableFechaHoraAsigna]=@TicketResponsableFechaHoraAsigna, "
       + " [TicketResponsableFechaHoraResuelve]=@TicketResponsableFechaHoraResuelve, [EtapaDesarrolloId]=@EtapaDesarrolloId, [EstadoTicketTecnicoId]=@EstadoTicketTecnicoId, [TicketTecnicoResponsableId]=@TicketTecnicoResponsableId  WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId" ;
       Object[] prmT000731;
       prmT000731 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000733;
       prmT000733 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000734;
       prmT000734 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000735;
       prmT000735 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000720;
       prmT000720 = new Object[] {
       new ParDef("@UsuarioId",GXType.Int16,4,0)
       };
       Object[] prmT000721;
       prmT000721 = new Object[] {
       new ParDef("@EstadoTicketTicketId",GXType.Int16,4,0)
       };
       Object[] prmT000732;
       prmT000732 = new Object[] {
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00072", "SELECT [TicketId], [TicketResponsableId], [TicketHoraResponsable], [TicketFechaResponsable], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [EtapaDesarrolloId], [EstadoTicketTecnicoId] AS EstadoTicketTecnicoId, [TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM [TicketResponsable] WITH (UPDLOCK) WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00073", "SELECT [TicketId], [TicketResponsableId], [TicketHoraResponsable], [TicketFechaResponsable], [TicketResponsableInventarioSerie], [TicketResponsableInstalacion], [TicketResponsableConfiguracion], [TicketResponsableInternetRouter], [TicketResponsableFormateo], [TicketResponsableReparacion], [TicketResponsableLimpieza], [TicketResponsablePuntoRed], [TicketResponsableCambiosHardware], [TicketResponsableCopiasRespaldo], [TicketResponsableCerrado], [TicketResponsablePendiente], [TicketResponsablePasaTaller], [TicketResponsableObservacion], [TicketResponsableFechaResuelve], [TicketResponsableHoraResuelve], [TicketResponsableRamTxt], [TicketResponsableDiscoDuroTxt], [TicketResponsableProcesadorTxt], [TicketResponsableMaletinTxt], [TicketResponsableTonerCintaTxt], [TicketResponsableTarjetaVideoExtraTxt], [TicketResponsableCargadorLaptopTxt], [TicketResponsableCDsDVDsTxt], [TicketResponsableCableEspecialTxt], [TicketResponsableOtrosTallerTxt], [TicketResponsableFechaHoraAsigna], [TicketResponsableFechaHoraResuelve], [EtapaDesarrolloId], [EstadoTicketTecnicoId] AS EstadoTicketTecnicoId, [TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00074", "SELECT [EtapaDesarrolloNombre] FROM [EtapasDesarrollo] WHERE [EtapaDesarrolloId] = @EtapaDesarrolloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00075", "SELECT [EstadoTicketNombre] AS EstadoTicketTecnicoNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketTecnicoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00076", "SELECT [ResponsableNombre] AS TicketTecnicoResponsableNombre FROM [Responsable] WHERE [ResponsableId] = @TicketTecnicoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00077", "SELECT [TicketId], [TicketFecha], [TicketHora], [TicketLastId], [TicketHoraCaracter], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [TicketUsuarioAsigno], [TicketFechaHora], [UsuarioId], [EstadoTicketTicketId] AS EstadoTicketTicketId FROM [Ticket] WITH (UPDLOCK) WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00078", "SELECT [TicketId], [TicketFecha], [TicketHora], [TicketLastId], [TicketHoraCaracter], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [TicketUsuarioAsigno], [TicketFechaHora], [UsuarioId], [EstadoTicketTicketId] AS EstadoTicketTicketId FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00079", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioGerencia], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000710", "SELECT [EstadoTicketNombre] AS EstadoTicketTicketNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketTicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000711", "SELECT TM1.[TicketId], TM1.[TicketFecha], TM1.[TicketHora], T2.[UsuarioNombre], T2.[UsuarioRequerimiento], T2.[UsuarioGerencia], T2.[UsuarioDepartamento], T3.[EstadoTicketNombre] AS EstadoTicketTicketNombre, TM1.[TicketLastId], TM1.[TicketHoraCaracter], TM1.[TicketLaptop], TM1.[TicketDesktop], TM1.[TicketMonitor], TM1.[TicketImpresora], TM1.[TicketEscaner], TM1.[TicketRouter], TM1.[TicketSistemaOperativo], TM1.[TicketOffice], TM1.[TicketAntivirus], TM1.[TicketAplicacion], TM1.[TicketDisenio], TM1.[TicketIngenieria], TM1.[TicketDiscoDuroExterno], TM1.[TicketPerifericos], TM1.[TicketUps], TM1.[TicketApoyoUsuario], TM1.[TicketInstalarDataShow], TM1.[TicketOtros], TM1.[TicketUsuarioAsigno], TM1.[TicketFechaHora], TM1.[UsuarioId], TM1.[EstadoTicketTicketId] AS EstadoTicketTicketId FROM (([Ticket] TM1 INNER JOIN [Usuario] T2 ON T2.[UsuarioId] = TM1.[UsuarioId]) INNER JOIN [EstadoTicket] T3 ON T3.[EstadoTicketId] = TM1.[EstadoTicketTicketId]) WHERE TM1.[TicketId] = @TicketId ORDER BY TM1.[TicketId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000711,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000712", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioGerencia], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000712,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000713", "SELECT [EstadoTicketNombre] AS EstadoTicketTicketNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketTicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000713,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000714", "SELECT [TicketId] FROM [Ticket] WHERE [TicketId] = @TicketId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000714,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000715", "SELECT TOP 1 [TicketId] FROM [Ticket] WHERE ( [TicketId] > @TicketId) ORDER BY [TicketId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000716", "SELECT TOP 1 [TicketId] FROM [Ticket] WHERE ( [TicketId] < @TicketId) ORDER BY [TicketId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000717", "INSERT INTO [Ticket]([TicketFecha], [TicketHora], [TicketLastId], [TicketHoraCaracter], [TicketLaptop], [TicketDesktop], [TicketMonitor], [TicketImpresora], [TicketEscaner], [TicketRouter], [TicketSistemaOperativo], [TicketOffice], [TicketAntivirus], [TicketAplicacion], [TicketDisenio], [TicketIngenieria], [TicketDiscoDuroExterno], [TicketPerifericos], [TicketUps], [TicketApoyoUsuario], [TicketInstalarDataShow], [TicketOtros], [TicketUsuarioAsigno], [TicketFechaHora], [UsuarioId], [EstadoTicketTicketId]) VALUES(@TicketFecha, @TicketHora, @TicketLastId, @TicketHoraCaracter, @TicketLaptop, @TicketDesktop, @TicketMonitor, @TicketImpresora, @TicketEscaner, @TicketRouter, @TicketSistemaOperativo, @TicketOffice, @TicketAntivirus, @TicketAplicacion, @TicketDisenio, @TicketIngenieria, @TicketDiscoDuroExterno, @TicketPerifericos, @TicketUps, @TicketApoyoUsuario, @TicketInstalarDataShow, @TicketOtros, @TicketUsuarioAsigno, @TicketFechaHora, @UsuarioId, @EstadoTicketTicketId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000717)
          ,new CursorDef("T000718", "UPDATE [Ticket] SET [TicketFecha]=@TicketFecha, [TicketHora]=@TicketHora, [TicketLastId]=@TicketLastId, [TicketHoraCaracter]=@TicketHoraCaracter, [TicketLaptop]=@TicketLaptop, [TicketDesktop]=@TicketDesktop, [TicketMonitor]=@TicketMonitor, [TicketImpresora]=@TicketImpresora, [TicketEscaner]=@TicketEscaner, [TicketRouter]=@TicketRouter, [TicketSistemaOperativo]=@TicketSistemaOperativo, [TicketOffice]=@TicketOffice, [TicketAntivirus]=@TicketAntivirus, [TicketAplicacion]=@TicketAplicacion, [TicketDisenio]=@TicketDisenio, [TicketIngenieria]=@TicketIngenieria, [TicketDiscoDuroExterno]=@TicketDiscoDuroExterno, [TicketPerifericos]=@TicketPerifericos, [TicketUps]=@TicketUps, [TicketApoyoUsuario]=@TicketApoyoUsuario, [TicketInstalarDataShow]=@TicketInstalarDataShow, [TicketOtros]=@TicketOtros, [TicketUsuarioAsigno]=@TicketUsuarioAsigno, [TicketFechaHora]=@TicketFechaHora, [UsuarioId]=@UsuarioId, [EstadoTicketTicketId]=@EstadoTicketTicketId  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmT000718)
          ,new CursorDef("T000719", "DELETE FROM [Ticket]  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmT000719)
          ,new CursorDef("T000720", "SELECT [UsuarioNombre], [UsuarioRequerimiento], [UsuarioGerencia], [UsuarioDepartamento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000720,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000721", "SELECT [EstadoTicketNombre] AS EstadoTicketTicketNombre FROM [EstadoTicket] WHERE [EstadoTicketId] = @EstadoTicketTicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000721,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000722", "SELECT TOP 1 [SoporteTecnicoId] FROM [AtencionSoporteTecnico] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000723", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000723,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000724", "UPDATE [Ticket] SET [TicketLastId]=@TicketLastId  WHERE [TicketId] = @TicketId", GxErrorMask.GX_NOMASK,prmT000724)
          ,new CursorDef("T000725", "SELECT [TicketId] FROM [Ticket] ORDER BY [TicketId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000725,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000726", cmdBufferT000726,true, GxErrorMask.GX_NOMASK, false, this,prmT000726,11, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000727", "SELECT [ResponsableNombre] AS TicketTecnicoResponsableNombre FROM [Responsable] WHERE [ResponsableId] = @TicketTecnicoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000727,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000728", "SELECT [TicketId], [TicketResponsableId] FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000728,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000729", cmdBufferT000729, GxErrorMask.GX_NOMASK,prmT000729)
          ,new CursorDef("T000730", cmdBufferT000730, GxErrorMask.GX_NOMASK,prmT000730)
          ,new CursorDef("T000731", "DELETE FROM [TicketResponsable]  WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId", GxErrorMask.GX_NOMASK,prmT000731)
          ,new CursorDef("T000732", "SELECT [ResponsableNombre] AS TicketTecnicoResponsableNombre FROM [Responsable] WHERE [ResponsableId] = @TicketTecnicoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000732,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000733", "SELECT TOP 1 [TicketTecnicoId] FROM [TicketTecnico] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000733,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000734", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000734,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000735", "SELECT [TicketId], [TicketResponsableId] FROM [TicketResponsable] WHERE [TicketId] = @TicketId ORDER BY [TicketId], [TicketResponsableId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000735,11, GxCacheFrequency.OFF ,true,false )
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
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((bool[]) buf[6])[0] = rslt.getBool(6);
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             ((bool[]) buf[8])[0] = rslt.getBool(7);
             ((bool[]) buf[9])[0] = rslt.wasNull(7);
             ((bool[]) buf[10])[0] = rslt.getBool(8);
             ((bool[]) buf[11])[0] = rslt.wasNull(8);
             ((bool[]) buf[12])[0] = rslt.getBool(9);
             ((bool[]) buf[13])[0] = rslt.wasNull(9);
             ((bool[]) buf[14])[0] = rslt.getBool(10);
             ((bool[]) buf[15])[0] = rslt.wasNull(10);
             ((bool[]) buf[16])[0] = rslt.getBool(11);
             ((bool[]) buf[17])[0] = rslt.wasNull(11);
             ((bool[]) buf[18])[0] = rslt.getBool(12);
             ((bool[]) buf[19])[0] = rslt.wasNull(12);
             ((bool[]) buf[20])[0] = rslt.getBool(13);
             ((bool[]) buf[21])[0] = rslt.wasNull(13);
             ((bool[]) buf[22])[0] = rslt.getBool(14);
             ((bool[]) buf[23])[0] = rslt.wasNull(14);
             ((bool[]) buf[24])[0] = rslt.getBool(15);
             ((bool[]) buf[25])[0] = rslt.wasNull(15);
             ((bool[]) buf[26])[0] = rslt.getBool(16);
             ((bool[]) buf[27])[0] = rslt.wasNull(16);
             ((bool[]) buf[28])[0] = rslt.getBool(17);
             ((bool[]) buf[29])[0] = rslt.wasNull(17);
             ((string[]) buf[30])[0] = rslt.getVarchar(18);
             ((bool[]) buf[31])[0] = rslt.wasNull(18);
             ((DateTime[]) buf[32])[0] = rslt.getGXDate(19);
             ((bool[]) buf[33])[0] = rslt.wasNull(19);
             ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(20);
             ((bool[]) buf[35])[0] = rslt.wasNull(20);
             ((string[]) buf[36])[0] = rslt.getVarchar(21);
             ((bool[]) buf[37])[0] = rslt.wasNull(21);
             ((string[]) buf[38])[0] = rslt.getVarchar(22);
             ((bool[]) buf[39])[0] = rslt.wasNull(22);
             ((string[]) buf[40])[0] = rslt.getVarchar(23);
             ((bool[]) buf[41])[0] = rslt.wasNull(23);
             ((string[]) buf[42])[0] = rslt.getVarchar(24);
             ((bool[]) buf[43])[0] = rslt.wasNull(24);
             ((string[]) buf[44])[0] = rslt.getVarchar(25);
             ((bool[]) buf[45])[0] = rslt.wasNull(25);
             ((string[]) buf[46])[0] = rslt.getVarchar(26);
             ((bool[]) buf[47])[0] = rslt.wasNull(26);
             ((string[]) buf[48])[0] = rslt.getVarchar(27);
             ((bool[]) buf[49])[0] = rslt.wasNull(27);
             ((string[]) buf[50])[0] = rslt.getVarchar(28);
             ((bool[]) buf[51])[0] = rslt.wasNull(28);
             ((string[]) buf[52])[0] = rslt.getVarchar(29);
             ((bool[]) buf[53])[0] = rslt.wasNull(29);
             ((string[]) buf[54])[0] = rslt.getVarchar(30);
             ((bool[]) buf[55])[0] = rslt.wasNull(30);
             ((DateTime[]) buf[56])[0] = rslt.getGXDateTime(31);
             ((bool[]) buf[57])[0] = rslt.wasNull(31);
             ((DateTime[]) buf[58])[0] = rslt.getGXDateTime(32);
             ((bool[]) buf[59])[0] = rslt.wasNull(32);
             ((short[]) buf[60])[0] = rslt.getShort(33);
             ((bool[]) buf[61])[0] = rslt.wasNull(33);
             ((short[]) buf[62])[0] = rslt.getShort(34);
             ((short[]) buf[63])[0] = rslt.getShort(35);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((bool[]) buf[5])[0] = rslt.wasNull(5);
             ((bool[]) buf[6])[0] = rslt.getBool(6);
             ((bool[]) buf[7])[0] = rslt.wasNull(6);
             ((bool[]) buf[8])[0] = rslt.getBool(7);
             ((bool[]) buf[9])[0] = rslt.wasNull(7);
             ((bool[]) buf[10])[0] = rslt.getBool(8);
             ((bool[]) buf[11])[0] = rslt.wasNull(8);
             ((bool[]) buf[12])[0] = rslt.getBool(9);
             ((bool[]) buf[13])[0] = rslt.wasNull(9);
             ((bool[]) buf[14])[0] = rslt.getBool(10);
             ((bool[]) buf[15])[0] = rslt.wasNull(10);
             ((bool[]) buf[16])[0] = rslt.getBool(11);
             ((bool[]) buf[17])[0] = rslt.wasNull(11);
             ((bool[]) buf[18])[0] = rslt.getBool(12);
             ((bool[]) buf[19])[0] = rslt.wasNull(12);
             ((bool[]) buf[20])[0] = rslt.getBool(13);
             ((bool[]) buf[21])[0] = rslt.wasNull(13);
             ((bool[]) buf[22])[0] = rslt.getBool(14);
             ((bool[]) buf[23])[0] = rslt.wasNull(14);
             ((bool[]) buf[24])[0] = rslt.getBool(15);
             ((bool[]) buf[25])[0] = rslt.wasNull(15);
             ((bool[]) buf[26])[0] = rslt.getBool(16);
             ((bool[]) buf[27])[0] = rslt.wasNull(16);
             ((bool[]) buf[28])[0] = rslt.getBool(17);
             ((bool[]) buf[29])[0] = rslt.wasNull(17);
             ((string[]) buf[30])[0] = rslt.getVarchar(18);
             ((bool[]) buf[31])[0] = rslt.wasNull(18);
             ((DateTime[]) buf[32])[0] = rslt.getGXDate(19);
             ((bool[]) buf[33])[0] = rslt.wasNull(19);
             ((DateTime[]) buf[34])[0] = rslt.getGXDateTime(20);
             ((bool[]) buf[35])[0] = rslt.wasNull(20);
             ((string[]) buf[36])[0] = rslt.getVarchar(21);
             ((bool[]) buf[37])[0] = rslt.wasNull(21);
             ((string[]) buf[38])[0] = rslt.getVarchar(22);
             ((bool[]) buf[39])[0] = rslt.wasNull(22);
             ((string[]) buf[40])[0] = rslt.getVarchar(23);
             ((bool[]) buf[41])[0] = rslt.wasNull(23);
             ((string[]) buf[42])[0] = rslt.getVarchar(24);
             ((bool[]) buf[43])[0] = rslt.wasNull(24);
             ((string[]) buf[44])[0] = rslt.getVarchar(25);
             ((bool[]) buf[45])[0] = rslt.wasNull(25);
             ((string[]) buf[46])[0] = rslt.getVarchar(26);
             ((bool[]) buf[47])[0] = rslt.wasNull(26);
             ((string[]) buf[48])[0] = rslt.getVarchar(27);
             ((bool[]) buf[49])[0] = rslt.wasNull(27);
             ((string[]) buf[50])[0] = rslt.getVarchar(28);
             ((bool[]) buf[51])[0] = rslt.wasNull(28);
             ((string[]) buf[52])[0] = rslt.getVarchar(29);
             ((bool[]) buf[53])[0] = rslt.wasNull(29);
             ((string[]) buf[54])[0] = rslt.getVarchar(30);
             ((bool[]) buf[55])[0] = rslt.wasNull(30);
             ((DateTime[]) buf[56])[0] = rslt.getGXDateTime(31);
             ((bool[]) buf[57])[0] = rslt.wasNull(31);
             ((DateTime[]) buf[58])[0] = rslt.getGXDateTime(32);
             ((bool[]) buf[59])[0] = rslt.wasNull(32);
             ((short[]) buf[60])[0] = rslt.getShort(33);
             ((bool[]) buf[61])[0] = rslt.wasNull(33);
             ((short[]) buf[62])[0] = rslt.getShort(34);
             ((short[]) buf[63])[0] = rslt.getShort(35);
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
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((long[]) buf[3])[0] = rslt.getLong(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 8);
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
             ((string[]) buf[23])[0] = rslt.getVarchar(24);
             ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             ((short[]) buf[26])[0] = rslt.getShort(26);
             ((short[]) buf[27])[0] = rslt.getShort(27);
             return;
          case 6 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((long[]) buf[3])[0] = rslt.getLong(4);
             ((string[]) buf[4])[0] = rslt.getString(5, 8);
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
             ((string[]) buf[23])[0] = rslt.getVarchar(24);
             ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(25);
             ((bool[]) buf[25])[0] = rslt.wasNull(25);
             ((short[]) buf[26])[0] = rslt.getShort(26);
             ((short[]) buf[27])[0] = rslt.getShort(27);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 9 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((long[]) buf[8])[0] = rslt.getLong(9);
             ((string[]) buf[9])[0] = rslt.getString(10, 8);
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
             ((string[]) buf[28])[0] = rslt.getVarchar(29);
             ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(30);
             ((bool[]) buf[30])[0] = rslt.wasNull(30);
             ((short[]) buf[31])[0] = rslt.getShort(31);
             ((short[]) buf[32])[0] = rslt.getShort(32);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
          case 18 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((string[]) buf[1])[0] = rslt.getVarchar(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
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
          case 23 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 24 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((string[]) buf[5])[0] = rslt.getVarchar(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((bool[]) buf[7])[0] = rslt.wasNull(7);
             ((bool[]) buf[8])[0] = rslt.getBool(8);
             ((bool[]) buf[9])[0] = rslt.wasNull(8);
             ((bool[]) buf[10])[0] = rslt.getBool(9);
             ((bool[]) buf[11])[0] = rslt.wasNull(9);
             ((bool[]) buf[12])[0] = rslt.getBool(10);
             ((bool[]) buf[13])[0] = rslt.wasNull(10);
             ((bool[]) buf[14])[0] = rslt.getBool(11);
             ((bool[]) buf[15])[0] = rslt.wasNull(11);
             ((bool[]) buf[16])[0] = rslt.getBool(12);
             ((bool[]) buf[17])[0] = rslt.wasNull(12);
             ((bool[]) buf[18])[0] = rslt.getBool(13);
             ((bool[]) buf[19])[0] = rslt.wasNull(13);
             ((bool[]) buf[20])[0] = rslt.getBool(14);
             ((bool[]) buf[21])[0] = rslt.wasNull(14);
             ((bool[]) buf[22])[0] = rslt.getBool(15);
             ((bool[]) buf[23])[0] = rslt.wasNull(15);
             ((bool[]) buf[24])[0] = rslt.getBool(16);
             ((bool[]) buf[25])[0] = rslt.wasNull(16);
             ((bool[]) buf[26])[0] = rslt.getBool(17);
             ((bool[]) buf[27])[0] = rslt.wasNull(17);
             ((bool[]) buf[28])[0] = rslt.getBool(18);
             ((bool[]) buf[29])[0] = rslt.wasNull(18);
             ((bool[]) buf[30])[0] = rslt.getBool(19);
             ((bool[]) buf[31])[0] = rslt.wasNull(19);
             ((string[]) buf[32])[0] = rslt.getVarchar(20);
             ((bool[]) buf[33])[0] = rslt.wasNull(20);
             ((DateTime[]) buf[34])[0] = rslt.getGXDate(21);
             ((bool[]) buf[35])[0] = rslt.wasNull(21);
             ((DateTime[]) buf[36])[0] = rslt.getGXDateTime(22);
             ((bool[]) buf[37])[0] = rslt.wasNull(22);
             ((string[]) buf[38])[0] = rslt.getVarchar(23);
             ((bool[]) buf[39])[0] = rslt.wasNull(23);
             ((string[]) buf[40])[0] = rslt.getVarchar(24);
             ((bool[]) buf[41])[0] = rslt.wasNull(24);
             ((string[]) buf[42])[0] = rslt.getVarchar(25);
             ((bool[]) buf[43])[0] = rslt.wasNull(25);
             ((string[]) buf[44])[0] = rslt.getVarchar(26);
             ((bool[]) buf[45])[0] = rslt.wasNull(26);
             ((string[]) buf[46])[0] = rslt.getVarchar(27);
             ((bool[]) buf[47])[0] = rslt.wasNull(27);
             ((string[]) buf[48])[0] = rslt.getVarchar(28);
             ((bool[]) buf[49])[0] = rslt.wasNull(28);
             ((string[]) buf[50])[0] = rslt.getVarchar(29);
             ((bool[]) buf[51])[0] = rslt.wasNull(29);
             ((string[]) buf[52])[0] = rslt.getVarchar(30);
             ((bool[]) buf[53])[0] = rslt.wasNull(30);
             ((string[]) buf[54])[0] = rslt.getVarchar(31);
             ((bool[]) buf[55])[0] = rslt.wasNull(31);
             ((string[]) buf[56])[0] = rslt.getVarchar(32);
             ((bool[]) buf[57])[0] = rslt.wasNull(32);
             ((DateTime[]) buf[58])[0] = rslt.getGXDateTime(33);
             ((bool[]) buf[59])[0] = rslt.wasNull(33);
             ((DateTime[]) buf[60])[0] = rslt.getGXDateTime(34);
             ((bool[]) buf[61])[0] = rslt.wasNull(34);
             ((string[]) buf[62])[0] = rslt.getVarchar(35);
             ((short[]) buf[63])[0] = rslt.getShort(36);
             ((bool[]) buf[64])[0] = rslt.wasNull(36);
             ((short[]) buf[65])[0] = rslt.getShort(37);
             ((short[]) buf[66])[0] = rslt.getShort(38);
             return;
          case 25 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 26 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             return;
    }
    getresults30( cursor, rslt, buf) ;
 }

 public void getresults30( int cursor ,
                           IFieldGetter rslt ,
                           Object[] buf )
 {
    switch ( cursor )
    {
          case 30 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 31 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 32 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 33 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((long[]) buf[1])[0] = rslt.getLong(2);
             return;
    }
 }

}

}
