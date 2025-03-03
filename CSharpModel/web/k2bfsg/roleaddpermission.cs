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
   public class roleaddpermission : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public roleaddpermission( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("K2BOrion");
      }

      public roleaddpermission( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_RoleId ,
                           ref long aP1_ApplicationId )
      {
         this.AV39RoleId = aP0_RoleId;
         this.AV10ApplicationId = aP1_ApplicationId;
         executePrivate();
         aP0_RoleId=this.AV39RoleId;
         aP1_ApplicationId=this.AV10ApplicationId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavPermissionaccesstype = new GXCombobox();
         cmbavIsinherited = new GXCombobox();
         cmbavGridsettingsrowsperpage_availablepermissions = new GXCombobox();
         chkavFreezecolumntitles_availablepermissions = new GXCheckbox();
         chkavCheckall_availablepermissions = new GXCheckbox();
         chkavMultirowitemselected_availablepermissions = new GXCheckbox();
         cmbavAccess = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Availablepermissions") == 0 )
            {
               nRC_GXsfl_126 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_126"), "."));
               nGXsfl_126_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_126_idx"), "."));
               sGXsfl_126_idx = GetPar( "sGXsfl_126_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrAvailablepermissions_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Availablepermissions") == 0 )
            {
               AV39RoleId = (long)(NumberUtil.Val( GetPar( "RoleId"), "."));
               AV10ApplicationId = (long)(NumberUtil.Val( GetPar( "ApplicationId"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV70ClassCollection_AvailablePermissions);
               AV59PermissionAccessType_PreviousValue = GetPar( "PermissionAccessType_PreviousValue");
               cmbavPermissionaccesstype.FromJSonString( GetNextPar( ));
               AV34PermissionAccessType = GetPar( "PermissionAccessType");
               AV60IsInherited_PreviousValue = GetPar( "IsInherited_PreviousValue");
               cmbavIsinherited.FromJSonString( GetNextPar( ));
               AV27IsInherited = GetPar( "IsInherited");
               ajax_req_read_hidden_sdt(GetNextPar( ), AV51AllSelectedItems_AvailablePermissions);
               AV75Pgmname = GetPar( "Pgmname");
               AV13CurrentPage_AvailablePermissions = (short)(NumberUtil.Val( GetPar( "CurrentPage_AvailablePermissions"), "."));
               AV66GenericFilter_AvailablePermissions = GetPar( "GenericFilter_AvailablePermissions");
               AV62CountSelectedItems_AvailablePermissions = (short)(NumberUtil.Val( GetPar( "CountSelectedItems_AvailablePermissions"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV67GridConfiguration);
               AV23HasNextPage_AvailablePermissions = StringUtil.StrToBool( GetPar( "HasNextPage_AvailablePermissions"));
               AV46RowsPerPage_AvailablePermissions = (short)(NumberUtil.Val( GetPar( "RowsPerPage_AvailablePermissions"), "."));
               AV26Id = GetPar( "Id");
               AV12AvailablePermissions_SelectedRows = (short)(NumberUtil.Val( GetPar( "AvailablePermissions_SelectedRows"), "."));
               AV56S_Access = GetPar( "S_Access");
               AV25I_LoadCount_AvailablePermissions = (short)(NumberUtil.Val( GetPar( "I_LoadCount_AvailablePermissions"), "."));
               ajax_req_read_hidden_sdt(GetNextPar( ), AV61FieldValues_AvailablePermissions);
               AV71FreezeColumnTitles_AvailablePermissions = StringUtil.StrToBool( GetPar( "FreezeColumnTitles_AvailablePermissions"));
               AV48CheckAll_AvailablePermissions = StringUtil.StrToBool( GetPar( "CheckAll_AvailablePermissions"));
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrAvailablepermissions_refresh( AV39RoleId, AV10ApplicationId, AV70ClassCollection_AvailablePermissions, AV59PermissionAccessType_PreviousValue, AV34PermissionAccessType, AV60IsInherited_PreviousValue, AV27IsInherited, AV51AllSelectedItems_AvailablePermissions, AV75Pgmname, AV13CurrentPage_AvailablePermissions, AV66GenericFilter_AvailablePermissions, AV62CountSelectedItems_AvailablePermissions, AV67GridConfiguration, AV23HasNextPage_AvailablePermissions, AV46RowsPerPage_AvailablePermissions, AV26Id, AV12AvailablePermissions_SelectedRows, AV56S_Access, AV25I_LoadCount_AvailablePermissions, AV61FieldValues_AvailablePermissions, AV71FreezeColumnTitles_AvailablePermissions, AV48CheckAll_AvailablePermissions) ;
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
               AV39RoleId = (long)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV39RoleId", StringUtil.LTrimStr( (decimal)(AV39RoleId), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39RoleId), "ZZZZZZZZZZZ9"), context));
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV10ApplicationId = (long)(NumberUtil.Val( GetPar( "ApplicationId"), "."));
                  AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ApplicationId), "ZZZZZZZZZZZ9"), context));
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
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("k2bt_masterpage", "GeneXus.Programs.k2bt_masterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      public override short ExecuteStartEvent( )
      {
         PA4E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4E2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 184460), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 184460), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2024188193737", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
         context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.roleaddpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV39RoleId,12,0)),UrlEncode(StringUtil.LTrimStr(AV10ApplicationId,12,0))}, new string[] {"RoleId","ApplicationId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39RoleId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25I_LoadCount_AvailablePermissions), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", AV23HasNextPage_AvailablePermissions, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_126", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_126), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFILTERTAGSCOLLECTION_AVAILABLEPERMISSIONS", AV68FilterTagsCollection_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFILTERTAGSCOLLECTION_AVAILABLEPERMISSIONS", AV68FilterTagsCollection_AvailablePermissions);
         }
         GxWebStd.gx_hidden_field( context, "vDELETEDTAG_AVAILABLEPERMISSIONS", StringUtil.RTrim( AV69DeletedTag_AvailablePermissions));
         GxWebStd.gx_hidden_field( context, "vCURRENTPAGE_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCLASSCOLLECTION_AVAILABLEPERMISSIONS", AV70ClassCollection_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCLASSCOLLECTION_AVAILABLEPERMISSIONS", AV70ClassCollection_AvailablePermissions);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV75Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDCONFIGURATION", AV67GridConfiguration);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDCONFIGURATION", AV67GridConfiguration);
         }
         GxWebStd.gx_hidden_field( context, "vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62CountSelectedItems_AvailablePermissions), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39RoleId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39RoleId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ApplicationId), "ZZZZZZZZZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vALLSELECTEDITEMS_AVAILABLEPERMISSIONS", AV51AllSelectedItems_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vALLSELECTEDITEMS_AVAILABLEPERMISSIONS", AV51AllSelectedItems_AvailablePermissions);
         }
         GxWebStd.gx_hidden_field( context, "vROWSPERPAGE_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46RowsPerPage_AvailablePermissions), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vAVAILABLEPERMISSIONS_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12AvailablePermissions_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vS_ACCESS", StringUtil.RTrim( AV56S_Access));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25I_LoadCount_AvailablePermissions), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25I_LoadCount_AvailablePermissions), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFIELDVALUES_AVAILABLEPERMISSIONS", AV61FieldValues_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFIELDVALUES_AVAILABLEPERMISSIONS", AV61FieldValues_AvailablePermissions);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_AVAILABLEPERMISSIONS", AV23HasNextPage_AvailablePermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", AV23HasNextPage_AvailablePermissions, context));
         GxWebStd.gx_boolean_hidden_field( context, "vMULTIROWHASNEXT_AVAILABLEPERMISSIONS", AV30MultiRowHasNext_AvailablePermissions);
         GxWebStd.gx_hidden_field( context, "vMULTIROWITERATOR_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV32MultiRowIterator_AvailablePermissions), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDITEMS_AVAILABLEPERMISSIONS", AV52SelectedItems_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDITEMS_AVAILABLEPERMISSIONS", AV52SelectedItems_AvailablePermissions);
         }
         GxWebStd.gx_hidden_field( context, "vS_ID", StringUtil.RTrim( AV57S_Id));
         GxWebStd.gx_hidden_field( context, "vPERMISSIONACCESSTYPE_PREVIOUSVALUE", StringUtil.RTrim( AV59PermissionAccessType_PreviousValue));
         GxWebStd.gx_hidden_field( context, "vISINHERITED_PREVIOUSVALUE", StringUtil.RTrim( AV60IsInherited_PreviousValue));
         GxWebStd.gx_hidden_field( context, "vINDEX_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV53Index_AvailablePermissions), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSELECTEDITEM_AVAILABLEPERMISSIONS", AV49SelectedItem_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSELECTEDITEM_AVAILABLEPERMISSIONS", AV49SelectedItem_AvailablePermissions);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFIELDVALUE_AVAILABLEPERMISSIONS", AV50FieldValue_AvailablePermissions);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFIELDVALUE_AVAILABLEPERMISSIONS", AV50FieldValue_AvailablePermissions);
         }
         GxWebStd.gx_hidden_field( context, "vGXV6", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV82GXV6), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERTAGSUSERCONTROL_AVAILABLEPERMISSIONS_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_availablepermissions_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, "GRIDSETTINGS_CONTENTOUTERTABLEAVAILABLEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divGridsettings_contentoutertableavailablepermissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible), 5, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4E2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("k2bfsg.roleaddpermission.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV39RoleId,12,0)),UrlEncode(StringUtil.LTrimStr(AV10ApplicationId,12,0))}, new string[] {"RoleId","ApplicationId"})  ;
      }

      public override string GetPgmname( )
      {
         return "K2BFSG.RoleAddPermission" ;
      }

      public override string GetPgmdesc( )
      {
         return "Agregar permiso" ;
      }

      protected void WB4E0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
            GxWebStd.gx_div_start( context, divResponsivetable_mainattributes_attributes_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributescontainertable_attributes_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TabularContentContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTable_container_rolename_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavRolename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavRolename_Internalname, "Nombre de rol", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavRolename_Internalname, StringUtil.RTrim( AV40RoleName), StringUtil.RTrim( context.localUtil.Format( AV40RoleName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavRolename_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavRolename_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\RoleAddPermission.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_applicationname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavApplicationname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavApplicationname_Internalname, "Nombre de aplicaci�n", "gx-form-item Attribute_TrnLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavApplicationname_Internalname, StringUtil.RTrim( AV11ApplicationName), StringUtil.RTrim( context.localUtil.Format( AV11ApplicationName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavApplicationname_Jsonclick, 0, "Attribute_Trn", "", "", "", "", 1, edtavApplicationname_Enabled, 0, "text", "", 0, "px", 1, "row", 254, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "left", true, "", "HLP_K2BFSG\\RoleAddPermission.htm");
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
            GxWebStd.gx_div_start( context, divGridcomponentcontent_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_availablepermissions_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_WPD_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_availablepermissions_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_combinedfilterlayout_availablepermissions_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section4_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_CombinedFilters", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGenericfilter_availablepermissions_Internalname, "Generic Filter_Available Permissions", "gx-form-item K2BTools_SearchCriteriaLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_126_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGenericfilter_availablepermissions_Internalname, StringUtil.RTrim( AV66GenericFilter_AvailablePermissions), StringUtil.RTrim( context.localUtil.Format( AV66GenericFilter_AvailablePermissions, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Buscar...", edtavGenericfilter_availablepermissions_Jsonclick, 0, "K2BTools_SearchCriteria", "", "", "", "", 1, edtavGenericfilter_availablepermissions_Enabled, 0, "text", "", 40, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\RoleAddPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_combined_availablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERTOGGLE_COMBINED_AVAILABLEPERMISSIONS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleAddPermission.htm");
            /* User Defined Control */
            ucFiltertagsusercontrol_availablepermissions.SetProperty("TagValues", AV68FilterTagsCollection_AvailablePermissions);
            ucFiltertagsusercontrol_availablepermissions.SetProperty("DeletedTag", AV69DeletedTag_AvailablePermissions);
            ucFiltertagsusercontrol_availablepermissions.Render(context, "k2btagsviewer", Filtertagsusercontrol_availablepermissions_Internalname, "FILTERTAGSUSERCONTROL_AVAILABLEPERMISSIONSContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname, divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_combined_availablepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_combined_availablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"ELAYOUTDEFINED_FILTERCLOSE_COMBINED_AVAILABLEPERMISSIONS.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleAddPermission.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_permissionaccesstype_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavPermissionaccesstype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPermissionaccesstype_Internalname, "Tipo de acceso predeterminado", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPermissionaccesstype, cmbavPermissionaccesstype_Internalname, StringUtil.RTrim( AV34PermissionAccessType), 1, cmbavPermissionaccesstype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavPermissionaccesstype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,62);\"", "", true, 1, "HLP_K2BFSG\\RoleAddPermission.htm");
            cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV34PermissionAccessType);
            AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", (string)(cmbavPermissionaccesstype.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTable_container_isinherited_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+cmbavIsinherited_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIsinherited_Internalname, "Es heredado", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIsinherited, cmbavIsinherited_Internalname, StringUtil.RTrim( AV27IsInherited), 1, cmbavIsinherited_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavIsinherited.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute_Filter", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "", true, 1, "HLP_K2BFSG\\RoleAddPermission.htm");
            cmbavIsinherited.CurrentValue = StringUtil.RTrim( AV27IsInherited);
            AssignProp("", false, cmbavIsinherited_Internalname, "Values", (string)(cmbavIsinherited.ToJavascriptSource()), true);
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
            wb_table1_71_4E2( true) ;
         }
         else
         {
            wb_table1_71_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_71_4E2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_availablepermissions_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_availablepermissions_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_120_4E2( true) ;
         }
         else
         {
            wb_table2_120_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_120_4E2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_134_4E2( true) ;
         }
         else
         {
            wb_table3_134_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table3_134_4E2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_section8_availablepermissions_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPaginationbar_pagingcontainertable_availablepermissions_Internalname, divPaginationbar_pagingcontainertable_availablepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_PaginationContainer", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagebuttontextblockavailablepermissions_Internalname, "", "", "", lblPaginationbar_previouspagebuttontextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114e1_client"+"'", "", lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_firstpagetextblockavailablepermissions_Internalname, lblPaginationbar_firstpagetextblockavailablepermissions_Caption, "", "", lblPaginationbar_firstpagetextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"e124e1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_firstpagetextblockavailablepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname, "...", "", "", lblPaginationbar_spacinglefttextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacinglefttextblockavailablepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_previouspagetextblockavailablepermissions_Internalname, lblPaginationbar_previouspagetextblockavailablepermissions_Caption, "", "", lblPaginationbar_previouspagetextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"e114e1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_previouspagetextblockavailablepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_currentpagetextblockavailablepermissions_Internalname, lblPaginationbar_currentpagetextblockavailablepermissions_Caption, "", "", lblPaginationbar_currentpagetextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationCurrent", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagetextblockavailablepermissions_Internalname, lblPaginationbar_nextpagetextblockavailablepermissions_Caption, "", "", lblPaginationbar_nextpagetextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"e134e1_client"+"'", "", "K2BToolsTextBlock_PaginationNormal", 7, "", lblPaginationbar_nextpagetextblockavailablepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_spacingrighttextblockavailablepermissions_Internalname, "...", "", "", lblPaginationbar_spacingrighttextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_PaginationDisabled", 0, "", lblPaginationbar_spacingrighttextblockavailablepermissions_Visible, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblPaginationbar_nextpagebuttontextblockavailablepermissions_Internalname, "", "", "", lblPaginationbar_nextpagebuttontextblockavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"e134e1_client"+"'", "", lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class, 7, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* User Defined Control */
            ucK2bcontrolbeautify1.Render(context, "k2bcontrolbeautify", K2bcontrolbeautify1_Internalname, "K2BCONTROLBEAUTIFY1Container");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 126 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( AvailablepermissionsContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"AvailablepermissionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Availablepermissions", AvailablepermissionsContainer);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AvailablepermissionsContainerData", AvailablepermissionsContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "AvailablepermissionsContainerData"+"V", AvailablepermissionsContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AvailablepermissionsContainerData"+"V"+"\" value='"+AvailablepermissionsContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4E2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Agregar permiso", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4E0( ) ;
      }

      protected void WS4E2( )
      {
         START4E2( ) ;
         EVT4E2( ) ;
      }

      protected void EVT4E2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'E_ADDSELECTED'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'E_AddSelected' */
                              E144E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'SAVEGRIDSETTINGS(AVAILABLEPERMISSIONS)'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'SaveGridSettings(AvailablePermissions)' */
                              E154E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_AVAILABLEPERMISSIONS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_COMBINED_AVAILABLEPERMISSIONS.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E174E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 25), "AVAILABLEPERMISSIONS.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 48), "VMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 28), "AVAILABLEPERMISSIONS.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 48), "VMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_126_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
                              SubsflControlProps_1262( ) ;
                              AV31MultiRowItemSelected_AvailablePermissions = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_availablepermissions_Internalname));
                              AssignAttri("", false, chkavMultirowitemselected_availablepermissions_Internalname, AV31MultiRowItemSelected_AvailablePermissions);
                              AV33Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV33Name);
                              GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV33Name, "")), context));
                              AV14Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri("", false, edtavDsc_Internalname, AV14Dsc);
                              GxWebStd.gx_hidden_field( context, "gxhash_vDSC"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV14Dsc, "")), context));
                              cmbavAccess.Name = cmbavAccess_Internalname;
                              cmbavAccess.CurrentValue = cgiGet( cmbavAccess_Internalname);
                              AV6Access = cgiGet( cmbavAccess_Internalname);
                              AssignAttri("", false, cmbavAccess_Internalname, AV6Access);
                              AV26Id = cgiGet( edtavId_Internalname);
                              AssignAttri("", false, edtavId_Internalname, AV26Id);
                              GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV26Id, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E184E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E194E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "AVAILABLEPERMISSIONS.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E214E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "AVAILABLEPERMISSIONS.REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E224E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
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

      protected void WE4E2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA4E2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavRolename_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrAvailablepermissions_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1262( ) ;
         while ( nGXsfl_126_idx <= nRC_GXsfl_126 )
         {
            sendrow_1262( ) ;
            nGXsfl_126_idx = ((subAvailablepermissions_Islastpage==1)&&(nGXsfl_126_idx+1>subAvailablepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_idx+1);
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( AvailablepermissionsContainer)) ;
         /* End function gxnrAvailablepermissions_newrow */
      }

      protected void gxgrAvailablepermissions_refresh( long AV39RoleId ,
                                                       long AV10ApplicationId ,
                                                       GxSimpleCollection<string> AV70ClassCollection_AvailablePermissions ,
                                                       string AV59PermissionAccessType_PreviousValue ,
                                                       string AV34PermissionAccessType ,
                                                       string AV60IsInherited_PreviousValue ,
                                                       string AV27IsInherited ,
                                                       GXBaseCollection<SdtK2BSelectionItem> AV51AllSelectedItems_AvailablePermissions ,
                                                       string AV75Pgmname ,
                                                       short AV13CurrentPage_AvailablePermissions ,
                                                       string AV66GenericFilter_AvailablePermissions ,
                                                       short AV62CountSelectedItems_AvailablePermissions ,
                                                       SdtK2BGridConfiguration AV67GridConfiguration ,
                                                       bool AV23HasNextPage_AvailablePermissions ,
                                                       short AV46RowsPerPage_AvailablePermissions ,
                                                       string AV26Id ,
                                                       short AV12AvailablePermissions_SelectedRows ,
                                                       string AV56S_Access ,
                                                       short AV25I_LoadCount_AvailablePermissions ,
                                                       GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV61FieldValues_AvailablePermissions ,
                                                       bool AV71FreezeColumnTitles_AvailablePermissions ,
                                                       bool AV48CheckAll_AvailablePermissions )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E194E2 ();
         AVAILABLEPERMISSIONS_nCurrentRecord = 0;
         RF4E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrAvailablepermissions_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV26Id, "")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.RTrim( AV26Id));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV33Name, "")), context));
         GxWebStd.gx_hidden_field( context, "vNAME", StringUtil.RTrim( AV33Name));
         GxWebStd.gx_hidden_field( context, "gxhash_vDSC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14Dsc, "")), context));
         GxWebStd.gx_hidden_field( context, "vDSC", StringUtil.RTrim( AV14Dsc));
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
         if ( cmbavPermissionaccesstype.ItemCount > 0 )
         {
            AV34PermissionAccessType = cmbavPermissionaccesstype.getValidValue(AV34PermissionAccessType);
            AssignAttri("", false, "AV34PermissionAccessType", AV34PermissionAccessType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV34PermissionAccessType);
            AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", cmbavPermissionaccesstype.ToJavascriptSource(), true);
         }
         if ( cmbavIsinherited.ItemCount > 0 )
         {
            AV27IsInherited = cmbavIsinherited.getValidValue(AV27IsInherited);
            AssignAttri("", false, "AV27IsInherited", AV27IsInherited);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIsinherited.CurrentValue = StringUtil.RTrim( AV27IsInherited);
            AssignProp("", false, cmbavIsinherited_Internalname, "Values", cmbavIsinherited.ToJavascriptSource(), true);
         }
         if ( cmbavGridsettingsrowsperpage_availablepermissions.ItemCount > 0 )
         {
            AV47GridSettingsRowsPerPage_AvailablePermissions = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_availablepermissions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0))), "."));
            AssignAttri("", false, "AV47GridSettingsRowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGridsettingsrowsperpage_availablepermissions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_availablepermissions_Internalname, "Values", cmbavGridsettingsrowsperpage_availablepermissions.ToJavascriptSource(), true);
         }
         AV71FreezeColumnTitles_AvailablePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV71FreezeColumnTitles_AvailablePermissions));
         AssignAttri("", false, "AV71FreezeColumnTitles_AvailablePermissions", AV71FreezeColumnTitles_AvailablePermissions);
         AV48CheckAll_AvailablePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV48CheckAll_AvailablePermissions));
         AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E194E2 ();
         RF4E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV75Pgmname = "K2BFSG.RoleAddPermission";
         context.Gx_err = 0;
         edtavRolename_Enabled = 0;
         AssignProp("", false, edtavRolename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRolename_Enabled), 5, 0), true);
         edtavApplicationname_Enabled = 0;
         AssignProp("", false, edtavApplicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationname_Enabled), 5, 0), true);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_126_Refreshing);
      }

      protected void RF4E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            AvailablepermissionsContainer.ClearRows();
         }
         wbStart = 126;
         E224E2 ();
         nGXsfl_126_idx = 1;
         sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
         SubsflControlProps_1262( ) ;
         bGXsfl_126_Refreshing = true;
         AvailablepermissionsContainer.AddObjectProperty("GridName", "Availablepermissions");
         AvailablepermissionsContainer.AddObjectProperty("CmpContext", "");
         AvailablepermissionsContainer.AddObjectProperty("InMasterPage", "false");
         AvailablepermissionsContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         AvailablepermissionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         AvailablepermissionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         AvailablepermissionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Backcolorstyle), 1, 0, ".", "")));
         AvailablepermissionsContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Sortable), 1, 0, ".", "")));
         AvailablepermissionsContainer.PageSize = subAvailablepermissions_fnc_Recordsperpage( );
         if ( subAvailablepermissions_Islastpage != 0 )
         {
            AVAILABLEPERMISSIONS_nFirstRecordOnPage = (long)(subAvailablepermissions_fnc_Recordcount( )-subAvailablepermissions_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "AVAILABLEPERMISSIONS_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(AVAILABLEPERMISSIONS_nFirstRecordOnPage), 15, 0, ".", "")));
            AvailablepermissionsContainer.AddObjectProperty("AVAILABLEPERMISSIONS_nFirstRecordOnPage", AVAILABLEPERMISSIONS_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1262( ) ;
            E204E2 ();
            wbEnd = 126;
            WB4E0( ) ;
         }
         bGXsfl_126_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV75Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV75Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV39RoleId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39RoleId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10ApplicationId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV26Id, "")), context));
         GxWebStd.gx_hidden_field( context, "vI_LOADCOUNT_AVAILABLEPERMISSIONS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25I_LoadCount_AvailablePermissions), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25I_LoadCount_AvailablePermissions), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vHASNEXTPAGE_AVAILABLEPERMISSIONS", AV23HasNextPage_AvailablePermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", AV23HasNextPage_AvailablePermissions, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV33Name, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDSC"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV14Dsc, "")), context));
      }

      protected int subAvailablepermissions_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subAvailablepermissions_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subAvailablepermissions_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subAvailablepermissions_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV75Pgmname = "K2BFSG.RoleAddPermission";
         context.Gx_err = 0;
         edtavRolename_Enabled = 0;
         AssignProp("", false, edtavRolename_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRolename_Enabled), 5, 0), true);
         edtavApplicationname_Enabled = 0;
         AssignProp("", false, edtavApplicationname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavApplicationname_Enabled), 5, 0), true);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_126_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vFILTERTAGSCOLLECTION_AVAILABLEPERMISSIONS"), AV68FilterTagsCollection_AvailablePermissions);
            ajax_req_read_hidden_sdt(cgiGet( "vALLSELECTEDITEMS_AVAILABLEPERMISSIONS"), AV51AllSelectedItems_AvailablePermissions);
            ajax_req_read_hidden_sdt(cgiGet( "vSELECTEDITEM_AVAILABLEPERMISSIONS"), AV49SelectedItem_AvailablePermissions);
            ajax_req_read_hidden_sdt(cgiGet( "vFIELDVALUE_AVAILABLEPERMISSIONS"), AV50FieldValue_AvailablePermissions);
            /* Read saved values. */
            nRC_GXsfl_126 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_126"), ".", ","));
            AV69DeletedTag_AvailablePermissions = cgiGet( "vDELETEDTAG_AVAILABLEPERMISSIONS");
            AV53Index_AvailablePermissions = (short)(context.localUtil.CToN( cgiGet( "vINDEX_AVAILABLEPERMISSIONS"), ".", ","));
            AV62CountSelectedItems_AvailablePermissions = (short)(context.localUtil.CToN( cgiGet( "vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS"), ".", ","));
            AV82GXV6 = (int)(context.localUtil.CToN( cgiGet( "vGXV6"), ".", ","));
            AV46RowsPerPage_AvailablePermissions = (short)(context.localUtil.CToN( cgiGet( "vROWSPERPAGE_AVAILABLEPERMISSIONS"), ".", ","));
            AV13CurrentPage_AvailablePermissions = (short)(context.localUtil.CToN( cgiGet( "vCURRENTPAGE_AVAILABLEPERMISSIONS"), ".", ","));
            AV23HasNextPage_AvailablePermissions = StringUtil.StrToBool( cgiGet( "vHASNEXTPAGE_AVAILABLEPERMISSIONS"));
            Filtertagsusercontrol_availablepermissions_Emptystatemessage = cgiGet( "FILTERTAGSUSERCONTROL_AVAILABLEPERMISSIONS_Emptystatemessage");
            divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible = (int)(context.localUtil.CToN( cgiGet( "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS_Visible"), ".", ","));
            /* Read variables values. */
            AV40RoleName = cgiGet( edtavRolename_Internalname);
            AssignAttri("", false, "AV40RoleName", AV40RoleName);
            AV11ApplicationName = cgiGet( edtavApplicationname_Internalname);
            AssignAttri("", false, "AV11ApplicationName", AV11ApplicationName);
            AV66GenericFilter_AvailablePermissions = cgiGet( edtavGenericfilter_availablepermissions_Internalname);
            AssignAttri("", false, "AV66GenericFilter_AvailablePermissions", AV66GenericFilter_AvailablePermissions);
            cmbavPermissionaccesstype.Name = cmbavPermissionaccesstype_Internalname;
            cmbavPermissionaccesstype.CurrentValue = cgiGet( cmbavPermissionaccesstype_Internalname);
            AV34PermissionAccessType = cgiGet( cmbavPermissionaccesstype_Internalname);
            AssignAttri("", false, "AV34PermissionAccessType", AV34PermissionAccessType);
            cmbavIsinherited.Name = cmbavIsinherited_Internalname;
            cmbavIsinherited.CurrentValue = cgiGet( cmbavIsinherited_Internalname);
            AV27IsInherited = cgiGet( cmbavIsinherited_Internalname);
            AssignAttri("", false, "AV27IsInherited", AV27IsInherited);
            cmbavGridsettingsrowsperpage_availablepermissions.Name = cmbavGridsettingsrowsperpage_availablepermissions_Internalname;
            cmbavGridsettingsrowsperpage_availablepermissions.CurrentValue = cgiGet( cmbavGridsettingsrowsperpage_availablepermissions_Internalname);
            AV47GridSettingsRowsPerPage_AvailablePermissions = (short)(NumberUtil.Val( cgiGet( cmbavGridsettingsrowsperpage_availablepermissions_Internalname), "."));
            AssignAttri("", false, "AV47GridSettingsRowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0));
            AV71FreezeColumnTitles_AvailablePermissions = StringUtil.StrToBool( cgiGet( chkavFreezecolumntitles_availablepermissions_Internalname));
            AssignAttri("", false, "AV71FreezeColumnTitles_AvailablePermissions", AV71FreezeColumnTitles_AvailablePermissions);
            AV48CheckAll_AvailablePermissions = StringUtil.StrToBool( cgiGet( chkavCheckall_availablepermissions_Internalname));
            AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void S172( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         if ( (0==AV39RoleId) || (0==AV10ApplicationId) )
         {
            context.setWebReturnParms(new Object[] {(long)AV39RoleId,(long)AV10ApplicationId});
            context.setWebReturnParmsMetadata(new Object[] {"AV39RoleId","AV10ApplicationId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV19GAMRole.load( AV39RoleId);
            AV18GAMApplication.load( AV10ApplicationId);
            AV40RoleName = AV19GAMRole.gxTpr_Name;
            AssignAttri("", false, "AV40RoleName", AV40RoleName);
            AV11ApplicationName = AV18GAMApplication.gxTpr_Name;
            AssignAttri("", false, "AV11ApplicationName", AV11ApplicationName);
         }
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
         GXt_objcol_SdtMessages_Message1 = AV45Messages;
         new k2btoolsmessagequeuegetallmessages(context ).execute( out  GXt_objcol_SdtMessages_Message1) ;
         AV45Messages = GXt_objcol_SdtMessages_Message1;
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV45Messages.Count )
         {
            AV28Message = ((GeneXus.Utils.SdtMessages_Message)AV45Messages.Item(AV74GXV1));
            GX_msglist.addItem(AV28Message.gxTpr_Description);
            AV74GXV1 = (int)(AV74GXV1+1);
         }
         AV48CheckAll_AvailablePermissions = false;
         AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E184E2 ();
         if (returnInSub) return;
      }

      protected void E184E2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible), 5, 0), true);
         new k2bloadrowsperpage(context ).execute(  AV75Pgmname,  "AvailablePermissions", out  AV46RowsPerPage_AvailablePermissions, out  AV63RowsPerPageLoaded_AvailablePermissions) ;
         AssignAttri("", false, "AV46RowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV46RowsPerPage_AvailablePermissions), 4, 0));
         if ( ! AV63RowsPerPageLoaded_AvailablePermissions )
         {
            AV46RowsPerPage_AvailablePermissions = 20;
            AssignAttri("", false, "AV46RowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV46RowsPerPage_AvailablePermissions), 4, 0));
         }
         AV47GridSettingsRowsPerPage_AvailablePermissions = AV46RowsPerPage_AvailablePermissions;
         AssignAttri("", false, "AV47GridSettingsRowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0));
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(AVAILABLEPERMISSIONS)' */
         S122 ();
         if (returnInSub) return;
         AV59PermissionAccessType_PreviousValue = AV34PermissionAccessType;
         AssignAttri("", false, "AV59PermissionAccessType_PreviousValue", AV59PermissionAccessType_PreviousValue);
         AV60IsInherited_PreviousValue = AV27IsInherited;
         AssignAttri("", false, "AV60IsInherited_PreviousValue", AV60IsInherited_PreviousValue);
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(AVAILABLEPERMISSIONS)' */
         S132 ();
         if (returnInSub) return;
         subAvailablepermissions_Backcolorstyle = 3;
         divGridsettings_contentoutertableavailablepermissions_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertableavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertableavailablepermissions_Visible), 5, 0), true);
      }

      protected void E194E2( )
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
         if ( (0==AV13CurrentPage_AvailablePermissions) )
         {
            AV13CurrentPage_AvailablePermissions = 1;
            AssignAttri("", false, "AV13CurrentPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0));
         }
         AV38Reload_AvailablePermissions = true;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(AVAILABLEPERMISSIONS)' */
         S152 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(AVAILABLEPERMISSIONS)' */
            S162 ();
            if (returnInSub) return;
            AV12AvailablePermissions_SelectedRows = 0;
            AssignAttri("", false, "AV12AvailablePermissions_SelectedRows", StringUtil.LTrimStr( (decimal)(AV12AvailablePermissions_SelectedRows), 4, 0));
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV70ClassCollection_AvailablePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_availablepermissions_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_availablepermissions_Internalname, "Class", divMaingrid_responsivetable_availablepermissions_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridConfiguration", AV67GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ClassCollection_AvailablePermissions", AV70ClassCollection_AvailablePermissions);
      }

      protected void S112( )
      {
         /* 'U_OPENPAGE' Routine */
         returnInSub = false;
      }

      private void E204E2( )
      {
         /* Availablepermissions_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_availablepermissions_Visible = 1;
         AssignProp("", false, tblI_noresultsfoundtablename_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_availablepermissions_Visible), 5, 0), true);
         AV25I_LoadCount_AvailablePermissions = 0;
         AssignAttri("", false, "AV25I_LoadCount_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV25I_LoadCount_AvailablePermissions), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25I_LoadCount_AvailablePermissions), "ZZZ9"), context));
         AV23HasNextPage_AvailablePermissions = false;
         AssignAttri("", false, "AV23HasNextPage_AvailablePermissions", AV23HasNextPage_AvailablePermissions);
         GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", AV23HasNextPage_AvailablePermissions, context));
         AV17Exit_AvailablePermissions = false;
         while ( true )
         {
            AV25I_LoadCount_AvailablePermissions = (short)(AV25I_LoadCount_AvailablePermissions+1);
            AssignAttri("", false, "AV25I_LoadCount_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV25I_LoadCount_AvailablePermissions), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vI_LOADCOUNT_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV25I_LoadCount_AvailablePermissions), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(AVAILABLEPERMISSIONS)' */
            S182 ();
            if (returnInSub) return;
            AV6Access = "";
            AssignAttri("", false, cmbavAccess_Internalname, AV6Access);
            /* Execute user subroutine: 'U_AFTERDATALOAD(AVAILABLEPERMISSIONS)' */
            S192 ();
            if (returnInSub) return;
            if ( AV17Exit_AvailablePermissions )
            {
               if (true) break;
            }
            if ( AV25I_LoadCount_AvailablePermissions > AV46RowsPerPage_AvailablePermissions * AV13CurrentPage_AvailablePermissions )
            {
               AV23HasNextPage_AvailablePermissions = true;
               AssignAttri("", false, "AV23HasNextPage_AvailablePermissions", AV23HasNextPage_AvailablePermissions);
               GxWebStd.gx_hidden_field( context, "gxhash_vHASNEXTPAGE_AVAILABLEPERMISSIONS", GetSecureSignedToken( "", AV23HasNextPage_AvailablePermissions, context));
               if (true) break;
            }
            if ( AV25I_LoadCount_AvailablePermissions > AV46RowsPerPage_AvailablePermissions * ( AV13CurrentPage_AvailablePermissions - 1 ) )
            {
               tblI_noresultsfoundtablename_availablepermissions_Visible = 0;
               AssignProp("", false, tblI_noresultsfoundtablename_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_availablepermissions_Visible), 5, 0), true);
               AV31MultiRowItemSelected_AvailablePermissions = false;
               AssignAttri("", false, chkavMultirowitemselected_availablepermissions_Internalname, AV31MultiRowItemSelected_AvailablePermissions);
               AV76GXV2 = 1;
               while ( AV76GXV2 <= AV51AllSelectedItems_AvailablePermissions.Count )
               {
                  AV49SelectedItem_AvailablePermissions = ((SdtK2BSelectionItem)AV51AllSelectedItems_AvailablePermissions.Item(AV76GXV2));
                  if ( StringUtil.StrCmp(AV49SelectedItem_AvailablePermissions.gxTpr_Skcharacter1, AV26Id) == 0 )
                  {
                     if ( AV49SelectedItem_AvailablePermissions.gxTpr_Isselected )
                     {
                        AV31MultiRowItemSelected_AvailablePermissions = true;
                        AssignAttri("", false, chkavMultirowitemselected_availablepermissions_Internalname, AV31MultiRowItemSelected_AvailablePermissions);
                        AV12AvailablePermissions_SelectedRows = (short)(AV12AvailablePermissions_SelectedRows+1);
                        AssignAttri("", false, "AV12AvailablePermissions_SelectedRows", StringUtil.LTrimStr( (decimal)(AV12AvailablePermissions_SelectedRows), 4, 0));
                     }
                     AV61FieldValues_AvailablePermissions = AV49SelectedItem_AvailablePermissions.gxTpr_Fieldvalues;
                     /* Execute user subroutine: 'GETFIELDVALUES_AVAILABLEPERMISSIONS' */
                     S202 ();
                     if (returnInSub) return;
                     AV6Access = AV56S_Access;
                     AssignAttri("", false, cmbavAccess_Internalname, AV6Access);
                     if (true) break;
                  }
                  AV76GXV2 = (int)(AV76GXV2+1);
               }
               if ( ((int)((AV25I_LoadCount_AvailablePermissions) % (AV46RowsPerPage_AvailablePermissions))) == 1 )
               {
                  AV48CheckAll_AvailablePermissions = true;
                  AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
               }
               if ( ! AV31MultiRowItemSelected_AvailablePermissions )
               {
                  AV48CheckAll_AvailablePermissions = false;
                  AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 126;
               }
               sendrow_1262( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_126_Refreshing )
               {
                  context.DoAjaxLoad(126, AvailablepermissionsRow);
               }
            }
         }
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(AVAILABLEPERMISSIONS)' */
         S212 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(AVAILABLEPERMISSIONS)' */
         S222 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         cmbavAccess.CurrentValue = StringUtil.RTrim( AV6Access);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61FieldValues_AvailablePermissions", AV61FieldValues_AvailablePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV36PermissionFilter", AV36PermissionFilter);
      }

      protected void S182( )
      {
         /* 'U_LOADROWVARS(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         if ( AV25I_LoadCount_AvailablePermissions == 1 )
         {
            AV19GAMRole.load( AV39RoleId);
            AV18GAMApplication.load( AV10ApplicationId);
            AV9AppId = AV10ApplicationId;
            AV36PermissionFilter.gxTpr_Applicationid = AV9AppId;
            AV36PermissionFilter.gxTpr_Name = AV66GenericFilter_AvailablePermissions;
            AV36PermissionFilter.gxTpr_Accesstype = AV34PermissionAccessType;
            AV36PermissionFilter.gxTpr_Inherited = AV27IsInherited;
            if ( ! (0==AV9AppId) )
            {
               AV37Permissions = AV19GAMRole.getunassignedpermissions(AV36PermissionFilter, out  AV16Errors);
            }
            else
            {
               AV37Permissions.Clear();
            }
         }
         if ( AV37Permissions.Count >= AV25I_LoadCount_AvailablePermissions )
         {
            AV33Name = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV37Permissions.Item(AV25I_LoadCount_AvailablePermissions)).gxTpr_Name;
            AssignAttri("", false, edtavName_Internalname, AV33Name);
            GxWebStd.gx_hidden_field( context, "gxhash_vNAME"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV33Name, "")), context));
            AV14Dsc = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV37Permissions.Item(AV25I_LoadCount_AvailablePermissions)).gxTpr_Description;
            AssignAttri("", false, edtavDsc_Internalname, AV14Dsc);
            GxWebStd.gx_hidden_field( context, "gxhash_vDSC"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV14Dsc, "")), context));
            AV6Access = "A";
            AssignAttri("", false, cmbavAccess_Internalname, AV6Access);
            AV26Id = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV37Permissions.Item(AV25I_LoadCount_AvailablePermissions)).gxTpr_Guid;
            AssignAttri("", false, edtavId_Internalname, AV26Id);
            GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_126_idx, GetSecureSignedToken( sGXsfl_126_idx, StringUtil.RTrim( context.localUtil.Format( AV26Id, "")), context));
         }
         else
         {
            AV17Exit_AvailablePermissions = true;
         }
      }

      protected void S212( )
      {
         /* 'UPDATEPAGINGCONTROLS(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         lblPaginationbar_firstpagetextblockavailablepermissions_Caption = "1";
         AssignProp("", false, lblPaginationbar_firstpagetextblockavailablepermissions_Internalname, "Caption", lblPaginationbar_firstpagetextblockavailablepermissions_Caption, true);
         lblPaginationbar_previouspagetextblockavailablepermissions_Caption = StringUtil.Str( (decimal)(AV13CurrentPage_AvailablePermissions-1), 10, 0);
         AssignProp("", false, lblPaginationbar_previouspagetextblockavailablepermissions_Internalname, "Caption", lblPaginationbar_previouspagetextblockavailablepermissions_Caption, true);
         lblPaginationbar_currentpagetextblockavailablepermissions_Caption = StringUtil.Str( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0);
         AssignProp("", false, lblPaginationbar_currentpagetextblockavailablepermissions_Internalname, "Caption", lblPaginationbar_currentpagetextblockavailablepermissions_Caption, true);
         lblPaginationbar_nextpagetextblockavailablepermissions_Caption = StringUtil.Str( (decimal)(AV13CurrentPage_AvailablePermissions+1), 10, 0);
         AssignProp("", false, lblPaginationbar_nextpagetextblockavailablepermissions_Internalname, "Caption", lblPaginationbar_nextpagetextblockavailablepermissions_Caption, true);
         lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_previouspagebuttontextblockavailablepermissions_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class, true);
         lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         AssignProp("", false, lblPaginationbar_nextpagebuttontextblockavailablepermissions_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class, true);
         if ( (0==AV13CurrentPage_AvailablePermissions) || ( AV13CurrentPage_AvailablePermissions <= 1 ) )
         {
            lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class = "K2BToolsTextBlock_PaginationDisabled";
            AssignProp("", false, lblPaginationbar_previouspagebuttontextblockavailablepermissions_Internalname, "Class", lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class, true);
            lblPaginationbar_firstpagetextblockavailablepermissions_Visible = 0;
            AssignProp("", false, lblPaginationbar_firstpagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockavailablepermissions_Visible), 5, 0), true);
            lblPaginationbar_spacinglefttextblockavailablepermissions_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockavailablepermissions_Visible), 5, 0), true);
            lblPaginationbar_previouspagetextblockavailablepermissions_Visible = 0;
            AssignProp("", false, lblPaginationbar_previouspagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockavailablepermissions_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_previouspagetextblockavailablepermissions_Visible = 1;
            AssignProp("", false, lblPaginationbar_previouspagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_previouspagetextblockavailablepermissions_Visible), 5, 0), true);
            if ( AV13CurrentPage_AvailablePermissions == 2 )
            {
               lblPaginationbar_firstpagetextblockavailablepermissions_Visible = 0;
               AssignProp("", false, lblPaginationbar_firstpagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockavailablepermissions_Visible), 5, 0), true);
               lblPaginationbar_spacinglefttextblockavailablepermissions_Visible = 0;
               AssignProp("", false, lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockavailablepermissions_Visible), 5, 0), true);
            }
            else
            {
               lblPaginationbar_firstpagetextblockavailablepermissions_Visible = 1;
               AssignProp("", false, lblPaginationbar_firstpagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_firstpagetextblockavailablepermissions_Visible), 5, 0), true);
               if ( AV13CurrentPage_AvailablePermissions == 3 )
               {
                  lblPaginationbar_spacinglefttextblockavailablepermissions_Visible = 0;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockavailablepermissions_Visible), 5, 0), true);
               }
               else
               {
                  lblPaginationbar_spacinglefttextblockavailablepermissions_Visible = 1;
                  AssignProp("", false, lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacinglefttextblockavailablepermissions_Visible), 5, 0), true);
               }
            }
         }
         if ( ! AV23HasNextPage_AvailablePermissions )
         {
            lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class = "K2BToolsTextBlock_PaginationNormal_Disabled";
            AssignProp("", false, lblPaginationbar_nextpagebuttontextblockavailablepermissions_Internalname, "Class", lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class, true);
            lblPaginationbar_spacingrighttextblockavailablepermissions_Visible = 0;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockavailablepermissions_Visible), 5, 0), true);
            lblPaginationbar_nextpagetextblockavailablepermissions_Visible = 0;
            AssignProp("", false, lblPaginationbar_nextpagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockavailablepermissions_Visible), 5, 0), true);
         }
         else
         {
            lblPaginationbar_nextpagetextblockavailablepermissions_Visible = 1;
            AssignProp("", false, lblPaginationbar_nextpagetextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_nextpagetextblockavailablepermissions_Visible), 5, 0), true);
            lblPaginationbar_spacingrighttextblockavailablepermissions_Visible = 1;
            AssignProp("", false, lblPaginationbar_spacingrighttextblockavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(lblPaginationbar_spacingrighttextblockavailablepermissions_Visible), 5, 0), true);
         }
         if ( ( AV13CurrentPage_AvailablePermissions <= 1 ) && ! AV23HasNextPage_AvailablePermissions )
         {
            divPaginationbar_pagingcontainertable_availablepermissions_Visible = 0;
            AssignProp("", false, divPaginationbar_pagingcontainertable_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_availablepermissions_Visible), 5, 0), true);
         }
         else
         {
            divPaginationbar_pagingcontainertable_availablepermissions_Visible = 1;
            AssignProp("", false, divPaginationbar_pagingcontainertable_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divPaginationbar_pagingcontainertable_availablepermissions_Visible), 5, 0), true);
         }
      }

      protected void S232( )
      {
         /* 'RESETMULTIROWITERATOR(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV32MultiRowIterator_AvailablePermissions = 1;
         AssignAttri("", false, "AV32MultiRowIterator_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV32MultiRowIterator_AvailablePermissions), 4, 0));
      }

      protected void S242( )
      {
         /* 'GETNEXTMULTIROW(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV54S_Name = "";
         AV55S_Dsc = "";
         AV56S_Access = "";
         AssignAttri("", false, "AV56S_Access", AV56S_Access);
         AV57S_Id = "";
         AssignAttri("", false, "AV57S_Id", AV57S_Id);
         while ( ( AV32MultiRowIterator_AvailablePermissions <= AV52SelectedItems_AvailablePermissions.Count ) && ! ((SdtK2BSelectionItem)AV52SelectedItems_AvailablePermissions.Item(AV32MultiRowIterator_AvailablePermissions)).gxTpr_Isselected )
         {
            AV32MultiRowIterator_AvailablePermissions = (short)(AV32MultiRowIterator_AvailablePermissions+1);
            AssignAttri("", false, "AV32MultiRowIterator_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV32MultiRowIterator_AvailablePermissions), 4, 0));
         }
         if ( AV32MultiRowIterator_AvailablePermissions > AV52SelectedItems_AvailablePermissions.Count )
         {
            AV30MultiRowHasNext_AvailablePermissions = false;
            AssignAttri("", false, "AV30MultiRowHasNext_AvailablePermissions", AV30MultiRowHasNext_AvailablePermissions);
         }
         else
         {
            AV30MultiRowHasNext_AvailablePermissions = true;
            AssignAttri("", false, "AV30MultiRowHasNext_AvailablePermissions", AV30MultiRowHasNext_AvailablePermissions);
            AV61FieldValues_AvailablePermissions = ((SdtK2BSelectionItem)AV52SelectedItems_AvailablePermissions.Item(AV32MultiRowIterator_AvailablePermissions)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_AVAILABLEPERMISSIONS' */
            S202 ();
            if (returnInSub) return;
         }
         AV32MultiRowIterator_AvailablePermissions = (short)(AV32MultiRowIterator_AvailablePermissions+1);
         AssignAttri("", false, "AV32MultiRowIterator_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV32MultiRowIterator_AvailablePermissions), 4, 0));
      }

      protected void S252( )
      {
         /* 'U_ADDSELECTED' Routine */
         returnInSub = false;
         AV19GAMRole.load( AV39RoleId);
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(AVAILABLEPERMISSIONS)' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(AVAILABLEPERMISSIONS)' */
         S242 ();
         if (returnInSub) return;
         AV44hasError = false;
         while ( AV30MultiRowHasNext_AvailablePermissions )
         {
            AV35PermissionAdd.gxTpr_Applicationid = AV10ApplicationId;
            AV35PermissionAdd.gxTpr_Guid = AV57S_Id;
            AV35PermissionAdd.gxTpr_Type = AV56S_Access;
            AV5isOK = AV19GAMRole.addpermission(AV35PermissionAdd, out  AV16Errors);
            if ( ! AV5isOK )
            {
               AV44hasError = true;
               AV77GXV3 = 1;
               while ( AV77GXV3 <= AV16Errors.Count )
               {
                  AV15Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16Errors.Item(AV77GXV3));
                  GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV15Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV15Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                  AV77GXV3 = (int)(AV77GXV3+1);
               }
               if (true) break;
            }
            /* Execute user subroutine: 'GETNEXTMULTIROW(AVAILABLEPERMISSIONS)' */
            S242 ();
            if (returnInSub) return;
         }
         if ( ! AV44hasError )
         {
            context.CommitDataStores("k2bfsg.roleaddpermission",pr_default);
            AV28Message = new GeneXus.Utils.SdtMessages_Message(context);
            AV28Message.gxTpr_Description = StringUtil.Format( "Permisos para %1 fueron agregados exitosamente", AV19GAMRole.gxTpr_Name, "", "", "", "", "", "", "", "");
            new k2btoolsmessagequeueadd(context ).execute(  AV28Message) ;
            context.setWebReturnParms(new Object[] {(long)AV39RoleId,(long)AV10ApplicationId});
            context.setWebReturnParmsMetadata(new Object[] {"AV39RoleId","AV10ApplicationId"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            AV78GXV4 = 1;
            while ( AV78GXV4 <= AV16Errors.Count )
            {
               AV15Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV16Errors.Item(AV78GXV4));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV15Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV15Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV78GXV4 = (int)(AV78GXV4+1);
            }
         }
      }

      protected void E144E2( )
      {
         /* 'E_AddSelected' Routine */
         returnInSub = false;
         AV52SelectedItems_AvailablePermissions = AV51AllSelectedItems_AvailablePermissions;
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(AVAILABLEPERMISSIONS)' */
         S232 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(AVAILABLEPERMISSIONS)' */
         S242 ();
         if (returnInSub) return;
         if ( ! AV30MultiRowHasNext_AvailablePermissions )
         {
            AV38Reload_AvailablePermissions = false;
            GX_msglist.addItem("Error : You must select at least one permission");
         }
         else
         {
            /* Execute user subroutine: 'RESETMULTIROWITERATOR(AVAILABLEPERMISSIONS)' */
            S232 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'GETNEXTMULTIROW(AVAILABLEPERMISSIONS)' */
            S242 ();
            if (returnInSub) return;
            while ( AV30MultiRowHasNext_AvailablePermissions )
            {
               /* Execute user subroutine: 'GETNEXTMULTIROW(AVAILABLEPERMISSIONS)' */
               S242 ();
               if (returnInSub) return;
            }
            /* Execute user subroutine: 'U_ADDSELECTED' */
            S252 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV52SelectedItems_AvailablePermissions", AV52SelectedItems_AvailablePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV61FieldValues_AvailablePermissions", AV61FieldValues_AvailablePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35PermissionAdd", AV35PermissionAdd);
      }

      protected void S222( )
      {
         /* 'SAVEGRIDSTATE(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV22GridStateKey = "AvailablePermissions";
         new k2bloadgridstate(context ).execute(  AV75Pgmname,  AV22GridStateKey, out  AV20GridState) ;
         AV20GridState.gxTpr_Currentpage = AV13CurrentPage_AvailablePermissions;
         AV20GridState.gxTpr_Filtervalues.Clear();
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV21GridStateFilterValue.gxTpr_Filtername = "PermissionAccessType";
         AV21GridStateFilterValue.gxTpr_Value = AV34PermissionAccessType;
         AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV21GridStateFilterValue.gxTpr_Filtername = "IsInherited";
         AV21GridStateFilterValue.gxTpr_Value = AV27IsInherited;
         AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV21GridStateFilterValue.gxTpr_Filtername = "GenericFilter_AvailablePermissions";
         AV21GridStateFilterValue.gxTpr_Value = AV66GenericFilter_AvailablePermissions;
         AV20GridState.gxTpr_Filtervalues.Add(AV21GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV75Pgmname,  AV22GridStateKey,  AV20GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV22GridStateKey = "AvailablePermissions";
         new k2bloadgridstate(context ).execute(  AV75Pgmname,  AV22GridStateKey, out  AV20GridState) ;
         AV79GXV5 = 1;
         while ( AV79GXV5 <= AV20GridState.gxTpr_Filtervalues.Count )
         {
            AV21GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV20GridState.gxTpr_Filtervalues.Item(AV79GXV5));
            if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Filtername, "PermissionAccessType") == 0 )
            {
               AV34PermissionAccessType = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV34PermissionAccessType", AV34PermissionAccessType);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Filtername, "IsInherited") == 0 )
            {
               AV27IsInherited = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV27IsInherited", AV27IsInherited);
            }
            else if ( StringUtil.StrCmp(AV21GridStateFilterValue.gxTpr_Filtername, "GenericFilter_AvailablePermissions") == 0 )
            {
               AV66GenericFilter_AvailablePermissions = AV21GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66GenericFilter_AvailablePermissions", AV66GenericFilter_AvailablePermissions);
            }
            AV79GXV5 = (int)(AV79GXV5+1);
         }
         if ( AV20GridState.gxTpr_Currentpage > 0 )
         {
            AV13CurrentPage_AvailablePermissions = AV20GridState.gxTpr_Currentpage;
            AssignAttri("", false, "AV13CurrentPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0));
         }
      }

      protected void S322( )
      {
         /* 'U_MULTIROWITEMSELECTED(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
      }

      protected void E214E2( )
      {
         /* Multirowitemselected_availablepermissions_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(AVAILABLEPERMISSIONS)' */
         S262 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ClassCollection_AvailablePermissions", AV70ClassCollection_AvailablePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV51AllSelectedItems_AvailablePermissions", AV51AllSelectedItems_AvailablePermissions);
      }

      protected void E154E2( )
      {
         /* 'SaveGridSettings(AvailablePermissions)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV75Pgmname,  "AvailablePermissions", ref  AV67GridConfiguration) ;
         AV67GridConfiguration.gxTpr_Freezecolumntitles = AV71FreezeColumnTitles_AvailablePermissions;
         new k2bsavegridconfiguration(context ).execute(  AV75Pgmname,  "AvailablePermissions",  AV67GridConfiguration,  true) ;
         if ( AV46RowsPerPage_AvailablePermissions != AV47GridSettingsRowsPerPage_AvailablePermissions )
         {
            AV46RowsPerPage_AvailablePermissions = AV47GridSettingsRowsPerPage_AvailablePermissions;
            AssignAttri("", false, "AV46RowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV46RowsPerPage_AvailablePermissions), 4, 0));
            new k2bsaverowsperpage(context ).execute(  AV75Pgmname,  "AvailablePermissions",  AV46RowsPerPage_AvailablePermissions) ;
            AV13CurrentPage_AvailablePermissions = 1;
            AssignAttri("", false, "AV13CurrentPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0));
         }
         gxgrAvailablepermissions_refresh( AV39RoleId, AV10ApplicationId, AV70ClassCollection_AvailablePermissions, AV59PermissionAccessType_PreviousValue, AV34PermissionAccessType, AV60IsInherited_PreviousValue, AV27IsInherited, AV51AllSelectedItems_AvailablePermissions, AV75Pgmname, AV13CurrentPage_AvailablePermissions, AV66GenericFilter_AvailablePermissions, AV62CountSelectedItems_AvailablePermissions, AV67GridConfiguration, AV23HasNextPage_AvailablePermissions, AV46RowsPerPage_AvailablePermissions, AV26Id, AV12AvailablePermissions_SelectedRows, AV56S_Access, AV25I_LoadCount_AvailablePermissions, AV61FieldValues_AvailablePermissions, AV71FreezeColumnTitles_AvailablePermissions, AV48CheckAll_AvailablePermissions) ;
         divGridsettings_contentoutertableavailablepermissions_Visible = 0;
         AssignProp("", false, divGridsettings_contentoutertableavailablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divGridsettings_contentoutertableavailablepermissions_Visible), 5, 0), true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridConfiguration", AV67GridConfiguration);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ClassCollection_AvailablePermissions", AV70ClassCollection_AvailablePermissions);
      }

      protected void S272( )
      {
         /* 'U_GRIDREFRESH(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
      }

      protected void E224E2( )
      {
         /* Availablepermissions_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV70ClassCollection_AvailablePermissions) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(AVAILABLEPERMISSIONS)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(AVAILABLEPERMISSIONS)' */
         S222 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV59PermissionAccessType_PreviousValue, AV34PermissionAccessType) != 0 )
         {
            AV59PermissionAccessType_PreviousValue = AV34PermissionAccessType;
            AssignAttri("", false, "AV59PermissionAccessType_PreviousValue", AV59PermissionAccessType_PreviousValue);
            AV13CurrentPage_AvailablePermissions = 1;
            AssignAttri("", false, "AV13CurrentPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0));
         }
         if ( StringUtil.StrCmp(AV60IsInherited_PreviousValue, AV27IsInherited) != 0 )
         {
            AV60IsInherited_PreviousValue = AV27IsInherited;
            AssignAttri("", false, "AV60IsInherited_PreviousValue", AV60IsInherited_PreviousValue);
            AV13CurrentPage_AvailablePermissions = 1;
            AssignAttri("", false, "AV13CurrentPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV13CurrentPage_AvailablePermissions), 4, 0));
         }
         subAvailablepermissions_Backcolorstyle = 3;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(AVAILABLEPERMISSIONS)' */
         S162 ();
         if (returnInSub) return;
         AV12AvailablePermissions_SelectedRows = 0;
         AssignAttri("", false, "AV12AvailablePermissions_SelectedRows", StringUtil.LTrimStr( (decimal)(AV12AvailablePermissions_SelectedRows), 4, 0));
         if ( AV51AllSelectedItems_AvailablePermissions.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV70ClassCollection_AvailablePermissions) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV70ClassCollection_AvailablePermissions) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV70ClassCollection_AvailablePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_availablepermissions_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_availablepermissions_Internalname, "Class", divMaingrid_responsivetable_availablepermissions_Class, true);
         /* Execute user subroutine: 'U_GRIDREFRESH(AVAILABLEPERMISSIONS)' */
         S272 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'E_APPLYGRIDCONFIGURATION(AVAILABLEPERMISSIONS)' */
         S152 ();
         if (returnInSub) return;
         AV48CheckAll_AvailablePermissions = false;
         AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
         /* Execute user subroutine: 'UPDATEPAGINGCONTROLS(AVAILABLEPERMISSIONS)' */
         S212 ();
         if (returnInSub) return;
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV70ClassCollection_AvailablePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_availablepermissions_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_availablepermissions_Internalname, "Class", divMaingrid_responsivetable_availablepermissions_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV70ClassCollection_AvailablePermissions", AV70ClassCollection_AvailablePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV68FilterTagsCollection_AvailablePermissions", AV68FilterTagsCollection_AvailablePermissions);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV67GridConfiguration", AV67GridConfiguration);
      }

      protected void S262( )
      {
         /* 'PROCESSSELECTION(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV48CheckAll_AvailablePermissions = true;
         AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
         /* Start For Each Line in Availablepermissions */
         nRC_GXsfl_126 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_126"), ".", ","));
         nGXsfl_126_fel_idx = 0;
         while ( nGXsfl_126_fel_idx < nRC_GXsfl_126 )
         {
            nGXsfl_126_fel_idx = ((subAvailablepermissions_Islastpage==1)&&(nGXsfl_126_fel_idx+1>subAvailablepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_fel_idx+1);
            sGXsfl_126_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1262( ) ;
            AV31MultiRowItemSelected_AvailablePermissions = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_availablepermissions_Internalname));
            AV33Name = cgiGet( edtavName_Internalname);
            AV14Dsc = cgiGet( edtavDsc_Internalname);
            cmbavAccess.Name = cmbavAccess_Internalname;
            cmbavAccess.CurrentValue = cgiGet( cmbavAccess_Internalname);
            AV6Access = cgiGet( cmbavAccess_Internalname);
            AV26Id = cgiGet( edtavId_Internalname);
            /* Execute user subroutine: 'UPDATESELECTION(AVAILABLEPERMISSIONS)' */
            S282 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_126_fel_idx == 0 )
         {
            nGXsfl_126_idx = 1;
            sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
            SubsflControlProps_1262( ) ;
         }
         nGXsfl_126_fel_idx = 1;
         /* Execute user subroutine: 'REFRESHGLOBALRELATEDACTIONS(AVAILABLEPERMISSIONS)' */
         S162 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(AVAILABLEPERMISSIONS)' */
         S322 ();
         if (returnInSub) return;
         if ( AV51AllSelectedItems_AvailablePermissions.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV70ClassCollection_AvailablePermissions) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV70ClassCollection_AvailablePermissions) ;
         }
         GXt_char2 = "";
         new k2bscjoinstring(context ).execute(  AV70ClassCollection_AvailablePermissions,  " ", out  GXt_char2) ;
         divMaingrid_responsivetable_availablepermissions_Class = GXt_char2;
         AssignProp("", false, divMaingrid_responsivetable_availablepermissions_Internalname, "Class", divMaingrid_responsivetable_availablepermissions_Class, true);
      }

      protected void S302( )
      {
         /* 'DISPLAYMULTIPLEGLOBALACTIONS(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         bttAddselected_Visible = 1;
         AssignProp("", false, bttAddselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddselected_Visible), 5, 0), true);
      }

      protected void S312( )
      {
         /* 'HIDEMULTIPLEGLOBALACTIONS(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         bttAddselected_Visible = 0;
         AssignProp("", false, bttAddselected_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttAddselected_Visible), 5, 0), true);
      }

      protected void S282( )
      {
         /* 'UPDATESELECTION(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV53Index_AvailablePermissions = 1;
         while ( AV53Index_AvailablePermissions <= AV51AllSelectedItems_AvailablePermissions.Count )
         {
            if ( StringUtil.StrCmp(((SdtK2BSelectionItem)AV51AllSelectedItems_AvailablePermissions.Item(AV53Index_AvailablePermissions)).gxTpr_Skcharacter1, AV26Id) == 0 )
            {
               AV51AllSelectedItems_AvailablePermissions.RemoveItem(AV53Index_AvailablePermissions);
            }
            else
            {
               AV53Index_AvailablePermissions = (short)(AV53Index_AvailablePermissions+1);
            }
         }
         if ( AV31MultiRowItemSelected_AvailablePermissions || ! String.IsNullOrEmpty(StringUtil.RTrim( AV6Access)) )
         {
            AV49SelectedItem_AvailablePermissions = new SdtK2BSelectionItem(context);
            AV49SelectedItem_AvailablePermissions.gxTpr_Isselected = AV31MultiRowItemSelected_AvailablePermissions;
            AV49SelectedItem_AvailablePermissions.gxTpr_Skcharacter1 = AV26Id;
            AV50FieldValue_AvailablePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV50FieldValue_AvailablePermissions.gxTpr_Name = "Name";
            AV50FieldValue_AvailablePermissions.gxTpr_Value = AV33Name;
            AV49SelectedItem_AvailablePermissions.gxTpr_Fieldvalues.Add(AV50FieldValue_AvailablePermissions, 0);
            AV50FieldValue_AvailablePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV50FieldValue_AvailablePermissions.gxTpr_Name = "Dsc";
            AV50FieldValue_AvailablePermissions.gxTpr_Value = AV14Dsc;
            AV49SelectedItem_AvailablePermissions.gxTpr_Fieldvalues.Add(AV50FieldValue_AvailablePermissions, 0);
            AV50FieldValue_AvailablePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV50FieldValue_AvailablePermissions.gxTpr_Name = "Access";
            AV50FieldValue_AvailablePermissions.gxTpr_Value = AV6Access;
            AV49SelectedItem_AvailablePermissions.gxTpr_Fieldvalues.Add(AV50FieldValue_AvailablePermissions, 0);
            AV50FieldValue_AvailablePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV50FieldValue_AvailablePermissions.gxTpr_Name = "Id";
            AV50FieldValue_AvailablePermissions.gxTpr_Value = AV26Id;
            AV49SelectedItem_AvailablePermissions.gxTpr_Fieldvalues.Add(AV50FieldValue_AvailablePermissions, 0);
            AV51AllSelectedItems_AvailablePermissions.Add(AV49SelectedItem_AvailablePermissions, 0);
         }
         if ( ! AV31MultiRowItemSelected_AvailablePermissions )
         {
            AV48CheckAll_AvailablePermissions = false;
            AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
         }
      }

      protected void S162( )
      {
         /* 'REFRESHGLOBALRELATEDACTIONS(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'GETSELECTEDITEMSCOUNT_AVAILABLEPERMISSIONS' */
         S292 ();
         if (returnInSub) return;
         if ( AV62CountSelectedItems_AvailablePermissions > 0 )
         {
            /* Execute user subroutine: 'DISPLAYMULTIPLEGLOBALACTIONS(AVAILABLEPERMISSIONS)' */
            S302 ();
            if (returnInSub) return;
         }
         else
         {
            /* Execute user subroutine: 'HIDEMULTIPLEGLOBALACTIONS(AVAILABLEPERMISSIONS)' */
            S312 ();
            if (returnInSub) return;
         }
      }

      protected void S292( )
      {
         /* 'GETSELECTEDITEMSCOUNT_AVAILABLEPERMISSIONS' Routine */
         returnInSub = false;
         AV62CountSelectedItems_AvailablePermissions = 0;
         AssignAttri("", false, "AV62CountSelectedItems_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV62CountSelectedItems_AvailablePermissions), 4, 0));
         AV82GXV6 = 1;
         while ( AV82GXV6 <= AV51AllSelectedItems_AvailablePermissions.Count )
         {
            AV49SelectedItem_AvailablePermissions = ((SdtK2BSelectionItem)AV51AllSelectedItems_AvailablePermissions.Item(AV82GXV6));
            if ( AV49SelectedItem_AvailablePermissions.gxTpr_Isselected )
            {
               AV62CountSelectedItems_AvailablePermissions = (short)(AV62CountSelectedItems_AvailablePermissions+1);
               AssignAttri("", false, "AV62CountSelectedItems_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV62CountSelectedItems_AvailablePermissions), 4, 0));
            }
            AV82GXV6 = (int)(AV82GXV6+1);
         }
      }

      protected void S202( )
      {
         /* 'GETFIELDVALUES_AVAILABLEPERMISSIONS' Routine */
         returnInSub = false;
         AV83GXV7 = 1;
         while ( AV83GXV7 <= AV61FieldValues_AvailablePermissions.Count )
         {
            AV50FieldValue_AvailablePermissions = ((SdtK2BSelectionItem_FieldValuesItem)AV61FieldValues_AvailablePermissions.Item(AV83GXV7));
            if ( StringUtil.StrCmp(AV50FieldValue_AvailablePermissions.gxTpr_Name, "Name") == 0 )
            {
               AV54S_Name = AV50FieldValue_AvailablePermissions.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50FieldValue_AvailablePermissions.gxTpr_Name, "Dsc") == 0 )
            {
               AV55S_Dsc = AV50FieldValue_AvailablePermissions.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50FieldValue_AvailablePermissions.gxTpr_Name, "Access") == 0 )
            {
               AV56S_Access = AV50FieldValue_AvailablePermissions.gxTpr_Value;
               AssignAttri("", false, "AV56S_Access", AV56S_Access);
            }
            else if ( StringUtil.StrCmp(AV50FieldValue_AvailablePermissions.gxTpr_Name, "Id") == 0 )
            {
               AV57S_Id = AV50FieldValue_AvailablePermissions.gxTpr_Value;
               AssignAttri("", false, "AV57S_Id", AV57S_Id);
            }
            AV83GXV7 = (int)(AV83GXV7+1);
         }
      }

      protected void S332( )
      {
         /* 'U_ACCESS_CONTROLVALUECHANGED' Routine */
         returnInSub = false;
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV64K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34PermissionAccessType)) )
         {
            AV65K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "PermissionAccessType";
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Tipo de acceso predeterminado";
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV34PermissionAccessType;
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = GeneXus.Programs.genexussecuritycommon.gxdomaingampermissionaccesstype.getDescription(context,AV34PermissionAccessType);
            AV64K2BFilterValuesSDT_WebForm.Add(AV65K2BFilterValuesSDTItem_WebForm, 0);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27IsInherited)) )
         {
            AV65K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "IsInherited";
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Es heredado";
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV27IsInherited;
            AV65K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = GeneXus.Programs.genexussecuritycommon.gxdomaingambooleanfilter.getDescription(context,AV27IsInherited);
            AV64K2BFilterValuesSDT_WebForm.Add(AV65K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_availablepermissions_Emptystatemessage = "No hay filtros aplicados";
         ucFiltertagsusercontrol_availablepermissions.SendProperty(context, "", false, Filtertagsusercontrol_availablepermissions_Internalname, "EmptyStateMessage", Filtertagsusercontrol_availablepermissions_Emptystatemessage);
         if ( AV64K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = AV68FilterTagsCollection_AvailablePermissions;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV75Pgmname,  "AvailablePermissions",  AV64K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item3) ;
            AV68FilterTagsCollection_AvailablePermissions = GXt_objcol_SdtK2BValueDescriptionCollection_Item3;
         }
      }

      protected void E164E2( )
      {
         /* Layoutdefined_filtertoggle_combined_availablepermissions_Click Routine */
         returnInSub = false;
         if ( divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible = 0;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible = 1;
            AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap)), true);
            AssignProp("", false, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E174E2( )
      {
         /* Layoutdefined_filterclose_combined_availablepermissions_Click Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible = 0;
         AssignProp("", false, divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap)), true);
         AssignProp("", false, imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_AFTERDATALOAD(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
      }

      protected void S152( )
      {
         /* 'E_APPLYGRIDCONFIGURATION(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         new k2bloadgridconfiguration(context ).execute(  AV75Pgmname,  "AvailablePermissions", ref  AV67GridConfiguration) ;
         /* Execute user subroutine: 'E_APPLYFREEZECOLUMNTITLES(AVAILABLEPERMISSIONS)' */
         S342 ();
         if (returnInSub) return;
      }

      protected void S342( )
      {
         /* 'E_APPLYFREEZECOLUMNTITLES(AVAILABLEPERMISSIONS)' Routine */
         returnInSub = false;
         AV71FreezeColumnTitles_AvailablePermissions = AV67GridConfiguration.gxTpr_Freezecolumntitles;
         AssignAttri("", false, "AV71FreezeColumnTitles_AvailablePermissions", AV71FreezeColumnTitles_AvailablePermissions);
         if ( AV71FreezeColumnTitles_AvailablePermissions )
         {
            new k2bscadditem(context ).execute(  "K2BT_FreezeColumnTitles",  true, ref  AV70ClassCollection_AvailablePermissions) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BT_FreezeColumnTitles", ref  AV70ClassCollection_AvailablePermissions) ;
         }
      }

      protected void wb_table3_134_4E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_availablepermissions_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_availablepermissions_Internalname, tblI_noresultsfoundtablename_availablepermissions_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_availablepermissions_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_availablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_134_4E2e( true) ;
         }
         else
         {
            wb_table3_134_4E2e( false) ;
         }
      }

      protected void wb_table2_120_4E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainer_availablepermissions_Internalname, tblTablegridcontainer_availablepermissions_Internalname, "", "K2BToolsTable_GridContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_availablepermissions_Internalname, StringUtil.BoolToStr( AV48CheckAll_AvailablePermissions), "", "", 1, chkavCheckall_availablepermissions.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,124);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            AvailablepermissionsContainer.SetWrapped(nGXWrapped);
            if ( AvailablepermissionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"AvailablepermissionsContainer"+"DivS\" data-gxgridid=\"126\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subAvailablepermissions_Internalname, subAvailablepermissions_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subAvailablepermissions_Backcolorstyle == 0 )
               {
                  subAvailablepermissions_Titlebackstyle = 0;
                  if ( StringUtil.Len( subAvailablepermissions_Class) > 0 )
                  {
                     subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Title";
                  }
               }
               else
               {
                  subAvailablepermissions_Titlebackstyle = 1;
                  if ( subAvailablepermissions_Backcolorstyle == 1 )
                  {
                     subAvailablepermissions_Titlebackcolor = subAvailablepermissions_Allbackcolor;
                     if ( StringUtil.Len( subAvailablepermissions_Class) > 0 )
                     {
                        subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subAvailablepermissions_Class) > 0 )
                     {
                        subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Descripci�n") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Tipo de acceso") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               AvailablepermissionsContainer.AddObjectProperty("GridName", "Availablepermissions");
            }
            else
            {
               AvailablepermissionsContainer.AddObjectProperty("GridName", "Availablepermissions");
               AvailablepermissionsContainer.AddObjectProperty("Header", subAvailablepermissions_Header);
               AvailablepermissionsContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
               AvailablepermissionsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Backcolorstyle), 1, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Sortable), 1, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("CmpContext", "");
               AvailablepermissionsContainer.AddObjectProperty("InMasterPage", "false");
               AvailablepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               AvailablepermissionsColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV31MultiRowItemSelected_AvailablePermissions));
               AvailablepermissionsContainer.AddColumnProperties(AvailablepermissionsColumn);
               AvailablepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               AvailablepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV33Name));
               AvailablepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
               AvailablepermissionsContainer.AddColumnProperties(AvailablepermissionsColumn);
               AvailablepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               AvailablepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV14Dsc));
               AvailablepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
               AvailablepermissionsContainer.AddColumnProperties(AvailablepermissionsColumn);
               AvailablepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               AvailablepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV6Access));
               AvailablepermissionsContainer.AddColumnProperties(AvailablepermissionsColumn);
               AvailablepermissionsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               AvailablepermissionsColumn.AddObjectProperty("Value", StringUtil.RTrim( AV26Id));
               AvailablepermissionsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
               AvailablepermissionsContainer.AddColumnProperties(AvailablepermissionsColumn);
               AvailablepermissionsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Selectedindex), 4, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Allowselection), 1, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Selectioncolor), 9, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Allowhovering), 1, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Hoveringcolor), 9, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Allowcollapsing), 1, 0, ".", "")));
               AvailablepermissionsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subAvailablepermissions_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 126 )
         {
            wbEnd = 0;
            nRC_GXsfl_126 = (int)(nGXsfl_126_idx-1);
            if ( AvailablepermissionsContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"AvailablepermissionsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Availablepermissions", AvailablepermissionsContainer);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AvailablepermissionsContainerData", AvailablepermissionsContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "AvailablepermissionsContainerData"+"V", AvailablepermissionsContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"AvailablepermissionsContainerData"+"V"+"\" value='"+AvailablepermissionsContainer.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_120_4E2e( true) ;
         }
         else
         {
            wb_table2_120_4E2e( false) ;
         }
      }

      protected void wb_table1_71_4E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_availablepermissions_Internalname, tblLayoutdefined_table7_availablepermissions_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_globaltable_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
            ClassString = "Image_Action K2BT_GridSettingsToggle";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "64b0617d-9a6f-48ed-90cc-95b7ade149f7", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgGridsettings_labelavailablepermissions_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_GridSettingsLabel", "Config. tabla", 0, 0, 0, "px", 0, "px", 0, 0, 7, imgGridsettings_labelavailablepermissions_Jsonclick, "'"+""+"'"+",false,"+"'"+"e234e1_client"+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleAddPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridsettings_contentoutertableavailablepermissions_Internalname, divGridsettings_contentoutertableavailablepermissions_Visible, 0, "px", 0, "px", "K2BToolsTable_GridSettings", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_availablepermissionscontentinnertable_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcustomizationcontainer_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsCustomizationContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGslayoutdefined_availablepermissionsruntimecolumnselectiontb_Internalname, "Config. tabla", "", "", lblGslayoutdefined_availablepermissionsruntimecolumnselectiontb_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Section_Invisible", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleAddPermission.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGslayoutdefined_availablepermissionscustomizationcollapsiblesection_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridSettingsContent", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divRowsperpagecontainer_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+cmbavGridsettingsrowsperpage_availablepermissions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGridsettingsrowsperpage_availablepermissions_Internalname, "Filas por p�gina", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'" + sGXsfl_126_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGridsettingsrowsperpage_availablepermissions, cmbavGridsettingsrowsperpage_availablepermissions_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0)), 1, cmbavGridsettingsrowsperpage_availablepermissions_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavGridsettingsrowsperpage_availablepermissions.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,97);\"", "", true, 1, "HLP_K2BFSG\\RoleAddPermission.htm");
            cmbavGridsettingsrowsperpage_availablepermissions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0));
            AssignProp("", false, cmbavGridsettingsrowsperpage_availablepermissions_Internalname, "Values", (string)(cmbavGridsettingsrowsperpage_availablepermissions.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divFreezecolumntitlescontainer_availablepermissions_Internalname, 1, 0, "px", 0, "px", "K2BT_GridSettingsAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+chkavFreezecolumntitles_availablepermissions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavFreezecolumntitles_availablepermissions_Internalname, "Inmovilizar t�tulos", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'" + sGXsfl_126_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavFreezecolumntitles_availablepermissions_Internalname, StringUtil.BoolToStr( AV71FreezeColumnTitles_AvailablePermissions), "", "Inmovilizar t�tulos", 1, chkavFreezecolumntitles_availablepermissions.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(103, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,103);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MinimalAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttGridsettings_saveavailablepermissions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(126), 3, 0)+","+"null"+");", "Aplicar", bttGridsettings_saveavailablepermissions_Jsonclick, 5, "Aplicar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'SAVEGRIDSETTINGS(AVAILABLEPERMISSIONS)\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleAddPermission.htm");
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
            wb_table4_108_4E2( true) ;
         }
         else
         {
            wb_table4_108_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table4_108_4E2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_71_4E2e( true) ;
         }
         else
         {
            wb_table1_71_4E2e( false) ;
         }
      }

      protected void wb_table4_108_4E2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActions_availablepermissions_topright_Internalname, tblActions_availablepermissions_topright_Internalname, "", "Table_ActionsContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttAddselected_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(126), 3, 0)+","+"null"+");", "Agregar seleccionados", bttAddselected_Jsonclick, 5, "", "", StyleString, ClassString, bttAddselected_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'E_ADDSELECTED\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleAddPermission.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_108_4E2e( true) ;
         }
         else
         {
            wb_table4_108_4E2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV39RoleId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV39RoleId", StringUtil.LTrimStr( (decimal)(AV39RoleId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV39RoleId), "ZZZZZZZZZZZ9"), context));
         AV10ApplicationId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10ApplicationId), "ZZZZZZZZZZZ9"), context));
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
         PA4E2( ) ;
         WS4E2( ) ;
         WE4E2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188195515", true, true);
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
            context.AddJavascriptSource("k2bfsg/roleaddpermission.js", "?2024188195518", false, true);
            context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1262( )
      {
         chkavMultirowitemselected_availablepermissions_Internalname = "vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS_"+sGXsfl_126_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_126_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_126_idx;
         cmbavAccess_Internalname = "vACCESS_"+sGXsfl_126_idx;
         edtavId_Internalname = "vID_"+sGXsfl_126_idx;
      }

      protected void SubsflControlProps_fel_1262( )
      {
         chkavMultirowitemselected_availablepermissions_Internalname = "vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS_"+sGXsfl_126_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_126_fel_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_126_fel_idx;
         cmbavAccess_Internalname = "vACCESS_"+sGXsfl_126_fel_idx;
         edtavId_Internalname = "vID_"+sGXsfl_126_fel_idx;
      }

      protected void sendrow_1262( )
      {
         SubsflControlProps_1262( ) ;
         WB4E0( ) ;
         AvailablepermissionsRow = GXWebRow.GetNew(context,AvailablepermissionsContainer);
         if ( subAvailablepermissions_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subAvailablepermissions_Backstyle = 0;
            if ( StringUtil.StrCmp(subAvailablepermissions_Class, "") != 0 )
            {
               subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Odd";
            }
         }
         else if ( subAvailablepermissions_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subAvailablepermissions_Backstyle = 0;
            subAvailablepermissions_Backcolor = subAvailablepermissions_Allbackcolor;
            if ( StringUtil.StrCmp(subAvailablepermissions_Class, "") != 0 )
            {
               subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Uniform";
            }
         }
         else if ( subAvailablepermissions_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subAvailablepermissions_Backstyle = 1;
            if ( StringUtil.StrCmp(subAvailablepermissions_Class, "") != 0 )
            {
               subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Odd";
            }
            subAvailablepermissions_Backcolor = (int)(0x0);
         }
         else if ( subAvailablepermissions_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subAvailablepermissions_Backstyle = 1;
            if ( ((int)((nGXsfl_126_idx) % (2))) == 0 )
            {
               subAvailablepermissions_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subAvailablepermissions_Class, "") != 0 )
               {
                  subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Even";
               }
            }
            else
            {
               subAvailablepermissions_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subAvailablepermissions_Class, "") != 0 )
               {
                  subAvailablepermissions_Linesclass = subAvailablepermissions_Class+"Odd";
               }
            }
         }
         if ( AvailablepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_126_idx+"\">") ;
         }
         /* Subfile cell */
         if ( AvailablepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_availablepermissions.Enabled!=0)&&(chkavMultirowitemselected_availablepermissions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 127,'',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS_" + sGXsfl_126_idx;
         chkavMultirowitemselected_availablepermissions.Name = GXCCtl;
         chkavMultirowitemselected_availablepermissions.WebTags = "";
         chkavMultirowitemselected_availablepermissions.Caption = "";
         AssignProp("", false, chkavMultirowitemselected_availablepermissions_Internalname, "TitleCaption", chkavMultirowitemselected_availablepermissions.Caption, !bGXsfl_126_Refreshing);
         chkavMultirowitemselected_availablepermissions.CheckedValue = "false";
         AV31MultiRowItemSelected_AvailablePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV31MultiRowItemSelected_AvailablePermissions));
         AssignAttri("", false, chkavMultirowitemselected_availablepermissions_Internalname, AV31MultiRowItemSelected_AvailablePermissions);
         AvailablepermissionsRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_availablepermissions_Internalname,StringUtil.BoolToStr( AV31MultiRowItemSelected_AvailablePermissions),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_availablepermissions.Enabled!=0)&&(chkavMultirowitemselected_availablepermissions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,127);\"" : " ")});
         /* Subfile cell */
         if ( AvailablepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 128,'',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
         ROClassString = "Attribute_Grid";
         AvailablepermissionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV33Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,128);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)126,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( AvailablepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 129,'',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
         ROClassString = "Attribute_Grid";
         AvailablepermissionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV14Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,129);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)-1,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)126,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( AvailablepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         TempTags = " " + ((cmbavAccess.Enabled!=0)&&(cmbavAccess.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 130,'',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
         if ( ( cmbavAccess.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "vACCESS_" + sGXsfl_126_idx;
            cmbavAccess.Name = GXCCtl;
            cmbavAccess.WebTags = "";
            cmbavAccess.addItem("A", "Allow", 0);
            cmbavAccess.addItem("D", "Deny", 0);
            cmbavAccess.addItem("R", "Restricted", 0);
            if ( cmbavAccess.ItemCount > 0 )
            {
               AV6Access = cmbavAccess.getValidValue(AV6Access);
               AssignAttri("", false, cmbavAccess_Internalname, AV6Access);
            }
         }
         /* ComboBox */
         AvailablepermissionsRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAccess,(string)cmbavAccess_Internalname,StringUtil.RTrim( AV6Access),(short)1,(string)cmbavAccess_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute_Grid",(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavAccess.Enabled!=0)&&(cmbavAccess.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,130);\"" : " "),(string)"",(bool)true,(short)1});
         cmbavAccess.CurrentValue = StringUtil.RTrim( AV6Access);
         AssignProp("", false, cmbavAccess_Internalname, "Values", (string)(cmbavAccess.ToJavascriptSource()), !bGXsfl_126_Refreshing);
         /* Subfile cell */
         if ( AvailablepermissionsContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 131,'',false,'"+sGXsfl_126_idx+"',126)\"" : " ");
         ROClassString = "Attribute_Grid";
         AvailablepermissionsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV26Id),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,131);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)126,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"left",(bool)true,(string)""});
         send_integrity_lvl_hashes4E2( ) ;
         AvailablepermissionsContainer.AddRow(AvailablepermissionsRow);
         nGXsfl_126_idx = ((subAvailablepermissions_Islastpage==1)&&(nGXsfl_126_idx+1>subAvailablepermissions_fnc_Recordsperpage( )) ? 1 : nGXsfl_126_idx+1);
         sGXsfl_126_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_126_idx), 4, 0), 4, "0");
         SubsflControlProps_1262( ) ;
         /* End function sendrow_1262 */
      }

      protected void init_web_controls( )
      {
         cmbavPermissionaccesstype.Name = "vPERMISSIONACCESSTYPE";
         cmbavPermissionaccesstype.WebTags = "";
         cmbavPermissionaccesstype.addItem("", "(Ninguno)", 0);
         cmbavPermissionaccesstype.addItem("A", "Allow", 0);
         cmbavPermissionaccesstype.addItem("D", "Deny", 0);
         cmbavPermissionaccesstype.addItem("R", "Restricted", 0);
         if ( cmbavPermissionaccesstype.ItemCount > 0 )
         {
            AV34PermissionAccessType = cmbavPermissionaccesstype.getValidValue(AV34PermissionAccessType);
            AssignAttri("", false, "AV34PermissionAccessType", AV34PermissionAccessType);
         }
         cmbavIsinherited.Name = "vISINHERITED";
         cmbavIsinherited.WebTags = "";
         cmbavIsinherited.addItem("A", "All", 0);
         cmbavIsinherited.addItem("T", "Yes", 0);
         cmbavIsinherited.addItem("F", "No", 0);
         if ( cmbavIsinherited.ItemCount > 0 )
         {
            AV27IsInherited = cmbavIsinherited.getValidValue(AV27IsInherited);
            AssignAttri("", false, "AV27IsInherited", AV27IsInherited);
         }
         cmbavGridsettingsrowsperpage_availablepermissions.Name = "vGRIDSETTINGSROWSPERPAGE_AVAILABLEPERMISSIONS";
         cmbavGridsettingsrowsperpage_availablepermissions.WebTags = "";
         cmbavGridsettingsrowsperpage_availablepermissions.addItem("10", "10", 0);
         cmbavGridsettingsrowsperpage_availablepermissions.addItem("20", "20", 0);
         cmbavGridsettingsrowsperpage_availablepermissions.addItem("50", "50", 0);
         cmbavGridsettingsrowsperpage_availablepermissions.addItem("100", "100", 0);
         cmbavGridsettingsrowsperpage_availablepermissions.addItem("200", "200", 0);
         if ( cmbavGridsettingsrowsperpage_availablepermissions.ItemCount > 0 )
         {
            AV47GridSettingsRowsPerPage_AvailablePermissions = (short)(NumberUtil.Val( cmbavGridsettingsrowsperpage_availablepermissions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0))), "."));
            AssignAttri("", false, "AV47GridSettingsRowsPerPage_AvailablePermissions", StringUtil.LTrimStr( (decimal)(AV47GridSettingsRowsPerPage_AvailablePermissions), 4, 0));
         }
         chkavFreezecolumntitles_availablepermissions.Name = "vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS";
         chkavFreezecolumntitles_availablepermissions.WebTags = "";
         chkavFreezecolumntitles_availablepermissions.Caption = "";
         AssignProp("", false, chkavFreezecolumntitles_availablepermissions_Internalname, "TitleCaption", chkavFreezecolumntitles_availablepermissions.Caption, true);
         chkavFreezecolumntitles_availablepermissions.CheckedValue = "false";
         AV71FreezeColumnTitles_AvailablePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV71FreezeColumnTitles_AvailablePermissions));
         AssignAttri("", false, "AV71FreezeColumnTitles_AvailablePermissions", AV71FreezeColumnTitles_AvailablePermissions);
         chkavCheckall_availablepermissions.Name = "vCHECKALL_AVAILABLEPERMISSIONS";
         chkavCheckall_availablepermissions.WebTags = "";
         chkavCheckall_availablepermissions.Caption = "";
         AssignProp("", false, chkavCheckall_availablepermissions_Internalname, "TitleCaption", chkavCheckall_availablepermissions.Caption, true);
         chkavCheckall_availablepermissions.CheckedValue = "false";
         AV48CheckAll_AvailablePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV48CheckAll_AvailablePermissions));
         AssignAttri("", false, "AV48CheckAll_AvailablePermissions", AV48CheckAll_AvailablePermissions);
         GXCCtl = "vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS_" + sGXsfl_126_idx;
         chkavMultirowitemselected_availablepermissions.Name = GXCCtl;
         chkavMultirowitemselected_availablepermissions.WebTags = "";
         chkavMultirowitemselected_availablepermissions.Caption = "";
         AssignProp("", false, chkavMultirowitemselected_availablepermissions_Internalname, "TitleCaption", chkavMultirowitemselected_availablepermissions.Caption, !bGXsfl_126_Refreshing);
         chkavMultirowitemselected_availablepermissions.CheckedValue = "false";
         AV31MultiRowItemSelected_AvailablePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV31MultiRowItemSelected_AvailablePermissions));
         AssignAttri("", false, chkavMultirowitemselected_availablepermissions_Internalname, AV31MultiRowItemSelected_AvailablePermissions);
         GXCCtl = "vACCESS_" + sGXsfl_126_idx;
         cmbavAccess.Name = GXCCtl;
         cmbavAccess.WebTags = "";
         cmbavAccess.addItem("A", "Allow", 0);
         cmbavAccess.addItem("D", "Deny", 0);
         cmbavAccess.addItem("R", "Restricted", 0);
         if ( cmbavAccess.ItemCount > 0 )
         {
            AV6Access = cmbavAccess.getValidValue(AV6Access);
            AssignAttri("", false, cmbavAccess_Internalname, AV6Access);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         edtavRolename_Internalname = "vROLENAME";
         divTable_container_rolename_Internalname = "TABLE_CONTAINER_ROLENAME";
         edtavApplicationname_Internalname = "vAPPLICATIONNAME";
         divTable_container_applicationname_Internalname = "TABLE_CONTAINER_APPLICATIONNAME";
         divAttributescontainertable_attributes_Internalname = "ATTRIBUTESCONTAINERTABLE_ATTRIBUTES";
         divResponsivetable_mainattributes_attributes_Internalname = "RESPONSIVETABLE_MAINATTRIBUTES_ATTRIBUTES";
         edtavGenericfilter_availablepermissions_Internalname = "vGENERICFILTER_AVAILABLEPERMISSIONS";
         imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname = "LAYOUTDEFINED_FILTERTOGGLE_COMBINED_AVAILABLEPERMISSIONS";
         Filtertagsusercontrol_availablepermissions_Internalname = "FILTERTAGSUSERCONTROL_AVAILABLEPERMISSIONS";
         divLayoutdefined_section4_availablepermissions_Internalname = "LAYOUTDEFINED_SECTION4_AVAILABLEPERMISSIONS";
         imgLayoutdefined_filterclose_combined_availablepermissions_Internalname = "LAYOUTDEFINED_FILTERCLOSE_COMBINED_AVAILABLEPERMISSIONS";
         cmbavPermissionaccesstype_Internalname = "vPERMISSIONACCESSTYPE";
         divTable_container_permissionaccesstype_Internalname = "TABLE_CONTAINER_PERMISSIONACCESSTYPE";
         cmbavIsinherited_Internalname = "vISINHERITED";
         divTable_container_isinherited_Internalname = "TABLE_CONTAINER_ISINHERITED";
         divFiltercontainertable_filters_Internalname = "FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = "MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname = "LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS";
         divLayoutdefined_combinedfilterlayout_availablepermissions_Internalname = "LAYOUTDEFINED_COMBINEDFILTERLAYOUT_AVAILABLEPERMISSIONS";
         divLayoutdefined_filterglobalcontainer_availablepermissions_Internalname = "LAYOUTDEFINED_FILTERGLOBALCONTAINER_AVAILABLEPERMISSIONS";
         imgGridsettings_labelavailablepermissions_Internalname = "GRIDSETTINGS_LABELAVAILABLEPERMISSIONS";
         lblGslayoutdefined_availablepermissionsruntimecolumnselectiontb_Internalname = "GSLAYOUTDEFINED_AVAILABLEPERMISSIONSRUNTIMECOLUMNSELECTIONTB";
         cmbavGridsettingsrowsperpage_availablepermissions_Internalname = "vGRIDSETTINGSROWSPERPAGE_AVAILABLEPERMISSIONS";
         divRowsperpagecontainer_availablepermissions_Internalname = "ROWSPERPAGECONTAINER_AVAILABLEPERMISSIONS";
         chkavFreezecolumntitles_availablepermissions_Internalname = "vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS";
         divFreezecolumntitlescontainer_availablepermissions_Internalname = "FREEZECOLUMNTITLESCONTAINER_AVAILABLEPERMISSIONS";
         bttGridsettings_saveavailablepermissions_Internalname = "GRIDSETTINGS_SAVEAVAILABLEPERMISSIONS";
         divGslayoutdefined_availablepermissionscustomizationcollapsiblesection_Internalname = "GSLAYOUTDEFINED_AVAILABLEPERMISSIONSCUSTOMIZATIONCOLLAPSIBLESECTION";
         divGridcustomizationcontainer_availablepermissions_Internalname = "GRIDCUSTOMIZATIONCONTAINER_AVAILABLEPERMISSIONS";
         divGslayoutdefined_availablepermissionscontentinnertable_Internalname = "GSLAYOUTDEFINED_AVAILABLEPERMISSIONSCONTENTINNERTABLE";
         divGridsettings_contentoutertableavailablepermissions_Internalname = "GRIDSETTINGS_CONTENTOUTERTABLEAVAILABLEPERMISSIONS";
         divGridsettings_globaltable_availablepermissions_Internalname = "GRIDSETTINGS_GLOBALTABLE_AVAILABLEPERMISSIONS";
         bttAddselected_Internalname = "ADDSELECTED";
         tblActions_availablepermissions_topright_Internalname = "ACTIONS_AVAILABLEPERMISSIONS_TOPRIGHT";
         tblLayoutdefined_table7_availablepermissions_Internalname = "LAYOUTDEFINED_TABLE7_AVAILABLEPERMISSIONS";
         divLayoutdefined_table10_availablepermissions_Internalname = "LAYOUTDEFINED_TABLE10_AVAILABLEPERMISSIONS";
         chkavCheckall_availablepermissions_Internalname = "vCHECKALL_AVAILABLEPERMISSIONS";
         chkavMultirowitemselected_availablepermissions_Internalname = "vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         cmbavAccess_Internalname = "vACCESS";
         edtavId_Internalname = "vID";
         tblTablegridcontainer_availablepermissions_Internalname = "TABLEGRIDCONTAINER_AVAILABLEPERMISSIONS";
         lblI_noresultsfoundtextblock_availablepermissions_Internalname = "I_NORESULTSFOUNDTEXTBLOCK_AVAILABLEPERMISSIONS";
         tblI_noresultsfoundtablename_availablepermissions_Internalname = "I_NORESULTSFOUNDTABLENAME_AVAILABLEPERMISSIONS";
         divMaingrid_responsivetable_availablepermissions_Internalname = "MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS";
         lblPaginationbar_previouspagebuttontextblockavailablepermissions_Internalname = "PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_firstpagetextblockavailablepermissions_Internalname = "PAGINATIONBAR_FIRSTPAGETEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname = "PAGINATIONBAR_SPACINGLEFTTEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_previouspagetextblockavailablepermissions_Internalname = "PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_currentpagetextblockavailablepermissions_Internalname = "PAGINATIONBAR_CURRENTPAGETEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_nextpagetextblockavailablepermissions_Internalname = "PAGINATIONBAR_NEXTPAGETEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_spacingrighttextblockavailablepermissions_Internalname = "PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKAVAILABLEPERMISSIONS";
         lblPaginationbar_nextpagebuttontextblockavailablepermissions_Internalname = "PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKAVAILABLEPERMISSIONS";
         divPaginationbar_pagingcontainertable_availablepermissions_Internalname = "PAGINATIONBAR_PAGINGCONTAINERTABLE_AVAILABLEPERMISSIONS";
         divLayoutdefined_section8_availablepermissions_Internalname = "LAYOUTDEFINED_SECTION8_AVAILABLEPERMISSIONS";
         divLayoutdefined_table3_availablepermissions_Internalname = "LAYOUTDEFINED_TABLE3_AVAILABLEPERMISSIONS";
         divLayoutdefined_grid_inner_availablepermissions_Internalname = "LAYOUTDEFINED_GRID_INNER_AVAILABLEPERMISSIONS";
         divGridcomponentcontent_availablepermissions_Internalname = "GRIDCOMPONENTCONTENT_AVAILABLEPERMISSIONS";
         divContenttable_Internalname = "CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = "K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subAvailablepermissions_Internalname = "AVAILABLEPERMISSIONS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("K2BOrion");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         chkavCheckall_availablepermissions.Caption = "";
         chkavFreezecolumntitles_availablepermissions.Caption = "Inmovilizar t�tulos";
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         cmbavAccess_Jsonclick = "";
         cmbavAccess.Visible = -1;
         cmbavAccess.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Visible = -1;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         chkavMultirowitemselected_availablepermissions.Caption = "";
         chkavMultirowitemselected_availablepermissions.Visible = -1;
         chkavMultirowitemselected_availablepermissions.Enabled = 1;
         bttAddselected_Visible = 1;
         chkavFreezecolumntitles_availablepermissions.Enabled = 1;
         cmbavGridsettingsrowsperpage_availablepermissions_Jsonclick = "";
         cmbavGridsettingsrowsperpage_availablepermissions.Enabled = 1;
         divGridsettings_contentoutertableavailablepermissions_Visible = 1;
         subAvailablepermissions_Allowcollapsing = 0;
         subAvailablepermissions_Allowselection = 0;
         edtavId_Enabled = 1;
         edtavDsc_Enabled = 1;
         edtavName_Enabled = 1;
         subAvailablepermissions_Header = "";
         subAvailablepermissions_Class = "K2BT_SG Grid_WorkWith";
         subAvailablepermissions_Backcolorstyle = 0;
         chkavCheckall_availablepermissions.Enabled = 1;
         tblI_noresultsfoundtablename_availablepermissions_Visible = 1;
         subAvailablepermissions_Sortable = 0;
         lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         lblPaginationbar_spacingrighttextblockavailablepermissions_Visible = 1;
         lblPaginationbar_nextpagetextblockavailablepermissions_Caption = "#";
         lblPaginationbar_nextpagetextblockavailablepermissions_Visible = 1;
         lblPaginationbar_currentpagetextblockavailablepermissions_Caption = "#";
         lblPaginationbar_previouspagetextblockavailablepermissions_Caption = "#";
         lblPaginationbar_previouspagetextblockavailablepermissions_Visible = 1;
         lblPaginationbar_spacinglefttextblockavailablepermissions_Visible = 1;
         lblPaginationbar_firstpagetextblockavailablepermissions_Caption = "1";
         lblPaginationbar_firstpagetextblockavailablepermissions_Visible = 1;
         lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class = "K2BToolsTextBlock_PaginationNormal";
         divPaginationbar_pagingcontainertable_availablepermissions_Visible = 1;
         divMaingrid_responsivetable_availablepermissions_Class = "Section_Grid";
         cmbavIsinherited_Jsonclick = "";
         cmbavIsinherited.Enabled = 1;
         cmbavPermissionaccesstype_Jsonclick = "";
         cmbavPermissionaccesstype.Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible = 1;
         imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
         edtavGenericfilter_availablepermissions_Jsonclick = "";
         edtavGenericfilter_availablepermissions_Enabled = 1;
         edtavApplicationname_Jsonclick = "";
         edtavApplicationname_Enabled = 1;
         edtavRolename_Jsonclick = "";
         edtavRolename_Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Agregar permiso";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AVAILABLEPERMISSIONS_nFirstRecordOnPage'},{av:'AVAILABLEPERMISSIONS_nEOF'},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV40RoleName',fld:'vROLENAME',pic:''},{av:'AV11ApplicationName',fld:'vAPPLICATIONNAME',pic:''},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("AVAILABLEPERMISSIONS.LOAD","{handler:'E204E2',iparms:[{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("AVAILABLEPERMISSIONS.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_availablepermissions_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_AVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'cmbavAccess'},{av:'AV6Access',fld:'vACCESS',pic:''},{av:'AV31MultiRowItemSelected_AvailablePermissions',fld:'vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS',pic:''},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV33Name',fld:'vNAME',pic:'',hsh:true},{av:'AV14Dsc',fld:'vDSC',pic:'',hsh:true},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV57S_Id',fld:'vS_ID',pic:''},{av:'lblPaginationbar_firstpagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_availablepermissions_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_AVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("'PAGINGPREVIOUS(AVAILABLEPERMISSIONS)'","{handler:'E114E1',iparms:[{av:'AVAILABLEPERMISSIONS_nFirstRecordOnPage'},{av:'AVAILABLEPERMISSIONS_nEOF'},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("'PAGINGPREVIOUS(AVAILABLEPERMISSIONS)'",",oparms:[{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV40RoleName',fld:'vROLENAME',pic:''},{av:'AV11ApplicationName',fld:'vAPPLICATIONNAME',pic:''},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("'PAGINGNEXT(AVAILABLEPERMISSIONS)'","{handler:'E134E1',iparms:[{av:'AVAILABLEPERMISSIONS_nFirstRecordOnPage'},{av:'AVAILABLEPERMISSIONS_nEOF'},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("'PAGINGNEXT(AVAILABLEPERMISSIONS)'",",oparms:[{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV40RoleName',fld:'vROLENAME',pic:''},{av:'AV11ApplicationName',fld:'vAPPLICATIONNAME',pic:''},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("'E_ADDSELECTED'","{handler:'E144E2',iparms:[{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV30MultiRowHasNext_AvailablePermissions',fld:'vMULTIROWHASNEXT_AVAILABLEPERMISSIONS',pic:''},{av:'AV32MultiRowIterator_AvailablePermissions',fld:'vMULTIROWITERATOR_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV52SelectedItems_AvailablePermissions',fld:'vSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV57S_Id',fld:'vS_ID',pic:''},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("'E_ADDSELECTED'",",oparms:[{av:'AV52SelectedItems_AvailablePermissions',fld:'vSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV32MultiRowIterator_AvailablePermissions',fld:'vMULTIROWITERATOR_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV57S_Id',fld:'vS_ID',pic:''},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV30MultiRowHasNext_AvailablePermissions',fld:'vMULTIROWHASNEXT_AVAILABLEPERMISSIONS',pic:''},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS.CLICK","{handler:'E214E2',iparms:[{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV26Id',fld:'vID',grid:126,pic:'',hsh:true},{av:'AVAILABLEPERMISSIONS_nFirstRecordOnPage'},{av:'nRC_GXsfl_126',ctrl:'AVAILABLEPERMISSIONS',grid:126,prop:'GridRC',grid:126},{av:'AV31MultiRowItemSelected_AvailablePermissions',fld:'vMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS',grid:126,pic:''},{av:'AV6Access',fld:'vACCESS',grid:126,pic:''},{av:'AV33Name',fld:'vNAME',grid:126,pic:'',hsh:true},{av:'AV14Dsc',fld:'vDSC',grid:126,pic:'',hsh:true},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("VMULTIROWITEMSELECTED_AVAILABLEPERMISSIONS.CLICK",",oparms:[{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("'PAGINGFIRST(AVAILABLEPERMISSIONS)'","{handler:'E124E1',iparms:[{av:'AVAILABLEPERMISSIONS_nFirstRecordOnPage'},{av:'AVAILABLEPERMISSIONS_nEOF'},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("'PAGINGFIRST(AVAILABLEPERMISSIONS)'",",oparms:[{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV40RoleName',fld:'vROLENAME',pic:''},{av:'AV11ApplicationName',fld:'vAPPLICATIONNAME',pic:''},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("'TOGGLEGRIDSETTINGS(AVAILABLEPERMISSIONS)'","{handler:'E234E1',iparms:[{av:'divGridsettings_contentoutertableavailablepermissions_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEAVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("'TOGGLEGRIDSETTINGS(AVAILABLEPERMISSIONS)'",",oparms:[{av:'cmbavGridsettingsrowsperpage_availablepermissions'},{av:'AV47GridSettingsRowsPerPage_AvailablePermissions',fld:'vGRIDSETTINGSROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertableavailablepermissions_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEAVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("'SAVEGRIDSETTINGS(AVAILABLEPERMISSIONS)'","{handler:'E154E2',iparms:[{av:'AVAILABLEPERMISSIONS_nFirstRecordOnPage'},{av:'AVAILABLEPERMISSIONS_nEOF'},{av:'AV39RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV26Id',fld:'vID',pic:'',hsh:true},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'AV56S_Access',fld:'vS_ACCESS',pic:''},{av:'AV25I_LoadCount_AvailablePermissions',fld:'vI_LOADCOUNT_AVAILABLEPERMISSIONS',pic:'ZZZ9',hsh:true},{av:'AV61FieldValues_AvailablePermissions',fld:'vFIELDVALUES_AVAILABLEPERMISSIONS',pic:''},{av:'cmbavGridsettingsrowsperpage_availablepermissions'},{av:'AV47GridSettingsRowsPerPage_AvailablePermissions',fld:'vGRIDSETTINGSROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("'SAVEGRIDSETTINGS(AVAILABLEPERMISSIONS)'",",oparms:[{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV46RowsPerPage_AvailablePermissions',fld:'vROWSPERPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'divGridsettings_contentoutertableavailablepermissions_Visible',ctrl:'GRIDSETTINGS_CONTENTOUTERTABLEAVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'AV40RoleName',fld:'vROLENAME',pic:''},{av:'AV11ApplicationName',fld:'vAPPLICATIONNAME',pic:''},{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("AVAILABLEPERMISSIONS.REFRESH","{handler:'E224E2',iparms:[{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV34PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'cmbavIsinherited'},{av:'AV27IsInherited',fld:'vISINHERITED',pic:''},{av:'AV51AllSelectedItems_AvailablePermissions',fld:'vALLSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:''},{av:'AV75Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV66GenericFilter_AvailablePermissions',fld:'vGENERICFILTER_AVAILABLEPERMISSIONS',pic:''},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'AV23HasNextPage_AvailablePermissions',fld:'vHASNEXTPAGE_AVAILABLEPERMISSIONS',pic:'',hsh:true},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("AVAILABLEPERMISSIONS.REFRESH",",oparms:[{av:'AV70ClassCollection_AvailablePermissions',fld:'vCLASSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV59PermissionAccessType_PreviousValue',fld:'vPERMISSIONACCESSTYPE_PREVIOUSVALUE',pic:''},{av:'AV13CurrentPage_AvailablePermissions',fld:'vCURRENTPAGE_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{av:'AV60IsInherited_PreviousValue',fld:'vISINHERITED_PREVIOUSVALUE',pic:''},{av:'subAvailablepermissions_Backcolorstyle',ctrl:'AVAILABLEPERMISSIONS',prop:'Backcolorstyle'},{av:'AV12AvailablePermissions_SelectedRows',fld:'vAVAILABLEPERMISSIONS_SELECTEDROWS',pic:'ZZZ9'},{av:'divMaingrid_responsivetable_availablepermissions_Class',ctrl:'MAINGRID_RESPONSIVETABLE_AVAILABLEPERMISSIONS',prop:'Class'},{av:'Filtertagsusercontrol_availablepermissions_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_AVAILABLEPERMISSIONS',prop:'EmptyStateMessage'},{av:'AV68FilterTagsCollection_AvailablePermissions',fld:'vFILTERTAGSCOLLECTION_AVAILABLEPERMISSIONS',pic:''},{av:'AV67GridConfiguration',fld:'vGRIDCONFIGURATION',pic:''},{av:'lblPaginationbar_firstpagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_currentpagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_CURRENTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_nextpagetextblockavailablepermissions_Caption',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Caption'},{av:'lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class',ctrl:'PAGINATIONBAR_PREVIOUSPAGEBUTTONTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class',ctrl:'PAGINATIONBAR_NEXTPAGEBUTTONTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Class'},{av:'lblPaginationbar_firstpagetextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_FIRSTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacinglefttextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGLEFTTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_previouspagetextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_PREVIOUSPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_spacingrighttextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_SPACINGRIGHTTEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'lblPaginationbar_nextpagetextblockavailablepermissions_Visible',ctrl:'PAGINATIONBAR_NEXTPAGETEXTBLOCKAVAILABLEPERMISSIONS',prop:'Visible'},{av:'divPaginationbar_pagingcontainertable_availablepermissions_Visible',ctrl:'PAGINATIONBAR_PAGINGCONTAINERTABLE_AVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV62CountSelectedItems_AvailablePermissions',fld:'vCOUNTSELECTEDITEMS_AVAILABLEPERMISSIONS',pic:'ZZZ9'},{ctrl:'ADDSELECTED',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_AVAILABLEPERMISSIONS.CLICK","{handler:'E164E2',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_COMBINED_AVAILABLEPERMISSIONS.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_AVAILABLEPERMISSIONS.CLICK","{handler:'E174E2',iparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_COMBINED_AVAILABLEPERMISSIONS.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_COMBINED_AVAILABLEPERMISSIONS',prop:'Visible'},{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPE","{handler:'Validv_Permissionaccesstype',iparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPE",",oparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("VALIDV_ISINHERITED","{handler:'Validv_Isinherited',iparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("VALIDV_ISINHERITED",",oparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("VALIDV_ACCESS","{handler:'Validv_Access',iparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("VALIDV_ACCESS",",oparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Id',iparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV71FreezeColumnTitles_AvailablePermissions',fld:'vFREEZECOLUMNTITLES_AVAILABLEPERMISSIONS',pic:''},{av:'AV48CheckAll_AvailablePermissions',fld:'vCHECKALL_AVAILABLEPERMISSIONS',pic:''}]}");
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
         AV70ClassCollection_AvailablePermissions = new GxSimpleCollection<string>();
         AV59PermissionAccessType_PreviousValue = "";
         AV34PermissionAccessType = "";
         AV60IsInherited_PreviousValue = "";
         AV27IsInherited = "";
         AV51AllSelectedItems_AvailablePermissions = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV75Pgmname = "";
         AV66GenericFilter_AvailablePermissions = "";
         AV67GridConfiguration = new SdtK2BGridConfiguration(context);
         AV26Id = "";
         AV56S_Access = "";
         AV61FieldValues_AvailablePermissions = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "kb_ticket");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV68FilterTagsCollection_AvailablePermissions = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV69DeletedTag_AvailablePermissions = "";
         AV52SelectedItems_AvailablePermissions = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV57S_Id = "";
         AV49SelectedItem_AvailablePermissions = new SdtK2BSelectionItem(context);
         AV50FieldValue_AvailablePermissions = new SdtK2BSelectionItem_FieldValuesItem(context);
         Filtertagsusercontrol_availablepermissions_Emptystatemessage = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         AV40RoleName = "";
         AV11ApplicationName = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_combined_availablepermissions_Jsonclick = "";
         ucFiltertagsusercontrol_availablepermissions = new GXUserControl();
         imgLayoutdefined_filterclose_combined_availablepermissions_Jsonclick = "";
         lblPaginationbar_previouspagebuttontextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_firstpagetextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_spacinglefttextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_previouspagetextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_currentpagetextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_nextpagetextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_spacingrighttextblockavailablepermissions_Jsonclick = "";
         lblPaginationbar_nextpagebuttontextblockavailablepermissions_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         AvailablepermissionsContainer = new GXWebGrid( context);
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV33Name = "";
         AV14Dsc = "";
         AV6Access = "";
         AV19GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV18GAMApplication = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV45Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtMessages_Message1 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV28Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV24HttpRequest = new GxHttpRequest( context);
         AvailablepermissionsRow = new GXWebRow();
         AV36PermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV37Permissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV16Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV54S_Name = "";
         AV55S_Dsc = "";
         AV35PermissionAdd = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV15Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV22GridStateKey = "";
         AV20GridState = new SdtK2BGridState(context);
         AV21GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         GXt_char2 = "";
         AV64K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV65K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item3 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         lblI_noresultsfoundtextblock_availablepermissions_Jsonclick = "";
         subAvailablepermissions_Linesclass = "";
         AvailablepermissionsColumn = new GXWebColumn();
         imgGridsettings_labelavailablepermissions_Jsonclick = "";
         lblGslayoutdefined_availablepermissionsruntimecolumnselectiontb_Jsonclick = "";
         bttGridsettings_saveavailablepermissions_Jsonclick = "";
         bttAddselected_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         GXCCtl = "";
         ROClassString = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleaddpermission__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleaddpermission__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleaddpermission__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleaddpermission__default(),
            new Object[][] {
            }
         );
         AV75Pgmname = "K2BFSG.RoleAddPermission";
         /* GeneXus formulas. */
         AV75Pgmname = "K2BFSG.RoleAddPermission";
         context.Gx_err = 0;
         edtavRolename_Enabled = 0;
         edtavApplicationname_Enabled = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV13CurrentPage_AvailablePermissions ;
      private short AV62CountSelectedItems_AvailablePermissions ;
      private short AV46RowsPerPage_AvailablePermissions ;
      private short AV12AvailablePermissions_SelectedRows ;
      private short AV25I_LoadCount_AvailablePermissions ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short AV32MultiRowIterator_AvailablePermissions ;
      private short AV53Index_AvailablePermissions ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV47GridSettingsRowsPerPage_AvailablePermissions ;
      private short subAvailablepermissions_Backcolorstyle ;
      private short subAvailablepermissions_Sortable ;
      private short AVAILABLEPERMISSIONS_nEOF ;
      private short subAvailablepermissions_Titlebackstyle ;
      private short subAvailablepermissions_Allowselection ;
      private short subAvailablepermissions_Allowhovering ;
      private short subAvailablepermissions_Allowcollapsing ;
      private short subAvailablepermissions_Collapsed ;
      private short subAvailablepermissions_Backstyle ;
      private int divGridsettings_contentoutertableavailablepermissions_Visible ;
      private int divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Visible ;
      private int nRC_GXsfl_126 ;
      private int nGXsfl_126_idx=1 ;
      private int AV82GXV6 ;
      private int edtavRolename_Enabled ;
      private int edtavApplicationname_Enabled ;
      private int edtavGenericfilter_availablepermissions_Enabled ;
      private int divPaginationbar_pagingcontainertable_availablepermissions_Visible ;
      private int lblPaginationbar_firstpagetextblockavailablepermissions_Visible ;
      private int lblPaginationbar_spacinglefttextblockavailablepermissions_Visible ;
      private int lblPaginationbar_previouspagetextblockavailablepermissions_Visible ;
      private int lblPaginationbar_nextpagetextblockavailablepermissions_Visible ;
      private int lblPaginationbar_spacingrighttextblockavailablepermissions_Visible ;
      private int subAvailablepermissions_Islastpage ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavId_Enabled ;
      private int AV74GXV1 ;
      private int tblI_noresultsfoundtablename_availablepermissions_Visible ;
      private int AV76GXV2 ;
      private int AV77GXV3 ;
      private int AV78GXV4 ;
      private int AV79GXV5 ;
      private int nGXsfl_126_fel_idx=1 ;
      private int bttAddselected_Visible ;
      private int AV83GXV7 ;
      private int subAvailablepermissions_Titlebackcolor ;
      private int subAvailablepermissions_Allbackcolor ;
      private int subAvailablepermissions_Selectedindex ;
      private int subAvailablepermissions_Selectioncolor ;
      private int subAvailablepermissions_Hoveringcolor ;
      private int idxLst ;
      private int subAvailablepermissions_Backcolor ;
      private int edtavName_Visible ;
      private int edtavDsc_Visible ;
      private int edtavId_Visible ;
      private long AV39RoleId ;
      private long AV10ApplicationId ;
      private long wcpOAV39RoleId ;
      private long wcpOAV10ApplicationId ;
      private long AVAILABLEPERMISSIONS_nCurrentRecord ;
      private long AVAILABLEPERMISSIONS_nFirstRecordOnPage ;
      private long AV9AppId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_126_idx="0001" ;
      private string AV59PermissionAccessType_PreviousValue ;
      private string AV34PermissionAccessType ;
      private string AV60IsInherited_PreviousValue ;
      private string AV27IsInherited ;
      private string AV75Pgmname ;
      private string AV66GenericFilter_AvailablePermissions ;
      private string AV26Id ;
      private string AV56S_Access ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV69DeletedTag_AvailablePermissions ;
      private string AV57S_Id ;
      private string Filtertagsusercontrol_availablepermissions_Emptystatemessage ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divResponsivetable_mainattributes_attributes_Internalname ;
      private string divAttributescontainertable_attributes_Internalname ;
      private string divTable_container_rolename_Internalname ;
      private string edtavRolename_Internalname ;
      private string TempTags ;
      private string AV40RoleName ;
      private string edtavRolename_Jsonclick ;
      private string divTable_container_applicationname_Internalname ;
      private string edtavApplicationname_Internalname ;
      private string AV11ApplicationName ;
      private string edtavApplicationname_Jsonclick ;
      private string divGridcomponentcontent_availablepermissions_Internalname ;
      private string divLayoutdefined_grid_inner_availablepermissions_Internalname ;
      private string divLayoutdefined_table10_availablepermissions_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_availablepermissions_Internalname ;
      private string divLayoutdefined_combinedfilterlayout_availablepermissions_Internalname ;
      private string divLayoutdefined_section4_availablepermissions_Internalname ;
      private string edtavGenericfilter_availablepermissions_Internalname ;
      private string edtavGenericfilter_availablepermissions_Jsonclick ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_combined_availablepermissions_Internalname ;
      private string imgLayoutdefined_filtertoggle_combined_availablepermissions_Jsonclick ;
      private string Filtertagsusercontrol_availablepermissions_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_combined_availablepermissions_Internalname ;
      private string imgLayoutdefined_filterclose_combined_availablepermissions_Internalname ;
      private string imgLayoutdefined_filterclose_combined_availablepermissions_Jsonclick ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_permissionaccesstype_Internalname ;
      private string cmbavPermissionaccesstype_Internalname ;
      private string cmbavPermissionaccesstype_Jsonclick ;
      private string divTable_container_isinherited_Internalname ;
      private string cmbavIsinherited_Internalname ;
      private string cmbavIsinherited_Jsonclick ;
      private string divLayoutdefined_table3_availablepermissions_Internalname ;
      private string divMaingrid_responsivetable_availablepermissions_Internalname ;
      private string divMaingrid_responsivetable_availablepermissions_Class ;
      private string divLayoutdefined_section8_availablepermissions_Internalname ;
      private string divPaginationbar_pagingcontainertable_availablepermissions_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_previouspagebuttontextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_previouspagebuttontextblockavailablepermissions_Class ;
      private string lblPaginationbar_firstpagetextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_firstpagetextblockavailablepermissions_Caption ;
      private string lblPaginationbar_firstpagetextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_spacinglefttextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_spacinglefttextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_previouspagetextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_previouspagetextblockavailablepermissions_Caption ;
      private string lblPaginationbar_previouspagetextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_currentpagetextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_currentpagetextblockavailablepermissions_Caption ;
      private string lblPaginationbar_currentpagetextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_nextpagetextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_nextpagetextblockavailablepermissions_Caption ;
      private string lblPaginationbar_nextpagetextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_spacingrighttextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_spacingrighttextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockavailablepermissions_Internalname ;
      private string lblPaginationbar_nextpagebuttontextblockavailablepermissions_Jsonclick ;
      private string lblPaginationbar_nextpagebuttontextblockavailablepermissions_Class ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavMultirowitemselected_availablepermissions_Internalname ;
      private string AV33Name ;
      private string edtavName_Internalname ;
      private string AV14Dsc ;
      private string edtavDsc_Internalname ;
      private string cmbavAccess_Internalname ;
      private string AV6Access ;
      private string edtavId_Internalname ;
      private string cmbavGridsettingsrowsperpage_availablepermissions_Internalname ;
      private string chkavFreezecolumntitles_availablepermissions_Internalname ;
      private string chkavCheckall_availablepermissions_Internalname ;
      private string divGridsettings_contentoutertableavailablepermissions_Internalname ;
      private string tblI_noresultsfoundtablename_availablepermissions_Internalname ;
      private string AV54S_Name ;
      private string AV55S_Dsc ;
      private string sGXsfl_126_fel_idx="0001" ;
      private string GXt_char2 ;
      private string bttAddselected_Internalname ;
      private string lblI_noresultsfoundtextblock_availablepermissions_Internalname ;
      private string lblI_noresultsfoundtextblock_availablepermissions_Jsonclick ;
      private string tblTablegridcontainer_availablepermissions_Internalname ;
      private string subAvailablepermissions_Internalname ;
      private string subAvailablepermissions_Class ;
      private string subAvailablepermissions_Linesclass ;
      private string subAvailablepermissions_Header ;
      private string tblLayoutdefined_table7_availablepermissions_Internalname ;
      private string divGridsettings_globaltable_availablepermissions_Internalname ;
      private string imgGridsettings_labelavailablepermissions_Internalname ;
      private string imgGridsettings_labelavailablepermissions_Jsonclick ;
      private string divGslayoutdefined_availablepermissionscontentinnertable_Internalname ;
      private string divGridcustomizationcontainer_availablepermissions_Internalname ;
      private string lblGslayoutdefined_availablepermissionsruntimecolumnselectiontb_Internalname ;
      private string lblGslayoutdefined_availablepermissionsruntimecolumnselectiontb_Jsonclick ;
      private string divGslayoutdefined_availablepermissionscustomizationcollapsiblesection_Internalname ;
      private string divRowsperpagecontainer_availablepermissions_Internalname ;
      private string cmbavGridsettingsrowsperpage_availablepermissions_Jsonclick ;
      private string divFreezecolumntitlescontainer_availablepermissions_Internalname ;
      private string bttGridsettings_saveavailablepermissions_Internalname ;
      private string bttGridsettings_saveavailablepermissions_Jsonclick ;
      private string tblActions_availablepermissions_topright_Internalname ;
      private string bttAddselected_Jsonclick ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string cmbavAccess_Jsonclick ;
      private string edtavId_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV23HasNextPage_AvailablePermissions ;
      private bool AV71FreezeColumnTitles_AvailablePermissions ;
      private bool AV48CheckAll_AvailablePermissions ;
      private bool AV30MultiRowHasNext_AvailablePermissions ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV31MultiRowItemSelected_AvailablePermissions ;
      private bool bGXsfl_126_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV63RowsPerPageLoaded_AvailablePermissions ;
      private bool gx_refresh_fired ;
      private bool AV38Reload_AvailablePermissions ;
      private bool AV17Exit_AvailablePermissions ;
      private bool AV44hasError ;
      private bool AV5isOK ;
      private string AV22GridStateKey ;
      private string imgLayoutdefined_filtertoggle_combined_availablepermissions_Bitmap ;
      private GXWebGrid AvailablepermissionsContainer ;
      private GXWebRow AvailablepermissionsRow ;
      private GXWebColumn AvailablepermissionsColumn ;
      private GXUserControl ucFiltertagsusercontrol_availablepermissions ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_RoleId ;
      private long aP1_ApplicationId ;
      private GXCombobox cmbavPermissionaccesstype ;
      private GXCombobox cmbavIsinherited ;
      private GXCombobox cmbavGridsettingsrowsperpage_availablepermissions ;
      private GXCheckbox chkavFreezecolumntitles_availablepermissions ;
      private GXCheckbox chkavCheckall_availablepermissions ;
      private GXCheckbox chkavMultirowitemselected_availablepermissions ;
      private GXCombobox cmbavAccess ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV24HttpRequest ;
      private GxSimpleCollection<string> AV70ClassCollection_AvailablePermissions ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV16Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV37Permissions ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV45Messages ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> GXt_objcol_SdtMessages_Message1 ;
      private GXBaseCollection<SdtK2BSelectionItem> AV51AllSelectedItems_AvailablePermissions ;
      private GXBaseCollection<SdtK2BSelectionItem> AV52SelectedItems_AvailablePermissions ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV61FieldValues_AvailablePermissions ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV64K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV68FilterTagsCollection_AvailablePermissions ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV15Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV18GAMApplication ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV19GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV35PermissionAdd ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV36PermissionFilter ;
      private SdtK2BGridState AV20GridState ;
      private SdtK2BGridState_FilterValue AV21GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV28Message ;
      private SdtK2BSelectionItem AV49SelectedItem_AvailablePermissions ;
      private SdtK2BSelectionItem_FieldValuesItem AV50FieldValue_AvailablePermissions ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV65K2BFilterValuesSDTItem_WebForm ;
      private SdtK2BGridConfiguration AV67GridConfiguration ;
   }

   public class roleaddpermission__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class roleaddpermission__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class roleaddpermission__gam : DataStoreHelperBase, IDataStoreHelper
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

public class roleaddpermission__default : DataStoreHelperBase, IDataStoreHelper
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
