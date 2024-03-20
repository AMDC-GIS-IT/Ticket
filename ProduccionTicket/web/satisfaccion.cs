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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class satisfaccion : GXWebComponent, System.Web.SessionState.IRequiresSessionState
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
               AV7SatisfaccionId = (long)(NumberUtil.Val( GetPar( "SatisfaccionId"), "."));
               AssignAttri(sPrefix, false, "AV7SatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7SatisfaccionId), 10, 0));
               setjustcreated();
               componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)Gx_mode,(long)AV7SatisfaccionId});
               componentstart();
               context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
               componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel26"+"_"+"") == 0 )
            {
               A15UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA93066( A15UsuarioId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel27"+"_"+"") == 0 )
            {
               A8SatisfaccionResueltoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionResueltoId"), "."));
               AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA33066( A8SatisfaccionResueltoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel28"+"_"+"") == 0 )
            {
               A9SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoProblemaId"), "."));
               AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA36066( A9SatisfaccionTecnicoProblemaId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel29"+"_"+"") == 0 )
            {
               A10SatisfaccionTecnicoCompetenteId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoCompetenteId"), "."));
               AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA35066( A10SatisfaccionTecnicoCompetenteId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel30"+"_"+"") == 0 )
            {
               A11SatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoProfesionalismoId"), "."));
               AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA37066( A11SatisfaccionTecnicoProfesionalismoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel31"+"_"+"") == 0 )
            {
               A12SatisfaccionTiempoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTiempoId"), "."));
               AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA38066( A12SatisfaccionTiempoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel32"+"_"+"") == 0 )
            {
               A13SatisfaccionAtencionId = (short)(NumberUtil.Val( GetPar( "SatisfaccionAtencionId"), "."));
               AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXASA31066( A13SatisfaccionAtencionId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_48") == 0 )
            {
               A14TicketId = (long)(NumberUtil.Val( GetPar( "TicketId"), "."));
               AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_48( A14TicketId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_61") == 0 )
            {
               A15UsuarioId = (long)(NumberUtil.Val( GetPar( "UsuarioId"), "."));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_61( A15UsuarioId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_49") == 0 )
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
               gxLoad_49( A14TicketId, A16TicketResponsableId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_60") == 0 )
            {
               A198TicketTecnicoResponsableId = (short)(NumberUtil.Val( GetPar( "TicketTecnicoResponsableId"), "."));
               AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_60( A198TicketTecnicoResponsableId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_50") == 0 )
            {
               A8SatisfaccionResueltoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionResueltoId"), "."));
               AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_50( A8SatisfaccionResueltoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_51") == 0 )
            {
               A9SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoProblemaId"), "."));
               AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_51( A9SatisfaccionTecnicoProblemaId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_52") == 0 )
            {
               A10SatisfaccionTecnicoCompetenteId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoCompetenteId"), "."));
               AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_52( A10SatisfaccionTecnicoCompetenteId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_53") == 0 )
            {
               A11SatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTecnicoProfesionalismoId"), "."));
               AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_53( A11SatisfaccionTecnicoProfesionalismoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_54") == 0 )
            {
               A12SatisfaccionTiempoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionTiempoId"), "."));
               AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_54( A12SatisfaccionTiempoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_55") == 0 )
            {
               A13SatisfaccionAtencionId = (short)(NumberUtil.Val( GetPar( "SatisfaccionAtencionId"), "."));
               AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_55( A13SatisfaccionAtencionId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_56") == 0 )
            {
               A347SatisfaccionCatalogaId = (short)(NumberUtil.Val( GetPar( "SatisfaccionCatalogaId"), "."));
               AssignAttri(sPrefix, false, "A347SatisfaccionCatalogaId", StringUtil.LTrimStr( (decimal)(A347SatisfaccionCatalogaId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_56( A347SatisfaccionCatalogaId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_57") == 0 )
            {
               A350SatisfaccionRendimientoId = (short)(NumberUtil.Val( GetPar( "SatisfaccionRendimientoId"), "."));
               AssignAttri(sPrefix, false, "A350SatisfaccionRendimientoId", StringUtil.LTrimStr( (decimal)(A350SatisfaccionRendimientoId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_57( A350SatisfaccionRendimientoId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_58") == 0 )
            {
               A353SatisfaccionProgramadorId = (short)(NumberUtil.Val( GetPar( "SatisfaccionProgramadorId"), "."));
               AssignAttri(sPrefix, false, "A353SatisfaccionProgramadorId", StringUtil.LTrimStr( (decimal)(A353SatisfaccionProgramadorId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_58( A353SatisfaccionProgramadorId) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_59") == 0 )
            {
               A356SatisfaccionCapacitacionId = (short)(NumberUtil.Val( GetPar( "SatisfaccionCapacitacionId"), "."));
               AssignAttri(sPrefix, false, "A356SatisfaccionCapacitacionId", StringUtil.LTrimStr( (decimal)(A356SatisfaccionCapacitacionId), 4, 0));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxLoad_59( A356SatisfaccionCapacitacionId) ;
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
                  AV7SatisfaccionId = (long)(NumberUtil.Val( GetPar( "SatisfaccionId"), "."));
                  AssignAttri(sPrefix, false, "AV7SatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7SatisfaccionId), 10, 0));
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
               Form.Meta.addItem("description", "Satisfaccion", 0) ;
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
            GX_FocusControl = edtSatisfaccionFecha_Internalname;
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

      public satisfaccion( )
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

      public satisfaccion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           long aP1_SatisfaccionId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7SatisfaccionId = aP1_SatisfaccionId;
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
            return "satisfaccion_Execute" ;
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
            RenderHtmlCloseForm066( ) ;
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
            GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "satisfaccion.aspx");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionid_Internalname, divK2btoolstable_attributecontainersatisfaccionid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionId_Internalname, "Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A7SatisfaccionId), 10, 0, ".", "")), StringUtil.LTrim( ((edtSatisfaccionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A7SatisfaccionId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionfecha_Internalname, divK2btoolstable_attributecontainersatisfaccionfecha_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionFecha_Internalname, "Fecha Encuesta:", "gx-form-item Attribute_TrnDateLabel Attribute_RequiredLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSatisfaccionFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionFecha_Internalname, context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"), context.localUtil.Format( A32SatisfaccionFecha, "99/99/9999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,30);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionFecha_Jsonclick, 0, "Attribute_TrnDate Attribute_Required", "", "", "", "", 1, edtSatisfaccionFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_Satisfaccion.htm");
         GxWebStd.gx_bitmap( context, edtSatisfaccionFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSatisfaccionFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Satisfaccion.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionhora_Internalname, divK2btoolstable_attributecontainersatisfaccionhora_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionHora_Internalname, "Hora", "gx-form-item Attribute_TrnDateTimeLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSatisfaccionHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionHora_Internalname, context.localUtil.TToC( A144SatisfaccionHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A144SatisfaccionHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionHora_Jsonclick, 0, "Attribute_TrnDateTime", "", "", "", "", 1, edtSatisfaccionHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Hora", "right", false, "", "HLP_Satisfaccion.htm");
         GxWebStd.gx_bitmap( context, edtSatisfaccionHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSatisfaccionHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divTableclmid1_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketresponsableid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketResponsableId_Internalname, "Ticket Responsable Id", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A16TicketResponsableId), "ZZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketResponsableId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketResponsableId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_16_Internalname, sImgUrl, imgprompt_16_Link, "", "", context.GetTheme( ), imgprompt_16_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
         GxWebStd.gx_label_element( context, edtUsuarioFecha_Internalname, "Fecha", "gx-form-item Attribute_TrnDateLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         context.WriteHtmlText( "<div id=\""+edtUsuarioFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtUsuarioFecha_Internalname, context.localUtil.Format(A90UsuarioFecha, "99/99/9999"), context.localUtil.Format( A90UsuarioFecha, "99/99/9999"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioFecha_Jsonclick, 0, "Attribute_TrnDate", "", "", "", "", 1, edtUsuarioFecha_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "Fecha", "right", false, "", "HLP_Satisfaccion.htm");
         GxWebStd.gx_bitmap( context, edtUsuarioFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtUsuarioFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainerticketid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketId_Internalname, "Id Ticket", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTicketId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A14TicketId), "ZZZZZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketId_Enabled, 1, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_14_Internalname, sImgUrl, imgprompt_14_Link, "", "", context.GetTheme( ), imgprompt_14_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoresponsableid_Internalname, divK2btoolstable_attributecontainertickettecnicoresponsableid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoResponsableId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoResponsableId_Internalname, "Id Técnico", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
         GxWebStd.gx_single_line_edit( context, edtTicketTecnicoResponsableId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")), StringUtil.LTrim( ((edtTicketTecnicoResponsableId_Enabled!=0) ? context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9") : context.localUtil.Format( (decimal)(A198TicketTecnicoResponsableId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoResponsableId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketTecnicoResponsableId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainertickettecnicoresponsablenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtTicketTecnicoResponsableNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTicketTecnicoResponsableNombre_Internalname, "Técnico", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
         GxWebStd.gx_single_line_edit( context, edtTicketTecnicoResponsableNombre_Internalname, A199TicketTecnicoResponsableNombre, StringUtil.RTrim( context.localUtil.Format( A199TicketTecnicoResponsableNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTicketTecnicoResponsableNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtTicketTecnicoResponsableNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_Satisfaccion.htm");
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
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
         GxWebStd.gx_single_line_edit( context, edtUsuarioId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")), StringUtil.LTrim( ((edtUsuarioId_Enabled!=0) ? context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A15UsuarioId), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuarioId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "NumMax", "right", false, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuarioNombre_Internalname, A93UsuarioNombre, StringUtil.RTrim( context.localUtil.Format( A93UsuarioNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtUsuarioNombre_Link, "", "", "", edtUsuarioNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtUsuarioNombre_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "Nombres", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_html_textarea( context, edtUsuarioRequerimiento_Internalname, A94UsuarioRequerimiento, "", "", 0, 1, edtUsuarioRequerimiento_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_lnresuelto_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_lnresuelto_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lnresuelto_Class, "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lnresuelto_Internalname, "¿Considera resuelto el requerimiento?", "", "", lblLineseparatortitle_lnresuelto_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e11066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_lnresuelto_Internalname, divLineseparatorcontent_lnresuelto_Visible, 0, "px", 0, "px", divLineseparatorcontent_lnresuelto_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionResueltoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionResueltoNombre_Internalname, "Respuesta:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionResueltoNombre_Internalname, A33SatisfaccionResueltoNombre, StringUtil.RTrim( context.localUtil.Format( A33SatisfaccionResueltoNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSatisfaccionResueltoNombre_Link, "", "", "", edtSatisfaccionResueltoNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionResueltoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionresueltoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionResueltoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionResueltoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A8SatisfaccionResueltoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,118);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionResueltoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionResueltoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_8_Internalname, sImgUrl, imgprompt_8_Link, "", "", context.GetTheme( ), imgprompt_8_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_lnproblema_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_lnproblema_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lnproblema_Class, "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lnproblema_Internalname, "¿El técnico pudo identificar rápidamente el problema?", "", "", lblLineseparatortitle_lnproblema_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e12066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_lnproblema_Internalname, divLineseparatorcontent_lnproblema_Visible, 0, "px", 0, "px", divLineseparatorcontent_lnproblema_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTecnicoProblemaNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Respuesta:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTecnicoProblemaNombre_Internalname, A36SatisfaccionTecnicoProblemaNombre, StringUtil.RTrim( context.localUtil.Format( A36SatisfaccionTecnicoProblemaNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSatisfaccionTecnicoProblemaNombre_Link, "", "", "", edtSatisfaccionTecnicoProblemaNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTecnicoProblemaNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoproblemaid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTecnicoProblemaId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTecnicoProblemaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9SatisfaccionTecnicoProblemaId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,136);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionTecnicoProblemaId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTecnicoProblemaId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_lncapacidad_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_lncapacidad_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lncapacidad_Class, "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lncapacidad_Internalname, "¿El técnico parece muy bien informado y competente?", "", "", lblLineseparatortitle_lncapacidad_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e13066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_lncapacidad_Internalname, divLineseparatorcontent_lncapacidad_Visible, 0, "px", 0, "px", divLineseparatorcontent_lncapacidad_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTecnicoCompetenteNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Respuesta:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTecnicoCompetenteNombre_Internalname, A35SatisfaccionTecnicoCompetenteNombre, StringUtil.RTrim( context.localUtil.Format( A35SatisfaccionTecnicoCompetenteNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSatisfaccionTecnicoCompetenteNombre_Link, "", "", "", edtSatisfaccionTecnicoCompetenteNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTecnicoCompetenteNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicocompetenteid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTecnicoCompetenteId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 154,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTecnicoCompetenteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A10SatisfaccionTecnicoCompetenteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,154);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionTecnicoCompetenteId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTecnicoCompetenteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_10_Internalname, sImgUrl, imgprompt_10_Link, "", "", context.GetTheme( ), imgprompt_10_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_lncortesia_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_lncortesia_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lncortesia_Class, "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lncortesia_Internalname, "¿El técnico maneja los problemas con cortesía y profesionalismo?", "", "", lblLineseparatortitle_lncortesia_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e14066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_lncortesia_Internalname, divLineseparatorcontent_lncortesia_Visible, 0, "px", 0, "px", divLineseparatorcontent_lncortesia_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTecnicoProfesionalismoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Respuesta:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, A37SatisfaccionTecnicoProfesionalismoNombre, StringUtil.RTrim( context.localUtil.Format( A37SatisfaccionTecnicoProfesionalismoNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSatisfaccionTecnicoProfesionalismoNombre_Link, "", "", "", edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTecnicoProfesionalismoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTecnicoProfesionalismoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTecnicoProfesionalismoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,172);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionTecnicoProfesionalismoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTecnicoProfesionalismoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_11_Internalname, sImgUrl, imgprompt_11_Link, "", "", context.GetTheme( ), imgprompt_11_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_lntiempo_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_lntiempo_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lntiempo_Class, "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lntiempo_Internalname, "¿Esta conforme con el tiempo resuelto su requerimiento?", "", "", lblLineseparatortitle_lntiempo_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e15066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_lntiempo_Internalname, divLineseparatorcontent_lntiempo_Visible, 0, "px", 0, "px", divLineseparatorcontent_lntiempo_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTiempoNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionTiempoNombre_Internalname, "Respuesta:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTiempoNombre_Internalname, A38SatisfaccionTiempoNombre, StringUtil.RTrim( context.localUtil.Format( A38SatisfaccionTiempoNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSatisfaccionTiempoNombre_Link, "", "", "", edtSatisfaccionTiempoNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTiempoNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfacciontiempoid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionTiempoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 190,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionTiempoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A12SatisfaccionTiempoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,190);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionTiempoId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionTiempoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_12_Internalname, sImgUrl, imgprompt_12_Link, "", "", context.GetTheme( ), imgprompt_12_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_clatencion_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_clatencion_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_clatencion_Class, "left", "top", "", "", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_clatencion_Internalname, "En general, ¿qué tan satisfecho está usted con la atención recibida?", "", "", lblLineseparatortitle_clatencion_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e16066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_clatencion_Internalname, divLineseparatorcontent_clatencion_Visible, 0, "px", 0, "px", divLineseparatorcontent_clatencion_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionatencionid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionAtencionId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'" + sPrefix + "',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionAtencionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A13SatisfaccionAtencionId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,202);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSatisfaccionAtencionId_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionAtencionId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "NumMin", "right", false, "", "HLP_Satisfaccion.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "f5b04895-0024-488b-8e3b-b687ca4598ee", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_13_Internalname, sImgUrl, imgprompt_13_Link, "", "", context.GetTheme( ), imgprompt_13_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionAtencionNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionAtencionNombre_Internalname, "Respuesta:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
         GxWebStd.gx_single_line_edit( context, edtSatisfaccionAtencionNombre_Internalname, A31SatisfaccionAtencionNombre, StringUtil.RTrim( context.localUtil.Format( A31SatisfaccionAtencionNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", edtSatisfaccionAtencionNombre_Link, "", "", "", edtSatisfaccionAtencionNombre_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtSatisfaccionAtencionNombre_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 1, -1, -1, true, "Descripcion", "left", true, "", "HLP_Satisfaccion.htm");
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
         GxWebStd.gx_div_start( context, divLineseparator_lnsugerencia_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorheader_lnsugerencia_Internalname, 1, 0, "px", 0, "px", divLineseparatorheader_lnsugerencia_Class, "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLineseparatortitle_lnsugerencia_Internalname, "¿Tiene algún comentario o sugerencia adicional que hacernos sobre el soporte técnico recibido?", "", "", lblLineseparatortitle_lnsugerencia_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e17066_client"+"'", "", "TextBlock_LineSeparatorOpen", 7, "", 1, 1, 0, 0, "HLP_Satisfaccion.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLineseparatorcontent_lnsugerencia_Internalname, divLineseparatorcontent_lnsugerencia_Visible, 0, "px", 0, "px", divLineseparatorcontent_lnsugerencia_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divK2btoolstable_attributecontainersatisfaccionsugerencia_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtSatisfaccionSugerencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSatisfaccionSugerencia_Internalname, "Sugerencia:", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         AssignAttri(sPrefix, false, "A34SatisfaccionSugerencia", A34SatisfaccionSugerencia);
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 220,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Attribute_Trn";
         StyleString = "";
         ClassString = "Attribute_Trn";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtSatisfaccionSugerencia_Internalname, A34SatisfaccionSugerencia, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,220);\"", 0, 1, edtSatisfaccionSugerencia_Enabled, 0, 80, "chr", 4, "row", StyleString, ClassString, "", "", "300", -1, 0, "", "", -1, true, "Texto", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_Satisfaccion.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'" + sPrefix + "',false,'',0)\"";
         ClassString = "K2BToolsButton_MainAction";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttEnter_Internalname, "", bttEnter_Caption, bttEnter_Jsonclick, 5, bttEnter_Tooltiptext, "", StyleString, ClassString, bttEnter_Visible, bttEnter_Enabled, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Satisfaccion.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 228,'" + sPrefix + "',false,'',0)\"";
         ClassString = "Button_Standard";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttCancel_Internalname, "", "Cancelar", bttCancel_Jsonclick, 5, "Cancelar", "", StyleString, ClassString, bttCancel_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOCANCEL\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_Satisfaccion.htm");
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
         E18062 ();
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
               Z7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z7SatisfaccionId"), ".", ","));
               Z32SatisfaccionFecha = context.localUtil.CToD( cgiGet( sPrefix+"Z32SatisfaccionFecha"), 0);
               Z144SatisfaccionHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( sPrefix+"Z144SatisfaccionHora"), 0));
               Z34SatisfaccionSugerencia = cgiGet( sPrefix+"Z34SatisfaccionSugerencia");
               n34SatisfaccionSugerencia = (String.IsNullOrEmpty(StringUtil.RTrim( A34SatisfaccionSugerencia)) ? true : false);
               Z359SatisfaccionMejoraSoftware = cgiGet( sPrefix+"Z359SatisfaccionMejoraSoftware");
               n359SatisfaccionMejoraSoftware = (String.IsNullOrEmpty(StringUtil.RTrim( A359SatisfaccionMejoraSoftware)) ? true : false);
               Z14TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z14TicketId"), ".", ","));
               Z16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"Z16TicketResponsableId"), ".", ","));
               Z8SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z8SatisfaccionResueltoId"), ".", ","));
               Z9SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z9SatisfaccionTecnicoProblemaId"), ".", ","));
               Z10SatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z10SatisfaccionTecnicoCompetenteId"), ".", ","));
               Z11SatisfaccionTecnicoProfesionalismoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z11SatisfaccionTecnicoProfesionalismoId"), ".", ","));
               Z12SatisfaccionTiempoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z12SatisfaccionTiempoId"), ".", ","));
               Z13SatisfaccionAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z13SatisfaccionAtencionId"), ".", ","));
               Z347SatisfaccionCatalogaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z347SatisfaccionCatalogaId"), ".", ","));
               Z350SatisfaccionRendimientoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z350SatisfaccionRendimientoId"), ".", ","));
               Z353SatisfaccionProgramadorId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z353SatisfaccionProgramadorId"), ".", ","));
               Z356SatisfaccionCapacitacionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z356SatisfaccionCapacitacionId"), ".", ","));
               wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
               wcpOAV7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7SatisfaccionId"), ".", ","));
               A359SatisfaccionMejoraSoftware = cgiGet( sPrefix+"Z359SatisfaccionMejoraSoftware");
               n359SatisfaccionMejoraSoftware = false;
               n359SatisfaccionMejoraSoftware = (String.IsNullOrEmpty(StringUtil.RTrim( A359SatisfaccionMejoraSoftware)) ? true : false);
               A347SatisfaccionCatalogaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z347SatisfaccionCatalogaId"), ".", ","));
               A350SatisfaccionRendimientoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z350SatisfaccionRendimientoId"), ".", ","));
               A353SatisfaccionProgramadorId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z353SatisfaccionProgramadorId"), ".", ","));
               A356SatisfaccionCapacitacionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"Z356SatisfaccionCapacitacionId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( sPrefix+"IsModified"), ".", ","));
               Gx_mode = cgiGet( sPrefix+"Mode");
               N14TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"N14TicketId"), ".", ","));
               N16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"N16TicketResponsableId"), ".", ","));
               N8SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N8SatisfaccionResueltoId"), ".", ","));
               N9SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N9SatisfaccionTecnicoProblemaId"), ".", ","));
               N10SatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N10SatisfaccionTecnicoCompetenteId"), ".", ","));
               N11SatisfaccionTecnicoProfesionalismoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N11SatisfaccionTecnicoProfesionalismoId"), ".", ","));
               N12SatisfaccionTiempoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N12SatisfaccionTiempoId"), ".", ","));
               N13SatisfaccionAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N13SatisfaccionAtencionId"), ".", ","));
               N347SatisfaccionCatalogaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N347SatisfaccionCatalogaId"), ".", ","));
               N350SatisfaccionRendimientoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N350SatisfaccionRendimientoId"), ".", ","));
               N353SatisfaccionProgramadorId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N353SatisfaccionProgramadorId"), ".", ","));
               N356SatisfaccionCapacitacionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"N356SatisfaccionCapacitacionId"), ".", ","));
               AV7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vSATISFACCIONID"), ".", ","));
               AV12Insert_TicketId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_TICKETID"), ".", ","));
               AV32Insert_TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_TICKETRESPONSABLEID"), ".", ","));
               AV13Insert_SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONRESUELTOID"), ".", ","));
               AV14Insert_SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONTECNICOPROBLEMAID"), ".", ","));
               AV15Insert_SatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONTECNICOCOMPETENTEID"), ".", ","));
               AV16Insert_SatisfaccionTecnicoProfesionalismoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONTECNICOPROFESIONALISMOID"), ".", ","));
               AV17Insert_SatisfaccionTiempoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONTIEMPOID"), ".", ","));
               AV18Insert_SatisfaccionAtencionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONATENCIONID"), ".", ","));
               AV35Insert_SatisfaccionCatalogaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONCATALOGAID"), ".", ","));
               A347SatisfaccionCatalogaId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONCATALOGAID"), ".", ","));
               AV36Insert_SatisfaccionRendimientoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONRENDIMIENTOID"), ".", ","));
               A350SatisfaccionRendimientoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONRENDIMIENTOID"), ".", ","));
               AV37Insert_SatisfaccionProgramadorId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONPROGRAMADORID"), ".", ","));
               A353SatisfaccionProgramadorId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONPROGRAMADORID"), ".", ","));
               AV38Insert_SatisfaccionCapacitacionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINSERT_SATISFACCIONCAPACITACIONID"), ".", ","));
               A356SatisfaccionCapacitacionId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONCAPACITACIONID"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vGXBSCREEN"), ".", ","));
               A359SatisfaccionMejoraSoftware = cgiGet( sPrefix+"SATISFACCIONMEJORASOFTWARE");
               n359SatisfaccionMejoraSoftware = (String.IsNullOrEmpty(StringUtil.RTrim( A359SatisfaccionMejoraSoftware)) ? true : false);
               A280SatisfaccionResueltoCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONRESUELTOCALIFICACION"), ".", ","));
               A282SatisfaccionTecnicoProblemaCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONTECNICOPROBLEMACALIFICACION"), ".", ","));
               A281SatisfaccionTecnicoCompetenteCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONTECNICOCOMPETENTECALIFICACION"), ".", ","));
               A283SatisfaccionTecnicoProfesionalismoCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOCALIFICACION"), ".", ","));
               A284SatisfaccionTiempoCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONTIEMPOCALIFICACION"), ".", ","));
               A279SatisfaccionAtencionCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONATENCIONCALIFICACION"), ".", ","));
               A348SatisfaccionCatalogaNombre = cgiGet( sPrefix+"SATISFACCIONCATALOGANOMBRE");
               A349SatisfaccionCatalogaCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONCATALOGACALIFICACION"), ".", ","));
               A351SatisfaccionRendimientoNombre = cgiGet( sPrefix+"SATISFACCIONRENDIMIENTONOMBRE");
               A352SatisfaccionRendimientoCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONRENDIMIENTOCALIFICACION"), ".", ","));
               A354SatisfaccionProgramadorNombre = cgiGet( sPrefix+"SATISFACCIONPROGRAMADORNOMBRE");
               A355SatisfaccionProgramadorCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONPROGRAMADORCALIFICACION"), ".", ","));
               A357SatisfaccionCapacitacionNombre = cgiGet( sPrefix+"SATISFACCIONCAPACITACIONNOMBRE");
               A358SatisfaccionCapacitacionCalificacion = (short)(context.localUtil.CToN( cgiGet( sPrefix+"SATISFACCIONCAPACITACIONCALIFICACION"), ".", ","));
               AV40Pgmname = cgiGet( sPrefix+"vPGMNAME");
               K2bcontrolbeautify1_Objectcall = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall");
               K2bcontrolbeautify1_Class = cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Class");
               K2bcontrolbeautify1_Enabled = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Enabled"));
               K2bcontrolbeautify1_Updatecheckboxes = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Updatecheckboxes"));
               K2bcontrolbeautify1_Visible = StringUtil.StrToBool( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Visible"));
               K2bcontrolbeautify1_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( sPrefix+"K2BCONTROLBEAUTIFY1_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               A7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( edtSatisfaccionId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
               if ( context.localUtil.VCDate( cgiGet( edtSatisfaccionFecha_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "SATISFACCIONFECHA");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionFecha_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A32SatisfaccionFecha = DateTime.MinValue;
                  AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
               }
               else
               {
                  A32SatisfaccionFecha = context.localUtil.CToD( cgiGet( edtSatisfaccionFecha_Internalname), 2);
                  AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtSatisfaccionHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "SATISFACCIONHORA");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionHora_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
                  AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A144SatisfaccionHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtSatisfaccionHora_Internalname)));
                  AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
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
                  A16TicketResponsableId = (long)(context.localUtil.CToN( cgiGet( edtTicketResponsableId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
               }
               A90UsuarioFecha = context.localUtil.CToD( cgiGet( edtUsuarioFecha_Internalname), 2);
               AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
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
                  A14TicketId = (long)(context.localUtil.CToN( cgiGet( edtTicketId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
               }
               A198TicketTecnicoResponsableId = (short)(context.localUtil.CToN( cgiGet( edtTicketTecnicoResponsableId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
               A199TicketTecnicoResponsableNombre = cgiGet( edtTicketTecnicoResponsableNombre_Internalname);
               AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
               A15UsuarioId = (long)(context.localUtil.CToN( cgiGet( edtUsuarioId_Internalname), ".", ","));
               AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
               A93UsuarioNombre = cgiGet( edtUsuarioNombre_Internalname);
               AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
               A94UsuarioRequerimiento = cgiGet( edtUsuarioRequerimiento_Internalname);
               AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
               A33SatisfaccionResueltoNombre = cgiGet( edtSatisfaccionResueltoNombre_Internalname);
               AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionResueltoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionResueltoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SATISFACCIONRESUELTOID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionResueltoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A8SatisfaccionResueltoId = 0;
                  AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
               }
               else
               {
                  A8SatisfaccionResueltoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionResueltoId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
               }
               A36SatisfaccionTecnicoProblemaNombre = cgiGet( edtSatisfaccionTecnicoProblemaNombre_Internalname);
               AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProblemaId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProblemaId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SATISFACCIONTECNICOPROBLEMAID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionTecnicoProblemaId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9SatisfaccionTecnicoProblemaId = 0;
                  AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
               }
               else
               {
                  A9SatisfaccionTecnicoProblemaId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProblemaId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
               }
               A35SatisfaccionTecnicoCompetenteNombre = cgiGet( edtSatisfaccionTecnicoCompetenteNombre_Internalname);
               AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoCompetenteId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoCompetenteId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SATISFACCIONTECNICOCOMPETENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionTecnicoCompetenteId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A10SatisfaccionTecnicoCompetenteId = 0;
                  AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
               }
               else
               {
                  A10SatisfaccionTecnicoCompetenteId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoCompetenteId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
               }
               A37SatisfaccionTecnicoProfesionalismoNombre = cgiGet( edtSatisfaccionTecnicoProfesionalismoNombre_Internalname);
               AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProfesionalismoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProfesionalismoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SATISFACCIONTECNICOPROFESIONALISMOID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionTecnicoProfesionalismoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A11SatisfaccionTecnicoProfesionalismoId = 0;
                  AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
               }
               else
               {
                  A11SatisfaccionTecnicoProfesionalismoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTecnicoProfesionalismoId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
               }
               A38SatisfaccionTiempoNombre = cgiGet( edtSatisfaccionTiempoNombre_Internalname);
               AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTiempoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionTiempoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SATISFACCIONTIEMPOID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionTiempoId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A12SatisfaccionTiempoId = 0;
                  AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
               }
               else
               {
                  A12SatisfaccionTiempoId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionTiempoId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionAtencionId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSatisfaccionAtencionId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SATISFACCIONATENCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionAtencionId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A13SatisfaccionAtencionId = 0;
                  AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
               }
               else
               {
                  A13SatisfaccionAtencionId = (short)(context.localUtil.CToN( cgiGet( edtSatisfaccionAtencionId_Internalname), ".", ","));
                  AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
               }
               A31SatisfaccionAtencionNombre = cgiGet( edtSatisfaccionAtencionNombre_Internalname);
               AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
               A34SatisfaccionSugerencia = cgiGet( edtSatisfaccionSugerencia_Internalname);
               n34SatisfaccionSugerencia = false;
               AssignAttri(sPrefix, false, "A34SatisfaccionSugerencia", A34SatisfaccionSugerencia);
               n34SatisfaccionSugerencia = (String.IsNullOrEmpty(StringUtil.RTrim( A34SatisfaccionSugerencia)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Satisfaccion");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("SatisfaccionMejoraSoftware", StringUtil.RTrim( context.localUtil.Format( A359SatisfaccionMejoraSoftware, "")));
               hsh = cgiGet( sPrefix+"hsh");
               if ( ( ! ( ( A7SatisfaccionId != Z7SatisfaccionId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("satisfaccion:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A7SatisfaccionId = (long)(NumberUtil.Val( GetPar( "SatisfaccionId"), "."));
                  AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttEnter_Internalname;
                              AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "SATISFACCIONID");
                        AnyError = 1;
                        GX_FocusControl = edtSatisfaccionId_Internalname;
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
                                 E18062 ();
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
                                 E19062 ();
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
                                 E20062 ();
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
            E19062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll066( ) ;
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
            DisableAttributes066( ) ;
         }
         AssignProp(sPrefix, false, edtSatisfaccionFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionFecha_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionHora_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTicketTecnicoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtTicketTecnicoResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionNombre_Enabled), 5, 0), true);
         AssignProp(sPrefix, false, edtSatisfaccionSugerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionSugerencia_Enabled), 5, 0), true);
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri(sPrefix, false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E18062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV23StandardActivityType = "Insert";
            AssignAttri(sPrefix, false, "AV23StandardActivityType", AV23StandardActivityType);
            AV24UserActivityType = "";
            AssignAttri(sPrefix, false, "AV24UserActivityType", AV24UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV23StandardActivityType = "Update";
            AssignAttri(sPrefix, false, "AV23StandardActivityType", AV23StandardActivityType);
            AV24UserActivityType = "";
            AssignAttri(sPrefix, false, "AV24UserActivityType", AV24UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV23StandardActivityType = "Delete";
            AssignAttri(sPrefix, false, "AV23StandardActivityType", AV23StandardActivityType);
            AV24UserActivityType = "";
            AssignAttri(sPrefix, false, "AV24UserActivityType", AV24UserActivityType);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            AV23StandardActivityType = "Display";
            AssignAttri(sPrefix, false, "AV23StandardActivityType", AV23StandardActivityType);
            AV24UserActivityType = "";
            AssignAttri(sPrefix, false, "AV24UserActivityType", AV24UserActivityType);
         }
         new k2bisauthorizedactivityname(context ).execute(  "Satisfaccion",  "Satisfaccion",  AV23StandardActivityType,  AV24UserActivityType,  AV40Pgmname, out  AV25IsAuthorized) ;
         AssignAttri(sPrefix, false, "AV25IsAuthorized", AV25IsAuthorized);
         if ( ! AV25IsAuthorized )
         {
            CallWebObject(formatLink("k2bnotauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim("Satisfaccion")),UrlEncode(StringUtil.RTrim("Satisfaccion")),UrlEncode(StringUtil.RTrim(AV23StandardActivityType)),UrlEncode(StringUtil.RTrim(AV24UserActivityType)),UrlEncode(StringUtil.RTrim(AV40Pgmname))}, new string[] {"EntityName","TransactionName","StandardActivityType","UserActivityType","ProgramName"}) );
            context.wjLocDisableFrm = 1;
         }
         else
         {
         }
         new k2bgetcontext(context ).execute( out  AV19Context) ;
         AV20BtnCaption = "Confirmar";
         AssignAttri(sPrefix, false, "AV20BtnCaption", AV20BtnCaption);
         AV21BtnTooltip = "Confirmar";
         AssignAttri(sPrefix, false, "AV21BtnTooltip", AV21BtnTooltip);
         if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV20BtnCaption = "Actualizar";
            AssignAttri(sPrefix, false, "AV20BtnCaption", AV20BtnCaption);
            AV21BtnTooltip = "Actualizar";
            AssignAttri(sPrefix, false, "AV21BtnTooltip", AV21BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV20BtnCaption = "Confirmar";
            AssignAttri(sPrefix, false, "AV20BtnCaption", AV20BtnCaption);
            AV21BtnTooltip = "Confirmar";
            AssignAttri(sPrefix, false, "AV21BtnTooltip", AV21BtnTooltip);
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV20BtnCaption = "Eliminar";
            AssignAttri(sPrefix, false, "AV20BtnCaption", AV20BtnCaption);
            AV21BtnTooltip = "Eliminar";
            AssignAttri(sPrefix, false, "AV21BtnTooltip", AV21BtnTooltip);
         }
         bttEnter_Caption = AV20BtnCaption;
         AssignProp(sPrefix, false, bttEnter_Internalname, "Caption", bttEnter_Caption, true);
         bttEnter_Tooltiptext = AV21BtnTooltip;
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
         new k2bgettrncontextbyname(context ).execute(  "Satisfaccion", out  AV8TrnContext) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Popup") == 0 )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               Form.Caption = StringUtil.Format( "Insertar %1", "Satisfaccion", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
            {
               Form.Caption = StringUtil.Format( "Actualizar %1", "Satisfaccion", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               Form.Caption = StringUtil.Format( "Eliminar %1", "Satisfaccion", "", "", "", "", "", "", "", "");
               AssignProp(sPrefix, false, "FORM", "Caption", Form.Caption, true);
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV41GXV1 = 1;
            AssignAttri(sPrefix, false, "AV41GXV1", StringUtil.LTrimStr( (decimal)(AV41GXV1), 8, 0));
            while ( AV41GXV1 <= AV8TrnContext.gxTpr_Attributes.Count )
            {
               AV9TrnContextAtt = ((SdtK2BTrnContext_Attribute)AV8TrnContext.gxTpr_Attributes.Item(AV41GXV1));
               if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "TicketId") == 0 )
               {
                  AV12Insert_TicketId = (long)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV12Insert_TicketId", StringUtil.LTrimStr( (decimal)(AV12Insert_TicketId), 10, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "TicketResponsableId") == 0 )
               {
                  AV32Insert_TicketResponsableId = (long)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV32Insert_TicketResponsableId", StringUtil.LTrimStr( (decimal)(AV32Insert_TicketResponsableId), 10, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionResueltoId") == 0 )
               {
                  AV13Insert_SatisfaccionResueltoId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV13Insert_SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(AV13Insert_SatisfaccionResueltoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionTecnicoProblemaId") == 0 )
               {
                  AV14Insert_SatisfaccionTecnicoProblemaId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV14Insert_SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(AV14Insert_SatisfaccionTecnicoProblemaId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionTecnicoCompetenteId") == 0 )
               {
                  AV15Insert_SatisfaccionTecnicoCompetenteId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV15Insert_SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(AV15Insert_SatisfaccionTecnicoCompetenteId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionTecnicoProfesionalismoId") == 0 )
               {
                  AV16Insert_SatisfaccionTecnicoProfesionalismoId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV16Insert_SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(AV16Insert_SatisfaccionTecnicoProfesionalismoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionTiempoId") == 0 )
               {
                  AV17Insert_SatisfaccionTiempoId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV17Insert_SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(AV17Insert_SatisfaccionTiempoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionAtencionId") == 0 )
               {
                  AV18Insert_SatisfaccionAtencionId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV18Insert_SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(AV18Insert_SatisfaccionAtencionId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionCatalogaId") == 0 )
               {
                  AV35Insert_SatisfaccionCatalogaId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV35Insert_SatisfaccionCatalogaId", StringUtil.LTrimStr( (decimal)(AV35Insert_SatisfaccionCatalogaId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionRendimientoId") == 0 )
               {
                  AV36Insert_SatisfaccionRendimientoId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV36Insert_SatisfaccionRendimientoId", StringUtil.LTrimStr( (decimal)(AV36Insert_SatisfaccionRendimientoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionProgramadorId") == 0 )
               {
                  AV37Insert_SatisfaccionProgramadorId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV37Insert_SatisfaccionProgramadorId", StringUtil.LTrimStr( (decimal)(AV37Insert_SatisfaccionProgramadorId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV9TrnContextAtt.gxTpr_Attributename, "SatisfaccionCapacitacionId") == 0 )
               {
                  AV38Insert_SatisfaccionCapacitacionId = (short)(NumberUtil.Val( AV9TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri(sPrefix, false, "AV38Insert_SatisfaccionCapacitacionId", StringUtil.LTrimStr( (decimal)(AV38Insert_SatisfaccionCapacitacionId), 4, 0));
               }
               AV41GXV1 = (int)(AV41GXV1+1);
               AssignAttri(sPrefix, false, "AV41GXV1", StringUtil.LTrimStr( (decimal)(AV41GXV1), 8, 0));
            }
         }
         divK2btoolstable_attributecontainersatisfaccionid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainersatisfaccionid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfaccionid_Visible), 5, 0), true);
         divK2btoolstable_attributecontainersatisfaccionfecha_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainersatisfaccionfecha_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfaccionfecha_Visible), 5, 0), true);
         divK2btoolstable_attributecontainersatisfaccionhora_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainersatisfaccionhora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainersatisfaccionhora_Visible), 5, 0), true);
         divK2btoolstable_attributecontainertickettecnicoresponsableid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainertickettecnicoresponsableid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainertickettecnicoresponsableid_Visible), 5, 0), true);
         divK2btoolstable_attributecontainerusuarioid_Visible = 0;
         AssignProp(sPrefix, false, divK2btoolstable_attributecontainerusuarioid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divK2btoolstable_attributecontainerusuarioid_Visible), 5, 0), true);
      }

      protected void E19062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( AV8TrnContext.gxTpr_Savepk || ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 ) )
         {
            AV27AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
            AV28AttributeValueItem = new SdtK2BAttributeValue_Item(context);
            AV28AttributeValueItem.gxTpr_Attributename = "SatisfaccionId";
            AV28AttributeValueItem.gxTpr_Attributevalue = StringUtil.Str( (decimal)(A7SatisfaccionId), 10, 0);
            AV27AttributeValue.Add(AV28AttributeValueItem, 0);
            new k2bsettransactionpk(context ).execute(  "Satisfaccion",  AV27AttributeValue) ;
         }
         AV29Message = new GeneXus.Utils.SdtMessages_Message(context);
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV29Message.gxTpr_Description = StringUtil.Format( "La satisfaccion %1 fue creada", context.localUtil.DToC( A32SatisfaccionFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
         {
            AV29Message.gxTpr_Description = StringUtil.Format( "La satisfaccion %1 fue actualizada", context.localUtil.DToC( A32SatisfaccionFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV29Message.gxTpr_Description = StringUtil.Format( "La satisfaccion %1 fue eliminada", context.localUtil.DToC( A32SatisfaccionFecha, 2, "/"), "", "", "", "", "", "", "", "");
         }
         new k2btoolsmessagequeueadd(context ).execute(  AV29Message) ;
         if ( StringUtil.StrCmp(AV8TrnContext.gxTpr_Returnmode, "Modal") == 0 )
         {
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalConfirmed", new Object[] {(string)"Satisfaccion",(GXBaseCollection<SdtK2BAttributeValue_Item>)AV27AttributeValue}, true);
         }
         else
         {
            if ( ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( AV8TrnContext.gxTpr_Afterinsert.gxTpr_Aftertrn != 5 ) ) || ( ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) && ( AV8TrnContext.gxTpr_Afterupdate.gxTpr_Aftertrn != 5 ) ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
            {
               new k2bremovetrncontextbyname(context ).execute(  "Satisfaccion") ;
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV27AttributeValue", AV27AttributeValue);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV10Navigation", AV10Navigation);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV8TrnContext", AV8TrnContext);
      }

      protected void S112( )
      {
         /* 'DOAFTERTRNACTION' Routine */
         returnInSub = false;
         AV26encrypt = AV8TrnContext.gxTpr_Entitymanagerencrypturlparameters;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV26encrypt)) )
         {
            GXt_char1 = AV26encrypt;
            new k2btoolsgetuseencryption(context ).execute( out  GXt_char1) ;
            AV26encrypt = GXt_char1;
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
               if ( StringUtil.StrCmp(AV26encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A7SatisfaccionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                        A7SatisfaccionId = (long)(args[2]) ;
                        AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV26encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A7SatisfaccionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[1]) ;
                           A7SatisfaccionId = (long)(args[2]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV8TrnContext.gxTpr_Entitymanagernexttaskmode,(long)A7SatisfaccionId,AV8TrnContext.gxTpr_Entitymanagernexttaskcode} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV8TrnContext.gxTpr_Entitymanagernexttaskmode = (string)(args[0]) ;
                           A7SatisfaccionId = (long)(args[1]) ;
                           AV8TrnContext.gxTpr_Entitymanagernexttaskcode = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskmode)),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(AV8TrnContext.gxTpr_Entitymanagernexttaskcode))}, new string[] {}) ;
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
               if ( StringUtil.StrCmp(AV26encrypt, "SITE") == 0 )
               {
                  try {
                     args = new Object[] {(string)"_site_encryption",AV10Navigation.gxTpr_Mode,(long)A7SatisfaccionId,AV10Navigation.gxTpr_Extraparameter} ;
                     ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                     if ( ( args != null ) && ( args.Length == 4 ) )
                     {
                        AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                        A7SatisfaccionId = (long)(args[2]) ;
                        AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                     }
                     AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
                  }
                  catch (GxClassLoaderException) {
                     if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                     else
                     {
                        GXKey = Crypto.GetSiteKey( );
                        GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                        context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                     }
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(AV26encrypt, "SESSION") == 0 )
                  {
                     try {
                        args = new Object[] {(string)"_session_encryption",AV10Navigation.gxTpr_Mode,(long)A7SatisfaccionId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 4 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[1]) ;
                           A7SatisfaccionId = (long)(args[2]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[3]) ;
                        }
                        AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+".aspx"+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
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
                           GXEncryptionTmp = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)) + "," + UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)) + "," + UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter));
                           context.wjLoc = StringUtil.Trim( StringUtil.Lower( AV11DinamicObjToLink))+ "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
                        }
                     }
                  }
                  else
                  {
                     try {
                        args = new Object[] {AV10Navigation.gxTpr_Mode,(long)A7SatisfaccionId,AV10Navigation.gxTpr_Extraparameter} ;
                        ClassLoader.WebExecute(AV11DinamicObjToLink,"GeneXus.Programs",AV11DinamicObjToLink.ToLower().Trim(), new Object[] {context }, "execute", args);
                        if ( ( args != null ) && ( args.Length == 3 ) )
                        {
                           AV10Navigation.gxTpr_Mode = (string)(args[0]) ;
                           A7SatisfaccionId = (long)(args[1]) ;
                           AV10Navigation.gxTpr_Extraparameter = (string)(args[2]) ;
                        }
                        AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
                     }
                     catch (GxClassLoaderException) {
                        if ( AV11DinamicObjToLink .Trim().Length < 6 || AV11DinamicObjToLink .Substring( AV11DinamicObjToLink .Trim().Length - 5, 5) != ".aspx")
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink+".aspx", new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
                        }
                        else
                        {
                           context.wjLoc = formatLink(AV11DinamicObjToLink, new object[] {UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Mode)),UrlEncode(StringUtil.LTrimStr(A7SatisfaccionId,10,0)),UrlEncode(StringUtil.RTrim(AV10Navigation.gxTpr_Extraparameter))}, new string[] {}) ;
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

      protected void E20062( )
      {
         /* 'DoCancel' Routine */
         returnInSub = false;
         new k2bremovetrncontextbyname(context ).execute(  "Satisfaccion") ;
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
            this.executeExternalObjectMethod(sPrefix, false, "GlobalEvents", "K2BT_ModalCancelled", new Object[] {(string)"Satisfaccion"}, true);
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
            AV22Url = AV8TrnContext.gxTpr_Callerurl;
            CallWebObject(formatLink(AV22Url) );
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

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 47 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z32SatisfaccionFecha = T00063_A32SatisfaccionFecha[0];
               Z144SatisfaccionHora = T00063_A144SatisfaccionHora[0];
               Z34SatisfaccionSugerencia = T00063_A34SatisfaccionSugerencia[0];
               Z359SatisfaccionMejoraSoftware = T00063_A359SatisfaccionMejoraSoftware[0];
               Z14TicketId = T00063_A14TicketId[0];
               Z16TicketResponsableId = T00063_A16TicketResponsableId[0];
               Z8SatisfaccionResueltoId = T00063_A8SatisfaccionResueltoId[0];
               Z9SatisfaccionTecnicoProblemaId = T00063_A9SatisfaccionTecnicoProblemaId[0];
               Z10SatisfaccionTecnicoCompetenteId = T00063_A10SatisfaccionTecnicoCompetenteId[0];
               Z11SatisfaccionTecnicoProfesionalismoId = T00063_A11SatisfaccionTecnicoProfesionalismoId[0];
               Z12SatisfaccionTiempoId = T00063_A12SatisfaccionTiempoId[0];
               Z13SatisfaccionAtencionId = T00063_A13SatisfaccionAtencionId[0];
               Z347SatisfaccionCatalogaId = T00063_A347SatisfaccionCatalogaId[0];
               Z350SatisfaccionRendimientoId = T00063_A350SatisfaccionRendimientoId[0];
               Z353SatisfaccionProgramadorId = T00063_A353SatisfaccionProgramadorId[0];
               Z356SatisfaccionCapacitacionId = T00063_A356SatisfaccionCapacitacionId[0];
            }
            else
            {
               Z32SatisfaccionFecha = A32SatisfaccionFecha;
               Z144SatisfaccionHora = A144SatisfaccionHora;
               Z34SatisfaccionSugerencia = A34SatisfaccionSugerencia;
               Z359SatisfaccionMejoraSoftware = A359SatisfaccionMejoraSoftware;
               Z14TicketId = A14TicketId;
               Z16TicketResponsableId = A16TicketResponsableId;
               Z8SatisfaccionResueltoId = A8SatisfaccionResueltoId;
               Z9SatisfaccionTecnicoProblemaId = A9SatisfaccionTecnicoProblemaId;
               Z10SatisfaccionTecnicoCompetenteId = A10SatisfaccionTecnicoCompetenteId;
               Z11SatisfaccionTecnicoProfesionalismoId = A11SatisfaccionTecnicoProfesionalismoId;
               Z12SatisfaccionTiempoId = A12SatisfaccionTiempoId;
               Z13SatisfaccionAtencionId = A13SatisfaccionAtencionId;
               Z347SatisfaccionCatalogaId = A347SatisfaccionCatalogaId;
               Z350SatisfaccionRendimientoId = A350SatisfaccionRendimientoId;
               Z353SatisfaccionProgramadorId = A353SatisfaccionProgramadorId;
               Z356SatisfaccionCapacitacionId = A356SatisfaccionCapacitacionId;
            }
         }
         if ( GX_JID == -47 )
         {
            Z7SatisfaccionId = A7SatisfaccionId;
            Z32SatisfaccionFecha = A32SatisfaccionFecha;
            Z144SatisfaccionHora = A144SatisfaccionHora;
            Z34SatisfaccionSugerencia = A34SatisfaccionSugerencia;
            Z359SatisfaccionMejoraSoftware = A359SatisfaccionMejoraSoftware;
            Z14TicketId = A14TicketId;
            Z16TicketResponsableId = A16TicketResponsableId;
            Z8SatisfaccionResueltoId = A8SatisfaccionResueltoId;
            Z9SatisfaccionTecnicoProblemaId = A9SatisfaccionTecnicoProblemaId;
            Z10SatisfaccionTecnicoCompetenteId = A10SatisfaccionTecnicoCompetenteId;
            Z11SatisfaccionTecnicoProfesionalismoId = A11SatisfaccionTecnicoProfesionalismoId;
            Z12SatisfaccionTiempoId = A12SatisfaccionTiempoId;
            Z13SatisfaccionAtencionId = A13SatisfaccionAtencionId;
            Z347SatisfaccionCatalogaId = A347SatisfaccionCatalogaId;
            Z350SatisfaccionRendimientoId = A350SatisfaccionRendimientoId;
            Z353SatisfaccionProgramadorId = A353SatisfaccionProgramadorId;
            Z356SatisfaccionCapacitacionId = A356SatisfaccionCapacitacionId;
            Z348SatisfaccionCatalogaNombre = A348SatisfaccionCatalogaNombre;
            Z349SatisfaccionCatalogaCalificacion = A349SatisfaccionCatalogaCalificacion;
            Z351SatisfaccionRendimientoNombre = A351SatisfaccionRendimientoNombre;
            Z352SatisfaccionRendimientoCalificacion = A352SatisfaccionRendimientoCalificacion;
            Z354SatisfaccionProgramadorNombre = A354SatisfaccionProgramadorNombre;
            Z355SatisfaccionProgramadorCalificacion = A355SatisfaccionProgramadorCalificacion;
            Z357SatisfaccionCapacitacionNombre = A357SatisfaccionCapacitacionNombre;
            Z358SatisfaccionCapacitacionCalificacion = A358SatisfaccionCapacitacionCalificacion;
            Z15UsuarioId = A15UsuarioId;
            Z93UsuarioNombre = A93UsuarioNombre;
            Z90UsuarioFecha = A90UsuarioFecha;
            Z94UsuarioRequerimiento = A94UsuarioRequerimiento;
            Z198TicketTecnicoResponsableId = A198TicketTecnicoResponsableId;
            Z199TicketTecnicoResponsableNombre = A199TicketTecnicoResponsableNombre;
            Z33SatisfaccionResueltoNombre = A33SatisfaccionResueltoNombre;
            Z280SatisfaccionResueltoCalificacion = A280SatisfaccionResueltoCalificacion;
            Z36SatisfaccionTecnicoProblemaNombre = A36SatisfaccionTecnicoProblemaNombre;
            Z282SatisfaccionTecnicoProblemaCalificacion = A282SatisfaccionTecnicoProblemaCalificacion;
            Z35SatisfaccionTecnicoCompetenteNombre = A35SatisfaccionTecnicoCompetenteNombre;
            Z281SatisfaccionTecnicoCompetenteCalificacion = A281SatisfaccionTecnicoCompetenteCalificacion;
            Z37SatisfaccionTecnicoProfesionalismoNombre = A37SatisfaccionTecnicoProfesionalismoNombre;
            Z283SatisfaccionTecnicoProfesionalismoCalificacion = A283SatisfaccionTecnicoProfesionalismoCalificacion;
            Z38SatisfaccionTiempoNombre = A38SatisfaccionTiempoNombre;
            Z284SatisfaccionTiempoCalificacion = A284SatisfaccionTiempoCalificacion;
            Z31SatisfaccionAtencionNombre = A31SatisfaccionAtencionNombre;
            Z279SatisfaccionAtencionCalificacion = A279SatisfaccionAtencionCalificacion;
         }
      }

      protected void standaloneNotModal( )
      {
         edtSatisfaccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         imgprompt_16_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0081.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETID"+"'), id:'"+sPrefix+"TICKETID"+"'"+",IOType:'in'}"+","+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETRESPONSABLEID"+"'), id:'"+sPrefix+"TICKETRESPONSABLEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_14_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"TICKETID"+"'), id:'"+sPrefix+"TICKETID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_8_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadosatisfaccion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SATISFACCIONRESUELTOID"+"'), id:'"+sPrefix+"SATISFACCIONRESUELTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadosatisfaccion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SATISFACCIONTECNICOPROBLEMAID"+"'), id:'"+sPrefix+"SATISFACCIONTECNICOPROBLEMAID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_10_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadosatisfaccion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SATISFACCIONTECNICOCOMPETENTEID"+"'), id:'"+sPrefix+"SATISFACCIONTECNICOCOMPETENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_11_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadosatisfaccion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID"+"'), id:'"+sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_12_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadosatisfaccion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SATISFACCIONTIEMPOID"+"'), id:'"+sPrefix+"SATISFACCIONTIEMPOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         imgprompt_13_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"promptestadosatisfaccion.aspx"+"',["+"{Ctrl:gx.dom.el('"+sPrefix+"SATISFACCIONATENCIONID"+"'), id:'"+sPrefix+"SATISFACCIONATENCIONID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'"+sPrefix+"', false"+","+"false"+");");
         edtSatisfaccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Enabled), 5, 0), true);
         if ( ! (0==AV7SatisfaccionId) )
         {
            A7SatisfaccionId = AV7SatisfaccionId;
            AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_TicketResponsableId) )
         {
            edtTicketResponsableId_Enabled = 0;
            AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), true);
         }
         else
         {
            edtTicketResponsableId_Enabled = 1;
            AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SatisfaccionResueltoId) )
         {
            edtSatisfaccionResueltoId_Enabled = 0;
            AssignProp(sPrefix, false, edtSatisfaccionResueltoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoId_Enabled), 5, 0), true);
         }
         else
         {
            edtSatisfaccionResueltoId_Enabled = 1;
            AssignProp(sPrefix, false, edtSatisfaccionResueltoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_SatisfaccionTecnicoProblemaId) )
         {
            edtSatisfaccionTecnicoProblemaId_Enabled = 0;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaId_Enabled), 5, 0), true);
         }
         else
         {
            edtSatisfaccionTecnicoProblemaId_Enabled = 1;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_SatisfaccionTecnicoCompetenteId) )
         {
            edtSatisfaccionTecnicoCompetenteId_Enabled = 0;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteId_Enabled), 5, 0), true);
         }
         else
         {
            edtSatisfaccionTecnicoCompetenteId_Enabled = 1;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_SatisfaccionTecnicoProfesionalismoId) )
         {
            edtSatisfaccionTecnicoProfesionalismoId_Enabled = 0;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoId_Enabled), 5, 0), true);
         }
         else
         {
            edtSatisfaccionTecnicoProfesionalismoId_Enabled = 1;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV17Insert_SatisfaccionTiempoId) )
         {
            edtSatisfaccionTiempoId_Enabled = 0;
            AssignProp(sPrefix, false, edtSatisfaccionTiempoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoId_Enabled), 5, 0), true);
         }
         else
         {
            edtSatisfaccionTiempoId_Enabled = 1;
            AssignProp(sPrefix, false, edtSatisfaccionTiempoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_SatisfaccionAtencionId) )
         {
            edtSatisfaccionAtencionId_Enabled = 0;
            AssignProp(sPrefix, false, edtSatisfaccionAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionId_Enabled), 5, 0), true);
         }
         else
         {
            edtSatisfaccionAtencionId_Enabled = 1;
            AssignProp(sPrefix, false, edtSatisfaccionAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV38Insert_SatisfaccionCapacitacionId) )
         {
            A356SatisfaccionCapacitacionId = AV38Insert_SatisfaccionCapacitacionId;
            AssignAttri(sPrefix, false, "A356SatisfaccionCapacitacionId", StringUtil.LTrimStr( (decimal)(A356SatisfaccionCapacitacionId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV37Insert_SatisfaccionProgramadorId) )
         {
            A353SatisfaccionProgramadorId = AV37Insert_SatisfaccionProgramadorId;
            AssignAttri(sPrefix, false, "A353SatisfaccionProgramadorId", StringUtil.LTrimStr( (decimal)(A353SatisfaccionProgramadorId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV36Insert_SatisfaccionRendimientoId) )
         {
            A350SatisfaccionRendimientoId = AV36Insert_SatisfaccionRendimientoId;
            AssignAttri(sPrefix, false, "A350SatisfaccionRendimientoId", StringUtil.LTrimStr( (decimal)(A350SatisfaccionRendimientoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV35Insert_SatisfaccionCatalogaId) )
         {
            A347SatisfaccionCatalogaId = AV35Insert_SatisfaccionCatalogaId;
            AssignAttri(sPrefix, false, "A347SatisfaccionCatalogaId", StringUtil.LTrimStr( (decimal)(A347SatisfaccionCatalogaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV18Insert_SatisfaccionAtencionId) )
         {
            A13SatisfaccionAtencionId = AV18Insert_SatisfaccionAtencionId;
            AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV17Insert_SatisfaccionTiempoId) )
         {
            A12SatisfaccionTiempoId = AV17Insert_SatisfaccionTiempoId;
            AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV16Insert_SatisfaccionTecnicoProfesionalismoId) )
         {
            A11SatisfaccionTecnicoProfesionalismoId = AV16Insert_SatisfaccionTecnicoProfesionalismoId;
            AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV15Insert_SatisfaccionTecnicoCompetenteId) )
         {
            A10SatisfaccionTecnicoCompetenteId = AV15Insert_SatisfaccionTecnicoCompetenteId;
            AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_SatisfaccionTecnicoProblemaId) )
         {
            A9SatisfaccionTecnicoProblemaId = AV14Insert_SatisfaccionTecnicoProblemaId;
            AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_SatisfaccionResueltoId) )
         {
            A8SatisfaccionResueltoId = AV13Insert_SatisfaccionResueltoId;
            AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV32Insert_TicketResponsableId) )
         {
            A16TicketResponsableId = AV32Insert_TicketResponsableId;
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
         if ( IsIns( )  && (DateTime.MinValue==A32SatisfaccionFecha) && ( Gx_BScreen == 0 ) )
         {
            A32SatisfaccionFecha = DateTimeUtil.Today( context);
            AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
         }
         if ( IsIns( )  && (DateTime.MinValue==A144SatisfaccionHora) && ( Gx_BScreen == 0 ) )
         {
            A144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
            AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV40Pgmname = "Satisfaccion";
            AssignAttri(sPrefix, false, "AV40Pgmname", AV40Pgmname);
            /* Using cursor T000615 */
            pr_default.execute(13, new Object[] {A356SatisfaccionCapacitacionId});
            A357SatisfaccionCapacitacionNombre = T000615_A357SatisfaccionCapacitacionNombre[0];
            A358SatisfaccionCapacitacionCalificacion = T000615_A358SatisfaccionCapacitacionCalificacion[0];
            pr_default.close(13);
            /* Using cursor T000614 */
            pr_default.execute(12, new Object[] {A353SatisfaccionProgramadorId});
            A354SatisfaccionProgramadorNombre = T000614_A354SatisfaccionProgramadorNombre[0];
            A355SatisfaccionProgramadorCalificacion = T000614_A355SatisfaccionProgramadorCalificacion[0];
            pr_default.close(12);
            /* Using cursor T000613 */
            pr_default.execute(11, new Object[] {A350SatisfaccionRendimientoId});
            A351SatisfaccionRendimientoNombre = T000613_A351SatisfaccionRendimientoNombre[0];
            A352SatisfaccionRendimientoCalificacion = T000613_A352SatisfaccionRendimientoCalificacion[0];
            pr_default.close(11);
            /* Using cursor T000612 */
            pr_default.execute(10, new Object[] {A347SatisfaccionCatalogaId});
            A348SatisfaccionCatalogaNombre = T000612_A348SatisfaccionCatalogaNombre[0];
            A349SatisfaccionCatalogaCalificacion = T000612_A349SatisfaccionCatalogaCalificacion[0];
            pr_default.close(10);
            /* Using cursor T000611 */
            pr_default.execute(9, new Object[] {A13SatisfaccionAtencionId});
            A31SatisfaccionAtencionNombre = T000611_A31SatisfaccionAtencionNombre[0];
            AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
            A279SatisfaccionAtencionCalificacion = T000611_A279SatisfaccionAtencionCalificacion[0];
            pr_default.close(9);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Link", edtSatisfaccionAtencionNombre_Link, true);
            }
            /* Using cursor T000610 */
            pr_default.execute(8, new Object[] {A12SatisfaccionTiempoId});
            A38SatisfaccionTiempoNombre = T000610_A38SatisfaccionTiempoNombre[0];
            AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
            A284SatisfaccionTiempoCalificacion = T000610_A284SatisfaccionTiempoCalificacion[0];
            pr_default.close(8);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Link", edtSatisfaccionTiempoNombre_Link, true);
            }
            /* Using cursor T00069 */
            pr_default.execute(7, new Object[] {A11SatisfaccionTecnicoProfesionalismoId});
            A37SatisfaccionTecnicoProfesionalismoNombre = T00069_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
            A283SatisfaccionTecnicoProfesionalismoCalificacion = T00069_A283SatisfaccionTecnicoProfesionalismoCalificacion[0];
            pr_default.close(7);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Link", edtSatisfaccionTecnicoProfesionalismoNombre_Link, true);
            }
            /* Using cursor T00068 */
            pr_default.execute(6, new Object[] {A10SatisfaccionTecnicoCompetenteId});
            A35SatisfaccionTecnicoCompetenteNombre = T00068_A35SatisfaccionTecnicoCompetenteNombre[0];
            AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
            A281SatisfaccionTecnicoCompetenteCalificacion = T00068_A281SatisfaccionTecnicoCompetenteCalificacion[0];
            pr_default.close(6);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Link", edtSatisfaccionTecnicoCompetenteNombre_Link, true);
            }
            /* Using cursor T00067 */
            pr_default.execute(5, new Object[] {A9SatisfaccionTecnicoProblemaId});
            A36SatisfaccionTecnicoProblemaNombre = T00067_A36SatisfaccionTecnicoProblemaNombre[0];
            AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
            A282SatisfaccionTecnicoProblemaCalificacion = T00067_A282SatisfaccionTecnicoProblemaCalificacion[0];
            pr_default.close(5);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Link", edtSatisfaccionTecnicoProblemaNombre_Link, true);
            }
            /* Using cursor T00066 */
            pr_default.execute(4, new Object[] {A8SatisfaccionResueltoId});
            A33SatisfaccionResueltoNombre = T00066_A33SatisfaccionResueltoNombre[0];
            AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
            A280SatisfaccionResueltoCalificacion = T00066_A280SatisfaccionResueltoCalificacion[0];
            pr_default.close(4);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Link", edtSatisfaccionResueltoNombre_Link, true);
            }
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A14TicketId});
            A15UsuarioId = T00064_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
            pr_default.close(2);
            /* Using cursor T000617 */
            pr_default.execute(15, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T000617_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A90UsuarioFecha = T000617_A90UsuarioFecha[0];
            AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
            A94UsuarioRequerimiento = T000617_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            pr_default.close(15);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
            }
            /* Using cursor T00065 */
            pr_default.execute(3, new Object[] {A14TicketId, A16TicketResponsableId});
            A198TicketTecnicoResponsableId = T00065_A198TicketTecnicoResponsableId[0];
            AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
            pr_default.close(3);
            /* Using cursor T000616 */
            pr_default.execute(14, new Object[] {A198TicketTecnicoResponsableId});
            A199TicketTecnicoResponsableNombre = T000616_A199TicketTecnicoResponsableNombre[0];
            AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
            pr_default.close(14);
         }
      }

      protected void Load066( )
      {
         /* Using cursor T000618 */
         pr_default.execute(16, new Object[] {A7SatisfaccionId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound6 = 1;
            A32SatisfaccionFecha = T000618_A32SatisfaccionFecha[0];
            AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
            A144SatisfaccionHora = T000618_A144SatisfaccionHora[0];
            AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
            A199TicketTecnicoResponsableNombre = T000618_A199TicketTecnicoResponsableNombre[0];
            AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
            A93UsuarioNombre = T000618_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A90UsuarioFecha = T000618_A90UsuarioFecha[0];
            AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
            A94UsuarioRequerimiento = T000618_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            A33SatisfaccionResueltoNombre = T000618_A33SatisfaccionResueltoNombre[0];
            AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
            A280SatisfaccionResueltoCalificacion = T000618_A280SatisfaccionResueltoCalificacion[0];
            A36SatisfaccionTecnicoProblemaNombre = T000618_A36SatisfaccionTecnicoProblemaNombre[0];
            AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
            A282SatisfaccionTecnicoProblemaCalificacion = T000618_A282SatisfaccionTecnicoProblemaCalificacion[0];
            A35SatisfaccionTecnicoCompetenteNombre = T000618_A35SatisfaccionTecnicoCompetenteNombre[0];
            AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
            A281SatisfaccionTecnicoCompetenteCalificacion = T000618_A281SatisfaccionTecnicoCompetenteCalificacion[0];
            A37SatisfaccionTecnicoProfesionalismoNombre = T000618_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
            A283SatisfaccionTecnicoProfesionalismoCalificacion = T000618_A283SatisfaccionTecnicoProfesionalismoCalificacion[0];
            A38SatisfaccionTiempoNombre = T000618_A38SatisfaccionTiempoNombre[0];
            AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
            A284SatisfaccionTiempoCalificacion = T000618_A284SatisfaccionTiempoCalificacion[0];
            A31SatisfaccionAtencionNombre = T000618_A31SatisfaccionAtencionNombre[0];
            AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
            A279SatisfaccionAtencionCalificacion = T000618_A279SatisfaccionAtencionCalificacion[0];
            A34SatisfaccionSugerencia = T000618_A34SatisfaccionSugerencia[0];
            n34SatisfaccionSugerencia = T000618_n34SatisfaccionSugerencia[0];
            AssignAttri(sPrefix, false, "A34SatisfaccionSugerencia", A34SatisfaccionSugerencia);
            A348SatisfaccionCatalogaNombre = T000618_A348SatisfaccionCatalogaNombre[0];
            A349SatisfaccionCatalogaCalificacion = T000618_A349SatisfaccionCatalogaCalificacion[0];
            A351SatisfaccionRendimientoNombre = T000618_A351SatisfaccionRendimientoNombre[0];
            A352SatisfaccionRendimientoCalificacion = T000618_A352SatisfaccionRendimientoCalificacion[0];
            A354SatisfaccionProgramadorNombre = T000618_A354SatisfaccionProgramadorNombre[0];
            A355SatisfaccionProgramadorCalificacion = T000618_A355SatisfaccionProgramadorCalificacion[0];
            A357SatisfaccionCapacitacionNombre = T000618_A357SatisfaccionCapacitacionNombre[0];
            A358SatisfaccionCapacitacionCalificacion = T000618_A358SatisfaccionCapacitacionCalificacion[0];
            A359SatisfaccionMejoraSoftware = T000618_A359SatisfaccionMejoraSoftware[0];
            n359SatisfaccionMejoraSoftware = T000618_n359SatisfaccionMejoraSoftware[0];
            A14TicketId = T000618_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            A16TicketResponsableId = T000618_A16TicketResponsableId[0];
            AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
            A8SatisfaccionResueltoId = T000618_A8SatisfaccionResueltoId[0];
            AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
            A9SatisfaccionTecnicoProblemaId = T000618_A9SatisfaccionTecnicoProblemaId[0];
            AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
            A10SatisfaccionTecnicoCompetenteId = T000618_A10SatisfaccionTecnicoCompetenteId[0];
            AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
            A11SatisfaccionTecnicoProfesionalismoId = T000618_A11SatisfaccionTecnicoProfesionalismoId[0];
            AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
            A12SatisfaccionTiempoId = T000618_A12SatisfaccionTiempoId[0];
            AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
            A13SatisfaccionAtencionId = T000618_A13SatisfaccionAtencionId[0];
            AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
            A347SatisfaccionCatalogaId = T000618_A347SatisfaccionCatalogaId[0];
            A350SatisfaccionRendimientoId = T000618_A350SatisfaccionRendimientoId[0];
            A353SatisfaccionProgramadorId = T000618_A353SatisfaccionProgramadorId[0];
            A356SatisfaccionCapacitacionId = T000618_A356SatisfaccionCapacitacionId[0];
            A198TicketTecnicoResponsableId = T000618_A198TicketTecnicoResponsableId[0];
            AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
            A15UsuarioId = T000618_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
            ZM066( -47) ;
         }
         pr_default.close(16);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         AV40Pgmname = "Satisfaccion";
         AssignAttri(sPrefix, false, "AV40Pgmname", AV40Pgmname);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Link", edtSatisfaccionResueltoNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Link", edtSatisfaccionTecnicoProblemaNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Link", edtSatisfaccionTecnicoCompetenteNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Link", edtSatisfaccionTecnicoProfesionalismoNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Link", edtSatisfaccionTiempoNombre_Link, true);
         }
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(sMode6, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Link", edtSatisfaccionAtencionNombre_Link, true);
         }
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         AssignAttri(sPrefix, false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV40Pgmname = "Satisfaccion";
         AssignAttri(sPrefix, false, "AV40Pgmname", AV40Pgmname);
         if ( ! ( (DateTime.MinValue==A32SatisfaccionFecha) || ( DateTimeUtil.ResetTime ( A32SatisfaccionFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "SATISFACCIONFECHA");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionFecha_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A15UsuarioId = T00064_A15UsuarioId[0];
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
         pr_default.close(2);
         /* Using cursor T000617 */
         pr_default.execute(15, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000617_A93UsuarioNombre[0];
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A90UsuarioFecha = T000617_A90UsuarioFecha[0];
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         A94UsuarioRequerimiento = T000617_A94UsuarioRequerimiento[0];
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         pr_default.close(15);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
            AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         }
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "TICKETRESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A198TicketTecnicoResponsableId = T00065_A198TicketTecnicoResponsableId[0];
         AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
         pr_default.close(3);
         /* Using cursor T000616 */
         pr_default.execute(14, new Object[] {A198TicketTecnicoResponsableId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Ticket Tecnico Responsable'.", "ForeignKeyNotFound", 1, "TICKETTECNICORESPONSABLEID");
            AnyError = 1;
         }
         A199TicketTecnicoResponsableNombre = T000616_A199TicketTecnicoResponsableNombre[0];
         AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
         pr_default.close(14);
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A8SatisfaccionResueltoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Resuelto'.", "ForeignKeyNotFound", 1, "SATISFACCIONRESUELTOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionResueltoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A33SatisfaccionResueltoNombre = T00066_A33SatisfaccionResueltoNombre[0];
         AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
         A280SatisfaccionResueltoCalificacion = T00066_A280SatisfaccionResueltoCalificacion[0];
         pr_default.close(4);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Link", edtSatisfaccionResueltoNombre_Link, true);
         }
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A9SatisfaccionTecnicoProblemaId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Problema'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOPROBLEMAID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoProblemaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A36SatisfaccionTecnicoProblemaNombre = T00067_A36SatisfaccionTecnicoProblemaNombre[0];
         AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
         A282SatisfaccionTecnicoProblemaCalificacion = T00067_A282SatisfaccionTecnicoProblemaCalificacion[0];
         pr_default.close(5);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Link", edtSatisfaccionTecnicoProblemaNombre_Link, true);
         }
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A10SatisfaccionTecnicoCompetenteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Competente'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOCOMPETENTEID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoCompetenteId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A35SatisfaccionTecnicoCompetenteNombre = T00068_A35SatisfaccionTecnicoCompetenteNombre[0];
         AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
         A281SatisfaccionTecnicoCompetenteCalificacion = T00068_A281SatisfaccionTecnicoCompetenteCalificacion[0];
         pr_default.close(6);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Link", edtSatisfaccionTecnicoCompetenteNombre_Link, true);
         }
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A11SatisfaccionTecnicoProfesionalismoId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Profesionalismo'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOPROFESIONALISMOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoProfesionalismoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A37SatisfaccionTecnicoProfesionalismoNombre = T00069_A37SatisfaccionTecnicoProfesionalismoNombre[0];
         AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
         A283SatisfaccionTecnicoProfesionalismoCalificacion = T00069_A283SatisfaccionTecnicoProfesionalismoCalificacion[0];
         pr_default.close(7);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Link", edtSatisfaccionTecnicoProfesionalismoNombre_Link, true);
         }
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A12SatisfaccionTiempoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tiempo'.", "ForeignKeyNotFound", 1, "SATISFACCIONTIEMPOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTiempoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A38SatisfaccionTiempoNombre = T000610_A38SatisfaccionTiempoNombre[0];
         AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
         A284SatisfaccionTiempoCalificacion = T000610_A284SatisfaccionTiempoCalificacion[0];
         pr_default.close(8);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Link", edtSatisfaccionTiempoNombre_Link, true);
         }
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A13SatisfaccionAtencionId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Atencion'.", "ForeignKeyNotFound", 1, "SATISFACCIONATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionAtencionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A31SatisfaccionAtencionNombre = T000611_A31SatisfaccionAtencionNombre[0];
         AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
         A279SatisfaccionAtencionCalificacion = T000611_A279SatisfaccionAtencionCalificacion[0];
         pr_default.close(9);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Link", edtSatisfaccionAtencionNombre_Link, true);
         }
         /* Using cursor T000612 */
         pr_default.execute(10, new Object[] {A347SatisfaccionCatalogaId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Cataloga'.", "ForeignKeyNotFound", 1, "SATISFACCIONCATALOGAID");
            AnyError = 1;
         }
         A348SatisfaccionCatalogaNombre = T000612_A348SatisfaccionCatalogaNombre[0];
         A349SatisfaccionCatalogaCalificacion = T000612_A349SatisfaccionCatalogaCalificacion[0];
         pr_default.close(10);
         /* Using cursor T000613 */
         pr_default.execute(11, new Object[] {A350SatisfaccionRendimientoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Rendimiento'.", "ForeignKeyNotFound", 1, "SATISFACCIONRENDIMIENTOID");
            AnyError = 1;
         }
         A351SatisfaccionRendimientoNombre = T000613_A351SatisfaccionRendimientoNombre[0];
         A352SatisfaccionRendimientoCalificacion = T000613_A352SatisfaccionRendimientoCalificacion[0];
         pr_default.close(11);
         /* Using cursor T000614 */
         pr_default.execute(12, new Object[] {A353SatisfaccionProgramadorId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Programador'.", "ForeignKeyNotFound", 1, "SATISFACCIONPROGRAMADORID");
            AnyError = 1;
         }
         A354SatisfaccionProgramadorNombre = T000614_A354SatisfaccionProgramadorNombre[0];
         A355SatisfaccionProgramadorCalificacion = T000614_A355SatisfaccionProgramadorCalificacion[0];
         pr_default.close(12);
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A356SatisfaccionCapacitacionId});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Capacitacion'.", "ForeignKeyNotFound", 1, "SATISFACCIONCAPACITACIONID");
            AnyError = 1;
         }
         A357SatisfaccionCapacitacionNombre = T000615_A357SatisfaccionCapacitacionNombre[0];
         A358SatisfaccionCapacitacionCalificacion = T000615_A358SatisfaccionCapacitacionCalificacion[0];
         pr_default.close(13);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
         pr_default.close(15);
         pr_default.close(3);
         pr_default.close(14);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_48( long A14TicketId )
      {
         /* Using cursor T000619 */
         pr_default.execute(17, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A15UsuarioId = T000619_A15UsuarioId[0];
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_61( long A15UsuarioId )
      {
         /* Using cursor T000620 */
         pr_default.execute(18, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000620_A93UsuarioNombre[0];
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A90UsuarioFecha = T000620_A90UsuarioFecha[0];
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         A94UsuarioRequerimiento = T000620_A94UsuarioRequerimiento[0];
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A93UsuarioNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.Format(A90UsuarioFecha, "99/99/9999"))+"\""+","+"\""+GXUtil.EncodeJSConstant( A94UsuarioRequerimiento)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_49( long A14TicketId ,
                                long A16TicketResponsableId )
      {
         /* Using cursor T000621 */
         pr_default.execute(19, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "TICKETRESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A198TicketTecnicoResponsableId = T000621_A198TicketTecnicoResponsableId[0];
         AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_60( short A198TicketTecnicoResponsableId )
      {
         /* Using cursor T000622 */
         pr_default.execute(20, new Object[] {A198TicketTecnicoResponsableId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Ticket Tecnico Responsable'.", "ForeignKeyNotFound", 1, "TICKETTECNICORESPONSABLEID");
            AnyError = 1;
         }
         A199TicketTecnicoResponsableNombre = T000622_A199TicketTecnicoResponsableNombre[0];
         AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A199TicketTecnicoResponsableNombre)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_50( short A8SatisfaccionResueltoId )
      {
         /* Using cursor T000623 */
         pr_default.execute(21, new Object[] {A8SatisfaccionResueltoId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Resuelto'.", "ForeignKeyNotFound", 1, "SATISFACCIONRESUELTOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionResueltoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A33SatisfaccionResueltoNombre = T000623_A33SatisfaccionResueltoNombre[0];
         AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
         A280SatisfaccionResueltoCalificacion = T000623_A280SatisfaccionResueltoCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A33SatisfaccionResueltoNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A280SatisfaccionResueltoCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_51( short A9SatisfaccionTecnicoProblemaId )
      {
         /* Using cursor T000624 */
         pr_default.execute(22, new Object[] {A9SatisfaccionTecnicoProblemaId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Problema'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOPROBLEMAID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoProblemaId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A36SatisfaccionTecnicoProblemaNombre = T000624_A36SatisfaccionTecnicoProblemaNombre[0];
         AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
         A282SatisfaccionTecnicoProblemaCalificacion = T000624_A282SatisfaccionTecnicoProblemaCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A36SatisfaccionTecnicoProblemaNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A282SatisfaccionTecnicoProblemaCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_52( short A10SatisfaccionTecnicoCompetenteId )
      {
         /* Using cursor T000625 */
         pr_default.execute(23, new Object[] {A10SatisfaccionTecnicoCompetenteId});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Competente'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOCOMPETENTEID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoCompetenteId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A35SatisfaccionTecnicoCompetenteNombre = T000625_A35SatisfaccionTecnicoCompetenteNombre[0];
         AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
         A281SatisfaccionTecnicoCompetenteCalificacion = T000625_A281SatisfaccionTecnicoCompetenteCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A35SatisfaccionTecnicoCompetenteNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A281SatisfaccionTecnicoCompetenteCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_53( short A11SatisfaccionTecnicoProfesionalismoId )
      {
         /* Using cursor T000626 */
         pr_default.execute(24, new Object[] {A11SatisfaccionTecnicoProfesionalismoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Profesionalismo'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOPROFESIONALISMOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoProfesionalismoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A37SatisfaccionTecnicoProfesionalismoNombre = T000626_A37SatisfaccionTecnicoProfesionalismoNombre[0];
         AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
         A283SatisfaccionTecnicoProfesionalismoCalificacion = T000626_A283SatisfaccionTecnicoProfesionalismoCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A37SatisfaccionTecnicoProfesionalismoNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A283SatisfaccionTecnicoProfesionalismoCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_54( short A12SatisfaccionTiempoId )
      {
         /* Using cursor T000627 */
         pr_default.execute(25, new Object[] {A12SatisfaccionTiempoId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tiempo'.", "ForeignKeyNotFound", 1, "SATISFACCIONTIEMPOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTiempoId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A38SatisfaccionTiempoNombre = T000627_A38SatisfaccionTiempoNombre[0];
         AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
         A284SatisfaccionTiempoCalificacion = T000627_A284SatisfaccionTiempoCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A38SatisfaccionTiempoNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SatisfaccionTiempoCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void gxLoad_55( short A13SatisfaccionAtencionId )
      {
         /* Using cursor T000628 */
         pr_default.execute(26, new Object[] {A13SatisfaccionAtencionId});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Atencion'.", "ForeignKeyNotFound", 1, "SATISFACCIONATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionAtencionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         A31SatisfaccionAtencionNombre = T000628_A31SatisfaccionAtencionNombre[0];
         AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
         A279SatisfaccionAtencionCalificacion = T000628_A279SatisfaccionAtencionCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A31SatisfaccionAtencionNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A279SatisfaccionAtencionCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_56( short A347SatisfaccionCatalogaId )
      {
         /* Using cursor T000629 */
         pr_default.execute(27, new Object[] {A347SatisfaccionCatalogaId});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Cataloga'.", "ForeignKeyNotFound", 1, "SATISFACCIONCATALOGAID");
            AnyError = 1;
         }
         A348SatisfaccionCatalogaNombre = T000629_A348SatisfaccionCatalogaNombre[0];
         A349SatisfaccionCatalogaCalificacion = T000629_A349SatisfaccionCatalogaCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A348SatisfaccionCatalogaNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A349SatisfaccionCatalogaCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_57( short A350SatisfaccionRendimientoId )
      {
         /* Using cursor T000630 */
         pr_default.execute(28, new Object[] {A350SatisfaccionRendimientoId});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Rendimiento'.", "ForeignKeyNotFound", 1, "SATISFACCIONRENDIMIENTOID");
            AnyError = 1;
         }
         A351SatisfaccionRendimientoNombre = T000630_A351SatisfaccionRendimientoNombre[0];
         A352SatisfaccionRendimientoCalificacion = T000630_A352SatisfaccionRendimientoCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A351SatisfaccionRendimientoNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A352SatisfaccionRendimientoCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void gxLoad_58( short A353SatisfaccionProgramadorId )
      {
         /* Using cursor T000631 */
         pr_default.execute(29, new Object[] {A353SatisfaccionProgramadorId});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Programador'.", "ForeignKeyNotFound", 1, "SATISFACCIONPROGRAMADORID");
            AnyError = 1;
         }
         A354SatisfaccionProgramadorNombre = T000631_A354SatisfaccionProgramadorNombre[0];
         A355SatisfaccionProgramadorCalificacion = T000631_A355SatisfaccionProgramadorCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A354SatisfaccionProgramadorNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A355SatisfaccionProgramadorCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(29) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(29);
      }

      protected void gxLoad_59( short A356SatisfaccionCapacitacionId )
      {
         /* Using cursor T000632 */
         pr_default.execute(30, new Object[] {A356SatisfaccionCapacitacionId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Capacitacion'.", "ForeignKeyNotFound", 1, "SATISFACCIONCAPACITACIONID");
            AnyError = 1;
         }
         A357SatisfaccionCapacitacionNombre = T000632_A357SatisfaccionCapacitacionNombre[0];
         A358SatisfaccionCapacitacionCalificacion = T000632_A358SatisfaccionCapacitacionCalificacion[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A357SatisfaccionCapacitacionNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A358SatisfaccionCapacitacionCalificacion), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(30) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(30);
      }

      protected void GetKey066( )
      {
         /* Using cursor T000633 */
         pr_default.execute(31, new Object[] {A7SatisfaccionId});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(31);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A7SatisfaccionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 47) ;
            RcdFound6 = 1;
            A7SatisfaccionId = T00063_A7SatisfaccionId[0];
            AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
            A32SatisfaccionFecha = T00063_A32SatisfaccionFecha[0];
            AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
            A144SatisfaccionHora = T00063_A144SatisfaccionHora[0];
            AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
            A34SatisfaccionSugerencia = T00063_A34SatisfaccionSugerencia[0];
            n34SatisfaccionSugerencia = T00063_n34SatisfaccionSugerencia[0];
            AssignAttri(sPrefix, false, "A34SatisfaccionSugerencia", A34SatisfaccionSugerencia);
            A359SatisfaccionMejoraSoftware = T00063_A359SatisfaccionMejoraSoftware[0];
            n359SatisfaccionMejoraSoftware = T00063_n359SatisfaccionMejoraSoftware[0];
            A14TicketId = T00063_A14TicketId[0];
            AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
            A16TicketResponsableId = T00063_A16TicketResponsableId[0];
            AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
            A8SatisfaccionResueltoId = T00063_A8SatisfaccionResueltoId[0];
            AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
            A9SatisfaccionTecnicoProblemaId = T00063_A9SatisfaccionTecnicoProblemaId[0];
            AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
            A10SatisfaccionTecnicoCompetenteId = T00063_A10SatisfaccionTecnicoCompetenteId[0];
            AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
            A11SatisfaccionTecnicoProfesionalismoId = T00063_A11SatisfaccionTecnicoProfesionalismoId[0];
            AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
            A12SatisfaccionTiempoId = T00063_A12SatisfaccionTiempoId[0];
            AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
            A13SatisfaccionAtencionId = T00063_A13SatisfaccionAtencionId[0];
            AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
            A347SatisfaccionCatalogaId = T00063_A347SatisfaccionCatalogaId[0];
            A350SatisfaccionRendimientoId = T00063_A350SatisfaccionRendimientoId[0];
            A353SatisfaccionProgramadorId = T00063_A353SatisfaccionProgramadorId[0];
            A356SatisfaccionCapacitacionId = T00063_A356SatisfaccionCapacitacionId[0];
            Z7SatisfaccionId = A7SatisfaccionId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000634 */
         pr_default.execute(32, new Object[] {A7SatisfaccionId});
         if ( (pr_default.getStatus(32) != 101) )
         {
            while ( (pr_default.getStatus(32) != 101) && ( ( T000634_A7SatisfaccionId[0] < A7SatisfaccionId ) ) )
            {
               pr_default.readNext(32);
            }
            if ( (pr_default.getStatus(32) != 101) && ( ( T000634_A7SatisfaccionId[0] > A7SatisfaccionId ) ) )
            {
               A7SatisfaccionId = T000634_A7SatisfaccionId[0];
               AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(32);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000635 */
         pr_default.execute(33, new Object[] {A7SatisfaccionId});
         if ( (pr_default.getStatus(33) != 101) )
         {
            while ( (pr_default.getStatus(33) != 101) && ( ( T000635_A7SatisfaccionId[0] > A7SatisfaccionId ) ) )
            {
               pr_default.readNext(33);
            }
            if ( (pr_default.getStatus(33) != 101) && ( ( T000635_A7SatisfaccionId[0] < A7SatisfaccionId ) ) )
            {
               A7SatisfaccionId = T000635_A7SatisfaccionId[0];
               AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(33);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSatisfaccionFecha_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A7SatisfaccionId != Z7SatisfaccionId )
               {
                  A7SatisfaccionId = Z7SatisfaccionId;
                  AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SATISFACCIONID");
                  AnyError = 1;
                  GX_FocusControl = edtSatisfaccionId_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSatisfaccionFecha_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtSatisfaccionFecha_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A7SatisfaccionId != Z7SatisfaccionId )
               {
                  /* Insert record */
                  GX_FocusControl = edtSatisfaccionFecha_Internalname;
                  AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SATISFACCIONID");
                     AnyError = 1;
                     GX_FocusControl = edtSatisfaccionId_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtSatisfaccionFecha_Internalname;
                     AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
         if ( A7SatisfaccionId != Z7SatisfaccionId )
         {
            A7SatisfaccionId = Z7SatisfaccionId;
            AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SATISFACCIONID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionId_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSatisfaccionFecha_Internalname;
            AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A7SatisfaccionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Satisfaccion"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z32SatisfaccionFecha ) != DateTimeUtil.ResetTime ( T00062_A32SatisfaccionFecha[0] ) ) || ( Z144SatisfaccionHora != T00062_A144SatisfaccionHora[0] ) || ( StringUtil.StrCmp(Z34SatisfaccionSugerencia, T00062_A34SatisfaccionSugerencia[0]) != 0 ) || ( StringUtil.StrCmp(Z359SatisfaccionMejoraSoftware, T00062_A359SatisfaccionMejoraSoftware[0]) != 0 ) || ( Z14TicketId != T00062_A14TicketId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z16TicketResponsableId != T00062_A16TicketResponsableId[0] ) || ( Z8SatisfaccionResueltoId != T00062_A8SatisfaccionResueltoId[0] ) || ( Z9SatisfaccionTecnicoProblemaId != T00062_A9SatisfaccionTecnicoProblemaId[0] ) || ( Z10SatisfaccionTecnicoCompetenteId != T00062_A10SatisfaccionTecnicoCompetenteId[0] ) || ( Z11SatisfaccionTecnicoProfesionalismoId != T00062_A11SatisfaccionTecnicoProfesionalismoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z12SatisfaccionTiempoId != T00062_A12SatisfaccionTiempoId[0] ) || ( Z13SatisfaccionAtencionId != T00062_A13SatisfaccionAtencionId[0] ) || ( Z347SatisfaccionCatalogaId != T00062_A347SatisfaccionCatalogaId[0] ) || ( Z350SatisfaccionRendimientoId != T00062_A350SatisfaccionRendimientoId[0] ) || ( Z353SatisfaccionProgramadorId != T00062_A353SatisfaccionProgramadorId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z356SatisfaccionCapacitacionId != T00062_A356SatisfaccionCapacitacionId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z32SatisfaccionFecha ) != DateTimeUtil.ResetTime ( T00062_A32SatisfaccionFecha[0] ) )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionFecha");
                  GXUtil.WriteLogRaw("Old: ",Z32SatisfaccionFecha);
                  GXUtil.WriteLogRaw("Current: ",T00062_A32SatisfaccionFecha[0]);
               }
               if ( Z144SatisfaccionHora != T00062_A144SatisfaccionHora[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionHora");
                  GXUtil.WriteLogRaw("Old: ",Z144SatisfaccionHora);
                  GXUtil.WriteLogRaw("Current: ",T00062_A144SatisfaccionHora[0]);
               }
               if ( StringUtil.StrCmp(Z34SatisfaccionSugerencia, T00062_A34SatisfaccionSugerencia[0]) != 0 )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionSugerencia");
                  GXUtil.WriteLogRaw("Old: ",Z34SatisfaccionSugerencia);
                  GXUtil.WriteLogRaw("Current: ",T00062_A34SatisfaccionSugerencia[0]);
               }
               if ( StringUtil.StrCmp(Z359SatisfaccionMejoraSoftware, T00062_A359SatisfaccionMejoraSoftware[0]) != 0 )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionMejoraSoftware");
                  GXUtil.WriteLogRaw("Old: ",Z359SatisfaccionMejoraSoftware);
                  GXUtil.WriteLogRaw("Current: ",T00062_A359SatisfaccionMejoraSoftware[0]);
               }
               if ( Z14TicketId != T00062_A14TicketId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"TicketId");
                  GXUtil.WriteLogRaw("Old: ",Z14TicketId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A14TicketId[0]);
               }
               if ( Z16TicketResponsableId != T00062_A16TicketResponsableId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"TicketResponsableId");
                  GXUtil.WriteLogRaw("Old: ",Z16TicketResponsableId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A16TicketResponsableId[0]);
               }
               if ( Z8SatisfaccionResueltoId != T00062_A8SatisfaccionResueltoId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionResueltoId");
                  GXUtil.WriteLogRaw("Old: ",Z8SatisfaccionResueltoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A8SatisfaccionResueltoId[0]);
               }
               if ( Z9SatisfaccionTecnicoProblemaId != T00062_A9SatisfaccionTecnicoProblemaId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionTecnicoProblemaId");
                  GXUtil.WriteLogRaw("Old: ",Z9SatisfaccionTecnicoProblemaId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A9SatisfaccionTecnicoProblemaId[0]);
               }
               if ( Z10SatisfaccionTecnicoCompetenteId != T00062_A10SatisfaccionTecnicoCompetenteId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionTecnicoCompetenteId");
                  GXUtil.WriteLogRaw("Old: ",Z10SatisfaccionTecnicoCompetenteId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A10SatisfaccionTecnicoCompetenteId[0]);
               }
               if ( Z11SatisfaccionTecnicoProfesionalismoId != T00062_A11SatisfaccionTecnicoProfesionalismoId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionTecnicoProfesionalismoId");
                  GXUtil.WriteLogRaw("Old: ",Z11SatisfaccionTecnicoProfesionalismoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A11SatisfaccionTecnicoProfesionalismoId[0]);
               }
               if ( Z12SatisfaccionTiempoId != T00062_A12SatisfaccionTiempoId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionTiempoId");
                  GXUtil.WriteLogRaw("Old: ",Z12SatisfaccionTiempoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A12SatisfaccionTiempoId[0]);
               }
               if ( Z13SatisfaccionAtencionId != T00062_A13SatisfaccionAtencionId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionAtencionId");
                  GXUtil.WriteLogRaw("Old: ",Z13SatisfaccionAtencionId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A13SatisfaccionAtencionId[0]);
               }
               if ( Z347SatisfaccionCatalogaId != T00062_A347SatisfaccionCatalogaId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionCatalogaId");
                  GXUtil.WriteLogRaw("Old: ",Z347SatisfaccionCatalogaId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A347SatisfaccionCatalogaId[0]);
               }
               if ( Z350SatisfaccionRendimientoId != T00062_A350SatisfaccionRendimientoId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionRendimientoId");
                  GXUtil.WriteLogRaw("Old: ",Z350SatisfaccionRendimientoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A350SatisfaccionRendimientoId[0]);
               }
               if ( Z353SatisfaccionProgramadorId != T00062_A353SatisfaccionProgramadorId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionProgramadorId");
                  GXUtil.WriteLogRaw("Old: ",Z353SatisfaccionProgramadorId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A353SatisfaccionProgramadorId[0]);
               }
               if ( Z356SatisfaccionCapacitacionId != T00062_A356SatisfaccionCapacitacionId[0] )
               {
                  GXUtil.WriteLog("satisfaccion:[seudo value changed for attri]"+"SatisfaccionCapacitacionId");
                  GXUtil.WriteLogRaw("Old: ",Z356SatisfaccionCapacitacionId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A356SatisfaccionCapacitacionId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Satisfaccion"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         if ( ! IsAuthorized("satisfaccion_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000636 */
                     pr_default.execute(34, new Object[] {A7SatisfaccionId, A32SatisfaccionFecha, A144SatisfaccionHora, n34SatisfaccionSugerencia, A34SatisfaccionSugerencia, n359SatisfaccionMejoraSoftware, A359SatisfaccionMejoraSoftware, A14TicketId, A16TicketResponsableId, A8SatisfaccionResueltoId, A9SatisfaccionTecnicoProblemaId, A10SatisfaccionTecnicoCompetenteId, A11SatisfaccionTecnicoProfesionalismoId, A12SatisfaccionTiempoId, A13SatisfaccionAtencionId, A347SatisfaccionCatalogaId, A350SatisfaccionRendimientoId, A353SatisfaccionProgramadorId, A356SatisfaccionCapacitacionId});
                     pr_default.close(34);
                     dsDefault.SmartCacheProvider.SetUpdated("Satisfaccion");
                     if ( (pr_default.getStatus(34) == 1) )
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
                           ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         if ( ! IsAuthorized("satisfaccion_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000637 */
                     pr_default.execute(35, new Object[] {A32SatisfaccionFecha, A144SatisfaccionHora, n34SatisfaccionSugerencia, A34SatisfaccionSugerencia, n359SatisfaccionMejoraSoftware, A359SatisfaccionMejoraSoftware, A14TicketId, A16TicketResponsableId, A8SatisfaccionResueltoId, A9SatisfaccionTecnicoProblemaId, A10SatisfaccionTecnicoCompetenteId, A11SatisfaccionTecnicoProfesionalismoId, A12SatisfaccionTiempoId, A13SatisfaccionAtencionId, A347SatisfaccionCatalogaId, A350SatisfaccionRendimientoId, A353SatisfaccionProgramadorId, A356SatisfaccionCapacitacionId, A7SatisfaccionId});
                     pr_default.close(35);
                     dsDefault.SmartCacheProvider.SetUpdated("Satisfaccion");
                     if ( (pr_default.getStatus(35) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Satisfaccion"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("satisfaccion_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000638 */
                  pr_default.execute(36, new Object[] {A7SatisfaccionId});
                  pr_default.close(36);
                  dsDefault.SmartCacheProvider.SetUpdated("Satisfaccion");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri(sPrefix, false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV40Pgmname = "Satisfaccion";
            AssignAttri(sPrefix, false, "AV40Pgmname", AV40Pgmname);
            /* Using cursor T000639 */
            pr_default.execute(37, new Object[] {A14TicketId});
            A15UsuarioId = T000639_A15UsuarioId[0];
            AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
            pr_default.close(37);
            /* Using cursor T000640 */
            pr_default.execute(38, new Object[] {A15UsuarioId});
            A93UsuarioNombre = T000640_A93UsuarioNombre[0];
            AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
            A90UsuarioFecha = T000640_A90UsuarioFecha[0];
            AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
            A94UsuarioRequerimiento = T000640_A94UsuarioRequerimiento[0];
            AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
            pr_default.close(38);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
               AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
            }
            /* Using cursor T000641 */
            pr_default.execute(39, new Object[] {A14TicketId, A16TicketResponsableId});
            A198TicketTecnicoResponsableId = T000641_A198TicketTecnicoResponsableId[0];
            AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
            pr_default.close(39);
            /* Using cursor T000642 */
            pr_default.execute(40, new Object[] {A198TicketTecnicoResponsableId});
            A199TicketTecnicoResponsableNombre = T000642_A199TicketTecnicoResponsableNombre[0];
            AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
            pr_default.close(40);
            /* Using cursor T000643 */
            pr_default.execute(41, new Object[] {A8SatisfaccionResueltoId});
            A33SatisfaccionResueltoNombre = T000643_A33SatisfaccionResueltoNombre[0];
            AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
            A280SatisfaccionResueltoCalificacion = T000643_A280SatisfaccionResueltoCalificacion[0];
            pr_default.close(41);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Link", edtSatisfaccionResueltoNombre_Link, true);
            }
            /* Using cursor T000644 */
            pr_default.execute(42, new Object[] {A9SatisfaccionTecnicoProblemaId});
            A36SatisfaccionTecnicoProblemaNombre = T000644_A36SatisfaccionTecnicoProblemaNombre[0];
            AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
            A282SatisfaccionTecnicoProblemaCalificacion = T000644_A282SatisfaccionTecnicoProblemaCalificacion[0];
            pr_default.close(42);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Link", edtSatisfaccionTecnicoProblemaNombre_Link, true);
            }
            /* Using cursor T000645 */
            pr_default.execute(43, new Object[] {A10SatisfaccionTecnicoCompetenteId});
            A35SatisfaccionTecnicoCompetenteNombre = T000645_A35SatisfaccionTecnicoCompetenteNombre[0];
            AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
            A281SatisfaccionTecnicoCompetenteCalificacion = T000645_A281SatisfaccionTecnicoCompetenteCalificacion[0];
            pr_default.close(43);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Link", edtSatisfaccionTecnicoCompetenteNombre_Link, true);
            }
            /* Using cursor T000646 */
            pr_default.execute(44, new Object[] {A11SatisfaccionTecnicoProfesionalismoId});
            A37SatisfaccionTecnicoProfesionalismoNombre = T000646_A37SatisfaccionTecnicoProfesionalismoNombre[0];
            AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
            A283SatisfaccionTecnicoProfesionalismoCalificacion = T000646_A283SatisfaccionTecnicoProfesionalismoCalificacion[0];
            pr_default.close(44);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Link", edtSatisfaccionTecnicoProfesionalismoNombre_Link, true);
            }
            /* Using cursor T000647 */
            pr_default.execute(45, new Object[] {A12SatisfaccionTiempoId});
            A38SatisfaccionTiempoNombre = T000647_A38SatisfaccionTiempoNombre[0];
            AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
            A284SatisfaccionTiempoCalificacion = T000647_A284SatisfaccionTiempoCalificacion[0];
            pr_default.close(45);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Link", edtSatisfaccionTiempoNombre_Link, true);
            }
            /* Using cursor T000648 */
            pr_default.execute(46, new Object[] {A13SatisfaccionAtencionId});
            A31SatisfaccionAtencionNombre = T000648_A31SatisfaccionAtencionNombre[0];
            AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
            A279SatisfaccionAtencionCalificacion = T000648_A279SatisfaccionAtencionCalificacion[0];
            pr_default.close(46);
            GXt_boolean2 = false;
            new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
            if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
            {
               edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
               AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Link", edtSatisfaccionAtencionNombre_Link, true);
            }
            /* Using cursor T000649 */
            pr_default.execute(47, new Object[] {A347SatisfaccionCatalogaId});
            A348SatisfaccionCatalogaNombre = T000649_A348SatisfaccionCatalogaNombre[0];
            A349SatisfaccionCatalogaCalificacion = T000649_A349SatisfaccionCatalogaCalificacion[0];
            pr_default.close(47);
            /* Using cursor T000650 */
            pr_default.execute(48, new Object[] {A350SatisfaccionRendimientoId});
            A351SatisfaccionRendimientoNombre = T000650_A351SatisfaccionRendimientoNombre[0];
            A352SatisfaccionRendimientoCalificacion = T000650_A352SatisfaccionRendimientoCalificacion[0];
            pr_default.close(48);
            /* Using cursor T000651 */
            pr_default.execute(49, new Object[] {A353SatisfaccionProgramadorId});
            A354SatisfaccionProgramadorNombre = T000651_A354SatisfaccionProgramadorNombre[0];
            A355SatisfaccionProgramadorCalificacion = T000651_A355SatisfaccionProgramadorCalificacion[0];
            pr_default.close(49);
            /* Using cursor T000652 */
            pr_default.execute(50, new Object[] {A356SatisfaccionCapacitacionId});
            A357SatisfaccionCapacitacionNombre = T000652_A357SatisfaccionCapacitacionNombre[0];
            A358SatisfaccionCapacitacionCalificacion = T000652_A358SatisfaccionCapacitacionCalificacion[0];
            pr_default.close(50);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(37);
            pr_default.close(39);
            pr_default.close(41);
            pr_default.close(42);
            pr_default.close(43);
            pr_default.close(44);
            pr_default.close(45);
            pr_default.close(46);
            pr_default.close(47);
            pr_default.close(48);
            pr_default.close(49);
            pr_default.close(50);
            pr_default.close(40);
            pr_default.close(38);
            context.CommitDataStores("satisfaccion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(37);
            pr_default.close(39);
            pr_default.close(41);
            pr_default.close(42);
            pr_default.close(43);
            pr_default.close(44);
            pr_default.close(45);
            pr_default.close(46);
            pr_default.close(47);
            pr_default.close(48);
            pr_default.close(49);
            pr_default.close(50);
            pr_default.close(40);
            pr_default.close(38);
            context.RollbackDataStores("satisfaccion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Scan By routine */
         /* Using cursor T000653 */
         pr_default.execute(51);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(51) != 101) )
         {
            RcdFound6 = 1;
            A7SatisfaccionId = T000653_A7SatisfaccionId[0];
            AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(51);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(51) != 101) )
         {
            RcdFound6 = 1;
            A7SatisfaccionId = T000653_A7SatisfaccionId[0];
            AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(51);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtSatisfaccionId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionId_Enabled), 5, 0), true);
         edtSatisfaccionFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionFecha_Enabled), 5, 0), true);
         edtSatisfaccionHora_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionHora_Enabled), 5, 0), true);
         edtTicketResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketResponsableId_Enabled), 5, 0), true);
         edtUsuarioFecha_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioFecha_Enabled), 5, 0), true);
         edtTicketId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketId_Enabled), 5, 0), true);
         edtTicketTecnicoResponsableId_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoResponsableId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableId_Enabled), 5, 0), true);
         edtTicketTecnicoResponsableNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtTicketTecnicoResponsableNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTicketTecnicoResponsableNombre_Enabled), 5, 0), true);
         edtUsuarioId_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioId_Enabled), 5, 0), true);
         edtUsuarioNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioNombre_Enabled), 5, 0), true);
         edtUsuarioRequerimiento_Enabled = 0;
         AssignProp(sPrefix, false, edtUsuarioRequerimiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuarioRequerimiento_Enabled), 5, 0), true);
         edtSatisfaccionResueltoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoNombre_Enabled), 5, 0), true);
         edtSatisfaccionResueltoId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionResueltoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionResueltoId_Enabled), 5, 0), true);
         edtSatisfaccionTecnicoProblemaNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaNombre_Enabled), 5, 0), true);
         edtSatisfaccionTecnicoProblemaId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProblemaId_Enabled), 5, 0), true);
         edtSatisfaccionTecnicoCompetenteNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteNombre_Enabled), 5, 0), true);
         edtSatisfaccionTecnicoCompetenteId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoCompetenteId_Enabled), 5, 0), true);
         edtSatisfaccionTecnicoProfesionalismoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoNombre_Enabled), 5, 0), true);
         edtSatisfaccionTecnicoProfesionalismoId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTecnicoProfesionalismoId_Enabled), 5, 0), true);
         edtSatisfaccionTiempoNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoNombre_Enabled), 5, 0), true);
         edtSatisfaccionTiempoId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionTiempoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionTiempoId_Enabled), 5, 0), true);
         edtSatisfaccionAtencionId_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionAtencionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionId_Enabled), 5, 0), true);
         edtSatisfaccionAtencionNombre_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionAtencionNombre_Enabled), 5, 0), true);
         edtSatisfaccionSugerencia_Enabled = 0;
         AssignProp(sPrefix, false, edtSatisfaccionSugerencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSatisfaccionSugerencia_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.AddJavascriptSource("gxcfg.js", "?2024188344518", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 184460), false, true);
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("satisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7SatisfaccionId,10,0))}, new string[] {"Gx_mode","SatisfaccionId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", sPrefix+"hsh"+"Satisfaccion");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("SatisfaccionMejoraSoftware", StringUtil.RTrim( context.localUtil.Format( A359SatisfaccionMejoraSoftware, "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("satisfaccion:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"Z7SatisfaccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z7SatisfaccionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z32SatisfaccionFecha", context.localUtil.DToC( Z32SatisfaccionFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z144SatisfaccionHora", context.localUtil.TToC( Z144SatisfaccionHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z34SatisfaccionSugerencia", Z34SatisfaccionSugerencia);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z359SatisfaccionMejoraSoftware", Z359SatisfaccionMejoraSoftware);
         GxWebStd.gx_hidden_field( context, sPrefix+"Z14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z14TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z16TicketResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z8SatisfaccionResueltoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z8SatisfaccionResueltoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z9SatisfaccionTecnicoProblemaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z10SatisfaccionTecnicoCompetenteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z12SatisfaccionTiempoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z12SatisfaccionTiempoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z13SatisfaccionAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z13SatisfaccionAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z347SatisfaccionCatalogaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z347SatisfaccionCatalogaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z350SatisfaccionRendimientoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350SatisfaccionRendimientoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z353SatisfaccionProgramadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z353SatisfaccionProgramadorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Z356SatisfaccionCapacitacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z356SatisfaccionCapacitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOGx_mode", StringUtil.RTrim( wcpOGx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7SatisfaccionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7SatisfaccionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, sPrefix+"N14TicketId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A14TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N16TicketResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N8SatisfaccionResueltoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A8SatisfaccionResueltoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N9SatisfaccionTecnicoProblemaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N10SatisfaccionTecnicoCompetenteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N12SatisfaccionTiempoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A12SatisfaccionTiempoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N13SatisfaccionAtencionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A13SatisfaccionAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N347SatisfaccionCatalogaId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A347SatisfaccionCatalogaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N350SatisfaccionRendimientoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A350SatisfaccionRendimientoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N353SatisfaccionProgramadorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A353SatisfaccionProgramadorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"N356SatisfaccionCapacitacionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A356SatisfaccionCapacitacionId), 4, 0, ".", "")));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vATTRIBUTEVALUE", AV27AttributeValue);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vATTRIBUTEVALUE", AV27AttributeValue);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vATTRIBUTEVALUE", GetSecureSignedToken( sPrefix, AV27AttributeValue, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNAVIGATION", AV10Navigation);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNAVIGATION", AV10Navigation);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAVIGATION", GetSecureSignedToken( sPrefix, AV10Navigation, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSATISFACCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SatisfaccionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_TICKETID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_TicketId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_TICKETRESPONSABLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32Insert_TicketResponsableId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONRESUELTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_SatisfaccionResueltoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONTECNICOPROBLEMAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_SatisfaccionTecnicoProblemaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONTECNICOCOMPETENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15Insert_SatisfaccionTecnicoCompetenteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONTECNICOPROFESIONALISMOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16Insert_SatisfaccionTecnicoProfesionalismoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONTIEMPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17Insert_SatisfaccionTiempoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONATENCIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV18Insert_SatisfaccionAtencionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONCATALOGAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35Insert_SatisfaccionCatalogaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONCATALOGAID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A347SatisfaccionCatalogaId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONRENDIMIENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV36Insert_SatisfaccionRendimientoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONRENDIMIENTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A350SatisfaccionRendimientoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONPROGRAMADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37Insert_SatisfaccionProgramadorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONPROGRAMADORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A353SatisfaccionProgramadorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vINSERT_SATISFACCIONCAPACITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38Insert_SatisfaccionCapacitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONCAPACITACIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A356SatisfaccionCapacitacionId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONMEJORASOFTWARE", A359SatisfaccionMejoraSoftware);
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONRESUELTOCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A280SatisfaccionResueltoCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONTECNICOPROBLEMACALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A282SatisfaccionTecnicoProblemaCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONTECNICOCOMPETENTECALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A281SatisfaccionTecnicoCompetenteCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A283SatisfaccionTecnicoProfesionalismoCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONTIEMPOCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SatisfaccionTiempoCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONATENCIONCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A279SatisfaccionAtencionCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONCATALOGANOMBRE", A348SatisfaccionCatalogaNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONCATALOGACALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A349SatisfaccionCatalogaCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONRENDIMIENTONOMBRE", A351SatisfaccionRendimientoNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONRENDIMIENTOCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A352SatisfaccionRendimientoCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONPROGRAMADORNOMBRE", A354SatisfaccionProgramadorNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONPROGRAMADORCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A355SatisfaccionProgramadorCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONCAPACITACIONNOMBRE", A357SatisfaccionCapacitacionNombre);
         GxWebStd.gx_hidden_field( context, sPrefix+"SATISFACCIONCAPACITACIONCALIFICACION", StringUtil.LTrim( StringUtil.NToC( (decimal)(A358SatisfaccionCapacitacionCalificacion), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV40Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Objectcall", StringUtil.RTrim( K2bcontrolbeautify1_Objectcall));
         GxWebStd.gx_hidden_field( context, sPrefix+"K2BCONTROLBEAUTIFY1_Enabled", StringUtil.BoolToStr( K2bcontrolbeautify1_Enabled));
      }

      protected void RenderHtmlCloseForm066( )
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
         return "Satisfaccion" ;
      }

      public override string GetPgmdesc( )
      {
         return "Satisfaccion" ;
      }

      protected void InitializeNonKey066( )
      {
         A14TicketId = 0;
         AssignAttri(sPrefix, false, "A14TicketId", StringUtil.LTrimStr( (decimal)(A14TicketId), 10, 0));
         A16TicketResponsableId = 0;
         AssignAttri(sPrefix, false, "A16TicketResponsableId", StringUtil.LTrimStr( (decimal)(A16TicketResponsableId), 10, 0));
         A8SatisfaccionResueltoId = 0;
         AssignAttri(sPrefix, false, "A8SatisfaccionResueltoId", StringUtil.LTrimStr( (decimal)(A8SatisfaccionResueltoId), 4, 0));
         A9SatisfaccionTecnicoProblemaId = 0;
         AssignAttri(sPrefix, false, "A9SatisfaccionTecnicoProblemaId", StringUtil.LTrimStr( (decimal)(A9SatisfaccionTecnicoProblemaId), 4, 0));
         A10SatisfaccionTecnicoCompetenteId = 0;
         AssignAttri(sPrefix, false, "A10SatisfaccionTecnicoCompetenteId", StringUtil.LTrimStr( (decimal)(A10SatisfaccionTecnicoCompetenteId), 4, 0));
         A11SatisfaccionTecnicoProfesionalismoId = 0;
         AssignAttri(sPrefix, false, "A11SatisfaccionTecnicoProfesionalismoId", StringUtil.LTrimStr( (decimal)(A11SatisfaccionTecnicoProfesionalismoId), 4, 0));
         A12SatisfaccionTiempoId = 0;
         AssignAttri(sPrefix, false, "A12SatisfaccionTiempoId", StringUtil.LTrimStr( (decimal)(A12SatisfaccionTiempoId), 4, 0));
         A13SatisfaccionAtencionId = 0;
         AssignAttri(sPrefix, false, "A13SatisfaccionAtencionId", StringUtil.LTrimStr( (decimal)(A13SatisfaccionAtencionId), 4, 0));
         A347SatisfaccionCatalogaId = 0;
         AssignAttri(sPrefix, false, "A347SatisfaccionCatalogaId", StringUtil.LTrimStr( (decimal)(A347SatisfaccionCatalogaId), 4, 0));
         A350SatisfaccionRendimientoId = 0;
         AssignAttri(sPrefix, false, "A350SatisfaccionRendimientoId", StringUtil.LTrimStr( (decimal)(A350SatisfaccionRendimientoId), 4, 0));
         A353SatisfaccionProgramadorId = 0;
         AssignAttri(sPrefix, false, "A353SatisfaccionProgramadorId", StringUtil.LTrimStr( (decimal)(A353SatisfaccionProgramadorId), 4, 0));
         A356SatisfaccionCapacitacionId = 0;
         AssignAttri(sPrefix, false, "A356SatisfaccionCapacitacionId", StringUtil.LTrimStr( (decimal)(A356SatisfaccionCapacitacionId), 4, 0));
         A198TicketTecnicoResponsableId = 0;
         AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrimStr( (decimal)(A198TicketTecnicoResponsableId), 4, 0));
         A199TicketTecnicoResponsableNombre = "";
         AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
         A15UsuarioId = 0;
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrimStr( (decimal)(A15UsuarioId), 10, 0));
         A93UsuarioNombre = "";
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         A90UsuarioFecha = DateTime.MinValue;
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         A94UsuarioRequerimiento = "";
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         A33SatisfaccionResueltoNombre = "";
         AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
         A280SatisfaccionResueltoCalificacion = 0;
         AssignAttri(sPrefix, false, "A280SatisfaccionResueltoCalificacion", StringUtil.LTrimStr( (decimal)(A280SatisfaccionResueltoCalificacion), 4, 0));
         A36SatisfaccionTecnicoProblemaNombre = "";
         AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
         A282SatisfaccionTecnicoProblemaCalificacion = 0;
         AssignAttri(sPrefix, false, "A282SatisfaccionTecnicoProblemaCalificacion", StringUtil.LTrimStr( (decimal)(A282SatisfaccionTecnicoProblemaCalificacion), 4, 0));
         A35SatisfaccionTecnicoCompetenteNombre = "";
         AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
         A281SatisfaccionTecnicoCompetenteCalificacion = 0;
         AssignAttri(sPrefix, false, "A281SatisfaccionTecnicoCompetenteCalificacion", StringUtil.LTrimStr( (decimal)(A281SatisfaccionTecnicoCompetenteCalificacion), 4, 0));
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
         A283SatisfaccionTecnicoProfesionalismoCalificacion = 0;
         AssignAttri(sPrefix, false, "A283SatisfaccionTecnicoProfesionalismoCalificacion", StringUtil.LTrimStr( (decimal)(A283SatisfaccionTecnicoProfesionalismoCalificacion), 4, 0));
         A38SatisfaccionTiempoNombre = "";
         AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
         A284SatisfaccionTiempoCalificacion = 0;
         AssignAttri(sPrefix, false, "A284SatisfaccionTiempoCalificacion", StringUtil.LTrimStr( (decimal)(A284SatisfaccionTiempoCalificacion), 4, 0));
         A31SatisfaccionAtencionNombre = "";
         AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
         A279SatisfaccionAtencionCalificacion = 0;
         AssignAttri(sPrefix, false, "A279SatisfaccionAtencionCalificacion", StringUtil.LTrimStr( (decimal)(A279SatisfaccionAtencionCalificacion), 4, 0));
         A34SatisfaccionSugerencia = "";
         n34SatisfaccionSugerencia = false;
         AssignAttri(sPrefix, false, "A34SatisfaccionSugerencia", A34SatisfaccionSugerencia);
         n34SatisfaccionSugerencia = (String.IsNullOrEmpty(StringUtil.RTrim( A34SatisfaccionSugerencia)) ? true : false);
         A348SatisfaccionCatalogaNombre = "";
         AssignAttri(sPrefix, false, "A348SatisfaccionCatalogaNombre", A348SatisfaccionCatalogaNombre);
         A349SatisfaccionCatalogaCalificacion = 0;
         AssignAttri(sPrefix, false, "A349SatisfaccionCatalogaCalificacion", StringUtil.LTrimStr( (decimal)(A349SatisfaccionCatalogaCalificacion), 4, 0));
         A351SatisfaccionRendimientoNombre = "";
         AssignAttri(sPrefix, false, "A351SatisfaccionRendimientoNombre", A351SatisfaccionRendimientoNombre);
         A352SatisfaccionRendimientoCalificacion = 0;
         AssignAttri(sPrefix, false, "A352SatisfaccionRendimientoCalificacion", StringUtil.LTrimStr( (decimal)(A352SatisfaccionRendimientoCalificacion), 4, 0));
         A354SatisfaccionProgramadorNombre = "";
         AssignAttri(sPrefix, false, "A354SatisfaccionProgramadorNombre", A354SatisfaccionProgramadorNombre);
         A355SatisfaccionProgramadorCalificacion = 0;
         AssignAttri(sPrefix, false, "A355SatisfaccionProgramadorCalificacion", StringUtil.LTrimStr( (decimal)(A355SatisfaccionProgramadorCalificacion), 4, 0));
         A357SatisfaccionCapacitacionNombre = "";
         AssignAttri(sPrefix, false, "A357SatisfaccionCapacitacionNombre", A357SatisfaccionCapacitacionNombre);
         A358SatisfaccionCapacitacionCalificacion = 0;
         AssignAttri(sPrefix, false, "A358SatisfaccionCapacitacionCalificacion", StringUtil.LTrimStr( (decimal)(A358SatisfaccionCapacitacionCalificacion), 4, 0));
         A359SatisfaccionMejoraSoftware = "";
         n359SatisfaccionMejoraSoftware = false;
         AssignAttri(sPrefix, false, "A359SatisfaccionMejoraSoftware", A359SatisfaccionMejoraSoftware);
         A32SatisfaccionFecha = DateTimeUtil.Today( context);
         AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
         A144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
         Z32SatisfaccionFecha = DateTime.MinValue;
         Z144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         Z34SatisfaccionSugerencia = "";
         Z359SatisfaccionMejoraSoftware = "";
         Z14TicketId = 0;
         Z16TicketResponsableId = 0;
         Z8SatisfaccionResueltoId = 0;
         Z9SatisfaccionTecnicoProblemaId = 0;
         Z10SatisfaccionTecnicoCompetenteId = 0;
         Z11SatisfaccionTecnicoProfesionalismoId = 0;
         Z12SatisfaccionTiempoId = 0;
         Z13SatisfaccionAtencionId = 0;
         Z347SatisfaccionCatalogaId = 0;
         Z350SatisfaccionRendimientoId = 0;
         Z353SatisfaccionProgramadorId = 0;
         Z356SatisfaccionCapacitacionId = 0;
      }

      protected void InitAll066( )
      {
         A7SatisfaccionId = 0;
         AssignAttri(sPrefix, false, "A7SatisfaccionId", StringUtil.LTrimStr( (decimal)(A7SatisfaccionId), 10, 0));
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A32SatisfaccionFecha = i32SatisfaccionFecha;
         AssignAttri(sPrefix, false, "A32SatisfaccionFecha", context.localUtil.Format(A32SatisfaccionFecha, "99/99/9999"));
         A144SatisfaccionHora = i144SatisfaccionHora;
         AssignAttri(sPrefix, false, "A144SatisfaccionHora", context.localUtil.TToC( A144SatisfaccionHora, 0, 5, 0, 3, "/", ":", " "));
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlGx_mode = (string)((string)getParm(obj,0));
         sCtrlAV7SatisfaccionId = (string)((string)getParm(obj,1));
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
         AddComponentObject(sPrefix, "satisfaccion", GetJustCreated( ));
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
            AV7SatisfaccionId = Convert.ToInt64(getParm(obj,3));
            AssignAttri(sPrefix, false, "AV7SatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7SatisfaccionId), 10, 0));
         }
         wcpOGx_mode = cgiGet( sPrefix+"wcpOGx_mode");
         wcpOAV7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7SatisfaccionId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(Gx_mode, wcpOGx_mode) != 0 ) || ( AV7SatisfaccionId != wcpOAV7SatisfaccionId ) ) )
         {
            setjustcreated();
         }
         wcpOGx_mode = Gx_mode;
         wcpOAV7SatisfaccionId = AV7SatisfaccionId;
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
         sCtrlAV7SatisfaccionId = cgiGet( sPrefix+"AV7SatisfaccionId_CTRL");
         if ( StringUtil.Len( sCtrlAV7SatisfaccionId) > 0 )
         {
            AV7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV7SatisfaccionId), ".", ","));
            AssignAttri(sPrefix, false, "AV7SatisfaccionId", StringUtil.LTrimStr( (decimal)(AV7SatisfaccionId), 10, 0));
         }
         else
         {
            AV7SatisfaccionId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV7SatisfaccionId_PARM"), ".", ","));
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
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7SatisfaccionId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7SatisfaccionId), 10, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7SatisfaccionId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7SatisfaccionId_CTRL", StringUtil.RTrim( sCtrlAV7SatisfaccionId));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188344581", true, true);
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
         context.AddJavascriptSource("satisfaccion.js", "?2024188344583", false, true);
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         divK2beserrviewercell_Internalname = sPrefix+"K2BESERRVIEWERCELL";
         edtSatisfaccionId_Internalname = sPrefix+"SATISFACCIONID";
         divK2btoolstable_attributecontainersatisfaccionid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONID";
         edtSatisfaccionFecha_Internalname = sPrefix+"SATISFACCIONFECHA";
         divK2btoolstable_attributecontainersatisfaccionfecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONFECHA";
         edtSatisfaccionHora_Internalname = sPrefix+"SATISFACCIONHORA";
         divK2btoolstable_attributecontainersatisfaccionhora_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONHORA";
         divTableclmid0_Internalname = sPrefix+"TABLECLMID0";
         edtTicketResponsableId_Internalname = sPrefix+"TICKETRESPONSABLEID";
         divK2btoolstable_attributecontainerticketresponsableid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETRESPONSABLEID";
         divTableclmid1_Internalname = sPrefix+"TABLECLMID1";
         divClmid_Internalname = sPrefix+"CLMID";
         edtUsuarioFecha_Internalname = sPrefix+"USUARIOFECHA";
         divK2btoolstable_attributecontainerusuariofecha_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOFECHA";
         divTableclmfecha0_Internalname = sPrefix+"TABLECLMFECHA0";
         divClmfecha_Internalname = sPrefix+"CLMFECHA";
         edtTicketId_Internalname = sPrefix+"TICKETID";
         divK2btoolstable_attributecontainerticketid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETID";
         edtTicketTecnicoResponsableId_Internalname = sPrefix+"TICKETTECNICORESPONSABLEID";
         divK2btoolstable_attributecontainertickettecnicoresponsableid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICORESPONSABLEID";
         edtTicketTecnicoResponsableNombre_Internalname = sPrefix+"TICKETTECNICORESPONSABLENOMBRE";
         divK2btoolstable_attributecontainertickettecnicoresponsablenombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERTICKETTECNICORESPONSABLENOMBRE";
         edtUsuarioId_Internalname = sPrefix+"USUARIOID";
         divK2btoolstable_attributecontainerusuarioid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOID";
         edtUsuarioNombre_Internalname = sPrefix+"USUARIONOMBRE";
         divK2btoolstable_attributecontainerusuarionombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIONOMBRE";
         divTableclmusuario0_Internalname = sPrefix+"TABLECLMUSUARIO0";
         edtUsuarioRequerimiento_Internalname = sPrefix+"USUARIOREQUERIMIENTO";
         divK2btoolstable_attributecontainerusuariorequerimiento_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERUSUARIOREQUERIMIENTO";
         divTableclmusuario1_Internalname = sPrefix+"TABLECLMUSUARIO1";
         divClmusuario_Internalname = sPrefix+"CLMUSUARIO";
         lblLineseparatortitle_lnresuelto_Internalname = sPrefix+"LINESEPARATORTITLE_LNRESUELTO";
         divLineseparatorheader_lnresuelto_Internalname = sPrefix+"LINESEPARATORHEADER_LNRESUELTO";
         edtSatisfaccionResueltoNombre_Internalname = sPrefix+"SATISFACCIONRESUELTONOMBRE";
         divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONRESUELTONOMBRE";
         edtSatisfaccionResueltoId_Internalname = sPrefix+"SATISFACCIONRESUELTOID";
         divK2btoolstable_attributecontainersatisfaccionresueltoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONRESUELTOID";
         divLineseparatorcontent_lnresuelto_Internalname = sPrefix+"LINESEPARATORCONTENT_LNRESUELTO";
         divLineseparator_lnresuelto_Internalname = sPrefix+"LINESEPARATOR_LNRESUELTO";
         lblLineseparatortitle_lnproblema_Internalname = sPrefix+"LINESEPARATORTITLE_LNPROBLEMA";
         divLineseparatorheader_lnproblema_Internalname = sPrefix+"LINESEPARATORHEADER_LNPROBLEMA";
         edtSatisfaccionTecnicoProblemaNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMANOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROBLEMANOMBRE";
         edtSatisfaccionTecnicoProblemaId_Internalname = sPrefix+"SATISFACCIONTECNICOPROBLEMAID";
         divK2btoolstable_attributecontainersatisfacciontecnicoproblemaid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROBLEMAID";
         divLineseparatorcontent_lnproblema_Internalname = sPrefix+"LINESEPARATORCONTENT_LNPROBLEMA";
         divLineseparator_lnproblema_Internalname = sPrefix+"LINESEPARATOR_LNPROBLEMA";
         lblLineseparatortitle_lncapacidad_Internalname = sPrefix+"LINESEPARATORTITLE_LNCAPACIDAD";
         divLineseparatorheader_lncapacidad_Internalname = sPrefix+"LINESEPARATORHEADER_LNCAPACIDAD";
         edtSatisfaccionTecnicoCompetenteNombre_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTENOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOCOMPETENTENOMBRE";
         edtSatisfaccionTecnicoCompetenteId_Internalname = sPrefix+"SATISFACCIONTECNICOCOMPETENTEID";
         divK2btoolstable_attributecontainersatisfacciontecnicocompetenteid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOCOMPETENTEID";
         divLineseparatorcontent_lncapacidad_Internalname = sPrefix+"LINESEPARATORCONTENT_LNCAPACIDAD";
         divLineseparator_lncapacidad_Internalname = sPrefix+"LINESEPARATOR_LNCAPACIDAD";
         lblLineseparatortitle_lncortesia_Internalname = sPrefix+"LINESEPARATORTITLE_LNCORTESIA";
         divLineseparatorheader_lncortesia_Internalname = sPrefix+"LINESEPARATORHEADER_LNCORTESIA";
         edtSatisfaccionTecnicoProfesionalismoNombre_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROFESIONALISMONOMBRE";
         edtSatisfaccionTecnicoProfesionalismoId_Internalname = sPrefix+"SATISFACCIONTECNICOPROFESIONALISMOID";
         divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTECNICOPROFESIONALISMOID";
         divLineseparatorcontent_lncortesia_Internalname = sPrefix+"LINESEPARATORCONTENT_LNCORTESIA";
         divLineseparator_lncortesia_Internalname = sPrefix+"LINESEPARATOR_LNCORTESIA";
         lblLineseparatortitle_lntiempo_Internalname = sPrefix+"LINESEPARATORTITLE_LNTIEMPO";
         divLineseparatorheader_lntiempo_Internalname = sPrefix+"LINESEPARATORHEADER_LNTIEMPO";
         edtSatisfaccionTiempoNombre_Internalname = sPrefix+"SATISFACCIONTIEMPONOMBRE";
         divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTIEMPONOMBRE";
         edtSatisfaccionTiempoId_Internalname = sPrefix+"SATISFACCIONTIEMPOID";
         divK2btoolstable_attributecontainersatisfacciontiempoid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONTIEMPOID";
         divLineseparatorcontent_lntiempo_Internalname = sPrefix+"LINESEPARATORCONTENT_LNTIEMPO";
         divLineseparator_lntiempo_Internalname = sPrefix+"LINESEPARATOR_LNTIEMPO";
         lblLineseparatortitle_clatencion_Internalname = sPrefix+"LINESEPARATORTITLE_CLATENCION";
         divLineseparatorheader_clatencion_Internalname = sPrefix+"LINESEPARATORHEADER_CLATENCION";
         edtSatisfaccionAtencionId_Internalname = sPrefix+"SATISFACCIONATENCIONID";
         divK2btoolstable_attributecontainersatisfaccionatencionid_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONATENCIONID";
         edtSatisfaccionAtencionNombre_Internalname = sPrefix+"SATISFACCIONATENCIONNOMBRE";
         divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONATENCIONNOMBRE";
         divLineseparatorcontent_clatencion_Internalname = sPrefix+"LINESEPARATORCONTENT_CLATENCION";
         divLineseparator_clatencion_Internalname = sPrefix+"LINESEPARATOR_CLATENCION";
         lblLineseparatortitle_lnsugerencia_Internalname = sPrefix+"LINESEPARATORTITLE_LNSUGERENCIA";
         divLineseparatorheader_lnsugerencia_Internalname = sPrefix+"LINESEPARATORHEADER_LNSUGERENCIA";
         edtSatisfaccionSugerencia_Internalname = sPrefix+"SATISFACCIONSUGERENCIA";
         divK2btoolstable_attributecontainersatisfaccionsugerencia_Internalname = sPrefix+"K2BTOOLSTABLE_ATTRIBUTECONTAINERSATISFACCIONSUGERENCIA";
         divLineseparatorcontent_lnsugerencia_Internalname = sPrefix+"LINESEPARATORCONTENT_LNSUGERENCIA";
         divLineseparator_lnsugerencia_Internalname = sPrefix+"LINESEPARATOR_LNSUGERENCIA";
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
         imgprompt_8_Internalname = sPrefix+"PROMPT_8";
         imgprompt_9_Internalname = sPrefix+"PROMPT_9";
         imgprompt_10_Internalname = sPrefix+"PROMPT_10";
         imgprompt_11_Internalname = sPrefix+"PROMPT_11";
         imgprompt_12_Internalname = sPrefix+"PROMPT_12";
         imgprompt_13_Internalname = sPrefix+"PROMPT_13";
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
         Form.Caption = "Satisfaccion";
         bttCancel_Visible = 1;
         bttEnter_Tooltiptext = "Confirmar";
         bttEnter_Caption = "Confirmar";
         bttEnter_Enabled = 1;
         bttEnter_Visible = 1;
         edtSatisfaccionSugerencia_Enabled = 1;
         divLineseparatorcontent_lnsugerencia_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lnsugerencia_Visible = 1;
         divLineseparatorheader_lnsugerencia_Class = "Section_LineSeparatorOpen";
         edtSatisfaccionAtencionNombre_Jsonclick = "";
         edtSatisfaccionAtencionNombre_Link = "";
         edtSatisfaccionAtencionNombre_Enabled = 0;
         imgprompt_13_Visible = 1;
         imgprompt_13_Link = "";
         edtSatisfaccionAtencionId_Jsonclick = "";
         edtSatisfaccionAtencionId_Enabled = 1;
         divLineseparatorcontent_clatencion_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_clatencion_Visible = 1;
         divLineseparatorheader_clatencion_Class = "Section_LineSeparatorOpen";
         imgprompt_12_Visible = 1;
         imgprompt_12_Link = "";
         edtSatisfaccionTiempoId_Jsonclick = "";
         edtSatisfaccionTiempoId_Enabled = 1;
         edtSatisfaccionTiempoNombre_Jsonclick = "";
         edtSatisfaccionTiempoNombre_Link = "";
         edtSatisfaccionTiempoNombre_Enabled = 0;
         divLineseparatorcontent_lntiempo_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lntiempo_Visible = 1;
         divLineseparatorheader_lntiempo_Class = "Section_LineSeparatorOpen";
         imgprompt_11_Visible = 1;
         imgprompt_11_Link = "";
         edtSatisfaccionTecnicoProfesionalismoId_Jsonclick = "";
         edtSatisfaccionTecnicoProfesionalismoId_Enabled = 1;
         edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick = "";
         edtSatisfaccionTecnicoProfesionalismoNombre_Link = "";
         edtSatisfaccionTecnicoProfesionalismoNombre_Enabled = 0;
         divLineseparatorcontent_lncortesia_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lncortesia_Visible = 1;
         divLineseparatorheader_lncortesia_Class = "Section_LineSeparatorOpen";
         imgprompt_10_Visible = 1;
         imgprompt_10_Link = "";
         edtSatisfaccionTecnicoCompetenteId_Jsonclick = "";
         edtSatisfaccionTecnicoCompetenteId_Enabled = 1;
         edtSatisfaccionTecnicoCompetenteNombre_Jsonclick = "";
         edtSatisfaccionTecnicoCompetenteNombre_Link = "";
         edtSatisfaccionTecnicoCompetenteNombre_Enabled = 0;
         divLineseparatorcontent_lncapacidad_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lncapacidad_Visible = 1;
         divLineseparatorheader_lncapacidad_Class = "Section_LineSeparatorOpen";
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtSatisfaccionTecnicoProblemaId_Jsonclick = "";
         edtSatisfaccionTecnicoProblemaId_Enabled = 1;
         edtSatisfaccionTecnicoProblemaNombre_Jsonclick = "";
         edtSatisfaccionTecnicoProblemaNombre_Link = "";
         edtSatisfaccionTecnicoProblemaNombre_Enabled = 0;
         divLineseparatorcontent_lnproblema_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lnproblema_Visible = 1;
         divLineseparatorheader_lnproblema_Class = "Section_LineSeparatorOpen";
         imgprompt_8_Visible = 1;
         imgprompt_8_Link = "";
         edtSatisfaccionResueltoId_Jsonclick = "";
         edtSatisfaccionResueltoId_Enabled = 1;
         edtSatisfaccionResueltoNombre_Jsonclick = "";
         edtSatisfaccionResueltoNombre_Link = "";
         edtSatisfaccionResueltoNombre_Enabled = 0;
         divLineseparatorcontent_lnresuelto_Class = "K2BT_NGA Section_LineSeparatorContentOpen";
         divLineseparatorcontent_lnresuelto_Visible = 1;
         divLineseparatorheader_lnresuelto_Class = "Section_LineSeparatorOpen";
         edtUsuarioRequerimiento_Enabled = 0;
         edtUsuarioNombre_Jsonclick = "";
         edtUsuarioNombre_Link = "";
         edtUsuarioNombre_Enabled = 0;
         edtUsuarioId_Jsonclick = "";
         edtUsuarioId_Enabled = 0;
         divK2btoolstable_attributecontainerusuarioid_Visible = 1;
         edtTicketTecnicoResponsableNombre_Jsonclick = "";
         edtTicketTecnicoResponsableNombre_Enabled = 0;
         edtTicketTecnicoResponsableId_Jsonclick = "";
         edtTicketTecnicoResponsableId_Enabled = 0;
         divK2btoolstable_attributecontainertickettecnicoresponsableid_Visible = 1;
         imgprompt_14_Visible = 1;
         imgprompt_14_Link = "";
         edtTicketId_Jsonclick = "";
         edtTicketId_Enabled = 1;
         edtUsuarioFecha_Jsonclick = "";
         edtUsuarioFecha_Enabled = 0;
         imgprompt_16_Visible = 1;
         imgprompt_16_Link = "";
         edtTicketResponsableId_Jsonclick = "";
         edtTicketResponsableId_Enabled = 1;
         edtSatisfaccionHora_Jsonclick = "";
         edtSatisfaccionHora_Enabled = 1;
         divK2btoolstable_attributecontainersatisfaccionhora_Visible = 1;
         edtSatisfaccionFecha_Jsonclick = "";
         edtSatisfaccionFecha_Enabled = 1;
         divK2btoolstable_attributecontainersatisfaccionfecha_Visible = 1;
         edtSatisfaccionId_Jsonclick = "";
         edtSatisfaccionId_Enabled = 0;
         divK2btoolstable_attributecontainersatisfaccionid_Visible = 1;
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

      protected void GXASA93066( long A15UsuarioId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
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

      protected void GXASA33066( short A8SatisfaccionResueltoId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Link", edtSatisfaccionResueltoNombre_Link, true);
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

      protected void GXASA36066( short A9SatisfaccionTecnicoProblemaId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Link", edtSatisfaccionTecnicoProblemaNombre_Link, true);
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

      protected void GXASA35066( short A10SatisfaccionTecnicoCompetenteId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Link", edtSatisfaccionTecnicoCompetenteNombre_Link, true);
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

      protected void GXASA37066( short A11SatisfaccionTecnicoProfesionalismoId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Link", edtSatisfaccionTecnicoProfesionalismoNombre_Link, true);
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

      protected void GXASA38066( short A12SatisfaccionTiempoId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Link", edtSatisfaccionTiempoNombre_Link, true);
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

      protected void GXASA31066( short A13SatisfaccionAtencionId )
      {
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
            AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Link", edtSatisfaccionAtencionNombre_Link, true);
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

      public void Valid_Ticketid( )
      {
         /* Using cursor T000639 */
         pr_default.execute(37, new Object[] {A14TicketId});
         if ( (pr_default.getStatus(37) == 101) )
         {
            GX_msglist.addItem("No existe 'Ticket'.", "ForeignKeyNotFound", 1, "TICKETID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
         }
         A15UsuarioId = T000639_A15UsuarioId[0];
         pr_default.close(37);
         /* Using cursor T000640 */
         pr_default.execute(38, new Object[] {A15UsuarioId});
         if ( (pr_default.getStatus(38) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "USUARIOID");
            AnyError = 1;
         }
         A93UsuarioNombre = T000640_A93UsuarioNombre[0];
         A90UsuarioFecha = T000640_A90UsuarioFecha[0];
         A94UsuarioRequerimiento = T000640_A94UsuarioRequerimiento[0];
         pr_default.close(38);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "Usuario",  "Usuario",  "Display",  "",  "EntityManagerUsuario", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtUsuarioNombre_Link = formatLink("entitymanagerusuario.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A15UsuarioId,10,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","UsuarioId","TabCode"}) ;
         }
         /* Using cursor T000641 */
         pr_default.execute(39, new Object[] {A14TicketId, A16TicketResponsableId});
         if ( (pr_default.getStatus(39) == 101) )
         {
            GX_msglist.addItem("No existe 'Responsable'.", "ForeignKeyNotFound", 1, "TICKETRESPONSABLEID");
            AnyError = 1;
            GX_FocusControl = edtTicketId_Internalname;
         }
         A198TicketTecnicoResponsableId = T000641_A198TicketTecnicoResponsableId[0];
         pr_default.close(39);
         /* Using cursor T000642 */
         pr_default.execute(40, new Object[] {A198TicketTecnicoResponsableId});
         if ( (pr_default.getStatus(40) == 101) )
         {
            GX_msglist.addItem("No existe 'Sg Ticket Tecnico Responsable'.", "ForeignKeyNotFound", 1, "TICKETTECNICORESPONSABLEID");
            AnyError = 1;
         }
         A199TicketTecnicoResponsableNombre = T000642_A199TicketTecnicoResponsableNombre[0];
         pr_default.close(40);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A15UsuarioId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15UsuarioId), 10, 0, ".", "")));
         AssignAttri(sPrefix, false, "A93UsuarioNombre", A93UsuarioNombre);
         AssignAttri(sPrefix, false, "A90UsuarioFecha", context.localUtil.Format(A90UsuarioFecha, "99/99/9999"));
         AssignAttri(sPrefix, false, "A94UsuarioRequerimiento", A94UsuarioRequerimiento);
         AssignProp(sPrefix, false, edtUsuarioNombre_Internalname, "Link", edtUsuarioNombre_Link, true);
         AssignAttri(sPrefix, false, "A198TicketTecnicoResponsableId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A198TicketTecnicoResponsableId), 4, 0, ".", "")));
         AssignAttri(sPrefix, false, "A199TicketTecnicoResponsableNombre", A199TicketTecnicoResponsableNombre);
      }

      public void Valid_Satisfaccionresueltoid( )
      {
         /* Using cursor T000643 */
         pr_default.execute(41, new Object[] {A8SatisfaccionResueltoId});
         if ( (pr_default.getStatus(41) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Resuelto'.", "ForeignKeyNotFound", 1, "SATISFACCIONRESUELTOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionResueltoId_Internalname;
         }
         A33SatisfaccionResueltoNombre = T000643_A33SatisfaccionResueltoNombre[0];
         A280SatisfaccionResueltoCalificacion = T000643_A280SatisfaccionResueltoCalificacion[0];
         pr_default.close(41);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionResueltoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A8SatisfaccionResueltoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A33SatisfaccionResueltoNombre", A33SatisfaccionResueltoNombre);
         AssignAttri(sPrefix, false, "A280SatisfaccionResueltoCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A280SatisfaccionResueltoCalificacion), 4, 0, ".", "")));
         AssignProp(sPrefix, false, edtSatisfaccionResueltoNombre_Internalname, "Link", edtSatisfaccionResueltoNombre_Link, true);
      }

      public void Valid_Satisfacciontecnicoproblemaid( )
      {
         /* Using cursor T000644 */
         pr_default.execute(42, new Object[] {A9SatisfaccionTecnicoProblemaId});
         if ( (pr_default.getStatus(42) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Problema'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOPROBLEMAID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoProblemaId_Internalname;
         }
         A36SatisfaccionTecnicoProblemaNombre = T000644_A36SatisfaccionTecnicoProblemaNombre[0];
         A282SatisfaccionTecnicoProblemaCalificacion = T000644_A282SatisfaccionTecnicoProblemaCalificacion[0];
         pr_default.close(42);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProblemaNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A9SatisfaccionTecnicoProblemaId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A36SatisfaccionTecnicoProblemaNombre", A36SatisfaccionTecnicoProblemaNombre);
         AssignAttri(sPrefix, false, "A282SatisfaccionTecnicoProblemaCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A282SatisfaccionTecnicoProblemaCalificacion), 4, 0, ".", "")));
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProblemaNombre_Internalname, "Link", edtSatisfaccionTecnicoProblemaNombre_Link, true);
      }

      public void Valid_Satisfacciontecnicocompetenteid( )
      {
         /* Using cursor T000645 */
         pr_default.execute(43, new Object[] {A10SatisfaccionTecnicoCompetenteId});
         if ( (pr_default.getStatus(43) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Competente'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOCOMPETENTEID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoCompetenteId_Internalname;
         }
         A35SatisfaccionTecnicoCompetenteNombre = T000645_A35SatisfaccionTecnicoCompetenteNombre[0];
         A281SatisfaccionTecnicoCompetenteCalificacion = T000645_A281SatisfaccionTecnicoCompetenteCalificacion[0];
         pr_default.close(43);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoCompetenteNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A10SatisfaccionTecnicoCompetenteId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A35SatisfaccionTecnicoCompetenteNombre", A35SatisfaccionTecnicoCompetenteNombre);
         AssignAttri(sPrefix, false, "A281SatisfaccionTecnicoCompetenteCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A281SatisfaccionTecnicoCompetenteCalificacion), 4, 0, ".", "")));
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoCompetenteNombre_Internalname, "Link", edtSatisfaccionTecnicoCompetenteNombre_Link, true);
      }

      public void Valid_Satisfacciontecnicoprofesionalismoid( )
      {
         /* Using cursor T000646 */
         pr_default.execute(44, new Object[] {A11SatisfaccionTecnicoProfesionalismoId});
         if ( (pr_default.getStatus(44) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tecnico Profesionalismo'.", "ForeignKeyNotFound", 1, "SATISFACCIONTECNICOPROFESIONALISMOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTecnicoProfesionalismoId_Internalname;
         }
         A37SatisfaccionTecnicoProfesionalismoNombre = T000646_A37SatisfaccionTecnicoProfesionalismoNombre[0];
         A283SatisfaccionTecnicoProfesionalismoCalificacion = T000646_A283SatisfaccionTecnicoProfesionalismoCalificacion[0];
         pr_default.close(44);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTecnicoProfesionalismoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A11SatisfaccionTecnicoProfesionalismoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A37SatisfaccionTecnicoProfesionalismoNombre", A37SatisfaccionTecnicoProfesionalismoNombre);
         AssignAttri(sPrefix, false, "A283SatisfaccionTecnicoProfesionalismoCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A283SatisfaccionTecnicoProfesionalismoCalificacion), 4, 0, ".", "")));
         AssignProp(sPrefix, false, edtSatisfaccionTecnicoProfesionalismoNombre_Internalname, "Link", edtSatisfaccionTecnicoProfesionalismoNombre_Link, true);
      }

      public void Valid_Satisfacciontiempoid( )
      {
         /* Using cursor T000647 */
         pr_default.execute(45, new Object[] {A12SatisfaccionTiempoId});
         if ( (pr_default.getStatus(45) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Tiempo'.", "ForeignKeyNotFound", 1, "SATISFACCIONTIEMPOID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionTiempoId_Internalname;
         }
         A38SatisfaccionTiempoNombre = T000647_A38SatisfaccionTiempoNombre[0];
         A284SatisfaccionTiempoCalificacion = T000647_A284SatisfaccionTiempoCalificacion[0];
         pr_default.close(45);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionTiempoNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A12SatisfaccionTiempoId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A38SatisfaccionTiempoNombre", A38SatisfaccionTiempoNombre);
         AssignAttri(sPrefix, false, "A284SatisfaccionTiempoCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A284SatisfaccionTiempoCalificacion), 4, 0, ".", "")));
         AssignProp(sPrefix, false, edtSatisfaccionTiempoNombre_Internalname, "Link", edtSatisfaccionTiempoNombre_Link, true);
      }

      public void Valid_Satisfaccionatencionid( )
      {
         /* Using cursor T000648 */
         pr_default.execute(46, new Object[] {A13SatisfaccionAtencionId});
         if ( (pr_default.getStatus(46) == 101) )
         {
            GX_msglist.addItem("No existe 'Satisfaccion Atencion'.", "ForeignKeyNotFound", 1, "SATISFACCIONATENCIONID");
            AnyError = 1;
            GX_FocusControl = edtSatisfaccionAtencionId_Internalname;
         }
         A31SatisfaccionAtencionNombre = T000648_A31SatisfaccionAtencionNombre[0];
         A279SatisfaccionAtencionCalificacion = T000648_A279SatisfaccionAtencionCalificacion[0];
         pr_default.close(46);
         GXt_boolean2 = false;
         new k2bisauthorizedactivityname(context ).execute(  "EstadoSatisfaccion",  "EstadoSatisfaccion",  "Display",  "",  "EntityManagerEstadoSatisfaccion", out  GXt_boolean2) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) && GXt_boolean2 )
         {
            edtSatisfaccionAtencionNombre_Link = formatLink("entitymanagerestadosatisfaccion.aspx", new object[] {UrlEncode(StringUtil.RTrim("DSP")),UrlEncode(StringUtil.LTrimStr(A13SatisfaccionAtencionId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"Mode","EstadoSatisfaccionId","TabCode"}) ;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri(sPrefix, false, "A31SatisfaccionAtencionNombre", A31SatisfaccionAtencionNombre);
         AssignAttri(sPrefix, false, "A279SatisfaccionAtencionCalificacion", StringUtil.LTrim( StringUtil.NToC( (decimal)(A279SatisfaccionAtencionCalificacion), 4, 0, ".", "")));
         AssignProp(sPrefix, false, edtSatisfaccionAtencionNombre_Internalname, "Link", edtSatisfaccionAtencionNombre_Link, true);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'componentprocess',iparms:[{postForm:true},{sPrefix:true},{sSFPrefix:true},{sCompEvt:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'AV7SatisfaccionId',fld:'vSATISFACCIONID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV27AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A359SatisfaccionMejoraSoftware',fld:'SATISFACCIONMEJORASOFTWARE',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E19062',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A32SatisfaccionFecha',fld:'SATISFACCIONFECHA',pic:''},{av:'AV27AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV27AttributeValue',fld:'vATTRIBUTEVALUE',pic:'',hsh:true},{av:'AV10Navigation',fld:'vNAVIGATION',pic:'',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A7SatisfaccionId',fld:'SATISFACCIONID',pic:'ZZZZZZZZZ9'}]}");
         setEventMetadata("'DOCANCEL'","{handler:'E20062',iparms:[{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("'DOCANCEL'",",oparms:[]}");
         setEventMetadata("LINESEPARATORTITLE_LNRESUELTO.CLICK","{handler:'E11066',iparms:[{av:'divLineseparatorcontent_lnresuelto_Visible',ctrl:'LINESEPARATORCONTENT_LNRESUELTO',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LNRESUELTO.CLICK",",oparms:[{av:'divLineseparatorcontent_lnresuelto_Visible',ctrl:'LINESEPARATORCONTENT_LNRESUELTO',prop:'Visible'},{av:'divLineseparatorcontent_lnresuelto_Class',ctrl:'LINESEPARATORCONTENT_LNRESUELTO',prop:'Class'},{av:'divLineseparatorheader_lnresuelto_Class',ctrl:'LINESEPARATORHEADER_LNRESUELTO',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_LNPROBLEMA.CLICK","{handler:'E12066',iparms:[{av:'divLineseparatorcontent_lnproblema_Visible',ctrl:'LINESEPARATORCONTENT_LNPROBLEMA',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LNPROBLEMA.CLICK",",oparms:[{av:'divLineseparatorcontent_lnproblema_Visible',ctrl:'LINESEPARATORCONTENT_LNPROBLEMA',prop:'Visible'},{av:'divLineseparatorcontent_lnproblema_Class',ctrl:'LINESEPARATORCONTENT_LNPROBLEMA',prop:'Class'},{av:'divLineseparatorheader_lnproblema_Class',ctrl:'LINESEPARATORHEADER_LNPROBLEMA',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_LNCAPACIDAD.CLICK","{handler:'E13066',iparms:[{av:'divLineseparatorcontent_lncapacidad_Visible',ctrl:'LINESEPARATORCONTENT_LNCAPACIDAD',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LNCAPACIDAD.CLICK",",oparms:[{av:'divLineseparatorcontent_lncapacidad_Visible',ctrl:'LINESEPARATORCONTENT_LNCAPACIDAD',prop:'Visible'},{av:'divLineseparatorcontent_lncapacidad_Class',ctrl:'LINESEPARATORCONTENT_LNCAPACIDAD',prop:'Class'},{av:'divLineseparatorheader_lncapacidad_Class',ctrl:'LINESEPARATORHEADER_LNCAPACIDAD',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_LNCORTESIA.CLICK","{handler:'E14066',iparms:[{av:'divLineseparatorcontent_lncortesia_Visible',ctrl:'LINESEPARATORCONTENT_LNCORTESIA',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LNCORTESIA.CLICK",",oparms:[{av:'divLineseparatorcontent_lncortesia_Visible',ctrl:'LINESEPARATORCONTENT_LNCORTESIA',prop:'Visible'},{av:'divLineseparatorcontent_lncortesia_Class',ctrl:'LINESEPARATORCONTENT_LNCORTESIA',prop:'Class'},{av:'divLineseparatorheader_lncortesia_Class',ctrl:'LINESEPARATORHEADER_LNCORTESIA',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_LNTIEMPO.CLICK","{handler:'E15066',iparms:[{av:'divLineseparatorcontent_lntiempo_Visible',ctrl:'LINESEPARATORCONTENT_LNTIEMPO',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LNTIEMPO.CLICK",",oparms:[{av:'divLineseparatorcontent_lntiempo_Visible',ctrl:'LINESEPARATORCONTENT_LNTIEMPO',prop:'Visible'},{av:'divLineseparatorcontent_lntiempo_Class',ctrl:'LINESEPARATORCONTENT_LNTIEMPO',prop:'Class'},{av:'divLineseparatorheader_lntiempo_Class',ctrl:'LINESEPARATORHEADER_LNTIEMPO',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_CLATENCION.CLICK","{handler:'E16066',iparms:[{av:'divLineseparatorcontent_clatencion_Visible',ctrl:'LINESEPARATORCONTENT_CLATENCION',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_CLATENCION.CLICK",",oparms:[{av:'divLineseparatorcontent_clatencion_Visible',ctrl:'LINESEPARATORCONTENT_CLATENCION',prop:'Visible'},{av:'divLineseparatorcontent_clatencion_Class',ctrl:'LINESEPARATORCONTENT_CLATENCION',prop:'Class'},{av:'divLineseparatorheader_clatencion_Class',ctrl:'LINESEPARATORHEADER_CLATENCION',prop:'Class'}]}");
         setEventMetadata("LINESEPARATORTITLE_LNSUGERENCIA.CLICK","{handler:'E17066',iparms:[{av:'divLineseparatorcontent_lnsugerencia_Visible',ctrl:'LINESEPARATORCONTENT_LNSUGERENCIA',prop:'Visible'}]");
         setEventMetadata("LINESEPARATORTITLE_LNSUGERENCIA.CLICK",",oparms:[{av:'divLineseparatorcontent_lnsugerencia_Visible',ctrl:'LINESEPARATORCONTENT_LNSUGERENCIA',prop:'Visible'},{av:'divLineseparatorcontent_lnsugerencia_Class',ctrl:'LINESEPARATORCONTENT_LNSUGERENCIA',prop:'Class'},{av:'divLineseparatorheader_lnsugerencia_Class',ctrl:'LINESEPARATORHEADER_LNSUGERENCIA',prop:'Class'}]}");
         setEventMetadata("VALID_SATISFACCIONID","{handler:'Valid_Satisfaccionid',iparms:[]");
         setEventMetadata("VALID_SATISFACCIONID",",oparms:[]}");
         setEventMetadata("VALID_SATISFACCIONFECHA","{handler:'Valid_Satisfaccionfecha',iparms:[]");
         setEventMetadata("VALID_SATISFACCIONFECHA",",oparms:[]}");
         setEventMetadata("VALID_TICKETRESPONSABLEID","{handler:'Valid_Ticketresponsableid',iparms:[]");
         setEventMetadata("VALID_TICKETRESPONSABLEID",",oparms:[]}");
         setEventMetadata("VALID_TICKETID","{handler:'Valid_Ticketid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A14TicketId',fld:'TICKETID',pic:'ZZZZZZZZZ9'},{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A16TicketResponsableId',fld:'TICKETRESPONSABLEID',pic:'ZZZZZZZZZ9'},{av:'A198TicketTecnicoResponsableId',fld:'TICKETTECNICORESPONSABLEID',pic:'ZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A90UsuarioFecha',fld:'USUARIOFECHA',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'A199TicketTecnicoResponsableNombre',fld:'TICKETTECNICORESPONSABLENOMBRE',pic:''}]");
         setEventMetadata("VALID_TICKETID",",oparms:[{av:'A15UsuarioId',fld:'USUARIOID',pic:'ZZZZZZZZZ9'},{av:'A93UsuarioNombre',fld:'USUARIONOMBRE',pic:''},{av:'A90UsuarioFecha',fld:'USUARIOFECHA',pic:''},{av:'A94UsuarioRequerimiento',fld:'USUARIOREQUERIMIENTO',pic:''},{av:'edtUsuarioNombre_Link',ctrl:'USUARIONOMBRE',prop:'Link'},{av:'A198TicketTecnicoResponsableId',fld:'TICKETTECNICORESPONSABLEID',pic:'ZZZ9'},{av:'A199TicketTecnicoResponsableNombre',fld:'TICKETTECNICORESPONSABLENOMBRE',pic:''}]}");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID","{handler:'Valid_Tickettecnicoresponsableid',iparms:[]");
         setEventMetadata("VALID_TICKETTECNICORESPONSABLEID",",oparms:[]}");
         setEventMetadata("VALID_USUARIOID","{handler:'Valid_Usuarioid',iparms:[]");
         setEventMetadata("VALID_USUARIOID",",oparms:[]}");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID","{handler:'Valid_Satisfaccionresueltoid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A8SatisfaccionResueltoId',fld:'SATISFACCIONRESUELTOID',pic:'ZZZ9'},{av:'A33SatisfaccionResueltoNombre',fld:'SATISFACCIONRESUELTONOMBRE',pic:''},{av:'A280SatisfaccionResueltoCalificacion',fld:'SATISFACCIONRESUELTOCALIFICACION',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SATISFACCIONRESUELTOID",",oparms:[{av:'A33SatisfaccionResueltoNombre',fld:'SATISFACCIONRESUELTONOMBRE',pic:''},{av:'A280SatisfaccionResueltoCalificacion',fld:'SATISFACCIONRESUELTOCALIFICACION',pic:'ZZZ9'},{av:'edtSatisfaccionResueltoNombre_Link',ctrl:'SATISFACCIONRESUELTONOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID","{handler:'Valid_Satisfacciontecnicoproblemaid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A9SatisfaccionTecnicoProblemaId',fld:'SATISFACCIONTECNICOPROBLEMAID',pic:'ZZZ9'},{av:'A36SatisfaccionTecnicoProblemaNombre',fld:'SATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'A282SatisfaccionTecnicoProblemaCalificacion',fld:'SATISFACCIONTECNICOPROBLEMACALIFICACION',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROBLEMAID",",oparms:[{av:'A36SatisfaccionTecnicoProblemaNombre',fld:'SATISFACCIONTECNICOPROBLEMANOMBRE',pic:''},{av:'A282SatisfaccionTecnicoProblemaCalificacion',fld:'SATISFACCIONTECNICOPROBLEMACALIFICACION',pic:'ZZZ9'},{av:'edtSatisfaccionTecnicoProblemaNombre_Link',ctrl:'SATISFACCIONTECNICOPROBLEMANOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID","{handler:'Valid_Satisfacciontecnicocompetenteid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A10SatisfaccionTecnicoCompetenteId',fld:'SATISFACCIONTECNICOCOMPETENTEID',pic:'ZZZ9'},{av:'A35SatisfaccionTecnicoCompetenteNombre',fld:'SATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'A281SatisfaccionTecnicoCompetenteCalificacion',fld:'SATISFACCIONTECNICOCOMPETENTECALIFICACION',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOCOMPETENTEID",",oparms:[{av:'A35SatisfaccionTecnicoCompetenteNombre',fld:'SATISFACCIONTECNICOCOMPETENTENOMBRE',pic:''},{av:'A281SatisfaccionTecnicoCompetenteCalificacion',fld:'SATISFACCIONTECNICOCOMPETENTECALIFICACION',pic:'ZZZ9'},{av:'edtSatisfaccionTecnicoCompetenteNombre_Link',ctrl:'SATISFACCIONTECNICOCOMPETENTENOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID","{handler:'Valid_Satisfacciontecnicoprofesionalismoid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A11SatisfaccionTecnicoProfesionalismoId',fld:'SATISFACCIONTECNICOPROFESIONALISMOID',pic:'ZZZ9'},{av:'A37SatisfaccionTecnicoProfesionalismoNombre',fld:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'A283SatisfaccionTecnicoProfesionalismoCalificacion',fld:'SATISFACCIONTECNICOPROFESIONALISMOCALIFICACION',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SATISFACCIONTECNICOPROFESIONALISMOID",",oparms:[{av:'A37SatisfaccionTecnicoProfesionalismoNombre',fld:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',pic:''},{av:'A283SatisfaccionTecnicoProfesionalismoCalificacion',fld:'SATISFACCIONTECNICOPROFESIONALISMOCALIFICACION',pic:'ZZZ9'},{av:'edtSatisfaccionTecnicoProfesionalismoNombre_Link',ctrl:'SATISFACCIONTECNICOPROFESIONALISMONOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID","{handler:'Valid_Satisfacciontiempoid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A12SatisfaccionTiempoId',fld:'SATISFACCIONTIEMPOID',pic:'ZZZ9'},{av:'A38SatisfaccionTiempoNombre',fld:'SATISFACCIONTIEMPONOMBRE',pic:''},{av:'A284SatisfaccionTiempoCalificacion',fld:'SATISFACCIONTIEMPOCALIFICACION',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SATISFACCIONTIEMPOID",",oparms:[{av:'A38SatisfaccionTiempoNombre',fld:'SATISFACCIONTIEMPONOMBRE',pic:''},{av:'A284SatisfaccionTiempoCalificacion',fld:'SATISFACCIONTIEMPOCALIFICACION',pic:'ZZZ9'},{av:'edtSatisfaccionTiempoNombre_Link',ctrl:'SATISFACCIONTIEMPONOMBRE',prop:'Link'}]}");
         setEventMetadata("VALID_SATISFACCIONATENCIONID","{handler:'Valid_Satisfaccionatencionid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A13SatisfaccionAtencionId',fld:'SATISFACCIONATENCIONID',pic:'ZZZ9'},{av:'A31SatisfaccionAtencionNombre',fld:'SATISFACCIONATENCIONNOMBRE',pic:''},{av:'A279SatisfaccionAtencionCalificacion',fld:'SATISFACCIONATENCIONCALIFICACION',pic:'ZZZ9'}]");
         setEventMetadata("VALID_SATISFACCIONATENCIONID",",oparms:[{av:'A31SatisfaccionAtencionNombre',fld:'SATISFACCIONATENCIONNOMBRE',pic:''},{av:'A279SatisfaccionAtencionCalificacion',fld:'SATISFACCIONATENCIONCALIFICACION',pic:'ZZZ9'},{av:'edtSatisfaccionAtencionNombre_Link',ctrl:'SATISFACCIONATENCIONNOMBRE',prop:'Link'}]}");
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
         pr_default.close(39);
         pr_default.close(37);
         pr_default.close(41);
         pr_default.close(42);
         pr_default.close(43);
         pr_default.close(44);
         pr_default.close(45);
         pr_default.close(46);
         pr_default.close(47);
         pr_default.close(48);
         pr_default.close(49);
         pr_default.close(50);
         pr_default.close(40);
         pr_default.close(38);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z32SatisfaccionFecha = DateTime.MinValue;
         Z144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         Z34SatisfaccionSugerencia = "";
         Z359SatisfaccionMejoraSoftware = "";
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
         A32SatisfaccionFecha = DateTime.MinValue;
         TempTags = "";
         A144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         sImgUrl = "";
         A90UsuarioFecha = DateTime.MinValue;
         A199TicketTecnicoResponsableNombre = "";
         A93UsuarioNombre = "";
         A94UsuarioRequerimiento = "";
         lblLineseparatortitle_lnresuelto_Jsonclick = "";
         A33SatisfaccionResueltoNombre = "";
         lblLineseparatortitle_lnproblema_Jsonclick = "";
         A36SatisfaccionTecnicoProblemaNombre = "";
         lblLineseparatortitle_lncapacidad_Jsonclick = "";
         A35SatisfaccionTecnicoCompetenteNombre = "";
         lblLineseparatortitle_lncortesia_Jsonclick = "";
         A37SatisfaccionTecnicoProfesionalismoNombre = "";
         lblLineseparatortitle_lntiempo_Jsonclick = "";
         A38SatisfaccionTiempoNombre = "";
         lblLineseparatortitle_clatencion_Jsonclick = "";
         A31SatisfaccionAtencionNombre = "";
         lblLineseparatortitle_lnsugerencia_Jsonclick = "";
         A34SatisfaccionSugerencia = "";
         sStyleString = "";
         bttEnter_Jsonclick = "";
         bttCancel_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         A359SatisfaccionMejoraSoftware = "";
         A348SatisfaccionCatalogaNombre = "";
         A351SatisfaccionRendimientoNombre = "";
         A354SatisfaccionProgramadorNombre = "";
         A357SatisfaccionCapacitacionNombre = "";
         AV40Pgmname = "";
         K2bcontrolbeautify1_Objectcall = "";
         K2bcontrolbeautify1_Class = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV23StandardActivityType = "";
         AV24UserActivityType = "";
         AV19Context = new SdtK2BContext(context);
         AV20BtnCaption = "";
         AV21BtnTooltip = "";
         AV8TrnContext = new SdtK2BTrnContext(context);
         AV9TrnContextAtt = new SdtK2BTrnContext_Attribute(context);
         AV27AttributeValue = new GXBaseCollection<SdtK2BAttributeValue_Item>( context, "Item", "kb_ticket");
         AV28AttributeValueItem = new SdtK2BAttributeValue_Item(context);
         AV29Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV10Navigation = new SdtK2BTrnNavigation(context);
         AV26encrypt = "";
         GXt_char1 = "";
         AV11DinamicObjToLink = "";
         GXEncryptionTmp = "";
         AV22Url = "";
         Z348SatisfaccionCatalogaNombre = "";
         Z351SatisfaccionRendimientoNombre = "";
         Z354SatisfaccionProgramadorNombre = "";
         Z357SatisfaccionCapacitacionNombre = "";
         Z93UsuarioNombre = "";
         Z90UsuarioFecha = DateTime.MinValue;
         Z94UsuarioRequerimiento = "";
         Z199TicketTecnicoResponsableNombre = "";
         Z33SatisfaccionResueltoNombre = "";
         Z36SatisfaccionTecnicoProblemaNombre = "";
         Z35SatisfaccionTecnicoCompetenteNombre = "";
         Z37SatisfaccionTecnicoProfesionalismoNombre = "";
         Z38SatisfaccionTiempoNombre = "";
         Z31SatisfaccionAtencionNombre = "";
         T000615_A357SatisfaccionCapacitacionNombre = new string[] {""} ;
         T000615_A358SatisfaccionCapacitacionCalificacion = new short[1] ;
         T000614_A354SatisfaccionProgramadorNombre = new string[] {""} ;
         T000614_A355SatisfaccionProgramadorCalificacion = new short[1] ;
         T000613_A351SatisfaccionRendimientoNombre = new string[] {""} ;
         T000613_A352SatisfaccionRendimientoCalificacion = new short[1] ;
         T000612_A348SatisfaccionCatalogaNombre = new string[] {""} ;
         T000612_A349SatisfaccionCatalogaCalificacion = new short[1] ;
         T000611_A31SatisfaccionAtencionNombre = new string[] {""} ;
         T000611_A279SatisfaccionAtencionCalificacion = new short[1] ;
         T000610_A38SatisfaccionTiempoNombre = new string[] {""} ;
         T000610_A284SatisfaccionTiempoCalificacion = new short[1] ;
         T00069_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         T00069_A283SatisfaccionTecnicoProfesionalismoCalificacion = new short[1] ;
         T00068_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         T00068_A281SatisfaccionTecnicoCompetenteCalificacion = new short[1] ;
         T00067_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         T00067_A282SatisfaccionTecnicoProblemaCalificacion = new short[1] ;
         T00066_A33SatisfaccionResueltoNombre = new string[] {""} ;
         T00066_A280SatisfaccionResueltoCalificacion = new short[1] ;
         T00064_A15UsuarioId = new long[1] ;
         T000617_A93UsuarioNombre = new string[] {""} ;
         T000617_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T000617_A94UsuarioRequerimiento = new string[] {""} ;
         T00065_A198TicketTecnicoResponsableId = new short[1] ;
         T000616_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000618_A7SatisfaccionId = new long[1] ;
         T000618_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         T000618_A144SatisfaccionHora = new DateTime[] {DateTime.MinValue} ;
         T000618_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000618_A93UsuarioNombre = new string[] {""} ;
         T000618_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T000618_A94UsuarioRequerimiento = new string[] {""} ;
         T000618_A33SatisfaccionResueltoNombre = new string[] {""} ;
         T000618_A280SatisfaccionResueltoCalificacion = new short[1] ;
         T000618_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         T000618_A282SatisfaccionTecnicoProblemaCalificacion = new short[1] ;
         T000618_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         T000618_A281SatisfaccionTecnicoCompetenteCalificacion = new short[1] ;
         T000618_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         T000618_A283SatisfaccionTecnicoProfesionalismoCalificacion = new short[1] ;
         T000618_A38SatisfaccionTiempoNombre = new string[] {""} ;
         T000618_A284SatisfaccionTiempoCalificacion = new short[1] ;
         T000618_A31SatisfaccionAtencionNombre = new string[] {""} ;
         T000618_A279SatisfaccionAtencionCalificacion = new short[1] ;
         T000618_A34SatisfaccionSugerencia = new string[] {""} ;
         T000618_n34SatisfaccionSugerencia = new bool[] {false} ;
         T000618_A348SatisfaccionCatalogaNombre = new string[] {""} ;
         T000618_A349SatisfaccionCatalogaCalificacion = new short[1] ;
         T000618_A351SatisfaccionRendimientoNombre = new string[] {""} ;
         T000618_A352SatisfaccionRendimientoCalificacion = new short[1] ;
         T000618_A354SatisfaccionProgramadorNombre = new string[] {""} ;
         T000618_A355SatisfaccionProgramadorCalificacion = new short[1] ;
         T000618_A357SatisfaccionCapacitacionNombre = new string[] {""} ;
         T000618_A358SatisfaccionCapacitacionCalificacion = new short[1] ;
         T000618_A359SatisfaccionMejoraSoftware = new string[] {""} ;
         T000618_n359SatisfaccionMejoraSoftware = new bool[] {false} ;
         T000618_A14TicketId = new long[1] ;
         T000618_A16TicketResponsableId = new long[1] ;
         T000618_A8SatisfaccionResueltoId = new short[1] ;
         T000618_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         T000618_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         T000618_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         T000618_A12SatisfaccionTiempoId = new short[1] ;
         T000618_A13SatisfaccionAtencionId = new short[1] ;
         T000618_A347SatisfaccionCatalogaId = new short[1] ;
         T000618_A350SatisfaccionRendimientoId = new short[1] ;
         T000618_A353SatisfaccionProgramadorId = new short[1] ;
         T000618_A356SatisfaccionCapacitacionId = new short[1] ;
         T000618_A198TicketTecnicoResponsableId = new short[1] ;
         T000618_A15UsuarioId = new long[1] ;
         T000619_A15UsuarioId = new long[1] ;
         T000620_A93UsuarioNombre = new string[] {""} ;
         T000620_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T000620_A94UsuarioRequerimiento = new string[] {""} ;
         T000621_A198TicketTecnicoResponsableId = new short[1] ;
         T000622_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000623_A33SatisfaccionResueltoNombre = new string[] {""} ;
         T000623_A280SatisfaccionResueltoCalificacion = new short[1] ;
         T000624_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         T000624_A282SatisfaccionTecnicoProblemaCalificacion = new short[1] ;
         T000625_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         T000625_A281SatisfaccionTecnicoCompetenteCalificacion = new short[1] ;
         T000626_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         T000626_A283SatisfaccionTecnicoProfesionalismoCalificacion = new short[1] ;
         T000627_A38SatisfaccionTiempoNombre = new string[] {""} ;
         T000627_A284SatisfaccionTiempoCalificacion = new short[1] ;
         T000628_A31SatisfaccionAtencionNombre = new string[] {""} ;
         T000628_A279SatisfaccionAtencionCalificacion = new short[1] ;
         T000629_A348SatisfaccionCatalogaNombre = new string[] {""} ;
         T000629_A349SatisfaccionCatalogaCalificacion = new short[1] ;
         T000630_A351SatisfaccionRendimientoNombre = new string[] {""} ;
         T000630_A352SatisfaccionRendimientoCalificacion = new short[1] ;
         T000631_A354SatisfaccionProgramadorNombre = new string[] {""} ;
         T000631_A355SatisfaccionProgramadorCalificacion = new short[1] ;
         T000632_A357SatisfaccionCapacitacionNombre = new string[] {""} ;
         T000632_A358SatisfaccionCapacitacionCalificacion = new short[1] ;
         T000633_A7SatisfaccionId = new long[1] ;
         T00063_A7SatisfaccionId = new long[1] ;
         T00063_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         T00063_A144SatisfaccionHora = new DateTime[] {DateTime.MinValue} ;
         T00063_A34SatisfaccionSugerencia = new string[] {""} ;
         T00063_n34SatisfaccionSugerencia = new bool[] {false} ;
         T00063_A359SatisfaccionMejoraSoftware = new string[] {""} ;
         T00063_n359SatisfaccionMejoraSoftware = new bool[] {false} ;
         T00063_A14TicketId = new long[1] ;
         T00063_A16TicketResponsableId = new long[1] ;
         T00063_A8SatisfaccionResueltoId = new short[1] ;
         T00063_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         T00063_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         T00063_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         T00063_A12SatisfaccionTiempoId = new short[1] ;
         T00063_A13SatisfaccionAtencionId = new short[1] ;
         T00063_A347SatisfaccionCatalogaId = new short[1] ;
         T00063_A350SatisfaccionRendimientoId = new short[1] ;
         T00063_A353SatisfaccionProgramadorId = new short[1] ;
         T00063_A356SatisfaccionCapacitacionId = new short[1] ;
         T000634_A7SatisfaccionId = new long[1] ;
         T000635_A7SatisfaccionId = new long[1] ;
         T00062_A7SatisfaccionId = new long[1] ;
         T00062_A32SatisfaccionFecha = new DateTime[] {DateTime.MinValue} ;
         T00062_A144SatisfaccionHora = new DateTime[] {DateTime.MinValue} ;
         T00062_A34SatisfaccionSugerencia = new string[] {""} ;
         T00062_n34SatisfaccionSugerencia = new bool[] {false} ;
         T00062_A359SatisfaccionMejoraSoftware = new string[] {""} ;
         T00062_n359SatisfaccionMejoraSoftware = new bool[] {false} ;
         T00062_A14TicketId = new long[1] ;
         T00062_A16TicketResponsableId = new long[1] ;
         T00062_A8SatisfaccionResueltoId = new short[1] ;
         T00062_A9SatisfaccionTecnicoProblemaId = new short[1] ;
         T00062_A10SatisfaccionTecnicoCompetenteId = new short[1] ;
         T00062_A11SatisfaccionTecnicoProfesionalismoId = new short[1] ;
         T00062_A12SatisfaccionTiempoId = new short[1] ;
         T00062_A13SatisfaccionAtencionId = new short[1] ;
         T00062_A347SatisfaccionCatalogaId = new short[1] ;
         T00062_A350SatisfaccionRendimientoId = new short[1] ;
         T00062_A353SatisfaccionProgramadorId = new short[1] ;
         T00062_A356SatisfaccionCapacitacionId = new short[1] ;
         T000639_A15UsuarioId = new long[1] ;
         T000640_A93UsuarioNombre = new string[] {""} ;
         T000640_A90UsuarioFecha = new DateTime[] {DateTime.MinValue} ;
         T000640_A94UsuarioRequerimiento = new string[] {""} ;
         T000641_A198TicketTecnicoResponsableId = new short[1] ;
         T000642_A199TicketTecnicoResponsableNombre = new string[] {""} ;
         T000643_A33SatisfaccionResueltoNombre = new string[] {""} ;
         T000643_A280SatisfaccionResueltoCalificacion = new short[1] ;
         T000644_A36SatisfaccionTecnicoProblemaNombre = new string[] {""} ;
         T000644_A282SatisfaccionTecnicoProblemaCalificacion = new short[1] ;
         T000645_A35SatisfaccionTecnicoCompetenteNombre = new string[] {""} ;
         T000645_A281SatisfaccionTecnicoCompetenteCalificacion = new short[1] ;
         T000646_A37SatisfaccionTecnicoProfesionalismoNombre = new string[] {""} ;
         T000646_A283SatisfaccionTecnicoProfesionalismoCalificacion = new short[1] ;
         T000647_A38SatisfaccionTiempoNombre = new string[] {""} ;
         T000647_A284SatisfaccionTiempoCalificacion = new short[1] ;
         T000648_A31SatisfaccionAtencionNombre = new string[] {""} ;
         T000648_A279SatisfaccionAtencionCalificacion = new short[1] ;
         T000649_A348SatisfaccionCatalogaNombre = new string[] {""} ;
         T000649_A349SatisfaccionCatalogaCalificacion = new short[1] ;
         T000650_A351SatisfaccionRendimientoNombre = new string[] {""} ;
         T000650_A352SatisfaccionRendimientoCalificacion = new short[1] ;
         T000651_A354SatisfaccionProgramadorNombre = new string[] {""} ;
         T000651_A355SatisfaccionProgramadorCalificacion = new short[1] ;
         T000652_A357SatisfaccionCapacitacionNombre = new string[] {""} ;
         T000652_A358SatisfaccionCapacitacionCalificacion = new short[1] ;
         T000653_A7SatisfaccionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i32SatisfaccionFecha = DateTime.MinValue;
         i144SatisfaccionHora = (DateTime)(DateTime.MinValue);
         sCtrlGx_mode = "";
         sCtrlAV7SatisfaccionId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.satisfaccion__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.satisfaccion__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.satisfaccion__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.satisfaccion__default(),
            new Object[][] {
                new Object[] {
               T00062_A7SatisfaccionId, T00062_A32SatisfaccionFecha, T00062_A144SatisfaccionHora, T00062_A34SatisfaccionSugerencia, T00062_n34SatisfaccionSugerencia, T00062_A359SatisfaccionMejoraSoftware, T00062_n359SatisfaccionMejoraSoftware, T00062_A14TicketId, T00062_A16TicketResponsableId, T00062_A8SatisfaccionResueltoId,
               T00062_A9SatisfaccionTecnicoProblemaId, T00062_A10SatisfaccionTecnicoCompetenteId, T00062_A11SatisfaccionTecnicoProfesionalismoId, T00062_A12SatisfaccionTiempoId, T00062_A13SatisfaccionAtencionId, T00062_A347SatisfaccionCatalogaId, T00062_A350SatisfaccionRendimientoId, T00062_A353SatisfaccionProgramadorId, T00062_A356SatisfaccionCapacitacionId
               }
               , new Object[] {
               T00063_A7SatisfaccionId, T00063_A32SatisfaccionFecha, T00063_A144SatisfaccionHora, T00063_A34SatisfaccionSugerencia, T00063_n34SatisfaccionSugerencia, T00063_A359SatisfaccionMejoraSoftware, T00063_n359SatisfaccionMejoraSoftware, T00063_A14TicketId, T00063_A16TicketResponsableId, T00063_A8SatisfaccionResueltoId,
               T00063_A9SatisfaccionTecnicoProblemaId, T00063_A10SatisfaccionTecnicoCompetenteId, T00063_A11SatisfaccionTecnicoProfesionalismoId, T00063_A12SatisfaccionTiempoId, T00063_A13SatisfaccionAtencionId, T00063_A347SatisfaccionCatalogaId, T00063_A350SatisfaccionRendimientoId, T00063_A353SatisfaccionProgramadorId, T00063_A356SatisfaccionCapacitacionId
               }
               , new Object[] {
               T00064_A15UsuarioId
               }
               , new Object[] {
               T00065_A198TicketTecnicoResponsableId
               }
               , new Object[] {
               T00066_A33SatisfaccionResueltoNombre, T00066_A280SatisfaccionResueltoCalificacion
               }
               , new Object[] {
               T00067_A36SatisfaccionTecnicoProblemaNombre, T00067_A282SatisfaccionTecnicoProblemaCalificacion
               }
               , new Object[] {
               T00068_A35SatisfaccionTecnicoCompetenteNombre, T00068_A281SatisfaccionTecnicoCompetenteCalificacion
               }
               , new Object[] {
               T00069_A37SatisfaccionTecnicoProfesionalismoNombre, T00069_A283SatisfaccionTecnicoProfesionalismoCalificacion
               }
               , new Object[] {
               T000610_A38SatisfaccionTiempoNombre, T000610_A284SatisfaccionTiempoCalificacion
               }
               , new Object[] {
               T000611_A31SatisfaccionAtencionNombre, T000611_A279SatisfaccionAtencionCalificacion
               }
               , new Object[] {
               T000612_A348SatisfaccionCatalogaNombre, T000612_A349SatisfaccionCatalogaCalificacion
               }
               , new Object[] {
               T000613_A351SatisfaccionRendimientoNombre, T000613_A352SatisfaccionRendimientoCalificacion
               }
               , new Object[] {
               T000614_A354SatisfaccionProgramadorNombre, T000614_A355SatisfaccionProgramadorCalificacion
               }
               , new Object[] {
               T000615_A357SatisfaccionCapacitacionNombre, T000615_A358SatisfaccionCapacitacionCalificacion
               }
               , new Object[] {
               T000616_A199TicketTecnicoResponsableNombre
               }
               , new Object[] {
               T000617_A93UsuarioNombre, T000617_A90UsuarioFecha, T000617_A94UsuarioRequerimiento
               }
               , new Object[] {
               T000618_A7SatisfaccionId, T000618_A32SatisfaccionFecha, T000618_A144SatisfaccionHora, T000618_A199TicketTecnicoResponsableNombre, T000618_A93UsuarioNombre, T000618_A90UsuarioFecha, T000618_A94UsuarioRequerimiento, T000618_A33SatisfaccionResueltoNombre, T000618_A280SatisfaccionResueltoCalificacion, T000618_A36SatisfaccionTecnicoProblemaNombre,
               T000618_A282SatisfaccionTecnicoProblemaCalificacion, T000618_A35SatisfaccionTecnicoCompetenteNombre, T000618_A281SatisfaccionTecnicoCompetenteCalificacion, T000618_A37SatisfaccionTecnicoProfesionalismoNombre, T000618_A283SatisfaccionTecnicoProfesionalismoCalificacion, T000618_A38SatisfaccionTiempoNombre, T000618_A284SatisfaccionTiempoCalificacion, T000618_A31SatisfaccionAtencionNombre, T000618_A279SatisfaccionAtencionCalificacion, T000618_A34SatisfaccionSugerencia,
               T000618_n34SatisfaccionSugerencia, T000618_A348SatisfaccionCatalogaNombre, T000618_A349SatisfaccionCatalogaCalificacion, T000618_A351SatisfaccionRendimientoNombre, T000618_A352SatisfaccionRendimientoCalificacion, T000618_A354SatisfaccionProgramadorNombre, T000618_A355SatisfaccionProgramadorCalificacion, T000618_A357SatisfaccionCapacitacionNombre, T000618_A358SatisfaccionCapacitacionCalificacion, T000618_A359SatisfaccionMejoraSoftware,
               T000618_n359SatisfaccionMejoraSoftware, T000618_A14TicketId, T000618_A16TicketResponsableId, T000618_A8SatisfaccionResueltoId, T000618_A9SatisfaccionTecnicoProblemaId, T000618_A10SatisfaccionTecnicoCompetenteId, T000618_A11SatisfaccionTecnicoProfesionalismoId, T000618_A12SatisfaccionTiempoId, T000618_A13SatisfaccionAtencionId, T000618_A347SatisfaccionCatalogaId,
               T000618_A350SatisfaccionRendimientoId, T000618_A353SatisfaccionProgramadorId, T000618_A356SatisfaccionCapacitacionId, T000618_A198TicketTecnicoResponsableId, T000618_A15UsuarioId
               }
               , new Object[] {
               T000619_A15UsuarioId
               }
               , new Object[] {
               T000620_A93UsuarioNombre, T000620_A90UsuarioFecha, T000620_A94UsuarioRequerimiento
               }
               , new Object[] {
               T000621_A198TicketTecnicoResponsableId
               }
               , new Object[] {
               T000622_A199TicketTecnicoResponsableNombre
               }
               , new Object[] {
               T000623_A33SatisfaccionResueltoNombre, T000623_A280SatisfaccionResueltoCalificacion
               }
               , new Object[] {
               T000624_A36SatisfaccionTecnicoProblemaNombre, T000624_A282SatisfaccionTecnicoProblemaCalificacion
               }
               , new Object[] {
               T000625_A35SatisfaccionTecnicoCompetenteNombre, T000625_A281SatisfaccionTecnicoCompetenteCalificacion
               }
               , new Object[] {
               T000626_A37SatisfaccionTecnicoProfesionalismoNombre, T000626_A283SatisfaccionTecnicoProfesionalismoCalificacion
               }
               , new Object[] {
               T000627_A38SatisfaccionTiempoNombre, T000627_A284SatisfaccionTiempoCalificacion
               }
               , new Object[] {
               T000628_A31SatisfaccionAtencionNombre, T000628_A279SatisfaccionAtencionCalificacion
               }
               , new Object[] {
               T000629_A348SatisfaccionCatalogaNombre, T000629_A349SatisfaccionCatalogaCalificacion
               }
               , new Object[] {
               T000630_A351SatisfaccionRendimientoNombre, T000630_A352SatisfaccionRendimientoCalificacion
               }
               , new Object[] {
               T000631_A354SatisfaccionProgramadorNombre, T000631_A355SatisfaccionProgramadorCalificacion
               }
               , new Object[] {
               T000632_A357SatisfaccionCapacitacionNombre, T000632_A358SatisfaccionCapacitacionCalificacion
               }
               , new Object[] {
               T000633_A7SatisfaccionId
               }
               , new Object[] {
               T000634_A7SatisfaccionId
               }
               , new Object[] {
               T000635_A7SatisfaccionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000639_A15UsuarioId
               }
               , new Object[] {
               T000640_A93UsuarioNombre, T000640_A90UsuarioFecha, T000640_A94UsuarioRequerimiento
               }
               , new Object[] {
               T000641_A198TicketTecnicoResponsableId
               }
               , new Object[] {
               T000642_A199TicketTecnicoResponsableNombre
               }
               , new Object[] {
               T000643_A33SatisfaccionResueltoNombre, T000643_A280SatisfaccionResueltoCalificacion
               }
               , new Object[] {
               T000644_A36SatisfaccionTecnicoProblemaNombre, T000644_A282SatisfaccionTecnicoProblemaCalificacion
               }
               , new Object[] {
               T000645_A35SatisfaccionTecnicoCompetenteNombre, T000645_A281SatisfaccionTecnicoCompetenteCalificacion
               }
               , new Object[] {
               T000646_A37SatisfaccionTecnicoProfesionalismoNombre, T000646_A283SatisfaccionTecnicoProfesionalismoCalificacion
               }
               , new Object[] {
               T000647_A38SatisfaccionTiempoNombre, T000647_A284SatisfaccionTiempoCalificacion
               }
               , new Object[] {
               T000648_A31SatisfaccionAtencionNombre, T000648_A279SatisfaccionAtencionCalificacion
               }
               , new Object[] {
               T000649_A348SatisfaccionCatalogaNombre, T000649_A349SatisfaccionCatalogaCalificacion
               }
               , new Object[] {
               T000650_A351SatisfaccionRendimientoNombre, T000650_A352SatisfaccionRendimientoCalificacion
               }
               , new Object[] {
               T000651_A354SatisfaccionProgramadorNombre, T000651_A355SatisfaccionProgramadorCalificacion
               }
               , new Object[] {
               T000652_A357SatisfaccionCapacitacionNombre, T000652_A358SatisfaccionCapacitacionCalificacion
               }
               , new Object[] {
               T000653_A7SatisfaccionId
               }
            }
         );
         AV40Pgmname = "Satisfaccion";
         Z144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         A144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         i144SatisfaccionHora = DateTimeUtil.ResetDate(DateTimeUtil.Now( context));
         Z32SatisfaccionFecha = DateTimeUtil.Today( context);
         A32SatisfaccionFecha = DateTimeUtil.Today( context);
         i32SatisfaccionFecha = DateTimeUtil.Today( context);
      }

      private short Z8SatisfaccionResueltoId ;
      private short Z9SatisfaccionTecnicoProblemaId ;
      private short Z10SatisfaccionTecnicoCompetenteId ;
      private short Z11SatisfaccionTecnicoProfesionalismoId ;
      private short Z12SatisfaccionTiempoId ;
      private short Z13SatisfaccionAtencionId ;
      private short Z347SatisfaccionCatalogaId ;
      private short Z350SatisfaccionRendimientoId ;
      private short Z353SatisfaccionProgramadorId ;
      private short Z356SatisfaccionCapacitacionId ;
      private short N8SatisfaccionResueltoId ;
      private short N9SatisfaccionTecnicoProblemaId ;
      private short N10SatisfaccionTecnicoCompetenteId ;
      private short N11SatisfaccionTecnicoProfesionalismoId ;
      private short N12SatisfaccionTiempoId ;
      private short N13SatisfaccionAtencionId ;
      private short N347SatisfaccionCatalogaId ;
      private short N350SatisfaccionRendimientoId ;
      private short N353SatisfaccionProgramadorId ;
      private short N356SatisfaccionCapacitacionId ;
      private short GxWebError ;
      private short nDynComponent ;
      private short A8SatisfaccionResueltoId ;
      private short A9SatisfaccionTecnicoProblemaId ;
      private short A10SatisfaccionTecnicoCompetenteId ;
      private short A11SatisfaccionTecnicoProfesionalismoId ;
      private short A12SatisfaccionTiempoId ;
      private short A13SatisfaccionAtencionId ;
      private short A198TicketTecnicoResponsableId ;
      private short A347SatisfaccionCatalogaId ;
      private short A350SatisfaccionRendimientoId ;
      private short A353SatisfaccionProgramadorId ;
      private short A356SatisfaccionCapacitacionId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDraw ;
      private short nDoneStart ;
      private short AV13Insert_SatisfaccionResueltoId ;
      private short AV14Insert_SatisfaccionTecnicoProblemaId ;
      private short AV15Insert_SatisfaccionTecnicoCompetenteId ;
      private short AV16Insert_SatisfaccionTecnicoProfesionalismoId ;
      private short AV17Insert_SatisfaccionTiempoId ;
      private short AV18Insert_SatisfaccionAtencionId ;
      private short AV35Insert_SatisfaccionCatalogaId ;
      private short AV36Insert_SatisfaccionRendimientoId ;
      private short AV37Insert_SatisfaccionProgramadorId ;
      private short AV38Insert_SatisfaccionCapacitacionId ;
      private short Gx_BScreen ;
      private short A280SatisfaccionResueltoCalificacion ;
      private short A282SatisfaccionTecnicoProblemaCalificacion ;
      private short A281SatisfaccionTecnicoCompetenteCalificacion ;
      private short A283SatisfaccionTecnicoProfesionalismoCalificacion ;
      private short A284SatisfaccionTiempoCalificacion ;
      private short A279SatisfaccionAtencionCalificacion ;
      private short A349SatisfaccionCatalogaCalificacion ;
      private short A352SatisfaccionRendimientoCalificacion ;
      private short A355SatisfaccionProgramadorCalificacion ;
      private short A358SatisfaccionCapacitacionCalificacion ;
      private short RcdFound6 ;
      private short GX_JID ;
      private short Z349SatisfaccionCatalogaCalificacion ;
      private short Z352SatisfaccionRendimientoCalificacion ;
      private short Z355SatisfaccionProgramadorCalificacion ;
      private short Z358SatisfaccionCapacitacionCalificacion ;
      private short Z198TicketTecnicoResponsableId ;
      private short Z280SatisfaccionResueltoCalificacion ;
      private short Z282SatisfaccionTecnicoProblemaCalificacion ;
      private short Z281SatisfaccionTecnicoCompetenteCalificacion ;
      private short Z283SatisfaccionTecnicoProfesionalismoCalificacion ;
      private short Z284SatisfaccionTiempoCalificacion ;
      private short Z279SatisfaccionAtencionCalificacion ;
      private short nIsDirty_6 ;
      private int divLineseparatorcontent_lnresuelto_Visible ;
      private int divLineseparatorcontent_lnproblema_Visible ;
      private int divLineseparatorcontent_lncapacidad_Visible ;
      private int divLineseparatorcontent_lncortesia_Visible ;
      private int divLineseparatorcontent_lntiempo_Visible ;
      private int divLineseparatorcontent_clatencion_Visible ;
      private int divLineseparatorcontent_lnsugerencia_Visible ;
      private int trnEnded ;
      private int divK2btoolstable_attributecontainersatisfaccionid_Visible ;
      private int edtSatisfaccionId_Enabled ;
      private int divK2btoolstable_attributecontainersatisfaccionfecha_Visible ;
      private int edtSatisfaccionFecha_Enabled ;
      private int divK2btoolstable_attributecontainersatisfaccionhora_Visible ;
      private int edtSatisfaccionHora_Enabled ;
      private int edtTicketResponsableId_Enabled ;
      private int imgprompt_16_Visible ;
      private int edtUsuarioFecha_Enabled ;
      private int edtTicketId_Enabled ;
      private int imgprompt_14_Visible ;
      private int divK2btoolstable_attributecontainertickettecnicoresponsableid_Visible ;
      private int edtTicketTecnicoResponsableId_Enabled ;
      private int edtTicketTecnicoResponsableNombre_Enabled ;
      private int divK2btoolstable_attributecontainerusuarioid_Visible ;
      private int edtUsuarioId_Enabled ;
      private int edtUsuarioNombre_Enabled ;
      private int edtUsuarioRequerimiento_Enabled ;
      private int edtSatisfaccionResueltoNombre_Enabled ;
      private int edtSatisfaccionResueltoId_Enabled ;
      private int imgprompt_8_Visible ;
      private int edtSatisfaccionTecnicoProblemaNombre_Enabled ;
      private int edtSatisfaccionTecnicoProblemaId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtSatisfaccionTecnicoCompetenteNombre_Enabled ;
      private int edtSatisfaccionTecnicoCompetenteId_Enabled ;
      private int imgprompt_10_Visible ;
      private int edtSatisfaccionTecnicoProfesionalismoNombre_Enabled ;
      private int edtSatisfaccionTecnicoProfesionalismoId_Enabled ;
      private int imgprompt_11_Visible ;
      private int edtSatisfaccionTiempoNombre_Enabled ;
      private int edtSatisfaccionTiempoId_Enabled ;
      private int imgprompt_12_Visible ;
      private int edtSatisfaccionAtencionId_Enabled ;
      private int imgprompt_13_Visible ;
      private int edtSatisfaccionAtencionNombre_Enabled ;
      private int edtSatisfaccionSugerencia_Enabled ;
      private int bttEnter_Visible ;
      private int bttEnter_Enabled ;
      private int bttCancel_Visible ;
      private int K2bcontrolbeautify1_Gxcontroltype ;
      private int AV41GXV1 ;
      private int idxLst ;
      private long wcpOAV7SatisfaccionId ;
      private long Z7SatisfaccionId ;
      private long Z14TicketId ;
      private long Z16TicketResponsableId ;
      private long N14TicketId ;
      private long N16TicketResponsableId ;
      private long AV7SatisfaccionId ;
      private long A15UsuarioId ;
      private long A14TicketId ;
      private long A16TicketResponsableId ;
      private long A7SatisfaccionId ;
      private long AV12Insert_TicketId ;
      private long AV32Insert_TicketResponsableId ;
      private long Z15UsuarioId ;
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
      private string edtSatisfaccionFecha_Internalname ;
      private string divK2besmaintable_Internalname ;
      private string divK2beserrviewercell_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divK2besdataareacontainercell_Internalname ;
      private string divK2babstracttabledataareacontainer_Internalname ;
      private string divK2btrnformmaintablecell_Internalname ;
      private string divTableattributesinformsection1_Internalname ;
      private string divClmid_Internalname ;
      private string divTableclmid0_Internalname ;
      private string divK2btoolstable_attributecontainersatisfaccionid_Internalname ;
      private string edtSatisfaccionId_Internalname ;
      private string edtSatisfaccionId_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfaccionfecha_Internalname ;
      private string TempTags ;
      private string edtSatisfaccionFecha_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfaccionhora_Internalname ;
      private string edtSatisfaccionHora_Internalname ;
      private string edtSatisfaccionHora_Jsonclick ;
      private string divTableclmid1_Internalname ;
      private string divK2btoolstable_attributecontainerticketresponsableid_Internalname ;
      private string edtTicketResponsableId_Internalname ;
      private string edtTicketResponsableId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_16_Internalname ;
      private string imgprompt_16_Link ;
      private string divClmfecha_Internalname ;
      private string divTableclmfecha0_Internalname ;
      private string divK2btoolstable_attributecontainerusuariofecha_Internalname ;
      private string edtUsuarioFecha_Internalname ;
      private string edtUsuarioFecha_Jsonclick ;
      private string divClmusuario_Internalname ;
      private string divTableclmusuario0_Internalname ;
      private string divK2btoolstable_attributecontainerticketid_Internalname ;
      private string edtTicketId_Internalname ;
      private string edtTicketId_Jsonclick ;
      private string imgprompt_14_Internalname ;
      private string imgprompt_14_Link ;
      private string divK2btoolstable_attributecontainertickettecnicoresponsableid_Internalname ;
      private string edtTicketTecnicoResponsableId_Internalname ;
      private string edtTicketTecnicoResponsableId_Jsonclick ;
      private string divK2btoolstable_attributecontainertickettecnicoresponsablenombre_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Internalname ;
      private string edtTicketTecnicoResponsableNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuarioid_Internalname ;
      private string edtUsuarioId_Internalname ;
      private string edtUsuarioId_Jsonclick ;
      private string divK2btoolstable_attributecontainerusuarionombre_Internalname ;
      private string edtUsuarioNombre_Internalname ;
      private string edtUsuarioNombre_Link ;
      private string edtUsuarioNombre_Jsonclick ;
      private string divTableclmusuario1_Internalname ;
      private string divK2btoolstable_attributecontainerusuariorequerimiento_Internalname ;
      private string edtUsuarioRequerimiento_Internalname ;
      private string divLineseparator_lnresuelto_Internalname ;
      private string divLineseparatorheader_lnresuelto_Internalname ;
      private string divLineseparatorheader_lnresuelto_Class ;
      private string lblLineseparatortitle_lnresuelto_Internalname ;
      private string lblLineseparatortitle_lnresuelto_Jsonclick ;
      private string divLineseparatorcontent_lnresuelto_Internalname ;
      private string divLineseparatorcontent_lnresuelto_Class ;
      private string divK2btoolstable_attributecontainersatisfaccionresueltonombre_Internalname ;
      private string edtSatisfaccionResueltoNombre_Internalname ;
      private string edtSatisfaccionResueltoNombre_Link ;
      private string edtSatisfaccionResueltoNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfaccionresueltoid_Internalname ;
      private string edtSatisfaccionResueltoId_Internalname ;
      private string edtSatisfaccionResueltoId_Jsonclick ;
      private string imgprompt_8_Internalname ;
      private string imgprompt_8_Link ;
      private string divLineseparator_lnproblema_Internalname ;
      private string divLineseparatorheader_lnproblema_Internalname ;
      private string divLineseparatorheader_lnproblema_Class ;
      private string lblLineseparatortitle_lnproblema_Internalname ;
      private string lblLineseparatortitle_lnproblema_Jsonclick ;
      private string divLineseparatorcontent_lnproblema_Internalname ;
      private string divLineseparatorcontent_lnproblema_Class ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicoproblemanombre_Internalname ;
      private string edtSatisfaccionTecnicoProblemaNombre_Internalname ;
      private string edtSatisfaccionTecnicoProblemaNombre_Link ;
      private string edtSatisfaccionTecnicoProblemaNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicoproblemaid_Internalname ;
      private string edtSatisfaccionTecnicoProblemaId_Internalname ;
      private string edtSatisfaccionTecnicoProblemaId_Jsonclick ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string divLineseparator_lncapacidad_Internalname ;
      private string divLineseparatorheader_lncapacidad_Internalname ;
      private string divLineseparatorheader_lncapacidad_Class ;
      private string lblLineseparatortitle_lncapacidad_Internalname ;
      private string lblLineseparatortitle_lncapacidad_Jsonclick ;
      private string divLineseparatorcontent_lncapacidad_Internalname ;
      private string divLineseparatorcontent_lncapacidad_Class ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicocompetentenombre_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteNombre_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteNombre_Link ;
      private string edtSatisfaccionTecnicoCompetenteNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicocompetenteid_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteId_Internalname ;
      private string edtSatisfaccionTecnicoCompetenteId_Jsonclick ;
      private string imgprompt_10_Internalname ;
      private string imgprompt_10_Link ;
      private string divLineseparator_lncortesia_Internalname ;
      private string divLineseparatorheader_lncortesia_Internalname ;
      private string divLineseparatorheader_lncortesia_Class ;
      private string lblLineseparatortitle_lncortesia_Internalname ;
      private string lblLineseparatortitle_lncortesia_Jsonclick ;
      private string divLineseparatorcontent_lncortesia_Internalname ;
      private string divLineseparatorcontent_lncortesia_Class ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismonombre_Internalname ;
      private string edtSatisfaccionTecnicoProfesionalismoNombre_Internalname ;
      private string edtSatisfaccionTecnicoProfesionalismoNombre_Link ;
      private string edtSatisfaccionTecnicoProfesionalismoNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontecnicoprofesionalismoid_Internalname ;
      private string edtSatisfaccionTecnicoProfesionalismoId_Internalname ;
      private string edtSatisfaccionTecnicoProfesionalismoId_Jsonclick ;
      private string imgprompt_11_Internalname ;
      private string imgprompt_11_Link ;
      private string divLineseparator_lntiempo_Internalname ;
      private string divLineseparatorheader_lntiempo_Internalname ;
      private string divLineseparatorheader_lntiempo_Class ;
      private string lblLineseparatortitle_lntiempo_Internalname ;
      private string lblLineseparatortitle_lntiempo_Jsonclick ;
      private string divLineseparatorcontent_lntiempo_Internalname ;
      private string divLineseparatorcontent_lntiempo_Class ;
      private string divK2btoolstable_attributecontainersatisfacciontiemponombre_Internalname ;
      private string edtSatisfaccionTiempoNombre_Internalname ;
      private string edtSatisfaccionTiempoNombre_Link ;
      private string edtSatisfaccionTiempoNombre_Jsonclick ;
      private string divK2btoolstable_attributecontainersatisfacciontiempoid_Internalname ;
      private string edtSatisfaccionTiempoId_Internalname ;
      private string edtSatisfaccionTiempoId_Jsonclick ;
      private string imgprompt_12_Internalname ;
      private string imgprompt_12_Link ;
      private string divLineseparator_clatencion_Internalname ;
      private string divLineseparatorheader_clatencion_Internalname ;
      private string divLineseparatorheader_clatencion_Class ;
      private string lblLineseparatortitle_clatencion_Internalname ;
      private string lblLineseparatortitle_clatencion_Jsonclick ;
      private string divLineseparatorcontent_clatencion_Internalname ;
      private string divLineseparatorcontent_clatencion_Class ;
      private string divK2btoolstable_attributecontainersatisfaccionatencionid_Internalname ;
      private string edtSatisfaccionAtencionId_Internalname ;
      private string edtSatisfaccionAtencionId_Jsonclick ;
      private string imgprompt_13_Internalname ;
      private string imgprompt_13_Link ;
      private string divK2btoolstable_attributecontainersatisfaccionatencionnombre_Internalname ;
      private string edtSatisfaccionAtencionNombre_Internalname ;
      private string edtSatisfaccionAtencionNombre_Link ;
      private string edtSatisfaccionAtencionNombre_Jsonclick ;
      private string divLineseparator_lnsugerencia_Internalname ;
      private string divLineseparatorheader_lnsugerencia_Internalname ;
      private string divLineseparatorheader_lnsugerencia_Class ;
      private string lblLineseparatortitle_lnsugerencia_Internalname ;
      private string lblLineseparatortitle_lnsugerencia_Jsonclick ;
      private string divLineseparatorcontent_lnsugerencia_Internalname ;
      private string divLineseparatorcontent_lnsugerencia_Class ;
      private string divK2btoolstable_attributecontainersatisfaccionsugerencia_Internalname ;
      private string edtSatisfaccionSugerencia_Internalname ;
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
      private string AV40Pgmname ;
      private string K2bcontrolbeautify1_Objectcall ;
      private string K2bcontrolbeautify1_Class ;
      private string hsh ;
      private string sMode6 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23StandardActivityType ;
      private string AV20BtnCaption ;
      private string AV21BtnTooltip ;
      private string AV26encrypt ;
      private string GXt_char1 ;
      private string GXEncryptionTmp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string sCtrlGx_mode ;
      private string sCtrlAV7SatisfaccionId ;
      private DateTime Z144SatisfaccionHora ;
      private DateTime A144SatisfaccionHora ;
      private DateTime i144SatisfaccionHora ;
      private DateTime Z32SatisfaccionFecha ;
      private DateTime A32SatisfaccionFecha ;
      private DateTime A90UsuarioFecha ;
      private DateTime Z90UsuarioFecha ;
      private DateTime i32SatisfaccionFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n34SatisfaccionSugerencia ;
      private bool n359SatisfaccionMejoraSoftware ;
      private bool K2bcontrolbeautify1_Enabled ;
      private bool K2bcontrolbeautify1_Updatecheckboxes ;
      private bool K2bcontrolbeautify1_Visible ;
      private bool returnInSub ;
      private bool AV25IsAuthorized ;
      private bool Gx_longc ;
      private bool GXt_boolean2 ;
      private string Z34SatisfaccionSugerencia ;
      private string Z359SatisfaccionMejoraSoftware ;
      private string A199TicketTecnicoResponsableNombre ;
      private string A93UsuarioNombre ;
      private string A94UsuarioRequerimiento ;
      private string A33SatisfaccionResueltoNombre ;
      private string A36SatisfaccionTecnicoProblemaNombre ;
      private string A35SatisfaccionTecnicoCompetenteNombre ;
      private string A37SatisfaccionTecnicoProfesionalismoNombre ;
      private string A38SatisfaccionTiempoNombre ;
      private string A31SatisfaccionAtencionNombre ;
      private string A34SatisfaccionSugerencia ;
      private string A359SatisfaccionMejoraSoftware ;
      private string A348SatisfaccionCatalogaNombre ;
      private string A351SatisfaccionRendimientoNombre ;
      private string A354SatisfaccionProgramadorNombre ;
      private string A357SatisfaccionCapacitacionNombre ;
      private string AV24UserActivityType ;
      private string AV11DinamicObjToLink ;
      private string AV22Url ;
      private string Z348SatisfaccionCatalogaNombre ;
      private string Z351SatisfaccionRendimientoNombre ;
      private string Z354SatisfaccionProgramadorNombre ;
      private string Z357SatisfaccionCapacitacionNombre ;
      private string Z93UsuarioNombre ;
      private string Z94UsuarioRequerimiento ;
      private string Z199TicketTecnicoResponsableNombre ;
      private string Z33SatisfaccionResueltoNombre ;
      private string Z36SatisfaccionTecnicoProblemaNombre ;
      private string Z35SatisfaccionTecnicoCompetenteNombre ;
      private string Z37SatisfaccionTecnicoProfesionalismoNombre ;
      private string Z38SatisfaccionTiempoNombre ;
      private string Z31SatisfaccionAtencionNombre ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private Object[] args ;
      private IDataStoreProvider pr_default ;
      private string[] T000615_A357SatisfaccionCapacitacionNombre ;
      private short[] T000615_A358SatisfaccionCapacitacionCalificacion ;
      private string[] T000614_A354SatisfaccionProgramadorNombre ;
      private short[] T000614_A355SatisfaccionProgramadorCalificacion ;
      private string[] T000613_A351SatisfaccionRendimientoNombre ;
      private short[] T000613_A352SatisfaccionRendimientoCalificacion ;
      private string[] T000612_A348SatisfaccionCatalogaNombre ;
      private short[] T000612_A349SatisfaccionCatalogaCalificacion ;
      private string[] T000611_A31SatisfaccionAtencionNombre ;
      private short[] T000611_A279SatisfaccionAtencionCalificacion ;
      private string[] T000610_A38SatisfaccionTiempoNombre ;
      private short[] T000610_A284SatisfaccionTiempoCalificacion ;
      private string[] T00069_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] T00069_A283SatisfaccionTecnicoProfesionalismoCalificacion ;
      private string[] T00068_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] T00068_A281SatisfaccionTecnicoCompetenteCalificacion ;
      private string[] T00067_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] T00067_A282SatisfaccionTecnicoProblemaCalificacion ;
      private string[] T00066_A33SatisfaccionResueltoNombre ;
      private short[] T00066_A280SatisfaccionResueltoCalificacion ;
      private long[] T00064_A15UsuarioId ;
      private string[] T000617_A93UsuarioNombre ;
      private DateTime[] T000617_A90UsuarioFecha ;
      private string[] T000617_A94UsuarioRequerimiento ;
      private short[] T00065_A198TicketTecnicoResponsableId ;
      private string[] T000616_A199TicketTecnicoResponsableNombre ;
      private long[] T000618_A7SatisfaccionId ;
      private DateTime[] T000618_A32SatisfaccionFecha ;
      private DateTime[] T000618_A144SatisfaccionHora ;
      private string[] T000618_A199TicketTecnicoResponsableNombre ;
      private string[] T000618_A93UsuarioNombre ;
      private DateTime[] T000618_A90UsuarioFecha ;
      private string[] T000618_A94UsuarioRequerimiento ;
      private string[] T000618_A33SatisfaccionResueltoNombre ;
      private short[] T000618_A280SatisfaccionResueltoCalificacion ;
      private string[] T000618_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] T000618_A282SatisfaccionTecnicoProblemaCalificacion ;
      private string[] T000618_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] T000618_A281SatisfaccionTecnicoCompetenteCalificacion ;
      private string[] T000618_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] T000618_A283SatisfaccionTecnicoProfesionalismoCalificacion ;
      private string[] T000618_A38SatisfaccionTiempoNombre ;
      private short[] T000618_A284SatisfaccionTiempoCalificacion ;
      private string[] T000618_A31SatisfaccionAtencionNombre ;
      private short[] T000618_A279SatisfaccionAtencionCalificacion ;
      private string[] T000618_A34SatisfaccionSugerencia ;
      private bool[] T000618_n34SatisfaccionSugerencia ;
      private string[] T000618_A348SatisfaccionCatalogaNombre ;
      private short[] T000618_A349SatisfaccionCatalogaCalificacion ;
      private string[] T000618_A351SatisfaccionRendimientoNombre ;
      private short[] T000618_A352SatisfaccionRendimientoCalificacion ;
      private string[] T000618_A354SatisfaccionProgramadorNombre ;
      private short[] T000618_A355SatisfaccionProgramadorCalificacion ;
      private string[] T000618_A357SatisfaccionCapacitacionNombre ;
      private short[] T000618_A358SatisfaccionCapacitacionCalificacion ;
      private string[] T000618_A359SatisfaccionMejoraSoftware ;
      private bool[] T000618_n359SatisfaccionMejoraSoftware ;
      private long[] T000618_A14TicketId ;
      private long[] T000618_A16TicketResponsableId ;
      private short[] T000618_A8SatisfaccionResueltoId ;
      private short[] T000618_A9SatisfaccionTecnicoProblemaId ;
      private short[] T000618_A10SatisfaccionTecnicoCompetenteId ;
      private short[] T000618_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] T000618_A12SatisfaccionTiempoId ;
      private short[] T000618_A13SatisfaccionAtencionId ;
      private short[] T000618_A347SatisfaccionCatalogaId ;
      private short[] T000618_A350SatisfaccionRendimientoId ;
      private short[] T000618_A353SatisfaccionProgramadorId ;
      private short[] T000618_A356SatisfaccionCapacitacionId ;
      private short[] T000618_A198TicketTecnicoResponsableId ;
      private long[] T000618_A15UsuarioId ;
      private long[] T000619_A15UsuarioId ;
      private string[] T000620_A93UsuarioNombre ;
      private DateTime[] T000620_A90UsuarioFecha ;
      private string[] T000620_A94UsuarioRequerimiento ;
      private short[] T000621_A198TicketTecnicoResponsableId ;
      private string[] T000622_A199TicketTecnicoResponsableNombre ;
      private string[] T000623_A33SatisfaccionResueltoNombre ;
      private short[] T000623_A280SatisfaccionResueltoCalificacion ;
      private string[] T000624_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] T000624_A282SatisfaccionTecnicoProblemaCalificacion ;
      private string[] T000625_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] T000625_A281SatisfaccionTecnicoCompetenteCalificacion ;
      private string[] T000626_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] T000626_A283SatisfaccionTecnicoProfesionalismoCalificacion ;
      private string[] T000627_A38SatisfaccionTiempoNombre ;
      private short[] T000627_A284SatisfaccionTiempoCalificacion ;
      private string[] T000628_A31SatisfaccionAtencionNombre ;
      private short[] T000628_A279SatisfaccionAtencionCalificacion ;
      private string[] T000629_A348SatisfaccionCatalogaNombre ;
      private short[] T000629_A349SatisfaccionCatalogaCalificacion ;
      private string[] T000630_A351SatisfaccionRendimientoNombre ;
      private short[] T000630_A352SatisfaccionRendimientoCalificacion ;
      private string[] T000631_A354SatisfaccionProgramadorNombre ;
      private short[] T000631_A355SatisfaccionProgramadorCalificacion ;
      private string[] T000632_A357SatisfaccionCapacitacionNombre ;
      private short[] T000632_A358SatisfaccionCapacitacionCalificacion ;
      private long[] T000633_A7SatisfaccionId ;
      private long[] T00063_A7SatisfaccionId ;
      private DateTime[] T00063_A32SatisfaccionFecha ;
      private DateTime[] T00063_A144SatisfaccionHora ;
      private string[] T00063_A34SatisfaccionSugerencia ;
      private bool[] T00063_n34SatisfaccionSugerencia ;
      private string[] T00063_A359SatisfaccionMejoraSoftware ;
      private bool[] T00063_n359SatisfaccionMejoraSoftware ;
      private long[] T00063_A14TicketId ;
      private long[] T00063_A16TicketResponsableId ;
      private short[] T00063_A8SatisfaccionResueltoId ;
      private short[] T00063_A9SatisfaccionTecnicoProblemaId ;
      private short[] T00063_A10SatisfaccionTecnicoCompetenteId ;
      private short[] T00063_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] T00063_A12SatisfaccionTiempoId ;
      private short[] T00063_A13SatisfaccionAtencionId ;
      private short[] T00063_A347SatisfaccionCatalogaId ;
      private short[] T00063_A350SatisfaccionRendimientoId ;
      private short[] T00063_A353SatisfaccionProgramadorId ;
      private short[] T00063_A356SatisfaccionCapacitacionId ;
      private long[] T000634_A7SatisfaccionId ;
      private long[] T000635_A7SatisfaccionId ;
      private long[] T00062_A7SatisfaccionId ;
      private DateTime[] T00062_A32SatisfaccionFecha ;
      private DateTime[] T00062_A144SatisfaccionHora ;
      private string[] T00062_A34SatisfaccionSugerencia ;
      private bool[] T00062_n34SatisfaccionSugerencia ;
      private string[] T00062_A359SatisfaccionMejoraSoftware ;
      private bool[] T00062_n359SatisfaccionMejoraSoftware ;
      private long[] T00062_A14TicketId ;
      private long[] T00062_A16TicketResponsableId ;
      private short[] T00062_A8SatisfaccionResueltoId ;
      private short[] T00062_A9SatisfaccionTecnicoProblemaId ;
      private short[] T00062_A10SatisfaccionTecnicoCompetenteId ;
      private short[] T00062_A11SatisfaccionTecnicoProfesionalismoId ;
      private short[] T00062_A12SatisfaccionTiempoId ;
      private short[] T00062_A13SatisfaccionAtencionId ;
      private short[] T00062_A347SatisfaccionCatalogaId ;
      private short[] T00062_A350SatisfaccionRendimientoId ;
      private short[] T00062_A353SatisfaccionProgramadorId ;
      private short[] T00062_A356SatisfaccionCapacitacionId ;
      private long[] T000639_A15UsuarioId ;
      private string[] T000640_A93UsuarioNombre ;
      private DateTime[] T000640_A90UsuarioFecha ;
      private string[] T000640_A94UsuarioRequerimiento ;
      private short[] T000641_A198TicketTecnicoResponsableId ;
      private string[] T000642_A199TicketTecnicoResponsableNombre ;
      private string[] T000643_A33SatisfaccionResueltoNombre ;
      private short[] T000643_A280SatisfaccionResueltoCalificacion ;
      private string[] T000644_A36SatisfaccionTecnicoProblemaNombre ;
      private short[] T000644_A282SatisfaccionTecnicoProblemaCalificacion ;
      private string[] T000645_A35SatisfaccionTecnicoCompetenteNombre ;
      private short[] T000645_A281SatisfaccionTecnicoCompetenteCalificacion ;
      private string[] T000646_A37SatisfaccionTecnicoProfesionalismoNombre ;
      private short[] T000646_A283SatisfaccionTecnicoProfesionalismoCalificacion ;
      private string[] T000647_A38SatisfaccionTiempoNombre ;
      private short[] T000647_A284SatisfaccionTiempoCalificacion ;
      private string[] T000648_A31SatisfaccionAtencionNombre ;
      private short[] T000648_A279SatisfaccionAtencionCalificacion ;
      private string[] T000649_A348SatisfaccionCatalogaNombre ;
      private short[] T000649_A349SatisfaccionCatalogaCalificacion ;
      private string[] T000650_A351SatisfaccionRendimientoNombre ;
      private short[] T000650_A352SatisfaccionRendimientoCalificacion ;
      private string[] T000651_A354SatisfaccionProgramadorNombre ;
      private short[] T000651_A355SatisfaccionProgramadorCalificacion ;
      private string[] T000652_A357SatisfaccionCapacitacionNombre ;
      private short[] T000652_A358SatisfaccionCapacitacionCalificacion ;
      private long[] T000653_A7SatisfaccionId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<SdtK2BAttributeValue_Item> AV27AttributeValue ;
      private SdtK2BTrnContext AV8TrnContext ;
      private SdtK2BTrnContext_Attribute AV9TrnContextAtt ;
      private SdtK2BTrnNavigation AV10Navigation ;
      private SdtK2BContext AV19Context ;
      private SdtK2BAttributeValue_Item AV28AttributeValueItem ;
      private GeneXus.Utils.SdtMessages_Message AV29Message ;
   }

   public class satisfaccion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class satisfaccion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class satisfaccion__gam : DataStoreHelperBase, IDataStoreHelper
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

public class satisfaccion__default : DataStoreHelperBase, IDataStoreHelper
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
      ,new ForEachCursor(def[16])
      ,new ForEachCursor(def[17])
      ,new ForEachCursor(def[18])
      ,new ForEachCursor(def[19])
      ,new ForEachCursor(def[20])
      ,new ForEachCursor(def[21])
      ,new ForEachCursor(def[22])
      ,new ForEachCursor(def[23])
      ,new ForEachCursor(def[24])
      ,new ForEachCursor(def[25])
      ,new ForEachCursor(def[26])
      ,new ForEachCursor(def[27])
      ,new ForEachCursor(def[28])
      ,new ForEachCursor(def[29])
      ,new ForEachCursor(def[30])
      ,new ForEachCursor(def[31])
      ,new ForEachCursor(def[32])
      ,new ForEachCursor(def[33])
      ,new UpdateCursor(def[34])
      ,new UpdateCursor(def[35])
      ,new UpdateCursor(def[36])
      ,new ForEachCursor(def[37])
      ,new ForEachCursor(def[38])
      ,new ForEachCursor(def[39])
      ,new ForEachCursor(def[40])
      ,new ForEachCursor(def[41])
      ,new ForEachCursor(def[42])
      ,new ForEachCursor(def[43])
      ,new ForEachCursor(def[44])
      ,new ForEachCursor(def[45])
      ,new ForEachCursor(def[46])
      ,new ForEachCursor(def[47])
      ,new ForEachCursor(def[48])
      ,new ForEachCursor(def[49])
      ,new ForEachCursor(def[50])
      ,new ForEachCursor(def[51])
    };
 }

 private static CursorDef[] def;
 private void cursorDefinitions( )
 {
    if ( def == null )
    {
       Object[] prmT000618;
       prmT000618 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       string cmdBufferT000618;
       cmdBufferT000618=" SELECT TM1.[SatisfaccionId], TM1.[SatisfaccionFecha], TM1.[SatisfaccionHora], T9.[ResponsableNombre] AS TicketTecnicoResponsableNombre, T7.[UsuarioNombre], T7.[UsuarioFecha], T7.[UsuarioRequerimiento], T10.[EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, T10.[EstadoSatisfaccionCalificacion] AS SatisfaccionResueltoCalificacion, T11.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, T11.[EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProblemaCalificacion, T12.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, T12.[EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoCompetenteCalificacion, T13.[EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, T13.[EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProfesionalismoCalificacion, T14.[EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, T14.[EstadoSatisfaccionCalificacion] AS SatisfaccionTiempoCalificacion, T15.[EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, T15.[EstadoSatisfaccionCalificacion] AS SatisfaccionAtencionCalificacion, TM1.[SatisfaccionSugerencia], T2.[EstadoSatisfaccionNombre] AS SatisfaccionCatalogaNombre, T2.[EstadoSatisfaccionCalificacion] AS SatisfaccionCatalogaCalificacion, T3.[EstadoSatisfaccionNombre] AS SatisfaccionRendimientoNombre, T3.[EstadoSatisfaccionCalificacion] AS SatisfaccionRendimientoCalificacion, T4.[EstadoSatisfaccionNombre] AS SatisfaccionProgramadorNombre, T4.[EstadoSatisfaccionCalificacion] AS SatisfaccionProgramadorCalificacion, T5.[EstadoSatisfaccionNombre] AS SatisfaccionCapacitacionNombre, T5.[EstadoSatisfaccionCalificacion] AS SatisfaccionCapacitacionCalificacion, TM1.[SatisfaccionMejoraSoftware], TM1.[TicketId], TM1.[TicketResponsableId], TM1.[SatisfaccionResueltoId] AS SatisfaccionResueltoId, TM1.[SatisfaccionTecnicoProblemaId] "
       + " AS SatisfaccionTecnicoProblemaId, TM1.[SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, TM1.[SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, TM1.[SatisfaccionTiempoId] AS SatisfaccionTiempoId, TM1.[SatisfaccionAtencionId] AS SatisfaccionAtencionId, TM1.[SatisfaccionCatalogaId] AS SatisfaccionCatalogaId, TM1.[SatisfaccionRendimientoId] AS SatisfaccionRendimientoId, TM1.[SatisfaccionProgramadorId] AS SatisfaccionProgramadorId, TM1.[SatisfaccionCapacitacionId] AS SatisfaccionCapacitacionId, T8.[TicketTecnicoResponsableId] AS TicketTecnicoResponsableId, T6.[UsuarioId] FROM (((((((((((((([Satisfaccion] TM1 INNER JOIN [EstadoSatisfaccion] T2 ON T2.[EstadoSatisfaccionId] = TM1.[SatisfaccionCatalogaId]) INNER JOIN [EstadoSatisfaccion] T3 ON T3.[EstadoSatisfaccionId] = TM1.[SatisfaccionRendimientoId]) INNER JOIN [EstadoSatisfaccion] T4 ON T4.[EstadoSatisfaccionId] = TM1.[SatisfaccionProgramadorId]) INNER JOIN [EstadoSatisfaccion] T5 ON T5.[EstadoSatisfaccionId] = TM1.[SatisfaccionCapacitacionId]) INNER JOIN [Ticket] T6 ON T6.[TicketId] = TM1.[TicketId]) INNER JOIN [Usuario] T7 ON T7.[UsuarioId] = T6.[UsuarioId]) INNER JOIN [TicketResponsable] T8 ON T8.[TicketId] = TM1.[TicketId] AND T8.[TicketResponsableId] = TM1.[TicketResponsableId]) INNER JOIN [Responsable] T9 ON T9.[ResponsableId] = T8.[TicketTecnicoResponsableId]) INNER JOIN [EstadoSatisfaccion] T10 ON T10.[EstadoSatisfaccionId] = TM1.[SatisfaccionResueltoId]) INNER JOIN [EstadoSatisfaccion] T11 ON T11.[EstadoSatisfaccionId] = TM1.[SatisfaccionTecnicoProblemaId]) INNER JOIN [EstadoSatisfaccion] T12 ON T12.[EstadoSatisfaccionId] = TM1.[SatisfaccionTecnicoCompetenteId]) INNER JOIN [EstadoSatisfaccion] T13 ON T13.[EstadoSatisfaccionId] = TM1.[SatisfaccionTecnicoProfesionalismoId])"
       + " INNER JOIN [EstadoSatisfaccion] T14 ON T14.[EstadoSatisfaccionId] = TM1.[SatisfaccionTiempoId]) INNER JOIN [EstadoSatisfaccion] T15 ON T15.[EstadoSatisfaccionId] = TM1.[SatisfaccionAtencionId]) WHERE TM1.[SatisfaccionId] = @SatisfaccionId ORDER BY TM1.[SatisfaccionId]  OPTION (FAST 100)" ;
       Object[] prmT00064;
       prmT00064 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000617;
       prmT000617 = new Object[] {
       new ParDef("@UsuarioId",GXType.Decimal,10,0)
       };
       Object[] prmT00065;
       prmT00065 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000616;
       prmT000616 = new Object[] {
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT00066;
       prmT00066 = new Object[] {
       new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0)
       };
       Object[] prmT00067;
       prmT00067 = new Object[] {
       new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0)
       };
       Object[] prmT00068;
       prmT00068 = new Object[] {
       new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0)
       };
       Object[] prmT00069;
       prmT00069 = new Object[] {
       new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0)
       };
       Object[] prmT000610;
       prmT000610 = new Object[] {
       new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0)
       };
       Object[] prmT000611;
       prmT000611 = new Object[] {
       new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000612;
       prmT000612 = new Object[] {
       new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0)
       };
       Object[] prmT000613;
       prmT000613 = new Object[] {
       new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000614;
       prmT000614 = new Object[] {
       new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0)
       };
       Object[] prmT000615;
       prmT000615 = new Object[] {
       new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0)
       };
       Object[] prmT000619;
       prmT000619 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000620;
       prmT000620 = new Object[] {
       new ParDef("@UsuarioId",GXType.Decimal,10,0)
       };
       Object[] prmT000621;
       prmT000621 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000622;
       prmT000622 = new Object[] {
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000623;
       prmT000623 = new Object[] {
       new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0)
       };
       Object[] prmT000624;
       prmT000624 = new Object[] {
       new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0)
       };
       Object[] prmT000625;
       prmT000625 = new Object[] {
       new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0)
       };
       Object[] prmT000626;
       prmT000626 = new Object[] {
       new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0)
       };
       Object[] prmT000627;
       prmT000627 = new Object[] {
       new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0)
       };
       Object[] prmT000628;
       prmT000628 = new Object[] {
       new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0)
       };
       Object[] prmT000629;
       prmT000629 = new Object[] {
       new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0)
       };
       Object[] prmT000630;
       prmT000630 = new Object[] {
       new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000631;
       prmT000631 = new Object[] {
       new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0)
       };
       Object[] prmT000632;
       prmT000632 = new Object[] {
       new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0)
       };
       Object[] prmT000633;
       prmT000633 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT00063;
       prmT00063 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT000634;
       prmT000634 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT000635;
       prmT000635 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT00062;
       prmT00062 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT000636;
       prmT000636 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0) ,
       new ParDef("@SatisfaccionFecha",GXType.Date,8,0) ,
       new ParDef("@SatisfaccionHora",GXType.DateTime,0,5) ,
       new ParDef("@SatisfaccionSugerencia",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@SatisfaccionMejoraSoftware",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
       new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0)
       };
       Object[] prmT000637;
       prmT000637 = new Object[] {
       new ParDef("@SatisfaccionFecha",GXType.Date,8,0) ,
       new ParDef("@SatisfaccionHora",GXType.DateTime,0,5) ,
       new ParDef("@SatisfaccionSugerencia",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@SatisfaccionMejoraSoftware",GXType.NVarChar,300,0){Nullable=true} ,
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0) ,
       new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0) ,
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT000638;
       prmT000638 = new Object[] {
       new ParDef("@SatisfaccionId",GXType.Decimal,10,0)
       };
       Object[] prmT000649;
       prmT000649 = new Object[] {
       new ParDef("@SatisfaccionCatalogaId",GXType.Int16,4,0)
       };
       Object[] prmT000650;
       prmT000650 = new Object[] {
       new ParDef("@SatisfaccionRendimientoId",GXType.Int16,4,0)
       };
       Object[] prmT000651;
       prmT000651 = new Object[] {
       new ParDef("@SatisfaccionProgramadorId",GXType.Int16,4,0)
       };
       Object[] prmT000652;
       prmT000652 = new Object[] {
       new ParDef("@SatisfaccionCapacitacionId",GXType.Int16,4,0)
       };
       Object[] prmT000653;
       prmT000653 = new Object[] {
       };
       Object[] prmT000639;
       prmT000639 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0)
       };
       Object[] prmT000640;
       prmT000640 = new Object[] {
       new ParDef("@UsuarioId",GXType.Decimal,10,0)
       };
       Object[] prmT000641;
       prmT000641 = new Object[] {
       new ParDef("@TicketId",GXType.Decimal,10,0) ,
       new ParDef("@TicketResponsableId",GXType.Decimal,10,0)
       };
       Object[] prmT000642;
       prmT000642 = new Object[] {
       new ParDef("@TicketTecnicoResponsableId",GXType.Int16,4,0)
       };
       Object[] prmT000643;
       prmT000643 = new Object[] {
       new ParDef("@SatisfaccionResueltoId",GXType.Int16,4,0)
       };
       Object[] prmT000644;
       prmT000644 = new Object[] {
       new ParDef("@SatisfaccionTecnicoProblemaId",GXType.Int16,4,0)
       };
       Object[] prmT000645;
       prmT000645 = new Object[] {
       new ParDef("@SatisfaccionTecnicoCompetenteId",GXType.Int16,4,0)
       };
       Object[] prmT000646;
       prmT000646 = new Object[] {
       new ParDef("@SatisfaccionTecnicoProfesionalismoId",GXType.Int16,4,0)
       };
       Object[] prmT000647;
       prmT000647 = new Object[] {
       new ParDef("@SatisfaccionTiempoId",GXType.Int16,4,0)
       };
       Object[] prmT000648;
       prmT000648 = new Object[] {
       new ParDef("@SatisfaccionAtencionId",GXType.Int16,4,0)
       };
       def= new CursorDef[] {
           new CursorDef("T00062", "SELECT [SatisfaccionId], [SatisfaccionFecha], [SatisfaccionHora], [SatisfaccionSugerencia], [SatisfaccionMejoraSoftware], [TicketId], [TicketResponsableId], [SatisfaccionResueltoId] AS SatisfaccionResueltoId, [SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, [SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, [SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, [SatisfaccionTiempoId] AS SatisfaccionTiempoId, [SatisfaccionAtencionId] AS SatisfaccionAtencionId, [SatisfaccionCatalogaId] AS SatisfaccionCatalogaId, [SatisfaccionRendimientoId] AS SatisfaccionRendimientoId, [SatisfaccionProgramadorId] AS SatisfaccionProgramadorId, [SatisfaccionCapacitacionId] AS SatisfaccionCapacitacionId FROM [Satisfaccion] WITH (UPDLOCK) WHERE [SatisfaccionId] = @SatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00063", "SELECT [SatisfaccionId], [SatisfaccionFecha], [SatisfaccionHora], [SatisfaccionSugerencia], [SatisfaccionMejoraSoftware], [TicketId], [TicketResponsableId], [SatisfaccionResueltoId] AS SatisfaccionResueltoId, [SatisfaccionTecnicoProblemaId] AS SatisfaccionTecnicoProblemaId, [SatisfaccionTecnicoCompetenteId] AS SatisfaccionTecnicoCompetenteId, [SatisfaccionTecnicoProfesionalismoId] AS SatisfaccionTecnicoProfesionalismoId, [SatisfaccionTiempoId] AS SatisfaccionTiempoId, [SatisfaccionAtencionId] AS SatisfaccionAtencionId, [SatisfaccionCatalogaId] AS SatisfaccionCatalogaId, [SatisfaccionRendimientoId] AS SatisfaccionRendimientoId, [SatisfaccionProgramadorId] AS SatisfaccionProgramadorId, [SatisfaccionCapacitacionId] AS SatisfaccionCapacitacionId FROM [Satisfaccion] WHERE [SatisfaccionId] = @SatisfaccionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00064", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00065", "SELECT [TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00066", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionResueltoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionResueltoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00067", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProblemaCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoProblemaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00068", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoCompetenteCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoCompetenteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T00069", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProfesionalismoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoProfesionalismoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000610", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTiempoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTiempoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000611", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionAtencionCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000612", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionCatalogaNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionCatalogaCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionCatalogaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000613", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionRendimientoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionRendimientoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionRendimientoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000614", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionProgramadorNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionProgramadorCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionProgramadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000615", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionCapacitacionNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionCapacitacionCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionCapacitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000616", "SELECT [ResponsableNombre] AS TicketTecnicoResponsableNombre FROM [Responsable] WHERE [ResponsableId] = @TicketTecnicoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000617", "SELECT [UsuarioNombre], [UsuarioFecha], [UsuarioRequerimiento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000618", cmdBufferT000618,true, GxErrorMask.GX_NOMASK, false, this,prmT000618,100, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000619", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000620", "SELECT [UsuarioNombre], [UsuarioFecha], [UsuarioRequerimiento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000620,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000621", "SELECT [TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000621,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000622", "SELECT [ResponsableNombre] AS TicketTecnicoResponsableNombre FROM [Responsable] WHERE [ResponsableId] = @TicketTecnicoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000622,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000623", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionResueltoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionResueltoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000623,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000624", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProblemaCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoProblemaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000624,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000625", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoCompetenteCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoCompetenteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000626", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProfesionalismoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoProfesionalismoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000627", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTiempoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTiempoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000628", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionAtencionCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000628,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000629", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionCatalogaNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionCatalogaCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionCatalogaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000629,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000630", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionRendimientoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionRendimientoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionRendimientoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000630,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000631", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionProgramadorNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionProgramadorCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionProgramadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000631,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000632", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionCapacitacionNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionCapacitacionCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionCapacitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000632,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000633", "SELECT [SatisfaccionId] FROM [Satisfaccion] WHERE [SatisfaccionId] = @SatisfaccionId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000633,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000634", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE ( [SatisfaccionId] > @SatisfaccionId) ORDER BY [SatisfaccionId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000634,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000635", "SELECT TOP 1 [SatisfaccionId] FROM [Satisfaccion] WHERE ( [SatisfaccionId] < @SatisfaccionId) ORDER BY [SatisfaccionId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000635,1, GxCacheFrequency.OFF ,true,true )
          ,new CursorDef("T000636", "INSERT INTO [Satisfaccion]([SatisfaccionId], [SatisfaccionFecha], [SatisfaccionHora], [SatisfaccionSugerencia], [SatisfaccionMejoraSoftware], [TicketId], [TicketResponsableId], [SatisfaccionResueltoId], [SatisfaccionTecnicoProblemaId], [SatisfaccionTecnicoCompetenteId], [SatisfaccionTecnicoProfesionalismoId], [SatisfaccionTiempoId], [SatisfaccionAtencionId], [SatisfaccionCatalogaId], [SatisfaccionRendimientoId], [SatisfaccionProgramadorId], [SatisfaccionCapacitacionId]) VALUES(@SatisfaccionId, @SatisfaccionFecha, @SatisfaccionHora, @SatisfaccionSugerencia, @SatisfaccionMejoraSoftware, @TicketId, @TicketResponsableId, @SatisfaccionResueltoId, @SatisfaccionTecnicoProblemaId, @SatisfaccionTecnicoCompetenteId, @SatisfaccionTecnicoProfesionalismoId, @SatisfaccionTiempoId, @SatisfaccionAtencionId, @SatisfaccionCatalogaId, @SatisfaccionRendimientoId, @SatisfaccionProgramadorId, @SatisfaccionCapacitacionId)", GxErrorMask.GX_NOMASK,prmT000636)
          ,new CursorDef("T000637", "UPDATE [Satisfaccion] SET [SatisfaccionFecha]=@SatisfaccionFecha, [SatisfaccionHora]=@SatisfaccionHora, [SatisfaccionSugerencia]=@SatisfaccionSugerencia, [SatisfaccionMejoraSoftware]=@SatisfaccionMejoraSoftware, [TicketId]=@TicketId, [TicketResponsableId]=@TicketResponsableId, [SatisfaccionResueltoId]=@SatisfaccionResueltoId, [SatisfaccionTecnicoProblemaId]=@SatisfaccionTecnicoProblemaId, [SatisfaccionTecnicoCompetenteId]=@SatisfaccionTecnicoCompetenteId, [SatisfaccionTecnicoProfesionalismoId]=@SatisfaccionTecnicoProfesionalismoId, [SatisfaccionTiempoId]=@SatisfaccionTiempoId, [SatisfaccionAtencionId]=@SatisfaccionAtencionId, [SatisfaccionCatalogaId]=@SatisfaccionCatalogaId, [SatisfaccionRendimientoId]=@SatisfaccionRendimientoId, [SatisfaccionProgramadorId]=@SatisfaccionProgramadorId, [SatisfaccionCapacitacionId]=@SatisfaccionCapacitacionId  WHERE [SatisfaccionId] = @SatisfaccionId", GxErrorMask.GX_NOMASK,prmT000637)
          ,new CursorDef("T000638", "DELETE FROM [Satisfaccion]  WHERE [SatisfaccionId] = @SatisfaccionId", GxErrorMask.GX_NOMASK,prmT000638)
          ,new CursorDef("T000639", "SELECT [UsuarioId] FROM [Ticket] WHERE [TicketId] = @TicketId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000639,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000640", "SELECT [UsuarioNombre], [UsuarioFecha], [UsuarioRequerimiento] FROM [Usuario] WHERE [UsuarioId] = @UsuarioId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000640,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000641", "SELECT [TicketTecnicoResponsableId] AS TicketTecnicoResponsableId FROM [TicketResponsable] WHERE [TicketId] = @TicketId AND [TicketResponsableId] = @TicketResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000641,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000642", "SELECT [ResponsableNombre] AS TicketTecnicoResponsableNombre FROM [Responsable] WHERE [ResponsableId] = @TicketTecnicoResponsableId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000642,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000643", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionResueltoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionResueltoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionResueltoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000643,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000644", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProblemaNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProblemaCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoProblemaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000644,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000645", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoCompetenteNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoCompetenteCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoCompetenteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000645,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000646", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTecnicoProfesionalismoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTecnicoProfesionalismoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTecnicoProfesionalismoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000646,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000647", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionTiempoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionTiempoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionTiempoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000647,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000648", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionAtencionNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionAtencionCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionAtencionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000648,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000649", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionCatalogaNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionCatalogaCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionCatalogaId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000649,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000650", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionRendimientoNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionRendimientoCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionRendimientoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000650,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000651", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionProgramadorNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionProgramadorCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionProgramadorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000651,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000652", "SELECT [EstadoSatisfaccionNombre] AS SatisfaccionCapacitacionNombre, [EstadoSatisfaccionCalificacion] AS SatisfaccionCapacitacionCalificacion FROM [EstadoSatisfaccion] WHERE [EstadoSatisfaccionId] = @SatisfaccionCapacitacionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000652,1, GxCacheFrequency.OFF ,true,false )
          ,new CursorDef("T000653", "SELECT [SatisfaccionId] FROM [Satisfaccion] ORDER BY [SatisfaccionId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000653,100, GxCacheFrequency.OFF ,true,false )
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
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((long[]) buf[7])[0] = rslt.getLong(6);
             ((long[]) buf[8])[0] = rslt.getLong(7);
             ((short[]) buf[9])[0] = rslt.getShort(8);
             ((short[]) buf[10])[0] = rslt.getShort(9);
             ((short[]) buf[11])[0] = rslt.getShort(10);
             ((short[]) buf[12])[0] = rslt.getShort(11);
             ((short[]) buf[13])[0] = rslt.getShort(12);
             ((short[]) buf[14])[0] = rslt.getShort(13);
             ((short[]) buf[15])[0] = rslt.getShort(14);
             ((short[]) buf[16])[0] = rslt.getShort(15);
             ((short[]) buf[17])[0] = rslt.getShort(16);
             ((short[]) buf[18])[0] = rslt.getShort(17);
             return;
          case 1 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((bool[]) buf[4])[0] = rslt.wasNull(4);
             ((string[]) buf[5])[0] = rslt.getVarchar(5);
             ((bool[]) buf[6])[0] = rslt.wasNull(5);
             ((long[]) buf[7])[0] = rslt.getLong(6);
             ((long[]) buf[8])[0] = rslt.getLong(7);
             ((short[]) buf[9])[0] = rslt.getShort(8);
             ((short[]) buf[10])[0] = rslt.getShort(9);
             ((short[]) buf[11])[0] = rslt.getShort(10);
             ((short[]) buf[12])[0] = rslt.getShort(11);
             ((short[]) buf[13])[0] = rslt.getShort(12);
             ((short[]) buf[14])[0] = rslt.getShort(13);
             ((short[]) buf[15])[0] = rslt.getShort(14);
             ((short[]) buf[16])[0] = rslt.getShort(15);
             ((short[]) buf[17])[0] = rslt.getShort(16);
             ((short[]) buf[18])[0] = rslt.getShort(17);
             return;
          case 2 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 3 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 4 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 5 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 6 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 7 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 8 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 9 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 10 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 11 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 12 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 13 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 14 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 15 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 16 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
             ((string[]) buf[3])[0] = rslt.getVarchar(4);
             ((string[]) buf[4])[0] = rslt.getVarchar(5);
             ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
             ((string[]) buf[6])[0] = rslt.getVarchar(7);
             ((string[]) buf[7])[0] = rslt.getVarchar(8);
             ((short[]) buf[8])[0] = rslt.getShort(9);
             ((string[]) buf[9])[0] = rslt.getVarchar(10);
             ((short[]) buf[10])[0] = rslt.getShort(11);
             ((string[]) buf[11])[0] = rslt.getVarchar(12);
             ((short[]) buf[12])[0] = rslt.getShort(13);
             ((string[]) buf[13])[0] = rslt.getVarchar(14);
             ((short[]) buf[14])[0] = rslt.getShort(15);
             ((string[]) buf[15])[0] = rslt.getVarchar(16);
             ((short[]) buf[16])[0] = rslt.getShort(17);
             ((string[]) buf[17])[0] = rslt.getVarchar(18);
             ((short[]) buf[18])[0] = rslt.getShort(19);
             ((string[]) buf[19])[0] = rslt.getVarchar(20);
             ((bool[]) buf[20])[0] = rslt.wasNull(20);
             ((string[]) buf[21])[0] = rslt.getVarchar(21);
             ((short[]) buf[22])[0] = rslt.getShort(22);
             ((string[]) buf[23])[0] = rslt.getVarchar(23);
             ((short[]) buf[24])[0] = rslt.getShort(24);
             ((string[]) buf[25])[0] = rslt.getVarchar(25);
             ((short[]) buf[26])[0] = rslt.getShort(26);
             ((string[]) buf[27])[0] = rslt.getVarchar(27);
             ((short[]) buf[28])[0] = rslt.getShort(28);
             ((string[]) buf[29])[0] = rslt.getVarchar(29);
             ((bool[]) buf[30])[0] = rslt.wasNull(29);
             ((long[]) buf[31])[0] = rslt.getLong(30);
             ((long[]) buf[32])[0] = rslt.getLong(31);
             ((short[]) buf[33])[0] = rslt.getShort(32);
             ((short[]) buf[34])[0] = rslt.getShort(33);
             ((short[]) buf[35])[0] = rslt.getShort(34);
             ((short[]) buf[36])[0] = rslt.getShort(35);
             ((short[]) buf[37])[0] = rslt.getShort(36);
             ((short[]) buf[38])[0] = rslt.getShort(37);
             ((short[]) buf[39])[0] = rslt.getShort(38);
             ((short[]) buf[40])[0] = rslt.getShort(39);
             ((short[]) buf[41])[0] = rslt.getShort(40);
             ((short[]) buf[42])[0] = rslt.getShort(41);
             ((short[]) buf[43])[0] = rslt.getShort(42);
             ((long[]) buf[44])[0] = rslt.getLong(43);
             return;
          case 17 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 18 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 19 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 20 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 21 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 22 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 23 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 24 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 25 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 26 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 27 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 28 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 29 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
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
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 31 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 32 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 33 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 37 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
          case 38 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
             ((string[]) buf[2])[0] = rslt.getVarchar(3);
             return;
          case 39 :
             ((short[]) buf[0])[0] = rslt.getShort(1);
             return;
          case 40 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             return;
          case 41 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 42 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 43 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 44 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 45 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 46 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 47 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 48 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 49 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 50 :
             ((string[]) buf[0])[0] = rslt.getVarchar(1);
             ((short[]) buf[1])[0] = rslt.getShort(2);
             return;
          case 51 :
             ((long[]) buf[0])[0] = rslt.getLong(1);
             return;
    }
 }

}

}
