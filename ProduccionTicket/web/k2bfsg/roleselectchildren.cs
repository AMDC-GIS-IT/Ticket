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
   public class roleselectchildren : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public roleselectchildren( )
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

      public roleselectchildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_RoleId )
      {
         this.AV7RoleId = aP0_RoleId;
         executePrivate();
         aP0_RoleId=this.AV7RoleId;
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
         chkavCheckall_grid = new GXCheckbox();
         chkavMultirowitemselected_grid = new GXCheckbox();
         chkavSelectedcheckall_multipleselection = new GXCheckbox();
         chkavSelectedgridmultirowitemselected_multipleselection = new GXCheckbox();
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
                  AV7RoleId = (long)(NumberUtil.Val( GetPar( "RoleId"), "."));
                  AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(long)AV7RoleId});
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
               {
                  nRC_GXsfl_70 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_70"), "."));
                  nGXsfl_70_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_70_idx"), "."));
                  sGXsfl_70_idx = GetPar( "sGXsfl_70_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrGrid_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
               {
                  AV38CurrentPage_Grid = (short)(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."));
                  AV34XMLItems_MultipleSelection = GetPar( "XMLItems_MultipleSelection");
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV72ClassCollection_Grid);
                  AV49FilName = GetPar( "FilName");
                  AV85Pgmname = GetPar( "Pgmname");
                  AV50FilExternalId = GetPar( "FilExternalId");
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV57AllSelectedItems_Grid);
                  AV47Id = (long)(NumberUtil.Val( GetPar( "Id"), "."));
                  AV60Grid_SelectedRows = (short)(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."));
                  AV7RoleId = (long)(NumberUtil.Val( GetPar( "RoleId"), "."));
                  AV43I_LoadCount_Grid = (short)(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."));
                  AV19I_LoadCount_Skip = (short)(NumberUtil.Val( GetPar( "I_LoadCount_Skip"), "."));
                  AV31InCollection = StringUtil.StrToBool( GetPar( "InCollection"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV32MultipleSelectionItems);
                  AV54CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
                  AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( GetPar( "SelectedCheckAll_MultipleSelection"));
                  AV35Reload_MultipleSelection = StringUtil.StrToBool( GetPar( "Reload_MultipleSelection"));
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrGrid_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV85Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
                  AddString( context.getJSONResponse( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Selectedgrid_multipleselection") == 0 )
               {
                  nRC_GXsfl_106 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_106"), "."));
                  nGXsfl_106_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_106_idx"), "."));
                  sGXsfl_106_idx = GetPar( "sGXsfl_106_idx");
                  sPrefix = GetPar( "sPrefix");
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxnrSelectedgrid_multipleselection_newrow( ) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Selectedgrid_multipleselection") == 0 )
               {
                  AV38CurrentPage_Grid = (short)(NumberUtil.Val( GetPar( "CurrentPage_Grid"), "."));
                  AV34XMLItems_MultipleSelection = GetPar( "XMLItems_MultipleSelection");
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV72ClassCollection_Grid);
                  AV35Reload_MultipleSelection = StringUtil.StrToBool( GetPar( "Reload_MultipleSelection"));
                  ajax_req_read_hidden_sdt(GetNextPar( ), AV32MultipleSelectionItems);
                  AV54CheckAll_Grid = StringUtil.StrToBool( GetPar( "CheckAll_Grid"));
                  AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( GetPar( "SelectedCheckAll_MultipleSelection"));
                  AV60Grid_SelectedRows = (short)(NumberUtil.Val( GetPar( "Grid_SelectedRows"), "."));
                  AV43I_LoadCount_Grid = (short)(NumberUtil.Val( GetPar( "I_LoadCount_Grid"), "."));
                  AV19I_LoadCount_Skip = (short)(NumberUtil.Val( GetPar( "I_LoadCount_Skip"), "."));
                  AV85Pgmname = GetPar( "Pgmname");
                  sPrefix = GetPar( "sPrefix");
                  init_default_properties( ) ;
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV85Pgmname, sPrefix) ;
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
            PA452( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV85Pgmname = "K2BFSG.RoleSelectChildren";
               context.Gx_err = 0;
               edtavName_Enabled = 0;
               AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_70_Refreshing);
               edtavId_Enabled = 0;
               AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_70_Refreshing);
               edtavSelected_name_Enabled = 0;
               AssignProp(sPrefix, false, edtavSelected_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_name_Enabled), 5, 0), !bGXsfl_106_Refreshing);
               edtavSelected_id_Enabled = 0;
               AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Enabled), 5, 0), !bGXsfl_106_Refreshing);
               WS452( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
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
            context.SendWebValue( "Seleccionar hijos de rol") ;
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
         context.AddJavascriptSource("gxcfg.js", "?2024188305937", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
         context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("k2bfsg.roleselectchildren.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV7RoleId,12,0))}, new string[] {"RoleId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV38CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV85Pgmname, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_70", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_70), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_106", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_106), 8, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV70FilterTagsCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFILTERTAGSCOLLECTION_GRID", AV70FilterTagsCollection_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vDELETEDTAG_GRID", StringUtil.RTrim( AV71DeletedTag_Grid));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7RoleId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV7RoleId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV38CurrentPage_Grid), "ZZZ9"), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vCLASSCOLLECTION_GRID", AV72ClassCollection_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vCLASSCOLLECTION_GRID", AV72ClassCollection_Grid);
         }
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vRELOAD_MULTIPLESELECTION", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vMULTIPLESELECTIONITEMS", AV32MultipleSelectionItems);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vMULTIPLESELECTIONITEMS", AV32MultipleSelectionItems);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RoleId), 12, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vALLSELECTEDITEMS_GRID", AV57AllSelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vALLSELECTEDITEMS_GRID", AV57AllSelectedItems_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_SKIP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Skip), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vINCOLLECTION", AV31InCollection);
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV85Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV85Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vMULTIROWHASNEXT_GRID", AV41MultiRowHasNext_Grid);
         GxWebStd.gx_hidden_field( context, sPrefix+"vS_NAME", StringUtil.RTrim( AV61S_Name));
         GxWebStd.gx_hidden_field( context, sPrefix+"vS_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62S_Id), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vMULTIROWITERATOR_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV42MultiRowIterator_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDITEMS_GRID", AV58SelectedItems_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDITEMS_GRID", AV58SelectedItems_Grid);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFIELDVALUES_GRID", AV66FieldValues_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFIELDVALUES_GRID", AV66FieldValues_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vINDEX_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV59Index_Grid), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSELECTEDITEM_GRID", AV55SelectedItem_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSELECTEDITEM_GRID", AV55SelectedItem_Grid);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vFIELDVALUE_GRID", AV56FieldValue_Grid);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vFIELDVALUE_GRID", AV56FieldValue_Grid);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage", StringUtil.RTrim( Filtertagsusercontrol_grid_Emptystatemessage));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm452( )
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
         return "K2BFSG.RoleSelectChildren" ;
      }

      public override string GetPgmdesc( )
      {
         return "Seleccionar hijos de rol" ;
      }

      protected void WB450( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "k2bfsg.roleselectchildren.aspx");
               context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
               context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
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
            GxWebStd.gx_div_start( context, divMainmultipleselectionresponsivetable_multipleselection_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcomponentcontent_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_ComponentWithoutTitleContainer K2BToolsTable_WebPanelDesignerGridContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_grid_inner_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_table10_grid_Internalname, 1, 0, "px", 0, "px", "K2BT_WPD_BeforeGridContainer", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "left", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filterglobalcontainer_grid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_onlydetailedfilterlayout_grid_Internalname, 1, 0, "px", 0, "px", "ControlBeautify_ParentCollapsableTable", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_section5_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsSection_OnlyDetailedFilters", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsImage_FilterToggleButton";
            StyleString = "";
            sImgUrl = imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap;
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ELAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
            /* User Defined Control */
            ucFiltertagsusercontrol_grid.SetProperty("TagValues", AV70FilterTagsCollection_Grid);
            ucFiltertagsusercontrol_grid.SetProperty("DeletedTag", AV71DeletedTag_Grid);
            ucFiltertagsusercontrol_grid.Render(context, "k2btagsviewer", Filtertagsusercontrol_grid_Internalname, sPrefix+"FILTERTAGSUSERCONTROL_GRIDContainer");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible, 0, "px", 0, "px", "K2BToolsTable_FilterCollapsibleTable ControlBeautify_CollapsableTable", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Image_Action";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "9aecb836-6551-428a-b43d-2dcaf78773a5", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgLayoutdefined_filterclose_onlydetailed_grid_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgLayoutdefined_filterclose_onlydetailed_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ELAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filname_Internalname, 1, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, "Nombre", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, StringUtil.RTrim( AV49FilName), StringUtil.RTrim( context.localUtil.Format( AV49FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\RoleSelectChildren.htm");
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
            GxWebStd.gx_div_start( context, divTable_container_filexternalid_Internalname, divTable_container_filexternalid_Visible, 0, "px", 0, "px", "K2BT_NGA K2BToolsTable_TopAttributeContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group gx-label-top", "left", "top", ""+" data-gx-for=\""+edtavFilexternalid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilexternalid_Internalname, "Identificador externo", "gx-form-item Attribute_FilterLabel", 1, true, "width: 100%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 100, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilexternalid_Internalname, StringUtil.RTrim( AV50FilExternalId), StringUtil.RTrim( context.localUtil.Format( AV50FilExternalId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilexternalid_Jsonclick, 0, "Attribute_Filter", "", "", "", "", 1, edtavFilexternalid_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "left", true, "", "HLP_K2BFSG\\RoleSelectChildren.htm");
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
            wb_table1_54_452( true) ;
         }
         else
         {
            wb_table1_54_452( false) ;
         }
         return  ;
      }

      protected void wb_table1_54_452e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divLayoutdefined_table3_grid_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_GridControlsContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaingrid_responsivetable_grid_Internalname, 1, 0, "px", 0, "px", divMaingrid_responsivetable_grid_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table2_64_452( true) ;
         }
         else
         {
            wb_table2_64_452( false) ;
         }
         return  ;
      }

      protected void wb_table2_64_452e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table3_76_452( true) ;
         }
         else
         {
            wb_table3_76_452( false) ;
         }
         return  ;
      }

      protected void wb_table3_76_452e( bool wbgen )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMultipleselectionactionscontainerresponsivetable_multipleselection_Internalname, 1, 0, "px", 0, "px", "K2BToolsMultipleSelectionButtons", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsMultipleSelectionImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "403df9aa-667d-48f9-8058-9fe7672d9ae4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMultipleselection_add_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_MultipleSelectionRemove", "Eliminar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgMultipleselection_add_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'REMOVE(MULTIPLESELECTION)\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsMultipleSelectionImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "80546ac5-4685-4f33-bad3-7ceb5a1259f4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgMultipleselection_remove_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "K2BT_MultipleSelectionAdd", "Agregar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgMultipleselection_remove_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ADD(MULTIPLESELECTION)\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "left", "top", "", "", "div");
            wb_table4_90_452( true) ;
         }
         else
         {
            wb_table4_90_452( false) ;
         }
         return  ;
      }

      protected void wb_table4_90_452e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divResponsivetable_containernode_actions_Internalname, 1, 0, "px", 0, "px", "K2BToolsTable_FullWidth", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table5_115_452( true) ;
         }
         else
         {
            wb_table5_115_452( false) ;
         }
         return  ;
      }

      protected void wb_table5_115_452e( bool wbgen )
      {
         if ( wbgen )
         {
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
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 106 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+sPrefix+"Selectedgrid_multipleselectionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Selectedgrid_multipleselection", Selectedgrid_multipleselectionContainer);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData", Selectedgrid_multipleselectionContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData"+"V", Selectedgrid_multipleselectionContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Selectedgrid_multipleselectionContainerData"+"V"+"\" value='"+Selectedgrid_multipleselectionContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START452( )
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
                  Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "Seleccionar hijos de rol", 0) ;
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
               STRUP450( ) ;
            }
         }
      }

      protected void WS452( )
      {
         START452( ) ;
         EVT452( ) ;
      }

      protected void EVT452( )
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
                                 STRUP450( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "'E_CONFIRM'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'E_Confirm' */
                                    E11452 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E12452 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E13452 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADD(MULTIPLESELECTION)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Add(MultipleSelection)' */
                                    E14452 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVE(MULTIPLESELECTION)'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Remove(MultipleSelection)' */
                                    E15452 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E16452 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E17452 ();
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 12), "GRID.REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 32), "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              nGXsfl_70_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
                              SubsflControlProps_702( ) ;
                              AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
                              AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
                              AV45Name = cgiGet( edtavName_Internalname);
                              AssignAttri(sPrefix, false, edtavName_Internalname, AV45Name);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                                 GX_FocusControl = edtavId_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV47Id = 0;
                                 AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
                              }
                              else
                              {
                                 AV47Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","));
                                 AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
                              }
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
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Start */
                                          E18452 ();
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
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          /* Execute user event: Refresh */
                                          E19452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E20452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E16452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.REFRESH") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E21452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VMULTIROWITEMSELECTED_GRID.CLICK") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E22452 ();
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
                                       STRUP450( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E16452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17452 ();
                                       }
                                    }
                                 }
                              }
                              else
                              {
                              }
                           }
                           else if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 35), "SELECTEDGRID_MULTIPLESELECTION.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.DROP") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP450( ) ;
                              }
                              nGXsfl_106_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
                              SubsflControlProps_1063( ) ;
                              AV36SelectedGridMultiRowItemSelected_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedgridmultirowitemselected_multipleselection_Internalname));
                              AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
                              AV46Selected_Name = cgiGet( edtavSelected_name_Internalname);
                              AssignAttri(sPrefix, false, edtavSelected_name_Internalname, AV46Selected_Name);
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSELECTED_ID");
                                 GX_FocusControl = edtavSelected_id_Internalname;
                                 AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV48Selected_Id = 0;
                                 AssignAttri(sPrefix, false, edtavSelected_id_Internalname, StringUtil.LTrimStr( (decimal)(AV48Selected_Id), 12, 0));
                              }
                              else
                              {
                                 AV48Selected_Id = (long)(context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ","));
                                 AssignAttri(sPrefix, false, edtavSelected_id_Internalname, StringUtil.LTrimStr( (decimal)(AV48Selected_Id), 12, 0));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E23453 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP450( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavMultirowitemselected_grid_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "SELECTEDGRID_MULTIPLESELECTION.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E16452 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.DROP") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          GX_FocusControl = chkavSelectedgridmultirowitemselected_multipleselection_Internalname;
                                          AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                          E17452 ();
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

      protected void WE452( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm452( ) ;
            }
         }
      }

      protected void PA452( )
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
               GX_FocusControl = edtavFilname_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_702( ) ;
         while ( nGXsfl_70_idx <= nRC_GXsfl_70 )
         {
            sendrow_702( ) ;
            nGXsfl_70_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxnrSelectedgrid_multipleselection_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1063( ) ;
         while ( nGXsfl_106_idx <= nRC_GXsfl_106 )
         {
            sendrow_1063( ) ;
            nGXsfl_106_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_106_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1063( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Selectedgrid_multipleselectionContainer)) ;
         /* End function gxnrSelectedgrid_multipleselection_newrow */
      }

      protected void gxgrGrid_refresh( short AV38CurrentPage_Grid ,
                                       string AV34XMLItems_MultipleSelection ,
                                       GxSimpleCollection<string> AV72ClassCollection_Grid ,
                                       string AV49FilName ,
                                       string AV85Pgmname ,
                                       string AV50FilExternalId ,
                                       GXBaseCollection<SdtK2BSelectionItem> AV57AllSelectedItems_Grid ,
                                       long AV47Id ,
                                       short AV60Grid_SelectedRows ,
                                       long AV7RoleId ,
                                       short AV43I_LoadCount_Grid ,
                                       short AV19I_LoadCount_Skip ,
                                       bool AV31InCollection ,
                                       GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem> AV32MultipleSelectionItems ,
                                       bool AV54CheckAll_Grid ,
                                       bool AV53SelectedCheckAll_MultipleSelection ,
                                       bool AV35Reload_MultipleSelection ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E19452 ();
         GRID_nCurrentRecord = 0;
         RF452( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void gxgrSelectedgrid_multipleselection_refresh( short AV38CurrentPage_Grid ,
                                                                 string AV34XMLItems_MultipleSelection ,
                                                                 GxSimpleCollection<string> AV72ClassCollection_Grid ,
                                                                 bool AV35Reload_MultipleSelection ,
                                                                 GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem> AV32MultipleSelectionItems ,
                                                                 bool AV54CheckAll_Grid ,
                                                                 bool AV53SelectedCheckAll_MultipleSelection ,
                                                                 short AV60Grid_SelectedRows ,
                                                                 short AV43I_LoadCount_Grid ,
                                                                 short AV19I_LoadCount_Skip ,
                                                                 string AV85Pgmname ,
                                                                 string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         /* Execute user event: Refresh */
         E19452 ();
         SELECTEDGRID_MULTIPLESELECTION_nCurrentRecord = 0;
         RF453( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrSelectedgrid_multipleselection_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
         AV54CheckAll_Grid = StringUtil.StrToBool( StringUtil.BoolToStr( AV54CheckAll_Grid));
         AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( StringUtil.BoolToStr( AV53SelectedCheckAll_MultipleSelection));
         AssignAttri(sPrefix, false, "AV53SelectedCheckAll_MultipleSelection", AV53SelectedCheckAll_MultipleSelection);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         /* Execute user event: Refresh */
         E19452 ();
         RF452( ) ;
         RF453( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV85Pgmname = "K2BFSG.RoleSelectChildren";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_70_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_70_Refreshing);
         edtavSelected_name_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_name_Enabled), 5, 0), !bGXsfl_106_Refreshing);
         edtavSelected_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Enabled), 5, 0), !bGXsfl_106_Refreshing);
      }

      protected void RF452( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 70;
         E21452 ();
         nGXsfl_70_idx = 1;
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         bGXsfl_70_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_702( ) ;
            E20452 ();
            wbEnd = 70;
            WB450( ) ;
         }
         bGXsfl_70_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes452( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"vCURRENTPAGE_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV38CurrentPage_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV38CurrentPage_Grid), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, sPrefix+"vRELOAD_MULTIPLESELECTION", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vGRID_SELECTEDROWS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60Grid_SelectedRows), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_GRID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43I_LoadCount_Grid), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vI_LOADCOUNT_SKIP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19I_LoadCount_Skip), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPGMNAME", StringUtil.RTrim( AV85Pgmname));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vPGMNAME", GetSecureSignedToken( sPrefix, StringUtil.RTrim( context.localUtil.Format( AV85Pgmname, "")), context));
      }

      protected void RF453( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Selectedgrid_multipleselectionContainer.ClearRows();
         }
         wbStart = 106;
         nGXsfl_106_idx = 1;
         sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
         SubsflControlProps_1063( ) ;
         bGXsfl_106_Refreshing = true;
         Selectedgrid_multipleselectionContainer.AddObjectProperty("GridName", "Selectedgrid_multipleselection");
         Selectedgrid_multipleselectionContainer.AddObjectProperty("CmpContext", sPrefix);
         Selectedgrid_multipleselectionContainer.AddObjectProperty("InMasterPage", "false");
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Backcolorstyle), 1, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Sortable), 1, 0, ".", "")));
         Selectedgrid_multipleselectionContainer.PageSize = subSelectedgrid_multipleselection_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1063( ) ;
            E23453 ();
            wbEnd = 106;
            WB450( ) ;
         }
         bGXsfl_106_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes453( )
      {
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subSelectedgrid_multipleselection_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         AV85Pgmname = "K2BFSG.RoleSelectChildren";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         AssignProp(sPrefix, false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_70_Refreshing);
         edtavId_Enabled = 0;
         AssignProp(sPrefix, false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_70_Refreshing);
         edtavSelected_name_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_name_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_name_Enabled), 5, 0), !bGXsfl_106_Refreshing);
         edtavSelected_id_Enabled = 0;
         AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Enabled), 5, 0), !bGXsfl_106_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP450( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E18452 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFILTERTAGSCOLLECTION_GRID"), AV70FilterTagsCollection_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vALLSELECTEDITEMS_GRID"), AV57AllSelectedItems_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vSELECTEDITEM_GRID"), AV55SelectedItem_Grid);
            ajax_req_read_hidden_sdt(cgiGet( sPrefix+"vFIELDVALUE_GRID"), AV56FieldValue_Grid);
            /* Read saved values. */
            nRC_GXsfl_70 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_70"), ".", ","));
            nRC_GXsfl_106 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_106"), ".", ","));
            AV71DeletedTag_Grid = cgiGet( sPrefix+"vDELETEDTAG_GRID");
            wcpOAV7RoleId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7RoleId"), ".", ","));
            AV59Index_Grid = (short)(context.localUtil.CToN( cgiGet( sPrefix+"vINDEX_GRID"), ".", ","));
            Filtertagsusercontrol_grid_Emptystatemessage = cgiGet( sPrefix+"FILTERTAGSUSERCONTROL_GRID_Emptystatemessage");
            divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = (int)(context.localUtil.CToN( cgiGet( sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID_Visible"), ".", ","));
            /* Read variables values. */
            AV49FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri(sPrefix, false, "AV49FilName", AV49FilName);
            AV50FilExternalId = cgiGet( edtavFilexternalid_Internalname);
            AssignAttri(sPrefix, false, "AV50FilExternalId", AV50FilExternalId);
            AV54CheckAll_Grid = StringUtil.StrToBool( cgiGet( chkavCheckall_grid_Internalname));
            AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
            AV34XMLItems_MultipleSelection = cgiGet( edtavXmlitems_multipleselection_Internalname);
            AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
            AV53SelectedCheckAll_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedcheckall_multipleselection_Internalname));
            AssignAttri(sPrefix, false, "AV53SelectedCheckAll_MultipleSelection", AV53SelectedCheckAll_MultipleSelection);
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
         AV32MultipleSelectionItems.Clear();
         AV6GAMRole.load( AV7RoleId);
         AV5ChildRoles = AV6GAMRole.getchildren(AV9Filter, ref  AV12Errors);
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV5ChildRoles.Count )
         {
            AV10RoleAux = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV75GXV1));
            AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
            AV33MultipleSelectionItem.gxTpr_Id = AV10RoleAux.gxTpr_Id;
            AV33MultipleSelectionItem.gxTpr_Name = AV10RoleAux.gxTpr_Name;
            AV32MultipleSelectionItems.Add(AV33MultipleSelectionItem, 0);
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         AV19I_LoadCount_Skip = 0;
         AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
      }

      protected void S142( )
      {
         /* 'U_STARTPAGE' Routine */
         returnInSub = false;
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E18452 ();
         if (returnInSub) return;
      }

      protected void E18452( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         /* Execute user subroutine: 'U_OPENPAGE' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'LOADGRIDSTATE(GRID)' */
         S122 ();
         if (returnInSub) return;
         AV64FilName_PreviousValue = AV49FilName;
         AV65FilExternalId_PreviousValue = AV50FilExternalId;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
      }

      protected void E19452( )
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
         if ( (0==AV38CurrentPage_Grid) )
         {
            AV38CurrentPage_Grid = 1;
            AssignAttri(sPrefix, false, "AV38CurrentPage_Grid", StringUtil.LTrimStr( (decimal)(AV38CurrentPage_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vCURRENTPAGE_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV38CurrentPage_Grid), "ZZZ9"), context));
         }
         AV39Reload_Grid = true;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV35Reload_MultipleSelection = true;
         AssignAttri(sPrefix, false, "AV35Reload_MultipleSelection", AV35Reload_MultipleSelection);
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vRELOAD_MULTIPLESELECTION", GetSecureSignedToken( sPrefix, AV35Reload_MultipleSelection, context));
         edtavXmlitems_multipleselection_Visible = 0;
         AssignProp(sPrefix, false, edtavXmlitems_multipleselection_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavXmlitems_multipleselection_Visible), 5, 0), true);
         divTable_container_filexternalid_Visible = 0;
         AssignProp(sPrefix, false, divTable_container_filexternalid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTable_container_filexternalid_Visible), 5, 0), true);
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         if ( StringUtil.StrCmp(AV24HttpRequest.Method, "GET") == 0 )
         {
            AV60Grid_SelectedRows = 0;
            AssignAttri(sPrefix, false, "AV60Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV60Grid_SelectedRows), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV72ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /* Execute user subroutine: 'U_REFRESHPAGE' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
      }

      protected void S152( )
      {
         /* 'U_REFRESHPAGE' Routine */
         returnInSub = false;
         edtavSelected_id_Visible = 0;
         AssignProp(sPrefix, false, edtavSelected_id_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavSelected_id_Visible), 5, 0), !bGXsfl_106_Refreshing);
      }

      protected void S163( )
      {
         /* 'U_LOADSELECTEDGRIDROWVARS(MULTIPLESELECTION)' Routine */
         returnInSub = false;
      }

      protected void S292( )
      {
         /* 'RESETMULTIROWITERATOR(GRID)' Routine */
         returnInSub = false;
         AV42MultiRowIterator_Grid = 1;
         AssignAttri(sPrefix, false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
      }

      protected void S282( )
      {
         /* 'GETNEXTMULTIROW(GRID)' Routine */
         returnInSub = false;
         AV61S_Name = "";
         AssignAttri(sPrefix, false, "AV61S_Name", AV61S_Name);
         AV62S_Id = 0;
         AssignAttri(sPrefix, false, "AV62S_Id", StringUtil.LTrimStr( (decimal)(AV62S_Id), 12, 0));
         while ( ( AV42MultiRowIterator_Grid <= AV58SelectedItems_Grid.Count ) && ! ((SdtK2BSelectionItem)AV58SelectedItems_Grid.Item(AV42MultiRowIterator_Grid)).gxTpr_Isselected )
         {
            AV42MultiRowIterator_Grid = (short)(AV42MultiRowIterator_Grid+1);
            AssignAttri(sPrefix, false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
         }
         if ( AV42MultiRowIterator_Grid > AV58SelectedItems_Grid.Count )
         {
            AV41MultiRowHasNext_Grid = false;
            AssignAttri(sPrefix, false, "AV41MultiRowHasNext_Grid", AV41MultiRowHasNext_Grid);
         }
         else
         {
            AV41MultiRowHasNext_Grid = true;
            AssignAttri(sPrefix, false, "AV41MultiRowHasNext_Grid", AV41MultiRowHasNext_Grid);
            AV66FieldValues_Grid = ((SdtK2BSelectionItem)AV58SelectedItems_Grid.Item(AV42MultiRowIterator_Grid)).gxTpr_Fieldvalues;
            /* Execute user subroutine: 'GETFIELDVALUES_GRID' */
            S302 ();
            if (returnInSub) return;
         }
         AV42MultiRowIterator_Grid = (short)(AV42MultiRowIterator_Grid+1);
         AssignAttri(sPrefix, false, "AV42MultiRowIterator_Grid", StringUtil.LTrimStr( (decimal)(AV42MultiRowIterator_Grid), 4, 0));
      }

      protected void S172( )
      {
         /* 'U_CONFIRM' Routine */
         returnInSub = false;
         AV6GAMRole.load( AV7RoleId);
         AV52RoleName = AV6GAMRole.gxTpr_Name;
         AV5ChildRoles = AV6GAMRole.getchildren(AV9Filter, ref  AV12Errors);
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV51isOK = true;
         AV77GXV2 = 1;
         while ( AV77GXV2 <= AV32MultipleSelectionItems.Count )
         {
            AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV77GXV2));
            AV18Found = false;
            AV78GXV3 = 1;
            while ( AV78GXV3 <= AV5ChildRoles.Count )
            {
               AV17item = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV78GXV3));
               if ( AV17item.gxTpr_Id == AV33MultipleSelectionItem.gxTpr_Id )
               {
                  AV18Found = true;
               }
               AV78GXV3 = (int)(AV78GXV3+1);
            }
            if ( ! AV18Found )
            {
               AV51isOK = AV6GAMRole.addrolebyid(AV33MultipleSelectionItem.gxTpr_Id, ref  AV12Errors);
               if ( ! AV51isOK )
               {
                  AV79GXV4 = 1;
                  while ( AV79GXV4 <= AV12Errors.Count )
                  {
                     AV16Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV79GXV4));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV16Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV16Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV79GXV4 = (int)(AV79GXV4+1);
                  }
                  if (true) break;
               }
            }
            AV77GXV2 = (int)(AV77GXV2+1);
         }
         if ( AV51isOK )
         {
            AV80GXV5 = 1;
            while ( AV80GXV5 <= AV5ChildRoles.Count )
            {
               AV17item = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV80GXV5));
               AV18Found = false;
               AV81GXV6 = 1;
               while ( AV81GXV6 <= AV32MultipleSelectionItems.Count )
               {
                  AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV81GXV6));
                  if ( AV17item.gxTpr_Id == AV33MultipleSelectionItem.gxTpr_Id )
                  {
                     AV18Found = true;
                  }
                  AV81GXV6 = (int)(AV81GXV6+1);
               }
               if ( ! AV18Found )
               {
                  AV51isOK = AV6GAMRole.deleterolebyid(AV17item.gxTpr_Id, ref  AV12Errors);
                  if ( ! AV51isOK )
                  {
                     AV82GXV7 = 1;
                     while ( AV82GXV7 <= AV12Errors.Count )
                     {
                        AV16Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV12Errors.Item(AV82GXV7));
                        GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV16Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV16Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                        AV82GXV7 = (int)(AV82GXV7+1);
                     }
                     if (true) break;
                  }
               }
               AV80GXV5 = (int)(AV80GXV5+1);
            }
         }
         if ( AV51isOK )
         {
            context.CommitDataStores("k2bfsg.roleselectchildren",pr_default);
            GX_msglist.addItem(StringUtil.Format( "Roles hijos de %1 fueron actualizados", AV52RoleName, "", "", "", "", "", "", "", ""));
            context.DoAjaxRefreshCmp(sPrefix);
         }
      }

      protected void E11452( )
      {
         /* 'E_Confirm' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'U_CONFIRM' */
         S172 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
      }

      private void E20452( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
         AV43I_LoadCount_Grid = 0;
         AssignAttri(sPrefix, false, "AV43I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV43I_LoadCount_Grid), 4, 0));
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
         AV44Exit_Grid = false;
         while ( true )
         {
            AV43I_LoadCount_Grid = (short)(AV43I_LoadCount_Grid+1);
            AssignAttri(sPrefix, false, "AV43I_LoadCount_Grid", StringUtil.LTrimStr( (decimal)(AV43I_LoadCount_Grid), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_GRID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV43I_LoadCount_Grid), "ZZZ9"), context));
            /* Execute user subroutine: 'U_LOADROWVARS(GRID)' */
            S182 ();
            if (returnInSub) return;
            /* Execute user subroutine: 'U_AFTERDATALOAD(GRID)' */
            S192 ();
            if (returnInSub) return;
            if ( AV44Exit_Grid )
            {
               if (true) break;
            }
            tblI_noresultsfoundtablename_grid_Visible = 0;
            AssignProp(sPrefix, false, tblI_noresultsfoundtablename_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(tblI_noresultsfoundtablename_grid_Visible), 5, 0), true);
            AV40MultiRowItemSelected_Grid = false;
            AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
            AV83GXV8 = 1;
            while ( AV83GXV8 <= AV57AllSelectedItems_Grid.Count )
            {
               AV55SelectedItem_Grid = ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV83GXV8));
               if ( AV55SelectedItem_Grid.gxTpr_Sknumeric1 == AV47Id )
               {
                  if ( AV55SelectedItem_Grid.gxTpr_Isselected )
                  {
                     AV40MultiRowItemSelected_Grid = true;
                     AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
                     AV60Grid_SelectedRows = (short)(AV60Grid_SelectedRows+1);
                     AssignAttri(sPrefix, false, "AV60Grid_SelectedRows", StringUtil.LTrimStr( (decimal)(AV60Grid_SelectedRows), 4, 0));
                     GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vGRID_SELECTEDROWS", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV60Grid_SelectedRows), "ZZZ9"), context));
                  }
                  if (true) break;
               }
               AV83GXV8 = (int)(AV83GXV8+1);
            }
            if ( AV43I_LoadCount_Grid == 1 )
            {
               AV54CheckAll_Grid = true;
               AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
            }
            if ( ! AV40MultiRowItemSelected_Grid )
            {
               AV54CheckAll_Grid = false;
               AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 70;
            }
            sendrow_702( ) ;
            if ( isFullAjaxMode( ) && ! bGXsfl_70_Refreshing )
            {
               context.DoAjaxLoad(70, GridRow);
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S202 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV9Filter", AV9Filter);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
      }

      protected void S182( )
      {
         /* 'U_LOADROWVARS(GRID)' Routine */
         returnInSub = false;
         AV6GAMRole.load( AV7RoleId);
         AV9Filter.gxTpr_Name = AV49FilName;
         AV9Filter.gxTpr_Externalid = AV50FilExternalId;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         if ( AV43I_LoadCount_Grid == 1 )
         {
            AV19I_LoadCount_Skip = 0;
            AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
            AV5ChildRoles = AV6GAMRole.getchildren(AV9Filter, ref  AV12Errors);
            AV11CandidateRoles = AV6GAMRole.getunassignedroles(AV9Filter, out  AV12Errors);
         }
         AV14FoundItem = false;
         if ( AV5ChildRoles.Count + AV11CandidateRoles.Count >= AV43I_LoadCount_Grid + AV19I_LoadCount_Skip )
         {
            while ( ( AV5ChildRoles.Count >= AV43I_LoadCount_Grid + AV19I_LoadCount_Skip ) && ! AV14FoundItem )
            {
               AV45Name = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV43I_LoadCount_Grid+AV19I_LoadCount_Skip)).gxTpr_Name;
               AssignAttri(sPrefix, false, edtavName_Internalname, AV45Name);
               AV47Id = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV5ChildRoles.Item(AV43I_LoadCount_Grid+AV19I_LoadCount_Skip)).gxTpr_Id;
               AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
               /* Execute user subroutine: 'ISINCOLLECTION(MULTIPLESELECTION)' */
               S212 ();
               if (returnInSub) return;
               if ( ! AV31InCollection )
               {
                  AV14FoundItem = true;
               }
               else
               {
                  AV19I_LoadCount_Skip = (short)(AV19I_LoadCount_Skip+1);
                  AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
                  GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
               }
            }
            if ( ! AV14FoundItem )
            {
               while ( ( ( AV5ChildRoles.Count + AV11CandidateRoles.Count >= AV43I_LoadCount_Grid + AV19I_LoadCount_Skip ) ) && ! AV14FoundItem )
               {
                  AV13i = (short)(AV43I_LoadCount_Grid+AV19I_LoadCount_Skip-AV5ChildRoles.Count);
                  AV45Name = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV11CandidateRoles.Item(AV13i)).gxTpr_Name;
                  AssignAttri(sPrefix, false, edtavName_Internalname, AV45Name);
                  AV47Id = ((GeneXus.Programs.genexussecurity.SdtGAMRole)AV11CandidateRoles.Item(AV13i)).gxTpr_Id;
                  AssignAttri(sPrefix, false, edtavId_Internalname, StringUtil.LTrimStr( (decimal)(AV47Id), 12, 0));
                  /* Execute user subroutine: 'ISINCOLLECTION(MULTIPLESELECTION)' */
                  S212 ();
                  if (returnInSub) return;
                  if ( ! AV31InCollection )
                  {
                     AV14FoundItem = true;
                  }
                  else
                  {
                     AV19I_LoadCount_Skip = (short)(AV19I_LoadCount_Skip+1);
                     AssignAttri(sPrefix, false, "AV19I_LoadCount_Skip", StringUtil.LTrimStr( (decimal)(AV19I_LoadCount_Skip), 4, 0));
                     GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_vI_LOADCOUNT_SKIP", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(AV19I_LoadCount_Skip), "ZZZ9"), context));
                  }
               }
            }
         }
         if ( ! AV14FoundItem )
         {
            AV44Exit_Grid = true;
         }
      }

      protected void S212( )
      {
         /* 'ISINCOLLECTION(MULTIPLESELECTION)' Routine */
         returnInSub = false;
         AV31InCollection = false;
         AssignAttri(sPrefix, false, "AV31InCollection", AV31InCollection);
         AV84GXV9 = 1;
         while ( AV84GXV9 <= AV32MultipleSelectionItems.Count )
         {
            AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV84GXV9));
            if ( AV47Id == AV33MultipleSelectionItem.gxTpr_Id )
            {
               AV31InCollection = true;
               AssignAttri(sPrefix, false, "AV31InCollection", AV31InCollection);
               if (true) break;
            }
            AV84GXV9 = (int)(AV84GXV9+1);
         }
      }

      protected void S202( )
      {
         /* 'SAVEGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV26GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV85Pgmname,  AV26GridStateKey, out  AV27GridState) ;
         AV27GridState.gxTpr_Filtervalues.Clear();
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "FilName";
         AV28GridStateFilterValue.gxTpr_Value = AV49FilName;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         AV28GridStateFilterValue.gxTpr_Filtername = "FilExternalId";
         AV28GridStateFilterValue.gxTpr_Value = AV50FilExternalId;
         AV27GridState.gxTpr_Filtervalues.Add(AV28GridStateFilterValue, 0);
         new k2bsavegridstate(context ).execute(  AV85Pgmname,  AV26GridStateKey,  AV27GridState) ;
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE(GRID)' Routine */
         returnInSub = false;
         AV26GridStateKey = "Grid";
         new k2bloadgridstate(context ).execute(  AV85Pgmname,  AV26GridStateKey, out  AV27GridState) ;
         AV86GXV10 = 1;
         while ( AV86GXV10 <= AV27GridState.gxTpr_Filtervalues.Count )
         {
            AV28GridStateFilterValue = ((SdtK2BGridState_FilterValue)AV27GridState.gxTpr_Filtervalues.Item(AV86GXV10));
            if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "FilName") == 0 )
            {
               AV49FilName = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV49FilName", AV49FilName);
            }
            else if ( StringUtil.StrCmp(AV28GridStateFilterValue.gxTpr_Filtername, "FilExternalId") == 0 )
            {
               AV50FilExternalId = AV28GridStateFilterValue.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV50FilExternalId", AV50FilExternalId);
            }
            AV86GXV10 = (int)(AV86GXV10+1);
         }
      }

      protected void E16452( )
      {
         /* Selectedgrid_multipleselection_Drop Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         /* Execute user subroutine: 'ISINCOLLECTION(MULTIPLESELECTION)' */
         S212 ();
         if (returnInSub) return;
         if ( ! AV31InCollection )
         {
            AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
            AV33MultipleSelectionItem.gxTpr_Name = AV45Name;
            AV33MultipleSelectionItem.gxTpr_Id = AV47Id;
            AV32MultipleSelectionItems.Add(AV33MultipleSelectionItem, 0);
            AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
            AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         }
         AV40MultiRowItemSelected_Grid = false;
         AssignAttri(sPrefix, false, chkavMultirowitemselected_grid_Internalname, AV40MultiRowItemSelected_Grid);
         /* Execute user subroutine: 'U_ADDMULTIPLESELECTION(MULTIPLESELECTION)' */
         S222 ();
         if (returnInSub) return;
         AV59Index_Grid = 1;
         while ( AV59Index_Grid <= AV57AllSelectedItems_Grid.Count )
         {
            if ( ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV59Index_Grid)).gxTpr_Sknumeric1 == AV47Id )
            {
               AV57AllSelectedItems_Grid.RemoveItem(AV59Index_Grid);
            }
            else
            {
               AV59Index_Grid = (short)(AV59Index_Grid+1);
            }
         }
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV85Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV85Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
      }

      protected void E17452( )
      {
         /* Grid_Drop Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV87GXV11 = 1;
         while ( AV87GXV11 <= AV32MultipleSelectionItems.Count )
         {
            AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV87GXV11));
            if ( AV48Selected_Id == AV33MultipleSelectionItem.gxTpr_Id )
            {
               AV37SelectedGridLoadCount_MultipleSelection = (short)(AV32MultipleSelectionItems.IndexOf(AV33MultipleSelectionItem));
               AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
               if (true) break;
            }
            AV87GXV11 = (int)(AV87GXV11+1);
         }
         if ( AV37SelectedGridLoadCount_MultipleSelection != 0 )
         {
            AV32MultipleSelectionItems.RemoveItem(AV37SelectedGridLoadCount_MultipleSelection);
         }
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         AV36SelectedGridMultiRowItemSelected_MultipleSelection = false;
         AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
         /* Execute user subroutine: 'U_REMOVEMULTIPLESELECTION(MULTIPLESELECTION)' */
         S232 ();
         if (returnInSub) return;
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV85Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV85Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
      }

      protected void S222( )
      {
         /* 'U_ADDMULTIPLESELECTION(MULTIPLESELECTION)' Routine */
         returnInSub = false;
      }

      protected void S232( )
      {
         /* 'U_REMOVEMULTIPLESELECTION(MULTIPLESELECTION)' Routine */
         returnInSub = false;
      }

      protected void S242( )
      {
         /* 'U_GRIDREFRESH(GRID)' Routine */
         returnInSub = false;
      }

      protected void E21452( )
      {
         /* Grid_Refresh Routine */
         returnInSub = false;
         new k2bscadditem(context ).execute(  "Section_Grid",  true, ref  AV72ClassCollection_Grid) ;
         /* Execute user subroutine: 'UPDATEFILTERSUMMARY(GRID)' */
         S132 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'SAVEGRIDSTATE(GRID)' */
         S202 ();
         if (returnInSub) return;
         subGrid_Backcolorstyle = 3;
         /* Execute user subroutine: 'U_GRIDREFRESH(GRID)' */
         S242 ();
         if (returnInSub) return;
         AV54CheckAll_Grid = false;
         AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV72ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV70FilterTagsCollection_Grid", AV70FilterTagsCollection_Grid);
      }

      protected void E22452( )
      {
         /* Multirowitemselected_grid_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'PROCESSSELECTION(GRID)' */
         S252 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV72ClassCollection_Grid", AV72ClassCollection_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
      }

      protected void S252( )
      {
         /* 'PROCESSSELECTION(GRID)' Routine */
         returnInSub = false;
         AV54CheckAll_Grid = true;
         AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         /* Start For Each Line in Grid */
         nRC_GXsfl_70 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_70"), ".", ","));
         nGXsfl_70_fel_idx = 0;
         while ( nGXsfl_70_fel_idx < nRC_GXsfl_70 )
         {
            nGXsfl_70_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_fel_idx+1);
            sGXsfl_70_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_702( ) ;
            AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
            AV45Name = cgiGet( edtavName_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
               GX_FocusControl = edtavId_Internalname;
               wbErr = true;
               AV47Id = 0;
            }
            else
            {
               AV47Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","));
            }
            /* Execute user subroutine: 'UPDATESELECTION(GRID)' */
            S262 ();
            if (returnInSub) return;
            /* End For Each Line */
         }
         if ( nGXsfl_70_fel_idx == 0 )
         {
            nGXsfl_70_idx = 1;
            sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
            SubsflControlProps_702( ) ;
         }
         nGXsfl_70_fel_idx = 1;
         /* Execute user subroutine: 'U_MULTIROWITEMSELECTED(GRID)' */
         S272 ();
         if (returnInSub) return;
         if ( AV57AllSelectedItems_Grid.Count > 0 )
         {
            new k2bscadditem(context ).execute(  "K2BTools_GridSelecting",  true, ref  AV72ClassCollection_Grid) ;
         }
         else
         {
            new k2bscremoveitem(context ).execute(  "K2BTools_GridSelecting", ref  AV72ClassCollection_Grid) ;
         }
         GXt_char1 = "";
         new k2bscjoinstring(context ).execute(  AV72ClassCollection_Grid,  " ", out  GXt_char1) ;
         divMaingrid_responsivetable_grid_Class = GXt_char1;
         AssignProp(sPrefix, false, divMaingrid_responsivetable_grid_Internalname, "Class", divMaingrid_responsivetable_grid_Class, true);
      }

      protected void S262( )
      {
         /* 'UPDATESELECTION(GRID)' Routine */
         returnInSub = false;
         AV59Index_Grid = 1;
         while ( AV59Index_Grid <= AV57AllSelectedItems_Grid.Count )
         {
            if ( ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV59Index_Grid)).gxTpr_Sknumeric1 == AV47Id )
            {
               AV57AllSelectedItems_Grid.RemoveItem(AV59Index_Grid);
            }
            else
            {
               AV59Index_Grid = (short)(AV59Index_Grid+1);
            }
         }
         if ( AV40MultiRowItemSelected_Grid )
         {
            AV55SelectedItem_Grid = new SdtK2BSelectionItem(context);
            AV55SelectedItem_Grid.gxTpr_Isselected = AV40MultiRowItemSelected_Grid;
            AV55SelectedItem_Grid.gxTpr_Sknumeric1 = AV47Id;
            AV56FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV56FieldValue_Grid.gxTpr_Name = "Name";
            AV56FieldValue_Grid.gxTpr_Value = AV45Name;
            AV55SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV56FieldValue_Grid, 0);
            AV56FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
            AV56FieldValue_Grid.gxTpr_Name = "Id";
            AV56FieldValue_Grid.gxTpr_Value = StringUtil.Str( (decimal)(AV47Id), 12, 0);
            AV55SelectedItem_Grid.gxTpr_Fieldvalues.Add(AV56FieldValue_Grid, 0);
            AV57AllSelectedItems_Grid.Add(AV55SelectedItem_Grid, 0);
         }
         if ( ! AV40MultiRowItemSelected_Grid )
         {
            AV54CheckAll_Grid = false;
            AssignAttri(sPrefix, false, "AV54CheckAll_Grid", AV54CheckAll_Grid);
         }
      }

      protected void S272( )
      {
         /* 'U_MULTIROWITEMSELECTED(GRID)' Routine */
         returnInSub = false;
      }

      protected void S302( )
      {
         /* 'GETFIELDVALUES_GRID' Routine */
         returnInSub = false;
         AV92GXV12 = 1;
         while ( AV92GXV12 <= AV66FieldValues_Grid.Count )
         {
            AV56FieldValue_Grid = ((SdtK2BSelectionItem_FieldValuesItem)AV66FieldValues_Grid.Item(AV92GXV12));
            if ( StringUtil.StrCmp(AV56FieldValue_Grid.gxTpr_Name, "Name") == 0 )
            {
               AV61S_Name = AV56FieldValue_Grid.gxTpr_Value;
               AssignAttri(sPrefix, false, "AV61S_Name", AV61S_Name);
            }
            else if ( StringUtil.StrCmp(AV56FieldValue_Grid.gxTpr_Name, "Id") == 0 )
            {
               AV62S_Id = (long)(NumberUtil.Val( AV56FieldValue_Grid.gxTpr_Value, "."));
               AssignAttri(sPrefix, false, "AV62S_Id", StringUtil.LTrimStr( (decimal)(AV62S_Id), 12, 0));
            }
            AV92GXV12 = (int)(AV92GXV12+1);
         }
      }

      protected void S132( )
      {
         /* 'UPDATEFILTERSUMMARY(GRID)' Routine */
         returnInSub = false;
         AV68K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49FilName)) )
         {
            AV69K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Name = "FilName";
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Description = "Nombre";
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Type = "Standard";
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Value = AV49FilName;
            AV69K2BFilterValuesSDTItem_WebForm.gxTpr_Valuedescription = AV49FilName;
            AV68K2BFilterValuesSDT_WebForm.Add(AV69K2BFilterValuesSDTItem_WebForm, 0);
         }
         Filtertagsusercontrol_grid_Emptystatemessage = "No hay filtros aplicados";
         ucFiltertagsusercontrol_grid.SendProperty(context, sPrefix, false, Filtertagsusercontrol_grid_Internalname, "EmptyStateMessage", Filtertagsusercontrol_grid_Emptystatemessage);
         if ( AV68K2BFilterValuesSDT_WebForm.Count > 0 )
         {
            GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = AV70FilterTagsCollection_Grid;
            new k2bgettagcollectionforfiltervalues(context ).execute(  AV85Pgmname,  "Grid",  AV68K2BFilterValuesSDT_WebForm, out  GXt_objcol_SdtK2BValueDescriptionCollection_Item2) ;
            AV70FilterTagsCollection_Grid = GXt_objcol_SdtK2BValueDescriptionCollection_Item2;
         }
      }

      protected void E12452( )
      {
         /* Layoutdefined_filtertoggle_onlydetailed_grid_Click Routine */
         returnInSub = false;
         if ( divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible != 0 )
         {
            divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
            AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap)), true);
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap), true);
         }
         else
         {
            divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
            AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
            imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = context.GetImagePath( "0f563368-53de-4c84-a145-c3119aedd1ee", "", context.GetTheme( ));
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap)), true);
            AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap), true);
         }
         /*  Sending Event outputs  */
      }

      protected void E13452( )
      {
         /* Layoutdefined_filterclose_onlydetailed_grid_Click Routine */
         returnInSub = false;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 0;
         AssignProp(sPrefix, false, divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible), 5, 0), true);
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( ));
         AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "Bitmap", context.convertURL( context.PathToRelativeUrl( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap)), true);
         AssignProp(sPrefix, false, imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname, "SrcSet", context.GetImageSrcSet( imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap), true);
         /*  Sending Event outputs  */
      }

      protected void S192( )
      {
         /* 'U_AFTERDATALOAD(GRID)' Routine */
         returnInSub = false;
      }

      protected void E14452( )
      {
         /* 'Add(MultipleSelection)' Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         AV58SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV93GXV13 = 1;
         while ( AV93GXV13 <= AV57AllSelectedItems_Grid.Count )
         {
            AV55SelectedItem_Grid = ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV93GXV13));
            /* Start For Each Line in Grid */
            nRC_GXsfl_70 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_70"), ".", ","));
            nGXsfl_70_fel_idx = 0;
            while ( nGXsfl_70_fel_idx < nRC_GXsfl_70 )
            {
               nGXsfl_70_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_fel_idx+1);
               sGXsfl_70_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_702( ) ;
               AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
               AV45Name = cgiGet( edtavName_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                  GX_FocusControl = edtavId_Internalname;
                  wbErr = true;
                  AV47Id = 0;
               }
               else
               {
                  AV47Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","));
               }
               if ( AV55SelectedItem_Grid.gxTpr_Sknumeric1 == AV47Id )
               {
                  AV58SelectedItems_Grid.Add(AV55SelectedItem_Grid, 0);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               /* End For Each Line */
            }
            if ( nGXsfl_70_fel_idx == 0 )
            {
               nGXsfl_70_idx = 1;
               sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
               SubsflControlProps_702( ) ;
            }
            nGXsfl_70_fel_idx = 1;
            AV93GXV13 = (int)(AV93GXV13+1);
         }
         /* Execute user subroutine: 'RESETMULTIROWITERATOR(GRID)' */
         S292 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
         S282 ();
         if (returnInSub) return;
         while ( AV41MultiRowHasNext_Grid )
         {
            AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
            AV33MultipleSelectionItem.gxTpr_Name = AV61S_Name;
            AV33MultipleSelectionItem.gxTpr_Id = AV62S_Id;
            AV32MultipleSelectionItems.Add(AV33MultipleSelectionItem, 0);
            /* Execute user subroutine: 'GETNEXTMULTIROW(GRID)' */
            S282 ();
            if (returnInSub) return;
         }
         AV95GXV14 = 1;
         while ( AV95GXV14 <= AV57AllSelectedItems_Grid.Count )
         {
            AV55SelectedItem_Grid = ((SdtK2BSelectionItem)AV57AllSelectedItems_Grid.Item(AV95GXV14));
            /* Start For Each Line in Grid */
            nRC_GXsfl_70 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_70"), ".", ","));
            nGXsfl_70_fel_idx = 0;
            while ( nGXsfl_70_fel_idx < nRC_GXsfl_70 )
            {
               nGXsfl_70_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_fel_idx+1);
               sGXsfl_70_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_702( ) ;
               AV40MultiRowItemSelected_Grid = StringUtil.StrToBool( cgiGet( chkavMultirowitemselected_grid_Internalname));
               AV45Name = cgiGet( edtavName_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vID");
                  GX_FocusControl = edtavId_Internalname;
                  wbErr = true;
                  AV47Id = 0;
               }
               else
               {
                  AV47Id = (long)(context.localUtil.CToN( cgiGet( edtavId_Internalname), ".", ","));
               }
               if ( AV55SelectedItem_Grid.gxTpr_Sknumeric1 == AV47Id )
               {
                  AV55SelectedItem_Grid.gxTpr_Isselected = false;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               /* End For Each Line */
            }
            if ( nGXsfl_70_fel_idx == 0 )
            {
               nGXsfl_70_idx = 1;
               sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
               SubsflControlProps_702( ) ;
            }
            nGXsfl_70_fel_idx = 1;
            AV95GXV14 = (int)(AV95GXV14+1);
         }
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         /* Execute user subroutine: 'U_ADDMULTIPLESELECTION(MULTIPLESELECTION)' */
         S222 ();
         if (returnInSub) return;
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV85Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV85Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV58SelectedItems_Grid", AV58SelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV57AllSelectedItems_Grid", AV57AllSelectedItems_Grid);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV66FieldValues_Grid", AV66FieldValues_Grid);
      }

      protected void E15452( )
      {
         /* 'Remove(MultipleSelection)' Routine */
         returnInSub = false;
         AV32MultipleSelectionItems.FromXml(AV34XMLItems_MultipleSelection, null, "RolesSDT", "");
         /* Start For Each Line in Selectedgrid_multipleselection */
         nRC_GXsfl_106 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_106"), ".", ","));
         nGXsfl_106_fel_idx = 0;
         while ( nGXsfl_106_fel_idx < nRC_GXsfl_106 )
         {
            nGXsfl_106_fel_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_106_fel_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_fel_idx+1);
            sGXsfl_106_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_1063( ) ;
            AV36SelectedGridMultiRowItemSelected_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedgridmultirowitemselected_multipleselection_Internalname));
            AV46Selected_Name = cgiGet( edtavSelected_name_Internalname);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSELECTED_ID");
               GX_FocusControl = edtavSelected_id_Internalname;
               wbErr = true;
               AV48Selected_Id = 0;
            }
            else
            {
               AV48Selected_Id = (long)(context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ","));
            }
            if ( AV36SelectedGridMultiRowItemSelected_MultipleSelection )
            {
               AV37SelectedGridLoadCount_MultipleSelection = 0;
               AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
               AV98GXV15 = 1;
               while ( AV98GXV15 <= AV32MultipleSelectionItems.Count )
               {
                  AV33MultipleSelectionItem = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV98GXV15));
                  if ( AV48Selected_Id == AV33MultipleSelectionItem.gxTpr_Id )
                  {
                     AV37SelectedGridLoadCount_MultipleSelection = (short)(AV32MultipleSelectionItems.IndexOf(AV33MultipleSelectionItem));
                     AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
                     if (true) break;
                  }
                  AV98GXV15 = (int)(AV98GXV15+1);
               }
               if ( AV37SelectedGridLoadCount_MultipleSelection != 0 )
               {
                  AV32MultipleSelectionItems.RemoveItem(AV37SelectedGridLoadCount_MultipleSelection);
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_106_fel_idx == 0 )
         {
            nGXsfl_106_idx = 1;
            sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
            SubsflControlProps_1063( ) ;
         }
         nGXsfl_106_fel_idx = 1;
         AV36SelectedGridMultiRowItemSelected_MultipleSelection = false;
         AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
         AV34XMLItems_MultipleSelection = AV32MultipleSelectionItems.ToXml(false, true, "RolesSDT", "");
         AssignAttri(sPrefix, false, "AV34XMLItems_MultipleSelection", AV34XMLItems_MultipleSelection);
         /* Execute user subroutine: 'U_REMOVEMULTIPLESELECTION(MULTIPLESELECTION)' */
         S232 ();
         if (returnInSub) return;
         gxgrGrid_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV49FilName, AV85Pgmname, AV50FilExternalId, AV57AllSelectedItems_Grid, AV47Id, AV60Grid_SelectedRows, AV7RoleId, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV31InCollection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV35Reload_MultipleSelection, sPrefix) ;
         gxgrSelectedgrid_multipleselection_refresh( AV38CurrentPage_Grid, AV34XMLItems_MultipleSelection, AV72ClassCollection_Grid, AV35Reload_MultipleSelection, AV32MultipleSelectionItems, AV54CheckAll_Grid, AV53SelectedCheckAll_MultipleSelection, AV60Grid_SelectedRows, AV43I_LoadCount_Grid, AV19I_LoadCount_Skip, AV85Pgmname, sPrefix) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV32MultipleSelectionItems", AV32MultipleSelectionItems);
      }

      private void E23453( )
      {
         /* Selectedgrid_multipleselection_Load Routine */
         returnInSub = false;
         AV53SelectedCheckAll_MultipleSelection = false;
         AssignAttri(sPrefix, false, "AV53SelectedCheckAll_MultipleSelection", AV53SelectedCheckAll_MultipleSelection);
         if ( ! AV35Reload_MultipleSelection )
         {
            /* Start For Each Line in Selectedgrid_multipleselection */
            nRC_GXsfl_106 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_106"), ".", ","));
            nGXsfl_106_fel_idx = 0;
            while ( nGXsfl_106_fel_idx < nRC_GXsfl_106 )
            {
               nGXsfl_106_fel_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_106_fel_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_fel_idx+1);
               sGXsfl_106_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_1063( ) ;
               AV36SelectedGridMultiRowItemSelected_MultipleSelection = StringUtil.StrToBool( cgiGet( chkavSelectedgridmultirowitemselected_multipleselection_Internalname));
               AV46Selected_Name = cgiGet( edtavSelected_name_Internalname);
               if ( ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ",") > Convert.ToDecimal( 999999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vSELECTED_ID");
                  GX_FocusControl = edtavSelected_id_Internalname;
                  wbErr = true;
                  AV48Selected_Id = 0;
               }
               else
               {
                  AV48Selected_Id = (long)(context.localUtil.CToN( cgiGet( edtavSelected_id_Internalname), ".", ","));
               }
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 106;
               }
               sendrow_1063( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_106_Refreshing )
               {
                  context.DoAjaxLoad(106, Selectedgrid_multipleselectionRow);
               }
               /* End For Each Line */
            }
            if ( nGXsfl_106_fel_idx == 0 )
            {
               nGXsfl_106_idx = 1;
               sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
               SubsflControlProps_1063( ) ;
            }
            nGXsfl_106_fel_idx = 1;
         }
         else
         {
            AV37SelectedGridLoadCount_MultipleSelection = 0;
            AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
            while ( true )
            {
               AV37SelectedGridLoadCount_MultipleSelection = (short)(AV37SelectedGridLoadCount_MultipleSelection+1);
               AssignAttri(sPrefix, false, "AV37SelectedGridLoadCount_MultipleSelection", StringUtil.LTrimStr( (decimal)(AV37SelectedGridLoadCount_MultipleSelection), 4, 0));
               if ( AV37SelectedGridLoadCount_MultipleSelection > AV32MultipleSelectionItems.Count )
               {
                  if (true) break;
               }
               AV36SelectedGridMultiRowItemSelected_MultipleSelection = false;
               AssignAttri(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, AV36SelectedGridMultiRowItemSelected_MultipleSelection);
               AV46Selected_Name = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV37SelectedGridLoadCount_MultipleSelection)).gxTpr_Name;
               AssignAttri(sPrefix, false, edtavSelected_name_Internalname, AV46Selected_Name);
               AV48Selected_Id = ((GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem)AV32MultipleSelectionItems.Item(AV37SelectedGridLoadCount_MultipleSelection)).gxTpr_Id;
               AssignAttri(sPrefix, false, edtavSelected_id_Internalname, StringUtil.LTrimStr( (decimal)(AV48Selected_Id), 12, 0));
               /* Execute user subroutine: 'U_LOADSELECTEDGRIDROWVARS(MULTIPLESELECTION)' */
               S163 ();
               if (returnInSub) return;
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 106;
               }
               sendrow_1063( ) ;
               if ( isFullAjaxMode( ) && ! bGXsfl_106_Refreshing )
               {
                  context.DoAjaxLoad(106, Selectedgrid_multipleselectionRow);
               }
            }
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table5_115_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblActionscontainertableleft_actions_Internalname, tblActionscontainertableleft_actions_Internalname, "", "K2BToolsTableActionsLeftContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='K2BToolsTableCell_ActionContainer'>") ;
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'" + sPrefix + "',false,'',0)\"";
            ClassString = "K2BToolsButton_MainAction";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttConfirm_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(70), 2, 0)+","+"null"+");", "Confirmar", bttConfirm_Jsonclick, 5, "", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'E_CONFIRM\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_K2BFSG\\RoleSelectChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_115_452e( true) ;
         }
         else
         {
            wb_table5_115_452e( false) ;
         }
      }

      protected void wb_table4_90_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblSelecteduitemsmaintable_multipleselection_Internalname, tblSelecteduitemsmaintable_multipleselection_Internalname, "", "K2BToolsTable_FullWidth", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavXmlitems_multipleselection_Visible, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavXmlitems_multipleselection_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavXmlitems_multipleselection_Internalname, "XMLItems_Multiple Selection", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavXmlitems_multipleselection_Internalname, StringUtil.RTrim( AV34XMLItems_MultipleSelection), StringUtil.RTrim( context.localUtil.Format( AV34XMLItems_MultipleSelection, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,95);\"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavXmlitems_multipleselection_Jsonclick, 0, "Attribute", "", "", "", "", edtavXmlitems_multipleselection_Visible, edtavXmlitems_multipleselection_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_K2BFSG\\RoleSelectChildren.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divSelecteditemsresponsivetablecontainer_multipleselection_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table6_100_452( true) ;
         }
         else
         {
            wb_table6_100_452( false) ;
         }
         return  ;
      }

      protected void wb_table6_100_452e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_90_452e( true) ;
         }
         else
         {
            wb_table4_90_452e( false) ;
         }
      }

      protected void wb_table6_100_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainermultipleselection_multipleselection_Internalname, tblTablegridcontainermultipleselection_multipleselection_Internalname, "", "K2BToolsTable_GridContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavSelectedcheckall_multipleselection_Internalname, StringUtil.BoolToStr( AV53SelectedCheckAll_MultipleSelection), "", "", 1, chkavSelectedcheckall_multipleselection.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,104);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            Selectedgrid_multipleselectionContainer.SetWrapped(nGXWrapped);
            if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"Selectedgrid_multipleselectionContainer"+"DivS\" data-gxgridid=\"106\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subSelectedgrid_multipleselection_Internalname, subSelectedgrid_multipleselection_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subSelectedgrid_multipleselection_Backcolorstyle == 0 )
               {
                  subSelectedgrid_multipleselection_Titlebackstyle = 0;
                  if ( StringUtil.Len( subSelectedgrid_multipleselection_Class) > 0 )
                  {
                     subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Title";
                  }
               }
               else
               {
                  subSelectedgrid_multipleselection_Titlebackstyle = 1;
                  if ( subSelectedgrid_multipleselection_Backcolorstyle == 1 )
                  {
                     subSelectedgrid_multipleselection_Titlebackcolor = subSelectedgrid_multipleselection_Allbackcolor;
                     if ( StringUtil.Len( subSelectedgrid_multipleselection_Class) > 0 )
                     {
                        subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subSelectedgrid_multipleselection_Class) > 0 )
                     {
                        subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+((edtavSelected_id_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Selectedgrid_multipleselectionContainer.AddObjectProperty("GridName", "Selectedgrid_multipleselection");
            }
            else
            {
               Selectedgrid_multipleselectionContainer.AddObjectProperty("GridName", "Selectedgrid_multipleselection");
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Header", subSelectedgrid_multipleselection_Header);
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Backcolorstyle), 1, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Sortable), 1, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("CmpContext", sPrefix);
               Selectedgrid_multipleselectionContainer.AddObjectProperty("InMasterPage", "false");
               Selectedgrid_multipleselectionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Selectedgrid_multipleselectionColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV36SelectedGridMultiRowItemSelected_MultipleSelection));
               Selectedgrid_multipleselectionContainer.AddColumnProperties(Selectedgrid_multipleselectionColumn);
               Selectedgrid_multipleselectionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Selectedgrid_multipleselectionColumn.AddObjectProperty("Value", StringUtil.RTrim( AV46Selected_Name));
               Selectedgrid_multipleselectionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelected_name_Enabled), 5, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddColumnProperties(Selectedgrid_multipleselectionColumn);
               Selectedgrid_multipleselectionColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               Selectedgrid_multipleselectionColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48Selected_Id), 12, 0, ".", "")));
               Selectedgrid_multipleselectionColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelected_id_Enabled), 5, 0, ".", "")));
               Selectedgrid_multipleselectionColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSelected_id_Visible), 5, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddColumnProperties(Selectedgrid_multipleselectionColumn);
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Selectedindex), 4, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Allowselection), 1, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Selectioncolor), 9, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Allowhovering), 1, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Hoveringcolor), 9, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Allowcollapsing), 1, 0, ".", "")));
               Selectedgrid_multipleselectionContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subSelectedgrid_multipleselection_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 106 )
         {
            wbEnd = 0;
            nRC_GXsfl_106 = (int)(nGXsfl_106_idx-1);
            if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"Selectedgrid_multipleselectionContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Selectedgrid_multipleselection", Selectedgrid_multipleselectionContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData", Selectedgrid_multipleselectionContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"Selectedgrid_multipleselectionContainerData"+"V", Selectedgrid_multipleselectionContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"Selectedgrid_multipleselectionContainerData"+"V"+"\" value='"+Selectedgrid_multipleselectionContainer.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_100_452e( true) ;
         }
         else
         {
            wb_table6_100_452e( false) ;
         }
      }

      protected void wb_table3_76_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            if ( tblI_noresultsfoundtablename_grid_Visible == 0 )
            {
               sStyleString += "display:none;";
            }
            GxWebStd.gx_table_start( context, tblI_noresultsfoundtablename_grid_Internalname, tblI_noresultsfoundtablename_grid_Internalname, "", "K2BToolsTable_NoResultsFound", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblI_noresultsfoundtextblock_grid_Internalname, "No hay resultados", "", "", lblI_noresultsfoundtextblock_grid_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "K2BToolsTextBlock_NoResultsFound", 0, "", 1, 1, 0, 0, "HLP_K2BFSG\\RoleSelectChildren.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_76_452e( true) ;
         }
         else
         {
            wb_table3_76_452e( false) ;
         }
      }

      protected void wb_table2_64_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablegridcontainer_grid_Internalname, tblTablegridcontainer_grid_Internalname, "", "K2BToolsTable_GridContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'" + sPrefix + "',false,'" + sGXsfl_70_idx + "',0)\"";
            ClassString = "K2BTools_CheckAllGrid";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCheckall_grid_Internalname, StringUtil.BoolToStr( AV54CheckAll_Grid), "", "", 1, chkavCheckall_grid.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"70\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "K2BT_SG Grid_WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid_Backcolorstyle == 0 )
               {
                  subGrid_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
               else
               {
                  subGrid_Titlebackstyle = 1;
                  if ( subGrid_Backcolorstyle == 1 )
                  {
                     subGrid_Titlebackcolor = subGrid_Allbackcolor;
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid_Class) > 0 )
                     {
                        subGrid_Linesclass = subGrid_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+""+"\" "+" width="+StringUtil.LTrimStr( (decimal)(20), 4, 0)+"px"+" class=\""+"CheckBoxInGrid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Nombre") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute_Grid"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
               context.SendWebValue( "Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               GridContainer.AddObjectProperty("GridName", "Grid");
            }
            else
            {
               GridContainer.AddObjectProperty("GridName", "Grid");
               GridContainer.AddObjectProperty("Header", subGrid_Header);
               GridContainer.AddObjectProperty("Class", "K2BT_SG Grid_WorkWith");
               GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("CmpContext", sPrefix);
               GridContainer.AddObjectProperty("InMasterPage", "false");
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.BoolToStr( AV40MultiRowItemSelected_Grid));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV45Name));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
               GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47Id), 12, 0, ".", "")));
               GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
               GridContainer.AddColumnProperties(GridColumn);
               GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
               GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
               GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 70 )
         {
            wbEnd = 0;
            nRC_GXsfl_70 = (int)(nGXsfl_70_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_64_452e( true) ;
         }
         else
         {
            wb_table2_64_452e( false) ;
         }
      }

      protected void wb_table1_54_452( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblLayoutdefined_table7_grid_Internalname, tblLayoutdefined_table7_grid_Internalname, "", "K2BToolsTable_GridConfigurationContainer", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_54_452e( true) ;
         }
         else
         {
            wb_table1_54_452e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7RoleId = Convert.ToInt64(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
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
         PA452( ) ;
         WS452( ) ;
         WE452( ) ;
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
         sCtrlAV7RoleId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA452( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "k2bfsg\\roleselectchildren", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA452( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7RoleId = Convert.ToInt64(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
         }
         wcpOAV7RoleId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV7RoleId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV7RoleId != wcpOAV7RoleId ) ) )
         {
            setjustcreated();
         }
         wcpOAV7RoleId = AV7RoleId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7RoleId = cgiGet( sPrefix+"AV7RoleId_CTRL");
         if ( StringUtil.Len( sCtrlAV7RoleId) > 0 )
         {
            AV7RoleId = (long)(context.localUtil.CToN( cgiGet( sCtrlAV7RoleId), ".", ","));
            AssignAttri(sPrefix, false, "AV7RoleId", StringUtil.LTrimStr( (decimal)(AV7RoleId), 12, 0));
         }
         else
         {
            AV7RoleId = (long)(context.localUtil.CToN( cgiGet( sPrefix+"AV7RoleId_PARM"), ".", ","));
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
         PA452( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS452( ) ;
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
         WS452( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7RoleId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7RoleId), 12, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7RoleId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7RoleId_CTRL", StringUtil.RTrim( sCtrlAV7RoleId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE452( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2024188311747", true, true);
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
            context.AddJavascriptSource("k2bfsg/roleselectchildren.js", "?2024188311750", false, true);
            context.AddJavascriptSource("Shared/K2BToolsComponents/dist/k2btools-components/k2btools-components.js", "", false, true);
            context.AddJavascriptSource("K2BTagsViewer/K2BTagsViewerRender.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/toastr-master/toastr.min.js", "", false, true);
            context.AddJavascriptSource("K2BControlBeautify/K2BControlBeautifyRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_702( )
      {
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID_"+sGXsfl_70_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_70_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_70_idx;
      }

      protected void SubsflControlProps_fel_702( )
      {
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID_"+sGXsfl_70_fel_idx;
         edtavName_Internalname = sPrefix+"vNAME_"+sGXsfl_70_fel_idx;
         edtavId_Internalname = sPrefix+"vID_"+sGXsfl_70_fel_idx;
      }

      protected void sendrow_702( )
      {
         SubsflControlProps_702( ) ;
         WB450( ) ;
         GridRow = GXWebRow.GetNew(context,GridContainer);
         if ( subGrid_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
         }
         else if ( subGrid_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid_Backstyle = 0;
            subGrid_Backcolor = subGrid_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Uniform";
            }
         }
         else if ( subGrid_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
            {
               subGrid_Linesclass = subGrid_Class+"Odd";
            }
            subGrid_Backcolor = (int)(0x0);
         }
         else if ( subGrid_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid_Backstyle = 1;
            if ( ((int)((nGXsfl_70_idx) % (2))) == 0 )
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Even";
               }
            }
            else
            {
               subGrid_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
         }
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_70_idx+"\">") ;
         }
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 71,'"+sPrefix+"',false,'"+sGXsfl_70_idx+"',70)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_70_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_70_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavMultirowitemselected_grid_Internalname,StringUtil.BoolToStr( AV40MultiRowItemSelected_Grid),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsCheckBoxColumn",(string)"",TempTags+((chkavMultirowitemselected_grid.Enabled!=0)&&(chkavMultirowitemselected_grid.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,71);\"" : " ")});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 72,'"+sPrefix+"',false,'"+sGXsfl_70_idx+"',70)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV45Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,72);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)70,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 73,'"+sPrefix+"',false,'"+sGXsfl_70_idx+"',70)\"" : " ");
         ROClassString = "Attribute_Grid";
         GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavId_Enabled!=0) ? context.localUtil.Format( (decimal)(AV47Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV47Id), "ZZZZZZZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)70,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes452( ) ;
         GridContainer.AddRow(GridRow);
         nGXsfl_70_idx = ((subGrid_Islastpage==1)&&(nGXsfl_70_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_70_idx+1);
         sGXsfl_70_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_70_idx), 4, 0), 4, "0");
         SubsflControlProps_702( ) ;
         /* End function sendrow_702 */
      }

      protected void SubsflControlProps_1063( )
      {
         chkavSelectedgridmultirowitemselected_multipleselection_Internalname = sPrefix+"vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_"+sGXsfl_106_idx;
         edtavSelected_name_Internalname = sPrefix+"vSELECTED_NAME_"+sGXsfl_106_idx;
         edtavSelected_id_Internalname = sPrefix+"vSELECTED_ID_"+sGXsfl_106_idx;
      }

      protected void SubsflControlProps_fel_1063( )
      {
         chkavSelectedgridmultirowitemselected_multipleselection_Internalname = sPrefix+"vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_"+sGXsfl_106_fel_idx;
         edtavSelected_name_Internalname = sPrefix+"vSELECTED_NAME_"+sGXsfl_106_fel_idx;
         edtavSelected_id_Internalname = sPrefix+"vSELECTED_ID_"+sGXsfl_106_fel_idx;
      }

      protected void sendrow_1063( )
      {
         SubsflControlProps_1063( ) ;
         WB450( ) ;
         Selectedgrid_multipleselectionRow = GXWebRow.GetNew(context,Selectedgrid_multipleselectionContainer);
         if ( subSelectedgrid_multipleselection_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 0;
            if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
            {
               subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Odd";
            }
         }
         else if ( subSelectedgrid_multipleselection_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 0;
            subSelectedgrid_multipleselection_Backcolor = subSelectedgrid_multipleselection_Allbackcolor;
            if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
            {
               subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Uniform";
            }
         }
         else if ( subSelectedgrid_multipleselection_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 1;
            if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
            {
               subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Odd";
            }
            subSelectedgrid_multipleselection_Backcolor = (int)(0x0);
         }
         else if ( subSelectedgrid_multipleselection_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subSelectedgrid_multipleselection_Backstyle = 1;
            if ( ((int)((nGXsfl_106_idx) % (2))) == 0 )
            {
               subSelectedgrid_multipleselection_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
               {
                  subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Even";
               }
            }
            else
            {
               subSelectedgrid_multipleselection_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subSelectedgrid_multipleselection_Class, "") != 0 )
               {
                  subSelectedgrid_multipleselection_Linesclass = subSelectedgrid_multipleselection_Class+"Odd";
               }
            }
         }
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"K2BT_SG Grid_WorkWith"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_106_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Check box */
         TempTags = " " + ((chkavSelectedgridmultirowitemselected_multipleselection.Enabled!=0)&&(chkavSelectedgridmultirowitemselected_multipleselection.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 107,'"+sPrefix+"',false,'"+sGXsfl_106_idx+"',106)\"" : " ");
         ClassString = "CheckBoxInGrid";
         StyleString = "";
         GXCCtl = "vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_" + sGXsfl_106_idx;
         chkavSelectedgridmultirowitemselected_multipleselection.Name = GXCCtl;
         chkavSelectedgridmultirowitemselected_multipleselection.WebTags = "";
         chkavSelectedgridmultirowitemselected_multipleselection.Caption = "";
         AssignProp(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, "TitleCaption", chkavSelectedgridmultirowitemselected_multipleselection.Caption, !bGXsfl_106_Refreshing);
         chkavSelectedgridmultirowitemselected_multipleselection.CheckedValue = "false";
         Selectedgrid_multipleselectionRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavSelectedgridmultirowitemselected_multipleselection_Internalname,StringUtil.BoolToStr( AV36SelectedGridMultiRowItemSelected_MultipleSelection),(string)"",(string)"",(short)-1,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"K2BToolsGridColumn",(string)"",TempTags+((chkavSelectedgridmultirowitemselected_multipleselection.Enabled!=0)&&(chkavSelectedgridmultirowitemselected_multipleselection.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,107);\"" : " ")});
         /* Subfile cell */
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSelected_name_Enabled!=0)&&(edtavSelected_name_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 108,'"+sPrefix+"',false,'"+sGXsfl_106_idx+"',106)\"" : " ");
         ROClassString = "Attribute_Grid";
         Selectedgrid_multipleselectionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelected_name_Internalname,StringUtil.RTrim( AV46Selected_Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavSelected_name_Enabled!=0)&&(edtavSelected_name_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,108);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSelected_name_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn",(string)"",(short)-1,(int)edtavSelected_name_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)60,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionShort",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Selectedgrid_multipleselectionContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+((edtavSelected_id_Visible==0) ? "display:none;" : "")+"\">") ;
         }
         /* Single line edit */
         TempTags = " " + ((edtavSelected_id_Enabled!=0)&&(edtavSelected_id_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 109,'"+sPrefix+"',false,'"+sGXsfl_106_idx+"',106)\"" : " ");
         ROClassString = "Attribute_Grid";
         Selectedgrid_multipleselectionRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSelected_id_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV48Selected_Id), 12, 0, ".", "")),StringUtil.LTrim( ((edtavSelected_id_Enabled!=0) ? context.localUtil.Format( (decimal)(AV48Selected_Id), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV48Selected_Id), "ZZZZZZZZZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+((edtavSelected_id_Enabled!=0)&&(edtavSelected_id_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"" : " "),(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSelected_id_Jsonclick,(short)0,(string)"Attribute_Grid",(string)"",(string)ROClassString,(string)"K2BToolsGridColumn InvisibleInExtraSmallColumn",(string)"",(int)edtavSelected_id_Visible,(int)edtavSelected_id_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)106,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes453( ) ;
         Selectedgrid_multipleselectionContainer.AddRow(Selectedgrid_multipleselectionRow);
         nGXsfl_106_idx = ((subSelectedgrid_multipleselection_Islastpage==1)&&(nGXsfl_106_idx+1>subSelectedgrid_multipleselection_fnc_Recordsperpage( )) ? 1 : nGXsfl_106_idx+1);
         sGXsfl_106_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_106_idx), 4, 0), 4, "0");
         SubsflControlProps_1063( ) ;
         /* End function sendrow_1063 */
      }

      protected void init_web_controls( )
      {
         chkavCheckall_grid.Name = "vCHECKALL_GRID";
         chkavCheckall_grid.WebTags = "";
         chkavCheckall_grid.Caption = "";
         AssignProp(sPrefix, false, chkavCheckall_grid_Internalname, "TitleCaption", chkavCheckall_grid.Caption, true);
         chkavCheckall_grid.CheckedValue = "false";
         GXCCtl = "vMULTIROWITEMSELECTED_GRID_" + sGXsfl_70_idx;
         chkavMultirowitemselected_grid.Name = GXCCtl;
         chkavMultirowitemselected_grid.WebTags = "";
         chkavMultirowitemselected_grid.Caption = "";
         AssignProp(sPrefix, false, chkavMultirowitemselected_grid_Internalname, "TitleCaption", chkavMultirowitemselected_grid.Caption, !bGXsfl_70_Refreshing);
         chkavMultirowitemselected_grid.CheckedValue = "false";
         chkavSelectedcheckall_multipleselection.Name = "vSELECTEDCHECKALL_MULTIPLESELECTION";
         chkavSelectedcheckall_multipleselection.WebTags = "";
         chkavSelectedcheckall_multipleselection.Caption = "";
         AssignProp(sPrefix, false, chkavSelectedcheckall_multipleselection_Internalname, "TitleCaption", chkavSelectedcheckall_multipleselection.Caption, true);
         chkavSelectedcheckall_multipleselection.CheckedValue = "false";
         GXCCtl = "vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION_" + sGXsfl_106_idx;
         chkavSelectedgridmultirowitemselected_multipleselection.Name = GXCCtl;
         chkavSelectedgridmultirowitemselected_multipleselection.WebTags = "";
         chkavSelectedgridmultirowitemselected_multipleselection.Caption = "";
         AssignProp(sPrefix, false, chkavSelectedgridmultirowitemselected_multipleselection_Internalname, "TitleCaption", chkavSelectedgridmultirowitemselected_multipleselection.Caption, !bGXsfl_106_Refreshing);
         chkavSelectedgridmultirowitemselected_multipleselection.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID";
         Filtertagsusercontrol_grid_Internalname = sPrefix+"FILTERTAGSUSERCONTROL_GRID";
         divLayoutdefined_section5_grid_Internalname = sPrefix+"LAYOUTDEFINED_SECTION5_GRID";
         imgLayoutdefined_filterclose_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID";
         edtavFilname_Internalname = sPrefix+"vFILNAME";
         divTable_container_filname_Internalname = sPrefix+"TABLE_CONTAINER_FILNAME";
         edtavFilexternalid_Internalname = sPrefix+"vFILEXTERNALID";
         divTable_container_filexternalid_Internalname = sPrefix+"TABLE_CONTAINER_FILEXTERNALID";
         divFiltercontainertable_filters_Internalname = sPrefix+"FILTERCONTAINERTABLE_FILTERS";
         divMainfilterresponsivetable_filters_Internalname = sPrefix+"MAINFILTERRESPONSIVETABLE_FILTERS";
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID";
         divLayoutdefined_onlydetailedfilterlayout_grid_Internalname = sPrefix+"LAYOUTDEFINED_ONLYDETAILEDFILTERLAYOUT_GRID";
         divLayoutdefined_filterglobalcontainer_grid_Internalname = sPrefix+"LAYOUTDEFINED_FILTERGLOBALCONTAINER_GRID";
         tblLayoutdefined_table7_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE7_GRID";
         divLayoutdefined_table10_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE10_GRID";
         chkavCheckall_grid_Internalname = sPrefix+"vCHECKALL_GRID";
         chkavMultirowitemselected_grid_Internalname = sPrefix+"vMULTIROWITEMSELECTED_GRID";
         edtavName_Internalname = sPrefix+"vNAME";
         edtavId_Internalname = sPrefix+"vID";
         tblTablegridcontainer_grid_Internalname = sPrefix+"TABLEGRIDCONTAINER_GRID";
         lblI_noresultsfoundtextblock_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTEXTBLOCK_GRID";
         tblI_noresultsfoundtablename_grid_Internalname = sPrefix+"I_NORESULTSFOUNDTABLENAME_GRID";
         divMaingrid_responsivetable_grid_Internalname = sPrefix+"MAINGRID_RESPONSIVETABLE_GRID";
         divLayoutdefined_table3_grid_Internalname = sPrefix+"LAYOUTDEFINED_TABLE3_GRID";
         divLayoutdefined_grid_inner_grid_Internalname = sPrefix+"LAYOUTDEFINED_GRID_INNER_GRID";
         divGridcomponentcontent_grid_Internalname = sPrefix+"GRIDCOMPONENTCONTENT_GRID";
         imgMultipleselection_add_Internalname = sPrefix+"MULTIPLESELECTION_ADD";
         imgMultipleselection_remove_Internalname = sPrefix+"MULTIPLESELECTION_REMOVE";
         divMultipleselectionactionscontainerresponsivetable_multipleselection_Internalname = sPrefix+"MULTIPLESELECTIONACTIONSCONTAINERRESPONSIVETABLE_MULTIPLESELECTION";
         edtavXmlitems_multipleselection_Internalname = sPrefix+"vXMLITEMS_MULTIPLESELECTION";
         chkavSelectedcheckall_multipleselection_Internalname = sPrefix+"vSELECTEDCHECKALL_MULTIPLESELECTION";
         chkavSelectedgridmultirowitemselected_multipleselection_Internalname = sPrefix+"vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION";
         edtavSelected_name_Internalname = sPrefix+"vSELECTED_NAME";
         edtavSelected_id_Internalname = sPrefix+"vSELECTED_ID";
         tblTablegridcontainermultipleselection_multipleselection_Internalname = sPrefix+"TABLEGRIDCONTAINERMULTIPLESELECTION_MULTIPLESELECTION";
         divSelecteditemsresponsivetablecontainer_multipleselection_Internalname = sPrefix+"SELECTEDITEMSRESPONSIVETABLECONTAINER_MULTIPLESELECTION";
         tblSelecteduitemsmaintable_multipleselection_Internalname = sPrefix+"SELECTEDUITEMSMAINTABLE_MULTIPLESELECTION";
         divMainmultipleselectionresponsivetable_multipleselection_Internalname = sPrefix+"MAINMULTIPLESELECTIONRESPONSIVETABLE_MULTIPLESELECTION";
         bttConfirm_Internalname = sPrefix+"CONFIRM";
         tblActionscontainertableleft_actions_Internalname = sPrefix+"ACTIONSCONTAINERTABLELEFT_ACTIONS";
         divResponsivetable_containernode_actions_Internalname = sPrefix+"RESPONSIVETABLE_CONTAINERNODE_ACTIONS";
         divContenttable_Internalname = sPrefix+"CONTENTTABLE";
         K2bcontrolbeautify1_Internalname = sPrefix+"K2BCONTROLBEAUTIFY1";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
         subSelectedgrid_multipleselection_Internalname = sPrefix+"SELECTEDGRID_MULTIPLESELECTION";
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
         chkavSelectedcheckall_multipleselection.Caption = "";
         chkavCheckall_grid.Caption = "";
         edtavSelected_id_Jsonclick = "";
         edtavSelected_name_Jsonclick = "";
         edtavSelected_name_Visible = -1;
         chkavSelectedgridmultirowitemselected_multipleselection.Caption = "";
         chkavSelectedgridmultirowitemselected_multipleselection.Visible = -1;
         chkavSelectedgridmultirowitemselected_multipleselection.Enabled = 1;
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         edtavName_Jsonclick = "";
         edtavName_Visible = -1;
         chkavMultirowitemselected_grid.Caption = "";
         chkavMultirowitemselected_grid.Visible = -1;
         chkavMultirowitemselected_grid.Enabled = 1;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         edtavId_Enabled = 1;
         edtavName_Enabled = 1;
         subGrid_Header = "";
         subGrid_Class = "K2BT_SG Grid_WorkWith";
         subGrid_Backcolorstyle = 0;
         chkavCheckall_grid.Enabled = 1;
         subSelectedgrid_multipleselection_Allowcollapsing = 0;
         subSelectedgrid_multipleselection_Allowselection = 0;
         edtavSelected_id_Enabled = 1;
         edtavSelected_name_Enabled = 1;
         subSelectedgrid_multipleselection_Header = "";
         subSelectedgrid_multipleselection_Class = "K2BT_SG Grid_WorkWith";
         subSelectedgrid_multipleselection_Backcolorstyle = 0;
         chkavSelectedcheckall_multipleselection.Enabled = 1;
         edtavXmlitems_multipleselection_Jsonclick = "";
         edtavXmlitems_multipleselection_Enabled = 1;
         tblI_noresultsfoundtablename_grid_Visible = 1;
         edtavSelected_id_Visible = 0;
         edtavXmlitems_multipleselection_Visible = 1;
         subSelectedgrid_multipleselection_Sortable = 0;
         subGrid_Sortable = 0;
         divMaingrid_responsivetable_grid_Class = "Section_Grid";
         edtavFilexternalid_Jsonclick = "";
         edtavFilexternalid_Enabled = 1;
         divTable_container_filexternalid_Visible = 1;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible = 1;
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap = (string)(context.GetImagePath( "39be923f-5322-4c9e-a386-dced95576ac1", "", context.GetTheme( )));
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'sPrefix'},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.LOAD","{handler:'E23453',iparms:[{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.LOAD",",oparms:[{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',pic:''},{av:'AV46Selected_Name',fld:'vSELECTED_NAME',pic:''},{av:'AV48Selected_Id',fld:'vSELECTED_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("'E_CONFIRM'","{handler:'E11452',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'sPrefix'},{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("'E_CONFIRM'",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("GRID.LOAD","{handler:'E20452',iparms:[{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'tblI_noresultsfoundtablename_grid_Visible',ctrl:'I_NORESULTSFOUNDTABLENAME_GRID',prop:'Visible'},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV45Name',fld:'vNAME',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.DROP","{handler:'E16452',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV45Name',fld:'vNAME',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("SELECTEDGRID_MULTIPLESELECTION.DROP",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("GRID.DROP","{handler:'E17452',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV48Selected_Id',fld:'vSELECTED_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("GRID.DROP",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("GRID.REFRESH","{handler:'E21452',iparms:[{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("GRID.REFRESH",",oparms:[{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'subGrid_Backcolorstyle',ctrl:'GRID',prop:'Backcolorstyle'},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'Filtertagsusercontrol_grid_Emptystatemessage',ctrl:'FILTERTAGSUSERCONTROL_GRID',prop:'EmptyStateMessage'},{av:'AV70FilterTagsCollection_Grid',fld:'vFILTERTAGSCOLLECTION_GRID',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK","{handler:'E22452',iparms:[{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV47Id',fld:'vID',grid:70,pic:'ZZZZZZZZZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_70',ctrl:'GRID',grid:70,prop:'GridRC',grid:70},{av:'AV40MultiRowItemSelected_Grid',fld:'vMULTIROWITEMSELECTED_GRID',grid:70,pic:''},{av:'AV45Name',fld:'vNAME',grid:70,pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("VMULTIROWITEMSELECTED_GRID.CLICK",",oparms:[{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK","{handler:'E12452',iparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERTOGGLE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK","{handler:'E13452',iparms:[{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("LAYOUTDEFINED_FILTERCLOSE_ONLYDETAILED_GRID.CLICK",",oparms:[{av:'divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible',ctrl:'LAYOUTDEFINED_FILTERCOLLAPSIBLESECTION_ONLYDETAILED_GRID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("'ADD(MULTIPLESELECTION)'","{handler:'E14452',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',grid:70,pic:'ZZZZZZZZZZZ9'},{av:'nRC_GXsfl_70',ctrl:'GRID',grid:70,prop:'GridRC',grid:70},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV41MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV61S_Name',fld:'vS_NAME',pic:''},{av:'AV62S_Id',fld:'vS_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV42MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV58SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV66FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("'ADD(MULTIPLESELECTION)'",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV58SelectedItems_Grid',fld:'vSELECTEDITEMS_GRID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV42MultiRowIterator_Grid',fld:'vMULTIROWITERATOR_GRID',pic:'ZZZ9'},{av:'AV61S_Name',fld:'vS_NAME',pic:''},{av:'AV62S_Id',fld:'vS_ID',pic:'ZZZZZZZZZZZ9'},{av:'AV66FieldValues_Grid',fld:'vFIELDVALUES_GRID',pic:''},{av:'AV41MultiRowHasNext_Grid',fld:'vMULTIROWHASNEXT_GRID',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("'REMOVE(MULTIPLESELECTION)'","{handler:'E15452',iparms:[{av:'SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage'},{av:'SELECTEDGRID_MULTIPLESELECTION_nEOF'},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV72ClassCollection_Grid',fld:'vCLASSCOLLECTION_GRID',pic:''},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'AV43I_LoadCount_Grid',fld:'vI_LOADCOUNT_GRID',pic:'ZZZ9',hsh:true},{av:'AV19I_LoadCount_Skip',fld:'vI_LOADCOUNT_SKIP',pic:'ZZZ9',hsh:true},{av:'AV85Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'sPrefix'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV49FilName',fld:'vFILNAME',pic:''},{av:'AV50FilExternalId',fld:'vFILEXTERNALID',pic:''},{av:'AV57AllSelectedItems_Grid',fld:'vALLSELECTEDITEMS_GRID',pic:''},{av:'AV47Id',fld:'vID',pic:'ZZZZZZZZZZZ9'},{av:'AV7RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV31InCollection',fld:'vINCOLLECTION',pic:''},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',grid:106,pic:''},{av:'nRC_GXsfl_106',ctrl:'SELECTEDGRID_MULTIPLESELECTION',grid:106,prop:'GridRC',grid:106},{av:'AV48Selected_Id',fld:'vSELECTED_ID',grid:106,pic:'ZZZZZZZZZZZ9'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("'REMOVE(MULTIPLESELECTION)'",",oparms:[{av:'AV32MultipleSelectionItems',fld:'vMULTIPLESELECTIONITEMS',pic:''},{av:'AV37SelectedGridLoadCount_MultipleSelection',fld:'vSELECTEDGRIDLOADCOUNT_MULTIPLESELECTION',pic:'ZZZ9'},{av:'AV36SelectedGridMultiRowItemSelected_MultipleSelection',fld:'vSELECTEDGRIDMULTIROWITEMSELECTED_MULTIPLESELECTION',pic:''},{av:'AV34XMLItems_MultipleSelection',fld:'vXMLITEMS_MULTIPLESELECTION',pic:''},{av:'AV38CurrentPage_Grid',fld:'vCURRENTPAGE_GRID',pic:'ZZZ9',hsh:true},{av:'AV35Reload_MultipleSelection',fld:'vRELOAD_MULTIPLESELECTION',pic:'',hsh:true},{av:'edtavXmlitems_multipleselection_Visible',ctrl:'vXMLITEMS_MULTIPLESELECTION',prop:'Visible'},{av:'divTable_container_filexternalid_Visible',ctrl:'TABLE_CONTAINER_FILEXTERNALID',prop:'Visible'},{av:'AV60Grid_SelectedRows',fld:'vGRID_SELECTEDROWS',pic:'ZZZ9',hsh:true},{av:'divMaingrid_responsivetable_grid_Class',ctrl:'MAINGRID_RESPONSIVETABLE_GRID',prop:'Class'},{av:'edtavSelected_id_Visible',ctrl:'vSELECTED_ID',prop:'Visible'},{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Id',iparms:[{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
         setEventMetadata("NULL","{handler:'Validv_Selected_id',iparms:[{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]");
         setEventMetadata("NULL",",oparms:[{av:'AV54CheckAll_Grid',fld:'vCHECKALL_GRID',pic:''},{av:'AV53SelectedCheckAll_MultipleSelection',fld:'vSELECTEDCHECKALL_MULTIPLESELECTION',pic:''}]}");
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
         AV34XMLItems_MultipleSelection = "";
         AV72ClassCollection_Grid = new GxSimpleCollection<string>();
         AV49FilName = "";
         AV85Pgmname = "";
         AV50FilExternalId = "";
         AV57AllSelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV32MultipleSelectionItems = new GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem>( context, "RolesSDTItem", "kb_ticket");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV70FilterTagsCollection_Grid = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         AV71DeletedTag_Grid = "";
         AV61S_Name = "";
         AV58SelectedItems_Grid = new GXBaseCollection<SdtK2BSelectionItem>( context, "K2BSelectionItem", "kb_ticket");
         AV66FieldValues_Grid = new GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem>( context, "K2BSelectionItem.FieldValuesItem", "kb_ticket");
         AV55SelectedItem_Grid = new SdtK2BSelectionItem(context);
         AV56FieldValue_Grid = new SdtK2BSelectionItem_FieldValuesItem(context);
         Filtertagsusercontrol_grid_Emptystatemessage = "";
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         sImgUrl = "";
         imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick = "";
         ucFiltertagsusercontrol_grid = new GXUserControl();
         imgLayoutdefined_filterclose_onlydetailed_grid_Jsonclick = "";
         imgMultipleselection_add_Jsonclick = "";
         imgMultipleselection_remove_Jsonclick = "";
         ucK2bcontrolbeautify1 = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Selectedgrid_multipleselectionContainer = new GXWebGrid( context);
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV45Name = "";
         AV46Selected_Name = "";
         AV6GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV5ChildRoles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV9Filter = new GeneXus.Programs.genexussecurity.SdtGAMRoleFilter(context);
         AV12Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV10RoleAux = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV33MultipleSelectionItem = new GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem(context);
         AV64FilName_PreviousValue = "";
         AV65FilExternalId_PreviousValue = "";
         AV24HttpRequest = new GxHttpRequest( context);
         AV52RoleName = "";
         AV17item = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV16Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         GridRow = new GXWebRow();
         AV11CandidateRoles = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole>( context, "GeneXus.Programs.genexussecurity.SdtGAMRole", "GeneXus.Programs");
         AV26GridStateKey = "";
         AV27GridState = new SdtK2BGridState(context);
         AV28GridStateFilterValue = new SdtK2BGridState_FilterValue(context);
         GXt_char1 = "";
         AV68K2BFilterValuesSDT_WebForm = new GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem>( context, "K2BFilterValuesSDTItem", "kb_ticket");
         AV69K2BFilterValuesSDTItem_WebForm = new SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem(context);
         GXt_objcol_SdtK2BValueDescriptionCollection_Item2 = new GXBaseCollection<SdtK2BValueDescriptionCollection_Item>( context, "Item", "kb_ticket");
         Selectedgrid_multipleselectionRow = new GXWebRow();
         bttConfirm_Jsonclick = "";
         subSelectedgrid_multipleselection_Linesclass = "";
         Selectedgrid_multipleselectionColumn = new GXWebColumn();
         lblI_noresultsfoundtextblock_grid_Jsonclick = "";
         subGrid_Linesclass = "";
         GridColumn = new GXWebColumn();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7RoleId = "";
         GXCCtl = "";
         ROClassString = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectchildren__datastore2(),
            new Object[][] {
            }
         );
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectchildren__datastore1(),
            new Object[][] {
            }
         );
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectchildren__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.k2bfsg.roleselectchildren__default(),
            new Object[][] {
            }
         );
         AV85Pgmname = "K2BFSG.RoleSelectChildren";
         /* GeneXus formulas. */
         AV85Pgmname = "K2BFSG.RoleSelectChildren";
         context.Gx_err = 0;
         edtavName_Enabled = 0;
         edtavId_Enabled = 0;
         edtavSelected_name_Enabled = 0;
         edtavSelected_id_Enabled = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short AV38CurrentPage_Grid ;
      private short AV60Grid_SelectedRows ;
      private short AV43I_LoadCount_Grid ;
      private short AV19I_LoadCount_Skip ;
      private short initialized ;
      private short nGXWrapped ;
      private short AV37SelectedGridLoadCount_MultipleSelection ;
      private short AV42MultiRowIterator_Grid ;
      private short AV59Index_Grid ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short subSelectedgrid_multipleselection_Backcolorstyle ;
      private short subSelectedgrid_multipleselection_Sortable ;
      private short GRID_nEOF ;
      private short SELECTEDGRID_MULTIPLESELECTION_nEOF ;
      private short AV13i ;
      private short subSelectedgrid_multipleselection_Titlebackstyle ;
      private short subSelectedgrid_multipleselection_Allowselection ;
      private short subSelectedgrid_multipleselection_Allowhovering ;
      private short subSelectedgrid_multipleselection_Allowcollapsing ;
      private short subSelectedgrid_multipleselection_Collapsed ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private short subGrid_Backstyle ;
      private short subSelectedgrid_multipleselection_Backstyle ;
      private int divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Visible ;
      private int nRC_GXsfl_70 ;
      private int nRC_GXsfl_106 ;
      private int nGXsfl_70_idx=1 ;
      private int nGXsfl_106_idx=1 ;
      private int edtavName_Enabled ;
      private int edtavId_Enabled ;
      private int edtavSelected_name_Enabled ;
      private int edtavSelected_id_Enabled ;
      private int edtavFilname_Enabled ;
      private int divTable_container_filexternalid_Visible ;
      private int edtavFilexternalid_Enabled ;
      private int subGrid_Islastpage ;
      private int subSelectedgrid_multipleselection_Islastpage ;
      private int AV75GXV1 ;
      private int edtavXmlitems_multipleselection_Visible ;
      private int edtavSelected_id_Visible ;
      private int AV77GXV2 ;
      private int AV78GXV3 ;
      private int AV79GXV4 ;
      private int AV80GXV5 ;
      private int AV81GXV6 ;
      private int AV82GXV7 ;
      private int tblI_noresultsfoundtablename_grid_Visible ;
      private int AV83GXV8 ;
      private int AV84GXV9 ;
      private int AV86GXV10 ;
      private int AV87GXV11 ;
      private int nGXsfl_70_fel_idx=1 ;
      private int AV92GXV12 ;
      private int AV93GXV13 ;
      private int AV95GXV14 ;
      private int nGXsfl_106_fel_idx=1 ;
      private int AV98GXV15 ;
      private int edtavXmlitems_multipleselection_Enabled ;
      private int subSelectedgrid_multipleselection_Titlebackcolor ;
      private int subSelectedgrid_multipleselection_Allbackcolor ;
      private int subSelectedgrid_multipleselection_Selectedindex ;
      private int subSelectedgrid_multipleselection_Selectioncolor ;
      private int subSelectedgrid_multipleselection_Hoveringcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int edtavName_Visible ;
      private int edtavId_Visible ;
      private int subSelectedgrid_multipleselection_Backcolor ;
      private int edtavSelected_name_Visible ;
      private long AV7RoleId ;
      private long wcpOAV7RoleId ;
      private long AV47Id ;
      private long AV62S_Id ;
      private long AV48Selected_Id ;
      private long GRID_nCurrentRecord ;
      private long SELECTEDGRID_MULTIPLESELECTION_nCurrentRecord ;
      private long GRID_nFirstRecordOnPage ;
      private long SELECTEDGRID_MULTIPLESELECTION_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_70_idx="0001" ;
      private string AV34XMLItems_MultipleSelection ;
      private string AV49FilName ;
      private string AV85Pgmname ;
      private string AV50FilExternalId ;
      private string sGXsfl_106_idx="0001" ;
      private string edtavName_Internalname ;
      private string edtavId_Internalname ;
      private string edtavSelected_name_Internalname ;
      private string edtavSelected_id_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string AV71DeletedTag_Grid ;
      private string AV61S_Name ;
      private string Filtertagsusercontrol_grid_Emptystatemessage ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divContenttable_Internalname ;
      private string divMainmultipleselectionresponsivetable_multipleselection_Internalname ;
      private string divGridcomponentcontent_grid_Internalname ;
      private string divLayoutdefined_grid_inner_grid_Internalname ;
      private string divLayoutdefined_table10_grid_Internalname ;
      private string divLayoutdefined_filterglobalcontainer_grid_Internalname ;
      private string divLayoutdefined_onlydetailedfilterlayout_grid_Internalname ;
      private string divLayoutdefined_section5_grid_Internalname ;
      private string TempTags ;
      private string sImgUrl ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Jsonclick ;
      private string Filtertagsusercontrol_grid_Internalname ;
      private string divLayoutdefined_filtercollapsiblesection_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filterclose_onlydetailed_grid_Internalname ;
      private string imgLayoutdefined_filterclose_onlydetailed_grid_Jsonclick ;
      private string divMainfilterresponsivetable_filters_Internalname ;
      private string divFiltercontainertable_filters_Internalname ;
      private string divTable_container_filname_Internalname ;
      private string edtavFilname_Internalname ;
      private string edtavFilname_Jsonclick ;
      private string divTable_container_filexternalid_Internalname ;
      private string edtavFilexternalid_Internalname ;
      private string edtavFilexternalid_Jsonclick ;
      private string divLayoutdefined_table3_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Internalname ;
      private string divMaingrid_responsivetable_grid_Class ;
      private string divMultipleselectionactionscontainerresponsivetable_multipleselection_Internalname ;
      private string imgMultipleselection_add_Internalname ;
      private string imgMultipleselection_add_Jsonclick ;
      private string imgMultipleselection_remove_Internalname ;
      private string imgMultipleselection_remove_Jsonclick ;
      private string divResponsivetable_containernode_actions_Internalname ;
      private string K2bcontrolbeautify1_Internalname ;
      private string sStyleString ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string chkavMultirowitemselected_grid_Internalname ;
      private string AV45Name ;
      private string chkavSelectedgridmultirowitemselected_multipleselection_Internalname ;
      private string AV46Selected_Name ;
      private string chkavCheckall_grid_Internalname ;
      private string edtavXmlitems_multipleselection_Internalname ;
      private string chkavSelectedcheckall_multipleselection_Internalname ;
      private string AV64FilName_PreviousValue ;
      private string AV65FilExternalId_PreviousValue ;
      private string AV52RoleName ;
      private string tblI_noresultsfoundtablename_grid_Internalname ;
      private string sGXsfl_70_fel_idx="0001" ;
      private string GXt_char1 ;
      private string sGXsfl_106_fel_idx="0001" ;
      private string tblActionscontainertableleft_actions_Internalname ;
      private string bttConfirm_Internalname ;
      private string bttConfirm_Jsonclick ;
      private string tblSelecteduitemsmaintable_multipleselection_Internalname ;
      private string edtavXmlitems_multipleselection_Jsonclick ;
      private string divSelecteditemsresponsivetablecontainer_multipleselection_Internalname ;
      private string tblTablegridcontainermultipleselection_multipleselection_Internalname ;
      private string subSelectedgrid_multipleselection_Internalname ;
      private string subSelectedgrid_multipleselection_Class ;
      private string subSelectedgrid_multipleselection_Linesclass ;
      private string subSelectedgrid_multipleselection_Header ;
      private string lblI_noresultsfoundtextblock_grid_Internalname ;
      private string lblI_noresultsfoundtextblock_grid_Jsonclick ;
      private string tblTablegridcontainer_grid_Internalname ;
      private string subGrid_Internalname ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string subGrid_Header ;
      private string tblLayoutdefined_table7_grid_Internalname ;
      private string sCtrlAV7RoleId ;
      private string GXCCtl ;
      private string ROClassString ;
      private string edtavName_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string edtavSelected_name_Jsonclick ;
      private string edtavSelected_id_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV31InCollection ;
      private bool AV54CheckAll_Grid ;
      private bool AV53SelectedCheckAll_MultipleSelection ;
      private bool AV35Reload_MultipleSelection ;
      private bool bGXsfl_70_Refreshing=false ;
      private bool bGXsfl_106_Refreshing=false ;
      private bool AV41MultiRowHasNext_Grid ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV40MultiRowItemSelected_Grid ;
      private bool AV36SelectedGridMultiRowItemSelected_MultipleSelection ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool AV39Reload_Grid ;
      private bool AV51isOK ;
      private bool AV18Found ;
      private bool AV44Exit_Grid ;
      private bool AV14FoundItem ;
      private string AV26GridStateKey ;
      private string imgLayoutdefined_filtertoggle_onlydetailed_grid_Bitmap ;
      private GXWebGrid GridContainer ;
      private GXWebGrid Selectedgrid_multipleselectionContainer ;
      private GXWebRow GridRow ;
      private GXWebRow Selectedgrid_multipleselectionRow ;
      private GXWebColumn Selectedgrid_multipleselectionColumn ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucFiltertagsusercontrol_grid ;
      private GXUserControl ucK2bcontrolbeautify1 ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_RoleId ;
      private GXCheckbox chkavCheckall_grid ;
      private GXCheckbox chkavMultirowitemselected_grid ;
      private GXCheckbox chkavSelectedcheckall_multipleselection ;
      private GXCheckbox chkavSelectedgridmultirowitemselected_multipleselection ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private IDataStoreProvider pr_datastore1 ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV24HttpRequest ;
      private GxSimpleCollection<string> AV72ClassCollection_Grid ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV5ChildRoles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRole> AV11CandidateRoles ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV12Errors ;
      private GXBaseCollection<GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem> AV32MultipleSelectionItems ;
      private GXBaseCollection<SdtK2BSelectionItem> AV57AllSelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem> AV58SelectedItems_Grid ;
      private GXBaseCollection<SdtK2BSelectionItem_FieldValuesItem> AV66FieldValues_Grid ;
      private GXBaseCollection<SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem> AV68K2BFilterValuesSDT_WebForm ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> AV70FilterTagsCollection_Grid ;
      private GXBaseCollection<SdtK2BValueDescriptionCollection_Item> GXt_objcol_SdtK2BValueDescriptionCollection_Item2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV6GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV10RoleAux ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV17item ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV16Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRoleFilter AV9Filter ;
      private GeneXus.Programs.k2bfsg.SdtRolesSDT_RolesSDTItem AV33MultipleSelectionItem ;
      private SdtK2BGridState AV27GridState ;
      private SdtK2BGridState_FilterValue AV28GridStateFilterValue ;
      private SdtK2BSelectionItem AV55SelectedItem_Grid ;
      private SdtK2BSelectionItem_FieldValuesItem AV56FieldValue_Grid ;
      private SdtK2BFilterValuesSDT_K2BFilterValuesSDTItem AV69K2BFilterValuesSDTItem_WebForm ;
   }

   public class roleselectchildren__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class roleselectchildren__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

public class roleselectchildren__gam : DataStoreHelperBase, IDataStoreHelper
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

public class roleselectchildren__default : DataStoreHelperBase, IDataStoreHelper
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
