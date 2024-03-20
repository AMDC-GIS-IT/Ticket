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
namespace GeneXus.Programs.k2bfsg {
   public class roleselectpermission : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public roleselectpermission( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("K2BOrion");
         }
      }

      public roleselectpermission( IGxContext context )
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

      public void execute( ref long aP0_RoleId )
      {
         this.AV6RoleId = aP0_RoleId;
         executePrivate();
         aP0_RoleId=this.AV6RoleId;
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
         cmbavApplicationid = new GXCombobox();
         cmbavGridsettingsrowsperpage_activepermissions = new GXCombobox();
         chkavFreezecolumntitles_activepermissions = new GXCheckbox();
         chkavCheckall_activepermissions = new GXCheckbox();
         chkavMultirowitemselected_activepermissions = new GXCheckbox();
         cmbavAccesstype = new GXCombobox();
         chkavIsinherited = new GXCheckbox();
         cmbavStoredaccesstype = new GXCombobox();
         chkavStoredisinherited = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "RoleId");
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
                  AV6RoleId = (long)(NumberUtil.Val( GetPar( "RoleId"), "."));
                  AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV6RoleId});
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
                  gxfirstwebparm = GetFirstPar( "RoleId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "RoleId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Activepermissions") == 0 )
               {
                  nRC_GXsfl_127 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_127"), "."));
                  nGXsfl_127_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_127_idx"), "."));
                  sGXsfl_127_idx = GetPar( "sGXsfl_127_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrActivepermissions_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Activepermissions") == 0 )
               {
                  AV6RoleId = (long)(NumberUtil.Val( GetPar( "RoleId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV85ClassCollection_ActivePermissions);
                  AV75ApplicationId_PreviousValue = (long)(NumberUtil.Val( GetPar( "ApplicationId_PreviousValue"), "."));
                  cmbavApplicationid.FromJSonString( GetNextPar( ));
                  AV14ApplicationId = (long)(NumberUtil.Val( GetPar( "ApplicationId"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV66AllSelectedItems_ActivePermissions);
                  AV97Pgmname = GetPar( "Pgmname");
                  AV15CurrentPage_ActivePermissions = (short)(NumberUtil.Val( GetPar( "CurrentPage_ActivePermissions"), "."));
                  AV83GenericFilter_ActivePermissions = GetPar( "GenericFilter_ActivePermissions");
                  AV77CountSelectedItems_ActivePermissions = (short)(NumberUtil.Val( GetPar( "CountSelectedItems_ActivePermissions"), "."));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV84GridConfiguration);
                  AV32HasNextPage_ActivePermissions = StringUtil.StrToBool( GetPar( "HasNextPage_ActivePermissions"));
                  AV61RowsPerPage_ActivePermissions = (short)(NumberUtil.Val( GetPar( "RowsPerPage_ActivePermissions"), "."));
                  AV37Id = GetPar( "Id");
                  AV9ActivePermissions_SelectedRows = (short)(NumberUtil.Val( GetPar( "ActivePermissions_SelectedRows"), "."));
                  AV35I_LoadCount_ActivePermissions = (short)(NumberUtil.Val( GetPar( "I_LoadCount_ActivePermissions"), "."));
                  AV91FreezeColumnTitles_ActivePermissions = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_ActivePermissions"));
                  AV63CheckAll_ActivePermissions = StringUtil.StrToBool( GetPar( "CheckAll_ActivePermissions"));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrActivepermissions_refresh( AV6RoleId, AV85ClassCollection_ActivePermissions, AV75ApplicationId_PreviousValue, AV14ApplicationId, AV66AllSelectedItems_ActivePermissions, AV97Pgmname, AV15CurrentPage_ActivePermissions, AV83GenericFilter_ActivePermissions, AV77CountSelectedItems_ActivePermissions, AV84GridConfiguration, AV32HasNextPage_ActivePermissions, AV61RowsPerPage_ActivePermissions, AV37Id, AV9ActivePermissions_SelectedRows, AV35I_LoadCount_ActivePermissions, AV91FreezeColumnTitles_ActivePermissions, AV63CheckAll_ActivePermissions, sPrefix) ;
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertableactivepermissions_Visible), 5, 0, ".", "")));
                  GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0, ".", "")));
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_activepermissions_Visible), 5, 0, ".", "")));
                  GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0, ".", "")));
                  GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_activepermissions_Visible), 5, 0, ".", "")));
                  AddString( context.getJSONResponse( )) ;
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
                  AV6RoleId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
                  AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 12, 0));
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
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
            return "k2bsecurity_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA442( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV97Pgmname = "K2BFSG.RoleSelectPermission";
               context.Gx_err = 0;
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_127_Refreshing);
               edtavDsc_Enabled = 0;
               AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_127_Refreshing);
               cmbavAccesstype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
               chkavIsinherited.Enabled = 0;
               AssignProp(sPrefix, false, chkavIsinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
               cmbavStoredaccesstype.Enabled = 0;
               AssignProp(sPrefix, false, cmbavStoredaccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavStoredaccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
               chkavStoredisinherited.Enabled = 0;
               AssignProp(sPrefix, false, chkavStoredisinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavStoredisinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
               edtavId_Enabled = 0;
               AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_127_Refreshing);
               WS442( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     WE442( ) ;
                  }
               }
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
            context.SendWebValue( "Seleccionar permisos de rol") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2023124949193", false, true);
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
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.roleselectpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6RoleId,12,0))}, new string[] {"RoleId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV35I_LoadCount_ActivePermissions), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, AV32HasNextPage_ActivePermissions, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_127", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_127), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6RoleId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_ACTIVEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15CurrentPage_ActivePermissions), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_ACTIVEPERMISSIONS", AV85ClassCollection_ActivePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_ACTIVEPERMISSIONS", AV85ClassCollection_ActivePermissions);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6RoleId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vGRIDCONFIGURATION", AV84GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vGRIDCONFIGURATION", AV84GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV77CountSelectedItems_ActivePermissions), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLSELECTEDITEMS_ACTIVEPERMISSIONS", AV66AllSelectedItems_ActivePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLSELECTEDITEMS_ACTIVEPERMISSIONS", AV66AllSelectedItems_ActivePermissions);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vROWSPERPAGE_ACTIVEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV61RowsPerPage_ActivePermissions), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vACTIVEPERMISSIONS_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV9ActivePermissions_SelectedRows), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_ACTIVEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35I_LoadCount_ActivePermissions), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV35I_LoadCount_ActivePermissions), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_ACTIVEPERMISSIONS", AV32HasNextPage_ActivePermissions);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, AV32HasNextPage_ActivePermissions, context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vMULTIROWHASNEXT_ACTIVEPERMISSIONS", AV45MultiRowHasNext_ActivePermissions);
         GxWebStd.gx_hidden_field( context, sPrefix+"vMULTIROWITERATOR_ACTIVEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47MultiRowIterator_ActivePermissions), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDITEMS_ACTIVEPERMISSIONS", AV67SelectedItems_ActivePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDITEMS_ACTIVEPERMISSIONS", AV67SelectedItems_ActivePermissions);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vS_ID", StringUtil.RTrim( AV72S_Id));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFIELDVALUES_ACTIVEPERMISSIONS", AV76FieldValues_ActivePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFIELDVALUES_ACTIVEPERMISSIONS", AV76FieldValues_ActivePermissions);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vAPPLICATIONID_PREVIOUSVALUE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV75ApplicationId_PreviousValue), 12, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vISOK", AV41isOK);
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertableactivepermissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_activepermissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridcomponentcontent_activepermissions_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm442( )
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
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
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
         return "K2BFSG.RoleSelectPermission" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seleccionar permisos de rol" ;
      }

      protected void WB440( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.roleselectpermission.aspx");
               context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
               context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divContenttable_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_WebPanelDesignerContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponent_activepermissions_Internalname, 1, 0, "px", 0, "px", divGridcomponent_activepermissions_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_15_442( true) ;
         }
         else
         {
            wb_table1_15_442( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_442e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_activepermissions_Internalname, divGridcomponentcontent_activepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_activepermissions_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_WPD_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_activepermissions_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_combinedfilterlayout_activepermissions_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section4_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGenericfilter_activepermissions_Internalname, "Generic Filter_Active Permissions", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'" + sPrefix + "',false,'" + sGXsfl_127_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_activepermissions_Internalname, StringUtil.RTrim( AV83GenericFilter_ActivePermissions), StringUtil.RTrim( context.localUtil.Format( AV83GenericFilter_ActivePermissions, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_activepermissions_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_activepermissions_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\RoleSelectPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_combined_activepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ELAYOUTDEFINED_FILTERTOGGLE_COMBINED_ACTIVEPERMISSIONS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLayoutdefined_filtersummary_combined_activepermissions_Internalname, lblLayoutdefined_filtersummary_combined_activepermissions_Caption, "", "", lblLayoutdefined_filtersummary_combined_activepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_FilterSummary", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname, divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_combined_activepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_combined_activepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ELAYOUTDEFINED_FILTERCLOSE_COMBINED_ACTIVEPERMISSIONS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMainfilterresponsivetable_filters_Internalname, 1, 0, "px", 0, "px", "FilterContainerTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFiltercontainertable_filters_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_applicationid_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavApplicationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavApplicationid_Internalname, "Aplicación", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'" + sPrefix + "',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavApplicationid, cmbavApplicationid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0)), 1, cmbavApplicationid_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavApplicationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 1, "HLP_K2BFSG\\RoleSelectPermission.htm");
            cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
            AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", (string)(cmbavApplicationid.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            wb_table2_61_442( true) ;
         }
         else
         {
            wb_table2_61_442( false) ;
         }
         return  ;
      }

      protected void wb_table2_61_442e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section1_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section7_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatLeft", "left", "top", "", "", "div");
            wb_table3_109_442( true) ;
         }
         else
         {
            wb_table3_109_442( false) ;
         }
         return  ;
      }

      protected void wb_table3_109_442e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section3_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FloatRight", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_activepermissions_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_activepermissions_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table4_121_442( true) ;
         }
         else
         {
            wb_table4_121_442( false) ;
         }
         return  ;
      }

      protected void wb_table4_121_442e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_139_442( true) ;
         }
         else
         {
            wb_table5_139_442( false) ;
         }
         return  ;
      }

      protected void wb_table5_139_442e( bool wbgen )
      {
         if ( wbgen )
         {
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_activepermissions_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_activepermissions_Internalname, divPaginationbar_pagingcontainertable_activepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockactivepermissions_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e11441_client"+"'", "", lblPaginationbar_previouspagebuttontextblockactivepermissions_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockactivepermissions_Internalname, lblPaginationbar_firstpagetextblockactivepermissions_Caption, "", "", lblPaginationbar_firstpagetextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e12441_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockactivepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockactivepermissions_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockactivepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockactivepermissions_Internalname, lblPaginationbar_previouspagetextblockactivepermissions_Caption, "", "", lblPaginationbar_previouspagetextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e11441_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockactivepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockactivepermissions_Internalname, lblPaginationbar_currentpagetextblockactivepermissions_Caption, "", "", lblPaginationbar_currentpagetextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockactivepermissions_Internalname, lblPaginationbar_nextpagetextblockactivepermissions_Caption, "", "", lblPaginationbar_nextpagetextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e13441_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockactivepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockactivepermissions_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockactivepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockactivepermissions_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e13441_client"+"'", "", lblPaginationbar_nextpagebuttontextblockactivepermissions_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, sPrefix+"K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 127 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( ActivepermissionsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"ActivepermissionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Activepermissions", ActivepermissionsContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"ActivepermissionsContainerData", ActivepermissionsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"ActivepermissionsContainerData"+"V", ActivepermissionsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"ActivepermissionsContainerData"+"V"+"\" value='"+ActivepermissionsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START442( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_6-154974", 0) ;
               }
               Form.Meta.addItem("description", "Seleccionar permisos de rol", 0) ;
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
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP440( ) ;
            }
         }
      }

      protected void WS442( )
      {
         START442( ) ;
         EVT442( ) ;
      }

      protected void EVT442( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADD'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Add' */
                                    E14442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_DELETEMULTIPLE'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_DeleteMultiple' */
                                    E15442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(ACTIVEPERMISSIONS)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'SaveGridSettings(ActivePermissions)' */
                                    E16442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VCHECKALL_ACTIVEPERMISSIONS.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E17442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_ACTIVEPERMISSIONS.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E18442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_COMBINED_ACTIVEPERMISSIONS.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E19442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDTITLE_ACTIVEPERMISSIONS.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E20442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "COLLAPSIBLEIMAGE_ACTIVEPERMISSIONS.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E21442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_SAVECHANGES'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_SaveChanges' */
                                    E22442 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 22), "ACTIVEPERMISSIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 45), "VMULTIROWITEMSELECTED_ACTIVEPERMISSIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "ACTIVEPERMISSIONS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 45), "VMULTIROWITEMSELECTED_ACTIVEPERMISSIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "'E_DELETE'") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP440( ) ;
                              }
                              nGXsfl_127_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
                              SubsflControlProps_1272( ) ;
                              AV46MultiRowItemSelected_ActivePermissions = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_activepermissions_Internalname));
                              AssignAttri(sPrefix, false, chkavMultirowitemselected_activepermissions_Internalname, AV46MultiRowItemSelected_ActivePermissions);
                              AV48Name = cgiGet( edtavName_Internalname);
                              AssignAttri(sPrefix, false, edtavName_Internalname, AV48Name);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV48Name, "")), context));
                              AV17Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri(sPrefix, false, edtavDsc_Internalname, AV17Dsc);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDSC"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV17Dsc, "")), context));
                              cmbavAccesstype.Name = cmbavAccesstype_Internalname;
                              cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
                              AV7AccessType = cgiGet( cmbavAccesstype_Internalname);
                              AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV7AccessType);
                              AV40IsInherited = StringUtil.StrToBool( cgiGet( chkavIsinherited_Internalname));
                              AssignAttri(sPrefix, false, chkavIsinherited_Internalname, AV40IsInherited);
                              cmbavStoredaccesstype.Name = cmbavStoredaccesstype_Internalname;
                              cmbavStoredaccesstype.CurrentValue = cgiGet( cmbavStoredaccesstype_Internalname);
                              AV86StoredAccessType = cgiGet( cmbavStoredaccesstype_Internalname);
                              AssignAttri(sPrefix, false, cmbavStoredaccesstype_Internalname, AV86StoredAccessType);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDACCESSTYPE"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV86StoredAccessType, "")), context));
                              AV88StoredIsInherited = StringUtil.StrToBool( cgiGet( chkavStoredisinherited_Internalname));
                              AssignAttri(sPrefix, false, chkavStoredisinherited_Internalname, AV88StoredIsInherited);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDISINHERITED"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, AV88StoredIsInherited, context));
                              AV37Id = cgiGet( edtavId_Internalname);
                              AssignAttri(sPrefix, false, edtavId_Internalname, AV37Id);
                              GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV37Id, "")), context));
                              AV82Delete_Action = cgiGet( edtavDelete_action_Internalname);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV82Delete_Action)) ? AV98Delete_action_GXI : context.convertURL( context.PathToRelativeUrl( AV82Delete_Action))), !bGXsfl_127_Refreshing);
                              AssignProp(sPrefix, false, edtavDelete_action_Internalname, "SrcSet", context.GetImageSrcSet( AV82Delete_Action), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E23442 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E24442 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ACTIVEPERMISSIONS.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E25442 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMULTIROWITEMSELECTED_ACTIVEPERMISSIONS.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E26442 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ACTIVEPERMISSIONS.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E27442 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "'E_DELETE'") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: 'E_Delete' */
                                          E28442 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP440( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_activepermissions_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE442( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm442( ) ;
            }
         }
      }

      protected void PA442( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavGenericfilter_activepermissions_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrActivepermissions_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1272( ) ;
         while ( nGXsfl_127_idx <= nRC_GXsfl_127 )
         {
            sendrow_1272( ) ;
            nGXsfl_127_idx = ((subActivepermissions_Islastpage==1)&&(nGXsfl_127_idx+1>subActivepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_idx+1);
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( ActivepermissionsContainer)) ;
         /* End function gxnrActivepermissions_newrow */
      }

      protected void gxgrActivepermissions_refresh( long AV6RoleId ,
                                                    GxSimpleCollection<string> AV85ClassCollection_ActivePermissions ,
                                                    long AV75ApplicationId_PreviousValue ,
                                                    long AV14ApplicationId ,
                                                    GXBaseCollection<SdtK2BSelectionItem> AV66AllSelectedItems_ActivePermissions ,
                                                    string AV97Pgmname ,
                                                    short AV15CurrentPage_ActivePermissions ,
                                                    string AV83GenericFilter_ActivePermissions ,
                                                    short AV77CountSelectedItems_ActivePermissions ,
                                                    SdtK2BGridConfiguration AV84GridConfiguration ,
                                                    bool AV32HasNextPage_ActivePermissions ,
                                                    short AV61RowsPerPage_ActivePermissions ,
                                                    string AV37Id ,
                                                    short AV9ActivePermissions_SelectedRows ,
                                                    short AV35I_LoadCount_ActivePermissions ,
                                                    bool AV91FreezeColumnTitles_ActivePermissions ,
                                                    bool AV63CheckAll_ActivePermissions ,
                                                    string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E24442 ();
         ACTIVEPERMISSIONS_nCurrentRecord = 0;
         RF442( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrActivepermissions_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV37Id, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vID", StringUtil.RTrim( AV37Id));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV48Name, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vNAME", StringUtil.RTrim( AV48Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDSC", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV17Dsc, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vDSC", StringUtil.RTrim( AV17Dsc));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDACCESSTYPE", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV86StoredAccessType, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTOREDACCESSTYPE", StringUtil.RTrim( AV86StoredAccessType));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDISINHERITED", GetSecureSignedToken( sPrefix, AV88StoredIsInherited, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSTOREDISINHERITED", StringUtil.BoolToStr( AV88StoredIsInherited));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavApplicationid.ItemCount > 0 )
         {
            AV14ApplicationId = (long)(NumberUtil.Val( cmbavApplicationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0))), "."));
            AssignAttri(sPrefix, false, "AV14ApplicationId", StringUtil.LTrimStr( (decimal)(AV14ApplicationId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
            AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_activepermissions.ItemCount > 0 )
         {
            AV62GridSettingsRowsPerPage_ActivePermissions = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_activepermissions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0))), "."));
            AssignAttri(sPrefix, false, "AV62GridSettingsRowsPerPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_activepermissions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_activepermissions_Internalname, "Values", cmbavGridsettingsrowsperpage_activepermissions.ToJavascriptSource(), true);
         }
         AV91FreezeColumnTitles_ActivePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV91FreezeColumnTitles_ActivePermissions));
         AssignAttri(sPrefix, false, "AV91FreezeColumnTitles_ActivePermissions", AV91FreezeColumnTitles_ActivePermissions);
         AV63CheckAll_ActivePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV63CheckAll_ActivePermissions));
         AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E24442 ();
         RF442( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV97Pgmname = "K2BFSG.RoleSelectPermission";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_127_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_127_Refreshing);
         cmbavAccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         chkavIsinherited.Enabled = 0;
         AssignProp(sPrefix, false, chkavIsinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         cmbavStoredaccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavStoredaccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavStoredaccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         chkavStoredisinherited.Enabled = 0;
         AssignProp(sPrefix, false, chkavStoredisinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavStoredisinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_127_Refreshing);
      }

      protected void RF442( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            ActivepermissionsContainer.ClearRows();
         }
         wbStart = 127;
         E27442 ();
         nGXsfl_127_idx = 1;
         sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
         SubsflControlProps_1272( ) ;
         bGXsfl_127_Refreshing = true;
         ActivepermissionsContainer.AddObjectProperty("GridName", "Activepermissions");
         ActivepermissionsContainer.AddObjectProperty("CmpContext", sPrefix);
         ActivepermissionsContainer.AddObjectProperty("InMasterPage", "false");
         ActivepermissionsContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         ActivepermissionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         ActivepermissionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         ActivepermissionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Backcolorstyle), 1, 0, ".", "")));
         ActivepermissionsContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Sortable), 1, 0, ".", "")));
         ActivepermissionsContainer.PageSize = subActivepermissions_fnc_Recordsperpage( );
         if ( subActivepermissions_Islastpage != 0 )
         {
            ACTIVEPERMISSIONS_nFirstRecordOnPage = (long)(subActivepermissions_fnc_Recordcount( )-subActivepermissions_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"ACTIVEPERMISSIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(ACTIVEPERMISSIONS_nFirstRecordOnPage), 15, 0, ".", "")));
            ActivepermissionsContainer.AddObjectProperty("ACTIVEPERMISSIONS_nFirstRecordOnPage", ACTIVEPERMISSIONS_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1272( ) ;
            E25442 ();
            wbEnd = 127;
            WB440( ) ;
         }
         bGXsfl_127_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes442( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV97Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV97Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV37Id, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_ACTIVEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV35I_LoadCount_ActivePermissions), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV35I_LoadCount_ActivePermissions), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vHASNEXTPAGE_ACTIVEPERMISSIONS", AV32HasNextPage_ActivePermissions);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, AV32HasNextPage_ActivePermissions, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV48Name, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDSC"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV17Dsc, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDACCESSTYPE"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV86StoredAccessType, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDISINHERITED"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, AV88StoredIsInherited, context));
      }

      protected int subActivepermissions_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subActivepermissions_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subActivepermissions_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subActivepermissions_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV97Pgmname = "K2BFSG.RoleSelectPermission";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_127_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp(sPrefix, false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_127_Refreshing);
         cmbavAccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         chkavIsinherited.Enabled = 0;
         AssignProp(sPrefix, false, chkavIsinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         cmbavStoredaccesstype.Enabled = 0;
         AssignProp(sPrefix, false, cmbavStoredaccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavStoredaccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         chkavStoredisinherited.Enabled = 0;
         AssignProp(sPrefix, false, chkavStoredisinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavStoredisinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_127_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP440( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E23442 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_127 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_127"), ",", "."));
            wcpOAV6RoleId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6RoleId"), ",", "."));
            AV61RowsPerPage_ActivePermissions = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vROWSPERPAGE_ACTIVEPERMISSIONS"), ",", "."));
            AV15CurrentPage_ActivePermissions = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vCURRENTPAGE_ACTIVEPERMISSIONS"), ",", "."));
            AV32HasNextPage_ActivePermissions = StringUtil.StrToBool( cgiGet( sPrefix+"vHASNEXTPAGE_ACTIVEPERMISSIONS"));
            divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS_Visible"), ",", "."));
            divGridcomponentcontent_activepermissions_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS_Visible"), ",", "."));
            /* Read variables values. */
            AV83GenericFilter_ActivePermissions = cgiGet( edtavGenericfilter_activepermissions_Internalname);
            AssignAttri(sPrefix, false, "AV83GenericFilter_ActivePermissions", AV83GenericFilter_ActivePermissions);
            cmbavApplicationid.Name = cmbavApplicationid_Internalname;
            cmbavApplicationid.CurrentValue = cgiGet( cmbavApplicationid_Internalname);
            AV14ApplicationId = (long)(NumberUtil.Val( cgiGet( cmbavApplicationid_Internalname), "."));
            AssignAttri(sPrefix, false, "AV14ApplicationId", StringUtil.LTrimStr( (decimal)(AV14ApplicationId), 12, 0));
            cmbavGridsettingsrowsperpage_activepermissions.Name = cmbavGridsettingsrowsperpage_activepermissions_Internalname;
            cmbavGridsettingsrowsperpage_activepermissions.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_activepermissions_Internalname);
            AV62GridSettingsRowsPerPage_ActivePermissions = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_activepermissions_Internalname), "."));
            AssignAttri(sPrefix, false, "AV62GridSettingsRowsPerPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0));
            AV91FreezeColumnTitles_ActivePermissions = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_activepermissions_Internalname));
            AssignAttri(sPrefix, false, "AV91FreezeColumnTitles_ActivePermissions", AV91FreezeColumnTitles_ActivePermissions);
            AV63CheckAll_ActivePermissions = StringUtil.StrToBool( cgiGet( chkavCheckall_activepermissions_Internalname));
            AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         AV5GAMRole.load( AV6RoleId);
         AV81CurrentAppGUID = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).getguid();
         cmbavApplicationid.removeAllItems();
         AV95GXV2 = 1;
         AV94GXV1 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV13ApplicationFilter, out  AV19Errors);
         while ( AV95GXV2 <= AV94GXV1.Count )
         {
            AV12Application = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV94GXV1.Item(AV95GXV2));
            if ( (0==AV14ApplicationId) && ( StringUtil.StrCmp(AV12Application.gxTpr_Guid, AV81CurrentAppGUID) == 0 ) )
            {
               AV14ApplicationId = AV12Application.gxTpr_Id;
               AssignAttri(sPrefix, false, "AV14ApplicationId", StringUtil.LTrimStr( (decimal)(AV14ApplicationId), 12, 0));
            }
            cmbavApplicationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV12Application.gxTpr_Id), 12, 0)), AV12Application.gxTpr_Name, 0);
            AV95GXV2 = (int)(AV95GXV2+1);
         }
         GXt_objcol_SdtMessages_Message1 = AV43Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV43Messages = GXt_objcol_SdtMessages_Message1;
         AV96GXV3 = 1;
         while ( AV96GXV3 <= AV43Messages.Count )
         {
            AV42Message = ((GeneXus.Utils.SdtMessages_Message)AV43Messages.Item(AV96GXV3));
            GX_msglist.addItem(AV42Message.gxTpr_Description);
            AV96GXV3 = (int)(AV96GXV3+1);
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E23442 ();
         if (returnInSub) return;
      }

      protected void E23442( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV97Pgmname,  "ActivePermissions", out  AV61RowsPerPage_ActivePermissions, out  AV78RowsPerPageLoaded_ActivePermissions) ;
         AssignAttri(sPrefix, false, "AV61RowsPerPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV61RowsPerPage_ActivePermissions), 4, 0));
         if ( ! AV78RowsPerPageLoaded_ActivePermissions )
         {
            AV61RowsPerPage_ActivePermissions = 20;
            AssignAttri(sPrefix, false, "AV61RowsPerPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV61RowsPerPage_ActivePermissions), 4, 0));
         }
         AV62GridSettingsRowsPerPage_ActivePermissions = AV61RowsPerPage_ActivePermissions;
         AssignAttri(sPrefix, false, "AV62GridSettingsRowsPerPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(ACTIVEPERMISSIONS)' */
         S122 ();
         if (returnInSub) return;
         AV75ApplicationId_PreviousValue = AV14ApplicationId;
         AssignAttri(sPrefix, false, "AV75ApplicationId_PreviousValue", StringUtil.LTrimStr( (decimal)(AV75ApplicationId_PreviousValue), 12, 0));
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(ACTIVEPERMISSIONS)' */
         S132 ();
         if (returnInSub) return;
         subActivepermissions_Backcolorstyle = 3;
         divGridsettings_contentoutertableactivepermissions_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertableactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertableactivepermissions_Visible), 5, 0), true);
      }

      protected void E24442( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_STARTPAGE' */
         S142 ();
         if (returnInSub) return;
         if ( (0==AV15CurrentPage_ActivePermissions) )
         {
            AV15CurrentPage_ActivePermissions = 1;
            AssignAttri(sPrefix, false, "AV15CurrentPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_ActivePermissions), 4, 0));
         }
         AV52Reload_ActivePermissions = true;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(ACTIVEPERMISSIONS)' */
         S152 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV33HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(ACTIVEPERMISSIONS)' */
            S162 ();
            if (returnInSub) return;
            AV9ActivePermissions_SelectedRows = 0;
            AssignAttri(sPrefix, false, "AV9ActivePermissions_SelectedRows", StringUtil.LTrimStr( (decimal)(AV9ActivePermissions_SelectedRows), 4, 0));
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV85ClassCollection_ActivePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_activepermissions_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_activepermissions_Internalname, "Class", divMaingrid_responsivetable_activepermissions_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
         AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
      }

      protected void S172( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
      }

      private void E25442( )
      {
         /* Activepermissions_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_activepermissions_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_activepermissions_Visible), 5, 0), true);
         AV35I_LoadCount_ActivePermissions = 0;
         AssignAttri(sPrefix, false, "AV35I_LoadCount_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV35I_LoadCount_ActivePermissions), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV35I_LoadCount_ActivePermissions), "ZZZ9"), context));
         AV32HasNextPage_ActivePermissions = false;
         AssignAttri(sPrefix, false, "AV32HasNextPage_ActivePermissions", AV32HasNextPage_ActivePermissions);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, AV32HasNextPage_ActivePermissions, context));
         AV20Exit_ActivePermissions = false;
         while ( true )
         {
            AV35I_LoadCount_ActivePermissions = (short)(AV35I_LoadCount_ActivePermissions+1);
            AssignAttri(sPrefix, false, "AV35I_LoadCount_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV35I_LoadCount_ActivePermissions), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV35I_LoadCount_ActivePermissions), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(ACTIVEPERMISSIONS)' */
            S182 ();
            if (returnInSub) return;
            AV82Delete_Action = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
            AssignAttri(sPrefix, false, edtavDelete_action_Internalname, AV82Delete_Action);
            AV98Delete_action_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
            edtavDelete_action_Tooltiptext = "Eliminar";
            /* Execute user subroutine: 'U_AFTERDATALOAD(ACTIVEPERMISSIONS)' */
            S192 ();
            if (returnInSub) return;
            if ( AV20Exit_ActivePermissions )
            {
               if (true) break;
            }
            if ( AV35I_LoadCount_ActivePermissions > AV61RowsPerPage_ActivePermissions * AV15CurrentPage_ActivePermissions )
            {
               AV32HasNextPage_ActivePermissions = true;
               AssignAttri(sPrefix, false, "AV32HasNextPage_ActivePermissions", AV32HasNextPage_ActivePermissions);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vHASNEXTPAGE_ACTIVEPERMISSIONS", GetSecureSignedToken( sPrefix, AV32HasNextPage_ActivePermissions, context));
               if (true) break;
            }
            if ( AV35I_LoadCount_ActivePermissions > AV61RowsPerPage_ActivePermissions * ( AV15CurrentPage_ActivePermissions - 1 ) )
            {
               tblI_noresultsfoundtablename_activepermissions_Visible = 0;
               AssignProp(sPrefix, false, tblI_noresultsfoundtablename_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_activepermissions_Visible), 5, 0), true);
               AV46MultiRowItemSelected_ActivePermissions = false;
               AssignAttri(sPrefix, false, chkavMultirowitemselected_activepermissions_Internalname, AV46MultiRowItemSelected_ActivePermissions);
               AV99GXV4 = 1;
               while ( AV99GXV4 <= AV66AllSelectedItems_ActivePermissions.Count )
               {
                  AV64SelectedItem_ActivePermissions = ((SdtK2BSelectionItem)AV66AllSelectedItems_ActivePermissions.Item(AV99GXV4));
                  if ( StringUtil.StrCmp(AV64SelectedItem_ActivePermissions.gxTpr_Skcharacter1, AV37Id) == 0 )
                  {
                     if ( AV64SelectedItem_ActivePermissions.gxTpr_Isselected )
                     {
                        AV46MultiRowItemSelected_ActivePermissions = true;
                        AssignAttri(sPrefix, false, chkavMultirowitemselected_activepermissions_Internalname, AV46MultiRowItemSelected_ActivePermissions);
                        AV9ActivePermissions_SelectedRows = (short)(AV9ActivePermissions_SelectedRows+1);
                        AssignAttri(sPrefix, false, "AV9ActivePermissions_SelectedRows", StringUtil.LTrimStr( (decimal)(AV9ActivePermissions_SelectedRows), 4, 0));
                     }
                     if (true) break;
                  }
                  AV99GXV4 = (int)(AV99GXV4+1);
               }
               if ( ((int)((AV35I_LoadCount_ActivePermissions) % (AV61RowsPerPage_ActivePermissions))) == 1 )
               {
                  AV63CheckAll_ActivePermissions = true;
                  AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
               }
               if ( ! AV46MultiRowItemSelected_ActivePermissions )
               {
                  AV63CheckAll_ActivePermissions = false;
                  AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 127;
               }
               sendrow_1272( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_127_Refreshing )
               {
                  context.DoAjaxLoad(127, ActivepermissionsRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(ACTIVEPERMISSIONS)' */
         S202 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(ACTIVEPERMISSIONS)' */
         S212 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV51PermissionFilter", AV51PermissionFilter);
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV7AccessType);
         cmbavStoredaccesstype.CurrentValue = StringUtil.RTrim( AV86StoredAccessType);
      }

      protected void S202( )
      {
         /* 'UPDATEPAGINGCONTROLS(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockactivepermissions_Caption = "1";
         AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockactivepermissions_Internalname, "Caption", lblPaginationbar_firstpagetextblockactivepermissions_Caption, true);
         lblPaginationbar_previouspagetextblockactivepermissions_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_ActivePermissions-1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockactivepermissions_Internalname, "Caption", lblPaginationbar_previouspagetextblockactivepermissions_Caption, true);
         lblPaginationbar_currentpagetextblockactivepermissions_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_ActivePermissions), 4, 0);
         AssignProp(sPrefix, false, lblPaginationbar_currentpagetextblockactivepermissions_Internalname, "Caption", lblPaginationbar_currentpagetextblockactivepermissions_Caption, true);
         lblPaginationbar_nextpagetextblockactivepermissions_Caption = StringUtil.Str( (decimal)(AV15CurrentPage_ActivePermissions+1), 10, 0);
         AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockactivepermissions_Internalname, "Caption", lblPaginationbar_nextpagetextblockactivepermissions_Caption, true);
         lblPaginationbar_previouspagebuttontextblockactivepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockactivepermissions_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockactivepermissions_Class, true);
         lblPaginationbar_nextpagebuttontextblockactivepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockactivepermissions_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockactivepermissions_Class, true);
         if ( (0==AV15CurrentPage_ActivePermissions) || ( AV15CurrentPage_ActivePermissions <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockactivepermissions_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp(sPrefix, false, lblPaginationbar_previouspagebuttontextblockactivepermissions_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockactivepermissions_Class, true);
            lblPaginationbar_firstpagetextblockactivepermissions_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockactivepermissions_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockactivepermissions_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockactivepermissions_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockactivepermissions_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockactivepermissions_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockactivepermissions_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_previouspagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockactivepermissions_Visible), 5, 0), true);
            if ( AV15CurrentPage_ActivePermissions == 2 )
            {
               lblPaginationbar_firstpagetextblockactivepermissions_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockactivepermissions_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockactivepermissions_Visible = 0;
               AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockactivepermissions_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockactivepermissions_Visible = 1;
               AssignProp(sPrefix, false, lblPaginationbar_firstpagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockactivepermissions_Visible), 5, 0), true);
               if ( AV15CurrentPage_ActivePermissions == 3 )
               {
                  lblPaginationbar_spacinglefttextblockactivepermissions_Visible = 0;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockactivepermissions_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockactivepermissions_Visible = 1;
                  AssignProp(sPrefix, false, lblPaginationbar_spacinglefttextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockactivepermissions_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV32HasNextPage_ActivePermissions )
         {
            lblPaginationbar_nextpagebuttontextblockactivepermissions_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp(sPrefix, false, lblPaginationbar_nextpagebuttontextblockactivepermissions_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockactivepermissions_Class, true);
            lblPaginationbar_spacingrighttextblockactivepermissions_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockactivepermissions_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockactivepermissions_Visible = 0;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockactivepermissions_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockactivepermissions_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_nextpagetextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockactivepermissions_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockactivepermissions_Visible = 1;
            AssignProp(sPrefix, false, lblPaginationbar_spacingrighttextblockactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockactivepermissions_Visible), 5, 0), true);
         }
         if ( ( AV15CurrentPage_ActivePermissions <= 1 ) && ! AV32HasNextPage_ActivePermissions )
         {
            divPaginationbar_pagingcontainertable_activepermissions_Visible = 0;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_activepermissions_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_activepermissions_Visible = 1;
            AssignProp(sPrefix, false, divPaginationbar_pagingcontainertable_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_activepermissions_Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'U_ADD' Routine */
         returnInSub = false;
         AV59Window.Autoresize = 1;
         AV59Window.Url = formatLink("k2bfsg.roleaddpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6RoleId,12,0)),UrlEncode(StringUtil.LTrimStr(AV14ApplicationId,12,0))}, new string[] {"RoleId","ApplicationId"}) ;
         AV59Window.SetReturnParms(new Object[] {"AV6RoleId","AV14ApplicationId",});
         context.NewWindow(AV59Window);
         context.DoAjaxRefreshCmp(sPrefix);
      }

      protected void E14442( )
      {
         /* 'E_Add' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_ADD' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
         AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
      }

      protected void S252( )
      {
         /* 'U_DELETEMULTIPLE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(ACTIVEPERMISSIONS)' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(ACTIVEPERMISSIONS)' */
         S242 ();
         if (returnInSub) return;
         AV60hasError = false;
         while ( AV45MultiRowHasNext_ActivePermissions )
         {
            AV5GAMRole.load( AV6RoleId);
            AV41isOK = AV5GAMRole.deletepermissionbyid(AV14ApplicationId, AV72S_Id, out  AV19Errors);
            AssignAttri(sPrefix, false, "AV41isOK", AV41isOK);
            if ( ! AV41isOK )
            {
               AV60hasError = true;
               AV100GXV5 = 1;
               while ( AV100GXV5 <= AV19Errors.Count )
               {
                  AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV100GXV5));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV100GXV5 = (int)(AV100GXV5+1);
               }
            }
            /* Execute user subroutine: 'GETNEXTMULTIROW(ACTIVEPERMISSIONS)' */
            S242 ();
            if (returnInSub) return;
         }
         if ( ! AV60hasError )
         {
            GX_msglist.addItem(StringUtil.Format( "Permisos para rol %1 eliminados exitosamente", AV5GAMRole.gxTpr_Name, "", "", "", "", "", "", "", ""));
            AV66AllSelectedItems_ActivePermissions.Clear();
            context.CommitDataStores("k2bfsg.roleselectpermission",pr_default);
         }
         gxgrActivepermissions_refresh( AV6RoleId, AV85ClassCollection_ActivePermissions, AV75ApplicationId_PreviousValue, AV14ApplicationId, AV66AllSelectedItems_ActivePermissions, AV97Pgmname, AV15CurrentPage_ActivePermissions, AV83GenericFilter_ActivePermissions, AV77CountSelectedItems_ActivePermissions, AV84GridConfiguration, AV32HasNextPage_ActivePermissions, AV61RowsPerPage_ActivePermissions, AV37Id, AV9ActivePermissions_SelectedRows, AV35I_LoadCount_ActivePermissions, AV91FreezeColumnTitles_ActivePermissions, AV63CheckAll_ActivePermissions, sPrefix) ;
      }

      protected void E15442( )
      {
         /* 'E_DeleteMultiple' Routine */
         returnInSub = false;
         AV67SelectedItems_ActivePermissions = AV66AllSelectedItems_ActivePermissions;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(ACTIVEPERMISSIONS)' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(ACTIVEPERMISSIONS)' */
         S242 ();
         if (returnInSub) return;
         if ( ! AV45MultiRowHasNext_ActivePermissions )
         {
            AV52Reload_ActivePermissions = false;
            GX_msglist.addItem("Error: Debe seleccionar alguna línea");
         }
         else
         {
            /* Execute user subroutine: 'RESETMULTIROWITERATOR(ACTIVEPERMISSIONS)' */
            S232 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'GETNEXTMULTIROW(ACTIVEPERMISSIONS)' */
            S242 ();
            if (returnInSub) return;
            while ( AV45MultiRowHasNext_ActivePermissions )
            {
               /* Execute user subroutine: 'GETNEXTMULTIROW(ACTIVEPERMISSIONS)' */
               S242 ();
               if (returnInSub) return;
            }
            /* Execute user subroutine: 'U_DELETEMULTIPLE' */
            S252 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV67SelectedItems_ActivePermissions", AV67SelectedItems_ActivePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV76FieldValues_ActivePermissions", AV76FieldValues_ActivePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66AllSelectedItems_ActivePermissions", AV66AllSelectedItems_ActivePermissions);
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
         AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
      }

      protected void S182( )
      {
         /* 'U_LOADROWVARS(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         if ( AV35I_LoadCount_ActivePermissions == 1 )
         {
            AV5GAMRole.load( AV6RoleId);
            AV22GAMApplication.load( AV14ApplicationId);
            AV51PermissionFilter.gxTpr_Applicationid = AV14ApplicationId;
            AV51PermissionFilter.gxTpr_Name = AV83GenericFilter_ActivePermissions;
            AV8ActivePermissions = AV5GAMRole.getpermissions(AV51PermissionFilter, out  AV19Errors);
         }
         if ( AV8ActivePermissions.Count >= AV35I_LoadCount_ActivePermissions )
         {
            AV48Name = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Name;
            AssignAttri(sPrefix, false, edtavName_Internalname, AV48Name);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vNAME"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV48Name, "")), context));
            AV17Dsc = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Description;
            AssignAttri(sPrefix, false, edtavDsc_Internalname, AV17Dsc);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vDSC"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV17Dsc, "")), context));
            AV7AccessType = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Type;
            AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV7AccessType);
            AV86StoredAccessType = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Type;
            AssignAttri(sPrefix, false, cmbavStoredaccesstype_Internalname, AV86StoredAccessType);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDACCESSTYPE"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV86StoredAccessType, "")), context));
            AV37Id = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Guid;
            AssignAttri(sPrefix, false, edtavId_Internalname, AV37Id);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vID"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV37Id, "")), context));
            AV40IsInherited = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Inherited;
            AssignAttri(sPrefix, false, chkavIsinherited_Internalname, AV40IsInherited);
            AV88StoredIsInherited = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV8ActivePermissions.Item(AV35I_LoadCount_ActivePermissions)).gxTpr_Inherited;
            AssignAttri(sPrefix, false, chkavStoredisinherited_Internalname, AV88StoredIsInherited);
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDISINHERITED"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, AV88StoredIsInherited, context));
         }
         else
         {
            AV20Exit_ActivePermissions = true;
         }
      }

      protected void S212( )
      {
         /* 'SAVEGRIDSTATE(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV31GridStateKey = "ActivePermissions";
         new k2bloadgridstate(context ).execute(  AV97Pgmname,  AV31GridStateKey, out  AV29GridState) ;
         AV29GridState.gxTpr_Currentpage = AV15CurrentPage_ActivePermissions;
         AV29GridState.gxTpr_Filtervalues.Clear();
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "ApplicationId";
         AV30GridStateFilterValue.gxTpr_Value = StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0);
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV30GridStateFilterValue.gxTpr_Filtername = "GenericFilter_ActivePermissions";
         AV30GridStateFilterValue.gxTpr_Value = AV83GenericFilter_ActivePermissions;
         AV29GridState.gxTpr_Filtervalues.Add(AV30GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV97Pgmname,  AV31GridStateKey,  AV29GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV31GridStateKey = "ActivePermissions";
         new k2bloadgridstate(context ).execute(  AV97Pgmname,  AV31GridStateKey, out  AV29GridState) ;
         AV101GXV6 = 1;
         while ( AV101GXV6 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV101GXV6));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "ApplicationId") == 0 )
            {
               AV14ApplicationId = (long)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AssignAttri(sPrefix, false, "AV14ApplicationId", StringUtil.LTrimStr( (decimal)(AV14ApplicationId), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Filtername, "GenericFilter_ActivePermissions") == 0 )
            {
               AV83GenericFilter_ActivePermissions = AV30GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV83GenericFilter_ActivePermissions", AV83GenericFilter_ActivePermissions);
            }
            AV101GXV6 = (int)(AV101GXV6+1);
         }
         if ( AV29GridState.gxTpr_Currentpage > 0 )
         {
            AV15CurrentPage_ActivePermissions = AV29GridState.gxTpr_Currentpage;
            AssignAttri(sPrefix, false, "AV15CurrentPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_ActivePermissions), 4, 0));
         }
      }

      protected void S362( )
      {
         /* 'DISPLAYPERSISTENTACTIONS(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         bttAdd_Visible = 1;
         AssignProp(sPrefix, false, bttAdd_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAdd_Visible), 5, 0), true);
         bttSavechanges_Visible = 1;
         AssignProp(sPrefix, false, bttSavechanges_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttSavechanges_Visible), 5, 0), true);
      }

      protected void S232( )
      {
         /* 'RESETMULTIROWITERATOR(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV47MultiRowIterator_ActivePermissions = 1;
         AssignAttri(sPrefix, false, "AV47MultiRowIterator_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV47MultiRowIterator_ActivePermissions), 4, 0));
      }

      protected void S242( )
      {
         /* 'GETNEXTMULTIROW(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV69S_Name = "";
         AV70S_Dsc = "";
         AV71S_AccessType = "";
         AV87S_StoredAccessType = "";
         AV72S_Id = "";
         AssignAttri(sPrefix, false, "AV72S_Id", AV72S_Id);
         while ( ( AV47MultiRowIterator_ActivePermissions <= AV67SelectedItems_ActivePermissions.Count ) && ! ((SdtK2BSelectionItem)AV67SelectedItems_ActivePermissions.Item(AV47MultiRowIterator_ActivePermissions)).gxTpr_Isselected )
         {
            AV47MultiRowIterator_ActivePermissions = (short)(AV47MultiRowIterator_ActivePermissions+1);
            AssignAttri(sPrefix, false, "AV47MultiRowIterator_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV47MultiRowIterator_ActivePermissions), 4, 0));
         }
         if ( AV47MultiRowIterator_ActivePermissions > AV67SelectedItems_ActivePermissions.Count )
         {
            AV45MultiRowHasNext_ActivePermissions = false;
            AssignAttri(sPrefix, false, "AV45MultiRowHasNext_ActivePermissions", AV45MultiRowHasNext_ActivePermissions);
         }
         else
         {
            AV45MultiRowHasNext_ActivePermissions = true;
            AssignAttri(sPrefix, false, "AV45MultiRowHasNext_ActivePermissions", AV45MultiRowHasNext_ActivePermissions);
            AV76FieldValues_ActivePermissions = ((SdtK2BSelectionItem)AV67SelectedItems_ActivePermissions.Item(AV47MultiRowIterator_ActivePermissions)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_ACTIVEPERMISSIONS' */
            S372 ();
            if (returnInSub) return;
         }
         AV47MultiRowIterator_ActivePermissions = (short)(AV47MultiRowIterator_ActivePermissions+1);
         AssignAttri(sPrefix, false, "AV47MultiRowIterator_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV47MultiRowIterator_ActivePermissions), 4, 0));
      }

      protected void S322( )
      {
         /* 'U_MULTIROWITEMSELECTED(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
      }

      protected void E26442( )
      {
         /* Multirowitemselected_activepermissions_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(ACTIVEPERMISSIONS)' */
         S262 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66AllSelectedItems_ActivePermissions", AV66AllSelectedItems_ActivePermissions);
      }

      protected void E16442( )
      {
         /* 'SaveGridSettings(ActivePermissions)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV97Pgmname,  "ActivePermissions", ref  AV84GridConfiguration) ;
         AV84GridConfiguration.gxTpr_Freezecolumntitles = AV91FreezeColumnTitles_ActivePermissions;
         new k2bsavegridconfiguration(context ).execute(  AV97Pgmname,  "ActivePermissions",  AV84GridConfiguration,  true) ;
         if ( AV61RowsPerPage_ActivePermissions != AV62GridSettingsRowsPerPage_ActivePermissions )
         {
            AV61RowsPerPage_ActivePermissions = AV62GridSettingsRowsPerPage_ActivePermissions;
            AssignAttri(sPrefix, false, "AV61RowsPerPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV61RowsPerPage_ActivePermissions), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV97Pgmname,  "ActivePermissions",  AV61RowsPerPage_ActivePermissions) ;
            AV15CurrentPage_ActivePermissions = 1;
            AssignAttri(sPrefix, false, "AV15CurrentPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_ActivePermissions), 4, 0));
         }
         gxgrActivepermissions_refresh( AV6RoleId, AV85ClassCollection_ActivePermissions, AV75ApplicationId_PreviousValue, AV14ApplicationId, AV66AllSelectedItems_ActivePermissions, AV97Pgmname, AV15CurrentPage_ActivePermissions, AV83GenericFilter_ActivePermissions, AV77CountSelectedItems_ActivePermissions, AV84GridConfiguration, AV32HasNextPage_ActivePermissions, AV61RowsPerPage_ActivePermissions, AV37Id, AV9ActivePermissions_SelectedRows, AV35I_LoadCount_ActivePermissions, AV91FreezeColumnTitles_ActivePermissions, AV63CheckAll_ActivePermissions, sPrefix) ;
         divGridsettings_contentoutertableactivepermissions_Visible = 0;
         AssignProp(sPrefix, false, divGridsettings_contentoutertableactivepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertableactivepermissions_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
         AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
      }

      protected void S272( )
      {
         /* 'U_GRIDREFRESH(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         cmbavAccesstype.Enabled = 1;
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Enabled), 5, 0), !bGXsfl_127_Refreshing);
         chkavIsinherited.Enabled = 1;
         AssignProp(sPrefix, false, chkavIsinherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavIsinherited.Enabled), 5, 0), !bGXsfl_127_Refreshing);
      }

      protected void E27442( )
      {
         /* Activepermissions_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV85ClassCollection_ActivePermissions) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(ACTIVEPERMISSIONS)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(ACTIVEPERMISSIONS)' */
         S212 ();
         if (returnInSub) return;
         if ( AV75ApplicationId_PreviousValue != AV14ApplicationId )
         {
            AV75ApplicationId_PreviousValue = AV14ApplicationId;
            AssignAttri(sPrefix, false, "AV75ApplicationId_PreviousValue", StringUtil.LTrimStr( (decimal)(AV75ApplicationId_PreviousValue), 12, 0));
            AV15CurrentPage_ActivePermissions = 1;
            AssignAttri(sPrefix, false, "AV15CurrentPage_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV15CurrentPage_ActivePermissions), 4, 0));
         }
         subActivepermissions_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(ACTIVEPERMISSIONS)' */
         S162 ();
         if (returnInSub) return;
         AV9ActivePermissions_SelectedRows = 0;
         AssignAttri(sPrefix, false, "AV9ActivePermissions_SelectedRows", StringUtil.LTrimStr( (decimal)(AV9ActivePermissions_SelectedRows), 4, 0));
         if ( AV66AllSelectedItems_ActivePermissions.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV85ClassCollection_ActivePermissions) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV85ClassCollection_ActivePermissions) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV85ClassCollection_ActivePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_activepermissions_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_activepermissions_Internalname, "Class", divMaingrid_responsivetable_activepermissions_Class, true);
         /* Execute user subroutine: 'U_GRIDREFRESH(ACTIVEPERMISSIONS)' */
         S272 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(ACTIVEPERMISSIONS)' */
         S152 ();
         if (returnInSub) return;
         AV63CheckAll_ActivePermissions = false;
         AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(ACTIVEPERMISSIONS)' */
         S202 ();
         if (returnInSub) return;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV85ClassCollection_ActivePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_activepermissions_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_activepermissions_Internalname, "Class", divMaingrid_responsivetable_activepermissions_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
      }

      protected void S262( )
      {
         /* 'PROCESSSELECTION(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV63CheckAll_ActivePermissions = true;
         AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
         /* Start For Each Line in Activepermissions */
         nRC_GXsfl_127 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_127"), ",", "."));
         nGXsfl_127_fel_idx = 0;
         while ( nGXsfl_127_fel_idx < nRC_GXsfl_127 )
         {
            nGXsfl_127_fel_idx = ((subActivepermissions_Islastpage==1)&&(nGXsfl_127_fel_idx+1>subActivepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_fel_idx+1);
            sGXsfl_127_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1272( ) ;
            AV46MultiRowItemSelected_ActivePermissions = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_activepermissions_Internalname));
            AV48Name = cgiGet( edtavName_Internalname);
            AV17Dsc = cgiGet( edtavDsc_Internalname);
            cmbavAccesstype.Name = cmbavAccesstype_Internalname;
            cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
            AV7AccessType = cgiGet( cmbavAccesstype_Internalname);
            AV40IsInherited = StringUtil.StrToBool( cgiGet( chkavIsinherited_Internalname));
            cmbavStoredaccesstype.Name = cmbavStoredaccesstype_Internalname;
            cmbavStoredaccesstype.CurrentValue = cgiGet( cmbavStoredaccesstype_Internalname);
            AV86StoredAccessType = cgiGet( cmbavStoredaccesstype_Internalname);
            AV88StoredIsInherited = StringUtil.StrToBool( cgiGet( chkavStoredisinherited_Internalname));
            AV37Id = cgiGet( edtavId_Internalname);
            AV82Delete_Action = cgiGet( edtavDelete_action_Internalname);
            /* Execute user subroutine: 'UPDATESELECTION(ACTIVEPERMISSIONS)' */
            S282 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_127_fel_idx == 0 )
         {
            nGXsfl_127_idx = 1;
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         nGXsfl_127_fel_idx = 1;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(ACTIVEPERMISSIONS)' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(ACTIVEPERMISSIONS)' */
         S322 ();
         if (returnInSub) return;
         if ( AV66AllSelectedItems_ActivePermissions.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV85ClassCollection_ActivePermissions) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV85ClassCollection_ActivePermissions) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV85ClassCollection_ActivePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_activepermissions_Class = GXt_char2;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_activepermissions_Internalname, "Class", divMaingrid_responsivetable_activepermissions_Class, true);
      }

      protected void S302( )
      {
         /* 'DISPLAYMULTIPLEGLOBALACTIONS(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         imgDeletemultiple_Visible = 1;
         AssignProp(sPrefix, false, imgDeletemultiple_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDeletemultiple_Visible), 5, 0), true);
         imgDeletemultiple_Bitmap = context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgDeletemultiple_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgDeletemultiple_Bitmap)), true);
         AssignProp(sPrefix, false, imgDeletemultiple_Internalname, "SrcSet", context.GetImageSrcSet( imgDeletemultiple_Bitmap), true);
         imgDeletemultiple_Tooltiptext = "Eliminar";
         AssignProp(sPrefix, false, imgDeletemultiple_Internalname, "Tooltiptext", imgDeletemultiple_Tooltiptext, true);
      }

      protected void S312( )
      {
         /* 'HIDEMULTIPLEGLOBALACTIONS(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         imgDeletemultiple_Visible = 0;
         AssignProp(sPrefix, false, imgDeletemultiple_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgDeletemultiple_Visible), 5, 0), true);
      }

      protected void S282( )
      {
         /* 'UPDATESELECTION(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV68Index_ActivePermissions = 1;
         while ( AV68Index_ActivePermissions <= AV66AllSelectedItems_ActivePermissions.Count )
         {
            if ( StringUtil.StrCmp(((SdtK2BSelectionItem)AV66AllSelectedItems_ActivePermissions.Item(AV68Index_ActivePermissions)).gxTpr_Skcharacter1, AV37Id) == 0 )
            {
               AV66AllSelectedItems_ActivePermissions.RemoveItem(AV68Index_ActivePermissions);
            }
            else
            {
               AV68Index_ActivePermissions = (short)(AV68Index_ActivePermissions+1);
            }
         }
         if ( AV46MultiRowItemSelected_ActivePermissions )
         {
            AV64SelectedItem_ActivePermissions = new SdtK2BSelectionItem(context);
            AV64SelectedItem_ActivePermissions.gxTpr_Isselected = AV46MultiRowItemSelected_ActivePermissions;
            AV64SelectedItem_ActivePermissions.gxTpr_Skcharacter1 = AV37Id;
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "Name";
            AV65FieldValue_ActivePermissions.gxTpr_Value = AV48Name;
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "Dsc";
            AV65FieldValue_ActivePermissions.gxTpr_Value = AV17Dsc;
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "AccessType";
            AV65FieldValue_ActivePermissions.gxTpr_Value = AV7AccessType;
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "IsInherited";
            AV65FieldValue_ActivePermissions.gxTpr_Value = StringUtil.BoolToStr( AV40IsInherited);
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "StoredAccessType";
            AV65FieldValue_ActivePermissions.gxTpr_Value = AV86StoredAccessType;
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "StoredIsInherited";
            AV65FieldValue_ActivePermissions.gxTpr_Value = StringUtil.BoolToStr( AV88StoredIsInherited);
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV65FieldValue_ActivePermissions.gxTpr_Name = "Id";
            AV65FieldValue_ActivePermissions.gxTpr_Value = AV37Id;
            AV64SelectedItem_ActivePermissions.gxTpr_Fieldvalues.Add(AV65FieldValue_ActivePermissions, 0);
            AV66AllSelectedItems_ActivePermissions.Add(AV64SelectedItem_ActivePermissions, 0);
         }
         if ( ! AV46MultiRowItemSelected_ActivePermissions )
         {
            AV63CheckAll_ActivePermissions = false;
            AssignAttri(sPrefix, false, "AV63CheckAll_ActivePermissions", AV63CheckAll_ActivePermissions);
         }
      }

      protected void E17442( )
      {
         /* Checkall_activepermissions_Click Routine */
         returnInSub = false;
         /* Start For Each Line in Activepermissions */
         nRC_GXsfl_127 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_127"), ",", "."));
         nGXsfl_127_fel_idx = 0;
         while ( nGXsfl_127_fel_idx < nRC_GXsfl_127 )
         {
            nGXsfl_127_fel_idx = ((subActivepermissions_Islastpage==1)&&(nGXsfl_127_fel_idx+1>subActivepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_fel_idx+1);
            sGXsfl_127_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1272( ) ;
            AV46MultiRowItemSelected_ActivePermissions = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_activepermissions_Internalname));
            AV48Name = cgiGet( edtavName_Internalname);
            AV17Dsc = cgiGet( edtavDsc_Internalname);
            cmbavAccesstype.Name = cmbavAccesstype_Internalname;
            cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
            AV7AccessType = cgiGet( cmbavAccesstype_Internalname);
            AV40IsInherited = StringUtil.StrToBool( cgiGet( chkavIsinherited_Internalname));
            cmbavStoredaccesstype.Name = cmbavStoredaccesstype_Internalname;
            cmbavStoredaccesstype.CurrentValue = cgiGet( cmbavStoredaccesstype_Internalname);
            AV86StoredAccessType = cgiGet( cmbavStoredaccesstype_Internalname);
            AV88StoredIsInherited = StringUtil.StrToBool( cgiGet( chkavStoredisinherited_Internalname));
            AV37Id = cgiGet( edtavId_Internalname);
            AV82Delete_Action = cgiGet( edtavDelete_action_Internalname);
            if ( AV46MultiRowItemSelected_ActivePermissions != AV63CheckAll_ActivePermissions )
            {
               AV46MultiRowItemSelected_ActivePermissions = AV63CheckAll_ActivePermissions;
               AssignAttri(sPrefix, false, chkavMultirowitemselected_activepermissions_Internalname, AV46MultiRowItemSelected_ActivePermissions);
               /* Execute user subroutine: 'UPDATESELECTION(ACTIVEPERMISSIONS)' */
               S282 ();
               if (returnInSub) return;
            }
            /* End For Each Line */
         }
         if ( nGXsfl_127_fel_idx == 0 )
         {
            nGXsfl_127_idx = 1;
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         nGXsfl_127_fel_idx = 1;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_ACTIVEPERMISSIONS' */
         S292 ();
         if (returnInSub) return;
         if ( AV77CountSelectedItems_ActivePermissions > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(ACTIVEPERMISSIONS)' */
            S302 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(ACTIVEPERMISSIONS)' */
            S312 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(ACTIVEPERMISSIONS)' */
         S322 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66AllSelectedItems_ActivePermissions", AV66AllSelectedItems_ActivePermissions);
      }

      protected void S162( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_ACTIVEPERMISSIONS' */
         S292 ();
         if (returnInSub) return;
         if ( AV77CountSelectedItems_ActivePermissions > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(ACTIVEPERMISSIONS)' */
            S302 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(ACTIVEPERMISSIONS)' */
            S312 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'DISPLAYPERSISTENTACTIONS(ACTIVEPERMISSIONS)' */
         S362 ();
         if (returnInSub) return;
      }

      protected void S292( )
      {
         /* 'GETSELECTEDITEMSCOUNT_ACTIVEPERMISSIONS' Routine */
         returnInSub = false;
         AV77CountSelectedItems_ActivePermissions = 0;
         AssignAttri(sPrefix, false, "AV77CountSelectedItems_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV77CountSelectedItems_ActivePermissions), 4, 0));
         AV104GXV7 = 1;
         while ( AV104GXV7 <= AV66AllSelectedItems_ActivePermissions.Count )
         {
            AV64SelectedItem_ActivePermissions = ((SdtK2BSelectionItem)AV66AllSelectedItems_ActivePermissions.Item(AV104GXV7));
            if ( AV64SelectedItem_ActivePermissions.gxTpr_Isselected )
            {
               AV77CountSelectedItems_ActivePermissions = (short)(AV77CountSelectedItems_ActivePermissions+1);
               AssignAttri(sPrefix, false, "AV77CountSelectedItems_ActivePermissions", StringUtil.LTrimStr( (decimal)(AV77CountSelectedItems_ActivePermissions), 4, 0));
            }
            AV104GXV7 = (int)(AV104GXV7+1);
         }
      }

      protected void S372( )
      {
         /* 'GETFIELDVALUES_ACTIVEPERMISSIONS' Routine */
         returnInSub = false;
         AV105GXV8 = 1;
         while ( AV105GXV8 <= AV76FieldValues_ActivePermissions.Count )
         {
            AV65FieldValue_ActivePermissions = ((SdtK2BSelectionItem_FieldValuesItem)AV76FieldValues_ActivePermissions.Item(AV105GXV8));
            if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "Name") == 0 )
            {
               AV69S_Name = AV65FieldValue_ActivePermissions.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "Dsc") == 0 )
            {
               AV70S_Dsc = AV65FieldValue_ActivePermissions.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "AccessType") == 0 )
            {
               AV71S_AccessType = AV65FieldValue_ActivePermissions.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "IsInherited") == 0 )
            {
               AV74S_IsInherited = BooleanUtil.Val( AV65FieldValue_ActivePermissions.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "StoredAccessType") == 0 )
            {
               AV87S_StoredAccessType = AV65FieldValue_ActivePermissions.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "StoredIsInherited") == 0 )
            {
               AV89S_StoredIsInherited = BooleanUtil.Val( AV65FieldValue_ActivePermissions.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV65FieldValue_ActivePermissions.gxTpr_Name, "Id") == 0 )
            {
               AV72S_Id = AV65FieldValue_ActivePermissions.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV72S_Id", AV72S_Id);
            }
            AV105GXV8 = (int)(AV105GXV8+1);
         }
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV79K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! (0==AV14ApplicationId) )
         {
            AV80K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV80K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "ApplicationId";
            AV80K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Aplicación";
            AV80K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV80K2BFilterValuesSDTItem_WebForm.gxTpr_Value = StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0);
            AV80K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0);
            AV79K2BFilterValuesSDT_WebForm.Add(AV80K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( AV79K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_char2 = "";
            new GeneXus.Programs.k2bfsg.k2bgetfilterssummarywrapper(context ).execute(  AV97Pgmname,  "ActivePermissions",  AV79K2BFilterValuesSDT_WebForm, out  GXt_char2) ;
            lblLayoutdefined_filtersummary_combined_activepermissions_Caption = GXt_char2;
            AssignProp(sPrefix, false, lblLayoutdefined_filtersummary_combined_activepermissions_Internalname, "Caption", lblLayoutdefined_filtersummary_combined_activepermissions_Caption, true);
         }
         else
         {
            lblLayoutdefined_filtersummary_combined_activepermissions_Caption = "No hay filtros aplicados";
            AssignProp(sPrefix, false, lblLayoutdefined_filtersummary_combined_activepermissions_Internalname, "Caption", lblLayoutdefined_filtersummary_combined_activepermissions_Caption, true);
         }
      }

      protected void E28442( )
      {
         /* 'E_Delete' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_DELETE' */
         S332 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
         AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
      }

      protected void S332( )
      {
         /* 'U_DELETE' Routine */
         returnInSub = false;
         AV5GAMRole.load( AV6RoleId);
         AV41isOK = AV5GAMRole.deletepermissionbyid(AV14ApplicationId, AV37Id, out  AV19Errors);
         AssignAttri(sPrefix, false, "AV41isOK", AV41isOK);
         if ( ! AV41isOK )
         {
            AV60hasError = true;
            AV106GXV9 = 1;
            while ( AV106GXV9 <= AV19Errors.Count )
            {
               AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV106GXV9));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV106GXV9 = (int)(AV106GXV9+1);
            }
         }
         context.CommitDataStores("k2bfsg.roleselectpermission",pr_default);
         gxgrActivepermissions_refresh( AV6RoleId, AV85ClassCollection_ActivePermissions, AV75ApplicationId_PreviousValue, AV14ApplicationId, AV66AllSelectedItems_ActivePermissions, AV97Pgmname, AV15CurrentPage_ActivePermissions, AV83GenericFilter_ActivePermissions, AV77CountSelectedItems_ActivePermissions, AV84GridConfiguration, AV32HasNextPage_ActivePermissions, AV61RowsPerPage_ActivePermissions, AV37Id, AV9ActivePermissions_SelectedRows, AV35I_LoadCount_ActivePermissions, AV91FreezeColumnTitles_ActivePermissions, AV63CheckAll_ActivePermissions, sPrefix) ;
      }

      protected void E18442( )
      {
         /* Layoutdefined_filtertoggle_combined_activepermissions_Click Routine */
         returnInSub = false;
         if ( divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible = 0;
            AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap)), true);
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible = 1;
            AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap)), true);
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E19442( )
      {
         /* Layoutdefined_filterclose_combined_activepermissions_Click Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap)), true);
         AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void S342( )
      {
         /* 'TOGGLECOLLAPSIBLESECTION(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         if ( divGridcomponentcontent_activepermissions_Visible != 0 )
         {
            divGridcomponentcontent_activepermissions_Visible = 0;
            AssignProp(sPrefix, false, divGridcomponentcontent_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_activepermissions_Visible), 5, 0), true);
            imgCollapsibleimage_activepermissions_Bitmap = context.GetImagePath( "87ba2769-8aab-4613-b833-d06fcae04609", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgCollapsibleimage_activepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgCollapsibleimage_activepermissions_Bitmap)), true);
            AssignProp(sPrefix, false, imgCollapsibleimage_activepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgCollapsibleimage_activepermissions_Bitmap), true);
            divGridcomponent_activepermissions_Class = "K2BToolsTable_ComponentContainer"+" "+"K2BToolsTable_CollapsedComponentContainer";
            AssignProp(sPrefix, false, divGridcomponent_activepermissions_Internalname, "Class", divGridcomponent_activepermissions_Class, true);
         }
         else
         {
            divGridcomponentcontent_activepermissions_Visible = 1;
            AssignProp(sPrefix, false, divGridcomponentcontent_activepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridcomponentcontent_activepermissions_Visible), 5, 0), true);
            imgCollapsibleimage_activepermissions_Bitmap = context.GetImagePath( "cd4bc2b0-7bb2-4b77-aeb7-0c6632fa5484", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgCollapsibleimage_activepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgCollapsibleimage_activepermissions_Bitmap)), true);
            AssignProp(sPrefix, false, imgCollapsibleimage_activepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgCollapsibleimage_activepermissions_Bitmap), true);
            divGridcomponent_activepermissions_Class = "K2BToolsTable_ComponentContainer";
            AssignProp(sPrefix, false, divGridcomponent_activepermissions_Internalname, "Class", divGridcomponent_activepermissions_Class, true);
         }
      }

      protected void E20442( )
      {
         /* Gridtitle_activepermissions_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'TOGGLECOLLAPSIBLESECTION(ACTIVEPERMISSIONS)' */
         S342 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void E21442( )
      {
         /* Collapsibleimage_activepermissions_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'TOGGLECOLLAPSIBLESECTION(ACTIVEPERMISSIONS)' */
         S342 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_AFTERDATALOAD(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV97Pgmname,  "ActivePermissions", ref  AV84GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(ACTIVEPERMISSIONS)' */
         S382 ();
         if (returnInSub) return;
      }

      protected void E22442( )
      {
         /* 'E_SaveChanges' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_SAVECHANGES' */
         S352 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV90PermissionUpd", AV90PermissionUpd);
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14ApplicationId), 12, 0));
         AssignProp(sPrefix, false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV84GridConfiguration", AV84GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV85ClassCollection_ActivePermissions", AV85ClassCollection_ActivePermissions);
      }

      protected void S352( )
      {
         /* 'U_SAVECHANGES' Routine */
         returnInSub = false;
         AV5GAMRole.load( AV6RoleId);
         /* Start For Each Line in Activepermissions */
         nRC_GXsfl_127 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_127"), ",", "."));
         nGXsfl_127_fel_idx = 0;
         while ( nGXsfl_127_fel_idx < nRC_GXsfl_127 )
         {
            nGXsfl_127_fel_idx = ((subActivepermissions_Islastpage==1)&&(nGXsfl_127_fel_idx+1>subActivepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_fel_idx+1);
            sGXsfl_127_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1272( ) ;
            AV46MultiRowItemSelected_ActivePermissions = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_activepermissions_Internalname));
            AV48Name = cgiGet( edtavName_Internalname);
            AV17Dsc = cgiGet( edtavDsc_Internalname);
            cmbavAccesstype.Name = cmbavAccesstype_Internalname;
            cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
            AV7AccessType = cgiGet( cmbavAccesstype_Internalname);
            AV40IsInherited = StringUtil.StrToBool( cgiGet( chkavIsinherited_Internalname));
            cmbavStoredaccesstype.Name = cmbavStoredaccesstype_Internalname;
            cmbavStoredaccesstype.CurrentValue = cgiGet( cmbavStoredaccesstype_Internalname);
            AV86StoredAccessType = cgiGet( cmbavStoredaccesstype_Internalname);
            AV88StoredIsInherited = StringUtil.StrToBool( cgiGet( chkavStoredisinherited_Internalname));
            AV37Id = cgiGet( edtavId_Internalname);
            AV82Delete_Action = cgiGet( edtavDelete_action_Internalname);
            if ( ( StringUtil.StrCmp(AV7AccessType, AV86StoredAccessType) != 0 ) || ( AV40IsInherited != AV88StoredIsInherited ) )
            {
               AV90PermissionUpd.gxTpr_Applicationid = AV14ApplicationId;
               AV90PermissionUpd.gxTpr_Guid = AV37Id;
               AV90PermissionUpd.gxTpr_Type = AV7AccessType;
               AV90PermissionUpd.gxTpr_Inherited = AV40IsInherited;
               AV41isOK = AV5GAMRole.updatepermission(AV90PermissionUpd, out  AV19Errors);
               AssignAttri(sPrefix, false, "AV41isOK", AV41isOK);
               if ( ! AV41isOK )
               {
                  AV108GXV10 = 1;
                  while ( AV108GXV10 <= AV19Errors.Count )
                  {
                     AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV108GXV10));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV108GXV10 = (int)(AV108GXV10+1);
                  }
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_127_fel_idx == 0 )
         {
            nGXsfl_127_idx = 1;
            sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
            SubsflControlProps_1272( ) ;
         }
         nGXsfl_127_fel_idx = 1;
         if ( AV41isOK )
         {
            context.CommitDataStores("k2bfsg.roleselectpermission",pr_default);
            GX_msglist.addItem(StringUtil.Format( "El rol %1 fue actualizado", AV5GAMRole.gxTpr_Name, "", "", "", "", "", "", "", ""));
         }
         else
         {
            AV109GXV11 = 1;
            while ( AV109GXV11 <= AV19Errors.Count )
            {
               AV18Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV19Errors.Item(AV109GXV11));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV18Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV18Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV109GXV11 = (int)(AV109GXV11+1);
            }
         }
         gxgrActivepermissions_refresh( AV6RoleId, AV85ClassCollection_ActivePermissions, AV75ApplicationId_PreviousValue, AV14ApplicationId, AV66AllSelectedItems_ActivePermissions, AV97Pgmname, AV15CurrentPage_ActivePermissions, AV83GenericFilter_ActivePermissions, AV77CountSelectedItems_ActivePermissions, AV84GridConfiguration, AV32HasNextPage_ActivePermissions, AV61RowsPerPage_ActivePermissions, AV37Id, AV9ActivePermissions_SelectedRows, AV35I_LoadCount_ActivePermissions, AV91FreezeColumnTitles_ActivePermissions, AV63CheckAll_ActivePermissions, sPrefix) ;
      }

      protected void S382( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(ACTIVEPERMISSIONS)' Routine */
         returnInSub = false;
         AV91FreezeColumnTitles_ActivePermissions = AV84GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri(sPrefix, false, "AV91FreezeColumnTitles_ActivePermissions", AV91FreezeColumnTitles_ActivePermissions);
         if ( AV91FreezeColumnTitles_ActivePermissions )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV85ClassCollection_ActivePermissions) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV85ClassCollection_ActivePermissions) ;
         }
      }

      protected void wb_table5_139_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_activepermissions_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_activepermissions_Internalname, tblI_noresultsfoundtablename_activepermissions_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_activepermissions_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_activepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_139_442e( true) ;
         }
         else
         {
            wb_table5_139_442e( false) ;
         }
      }

      protected void wb_table4_121_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainer_activepermissions_Internalname, tblTablegridcontainer_activepermissions_Internalname, "", "K2BToolsTable_GridContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'" + sPrefix + "',false,'" + sGXsfl_127_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_activepermissions_Internalname, StringUtil.BoolToStr( AV63CheckAll_ActivePermissions), "", "", 1, chkavCheckall_activepermissions.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,125);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            ActivepermissionsContainer.SetWrapped(nGXWrapped);
            if ( ActivepermissionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"ActivepermissionsContainer"+"DivS\" data-gxgridid=\"127\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subActivepermissions_Internalname, subActivepermissions_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subActivepermissions_Backcolorstyle == 0 )
               {
                  subActivepermissions_Titlebackstyle = 0;
                  if ( StringUtil.Len( subActivepermissions_Class) > 0 )
                  {
                     subActivepermissions_Linesclass = subActivepermissions_Class+"Title";
                  }
               }
               else
               {
                  subActivepermissions_Titlebackstyle = 1;
                  if ( subActivepermissions_Backcolorstyle == 1 )
                  {
                     subActivepermissions_Titlebackcolor = subActivepermissions_Allbackcolor;
                     if ( StringUtil.Len( subActivepermissions_Class) > 0 )
                     {
                        subActivepermissions_Linesclass = subActivepermissions_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subActivepermissions_Class) > 0 )
                     {
                        subActivepermissions_Linesclass = subActivepermissions_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripción") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de acceso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Es heredado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Tipo de acceso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Es heredado") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Invisible"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"Image_Action"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               ActivepermissionsContainer.AddObjectProperty("GridName", "Activepermissions");
            }
            else
            {
               ActivepermissionsContainer.AddObjectProperty("GridName", "Activepermissions");
               ActivepermissionsContainer.AddObjectProperty("Header", subActivepermissions_Header);
               ActivepermissionsContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
               ActivepermissionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Backcolorstyle), 1, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Sortable), 1, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("CmpContext", sPrefix);
               ActivepermissionsContainer.AddObjectProperty("InMasterPage", "false");
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV46MultiRowItemSelected_ActivePermissions));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV48Name));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV17Dsc));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV7AccessType));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavAccesstype.Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV40IsInherited));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavIsinherited.Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV86StoredAccessType));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavStoredaccesstype.Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV88StoredIsInherited));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavStoredisinherited.Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV37Id));
               ActivepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               ActivepermissionsColumn.AddObjectProperty("Value", context.convertURL( AV82Delete_Action));
               ActivepermissionsColumn.AddObjectProperty("Tooltiptext", StringUtil.RTrim( edtavDelete_action_Tooltiptext));
               ActivepermissionsContainer.AddColumnProperties(ActivepermissionsColumn);
               ActivepermissionsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Selectedindex), 4, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Allowselection), 1, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Selectioncolor), 9, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Allowhovering), 1, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Hoveringcolor), 9, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Allowcollapsing), 1, 0, ".", "")));
               ActivepermissionsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subActivepermissions_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 127 )
         {
            wbEnd = 0;
            nRC_GXsfl_127 = (int)(nGXsfl_127_idx-1);
            if ( ActivepermissionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"ActivepermissionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Activepermissions", ActivepermissionsContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"ActivepermissionsContainerData", ActivepermissionsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"ActivepermissionsContainerData"+"V", ActivepermissionsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"ActivepermissionsContainerData"+"V"+"\" value='"+ActivepermissionsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_121_442e( true) ;
         }
         else
         {
            wb_table4_121_442e( false) ;
         }
      }

      protected void wb_table3_109_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_activepermissions_gridassociatedleft_Internalname, tblActions_activepermissions_gridassociatedleft_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = imgDeletemultiple_Bitmap;
            GxWebStd.gx_bitmap( context, imgDeletemultiple_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgDeletemultiple_Visible, 1, "K2BT_DeleteAction", imgDeletemultiple_Tooltiptext, 0, 0, 0, "px", 0, "px", 0, 0, 5, imgDeletemultiple_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETEMULTIPLE\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttSavechanges_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "Save Changes", bttSavechanges_Jsonclick, 5, "", "", StyleString, ClassString, bttSavechanges_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_SAVECHANGES\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleSelectPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_109_442e( true) ;
         }
         else
         {
            wb_table3_109_442e( false) ;
         }
      }

      protected void wb_table2_61_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_activepermissions_Internalname, tblLayoutdefined_table7_activepermissions_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelactivepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelactivepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+"e29441_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertableactivepermissions_Internalname, divGridsettings_contentoutertableactivepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_activepermissionscontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_activepermissionsruntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblGslayoutdefined_activepermissionsruntimecolumnselectiontb_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_activepermissionscustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_activepermissions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_activepermissions_Internalname, "Filas por página", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'" + sPrefix + "',false,'" + sGXsfl_127_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_activepermissions, cmbavGridsettingsrowsperpage_activepermissions_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0)), 1, cmbavGridsettingsrowsperpage_activepermissions_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_activepermissions.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,87);\"", "", true, 1, "HLP_K2BFSG\\RoleSelectPermission.htm");
            cmbavGridsettingsrowsperpage_activepermissions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV62GridSettingsRowsPerPage_ActivePermissions), 4, 0));
            AssignProp(sPrefix, false, cmbavGridsettingsrowsperpage_activepermissions_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_activepermissions.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_activepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_activepermissions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_activepermissions_Internalname, "Inmovilizar títulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'" + sPrefix + "',false,'" + sGXsfl_127_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_activepermissions_Internalname, StringUtil.BoolToStr( AV91FreezeColumnTitles_ActivePermissions), "", "Inmovilizar títulos", 1, chkavFreezecolumntitles_activepermissions.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(93, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,93);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_saveactivepermissions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "Aplicar", bttGridsettings_saveactivepermissions_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'SAVEGRIDSETTINGS(ACTIVEPERMISSIONS)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleSelectPermission.htm");
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
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table6_98_442( true) ;
         }
         else
         {
            wb_table6_98_442( false) ;
         }
         return  ;
      }

      protected void wb_table6_98_442e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_61_442e( true) ;
         }
         else
         {
            wb_table2_61_442e( false) ;
         }
      }

      protected void wb_table6_98_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_activepermissions_topright_Internalname, tblActions_activepermissions_topright_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsAction_AddNew";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAdd_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(127), 3, 0)+","+"null"+");", "Nuevo", bttAdd_Jsonclick, 5, "", "", StyleString, ClassString, bttAdd_Visible, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_ADD\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleSelectPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_98_442e( true) ;
         }
         else
         {
            wb_table6_98_442e( false) ;
         }
      }

      protected void wb_table1_15_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblGridtitlecontainertable_activepermissions_Internalname, tblGridtitlecontainertable_activepermissions_Internalname, "", "Table_Basic_Widht100Percent", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGridtitle_activepermissions_Internalname, "Permisos", "", "", lblGridtitle_activepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EGRIDTITLE_ACTIVEPERMISSIONS.CLICK."+"'", "", "TextBlock_Subtitle", 5, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table7_20_442( true) ;
         }
         else
         {
            wb_table7_20_442( false) ;
         }
         return  ;
      }

      protected void wb_table7_20_442e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_442e( true) ;
         }
         else
         {
            wb_table1_15_442e( false) ;
         }
      }

      protected void wb_table7_20_442( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblCollapsibleimagecontainer_activepermissions_Internalname, tblCollapsibleimagecontainer_activepermissions_Internalname, "", "K2BToolsTable_FloatRight", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BT_CollapseCardImage";
            StyleString = "";
            sImgUrl = imgCollapsibleimage_activepermissions_Bitmap;
            GxWebStd.gx_bitmap( context, imgCollapsibleimage_activepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgCollapsibleimage_activepermissions_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECOLLAPSIBLEIMAGE_ACTIVEPERMISSIONS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table7_20_442e( true) ;
         }
         else
         {
            wb_table7_20_442e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6RoleId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 12, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA442( ) ;
         WS442( ) ;
         WE442( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6RoleId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA442( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\roleselectpermission", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA442( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6RoleId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 12, 0));
         }
         wcpOAV6RoleId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6RoleId"), ",", "."));
         if ( ! GetJustCreated( ) && ( ( AV6RoleId != wcpOAV6RoleId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6RoleId = AV6RoleId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6RoleId = cgiGet( sPrefix+"AV6RoleId_CTRL");
         if ( StringUtil.Len( sCtrlAV6RoleId) > 0 )
         {
            AV6RoleId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV6RoleId), ",", "."));
            AssignAttri(sPrefix, false, "AV6RoleId", StringUtil.LTrimStr( (decimal)(AV6RoleId), 12, 0));
         }
         else
         {
            AV6RoleId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV6RoleId_PARM"), ",", "."));
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
         INITWEB( ) ;
         nDraw = 0;
         PA442( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS442( ) ;
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
         WS442( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6RoleId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6RoleId), 12, 0, ",", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6RoleId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6RoleId_CTRL", StringUtil.RTrim( sCtrlAV6RoleId));
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
            WE442( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20231249495913", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("k2bfsg/roleselectpermission.js", "?20231249495918", false, true);
            context.AddJavascriptSource("K2BControlBeautify/silviomoreto-bootstrap-select/dist/js/bootstrap-select.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1272( )
      {
         chkavMultirowitemselected_activepermissions_Internalname = sPrefix+"vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS_"+sGXsfl_127_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_127_idx;
         edtavDsc_Internalname = sPrefix+"vDSC_"+sGXsfl_127_idx;
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE_"+sGXsfl_127_idx;
         chkavIsinherited_Internalname = sPrefix+"vISINHERITED_"+sGXsfl_127_idx;
         cmbavStoredaccesstype_Internalname = sPrefix+"vSTOREDACCESSTYPE_"+sGXsfl_127_idx;
         chkavStoredisinherited_Internalname = sPrefix+"vSTOREDISINHERITED_"+sGXsfl_127_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_127_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_127_idx;
      }

      protected void SubsflControlProps_fel_1272( )
      {
         chkavMultirowitemselected_activepermissions_Internalname = sPrefix+"vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS_"+sGXsfl_127_fel_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_127_fel_idx;
         edtavDsc_Internalname = sPrefix+"vDSC_"+sGXsfl_127_fel_idx;
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE_"+sGXsfl_127_fel_idx;
         chkavIsinherited_Internalname = sPrefix+"vISINHERITED_"+sGXsfl_127_fel_idx;
         cmbavStoredaccesstype_Internalname = sPrefix+"vSTOREDACCESSTYPE_"+sGXsfl_127_fel_idx;
         chkavStoredisinherited_Internalname = sPrefix+"vSTOREDISINHERITED_"+sGXsfl_127_fel_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_127_fel_idx;
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION_"+sGXsfl_127_fel_idx;
      }

      protected void sendrow_1272( )
      {
         SubsflControlProps_1272( ) ;
         WB440( ) ;
         ActivepermissionsRow = GXWebRow.GetNew(context,ActivepermissionsContainer);
         if ( subActivepermissions_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subActivepermissions_Backstyle = 0;
            if ( StringUtil.StrCmp(subActivepermissions_Class, "") != 0 )
            {
               subActivepermissions_Linesclass = subActivepermissions_Class+"Odd";
            }
         }
         else if ( subActivepermissions_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subActivepermissions_Backstyle = 0;
            subActivepermissions_Backcolor = subActivepermissions_Allbackcolor;
            if ( StringUtil.StrCmp(subActivepermissions_Class, "") != 0 )
            {
               subActivepermissions_Linesclass = subActivepermissions_Class+"Uniform";
            }
         }
         else if ( subActivepermissions_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subActivepermissions_Backstyle = 1;
            if ( StringUtil.StrCmp(subActivepermissions_Class, "") != 0 )
            {
               subActivepermissions_Linesclass = subActivepermissions_Class+"Odd";
            }
            subActivepermissions_Backcolor = (int)(0x0);
         }
         else if ( subActivepermissions_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subActivepermissions_Backstyle = 1;
            if ( ((int)((nGXsfl_127_idx) % (2))) == 0 )
            {
               subActivepermissions_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subActivepermissions_Class, "") != 0 )
               {
                  subActivepermissions_Linesclass = subActivepermissions_Class+"Even";
               }
            }
            else
            {
               subActivepermissions_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subActivepermissions_Class, "") != 0 )
               {
                  subActivepermissions_Linesclass = subActivepermissions_Class+"Odd";
               }
            }
         }
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_127_idx+"\">") ;
         }
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_activepermissions.Enabled!=0)&&(chkavMultirowitemselected_activepermissions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 128,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS_" + sGXsfl_127_idx;
         chkavMultirowitemselected_activepermissions.Name = GXCCtl;
         chkavMultirowitemselected_activepermissions.WebTags = "";
         chkavMultirowitemselected_activepermissions.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_activepermissions_Internalname, "TitleCaption", chkavMultirowitemselected_activepermissions.Caption, !bGXsfl_127_Refreshing);
         chkavMultirowitemselected_activepermissions.CheckedValue = "false";
         ActivepermissionsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_activepermissions_Internalname,StringUtil.BoolToStr( AV46MultiRowItemSelected_ActivePermissions),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_activepermissions.Enabled!=0)&&(chkavMultirowitemselected_activepermissions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,128);\"" : " ")});
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 129,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         ROClassString = "Attribute_Grid";
         ActivepermissionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV48Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,129);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 130,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         ROClassString = "Attribute_Grid";
         ActivepermissionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV17Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,130);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 131,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         GXCCtl = "vACCESSTYPE_" + sGXsfl_127_idx;
         cmbavAccesstype.Name = GXCCtl;
         cmbavAccesstype.WebTags = "";
         cmbavAccesstype.addItem("A", "Allow", 0);
         cmbavAccesstype.addItem("D", "Deny", 0);
         cmbavAccesstype.addItem("R", "Restricted", 0);
         if ( cmbavAccesstype.ItemCount > 0 )
         {
            AV7AccessType = cmbavAccesstype.getValidValue(AV7AccessType);
            AssignAttri(sPrefix, false, cmbavAccesstype_Internalname, AV7AccessType);
         }
         /* ComboBox */
         ActivepermissionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAccesstype,(string)cmbavAccesstype_Internalname,StringUtil.RTrim( AV7AccessType),(short)1,(string)cmbavAccesstype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbavAccesstype.Enabled,(short)1,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute_Grid",(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,131);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV7AccessType);
         AssignProp(sPrefix, false, cmbavAccesstype_Internalname, "Values", (string)(cmbavAccesstype.ToJavascriptSource()), !bGXsfl_127_Refreshing);
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavIsinherited.Enabled!=0)&&(chkavIsinherited.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 132,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         ClassString = "Attribute_Grid";
         StyleString = "";
         GXCCtl = "vISINHERITED_" + sGXsfl_127_idx;
         chkavIsinherited.Name = GXCCtl;
         chkavIsinherited.WebTags = "";
         chkavIsinherited.Caption = "";
         AssignProp(sPrefix, false, chkavIsinherited_Internalname, "TitleCaption", chkavIsinherited.Caption, !bGXsfl_127_Refreshing);
         chkavIsinherited.CheckedValue = "false";
         ActivepermissionsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavIsinherited_Internalname,StringUtil.BoolToStr( AV40IsInherited),(string)"",(string)"",(short)-1,chkavIsinherited.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(132, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavIsinherited.Enabled!=0)&&(chkavIsinherited.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,132);\"" : " ")});
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         TempTags = " " + ((cmbavStoredaccesstype.Enabled!=0)&&(cmbavStoredaccesstype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 133,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         if ( ( cmbavStoredaccesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vSTOREDACCESSTYPE_" + sGXsfl_127_idx;
            cmbavStoredaccesstype.Name = GXCCtl;
            cmbavStoredaccesstype.WebTags = "";
            cmbavStoredaccesstype.addItem("A", "Allow", 0);
            cmbavStoredaccesstype.addItem("D", "Deny", 0);
            cmbavStoredaccesstype.addItem("R", "Restricted", 0);
            if ( cmbavStoredaccesstype.ItemCount > 0 )
            {
               AV86StoredAccessType = cmbavStoredaccesstype.getValidValue(AV86StoredAccessType);
               AssignAttri(sPrefix, false, cmbavStoredaccesstype_Internalname, AV86StoredAccessType);
               GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vSTOREDACCESSTYPE"+"_"+sGXsfl_127_idx, GetSecureSignedToken( sPrefix+sGXsfl_127_idx, StringUtil.RTrim( context.localUtil.Format( AV86StoredAccessType, "")), context));
            }
         }
         /* ComboBox */
         ActivepermissionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavStoredaccesstype,(string)cmbavStoredaccesstype_Internalname,StringUtil.RTrim( AV86StoredAccessType),(short)1,(string)cmbavStoredaccesstype_Jsonclick,(short)0,(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavStoredaccesstype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute_Grid",(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavStoredaccesstype.Enabled!=0)&&(cmbavStoredaccesstype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,133);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavStoredaccesstype.CurrentValue = StringUtil.RTrim( AV86StoredAccessType);
         AssignProp(sPrefix, false, cmbavStoredaccesstype_Internalname, "Values", (string)(cmbavStoredaccesstype.ToJavascriptSource()), !bGXsfl_127_Refreshing);
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavStoredisinherited.Enabled!=0)&&(chkavStoredisinherited.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 134,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         ClassString = "Attribute_Grid";
         StyleString = "";
         GXCCtl = "vSTOREDISINHERITED_" + sGXsfl_127_idx;
         chkavStoredisinherited.Name = GXCCtl;
         chkavStoredisinherited.WebTags = "";
         chkavStoredisinherited.Caption = "";
         AssignProp(sPrefix, false, chkavStoredisinherited_Internalname, "TitleCaption", chkavStoredisinherited.Caption, !bGXsfl_127_Refreshing);
         chkavStoredisinherited.CheckedValue = "false";
         ActivepermissionsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavStoredisinherited_Internalname,StringUtil.BoolToStr( AV88StoredIsInherited),(string)"",(string)"",(short)0,chkavStoredisinherited.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(134, this, 'true', 'false',"+"'"+sPrefix+"'"+");"+"gx.evt.onchange(this, event);\""+((chkavStoredisinherited.Enabled!=0)&&(chkavStoredisinherited.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,134);\"" : " ")});
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 135,'"+sPrefix+"',false,'"+sGXsfl_127_idx+"',127)\"" : " ");
         ROClassString = "Attribute_Invisible";
         ActivepermissionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV37Id),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,135);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Invisible",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)127,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( ActivepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Active Bitmap Variable */
         TempTags = " " + ((edtavDelete_action_Enabled!=0)&&(edtavDelete_action_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 136,'"+sPrefix+"',false,'',127)\"" : " ");
         ClassString = "Image_Action";
         StyleString = "";
         AV82Delete_Action_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV82Delete_Action))&&String.IsNullOrEmpty(StringUtil.RTrim( AV98Delete_action_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV82Delete_Action)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV82Delete_Action)) ? AV98Delete_action_GXI : context.PathToRelativeUrl( AV82Delete_Action));
         ActivepermissionsRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_action_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"Delete",(string)edtavDelete_action_Tooltiptext,(short)0,(short)1,(short)20,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)5,(string)edtavDelete_action_Jsonclick,"'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_DELETE\\'."+sGXsfl_127_idx+"'",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn ActionColumn ActionVisibleOnRowHover",(string)"",(string)"",(string)"",(string)""+TempTags,(string)"",(string)"",(short)1,(bool)AV82Delete_Action_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes442( ) ;
         ActivepermissionsContainer.AddRow(ActivepermissionsRow);
         nGXsfl_127_idx = ((subActivepermissions_Islastpage==1)&&(nGXsfl_127_idx+1>subActivepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_127_idx+1);
         sGXsfl_127_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_127_idx), 4, 0), 4, "0");
         SubsflControlProps_1272( ) ;
         /* End function sendrow_1272 */
      }

      protected void init_web_controls( )
      {
         cmbavApplicationid.Name = "vAPPLICATIONID";
         cmbavApplicationid.WebTags = "";
         if ( cmbavApplicationid.ItemCount > 0 )
         {
         }
         cmbavGridsettingsrowsperpage_activepermissions.Name = "vGRIDSETTINGSROWSPERPAGE_ACTIVEPERMISSIONS";
         cmbavGridsettingsrowsperpage_activepermissions.WebTags = "";
         cmbavGridsettingsrowsperpage_activepermissions.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_activepermissions.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_activepermissions.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_activepermissions.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_activepermissions.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_activepermissions.ItemCount > 0 )
         {
         }
         chkavFreezecolumntitles_activepermissions.Name = "vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS";
         chkavFreezecolumntitles_activepermissions.WebTags = "";
         chkavFreezecolumntitles_activepermissions.Caption = "";
         AssignProp(sPrefix, false, chkavFreezecolumntitles_activepermissions_Internalname, "TitleCaption", chkavFreezecolumntitles_activepermissions.Caption, true);
         chkavFreezecolumntitles_activepermissions.CheckedValue = "false";
         chkavCheckall_activepermissions.Name = "vCHECKALL_ACTIVEPERMISSIONS";
         chkavCheckall_activepermissions.WebTags = "";
         chkavCheckall_activepermissions.Caption = "";
         AssignProp(sPrefix, false, chkavCheckall_activepermissions_Internalname, "TitleCaption", chkavCheckall_activepermissions.Caption, true);
         chkavCheckall_activepermissions.CheckedValue = "false";
         GXCCtl = "vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS_" + sGXsfl_127_idx;
         chkavMultirowitemselected_activepermissions.Name = GXCCtl;
         chkavMultirowitemselected_activepermissions.WebTags = "";
         chkavMultirowitemselected_activepermissions.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_activepermissions_Internalname, "TitleCaption", chkavMultirowitemselected_activepermissions.Caption, !bGXsfl_127_Refreshing);
         chkavMultirowitemselected_activepermissions.CheckedValue = "false";
         GXCCtl = "vACCESSTYPE_" + sGXsfl_127_idx;
         cmbavAccesstype.Name = GXCCtl;
         cmbavAccesstype.WebTags = "";
         cmbavAccesstype.addItem("A", "Allow", 0);
         cmbavAccesstype.addItem("D", "Deny", 0);
         cmbavAccesstype.addItem("R", "Restricted", 0);
         if ( cmbavAccesstype.ItemCount > 0 )
         {
         }
         GXCCtl = "vISINHERITED_" + sGXsfl_127_idx;
         chkavIsinherited.Name = GXCCtl;
         chkavIsinherited.WebTags = "";
         chkavIsinherited.Caption = "";
         AssignProp(sPrefix, false, chkavIsinherited_Internalname, "TitleCaption", chkavIsinherited.Caption, !bGXsfl_127_Refreshing);
         chkavIsinherited.CheckedValue = "false";
         GXCCtl = "vSTOREDACCESSTYPE_" + sGXsfl_127_idx;
         cmbavStoredaccesstype.Name = GXCCtl;
         cmbavStoredaccesstype.WebTags = "";
         cmbavStoredaccesstype.addItem("A", "Allow", 0);
         cmbavStoredaccesstype.addItem("D", "Deny", 0);
         cmbavStoredaccesstype.addItem("R", "Restricted", 0);
         if ( cmbavStoredaccesstype.ItemCount > 0 )
         {
         }
         GXCCtl = "vSTOREDISINHERITED_" + sGXsfl_127_idx;
         chkavStoredisinherited.Name = GXCCtl;
         chkavStoredisinherited.WebTags = "";
         chkavStoredisinherited.Caption = "";
         AssignProp(sPrefix, false, chkavStoredisinherited_Internalname, "TitleCaption", chkavStoredisinherited.Caption, !bGXsfl_127_Refreshing);
         chkavStoredisinherited.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGridtitle_activepermissions_Internalname = sPrefix+"GRIDTITLE_ACTIVEPERMISSIONS";
         imgCollapsibleimage_activepermissions_Internalname = sPrefix+"COLLAPSIBLEIMAGE_ACTIVEPERMISSIONS";
         tblCollapsibleimagecontainer_activepermissions_Internalname = sPrefix+"COLLAPSIBLEIMAGECONTAINER_ACTIVEPERMISSIONS";
         tblGridtitlecontainertable_activepermissions_Internalname = sPrefix+"GRIDTITLECONTAINERTABLE_ACTIVEPERMISSIONS";
         edtavGenericfilter_activepermissions_Internalname = sPrefix+"vGENERICFILTER_ACTIVEPERMISSIONS";
         imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_FILTERTOGGLE_COMBINED_ACTIVEPERMISSIONS";
         lblLayoutdefined_filtersummary_combined_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_FILTERSUMMARY_COMBINED_ACTIVEPERMISSIONS";
         divLayoutdefined_section4_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_SECTION4_ACTIVEPERMISSIONS";
         imgLayoutdefined_filterclose_combined_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCLOSE_COMBINED_ACTIVEPERMISSIONS";
         cmbavApplicationid_Internalname = sPrefix+"vAPPLICATIONID";
         divTable_container_applicationid_Internalname = sPrefix+"TABLE_CONTAINER_APPLICATIONID";
         divFiltercontainertable_filters_Internalname = sPrefix+"FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = sPrefix+"MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS";
         divLayoutdefined_combinedfilterlayout_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_COMBINEDFILTERLAYOUT_ACTIVEPERMISSIONS";
         divLayoutdefined_filterglobalcontainer_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_FILTERGLOBALCONTAINER_ACTIVEPERMISSIONS";
         imgGridsettings_labelactivepermissions_Internalname = sPrefix+"GRIDSETTINGS_LABELACTIVEPERMISSIONS";
         lblGslayoutdefined_activepermissionsruntimecolumnselectiontb_Internalname = sPrefix+"GSLAYOUTDEFINED_ACTIVEPERMISSIONSRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_activepermissions_Internalname = sPrefix+"vGRIDSETTINGSROWSPERPAGE_ACTIVEPERMISSIONS";
         divRowsperpagecontainer_activepermissions_Internalname = sPrefix+"ROWSPERPAGECONTAINER_ACTIVEPERMISSIONS";
         chkavFreezecolumntitles_activepermissions_Internalname = sPrefix+"vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS";
         divFreezecolumntitlescontainer_activepermissions_Internalname = sPrefix+"FREEZECOLUMNTITLESCONTAINER_ACTIVEPERMISSIONS";
         bttGridsettings_saveactivepermissions_Internalname = sPrefix+"GRIDSETTINGS_SAVEACTIVEPERMISSIONS";
         divGslayoutdefined_activepermissionscustomizationcollapsiblesection_Internalname = sPrefix+"GSLAYOUTDEFINED_ACTIVEPERMISSIONSCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_activepermissions_Internalname = sPrefix+"GRIDCUSTOMIZATIONCONTAINER_ACTIVEPERMISSIONS";
         divGslayoutdefined_activepermissionscontentinnertable_Internalname = sPrefix+"GSLAYOUTDEFINED_ACTIVEPERMISSIONSCONTENTINNERTABLE";
         divGridsettings_contentoutertableactivepermissions_Internalname = sPrefix+"GRIDSETTINGS_CONTENTOUTERTABLEACTIVEPERMISSIONS";
         divGridsettings_globaltable_activepermissions_Internalname = sPrefix+"GRIDSETTINGS_GLOBALTABLE_ACTIVEPERMISSIONS";
         bttAdd_Internalname = sPrefix+"ADD";
         tblActions_activepermissions_topright_Internalname = sPrefix+"ACTIONS_ACTIVEPERMISSIONS_TOPRIGHT";
         tblLayoutdefined_table7_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_ACTIVEPERMISSIONS";
         divLayoutdefined_table10_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_ACTIVEPERMISSIONS";
         imgDeletemultiple_Internalname = sPrefix+"DELETEMULTIPLE";
         bttSavechanges_Internalname = sPrefix+"SAVECHANGES";
         tblActions_activepermissions_gridassociatedleft_Internalname = sPrefix+"ACTIONS_ACTIVEPERMISSIONS_GRIDASSOCIATEDLEFT";
         divLayoutdefined_section7_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_SECTION7_ACTIVEPERMISSIONS";
         divLayoutdefined_section3_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_SECTION3_ACTIVEPERMISSIONS";
         divLayoutdefined_section1_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_SECTION1_ACTIVEPERMISSIONS";
         chkavCheckall_activepermissions_Internalname = sPrefix+"vCHECKALL_ACTIVEPERMISSIONS";
         chkavMultirowitemselected_activepermissions_Internalname = sPrefix+"vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS";
         edtavName_Internalname = sPrefix+"vNAME";
         edtavDsc_Internalname = sPrefix+"vDSC";
         cmbavAccesstype_Internalname = sPrefix+"vACCESSTYPE";
         chkavIsinherited_Internalname = sPrefix+"vISINHERITED";
         cmbavStoredaccesstype_Internalname = sPrefix+"vSTOREDACCESSTYPE";
         chkavStoredisinherited_Internalname = sPrefix+"vSTOREDISINHERITED";
         edtavId_Internalname = sPrefix+"vID";
         edtavDelete_action_Internalname = sPrefix+"vDELETE_ACTION";
         tblTablegridcontainer_activepermissions_Internalname = sPrefix+"TABLEGRIDCONTAINER_ACTIVEPERMISSIONS";
         lblI_noresultsfoundtextblock_activepermissions_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_ACTIVEPERMISSIONS";
         tblI_noresultsfoundtablename_activepermissions_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_ACTIVEPERMISSIONS";
         divMaingrid_responsivetable_activepermissions_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS";
         lblPaginationbar_previouspagebuttontextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_firstpagetextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_FIRSTPAGETEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_spacinglefttextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_SPACINGLEFTTEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_previouspagetextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_currentpagetextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_CURRENTPAGETEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_nextpagetextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGETEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_spacingrighttextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKACTIVEPERMISSIONS";
         lblPaginationbar_nextpagebuttontextblockactivepermissions_Internalname = sPrefix+"PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKACTIVEPERMISSIONS";
         divPaginationbar_pagingcontainertable_activepermissions_Internalname = sPrefix+"PAGINATIONBAR_PAGINGCONTAINERTABLE_ACTIVEPERMISSIONS";
         divLayoutdefined_section8_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_SECTION8_ACTIVEPERMISSIONS";
         divLayoutdefined_table3_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_ACTIVEPERMISSIONS";
         divLayoutdefined_grid_inner_activepermissions_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_ACTIVEPERMISSIONS";
         divGridcomponentcontent_activepermissions_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS";
         divGridcomponent_activepermissions_Internalname = sPrefix+"GRIDCOMPONENT_ACTIVEPERMISSIONS";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subActivepermissions_Internalname = sPrefix+"ACTIVEPERMISSIONS";
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
         chkavCheckall_activepermissions.Caption = "";
         chkavFreezecolumntitles_activepermissions.Caption = "Inmovilizar títulos";
         edtavDelete_action_Jsonclick = "";
         edtavDelete_action_Visible = -1;
         edtavDelete_action_Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         chkavStoredisinherited.Caption = "";
         chkavStoredisinherited.Visible = 0;
         cmbavStoredaccesstype_Jsonclick = "";
         cmbavStoredaccesstype.Visible = 0;
         chkavIsinherited.Caption = "";
         chkavIsinherited.Visible = -1;
         cmbavAccesstype_Jsonclick = "";
         cmbavAccesstype.Visible = -1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Visible = -1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         chkavMultirowitemselected_activepermissions.Caption = "";
         chkavMultirowitemselected_activepermissions.Visible = -1;
         chkavMultirowitemselected_activepermissions.Enabled = 1;
         imgCollapsibleimage_activepermissions_Bitmap = (string)(context.GetImagePath( "cd4bc2b0-7bb2-4b77-aeb7-0c6632fa5484", "", context.GetTheme( )));
         bttAdd_Visible = 1;
         chkavFreezecolumntitles_activepermissions.Enabled = 1;
         cmbavGridsettingsrowsperpage_activepermissions_Jsonclick = "";
         cmbavGridsettingsrowsperpage_activepermissions.Enabled = 1;
         divGridsettings_contentoutertableactivepermissions_Visible = 1;
         bttSavechanges_Visible = 1;
         imgDeletemultiple_Visible = 1;
         imgDeletemultiple_Bitmap = (string)(context.GetImagePath( "3e4a9f50-2c57-41b6-9da5-ebe49bca33c0", "", context.GetTheme( )));
         subActivepermissions_Allowcollapsing = 0;
         subActivepermissions_Allowselection = 0;
         edtavDelete_action_Tooltiptext = "";
         edtavId_Enabled = 1;
         chkavStoredisinherited.Enabled = 1;
         cmbavStoredaccesstype.Enabled = 1;
         edtavDsc_Enabled = 1;
         edtavName_Enabled = 1;
         subActivepermissions_Header = "";
         subActivepermissions_Class = "K2BT_SG Grid_WorkWith";
         subActivepermissions_Backcolorstyle = 0;
         chkavCheckall_activepermissions.Enabled = 1;
         imgDeletemultiple_Tooltiptext = "Eliminar";
         chkavIsinherited.Enabled = 1;
         cmbavAccesstype.Enabled = 1;
         tblI_noresultsfoundtablename_activepermissions_Visible = 1;
         subActivepermissions_Sortable = 0;
         lblPaginationbar_nextpagebuttontextblockactivepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockactivepermissions_Visible = 1;
         lblPaginationbar_nextpagetextblockactivepermissions_Caption = "#";
         lblPaginationbar_nextpagetextblockactivepermissions_Visible = 1;
         lblPaginationbar_currentpagetextblockactivepermissions_Caption = "#";
         lblPaginationbar_previouspagetextblockactivepermissions_Caption = "#";
         lblPaginationbar_previouspagetextblockactivepermissions_Visible = 1;
         lblPaginationbar_spacinglefttextblockactivepermissions_Visible = 1;
         lblPaginationbar_firstpagetextblockactivepermissions_Caption = "1";
         lblPaginationbar_firstpagetextblockactivepermissions_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockactivepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_activepermissions_Visible = 1;
         divMaingrid_responsivetable_activepermissions_Class = "Section_Grid";
         cmbavApplicationid_Jsonclick = "";
         cmbavApplicationid.Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible = 1;
         lblLayoutdefined_filtersummary_combined_activepermissions_Caption = "Filter Summary";
         imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavGenericfilter_activepermissions_Jsonclick = "";
         edtavGenericfilter_activepermissions_Enabled = 1;
         divGridcomponentcontent_activepermissions_Visible = 1;
         divGridcomponent_activepermissions_Class = "K2BToolsTable_ComponentContainer";
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'sPrefix'},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("ACTIVEPERMISSIONS.LOAD","{handler:'E25442',iparms:[{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("ACTIVEPERMISSIONS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_activepermissions_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV82Delete_Action',fld:'vDELETE_ACTION',pic:''},{av:'edtavDelete_action_Tooltiptext',ctrl:'vDELETE_ACTION',prop:'Tooltiptext'},{av:'AV46MultiRowItemSelected_ActivePermissions',fld:'vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS',pic:''},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV48Name',fld:'vNAME',pic:'',hsh:true},{av:'AV17Dsc',fld:'vDSC',pic:'',hsh:true},{av:'cmbavAccesstype'},{av:'AV7AccessType',fld:'vACCESSTYPE',pic:''},{av:'cmbavStoredaccesstype'},{av:'AV86StoredAccessType',fld:'vSTOREDACCESSTYPE',pic:'',hsh:true},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV40IsInherited',fld:'vISINHERITED',pic:''},{av:'AV88StoredIsInherited',fld:'vSTOREDISINHERITED',pic:'',hsh:true},{av:'lblPaginationbar_firstpagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockactivepermissions_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKACTIVEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockactivepermissions_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKACTIVEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_activepermissions_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(ACTIVEPERMISSIONS)'","{handler:'E11441',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(ACTIVEPERMISSIONS)'",",oparms:[{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(ACTIVEPERMISSIONS)'","{handler:'E13441',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'PAGINGNEXT(ACTIVEPERMISSIONS)'",",oparms:[{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'E_ADD'","{handler:'E14442',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'E_ADD'",",oparms:[{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'E_DELETEMULTIPLE'","{handler:'E15442',iparms:[{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV45MultiRowHasNext_ActivePermissions',fld:'vMULTIROWHASNEXT_ACTIVEPERMISSIONS',pic:''},{av:'AV47MultiRowIterator_ActivePermissions',fld:'vMULTIROWITERATOR_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV67SelectedItems_ActivePermissions',fld:'vSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV72S_Id',fld:'vS_ID',pic:''},{av:'AV76FieldValues_ActivePermissions',fld:'vFIELDVALUES_ACTIVEPERMISSIONS',pic:''},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'E_DELETEMULTIPLE'",",oparms:[{av:'AV67SelectedItems_ActivePermissions',fld:'vSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV47MultiRowIterator_ActivePermissions',fld:'vMULTIROWITERATOR_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV72S_Id',fld:'vS_ID',pic:''},{av:'AV76FieldValues_ActivePermissions',fld:'vFIELDVALUES_ACTIVEPERMISSIONS',pic:''},{av:'AV45MultiRowHasNext_ActivePermissions',fld:'vMULTIROWHASNEXT_ACTIVEPERMISSIONS',pic:''},{av:'AV41isOK',fld:'vISOK',pic:''},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'PAGINGFIRST(ACTIVEPERMISSIONS)'","{handler:'E12441',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'PAGINGFIRST(ACTIVEPERMISSIONS)'",",oparms:[{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_ACTIVEPERMISSIONS.CLICK","{handler:'E26442',iparms:[{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV37Id',fld:'vID',grid:127,pic:'',hsh:true},{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_127',ctrl:'ACTIVEPERMISSIONS',grid:127,prop:'GridRC',grid:127},{av:'AV46MultiRowItemSelected_ActivePermissions',fld:'vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS',grid:127,pic:''},{av:'AV48Name',fld:'vNAME',grid:127,pic:'',hsh:true},{av:'AV17Dsc',fld:'vDSC',grid:127,pic:'',hsh:true},{av:'AV7AccessType',fld:'vACCESSTYPE',grid:127,pic:''},{av:'AV40IsInherited',fld:'vISINHERITED',grid:127,pic:''},{av:'AV86StoredAccessType',fld:'vSTOREDACCESSTYPE',grid:127,pic:'',hsh:true},{av:'AV88StoredIsInherited',fld:'vSTOREDISINHERITED',grid:127,pic:'',hsh:true},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("VMULTIROWITEMSELECTED_ACTIVEPERMISSIONS.CLICK",",oparms:[{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(ACTIVEPERMISSIONS)'","{handler:'E29441',iparms:[{av:'divGridsettings_contentoutertableactivepermissions_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEACTIVEPERMISSIONS',prop:'Visible'},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(ACTIVEPERMISSIONS)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_activepermissions'},{av:'AV62GridSettingsRowsPerPage_ActivePermissions',fld:'vGRIDSETTINGSROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertableactivepermissions_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(ACTIVEPERMISSIONS)'","{handler:'E16442',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'cmbavGridsettingsrowsperpage_activepermissions'},{av:'AV62GridSettingsRowsPerPage_ActivePermissions',fld:'vGRIDSETTINGSROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS(ACTIVEPERMISSIONS)'",",oparms:[{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertableactivepermissions_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEACTIVEPERMISSIONS',prop:'Visible'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("ACTIVEPERMISSIONS.REFRESH","{handler:'E27442',iparms:[{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("ACTIVEPERMISSIONS.REFRESH",",oparms:[{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'subActivepermissions_Backcolorstyle',ctrl:'ACTIVEPERMISSIONS',prop:'Backcolorstyle'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'lblLayoutdefined_filtersummary_combined_activepermissions_Caption',ctrl:'LAYOUTDEFINED_FILTERSUMMARY_COMBINED_ACTIVEPERMISSIONS',prop:'Caption'},{av:'cmbavAccesstype'},{av:'chkavIsinherited.Enabled',ctrl:'vISINHERITED',prop:'Enabled'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'lblPaginationbar_firstpagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockactivepermissions_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockactivepermissions_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKACTIVEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockactivepermissions_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKACTIVEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockactivepermissions_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKACTIVEPERMISSIONS',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_activepermissions_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("VCHECKALL_ACTIVEPERMISSIONS.CLICK","{handler:'E17442',iparms:[{av:'AV46MultiRowItemSelected_ActivePermissions',fld:'vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS',grid:127,pic:''},{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_127',ctrl:'ACTIVEPERMISSIONS',grid:127,prop:'GridRC',grid:127},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV37Id',fld:'vID',grid:127,pic:'',hsh:true},{av:'AV48Name',fld:'vNAME',grid:127,pic:'',hsh:true},{av:'AV17Dsc',fld:'vDSC',grid:127,pic:'',hsh:true},{av:'AV7AccessType',fld:'vACCESSTYPE',grid:127,pic:''},{av:'AV40IsInherited',fld:'vISINHERITED',grid:127,pic:''},{av:'AV86StoredAccessType',fld:'vSTOREDACCESSTYPE',grid:127,pic:'',hsh:true},{av:'AV88StoredIsInherited',fld:'vSTOREDISINHERITED',grid:127,pic:'',hsh:true},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("VCHECKALL_ACTIVEPERMISSIONS.CLICK",",oparms:[{av:'AV46MultiRowItemSelected_ActivePermissions',fld:'vMULTIROWITEMSELECTED_ACTIVEPERMISSIONS',pic:''},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'E_DELETE'","{handler:'E28442',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',pic:'',hsh:true},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'E_DELETE'",",oparms:[{av:'AV41isOK',fld:'vISOK',pic:''},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_ACTIVEPERMISSIONS.CLICK","{handler:'E18442',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_ACTIVEPERMISSIONS.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_ACTIVEPERMISSIONS.CLICK","{handler:'E19442',iparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_ACTIVEPERMISSIONS.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("GRIDTITLE_ACTIVEPERMISSIONS.CLICK","{handler:'E20442',iparms:[{av:'divGridcomponentcontent_activepermissions_Visible',ctrl:'GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("GRIDTITLE_ACTIVEPERMISSIONS.CLICK",",oparms:[{av:'divGridcomponentcontent_activepermissions_Visible',ctrl:'GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS',prop:'Visible'},{av:'divGridcomponent_activepermissions_Class',ctrl:'GRIDCOMPONENT_ACTIVEPERMISSIONS',prop:'Class'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("COLLAPSIBLEIMAGE_ACTIVEPERMISSIONS.CLICK","{handler:'E21442',iparms:[{av:'divGridcomponentcontent_activepermissions_Visible',ctrl:'GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("COLLAPSIBLEIMAGE_ACTIVEPERMISSIONS.CLICK",",oparms:[{av:'divGridcomponentcontent_activepermissions_Visible',ctrl:'GRIDCOMPONENTCONTENT_ACTIVEPERMISSIONS',prop:'Visible'},{av:'divGridcomponent_activepermissions_Class',ctrl:'GRIDCOMPONENT_ACTIVEPERMISSIONS',prop:'Class'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("'E_SAVECHANGES'","{handler:'E22442',iparms:[{av:'ACTIVEPERMISSIONS_nFirstRecordOnPage'},{av:'ACTIVEPERMISSIONS_nEOF'},{av:'AV6RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV75ApplicationId_PreviousValue',fld:'vAPPLICATIONID_PREVIOUSVALUE',pic:'ZZZZZZZZZZZ9'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV66AllSelectedItems_ActivePermissions',fld:'vALLSELECTEDITEMS_ACTIVEPERMISSIONS',pic:''},{av:'AV97Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV83GenericFilter_ActivePermissions',fld:'vGENERICFILTER_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV32HasNextPage_ActivePermissions',fld:'vHASNEXTPAGE_ACTIVEPERMISSIONS',pic:'',hsh:true},{av:'AV61RowsPerPage_ActivePermissions',fld:'vROWSPERPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV37Id',fld:'vID',grid:127,pic:'',hsh:true},{av:'nRC_GXsfl_127',ctrl:'ACTIVEPERMISSIONS',grid:127,prop:'GridRC',grid:127},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV35I_LoadCount_ActivePermissions',fld:'vI_LOADCOUNT_ACTIVEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'sPrefix'},{av:'AV7AccessType',fld:'vACCESSTYPE',grid:127,pic:''},{av:'AV86StoredAccessType',fld:'vSTOREDACCESSTYPE',grid:127,pic:'',hsh:true},{av:'AV40IsInherited',fld:'vISINHERITED',grid:127,pic:''},{av:'AV88StoredIsInherited',fld:'vSTOREDISINHERITED',grid:127,pic:'',hsh:true},{av:'AV41isOK',fld:'vISOK',pic:''},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("'E_SAVECHANGES'",",oparms:[{av:'AV41isOK',fld:'vISOK',pic:''},{av:'AV15CurrentPage_ActivePermissions',fld:'vCURRENTPAGE_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'AV9ActivePermissions_SelectedRows',fld:'vACTIVEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_activepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_ACTIVEPERMISSIONS',prop:'Class'},{av:'cmbavApplicationid'},{av:'AV14ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV84GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV85ClassCollection_ActivePermissions',fld:'vCLASSCOLLECTION_ACTIVEPERMISSIONS',pic:''},{av:'AV77CountSelectedItems_ActivePermissions',fld:'vCOUNTSELECTEDITEMS_ACTIVEPERMISSIONS',pic:'ZZZ9'},{av:'imgDeletemultiple_Visible',ctrl:'DELETEMULTIPLE',prop:'Visible'},{av:'imgDeletemultiple_Tooltiptext',ctrl:'DELETEMULTIPLE',prop:'Tooltiptext'},{ctrl:'ADD',prop:'Visible'},{ctrl:'SAVECHANGES',prop:'Visible'},{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("VALIDV_ACCESSTYPE","{handler:'Validv_Accesstype',iparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("VALIDV_ACCESSTYPE",",oparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("VALIDV_STOREDACCESSTYPE","{handler:'Validv_Storedaccesstype',iparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("VALIDV_STOREDACCESSTYPE",",oparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Delete_action',iparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV91FreezeColumnTitles_ActivePermissions',fld:'vFREEZECOLUMNTITLES_ACTIVEPERMISSIONS',pic:''},{av:'AV63CheckAll_ActivePermissions',fld:'vCHECKALL_ACTIVEPERMISSIONS',pic:''}]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV85ClassCollection_ActivePermissions = new GxSimpleCollection<string>();
         AV66AllSelectedItems_ActivePermissions = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV97Pgmname = "";
         AV83GenericFilter_ActivePermissions = "";
         AV84GridConfiguration = new SdtK2BGridConfiguration(context);
         AV37Id = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV67SelectedItems_ActivePermissions = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV72S_Id = "";
         AV76FieldValues_ActivePermissions = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "kb_ticket");
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_activepermissions_Jsonclick = "";
         lblLayoutdefined_filtersummary_combined_activepermissions_Jsonclick = "";
         imgLayoutdefined_filterclose_combined_activepermissions_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_firstpagetextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_previouspagetextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_currentpagetextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_nextpagetextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockactivepermissions_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockactivepermissions_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         ActivepermissionsContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV48Name = "";
         AV17Dsc = "";
         AV7AccessType = "";
         AV86StoredAccessType = "";
         AV82Delete_Action = "";
         AV98Delete_action_GXI = "";
         AV5GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV81CurrentAppGUID = "";
         AV94GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplication", "GeneXus.Programs");
         AV13ApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
         AV19Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV12Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV43Messages = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<SdtMessages_Message>( context, "Message", "GeneXus");
         AV42Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV33HttpRequest = new GxHttpRequest( context);
         AV64SelectedItem_ActivePermissions = new SdtK2BSelectionItem(context);
         ActivepermissionsRow = new GXWebRow();
         AV51PermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV59Window = new GXWindow();
         AV18Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV22GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV8ActivePermissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV31GridStateKey = "";
         AV29GridState = new SdtK2BGridState(context);
         AV30GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV69S_Name = "";
         AV70S_Dsc = "";
         AV71S_AccessType = "";
         AV87S_StoredAccessType = "";
         AV65FieldValue_ActivePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
         AV79K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV80K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_char2 = "";
         AV90PermissionUpd = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         lblI_noresultsfoundtextblock_activepermissions_Jsonclick = "";
         subActivepermissions_Linesclass = "";
         ActivepermissionsColumn = new GXWebColumn();
         imgDeletemultiple_Jsonclick = "";
         bttSavechanges_Jsonclick = "";
         imgGridsettings_labelactivepermissions_Jsonclick = "";
         lblGslayoutdefined_activepermissionsruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_saveactivepermissions_Jsonclick = "";
         bttAdd_Jsonclick = "";
         lblGridtitle_activepermissions_Jsonclick = "";
         imgCollapsibleimage_activepermissions_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6RoleId = "";
         GXCCtl = "";
         ROClassString = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectpermission__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectpermission__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectpermission__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectpermission__default(),
            new Object[][] {
            }
         );
         AV97Pgmname = "K2BFSG.RoleSelectPermission";
         /* GeneXus formulas. */
         AV97Pgmname = "K2BFSG.RoleSelectPermission";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         cmbavAccesstype.Enabled = 0;
         chkavIsinherited.Enabled = 0;
         cmbavStoredaccesstype.Enabled = 0;
         chkavStoredisinherited.Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV15CurrentPage_ActivePermissions ;
      private short AV77CountSelectedItems_ActivePermissions ;
      private short AV61RowsPerPage_ActivePermissions ;
      private short AV9ActivePermissions_SelectedRows ;
      private short AV35I_LoadCount_ActivePermissions ;
      private short initialized ;
      private short nGXWrapped ;
      private short AV47MultiRowIterator_ActivePermissions ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV62GridSettingsRowsPerPage_ActivePermissions ;
      private short subActivepermissions_Backcolorstyle ;
      private short subActivepermissions_Sortable ;
      private short ACTIVEPERMISSIONS_nEOF ;
      private short AV68Index_ActivePermissions ;
      private short subActivepermissions_Titlebackstyle ;
      private short subActivepermissions_Allowselection ;
      private short subActivepermissions_Allowhovering ;
      private short subActivepermissions_Allowcollapsing ;
      private short subActivepermissions_Collapsed ;
      private short subActivepermissions_Backstyle ;
      private int divGridsettings_contentoutertableactivepermissions_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Visible ;
      private int divGridcomponentcontent_activepermissions_Visible ;
      private int nRC_GXsfl_127 ;
      private int nGXsfl_127_idx=1 ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavId_Enabled ;
      private int edtavGenericfilter_activepermissions_Enabled ;
      private int divPaginationbar_pagingcontainertable_activepermissions_Visible ;
      private int lblPaginationbar_firstpagetextblockactivepermissions_Visible ;
      private int lblPaginationbar_spacinglefttextblockactivepermissions_Visible ;
      private int lblPaginationbar_previouspagetextblockactivepermissions_Visible ;
      private int lblPaginationbar_nextpagetextblockactivepermissions_Visible ;
      private int lblPaginationbar_spacingrighttextblockactivepermissions_Visible ;
      private int subActivepermissions_Islastpage ;
      private int AV95GXV2 ;
      private int AV96GXV3 ;
      private int tblI_noresultsfoundtablename_activepermissions_Visible ;
      private int AV99GXV4 ;
      private int AV100GXV5 ;
      private int AV101GXV6 ;
      private int bttAdd_Visible ;
      private int bttSavechanges_Visible ;
      private int nGXsfl_127_fel_idx=1 ;
      private int imgDeletemultiple_Visible ;
      private int AV104GXV7 ;
      private int AV105GXV8 ;
      private int AV106GXV9 ;
      private int AV108GXV10 ;
      private int AV109GXV11 ;
      private int subActivepermissions_Titlebackcolor ;
      private int subActivepermissions_Allbackcolor ;
      private int subActivepermissions_Selectedindex ;
      private int subActivepermissions_Selectioncolor ;
      private int subActivepermissions_Hoveringcolor ;
      private int idxLst ;
      private int subActivepermissions_Backcolor ;
      private int edtavName_Visible ;
      private int edtavDsc_Visible ;
      private int edtavId_Visible ;
      private int edtavDelete_action_Enabled ;
      private int edtavDelete_action_Visible ;
      private long AV6RoleId ;
      private long wcpOAV6RoleId ;
      private long AV75ApplicationId_PreviousValue ;
      private long AV14ApplicationId ;
      private long ACTIVEPERMISSIONS_nCurrentRecord ;
      private long ACTIVEPERMISSIONS_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_127_idx="0001" ;
      private string AV97Pgmname ;
      private string AV83GenericFilter_ActivePermissions ;
      private string AV37Id ;
      private string edtavName_Internalname ;
      private string edtavDsc_Internalname ;
      private string cmbavAccesstype_Internalname ;
      private string chkavIsinherited_Internalname ;
      private string cmbavStoredaccesstype_Internalname ;
      private string chkavStoredisinherited_Internalname ;
      private string edtavId_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV72S_Id ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divGridcomponent_activepermissions_Internalname ;
      private string divGridcomponent_activepermissions_Class ;
      private string divGridcomponentcontent_activepermissions_Internalname ;
      private string divLayoutdefined_grid_inner_activepermissions_Internalname ;
      private string divLayoutdefined_table10_activepermissions_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_activepermissions_Internalname ;
      private string divLayoutdefined_combinedfilterlayout_activepermissions_Internalname ;
      private string divLayoutdefined_section4_activepermissions_Internalname ;
      private string edtavGenericfilter_activepermissions_Internalname ;
      private string TempTags ;
      private string edtavGenericfilter_activepermissions_Jsonclick ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_combined_activepermissions_Internalname ;
      private string imgLayoutdefined_filtertoggle_combined_activepermissions_Jsonclick ;
      private string lblLayoutdefined_filtersummary_combined_activepermissions_Internalname ;
      private string lblLayoutdefined_filtersummary_combined_activepermissions_Caption ;
      private string lblLayoutdefined_filtersummary_combined_activepermissions_Jsonclick ;
      private string divLayoutdefined_filtercollapsiblesection_combined_activepermissions_Internalname ;
      private string imgLayoutdefined_filterclose_combined_activepermissions_Internalname ;
      private string imgLayoutdefined_filterclose_combined_activepermissions_Jsonclick ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_applicationid_Internalname ;
      private string cmbavApplicationid_Internalname ;
      private string cmbavApplicationid_Jsonclick ;
      private string divLayoutdefined_table3_activepermissions_Internalname ;
      private string divLayoutdefined_section1_activepermissions_Internalname ;
      private string divLayoutdefined_section7_activepermissions_Internalname ;
      private string divLayoutdefined_section3_activepermissions_Internalname ;
      private string divMaingrid_responsivetable_activepermissions_Internalname ;
      private string divMaingrid_responsivetable_activepermissions_Class ;
      private string divLayoutdefined_section8_activepermissions_Internalname ;
      private string divPaginationbar_pagingcontainertable_activepermissions_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockactivepermissions_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockactivepermissions_Class ;
      private string lblPaginationbar_firstpagetextblockactivepermissions_Internalname ;
      private string lblPaginationbar_firstpagetextblockactivepermissions_Caption ;
      private string lblPaginationbar_firstpagetextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockactivepermissions_Internalname ;
      private string lblPaginationbar_spacinglefttextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockactivepermissions_Internalname ;
      private string lblPaginationbar_previouspagetextblockactivepermissions_Caption ;
      private string lblPaginationbar_previouspagetextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockactivepermissions_Internalname ;
      private string lblPaginationbar_currentpagetextblockactivepermissions_Caption ;
      private string lblPaginationbar_currentpagetextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockactivepermissions_Internalname ;
      private string lblPaginationbar_nextpagetextblockactivepermissions_Caption ;
      private string lblPaginationbar_nextpagetextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockactivepermissions_Internalname ;
      private string lblPaginationbar_spacingrighttextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockactivepermissions_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockactivepermissions_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockactivepermissions_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sStyleString ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavMultirowitemselected_activepermissions_Internalname ;
      private string AV48Name ;
      private string AV17Dsc ;
      private string AV7AccessType ;
      private string AV86StoredAccessType ;
      private string edtavDelete_action_Internalname ;
      private string cmbavGridsettingsrowsperpage_activepermissions_Internalname ;
      private string chkavFreezecolumntitles_activepermissions_Internalname ;
      private string chkavCheckall_activepermissions_Internalname ;
      private string AV81CurrentAppGUID ;
      private string divGridsettings_contentoutertableactivepermissions_Internalname ;
      private string tblI_noresultsfoundtablename_activepermissions_Internalname ;
      private string edtavDelete_action_Tooltiptext ;
      private string bttAdd_Internalname ;
      private string bttSavechanges_Internalname ;
      private string AV69S_Name ;
      private string AV70S_Dsc ;
      private string AV71S_AccessType ;
      private string AV87S_StoredAccessType ;
      private string sGXsfl_127_fel_idx="0001" ;
      private string imgDeletemultiple_Internalname ;
      private string imgDeletemultiple_Tooltiptext ;
      private string GXt_char2 ;
      private string imgCollapsibleimage_activepermissions_Internalname ;
      private string lblI_noresultsfoundtextblock_activepermissions_Internalname ;
      private string lblI_noresultsfoundtextblock_activepermissions_Jsonclick ;
      private string tblTablegridcontainer_activepermissions_Internalname ;
      private string subActivepermissions_Internalname ;
      private string subActivepermissions_Class ;
      private string subActivepermissions_Linesclass ;
      private string subActivepermissions_Header ;
      private string tblActions_activepermissions_gridassociatedleft_Internalname ;
      private string imgDeletemultiple_Jsonclick ;
      private string bttSavechanges_Jsonclick ;
      private string tblLayoutdefined_table7_activepermissions_Internalname ;
      private string divGridsettings_globaltable_activepermissions_Internalname ;
      private string imgGridsettings_labelactivepermissions_Internalname ;
      private string imgGridsettings_labelactivepermissions_Jsonclick ;
      private string divGslayoutdefined_activepermissionscontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_activepermissions_Internalname ;
      private string lblGslayoutdefined_activepermissionsruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_activepermissionsruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_activepermissionscustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_activepermissions_Internalname ;
      private string cmbavGridsettingsrowsperpage_activepermissions_Jsonclick ;
      private string divFreezecolumntitlescontainer_activepermissions_Internalname ;
      private string bttGridsettings_saveactivepermissions_Internalname ;
      private string bttGridsettings_saveactivepermissions_Jsonclick ;
      private string tblActions_activepermissions_topright_Internalname ;
      private string bttAdd_Jsonclick ;
      private string tblGridtitlecontainertable_activepermissions_Internalname ;
      private string lblGridtitle_activepermissions_Internalname ;
      private string lblGridtitle_activepermissions_Jsonclick ;
      private string tblCollapsibleimagecontainer_activepermissions_Internalname ;
      private string imgCollapsibleimage_activepermissions_Jsonclick ;
      private string sCtrlAV6RoleId ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string cmbavAccesstype_Jsonclick ;
      private string cmbavStoredaccesstype_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string edtavDelete_action_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV32HasNextPage_ActivePermissions ;
      private bool AV91FreezeColumnTitles_ActivePermissions ;
      private bool AV63CheckAll_ActivePermissions ;
      private bool bGXsfl_127_Refreshing=false ;
      private bool AV45MultiRowHasNext_ActivePermissions ;
      private bool AV41isOK ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV46MultiRowItemSelected_ActivePermissions ;
      private bool AV40IsInherited ;
      private bool AV88StoredIsInherited ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV78RowsPerPageLoaded_ActivePermissions ;
      private bool gx_refresh_fired ;
      private bool AV52Reload_ActivePermissions ;
      private bool AV20Exit_ActivePermissions ;
      private bool AV60hasError ;
      private bool AV74S_IsInherited ;
      private bool AV89S_StoredIsInherited ;
      private bool AV82Delete_Action_IsBlob ;
      private string AV98Delete_action_GXI ;
      private string AV31GridStateKey ;
      private string imgLayoutdefined_filtertoggle_combined_activepermissions_Bitmap ;
      private string AV82Delete_Action ;
      private string imgDeletemultiple_Bitmap ;
      private string imgCollapsibleimage_activepermissions_Bitmap ;
      private GXWebGrid ActivepermissionsContainer ;
      private GXWebRow ActivepermissionsRow ;
      private GXWebColumn ActivepermissionsColumn ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_RoleId ;
      private GXCombobox cmbavApplicationid ;
      private GXCombobox cmbavGridsettingsrowsperpage_activepermissions ;
      private GXCheckbox chkavFreezecolumntitles_activepermissions ;
      private GXCheckbox chkavCheckall_activepermissions ;
      private GXCheckbox chkavMultirowitemselected_activepermissions ;
      private GXCombobox cmbavAccesstype ;
      private GXCheckbox chkavIsinherited ;
      private GXCombobox cmbavStoredaccesstype ;
      private GXCheckbox chkavStoredisinherited ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV33HttpRequest ;
      private GxSimpleCollection<string> AV85ClassCollection_ActivePermissions ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV19Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication> AV94GXV1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV8ActivePermissions ;
      private GXBaseCollection<SdtMessages_Message> AV43Messages ;
      private GXBaseCollection<SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BSelectionItem> AV66AllSelectedItems_ActivePermissions ;
      private GXBaseCollection<SdtK2BSelectionItem> AV67SelectedItems_ActivePermissions ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV76FieldValues_ActivePermissions ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV79K2BFilterValuesSDT_WebForm ;
      private GXWindow AV59Window ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV5GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV18Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV12Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV22GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV90PermissionUpd ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV51PermissionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter AV13ApplicationFilter ;
      private SdtK2BGridState AV29GridState ;
      private SdtK2BGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV42Message ;
      private SdtK2BSelectionItem AV64SelectedItem_ActivePermissions ;
      private SdtK2BSelectionItem_FieldValuesItem AV65FieldValue_ActivePermissions ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV80K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV84GridConfiguration ;
   }

   public class roleselectpermission__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class roleselectpermission__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class roleselectpermission__gam : DataStoreHelperBase, IDataStoreHelper
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

public class roleselectpermission__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
